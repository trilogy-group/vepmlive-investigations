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

namespace EPMLiveCore.Layouts.epmlive
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Layouts.epmlive.ReportFilterViewCreator" />)
    ///     and namespace <see cref="EPMLiveCore.Layouts.epmlive"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public partial class ReportFilterViewCreatorTest : AbstractBaseSetupTypedTest<ReportFilterViewCreator>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportFilterViewCreator) Initializer

        private const string MethodPage_Init = "Page_Init";
        private const string MethodCreateViewButton_Click = "CreateViewButton_Click";
        private const string MethodHideListWebPartAndRemoveOtherWebParts = "HideListWebPartAndRemoveOtherWebParts";
        private const string MethodUpdateViewHtmlAndSave = "UpdateViewHtmlAndSave";
        private const string MethodCreateListView = "CreateListView";
        private const string MethodAddEpmLiveWebPartTagToTopOfContents = "AddEpmLiveWebPartTagToTopOfContents";
        private const string MethodGetViewContentBasedOnLayoutType = "GetViewContentBasedOnLayoutType";
        private const string MethodInsertViewContentIntoContentPlaceHolder = "InsertViewContentIntoContentPlaceHolder";
        private const string MethodGetHeaderFooter3ColumnLayout = "GetHeaderFooter3ColumnLayout";
        private const string MethodGetFullPageVerticalLayout = "GetFullPageVerticalLayout";
        private const string MethodGetHeaderLeftColumnBodyLayout = "GetHeaderLeftColumnBodyLayout";
        private const string MethodGetHeaderRightColumnBodyLayout = "GetHeaderRightColumnBodyLayout";
        private Type _reportFilterViewCreatorInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportFilterViewCreator _reportFilterViewCreatorInstance;
        private ReportFilterViewCreator _reportFilterViewCreatorInstanceFixture;

        #region General Initializer : Class (ReportFilterViewCreator) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportFilterViewCreator" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportFilterViewCreatorInstanceType = typeof(ReportFilterViewCreator);
            _reportFilterViewCreatorInstanceFixture = Create(true);
            _reportFilterViewCreatorInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportFilterViewCreator)

        #region General Initializer : Class (ReportFilterViewCreator) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ReportFilterViewCreator" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Init, 0)]
        [TestCase(MethodCreateViewButton_Click, 0)]
        [TestCase(MethodHideListWebPartAndRemoveOtherWebParts, 0)]
        [TestCase(MethodUpdateViewHtmlAndSave, 0)]
        [TestCase(MethodCreateListView, 0)]
        [TestCase(MethodAddEpmLiveWebPartTagToTopOfContents, 0)]
        [TestCase(MethodGetViewContentBasedOnLayoutType, 0)]
        [TestCase(MethodInsertViewContentIntoContentPlaceHolder, 0)]
        [TestCase(MethodGetHeaderFooter3ColumnLayout, 0)]
        [TestCase(MethodGetFullPageVerticalLayout, 0)]
        [TestCase(MethodGetHeaderLeftColumnBodyLayout, 0)]
        [TestCase(MethodGetHeaderRightColumnBodyLayout, 0)]
        public void AUT_ReportFilterViewCreator_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_reportFilterViewCreatorInstanceFixture, 
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
        ///     Class (<see cref="ReportFilterViewCreator" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ReportFilterViewCreator_Is_Instance_Present_Test()
        {
            // Assert
            _reportFilterViewCreatorInstanceType.ShouldNotBeNull();
            _reportFilterViewCreatorInstance.ShouldNotBeNull();
            _reportFilterViewCreatorInstanceFixture.ShouldNotBeNull();
            _reportFilterViewCreatorInstance.ShouldBeAssignableTo<ReportFilterViewCreator>();
            _reportFilterViewCreatorInstanceFixture.ShouldBeAssignableTo<ReportFilterViewCreator>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ReportFilterViewCreator) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ReportFilterViewCreator_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ReportFilterViewCreator instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _reportFilterViewCreatorInstanceType.ShouldNotBeNull();
            _reportFilterViewCreatorInstance.ShouldNotBeNull();
            _reportFilterViewCreatorInstanceFixture.ShouldNotBeNull();
            _reportFilterViewCreatorInstance.ShouldBeAssignableTo<ReportFilterViewCreator>();
            _reportFilterViewCreatorInstanceFixture.ShouldBeAssignableTo<ReportFilterViewCreator>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="ReportFilterViewCreator" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodHideListWebPartAndRemoveOtherWebParts)]
        [TestCase(MethodUpdateViewHtmlAndSave)]
        [TestCase(MethodCreateListView)]
        [TestCase(MethodAddEpmLiveWebPartTagToTopOfContents)]
        [TestCase(MethodGetViewContentBasedOnLayoutType)]
        [TestCase(MethodInsertViewContentIntoContentPlaceHolder)]
        [TestCase(MethodGetHeaderFooter3ColumnLayout)]
        [TestCase(MethodGetFullPageVerticalLayout)]
        [TestCase(MethodGetHeaderLeftColumnBodyLayout)]
        [TestCase(MethodGetHeaderRightColumnBodyLayout)]
        public void AUT_ReportFilterViewCreator_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_reportFilterViewCreatorInstanceFixture,
                                                                              _reportFilterViewCreatorInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ReportFilterViewCreator" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Init)]
        [TestCase(MethodCreateViewButton_Click)]
        public void AUT_ReportFilterViewCreator_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ReportFilterViewCreator>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Init) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportFilterViewCreator_Page_Init_Method_Call_Internally(Type[] types)
        {
            var methodPage_InitPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportFilterViewCreatorInstance, MethodPage_Init, Fixture, methodPage_InitPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Init) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_Page_Init_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_InitPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Init = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Init, methodPage_InitPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportFilterViewCreatorInstanceFixture, parametersOfPage_Init);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPage_Init.ShouldNotBeNull();
            parametersOfPage_Init.Length.ShouldBe(2);
            methodPage_InitPrametersTypes.Length.ShouldBe(2);
            methodPage_InitPrametersTypes.Length.ShouldBe(parametersOfPage_Init.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Page_Init) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_Page_Init_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_InitPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Init = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportFilterViewCreatorInstance, MethodPage_Init, parametersOfPage_Init, methodPage_InitPrametersTypes);

            // Assert
            parametersOfPage_Init.ShouldNotBeNull();
            parametersOfPage_Init.Length.ShouldBe(2);
            methodPage_InitPrametersTypes.Length.ShouldBe(2);
            methodPage_InitPrametersTypes.Length.ShouldBe(parametersOfPage_Init.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Init) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_Page_Init_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPage_Init, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Page_Init) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_Page_Init_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_InitPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportFilterViewCreatorInstance, MethodPage_Init, Fixture, methodPage_InitPrametersTypes);

            // Assert
            methodPage_InitPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Init) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_Page_Init_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Init, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportFilterViewCreatorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateViewButton_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportFilterViewCreator_CreateViewButton_Click_Method_Call_Internally(Type[] types)
        {
            var methodCreateViewButton_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportFilterViewCreatorInstance, MethodCreateViewButton_Click, Fixture, methodCreateViewButton_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateViewButton_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_CreateViewButton_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodCreateViewButton_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfCreateViewButton_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateViewButton_Click, methodCreateViewButton_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportFilterViewCreatorInstanceFixture, parametersOfCreateViewButton_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateViewButton_Click.ShouldNotBeNull();
            parametersOfCreateViewButton_Click.Length.ShouldBe(2);
            methodCreateViewButton_ClickPrametersTypes.Length.ShouldBe(2);
            methodCreateViewButton_ClickPrametersTypes.Length.ShouldBe(parametersOfCreateViewButton_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CreateViewButton_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_CreateViewButton_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodCreateViewButton_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfCreateViewButton_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportFilterViewCreatorInstance, MethodCreateViewButton_Click, parametersOfCreateViewButton_Click, methodCreateViewButton_ClickPrametersTypes);

            // Assert
            parametersOfCreateViewButton_Click.ShouldNotBeNull();
            parametersOfCreateViewButton_Click.Length.ShouldBe(2);
            methodCreateViewButton_ClickPrametersTypes.Length.ShouldBe(2);
            methodCreateViewButton_ClickPrametersTypes.Length.ShouldBe(parametersOfCreateViewButton_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateViewButton_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_CreateViewButton_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreateViewButton_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateViewButton_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_CreateViewButton_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateViewButton_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportFilterViewCreatorInstance, MethodCreateViewButton_Click, Fixture, methodCreateViewButton_ClickPrametersTypes);

            // Assert
            methodCreateViewButton_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateViewButton_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_CreateViewButton_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateViewButton_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportFilterViewCreatorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HideListWebPartAndRemoveOtherWebParts) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportFilterViewCreator_HideListWebPartAndRemoveOtherWebParts_Static_Method_Call_Internally(Type[] types)
        {
            var methodHideListWebPartAndRemoveOtherWebPartsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterViewCreatorInstanceFixture, _reportFilterViewCreatorInstanceType, MethodHideListWebPartAndRemoveOtherWebParts, Fixture, methodHideListWebPartAndRemoveOtherWebPartsPrametersTypes);
        }

        #endregion

        #region Method Call : (HideListWebPartAndRemoveOtherWebParts) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_HideListWebPartAndRemoveOtherWebParts_Static_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var view = CreateType<SPView>();
            var methodHideListWebPartAndRemoveOtherWebPartsPrametersTypes = new Type[] { typeof(SPView) };
            object[] parametersOfHideListWebPartAndRemoveOtherWebParts = { view };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodHideListWebPartAndRemoveOtherWebParts, methodHideListWebPartAndRemoveOtherWebPartsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportFilterViewCreatorInstanceFixture, parametersOfHideListWebPartAndRemoveOtherWebParts);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfHideListWebPartAndRemoveOtherWebParts.ShouldNotBeNull();
            parametersOfHideListWebPartAndRemoveOtherWebParts.Length.ShouldBe(1);
            methodHideListWebPartAndRemoveOtherWebPartsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (HideListWebPartAndRemoveOtherWebParts) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_HideListWebPartAndRemoveOtherWebParts_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var view = CreateType<SPView>();
            var methodHideListWebPartAndRemoveOtherWebPartsPrametersTypes = new Type[] { typeof(SPView) };
            object[] parametersOfHideListWebPartAndRemoveOtherWebParts = { view };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_reportFilterViewCreatorInstanceFixture, _reportFilterViewCreatorInstanceType, MethodHideListWebPartAndRemoveOtherWebParts, parametersOfHideListWebPartAndRemoveOtherWebParts, methodHideListWebPartAndRemoveOtherWebPartsPrametersTypes);

            // Assert
            parametersOfHideListWebPartAndRemoveOtherWebParts.ShouldNotBeNull();
            parametersOfHideListWebPartAndRemoveOtherWebParts.Length.ShouldBe(1);
            methodHideListWebPartAndRemoveOtherWebPartsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HideListWebPartAndRemoveOtherWebParts) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_HideListWebPartAndRemoveOtherWebParts_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodHideListWebPartAndRemoveOtherWebParts, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (HideListWebPartAndRemoveOtherWebParts) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_HideListWebPartAndRemoveOtherWebParts_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodHideListWebPartAndRemoveOtherWebPartsPrametersTypes = new Type[] { typeof(SPView) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterViewCreatorInstanceFixture, _reportFilterViewCreatorInstanceType, MethodHideListWebPartAndRemoveOtherWebParts, Fixture, methodHideListWebPartAndRemoveOtherWebPartsPrametersTypes);

            // Assert
            methodHideListWebPartAndRemoveOtherWebPartsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HideListWebPartAndRemoveOtherWebParts) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_HideListWebPartAndRemoveOtherWebParts_Static_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodHideListWebPartAndRemoveOtherWebParts, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportFilterViewCreatorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateViewHtmlAndSave) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportFilterViewCreator_UpdateViewHtmlAndSave_Static_Method_Call_Internally(Type[] types)
        {
            var methodUpdateViewHtmlAndSavePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterViewCreatorInstanceFixture, _reportFilterViewCreatorInstanceType, MethodUpdateViewHtmlAndSave, Fixture, methodUpdateViewHtmlAndSavePrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateViewHtmlAndSave) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_UpdateViewHtmlAndSave_Static_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var listToCreateViewOn = CreateType<SPList>();
            var selectedLayout = CreateType<string>();
            var view = CreateType<SPView>();
            var methodUpdateViewHtmlAndSavePrametersTypes = new Type[] { typeof(SPList), typeof(string), typeof(SPView) };
            object[] parametersOfUpdateViewHtmlAndSave = { listToCreateViewOn, selectedLayout, view };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateViewHtmlAndSave, methodUpdateViewHtmlAndSavePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportFilterViewCreatorInstanceFixture, parametersOfUpdateViewHtmlAndSave);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateViewHtmlAndSave.ShouldNotBeNull();
            parametersOfUpdateViewHtmlAndSave.Length.ShouldBe(3);
            methodUpdateViewHtmlAndSavePrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateViewHtmlAndSave) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_UpdateViewHtmlAndSave_Static_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listToCreateViewOn = CreateType<SPList>();
            var selectedLayout = CreateType<string>();
            var view = CreateType<SPView>();
            var methodUpdateViewHtmlAndSavePrametersTypes = new Type[] { typeof(SPList), typeof(string), typeof(SPView) };
            object[] parametersOfUpdateViewHtmlAndSave = { listToCreateViewOn, selectedLayout, view };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_reportFilterViewCreatorInstanceFixture, _reportFilterViewCreatorInstanceType, MethodUpdateViewHtmlAndSave, parametersOfUpdateViewHtmlAndSave, methodUpdateViewHtmlAndSavePrametersTypes);

            // Assert
            parametersOfUpdateViewHtmlAndSave.ShouldNotBeNull();
            parametersOfUpdateViewHtmlAndSave.Length.ShouldBe(3);
            methodUpdateViewHtmlAndSavePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateViewHtmlAndSave) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_UpdateViewHtmlAndSave_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateViewHtmlAndSave, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateViewHtmlAndSave) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_UpdateViewHtmlAndSave_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateViewHtmlAndSavePrametersTypes = new Type[] { typeof(SPList), typeof(string), typeof(SPView) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterViewCreatorInstanceFixture, _reportFilterViewCreatorInstanceType, MethodUpdateViewHtmlAndSave, Fixture, methodUpdateViewHtmlAndSavePrametersTypes);

            // Assert
            methodUpdateViewHtmlAndSavePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateViewHtmlAndSave) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_UpdateViewHtmlAndSave_Static_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateViewHtmlAndSave, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportFilterViewCreatorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateListView) (Return Type : SPView) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportFilterViewCreator_CreateListView_Static_Method_Call_Internally(Type[] types)
        {
            var methodCreateListViewPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterViewCreatorInstanceFixture, _reportFilterViewCreatorInstanceType, MethodCreateListView, Fixture, methodCreateListViewPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateListView) (Return Type : SPView) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_CreateListView_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listToCreateViewOn = CreateType<SPList>();
            var viewName = CreateType<string>();
            var methodCreateListViewPrametersTypes = new Type[] { typeof(SPList), typeof(string) };
            object[] parametersOfCreateListView = { listToCreateViewOn, viewName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCreateListView, methodCreateListViewPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterViewCreatorInstanceFixture, _reportFilterViewCreatorInstanceType, MethodCreateListView, Fixture, methodCreateListViewPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<SPView>(_reportFilterViewCreatorInstanceFixture, _reportFilterViewCreatorInstanceType, MethodCreateListView, parametersOfCreateListView, methodCreateListViewPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_reportFilterViewCreatorInstanceFixture, parametersOfCreateListView);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfCreateListView.ShouldNotBeNull();
            parametersOfCreateListView.Length.ShouldBe(2);
            methodCreateListViewPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CreateListView) (Return Type : SPView) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_CreateListView_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listToCreateViewOn = CreateType<SPList>();
            var viewName = CreateType<string>();
            var methodCreateListViewPrametersTypes = new Type[] { typeof(SPList), typeof(string) };
            object[] parametersOfCreateListView = { listToCreateViewOn, viewName };

            // Assert
            parametersOfCreateListView.ShouldNotBeNull();
            parametersOfCreateListView.Length.ShouldBe(2);
            methodCreateListViewPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<SPView>(_reportFilterViewCreatorInstanceFixture, _reportFilterViewCreatorInstanceType, MethodCreateListView, parametersOfCreateListView, methodCreateListViewPrametersTypes));
        }

        #endregion

        #region Method Call : (CreateListView) (Return Type : SPView) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_CreateListView_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCreateListViewPrametersTypes = new Type[] { typeof(SPList), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterViewCreatorInstanceFixture, _reportFilterViewCreatorInstanceType, MethodCreateListView, Fixture, methodCreateListViewPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCreateListViewPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (CreateListView) (Return Type : SPView) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_CreateListView_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateListViewPrametersTypes = new Type[] { typeof(SPList), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterViewCreatorInstanceFixture, _reportFilterViewCreatorInstanceType, MethodCreateListView, Fixture, methodCreateListViewPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreateListViewPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateListView) (Return Type : SPView) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_CreateListView_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateListView, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportFilterViewCreatorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateListView) (Return Type : SPView) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_CreateListView_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreateListView, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddEpmLiveWebPartTagToTopOfContents) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportFilterViewCreator_AddEpmLiveWebPartTagToTopOfContents_Static_Method_Call_Internally(Type[] types)
        {
            var methodAddEpmLiveWebPartTagToTopOfContentsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterViewCreatorInstanceFixture, _reportFilterViewCreatorInstanceType, MethodAddEpmLiveWebPartTagToTopOfContents, Fixture, methodAddEpmLiveWebPartTagToTopOfContentsPrametersTypes);
        }

        #endregion

        #region Method Call : (AddEpmLiveWebPartTagToTopOfContents) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_AddEpmLiveWebPartTagToTopOfContents_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var fileContents = CreateType<string>();
            var methodAddEpmLiveWebPartTagToTopOfContentsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfAddEpmLiveWebPartTagToTopOfContents = { fileContents };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddEpmLiveWebPartTagToTopOfContents, methodAddEpmLiveWebPartTagToTopOfContentsPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddEpmLiveWebPartTagToTopOfContents.ShouldNotBeNull();
            parametersOfAddEpmLiveWebPartTagToTopOfContents.Length.ShouldBe(1);
            methodAddEpmLiveWebPartTagToTopOfContentsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(_reportFilterViewCreatorInstanceFixture, parametersOfAddEpmLiveWebPartTagToTopOfContents));
        }

        #endregion

        #region Method Call : (AddEpmLiveWebPartTagToTopOfContents) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_AddEpmLiveWebPartTagToTopOfContents_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var fileContents = CreateType<string>();
            var methodAddEpmLiveWebPartTagToTopOfContentsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfAddEpmLiveWebPartTagToTopOfContents = { fileContents };

            // Assert
            parametersOfAddEpmLiveWebPartTagToTopOfContents.ShouldNotBeNull();
            parametersOfAddEpmLiveWebPartTagToTopOfContents.Length.ShouldBe(1);
            methodAddEpmLiveWebPartTagToTopOfContentsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_reportFilterViewCreatorInstanceFixture, _reportFilterViewCreatorInstanceType, MethodAddEpmLiveWebPartTagToTopOfContents, parametersOfAddEpmLiveWebPartTagToTopOfContents, methodAddEpmLiveWebPartTagToTopOfContentsPrametersTypes));
        }

        #endregion

        #region Method Call : (AddEpmLiveWebPartTagToTopOfContents) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_AddEpmLiveWebPartTagToTopOfContents_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodAddEpmLiveWebPartTagToTopOfContentsPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterViewCreatorInstanceFixture, _reportFilterViewCreatorInstanceType, MethodAddEpmLiveWebPartTagToTopOfContents, Fixture, methodAddEpmLiveWebPartTagToTopOfContentsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodAddEpmLiveWebPartTagToTopOfContentsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (AddEpmLiveWebPartTagToTopOfContents) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_AddEpmLiveWebPartTagToTopOfContents_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddEpmLiveWebPartTagToTopOfContentsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterViewCreatorInstanceFixture, _reportFilterViewCreatorInstanceType, MethodAddEpmLiveWebPartTagToTopOfContents, Fixture, methodAddEpmLiveWebPartTagToTopOfContentsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAddEpmLiveWebPartTagToTopOfContentsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddEpmLiveWebPartTagToTopOfContents) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_AddEpmLiveWebPartTagToTopOfContents_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddEpmLiveWebPartTagToTopOfContents, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportFilterViewCreatorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (AddEpmLiveWebPartTagToTopOfContents) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_AddEpmLiveWebPartTagToTopOfContents_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddEpmLiveWebPartTagToTopOfContents, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetViewContentBasedOnLayoutType) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportFilterViewCreator_GetViewContentBasedOnLayoutType_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetViewContentBasedOnLayoutTypePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterViewCreatorInstanceFixture, _reportFilterViewCreatorInstanceType, MethodGetViewContentBasedOnLayoutType, Fixture, methodGetViewContentBasedOnLayoutTypePrametersTypes);
        }

        #endregion

        #region Method Call : (GetViewContentBasedOnLayoutType) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_GetViewContentBasedOnLayoutType_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var selectedLayout = CreateType<string>();
            var methodGetViewContentBasedOnLayoutTypePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetViewContentBasedOnLayoutType = { selectedLayout };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetViewContentBasedOnLayoutType, methodGetViewContentBasedOnLayoutTypePrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetViewContentBasedOnLayoutType.ShouldNotBeNull();
            parametersOfGetViewContentBasedOnLayoutType.Length.ShouldBe(1);
            methodGetViewContentBasedOnLayoutTypePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(_reportFilterViewCreatorInstanceFixture, parametersOfGetViewContentBasedOnLayoutType));
        }

        #endregion

        #region Method Call : (GetViewContentBasedOnLayoutType) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_GetViewContentBasedOnLayoutType_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var selectedLayout = CreateType<string>();
            var methodGetViewContentBasedOnLayoutTypePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetViewContentBasedOnLayoutType = { selectedLayout };

            // Assert
            parametersOfGetViewContentBasedOnLayoutType.ShouldNotBeNull();
            parametersOfGetViewContentBasedOnLayoutType.Length.ShouldBe(1);
            methodGetViewContentBasedOnLayoutTypePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_reportFilterViewCreatorInstanceFixture, _reportFilterViewCreatorInstanceType, MethodGetViewContentBasedOnLayoutType, parametersOfGetViewContentBasedOnLayoutType, methodGetViewContentBasedOnLayoutTypePrametersTypes));
        }

        #endregion

        #region Method Call : (GetViewContentBasedOnLayoutType) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_GetViewContentBasedOnLayoutType_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetViewContentBasedOnLayoutTypePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterViewCreatorInstanceFixture, _reportFilterViewCreatorInstanceType, MethodGetViewContentBasedOnLayoutType, Fixture, methodGetViewContentBasedOnLayoutTypePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetViewContentBasedOnLayoutTypePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetViewContentBasedOnLayoutType) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_GetViewContentBasedOnLayoutType_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetViewContentBasedOnLayoutTypePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterViewCreatorInstanceFixture, _reportFilterViewCreatorInstanceType, MethodGetViewContentBasedOnLayoutType, Fixture, methodGetViewContentBasedOnLayoutTypePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetViewContentBasedOnLayoutTypePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetViewContentBasedOnLayoutType) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_GetViewContentBasedOnLayoutType_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetViewContentBasedOnLayoutType, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportFilterViewCreatorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetViewContentBasedOnLayoutType) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_GetViewContentBasedOnLayoutType_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetViewContentBasedOnLayoutType, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InsertViewContentIntoContentPlaceHolder) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportFilterViewCreator_InsertViewContentIntoContentPlaceHolder_Static_Method_Call_Internally(Type[] types)
        {
            var methodInsertViewContentIntoContentPlaceHolderPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterViewCreatorInstanceFixture, _reportFilterViewCreatorInstanceType, MethodInsertViewContentIntoContentPlaceHolder, Fixture, methodInsertViewContentIntoContentPlaceHolderPrametersTypes);
        }

        #endregion

        #region Method Call : (InsertViewContentIntoContentPlaceHolder) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_InsertViewContentIntoContentPlaceHolder_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var fileContents = CreateType<string>();
            var viewContent = CreateType<string>();
            var methodInsertViewContentIntoContentPlaceHolderPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfInsertViewContentIntoContentPlaceHolder = { fileContents, viewContent };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInsertViewContentIntoContentPlaceHolder, methodInsertViewContentIntoContentPlaceHolderPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInsertViewContentIntoContentPlaceHolder.ShouldNotBeNull();
            parametersOfInsertViewContentIntoContentPlaceHolder.Length.ShouldBe(2);
            methodInsertViewContentIntoContentPlaceHolderPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => methodInfo.Invoke(_reportFilterViewCreatorInstanceFixture, parametersOfInsertViewContentIntoContentPlaceHolder));
        }

        #endregion

        #region Method Call : (InsertViewContentIntoContentPlaceHolder) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_InsertViewContentIntoContentPlaceHolder_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var fileContents = CreateType<string>();
            var viewContent = CreateType<string>();
            var methodInsertViewContentIntoContentPlaceHolderPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfInsertViewContentIntoContentPlaceHolder = { fileContents, viewContent };

            // Assert
            parametersOfInsertViewContentIntoContentPlaceHolder.ShouldNotBeNull();
            parametersOfInsertViewContentIntoContentPlaceHolder.Length.ShouldBe(2);
            methodInsertViewContentIntoContentPlaceHolderPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_reportFilterViewCreatorInstanceFixture, _reportFilterViewCreatorInstanceType, MethodInsertViewContentIntoContentPlaceHolder, parametersOfInsertViewContentIntoContentPlaceHolder, methodInsertViewContentIntoContentPlaceHolderPrametersTypes));
        }

        #endregion

        #region Method Call : (InsertViewContentIntoContentPlaceHolder) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_InsertViewContentIntoContentPlaceHolder_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodInsertViewContentIntoContentPlaceHolderPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterViewCreatorInstanceFixture, _reportFilterViewCreatorInstanceType, MethodInsertViewContentIntoContentPlaceHolder, Fixture, methodInsertViewContentIntoContentPlaceHolderPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodInsertViewContentIntoContentPlaceHolderPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (InsertViewContentIntoContentPlaceHolder) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_InsertViewContentIntoContentPlaceHolder_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInsertViewContentIntoContentPlaceHolderPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterViewCreatorInstanceFixture, _reportFilterViewCreatorInstanceType, MethodInsertViewContentIntoContentPlaceHolder, Fixture, methodInsertViewContentIntoContentPlaceHolderPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodInsertViewContentIntoContentPlaceHolderPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InsertViewContentIntoContentPlaceHolder) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_InsertViewContentIntoContentPlaceHolder_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInsertViewContentIntoContentPlaceHolder, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportFilterViewCreatorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (InsertViewContentIntoContentPlaceHolder) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_InsertViewContentIntoContentPlaceHolder_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodInsertViewContentIntoContentPlaceHolder, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetHeaderFooter3ColumnLayout) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportFilterViewCreator_GetHeaderFooter3ColumnLayout_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetHeaderFooter3ColumnLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterViewCreatorInstanceFixture, _reportFilterViewCreatorInstanceType, MethodGetHeaderFooter3ColumnLayout, Fixture, methodGetHeaderFooter3ColumnLayoutPrametersTypes);
        }

        #endregion

        #region Method Call : (GetHeaderFooter3ColumnLayout) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_GetHeaderFooter3ColumnLayout_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetHeaderFooter3ColumnLayoutPrametersTypes = null;
            object[] parametersOfGetHeaderFooter3ColumnLayout = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetHeaderFooter3ColumnLayout, methodGetHeaderFooter3ColumnLayoutPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetHeaderFooter3ColumnLayout.ShouldBeNull();
            methodGetHeaderFooter3ColumnLayoutPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => methodInfo.Invoke(_reportFilterViewCreatorInstanceFixture, parametersOfGetHeaderFooter3ColumnLayout));
        }

        #endregion

        #region Method Call : (GetHeaderFooter3ColumnLayout) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_GetHeaderFooter3ColumnLayout_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetHeaderFooter3ColumnLayoutPrametersTypes = null;
            object[] parametersOfGetHeaderFooter3ColumnLayout = null; // no parameter present

            // Assert
            parametersOfGetHeaderFooter3ColumnLayout.ShouldBeNull();
            methodGetHeaderFooter3ColumnLayoutPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_reportFilterViewCreatorInstanceFixture, _reportFilterViewCreatorInstanceType, MethodGetHeaderFooter3ColumnLayout, parametersOfGetHeaderFooter3ColumnLayout, methodGetHeaderFooter3ColumnLayoutPrametersTypes));
        }

        #endregion

        #region Method Call : (GetHeaderFooter3ColumnLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_GetHeaderFooter3ColumnLayout_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetHeaderFooter3ColumnLayoutPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterViewCreatorInstanceFixture, _reportFilterViewCreatorInstanceType, MethodGetHeaderFooter3ColumnLayout, Fixture, methodGetHeaderFooter3ColumnLayoutPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetHeaderFooter3ColumnLayoutPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetHeaderFooter3ColumnLayout) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_GetHeaderFooter3ColumnLayout_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetHeaderFooter3ColumnLayoutPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterViewCreatorInstanceFixture, _reportFilterViewCreatorInstanceType, MethodGetHeaderFooter3ColumnLayout, Fixture, methodGetHeaderFooter3ColumnLayoutPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetHeaderFooter3ColumnLayoutPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetHeaderFooter3ColumnLayout) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_GetHeaderFooter3ColumnLayout_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetHeaderFooter3ColumnLayout, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportFilterViewCreatorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetFullPageVerticalLayout) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportFilterViewCreator_GetFullPageVerticalLayout_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFullPageVerticalLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterViewCreatorInstanceFixture, _reportFilterViewCreatorInstanceType, MethodGetFullPageVerticalLayout, Fixture, methodGetFullPageVerticalLayoutPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFullPageVerticalLayout) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_GetFullPageVerticalLayout_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetFullPageVerticalLayoutPrametersTypes = null;
            object[] parametersOfGetFullPageVerticalLayout = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetFullPageVerticalLayout, methodGetFullPageVerticalLayoutPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetFullPageVerticalLayout.ShouldBeNull();
            methodGetFullPageVerticalLayoutPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => methodInfo.Invoke(_reportFilterViewCreatorInstanceFixture, parametersOfGetFullPageVerticalLayout));
        }

        #endregion

        #region Method Call : (GetFullPageVerticalLayout) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_GetFullPageVerticalLayout_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetFullPageVerticalLayoutPrametersTypes = null;
            object[] parametersOfGetFullPageVerticalLayout = null; // no parameter present

            // Assert
            parametersOfGetFullPageVerticalLayout.ShouldBeNull();
            methodGetFullPageVerticalLayoutPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_reportFilterViewCreatorInstanceFixture, _reportFilterViewCreatorInstanceType, MethodGetFullPageVerticalLayout, parametersOfGetFullPageVerticalLayout, methodGetFullPageVerticalLayoutPrametersTypes));
        }

        #endregion

        #region Method Call : (GetFullPageVerticalLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_GetFullPageVerticalLayout_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetFullPageVerticalLayoutPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterViewCreatorInstanceFixture, _reportFilterViewCreatorInstanceType, MethodGetFullPageVerticalLayout, Fixture, methodGetFullPageVerticalLayoutPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFullPageVerticalLayoutPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFullPageVerticalLayout) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_GetFullPageVerticalLayout_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetFullPageVerticalLayoutPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterViewCreatorInstanceFixture, _reportFilterViewCreatorInstanceType, MethodGetFullPageVerticalLayout, Fixture, methodGetFullPageVerticalLayoutPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFullPageVerticalLayoutPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFullPageVerticalLayout) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_GetFullPageVerticalLayout_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFullPageVerticalLayout, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportFilterViewCreatorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetHeaderLeftColumnBodyLayout) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportFilterViewCreator_GetHeaderLeftColumnBodyLayout_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetHeaderLeftColumnBodyLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterViewCreatorInstanceFixture, _reportFilterViewCreatorInstanceType, MethodGetHeaderLeftColumnBodyLayout, Fixture, methodGetHeaderLeftColumnBodyLayoutPrametersTypes);
        }

        #endregion

        #region Method Call : (GetHeaderLeftColumnBodyLayout) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_GetHeaderLeftColumnBodyLayout_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetHeaderLeftColumnBodyLayoutPrametersTypes = null;
            object[] parametersOfGetHeaderLeftColumnBodyLayout = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetHeaderLeftColumnBodyLayout, methodGetHeaderLeftColumnBodyLayoutPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetHeaderLeftColumnBodyLayout.ShouldBeNull();
            methodGetHeaderLeftColumnBodyLayoutPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => methodInfo.Invoke(_reportFilterViewCreatorInstanceFixture, parametersOfGetHeaderLeftColumnBodyLayout));
        }

        #endregion

        #region Method Call : (GetHeaderLeftColumnBodyLayout) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_GetHeaderLeftColumnBodyLayout_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetHeaderLeftColumnBodyLayoutPrametersTypes = null;
            object[] parametersOfGetHeaderLeftColumnBodyLayout = null; // no parameter present

            // Assert
            parametersOfGetHeaderLeftColumnBodyLayout.ShouldBeNull();
            methodGetHeaderLeftColumnBodyLayoutPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_reportFilterViewCreatorInstanceFixture, _reportFilterViewCreatorInstanceType, MethodGetHeaderLeftColumnBodyLayout, parametersOfGetHeaderLeftColumnBodyLayout, methodGetHeaderLeftColumnBodyLayoutPrametersTypes));
        }

        #endregion

        #region Method Call : (GetHeaderLeftColumnBodyLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_GetHeaderLeftColumnBodyLayout_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetHeaderLeftColumnBodyLayoutPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterViewCreatorInstanceFixture, _reportFilterViewCreatorInstanceType, MethodGetHeaderLeftColumnBodyLayout, Fixture, methodGetHeaderLeftColumnBodyLayoutPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetHeaderLeftColumnBodyLayoutPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetHeaderLeftColumnBodyLayout) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_GetHeaderLeftColumnBodyLayout_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetHeaderLeftColumnBodyLayoutPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterViewCreatorInstanceFixture, _reportFilterViewCreatorInstanceType, MethodGetHeaderLeftColumnBodyLayout, Fixture, methodGetHeaderLeftColumnBodyLayoutPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetHeaderLeftColumnBodyLayoutPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetHeaderLeftColumnBodyLayout) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_GetHeaderLeftColumnBodyLayout_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetHeaderLeftColumnBodyLayout, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportFilterViewCreatorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetHeaderRightColumnBodyLayout) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportFilterViewCreator_GetHeaderRightColumnBodyLayout_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetHeaderRightColumnBodyLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterViewCreatorInstanceFixture, _reportFilterViewCreatorInstanceType, MethodGetHeaderRightColumnBodyLayout, Fixture, methodGetHeaderRightColumnBodyLayoutPrametersTypes);
        }

        #endregion

        #region Method Call : (GetHeaderRightColumnBodyLayout) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_GetHeaderRightColumnBodyLayout_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetHeaderRightColumnBodyLayoutPrametersTypes = null;
            object[] parametersOfGetHeaderRightColumnBodyLayout = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetHeaderRightColumnBodyLayout, methodGetHeaderRightColumnBodyLayoutPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetHeaderRightColumnBodyLayout.ShouldBeNull();
            methodGetHeaderRightColumnBodyLayoutPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => methodInfo.Invoke(_reportFilterViewCreatorInstanceFixture, parametersOfGetHeaderRightColumnBodyLayout));
        }

        #endregion

        #region Method Call : (GetHeaderRightColumnBodyLayout) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_GetHeaderRightColumnBodyLayout_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetHeaderRightColumnBodyLayoutPrametersTypes = null;
            object[] parametersOfGetHeaderRightColumnBodyLayout = null; // no parameter present

            // Assert
            parametersOfGetHeaderRightColumnBodyLayout.ShouldBeNull();
            methodGetHeaderRightColumnBodyLayoutPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_reportFilterViewCreatorInstanceFixture, _reportFilterViewCreatorInstanceType, MethodGetHeaderRightColumnBodyLayout, parametersOfGetHeaderRightColumnBodyLayout, methodGetHeaderRightColumnBodyLayoutPrametersTypes));
        }

        #endregion

        #region Method Call : (GetHeaderRightColumnBodyLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_GetHeaderRightColumnBodyLayout_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetHeaderRightColumnBodyLayoutPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterViewCreatorInstanceFixture, _reportFilterViewCreatorInstanceType, MethodGetHeaderRightColumnBodyLayout, Fixture, methodGetHeaderRightColumnBodyLayoutPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetHeaderRightColumnBodyLayoutPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetHeaderRightColumnBodyLayout) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_GetHeaderRightColumnBodyLayout_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetHeaderRightColumnBodyLayoutPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportFilterViewCreatorInstanceFixture, _reportFilterViewCreatorInstanceType, MethodGetHeaderRightColumnBodyLayout, Fixture, methodGetHeaderRightColumnBodyLayoutPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetHeaderRightColumnBodyLayoutPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetHeaderRightColumnBodyLayout) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportFilterViewCreator_GetHeaderRightColumnBodyLayout_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetHeaderRightColumnBodyLayout, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportFilterViewCreatorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion
    }
}
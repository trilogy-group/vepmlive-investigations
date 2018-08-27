using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.Layouts.EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Layouts.EPMLiveCore.createsite" />)
    ///     and namespace <see cref="EPMLiveCore.Layouts.EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CreatesiteTest : AbstractBaseSetupTypedTest<createsite>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (createsite) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodSelector_ContextChange = "Selector_ContextChange";
        private const string MethodBtnCreateSite_Click = "BtnCreateSite_Click";
        private const string MethodBtnCancel_Click = "BtnCancel_Click";
        private const string MethodEnsureSiteCollectionFeaturesActivated = "EnsureSiteCollectionFeaturesActivated";
        private const string MethodGetFeatureDefinitionsInSolution = "GetFeatureDefinitionsInSolution";
        private const string MethodGetSiteGroup = "GetSiteGroup";
        private const string Methodaddfile = "addfile";
        private const string MethodmapReports = "mapReports";
        private const string MethodcreateSite = "createSite";
        private const string Fieldapp = "app";
        private Type _createsiteInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private createsite _createsiteInstance;
        private createsite _createsiteInstanceFixture;

        #region General Initializer : Class (createsite) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="createsite" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _createsiteInstanceType = typeof(createsite);
            _createsiteInstanceFixture = Create(true);
            _createsiteInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (createsite)

        #region General Initializer : Class (createsite) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="createsite" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodSelector_ContextChange, 0)]
        [TestCase(MethodBtnCreateSite_Click, 0)]
        [TestCase(MethodBtnCancel_Click, 0)]
        [TestCase(MethodEnsureSiteCollectionFeaturesActivated, 0)]
        [TestCase(MethodGetFeatureDefinitionsInSolution, 0)]
        [TestCase(MethodGetSiteGroup, 0)]
        [TestCase(Methodaddfile, 0)]
        [TestCase(MethodmapReports, 0)]
        [TestCase(MethodcreateSite, 0)]
        public void AUT_Createsite_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_createsiteInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (createsite) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="createsite" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldapp)]
        public void AUT_Createsite_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_createsiteInstanceFixture, 
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
        ///     Class (<see cref="createsite" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Createsite_Is_Instance_Present_Test()
        {
            // Assert
            _createsiteInstanceType.ShouldNotBeNull();
            _createsiteInstance.ShouldNotBeNull();
            _createsiteInstanceFixture.ShouldNotBeNull();
            _createsiteInstance.ShouldBeAssignableTo<createsite>();
            _createsiteInstanceFixture.ShouldBeAssignableTo<createsite>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (createsite) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_createsite_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            createsite instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _createsiteInstanceType.ShouldNotBeNull();
            _createsiteInstance.ShouldNotBeNull();
            _createsiteInstanceFixture.ShouldNotBeNull();
            _createsiteInstance.ShouldBeAssignableTo<createsite>();
            _createsiteInstanceFixture.ShouldBeAssignableTo<createsite>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="createsite" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodEnsureSiteCollectionFeaturesActivated)]
        [TestCase(MethodGetFeatureDefinitionsInSolution)]
        [TestCase(MethodGetSiteGroup)]
        [TestCase(Methodaddfile)]
        public void AUT_Createsite_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_createsiteInstanceFixture,
                                                                              _createsiteInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="createsite" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodSelector_ContextChange)]
        [TestCase(MethodBtnCreateSite_Click)]
        [TestCase(MethodBtnCancel_Click)]
        [TestCase(MethodmapReports)]
        [TestCase(MethodcreateSite)]
        public void AUT_Createsite_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<createsite>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Createsite_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createsiteInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_createsiteInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Createsite_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_createsiteInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Createsite_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Createsite_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createsiteInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_createsiteInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Selector_ContextChange) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Createsite_Selector_ContextChange_Method_Call_Internally(Type[] types)
        {
            var methodSelector_ContextChangePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createsiteInstance, MethodSelector_ContextChange, Fixture, methodSelector_ContextChangePrametersTypes);
        }

        #endregion

        #region Method Call : (Selector_ContextChange) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_Selector_ContextChange_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodSelector_ContextChangePrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfSelector_ContextChange = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSelector_ContextChange, methodSelector_ContextChangePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_createsiteInstanceFixture, parametersOfSelector_ContextChange);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSelector_ContextChange.ShouldNotBeNull();
            parametersOfSelector_ContextChange.Length.ShouldBe(2);
            methodSelector_ContextChangePrametersTypes.Length.ShouldBe(2);
            methodSelector_ContextChangePrametersTypes.Length.ShouldBe(parametersOfSelector_ContextChange.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Selector_ContextChange) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_Selector_ContextChange_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodSelector_ContextChangePrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfSelector_ContextChange = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_createsiteInstance, MethodSelector_ContextChange, parametersOfSelector_ContextChange, methodSelector_ContextChangePrametersTypes);

            // Assert
            parametersOfSelector_ContextChange.ShouldNotBeNull();
            parametersOfSelector_ContextChange.Length.ShouldBe(2);
            methodSelector_ContextChangePrametersTypes.Length.ShouldBe(2);
            methodSelector_ContextChangePrametersTypes.Length.ShouldBe(parametersOfSelector_ContextChange.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Selector_ContextChange) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_Selector_ContextChange_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSelector_ContextChange, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Selector_ContextChange) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_Selector_ContextChange_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSelector_ContextChangePrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createsiteInstance, MethodSelector_ContextChange, Fixture, methodSelector_ContextChangePrametersTypes);

            // Assert
            methodSelector_ContextChangePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Selector_ContextChange) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_Selector_ContextChange_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSelector_ContextChange, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_createsiteInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BtnCreateSite_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Createsite_BtnCreateSite_Click_Method_Call_Internally(Type[] types)
        {
            var methodBtnCreateSite_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createsiteInstance, MethodBtnCreateSite_Click, Fixture, methodBtnCreateSite_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (BtnCreateSite_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_BtnCreateSite_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodBtnCreateSite_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfBtnCreateSite_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBtnCreateSite_Click, methodBtnCreateSite_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_createsiteInstanceFixture, parametersOfBtnCreateSite_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfBtnCreateSite_Click.ShouldNotBeNull();
            parametersOfBtnCreateSite_Click.Length.ShouldBe(2);
            methodBtnCreateSite_ClickPrametersTypes.Length.ShouldBe(2);
            methodBtnCreateSite_ClickPrametersTypes.Length.ShouldBe(parametersOfBtnCreateSite_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (BtnCreateSite_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_BtnCreateSite_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodBtnCreateSite_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfBtnCreateSite_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_createsiteInstance, MethodBtnCreateSite_Click, parametersOfBtnCreateSite_Click, methodBtnCreateSite_ClickPrametersTypes);

            // Assert
            parametersOfBtnCreateSite_Click.ShouldNotBeNull();
            parametersOfBtnCreateSite_Click.Length.ShouldBe(2);
            methodBtnCreateSite_ClickPrametersTypes.Length.ShouldBe(2);
            methodBtnCreateSite_ClickPrametersTypes.Length.ShouldBe(parametersOfBtnCreateSite_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BtnCreateSite_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_BtnCreateSite_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBtnCreateSite_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BtnCreateSite_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_BtnCreateSite_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBtnCreateSite_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createsiteInstance, MethodBtnCreateSite_Click, Fixture, methodBtnCreateSite_ClickPrametersTypes);

            // Assert
            methodBtnCreateSite_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BtnCreateSite_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_BtnCreateSite_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBtnCreateSite_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_createsiteInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BtnCancel_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Createsite_BtnCancel_Click_Method_Call_Internally(Type[] types)
        {
            var methodBtnCancel_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createsiteInstance, MethodBtnCancel_Click, Fixture, methodBtnCancel_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (BtnCancel_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_BtnCancel_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodBtnCancel_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfBtnCancel_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBtnCancel_Click, methodBtnCancel_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_createsiteInstanceFixture, parametersOfBtnCancel_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfBtnCancel_Click.ShouldNotBeNull();
            parametersOfBtnCancel_Click.Length.ShouldBe(2);
            methodBtnCancel_ClickPrametersTypes.Length.ShouldBe(2);
            methodBtnCancel_ClickPrametersTypes.Length.ShouldBe(parametersOfBtnCancel_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (BtnCancel_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_BtnCancel_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodBtnCancel_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfBtnCancel_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_createsiteInstance, MethodBtnCancel_Click, parametersOfBtnCancel_Click, methodBtnCancel_ClickPrametersTypes);

            // Assert
            parametersOfBtnCancel_Click.ShouldNotBeNull();
            parametersOfBtnCancel_Click.Length.ShouldBe(2);
            methodBtnCancel_ClickPrametersTypes.Length.ShouldBe(2);
            methodBtnCancel_ClickPrametersTypes.Length.ShouldBe(parametersOfBtnCancel_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BtnCancel_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_BtnCancel_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBtnCancel_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BtnCancel_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_BtnCancel_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBtnCancel_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createsiteInstance, MethodBtnCancel_Click, Fixture, methodBtnCancel_ClickPrametersTypes);

            // Assert
            methodBtnCancel_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BtnCancel_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_BtnCancel_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBtnCancel_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_createsiteInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnsureSiteCollectionFeaturesActivated) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Createsite_EnsureSiteCollectionFeaturesActivated_Static_Method_Call_Internally(Type[] types)
        {
            var methodEnsureSiteCollectionFeaturesActivatedPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_createsiteInstanceFixture, _createsiteInstanceType, MethodEnsureSiteCollectionFeaturesActivated, Fixture, methodEnsureSiteCollectionFeaturesActivatedPrametersTypes);
        }

        #endregion

        #region Method Call : (EnsureSiteCollectionFeaturesActivated) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_EnsureSiteCollectionFeaturesActivated_Static_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var solution = CreateType<SPUserSolution>();
            var site = CreateType<SPSite>();
            var methodEnsureSiteCollectionFeaturesActivatedPrametersTypes = new Type[] { typeof(SPUserSolution), typeof(SPSite) };
            object[] parametersOfEnsureSiteCollectionFeaturesActivated = { solution, site };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodEnsureSiteCollectionFeaturesActivated, methodEnsureSiteCollectionFeaturesActivatedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_createsiteInstanceFixture, parametersOfEnsureSiteCollectionFeaturesActivated);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfEnsureSiteCollectionFeaturesActivated.ShouldNotBeNull();
            parametersOfEnsureSiteCollectionFeaturesActivated.Length.ShouldBe(2);
            methodEnsureSiteCollectionFeaturesActivatedPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (EnsureSiteCollectionFeaturesActivated) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_EnsureSiteCollectionFeaturesActivated_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var solution = CreateType<SPUserSolution>();
            var site = CreateType<SPSite>();
            var methodEnsureSiteCollectionFeaturesActivatedPrametersTypes = new Type[] { typeof(SPUserSolution), typeof(SPSite) };
            object[] parametersOfEnsureSiteCollectionFeaturesActivated = { solution, site };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_createsiteInstanceFixture, _createsiteInstanceType, MethodEnsureSiteCollectionFeaturesActivated, parametersOfEnsureSiteCollectionFeaturesActivated, methodEnsureSiteCollectionFeaturesActivatedPrametersTypes);

            // Assert
            parametersOfEnsureSiteCollectionFeaturesActivated.ShouldNotBeNull();
            parametersOfEnsureSiteCollectionFeaturesActivated.Length.ShouldBe(2);
            methodEnsureSiteCollectionFeaturesActivatedPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnsureSiteCollectionFeaturesActivated) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_EnsureSiteCollectionFeaturesActivated_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodEnsureSiteCollectionFeaturesActivated, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (EnsureSiteCollectionFeaturesActivated) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_EnsureSiteCollectionFeaturesActivated_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodEnsureSiteCollectionFeaturesActivatedPrametersTypes = new Type[] { typeof(SPUserSolution), typeof(SPSite) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_createsiteInstanceFixture, _createsiteInstanceType, MethodEnsureSiteCollectionFeaturesActivated, Fixture, methodEnsureSiteCollectionFeaturesActivatedPrametersTypes);

            // Assert
            methodEnsureSiteCollectionFeaturesActivatedPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnsureSiteCollectionFeaturesActivated) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_EnsureSiteCollectionFeaturesActivated_Static_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodEnsureSiteCollectionFeaturesActivated, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_createsiteInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFeatureDefinitionsInSolution) (Return Type : List<SPFeatureDefinition>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Createsite_GetFeatureDefinitionsInSolution_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFeatureDefinitionsInSolutionPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_createsiteInstanceFixture, _createsiteInstanceType, MethodGetFeatureDefinitionsInSolution, Fixture, methodGetFeatureDefinitionsInSolutionPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFeatureDefinitionsInSolution) (Return Type : List<SPFeatureDefinition>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_GetFeatureDefinitionsInSolution_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var solution = CreateType<SPUserSolution>();
            var site = CreateType<SPSite>();
            var methodGetFeatureDefinitionsInSolutionPrametersTypes = new Type[] { typeof(SPUserSolution), typeof(SPSite) };
            object[] parametersOfGetFeatureDefinitionsInSolution = { solution, site };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFeatureDefinitionsInSolution, methodGetFeatureDefinitionsInSolutionPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_createsiteInstanceFixture, _createsiteInstanceType, MethodGetFeatureDefinitionsInSolution, Fixture, methodGetFeatureDefinitionsInSolutionPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<List<SPFeatureDefinition>>(_createsiteInstanceFixture, _createsiteInstanceType, MethodGetFeatureDefinitionsInSolution, parametersOfGetFeatureDefinitionsInSolution, methodGetFeatureDefinitionsInSolutionPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_createsiteInstanceFixture, parametersOfGetFeatureDefinitionsInSolution);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFeatureDefinitionsInSolution.ShouldNotBeNull();
            parametersOfGetFeatureDefinitionsInSolution.Length.ShouldBe(2);
            methodGetFeatureDefinitionsInSolutionPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetFeatureDefinitionsInSolution) (Return Type : List<SPFeatureDefinition>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_GetFeatureDefinitionsInSolution_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var solution = CreateType<SPUserSolution>();
            var site = CreateType<SPSite>();
            var methodGetFeatureDefinitionsInSolutionPrametersTypes = new Type[] { typeof(SPUserSolution), typeof(SPSite) };
            object[] parametersOfGetFeatureDefinitionsInSolution = { solution, site };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<List<SPFeatureDefinition>>(_createsiteInstanceFixture, _createsiteInstanceType, MethodGetFeatureDefinitionsInSolution, parametersOfGetFeatureDefinitionsInSolution, methodGetFeatureDefinitionsInSolutionPrametersTypes);

            // Assert
            parametersOfGetFeatureDefinitionsInSolution.ShouldNotBeNull();
            parametersOfGetFeatureDefinitionsInSolution.Length.ShouldBe(2);
            methodGetFeatureDefinitionsInSolutionPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFeatureDefinitionsInSolution) (Return Type : List<SPFeatureDefinition>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_GetFeatureDefinitionsInSolution_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFeatureDefinitionsInSolutionPrametersTypes = new Type[] { typeof(SPUserSolution), typeof(SPSite) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_createsiteInstanceFixture, _createsiteInstanceType, MethodGetFeatureDefinitionsInSolution, Fixture, methodGetFeatureDefinitionsInSolutionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFeatureDefinitionsInSolutionPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetFeatureDefinitionsInSolution) (Return Type : List<SPFeatureDefinition>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_GetFeatureDefinitionsInSolution_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFeatureDefinitionsInSolutionPrametersTypes = new Type[] { typeof(SPUserSolution), typeof(SPSite) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_createsiteInstanceFixture, _createsiteInstanceType, MethodGetFeatureDefinitionsInSolution, Fixture, methodGetFeatureDefinitionsInSolutionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFeatureDefinitionsInSolutionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFeatureDefinitionsInSolution) (Return Type : List<SPFeatureDefinition>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_GetFeatureDefinitionsInSolution_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFeatureDefinitionsInSolution, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_createsiteInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFeatureDefinitionsInSolution) (Return Type : List<SPFeatureDefinition>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_GetFeatureDefinitionsInSolution_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFeatureDefinitionsInSolution, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSiteGroup) (Return Type : SPGroup) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Createsite_GetSiteGroup_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetSiteGroupPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_createsiteInstanceFixture, _createsiteInstanceType, MethodGetSiteGroup, Fixture, methodGetSiteGroupPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSiteGroup) (Return Type : SPGroup) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_GetSiteGroup_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var name = CreateType<string>();
            var methodGetSiteGroupPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfGetSiteGroup = { web, name };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSiteGroup, methodGetSiteGroupPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_createsiteInstanceFixture, _createsiteInstanceType, MethodGetSiteGroup, Fixture, methodGetSiteGroupPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<SPGroup>(_createsiteInstanceFixture, _createsiteInstanceType, MethodGetSiteGroup, parametersOfGetSiteGroup, methodGetSiteGroupPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_createsiteInstanceFixture, parametersOfGetSiteGroup);

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
        public void AUT_Createsite_GetSiteGroup_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var name = CreateType<string>();
            var methodGetSiteGroupPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfGetSiteGroup = { web, name };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<SPGroup>(_createsiteInstanceFixture, _createsiteInstanceType, MethodGetSiteGroup, parametersOfGetSiteGroup, methodGetSiteGroupPrametersTypes);

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
        public void AUT_Createsite_GetSiteGroup_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetSiteGroupPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_createsiteInstanceFixture, _createsiteInstanceType, MethodGetSiteGroup, Fixture, methodGetSiteGroupPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetSiteGroupPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetSiteGroup) (Return Type : SPGroup) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_GetSiteGroup_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSiteGroupPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_createsiteInstanceFixture, _createsiteInstanceType, MethodGetSiteGroup, Fixture, methodGetSiteGroupPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSiteGroupPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSiteGroup) (Return Type : SPGroup) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_GetSiteGroup_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSiteGroup, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_createsiteInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSiteGroup) (Return Type : SPGroup) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_GetSiteGroup_Static_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (addfile) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Createsite_addfile_Static_Method_Call_Internally(Type[] types)
        {
            var methodaddfilePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_createsiteInstanceFixture, _createsiteInstanceType, Methodaddfile, Fixture, methodaddfilePrametersTypes);
        }

        #endregion

        #region Method Call : (addfile) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_addfile_Static_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var file = CreateType<string>();
            var web = CreateType<SPWeb>();
            var path = CreateType<string>();
            var counter = CreateType<int>();
            var methodaddfilePrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(string), typeof(int) };
            object[] parametersOfaddfile = { file, web, path, counter };
            Exception exception = null;
            var methodInfo = GetMethodInfo(Methodaddfile, methodaddfilePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_createsiteInstanceFixture, parametersOfaddfile);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfaddfile.ShouldNotBeNull();
            parametersOfaddfile.Length.ShouldBe(4);
            methodaddfilePrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (addfile) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_addfile_Static_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var file = CreateType<string>();
            var web = CreateType<SPWeb>();
            var path = CreateType<string>();
            var counter = CreateType<int>();
            var methodaddfilePrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(string), typeof(int) };
            object[] parametersOfaddfile = { file, web, path, counter };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_createsiteInstanceFixture, _createsiteInstanceType, Methodaddfile, parametersOfaddfile, methodaddfilePrametersTypes);

            // Assert
            parametersOfaddfile.ShouldNotBeNull();
            parametersOfaddfile.Length.ShouldBe(4);
            methodaddfilePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addfile) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_addfile_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(Methodaddfile, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addfile) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_addfile_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodaddfilePrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(string), typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_createsiteInstanceFixture, _createsiteInstanceType, Methodaddfile, Fixture, methodaddfilePrametersTypes);

            // Assert
            methodaddfilePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addfile) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_addfile_Static_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(Methodaddfile, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_createsiteInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (mapReports) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Createsite_mapReports_Method_Call_Internally(Type[] types)
        {
            var methodmapReportsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createsiteInstance, MethodmapReports, Fixture, methodmapReportsPrametersTypes);
        }

        #endregion

        #region Method Call : (mapReports) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_mapReports_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var methodmapReportsPrametersTypes = new Type[] { typeof(SPSite) };
            object[] parametersOfmapReports = { site };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodmapReports, methodmapReportsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<createsite, string>(_createsiteInstanceFixture, out exception1, parametersOfmapReports);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<createsite, string>(_createsiteInstance, MethodmapReports, parametersOfmapReports, methodmapReportsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfmapReports.ShouldNotBeNull();
            parametersOfmapReports.Length.ShouldBe(1);
            methodmapReportsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (mapReports) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_mapReports_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var methodmapReportsPrametersTypes = new Type[] { typeof(SPSite) };
            object[] parametersOfmapReports = { site };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<createsite, string>(_createsiteInstance, MethodmapReports, parametersOfmapReports, methodmapReportsPrametersTypes);

            // Assert
            parametersOfmapReports.ShouldNotBeNull();
            parametersOfmapReports.Length.ShouldBe(1);
            methodmapReportsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (mapReports) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_mapReports_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodmapReportsPrametersTypes = new Type[] { typeof(SPSite) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createsiteInstance, MethodmapReports, Fixture, methodmapReportsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodmapReportsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (mapReports) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_mapReports_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodmapReportsPrametersTypes = new Type[] { typeof(SPSite) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createsiteInstance, MethodmapReports, Fixture, methodmapReportsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodmapReportsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (mapReports) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_mapReports_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodmapReports, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_createsiteInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (mapReports) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_mapReports_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodmapReports, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (createSite) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Createsite_createSite_Method_Call_Internally(Type[] types)
        {
            var methodcreateSitePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createsiteInstance, MethodcreateSite, Fixture, methodcreateSitePrametersTypes);
        }

        #endregion

        #region Method Call : (createSite) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_createSite_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var url = CreateType<string>();
            var title = CreateType<string>();
            var description = CreateType<string>();
            var user = CreateType<string>();
            var fullName = CreateType<string>();
            var email = CreateType<string>();
            var template = CreateType<string>();
            var siteid = CreateType<Guid>();
            var methodcreateSitePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(Guid) };
            object[] parametersOfcreateSite = { url, title, description, user, fullName, email, template, siteid };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodcreateSite, methodcreateSitePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_createsiteInstanceFixture, parametersOfcreateSite);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfcreateSite.ShouldNotBeNull();
            parametersOfcreateSite.Length.ShouldBe(8);
            methodcreateSitePrametersTypes.Length.ShouldBe(8);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (createSite) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_createSite_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var url = CreateType<string>();
            var title = CreateType<string>();
            var description = CreateType<string>();
            var user = CreateType<string>();
            var fullName = CreateType<string>();
            var email = CreateType<string>();
            var template = CreateType<string>();
            var siteid = CreateType<Guid>();
            var methodcreateSitePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(Guid) };
            object[] parametersOfcreateSite = { url, title, description, user, fullName, email, template, siteid };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<createsite, string>(_createsiteInstance, MethodcreateSite, parametersOfcreateSite, methodcreateSitePrametersTypes);

            // Assert
            parametersOfcreateSite.ShouldNotBeNull();
            parametersOfcreateSite.Length.ShouldBe(8);
            methodcreateSitePrametersTypes.Length.ShouldBe(8);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (createSite) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_createSite_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodcreateSitePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(Guid) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createsiteInstance, MethodcreateSite, Fixture, methodcreateSitePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodcreateSitePrametersTypes.Length.ShouldBe(8);
        }

        #endregion

        #region Method Call : (createSite) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_createSite_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodcreateSitePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(Guid) };
            const int parametersCount = 8;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createsiteInstance, MethodcreateSite, Fixture, methodcreateSitePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodcreateSitePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (createSite) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_createSite_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodcreateSite, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_createsiteInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (createSite) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Createsite_createSite_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodcreateSite, 0);
            const int parametersCount = 8;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #endregion

        #endregion
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web.UI.WebControls;
using System.Xml;
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.BaseSetup.Version.V2;
using AUT.ConfigureTestProjects.BaseSetup.Version.V3;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.Model;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.ReportingProxy;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore.Layouts.epmlive;
using AddFragment = EPMLiveCore.Layouts.epmlive;

namespace EPMLiveCore.Layouts.epmlive
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Layouts.epmlive.AddFragment" />)
    ///     and namespace <see cref="EPMLiveCore.Layouts.epmlive"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    public partial class AddFragmentTest : AbstractBaseSetupV3Test
    {
        public AddFragmentTest() : base(typeof(AddFragment))
        {}

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Overrides of IAbstractBaseSetupV2Test

        /// <summary>
        ///    Configure and ignore problematic tests.
        ///    Added tests will be ignored.
        /// </summary>
        public override void ConfigureIgnoringTests()
        {
            base.ConfigureIgnoringTests();
        }

        #endregion

        #region General Initializer : Class (AddFragment) Initializer

        #region Methods

        private const string MethodOnPreRender = "OnPreRender";
        private const string MethodPage_Load = "Page_Load";
        private const string MethodCheckForNoFragment = "CheckForNoFragment";
        private const string MethodbtnImport_Click = "btnImport_Click";
        private const string MethodFillMyFragmentsGrid = "FillMyFragmentsGrid";
        private const string MethodFillPublicFragmentsGrid = "FillPublicFragmentsGrid";
        private const string MethodImportFragmentAndAddResourceToTeam = "ImportFragmentAndAddResourceToTeam";
        private const string MethodUpdateNodes = "UpdateNodes";
        private const string MethodAddResourceToTeam = "AddResourceToTeam";

        #endregion

        #region Fields

        private const string FieldLAYOUT_PATH = "LAYOUT_PATH";

        #endregion

        private Type _addFragmentInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private AddFragment _addFragmentInstance;
        private AddFragment _addFragmentInstanceFixture;

        #region General Initializer : Class (AddFragment) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="AddFragment" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _addFragmentInstanceType = typeof(AddFragment);
            _addFragmentInstanceFixture = this.Create<AddFragment>(true);
            _addFragmentInstance = _addFragmentInstanceFixture ?? this.Create<AddFragment>(false);
            CurrentInstance = _addFragmentInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (AddFragment)

        #region General Initializer : Class (AddFragment) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="AddFragment" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodOnPreRender, 0)]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodCheckForNoFragment, 0)]
        [TestCase(MethodFillMyFragmentsGrid, 0)]
        [TestCase(MethodFillPublicFragmentsGrid, 0)]
        [TestCase(MethodImportFragmentAndAddResourceToTeam, 0)]
        [TestCase(MethodUpdateNodes, 0)]
        [TestCase(MethodAddResourceToTeam, 0)]
        public void AUT_AddFragment_All_Methods_Explore_Verify_Test(string name, int overloadingIndex = 0)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var currentMethodInfo = this.GetMethodInfo(name, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_addFragmentInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (AddFragment) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="AddFragment" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldLAYOUT_PATH)]
        public void AUT_AddFragment_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_addFragmentInstanceFixture, 
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
        ///     Class (<see cref="AddFragment" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_AddFragment_Is_Instance_Present_Test()
        {
            // Assert
            _addFragmentInstanceType.ShouldNotBeNull();
            _addFragmentInstance.ShouldNotBeNull();
            _addFragmentInstanceFixture.ShouldNotBeNull();
            _addFragmentInstance.ShouldBeAssignableTo<AddFragment>();
            _addFragmentInstanceFixture.ShouldBeAssignableTo<AddFragment>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (AddFragment) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_AddFragment_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            AddFragment instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _addFragmentInstanceType.ShouldNotBeNull();
            _addFragmentInstance.ShouldNotBeNull();
            _addFragmentInstanceFixture.ShouldNotBeNull();
            _addFragmentInstance.ShouldBeAssignableTo<AddFragment>();
            _addFragmentInstanceFixture.ShouldBeAssignableTo<AddFragment>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : (OnPreRender) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AddFragment_OnPreRender_Method_Call_Internally(Type[] types)
        {
            var methodOnPreRenderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addFragmentInstance, MethodOnPreRender, Fixture, methodOnPreRenderPrametersTypes);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AddFragment_OnPreRender_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodOnPreRender);
            var e = this.CreateType<EventArgs>();
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnPreRender = { e };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodOnPreRender, methodOnPreRenderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_addFragmentInstanceFixture, parametersOfOnPreRender);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOnPreRender.ShouldNotBeNull();
            parametersOfOnPreRender.Length.ShouldBe(1);
            methodOnPreRenderPrametersTypes.Length.ShouldBe(1);
            methodOnPreRenderPrametersTypes.Length.ShouldBe(parametersOfOnPreRender.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AddFragment_OnPreRender_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodOnPreRender);
            var e = this.CreateType<EventArgs>();
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnPreRender = { e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_addFragmentInstance, MethodOnPreRender, parametersOfOnPreRender, methodOnPreRenderPrametersTypes);

            // Assert
            parametersOfOnPreRender.ShouldNotBeNull();
            parametersOfOnPreRender.Length.ShouldBe(1);
            methodOnPreRenderPrametersTypes.Length.ShouldBe(1);
            methodOnPreRenderPrametersTypes.Length.ShouldBe(parametersOfOnPreRender.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AddFragment_OnPreRender_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodOnPreRender);
            var methodInfo = this.GetMethodInfo(MethodOnPreRender, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AddFragment_OnPreRender_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodOnPreRender);
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addFragmentInstance, MethodOnPreRender, Fixture, methodOnPreRenderPrametersTypes);

            // Assert
            methodOnPreRenderPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AddFragment_OnPreRender_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodOnPreRender);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodOnPreRender, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_addFragmentInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AddFragment_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addFragmentInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AddFragment_Page_Load_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPage_Load);
            var sender = this.CreateType<object>();
            var e = this.CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_addFragmentInstanceFixture, parametersOfPage_Load);

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
        public void AUT_AddFragment_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPage_Load);
            var sender = this.CreateType<object>();
            var e = this.CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_addFragmentInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_AddFragment_Page_Load_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPage_Load);
            var methodInfo = this.GetMethodInfo(MethodPage_Load, 0);
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
        public void AUT_AddFragment_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPage_Load);
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addFragmentInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AddFragment_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPage_Load);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_addFragmentInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CheckForNoFragment) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AddFragment_CheckForNoFragment_Method_Call_Internally(Type[] types)
        {
            var methodCheckForNoFragmentPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addFragmentInstance, MethodCheckForNoFragment, Fixture, methodCheckForNoFragmentPrametersTypes);
        }

        #endregion

        #region Method Call : (CheckForNoFragment) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AddFragment_CheckForNoFragment_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodCheckForNoFragment);
            Type [] methodCheckForNoFragmentPrametersTypes = null;
            object[] parametersOfCheckForNoFragment = null; // no parameter present
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodCheckForNoFragment, methodCheckForNoFragmentPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_addFragmentInstanceFixture, parametersOfCheckForNoFragment);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCheckForNoFragment.ShouldBeNull();
            methodCheckForNoFragmentPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CheckForNoFragment) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AddFragment_CheckForNoFragment_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodCheckForNoFragment);
            Type [] methodCheckForNoFragmentPrametersTypes = null;
            object[] parametersOfCheckForNoFragment = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_addFragmentInstance, MethodCheckForNoFragment, parametersOfCheckForNoFragment, methodCheckForNoFragmentPrametersTypes);

            // Assert
            parametersOfCheckForNoFragment.ShouldBeNull();
            methodCheckForNoFragmentPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CheckForNoFragment) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AddFragment_CheckForNoFragment_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodCheckForNoFragment);
            Type [] methodCheckForNoFragmentPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addFragmentInstance, MethodCheckForNoFragment, Fixture, methodCheckForNoFragmentPrametersTypes);

            // Assert
            methodCheckForNoFragmentPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CheckForNoFragment) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AddFragment_CheckForNoFragment_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodCheckForNoFragment);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodCheckForNoFragment, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_addFragmentInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnImport_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AddFragment_btnImport_Click_Method_Call_Internally(Type[] types)
        {
            var methodbtnImport_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addFragmentInstance, MethodbtnImport_Click, Fixture, methodbtnImport_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (FillMyFragmentsGrid) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AddFragment_FillMyFragmentsGrid_Method_Call_Internally(Type[] types)
        {
            var methodFillMyFragmentsGridPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addFragmentInstance, MethodFillMyFragmentsGrid, Fixture, methodFillMyFragmentsGridPrametersTypes);
        }

        #endregion

        #region Method Call : (FillMyFragmentsGrid) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AddFragment_FillMyFragmentsGrid_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodFillMyFragmentsGrid);
            Type [] methodFillMyFragmentsGridPrametersTypes = null;
            object[] parametersOfFillMyFragmentsGrid = null; // no parameter present
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodFillMyFragmentsGrid, methodFillMyFragmentsGridPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_addFragmentInstanceFixture, parametersOfFillMyFragmentsGrid);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfFillMyFragmentsGrid.ShouldBeNull();
            methodFillMyFragmentsGridPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (FillMyFragmentsGrid) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AddFragment_FillMyFragmentsGrid_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodFillMyFragmentsGrid);
            Type [] methodFillMyFragmentsGridPrametersTypes = null;
            object[] parametersOfFillMyFragmentsGrid = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_addFragmentInstance, MethodFillMyFragmentsGrid, parametersOfFillMyFragmentsGrid, methodFillMyFragmentsGridPrametersTypes);

            // Assert
            parametersOfFillMyFragmentsGrid.ShouldBeNull();
            methodFillMyFragmentsGridPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FillMyFragmentsGrid) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AddFragment_FillMyFragmentsGrid_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodFillMyFragmentsGrid);
            Type [] methodFillMyFragmentsGridPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addFragmentInstance, MethodFillMyFragmentsGrid, Fixture, methodFillMyFragmentsGridPrametersTypes);

            // Assert
            methodFillMyFragmentsGridPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FillMyFragmentsGrid) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AddFragment_FillMyFragmentsGrid_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodFillMyFragmentsGrid);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodFillMyFragmentsGrid, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_addFragmentInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FillPublicFragmentsGrid) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AddFragment_FillPublicFragmentsGrid_Method_Call_Internally(Type[] types)
        {
            var methodFillPublicFragmentsGridPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addFragmentInstance, MethodFillPublicFragmentsGrid, Fixture, methodFillPublicFragmentsGridPrametersTypes);
        }

        #endregion

        #region Method Call : (FillPublicFragmentsGrid) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AddFragment_FillPublicFragmentsGrid_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodFillPublicFragmentsGrid);
            Type [] methodFillPublicFragmentsGridPrametersTypes = null;
            object[] parametersOfFillPublicFragmentsGrid = null; // no parameter present
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodFillPublicFragmentsGrid, methodFillPublicFragmentsGridPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_addFragmentInstanceFixture, parametersOfFillPublicFragmentsGrid);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfFillPublicFragmentsGrid.ShouldBeNull();
            methodFillPublicFragmentsGridPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (FillPublicFragmentsGrid) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AddFragment_FillPublicFragmentsGrid_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodFillPublicFragmentsGrid);
            Type [] methodFillPublicFragmentsGridPrametersTypes = null;
            object[] parametersOfFillPublicFragmentsGrid = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_addFragmentInstance, MethodFillPublicFragmentsGrid, parametersOfFillPublicFragmentsGrid, methodFillPublicFragmentsGridPrametersTypes);

            // Assert
            parametersOfFillPublicFragmentsGrid.ShouldBeNull();
            methodFillPublicFragmentsGridPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FillPublicFragmentsGrid) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AddFragment_FillPublicFragmentsGrid_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodFillPublicFragmentsGrid);
            Type [] methodFillPublicFragmentsGridPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addFragmentInstance, MethodFillPublicFragmentsGrid, Fixture, methodFillPublicFragmentsGridPrametersTypes);

            // Assert
            methodFillPublicFragmentsGridPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FillPublicFragmentsGrid) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AddFragment_FillPublicFragmentsGrid_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodFillPublicFragmentsGrid);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodFillPublicFragmentsGrid, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_addFragmentInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ImportFragmentAndAddResourceToTeam) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AddFragment_ImportFragmentAndAddResourceToTeam_Method_Call_Internally(Type[] types)
        {
            var methodImportFragmentAndAddResourceToTeamPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addFragmentInstance, MethodImportFragmentAndAddResourceToTeam, Fixture, methodImportFragmentAndAddResourceToTeamPrametersTypes);
        }

        #endregion

        #region Method Call : (ImportFragmentAndAddResourceToTeam) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AddFragment_ImportFragmentAndAddResourceToTeam_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodImportFragmentAndAddResourceToTeam);
            var itemId = this.CreateType<int>();
            var methodImportFragmentAndAddResourceToTeamPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfImportFragmentAndAddResourceToTeam = { itemId };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodImportFragmentAndAddResourceToTeam, methodImportFragmentAndAddResourceToTeamPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_addFragmentInstanceFixture, parametersOfImportFragmentAndAddResourceToTeam);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfImportFragmentAndAddResourceToTeam.ShouldNotBeNull();
            parametersOfImportFragmentAndAddResourceToTeam.Length.ShouldBe(1);
            methodImportFragmentAndAddResourceToTeamPrametersTypes.Length.ShouldBe(1);
            methodImportFragmentAndAddResourceToTeamPrametersTypes.Length.ShouldBe(parametersOfImportFragmentAndAddResourceToTeam.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ImportFragmentAndAddResourceToTeam) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AddFragment_ImportFragmentAndAddResourceToTeam_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodImportFragmentAndAddResourceToTeam);
            var itemId = this.CreateType<int>();
            var methodImportFragmentAndAddResourceToTeamPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfImportFragmentAndAddResourceToTeam = { itemId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_addFragmentInstance, MethodImportFragmentAndAddResourceToTeam, parametersOfImportFragmentAndAddResourceToTeam, methodImportFragmentAndAddResourceToTeamPrametersTypes);

            // Assert
            parametersOfImportFragmentAndAddResourceToTeam.ShouldNotBeNull();
            parametersOfImportFragmentAndAddResourceToTeam.Length.ShouldBe(1);
            methodImportFragmentAndAddResourceToTeamPrametersTypes.Length.ShouldBe(1);
            methodImportFragmentAndAddResourceToTeamPrametersTypes.Length.ShouldBe(parametersOfImportFragmentAndAddResourceToTeam.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ImportFragmentAndAddResourceToTeam) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AddFragment_ImportFragmentAndAddResourceToTeam_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodImportFragmentAndAddResourceToTeam);
            var methodInfo = this.GetMethodInfo(MethodImportFragmentAndAddResourceToTeam, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ImportFragmentAndAddResourceToTeam) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AddFragment_ImportFragmentAndAddResourceToTeam_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodImportFragmentAndAddResourceToTeam);
            var methodImportFragmentAndAddResourceToTeamPrametersTypes = new Type[] { typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addFragmentInstance, MethodImportFragmentAndAddResourceToTeam, Fixture, methodImportFragmentAndAddResourceToTeamPrametersTypes);

            // Assert
            methodImportFragmentAndAddResourceToTeamPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ImportFragmentAndAddResourceToTeam) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AddFragment_ImportFragmentAndAddResourceToTeam_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodImportFragmentAndAddResourceToTeam);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodImportFragmentAndAddResourceToTeam, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_addFragmentInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateNodes) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AddFragment_UpdateNodes_Method_Call_Internally(Type[] types)
        {
            var methodUpdateNodesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addFragmentInstance, MethodUpdateNodes, Fixture, methodUpdateNodesPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateNodes) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AddFragment_UpdateNodes_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodUpdateNodes);
            var xmlNode = this.CreateType<XmlNode>();
            var teamToAdd = this.CreateType<List<string>>();
            var rowId = this.CreateType<Int32>();
            var methodUpdateNodesPrametersTypes = new Type[] { typeof(XmlNode), typeof(List<string>), typeof(Int32) };
            object[] parametersOfUpdateNodes = { xmlNode, teamToAdd, rowId };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodUpdateNodes, methodUpdateNodesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_addFragmentInstanceFixture, parametersOfUpdateNodes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateNodes.ShouldNotBeNull();
            parametersOfUpdateNodes.Length.ShouldBe(3);
            methodUpdateNodesPrametersTypes.Length.ShouldBe(3);
            methodUpdateNodesPrametersTypes.Length.ShouldBe(parametersOfUpdateNodes.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateNodes) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AddFragment_UpdateNodes_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodUpdateNodes);
            var xmlNode = this.CreateType<XmlNode>();
            var teamToAdd = this.CreateType<List<string>>();
            var rowId = this.CreateType<Int32>();
            var methodUpdateNodesPrametersTypes = new Type[] { typeof(XmlNode), typeof(List<string>), typeof(Int32) };
            object[] parametersOfUpdateNodes = { xmlNode, teamToAdd, rowId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_addFragmentInstance, MethodUpdateNodes, parametersOfUpdateNodes, methodUpdateNodesPrametersTypes);

            // Assert
            parametersOfUpdateNodes.ShouldNotBeNull();
            parametersOfUpdateNodes.Length.ShouldBe(3);
            methodUpdateNodesPrametersTypes.Length.ShouldBe(3);
            methodUpdateNodesPrametersTypes.Length.ShouldBe(parametersOfUpdateNodes.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateNodes) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AddFragment_UpdateNodes_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodUpdateNodes);
            var methodInfo = this.GetMethodInfo(MethodUpdateNodes, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateNodes) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AddFragment_UpdateNodes_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodUpdateNodes);
            var methodUpdateNodesPrametersTypes = new Type[] { typeof(XmlNode), typeof(List<string>), typeof(Int32) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addFragmentInstance, MethodUpdateNodes, Fixture, methodUpdateNodesPrametersTypes);

            // Assert
            methodUpdateNodesPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateNodes) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AddFragment_UpdateNodes_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodUpdateNodes);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodUpdateNodes, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_addFragmentInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddResourceToTeam) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AddFragment_AddResourceToTeam_Method_Call_Internally(Type[] types)
        {
            var methodAddResourceToTeamPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addFragmentInstance, MethodAddResourceToTeam, Fixture, methodAddResourceToTeamPrametersTypes);
        }

        #endregion
        
        #region Method Call : (AddResourceToTeam) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AddFragment_AddResourceToTeam_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodAddResourceToTeam);
            var resources = this.CreateType<List<string>>();
            var methodAddResourceToTeamPrametersTypes = new Type[] { typeof(List<string>) };
            object[] parametersOfAddResourceToTeam = { resources };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_addFragmentInstance, MethodAddResourceToTeam, parametersOfAddResourceToTeam, methodAddResourceToTeamPrametersTypes);

            // Assert
            parametersOfAddResourceToTeam.ShouldNotBeNull();
            parametersOfAddResourceToTeam.Length.ShouldBe(1);
            methodAddResourceToTeamPrametersTypes.Length.ShouldBe(1);
            methodAddResourceToTeamPrametersTypes.Length.ShouldBe(parametersOfAddResourceToTeam.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddResourceToTeam) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AddFragment_AddResourceToTeam_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodAddResourceToTeam);
            var methodInfo = this.GetMethodInfo(MethodAddResourceToTeam, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddResourceToTeam) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AddFragment_AddResourceToTeam_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodAddResourceToTeam);
            var methodAddResourceToTeamPrametersTypes = new Type[] { typeof(List<string>) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addFragmentInstance, MethodAddResourceToTeam, Fixture, methodAddResourceToTeamPrametersTypes);

            // Assert
            methodAddResourceToTeamPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddResourceToTeam) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AddFragment_AddResourceToTeam_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodAddResourceToTeam);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodAddResourceToTeam, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_addFragmentInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
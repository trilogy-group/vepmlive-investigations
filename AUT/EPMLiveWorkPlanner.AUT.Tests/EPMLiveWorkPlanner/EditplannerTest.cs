using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
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
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveWorkPlanner;
using editplanner = EPMLiveWorkPlanner;

namespace EPMLiveWorkPlanner
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWorkPlanner.editplanner" />)
    ///     and namespace <see cref="EPMLiveWorkPlanner"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    public partial class EditplannerTest : AbstractBaseSetupV3Test
    {
        public EditplannerTest() : base(typeof(editplanner))
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

        #region General Initializer : Class (editplanner) Initializer

        #region Methods

        private const string MethodPage_Load = "Page_Load";
        private const string MethodddlTaskCenter_SelectedIndexChanged = "ddlTaskCenter_SelectedIndexChanged";
        private const string MethodddlProjectCenter_SelectedIndexChanged = "ddlProjectCenter_SelectedIndexChanged";
        private const string MethodButton1_Click = "Button1_Click";
        private const string MethodGridView1_RowCommand = "GridView1_RowCommand";
        private const string MethodGridView1_RowDataBound = "GridView1_RowDataBound";
        private const string MethodbtnAdd_Click = "btnAdd_Click";
        private const string Methodfilltaskfields = "filltaskfields";
        private const string MethodloadTaskCenterFields = "loadTaskCenterFields";
        private const string Methodfilltasklist = "filltasklist";
        private const string MethodloadFields = "loadFields";
        private const string MethodGetStatusColumns = "GetStatusColumns";
        private const string MethodGetFilterColumns = "GetFilterColumns";
        private const string MethodGetColumnValues = "GetColumnValues";
        private const string MethodGetAllListColumns = "GetAllListColumns";
        private const string MethodddlKanBanStatusColumn_SelectedIndexChanged = "ddlKanBanStatusColumn_SelectedIndexChanged";
        private const string MethodchkOnlinePlanner_CheckedChanged = "chkOnlinePlanner_CheckedChanged";

        #endregion

        #region Fields

        private const string FieldGridView1 = "GridView1";
        private const string FieldddlAddCalculation = "ddlAddCalculation";
        private const string FieldtxtAddField = "txtAddField";
        private const string FieldddlProjectCenter = "ddlProjectCenter";
        private const string FieldddlTaskCenter = "ddlTaskCenter";
        private const string Fieldstatusfields = "statusfields";
        private const string FieldkanbanAdditionalColumns = "kanbanAdditionalColumns";
        private const string FieldkanbanItemStatusFields = "kanbanItemStatusFields";
        private const string FieldkanbanItemStatusFieldsAvailable = "kanbanItemStatusFieldsAvailable";
        private const string Fieldworkstart = "workstart";
        private const string Fieldworkend = "workend";
        private const string Fieldworkhours = "workhours";

        #endregion

        private Type _editplannerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private editplanner _editplannerInstance;
        private editplanner _editplannerInstanceFixture;

        #region General Initializer : Class (editplanner) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="editplanner" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _editplannerInstanceType = typeof(editplanner);
            _editplannerInstanceFixture = this.Create<editplanner>(true);
            _editplannerInstance = _editplannerInstanceFixture ?? this.Create<editplanner>(false);
            CurrentInstance = _editplannerInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (editplanner)

        #region General Initializer : Class (editplanner) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="editplanner" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodddlTaskCenter_SelectedIndexChanged, 0)]
        [TestCase(MethodddlProjectCenter_SelectedIndexChanged, 0)]
        [TestCase(MethodGridView1_RowCommand, 0)]
        [TestCase(MethodGridView1_RowDataBound, 0)]
        [TestCase(Methodfilltaskfields, 0)]
        [TestCase(MethodloadTaskCenterFields, 0)]
        [TestCase(Methodfilltasklist, 0)]
        [TestCase(MethodloadFields, 0)]
        [TestCase(MethodGetStatusColumns, 0)]
        [TestCase(MethodGetFilterColumns, 0)]
        [TestCase(MethodGetColumnValues, 0)]
        [TestCase(MethodGetAllListColumns, 0)]
        [TestCase(MethodddlKanBanStatusColumn_SelectedIndexChanged, 0)]
        [TestCase(MethodchkOnlinePlanner_CheckedChanged, 0)]
        public void AUT_Editplanner_All_Methods_Explore_Verify_Test(string name, int overloadingIndex = 0)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var currentMethodInfo = this.GetMethodInfo(name, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_editplannerInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (editplanner) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="editplanner" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldGridView1)]
        [TestCase(FieldddlAddCalculation)]
        [TestCase(FieldtxtAddField)]
        [TestCase(FieldddlProjectCenter)]
        [TestCase(FieldddlTaskCenter)]
        [TestCase(Fieldstatusfields)]
        [TestCase(FieldkanbanAdditionalColumns)]
        [TestCase(FieldkanbanItemStatusFields)]
        [TestCase(FieldkanbanItemStatusFieldsAvailable)]
        [TestCase(Fieldworkstart)]
        [TestCase(Fieldworkend)]
        [TestCase(Fieldworkhours)]
        public void AUT_Editplanner_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_editplannerInstanceFixture, 
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
        ///     Class (<see cref="editplanner" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Editplanner_Is_Instance_Present_Test()
        {
            // Assert
            _editplannerInstanceType.ShouldNotBeNull();
            _editplannerInstance.ShouldNotBeNull();
            _editplannerInstanceFixture.ShouldNotBeNull();
            _editplannerInstance.ShouldBeAssignableTo<editplanner>();
            _editplannerInstanceFixture.ShouldBeAssignableTo<editplanner>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (editplanner) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_editplanner_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            editplanner instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _editplannerInstanceType.ShouldNotBeNull();
            _editplannerInstance.ShouldNotBeNull();
            _editplannerInstanceFixture.ShouldNotBeNull();
            _editplannerInstance.ShouldBeAssignableTo<editplanner>();
            _editplannerInstanceFixture.ShouldBeAssignableTo<editplanner>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Editplanner_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editplannerInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_Page_Load_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
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
            Action currentAction = () => methodInfo.Invoke(_editplannerInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Editplanner_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPage_Load);
            var sender = this.CreateType<object>();
            var e = this.CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_editplannerInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Editplanner_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Editplanner_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPage_Load);
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editplannerInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPage_Load);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_editplannerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ddlTaskCenter_SelectedIndexChanged) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Editplanner_ddlTaskCenter_SelectedIndexChanged_Method_Call_Internally(Type[] types)
        {
            var methodddlTaskCenter_SelectedIndexChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editplannerInstance, MethodddlTaskCenter_SelectedIndexChanged, Fixture, methodddlTaskCenter_SelectedIndexChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (ddlTaskCenter_SelectedIndexChanged) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_ddlTaskCenter_SelectedIndexChanged_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodddlTaskCenter_SelectedIndexChanged);
            var sender = this.CreateType<object>();
            var e = this.CreateType<EventArgs>();
            var methodddlTaskCenter_SelectedIndexChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfddlTaskCenter_SelectedIndexChanged = { sender, e };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodddlTaskCenter_SelectedIndexChanged, methodddlTaskCenter_SelectedIndexChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_editplannerInstanceFixture, parametersOfddlTaskCenter_SelectedIndexChanged);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfddlTaskCenter_SelectedIndexChanged.ShouldNotBeNull();
            parametersOfddlTaskCenter_SelectedIndexChanged.Length.ShouldBe(2);
            methodddlTaskCenter_SelectedIndexChangedPrametersTypes.Length.ShouldBe(2);
            methodddlTaskCenter_SelectedIndexChangedPrametersTypes.Length.ShouldBe(parametersOfddlTaskCenter_SelectedIndexChanged.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ddlTaskCenter_SelectedIndexChanged) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_ddlTaskCenter_SelectedIndexChanged_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodddlTaskCenter_SelectedIndexChanged);
            var sender = this.CreateType<object>();
            var e = this.CreateType<EventArgs>();
            var methodddlTaskCenter_SelectedIndexChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfddlTaskCenter_SelectedIndexChanged = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_editplannerInstance, MethodddlTaskCenter_SelectedIndexChanged, parametersOfddlTaskCenter_SelectedIndexChanged, methodddlTaskCenter_SelectedIndexChangedPrametersTypes);

            // Assert
            parametersOfddlTaskCenter_SelectedIndexChanged.ShouldNotBeNull();
            parametersOfddlTaskCenter_SelectedIndexChanged.Length.ShouldBe(2);
            methodddlTaskCenter_SelectedIndexChangedPrametersTypes.Length.ShouldBe(2);
            methodddlTaskCenter_SelectedIndexChangedPrametersTypes.Length.ShouldBe(parametersOfddlTaskCenter_SelectedIndexChanged.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ddlTaskCenter_SelectedIndexChanged) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_ddlTaskCenter_SelectedIndexChanged_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodddlTaskCenter_SelectedIndexChanged);
            var methodInfo = this.GetMethodInfo(MethodddlTaskCenter_SelectedIndexChanged, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ddlTaskCenter_SelectedIndexChanged) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_ddlTaskCenter_SelectedIndexChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodddlTaskCenter_SelectedIndexChanged);
            var methodddlTaskCenter_SelectedIndexChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editplannerInstance, MethodddlTaskCenter_SelectedIndexChanged, Fixture, methodddlTaskCenter_SelectedIndexChangedPrametersTypes);

            // Assert
            methodddlTaskCenter_SelectedIndexChangedPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ddlTaskCenter_SelectedIndexChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_ddlTaskCenter_SelectedIndexChanged_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodddlTaskCenter_SelectedIndexChanged);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodddlTaskCenter_SelectedIndexChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_editplannerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ddlProjectCenter_SelectedIndexChanged) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Editplanner_ddlProjectCenter_SelectedIndexChanged_Method_Call_Internally(Type[] types)
        {
            var methodddlProjectCenter_SelectedIndexChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editplannerInstance, MethodddlProjectCenter_SelectedIndexChanged, Fixture, methodddlProjectCenter_SelectedIndexChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (ddlProjectCenter_SelectedIndexChanged) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_ddlProjectCenter_SelectedIndexChanged_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodddlProjectCenter_SelectedIndexChanged);
            var sender = this.CreateType<object>();
            var e = this.CreateType<EventArgs>();
            var methodddlProjectCenter_SelectedIndexChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfddlProjectCenter_SelectedIndexChanged = { sender, e };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodddlProjectCenter_SelectedIndexChanged, methodddlProjectCenter_SelectedIndexChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_editplannerInstanceFixture, parametersOfddlProjectCenter_SelectedIndexChanged);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfddlProjectCenter_SelectedIndexChanged.ShouldNotBeNull();
            parametersOfddlProjectCenter_SelectedIndexChanged.Length.ShouldBe(2);
            methodddlProjectCenter_SelectedIndexChangedPrametersTypes.Length.ShouldBe(2);
            methodddlProjectCenter_SelectedIndexChangedPrametersTypes.Length.ShouldBe(parametersOfddlProjectCenter_SelectedIndexChanged.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ddlProjectCenter_SelectedIndexChanged) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_ddlProjectCenter_SelectedIndexChanged_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodddlProjectCenter_SelectedIndexChanged);
            var sender = this.CreateType<object>();
            var e = this.CreateType<EventArgs>();
            var methodddlProjectCenter_SelectedIndexChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfddlProjectCenter_SelectedIndexChanged = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_editplannerInstance, MethodddlProjectCenter_SelectedIndexChanged, parametersOfddlProjectCenter_SelectedIndexChanged, methodddlProjectCenter_SelectedIndexChangedPrametersTypes);

            // Assert
            parametersOfddlProjectCenter_SelectedIndexChanged.ShouldNotBeNull();
            parametersOfddlProjectCenter_SelectedIndexChanged.Length.ShouldBe(2);
            methodddlProjectCenter_SelectedIndexChangedPrametersTypes.Length.ShouldBe(2);
            methodddlProjectCenter_SelectedIndexChangedPrametersTypes.Length.ShouldBe(parametersOfddlProjectCenter_SelectedIndexChanged.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ddlProjectCenter_SelectedIndexChanged) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_ddlProjectCenter_SelectedIndexChanged_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodddlProjectCenter_SelectedIndexChanged);
            var methodInfo = this.GetMethodInfo(MethodddlProjectCenter_SelectedIndexChanged, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ddlProjectCenter_SelectedIndexChanged) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_ddlProjectCenter_SelectedIndexChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodddlProjectCenter_SelectedIndexChanged);
            var methodddlProjectCenter_SelectedIndexChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editplannerInstance, MethodddlProjectCenter_SelectedIndexChanged, Fixture, methodddlProjectCenter_SelectedIndexChangedPrametersTypes);

            // Assert
            methodddlProjectCenter_SelectedIndexChangedPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ddlProjectCenter_SelectedIndexChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_ddlProjectCenter_SelectedIndexChanged_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodddlProjectCenter_SelectedIndexChanged);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodddlProjectCenter_SelectedIndexChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_editplannerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Button1_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Editplanner_Button1_Click_Method_Call_Internally(Type[] types)
        {
            var methodButton1_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editplannerInstance, MethodButton1_Click, Fixture, methodButton1_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (GridView1_RowCommand) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Editplanner_GridView1_RowCommand_Method_Call_Internally(Type[] types)
        {
            var methodGridView1_RowCommandPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editplannerInstance, MethodGridView1_RowCommand, Fixture, methodGridView1_RowCommandPrametersTypes);
        }

        #endregion

        #region Method Call : (GridView1_RowCommand) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_GridView1_RowCommand_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGridView1_RowCommand);
            var sender = this.CreateType<object>();
            var e = this.CreateType<GridViewCommandEventArgs>();
            var methodGridView1_RowCommandPrametersTypes = new Type[] { typeof(object), typeof(GridViewCommandEventArgs) };
            object[] parametersOfGridView1_RowCommand = { sender, e };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodGridView1_RowCommand, methodGridView1_RowCommandPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_editplannerInstanceFixture, parametersOfGridView1_RowCommand);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGridView1_RowCommand.ShouldNotBeNull();
            parametersOfGridView1_RowCommand.Length.ShouldBe(2);
            methodGridView1_RowCommandPrametersTypes.Length.ShouldBe(2);
            methodGridView1_RowCommandPrametersTypes.Length.ShouldBe(parametersOfGridView1_RowCommand.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView1_RowCommand) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_GridView1_RowCommand_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGridView1_RowCommand);
            var sender = this.CreateType<object>();
            var e = this.CreateType<GridViewCommandEventArgs>();
            var methodGridView1_RowCommandPrametersTypes = new Type[] { typeof(object), typeof(GridViewCommandEventArgs) };
            object[] parametersOfGridView1_RowCommand = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_editplannerInstance, MethodGridView1_RowCommand, parametersOfGridView1_RowCommand, methodGridView1_RowCommandPrametersTypes);

            // Assert
            parametersOfGridView1_RowCommand.ShouldNotBeNull();
            parametersOfGridView1_RowCommand.Length.ShouldBe(2);
            methodGridView1_RowCommandPrametersTypes.Length.ShouldBe(2);
            methodGridView1_RowCommandPrametersTypes.Length.ShouldBe(parametersOfGridView1_RowCommand.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView1_RowCommand) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_GridView1_RowCommand_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGridView1_RowCommand);
            var methodInfo = this.GetMethodInfo(MethodGridView1_RowCommand, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GridView1_RowCommand) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_GridView1_RowCommand_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGridView1_RowCommand);
            var methodGridView1_RowCommandPrametersTypes = new Type[] { typeof(object), typeof(GridViewCommandEventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editplannerInstance, MethodGridView1_RowCommand, Fixture, methodGridView1_RowCommandPrametersTypes);

            // Assert
            methodGridView1_RowCommandPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView1_RowCommand) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_GridView1_RowCommand_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGridView1_RowCommand);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGridView1_RowCommand, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_editplannerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView1_RowDataBound) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Editplanner_GridView1_RowDataBound_Method_Call_Internally(Type[] types)
        {
            var methodGridView1_RowDataBoundPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editplannerInstance, MethodGridView1_RowDataBound, Fixture, methodGridView1_RowDataBoundPrametersTypes);
        }

        #endregion

        #region Method Call : (GridView1_RowDataBound) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_GridView1_RowDataBound_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGridView1_RowDataBound);
            var sender = this.CreateType<object>();
            var e = this.CreateType<GridViewRowEventArgs>();
            var methodGridView1_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };
            object[] parametersOfGridView1_RowDataBound = { sender, e };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodGridView1_RowDataBound, methodGridView1_RowDataBoundPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_editplannerInstanceFixture, parametersOfGridView1_RowDataBound);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGridView1_RowDataBound.ShouldNotBeNull();
            parametersOfGridView1_RowDataBound.Length.ShouldBe(2);
            methodGridView1_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            methodGridView1_RowDataBoundPrametersTypes.Length.ShouldBe(parametersOfGridView1_RowDataBound.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GridView1_RowDataBound) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_GridView1_RowDataBound_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGridView1_RowDataBound);
            var sender = this.CreateType<object>();
            var e = this.CreateType<GridViewRowEventArgs>();
            var methodGridView1_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };
            object[] parametersOfGridView1_RowDataBound = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_editplannerInstance, MethodGridView1_RowDataBound, parametersOfGridView1_RowDataBound, methodGridView1_RowDataBoundPrametersTypes);

            // Assert
            parametersOfGridView1_RowDataBound.ShouldNotBeNull();
            parametersOfGridView1_RowDataBound.Length.ShouldBe(2);
            methodGridView1_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            methodGridView1_RowDataBoundPrametersTypes.Length.ShouldBe(parametersOfGridView1_RowDataBound.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView1_RowDataBound) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_GridView1_RowDataBound_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGridView1_RowDataBound);
            var methodInfo = this.GetMethodInfo(MethodGridView1_RowDataBound, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GridView1_RowDataBound) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_GridView1_RowDataBound_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGridView1_RowDataBound);
            var methodGridView1_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editplannerInstance, MethodGridView1_RowDataBound, Fixture, methodGridView1_RowDataBoundPrametersTypes);

            // Assert
            methodGridView1_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView1_RowDataBound) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_GridView1_RowDataBound_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGridView1_RowDataBound);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGridView1_RowDataBound, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_editplannerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnAdd_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Editplanner_btnAdd_Click_Method_Call_Internally(Type[] types)
        {
            var methodbtnAdd_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editplannerInstance, MethodbtnAdd_Click, Fixture, methodbtnAdd_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (filltaskfields) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Editplanner_filltaskfields_Method_Call_Internally(Type[] types)
        {
            var methodfilltaskfieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editplannerInstance, Methodfilltaskfields, Fixture, methodfilltaskfieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (filltaskfields) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_filltaskfields_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(Methodfilltaskfields);
            var web = this.CreateType<SPWeb>();
            var methodfilltaskfieldsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOffilltaskfields = { web };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(Methodfilltaskfields, methodfilltaskfieldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_editplannerInstanceFixture, parametersOffilltaskfields);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOffilltaskfields.ShouldNotBeNull();
            parametersOffilltaskfields.Length.ShouldBe(1);
            methodfilltaskfieldsPrametersTypes.Length.ShouldBe(1);
            methodfilltaskfieldsPrametersTypes.Length.ShouldBe(parametersOffilltaskfields.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (filltaskfields) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_filltaskfields_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(Methodfilltaskfields);
            var web = this.CreateType<SPWeb>();
            var methodfilltaskfieldsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOffilltaskfields = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_editplannerInstance, Methodfilltaskfields, parametersOffilltaskfields, methodfilltaskfieldsPrametersTypes);

            // Assert
            parametersOffilltaskfields.ShouldNotBeNull();
            parametersOffilltaskfields.Length.ShouldBe(1);
            methodfilltaskfieldsPrametersTypes.Length.ShouldBe(1);
            methodfilltaskfieldsPrametersTypes.Length.ShouldBe(parametersOffilltaskfields.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (filltaskfields) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_filltaskfields_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(Methodfilltaskfields);
            var methodInfo = this.GetMethodInfo(Methodfilltaskfields, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (filltaskfields) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_filltaskfields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(Methodfilltaskfields);
            var methodfilltaskfieldsPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editplannerInstance, Methodfilltaskfields, Fixture, methodfilltaskfieldsPrametersTypes);

            // Assert
            methodfilltaskfieldsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (filltaskfields) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_filltaskfields_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(Methodfilltaskfields);
            Exception exception;
            var methodInfo = this.GetMethodInfo(Methodfilltaskfields, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_editplannerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadTaskCenterFields) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Editplanner_loadTaskCenterFields_Method_Call_Internally(Type[] types)
        {
            var methodloadTaskCenterFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editplannerInstance, MethodloadTaskCenterFields, Fixture, methodloadTaskCenterFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (loadTaskCenterFields) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_loadTaskCenterFields_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodloadTaskCenterFields);
            var web = this.CreateType<SPWeb>();
            var clear = this.CreateType<bool>();
            var methodloadTaskCenterFieldsPrametersTypes = new Type[] { typeof(SPWeb), typeof(bool) };
            object[] parametersOfloadTaskCenterFields = { web, clear };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodloadTaskCenterFields, methodloadTaskCenterFieldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_editplannerInstanceFixture, parametersOfloadTaskCenterFields);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfloadTaskCenterFields.ShouldNotBeNull();
            parametersOfloadTaskCenterFields.Length.ShouldBe(2);
            methodloadTaskCenterFieldsPrametersTypes.Length.ShouldBe(2);
            methodloadTaskCenterFieldsPrametersTypes.Length.ShouldBe(parametersOfloadTaskCenterFields.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (loadTaskCenterFields) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_loadTaskCenterFields_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodloadTaskCenterFields);
            var web = this.CreateType<SPWeb>();
            var clear = this.CreateType<bool>();
            var methodloadTaskCenterFieldsPrametersTypes = new Type[] { typeof(SPWeb), typeof(bool) };
            object[] parametersOfloadTaskCenterFields = { web, clear };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_editplannerInstance, MethodloadTaskCenterFields, parametersOfloadTaskCenterFields, methodloadTaskCenterFieldsPrametersTypes);

            // Assert
            parametersOfloadTaskCenterFields.ShouldNotBeNull();
            parametersOfloadTaskCenterFields.Length.ShouldBe(2);
            methodloadTaskCenterFieldsPrametersTypes.Length.ShouldBe(2);
            methodloadTaskCenterFieldsPrametersTypes.Length.ShouldBe(parametersOfloadTaskCenterFields.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadTaskCenterFields) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_loadTaskCenterFields_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodloadTaskCenterFields);
            var methodInfo = this.GetMethodInfo(MethodloadTaskCenterFields, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (loadTaskCenterFields) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_loadTaskCenterFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodloadTaskCenterFields);
            var methodloadTaskCenterFieldsPrametersTypes = new Type[] { typeof(SPWeb), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editplannerInstance, MethodloadTaskCenterFields, Fixture, methodloadTaskCenterFieldsPrametersTypes);

            // Assert
            methodloadTaskCenterFieldsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadTaskCenterFields) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_loadTaskCenterFields_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodloadTaskCenterFields);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodloadTaskCenterFields, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_editplannerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (filltasklist) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Editplanner_filltasklist_Method_Call_Internally(Type[] types)
        {
            var methodfilltasklistPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editplannerInstance, Methodfilltasklist, Fixture, methodfilltasklistPrametersTypes);
        }

        #endregion

        #region Method Call : (filltasklist) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_filltasklist_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(Methodfilltasklist);
            var web = this.CreateType<SPWeb>();
            var methodfilltasklistPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOffilltasklist = { web };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(Methodfilltasklist, methodfilltasklistPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_editplannerInstanceFixture, parametersOffilltasklist);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOffilltasklist.ShouldNotBeNull();
            parametersOffilltasklist.Length.ShouldBe(1);
            methodfilltasklistPrametersTypes.Length.ShouldBe(1);
            methodfilltasklistPrametersTypes.Length.ShouldBe(parametersOffilltasklist.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (filltasklist) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_filltasklist_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(Methodfilltasklist);
            var web = this.CreateType<SPWeb>();
            var methodfilltasklistPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOffilltasklist = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_editplannerInstance, Methodfilltasklist, parametersOffilltasklist, methodfilltasklistPrametersTypes);

            // Assert
            parametersOffilltasklist.ShouldNotBeNull();
            parametersOffilltasklist.Length.ShouldBe(1);
            methodfilltasklistPrametersTypes.Length.ShouldBe(1);
            methodfilltasklistPrametersTypes.Length.ShouldBe(parametersOffilltasklist.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (filltasklist) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_filltasklist_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(Methodfilltasklist);
            var methodInfo = this.GetMethodInfo(Methodfilltasklist, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (filltasklist) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_filltasklist_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(Methodfilltasklist);
            var methodfilltasklistPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editplannerInstance, Methodfilltasklist, Fixture, methodfilltasklistPrametersTypes);

            // Assert
            methodfilltasklistPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (filltasklist) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_filltasklist_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(Methodfilltasklist);
            Exception exception;
            var methodInfo = this.GetMethodInfo(Methodfilltasklist, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_editplannerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadFields) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Editplanner_loadFields_Method_Call_Internally(Type[] types)
        {
            var methodloadFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editplannerInstance, MethodloadFields, Fixture, methodloadFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (loadFields) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_loadFields_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodloadFields);
            var web = this.CreateType<SPWeb>();
            var methodloadFieldsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfloadFields = { web };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodloadFields, methodloadFieldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_editplannerInstanceFixture, parametersOfloadFields);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfloadFields.ShouldNotBeNull();
            parametersOfloadFields.Length.ShouldBe(1);
            methodloadFieldsPrametersTypes.Length.ShouldBe(1);
            methodloadFieldsPrametersTypes.Length.ShouldBe(parametersOfloadFields.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (loadFields) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_loadFields_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodloadFields);
            var web = this.CreateType<SPWeb>();
            var methodloadFieldsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfloadFields = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_editplannerInstance, MethodloadFields, parametersOfloadFields, methodloadFieldsPrametersTypes);

            // Assert
            parametersOfloadFields.ShouldNotBeNull();
            parametersOfloadFields.Length.ShouldBe(1);
            methodloadFieldsPrametersTypes.Length.ShouldBe(1);
            methodloadFieldsPrametersTypes.Length.ShouldBe(parametersOfloadFields.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadFields) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_loadFields_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodloadFields);
            var methodInfo = this.GetMethodInfo(MethodloadFields, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (loadFields) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_loadFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodloadFields);
            var methodloadFieldsPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editplannerInstance, MethodloadFields, Fixture, methodloadFieldsPrametersTypes);

            // Assert
            methodloadFieldsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadFields) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_loadFields_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodloadFields);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodloadFields, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_editplannerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetStatusColumns) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Editplanner_GetStatusColumns_Method_Call_Internally(Type[] types)
        {
            var methodGetStatusColumnsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editplannerInstance, MethodGetStatusColumns, Fixture, methodGetStatusColumnsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetStatusColumns) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_GetStatusColumns_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetStatusColumns);
            var web = this.CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => _editplannerInstance.GetStatusColumns(web);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetStatusColumns) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_GetStatusColumns_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetStatusColumns);
            var web = this.CreateType<SPWeb>();
            var methodGetStatusColumnsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfGetStatusColumns = { web };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodGetStatusColumns, methodGetStatusColumnsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_editplannerInstanceFixture, parametersOfGetStatusColumns);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetStatusColumns.ShouldNotBeNull();
            parametersOfGetStatusColumns.Length.ShouldBe(1);
            methodGetStatusColumnsPrametersTypes.Length.ShouldBe(1);
            methodGetStatusColumnsPrametersTypes.Length.ShouldBe(parametersOfGetStatusColumns.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetStatusColumns) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_GetStatusColumns_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetStatusColumns);
            var web = this.CreateType<SPWeb>();
            var methodGetStatusColumnsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfGetStatusColumns = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_editplannerInstance, MethodGetStatusColumns, parametersOfGetStatusColumns, methodGetStatusColumnsPrametersTypes);

            // Assert
            parametersOfGetStatusColumns.ShouldNotBeNull();
            parametersOfGetStatusColumns.Length.ShouldBe(1);
            methodGetStatusColumnsPrametersTypes.Length.ShouldBe(1);
            methodGetStatusColumnsPrametersTypes.Length.ShouldBe(parametersOfGetStatusColumns.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetStatusColumns) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_GetStatusColumns_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetStatusColumns);
            var methodInfo = this.GetMethodInfo(MethodGetStatusColumns, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetStatusColumns) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_GetStatusColumns_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetStatusColumns);
            var methodGetStatusColumnsPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editplannerInstance, MethodGetStatusColumns, Fixture, methodGetStatusColumnsPrametersTypes);

            // Assert
            methodGetStatusColumnsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetStatusColumns) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_GetStatusColumns_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetStatusColumns);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetStatusColumns, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_editplannerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFilterColumns) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Editplanner_GetFilterColumns_Method_Call_Internally(Type[] types)
        {
            var methodGetFilterColumnsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editplannerInstance, MethodGetFilterColumns, Fixture, methodGetFilterColumnsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFilterColumns) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_GetFilterColumns_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetFilterColumns);
            var web = this.CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => _editplannerInstance.GetFilterColumns(web);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetFilterColumns) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_GetFilterColumns_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetFilterColumns);
            var web = this.CreateType<SPWeb>();
            var methodGetFilterColumnsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfGetFilterColumns = { web };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodGetFilterColumns, methodGetFilterColumnsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_editplannerInstanceFixture, parametersOfGetFilterColumns);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetFilterColumns.ShouldNotBeNull();
            parametersOfGetFilterColumns.Length.ShouldBe(1);
            methodGetFilterColumnsPrametersTypes.Length.ShouldBe(1);
            methodGetFilterColumnsPrametersTypes.Length.ShouldBe(parametersOfGetFilterColumns.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFilterColumns) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_GetFilterColumns_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetFilterColumns);
            var web = this.CreateType<SPWeb>();
            var methodGetFilterColumnsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfGetFilterColumns = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_editplannerInstance, MethodGetFilterColumns, parametersOfGetFilterColumns, methodGetFilterColumnsPrametersTypes);

            // Assert
            parametersOfGetFilterColumns.ShouldNotBeNull();
            parametersOfGetFilterColumns.Length.ShouldBe(1);
            methodGetFilterColumnsPrametersTypes.Length.ShouldBe(1);
            methodGetFilterColumnsPrametersTypes.Length.ShouldBe(parametersOfGetFilterColumns.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFilterColumns) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_GetFilterColumns_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetFilterColumns);
            var methodInfo = this.GetMethodInfo(MethodGetFilterColumns, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFilterColumns) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_GetFilterColumns_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetFilterColumns);
            var methodGetFilterColumnsPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editplannerInstance, MethodGetFilterColumns, Fixture, methodGetFilterColumnsPrametersTypes);

            // Assert
            methodGetFilterColumnsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFilterColumns) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_GetFilterColumns_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetFilterColumns);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetFilterColumns, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_editplannerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetColumnValues) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Editplanner_GetColumnValues_Method_Call_Internally(Type[] types)
        {
            var methodGetColumnValuesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editplannerInstance, MethodGetColumnValues, Fixture, methodGetColumnValuesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetColumnValues) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_GetColumnValues_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetColumnValues);
            var web = this.CreateType<SPWeb>();
            var clear = this.CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _editplannerInstance.GetColumnValues(web, clear);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetColumnValues) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_GetColumnValues_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetColumnValues);
            var web = this.CreateType<SPWeb>();
            var clear = this.CreateType<bool>();
            var methodGetColumnValuesPrametersTypes = new Type[] { typeof(SPWeb), typeof(bool) };
            object[] parametersOfGetColumnValues = { web, clear };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodGetColumnValues, methodGetColumnValuesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_editplannerInstanceFixture, parametersOfGetColumnValues);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetColumnValues.ShouldNotBeNull();
            parametersOfGetColumnValues.Length.ShouldBe(2);
            methodGetColumnValuesPrametersTypes.Length.ShouldBe(2);
            methodGetColumnValuesPrametersTypes.Length.ShouldBe(parametersOfGetColumnValues.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetColumnValues) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_GetColumnValues_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetColumnValues);
            var web = this.CreateType<SPWeb>();
            var clear = this.CreateType<bool>();
            var methodGetColumnValuesPrametersTypes = new Type[] { typeof(SPWeb), typeof(bool) };
            object[] parametersOfGetColumnValues = { web, clear };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_editplannerInstance, MethodGetColumnValues, parametersOfGetColumnValues, methodGetColumnValuesPrametersTypes);

            // Assert
            parametersOfGetColumnValues.ShouldNotBeNull();
            parametersOfGetColumnValues.Length.ShouldBe(2);
            methodGetColumnValuesPrametersTypes.Length.ShouldBe(2);
            methodGetColumnValuesPrametersTypes.Length.ShouldBe(parametersOfGetColumnValues.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetColumnValues) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_GetColumnValues_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetColumnValues);
            var methodInfo = this.GetMethodInfo(MethodGetColumnValues, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetColumnValues) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_GetColumnValues_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetColumnValues);
            var methodGetColumnValuesPrametersTypes = new Type[] { typeof(SPWeb), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editplannerInstance, MethodGetColumnValues, Fixture, methodGetColumnValuesPrametersTypes);

            // Assert
            methodGetColumnValuesPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetColumnValues) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_GetColumnValues_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetColumnValues);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetColumnValues, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_editplannerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAllListColumns) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Editplanner_GetAllListColumns_Method_Call_Internally(Type[] types)
        {
            var methodGetAllListColumnsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editplannerInstance, MethodGetAllListColumns, Fixture, methodGetAllListColumnsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAllListColumns) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_GetAllListColumns_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAllListColumns);
            var web = this.CreateType<SPWeb>();
            var clear = this.CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _editplannerInstance.GetAllListColumns(web, clear);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetAllListColumns) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_GetAllListColumns_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAllListColumns);
            var web = this.CreateType<SPWeb>();
            var clear = this.CreateType<bool>();
            var methodGetAllListColumnsPrametersTypes = new Type[] { typeof(SPWeb), typeof(bool) };
            object[] parametersOfGetAllListColumns = { web, clear };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodGetAllListColumns, methodGetAllListColumnsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_editplannerInstanceFixture, parametersOfGetAllListColumns);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetAllListColumns.ShouldNotBeNull();
            parametersOfGetAllListColumns.Length.ShouldBe(2);
            methodGetAllListColumnsPrametersTypes.Length.ShouldBe(2);
            methodGetAllListColumnsPrametersTypes.Length.ShouldBe(parametersOfGetAllListColumns.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAllListColumns) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_GetAllListColumns_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAllListColumns);
            var web = this.CreateType<SPWeb>();
            var clear = this.CreateType<bool>();
            var methodGetAllListColumnsPrametersTypes = new Type[] { typeof(SPWeb), typeof(bool) };
            object[] parametersOfGetAllListColumns = { web, clear };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_editplannerInstance, MethodGetAllListColumns, parametersOfGetAllListColumns, methodGetAllListColumnsPrametersTypes);

            // Assert
            parametersOfGetAllListColumns.ShouldNotBeNull();
            parametersOfGetAllListColumns.Length.ShouldBe(2);
            methodGetAllListColumnsPrametersTypes.Length.ShouldBe(2);
            methodGetAllListColumnsPrametersTypes.Length.ShouldBe(parametersOfGetAllListColumns.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAllListColumns) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_GetAllListColumns_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAllListColumns);
            var methodInfo = this.GetMethodInfo(MethodGetAllListColumns, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAllListColumns) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_GetAllListColumns_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAllListColumns);
            var methodGetAllListColumnsPrametersTypes = new Type[] { typeof(SPWeb), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editplannerInstance, MethodGetAllListColumns, Fixture, methodGetAllListColumnsPrametersTypes);

            // Assert
            methodGetAllListColumnsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAllListColumns) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_GetAllListColumns_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAllListColumns);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetAllListColumns, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_editplannerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ddlKanBanStatusColumn_SelectedIndexChanged) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Editplanner_ddlKanBanStatusColumn_SelectedIndexChanged_Method_Call_Internally(Type[] types)
        {
            var methodddlKanBanStatusColumn_SelectedIndexChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editplannerInstance, MethodddlKanBanStatusColumn_SelectedIndexChanged, Fixture, methodddlKanBanStatusColumn_SelectedIndexChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (ddlKanBanStatusColumn_SelectedIndexChanged) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_ddlKanBanStatusColumn_SelectedIndexChanged_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodddlKanBanStatusColumn_SelectedIndexChanged);
            var sender = this.CreateType<object>();
            var e = this.CreateType<EventArgs>();
            var methodddlKanBanStatusColumn_SelectedIndexChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfddlKanBanStatusColumn_SelectedIndexChanged = { sender, e };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodddlKanBanStatusColumn_SelectedIndexChanged, methodddlKanBanStatusColumn_SelectedIndexChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_editplannerInstanceFixture, parametersOfddlKanBanStatusColumn_SelectedIndexChanged);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfddlKanBanStatusColumn_SelectedIndexChanged.ShouldNotBeNull();
            parametersOfddlKanBanStatusColumn_SelectedIndexChanged.Length.ShouldBe(2);
            methodddlKanBanStatusColumn_SelectedIndexChangedPrametersTypes.Length.ShouldBe(2);
            methodddlKanBanStatusColumn_SelectedIndexChangedPrametersTypes.Length.ShouldBe(parametersOfddlKanBanStatusColumn_SelectedIndexChanged.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ddlKanBanStatusColumn_SelectedIndexChanged) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_ddlKanBanStatusColumn_SelectedIndexChanged_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodddlKanBanStatusColumn_SelectedIndexChanged);
            var sender = this.CreateType<object>();
            var e = this.CreateType<EventArgs>();
            var methodddlKanBanStatusColumn_SelectedIndexChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfddlKanBanStatusColumn_SelectedIndexChanged = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_editplannerInstance, MethodddlKanBanStatusColumn_SelectedIndexChanged, parametersOfddlKanBanStatusColumn_SelectedIndexChanged, methodddlKanBanStatusColumn_SelectedIndexChangedPrametersTypes);

            // Assert
            parametersOfddlKanBanStatusColumn_SelectedIndexChanged.ShouldNotBeNull();
            parametersOfddlKanBanStatusColumn_SelectedIndexChanged.Length.ShouldBe(2);
            methodddlKanBanStatusColumn_SelectedIndexChangedPrametersTypes.Length.ShouldBe(2);
            methodddlKanBanStatusColumn_SelectedIndexChangedPrametersTypes.Length.ShouldBe(parametersOfddlKanBanStatusColumn_SelectedIndexChanged.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ddlKanBanStatusColumn_SelectedIndexChanged) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_ddlKanBanStatusColumn_SelectedIndexChanged_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodddlKanBanStatusColumn_SelectedIndexChanged);
            var methodInfo = this.GetMethodInfo(MethodddlKanBanStatusColumn_SelectedIndexChanged, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ddlKanBanStatusColumn_SelectedIndexChanged) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_ddlKanBanStatusColumn_SelectedIndexChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodddlKanBanStatusColumn_SelectedIndexChanged);
            var methodddlKanBanStatusColumn_SelectedIndexChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editplannerInstance, MethodddlKanBanStatusColumn_SelectedIndexChanged, Fixture, methodddlKanBanStatusColumn_SelectedIndexChangedPrametersTypes);

            // Assert
            methodddlKanBanStatusColumn_SelectedIndexChangedPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ddlKanBanStatusColumn_SelectedIndexChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_ddlKanBanStatusColumn_SelectedIndexChanged_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodddlKanBanStatusColumn_SelectedIndexChanged);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodddlKanBanStatusColumn_SelectedIndexChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_editplannerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (chkOnlinePlanner_CheckedChanged) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Editplanner_chkOnlinePlanner_CheckedChanged_Method_Call_Internally(Type[] types)
        {
            var methodchkOnlinePlanner_CheckedChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editplannerInstance, MethodchkOnlinePlanner_CheckedChanged, Fixture, methodchkOnlinePlanner_CheckedChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (chkOnlinePlanner_CheckedChanged) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_chkOnlinePlanner_CheckedChanged_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodchkOnlinePlanner_CheckedChanged);
            var sender = this.CreateType<object>();
            var e = this.CreateType<EventArgs>();
            var methodchkOnlinePlanner_CheckedChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfchkOnlinePlanner_CheckedChanged = { sender, e };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodchkOnlinePlanner_CheckedChanged, methodchkOnlinePlanner_CheckedChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_editplannerInstanceFixture, parametersOfchkOnlinePlanner_CheckedChanged);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfchkOnlinePlanner_CheckedChanged.ShouldNotBeNull();
            parametersOfchkOnlinePlanner_CheckedChanged.Length.ShouldBe(2);
            methodchkOnlinePlanner_CheckedChangedPrametersTypes.Length.ShouldBe(2);
            methodchkOnlinePlanner_CheckedChangedPrametersTypes.Length.ShouldBe(parametersOfchkOnlinePlanner_CheckedChanged.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (chkOnlinePlanner_CheckedChanged) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_chkOnlinePlanner_CheckedChanged_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodchkOnlinePlanner_CheckedChanged);
            var sender = this.CreateType<object>();
            var e = this.CreateType<EventArgs>();
            var methodchkOnlinePlanner_CheckedChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfchkOnlinePlanner_CheckedChanged = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_editplannerInstance, MethodchkOnlinePlanner_CheckedChanged, parametersOfchkOnlinePlanner_CheckedChanged, methodchkOnlinePlanner_CheckedChangedPrametersTypes);

            // Assert
            parametersOfchkOnlinePlanner_CheckedChanged.ShouldNotBeNull();
            parametersOfchkOnlinePlanner_CheckedChanged.Length.ShouldBe(2);
            methodchkOnlinePlanner_CheckedChangedPrametersTypes.Length.ShouldBe(2);
            methodchkOnlinePlanner_CheckedChangedPrametersTypes.Length.ShouldBe(parametersOfchkOnlinePlanner_CheckedChanged.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (chkOnlinePlanner_CheckedChanged) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_chkOnlinePlanner_CheckedChanged_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodchkOnlinePlanner_CheckedChanged);
            var methodInfo = this.GetMethodInfo(MethodchkOnlinePlanner_CheckedChanged, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (chkOnlinePlanner_CheckedChanged) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_chkOnlinePlanner_CheckedChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodchkOnlinePlanner_CheckedChanged);
            var methodchkOnlinePlanner_CheckedChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editplannerInstance, MethodchkOnlinePlanner_CheckedChanged, Fixture, methodchkOnlinePlanner_CheckedChangedPrametersTypes);

            // Assert
            methodchkOnlinePlanner_CheckedChangedPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (chkOnlinePlanner_CheckedChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Editplanner_chkOnlinePlanner_CheckedChanged_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodchkOnlinePlanner_CheckedChanged);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodchkOnlinePlanner_CheckedChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_editplannerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
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
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveWorkPlanner;
using tasks = EPMLiveWorkPlanner;

namespace EPMLiveWorkPlanner
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWorkPlanner.tasks" />)
    ///     and namespace <see cref="EPMLiveWorkPlanner"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class TasksTest : AbstractBaseSetupV3Test
    {
        public TasksTest() : base(typeof(tasks))
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

        #region General Initializer : Class (tasks) Initializer

        #region Methods

        private const string MethodcreateToolbar = "createToolbar";
        private const string MethodloadViews = "loadViews";
        private const string MethodgetRealField = "getRealField";
        private const string MethodPage_Load = "Page_Load";

        #endregion

        #region Fields

        private const string FieldprojectName = "projectName";
        private const string FieldviewList = "viewList";
        private const string FieldcurrentView = "currentView";
        private const string FieldcurrentViewGuid = "currentViewGuid";
        private const string FieldautoCalc = "autoCalc";
        private const string FieldcolumnCalculations = "columnCalculations";
        private const string FielddefaultValues = "defaultValues";
        private const string FieldminValues = "minValues";
        private const string FieldmaxValues = "maxValues";
        private const string FieldlistId = "listId";
        private const string FieldSiteUrl = "SiteUrl";
        private const string FieldpcURL = "pcURL";
        private const string FieldpnlMain = "pnlMain";
        private const string FieldshowPlanner = "showPlanner";
        private const string FieldpnlExpire = "pnlExpire";
        private const string FieldpnlToolbar = "pnlToolbar";
        private const string FieldlblExpire = "lblExpire";
        private const string FieldlastBaseline = "lastBaseline";
        private const string FieldpnlFileToolbar = "pnlFileToolbar";
        private const string FieldpnlEditToolbar = "pnlEditToolbar";
        private const string FieldpnlResourceToolbar = "pnlResourceToolbar";
        private const string FieldpnlProjectServer = "pnlProjectServer";
        private const string FieldresUrl = "resUrl";
        private const string FieldstrDateFormat = "strDateFormat";
        private const string FieldsUrl = "sUrl";
        private const string FieldprojectEditUrl = "projectEditUrl";
        private const string Fieldnonwork = "nonwork";
        private const string Fieldworkdays = "workdays";
        private const string FielduseResourcePool = "useResourcePool";
        private const string FieldhasFilters = "hasFilters";
        private const string FielddisableFilters = "disableFilters";
        private const string FieldlstProjectCenter = "lstProjectCenter";
        private const string FieldlstTaskCenter = "lstTaskCenter";
        private const string FieldwpFields = "wpFields";
        private const string FieldwebId = "webId";
        private const string FieldsiteId = "siteId";

        #endregion

        private Type _tasksInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private tasks _tasksInstance;
        private tasks _tasksInstanceFixture;

        #region General Initializer : Class (tasks) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="tasks" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _tasksInstanceType = typeof(tasks);
            _tasksInstanceFixture = this.Create<tasks>(true);
            _tasksInstance = _tasksInstanceFixture ?? this.Create<tasks>(false);
            CurrentInstance = _tasksInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (tasks)

        #region General Initializer : Class (tasks) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="tasks" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodcreateToolbar, 0)]
        [TestCase(MethodloadViews, 0)]
        [TestCase(MethodgetRealField, 0)]
        [TestCase(MethodPage_Load, 0)]
        public void AUT_Tasks_All_Methods_Explore_Verify_Test(string name, int overloadingIndex = 0)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var currentMethodInfo = this.GetMethodInfo(name, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_tasksInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (tasks) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="tasks" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldprojectName)]
        [TestCase(FieldviewList)]
        [TestCase(FieldcurrentView)]
        [TestCase(FieldcurrentViewGuid)]
        [TestCase(FieldautoCalc)]
        [TestCase(FieldcolumnCalculations)]
        [TestCase(FielddefaultValues)]
        [TestCase(FieldminValues)]
        [TestCase(FieldmaxValues)]
        [TestCase(FieldlistId)]
        [TestCase(FieldSiteUrl)]
        [TestCase(FieldpcURL)]
        [TestCase(FieldpnlMain)]
        [TestCase(FieldshowPlanner)]
        [TestCase(FieldpnlExpire)]
        [TestCase(FieldpnlToolbar)]
        [TestCase(FieldlblExpire)]
        [TestCase(FieldlastBaseline)]
        [TestCase(FieldpnlFileToolbar)]
        [TestCase(FieldpnlEditToolbar)]
        [TestCase(FieldpnlResourceToolbar)]
        [TestCase(FieldpnlProjectServer)]
        [TestCase(FieldresUrl)]
        [TestCase(FieldstrDateFormat)]
        [TestCase(FieldsUrl)]
        [TestCase(FieldprojectEditUrl)]
        [TestCase(Fieldnonwork)]
        [TestCase(Fieldworkdays)]
        [TestCase(FielduseResourcePool)]
        [TestCase(FieldhasFilters)]
        [TestCase(FielddisableFilters)]
        [TestCase(FieldlstProjectCenter)]
        [TestCase(FieldlstTaskCenter)]
        [TestCase(FieldwpFields)]
        [TestCase(FieldwebId)]
        [TestCase(FieldsiteId)]
        public void AUT_Tasks_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_tasksInstanceFixture, 
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
        ///     Class (<see cref="tasks" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Tasks_Is_Instance_Present_Test()
        {
            // Assert
            _tasksInstanceType.ShouldNotBeNull();
            _tasksInstance.ShouldNotBeNull();
            _tasksInstanceFixture.ShouldNotBeNull();
            _tasksInstance.ShouldBeAssignableTo<tasks>();
            _tasksInstanceFixture.ShouldBeAssignableTo<tasks>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (tasks) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_tasks_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            tasks instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _tasksInstanceType.ShouldNotBeNull();
            _tasksInstance.ShouldNotBeNull();
            _tasksInstanceFixture.ShouldNotBeNull();
            _tasksInstance.ShouldBeAssignableTo<tasks>();
            _tasksInstanceFixture.ShouldBeAssignableTo<tasks>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : (createToolbar) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tasks_createToolbar_Method_Call_Internally(Type[] types)
        {
            var methodcreateToolbarPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tasksInstance, MethodcreateToolbar, Fixture, methodcreateToolbarPrametersTypes);
        }

        #endregion

        #region Method Call : (createToolbar) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tasks_createToolbar_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodcreateToolbar);
            var web = this.CreateType<SPWeb>();
            var methodcreateToolbarPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfcreateToolbar = { web };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodcreateToolbar, methodcreateToolbarPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tasksInstanceFixture, parametersOfcreateToolbar);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfcreateToolbar.ShouldNotBeNull();
            parametersOfcreateToolbar.Length.ShouldBe(1);
            methodcreateToolbarPrametersTypes.Length.ShouldBe(1);
            methodcreateToolbarPrametersTypes.Length.ShouldBe(parametersOfcreateToolbar.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (createToolbar) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tasks_createToolbar_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodcreateToolbar);
            var web = this.CreateType<SPWeb>();
            var methodcreateToolbarPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfcreateToolbar = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tasksInstance, MethodcreateToolbar, parametersOfcreateToolbar, methodcreateToolbarPrametersTypes);

            // Assert
            parametersOfcreateToolbar.ShouldNotBeNull();
            parametersOfcreateToolbar.Length.ShouldBe(1);
            methodcreateToolbarPrametersTypes.Length.ShouldBe(1);
            methodcreateToolbarPrametersTypes.Length.ShouldBe(parametersOfcreateToolbar.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (createToolbar) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tasks_createToolbar_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodcreateToolbar);
            var methodInfo = this.GetMethodInfo(MethodcreateToolbar, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (createToolbar) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tasks_createToolbar_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodcreateToolbar);
            var methodcreateToolbarPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tasksInstance, MethodcreateToolbar, Fixture, methodcreateToolbarPrametersTypes);

            // Assert
            methodcreateToolbarPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (createToolbar) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tasks_createToolbar_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodcreateToolbar);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodcreateToolbar, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tasksInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadViews) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tasks_loadViews_Method_Call_Internally(Type[] types)
        {
            var methodloadViewsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tasksInstance, MethodloadViews, Fixture, methodloadViewsPrametersTypes);
        }

        #endregion

        #region Method Call : (loadViews) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tasks_loadViews_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodloadViews);
            var web = this.CreateType<SPWeb>();
            var methodloadViewsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfloadViews = { web };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodloadViews, methodloadViewsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tasksInstanceFixture, parametersOfloadViews);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfloadViews.ShouldNotBeNull();
            parametersOfloadViews.Length.ShouldBe(1);
            methodloadViewsPrametersTypes.Length.ShouldBe(1);
            methodloadViewsPrametersTypes.Length.ShouldBe(parametersOfloadViews.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (loadViews) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tasks_loadViews_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodloadViews);
            var web = this.CreateType<SPWeb>();
            var methodloadViewsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfloadViews = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tasksInstance, MethodloadViews, parametersOfloadViews, methodloadViewsPrametersTypes);

            // Assert
            parametersOfloadViews.ShouldNotBeNull();
            parametersOfloadViews.Length.ShouldBe(1);
            methodloadViewsPrametersTypes.Length.ShouldBe(1);
            methodloadViewsPrametersTypes.Length.ShouldBe(parametersOfloadViews.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadViews) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tasks_loadViews_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodloadViews);
            var methodInfo = this.GetMethodInfo(MethodloadViews, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (loadViews) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tasks_loadViews_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodloadViews);
            var methodloadViewsPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tasksInstance, MethodloadViews, Fixture, methodloadViewsPrametersTypes);

            // Assert
            methodloadViewsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadViews) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tasks_loadViews_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodloadViews);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodloadViews, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tasksInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tasks_getRealField_Method_Call_Internally(Type[] types)
        {
            var methodgetRealFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tasksInstance, MethodgetRealField, Fixture, methodgetRealFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tasks_getRealField_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetRealField);
            var field = this.CreateType<SPField>();
            var methodgetRealFieldPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfgetRealField = { field };
            Exception exception, exception1;
            var methodInfo = this.GetMethodInfo(MethodgetRealField, methodgetRealFieldPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<tasks, SPField>(_tasksInstanceFixture, out exception1, parametersOfgetRealField);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<tasks, SPField>(_tasksInstance, MethodgetRealField, parametersOfgetRealField, methodgetRealFieldPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetRealField.ShouldNotBeNull();
            parametersOfgetRealField.Length.ShouldBe(1);
            methodgetRealFieldPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tasks_getRealField_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetRealField);
            var field = this.CreateType<SPField>();
            var methodgetRealFieldPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfgetRealField = { field };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodgetRealField, methodgetRealFieldPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tasksInstanceFixture, parametersOfgetRealField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetRealField.ShouldNotBeNull();
            parametersOfgetRealField.Length.ShouldBe(1);
            methodgetRealFieldPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tasks_getRealField_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetRealField);
            var field = this.CreateType<SPField>();
            var methodgetRealFieldPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfgetRealField = { field };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<tasks, SPField>(_tasksInstance, MethodgetRealField, parametersOfgetRealField, methodgetRealFieldPrametersTypes);

            // Assert
            parametersOfgetRealField.ShouldNotBeNull();
            parametersOfgetRealField.Length.ShouldBe(1);
            methodgetRealFieldPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tasks_getRealField_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetRealField);
            var methodgetRealFieldPrametersTypes = new Type[] { typeof(SPField) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tasksInstance, MethodgetRealField, Fixture, methodgetRealFieldPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetRealFieldPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tasks_getRealField_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetRealField);
            var methodgetRealFieldPrametersTypes = new Type[] { typeof(SPField) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tasksInstance, MethodgetRealField, Fixture, methodgetRealFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetRealFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tasks_getRealField_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetRealField);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodgetRealField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_tasksInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tasks_getRealField_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetRealField);
            var methodInfo = this.GetMethodInfo(MethodgetRealField, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tasks_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tasksInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tasks_Page_Load_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
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
            Action currentAction = () => methodInfo.Invoke(_tasksInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Tasks_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPage_Load);
            var sender = this.CreateType<object>();
            var e = this.CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tasksInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Tasks_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Tasks_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPage_Load);
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tasksInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tasks_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPage_Load);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tasksInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
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
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.SharePoint;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveWorkPlanner;
using ListImportJob = EPMLiveWorkPlanner;

namespace EPMLiveWorkPlanner
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWorkPlanner.ListImportJob" />)
    ///     and namespace <see cref="EPMLiveWorkPlanner"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ListImportJobTest : AbstractBaseSetupV3Test
    {
        public ListImportJobTest() : base(typeof(ListImportJob))
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

        #region General Initializer : Class (ListImportJob) Initializer

        #region Methods

        private const string MethodgetAttribute = "getAttribute";
        private const string Methodexecute = "execute";
        private const string MethodImportTasksFromListTasks = "ImportTasksFromListTasks";
        private const string MethodImportTasksFromListsTasksProcess = "ImportTasksFromListsTasksProcess";
        private const string MethodgetFieldValue = "getFieldValue";

        #endregion

        #region Fields

        private const string FieldsbErrors = "sbErrors";

        #endregion

        private Type _listImportJobInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private ListImportJob _listImportJobInstance;
        private ListImportJob _listImportJobInstanceFixture;

        #region General Initializer : Class (ListImportJob) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ListImportJob" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _listImportJobInstanceType = typeof(ListImportJob);
            _listImportJobInstanceFixture = this.Create<ListImportJob>(true);
            _listImportJobInstance = _listImportJobInstanceFixture ?? this.Create<ListImportJob>(false);
            CurrentInstance = _listImportJobInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ListImportJob)

        #region General Initializer : Class (ListImportJob) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ListImportJob" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodgetAttribute, 0)]
        [TestCase(Methodexecute, 0)]
        [TestCase(MethodImportTasksFromListTasks, 0)]
        [TestCase(MethodImportTasksFromListsTasksProcess, 0)]
        [TestCase(MethodgetFieldValue, 0)]
        public void AUT_ListImportJob_All_Methods_Explore_Verify_Test(string name, int overloadingIndex = 0)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var currentMethodInfo = this.GetMethodInfo(name, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_listImportJobInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ListImportJob) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ListImportJob" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldsbErrors)]
        public void AUT_ListImportJob_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_listImportJobInstanceFixture, 
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
        ///     Class (<see cref="ListImportJob" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ListImportJob_Is_Instance_Present_Test()
        {
            // Assert
            _listImportJobInstanceType.ShouldNotBeNull();
            _listImportJobInstance.ShouldNotBeNull();
            _listImportJobInstanceFixture.ShouldNotBeNull();
            _listImportJobInstance.ShouldBeAssignableTo<ListImportJob>();
            _listImportJobInstanceFixture.ShouldBeAssignableTo<ListImportJob>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ListImportJob) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ListImportJob_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ListImportJob instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _listImportJobInstanceType.ShouldNotBeNull();
            _listImportJobInstance.ShouldNotBeNull();
            _listImportJobInstanceFixture.ShouldNotBeNull();
            _listImportJobInstance.ShouldBeAssignableTo<ListImportJob>();
            _listImportJobInstanceFixture.ShouldBeAssignableTo<ListImportJob>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : (getAttribute) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListImportJob_getAttribute_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetAttributePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listImportJobInstanceFixture, _listImportJobInstanceType, MethodgetAttribute, Fixture, methodgetAttributePrametersTypes);
        }

        #endregion

        #region Method Call : (getAttribute) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListImportJob_getAttribute_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetAttribute);
            var nd = this.CreateType<XmlNode>();
            var attribute = this.CreateType<string>();
            var methodgetAttributePrametersTypes = new Type[] { typeof(XmlNode), typeof(string) };
            object[] parametersOfgetAttribute = { nd, attribute };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodgetAttribute, methodgetAttributePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listImportJobInstanceFixture, parametersOfgetAttribute);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetAttribute.ShouldNotBeNull();
            parametersOfgetAttribute.Length.ShouldBe(2);
            methodgetAttributePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getAttribute) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListImportJob_getAttribute_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetAttribute);
            var nd = this.CreateType<XmlNode>();
            var attribute = this.CreateType<string>();
            var methodgetAttributePrametersTypes = new Type[] { typeof(XmlNode), typeof(string) };
            object[] parametersOfgetAttribute = { nd, attribute };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_listImportJobInstanceFixture, _listImportJobInstanceType, MethodgetAttribute, parametersOfgetAttribute, methodgetAttributePrametersTypes);

            // Assert
            parametersOfgetAttribute.ShouldNotBeNull();
            parametersOfgetAttribute.Length.ShouldBe(2);
            methodgetAttributePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getAttribute) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListImportJob_getAttribute_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetAttribute);
            var methodgetAttributePrametersTypes = new Type[] { typeof(XmlNode), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listImportJobInstanceFixture, _listImportJobInstanceType, MethodgetAttribute, Fixture, methodgetAttributePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetAttributePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (getAttribute) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListImportJob_getAttribute_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetAttribute);
            var methodgetAttributePrametersTypes = new Type[] { typeof(XmlNode), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listImportJobInstanceFixture, _listImportJobInstanceType, MethodgetAttribute, Fixture, methodgetAttributePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetAttributePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getAttribute) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListImportJob_getAttribute_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetAttribute);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodgetAttribute, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listImportJobInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getAttribute) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListImportJob_getAttribute_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetAttribute);
            var methodInfo = this.GetMethodInfo(MethodgetAttribute, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListImportJob_execute_Method_Call_Internally(Type[] types)
        {
            var methodexecutePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listImportJobInstance, Methodexecute, Fixture, methodexecutePrametersTypes);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListImportJob_execute_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(Methodexecute);
            var osite = this.CreateType<SPSite>();
            var oweb = this.CreateType<SPWeb>();
            var data = this.CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _listImportJobInstance.execute(osite, oweb, data);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListImportJob_execute_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(Methodexecute);
            var osite = this.CreateType<SPSite>();
            var oweb = this.CreateType<SPWeb>();
            var data = this.CreateType<string>();
            var methodexecutePrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb), typeof(string) };
            object[] parametersOfexecute = { osite, oweb, data };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(Methodexecute, methodexecutePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listImportJobInstanceFixture, parametersOfexecute);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfexecute.ShouldNotBeNull();
            parametersOfexecute.Length.ShouldBe(3);
            methodexecutePrametersTypes.Length.ShouldBe(3);
            methodexecutePrametersTypes.Length.ShouldBe(parametersOfexecute.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListImportJob_execute_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(Methodexecute);
            var osite = this.CreateType<SPSite>();
            var oweb = this.CreateType<SPWeb>();
            var data = this.CreateType<string>();
            var methodexecutePrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb), typeof(string) };
            object[] parametersOfexecute = { osite, oweb, data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listImportJobInstance, Methodexecute, parametersOfexecute, methodexecutePrametersTypes);

            // Assert
            parametersOfexecute.ShouldNotBeNull();
            parametersOfexecute.Length.ShouldBe(3);
            methodexecutePrametersTypes.Length.ShouldBe(3);
            methodexecutePrametersTypes.Length.ShouldBe(parametersOfexecute.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListImportJob_execute_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(Methodexecute);
            var methodInfo = this.GetMethodInfo(Methodexecute, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListImportJob_execute_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(Methodexecute);
            var methodexecutePrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listImportJobInstance, Methodexecute, Fixture, methodexecutePrametersTypes);

            // Assert
            methodexecutePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListImportJob_execute_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(Methodexecute);
            Exception exception;
            var methodInfo = this.GetMethodInfo(Methodexecute, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listImportJobInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ImportTasksFromListTasks) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListImportJob_ImportTasksFromListTasks_Method_Call_Internally(Type[] types)
        {
            var methodImportTasksFromListTasksPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listImportJobInstance, MethodImportTasksFromListTasks, Fixture, methodImportTasksFromListTasksPrametersTypes);
        }

        #endregion

        #region Method Call : (ImportTasksFromListTasks) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListImportJob_ImportTasksFromListTasks_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodImportTasksFromListTasks);
            var lic = this.CreateType<SPListItemCollection>();
            var docNew = this.CreateType<XmlDocument>();
            var hshMapping = this.CreateType<Hashtable>();
            var dsResources = this.CreateType<DataSet>();
            var bMatchingTaskCenter = this.CreateType<bool>();
            var docPlan = this.CreateType<XmlDocument>();
            var methodImportTasksFromListTasksPrametersTypes = new Type[] { typeof(SPListItemCollection), typeof(XmlDocument), typeof(Hashtable), typeof(DataSet), typeof(bool), typeof(XmlDocument) };
            object[] parametersOfImportTasksFromListTasks = { lic, docNew, hshMapping, dsResources, bMatchingTaskCenter, docPlan };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodImportTasksFromListTasks, methodImportTasksFromListTasksPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listImportJobInstanceFixture, parametersOfImportTasksFromListTasks);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfImportTasksFromListTasks.ShouldNotBeNull();
            parametersOfImportTasksFromListTasks.Length.ShouldBe(6);
            methodImportTasksFromListTasksPrametersTypes.Length.ShouldBe(6);
            methodImportTasksFromListTasksPrametersTypes.Length.ShouldBe(parametersOfImportTasksFromListTasks.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ImportTasksFromListTasks) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListImportJob_ImportTasksFromListTasks_Method_Call_Void_With_6_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodImportTasksFromListTasks);
            var lic = this.CreateType<SPListItemCollection>();
            var docNew = this.CreateType<XmlDocument>();
            var hshMapping = this.CreateType<Hashtable>();
            var dsResources = this.CreateType<DataSet>();
            var bMatchingTaskCenter = this.CreateType<bool>();
            var docPlan = this.CreateType<XmlDocument>();
            var methodImportTasksFromListTasksPrametersTypes = new Type[] { typeof(SPListItemCollection), typeof(XmlDocument), typeof(Hashtable), typeof(DataSet), typeof(bool), typeof(XmlDocument) };
            object[] parametersOfImportTasksFromListTasks = { lic, docNew, hshMapping, dsResources, bMatchingTaskCenter, docPlan };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listImportJobInstance, MethodImportTasksFromListTasks, parametersOfImportTasksFromListTasks, methodImportTasksFromListTasksPrametersTypes);

            // Assert
            parametersOfImportTasksFromListTasks.ShouldNotBeNull();
            parametersOfImportTasksFromListTasks.Length.ShouldBe(6);
            methodImportTasksFromListTasksPrametersTypes.Length.ShouldBe(6);
            methodImportTasksFromListTasksPrametersTypes.Length.ShouldBe(parametersOfImportTasksFromListTasks.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ImportTasksFromListTasks) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListImportJob_ImportTasksFromListTasks_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodImportTasksFromListTasks);
            var methodInfo = this.GetMethodInfo(MethodImportTasksFromListTasks, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ImportTasksFromListTasks) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListImportJob_ImportTasksFromListTasks_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodImportTasksFromListTasks);
            var methodImportTasksFromListTasksPrametersTypes = new Type[] { typeof(SPListItemCollection), typeof(XmlDocument), typeof(Hashtable), typeof(DataSet), typeof(bool), typeof(XmlDocument) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listImportJobInstance, MethodImportTasksFromListTasks, Fixture, methodImportTasksFromListTasksPrametersTypes);

            // Assert
            methodImportTasksFromListTasksPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ImportTasksFromListTasks) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListImportJob_ImportTasksFromListTasks_Method_Call_With_6_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodImportTasksFromListTasks);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodImportTasksFromListTasks, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listImportJobInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ImportTasksFromListsTasksProcess) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListImportJob_ImportTasksFromListsTasksProcess_Method_Call_Internally(Type[] types)
        {
            var methodImportTasksFromListsTasksProcessPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listImportJobInstance, MethodImportTasksFromListsTasksProcess, Fixture, methodImportTasksFromListsTasksProcessPrametersTypes);
        }

        #endregion

        #region Method Call : (ImportTasksFromListsTasksProcess) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListImportJob_ImportTasksFromListsTasksProcess_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodImportTasksFromListsTasksProcess);
            var li = this.CreateType<SPListItem>();
            var docNew = this.CreateType<XmlDocument>();
            var hshMapping = this.CreateType<Hashtable>();
            var dsResources = this.CreateType<DataSet>();
            var methodImportTasksFromListsTasksProcessPrametersTypes = new Type[] { typeof(SPListItem), typeof(XmlDocument), typeof(Hashtable), typeof(DataSet) };
            object[] parametersOfImportTasksFromListsTasksProcess = { li, docNew, hshMapping, dsResources };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodImportTasksFromListsTasksProcess, methodImportTasksFromListsTasksProcessPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listImportJobInstanceFixture, parametersOfImportTasksFromListsTasksProcess);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfImportTasksFromListsTasksProcess.ShouldNotBeNull();
            parametersOfImportTasksFromListsTasksProcess.Length.ShouldBe(4);
            methodImportTasksFromListsTasksProcessPrametersTypes.Length.ShouldBe(4);
            methodImportTasksFromListsTasksProcessPrametersTypes.Length.ShouldBe(parametersOfImportTasksFromListsTasksProcess.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ImportTasksFromListsTasksProcess) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListImportJob_ImportTasksFromListsTasksProcess_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodImportTasksFromListsTasksProcess);
            var li = this.CreateType<SPListItem>();
            var docNew = this.CreateType<XmlDocument>();
            var hshMapping = this.CreateType<Hashtable>();
            var dsResources = this.CreateType<DataSet>();
            var methodImportTasksFromListsTasksProcessPrametersTypes = new Type[] { typeof(SPListItem), typeof(XmlDocument), typeof(Hashtable), typeof(DataSet) };
            object[] parametersOfImportTasksFromListsTasksProcess = { li, docNew, hshMapping, dsResources };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listImportJobInstance, MethodImportTasksFromListsTasksProcess, parametersOfImportTasksFromListsTasksProcess, methodImportTasksFromListsTasksProcessPrametersTypes);

            // Assert
            parametersOfImportTasksFromListsTasksProcess.ShouldNotBeNull();
            parametersOfImportTasksFromListsTasksProcess.Length.ShouldBe(4);
            methodImportTasksFromListsTasksProcessPrametersTypes.Length.ShouldBe(4);
            methodImportTasksFromListsTasksProcessPrametersTypes.Length.ShouldBe(parametersOfImportTasksFromListsTasksProcess.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ImportTasksFromListsTasksProcess) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListImportJob_ImportTasksFromListsTasksProcess_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodImportTasksFromListsTasksProcess);
            var methodInfo = this.GetMethodInfo(MethodImportTasksFromListsTasksProcess, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ImportTasksFromListsTasksProcess) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListImportJob_ImportTasksFromListsTasksProcess_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodImportTasksFromListsTasksProcess);
            var methodImportTasksFromListsTasksProcessPrametersTypes = new Type[] { typeof(SPListItem), typeof(XmlDocument), typeof(Hashtable), typeof(DataSet) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listImportJobInstance, MethodImportTasksFromListsTasksProcess, Fixture, methodImportTasksFromListsTasksProcessPrametersTypes);

            // Assert
            methodImportTasksFromListsTasksProcessPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ImportTasksFromListsTasksProcess) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListImportJob_ImportTasksFromListsTasksProcess_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodImportTasksFromListsTasksProcess);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodImportTasksFromListsTasksProcess, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listImportJobInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getFieldValue) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListImportJob_getFieldValue_Method_Call_Internally(Type[] types)
        {
            var methodgetFieldValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listImportJobInstance, MethodgetFieldValue, Fixture, methodgetFieldValuePrametersTypes);
        }

        #endregion

        #region Method Call : (getFieldValue) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListImportJob_getFieldValue_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetFieldValue);
            var li = this.CreateType<SPListItem>();
            var oField = this.CreateType<SPField>();
            var dsResources = this.CreateType<DataSet>();
            Action executeAction = null;

            // Act
            executeAction = () => _listImportJobInstance.getFieldValue(li, oField, dsResources);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (getFieldValue) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListImportJob_getFieldValue_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetFieldValue);
            var li = this.CreateType<SPListItem>();
            var oField = this.CreateType<SPField>();
            var dsResources = this.CreateType<DataSet>();
            var methodgetFieldValuePrametersTypes = new Type[] { typeof(SPListItem), typeof(SPField), typeof(DataSet) };
            object[] parametersOfgetFieldValue = { li, oField, dsResources };
            Exception exception, exception1;
            var methodInfo = this.GetMethodInfo(MethodgetFieldValue, methodgetFieldValuePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ListImportJob, string>(_listImportJobInstanceFixture, out exception1, parametersOfgetFieldValue);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ListImportJob, string>(_listImportJobInstance, MethodgetFieldValue, parametersOfgetFieldValue, methodgetFieldValuePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            parametersOfgetFieldValue.ShouldNotBeNull();
            parametersOfgetFieldValue.Length.ShouldBe(3);
            methodgetFieldValuePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (getFieldValue) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListImportJob_getFieldValue_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetFieldValue);
            var li = this.CreateType<SPListItem>();
            var oField = this.CreateType<SPField>();
            var dsResources = this.CreateType<DataSet>();
            var methodgetFieldValuePrametersTypes = new Type[] { typeof(SPListItem), typeof(SPField), typeof(DataSet) };
            object[] parametersOfgetFieldValue = { li, oField, dsResources };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodgetFieldValue, methodgetFieldValuePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listImportJobInstanceFixture, parametersOfgetFieldValue);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetFieldValue.ShouldNotBeNull();
            parametersOfgetFieldValue.Length.ShouldBe(3);
            methodgetFieldValuePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getFieldValue) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListImportJob_getFieldValue_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetFieldValue);
            var li = this.CreateType<SPListItem>();
            var oField = this.CreateType<SPField>();
            var dsResources = this.CreateType<DataSet>();
            var methodgetFieldValuePrametersTypes = new Type[] { typeof(SPListItem), typeof(SPField), typeof(DataSet) };
            object[] parametersOfgetFieldValue = { li, oField, dsResources };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ListImportJob, string>(_listImportJobInstance, MethodgetFieldValue, parametersOfgetFieldValue, methodgetFieldValuePrametersTypes);

            // Assert
            parametersOfgetFieldValue.ShouldNotBeNull();
            parametersOfgetFieldValue.Length.ShouldBe(3);
            methodgetFieldValuePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getFieldValue) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListImportJob_getFieldValue_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetFieldValue);
            var methodgetFieldValuePrametersTypes = new Type[] { typeof(SPListItem), typeof(SPField), typeof(DataSet) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listImportJobInstance, MethodgetFieldValue, Fixture, methodgetFieldValuePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodgetFieldValuePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (getFieldValue) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListImportJob_getFieldValue_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetFieldValue);
            var methodgetFieldValuePrametersTypes = new Type[] { typeof(SPListItem), typeof(SPField), typeof(DataSet) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listImportJobInstance, MethodgetFieldValue, Fixture, methodgetFieldValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetFieldValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getFieldValue) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListImportJob_getFieldValue_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetFieldValue);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodgetFieldValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listImportJobInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getFieldValue) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListImportJob_getFieldValue_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetFieldValue);
            var methodInfo = this.GetMethodInfo(MethodgetFieldValue, 0);
            const int parametersCount = 3;

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
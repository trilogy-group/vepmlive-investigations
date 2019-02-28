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
using EPMLiveCore;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveWorkPlanner;
using PublishJob = EPMLiveWorkPlanner;

namespace EPMLiveWorkPlanner
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWorkPlanner.PublishJob" />)
    ///     and namespace <see cref="EPMLiveWorkPlanner"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class PublishJobTest : AbstractBaseSetupV3Test
    {
        public PublishJobTest() : base(typeof(PublishJob))
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

        #region General Initializer : Class (PublishJob) Initializer

        #region Methods

        private const string Methodexecute = "execute";
        private const string MethodFormatPFEWorkJobXml = "FormatPFEWorkJobXml";
        private const string MethodStartPublish = "StartPublish";
        private const string MethodgetPrefix = "getPrefix";
        private const string MethodsetupProjectCenter = "setupProjectCenter";
        private const string MethodsetupTaskCenter = "setupTaskCenter";
        private const string MethodensureFolder = "ensureFolder";
        private const string MethodMoveListItemToFolder = "MoveListItemToFolder";
        private const string MethodpublishTasks = "publishTasks";
        private const string MethodprocessTask = "processTask";

        #endregion

        #region Fields

        private const string FieldhshTaskCenterFields = "hshTaskCenterFields";
        private const string FieldtaskCenterProjectField = "taskCenterProjectField";
        private const string FieldhshLinks = "hshLinks";

        #endregion

        private Type _publishJobInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private PublishJob _publishJobInstance;
        private PublishJob _publishJobInstanceFixture;

        #region General Initializer : Class (PublishJob) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PublishJob" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _publishJobInstanceType = typeof(PublishJob);
            _publishJobInstanceFixture = this.Create<PublishJob>(true);
            _publishJobInstance = _publishJobInstanceFixture ?? this.Create<PublishJob>(false);
            CurrentInstance = _publishJobInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PublishJob)

        #region General Initializer : Class (PublishJob) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="PublishJob" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Methodexecute, 0)]
        [TestCase(MethodFormatPFEWorkJobXml, 0)]
        [TestCase(MethodStartPublish, 0)]
        [TestCase(MethodgetPrefix, 0)]
        [TestCase(MethodsetupProjectCenter, 0)]
        [TestCase(MethodsetupTaskCenter, 0)]
        [TestCase(MethodensureFolder, 0)]
        [TestCase(MethodMoveListItemToFolder, 0)]
        [TestCase(MethodpublishTasks, 0)]
        [TestCase(MethodprocessTask, 0)]
        public void AUT_PublishJob_All_Methods_Explore_Verify_Test(string name, int overloadingIndex = 0)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var currentMethodInfo = this.GetMethodInfo(name, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_publishJobInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (PublishJob) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="PublishJob" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldhshTaskCenterFields)]
        [TestCase(FieldtaskCenterProjectField)]
        [TestCase(FieldhshLinks)]
        public void AUT_PublishJob_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_publishJobInstanceFixture, 
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
        ///     Class (<see cref="PublishJob" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_PublishJob_Is_Instance_Present_Test()
        {
            // Assert
            _publishJobInstanceType.ShouldNotBeNull();
            _publishJobInstance.ShouldNotBeNull();
            _publishJobInstanceFixture.ShouldNotBeNull();
            _publishJobInstance.ShouldBeAssignableTo<PublishJob>();
            _publishJobInstanceFixture.ShouldBeAssignableTo<PublishJob>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (PublishJob) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_PublishJob_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            PublishJob instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _publishJobInstanceType.ShouldNotBeNull();
            _publishJobInstance.ShouldNotBeNull();
            _publishJobInstanceFixture.ShouldNotBeNull();
            _publishJobInstance.ShouldBeAssignableTo<PublishJob>();
            _publishJobInstanceFixture.ShouldBeAssignableTo<PublishJob>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : (execute) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PublishJob_execute_Method_Call_Internally(Type[] types)
        {
            var methodexecutePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_publishJobInstance, Methodexecute, Fixture, methodexecutePrametersTypes);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_execute_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(Methodexecute);
            var osite = this.CreateType<SPSite>();
            var oweb = this.CreateType<SPWeb>();
            var data = this.CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _publishJobInstance.execute(osite, oweb, data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_execute_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
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
            Action currentAction = () => methodInfo.Invoke(_publishJobInstanceFixture, parametersOfexecute);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfexecute.ShouldNotBeNull();
            parametersOfexecute.Length.ShouldBe(3);
            methodexecutePrametersTypes.Length.ShouldBe(3);
            methodexecutePrametersTypes.Length.ShouldBe(parametersOfexecute.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_execute_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(Methodexecute);
            var osite = this.CreateType<SPSite>();
            var oweb = this.CreateType<SPWeb>();
            var data = this.CreateType<string>();
            var methodexecutePrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb), typeof(string) };
            object[] parametersOfexecute = { osite, oweb, data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_publishJobInstance, Methodexecute, parametersOfexecute, methodexecutePrametersTypes);

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
        public void AUT_PublishJob_execute_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_PublishJob_execute_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(Methodexecute);
            var methodexecutePrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_publishJobInstance, Methodexecute, Fixture, methodexecutePrametersTypes);

            // Assert
            methodexecutePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_execute_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(Methodexecute);
            Exception exception;
            var methodInfo = this.GetMethodInfo(Methodexecute, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_publishJobInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FormatPFEWorkJobXml) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PublishJob_FormatPFEWorkJobXml_Method_Call_Internally(Type[] types)
        {
            var methodFormatPFEWorkJobXmlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_publishJobInstance, MethodFormatPFEWorkJobXml, Fixture, methodFormatPFEWorkJobXmlPrametersTypes);
        }

        #endregion

        #region Method Call : (FormatPFEWorkJobXml) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_FormatPFEWorkJobXml_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodFormatPFEWorkJobXml);
            var doc = this.CreateType<XmlDocument>();
            var methodFormatPFEWorkJobXmlPrametersTypes = new Type[] { typeof(XmlDocument) };
            object[] parametersOfFormatPFEWorkJobXml = { doc };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodFormatPFEWorkJobXml, methodFormatPFEWorkJobXmlPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_publishJobInstanceFixture, parametersOfFormatPFEWorkJobXml);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfFormatPFEWorkJobXml.ShouldNotBeNull();
            parametersOfFormatPFEWorkJobXml.Length.ShouldBe(1);
            methodFormatPFEWorkJobXmlPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FormatPFEWorkJobXml) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_FormatPFEWorkJobXml_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodFormatPFEWorkJobXml);
            var doc = this.CreateType<XmlDocument>();
            var methodFormatPFEWorkJobXmlPrametersTypes = new Type[] { typeof(XmlDocument) };
            object[] parametersOfFormatPFEWorkJobXml = { doc };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<PublishJob, string>(_publishJobInstance, MethodFormatPFEWorkJobXml, parametersOfFormatPFEWorkJobXml, methodFormatPFEWorkJobXmlPrametersTypes);

            // Assert
            parametersOfFormatPFEWorkJobXml.ShouldNotBeNull();
            parametersOfFormatPFEWorkJobXml.Length.ShouldBe(1);
            methodFormatPFEWorkJobXmlPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FormatPFEWorkJobXml) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_FormatPFEWorkJobXml_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodFormatPFEWorkJobXml);
            var methodFormatPFEWorkJobXmlPrametersTypes = new Type[] { typeof(XmlDocument) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_publishJobInstance, MethodFormatPFEWorkJobXml, Fixture, methodFormatPFEWorkJobXmlPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodFormatPFEWorkJobXmlPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (FormatPFEWorkJobXml) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_FormatPFEWorkJobXml_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodFormatPFEWorkJobXml);
            var methodFormatPFEWorkJobXmlPrametersTypes = new Type[] { typeof(XmlDocument) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_publishJobInstance, MethodFormatPFEWorkJobXml, Fixture, methodFormatPFEWorkJobXmlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodFormatPFEWorkJobXmlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FormatPFEWorkJobXml) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_FormatPFEWorkJobXml_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodFormatPFEWorkJobXml);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodFormatPFEWorkJobXml, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_publishJobInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (FormatPFEWorkJobXml) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_FormatPFEWorkJobXml_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodFormatPFEWorkJobXml);
            var methodInfo = this.GetMethodInfo(MethodFormatPFEWorkJobXml, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (StartPublish) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PublishJob_StartPublish_Method_Call_Internally(Type[] types)
        {
            var methodStartPublishPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_publishJobInstance, MethodStartPublish, Fixture, methodStartPublishPrametersTypes);
        }

        #endregion

        #region Method Call : (StartPublish) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_StartPublish_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodStartPublish);
            var doc = this.CreateType<XmlDocument>();
            var site = this.CreateType<SPSite>();
            var web = this.CreateType<SPWeb>();
            var oProjectCenter = this.CreateType<SPList>();
            var oTaskCenter = this.CreateType<SPList>();
            var projectid = this.CreateType<string>();
            var props = this.CreateType<EPMLiveWorkPlanner.WorkPlannerAPI.PlannerProps>();
            var plannerid = this.CreateType<string>();
            var methodStartPublishPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPSite), typeof(SPWeb), typeof(SPList), typeof(SPList), typeof(string), typeof(EPMLiveWorkPlanner.WorkPlannerAPI.PlannerProps), typeof(string) };
            object[] parametersOfStartPublish = { doc, site, web, oProjectCenter, oTaskCenter, projectid, props, plannerid };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodStartPublish, methodStartPublishPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_publishJobInstanceFixture, parametersOfStartPublish);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfStartPublish.ShouldNotBeNull();
            parametersOfStartPublish.Length.ShouldBe(8);
            methodStartPublishPrametersTypes.Length.ShouldBe(8);
            methodStartPublishPrametersTypes.Length.ShouldBe(parametersOfStartPublish.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (StartPublish) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_StartPublish_Method_Call_Void_With_8_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodStartPublish);
            var doc = this.CreateType<XmlDocument>();
            var site = this.CreateType<SPSite>();
            var web = this.CreateType<SPWeb>();
            var oProjectCenter = this.CreateType<SPList>();
            var oTaskCenter = this.CreateType<SPList>();
            var projectid = this.CreateType<string>();
            var props = this.CreateType<EPMLiveWorkPlanner.WorkPlannerAPI.PlannerProps>();
            var plannerid = this.CreateType<string>();
            var methodStartPublishPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPSite), typeof(SPWeb), typeof(SPList), typeof(SPList), typeof(string), typeof(EPMLiveWorkPlanner.WorkPlannerAPI.PlannerProps), typeof(string) };
            object[] parametersOfStartPublish = { doc, site, web, oProjectCenter, oTaskCenter, projectid, props, plannerid };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_publishJobInstance, MethodStartPublish, parametersOfStartPublish, methodStartPublishPrametersTypes);

            // Assert
            parametersOfStartPublish.ShouldNotBeNull();
            parametersOfStartPublish.Length.ShouldBe(8);
            methodStartPublishPrametersTypes.Length.ShouldBe(8);
            methodStartPublishPrametersTypes.Length.ShouldBe(parametersOfStartPublish.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StartPublish) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_StartPublish_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodStartPublish);
            var methodInfo = this.GetMethodInfo(MethodStartPublish, 0);
            const int parametersCount = 8;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (StartPublish) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_StartPublish_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodStartPublish);
            var methodStartPublishPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPSite), typeof(SPWeb), typeof(SPList), typeof(SPList), typeof(string), typeof(EPMLiveWorkPlanner.WorkPlannerAPI.PlannerProps), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_publishJobInstance, MethodStartPublish, Fixture, methodStartPublishPrametersTypes);

            // Assert
            methodStartPublishPrametersTypes.Length.ShouldBe(8);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StartPublish) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_StartPublish_Method_Call_With_8_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodStartPublish);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodStartPublish, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_publishJobInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getPrefix) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PublishJob_getPrefix_Method_Call_Internally(Type[] types)
        {
            var methodgetPrefixPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_publishJobInstance, MethodgetPrefix, Fixture, methodgetPrefixPrametersTypes);
        }

        #endregion

        #region Method Call : (getPrefix) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_getPrefix_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetPrefix);
            var site = this.CreateType<SPSite>();
            var methodgetPrefixPrametersTypes = new Type[] { typeof(SPSite) };
            object[] parametersOfgetPrefix = { site };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodgetPrefix, methodgetPrefixPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_publishJobInstanceFixture, parametersOfgetPrefix);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetPrefix.ShouldNotBeNull();
            parametersOfgetPrefix.Length.ShouldBe(1);
            methodgetPrefixPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getPrefix) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_getPrefix_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetPrefix);
            var site = this.CreateType<SPSite>();
            var methodgetPrefixPrametersTypes = new Type[] { typeof(SPSite) };
            object[] parametersOfgetPrefix = { site };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<PublishJob, string>(_publishJobInstance, MethodgetPrefix, parametersOfgetPrefix, methodgetPrefixPrametersTypes);

            // Assert
            parametersOfgetPrefix.ShouldNotBeNull();
            parametersOfgetPrefix.Length.ShouldBe(1);
            methodgetPrefixPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getPrefix) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_getPrefix_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetPrefix);
            var methodgetPrefixPrametersTypes = new Type[] { typeof(SPSite) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_publishJobInstance, MethodgetPrefix, Fixture, methodgetPrefixPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetPrefixPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getPrefix) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_getPrefix_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetPrefix);
            var methodgetPrefixPrametersTypes = new Type[] { typeof(SPSite) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_publishJobInstance, MethodgetPrefix, Fixture, methodgetPrefixPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetPrefixPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getPrefix) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_getPrefix_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetPrefix);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodgetPrefix, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_publishJobInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getPrefix) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_getPrefix_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetPrefix);
            var methodInfo = this.GetMethodInfo(MethodgetPrefix, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setupProjectCenter) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PublishJob_setupProjectCenter_Method_Call_Internally(Type[] types)
        {
            var methodsetupProjectCenterPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_publishJobInstance, MethodsetupProjectCenter, Fixture, methodsetupProjectCenterPrametersTypes);
        }

        #endregion

        #region Method Call : (setupProjectCenter) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_setupProjectCenter_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodsetupProjectCenter);
            var list = this.CreateType<SPList>();
            var methodsetupProjectCenterPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfsetupProjectCenter = { list };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodsetupProjectCenter, methodsetupProjectCenterPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_publishJobInstanceFixture, parametersOfsetupProjectCenter);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfsetupProjectCenter.ShouldNotBeNull();
            parametersOfsetupProjectCenter.Length.ShouldBe(1);
            methodsetupProjectCenterPrametersTypes.Length.ShouldBe(1);
            methodsetupProjectCenterPrametersTypes.Length.ShouldBe(parametersOfsetupProjectCenter.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setupProjectCenter) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_setupProjectCenter_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodsetupProjectCenter);
            var list = this.CreateType<SPList>();
            var methodsetupProjectCenterPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfsetupProjectCenter = { list };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_publishJobInstance, MethodsetupProjectCenter, parametersOfsetupProjectCenter, methodsetupProjectCenterPrametersTypes);

            // Assert
            parametersOfsetupProjectCenter.ShouldNotBeNull();
            parametersOfsetupProjectCenter.Length.ShouldBe(1);
            methodsetupProjectCenterPrametersTypes.Length.ShouldBe(1);
            methodsetupProjectCenterPrametersTypes.Length.ShouldBe(parametersOfsetupProjectCenter.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setupProjectCenter) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_setupProjectCenter_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodsetupProjectCenter);
            var methodInfo = this.GetMethodInfo(MethodsetupProjectCenter, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setupProjectCenter) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_setupProjectCenter_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodsetupProjectCenter);
            var methodsetupProjectCenterPrametersTypes = new Type[] { typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_publishJobInstance, MethodsetupProjectCenter, Fixture, methodsetupProjectCenterPrametersTypes);

            // Assert
            methodsetupProjectCenterPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setupProjectCenter) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_setupProjectCenter_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodsetupProjectCenter);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodsetupProjectCenter, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_publishJobInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setupTaskCenter) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PublishJob_setupTaskCenter_Method_Call_Internally(Type[] types)
        {
            var methodsetupTaskCenterPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_publishJobInstance, MethodsetupTaskCenter, Fixture, methodsetupTaskCenterPrametersTypes);
        }

        #endregion

        #region Method Call : (setupTaskCenter) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_setupTaskCenter_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodsetupTaskCenter);
            var list = this.CreateType<SPList>();
            var methodsetupTaskCenterPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfsetupTaskCenter = { list };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodsetupTaskCenter, methodsetupTaskCenterPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_publishJobInstanceFixture, parametersOfsetupTaskCenter);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfsetupTaskCenter.ShouldNotBeNull();
            parametersOfsetupTaskCenter.Length.ShouldBe(1);
            methodsetupTaskCenterPrametersTypes.Length.ShouldBe(1);
            methodsetupTaskCenterPrametersTypes.Length.ShouldBe(parametersOfsetupTaskCenter.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (setupTaskCenter) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_setupTaskCenter_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodsetupTaskCenter);
            var list = this.CreateType<SPList>();
            var methodsetupTaskCenterPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfsetupTaskCenter = { list };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_publishJobInstance, MethodsetupTaskCenter, parametersOfsetupTaskCenter, methodsetupTaskCenterPrametersTypes);

            // Assert
            parametersOfsetupTaskCenter.ShouldNotBeNull();
            parametersOfsetupTaskCenter.Length.ShouldBe(1);
            methodsetupTaskCenterPrametersTypes.Length.ShouldBe(1);
            methodsetupTaskCenterPrametersTypes.Length.ShouldBe(parametersOfsetupTaskCenter.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setupTaskCenter) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_setupTaskCenter_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodsetupTaskCenter);
            var methodInfo = this.GetMethodInfo(MethodsetupTaskCenter, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setupTaskCenter) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_setupTaskCenter_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodsetupTaskCenter);
            var methodsetupTaskCenterPrametersTypes = new Type[] { typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_publishJobInstance, MethodsetupTaskCenter, Fixture, methodsetupTaskCenterPrametersTypes);

            // Assert
            methodsetupTaskCenterPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setupTaskCenter) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_setupTaskCenter_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodsetupTaskCenter);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodsetupTaskCenter, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_publishJobInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ensureFolder) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PublishJob_ensureFolder_Method_Call_Internally(Type[] types)
        {
            var methodensureFolderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_publishJobInstance, MethodensureFolder, Fixture, methodensureFolderPrametersTypes);
        }

        #endregion

        #region Method Call : (ensureFolder) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_ensureFolder_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodensureFolder);
            var list = this.CreateType<SPList>();
            var folder = this.CreateType<string>();
            var methodensureFolderPrametersTypes = new Type[] { typeof(SPList), typeof(string) };
            object[] parametersOfensureFolder = { list, folder };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodensureFolder, methodensureFolderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_publishJobInstanceFixture, parametersOfensureFolder);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfensureFolder.ShouldNotBeNull();
            parametersOfensureFolder.Length.ShouldBe(2);
            methodensureFolderPrametersTypes.Length.ShouldBe(2);
            methodensureFolderPrametersTypes.Length.ShouldBe(parametersOfensureFolder.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ensureFolder) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_ensureFolder_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodensureFolder);
            var list = this.CreateType<SPList>();
            var folder = this.CreateType<string>();
            var methodensureFolderPrametersTypes = new Type[] { typeof(SPList), typeof(string) };
            object[] parametersOfensureFolder = { list, folder };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_publishJobInstance, MethodensureFolder, parametersOfensureFolder, methodensureFolderPrametersTypes);

            // Assert
            parametersOfensureFolder.ShouldNotBeNull();
            parametersOfensureFolder.Length.ShouldBe(2);
            methodensureFolderPrametersTypes.Length.ShouldBe(2);
            methodensureFolderPrametersTypes.Length.ShouldBe(parametersOfensureFolder.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ensureFolder) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_ensureFolder_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodensureFolder);
            var methodInfo = this.GetMethodInfo(MethodensureFolder, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ensureFolder) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_ensureFolder_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodensureFolder);
            var methodensureFolderPrametersTypes = new Type[] { typeof(SPList), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_publishJobInstance, MethodensureFolder, Fixture, methodensureFolderPrametersTypes);

            // Assert
            methodensureFolderPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ensureFolder) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_ensureFolder_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodensureFolder);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodensureFolder, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_publishJobInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (MoveListItemToFolder) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PublishJob_MoveListItemToFolder_Static_Method_Call_Internally(Type[] types)
        {
            var methodMoveListItemToFolderPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_publishJobInstanceFixture, _publishJobInstanceType, MethodMoveListItemToFolder, Fixture, methodMoveListItemToFolderPrametersTypes);
        }

        #endregion

        #region Method Call : (MoveListItemToFolder) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_MoveListItemToFolder_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodMoveListItemToFolder);
            var item = this.CreateType<SPListItem>();
            var destinationFolder = this.CreateType<SPFolder>();
            Action executeAction = null;

            // Act
            executeAction = () => PublishJob.MoveListItemToFolder(item, destinationFolder);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (MoveListItemToFolder) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_MoveListItemToFolder_Static_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodMoveListItemToFolder);
            var item = this.CreateType<SPListItem>();
            var destinationFolder = this.CreateType<SPFolder>();
            var methodMoveListItemToFolderPrametersTypes = new Type[] { typeof(SPListItem), typeof(SPFolder) };
            object[] parametersOfMoveListItemToFolder = { item, destinationFolder };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodMoveListItemToFolder, methodMoveListItemToFolderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_publishJobInstanceFixture, parametersOfMoveListItemToFolder);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfMoveListItemToFolder.ShouldNotBeNull();
            parametersOfMoveListItemToFolder.Length.ShouldBe(2);
            methodMoveListItemToFolderPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (MoveListItemToFolder) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_MoveListItemToFolder_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodMoveListItemToFolder);
            var item = this.CreateType<SPListItem>();
            var destinationFolder = this.CreateType<SPFolder>();
            var methodMoveListItemToFolderPrametersTypes = new Type[] { typeof(SPListItem), typeof(SPFolder) };
            object[] parametersOfMoveListItemToFolder = { item, destinationFolder };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_publishJobInstanceFixture, _publishJobInstanceType, MethodMoveListItemToFolder, parametersOfMoveListItemToFolder, methodMoveListItemToFolderPrametersTypes);

            // Assert
            parametersOfMoveListItemToFolder.ShouldNotBeNull();
            parametersOfMoveListItemToFolder.Length.ShouldBe(2);
            methodMoveListItemToFolderPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (MoveListItemToFolder) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_MoveListItemToFolder_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodMoveListItemToFolder);
            var methodInfo = this.GetMethodInfo(MethodMoveListItemToFolder, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (MoveListItemToFolder) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_MoveListItemToFolder_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodMoveListItemToFolder);
            var methodMoveListItemToFolderPrametersTypes = new Type[] { typeof(SPListItem), typeof(SPFolder) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_publishJobInstanceFixture, _publishJobInstanceType, MethodMoveListItemToFolder, Fixture, methodMoveListItemToFolderPrametersTypes);

            // Assert
            methodMoveListItemToFolderPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (MoveListItemToFolder) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_MoveListItemToFolder_Static_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodMoveListItemToFolder);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodMoveListItemToFolder, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_publishJobInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (publishTasks) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PublishJob_publishTasks_Method_Call_Internally(Type[] types)
        {
            var methodpublishTasksPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_publishJobInstance, MethodpublishTasks, Fixture, methodpublishTasksPrametersTypes);
        }

        #endregion

        #region Method Call : (publishTasks) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_publishTasks_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodpublishTasks);
            var doc = this.CreateType<XmlDocument>();
            var list = this.CreateType<SPList>();
            var projectid = this.CreateType<string>();
            var taskFields = this.CreateType<Hashtable>();
            var taskCenterProjectField = this.CreateType<string>();
            var sPrefix = this.CreateType<string>();
            var props = this.CreateType<EPMLiveWorkPlanner.WorkPlannerAPI.PlannerProps>();
            var plannerid = this.CreateType<string>();
            var methodpublishTasksPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPList), typeof(string), typeof(Hashtable), typeof(string), typeof(string), typeof(EPMLiveWorkPlanner.WorkPlannerAPI.PlannerProps), typeof(string) };
            object[] parametersOfpublishTasks = { doc, list, projectid, taskFields, taskCenterProjectField, sPrefix, props, plannerid };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodpublishTasks, methodpublishTasksPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_publishJobInstanceFixture, parametersOfpublishTasks);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfpublishTasks.ShouldNotBeNull();
            parametersOfpublishTasks.Length.ShouldBe(8);
            methodpublishTasksPrametersTypes.Length.ShouldBe(8);
            methodpublishTasksPrametersTypes.Length.ShouldBe(parametersOfpublishTasks.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (publishTasks) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_publishTasks_Method_Call_Void_With_8_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodpublishTasks);
            var doc = this.CreateType<XmlDocument>();
            var list = this.CreateType<SPList>();
            var projectid = this.CreateType<string>();
            var taskFields = this.CreateType<Hashtable>();
            var taskCenterProjectField = this.CreateType<string>();
            var sPrefix = this.CreateType<string>();
            var props = this.CreateType<EPMLiveWorkPlanner.WorkPlannerAPI.PlannerProps>();
            var plannerid = this.CreateType<string>();
            var methodpublishTasksPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPList), typeof(string), typeof(Hashtable), typeof(string), typeof(string), typeof(EPMLiveWorkPlanner.WorkPlannerAPI.PlannerProps), typeof(string) };
            object[] parametersOfpublishTasks = { doc, list, projectid, taskFields, taskCenterProjectField, sPrefix, props, plannerid };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_publishJobInstance, MethodpublishTasks, parametersOfpublishTasks, methodpublishTasksPrametersTypes);

            // Assert
            parametersOfpublishTasks.ShouldNotBeNull();
            parametersOfpublishTasks.Length.ShouldBe(8);
            methodpublishTasksPrametersTypes.Length.ShouldBe(8);
            methodpublishTasksPrametersTypes.Length.ShouldBe(parametersOfpublishTasks.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (publishTasks) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_publishTasks_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodpublishTasks);
            var methodInfo = this.GetMethodInfo(MethodpublishTasks, 0);
            const int parametersCount = 8;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (publishTasks) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_publishTasks_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodpublishTasks);
            var methodpublishTasksPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPList), typeof(string), typeof(Hashtable), typeof(string), typeof(string), typeof(EPMLiveWorkPlanner.WorkPlannerAPI.PlannerProps), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_publishJobInstance, MethodpublishTasks, Fixture, methodpublishTasksPrametersTypes);

            // Assert
            methodpublishTasksPrametersTypes.Length.ShouldBe(8);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (publishTasks) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_publishTasks_Method_Call_With_8_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodpublishTasks);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodpublishTasks, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_publishJobInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processTask) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PublishJob_processTask_Method_Call_Internally(Type[] types)
        {
            var methodprocessTaskPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_publishJobInstance, MethodprocessTask, Fixture, methodprocessTaskPrametersTypes);
        }

        #endregion

        #region Method Call : (processTask) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_processTask_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodprocessTask);
            var ndTask = this.CreateType<XmlNode>();
            var liTask = this.CreateType<SPListItem>();
            var taskFields = this.CreateType<Hashtable>();
            var web = this.CreateType<SPWeb>();
            var sPrefix = this.CreateType<string>();
            var projectid = this.CreateType<string>();
            var methodprocessTaskPrametersTypes = new Type[] { typeof(XmlNode), typeof(SPListItem), typeof(Hashtable), typeof(SPWeb), typeof(string), typeof(string) };
            object[] parametersOfprocessTask = { ndTask, liTask, taskFields, web, sPrefix, projectid };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodprocessTask, methodprocessTaskPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_publishJobInstanceFixture, parametersOfprocessTask);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfprocessTask.ShouldNotBeNull();
            parametersOfprocessTask.Length.ShouldBe(6);
            methodprocessTaskPrametersTypes.Length.ShouldBe(6);
            methodprocessTaskPrametersTypes.Length.ShouldBe(parametersOfprocessTask.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (processTask) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_processTask_Method_Call_Void_With_6_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodprocessTask);
            var ndTask = this.CreateType<XmlNode>();
            var liTask = this.CreateType<SPListItem>();
            var taskFields = this.CreateType<Hashtable>();
            var web = this.CreateType<SPWeb>();
            var sPrefix = this.CreateType<string>();
            var projectid = this.CreateType<string>();
            var methodprocessTaskPrametersTypes = new Type[] { typeof(XmlNode), typeof(SPListItem), typeof(Hashtable), typeof(SPWeb), typeof(string), typeof(string) };
            object[] parametersOfprocessTask = { ndTask, liTask, taskFields, web, sPrefix, projectid };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_publishJobInstance, MethodprocessTask, parametersOfprocessTask, methodprocessTaskPrametersTypes);

            // Assert
            parametersOfprocessTask.ShouldNotBeNull();
            parametersOfprocessTask.Length.ShouldBe(6);
            methodprocessTaskPrametersTypes.Length.ShouldBe(6);
            methodprocessTaskPrametersTypes.Length.ShouldBe(parametersOfprocessTask.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processTask) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_processTask_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodprocessTask);
            var methodInfo = this.GetMethodInfo(MethodprocessTask, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processTask) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_processTask_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodprocessTask);
            var methodprocessTaskPrametersTypes = new Type[] { typeof(XmlNode), typeof(SPListItem), typeof(Hashtable), typeof(SPWeb), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_publishJobInstance, MethodprocessTask, Fixture, methodprocessTaskPrametersTypes);

            // Assert
            methodprocessTaskPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processTask) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishJob_processTask_Method_Call_With_6_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodprocessTask);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodprocessTask, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_publishJobInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
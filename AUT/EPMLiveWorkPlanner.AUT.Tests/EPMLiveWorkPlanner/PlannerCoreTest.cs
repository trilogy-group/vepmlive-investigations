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
using Microsoft.SharePoint;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveWorkPlanner;
using PlannerCore = EPMLiveWorkPlanner;

namespace EPMLiveWorkPlanner
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWorkPlanner.PlannerCore" />)
    ///     and namespace <see cref="EPMLiveWorkPlanner"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class PlannerCoreTest : AbstractBaseSetupV3Test
    {
        public PlannerCoreTest() : base(typeof(PlannerCore))
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

        #region General Initializer : Class (PlannerCore) Initializer

        #region Methods

        private const string MethodgetResourceList = "getResourceList";
        private const string MethodgetFieldInfo = "getFieldInfo";
        private const string MethodgetStatusMethod = "getStatusMethod";
        private const string MethodgetWorkPlannerStatusFields = "getWorkPlannerStatusFields";
        private const string MethodgetWorkPlannerFromTaskList = "getWorkPlannerFromTaskList";

        #endregion

        private Type _plannerCoreInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private PlannerCore _plannerCoreInstance;
        private PlannerCore _plannerCoreInstanceFixture;

        #region General Initializer : Class (PlannerCore) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PlannerCore" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _plannerCoreInstanceType = typeof(PlannerCore);
            _plannerCoreInstanceFixture = this.Create<PlannerCore>(true);
            _plannerCoreInstance = _plannerCoreInstanceFixture ?? this.Create<PlannerCore>(false);
            CurrentInstance = _plannerCoreInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PlannerCore)

        #region General Initializer : Class (PlannerCore) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="PlannerCore" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodgetResourceList, 0)]
        [TestCase(MethodgetFieldInfo, 0)]
        [TestCase(MethodgetStatusMethod, 0)]
        [TestCase(MethodgetWorkPlannerStatusFields, 0)]
        [TestCase(MethodgetWorkPlannerFromTaskList, 0)]
        public void AUT_PlannerCore_All_Methods_Explore_Verify_Test(string name, int overloadingIndex = 0)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var currentMethodInfo = this.GetMethodInfo(name, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_plannerCoreInstanceFixture, 
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
        ///     Class (<see cref="PlannerCore" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_PlannerCore_Is_Instance_Present_Test()
        {
            // Assert
            _plannerCoreInstanceType.ShouldNotBeNull();
            _plannerCoreInstance.ShouldNotBeNull();
            _plannerCoreInstanceFixture.ShouldNotBeNull();
            _plannerCoreInstance.ShouldBeAssignableTo<PlannerCore>();
            _plannerCoreInstanceFixture.ShouldBeAssignableTo<PlannerCore>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (PlannerCore) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_PlannerCore_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            PlannerCore instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _plannerCoreInstanceType.ShouldNotBeNull();
            _plannerCoreInstance.ShouldNotBeNull();
            _plannerCoreInstanceFixture.ShouldNotBeNull();
            _plannerCoreInstance.ShouldBeAssignableTo<PlannerCore>();
            _plannerCoreInstanceFixture.ShouldBeAssignableTo<PlannerCore>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : (getResourceList) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PlannerCore_getResourceList_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetResourceListPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_plannerCoreInstanceFixture, _plannerCoreInstanceType, MethodgetResourceList, Fixture, methodgetResourceListPrametersTypes);
        }

        #endregion

        #region Method Call : (getResourceList) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PlannerCore_getResourceList_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetResourceList);
            var input = this.CreateType<string>();
            var oWeb = this.CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => PlannerCore.getResourceList(input, oWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (getResourceList) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PlannerCore_getResourceList_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetResourceList);
            var input = this.CreateType<string>();
            var oWeb = this.CreateType<SPWeb>();
            var methodgetResourceListPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfgetResourceList = { input, oWeb };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodgetResourceList, methodgetResourceListPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_plannerCoreInstanceFixture, _plannerCoreInstanceType, MethodgetResourceList, Fixture, methodgetResourceListPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_plannerCoreInstanceFixture, _plannerCoreInstanceType, MethodgetResourceList, parametersOfgetResourceList, methodgetResourceListPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_plannerCoreInstanceFixture, parametersOfgetResourceList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetResourceList.ShouldNotBeNull();
            parametersOfgetResourceList.Length.ShouldBe(2);
            methodgetResourceListPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (getResourceList) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PlannerCore_getResourceList_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetResourceList);
            var input = this.CreateType<string>();
            var oWeb = this.CreateType<SPWeb>();
            var methodgetResourceListPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfgetResourceList = { input, oWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_plannerCoreInstanceFixture, _plannerCoreInstanceType, MethodgetResourceList, parametersOfgetResourceList, methodgetResourceListPrametersTypes);

            // Assert
            parametersOfgetResourceList.ShouldNotBeNull();
            parametersOfgetResourceList.Length.ShouldBe(2);
            methodgetResourceListPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getResourceList) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PlannerCore_getResourceList_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetResourceList);
            var methodgetResourceListPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_plannerCoreInstanceFixture, _plannerCoreInstanceType, MethodgetResourceList, Fixture, methodgetResourceListPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetResourceListPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (getResourceList) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PlannerCore_getResourceList_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetResourceList);
            var methodgetResourceListPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_plannerCoreInstanceFixture, _plannerCoreInstanceType, MethodgetResourceList, Fixture, methodgetResourceListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetResourceListPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getResourceList) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PlannerCore_getResourceList_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetResourceList);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodgetResourceList, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_plannerCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getResourceList) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PlannerCore_getResourceList_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetResourceList);
            var methodInfo = this.GetMethodInfo(MethodgetResourceList, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getFieldInfo) (Return Type : SortedList) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PlannerCore_getFieldInfo_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetFieldInfoPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_plannerCoreInstanceFixture, _plannerCoreInstanceType, MethodgetFieldInfo, Fixture, methodgetFieldInfoPrametersTypes);
        }

        #endregion

        #region Method Call : (getFieldInfo) (Return Type : SortedList) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PlannerCore_getFieldInfo_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetFieldInfo);
            var web = this.CreateType<SPWeb>();
            var planner = this.CreateType<string>();
            var methodgetFieldInfoPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfgetFieldInfo = { web, planner };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodgetFieldInfo, methodgetFieldInfoPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_plannerCoreInstanceFixture, _plannerCoreInstanceType, MethodgetFieldInfo, Fixture, methodgetFieldInfoPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<SortedList>(_plannerCoreInstanceFixture, _plannerCoreInstanceType, MethodgetFieldInfo, parametersOfgetFieldInfo, methodgetFieldInfoPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_plannerCoreInstanceFixture, parametersOfgetFieldInfo);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetFieldInfo.ShouldNotBeNull();
            parametersOfgetFieldInfo.Length.ShouldBe(2);
            methodgetFieldInfoPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (getFieldInfo) (Return Type : SortedList) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PlannerCore_getFieldInfo_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetFieldInfo);
            var web = this.CreateType<SPWeb>();
            var planner = this.CreateType<string>();
            var methodgetFieldInfoPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfgetFieldInfo = { web, planner };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<SortedList>(_plannerCoreInstanceFixture, _plannerCoreInstanceType, MethodgetFieldInfo, parametersOfgetFieldInfo, methodgetFieldInfoPrametersTypes);

            // Assert
            parametersOfgetFieldInfo.ShouldNotBeNull();
            parametersOfgetFieldInfo.Length.ShouldBe(2);
            methodgetFieldInfoPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getFieldInfo) (Return Type : SortedList) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PlannerCore_getFieldInfo_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetFieldInfo);
            var methodgetFieldInfoPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_plannerCoreInstanceFixture, _plannerCoreInstanceType, MethodgetFieldInfo, Fixture, methodgetFieldInfoPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetFieldInfoPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (getFieldInfo) (Return Type : SortedList) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PlannerCore_getFieldInfo_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetFieldInfo);
            var methodgetFieldInfoPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_plannerCoreInstanceFixture, _plannerCoreInstanceType, MethodgetFieldInfo, Fixture, methodgetFieldInfoPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetFieldInfoPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getFieldInfo) (Return Type : SortedList) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PlannerCore_getFieldInfo_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetFieldInfo);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodgetFieldInfo, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_plannerCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getFieldInfo) (Return Type : SortedList) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PlannerCore_getFieldInfo_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetFieldInfo);
            var methodInfo = this.GetMethodInfo(MethodgetFieldInfo, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getStatusMethod) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PlannerCore_getStatusMethod_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetStatusMethodPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_plannerCoreInstanceFixture, _plannerCoreInstanceType, MethodgetStatusMethod, Fixture, methodgetStatusMethodPrametersTypes);
        }

        #endregion

        #region Method Call : (getStatusMethod) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PlannerCore_getStatusMethod_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetStatusMethod);
            var w = this.CreateType<SPWeb>();
            var list = this.CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => PlannerCore.getStatusMethod(w, list);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (getStatusMethod) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PlannerCore_getStatusMethod_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetStatusMethod);
            var w = this.CreateType<SPWeb>();
            var list = this.CreateType<string>();
            var methodgetStatusMethodPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfgetStatusMethod = { w, list };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodgetStatusMethod, methodgetStatusMethodPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_plannerCoreInstanceFixture, _plannerCoreInstanceType, MethodgetStatusMethod, Fixture, methodgetStatusMethodPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_plannerCoreInstanceFixture, _plannerCoreInstanceType, MethodgetStatusMethod, parametersOfgetStatusMethod, methodgetStatusMethodPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            parametersOfgetStatusMethod.ShouldNotBeNull();
            parametersOfgetStatusMethod.Length.ShouldBe(2);
            methodgetStatusMethodPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_plannerCoreInstanceFixture, _plannerCoreInstanceType, MethodgetStatusMethod, parametersOfgetStatusMethod, methodgetStatusMethodPrametersTypes));
        }

        #endregion

        #region Method Call : (getStatusMethod) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PlannerCore_getStatusMethod_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetStatusMethod);
            var w = this.CreateType<SPWeb>();
            var list = this.CreateType<string>();
            var methodgetStatusMethodPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfgetStatusMethod = { w, list };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodgetStatusMethod, methodgetStatusMethodPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_plannerCoreInstanceFixture, parametersOfgetStatusMethod);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetStatusMethod.ShouldNotBeNull();
            parametersOfgetStatusMethod.Length.ShouldBe(2);
            methodgetStatusMethodPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getStatusMethod) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PlannerCore_getStatusMethod_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetStatusMethod);
            var w = this.CreateType<SPWeb>();
            var list = this.CreateType<string>();
            var methodgetStatusMethodPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfgetStatusMethod = { w, list };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_plannerCoreInstanceFixture, _plannerCoreInstanceType, MethodgetStatusMethod, parametersOfgetStatusMethod, methodgetStatusMethodPrametersTypes);

            // Assert
            parametersOfgetStatusMethod.ShouldNotBeNull();
            parametersOfgetStatusMethod.Length.ShouldBe(2);
            methodgetStatusMethodPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getStatusMethod) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PlannerCore_getStatusMethod_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetStatusMethod);
            var methodgetStatusMethodPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_plannerCoreInstanceFixture, _plannerCoreInstanceType, MethodgetStatusMethod, Fixture, methodgetStatusMethodPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodgetStatusMethodPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (getStatusMethod) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PlannerCore_getStatusMethod_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetStatusMethod);
            var methodgetStatusMethodPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_plannerCoreInstanceFixture, _plannerCoreInstanceType, MethodgetStatusMethod, Fixture, methodgetStatusMethodPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetStatusMethodPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getStatusMethod) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PlannerCore_getStatusMethod_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetStatusMethod);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodgetStatusMethod, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_plannerCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getStatusMethod) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PlannerCore_getStatusMethod_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetStatusMethod);
            var methodInfo = this.GetMethodInfo(MethodgetStatusMethod, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getWorkPlannerStatusFields) (Return Type : SortedList) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PlannerCore_getWorkPlannerStatusFields_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetWorkPlannerStatusFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_plannerCoreInstanceFixture, _plannerCoreInstanceType, MethodgetWorkPlannerStatusFields, Fixture, methodgetWorkPlannerStatusFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (getWorkPlannerStatusFields) (Return Type : SortedList) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PlannerCore_getWorkPlannerStatusFields_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetWorkPlannerStatusFields);
            var w = this.CreateType<SPWeb>();
            var list = this.CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => PlannerCore.getWorkPlannerStatusFields(w, list);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (getWorkPlannerStatusFields) (Return Type : SortedList) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PlannerCore_getWorkPlannerStatusFields_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetWorkPlannerStatusFields);
            var w = this.CreateType<SPWeb>();
            var list = this.CreateType<string>();
            var methodgetWorkPlannerStatusFieldsPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfgetWorkPlannerStatusFields = { w, list };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodgetWorkPlannerStatusFields, methodgetWorkPlannerStatusFieldsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_plannerCoreInstanceFixture, _plannerCoreInstanceType, MethodgetWorkPlannerStatusFields, Fixture, methodgetWorkPlannerStatusFieldsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<SortedList>(_plannerCoreInstanceFixture, _plannerCoreInstanceType, MethodgetWorkPlannerStatusFields, parametersOfgetWorkPlannerStatusFields, methodgetWorkPlannerStatusFieldsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            parametersOfgetWorkPlannerStatusFields.ShouldNotBeNull();
            parametersOfgetWorkPlannerStatusFields.Length.ShouldBe(2);
            methodgetWorkPlannerStatusFieldsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<SortedList>(_plannerCoreInstanceFixture, _plannerCoreInstanceType, MethodgetWorkPlannerStatusFields, parametersOfgetWorkPlannerStatusFields, methodgetWorkPlannerStatusFieldsPrametersTypes));
        }

        #endregion

        #region Method Call : (getWorkPlannerStatusFields) (Return Type : SortedList) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PlannerCore_getWorkPlannerStatusFields_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetWorkPlannerStatusFields);
            var w = this.CreateType<SPWeb>();
            var list = this.CreateType<string>();
            var methodgetWorkPlannerStatusFieldsPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfgetWorkPlannerStatusFields = { w, list };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodgetWorkPlannerStatusFields, methodgetWorkPlannerStatusFieldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_plannerCoreInstanceFixture, parametersOfgetWorkPlannerStatusFields);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetWorkPlannerStatusFields.ShouldNotBeNull();
            parametersOfgetWorkPlannerStatusFields.Length.ShouldBe(2);
            methodgetWorkPlannerStatusFieldsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getWorkPlannerStatusFields) (Return Type : SortedList) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PlannerCore_getWorkPlannerStatusFields_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetWorkPlannerStatusFields);
            var w = this.CreateType<SPWeb>();
            var list = this.CreateType<string>();
            var methodgetWorkPlannerStatusFieldsPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfgetWorkPlannerStatusFields = { w, list };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<SortedList>(_plannerCoreInstanceFixture, _plannerCoreInstanceType, MethodgetWorkPlannerStatusFields, parametersOfgetWorkPlannerStatusFields, methodgetWorkPlannerStatusFieldsPrametersTypes);

            // Assert
            parametersOfgetWorkPlannerStatusFields.ShouldNotBeNull();
            parametersOfgetWorkPlannerStatusFields.Length.ShouldBe(2);
            methodgetWorkPlannerStatusFieldsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getWorkPlannerStatusFields) (Return Type : SortedList) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PlannerCore_getWorkPlannerStatusFields_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetWorkPlannerStatusFields);
            var methodgetWorkPlannerStatusFieldsPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_plannerCoreInstanceFixture, _plannerCoreInstanceType, MethodgetWorkPlannerStatusFields, Fixture, methodgetWorkPlannerStatusFieldsPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodgetWorkPlannerStatusFieldsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (getWorkPlannerStatusFields) (Return Type : SortedList) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PlannerCore_getWorkPlannerStatusFields_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetWorkPlannerStatusFields);
            var methodgetWorkPlannerStatusFieldsPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_plannerCoreInstanceFixture, _plannerCoreInstanceType, MethodgetWorkPlannerStatusFields, Fixture, methodgetWorkPlannerStatusFieldsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetWorkPlannerStatusFieldsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getWorkPlannerStatusFields) (Return Type : SortedList) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PlannerCore_getWorkPlannerStatusFields_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetWorkPlannerStatusFields);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodgetWorkPlannerStatusFields, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_plannerCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getWorkPlannerStatusFields) (Return Type : SortedList) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PlannerCore_getWorkPlannerStatusFields_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetWorkPlannerStatusFields);
            var methodInfo = this.GetMethodInfo(MethodgetWorkPlannerStatusFields, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getWorkPlannerFromTaskList) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PlannerCore_getWorkPlannerFromTaskList_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetWorkPlannerFromTaskListPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_plannerCoreInstanceFixture, _plannerCoreInstanceType, MethodgetWorkPlannerFromTaskList, Fixture, methodgetWorkPlannerFromTaskListPrametersTypes);
        }

        #endregion

        #region Method Call : (getWorkPlannerFromTaskList) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PlannerCore_getWorkPlannerFromTaskList_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetWorkPlannerFromTaskList);
            var w = this.CreateType<SPWeb>();
            var list = this.CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => PlannerCore.getWorkPlannerFromTaskList(w, list);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (getWorkPlannerFromTaskList) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PlannerCore_getWorkPlannerFromTaskList_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetWorkPlannerFromTaskList);
            var w = this.CreateType<SPWeb>();
            var list = this.CreateType<string>();
            var methodgetWorkPlannerFromTaskListPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfgetWorkPlannerFromTaskList = { w, list };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodgetWorkPlannerFromTaskList, methodgetWorkPlannerFromTaskListPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_plannerCoreInstanceFixture, _plannerCoreInstanceType, MethodgetWorkPlannerFromTaskList, Fixture, methodgetWorkPlannerFromTaskListPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_plannerCoreInstanceFixture, _plannerCoreInstanceType, MethodgetWorkPlannerFromTaskList, parametersOfgetWorkPlannerFromTaskList, methodgetWorkPlannerFromTaskListPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            parametersOfgetWorkPlannerFromTaskList.ShouldNotBeNull();
            parametersOfgetWorkPlannerFromTaskList.Length.ShouldBe(2);
            methodgetWorkPlannerFromTaskListPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_plannerCoreInstanceFixture, _plannerCoreInstanceType, MethodgetWorkPlannerFromTaskList, parametersOfgetWorkPlannerFromTaskList, methodgetWorkPlannerFromTaskListPrametersTypes));
        }

        #endregion

        #region Method Call : (getWorkPlannerFromTaskList) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PlannerCore_getWorkPlannerFromTaskList_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetWorkPlannerFromTaskList);
            var w = this.CreateType<SPWeb>();
            var list = this.CreateType<string>();
            var methodgetWorkPlannerFromTaskListPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfgetWorkPlannerFromTaskList = { w, list };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodgetWorkPlannerFromTaskList, methodgetWorkPlannerFromTaskListPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_plannerCoreInstanceFixture, parametersOfgetWorkPlannerFromTaskList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetWorkPlannerFromTaskList.ShouldNotBeNull();
            parametersOfgetWorkPlannerFromTaskList.Length.ShouldBe(2);
            methodgetWorkPlannerFromTaskListPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getWorkPlannerFromTaskList) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PlannerCore_getWorkPlannerFromTaskList_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetWorkPlannerFromTaskList);
            var w = this.CreateType<SPWeb>();
            var list = this.CreateType<string>();
            var methodgetWorkPlannerFromTaskListPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfgetWorkPlannerFromTaskList = { w, list };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_plannerCoreInstanceFixture, _plannerCoreInstanceType, MethodgetWorkPlannerFromTaskList, parametersOfgetWorkPlannerFromTaskList, methodgetWorkPlannerFromTaskListPrametersTypes);

            // Assert
            parametersOfgetWorkPlannerFromTaskList.ShouldNotBeNull();
            parametersOfgetWorkPlannerFromTaskList.Length.ShouldBe(2);
            methodgetWorkPlannerFromTaskListPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getWorkPlannerFromTaskList) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PlannerCore_getWorkPlannerFromTaskList_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetWorkPlannerFromTaskList);
            var methodgetWorkPlannerFromTaskListPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_plannerCoreInstanceFixture, _plannerCoreInstanceType, MethodgetWorkPlannerFromTaskList, Fixture, methodgetWorkPlannerFromTaskListPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodgetWorkPlannerFromTaskListPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (getWorkPlannerFromTaskList) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PlannerCore_getWorkPlannerFromTaskList_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetWorkPlannerFromTaskList);
            var methodgetWorkPlannerFromTaskListPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_plannerCoreInstanceFixture, _plannerCoreInstanceType, MethodgetWorkPlannerFromTaskList, Fixture, methodgetWorkPlannerFromTaskListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetWorkPlannerFromTaskListPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getWorkPlannerFromTaskList) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PlannerCore_getWorkPlannerFromTaskList_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetWorkPlannerFromTaskList);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodgetWorkPlannerFromTaskList, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_plannerCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getWorkPlannerFromTaskList) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PlannerCore_getWorkPlannerFromTaskList_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetWorkPlannerFromTaskList);
            var methodInfo = this.GetMethodInfo(MethodgetWorkPlannerFromTaskList, 0);
            const int parametersCount = 2;

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
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
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveWorkPlanner;
using gettasks = EPMLiveWorkPlanner;

namespace EPMLiveWorkPlanner
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWorkPlanner.gettasks" />)
    ///     and namespace <see cref="EPMLiveWorkPlanner"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class GettasksTest : AbstractBaseSetupV3Test
    {
        public GettasksTest() : base(typeof(gettasks))
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

        #region General Initializer : Class (gettasks) Initializer

        #region Methods

        private const string MethodPage_Load = "Page_Load";
        private const string MethodgetPercentCalc = "getPercentCalc";
        private const string MethodgetLookupList = "getLookupList";
        private const string MethodgetSingleLookup = "getSingleLookup";
        private const string MethodgetSingleUser = "getSingleUser";
        private const string MethodgetMultiUser = "getMultiUser";
        private const string MethodgetRealField = "getRealField";
        private const string MethodaddHeader = "addHeader";
        private const string MethodgetCellData = "getCellData";
        private const string MethodgetWBS = "getWBS";

        #endregion

        #region Fields

        private const string Fielddata = "data";
        private const string FielduseResourcePool = "useResourcePool";
        private const string FieldslResources = "slResources";
        private const string Fieldview = "view";
        private const string Fieldweb = "web";
        private const string FieldhshComboCells = "hshComboCells";
        private const string FieldarrNewTasks = "arrNewTasks";
        private const string Fieldtaskordercol = "taskordercol";
        private const string FieldlstProjectCenter = "lstProjectCenter";
        private const string FieldlstTaskCenter = "lstTaskCenter";
        private const string FieldsResourcePoolUrl = "sResourcePoolUrl";
        private const string FieldsResourceList = "sResourceList";
        private const string FieldwpFields = "wpFields";

        #endregion

        private Type _gettasksInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private gettasks _gettasksInstance;
        private gettasks _gettasksInstanceFixture;

        #region General Initializer : Class (gettasks) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="gettasks" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _gettasksInstanceType = typeof(gettasks);
            _gettasksInstanceFixture = this.Create<gettasks>(true);
            _gettasksInstance = _gettasksInstanceFixture ?? this.Create<gettasks>(false);
            CurrentInstance = _gettasksInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (gettasks)

        #region General Initializer : Class (gettasks) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="gettasks" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodgetPercentCalc, 0)]
        [TestCase(MethodgetLookupList, 0)]
        [TestCase(MethodgetSingleLookup, 0)]
        [TestCase(MethodgetSingleUser, 0)]
        [TestCase(MethodgetMultiUser, 0)]
        [TestCase(MethodgetRealField, 0)]
        [TestCase(MethodaddHeader, 0)]
        [TestCase(MethodgetCellData, 0)]
        [TestCase(MethodgetWBS, 0)]
        public void AUT_Gettasks_All_Methods_Explore_Verify_Test(string name, int overloadingIndex = 0)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var currentMethodInfo = this.GetMethodInfo(name, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_gettasksInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (gettasks) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="gettasks" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fielddata)]
        [TestCase(FielduseResourcePool)]
        [TestCase(FieldslResources)]
        [TestCase(Fieldview)]
        [TestCase(Fieldweb)]
        [TestCase(FieldhshComboCells)]
        [TestCase(FieldarrNewTasks)]
        [TestCase(Fieldtaskordercol)]
        [TestCase(FieldlstProjectCenter)]
        [TestCase(FieldlstTaskCenter)]
        [TestCase(FieldsResourcePoolUrl)]
        [TestCase(FieldsResourceList)]
        [TestCase(FieldwpFields)]
        public void AUT_Gettasks_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_gettasksInstanceFixture, 
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
        ///     Class (<see cref="gettasks" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Gettasks_Is_Instance_Present_Test()
        {
            // Assert
            _gettasksInstanceType.ShouldNotBeNull();
            _gettasksInstance.ShouldNotBeNull();
            _gettasksInstanceFixture.ShouldNotBeNull();
            _gettasksInstance.ShouldBeAssignableTo<gettasks>();
            _gettasksInstanceFixture.ShouldBeAssignableTo<gettasks>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (gettasks) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_gettasks_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            gettasks instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _gettasksInstanceType.ShouldNotBeNull();
            _gettasksInstance.ShouldNotBeNull();
            _gettasksInstanceFixture.ShouldNotBeNull();
            _gettasksInstance.ShouldBeAssignableTo<gettasks>();
            _gettasksInstanceFixture.ShouldBeAssignableTo<gettasks>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gettasks_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gettasksInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_Page_Load_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
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
            Action currentAction = () => methodInfo.Invoke(_gettasksInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Gettasks_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPage_Load);
            var sender = this.CreateType<object>();
            var e = this.CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gettasksInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Gettasks_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Gettasks_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPage_Load);
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gettasksInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPage_Load);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gettasksInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getPercentCalc) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gettasks_getPercentCalc_Method_Call_Internally(Type[] types)
        {
            var methodgetPercentCalcPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gettasksInstance, MethodgetPercentCalc, Fixture, methodgetPercentCalcPrametersTypes);
        }

        #endregion

        #region Method Call : (getPercentCalc) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getPercentCalc_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetPercentCalc);
            var web = this.CreateType<SPWeb>();
            var methodgetPercentCalcPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfgetPercentCalc = { web };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodgetPercentCalc, methodgetPercentCalcPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gettasksInstanceFixture, parametersOfgetPercentCalc);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetPercentCalc.ShouldNotBeNull();
            parametersOfgetPercentCalc.Length.ShouldBe(1);
            methodgetPercentCalcPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getPercentCalc) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getPercentCalc_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetPercentCalc);
            var web = this.CreateType<SPWeb>();
            var methodgetPercentCalcPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfgetPercentCalc = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<gettasks, string>(_gettasksInstance, MethodgetPercentCalc, parametersOfgetPercentCalc, methodgetPercentCalcPrametersTypes);

            // Assert
            parametersOfgetPercentCalc.ShouldNotBeNull();
            parametersOfgetPercentCalc.Length.ShouldBe(1);
            methodgetPercentCalcPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getPercentCalc) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getPercentCalc_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetPercentCalc);
            var methodgetPercentCalcPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gettasksInstance, MethodgetPercentCalc, Fixture, methodgetPercentCalcPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetPercentCalcPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getPercentCalc) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getPercentCalc_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetPercentCalc);
            var methodgetPercentCalcPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gettasksInstance, MethodgetPercentCalc, Fixture, methodgetPercentCalcPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetPercentCalcPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getPercentCalc) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getPercentCalc_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetPercentCalc);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodgetPercentCalc, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gettasksInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getPercentCalc) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getPercentCalc_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetPercentCalc);
            var methodInfo = this.GetMethodInfo(MethodgetPercentCalc, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getLookupList) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gettasks_getLookupList_Method_Call_Internally(Type[] types)
        {
            var methodgetLookupListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gettasksInstance, MethodgetLookupList, Fixture, methodgetLookupListPrametersTypes);
        }

        #endregion

        #region Method Call : (getLookupList) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getLookupList_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetLookupList);
            var web = this.CreateType<SPWeb>();
            var list = this.CreateType<string>();
            var field = this.CreateType<string>();
            var methodgetLookupListPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };
            object[] parametersOfgetLookupList = { web, list, field };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodgetLookupList, methodgetLookupListPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gettasksInstanceFixture, parametersOfgetLookupList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetLookupList.ShouldNotBeNull();
            parametersOfgetLookupList.Length.ShouldBe(3);
            methodgetLookupListPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getLookupList) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getLookupList_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetLookupList);
            var web = this.CreateType<SPWeb>();
            var list = this.CreateType<string>();
            var field = this.CreateType<string>();
            var methodgetLookupListPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };
            object[] parametersOfgetLookupList = { web, list, field };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<gettasks, string>(_gettasksInstance, MethodgetLookupList, parametersOfgetLookupList, methodgetLookupListPrametersTypes);

            // Assert
            parametersOfgetLookupList.ShouldNotBeNull();
            parametersOfgetLookupList.Length.ShouldBe(3);
            methodgetLookupListPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getLookupList) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getLookupList_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetLookupList);
            var methodgetLookupListPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gettasksInstance, MethodgetLookupList, Fixture, methodgetLookupListPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetLookupListPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (getLookupList) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getLookupList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetLookupList);
            var methodgetLookupListPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gettasksInstance, MethodgetLookupList, Fixture, methodgetLookupListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetLookupListPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getLookupList) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getLookupList_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetLookupList);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodgetLookupList, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gettasksInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getLookupList) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getLookupList_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetLookupList);
            var methodInfo = this.GetMethodInfo(MethodgetLookupList, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getSingleLookup) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gettasks_getSingleLookup_Method_Call_Internally(Type[] types)
        {
            var methodgetSingleLookupPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gettasksInstance, MethodgetSingleLookup, Fixture, methodgetSingleLookupPrametersTypes);
        }

        #endregion

        #region Method Call : (getSingleLookup) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getSingleLookup_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetSingleLookup);
            var list = this.CreateType<string>();
            var field = this.CreateType<string>();
            var methodgetSingleLookupPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfgetSingleLookup = { list, field };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodgetSingleLookup, methodgetSingleLookupPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gettasksInstanceFixture, parametersOfgetSingleLookup);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetSingleLookup.ShouldNotBeNull();
            parametersOfgetSingleLookup.Length.ShouldBe(2);
            methodgetSingleLookupPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getSingleLookup) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getSingleLookup_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetSingleLookup);
            var list = this.CreateType<string>();
            var field = this.CreateType<string>();
            var methodgetSingleLookupPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfgetSingleLookup = { list, field };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<gettasks, string>(_gettasksInstance, MethodgetSingleLookup, parametersOfgetSingleLookup, methodgetSingleLookupPrametersTypes);

            // Assert
            parametersOfgetSingleLookup.ShouldNotBeNull();
            parametersOfgetSingleLookup.Length.ShouldBe(2);
            methodgetSingleLookupPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getSingleLookup) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getSingleLookup_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetSingleLookup);
            var methodgetSingleLookupPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gettasksInstance, MethodgetSingleLookup, Fixture, methodgetSingleLookupPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetSingleLookupPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (getSingleLookup) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getSingleLookup_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetSingleLookup);
            var methodgetSingleLookupPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gettasksInstance, MethodgetSingleLookup, Fixture, methodgetSingleLookupPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetSingleLookupPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getSingleLookup) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getSingleLookup_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetSingleLookup);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodgetSingleLookup, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gettasksInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getSingleLookup) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getSingleLookup_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetSingleLookup);
            var methodInfo = this.GetMethodInfo(MethodgetSingleLookup, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getSingleUser) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gettasks_getSingleUser_Method_Call_Internally(Type[] types)
        {
            var methodgetSingleUserPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gettasksInstance, MethodgetSingleUser, Fixture, methodgetSingleUserPrametersTypes);
        }

        #endregion

        #region Method Call : (getSingleUser) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getSingleUser_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetSingleUser);
            var mode = this.CreateType<string>();
            var methodgetSingleUserPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfgetSingleUser = { mode };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodgetSingleUser, methodgetSingleUserPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gettasksInstanceFixture, parametersOfgetSingleUser);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetSingleUser.ShouldNotBeNull();
            parametersOfgetSingleUser.Length.ShouldBe(1);
            methodgetSingleUserPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getSingleUser) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getSingleUser_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetSingleUser);
            var mode = this.CreateType<string>();
            var methodgetSingleUserPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfgetSingleUser = { mode };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<gettasks, string>(_gettasksInstance, MethodgetSingleUser, parametersOfgetSingleUser, methodgetSingleUserPrametersTypes);

            // Assert
            parametersOfgetSingleUser.ShouldNotBeNull();
            parametersOfgetSingleUser.Length.ShouldBe(1);
            methodgetSingleUserPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getSingleUser) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getSingleUser_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetSingleUser);
            var methodgetSingleUserPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gettasksInstance, MethodgetSingleUser, Fixture, methodgetSingleUserPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetSingleUserPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getSingleUser) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getSingleUser_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetSingleUser);
            var methodgetSingleUserPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gettasksInstance, MethodgetSingleUser, Fixture, methodgetSingleUserPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetSingleUserPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getSingleUser) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getSingleUser_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetSingleUser);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodgetSingleUser, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gettasksInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getSingleUser) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getSingleUser_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetSingleUser);
            var methodInfo = this.GetMethodInfo(MethodgetSingleUser, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getMultiUser) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gettasks_getMultiUser_Method_Call_Internally(Type[] types)
        {
            var methodgetMultiUserPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gettasksInstance, MethodgetMultiUser, Fixture, methodgetMultiUserPrametersTypes);
        }

        #endregion

        #region Method Call : (getMultiUser) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getMultiUser_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetMultiUser);
            var mode = this.CreateType<string>();
            var web = this.CreateType<SPWeb>();
            var methodgetMultiUserPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfgetMultiUser = { mode, web };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodgetMultiUser, methodgetMultiUserPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gettasksInstanceFixture, parametersOfgetMultiUser);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetMultiUser.ShouldNotBeNull();
            parametersOfgetMultiUser.Length.ShouldBe(2);
            methodgetMultiUserPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getMultiUser) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getMultiUser_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetMultiUser);
            var mode = this.CreateType<string>();
            var web = this.CreateType<SPWeb>();
            var methodgetMultiUserPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfgetMultiUser = { mode, web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<gettasks, string>(_gettasksInstance, MethodgetMultiUser, parametersOfgetMultiUser, methodgetMultiUserPrametersTypes);

            // Assert
            parametersOfgetMultiUser.ShouldNotBeNull();
            parametersOfgetMultiUser.Length.ShouldBe(2);
            methodgetMultiUserPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getMultiUser) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getMultiUser_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetMultiUser);
            var methodgetMultiUserPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gettasksInstance, MethodgetMultiUser, Fixture, methodgetMultiUserPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetMultiUserPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (getMultiUser) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getMultiUser_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetMultiUser);
            var methodgetMultiUserPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gettasksInstance, MethodgetMultiUser, Fixture, methodgetMultiUserPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetMultiUserPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getMultiUser) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getMultiUser_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetMultiUser);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodgetMultiUser, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gettasksInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getMultiUser) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getMultiUser_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetMultiUser);
            var methodInfo = this.GetMethodInfo(MethodgetMultiUser, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gettasks_getRealField_Method_Call_Internally(Type[] types)
        {
            var methodgetRealFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gettasksInstance, MethodgetRealField, Fixture, methodgetRealFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getRealField_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetRealField);
            var field = this.CreateType<SPField>();
            var methodgetRealFieldPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfgetRealField = { field };
            Exception exception, exception1;
            var methodInfo = this.GetMethodInfo(MethodgetRealField, methodgetRealFieldPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<gettasks, SPField>(_gettasksInstanceFixture, out exception1, parametersOfgetRealField);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<gettasks, SPField>(_gettasksInstance, MethodgetRealField, parametersOfgetRealField, methodgetRealFieldPrametersTypes);

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
        public void AUT_Gettasks_getRealField_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetRealField);
            var field = this.CreateType<SPField>();
            var methodgetRealFieldPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfgetRealField = { field };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodgetRealField, methodgetRealFieldPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gettasksInstanceFixture, parametersOfgetRealField);

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
        public void AUT_Gettasks_getRealField_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetRealField);
            var field = this.CreateType<SPField>();
            var methodgetRealFieldPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfgetRealField = { field };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<gettasks, SPField>(_gettasksInstance, MethodgetRealField, parametersOfgetRealField, methodgetRealFieldPrametersTypes);

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
        public void AUT_Gettasks_getRealField_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetRealField);
            var methodgetRealFieldPrametersTypes = new Type[] { typeof(SPField) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gettasksInstance, MethodgetRealField, Fixture, methodgetRealFieldPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetRealFieldPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getRealField_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetRealField);
            var methodgetRealFieldPrametersTypes = new Type[] { typeof(SPField) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gettasksInstance, MethodgetRealField, Fixture, methodgetRealFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetRealFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getRealField_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetRealField);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodgetRealField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gettasksInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getRealField_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (addHeader) (Return Type : XmlDocument) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gettasks_addHeader_Method_Call_Internally(Type[] types)
        {
            var methodaddHeaderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gettasksInstance, MethodaddHeader, Fixture, methodaddHeaderPrametersTypes);
        }

        #endregion

        #region Method Call : (addHeader) (Return Type : XmlDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_addHeader_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodaddHeader);
            var doc = this.CreateType<XmlDocument>();
            var methodaddHeaderPrametersTypes = new Type[] { typeof(XmlDocument) };
            object[] parametersOfaddHeader = { doc };
            Exception exception, exception1;
            var methodInfo = this.GetMethodInfo(MethodaddHeader, methodaddHeaderPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<gettasks, XmlDocument>(_gettasksInstanceFixture, out exception1, parametersOfaddHeader);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<gettasks, XmlDocument>(_gettasksInstance, MethodaddHeader, parametersOfaddHeader, methodaddHeaderPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfaddHeader.ShouldNotBeNull();
            parametersOfaddHeader.Length.ShouldBe(1);
            methodaddHeaderPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (addHeader) (Return Type : XmlDocument) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_addHeader_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodaddHeader);
            var doc = this.CreateType<XmlDocument>();
            var methodaddHeaderPrametersTypes = new Type[] { typeof(XmlDocument) };
            object[] parametersOfaddHeader = { doc };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<gettasks, XmlDocument>(_gettasksInstance, MethodaddHeader, parametersOfaddHeader, methodaddHeaderPrametersTypes);

            // Assert
            parametersOfaddHeader.ShouldNotBeNull();
            parametersOfaddHeader.Length.ShouldBe(1);
            methodaddHeaderPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addHeader) (Return Type : XmlDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_addHeader_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodaddHeader);
            var methodaddHeaderPrametersTypes = new Type[] { typeof(XmlDocument) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gettasksInstance, MethodaddHeader, Fixture, methodaddHeaderPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodaddHeaderPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (addHeader) (Return Type : XmlDocument) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_addHeader_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodaddHeader);
            var methodaddHeaderPrametersTypes = new Type[] { typeof(XmlDocument) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gettasksInstance, MethodaddHeader, Fixture, methodaddHeaderPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodaddHeaderPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addHeader) (Return Type : XmlDocument) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_addHeader_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodaddHeader);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodaddHeader, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gettasksInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (addHeader) (Return Type : XmlDocument) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_addHeader_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodaddHeader);
            var methodInfo = this.GetMethodInfo(MethodaddHeader, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getCellData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gettasks_getCellData_Method_Call_Internally(Type[] types)
        {
            var methodgetCellDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gettasksInstance, MethodgetCellData, Fixture, methodgetCellDataPrametersTypes);
        }

        #endregion

        #region Method Call : (getCellData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getCellData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetCellData);
            var li = this.CreateType<SPListItem>();
            var methodgetCellDataPrametersTypes = new Type[] { typeof(SPListItem) };
            object[] parametersOfgetCellData = { li };
            Exception exception, exception1;
            var methodInfo = this.GetMethodInfo(MethodgetCellData, methodgetCellDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<gettasks, string>(_gettasksInstanceFixture, out exception1, parametersOfgetCellData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<gettasks, string>(_gettasksInstance, MethodgetCellData, parametersOfgetCellData, methodgetCellDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetCellData.ShouldNotBeNull();
            parametersOfgetCellData.Length.ShouldBe(1);
            methodgetCellDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getCellData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getCellData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetCellData);
            var li = this.CreateType<SPListItem>();
            var methodgetCellDataPrametersTypes = new Type[] { typeof(SPListItem) };
            object[] parametersOfgetCellData = { li };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<gettasks, string>(_gettasksInstance, MethodgetCellData, parametersOfgetCellData, methodgetCellDataPrametersTypes);

            // Assert
            parametersOfgetCellData.ShouldNotBeNull();
            parametersOfgetCellData.Length.ShouldBe(1);
            methodgetCellDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getCellData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getCellData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetCellData);
            var methodgetCellDataPrametersTypes = new Type[] { typeof(SPListItem) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gettasksInstance, MethodgetCellData, Fixture, methodgetCellDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetCellDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getCellData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getCellData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetCellData);
            var methodgetCellDataPrametersTypes = new Type[] { typeof(SPListItem) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gettasksInstance, MethodgetCellData, Fixture, methodgetCellDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetCellDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getCellData) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getCellData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetCellData);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodgetCellData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gettasksInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getCellData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getCellData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetCellData);
            var methodInfo = this.GetMethodInfo(MethodgetCellData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getWBS) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gettasks_getWBS_Method_Call_Internally(Type[] types)
        {
            var methodgetWBSPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gettasksInstance, MethodgetWBS, Fixture, methodgetWBSPrametersTypes);
        }

        #endregion

        #region Method Call : (getWBS) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getWBS_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetWBS);
            var li = this.CreateType<SPListItem>();
            var methodgetWBSPrametersTypes = new Type[] { typeof(SPListItem) };
            object[] parametersOfgetWBS = { li };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodgetWBS, methodgetWBSPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gettasksInstanceFixture, parametersOfgetWBS);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetWBS.ShouldNotBeNull();
            parametersOfgetWBS.Length.ShouldBe(1);
            methodgetWBSPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getWBS) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getWBS_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetWBS);
            var li = this.CreateType<SPListItem>();
            var methodgetWBSPrametersTypes = new Type[] { typeof(SPListItem) };
            object[] parametersOfgetWBS = { li };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<gettasks, string>(_gettasksInstance, MethodgetWBS, parametersOfgetWBS, methodgetWBSPrametersTypes);

            // Assert
            parametersOfgetWBS.ShouldNotBeNull();
            parametersOfgetWBS.Length.ShouldBe(1);
            methodgetWBSPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getWBS) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getWBS_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetWBS);
            var methodgetWBSPrametersTypes = new Type[] { typeof(SPListItem) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gettasksInstance, MethodgetWBS, Fixture, methodgetWBSPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetWBSPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getWBS) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getWBS_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetWBS);
            var methodgetWBSPrametersTypes = new Type[] { typeof(SPListItem) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gettasksInstance, MethodgetWBS, Fixture, methodgetWBSPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetWBSPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getWBS) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getWBS_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetWBS);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodgetWBS, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gettasksInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getWBS) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gettasks_getWBS_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetWBS);
            var methodInfo = this.GetMethodInfo(MethodgetWBS, 0);
            const int parametersCount = 1;

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
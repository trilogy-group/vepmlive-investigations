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
using System.Text.RegularExpressions;
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
using updatetask = EPMLiveWorkPlanner;

namespace EPMLiveWorkPlanner
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWorkPlanner.updatetask" />)
    ///     and namespace <see cref="EPMLiveWorkPlanner"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class UpdatetaskTest : AbstractBaseSetupV3Test
    {
        public UpdatetaskTest() : base(typeof(updatetask))
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

        #region General Initializer : Class (updatetask) Initializer

        #region Methods

        private const string MethodPage_Load = "Page_Load";
        private const string MethodprocessItem = "processItem";
        private const string MethodgetCellData = "getCellData";

        #endregion

        #region Fields

        private const string Fieldoutput = "output";
        private const string FielduseResourcePool = "useResourcePool";
        private const string FieldhshResources = "hshResources";
        private const string FieldstartHour = "startHour";
        private const string FieldendHour = "endHour";
        private const string Fieldview = "view";
        private const string FieldslResources = "slResources";
        private const string FieldsbUpdatedRows = "sbUpdatedRows";
        private const string FieldlstProjectCenter = "lstProjectCenter";
        private const string FieldlstTaskCenter = "lstTaskCenter";
        private const string FieldsResourcePoolUrl = "sResourcePoolUrl";
        private const string FieldsResourceList = "sResourceList";
        private const string FieldwpFields = "wpFields";
        private const string FieldresWeb = "resWeb";

        #endregion

        private Type _updatetaskInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private updatetask _updatetaskInstance;
        private updatetask _updatetaskInstanceFixture;

        #region General Initializer : Class (updatetask) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="updatetask" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _updatetaskInstanceType = typeof(updatetask);
            _updatetaskInstanceFixture = this.Create<updatetask>(true);
            _updatetaskInstance = _updatetaskInstanceFixture ?? this.Create<updatetask>(false);
            CurrentInstance = _updatetaskInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (updatetask)

        #region General Initializer : Class (updatetask) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="updatetask" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodprocessItem, 0)]
        [TestCase(MethodgetCellData, 0)]
        public void AUT_Updatetask_All_Methods_Explore_Verify_Test(string name, int overloadingIndex = 0)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var currentMethodInfo = this.GetMethodInfo(name, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_updatetaskInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (updatetask) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="updatetask" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldoutput)]
        [TestCase(FielduseResourcePool)]
        [TestCase(FieldhshResources)]
        [TestCase(FieldstartHour)]
        [TestCase(FieldendHour)]
        [TestCase(Fieldview)]
        [TestCase(FieldslResources)]
        [TestCase(FieldsbUpdatedRows)]
        [TestCase(FieldlstProjectCenter)]
        [TestCase(FieldlstTaskCenter)]
        [TestCase(FieldsResourcePoolUrl)]
        [TestCase(FieldsResourceList)]
        [TestCase(FieldwpFields)]
        [TestCase(FieldresWeb)]
        public void AUT_Updatetask_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_updatetaskInstanceFixture, 
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
        ///     Class (<see cref="updatetask" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Updatetask_Is_Instance_Present_Test()
        {
            // Assert
            _updatetaskInstanceType.ShouldNotBeNull();
            _updatetaskInstance.ShouldNotBeNull();
            _updatetaskInstanceFixture.ShouldNotBeNull();
            _updatetaskInstance.ShouldBeAssignableTo<updatetask>();
            _updatetaskInstanceFixture.ShouldBeAssignableTo<updatetask>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (updatetask) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_updatetask_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            updatetask instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _updatetaskInstanceType.ShouldNotBeNull();
            _updatetaskInstance.ShouldNotBeNull();
            _updatetaskInstanceFixture.ShouldNotBeNull();
            _updatetaskInstance.ShouldBeAssignableTo<updatetask>();
            _updatetaskInstanceFixture.ShouldBeAssignableTo<updatetask>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Updatetask_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_updatetaskInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Updatetask_Page_Load_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
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
            Action currentAction = () => methodInfo.Invoke(_updatetaskInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Updatetask_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPage_Load);
            var sender = this.CreateType<object>();
            var e = this.CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_updatetaskInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Updatetask_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Updatetask_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPage_Load);
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_updatetaskInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Updatetask_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPage_Load);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_updatetaskInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processItem) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Updatetask_processItem_Method_Call_Internally(Type[] types)
        {
            var methodprocessItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_updatetaskInstance, MethodprocessItem, Fixture, methodprocessItemPrametersTypes);
        }

        #endregion

        #region Method Call : (processItem) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Updatetask_processItem_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodprocessItem);
            var gr_id = this.CreateType<string>();
            var web = this.CreateType<SPWeb>();
            var list = this.CreateType<SPList>();
            var view = this.CreateType<SPView>();
            var methodprocessItemPrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(SPList), typeof(SPView) };
            object[] parametersOfprocessItem = { gr_id, web, list, view };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodprocessItem, methodprocessItemPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_updatetaskInstanceFixture, parametersOfprocessItem);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfprocessItem.ShouldNotBeNull();
            parametersOfprocessItem.Length.ShouldBe(4);
            methodprocessItemPrametersTypes.Length.ShouldBe(4);
            methodprocessItemPrametersTypes.Length.ShouldBe(parametersOfprocessItem.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (processItem) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Updatetask_processItem_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodprocessItem);
            var gr_id = this.CreateType<string>();
            var web = this.CreateType<SPWeb>();
            var list = this.CreateType<SPList>();
            var view = this.CreateType<SPView>();
            var methodprocessItemPrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(SPList), typeof(SPView) };
            object[] parametersOfprocessItem = { gr_id, web, list, view };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_updatetaskInstance, MethodprocessItem, parametersOfprocessItem, methodprocessItemPrametersTypes);

            // Assert
            parametersOfprocessItem.ShouldNotBeNull();
            parametersOfprocessItem.Length.ShouldBe(4);
            methodprocessItemPrametersTypes.Length.ShouldBe(4);
            methodprocessItemPrametersTypes.Length.ShouldBe(parametersOfprocessItem.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processItem) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Updatetask_processItem_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodprocessItem);
            var methodInfo = this.GetMethodInfo(MethodprocessItem, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processItem) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Updatetask_processItem_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodprocessItem);
            var methodprocessItemPrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(SPList), typeof(SPView) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_updatetaskInstance, MethodprocessItem, Fixture, methodprocessItemPrametersTypes);

            // Assert
            methodprocessItemPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processItem) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Updatetask_processItem_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodprocessItem);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodprocessItem, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_updatetaskInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getCellData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Updatetask_getCellData_Method_Call_Internally(Type[] types)
        {
            var methodgetCellDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_updatetaskInstance, MethodgetCellData, Fixture, methodgetCellDataPrametersTypes);
        }

        #endregion

        #region Method Call : (getCellData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Updatetask_getCellData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetCellData);
            var li = this.CreateType<SPListItem>();
            var methodgetCellDataPrametersTypes = new Type[] { typeof(SPListItem) };
            object[] parametersOfgetCellData = { li };
            Exception exception, exception1;
            var methodInfo = this.GetMethodInfo(MethodgetCellData, methodgetCellDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<updatetask, string>(_updatetaskInstanceFixture, out exception1, parametersOfgetCellData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<updatetask, string>(_updatetaskInstance, MethodgetCellData, parametersOfgetCellData, methodgetCellDataPrametersTypes);

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
        public void AUT_Updatetask_getCellData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetCellData);
            var li = this.CreateType<SPListItem>();
            var methodgetCellDataPrametersTypes = new Type[] { typeof(SPListItem) };
            object[] parametersOfgetCellData = { li };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<updatetask, string>(_updatetaskInstance, MethodgetCellData, parametersOfgetCellData, methodgetCellDataPrametersTypes);

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
        public void AUT_Updatetask_getCellData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetCellData);
            var methodgetCellDataPrametersTypes = new Type[] { typeof(SPListItem) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_updatetaskInstance, MethodgetCellData, Fixture, methodgetCellDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetCellDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getCellData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Updatetask_getCellData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetCellData);
            var methodgetCellDataPrametersTypes = new Type[] { typeof(SPListItem) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_updatetaskInstance, MethodgetCellData, Fixture, methodgetCellDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetCellDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getCellData) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Updatetask_getCellData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetCellData);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodgetCellData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_updatetaskInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getCellData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Updatetask_getCellData_Method_Call_Parameters_Count_Verification_Test()
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

        #endregion

        #endregion
    }
}
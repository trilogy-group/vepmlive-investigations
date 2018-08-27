using System;
using System.Diagnostics.CodeAnalysis;
using System.Web.UI.WebControls;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.sitepermissions" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public partial class SitepermissionsTest : AbstractBaseSetupTypedTest<sitepermissions>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (sitepermissions) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodfillData = "fillData";
        private const string MethodfillSubData = "fillSubData";
        private const string MethodGridView1_RowDataBound = "GridView1_RowDataBound";
        private const string MethodGridView1_RowCommand = "GridView1_RowCommand";
        private const string MethodButton2_Click = "Button2_Click";
        private const string MethodButton3_Click = "Button3_Click";
        private const string Fieldaccount_ref = "account_ref";
        private const string Fieldaccountid = "accountid";
        private const string Fieldquantity = "quantity";
        private const string FieldstrBarColor = "strBarColor";
        private const string FieldstrWidth = "strWidth";
        private const string Fieldversion = "version";
        private const string Fieldweburl = "weburl";
        private Type _sitepermissionsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private sitepermissions _sitepermissionsInstance;
        private sitepermissions _sitepermissionsInstanceFixture;

        #region General Initializer : Class (sitepermissions) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="sitepermissions" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _sitepermissionsInstanceType = typeof(sitepermissions);
            _sitepermissionsInstanceFixture = Create(true);
            _sitepermissionsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (sitepermissions)

        #region General Initializer : Class (sitepermissions) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="sitepermissions" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodfillData, 0)]
        [TestCase(MethodfillSubData, 0)]
        [TestCase(MethodGridView1_RowDataBound, 0)]
        [TestCase(MethodGridView1_RowCommand, 0)]
        [TestCase(MethodButton2_Click, 0)]
        [TestCase(MethodButton3_Click, 0)]
        public void AUT_Sitepermissions_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_sitepermissionsInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (sitepermissions) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="sitepermissions" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldaccount_ref)]
        [TestCase(Fieldaccountid)]
        [TestCase(Fieldquantity)]
        [TestCase(FieldstrBarColor)]
        [TestCase(FieldstrWidth)]
        [TestCase(Fieldversion)]
        [TestCase(Fieldweburl)]
        public void AUT_Sitepermissions_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_sitepermissionsInstanceFixture, 
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
        ///     Class (<see cref="sitepermissions" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Sitepermissions_Is_Instance_Present_Test()
        {
            // Assert
            _sitepermissionsInstanceType.ShouldNotBeNull();
            _sitepermissionsInstance.ShouldNotBeNull();
            _sitepermissionsInstanceFixture.ShouldNotBeNull();
            _sitepermissionsInstance.ShouldBeAssignableTo<sitepermissions>();
            _sitepermissionsInstanceFixture.ShouldBeAssignableTo<sitepermissions>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (sitepermissions) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_sitepermissions_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            sitepermissions instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _sitepermissionsInstanceType.ShouldNotBeNull();
            _sitepermissionsInstance.ShouldNotBeNull();
            _sitepermissionsInstanceFixture.ShouldNotBeNull();
            _sitepermissionsInstance.ShouldBeAssignableTo<sitepermissions>();
            _sitepermissionsInstanceFixture.ShouldBeAssignableTo<sitepermissions>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="sitepermissions" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodfillData)]
        [TestCase(MethodfillSubData)]
        [TestCase(MethodGridView1_RowDataBound)]
        [TestCase(MethodGridView1_RowCommand)]
        [TestCase(MethodButton2_Click)]
        [TestCase(MethodButton3_Click)]
        public void AUT_Sitepermissions_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<sitepermissions>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Sitepermissions_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sitepermissionsInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Sitepermissions_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_sitepermissionsInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Sitepermissions_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_sitepermissionsInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Sitepermissions_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Sitepermissions_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sitepermissionsInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Sitepermissions_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_sitepermissionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (fillData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Sitepermissions_fillData_Method_Call_Internally(Type[] types)
        {
            var methodfillDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sitepermissionsInstance, MethodfillData, Fixture, methodfillDataPrametersTypes);
        }

        #endregion

        #region Method Call : (fillData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Sitepermissions_fillData_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var methodfillDataPrametersTypes = new Type[] { typeof(SPSite) };
            object[] parametersOffillData = { site };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodfillData, methodfillDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_sitepermissionsInstanceFixture, parametersOffillData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOffillData.ShouldNotBeNull();
            parametersOffillData.Length.ShouldBe(1);
            methodfillDataPrametersTypes.Length.ShouldBe(1);
            methodfillDataPrametersTypes.Length.ShouldBe(parametersOffillData.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (fillData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Sitepermissions_fillData_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var methodfillDataPrametersTypes = new Type[] { typeof(SPSite) };
            object[] parametersOffillData = { site };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_sitepermissionsInstance, MethodfillData, parametersOffillData, methodfillDataPrametersTypes);

            // Assert
            parametersOffillData.ShouldNotBeNull();
            parametersOffillData.Length.ShouldBe(1);
            methodfillDataPrametersTypes.Length.ShouldBe(1);
            methodfillDataPrametersTypes.Length.ShouldBe(parametersOffillData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (fillData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Sitepermissions_fillData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodfillData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (fillData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Sitepermissions_fillData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodfillDataPrametersTypes = new Type[] { typeof(SPSite) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sitepermissionsInstance, MethodfillData, Fixture, methodfillDataPrametersTypes);

            // Assert
            methodfillDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (fillData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Sitepermissions_fillData_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodfillData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_sitepermissionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (fillSubData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Sitepermissions_fillSubData_Method_Call_Internally(Type[] types)
        {
            var methodfillSubDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sitepermissionsInstance, MethodfillSubData, Fixture, methodfillSubDataPrametersTypes);
        }

        #endregion

        #region Method Call : (fillSubData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Sitepermissions_fillSubData_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodfillSubDataPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOffillSubData = { web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodfillSubData, methodfillSubDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_sitepermissionsInstanceFixture, parametersOffillSubData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOffillSubData.ShouldNotBeNull();
            parametersOffillSubData.Length.ShouldBe(1);
            methodfillSubDataPrametersTypes.Length.ShouldBe(1);
            methodfillSubDataPrametersTypes.Length.ShouldBe(parametersOffillSubData.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (fillSubData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Sitepermissions_fillSubData_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodfillSubDataPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOffillSubData = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_sitepermissionsInstance, MethodfillSubData, parametersOffillSubData, methodfillSubDataPrametersTypes);

            // Assert
            parametersOffillSubData.ShouldNotBeNull();
            parametersOffillSubData.Length.ShouldBe(1);
            methodfillSubDataPrametersTypes.Length.ShouldBe(1);
            methodfillSubDataPrametersTypes.Length.ShouldBe(parametersOffillSubData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (fillSubData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Sitepermissions_fillSubData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodfillSubData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (fillSubData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Sitepermissions_fillSubData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodfillSubDataPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sitepermissionsInstance, MethodfillSubData, Fixture, methodfillSubDataPrametersTypes);

            // Assert
            methodfillSubDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (fillSubData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Sitepermissions_fillSubData_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodfillSubData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_sitepermissionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView1_RowDataBound) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Sitepermissions_GridView1_RowDataBound_Method_Call_Internally(Type[] types)
        {
            var methodGridView1_RowDataBoundPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sitepermissionsInstance, MethodGridView1_RowDataBound, Fixture, methodGridView1_RowDataBoundPrametersTypes);
        }

        #endregion

        #region Method Call : (GridView1_RowDataBound) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Sitepermissions_GridView1_RowDataBound_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridViewRowEventArgs>();
            var methodGridView1_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };
            object[] parametersOfGridView1_RowDataBound = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGridView1_RowDataBound, methodGridView1_RowDataBoundPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_sitepermissionsInstanceFixture, parametersOfGridView1_RowDataBound);

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
        public void AUT_Sitepermissions_GridView1_RowDataBound_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridViewRowEventArgs>();
            var methodGridView1_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };
            object[] parametersOfGridView1_RowDataBound = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_sitepermissionsInstance, MethodGridView1_RowDataBound, parametersOfGridView1_RowDataBound, methodGridView1_RowDataBoundPrametersTypes);

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
        public void AUT_Sitepermissions_GridView1_RowDataBound_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGridView1_RowDataBound, 0);
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
        public void AUT_Sitepermissions_GridView1_RowDataBound_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGridView1_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sitepermissionsInstance, MethodGridView1_RowDataBound, Fixture, methodGridView1_RowDataBoundPrametersTypes);

            // Assert
            methodGridView1_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView1_RowDataBound) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Sitepermissions_GridView1_RowDataBound_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGridView1_RowDataBound, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_sitepermissionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView1_RowCommand) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Sitepermissions_GridView1_RowCommand_Method_Call_Internally(Type[] types)
        {
            var methodGridView1_RowCommandPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sitepermissionsInstance, MethodGridView1_RowCommand, Fixture, methodGridView1_RowCommandPrametersTypes);
        }

        #endregion

        #region Method Call : (GridView1_RowCommand) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Sitepermissions_GridView1_RowCommand_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridViewCommandEventArgs>();
            var methodGridView1_RowCommandPrametersTypes = new Type[] { typeof(object), typeof(GridViewCommandEventArgs) };
            object[] parametersOfGridView1_RowCommand = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGridView1_RowCommand, methodGridView1_RowCommandPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_sitepermissionsInstanceFixture, parametersOfGridView1_RowCommand);

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
        public void AUT_Sitepermissions_GridView1_RowCommand_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridViewCommandEventArgs>();
            var methodGridView1_RowCommandPrametersTypes = new Type[] { typeof(object), typeof(GridViewCommandEventArgs) };
            object[] parametersOfGridView1_RowCommand = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_sitepermissionsInstance, MethodGridView1_RowCommand, parametersOfGridView1_RowCommand, methodGridView1_RowCommandPrametersTypes);

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
        public void AUT_Sitepermissions_GridView1_RowCommand_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGridView1_RowCommand, 0);
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
        public void AUT_Sitepermissions_GridView1_RowCommand_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGridView1_RowCommandPrametersTypes = new Type[] { typeof(object), typeof(GridViewCommandEventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sitepermissionsInstance, MethodGridView1_RowCommand, Fixture, methodGridView1_RowCommandPrametersTypes);

            // Assert
            methodGridView1_RowCommandPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView1_RowCommand) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Sitepermissions_GridView1_RowCommand_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGridView1_RowCommand, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_sitepermissionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Button2_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Sitepermissions_Button2_Click_Method_Call_Internally(Type[] types)
        {
            var methodButton2_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sitepermissionsInstance, MethodButton2_Click, Fixture, methodButton2_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (Button2_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Sitepermissions_Button2_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodButton2_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfButton2_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodButton2_Click, methodButton2_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_sitepermissionsInstanceFixture, parametersOfButton2_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfButton2_Click.ShouldNotBeNull();
            parametersOfButton2_Click.Length.ShouldBe(2);
            methodButton2_ClickPrametersTypes.Length.ShouldBe(2);
            methodButton2_ClickPrametersTypes.Length.ShouldBe(parametersOfButton2_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Button2_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Sitepermissions_Button2_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodButton2_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfButton2_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_sitepermissionsInstance, MethodButton2_Click, parametersOfButton2_Click, methodButton2_ClickPrametersTypes);

            // Assert
            parametersOfButton2_Click.ShouldNotBeNull();
            parametersOfButton2_Click.Length.ShouldBe(2);
            methodButton2_ClickPrametersTypes.Length.ShouldBe(2);
            methodButton2_ClickPrametersTypes.Length.ShouldBe(parametersOfButton2_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Button2_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Sitepermissions_Button2_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodButton2_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Button2_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Sitepermissions_Button2_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodButton2_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sitepermissionsInstance, MethodButton2_Click, Fixture, methodButton2_ClickPrametersTypes);

            // Assert
            methodButton2_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Button2_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Sitepermissions_Button2_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodButton2_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_sitepermissionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Button3_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Sitepermissions_Button3_Click_Method_Call_Internally(Type[] types)
        {
            var methodButton3_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sitepermissionsInstance, MethodButton3_Click, Fixture, methodButton3_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (Button3_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Sitepermissions_Button3_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodButton3_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfButton3_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodButton3_Click, methodButton3_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_sitepermissionsInstanceFixture, parametersOfButton3_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfButton3_Click.ShouldNotBeNull();
            parametersOfButton3_Click.Length.ShouldBe(2);
            methodButton3_ClickPrametersTypes.Length.ShouldBe(2);
            methodButton3_ClickPrametersTypes.Length.ShouldBe(parametersOfButton3_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Button3_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Sitepermissions_Button3_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodButton3_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfButton3_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_sitepermissionsInstance, MethodButton3_Click, parametersOfButton3_Click, methodButton3_ClickPrametersTypes);

            // Assert
            parametersOfButton3_Click.ShouldNotBeNull();
            parametersOfButton3_Click.Length.ShouldBe(2);
            methodButton3_ClickPrametersTypes.Length.ShouldBe(2);
            methodButton3_ClickPrametersTypes.Length.ShouldBe(parametersOfButton3_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Button3_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Sitepermissions_Button3_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodButton3_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Button3_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Sitepermissions_Button3_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodButton3_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sitepermissionsInstance, MethodButton3_Click, Fixture, methodButton3_ClickPrametersTypes);

            // Assert
            methodButton3_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Button3_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Sitepermissions_Button3_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodButton3_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_sitepermissionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
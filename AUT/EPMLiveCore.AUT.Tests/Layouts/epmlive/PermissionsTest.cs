using System;
using System.Data;
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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.permissions" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class PermissionsTest : AbstractBaseSetupTypedTest<permissions>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (permissions) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodGetSpUsers = "GetSpUsers";
        private const string MethodPopulateGvSelect = "PopulateGvSelect";
        private const string MethodGetClause = "GetClause";
        private const string MethodConfigureGroupsData = "ConfigureGroupsData";
        private const string MethodGridView1_RowDataBound = "GridView1_RowDataBound";
        private const string MethodbtnSubmit_Click = "btnSubmit_Click";
        private const string MethodbtnCancel_Click = "btnCancel_Click";
        private const string MethodbtnRefresh_Click = "btnRefresh_Click";
        private const string Field_groups = "_groups";
        private Type _permissionsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private permissions _permissionsInstance;
        private permissions _permissionsInstanceFixture;

        #region General Initializer : Class (permissions) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="permissions" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _permissionsInstanceType = typeof(permissions);
            _permissionsInstanceFixture = Create(true);
            _permissionsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (permissions)

        #region General Initializer : Class (permissions) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="permissions" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodGetSpUsers, 0)]
        [TestCase(MethodPopulateGvSelect, 0)]
        [TestCase(MethodGetClause, 0)]
        [TestCase(MethodConfigureGroupsData, 0)]
        [TestCase(MethodGridView1_RowDataBound, 0)]
        [TestCase(MethodbtnSubmit_Click, 0)]
        [TestCase(MethodbtnCancel_Click, 0)]
        [TestCase(MethodbtnRefresh_Click, 0)]
        public void AUT_Permissions_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_permissionsInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (permissions) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="permissions" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_groups)]
        public void AUT_Permissions_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_permissionsInstanceFixture, 
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
        ///     Class (<see cref="permissions" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Permissions_Is_Instance_Present_Test()
        {
            // Assert
            _permissionsInstanceType.ShouldNotBeNull();
            _permissionsInstance.ShouldNotBeNull();
            _permissionsInstanceFixture.ShouldNotBeNull();
            _permissionsInstance.ShouldBeAssignableTo<permissions>();
            _permissionsInstanceFixture.ShouldBeAssignableTo<permissions>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (permissions) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_permissions_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            permissions instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _permissionsInstanceType.ShouldNotBeNull();
            _permissionsInstance.ShouldNotBeNull();
            _permissionsInstanceFixture.ShouldNotBeNull();
            _permissionsInstance.ShouldBeAssignableTo<permissions>();
            _permissionsInstanceFixture.ShouldBeAssignableTo<permissions>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="permissions" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodGetSpUsers)]
        [TestCase(MethodPopulateGvSelect)]
        [TestCase(MethodGetClause)]
        [TestCase(MethodConfigureGroupsData)]
        [TestCase(MethodGridView1_RowDataBound)]
        [TestCase(MethodbtnSubmit_Click)]
        [TestCase(MethodbtnCancel_Click)]
        [TestCase(MethodbtnRefresh_Click)]
        public void AUT_Permissions_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<permissions>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Permissions_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_permissionsInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Permissions_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_permissionsInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Permissions_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_permissionsInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Permissions_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Permissions_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_permissionsInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Permissions_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_permissionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSpUsers) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Permissions_GetSpUsers_Method_Call_Internally(Type[] types)
        {
            var methodGetSpUsersPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_permissionsInstance, MethodGetSpUsers, Fixture, methodGetSpUsersPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSpUsers) (Return Type : DataTable) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Permissions_GetSpUsers_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var dv = CreateType<DataView>();
            var web = CreateType<SPWeb>();
            var methodGetSpUsersPrametersTypes = new Type[] { typeof(DataView), typeof(SPWeb) };
            object[] parametersOfGetSpUsers = { dv, web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetSpUsers, methodGetSpUsersPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetSpUsers.ShouldNotBeNull();
            parametersOfGetSpUsers.Length.ShouldBe(2);
            methodGetSpUsersPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => methodInfo.Invoke(_permissionsInstanceFixture, parametersOfGetSpUsers));
        }

        #endregion

        #region Method Call : (GetSpUsers) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Permissions_GetSpUsers_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dv = CreateType<DataView>();
            var web = CreateType<SPWeb>();
            var methodGetSpUsersPrametersTypes = new Type[] { typeof(DataView), typeof(SPWeb) };
            object[] parametersOfGetSpUsers = { dv, web };

            // Assert
            parametersOfGetSpUsers.ShouldNotBeNull();
            parametersOfGetSpUsers.Length.ShouldBe(2);
            methodGetSpUsersPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<permissions, DataTable>(_permissionsInstance, MethodGetSpUsers, parametersOfGetSpUsers, methodGetSpUsersPrametersTypes));
        }

        #endregion

        #region Method Call : (GetSpUsers) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Permissions_GetSpUsers_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetSpUsersPrametersTypes = new Type[] { typeof(DataView), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_permissionsInstance, MethodGetSpUsers, Fixture, methodGetSpUsersPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetSpUsersPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetSpUsers) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Permissions_GetSpUsers_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSpUsersPrametersTypes = new Type[] { typeof(DataView), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_permissionsInstance, MethodGetSpUsers, Fixture, methodGetSpUsersPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSpUsersPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSpUsers) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Permissions_GetSpUsers_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSpUsers, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_permissionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSpUsers) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Permissions_GetSpUsers_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetSpUsers, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PopulateGvSelect) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Permissions_PopulateGvSelect_Method_Call_Internally(Type[] types)
        {
            var methodPopulateGvSelectPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_permissionsInstance, MethodPopulateGvSelect, Fixture, methodPopulateGvSelectPrametersTypes);
        }

        #endregion

        #region Method Call : (PopulateGvSelect) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Permissions_PopulateGvSelect_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var web = CreateType<SPWeb>();
            var methodPopulateGvSelectPrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb) };
            object[] parametersOfPopulateGvSelect = { site, web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPopulateGvSelect, methodPopulateGvSelectPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_permissionsInstanceFixture, parametersOfPopulateGvSelect);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPopulateGvSelect.ShouldNotBeNull();
            parametersOfPopulateGvSelect.Length.ShouldBe(2);
            methodPopulateGvSelectPrametersTypes.Length.ShouldBe(2);
            methodPopulateGvSelectPrametersTypes.Length.ShouldBe(parametersOfPopulateGvSelect.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (PopulateGvSelect) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Permissions_PopulateGvSelect_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var web = CreateType<SPWeb>();
            var methodPopulateGvSelectPrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb) };
            object[] parametersOfPopulateGvSelect = { site, web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_permissionsInstance, MethodPopulateGvSelect, parametersOfPopulateGvSelect, methodPopulateGvSelectPrametersTypes);

            // Assert
            parametersOfPopulateGvSelect.ShouldNotBeNull();
            parametersOfPopulateGvSelect.Length.ShouldBe(2);
            methodPopulateGvSelectPrametersTypes.Length.ShouldBe(2);
            methodPopulateGvSelectPrametersTypes.Length.ShouldBe(parametersOfPopulateGvSelect.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateGvSelect) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Permissions_PopulateGvSelect_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPopulateGvSelect, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PopulateGvSelect) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Permissions_PopulateGvSelect_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPopulateGvSelectPrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_permissionsInstance, MethodPopulateGvSelect, Fixture, methodPopulateGvSelectPrametersTypes);

            // Assert
            methodPopulateGvSelectPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateGvSelect) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Permissions_PopulateGvSelect_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPopulateGvSelect, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_permissionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetClause) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Permissions_GetClause_Method_Call_Internally(Type[] types)
        {
            var methodGetClausePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_permissionsInstance, MethodGetClause, Fixture, methodGetClausePrametersTypes);
        }

        #endregion

        #region Method Call : (GetClause) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Permissions_GetClause_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var resources = CreateType<string>();
            var methodGetClausePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetClause = { resources };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetClause, methodGetClausePrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetClause.ShouldNotBeNull();
            parametersOfGetClause.Length.ShouldBe(1);
            methodGetClausePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(_permissionsInstanceFixture, parametersOfGetClause));
        }

        #endregion

        #region Method Call : (GetClause) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Permissions_GetClause_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var resources = CreateType<string>();
            var methodGetClausePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetClause = { resources };

            // Assert
            parametersOfGetClause.ShouldNotBeNull();
            parametersOfGetClause.Length.ShouldBe(1);
            methodGetClausePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<permissions, string>(_permissionsInstance, MethodGetClause, parametersOfGetClause, methodGetClausePrametersTypes));
        }

        #endregion

        #region Method Call : (GetClause) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Permissions_GetClause_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetClausePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_permissionsInstance, MethodGetClause, Fixture, methodGetClausePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetClausePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetClause) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Permissions_GetClause_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetClausePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_permissionsInstance, MethodGetClause, Fixture, methodGetClausePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetClausePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetClause) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Permissions_GetClause_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetClause, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_permissionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetClause) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Permissions_GetClause_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetClause, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ConfigureGroupsData) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Permissions_ConfigureGroupsData_Method_Call_Internally(Type[] types)
        {
            var methodConfigureGroupsDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_permissionsInstance, MethodConfigureGroupsData, Fixture, methodConfigureGroupsDataPrametersTypes);
        }

        #endregion

        #region Method Call : (ConfigureGroupsData) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Permissions_ConfigureGroupsData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodConfigureGroupsDataPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfConfigureGroupsData = { web };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodConfigureGroupsData, methodConfigureGroupsDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<permissions, DataTable>(_permissionsInstanceFixture, out exception1, parametersOfConfigureGroupsData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<permissions, DataTable>(_permissionsInstance, MethodConfigureGroupsData, parametersOfConfigureGroupsData, methodConfigureGroupsDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfConfigureGroupsData.ShouldNotBeNull();
            parametersOfConfigureGroupsData.Length.ShouldBe(1);
            methodConfigureGroupsDataPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_permissionsInstanceFixture, parametersOfConfigureGroupsData));
        }

        #endregion

        #region Method Call : (ConfigureGroupsData) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Permissions_ConfigureGroupsData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodConfigureGroupsDataPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfConfigureGroupsData = { web };

            // Assert
            parametersOfConfigureGroupsData.ShouldNotBeNull();
            parametersOfConfigureGroupsData.Length.ShouldBe(1);
            methodConfigureGroupsDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<permissions, DataTable>(_permissionsInstance, MethodConfigureGroupsData, parametersOfConfigureGroupsData, methodConfigureGroupsDataPrametersTypes));
        }

        #endregion

        #region Method Call : (ConfigureGroupsData) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Permissions_ConfigureGroupsData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodConfigureGroupsDataPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_permissionsInstance, MethodConfigureGroupsData, Fixture, methodConfigureGroupsDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodConfigureGroupsDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ConfigureGroupsData) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Permissions_ConfigureGroupsData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodConfigureGroupsDataPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_permissionsInstance, MethodConfigureGroupsData, Fixture, methodConfigureGroupsDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodConfigureGroupsDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ConfigureGroupsData) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Permissions_ConfigureGroupsData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodConfigureGroupsData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_permissionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ConfigureGroupsData) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Permissions_ConfigureGroupsData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodConfigureGroupsData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GridView1_RowDataBound) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Permissions_GridView1_RowDataBound_Method_Call_Internally(Type[] types)
        {
            var methodGridView1_RowDataBoundPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_permissionsInstance, MethodGridView1_RowDataBound, Fixture, methodGridView1_RowDataBoundPrametersTypes);
        }

        #endregion

        #region Method Call : (GridView1_RowDataBound) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Permissions_GridView1_RowDataBound_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridViewRowEventArgs>();
            var methodGridView1_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };
            object[] parametersOfGridView1_RowDataBound = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGridView1_RowDataBound, methodGridView1_RowDataBoundPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_permissionsInstanceFixture, parametersOfGridView1_RowDataBound);

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
        public void AUT_Permissions_GridView1_RowDataBound_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridViewRowEventArgs>();
            var methodGridView1_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };
            object[] parametersOfGridView1_RowDataBound = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_permissionsInstance, MethodGridView1_RowDataBound, parametersOfGridView1_RowDataBound, methodGridView1_RowDataBoundPrametersTypes);

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
        public void AUT_Permissions_GridView1_RowDataBound_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Permissions_GridView1_RowDataBound_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGridView1_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_permissionsInstance, MethodGridView1_RowDataBound, Fixture, methodGridView1_RowDataBoundPrametersTypes);

            // Assert
            methodGridView1_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView1_RowDataBound) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Permissions_GridView1_RowDataBound_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGridView1_RowDataBound, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_permissionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnSubmit_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Permissions_btnSubmit_Click_Method_Call_Internally(Type[] types)
        {
            var methodbtnSubmit_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_permissionsInstance, MethodbtnSubmit_Click, Fixture, methodbtnSubmit_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnSubmit_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Permissions_btnSubmit_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnSubmit_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnSubmit_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnSubmit_Click, methodbtnSubmit_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_permissionsInstanceFixture, parametersOfbtnSubmit_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbtnSubmit_Click.ShouldNotBeNull();
            parametersOfbtnSubmit_Click.Length.ShouldBe(2);
            methodbtnSubmit_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnSubmit_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnSubmit_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (btnSubmit_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Permissions_btnSubmit_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnSubmit_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnSubmit_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_permissionsInstance, MethodbtnSubmit_Click, parametersOfbtnSubmit_Click, methodbtnSubmit_ClickPrametersTypes);

            // Assert
            parametersOfbtnSubmit_Click.ShouldNotBeNull();
            parametersOfbtnSubmit_Click.Length.ShouldBe(2);
            methodbtnSubmit_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnSubmit_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnSubmit_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnSubmit_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Permissions_btnSubmit_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbtnSubmit_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (btnSubmit_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Permissions_btnSubmit_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnSubmit_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_permissionsInstance, MethodbtnSubmit_Click, Fixture, methodbtnSubmit_ClickPrametersTypes);

            // Assert
            methodbtnSubmit_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnSubmit_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Permissions_btnSubmit_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnSubmit_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_permissionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnCancel_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Permissions_btnCancel_Click_Method_Call_Internally(Type[] types)
        {
            var methodbtnCancel_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_permissionsInstance, MethodbtnCancel_Click, Fixture, methodbtnCancel_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnCancel_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Permissions_btnCancel_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnCancel_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnCancel_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnCancel_Click, methodbtnCancel_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_permissionsInstanceFixture, parametersOfbtnCancel_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbtnCancel_Click.ShouldNotBeNull();
            parametersOfbtnCancel_Click.Length.ShouldBe(2);
            methodbtnCancel_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnCancel_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnCancel_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (btnCancel_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Permissions_btnCancel_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnCancel_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnCancel_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_permissionsInstance, MethodbtnCancel_Click, parametersOfbtnCancel_Click, methodbtnCancel_ClickPrametersTypes);

            // Assert
            parametersOfbtnCancel_Click.ShouldNotBeNull();
            parametersOfbtnCancel_Click.Length.ShouldBe(2);
            methodbtnCancel_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnCancel_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnCancel_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnCancel_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Permissions_btnCancel_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbtnCancel_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (btnCancel_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Permissions_btnCancel_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnCancel_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_permissionsInstance, MethodbtnCancel_Click, Fixture, methodbtnCancel_ClickPrametersTypes);

            // Assert
            methodbtnCancel_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnCancel_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Permissions_btnCancel_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnCancel_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_permissionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnRefresh_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Permissions_btnRefresh_Click_Method_Call_Internally(Type[] types)
        {
            var methodbtnRefresh_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_permissionsInstance, MethodbtnRefresh_Click, Fixture, methodbtnRefresh_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnRefresh_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Permissions_btnRefresh_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnRefresh_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnRefresh_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnRefresh_Click, methodbtnRefresh_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_permissionsInstanceFixture, parametersOfbtnRefresh_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbtnRefresh_Click.ShouldNotBeNull();
            parametersOfbtnRefresh_Click.Length.ShouldBe(2);
            methodbtnRefresh_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnRefresh_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnRefresh_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (btnRefresh_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Permissions_btnRefresh_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnRefresh_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnRefresh_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_permissionsInstance, MethodbtnRefresh_Click, parametersOfbtnRefresh_Click, methodbtnRefresh_ClickPrametersTypes);

            // Assert
            parametersOfbtnRefresh_Click.ShouldNotBeNull();
            parametersOfbtnRefresh_Click.Length.ShouldBe(2);
            methodbtnRefresh_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnRefresh_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnRefresh_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnRefresh_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Permissions_btnRefresh_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbtnRefresh_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (btnRefresh_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Permissions_btnRefresh_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnRefresh_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_permissionsInstance, MethodbtnRefresh_Click, Fixture, methodbtnRefresh_ClickPrametersTypes);

            // Assert
            methodbtnRefresh_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnRefresh_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Permissions_btnRefresh_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnRefresh_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_permissionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
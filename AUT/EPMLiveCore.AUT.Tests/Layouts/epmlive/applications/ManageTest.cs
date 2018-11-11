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

namespace EPMLiveCore.Layouts.epmlive.applications
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Layouts.epmlive.applications.Manage" />)
    ///     and namespace <see cref="EPMLiveCore.Layouts.epmlive.applications"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public partial class ManageTest : AbstractBaseSetupTypedTest<Manage>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Manage) Initializer

        private const string MethodGetProperty = "GetProperty";
        private const string MethodPage_Load = "Page_Load";
        private const string MethodCheckForQuickLaunchField = "CheckForQuickLaunchField";
        private const string MethodGetDataTable = "GetDataTable";
        private const string MethodLoadCustom = "LoadCustom";
        private const string MethodSetCustomOrder = "SetCustomOrder";
        private const string MethodlnkSaveOrder_OnClicked = "lnkSaveOrder_OnClicked";
        private const string MethodGridView_PreRender = "GridView_PreRender";
        private const string MethodGridView_RowDataBound = "GridView_RowDataBound";
        private const string MethodddlOrder_SelectedIndexChanged = "ddlOrder_SelectedIndexChanged";
        private const string MethodGridView_RowCommand = "GridView_RowCommand";
        private const string MethodHandleNAcase = "HandleNAcase";
        private const string MethodStripHTML = "StripHTML";
        private const string MethodDelButton = "DelButton";
        private const string MethodEditButton = "EditButton";
        private const string MethodManageApps = "ManageApps";
        private const string MethodQLButton = "QLButton";
        private const string MethodTNButton = "TNButton";
        private const string FieldsWebUrl = "sWebUrl";
        private const string FieldsFullWebUrl = "sFullWebUrl";
        private const string FieldINSTALLED_APPS = "INSTALLED_APPS";
        private Type _manageInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Manage _manageInstance;
        private Manage _manageInstanceFixture;

        #region General Initializer : Class (Manage) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Manage" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _manageInstanceType = typeof(Manage);
            _manageInstanceFixture = Create(true);
            _manageInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Manage)

        #region General Initializer : Class (Manage) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Manage" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(MethodGetProperty, 0)]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodCheckForQuickLaunchField, 0)]
        [TestCase(MethodGetDataTable, 0)]
        [TestCase(MethodLoadCustom, 0)]
        [TestCase(MethodSetCustomOrder, 0)]
        [TestCase(MethodlnkSaveOrder_OnClicked, 0)]
        [TestCase(MethodGridView_PreRender, 0)]
        [TestCase(MethodGridView_RowDataBound, 0)]
        [TestCase(MethodddlOrder_SelectedIndexChanged, 0)]
        [TestCase(MethodGridView_RowCommand, 0)]
        [TestCase(MethodHandleNAcase, 0)]
        [TestCase(MethodStripHTML, 0)]
        [TestCase(MethodDelButton, 0)]
        [TestCase(MethodEditButton, 0)]
        [TestCase(MethodManageApps, 0)]
        [TestCase(MethodQLButton, 0)]
        [TestCase(MethodTNButton, 0)]
        public void AUT_Manage_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_manageInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Manage) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Manage" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldsWebUrl)]
        [TestCase(FieldsFullWebUrl)]
        [TestCase(FieldINSTALLED_APPS)]
        public void AUT_Manage_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_manageInstanceFixture, 
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
        ///     Class (<see cref="Manage" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_Manage_Is_Instance_Present_Test()
        {
            // Assert
            _manageInstanceType.ShouldNotBeNull();
            _manageInstance.ShouldNotBeNull();
            _manageInstanceFixture.ShouldNotBeNull();
            _manageInstance.ShouldBeAssignableTo<Manage>();
            _manageInstanceFixture.ShouldBeAssignableTo<Manage>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Manage) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_Manage_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Manage instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _manageInstanceType.ShouldNotBeNull();
            _manageInstance.ShouldNotBeNull();
            _manageInstanceFixture.ShouldNotBeNull();
            _manageInstance.ShouldBeAssignableTo<Manage>();
            _manageInstanceFixture.ShouldBeAssignableTo<Manage>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="Manage" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        [TestCase(MethodStripHTML)]
        public void AUT_Manage_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_manageInstanceFixture,
                                                                              _manageInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="Manage" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        [TestCase(MethodGetProperty)]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodCheckForQuickLaunchField)]
        [TestCase(MethodGetDataTable)]
        [TestCase(MethodLoadCustom)]
        [TestCase(MethodSetCustomOrder)]
        [TestCase(MethodlnkSaveOrder_OnClicked)]
        [TestCase(MethodGridView_PreRender)]
        [TestCase(MethodGridView_RowDataBound)]
        [TestCase(MethodddlOrder_SelectedIndexChanged)]
        [TestCase(MethodGridView_RowCommand)]
        [TestCase(MethodHandleNAcase)]
        [TestCase(MethodDelButton)]
        [TestCase(MethodEditButton)]
        [TestCase(MethodManageApps)]
        [TestCase(MethodQLButton)]
        [TestCase(MethodTNButton)]
        public void AUT_Manage_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<Manage>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetProperty) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Manage_GetProperty_Method_Call_Internally(Type[] types)
        {
            var methodGetPropertyPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodGetProperty, Fixture, methodGetPropertyPrametersTypes);
        }

        #endregion

        #region Method Call : (GetProperty) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_GetProperty_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var oList = CreateType<SPList>();
            var oListItem = CreateType<SPListItem>();
            var Property = CreateType<string>();
            var methodGetPropertyPrametersTypes = new Type[] { typeof(SPList), typeof(SPListItem), typeof(string) };
            object[] parametersOfGetProperty = { oList, oListItem, Property };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetProperty, methodGetPropertyPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetProperty.ShouldNotBeNull();
            parametersOfGetProperty.Length.ShouldBe(3);
            methodGetPropertyPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => methodInfo.Invoke(_manageInstanceFixture, parametersOfGetProperty));
        }

        #endregion

        #region Method Call : (GetProperty) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_GetProperty_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oList = CreateType<SPList>();
            var oListItem = CreateType<SPListItem>();
            var Property = CreateType<string>();
            var methodGetPropertyPrametersTypes = new Type[] { typeof(SPList), typeof(SPListItem), typeof(string) };
            object[] parametersOfGetProperty = { oList, oListItem, Property };

            // Assert
            parametersOfGetProperty.ShouldNotBeNull();
            parametersOfGetProperty.Length.ShouldBe(3);
            methodGetPropertyPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Manage, string>(_manageInstance, MethodGetProperty, parametersOfGetProperty, methodGetPropertyPrametersTypes));
        }

        #endregion

        #region Method Call : (GetProperty) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_GetProperty_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetPropertyPrametersTypes = new Type[] { typeof(SPList), typeof(SPListItem), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodGetProperty, Fixture, methodGetPropertyPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetPropertyPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetProperty) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_GetProperty_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetPropertyPrametersTypes = new Type[] { typeof(SPList), typeof(SPListItem), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodGetProperty, Fixture, methodGetPropertyPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetPropertyPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetProperty) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_GetProperty_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetProperty, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_manageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetProperty) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_GetProperty_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetProperty, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Manage_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_manageInstanceFixture, parametersOfPage_Load);

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
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_manageInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_manageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CheckForQuickLaunchField) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Manage_CheckForQuickLaunchField_Method_Call_Internally(Type[] types)
        {
            var methodCheckForQuickLaunchFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodCheckForQuickLaunchField, Fixture, methodCheckForQuickLaunchFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (CheckForQuickLaunchField) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_CheckForQuickLaunchField_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            var methodCheckForQuickLaunchFieldPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfCheckForQuickLaunchField = { spWeb };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCheckForQuickLaunchField, methodCheckForQuickLaunchFieldPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_manageInstanceFixture, parametersOfCheckForQuickLaunchField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCheckForQuickLaunchField.ShouldNotBeNull();
            parametersOfCheckForQuickLaunchField.Length.ShouldBe(1);
            methodCheckForQuickLaunchFieldPrametersTypes.Length.ShouldBe(1);
            methodCheckForQuickLaunchFieldPrametersTypes.Length.ShouldBe(parametersOfCheckForQuickLaunchField.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CheckForQuickLaunchField) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_CheckForQuickLaunchField_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            var methodCheckForQuickLaunchFieldPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfCheckForQuickLaunchField = { spWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_manageInstance, MethodCheckForQuickLaunchField, parametersOfCheckForQuickLaunchField, methodCheckForQuickLaunchFieldPrametersTypes);

            // Assert
            parametersOfCheckForQuickLaunchField.ShouldNotBeNull();
            parametersOfCheckForQuickLaunchField.Length.ShouldBe(1);
            methodCheckForQuickLaunchFieldPrametersTypes.Length.ShouldBe(1);
            methodCheckForQuickLaunchFieldPrametersTypes.Length.ShouldBe(parametersOfCheckForQuickLaunchField.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CheckForQuickLaunchField) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_CheckForQuickLaunchField_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCheckForQuickLaunchField, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CheckForQuickLaunchField) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_CheckForQuickLaunchField_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCheckForQuickLaunchFieldPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodCheckForQuickLaunchField, Fixture, methodCheckForQuickLaunchFieldPrametersTypes);

            // Assert
            methodCheckForQuickLaunchFieldPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CheckForQuickLaunchField) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_CheckForQuickLaunchField_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCheckForQuickLaunchField, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_manageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDataTable) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Manage_GetDataTable_Method_Call_Internally(Type[] types)
        {
            var methodGetDataTablePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodGetDataTable, Fixture, methodGetDataTablePrametersTypes);
        }

        #endregion

        #region Method Call : (GetDataTable) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_GetDataTable_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetDataTablePrametersTypes = null;
            object[] parametersOfGetDataTable = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDataTable, methodGetDataTablePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Manage, DataTable>(_manageInstanceFixture, out exception1, parametersOfGetDataTable);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Manage, DataTable>(_manageInstance, MethodGetDataTable, parametersOfGetDataTable, methodGetDataTablePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetDataTable.ShouldBeNull();
            methodGetDataTablePrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(() => methodInfo.Invoke(_manageInstanceFixture, parametersOfGetDataTable));
        }

        #endregion

        #region Method Call : (GetDataTable) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_GetDataTable_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetDataTablePrametersTypes = null;
            object[] parametersOfGetDataTable = null; // no parameter present

            // Assert
            parametersOfGetDataTable.ShouldBeNull();
            methodGetDataTablePrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Manage, DataTable>(_manageInstance, MethodGetDataTable, parametersOfGetDataTable, methodGetDataTablePrametersTypes));
        }

        #endregion

        #region Method Call : (GetDataTable) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_GetDataTable_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetDataTablePrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodGetDataTable, Fixture, methodGetDataTablePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDataTablePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDataTable) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_GetDataTable_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetDataTablePrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodGetDataTable, Fixture, methodGetDataTablePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDataTablePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDataTable) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_GetDataTable_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDataTable, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_manageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (LoadCustom) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Manage_LoadCustom_Method_Call_Internally(Type[] types)
        {
            var methodLoadCustomPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodLoadCustom, Fixture, methodLoadCustomPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadCustom) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_LoadCustom_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var dt = CreateType<DataTable>();
            var methodLoadCustomPrametersTypes = new Type[] { typeof(DataTable) };
            object[] parametersOfLoadCustom = { dt };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodLoadCustom, methodLoadCustomPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_manageInstanceFixture, parametersOfLoadCustom);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfLoadCustom.ShouldNotBeNull();
            parametersOfLoadCustom.Length.ShouldBe(1);
            methodLoadCustomPrametersTypes.Length.ShouldBe(1);
            methodLoadCustomPrametersTypes.Length.ShouldBe(parametersOfLoadCustom.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (LoadCustom) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_LoadCustom_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dt = CreateType<DataTable>();
            var methodLoadCustomPrametersTypes = new Type[] { typeof(DataTable) };
            object[] parametersOfLoadCustom = { dt };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_manageInstance, MethodLoadCustom, parametersOfLoadCustom, methodLoadCustomPrametersTypes);

            // Assert
            parametersOfLoadCustom.ShouldNotBeNull();
            parametersOfLoadCustom.Length.ShouldBe(1);
            methodLoadCustomPrametersTypes.Length.ShouldBe(1);
            methodLoadCustomPrametersTypes.Length.ShouldBe(parametersOfLoadCustom.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadCustom) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_LoadCustom_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodLoadCustom, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LoadCustom) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_LoadCustom_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLoadCustomPrametersTypes = new Type[] { typeof(DataTable) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodLoadCustom, Fixture, methodLoadCustomPrametersTypes);

            // Assert
            methodLoadCustomPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadCustom) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_LoadCustom_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLoadCustom, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_manageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetCustomOrder) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Manage_SetCustomOrder_Method_Call_Internally(Type[] types)
        {
            var methodSetCustomOrderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodSetCustomOrder, Fixture, methodSetCustomOrderPrametersTypes);
        }

        #endregion

        #region Method Call : (SetCustomOrder) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_SetCustomOrder_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPListItemCollection>();
            var oWeb = CreateType<SPWeb>();
            var oList = CreateType<SPList>();
            var methodSetCustomOrderPrametersTypes = new Type[] { typeof(SPListItemCollection), typeof(SPWeb), typeof(SPList) };
            object[] parametersOfSetCustomOrder = { list, oWeb, oList };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetCustomOrder, methodSetCustomOrderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_manageInstanceFixture, parametersOfSetCustomOrder);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetCustomOrder.ShouldNotBeNull();
            parametersOfSetCustomOrder.Length.ShouldBe(3);
            methodSetCustomOrderPrametersTypes.Length.ShouldBe(3);
            methodSetCustomOrderPrametersTypes.Length.ShouldBe(parametersOfSetCustomOrder.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetCustomOrder) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_SetCustomOrder_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPListItemCollection>();
            var oWeb = CreateType<SPWeb>();
            var oList = CreateType<SPList>();
            var methodSetCustomOrderPrametersTypes = new Type[] { typeof(SPListItemCollection), typeof(SPWeb), typeof(SPList) };
            object[] parametersOfSetCustomOrder = { list, oWeb, oList };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_manageInstance, MethodSetCustomOrder, parametersOfSetCustomOrder, methodSetCustomOrderPrametersTypes);

            // Assert
            parametersOfSetCustomOrder.ShouldNotBeNull();
            parametersOfSetCustomOrder.Length.ShouldBe(3);
            methodSetCustomOrderPrametersTypes.Length.ShouldBe(3);
            methodSetCustomOrderPrametersTypes.Length.ShouldBe(parametersOfSetCustomOrder.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetCustomOrder) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_SetCustomOrder_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetCustomOrder, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetCustomOrder) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_SetCustomOrder_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetCustomOrderPrametersTypes = new Type[] { typeof(SPListItemCollection), typeof(SPWeb), typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodSetCustomOrder, Fixture, methodSetCustomOrderPrametersTypes);

            // Assert
            methodSetCustomOrderPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetCustomOrder) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_SetCustomOrder_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetCustomOrder, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_manageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (lnkSaveOrder_OnClicked) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Manage_lnkSaveOrder_OnClicked_Method_Call_Internally(Type[] types)
        {
            var methodlnkSaveOrder_OnClickedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodlnkSaveOrder_OnClicked, Fixture, methodlnkSaveOrder_OnClickedPrametersTypes);
        }

        #endregion

        #region Method Call : (lnkSaveOrder_OnClicked) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_lnkSaveOrder_OnClicked_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodlnkSaveOrder_OnClickedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOflnkSaveOrder_OnClicked = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodlnkSaveOrder_OnClicked, methodlnkSaveOrder_OnClickedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_manageInstanceFixture, parametersOflnkSaveOrder_OnClicked);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOflnkSaveOrder_OnClicked.ShouldNotBeNull();
            parametersOflnkSaveOrder_OnClicked.Length.ShouldBe(2);
            methodlnkSaveOrder_OnClickedPrametersTypes.Length.ShouldBe(2);
            methodlnkSaveOrder_OnClickedPrametersTypes.Length.ShouldBe(parametersOflnkSaveOrder_OnClicked.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (lnkSaveOrder_OnClicked) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_lnkSaveOrder_OnClicked_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodlnkSaveOrder_OnClickedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOflnkSaveOrder_OnClicked = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_manageInstance, MethodlnkSaveOrder_OnClicked, parametersOflnkSaveOrder_OnClicked, methodlnkSaveOrder_OnClickedPrametersTypes);

            // Assert
            parametersOflnkSaveOrder_OnClicked.ShouldNotBeNull();
            parametersOflnkSaveOrder_OnClicked.Length.ShouldBe(2);
            methodlnkSaveOrder_OnClickedPrametersTypes.Length.ShouldBe(2);
            methodlnkSaveOrder_OnClickedPrametersTypes.Length.ShouldBe(parametersOflnkSaveOrder_OnClicked.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (lnkSaveOrder_OnClicked) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_lnkSaveOrder_OnClicked_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodlnkSaveOrder_OnClicked, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (lnkSaveOrder_OnClicked) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_lnkSaveOrder_OnClicked_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodlnkSaveOrder_OnClickedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodlnkSaveOrder_OnClicked, Fixture, methodlnkSaveOrder_OnClickedPrametersTypes);

            // Assert
            methodlnkSaveOrder_OnClickedPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (lnkSaveOrder_OnClicked) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_lnkSaveOrder_OnClicked_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodlnkSaveOrder_OnClicked, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_manageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView_PreRender) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Manage_GridView_PreRender_Method_Call_Internally(Type[] types)
        {
            var methodGridView_PreRenderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodGridView_PreRender, Fixture, methodGridView_PreRenderPrametersTypes);
        }

        #endregion

        #region Method Call : (GridView_PreRender) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_GridView_PreRender_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodGridView_PreRenderPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfGridView_PreRender = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGridView_PreRender, methodGridView_PreRenderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_manageInstanceFixture, parametersOfGridView_PreRender);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGridView_PreRender.ShouldNotBeNull();
            parametersOfGridView_PreRender.Length.ShouldBe(2);
            methodGridView_PreRenderPrametersTypes.Length.ShouldBe(2);
            methodGridView_PreRenderPrametersTypes.Length.ShouldBe(parametersOfGridView_PreRender.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GridView_PreRender) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_GridView_PreRender_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodGridView_PreRenderPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfGridView_PreRender = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_manageInstance, MethodGridView_PreRender, parametersOfGridView_PreRender, methodGridView_PreRenderPrametersTypes);

            // Assert
            parametersOfGridView_PreRender.ShouldNotBeNull();
            parametersOfGridView_PreRender.Length.ShouldBe(2);
            methodGridView_PreRenderPrametersTypes.Length.ShouldBe(2);
            methodGridView_PreRenderPrametersTypes.Length.ShouldBe(parametersOfGridView_PreRender.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView_PreRender) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_GridView_PreRender_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGridView_PreRender, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GridView_PreRender) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_GridView_PreRender_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGridView_PreRenderPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodGridView_PreRender, Fixture, methodGridView_PreRenderPrametersTypes);

            // Assert
            methodGridView_PreRenderPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView_PreRender) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_GridView_PreRender_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGridView_PreRender, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_manageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView_RowDataBound) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Manage_GridView_RowDataBound_Method_Call_Internally(Type[] types)
        {
            var methodGridView_RowDataBoundPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodGridView_RowDataBound, Fixture, methodGridView_RowDataBoundPrametersTypes);
        }

        #endregion

        #region Method Call : (GridView_RowDataBound) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_GridView_RowDataBound_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridViewRowEventArgs>();
            var methodGridView_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };
            object[] parametersOfGridView_RowDataBound = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGridView_RowDataBound, methodGridView_RowDataBoundPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_manageInstanceFixture, parametersOfGridView_RowDataBound);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGridView_RowDataBound.ShouldNotBeNull();
            parametersOfGridView_RowDataBound.Length.ShouldBe(2);
            methodGridView_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            methodGridView_RowDataBoundPrametersTypes.Length.ShouldBe(parametersOfGridView_RowDataBound.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GridView_RowDataBound) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_GridView_RowDataBound_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridViewRowEventArgs>();
            var methodGridView_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };
            object[] parametersOfGridView_RowDataBound = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_manageInstance, MethodGridView_RowDataBound, parametersOfGridView_RowDataBound, methodGridView_RowDataBoundPrametersTypes);

            // Assert
            parametersOfGridView_RowDataBound.ShouldNotBeNull();
            parametersOfGridView_RowDataBound.Length.ShouldBe(2);
            methodGridView_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            methodGridView_RowDataBoundPrametersTypes.Length.ShouldBe(parametersOfGridView_RowDataBound.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView_RowDataBound) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_GridView_RowDataBound_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGridView_RowDataBound, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GridView_RowDataBound) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_GridView_RowDataBound_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGridView_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodGridView_RowDataBound, Fixture, methodGridView_RowDataBoundPrametersTypes);

            // Assert
            methodGridView_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView_RowDataBound) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_GridView_RowDataBound_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGridView_RowDataBound, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_manageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ddlOrder_SelectedIndexChanged) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Manage_ddlOrder_SelectedIndexChanged_Method_Call_Internally(Type[] types)
        {
            var methodddlOrder_SelectedIndexChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodddlOrder_SelectedIndexChanged, Fixture, methodddlOrder_SelectedIndexChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (ddlOrder_SelectedIndexChanged) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_ddlOrder_SelectedIndexChanged_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodddlOrder_SelectedIndexChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfddlOrder_SelectedIndexChanged = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodddlOrder_SelectedIndexChanged, methodddlOrder_SelectedIndexChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_manageInstanceFixture, parametersOfddlOrder_SelectedIndexChanged);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfddlOrder_SelectedIndexChanged.ShouldNotBeNull();
            parametersOfddlOrder_SelectedIndexChanged.Length.ShouldBe(2);
            methodddlOrder_SelectedIndexChangedPrametersTypes.Length.ShouldBe(2);
            methodddlOrder_SelectedIndexChangedPrametersTypes.Length.ShouldBe(parametersOfddlOrder_SelectedIndexChanged.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ddlOrder_SelectedIndexChanged) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_ddlOrder_SelectedIndexChanged_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodddlOrder_SelectedIndexChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfddlOrder_SelectedIndexChanged = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_manageInstance, MethodddlOrder_SelectedIndexChanged, parametersOfddlOrder_SelectedIndexChanged, methodddlOrder_SelectedIndexChangedPrametersTypes);

            // Assert
            parametersOfddlOrder_SelectedIndexChanged.ShouldNotBeNull();
            parametersOfddlOrder_SelectedIndexChanged.Length.ShouldBe(2);
            methodddlOrder_SelectedIndexChangedPrametersTypes.Length.ShouldBe(2);
            methodddlOrder_SelectedIndexChangedPrametersTypes.Length.ShouldBe(parametersOfddlOrder_SelectedIndexChanged.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ddlOrder_SelectedIndexChanged) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_ddlOrder_SelectedIndexChanged_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodddlOrder_SelectedIndexChanged, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ddlOrder_SelectedIndexChanged) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_ddlOrder_SelectedIndexChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodddlOrder_SelectedIndexChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodddlOrder_SelectedIndexChanged, Fixture, methodddlOrder_SelectedIndexChangedPrametersTypes);

            // Assert
            methodddlOrder_SelectedIndexChangedPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ddlOrder_SelectedIndexChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_ddlOrder_SelectedIndexChanged_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodddlOrder_SelectedIndexChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_manageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView_RowCommand) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Manage_GridView_RowCommand_Method_Call_Internally(Type[] types)
        {
            var methodGridView_RowCommandPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodGridView_RowCommand, Fixture, methodGridView_RowCommandPrametersTypes);
        }

        #endregion

        #region Method Call : (GridView_RowCommand) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_GridView_RowCommand_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridViewCommandEventArgs>();
            var methodGridView_RowCommandPrametersTypes = new Type[] { typeof(object), typeof(GridViewCommandEventArgs) };
            object[] parametersOfGridView_RowCommand = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGridView_RowCommand, methodGridView_RowCommandPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_manageInstanceFixture, parametersOfGridView_RowCommand);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGridView_RowCommand.ShouldNotBeNull();
            parametersOfGridView_RowCommand.Length.ShouldBe(2);
            methodGridView_RowCommandPrametersTypes.Length.ShouldBe(2);
            methodGridView_RowCommandPrametersTypes.Length.ShouldBe(parametersOfGridView_RowCommand.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView_RowCommand) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_GridView_RowCommand_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridViewCommandEventArgs>();
            var methodGridView_RowCommandPrametersTypes = new Type[] { typeof(object), typeof(GridViewCommandEventArgs) };
            object[] parametersOfGridView_RowCommand = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_manageInstance, MethodGridView_RowCommand, parametersOfGridView_RowCommand, methodGridView_RowCommandPrametersTypes);

            // Assert
            parametersOfGridView_RowCommand.ShouldNotBeNull();
            parametersOfGridView_RowCommand.Length.ShouldBe(2);
            methodGridView_RowCommandPrametersTypes.Length.ShouldBe(2);
            methodGridView_RowCommandPrametersTypes.Length.ShouldBe(parametersOfGridView_RowCommand.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView_RowCommand) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_GridView_RowCommand_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGridView_RowCommand, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GridView_RowCommand) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_GridView_RowCommand_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGridView_RowCommandPrametersTypes = new Type[] { typeof(object), typeof(GridViewCommandEventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodGridView_RowCommand, Fixture, methodGridView_RowCommandPrametersTypes);

            // Assert
            methodGridView_RowCommandPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView_RowCommand) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_GridView_RowCommand_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGridView_RowCommand, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_manageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HandleNAcase) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Manage_HandleNAcase_Method_Call_Internally(Type[] types)
        {
            var methodHandleNAcasePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodHandleNAcase, Fixture, methodHandleNAcasePrametersTypes);
        }

        #endregion

        #region Method Call : (HandleNAcase) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_HandleNAcase_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodHandleNAcasePrametersTypes = null;
            object[] parametersOfHandleNAcase = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodHandleNAcase, methodHandleNAcasePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_manageInstanceFixture, parametersOfHandleNAcase);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfHandleNAcase.ShouldBeNull();
            methodHandleNAcasePrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (HandleNAcase) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_HandleNAcase_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodHandleNAcasePrametersTypes = null;
            object[] parametersOfHandleNAcase = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_manageInstance, MethodHandleNAcase, parametersOfHandleNAcase, methodHandleNAcasePrametersTypes);

            // Assert
            parametersOfHandleNAcase.ShouldBeNull();
            methodHandleNAcasePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HandleNAcase) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_HandleNAcase_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodHandleNAcasePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodHandleNAcase, Fixture, methodHandleNAcasePrametersTypes);

            // Assert
            methodHandleNAcasePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HandleNAcase) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_HandleNAcase_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodHandleNAcase, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_manageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StripHTML) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Manage_StripHTML_Static_Method_Call_Internally(Type[] types)
        {
            var methodStripHTMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_manageInstanceFixture, _manageInstanceType, MethodStripHTML, Fixture, methodStripHTMLPrametersTypes);
        }

        #endregion

        #region Method Call : (StripHTML) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_StripHTML_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var input = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => Manage.StripHTML(input);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (StripHTML) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_StripHTML_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var input = CreateType<string>();
            var methodStripHTMLPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfStripHTML = { input };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodStripHTML, methodStripHTMLPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfStripHTML.ShouldNotBeNull();
            parametersOfStripHTML.Length.ShouldBe(1);
            methodStripHTMLPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(_manageInstanceFixture, parametersOfStripHTML));
        }

        #endregion

        #region Method Call : (StripHTML) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_StripHTML_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var input = CreateType<string>();
            var methodStripHTMLPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfStripHTML = { input };

            // Assert
            parametersOfStripHTML.ShouldNotBeNull();
            parametersOfStripHTML.Length.ShouldBe(1);
            methodStripHTMLPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_manageInstanceFixture, _manageInstanceType, MethodStripHTML, parametersOfStripHTML, methodStripHTMLPrametersTypes));
        }

        #endregion

        #region Method Call : (StripHTML) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_StripHTML_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodStripHTMLPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_manageInstanceFixture, _manageInstanceType, MethodStripHTML, Fixture, methodStripHTMLPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodStripHTMLPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (StripHTML) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_StripHTML_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodStripHTMLPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_manageInstanceFixture, _manageInstanceType, MethodStripHTML, Fixture, methodStripHTMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodStripHTMLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (StripHTML) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_StripHTML_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodStripHTML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_manageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (StripHTML) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_StripHTML_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodStripHTML, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DelButton) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Manage_DelButton_Method_Call_Internally(Type[] types)
        {
            var methodDelButtonPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodDelButton, Fixture, methodDelButtonPrametersTypes);
        }

        #endregion

        #region Method Call : (DelButton) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_DelButton_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var id = CreateType<object>();
            var methodDelButtonPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfDelButton = { id };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDelButton, methodDelButtonPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDelButton.ShouldNotBeNull();
            parametersOfDelButton.Length.ShouldBe(1);
            methodDelButtonPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(_manageInstanceFixture, parametersOfDelButton));
        }

        #endregion

        #region Method Call : (DelButton) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_DelButton_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var id = CreateType<object>();
            var methodDelButtonPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfDelButton = { id };

            // Assert
            parametersOfDelButton.ShouldNotBeNull();
            parametersOfDelButton.Length.ShouldBe(1);
            methodDelButtonPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Manage, string>(_manageInstance, MethodDelButton, parametersOfDelButton, methodDelButtonPrametersTypes));
        }

        #endregion

        #region Method Call : (DelButton) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_DelButton_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodDelButtonPrametersTypes = new Type[] { typeof(object) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodDelButton, Fixture, methodDelButtonPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodDelButtonPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DelButton) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_DelButton_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDelButtonPrametersTypes = new Type[] { typeof(object) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodDelButton, Fixture, methodDelButtonPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDelButtonPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DelButton) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_DelButton_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDelButton, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_manageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (DelButton) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_DelButton_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDelButton, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (EditButton) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Manage_EditButton_Method_Call_Internally(Type[] types)
        {
            var methodEditButtonPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodEditButton, Fixture, methodEditButtonPrametersTypes);
        }

        #endregion

        #region Method Call : (EditButton) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_EditButton_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var id = CreateType<object>();
            var methodEditButtonPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfEditButton = { id };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodEditButton, methodEditButtonPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfEditButton.ShouldNotBeNull();
            parametersOfEditButton.Length.ShouldBe(1);
            methodEditButtonPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(_manageInstanceFixture, parametersOfEditButton));
        }

        #endregion

        #region Method Call : (EditButton) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_EditButton_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var id = CreateType<object>();
            var methodEditButtonPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfEditButton = { id };

            // Assert
            parametersOfEditButton.ShouldNotBeNull();
            parametersOfEditButton.Length.ShouldBe(1);
            methodEditButtonPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Manage, string>(_manageInstance, MethodEditButton, parametersOfEditButton, methodEditButtonPrametersTypes));
        }

        #endregion

        #region Method Call : (EditButton) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_EditButton_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodEditButtonPrametersTypes = new Type[] { typeof(object) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodEditButton, Fixture, methodEditButtonPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodEditButtonPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (EditButton) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_EditButton_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodEditButtonPrametersTypes = new Type[] { typeof(object) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodEditButton, Fixture, methodEditButtonPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodEditButtonPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (EditButton) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_EditButton_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodEditButton, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_manageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (EditButton) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_EditButton_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodEditButton, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ManageApps) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Manage_ManageApps_Method_Call_Internally(Type[] types)
        {
            var methodManageAppsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodManageApps, Fixture, methodManageAppsPrametersTypes);
        }

        #endregion

        #region Method Call : (ManageApps) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_ManageApps_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var id = CreateType<object>();
            var methodManageAppsPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfManageApps = { id };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodManageApps, methodManageAppsPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfManageApps.ShouldNotBeNull();
            parametersOfManageApps.Length.ShouldBe(1);
            methodManageAppsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(_manageInstanceFixture, parametersOfManageApps));
        }

        #endregion

        #region Method Call : (ManageApps) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_ManageApps_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var id = CreateType<object>();
            var methodManageAppsPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfManageApps = { id };

            // Assert
            parametersOfManageApps.ShouldNotBeNull();
            parametersOfManageApps.Length.ShouldBe(1);
            methodManageAppsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Manage, string>(_manageInstance, MethodManageApps, parametersOfManageApps, methodManageAppsPrametersTypes));
        }

        #endregion

        #region Method Call : (ManageApps) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_ManageApps_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodManageAppsPrametersTypes = new Type[] { typeof(object) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodManageApps, Fixture, methodManageAppsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodManageAppsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ManageApps) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_ManageApps_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodManageAppsPrametersTypes = new Type[] { typeof(object) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodManageApps, Fixture, methodManageAppsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodManageAppsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ManageApps) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_ManageApps_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodManageApps, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_manageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ManageApps) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_ManageApps_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodManageApps, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (QLButton) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Manage_QLButton_Method_Call_Internally(Type[] types)
        {
            var methodQLButtonPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodQLButton, Fixture, methodQLButtonPrametersTypes);
        }

        #endregion

        #region Method Call : (QLButton) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_QLButton_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var id = CreateType<object>();
            var methodQLButtonPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfQLButton = { id };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodQLButton, methodQLButtonPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfQLButton.ShouldNotBeNull();
            parametersOfQLButton.Length.ShouldBe(1);
            methodQLButtonPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(_manageInstanceFixture, parametersOfQLButton));
        }

        #endregion

        #region Method Call : (QLButton) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_QLButton_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var id = CreateType<object>();
            var methodQLButtonPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfQLButton = { id };

            // Assert
            parametersOfQLButton.ShouldNotBeNull();
            parametersOfQLButton.Length.ShouldBe(1);
            methodQLButtonPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Manage, string>(_manageInstance, MethodQLButton, parametersOfQLButton, methodQLButtonPrametersTypes));
        }

        #endregion

        #region Method Call : (QLButton) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_QLButton_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodQLButtonPrametersTypes = new Type[] { typeof(object) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodQLButton, Fixture, methodQLButtonPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodQLButtonPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (QLButton) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_QLButton_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodQLButtonPrametersTypes = new Type[] { typeof(object) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodQLButton, Fixture, methodQLButtonPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodQLButtonPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (QLButton) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_QLButton_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodQLButton, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_manageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (QLButton) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_QLButton_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodQLButton, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TNButton) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Manage_TNButton_Method_Call_Internally(Type[] types)
        {
            var methodTNButtonPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodTNButton, Fixture, methodTNButtonPrametersTypes);
        }

        #endregion

        #region Method Call : (TNButton) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_TNButton_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var id = CreateType<object>();
            var methodTNButtonPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfTNButton = { id };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodTNButton, methodTNButtonPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfTNButton.ShouldNotBeNull();
            parametersOfTNButton.Length.ShouldBe(1);
            methodTNButtonPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(_manageInstanceFixture, parametersOfTNButton));
        }

        #endregion

        #region Method Call : (TNButton) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_TNButton_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var id = CreateType<object>();
            var methodTNButtonPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfTNButton = { id };

            // Assert
            parametersOfTNButton.ShouldNotBeNull();
            parametersOfTNButton.Length.ShouldBe(1);
            methodTNButtonPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Manage, string>(_manageInstance, MethodTNButton, parametersOfTNButton, methodTNButtonPrametersTypes));
        }

        #endregion

        #region Method Call : (TNButton) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_TNButton_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodTNButtonPrametersTypes = new Type[] { typeof(object) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodTNButton, Fixture, methodTNButtonPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodTNButtonPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (TNButton) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_TNButton_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodTNButtonPrametersTypes = new Type[] { typeof(object) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodTNButton, Fixture, methodTNButtonPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodTNButtonPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TNButton) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_TNButton_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodTNButton, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_manageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (TNButton) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Manage_TNButton_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodTNButton, 0);
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
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

namespace EPMLiveCore.Layouts.epmlive.applications
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Layouts.epmlive.applications.ManageApps" />)
    ///     and namespace <see cref="EPMLiveCore.Layouts.epmlive.applications"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ManageAppsTest : AbstractBaseSetupTypedTest<ManageApps>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ManageApps) Initializer

        private const string MethodGetProperty = "GetProperty";
        private const string MethodPage_Load = "Page_Load";
        private const string MethodLoadInstalled = "LoadInstalled";
        private const string MethodGridView2_RowDataBound = "GridView2_RowDataBound";
        private const string MethodUnInstButton = "UnInstButton";
        private const string FieldsWebUrl = "sWebUrl";
        private const string FieldsFullWebUrl = "sFullWebUrl";
        private Type _manageAppsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ManageApps _manageAppsInstance;
        private ManageApps _manageAppsInstanceFixture;

        #region General Initializer : Class (ManageApps) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ManageApps" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _manageAppsInstanceType = typeof(ManageApps);
            _manageAppsInstanceFixture = Create(true);
            _manageAppsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ManageApps)

        #region General Initializer : Class (ManageApps) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ManageApps" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetProperty, 0)]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodLoadInstalled, 0)]
        [TestCase(MethodGridView2_RowDataBound, 0)]
        [TestCase(MethodUnInstButton, 0)]
        public void AUT_ManageApps_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_manageAppsInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ManageApps) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ManageApps" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldsWebUrl)]
        [TestCase(FieldsFullWebUrl)]
        public void AUT_ManageApps_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_manageAppsInstanceFixture, 
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
        ///     Class (<see cref="ManageApps" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ManageApps_Is_Instance_Present_Test()
        {
            // Assert
            _manageAppsInstanceType.ShouldNotBeNull();
            _manageAppsInstance.ShouldNotBeNull();
            _manageAppsInstanceFixture.ShouldNotBeNull();
            _manageAppsInstance.ShouldBeAssignableTo<ManageApps>();
            _manageAppsInstanceFixture.ShouldBeAssignableTo<ManageApps>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ManageApps) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ManageApps_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ManageApps instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _manageAppsInstanceType.ShouldNotBeNull();
            _manageAppsInstance.ShouldNotBeNull();
            _manageAppsInstanceFixture.ShouldNotBeNull();
            _manageAppsInstance.ShouldBeAssignableTo<ManageApps>();
            _manageAppsInstanceFixture.ShouldBeAssignableTo<ManageApps>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ManageApps" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetProperty)]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodLoadInstalled)]
        [TestCase(MethodGridView2_RowDataBound)]
        [TestCase(MethodUnInstButton)]
        public void AUT_ManageApps_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ManageApps>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetProperty) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ManageApps_GetProperty_Method_Call_Internally(Type[] types)
        {
            var methodGetPropertyPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageAppsInstance, MethodGetProperty, Fixture, methodGetPropertyPrametersTypes);
        }

        #endregion

        #region Method Call : (GetProperty) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ManageApps_GetProperty_Method_Call_With_No_Exception_Thrown_Test()
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
            Should.NotThrow(() => methodInfo.Invoke(_manageAppsInstanceFixture, parametersOfGetProperty));
        }

        #endregion

        #region Method Call : (GetProperty) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ManageApps_GetProperty_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
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
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<ManageApps, string>(_manageAppsInstance, MethodGetProperty, parametersOfGetProperty, methodGetPropertyPrametersTypes));
        }

        #endregion

        #region Method Call : (GetProperty) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ManageApps_GetProperty_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetPropertyPrametersTypes = new Type[] { typeof(SPList), typeof(SPListItem), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageAppsInstance, MethodGetProperty, Fixture, methodGetPropertyPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetPropertyPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetProperty) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ManageApps_GetProperty_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetPropertyPrametersTypes = new Type[] { typeof(SPList), typeof(SPListItem), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageAppsInstance, MethodGetProperty, Fixture, methodGetPropertyPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetPropertyPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetProperty) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ManageApps_GetProperty_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetProperty, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_manageAppsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetProperty) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ManageApps_GetProperty_Method_Call_Parameters_Count_Verification_Test()
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
        private void AUT_ManageApps_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageAppsInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ManageApps_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_manageAppsInstanceFixture, parametersOfPage_Load);

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
        public void AUT_ManageApps_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_manageAppsInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_ManageApps_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ManageApps_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageAppsInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ManageApps_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_manageAppsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadInstalled) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ManageApps_LoadInstalled_Method_Call_Internally(Type[] types)
        {
            var methodLoadInstalledPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageAppsInstance, MethodLoadInstalled, Fixture, methodLoadInstalledPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadInstalled) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ManageApps_LoadInstalled_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var oWeb = CreateType<SPWeb>();
            var oList = CreateType<SPList>();
            var methodLoadInstalledPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPList) };
            object[] parametersOfLoadInstalled = { oWeb, oList };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodLoadInstalled, methodLoadInstalledPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_manageAppsInstanceFixture, parametersOfLoadInstalled);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfLoadInstalled.ShouldNotBeNull();
            parametersOfLoadInstalled.Length.ShouldBe(2);
            methodLoadInstalledPrametersTypes.Length.ShouldBe(2);
            methodLoadInstalledPrametersTypes.Length.ShouldBe(parametersOfLoadInstalled.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (LoadInstalled) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ManageApps_LoadInstalled_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oWeb = CreateType<SPWeb>();
            var oList = CreateType<SPList>();
            var methodLoadInstalledPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPList) };
            object[] parametersOfLoadInstalled = { oWeb, oList };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_manageAppsInstance, MethodLoadInstalled, parametersOfLoadInstalled, methodLoadInstalledPrametersTypes);

            // Assert
            parametersOfLoadInstalled.ShouldNotBeNull();
            parametersOfLoadInstalled.Length.ShouldBe(2);
            methodLoadInstalledPrametersTypes.Length.ShouldBe(2);
            methodLoadInstalledPrametersTypes.Length.ShouldBe(parametersOfLoadInstalled.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadInstalled) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ManageApps_LoadInstalled_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodLoadInstalled, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LoadInstalled) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ManageApps_LoadInstalled_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLoadInstalledPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageAppsInstance, MethodLoadInstalled, Fixture, methodLoadInstalledPrametersTypes);

            // Assert
            methodLoadInstalledPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadInstalled) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ManageApps_LoadInstalled_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLoadInstalled, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_manageAppsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView2_RowDataBound) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ManageApps_GridView2_RowDataBound_Method_Call_Internally(Type[] types)
        {
            var methodGridView2_RowDataBoundPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageAppsInstance, MethodGridView2_RowDataBound, Fixture, methodGridView2_RowDataBoundPrametersTypes);
        }

        #endregion

        #region Method Call : (GridView2_RowDataBound) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ManageApps_GridView2_RowDataBound_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridViewRowEventArgs>();
            var methodGridView2_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };
            object[] parametersOfGridView2_RowDataBound = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGridView2_RowDataBound, methodGridView2_RowDataBoundPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_manageAppsInstanceFixture, parametersOfGridView2_RowDataBound);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGridView2_RowDataBound.ShouldNotBeNull();
            parametersOfGridView2_RowDataBound.Length.ShouldBe(2);
            methodGridView2_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            methodGridView2_RowDataBoundPrametersTypes.Length.ShouldBe(parametersOfGridView2_RowDataBound.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GridView2_RowDataBound) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ManageApps_GridView2_RowDataBound_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridViewRowEventArgs>();
            var methodGridView2_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };
            object[] parametersOfGridView2_RowDataBound = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_manageAppsInstance, MethodGridView2_RowDataBound, parametersOfGridView2_RowDataBound, methodGridView2_RowDataBoundPrametersTypes);

            // Assert
            parametersOfGridView2_RowDataBound.ShouldNotBeNull();
            parametersOfGridView2_RowDataBound.Length.ShouldBe(2);
            methodGridView2_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            methodGridView2_RowDataBoundPrametersTypes.Length.ShouldBe(parametersOfGridView2_RowDataBound.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView2_RowDataBound) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ManageApps_GridView2_RowDataBound_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGridView2_RowDataBound, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GridView2_RowDataBound) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ManageApps_GridView2_RowDataBound_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGridView2_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageAppsInstance, MethodGridView2_RowDataBound, Fixture, methodGridView2_RowDataBoundPrametersTypes);

            // Assert
            methodGridView2_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView2_RowDataBound) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ManageApps_GridView2_RowDataBound_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGridView2_RowDataBound, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_manageAppsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UnInstButton) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ManageApps_UnInstButton_Method_Call_Internally(Type[] types)
        {
            var methodUnInstButtonPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageAppsInstance, MethodUnInstButton, Fixture, methodUnInstButtonPrametersTypes);
        }

        #endregion

        #region Method Call : (UnInstButton) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ManageApps_UnInstButton_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var id = CreateType<object>();
            var methodUnInstButtonPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfUnInstButton = { id };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUnInstButton, methodUnInstButtonPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUnInstButton.ShouldNotBeNull();
            parametersOfUnInstButton.Length.ShouldBe(1);
            methodUnInstButtonPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(_manageAppsInstanceFixture, parametersOfUnInstButton));
        }

        #endregion

        #region Method Call : (UnInstButton) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ManageApps_UnInstButton_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var id = CreateType<object>();
            var methodUnInstButtonPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfUnInstButton = { id };

            // Assert
            parametersOfUnInstButton.ShouldNotBeNull();
            parametersOfUnInstButton.Length.ShouldBe(1);
            methodUnInstButtonPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<ManageApps, string>(_manageAppsInstance, MethodUnInstButton, parametersOfUnInstButton, methodUnInstButtonPrametersTypes));
        }

        #endregion

        #region Method Call : (UnInstButton) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ManageApps_UnInstButton_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodUnInstButtonPrametersTypes = new Type[] { typeof(object) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageAppsInstance, MethodUnInstButton, Fixture, methodUnInstButtonPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodUnInstButtonPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (UnInstButton) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ManageApps_UnInstButton_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUnInstButtonPrametersTypes = new Type[] { typeof(object) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageAppsInstance, MethodUnInstButton, Fixture, methodUnInstButtonPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUnInstButtonPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UnInstButton) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ManageApps_UnInstButton_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUnInstButton, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_manageAppsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (UnInstButton) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ManageApps_UnInstButton_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUnInstButton, 0);
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
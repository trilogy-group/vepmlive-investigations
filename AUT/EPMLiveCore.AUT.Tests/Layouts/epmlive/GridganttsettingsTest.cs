using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using EPMLiveCore.ReportHelper;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.Layouts.epmlive
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Layouts.epmlive.gridganttsettings" />)
    ///     and namespace <see cref="EPMLiveCore.Layouts.epmlive"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public partial class GridganttsettingsTest : AbstractBaseSetupTypedTest<gridganttsettings>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (gridganttsettings) Initializer

        private const string PropertyPageToRedirectOnCancel = "PageToRedirectOnCancel";
        private const string MethodGetGroupsPermissionsAssignment = "GetGroupsPermissionsAssignment";
        private const string MethodlnkGrpPermDelete_OnClick = "lnkGrpPermDelete_OnClick";
        private const string MethodbtnGrpPermAdd_OnClick = "btnGrpPermAdd_OnClick";
        private const string MethodOnPreLoad = "OnPreLoad";
        private const string MethodPage_Load = "Page_Load";
        private const string MethodGetAvailableDefaultTemps = "GetAvailableDefaultTemps";
        private const string MethodGetAvailableParentSiteLookups = "GetAvailableParentSiteLookups";
        private const string MethodGetListEvents = "GetListEvents";
        private const string MethodAddGridGanttToViews = "AddGridGanttToViews";
        private const string MethodRemoveEventHandlers = "RemoveEventHandlers";
        private const string MethodAddFieldsAndFixLookupFields = "AddFieldsAndFixLookupFields";
        private const string MethodAddEventHandlers = "AddEventHandlers";
        private const string MethodFixLookupFields = "FixLookupFields";
        private const string MethodEnableWorkengineListFeatures = "EnableWorkengineListFeatures";
        private const string MethodAddRemoveMyWorkReportingEvents = "AddRemoveMyWorkReportingEvents";
        private const string MethodAddEventReceiverElement = "AddEventReceiverElement";
        private const string MethodRemoveWorkengineListFeatures = "RemoveWorkengineListFeatures";
        private const string MethodButton1_Click = "Button1_Click";
        private const string MethodSetListIcon = "SetListIcon";
        private const string MethodGetListFields = "GetListFields";
        private const string MethodDisableFancyForms = "DisableFancyForms";
        private const string MethodEnableFancyForms = "EnableFancyForms";
        private const string MethodAddReportEvent = "AddReportEvent";
        private const string MethodShowAlert = "ShowAlert";
        private const string MethodGetRefLists = "GetRefLists";
        private const string MethodEnableSiteFeature = "EnableSiteFeature";
        private const string MethodClearLookupReferences = "ClearLookupReferences";
        private const string MethodUpdateLookupReferences = "UpdateLookupReferences";
        private const string MethodReplaceXmlAttributeValue = "ReplaceXmlAttributeValue";
        private const string MethodFieldExistsInList = "FieldExistsInList";
        private const string FieldtxtRollupLists = "txtRollupLists";
        private const string FieldtxtRollupSites = "txtRollupSites";
        private const string FieldchkExecutive = "chkExecutive";
        private const string FieldchkShowViewToolbar = "chkShowViewToolbar";
        private const string FieldchkHideNewButton = "chkHideNewButton";
        private const string FieldchkUsePopup = "chkUsePopup";
        private const string FieldchkResTools = "chkResTools";
        private const string FieldchkPerformance = "chkPerformance";
        private const string FieldchkAllowEdit = "chkAllowEdit";
        private const string FieldchkEditDefault = "chkEditDefault";
        private const string FieldchkShowInsert = "chkShowInsert";
        private const string FieldchkDisableNewRollup = "chkDisableNewRollup";
        private const string FieldchkEnableRequests = "chkEnableRequests";
        private const string FieldchkUseNewMenu = "chkUseNewMenu";
        private const string FieldtxtNewMenuName = "txtNewMenuName";
        private const string FieldstrListName = "strListName";
        private const string FieldstrListId = "strListId";
        private const string FieldstrReportActionUrl = "strReportActionUrl";
        private const string FielddtGroupsPermissions = "dtGroupsPermissions";
        private const string FieldREPORT_CHECK_URL = "REPORT_CHECK_URL";
        private Type _gridganttsettingsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private gridganttsettings _gridganttsettingsInstance;
        private gridganttsettings _gridganttsettingsInstanceFixture;

        #region General Initializer : Class (gridganttsettings) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="gridganttsettings" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _gridganttsettingsInstanceType = typeof(gridganttsettings);
            _gridganttsettingsInstanceFixture = Create(true);
            _gridganttsettingsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (gridganttsettings)

        #region General Initializer : Class (gridganttsettings) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="gridganttsettings" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetGroupsPermissionsAssignment, 0)]
        [TestCase(MethodlnkGrpPermDelete_OnClick, 0)]
        [TestCase(MethodbtnGrpPermAdd_OnClick, 0)]
        [TestCase(MethodOnPreLoad, 0)]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodGetAvailableDefaultTemps, 0)]
        [TestCase(MethodGetAvailableParentSiteLookups, 0)]
        [TestCase(MethodGetListEvents, 0)]
        [TestCase(MethodAddGridGanttToViews, 0)]
        [TestCase(MethodRemoveEventHandlers, 0)]
        [TestCase(MethodAddFieldsAndFixLookupFields, 0)]
        [TestCase(MethodAddEventHandlers, 0)]
        [TestCase(MethodFixLookupFields, 0)]
        [TestCase(MethodEnableWorkengineListFeatures, 0)]
        [TestCase(MethodAddRemoveMyWorkReportingEvents, 0)]
        [TestCase(MethodAddEventReceiverElement, 0)]
        [TestCase(MethodRemoveWorkengineListFeatures, 0)]
        [TestCase(MethodButton1_Click, 0)]
        [TestCase(MethodSetListIcon, 0)]
        [TestCase(MethodGetListFields, 0)]
        [TestCase(MethodDisableFancyForms, 0)]
        [TestCase(MethodEnableFancyForms, 0)]
        [TestCase(MethodAddReportEvent, 0)]
        [TestCase(MethodShowAlert, 0)]
        [TestCase(MethodGetRefLists, 0)]
        [TestCase(MethodEnableSiteFeature, 0)]
        [TestCase(MethodClearLookupReferences, 0)]
        [TestCase(MethodUpdateLookupReferences, 0)]
        [TestCase(MethodReplaceXmlAttributeValue, 0)]
        [TestCase(MethodFieldExistsInList, 0)]
        public void AUT_Gridganttsettings_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_gridganttsettingsInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (gridganttsettings) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="gridganttsettings" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyPageToRedirectOnCancel)]
        public void AUT_Gridganttsettings_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_gridganttsettingsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (gridganttsettings) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="gridganttsettings" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldtxtRollupLists)]
        [TestCase(FieldtxtRollupSites)]
        [TestCase(FieldchkExecutive)]
        [TestCase(FieldchkShowViewToolbar)]
        [TestCase(FieldchkHideNewButton)]
        [TestCase(FieldchkUsePopup)]
        [TestCase(FieldchkResTools)]
        [TestCase(FieldchkPerformance)]
        [TestCase(FieldchkAllowEdit)]
        [TestCase(FieldchkEditDefault)]
        [TestCase(FieldchkShowInsert)]
        [TestCase(FieldchkDisableNewRollup)]
        [TestCase(FieldchkEnableRequests)]
        [TestCase(FieldchkUseNewMenu)]
        [TestCase(FieldtxtNewMenuName)]
        [TestCase(FieldstrListName)]
        [TestCase(FieldstrListId)]
        [TestCase(FieldstrReportActionUrl)]
        [TestCase(FielddtGroupsPermissions)]
        [TestCase(FieldREPORT_CHECK_URL)]
        public void AUT_Gridganttsettings_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_gridganttsettingsInstanceFixture, 
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
        ///     Class (<see cref="gridganttsettings" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Gridganttsettings_Is_Instance_Present_Test()
        {
            // Assert
            _gridganttsettingsInstanceType.ShouldNotBeNull();
            _gridganttsettingsInstance.ShouldNotBeNull();
            _gridganttsettingsInstanceFixture.ShouldNotBeNull();
            _gridganttsettingsInstance.ShouldBeAssignableTo<gridganttsettings>();
            _gridganttsettingsInstanceFixture.ShouldBeAssignableTo<gridganttsettings>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (gridganttsettings) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_gridganttsettings_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            gridganttsettings instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _gridganttsettingsInstanceType.ShouldNotBeNull();
            _gridganttsettingsInstance.ShouldNotBeNull();
            _gridganttsettingsInstanceFixture.ShouldNotBeNull();
            _gridganttsettingsInstance.ShouldBeAssignableTo<gridganttsettings>();
            _gridganttsettingsInstanceFixture.ShouldBeAssignableTo<gridganttsettings>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (gridganttsettings) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyPageToRedirectOnCancel)]
        public void AUT_Gridganttsettings_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<gridganttsettings, T>(_gridganttsettingsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (gridganttsettings) => Property (PageToRedirectOnCancel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Gridganttsettings_Public_Class_PageToRedirectOnCancel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPageToRedirectOnCancel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="gridganttsettings" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetGroupsPermissionsAssignment)]
        [TestCase(MethodlnkGrpPermDelete_OnClick)]
        [TestCase(MethodbtnGrpPermAdd_OnClick)]
        [TestCase(MethodOnPreLoad)]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodGetAvailableDefaultTemps)]
        [TestCase(MethodGetAvailableParentSiteLookups)]
        [TestCase(MethodGetListEvents)]
        [TestCase(MethodAddGridGanttToViews)]
        [TestCase(MethodRemoveEventHandlers)]
        [TestCase(MethodAddFieldsAndFixLookupFields)]
        [TestCase(MethodAddEventHandlers)]
        [TestCase(MethodFixLookupFields)]
        [TestCase(MethodEnableWorkengineListFeatures)]
        [TestCase(MethodAddRemoveMyWorkReportingEvents)]
        [TestCase(MethodAddEventReceiverElement)]
        [TestCase(MethodRemoveWorkengineListFeatures)]
        [TestCase(MethodButton1_Click)]
        [TestCase(MethodSetListIcon)]
        [TestCase(MethodGetListFields)]
        [TestCase(MethodDisableFancyForms)]
        [TestCase(MethodEnableFancyForms)]
        [TestCase(MethodAddReportEvent)]
        [TestCase(MethodShowAlert)]
        [TestCase(MethodGetRefLists)]
        [TestCase(MethodEnableSiteFeature)]
        [TestCase(MethodClearLookupReferences)]
        [TestCase(MethodUpdateLookupReferences)]
        [TestCase(MethodReplaceXmlAttributeValue)]
        [TestCase(MethodFieldExistsInList)]
        public void AUT_Gridganttsettings_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<gridganttsettings>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetGroupsPermissionsAssignment) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gridganttsettings_GetGroupsPermissionsAssignment_Method_Call_Internally(Type[] types)
        {
            var methodGetGroupsPermissionsAssignmentPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodGetGroupsPermissionsAssignment, Fixture, methodGetGroupsPermissionsAssignmentPrametersTypes);
        }

        #endregion

        #region Method Call : (GetGroupsPermissionsAssignment) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_GetGroupsPermissionsAssignment_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodGetGroupsPermissionsAssignmentPrametersTypes = null;
            object[] parametersOfGetGroupsPermissionsAssignment = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetGroupsPermissionsAssignment, methodGetGroupsPermissionsAssignmentPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<gridganttsettings, string>(_gridganttsettingsInstanceFixture, out exception1, parametersOfGetGroupsPermissionsAssignment);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<gridganttsettings, string>(_gridganttsettingsInstance, MethodGetGroupsPermissionsAssignment, parametersOfGetGroupsPermissionsAssignment, methodGetGroupsPermissionsAssignmentPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetGroupsPermissionsAssignment.ShouldBeNull();
            methodGetGroupsPermissionsAssignmentPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<gridganttsettings, string>(_gridganttsettingsInstance, MethodGetGroupsPermissionsAssignment, parametersOfGetGroupsPermissionsAssignment, methodGetGroupsPermissionsAssignmentPrametersTypes));
        }

        #endregion

        #region Method Call : (GetGroupsPermissionsAssignment) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_GetGroupsPermissionsAssignment_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetGroupsPermissionsAssignmentPrametersTypes = null;
            object[] parametersOfGetGroupsPermissionsAssignment = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetGroupsPermissionsAssignment, methodGetGroupsPermissionsAssignmentPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetGroupsPermissionsAssignment.ShouldBeNull();
            methodGetGroupsPermissionsAssignmentPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => methodInfo.Invoke(_gridganttsettingsInstanceFixture, parametersOfGetGroupsPermissionsAssignment));
        }

        #endregion

        #region Method Call : (GetGroupsPermissionsAssignment) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_GetGroupsPermissionsAssignment_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetGroupsPermissionsAssignmentPrametersTypes = null;
            object[] parametersOfGetGroupsPermissionsAssignment = null; // no parameter present

            // Assert
            parametersOfGetGroupsPermissionsAssignment.ShouldBeNull();
            methodGetGroupsPermissionsAssignmentPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<gridganttsettings, string>(_gridganttsettingsInstance, MethodGetGroupsPermissionsAssignment, parametersOfGetGroupsPermissionsAssignment, methodGetGroupsPermissionsAssignmentPrametersTypes));
        }

        #endregion

        #region Method Call : (GetGroupsPermissionsAssignment) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_GetGroupsPermissionsAssignment_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetGroupsPermissionsAssignmentPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodGetGroupsPermissionsAssignment, Fixture, methodGetGroupsPermissionsAssignmentPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetGroupsPermissionsAssignmentPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetGroupsPermissionsAssignment) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_GetGroupsPermissionsAssignment_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetGroupsPermissionsAssignmentPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodGetGroupsPermissionsAssignment, Fixture, methodGetGroupsPermissionsAssignmentPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetGroupsPermissionsAssignmentPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetGroupsPermissionsAssignment) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_GetGroupsPermissionsAssignment_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetGroupsPermissionsAssignment, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridganttsettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (lnkGrpPermDelete_OnClick) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gridganttsettings_lnkGrpPermDelete_OnClick_Method_Call_Internally(Type[] types)
        {
            var methodlnkGrpPermDelete_OnClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodlnkGrpPermDelete_OnClick, Fixture, methodlnkGrpPermDelete_OnClickPrametersTypes);
        }

        #endregion

        #region Method Call : (lnkGrpPermDelete_OnClick) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_lnkGrpPermDelete_OnClick_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodlnkGrpPermDelete_OnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOflnkGrpPermDelete_OnClick = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodlnkGrpPermDelete_OnClick, methodlnkGrpPermDelete_OnClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridganttsettingsInstanceFixture, parametersOflnkGrpPermDelete_OnClick);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOflnkGrpPermDelete_OnClick.ShouldNotBeNull();
            parametersOflnkGrpPermDelete_OnClick.Length.ShouldBe(2);
            methodlnkGrpPermDelete_OnClickPrametersTypes.Length.ShouldBe(2);
            methodlnkGrpPermDelete_OnClickPrametersTypes.Length.ShouldBe(parametersOflnkGrpPermDelete_OnClick.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (lnkGrpPermDelete_OnClick) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_lnkGrpPermDelete_OnClick_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodlnkGrpPermDelete_OnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOflnkGrpPermDelete_OnClick = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridganttsettingsInstance, MethodlnkGrpPermDelete_OnClick, parametersOflnkGrpPermDelete_OnClick, methodlnkGrpPermDelete_OnClickPrametersTypes);

            // Assert
            parametersOflnkGrpPermDelete_OnClick.ShouldNotBeNull();
            parametersOflnkGrpPermDelete_OnClick.Length.ShouldBe(2);
            methodlnkGrpPermDelete_OnClickPrametersTypes.Length.ShouldBe(2);
            methodlnkGrpPermDelete_OnClickPrametersTypes.Length.ShouldBe(parametersOflnkGrpPermDelete_OnClick.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (lnkGrpPermDelete_OnClick) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_lnkGrpPermDelete_OnClick_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodlnkGrpPermDelete_OnClick, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (lnkGrpPermDelete_OnClick) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_lnkGrpPermDelete_OnClick_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodlnkGrpPermDelete_OnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodlnkGrpPermDelete_OnClick, Fixture, methodlnkGrpPermDelete_OnClickPrametersTypes);

            // Assert
            methodlnkGrpPermDelete_OnClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (lnkGrpPermDelete_OnClick) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_lnkGrpPermDelete_OnClick_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodlnkGrpPermDelete_OnClick, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridganttsettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnGrpPermAdd_OnClick) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gridganttsettings_btnGrpPermAdd_OnClick_Method_Call_Internally(Type[] types)
        {
            var methodbtnGrpPermAdd_OnClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodbtnGrpPermAdd_OnClick, Fixture, methodbtnGrpPermAdd_OnClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnGrpPermAdd_OnClick) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_btnGrpPermAdd_OnClick_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnGrpPermAdd_OnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnGrpPermAdd_OnClick = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnGrpPermAdd_OnClick, methodbtnGrpPermAdd_OnClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridganttsettingsInstanceFixture, parametersOfbtnGrpPermAdd_OnClick);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbtnGrpPermAdd_OnClick.ShouldNotBeNull();
            parametersOfbtnGrpPermAdd_OnClick.Length.ShouldBe(2);
            methodbtnGrpPermAdd_OnClickPrametersTypes.Length.ShouldBe(2);
            methodbtnGrpPermAdd_OnClickPrametersTypes.Length.ShouldBe(parametersOfbtnGrpPermAdd_OnClick.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (btnGrpPermAdd_OnClick) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_btnGrpPermAdd_OnClick_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnGrpPermAdd_OnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnGrpPermAdd_OnClick = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridganttsettingsInstance, MethodbtnGrpPermAdd_OnClick, parametersOfbtnGrpPermAdd_OnClick, methodbtnGrpPermAdd_OnClickPrametersTypes);

            // Assert
            parametersOfbtnGrpPermAdd_OnClick.ShouldNotBeNull();
            parametersOfbtnGrpPermAdd_OnClick.Length.ShouldBe(2);
            methodbtnGrpPermAdd_OnClickPrametersTypes.Length.ShouldBe(2);
            methodbtnGrpPermAdd_OnClickPrametersTypes.Length.ShouldBe(parametersOfbtnGrpPermAdd_OnClick.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnGrpPermAdd_OnClick) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_btnGrpPermAdd_OnClick_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbtnGrpPermAdd_OnClick, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (btnGrpPermAdd_OnClick) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_btnGrpPermAdd_OnClick_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnGrpPermAdd_OnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodbtnGrpPermAdd_OnClick, Fixture, methodbtnGrpPermAdd_OnClickPrametersTypes);

            // Assert
            methodbtnGrpPermAdd_OnClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnGrpPermAdd_OnClick) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_btnGrpPermAdd_OnClick_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnGrpPermAdd_OnClick, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridganttsettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreLoad) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gridganttsettings_OnPreLoad_Method_Call_Internally(Type[] types)
        {
            var methodOnPreLoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodOnPreLoad, Fixture, methodOnPreLoadPrametersTypes);
        }

        #endregion

        #region Method Call : (OnPreLoad) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_OnPreLoad_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnPreLoadPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnPreLoad = { e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnPreLoad, methodOnPreLoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridganttsettingsInstanceFixture, parametersOfOnPreLoad);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOnPreLoad.ShouldNotBeNull();
            parametersOfOnPreLoad.Length.ShouldBe(1);
            methodOnPreLoadPrametersTypes.Length.ShouldBe(1);
            methodOnPreLoadPrametersTypes.Length.ShouldBe(parametersOfOnPreLoad.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (OnPreLoad) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_OnPreLoad_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnPreLoadPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnPreLoad = { e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridganttsettingsInstance, MethodOnPreLoad, parametersOfOnPreLoad, methodOnPreLoadPrametersTypes);

            // Assert
            parametersOfOnPreLoad.ShouldNotBeNull();
            parametersOfOnPreLoad.Length.ShouldBe(1);
            methodOnPreLoadPrametersTypes.Length.ShouldBe(1);
            methodOnPreLoadPrametersTypes.Length.ShouldBe(parametersOfOnPreLoad.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreLoad) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_OnPreLoad_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOnPreLoad, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnPreLoad) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_OnPreLoad_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnPreLoadPrametersTypes = new Type[] { typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodOnPreLoad, Fixture, methodOnPreLoadPrametersTypes);

            // Assert
            methodOnPreLoadPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreLoad) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_OnPreLoad_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnPreLoad, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridganttsettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gridganttsettings_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridganttsettingsInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Gridganttsettings_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridganttsettingsInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Gridganttsettings_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Gridganttsettings_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridganttsettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAvailableDefaultTemps) (Return Type : Dictionary<string, int>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gridganttsettings_GetAvailableDefaultTemps_Method_Call_Internally(Type[] types)
        {
            var methodGetAvailableDefaultTempsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodGetAvailableDefaultTemps, Fixture, methodGetAvailableDefaultTempsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAvailableDefaultTemps) (Return Type : Dictionary<string, int>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_GetAvailableDefaultTemps_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetAvailableDefaultTempsPrametersTypes = null;
            object[] parametersOfGetAvailableDefaultTemps = null; // no parameter present

            // Assert
            parametersOfGetAvailableDefaultTemps.ShouldBeNull();
            methodGetAvailableDefaultTempsPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<gridganttsettings, Dictionary<string, int>>(_gridganttsettingsInstance, MethodGetAvailableDefaultTemps, parametersOfGetAvailableDefaultTemps, methodGetAvailableDefaultTempsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetAvailableDefaultTemps) (Return Type : Dictionary<string, int>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_GetAvailableDefaultTemps_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetAvailableDefaultTempsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodGetAvailableDefaultTemps, Fixture, methodGetAvailableDefaultTempsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetAvailableDefaultTempsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAvailableDefaultTemps) (Return Type : Dictionary<string, int>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_GetAvailableDefaultTemps_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetAvailableDefaultTemps, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridganttsettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAvailableParentSiteLookups) (Return Type : Dictionary<string, string>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gridganttsettings_GetAvailableParentSiteLookups_Method_Call_Internally(Type[] types)
        {
            var methodGetAvailableParentSiteLookupsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodGetAvailableParentSiteLookups, Fixture, methodGetAvailableParentSiteLookupsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAvailableParentSiteLookups) (Return Type : Dictionary<string, string>) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_GetAvailableParentSiteLookups_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var gSettings = CreateType<GridGanttSettings>();
            var methodGetAvailableParentSiteLookupsPrametersTypes = new Type[] { typeof(SPList), typeof(GridGanttSettings) };
            object[] parametersOfGetAvailableParentSiteLookups = { list, gSettings };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetAvailableParentSiteLookups, methodGetAvailableParentSiteLookupsPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetAvailableParentSiteLookups.ShouldNotBeNull();
            parametersOfGetAvailableParentSiteLookups.Length.ShouldBe(2);
            methodGetAvailableParentSiteLookupsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => methodInfo.Invoke(_gridganttsettingsInstanceFixture, parametersOfGetAvailableParentSiteLookups));
        }

        #endregion

        #region Method Call : (GetAvailableParentSiteLookups) (Return Type : Dictionary<string, string>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_GetAvailableParentSiteLookups_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var gSettings = CreateType<GridGanttSettings>();
            var methodGetAvailableParentSiteLookupsPrametersTypes = new Type[] { typeof(SPList), typeof(GridGanttSettings) };
            object[] parametersOfGetAvailableParentSiteLookups = { list, gSettings };

            // Assert
            parametersOfGetAvailableParentSiteLookups.ShouldNotBeNull();
            parametersOfGetAvailableParentSiteLookups.Length.ShouldBe(2);
            methodGetAvailableParentSiteLookupsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<gridganttsettings, Dictionary<string, string>>(_gridganttsettingsInstance, MethodGetAvailableParentSiteLookups, parametersOfGetAvailableParentSiteLookups, methodGetAvailableParentSiteLookupsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetAvailableParentSiteLookups) (Return Type : Dictionary<string, string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_GetAvailableParentSiteLookups_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetAvailableParentSiteLookupsPrametersTypes = new Type[] { typeof(SPList), typeof(GridGanttSettings) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodGetAvailableParentSiteLookups, Fixture, methodGetAvailableParentSiteLookupsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetAvailableParentSiteLookupsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetAvailableParentSiteLookups) (Return Type : Dictionary<string, string>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_GetAvailableParentSiteLookups_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetAvailableParentSiteLookupsPrametersTypes = new Type[] { typeof(SPList), typeof(GridGanttSettings) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodGetAvailableParentSiteLookups, Fixture, methodGetAvailableParentSiteLookupsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetAvailableParentSiteLookupsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAvailableParentSiteLookups) (Return Type : Dictionary<string, string>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_GetAvailableParentSiteLookups_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetAvailableParentSiteLookups, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridganttsettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAvailableParentSiteLookups) (Return Type : Dictionary<string, string>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_GetAvailableParentSiteLookups_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetAvailableParentSiteLookups, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListEvents) (Return Type : List<SPEventReceiverDefinition>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gridganttsettings_GetListEvents_Method_Call_Internally(Type[] types)
        {
            var methodGetListEventsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodGetListEvents, Fixture, methodGetListEventsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetListEvents) (Return Type : List<SPEventReceiverDefinition>) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_GetListEvents_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var assemblyName = CreateType<string>();
            var className = CreateType<string>();
            var types = CreateType<List<SPEventReceiverType>>();
            var methodGetListEventsPrametersTypes = new Type[] { typeof(SPList), typeof(string), typeof(string), typeof(List<SPEventReceiverType>) };
            object[] parametersOfGetListEvents = { list, assemblyName, className, types };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetListEvents, methodGetListEventsPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetListEvents.ShouldNotBeNull();
            parametersOfGetListEvents.Length.ShouldBe(4);
            methodGetListEventsPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => methodInfo.Invoke(_gridganttsettingsInstanceFixture, parametersOfGetListEvents));
        }

        #endregion

        #region Method Call : (GetListEvents) (Return Type : List<SPEventReceiverDefinition>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_GetListEvents_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var assemblyName = CreateType<string>();
            var className = CreateType<string>();
            var types = CreateType<List<SPEventReceiverType>>();
            var methodGetListEventsPrametersTypes = new Type[] { typeof(SPList), typeof(string), typeof(string), typeof(List<SPEventReceiverType>) };
            object[] parametersOfGetListEvents = { list, assemblyName, className, types };

            // Assert
            parametersOfGetListEvents.ShouldNotBeNull();
            parametersOfGetListEvents.Length.ShouldBe(4);
            methodGetListEventsPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<gridganttsettings, List<SPEventReceiverDefinition>>(_gridganttsettingsInstance, MethodGetListEvents, parametersOfGetListEvents, methodGetListEventsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetListEvents) (Return Type : List<SPEventReceiverDefinition>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_GetListEvents_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetListEventsPrametersTypes = new Type[] { typeof(SPList), typeof(string), typeof(string), typeof(List<SPEventReceiverType>) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodGetListEvents, Fixture, methodGetListEventsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetListEventsPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetListEvents) (Return Type : List<SPEventReceiverDefinition>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_GetListEvents_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetListEventsPrametersTypes = new Type[] { typeof(SPList), typeof(string), typeof(string), typeof(List<SPEventReceiverType>) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodGetListEvents, Fixture, methodGetListEventsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListEventsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListEvents) (Return Type : List<SPEventReceiverDefinition>) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_GetListEvents_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListEvents, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridganttsettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetListEvents) (Return Type : List<SPEventReceiverDefinition>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_GetListEvents_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetListEvents, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddGridGanttToViews) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gridganttsettings_AddGridGanttToViews_Method_Call_Internally(Type[] types)
        {
            var methodAddGridGanttToViewsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodAddGridGanttToViews, Fixture, methodAddGridGanttToViewsPrametersTypes);
        }

        #endregion

        #region Method Call : (AddGridGanttToViews) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_AddGridGanttToViews_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodAddGridGanttToViewsPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfAddGridGanttToViews = { list };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddGridGanttToViews, methodAddGridGanttToViewsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridganttsettingsInstanceFixture, parametersOfAddGridGanttToViews);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddGridGanttToViews.ShouldNotBeNull();
            parametersOfAddGridGanttToViews.Length.ShouldBe(1);
            methodAddGridGanttToViewsPrametersTypes.Length.ShouldBe(1);
            methodAddGridGanttToViewsPrametersTypes.Length.ShouldBe(parametersOfAddGridGanttToViews.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddGridGanttToViews) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_AddGridGanttToViews_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodAddGridGanttToViewsPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfAddGridGanttToViews = { list };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridganttsettingsInstance, MethodAddGridGanttToViews, parametersOfAddGridGanttToViews, methodAddGridGanttToViewsPrametersTypes);

            // Assert
            parametersOfAddGridGanttToViews.ShouldNotBeNull();
            parametersOfAddGridGanttToViews.Length.ShouldBe(1);
            methodAddGridGanttToViewsPrametersTypes.Length.ShouldBe(1);
            methodAddGridGanttToViewsPrametersTypes.Length.ShouldBe(parametersOfAddGridGanttToViews.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddGridGanttToViews) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_AddGridGanttToViews_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddGridGanttToViews, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddGridGanttToViews) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_AddGridGanttToViews_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddGridGanttToViewsPrametersTypes = new Type[] { typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodAddGridGanttToViews, Fixture, methodAddGridGanttToViewsPrametersTypes);

            // Assert
            methodAddGridGanttToViewsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddGridGanttToViews) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_AddGridGanttToViews_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddGridGanttToViews, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridganttsettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RemoveEventHandlers) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gridganttsettings_RemoveEventHandlers_Method_Call_Internally(Type[] types)
        {
            var methodRemoveEventHandlersPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodRemoveEventHandlers, Fixture, methodRemoveEventHandlersPrametersTypes);
        }

        #endregion

        #region Method Call : (RemoveEventHandlers) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_RemoveEventHandlers_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodRemoveEventHandlersPrametersTypes = null;
            object[] parametersOfRemoveEventHandlers = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRemoveEventHandlers, methodRemoveEventHandlersPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridganttsettingsInstanceFixture, parametersOfRemoveEventHandlers);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRemoveEventHandlers.ShouldBeNull();
            methodRemoveEventHandlersPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RemoveEventHandlers) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_RemoveEventHandlers_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRemoveEventHandlersPrametersTypes = null;
            object[] parametersOfRemoveEventHandlers = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridganttsettingsInstance, MethodRemoveEventHandlers, parametersOfRemoveEventHandlers, methodRemoveEventHandlersPrametersTypes);

            // Assert
            parametersOfRemoveEventHandlers.ShouldBeNull();
            methodRemoveEventHandlersPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RemoveEventHandlers) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_RemoveEventHandlers_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRemoveEventHandlersPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodRemoveEventHandlers, Fixture, methodRemoveEventHandlersPrametersTypes);

            // Assert
            methodRemoveEventHandlersPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RemoveEventHandlers) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_RemoveEventHandlers_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRemoveEventHandlers, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridganttsettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddFieldsAndFixLookupFields) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gridganttsettings_AddFieldsAndFixLookupFields_Method_Call_Internally(Type[] types)
        {
            var methodAddFieldsAndFixLookupFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodAddFieldsAndFixLookupFields, Fixture, methodAddFieldsAndFixLookupFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (AddFieldsAndFixLookupFields) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_AddFieldsAndFixLookupFields_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodAddFieldsAndFixLookupFieldsPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfAddFieldsAndFixLookupFields = { list };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddFieldsAndFixLookupFields, methodAddFieldsAndFixLookupFieldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridganttsettingsInstanceFixture, parametersOfAddFieldsAndFixLookupFields);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddFieldsAndFixLookupFields.ShouldNotBeNull();
            parametersOfAddFieldsAndFixLookupFields.Length.ShouldBe(1);
            methodAddFieldsAndFixLookupFieldsPrametersTypes.Length.ShouldBe(1);
            methodAddFieldsAndFixLookupFieldsPrametersTypes.Length.ShouldBe(parametersOfAddFieldsAndFixLookupFields.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddFieldsAndFixLookupFields) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_AddFieldsAndFixLookupFields_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodAddFieldsAndFixLookupFieldsPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfAddFieldsAndFixLookupFields = { list };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridganttsettingsInstance, MethodAddFieldsAndFixLookupFields, parametersOfAddFieldsAndFixLookupFields, methodAddFieldsAndFixLookupFieldsPrametersTypes);

            // Assert
            parametersOfAddFieldsAndFixLookupFields.ShouldNotBeNull();
            parametersOfAddFieldsAndFixLookupFields.Length.ShouldBe(1);
            methodAddFieldsAndFixLookupFieldsPrametersTypes.Length.ShouldBe(1);
            methodAddFieldsAndFixLookupFieldsPrametersTypes.Length.ShouldBe(parametersOfAddFieldsAndFixLookupFields.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddFieldsAndFixLookupFields) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_AddFieldsAndFixLookupFields_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddFieldsAndFixLookupFields, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddFieldsAndFixLookupFields) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_AddFieldsAndFixLookupFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddFieldsAndFixLookupFieldsPrametersTypes = new Type[] { typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodAddFieldsAndFixLookupFields, Fixture, methodAddFieldsAndFixLookupFieldsPrametersTypes);

            // Assert
            methodAddFieldsAndFixLookupFieldsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddFieldsAndFixLookupFields) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_AddFieldsAndFixLookupFields_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddFieldsAndFixLookupFields, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridganttsettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddEventHandlers) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gridganttsettings_AddEventHandlers_Method_Call_Internally(Type[] types)
        {
            var methodAddEventHandlersPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodAddEventHandlers, Fixture, methodAddEventHandlersPrametersTypes);
        }

        #endregion

        #region Method Call : (AddEventHandlers) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_AddEventHandlers_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodAddEventHandlersPrametersTypes = null;
            object[] parametersOfAddEventHandlers = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddEventHandlers, methodAddEventHandlersPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridganttsettingsInstanceFixture, parametersOfAddEventHandlers);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddEventHandlers.ShouldBeNull();
            methodAddEventHandlersPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddEventHandlers) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_AddEventHandlers_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodAddEventHandlersPrametersTypes = null;
            object[] parametersOfAddEventHandlers = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridganttsettingsInstance, MethodAddEventHandlers, parametersOfAddEventHandlers, methodAddEventHandlersPrametersTypes);

            // Assert
            parametersOfAddEventHandlers.ShouldBeNull();
            methodAddEventHandlersPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddEventHandlers) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_AddEventHandlers_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodAddEventHandlersPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodAddEventHandlers, Fixture, methodAddEventHandlersPrametersTypes);

            // Assert
            methodAddEventHandlersPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddEventHandlers) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_AddEventHandlers_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddEventHandlers, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridganttsettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FixLookupFields) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gridganttsettings_FixLookupFields_Method_Call_Internally(Type[] types)
        {
            var methodFixLookupFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodFixLookupFields, Fixture, methodFixLookupFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (FixLookupFields) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_FixLookupFields_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodFixLookupFieldsPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfFixLookupFields = { list };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodFixLookupFields, methodFixLookupFieldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridganttsettingsInstanceFixture, parametersOfFixLookupFields);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfFixLookupFields.ShouldNotBeNull();
            parametersOfFixLookupFields.Length.ShouldBe(1);
            methodFixLookupFieldsPrametersTypes.Length.ShouldBe(1);
            methodFixLookupFieldsPrametersTypes.Length.ShouldBe(parametersOfFixLookupFields.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (FixLookupFields) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_FixLookupFields_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodFixLookupFieldsPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfFixLookupFields = { list };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridganttsettingsInstance, MethodFixLookupFields, parametersOfFixLookupFields, methodFixLookupFieldsPrametersTypes);

            // Assert
            parametersOfFixLookupFields.ShouldNotBeNull();
            parametersOfFixLookupFields.Length.ShouldBe(1);
            methodFixLookupFieldsPrametersTypes.Length.ShouldBe(1);
            methodFixLookupFieldsPrametersTypes.Length.ShouldBe(parametersOfFixLookupFields.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FixLookupFields) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_FixLookupFields_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodFixLookupFields, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FixLookupFields) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_FixLookupFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFixLookupFieldsPrametersTypes = new Type[] { typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodFixLookupFields, Fixture, methodFixLookupFieldsPrametersTypes);

            // Assert
            methodFixLookupFieldsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FixLookupFields) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_FixLookupFields_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFixLookupFields, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridganttsettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnableWorkengineListFeatures) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gridganttsettings_EnableWorkengineListFeatures_Method_Call_Internally(Type[] types)
        {
            var methodEnableWorkengineListFeaturesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodEnableWorkengineListFeatures, Fixture, methodEnableWorkengineListFeaturesPrametersTypes);
        }

        #endregion

        #region Method Call : (EnableWorkengineListFeatures) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_EnableWorkengineListFeatures_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodEnableWorkengineListFeaturesPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfEnableWorkengineListFeatures = { list };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodEnableWorkengineListFeatures, methodEnableWorkengineListFeaturesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridganttsettingsInstanceFixture, parametersOfEnableWorkengineListFeatures);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfEnableWorkengineListFeatures.ShouldNotBeNull();
            parametersOfEnableWorkengineListFeatures.Length.ShouldBe(1);
            methodEnableWorkengineListFeaturesPrametersTypes.Length.ShouldBe(1);
            methodEnableWorkengineListFeaturesPrametersTypes.Length.ShouldBe(parametersOfEnableWorkengineListFeatures.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (EnableWorkengineListFeatures) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_EnableWorkengineListFeatures_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodEnableWorkengineListFeaturesPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfEnableWorkengineListFeatures = { list };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridganttsettingsInstance, MethodEnableWorkengineListFeatures, parametersOfEnableWorkengineListFeatures, methodEnableWorkengineListFeaturesPrametersTypes);

            // Assert
            parametersOfEnableWorkengineListFeatures.ShouldNotBeNull();
            parametersOfEnableWorkengineListFeatures.Length.ShouldBe(1);
            methodEnableWorkengineListFeaturesPrametersTypes.Length.ShouldBe(1);
            methodEnableWorkengineListFeaturesPrametersTypes.Length.ShouldBe(parametersOfEnableWorkengineListFeatures.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnableWorkengineListFeatures) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_EnableWorkengineListFeatures_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodEnableWorkengineListFeatures, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (EnableWorkengineListFeatures) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_EnableWorkengineListFeatures_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodEnableWorkengineListFeaturesPrametersTypes = new Type[] { typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodEnableWorkengineListFeatures, Fixture, methodEnableWorkengineListFeaturesPrametersTypes);

            // Assert
            methodEnableWorkengineListFeaturesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnableWorkengineListFeatures) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_EnableWorkengineListFeatures_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodEnableWorkengineListFeatures, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridganttsettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddRemoveMyWorkReportingEvents) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gridganttsettings_AddRemoveMyWorkReportingEvents_Method_Call_Internally(Type[] types)
        {
            var methodAddRemoveMyWorkReportingEventsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodAddRemoveMyWorkReportingEvents, Fixture, methodAddRemoveMyWorkReportingEventsPrametersTypes);
        }

        #endregion

        #region Method Call : (AddRemoveMyWorkReportingEvents) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_AddRemoveMyWorkReportingEvents_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var operation = CreateType<string>();
            var methodAddRemoveMyWorkReportingEventsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfAddRemoveMyWorkReportingEvents = { operation };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddRemoveMyWorkReportingEvents, methodAddRemoveMyWorkReportingEventsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridganttsettingsInstanceFixture, parametersOfAddRemoveMyWorkReportingEvents);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddRemoveMyWorkReportingEvents.ShouldNotBeNull();
            parametersOfAddRemoveMyWorkReportingEvents.Length.ShouldBe(1);
            methodAddRemoveMyWorkReportingEventsPrametersTypes.Length.ShouldBe(1);
            methodAddRemoveMyWorkReportingEventsPrametersTypes.Length.ShouldBe(parametersOfAddRemoveMyWorkReportingEvents.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddRemoveMyWorkReportingEvents) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_AddRemoveMyWorkReportingEvents_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var operation = CreateType<string>();
            var methodAddRemoveMyWorkReportingEventsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfAddRemoveMyWorkReportingEvents = { operation };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridganttsettingsInstance, MethodAddRemoveMyWorkReportingEvents, parametersOfAddRemoveMyWorkReportingEvents, methodAddRemoveMyWorkReportingEventsPrametersTypes);

            // Assert
            parametersOfAddRemoveMyWorkReportingEvents.ShouldNotBeNull();
            parametersOfAddRemoveMyWorkReportingEvents.Length.ShouldBe(1);
            methodAddRemoveMyWorkReportingEventsPrametersTypes.Length.ShouldBe(1);
            methodAddRemoveMyWorkReportingEventsPrametersTypes.Length.ShouldBe(parametersOfAddRemoveMyWorkReportingEvents.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddRemoveMyWorkReportingEvents) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_AddRemoveMyWorkReportingEvents_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddRemoveMyWorkReportingEvents, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddRemoveMyWorkReportingEvents) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_AddRemoveMyWorkReportingEvents_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddRemoveMyWorkReportingEventsPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodAddRemoveMyWorkReportingEvents, Fixture, methodAddRemoveMyWorkReportingEventsPrametersTypes);

            // Assert
            methodAddRemoveMyWorkReportingEventsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddRemoveMyWorkReportingEvents) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_AddRemoveMyWorkReportingEvents_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddRemoveMyWorkReportingEvents, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridganttsettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddEventReceiverElement) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gridganttsettings_AddEventReceiverElement_Method_Call_Internally(Type[] types)
        {
            var methodAddEventReceiverElementPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodAddEventReceiverElement, Fixture, methodAddEventReceiverElementPrametersTypes);
        }

        #endregion

        #region Method Call : (AddEventReceiverElement) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_AddEventReceiverElement_Method_Call_Void_With_6_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var operation = CreateType<string>();
            var className = CreateType<string>();
            var assembly = CreateType<string>();
            var spEventReceiverTypes = CreateType<IEnumerable<SPEventReceiverType>>();
            var listId = CreateType<Guid>();
            var dataElement = CreateType<XElement>();
            var methodAddEventReceiverElementPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(IEnumerable<SPEventReceiverType>), typeof(Guid), typeof(XElement) };
            object[] parametersOfAddEventReceiverElement = { operation, className, assembly, spEventReceiverTypes, listId, dataElement };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddEventReceiverElement, methodAddEventReceiverElementPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridganttsettingsInstanceFixture, parametersOfAddEventReceiverElement);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddEventReceiverElement.ShouldNotBeNull();
            parametersOfAddEventReceiverElement.Length.ShouldBe(6);
            methodAddEventReceiverElementPrametersTypes.Length.ShouldBe(6);
            methodAddEventReceiverElementPrametersTypes.Length.ShouldBe(parametersOfAddEventReceiverElement.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddEventReceiverElement) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_AddEventReceiverElement_Method_Call_Void_With_6_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var operation = CreateType<string>();
            var className = CreateType<string>();
            var assembly = CreateType<string>();
            var spEventReceiverTypes = CreateType<IEnumerable<SPEventReceiverType>>();
            var listId = CreateType<Guid>();
            var dataElement = CreateType<XElement>();
            var methodAddEventReceiverElementPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(IEnumerable<SPEventReceiverType>), typeof(Guid), typeof(XElement) };
            object[] parametersOfAddEventReceiverElement = { operation, className, assembly, spEventReceiverTypes, listId, dataElement };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridganttsettingsInstance, MethodAddEventReceiverElement, parametersOfAddEventReceiverElement, methodAddEventReceiverElementPrametersTypes);

            // Assert
            parametersOfAddEventReceiverElement.ShouldNotBeNull();
            parametersOfAddEventReceiverElement.Length.ShouldBe(6);
            methodAddEventReceiverElementPrametersTypes.Length.ShouldBe(6);
            methodAddEventReceiverElementPrametersTypes.Length.ShouldBe(parametersOfAddEventReceiverElement.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddEventReceiverElement) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_AddEventReceiverElement_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddEventReceiverElement, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddEventReceiverElement) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_AddEventReceiverElement_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddEventReceiverElementPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(IEnumerable<SPEventReceiverType>), typeof(Guid), typeof(XElement) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodAddEventReceiverElement, Fixture, methodAddEventReceiverElementPrametersTypes);

            // Assert
            methodAddEventReceiverElementPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddEventReceiverElement) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_AddEventReceiverElement_Method_Call_With_6_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddEventReceiverElement, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridganttsettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RemoveWorkengineListFeatures) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gridganttsettings_RemoveWorkengineListFeatures_Method_Call_Internally(Type[] types)
        {
            var methodRemoveWorkengineListFeaturesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodRemoveWorkengineListFeatures, Fixture, methodRemoveWorkengineListFeaturesPrametersTypes);
        }

        #endregion

        #region Method Call : (RemoveWorkengineListFeatures) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_RemoveWorkengineListFeatures_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodRemoveWorkengineListFeaturesPrametersTypes = null;
            object[] parametersOfRemoveWorkengineListFeatures = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRemoveWorkengineListFeatures, methodRemoveWorkengineListFeaturesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridganttsettingsInstanceFixture, parametersOfRemoveWorkengineListFeatures);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRemoveWorkengineListFeatures.ShouldBeNull();
            methodRemoveWorkengineListFeaturesPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RemoveWorkengineListFeatures) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_RemoveWorkengineListFeatures_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRemoveWorkengineListFeaturesPrametersTypes = null;
            object[] parametersOfRemoveWorkengineListFeatures = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridganttsettingsInstance, MethodRemoveWorkengineListFeatures, parametersOfRemoveWorkengineListFeatures, methodRemoveWorkengineListFeaturesPrametersTypes);

            // Assert
            parametersOfRemoveWorkengineListFeatures.ShouldBeNull();
            methodRemoveWorkengineListFeaturesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RemoveWorkengineListFeatures) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_RemoveWorkengineListFeatures_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRemoveWorkengineListFeaturesPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodRemoveWorkengineListFeatures, Fixture, methodRemoveWorkengineListFeaturesPrametersTypes);

            // Assert
            methodRemoveWorkengineListFeaturesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RemoveWorkengineListFeatures) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_RemoveWorkengineListFeatures_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRemoveWorkengineListFeatures, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridganttsettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Button1_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gridganttsettings_Button1_Click_Method_Call_Internally(Type[] types)
        {
            var methodButton1_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodButton1_Click, Fixture, methodButton1_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (Button1_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_Button1_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodButton1_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfButton1_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodButton1_Click, methodButton1_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridganttsettingsInstanceFixture, parametersOfButton1_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfButton1_Click.ShouldNotBeNull();
            parametersOfButton1_Click.Length.ShouldBe(2);
            methodButton1_ClickPrametersTypes.Length.ShouldBe(2);
            methodButton1_ClickPrametersTypes.Length.ShouldBe(parametersOfButton1_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Button1_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_Button1_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodButton1_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfButton1_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridganttsettingsInstance, MethodButton1_Click, parametersOfButton1_Click, methodButton1_ClickPrametersTypes);

            // Assert
            parametersOfButton1_Click.ShouldNotBeNull();
            parametersOfButton1_Click.Length.ShouldBe(2);
            methodButton1_ClickPrametersTypes.Length.ShouldBe(2);
            methodButton1_ClickPrametersTypes.Length.ShouldBe(parametersOfButton1_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Button1_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_Button1_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodButton1_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Button1_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_Button1_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodButton1_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodButton1_Click, Fixture, methodButton1_ClickPrametersTypes);

            // Assert
            methodButton1_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Button1_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_Button1_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodButton1_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridganttsettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetListIcon) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gridganttsettings_SetListIcon_Method_Call_Internally(Type[] types)
        {
            var methodSetListIconPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodSetListIcon, Fixture, methodSetListIconPrametersTypes);
        }

        #endregion

        #region Method Call : (SetListIcon) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_SetListIcon_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var icon = CreateType<string>();
            var methodSetListIconPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSetListIcon = { icon };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetListIcon, methodSetListIconPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridganttsettingsInstanceFixture, parametersOfSetListIcon);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetListIcon.ShouldNotBeNull();
            parametersOfSetListIcon.Length.ShouldBe(1);
            methodSetListIconPrametersTypes.Length.ShouldBe(1);
            methodSetListIconPrametersTypes.Length.ShouldBe(parametersOfSetListIcon.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetListIcon) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_SetListIcon_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var icon = CreateType<string>();
            var methodSetListIconPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSetListIcon = { icon };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridganttsettingsInstance, MethodSetListIcon, parametersOfSetListIcon, methodSetListIconPrametersTypes);

            // Assert
            parametersOfSetListIcon.ShouldNotBeNull();
            parametersOfSetListIcon.Length.ShouldBe(1);
            methodSetListIconPrametersTypes.Length.ShouldBe(1);
            methodSetListIconPrametersTypes.Length.ShouldBe(parametersOfSetListIcon.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetListIcon) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_SetListIcon_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetListIcon, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetListIcon) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_SetListIcon_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetListIconPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodSetListIcon, Fixture, methodSetListIconPrametersTypes);

            // Assert
            methodSetListIconPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetListIcon) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_SetListIcon_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetListIcon, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridganttsettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListFields) (Return Type : ListItemCollection) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gridganttsettings_GetListFields_Method_Call_Internally(Type[] types)
        {
            var methodGetListFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodGetListFields, Fixture, methodGetListFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetListFields) (Return Type : ListItemCollection) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_GetListFields_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var spList = CreateType<SPList>();
            var methodGetListFieldsPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfGetListFields = { spList };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetListFields, methodGetListFieldsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<gridganttsettings, ListItemCollection>(_gridganttsettingsInstanceFixture, out exception1, parametersOfGetListFields);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<gridganttsettings, ListItemCollection>(_gridganttsettingsInstance, MethodGetListFields, parametersOfGetListFields, methodGetListFieldsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetListFields.ShouldNotBeNull();
            parametersOfGetListFields.Length.ShouldBe(1);
            methodGetListFieldsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_gridganttsettingsInstanceFixture, parametersOfGetListFields));
        }

        #endregion

        #region Method Call : (GetListFields) (Return Type : ListItemCollection) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_GetListFields_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spList = CreateType<SPList>();
            var methodGetListFieldsPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfGetListFields = { spList };

            // Assert
            parametersOfGetListFields.ShouldNotBeNull();
            parametersOfGetListFields.Length.ShouldBe(1);
            methodGetListFieldsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<gridganttsettings, ListItemCollection>(_gridganttsettingsInstance, MethodGetListFields, parametersOfGetListFields, methodGetListFieldsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetListFields) (Return Type : ListItemCollection) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_GetListFields_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetListFieldsPrametersTypes = new Type[] { typeof(SPList) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodGetListFields, Fixture, methodGetListFieldsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetListFieldsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetListFields) (Return Type : ListItemCollection) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_GetListFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetListFieldsPrametersTypes = new Type[] { typeof(SPList) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodGetListFields, Fixture, methodGetListFieldsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListFieldsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListFields) (Return Type : ListItemCollection) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_GetListFields_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListFields, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridganttsettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListFields) (Return Type : ListItemCollection) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_GetListFields_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetListFields, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DisableFancyForms) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gridganttsettings_DisableFancyForms_Method_Call_Internally(Type[] types)
        {
            var methodDisableFancyFormsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodDisableFancyForms, Fixture, methodDisableFancyFormsPrametersTypes);
        }

        #endregion

        #region Method Call : (DisableFancyForms) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_DisableFancyForms_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodDisableFancyFormsPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfDisableFancyForms = { list };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDisableFancyForms, methodDisableFancyFormsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridganttsettingsInstanceFixture, parametersOfDisableFancyForms);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDisableFancyForms.ShouldNotBeNull();
            parametersOfDisableFancyForms.Length.ShouldBe(1);
            methodDisableFancyFormsPrametersTypes.Length.ShouldBe(1);
            methodDisableFancyFormsPrametersTypes.Length.ShouldBe(parametersOfDisableFancyForms.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DisableFancyForms) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_DisableFancyForms_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodDisableFancyFormsPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfDisableFancyForms = { list };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridganttsettingsInstance, MethodDisableFancyForms, parametersOfDisableFancyForms, methodDisableFancyFormsPrametersTypes);

            // Assert
            parametersOfDisableFancyForms.ShouldNotBeNull();
            parametersOfDisableFancyForms.Length.ShouldBe(1);
            methodDisableFancyFormsPrametersTypes.Length.ShouldBe(1);
            methodDisableFancyFormsPrametersTypes.Length.ShouldBe(parametersOfDisableFancyForms.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DisableFancyForms) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_DisableFancyForms_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDisableFancyForms, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DisableFancyForms) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_DisableFancyForms_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDisableFancyFormsPrametersTypes = new Type[] { typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodDisableFancyForms, Fixture, methodDisableFancyFormsPrametersTypes);

            // Assert
            methodDisableFancyFormsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DisableFancyForms) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_DisableFancyForms_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDisableFancyForms, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridganttsettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnableFancyForms) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gridganttsettings_EnableFancyForms_Method_Call_Internally(Type[] types)
        {
            var methodEnableFancyFormsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodEnableFancyForms, Fixture, methodEnableFancyFormsPrametersTypes);
        }

        #endregion

        #region Method Call : (EnableFancyForms) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_EnableFancyForms_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodEnableFancyFormsPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfEnableFancyForms = { list };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodEnableFancyForms, methodEnableFancyFormsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridganttsettingsInstanceFixture, parametersOfEnableFancyForms);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfEnableFancyForms.ShouldNotBeNull();
            parametersOfEnableFancyForms.Length.ShouldBe(1);
            methodEnableFancyFormsPrametersTypes.Length.ShouldBe(1);
            methodEnableFancyFormsPrametersTypes.Length.ShouldBe(parametersOfEnableFancyForms.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnableFancyForms) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_EnableFancyForms_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodEnableFancyFormsPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfEnableFancyForms = { list };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridganttsettingsInstance, MethodEnableFancyForms, parametersOfEnableFancyForms, methodEnableFancyFormsPrametersTypes);

            // Assert
            parametersOfEnableFancyForms.ShouldNotBeNull();
            parametersOfEnableFancyForms.Length.ShouldBe(1);
            methodEnableFancyFormsPrametersTypes.Length.ShouldBe(1);
            methodEnableFancyFormsPrametersTypes.Length.ShouldBe(parametersOfEnableFancyForms.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnableFancyForms) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_EnableFancyForms_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodEnableFancyForms, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (EnableFancyForms) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_EnableFancyForms_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodEnableFancyFormsPrametersTypes = new Type[] { typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodEnableFancyForms, Fixture, methodEnableFancyFormsPrametersTypes);

            // Assert
            methodEnableFancyFormsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnableFancyForms) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_EnableFancyForms_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodEnableFancyForms, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridganttsettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddReportEvent) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gridganttsettings_AddReportEvent_Method_Call_Internally(Type[] types)
        {
            var methodAddReportEventPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodAddReportEvent, Fixture, methodAddReportEventPrametersTypes);
        }

        #endregion

        #region Method Call : (AddReportEvent) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_AddReportEvent_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodAddReportEventPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfAddReportEvent = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddReportEvent, methodAddReportEventPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridganttsettingsInstanceFixture, parametersOfAddReportEvent);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddReportEvent.ShouldNotBeNull();
            parametersOfAddReportEvent.Length.ShouldBe(2);
            methodAddReportEventPrametersTypes.Length.ShouldBe(2);
            methodAddReportEventPrametersTypes.Length.ShouldBe(parametersOfAddReportEvent.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddReportEvent) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_AddReportEvent_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodAddReportEventPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfAddReportEvent = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridganttsettingsInstance, MethodAddReportEvent, parametersOfAddReportEvent, methodAddReportEventPrametersTypes);

            // Assert
            parametersOfAddReportEvent.ShouldNotBeNull();
            parametersOfAddReportEvent.Length.ShouldBe(2);
            methodAddReportEventPrametersTypes.Length.ShouldBe(2);
            methodAddReportEventPrametersTypes.Length.ShouldBe(parametersOfAddReportEvent.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddReportEvent) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_AddReportEvent_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddReportEvent, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddReportEvent) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_AddReportEvent_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddReportEventPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodAddReportEvent, Fixture, methodAddReportEventPrametersTypes);

            // Assert
            methodAddReportEventPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddReportEvent) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_AddReportEvent_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddReportEvent, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridganttsettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ShowAlert) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gridganttsettings_ShowAlert_Method_Call_Internally(Type[] types)
        {
            var methodShowAlertPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodShowAlert, Fixture, methodShowAlertPrametersTypes);
        }

        #endregion

        #region Method Call : (ShowAlert) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_ShowAlert_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodShowAlertPrametersTypes = null;
            object[] parametersOfShowAlert = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodShowAlert, methodShowAlertPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridganttsettingsInstanceFixture, parametersOfShowAlert);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfShowAlert.ShouldBeNull();
            methodShowAlertPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ShowAlert) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_ShowAlert_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodShowAlertPrametersTypes = null;
            object[] parametersOfShowAlert = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridganttsettingsInstance, MethodShowAlert, parametersOfShowAlert, methodShowAlertPrametersTypes);

            // Assert
            parametersOfShowAlert.ShouldBeNull();
            methodShowAlertPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ShowAlert) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_ShowAlert_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodShowAlertPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodShowAlert, Fixture, methodShowAlertPrametersTypes);

            // Assert
            methodShowAlertPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ShowAlert) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_ShowAlert_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodShowAlert, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridganttsettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetRefLists) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gridganttsettings_GetRefLists_Method_Call_Internally(Type[] types)
        {
            var methodGetRefListsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodGetRefLists, Fixture, methodGetRefListsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetRefLists) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_GetRefLists_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var refTables = CreateType<DataTable>();
            var dao = CreateType<EPMData>();
            var methodGetRefListsPrametersTypes = new Type[] { typeof(DataTable), typeof(EPMData) };
            object[] parametersOfGetRefLists = { refTables, dao };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetRefLists, methodGetRefListsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<gridganttsettings, string>(_gridganttsettingsInstanceFixture, out exception1, parametersOfGetRefLists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<gridganttsettings, string>(_gridganttsettingsInstance, MethodGetRefLists, parametersOfGetRefLists, methodGetRefListsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetRefLists.ShouldNotBeNull();
            parametersOfGetRefLists.Length.ShouldBe(2);
            methodGetRefListsPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(() => methodInfo.Invoke(_gridganttsettingsInstanceFixture, parametersOfGetRefLists));
        }

        #endregion

        #region Method Call : (GetRefLists) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_GetRefLists_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var refTables = CreateType<DataTable>();
            var dao = CreateType<EPMData>();
            var methodGetRefListsPrametersTypes = new Type[] { typeof(DataTable), typeof(EPMData) };
            object[] parametersOfGetRefLists = { refTables, dao };

            // Assert
            parametersOfGetRefLists.ShouldNotBeNull();
            parametersOfGetRefLists.Length.ShouldBe(2);
            methodGetRefListsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<gridganttsettings, string>(_gridganttsettingsInstance, MethodGetRefLists, parametersOfGetRefLists, methodGetRefListsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetRefLists) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_GetRefLists_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetRefListsPrametersTypes = new Type[] { typeof(DataTable), typeof(EPMData) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodGetRefLists, Fixture, methodGetRefListsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetRefListsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetRefLists) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_GetRefLists_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetRefListsPrametersTypes = new Type[] { typeof(DataTable), typeof(EPMData) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodGetRefLists, Fixture, methodGetRefListsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetRefListsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRefLists) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_GetRefLists_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetRefLists, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridganttsettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRefLists) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_GetRefLists_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetRefLists, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (EnableSiteFeature) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gridganttsettings_EnableSiteFeature_Method_Call_Internally(Type[] types)
        {
            var methodEnableSiteFeaturePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodEnableSiteFeature, Fixture, methodEnableSiteFeaturePrametersTypes);
        }

        #endregion

        #region Method Call : (EnableSiteFeature) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_EnableSiteFeature_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodEnableSiteFeaturePrametersTypes = null;
            object[] parametersOfEnableSiteFeature = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodEnableSiteFeature, methodEnableSiteFeaturePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridganttsettingsInstanceFixture, parametersOfEnableSiteFeature);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfEnableSiteFeature.ShouldBeNull();
            methodEnableSiteFeaturePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnableSiteFeature) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_EnableSiteFeature_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodEnableSiteFeaturePrametersTypes = null;
            object[] parametersOfEnableSiteFeature = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridganttsettingsInstance, MethodEnableSiteFeature, parametersOfEnableSiteFeature, methodEnableSiteFeaturePrametersTypes);

            // Assert
            parametersOfEnableSiteFeature.ShouldBeNull();
            methodEnableSiteFeaturePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnableSiteFeature) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_EnableSiteFeature_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodEnableSiteFeaturePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodEnableSiteFeature, Fixture, methodEnableSiteFeaturePrametersTypes);

            // Assert
            methodEnableSiteFeaturePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnableSiteFeature) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_EnableSiteFeature_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodEnableSiteFeature, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridganttsettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearLookupReferences) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gridganttsettings_ClearLookupReferences_Method_Call_Internally(Type[] types)
        {
            var methodClearLookupReferencesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodClearLookupReferences, Fixture, methodClearLookupReferencesPrametersTypes);
        }

        #endregion

        #region Method Call : (ClearLookupReferences) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_ClearLookupReferences_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var lookupField = CreateType<SPFieldLookup>();
            Action executeAction = null;

            // Act
            executeAction = () => _gridganttsettingsInstance.ClearLookupReferences(lookupField);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ClearLookupReferences) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_ClearLookupReferences_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var lookupField = CreateType<SPFieldLookup>();
            var methodClearLookupReferencesPrametersTypes = new Type[] { typeof(SPFieldLookup) };
            object[] parametersOfClearLookupReferences = { lookupField };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodClearLookupReferences, methodClearLookupReferencesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridganttsettingsInstanceFixture, parametersOfClearLookupReferences);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfClearLookupReferences.ShouldNotBeNull();
            parametersOfClearLookupReferences.Length.ShouldBe(1);
            methodClearLookupReferencesPrametersTypes.Length.ShouldBe(1);
            methodClearLookupReferencesPrametersTypes.Length.ShouldBe(parametersOfClearLookupReferences.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ClearLookupReferences) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_ClearLookupReferences_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var lookupField = CreateType<SPFieldLookup>();
            var methodClearLookupReferencesPrametersTypes = new Type[] { typeof(SPFieldLookup) };
            object[] parametersOfClearLookupReferences = { lookupField };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridganttsettingsInstance, MethodClearLookupReferences, parametersOfClearLookupReferences, methodClearLookupReferencesPrametersTypes);

            // Assert
            parametersOfClearLookupReferences.ShouldNotBeNull();
            parametersOfClearLookupReferences.Length.ShouldBe(1);
            methodClearLookupReferencesPrametersTypes.Length.ShouldBe(1);
            methodClearLookupReferencesPrametersTypes.Length.ShouldBe(parametersOfClearLookupReferences.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearLookupReferences) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_ClearLookupReferences_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodClearLookupReferences, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ClearLookupReferences) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_ClearLookupReferences_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodClearLookupReferencesPrametersTypes = new Type[] { typeof(SPFieldLookup) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodClearLookupReferences, Fixture, methodClearLookupReferencesPrametersTypes);

            // Assert
            methodClearLookupReferencesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearLookupReferences) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_ClearLookupReferences_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodClearLookupReferences, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridganttsettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateLookupReferences) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gridganttsettings_UpdateLookupReferences_Method_Call_Internally(Type[] types)
        {
            var methodUpdateLookupReferencesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodUpdateLookupReferences, Fixture, methodUpdateLookupReferencesPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateLookupReferences) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_UpdateLookupReferences_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var lookupField = CreateType<SPFieldLookup>();
            var web = CreateType<SPWeb>();
            var list = CreateType<SPList>();
            Action executeAction = null;

            // Act
            executeAction = () => _gridganttsettingsInstance.UpdateLookupReferences(lookupField, web, list);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateLookupReferences) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_UpdateLookupReferences_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var lookupField = CreateType<SPFieldLookup>();
            var web = CreateType<SPWeb>();
            var list = CreateType<SPList>();
            var methodUpdateLookupReferencesPrametersTypes = new Type[] { typeof(SPFieldLookup), typeof(SPWeb), typeof(SPList) };
            object[] parametersOfUpdateLookupReferences = { lookupField, web, list };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateLookupReferences, methodUpdateLookupReferencesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridganttsettingsInstanceFixture, parametersOfUpdateLookupReferences);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateLookupReferences.ShouldNotBeNull();
            parametersOfUpdateLookupReferences.Length.ShouldBe(3);
            methodUpdateLookupReferencesPrametersTypes.Length.ShouldBe(3);
            methodUpdateLookupReferencesPrametersTypes.Length.ShouldBe(parametersOfUpdateLookupReferences.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateLookupReferences) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_UpdateLookupReferences_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var lookupField = CreateType<SPFieldLookup>();
            var web = CreateType<SPWeb>();
            var list = CreateType<SPList>();
            var methodUpdateLookupReferencesPrametersTypes = new Type[] { typeof(SPFieldLookup), typeof(SPWeb), typeof(SPList) };
            object[] parametersOfUpdateLookupReferences = { lookupField, web, list };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridganttsettingsInstance, MethodUpdateLookupReferences, parametersOfUpdateLookupReferences, methodUpdateLookupReferencesPrametersTypes);

            // Assert
            parametersOfUpdateLookupReferences.ShouldNotBeNull();
            parametersOfUpdateLookupReferences.Length.ShouldBe(3);
            methodUpdateLookupReferencesPrametersTypes.Length.ShouldBe(3);
            methodUpdateLookupReferencesPrametersTypes.Length.ShouldBe(parametersOfUpdateLookupReferences.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateLookupReferences) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_UpdateLookupReferences_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateLookupReferences, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateLookupReferences) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_UpdateLookupReferences_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateLookupReferencesPrametersTypes = new Type[] { typeof(SPFieldLookup), typeof(SPWeb), typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodUpdateLookupReferences, Fixture, methodUpdateLookupReferencesPrametersTypes);

            // Assert
            methodUpdateLookupReferencesPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateLookupReferences) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_UpdateLookupReferences_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateLookupReferences, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridganttsettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReplaceXmlAttributeValue) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gridganttsettings_ReplaceXmlAttributeValue_Method_Call_Internally(Type[] types)
        {
            var methodReplaceXmlAttributeValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodReplaceXmlAttributeValue, Fixture, methodReplaceXmlAttributeValuePrametersTypes);
        }

        #endregion

        #region Method Call : (ReplaceXmlAttributeValue) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_ReplaceXmlAttributeValue_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var attributeName = CreateType<string>();
            var value = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _gridganttsettingsInstance.ReplaceXmlAttributeValue(xml, attributeName, value);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ReplaceXmlAttributeValue) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_ReplaceXmlAttributeValue_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var attributeName = CreateType<string>();
            var value = CreateType<string>();
            var methodReplaceXmlAttributeValuePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            object[] parametersOfReplaceXmlAttributeValue = { xml, attributeName, value };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodReplaceXmlAttributeValue, methodReplaceXmlAttributeValuePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<gridganttsettings, string>(_gridganttsettingsInstanceFixture, out exception1, parametersOfReplaceXmlAttributeValue);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<gridganttsettings, string>(_gridganttsettingsInstance, MethodReplaceXmlAttributeValue, parametersOfReplaceXmlAttributeValue, methodReplaceXmlAttributeValuePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfReplaceXmlAttributeValue.ShouldNotBeNull();
            parametersOfReplaceXmlAttributeValue.Length.ShouldBe(3);
            methodReplaceXmlAttributeValuePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<gridganttsettings, string>(_gridganttsettingsInstance, MethodReplaceXmlAttributeValue, parametersOfReplaceXmlAttributeValue, methodReplaceXmlAttributeValuePrametersTypes));
        }

        #endregion

        #region Method Call : (ReplaceXmlAttributeValue) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_ReplaceXmlAttributeValue_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var attributeName = CreateType<string>();
            var value = CreateType<string>();
            var methodReplaceXmlAttributeValuePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            object[] parametersOfReplaceXmlAttributeValue = { xml, attributeName, value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReplaceXmlAttributeValue, methodReplaceXmlAttributeValuePrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReplaceXmlAttributeValue.ShouldNotBeNull();
            parametersOfReplaceXmlAttributeValue.Length.ShouldBe(3);
            methodReplaceXmlAttributeValuePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => methodInfo.Invoke(_gridganttsettingsInstanceFixture, parametersOfReplaceXmlAttributeValue));
        }

        #endregion

        #region Method Call : (ReplaceXmlAttributeValue) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_ReplaceXmlAttributeValue_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var attributeName = CreateType<string>();
            var value = CreateType<string>();
            var methodReplaceXmlAttributeValuePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            object[] parametersOfReplaceXmlAttributeValue = { xml, attributeName, value };

            // Assert
            parametersOfReplaceXmlAttributeValue.ShouldNotBeNull();
            parametersOfReplaceXmlAttributeValue.Length.ShouldBe(3);
            methodReplaceXmlAttributeValuePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<gridganttsettings, string>(_gridganttsettingsInstance, MethodReplaceXmlAttributeValue, parametersOfReplaceXmlAttributeValue, methodReplaceXmlAttributeValuePrametersTypes));
        }

        #endregion

        #region Method Call : (ReplaceXmlAttributeValue) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_ReplaceXmlAttributeValue_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodReplaceXmlAttributeValuePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodReplaceXmlAttributeValue, Fixture, methodReplaceXmlAttributeValuePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodReplaceXmlAttributeValuePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (ReplaceXmlAttributeValue) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_ReplaceXmlAttributeValue_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReplaceXmlAttributeValuePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodReplaceXmlAttributeValue, Fixture, methodReplaceXmlAttributeValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodReplaceXmlAttributeValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReplaceXmlAttributeValue) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_ReplaceXmlAttributeValue_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReplaceXmlAttributeValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridganttsettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ReplaceXmlAttributeValue) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_ReplaceXmlAttributeValue_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReplaceXmlAttributeValue, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FieldExistsInList) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gridganttsettings_FieldExistsInList_Method_Call_Internally(Type[] types)
        {
            var methodFieldExistsInListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodFieldExistsInList, Fixture, methodFieldExistsInListPrametersTypes);
        }

        #endregion

        #region Method Call : (FieldExistsInList) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_FieldExistsInList_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var fldInternalName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _gridganttsettingsInstance.FieldExistsInList(list, fldInternalName);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (FieldExistsInList) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_FieldExistsInList_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var fldInternalName = CreateType<string>();
            var methodFieldExistsInListPrametersTypes = new Type[] { typeof(SPList), typeof(string) };
            object[] parametersOfFieldExistsInList = { list, fldInternalName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodFieldExistsInList, methodFieldExistsInListPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<gridganttsettings, bool>(_gridganttsettingsInstanceFixture, out exception1, parametersOfFieldExistsInList);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<gridganttsettings, bool>(_gridganttsettingsInstance, MethodFieldExistsInList, parametersOfFieldExistsInList, methodFieldExistsInListPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfFieldExistsInList.ShouldNotBeNull();
            parametersOfFieldExistsInList.Length.ShouldBe(2);
            methodFieldExistsInListPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<gridganttsettings, bool>(_gridganttsettingsInstance, MethodFieldExistsInList, parametersOfFieldExistsInList, methodFieldExistsInListPrametersTypes));
        }

        #endregion

        #region Method Call : (FieldExistsInList) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_FieldExistsInList_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var fldInternalName = CreateType<string>();
            var methodFieldExistsInListPrametersTypes = new Type[] { typeof(SPList), typeof(string) };
            object[] parametersOfFieldExistsInList = { list, fldInternalName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodFieldExistsInList, methodFieldExistsInListPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfFieldExistsInList.ShouldNotBeNull();
            parametersOfFieldExistsInList.Length.ShouldBe(2);
            methodFieldExistsInListPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => methodInfo.Invoke(_gridganttsettingsInstanceFixture, parametersOfFieldExistsInList));
        }

        #endregion

        #region Method Call : (FieldExistsInList) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_FieldExistsInList_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var fldInternalName = CreateType<string>();
            var methodFieldExistsInListPrametersTypes = new Type[] { typeof(SPList), typeof(string) };
            object[] parametersOfFieldExistsInList = { list, fldInternalName };

            // Assert
            parametersOfFieldExistsInList.ShouldNotBeNull();
            parametersOfFieldExistsInList.Length.ShouldBe(2);
            methodFieldExistsInListPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<gridganttsettings, bool>(_gridganttsettingsInstance, MethodFieldExistsInList, parametersOfFieldExistsInList, methodFieldExistsInListPrametersTypes));
        }

        #endregion

        #region Method Call : (FieldExistsInList) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_FieldExistsInList_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodFieldExistsInListPrametersTypes = new Type[] { typeof(SPList), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodFieldExistsInList, Fixture, methodFieldExistsInListPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodFieldExistsInListPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (FieldExistsInList) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_FieldExistsInList_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodFieldExistsInListPrametersTypes = new Type[] { typeof(SPList), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodFieldExistsInList, Fixture, methodFieldExistsInListPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodFieldExistsInListPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (FieldExistsInList) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_FieldExistsInList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFieldExistsInListPrametersTypes = new Type[] { typeof(SPList), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridganttsettingsInstance, MethodFieldExistsInList, Fixture, methodFieldExistsInListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodFieldExistsInListPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FieldExistsInList) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_FieldExistsInList_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFieldExistsInList, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridganttsettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (FieldExistsInList) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gridganttsettings_FieldExistsInList_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodFieldExistsInList, 0);
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
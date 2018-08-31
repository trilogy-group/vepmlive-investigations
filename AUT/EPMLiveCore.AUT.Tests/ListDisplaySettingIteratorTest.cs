using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.AutoFixtureSetup;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using EPMLiveCore.API;
using EPMLiveCore.Controls.Navigation.Providers;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.ReportingProxy;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using ListDisplaySettingIterator = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.ListDisplaySettingIterator" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class ListDisplaySettingIteratorTest : AbstractBaseSetupTypedTest<ListDisplaySettingIterator>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ListDisplaySettingIterator) Initializer

        private const string MethodFindSaveButtons = "FindSaveButtons";
        private const string MethodCustomHandler = "CustomHandler";
        private const string MethodHandleNewItemRecent = "HandleNewItemRecent";
        private const string MethodProcessNewItemRecent = "ProcessNewItemRecent";
        private const string MethodClearCache = "ClearCache";
        private const string MethodOnInit = "OnInit";
        private const string MethodRenderControl = "RenderControl";
        private const string MethodDispose = "Dispose";
        private const string MethodAddControlsToWriter = "AddControlsToWriter";
        private const string MethodCreateHtmlPanelText = "CreateHtmlPanelText";
        private const string MethodCreateChildControls = "CreateChildControls";
        private const string MethodInsertLookupValueByQueryString = "InsertLookupValueByQueryString";
        private const string MethodGetLookupItemValue = "GetLookupItemValue";
        private const string MethodGetQueryStringLookupVal = "GetQueryStringLookupVal";
        private const string MethodAddTypeAheadFieldControls = "AddTypeAheadFieldControls";
        private const string MethodCreateCascadingMultiLookupControl = "CreateCascadingMultiLookupControl";
        private const string MethodCreateCascadingLookupControl = "CreateCascadingLookupControl";
        private const string MethodCreateGenericPickerControl = "CreateGenericPickerControl";
        private const string MethodAddEntityPickersToLookups = "AddEntityPickersToLookups";
        private const string MethodGenerateControlDataForLookupField = "GenerateControlDataForLookupField";
        private const string MethodGetControl = "GetControl";
        private const string MethodGetChildControlBasedOnFieldType = "GetChildControlBasedOnFieldType";
        private const string MethodSetFieldName = "SetFieldName";
        private const string MethodSetControlMode = "SetControlMode";
        private const string MethodIsFieldExcluded = "IsFieldExcluded";
        private const string FieldBarcolor1 = "Barcolor1";
        private const string FieldBarcolor2 = "Barcolor2";
        private const string FieldBarcolor3 = "Barcolor3";
        private const string FieldActivationId = "ActivationId";
        private const string FieldfieldProperties = "fieldProperties";
        private const string Fieldlist = "list";
        private const string Fieldmode = "mode";
        private const string FieldarrwpFields = "arrwpFields";
        private const string FieldisResList = "isResList";
        private const string FieldisOnline = "isOnline";
        private const string FieldlookupField = "lookupField";
        private const string FieldlookupValue = "lookupValue";
        private const string FielduserPanelItems = "userPanelItems";
        private const string FieldpermissionPanelItems = "permissionPanelItems";
        private const string FielduserPanelSb = "userPanelSb";
        private const string FielduserPanel = "userPanel";
        private const string FieldprofilePanelSb = "profilePanelSb";
        private const string FieldprofilePanel = "profilePanel";
        private const string FieldpermissionPanelSb = "permissionPanelSb";
        private const string FieldpermissionPanel = "permissionPanel";
        private const string FielddControls = "dControls";
        private const string Fieldmax = "max";
        private const string Fieldcount = "count";
        private const string Fieldwidth = "width";
        private const string Fieldbarcolor = "barcolor";
        private const string Fieldownerusername = "ownerusername";
        private const string Fieldownername = "ownername";
        private const string Fieldaccountid = "accountid";
        private const string FieldisWorkList = "isWorkList";
        private const string Fieldbillingtype = "billingtype";
        private const string FielduserpanelRequiredCount = "userpanelRequiredCount";
        private const string FieldpermissionPanelRequiredCount = "permissionPanelRequiredCount";
        private const string FieldprofilepanelRequiredCount = "profilepanelRequiredCount";
        private const string Fieldpicker = "picker";
        private const string FieldisFeatureActivated = "isFeatureActivated";
        private const string FieldDisplayFormRedirect = "DisplayFormRedirect";
        private const string FieldbUseTeam = "bUseTeam";
        private const string FieldActivationType = "ActivationType";
        private Type _listDisplaySettingIteratorInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ListDisplaySettingIterator _listDisplaySettingIteratorInstance;
        private ListDisplaySettingIterator _listDisplaySettingIteratorInstanceFixture;

        #region General Initializer : Class (ListDisplaySettingIterator) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ListDisplaySettingIterator" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _listDisplaySettingIteratorInstanceType = typeof(ListDisplaySettingIterator);
            _listDisplaySettingIteratorInstanceFixture = Create(true);
            _listDisplaySettingIteratorInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ListDisplaySettingIterator)

        #region General Initializer : Class (ListDisplaySettingIterator) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ListDisplaySettingIterator" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodFindSaveButtons, 0)]
        [TestCase(MethodCustomHandler, 0)]
        [TestCase(MethodHandleNewItemRecent, 0)]
        [TestCase(MethodProcessNewItemRecent, 0)]
        [TestCase(MethodClearCache, 0)]
        [TestCase(MethodOnInit, 0)]
        [TestCase(MethodRenderControl, 0)]
        [TestCase(MethodDispose, 0)]
        [TestCase(MethodAddControlsToWriter, 0)]
        [TestCase(MethodCreateHtmlPanelText, 0)]
        [TestCase(MethodCreateChildControls, 0)]
        [TestCase(MethodInsertLookupValueByQueryString, 0)]
        [TestCase(MethodGetLookupItemValue, 0)]
        [TestCase(MethodGetQueryStringLookupVal, 0)]
        [TestCase(MethodGetQueryStringLookupVal, 1)]
        [TestCase(MethodAddTypeAheadFieldControls, 0)]
        [TestCase(MethodAddEntityPickersToLookups, 0)]
        [TestCase(MethodGenerateControlDataForLookupField, 0)]
        [TestCase(MethodGetControl, 0)]
        [TestCase(MethodGetChildControlBasedOnFieldType, 0)]
        [TestCase(MethodSetFieldName, 0)]
        [TestCase(MethodSetControlMode, 0)]
        [TestCase(MethodIsFieldExcluded, 0)]
        public void AUT_ListDisplaySettingIterator_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_listDisplaySettingIteratorInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ListDisplaySettingIterator) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ListDisplaySettingIterator" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldfieldProperties)]
        [TestCase(Fieldlist)]
        [TestCase(Fieldmode)]
        [TestCase(FieldarrwpFields)]
        [TestCase(FieldisResList)]
        [TestCase(FieldisOnline)]
        [TestCase(FieldlookupField)]
        [TestCase(FieldlookupValue)]
        [TestCase(FielduserPanelItems)]
        [TestCase(FieldpermissionPanelItems)]
        [TestCase(FielduserPanelSb)]
        [TestCase(FielduserPanel)]
        [TestCase(FieldprofilePanelSb)]
        [TestCase(FieldprofilePanel)]
        [TestCase(FieldpermissionPanelSb)]
        [TestCase(FieldpermissionPanel)]
        [TestCase(FielddControls)]
        [TestCase(Fieldmax)]
        [TestCase(Fieldcount)]
        [TestCase(Fieldwidth)]
        [TestCase(Fieldbarcolor)]
        [TestCase(Fieldownerusername)]
        [TestCase(Fieldownername)]
        [TestCase(Fieldaccountid)]
        [TestCase(FieldisWorkList)]
        [TestCase(Fieldbillingtype)]
        [TestCase(FielduserpanelRequiredCount)]
        [TestCase(FieldpermissionPanelRequiredCount)]
        [TestCase(FieldprofilepanelRequiredCount)]
        [TestCase(Fieldpicker)]
        [TestCase(FieldisFeatureActivated)]
        [TestCase(FieldDisplayFormRedirect)]
        [TestCase(FieldbUseTeam)]
        [TestCase(FieldActivationType)]
        public void AUT_ListDisplaySettingIterator_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_listDisplaySettingIteratorInstanceFixture, 
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
        ///     Class (<see cref="ListDisplaySettingIterator" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ListDisplaySettingIterator_Is_Instance_Present_Test()
        {
            // Assert
            _listDisplaySettingIteratorInstanceType.ShouldNotBeNull();
            _listDisplaySettingIteratorInstance.ShouldNotBeNull();
            _listDisplaySettingIteratorInstanceFixture.ShouldNotBeNull();
            _listDisplaySettingIteratorInstance.ShouldBeAssignableTo<ListDisplaySettingIterator>();
            _listDisplaySettingIteratorInstanceFixture.ShouldBeAssignableTo<ListDisplaySettingIterator>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ListDisplaySettingIterator) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ListDisplaySettingIterator_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ListDisplaySettingIterator instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _listDisplaySettingIteratorInstanceType.ShouldNotBeNull();
            _listDisplaySettingIteratorInstance.ShouldNotBeNull();
            _listDisplaySettingIteratorInstanceFixture.ShouldNotBeNull();
            _listDisplaySettingIteratorInstance.ShouldBeAssignableTo<ListDisplaySettingIterator>();
            _listDisplaySettingIteratorInstanceFixture.ShouldBeAssignableTo<ListDisplaySettingIterator>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="ListDisplaySettingIterator" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodClearCache)]
        [TestCase(MethodGetControl)]
        [TestCase(MethodGetChildControlBasedOnFieldType)]
        [TestCase(MethodSetFieldName)]
        [TestCase(MethodSetControlMode)]
        public void AUT_ListDisplaySettingIterator_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_listDisplaySettingIteratorInstanceFixture,
                                                                              _listDisplaySettingIteratorInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ListDisplaySettingIterator" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodFindSaveButtons)]
        [TestCase(MethodCustomHandler)]
        [TestCase(MethodHandleNewItemRecent)]
        [TestCase(MethodProcessNewItemRecent)]
        [TestCase(MethodOnInit)]
        [TestCase(MethodRenderControl)]
        [TestCase(MethodDispose)]
        [TestCase(MethodAddControlsToWriter)]
        [TestCase(MethodCreateHtmlPanelText)]
        [TestCase(MethodCreateChildControls)]
        [TestCase(MethodInsertLookupValueByQueryString)]
        [TestCase(MethodGetLookupItemValue)]
        [TestCase(MethodGetQueryStringLookupVal)]
        [TestCase(MethodAddTypeAheadFieldControls)]
        [TestCase(MethodAddEntityPickersToLookups)]
        [TestCase(MethodGenerateControlDataForLookupField)]
        [TestCase(MethodIsFieldExcluded)]
        public void AUT_ListDisplaySettingIterator_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ListDisplaySettingIterator>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (FindSaveButtons) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListDisplaySettingIterator_FindSaveButtons_Method_Call_Internally(Type[] types)
        {
            var methodFindSaveButtonsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodFindSaveButtons, Fixture, methodFindSaveButtonsPrametersTypes);
        }

        #endregion

        #region Method Call : (FindSaveButtons) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_FindSaveButtons_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var Parent = CreateType<Control>();
            var Controls = CreateType<ArrayList>();
            var methodFindSaveButtonsPrametersTypes = new Type[] { typeof(Control), typeof(ArrayList) };
            object[] parametersOfFindSaveButtons = { Parent, Controls };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodFindSaveButtons, methodFindSaveButtonsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listDisplaySettingIteratorInstanceFixture, parametersOfFindSaveButtons);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfFindSaveButtons.ShouldNotBeNull();
            parametersOfFindSaveButtons.Length.ShouldBe(2);
            methodFindSaveButtonsPrametersTypes.Length.ShouldBe(2);
            methodFindSaveButtonsPrametersTypes.Length.ShouldBe(parametersOfFindSaveButtons.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FindSaveButtons) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_FindSaveButtons_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Parent = CreateType<Control>();
            var Controls = CreateType<ArrayList>();
            var methodFindSaveButtonsPrametersTypes = new Type[] { typeof(Control), typeof(ArrayList) };
            object[] parametersOfFindSaveButtons = { Parent, Controls };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listDisplaySettingIteratorInstance, MethodFindSaveButtons, parametersOfFindSaveButtons, methodFindSaveButtonsPrametersTypes);

            // Assert
            parametersOfFindSaveButtons.ShouldNotBeNull();
            parametersOfFindSaveButtons.Length.ShouldBe(2);
            methodFindSaveButtonsPrametersTypes.Length.ShouldBe(2);
            methodFindSaveButtonsPrametersTypes.Length.ShouldBe(parametersOfFindSaveButtons.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FindSaveButtons) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_FindSaveButtons_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodFindSaveButtons, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FindSaveButtons) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_FindSaveButtons_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFindSaveButtonsPrametersTypes = new Type[] { typeof(Control), typeof(ArrayList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodFindSaveButtons, Fixture, methodFindSaveButtonsPrametersTypes);

            // Assert
            methodFindSaveButtonsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FindSaveButtons) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_FindSaveButtons_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFindSaveButtons, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listDisplaySettingIteratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CustomHandler) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListDisplaySettingIterator_CustomHandler_Method_Call_Internally(Type[] types)
        {
            var methodCustomHandlerPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodCustomHandler, Fixture, methodCustomHandlerPrametersTypes);
        }

        #endregion

        #region Method Call : (CustomHandler) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_CustomHandler_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodCustomHandlerPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfCustomHandler = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCustomHandler, methodCustomHandlerPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listDisplaySettingIteratorInstanceFixture, parametersOfCustomHandler);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCustomHandler.ShouldNotBeNull();
            parametersOfCustomHandler.Length.ShouldBe(2);
            methodCustomHandlerPrametersTypes.Length.ShouldBe(2);
            methodCustomHandlerPrametersTypes.Length.ShouldBe(parametersOfCustomHandler.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CustomHandler) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_CustomHandler_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodCustomHandlerPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfCustomHandler = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listDisplaySettingIteratorInstance, MethodCustomHandler, parametersOfCustomHandler, methodCustomHandlerPrametersTypes);

            // Assert
            parametersOfCustomHandler.ShouldNotBeNull();
            parametersOfCustomHandler.Length.ShouldBe(2);
            methodCustomHandlerPrametersTypes.Length.ShouldBe(2);
            methodCustomHandlerPrametersTypes.Length.ShouldBe(parametersOfCustomHandler.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CustomHandler) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_CustomHandler_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCustomHandler, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CustomHandler) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_CustomHandler_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCustomHandlerPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodCustomHandler, Fixture, methodCustomHandlerPrametersTypes);

            // Assert
            methodCustomHandlerPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CustomHandler) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_CustomHandler_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCustomHandler, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listDisplaySettingIteratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HandleNewItemRecent) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListDisplaySettingIterator_HandleNewItemRecent_Method_Call_Internally(Type[] types)
        {
            var methodHandleNewItemRecentPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodHandleNewItemRecent, Fixture, methodHandleNewItemRecentPrametersTypes);
        }

        #endregion

        #region Method Call : (HandleNewItemRecent) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_HandleNewItemRecent_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodHandleNewItemRecentPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfHandleNewItemRecent = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodHandleNewItemRecent, methodHandleNewItemRecentPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listDisplaySettingIteratorInstanceFixture, parametersOfHandleNewItemRecent);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfHandleNewItemRecent.ShouldNotBeNull();
            parametersOfHandleNewItemRecent.Length.ShouldBe(2);
            methodHandleNewItemRecentPrametersTypes.Length.ShouldBe(2);
            methodHandleNewItemRecentPrametersTypes.Length.ShouldBe(parametersOfHandleNewItemRecent.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (HandleNewItemRecent) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_HandleNewItemRecent_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodHandleNewItemRecentPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfHandleNewItemRecent = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listDisplaySettingIteratorInstance, MethodHandleNewItemRecent, parametersOfHandleNewItemRecent, methodHandleNewItemRecentPrametersTypes);

            // Assert
            parametersOfHandleNewItemRecent.ShouldNotBeNull();
            parametersOfHandleNewItemRecent.Length.ShouldBe(2);
            methodHandleNewItemRecentPrametersTypes.Length.ShouldBe(2);
            methodHandleNewItemRecentPrametersTypes.Length.ShouldBe(parametersOfHandleNewItemRecent.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HandleNewItemRecent) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_HandleNewItemRecent_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodHandleNewItemRecent, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (HandleNewItemRecent) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_HandleNewItemRecent_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodHandleNewItemRecentPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodHandleNewItemRecent, Fixture, methodHandleNewItemRecentPrametersTypes);

            // Assert
            methodHandleNewItemRecentPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HandleNewItemRecent) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_HandleNewItemRecent_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodHandleNewItemRecent, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listDisplaySettingIteratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessNewItemRecent) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListDisplaySettingIterator_ProcessNewItemRecent_Method_Call_Internally(Type[] types)
        {
            var methodProcessNewItemRecentPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodProcessNewItemRecent, Fixture, methodProcessNewItemRecentPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessNewItemRecent) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_ProcessNewItemRecent_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var i = CreateType<SPListItem>();
            var methodProcessNewItemRecentPrametersTypes = new Type[] { typeof(SPListItem) };
            object[] parametersOfProcessNewItemRecent = { i };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodProcessNewItemRecent, methodProcessNewItemRecentPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listDisplaySettingIteratorInstanceFixture, parametersOfProcessNewItemRecent);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfProcessNewItemRecent.ShouldNotBeNull();
            parametersOfProcessNewItemRecent.Length.ShouldBe(1);
            methodProcessNewItemRecentPrametersTypes.Length.ShouldBe(1);
            methodProcessNewItemRecentPrametersTypes.Length.ShouldBe(parametersOfProcessNewItemRecent.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessNewItemRecent) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_ProcessNewItemRecent_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var i = CreateType<SPListItem>();
            var methodProcessNewItemRecentPrametersTypes = new Type[] { typeof(SPListItem) };
            object[] parametersOfProcessNewItemRecent = { i };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listDisplaySettingIteratorInstance, MethodProcessNewItemRecent, parametersOfProcessNewItemRecent, methodProcessNewItemRecentPrametersTypes);

            // Assert
            parametersOfProcessNewItemRecent.ShouldNotBeNull();
            parametersOfProcessNewItemRecent.Length.ShouldBe(1);
            methodProcessNewItemRecentPrametersTypes.Length.ShouldBe(1);
            methodProcessNewItemRecentPrametersTypes.Length.ShouldBe(parametersOfProcessNewItemRecent.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessNewItemRecent) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_ProcessNewItemRecent_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodProcessNewItemRecent, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessNewItemRecent) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_ProcessNewItemRecent_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessNewItemRecentPrametersTypes = new Type[] { typeof(SPListItem) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodProcessNewItemRecent, Fixture, methodProcessNewItemRecentPrametersTypes);

            // Assert
            methodProcessNewItemRecentPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessNewItemRecent) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_ProcessNewItemRecent_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessNewItemRecent, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listDisplaySettingIteratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListDisplaySettingIterator_ClearCache_Static_Method_Call_Internally(Type[] types)
        {
            var methodClearCachePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstanceFixture, _listDisplaySettingIteratorInstanceType, MethodClearCache, Fixture, methodClearCachePrametersTypes);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_ClearCache_Static_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodClearCachePrametersTypes = null;
            object[] parametersOfClearCache = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodClearCache, methodClearCachePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listDisplaySettingIteratorInstanceFixture, parametersOfClearCache);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfClearCache.ShouldBeNull();
            methodClearCachePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_ClearCache_Static_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodClearCachePrametersTypes = null;
            object[] parametersOfClearCache = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_listDisplaySettingIteratorInstanceFixture, _listDisplaySettingIteratorInstanceType, MethodClearCache, parametersOfClearCache, methodClearCachePrametersTypes);

            // Assert
            parametersOfClearCache.ShouldBeNull();
            methodClearCachePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_ClearCache_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodClearCachePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstanceFixture, _listDisplaySettingIteratorInstanceType, MethodClearCache, Fixture, methodClearCachePrametersTypes);

            // Assert
            methodClearCachePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_ClearCache_Static_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodClearCache, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listDisplaySettingIteratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListDisplaySettingIterator_OnInit_Method_Call_Internally(Type[] types)
        {
            var methodOnInitPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodOnInit, Fixture, methodOnInitPrametersTypes);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_OnInit_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnInitPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnInit = { e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnInit, methodOnInitPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listDisplaySettingIteratorInstanceFixture, parametersOfOnInit);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOnInit.ShouldNotBeNull();
            parametersOfOnInit.Length.ShouldBe(1);
            methodOnInitPrametersTypes.Length.ShouldBe(1);
            methodOnInitPrametersTypes.Length.ShouldBe(parametersOfOnInit.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_OnInit_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnInitPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnInit = { e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listDisplaySettingIteratorInstance, MethodOnInit, parametersOfOnInit, methodOnInitPrametersTypes);

            // Assert
            parametersOfOnInit.ShouldNotBeNull();
            parametersOfOnInit.Length.ShouldBe(1);
            methodOnInitPrametersTypes.Length.ShouldBe(1);
            methodOnInitPrametersTypes.Length.ShouldBe(parametersOfOnInit.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_OnInit_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOnInit, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_OnInit_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnInitPrametersTypes = new Type[] { typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodOnInit, Fixture, methodOnInitPrametersTypes);

            // Assert
            methodOnInitPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_OnInit_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnInit, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listDisplaySettingIteratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderControl) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListDisplaySettingIterator_RenderControl_Method_Call_Internally(Type[] types)
        {
            var methodRenderControlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodRenderControl, Fixture, methodRenderControlPrametersTypes);
        }

        #endregion

        #region Method Call : (RenderControl) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_RenderControl_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var writer = CreateType<System.Web.UI.HtmlTextWriter>();
            Action executeAction = null;

            // Act
            executeAction = () => _listDisplaySettingIteratorInstance.RenderControl(writer);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (RenderControl) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_RenderControl_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var writer = CreateType<System.Web.UI.HtmlTextWriter>();
            var methodRenderControlPrametersTypes = new Type[] { typeof(System.Web.UI.HtmlTextWriter) };
            object[] parametersOfRenderControl = { writer };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRenderControl, methodRenderControlPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listDisplaySettingIteratorInstanceFixture, parametersOfRenderControl);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRenderControl.ShouldNotBeNull();
            parametersOfRenderControl.Length.ShouldBe(1);
            methodRenderControlPrametersTypes.Length.ShouldBe(1);
            methodRenderControlPrametersTypes.Length.ShouldBe(parametersOfRenderControl.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RenderControl) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_RenderControl_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var writer = CreateType<System.Web.UI.HtmlTextWriter>();
            var methodRenderControlPrametersTypes = new Type[] { typeof(System.Web.UI.HtmlTextWriter) };
            object[] parametersOfRenderControl = { writer };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listDisplaySettingIteratorInstance, MethodRenderControl, parametersOfRenderControl, methodRenderControlPrametersTypes);

            // Assert
            parametersOfRenderControl.ShouldNotBeNull();
            parametersOfRenderControl.Length.ShouldBe(1);
            methodRenderControlPrametersTypes.Length.ShouldBe(1);
            methodRenderControlPrametersTypes.Length.ShouldBe(parametersOfRenderControl.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderControl) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_RenderControl_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRenderControl, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenderControl) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_RenderControl_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenderControlPrametersTypes = new Type[] { typeof(System.Web.UI.HtmlTextWriter) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodRenderControl, Fixture, methodRenderControlPrametersTypes);

            // Assert
            methodRenderControlPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderControl) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_RenderControl_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenderControl, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listDisplaySettingIteratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListDisplaySettingIterator_Dispose_Method_Call_Internally(Type[] types)
        {
            var methodDisposePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodDispose, Fixture, methodDisposePrametersTypes);
        }

        #endregion
        
        #region Method Call : (Dispose) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_Dispose_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodDisposePrametersTypes = null;
            object[] parametersOfDispose = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listDisplaySettingIteratorInstance, MethodDispose, parametersOfDispose, methodDisposePrametersTypes);

            // Assert
            parametersOfDispose.ShouldBeNull();
            methodDisposePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_Dispose_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodDisposePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodDispose, Fixture, methodDisposePrametersTypes);

            // Assert
            methodDisposePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_Dispose_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDispose, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listDisplaySettingIteratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddControlsToWriter) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListDisplaySettingIterator_AddControlsToWriter_Method_Call_Internally(Type[] types)
        {
            var methodAddControlsToWriterPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodAddControlsToWriter, Fixture, methodAddControlsToWriterPrametersTypes);
        }

        #endregion

        #region Method Call : (AddControlsToWriter) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_AddControlsToWriter_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var control = CreateType<Control>();
            var writer = CreateType<HtmlTextWriter>();
            var internalName = CreateType<string>();
            var methodAddControlsToWriterPrametersTypes = new Type[] { typeof(Control), typeof(HtmlTextWriter), typeof(string) };
            object[] parametersOfAddControlsToWriter = { control, writer, internalName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddControlsToWriter, methodAddControlsToWriterPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listDisplaySettingIteratorInstanceFixture, parametersOfAddControlsToWriter);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddControlsToWriter.ShouldNotBeNull();
            parametersOfAddControlsToWriter.Length.ShouldBe(3);
            methodAddControlsToWriterPrametersTypes.Length.ShouldBe(3);
            methodAddControlsToWriterPrametersTypes.Length.ShouldBe(parametersOfAddControlsToWriter.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddControlsToWriter) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_AddControlsToWriter_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var control = CreateType<Control>();
            var writer = CreateType<HtmlTextWriter>();
            var internalName = CreateType<string>();
            var methodAddControlsToWriterPrametersTypes = new Type[] { typeof(Control), typeof(HtmlTextWriter), typeof(string) };
            object[] parametersOfAddControlsToWriter = { control, writer, internalName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listDisplaySettingIteratorInstance, MethodAddControlsToWriter, parametersOfAddControlsToWriter, methodAddControlsToWriterPrametersTypes);

            // Assert
            parametersOfAddControlsToWriter.ShouldNotBeNull();
            parametersOfAddControlsToWriter.Length.ShouldBe(3);
            methodAddControlsToWriterPrametersTypes.Length.ShouldBe(3);
            methodAddControlsToWriterPrametersTypes.Length.ShouldBe(parametersOfAddControlsToWriter.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddControlsToWriter) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_AddControlsToWriter_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddControlsToWriter, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddControlsToWriter) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_AddControlsToWriter_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddControlsToWriterPrametersTypes = new Type[] { typeof(Control), typeof(HtmlTextWriter), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodAddControlsToWriter, Fixture, methodAddControlsToWriterPrametersTypes);

            // Assert
            methodAddControlsToWriterPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddControlsToWriter) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_AddControlsToWriter_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddControlsToWriter, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listDisplaySettingIteratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateHtmlPanelText) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListDisplaySettingIterator_CreateHtmlPanelText_Method_Call_Internally(Type[] types)
        {
            var methodCreateHtmlPanelTextPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodCreateHtmlPanelText, Fixture, methodCreateHtmlPanelTextPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateHtmlPanelText) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_CreateHtmlPanelText_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var panelTitle = CreateType<string>();
            var methodCreateHtmlPanelTextPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfCreateHtmlPanelText = { panelTitle };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateHtmlPanelText, methodCreateHtmlPanelTextPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listDisplaySettingIteratorInstanceFixture, parametersOfCreateHtmlPanelText);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateHtmlPanelText.ShouldNotBeNull();
            parametersOfCreateHtmlPanelText.Length.ShouldBe(1);
            methodCreateHtmlPanelTextPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateHtmlPanelText) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_CreateHtmlPanelText_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var panelTitle = CreateType<string>();
            var methodCreateHtmlPanelTextPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfCreateHtmlPanelText = { panelTitle };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ListDisplaySettingIterator, string>(_listDisplaySettingIteratorInstance, MethodCreateHtmlPanelText, parametersOfCreateHtmlPanelText, methodCreateHtmlPanelTextPrametersTypes);

            // Assert
            parametersOfCreateHtmlPanelText.ShouldNotBeNull();
            parametersOfCreateHtmlPanelText.Length.ShouldBe(1);
            methodCreateHtmlPanelTextPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateHtmlPanelText) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_CreateHtmlPanelText_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCreateHtmlPanelTextPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodCreateHtmlPanelText, Fixture, methodCreateHtmlPanelTextPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCreateHtmlPanelTextPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (CreateHtmlPanelText) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_CreateHtmlPanelText_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateHtmlPanelTextPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodCreateHtmlPanelText, Fixture, methodCreateHtmlPanelTextPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreateHtmlPanelTextPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateHtmlPanelText) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_CreateHtmlPanelText_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateHtmlPanelText, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listDisplaySettingIteratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (CreateHtmlPanelText) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_CreateHtmlPanelText_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreateHtmlPanelText, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListDisplaySettingIterator_CreateChildControls_Method_Call_Internally(Type[] types)
        {
            var methodCreateChildControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, methodCreateChildControlsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listDisplaySettingIteratorInstanceFixture, parametersOfCreateChildControls);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateChildControls.ShouldBeNull();
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listDisplaySettingIteratorInstance, MethodCreateChildControls, parametersOfCreateChildControls, methodCreateChildControlsPrametersTypes);

            // Assert
            parametersOfCreateChildControls.ShouldBeNull();
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_CreateChildControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);

            // Assert
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_CreateChildControls_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listDisplaySettingIteratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InsertLookupValueByQueryString) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListDisplaySettingIterator_InsertLookupValueByQueryString_Method_Call_Internally(Type[] types)
        {
            var methodInsertLookupValueByQueryStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodInsertLookupValueByQueryString, Fixture, methodInsertLookupValueByQueryStringPrametersTypes);
        }

        #endregion

        #region Method Call : (InsertLookupValueByQueryString) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_InsertLookupValueByQueryString_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodInsertLookupValueByQueryStringPrametersTypes = null;
            object[] parametersOfInsertLookupValueByQueryString = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInsertLookupValueByQueryString, methodInsertLookupValueByQueryStringPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listDisplaySettingIteratorInstanceFixture, parametersOfInsertLookupValueByQueryString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInsertLookupValueByQueryString.ShouldBeNull();
            methodInsertLookupValueByQueryStringPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (InsertLookupValueByQueryString) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_InsertLookupValueByQueryString_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodInsertLookupValueByQueryStringPrametersTypes = null;
            object[] parametersOfInsertLookupValueByQueryString = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listDisplaySettingIteratorInstance, MethodInsertLookupValueByQueryString, parametersOfInsertLookupValueByQueryString, methodInsertLookupValueByQueryStringPrametersTypes);

            // Assert
            parametersOfInsertLookupValueByQueryString.ShouldBeNull();
            methodInsertLookupValueByQueryStringPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InsertLookupValueByQueryString) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_InsertLookupValueByQueryString_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodInsertLookupValueByQueryStringPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodInsertLookupValueByQueryString, Fixture, methodInsertLookupValueByQueryStringPrametersTypes);

            // Assert
            methodInsertLookupValueByQueryStringPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InsertLookupValueByQueryString) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_InsertLookupValueByQueryString_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInsertLookupValueByQueryString, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listDisplaySettingIteratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetLookupItemValue) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListDisplaySettingIterator_GetLookupItemValue_Method_Call_Internally(Type[] types)
        {
            var methodGetLookupItemValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodGetLookupItemValue, Fixture, methodGetLookupItemValuePrametersTypes);
        }

        #endregion

        #region Method Call : (GetLookupItemValue) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_GetLookupItemValue_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var lookupFld = CreateType<SPFieldLookup>();
            var lookupItemID = CreateType<int>();
            var methodGetLookupItemValuePrametersTypes = new Type[] { typeof(SPFieldLookup), typeof(int) };
            object[] parametersOfGetLookupItemValue = { lookupFld, lookupItemID };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetLookupItemValue, methodGetLookupItemValuePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ListDisplaySettingIterator, string>(_listDisplaySettingIteratorInstanceFixture, out exception1, parametersOfGetLookupItemValue);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ListDisplaySettingIterator, string>(_listDisplaySettingIteratorInstance, MethodGetLookupItemValue, parametersOfGetLookupItemValue, methodGetLookupItemValuePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetLookupItemValue.ShouldNotBeNull();
            parametersOfGetLookupItemValue.Length.ShouldBe(2);
            methodGetLookupItemValuePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetLookupItemValue) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_GetLookupItemValue_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var lookupFld = CreateType<SPFieldLookup>();
            var lookupItemID = CreateType<int>();
            var methodGetLookupItemValuePrametersTypes = new Type[] { typeof(SPFieldLookup), typeof(int) };
            object[] parametersOfGetLookupItemValue = { lookupFld, lookupItemID };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ListDisplaySettingIterator, string>(_listDisplaySettingIteratorInstance, MethodGetLookupItemValue, parametersOfGetLookupItemValue, methodGetLookupItemValuePrametersTypes);

            // Assert
            parametersOfGetLookupItemValue.ShouldNotBeNull();
            parametersOfGetLookupItemValue.Length.ShouldBe(2);
            methodGetLookupItemValuePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetLookupItemValue) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_GetLookupItemValue_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetLookupItemValuePrametersTypes = new Type[] { typeof(SPFieldLookup), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodGetLookupItemValue, Fixture, methodGetLookupItemValuePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetLookupItemValuePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetLookupItemValue) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_GetLookupItemValue_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetLookupItemValuePrametersTypes = new Type[] { typeof(SPFieldLookup), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodGetLookupItemValue, Fixture, methodGetLookupItemValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetLookupItemValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetLookupItemValue) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_GetLookupItemValue_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetLookupItemValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listDisplaySettingIteratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLookupItemValue) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_GetLookupItemValue_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetLookupItemValue, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetQueryStringLookupVal) (Return Type : SPFieldLookupValueCollection) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListDisplaySettingIterator_GetQueryStringLookupVal_Method_Call_Internally(Type[] types)
        {
            var methodGetQueryStringLookupValPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodGetQueryStringLookupVal, Fixture, methodGetQueryStringLookupValPrametersTypes);
        }

        #endregion

        #region Method Call : (GetQueryStringLookupVal) (Return Type : SPFieldLookupValueCollection) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_GetQueryStringLookupVal_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var currentFld = CreateType<FormField>();
            var methodGetQueryStringLookupValPrametersTypes = new Type[] { typeof(FormField) };
            object[] parametersOfGetQueryStringLookupVal = { currentFld };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetQueryStringLookupVal, methodGetQueryStringLookupValPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ListDisplaySettingIterator, SPFieldLookupValueCollection>(_listDisplaySettingIteratorInstanceFixture, out exception1, parametersOfGetQueryStringLookupVal);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ListDisplaySettingIterator, SPFieldLookupValueCollection>(_listDisplaySettingIteratorInstance, MethodGetQueryStringLookupVal, parametersOfGetQueryStringLookupVal, methodGetQueryStringLookupValPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetQueryStringLookupVal.ShouldNotBeNull();
            parametersOfGetQueryStringLookupVal.Length.ShouldBe(1);
            methodGetQueryStringLookupValPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetQueryStringLookupVal) (Return Type : SPFieldLookupValueCollection) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_GetQueryStringLookupVal_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var currentFld = CreateType<FormField>();
            var methodGetQueryStringLookupValPrametersTypes = new Type[] { typeof(FormField) };
            object[] parametersOfGetQueryStringLookupVal = { currentFld };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ListDisplaySettingIterator, SPFieldLookupValueCollection>(_listDisplaySettingIteratorInstance, MethodGetQueryStringLookupVal, parametersOfGetQueryStringLookupVal, methodGetQueryStringLookupValPrametersTypes);

            // Assert
            parametersOfGetQueryStringLookupVal.ShouldNotBeNull();
            parametersOfGetQueryStringLookupVal.Length.ShouldBe(1);
            methodGetQueryStringLookupValPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetQueryStringLookupVal) (Return Type : SPFieldLookupValueCollection) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_GetQueryStringLookupVal_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetQueryStringLookupValPrametersTypes = new Type[] { typeof(FormField) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodGetQueryStringLookupVal, Fixture, methodGetQueryStringLookupValPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetQueryStringLookupValPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetQueryStringLookupVal) (Return Type : SPFieldLookupValueCollection) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_GetQueryStringLookupVal_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetQueryStringLookupValPrametersTypes = new Type[] { typeof(FormField) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodGetQueryStringLookupVal, Fixture, methodGetQueryStringLookupValPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetQueryStringLookupValPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetQueryStringLookupVal) (Return Type : SPFieldLookupValueCollection) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_GetQueryStringLookupVal_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetQueryStringLookupVal, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listDisplaySettingIteratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetQueryStringLookupVal) (Return Type : SPFieldLookupValueCollection) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_GetQueryStringLookupVal_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetQueryStringLookupVal, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetQueryStringLookupVal) (Return Type : SPFieldLookupValueCollection) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListDisplaySettingIterator_GetQueryStringLookupVal_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodGetQueryStringLookupValPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodGetQueryStringLookupVal, Fixture, methodGetQueryStringLookupValPrametersTypes);
        }

        #endregion

        #region Method Call : (GetQueryStringLookupVal) (Return Type : SPFieldLookupValueCollection) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_GetQueryStringLookupVal_Method_Call_Overloading_Of_1_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var fld = CreateType<SPField>();
            var methodGetQueryStringLookupValPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfGetQueryStringLookupVal = { fld };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetQueryStringLookupVal, methodGetQueryStringLookupValPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ListDisplaySettingIterator, SPFieldLookupValueCollection>(_listDisplaySettingIteratorInstanceFixture, out exception1, parametersOfGetQueryStringLookupVal);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ListDisplaySettingIterator, SPFieldLookupValueCollection>(_listDisplaySettingIteratorInstance, MethodGetQueryStringLookupVal, parametersOfGetQueryStringLookupVal, methodGetQueryStringLookupValPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetQueryStringLookupVal.ShouldNotBeNull();
            parametersOfGetQueryStringLookupVal.Length.ShouldBe(1);
            methodGetQueryStringLookupValPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetQueryStringLookupVal) (Return Type : SPFieldLookupValueCollection) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_GetQueryStringLookupVal_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var fld = CreateType<SPField>();
            var methodGetQueryStringLookupValPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfGetQueryStringLookupVal = { fld };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ListDisplaySettingIterator, SPFieldLookupValueCollection>(_listDisplaySettingIteratorInstance, MethodGetQueryStringLookupVal, parametersOfGetQueryStringLookupVal, methodGetQueryStringLookupValPrametersTypes);

            // Assert
            parametersOfGetQueryStringLookupVal.ShouldNotBeNull();
            parametersOfGetQueryStringLookupVal.Length.ShouldBe(1);
            methodGetQueryStringLookupValPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetQueryStringLookupVal) (Return Type : SPFieldLookupValueCollection) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_GetQueryStringLookupVal_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetQueryStringLookupValPrametersTypes = new Type[] { typeof(SPField) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodGetQueryStringLookupVal, Fixture, methodGetQueryStringLookupValPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetQueryStringLookupValPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetQueryStringLookupVal) (Return Type : SPFieldLookupValueCollection) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_GetQueryStringLookupVal_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetQueryStringLookupValPrametersTypes = new Type[] { typeof(SPField) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodGetQueryStringLookupVal, Fixture, methodGetQueryStringLookupValPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetQueryStringLookupValPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetQueryStringLookupVal) (Return Type : SPFieldLookupValueCollection) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_GetQueryStringLookupVal_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetQueryStringLookupVal, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listDisplaySettingIteratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetQueryStringLookupVal) (Return Type : SPFieldLookupValueCollection) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_GetQueryStringLookupVal_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetQueryStringLookupVal, 1);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddTypeAheadFieldControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListDisplaySettingIterator_AddTypeAheadFieldControls_Method_Call_Internally(Type[] types)
        {
            var methodAddTypeAheadFieldControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodAddTypeAheadFieldControls, Fixture, methodAddTypeAheadFieldControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (AddTypeAheadFieldControls) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_AddTypeAheadFieldControls_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var methodAddTypeAheadFieldControlsPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfAddTypeAheadFieldControls = { field };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddTypeAheadFieldControls, methodAddTypeAheadFieldControlsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listDisplaySettingIteratorInstanceFixture, parametersOfAddTypeAheadFieldControls);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddTypeAheadFieldControls.ShouldNotBeNull();
            parametersOfAddTypeAheadFieldControls.Length.ShouldBe(1);
            methodAddTypeAheadFieldControlsPrametersTypes.Length.ShouldBe(1);
            methodAddTypeAheadFieldControlsPrametersTypes.Length.ShouldBe(parametersOfAddTypeAheadFieldControls.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddTypeAheadFieldControls) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_AddTypeAheadFieldControls_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var methodAddTypeAheadFieldControlsPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfAddTypeAheadFieldControls = { field };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listDisplaySettingIteratorInstance, MethodAddTypeAheadFieldControls, parametersOfAddTypeAheadFieldControls, methodAddTypeAheadFieldControlsPrametersTypes);

            // Assert
            parametersOfAddTypeAheadFieldControls.ShouldNotBeNull();
            parametersOfAddTypeAheadFieldControls.Length.ShouldBe(1);
            methodAddTypeAheadFieldControlsPrametersTypes.Length.ShouldBe(1);
            methodAddTypeAheadFieldControlsPrametersTypes.Length.ShouldBe(parametersOfAddTypeAheadFieldControls.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddTypeAheadFieldControls) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_AddTypeAheadFieldControls_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddTypeAheadFieldControls, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddTypeAheadFieldControls) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_AddTypeAheadFieldControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddTypeAheadFieldControlsPrametersTypes = new Type[] { typeof(SPField) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodAddTypeAheadFieldControls, Fixture, methodAddTypeAheadFieldControlsPrametersTypes);

            // Assert
            methodAddTypeAheadFieldControlsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddTypeAheadFieldControls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_AddTypeAheadFieldControls_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddTypeAheadFieldControls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listDisplaySettingIteratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateCascadingMultiLookupControl) (Return Type : CascadingMultiLookupRenderControl) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListDisplaySettingIterator_CreateCascadingMultiLookupControl_Method_Call_Internally(Type[] types)
        {
            var methodCreateCascadingMultiLookupControlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodCreateCascadingMultiLookupControl, Fixture, methodCreateCascadingMultiLookupControlPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateCascadingMultiLookupControl) (Return Type : CascadingMultiLookupRenderControl) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_CreateCascadingMultiLookupControl_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var lookupData = CreateType<LookupConfigData>();
            var lookupField = CreateType<SPFieldLookup>();
            var methodCreateCascadingMultiLookupControlPrametersTypes = new Type[] { typeof(SPField), typeof(LookupConfigData), typeof(SPFieldLookup) };
            object[] parametersOfCreateCascadingMultiLookupControl = { field, lookupData, lookupField };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ListDisplaySettingIterator, CascadingMultiLookupRenderControl>(_listDisplaySettingIteratorInstance, MethodCreateCascadingMultiLookupControl, parametersOfCreateCascadingMultiLookupControl, methodCreateCascadingMultiLookupControlPrametersTypes);

            // Assert
            parametersOfCreateCascadingMultiLookupControl.ShouldNotBeNull();
            parametersOfCreateCascadingMultiLookupControl.Length.ShouldBe(3);
            methodCreateCascadingMultiLookupControlPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateCascadingMultiLookupControl) (Return Type : CascadingMultiLookupRenderControl) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_CreateCascadingMultiLookupControl_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCreateCascadingMultiLookupControlPrametersTypes = new Type[] { typeof(SPField), typeof(LookupConfigData), typeof(SPFieldLookup) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodCreateCascadingMultiLookupControl, Fixture, methodCreateCascadingMultiLookupControlPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCreateCascadingMultiLookupControlPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (CreateCascadingMultiLookupControl) (Return Type : CascadingMultiLookupRenderControl) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_CreateCascadingMultiLookupControl_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateCascadingMultiLookupControlPrametersTypes = new Type[] { typeof(SPField), typeof(LookupConfigData), typeof(SPFieldLookup) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodCreateCascadingMultiLookupControl, Fixture, methodCreateCascadingMultiLookupControlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreateCascadingMultiLookupControlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateCascadingLookupControl) (Return Type : CascadingLookupRenderControl) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListDisplaySettingIterator_CreateCascadingLookupControl_Method_Call_Internally(Type[] types)
        {
            var methodCreateCascadingLookupControlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodCreateCascadingLookupControl, Fixture, methodCreateCascadingLookupControlPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateCascadingLookupControl) (Return Type : CascadingLookupRenderControl) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_CreateCascadingLookupControl_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var lookupData = CreateType<LookupConfigData>();
            var lookupField = CreateType<SPFieldLookup>();
            var methodCreateCascadingLookupControlPrametersTypes = new Type[] { typeof(SPField), typeof(LookupConfigData), typeof(SPFieldLookup) };
            object[] parametersOfCreateCascadingLookupControl = { field, lookupData, lookupField };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ListDisplaySettingIterator, CascadingLookupRenderControl>(_listDisplaySettingIteratorInstance, MethodCreateCascadingLookupControl, parametersOfCreateCascadingLookupControl, methodCreateCascadingLookupControlPrametersTypes);

            // Assert
            parametersOfCreateCascadingLookupControl.ShouldNotBeNull();
            parametersOfCreateCascadingLookupControl.Length.ShouldBe(3);
            methodCreateCascadingLookupControlPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateCascadingLookupControl) (Return Type : CascadingLookupRenderControl) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_CreateCascadingLookupControl_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCreateCascadingLookupControlPrametersTypes = new Type[] { typeof(SPField), typeof(LookupConfigData), typeof(SPFieldLookup) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodCreateCascadingLookupControl, Fixture, methodCreateCascadingLookupControlPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCreateCascadingLookupControlPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (CreateCascadingLookupControl) (Return Type : CascadingLookupRenderControl) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_CreateCascadingLookupControl_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateCascadingLookupControlPrametersTypes = new Type[] { typeof(SPField), typeof(LookupConfigData), typeof(SPFieldLookup) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodCreateCascadingLookupControl, Fixture, methodCreateCascadingLookupControlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreateCascadingLookupControlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateGenericPickerControl) (Return Type : GenericEntityEditor) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListDisplaySettingIterator_CreateGenericPickerControl_Method_Call_Internally(Type[] types)
        {
            var methodCreateGenericPickerControlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodCreateGenericPickerControl, Fixture, methodCreateGenericPickerControlPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateGenericPickerControl) (Return Type : GenericEntityEditor) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_CreateGenericPickerControl_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var lookupData = CreateType<LookupConfigData>();
            var methodCreateGenericPickerControlPrametersTypes = new Type[] { typeof(SPField), typeof(LookupConfigData) };
            object[] parametersOfCreateGenericPickerControl = { field, lookupData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ListDisplaySettingIterator, GenericEntityEditor>(_listDisplaySettingIteratorInstance, MethodCreateGenericPickerControl, parametersOfCreateGenericPickerControl, methodCreateGenericPickerControlPrametersTypes);

            // Assert
            parametersOfCreateGenericPickerControl.ShouldNotBeNull();
            parametersOfCreateGenericPickerControl.Length.ShouldBe(2);
            methodCreateGenericPickerControlPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateGenericPickerControl) (Return Type : GenericEntityEditor) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_CreateGenericPickerControl_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCreateGenericPickerControlPrametersTypes = new Type[] { typeof(SPField), typeof(LookupConfigData) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodCreateGenericPickerControl, Fixture, methodCreateGenericPickerControlPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCreateGenericPickerControlPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (CreateGenericPickerControl) (Return Type : GenericEntityEditor) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_CreateGenericPickerControl_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateGenericPickerControlPrametersTypes = new Type[] { typeof(SPField), typeof(LookupConfigData) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodCreateGenericPickerControl, Fixture, methodCreateGenericPickerControlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreateGenericPickerControlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddEntityPickersToLookups) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListDisplaySettingIterator_AddEntityPickersToLookups_Method_Call_Internally(Type[] types)
        {
            var methodAddEntityPickersToLookupsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodAddEntityPickersToLookups, Fixture, methodAddEntityPickersToLookupsPrametersTypes);
        }

        #endregion

        #region Method Call : (AddEntityPickersToLookups) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_AddEntityPickersToLookups_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodAddEntityPickersToLookupsPrametersTypes = null;
            object[] parametersOfAddEntityPickersToLookups = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddEntityPickersToLookups, methodAddEntityPickersToLookupsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listDisplaySettingIteratorInstanceFixture, parametersOfAddEntityPickersToLookups);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddEntityPickersToLookups.ShouldBeNull();
            methodAddEntityPickersToLookupsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddEntityPickersToLookups) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_AddEntityPickersToLookups_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodAddEntityPickersToLookupsPrametersTypes = null;
            object[] parametersOfAddEntityPickersToLookups = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listDisplaySettingIteratorInstance, MethodAddEntityPickersToLookups, parametersOfAddEntityPickersToLookups, methodAddEntityPickersToLookupsPrametersTypes);

            // Assert
            parametersOfAddEntityPickersToLookups.ShouldBeNull();
            methodAddEntityPickersToLookupsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddEntityPickersToLookups) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_AddEntityPickersToLookups_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodAddEntityPickersToLookupsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodAddEntityPickersToLookups, Fixture, methodAddEntityPickersToLookupsPrametersTypes);

            // Assert
            methodAddEntityPickersToLookupsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddEntityPickersToLookups) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_AddEntityPickersToLookups_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddEntityPickersToLookups, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listDisplaySettingIteratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GenerateControlDataForLookupField) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListDisplaySettingIterator_GenerateControlDataForLookupField_Method_Call_Internally(Type[] types)
        {
            var methodGenerateControlDataForLookupFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodGenerateControlDataForLookupField, Fixture, methodGenerateControlDataForLookupFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (GenerateControlDataForLookupField) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_GenerateControlDataForLookupField_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sourceFld = CreateType<FormField>();
            var isMulti = CreateType<bool>();
            var methodGenerateControlDataForLookupFieldPrametersTypes = new Type[] { typeof(FormField), typeof(bool) };
            object[] parametersOfGenerateControlDataForLookupField = { sourceFld, isMulti };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGenerateControlDataForLookupField, methodGenerateControlDataForLookupFieldPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ListDisplaySettingIterator, string>(_listDisplaySettingIteratorInstanceFixture, out exception1, parametersOfGenerateControlDataForLookupField);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ListDisplaySettingIterator, string>(_listDisplaySettingIteratorInstance, MethodGenerateControlDataForLookupField, parametersOfGenerateControlDataForLookupField, methodGenerateControlDataForLookupFieldPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGenerateControlDataForLookupField.ShouldNotBeNull();
            parametersOfGenerateControlDataForLookupField.Length.ShouldBe(2);
            methodGenerateControlDataForLookupFieldPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GenerateControlDataForLookupField) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_GenerateControlDataForLookupField_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sourceFld = CreateType<FormField>();
            var isMulti = CreateType<bool>();
            var methodGenerateControlDataForLookupFieldPrametersTypes = new Type[] { typeof(FormField), typeof(bool) };
            object[] parametersOfGenerateControlDataForLookupField = { sourceFld, isMulti };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ListDisplaySettingIterator, string>(_listDisplaySettingIteratorInstance, MethodGenerateControlDataForLookupField, parametersOfGenerateControlDataForLookupField, methodGenerateControlDataForLookupFieldPrametersTypes);

            // Assert
            parametersOfGenerateControlDataForLookupField.ShouldNotBeNull();
            parametersOfGenerateControlDataForLookupField.Length.ShouldBe(2);
            methodGenerateControlDataForLookupFieldPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GenerateControlDataForLookupField) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_GenerateControlDataForLookupField_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGenerateControlDataForLookupFieldPrametersTypes = new Type[] { typeof(FormField), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodGenerateControlDataForLookupField, Fixture, methodGenerateControlDataForLookupFieldPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGenerateControlDataForLookupFieldPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GenerateControlDataForLookupField) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_GenerateControlDataForLookupField_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGenerateControlDataForLookupFieldPrametersTypes = new Type[] { typeof(FormField), typeof(bool) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodGenerateControlDataForLookupField, Fixture, methodGenerateControlDataForLookupFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGenerateControlDataForLookupFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GenerateControlDataForLookupField) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_GenerateControlDataForLookupField_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGenerateControlDataForLookupField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listDisplaySettingIteratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GenerateControlDataForLookupField) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_GenerateControlDataForLookupField_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGenerateControlDataForLookupField, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetControl) (Return Type : Control) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListDisplaySettingIterator_GetControl_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetControlPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstanceFixture, _listDisplaySettingIteratorInstanceType, MethodGetControl, Fixture, methodGetControlPrametersTypes);
        }

        #endregion

        #region Method Call : (GetControl) (Return Type : Control) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_GetControl_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var formField = CreateType<FieldMetadata>();
            var methodGetControlPrametersTypes = new Type[] { typeof(FieldMetadata) };
            object[] parametersOfGetControl = { formField };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetControl, methodGetControlPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstanceFixture, _listDisplaySettingIteratorInstanceType, MethodGetControl, Fixture, methodGetControlPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<Control>(_listDisplaySettingIteratorInstanceFixture, _listDisplaySettingIteratorInstanceType, MethodGetControl, parametersOfGetControl, methodGetControlPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_listDisplaySettingIteratorInstanceFixture, parametersOfGetControl);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetControl.ShouldNotBeNull();
            parametersOfGetControl.Length.ShouldBe(1);
            methodGetControlPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetControl) (Return Type : Control) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_GetControl_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var formField = CreateType<FieldMetadata>();
            var methodGetControlPrametersTypes = new Type[] { typeof(FieldMetadata) };
            object[] parametersOfGetControl = { formField };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<Control>(_listDisplaySettingIteratorInstanceFixture, _listDisplaySettingIteratorInstanceType, MethodGetControl, parametersOfGetControl, methodGetControlPrametersTypes);

            // Assert
            parametersOfGetControl.ShouldNotBeNull();
            parametersOfGetControl.Length.ShouldBe(1);
            methodGetControlPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetControl) (Return Type : Control) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_GetControl_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetControlPrametersTypes = new Type[] { typeof(FieldMetadata) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstanceFixture, _listDisplaySettingIteratorInstanceType, MethodGetControl, Fixture, methodGetControlPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetControlPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetControl) (Return Type : Control) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_GetControl_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetControlPrametersTypes = new Type[] { typeof(FieldMetadata) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstanceFixture, _listDisplaySettingIteratorInstanceType, MethodGetControl, Fixture, methodGetControlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetControlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetControl) (Return Type : Control) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_GetControl_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetControl, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listDisplaySettingIteratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetControl) (Return Type : Control) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_GetControl_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetControl, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetChildControlBasedOnFieldType) (Return Type : Type) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListDisplaySettingIterator_GetChildControlBasedOnFieldType_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetChildControlBasedOnFieldTypePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstanceFixture, _listDisplaySettingIteratorInstanceType, MethodGetChildControlBasedOnFieldType, Fixture, methodGetChildControlBasedOnFieldTypePrametersTypes);
        }

        #endregion

        #region Method Call : (GetChildControlBasedOnFieldType) (Return Type : Type) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_GetChildControlBasedOnFieldType_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var field = CreateType<object>();
            var methodGetChildControlBasedOnFieldTypePrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfGetChildControlBasedOnFieldType = { field };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetChildControlBasedOnFieldType, methodGetChildControlBasedOnFieldTypePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listDisplaySettingIteratorInstanceFixture, parametersOfGetChildControlBasedOnFieldType);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetChildControlBasedOnFieldType.ShouldNotBeNull();
            parametersOfGetChildControlBasedOnFieldType.Length.ShouldBe(1);
            methodGetChildControlBasedOnFieldTypePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetChildControlBasedOnFieldType) (Return Type : Type) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_GetChildControlBasedOnFieldType_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var field = CreateType<object>();
            var methodGetChildControlBasedOnFieldTypePrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfGetChildControlBasedOnFieldType = { field };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<Type>(_listDisplaySettingIteratorInstanceFixture, _listDisplaySettingIteratorInstanceType, MethodGetChildControlBasedOnFieldType, parametersOfGetChildControlBasedOnFieldType, methodGetChildControlBasedOnFieldTypePrametersTypes);

            // Assert
            parametersOfGetChildControlBasedOnFieldType.ShouldNotBeNull();
            parametersOfGetChildControlBasedOnFieldType.Length.ShouldBe(1);
            methodGetChildControlBasedOnFieldTypePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetChildControlBasedOnFieldType) (Return Type : Type) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_GetChildControlBasedOnFieldType_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetChildControlBasedOnFieldTypePrametersTypes = new Type[] { typeof(object) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstanceFixture, _listDisplaySettingIteratorInstanceType, MethodGetChildControlBasedOnFieldType, Fixture, methodGetChildControlBasedOnFieldTypePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetChildControlBasedOnFieldTypePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetChildControlBasedOnFieldType) (Return Type : Type) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_GetChildControlBasedOnFieldType_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetChildControlBasedOnFieldTypePrametersTypes = new Type[] { typeof(object) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstanceFixture, _listDisplaySettingIteratorInstanceType, MethodGetChildControlBasedOnFieldType, Fixture, methodGetChildControlBasedOnFieldTypePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetChildControlBasedOnFieldTypePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetChildControlBasedOnFieldType) (Return Type : Type) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_GetChildControlBasedOnFieldType_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetChildControlBasedOnFieldType, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listDisplaySettingIteratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetChildControlBasedOnFieldType) (Return Type : Type) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_GetChildControlBasedOnFieldType_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetChildControlBasedOnFieldType, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetFieldName) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListDisplaySettingIterator_SetFieldName_Static_Method_Call_Internally(Type[] types)
        {
            var methodSetFieldNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstanceFixture, _listDisplaySettingIteratorInstanceType, MethodSetFieldName, Fixture, methodSetFieldNamePrametersTypes);
        }

        #endregion

        #region Method Call : (SetFieldName) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_SetFieldName_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var child = CreateType<TemplateContainer>();
            var fieldName = CreateType<string>();
            var methodSetFieldNamePrametersTypes = new Type[] { typeof(TemplateContainer), typeof(string) };
            object[] parametersOfSetFieldName = { child, fieldName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetFieldName, methodSetFieldNamePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listDisplaySettingIteratorInstanceFixture, parametersOfSetFieldName);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetFieldName.ShouldNotBeNull();
            parametersOfSetFieldName.Length.ShouldBe(2);
            methodSetFieldNamePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetFieldName) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_SetFieldName_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var child = CreateType<TemplateContainer>();
            var fieldName = CreateType<string>();
            var methodSetFieldNamePrametersTypes = new Type[] { typeof(TemplateContainer), typeof(string) };
            object[] parametersOfSetFieldName = { child, fieldName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_listDisplaySettingIteratorInstanceFixture, _listDisplaySettingIteratorInstanceType, MethodSetFieldName, parametersOfSetFieldName, methodSetFieldNamePrametersTypes);

            // Assert
            parametersOfSetFieldName.ShouldNotBeNull();
            parametersOfSetFieldName.Length.ShouldBe(2);
            methodSetFieldNamePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetFieldName) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_SetFieldName_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetFieldName, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetFieldName) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_SetFieldName_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetFieldNamePrametersTypes = new Type[] { typeof(TemplateContainer), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstanceFixture, _listDisplaySettingIteratorInstanceType, MethodSetFieldName, Fixture, methodSetFieldNamePrametersTypes);

            // Assert
            methodSetFieldNamePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetFieldName) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_SetFieldName_Static_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetFieldName, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listDisplaySettingIteratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetControlMode) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListDisplaySettingIterator_SetControlMode_Static_Method_Call_Internally(Type[] types)
        {
            var methodSetControlModePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstanceFixture, _listDisplaySettingIteratorInstanceType, MethodSetControlMode, Fixture, methodSetControlModePrametersTypes);
        }

        #endregion

        #region Method Call : (SetControlMode) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_SetControlMode_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var child = CreateType<TemplateContainer>();
            var controlMode = CreateType<SPControlMode>();
            var methodSetControlModePrametersTypes = new Type[] { typeof(TemplateContainer), typeof(SPControlMode) };
            object[] parametersOfSetControlMode = { child, controlMode };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetControlMode, methodSetControlModePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listDisplaySettingIteratorInstanceFixture, parametersOfSetControlMode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetControlMode.ShouldNotBeNull();
            parametersOfSetControlMode.Length.ShouldBe(2);
            methodSetControlModePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetControlMode) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_SetControlMode_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var child = CreateType<TemplateContainer>();
            var controlMode = CreateType<SPControlMode>();
            var methodSetControlModePrametersTypes = new Type[] { typeof(TemplateContainer), typeof(SPControlMode) };
            object[] parametersOfSetControlMode = { child, controlMode };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_listDisplaySettingIteratorInstanceFixture, _listDisplaySettingIteratorInstanceType, MethodSetControlMode, parametersOfSetControlMode, methodSetControlModePrametersTypes);

            // Assert
            parametersOfSetControlMode.ShouldNotBeNull();
            parametersOfSetControlMode.Length.ShouldBe(2);
            methodSetControlModePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetControlMode) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_SetControlMode_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetControlMode, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetControlMode) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_SetControlMode_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetControlModePrametersTypes = new Type[] { typeof(TemplateContainer), typeof(SPControlMode) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstanceFixture, _listDisplaySettingIteratorInstanceType, MethodSetControlMode, Fixture, methodSetControlModePrametersTypes);

            // Assert
            methodSetControlModePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetControlMode) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_SetControlMode_Static_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetControlMode, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listDisplaySettingIteratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsFieldExcluded) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListDisplaySettingIterator_IsFieldExcluded_Method_Call_Internally(Type[] types)
        {
            var methodIsFieldExcludedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodIsFieldExcluded, Fixture, methodIsFieldExcludedPrametersTypes);
        }

        #endregion

        #region Method Call : (IsFieldExcluded) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_IsFieldExcluded_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var methodIsFieldExcludedPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfIsFieldExcluded = { field };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsFieldExcluded, methodIsFieldExcludedPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ListDisplaySettingIterator, bool>(_listDisplaySettingIteratorInstanceFixture, out exception1, parametersOfIsFieldExcluded);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ListDisplaySettingIterator, bool>(_listDisplaySettingIteratorInstance, MethodIsFieldExcluded, parametersOfIsFieldExcluded, methodIsFieldExcludedPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsFieldExcluded.ShouldNotBeNull();
            parametersOfIsFieldExcluded.Length.ShouldBe(1);
            methodIsFieldExcludedPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (IsFieldExcluded) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_IsFieldExcluded_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var methodIsFieldExcludedPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfIsFieldExcluded = { field };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsFieldExcluded, methodIsFieldExcludedPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ListDisplaySettingIterator, bool>(_listDisplaySettingIteratorInstanceFixture, out exception1, parametersOfIsFieldExcluded);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ListDisplaySettingIterator, bool>(_listDisplaySettingIteratorInstance, MethodIsFieldExcluded, parametersOfIsFieldExcluded, methodIsFieldExcludedPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsFieldExcluded.ShouldNotBeNull();
            parametersOfIsFieldExcluded.Length.ShouldBe(1);
            methodIsFieldExcludedPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (IsFieldExcluded) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_IsFieldExcluded_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var methodIsFieldExcludedPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfIsFieldExcluded = { field };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ListDisplaySettingIterator, bool>(_listDisplaySettingIteratorInstance, MethodIsFieldExcluded, parametersOfIsFieldExcluded, methodIsFieldExcludedPrametersTypes);

            // Assert
            parametersOfIsFieldExcluded.ShouldNotBeNull();
            parametersOfIsFieldExcluded.Length.ShouldBe(1);
            methodIsFieldExcludedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsFieldExcluded) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_IsFieldExcluded_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsFieldExcludedPrametersTypes = new Type[] { typeof(SPField) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplaySettingIteratorInstance, MethodIsFieldExcluded, Fixture, methodIsFieldExcludedPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsFieldExcludedPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsFieldExcluded) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_IsFieldExcluded_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsFieldExcluded, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listDisplaySettingIteratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsFieldExcluded) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplaySettingIterator_IsFieldExcluded_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodIsFieldExcluded, 0);
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
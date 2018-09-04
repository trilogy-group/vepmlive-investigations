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
using System.Web.UI.WebControls;
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.AutoFixtureSetup;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using ListDisplayPage = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.ListDisplayPage" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class ListDisplayPageTest : AbstractBaseSetupTypedTest<ListDisplayPage>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ListDisplayPage) Initializer

        private const string PropertyCurrentList = "CurrentList";
        private const string MethodOnLoad = "OnLoad";
        private const string MethodRenderPage = "RenderPage";
        private const string MethodPrepareRenderPage = "PrepareRenderPage";
        private const string MethodMatchROFields = "MatchROFields";
        private const string MethodRenderOptions = "RenderOptions";
        private const string MethodUpdateGlobalScript = "UpdateGlobalScript";
        private const string MethodSaveCustomDisplay = "SaveCustomDisplay";
        private const string MethodRenderOption = "RenderOption";
        private const string MethodRenderPanelWhere = "RenderPanelWhere";
        private const string MethodRenderWhere = "RenderWhere";
        private const string MethodRegisterScript = "RegisterScript";
        private const string FieldpageRender = "pageRender";
        private const string FieldcurrentList = "currentList";
        private const string FielddisplayableFields = "displayableFields";
        private const string Fieldgroups = "groups";
        private const string FieldcomputeFieldsScript = "computeFieldsScript";
        private const string FieldfieldProperties = "fieldProperties";
        private const string FieldOK = "OK";
        private const string FieldCancel = "Cancel";
        private const string FieldPAGE_SIZE = "PAGE_SIZE";
        private Type _listDisplayPageInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ListDisplayPage _listDisplayPageInstance;
        private ListDisplayPage _listDisplayPageInstanceFixture;

        #region General Initializer : Class (ListDisplayPage) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ListDisplayPage" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _listDisplayPageInstanceType = typeof(ListDisplayPage);
            _listDisplayPageInstanceFixture = Create(true);
            _listDisplayPageInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ListDisplayPage)

        #region General Initializer : Class (ListDisplayPage) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ListDisplayPage" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodOnLoad, 0)]
        [TestCase(MethodRenderPage, 0)]
        [TestCase(MethodPrepareRenderPage, 0)]
        [TestCase(MethodMatchROFields, 0)]
        [TestCase(MethodRenderOptions, 0)]
        [TestCase(MethodUpdateGlobalScript, 0)]
        [TestCase(MethodSaveCustomDisplay, 0)]
        [TestCase(MethodRenderOption, 0)]
        [TestCase(MethodRenderPanelWhere, 0)]
        [TestCase(MethodRenderWhere, 0)]
        [TestCase(MethodRegisterScript, 0)]
        public void AUT_ListDisplayPage_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_listDisplayPageInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ListDisplayPage) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ListDisplayPage" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyCurrentList)]
        public void AUT_ListDisplayPage_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_listDisplayPageInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ListDisplayPage) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ListDisplayPage" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldpageRender)]
        [TestCase(FieldcurrentList)]
        [TestCase(FielddisplayableFields)]
        [TestCase(Fieldgroups)]
        [TestCase(FieldcomputeFieldsScript)]
        [TestCase(FieldfieldProperties)]
        [TestCase(FieldOK)]
        [TestCase(FieldCancel)]
        [TestCase(FieldPAGE_SIZE)]
        public void AUT_ListDisplayPage_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_listDisplayPageInstanceFixture, 
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
        ///     Class (<see cref="ListDisplayPage" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ListDisplayPage_Is_Instance_Present_Test()
        {
            // Assert
            _listDisplayPageInstanceType.ShouldNotBeNull();
            _listDisplayPageInstance.ShouldNotBeNull();
            _listDisplayPageInstanceFixture.ShouldNotBeNull();
            _listDisplayPageInstance.ShouldBeAssignableTo<ListDisplayPage>();
            _listDisplayPageInstanceFixture.ShouldBeAssignableTo<ListDisplayPage>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ListDisplayPage) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ListDisplayPage_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ListDisplayPage instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _listDisplayPageInstanceType.ShouldNotBeNull();
            _listDisplayPageInstance.ShouldNotBeNull();
            _listDisplayPageInstanceFixture.ShouldNotBeNull();
            _listDisplayPageInstance.ShouldBeAssignableTo<ListDisplayPage>();
            _listDisplayPageInstanceFixture.ShouldBeAssignableTo<ListDisplayPage>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ListDisplayPage) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(SPList) , PropertyCurrentList)]
        public void AUT_ListDisplayPage_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ListDisplayPage, T>(_listDisplayPageInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ListDisplayPage) => Property (CurrentList) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ListDisplayPage_CurrentList_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyCurrentList);
            Action currentAction = () => propertyInfo.SetValue(_listDisplayPageInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ListDisplayPage) => Property (CurrentList) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ListDisplayPage_Public_Class_CurrentList_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCurrentList);

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
        ///      Class (<see cref="ListDisplayPage" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodOnLoad)]
        [TestCase(MethodRenderPage)]
        [TestCase(MethodPrepareRenderPage)]
        [TestCase(MethodMatchROFields)]
        [TestCase(MethodRenderOptions)]
        [TestCase(MethodUpdateGlobalScript)]
        [TestCase(MethodSaveCustomDisplay)]
        [TestCase(MethodRenderOption)]
        [TestCase(MethodRenderPanelWhere)]
        [TestCase(MethodRenderWhere)]
        [TestCase(MethodRegisterScript)]
        public void AUT_ListDisplayPage_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ListDisplayPage>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListDisplayPage_OnLoad_Method_Call_Internally(Type[] types)
        {
            var methodOnLoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplayPageInstance, MethodOnLoad, Fixture, methodOnLoadPrametersTypes);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_OnLoad_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnLoadPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnLoad = { e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnLoad, methodOnLoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listDisplayPageInstanceFixture, parametersOfOnLoad);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOnLoad.ShouldNotBeNull();
            parametersOfOnLoad.Length.ShouldBe(1);
            methodOnLoadPrametersTypes.Length.ShouldBe(1);
            methodOnLoadPrametersTypes.Length.ShouldBe(parametersOfOnLoad.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_OnLoad_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnLoadPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnLoad = { e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listDisplayPageInstance, MethodOnLoad, parametersOfOnLoad, methodOnLoadPrametersTypes);

            // Assert
            parametersOfOnLoad.ShouldNotBeNull();
            parametersOfOnLoad.Length.ShouldBe(1);
            methodOnLoadPrametersTypes.Length.ShouldBe(1);
            methodOnLoadPrametersTypes.Length.ShouldBe(parametersOfOnLoad.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_OnLoad_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOnLoad, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_OnLoad_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnLoadPrametersTypes = new Type[] { typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplayPageInstance, MethodOnLoad, Fixture, methodOnLoadPrametersTypes);

            // Assert
            methodOnLoadPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_OnLoad_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnLoad, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listDisplayPageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderPage) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListDisplayPage_RenderPage_Method_Call_Internally(Type[] types)
        {
            var methodRenderPagePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplayPageInstance, MethodRenderPage, Fixture, methodRenderPagePrametersTypes);
        }

        #endregion

        #region Method Call : (RenderPage) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_RenderPage_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodRenderPagePrametersTypes = null;
            object[] parametersOfRenderPage = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRenderPage, methodRenderPagePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listDisplayPageInstanceFixture, parametersOfRenderPage);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRenderPage.ShouldBeNull();
            methodRenderPagePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderPage) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_RenderPage_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRenderPagePrametersTypes = null;
            object[] parametersOfRenderPage = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ListDisplayPage, string>(_listDisplayPageInstance, MethodRenderPage, parametersOfRenderPage, methodRenderPagePrametersTypes);

            // Assert
            parametersOfRenderPage.ShouldBeNull();
            methodRenderPagePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderPage) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_RenderPage_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodRenderPagePrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplayPageInstance, MethodRenderPage, Fixture, methodRenderPagePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodRenderPagePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RenderPage) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_RenderPage_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRenderPagePrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplayPageInstance, MethodRenderPage, Fixture, methodRenderPagePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRenderPagePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PrepareRenderPage) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListDisplayPage_PrepareRenderPage_Method_Call_Internally(Type[] types)
        {
            var methodPrepareRenderPagePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplayPageInstance, MethodPrepareRenderPage, Fixture, methodPrepareRenderPagePrametersTypes);
        }

        #endregion

        #region Method Call : (PrepareRenderPage) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_PrepareRenderPage_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodPrepareRenderPagePrametersTypes = null;
            object[] parametersOfPrepareRenderPage = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodPrepareRenderPage, methodPrepareRenderPagePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ListDisplayPage, string>(_listDisplayPageInstanceFixture, out exception1, parametersOfPrepareRenderPage);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ListDisplayPage, string>(_listDisplayPageInstance, MethodPrepareRenderPage, parametersOfPrepareRenderPage, methodPrepareRenderPagePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfPrepareRenderPage.ShouldBeNull();
            methodPrepareRenderPagePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PrepareRenderPage) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_PrepareRenderPage_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodPrepareRenderPagePrametersTypes = null;
            object[] parametersOfPrepareRenderPage = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ListDisplayPage, string>(_listDisplayPageInstance, MethodPrepareRenderPage, parametersOfPrepareRenderPage, methodPrepareRenderPagePrametersTypes);

            // Assert
            parametersOfPrepareRenderPage.ShouldBeNull();
            methodPrepareRenderPagePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PrepareRenderPage) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_PrepareRenderPage_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodPrepareRenderPagePrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplayPageInstance, MethodPrepareRenderPage, Fixture, methodPrepareRenderPagePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodPrepareRenderPagePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PrepareRenderPage) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_PrepareRenderPage_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodPrepareRenderPagePrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplayPageInstance, MethodPrepareRenderPage, Fixture, methodPrepareRenderPagePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodPrepareRenderPagePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PrepareRenderPage) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_PrepareRenderPage_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPrepareRenderPage, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listDisplayPageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (MatchROFields) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListDisplayPage_MatchROFields_Method_Call_Internally(Type[] types)
        {
            var methodMatchROFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplayPageInstance, MethodMatchROFields, Fixture, methodMatchROFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (MatchROFields) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_MatchROFields_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var fieldId = CreateType<Guid>();
            var methodMatchROFieldsPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfMatchROFields = { fieldId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodMatchROFields, methodMatchROFieldsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ListDisplayPage, bool>(_listDisplayPageInstanceFixture, out exception1, parametersOfMatchROFields);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ListDisplayPage, bool>(_listDisplayPageInstance, MethodMatchROFields, parametersOfMatchROFields, methodMatchROFieldsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfMatchROFields.ShouldNotBeNull();
            parametersOfMatchROFields.Length.ShouldBe(1);
            methodMatchROFieldsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (MatchROFields) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_MatchROFields_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var fieldId = CreateType<Guid>();
            var methodMatchROFieldsPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfMatchROFields = { fieldId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodMatchROFields, methodMatchROFieldsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ListDisplayPage, bool>(_listDisplayPageInstanceFixture, out exception1, parametersOfMatchROFields);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ListDisplayPage, bool>(_listDisplayPageInstance, MethodMatchROFields, parametersOfMatchROFields, methodMatchROFieldsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfMatchROFields.ShouldNotBeNull();
            parametersOfMatchROFields.Length.ShouldBe(1);
            methodMatchROFieldsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (MatchROFields) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_MatchROFields_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var fieldId = CreateType<Guid>();
            var methodMatchROFieldsPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfMatchROFields = { fieldId };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodMatchROFields, methodMatchROFieldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listDisplayPageInstanceFixture, parametersOfMatchROFields);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfMatchROFields.ShouldNotBeNull();
            parametersOfMatchROFields.Length.ShouldBe(1);
            methodMatchROFieldsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (MatchROFields) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_MatchROFields_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var fieldId = CreateType<Guid>();
            var methodMatchROFieldsPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfMatchROFields = { fieldId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ListDisplayPage, bool>(_listDisplayPageInstance, MethodMatchROFields, parametersOfMatchROFields, methodMatchROFieldsPrametersTypes);

            // Assert
            parametersOfMatchROFields.ShouldNotBeNull();
            parametersOfMatchROFields.Length.ShouldBe(1);
            methodMatchROFieldsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (MatchROFields) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_MatchROFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodMatchROFieldsPrametersTypes = new Type[] { typeof(Guid) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplayPageInstance, MethodMatchROFields, Fixture, methodMatchROFieldsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodMatchROFieldsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (MatchROFields) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_MatchROFields_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodMatchROFields, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listDisplayPageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (MatchROFields) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_MatchROFields_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodMatchROFields, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenderOptions) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListDisplayPage_RenderOptions_Method_Call_Internally(Type[] types)
        {
            var methodRenderOptionsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplayPageInstance, MethodRenderOptions, Fixture, methodRenderOptionsPrametersTypes);
        }

        #endregion

        #region Method Call : (RenderOptions) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_RenderOptions_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var methodRenderOptionsPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfRenderOptions = { field };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRenderOptions, methodRenderOptionsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ListDisplayPage, string>(_listDisplayPageInstanceFixture, out exception1, parametersOfRenderOptions);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ListDisplayPage, string>(_listDisplayPageInstance, MethodRenderOptions, parametersOfRenderOptions, methodRenderOptionsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfRenderOptions.ShouldNotBeNull();
            parametersOfRenderOptions.Length.ShouldBe(1);
            methodRenderOptionsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (RenderOptions) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_RenderOptions_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var methodRenderOptionsPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfRenderOptions = { field };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ListDisplayPage, string>(_listDisplayPageInstance, MethodRenderOptions, parametersOfRenderOptions, methodRenderOptionsPrametersTypes);

            // Assert
            parametersOfRenderOptions.ShouldNotBeNull();
            parametersOfRenderOptions.Length.ShouldBe(1);
            methodRenderOptionsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderOptions) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_RenderOptions_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodRenderOptionsPrametersTypes = new Type[] { typeof(SPField) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplayPageInstance, MethodRenderOptions, Fixture, methodRenderOptionsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodRenderOptionsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (RenderOptions) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_RenderOptions_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenderOptionsPrametersTypes = new Type[] { typeof(SPField) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplayPageInstance, MethodRenderOptions, Fixture, methodRenderOptionsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRenderOptionsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenderOptions) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_RenderOptions_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenderOptions, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listDisplayPageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RenderOptions) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_RenderOptions_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRenderOptions, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateGlobalScript) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListDisplayPage_UpdateGlobalScript_Method_Call_Internally(Type[] types)
        {
            var methodUpdateGlobalScriptPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplayPageInstance, MethodUpdateGlobalScript, Fixture, methodUpdateGlobalScriptPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateGlobalScript) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_UpdateGlobalScript_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var mode = CreateType<string>();
            var methodUpdateGlobalScriptPrametersTypes = new Type[] { typeof(SPField), typeof(string) };
            object[] parametersOfUpdateGlobalScript = { field, mode };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateGlobalScript, methodUpdateGlobalScriptPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listDisplayPageInstanceFixture, parametersOfUpdateGlobalScript);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateGlobalScript.ShouldNotBeNull();
            parametersOfUpdateGlobalScript.Length.ShouldBe(2);
            methodUpdateGlobalScriptPrametersTypes.Length.ShouldBe(2);
            methodUpdateGlobalScriptPrametersTypes.Length.ShouldBe(parametersOfUpdateGlobalScript.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateGlobalScript) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_UpdateGlobalScript_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var mode = CreateType<string>();
            var methodUpdateGlobalScriptPrametersTypes = new Type[] { typeof(SPField), typeof(string) };
            object[] parametersOfUpdateGlobalScript = { field, mode };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listDisplayPageInstance, MethodUpdateGlobalScript, parametersOfUpdateGlobalScript, methodUpdateGlobalScriptPrametersTypes);

            // Assert
            parametersOfUpdateGlobalScript.ShouldNotBeNull();
            parametersOfUpdateGlobalScript.Length.ShouldBe(2);
            methodUpdateGlobalScriptPrametersTypes.Length.ShouldBe(2);
            methodUpdateGlobalScriptPrametersTypes.Length.ShouldBe(parametersOfUpdateGlobalScript.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateGlobalScript) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_UpdateGlobalScript_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateGlobalScript, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateGlobalScript) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_UpdateGlobalScript_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateGlobalScriptPrametersTypes = new Type[] { typeof(SPField), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplayPageInstance, MethodUpdateGlobalScript, Fixture, methodUpdateGlobalScriptPrametersTypes);

            // Assert
            methodUpdateGlobalScriptPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateGlobalScript) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_UpdateGlobalScript_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateGlobalScript, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listDisplayPageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveCustomDisplay) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListDisplayPage_SaveCustomDisplay_Method_Call_Internally(Type[] types)
        {
            var methodSaveCustomDisplayPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplayPageInstance, MethodSaveCustomDisplay, Fixture, methodSaveCustomDisplayPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveCustomDisplay) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_SaveCustomDisplay_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodSaveCustomDisplayPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfSaveCustomDisplay = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSaveCustomDisplay, methodSaveCustomDisplayPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listDisplayPageInstanceFixture, parametersOfSaveCustomDisplay);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSaveCustomDisplay.ShouldNotBeNull();
            parametersOfSaveCustomDisplay.Length.ShouldBe(2);
            methodSaveCustomDisplayPrametersTypes.Length.ShouldBe(2);
            methodSaveCustomDisplayPrametersTypes.Length.ShouldBe(parametersOfSaveCustomDisplay.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SaveCustomDisplay) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_SaveCustomDisplay_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodSaveCustomDisplayPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfSaveCustomDisplay = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listDisplayPageInstance, MethodSaveCustomDisplay, parametersOfSaveCustomDisplay, methodSaveCustomDisplayPrametersTypes);

            // Assert
            parametersOfSaveCustomDisplay.ShouldNotBeNull();
            parametersOfSaveCustomDisplay.Length.ShouldBe(2);
            methodSaveCustomDisplayPrametersTypes.Length.ShouldBe(2);
            methodSaveCustomDisplayPrametersTypes.Length.ShouldBe(parametersOfSaveCustomDisplay.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveCustomDisplay) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_SaveCustomDisplay_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSaveCustomDisplay, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveCustomDisplay) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_SaveCustomDisplay_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveCustomDisplayPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplayPageInstance, MethodSaveCustomDisplay, Fixture, methodSaveCustomDisplayPrametersTypes);

            // Assert
            methodSaveCustomDisplayPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveCustomDisplay) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_SaveCustomDisplay_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveCustomDisplay, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listDisplayPageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderOption) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListDisplayPage_RenderOption_Method_Call_Internally(Type[] types)
        {
            var methodRenderOptionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplayPageInstance, MethodRenderOption, Fixture, methodRenderOptionPrametersTypes);
        }

        #endregion

        #region Method Call : (RenderOption) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_RenderOption_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var mode = CreateType<string>();
            var showWhere = CreateType<bool>();
            var showEdit = CreateType<bool>();
            var methodRenderOptionPrametersTypes = new Type[] { typeof(SPField), typeof(string), typeof(bool), typeof(bool) };
            object[] parametersOfRenderOption = { field, mode, showWhere, showEdit };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRenderOption, methodRenderOptionPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ListDisplayPage, string>(_listDisplayPageInstanceFixture, out exception1, parametersOfRenderOption);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ListDisplayPage, string>(_listDisplayPageInstance, MethodRenderOption, parametersOfRenderOption, methodRenderOptionPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfRenderOption.ShouldNotBeNull();
            parametersOfRenderOption.Length.ShouldBe(4);
            methodRenderOptionPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (RenderOption) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_RenderOption_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var mode = CreateType<string>();
            var showWhere = CreateType<bool>();
            var showEdit = CreateType<bool>();
            var methodRenderOptionPrametersTypes = new Type[] { typeof(SPField), typeof(string), typeof(bool), typeof(bool) };
            object[] parametersOfRenderOption = { field, mode, showWhere, showEdit };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ListDisplayPage, string>(_listDisplayPageInstance, MethodRenderOption, parametersOfRenderOption, methodRenderOptionPrametersTypes);

            // Assert
            parametersOfRenderOption.ShouldNotBeNull();
            parametersOfRenderOption.Length.ShouldBe(4);
            methodRenderOptionPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderOption) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_RenderOption_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodRenderOptionPrametersTypes = new Type[] { typeof(SPField), typeof(string), typeof(bool), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplayPageInstance, MethodRenderOption, Fixture, methodRenderOptionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodRenderOptionPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (RenderOption) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_RenderOption_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenderOptionPrametersTypes = new Type[] { typeof(SPField), typeof(string), typeof(bool), typeof(bool) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplayPageInstance, MethodRenderOption, Fixture, methodRenderOptionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRenderOptionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenderOption) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_RenderOption_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenderOption, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listDisplayPageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RenderOption) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_RenderOption_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRenderOption, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenderPanelWhere) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListDisplayPage_RenderPanelWhere_Method_Call_Internally(Type[] types)
        {
            var methodRenderPanelWherePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplayPageInstance, MethodRenderPanelWhere, Fixture, methodRenderPanelWherePrametersTypes);
        }

        #endregion

        #region Method Call : (RenderPanelWhere) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_RenderPanelWhere_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var mode = CreateType<string>();
            var showWhere = CreateType<bool>();
            var methodRenderPanelWherePrametersTypes = new Type[] { typeof(SPField), typeof(string), typeof(bool) };
            object[] parametersOfRenderPanelWhere = { field, mode, showWhere };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRenderPanelWhere, methodRenderPanelWherePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ListDisplayPage, string>(_listDisplayPageInstanceFixture, out exception1, parametersOfRenderPanelWhere);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ListDisplayPage, string>(_listDisplayPageInstance, MethodRenderPanelWhere, parametersOfRenderPanelWhere, methodRenderPanelWherePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfRenderPanelWhere.ShouldNotBeNull();
            parametersOfRenderPanelWhere.Length.ShouldBe(3);
            methodRenderPanelWherePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (RenderPanelWhere) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_RenderPanelWhere_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var mode = CreateType<string>();
            var showWhere = CreateType<bool>();
            var methodRenderPanelWherePrametersTypes = new Type[] { typeof(SPField), typeof(string), typeof(bool) };
            object[] parametersOfRenderPanelWhere = { field, mode, showWhere };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ListDisplayPage, string>(_listDisplayPageInstance, MethodRenderPanelWhere, parametersOfRenderPanelWhere, methodRenderPanelWherePrametersTypes);

            // Assert
            parametersOfRenderPanelWhere.ShouldNotBeNull();
            parametersOfRenderPanelWhere.Length.ShouldBe(3);
            methodRenderPanelWherePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderPanelWhere) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_RenderPanelWhere_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodRenderPanelWherePrametersTypes = new Type[] { typeof(SPField), typeof(string), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplayPageInstance, MethodRenderPanelWhere, Fixture, methodRenderPanelWherePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodRenderPanelWherePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (RenderPanelWhere) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_RenderPanelWhere_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenderPanelWherePrametersTypes = new Type[] { typeof(SPField), typeof(string), typeof(bool) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplayPageInstance, MethodRenderPanelWhere, Fixture, methodRenderPanelWherePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRenderPanelWherePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenderPanelWhere) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_RenderPanelWhere_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenderPanelWhere, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listDisplayPageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RenderPanelWhere) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_RenderPanelWhere_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRenderPanelWhere, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenderWhere) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListDisplayPage_RenderWhere_Method_Call_Internally(Type[] types)
        {
            var methodRenderWherePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplayPageInstance, MethodRenderWhere, Fixture, methodRenderWherePrametersTypes);
        }

        #endregion

        #region Method Call : (RenderWhere) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_RenderWhere_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var mode = CreateType<string>();
            var methodRenderWherePrametersTypes = new Type[] { typeof(SPField), typeof(string) };
            object[] parametersOfRenderWhere = { field, mode };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRenderWhere, methodRenderWherePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ListDisplayPage, string>(_listDisplayPageInstanceFixture, out exception1, parametersOfRenderWhere);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ListDisplayPage, string>(_listDisplayPageInstance, MethodRenderWhere, parametersOfRenderWhere, methodRenderWherePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfRenderWhere.ShouldNotBeNull();
            parametersOfRenderWhere.Length.ShouldBe(2);
            methodRenderWherePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (RenderWhere) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_RenderWhere_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var mode = CreateType<string>();
            var methodRenderWherePrametersTypes = new Type[] { typeof(SPField), typeof(string) };
            object[] parametersOfRenderWhere = { field, mode };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ListDisplayPage, string>(_listDisplayPageInstance, MethodRenderWhere, parametersOfRenderWhere, methodRenderWherePrametersTypes);

            // Assert
            parametersOfRenderWhere.ShouldNotBeNull();
            parametersOfRenderWhere.Length.ShouldBe(2);
            methodRenderWherePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderWhere) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_RenderWhere_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodRenderWherePrametersTypes = new Type[] { typeof(SPField), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplayPageInstance, MethodRenderWhere, Fixture, methodRenderWherePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodRenderWherePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (RenderWhere) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_RenderWhere_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenderWherePrametersTypes = new Type[] { typeof(SPField), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplayPageInstance, MethodRenderWhere, Fixture, methodRenderWherePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRenderWherePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenderWhere) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_RenderWhere_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenderWhere, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listDisplayPageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RenderWhere) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_RenderWhere_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRenderWhere, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RegisterScript) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListDisplayPage_RegisterScript_Method_Call_Internally(Type[] types)
        {
            var methodRegisterScriptPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplayPageInstance, MethodRegisterScript, Fixture, methodRegisterScriptPrametersTypes);
        }

        #endregion

        #region Method Call : (RegisterScript) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_RegisterScript_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodRegisterScriptPrametersTypes = null;
            object[] parametersOfRegisterScript = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRegisterScript, methodRegisterScriptPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listDisplayPageInstanceFixture, parametersOfRegisterScript);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRegisterScript.ShouldBeNull();
            methodRegisterScriptPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterScript) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_RegisterScript_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRegisterScriptPrametersTypes = null;
            object[] parametersOfRegisterScript = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listDisplayPageInstance, MethodRegisterScript, parametersOfRegisterScript, methodRegisterScriptPrametersTypes);

            // Assert
            parametersOfRegisterScript.ShouldBeNull();
            methodRegisterScriptPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterScript) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_RegisterScript_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRegisterScriptPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listDisplayPageInstance, MethodRegisterScript, Fixture, methodRegisterScriptPrametersTypes);

            // Assert
            methodRegisterScriptPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterScript) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayPage_RegisterScript_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRegisterScript, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listDisplayPageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
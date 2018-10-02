using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
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
using EPMLiveCore.GlobalResources;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using GenericQueryControl = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.GenericQueryControl" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class GenericQueryControlTest : AbstractBaseSetupTypedTest<GenericQueryControl>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (GenericQueryControl) Initializer

        private const string PropertyWeb = "Web";
        private const string PropertyList = "List";
        private const string PropertyPropertyBag = "PropertyBag";
        private const string MethodOnLoad = "OnLoad";
        private const string MethodOnUnload = "OnUnload";
        private const string MethodGetListTable = "GetListTable";
        private const string MethodIssueQuery = "IssueQuery";
        private const string MethodGetEntity = "GetEntity";
        private const string MethodCreateChildControls = "CreateChildControls";
        private const string MethodFillSearchOperators = "FillSearchOperators";
        private const string MethodOnPreRender = "OnPreRender";
        private const string MethodGenerateContextScript = "GenerateContextScript";
        private const string MethodGetCallbackResult = "GetCallbackResult";
        private const string MethodRaiseCallbackEvent = "RaiseCallbackEvent";
        private const string MethodDispose = "Dispose";
        private const string MethodDisposeTable = "DisposeTable";
        private const string FieldpropertyBag = "propertyBag";
        private const string Fieldweb = "web";
        private const string Fieldlist = "list";
        private const string FielddataTable = "dataTable";
        private const string FieldsearchField = "searchField";
        private const string FieldsearchOperator = "searchOperator";
        private const string FielddrpdSearchOperators = "drpdSearchOperators";
        private Type _genericQueryControlInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private GenericQueryControl _genericQueryControlInstance;
        private GenericQueryControl _genericQueryControlInstanceFixture;

        #region General Initializer : Class (GenericQueryControl) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="GenericQueryControl" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _genericQueryControlInstanceType = typeof(GenericQueryControl);
            _genericQueryControlInstanceFixture = Create(true);
            _genericQueryControlInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (GenericQueryControl)

        #region General Initializer : Class (GenericQueryControl) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="GenericQueryControl" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodOnLoad, 0)]
        [TestCase(MethodOnUnload, 0)]
        [TestCase(MethodGetListTable, 0)]
        [TestCase(MethodIssueQuery, 0)]
        [TestCase(MethodGetEntity, 0)]
        [TestCase(MethodCreateChildControls, 0)]
        [TestCase(MethodFillSearchOperators, 0)]
        [TestCase(MethodOnPreRender, 0)]
        [TestCase(MethodGenerateContextScript, 0)]
        [TestCase(MethodGetCallbackResult, 0)]
        [TestCase(MethodRaiseCallbackEvent, 0)]
        public void AUT_GenericQueryControl_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_genericQueryControlInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (GenericQueryControl) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="GenericQueryControl" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyWeb)]
        [TestCase(PropertyList)]
        [TestCase(PropertyPropertyBag)]
        public void AUT_GenericQueryControl_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_genericQueryControlInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (GenericQueryControl) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="GenericQueryControl" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldpropertyBag)]
        [TestCase(Fieldweb)]
        [TestCase(Fieldlist)]
        [TestCase(FielddataTable)]
        [TestCase(FieldsearchField)]
        [TestCase(FieldsearchOperator)]
        [TestCase(FielddrpdSearchOperators)]
        public void AUT_GenericQueryControl_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_genericQueryControlInstanceFixture, 
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
        ///     Class (<see cref="GenericQueryControl" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_GenericQueryControl_Is_Instance_Present_Test()
        {
            // Assert
            _genericQueryControlInstanceType.ShouldNotBeNull();
            _genericQueryControlInstance.ShouldNotBeNull();
            _genericQueryControlInstanceFixture.ShouldNotBeNull();
            _genericQueryControlInstance.ShouldBeAssignableTo<GenericQueryControl>();
            _genericQueryControlInstanceFixture.ShouldBeAssignableTo<GenericQueryControl>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (GenericQueryControl) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_GenericQueryControl_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            GenericQueryControl instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _genericQueryControlInstanceType.ShouldNotBeNull();
            _genericQueryControlInstance.ShouldNotBeNull();
            _genericQueryControlInstanceFixture.ShouldNotBeNull();
            _genericQueryControlInstance.ShouldBeAssignableTo<GenericQueryControl>();
            _genericQueryControlInstanceFixture.ShouldBeAssignableTo<GenericQueryControl>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (GenericQueryControl) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(SPWeb) , PropertyWeb)]
        [TestCaseGeneric(typeof(SPList) , PropertyList)]
        [TestCaseGeneric(typeof(GenericEntityPickerPropertyBag) , PropertyPropertyBag)]
        public void AUT_GenericQueryControl_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<GenericQueryControl, T>(_genericQueryControlInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (GenericQueryControl) => Property (List) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GenericQueryControl_List_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyList);
            Action currentAction = () => propertyInfo.SetValue(_genericQueryControlInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (GenericQueryControl) => Property (List) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GenericQueryControl_Public_Class_List_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyList);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GenericQueryControl) => Property (PropertyBag) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GenericQueryControl_PropertyBag_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyPropertyBag);
            Action currentAction = () => propertyInfo.SetValue(_genericQueryControlInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (GenericQueryControl) => Property (PropertyBag) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GenericQueryControl_Public_Class_PropertyBag_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropertyBag);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GenericQueryControl) => Property (Web) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GenericQueryControl_Web_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyWeb);
            Action currentAction = () => propertyInfo.SetValue(_genericQueryControlInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (GenericQueryControl) => Property (Web) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GenericQueryControl_Public_Class_Web_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyWeb);

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
        ///      Class (<see cref="GenericQueryControl" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodOnLoad)]
        [TestCase(MethodOnUnload)]
        [TestCase(MethodGetListTable)]
        [TestCase(MethodIssueQuery)]
        [TestCase(MethodGetEntity)]
        [TestCase(MethodCreateChildControls)]
        [TestCase(MethodFillSearchOperators)]
        [TestCase(MethodOnPreRender)]
        [TestCase(MethodGenerateContextScript)]
        [TestCase(MethodGetCallbackResult)]
        [TestCase(MethodRaiseCallbackEvent)]
        [TestCase(MethodDispose)]
        public void AUT_GenericQueryControl_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<GenericQueryControl>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GenericQueryControl_OnLoad_Method_Call_Internally(Type[] types)
        {
            var methodOnLoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericQueryControlInstance, MethodOnLoad, Fixture, methodOnLoadPrametersTypes);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_OnLoad_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnLoadPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnLoad = { e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnLoad, methodOnLoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_genericQueryControlInstanceFixture, parametersOfOnLoad);

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
        public void AUT_GenericQueryControl_OnLoad_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnLoadPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnLoad = { e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_genericQueryControlInstance, MethodOnLoad, parametersOfOnLoad, methodOnLoadPrametersTypes);

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
        public void AUT_GenericQueryControl_OnLoad_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_GenericQueryControl_OnLoad_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnLoadPrametersTypes = new Type[] { typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericQueryControlInstance, MethodOnLoad, Fixture, methodOnLoadPrametersTypes);

            // Assert
            methodOnLoadPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_OnLoad_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnLoad, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_genericQueryControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnUnload) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GenericQueryControl_OnUnload_Method_Call_Internally(Type[] types)
        {
            var methodOnUnloadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericQueryControlInstance, MethodOnUnload, Fixture, methodOnUnloadPrametersTypes);
        }

        #endregion

        #region Method Call : (OnUnload) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_OnUnload_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnUnloadPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnUnload = { e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnUnload, methodOnUnloadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_genericQueryControlInstanceFixture, parametersOfOnUnload);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOnUnload.ShouldNotBeNull();
            parametersOfOnUnload.Length.ShouldBe(1);
            methodOnUnloadPrametersTypes.Length.ShouldBe(1);
            methodOnUnloadPrametersTypes.Length.ShouldBe(parametersOfOnUnload.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnUnload) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_OnUnload_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnUnloadPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnUnload = { e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_genericQueryControlInstance, MethodOnUnload, parametersOfOnUnload, methodOnUnloadPrametersTypes);

            // Assert
            parametersOfOnUnload.ShouldNotBeNull();
            parametersOfOnUnload.Length.ShouldBe(1);
            methodOnUnloadPrametersTypes.Length.ShouldBe(1);
            methodOnUnloadPrametersTypes.Length.ShouldBe(parametersOfOnUnload.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnUnload) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_OnUnload_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOnUnload, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnUnload) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_OnUnload_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnUnloadPrametersTypes = new Type[] { typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericQueryControlInstance, MethodOnUnload, Fixture, methodOnUnloadPrametersTypes);

            // Assert
            methodOnUnloadPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnUnload) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_OnUnload_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnUnload, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_genericQueryControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListTable) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GenericQueryControl_GetListTable_Method_Call_Internally(Type[] types)
        {
            var methodGetListTablePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericQueryControlInstance, MethodGetListTable, Fixture, methodGetListTablePrametersTypes);
        }

        #endregion

        #region Method Call : (GetListTable) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_GetListTable_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var search = CreateType<string>();
            var groupName = CreateType<string>();
            var methodGetListTablePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfGetListTable = { search, groupName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetListTable, methodGetListTablePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GenericQueryControl, DataTable>(_genericQueryControlInstanceFixture, out exception1, parametersOfGetListTable);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GenericQueryControl, DataTable>(_genericQueryControlInstance, MethodGetListTable, parametersOfGetListTable, methodGetListTablePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetListTable.ShouldNotBeNull();
            parametersOfGetListTable.Length.ShouldBe(2);
            methodGetListTablePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetListTable) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_GetListTable_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var search = CreateType<string>();
            var groupName = CreateType<string>();
            var methodGetListTablePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfGetListTable = { search, groupName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GenericQueryControl, DataTable>(_genericQueryControlInstance, MethodGetListTable, parametersOfGetListTable, methodGetListTablePrametersTypes);

            // Assert
            parametersOfGetListTable.ShouldNotBeNull();
            parametersOfGetListTable.Length.ShouldBe(2);
            methodGetListTablePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListTable) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_GetListTable_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetListTablePrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericQueryControlInstance, MethodGetListTable, Fixture, methodGetListTablePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetListTablePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetListTable) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_GetListTable_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetListTablePrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericQueryControlInstance, MethodGetListTable, Fixture, methodGetListTablePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListTablePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListTable) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_GetListTable_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListTable, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_genericQueryControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListTable) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_GetListTable_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetListTable, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IssueQuery) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GenericQueryControl_IssueQuery_Method_Call_Internally(Type[] types)
        {
            var methodIssueQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericQueryControlInstance, MethodIssueQuery, Fixture, methodIssueQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (IssueQuery) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_IssueQuery_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var search = CreateType<string>();
            var groupName = CreateType<string>();
            var pageIndex = CreateType<int>();
            var pageSize = CreateType<int>();
            var methodIssueQueryPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(int), typeof(int) };
            object[] parametersOfIssueQuery = { search, groupName, pageIndex, pageSize };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIssueQuery, methodIssueQueryPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GenericQueryControl, int>(_genericQueryControlInstanceFixture, out exception1, parametersOfIssueQuery);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GenericQueryControl, int>(_genericQueryControlInstance, MethodIssueQuery, parametersOfIssueQuery, methodIssueQueryPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIssueQuery.ShouldNotBeNull();
            parametersOfIssueQuery.Length.ShouldBe(4);
            methodIssueQueryPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (IssueQuery) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_IssueQuery_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var search = CreateType<string>();
            var groupName = CreateType<string>();
            var pageIndex = CreateType<int>();
            var pageSize = CreateType<int>();
            var methodIssueQueryPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(int), typeof(int) };
            object[] parametersOfIssueQuery = { search, groupName, pageIndex, pageSize };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIssueQuery, methodIssueQueryPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GenericQueryControl, int>(_genericQueryControlInstanceFixture, out exception1, parametersOfIssueQuery);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GenericQueryControl, int>(_genericQueryControlInstance, MethodIssueQuery, parametersOfIssueQuery, methodIssueQueryPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIssueQuery.ShouldNotBeNull();
            parametersOfIssueQuery.Length.ShouldBe(4);
            methodIssueQueryPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (IssueQuery) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_IssueQuery_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var search = CreateType<string>();
            var groupName = CreateType<string>();
            var pageIndex = CreateType<int>();
            var pageSize = CreateType<int>();
            var methodIssueQueryPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(int), typeof(int) };
            object[] parametersOfIssueQuery = { search, groupName, pageIndex, pageSize };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GenericQueryControl, int>(_genericQueryControlInstance, MethodIssueQuery, parametersOfIssueQuery, methodIssueQueryPrametersTypes);

            // Assert
            parametersOfIssueQuery.ShouldNotBeNull();
            parametersOfIssueQuery.Length.ShouldBe(4);
            methodIssueQueryPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IssueQuery) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_IssueQuery_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIssueQueryPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(int), typeof(int) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericQueryControlInstance, MethodIssueQuery, Fixture, methodIssueQueryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIssueQueryPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IssueQuery) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_IssueQuery_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIssueQuery, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_genericQueryControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IssueQuery) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_IssueQuery_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodIssueQuery, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetEntity) (Return Type : PickerEntity) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GenericQueryControl_GetEntity_Method_Call_Internally(Type[] types)
        {
            var methodGetEntityPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericQueryControlInstance, MethodGetEntity, Fixture, methodGetEntityPrametersTypes);
        }

        #endregion

        #region Method Call : (GetEntity) (Return Type : PickerEntity) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_GetEntity_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var row = CreateType<DataRow>();
            Action executeAction = null;

            // Act
            executeAction = () => _genericQueryControlInstance.GetEntity(row);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetEntity) (Return Type : PickerEntity) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_GetEntity_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var row = CreateType<DataRow>();
            var methodGetEntityPrametersTypes = new Type[] { typeof(DataRow) };
            object[] parametersOfGetEntity = { row };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetEntity, methodGetEntityPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GenericQueryControl, PickerEntity>(_genericQueryControlInstanceFixture, out exception1, parametersOfGetEntity);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GenericQueryControl, PickerEntity>(_genericQueryControlInstance, MethodGetEntity, parametersOfGetEntity, methodGetEntityPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetEntity.ShouldNotBeNull();
            parametersOfGetEntity.Length.ShouldBe(1);
            methodGetEntityPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetEntity) (Return Type : PickerEntity) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_GetEntity_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var row = CreateType<DataRow>();
            var methodGetEntityPrametersTypes = new Type[] { typeof(DataRow) };
            object[] parametersOfGetEntity = { row };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GenericQueryControl, PickerEntity>(_genericQueryControlInstance, MethodGetEntity, parametersOfGetEntity, methodGetEntityPrametersTypes);

            // Assert
            parametersOfGetEntity.ShouldNotBeNull();
            parametersOfGetEntity.Length.ShouldBe(1);
            methodGetEntityPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetEntity) (Return Type : PickerEntity) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_GetEntity_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetEntityPrametersTypes = new Type[] { typeof(DataRow) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericQueryControlInstance, MethodGetEntity, Fixture, methodGetEntityPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetEntityPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetEntity) (Return Type : PickerEntity) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_GetEntity_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetEntityPrametersTypes = new Type[] { typeof(DataRow) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericQueryControlInstance, MethodGetEntity, Fixture, methodGetEntityPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetEntityPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetEntity) (Return Type : PickerEntity) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_GetEntity_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetEntity, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_genericQueryControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetEntity) (Return Type : PickerEntity) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_GetEntity_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetEntity, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GenericQueryControl_CreateChildControls_Method_Call_Internally(Type[] types)
        {
            var methodCreateChildControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericQueryControlInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, methodCreateChildControlsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_genericQueryControlInstanceFixture, parametersOfCreateChildControls);

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
        public void AUT_GenericQueryControl_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_genericQueryControlInstance, MethodCreateChildControls, parametersOfCreateChildControls, methodCreateChildControlsPrametersTypes);

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
        public void AUT_GenericQueryControl_CreateChildControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericQueryControlInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);

            // Assert
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_CreateChildControls_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_genericQueryControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FillSearchOperators) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GenericQueryControl_FillSearchOperators_Method_Call_Internally(Type[] types)
        {
            var methodFillSearchOperatorsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericQueryControlInstance, MethodFillSearchOperators, Fixture, methodFillSearchOperatorsPrametersTypes);
        }

        #endregion

        #region Method Call : (FillSearchOperators) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_FillSearchOperators_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var searchField = CreateType<string>();
            var methodFillSearchOperatorsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfFillSearchOperators = { searchField };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodFillSearchOperators, methodFillSearchOperatorsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_genericQueryControlInstanceFixture, parametersOfFillSearchOperators);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfFillSearchOperators.ShouldNotBeNull();
            parametersOfFillSearchOperators.Length.ShouldBe(1);
            methodFillSearchOperatorsPrametersTypes.Length.ShouldBe(1);
            methodFillSearchOperatorsPrametersTypes.Length.ShouldBe(parametersOfFillSearchOperators.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (FillSearchOperators) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_FillSearchOperators_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var searchField = CreateType<string>();
            var methodFillSearchOperatorsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfFillSearchOperators = { searchField };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_genericQueryControlInstance, MethodFillSearchOperators, parametersOfFillSearchOperators, methodFillSearchOperatorsPrametersTypes);

            // Assert
            parametersOfFillSearchOperators.ShouldNotBeNull();
            parametersOfFillSearchOperators.Length.ShouldBe(1);
            methodFillSearchOperatorsPrametersTypes.Length.ShouldBe(1);
            methodFillSearchOperatorsPrametersTypes.Length.ShouldBe(parametersOfFillSearchOperators.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FillSearchOperators) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_FillSearchOperators_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodFillSearchOperators, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FillSearchOperators) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_FillSearchOperators_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFillSearchOperatorsPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericQueryControlInstance, MethodFillSearchOperators, Fixture, methodFillSearchOperatorsPrametersTypes);

            // Assert
            methodFillSearchOperatorsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FillSearchOperators) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_FillSearchOperators_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFillSearchOperators, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_genericQueryControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GenericQueryControl_OnPreRender_Method_Call_Internally(Type[] types)
        {
            var methodOnPreRenderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericQueryControlInstance, MethodOnPreRender, Fixture, methodOnPreRenderPrametersTypes);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_OnPreRender_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnPreRender = { e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnPreRender, methodOnPreRenderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_genericQueryControlInstanceFixture, parametersOfOnPreRender);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOnPreRender.ShouldNotBeNull();
            parametersOfOnPreRender.Length.ShouldBe(1);
            methodOnPreRenderPrametersTypes.Length.ShouldBe(1);
            methodOnPreRenderPrametersTypes.Length.ShouldBe(parametersOfOnPreRender.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_OnPreRender_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnPreRender = { e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_genericQueryControlInstance, MethodOnPreRender, parametersOfOnPreRender, methodOnPreRenderPrametersTypes);

            // Assert
            parametersOfOnPreRender.ShouldNotBeNull();
            parametersOfOnPreRender.Length.ShouldBe(1);
            methodOnPreRenderPrametersTypes.Length.ShouldBe(1);
            methodOnPreRenderPrametersTypes.Length.ShouldBe(parametersOfOnPreRender.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_OnPreRender_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOnPreRender, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_OnPreRender_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericQueryControlInstance, MethodOnPreRender, Fixture, methodOnPreRenderPrametersTypes);

            // Assert
            methodOnPreRenderPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_OnPreRender_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnPreRender, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_genericQueryControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GenerateContextScript) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GenericQueryControl_GenerateContextScript_Method_Call_Internally(Type[] types)
        {
            var methodGenerateContextScriptPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericQueryControlInstance, MethodGenerateContextScript, Fixture, methodGenerateContextScriptPrametersTypes);
        }

        #endregion

        #region Method Call : (GenerateContextScript) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_GenerateContextScript_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodGenerateContextScriptPrametersTypes = null;
            object[] parametersOfGenerateContextScript = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGenerateContextScript, methodGenerateContextScriptPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GenericQueryControl, string>(_genericQueryControlInstanceFixture, out exception1, parametersOfGenerateContextScript);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GenericQueryControl, string>(_genericQueryControlInstance, MethodGenerateContextScript, parametersOfGenerateContextScript, methodGenerateContextScriptPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGenerateContextScript.ShouldBeNull();
            methodGenerateContextScriptPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GenerateContextScript) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_GenerateContextScript_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGenerateContextScriptPrametersTypes = null;
            object[] parametersOfGenerateContextScript = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGenerateContextScript, methodGenerateContextScriptPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_genericQueryControlInstanceFixture, parametersOfGenerateContextScript);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGenerateContextScript.ShouldBeNull();
            methodGenerateContextScriptPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GenerateContextScript) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_GenerateContextScript_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGenerateContextScriptPrametersTypes = null;
            object[] parametersOfGenerateContextScript = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GenericQueryControl, string>(_genericQueryControlInstance, MethodGenerateContextScript, parametersOfGenerateContextScript, methodGenerateContextScriptPrametersTypes);

            // Assert
            parametersOfGenerateContextScript.ShouldBeNull();
            methodGenerateContextScriptPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion
        
        #region Method Call : (GenerateContextScript) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_GenerateContextScript_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGenerateContextScriptPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericQueryControlInstance, MethodGenerateContextScript, Fixture, methodGenerateContextScriptPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGenerateContextScriptPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GenerateContextScript) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_GenerateContextScript_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGenerateContextScript, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_genericQueryControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetCallbackResult) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GenericQueryControl_GetCallbackResult_Method_Call_Internally(Type[] types)
        {
            var methodGetCallbackResultPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericQueryControlInstance, MethodGetCallbackResult, Fixture, methodGetCallbackResultPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCallbackResult) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_GetCallbackResult_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _genericQueryControlInstance.GetCallbackResult();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetCallbackResult) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_GetCallbackResult_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetCallbackResultPrametersTypes = null;
            object[] parametersOfGetCallbackResult = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetCallbackResult, methodGetCallbackResultPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GenericQueryControl, string>(_genericQueryControlInstanceFixture, out exception1, parametersOfGetCallbackResult);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GenericQueryControl, string>(_genericQueryControlInstance, MethodGetCallbackResult, parametersOfGetCallbackResult, methodGetCallbackResultPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetCallbackResult.ShouldBeNull();
            methodGetCallbackResultPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCallbackResult) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_GetCallbackResult_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetCallbackResultPrametersTypes = null;
            object[] parametersOfGetCallbackResult = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GenericQueryControl, string>(_genericQueryControlInstance, MethodGetCallbackResult, parametersOfGetCallbackResult, methodGetCallbackResultPrametersTypes);

            // Assert
            parametersOfGetCallbackResult.ShouldBeNull();
            methodGetCallbackResultPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCallbackResult) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_GetCallbackResult_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetCallbackResultPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericQueryControlInstance, MethodGetCallbackResult, Fixture, methodGetCallbackResultPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCallbackResultPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCallbackResult) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_GetCallbackResult_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetCallbackResultPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericQueryControlInstance, MethodGetCallbackResult, Fixture, methodGetCallbackResultPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCallbackResultPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCallbackResult) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_GetCallbackResult_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCallbackResult, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_genericQueryControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RaiseCallbackEvent) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GenericQueryControl_RaiseCallbackEvent_Method_Call_Internally(Type[] types)
        {
            var methodRaiseCallbackEventPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericQueryControlInstance, MethodRaiseCallbackEvent, Fixture, methodRaiseCallbackEventPrametersTypes);
        }

        #endregion

        #region Method Call : (RaiseCallbackEvent) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_RaiseCallbackEvent_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var eventArgument = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _genericQueryControlInstance.RaiseCallbackEvent(eventArgument);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (RaiseCallbackEvent) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_RaiseCallbackEvent_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var eventArgument = CreateType<string>();
            var methodRaiseCallbackEventPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaiseCallbackEvent = { eventArgument };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRaiseCallbackEvent, methodRaiseCallbackEventPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_genericQueryControlInstanceFixture, parametersOfRaiseCallbackEvent);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRaiseCallbackEvent.ShouldNotBeNull();
            parametersOfRaiseCallbackEvent.Length.ShouldBe(1);
            methodRaiseCallbackEventPrametersTypes.Length.ShouldBe(1);
            methodRaiseCallbackEventPrametersTypes.Length.ShouldBe(parametersOfRaiseCallbackEvent.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaiseCallbackEvent) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_RaiseCallbackEvent_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var eventArgument = CreateType<string>();
            var methodRaiseCallbackEventPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaiseCallbackEvent = { eventArgument };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_genericQueryControlInstance, MethodRaiseCallbackEvent, parametersOfRaiseCallbackEvent, methodRaiseCallbackEventPrametersTypes);

            // Assert
            parametersOfRaiseCallbackEvent.ShouldNotBeNull();
            parametersOfRaiseCallbackEvent.Length.ShouldBe(1);
            methodRaiseCallbackEventPrametersTypes.Length.ShouldBe(1);
            methodRaiseCallbackEventPrametersTypes.Length.ShouldBe(parametersOfRaiseCallbackEvent.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaiseCallbackEvent) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_RaiseCallbackEvent_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRaiseCallbackEvent, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RaiseCallbackEvent) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_RaiseCallbackEvent_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRaiseCallbackEventPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericQueryControlInstance, MethodRaiseCallbackEvent, Fixture, methodRaiseCallbackEventPrametersTypes);

            // Assert
            methodRaiseCallbackEventPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaiseCallbackEvent) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_RaiseCallbackEvent_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRaiseCallbackEvent, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_genericQueryControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GenericQueryControl_Dispose_Method_Call_Internally(Type[] types)
        {
            var methodDisposePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericQueryControlInstance, MethodDispose, Fixture, methodDisposePrametersTypes);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_Dispose_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _genericQueryControlInstance.Dispose();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_Dispose_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodDisposePrametersTypes = null;
            object[] parametersOfDispose = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_genericQueryControlInstance, MethodDispose, parametersOfDispose, methodDisposePrametersTypes);

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
        public void AUT_GenericQueryControl_Dispose_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodDisposePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericQueryControlInstance, MethodDispose, Fixture, methodDisposePrametersTypes);

            // Assert
            methodDisposePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DisposeTable) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GenericQueryControl_DisposeTable_Method_Call_Internally(Type[] types)
        {
            var methodDisposeTablePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericQueryControlInstance, MethodDisposeTable, Fixture, methodDisposeTablePrametersTypes);
        }

        #endregion

        #region Method Call : (DisposeTable) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_DisposeTable_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var table = CreateType<Table>();
            var methodDisposeTablePrametersTypes = new Type[] { typeof(Table) };
            object[] parametersOfDisposeTable = { table };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_genericQueryControlInstance, MethodDisposeTable, parametersOfDisposeTable, methodDisposeTablePrametersTypes);

            // Assert
            parametersOfDisposeTable.ShouldNotBeNull();
            parametersOfDisposeTable.Length.ShouldBe(1);
            methodDisposeTablePrametersTypes.Length.ShouldBe(1);
            methodDisposeTablePrametersTypes.Length.ShouldBe(parametersOfDisposeTable.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DisposeTable) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericQueryControl_DisposeTable_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDisposeTablePrametersTypes = new Type[] { typeof(Table) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericQueryControlInstance, MethodDisposeTable, Fixture, methodDisposeTablePrametersTypes);

            // Assert
            methodDisposeTablePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
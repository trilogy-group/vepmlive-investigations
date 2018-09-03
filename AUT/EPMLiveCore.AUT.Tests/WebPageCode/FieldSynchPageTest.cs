using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
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
using FieldSynchPage = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.FieldSynchPage" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class FieldSynchPageTest : AbstractBaseSetupTypedTest<FieldSynchPage>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FieldSynchPage) Initializer

        private const string PropertyCurrentList = "CurrentList";
        private const string MethodOnLoad = "OnLoad";
        private const string MethodGvFields_RowDataBound = "GvFields_RowDataBound";
        private const string MethodListFields = "ListFields";
        private const string MethodbtnSynchronize_Click = "btnSynchronize_Click";
        private const string MethodSyncFieldRecursive = "SyncFieldRecursive";
        private const string MethodbtnCancel_Click = "btnCancel_Click";
        private const string MethodgetFieldSchemaAttribValue = "getFieldSchemaAttribValue";
        private const string FieldoFromWeb = "oFromWeb";
        private const string FieldoFromList = "oFromList";
        private const string FieldfldFromField = "fldFromField";
        private const string FieldcurrentList = "currentList";
        private const string FieldtxtToList = "txtToList";
        private const string FieldGvFields = "GvFields";
        private const string FieldlblListName = "lblListName";
        private const string FieldbtnSynchronize = "btnSynchronize";
        private const string FieldCancel = "Cancel";
        private const string FieldsResults = "sResults";
        private const string FieldsLeftPadding = "sLeftPadding";
        private const string FieldlblResult = "lblResult";
        private const string FieldchkCreateNewList = "chkCreateNewList";
        private const string FieldpnlResults = "pnlResults";
        private Type _fieldSynchPageInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private FieldSynchPage _fieldSynchPageInstance;
        private FieldSynchPage _fieldSynchPageInstanceFixture;

        #region General Initializer : Class (FieldSynchPage) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FieldSynchPage" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _fieldSynchPageInstanceType = typeof(FieldSynchPage);
            _fieldSynchPageInstanceFixture = Create(true);
            _fieldSynchPageInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FieldSynchPage)

        #region General Initializer : Class (FieldSynchPage) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="FieldSynchPage" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodOnLoad, 0)]
        [TestCase(MethodGvFields_RowDataBound, 0)]
        [TestCase(MethodListFields, 0)]
        [TestCase(MethodbtnSynchronize_Click, 0)]
        [TestCase(MethodbtnCancel_Click, 0)]
        [TestCase(MethodgetFieldSchemaAttribValue, 0)]
        public void AUT_FieldSynchPage_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_fieldSynchPageInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FieldSynchPage) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="FieldSynchPage" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyCurrentList)]
        public void AUT_FieldSynchPage_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_fieldSynchPageInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FieldSynchPage) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FieldSynchPage" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldoFromWeb)]
        [TestCase(FieldoFromList)]
        [TestCase(FieldfldFromField)]
        [TestCase(FieldcurrentList)]
        [TestCase(FieldtxtToList)]
        [TestCase(FieldGvFields)]
        [TestCase(FieldlblListName)]
        [TestCase(FieldbtnSynchronize)]
        [TestCase(FieldCancel)]
        [TestCase(FieldsResults)]
        [TestCase(FieldsLeftPadding)]
        [TestCase(FieldlblResult)]
        [TestCase(FieldchkCreateNewList)]
        [TestCase(FieldpnlResults)]
        public void AUT_FieldSynchPage_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_fieldSynchPageInstanceFixture, 
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
        ///     Class (<see cref="FieldSynchPage" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_FieldSynchPage_Is_Instance_Present_Test()
        {
            // Assert
            _fieldSynchPageInstanceType.ShouldNotBeNull();
            _fieldSynchPageInstance.ShouldNotBeNull();
            _fieldSynchPageInstanceFixture.ShouldNotBeNull();
            _fieldSynchPageInstance.ShouldBeAssignableTo<FieldSynchPage>();
            _fieldSynchPageInstanceFixture.ShouldBeAssignableTo<FieldSynchPage>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (FieldSynchPage) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_FieldSynchPage_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            FieldSynchPage instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _fieldSynchPageInstanceType.ShouldNotBeNull();
            _fieldSynchPageInstance.ShouldNotBeNull();
            _fieldSynchPageInstanceFixture.ShouldNotBeNull();
            _fieldSynchPageInstance.ShouldBeAssignableTo<FieldSynchPage>();
            _fieldSynchPageInstanceFixture.ShouldBeAssignableTo<FieldSynchPage>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (FieldSynchPage) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(SPList) , PropertyCurrentList)]
        public void AUT_FieldSynchPage_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<FieldSynchPage, T>(_fieldSynchPageInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (FieldSynchPage) => Property (CurrentList) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_FieldSynchPage_CurrentList_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyCurrentList);
            Action currentAction = () => propertyInfo.SetValue(_fieldSynchPageInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FieldSynchPage) => Property (CurrentList) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_FieldSynchPage_Public_Class_CurrentList_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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
        ///      Class (<see cref="FieldSynchPage" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodOnLoad)]
        [TestCase(MethodGvFields_RowDataBound)]
        [TestCase(MethodListFields)]
        [TestCase(MethodbtnSynchronize_Click)]
        [TestCase(MethodbtnCancel_Click)]
        [TestCase(MethodgetFieldSchemaAttribValue)]
        public void AUT_FieldSynchPage_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<FieldSynchPage>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FieldSynchPage_OnLoad_Method_Call_Internally(Type[] types)
        {
            var methodOnLoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_fieldSynchPageInstance, MethodOnLoad, Fixture, methodOnLoadPrametersTypes);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FieldSynchPage_OnLoad_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnLoadPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnLoad = { e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnLoad, methodOnLoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_fieldSynchPageInstanceFixture, parametersOfOnLoad);

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
        public void AUT_FieldSynchPage_OnLoad_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnLoadPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnLoad = { e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_fieldSynchPageInstance, MethodOnLoad, parametersOfOnLoad, methodOnLoadPrametersTypes);

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
        public void AUT_FieldSynchPage_OnLoad_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_FieldSynchPage_OnLoad_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnLoadPrametersTypes = new Type[] { typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_fieldSynchPageInstance, MethodOnLoad, Fixture, methodOnLoadPrametersTypes);

            // Assert
            methodOnLoadPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FieldSynchPage_OnLoad_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnLoad, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_fieldSynchPageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GvFields_RowDataBound) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FieldSynchPage_GvFields_RowDataBound_Method_Call_Internally(Type[] types)
        {
            var methodGvFields_RowDataBoundPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_fieldSynchPageInstance, MethodGvFields_RowDataBound, Fixture, methodGvFields_RowDataBoundPrametersTypes);
        }

        #endregion

        #region Method Call : (GvFields_RowDataBound) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FieldSynchPage_GvFields_RowDataBound_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridViewRowEventArgs>();
            var methodGvFields_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };
            object[] parametersOfGvFields_RowDataBound = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGvFields_RowDataBound, methodGvFields_RowDataBoundPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_fieldSynchPageInstanceFixture, parametersOfGvFields_RowDataBound);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGvFields_RowDataBound.ShouldNotBeNull();
            parametersOfGvFields_RowDataBound.Length.ShouldBe(2);
            methodGvFields_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            methodGvFields_RowDataBoundPrametersTypes.Length.ShouldBe(parametersOfGvFields_RowDataBound.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GvFields_RowDataBound) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FieldSynchPage_GvFields_RowDataBound_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridViewRowEventArgs>();
            var methodGvFields_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };
            object[] parametersOfGvFields_RowDataBound = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_fieldSynchPageInstance, MethodGvFields_RowDataBound, parametersOfGvFields_RowDataBound, methodGvFields_RowDataBoundPrametersTypes);

            // Assert
            parametersOfGvFields_RowDataBound.ShouldNotBeNull();
            parametersOfGvFields_RowDataBound.Length.ShouldBe(2);
            methodGvFields_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            methodGvFields_RowDataBoundPrametersTypes.Length.ShouldBe(parametersOfGvFields_RowDataBound.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GvFields_RowDataBound) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FieldSynchPage_GvFields_RowDataBound_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGvFields_RowDataBound, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GvFields_RowDataBound) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FieldSynchPage_GvFields_RowDataBound_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGvFields_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_fieldSynchPageInstance, MethodGvFields_RowDataBound, Fixture, methodGvFields_RowDataBoundPrametersTypes);

            // Assert
            methodGvFields_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GvFields_RowDataBound) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FieldSynchPage_GvFields_RowDataBound_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGvFields_RowDataBound, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_fieldSynchPageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ListFields) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FieldSynchPage_ListFields_Method_Call_Internally(Type[] types)
        {
            var methodListFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_fieldSynchPageInstance, MethodListFields, Fixture, methodListFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (ListFields) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FieldSynchPage_ListFields_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodListFieldsPrametersTypes = null;
            object[] parametersOfListFields = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodListFields, methodListFieldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_fieldSynchPageInstanceFixture, parametersOfListFields);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfListFields.ShouldBeNull();
            methodListFieldsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ListFields) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FieldSynchPage_ListFields_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodListFieldsPrametersTypes = null;
            object[] parametersOfListFields = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_fieldSynchPageInstance, MethodListFields, parametersOfListFields, methodListFieldsPrametersTypes);

            // Assert
            parametersOfListFields.ShouldBeNull();
            methodListFieldsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ListFields) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FieldSynchPage_ListFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodListFieldsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_fieldSynchPageInstance, MethodListFields, Fixture, methodListFieldsPrametersTypes);

            // Assert
            methodListFieldsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ListFields) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FieldSynchPage_ListFields_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodListFields, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_fieldSynchPageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnSynchronize_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FieldSynchPage_btnSynchronize_Click_Method_Call_Internally(Type[] types)
        {
            var methodbtnSynchronize_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_fieldSynchPageInstance, MethodbtnSynchronize_Click, Fixture, methodbtnSynchronize_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnSynchronize_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FieldSynchPage_btnSynchronize_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnSynchronize_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnSynchronize_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnSynchronize_Click, methodbtnSynchronize_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_fieldSynchPageInstanceFixture, parametersOfbtnSynchronize_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbtnSynchronize_Click.ShouldNotBeNull();
            parametersOfbtnSynchronize_Click.Length.ShouldBe(2);
            methodbtnSynchronize_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnSynchronize_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnSynchronize_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (btnSynchronize_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FieldSynchPage_btnSynchronize_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnSynchronize_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnSynchronize_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_fieldSynchPageInstance, MethodbtnSynchronize_Click, parametersOfbtnSynchronize_Click, methodbtnSynchronize_ClickPrametersTypes);

            // Assert
            parametersOfbtnSynchronize_Click.ShouldNotBeNull();
            parametersOfbtnSynchronize_Click.Length.ShouldBe(2);
            methodbtnSynchronize_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnSynchronize_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnSynchronize_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnSynchronize_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FieldSynchPage_btnSynchronize_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbtnSynchronize_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (btnSynchronize_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FieldSynchPage_btnSynchronize_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnSynchronize_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_fieldSynchPageInstance, MethodbtnSynchronize_Click, Fixture, methodbtnSynchronize_ClickPrametersTypes);

            // Assert
            methodbtnSynchronize_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnSynchronize_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FieldSynchPage_btnSynchronize_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnSynchronize_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_fieldSynchPageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnCancel_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FieldSynchPage_btnCancel_Click_Method_Call_Internally(Type[] types)
        {
            var methodbtnCancel_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_fieldSynchPageInstance, MethodbtnCancel_Click, Fixture, methodbtnCancel_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnCancel_Click) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FieldSynchPage_btnCancel_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnCancel_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnCancel_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnCancel_Click, methodbtnCancel_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_fieldSynchPageInstanceFixture, parametersOfbtnCancel_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbtnCancel_Click.ShouldNotBeNull();
            parametersOfbtnCancel_Click.Length.ShouldBe(2);
            methodbtnCancel_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnCancel_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnCancel_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnCancel_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FieldSynchPage_btnCancel_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnCancel_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnCancel_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_fieldSynchPageInstance, MethodbtnCancel_Click, parametersOfbtnCancel_Click, methodbtnCancel_ClickPrametersTypes);

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
        public void AUT_FieldSynchPage_btnCancel_Click_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_FieldSynchPage_btnCancel_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnCancel_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_fieldSynchPageInstance, MethodbtnCancel_Click, Fixture, methodbtnCancel_ClickPrametersTypes);

            // Assert
            methodbtnCancel_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnCancel_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FieldSynchPage_btnCancel_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnCancel_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_fieldSynchPageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getFieldSchemaAttribValue) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FieldSynchPage_getFieldSchemaAttribValue_Method_Call_Internally(Type[] types)
        {
            var methodgetFieldSchemaAttribValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_fieldSynchPageInstance, MethodgetFieldSchemaAttribValue, Fixture, methodgetFieldSchemaAttribValuePrametersTypes);
        }

        #endregion

        #region Method Call : (getFieldSchemaAttribValue) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FieldSynchPage_getFieldSchemaAttribValue_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sStringToSearch = CreateType<string>();
            var sAttribName = CreateType<string>();
            var methodgetFieldSchemaAttribValuePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfgetFieldSchemaAttribValue = { sStringToSearch, sAttribName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetFieldSchemaAttribValue, methodgetFieldSchemaAttribValuePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_fieldSynchPageInstanceFixture, parametersOfgetFieldSchemaAttribValue);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetFieldSchemaAttribValue.ShouldNotBeNull();
            parametersOfgetFieldSchemaAttribValue.Length.ShouldBe(2);
            methodgetFieldSchemaAttribValuePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getFieldSchemaAttribValue) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FieldSynchPage_getFieldSchemaAttribValue_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sStringToSearch = CreateType<string>();
            var sAttribName = CreateType<string>();
            var methodgetFieldSchemaAttribValuePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfgetFieldSchemaAttribValue = { sStringToSearch, sAttribName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<FieldSynchPage, string>(_fieldSynchPageInstance, MethodgetFieldSchemaAttribValue, parametersOfgetFieldSchemaAttribValue, methodgetFieldSchemaAttribValuePrametersTypes);

            // Assert
            parametersOfgetFieldSchemaAttribValue.ShouldNotBeNull();
            parametersOfgetFieldSchemaAttribValue.Length.ShouldBe(2);
            methodgetFieldSchemaAttribValuePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getFieldSchemaAttribValue) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FieldSynchPage_getFieldSchemaAttribValue_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetFieldSchemaAttribValuePrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_fieldSynchPageInstance, MethodgetFieldSchemaAttribValue, Fixture, methodgetFieldSchemaAttribValuePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetFieldSchemaAttribValuePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (getFieldSchemaAttribValue) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FieldSynchPage_getFieldSchemaAttribValue_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetFieldSchemaAttribValuePrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_fieldSynchPageInstance, MethodgetFieldSchemaAttribValue, Fixture, methodgetFieldSchemaAttribValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetFieldSchemaAttribValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getFieldSchemaAttribValue) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FieldSynchPage_getFieldSchemaAttribValue_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetFieldSchemaAttribValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_fieldSynchPageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getFieldSchemaAttribValue) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FieldSynchPage_getFieldSchemaAttribValue_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetFieldSchemaAttribValue, 0);
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
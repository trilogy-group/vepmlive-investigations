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
using ListFieldIteratorExtensions = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.ListFieldIteratorExtensions" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ListFieldIteratorExtensionsTest : AbstractBaseSetupTest
    {

        public ListFieldIteratorExtensionsTest() : base(typeof(ListFieldIteratorExtensions))
        {}

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ListFieldIteratorExtensions) Initializer

        private const string MethodGetFormFieldByField = "GetFormFieldByField";
        private const string MethodGetFormFieldByType = "GetFormFieldByType";
        private const string MethodGetFormField = "GetFormField";
        private const string MethodGetFormFields = "GetFormFields";
        private const string MethodFindFieldFormControls = "FindFieldFormControls";
        private Type _listFieldIteratorExtensionsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;

        #region General Initializer : Class (ListFieldIteratorExtensions) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ListFieldIteratorExtensions" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _listFieldIteratorExtensionsInstanceType = typeof(ListFieldIteratorExtensions);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ListFieldIteratorExtensions)

        #region General Initializer : Class (ListFieldIteratorExtensions) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ListFieldIteratorExtensions" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetFormFieldByField, 0)]
        [TestCase(MethodGetFormFieldByType, 0)]
        [TestCase(MethodGetFormField, 0)]
        [TestCase(MethodGetFormField, 1)]
        [TestCase(MethodGetFormFields, 0)]
        [TestCase(MethodFindFieldFormControls, 0)]
        public void AUT_ListFieldIteratorExtensions_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(null, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="ListFieldIteratorExtensions" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ListFieldIteratorExtensions_Is_Static_Type_Present_Test()
        {
            // Assert
            _listFieldIteratorExtensionsInstanceType.ShouldNotBeNull();
        }

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="ListFieldIteratorExtensions" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetFormFieldByField)]
        [TestCase(MethodGetFormFieldByType)]
        [TestCase(MethodGetFormField)]
        [TestCase(MethodGetFormFields)]
        [TestCase(MethodFindFieldFormControls)]
        public void AUT_ListFieldIteratorExtensions_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(null,
                                                                              _listFieldIteratorExtensionsInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (GetFormFieldByField) (Return Type : FormField) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListFieldIteratorExtensions_GetFormFieldByField_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFormFieldByFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _listFieldIteratorExtensionsInstanceType, MethodGetFormFieldByField, Fixture, methodGetFormFieldByFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFormFieldByField) (Return Type : FormField) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListFieldIteratorExtensions_GetFormFieldByField_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var listFieldIterator = CreateType<ListFieldIterator>();
            var field = CreateType<SPField>();
            Action executeAction = null;

            // Act
            executeAction = () => ListFieldIteratorExtensions.GetFormFieldByField(listFieldIterator, field);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetFormFieldByField) (Return Type : FormField) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListFieldIteratorExtensions_GetFormFieldByField_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listFieldIterator = CreateType<ListFieldIterator>();
            var field = CreateType<SPField>();
            var methodGetFormFieldByFieldPrametersTypes = new Type[] { typeof(ListFieldIterator), typeof(SPField) };
            object[] parametersOfGetFormFieldByField = { listFieldIterator, field };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFormFieldByField, methodGetFormFieldByFieldPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _listFieldIteratorExtensionsInstanceType, MethodGetFormFieldByField, Fixture, methodGetFormFieldByFieldPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<FormField>(null, _listFieldIteratorExtensionsInstanceType, MethodGetFormFieldByField, parametersOfGetFormFieldByField, methodGetFormFieldByFieldPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetFormFieldByField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFormFieldByField.ShouldNotBeNull();
            parametersOfGetFormFieldByField.Length.ShouldBe(2);
            methodGetFormFieldByFieldPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetFormFieldByField) (Return Type : FormField) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListFieldIteratorExtensions_GetFormFieldByField_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listFieldIterator = CreateType<ListFieldIterator>();
            var field = CreateType<SPField>();
            var methodGetFormFieldByFieldPrametersTypes = new Type[] { typeof(ListFieldIterator), typeof(SPField) };
            object[] parametersOfGetFormFieldByField = { listFieldIterator, field };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<FormField>(null, _listFieldIteratorExtensionsInstanceType, MethodGetFormFieldByField, parametersOfGetFormFieldByField, methodGetFormFieldByFieldPrametersTypes);

            // Assert
            parametersOfGetFormFieldByField.ShouldNotBeNull();
            parametersOfGetFormFieldByField.Length.ShouldBe(2);
            methodGetFormFieldByFieldPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFormFieldByField) (Return Type : FormField) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListFieldIteratorExtensions_GetFormFieldByField_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFormFieldByFieldPrametersTypes = new Type[] { typeof(ListFieldIterator), typeof(SPField) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _listFieldIteratorExtensionsInstanceType, MethodGetFormFieldByField, Fixture, methodGetFormFieldByFieldPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFormFieldByFieldPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetFormFieldByField) (Return Type : FormField) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListFieldIteratorExtensions_GetFormFieldByField_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFormFieldByFieldPrametersTypes = new Type[] { typeof(ListFieldIterator), typeof(SPField) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _listFieldIteratorExtensionsInstanceType, MethodGetFormFieldByField, Fixture, methodGetFormFieldByFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFormFieldByFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFormFieldByField) (Return Type : FormField) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListFieldIteratorExtensions_GetFormFieldByField_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFormFieldByField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFormFieldByField) (Return Type : FormField) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListFieldIteratorExtensions_GetFormFieldByField_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFormFieldByField, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFormFieldByType) (Return Type : List<FormField>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListFieldIteratorExtensions_GetFormFieldByType_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFormFieldByTypePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _listFieldIteratorExtensionsInstanceType, MethodGetFormFieldByType, Fixture, methodGetFormFieldByTypePrametersTypes);
        }

        #endregion

        #region Method Call : (GetFormFieldByType) (Return Type : List<FormField>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListFieldIteratorExtensions_GetFormFieldByType_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var listFieldIterator = CreateType<ListFieldIterator>();
            var fieldType = CreateType<Type>();
            Action executeAction = null;

            // Act
            executeAction = () => ListFieldIteratorExtensions.GetFormFieldByType(listFieldIterator, fieldType);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetFormFieldByType) (Return Type : List<FormField>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListFieldIteratorExtensions_GetFormFieldByType_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listFieldIterator = CreateType<ListFieldIterator>();
            var fieldType = CreateType<Type>();
            var methodGetFormFieldByTypePrametersTypes = new Type[] { typeof(ListFieldIterator), typeof(Type) };
            object[] parametersOfGetFormFieldByType = { listFieldIterator, fieldType };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFormFieldByType, methodGetFormFieldByTypePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _listFieldIteratorExtensionsInstanceType, MethodGetFormFieldByType, Fixture, methodGetFormFieldByTypePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<List<FormField>>(null, _listFieldIteratorExtensionsInstanceType, MethodGetFormFieldByType, parametersOfGetFormFieldByType, methodGetFormFieldByTypePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetFormFieldByType);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFormFieldByType.ShouldNotBeNull();
            parametersOfGetFormFieldByType.Length.ShouldBe(2);
            methodGetFormFieldByTypePrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetFormFieldByType) (Return Type : List<FormField>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListFieldIteratorExtensions_GetFormFieldByType_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listFieldIterator = CreateType<ListFieldIterator>();
            var fieldType = CreateType<Type>();
            var methodGetFormFieldByTypePrametersTypes = new Type[] { typeof(ListFieldIterator), typeof(Type) };
            object[] parametersOfGetFormFieldByType = { listFieldIterator, fieldType };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<List<FormField>>(null, _listFieldIteratorExtensionsInstanceType, MethodGetFormFieldByType, parametersOfGetFormFieldByType, methodGetFormFieldByTypePrametersTypes);

            // Assert
            parametersOfGetFormFieldByType.ShouldNotBeNull();
            parametersOfGetFormFieldByType.Length.ShouldBe(2);
            methodGetFormFieldByTypePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFormFieldByType) (Return Type : List<FormField>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListFieldIteratorExtensions_GetFormFieldByType_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFormFieldByTypePrametersTypes = new Type[] { typeof(ListFieldIterator), typeof(Type) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _listFieldIteratorExtensionsInstanceType, MethodGetFormFieldByType, Fixture, methodGetFormFieldByTypePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFormFieldByTypePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetFormFieldByType) (Return Type : List<FormField>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListFieldIteratorExtensions_GetFormFieldByType_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFormFieldByTypePrametersTypes = new Type[] { typeof(ListFieldIterator), typeof(Type) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _listFieldIteratorExtensionsInstanceType, MethodGetFormFieldByType, Fixture, methodGetFormFieldByTypePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFormFieldByTypePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFormFieldByType) (Return Type : List<FormField>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListFieldIteratorExtensions_GetFormFieldByType_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFormFieldByType, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFormFieldByType) (Return Type : List<FormField>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListFieldIteratorExtensions_GetFormFieldByType_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFormFieldByType, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFormField) (Return Type : List<FormField>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListFieldIteratorExtensions_GetFormField_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFormFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _listFieldIteratorExtensionsInstanceType, MethodGetFormField, Fixture, methodGetFormFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFormField) (Return Type : List<FormField>) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListFieldIteratorExtensions_GetFormField_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var listFieldITerator = CreateType<ListFieldIterator>();
            var formFields = CreateType<List<FormField>>();
            var fieldType = CreateType<Type>();
            Action executeAction = null;

            // Act
            executeAction = () => ListFieldIteratorExtensions.GetFormField(listFieldITerator, formFields, fieldType);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetFormField) (Return Type : List<FormField>) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListFieldIteratorExtensions_GetFormField_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var listFieldITerator = CreateType<ListFieldIterator>();
            var formFields = CreateType<List<FormField>>();
            var fieldType = CreateType<Type>();
            var methodGetFormFieldPrametersTypes = new Type[] { typeof(ListFieldIterator), typeof(List<FormField>), typeof(Type) };
            object[] parametersOfGetFormField = { listFieldITerator, formFields, fieldType };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetFormField, methodGetFormFieldPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetFormField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetFormField.ShouldNotBeNull();
            parametersOfGetFormField.Length.ShouldBe(3);
            methodGetFormFieldPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFormField) (Return Type : List<FormField>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListFieldIteratorExtensions_GetFormField_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listFieldITerator = CreateType<ListFieldIterator>();
            var formFields = CreateType<List<FormField>>();
            var fieldType = CreateType<Type>();
            var methodGetFormFieldPrametersTypes = new Type[] { typeof(ListFieldIterator), typeof(List<FormField>), typeof(Type) };
            object[] parametersOfGetFormField = { listFieldITerator, formFields, fieldType };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<List<FormField>>(null, _listFieldIteratorExtensionsInstanceType, MethodGetFormField, parametersOfGetFormField, methodGetFormFieldPrametersTypes);

            // Assert
            parametersOfGetFormField.ShouldNotBeNull();
            parametersOfGetFormField.Length.ShouldBe(3);
            methodGetFormFieldPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFormField) (Return Type : List<FormField>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListFieldIteratorExtensions_GetFormField_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFormFieldPrametersTypes = new Type[] { typeof(ListFieldIterator), typeof(List<FormField>), typeof(Type) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _listFieldIteratorExtensionsInstanceType, MethodGetFormField, Fixture, methodGetFormFieldPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFormFieldPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetFormField) (Return Type : List<FormField>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListFieldIteratorExtensions_GetFormField_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFormFieldPrametersTypes = new Type[] { typeof(ListFieldIterator), typeof(List<FormField>), typeof(Type) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _listFieldIteratorExtensionsInstanceType, MethodGetFormField, Fixture, methodGetFormFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFormFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFormField) (Return Type : List<FormField>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListFieldIteratorExtensions_GetFormField_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFormField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFormField) (Return Type : List<FormField>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListFieldIteratorExtensions_GetFormField_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFormField, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFormField) (Return Type : FormField) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListFieldIteratorExtensions_GetFormField_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodGetFormFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _listFieldIteratorExtensionsInstanceType, MethodGetFormField, Fixture, methodGetFormFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFormField) (Return Type : FormField) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListFieldIteratorExtensions_GetFormField_Static_Method_DirectCall_Overloading_Of_1_No_Exception_Thrown_Test()
        {
            // Arrange
            var listFieldITerator = CreateType<ListFieldIterator>();
            var formFields = CreateType<List<FormField>>();
            var field = CreateType<SPField>();
            Action executeAction = null;

            // Act
            executeAction = () => ListFieldIteratorExtensions.GetFormField(listFieldITerator, formFields, field);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetFormField) (Return Type : FormField) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListFieldIteratorExtensions_GetFormField_Static_Method_Call_Overloading_Of_1_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var listFieldITerator = CreateType<ListFieldIterator>();
            var formFields = CreateType<List<FormField>>();
            var field = CreateType<SPField>();
            var methodGetFormFieldPrametersTypes = new Type[] { typeof(ListFieldIterator), typeof(List<FormField>), typeof(SPField) };
            object[] parametersOfGetFormField = { listFieldITerator, formFields, field };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetFormField, methodGetFormFieldPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetFormField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetFormField.ShouldNotBeNull();
            parametersOfGetFormField.Length.ShouldBe(3);
            methodGetFormFieldPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFormField) (Return Type : FormField) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListFieldIteratorExtensions_GetFormField_Static_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listFieldITerator = CreateType<ListFieldIterator>();
            var formFields = CreateType<List<FormField>>();
            var field = CreateType<SPField>();
            var methodGetFormFieldPrametersTypes = new Type[] { typeof(ListFieldIterator), typeof(List<FormField>), typeof(SPField) };
            object[] parametersOfGetFormField = { listFieldITerator, formFields, field };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<FormField>(null, _listFieldIteratorExtensionsInstanceType, MethodGetFormField, parametersOfGetFormField, methodGetFormFieldPrametersTypes);

            // Assert
            parametersOfGetFormField.ShouldNotBeNull();
            parametersOfGetFormField.Length.ShouldBe(3);
            methodGetFormFieldPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFormField) (Return Type : FormField) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListFieldIteratorExtensions_GetFormField_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFormFieldPrametersTypes = new Type[] { typeof(ListFieldIterator), typeof(List<FormField>), typeof(SPField) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _listFieldIteratorExtensionsInstanceType, MethodGetFormField, Fixture, methodGetFormFieldPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFormFieldPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetFormField) (Return Type : FormField) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListFieldIteratorExtensions_GetFormField_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFormFieldPrametersTypes = new Type[] { typeof(ListFieldIterator), typeof(List<FormField>), typeof(SPField) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _listFieldIteratorExtensionsInstanceType, MethodGetFormField, Fixture, methodGetFormFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFormFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFormField) (Return Type : FormField) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListFieldIteratorExtensions_GetFormField_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFormField, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFormField) (Return Type : FormField) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListFieldIteratorExtensions_GetFormField_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFormField, 1);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFormFields) (Return Type : List<FormField>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListFieldIteratorExtensions_GetFormFields_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFormFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _listFieldIteratorExtensionsInstanceType, MethodGetFormFields, Fixture, methodGetFormFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFormFields) (Return Type : List<FormField>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListFieldIteratorExtensions_GetFormFields_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var listFieldIterator = CreateType<ListFieldIterator>();
            Action executeAction = null;

            // Act
            executeAction = () => ListFieldIteratorExtensions.GetFormFields(listFieldIterator);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetFormFields) (Return Type : List<FormField>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListFieldIteratorExtensions_GetFormFields_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listFieldIterator = CreateType<ListFieldIterator>();
            var methodGetFormFieldsPrametersTypes = new Type[] { typeof(ListFieldIterator) };
            object[] parametersOfGetFormFields = { listFieldIterator };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFormFields, methodGetFormFieldsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _listFieldIteratorExtensionsInstanceType, MethodGetFormFields, Fixture, methodGetFormFieldsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<List<FormField>>(null, _listFieldIteratorExtensionsInstanceType, MethodGetFormFields, parametersOfGetFormFields, methodGetFormFieldsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetFormFields);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFormFields.ShouldNotBeNull();
            parametersOfGetFormFields.Length.ShouldBe(1);
            methodGetFormFieldsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetFormFields) (Return Type : List<FormField>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListFieldIteratorExtensions_GetFormFields_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listFieldIterator = CreateType<ListFieldIterator>();
            var methodGetFormFieldsPrametersTypes = new Type[] { typeof(ListFieldIterator) };
            object[] parametersOfGetFormFields = { listFieldIterator };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<List<FormField>>(null, _listFieldIteratorExtensionsInstanceType, MethodGetFormFields, parametersOfGetFormFields, methodGetFormFieldsPrametersTypes);

            // Assert
            parametersOfGetFormFields.ShouldNotBeNull();
            parametersOfGetFormFields.Length.ShouldBe(1);
            methodGetFormFieldsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFormFields) (Return Type : List<FormField>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListFieldIteratorExtensions_GetFormFields_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFormFieldsPrametersTypes = new Type[] { typeof(ListFieldIterator) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _listFieldIteratorExtensionsInstanceType, MethodGetFormFields, Fixture, methodGetFormFieldsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFormFieldsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFormFields) (Return Type : List<FormField>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListFieldIteratorExtensions_GetFormFields_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFormFieldsPrametersTypes = new Type[] { typeof(ListFieldIterator) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _listFieldIteratorExtensionsInstanceType, MethodGetFormFields, Fixture, methodGetFormFieldsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFormFieldsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFormFields) (Return Type : List<FormField>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListFieldIteratorExtensions_GetFormFields_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFormFields, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFormFields) (Return Type : List<FormField>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListFieldIteratorExtensions_GetFormFields_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFormFields, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FindFieldFormControls) (Return Type : List<FormField>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListFieldIteratorExtensions_FindFieldFormControls_Static_Method_Call_Internally(Type[] types)
        {
            var methodFindFieldFormControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _listFieldIteratorExtensionsInstanceType, MethodFindFieldFormControls, Fixture, methodFindFieldFormControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (FindFieldFormControls) (Return Type : List<FormField>) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListFieldIteratorExtensions_FindFieldFormControls_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var root = CreateType<System.Web.UI.Control>();
            var methodFindFieldFormControlsPrametersTypes = new Type[] { typeof(System.Web.UI.Control) };
            object[] parametersOfFindFieldFormControls = { root };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodFindFieldFormControls, methodFindFieldFormControlsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfFindFieldFormControls);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfFindFieldFormControls.ShouldNotBeNull();
            parametersOfFindFieldFormControls.Length.ShouldBe(1);
            methodFindFieldFormControlsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FindFieldFormControls) (Return Type : List<FormField>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListFieldIteratorExtensions_FindFieldFormControls_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var root = CreateType<System.Web.UI.Control>();
            var methodFindFieldFormControlsPrametersTypes = new Type[] { typeof(System.Web.UI.Control) };
            object[] parametersOfFindFieldFormControls = { root };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<List<FormField>>(null, _listFieldIteratorExtensionsInstanceType, MethodFindFieldFormControls, parametersOfFindFieldFormControls, methodFindFieldFormControlsPrametersTypes);

            // Assert
            parametersOfFindFieldFormControls.ShouldNotBeNull();
            parametersOfFindFieldFormControls.Length.ShouldBe(1);
            methodFindFieldFormControlsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FindFieldFormControls) (Return Type : List<FormField>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListFieldIteratorExtensions_FindFieldFormControls_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodFindFieldFormControlsPrametersTypes = new Type[] { typeof(System.Web.UI.Control) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _listFieldIteratorExtensionsInstanceType, MethodFindFieldFormControls, Fixture, methodFindFieldFormControlsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodFindFieldFormControlsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (FindFieldFormControls) (Return Type : List<FormField>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListFieldIteratorExtensions_FindFieldFormControls_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFindFieldFormControlsPrametersTypes = new Type[] { typeof(System.Web.UI.Control) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _listFieldIteratorExtensionsInstanceType, MethodFindFieldFormControls, Fixture, methodFindFieldFormControlsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodFindFieldFormControlsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FindFieldFormControls) (Return Type : List<FormField>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListFieldIteratorExtensions_FindFieldFormControls_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFindFieldFormControls, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (FindFieldFormControls) (Return Type : List<FormField>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListFieldIteratorExtensions_FindFieldFormControls_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodFindFieldFormControls, 0);
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
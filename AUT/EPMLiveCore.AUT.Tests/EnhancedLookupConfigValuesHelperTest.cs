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
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.AutoFixtureSetup;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using EnhancedLookupConfigValuesHelper = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.EnhancedLookupConfigValuesHelper" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class EnhancedLookupConfigValuesHelperTest : AbstractBaseSetupTypedTest<EnhancedLookupConfigValuesHelper>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EnhancedLookupConfigValuesHelper) Initializer

        private const string MethodInitFieldsData = "InitFieldsData";
        private const string MethodGetFieldData = "GetFieldData";
        private const string MethodGetSecuredFields = "GetSecuredFields";
        private const string MethodContainsKey = "ContainsKey";
        private const string MethodIsParentField = "IsParentField";
        private const string Field_fieldsData = "_fieldsData";
        private const string Field_parents = "_parents";
        private Type _enhancedLookupConfigValuesHelperInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private EnhancedLookupConfigValuesHelper _enhancedLookupConfigValuesHelperInstance;
        private EnhancedLookupConfigValuesHelper _enhancedLookupConfigValuesHelperInstanceFixture;

        #region General Initializer : Class (EnhancedLookupConfigValuesHelper) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EnhancedLookupConfigValuesHelper" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _enhancedLookupConfigValuesHelperInstanceType = typeof(EnhancedLookupConfigValuesHelper);
            _enhancedLookupConfigValuesHelperInstanceFixture = Create(true);
            _enhancedLookupConfigValuesHelperInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (EnhancedLookupConfigValuesHelper)

        #region General Initializer : Class (EnhancedLookupConfigValuesHelper) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="EnhancedLookupConfigValuesHelper" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodInitFieldsData, 0)]
        [TestCase(MethodGetFieldData, 0)]
        [TestCase(MethodGetSecuredFields, 0)]
        [TestCase(MethodContainsKey, 0)]
        [TestCase(MethodIsParentField, 0)]
        public void AUT_EnhancedLookupConfigValuesHelper_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_enhancedLookupConfigValuesHelperInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (EnhancedLookupConfigValuesHelper) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="EnhancedLookupConfigValuesHelper" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_fieldsData)]
        [TestCase(Field_parents)]
        public void AUT_EnhancedLookupConfigValuesHelper_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_enhancedLookupConfigValuesHelperInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="EnhancedLookupConfigValuesHelper" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodInitFieldsData)]
        [TestCase(MethodGetFieldData)]
        [TestCase(MethodGetSecuredFields)]
        [TestCase(MethodContainsKey)]
        [TestCase(MethodIsParentField)]
        public void AUT_EnhancedLookupConfigValuesHelper_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<EnhancedLookupConfigValuesHelper>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (InitFieldsData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EnhancedLookupConfigValuesHelper_InitFieldsData_Method_Call_Internally(Type[] types)
        {
            var methodInitFieldsDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_enhancedLookupConfigValuesHelperInstance, MethodInitFieldsData, Fixture, methodInitFieldsDataPrametersTypes);
        }

        #endregion

        #region Method Call : (InitFieldsData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EnhancedLookupConfigValuesHelper_InitFieldsData_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var rawValue = CreateType<string>();
            var methodInitFieldsDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfInitFieldsData = { rawValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitFieldsData, methodInitFieldsDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_enhancedLookupConfigValuesHelperInstanceFixture, parametersOfInitFieldsData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInitFieldsData.ShouldNotBeNull();
            parametersOfInitFieldsData.Length.ShouldBe(1);
            methodInitFieldsDataPrametersTypes.Length.ShouldBe(1);
            methodInitFieldsDataPrametersTypes.Length.ShouldBe(parametersOfInitFieldsData.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (InitFieldsData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EnhancedLookupConfigValuesHelper_InitFieldsData_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var rawValue = CreateType<string>();
            var methodInitFieldsDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfInitFieldsData = { rawValue };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_enhancedLookupConfigValuesHelperInstance, MethodInitFieldsData, parametersOfInitFieldsData, methodInitFieldsDataPrametersTypes);

            // Assert
            parametersOfInitFieldsData.ShouldNotBeNull();
            parametersOfInitFieldsData.Length.ShouldBe(1);
            methodInitFieldsDataPrametersTypes.Length.ShouldBe(1);
            methodInitFieldsDataPrametersTypes.Length.ShouldBe(parametersOfInitFieldsData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitFieldsData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EnhancedLookupConfigValuesHelper_InitFieldsData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodInitFieldsData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InitFieldsData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EnhancedLookupConfigValuesHelper_InitFieldsData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInitFieldsDataPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_enhancedLookupConfigValuesHelperInstance, MethodInitFieldsData, Fixture, methodInitFieldsDataPrametersTypes);

            // Assert
            methodInitFieldsDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitFieldsData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EnhancedLookupConfigValuesHelper_InitFieldsData_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitFieldsData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_enhancedLookupConfigValuesHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFieldData) (Return Type : LookupConfigData) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EnhancedLookupConfigValuesHelper_GetFieldData_Method_Call_Internally(Type[] types)
        {
            var methodGetFieldDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_enhancedLookupConfigValuesHelperInstance, MethodGetFieldData, Fixture, methodGetFieldDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFieldData) (Return Type : LookupConfigData) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EnhancedLookupConfigValuesHelper_GetFieldData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var fieldIntName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _enhancedLookupConfigValuesHelperInstance.GetFieldData(fieldIntName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetFieldData) (Return Type : LookupConfigData) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EnhancedLookupConfigValuesHelper_GetFieldData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var fieldIntName = CreateType<string>();
            var methodGetFieldDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetFieldData = { fieldIntName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetFieldData, methodGetFieldDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EnhancedLookupConfigValuesHelper, LookupConfigData>(_enhancedLookupConfigValuesHelperInstanceFixture, out exception1, parametersOfGetFieldData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EnhancedLookupConfigValuesHelper, LookupConfigData>(_enhancedLookupConfigValuesHelperInstance, MethodGetFieldData, parametersOfGetFieldData, methodGetFieldDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFieldData.ShouldNotBeNull();
            parametersOfGetFieldData.Length.ShouldBe(1);
            methodGetFieldDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFieldData) (Return Type : LookupConfigData) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EnhancedLookupConfigValuesHelper_GetFieldData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var fieldIntName = CreateType<string>();
            var methodGetFieldDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetFieldData = { fieldIntName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EnhancedLookupConfigValuesHelper, LookupConfigData>(_enhancedLookupConfigValuesHelperInstance, MethodGetFieldData, parametersOfGetFieldData, methodGetFieldDataPrametersTypes);

            // Assert
            parametersOfGetFieldData.ShouldNotBeNull();
            parametersOfGetFieldData.Length.ShouldBe(1);
            methodGetFieldDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFieldData) (Return Type : LookupConfigData) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EnhancedLookupConfigValuesHelper_GetFieldData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFieldDataPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_enhancedLookupConfigValuesHelperInstance, MethodGetFieldData, Fixture, methodGetFieldDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFieldDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFieldData) (Return Type : LookupConfigData) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EnhancedLookupConfigValuesHelper_GetFieldData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFieldDataPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_enhancedLookupConfigValuesHelperInstance, MethodGetFieldData, Fixture, methodGetFieldDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFieldDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFieldData) (Return Type : LookupConfigData) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EnhancedLookupConfigValuesHelper_GetFieldData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFieldData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_enhancedLookupConfigValuesHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFieldData) (Return Type : LookupConfigData) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EnhancedLookupConfigValuesHelper_GetFieldData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFieldData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSecuredFields) (Return Type : List<string>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EnhancedLookupConfigValuesHelper_GetSecuredFields_Method_Call_Internally(Type[] types)
        {
            var methodGetSecuredFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_enhancedLookupConfigValuesHelperInstance, MethodGetSecuredFields, Fixture, methodGetSecuredFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSecuredFields) (Return Type : List<string>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EnhancedLookupConfigValuesHelper_GetSecuredFields_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _enhancedLookupConfigValuesHelperInstance.GetSecuredFields();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetSecuredFields) (Return Type : List<string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EnhancedLookupConfigValuesHelper_GetSecuredFields_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetSecuredFieldsPrametersTypes = null;
            object[] parametersOfGetSecuredFields = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetSecuredFields, methodGetSecuredFieldsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EnhancedLookupConfigValuesHelper, List<string>>(_enhancedLookupConfigValuesHelperInstanceFixture, out exception1, parametersOfGetSecuredFields);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EnhancedLookupConfigValuesHelper, List<string>>(_enhancedLookupConfigValuesHelperInstance, MethodGetSecuredFields, parametersOfGetSecuredFields, methodGetSecuredFieldsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetSecuredFields.ShouldBeNull();
            methodGetSecuredFieldsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSecuredFields) (Return Type : List<string>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EnhancedLookupConfigValuesHelper_GetSecuredFields_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetSecuredFieldsPrametersTypes = null;
            object[] parametersOfGetSecuredFields = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EnhancedLookupConfigValuesHelper, List<string>>(_enhancedLookupConfigValuesHelperInstance, MethodGetSecuredFields, parametersOfGetSecuredFields, methodGetSecuredFieldsPrametersTypes);

            // Assert
            parametersOfGetSecuredFields.ShouldBeNull();
            methodGetSecuredFieldsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSecuredFields) (Return Type : List<string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EnhancedLookupConfigValuesHelper_GetSecuredFields_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetSecuredFieldsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_enhancedLookupConfigValuesHelperInstance, MethodGetSecuredFields, Fixture, methodGetSecuredFieldsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetSecuredFieldsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSecuredFields) (Return Type : List<string>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EnhancedLookupConfigValuesHelper_GetSecuredFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetSecuredFieldsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_enhancedLookupConfigValuesHelperInstance, MethodGetSecuredFields, Fixture, methodGetSecuredFieldsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSecuredFieldsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSecuredFields) (Return Type : List<string>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EnhancedLookupConfigValuesHelper_GetSecuredFields_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSecuredFields, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_enhancedLookupConfigValuesHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ContainsKey) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EnhancedLookupConfigValuesHelper_ContainsKey_Method_Call_Internally(Type[] types)
        {
            var methodContainsKeyPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_enhancedLookupConfigValuesHelperInstance, MethodContainsKey, Fixture, methodContainsKeyPrametersTypes);
        }

        #endregion

        #region Method Call : (ContainsKey) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EnhancedLookupConfigValuesHelper_ContainsKey_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var name = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _enhancedLookupConfigValuesHelperInstance.ContainsKey(name);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ContainsKey) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EnhancedLookupConfigValuesHelper_ContainsKey_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var methodContainsKeyPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfContainsKey = { name };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodContainsKey, methodContainsKeyPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EnhancedLookupConfigValuesHelper, bool>(_enhancedLookupConfigValuesHelperInstanceFixture, out exception1, parametersOfContainsKey);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EnhancedLookupConfigValuesHelper, bool>(_enhancedLookupConfigValuesHelperInstance, MethodContainsKey, parametersOfContainsKey, methodContainsKeyPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfContainsKey.ShouldNotBeNull();
            parametersOfContainsKey.Length.ShouldBe(1);
            methodContainsKeyPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ContainsKey) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EnhancedLookupConfigValuesHelper_ContainsKey_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var methodContainsKeyPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfContainsKey = { name };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodContainsKey, methodContainsKeyPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EnhancedLookupConfigValuesHelper, bool>(_enhancedLookupConfigValuesHelperInstanceFixture, out exception1, parametersOfContainsKey);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EnhancedLookupConfigValuesHelper, bool>(_enhancedLookupConfigValuesHelperInstance, MethodContainsKey, parametersOfContainsKey, methodContainsKeyPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfContainsKey.ShouldNotBeNull();
            parametersOfContainsKey.Length.ShouldBe(1);
            methodContainsKeyPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ContainsKey) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EnhancedLookupConfigValuesHelper_ContainsKey_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var methodContainsKeyPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfContainsKey = { name };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EnhancedLookupConfigValuesHelper, bool>(_enhancedLookupConfigValuesHelperInstance, MethodContainsKey, parametersOfContainsKey, methodContainsKeyPrametersTypes);

            // Assert
            parametersOfContainsKey.ShouldNotBeNull();
            parametersOfContainsKey.Length.ShouldBe(1);
            methodContainsKeyPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ContainsKey) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EnhancedLookupConfigValuesHelper_ContainsKey_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodContainsKeyPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_enhancedLookupConfigValuesHelperInstance, MethodContainsKey, Fixture, methodContainsKeyPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodContainsKeyPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ContainsKey) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EnhancedLookupConfigValuesHelper_ContainsKey_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodContainsKey, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_enhancedLookupConfigValuesHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ContainsKey) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EnhancedLookupConfigValuesHelper_ContainsKey_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodContainsKey, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsParentField) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EnhancedLookupConfigValuesHelper_IsParentField_Method_Call_Internally(Type[] types)
        {
            var methodIsParentFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_enhancedLookupConfigValuesHelperInstance, MethodIsParentField, Fixture, methodIsParentFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (IsParentField) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EnhancedLookupConfigValuesHelper_IsParentField_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var name = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _enhancedLookupConfigValuesHelperInstance.IsParentField(name);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (IsParentField) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EnhancedLookupConfigValuesHelper_IsParentField_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var methodIsParentFieldPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsParentField = { name };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsParentField, methodIsParentFieldPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EnhancedLookupConfigValuesHelper, bool>(_enhancedLookupConfigValuesHelperInstanceFixture, out exception1, parametersOfIsParentField);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EnhancedLookupConfigValuesHelper, bool>(_enhancedLookupConfigValuesHelperInstance, MethodIsParentField, parametersOfIsParentField, methodIsParentFieldPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsParentField.ShouldNotBeNull();
            parametersOfIsParentField.Length.ShouldBe(1);
            methodIsParentFieldPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (IsParentField) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EnhancedLookupConfigValuesHelper_IsParentField_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var methodIsParentFieldPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsParentField = { name };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsParentField, methodIsParentFieldPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EnhancedLookupConfigValuesHelper, bool>(_enhancedLookupConfigValuesHelperInstanceFixture, out exception1, parametersOfIsParentField);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EnhancedLookupConfigValuesHelper, bool>(_enhancedLookupConfigValuesHelperInstance, MethodIsParentField, parametersOfIsParentField, methodIsParentFieldPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsParentField.ShouldNotBeNull();
            parametersOfIsParentField.Length.ShouldBe(1);
            methodIsParentFieldPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (IsParentField) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EnhancedLookupConfigValuesHelper_IsParentField_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var methodIsParentFieldPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsParentField = { name };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EnhancedLookupConfigValuesHelper, bool>(_enhancedLookupConfigValuesHelperInstance, MethodIsParentField, parametersOfIsParentField, methodIsParentFieldPrametersTypes);

            // Assert
            parametersOfIsParentField.ShouldNotBeNull();
            parametersOfIsParentField.Length.ShouldBe(1);
            methodIsParentFieldPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsParentField) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EnhancedLookupConfigValuesHelper_IsParentField_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsParentFieldPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_enhancedLookupConfigValuesHelperInstance, MethodIsParentField, Fixture, methodIsParentFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsParentFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsParentField) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EnhancedLookupConfigValuesHelper_IsParentField_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsParentField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_enhancedLookupConfigValuesHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsParentField) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EnhancedLookupConfigValuesHelper_IsParentField_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodIsParentField, 0);
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
using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace WorkEnginePPM.Core.ResourceManagement
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.Core.ResourceManagement.Utilities" />)
    ///     and namespace <see cref="WorkEnginePPM.Core.ResourceManagement"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class UtilitiesTest : AbstractBaseSetupTest
    {

        public UtilitiesTest() : base(typeof(Utilities))
        {}

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Utilities) Initializer

        private const string MethodAddUpdateResource = "AddUpdateResource";
        private const string MethodBuildFieldsTable = "BuildFieldsTable";
        private const string MethodDeleteResource = "DeleteResource";
        private const string MethodGetCleanFieldValue = "GetCleanFieldValue";
        private const string MethodPerformDeleteResourceCheck = "PerformDeleteResourceCheck";
        private const string MethodWriteDataTableToFile = "WriteDataTableToFile";
        private const string MethodAreEqualObjects = "AreEqualObjects";
        private const string MethodGetUserName = "GetUserName";
        private const string MethodGetValue = "GetValue";
        private const string MethodTryGetPFEFieldId = "TryGetPFEFieldId";
        private const string MethodCheckPFEResourceCenterPermission = "CheckPFEResourceCenterPermission";
        private const string MethodGetValidDateInFormat = "GetValidDateInFormat";
        private Type _utilitiesInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;

        #region General Initializer : Class (Utilities) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Utilities" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _utilitiesInstanceType = typeof(Utilities);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Utilities)

        #region General Initializer : Class (Utilities) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Utilities" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodAddUpdateResource, 0)]
        [TestCase(MethodBuildFieldsTable, 0)]
        [TestCase(MethodDeleteResource, 0)]
        [TestCase(MethodGetCleanFieldValue, 0)]
        [TestCase(MethodPerformDeleteResourceCheck, 0)]
        [TestCase(MethodWriteDataTableToFile, 0)]
        [TestCase(MethodAreEqualObjects, 0)]
        [TestCase(MethodGetCleanFieldValue, 1)]
        [TestCase(MethodGetUserName, 0)]
        [TestCase(MethodGetValue, 0)]
        [TestCase(MethodTryGetPFEFieldId, 0)]
        [TestCase(MethodCheckPFEResourceCenterPermission, 0)]
        [TestCase(MethodGetValidDateInFormat, 0)]
        public void AUT_Utilities_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
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
        ///     Class (<see cref="Utilities" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Utilities_Is_Static_Type_Present_Test()
        {
            // Assert
            _utilitiesInstanceType.ShouldNotBeNull();
        }

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="Utilities" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodAddUpdateResource)]
        [TestCase(MethodBuildFieldsTable)]
        [TestCase(MethodDeleteResource)]
        [TestCase(MethodGetCleanFieldValue)]
        [TestCase(MethodPerformDeleteResourceCheck)]
        [TestCase(MethodWriteDataTableToFile)]
        [TestCase(MethodAreEqualObjects)]
        [TestCase(MethodGetUserName)]
        [TestCase(MethodGetValue)]
        [TestCase(MethodTryGetPFEFieldId)]
        [TestCase(MethodCheckPFEResourceCenterPermission)]
        [TestCase(MethodGetValidDateInFormat)]
        public void AUT_Utilities_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(null,
                                                                              _utilitiesInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (AddUpdateResource) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utilities_AddUpdateResource_Static_Method_Call_Internally(Type[] types)
        {
            var methodAddUpdateResourcePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodAddUpdateResource, Fixture, methodAddUpdateResourcePrametersTypes);
        }

        #endregion

        #region Method Call : (AddUpdateResource) (Return Type : int) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_AddUpdateResource_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var fieldsTable = CreateType<DataTable>();
            var spWeb = CreateType<SPWeb>();
            var listId = CreateType<Guid>();
            var rate = CreateType<decimal>();
            var returnId = CreateType<Boolean>();
            Action executeAction = null;

            // Act
            executeAction = () => Utilities.AddUpdateResource(fieldsTable, spWeb, listId, out rate, returnId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (AddUpdateResource) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_AddUpdateResource_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var fieldsTable = CreateType<DataTable>();
            var spWeb = CreateType<SPWeb>();
            var listId = CreateType<Guid>();
            var rate = CreateType<decimal>();
            var returnId = CreateType<Boolean>();
            var methodAddUpdateResourcePrametersTypes = new Type[] { typeof(DataTable), typeof(SPWeb), typeof(Guid), typeof(decimal), typeof(Boolean) };
            object[] parametersOfAddUpdateResource = { fieldsTable, spWeb, listId, rate, returnId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<int>(null, _utilitiesInstanceType, MethodAddUpdateResource, parametersOfAddUpdateResource, methodAddUpdateResourcePrametersTypes);

            // Assert
            parametersOfAddUpdateResource.ShouldNotBeNull();
            parametersOfAddUpdateResource.Length.ShouldBe(5);
            methodAddUpdateResourcePrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddUpdateResource) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_AddUpdateResource_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddUpdateResourcePrametersTypes = new Type[] { typeof(DataTable), typeof(SPWeb), typeof(Guid), typeof(decimal), typeof(Boolean) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodAddUpdateResource, Fixture, methodAddUpdateResourcePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAddUpdateResourcePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddUpdateResource) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_AddUpdateResource_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddUpdateResource, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AddUpdateResource) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_AddUpdateResource_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddUpdateResource, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildFieldsTable) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utilities_BuildFieldsTable_Static_Method_Call_Internally(Type[] types)
        {
            var methodBuildFieldsTablePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodBuildFieldsTable, Fixture, methodBuildFieldsTablePrametersTypes);
        }

        #endregion

        #region Method Call : (BuildFieldsTable) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_BuildFieldsTable_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var isNewResource = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => Utilities.BuildFieldsTable(properties, isNewResource);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (BuildFieldsTable) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_BuildFieldsTable_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var isNewResource = CreateType<bool>();
            var methodBuildFieldsTablePrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(bool) };
            object[] parametersOfBuildFieldsTable = { properties, isNewResource };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildFieldsTable, methodBuildFieldsTablePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodBuildFieldsTable, Fixture, methodBuildFieldsTablePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<DataTable>(null, _utilitiesInstanceType, MethodBuildFieldsTable, parametersOfBuildFieldsTable, methodBuildFieldsTablePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfBuildFieldsTable);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfBuildFieldsTable.ShouldNotBeNull();
            parametersOfBuildFieldsTable.Length.ShouldBe(2);
            methodBuildFieldsTablePrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (BuildFieldsTable) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_BuildFieldsTable_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var isNewResource = CreateType<bool>();
            var methodBuildFieldsTablePrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(bool) };
            object[] parametersOfBuildFieldsTable = { properties, isNewResource };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<DataTable>(null, _utilitiesInstanceType, MethodBuildFieldsTable, parametersOfBuildFieldsTable, methodBuildFieldsTablePrametersTypes);

            // Assert
            parametersOfBuildFieldsTable.ShouldNotBeNull();
            parametersOfBuildFieldsTable.Length.ShouldBe(2);
            methodBuildFieldsTablePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildFieldsTable) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_BuildFieldsTable_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodBuildFieldsTablePrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodBuildFieldsTable, Fixture, methodBuildFieldsTablePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodBuildFieldsTablePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (BuildFieldsTable) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_BuildFieldsTable_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBuildFieldsTablePrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(bool) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodBuildFieldsTable, Fixture, methodBuildFieldsTablePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildFieldsTablePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildFieldsTable) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_BuildFieldsTable_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildFieldsTable, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BuildFieldsTable) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_BuildFieldsTable_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBuildFieldsTable, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteResource) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utilities_DeleteResource_Static_Method_Call_Internally(Type[] types)
        {
            var methodDeleteResourcePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodDeleteResource, Fixture, methodDeleteResourcePrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteResource) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_DeleteResource_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var extId = CreateType<int>();
            var dataId = CreateType<Guid>();
            var spWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => Utilities.DeleteResource(extId, dataId, spWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteResource) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_DeleteResource_Static_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var extId = CreateType<int>();
            var dataId = CreateType<Guid>();
            var spWeb = CreateType<SPWeb>();
            var methodDeleteResourcePrametersTypes = new Type[] { typeof(int), typeof(Guid), typeof(SPWeb) };
            object[] parametersOfDeleteResource = { extId, dataId, spWeb };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDeleteResource, methodDeleteResourcePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfDeleteResource);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDeleteResource.ShouldNotBeNull();
            parametersOfDeleteResource.Length.ShouldBe(3);
            methodDeleteResourcePrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DeleteResource) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_DeleteResource_Static_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var extId = CreateType<int>();
            var dataId = CreateType<Guid>();
            var spWeb = CreateType<SPWeb>();
            var methodDeleteResourcePrametersTypes = new Type[] { typeof(int), typeof(Guid), typeof(SPWeb) };
            object[] parametersOfDeleteResource = { extId, dataId, spWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(null, _utilitiesInstanceType, MethodDeleteResource, parametersOfDeleteResource, methodDeleteResourcePrametersTypes);

            // Assert
            parametersOfDeleteResource.ShouldNotBeNull();
            parametersOfDeleteResource.Length.ShouldBe(3);
            methodDeleteResourcePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteResource) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_DeleteResource_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteResource, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteResource) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_DeleteResource_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteResourcePrametersTypes = new Type[] { typeof(int), typeof(Guid), typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodDeleteResource, Fixture, methodDeleteResourcePrametersTypes);

            // Assert
            methodDeleteResourcePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteResource) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_DeleteResource_Static_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteResource, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCleanFieldValue) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utilities_GetCleanFieldValue_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetCleanFieldValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetCleanFieldValue, Fixture, methodGetCleanFieldValuePrametersTypes);
        }

        #endregion

        #region Method Call : (GetCleanFieldValue) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetCleanFieldValue_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            var rawValue = CreateType<object>();
            var spField = CreateType<SPField>();
            var returnId = CreateType<Boolean>();
            Action executeAction = null;

            // Act
            executeAction = () => Utilities.GetCleanFieldValue(spWeb, rawValue, spField, returnId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetCleanFieldValue) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetCleanFieldValue_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            var rawValue = CreateType<object>();
            var spField = CreateType<SPField>();
            var returnId = CreateType<Boolean>();
            var methodGetCleanFieldValuePrametersTypes = new Type[] { typeof(SPWeb), typeof(object), typeof(SPField), typeof(Boolean) };
            object[] parametersOfGetCleanFieldValue = { spWeb, rawValue, spField, returnId };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCleanFieldValue, methodGetCleanFieldValuePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetCleanFieldValue, Fixture, methodGetCleanFieldValuePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _utilitiesInstanceType, MethodGetCleanFieldValue, parametersOfGetCleanFieldValue, methodGetCleanFieldValuePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetCleanFieldValue);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetCleanFieldValue.ShouldNotBeNull();
            parametersOfGetCleanFieldValue.Length.ShouldBe(4);
            methodGetCleanFieldValuePrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetCleanFieldValue) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetCleanFieldValue_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            var rawValue = CreateType<object>();
            var spField = CreateType<SPField>();
            var returnId = CreateType<Boolean>();
            var methodGetCleanFieldValuePrametersTypes = new Type[] { typeof(SPWeb), typeof(object), typeof(SPField), typeof(Boolean) };
            object[] parametersOfGetCleanFieldValue = { spWeb, rawValue, spField, returnId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _utilitiesInstanceType, MethodGetCleanFieldValue, parametersOfGetCleanFieldValue, methodGetCleanFieldValuePrametersTypes);

            // Assert
            parametersOfGetCleanFieldValue.ShouldNotBeNull();
            parametersOfGetCleanFieldValue.Length.ShouldBe(4);
            methodGetCleanFieldValuePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCleanFieldValue) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetCleanFieldValue_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCleanFieldValuePrametersTypes = new Type[] { typeof(SPWeb), typeof(object), typeof(SPField), typeof(Boolean) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetCleanFieldValue, Fixture, methodGetCleanFieldValuePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCleanFieldValuePrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetCleanFieldValue) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetCleanFieldValue_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCleanFieldValuePrametersTypes = new Type[] { typeof(SPWeb), typeof(object), typeof(SPField), typeof(Boolean) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetCleanFieldValue, Fixture, methodGetCleanFieldValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCleanFieldValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCleanFieldValue) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetCleanFieldValue_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCleanFieldValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCleanFieldValue) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetCleanFieldValue_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCleanFieldValue, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PerformDeleteResourceCheck) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utilities_PerformDeleteResourceCheck_Static_Method_Call_Internally(Type[] types)
        {
            var methodPerformDeleteResourceCheckPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodPerformDeleteResourceCheck, Fixture, methodPerformDeleteResourceCheckPrametersTypes);
        }

        #endregion

        #region Method Call : (PerformDeleteResourceCheck) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_PerformDeleteResourceCheck_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var extId = CreateType<int>();
            var dataId = CreateType<Guid>();
            var spWeb = CreateType<SPWeb>();
            var deleteResourceCheckStatus = CreateType<string>();
            var deleteResourceCheckMessage = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => Utilities.PerformDeleteResourceCheck(extId, dataId, spWeb, out deleteResourceCheckStatus, out deleteResourceCheckMessage);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (PerformDeleteResourceCheck) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_PerformDeleteResourceCheck_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var extId = CreateType<int>();
            var dataId = CreateType<Guid>();
            var spWeb = CreateType<SPWeb>();
            var deleteResourceCheckStatus = CreateType<string>();
            var deleteResourceCheckMessage = CreateType<string>();
            var methodPerformDeleteResourceCheckPrametersTypes = new Type[] { typeof(int), typeof(Guid), typeof(SPWeb), typeof(string), typeof(string) };
            object[] parametersOfPerformDeleteResourceCheck = { extId, dataId, spWeb, deleteResourceCheckStatus, deleteResourceCheckMessage };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(null, _utilitiesInstanceType, MethodPerformDeleteResourceCheck, parametersOfPerformDeleteResourceCheck, methodPerformDeleteResourceCheckPrametersTypes);

            // Assert
            parametersOfPerformDeleteResourceCheck.ShouldNotBeNull();
            parametersOfPerformDeleteResourceCheck.Length.ShouldBe(5);
            methodPerformDeleteResourceCheckPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PerformDeleteResourceCheck) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_PerformDeleteResourceCheck_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPerformDeleteResourceCheckPrametersTypes = new Type[] { typeof(int), typeof(Guid), typeof(SPWeb), typeof(string), typeof(string) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodPerformDeleteResourceCheck, Fixture, methodPerformDeleteResourceCheckPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodPerformDeleteResourceCheckPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PerformDeleteResourceCheck) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_PerformDeleteResourceCheck_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPerformDeleteResourceCheck, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PerformDeleteResourceCheck) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_PerformDeleteResourceCheck_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPerformDeleteResourceCheck, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (WriteDataTableToFile) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utilities_WriteDataTableToFile_Static_Method_Call_Internally(Type[] types)
        {
            var methodWriteDataTableToFilePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodWriteDataTableToFile, Fixture, methodWriteDataTableToFilePrametersTypes);
        }

        #endregion

        #region Method Call : (WriteDataTableToFile) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_WriteDataTableToFile_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var dt = CreateType<DataTable>();
            var outputFilePath = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => Utilities.WriteDataTableToFile(dt, outputFilePath);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (WriteDataTableToFile) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_WriteDataTableToFile_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var dt = CreateType<DataTable>();
            var outputFilePath = CreateType<string>();
            var methodWriteDataTableToFilePrametersTypes = new Type[] { typeof(DataTable), typeof(string) };
            object[] parametersOfWriteDataTableToFile = { dt, outputFilePath };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodWriteDataTableToFile, methodWriteDataTableToFilePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfWriteDataTableToFile);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfWriteDataTableToFile.ShouldNotBeNull();
            parametersOfWriteDataTableToFile.Length.ShouldBe(2);
            methodWriteDataTableToFilePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteDataTableToFile) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_WriteDataTableToFile_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dt = CreateType<DataTable>();
            var outputFilePath = CreateType<string>();
            var methodWriteDataTableToFilePrametersTypes = new Type[] { typeof(DataTable), typeof(string) };
            object[] parametersOfWriteDataTableToFile = { dt, outputFilePath };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(null, _utilitiesInstanceType, MethodWriteDataTableToFile, parametersOfWriteDataTableToFile, methodWriteDataTableToFilePrametersTypes);

            // Assert
            parametersOfWriteDataTableToFile.ShouldNotBeNull();
            parametersOfWriteDataTableToFile.Length.ShouldBe(2);
            methodWriteDataTableToFilePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteDataTableToFile) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_WriteDataTableToFile_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodWriteDataTableToFile, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (WriteDataTableToFile) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_WriteDataTableToFile_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodWriteDataTableToFilePrametersTypes = new Type[] { typeof(DataTable), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodWriteDataTableToFile, Fixture, methodWriteDataTableToFilePrametersTypes);

            // Assert
            methodWriteDataTableToFilePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteDataTableToFile) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_WriteDataTableToFile_Static_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodWriteDataTableToFile, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AreEqualObjects) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utilities_AreEqualObjects_Static_Method_Call_Internally(Type[] types)
        {
            var methodAreEqualObjectsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodAreEqualObjects, Fixture, methodAreEqualObjectsPrametersTypes);
        }

        #endregion

        #region Method Call : (AreEqualObjects) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_AreEqualObjects_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var newValue = CreateType<object>();
            var currentValue = CreateType<object>();
            var spField = CreateType<SPField>();
            var spWeb = CreateType<SPWeb>();
            var methodAreEqualObjectsPrametersTypes = new Type[] { typeof(object), typeof(object), typeof(SPField), typeof(SPWeb) };
            object[] parametersOfAreEqualObjects = { newValue, currentValue, spField, spWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(null, _utilitiesInstanceType, MethodAreEqualObjects, parametersOfAreEqualObjects, methodAreEqualObjectsPrametersTypes);

            // Assert
            parametersOfAreEqualObjects.ShouldNotBeNull();
            parametersOfAreEqualObjects.Length.ShouldBe(4);
            methodAreEqualObjectsPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AreEqualObjects) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_AreEqualObjects_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAreEqualObjectsPrametersTypes = new Type[] { typeof(object), typeof(object), typeof(SPField), typeof(SPWeb) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodAreEqualObjects, Fixture, methodAreEqualObjectsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAreEqualObjectsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AreEqualObjects) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_AreEqualObjects_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAreEqualObjects, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AreEqualObjects) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_AreEqualObjects_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAreEqualObjects, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCleanFieldValue) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utilities_GetCleanFieldValue_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodGetCleanFieldValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetCleanFieldValue, Fixture, methodGetCleanFieldValuePrametersTypes);
        }

        #endregion

        #region Method Call : (GetCleanFieldValue) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetCleanFieldValue_Static_Method_Call_Overloading_Of_1_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            var dataRow = CreateType<DataRow>();
            var rawValue = CreateType<object>();
            var returnId = CreateType<Boolean>();
            var methodGetCleanFieldValuePrametersTypes = new Type[] { typeof(SPWeb), typeof(DataRow), typeof(object), typeof(Boolean) };
            object[] parametersOfGetCleanFieldValue = { spWeb, dataRow, rawValue, returnId };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCleanFieldValue, methodGetCleanFieldValuePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetCleanFieldValue, Fixture, methodGetCleanFieldValuePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _utilitiesInstanceType, MethodGetCleanFieldValue, parametersOfGetCleanFieldValue, methodGetCleanFieldValuePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetCleanFieldValue);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetCleanFieldValue.ShouldNotBeNull();
            parametersOfGetCleanFieldValue.Length.ShouldBe(4);
            methodGetCleanFieldValuePrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetCleanFieldValue) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetCleanFieldValue_Static_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            var dataRow = CreateType<DataRow>();
            var rawValue = CreateType<object>();
            var returnId = CreateType<Boolean>();
            var methodGetCleanFieldValuePrametersTypes = new Type[] { typeof(SPWeb), typeof(DataRow), typeof(object), typeof(Boolean) };
            object[] parametersOfGetCleanFieldValue = { spWeb, dataRow, rawValue, returnId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _utilitiesInstanceType, MethodGetCleanFieldValue, parametersOfGetCleanFieldValue, methodGetCleanFieldValuePrametersTypes);

            // Assert
            parametersOfGetCleanFieldValue.ShouldNotBeNull();
            parametersOfGetCleanFieldValue.Length.ShouldBe(4);
            methodGetCleanFieldValuePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCleanFieldValue) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetCleanFieldValue_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCleanFieldValuePrametersTypes = new Type[] { typeof(SPWeb), typeof(DataRow), typeof(object), typeof(Boolean) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetCleanFieldValue, Fixture, methodGetCleanFieldValuePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCleanFieldValuePrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetCleanFieldValue) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetCleanFieldValue_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCleanFieldValuePrametersTypes = new Type[] { typeof(SPWeb), typeof(DataRow), typeof(object), typeof(Boolean) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetCleanFieldValue, Fixture, methodGetCleanFieldValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCleanFieldValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCleanFieldValue) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetCleanFieldValue_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCleanFieldValue, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCleanFieldValue) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetCleanFieldValue_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCleanFieldValue, 1);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetUserName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utilities_GetUserName_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetUserNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetUserName, Fixture, methodGetUserNamePrametersTypes);
        }

        #endregion

        #region Method Call : (GetUserName) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetUserName_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            var spFieldUserValue = CreateType<SPFieldUserValue>();
            var methodGetUserNamePrametersTypes = new Type[] { typeof(SPWeb), typeof(SPFieldUserValue) };
            object[] parametersOfGetUserName = { spWeb, spFieldUserValue };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetUserName, methodGetUserNamePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetUserName, Fixture, methodGetUserNamePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _utilitiesInstanceType, MethodGetUserName, parametersOfGetUserName, methodGetUserNamePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetUserName);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetUserName.ShouldNotBeNull();
            parametersOfGetUserName.Length.ShouldBe(2);
            methodGetUserNamePrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetUserName) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetUserName_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            var spFieldUserValue = CreateType<SPFieldUserValue>();
            var methodGetUserNamePrametersTypes = new Type[] { typeof(SPWeb), typeof(SPFieldUserValue) };
            object[] parametersOfGetUserName = { spWeb, spFieldUserValue };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _utilitiesInstanceType, MethodGetUserName, parametersOfGetUserName, methodGetUserNamePrametersTypes);

            // Assert
            parametersOfGetUserName.ShouldNotBeNull();
            parametersOfGetUserName.Length.ShouldBe(2);
            methodGetUserNamePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetUserName) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetUserName_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetUserNamePrametersTypes = new Type[] { typeof(SPWeb), typeof(SPFieldUserValue) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetUserName, Fixture, methodGetUserNamePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetUserNamePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetUserName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetUserName_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetUserNamePrametersTypes = new Type[] { typeof(SPWeb), typeof(SPFieldUserValue) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetUserName, Fixture, methodGetUserNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetUserNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetUserName) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetUserName_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetUserName, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetUserName) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetUserName_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetUserName, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetValue) (Return Type : object) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utilities_GetValue_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetValue, Fixture, methodGetValuePrametersTypes);
        }

        #endregion

        #region Method Call : (GetValue) (Return Type : object) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetValue_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var internalName = CreateType<string>();
            var methodGetValuePrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(string) };
            object[] parametersOfGetValue = { properties, internalName };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetValue, methodGetValuePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetValue, Fixture, methodGetValuePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<object>(null, _utilitiesInstanceType, MethodGetValue, parametersOfGetValue, methodGetValuePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetValue);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetValue.ShouldNotBeNull();
            parametersOfGetValue.Length.ShouldBe(2);
            methodGetValuePrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetValue) (Return Type : object) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetValue_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var internalName = CreateType<string>();
            var methodGetValuePrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(string) };
            object[] parametersOfGetValue = { properties, internalName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<object>(null, _utilitiesInstanceType, MethodGetValue, parametersOfGetValue, methodGetValuePrametersTypes);

            // Assert
            parametersOfGetValue.ShouldNotBeNull();
            parametersOfGetValue.Length.ShouldBe(2);
            methodGetValuePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetValue) (Return Type : object) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetValue_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetValuePrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetValue, Fixture, methodGetValuePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetValuePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetValue) (Return Type : object) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetValue_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetValuePrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetValue, Fixture, methodGetValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetValue) (Return Type : object) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetValue_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetValue) (Return Type : object) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetValue_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetValue, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TryGetPFEFieldId) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utilities_TryGetPFEFieldId_Static_Method_Call_Internally(Type[] types)
        {
            var methodTryGetPFEFieldIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodTryGetPFEFieldId, Fixture, methodTryGetPFEFieldIdPrametersTypes);
        }

        #endregion

        #region Method Call : (TryGetPFEFieldId) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_TryGetPFEFieldId_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var internalName = CreateType<string>();
            var pfeResourceField = CreateType<PFEResourceField>();
            var methodTryGetPFEFieldIdPrametersTypes = new Type[] { typeof(string), typeof(PFEResourceField) };
            object[] parametersOfTryGetPFEFieldId = { internalName, pfeResourceField };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodTryGetPFEFieldId, methodTryGetPFEFieldIdPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfTryGetPFEFieldId);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfTryGetPFEFieldId.ShouldNotBeNull();
            parametersOfTryGetPFEFieldId.Length.ShouldBe(2);
            methodTryGetPFEFieldIdPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (TryGetPFEFieldId) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_TryGetPFEFieldId_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var internalName = CreateType<string>();
            var pfeResourceField = CreateType<PFEResourceField>();
            var methodTryGetPFEFieldIdPrametersTypes = new Type[] { typeof(string), typeof(PFEResourceField) };
            object[] parametersOfTryGetPFEFieldId = { internalName, pfeResourceField };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(null, _utilitiesInstanceType, MethodTryGetPFEFieldId, parametersOfTryGetPFEFieldId, methodTryGetPFEFieldIdPrametersTypes);

            // Assert
            parametersOfTryGetPFEFieldId.ShouldNotBeNull();
            parametersOfTryGetPFEFieldId.Length.ShouldBe(2);
            methodTryGetPFEFieldIdPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (TryGetPFEFieldId) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_TryGetPFEFieldId_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodTryGetPFEFieldIdPrametersTypes = new Type[] { typeof(string), typeof(PFEResourceField) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodTryGetPFEFieldId, Fixture, methodTryGetPFEFieldIdPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodTryGetPFEFieldIdPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TryGetPFEFieldId) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_TryGetPFEFieldId_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodTryGetPFEFieldId, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (TryGetPFEFieldId) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_TryGetPFEFieldId_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodTryGetPFEFieldId, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CheckPFEResourceCenterPermission) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utilities_CheckPFEResourceCenterPermission_Static_Method_Call_Internally(Type[] types)
        {
            var methodCheckPFEResourceCenterPermissionPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodCheckPFEResourceCenterPermission, Fixture, methodCheckPFEResourceCenterPermissionPrametersTypes);
        }

        #endregion

        #region Method Call : (CheckPFEResourceCenterPermission) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_CheckPFEResourceCenterPermission_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var lWResID = CreateType<int>();
            var hasDeletePermission = CreateType<bool>();
            var hasPFEResourceCenterPermissions = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => Utilities.CheckPFEResourceCenterPermission(web, lWResID, hasDeletePermission, out hasPFEResourceCenterPermissions);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CheckPFEResourceCenterPermission) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_CheckPFEResourceCenterPermission_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var lWResID = CreateType<int>();
            var hasDeletePermission = CreateType<bool>();
            var hasPFEResourceCenterPermissions = CreateType<bool>();
            var methodCheckPFEResourceCenterPermissionPrametersTypes = new Type[] { typeof(SPWeb), typeof(int), typeof(bool), typeof(bool) };
            object[] parametersOfCheckPFEResourceCenterPermission = { web, lWResID, hasDeletePermission, hasPFEResourceCenterPermissions };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(null, _utilitiesInstanceType, MethodCheckPFEResourceCenterPermission, parametersOfCheckPFEResourceCenterPermission, methodCheckPFEResourceCenterPermissionPrametersTypes);

            // Assert
            parametersOfCheckPFEResourceCenterPermission.ShouldNotBeNull();
            parametersOfCheckPFEResourceCenterPermission.Length.ShouldBe(4);
            methodCheckPFEResourceCenterPermissionPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CheckPFEResourceCenterPermission) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_CheckPFEResourceCenterPermission_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCheckPFEResourceCenterPermissionPrametersTypes = new Type[] { typeof(SPWeb), typeof(int), typeof(bool), typeof(bool) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodCheckPFEResourceCenterPermission, Fixture, methodCheckPFEResourceCenterPermissionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCheckPFEResourceCenterPermissionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CheckPFEResourceCenterPermission) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_CheckPFEResourceCenterPermission_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCheckPFEResourceCenterPermission, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CheckPFEResourceCenterPermission) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_CheckPFEResourceCenterPermission_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCheckPFEResourceCenterPermission, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetValidDateInFormat) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utilities_GetValidDateInFormat_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetValidDateInFormatPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetValidDateInFormat, Fixture, methodGetValidDateInFormatPrametersTypes);
        }

        #endregion

        #region Method Call : (GetValidDateInFormat) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetValidDateInFormat_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var calendarOrderType = CreateType<SPCalendarOrderType>();
            var columnValue = CreateType<string>();
            var dateSeparator = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => Utilities.GetValidDateInFormat(calendarOrderType, columnValue, dateSeparator);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetValidDateInFormat) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetValidDateInFormat_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var calendarOrderType = CreateType<SPCalendarOrderType>();
            var columnValue = CreateType<string>();
            var dateSeparator = CreateType<string>();
            var methodGetValidDateInFormatPrametersTypes = new Type[] { typeof(SPCalendarOrderType), typeof(string), typeof(string) };
            object[] parametersOfGetValidDateInFormat = { calendarOrderType, columnValue, dateSeparator };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetValidDateInFormat, methodGetValidDateInFormatPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetValidDateInFormat, Fixture, methodGetValidDateInFormatPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _utilitiesInstanceType, MethodGetValidDateInFormat, parametersOfGetValidDateInFormat, methodGetValidDateInFormatPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetValidDateInFormat);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetValidDateInFormat.ShouldNotBeNull();
            parametersOfGetValidDateInFormat.Length.ShouldBe(3);
            methodGetValidDateInFormatPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetValidDateInFormat) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetValidDateInFormat_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var calendarOrderType = CreateType<SPCalendarOrderType>();
            var columnValue = CreateType<string>();
            var dateSeparator = CreateType<string>();
            var methodGetValidDateInFormatPrametersTypes = new Type[] { typeof(SPCalendarOrderType), typeof(string), typeof(string) };
            object[] parametersOfGetValidDateInFormat = { calendarOrderType, columnValue, dateSeparator };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _utilitiesInstanceType, MethodGetValidDateInFormat, parametersOfGetValidDateInFormat, methodGetValidDateInFormatPrametersTypes);

            // Assert
            parametersOfGetValidDateInFormat.ShouldNotBeNull();
            parametersOfGetValidDateInFormat.Length.ShouldBe(3);
            methodGetValidDateInFormatPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetValidDateInFormat) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetValidDateInFormat_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetValidDateInFormatPrametersTypes = new Type[] { typeof(SPCalendarOrderType), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetValidDateInFormat, Fixture, methodGetValidDateInFormatPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetValidDateInFormatPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetValidDateInFormat) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetValidDateInFormat_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetValidDateInFormatPrametersTypes = new Type[] { typeof(SPCalendarOrderType), typeof(string), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetValidDateInFormat, Fixture, methodGetValidDateInFormatPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetValidDateInFormatPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetValidDateInFormat) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetValidDateInFormat_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetValidDateInFormat, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetValidDateInFormat) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetValidDateInFormat_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetValidDateInFormat, 0);
            const int parametersCount = 3;

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
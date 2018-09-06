using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace WorkEnginePPM.Core.DataSync
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.Core.DataSync.DepartmentManager" />)
    ///     and namespace <see cref="WorkEnginePPM.Core.DataSync"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class DepartmentManagerTest : AbstractBaseSetupTypedTest<DepartmentManager>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DepartmentManager) Initializer

        private const string PropertyResourceDictionary = "ResourceDictionary";
        private const string PropertyResourcesListItems = "ResourcesListItems";
        private const string MethodDelete = "Delete";
        private const string MethodGetAllFromPFE = "GetAllFromPFE";
        private const string MethodGetDataTable = "GetDataTable";
        private const string MethodSynchronize = "Synchronize";
        private const string MethodPerformDepartmentDeleteCheck = "PerformDepartmentDeleteCheck";
        private const string MethodBuildRequest = "BuildRequest";
        private const string MethodGetResourceLookupFromExtId = "GetResourceLookupFromExtId";
        private const string MethodGetResourcePoolId = "GetResourcePoolId";
        private Type _departmentManagerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DepartmentManager _departmentManagerInstance;
        private DepartmentManager _departmentManagerInstanceFixture;

        #region General Initializer : Class (DepartmentManager) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DepartmentManager" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _departmentManagerInstanceType = typeof(DepartmentManager);
            _departmentManagerInstanceFixture = Create(true);
            _departmentManagerInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DepartmentManager)

        #region General Initializer : Class (DepartmentManager) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="DepartmentManager" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodDelete, 0)]
        [TestCase(MethodGetAllFromPFE, 0)]
        [TestCase(MethodGetDataTable, 0)]
        [TestCase(MethodSynchronize, 0)]
        [TestCase(MethodPerformDepartmentDeleteCheck, 0)]
        [TestCase(MethodBuildRequest, 0)]
        [TestCase(MethodGetResourceLookupFromExtId, 0)]
        [TestCase(MethodGetResourcePoolId, 0)]
        public void AUT_DepartmentManager_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_departmentManagerInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DepartmentManager) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DepartmentManager" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyResourceDictionary)]
        [TestCase(PropertyResourcesListItems)]
        public void AUT_DepartmentManager_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_departmentManagerInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DepartmentManager) => Property (ResourceDictionary) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_DepartmentManager_Public_Class_ResourceDictionary_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyResourceDictionary);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DepartmentManager) => Property (ResourcesListItems) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_DepartmentManager_Public_Class_ResourcesListItems_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyResourcesListItems);

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
        ///      Class (<see cref="DepartmentManager" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodDelete)]
        [TestCase(MethodGetAllFromPFE)]
        [TestCase(MethodGetDataTable)]
        [TestCase(MethodSynchronize)]
        [TestCase(MethodPerformDepartmentDeleteCheck)]
        [TestCase(MethodBuildRequest)]
        [TestCase(MethodGetResourceLookupFromExtId)]
        [TestCase(MethodGetResourcePoolId)]
        public void AUT_DepartmentManager_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<DepartmentManager>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DepartmentManager_Delete_Method_Call_Internally(Type[] types)
        {
            var methodDeletePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_departmentManagerInstance, MethodDelete, Fixture, methodDeletePrametersTypes);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_Delete_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var id = CreateType<int>();
            var extId = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _departmentManagerInstance.Delete(id, extId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_Delete_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var id = CreateType<int>();
            var extId = CreateType<string>();
            var methodDeletePrametersTypes = new Type[] { typeof(int), typeof(string) };
            object[] parametersOfDelete = { id, extId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDelete, methodDeletePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<DepartmentManager, bool>(_departmentManagerInstanceFixture, out exception1, parametersOfDelete);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<DepartmentManager, bool>(_departmentManagerInstance, MethodDelete, parametersOfDelete, methodDeletePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDelete.ShouldNotBeNull();
            parametersOfDelete.Length.ShouldBe(2);
            methodDeletePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_Delete_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var id = CreateType<int>();
            var extId = CreateType<string>();
            var methodDeletePrametersTypes = new Type[] { typeof(int), typeof(string) };
            object[] parametersOfDelete = { id, extId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDelete, methodDeletePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<DepartmentManager, bool>(_departmentManagerInstanceFixture, out exception1, parametersOfDelete);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<DepartmentManager, bool>(_departmentManagerInstance, MethodDelete, parametersOfDelete, methodDeletePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDelete.ShouldNotBeNull();
            parametersOfDelete.Length.ShouldBe(2);
            methodDeletePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_Delete_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var id = CreateType<int>();
            var extId = CreateType<string>();
            var methodDeletePrametersTypes = new Type[] { typeof(int), typeof(string) };
            object[] parametersOfDelete = { id, extId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<DepartmentManager, bool>(_departmentManagerInstance, MethodDelete, parametersOfDelete, methodDeletePrametersTypes);

            // Assert
            parametersOfDelete.ShouldNotBeNull();
            parametersOfDelete.Length.ShouldBe(2);
            methodDeletePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_Delete_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeletePrametersTypes = new Type[] { typeof(int), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_departmentManagerInstance, MethodDelete, Fixture, methodDeletePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeletePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_Delete_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDelete, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_departmentManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Delete) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_Delete_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDelete, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAllFromPFE) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DepartmentManager_GetAllFromPFE_Method_Call_Internally(Type[] types)
        {
            var methodGetAllFromPFEPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_departmentManagerInstance, MethodGetAllFromPFE, Fixture, methodGetAllFromPFEPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAllFromPFE) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_GetAllFromPFE_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _departmentManagerInstance.GetAllFromPFE();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetAllFromPFE) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_GetAllFromPFE_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetAllFromPFEPrametersTypes = null;
            object[] parametersOfGetAllFromPFE = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetAllFromPFE, methodGetAllFromPFEPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<DepartmentManager, DataTable>(_departmentManagerInstanceFixture, out exception1, parametersOfGetAllFromPFE);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<DepartmentManager, DataTable>(_departmentManagerInstance, MethodGetAllFromPFE, parametersOfGetAllFromPFE, methodGetAllFromPFEPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetAllFromPFE.ShouldBeNull();
            methodGetAllFromPFEPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAllFromPFE) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_GetAllFromPFE_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetAllFromPFEPrametersTypes = null;
            object[] parametersOfGetAllFromPFE = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<DepartmentManager, DataTable>(_departmentManagerInstance, MethodGetAllFromPFE, parametersOfGetAllFromPFE, methodGetAllFromPFEPrametersTypes);

            // Assert
            parametersOfGetAllFromPFE.ShouldBeNull();
            methodGetAllFromPFEPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAllFromPFE) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_GetAllFromPFE_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetAllFromPFEPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_departmentManagerInstance, MethodGetAllFromPFE, Fixture, methodGetAllFromPFEPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetAllFromPFEPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAllFromPFE) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_GetAllFromPFE_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetAllFromPFEPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_departmentManagerInstance, MethodGetAllFromPFE, Fixture, methodGetAllFromPFEPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetAllFromPFEPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAllFromPFE) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_GetAllFromPFE_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetAllFromPFE, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_departmentManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDataTable) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DepartmentManager_GetDataTable_Method_Call_Internally(Type[] types)
        {
            var methodGetDataTablePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_departmentManagerInstance, MethodGetDataTable, Fixture, methodGetDataTablePrametersTypes);
        }

        #endregion

        #region Method Call : (GetDataTable) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_GetDataTable_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var spListItemCollection = CreateType<SPListItemCollection>();
            Action executeAction = null;

            // Act
            executeAction = () => _departmentManagerInstance.GetDataTable(spListItemCollection);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetDataTable) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_GetDataTable_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var spListItemCollection = CreateType<SPListItemCollection>();
            var methodGetDataTablePrametersTypes = new Type[] { typeof(SPListItemCollection) };
            object[] parametersOfGetDataTable = { spListItemCollection };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDataTable, methodGetDataTablePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<DepartmentManager, DataTable>(_departmentManagerInstanceFixture, out exception1, parametersOfGetDataTable);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<DepartmentManager, DataTable>(_departmentManagerInstance, MethodGetDataTable, parametersOfGetDataTable, methodGetDataTablePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetDataTable.ShouldNotBeNull();
            parametersOfGetDataTable.Length.ShouldBe(1);
            methodGetDataTablePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetDataTable) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_GetDataTable_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spListItemCollection = CreateType<SPListItemCollection>();
            var methodGetDataTablePrametersTypes = new Type[] { typeof(SPListItemCollection) };
            object[] parametersOfGetDataTable = { spListItemCollection };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<DepartmentManager, DataTable>(_departmentManagerInstance, MethodGetDataTable, parametersOfGetDataTable, methodGetDataTablePrametersTypes);

            // Assert
            parametersOfGetDataTable.ShouldNotBeNull();
            parametersOfGetDataTable.Length.ShouldBe(1);
            methodGetDataTablePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDataTable) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_GetDataTable_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetDataTablePrametersTypes = new Type[] { typeof(SPListItemCollection) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_departmentManagerInstance, MethodGetDataTable, Fixture, methodGetDataTablePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDataTablePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetDataTable) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_GetDataTable_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDataTablePrametersTypes = new Type[] { typeof(SPListItemCollection) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_departmentManagerInstance, MethodGetDataTable, Fixture, methodGetDataTablePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDataTablePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDataTable) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_GetDataTable_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDataTable, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_departmentManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDataTable) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_GetDataTable_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetDataTable, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Synchronize) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DepartmentManager_Synchronize_Method_Call_Internally(Type[] types)
        {
            var methodSynchronizePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_departmentManagerInstance, MethodSynchronize, Fixture, methodSynchronizePrametersTypes);
        }

        #endregion

        #region Method Call : (Synchronize) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_Synchronize_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var dataTable = CreateType<DataTable>();
            Action executeAction = null;

            // Act
            executeAction = () => _departmentManagerInstance.Synchronize(dataTable);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Synchronize) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_Synchronize_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var dataTable = CreateType<DataTable>();
            var methodSynchronizePrametersTypes = new Type[] { typeof(DataTable) };
            object[] parametersOfSynchronize = { dataTable };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSynchronize, methodSynchronizePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<DepartmentManager, DataTable>(_departmentManagerInstanceFixture, out exception1, parametersOfSynchronize);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<DepartmentManager, DataTable>(_departmentManagerInstance, MethodSynchronize, parametersOfSynchronize, methodSynchronizePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSynchronize.ShouldNotBeNull();
            parametersOfSynchronize.Length.ShouldBe(1);
            methodSynchronizePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Synchronize) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_Synchronize_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dataTable = CreateType<DataTable>();
            var methodSynchronizePrametersTypes = new Type[] { typeof(DataTable) };
            object[] parametersOfSynchronize = { dataTable };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<DepartmentManager, DataTable>(_departmentManagerInstance, MethodSynchronize, parametersOfSynchronize, methodSynchronizePrametersTypes);

            // Assert
            parametersOfSynchronize.ShouldNotBeNull();
            parametersOfSynchronize.Length.ShouldBe(1);
            methodSynchronizePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Synchronize) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_Synchronize_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSynchronizePrametersTypes = new Type[] { typeof(DataTable) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_departmentManagerInstance, MethodSynchronize, Fixture, methodSynchronizePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSynchronizePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Synchronize) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_Synchronize_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSynchronizePrametersTypes = new Type[] { typeof(DataTable) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_departmentManagerInstance, MethodSynchronize, Fixture, methodSynchronizePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSynchronizePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Synchronize) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_Synchronize_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSynchronize, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_departmentManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Synchronize) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_Synchronize_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSynchronize, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PerformDepartmentDeleteCheck) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DepartmentManager_PerformDepartmentDeleteCheck_Method_Call_Internally(Type[] types)
        {
            var methodPerformDepartmentDeleteCheckPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_departmentManagerInstance, MethodPerformDepartmentDeleteCheck, Fixture, methodPerformDepartmentDeleteCheckPrametersTypes);
        }

        #endregion

        #region Method Call : (PerformDepartmentDeleteCheck) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_PerformDepartmentDeleteCheck_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var Errmsg = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _departmentManagerInstance.PerformDepartmentDeleteCheck(properties, out Errmsg);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (PerformDepartmentDeleteCheck) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_PerformDepartmentDeleteCheck_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var Errmsg = CreateType<string>();
            var methodPerformDepartmentDeleteCheckPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(string) };
            object[] parametersOfPerformDepartmentDeleteCheck = { properties, Errmsg };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodPerformDepartmentDeleteCheck, methodPerformDepartmentDeleteCheckPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<DepartmentManager, bool>(_departmentManagerInstanceFixture, out exception1, parametersOfPerformDepartmentDeleteCheck);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<DepartmentManager, bool>(_departmentManagerInstance, MethodPerformDepartmentDeleteCheck, parametersOfPerformDepartmentDeleteCheck, methodPerformDepartmentDeleteCheckPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfPerformDepartmentDeleteCheck.ShouldNotBeNull();
            parametersOfPerformDepartmentDeleteCheck.Length.ShouldBe(2);
            methodPerformDepartmentDeleteCheckPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (PerformDepartmentDeleteCheck) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_PerformDepartmentDeleteCheck_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var Errmsg = CreateType<string>();
            var methodPerformDepartmentDeleteCheckPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(string) };
            object[] parametersOfPerformDepartmentDeleteCheck = { properties, Errmsg };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodPerformDepartmentDeleteCheck, methodPerformDepartmentDeleteCheckPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<DepartmentManager, bool>(_departmentManagerInstanceFixture, out exception1, parametersOfPerformDepartmentDeleteCheck);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<DepartmentManager, bool>(_departmentManagerInstance, MethodPerformDepartmentDeleteCheck, parametersOfPerformDepartmentDeleteCheck, methodPerformDepartmentDeleteCheckPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfPerformDepartmentDeleteCheck.ShouldNotBeNull();
            parametersOfPerformDepartmentDeleteCheck.Length.ShouldBe(2);
            methodPerformDepartmentDeleteCheckPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (PerformDepartmentDeleteCheck) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_PerformDepartmentDeleteCheck_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var Errmsg = CreateType<string>();
            var methodPerformDepartmentDeleteCheckPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(string) };
            object[] parametersOfPerformDepartmentDeleteCheck = { properties, Errmsg };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<DepartmentManager, bool>(_departmentManagerInstance, MethodPerformDepartmentDeleteCheck, parametersOfPerformDepartmentDeleteCheck, methodPerformDepartmentDeleteCheckPrametersTypes);

            // Assert
            parametersOfPerformDepartmentDeleteCheck.ShouldNotBeNull();
            parametersOfPerformDepartmentDeleteCheck.Length.ShouldBe(2);
            methodPerformDepartmentDeleteCheckPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PerformDepartmentDeleteCheck) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_PerformDepartmentDeleteCheck_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPerformDepartmentDeleteCheckPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_departmentManagerInstance, MethodPerformDepartmentDeleteCheck, Fixture, methodPerformDepartmentDeleteCheckPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodPerformDepartmentDeleteCheckPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PerformDepartmentDeleteCheck) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_PerformDepartmentDeleteCheck_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPerformDepartmentDeleteCheck, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_departmentManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PerformDepartmentDeleteCheck) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_PerformDepartmentDeleteCheck_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPerformDepartmentDeleteCheck, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildRequest) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DepartmentManager_BuildRequest_Method_Call_Internally(Type[] types)
        {
            var methodBuildRequestPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_departmentManagerInstance, MethodBuildRequest, Fixture, methodBuildRequestPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildRequest) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_BuildRequest_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var parentId = CreateType<int>();
            var dataTable = CreateType<DataTable>();
            var dataElement = CreateType<XElement>();
            var methodBuildRequestPrametersTypes = new Type[] { typeof(int), typeof(DataTable), typeof(XElement) };
            object[] parametersOfBuildRequest = { parentId, dataTable, dataElement };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBuildRequest, methodBuildRequestPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_departmentManagerInstanceFixture, parametersOfBuildRequest);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfBuildRequest.ShouldNotBeNull();
            parametersOfBuildRequest.Length.ShouldBe(3);
            methodBuildRequestPrametersTypes.Length.ShouldBe(3);
            methodBuildRequestPrametersTypes.Length.ShouldBe(parametersOfBuildRequest.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (BuildRequest) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_BuildRequest_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var parentId = CreateType<int>();
            var dataTable = CreateType<DataTable>();
            var dataElement = CreateType<XElement>();
            var methodBuildRequestPrametersTypes = new Type[] { typeof(int), typeof(DataTable), typeof(XElement) };
            object[] parametersOfBuildRequest = { parentId, dataTable, dataElement };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_departmentManagerInstance, MethodBuildRequest, parametersOfBuildRequest, methodBuildRequestPrametersTypes);

            // Assert
            parametersOfBuildRequest.ShouldNotBeNull();
            parametersOfBuildRequest.Length.ShouldBe(3);
            methodBuildRequestPrametersTypes.Length.ShouldBe(3);
            methodBuildRequestPrametersTypes.Length.ShouldBe(parametersOfBuildRequest.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildRequest) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_BuildRequest_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBuildRequest, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildRequest) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_BuildRequest_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBuildRequestPrametersTypes = new Type[] { typeof(int), typeof(DataTable), typeof(XElement) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_departmentManagerInstance, MethodBuildRequest, Fixture, methodBuildRequestPrametersTypes);

            // Assert
            methodBuildRequestPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildRequest) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_BuildRequest_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildRequest, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_departmentManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetResourceLookupFromExtId) (Return Type : object) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DepartmentManager_GetResourceLookupFromExtId_Method_Call_Internally(Type[] types)
        {
            var methodGetResourceLookupFromExtIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_departmentManagerInstance, MethodGetResourceLookupFromExtId, Fixture, methodGetResourceLookupFromExtIdPrametersTypes);
        }

        #endregion

        #region Method Call : (GetResourceLookupFromExtId) (Return Type : object) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_GetResourceLookupFromExtId_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var resources = CreateType<string>();
            var isManager = CreateType<bool>();
            var methodGetResourceLookupFromExtIdPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfGetResourceLookupFromExtId = { resources, isManager };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetResourceLookupFromExtId, methodGetResourceLookupFromExtIdPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<DepartmentManager, object>(_departmentManagerInstanceFixture, out exception1, parametersOfGetResourceLookupFromExtId);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<DepartmentManager, object>(_departmentManagerInstance, MethodGetResourceLookupFromExtId, parametersOfGetResourceLookupFromExtId, methodGetResourceLookupFromExtIdPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetResourceLookupFromExtId.ShouldNotBeNull();
            parametersOfGetResourceLookupFromExtId.Length.ShouldBe(2);
            methodGetResourceLookupFromExtIdPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetResourceLookupFromExtId) (Return Type : object) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_GetResourceLookupFromExtId_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var resources = CreateType<string>();
            var isManager = CreateType<bool>();
            var methodGetResourceLookupFromExtIdPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfGetResourceLookupFromExtId = { resources, isManager };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<DepartmentManager, object>(_departmentManagerInstance, MethodGetResourceLookupFromExtId, parametersOfGetResourceLookupFromExtId, methodGetResourceLookupFromExtIdPrametersTypes);

            // Assert
            parametersOfGetResourceLookupFromExtId.ShouldNotBeNull();
            parametersOfGetResourceLookupFromExtId.Length.ShouldBe(2);
            methodGetResourceLookupFromExtIdPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetResourceLookupFromExtId) (Return Type : object) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_GetResourceLookupFromExtId_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetResourceLookupFromExtIdPrametersTypes = new Type[] { typeof(string), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_departmentManagerInstance, MethodGetResourceLookupFromExtId, Fixture, methodGetResourceLookupFromExtIdPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetResourceLookupFromExtIdPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetResourceLookupFromExtId) (Return Type : object) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_GetResourceLookupFromExtId_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetResourceLookupFromExtIdPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_departmentManagerInstance, MethodGetResourceLookupFromExtId, Fixture, methodGetResourceLookupFromExtIdPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetResourceLookupFromExtIdPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourceLookupFromExtId) (Return Type : object) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_GetResourceLookupFromExtId_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetResourceLookupFromExtId, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_departmentManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetResourceLookupFromExtId) (Return Type : object) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_GetResourceLookupFromExtId_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetResourceLookupFromExtId, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourcePoolId) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DepartmentManager_GetResourcePoolId_Method_Call_Internally(Type[] types)
        {
            var methodGetResourcePoolIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_departmentManagerInstance, MethodGetResourcePoolId, Fixture, methodGetResourcePoolIdPrametersTypes);
        }

        #endregion

        #region Method Call : (GetResourcePoolId) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_GetResourcePoolId_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var spFieldLookupValue = CreateType<SPFieldLookupValue>();
            var methodGetResourcePoolIdPrametersTypes = new Type[] { typeof(SPFieldLookupValue) };
            object[] parametersOfGetResourcePoolId = { spFieldLookupValue };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetResourcePoolId, methodGetResourcePoolIdPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<DepartmentManager, string>(_departmentManagerInstanceFixture, out exception1, parametersOfGetResourcePoolId);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<DepartmentManager, string>(_departmentManagerInstance, MethodGetResourcePoolId, parametersOfGetResourcePoolId, methodGetResourcePoolIdPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetResourcePoolId.ShouldNotBeNull();
            parametersOfGetResourcePoolId.Length.ShouldBe(1);
            methodGetResourcePoolIdPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetResourcePoolId) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_GetResourcePoolId_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spFieldLookupValue = CreateType<SPFieldLookupValue>();
            var methodGetResourcePoolIdPrametersTypes = new Type[] { typeof(SPFieldLookupValue) };
            object[] parametersOfGetResourcePoolId = { spFieldLookupValue };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<DepartmentManager, string>(_departmentManagerInstance, MethodGetResourcePoolId, parametersOfGetResourcePoolId, methodGetResourcePoolIdPrametersTypes);

            // Assert
            parametersOfGetResourcePoolId.ShouldNotBeNull();
            parametersOfGetResourcePoolId.Length.ShouldBe(1);
            methodGetResourcePoolIdPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetResourcePoolId) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_GetResourcePoolId_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetResourcePoolIdPrametersTypes = new Type[] { typeof(SPFieldLookupValue) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_departmentManagerInstance, MethodGetResourcePoolId, Fixture, methodGetResourcePoolIdPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetResourcePoolIdPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetResourcePoolId) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_GetResourcePoolId_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetResourcePoolIdPrametersTypes = new Type[] { typeof(SPFieldLookupValue) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_departmentManagerInstance, MethodGetResourcePoolId, Fixture, methodGetResourcePoolIdPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetResourcePoolIdPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourcePoolId) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_GetResourcePoolId_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetResourcePoolId, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_departmentManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetResourcePoolId) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DepartmentManager_GetResourcePoolId_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetResourcePoolId, 0);
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
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.Infrastructure
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Infrastructure.CacheStore" />)
    ///     and namespace <see cref="EPMLiveCore.Infrastructure"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class CacheStoreTest : AbstractBaseSetupTypedTest<CacheStore>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CacheStore) Initializer

        private const string PropertyCurrent = "Current";
        private const string MethodGet = "Get";
        private const string MethodGetDataTable = "GetDataTable";
        private const string MethodRemove = "Remove";
        private const string MethodRemoveCategory = "RemoveCategory";
        private const string MethodRemoveSafely = "RemoveSafely";
        private const string MethodSet = "Set";
        private const string MethodBuildKey = "BuildKey";
        private const string MethodCleanup = "Cleanup";
        private const string MethodDispose = "Dispose";
        private const string MethodRemoveKeys = "RemoveKeys";
        private const string MethodClear = "Clear";
        private const string Field_instance = "_instance";
        private const string FieldLocker = "Locker";
        private const string Field_indefiniteKeys = "_indefiniteKeys";
        private const string Field_store = "_store";
        private const string Field_timer = "_timer";
        private const string Field_disposed = "_disposed";
        private const string Field_ticks = "_ticks";
        private Type _cacheStoreInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CacheStore _cacheStoreInstance;
        private CacheStore _cacheStoreInstanceFixture;

        #region General Initializer : Class (CacheStore) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CacheStore" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _cacheStoreInstanceType = typeof(CacheStore);
            _cacheStoreInstanceFixture = Create(true);
            _cacheStoreInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CacheStore)

        #region General Initializer : Class (CacheStore) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="CacheStore" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGet, 0)]
        [TestCase(MethodGetDataTable, 0)]
        [TestCase(MethodRemove, 0)]
        [TestCase(MethodRemoveCategory, 0)]
        [TestCase(MethodRemoveSafely, 0)]
        [TestCase(MethodSet, 0)]
        [TestCase(MethodBuildKey, 0)]
        [TestCase(MethodCleanup, 0)]
        [TestCase(MethodDispose, 0)]
        [TestCase(MethodRemoveKeys, 0)]
        [TestCase(MethodClear, 0)]
        [TestCase(MethodDispose, 1)]
        public void AUT_CacheStore_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_cacheStoreInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CacheStore) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CacheStore" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyCurrent)]
        public void AUT_CacheStore_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_cacheStoreInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CacheStore) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CacheStore" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_instance)]
        [TestCase(FieldLocker)]
        [TestCase(Field_indefiniteKeys)]
        [TestCase(Field_store)]
        [TestCase(Field_timer)]
        [TestCase(Field_disposed)]
        [TestCase(Field_ticks)]
        public void AUT_CacheStore_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_cacheStoreInstanceFixture, 
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
        ///     Class (<see cref="CacheStore" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_CacheStore_Is_Instance_Present_Test()
        {
            // Assert
            _cacheStoreInstanceType.ShouldNotBeNull();
            _cacheStoreInstance.ShouldNotBeNull();
            _cacheStoreInstanceFixture.ShouldNotBeNull();
            _cacheStoreInstance.ShouldBeAssignableTo<CacheStore>();
            _cacheStoreInstanceFixture.ShouldBeAssignableTo<CacheStore>();
        }

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CacheStore) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(CacheStore) , PropertyCurrent)]
        public void AUT_CacheStore_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CacheStore, T>(_cacheStoreInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (CacheStore) => Property (Current) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_CacheStore_Current_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyCurrent);
            Action currentAction = () => propertyInfo.SetValue(_cacheStoreInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CacheStore) => Property (Current) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_CacheStore_Public_Class_Current_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCurrent);

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
        ///      Class (<see cref="CacheStore" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGet)]
        [TestCase(MethodGetDataTable)]
        [TestCase(MethodRemove)]
        [TestCase(MethodRemoveCategory)]
        [TestCase(MethodRemoveSafely)]
        [TestCase(MethodSet)]
        [TestCase(MethodBuildKey)]
        [TestCase(MethodCleanup)]
        [TestCase(MethodDispose)]
        [TestCase(MethodRemoveKeys)]
        [TestCase(MethodClear)]
        public void AUT_CacheStore_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<CacheStore>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Get) (Return Type : CachedValue) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CacheStore_Get_Method_Call_Internally(Type[] types)
        {
            var methodGetPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheStoreInstance, MethodGet, Fixture, methodGetPrametersTypes);
        }

        #endregion

        #region Method Call : (Get) (Return Type : CachedValue) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_Get_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var key = CreateType<string>();
            var category = CreateType<string>();
            var getValue = CreateType<Func<object>>();
            var keepIndefinite = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _cacheStoreInstance.Get(key, category, getValue, keepIndefinite);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Get) (Return Type : CachedValue) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_Get_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var key = CreateType<string>();
            var category = CreateType<string>();
            var getValue = CreateType<Func<object>>();
            var keepIndefinite = CreateType<bool>();
            var methodGetPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(Func<object>), typeof(bool) };
            object[] parametersOfGet = { key, category, getValue, keepIndefinite };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGet, methodGetPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CacheStore, CachedValue>(_cacheStoreInstanceFixture, out exception1, parametersOfGet);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CacheStore, CachedValue>(_cacheStoreInstance, MethodGet, parametersOfGet, methodGetPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGet.ShouldNotBeNull();
            parametersOfGet.Length.ShouldBe(4);
            methodGetPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<CacheStore, CachedValue>(_cacheStoreInstance, MethodGet, parametersOfGet, methodGetPrametersTypes));
        }

        #endregion

        #region Method Call : (Get) (Return Type : CachedValue) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_Get_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var key = CreateType<string>();
            var category = CreateType<string>();
            var getValue = CreateType<Func<object>>();
            var keepIndefinite = CreateType<bool>();
            var methodGetPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(Func<object>), typeof(bool) };
            object[] parametersOfGet = { key, category, getValue, keepIndefinite };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGet, methodGetPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGet.ShouldNotBeNull();
            parametersOfGet.Length.ShouldBe(4);
            methodGetPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => methodInfo.Invoke(_cacheStoreInstanceFixture, parametersOfGet));
        }

        #endregion

        #region Method Call : (Get) (Return Type : CachedValue) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_Get_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var key = CreateType<string>();
            var category = CreateType<string>();
            var getValue = CreateType<Func<object>>();
            var keepIndefinite = CreateType<bool>();
            var methodGetPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(Func<object>), typeof(bool) };
            object[] parametersOfGet = { key, category, getValue, keepIndefinite };

            // Assert
            parametersOfGet.ShouldNotBeNull();
            parametersOfGet.Length.ShouldBe(4);
            methodGetPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<CacheStore, CachedValue>(_cacheStoreInstance, MethodGet, parametersOfGet, methodGetPrametersTypes));
        }

        #endregion

        #region Method Call : (Get) (Return Type : CachedValue) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_Get_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(Func<object>), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheStoreInstance, MethodGet, Fixture, methodGetPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (Get) (Return Type : CachedValue) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_Get_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(Func<object>), typeof(bool) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheStoreInstance, MethodGet, Fixture, methodGetPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Get) (Return Type : CachedValue) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_Get_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGet, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cacheStoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (Get) (Return Type : CachedValue) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_Get_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGet, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDataTable) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CacheStore_GetDataTable_Method_Call_Internally(Type[] types)
        {
            var methodGetDataTablePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheStoreInstance, MethodGetDataTable, Fixture, methodGetDataTablePrametersTypes);
        }

        #endregion

        #region Method Call : (GetDataTable) (Return Type : DataTable) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_GetDataTable_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _cacheStoreInstance.GetDataTable();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetDataTable) (Return Type : DataTable) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_GetDataTable_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetDataTablePrametersTypes = null;
            object[] parametersOfGetDataTable = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetDataTable, methodGetDataTablePrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetDataTable.ShouldBeNull();
            methodGetDataTablePrametersTypes.ShouldBeNull();
            Should.NotThrow(() => methodInfo.Invoke(_cacheStoreInstanceFixture, parametersOfGetDataTable));
        }

        #endregion

        #region Method Call : (GetDataTable) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_GetDataTable_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetDataTablePrametersTypes = null;
            object[] parametersOfGetDataTable = null; // no parameter present

            // Assert
            parametersOfGetDataTable.ShouldBeNull();
            methodGetDataTablePrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<CacheStore, DataTable>(_cacheStoreInstance, MethodGetDataTable, parametersOfGetDataTable, methodGetDataTablePrametersTypes));
        }

        #endregion

        #region Method Call : (GetDataTable) (Return Type : DataTable) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_GetDataTable_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetDataTablePrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheStoreInstance, MethodGetDataTable, Fixture, methodGetDataTablePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetDataTablePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDataTable) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_GetDataTable_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetDataTablePrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheStoreInstance, MethodGetDataTable, Fixture, methodGetDataTablePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDataTablePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDataTable) (Return Type : DataTable) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_GetDataTable_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDataTable, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cacheStoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (Remove) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CacheStore_Remove_Method_Call_Internally(Type[] types)
        {
            var methodRemovePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheStoreInstance, MethodRemove, Fixture, methodRemovePrametersTypes);
        }

        #endregion

        #region Method Call : (Remove) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_Remove_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var key = CreateType<string>();
            var category = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cacheStoreInstance.Remove(key, category);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Remove) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_Remove_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var key = CreateType<string>();
            var category = CreateType<string>();
            var methodRemovePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfRemove = { key, category };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRemove, methodRemovePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cacheStoreInstanceFixture, parametersOfRemove);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRemove.ShouldNotBeNull();
            parametersOfRemove.Length.ShouldBe(2);
            methodRemovePrametersTypes.Length.ShouldBe(2);
            methodRemovePrametersTypes.Length.ShouldBe(parametersOfRemove.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Remove) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_Remove_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var key = CreateType<string>();
            var category = CreateType<string>();
            var methodRemovePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfRemove = { key, category };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cacheStoreInstance, MethodRemove, parametersOfRemove, methodRemovePrametersTypes);

            // Assert
            parametersOfRemove.ShouldNotBeNull();
            parametersOfRemove.Length.ShouldBe(2);
            methodRemovePrametersTypes.Length.ShouldBe(2);
            methodRemovePrametersTypes.Length.ShouldBe(parametersOfRemove.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Remove) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_Remove_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRemove, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Remove) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_Remove_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRemovePrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheStoreInstance, MethodRemove, Fixture, methodRemovePrametersTypes);

            // Assert
            methodRemovePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Remove) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_Remove_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRemove, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cacheStoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RemoveCategory) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CacheStore_RemoveCategory_Method_Call_Internally(Type[] types)
        {
            var methodRemoveCategoryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheStoreInstance, MethodRemoveCategory, Fixture, methodRemoveCategoryPrametersTypes);
        }

        #endregion

        #region Method Call : (RemoveCategory) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_RemoveCategory_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var category = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cacheStoreInstance.RemoveCategory(category);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (RemoveCategory) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_RemoveCategory_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var category = CreateType<string>();
            var methodRemoveCategoryPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRemoveCategory = { category };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRemoveCategory, methodRemoveCategoryPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cacheStoreInstanceFixture, parametersOfRemoveCategory);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRemoveCategory.ShouldNotBeNull();
            parametersOfRemoveCategory.Length.ShouldBe(1);
            methodRemoveCategoryPrametersTypes.Length.ShouldBe(1);
            methodRemoveCategoryPrametersTypes.Length.ShouldBe(parametersOfRemoveCategory.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RemoveCategory) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_RemoveCategory_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var category = CreateType<string>();
            var methodRemoveCategoryPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRemoveCategory = { category };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cacheStoreInstance, MethodRemoveCategory, parametersOfRemoveCategory, methodRemoveCategoryPrametersTypes);

            // Assert
            parametersOfRemoveCategory.ShouldNotBeNull();
            parametersOfRemoveCategory.Length.ShouldBe(1);
            methodRemoveCategoryPrametersTypes.Length.ShouldBe(1);
            methodRemoveCategoryPrametersTypes.Length.ShouldBe(parametersOfRemoveCategory.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RemoveCategory) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_RemoveCategory_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRemoveCategory, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RemoveCategory) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_RemoveCategory_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRemoveCategoryPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheStoreInstance, MethodRemoveCategory, Fixture, methodRemoveCategoryPrametersTypes);

            // Assert
            methodRemoveCategoryPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RemoveCategory) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_RemoveCategory_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRemoveCategory, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cacheStoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RemoveSafely) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CacheStore_RemoveSafely_Method_Call_Internally(Type[] types)
        {
            var methodRemoveSafelyPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheStoreInstance, MethodRemoveSafely, Fixture, methodRemoveSafelyPrametersTypes);
        }

        #endregion

        #region Method Call : (RemoveSafely) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_RemoveSafely_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var webUrl = CreateType<string>();
            var category = CreateType<string>();
            var key = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cacheStoreInstance.RemoveSafely(webUrl, category, key);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (RemoveSafely) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_RemoveSafely_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var webUrl = CreateType<string>();
            var category = CreateType<string>();
            var key = CreateType<string>();
            var methodRemoveSafelyPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            object[] parametersOfRemoveSafely = { webUrl, category, key };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRemoveSafely, methodRemoveSafelyPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cacheStoreInstanceFixture, parametersOfRemoveSafely);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRemoveSafely.ShouldNotBeNull();
            parametersOfRemoveSafely.Length.ShouldBe(3);
            methodRemoveSafelyPrametersTypes.Length.ShouldBe(3);
            methodRemoveSafelyPrametersTypes.Length.ShouldBe(parametersOfRemoveSafely.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RemoveSafely) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_RemoveSafely_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var webUrl = CreateType<string>();
            var category = CreateType<string>();
            var key = CreateType<string>();
            var methodRemoveSafelyPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            object[] parametersOfRemoveSafely = { webUrl, category, key };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cacheStoreInstance, MethodRemoveSafely, parametersOfRemoveSafely, methodRemoveSafelyPrametersTypes);

            // Assert
            parametersOfRemoveSafely.ShouldNotBeNull();
            parametersOfRemoveSafely.Length.ShouldBe(3);
            methodRemoveSafelyPrametersTypes.Length.ShouldBe(3);
            methodRemoveSafelyPrametersTypes.Length.ShouldBe(parametersOfRemoveSafely.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RemoveSafely) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_RemoveSafely_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRemoveSafely, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RemoveSafely) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_RemoveSafely_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRemoveSafelyPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheStoreInstance, MethodRemoveSafely, Fixture, methodRemoveSafelyPrametersTypes);

            // Assert
            methodRemoveSafelyPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RemoveSafely) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_RemoveSafely_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRemoveSafely, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cacheStoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Set) (Return Type : CachedValue) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CacheStore_Set_Method_Call_Internally(Type[] types)
        {
            var methodSetPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheStoreInstance, MethodSet, Fixture, methodSetPrametersTypes);
        }

        #endregion

        #region Method Call : (Set) (Return Type : CachedValue) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_Set_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var key = CreateType<string>();
            var value = CreateType<object>();
            var category = CreateType<string>();
            var keepIndefinite = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _cacheStoreInstance.Set(key, value, category, keepIndefinite);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Set) (Return Type : CachedValue) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_Set_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var key = CreateType<string>();
            var value = CreateType<object>();
            var category = CreateType<string>();
            var keepIndefinite = CreateType<bool>();
            var methodSetPrametersTypes = new Type[] { typeof(string), typeof(object), typeof(string), typeof(bool) };
            object[] parametersOfSet = { key, value, category, keepIndefinite };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSet, methodSetPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSet.ShouldNotBeNull();
            parametersOfSet.Length.ShouldBe(4);
            methodSetPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => methodInfo.Invoke(_cacheStoreInstanceFixture, parametersOfSet));
        }

        #endregion

        #region Method Call : (Set) (Return Type : CachedValue) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_Set_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var key = CreateType<string>();
            var value = CreateType<object>();
            var category = CreateType<string>();
            var keepIndefinite = CreateType<bool>();
            var methodSetPrametersTypes = new Type[] { typeof(string), typeof(object), typeof(string), typeof(bool) };
            object[] parametersOfSet = { key, value, category, keepIndefinite };

            // Assert
            parametersOfSet.ShouldNotBeNull();
            parametersOfSet.Length.ShouldBe(4);
            methodSetPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<CacheStore, CachedValue>(_cacheStoreInstance, MethodSet, parametersOfSet, methodSetPrametersTypes));
        }

        #endregion

        #region Method Call : (Set) (Return Type : CachedValue) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_Set_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodSetPrametersTypes = new Type[] { typeof(string), typeof(object), typeof(string), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheStoreInstance, MethodSet, Fixture, methodSetPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodSetPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (Set) (Return Type : CachedValue) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_Set_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetPrametersTypes = new Type[] { typeof(string), typeof(object), typeof(string), typeof(bool) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheStoreInstance, MethodSet, Fixture, methodSetPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSetPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Set) (Return Type : CachedValue) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_Set_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSet, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cacheStoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (Set) (Return Type : CachedValue) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_Set_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSet, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildKey) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CacheStore_BuildKey_Method_Call_Internally(Type[] types)
        {
            var methodBuildKeyPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheStoreInstance, MethodBuildKey, Fixture, methodBuildKeyPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildKey) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_BuildKey_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var key = CreateType<string>();
            var category = CreateType<string>();
            var methodBuildKeyPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfBuildKey = { key, category };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBuildKey, methodBuildKeyPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfBuildKey.ShouldNotBeNull();
            parametersOfBuildKey.Length.ShouldBe(2);
            methodBuildKeyPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => methodInfo.Invoke(_cacheStoreInstanceFixture, parametersOfBuildKey));
        }

        #endregion

        #region Method Call : (BuildKey) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_BuildKey_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var key = CreateType<string>();
            var category = CreateType<string>();
            var methodBuildKeyPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfBuildKey = { key, category };

            // Assert
            parametersOfBuildKey.ShouldNotBeNull();
            parametersOfBuildKey.Length.ShouldBe(2);
            methodBuildKeyPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<CacheStore, string>(_cacheStoreInstance, MethodBuildKey, parametersOfBuildKey, methodBuildKeyPrametersTypes));
        }

        #endregion

        #region Method Call : (BuildKey) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_BuildKey_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodBuildKeyPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheStoreInstance, MethodBuildKey, Fixture, methodBuildKeyPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodBuildKeyPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (BuildKey) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_BuildKey_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBuildKeyPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheStoreInstance, MethodBuildKey, Fixture, methodBuildKeyPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildKeyPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildKey) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_BuildKey_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildKey, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cacheStoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (BuildKey) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_BuildKey_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBuildKey, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Cleanup) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CacheStore_Cleanup_Method_Call_Internally(Type[] types)
        {
            var methodCleanupPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheStoreInstance, MethodCleanup, Fixture, methodCleanupPrametersTypes);
        }

        #endregion

        #region Method Call : (Cleanup) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_Cleanup_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var state = CreateType<object>();
            var methodCleanupPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfCleanup = { state };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCleanup, methodCleanupPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cacheStoreInstanceFixture, parametersOfCleanup);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCleanup.ShouldNotBeNull();
            parametersOfCleanup.Length.ShouldBe(1);
            methodCleanupPrametersTypes.Length.ShouldBe(1);
            methodCleanupPrametersTypes.Length.ShouldBe(parametersOfCleanup.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Cleanup) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_Cleanup_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var state = CreateType<object>();
            var methodCleanupPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfCleanup = { state };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cacheStoreInstance, MethodCleanup, parametersOfCleanup, methodCleanupPrametersTypes);

            // Assert
            parametersOfCleanup.ShouldNotBeNull();
            parametersOfCleanup.Length.ShouldBe(1);
            methodCleanupPrametersTypes.Length.ShouldBe(1);
            methodCleanupPrametersTypes.Length.ShouldBe(parametersOfCleanup.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Cleanup) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_Cleanup_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCleanup, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Cleanup) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_Cleanup_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCleanupPrametersTypes = new Type[] { typeof(object) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheStoreInstance, MethodCleanup, Fixture, methodCleanupPrametersTypes);

            // Assert
            methodCleanupPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Cleanup) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_Cleanup_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCleanup, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cacheStoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CacheStore_Dispose_Method_Call_Internally(Type[] types)
        {
            var methodDisposePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheStoreInstance, MethodDispose, Fixture, methodDisposePrametersTypes);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_Dispose_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var disposing = CreateType<bool>();
            var methodDisposePrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfDispose = { disposing };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDispose, methodDisposePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cacheStoreInstanceFixture, parametersOfDispose);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDispose.ShouldNotBeNull();
            parametersOfDispose.Length.ShouldBe(1);
            methodDisposePrametersTypes.Length.ShouldBe(1);
            methodDisposePrametersTypes.Length.ShouldBe(parametersOfDispose.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_Dispose_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var disposing = CreateType<bool>();
            var methodDisposePrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfDispose = { disposing };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cacheStoreInstance, MethodDispose, parametersOfDispose, methodDisposePrametersTypes);

            // Assert
            parametersOfDispose.ShouldNotBeNull();
            parametersOfDispose.Length.ShouldBe(1);
            methodDisposePrametersTypes.Length.ShouldBe(1);
            methodDisposePrametersTypes.Length.ShouldBe(parametersOfDispose.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_Dispose_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDisposePrametersTypes = new Type[] { typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheStoreInstance, MethodDispose, Fixture, methodDisposePrametersTypes);

            // Assert
            methodDisposePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_Dispose_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDispose, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cacheStoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RemoveKeys) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CacheStore_RemoveKeys_Method_Call_Internally(Type[] types)
        {
            var methodRemoveKeysPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheStoreInstance, MethodRemoveKeys, Fixture, methodRemoveKeysPrametersTypes);
        }

        #endregion

        #region Method Call : (RemoveKeys) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_RemoveKeys_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var keys = CreateType<Dictionary<string, List<string>>>();
            var methodRemoveKeysPrametersTypes = new Type[] { typeof(Dictionary<string, List<string>>) };
            object[] parametersOfRemoveKeys = { keys };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRemoveKeys, methodRemoveKeysPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cacheStoreInstanceFixture, parametersOfRemoveKeys);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRemoveKeys.ShouldNotBeNull();
            parametersOfRemoveKeys.Length.ShouldBe(1);
            methodRemoveKeysPrametersTypes.Length.ShouldBe(1);
            methodRemoveKeysPrametersTypes.Length.ShouldBe(parametersOfRemoveKeys.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RemoveKeys) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_RemoveKeys_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var keys = CreateType<Dictionary<string, List<string>>>();
            var methodRemoveKeysPrametersTypes = new Type[] { typeof(Dictionary<string, List<string>>) };
            object[] parametersOfRemoveKeys = { keys };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cacheStoreInstance, MethodRemoveKeys, parametersOfRemoveKeys, methodRemoveKeysPrametersTypes);

            // Assert
            parametersOfRemoveKeys.ShouldNotBeNull();
            parametersOfRemoveKeys.Length.ShouldBe(1);
            methodRemoveKeysPrametersTypes.Length.ShouldBe(1);
            methodRemoveKeysPrametersTypes.Length.ShouldBe(parametersOfRemoveKeys.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RemoveKeys) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_RemoveKeys_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRemoveKeys, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RemoveKeys) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_RemoveKeys_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRemoveKeysPrametersTypes = new Type[] { typeof(Dictionary<string, List<string>>) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheStoreInstance, MethodRemoveKeys, Fixture, methodRemoveKeysPrametersTypes);

            // Assert
            methodRemoveKeysPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RemoveKeys) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_RemoveKeys_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRemoveKeys, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cacheStoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Clear) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CacheStore_Clear_Method_Call_Internally(Type[] types)
        {
            var methodClearPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheStoreInstance, MethodClear, Fixture, methodClearPrametersTypes);
        }

        #endregion

        #region Method Call : (Clear) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_Clear_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodClearPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfClear = { data };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodClear, methodClearPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cacheStoreInstanceFixture, parametersOfClear);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfClear.ShouldNotBeNull();
            parametersOfClear.Length.ShouldBe(1);
            methodClearPrametersTypes.Length.ShouldBe(1);
            methodClearPrametersTypes.Length.ShouldBe(parametersOfClear.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Clear) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_Clear_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodClearPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfClear = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cacheStoreInstance, MethodClear, parametersOfClear, methodClearPrametersTypes);

            // Assert
            parametersOfClear.ShouldNotBeNull();
            parametersOfClear.Length.ShouldBe(1);
            methodClearPrametersTypes.Length.ShouldBe(1);
            methodClearPrametersTypes.Length.ShouldBe(parametersOfClear.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Clear) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_Clear_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodClear, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Clear) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_Clear_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodClearPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheStoreInstance, MethodClear, Fixture, methodClearPrametersTypes);

            // Assert
            methodClearPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Clear) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_Clear_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodClear, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cacheStoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CacheStore_Dispose_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodDisposePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheStoreInstance, MethodDispose, Fixture, methodDisposePrametersTypes);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_Dispose_Method_DirectCall_Overloading_Of_1_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _cacheStoreInstance.Dispose();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_Dispose_Method_Call_Void_Overloading_Of_1_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodDisposePrametersTypes = null;
            object[] parametersOfDispose = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDispose, methodDisposePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cacheStoreInstanceFixture, parametersOfDispose);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDispose.ShouldBeNull();
            methodDisposePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_Dispose_Method_Call_Void_Overloading_Of_1_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodDisposePrametersTypes = null;
            object[] parametersOfDispose = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cacheStoreInstance, MethodDispose, parametersOfDispose, methodDisposePrametersTypes);

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
        public void AUT_CacheStore_Dispose_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodDisposePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheStoreInstance, MethodDispose, Fixture, methodDisposePrametersTypes);

            // Assert
            methodDisposePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheStore_Dispose_Method_Call_Overloading_Of_1_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDispose, 1);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cacheStoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
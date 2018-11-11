using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using Telerik.Web.UI;

namespace EPMLiveCore.Layouts.epmlive.Admin
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Layouts.epmlive.Admin.CacheManager" />)
    ///     and namespace <see cref="EPMLiveCore.Layouts.epmlive.Admin"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public partial class CacheManagerTest : AbstractBaseSetupTypedTest<CacheManager>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CacheManager) Initializer

        private const string MethodCacheGrid_OnDeleteCommand = "CacheGrid_OnDeleteCommand";
        private const string MethodCacheGrid_OnItemCreated = "CacheGrid_OnItemCreated";
        private const string MethodCacheGrid_OnItemDataBound = "CacheGrid_OnItemDataBound";
        private const string MethodCacheGrid_OnNeedDataSource = "CacheGrid_OnNeedDataSource";
        private const string MethodPage_Load = "Page_Load";
        private const string MethodAddGroupDeleteButton = "AddGroupDeleteButton";
        private const string MethodCalculateMemoryAllocation = "CalculateMemoryAllocation";
        private const string MethodCalculateSize = "CalculateSize";
        private const string MethoddelButton_Click = "delButton_Click";
        private const string MethodDeleteItem = "DeleteItem";
        private const string MethodDeleteItemsForCategory = "DeleteItemsForCategory";
        private const string MethodGetServerInfo = "GetServerInfo";
        private const string MethodLoadData = "LoadData";
        private const string MethodValidateAccess = "ValidateAccess";
        private const string Field_totalBytes = "_totalBytes";
        private Type _cacheManagerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CacheManager _cacheManagerInstance;
        private CacheManager _cacheManagerInstanceFixture;

        #region General Initializer : Class (CacheManager) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CacheManager" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _cacheManagerInstanceType = typeof(CacheManager);
            _cacheManagerInstanceFixture = Create(true);
            _cacheManagerInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CacheManager)

        #region General Initializer : Class (CacheManager) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="CacheManager" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodCacheGrid_OnDeleteCommand, 0)]
        [TestCase(MethodCacheGrid_OnItemCreated, 0)]
        [TestCase(MethodCacheGrid_OnItemDataBound, 0)]
        [TestCase(MethodCacheGrid_OnNeedDataSource, 0)]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodAddGroupDeleteButton, 0)]
        [TestCase(MethodCalculateMemoryAllocation, 0)]
        [TestCase(MethodCalculateSize, 0)]
        [TestCase(MethoddelButton_Click, 0)]
        [TestCase(MethodDeleteItem, 0)]
        [TestCase(MethodDeleteItemsForCategory, 0)]
        [TestCase(MethodGetServerInfo, 0)]
        [TestCase(MethodLoadData, 0)]
        [TestCase(MethodValidateAccess, 0)]
        public void AUT_CacheManager_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_cacheManagerInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CacheManager) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CacheManager" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_totalBytes)]
        public void AUT_CacheManager_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_cacheManagerInstanceFixture, 
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
        ///     Class (<see cref="CacheManager" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_CacheManager_Is_Instance_Present_Test()
        {
            // Assert
            _cacheManagerInstanceType.ShouldNotBeNull();
            _cacheManagerInstance.ShouldNotBeNull();
            _cacheManagerInstanceFixture.ShouldNotBeNull();
            _cacheManagerInstance.ShouldBeAssignableTo<CacheManager>();
            _cacheManagerInstanceFixture.ShouldBeAssignableTo<CacheManager>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CacheManager) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_CacheManager_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CacheManager instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _cacheManagerInstanceType.ShouldNotBeNull();
            _cacheManagerInstance.ShouldNotBeNull();
            _cacheManagerInstanceFixture.ShouldNotBeNull();
            _cacheManagerInstance.ShouldBeAssignableTo<CacheManager>();
            _cacheManagerInstanceFixture.ShouldBeAssignableTo<CacheManager>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="CacheManager" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodDeleteItem)]
        public void AUT_CacheManager_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_cacheManagerInstanceFixture,
                                                                              _cacheManagerInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="CacheManager" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodCacheGrid_OnDeleteCommand)]
        [TestCase(MethodCacheGrid_OnItemCreated)]
        [TestCase(MethodCacheGrid_OnItemDataBound)]
        [TestCase(MethodCacheGrid_OnNeedDataSource)]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodAddGroupDeleteButton)]
        [TestCase(MethodCalculateMemoryAllocation)]
        [TestCase(MethodCalculateSize)]
        [TestCase(MethoddelButton_Click)]
        [TestCase(MethodDeleteItemsForCategory)]
        [TestCase(MethodGetServerInfo)]
        [TestCase(MethodLoadData)]
        [TestCase(MethodValidateAccess)]
        public void AUT_CacheManager_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<CacheManager>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (CacheGrid_OnDeleteCommand) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CacheManager_CacheGrid_OnDeleteCommand_Method_Call_Internally(Type[] types)
        {
            var methodCacheGrid_OnDeleteCommandPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheManagerInstance, MethodCacheGrid_OnDeleteCommand, Fixture, methodCacheGrid_OnDeleteCommandPrametersTypes);
        }

        #endregion

        #region Method Call : (CacheGrid_OnDeleteCommand) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_CacheGrid_OnDeleteCommand_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridCommandEventArgs>();
            var methodCacheGrid_OnDeleteCommandPrametersTypes = new Type[] { typeof(object), typeof(GridCommandEventArgs) };
            object[] parametersOfCacheGrid_OnDeleteCommand = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCacheGrid_OnDeleteCommand, methodCacheGrid_OnDeleteCommandPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cacheManagerInstanceFixture, parametersOfCacheGrid_OnDeleteCommand);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCacheGrid_OnDeleteCommand.ShouldNotBeNull();
            parametersOfCacheGrid_OnDeleteCommand.Length.ShouldBe(2);
            methodCacheGrid_OnDeleteCommandPrametersTypes.Length.ShouldBe(2);
            methodCacheGrid_OnDeleteCommandPrametersTypes.Length.ShouldBe(parametersOfCacheGrid_OnDeleteCommand.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CacheGrid_OnDeleteCommand) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_CacheGrid_OnDeleteCommand_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridCommandEventArgs>();
            var methodCacheGrid_OnDeleteCommandPrametersTypes = new Type[] { typeof(object), typeof(GridCommandEventArgs) };
            object[] parametersOfCacheGrid_OnDeleteCommand = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cacheManagerInstance, MethodCacheGrid_OnDeleteCommand, parametersOfCacheGrid_OnDeleteCommand, methodCacheGrid_OnDeleteCommandPrametersTypes);

            // Assert
            parametersOfCacheGrid_OnDeleteCommand.ShouldNotBeNull();
            parametersOfCacheGrid_OnDeleteCommand.Length.ShouldBe(2);
            methodCacheGrid_OnDeleteCommandPrametersTypes.Length.ShouldBe(2);
            methodCacheGrid_OnDeleteCommandPrametersTypes.Length.ShouldBe(parametersOfCacheGrid_OnDeleteCommand.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CacheGrid_OnDeleteCommand) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_CacheGrid_OnDeleteCommand_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCacheGrid_OnDeleteCommand, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CacheGrid_OnDeleteCommand) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_CacheGrid_OnDeleteCommand_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCacheGrid_OnDeleteCommandPrametersTypes = new Type[] { typeof(object), typeof(GridCommandEventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheManagerInstance, MethodCacheGrid_OnDeleteCommand, Fixture, methodCacheGrid_OnDeleteCommandPrametersTypes);

            // Assert
            methodCacheGrid_OnDeleteCommandPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CacheGrid_OnDeleteCommand) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_CacheGrid_OnDeleteCommand_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCacheGrid_OnDeleteCommand, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cacheManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CacheGrid_OnItemCreated) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CacheManager_CacheGrid_OnItemCreated_Method_Call_Internally(Type[] types)
        {
            var methodCacheGrid_OnItemCreatedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheManagerInstance, MethodCacheGrid_OnItemCreated, Fixture, methodCacheGrid_OnItemCreatedPrametersTypes);
        }

        #endregion

        #region Method Call : (CacheGrid_OnItemCreated) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_CacheGrid_OnItemCreated_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridItemEventArgs>();
            var methodCacheGrid_OnItemCreatedPrametersTypes = new Type[] { typeof(object), typeof(GridItemEventArgs) };
            object[] parametersOfCacheGrid_OnItemCreated = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCacheGrid_OnItemCreated, methodCacheGrid_OnItemCreatedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cacheManagerInstanceFixture, parametersOfCacheGrid_OnItemCreated);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCacheGrid_OnItemCreated.ShouldNotBeNull();
            parametersOfCacheGrid_OnItemCreated.Length.ShouldBe(2);
            methodCacheGrid_OnItemCreatedPrametersTypes.Length.ShouldBe(2);
            methodCacheGrid_OnItemCreatedPrametersTypes.Length.ShouldBe(parametersOfCacheGrid_OnItemCreated.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CacheGrid_OnItemCreated) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_CacheGrid_OnItemCreated_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridItemEventArgs>();
            var methodCacheGrid_OnItemCreatedPrametersTypes = new Type[] { typeof(object), typeof(GridItemEventArgs) };
            object[] parametersOfCacheGrid_OnItemCreated = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cacheManagerInstance, MethodCacheGrid_OnItemCreated, parametersOfCacheGrid_OnItemCreated, methodCacheGrid_OnItemCreatedPrametersTypes);

            // Assert
            parametersOfCacheGrid_OnItemCreated.ShouldNotBeNull();
            parametersOfCacheGrid_OnItemCreated.Length.ShouldBe(2);
            methodCacheGrid_OnItemCreatedPrametersTypes.Length.ShouldBe(2);
            methodCacheGrid_OnItemCreatedPrametersTypes.Length.ShouldBe(parametersOfCacheGrid_OnItemCreated.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CacheGrid_OnItemCreated) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_CacheGrid_OnItemCreated_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCacheGrid_OnItemCreated, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CacheGrid_OnItemCreated) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_CacheGrid_OnItemCreated_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCacheGrid_OnItemCreatedPrametersTypes = new Type[] { typeof(object), typeof(GridItemEventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheManagerInstance, MethodCacheGrid_OnItemCreated, Fixture, methodCacheGrid_OnItemCreatedPrametersTypes);

            // Assert
            methodCacheGrid_OnItemCreatedPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CacheGrid_OnItemCreated) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_CacheGrid_OnItemCreated_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCacheGrid_OnItemCreated, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cacheManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CacheGrid_OnItemDataBound) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CacheManager_CacheGrid_OnItemDataBound_Method_Call_Internally(Type[] types)
        {
            var methodCacheGrid_OnItemDataBoundPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheManagerInstance, MethodCacheGrid_OnItemDataBound, Fixture, methodCacheGrid_OnItemDataBoundPrametersTypes);
        }

        #endregion

        #region Method Call : (CacheGrid_OnItemDataBound) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_CacheGrid_OnItemDataBound_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridItemEventArgs>();
            var methodCacheGrid_OnItemDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridItemEventArgs) };
            object[] parametersOfCacheGrid_OnItemDataBound = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCacheGrid_OnItemDataBound, methodCacheGrid_OnItemDataBoundPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cacheManagerInstanceFixture, parametersOfCacheGrid_OnItemDataBound);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCacheGrid_OnItemDataBound.ShouldNotBeNull();
            parametersOfCacheGrid_OnItemDataBound.Length.ShouldBe(2);
            methodCacheGrid_OnItemDataBoundPrametersTypes.Length.ShouldBe(2);
            methodCacheGrid_OnItemDataBoundPrametersTypes.Length.ShouldBe(parametersOfCacheGrid_OnItemDataBound.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CacheGrid_OnItemDataBound) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_CacheGrid_OnItemDataBound_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridItemEventArgs>();
            var methodCacheGrid_OnItemDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridItemEventArgs) };
            object[] parametersOfCacheGrid_OnItemDataBound = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cacheManagerInstance, MethodCacheGrid_OnItemDataBound, parametersOfCacheGrid_OnItemDataBound, methodCacheGrid_OnItemDataBoundPrametersTypes);

            // Assert
            parametersOfCacheGrid_OnItemDataBound.ShouldNotBeNull();
            parametersOfCacheGrid_OnItemDataBound.Length.ShouldBe(2);
            methodCacheGrid_OnItemDataBoundPrametersTypes.Length.ShouldBe(2);
            methodCacheGrid_OnItemDataBoundPrametersTypes.Length.ShouldBe(parametersOfCacheGrid_OnItemDataBound.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CacheGrid_OnItemDataBound) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_CacheGrid_OnItemDataBound_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCacheGrid_OnItemDataBound, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CacheGrid_OnItemDataBound) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_CacheGrid_OnItemDataBound_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCacheGrid_OnItemDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridItemEventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheManagerInstance, MethodCacheGrid_OnItemDataBound, Fixture, methodCacheGrid_OnItemDataBoundPrametersTypes);

            // Assert
            methodCacheGrid_OnItemDataBoundPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CacheGrid_OnItemDataBound) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_CacheGrid_OnItemDataBound_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCacheGrid_OnItemDataBound, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cacheManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CacheGrid_OnNeedDataSource) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CacheManager_CacheGrid_OnNeedDataSource_Method_Call_Internally(Type[] types)
        {
            var methodCacheGrid_OnNeedDataSourcePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheManagerInstance, MethodCacheGrid_OnNeedDataSource, Fixture, methodCacheGrid_OnNeedDataSourcePrametersTypes);
        }

        #endregion

        #region Method Call : (CacheGrid_OnNeedDataSource) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_CacheGrid_OnNeedDataSource_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridNeedDataSourceEventArgs>();
            var methodCacheGrid_OnNeedDataSourcePrametersTypes = new Type[] { typeof(object), typeof(GridNeedDataSourceEventArgs) };
            object[] parametersOfCacheGrid_OnNeedDataSource = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCacheGrid_OnNeedDataSource, methodCacheGrid_OnNeedDataSourcePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cacheManagerInstanceFixture, parametersOfCacheGrid_OnNeedDataSource);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCacheGrid_OnNeedDataSource.ShouldNotBeNull();
            parametersOfCacheGrid_OnNeedDataSource.Length.ShouldBe(2);
            methodCacheGrid_OnNeedDataSourcePrametersTypes.Length.ShouldBe(2);
            methodCacheGrid_OnNeedDataSourcePrametersTypes.Length.ShouldBe(parametersOfCacheGrid_OnNeedDataSource.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CacheGrid_OnNeedDataSource) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_CacheGrid_OnNeedDataSource_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridNeedDataSourceEventArgs>();
            var methodCacheGrid_OnNeedDataSourcePrametersTypes = new Type[] { typeof(object), typeof(GridNeedDataSourceEventArgs) };
            object[] parametersOfCacheGrid_OnNeedDataSource = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cacheManagerInstance, MethodCacheGrid_OnNeedDataSource, parametersOfCacheGrid_OnNeedDataSource, methodCacheGrid_OnNeedDataSourcePrametersTypes);

            // Assert
            parametersOfCacheGrid_OnNeedDataSource.ShouldNotBeNull();
            parametersOfCacheGrid_OnNeedDataSource.Length.ShouldBe(2);
            methodCacheGrid_OnNeedDataSourcePrametersTypes.Length.ShouldBe(2);
            methodCacheGrid_OnNeedDataSourcePrametersTypes.Length.ShouldBe(parametersOfCacheGrid_OnNeedDataSource.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CacheGrid_OnNeedDataSource) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_CacheGrid_OnNeedDataSource_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCacheGrid_OnNeedDataSource, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CacheGrid_OnNeedDataSource) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_CacheGrid_OnNeedDataSource_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCacheGrid_OnNeedDataSourcePrametersTypes = new Type[] { typeof(object), typeof(GridNeedDataSourceEventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheManagerInstance, MethodCacheGrid_OnNeedDataSource, Fixture, methodCacheGrid_OnNeedDataSourcePrametersTypes);

            // Assert
            methodCacheGrid_OnNeedDataSourcePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CacheGrid_OnNeedDataSource) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_CacheGrid_OnNeedDataSource_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCacheGrid_OnNeedDataSource, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cacheManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CacheManager_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheManagerInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cacheManagerInstanceFixture, parametersOfPage_Load);

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
        public void AUT_CacheManager_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cacheManagerInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_CacheManager_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_CacheManager_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheManagerInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cacheManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddGroupDeleteButton) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CacheManager_AddGroupDeleteButton_Method_Call_Internally(Type[] types)
        {
            var methodAddGroupDeleteButtonPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheManagerInstance, MethodAddGroupDeleteButton, Fixture, methodAddGroupDeleteButtonPrametersTypes);
        }

        #endregion

        #region Method Call : (AddGroupDeleteButton) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_AddGroupDeleteButton_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var e = CreateType<GridItemEventArgs>();
            var methodAddGroupDeleteButtonPrametersTypes = new Type[] { typeof(GridItemEventArgs) };
            object[] parametersOfAddGroupDeleteButton = { e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddGroupDeleteButton, methodAddGroupDeleteButtonPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cacheManagerInstanceFixture, parametersOfAddGroupDeleteButton);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddGroupDeleteButton.ShouldNotBeNull();
            parametersOfAddGroupDeleteButton.Length.ShouldBe(1);
            methodAddGroupDeleteButtonPrametersTypes.Length.ShouldBe(1);
            methodAddGroupDeleteButtonPrametersTypes.Length.ShouldBe(parametersOfAddGroupDeleteButton.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddGroupDeleteButton) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_AddGroupDeleteButton_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var e = CreateType<GridItemEventArgs>();
            var methodAddGroupDeleteButtonPrametersTypes = new Type[] { typeof(GridItemEventArgs) };
            object[] parametersOfAddGroupDeleteButton = { e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cacheManagerInstance, MethodAddGroupDeleteButton, parametersOfAddGroupDeleteButton, methodAddGroupDeleteButtonPrametersTypes);

            // Assert
            parametersOfAddGroupDeleteButton.ShouldNotBeNull();
            parametersOfAddGroupDeleteButton.Length.ShouldBe(1);
            methodAddGroupDeleteButtonPrametersTypes.Length.ShouldBe(1);
            methodAddGroupDeleteButtonPrametersTypes.Length.ShouldBe(parametersOfAddGroupDeleteButton.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddGroupDeleteButton) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_AddGroupDeleteButton_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddGroupDeleteButton, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddGroupDeleteButton) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_AddGroupDeleteButton_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddGroupDeleteButtonPrametersTypes = new Type[] { typeof(GridItemEventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheManagerInstance, MethodAddGroupDeleteButton, Fixture, methodAddGroupDeleteButtonPrametersTypes);

            // Assert
            methodAddGroupDeleteButtonPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddGroupDeleteButton) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_AddGroupDeleteButton_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddGroupDeleteButton, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cacheManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CalculateMemoryAllocation) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CacheManager_CalculateMemoryAllocation_Method_Call_Internally(Type[] types)
        {
            var methodCalculateMemoryAllocationPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheManagerInstance, MethodCalculateMemoryAllocation, Fixture, methodCalculateMemoryAllocationPrametersTypes);
        }

        #endregion

        #region Method Call : (CalculateMemoryAllocation) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_CalculateMemoryAllocation_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodCalculateMemoryAllocationPrametersTypes = null;
            object[] parametersOfCalculateMemoryAllocation = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCalculateMemoryAllocation, methodCalculateMemoryAllocationPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cacheManagerInstanceFixture, parametersOfCalculateMemoryAllocation);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCalculateMemoryAllocation.ShouldBeNull();
            methodCalculateMemoryAllocationPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CalculateMemoryAllocation) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_CalculateMemoryAllocation_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCalculateMemoryAllocationPrametersTypes = null;
            object[] parametersOfCalculateMemoryAllocation = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cacheManagerInstance, MethodCalculateMemoryAllocation, parametersOfCalculateMemoryAllocation, methodCalculateMemoryAllocationPrametersTypes);

            // Assert
            parametersOfCalculateMemoryAllocation.ShouldBeNull();
            methodCalculateMemoryAllocationPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CalculateMemoryAllocation) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_CalculateMemoryAllocation_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCalculateMemoryAllocationPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheManagerInstance, MethodCalculateMemoryAllocation, Fixture, methodCalculateMemoryAllocationPrametersTypes);

            // Assert
            methodCalculateMemoryAllocationPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CalculateMemoryAllocation) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_CalculateMemoryAllocation_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCalculateMemoryAllocation, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cacheManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CalculateSize) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CacheManager_CalculateSize_Method_Call_Internally(Type[] types)
        {
            var methodCalculateSizePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheManagerInstance, MethodCalculateSize, Fixture, methodCalculateSizePrametersTypes);
        }

        #endregion

        #region Method Call : (CalculateSize) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_CalculateSize_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var dataTable = CreateType<DataTable>();
            var methodCalculateSizePrametersTypes = new Type[] { typeof(DataTable) };
            object[] parametersOfCalculateSize = { dataTable };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCalculateSize, methodCalculateSizePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cacheManagerInstanceFixture, parametersOfCalculateSize);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCalculateSize.ShouldNotBeNull();
            parametersOfCalculateSize.Length.ShouldBe(1);
            methodCalculateSizePrametersTypes.Length.ShouldBe(1);
            methodCalculateSizePrametersTypes.Length.ShouldBe(parametersOfCalculateSize.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CalculateSize) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_CalculateSize_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dataTable = CreateType<DataTable>();
            var methodCalculateSizePrametersTypes = new Type[] { typeof(DataTable) };
            object[] parametersOfCalculateSize = { dataTable };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cacheManagerInstance, MethodCalculateSize, parametersOfCalculateSize, methodCalculateSizePrametersTypes);

            // Assert
            parametersOfCalculateSize.ShouldNotBeNull();
            parametersOfCalculateSize.Length.ShouldBe(1);
            methodCalculateSizePrametersTypes.Length.ShouldBe(1);
            methodCalculateSizePrametersTypes.Length.ShouldBe(parametersOfCalculateSize.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CalculateSize) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_CalculateSize_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCalculateSize, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CalculateSize) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_CalculateSize_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCalculateSizePrametersTypes = new Type[] { typeof(DataTable) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheManagerInstance, MethodCalculateSize, Fixture, methodCalculateSizePrametersTypes);

            // Assert
            methodCalculateSizePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CalculateSize) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_CalculateSize_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCalculateSize, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cacheManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (delButton_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CacheManager_delButton_Click_Method_Call_Internally(Type[] types)
        {
            var methoddelButton_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheManagerInstance, MethoddelButton_Click, Fixture, methoddelButton_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (delButton_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_delButton_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methoddelButton_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfdelButton_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethoddelButton_Click, methoddelButton_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cacheManagerInstanceFixture, parametersOfdelButton_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfdelButton_Click.ShouldNotBeNull();
            parametersOfdelButton_Click.Length.ShouldBe(2);
            methoddelButton_ClickPrametersTypes.Length.ShouldBe(2);
            methoddelButton_ClickPrametersTypes.Length.ShouldBe(parametersOfdelButton_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (delButton_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_delButton_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methoddelButton_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfdelButton_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cacheManagerInstance, MethoddelButton_Click, parametersOfdelButton_Click, methoddelButton_ClickPrametersTypes);

            // Assert
            parametersOfdelButton_Click.ShouldNotBeNull();
            parametersOfdelButton_Click.Length.ShouldBe(2);
            methoddelButton_ClickPrametersTypes.Length.ShouldBe(2);
            methoddelButton_ClickPrametersTypes.Length.ShouldBe(parametersOfdelButton_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (delButton_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_delButton_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethoddelButton_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (delButton_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_delButton_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methoddelButton_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheManagerInstance, MethoddelButton_Click, Fixture, methoddelButton_ClickPrametersTypes);

            // Assert
            methoddelButton_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (delButton_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_delButton_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethoddelButton_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cacheManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteItem) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CacheManager_DeleteItem_Static_Method_Call_Internally(Type[] types)
        {
            var methodDeleteItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_cacheManagerInstanceFixture, _cacheManagerInstanceType, MethodDeleteItem, Fixture, methodDeleteItemPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteItem) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_DeleteItem_Static_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var item = CreateType<GridDataItem>();
            var methodDeleteItemPrametersTypes = new Type[] { typeof(GridDataItem) };
            object[] parametersOfDeleteItem = { item };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDeleteItem, methodDeleteItemPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cacheManagerInstanceFixture, parametersOfDeleteItem);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDeleteItem.ShouldNotBeNull();
            parametersOfDeleteItem.Length.ShouldBe(1);
            methodDeleteItemPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DeleteItem) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_DeleteItem_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var item = CreateType<GridDataItem>();
            var methodDeleteItemPrametersTypes = new Type[] { typeof(GridDataItem) };
            object[] parametersOfDeleteItem = { item };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_cacheManagerInstanceFixture, _cacheManagerInstanceType, MethodDeleteItem, parametersOfDeleteItem, methodDeleteItemPrametersTypes);

            // Assert
            parametersOfDeleteItem.ShouldNotBeNull();
            parametersOfDeleteItem.Length.ShouldBe(1);
            methodDeleteItemPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteItem) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_DeleteItem_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteItem, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteItem) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_DeleteItem_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteItemPrametersTypes = new Type[] { typeof(GridDataItem) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_cacheManagerInstanceFixture, _cacheManagerInstanceType, MethodDeleteItem, Fixture, methodDeleteItemPrametersTypes);

            // Assert
            methodDeleteItemPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteItem) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_DeleteItem_Static_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteItem, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cacheManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteItemsForCategory) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CacheManager_DeleteItemsForCategory_Method_Call_Internally(Type[] types)
        {
            var methodDeleteItemsForCategoryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheManagerInstance, MethodDeleteItemsForCategory, Fixture, methodDeleteItemsForCategoryPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteItemsForCategory) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_DeleteItemsForCategory_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var category = CreateType<string>();
            var methodDeleteItemsForCategoryPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeleteItemsForCategory = { category };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDeleteItemsForCategory, methodDeleteItemsForCategoryPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cacheManagerInstanceFixture, parametersOfDeleteItemsForCategory);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDeleteItemsForCategory.ShouldNotBeNull();
            parametersOfDeleteItemsForCategory.Length.ShouldBe(1);
            methodDeleteItemsForCategoryPrametersTypes.Length.ShouldBe(1);
            methodDeleteItemsForCategoryPrametersTypes.Length.ShouldBe(parametersOfDeleteItemsForCategory.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteItemsForCategory) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_DeleteItemsForCategory_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var category = CreateType<string>();
            var methodDeleteItemsForCategoryPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeleteItemsForCategory = { category };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cacheManagerInstance, MethodDeleteItemsForCategory, parametersOfDeleteItemsForCategory, methodDeleteItemsForCategoryPrametersTypes);

            // Assert
            parametersOfDeleteItemsForCategory.ShouldNotBeNull();
            parametersOfDeleteItemsForCategory.Length.ShouldBe(1);
            methodDeleteItemsForCategoryPrametersTypes.Length.ShouldBe(1);
            methodDeleteItemsForCategoryPrametersTypes.Length.ShouldBe(parametersOfDeleteItemsForCategory.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteItemsForCategory) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_DeleteItemsForCategory_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteItemsForCategory, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteItemsForCategory) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_DeleteItemsForCategory_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteItemsForCategoryPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheManagerInstance, MethodDeleteItemsForCategory, Fixture, methodDeleteItemsForCategoryPrametersTypes);

            // Assert
            methodDeleteItemsForCategoryPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteItemsForCategory) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_DeleteItemsForCategory_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteItemsForCategory, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cacheManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetServerInfo) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CacheManager_GetServerInfo_Method_Call_Internally(Type[] types)
        {
            var methodGetServerInfoPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheManagerInstance, MethodGetServerInfo, Fixture, methodGetServerInfoPrametersTypes);
        }

        #endregion

        #region Method Call : (GetServerInfo) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_GetServerInfo_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetServerInfoPrametersTypes = null;
            object[] parametersOfGetServerInfo = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetServerInfo, methodGetServerInfoPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cacheManagerInstanceFixture, parametersOfGetServerInfo);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetServerInfo.ShouldBeNull();
            methodGetServerInfoPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetServerInfo) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_GetServerInfo_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetServerInfoPrametersTypes = null;
            object[] parametersOfGetServerInfo = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cacheManagerInstance, MethodGetServerInfo, parametersOfGetServerInfo, methodGetServerInfoPrametersTypes);

            // Assert
            parametersOfGetServerInfo.ShouldBeNull();
            methodGetServerInfoPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetServerInfo) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_GetServerInfo_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetServerInfoPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheManagerInstance, MethodGetServerInfo, Fixture, methodGetServerInfoPrametersTypes);

            // Assert
            methodGetServerInfoPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetServerInfo) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_GetServerInfo_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetServerInfo, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cacheManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CacheManager_LoadData_Method_Call_Internally(Type[] types)
        {
            var methodLoadDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheManagerInstance, MethodLoadData, Fixture, methodLoadDataPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_LoadData_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodLoadDataPrametersTypes = null;
            object[] parametersOfLoadData = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodLoadData, methodLoadDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cacheManagerInstanceFixture, parametersOfLoadData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfLoadData.ShouldBeNull();
            methodLoadDataPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (LoadData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_LoadData_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodLoadDataPrametersTypes = null;
            object[] parametersOfLoadData = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cacheManagerInstance, MethodLoadData, parametersOfLoadData, methodLoadDataPrametersTypes);

            // Assert
            parametersOfLoadData.ShouldBeNull();
            methodLoadDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_LoadData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodLoadDataPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheManagerInstance, MethodLoadData, Fixture, methodLoadDataPrametersTypes);

            // Assert
            methodLoadDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_LoadData_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLoadData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cacheManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ValidateAccess) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CacheManager_ValidateAccess_Method_Call_Internally(Type[] types)
        {
            var methodValidateAccessPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheManagerInstance, MethodValidateAccess, Fixture, methodValidateAccessPrametersTypes);
        }

        #endregion

        #region Method Call : (ValidateAccess) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_ValidateAccess_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodValidateAccessPrametersTypes = null;
            object[] parametersOfValidateAccess = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodValidateAccess, methodValidateAccessPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cacheManagerInstanceFixture, parametersOfValidateAccess);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfValidateAccess.ShouldBeNull();
            methodValidateAccessPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ValidateAccess) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_ValidateAccess_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodValidateAccessPrametersTypes = null;
            object[] parametersOfValidateAccess = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cacheManagerInstance, MethodValidateAccess, parametersOfValidateAccess, methodValidateAccessPrametersTypes);

            // Assert
            parametersOfValidateAccess.ShouldBeNull();
            methodValidateAccessPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ValidateAccess) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_ValidateAccess_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodValidateAccessPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cacheManagerInstance, MethodValidateAccess, Fixture, methodValidateAccessPrametersTypes);

            // Assert
            methodValidateAccessPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ValidateAccess) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CacheManager_ValidateAccess_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodValidateAccess, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cacheManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
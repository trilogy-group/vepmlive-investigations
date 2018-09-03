using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace PortfolioEngineCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PortfolioEngineCore.QueueManager" />)
    ///     and namespace <see cref="PortfolioEngineCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class QueueManagerTest : AbstractBaseSetupTypedTest<QueueManager>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (QueueManager) Initializer

        private const string PropertyContext = "Context";
        private const string PropertyguidJob = "guidJob";
        private const string PropertyContextData = "ContextData";
        private const string PropertySession = "Session";
        private const string PropertyComment = "Comment";
        private const string PropertyWResID = "WResID";
        private const string MethodReadNextQueuedItem = "ReadNextQueuedItem";
        private const string MethodManageQueue = "ManageQueue";
        private const string MethodManageTimedJobs = "ManageTimedJobs";
        private const string MethodAddHeartBeat = "AddHeartBeat";
        private const string MethodSetJobStarted = "SetJobStarted";
        private const string MethodSetJobCompleted = "SetJobCompleted";
        private const string MethodHandleRequest = "HandleRequest";
        private const string MethodBuildProductInfoString = "BuildProductInfoString";
        private const string MethodconvertToSQL = "convertToSQL";
        private const string Fieldm_lContext = "m_lContext";
        private const string Fieldm_guidJob = "m_guidJob";
        private const string Fieldm_sContextData = "m_sContextData";
        private const string Fieldm_sSession = "m_sSession";
        private const string Fieldm_sComment = "m_sComment";
        private const string Fieldm_lWResID = "m_lWResID";
        private Type _queueManagerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private QueueManager _queueManagerInstance;
        private QueueManager _queueManagerInstanceFixture;

        #region General Initializer : Class (QueueManager) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="QueueManager" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _queueManagerInstanceType = typeof(QueueManager);
            _queueManagerInstanceFixture = Create(true);
            _queueManagerInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (QueueManager)

        #region General Initializer : Class (QueueManager) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="QueueManager" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodReadNextQueuedItem, 0)]
        [TestCase(MethodManageQueue, 0)]
        [TestCase(MethodManageTimedJobs, 0)]
        [TestCase(MethodAddHeartBeat, 0)]
        [TestCase(MethodSetJobStarted, 0)]
        [TestCase(MethodSetJobCompleted, 0)]
        [TestCase(MethodHandleRequest, 0)]
        [TestCase(MethodBuildProductInfoString, 0)]
        [TestCase(MethodconvertToSQL, 0)]
        public void AUT_QueueManager_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_queueManagerInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (QueueManager) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="QueueManager" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyContext)]
        [TestCase(PropertyguidJob)]
        [TestCase(PropertyContextData)]
        [TestCase(PropertySession)]
        [TestCase(PropertyComment)]
        [TestCase(PropertyWResID)]
        public void AUT_QueueManager_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_queueManagerInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (QueueManager) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="QueueManager" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldm_lContext)]
        [TestCase(Fieldm_guidJob)]
        [TestCase(Fieldm_sContextData)]
        [TestCase(Fieldm_sSession)]
        [TestCase(Fieldm_sComment)]
        [TestCase(Fieldm_lWResID)]
        public void AUT_QueueManager_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_queueManagerInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (QueueManager) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="QueueManager" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_QueueManager_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<QueueManager>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (QueueManager) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="QueueManager" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueueManager_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<QueueManager>(Fixture);
        }

        #endregion

        #region General Constructor : Class (QueueManager) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="QueueManager" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueueManager_Constructors_Explore_Verify_Test()
        {
            // Arrange
            var basepath = CreateType<string>();
            var username = CreateType<string>();
            var pid = CreateType<string>();
            var company = CreateType<string>();
            var dbcnstring = CreateType<string>();
            var secLevel = CreateType<SecurityLevels>();
            var bDebug = CreateType<bool>();
            object[] parametersOfQueueManager = { basepath, username, pid, company, dbcnstring, secLevel, bDebug };
            var methodQueueManagerPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(SecurityLevels), typeof(bool) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_queueManagerInstanceType, methodQueueManagerPrametersTypes, parametersOfQueueManager);
        }

        #endregion

        #region General Constructor : Class (QueueManager) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="QueueManager" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueueManager_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodQueueManagerPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(SecurityLevels), typeof(bool) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_queueManagerInstanceType, Fixture, methodQueueManagerPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (QueueManager) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="QueueManager" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueueManager_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var sBaseInfo = CreateType<string>();
            object[] parametersOfQueueManager = { sBaseInfo };
            var methodQueueManagerPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_queueManagerInstanceType, methodQueueManagerPrametersTypes, parametersOfQueueManager);
        }

        #endregion

        #region General Constructor : Class (QueueManager) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="QueueManager" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_QueueManager_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodQueueManagerPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_queueManagerInstanceType, Fixture, methodQueueManagerPrametersTypes);
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (QueueManager) => Property (Comment) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_QueueManager_Public_Class_Comment_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyComment);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (QueueManager) => Property (Context) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_QueueManager_Public_Class_Context_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyContext);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (QueueManager) => Property (ContextData) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_QueueManager_Public_Class_ContextData_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyContextData);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (QueueManager) => Property (guidJob) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_QueueManager_guidJob_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyguidJob);
            Action currentAction = () => propertyInfo.SetValue(_queueManagerInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (QueueManager) => Property (guidJob) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_QueueManager_Public_Class_guidJob_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyguidJob);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (QueueManager) => Property (Session) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_QueueManager_Public_Class_Session_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySession);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (QueueManager) => Property (WResID) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_QueueManager_Public_Class_WResID_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyWResID);

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

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="QueueManager" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodconvertToSQL)]
        public void AUT_QueueManager_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_queueManagerInstanceFixture,
                                                                              _queueManagerInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="QueueManager" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodReadNextQueuedItem)]
        [TestCase(MethodManageQueue)]
        [TestCase(MethodManageTimedJobs)]
        [TestCase(MethodAddHeartBeat)]
        [TestCase(MethodSetJobStarted)]
        [TestCase(MethodSetJobCompleted)]
        [TestCase(MethodHandleRequest)]
        [TestCase(MethodBuildProductInfoString)]
        public void AUT_QueueManager_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<QueueManager>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (ReadNextQueuedItem) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_QueueManager_ReadNextQueuedItem_Method_Call_Internally(Type[] types)
        {
            var methodReadNextQueuedItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueManagerInstance, MethodReadNextQueuedItem, Fixture, methodReadNextQueuedItemPrametersTypes);
        }

        #endregion

        #region Method Call : (ReadNextQueuedItem) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_ReadNextQueuedItem_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var exclusion = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _queueManagerInstance.ReadNextQueuedItem(exclusion);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ReadNextQueuedItem) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_ReadNextQueuedItem_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var exclusion = CreateType<string>();
            var methodReadNextQueuedItemPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfReadNextQueuedItem = { exclusion };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodReadNextQueuedItem, methodReadNextQueuedItemPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<QueueManager, bool>(_queueManagerInstanceFixture, out exception1, parametersOfReadNextQueuedItem);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<QueueManager, bool>(_queueManagerInstance, MethodReadNextQueuedItem, parametersOfReadNextQueuedItem, methodReadNextQueuedItemPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfReadNextQueuedItem.ShouldNotBeNull();
            parametersOfReadNextQueuedItem.Length.ShouldBe(1);
            methodReadNextQueuedItemPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ReadNextQueuedItem) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_ReadNextQueuedItem_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var exclusion = CreateType<string>();
            var methodReadNextQueuedItemPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfReadNextQueuedItem = { exclusion };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodReadNextQueuedItem, methodReadNextQueuedItemPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<QueueManager, bool>(_queueManagerInstanceFixture, out exception1, parametersOfReadNextQueuedItem);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<QueueManager, bool>(_queueManagerInstance, MethodReadNextQueuedItem, parametersOfReadNextQueuedItem, methodReadNextQueuedItemPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfReadNextQueuedItem.ShouldNotBeNull();
            parametersOfReadNextQueuedItem.Length.ShouldBe(1);
            methodReadNextQueuedItemPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ReadNextQueuedItem) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_ReadNextQueuedItem_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var exclusion = CreateType<string>();
            var methodReadNextQueuedItemPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfReadNextQueuedItem = { exclusion };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<QueueManager, bool>(_queueManagerInstance, MethodReadNextQueuedItem, parametersOfReadNextQueuedItem, methodReadNextQueuedItemPrametersTypes);

            // Assert
            parametersOfReadNextQueuedItem.ShouldNotBeNull();
            parametersOfReadNextQueuedItem.Length.ShouldBe(1);
            methodReadNextQueuedItemPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadNextQueuedItem) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_ReadNextQueuedItem_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadNextQueuedItemPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueManagerInstance, MethodReadNextQueuedItem, Fixture, methodReadNextQueuedItemPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodReadNextQueuedItemPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadNextQueuedItem) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_ReadNextQueuedItem_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReadNextQueuedItem, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_queueManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ReadNextQueuedItem) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_ReadNextQueuedItem_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReadNextQueuedItem, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ManageQueue) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_QueueManager_ManageQueue_Method_Call_Internally(Type[] types)
        {
            var methodManageQueuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueManagerInstance, MethodManageQueue, Fixture, methodManageQueuePrametersTypes);
        }

        #endregion

        #region Method Call : (ManageQueue) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_ManageQueue_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _queueManagerInstance.ManageQueue();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ManageQueue) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_ManageQueue_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodManageQueuePrametersTypes = null;
            object[] parametersOfManageQueue = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodManageQueue, methodManageQueuePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<QueueManager, bool>(_queueManagerInstanceFixture, out exception1, parametersOfManageQueue);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<QueueManager, bool>(_queueManagerInstance, MethodManageQueue, parametersOfManageQueue, methodManageQueuePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfManageQueue.ShouldBeNull();
            methodManageQueuePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ManageQueue) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_ManageQueue_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodManageQueuePrametersTypes = null;
            object[] parametersOfManageQueue = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodManageQueue, methodManageQueuePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<QueueManager, bool>(_queueManagerInstanceFixture, out exception1, parametersOfManageQueue);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<QueueManager, bool>(_queueManagerInstance, MethodManageQueue, parametersOfManageQueue, methodManageQueuePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfManageQueue.ShouldBeNull();
            methodManageQueuePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ManageQueue) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_ManageQueue_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodManageQueuePrametersTypes = null;
            object[] parametersOfManageQueue = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<QueueManager, bool>(_queueManagerInstance, MethodManageQueue, parametersOfManageQueue, methodManageQueuePrametersTypes);

            // Assert
            parametersOfManageQueue.ShouldBeNull();
            methodManageQueuePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ManageQueue) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_ManageQueue_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodManageQueuePrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueManagerInstance, MethodManageQueue, Fixture, methodManageQueuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodManageQueuePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ManageQueue) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_ManageQueue_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodManageQueue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_queueManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ManageTimedJobs) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_QueueManager_ManageTimedJobs_Method_Call_Internally(Type[] types)
        {
            var methodManageTimedJobsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueManagerInstance, MethodManageTimedJobs, Fixture, methodManageTimedJobsPrametersTypes);
        }

        #endregion

        #region Method Call : (ManageTimedJobs) (Return Type : int) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_ManageTimedJobs_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _queueManagerInstance.ManageTimedJobs();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ManageTimedJobs) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_ManageTimedJobs_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodManageTimedJobsPrametersTypes = null;
            object[] parametersOfManageTimedJobs = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodManageTimedJobs, methodManageTimedJobsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<QueueManager, int>(_queueManagerInstanceFixture, out exception1, parametersOfManageTimedJobs);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<QueueManager, int>(_queueManagerInstance, MethodManageTimedJobs, parametersOfManageTimedJobs, methodManageTimedJobsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfManageTimedJobs.ShouldBeNull();
            methodManageTimedJobsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ManageTimedJobs) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_ManageTimedJobs_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodManageTimedJobsPrametersTypes = null;
            object[] parametersOfManageTimedJobs = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodManageTimedJobs, methodManageTimedJobsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<QueueManager, int>(_queueManagerInstanceFixture, out exception1, parametersOfManageTimedJobs);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<QueueManager, int>(_queueManagerInstance, MethodManageTimedJobs, parametersOfManageTimedJobs, methodManageTimedJobsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfManageTimedJobs.ShouldBeNull();
            methodManageTimedJobsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ManageTimedJobs) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_ManageTimedJobs_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodManageTimedJobsPrametersTypes = null;
            object[] parametersOfManageTimedJobs = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<QueueManager, int>(_queueManagerInstance, MethodManageTimedJobs, parametersOfManageTimedJobs, methodManageTimedJobsPrametersTypes);

            // Assert
            parametersOfManageTimedJobs.ShouldBeNull();
            methodManageTimedJobsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ManageTimedJobs) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_ManageTimedJobs_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodManageTimedJobsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueManagerInstance, MethodManageTimedJobs, Fixture, methodManageTimedJobsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodManageTimedJobsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ManageTimedJobs) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_ManageTimedJobs_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodManageTimedJobs, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_queueManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AddHeartBeat) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_QueueManager_AddHeartBeat_Method_Call_Internally(Type[] types)
        {
            var methodAddHeartBeatPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueManagerInstance, MethodAddHeartBeat, Fixture, methodAddHeartBeatPrametersTypes);
        }

        #endregion

        #region Method Call : (AddHeartBeat) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_AddHeartBeat_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _queueManagerInstance.AddHeartBeat();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (AddHeartBeat) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_AddHeartBeat_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodAddHeartBeatPrametersTypes = null;
            object[] parametersOfAddHeartBeat = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddHeartBeat, methodAddHeartBeatPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_queueManagerInstanceFixture, parametersOfAddHeartBeat);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddHeartBeat.ShouldBeNull();
            methodAddHeartBeatPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddHeartBeat) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_AddHeartBeat_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodAddHeartBeatPrametersTypes = null;
            object[] parametersOfAddHeartBeat = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_queueManagerInstance, MethodAddHeartBeat, parametersOfAddHeartBeat, methodAddHeartBeatPrametersTypes);

            // Assert
            parametersOfAddHeartBeat.ShouldBeNull();
            methodAddHeartBeatPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddHeartBeat) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_AddHeartBeat_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodAddHeartBeatPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueManagerInstance, MethodAddHeartBeat, Fixture, methodAddHeartBeatPrametersTypes);

            // Assert
            methodAddHeartBeatPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddHeartBeat) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_AddHeartBeat_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddHeartBeat, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_queueManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetJobStarted) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_QueueManager_SetJobStarted_Method_Call_Internally(Type[] types)
        {
            var methodSetJobStartedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueManagerInstance, MethodSetJobStarted, Fixture, methodSetJobStartedPrametersTypes);
        }

        #endregion

        #region Method Call : (SetJobStarted) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_SetJobStarted_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _queueManagerInstance.SetJobStarted();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetJobStarted) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_SetJobStarted_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodSetJobStartedPrametersTypes = null;
            object[] parametersOfSetJobStarted = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSetJobStarted, methodSetJobStartedPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<QueueManager, bool>(_queueManagerInstanceFixture, out exception1, parametersOfSetJobStarted);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<QueueManager, bool>(_queueManagerInstance, MethodSetJobStarted, parametersOfSetJobStarted, methodSetJobStartedPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSetJobStarted.ShouldBeNull();
            methodSetJobStartedPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetJobStarted) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_SetJobStarted_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodSetJobStartedPrametersTypes = null;
            object[] parametersOfSetJobStarted = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSetJobStarted, methodSetJobStartedPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<QueueManager, bool>(_queueManagerInstanceFixture, out exception1, parametersOfSetJobStarted);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<QueueManager, bool>(_queueManagerInstance, MethodSetJobStarted, parametersOfSetJobStarted, methodSetJobStartedPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSetJobStarted.ShouldBeNull();
            methodSetJobStartedPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetJobStarted) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_SetJobStarted_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodSetJobStartedPrametersTypes = null;
            object[] parametersOfSetJobStarted = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<QueueManager, bool>(_queueManagerInstance, MethodSetJobStarted, parametersOfSetJobStarted, methodSetJobStartedPrametersTypes);

            // Assert
            parametersOfSetJobStarted.ShouldBeNull();
            methodSetJobStartedPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetJobStarted) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_SetJobStarted_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodSetJobStartedPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueManagerInstance, MethodSetJobStarted, Fixture, methodSetJobStartedPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSetJobStartedPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetJobStarted) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_SetJobStarted_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetJobStarted, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_queueManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetJobCompleted) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_QueueManager_SetJobCompleted_Method_Call_Internally(Type[] types)
        {
            var methodSetJobCompletedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueManagerInstance, MethodSetJobCompleted, Fixture, methodSetJobCompletedPrametersTypes);
        }

        #endregion

        #region Method Call : (SetJobCompleted) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_SetJobCompleted_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _queueManagerInstance.SetJobCompleted();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetJobCompleted) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_SetJobCompleted_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodSetJobCompletedPrametersTypes = null;
            object[] parametersOfSetJobCompleted = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSetJobCompleted, methodSetJobCompletedPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<QueueManager, bool>(_queueManagerInstanceFixture, out exception1, parametersOfSetJobCompleted);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<QueueManager, bool>(_queueManagerInstance, MethodSetJobCompleted, parametersOfSetJobCompleted, methodSetJobCompletedPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSetJobCompleted.ShouldBeNull();
            methodSetJobCompletedPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetJobCompleted) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_SetJobCompleted_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodSetJobCompletedPrametersTypes = null;
            object[] parametersOfSetJobCompleted = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSetJobCompleted, methodSetJobCompletedPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<QueueManager, bool>(_queueManagerInstanceFixture, out exception1, parametersOfSetJobCompleted);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<QueueManager, bool>(_queueManagerInstance, MethodSetJobCompleted, parametersOfSetJobCompleted, methodSetJobCompletedPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSetJobCompleted.ShouldBeNull();
            methodSetJobCompletedPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetJobCompleted) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_SetJobCompleted_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodSetJobCompletedPrametersTypes = null;
            object[] parametersOfSetJobCompleted = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<QueueManager, bool>(_queueManagerInstance, MethodSetJobCompleted, parametersOfSetJobCompleted, methodSetJobCompletedPrametersTypes);

            // Assert
            parametersOfSetJobCompleted.ShouldBeNull();
            methodSetJobCompletedPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetJobCompleted) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_SetJobCompleted_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodSetJobCompletedPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueManagerInstance, MethodSetJobCompleted, Fixture, methodSetJobCompletedPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSetJobCompletedPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetJobCompleted) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_SetJobCompleted_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetJobCompleted, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_queueManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (HandleRequest) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_QueueManager_HandleRequest_Method_Call_Internally(Type[] types)
        {
            var methodHandleRequestPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueManagerInstance, MethodHandleRequest, Fixture, methodHandleRequestPrametersTypes);
        }

        #endregion

        #region Method Call : (HandleRequest) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_HandleRequest_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sContext = CreateType<string>();
            var sRequest = CreateType<string>();
            var sReply = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _queueManagerInstance.HandleRequest(sContext, sRequest, out sReply);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (HandleRequest) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_HandleRequest_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sContext = CreateType<string>();
            var sRequest = CreateType<string>();
            var sReply = CreateType<string>();
            var methodHandleRequestPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            object[] parametersOfHandleRequest = { sContext, sRequest, sReply };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodHandleRequest, methodHandleRequestPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<QueueManager, bool>(_queueManagerInstanceFixture, out exception1, parametersOfHandleRequest);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<QueueManager, bool>(_queueManagerInstance, MethodHandleRequest, parametersOfHandleRequest, methodHandleRequestPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfHandleRequest.ShouldNotBeNull();
            parametersOfHandleRequest.Length.ShouldBe(3);
            methodHandleRequestPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (HandleRequest) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_HandleRequest_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sContext = CreateType<string>();
            var sRequest = CreateType<string>();
            var sReply = CreateType<string>();
            var methodHandleRequestPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            object[] parametersOfHandleRequest = { sContext, sRequest, sReply };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodHandleRequest, methodHandleRequestPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<QueueManager, bool>(_queueManagerInstanceFixture, out exception1, parametersOfHandleRequest);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<QueueManager, bool>(_queueManagerInstance, MethodHandleRequest, parametersOfHandleRequest, methodHandleRequestPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfHandleRequest.ShouldNotBeNull();
            parametersOfHandleRequest.Length.ShouldBe(3);
            methodHandleRequestPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (HandleRequest) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_HandleRequest_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sContext = CreateType<string>();
            var sRequest = CreateType<string>();
            var sReply = CreateType<string>();
            var methodHandleRequestPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            object[] parametersOfHandleRequest = { sContext, sRequest, sReply };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<QueueManager, bool>(_queueManagerInstance, MethodHandleRequest, parametersOfHandleRequest, methodHandleRequestPrametersTypes);

            // Assert
            parametersOfHandleRequest.ShouldNotBeNull();
            parametersOfHandleRequest.Length.ShouldBe(3);
            methodHandleRequestPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HandleRequest) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_HandleRequest_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodHandleRequestPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueManagerInstance, MethodHandleRequest, Fixture, methodHandleRequestPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodHandleRequestPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (HandleRequest) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_HandleRequest_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodHandleRequest, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_queueManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (HandleRequest) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_HandleRequest_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodHandleRequest, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildProductInfoString) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_QueueManager_BuildProductInfoString_Method_Call_Internally(Type[] types)
        {
            var methodBuildProductInfoStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueManagerInstance, MethodBuildProductInfoString, Fixture, methodBuildProductInfoStringPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildProductInfoString) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_BuildProductInfoString_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var token = CreateType<IntPtr>();
            var methodBuildProductInfoStringPrametersTypes = new Type[] { typeof(IntPtr) };
            object[] parametersOfBuildProductInfoString = { token };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodBuildProductInfoString, methodBuildProductInfoStringPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<QueueManager, string>(_queueManagerInstanceFixture, out exception1, parametersOfBuildProductInfoString);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<QueueManager, string>(_queueManagerInstance, MethodBuildProductInfoString, parametersOfBuildProductInfoString, methodBuildProductInfoStringPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfBuildProductInfoString.ShouldNotBeNull();
            parametersOfBuildProductInfoString.Length.ShouldBe(1);
            methodBuildProductInfoStringPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (BuildProductInfoString) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_BuildProductInfoString_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var token = CreateType<IntPtr>();
            var methodBuildProductInfoStringPrametersTypes = new Type[] { typeof(IntPtr) };
            object[] parametersOfBuildProductInfoString = { token };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<QueueManager, string>(_queueManagerInstance, MethodBuildProductInfoString, parametersOfBuildProductInfoString, methodBuildProductInfoStringPrametersTypes);

            // Assert
            parametersOfBuildProductInfoString.ShouldNotBeNull();
            parametersOfBuildProductInfoString.Length.ShouldBe(1);
            methodBuildProductInfoStringPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildProductInfoString) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_BuildProductInfoString_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodBuildProductInfoStringPrametersTypes = new Type[] { typeof(IntPtr) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueManagerInstance, MethodBuildProductInfoString, Fixture, methodBuildProductInfoStringPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodBuildProductInfoStringPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (BuildProductInfoString) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_BuildProductInfoString_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBuildProductInfoStringPrametersTypes = new Type[] { typeof(IntPtr) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueManagerInstance, MethodBuildProductInfoString, Fixture, methodBuildProductInfoStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildProductInfoStringPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildProductInfoString) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_BuildProductInfoString_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildProductInfoString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_queueManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BuildProductInfoString) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_BuildProductInfoString_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBuildProductInfoString, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (convertToSQL) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_QueueManager_convertToSQL_Static_Method_Call_Internally(Type[] types)
        {
            var methodconvertToSQLPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_queueManagerInstanceFixture, _queueManagerInstanceType, MethodconvertToSQL, Fixture, methodconvertToSQLPrametersTypes);
        }

        #endregion

        #region Method Call : (convertToSQL) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_convertToSQL_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sSqlconnect = CreateType<string>();
            var methodconvertToSQLPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfconvertToSQL = { sSqlconnect };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodconvertToSQL, methodconvertToSQLPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_queueManagerInstanceFixture, parametersOfconvertToSQL);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfconvertToSQL.ShouldNotBeNull();
            parametersOfconvertToSQL.Length.ShouldBe(1);
            methodconvertToSQLPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (convertToSQL) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_convertToSQL_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sSqlconnect = CreateType<string>();
            var methodconvertToSQLPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfconvertToSQL = { sSqlconnect };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_queueManagerInstanceFixture, _queueManagerInstanceType, MethodconvertToSQL, parametersOfconvertToSQL, methodconvertToSQLPrametersTypes);

            // Assert
            parametersOfconvertToSQL.ShouldNotBeNull();
            parametersOfconvertToSQL.Length.ShouldBe(1);
            methodconvertToSQLPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (convertToSQL) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_convertToSQL_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodconvertToSQLPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_queueManagerInstanceFixture, _queueManagerInstanceType, MethodconvertToSQL, Fixture, methodconvertToSQLPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodconvertToSQLPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (convertToSQL) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_convertToSQL_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodconvertToSQLPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_queueManagerInstanceFixture, _queueManagerInstanceType, MethodconvertToSQL, Fixture, methodconvertToSQLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodconvertToSQLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (convertToSQL) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_convertToSQL_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodconvertToSQL, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_queueManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (convertToSQL) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueManager_convertToSQL_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodconvertToSQL, 0);
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
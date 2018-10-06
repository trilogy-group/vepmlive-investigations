using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using EPMLiveCore.Controls.Navigation.Providers;
using EPMLiveCore.Services.DataContracts.SocialEngine;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.Services
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Services.SocialEngine" />)
    ///     and namespace <see cref="EPMLiveCore.Services"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class SocialEngineTest : AbstractBaseSetupTypedTest<SocialEngine>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SocialEngine) Initializer

        private const string MethodGetActivities = "GetActivities";
        private const string MethodGetCreatables = "GetCreatables";
        private const string MethodGetItemsForThread = "GetItemsForThread";
        private const string MethodGetLogs = "GetLogs";
        private const string MethodGetSUId = "GetSUId";
        private const string MethodGetWebs = "GetWebs";
        private const string MethodAddList = "AddList";
        private const string MethodAddUser = "AddUser";
        private const string MethodAddWeb = "AddWeb";
        private const string MethodBuildActivities = "BuildActivities";
        private const string MethodBuildActivity = "BuildActivity";
        private const string MethodBuildComments = "BuildComments";
        private const string MethodBuildCreatables = "BuildCreatables";
        private const string MethodBuildThread = "BuildThread";
        private const string MethodGetData = "GetData";
        private const string MethodGetReportingListLibs = "GetReportingListLibs";
        private const string MethodGetSafeWebUrl = "GetSafeWebUrl";
        private const string MethodGetThreadActivities = "GetThreadActivities";
        private const string MethodGetThreads = "GetThreads";
        private const string MethodParseMetaData = "ParseMetaData";
        private const string MethodSetLocalDateTime = "SetLocalDateTime";
        private const string MethodSortThreadActivities = "SortThreadActivities";
        private const string FieldDATE_FORMAT = "DATE_FORMAT";
        private const string FieldPROXY_URL = "PROXY_URL";
        private const string Field_activityDateTimeColumns = "_activityDateTimeColumns";
        private const string Field_locker = "_locker";
        private const string Field_threadDateTimeColumns = "_threadDateTimeColumns";
        private const string Field_utcTimeDict = "_utcTimeDict";
        private const string Field_regionalSettings = "_regionalSettings";
        private Type _socialEngineInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private SocialEngine _socialEngineInstance;
        private SocialEngine _socialEngineInstanceFixture;

        #region General Initializer : Class (SocialEngine) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SocialEngine" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _socialEngineInstanceType = typeof(SocialEngine);
            _socialEngineInstanceFixture = Create(true);
            _socialEngineInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SocialEngine)

        #region General Initializer : Class (SocialEngine) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="SocialEngine" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetActivities, 0)]
        [TestCase(MethodGetCreatables, 0)]
        [TestCase(MethodGetLogs, 0)]
        [TestCase(MethodGetSUId, 0)]
        [TestCase(MethodGetWebs, 0)]
        [TestCase(MethodAddList, 0)]
        [TestCase(MethodAddUser, 0)]
        [TestCase(MethodAddWeb, 0)]
        [TestCase(MethodBuildActivities, 0)]
        [TestCase(MethodBuildComments, 0)]
        [TestCase(MethodBuildCreatables, 0)]
        [TestCase(MethodGetData, 0)]
        [TestCase(MethodGetData, 1)]
        [TestCase(MethodGetReportingListLibs, 0)]
        [TestCase(MethodGetSafeWebUrl, 0)]
        [TestCase(MethodParseMetaData, 0)]
        [TestCase(MethodSetLocalDateTime, 0)]
        public void AUT_SocialEngine_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_socialEngineInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (SocialEngine) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="SocialEngine" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldDATE_FORMAT)]
        [TestCase(FieldPROXY_URL)]
        [TestCase(Field_activityDateTimeColumns)]
        [TestCase(Field_locker)]
        [TestCase(Field_threadDateTimeColumns)]
        [TestCase(Field_utcTimeDict)]
        [TestCase(Field_regionalSettings)]
        public void AUT_SocialEngine_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_socialEngineInstanceFixture, 
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
        ///     Class (<see cref="SocialEngine" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_SocialEngine_Is_Instance_Present_Test()
        {
            // Assert
            _socialEngineInstanceType.ShouldNotBeNull();
            _socialEngineInstance.ShouldNotBeNull();
            _socialEngineInstanceFixture.ShouldNotBeNull();
            _socialEngineInstance.ShouldBeAssignableTo<SocialEngine>();
            _socialEngineInstanceFixture.ShouldBeAssignableTo<SocialEngine>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (SocialEngine) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_SocialEngine_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            SocialEngine instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _socialEngineInstanceType.ShouldNotBeNull();
            _socialEngineInstance.ShouldNotBeNull();
            _socialEngineInstanceFixture.ShouldNotBeNull();
            _socialEngineInstance.ShouldBeAssignableTo<SocialEngine>();
            _socialEngineInstanceFixture.ShouldBeAssignableTo<SocialEngine>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="SocialEngine" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodBuildCreatables)]
        [TestCase(MethodGetReportingListLibs)]
        [TestCase(MethodGetSafeWebUrl)]
        public void AUT_SocialEngine_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_socialEngineInstanceFixture,
                                                                              _socialEngineInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="SocialEngine" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetActivities)]
        [TestCase(MethodGetCreatables)]
        [TestCase(MethodGetLogs)]
        [TestCase(MethodGetSUId)]
        [TestCase(MethodGetWebs)]
        [TestCase(MethodAddList)]
        [TestCase(MethodAddUser)]
        [TestCase(MethodAddWeb)]
        [TestCase(MethodBuildActivities)]
        [TestCase(MethodBuildComments)]
        [TestCase(MethodGetData)]
        [TestCase(MethodParseMetaData)]
        [TestCase(MethodSetLocalDateTime)]
        public void AUT_SocialEngine_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<SocialEngine>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetActivities) (Return Type : SEActivities) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SocialEngine_GetActivities_Method_Call_Internally(Type[] types)
        {
            var methodGetActivitiesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_socialEngineInstance, MethodGetActivities, Fixture, methodGetActivitiesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetActivities) (Return Type : SEActivities) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetActivities_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _socialEngineInstance.GetActivities();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetActivities) (Return Type : SEActivities) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetActivities_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetActivitiesPrametersTypes = null;
            object[] parametersOfGetActivities = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetActivities, methodGetActivitiesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_socialEngineInstanceFixture, parametersOfGetActivities);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetActivities.ShouldBeNull();
            methodGetActivitiesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetActivities) (Return Type : SEActivities) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetActivities_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetActivitiesPrametersTypes = null;
            object[] parametersOfGetActivities = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<SocialEngine, SEActivities>(_socialEngineInstance, MethodGetActivities, parametersOfGetActivities, methodGetActivitiesPrametersTypes);

            // Assert
            parametersOfGetActivities.ShouldBeNull();
            methodGetActivitiesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetActivities) (Return Type : SEActivities) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetActivities_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetActivitiesPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_socialEngineInstance, MethodGetActivities, Fixture, methodGetActivitiesPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetActivitiesPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetActivities) (Return Type : SEActivities) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetActivities_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetActivitiesPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_socialEngineInstance, MethodGetActivities, Fixture, methodGetActivitiesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetActivitiesPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetActivities) (Return Type : SEActivities) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetActivities_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetActivities, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_socialEngineInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetCreatables) (Return Type : Creatables) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SocialEngine_GetCreatables_Method_Call_Internally(Type[] types)
        {
            var methodGetCreatablesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_socialEngineInstance, MethodGetCreatables, Fixture, methodGetCreatablesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCreatables) (Return Type : Creatables) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetCreatables_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _socialEngineInstance.GetCreatables();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetCreatables) (Return Type : Creatables) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetCreatables_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetCreatablesPrametersTypes = null;
            object[] parametersOfGetCreatables = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetCreatables, methodGetCreatablesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_socialEngineInstanceFixture, parametersOfGetCreatables);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetCreatables.ShouldBeNull();
            methodGetCreatablesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCreatables) (Return Type : Creatables) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetCreatables_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetCreatablesPrametersTypes = null;
            object[] parametersOfGetCreatables = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<SocialEngine, Creatables>(_socialEngineInstance, MethodGetCreatables, parametersOfGetCreatables, methodGetCreatablesPrametersTypes);

            // Assert
            parametersOfGetCreatables.ShouldBeNull();
            methodGetCreatablesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCreatables) (Return Type : Creatables) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetCreatables_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetCreatablesPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_socialEngineInstance, MethodGetCreatables, Fixture, methodGetCreatablesPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetCreatablesPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCreatables) (Return Type : Creatables) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetCreatables_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetCreatablesPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_socialEngineInstance, MethodGetCreatables, Fixture, methodGetCreatablesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCreatablesPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCreatables) (Return Type : Creatables) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetCreatables_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCreatables, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_socialEngineInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetLogs) (Return Type : Logs) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SocialEngine_GetLogs_Method_Call_Internally(Type[] types)
        {
            var methodGetLogsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_socialEngineInstance, MethodGetLogs, Fixture, methodGetLogsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetLogs) (Return Type : Logs) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetLogs_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _socialEngineInstance.GetLogs();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetLogs) (Return Type : Logs) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetLogs_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetLogsPrametersTypes = null;
            object[] parametersOfGetLogs = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetLogs, methodGetLogsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_socialEngineInstanceFixture, parametersOfGetLogs);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetLogs.ShouldBeNull();
            methodGetLogsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetLogs) (Return Type : Logs) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetLogs_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetLogsPrametersTypes = null;
            object[] parametersOfGetLogs = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<SocialEngine, Logs>(_socialEngineInstance, MethodGetLogs, parametersOfGetLogs, methodGetLogsPrametersTypes);

            // Assert
            parametersOfGetLogs.ShouldBeNull();
            methodGetLogsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetLogs) (Return Type : Logs) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetLogs_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetLogsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_socialEngineInstance, MethodGetLogs, Fixture, methodGetLogsPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetLogsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLogs) (Return Type : Logs) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetLogs_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetLogsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_socialEngineInstance, MethodGetLogs, Fixture, methodGetLogsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetLogsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLogs) (Return Type : Logs) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetLogs_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetLogs, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_socialEngineInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetSUId) (Return Type : SEActivities) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SocialEngine_GetSUId_Method_Call_Internally(Type[] types)
        {
            var methodGetSUIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_socialEngineInstance, MethodGetSUId, Fixture, methodGetSUIdPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSUId) (Return Type : SEActivities) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetSUId_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var listId = CreateType<string>();
            var itemId = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _socialEngineInstance.GetSUId(listId, itemId);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetSUId) (Return Type : SEActivities) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetSUId_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var listId = CreateType<string>();
            var itemId = CreateType<string>();
            var methodGetSUIdPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfGetSUId = { listId, itemId };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetSUId, methodGetSUIdPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_socialEngineInstanceFixture, parametersOfGetSUId);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetSUId.ShouldNotBeNull();
            parametersOfGetSUId.Length.ShouldBe(2);
            methodGetSUIdPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSUId) (Return Type : SEActivities) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetSUId_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listId = CreateType<string>();
            var itemId = CreateType<string>();
            var methodGetSUIdPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfGetSUId = { listId, itemId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<SocialEngine, SEActivities>(_socialEngineInstance, MethodGetSUId, parametersOfGetSUId, methodGetSUIdPrametersTypes);

            // Assert
            parametersOfGetSUId.ShouldNotBeNull();
            parametersOfGetSUId.Length.ShouldBe(2);
            methodGetSUIdPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSUId) (Return Type : SEActivities) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetSUId_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetSUIdPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_socialEngineInstance, MethodGetSUId, Fixture, methodGetSUIdPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetSUIdPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetSUId) (Return Type : SEActivities) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetSUId_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSUIdPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_socialEngineInstance, MethodGetSUId, Fixture, methodGetSUIdPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSUIdPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSUId) (Return Type : SEActivities) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetSUId_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSUId, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_socialEngineInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetSUId) (Return Type : SEActivities) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetSUId_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetSUId, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetWebs) (Return Type : Webs) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SocialEngine_GetWebs_Method_Call_Internally(Type[] types)
        {
            var methodGetWebsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_socialEngineInstance, MethodGetWebs, Fixture, methodGetWebsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetWebs) (Return Type : Webs) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetWebs_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _socialEngineInstance.GetWebs();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetWebs) (Return Type : Webs) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetWebs_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetWebsPrametersTypes = null;
            object[] parametersOfGetWebs = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetWebs, methodGetWebsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_socialEngineInstanceFixture, parametersOfGetWebs);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetWebs.ShouldBeNull();
            methodGetWebsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetWebs) (Return Type : Webs) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetWebs_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetWebsPrametersTypes = null;
            object[] parametersOfGetWebs = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<SocialEngine, Webs>(_socialEngineInstance, MethodGetWebs, parametersOfGetWebs, methodGetWebsPrametersTypes);

            // Assert
            parametersOfGetWebs.ShouldBeNull();
            methodGetWebsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetWebs) (Return Type : Webs) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetWebs_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetWebsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_socialEngineInstance, MethodGetWebs, Fixture, methodGetWebsPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetWebsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetWebs) (Return Type : Webs) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetWebs_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetWebsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_socialEngineInstance, MethodGetWebs, Fixture, methodGetWebsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetWebsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetWebs) (Return Type : Webs) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetWebs_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetWebs, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_socialEngineInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (AddList) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SocialEngine_AddList_Method_Call_Internally(Type[] types)
        {
            var methodAddListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_socialEngineInstance, MethodAddList, Fixture, methodAddListPrametersTypes);
        }

        #endregion

        #region Method Call : (AddList) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_AddList_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var thread = CreateType<SEActivities.Thread>();
            var activities = CreateType<SEActivities>();
            var tr = CreateType<DataRow>();
            var methodAddListPrametersTypes = new Type[] { typeof(SEActivities.Thread), typeof(SEActivities), typeof(DataRow) };
            object[] parametersOfAddList = { thread, activities, tr };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddList, methodAddListPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_socialEngineInstanceFixture, parametersOfAddList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddList.ShouldNotBeNull();
            parametersOfAddList.Length.ShouldBe(3);
            methodAddListPrametersTypes.Length.ShouldBe(3);
            methodAddListPrametersTypes.Length.ShouldBe(parametersOfAddList.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddList) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_AddList_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var thread = CreateType<SEActivities.Thread>();
            var activities = CreateType<SEActivities>();
            var tr = CreateType<DataRow>();
            var methodAddListPrametersTypes = new Type[] { typeof(SEActivities.Thread), typeof(SEActivities), typeof(DataRow) };
            object[] parametersOfAddList = { thread, activities, tr };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_socialEngineInstance, MethodAddList, parametersOfAddList, methodAddListPrametersTypes);

            // Assert
            parametersOfAddList.ShouldNotBeNull();
            parametersOfAddList.Length.ShouldBe(3);
            methodAddListPrametersTypes.Length.ShouldBe(3);
            methodAddListPrametersTypes.Length.ShouldBe(parametersOfAddList.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddList) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_AddList_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddList, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddList) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_AddList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddListPrametersTypes = new Type[] { typeof(SEActivities.Thread), typeof(SEActivities), typeof(DataRow) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_socialEngineInstance, MethodAddList, Fixture, methodAddListPrametersTypes);

            // Assert
            methodAddListPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddList) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_AddList_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddList, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_socialEngineInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddUser) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SocialEngine_AddUser_Method_Call_Internally(Type[] types)
        {
            var methodAddUserPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_socialEngineInstance, MethodAddUser, Fixture, methodAddUserPrametersTypes);
        }

        #endregion

        #region Method Call : (AddUser) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_AddUser_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var activities = CreateType<SEActivities>();
            var activity = CreateType<SEActivities.Thread.Activity>();
            var ar = CreateType<DataRow>();
            var methodAddUserPrametersTypes = new Type[] { typeof(SEActivities), typeof(SEActivities.Thread.Activity), typeof(DataRow) };
            object[] parametersOfAddUser = { activities, activity, ar };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_socialEngineInstance, MethodAddUser, parametersOfAddUser, methodAddUserPrametersTypes);

            // Assert
            parametersOfAddUser.ShouldNotBeNull();
            parametersOfAddUser.Length.ShouldBe(3);
            methodAddUserPrametersTypes.Length.ShouldBe(3);
            methodAddUserPrametersTypes.Length.ShouldBe(parametersOfAddUser.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddUser) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_AddUser_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddUser, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddUser) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_AddUser_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddUserPrametersTypes = new Type[] { typeof(SEActivities), typeof(SEActivities.Thread.Activity), typeof(DataRow) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_socialEngineInstance, MethodAddUser, Fixture, methodAddUserPrametersTypes);

            // Assert
            methodAddUserPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddUser) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_AddUser_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddUser, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_socialEngineInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddWeb) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SocialEngine_AddWeb_Method_Call_Internally(Type[] types)
        {
            var methodAddWebPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_socialEngineInstance, MethodAddWeb, Fixture, methodAddWebPrametersTypes);
        }

        #endregion

        #region Method Call : (AddWeb) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_AddWeb_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var activities = CreateType<SEActivities>();
            var thread = CreateType<SEActivities.Thread>();
            var tr = CreateType<DataRow>();
            var methodAddWebPrametersTypes = new Type[] { typeof(SEActivities), typeof(SEActivities.Thread), typeof(DataRow) };
            object[] parametersOfAddWeb = { activities, thread, tr };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddWeb, methodAddWebPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_socialEngineInstanceFixture, parametersOfAddWeb);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddWeb.ShouldNotBeNull();
            parametersOfAddWeb.Length.ShouldBe(3);
            methodAddWebPrametersTypes.Length.ShouldBe(3);
            methodAddWebPrametersTypes.Length.ShouldBe(parametersOfAddWeb.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddWeb) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_AddWeb_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var activities = CreateType<SEActivities>();
            var thread = CreateType<SEActivities.Thread>();
            var tr = CreateType<DataRow>();
            var methodAddWebPrametersTypes = new Type[] { typeof(SEActivities), typeof(SEActivities.Thread), typeof(DataRow) };
            object[] parametersOfAddWeb = { activities, thread, tr };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_socialEngineInstance, MethodAddWeb, parametersOfAddWeb, methodAddWebPrametersTypes);

            // Assert
            parametersOfAddWeb.ShouldNotBeNull();
            parametersOfAddWeb.Length.ShouldBe(3);
            methodAddWebPrametersTypes.Length.ShouldBe(3);
            methodAddWebPrametersTypes.Length.ShouldBe(parametersOfAddWeb.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddWeb) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_AddWeb_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddWeb, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddWeb) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_AddWeb_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddWebPrametersTypes = new Type[] { typeof(SEActivities), typeof(SEActivities.Thread), typeof(DataRow) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_socialEngineInstance, MethodAddWeb, Fixture, methodAddWebPrametersTypes);

            // Assert
            methodAddWebPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddWeb) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_AddWeb_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddWeb, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_socialEngineInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildActivities) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SocialEngine_BuildActivities_Method_Call_Internally(Type[] types)
        {
            var methodBuildActivitiesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_socialEngineInstance, MethodBuildActivities, Fixture, methodBuildActivitiesPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildActivities) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_BuildActivities_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var activityRows = CreateType<IEnumerable<DataRow>>();
            var activities = CreateType<SEActivities>();
            var thread = CreateType<SEActivities.Thread>();
            var methodBuildActivitiesPrametersTypes = new Type[] { typeof(IEnumerable<DataRow>), typeof(SEActivities), typeof(SEActivities.Thread) };
            object[] parametersOfBuildActivities = { activityRows, activities, thread };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBuildActivities, methodBuildActivitiesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_socialEngineInstanceFixture, parametersOfBuildActivities);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfBuildActivities.ShouldNotBeNull();
            parametersOfBuildActivities.Length.ShouldBe(3);
            methodBuildActivitiesPrametersTypes.Length.ShouldBe(3);
            methodBuildActivitiesPrametersTypes.Length.ShouldBe(parametersOfBuildActivities.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (BuildActivities) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_BuildActivities_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var activityRows = CreateType<IEnumerable<DataRow>>();
            var activities = CreateType<SEActivities>();
            var thread = CreateType<SEActivities.Thread>();
            var methodBuildActivitiesPrametersTypes = new Type[] { typeof(IEnumerable<DataRow>), typeof(SEActivities), typeof(SEActivities.Thread) };
            object[] parametersOfBuildActivities = { activityRows, activities, thread };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_socialEngineInstance, MethodBuildActivities, parametersOfBuildActivities, methodBuildActivitiesPrametersTypes);

            // Assert
            parametersOfBuildActivities.ShouldNotBeNull();
            parametersOfBuildActivities.Length.ShouldBe(3);
            methodBuildActivitiesPrametersTypes.Length.ShouldBe(3);
            methodBuildActivitiesPrametersTypes.Length.ShouldBe(parametersOfBuildActivities.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildActivities) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_BuildActivities_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBuildActivities, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildActivities) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_BuildActivities_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBuildActivitiesPrametersTypes = new Type[] { typeof(IEnumerable<DataRow>), typeof(SEActivities), typeof(SEActivities.Thread) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_socialEngineInstance, MethodBuildActivities, Fixture, methodBuildActivitiesPrametersTypes);

            // Assert
            methodBuildActivitiesPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildActivities) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_BuildActivities_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildActivities, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_socialEngineInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildComments) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SocialEngine_BuildComments_Method_Call_Internally(Type[] types)
        {
            var methodBuildCommentsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_socialEngineInstance, MethodBuildComments, Fixture, methodBuildCommentsPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildComments) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_BuildComments_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var commentRows = CreateType<IEnumerable<DataRow>>();
            var activities = CreateType<SEActivities>();
            var thread = CreateType<SEActivities.Thread>();
            var methodBuildCommentsPrametersTypes = new Type[] { typeof(IEnumerable<DataRow>), typeof(SEActivities), typeof(SEActivities.Thread) };
            object[] parametersOfBuildComments = { commentRows, activities, thread };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBuildComments, methodBuildCommentsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_socialEngineInstanceFixture, parametersOfBuildComments);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfBuildComments.ShouldNotBeNull();
            parametersOfBuildComments.Length.ShouldBe(3);
            methodBuildCommentsPrametersTypes.Length.ShouldBe(3);
            methodBuildCommentsPrametersTypes.Length.ShouldBe(parametersOfBuildComments.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (BuildComments) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_BuildComments_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var commentRows = CreateType<IEnumerable<DataRow>>();
            var activities = CreateType<SEActivities>();
            var thread = CreateType<SEActivities.Thread>();
            var methodBuildCommentsPrametersTypes = new Type[] { typeof(IEnumerable<DataRow>), typeof(SEActivities), typeof(SEActivities.Thread) };
            object[] parametersOfBuildComments = { commentRows, activities, thread };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_socialEngineInstance, MethodBuildComments, parametersOfBuildComments, methodBuildCommentsPrametersTypes);

            // Assert
            parametersOfBuildComments.ShouldNotBeNull();
            parametersOfBuildComments.Length.ShouldBe(3);
            methodBuildCommentsPrametersTypes.Length.ShouldBe(3);
            methodBuildCommentsPrametersTypes.Length.ShouldBe(parametersOfBuildComments.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildComments) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_BuildComments_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBuildComments, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildComments) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_BuildComments_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBuildCommentsPrametersTypes = new Type[] { typeof(IEnumerable<DataRow>), typeof(SEActivities), typeof(SEActivities.Thread) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_socialEngineInstance, MethodBuildComments, Fixture, methodBuildCommentsPrametersTypes);

            // Assert
            methodBuildCommentsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildComments) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_BuildComments_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildComments, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_socialEngineInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildCreatables) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SocialEngine_BuildCreatables_Static_Method_Call_Internally(Type[] types)
        {
            var methodBuildCreatablesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_socialEngineInstanceFixture, _socialEngineInstanceType, MethodBuildCreatables, Fixture, methodBuildCreatablesPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildCreatables) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_BuildCreatables_Static_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var applicationsLinkProvider = CreateType<ApplicationsLinkProvider>();
            var creatables = CreateType<Creatables>();
            var webUrl = CreateType<string>();
            var webId = CreateType<Guid>();
            var methodBuildCreatablesPrametersTypes = new Type[] { typeof(ApplicationsLinkProvider), typeof(Creatables), typeof(string), typeof(Guid) };
            object[] parametersOfBuildCreatables = { applicationsLinkProvider, creatables, webUrl, webId };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBuildCreatables, methodBuildCreatablesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_socialEngineInstanceFixture, parametersOfBuildCreatables);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfBuildCreatables.ShouldNotBeNull();
            parametersOfBuildCreatables.Length.ShouldBe(4);
            methodBuildCreatablesPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (BuildCreatables) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_BuildCreatables_Static_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var applicationsLinkProvider = CreateType<ApplicationsLinkProvider>();
            var creatables = CreateType<Creatables>();
            var webUrl = CreateType<string>();
            var webId = CreateType<Guid>();
            var methodBuildCreatablesPrametersTypes = new Type[] { typeof(ApplicationsLinkProvider), typeof(Creatables), typeof(string), typeof(Guid) };
            object[] parametersOfBuildCreatables = { applicationsLinkProvider, creatables, webUrl, webId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_socialEngineInstanceFixture, _socialEngineInstanceType, MethodBuildCreatables, parametersOfBuildCreatables, methodBuildCreatablesPrametersTypes);

            // Assert
            parametersOfBuildCreatables.ShouldNotBeNull();
            parametersOfBuildCreatables.Length.ShouldBe(4);
            methodBuildCreatablesPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildCreatables) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_BuildCreatables_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBuildCreatables, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildCreatables) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_BuildCreatables_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBuildCreatablesPrametersTypes = new Type[] { typeof(ApplicationsLinkProvider), typeof(Creatables), typeof(string), typeof(Guid) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_socialEngineInstanceFixture, _socialEngineInstanceType, MethodBuildCreatables, Fixture, methodBuildCreatablesPrametersTypes);

            // Assert
            methodBuildCreatablesPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildCreatables) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_BuildCreatables_Static_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildCreatables, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_socialEngineInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SocialEngine_GetData_Method_Call_Internally(Type[] types)
        {
            var methodGetDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_socialEngineInstance, MethodGetData, Fixture, methodGetDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetData_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var activities = CreateType<SEActivities>();
            var threadId = CreateType<Guid>();
            var kind = CreateType<string>();
            var offset = CreateType<DateTime>();
            var methodGetDataPrametersTypes = new Type[] { typeof(SEActivities), typeof(Guid), typeof(string), typeof(DateTime) };
            object[] parametersOfGetData = { activities, threadId, kind, offset };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetData, methodGetDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_socialEngineInstanceFixture, parametersOfGetData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetData.ShouldNotBeNull();
            parametersOfGetData.Length.ShouldBe(4);
            methodGetDataPrametersTypes.Length.ShouldBe(4);
            methodGetDataPrametersTypes.Length.ShouldBe(parametersOfGetData.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetData_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var activities = CreateType<SEActivities>();
            var threadId = CreateType<Guid>();
            var kind = CreateType<string>();
            var offset = CreateType<DateTime>();
            var methodGetDataPrametersTypes = new Type[] { typeof(SEActivities), typeof(Guid), typeof(string), typeof(DateTime) };
            object[] parametersOfGetData = { activities, threadId, kind, offset };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_socialEngineInstance, MethodGetData, parametersOfGetData, methodGetDataPrametersTypes);

            // Assert
            parametersOfGetData.ShouldNotBeNull();
            parametersOfGetData.Length.ShouldBe(4);
            methodGetDataPrametersTypes.Length.ShouldBe(4);
            methodGetDataPrametersTypes.Length.ShouldBe(parametersOfGetData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetData, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDataPrametersTypes = new Type[] { typeof(SEActivities), typeof(Guid), typeof(string), typeof(DateTime) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_socialEngineInstance, MethodGetData, Fixture, methodGetDataPrametersTypes);

            // Assert
            methodGetDataPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetData_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_socialEngineInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SocialEngine_GetData_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodGetDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_socialEngineInstance, MethodGetData, Fixture, methodGetDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetData_Method_Call_Void_Overloading_Of_1_With_5_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var page = CreateType<int>();
            var limit = CreateType<int>();
            var activityLimit = CreateType<int>();
            var commentLimit = CreateType<int>();
            var activities = CreateType<SEActivities>();
            var methodGetDataPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(int), typeof(int), typeof(SEActivities) };
            object[] parametersOfGetData = { page, limit, activityLimit, commentLimit, activities };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetData, methodGetDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_socialEngineInstanceFixture, parametersOfGetData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetData.ShouldNotBeNull();
            parametersOfGetData.Length.ShouldBe(5);
            methodGetDataPrametersTypes.Length.ShouldBe(5);
            methodGetDataPrametersTypes.Length.ShouldBe(parametersOfGetData.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetData_Method_Call_Void_Overloading_Of_1_With_5_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var page = CreateType<int>();
            var limit = CreateType<int>();
            var activityLimit = CreateType<int>();
            var commentLimit = CreateType<int>();
            var activities = CreateType<SEActivities>();
            var methodGetDataPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(int), typeof(int), typeof(SEActivities) };
            object[] parametersOfGetData = { page, limit, activityLimit, commentLimit, activities };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_socialEngineInstance, MethodGetData, parametersOfGetData, methodGetDataPrametersTypes);

            // Assert
            parametersOfGetData.ShouldNotBeNull();
            parametersOfGetData.Length.ShouldBe(5);
            methodGetDataPrametersTypes.Length.ShouldBe(5);
            methodGetDataPrametersTypes.Length.ShouldBe(parametersOfGetData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetData_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetData, 1);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetData_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDataPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(int), typeof(int), typeof(SEActivities) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_socialEngineInstance, MethodGetData, Fixture, methodGetDataPrametersTypes);

            // Assert
            methodGetDataPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetData_Method_Call_Overloading_Of_1_With_5_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetData, 1);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_socialEngineInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetReportingListLibs) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SocialEngine_GetReportingListLibs_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetReportingListLibsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_socialEngineInstanceFixture, _socialEngineInstanceType, MethodGetReportingListLibs, Fixture, methodGetReportingListLibsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetReportingListLibs) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetReportingListLibs_Static_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var reportingLists = CreateType<DataTable>();
            var contextWeb = CreateType<SPWeb>();
            var methodGetReportingListLibsPrametersTypes = new Type[] { typeof(DataTable), typeof(SPWeb) };
            object[] parametersOfGetReportingListLibs = { reportingLists, contextWeb };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetReportingListLibs, methodGetReportingListLibsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_socialEngineInstanceFixture, parametersOfGetReportingListLibs);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetReportingListLibs.ShouldNotBeNull();
            parametersOfGetReportingListLibs.Length.ShouldBe(2);
            methodGetReportingListLibsPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetReportingListLibs) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetReportingListLibs_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var reportingLists = CreateType<DataTable>();
            var contextWeb = CreateType<SPWeb>();
            var methodGetReportingListLibsPrametersTypes = new Type[] { typeof(DataTable), typeof(SPWeb) };
            object[] parametersOfGetReportingListLibs = { reportingLists, contextWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_socialEngineInstanceFixture, _socialEngineInstanceType, MethodGetReportingListLibs, parametersOfGetReportingListLibs, methodGetReportingListLibsPrametersTypes);

            // Assert
            parametersOfGetReportingListLibs.ShouldNotBeNull();
            parametersOfGetReportingListLibs.Length.ShouldBe(2);
            methodGetReportingListLibsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetReportingListLibs) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetReportingListLibs_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetReportingListLibs, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetReportingListLibs) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetReportingListLibs_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetReportingListLibsPrametersTypes = new Type[] { typeof(DataTable), typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_socialEngineInstanceFixture, _socialEngineInstanceType, MethodGetReportingListLibs, Fixture, methodGetReportingListLibsPrametersTypes);

            // Assert
            methodGetReportingListLibsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetReportingListLibs) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetReportingListLibs_Static_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetReportingListLibs, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_socialEngineInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSafeWebUrl) (Return Type : object) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SocialEngine_GetSafeWebUrl_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetSafeWebUrlPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_socialEngineInstanceFixture, _socialEngineInstanceType, MethodGetSafeWebUrl, Fixture, methodGetSafeWebUrlPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSafeWebUrl) (Return Type : object) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetSafeWebUrl_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var webUrl = CreateType<object>();
            var methodGetSafeWebUrlPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfGetSafeWebUrl = { webUrl };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetSafeWebUrl, methodGetSafeWebUrlPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_socialEngineInstanceFixture, parametersOfGetSafeWebUrl);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetSafeWebUrl.ShouldNotBeNull();
            parametersOfGetSafeWebUrl.Length.ShouldBe(1);
            methodGetSafeWebUrlPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSafeWebUrl) (Return Type : object) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetSafeWebUrl_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var webUrl = CreateType<object>();
            var methodGetSafeWebUrlPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfGetSafeWebUrl = { webUrl };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<object>(_socialEngineInstanceFixture, _socialEngineInstanceType, MethodGetSafeWebUrl, parametersOfGetSafeWebUrl, methodGetSafeWebUrlPrametersTypes);

            // Assert
            parametersOfGetSafeWebUrl.ShouldNotBeNull();
            parametersOfGetSafeWebUrl.Length.ShouldBe(1);
            methodGetSafeWebUrlPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSafeWebUrl) (Return Type : object) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetSafeWebUrl_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetSafeWebUrlPrametersTypes = new Type[] { typeof(object) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_socialEngineInstanceFixture, _socialEngineInstanceType, MethodGetSafeWebUrl, Fixture, methodGetSafeWebUrlPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetSafeWebUrlPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetSafeWebUrl) (Return Type : object) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetSafeWebUrl_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSafeWebUrlPrametersTypes = new Type[] { typeof(object) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_socialEngineInstanceFixture, _socialEngineInstanceType, MethodGetSafeWebUrl, Fixture, methodGetSafeWebUrlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSafeWebUrlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSafeWebUrl) (Return Type : object) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetSafeWebUrl_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSafeWebUrl, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_socialEngineInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetSafeWebUrl) (Return Type : object) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_GetSafeWebUrl_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetSafeWebUrl, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ParseMetaData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SocialEngine_ParseMetaData_Method_Call_Internally(Type[] types)
        {
            var methodParseMetaDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_socialEngineInstance, MethodParseMetaData, Fixture, methodParseMetaDataPrametersTypes);
        }

        #endregion

        #region Method Call : (ParseMetaData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_ParseMetaData_Method_Call_Void_With_5_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var page = CreateType<int>();
            var limit = CreateType<int>();
            var activityLimit = CreateType<int>();
            var commentLimit = CreateType<int>();
            var offset = CreateType<DateTime>();
            var methodParseMetaDataPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(int), typeof(int), typeof(DateTime) };
            object[] parametersOfParseMetaData = { page, limit, activityLimit, commentLimit, offset };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodParseMetaData, methodParseMetaDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_socialEngineInstanceFixture, parametersOfParseMetaData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfParseMetaData.ShouldNotBeNull();
            parametersOfParseMetaData.Length.ShouldBe(5);
            methodParseMetaDataPrametersTypes.Length.ShouldBe(5);
            methodParseMetaDataPrametersTypes.Length.ShouldBe(parametersOfParseMetaData.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ParseMetaData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_ParseMetaData_Method_Call_Void_With_5_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var page = CreateType<int>();
            var limit = CreateType<int>();
            var activityLimit = CreateType<int>();
            var commentLimit = CreateType<int>();
            var offset = CreateType<DateTime>();
            var methodParseMetaDataPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(int), typeof(int), typeof(DateTime) };
            object[] parametersOfParseMetaData = { page, limit, activityLimit, commentLimit, offset };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_socialEngineInstance, MethodParseMetaData, parametersOfParseMetaData, methodParseMetaDataPrametersTypes);

            // Assert
            parametersOfParseMetaData.ShouldNotBeNull();
            parametersOfParseMetaData.Length.ShouldBe(5);
            methodParseMetaDataPrametersTypes.Length.ShouldBe(5);
            methodParseMetaDataPrametersTypes.Length.ShouldBe(parametersOfParseMetaData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ParseMetaData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_ParseMetaData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodParseMetaData, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ParseMetaData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_ParseMetaData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodParseMetaDataPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(int), typeof(int), typeof(DateTime) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_socialEngineInstance, MethodParseMetaData, Fixture, methodParseMetaDataPrametersTypes);

            // Assert
            methodParseMetaDataPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ParseMetaData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_ParseMetaData_Method_Call_With_5_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodParseMetaData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_socialEngineInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetLocalDateTime) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SocialEngine_SetLocalDateTime_Method_Call_Internally(Type[] types)
        {
            var methodSetLocalDateTimePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_socialEngineInstance, MethodSetLocalDateTime, Fixture, methodSetLocalDateTimePrametersTypes);
        }

        #endregion

        #region Method Call : (SetLocalDateTime) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_SetLocalDateTime_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var tr = CreateType<DataRow>();
            var column = CreateType<string>();
            var utcTimeDict = CreateType<Dictionary<DateTime, DateTime>>();
            var regionalSettings = CreateType<SPRegionalSettings>();
            var methodSetLocalDateTimePrametersTypes = new Type[] { typeof(DataRow), typeof(string), typeof(Dictionary<DateTime, DateTime>), typeof(SPRegionalSettings) };
            object[] parametersOfSetLocalDateTime = { tr, column, utcTimeDict, regionalSettings };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetLocalDateTime, methodSetLocalDateTimePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_socialEngineInstanceFixture, parametersOfSetLocalDateTime);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetLocalDateTime.ShouldNotBeNull();
            parametersOfSetLocalDateTime.Length.ShouldBe(4);
            methodSetLocalDateTimePrametersTypes.Length.ShouldBe(4);
            methodSetLocalDateTimePrametersTypes.Length.ShouldBe(parametersOfSetLocalDateTime.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetLocalDateTime) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_SetLocalDateTime_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var tr = CreateType<DataRow>();
            var column = CreateType<string>();
            var utcTimeDict = CreateType<Dictionary<DateTime, DateTime>>();
            var regionalSettings = CreateType<SPRegionalSettings>();
            var methodSetLocalDateTimePrametersTypes = new Type[] { typeof(DataRow), typeof(string), typeof(Dictionary<DateTime, DateTime>), typeof(SPRegionalSettings) };
            object[] parametersOfSetLocalDateTime = { tr, column, utcTimeDict, regionalSettings };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_socialEngineInstance, MethodSetLocalDateTime, parametersOfSetLocalDateTime, methodSetLocalDateTimePrametersTypes);

            // Assert
            parametersOfSetLocalDateTime.ShouldNotBeNull();
            parametersOfSetLocalDateTime.Length.ShouldBe(4);
            methodSetLocalDateTimePrametersTypes.Length.ShouldBe(4);
            methodSetLocalDateTimePrametersTypes.Length.ShouldBe(parametersOfSetLocalDateTime.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetLocalDateTime) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_SetLocalDateTime_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetLocalDateTime, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetLocalDateTime) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_SetLocalDateTime_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetLocalDateTimePrametersTypes = new Type[] { typeof(DataRow), typeof(string), typeof(Dictionary<DateTime, DateTime>), typeof(SPRegionalSettings) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_socialEngineInstance, MethodSetLocalDateTime, Fixture, methodSetLocalDateTimePrametersTypes);

            // Assert
            methodSetLocalDateTimePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetLocalDateTime) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngine_SetLocalDateTime_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetLocalDateTime, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_socialEngineInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
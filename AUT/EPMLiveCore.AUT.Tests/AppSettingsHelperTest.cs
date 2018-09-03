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
using EPMLiveCore.Controls.Navigation;
using EPMLiveCore.Controls.Navigation.Providers;
using EPMLiveCore.GlobalResources;
using EPMLiveCore.Infrastructure;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Navigation;
using Microsoft.SharePoint.Utilities;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using AppSettingsHelper = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.AppSettingsHelper" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class AppSettingsHelperTest : AbstractBaseSetupTypedTest<AppSettingsHelper>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (AppSettingsHelper) Initializer

        private const string MethodAppListExists = "AppListExists";
        private const string MethodAppIdExists = "AppIdExists";
        private const string MethodGetMyCurrentAppId = "GetMyCurrentAppId";
        private const string MethodGetDefaultCommunity = "GetDefaultCommunity";
        private const string MethodVerifyCookieId = "VerifyCookieId";
        private const string MethodSetCurrentAppId = "SetCurrentAppId";
        private const string MethodTryGetGlobalNodesByAppId = "TryGetGlobalNodesByAppId";
        private const string MethodTryGetMyAppGlobalNodes = "TryGetMyAppGlobalNodes";
        private const string MethodTryGetMyGlobalNavsForSiteMapProvider = "TryGetMyGlobalNavsForSiteMapProvider";
        private const string MethodTryGetAppGlobalNodesById = "TryGetAppGlobalNodesById";
        private const string MethodTryGetRootChildTopNavIdsByAppId = "TryGetRootChildTopNavIdsByAppId";
        private const string MethodTryGetTopNavIdsByAppId = "TryGetTopNavIdsByAppId";
        private const string MethodTryGetMyAppTopNavIds = "TryGetMyAppTopNavIds";
        private const string MethodTryGetTopNavNodeCollectionById = "TryGetTopNavNodeCollectionById";
        private const string MethodRecursiveFindNavNodeById = "RecursiveFindNavNodeById";
        private const string MethodRecursiveFindNavNodeByTitle = "RecursiveFindNavNodeByTitle";
        private const string MethodTryGetRootChildQuickLaunchIdsByAppId = "TryGetRootChildQuickLaunchIdsByAppId";
        private const string MethodTryGetQuickLaunchIdsByAppId = "TryGetQuickLaunchIdsByAppId";
        private const string MethodTryGetMyAppQuickLaunchIds = "TryGetMyAppQuickLaunchIds";
        private const string MethodTryGetQuickLaunchNodeCollectionById = "TryGetQuickLaunchNodeCollectionById";
        private const string MethodGetAppTopNavLastNodeId = "GetAppTopNavLastNodeId";
        private const string MethodAddAppTopNav = "AddAppTopNav";
        private const string MethodDeleteAppTopNav = "DeleteAppTopNav";
        private const string MethodGetAppQuickLaunchLastNodeId = "GetAppQuickLaunchLastNodeId";
        private const string MethodAddAppQuickLaunch = "AddAppQuickLaunch";
        private const string MethodDeleteAppQuickLaunch = "DeleteAppQuickLaunch";
        private const string MethodGetCurrentAppTitle = "GetCurrentAppTitle";
        private const string MethodGetRealIndex = "GetRealIndex";
        private const string MethodCreateChildNode = "CreateChildNode";
        private const string MethodCreateParentNode = "CreateParentNode";
        private const string MethodEditNodeById = "EditNodeById";
        private const string MethodDeleteNode = "DeleteNode";
        private const string MethodUpdateNodeOrder = "UpdateNodeOrder";
        private const string MethodMoveNode = "MoveNode";
        private const string MethodIsUrlInternal = "IsUrlInternal";
        private const string MethodGetCleanUrl = "GetCleanUrl";
        private const string FieldCurrentAppId = "CurrentAppId";
        private Type _appSettingsHelperInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private AppSettingsHelper _appSettingsHelperInstance;
        private AppSettingsHelper _appSettingsHelperInstanceFixture;

        #region General Initializer : Class (AppSettingsHelper) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="AppSettingsHelper" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _appSettingsHelperInstanceType = typeof(AppSettingsHelper);
            _appSettingsHelperInstanceFixture = Create(true);
            _appSettingsHelperInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (AppSettingsHelper)

        #region General Initializer : Class (AppSettingsHelper) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="AppSettingsHelper" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodAppListExists, 0)]
        [TestCase(MethodAppIdExists, 0)]
        [TestCase(MethodGetMyCurrentAppId, 0)]
        [TestCase(MethodGetDefaultCommunity, 0)]
        [TestCase(MethodVerifyCookieId, 0)]
        [TestCase(MethodSetCurrentAppId, 0)]
        [TestCase(MethodTryGetGlobalNodesByAppId, 0)]
        [TestCase(MethodTryGetMyAppGlobalNodes, 0)]
        [TestCase(MethodTryGetMyGlobalNavsForSiteMapProvider, 0)]
        [TestCase(MethodTryGetAppGlobalNodesById, 0)]
        [TestCase(MethodTryGetRootChildTopNavIdsByAppId, 0)]
        [TestCase(MethodTryGetTopNavIdsByAppId, 0)]
        [TestCase(MethodTryGetMyAppTopNavIds, 0)]
        [TestCase(MethodTryGetTopNavNodeCollectionById, 0)]
        [TestCase(MethodTryGetRootChildQuickLaunchIdsByAppId, 0)]
        [TestCase(MethodTryGetQuickLaunchIdsByAppId, 0)]
        [TestCase(MethodTryGetMyAppQuickLaunchIds, 0)]
        [TestCase(MethodTryGetQuickLaunchNodeCollectionById, 0)]
        [TestCase(MethodGetAppTopNavLastNodeId, 0)]
        [TestCase(MethodAddAppTopNav, 0)]
        [TestCase(MethodDeleteAppTopNav, 0)]
        [TestCase(MethodGetAppQuickLaunchLastNodeId, 0)]
        [TestCase(MethodAddAppQuickLaunch, 0)]
        [TestCase(MethodDeleteAppQuickLaunch, 0)]
        [TestCase(MethodGetCurrentAppTitle, 0)]
        [TestCase(MethodGetRealIndex, 0)]
        [TestCase(MethodCreateChildNode, 0)]
        [TestCase(MethodCreateParentNode, 0)]
        [TestCase(MethodEditNodeById, 0)]
        [TestCase(MethodDeleteNode, 0)]
        [TestCase(MethodUpdateNodeOrder, 0)]
        [TestCase(MethodMoveNode, 0)]
        [TestCase(MethodIsUrlInternal, 0)]
        [TestCase(MethodGetCleanUrl, 0)]
        public void AUT_AppSettingsHelper_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_appSettingsHelperInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (AppSettingsHelper) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="AppSettingsHelper" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldCurrentAppId)]
        public void AUT_AppSettingsHelper_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_appSettingsHelperInstanceFixture, 
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
        ///      Class (<see cref="AppSettingsHelper" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodAppListExists)]
        [TestCase(MethodAppIdExists)]
        [TestCase(MethodGetMyCurrentAppId)]
        [TestCase(MethodGetDefaultCommunity)]
        [TestCase(MethodVerifyCookieId)]
        [TestCase(MethodSetCurrentAppId)]
        [TestCase(MethodTryGetGlobalNodesByAppId)]
        [TestCase(MethodTryGetMyAppGlobalNodes)]
        [TestCase(MethodTryGetMyGlobalNavsForSiteMapProvider)]
        [TestCase(MethodTryGetAppGlobalNodesById)]
        [TestCase(MethodTryGetRootChildTopNavIdsByAppId)]
        [TestCase(MethodTryGetTopNavIdsByAppId)]
        [TestCase(MethodTryGetMyAppTopNavIds)]
        [TestCase(MethodTryGetTopNavNodeCollectionById)]
        [TestCase(MethodTryGetRootChildQuickLaunchIdsByAppId)]
        [TestCase(MethodTryGetQuickLaunchIdsByAppId)]
        [TestCase(MethodTryGetMyAppQuickLaunchIds)]
        [TestCase(MethodTryGetQuickLaunchNodeCollectionById)]
        [TestCase(MethodGetAppTopNavLastNodeId)]
        [TestCase(MethodAddAppTopNav)]
        [TestCase(MethodDeleteAppTopNav)]
        [TestCase(MethodGetAppQuickLaunchLastNodeId)]
        [TestCase(MethodAddAppQuickLaunch)]
        [TestCase(MethodDeleteAppQuickLaunch)]
        [TestCase(MethodGetCurrentAppTitle)]
        [TestCase(MethodGetRealIndex)]
        [TestCase(MethodCreateChildNode)]
        [TestCase(MethodCreateParentNode)]
        [TestCase(MethodEditNodeById)]
        [TestCase(MethodDeleteNode)]
        [TestCase(MethodUpdateNodeOrder)]
        [TestCase(MethodMoveNode)]
        [TestCase(MethodIsUrlInternal)]
        [TestCase(MethodGetCleanUrl)]
        public void AUT_AppSettingsHelper_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<AppSettingsHelper>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (AppListExists) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AppSettingsHelper_AppListExists_Method_Call_Internally(Type[] types)
        {
            var methodAppListExistsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodAppListExists, Fixture, methodAppListExistsPrametersTypes);
        }

        #endregion

        #region Method Call : (AppListExists) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_AppListExists_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _appSettingsHelperInstance.AppListExists();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (AppListExists) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_AppListExists_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodAppListExistsPrametersTypes = null;
            object[] parametersOfAppListExists = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodAppListExists, methodAppListExistsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<AppSettingsHelper, bool>(_appSettingsHelperInstanceFixture, out exception1, parametersOfAppListExists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<AppSettingsHelper, bool>(_appSettingsHelperInstance, MethodAppListExists, parametersOfAppListExists, methodAppListExistsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfAppListExists.ShouldBeNull();
            methodAppListExistsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AppListExists) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_AppListExists_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodAppListExistsPrametersTypes = null;
            object[] parametersOfAppListExists = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodAppListExists, methodAppListExistsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<AppSettingsHelper, bool>(_appSettingsHelperInstanceFixture, out exception1, parametersOfAppListExists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<AppSettingsHelper, bool>(_appSettingsHelperInstance, MethodAppListExists, parametersOfAppListExists, methodAppListExistsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfAppListExists.ShouldBeNull();
            methodAppListExistsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AppListExists) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_AppListExists_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodAppListExistsPrametersTypes = null;
            object[] parametersOfAppListExists = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<AppSettingsHelper, bool>(_appSettingsHelperInstance, MethodAppListExists, parametersOfAppListExists, methodAppListExistsPrametersTypes);

            // Assert
            parametersOfAppListExists.ShouldBeNull();
            methodAppListExistsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AppListExists) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_AppListExists_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodAppListExistsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodAppListExists, Fixture, methodAppListExistsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAppListExistsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AppListExists) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_AppListExists_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAppListExists, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_appSettingsHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AppIdExists) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AppSettingsHelper_AppIdExists_Method_Call_Internally(Type[] types)
        {
            var methodAppIdExistsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodAppIdExists, Fixture, methodAppIdExistsPrametersTypes);
        }

        #endregion

        #region Method Call : (AppIdExists) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_AppIdExists_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _appSettingsHelperInstance.AppIdExists(appId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (AppIdExists) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_AppIdExists_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var methodAppIdExistsPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfAppIdExists = { appId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodAppIdExists, methodAppIdExistsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<AppSettingsHelper, bool>(_appSettingsHelperInstanceFixture, out exception1, parametersOfAppIdExists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<AppSettingsHelper, bool>(_appSettingsHelperInstance, MethodAppIdExists, parametersOfAppIdExists, methodAppIdExistsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfAppIdExists.ShouldNotBeNull();
            parametersOfAppIdExists.Length.ShouldBe(1);
            methodAppIdExistsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (AppIdExists) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_AppIdExists_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var methodAppIdExistsPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfAppIdExists = { appId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodAppIdExists, methodAppIdExistsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<AppSettingsHelper, bool>(_appSettingsHelperInstanceFixture, out exception1, parametersOfAppIdExists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<AppSettingsHelper, bool>(_appSettingsHelperInstance, MethodAppIdExists, parametersOfAppIdExists, methodAppIdExistsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfAppIdExists.ShouldNotBeNull();
            parametersOfAppIdExists.Length.ShouldBe(1);
            methodAppIdExistsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (AppIdExists) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_AppIdExists_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var methodAppIdExistsPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfAppIdExists = { appId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<AppSettingsHelper, bool>(_appSettingsHelperInstance, MethodAppIdExists, parametersOfAppIdExists, methodAppIdExistsPrametersTypes);

            // Assert
            parametersOfAppIdExists.ShouldNotBeNull();
            parametersOfAppIdExists.Length.ShouldBe(1);
            methodAppIdExistsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AppIdExists) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_AppIdExists_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAppIdExistsPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodAppIdExists, Fixture, methodAppIdExistsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAppIdExistsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AppIdExists) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_AppIdExists_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAppIdExists, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_appSettingsHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AppIdExists) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_AppIdExists_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAppIdExists, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMyCurrentAppId) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AppSettingsHelper_GetMyCurrentAppId_Method_Call_Internally(Type[] types)
        {
            var methodGetMyCurrentAppIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodGetMyCurrentAppId, Fixture, methodGetMyCurrentAppIdPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMyCurrentAppId) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetMyCurrentAppId_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _appSettingsHelperInstance.GetMyCurrentAppId();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetMyCurrentAppId) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetMyCurrentAppId_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetMyCurrentAppIdPrametersTypes = null;
            object[] parametersOfGetMyCurrentAppId = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetMyCurrentAppId, methodGetMyCurrentAppIdPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_appSettingsHelperInstanceFixture, parametersOfGetMyCurrentAppId);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetMyCurrentAppId.ShouldBeNull();
            methodGetMyCurrentAppIdPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetMyCurrentAppId) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetMyCurrentAppId_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetMyCurrentAppIdPrametersTypes = null;
            object[] parametersOfGetMyCurrentAppId = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_appSettingsHelperInstance, MethodGetMyCurrentAppId, parametersOfGetMyCurrentAppId, methodGetMyCurrentAppIdPrametersTypes);

            // Assert
            parametersOfGetMyCurrentAppId.ShouldBeNull();
            methodGetMyCurrentAppIdPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetMyCurrentAppId) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetMyCurrentAppId_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetMyCurrentAppIdPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodGetMyCurrentAppId, Fixture, methodGetMyCurrentAppIdPrametersTypes);

            // Assert
            methodGetMyCurrentAppIdPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetMyCurrentAppId) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetMyCurrentAppId_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetMyCurrentAppId, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_appSettingsHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDefaultCommunity) (Return Type : SPListItem) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AppSettingsHelper_GetDefaultCommunity_Method_Call_Internally(Type[] types)
        {
            var methodGetDefaultCommunityPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodGetDefaultCommunity, Fixture, methodGetDefaultCommunityPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDefaultCommunity) (Return Type : SPListItem) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetDefaultCommunity_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var appList = CreateType<SPList>();
            Action executeAction = null;

            // Act
            executeAction = () => _appSettingsHelperInstance.GetDefaultCommunity(appList);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetDefaultCommunity) (Return Type : SPListItem) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetDefaultCommunity_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var appList = CreateType<SPList>();
            var methodGetDefaultCommunityPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfGetDefaultCommunity = { appList };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDefaultCommunity, methodGetDefaultCommunityPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<AppSettingsHelper, SPListItem>(_appSettingsHelperInstanceFixture, out exception1, parametersOfGetDefaultCommunity);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<AppSettingsHelper, SPListItem>(_appSettingsHelperInstance, MethodGetDefaultCommunity, parametersOfGetDefaultCommunity, methodGetDefaultCommunityPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetDefaultCommunity.ShouldNotBeNull();
            parametersOfGetDefaultCommunity.Length.ShouldBe(1);
            methodGetDefaultCommunityPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetDefaultCommunity) (Return Type : SPListItem) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetDefaultCommunity_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var appList = CreateType<SPList>();
            var methodGetDefaultCommunityPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfGetDefaultCommunity = { appList };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<AppSettingsHelper, SPListItem>(_appSettingsHelperInstance, MethodGetDefaultCommunity, parametersOfGetDefaultCommunity, methodGetDefaultCommunityPrametersTypes);

            // Assert
            parametersOfGetDefaultCommunity.ShouldNotBeNull();
            parametersOfGetDefaultCommunity.Length.ShouldBe(1);
            methodGetDefaultCommunityPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDefaultCommunity) (Return Type : SPListItem) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetDefaultCommunity_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetDefaultCommunityPrametersTypes = new Type[] { typeof(SPList) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodGetDefaultCommunity, Fixture, methodGetDefaultCommunityPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDefaultCommunityPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetDefaultCommunity) (Return Type : SPListItem) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetDefaultCommunity_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDefaultCommunityPrametersTypes = new Type[] { typeof(SPList) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodGetDefaultCommunity, Fixture, methodGetDefaultCommunityPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDefaultCommunityPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDefaultCommunity) (Return Type : SPListItem) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetDefaultCommunity_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDefaultCommunity, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_appSettingsHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDefaultCommunity) (Return Type : SPListItem) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetDefaultCommunity_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetDefaultCommunity, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (VerifyCookieId) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AppSettingsHelper_VerifyCookieId_Method_Call_Internally(Type[] types)
        {
            var methodVerifyCookieIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodVerifyCookieId, Fixture, methodVerifyCookieIdPrametersTypes);
        }

        #endregion

        #region Method Call : (VerifyCookieId) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_VerifyCookieId_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _appSettingsHelperInstance.VerifyCookieId();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (VerifyCookieId) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_VerifyCookieId_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodVerifyCookieIdPrametersTypes = null;
            object[] parametersOfVerifyCookieId = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodVerifyCookieId, methodVerifyCookieIdPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_appSettingsHelperInstanceFixture, parametersOfVerifyCookieId);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfVerifyCookieId.ShouldBeNull();
            methodVerifyCookieIdPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (VerifyCookieId) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_VerifyCookieId_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodVerifyCookieIdPrametersTypes = null;
            object[] parametersOfVerifyCookieId = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_appSettingsHelperInstance, MethodVerifyCookieId, parametersOfVerifyCookieId, methodVerifyCookieIdPrametersTypes);

            // Assert
            parametersOfVerifyCookieId.ShouldBeNull();
            methodVerifyCookieIdPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (VerifyCookieId) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_VerifyCookieId_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodVerifyCookieIdPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodVerifyCookieId, Fixture, methodVerifyCookieIdPrametersTypes);

            // Assert
            methodVerifyCookieIdPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (VerifyCookieId) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_VerifyCookieId_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodVerifyCookieId, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_appSettingsHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetCurrentAppId) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AppSettingsHelper_SetCurrentAppId_Method_Call_Internally(Type[] types)
        {
            var methodSetCurrentAppIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodSetCurrentAppId, Fixture, methodSetCurrentAppIdPrametersTypes);
        }

        #endregion

        #region Method Call : (SetCurrentAppId) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_SetCurrentAppId_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _appSettingsHelperInstance.SetCurrentAppId(appId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetCurrentAppId) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_SetCurrentAppId_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var methodSetCurrentAppIdPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfSetCurrentAppId = { appId };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetCurrentAppId, methodSetCurrentAppIdPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_appSettingsHelperInstanceFixture, parametersOfSetCurrentAppId);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetCurrentAppId.ShouldNotBeNull();
            parametersOfSetCurrentAppId.Length.ShouldBe(1);
            methodSetCurrentAppIdPrametersTypes.Length.ShouldBe(1);
            methodSetCurrentAppIdPrametersTypes.Length.ShouldBe(parametersOfSetCurrentAppId.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetCurrentAppId) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_SetCurrentAppId_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var methodSetCurrentAppIdPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfSetCurrentAppId = { appId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_appSettingsHelperInstance, MethodSetCurrentAppId, parametersOfSetCurrentAppId, methodSetCurrentAppIdPrametersTypes);

            // Assert
            parametersOfSetCurrentAppId.ShouldNotBeNull();
            parametersOfSetCurrentAppId.Length.ShouldBe(1);
            methodSetCurrentAppIdPrametersTypes.Length.ShouldBe(1);
            methodSetCurrentAppIdPrametersTypes.Length.ShouldBe(parametersOfSetCurrentAppId.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetCurrentAppId) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_SetCurrentAppId_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetCurrentAppId, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetCurrentAppId) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_SetCurrentAppId_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetCurrentAppIdPrametersTypes = new Type[] { typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodSetCurrentAppId, Fixture, methodSetCurrentAppIdPrametersTypes);

            // Assert
            methodSetCurrentAppIdPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetCurrentAppId) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_SetCurrentAppId_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetCurrentAppId, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_appSettingsHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (TryGetGlobalNodesByAppId) (Return Type : List<int>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AppSettingsHelper_TryGetGlobalNodesByAppId_Method_Call_Internally(Type[] types)
        {
            var methodTryGetGlobalNodesByAppIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodTryGetGlobalNodesByAppId, Fixture, methodTryGetGlobalNodesByAppIdPrametersTypes);
        }

        #endregion

        #region Method Call : (TryGetGlobalNodesByAppId) (Return Type : List<int>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetGlobalNodesByAppId_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _appSettingsHelperInstance.TryGetGlobalNodesByAppId(appId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (TryGetGlobalNodesByAppId) (Return Type : List<int>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetGlobalNodesByAppId_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var methodTryGetGlobalNodesByAppIdPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfTryGetGlobalNodesByAppId = { appId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<AppSettingsHelper, List<int>>(_appSettingsHelperInstance, MethodTryGetGlobalNodesByAppId, parametersOfTryGetGlobalNodesByAppId, methodTryGetGlobalNodesByAppIdPrametersTypes);

            // Assert
            parametersOfTryGetGlobalNodesByAppId.ShouldNotBeNull();
            parametersOfTryGetGlobalNodesByAppId.Length.ShouldBe(1);
            methodTryGetGlobalNodesByAppIdPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (TryGetGlobalNodesByAppId) (Return Type : List<int>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetGlobalNodesByAppId_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodTryGetGlobalNodesByAppIdPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodTryGetGlobalNodesByAppId, Fixture, methodTryGetGlobalNodesByAppIdPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodTryGetGlobalNodesByAppIdPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TryGetGlobalNodesByAppId) (Return Type : List<int>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetGlobalNodesByAppId_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodTryGetGlobalNodesByAppId, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_appSettingsHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (TryGetGlobalNodesByAppId) (Return Type : List<int>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetGlobalNodesByAppId_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodTryGetGlobalNodesByAppId, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TryGetMyAppGlobalNodes) (Return Type : List<int>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AppSettingsHelper_TryGetMyAppGlobalNodes_Method_Call_Internally(Type[] types)
        {
            var methodTryGetMyAppGlobalNodesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodTryGetMyAppGlobalNodes, Fixture, methodTryGetMyAppGlobalNodesPrametersTypes);
        }

        #endregion

        #region Method Call : (TryGetMyAppGlobalNodes) (Return Type : List<int>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetMyAppGlobalNodes_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _appSettingsHelperInstance.TryGetMyAppGlobalNodes();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (TryGetMyAppGlobalNodes) (Return Type : List<int>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetMyAppGlobalNodes_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodTryGetMyAppGlobalNodesPrametersTypes = null;
            object[] parametersOfTryGetMyAppGlobalNodes = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<AppSettingsHelper, List<int>>(_appSettingsHelperInstance, MethodTryGetMyAppGlobalNodes, parametersOfTryGetMyAppGlobalNodes, methodTryGetMyAppGlobalNodesPrametersTypes);

            // Assert
            parametersOfTryGetMyAppGlobalNodes.ShouldBeNull();
            methodTryGetMyAppGlobalNodesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (TryGetMyAppGlobalNodes) (Return Type : List<int>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetMyAppGlobalNodes_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodTryGetMyAppGlobalNodesPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodTryGetMyAppGlobalNodes, Fixture, methodTryGetMyAppGlobalNodesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodTryGetMyAppGlobalNodesPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (TryGetMyAppGlobalNodes) (Return Type : List<int>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetMyAppGlobalNodes_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodTryGetMyAppGlobalNodes, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_appSettingsHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (TryGetMyGlobalNavsForSiteMapProvider) (Return Type : List<int>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AppSettingsHelper_TryGetMyGlobalNavsForSiteMapProvider_Method_Call_Internally(Type[] types)
        {
            var methodTryGetMyGlobalNavsForSiteMapProviderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodTryGetMyGlobalNavsForSiteMapProvider, Fixture, methodTryGetMyGlobalNavsForSiteMapProviderPrametersTypes);
        }

        #endregion

        #region Method Call : (TryGetMyGlobalNavsForSiteMapProvider) (Return Type : List<int>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetMyGlobalNavsForSiteMapProvider_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _appSettingsHelperInstance.TryGetMyGlobalNavsForSiteMapProvider();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (TryGetMyGlobalNavsForSiteMapProvider) (Return Type : List<int>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetMyGlobalNavsForSiteMapProvider_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodTryGetMyGlobalNavsForSiteMapProviderPrametersTypes = null;
            object[] parametersOfTryGetMyGlobalNavsForSiteMapProvider = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<AppSettingsHelper, List<int>>(_appSettingsHelperInstance, MethodTryGetMyGlobalNavsForSiteMapProvider, parametersOfTryGetMyGlobalNavsForSiteMapProvider, methodTryGetMyGlobalNavsForSiteMapProviderPrametersTypes);

            // Assert
            parametersOfTryGetMyGlobalNavsForSiteMapProvider.ShouldBeNull();
            methodTryGetMyGlobalNavsForSiteMapProviderPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (TryGetMyGlobalNavsForSiteMapProvider) (Return Type : List<int>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetMyGlobalNavsForSiteMapProvider_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodTryGetMyGlobalNavsForSiteMapProviderPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodTryGetMyGlobalNavsForSiteMapProvider, Fixture, methodTryGetMyGlobalNavsForSiteMapProviderPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodTryGetMyGlobalNavsForSiteMapProviderPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (TryGetMyGlobalNavsForSiteMapProvider) (Return Type : List<int>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetMyGlobalNavsForSiteMapProvider_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodTryGetMyGlobalNavsForSiteMapProvider, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_appSettingsHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (TryGetAppGlobalNodesById) (Return Type : List<int>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AppSettingsHelper_TryGetAppGlobalNodesById_Method_Call_Internally(Type[] types)
        {
            var methodTryGetAppGlobalNodesByIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodTryGetAppGlobalNodesById, Fixture, methodTryGetAppGlobalNodesByIdPrametersTypes);
        }

        #endregion

        #region Method Call : (TryGetAppGlobalNodesById) (Return Type : List<int>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetAppGlobalNodesById_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _appSettingsHelperInstance.TryGetAppGlobalNodesById(appId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (TryGetAppGlobalNodesById) (Return Type : List<int>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetAppGlobalNodesById_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var methodTryGetAppGlobalNodesByIdPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfTryGetAppGlobalNodesById = { appId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<AppSettingsHelper, List<int>>(_appSettingsHelperInstance, MethodTryGetAppGlobalNodesById, parametersOfTryGetAppGlobalNodesById, methodTryGetAppGlobalNodesByIdPrametersTypes);

            // Assert
            parametersOfTryGetAppGlobalNodesById.ShouldNotBeNull();
            parametersOfTryGetAppGlobalNodesById.Length.ShouldBe(1);
            methodTryGetAppGlobalNodesByIdPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (TryGetAppGlobalNodesById) (Return Type : List<int>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetAppGlobalNodesById_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodTryGetAppGlobalNodesByIdPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodTryGetAppGlobalNodesById, Fixture, methodTryGetAppGlobalNodesByIdPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodTryGetAppGlobalNodesByIdPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TryGetAppGlobalNodesById) (Return Type : List<int>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetAppGlobalNodesById_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodTryGetAppGlobalNodesById, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_appSettingsHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (TryGetAppGlobalNodesById) (Return Type : List<int>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetAppGlobalNodesById_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodTryGetAppGlobalNodesById, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TryGetRootChildTopNavIdsByAppId) (Return Type : List<int>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AppSettingsHelper_TryGetRootChildTopNavIdsByAppId_Method_Call_Internally(Type[] types)
        {
            var methodTryGetRootChildTopNavIdsByAppIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodTryGetRootChildTopNavIdsByAppId, Fixture, methodTryGetRootChildTopNavIdsByAppIdPrametersTypes);
        }

        #endregion

        #region Method Call : (TryGetRootChildTopNavIdsByAppId) (Return Type : List<int>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetRootChildTopNavIdsByAppId_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _appSettingsHelperInstance.TryGetRootChildTopNavIdsByAppId(appId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (TryGetRootChildTopNavIdsByAppId) (Return Type : List<int>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetRootChildTopNavIdsByAppId_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var methodTryGetRootChildTopNavIdsByAppIdPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfTryGetRootChildTopNavIdsByAppId = { appId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<AppSettingsHelper, List<int>>(_appSettingsHelperInstance, MethodTryGetRootChildTopNavIdsByAppId, parametersOfTryGetRootChildTopNavIdsByAppId, methodTryGetRootChildTopNavIdsByAppIdPrametersTypes);

            // Assert
            parametersOfTryGetRootChildTopNavIdsByAppId.ShouldNotBeNull();
            parametersOfTryGetRootChildTopNavIdsByAppId.Length.ShouldBe(1);
            methodTryGetRootChildTopNavIdsByAppIdPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (TryGetRootChildTopNavIdsByAppId) (Return Type : List<int>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetRootChildTopNavIdsByAppId_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodTryGetRootChildTopNavIdsByAppIdPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodTryGetRootChildTopNavIdsByAppId, Fixture, methodTryGetRootChildTopNavIdsByAppIdPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodTryGetRootChildTopNavIdsByAppIdPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TryGetRootChildTopNavIdsByAppId) (Return Type : List<int>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetRootChildTopNavIdsByAppId_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodTryGetRootChildTopNavIdsByAppId, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_appSettingsHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (TryGetRootChildTopNavIdsByAppId) (Return Type : List<int>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetRootChildTopNavIdsByAppId_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodTryGetRootChildTopNavIdsByAppId, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TryGetTopNavIdsByAppId) (Return Type : List<int>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AppSettingsHelper_TryGetTopNavIdsByAppId_Method_Call_Internally(Type[] types)
        {
            var methodTryGetTopNavIdsByAppIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodTryGetTopNavIdsByAppId, Fixture, methodTryGetTopNavIdsByAppIdPrametersTypes);
        }

        #endregion

        #region Method Call : (TryGetTopNavIdsByAppId) (Return Type : List<int>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetTopNavIdsByAppId_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _appSettingsHelperInstance.TryGetTopNavIdsByAppId(appId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (TryGetTopNavIdsByAppId) (Return Type : List<int>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetTopNavIdsByAppId_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var methodTryGetTopNavIdsByAppIdPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfTryGetTopNavIdsByAppId = { appId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<AppSettingsHelper, List<int>>(_appSettingsHelperInstance, MethodTryGetTopNavIdsByAppId, parametersOfTryGetTopNavIdsByAppId, methodTryGetTopNavIdsByAppIdPrametersTypes);

            // Assert
            parametersOfTryGetTopNavIdsByAppId.ShouldNotBeNull();
            parametersOfTryGetTopNavIdsByAppId.Length.ShouldBe(1);
            methodTryGetTopNavIdsByAppIdPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (TryGetTopNavIdsByAppId) (Return Type : List<int>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetTopNavIdsByAppId_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodTryGetTopNavIdsByAppIdPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodTryGetTopNavIdsByAppId, Fixture, methodTryGetTopNavIdsByAppIdPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodTryGetTopNavIdsByAppIdPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TryGetTopNavIdsByAppId) (Return Type : List<int>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetTopNavIdsByAppId_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodTryGetTopNavIdsByAppId, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_appSettingsHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (TryGetTopNavIdsByAppId) (Return Type : List<int>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetTopNavIdsByAppId_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodTryGetTopNavIdsByAppId, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TryGetMyAppTopNavIds) (Return Type : List<int>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AppSettingsHelper_TryGetMyAppTopNavIds_Method_Call_Internally(Type[] types)
        {
            var methodTryGetMyAppTopNavIdsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodTryGetMyAppTopNavIds, Fixture, methodTryGetMyAppTopNavIdsPrametersTypes);
        }

        #endregion

        #region Method Call : (TryGetMyAppTopNavIds) (Return Type : List<int>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetMyAppTopNavIds_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _appSettingsHelperInstance.TryGetMyAppTopNavIds();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (TryGetMyAppTopNavIds) (Return Type : List<int>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetMyAppTopNavIds_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodTryGetMyAppTopNavIdsPrametersTypes = null;
            object[] parametersOfTryGetMyAppTopNavIds = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<AppSettingsHelper, List<int>>(_appSettingsHelperInstance, MethodTryGetMyAppTopNavIds, parametersOfTryGetMyAppTopNavIds, methodTryGetMyAppTopNavIdsPrametersTypes);

            // Assert
            parametersOfTryGetMyAppTopNavIds.ShouldBeNull();
            methodTryGetMyAppTopNavIdsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (TryGetMyAppTopNavIds) (Return Type : List<int>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetMyAppTopNavIds_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodTryGetMyAppTopNavIdsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodTryGetMyAppTopNavIds, Fixture, methodTryGetMyAppTopNavIdsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodTryGetMyAppTopNavIdsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (TryGetMyAppTopNavIds) (Return Type : List<int>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetMyAppTopNavIds_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodTryGetMyAppTopNavIds, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_appSettingsHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (TryGetTopNavNodeCollectionById) (Return Type : List<SPNavigationNode>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AppSettingsHelper_TryGetTopNavNodeCollectionById_Method_Call_Internally(Type[] types)
        {
            var methodTryGetTopNavNodeCollectionByIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodTryGetTopNavNodeCollectionById, Fixture, methodTryGetTopNavNodeCollectionByIdPrametersTypes);
        }

        #endregion

        #region Method Call : (TryGetTopNavNodeCollectionById) (Return Type : List<SPNavigationNode>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetTopNavNodeCollectionById_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _appSettingsHelperInstance.TryGetTopNavNodeCollectionById(appId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (TryGetTopNavNodeCollectionById) (Return Type : List<SPNavigationNode>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetTopNavNodeCollectionById_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var methodTryGetTopNavNodeCollectionByIdPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfTryGetTopNavNodeCollectionById = { appId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodTryGetTopNavNodeCollectionById, methodTryGetTopNavNodeCollectionByIdPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<AppSettingsHelper, List<SPNavigationNode>>(_appSettingsHelperInstanceFixture, out exception1, parametersOfTryGetTopNavNodeCollectionById);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<AppSettingsHelper, List<SPNavigationNode>>(_appSettingsHelperInstance, MethodTryGetTopNavNodeCollectionById, parametersOfTryGetTopNavNodeCollectionById, methodTryGetTopNavNodeCollectionByIdPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfTryGetTopNavNodeCollectionById.ShouldNotBeNull();
            parametersOfTryGetTopNavNodeCollectionById.Length.ShouldBe(1);
            methodTryGetTopNavNodeCollectionByIdPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (TryGetTopNavNodeCollectionById) (Return Type : List<SPNavigationNode>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetTopNavNodeCollectionById_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var methodTryGetTopNavNodeCollectionByIdPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfTryGetTopNavNodeCollectionById = { appId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<AppSettingsHelper, List<SPNavigationNode>>(_appSettingsHelperInstance, MethodTryGetTopNavNodeCollectionById, parametersOfTryGetTopNavNodeCollectionById, methodTryGetTopNavNodeCollectionByIdPrametersTypes);

            // Assert
            parametersOfTryGetTopNavNodeCollectionById.ShouldNotBeNull();
            parametersOfTryGetTopNavNodeCollectionById.Length.ShouldBe(1);
            methodTryGetTopNavNodeCollectionByIdPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (TryGetTopNavNodeCollectionById) (Return Type : List<SPNavigationNode>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetTopNavNodeCollectionById_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodTryGetTopNavNodeCollectionByIdPrametersTypes = new Type[] { typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodTryGetTopNavNodeCollectionById, Fixture, methodTryGetTopNavNodeCollectionByIdPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodTryGetTopNavNodeCollectionByIdPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (TryGetTopNavNodeCollectionById) (Return Type : List<SPNavigationNode>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetTopNavNodeCollectionById_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodTryGetTopNavNodeCollectionByIdPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodTryGetTopNavNodeCollectionById, Fixture, methodTryGetTopNavNodeCollectionByIdPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodTryGetTopNavNodeCollectionByIdPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TryGetTopNavNodeCollectionById) (Return Type : List<SPNavigationNode>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetTopNavNodeCollectionById_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodTryGetTopNavNodeCollectionById, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_appSettingsHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (TryGetTopNavNodeCollectionById) (Return Type : List<SPNavigationNode>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetTopNavNodeCollectionById_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodTryGetTopNavNodeCollectionById, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TryGetRootChildQuickLaunchIdsByAppId) (Return Type : List<int>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AppSettingsHelper_TryGetRootChildQuickLaunchIdsByAppId_Method_Call_Internally(Type[] types)
        {
            var methodTryGetRootChildQuickLaunchIdsByAppIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodTryGetRootChildQuickLaunchIdsByAppId, Fixture, methodTryGetRootChildQuickLaunchIdsByAppIdPrametersTypes);
        }

        #endregion

        #region Method Call : (TryGetRootChildQuickLaunchIdsByAppId) (Return Type : List<int>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetRootChildQuickLaunchIdsByAppId_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _appSettingsHelperInstance.TryGetRootChildQuickLaunchIdsByAppId(appId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (TryGetRootChildQuickLaunchIdsByAppId) (Return Type : List<int>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetRootChildQuickLaunchIdsByAppId_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var methodTryGetRootChildQuickLaunchIdsByAppIdPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfTryGetRootChildQuickLaunchIdsByAppId = { appId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<AppSettingsHelper, List<int>>(_appSettingsHelperInstance, MethodTryGetRootChildQuickLaunchIdsByAppId, parametersOfTryGetRootChildQuickLaunchIdsByAppId, methodTryGetRootChildQuickLaunchIdsByAppIdPrametersTypes);

            // Assert
            parametersOfTryGetRootChildQuickLaunchIdsByAppId.ShouldNotBeNull();
            parametersOfTryGetRootChildQuickLaunchIdsByAppId.Length.ShouldBe(1);
            methodTryGetRootChildQuickLaunchIdsByAppIdPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (TryGetRootChildQuickLaunchIdsByAppId) (Return Type : List<int>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetRootChildQuickLaunchIdsByAppId_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodTryGetRootChildQuickLaunchIdsByAppIdPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodTryGetRootChildQuickLaunchIdsByAppId, Fixture, methodTryGetRootChildQuickLaunchIdsByAppIdPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodTryGetRootChildQuickLaunchIdsByAppIdPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TryGetRootChildQuickLaunchIdsByAppId) (Return Type : List<int>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetRootChildQuickLaunchIdsByAppId_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodTryGetRootChildQuickLaunchIdsByAppId, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_appSettingsHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (TryGetRootChildQuickLaunchIdsByAppId) (Return Type : List<int>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetRootChildQuickLaunchIdsByAppId_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodTryGetRootChildQuickLaunchIdsByAppId, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TryGetQuickLaunchIdsByAppId) (Return Type : List<int>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AppSettingsHelper_TryGetQuickLaunchIdsByAppId_Method_Call_Internally(Type[] types)
        {
            var methodTryGetQuickLaunchIdsByAppIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodTryGetQuickLaunchIdsByAppId, Fixture, methodTryGetQuickLaunchIdsByAppIdPrametersTypes);
        }

        #endregion

        #region Method Call : (TryGetQuickLaunchIdsByAppId) (Return Type : List<int>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetQuickLaunchIdsByAppId_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _appSettingsHelperInstance.TryGetQuickLaunchIdsByAppId(appId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (TryGetQuickLaunchIdsByAppId) (Return Type : List<int>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetQuickLaunchIdsByAppId_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var methodTryGetQuickLaunchIdsByAppIdPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfTryGetQuickLaunchIdsByAppId = { appId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<AppSettingsHelper, List<int>>(_appSettingsHelperInstance, MethodTryGetQuickLaunchIdsByAppId, parametersOfTryGetQuickLaunchIdsByAppId, methodTryGetQuickLaunchIdsByAppIdPrametersTypes);

            // Assert
            parametersOfTryGetQuickLaunchIdsByAppId.ShouldNotBeNull();
            parametersOfTryGetQuickLaunchIdsByAppId.Length.ShouldBe(1);
            methodTryGetQuickLaunchIdsByAppIdPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (TryGetQuickLaunchIdsByAppId) (Return Type : List<int>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetQuickLaunchIdsByAppId_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodTryGetQuickLaunchIdsByAppIdPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodTryGetQuickLaunchIdsByAppId, Fixture, methodTryGetQuickLaunchIdsByAppIdPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodTryGetQuickLaunchIdsByAppIdPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TryGetQuickLaunchIdsByAppId) (Return Type : List<int>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetQuickLaunchIdsByAppId_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodTryGetQuickLaunchIdsByAppId, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_appSettingsHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (TryGetQuickLaunchIdsByAppId) (Return Type : List<int>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetQuickLaunchIdsByAppId_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodTryGetQuickLaunchIdsByAppId, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TryGetMyAppQuickLaunchIds) (Return Type : List<int>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AppSettingsHelper_TryGetMyAppQuickLaunchIds_Method_Call_Internally(Type[] types)
        {
            var methodTryGetMyAppQuickLaunchIdsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodTryGetMyAppQuickLaunchIds, Fixture, methodTryGetMyAppQuickLaunchIdsPrametersTypes);
        }

        #endregion

        #region Method Call : (TryGetMyAppQuickLaunchIds) (Return Type : List<int>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetMyAppQuickLaunchIds_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _appSettingsHelperInstance.TryGetMyAppQuickLaunchIds();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (TryGetMyAppQuickLaunchIds) (Return Type : List<int>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetMyAppQuickLaunchIds_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodTryGetMyAppQuickLaunchIdsPrametersTypes = null;
            object[] parametersOfTryGetMyAppQuickLaunchIds = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<AppSettingsHelper, List<int>>(_appSettingsHelperInstance, MethodTryGetMyAppQuickLaunchIds, parametersOfTryGetMyAppQuickLaunchIds, methodTryGetMyAppQuickLaunchIdsPrametersTypes);

            // Assert
            parametersOfTryGetMyAppQuickLaunchIds.ShouldBeNull();
            methodTryGetMyAppQuickLaunchIdsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (TryGetMyAppQuickLaunchIds) (Return Type : List<int>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetMyAppQuickLaunchIds_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodTryGetMyAppQuickLaunchIdsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodTryGetMyAppQuickLaunchIds, Fixture, methodTryGetMyAppQuickLaunchIdsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodTryGetMyAppQuickLaunchIdsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (TryGetMyAppQuickLaunchIds) (Return Type : List<int>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetMyAppQuickLaunchIds_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodTryGetMyAppQuickLaunchIds, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_appSettingsHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (TryGetQuickLaunchNodeCollectionById) (Return Type : List<SPNavigationNode>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AppSettingsHelper_TryGetQuickLaunchNodeCollectionById_Method_Call_Internally(Type[] types)
        {
            var methodTryGetQuickLaunchNodeCollectionByIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodTryGetQuickLaunchNodeCollectionById, Fixture, methodTryGetQuickLaunchNodeCollectionByIdPrametersTypes);
        }

        #endregion

        #region Method Call : (TryGetQuickLaunchNodeCollectionById) (Return Type : List<SPNavigationNode>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetQuickLaunchNodeCollectionById_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _appSettingsHelperInstance.TryGetQuickLaunchNodeCollectionById(appId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (TryGetQuickLaunchNodeCollectionById) (Return Type : List<SPNavigationNode>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetQuickLaunchNodeCollectionById_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var methodTryGetQuickLaunchNodeCollectionByIdPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfTryGetQuickLaunchNodeCollectionById = { appId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodTryGetQuickLaunchNodeCollectionById, methodTryGetQuickLaunchNodeCollectionByIdPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<AppSettingsHelper, List<SPNavigationNode>>(_appSettingsHelperInstanceFixture, out exception1, parametersOfTryGetQuickLaunchNodeCollectionById);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<AppSettingsHelper, List<SPNavigationNode>>(_appSettingsHelperInstance, MethodTryGetQuickLaunchNodeCollectionById, parametersOfTryGetQuickLaunchNodeCollectionById, methodTryGetQuickLaunchNodeCollectionByIdPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfTryGetQuickLaunchNodeCollectionById.ShouldNotBeNull();
            parametersOfTryGetQuickLaunchNodeCollectionById.Length.ShouldBe(1);
            methodTryGetQuickLaunchNodeCollectionByIdPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (TryGetQuickLaunchNodeCollectionById) (Return Type : List<SPNavigationNode>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetQuickLaunchNodeCollectionById_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var methodTryGetQuickLaunchNodeCollectionByIdPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfTryGetQuickLaunchNodeCollectionById = { appId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<AppSettingsHelper, List<SPNavigationNode>>(_appSettingsHelperInstance, MethodTryGetQuickLaunchNodeCollectionById, parametersOfTryGetQuickLaunchNodeCollectionById, methodTryGetQuickLaunchNodeCollectionByIdPrametersTypes);

            // Assert
            parametersOfTryGetQuickLaunchNodeCollectionById.ShouldNotBeNull();
            parametersOfTryGetQuickLaunchNodeCollectionById.Length.ShouldBe(1);
            methodTryGetQuickLaunchNodeCollectionByIdPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (TryGetQuickLaunchNodeCollectionById) (Return Type : List<SPNavigationNode>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetQuickLaunchNodeCollectionById_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodTryGetQuickLaunchNodeCollectionByIdPrametersTypes = new Type[] { typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodTryGetQuickLaunchNodeCollectionById, Fixture, methodTryGetQuickLaunchNodeCollectionByIdPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodTryGetQuickLaunchNodeCollectionByIdPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (TryGetQuickLaunchNodeCollectionById) (Return Type : List<SPNavigationNode>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetQuickLaunchNodeCollectionById_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodTryGetQuickLaunchNodeCollectionByIdPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodTryGetQuickLaunchNodeCollectionById, Fixture, methodTryGetQuickLaunchNodeCollectionByIdPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodTryGetQuickLaunchNodeCollectionByIdPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TryGetQuickLaunchNodeCollectionById) (Return Type : List<SPNavigationNode>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetQuickLaunchNodeCollectionById_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodTryGetQuickLaunchNodeCollectionById, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_appSettingsHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (TryGetQuickLaunchNodeCollectionById) (Return Type : List<SPNavigationNode>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_TryGetQuickLaunchNodeCollectionById_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodTryGetQuickLaunchNodeCollectionById, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAppTopNavLastNodeId) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AppSettingsHelper_GetAppTopNavLastNodeId_Method_Call_Internally(Type[] types)
        {
            var methodGetAppTopNavLastNodeIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodGetAppTopNavLastNodeId, Fixture, methodGetAppTopNavLastNodeIdPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAppTopNavLastNodeId) (Return Type : int) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetAppTopNavLastNodeId_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _appSettingsHelperInstance.GetAppTopNavLastNodeId(appId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetAppTopNavLastNodeId) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetAppTopNavLastNodeId_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var methodGetAppTopNavLastNodeIdPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfGetAppTopNavLastNodeId = { appId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetAppTopNavLastNodeId, methodGetAppTopNavLastNodeIdPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<AppSettingsHelper, int>(_appSettingsHelperInstanceFixture, out exception1, parametersOfGetAppTopNavLastNodeId);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<AppSettingsHelper, int>(_appSettingsHelperInstance, MethodGetAppTopNavLastNodeId, parametersOfGetAppTopNavLastNodeId, methodGetAppTopNavLastNodeIdPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetAppTopNavLastNodeId.ShouldNotBeNull();
            parametersOfGetAppTopNavLastNodeId.Length.ShouldBe(1);
            methodGetAppTopNavLastNodeIdPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetAppTopNavLastNodeId) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetAppTopNavLastNodeId_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var methodGetAppTopNavLastNodeIdPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfGetAppTopNavLastNodeId = { appId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetAppTopNavLastNodeId, methodGetAppTopNavLastNodeIdPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<AppSettingsHelper, int>(_appSettingsHelperInstanceFixture, out exception1, parametersOfGetAppTopNavLastNodeId);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<AppSettingsHelper, int>(_appSettingsHelperInstance, MethodGetAppTopNavLastNodeId, parametersOfGetAppTopNavLastNodeId, methodGetAppTopNavLastNodeIdPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetAppTopNavLastNodeId.ShouldNotBeNull();
            parametersOfGetAppTopNavLastNodeId.Length.ShouldBe(1);
            methodGetAppTopNavLastNodeIdPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetAppTopNavLastNodeId) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetAppTopNavLastNodeId_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var methodGetAppTopNavLastNodeIdPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfGetAppTopNavLastNodeId = { appId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<AppSettingsHelper, int>(_appSettingsHelperInstance, MethodGetAppTopNavLastNodeId, parametersOfGetAppTopNavLastNodeId, methodGetAppTopNavLastNodeIdPrametersTypes);

            // Assert
            parametersOfGetAppTopNavLastNodeId.ShouldNotBeNull();
            parametersOfGetAppTopNavLastNodeId.Length.ShouldBe(1);
            methodGetAppTopNavLastNodeIdPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAppTopNavLastNodeId) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetAppTopNavLastNodeId_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetAppTopNavLastNodeIdPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodGetAppTopNavLastNodeId, Fixture, methodGetAppTopNavLastNodeIdPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetAppTopNavLastNodeIdPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAppTopNavLastNodeId) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetAppTopNavLastNodeId_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetAppTopNavLastNodeId, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_appSettingsHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAppTopNavLastNodeId) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetAppTopNavLastNodeId_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetAppTopNavLastNodeId, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddAppTopNav) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AppSettingsHelper_AddAppTopNav_Method_Call_Internally(Type[] types)
        {
            var methodAddAppTopNavPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodAddAppTopNav, Fixture, methodAddAppTopNavPrametersTypes);
        }

        #endregion

        #region Method Call : (AddAppTopNav) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_AddAppTopNav_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var navId = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _appSettingsHelperInstance.AddAppTopNav(appId, navId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (AddAppTopNav) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_AddAppTopNav_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var navId = CreateType<int>();
            var methodAddAppTopNavPrametersTypes = new Type[] { typeof(int), typeof(int) };
            object[] parametersOfAddAppTopNav = { appId, navId };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddAppTopNav, methodAddAppTopNavPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_appSettingsHelperInstanceFixture, parametersOfAddAppTopNav);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddAppTopNav.ShouldNotBeNull();
            parametersOfAddAppTopNav.Length.ShouldBe(2);
            methodAddAppTopNavPrametersTypes.Length.ShouldBe(2);
            methodAddAppTopNavPrametersTypes.Length.ShouldBe(parametersOfAddAppTopNav.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddAppTopNav) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_AddAppTopNav_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var navId = CreateType<int>();
            var methodAddAppTopNavPrametersTypes = new Type[] { typeof(int), typeof(int) };
            object[] parametersOfAddAppTopNav = { appId, navId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_appSettingsHelperInstance, MethodAddAppTopNav, parametersOfAddAppTopNav, methodAddAppTopNavPrametersTypes);

            // Assert
            parametersOfAddAppTopNav.ShouldNotBeNull();
            parametersOfAddAppTopNav.Length.ShouldBe(2);
            methodAddAppTopNavPrametersTypes.Length.ShouldBe(2);
            methodAddAppTopNavPrametersTypes.Length.ShouldBe(parametersOfAddAppTopNav.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddAppTopNav) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_AddAppTopNav_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddAppTopNav, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddAppTopNav) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_AddAppTopNav_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddAppTopNavPrametersTypes = new Type[] { typeof(int), typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodAddAppTopNav, Fixture, methodAddAppTopNavPrametersTypes);

            // Assert
            methodAddAppTopNavPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddAppTopNav) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_AddAppTopNav_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddAppTopNav, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_appSettingsHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteAppTopNav) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AppSettingsHelper_DeleteAppTopNav_Method_Call_Internally(Type[] types)
        {
            var methodDeleteAppTopNavPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodDeleteAppTopNav, Fixture, methodDeleteAppTopNavPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteAppTopNav) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_DeleteAppTopNav_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var navId = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _appSettingsHelperInstance.DeleteAppTopNav(appId, navId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteAppTopNav) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_DeleteAppTopNav_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var navId = CreateType<int>();
            var methodDeleteAppTopNavPrametersTypes = new Type[] { typeof(int), typeof(int) };
            object[] parametersOfDeleteAppTopNav = { appId, navId };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDeleteAppTopNav, methodDeleteAppTopNavPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_appSettingsHelperInstanceFixture, parametersOfDeleteAppTopNav);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDeleteAppTopNav.ShouldNotBeNull();
            parametersOfDeleteAppTopNav.Length.ShouldBe(2);
            methodDeleteAppTopNavPrametersTypes.Length.ShouldBe(2);
            methodDeleteAppTopNavPrametersTypes.Length.ShouldBe(parametersOfDeleteAppTopNav.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DeleteAppTopNav) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_DeleteAppTopNav_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var navId = CreateType<int>();
            var methodDeleteAppTopNavPrametersTypes = new Type[] { typeof(int), typeof(int) };
            object[] parametersOfDeleteAppTopNav = { appId, navId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_appSettingsHelperInstance, MethodDeleteAppTopNav, parametersOfDeleteAppTopNav, methodDeleteAppTopNavPrametersTypes);

            // Assert
            parametersOfDeleteAppTopNav.ShouldNotBeNull();
            parametersOfDeleteAppTopNav.Length.ShouldBe(2);
            methodDeleteAppTopNavPrametersTypes.Length.ShouldBe(2);
            methodDeleteAppTopNavPrametersTypes.Length.ShouldBe(parametersOfDeleteAppTopNav.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteAppTopNav) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_DeleteAppTopNav_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteAppTopNav, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteAppTopNav) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_DeleteAppTopNav_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteAppTopNavPrametersTypes = new Type[] { typeof(int), typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodDeleteAppTopNav, Fixture, methodDeleteAppTopNavPrametersTypes);

            // Assert
            methodDeleteAppTopNavPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteAppTopNav) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_DeleteAppTopNav_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteAppTopNav, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_appSettingsHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAppQuickLaunchLastNodeId) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AppSettingsHelper_GetAppQuickLaunchLastNodeId_Method_Call_Internally(Type[] types)
        {
            var methodGetAppQuickLaunchLastNodeIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodGetAppQuickLaunchLastNodeId, Fixture, methodGetAppQuickLaunchLastNodeIdPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAppQuickLaunchLastNodeId) (Return Type : int) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetAppQuickLaunchLastNodeId_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _appSettingsHelperInstance.GetAppQuickLaunchLastNodeId(appId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetAppQuickLaunchLastNodeId) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetAppQuickLaunchLastNodeId_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var methodGetAppQuickLaunchLastNodeIdPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfGetAppQuickLaunchLastNodeId = { appId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetAppQuickLaunchLastNodeId, methodGetAppQuickLaunchLastNodeIdPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<AppSettingsHelper, int>(_appSettingsHelperInstanceFixture, out exception1, parametersOfGetAppQuickLaunchLastNodeId);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<AppSettingsHelper, int>(_appSettingsHelperInstance, MethodGetAppQuickLaunchLastNodeId, parametersOfGetAppQuickLaunchLastNodeId, methodGetAppQuickLaunchLastNodeIdPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetAppQuickLaunchLastNodeId.ShouldNotBeNull();
            parametersOfGetAppQuickLaunchLastNodeId.Length.ShouldBe(1);
            methodGetAppQuickLaunchLastNodeIdPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetAppQuickLaunchLastNodeId) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetAppQuickLaunchLastNodeId_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var methodGetAppQuickLaunchLastNodeIdPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfGetAppQuickLaunchLastNodeId = { appId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetAppQuickLaunchLastNodeId, methodGetAppQuickLaunchLastNodeIdPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<AppSettingsHelper, int>(_appSettingsHelperInstanceFixture, out exception1, parametersOfGetAppQuickLaunchLastNodeId);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<AppSettingsHelper, int>(_appSettingsHelperInstance, MethodGetAppQuickLaunchLastNodeId, parametersOfGetAppQuickLaunchLastNodeId, methodGetAppQuickLaunchLastNodeIdPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetAppQuickLaunchLastNodeId.ShouldNotBeNull();
            parametersOfGetAppQuickLaunchLastNodeId.Length.ShouldBe(1);
            methodGetAppQuickLaunchLastNodeIdPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetAppQuickLaunchLastNodeId) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetAppQuickLaunchLastNodeId_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var methodGetAppQuickLaunchLastNodeIdPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfGetAppQuickLaunchLastNodeId = { appId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<AppSettingsHelper, int>(_appSettingsHelperInstance, MethodGetAppQuickLaunchLastNodeId, parametersOfGetAppQuickLaunchLastNodeId, methodGetAppQuickLaunchLastNodeIdPrametersTypes);

            // Assert
            parametersOfGetAppQuickLaunchLastNodeId.ShouldNotBeNull();
            parametersOfGetAppQuickLaunchLastNodeId.Length.ShouldBe(1);
            methodGetAppQuickLaunchLastNodeIdPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAppQuickLaunchLastNodeId) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetAppQuickLaunchLastNodeId_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetAppQuickLaunchLastNodeIdPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodGetAppQuickLaunchLastNodeId, Fixture, methodGetAppQuickLaunchLastNodeIdPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetAppQuickLaunchLastNodeIdPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAppQuickLaunchLastNodeId) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetAppQuickLaunchLastNodeId_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetAppQuickLaunchLastNodeId, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_appSettingsHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAppQuickLaunchLastNodeId) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetAppQuickLaunchLastNodeId_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetAppQuickLaunchLastNodeId, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddAppQuickLaunch) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AppSettingsHelper_AddAppQuickLaunch_Method_Call_Internally(Type[] types)
        {
            var methodAddAppQuickLaunchPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodAddAppQuickLaunch, Fixture, methodAddAppQuickLaunchPrametersTypes);
        }

        #endregion

        #region Method Call : (AddAppQuickLaunch) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_AddAppQuickLaunch_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var navId = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _appSettingsHelperInstance.AddAppQuickLaunch(appId, navId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (AddAppQuickLaunch) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_AddAppQuickLaunch_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var navId = CreateType<int>();
            var methodAddAppQuickLaunchPrametersTypes = new Type[] { typeof(int), typeof(int) };
            object[] parametersOfAddAppQuickLaunch = { appId, navId };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddAppQuickLaunch, methodAddAppQuickLaunchPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_appSettingsHelperInstanceFixture, parametersOfAddAppQuickLaunch);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddAppQuickLaunch.ShouldNotBeNull();
            parametersOfAddAppQuickLaunch.Length.ShouldBe(2);
            methodAddAppQuickLaunchPrametersTypes.Length.ShouldBe(2);
            methodAddAppQuickLaunchPrametersTypes.Length.ShouldBe(parametersOfAddAppQuickLaunch.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddAppQuickLaunch) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_AddAppQuickLaunch_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var navId = CreateType<int>();
            var methodAddAppQuickLaunchPrametersTypes = new Type[] { typeof(int), typeof(int) };
            object[] parametersOfAddAppQuickLaunch = { appId, navId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_appSettingsHelperInstance, MethodAddAppQuickLaunch, parametersOfAddAppQuickLaunch, methodAddAppQuickLaunchPrametersTypes);

            // Assert
            parametersOfAddAppQuickLaunch.ShouldNotBeNull();
            parametersOfAddAppQuickLaunch.Length.ShouldBe(2);
            methodAddAppQuickLaunchPrametersTypes.Length.ShouldBe(2);
            methodAddAppQuickLaunchPrametersTypes.Length.ShouldBe(parametersOfAddAppQuickLaunch.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddAppQuickLaunch) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_AddAppQuickLaunch_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddAppQuickLaunch, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddAppQuickLaunch) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_AddAppQuickLaunch_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddAppQuickLaunchPrametersTypes = new Type[] { typeof(int), typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodAddAppQuickLaunch, Fixture, methodAddAppQuickLaunchPrametersTypes);

            // Assert
            methodAddAppQuickLaunchPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddAppQuickLaunch) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_AddAppQuickLaunch_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddAppQuickLaunch, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_appSettingsHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteAppQuickLaunch) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AppSettingsHelper_DeleteAppQuickLaunch_Method_Call_Internally(Type[] types)
        {
            var methodDeleteAppQuickLaunchPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodDeleteAppQuickLaunch, Fixture, methodDeleteAppQuickLaunchPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteAppQuickLaunch) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_DeleteAppQuickLaunch_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var navId = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _appSettingsHelperInstance.DeleteAppQuickLaunch(appId, navId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteAppQuickLaunch) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_DeleteAppQuickLaunch_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var navId = CreateType<int>();
            var methodDeleteAppQuickLaunchPrametersTypes = new Type[] { typeof(int), typeof(int) };
            object[] parametersOfDeleteAppQuickLaunch = { appId, navId };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDeleteAppQuickLaunch, methodDeleteAppQuickLaunchPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_appSettingsHelperInstanceFixture, parametersOfDeleteAppQuickLaunch);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDeleteAppQuickLaunch.ShouldNotBeNull();
            parametersOfDeleteAppQuickLaunch.Length.ShouldBe(2);
            methodDeleteAppQuickLaunchPrametersTypes.Length.ShouldBe(2);
            methodDeleteAppQuickLaunchPrametersTypes.Length.ShouldBe(parametersOfDeleteAppQuickLaunch.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DeleteAppQuickLaunch) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_DeleteAppQuickLaunch_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var navId = CreateType<int>();
            var methodDeleteAppQuickLaunchPrametersTypes = new Type[] { typeof(int), typeof(int) };
            object[] parametersOfDeleteAppQuickLaunch = { appId, navId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_appSettingsHelperInstance, MethodDeleteAppQuickLaunch, parametersOfDeleteAppQuickLaunch, methodDeleteAppQuickLaunchPrametersTypes);

            // Assert
            parametersOfDeleteAppQuickLaunch.ShouldNotBeNull();
            parametersOfDeleteAppQuickLaunch.Length.ShouldBe(2);
            methodDeleteAppQuickLaunchPrametersTypes.Length.ShouldBe(2);
            methodDeleteAppQuickLaunchPrametersTypes.Length.ShouldBe(parametersOfDeleteAppQuickLaunch.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteAppQuickLaunch) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_DeleteAppQuickLaunch_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteAppQuickLaunch, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteAppQuickLaunch) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_DeleteAppQuickLaunch_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteAppQuickLaunchPrametersTypes = new Type[] { typeof(int), typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodDeleteAppQuickLaunch, Fixture, methodDeleteAppQuickLaunchPrametersTypes);

            // Assert
            methodDeleteAppQuickLaunchPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteAppQuickLaunch) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_DeleteAppQuickLaunch_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteAppQuickLaunch, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_appSettingsHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCurrentAppTitle) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AppSettingsHelper_GetCurrentAppTitle_Method_Call_Internally(Type[] types)
        {
            var methodGetCurrentAppTitlePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodGetCurrentAppTitle, Fixture, methodGetCurrentAppTitlePrametersTypes);
        }

        #endregion

        #region Method Call : (GetCurrentAppTitle) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetCurrentAppTitle_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _appSettingsHelperInstance.GetCurrentAppTitle();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetCurrentAppTitle) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetCurrentAppTitle_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetCurrentAppTitlePrametersTypes = null;
            object[] parametersOfGetCurrentAppTitle = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetCurrentAppTitle, methodGetCurrentAppTitlePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<AppSettingsHelper, string>(_appSettingsHelperInstanceFixture, out exception1, parametersOfGetCurrentAppTitle);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<AppSettingsHelper, string>(_appSettingsHelperInstance, MethodGetCurrentAppTitle, parametersOfGetCurrentAppTitle, methodGetCurrentAppTitlePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetCurrentAppTitle.ShouldBeNull();
            methodGetCurrentAppTitlePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCurrentAppTitle) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetCurrentAppTitle_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetCurrentAppTitlePrametersTypes = null;
            object[] parametersOfGetCurrentAppTitle = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<AppSettingsHelper, string>(_appSettingsHelperInstance, MethodGetCurrentAppTitle, parametersOfGetCurrentAppTitle, methodGetCurrentAppTitlePrametersTypes);

            // Assert
            parametersOfGetCurrentAppTitle.ShouldBeNull();
            methodGetCurrentAppTitlePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCurrentAppTitle) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetCurrentAppTitle_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetCurrentAppTitlePrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodGetCurrentAppTitle, Fixture, methodGetCurrentAppTitlePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCurrentAppTitlePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCurrentAppTitle) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetCurrentAppTitle_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetCurrentAppTitlePrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodGetCurrentAppTitle, Fixture, methodGetCurrentAppTitlePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCurrentAppTitlePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCurrentAppTitle) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetCurrentAppTitle_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCurrentAppTitle, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_appSettingsHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRealIndex) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AppSettingsHelper_GetRealIndex_Method_Call_Internally(Type[] types)
        {
            var methodGetRealIndexPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodGetRealIndex, Fixture, methodGetRealIndexPrametersTypes);
        }

        #endregion

        #region Method Call : (GetRealIndex) (Return Type : int) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetRealIndex_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var parentNodeId = CreateType<int>();
            var position = CreateType<int>();
            var appId = CreateType<int>();
            var navType = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _appSettingsHelperInstance.GetRealIndex(parentNodeId, position, appId, navType);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetRealIndex) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetRealIndex_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var parentNodeId = CreateType<int>();
            var position = CreateType<int>();
            var appId = CreateType<int>();
            var navType = CreateType<string>();
            var methodGetRealIndexPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(int), typeof(string) };
            object[] parametersOfGetRealIndex = { parentNodeId, position, appId, navType };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetRealIndex, methodGetRealIndexPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<AppSettingsHelper, int>(_appSettingsHelperInstanceFixture, out exception1, parametersOfGetRealIndex);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<AppSettingsHelper, int>(_appSettingsHelperInstance, MethodGetRealIndex, parametersOfGetRealIndex, methodGetRealIndexPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetRealIndex.ShouldNotBeNull();
            parametersOfGetRealIndex.Length.ShouldBe(4);
            methodGetRealIndexPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetRealIndex) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetRealIndex_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var parentNodeId = CreateType<int>();
            var position = CreateType<int>();
            var appId = CreateType<int>();
            var navType = CreateType<string>();
            var methodGetRealIndexPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(int), typeof(string) };
            object[] parametersOfGetRealIndex = { parentNodeId, position, appId, navType };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetRealIndex, methodGetRealIndexPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<AppSettingsHelper, int>(_appSettingsHelperInstanceFixture, out exception1, parametersOfGetRealIndex);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<AppSettingsHelper, int>(_appSettingsHelperInstance, MethodGetRealIndex, parametersOfGetRealIndex, methodGetRealIndexPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetRealIndex.ShouldNotBeNull();
            parametersOfGetRealIndex.Length.ShouldBe(4);
            methodGetRealIndexPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetRealIndex) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetRealIndex_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var parentNodeId = CreateType<int>();
            var position = CreateType<int>();
            var appId = CreateType<int>();
            var navType = CreateType<string>();
            var methodGetRealIndexPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(int), typeof(string) };
            object[] parametersOfGetRealIndex = { parentNodeId, position, appId, navType };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<AppSettingsHelper, int>(_appSettingsHelperInstance, MethodGetRealIndex, parametersOfGetRealIndex, methodGetRealIndexPrametersTypes);

            // Assert
            parametersOfGetRealIndex.ShouldNotBeNull();
            parametersOfGetRealIndex.Length.ShouldBe(4);
            methodGetRealIndexPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetRealIndex) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetRealIndex_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetRealIndexPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(int), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodGetRealIndex, Fixture, methodGetRealIndexPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetRealIndexPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRealIndex) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetRealIndex_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetRealIndex, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_appSettingsHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRealIndex) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetRealIndex_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetRealIndex, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateChildNode) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AppSettingsHelper_CreateChildNode_Method_Call_Internally(Type[] types)
        {
            var methodCreateChildNodePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodCreateChildNode, Fixture, methodCreateChildNodePrametersTypes);
        }

        #endregion

        #region Method Call : (CreateChildNode) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_CreateChildNode_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var nodeType = CreateType<string>();
            var title = CreateType<string>();
            var url = CreateType<string>();
            var headingNodeId = CreateType<int>();
            var isExternal = CreateType<bool>();
            var origUser = CreateType<SPUser>();
            Action executeAction = null;

            // Act
            executeAction = () => _appSettingsHelperInstance.CreateChildNode(appId, nodeType, title, url, headingNodeId, isExternal, origUser);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CreateChildNode) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_CreateChildNode_Method_Call_Void_With_7_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var nodeType = CreateType<string>();
            var title = CreateType<string>();
            var url = CreateType<string>();
            var headingNodeId = CreateType<int>();
            var isExternal = CreateType<bool>();
            var origUser = CreateType<SPUser>();
            var methodCreateChildNodePrametersTypes = new Type[] { typeof(int), typeof(string), typeof(string), typeof(string), typeof(int), typeof(bool), typeof(SPUser) };
            object[] parametersOfCreateChildNode = { appId, nodeType, title, url, headingNodeId, isExternal, origUser };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateChildNode, methodCreateChildNodePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_appSettingsHelperInstanceFixture, parametersOfCreateChildNode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateChildNode.ShouldNotBeNull();
            parametersOfCreateChildNode.Length.ShouldBe(7);
            methodCreateChildNodePrametersTypes.Length.ShouldBe(7);
            methodCreateChildNodePrametersTypes.Length.ShouldBe(parametersOfCreateChildNode.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildNode) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_CreateChildNode_Method_Call_Void_With_7_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var nodeType = CreateType<string>();
            var title = CreateType<string>();
            var url = CreateType<string>();
            var headingNodeId = CreateType<int>();
            var isExternal = CreateType<bool>();
            var origUser = CreateType<SPUser>();
            var methodCreateChildNodePrametersTypes = new Type[] { typeof(int), typeof(string), typeof(string), typeof(string), typeof(int), typeof(bool), typeof(SPUser) };
            object[] parametersOfCreateChildNode = { appId, nodeType, title, url, headingNodeId, isExternal, origUser };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_appSettingsHelperInstance, MethodCreateChildNode, parametersOfCreateChildNode, methodCreateChildNodePrametersTypes);

            // Assert
            parametersOfCreateChildNode.ShouldNotBeNull();
            parametersOfCreateChildNode.Length.ShouldBe(7);
            methodCreateChildNodePrametersTypes.Length.ShouldBe(7);
            methodCreateChildNodePrametersTypes.Length.ShouldBe(parametersOfCreateChildNode.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildNode) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_CreateChildNode_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreateChildNode, 0);
            const int parametersCount = 7;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateChildNode) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_CreateChildNode_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateChildNodePrametersTypes = new Type[] { typeof(int), typeof(string), typeof(string), typeof(string), typeof(int), typeof(bool), typeof(SPUser) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodCreateChildNode, Fixture, methodCreateChildNodePrametersTypes);

            // Assert
            methodCreateChildNodePrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildNode) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_CreateChildNode_Method_Call_With_7_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateChildNode, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_appSettingsHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateParentNode) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AppSettingsHelper_CreateParentNode_Method_Call_Internally(Type[] types)
        {
            var methodCreateParentNodePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodCreateParentNode, Fixture, methodCreateParentNodePrametersTypes);
        }

        #endregion

        #region Method Call : (CreateParentNode) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_CreateParentNode_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var nodeType = CreateType<string>();
            var title = CreateType<string>();
            var url = CreateType<string>();
            var isExternal = CreateType<bool>();
            var origUser = CreateType<SPUser>();
            Action executeAction = null;

            // Act
            executeAction = () => _appSettingsHelperInstance.CreateParentNode(appId, nodeType, title, url, isExternal, origUser);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CreateParentNode) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_CreateParentNode_Method_Call_Void_With_6_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var nodeType = CreateType<string>();
            var title = CreateType<string>();
            var url = CreateType<string>();
            var isExternal = CreateType<bool>();
            var origUser = CreateType<SPUser>();
            var methodCreateParentNodePrametersTypes = new Type[] { typeof(int), typeof(string), typeof(string), typeof(string), typeof(bool), typeof(SPUser) };
            object[] parametersOfCreateParentNode = { appId, nodeType, title, url, isExternal, origUser };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateParentNode, methodCreateParentNodePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_appSettingsHelperInstanceFixture, parametersOfCreateParentNode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateParentNode.ShouldNotBeNull();
            parametersOfCreateParentNode.Length.ShouldBe(6);
            methodCreateParentNodePrametersTypes.Length.ShouldBe(6);
            methodCreateParentNodePrametersTypes.Length.ShouldBe(parametersOfCreateParentNode.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CreateParentNode) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_CreateParentNode_Method_Call_Void_With_6_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var nodeType = CreateType<string>();
            var title = CreateType<string>();
            var url = CreateType<string>();
            var isExternal = CreateType<bool>();
            var origUser = CreateType<SPUser>();
            var methodCreateParentNodePrametersTypes = new Type[] { typeof(int), typeof(string), typeof(string), typeof(string), typeof(bool), typeof(SPUser) };
            object[] parametersOfCreateParentNode = { appId, nodeType, title, url, isExternal, origUser };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_appSettingsHelperInstance, MethodCreateParentNode, parametersOfCreateParentNode, methodCreateParentNodePrametersTypes);

            // Assert
            parametersOfCreateParentNode.ShouldNotBeNull();
            parametersOfCreateParentNode.Length.ShouldBe(6);
            methodCreateParentNodePrametersTypes.Length.ShouldBe(6);
            methodCreateParentNodePrametersTypes.Length.ShouldBe(parametersOfCreateParentNode.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateParentNode) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_CreateParentNode_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreateParentNode, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateParentNode) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_CreateParentNode_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateParentNodePrametersTypes = new Type[] { typeof(int), typeof(string), typeof(string), typeof(string), typeof(bool), typeof(SPUser) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodCreateParentNode, Fixture, methodCreateParentNodePrametersTypes);

            // Assert
            methodCreateParentNodePrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateParentNode) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_CreateParentNode_Method_Call_With_6_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateParentNode, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_appSettingsHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EditNodeById) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AppSettingsHelper_EditNodeById_Method_Call_Internally(Type[] types)
        {
            var methodEditNodeByIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodEditNodeById, Fixture, methodEditNodeByIdPrametersTypes);
        }

        #endregion

        #region Method Call : (EditNodeById) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_EditNodeById_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var parentNodeId = CreateType<int>();
            var nodeId = CreateType<int>();
            var title = CreateType<string>();
            var url = CreateType<string>();
            var appId = CreateType<int>();
            var nodeType = CreateType<string>();
            var origUser = CreateType<SPUser>();
            Action executeAction = null;

            // Act
            executeAction = () => _appSettingsHelperInstance.EditNodeById(parentNodeId, nodeId, title, url, appId, nodeType, origUser);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (EditNodeById) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_EditNodeById_Method_Call_Void_With_7_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var parentNodeId = CreateType<int>();
            var nodeId = CreateType<int>();
            var title = CreateType<string>();
            var url = CreateType<string>();
            var appId = CreateType<int>();
            var nodeType = CreateType<string>();
            var origUser = CreateType<SPUser>();
            var methodEditNodeByIdPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(string), typeof(string), typeof(int), typeof(string), typeof(SPUser) };
            object[] parametersOfEditNodeById = { parentNodeId, nodeId, title, url, appId, nodeType, origUser };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodEditNodeById, methodEditNodeByIdPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_appSettingsHelperInstanceFixture, parametersOfEditNodeById);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfEditNodeById.ShouldNotBeNull();
            parametersOfEditNodeById.Length.ShouldBe(7);
            methodEditNodeByIdPrametersTypes.Length.ShouldBe(7);
            methodEditNodeByIdPrametersTypes.Length.ShouldBe(parametersOfEditNodeById.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (EditNodeById) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_EditNodeById_Method_Call_Void_With_7_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var parentNodeId = CreateType<int>();
            var nodeId = CreateType<int>();
            var title = CreateType<string>();
            var url = CreateType<string>();
            var appId = CreateType<int>();
            var nodeType = CreateType<string>();
            var origUser = CreateType<SPUser>();
            var methodEditNodeByIdPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(string), typeof(string), typeof(int), typeof(string), typeof(SPUser) };
            object[] parametersOfEditNodeById = { parentNodeId, nodeId, title, url, appId, nodeType, origUser };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_appSettingsHelperInstance, MethodEditNodeById, parametersOfEditNodeById, methodEditNodeByIdPrametersTypes);

            // Assert
            parametersOfEditNodeById.ShouldNotBeNull();
            parametersOfEditNodeById.Length.ShouldBe(7);
            methodEditNodeByIdPrametersTypes.Length.ShouldBe(7);
            methodEditNodeByIdPrametersTypes.Length.ShouldBe(parametersOfEditNodeById.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EditNodeById) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_EditNodeById_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodEditNodeById, 0);
            const int parametersCount = 7;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (EditNodeById) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_EditNodeById_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodEditNodeByIdPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(string), typeof(string), typeof(int), typeof(string), typeof(SPUser) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodEditNodeById, Fixture, methodEditNodeByIdPrametersTypes);

            // Assert
            methodEditNodeByIdPrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EditNodeById) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_EditNodeById_Method_Call_With_7_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodEditNodeById, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_appSettingsHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteNode) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AppSettingsHelper_DeleteNode_Method_Call_Internally(Type[] types)
        {
            var methodDeleteNodePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodDeleteNode, Fixture, methodDeleteNodePrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteNode) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_DeleteNode_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var nodeId = CreateType<int>();
            var nodeType = CreateType<string>();
            var origUser = CreateType<SPUser>();
            Action executeAction = null;

            // Act
            executeAction = () => _appSettingsHelperInstance.DeleteNode(appId, nodeId, nodeType, origUser);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteNode) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_DeleteNode_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var nodeId = CreateType<int>();
            var nodeType = CreateType<string>();
            var origUser = CreateType<SPUser>();
            var methodDeleteNodePrametersTypes = new Type[] { typeof(int), typeof(int), typeof(string), typeof(SPUser) };
            object[] parametersOfDeleteNode = { appId, nodeId, nodeType, origUser };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDeleteNode, methodDeleteNodePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_appSettingsHelperInstanceFixture, parametersOfDeleteNode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDeleteNode.ShouldNotBeNull();
            parametersOfDeleteNode.Length.ShouldBe(4);
            methodDeleteNodePrametersTypes.Length.ShouldBe(4);
            methodDeleteNodePrametersTypes.Length.ShouldBe(parametersOfDeleteNode.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DeleteNode) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_DeleteNode_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var nodeId = CreateType<int>();
            var nodeType = CreateType<string>();
            var origUser = CreateType<SPUser>();
            var methodDeleteNodePrametersTypes = new Type[] { typeof(int), typeof(int), typeof(string), typeof(SPUser) };
            object[] parametersOfDeleteNode = { appId, nodeId, nodeType, origUser };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_appSettingsHelperInstance, MethodDeleteNode, parametersOfDeleteNode, methodDeleteNodePrametersTypes);

            // Assert
            parametersOfDeleteNode.ShouldNotBeNull();
            parametersOfDeleteNode.Length.ShouldBe(4);
            methodDeleteNodePrametersTypes.Length.ShouldBe(4);
            methodDeleteNodePrametersTypes.Length.ShouldBe(parametersOfDeleteNode.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteNode) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_DeleteNode_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteNode, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteNode) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_DeleteNode_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteNodePrametersTypes = new Type[] { typeof(int), typeof(int), typeof(string), typeof(SPUser) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodDeleteNode, Fixture, methodDeleteNodePrametersTypes);

            // Assert
            methodDeleteNodePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteNode) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_DeleteNode_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteNode, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_appSettingsHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateNodeOrder) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AppSettingsHelper_UpdateNodeOrder_Method_Call_Internally(Type[] types)
        {
            var methodUpdateNodeOrderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodUpdateNodeOrder, Fixture, methodUpdateNodeOrderPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateNodeOrder) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_UpdateNodeOrder_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var nodeType = CreateType<string>();
            var moveInfos = CreateType<string>();
            var origUser = CreateType<SPUser>();
            Action executeAction = null;

            // Act
            executeAction = () => _appSettingsHelperInstance.UpdateNodeOrder(appId, nodeType, moveInfos, origUser);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateNodeOrder) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_UpdateNodeOrder_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var nodeType = CreateType<string>();
            var moveInfos = CreateType<string>();
            var origUser = CreateType<SPUser>();
            var methodUpdateNodeOrderPrametersTypes = new Type[] { typeof(int), typeof(string), typeof(string), typeof(SPUser) };
            object[] parametersOfUpdateNodeOrder = { appId, nodeType, moveInfos, origUser };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateNodeOrder, methodUpdateNodeOrderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_appSettingsHelperInstanceFixture, parametersOfUpdateNodeOrder);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateNodeOrder.ShouldNotBeNull();
            parametersOfUpdateNodeOrder.Length.ShouldBe(4);
            methodUpdateNodeOrderPrametersTypes.Length.ShouldBe(4);
            methodUpdateNodeOrderPrametersTypes.Length.ShouldBe(parametersOfUpdateNodeOrder.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateNodeOrder) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_UpdateNodeOrder_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var nodeType = CreateType<string>();
            var moveInfos = CreateType<string>();
            var origUser = CreateType<SPUser>();
            var methodUpdateNodeOrderPrametersTypes = new Type[] { typeof(int), typeof(string), typeof(string), typeof(SPUser) };
            object[] parametersOfUpdateNodeOrder = { appId, nodeType, moveInfos, origUser };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_appSettingsHelperInstance, MethodUpdateNodeOrder, parametersOfUpdateNodeOrder, methodUpdateNodeOrderPrametersTypes);

            // Assert
            parametersOfUpdateNodeOrder.ShouldNotBeNull();
            parametersOfUpdateNodeOrder.Length.ShouldBe(4);
            methodUpdateNodeOrderPrametersTypes.Length.ShouldBe(4);
            methodUpdateNodeOrderPrametersTypes.Length.ShouldBe(parametersOfUpdateNodeOrder.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateNodeOrder) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_UpdateNodeOrder_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateNodeOrder, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateNodeOrder) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_UpdateNodeOrder_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateNodeOrderPrametersTypes = new Type[] { typeof(int), typeof(string), typeof(string), typeof(SPUser) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodUpdateNodeOrder, Fixture, methodUpdateNodeOrderPrametersTypes);

            // Assert
            methodUpdateNodeOrderPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateNodeOrder) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_UpdateNodeOrder_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateNodeOrder, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_appSettingsHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (MoveNode) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AppSettingsHelper_MoveNode_Method_Call_Internally(Type[] types)
        {
            var methodMoveNodePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodMoveNode, Fixture, methodMoveNodePrametersTypes);
        }

        #endregion

        #region Method Call : (MoveNode) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_MoveNode_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var nodeType = CreateType<string>();
            var movementInfo = CreateType<string[]>();
            var methodMoveNodePrametersTypes = new Type[] { typeof(int), typeof(string), typeof(string[]) };
            object[] parametersOfMoveNode = { appId, nodeType, movementInfo };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodMoveNode, methodMoveNodePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_appSettingsHelperInstanceFixture, parametersOfMoveNode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfMoveNode.ShouldNotBeNull();
            parametersOfMoveNode.Length.ShouldBe(3);
            methodMoveNodePrametersTypes.Length.ShouldBe(3);
            methodMoveNodePrametersTypes.Length.ShouldBe(parametersOfMoveNode.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (MoveNode) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_MoveNode_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var appId = CreateType<int>();
            var nodeType = CreateType<string>();
            var movementInfo = CreateType<string[]>();
            var methodMoveNodePrametersTypes = new Type[] { typeof(int), typeof(string), typeof(string[]) };
            object[] parametersOfMoveNode = { appId, nodeType, movementInfo };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_appSettingsHelperInstance, MethodMoveNode, parametersOfMoveNode, methodMoveNodePrametersTypes);

            // Assert
            parametersOfMoveNode.ShouldNotBeNull();
            parametersOfMoveNode.Length.ShouldBe(3);
            methodMoveNodePrametersTypes.Length.ShouldBe(3);
            methodMoveNodePrametersTypes.Length.ShouldBe(parametersOfMoveNode.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (MoveNode) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_MoveNode_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodMoveNode, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (MoveNode) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_MoveNode_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodMoveNodePrametersTypes = new Type[] { typeof(int), typeof(string), typeof(string[]) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodMoveNode, Fixture, methodMoveNodePrametersTypes);

            // Assert
            methodMoveNodePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (MoveNode) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_MoveNode_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodMoveNode, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_appSettingsHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsUrlInternal) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AppSettingsHelper_IsUrlInternal_Method_Call_Internally(Type[] types)
        {
            var methodIsUrlInternalPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodIsUrlInternal, Fixture, methodIsUrlInternalPrametersTypes);
        }

        #endregion

        #region Method Call : (IsUrlInternal) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_IsUrlInternal_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var url = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _appSettingsHelperInstance.IsUrlInternal(url);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (IsUrlInternal) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_IsUrlInternal_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var url = CreateType<string>();
            var methodIsUrlInternalPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsUrlInternal = { url };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsUrlInternal, methodIsUrlInternalPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<AppSettingsHelper, bool>(_appSettingsHelperInstanceFixture, out exception1, parametersOfIsUrlInternal);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<AppSettingsHelper, bool>(_appSettingsHelperInstance, MethodIsUrlInternal, parametersOfIsUrlInternal, methodIsUrlInternalPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsUrlInternal.ShouldNotBeNull();
            parametersOfIsUrlInternal.Length.ShouldBe(1);
            methodIsUrlInternalPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (IsUrlInternal) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_IsUrlInternal_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var url = CreateType<string>();
            var methodIsUrlInternalPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsUrlInternal = { url };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsUrlInternal, methodIsUrlInternalPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<AppSettingsHelper, bool>(_appSettingsHelperInstanceFixture, out exception1, parametersOfIsUrlInternal);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<AppSettingsHelper, bool>(_appSettingsHelperInstance, MethodIsUrlInternal, parametersOfIsUrlInternal, methodIsUrlInternalPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsUrlInternal.ShouldNotBeNull();
            parametersOfIsUrlInternal.Length.ShouldBe(1);
            methodIsUrlInternalPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (IsUrlInternal) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_IsUrlInternal_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var url = CreateType<string>();
            var methodIsUrlInternalPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsUrlInternal = { url };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<AppSettingsHelper, bool>(_appSettingsHelperInstance, MethodIsUrlInternal, parametersOfIsUrlInternal, methodIsUrlInternalPrametersTypes);

            // Assert
            parametersOfIsUrlInternal.ShouldNotBeNull();
            parametersOfIsUrlInternal.Length.ShouldBe(1);
            methodIsUrlInternalPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsUrlInternal) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_IsUrlInternal_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsUrlInternalPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodIsUrlInternal, Fixture, methodIsUrlInternalPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsUrlInternalPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsUrlInternal) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_IsUrlInternal_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsUrlInternal, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_appSettingsHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsUrlInternal) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_IsUrlInternal_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodIsUrlInternal, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCleanUrl) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AppSettingsHelper_GetCleanUrl_Method_Call_Internally(Type[] types)
        {
            var methodGetCleanUrlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodGetCleanUrl, Fixture, methodGetCleanUrlPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCleanUrl) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetCleanUrl_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var url = CreateType<string>();
            var methodGetCleanUrlPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetCleanUrl = { url };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetCleanUrl, methodGetCleanUrlPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<AppSettingsHelper, string>(_appSettingsHelperInstanceFixture, out exception1, parametersOfGetCleanUrl);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<AppSettingsHelper, string>(_appSettingsHelperInstance, MethodGetCleanUrl, parametersOfGetCleanUrl, methodGetCleanUrlPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetCleanUrl.ShouldNotBeNull();
            parametersOfGetCleanUrl.Length.ShouldBe(1);
            methodGetCleanUrlPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetCleanUrl) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetCleanUrl_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var url = CreateType<string>();
            var methodGetCleanUrlPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetCleanUrl = { url };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<AppSettingsHelper, string>(_appSettingsHelperInstance, MethodGetCleanUrl, parametersOfGetCleanUrl, methodGetCleanUrlPrametersTypes);

            // Assert
            parametersOfGetCleanUrl.ShouldNotBeNull();
            parametersOfGetCleanUrl.Length.ShouldBe(1);
            methodGetCleanUrlPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCleanUrl) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetCleanUrl_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCleanUrlPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodGetCleanUrl, Fixture, methodGetCleanUrlPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCleanUrlPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetCleanUrl) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetCleanUrl_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCleanUrlPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appSettingsHelperInstance, MethodGetCleanUrl, Fixture, methodGetCleanUrlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCleanUrlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCleanUrl) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetCleanUrl_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCleanUrl, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_appSettingsHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCleanUrl) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppSettingsHelper_GetCleanUrl_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCleanUrl, 0);
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
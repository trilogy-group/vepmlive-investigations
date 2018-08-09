using System;
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

namespace EPMLiveCore.API
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.DownloadedTempWorkspaceFactory" />)
    ///     and namespace <see cref="EPMLiveCore.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class DownloadedTempWorkspaceFactoryTest : AbstractBaseSetupTypedTest<DownloadedTempWorkspaceFactory>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DownloadedTempWorkspaceFactory) Initializer

        private const string MethodCreateWorkspace = "CreateWorkspace";
        private const string MethodGetTempName = "GetTempName";
        private const string MethodTryGetListAndItem = "TryGetListAndItem";
        private Type _downloadedTempWorkspaceFactoryInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DownloadedTempWorkspaceFactory _downloadedTempWorkspaceFactoryInstance;
        private DownloadedTempWorkspaceFactory _downloadedTempWorkspaceFactoryInstanceFixture;

        #region General Initializer : Class (DownloadedTempWorkspaceFactory) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DownloadedTempWorkspaceFactory" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _downloadedTempWorkspaceFactoryInstanceType = typeof(DownloadedTempWorkspaceFactory);
            _downloadedTempWorkspaceFactoryInstanceFixture = Create(true);
            _downloadedTempWorkspaceFactoryInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DownloadedTempWorkspaceFactory)

        #region General Initializer : Class (DownloadedTempWorkspaceFactory) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="DownloadedTempWorkspaceFactory" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodCreateWorkspace, 0)]
        [TestCase(MethodGetTempName, 0)]
        [TestCase(MethodTryGetListAndItem, 0)]
        public void AUT_DownloadedTempWorkspaceFactory_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_downloadedTempWorkspaceFactoryInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="DownloadedTempWorkspaceFactory" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodCreateWorkspace)]
        [TestCase(MethodGetTempName)]
        [TestCase(MethodTryGetListAndItem)]
        public void AUT_DownloadedTempWorkspaceFactory_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<DownloadedTempWorkspaceFactory>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (CreateWorkspace) (Return Type : ICreatedWorkspaceInfo) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DownloadedTempWorkspaceFactory_CreateWorkspace_Method_Call_Internally(Type[] types)
        {
            var methodCreateWorkspacePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_downloadedTempWorkspaceFactoryInstance, MethodCreateWorkspace, Fixture, methodCreateWorkspacePrametersTypes);
        }

        #endregion

        #region Method Call : (CreateWorkspace) (Return Type : ICreatedWorkspaceInfo) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DownloadedTempWorkspaceFactory_CreateWorkspace_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _downloadedTempWorkspaceFactoryInstance.CreateWorkspace();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CreateWorkspace) (Return Type : ICreatedWorkspaceInfo) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DownloadedTempWorkspaceFactory_CreateWorkspace_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodCreateWorkspacePrametersTypes = null;
            object[] parametersOfCreateWorkspace = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCreateWorkspace, methodCreateWorkspacePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<DownloadedTempWorkspaceFactory, ICreatedWorkspaceInfo>(_downloadedTempWorkspaceFactoryInstanceFixture, out exception1, parametersOfCreateWorkspace);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<DownloadedTempWorkspaceFactory, ICreatedWorkspaceInfo>(_downloadedTempWorkspaceFactoryInstance, MethodCreateWorkspace, parametersOfCreateWorkspace, methodCreateWorkspacePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfCreateWorkspace.ShouldBeNull();
            methodCreateWorkspacePrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(() => methodInfo.Invoke(_downloadedTempWorkspaceFactoryInstanceFixture, parametersOfCreateWorkspace));
        }

        #endregion

        #region Method Call : (CreateWorkspace) (Return Type : ICreatedWorkspaceInfo) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DownloadedTempWorkspaceFactory_CreateWorkspace_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateWorkspacePrametersTypes = null;
            object[] parametersOfCreateWorkspace = null; // no parameter present

            // Assert
            parametersOfCreateWorkspace.ShouldBeNull();
            methodCreateWorkspacePrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<DownloadedTempWorkspaceFactory, ICreatedWorkspaceInfo>(_downloadedTempWorkspaceFactoryInstance, MethodCreateWorkspace, parametersOfCreateWorkspace, methodCreateWorkspacePrametersTypes));
        }

        #endregion

        #region Method Call : (CreateWorkspace) (Return Type : ICreatedWorkspaceInfo) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DownloadedTempWorkspaceFactory_CreateWorkspace_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodCreateWorkspacePrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_downloadedTempWorkspaceFactoryInstance, MethodCreateWorkspace, Fixture, methodCreateWorkspacePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCreateWorkspacePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateWorkspace) (Return Type : ICreatedWorkspaceInfo) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DownloadedTempWorkspaceFactory_CreateWorkspace_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateWorkspacePrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_downloadedTempWorkspaceFactoryInstance, MethodCreateWorkspace, Fixture, methodCreateWorkspacePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreateWorkspacePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateWorkspace) (Return Type : ICreatedWorkspaceInfo) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DownloadedTempWorkspaceFactory_CreateWorkspace_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateWorkspace, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_downloadedTempWorkspaceFactoryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTempName) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DownloadedTempWorkspaceFactory_GetTempName_Method_Call_Internally(Type[] types)
        {
            var methodGetTempNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_downloadedTempWorkspaceFactoryInstance, MethodGetTempName, Fixture, methodGetTempNamePrametersTypes);
        }

        #endregion

        #region Method Call : (GetTempName) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DownloadedTempWorkspaceFactory_GetTempName_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var eSite = CreateType<SPSite>();
            var TempGalWebId = CreateType<Guid>();
            var methodGetTempNamePrametersTypes = new Type[] { typeof(SPSite), typeof(Guid) };
            object[] parametersOfGetTempName = { eSite, TempGalWebId };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetTempName, methodGetTempNamePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_downloadedTempWorkspaceFactoryInstanceFixture, parametersOfGetTempName);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetTempName.ShouldNotBeNull();
            parametersOfGetTempName.Length.ShouldBe(2);
            methodGetTempNamePrametersTypes.Length.ShouldBe(2);
            methodGetTempNamePrametersTypes.Length.ShouldBe(parametersOfGetTempName.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetTempName) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DownloadedTempWorkspaceFactory_GetTempName_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var eSite = CreateType<SPSite>();
            var TempGalWebId = CreateType<Guid>();
            var methodGetTempNamePrametersTypes = new Type[] { typeof(SPSite), typeof(Guid) };
            object[] parametersOfGetTempName = { eSite, TempGalWebId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_downloadedTempWorkspaceFactoryInstance, MethodGetTempName, parametersOfGetTempName, methodGetTempNamePrametersTypes);

            // Assert
            parametersOfGetTempName.ShouldNotBeNull();
            parametersOfGetTempName.Length.ShouldBe(2);
            methodGetTempNamePrametersTypes.Length.ShouldBe(2);
            methodGetTempNamePrametersTypes.Length.ShouldBe(parametersOfGetTempName.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTempName) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DownloadedTempWorkspaceFactory_GetTempName_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTempName, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTempName) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DownloadedTempWorkspaceFactory_GetTempName_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTempNamePrametersTypes = new Type[] { typeof(SPSite), typeof(Guid) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_downloadedTempWorkspaceFactoryInstance, MethodGetTempName, Fixture, methodGetTempNamePrametersTypes);

            // Assert
            methodGetTempNamePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTempName) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DownloadedTempWorkspaceFactory_GetTempName_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTempName, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_downloadedTempWorkspaceFactoryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (TryGetListAndItem) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DownloadedTempWorkspaceFactory_TryGetListAndItem_Method_Call_Internally(Type[] types)
        {
            var methodTryGetListAndItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_downloadedTempWorkspaceFactoryInstance, MethodTryGetListAndItem, Fixture, methodTryGetListAndItemPrametersTypes);
        }

        #endregion

        #region Method Call : (TryGetListAndItem) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DownloadedTempWorkspaceFactory_TryGetListAndItem_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var web = CreateType<SPWeb>();
            var list = CreateType<SPList>();
            var item = CreateType<SPListItem>();
            var listName = CreateType<string>();
            var itemId = CreateType<int>();
            var methodTryGetListAndItemPrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb), typeof(SPList), typeof(SPListItem), typeof(string), typeof(int) };
            object[] parametersOfTryGetListAndItem = { site, web, list, item, listName, itemId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodTryGetListAndItem, methodTryGetListAndItemPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<DownloadedTempWorkspaceFactory, bool>(_downloadedTempWorkspaceFactoryInstanceFixture, out exception1, parametersOfTryGetListAndItem);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<DownloadedTempWorkspaceFactory, bool>(_downloadedTempWorkspaceFactoryInstance, MethodTryGetListAndItem, parametersOfTryGetListAndItem, methodTryGetListAndItemPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfTryGetListAndItem.ShouldNotBeNull();
            parametersOfTryGetListAndItem.Length.ShouldBe(6);
            methodTryGetListAndItemPrametersTypes.Length.ShouldBe(6);
            Should.Throw<Exception>(() => methodInfo.Invoke(_downloadedTempWorkspaceFactoryInstanceFixture, parametersOfTryGetListAndItem));
        }

        #endregion

        #region Method Call : (TryGetListAndItem) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DownloadedTempWorkspaceFactory_TryGetListAndItem_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var web = CreateType<SPWeb>();
            var list = CreateType<SPList>();
            var item = CreateType<SPListItem>();
            var listName = CreateType<string>();
            var itemId = CreateType<int>();
            var methodTryGetListAndItemPrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb), typeof(SPList), typeof(SPListItem), typeof(string), typeof(int) };
            object[] parametersOfTryGetListAndItem = { site, web, list, item, listName, itemId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodTryGetListAndItem, methodTryGetListAndItemPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<DownloadedTempWorkspaceFactory, bool>(_downloadedTempWorkspaceFactoryInstanceFixture, out exception1, parametersOfTryGetListAndItem);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<DownloadedTempWorkspaceFactory, bool>(_downloadedTempWorkspaceFactoryInstance, MethodTryGetListAndItem, parametersOfTryGetListAndItem, methodTryGetListAndItemPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfTryGetListAndItem.ShouldNotBeNull();
            parametersOfTryGetListAndItem.Length.ShouldBe(6);
            methodTryGetListAndItemPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<DownloadedTempWorkspaceFactory, bool>(_downloadedTempWorkspaceFactoryInstance, MethodTryGetListAndItem, parametersOfTryGetListAndItem, methodTryGetListAndItemPrametersTypes));
        }

        #endregion

        #region Method Call : (TryGetListAndItem) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DownloadedTempWorkspaceFactory_TryGetListAndItem_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var web = CreateType<SPWeb>();
            var list = CreateType<SPList>();
            var item = CreateType<SPListItem>();
            var listName = CreateType<string>();
            var itemId = CreateType<int>();
            var methodTryGetListAndItemPrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb), typeof(SPList), typeof(SPListItem), typeof(string), typeof(int) };
            object[] parametersOfTryGetListAndItem = { site, web, list, item, listName, itemId };

            // Assert
            parametersOfTryGetListAndItem.ShouldNotBeNull();
            parametersOfTryGetListAndItem.Length.ShouldBe(6);
            methodTryGetListAndItemPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<DownloadedTempWorkspaceFactory, bool>(_downloadedTempWorkspaceFactoryInstance, MethodTryGetListAndItem, parametersOfTryGetListAndItem, methodTryGetListAndItemPrametersTypes));
        }

        #endregion

        #region Method Call : (TryGetListAndItem) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DownloadedTempWorkspaceFactory_TryGetListAndItem_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodTryGetListAndItemPrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb), typeof(SPList), typeof(SPListItem), typeof(string), typeof(int) };
            const int parametersCount = 6;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_downloadedTempWorkspaceFactoryInstance, MethodTryGetListAndItem, Fixture, methodTryGetListAndItemPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodTryGetListAndItemPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TryGetListAndItem) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DownloadedTempWorkspaceFactory_TryGetListAndItem_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodTryGetListAndItem, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_downloadedTempWorkspaceFactoryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (TryGetListAndItem) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DownloadedTempWorkspaceFactory_TryGetListAndItem_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodTryGetListAndItem, 0);
            const int parametersCount = 6;

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
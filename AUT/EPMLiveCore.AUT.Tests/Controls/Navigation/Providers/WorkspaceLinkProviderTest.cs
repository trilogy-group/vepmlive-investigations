using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using EPMLiveCore.Infrastructure.Navigation;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.Controls.Navigation.Providers
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Controls.Navigation.Providers.WorkspaceLinkProvider" />)
    ///     and namespace <see cref="EPMLiveCore.Controls.Navigation.Providers"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class WorkspaceLinkProviderTest : AbstractBaseSetupTypedTest<WorkspaceLinkProvider>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WorkspaceLinkProvider) Initializer

        private const string PropertyKey = "Key";
        private const string MethodG = "G";
        private const string MethodGetAllWorkspaces = "GetAllWorkspaces";
        private const string MethodGetChildWebs = "GetChildWebs";
        private const string MethodIsArchived = "IsArchived";
        private const string MethodGetFavoriteWorkspaces = "GetFavoriteWorkspaces";
        private const string MethodGetRootWebLink = "GetRootWebLink";
        private const string MethodGetLinks = "GetLinks";
        private const string FieldCREATE_WORKSPACE_URL = "CREATE_WORKSPACE_URL";
        private const string Field_key = "_key";
        private const string FieldF_QUERY = "F_QUERY";
        private Type _workspaceLinkProviderInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private WorkspaceLinkProvider _workspaceLinkProviderInstance;
        private WorkspaceLinkProvider _workspaceLinkProviderInstanceFixture;

        #region General Initializer : Class (WorkspaceLinkProvider) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WorkspaceLinkProvider" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _workspaceLinkProviderInstanceType = typeof(WorkspaceLinkProvider);
            _workspaceLinkProviderInstanceFixture = Create(true);
            _workspaceLinkProviderInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WorkspaceLinkProvider)

        #region General Initializer : Class (WorkspaceLinkProvider) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="WorkspaceLinkProvider" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodG, 0)]
        [TestCase(MethodGetAllWorkspaces, 0)]
        [TestCase(MethodGetChildWebs, 0)]
        [TestCase(MethodGetFavoriteWorkspaces, 0)]
        [TestCase(MethodGetRootWebLink, 0)]
        [TestCase(MethodGetLinks, 0)]
        public void AUT_WorkspaceLinkProvider_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_workspaceLinkProviderInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (WorkspaceLinkProvider) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="WorkspaceLinkProvider" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyKey)]
        public void AUT_WorkspaceLinkProvider_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_workspaceLinkProviderInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (WorkspaceLinkProvider) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="WorkspaceLinkProvider" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldCREATE_WORKSPACE_URL)]
        [TestCase(Field_key)]
        [TestCase(FieldF_QUERY)]
        public void AUT_WorkspaceLinkProvider_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_workspaceLinkProviderInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : GetterSetter
        
        #region General Getters/Setters : Class (WorkspaceLinkProvider) => Property (Key) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkspaceLinkProvider_Public_Class_Key_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyKey);

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
        ///      Class (<see cref="WorkspaceLinkProvider" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodG)]
        [TestCase(MethodGetAllWorkspaces)]
        [TestCase(MethodGetChildWebs)]
        [TestCase(MethodIsArchived)]
        [TestCase(MethodGetFavoriteWorkspaces)]
        [TestCase(MethodGetRootWebLink)]
        [TestCase(MethodGetLinks)]
        public void AUT_WorkspaceLinkProvider_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<WorkspaceLinkProvider>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (G) (Return Type : Guid) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkspaceLinkProvider_G_Method_Call_Internally(Type[] types)
        {
            var methodGPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workspaceLinkProviderInstance, MethodG, Fixture, methodGPrametersTypes);
        }

        #endregion

        #region Method Call : (G) (Return Type : Guid) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceLinkProvider_G_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var value = CreateType<object>();
            var methodGPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfG = { value };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodG, methodGPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<WorkspaceLinkProvider, Guid>(_workspaceLinkProviderInstanceFixture, out exception1, parametersOfG);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<WorkspaceLinkProvider, Guid>(_workspaceLinkProviderInstance, MethodG, parametersOfG, methodGPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfG.ShouldNotBeNull();
            parametersOfG.Length.ShouldBe(1);
            methodGPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<WorkspaceLinkProvider, Guid>(_workspaceLinkProviderInstance, MethodG, parametersOfG, methodGPrametersTypes));
        }

        #endregion

        #region Method Call : (G) (Return Type : Guid) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceLinkProvider_G_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var value = CreateType<object>();
            var methodGPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfG = { value };

            // Assert
            parametersOfG.ShouldNotBeNull();
            parametersOfG.Length.ShouldBe(1);
            methodGPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<WorkspaceLinkProvider, Guid>(_workspaceLinkProviderInstance, MethodG, parametersOfG, methodGPrametersTypes));
        }

        #endregion

        #region Method Call : (G) (Return Type : Guid) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceLinkProvider_G_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGPrametersTypes = new Type[] { typeof(object) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workspaceLinkProviderInstance, MethodG, Fixture, methodGPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (G) (Return Type : Guid) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceLinkProvider_G_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGPrametersTypes = new Type[] { typeof(object) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workspaceLinkProviderInstance, MethodG, Fixture, methodGPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (G) (Return Type : Guid) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceLinkProvider_G_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodG, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workspaceLinkProviderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (G) (Return Type : Guid) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceLinkProvider_G_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodG, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAllWorkspaces) (Return Type : IEnumerable<SPNavLink>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkspaceLinkProvider_GetAllWorkspaces_Method_Call_Internally(Type[] types)
        {
            var methodGetAllWorkspacesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workspaceLinkProviderInstance, MethodGetAllWorkspaces, Fixture, methodGetAllWorkspacesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAllWorkspaces) (Return Type : IEnumerable<SPNavLink>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceLinkProvider_GetAllWorkspaces_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetAllWorkspacesPrametersTypes = null;
            object[] parametersOfGetAllWorkspaces = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetAllWorkspaces, methodGetAllWorkspacesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<WorkspaceLinkProvider, IEnumerable<SPNavLink>>(_workspaceLinkProviderInstanceFixture, out exception1, parametersOfGetAllWorkspaces);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<WorkspaceLinkProvider, IEnumerable<SPNavLink>>(_workspaceLinkProviderInstance, MethodGetAllWorkspaces, parametersOfGetAllWorkspaces, methodGetAllWorkspacesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetAllWorkspaces.ShouldBeNull();
            methodGetAllWorkspacesPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(() => methodInfo.Invoke(_workspaceLinkProviderInstanceFixture, parametersOfGetAllWorkspaces));
        }

        #endregion

        #region Method Call : (GetAllWorkspaces) (Return Type : IEnumerable<SPNavLink>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceLinkProvider_GetAllWorkspaces_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetAllWorkspacesPrametersTypes = null;
            object[] parametersOfGetAllWorkspaces = null; // no parameter present

            // Assert
            parametersOfGetAllWorkspaces.ShouldBeNull();
            methodGetAllWorkspacesPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<WorkspaceLinkProvider, IEnumerable<SPNavLink>>(_workspaceLinkProviderInstance, MethodGetAllWorkspaces, parametersOfGetAllWorkspaces, methodGetAllWorkspacesPrametersTypes));
        }

        #endregion

        #region Method Call : (GetAllWorkspaces) (Return Type : IEnumerable<SPNavLink>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceLinkProvider_GetAllWorkspaces_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetAllWorkspacesPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workspaceLinkProviderInstance, MethodGetAllWorkspaces, Fixture, methodGetAllWorkspacesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetAllWorkspacesPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAllWorkspaces) (Return Type : IEnumerable<SPNavLink>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceLinkProvider_GetAllWorkspaces_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetAllWorkspacesPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workspaceLinkProviderInstance, MethodGetAllWorkspaces, Fixture, methodGetAllWorkspacesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetAllWorkspacesPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAllWorkspaces) (Return Type : IEnumerable<SPNavLink>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceLinkProvider_GetAllWorkspaces_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetAllWorkspaces, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workspaceLinkProviderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetChildWebs) (Return Type : IEnumerable<SPNavLink>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkspaceLinkProvider_GetChildWebs_Method_Call_Internally(Type[] types)
        {
            var methodGetChildWebsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workspaceLinkProviderInstance, MethodGetChildWebs, Fixture, methodGetChildWebsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetChildWebs) (Return Type : IEnumerable<SPNavLink>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceLinkProvider_GetChildWebs_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var rows = CreateType<EnumerableRowCollection<DataRow>>();
            var webId = CreateType<string>();
            var spSite = CreateType<SPSite>();
            var methodGetChildWebsPrametersTypes = new Type[] { typeof(EnumerableRowCollection<DataRow>), typeof(string), typeof(SPSite) };
            object[] parametersOfGetChildWebs = { rows, webId, spSite };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetChildWebs, methodGetChildWebsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<WorkspaceLinkProvider, IEnumerable<SPNavLink>>(_workspaceLinkProviderInstanceFixture, out exception1, parametersOfGetChildWebs);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<WorkspaceLinkProvider, IEnumerable<SPNavLink>>(_workspaceLinkProviderInstance, MethodGetChildWebs, parametersOfGetChildWebs, methodGetChildWebsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetChildWebs.ShouldNotBeNull();
            parametersOfGetChildWebs.Length.ShouldBe(3);
            methodGetChildWebsPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(() => methodInfo.Invoke(_workspaceLinkProviderInstanceFixture, parametersOfGetChildWebs));
        }

        #endregion

        #region Method Call : (GetChildWebs) (Return Type : IEnumerable<SPNavLink>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceLinkProvider_GetChildWebs_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var rows = CreateType<EnumerableRowCollection<DataRow>>();
            var webId = CreateType<string>();
            var spSite = CreateType<SPSite>();
            var methodGetChildWebsPrametersTypes = new Type[] { typeof(EnumerableRowCollection<DataRow>), typeof(string), typeof(SPSite) };
            object[] parametersOfGetChildWebs = { rows, webId, spSite };

            // Assert
            parametersOfGetChildWebs.ShouldNotBeNull();
            parametersOfGetChildWebs.Length.ShouldBe(3);
            methodGetChildWebsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<WorkspaceLinkProvider, IEnumerable<SPNavLink>>(_workspaceLinkProviderInstance, MethodGetChildWebs, parametersOfGetChildWebs, methodGetChildWebsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetChildWebs) (Return Type : IEnumerable<SPNavLink>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceLinkProvider_GetChildWebs_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetChildWebsPrametersTypes = new Type[] { typeof(EnumerableRowCollection<DataRow>), typeof(string), typeof(SPSite) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workspaceLinkProviderInstance, MethodGetChildWebs, Fixture, methodGetChildWebsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetChildWebsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetChildWebs) (Return Type : IEnumerable<SPNavLink>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceLinkProvider_GetChildWebs_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetChildWebsPrametersTypes = new Type[] { typeof(EnumerableRowCollection<DataRow>), typeof(string), typeof(SPSite) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workspaceLinkProviderInstance, MethodGetChildWebs, Fixture, methodGetChildWebsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetChildWebsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetChildWebs) (Return Type : IEnumerable<SPNavLink>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceLinkProvider_GetChildWebs_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetChildWebs, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workspaceLinkProviderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetChildWebs) (Return Type : IEnumerable<SPNavLink>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceLinkProvider_GetChildWebs_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetChildWebs, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsArchived) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkspaceLinkProvider_IsArchived_Method_Call_Internally(Type[] types)
        {
            var methodIsArchivedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workspaceLinkProviderInstance, MethodIsArchived, Fixture, methodIsArchivedPrametersTypes);
        }

        #endregion
        
        #region Method Call : (IsArchived) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceLinkProvider_IsArchived_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var webIdString = CreateType<string>();
            var listIdString = CreateType<string>();
            var itemIdString = CreateType<string>();
            var methodIsArchivedPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfIsArchived = { siteId, webIdString, listIdString, itemIdString };

            // Assert
            parametersOfIsArchived.ShouldNotBeNull();
            parametersOfIsArchived.Length.ShouldBe(4);
            methodIsArchivedPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<WorkspaceLinkProvider, bool>(_workspaceLinkProviderInstance, MethodIsArchived, parametersOfIsArchived, methodIsArchivedPrametersTypes));
        }

        #endregion

        #region Method Call : (IsArchived) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceLinkProvider_IsArchived_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsArchivedPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workspaceLinkProviderInstance, MethodIsArchived, Fixture, methodIsArchivedPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsArchivedPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion
        
        #region Method Call : (GetFavoriteWorkspaces) (Return Type : IEnumerable<NavLink>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceLinkProvider_GetFavoriteWorkspaces_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var allWorkspaces = CreateType<List<SPNavLink>>();
            var methodGetFavoriteWorkspacesPrametersTypes = new Type[] { typeof(List<SPNavLink>) };
            object[] parametersOfGetFavoriteWorkspaces = { allWorkspaces };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetFavoriteWorkspaces, methodGetFavoriteWorkspacesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<WorkspaceLinkProvider, IEnumerable<NavLink>>(_workspaceLinkProviderInstanceFixture, out exception1, parametersOfGetFavoriteWorkspaces);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<WorkspaceLinkProvider, IEnumerable<NavLink>>(_workspaceLinkProviderInstance, MethodGetFavoriteWorkspaces, parametersOfGetFavoriteWorkspaces, methodGetFavoriteWorkspacesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFavoriteWorkspaces.ShouldNotBeNull();
            parametersOfGetFavoriteWorkspaces.Length.ShouldBe(1);
            methodGetFavoriteWorkspacesPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_workspaceLinkProviderInstanceFixture, parametersOfGetFavoriteWorkspaces));
        }

        #endregion

        #region Method Call : (GetFavoriteWorkspaces) (Return Type : IEnumerable<NavLink>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceLinkProvider_GetFavoriteWorkspaces_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var allWorkspaces = CreateType<List<SPNavLink>>();
            var methodGetFavoriteWorkspacesPrametersTypes = new Type[] { typeof(List<SPNavLink>) };
            object[] parametersOfGetFavoriteWorkspaces = { allWorkspaces };

            // Assert
            parametersOfGetFavoriteWorkspaces.ShouldNotBeNull();
            parametersOfGetFavoriteWorkspaces.Length.ShouldBe(1);
            methodGetFavoriteWorkspacesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<WorkspaceLinkProvider, IEnumerable<NavLink>>(_workspaceLinkProviderInstance, MethodGetFavoriteWorkspaces, parametersOfGetFavoriteWorkspaces, methodGetFavoriteWorkspacesPrametersTypes));
        }

        #endregion

        #region Method Call : (GetFavoriteWorkspaces) (Return Type : IEnumerable<NavLink>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceLinkProvider_GetFavoriteWorkspaces_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFavoriteWorkspacesPrametersTypes = new Type[] { typeof(List<SPNavLink>) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workspaceLinkProviderInstance, MethodGetFavoriteWorkspaces, Fixture, methodGetFavoriteWorkspacesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFavoriteWorkspacesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFavoriteWorkspaces) (Return Type : IEnumerable<NavLink>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceLinkProvider_GetFavoriteWorkspaces_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFavoriteWorkspacesPrametersTypes = new Type[] { typeof(List<SPNavLink>) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workspaceLinkProviderInstance, MethodGetFavoriteWorkspaces, Fixture, methodGetFavoriteWorkspacesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFavoriteWorkspacesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFavoriteWorkspaces) (Return Type : IEnumerable<NavLink>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceLinkProvider_GetFavoriteWorkspaces_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFavoriteWorkspaces, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workspaceLinkProviderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFavoriteWorkspaces) (Return Type : IEnumerable<NavLink>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceLinkProvider_GetFavoriteWorkspaces_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFavoriteWorkspaces, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRootWebLink) (Return Type : SPNavLink) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkspaceLinkProvider_GetRootWebLink_Method_Call_Internally(Type[] types)
        {
            var methodGetRootWebLinkPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workspaceLinkProviderInstance, MethodGetRootWebLink, Fixture, methodGetRootWebLinkPrametersTypes);
        }

        #endregion

        #region Method Call : (GetRootWebLink) (Return Type : SPNavLink) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceLinkProvider_GetRootWebLink_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var rows = CreateType<EnumerableRowCollection<DataRow>>();
            var methodGetRootWebLinkPrametersTypes = new Type[] { typeof(EnumerableRowCollection<DataRow>) };
            object[] parametersOfGetRootWebLink = { rows };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetRootWebLink, methodGetRootWebLinkPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<WorkspaceLinkProvider, SPNavLink>(_workspaceLinkProviderInstanceFixture, out exception1, parametersOfGetRootWebLink);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<WorkspaceLinkProvider, SPNavLink>(_workspaceLinkProviderInstance, MethodGetRootWebLink, parametersOfGetRootWebLink, methodGetRootWebLinkPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetRootWebLink.ShouldNotBeNull();
            parametersOfGetRootWebLink.Length.ShouldBe(1);
            methodGetRootWebLinkPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_workspaceLinkProviderInstanceFixture, parametersOfGetRootWebLink));
        }

        #endregion

        #region Method Call : (GetRootWebLink) (Return Type : SPNavLink) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceLinkProvider_GetRootWebLink_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var rows = CreateType<EnumerableRowCollection<DataRow>>();
            var methodGetRootWebLinkPrametersTypes = new Type[] { typeof(EnumerableRowCollection<DataRow>) };
            object[] parametersOfGetRootWebLink = { rows };

            // Assert
            parametersOfGetRootWebLink.ShouldNotBeNull();
            parametersOfGetRootWebLink.Length.ShouldBe(1);
            methodGetRootWebLinkPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<WorkspaceLinkProvider, SPNavLink>(_workspaceLinkProviderInstance, MethodGetRootWebLink, parametersOfGetRootWebLink, methodGetRootWebLinkPrametersTypes));
        }

        #endregion

        #region Method Call : (GetRootWebLink) (Return Type : SPNavLink) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceLinkProvider_GetRootWebLink_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetRootWebLinkPrametersTypes = new Type[] { typeof(EnumerableRowCollection<DataRow>) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workspaceLinkProviderInstance, MethodGetRootWebLink, Fixture, methodGetRootWebLinkPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetRootWebLinkPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetRootWebLink) (Return Type : SPNavLink) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceLinkProvider_GetRootWebLink_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetRootWebLinkPrametersTypes = new Type[] { typeof(EnumerableRowCollection<DataRow>) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workspaceLinkProviderInstance, MethodGetRootWebLink, Fixture, methodGetRootWebLinkPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetRootWebLinkPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRootWebLink) (Return Type : SPNavLink) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceLinkProvider_GetRootWebLink_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetRootWebLink, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workspaceLinkProviderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRootWebLink) (Return Type : SPNavLink) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceLinkProvider_GetRootWebLink_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetRootWebLink, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkspaceLinkProvider_GetLinks_Method_Call_Internally(Type[] types)
        {
            var methodGetLinksPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workspaceLinkProviderInstance, MethodGetLinks, Fixture, methodGetLinksPrametersTypes);
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceLinkProvider_GetLinks_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _workspaceLinkProviderInstance.GetLinks();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceLinkProvider_GetLinks_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetLinksPrametersTypes = null;
            object[] parametersOfGetLinks = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetLinks, methodGetLinksPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<WorkspaceLinkProvider, IEnumerable<INavObject>>(_workspaceLinkProviderInstanceFixture, out exception1, parametersOfGetLinks);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<WorkspaceLinkProvider, IEnumerable<INavObject>>(_workspaceLinkProviderInstance, MethodGetLinks, parametersOfGetLinks, methodGetLinksPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetLinks.ShouldBeNull();
            methodGetLinksPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(() => methodInfo.Invoke(_workspaceLinkProviderInstanceFixture, parametersOfGetLinks));
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceLinkProvider_GetLinks_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetLinksPrametersTypes = null;
            object[] parametersOfGetLinks = null; // no parameter present

            // Assert
            parametersOfGetLinks.ShouldBeNull();
            methodGetLinksPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<WorkspaceLinkProvider, IEnumerable<INavObject>>(_workspaceLinkProviderInstance, MethodGetLinks, parametersOfGetLinks, methodGetLinksPrametersTypes));
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceLinkProvider_GetLinks_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetLinksPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workspaceLinkProviderInstance, MethodGetLinks, Fixture, methodGetLinksPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetLinksPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceLinkProvider_GetLinks_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetLinksPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workspaceLinkProviderInstance, MethodGetLinks, Fixture, methodGetLinksPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetLinksPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceLinkProvider_GetLinks_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetLinks, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workspaceLinkProviderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #endregion

        #endregion
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.AutoFixtureSetup;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Navigation;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using MultiAppCustomSiteMapProvider = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.MultiAppCustomSiteMapProvider" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class MultiAppCustomSiteMapProviderTest : AbstractBaseSetupTypedTest<MultiAppCustomSiteMapProvider>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (MultiAppCustomSiteMapProvider) Initializer

        private const string MethodGetChildNodes = "GetChildNodes";
        private const string MethodCanShowChildNode = "CanShowChildNode";
        private const string MethodTryGetMatchingNavNode = "TryGetMatchingNavNode";
        private const string MethodGetUserGroups = "GetUserGroups";
        private const string MethodIsTopNavBarLink = "IsTopNavBarLink";
        private const string Field_siteId = "_siteId";
        private const string Field_webId = "_webId";
        private const string Field_userId = "_userId";
        private const string FieldappHelper = "appHelper";
        private Type _multiAppCustomSiteMapProviderInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private MultiAppCustomSiteMapProvider _multiAppCustomSiteMapProviderInstance;
        private MultiAppCustomSiteMapProvider _multiAppCustomSiteMapProviderInstanceFixture;

        #region General Initializer : Class (MultiAppCustomSiteMapProvider) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="MultiAppCustomSiteMapProvider" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _multiAppCustomSiteMapProviderInstanceType = typeof(MultiAppCustomSiteMapProvider);
            _multiAppCustomSiteMapProviderInstanceFixture = Create(true);
            _multiAppCustomSiteMapProviderInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (MultiAppCustomSiteMapProvider)

        #region General Initializer : Class (MultiAppCustomSiteMapProvider) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="MultiAppCustomSiteMapProvider" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetChildNodes, 0)]
        [TestCase(MethodCanShowChildNode, 0)]
        [TestCase(MethodTryGetMatchingNavNode, 0)]
        [TestCase(MethodGetUserGroups, 0)]
        [TestCase(MethodIsTopNavBarLink, 0)]
        public void AUT_MultiAppCustomSiteMapProvider_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_multiAppCustomSiteMapProviderInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (MultiAppCustomSiteMapProvider) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="MultiAppCustomSiteMapProvider" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_siteId)]
        [TestCase(Field_webId)]
        [TestCase(Field_userId)]
        [TestCase(FieldappHelper)]
        public void AUT_MultiAppCustomSiteMapProvider_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_multiAppCustomSiteMapProviderInstanceFixture, 
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
        ///      Class (<see cref="MultiAppCustomSiteMapProvider" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetChildNodes)]
        [TestCase(MethodCanShowChildNode)]
        [TestCase(MethodTryGetMatchingNavNode)]
        [TestCase(MethodGetUserGroups)]
        [TestCase(MethodIsTopNavBarLink)]
        public void AUT_MultiAppCustomSiteMapProvider_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<MultiAppCustomSiteMapProvider>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetChildNodes) (Return Type : SiteMapNodeCollection) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MultiAppCustomSiteMapProvider_GetChildNodes_Method_Call_Internally(Type[] types)
        {
            var methodGetChildNodesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_multiAppCustomSiteMapProviderInstance, MethodGetChildNodes, Fixture, methodGetChildNodesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetChildNodes) (Return Type : SiteMapNodeCollection) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MultiAppCustomSiteMapProvider_GetChildNodes_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var node = CreateType<SiteMapNode>();
            Action executeAction = null;

            // Act
            executeAction = () => _multiAppCustomSiteMapProviderInstance.GetChildNodes(node);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetChildNodes) (Return Type : SiteMapNodeCollection) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MultiAppCustomSiteMapProvider_GetChildNodes_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var node = CreateType<SiteMapNode>();
            var methodGetChildNodesPrametersTypes = new Type[] { typeof(SiteMapNode) };
            object[] parametersOfGetChildNodes = { node };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetChildNodes, methodGetChildNodesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<MultiAppCustomSiteMapProvider, SiteMapNodeCollection>(_multiAppCustomSiteMapProviderInstanceFixture, out exception1, parametersOfGetChildNodes);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<MultiAppCustomSiteMapProvider, SiteMapNodeCollection>(_multiAppCustomSiteMapProviderInstance, MethodGetChildNodes, parametersOfGetChildNodes, methodGetChildNodesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetChildNodes.ShouldNotBeNull();
            parametersOfGetChildNodes.Length.ShouldBe(1);
            methodGetChildNodesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetChildNodes) (Return Type : SiteMapNodeCollection) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MultiAppCustomSiteMapProvider_GetChildNodes_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var node = CreateType<SiteMapNode>();
            var methodGetChildNodesPrametersTypes = new Type[] { typeof(SiteMapNode) };
            object[] parametersOfGetChildNodes = { node };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<MultiAppCustomSiteMapProvider, SiteMapNodeCollection>(_multiAppCustomSiteMapProviderInstance, MethodGetChildNodes, parametersOfGetChildNodes, methodGetChildNodesPrametersTypes);

            // Assert
            parametersOfGetChildNodes.ShouldNotBeNull();
            parametersOfGetChildNodes.Length.ShouldBe(1);
            methodGetChildNodesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetChildNodes) (Return Type : SiteMapNodeCollection) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MultiAppCustomSiteMapProvider_GetChildNodes_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetChildNodesPrametersTypes = new Type[] { typeof(SiteMapNode) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_multiAppCustomSiteMapProviderInstance, MethodGetChildNodes, Fixture, methodGetChildNodesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetChildNodesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetChildNodes) (Return Type : SiteMapNodeCollection) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MultiAppCustomSiteMapProvider_GetChildNodes_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetChildNodesPrametersTypes = new Type[] { typeof(SiteMapNode) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_multiAppCustomSiteMapProviderInstance, MethodGetChildNodes, Fixture, methodGetChildNodesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetChildNodesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetChildNodes) (Return Type : SiteMapNodeCollection) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MultiAppCustomSiteMapProvider_GetChildNodes_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetChildNodes, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_multiAppCustomSiteMapProviderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetChildNodes) (Return Type : SiteMapNodeCollection) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MultiAppCustomSiteMapProvider_GetChildNodes_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetChildNodes, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CanShowChildNode) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MultiAppCustomSiteMapProvider_CanShowChildNode_Method_Call_Internally(Type[] types)
        {
            var methodCanShowChildNodePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_multiAppCustomSiteMapProviderInstance, MethodCanShowChildNode, Fixture, methodCanShowChildNodePrametersTypes);
        }

        #endregion

        #region Method Call : (CanShowChildNode) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MultiAppCustomSiteMapProvider_CanShowChildNode_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var n = CreateType<SiteMapNode>();
            var globalNavIds = CreateType<List<int>>();
            var methodCanShowChildNodePrametersTypes = new Type[] { typeof(SiteMapNode), typeof(List<int>) };
            object[] parametersOfCanShowChildNode = { n, globalNavIds };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCanShowChildNode, methodCanShowChildNodePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<MultiAppCustomSiteMapProvider, bool>(_multiAppCustomSiteMapProviderInstanceFixture, out exception1, parametersOfCanShowChildNode);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<MultiAppCustomSiteMapProvider, bool>(_multiAppCustomSiteMapProviderInstance, MethodCanShowChildNode, parametersOfCanShowChildNode, methodCanShowChildNodePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfCanShowChildNode.ShouldNotBeNull();
            parametersOfCanShowChildNode.Length.ShouldBe(2);
            methodCanShowChildNodePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (CanShowChildNode) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MultiAppCustomSiteMapProvider_CanShowChildNode_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var n = CreateType<SiteMapNode>();
            var globalNavIds = CreateType<List<int>>();
            var methodCanShowChildNodePrametersTypes = new Type[] { typeof(SiteMapNode), typeof(List<int>) };
            object[] parametersOfCanShowChildNode = { n, globalNavIds };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCanShowChildNode, methodCanShowChildNodePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<MultiAppCustomSiteMapProvider, bool>(_multiAppCustomSiteMapProviderInstanceFixture, out exception1, parametersOfCanShowChildNode);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<MultiAppCustomSiteMapProvider, bool>(_multiAppCustomSiteMapProviderInstance, MethodCanShowChildNode, parametersOfCanShowChildNode, methodCanShowChildNodePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfCanShowChildNode.ShouldNotBeNull();
            parametersOfCanShowChildNode.Length.ShouldBe(2);
            methodCanShowChildNodePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (CanShowChildNode) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MultiAppCustomSiteMapProvider_CanShowChildNode_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var n = CreateType<SiteMapNode>();
            var globalNavIds = CreateType<List<int>>();
            var methodCanShowChildNodePrametersTypes = new Type[] { typeof(SiteMapNode), typeof(List<int>) };
            object[] parametersOfCanShowChildNode = { n, globalNavIds };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<MultiAppCustomSiteMapProvider, bool>(_multiAppCustomSiteMapProviderInstance, MethodCanShowChildNode, parametersOfCanShowChildNode, methodCanShowChildNodePrametersTypes);

            // Assert
            parametersOfCanShowChildNode.ShouldNotBeNull();
            parametersOfCanShowChildNode.Length.ShouldBe(2);
            methodCanShowChildNodePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CanShowChildNode) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MultiAppCustomSiteMapProvider_CanShowChildNode_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCanShowChildNodePrametersTypes = new Type[] { typeof(SiteMapNode), typeof(List<int>) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_multiAppCustomSiteMapProviderInstance, MethodCanShowChildNode, Fixture, methodCanShowChildNodePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCanShowChildNodePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CanShowChildNode) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MultiAppCustomSiteMapProvider_CanShowChildNode_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCanShowChildNode, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_multiAppCustomSiteMapProviderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CanShowChildNode) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MultiAppCustomSiteMapProvider_CanShowChildNode_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCanShowChildNode, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TryGetMatchingNavNode) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MultiAppCustomSiteMapProvider_TryGetMatchingNavNode_Method_Call_Internally(Type[] types)
        {
            var methodTryGetMatchingNavNodePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_multiAppCustomSiteMapProviderInstance, MethodTryGetMatchingNavNode, Fixture, methodTryGetMatchingNavNodePrametersTypes);
        }

        #endregion

        #region Method Call : (TryGetMatchingNavNode) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MultiAppCustomSiteMapProvider_TryGetMatchingNavNode_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sn = CreateType<SiteMapNode>();
            var navNode = CreateType<SPNavigationNode>();
            var methodTryGetMatchingNavNodePrametersTypes = new Type[] { typeof(SiteMapNode), typeof(SPNavigationNode) };
            object[] parametersOfTryGetMatchingNavNode = { sn, navNode };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodTryGetMatchingNavNode, methodTryGetMatchingNavNodePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<MultiAppCustomSiteMapProvider, bool>(_multiAppCustomSiteMapProviderInstanceFixture, out exception1, parametersOfTryGetMatchingNavNode);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<MultiAppCustomSiteMapProvider, bool>(_multiAppCustomSiteMapProviderInstance, MethodTryGetMatchingNavNode, parametersOfTryGetMatchingNavNode, methodTryGetMatchingNavNodePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfTryGetMatchingNavNode.ShouldNotBeNull();
            parametersOfTryGetMatchingNavNode.Length.ShouldBe(2);
            methodTryGetMatchingNavNodePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (TryGetMatchingNavNode) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MultiAppCustomSiteMapProvider_TryGetMatchingNavNode_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sn = CreateType<SiteMapNode>();
            var navNode = CreateType<SPNavigationNode>();
            var methodTryGetMatchingNavNodePrametersTypes = new Type[] { typeof(SiteMapNode), typeof(SPNavigationNode) };
            object[] parametersOfTryGetMatchingNavNode = { sn, navNode };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodTryGetMatchingNavNode, methodTryGetMatchingNavNodePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<MultiAppCustomSiteMapProvider, bool>(_multiAppCustomSiteMapProviderInstanceFixture, out exception1, parametersOfTryGetMatchingNavNode);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<MultiAppCustomSiteMapProvider, bool>(_multiAppCustomSiteMapProviderInstance, MethodTryGetMatchingNavNode, parametersOfTryGetMatchingNavNode, methodTryGetMatchingNavNodePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfTryGetMatchingNavNode.ShouldNotBeNull();
            parametersOfTryGetMatchingNavNode.Length.ShouldBe(2);
            methodTryGetMatchingNavNodePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (TryGetMatchingNavNode) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MultiAppCustomSiteMapProvider_TryGetMatchingNavNode_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sn = CreateType<SiteMapNode>();
            var navNode = CreateType<SPNavigationNode>();
            var methodTryGetMatchingNavNodePrametersTypes = new Type[] { typeof(SiteMapNode), typeof(SPNavigationNode) };
            object[] parametersOfTryGetMatchingNavNode = { sn, navNode };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<MultiAppCustomSiteMapProvider, bool>(_multiAppCustomSiteMapProviderInstance, MethodTryGetMatchingNavNode, parametersOfTryGetMatchingNavNode, methodTryGetMatchingNavNodePrametersTypes);

            // Assert
            parametersOfTryGetMatchingNavNode.ShouldNotBeNull();
            parametersOfTryGetMatchingNavNode.Length.ShouldBe(2);
            methodTryGetMatchingNavNodePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (TryGetMatchingNavNode) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MultiAppCustomSiteMapProvider_TryGetMatchingNavNode_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodTryGetMatchingNavNodePrametersTypes = new Type[] { typeof(SiteMapNode), typeof(SPNavigationNode) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_multiAppCustomSiteMapProviderInstance, MethodTryGetMatchingNavNode, Fixture, methodTryGetMatchingNavNodePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodTryGetMatchingNavNodePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TryGetMatchingNavNode) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MultiAppCustomSiteMapProvider_TryGetMatchingNavNode_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodTryGetMatchingNavNode, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_multiAppCustomSiteMapProviderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (TryGetMatchingNavNode) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MultiAppCustomSiteMapProvider_TryGetMatchingNavNode_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodTryGetMatchingNavNode, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetUserGroups) (Return Type : List<string>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MultiAppCustomSiteMapProvider_GetUserGroups_Method_Call_Internally(Type[] types)
        {
            var methodGetUserGroupsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_multiAppCustomSiteMapProviderInstance, MethodGetUserGroups, Fixture, methodGetUserGroupsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetUserGroups) (Return Type : List<string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MultiAppCustomSiteMapProvider_GetUserGroups_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var user = CreateType<SPUser>();
            var methodGetUserGroupsPrametersTypes = new Type[] { typeof(SPUser) };
            object[] parametersOfGetUserGroups = { user };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetUserGroups, methodGetUserGroupsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<MultiAppCustomSiteMapProvider, List<string>>(_multiAppCustomSiteMapProviderInstanceFixture, out exception1, parametersOfGetUserGroups);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<MultiAppCustomSiteMapProvider, List<string>>(_multiAppCustomSiteMapProviderInstance, MethodGetUserGroups, parametersOfGetUserGroups, methodGetUserGroupsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetUserGroups.ShouldNotBeNull();
            parametersOfGetUserGroups.Length.ShouldBe(1);
            methodGetUserGroupsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetUserGroups) (Return Type : List<string>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MultiAppCustomSiteMapProvider_GetUserGroups_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var user = CreateType<SPUser>();
            var methodGetUserGroupsPrametersTypes = new Type[] { typeof(SPUser) };
            object[] parametersOfGetUserGroups = { user };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<MultiAppCustomSiteMapProvider, List<string>>(_multiAppCustomSiteMapProviderInstance, MethodGetUserGroups, parametersOfGetUserGroups, methodGetUserGroupsPrametersTypes);

            // Assert
            parametersOfGetUserGroups.ShouldNotBeNull();
            parametersOfGetUserGroups.Length.ShouldBe(1);
            methodGetUserGroupsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetUserGroups) (Return Type : List<string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MultiAppCustomSiteMapProvider_GetUserGroups_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetUserGroupsPrametersTypes = new Type[] { typeof(SPUser) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_multiAppCustomSiteMapProviderInstance, MethodGetUserGroups, Fixture, methodGetUserGroupsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetUserGroupsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetUserGroups) (Return Type : List<string>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MultiAppCustomSiteMapProvider_GetUserGroups_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetUserGroupsPrametersTypes = new Type[] { typeof(SPUser) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_multiAppCustomSiteMapProviderInstance, MethodGetUserGroups, Fixture, methodGetUserGroupsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetUserGroupsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetUserGroups) (Return Type : List<string>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MultiAppCustomSiteMapProvider_GetUserGroups_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetUserGroups, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_multiAppCustomSiteMapProviderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetUserGroups) (Return Type : List<string>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MultiAppCustomSiteMapProvider_GetUserGroups_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetUserGroups, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsTopNavBarLink) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MultiAppCustomSiteMapProvider_IsTopNavBarLink_Method_Call_Internally(Type[] types)
        {
            var methodIsTopNavBarLinkPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_multiAppCustomSiteMapProviderInstance, MethodIsTopNavBarLink, Fixture, methodIsTopNavBarLinkPrametersTypes);
        }

        #endregion

        #region Method Call : (IsTopNavBarLink) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MultiAppCustomSiteMapProvider_IsTopNavBarLink_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var smn = CreateType<SiteMapNode>();
            var methodIsTopNavBarLinkPrametersTypes = new Type[] { typeof(SiteMapNode) };
            object[] parametersOfIsTopNavBarLink = { smn };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsTopNavBarLink, methodIsTopNavBarLinkPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<MultiAppCustomSiteMapProvider, bool>(_multiAppCustomSiteMapProviderInstanceFixture, out exception1, parametersOfIsTopNavBarLink);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<MultiAppCustomSiteMapProvider, bool>(_multiAppCustomSiteMapProviderInstance, MethodIsTopNavBarLink, parametersOfIsTopNavBarLink, methodIsTopNavBarLinkPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsTopNavBarLink.ShouldNotBeNull();
            parametersOfIsTopNavBarLink.Length.ShouldBe(1);
            methodIsTopNavBarLinkPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (IsTopNavBarLink) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MultiAppCustomSiteMapProvider_IsTopNavBarLink_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var smn = CreateType<SiteMapNode>();
            var methodIsTopNavBarLinkPrametersTypes = new Type[] { typeof(SiteMapNode) };
            object[] parametersOfIsTopNavBarLink = { smn };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsTopNavBarLink, methodIsTopNavBarLinkPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<MultiAppCustomSiteMapProvider, bool>(_multiAppCustomSiteMapProviderInstanceFixture, out exception1, parametersOfIsTopNavBarLink);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<MultiAppCustomSiteMapProvider, bool>(_multiAppCustomSiteMapProviderInstance, MethodIsTopNavBarLink, parametersOfIsTopNavBarLink, methodIsTopNavBarLinkPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsTopNavBarLink.ShouldNotBeNull();
            parametersOfIsTopNavBarLink.Length.ShouldBe(1);
            methodIsTopNavBarLinkPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (IsTopNavBarLink) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MultiAppCustomSiteMapProvider_IsTopNavBarLink_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var smn = CreateType<SiteMapNode>();
            var methodIsTopNavBarLinkPrametersTypes = new Type[] { typeof(SiteMapNode) };
            object[] parametersOfIsTopNavBarLink = { smn };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<MultiAppCustomSiteMapProvider, bool>(_multiAppCustomSiteMapProviderInstance, MethodIsTopNavBarLink, parametersOfIsTopNavBarLink, methodIsTopNavBarLinkPrametersTypes);

            // Assert
            parametersOfIsTopNavBarLink.ShouldNotBeNull();
            parametersOfIsTopNavBarLink.Length.ShouldBe(1);
            methodIsTopNavBarLinkPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsTopNavBarLink) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MultiAppCustomSiteMapProvider_IsTopNavBarLink_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsTopNavBarLinkPrametersTypes = new Type[] { typeof(SiteMapNode) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_multiAppCustomSiteMapProviderInstance, MethodIsTopNavBarLink, Fixture, methodIsTopNavBarLinkPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsTopNavBarLinkPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsTopNavBarLink) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MultiAppCustomSiteMapProvider_IsTopNavBarLink_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsTopNavBarLink, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_multiAppCustomSiteMapProviderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsTopNavBarLink) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MultiAppCustomSiteMapProvider_IsTopNavBarLink_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodIsTopNavBarLink, 0);
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
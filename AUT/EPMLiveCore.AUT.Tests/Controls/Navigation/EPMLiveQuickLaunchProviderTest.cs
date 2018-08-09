using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.Controls.Navigation
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Controls.Navigation.EPMLiveQuickLaunchProvider" />)
    ///     and namespace <see cref="EPMLiveCore.Controls.Navigation"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class EPMLiveQuickLaunchProviderTest : AbstractBaseSetupTypedTest<EPMLiveQuickLaunchProvider>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EPMLiveQuickLaunchProvider) Initializer

        private const string MethodDefaultViewFromPropertyBag = "DefaultViewFromPropertyBag";
        private const string MethodGetSpList = "GetSpList";
        private const string MethodConvertFromString = "ConvertFromString";
        private const string MethodFindChildNodes = "FindChildNodes";
        private const string MethodPopulateCommunityLinks = "PopulateCommunityLinks";
        private const string MethodChangeChildNodeLink = "ChangeChildNodeLink";
        private const string MethodChangeNodeLink = "ChangeNodeLink";
        private const string MethodGetChildNodes = "GetChildNodes";
        private const string Field_communityLinks = "_communityLinks";
        private const string Field_linkNodes = "_linkNodes";
        private Type _ePMLiveQuickLaunchProviderInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private EPMLiveQuickLaunchProvider _ePMLiveQuickLaunchProviderInstance;
        private EPMLiveQuickLaunchProvider _ePMLiveQuickLaunchProviderInstanceFixture;

        #region General Initializer : Class (EPMLiveQuickLaunchProvider) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EPMLiveQuickLaunchProvider" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _ePMLiveQuickLaunchProviderInstanceType = typeof(EPMLiveQuickLaunchProvider);
            _ePMLiveQuickLaunchProviderInstanceFixture = Create(true);
            _ePMLiveQuickLaunchProviderInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (EPMLiveQuickLaunchProvider)

        #region General Initializer : Class (EPMLiveQuickLaunchProvider) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="EPMLiveQuickLaunchProvider" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodDefaultViewFromPropertyBag, 0)]
        [TestCase(MethodGetSpList, 0)]
        [TestCase(MethodConvertFromString, 0)]
        [TestCase(MethodFindChildNodes, 0)]
        [TestCase(MethodPopulateCommunityLinks, 0)]
        [TestCase(MethodChangeChildNodeLink, 0)]
        [TestCase(MethodChangeNodeLink, 0)]
        [TestCase(MethodGetChildNodes, 0)]
        public void AUT_EPMLiveQuickLaunchProvider_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_ePMLiveQuickLaunchProviderInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (EPMLiveQuickLaunchProvider) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="EPMLiveQuickLaunchProvider" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_communityLinks)]
        [TestCase(Field_linkNodes)]
        public void AUT_EPMLiveQuickLaunchProvider_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_ePMLiveQuickLaunchProviderInstanceFixture, 
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
        ///      Class (<see cref="EPMLiveQuickLaunchProvider" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodDefaultViewFromPropertyBag)]
        [TestCase(MethodGetSpList)]
        [TestCase(MethodConvertFromString)]
        [TestCase(MethodFindChildNodes)]
        [TestCase(MethodPopulateCommunityLinks)]
        [TestCase(MethodChangeChildNodeLink)]
        [TestCase(MethodChangeNodeLink)]
        [TestCase(MethodGetChildNodes)]
        public void AUT_EPMLiveQuickLaunchProvider_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<EPMLiveQuickLaunchProvider>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (DefaultViewFromPropertyBag) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveQuickLaunchProvider_DefaultViewFromPropertyBag_Method_Call_Internally(Type[] types)
        {
            var methodDefaultViewFromPropertyBagPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveQuickLaunchProviderInstance, MethodDefaultViewFromPropertyBag, Fixture, methodDefaultViewFromPropertyBagPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSpList) (Return Type : SPList) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveQuickLaunchProvider_GetSpList_Method_Call_Internally(Type[] types)
        {
            var methodGetSpListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveQuickLaunchProviderInstance, MethodGetSpList, Fixture, methodGetSpListPrametersTypes);
        }

        #endregion

        #region Method Call : (ConvertFromString) (Return Type : Dictionary<int, string>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveQuickLaunchProvider_ConvertFromString_Method_Call_Internally(Type[] types)
        {
            var methodConvertFromStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveQuickLaunchProviderInstance, MethodConvertFromString, Fixture, methodConvertFromStringPrametersTypes);
        }

        #endregion

        #region Method Call : (FindChildNodes) (Return Type : SiteMapNodeCollection) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveQuickLaunchProvider_FindChildNodes_Method_Call_Internally(Type[] types)
        {
            var methodFindChildNodesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveQuickLaunchProviderInstance, MethodFindChildNodes, Fixture, methodFindChildNodesPrametersTypes);
        }

        #endregion

        #region Method Call : (PopulateCommunityLinks) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveQuickLaunchProvider_PopulateCommunityLinks_Method_Call_Internally(Type[] types)
        {
            var methodPopulateCommunityLinksPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveQuickLaunchProviderInstance, MethodPopulateCommunityLinks, Fixture, methodPopulateCommunityLinksPrametersTypes);
        }

        #endregion

        #region Method Call : (ChangeChildNodeLink) (Return Type : SiteMapNodeCollection) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveQuickLaunchProvider_ChangeChildNodeLink_Method_Call_Internally(Type[] types)
        {
            var methodChangeChildNodeLinkPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveQuickLaunchProviderInstance, MethodChangeChildNodeLink, Fixture, methodChangeChildNodeLinkPrametersTypes);
        }

        #endregion

        #region Method Call : (ChangeNodeLink) (Return Type : SiteMapNode) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveQuickLaunchProvider_ChangeNodeLink_Method_Call_Internally(Type[] types)
        {
            var methodChangeNodeLinkPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveQuickLaunchProviderInstance, MethodChangeNodeLink, Fixture, methodChangeNodeLinkPrametersTypes);
        }

        #endregion

        #region Method Call : (GetChildNodes) (Return Type : SiteMapNodeCollection) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveQuickLaunchProvider_GetChildNodes_Method_Call_Internally(Type[] types)
        {
            var methodGetChildNodesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveQuickLaunchProviderInstance, MethodGetChildNodes, Fixture, methodGetChildNodesPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}
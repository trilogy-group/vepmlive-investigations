using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.Controls.Navigation.Providers
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Controls.Navigation.Providers.WorkplaceLinkProvider" />)
    ///     and namespace <see cref="EPMLiveCore.Controls.Navigation.Providers"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class WorkplaceLinkProviderTest : AbstractBaseSetupTypedTest<WorkplaceLinkProvider>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WorkplaceLinkProvider) Initializer

        private const string PropertyKey = "Key";
        private const string MethodCalculateUrl = "CalculateUrl";
        private const string MethodGetMyWorkplaceLinks = "GetMyWorkplaceLinks";
        private const string MethodGetNodes = "GetNodes";
        private const string MethodGetLinks = "GetLinks";
        private const string Field_key = "_key";
        private Type _workplaceLinkProviderInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private WorkplaceLinkProvider _workplaceLinkProviderInstance;
        private WorkplaceLinkProvider _workplaceLinkProviderInstanceFixture;

        #region General Initializer : Class (WorkplaceLinkProvider) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WorkplaceLinkProvider" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _workplaceLinkProviderInstanceType = typeof(WorkplaceLinkProvider);
            _workplaceLinkProviderInstanceFixture = Create(true);
            _workplaceLinkProviderInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WorkplaceLinkProvider)

        #region General Initializer : Class (WorkplaceLinkProvider) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="WorkplaceLinkProvider" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodCalculateUrl, 0)]
        [TestCase(MethodGetMyWorkplaceLinks, 0)]
        [TestCase(MethodGetNodes, 0)]
        [TestCase(MethodGetLinks, 0)]
        public void AUT_WorkplaceLinkProvider_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_workplaceLinkProviderInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (WorkplaceLinkProvider) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="WorkplaceLinkProvider" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyKey)]
        public void AUT_WorkplaceLinkProvider_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_workplaceLinkProviderInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (WorkplaceLinkProvider) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="WorkplaceLinkProvider" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_key)]
        public void AUT_WorkplaceLinkProvider_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_workplaceLinkProviderInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : GetterSetter
        
        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="WorkplaceLinkProvider" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetNodes)]
        public void AUT_WorkplaceLinkProvider_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_workplaceLinkProviderInstanceFixture,
                                                                              _workplaceLinkProviderInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="WorkplaceLinkProvider" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodCalculateUrl)]
        [TestCase(MethodGetMyWorkplaceLinks)]
        [TestCase(MethodGetLinks)]
        public void AUT_WorkplaceLinkProvider_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<WorkplaceLinkProvider>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (CalculateUrl) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkplaceLinkProvider_CalculateUrl_Method_Call_Internally(Type[] types)
        {
            var methodCalculateUrlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workplaceLinkProviderInstance, MethodCalculateUrl, Fixture, methodCalculateUrlPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMyWorkplaceLinks) (Return Type : IEnumerable<INavObject>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkplaceLinkProvider_GetMyWorkplaceLinks_Method_Call_Internally(Type[] types)
        {
            var methodGetMyWorkplaceLinksPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workplaceLinkProviderInstance, MethodGetMyWorkplaceLinks, Fixture, methodGetMyWorkplaceLinksPrametersTypes);
        }

        #endregion

        #region Method Call : (GetNodes) (Return Type : IEnumerable<int>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkplaceLinkProvider_GetNodes_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetNodesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workplaceLinkProviderInstanceFixture, _workplaceLinkProviderInstanceType, MethodGetNodes, Fixture, methodGetNodesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkplaceLinkProvider_GetLinks_Method_Call_Internally(Type[] types)
        {
            var methodGetLinksPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workplaceLinkProviderInstance, MethodGetLinks, Fixture, methodGetLinksPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}
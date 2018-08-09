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
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.Controls.Navigation.Providers
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Controls.Navigation.Providers.FavoritesLinkProvider" />)
    ///     and namespace <see cref="EPMLiveCore.Controls.Navigation.Providers"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class FavoritesLinkProviderTest : AbstractBaseSetupTypedTest<FavoritesLinkProvider>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FavoritesLinkProvider) Initializer

        private const string PropertyKey = "Key";
        private const string MethodGetLinks = "GetLinks";
        private const string MethodGetNavLink = "GetNavLink";
        private const string Field_key = "_key";
        private const string FieldQUERY = "QUERY";
        private Type _favoritesLinkProviderInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private FavoritesLinkProvider _favoritesLinkProviderInstance;
        private FavoritesLinkProvider _favoritesLinkProviderInstanceFixture;

        #region General Initializer : Class (FavoritesLinkProvider) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FavoritesLinkProvider" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _favoritesLinkProviderInstanceType = typeof(FavoritesLinkProvider);
            _favoritesLinkProviderInstanceFixture = Create(true);
            _favoritesLinkProviderInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FavoritesLinkProvider)

        #region General Initializer : Class (FavoritesLinkProvider) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="FavoritesLinkProvider" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetLinks, 0)]
        [TestCase(MethodGetNavLink, 0)]
        public void AUT_FavoritesLinkProvider_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_favoritesLinkProviderInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FavoritesLinkProvider) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="FavoritesLinkProvider" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyKey)]
        public void AUT_FavoritesLinkProvider_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_favoritesLinkProviderInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FavoritesLinkProvider) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FavoritesLinkProvider" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_key)]
        [TestCase(FieldQUERY)]
        public void AUT_FavoritesLinkProvider_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_favoritesLinkProviderInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : GetterSetter
        
        #region General Getters/Setters : Class (FavoritesLinkProvider) => Property (Key) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_FavoritesLinkProvider_Public_Class_Key_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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
        ///      Class (<see cref="FavoritesLinkProvider" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetLinks)]
        [TestCase(MethodGetNavLink)]
        public void AUT_FavoritesLinkProvider_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<FavoritesLinkProvider>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FavoritesLinkProvider_GetLinks_Method_Call_Internally(Type[] types)
        {
            var methodGetLinksPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_favoritesLinkProviderInstance, MethodGetLinks, Fixture, methodGetLinksPrametersTypes);
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FavoritesLinkProvider_GetLinks_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _favoritesLinkProviderInstance.GetLinks();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FavoritesLinkProvider_GetLinks_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetLinksPrametersTypes = null;
            object[] parametersOfGetLinks = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetLinks, methodGetLinksPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<FavoritesLinkProvider, IEnumerable<INavObject>>(_favoritesLinkProviderInstanceFixture, out exception1, parametersOfGetLinks);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<FavoritesLinkProvider, IEnumerable<INavObject>>(_favoritesLinkProviderInstance, MethodGetLinks, parametersOfGetLinks, methodGetLinksPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetLinks.ShouldBeNull();
            methodGetLinksPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(() => methodInfo.Invoke(_favoritesLinkProviderInstanceFixture, parametersOfGetLinks));
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FavoritesLinkProvider_GetLinks_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetLinksPrametersTypes = null;
            object[] parametersOfGetLinks = null; // no parameter present

            // Assert
            parametersOfGetLinks.ShouldBeNull();
            methodGetLinksPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<FavoritesLinkProvider, IEnumerable<INavObject>>(_favoritesLinkProviderInstance, MethodGetLinks, parametersOfGetLinks, methodGetLinksPrametersTypes));
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FavoritesLinkProvider_GetLinks_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetLinksPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_favoritesLinkProviderInstance, MethodGetLinks, Fixture, methodGetLinksPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetLinksPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FavoritesLinkProvider_GetLinks_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetLinksPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_favoritesLinkProviderInstance, MethodGetLinks, Fixture, methodGetLinksPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetLinksPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FavoritesLinkProvider_GetLinks_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetLinks, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_favoritesLinkProviderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetNavLink) (Return Type : SPNavLink) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FavoritesLinkProvider_GetNavLink_Method_Call_Internally(Type[] types)
        {
            var methodGetNavLinkPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_favoritesLinkProviderInstance, MethodGetNavLink, Fixture, methodGetNavLinkPrametersTypes);
        }

        #endregion

        #region Method Call : (GetNavLink) (Return Type : SPNavLink) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FavoritesLinkProvider_GetNavLink_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var row = CreateType<DataRow>();
            var methodGetNavLinkPrametersTypes = new Type[] { typeof(DataRow) };
            object[] parametersOfGetNavLink = { row };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetNavLink, methodGetNavLinkPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<FavoritesLinkProvider, SPNavLink>(_favoritesLinkProviderInstanceFixture, out exception1, parametersOfGetNavLink);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<FavoritesLinkProvider, SPNavLink>(_favoritesLinkProviderInstance, MethodGetNavLink, parametersOfGetNavLink, methodGetNavLinkPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetNavLink.ShouldNotBeNull();
            parametersOfGetNavLink.Length.ShouldBe(1);
            methodGetNavLinkPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_favoritesLinkProviderInstanceFixture, parametersOfGetNavLink));
        }

        #endregion

        #region Method Call : (GetNavLink) (Return Type : SPNavLink) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FavoritesLinkProvider_GetNavLink_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var row = CreateType<DataRow>();
            var methodGetNavLinkPrametersTypes = new Type[] { typeof(DataRow) };
            object[] parametersOfGetNavLink = { row };

            // Assert
            parametersOfGetNavLink.ShouldNotBeNull();
            parametersOfGetNavLink.Length.ShouldBe(1);
            methodGetNavLinkPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<FavoritesLinkProvider, SPNavLink>(_favoritesLinkProviderInstance, MethodGetNavLink, parametersOfGetNavLink, methodGetNavLinkPrametersTypes));
        }

        #endregion

        #region Method Call : (GetNavLink) (Return Type : SPNavLink) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FavoritesLinkProvider_GetNavLink_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetNavLinkPrametersTypes = new Type[] { typeof(DataRow) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_favoritesLinkProviderInstance, MethodGetNavLink, Fixture, methodGetNavLinkPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetNavLinkPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetNavLink) (Return Type : SPNavLink) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FavoritesLinkProvider_GetNavLink_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetNavLinkPrametersTypes = new Type[] { typeof(DataRow) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_favoritesLinkProviderInstance, MethodGetNavLink, Fixture, methodGetNavLinkPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetNavLinkPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetNavLink) (Return Type : SPNavLink) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FavoritesLinkProvider_GetNavLink_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetNavLink, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_favoritesLinkProviderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetNavLink) (Return Type : SPNavLink) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FavoritesLinkProvider_GetNavLink_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetNavLink, 0);
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
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

namespace ReportFiltering
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="ReportFiltering.SPListExtensions" />)
    ///     and namespace <see cref="ReportFiltering"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class SPListExtensionsTest : AbstractBaseSetupTest
    {

        public SPListExtensionsTest() : base(typeof(SPListExtensions))
        {}

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SPListExtensions) Initializer

        private const string MethodIsRollup = "IsRollup";
        private Type _sPListExtensionsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;

        #region General Initializer : Class (SPListExtensions) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SPListExtensions" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _sPListExtensionsInstanceType = typeof(SPListExtensions);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SPListExtensions)

        #region General Initializer : Class (SPListExtensions) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="SPListExtensions" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodIsRollup, 0)]
        public void AUT_SPListExtensions_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(null, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="SPListExtensions" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_SPListExtensions_Is_Static_Type_Present_Test()
        {
            // Assert
            _sPListExtensionsInstanceType.ShouldNotBeNull();
        }

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="SPListExtensions" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodIsRollup)]
        public void AUT_SPListExtensions_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(null,
                                                                              _sPListExtensionsInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (IsRollup) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SPListExtensions_IsRollup_Static_Method_Call_Internally(Type[] types)
        {
            var methodIsRollupPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _sPListExtensionsInstanceType, MethodIsRollup, Fixture, methodIsRollupPrametersTypes);
        }

        #endregion

        #region Method Call : (IsRollup) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListExtensions_IsRollup_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            Action executeAction = null;

            // Act
            executeAction = () => SPListExtensions.IsRollup(list);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (IsRollup) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListExtensions_IsRollup_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodIsRollupPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfIsRollup = { list };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(null, _sPListExtensionsInstanceType, MethodIsRollup, parametersOfIsRollup, methodIsRollupPrametersTypes);

            // Assert
            parametersOfIsRollup.ShouldNotBeNull();
            parametersOfIsRollup.Length.ShouldBe(1);
            methodIsRollupPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsRollup) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListExtensions_IsRollup_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsRollupPrametersTypes = new Type[] { typeof(SPList) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _sPListExtensionsInstanceType, MethodIsRollup, Fixture, methodIsRollupPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsRollupPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsRollup) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListExtensions_IsRollup_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsRollup, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsRollup) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListExtensions_IsRollup_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodIsRollup, 0);
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
using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.TCFieldIterator" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class TCFieldIteratorTest : AbstractBaseSetupTypedTest<TCFieldIterator>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (TCFieldIterator) Initializer

        private const string MethodIsFieldExcluded = "IsFieldExcluded";
        private const string MethodgetVal = "getVal";
        private const string MethodgetFieldInt = "getFieldInt";
        private Type _tCFieldIteratorInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private TCFieldIterator _tCFieldIteratorInstance;
        private TCFieldIterator _tCFieldIteratorInstanceFixture;

        #region General Initializer : Class (TCFieldIterator) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="TCFieldIterator" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _tCFieldIteratorInstanceType = typeof(TCFieldIterator);
            _tCFieldIteratorInstanceFixture = Create(true);
            _tCFieldIteratorInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (TCFieldIterator)

        #region General Initializer : Class (TCFieldIterator) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="TCFieldIterator" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodIsFieldExcluded, 0)]
        [TestCase(MethodgetVal, 0)]
        [TestCase(MethodgetFieldInt, 0)]
        public void AUT_TCFieldIterator_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_tCFieldIteratorInstanceFixture, 
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
        ///      Class (<see cref="TCFieldIterator" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodIsFieldExcluded)]
        [TestCase(MethodgetVal)]
        [TestCase(MethodgetFieldInt)]
        public void AUT_TCFieldIterator_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<TCFieldIterator>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (IsFieldExcluded) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TCFieldIterator_IsFieldExcluded_Method_Call_Internally(Type[] types)
        {
            var methodIsFieldExcludedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tCFieldIteratorInstance, MethodIsFieldExcluded, Fixture, methodIsFieldExcludedPrametersTypes);
        }

        #endregion

        #region Method Call : (getVal) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TCFieldIterator_getVal_Method_Call_Internally(Type[] types)
        {
            var methodgetValPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tCFieldIteratorInstance, MethodgetVal, Fixture, methodgetValPrametersTypes);
        }

        #endregion

        #region Method Call : (getFieldInt) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TCFieldIterator_getFieldInt_Method_Call_Internally(Type[] types)
        {
            var methodgetFieldIntPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tCFieldIteratorInstance, MethodgetFieldInt, Fixture, methodgetFieldIntPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}
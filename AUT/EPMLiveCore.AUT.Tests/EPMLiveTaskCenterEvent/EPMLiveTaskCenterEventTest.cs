using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.EPMLiveTaskCenterEvent
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.EPMLiveTaskCenterEvent.EPMLiveTaskCenterEvent" />)
    ///     and namespace <see cref="EPMLiveCore.EPMLiveTaskCenterEvent"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class EPMLiveTaskCenterEventTest : AbstractBaseSetupTypedTest<EPMLiveTaskCenterEvent>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EPMLiveTaskCenterEvent) Initializer

        private const string MethodItemUpdating = "ItemUpdating";
        private Type _ePMLiveTaskCenterEventInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private EPMLiveTaskCenterEvent _ePMLiveTaskCenterEventInstance;
        private EPMLiveTaskCenterEvent _ePMLiveTaskCenterEventInstanceFixture;

        #region General Initializer : Class (EPMLiveTaskCenterEvent) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EPMLiveTaskCenterEvent" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _ePMLiveTaskCenterEventInstanceType = typeof(EPMLiveTaskCenterEvent);
            _ePMLiveTaskCenterEventInstanceFixture = Create(true);
            _ePMLiveTaskCenterEventInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (EPMLiveTaskCenterEvent)

        #region General Initializer : Class (EPMLiveTaskCenterEvent) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="EPMLiveTaskCenterEvent" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodItemUpdating, 0)]
        public void AUT_EPMLiveTaskCenterEvent_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_ePMLiveTaskCenterEventInstanceFixture, 
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
        ///      Class (<see cref="EPMLiveTaskCenterEvent" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodItemUpdating)]
        public void AUT_EPMLiveTaskCenterEvent_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<EPMLiveTaskCenterEvent>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (ItemUpdating) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveTaskCenterEvent_ItemUpdating_Method_Call_Internally(Type[] types)
        {
            var methodItemUpdatingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveTaskCenterEventInstance, MethodItemUpdating, Fixture, methodItemUpdatingPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}
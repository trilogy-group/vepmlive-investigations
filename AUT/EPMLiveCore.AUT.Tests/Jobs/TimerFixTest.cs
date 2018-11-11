using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.Jobs
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Jobs.TimerFix" />)
    ///     and namespace <see cref="EPMLiveCore.Jobs"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class TimerFixTest : AbstractBaseSetupTypedTest<TimerFix>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (TimerFix) Initializer

        private const string MethodstoreResPlanInfo = "storeResPlanInfo";
        private const string Methodexecute = "execute";
        private const string MethodgetResUrl = "getResUrl";
        private const string MethodprocessResPlan = "processResPlan";
        private const string MethodprocessWeb = "processWeb";
        private const string MethodgetListItemCount = "getListItemCount";
        private const string FielddtResLink = "dtResLink";
        private const string FielddtResInfo = "dtResInfo";
        private const string FieldsResErrors = "sResErrors";
        private const string FieldbResErrors = "bResErrors";
        private const string FieldsbErrors = "sbErrors";
        private Type _timerFixInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private TimerFix _timerFixInstance;
        private TimerFix _timerFixInstanceFixture;

        #region General Initializer : Class (TimerFix) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="TimerFix" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _timerFixInstanceType = typeof(TimerFix);
            _timerFixInstanceFixture = Create(true);
            _timerFixInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (TimerFix)

        #region General Initializer : Class (TimerFix) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="TimerFix" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodstoreResPlanInfo, 0)]
        [TestCase(Methodexecute, 0)]
        [TestCase(MethodgetResUrl, 0)]
        [TestCase(MethodprocessResPlan, 0)]
        [TestCase(MethodprocessWeb, 0)]
        [TestCase(MethodgetListItemCount, 0)]
        public void AUT_TimerFix_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_timerFixInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (TimerFix) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="TimerFix" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FielddtResLink)]
        [TestCase(FielddtResInfo)]
        [TestCase(FieldsResErrors)]
        [TestCase(FieldbResErrors)]
        [TestCase(FieldsbErrors)]
        public void AUT_TimerFix_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_timerFixInstanceFixture, 
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
        ///      Class (<see cref="TimerFix" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodstoreResPlanInfo)]
        [TestCase(Methodexecute)]
        [TestCase(MethodgetResUrl)]
        [TestCase(MethodprocessResPlan)]
        [TestCase(MethodprocessWeb)]
        [TestCase(MethodgetListItemCount)]
        public void AUT_TimerFix_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<TimerFix>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (storeResPlanInfo) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TimerFix_storeResPlanInfo_Method_Call_Internally(Type[] types)
        {
            var methodstoreResPlanInfoPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timerFixInstance, MethodstoreResPlanInfo, Fixture, methodstoreResPlanInfoPrametersTypes);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TimerFix_execute_Method_Call_Internally(Type[] types)
        {
            var methodexecutePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timerFixInstance, Methodexecute, Fixture, methodexecutePrametersTypes);
        }

        #endregion

        #region Method Call : (getResUrl) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TimerFix_getResUrl_Method_Call_Internally(Type[] types)
        {
            var methodgetResUrlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timerFixInstance, MethodgetResUrl, Fixture, methodgetResUrlPrametersTypes);
        }

        #endregion

        #region Method Call : (processResPlan) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TimerFix_processResPlan_Method_Call_Internally(Type[] types)
        {
            var methodprocessResPlanPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timerFixInstance, MethodprocessResPlan, Fixture, methodprocessResPlanPrametersTypes);
        }

        #endregion

        #region Method Call : (processWeb) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TimerFix_processWeb_Method_Call_Internally(Type[] types)
        {
            var methodprocessWebPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timerFixInstance, MethodprocessWeb, Fixture, methodprocessWebPrametersTypes);
        }

        #endregion

        #region Method Call : (getListItemCount) (Return Type : double) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TimerFix_getListItemCount_Method_Call_Internally(Type[] types)
        {
            var methodgetListItemCountPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timerFixInstance, MethodgetListItemCount, Fixture, methodgetListItemCountPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}
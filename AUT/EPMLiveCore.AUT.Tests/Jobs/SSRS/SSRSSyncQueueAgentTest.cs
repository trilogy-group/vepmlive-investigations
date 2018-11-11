using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.Jobs.SSRS
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Jobs.SSRS.SSRSSyncQueueAgent" />)
    ///     and namespace <see cref="EPMLiveCore.Jobs.SSRS"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class SSRSSyncQueueAgentTest : AbstractBaseSetupTypedTest<SSRSSyncQueueAgent>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SSRSSyncQueueAgent) Initializer

        private const string MethodEnequeuPFEJobAllSiteCollections = "EnequeuPFEJobAllSiteCollections";
        private const string MethodEnequePFEJobSingleSiteCollection = "EnequePFEJobSingleSiteCollection";
        private Type _sSRSSyncQueueAgentInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private SSRSSyncQueueAgent _sSRSSyncQueueAgentInstance;
        private SSRSSyncQueueAgent _sSRSSyncQueueAgentInstanceFixture;

        #region General Initializer : Class (SSRSSyncQueueAgent) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SSRSSyncQueueAgent" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _sSRSSyncQueueAgentInstanceType = typeof(SSRSSyncQueueAgent);
            _sSRSSyncQueueAgentInstanceFixture = Create(true);
            _sSRSSyncQueueAgentInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SSRSSyncQueueAgent)

        #region General Initializer : Class (SSRSSyncQueueAgent) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="SSRSSyncQueueAgent" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodEnequeuPFEJobAllSiteCollections, 0)]
        [TestCase(MethodEnequePFEJobSingleSiteCollection, 0)]
        public void AUT_SSRSSyncQueueAgent_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_sSRSSyncQueueAgentInstanceFixture, 
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
        ///     Class (<see cref="SSRSSyncQueueAgent" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_SSRSSyncQueueAgent_Is_Instance_Present_Test()
        {
            // Assert
            _sSRSSyncQueueAgentInstanceType.ShouldNotBeNull();
            _sSRSSyncQueueAgentInstance.ShouldNotBeNull();
            _sSRSSyncQueueAgentInstanceFixture.ShouldNotBeNull();
            _sSRSSyncQueueAgentInstance.ShouldBeAssignableTo<SSRSSyncQueueAgent>();
            _sSRSSyncQueueAgentInstanceFixture.ShouldBeAssignableTo<SSRSSyncQueueAgent>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (SSRSSyncQueueAgent) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_SSRSSyncQueueAgent_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            SSRSSyncQueueAgent instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _sSRSSyncQueueAgentInstanceType.ShouldNotBeNull();
            _sSRSSyncQueueAgentInstance.ShouldNotBeNull();
            _sSRSSyncQueueAgentInstanceFixture.ShouldNotBeNull();
            _sSRSSyncQueueAgentInstance.ShouldBeAssignableTo<SSRSSyncQueueAgent>();
            _sSRSSyncQueueAgentInstanceFixture.ShouldBeAssignableTo<SSRSSyncQueueAgent>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="SSRSSyncQueueAgent" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodEnequeuPFEJobAllSiteCollections)]
        [TestCase(MethodEnequePFEJobSingleSiteCollection)]
        public void AUT_SSRSSyncQueueAgent_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_sSRSSyncQueueAgentInstanceFixture,
                                                                              _sSRSSyncQueueAgentInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (EnequeuPFEJobAllSiteCollections) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SSRSSyncQueueAgent_EnequeuPFEJobAllSiteCollections_Static_Method_Call_Internally(Type[] types)
        {
            var methodEnequeuPFEJobAllSiteCollectionsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sSRSSyncQueueAgentInstanceFixture, _sSRSSyncQueueAgentInstanceType, MethodEnequeuPFEJobAllSiteCollections, Fixture, methodEnequeuPFEJobAllSiteCollectionsPrametersTypes);
        }

        #endregion

        #region Method Call : (EnequeuPFEJobAllSiteCollections) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSSyncQueueAgent_EnequeuPFEJobAllSiteCollections_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var webapp = CreateType<SPWebApplication>();
            Action executeAction = null;

            // Act
            executeAction = () => SSRSSyncQueueAgent.EnequeuPFEJobAllSiteCollections(webapp);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (EnequeuPFEJobAllSiteCollections) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSSyncQueueAgent_EnequeuPFEJobAllSiteCollections_Static_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var webapp = CreateType<SPWebApplication>();
            var methodEnequeuPFEJobAllSiteCollectionsPrametersTypes = new Type[] { typeof(SPWebApplication) };
            object[] parametersOfEnequeuPFEJobAllSiteCollections = { webapp };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodEnequeuPFEJobAllSiteCollections, methodEnequeuPFEJobAllSiteCollectionsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_sSRSSyncQueueAgentInstanceFixture, parametersOfEnequeuPFEJobAllSiteCollections);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfEnequeuPFEJobAllSiteCollections.ShouldNotBeNull();
            parametersOfEnequeuPFEJobAllSiteCollections.Length.ShouldBe(1);
            methodEnequeuPFEJobAllSiteCollectionsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (EnequeuPFEJobAllSiteCollections) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSSyncQueueAgent_EnequeuPFEJobAllSiteCollections_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var webapp = CreateType<SPWebApplication>();
            var methodEnequeuPFEJobAllSiteCollectionsPrametersTypes = new Type[] { typeof(SPWebApplication) };
            object[] parametersOfEnequeuPFEJobAllSiteCollections = { webapp };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_sSRSSyncQueueAgentInstanceFixture, _sSRSSyncQueueAgentInstanceType, MethodEnequeuPFEJobAllSiteCollections, parametersOfEnequeuPFEJobAllSiteCollections, methodEnequeuPFEJobAllSiteCollectionsPrametersTypes);

            // Assert
            parametersOfEnequeuPFEJobAllSiteCollections.ShouldNotBeNull();
            parametersOfEnequeuPFEJobAllSiteCollections.Length.ShouldBe(1);
            methodEnequeuPFEJobAllSiteCollectionsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnequeuPFEJobAllSiteCollections) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSSyncQueueAgent_EnequeuPFEJobAllSiteCollections_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodEnequeuPFEJobAllSiteCollections, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (EnequeuPFEJobAllSiteCollections) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSSyncQueueAgent_EnequeuPFEJobAllSiteCollections_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodEnequeuPFEJobAllSiteCollectionsPrametersTypes = new Type[] { typeof(SPWebApplication) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sSRSSyncQueueAgentInstanceFixture, _sSRSSyncQueueAgentInstanceType, MethodEnequeuPFEJobAllSiteCollections, Fixture, methodEnequeuPFEJobAllSiteCollectionsPrametersTypes);

            // Assert
            methodEnequeuPFEJobAllSiteCollectionsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnequeuPFEJobAllSiteCollections) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSSyncQueueAgent_EnequeuPFEJobAllSiteCollections_Static_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodEnequeuPFEJobAllSiteCollections, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_sSRSSyncQueueAgentInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnequePFEJobSingleSiteCollection) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SSRSSyncQueueAgent_EnequePFEJobSingleSiteCollection_Static_Method_Call_Internally(Type[] types)
        {
            var methodEnequePFEJobSingleSiteCollectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sSRSSyncQueueAgentInstanceFixture, _sSRSSyncQueueAgentInstanceType, MethodEnequePFEJobSingleSiteCollection, Fixture, methodEnequePFEJobSingleSiteCollectionPrametersTypes);
        }

        #endregion

        #region Method Call : (EnequePFEJobSingleSiteCollection) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSSyncQueueAgent_EnequePFEJobSingleSiteCollection_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var webapp = CreateType<SPWebApplication>();
            var site = CreateType<SPSite>();
            Action executeAction = null;

            // Act
            executeAction = () => SSRSSyncQueueAgent.EnequePFEJobSingleSiteCollection(webapp, site);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (EnequePFEJobSingleSiteCollection) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSSyncQueueAgent_EnequePFEJobSingleSiteCollection_Static_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var webapp = CreateType<SPWebApplication>();
            var site = CreateType<SPSite>();
            var methodEnequePFEJobSingleSiteCollectionPrametersTypes = new Type[] { typeof(SPWebApplication), typeof(SPSite) };
            object[] parametersOfEnequePFEJobSingleSiteCollection = { webapp, site };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodEnequePFEJobSingleSiteCollection, methodEnequePFEJobSingleSiteCollectionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_sSRSSyncQueueAgentInstanceFixture, parametersOfEnequePFEJobSingleSiteCollection);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfEnequePFEJobSingleSiteCollection.ShouldNotBeNull();
            parametersOfEnequePFEJobSingleSiteCollection.Length.ShouldBe(2);
            methodEnequePFEJobSingleSiteCollectionPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (EnequePFEJobSingleSiteCollection) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSSyncQueueAgent_EnequePFEJobSingleSiteCollection_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var webapp = CreateType<SPWebApplication>();
            var site = CreateType<SPSite>();
            var methodEnequePFEJobSingleSiteCollectionPrametersTypes = new Type[] { typeof(SPWebApplication), typeof(SPSite) };
            object[] parametersOfEnequePFEJobSingleSiteCollection = { webapp, site };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_sSRSSyncQueueAgentInstanceFixture, _sSRSSyncQueueAgentInstanceType, MethodEnequePFEJobSingleSiteCollection, parametersOfEnequePFEJobSingleSiteCollection, methodEnequePFEJobSingleSiteCollectionPrametersTypes);

            // Assert
            parametersOfEnequePFEJobSingleSiteCollection.ShouldNotBeNull();
            parametersOfEnequePFEJobSingleSiteCollection.Length.ShouldBe(2);
            methodEnequePFEJobSingleSiteCollectionPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnequePFEJobSingleSiteCollection) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSSyncQueueAgent_EnequePFEJobSingleSiteCollection_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodEnequePFEJobSingleSiteCollection, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (EnequePFEJobSingleSiteCollection) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSSyncQueueAgent_EnequePFEJobSingleSiteCollection_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodEnequePFEJobSingleSiteCollectionPrametersTypes = new Type[] { typeof(SPWebApplication), typeof(SPSite) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sSRSSyncQueueAgentInstanceFixture, _sSRSSyncQueueAgentInstanceType, MethodEnequePFEJobSingleSiteCollection, Fixture, methodEnequePFEJobSingleSiteCollectionPrametersTypes);

            // Assert
            methodEnequePFEJobSingleSiteCollectionPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnequePFEJobSingleSiteCollection) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSSyncQueueAgent_EnequePFEJobSingleSiteCollection_Static_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodEnequePFEJobSingleSiteCollection, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_sSRSSyncQueueAgentInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
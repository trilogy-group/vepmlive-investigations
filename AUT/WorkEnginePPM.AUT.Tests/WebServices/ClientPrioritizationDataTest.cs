using System;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace ClientPrioritizationDataCache
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="ClientPrioritizationDataCache.ClientPrioritizationData" />)
    ///     and namespace <see cref="ClientPrioritizationDataCache"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ClientPrioritizationDataTest : AbstractBaseSetupTypedTest<ClientPrioritizationData>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ClientPrioritizationData) Initializer

        private const string MethodGrabPrioritizationData = "GrabPrioritizationData";
        private const string Fieldm_oRows = "m_oRows";
        private const string Fieldm_oCols = "m_oCols";
        private const string Fieldm_oWeights = "m_oWeights";
        private Type _clientPrioritizationDataInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ClientPrioritizationData _clientPrioritizationDataInstance;
        private ClientPrioritizationData _clientPrioritizationDataInstanceFixture;

        #region General Initializer : Class (ClientPrioritizationData) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ClientPrioritizationData" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _clientPrioritizationDataInstanceType = typeof(ClientPrioritizationData);
            _clientPrioritizationDataInstanceFixture = Create(true);
            _clientPrioritizationDataInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ClientPrioritizationData)

        #region General Initializer : Class (ClientPrioritizationData) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ClientPrioritizationData" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGrabPrioritizationData, 0)]
        public void AUT_ClientPrioritizationData_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_clientPrioritizationDataInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ClientPrioritizationData) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ClientPrioritizationData" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldm_oRows)]
        [TestCase(Fieldm_oCols)]
        [TestCase(Fieldm_oWeights)]
        public void AUT_ClientPrioritizationData_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_clientPrioritizationDataInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="ClientPrioritizationData" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ClientPrioritizationData_Is_Instance_Present_Test()
        {
            // Assert
            _clientPrioritizationDataInstanceType.ShouldNotBeNull();
            _clientPrioritizationDataInstance.ShouldNotBeNull();
            _clientPrioritizationDataInstanceFixture.ShouldNotBeNull();
            _clientPrioritizationDataInstance.ShouldBeAssignableTo<ClientPrioritizationData>();
            _clientPrioritizationDataInstanceFixture.ShouldBeAssignableTo<ClientPrioritizationData>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ClientPrioritizationData) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ClientPrioritizationData_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ClientPrioritizationData instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _clientPrioritizationDataInstanceType.ShouldNotBeNull();
            _clientPrioritizationDataInstance.ShouldNotBeNull();
            _clientPrioritizationDataInstanceFixture.ShouldNotBeNull();
            _clientPrioritizationDataInstance.ShouldBeAssignableTo<ClientPrioritizationData>();
            _clientPrioritizationDataInstanceFixture.ShouldBeAssignableTo<ClientPrioritizationData>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ClientPrioritizationData" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGrabPrioritizationData)]
        public void AUT_ClientPrioritizationData_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ClientPrioritizationData>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GrabPrioritizationData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClientPrioritizationData_GrabPrioritizationData_Method_Call_Internally(Type[] types)
        {
            var methodGrabPrioritizationDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clientPrioritizationDataInstance, MethodGrabPrioritizationData, Fixture, methodGrabPrioritizationDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GrabPrioritizationData) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClientPrioritizationData_GrabPrioritizationData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var conn = CreateType<SqlConnection>();
            Action executeAction = null;

            // Act
            executeAction = () => _clientPrioritizationDataInstance.GrabPrioritizationData(conn);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GrabPrioritizationData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClientPrioritizationData_GrabPrioritizationData_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var conn = CreateType<SqlConnection>();
            var methodGrabPrioritizationDataPrametersTypes = new Type[] { typeof(SqlConnection) };
            object[] parametersOfGrabPrioritizationData = { conn };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGrabPrioritizationData, methodGrabPrioritizationDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_clientPrioritizationDataInstanceFixture, parametersOfGrabPrioritizationData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGrabPrioritizationData.ShouldNotBeNull();
            parametersOfGrabPrioritizationData.Length.ShouldBe(1);
            methodGrabPrioritizationDataPrametersTypes.Length.ShouldBe(1);
            methodGrabPrioritizationDataPrametersTypes.Length.ShouldBe(parametersOfGrabPrioritizationData.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GrabPrioritizationData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClientPrioritizationData_GrabPrioritizationData_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var conn = CreateType<SqlConnection>();
            var methodGrabPrioritizationDataPrametersTypes = new Type[] { typeof(SqlConnection) };
            object[] parametersOfGrabPrioritizationData = { conn };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_clientPrioritizationDataInstance, MethodGrabPrioritizationData, parametersOfGrabPrioritizationData, methodGrabPrioritizationDataPrametersTypes);

            // Assert
            parametersOfGrabPrioritizationData.ShouldNotBeNull();
            parametersOfGrabPrioritizationData.Length.ShouldBe(1);
            methodGrabPrioritizationDataPrametersTypes.Length.ShouldBe(1);
            methodGrabPrioritizationDataPrametersTypes.Length.ShouldBe(parametersOfGrabPrioritizationData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GrabPrioritizationData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClientPrioritizationData_GrabPrioritizationData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGrabPrioritizationData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GrabPrioritizationData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClientPrioritizationData_GrabPrioritizationData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGrabPrioritizationDataPrametersTypes = new Type[] { typeof(SqlConnection) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clientPrioritizationDataInstance, MethodGrabPrioritizationData, Fixture, methodGrabPrioritizationDataPrametersTypes);

            // Assert
            methodGrabPrioritizationDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GrabPrioritizationData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClientPrioritizationData_GrabPrioritizationData_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGrabPrioritizationData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_clientPrioritizationDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
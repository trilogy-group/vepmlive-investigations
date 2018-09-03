using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace PortfolioEngineCore.Analyzers
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PortfolioEngineCore.Analyzers.BaseAnalyzer" />)
    ///     and namespace <see cref="PortfolioEngineCore.Analyzers"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class BaseAnalyzerTest : AbstractBaseSetupTypedTest<BaseAnalyzer>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (BaseAnalyzer) Initializer

        private const string MethodGenerateDataTicket = "GenerateDataTicket";
        private Type _baseAnalyzerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private BaseAnalyzer _baseAnalyzerInstance;
        private BaseAnalyzer _baseAnalyzerInstanceFixture;

        #region General Initializer : Class (BaseAnalyzer) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="BaseAnalyzer" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _baseAnalyzerInstanceType = typeof(BaseAnalyzer);
            _baseAnalyzerInstanceFixture = Create(true);
            _baseAnalyzerInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (BaseAnalyzer)

        #region General Initializer : Class (BaseAnalyzer) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="BaseAnalyzer" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGenerateDataTicket, 0)]
        public void AUT_BaseAnalyzer_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_baseAnalyzerInstanceFixture, 
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
        ///      Class (<see cref="BaseAnalyzer" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGenerateDataTicket)]
        public void AUT_BaseAnalyzer_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<BaseAnalyzer>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GenerateDataTicket) (Return Type : Guid) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_BaseAnalyzer_GenerateDataTicket_Method_Call_Internally(Type[] types)
        {
            var methodGenerateDataTicketPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_baseAnalyzerInstance, MethodGenerateDataTicket, Fixture, methodGenerateDataTicketPrametersTypes);
        }

        #endregion

        #region Method Call : (GenerateDataTicket) (Return Type : Guid) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BaseAnalyzer_GenerateDataTicket_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _baseAnalyzerInstance.GenerateDataTicket(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GenerateDataTicket) (Return Type : Guid) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BaseAnalyzer_GenerateDataTicket_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGenerateDataTicketPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGenerateDataTicket = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGenerateDataTicket, methodGenerateDataTicketPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<BaseAnalyzer, Guid>(_baseAnalyzerInstanceFixture, out exception1, parametersOfGenerateDataTicket);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<BaseAnalyzer, Guid>(_baseAnalyzerInstance, MethodGenerateDataTicket, parametersOfGenerateDataTicket, methodGenerateDataTicketPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGenerateDataTicket.ShouldNotBeNull();
            parametersOfGenerateDataTicket.Length.ShouldBe(1);
            methodGenerateDataTicketPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GenerateDataTicket) (Return Type : Guid) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BaseAnalyzer_GenerateDataTicket_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGenerateDataTicketPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGenerateDataTicket = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<BaseAnalyzer, Guid>(_baseAnalyzerInstance, MethodGenerateDataTicket, parametersOfGenerateDataTicket, methodGenerateDataTicketPrametersTypes);

            // Assert
            parametersOfGenerateDataTicket.ShouldNotBeNull();
            parametersOfGenerateDataTicket.Length.ShouldBe(1);
            methodGenerateDataTicketPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GenerateDataTicket) (Return Type : Guid) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BaseAnalyzer_GenerateDataTicket_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGenerateDataTicketPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_baseAnalyzerInstance, MethodGenerateDataTicket, Fixture, methodGenerateDataTicketPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGenerateDataTicketPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GenerateDataTicket) (Return Type : Guid) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BaseAnalyzer_GenerateDataTicket_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGenerateDataTicketPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_baseAnalyzerInstance, MethodGenerateDataTicket, Fixture, methodGenerateDataTicketPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGenerateDataTicketPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GenerateDataTicket) (Return Type : Guid) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BaseAnalyzer_GenerateDataTicket_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGenerateDataTicket, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_baseAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GenerateDataTicket) (Return Type : Guid) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BaseAnalyzer_GenerateDataTicket_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGenerateDataTicket, 0);
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
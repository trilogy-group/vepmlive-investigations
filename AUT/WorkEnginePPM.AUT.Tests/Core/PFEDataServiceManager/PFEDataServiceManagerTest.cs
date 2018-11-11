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

namespace WorkEnginePPM.Core.PFEDataServiceManager
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.Core.PFEDataServiceManager.PFEDataServiceManager" />)
    ///     and namespace <see cref="WorkEnginePPM.Core.PFEDataServiceManager"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class PFEDataServiceManagerTest : AbstractBaseSetupTypedTest<PFEDataServiceManager>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (PFEDataServiceManager) Initializer

        private const string MethodScheduleDataImport = "ScheduleDataImport";
        private const string MethodCollectDataImportResult = "CollectDataImportResult";
        private Type _pFEDataServiceManagerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private PFEDataServiceManager _pFEDataServiceManagerInstance;
        private PFEDataServiceManager _pFEDataServiceManagerInstanceFixture;

        #region General Initializer : Class (PFEDataServiceManager) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PFEDataServiceManager" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _pFEDataServiceManagerInstanceType = typeof(PFEDataServiceManager);
            _pFEDataServiceManagerInstanceFixture = Create(true);
            _pFEDataServiceManagerInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PFEDataServiceManager)

        #region General Initializer : Class (PFEDataServiceManager) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="PFEDataServiceManager" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodScheduleDataImport, 0)]
        [TestCase(MethodCollectDataImportResult, 0)]
        public void AUT_PFEDataServiceManager_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_pFEDataServiceManagerInstanceFixture, 
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
        ///      Class (<see cref="PFEDataServiceManager" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodScheduleDataImport)]
        [TestCase(MethodCollectDataImportResult)]
        public void AUT_PFEDataServiceManager_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<PFEDataServiceManager>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (ScheduleDataImport) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PFEDataServiceManager_ScheduleDataImport_Method_Call_Internally(Type[] types)
        {
            var methodScheduleDataImportPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pFEDataServiceManagerInstance, MethodScheduleDataImport, Fixture, methodScheduleDataImportPrametersTypes);
        }

        #endregion

        #region Method Call : (ScheduleDataImport) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEDataServiceManager_ScheduleDataImport_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _pFEDataServiceManagerInstance.ScheduleDataImport(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ScheduleDataImport) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEDataServiceManager_ScheduleDataImport_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodScheduleDataImportPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfScheduleDataImport = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodScheduleDataImport, methodScheduleDataImportPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PFEDataServiceManager, string>(_pFEDataServiceManagerInstanceFixture, out exception1, parametersOfScheduleDataImport);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PFEDataServiceManager, string>(_pFEDataServiceManagerInstance, MethodScheduleDataImport, parametersOfScheduleDataImport, methodScheduleDataImportPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfScheduleDataImport.ShouldNotBeNull();
            parametersOfScheduleDataImport.Length.ShouldBe(1);
            methodScheduleDataImportPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ScheduleDataImport) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEDataServiceManager_ScheduleDataImport_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodScheduleDataImportPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfScheduleDataImport = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<PFEDataServiceManager, string>(_pFEDataServiceManagerInstance, MethodScheduleDataImport, parametersOfScheduleDataImport, methodScheduleDataImportPrametersTypes);

            // Assert
            parametersOfScheduleDataImport.ShouldNotBeNull();
            parametersOfScheduleDataImport.Length.ShouldBe(1);
            methodScheduleDataImportPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ScheduleDataImport) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEDataServiceManager_ScheduleDataImport_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodScheduleDataImportPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pFEDataServiceManagerInstance, MethodScheduleDataImport, Fixture, methodScheduleDataImportPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodScheduleDataImportPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ScheduleDataImport) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEDataServiceManager_ScheduleDataImport_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodScheduleDataImportPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pFEDataServiceManagerInstance, MethodScheduleDataImport, Fixture, methodScheduleDataImportPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodScheduleDataImportPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ScheduleDataImport) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEDataServiceManager_ScheduleDataImport_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodScheduleDataImport, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_pFEDataServiceManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ScheduleDataImport) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEDataServiceManager_ScheduleDataImport_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodScheduleDataImport, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CollectDataImportResult) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PFEDataServiceManager_CollectDataImportResult_Method_Call_Internally(Type[] types)
        {
            var methodCollectDataImportResultPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pFEDataServiceManagerInstance, MethodCollectDataImportResult, Fixture, methodCollectDataImportResultPrametersTypes);
        }

        #endregion

        #region Method Call : (CollectDataImportResult) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEDataServiceManager_CollectDataImportResult_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _pFEDataServiceManagerInstance.CollectDataImportResult(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CollectDataImportResult) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEDataServiceManager_CollectDataImportResult_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodCollectDataImportResultPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfCollectDataImportResult = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCollectDataImportResult, methodCollectDataImportResultPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PFEDataServiceManager, string>(_pFEDataServiceManagerInstanceFixture, out exception1, parametersOfCollectDataImportResult);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PFEDataServiceManager, string>(_pFEDataServiceManagerInstance, MethodCollectDataImportResult, parametersOfCollectDataImportResult, methodCollectDataImportResultPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfCollectDataImportResult.ShouldNotBeNull();
            parametersOfCollectDataImportResult.Length.ShouldBe(1);
            methodCollectDataImportResultPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (CollectDataImportResult) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEDataServiceManager_CollectDataImportResult_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodCollectDataImportResultPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfCollectDataImportResult = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<PFEDataServiceManager, string>(_pFEDataServiceManagerInstance, MethodCollectDataImportResult, parametersOfCollectDataImportResult, methodCollectDataImportResultPrametersTypes);

            // Assert
            parametersOfCollectDataImportResult.ShouldNotBeNull();
            parametersOfCollectDataImportResult.Length.ShouldBe(1);
            methodCollectDataImportResultPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CollectDataImportResult) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEDataServiceManager_CollectDataImportResult_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCollectDataImportResultPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pFEDataServiceManagerInstance, MethodCollectDataImportResult, Fixture, methodCollectDataImportResultPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCollectDataImportResultPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (CollectDataImportResult) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEDataServiceManager_CollectDataImportResult_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCollectDataImportResultPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pFEDataServiceManagerInstance, MethodCollectDataImportResult, Fixture, methodCollectDataImportResultPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCollectDataImportResultPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CollectDataImportResult) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEDataServiceManager_CollectDataImportResult_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCollectDataImportResult, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_pFEDataServiceManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CollectDataImportResult) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEDataServiceManager_CollectDataImportResult_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCollectDataImportResult, 0);
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
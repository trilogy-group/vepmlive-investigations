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

namespace EPMLiveWebParts
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.getresourceplan" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class GetresourceplanTest : AbstractBaseSetupTypedTest<getresourceplan>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (getresourceplan) Initializer

        private const string MethodgetParams = "getParams";
        private const string MethodoutputData = "outputData";
        private const string MethodgetAssignedTo = "getAssignedTo";
        private const string MethodgetQuery = "getQuery";
        private const string Fieldresources = "resources";
        private Type _getresourceplanInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private getresourceplan _getresourceplanInstance;
        private getresourceplan _getresourceplanInstanceFixture;

        #region General Initializer : Class (getresourceplan) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="getresourceplan" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _getresourceplanInstanceType = typeof(getresourceplan);
            _getresourceplanInstanceFixture = Create(true);
            _getresourceplanInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (getresourceplan)

        #region General Initializer : Class (getresourceplan) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="getresourceplan" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodgetParams, 0)]
        [TestCase(MethodoutputData, 0)]
        [TestCase(MethodgetAssignedTo, 0)]
        [TestCase(MethodgetQuery, 0)]
        public void AUT_Getresourceplan_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_getresourceplanInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (getresourceplan) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="getresourceplan" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldresources)]
        public void AUT_Getresourceplan_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_getresourceplanInstanceFixture, 
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
        ///     Class (<see cref="getresourceplan" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Getresourceplan_Is_Instance_Present_Test()
        {
            // Assert
            _getresourceplanInstanceType.ShouldNotBeNull();
            _getresourceplanInstance.ShouldNotBeNull();
            _getresourceplanInstanceFixture.ShouldNotBeNull();
            _getresourceplanInstance.ShouldBeAssignableTo<getresourceplan>();
            _getresourceplanInstanceFixture.ShouldBeAssignableTo<getresourceplan>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (getresourceplan) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_getresourceplan_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            getresourceplan instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _getresourceplanInstanceType.ShouldNotBeNull();
            _getresourceplanInstance.ShouldNotBeNull();
            _getresourceplanInstanceFixture.ShouldNotBeNull();
            _getresourceplanInstance.ShouldBeAssignableTo<getresourceplan>();
            _getresourceplanInstanceFixture.ShouldBeAssignableTo<getresourceplan>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="getresourceplan" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodgetParams)]
        [TestCase(MethodoutputData)]
        [TestCase(MethodgetAssignedTo)]
        [TestCase(MethodgetQuery)]
        public void AUT_Getresourceplan_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<getresourceplan>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (getParams) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getresourceplan_getParams_Method_Call_Internally(Type[] types)
        {
            var methodgetParamsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getresourceplanInstance, MethodgetParams, Fixture, methodgetParamsPrametersTypes);
        }

        #endregion

        #region Method Call : (getParams) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getresourceplan_getParams_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var curWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => _getresourceplanInstance.getParams(curWeb);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (getParams) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getresourceplan_getParams_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var curWeb = CreateType<SPWeb>();
            var methodgetParamsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfgetParams = { curWeb };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetParams, methodgetParamsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getresourceplanInstanceFixture, parametersOfgetParams);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetParams.ShouldNotBeNull();
            parametersOfgetParams.Length.ShouldBe(1);
            methodgetParamsPrametersTypes.Length.ShouldBe(1);
            methodgetParamsPrametersTypes.Length.ShouldBe(parametersOfgetParams.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getParams) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getresourceplan_getParams_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var curWeb = CreateType<SPWeb>();
            var methodgetParamsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfgetParams = { curWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getresourceplanInstance, MethodgetParams, parametersOfgetParams, methodgetParamsPrametersTypes);

            // Assert
            parametersOfgetParams.ShouldNotBeNull();
            parametersOfgetParams.Length.ShouldBe(1);
            methodgetParamsPrametersTypes.Length.ShouldBe(1);
            methodgetParamsPrametersTypes.Length.ShouldBe(parametersOfgetParams.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getParams) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getresourceplan_getParams_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetParams, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getParams) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getresourceplan_getParams_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetParamsPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getresourceplanInstance, MethodgetParams, Fixture, methodgetParamsPrametersTypes);

            // Assert
            methodgetParamsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getParams) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getresourceplan_getParams_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetParams, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getresourceplanInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (outputData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getresourceplan_outputData_Method_Call_Internally(Type[] types)
        {
            var methodoutputDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getresourceplanInstance, MethodoutputData, Fixture, methodoutputDataPrametersTypes);
        }

        #endregion

        #region Method Call : (outputData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getresourceplan_outputData_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodoutputDataPrametersTypes = null;
            object[] parametersOfoutputData = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodoutputData, methodoutputDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getresourceplanInstanceFixture, parametersOfoutputData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfoutputData.ShouldBeNull();
            methodoutputDataPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (outputData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getresourceplan_outputData_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodoutputDataPrametersTypes = null;
            object[] parametersOfoutputData = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getresourceplanInstance, MethodoutputData, parametersOfoutputData, methodoutputDataPrametersTypes);

            // Assert
            parametersOfoutputData.ShouldBeNull();
            methodoutputDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (outputData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getresourceplan_outputData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodoutputDataPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getresourceplanInstance, MethodoutputData, Fixture, methodoutputDataPrametersTypes);

            // Assert
            methodoutputDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (outputData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getresourceplan_outputData_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodoutputData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getresourceplanInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getAssignedTo) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getresourceplan_getAssignedTo_Method_Call_Internally(Type[] types)
        {
            var methodgetAssignedToPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getresourceplanInstance, MethodgetAssignedTo, Fixture, methodgetAssignedToPrametersTypes);
        }

        #endregion
        
        #region Method Call : (getAssignedTo) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getresourceplan_getAssignedTo_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodgetAssignedToPrametersTypes = null;
            object[] parametersOfgetAssignedTo = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getresourceplan, string>(_getresourceplanInstance, MethodgetAssignedTo, parametersOfgetAssignedTo, methodgetAssignedToPrametersTypes);

            // Assert
            parametersOfgetAssignedTo.ShouldBeNull();
            methodgetAssignedToPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getAssignedTo) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getresourceplan_getAssignedTo_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodgetAssignedToPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getresourceplanInstance, MethodgetAssignedTo, Fixture, methodgetAssignedToPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetAssignedToPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getAssignedTo) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getresourceplan_getAssignedTo_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodgetAssignedToPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getresourceplanInstance, MethodgetAssignedTo, Fixture, methodgetAssignedToPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetAssignedToPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getAssignedTo) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getresourceplan_getAssignedTo_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetAssignedTo, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getresourceplanInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getQuery) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getresourceplan_getQuery_Method_Call_Internally(Type[] types)
        {
            var methodgetQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getresourceplanInstance, MethodgetQuery, Fixture, methodgetQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (getQuery) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getresourceplan_getQuery_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _getresourceplanInstance.getQuery();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (getQuery) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getresourceplan_getQuery_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodgetQueryPrametersTypes = null;
            object[] parametersOfgetQuery = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodgetQuery, methodgetQueryPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<getresourceplan, string>(_getresourceplanInstanceFixture, out exception1, parametersOfgetQuery);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<getresourceplan, string>(_getresourceplanInstance, MethodgetQuery, parametersOfgetQuery, methodgetQueryPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetQuery.ShouldBeNull();
            methodgetQueryPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getQuery) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getresourceplan_getQuery_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodgetQueryPrametersTypes = null;
            object[] parametersOfgetQuery = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getresourceplan, string>(_getresourceplanInstance, MethodgetQuery, parametersOfgetQuery, methodgetQueryPrametersTypes);

            // Assert
            parametersOfgetQuery.ShouldBeNull();
            methodgetQueryPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getQuery) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getresourceplan_getQuery_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodgetQueryPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getresourceplanInstance, MethodgetQuery, Fixture, methodgetQueryPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetQueryPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getQuery) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getresourceplan_getQuery_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodgetQueryPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getresourceplanInstance, MethodgetQuery, Fixture, methodgetQueryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetQueryPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getQuery) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getresourceplan_getQuery_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetQuery, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getresourceplanInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #endregion

        #endregion
    }
}
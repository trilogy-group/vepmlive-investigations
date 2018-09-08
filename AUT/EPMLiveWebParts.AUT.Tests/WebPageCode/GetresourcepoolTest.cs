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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.getresourcepool" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class GetresourcepoolTest : AbstractBaseSetupTypedTest<getresourcepool>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (getresourcepool) Initializer

        private const string MethodoutputXml = "outputXml";
        private const string MethodgetParams = "getParams";
        private Type _getresourcepoolInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private getresourcepool _getresourcepoolInstance;
        private getresourcepool _getresourcepoolInstanceFixture;

        #region General Initializer : Class (getresourcepool) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="getresourcepool" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _getresourcepoolInstanceType = typeof(getresourcepool);
            _getresourcepoolInstanceFixture = Create(true);
            _getresourcepoolInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (getresourcepool)

        #region General Initializer : Class (getresourcepool) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="getresourcepool" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodoutputXml, 0)]
        [TestCase(MethodgetParams, 0)]
        public void AUT_Getresourcepool_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_getresourcepoolInstanceFixture, 
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
        ///     Class (<see cref="getresourcepool" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Getresourcepool_Is_Instance_Present_Test()
        {
            // Assert
            _getresourcepoolInstanceType.ShouldNotBeNull();
            _getresourcepoolInstance.ShouldNotBeNull();
            _getresourcepoolInstanceFixture.ShouldNotBeNull();
            _getresourcepoolInstance.ShouldBeAssignableTo<getresourcepool>();
            _getresourcepoolInstanceFixture.ShouldBeAssignableTo<getresourcepool>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (getresourcepool) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_getresourcepool_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            getresourcepool instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _getresourcepoolInstanceType.ShouldNotBeNull();
            _getresourcepoolInstance.ShouldNotBeNull();
            _getresourcepoolInstanceFixture.ShouldNotBeNull();
            _getresourcepoolInstance.ShouldBeAssignableTo<getresourcepool>();
            _getresourcepoolInstanceFixture.ShouldBeAssignableTo<getresourcepool>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="getresourcepool" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodoutputXml)]
        [TestCase(MethodgetParams)]
        public void AUT_Getresourcepool_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<getresourcepool>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (outputXml) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getresourcepool_outputXml_Method_Call_Internally(Type[] types)
        {
            var methodoutputXmlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getresourcepoolInstance, MethodoutputXml, Fixture, methodoutputXmlPrametersTypes);
        }

        #endregion

        #region Method Call : (outputXml) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getresourcepool_outputXml_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodoutputXmlPrametersTypes = null;
            object[] parametersOfoutputXml = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodoutputXml, methodoutputXmlPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getresourcepoolInstanceFixture, parametersOfoutputXml);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfoutputXml.ShouldBeNull();
            methodoutputXmlPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (outputXml) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getresourcepool_outputXml_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodoutputXmlPrametersTypes = null;
            object[] parametersOfoutputXml = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getresourcepoolInstance, MethodoutputXml, parametersOfoutputXml, methodoutputXmlPrametersTypes);

            // Assert
            parametersOfoutputXml.ShouldBeNull();
            methodoutputXmlPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (outputXml) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getresourcepool_outputXml_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodoutputXmlPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getresourcepoolInstance, MethodoutputXml, Fixture, methodoutputXmlPrametersTypes);

            // Assert
            methodoutputXmlPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (outputXml) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getresourcepool_outputXml_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodoutputXml, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getresourcepoolInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getParams) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getresourcepool_getParams_Method_Call_Internally(Type[] types)
        {
            var methodgetParamsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getresourcepoolInstance, MethodgetParams, Fixture, methodgetParamsPrametersTypes);
        }

        #endregion

        #region Method Call : (getParams) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getresourcepool_getParams_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var curWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => _getresourcepoolInstance.getParams(curWeb);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (getParams) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getresourcepool_getParams_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var curWeb = CreateType<SPWeb>();
            var methodgetParamsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfgetParams = { curWeb };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetParams, methodgetParamsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getresourcepoolInstanceFixture, parametersOfgetParams);

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
        public void AUT_Getresourcepool_getParams_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var curWeb = CreateType<SPWeb>();
            var methodgetParamsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfgetParams = { curWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getresourcepoolInstance, MethodgetParams, parametersOfgetParams, methodgetParamsPrametersTypes);

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
        public void AUT_Getresourcepool_getParams_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Getresourcepool_getParams_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetParamsPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getresourcepoolInstance, MethodgetParams, Fixture, methodgetParamsPrametersTypes);

            // Assert
            methodgetParamsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getParams) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getresourcepool_getParams_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetParams, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getresourcepoolInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
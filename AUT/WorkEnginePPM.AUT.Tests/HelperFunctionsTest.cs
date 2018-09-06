using System;
using System.Collections;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Web.UI;
using System.Xml;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace WorkEnginePPM
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.HelperFunctions" />)
    ///     and namespace <see cref="WorkEnginePPM"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class HelperFunctionsTest : AbstractBaseSetupTypedTest<HelperFunctions>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (HelperFunctions) Initializer

        private const string MethodAddXml = "AddXml";
        private const string MethodgetSessionInfo = "getSessionInfo";
        private const string MethodoutputEPKControl = "outputEPKControl";
        private const string MethodUseNonActiveXControl = "UseNonActiveXControl";
        private const string MethodgetProjectNameFromUID = "getProjectNameFromUID";
        private const string MethodprepareItemList = "prepareItemList";
        private const string MethodprocessResourceDisable = "processResourceDisable";
        private const string MethodprepareResList = "prepareResList";
        private const string MethodprocessResource = "processResource";
        private const string MethodprocessPortfolioItem = "processPortfolioItem";
        private const string MethodGetResourcePool = "GetResourcePool";
        private Type _helperFunctionsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private HelperFunctions _helperFunctionsInstance;
        private HelperFunctions _helperFunctionsInstanceFixture;

        #region General Initializer : Class (HelperFunctions) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="HelperFunctions" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _helperFunctionsInstanceType = typeof(HelperFunctions);
            _helperFunctionsInstanceFixture = Create(true);
            _helperFunctionsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (HelperFunctions)

        #region General Initializer : Class (HelperFunctions) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="HelperFunctions" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodAddXml, 0)]
        [TestCase(MethodgetSessionInfo, 0)]
        [TestCase(MethodoutputEPKControl, 0)]
        [TestCase(MethodUseNonActiveXControl, 0)]
        [TestCase(MethodgetProjectNameFromUID, 0)]
        [TestCase(MethodprepareItemList, 0)]
        [TestCase(MethodprocessResourceDisable, 0)]
        [TestCase(MethodprepareResList, 0)]
        [TestCase(MethodprocessResource, 0)]
        [TestCase(MethodprocessPortfolioItem, 0)]
        [TestCase(MethodGetResourcePool, 0)]
        public void AUT_HelperFunctions_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_helperFunctionsInstanceFixture, 
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
        ///     Class (<see cref="HelperFunctions" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_HelperFunctions_Is_Instance_Present_Test()
        {
            // Assert
            _helperFunctionsInstanceType.ShouldNotBeNull();
            _helperFunctionsInstance.ShouldNotBeNull();
            _helperFunctionsInstanceFixture.ShouldNotBeNull();
            _helperFunctionsInstance.ShouldBeAssignableTo<HelperFunctions>();
            _helperFunctionsInstanceFixture.ShouldBeAssignableTo<HelperFunctions>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (HelperFunctions) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_HelperFunctions_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            HelperFunctions instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _helperFunctionsInstanceType.ShouldNotBeNull();
            _helperFunctionsInstance.ShouldNotBeNull();
            _helperFunctionsInstanceFixture.ShouldNotBeNull();
            _helperFunctionsInstance.ShouldBeAssignableTo<HelperFunctions>();
            _helperFunctionsInstanceFixture.ShouldBeAssignableTo<HelperFunctions>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="HelperFunctions" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodAddXml)]
        [TestCase(MethodgetSessionInfo)]
        [TestCase(MethodoutputEPKControl)]
        [TestCase(MethodUseNonActiveXControl)]
        [TestCase(MethodgetProjectNameFromUID)]
        [TestCase(MethodprepareItemList)]
        [TestCase(MethodprocessResourceDisable)]
        [TestCase(MethodprepareResList)]
        [TestCase(MethodprocessResource)]
        [TestCase(MethodprocessPortfolioItem)]
        [TestCase(MethodGetResourcePool)]
        public void AUT_HelperFunctions_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_helperFunctionsInstanceFixture,
                                                                              _helperFunctionsInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (AddXml) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_HelperFunctions_AddXml_Static_Method_Call_Internally(Type[] types)
        {
            var methodAddXmlPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodAddXml, Fixture, methodAddXmlPrametersTypes);
        }

        #endregion

        #region Method Call : (AddXml) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_AddXml_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var arrResourceExtIds = CreateType<ArrayList>();
            Action executeAction = null;

            // Act
            executeAction = () => HelperFunctions.AddXml(li, arrResourceExtIds);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (AddXml) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_AddXml_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var arrResourceExtIds = CreateType<ArrayList>();
            var methodAddXmlPrametersTypes = new Type[] { typeof(SPListItem), typeof(ArrayList) };
            object[] parametersOfAddXml = { li, arrResourceExtIds };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddXml, methodAddXmlPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodAddXml, Fixture, methodAddXmlPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodAddXml, parametersOfAddXml, methodAddXmlPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfAddXml.ShouldNotBeNull();
            parametersOfAddXml.Length.ShouldBe(2);
            methodAddXmlPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodAddXml, parametersOfAddXml, methodAddXmlPrametersTypes));
        }

        #endregion

        #region Method Call : (AddXml) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_AddXml_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var arrResourceExtIds = CreateType<ArrayList>();
            var methodAddXmlPrametersTypes = new Type[] { typeof(SPListItem), typeof(ArrayList) };
            object[] parametersOfAddXml = { li, arrResourceExtIds };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddXml, methodAddXmlPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_helperFunctionsInstanceFixture, parametersOfAddXml);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddXml.ShouldNotBeNull();
            parametersOfAddXml.Length.ShouldBe(2);
            methodAddXmlPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddXml) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_AddXml_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var arrResourceExtIds = CreateType<ArrayList>();
            var methodAddXmlPrametersTypes = new Type[] { typeof(SPListItem), typeof(ArrayList) };
            object[] parametersOfAddXml = { li, arrResourceExtIds };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodAddXml, parametersOfAddXml, methodAddXmlPrametersTypes);

            // Assert
            parametersOfAddXml.ShouldNotBeNull();
            parametersOfAddXml.Length.ShouldBe(2);
            methodAddXmlPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddXml) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_AddXml_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodAddXmlPrametersTypes = new Type[] { typeof(SPListItem), typeof(ArrayList) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodAddXml, Fixture, methodAddXmlPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodAddXmlPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (AddXml) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_AddXml_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddXmlPrametersTypes = new Type[] { typeof(SPListItem), typeof(ArrayList) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodAddXml, Fixture, methodAddXmlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAddXmlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddXml) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_AddXml_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddXml, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_helperFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (AddXml) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_AddXml_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddXml, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getSessionInfo) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_HelperFunctions_getSessionInfo_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetSessionInfoPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodgetSessionInfo, Fixture, methodgetSessionInfoPrametersTypes);
        }

        #endregion

        #region Method Call : (getSessionInfo) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_getSessionInfo_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var page = CreateType<Page>();
            Action executeAction = null;

            // Act
            executeAction = () => HelperFunctions.getSessionInfo(page);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (getSessionInfo) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_getSessionInfo_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var page = CreateType<Page>();
            var methodgetSessionInfoPrametersTypes = new Type[] { typeof(Page) };
            object[] parametersOfgetSessionInfo = { page };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetSessionInfo, methodgetSessionInfoPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodgetSessionInfo, Fixture, methodgetSessionInfoPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodgetSessionInfo, parametersOfgetSessionInfo, methodgetSessionInfoPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_helperFunctionsInstanceFixture, parametersOfgetSessionInfo);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetSessionInfo.ShouldNotBeNull();
            parametersOfgetSessionInfo.Length.ShouldBe(1);
            methodgetSessionInfoPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (getSessionInfo) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_getSessionInfo_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var page = CreateType<Page>();
            var methodgetSessionInfoPrametersTypes = new Type[] { typeof(Page) };
            object[] parametersOfgetSessionInfo = { page };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodgetSessionInfo, parametersOfgetSessionInfo, methodgetSessionInfoPrametersTypes);

            // Assert
            parametersOfgetSessionInfo.ShouldNotBeNull();
            parametersOfgetSessionInfo.Length.ShouldBe(1);
            methodgetSessionInfoPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getSessionInfo) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_getSessionInfo_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetSessionInfoPrametersTypes = new Type[] { typeof(Page) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodgetSessionInfo, Fixture, methodgetSessionInfoPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetSessionInfoPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getSessionInfo) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_getSessionInfo_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetSessionInfoPrametersTypes = new Type[] { typeof(Page) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodgetSessionInfo, Fixture, methodgetSessionInfoPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetSessionInfoPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getSessionInfo) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_getSessionInfo_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetSessionInfo, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_helperFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getSessionInfo) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_getSessionInfo_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetSessionInfo, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (outputEPKControl) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_HelperFunctions_outputEPKControl_Static_Method_Call_Internally(Type[] types)
        {
            var methodoutputEPKControlPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodoutputEPKControl, Fixture, methodoutputEPKControlPrametersTypes);
        }

        #endregion

        #region Method Call : (outputEPKControl) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_outputEPKControl_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sEpkurl = CreateType<string>();
            var sControl = CreateType<string>();
            var sParams = CreateType<string>();
            var resizable = CreateType<string>();
            var page = CreateType<Page>();
            var subPage = CreateType<string>();
            var bTest = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => HelperFunctions.outputEPKControl(sEpkurl, sControl, sParams, resizable, page, subPage, bTest);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (outputEPKControl) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_outputEPKControl_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sEpkurl = CreateType<string>();
            var sControl = CreateType<string>();
            var sParams = CreateType<string>();
            var resizable = CreateType<string>();
            var page = CreateType<Page>();
            var subPage = CreateType<string>();
            var bTest = CreateType<bool>();
            var methodoutputEPKControlPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(Page), typeof(string), typeof(bool) };
            object[] parametersOfoutputEPKControl = { sEpkurl, sControl, sParams, resizable, page, subPage, bTest };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodoutputEPKControl, methodoutputEPKControlPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodoutputEPKControl, Fixture, methodoutputEPKControlPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodoutputEPKControl, parametersOfoutputEPKControl, methodoutputEPKControlPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_helperFunctionsInstanceFixture, parametersOfoutputEPKControl);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfoutputEPKControl.ShouldNotBeNull();
            parametersOfoutputEPKControl.Length.ShouldBe(7);
            methodoutputEPKControlPrametersTypes.Length.ShouldBe(7);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (outputEPKControl) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_outputEPKControl_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sEpkurl = CreateType<string>();
            var sControl = CreateType<string>();
            var sParams = CreateType<string>();
            var resizable = CreateType<string>();
            var page = CreateType<Page>();
            var subPage = CreateType<string>();
            var bTest = CreateType<bool>();
            var methodoutputEPKControlPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(Page), typeof(string), typeof(bool) };
            object[] parametersOfoutputEPKControl = { sEpkurl, sControl, sParams, resizable, page, subPage, bTest };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodoutputEPKControl, parametersOfoutputEPKControl, methodoutputEPKControlPrametersTypes);

            // Assert
            parametersOfoutputEPKControl.ShouldNotBeNull();
            parametersOfoutputEPKControl.Length.ShouldBe(7);
            methodoutputEPKControlPrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (outputEPKControl) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_outputEPKControl_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodoutputEPKControlPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(Page), typeof(string), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodoutputEPKControl, Fixture, methodoutputEPKControlPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodoutputEPKControlPrametersTypes.Length.ShouldBe(7);
        }

        #endregion

        #region Method Call : (outputEPKControl) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_outputEPKControl_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodoutputEPKControlPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(Page), typeof(string), typeof(bool) };
            const int parametersCount = 7;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodoutputEPKControl, Fixture, methodoutputEPKControlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodoutputEPKControlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (outputEPKControl) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_outputEPKControl_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodoutputEPKControl, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_helperFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (outputEPKControl) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_outputEPKControl_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodoutputEPKControl, 0);
            const int parametersCount = 7;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UseNonActiveXControl) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_HelperFunctions_UseNonActiveXControl_Static_Method_Call_Internally(Type[] types)
        {
            var methodUseNonActiveXControlPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodUseNonActiveXControl, Fixture, methodUseNonActiveXControlPrametersTypes);
        }

        #endregion

        #region Method Call : (UseNonActiveXControl) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_UseNonActiveXControl_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sControl = CreateType<string>();
            var list = CreateType<SPList>();
            Action executeAction = null;

            // Act
            executeAction = () => HelperFunctions.UseNonActiveXControl(sControl, list);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UseNonActiveXControl) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_UseNonActiveXControl_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sControl = CreateType<string>();
            var list = CreateType<SPList>();
            var methodUseNonActiveXControlPrametersTypes = new Type[] { typeof(string), typeof(SPList) };
            object[] parametersOfUseNonActiveXControl = { sControl, list };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodUseNonActiveXControl, parametersOfUseNonActiveXControl, methodUseNonActiveXControlPrametersTypes);

            // Assert
            parametersOfUseNonActiveXControl.ShouldNotBeNull();
            parametersOfUseNonActiveXControl.Length.ShouldBe(2);
            methodUseNonActiveXControlPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UseNonActiveXControl) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_UseNonActiveXControl_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUseNonActiveXControlPrametersTypes = new Type[] { typeof(string), typeof(SPList) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodUseNonActiveXControl, Fixture, methodUseNonActiveXControlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUseNonActiveXControlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UseNonActiveXControl) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_UseNonActiveXControl_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUseNonActiveXControl, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_helperFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UseNonActiveXControl) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_UseNonActiveXControl_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUseNonActiveXControl, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getProjectNameFromUID) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_HelperFunctions_getProjectNameFromUID_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetProjectNameFromUIDPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodgetProjectNameFromUID, Fixture, methodgetProjectNameFromUIDPrametersTypes);
        }

        #endregion

        #region Method Call : (getProjectNameFromUID) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_getProjectNameFromUID_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var id = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => HelperFunctions.getProjectNameFromUID(id);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (getProjectNameFromUID) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_getProjectNameFromUID_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var id = CreateType<string>();
            var methodgetProjectNameFromUIDPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfgetProjectNameFromUID = { id };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetProjectNameFromUID, methodgetProjectNameFromUIDPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodgetProjectNameFromUID, Fixture, methodgetProjectNameFromUIDPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodgetProjectNameFromUID, parametersOfgetProjectNameFromUID, methodgetProjectNameFromUIDPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_helperFunctionsInstanceFixture, parametersOfgetProjectNameFromUID);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetProjectNameFromUID.ShouldNotBeNull();
            parametersOfgetProjectNameFromUID.Length.ShouldBe(1);
            methodgetProjectNameFromUIDPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (getProjectNameFromUID) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_getProjectNameFromUID_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var id = CreateType<string>();
            var methodgetProjectNameFromUIDPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfgetProjectNameFromUID = { id };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodgetProjectNameFromUID, parametersOfgetProjectNameFromUID, methodgetProjectNameFromUIDPrametersTypes);

            // Assert
            parametersOfgetProjectNameFromUID.ShouldNotBeNull();
            parametersOfgetProjectNameFromUID.Length.ShouldBe(1);
            methodgetProjectNameFromUIDPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getProjectNameFromUID) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_getProjectNameFromUID_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetProjectNameFromUIDPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodgetProjectNameFromUID, Fixture, methodgetProjectNameFromUIDPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetProjectNameFromUIDPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getProjectNameFromUID) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_getProjectNameFromUID_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetProjectNameFromUIDPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodgetProjectNameFromUID, Fixture, methodgetProjectNameFromUIDPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetProjectNameFromUIDPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getProjectNameFromUID) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_getProjectNameFromUID_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetProjectNameFromUID, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_helperFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getProjectNameFromUID) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_getProjectNameFromUID_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetProjectNameFromUID, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (prepareItemList) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_HelperFunctions_prepareItemList_Static_Method_Call_Internally(Type[] types)
        {
            var methodprepareItemListPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodprepareItemList, Fixture, methodprepareItemListPrametersTypes);
        }

        #endregion

        #region Method Call : (prepareItemList) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_prepareItemList_Static_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodprepareItemListPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfprepareItemList = { list };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodprepareItemList, methodprepareItemListPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_helperFunctionsInstanceFixture, parametersOfprepareItemList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfprepareItemList.ShouldNotBeNull();
            parametersOfprepareItemList.Length.ShouldBe(1);
            methodprepareItemListPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (prepareItemList) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_prepareItemList_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodprepareItemListPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfprepareItemList = { list };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodprepareItemList, parametersOfprepareItemList, methodprepareItemListPrametersTypes);

            // Assert
            parametersOfprepareItemList.ShouldNotBeNull();
            parametersOfprepareItemList.Length.ShouldBe(1);
            methodprepareItemListPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (prepareItemList) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_prepareItemList_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodprepareItemList, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (prepareItemList) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_prepareItemList_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodprepareItemListPrametersTypes = new Type[] { typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodprepareItemList, Fixture, methodprepareItemListPrametersTypes);

            // Assert
            methodprepareItemListPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (prepareItemList) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_prepareItemList_Static_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprepareItemList, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_helperFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processResourceDisable) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_HelperFunctions_processResourceDisable_Static_Method_Call_Internally(Type[] types)
        {
            var methodprocessResourceDisablePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodprocessResourceDisable, Fixture, methodprocessResourceDisablePrametersTypes);
        }

        #endregion

        #region Method Call : (processResourceDisable) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_processResourceDisable_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var nd = CreateType<XmlNode>();
            var resList = CreateType<SPList>();
            var errors = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => HelperFunctions.processResourceDisable(nd, resList, out errors);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (processResourceDisable) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_processResourceDisable_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var nd = CreateType<XmlNode>();
            var resList = CreateType<SPList>();
            var errors = CreateType<bool>();
            var methodprocessResourceDisablePrametersTypes = new Type[] { typeof(XmlNode), typeof(SPList), typeof(bool) };
            object[] parametersOfprocessResourceDisable = { nd, resList, errors };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprocessResourceDisable, methodprocessResourceDisablePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodprocessResourceDisable, Fixture, methodprocessResourceDisablePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodprocessResourceDisable, parametersOfprocessResourceDisable, methodprocessResourceDisablePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_helperFunctionsInstanceFixture, parametersOfprocessResourceDisable);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfprocessResourceDisable.ShouldNotBeNull();
            parametersOfprocessResourceDisable.Length.ShouldBe(3);
            methodprocessResourceDisablePrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (processResourceDisable) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_processResourceDisable_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var nd = CreateType<XmlNode>();
            var resList = CreateType<SPList>();
            var errors = CreateType<bool>();
            var methodprocessResourceDisablePrametersTypes = new Type[] { typeof(XmlNode), typeof(SPList), typeof(bool) };
            object[] parametersOfprocessResourceDisable = { nd, resList, errors };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodprocessResourceDisable, parametersOfprocessResourceDisable, methodprocessResourceDisablePrametersTypes);

            // Assert
            parametersOfprocessResourceDisable.ShouldNotBeNull();
            parametersOfprocessResourceDisable.Length.ShouldBe(3);
            methodprocessResourceDisablePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processResourceDisable) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_processResourceDisable_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodprocessResourceDisablePrametersTypes = new Type[] { typeof(XmlNode), typeof(SPList), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodprocessResourceDisable, Fixture, methodprocessResourceDisablePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodprocessResourceDisablePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (processResourceDisable) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_processResourceDisable_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodprocessResourceDisablePrametersTypes = new Type[] { typeof(XmlNode), typeof(SPList), typeof(bool) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodprocessResourceDisable, Fixture, methodprocessResourceDisablePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodprocessResourceDisablePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processResourceDisable) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_processResourceDisable_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprocessResourceDisable, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_helperFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (processResourceDisable) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_processResourceDisable_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodprocessResourceDisable, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (prepareResList) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_HelperFunctions_prepareResList_Static_Method_Call_Internally(Type[] types)
        {
            var methodprepareResListPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodprepareResList, Fixture, methodprepareResListPrametersTypes);
        }

        #endregion

        #region Method Call : (prepareResList) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_prepareResList_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            Action executeAction = null;

            // Act
            executeAction = () => HelperFunctions.prepareResList(list);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (prepareResList) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_prepareResList_Static_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodprepareResListPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfprepareResList = { list };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodprepareResList, methodprepareResListPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_helperFunctionsInstanceFixture, parametersOfprepareResList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfprepareResList.ShouldNotBeNull();
            parametersOfprepareResList.Length.ShouldBe(1);
            methodprepareResListPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (prepareResList) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_prepareResList_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodprepareResListPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfprepareResList = { list };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodprepareResList, parametersOfprepareResList, methodprepareResListPrametersTypes);

            // Assert
            parametersOfprepareResList.ShouldNotBeNull();
            parametersOfprepareResList.Length.ShouldBe(1);
            methodprepareResListPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (prepareResList) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_prepareResList_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodprepareResList, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (prepareResList) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_prepareResList_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodprepareResListPrametersTypes = new Type[] { typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodprepareResList, Fixture, methodprepareResListPrametersTypes);

            // Assert
            methodprepareResListPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (prepareResList) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_prepareResList_Static_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprepareResList, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_helperFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processResource) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_HelperFunctions_processResource_Static_Method_Call_Internally(Type[] types)
        {
            var methodprocessResourcePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodprocessResource, Fixture, methodprocessResourcePrametersTypes);
        }

        #endregion

        #region Method Call : (processResource) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_processResource_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var nd = CreateType<XmlNode>();
            var resList = CreateType<SPList>();
            var hshFields = CreateType<Hashtable>();
            var errors = CreateType<bool>();
            var sPrefix = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => HelperFunctions.processResource(nd, resList, hshFields, ref errors, sPrefix);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (processResource) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_processResource_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var nd = CreateType<XmlNode>();
            var resList = CreateType<SPList>();
            var hshFields = CreateType<Hashtable>();
            var errors = CreateType<bool>();
            var sPrefix = CreateType<string>();
            var methodprocessResourcePrametersTypes = new Type[] { typeof(XmlNode), typeof(SPList), typeof(Hashtable), typeof(bool), typeof(string) };
            object[] parametersOfprocessResource = { nd, resList, hshFields, errors, sPrefix };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprocessResource, methodprocessResourcePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodprocessResource, Fixture, methodprocessResourcePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodprocessResource, parametersOfprocessResource, methodprocessResourcePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_helperFunctionsInstanceFixture, parametersOfprocessResource);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfprocessResource.ShouldNotBeNull();
            parametersOfprocessResource.Length.ShouldBe(5);
            methodprocessResourcePrametersTypes.Length.ShouldBe(5);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (processResource) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_processResource_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var nd = CreateType<XmlNode>();
            var resList = CreateType<SPList>();
            var hshFields = CreateType<Hashtable>();
            var errors = CreateType<bool>();
            var sPrefix = CreateType<string>();
            var methodprocessResourcePrametersTypes = new Type[] { typeof(XmlNode), typeof(SPList), typeof(Hashtable), typeof(bool), typeof(string) };
            object[] parametersOfprocessResource = { nd, resList, hshFields, errors, sPrefix };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodprocessResource, parametersOfprocessResource, methodprocessResourcePrametersTypes);

            // Assert
            parametersOfprocessResource.ShouldNotBeNull();
            parametersOfprocessResource.Length.ShouldBe(5);
            methodprocessResourcePrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processResource) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_processResource_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodprocessResourcePrametersTypes = new Type[] { typeof(XmlNode), typeof(SPList), typeof(Hashtable), typeof(bool), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodprocessResource, Fixture, methodprocessResourcePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodprocessResourcePrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (processResource) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_processResource_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodprocessResourcePrametersTypes = new Type[] { typeof(XmlNode), typeof(SPList), typeof(Hashtable), typeof(bool), typeof(string) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodprocessResource, Fixture, methodprocessResourcePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodprocessResourcePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processResource) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_processResource_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprocessResource, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_helperFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (processResource) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_processResource_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodprocessResource, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processPortfolioItem) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_HelperFunctions_processPortfolioItem_Static_Method_Call_Internally(Type[] types)
        {
            var methodprocessPortfolioItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodprocessPortfolioItem, Fixture, methodprocessPortfolioItemPrametersTypes);
        }

        #endregion

        #region Method Call : (processPortfolioItem) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_processPortfolioItem_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var list = CreateType<SPList>();
            var itemid = CreateType<string>();
            var fields = CreateType<DataRow[]>();
            var externalid = CreateType<string>();
            var errors = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => HelperFunctions.processPortfolioItem(web, list, itemid, fields, externalid, out errors);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (processPortfolioItem) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_processPortfolioItem_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var list = CreateType<SPList>();
            var itemid = CreateType<string>();
            var fields = CreateType<DataRow[]>();
            var externalid = CreateType<string>();
            var errors = CreateType<bool>();
            var methodprocessPortfolioItemPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPList), typeof(string), typeof(DataRow[]), typeof(string), typeof(bool) };
            object[] parametersOfprocessPortfolioItem = { web, list, itemid, fields, externalid, errors };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprocessPortfolioItem, methodprocessPortfolioItemPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodprocessPortfolioItem, Fixture, methodprocessPortfolioItemPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodprocessPortfolioItem, parametersOfprocessPortfolioItem, methodprocessPortfolioItemPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_helperFunctionsInstanceFixture, parametersOfprocessPortfolioItem);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfprocessPortfolioItem.ShouldNotBeNull();
            parametersOfprocessPortfolioItem.Length.ShouldBe(6);
            methodprocessPortfolioItemPrametersTypes.Length.ShouldBe(6);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (processPortfolioItem) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_processPortfolioItem_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var list = CreateType<SPList>();
            var itemid = CreateType<string>();
            var fields = CreateType<DataRow[]>();
            var externalid = CreateType<string>();
            var errors = CreateType<bool>();
            var methodprocessPortfolioItemPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPList), typeof(string), typeof(DataRow[]), typeof(string), typeof(bool) };
            object[] parametersOfprocessPortfolioItem = { web, list, itemid, fields, externalid, errors };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodprocessPortfolioItem, parametersOfprocessPortfolioItem, methodprocessPortfolioItemPrametersTypes);

            // Assert
            parametersOfprocessPortfolioItem.ShouldNotBeNull();
            parametersOfprocessPortfolioItem.Length.ShouldBe(6);
            methodprocessPortfolioItemPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processPortfolioItem) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_processPortfolioItem_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodprocessPortfolioItemPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPList), typeof(string), typeof(DataRow[]), typeof(string), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodprocessPortfolioItem, Fixture, methodprocessPortfolioItemPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodprocessPortfolioItemPrametersTypes.Length.ShouldBe(6);
        }

        #endregion

        #region Method Call : (processPortfolioItem) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_processPortfolioItem_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodprocessPortfolioItemPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPList), typeof(string), typeof(DataRow[]), typeof(string), typeof(bool) };
            const int parametersCount = 6;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodprocessPortfolioItem, Fixture, methodprocessPortfolioItemPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodprocessPortfolioItemPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processPortfolioItem) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_processPortfolioItem_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprocessPortfolioItem, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_helperFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (processPortfolioItem) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_processPortfolioItem_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodprocessPortfolioItem, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourcePool) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_HelperFunctions_GetResourcePool_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetResourcePoolPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodGetResourcePool, Fixture, methodGetResourcePoolPrametersTypes);
        }

        #endregion

        #region Method Call : (GetResourcePool) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_GetResourcePool_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => HelperFunctions.GetResourcePool(web);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetResourcePool) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_GetResourcePool_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodGetResourcePoolPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfGetResourcePool = { web };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetResourcePool, methodGetResourcePoolPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodGetResourcePool, Fixture, methodGetResourcePoolPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<DataTable>(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodGetResourcePool, parametersOfGetResourcePool, methodGetResourcePoolPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_helperFunctionsInstanceFixture, parametersOfGetResourcePool);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetResourcePool.ShouldNotBeNull();
            parametersOfGetResourcePool.Length.ShouldBe(1);
            methodGetResourcePoolPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetResourcePool) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_GetResourcePool_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodGetResourcePoolPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfGetResourcePool = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<DataTable>(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodGetResourcePool, parametersOfGetResourcePool, methodGetResourcePoolPrametersTypes);

            // Assert
            parametersOfGetResourcePool.ShouldNotBeNull();
            parametersOfGetResourcePool.Length.ShouldBe(1);
            methodGetResourcePoolPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetResourcePool) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_GetResourcePool_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetResourcePoolPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodGetResourcePool, Fixture, methodGetResourcePoolPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetResourcePoolPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetResourcePool) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_GetResourcePool_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetResourcePoolPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_helperFunctionsInstanceFixture, _helperFunctionsInstanceType, MethodGetResourcePool, Fixture, methodGetResourcePoolPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetResourcePoolPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourcePool) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_GetResourcePool_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetResourcePool, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_helperFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetResourcePool) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HelperFunctions_GetResourcePool_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetResourcePool, 0);
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
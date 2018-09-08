using System;
using System.Collections;
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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.getedititem" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class GetedititemTest : AbstractBaseSetupTypedTest<getedititem>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (getedititem) Initializer

        private const string MethodgetParams = "getParams";
        private const string MethodpopulateGroups = "populateGroups";
        private const string MethodoutputXml = "outputXml";
        private Type _getedititemInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private getedititem _getedititemInstance;
        private getedititem _getedititemInstanceFixture;

        #region General Initializer : Class (getedititem) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="getedititem" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _getedititemInstanceType = typeof(getedititem);
            _getedititemInstanceFixture = Create(true);
            _getedititemInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (getedititem)

        #region General Initializer : Class (getedititem) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="getedititem" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodgetParams, 0)]
        [TestCase(MethodpopulateGroups, 0)]
        [TestCase(MethodoutputXml, 0)]
        public void AUT_Getedititem_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_getedititemInstanceFixture, 
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
        ///     Class (<see cref="getedititem" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Getedititem_Is_Instance_Present_Test()
        {
            // Assert
            _getedititemInstanceType.ShouldNotBeNull();
            _getedititemInstance.ShouldNotBeNull();
            _getedititemInstanceFixture.ShouldNotBeNull();
            _getedititemInstance.ShouldBeAssignableTo<getedititem>();
            _getedititemInstanceFixture.ShouldBeAssignableTo<getedititem>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (getedititem) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_getedititem_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            getedititem instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _getedititemInstanceType.ShouldNotBeNull();
            _getedititemInstance.ShouldNotBeNull();
            _getedititemInstanceFixture.ShouldNotBeNull();
            _getedititemInstance.ShouldBeAssignableTo<getedititem>();
            _getedititemInstanceFixture.ShouldBeAssignableTo<getedititem>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="getedititem" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodgetParams)]
        [TestCase(MethodpopulateGroups)]
        [TestCase(MethodoutputXml)]
        public void AUT_Getedititem_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<getedititem>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (getParams) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getedititem_getParams_Method_Call_Internally(Type[] types)
        {
            var methodgetParamsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getedititemInstance, MethodgetParams, Fixture, methodgetParamsPrametersTypes);
        }

        #endregion

        #region Method Call : (getParams) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getedititem_getParams_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var curWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => _getedititemInstance.getParams(curWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (getParams) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getedititem_getParams_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var curWeb = CreateType<SPWeb>();
            var methodgetParamsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfgetParams = { curWeb };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetParams, methodgetParamsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getedititemInstanceFixture, parametersOfgetParams);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetParams.ShouldNotBeNull();
            parametersOfgetParams.Length.ShouldBe(1);
            methodgetParamsPrametersTypes.Length.ShouldBe(1);
            methodgetParamsPrametersTypes.Length.ShouldBe(parametersOfgetParams.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (getParams) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getedititem_getParams_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var curWeb = CreateType<SPWeb>();
            var methodgetParamsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfgetParams = { curWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getedititemInstance, MethodgetParams, parametersOfgetParams, methodgetParamsPrametersTypes);

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
        public void AUT_Getedititem_getParams_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Getedititem_getParams_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetParamsPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getedititemInstance, MethodgetParams, Fixture, methodgetParamsPrametersTypes);

            // Assert
            methodgetParamsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getParams) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getedititem_getParams_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetParams, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getedititemInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (populateGroups) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getedititem_populateGroups_Method_Call_Internally(Type[] types)
        {
            var methodpopulateGroupsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getedititemInstance, MethodpopulateGroups, Fixture, methodpopulateGroupsPrametersTypes);
        }

        #endregion

        #region Method Call : (populateGroups) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getedititem_populateGroups_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var query = CreateType<string>();
            var arrGTemp = CreateType<SortedList>();
            var curWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => _getedititemInstance.populateGroups(query, arrGTemp, curWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (populateGroups) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getedititem_populateGroups_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var query = CreateType<string>();
            var arrGTemp = CreateType<SortedList>();
            var curWeb = CreateType<SPWeb>();
            var methodpopulateGroupsPrametersTypes = new Type[] { typeof(string), typeof(SortedList), typeof(SPWeb) };
            object[] parametersOfpopulateGroups = { query, arrGTemp, curWeb };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodpopulateGroups, methodpopulateGroupsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getedititemInstanceFixture, parametersOfpopulateGroups);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfpopulateGroups.ShouldNotBeNull();
            parametersOfpopulateGroups.Length.ShouldBe(3);
            methodpopulateGroupsPrametersTypes.Length.ShouldBe(3);
            methodpopulateGroupsPrametersTypes.Length.ShouldBe(parametersOfpopulateGroups.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (populateGroups) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getedititem_populateGroups_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var query = CreateType<string>();
            var arrGTemp = CreateType<SortedList>();
            var curWeb = CreateType<SPWeb>();
            var methodpopulateGroupsPrametersTypes = new Type[] { typeof(string), typeof(SortedList), typeof(SPWeb) };
            object[] parametersOfpopulateGroups = { query, arrGTemp, curWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getedititemInstance, MethodpopulateGroups, parametersOfpopulateGroups, methodpopulateGroupsPrametersTypes);

            // Assert
            parametersOfpopulateGroups.ShouldNotBeNull();
            parametersOfpopulateGroups.Length.ShouldBe(3);
            methodpopulateGroupsPrametersTypes.Length.ShouldBe(3);
            methodpopulateGroupsPrametersTypes.Length.ShouldBe(parametersOfpopulateGroups.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (populateGroups) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getedititem_populateGroups_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodpopulateGroups, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (populateGroups) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getedititem_populateGroups_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodpopulateGroupsPrametersTypes = new Type[] { typeof(string), typeof(SortedList), typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getedititemInstance, MethodpopulateGroups, Fixture, methodpopulateGroupsPrametersTypes);

            // Assert
            methodpopulateGroupsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (populateGroups) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getedititem_populateGroups_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodpopulateGroups, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getedititemInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (outputXml) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getedititem_outputXml_Method_Call_Internally(Type[] types)
        {
            var methodoutputXmlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getedititemInstance, MethodoutputXml, Fixture, methodoutputXmlPrametersTypes);
        }

        #endregion

        #region Method Call : (outputXml) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getedititem_outputXml_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodoutputXmlPrametersTypes = null;
            object[] parametersOfoutputXml = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodoutputXml, methodoutputXmlPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getedititemInstanceFixture, parametersOfoutputXml);

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
        public void AUT_Getedititem_outputXml_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodoutputXmlPrametersTypes = null;
            object[] parametersOfoutputXml = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getedititemInstance, MethodoutputXml, parametersOfoutputXml, methodoutputXmlPrametersTypes);

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
        public void AUT_Getedititem_outputXml_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodoutputXmlPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getedititemInstance, MethodoutputXml, Fixture, methodoutputXmlPrametersTypes);

            // Assert
            methodoutputXmlPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (outputXml) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getedititem_outputXml_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodoutputXml, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getedititemInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
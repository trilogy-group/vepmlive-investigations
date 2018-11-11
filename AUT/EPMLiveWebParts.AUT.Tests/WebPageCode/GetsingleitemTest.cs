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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.getsingleitem" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class GetsingleitemTest : AbstractBaseSetupTypedTest<getsingleitem>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (getsingleitem) Initializer

        private const string MethodpopulateGroups = "populateGroups";
        private const string MethodoutputXml = "outputXml";
        private Type _getsingleitemInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private getsingleitem _getsingleitemInstance;
        private getsingleitem _getsingleitemInstanceFixture;

        #region General Initializer : Class (getsingleitem) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="getsingleitem" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _getsingleitemInstanceType = typeof(getsingleitem);
            _getsingleitemInstanceFixture = Create(true);
            _getsingleitemInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (getsingleitem)

        #region General Initializer : Class (getsingleitem) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="getsingleitem" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodpopulateGroups, 0)]
        [TestCase(MethodoutputXml, 0)]
        public void AUT_Getsingleitem_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_getsingleitemInstanceFixture, 
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
        ///     Class (<see cref="getsingleitem" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Getsingleitem_Is_Instance_Present_Test()
        {
            // Assert
            _getsingleitemInstanceType.ShouldNotBeNull();
            _getsingleitemInstance.ShouldNotBeNull();
            _getsingleitemInstanceFixture.ShouldNotBeNull();
            _getsingleitemInstance.ShouldBeAssignableTo<getsingleitem>();
            _getsingleitemInstanceFixture.ShouldBeAssignableTo<getsingleitem>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (getsingleitem) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_getsingleitem_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            getsingleitem instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _getsingleitemInstanceType.ShouldNotBeNull();
            _getsingleitemInstance.ShouldNotBeNull();
            _getsingleitemInstanceFixture.ShouldNotBeNull();
            _getsingleitemInstance.ShouldBeAssignableTo<getsingleitem>();
            _getsingleitemInstanceFixture.ShouldBeAssignableTo<getsingleitem>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="getsingleitem" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodpopulateGroups)]
        [TestCase(MethodoutputXml)]
        public void AUT_Getsingleitem_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<getsingleitem>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (populateGroups) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getsingleitem_populateGroups_Method_Call_Internally(Type[] types)
        {
            var methodpopulateGroupsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getsingleitemInstance, MethodpopulateGroups, Fixture, methodpopulateGroupsPrametersTypes);
        }

        #endregion

        #region Method Call : (populateGroups) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getsingleitem_populateGroups_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var query = CreateType<string>();
            var arrGTemp = CreateType<SortedList>();
            var curWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => _getsingleitemInstance.populateGroups(query, arrGTemp, curWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (populateGroups) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getsingleitem_populateGroups_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
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
            Action currentAction = () => methodInfo.Invoke(_getsingleitemInstanceFixture, parametersOfpopulateGroups);

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
        public void AUT_Getsingleitem_populateGroups_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var query = CreateType<string>();
            var arrGTemp = CreateType<SortedList>();
            var curWeb = CreateType<SPWeb>();
            var methodpopulateGroupsPrametersTypes = new Type[] { typeof(string), typeof(SortedList), typeof(SPWeb) };
            object[] parametersOfpopulateGroups = { query, arrGTemp, curWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getsingleitemInstance, MethodpopulateGroups, parametersOfpopulateGroups, methodpopulateGroupsPrametersTypes);

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
        public void AUT_Getsingleitem_populateGroups_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Getsingleitem_populateGroups_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodpopulateGroupsPrametersTypes = new Type[] { typeof(string), typeof(SortedList), typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getsingleitemInstance, MethodpopulateGroups, Fixture, methodpopulateGroupsPrametersTypes);

            // Assert
            methodpopulateGroupsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (populateGroups) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getsingleitem_populateGroups_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodpopulateGroups, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getsingleitemInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (outputXml) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getsingleitem_outputXml_Method_Call_Internally(Type[] types)
        {
            var methodoutputXmlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getsingleitemInstance, MethodoutputXml, Fixture, methodoutputXmlPrametersTypes);
        }

        #endregion

        #region Method Call : (outputXml) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getsingleitem_outputXml_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodoutputXmlPrametersTypes = null;
            object[] parametersOfoutputXml = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodoutputXml, methodoutputXmlPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getsingleitemInstanceFixture, parametersOfoutputXml);

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
        public void AUT_Getsingleitem_outputXml_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodoutputXmlPrametersTypes = null;
            object[] parametersOfoutputXml = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getsingleitemInstance, MethodoutputXml, parametersOfoutputXml, methodoutputXmlPrametersTypes);

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
        public void AUT_Getsingleitem_outputXml_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodoutputXmlPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getsingleitemInstance, MethodoutputXml, Fixture, methodoutputXmlPrametersTypes);

            // Assert
            methodoutputXmlPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (outputXml) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getsingleitem_outputXml_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodoutputXml, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getsingleitemInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
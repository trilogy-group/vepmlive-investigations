using System;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.AutoFixtureSetup;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using EPMLiveCore.Properties;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore.WebPartsHelper;
using WebPartsReflector = EPMLiveCore.WebPartsHelper;

namespace EPMLiveCore.WebPartsHelper
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.WebPartsHelper.WebPartsReflector" />)
    ///     and namespace <see cref="EPMLiveCore.WebPartsHelper"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class WebPartsReflectorTest : AbstractBaseSetupTest
    {

        public WebPartsReflectorTest() : base(typeof(WebPartsReflector))
        {}

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WebPartsReflector) Initializer

        private const string MethodCreateGridListViewWebPart = "CreateGridListViewWebPart";
        private const string MethodCreateFancyDisplayFormWebPart = "CreateFancyDisplayFormWebPart";
        private const string MethodIsWebPartGridListView = "IsWebPartGridListView";
        private const string MethodCreateMyWorkWebPart = "CreateMyWorkWebPart";
        private const string MethodIsWebpartMyWorkWebPart = "IsWebpartMyWorkWebPart";
        private const string MethodSetWebPartProperty = "SetWebPartProperty";
        private Type _webPartsReflectorInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;

        #region General Initializer : Class (WebPartsReflector) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WebPartsReflector" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _webPartsReflectorInstanceType = typeof(WebPartsReflector);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WebPartsReflector)

        #region General Initializer : Class (WebPartsReflector) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="WebPartsReflector" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodCreateGridListViewWebPart, 0)]
        [TestCase(MethodCreateFancyDisplayFormWebPart, 0)]
        [TestCase(MethodIsWebPartGridListView, 0)]
        [TestCase(MethodCreateMyWorkWebPart, 0)]
        [TestCase(MethodIsWebpartMyWorkWebPart, 0)]
        [TestCase(MethodSetWebPartProperty, 0)]
        public void AUT_WebPartsReflector_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(null, 
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
        ///     Class (<see cref="WebPartsReflector" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_WebPartsReflector_Is_Static_Type_Present_Test()
        {
            // Assert
            _webPartsReflectorInstanceType.ShouldNotBeNull();
        }

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="WebPartsReflector" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodCreateGridListViewWebPart)]
        [TestCase(MethodCreateFancyDisplayFormWebPart)]
        [TestCase(MethodIsWebPartGridListView)]
        [TestCase(MethodCreateMyWorkWebPart)]
        [TestCase(MethodIsWebpartMyWorkWebPart)]
        [TestCase(MethodSetWebPartProperty)]
        public void AUT_WebPartsReflector_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(null,
                                                                              _webPartsReflectorInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (CreateGridListViewWebPart) (Return Type : WebPart) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WebPartsReflector_CreateGridListViewWebPart_Static_Method_Call_Internally(Type[] types)
        {
            var methodCreateGridListViewWebPartPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _webPartsReflectorInstanceType, MethodCreateGridListViewWebPart, Fixture, methodCreateGridListViewWebPartPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateGridListViewWebPart) (Return Type : WebPart) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartsReflector_CreateGridListViewWebPart_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => WebPartsReflector.CreateGridListViewWebPart();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (CreateGridListViewWebPart) (Return Type : WebPart) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartsReflector_CreateGridListViewWebPart_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodCreateGridListViewWebPartPrametersTypes = null;
            object[] parametersOfCreateGridListViewWebPart = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateGridListViewWebPart, methodCreateGridListViewWebPartPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfCreateGridListViewWebPart);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateGridListViewWebPart.ShouldBeNull();
            methodCreateGridListViewWebPartPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateGridListViewWebPart) (Return Type : WebPart) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartsReflector_CreateGridListViewWebPart_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateGridListViewWebPartPrametersTypes = null;
            object[] parametersOfCreateGridListViewWebPart = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<WebPart>(null, _webPartsReflectorInstanceType, MethodCreateGridListViewWebPart, parametersOfCreateGridListViewWebPart, methodCreateGridListViewWebPartPrametersTypes);

            // Assert
            parametersOfCreateGridListViewWebPart.ShouldBeNull();
            methodCreateGridListViewWebPartPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateGridListViewWebPart) (Return Type : WebPart) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartsReflector_CreateGridListViewWebPart_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodCreateGridListViewWebPartPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _webPartsReflectorInstanceType, MethodCreateGridListViewWebPart, Fixture, methodCreateGridListViewWebPartPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCreateGridListViewWebPartPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateGridListViewWebPart) (Return Type : WebPart) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartsReflector_CreateGridListViewWebPart_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateGridListViewWebPartPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _webPartsReflectorInstanceType, MethodCreateGridListViewWebPart, Fixture, methodCreateGridListViewWebPartPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreateGridListViewWebPartPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateGridListViewWebPart) (Return Type : WebPart) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartsReflector_CreateGridListViewWebPart_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateGridListViewWebPart, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (CreateFancyDisplayFormWebPart) (Return Type : WebPart) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WebPartsReflector_CreateFancyDisplayFormWebPart_Static_Method_Call_Internally(Type[] types)
        {
            var methodCreateFancyDisplayFormWebPartPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _webPartsReflectorInstanceType, MethodCreateFancyDisplayFormWebPart, Fixture, methodCreateFancyDisplayFormWebPartPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateFancyDisplayFormWebPart) (Return Type : WebPart) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartsReflector_CreateFancyDisplayFormWebPart_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => WebPartsReflector.CreateFancyDisplayFormWebPart();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (CreateFancyDisplayFormWebPart) (Return Type : WebPart) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartsReflector_CreateFancyDisplayFormWebPart_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodCreateFancyDisplayFormWebPartPrametersTypes = null;
            object[] parametersOfCreateFancyDisplayFormWebPart = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateFancyDisplayFormWebPart, methodCreateFancyDisplayFormWebPartPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfCreateFancyDisplayFormWebPart);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateFancyDisplayFormWebPart.ShouldBeNull();
            methodCreateFancyDisplayFormWebPartPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateFancyDisplayFormWebPart) (Return Type : WebPart) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartsReflector_CreateFancyDisplayFormWebPart_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateFancyDisplayFormWebPartPrametersTypes = null;
            object[] parametersOfCreateFancyDisplayFormWebPart = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<WebPart>(null, _webPartsReflectorInstanceType, MethodCreateFancyDisplayFormWebPart, parametersOfCreateFancyDisplayFormWebPart, methodCreateFancyDisplayFormWebPartPrametersTypes);

            // Assert
            parametersOfCreateFancyDisplayFormWebPart.ShouldBeNull();
            methodCreateFancyDisplayFormWebPartPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateFancyDisplayFormWebPart) (Return Type : WebPart) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartsReflector_CreateFancyDisplayFormWebPart_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodCreateFancyDisplayFormWebPartPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _webPartsReflectorInstanceType, MethodCreateFancyDisplayFormWebPart, Fixture, methodCreateFancyDisplayFormWebPartPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCreateFancyDisplayFormWebPartPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateFancyDisplayFormWebPart) (Return Type : WebPart) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartsReflector_CreateFancyDisplayFormWebPart_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateFancyDisplayFormWebPartPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _webPartsReflectorInstanceType, MethodCreateFancyDisplayFormWebPart, Fixture, methodCreateFancyDisplayFormWebPartPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreateFancyDisplayFormWebPartPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateFancyDisplayFormWebPart) (Return Type : WebPart) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartsReflector_CreateFancyDisplayFormWebPart_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateFancyDisplayFormWebPart, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (IsWebPartGridListView) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WebPartsReflector_IsWebPartGridListView_Static_Method_Call_Internally(Type[] types)
        {
            var methodIsWebPartGridListViewPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _webPartsReflectorInstanceType, MethodIsWebPartGridListView, Fixture, methodIsWebPartGridListViewPrametersTypes);
        }

        #endregion

        #region Method Call : (IsWebPartGridListView) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartsReflector_IsWebPartGridListView_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var wp = CreateType<WebPart>();
            Action executeAction = null;

            // Act
            executeAction = () => WebPartsReflector.IsWebPartGridListView(wp);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (IsWebPartGridListView) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartsReflector_IsWebPartGridListView_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var wp = CreateType<WebPart>();
            var methodIsWebPartGridListViewPrametersTypes = new Type[] { typeof(WebPart) };
            object[] parametersOfIsWebPartGridListView = { wp };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsWebPartGridListView, methodIsWebPartGridListViewPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _webPartsReflectorInstanceType, MethodIsWebPartGridListView, Fixture, methodIsWebPartGridListViewPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<bool>(null, _webPartsReflectorInstanceType, MethodIsWebPartGridListView, parametersOfIsWebPartGridListView, methodIsWebPartGridListViewPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsWebPartGridListView.ShouldNotBeNull();
            parametersOfIsWebPartGridListView.Length.ShouldBe(1);
            methodIsWebPartGridListViewPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(null, _webPartsReflectorInstanceType, MethodIsWebPartGridListView, parametersOfIsWebPartGridListView, methodIsWebPartGridListViewPrametersTypes));
        }

        #endregion

        #region Method Call : (IsWebPartGridListView) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartsReflector_IsWebPartGridListView_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var wp = CreateType<WebPart>();
            var methodIsWebPartGridListViewPrametersTypes = new Type[] { typeof(WebPart) };
            object[] parametersOfIsWebPartGridListView = { wp };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodIsWebPartGridListView, methodIsWebPartGridListViewPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfIsWebPartGridListView);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfIsWebPartGridListView.ShouldNotBeNull();
            parametersOfIsWebPartGridListView.Length.ShouldBe(1);
            methodIsWebPartGridListViewPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsWebPartGridListView) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartsReflector_IsWebPartGridListView_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var wp = CreateType<WebPart>();
            var methodIsWebPartGridListViewPrametersTypes = new Type[] { typeof(WebPart) };
            object[] parametersOfIsWebPartGridListView = { wp };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(null, _webPartsReflectorInstanceType, MethodIsWebPartGridListView, parametersOfIsWebPartGridListView, methodIsWebPartGridListViewPrametersTypes);

            // Assert
            parametersOfIsWebPartGridListView.ShouldNotBeNull();
            parametersOfIsWebPartGridListView.Length.ShouldBe(1);
            methodIsWebPartGridListViewPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsWebPartGridListView) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartsReflector_IsWebPartGridListView_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodIsWebPartGridListViewPrametersTypes = new Type[] { typeof(WebPart) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _webPartsReflectorInstanceType, MethodIsWebPartGridListView, Fixture, methodIsWebPartGridListViewPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodIsWebPartGridListViewPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (IsWebPartGridListView) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartsReflector_IsWebPartGridListView_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodIsWebPartGridListViewPrametersTypes = new Type[] { typeof(WebPart) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _webPartsReflectorInstanceType, MethodIsWebPartGridListView, Fixture, methodIsWebPartGridListViewPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodIsWebPartGridListViewPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (IsWebPartGridListView) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartsReflector_IsWebPartGridListView_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsWebPartGridListViewPrametersTypes = new Type[] { typeof(WebPart) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _webPartsReflectorInstanceType, MethodIsWebPartGridListView, Fixture, methodIsWebPartGridListViewPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsWebPartGridListViewPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsWebPartGridListView) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartsReflector_IsWebPartGridListView_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsWebPartGridListView, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (IsWebPartGridListView) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartsReflector_IsWebPartGridListView_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodIsWebPartGridListView, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateMyWorkWebPart) (Return Type : object) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WebPartsReflector_CreateMyWorkWebPart_Static_Method_Call_Internally(Type[] types)
        {
            var methodCreateMyWorkWebPartPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _webPartsReflectorInstanceType, MethodCreateMyWorkWebPart, Fixture, methodCreateMyWorkWebPartPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateMyWorkWebPart) (Return Type : object) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartsReflector_CreateMyWorkWebPart_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => WebPartsReflector.CreateMyWorkWebPart();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (CreateMyWorkWebPart) (Return Type : object) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartsReflector_CreateMyWorkWebPart_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodCreateMyWorkWebPartPrametersTypes = null;
            object[] parametersOfCreateMyWorkWebPart = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateMyWorkWebPart, methodCreateMyWorkWebPartPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfCreateMyWorkWebPart);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateMyWorkWebPart.ShouldBeNull();
            methodCreateMyWorkWebPartPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateMyWorkWebPart) (Return Type : object) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartsReflector_CreateMyWorkWebPart_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateMyWorkWebPartPrametersTypes = null;
            object[] parametersOfCreateMyWorkWebPart = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<object>(null, _webPartsReflectorInstanceType, MethodCreateMyWorkWebPart, parametersOfCreateMyWorkWebPart, methodCreateMyWorkWebPartPrametersTypes);

            // Assert
            parametersOfCreateMyWorkWebPart.ShouldBeNull();
            methodCreateMyWorkWebPartPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateMyWorkWebPart) (Return Type : object) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartsReflector_CreateMyWorkWebPart_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodCreateMyWorkWebPartPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _webPartsReflectorInstanceType, MethodCreateMyWorkWebPart, Fixture, methodCreateMyWorkWebPartPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCreateMyWorkWebPartPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateMyWorkWebPart) (Return Type : object) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartsReflector_CreateMyWorkWebPart_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateMyWorkWebPartPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _webPartsReflectorInstanceType, MethodCreateMyWorkWebPart, Fixture, methodCreateMyWorkWebPartPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreateMyWorkWebPartPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateMyWorkWebPart) (Return Type : object) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartsReflector_CreateMyWorkWebPart_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateMyWorkWebPart, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (IsWebpartMyWorkWebPart) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WebPartsReflector_IsWebpartMyWorkWebPart_Static_Method_Call_Internally(Type[] types)
        {
            var methodIsWebpartMyWorkWebPartPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _webPartsReflectorInstanceType, MethodIsWebpartMyWorkWebPart, Fixture, methodIsWebpartMyWorkWebPartPrametersTypes);
        }

        #endregion

        #region Method Call : (IsWebpartMyWorkWebPart) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartsReflector_IsWebpartMyWorkWebPart_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var myWorkWebPart = CreateType<object>();
            Action executeAction = null;

            // Act
            executeAction = () => WebPartsReflector.IsWebpartMyWorkWebPart(myWorkWebPart);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (IsWebpartMyWorkWebPart) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartsReflector_IsWebpartMyWorkWebPart_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var myWorkWebPart = CreateType<object>();
            var methodIsWebpartMyWorkWebPartPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfIsWebpartMyWorkWebPart = { myWorkWebPart };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsWebpartMyWorkWebPart, methodIsWebpartMyWorkWebPartPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _webPartsReflectorInstanceType, MethodIsWebpartMyWorkWebPart, Fixture, methodIsWebpartMyWorkWebPartPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<bool>(null, _webPartsReflectorInstanceType, MethodIsWebpartMyWorkWebPart, parametersOfIsWebpartMyWorkWebPart, methodIsWebpartMyWorkWebPartPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsWebpartMyWorkWebPart.ShouldNotBeNull();
            parametersOfIsWebpartMyWorkWebPart.Length.ShouldBe(1);
            methodIsWebpartMyWorkWebPartPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(null, _webPartsReflectorInstanceType, MethodIsWebpartMyWorkWebPart, parametersOfIsWebpartMyWorkWebPart, methodIsWebpartMyWorkWebPartPrametersTypes));
        }

        #endregion

        #region Method Call : (IsWebpartMyWorkWebPart) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartsReflector_IsWebpartMyWorkWebPart_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var myWorkWebPart = CreateType<object>();
            var methodIsWebpartMyWorkWebPartPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfIsWebpartMyWorkWebPart = { myWorkWebPart };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodIsWebpartMyWorkWebPart, methodIsWebpartMyWorkWebPartPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfIsWebpartMyWorkWebPart);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfIsWebpartMyWorkWebPart.ShouldNotBeNull();
            parametersOfIsWebpartMyWorkWebPart.Length.ShouldBe(1);
            methodIsWebpartMyWorkWebPartPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsWebpartMyWorkWebPart) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartsReflector_IsWebpartMyWorkWebPart_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var myWorkWebPart = CreateType<object>();
            var methodIsWebpartMyWorkWebPartPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfIsWebpartMyWorkWebPart = { myWorkWebPart };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(null, _webPartsReflectorInstanceType, MethodIsWebpartMyWorkWebPart, parametersOfIsWebpartMyWorkWebPart, methodIsWebpartMyWorkWebPartPrametersTypes);

            // Assert
            parametersOfIsWebpartMyWorkWebPart.ShouldNotBeNull();
            parametersOfIsWebpartMyWorkWebPart.Length.ShouldBe(1);
            methodIsWebpartMyWorkWebPartPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsWebpartMyWorkWebPart) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartsReflector_IsWebpartMyWorkWebPart_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodIsWebpartMyWorkWebPartPrametersTypes = new Type[] { typeof(object) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _webPartsReflectorInstanceType, MethodIsWebpartMyWorkWebPart, Fixture, methodIsWebpartMyWorkWebPartPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodIsWebpartMyWorkWebPartPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (IsWebpartMyWorkWebPart) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartsReflector_IsWebpartMyWorkWebPart_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodIsWebpartMyWorkWebPartPrametersTypes = new Type[] { typeof(object) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _webPartsReflectorInstanceType, MethodIsWebpartMyWorkWebPart, Fixture, methodIsWebpartMyWorkWebPartPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodIsWebpartMyWorkWebPartPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (IsWebpartMyWorkWebPart) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartsReflector_IsWebpartMyWorkWebPart_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsWebpartMyWorkWebPartPrametersTypes = new Type[] { typeof(object) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _webPartsReflectorInstanceType, MethodIsWebpartMyWorkWebPart, Fixture, methodIsWebpartMyWorkWebPartPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsWebpartMyWorkWebPartPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsWebpartMyWorkWebPart) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartsReflector_IsWebpartMyWorkWebPart_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsWebpartMyWorkWebPart, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (IsWebpartMyWorkWebPart) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartsReflector_IsWebpartMyWorkWebPart_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodIsWebpartMyWorkWebPart, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetWebPartProperty) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WebPartsReflector_SetWebPartProperty_Static_Method_Call_Internally(Type[] types)
        {
            var methodSetWebPartPropertyPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _webPartsReflectorInstanceType, MethodSetWebPartProperty, Fixture, methodSetWebPartPropertyPrametersTypes);
        }

        #endregion

        #region Method Call : (SetWebPartProperty) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartsReflector_SetWebPartProperty_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var webPart = CreateType<object>();
            var property = CreateType<string>();
            var value = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => WebPartsReflector.SetWebPartProperty(webPart, property, value);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetWebPartProperty) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartsReflector_SetWebPartProperty_Static_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var webPart = CreateType<object>();
            var property = CreateType<string>();
            var value = CreateType<string>();
            var methodSetWebPartPropertyPrametersTypes = new Type[] { typeof(object), typeof(string), typeof(string) };
            object[] parametersOfSetWebPartProperty = { webPart, property, value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetWebPartProperty, methodSetWebPartPropertyPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfSetWebPartProperty);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetWebPartProperty.ShouldNotBeNull();
            parametersOfSetWebPartProperty.Length.ShouldBe(3);
            methodSetWebPartPropertyPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetWebPartProperty) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartsReflector_SetWebPartProperty_Static_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var webPart = CreateType<object>();
            var property = CreateType<string>();
            var value = CreateType<string>();
            var methodSetWebPartPropertyPrametersTypes = new Type[] { typeof(object), typeof(string), typeof(string) };
            object[] parametersOfSetWebPartProperty = { webPart, property, value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(null, _webPartsReflectorInstanceType, MethodSetWebPartProperty, parametersOfSetWebPartProperty, methodSetWebPartPropertyPrametersTypes);

            // Assert
            parametersOfSetWebPartProperty.ShouldNotBeNull();
            parametersOfSetWebPartProperty.Length.ShouldBe(3);
            methodSetWebPartPropertyPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetWebPartProperty) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartsReflector_SetWebPartProperty_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetWebPartProperty, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetWebPartProperty) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartsReflector_SetWebPartProperty_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetWebPartPropertyPrametersTypes = new Type[] { typeof(object), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _webPartsReflectorInstanceType, MethodSetWebPartProperty, Fixture, methodSetWebPartPropertyPrametersTypes);

            // Assert
            methodSetWebPartPropertyPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetWebPartProperty) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartsReflector_SetWebPartProperty_Static_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetWebPartProperty, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
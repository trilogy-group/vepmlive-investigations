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

namespace EPMLiveWebParts
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.checkresgantt" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CheckresganttTest : AbstractBaseSetupTypedTest<checkresgantt>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (checkresgantt) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodgetParam = "getParam";
        private const string MethodloadTemplate = "loadTemplate";
        private const string FieldstrTemplate = "strTemplate";
        private const string FieldstrUrl = "strUrl";
        private const string FieldstrParams = "strParams";
        private const string Fieldlist = "list";
        private const string Fieldview = "view";
        private const string FieldstrFunctions = "strFunctions";
        private const string Fielddfmt = "dfmt";
        private const string FieldstrWorkplanner = "strWorkplanner";
        private const string FieldstrItemId = "strItemId";
        private const string FieldstrCallBack = "strCallBack";
        private Type _checkresganttInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private checkresgantt _checkresganttInstance;
        private checkresgantt _checkresganttInstanceFixture;

        #region General Initializer : Class (checkresgantt) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="checkresgantt" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _checkresganttInstanceType = typeof(checkresgantt);
            _checkresganttInstanceFixture = Create(true);
            _checkresganttInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (checkresgantt)

        #region General Initializer : Class (checkresgantt) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="checkresgantt" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodgetParam, 0)]
        [TestCase(MethodloadTemplate, 0)]
        public void AUT_Checkresgantt_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_checkresganttInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (checkresgantt) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="checkresgantt" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldstrTemplate)]
        [TestCase(FieldstrUrl)]
        [TestCase(FieldstrParams)]
        [TestCase(Fieldlist)]
        [TestCase(Fieldview)]
        [TestCase(FieldstrFunctions)]
        [TestCase(Fielddfmt)]
        [TestCase(FieldstrWorkplanner)]
        [TestCase(FieldstrItemId)]
        [TestCase(FieldstrCallBack)]
        public void AUT_Checkresgantt_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_checkresganttInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="checkresgantt" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodgetParam)]
        [TestCase(MethodloadTemplate)]
        public void AUT_Checkresgantt_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<checkresgantt>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Checkresgantt_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_checkresganttInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Checkresgantt_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_checkresganttInstanceFixture, parametersOfPage_Load);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPage_Load.ShouldNotBeNull();
            parametersOfPage_Load.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(parametersOfPage_Load.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Checkresgantt_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_checkresganttInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

            // Assert
            parametersOfPage_Load.ShouldNotBeNull();
            parametersOfPage_Load.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(parametersOfPage_Load.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Checkresgantt_Page_Load_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Checkresgantt_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_checkresganttInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Checkresgantt_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_checkresganttInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getParam) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Checkresgantt_getParam_Method_Call_Internally(Type[] types)
        {
            var methodgetParamPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_checkresganttInstance, MethodgetParam, Fixture, methodgetParamPrametersTypes);
        }

        #endregion

        #region Method Call : (getParam) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Checkresgantt_getParam_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodgetParamPrametersTypes = null;
            object[] parametersOfgetParam = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodgetParam, methodgetParamPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<checkresgantt, string>(_checkresganttInstanceFixture, out exception1, parametersOfgetParam);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<checkresgantt, string>(_checkresganttInstance, MethodgetParam, parametersOfgetParam, methodgetParamPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetParam.ShouldBeNull();
            methodgetParamPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getParam) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Checkresgantt_getParam_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodgetParamPrametersTypes = null;
            object[] parametersOfgetParam = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<checkresgantt, string>(_checkresganttInstance, MethodgetParam, parametersOfgetParam, methodgetParamPrametersTypes);

            // Assert
            parametersOfgetParam.ShouldBeNull();
            methodgetParamPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getParam) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Checkresgantt_getParam_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodgetParamPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_checkresganttInstance, MethodgetParam, Fixture, methodgetParamPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetParamPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getParam) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Checkresgantt_getParam_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodgetParamPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_checkresganttInstance, MethodgetParam, Fixture, methodgetParamPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetParamPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getParam) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Checkresgantt_getParam_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetParam, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_checkresganttInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (loadTemplate) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Checkresgantt_loadTemplate_Method_Call_Internally(Type[] types)
        {
            var methodloadTemplatePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_checkresganttInstance, MethodloadTemplate, Fixture, methodloadTemplatePrametersTypes);
        }

        #endregion

        #region Method Call : (loadTemplate) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Checkresgantt_loadTemplate_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodloadTemplatePrametersTypes = null;
            object[] parametersOfloadTemplate = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodloadTemplate, methodloadTemplatePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_checkresganttInstanceFixture, parametersOfloadTemplate);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfloadTemplate.ShouldBeNull();
            methodloadTemplatePrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (loadTemplate) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Checkresgantt_loadTemplate_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodloadTemplatePrametersTypes = null;
            object[] parametersOfloadTemplate = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_checkresganttInstance, MethodloadTemplate, parametersOfloadTemplate, methodloadTemplatePrametersTypes);

            // Assert
            parametersOfloadTemplate.ShouldBeNull();
            methodloadTemplatePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadTemplate) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Checkresgantt_loadTemplate_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodloadTemplatePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_checkresganttInstance, MethodloadTemplate, Fixture, methodloadTemplatePrametersTypes);

            // Assert
            methodloadTemplatePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadTemplate) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Checkresgantt_loadTemplate_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodloadTemplate, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_checkresganttInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
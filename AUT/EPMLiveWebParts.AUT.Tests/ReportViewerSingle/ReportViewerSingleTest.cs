using System;
using System.Diagnostics.CodeAnalysis;
using System.Web.UI;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.ReportViewerSingle" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ReportViewerSingleTest : AbstractBaseSetupTypedTest<ReportViewerSingle>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportViewerSingle) Initializer

        private const string PropertyPropReportPath = "PropReportPath";
        private const string PropertyUseDefaults = "UseDefaults";
        private const string PropertyPropSRSUrl = "PropSRSUrl";
        private const string PropertyIsIntegratedMode = "IsIntegratedMode";
        private const string MethodCreateChildControls = "CreateChildControls";
        private const string MethodRenderWebPart = "RenderWebPart";
        private const string Fieldrv = "rv";
        private const string FieldReportingServicesURL = "ReportingServicesURL";
        private const string FieldIntegrated = "Integrated";
        private const string FieldbUseDefaults = "bUseDefaults";
        private const string FieldbIsIntegratedMode = "bIsIntegratedMode";
        private const string FieldstrSRSUrl = "strSRSUrl";
        private const string FieldstrReportsPath = "strReportsPath";
        private const string Fielderror = "error";
        private Type _reportViewerSingleInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportViewerSingle _reportViewerSingleInstance;
        private ReportViewerSingle _reportViewerSingleInstanceFixture;

        #region General Initializer : Class (ReportViewerSingle) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportViewerSingle" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportViewerSingleInstanceType = typeof(ReportViewerSingle);
            _reportViewerSingleInstanceFixture = Create(true);
            _reportViewerSingleInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportViewerSingle)

        #region General Initializer : Class (ReportViewerSingle) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ReportViewerSingle" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(MethodCreateChildControls, 0)]
        [TestCase(MethodRenderWebPart, 0)]
        public void AUT_ReportViewerSingle_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_reportViewerSingleInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ReportViewerSingle) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportViewerSingle" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyPropReportPath)]
        [TestCase(PropertyUseDefaults)]
        [TestCase(PropertyPropSRSUrl)]
        [TestCase(PropertyIsIntegratedMode)]
        public void AUT_ReportViewerSingle_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_reportViewerSingleInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ReportViewerSingle) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportViewerSingle" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Fieldrv)]
        [TestCase(FieldReportingServicesURL)]
        [TestCase(FieldIntegrated)]
        [TestCase(FieldbUseDefaults)]
        [TestCase(FieldbIsIntegratedMode)]
        [TestCase(FieldstrSRSUrl)]
        [TestCase(FieldstrReportsPath)]
        [TestCase(Fielderror)]
        public void AUT_ReportViewerSingle_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_reportViewerSingleInstanceFixture, 
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
        ///     Class (<see cref="ReportViewerSingle" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ReportViewerSingle_Is_Instance_Present_Test()
        {
            // Assert
            _reportViewerSingleInstanceType.ShouldNotBeNull();
            _reportViewerSingleInstance.ShouldNotBeNull();
            _reportViewerSingleInstanceFixture.ShouldNotBeNull();
            _reportViewerSingleInstance.ShouldBeAssignableTo<ReportViewerSingle>();
            _reportViewerSingleInstanceFixture.ShouldBeAssignableTo<ReportViewerSingle>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ReportViewerSingle) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ReportViewerSingle_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ReportViewerSingle instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _reportViewerSingleInstanceType.ShouldNotBeNull();
            _reportViewerSingleInstance.ShouldNotBeNull();
            _reportViewerSingleInstanceFixture.ShouldNotBeNull();
            _reportViewerSingleInstance.ShouldBeAssignableTo<ReportViewerSingle>();
            _reportViewerSingleInstanceFixture.ShouldBeAssignableTo<ReportViewerSingle>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ReportViewerSingle) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyPropReportPath)]
        [TestCaseGeneric(typeof(bool) , PropertyUseDefaults)]
        [TestCaseGeneric(typeof(string) , PropertyPropSRSUrl)]
        [TestCaseGeneric(typeof(bool) , PropertyIsIntegratedMode)]
        public void AUT_ReportViewerSingle_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ReportViewerSingle, T>(_reportViewerSingleInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ReportViewerSingle) => Property (IsIntegratedMode) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportViewerSingle_Public_Class_IsIntegratedMode_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyIsIntegratedMode);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportViewerSingle) => Property (PropReportPath) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportViewerSingle_Public_Class_PropReportPath_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropReportPath);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportViewerSingle) => Property (PropSRSUrl) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportViewerSingle_Public_Class_PropSRSUrl_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropSRSUrl);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportViewerSingle) => Property (UseDefaults) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportViewerSingle_Public_Class_UseDefaults_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyUseDefaults);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ReportViewerSingle" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        [TestCase(MethodCreateChildControls)]
        [TestCase(MethodRenderWebPart)]
        public void AUT_ReportViewerSingle_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ReportViewerSingle>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportViewerSingle_CreateChildControls_Method_Call_Internally(Type[] types)
        {
            var methodCreateChildControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportViewerSingleInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewerSingle_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, methodCreateChildControlsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportViewerSingleInstanceFixture, parametersOfCreateChildControls);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateChildControls.ShouldBeNull();
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewerSingle_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportViewerSingleInstance, MethodCreateChildControls, parametersOfCreateChildControls, methodCreateChildControlsPrametersTypes);

            // Assert
            parametersOfCreateChildControls.ShouldBeNull();
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewerSingle_CreateChildControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportViewerSingleInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);

            // Assert
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewerSingle_CreateChildControls_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportViewerSingleInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderWebPart) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportViewerSingle_RenderWebPart_Method_Call_Internally(Type[] types)
        {
            var methodRenderWebPartPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportViewerSingleInstance, MethodRenderWebPart, Fixture, methodRenderWebPartPrametersTypes);
        }

        #endregion

        #region Method Call : (RenderWebPart) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewerSingle_RenderWebPart_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodRenderWebPartPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRenderWebPart = { output };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRenderWebPart, methodRenderWebPartPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportViewerSingleInstanceFixture, parametersOfRenderWebPart);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRenderWebPart.ShouldNotBeNull();
            parametersOfRenderWebPart.Length.ShouldBe(1);
            methodRenderWebPartPrametersTypes.Length.ShouldBe(1);
            methodRenderWebPartPrametersTypes.Length.ShouldBe(parametersOfRenderWebPart.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RenderWebPart) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewerSingle_RenderWebPart_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodRenderWebPartPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRenderWebPart = { output };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportViewerSingleInstance, MethodRenderWebPart, parametersOfRenderWebPart, methodRenderWebPartPrametersTypes);

            // Assert
            parametersOfRenderWebPart.ShouldNotBeNull();
            parametersOfRenderWebPart.Length.ShouldBe(1);
            methodRenderWebPartPrametersTypes.Length.ShouldBe(1);
            methodRenderWebPartPrametersTypes.Length.ShouldBe(parametersOfRenderWebPart.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderWebPart) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewerSingle_RenderWebPart_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRenderWebPart, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenderWebPart) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewerSingle_RenderWebPart_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenderWebPartPrametersTypes = new Type[] { typeof(HtmlTextWriter) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportViewerSingleInstance, MethodRenderWebPart, Fixture, methodRenderWebPartPrametersTypes);

            // Assert
            methodRenderWebPartPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderWebPart) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportViewerSingle_RenderWebPart_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenderWebPart, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportViewerSingleInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
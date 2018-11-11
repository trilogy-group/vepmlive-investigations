using System;
using System.Diagnostics.CodeAnalysis;
using System.Web.UI;
using System.Web.UI.WebControls;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts.SiteCollectionSetupWizard
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.SiteCollectionSetupWizard.SiteCollectionSetupWizard" />)
    ///     and namespace <see cref="EPMLiveWebParts.SiteCollectionSetupWizard"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class SiteCollectionSetupWizardTest : AbstractBaseSetupTypedTest<SiteCollectionSetupWizard>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SiteCollectionSetupWizard) Initializer

        private const string PropertyBorderStyle = "BorderStyle";
        private const string MethodCreateChildControls = "CreateChildControls";
        private const string MethodRender = "Render";
        private Type _siteCollectionSetupWizardInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private SiteCollectionSetupWizard _siteCollectionSetupWizardInstance;
        private SiteCollectionSetupWizard _siteCollectionSetupWizardInstanceFixture;

        #region General Initializer : Class (SiteCollectionSetupWizard) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SiteCollectionSetupWizard" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _siteCollectionSetupWizardInstanceType = typeof(SiteCollectionSetupWizard);
            _siteCollectionSetupWizardInstanceFixture = Create(true);
            _siteCollectionSetupWizardInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SiteCollectionSetupWizard)

        #region General Initializer : Class (SiteCollectionSetupWizard) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="SiteCollectionSetupWizard" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(MethodCreateChildControls, 0)]
        [TestCase(MethodRender, 0)]
        public void AUT_SiteCollectionSetupWizard_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_siteCollectionSetupWizardInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (SiteCollectionSetupWizard) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="SiteCollectionSetupWizard" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyBorderStyle)]
        public void AUT_SiteCollectionSetupWizard_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_siteCollectionSetupWizardInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="SiteCollectionSetupWizard" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_SiteCollectionSetupWizard_Is_Instance_Present_Test()
        {
            // Assert
            _siteCollectionSetupWizardInstanceType.ShouldNotBeNull();
            _siteCollectionSetupWizardInstance.ShouldNotBeNull();
            _siteCollectionSetupWizardInstanceFixture.ShouldNotBeNull();
            _siteCollectionSetupWizardInstance.ShouldBeAssignableTo<SiteCollectionSetupWizard>();
            _siteCollectionSetupWizardInstanceFixture.ShouldBeAssignableTo<SiteCollectionSetupWizard>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (SiteCollectionSetupWizard) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_SiteCollectionSetupWizard_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            SiteCollectionSetupWizard instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _siteCollectionSetupWizardInstanceType.ShouldNotBeNull();
            _siteCollectionSetupWizardInstance.ShouldNotBeNull();
            _siteCollectionSetupWizardInstanceFixture.ShouldNotBeNull();
            _siteCollectionSetupWizardInstance.ShouldBeAssignableTo<SiteCollectionSetupWizard>();
            _siteCollectionSetupWizardInstanceFixture.ShouldBeAssignableTo<SiteCollectionSetupWizard>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (SiteCollectionSetupWizard) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(BorderStyle) , PropertyBorderStyle)]
        public void AUT_SiteCollectionSetupWizard_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<SiteCollectionSetupWizard, T>(_siteCollectionSetupWizardInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (SiteCollectionSetupWizard) => Property (BorderStyle) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SiteCollectionSetupWizard_BorderStyle_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyBorderStyle);
            Action currentAction = () => propertyInfo.SetValue(_siteCollectionSetupWizardInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SiteCollectionSetupWizard) => Property (BorderStyle) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SiteCollectionSetupWizard_Public_Class_BorderStyle_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyBorderStyle);

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
        ///      Class (<see cref="SiteCollectionSetupWizard" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        [TestCase(MethodCreateChildControls)]
        [TestCase(MethodRender)]
        public void AUT_SiteCollectionSetupWizard_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<SiteCollectionSetupWizard>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SiteCollectionSetupWizard_CreateChildControls_Method_Call_Internally(Type[] types)
        {
            var methodCreateChildControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_siteCollectionSetupWizardInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_SiteCollectionSetupWizard_CreateChildControls_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, methodCreateChildControlsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_siteCollectionSetupWizardInstanceFixture, parametersOfCreateChildControls);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateChildControls.ShouldBeNull();
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_SiteCollectionSetupWizard_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_siteCollectionSetupWizardInstance, MethodCreateChildControls, parametersOfCreateChildControls, methodCreateChildControlsPrametersTypes);

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
        public void AUT_SiteCollectionSetupWizard_CreateChildControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_siteCollectionSetupWizardInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);

            // Assert
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_SiteCollectionSetupWizard_CreateChildControls_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_siteCollectionSetupWizardInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Render) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SiteCollectionSetupWizard_Render_Method_Call_Internally(Type[] types)
        {
            var methodRenderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_siteCollectionSetupWizardInstance, MethodRender, Fixture, methodRenderPrametersTypes);
        }

        #endregion

        #region Method Call : (Render) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_SiteCollectionSetupWizard_Render_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var writer = CreateType<HtmlTextWriter>();
            var methodRenderPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRender = { writer };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRender, methodRenderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_siteCollectionSetupWizardInstanceFixture, parametersOfRender);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRender.ShouldNotBeNull();
            parametersOfRender.Length.ShouldBe(1);
            methodRenderPrametersTypes.Length.ShouldBe(1);
            methodRenderPrametersTypes.Length.ShouldBe(parametersOfRender.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Render) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_SiteCollectionSetupWizard_Render_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var writer = CreateType<HtmlTextWriter>();
            var methodRenderPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRender = { writer };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_siteCollectionSetupWizardInstance, MethodRender, parametersOfRender, methodRenderPrametersTypes);

            // Assert
            parametersOfRender.ShouldNotBeNull();
            parametersOfRender.Length.ShouldBe(1);
            methodRenderPrametersTypes.Length.ShouldBe(1);
            methodRenderPrametersTypes.Length.ShouldBe(parametersOfRender.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Render) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_SiteCollectionSetupWizard_Render_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRender, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Render) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_SiteCollectionSetupWizard_Render_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenderPrametersTypes = new Type[] { typeof(HtmlTextWriter) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_siteCollectionSetupWizardInstance, MethodRender, Fixture, methodRenderPrametersTypes);

            // Assert
            methodRenderPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Render) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_SiteCollectionSetupWizard_Render_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRender, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_siteCollectionSetupWizardInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
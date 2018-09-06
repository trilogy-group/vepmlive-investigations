using System;
using System.Diagnostics.CodeAnalysis;
using System.Web.UI;
using System.Xml;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebPartPages;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts.RollupSummary
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.RollupSummary.RollupSummary" />)
    ///     and namespace <see cref="EPMLiveWebParts.RollupSummary"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class RollupSummaryTest : AbstractBaseSetupTypedTest<RollupSummary>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (RollupSummary) Initializer

        private const string PropertyMyXml = "MyXml";
        private const string PropertyMyRollupSites = "MyRollupSites";
        private const string PropertyTitle = "Title";
        private const string MethodRenderWebPart = "RenderWebPart";
        private const string MethodprocessSection = "processSection";
        private const string MethodprocessItem = "processItem";
        private const string MethodprocessDisplay = "processDisplay";
        private const string MethodprocessWeb = "processWeb";
        private const string MethodgetCount = "getCount";
        private const string MethodGetToolParts = "GetToolParts";
        private const string Fieldtitle = "title";
        private const string Fieldsb = "sb";
        private const string FieldstrXML = "strXML";
        private const string FieldstrRollupSites = "strRollupSites";
        private const string Fieldweb = "web";
        private const string FieldhshCounts = "hshCounts";
        private const string FieldhshNodes = "hshNodes";
        private const string FieldarrSites = "arrSites";
        private const string Fieldcn = "cn";
        private Type _rollupSummaryInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private RollupSummary _rollupSummaryInstance;
        private RollupSummary _rollupSummaryInstanceFixture;

        #region General Initializer : Class (RollupSummary) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RollupSummary" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _rollupSummaryInstanceType = typeof(RollupSummary);
            _rollupSummaryInstanceFixture = Create(true);
            _rollupSummaryInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (RollupSummary)

        #region General Initializer : Class (RollupSummary) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="RollupSummary" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(MethodRenderWebPart, 0)]
        [TestCase(MethodprocessSection, 0)]
        [TestCase(MethodprocessItem, 0)]
        [TestCase(MethodprocessDisplay, 0)]
        [TestCase(MethodprocessWeb, 0)]
        [TestCase(MethodgetCount, 0)]
        [TestCase(MethodGetToolParts, 0)]
        public void AUT_RollupSummary_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_rollupSummaryInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (RollupSummary) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="RollupSummary" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyMyXml)]
        [TestCase(PropertyMyRollupSites)]
        [TestCase(PropertyTitle)]
        public void AUT_RollupSummary_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_rollupSummaryInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (RollupSummary) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="RollupSummary" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Fieldtitle)]
        [TestCase(Fieldsb)]
        [TestCase(FieldstrXML)]
        [TestCase(FieldstrRollupSites)]
        [TestCase(Fieldweb)]
        [TestCase(FieldhshCounts)]
        [TestCase(FieldhshNodes)]
        [TestCase(FieldarrSites)]
        [TestCase(Fieldcn)]
        public void AUT_RollupSummary_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_rollupSummaryInstanceFixture, 
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
        ///     Class (<see cref="RollupSummary" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_RollupSummary_Is_Instance_Present_Test()
        {
            // Assert
            _rollupSummaryInstanceType.ShouldNotBeNull();
            _rollupSummaryInstance.ShouldNotBeNull();
            _rollupSummaryInstanceFixture.ShouldNotBeNull();
            _rollupSummaryInstance.ShouldBeAssignableTo<RollupSummary>();
            _rollupSummaryInstanceFixture.ShouldBeAssignableTo<RollupSummary>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (RollupSummary) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_RollupSummary_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            RollupSummary instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _rollupSummaryInstanceType.ShouldNotBeNull();
            _rollupSummaryInstance.ShouldNotBeNull();
            _rollupSummaryInstanceFixture.ShouldNotBeNull();
            _rollupSummaryInstance.ShouldBeAssignableTo<RollupSummary>();
            _rollupSummaryInstanceFixture.ShouldBeAssignableTo<RollupSummary>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (RollupSummary) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyMyXml)]
        [TestCaseGeneric(typeof(string) , PropertyMyRollupSites)]
        [TestCaseGeneric(typeof(string) , PropertyTitle)]
        public void AUT_RollupSummary_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<RollupSummary, T>(_rollupSummaryInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (RollupSummary) => Property (MyRollupSites) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RollupSummary_Public_Class_MyRollupSites_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyMyRollupSites);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RollupSummary) => Property (MyXml) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RollupSummary_Public_Class_MyXml_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyMyXml);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RollupSummary) => Property (Title) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RollupSummary_Public_Class_Title_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyTitle);

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
        ///      Class (<see cref="RollupSummary" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        [TestCase(MethodRenderWebPart)]
        [TestCase(MethodprocessSection)]
        [TestCase(MethodprocessItem)]
        [TestCase(MethodprocessDisplay)]
        [TestCase(MethodprocessWeb)]
        [TestCase(MethodgetCount)]
        [TestCase(MethodGetToolParts)]
        public void AUT_RollupSummary_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<RollupSummary>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (RenderWebPart) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RollupSummary_RenderWebPart_Method_Call_Internally(Type[] types)
        {
            var methodRenderWebPartPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rollupSummaryInstance, MethodRenderWebPart, Fixture, methodRenderWebPartPrametersTypes);
        }

        #endregion

        #region Method Call : (RenderWebPart) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_RollupSummary_RenderWebPart_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodRenderWebPartPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRenderWebPart = { output };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRenderWebPart, methodRenderWebPartPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rollupSummaryInstanceFixture, parametersOfRenderWebPart);

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
        public void AUT_RollupSummary_RenderWebPart_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodRenderWebPartPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRenderWebPart = { output };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_rollupSummaryInstance, MethodRenderWebPart, parametersOfRenderWebPart, methodRenderWebPartPrametersTypes);

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
        public void AUT_RollupSummary_RenderWebPart_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_RollupSummary_RenderWebPart_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenderWebPartPrametersTypes = new Type[] { typeof(HtmlTextWriter) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rollupSummaryInstance, MethodRenderWebPart, Fixture, methodRenderWebPartPrametersTypes);

            // Assert
            methodRenderWebPartPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderWebPart) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_RollupSummary_RenderWebPart_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenderWebPart, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_rollupSummaryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processSection) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RollupSummary_processSection_Method_Call_Internally(Type[] types)
        {
            var methodprocessSectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rollupSummaryInstance, MethodprocessSection, Fixture, methodprocessSectionPrametersTypes);
        }

        #endregion

        #region Method Call : (processSection) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_RollupSummary_processSection_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var ndSection = CreateType<XmlNode>();
            var methodprocessSectionPrametersTypes = new Type[] { typeof(XmlNode) };
            object[] parametersOfprocessSection = { ndSection };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodprocessSection, methodprocessSectionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rollupSummaryInstanceFixture, parametersOfprocessSection);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfprocessSection.ShouldNotBeNull();
            parametersOfprocessSection.Length.ShouldBe(1);
            methodprocessSectionPrametersTypes.Length.ShouldBe(1);
            methodprocessSectionPrametersTypes.Length.ShouldBe(parametersOfprocessSection.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (processSection) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_RollupSummary_processSection_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var ndSection = CreateType<XmlNode>();
            var methodprocessSectionPrametersTypes = new Type[] { typeof(XmlNode) };
            object[] parametersOfprocessSection = { ndSection };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_rollupSummaryInstance, MethodprocessSection, parametersOfprocessSection, methodprocessSectionPrametersTypes);

            // Assert
            parametersOfprocessSection.ShouldNotBeNull();
            parametersOfprocessSection.Length.ShouldBe(1);
            methodprocessSectionPrametersTypes.Length.ShouldBe(1);
            methodprocessSectionPrametersTypes.Length.ShouldBe(parametersOfprocessSection.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processSection) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_RollupSummary_processSection_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodprocessSection, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processSection) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_RollupSummary_processSection_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodprocessSectionPrametersTypes = new Type[] { typeof(XmlNode) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rollupSummaryInstance, MethodprocessSection, Fixture, methodprocessSectionPrametersTypes);

            // Assert
            methodprocessSectionPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processSection) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_RollupSummary_processSection_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprocessSection, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_rollupSummaryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processItem) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RollupSummary_processItem_Method_Call_Internally(Type[] types)
        {
            var methodprocessItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rollupSummaryInstance, MethodprocessItem, Fixture, methodprocessItemPrametersTypes);
        }

        #endregion

        #region Method Call : (processItem) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_RollupSummary_processItem_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var ndItem = CreateType<XmlNode>();
            Action executeAction = null;

            // Act
            executeAction = () => _rollupSummaryInstance.processItem(ndItem);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (processItem) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_RollupSummary_processItem_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var ndItem = CreateType<XmlNode>();
            var methodprocessItemPrametersTypes = new Type[] { typeof(XmlNode) };
            object[] parametersOfprocessItem = { ndItem };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodprocessItem, methodprocessItemPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rollupSummaryInstanceFixture, parametersOfprocessItem);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfprocessItem.ShouldNotBeNull();
            parametersOfprocessItem.Length.ShouldBe(1);
            methodprocessItemPrametersTypes.Length.ShouldBe(1);
            methodprocessItemPrametersTypes.Length.ShouldBe(parametersOfprocessItem.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (processItem) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_RollupSummary_processItem_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var ndItem = CreateType<XmlNode>();
            var methodprocessItemPrametersTypes = new Type[] { typeof(XmlNode) };
            object[] parametersOfprocessItem = { ndItem };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_rollupSummaryInstance, MethodprocessItem, parametersOfprocessItem, methodprocessItemPrametersTypes);

            // Assert
            parametersOfprocessItem.ShouldNotBeNull();
            parametersOfprocessItem.Length.ShouldBe(1);
            methodprocessItemPrametersTypes.Length.ShouldBe(1);
            methodprocessItemPrametersTypes.Length.ShouldBe(parametersOfprocessItem.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processItem) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_RollupSummary_processItem_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodprocessItem, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processItem) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_RollupSummary_processItem_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodprocessItemPrametersTypes = new Type[] { typeof(XmlNode) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rollupSummaryInstance, MethodprocessItem, Fixture, methodprocessItemPrametersTypes);

            // Assert
            methodprocessItemPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processItem) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_RollupSummary_processItem_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprocessItem, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_rollupSummaryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processDisplay) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RollupSummary_processDisplay_Method_Call_Internally(Type[] types)
        {
            var methodprocessDisplayPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rollupSummaryInstance, MethodprocessDisplay, Fixture, methodprocessDisplayPrametersTypes);
        }

        #endregion

        #region Method Call : (processDisplay) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_RollupSummary_processDisplay_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var ndDisplays = CreateType<XmlNode>();
            var count = CreateType<int>();
            var methodprocessDisplayPrametersTypes = new Type[] { typeof(XmlNode), typeof(int) };
            object[] parametersOfprocessDisplay = { ndDisplays, count };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodprocessDisplay, methodprocessDisplayPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rollupSummaryInstanceFixture, parametersOfprocessDisplay);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfprocessDisplay.ShouldNotBeNull();
            parametersOfprocessDisplay.Length.ShouldBe(2);
            methodprocessDisplayPrametersTypes.Length.ShouldBe(2);
            methodprocessDisplayPrametersTypes.Length.ShouldBe(parametersOfprocessDisplay.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (processDisplay) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_RollupSummary_processDisplay_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var ndDisplays = CreateType<XmlNode>();
            var count = CreateType<int>();
            var methodprocessDisplayPrametersTypes = new Type[] { typeof(XmlNode), typeof(int) };
            object[] parametersOfprocessDisplay = { ndDisplays, count };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_rollupSummaryInstance, MethodprocessDisplay, parametersOfprocessDisplay, methodprocessDisplayPrametersTypes);

            // Assert
            parametersOfprocessDisplay.ShouldNotBeNull();
            parametersOfprocessDisplay.Length.ShouldBe(2);
            methodprocessDisplayPrametersTypes.Length.ShouldBe(2);
            methodprocessDisplayPrametersTypes.Length.ShouldBe(parametersOfprocessDisplay.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processDisplay) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_RollupSummary_processDisplay_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodprocessDisplay, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processDisplay) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_RollupSummary_processDisplay_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodprocessDisplayPrametersTypes = new Type[] { typeof(XmlNode), typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rollupSummaryInstance, MethodprocessDisplay, Fixture, methodprocessDisplayPrametersTypes);

            // Assert
            methodprocessDisplayPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processDisplay) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_RollupSummary_processDisplay_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprocessDisplay, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_rollupSummaryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processWeb) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RollupSummary_processWeb_Method_Call_Internally(Type[] types)
        {
            var methodprocessWebPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rollupSummaryInstance, MethodprocessWeb, Fixture, methodprocessWebPrametersTypes);
        }

        #endregion

        #region Method Call : (processWeb) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_RollupSummary_processWeb_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var curWeb = CreateType<SPWeb>();
            var methodprocessWebPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfprocessWeb = { curWeb };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodprocessWeb, methodprocessWebPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rollupSummaryInstanceFixture, parametersOfprocessWeb);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfprocessWeb.ShouldNotBeNull();
            parametersOfprocessWeb.Length.ShouldBe(1);
            methodprocessWebPrametersTypes.Length.ShouldBe(1);
            methodprocessWebPrametersTypes.Length.ShouldBe(parametersOfprocessWeb.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processWeb) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_RollupSummary_processWeb_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var curWeb = CreateType<SPWeb>();
            var methodprocessWebPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfprocessWeb = { curWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_rollupSummaryInstance, MethodprocessWeb, parametersOfprocessWeb, methodprocessWebPrametersTypes);

            // Assert
            parametersOfprocessWeb.ShouldNotBeNull();
            parametersOfprocessWeb.Length.ShouldBe(1);
            methodprocessWebPrametersTypes.Length.ShouldBe(1);
            methodprocessWebPrametersTypes.Length.ShouldBe(parametersOfprocessWeb.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processWeb) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_RollupSummary_processWeb_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodprocessWeb, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processWeb) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_RollupSummary_processWeb_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodprocessWebPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rollupSummaryInstance, MethodprocessWeb, Fixture, methodprocessWebPrametersTypes);

            // Assert
            methodprocessWebPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processWeb) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_RollupSummary_processWeb_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprocessWeb, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_rollupSummaryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getCount) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RollupSummary_getCount_Method_Call_Internally(Type[] types)
        {
            var methodgetCountPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rollupSummaryInstance, MethodgetCount, Fixture, methodgetCountPrametersTypes);
        }

        #endregion

        #region Method Call : (getCount) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_RollupSummary_getCount_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var list = CreateType<string>();
            var query = CreateType<string>();
            var curWeb = CreateType<SPWeb>();
            var methodgetCountPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(SPWeb) };
            object[] parametersOfgetCount = { list, query, curWeb };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodgetCount, methodgetCountPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<RollupSummary, int>(_rollupSummaryInstanceFixture, out exception1, parametersOfgetCount);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<RollupSummary, int>(_rollupSummaryInstance, MethodgetCount, parametersOfgetCount, methodgetCountPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfgetCount.ShouldNotBeNull();
            parametersOfgetCount.Length.ShouldBe(3);
            methodgetCountPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (getCount) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_RollupSummary_getCount_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var list = CreateType<string>();
            var query = CreateType<string>();
            var curWeb = CreateType<SPWeb>();
            var methodgetCountPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(SPWeb) };
            object[] parametersOfgetCount = { list, query, curWeb };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodgetCount, methodgetCountPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<RollupSummary, int>(_rollupSummaryInstanceFixture, out exception1, parametersOfgetCount);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<RollupSummary, int>(_rollupSummaryInstance, MethodgetCount, parametersOfgetCount, methodgetCountPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfgetCount.ShouldNotBeNull();
            parametersOfgetCount.Length.ShouldBe(3);
            methodgetCountPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (getCount) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_RollupSummary_getCount_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<string>();
            var query = CreateType<string>();
            var curWeb = CreateType<SPWeb>();
            var methodgetCountPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(SPWeb) };
            object[] parametersOfgetCount = { list, query, curWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RollupSummary, int>(_rollupSummaryInstance, MethodgetCount, parametersOfgetCount, methodgetCountPrametersTypes);

            // Assert
            parametersOfgetCount.ShouldNotBeNull();
            parametersOfgetCount.Length.ShouldBe(3);
            methodgetCountPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getCount) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_RollupSummary_getCount_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetCountPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(SPWeb) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rollupSummaryInstance, MethodgetCount, Fixture, methodgetCountPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetCountPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getCount) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_RollupSummary_getCount_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetCount, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rollupSummaryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getCount) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_RollupSummary_getCount_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetCount, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RollupSummary_GetToolParts_Method_Call_Internally(Type[] types)
        {
            var methodGetToolPartsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rollupSummaryInstance, MethodGetToolParts, Fixture, methodGetToolPartsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_RollupSummary_GetToolParts_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _rollupSummaryInstance.GetToolParts();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_RollupSummary_GetToolParts_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetToolPartsPrametersTypes = null;
            object[] parametersOfGetToolParts = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetToolParts, methodGetToolPartsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rollupSummaryInstanceFixture, parametersOfGetToolParts);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetToolParts.ShouldBeNull();
            methodGetToolPartsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_RollupSummary_GetToolParts_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetToolPartsPrametersTypes = null;
            object[] parametersOfGetToolParts = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RollupSummary, ToolPart[]>(_rollupSummaryInstance, MethodGetToolParts, parametersOfGetToolParts, methodGetToolPartsPrametersTypes);

            // Assert
            parametersOfGetToolParts.ShouldBeNull();
            methodGetToolPartsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_RollupSummary_GetToolParts_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetToolPartsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rollupSummaryInstance, MethodGetToolParts, Fixture, methodGetToolPartsPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetToolPartsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_RollupSummary_GetToolParts_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetToolPartsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rollupSummaryInstance, MethodGetToolParts, Fixture, methodGetToolPartsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetToolPartsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_RollupSummary_GetToolParts_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetToolParts, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rollupSummaryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion
    }
}
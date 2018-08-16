using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.SalesforceMetadataService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.Layout" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class LayoutTest : AbstractBaseSetupTypedTest<Layout>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Layout) Initializer

        private const string PropertycustomButtons = "customButtons";
        private const string PropertycustomConsoleComponents = "customConsoleComponents";
        private const string PropertyemailDefault = "emailDefault";
        private const string PropertyemailDefaultSpecified = "emailDefaultSpecified";
        private const string PropertyexcludeButtons = "excludeButtons";
        private const string Propertyheaders = "headers";
        private const string PropertylayoutSections = "layoutSections";
        private const string PropertyminiLayout = "miniLayout";
        private const string PropertymultilineLayoutFields = "multilineLayoutFields";
        private const string PropertyrelatedLists = "relatedLists";
        private const string PropertyrelatedObjects = "relatedObjects";
        private const string PropertyrunAssignmentRulesDefault = "runAssignmentRulesDefault";
        private const string PropertyrunAssignmentRulesDefaultSpecified = "runAssignmentRulesDefaultSpecified";
        private const string PropertyshowEmailCheckbox = "showEmailCheckbox";
        private const string PropertyshowEmailCheckboxSpecified = "showEmailCheckboxSpecified";
        private const string PropertyshowHighlightsPanel = "showHighlightsPanel";
        private const string PropertyshowHighlightsPanelSpecified = "showHighlightsPanelSpecified";
        private const string PropertyshowInteractionLogPanel = "showInteractionLogPanel";
        private const string PropertyshowInteractionLogPanelSpecified = "showInteractionLogPanelSpecified";
        private const string PropertyshowKnowledgeComponent = "showKnowledgeComponent";
        private const string PropertyshowKnowledgeComponentSpecified = "showKnowledgeComponentSpecified";
        private const string PropertyshowRunAssignmentRulesCheckbox = "showRunAssignmentRulesCheckbox";
        private const string PropertyshowRunAssignmentRulesCheckboxSpecified = "showRunAssignmentRulesCheckboxSpecified";
        private const string PropertyshowSolutionSection = "showSolutionSection";
        private const string PropertyshowSolutionSectionSpecified = "showSolutionSectionSpecified";
        private const string PropertyshowSubmitAndAttachButton = "showSubmitAndAttachButton";
        private const string PropertyshowSubmitAndAttachButtonSpecified = "showSubmitAndAttachButtonSpecified";
        private const string PropertysummaryLayout = "summaryLayout";
        private const string FieldcustomButtonsField = "customButtonsField";
        private const string FieldcustomConsoleComponentsField = "customConsoleComponentsField";
        private const string FieldemailDefaultField = "emailDefaultField";
        private const string FieldemailDefaultFieldSpecified = "emailDefaultFieldSpecified";
        private const string FieldexcludeButtonsField = "excludeButtonsField";
        private const string FieldheadersField = "headersField";
        private const string FieldlayoutSectionsField = "layoutSectionsField";
        private const string FieldminiLayoutField = "miniLayoutField";
        private const string FieldmultilineLayoutFieldsField = "multilineLayoutFieldsField";
        private const string FieldrelatedListsField = "relatedListsField";
        private const string FieldrelatedObjectsField = "relatedObjectsField";
        private const string FieldrunAssignmentRulesDefaultField = "runAssignmentRulesDefaultField";
        private const string FieldrunAssignmentRulesDefaultFieldSpecified = "runAssignmentRulesDefaultFieldSpecified";
        private const string FieldshowEmailCheckboxField = "showEmailCheckboxField";
        private const string FieldshowEmailCheckboxFieldSpecified = "showEmailCheckboxFieldSpecified";
        private const string FieldshowHighlightsPanelField = "showHighlightsPanelField";
        private const string FieldshowHighlightsPanelFieldSpecified = "showHighlightsPanelFieldSpecified";
        private const string FieldshowInteractionLogPanelField = "showInteractionLogPanelField";
        private const string FieldshowInteractionLogPanelFieldSpecified = "showInteractionLogPanelFieldSpecified";
        private const string FieldshowKnowledgeComponentField = "showKnowledgeComponentField";
        private const string FieldshowKnowledgeComponentFieldSpecified = "showKnowledgeComponentFieldSpecified";
        private const string FieldshowRunAssignmentRulesCheckboxField = "showRunAssignmentRulesCheckboxField";
        private const string FieldshowRunAssignmentRulesCheckboxFieldSpecified = "showRunAssignmentRulesCheckboxFieldSpecified";
        private const string FieldshowSolutionSectionField = "showSolutionSectionField";
        private const string FieldshowSolutionSectionFieldSpecified = "showSolutionSectionFieldSpecified";
        private const string FieldshowSubmitAndAttachButtonField = "showSubmitAndAttachButtonField";
        private const string FieldshowSubmitAndAttachButtonFieldSpecified = "showSubmitAndAttachButtonFieldSpecified";
        private const string FieldsummaryLayoutField = "summaryLayoutField";
        private Type _layoutInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Layout _layoutInstance;
        private Layout _layoutInstanceFixture;

        #region General Initializer : Class (Layout) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Layout" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _layoutInstanceType = typeof(Layout);
            _layoutInstanceFixture = Create(true);
            _layoutInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Layout)

        #region General Initializer : Class (Layout) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Layout" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertycustomButtons)]
        [TestCase(PropertycustomConsoleComponents)]
        [TestCase(PropertyemailDefault)]
        [TestCase(PropertyemailDefaultSpecified)]
        [TestCase(PropertyexcludeButtons)]
        [TestCase(Propertyheaders)]
        [TestCase(PropertylayoutSections)]
        [TestCase(PropertyminiLayout)]
        [TestCase(PropertymultilineLayoutFields)]
        [TestCase(PropertyrelatedLists)]
        [TestCase(PropertyrelatedObjects)]
        [TestCase(PropertyrunAssignmentRulesDefault)]
        [TestCase(PropertyrunAssignmentRulesDefaultSpecified)]
        [TestCase(PropertyshowEmailCheckbox)]
        [TestCase(PropertyshowEmailCheckboxSpecified)]
        [TestCase(PropertyshowHighlightsPanel)]
        [TestCase(PropertyshowHighlightsPanelSpecified)]
        [TestCase(PropertyshowInteractionLogPanel)]
        [TestCase(PropertyshowInteractionLogPanelSpecified)]
        [TestCase(PropertyshowKnowledgeComponent)]
        [TestCase(PropertyshowKnowledgeComponentSpecified)]
        [TestCase(PropertyshowRunAssignmentRulesCheckbox)]
        [TestCase(PropertyshowRunAssignmentRulesCheckboxSpecified)]
        [TestCase(PropertyshowSolutionSection)]
        [TestCase(PropertyshowSolutionSectionSpecified)]
        [TestCase(PropertyshowSubmitAndAttachButton)]
        [TestCase(PropertyshowSubmitAndAttachButtonSpecified)]
        [TestCase(PropertysummaryLayout)]
        public void AUT_Layout_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_layoutInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Layout) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Layout" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcustomButtonsField)]
        [TestCase(FieldcustomConsoleComponentsField)]
        [TestCase(FieldemailDefaultField)]
        [TestCase(FieldemailDefaultFieldSpecified)]
        [TestCase(FieldexcludeButtonsField)]
        [TestCase(FieldheadersField)]
        [TestCase(FieldlayoutSectionsField)]
        [TestCase(FieldminiLayoutField)]
        [TestCase(FieldmultilineLayoutFieldsField)]
        [TestCase(FieldrelatedListsField)]
        [TestCase(FieldrelatedObjectsField)]
        [TestCase(FieldrunAssignmentRulesDefaultField)]
        [TestCase(FieldrunAssignmentRulesDefaultFieldSpecified)]
        [TestCase(FieldshowEmailCheckboxField)]
        [TestCase(FieldshowEmailCheckboxFieldSpecified)]
        [TestCase(FieldshowHighlightsPanelField)]
        [TestCase(FieldshowHighlightsPanelFieldSpecified)]
        [TestCase(FieldshowInteractionLogPanelField)]
        [TestCase(FieldshowInteractionLogPanelFieldSpecified)]
        [TestCase(FieldshowKnowledgeComponentField)]
        [TestCase(FieldshowKnowledgeComponentFieldSpecified)]
        [TestCase(FieldshowRunAssignmentRulesCheckboxField)]
        [TestCase(FieldshowRunAssignmentRulesCheckboxFieldSpecified)]
        [TestCase(FieldshowSolutionSectionField)]
        [TestCase(FieldshowSolutionSectionFieldSpecified)]
        [TestCase(FieldshowSubmitAndAttachButtonField)]
        [TestCase(FieldshowSubmitAndAttachButtonFieldSpecified)]
        [TestCase(FieldsummaryLayoutField)]
        public void AUT_Layout_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_layoutInstanceFixture, 
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
        ///     Class (<see cref="Layout" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_Layout_Is_Instance_Present_Test()
        {
            // Assert
            _layoutInstanceType.ShouldNotBeNull();
            _layoutInstance.ShouldNotBeNull();
            _layoutInstanceFixture.ShouldNotBeNull();
            _layoutInstance.ShouldBeAssignableTo<Layout>();
            _layoutInstanceFixture.ShouldBeAssignableTo<Layout>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Layout) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_Layout_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Layout instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _layoutInstanceType.ShouldNotBeNull();
            _layoutInstance.ShouldNotBeNull();
            _layoutInstanceFixture.ShouldNotBeNull();
            _layoutInstance.ShouldBeAssignableTo<Layout>();
            _layoutInstanceFixture.ShouldBeAssignableTo<Layout>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Layout) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string[]) , PropertycustomButtons)]
        [TestCaseGeneric(typeof(CustomConsoleComponents) , PropertycustomConsoleComponents)]
        [TestCaseGeneric(typeof(bool) , PropertyemailDefault)]
        [TestCaseGeneric(typeof(bool) , PropertyemailDefaultSpecified)]
        [TestCaseGeneric(typeof(string[]) , PropertyexcludeButtons)]
        [TestCaseGeneric(typeof(LayoutHeader[]) , Propertyheaders)]
        [TestCaseGeneric(typeof(LayoutSection[]) , PropertylayoutSections)]
        [TestCaseGeneric(typeof(MiniLayout) , PropertyminiLayout)]
        [TestCaseGeneric(typeof(string[]) , PropertymultilineLayoutFields)]
        [TestCaseGeneric(typeof(RelatedListItem[]) , PropertyrelatedLists)]
        [TestCaseGeneric(typeof(string[]) , PropertyrelatedObjects)]
        [TestCaseGeneric(typeof(bool) , PropertyrunAssignmentRulesDefault)]
        [TestCaseGeneric(typeof(bool) , PropertyrunAssignmentRulesDefaultSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyshowEmailCheckbox)]
        [TestCaseGeneric(typeof(bool) , PropertyshowEmailCheckboxSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyshowHighlightsPanel)]
        [TestCaseGeneric(typeof(bool) , PropertyshowHighlightsPanelSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyshowInteractionLogPanel)]
        [TestCaseGeneric(typeof(bool) , PropertyshowInteractionLogPanelSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyshowKnowledgeComponent)]
        [TestCaseGeneric(typeof(bool) , PropertyshowKnowledgeComponentSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyshowRunAssignmentRulesCheckbox)]
        [TestCaseGeneric(typeof(bool) , PropertyshowRunAssignmentRulesCheckboxSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyshowSolutionSection)]
        [TestCaseGeneric(typeof(bool) , PropertyshowSolutionSectionSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyshowSubmitAndAttachButton)]
        [TestCaseGeneric(typeof(bool) , PropertyshowSubmitAndAttachButtonSpecified)]
        [TestCaseGeneric(typeof(SummaryLayout) , PropertysummaryLayout)]
        public void AUT_Layout_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Layout, T>(_layoutInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Layout) => Property (customButtons) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Layout_customButtons_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycustomButtons);
            Action currentAction = () => propertyInfo.SetValue(_layoutInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Layout) => Property (customButtons) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Layout_Public_Class_customButtons_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycustomButtons);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Layout) => Property (customConsoleComponents) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Layout_customConsoleComponents_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycustomConsoleComponents);
            Action currentAction = () => propertyInfo.SetValue(_layoutInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Layout) => Property (customConsoleComponents) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Layout_Public_Class_customConsoleComponents_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycustomConsoleComponents);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Layout) => Property (emailDefault) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Layout_Public_Class_emailDefault_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyemailDefault);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Layout) => Property (emailDefaultSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Layout_Public_Class_emailDefaultSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyemailDefaultSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Layout) => Property (excludeButtons) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Layout_excludeButtons_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyexcludeButtons);
            Action currentAction = () => propertyInfo.SetValue(_layoutInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Layout) => Property (excludeButtons) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Layout_Public_Class_excludeButtons_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyexcludeButtons);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Layout) => Property (headers) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Layout_headers_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyheaders);
            Action currentAction = () => propertyInfo.SetValue(_layoutInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Layout) => Property (headers) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Layout_Public_Class_headers_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyheaders);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Layout) => Property (layoutSections) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Layout_layoutSections_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertylayoutSections);
            Action currentAction = () => propertyInfo.SetValue(_layoutInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Layout) => Property (layoutSections) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Layout_Public_Class_layoutSections_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylayoutSections);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Layout) => Property (miniLayout) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Layout_miniLayout_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyminiLayout);
            Action currentAction = () => propertyInfo.SetValue(_layoutInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Layout) => Property (miniLayout) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Layout_Public_Class_miniLayout_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyminiLayout);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Layout) => Property (multilineLayoutFields) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Layout_multilineLayoutFields_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertymultilineLayoutFields);
            Action currentAction = () => propertyInfo.SetValue(_layoutInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Layout) => Property (multilineLayoutFields) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Layout_Public_Class_multilineLayoutFields_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertymultilineLayoutFields);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Layout) => Property (relatedLists) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Layout_relatedLists_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyrelatedLists);
            Action currentAction = () => propertyInfo.SetValue(_layoutInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Layout) => Property (relatedLists) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Layout_Public_Class_relatedLists_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrelatedLists);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Layout) => Property (relatedObjects) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Layout_relatedObjects_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyrelatedObjects);
            Action currentAction = () => propertyInfo.SetValue(_layoutInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Layout) => Property (relatedObjects) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Layout_Public_Class_relatedObjects_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrelatedObjects);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Layout) => Property (runAssignmentRulesDefault) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Layout_Public_Class_runAssignmentRulesDefault_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrunAssignmentRulesDefault);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Layout) => Property (runAssignmentRulesDefaultSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Layout_Public_Class_runAssignmentRulesDefaultSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrunAssignmentRulesDefaultSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Layout) => Property (showEmailCheckbox) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Layout_Public_Class_showEmailCheckbox_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowEmailCheckbox);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Layout) => Property (showEmailCheckboxSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Layout_Public_Class_showEmailCheckboxSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowEmailCheckboxSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Layout) => Property (showHighlightsPanel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Layout_Public_Class_showHighlightsPanel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowHighlightsPanel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Layout) => Property (showHighlightsPanelSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Layout_Public_Class_showHighlightsPanelSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowHighlightsPanelSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Layout) => Property (showInteractionLogPanel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Layout_Public_Class_showInteractionLogPanel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowInteractionLogPanel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Layout) => Property (showInteractionLogPanelSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Layout_Public_Class_showInteractionLogPanelSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowInteractionLogPanelSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Layout) => Property (showKnowledgeComponent) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Layout_Public_Class_showKnowledgeComponent_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowKnowledgeComponent);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Layout) => Property (showKnowledgeComponentSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Layout_Public_Class_showKnowledgeComponentSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowKnowledgeComponentSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Layout) => Property (showRunAssignmentRulesCheckbox) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Layout_Public_Class_showRunAssignmentRulesCheckbox_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowRunAssignmentRulesCheckbox);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Layout) => Property (showRunAssignmentRulesCheckboxSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Layout_Public_Class_showRunAssignmentRulesCheckboxSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowRunAssignmentRulesCheckboxSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Layout) => Property (showSolutionSection) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Layout_Public_Class_showSolutionSection_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowSolutionSection);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Layout) => Property (showSolutionSectionSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Layout_Public_Class_showSolutionSectionSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowSolutionSectionSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Layout) => Property (showSubmitAndAttachButton) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Layout_Public_Class_showSubmitAndAttachButton_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowSubmitAndAttachButton);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Layout) => Property (showSubmitAndAttachButtonSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Layout_Public_Class_showSubmitAndAttachButtonSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowSubmitAndAttachButtonSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Layout) => Property (summaryLayout) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Layout_summaryLayout_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertysummaryLayout);
            Action currentAction = () => propertyInfo.SetValue(_layoutInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Layout) => Property (summaryLayout) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Layout_Public_Class_summaryLayout_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysummaryLayout);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #endregion

        #endregion
    }
}
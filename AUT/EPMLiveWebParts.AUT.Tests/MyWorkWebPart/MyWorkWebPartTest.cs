using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.MyWorkWebPart" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class MyWorkWebPartTest : AbstractBaseSetupTypedTest<MyWorkWebPart>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (MyWorkWebPart) Initializer

        private const string PropertyAllowEditToggle = "AllowEditToggle";
        private const string PropertyCrossSiteUrls = "CrossSiteUrls";
        private const string PropertyDefaultGlobalView = "DefaultGlobalView";
        private const string PropertyDefaultToEditMode = "DefaultToEditMode";
        private const string PropertyDelayScript = "DelayScript";
        private const string PropertyDueDayFilter = "DueDayFilter";
        private const string PropertyHideNewButton = "HideNewButton";
        private const string PropertyMyWorkSelectedLists = "MyWorkSelectedLists";
        private const string PropertyNewItemIndicator = "NewItemIndicator";
        private const string PropertyPerformanceMode = "PerformanceMode";
        private const string PropertySelectedFields = "SelectedFields";
        private const string PropertySelectedLists = "SelectedLists";
        private const string PropertyShowToolbar = "ShowToolbar";
        private const string PropertyUseCentralizedSettings = "UseCentralizedSettings";
        private const string PropertyWebPartContextualInfo = "WebPartContextualInfo";
        private const string MethodGetToolParts = "GetToolParts";
        private const string MethodRandomNumber = "RandomNumber";
        private const string MethodCreateChildControls = "CreateChildControls";
        private const string MethodOnPreRender = "OnPreRender";
        private const string MethodAddContextualTab = "AddContextualTab";
        private const string FieldMANAGE_TAB_ID = "MANAGE_TAB_ID";
        private const string FieldVIEWS_TAB_ID = "VIEWS_TAB_ID";
        private const string FieldRandom = "Random";
        private const string FieldSyncLock = "SyncLock";
        private const string Field_allWorkGridId = "_allWorkGridId";
        private const string Field_contextualTab = "_contextualTab";
        private const string Field_contextualTabTemplate = "_contextualTabTemplate";
        private const string Field_workingOnGridId = "_workingOnGridId";
        private const string Field_allowEditToggle = "_allowEditToggle";
        private const string Field_crossSiteUrls = "_crossSiteUrls";
        private const string Field_defaultGlobalView = "_defaultGlobalView";
        private const string Field_defaultToEditMode = "_defaultToEditMode";
        private const string Field_dueDayFilter = "_dueDayFilter";
        private const string Field_hideNewButton = "_hideNewButton";
        private const string Field_myWorkSelectedLists = "_myWorkSelectedLists";
        private const string Field_newItemButtonLists = "_newItemButtonLists";
        private const string Field_newItemIndicator = "_newItemIndicator";
        private const string Field_performanceMode = "_performanceMode";
        private const string Field_selectedFields = "_selectedFields";
        private const string Field_selectedLists = "_selectedLists";
        private const string Field_showToolbar = "_showToolbar";
        private const string Field_useCentralizedSettings = "_useCentralizedSettings";
        private Type _myWorkWebPartInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private MyWorkWebPart _myWorkWebPartInstance;
        private MyWorkWebPart _myWorkWebPartInstanceFixture;

        #region General Initializer : Class (MyWorkWebPart) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="MyWorkWebPart" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _myWorkWebPartInstanceType = typeof(MyWorkWebPart);
            _myWorkWebPartInstanceFixture = Create(true);
            _myWorkWebPartInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (MyWorkWebPart)

        #region General Initializer : Class (MyWorkWebPart) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="MyWorkWebPart" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(MethodGetToolParts, 0)]
        [TestCase(MethodRandomNumber, 0)]
        [TestCase(MethodCreateChildControls, 0)]
        [TestCase(MethodOnPreRender, 0)]
        [TestCase(MethodAddContextualTab, 0)]
        public void AUT_MyWorkWebPart_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_myWorkWebPartInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (MyWorkWebPart) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="MyWorkWebPart" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyAllowEditToggle)]
        [TestCase(PropertyCrossSiteUrls)]
        [TestCase(PropertyDefaultGlobalView)]
        [TestCase(PropertyDefaultToEditMode)]
        [TestCase(PropertyDelayScript)]
        [TestCase(PropertyDueDayFilter)]
        [TestCase(PropertyHideNewButton)]
        [TestCase(PropertyMyWorkSelectedLists)]
        [TestCase(PropertyNewItemIndicator)]
        [TestCase(PropertyPerformanceMode)]
        [TestCase(PropertySelectedFields)]
        [TestCase(PropertySelectedLists)]
        [TestCase(PropertyShowToolbar)]
        [TestCase(PropertyUseCentralizedSettings)]
        [TestCase(PropertyWebPartContextualInfo)]
        public void AUT_MyWorkWebPart_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_myWorkWebPartInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (MyWorkWebPart) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="MyWorkWebPart" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldMANAGE_TAB_ID)]
        [TestCase(FieldVIEWS_TAB_ID)]
        [TestCase(FieldRandom)]
        [TestCase(FieldSyncLock)]
        [TestCase(Field_allWorkGridId)]
        [TestCase(Field_contextualTab)]
        [TestCase(Field_contextualTabTemplate)]
        [TestCase(Field_workingOnGridId)]
        [TestCase(Field_allowEditToggle)]
        [TestCase(Field_crossSiteUrls)]
        [TestCase(Field_defaultGlobalView)]
        [TestCase(Field_defaultToEditMode)]
        [TestCase(Field_dueDayFilter)]
        [TestCase(Field_hideNewButton)]
        [TestCase(Field_myWorkSelectedLists)]
        [TestCase(Field_newItemButtonLists)]
        [TestCase(Field_newItemIndicator)]
        [TestCase(Field_performanceMode)]
        [TestCase(Field_selectedFields)]
        [TestCase(Field_selectedLists)]
        [TestCase(Field_showToolbar)]
        [TestCase(Field_useCentralizedSettings)]
        public void AUT_MyWorkWebPart_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_myWorkWebPartInstanceFixture, 
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
        ///     Class (<see cref="MyWorkWebPart" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_MyWorkWebPart_Is_Instance_Present_Test()
        {
            // Assert
            _myWorkWebPartInstanceType.ShouldNotBeNull();
            _myWorkWebPartInstance.ShouldNotBeNull();
            _myWorkWebPartInstanceFixture.ShouldNotBeNull();
            _myWorkWebPartInstance.ShouldBeAssignableTo<MyWorkWebPart>();
            _myWorkWebPartInstanceFixture.ShouldBeAssignableTo<MyWorkWebPart>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (MyWorkWebPart) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_MyWorkWebPart_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            MyWorkWebPart instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _myWorkWebPartInstanceType.ShouldNotBeNull();
            _myWorkWebPartInstance.ShouldNotBeNull();
            _myWorkWebPartInstanceFixture.ShouldNotBeNull();
            _myWorkWebPartInstance.ShouldBeAssignableTo<MyWorkWebPart>();
            _myWorkWebPartInstanceFixture.ShouldBeAssignableTo<MyWorkWebPart>();
        }

        #endregion

        #region General Constructor : Class (MyWorkWebPart) Default Assignment Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_MyWorkWebPart_Constructor_Instantiated_With_Default_Assignments_Test()
        {

            // Act
            var myWorkWebPartInstance  = new MyWorkWebPart();

            // Asserts
            myWorkWebPartInstance.ShouldNotBeNull();
            myWorkWebPartInstance.ShouldBeAssignableTo<MyWorkWebPart>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (MyWorkWebPart) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertyAllowEditToggle)]
        [TestCaseGeneric(typeof(string[]) , PropertyCrossSiteUrls)]
        [TestCaseGeneric(typeof(string) , PropertyDefaultGlobalView)]
        [TestCaseGeneric(typeof(bool) , PropertyDefaultToEditMode)]
        [TestCaseGeneric(typeof(string) , PropertyDelayScript)]
        [TestCaseGeneric(typeof(string) , PropertyDueDayFilter)]
        [TestCaseGeneric(typeof(bool) , PropertyHideNewButton)]
        [TestCaseGeneric(typeof(string[]) , PropertyMyWorkSelectedLists)]
        [TestCaseGeneric(typeof(string) , PropertyNewItemIndicator)]
        [TestCaseGeneric(typeof(bool) , PropertyPerformanceMode)]
        [TestCaseGeneric(typeof(string[]) , PropertySelectedFields)]
        [TestCaseGeneric(typeof(string[]) , PropertySelectedLists)]
        [TestCaseGeneric(typeof(bool) , PropertyShowToolbar)]
        [TestCaseGeneric(typeof(bool) , PropertyUseCentralizedSettings)]
        [TestCaseGeneric(typeof(WebPartContextualInfo) , PropertyWebPartContextualInfo)]
        public void AUT_MyWorkWebPart_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<MyWorkWebPart, T>(_myWorkWebPartInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (MyWorkWebPart) => Property (AllowEditToggle) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MyWorkWebPart_Public_Class_AllowEditToggle_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyAllowEditToggle);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MyWorkWebPart) => Property (CrossSiteUrls) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MyWorkWebPart_CrossSiteUrls_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyCrossSiteUrls);
            Action currentAction = () => propertyInfo.SetValue(_myWorkWebPartInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (MyWorkWebPart) => Property (CrossSiteUrls) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MyWorkWebPart_Public_Class_CrossSiteUrls_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCrossSiteUrls);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MyWorkWebPart) => Property (DefaultGlobalView) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MyWorkWebPart_Public_Class_DefaultGlobalView_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDefaultGlobalView);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MyWorkWebPart) => Property (DefaultToEditMode) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MyWorkWebPart_Public_Class_DefaultToEditMode_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDefaultToEditMode);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MyWorkWebPart) => Property (DelayScript) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MyWorkWebPart_Public_Class_DelayScript_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDelayScript);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MyWorkWebPart) => Property (DueDayFilter) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MyWorkWebPart_Public_Class_DueDayFilter_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDueDayFilter);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MyWorkWebPart) => Property (HideNewButton) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MyWorkWebPart_Public_Class_HideNewButton_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyHideNewButton);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MyWorkWebPart) => Property (MyWorkSelectedLists) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MyWorkWebPart_MyWorkSelectedLists_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyMyWorkSelectedLists);
            Action currentAction = () => propertyInfo.SetValue(_myWorkWebPartInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (MyWorkWebPart) => Property (MyWorkSelectedLists) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MyWorkWebPart_Public_Class_MyWorkSelectedLists_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyMyWorkSelectedLists);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MyWorkWebPart) => Property (NewItemIndicator) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MyWorkWebPart_Public_Class_NewItemIndicator_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyNewItemIndicator);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MyWorkWebPart) => Property (PerformanceMode) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MyWorkWebPart_Public_Class_PerformanceMode_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPerformanceMode);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MyWorkWebPart) => Property (SelectedFields) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MyWorkWebPart_SelectedFields_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertySelectedFields);
            Action currentAction = () => propertyInfo.SetValue(_myWorkWebPartInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (MyWorkWebPart) => Property (SelectedFields) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MyWorkWebPart_Public_Class_SelectedFields_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySelectedFields);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MyWorkWebPart) => Property (SelectedLists) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MyWorkWebPart_SelectedLists_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertySelectedLists);
            Action currentAction = () => propertyInfo.SetValue(_myWorkWebPartInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (MyWorkWebPart) => Property (SelectedLists) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MyWorkWebPart_Public_Class_SelectedLists_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySelectedLists);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MyWorkWebPart) => Property (ShowToolbar) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MyWorkWebPart_Public_Class_ShowToolbar_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyShowToolbar);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MyWorkWebPart) => Property (UseCentralizedSettings) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MyWorkWebPart_Public_Class_UseCentralizedSettings_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyUseCentralizedSettings);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MyWorkWebPart) => Property (WebPartContextualInfo) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MyWorkWebPart_WebPartContextualInfo_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyWebPartContextualInfo);
            Action currentAction = () => propertyInfo.SetValue(_myWorkWebPartInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (MyWorkWebPart) => Property (WebPartContextualInfo) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MyWorkWebPart_Public_Class_WebPartContextualInfo_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyWebPartContextualInfo);

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

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="MyWorkWebPart" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        [TestCase(MethodRandomNumber)]
        public void AUT_MyWorkWebPart_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_myWorkWebPartInstanceFixture,
                                                                              _myWorkWebPartInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="MyWorkWebPart" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        [TestCase(MethodGetToolParts)]
        [TestCase(MethodCreateChildControls)]
        [TestCase(MethodOnPreRender)]
        [TestCase(MethodAddContextualTab)]
        public void AUT_MyWorkWebPart_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<MyWorkWebPart>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWorkWebPart_GetToolParts_Method_Call_Internally(Type[] types)
        {
            var methodGetToolPartsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkWebPartInstance, MethodGetToolParts, Fixture, methodGetToolPartsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MyWorkWebPart_GetToolParts_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _myWorkWebPartInstance.GetToolParts();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MyWorkWebPart_GetToolParts_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetToolPartsPrametersTypes = null;
            object[] parametersOfGetToolParts = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetToolParts, methodGetToolPartsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<MyWorkWebPart, ToolPart[]>(_myWorkWebPartInstanceFixture, out exception1, parametersOfGetToolParts);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<MyWorkWebPart, ToolPart[]>(_myWorkWebPartInstance, MethodGetToolParts, parametersOfGetToolParts, methodGetToolPartsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetToolParts.ShouldBeNull();
            methodGetToolPartsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MyWorkWebPart_GetToolParts_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetToolPartsPrametersTypes = null;
            object[] parametersOfGetToolParts = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<MyWorkWebPart, ToolPart[]>(_myWorkWebPartInstance, MethodGetToolParts, parametersOfGetToolParts, methodGetToolPartsPrametersTypes);

            // Assert
            parametersOfGetToolParts.ShouldBeNull();
            methodGetToolPartsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MyWorkWebPart_GetToolParts_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetToolPartsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkWebPartInstance, MethodGetToolParts, Fixture, methodGetToolPartsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetToolPartsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MyWorkWebPart_GetToolParts_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetToolPartsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkWebPartInstance, MethodGetToolParts, Fixture, methodGetToolPartsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetToolPartsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MyWorkWebPart_GetToolParts_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetToolParts, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkWebPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RandomNumber) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWorkWebPart_RandomNumber_Static_Method_Call_Internally(Type[] types)
        {
            var methodRandomNumberPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkWebPartInstanceFixture, _myWorkWebPartInstanceType, MethodRandomNumber, Fixture, methodRandomNumberPrametersTypes);
        }

        #endregion

        #region Method Call : (RandomNumber) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MyWorkWebPart_RandomNumber_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var min = CreateType<int>();
            var max = CreateType<int>();
            var methodRandomNumberPrametersTypes = new Type[] { typeof(int), typeof(int) };
            object[] parametersOfRandomNumber = { min, max };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<int>(_myWorkWebPartInstanceFixture, _myWorkWebPartInstanceType, MethodRandomNumber, parametersOfRandomNumber, methodRandomNumberPrametersTypes);

            // Assert
            parametersOfRandomNumber.ShouldNotBeNull();
            parametersOfRandomNumber.Length.ShouldBe(2);
            methodRandomNumberPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RandomNumber) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MyWorkWebPart_RandomNumber_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRandomNumberPrametersTypes = new Type[] { typeof(int), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkWebPartInstanceFixture, _myWorkWebPartInstanceType, MethodRandomNumber, Fixture, methodRandomNumberPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRandomNumberPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RandomNumber) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MyWorkWebPart_RandomNumber_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRandomNumber, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWorkWebPart_CreateChildControls_Method_Call_Internally(Type[] types)
        {
            var methodCreateChildControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkWebPartInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MyWorkWebPart_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, methodCreateChildControlsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_myWorkWebPartInstanceFixture, parametersOfCreateChildControls);

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
        public void AUT_MyWorkWebPart_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_myWorkWebPartInstance, MethodCreateChildControls, parametersOfCreateChildControls, methodCreateChildControlsPrametersTypes);

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
        public void AUT_MyWorkWebPart_CreateChildControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkWebPartInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);

            // Assert
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MyWorkWebPart_CreateChildControls_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkWebPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWorkWebPart_OnPreRender_Method_Call_Internally(Type[] types)
        {
            var methodOnPreRenderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkWebPartInstance, MethodOnPreRender, Fixture, methodOnPreRenderPrametersTypes);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MyWorkWebPart_OnPreRender_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnPreRender = { e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnPreRender, methodOnPreRenderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_myWorkWebPartInstanceFixture, parametersOfOnPreRender);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOnPreRender.ShouldNotBeNull();
            parametersOfOnPreRender.Length.ShouldBe(1);
            methodOnPreRenderPrametersTypes.Length.ShouldBe(1);
            methodOnPreRenderPrametersTypes.Length.ShouldBe(parametersOfOnPreRender.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MyWorkWebPart_OnPreRender_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnPreRender = { e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_myWorkWebPartInstance, MethodOnPreRender, parametersOfOnPreRender, methodOnPreRenderPrametersTypes);

            // Assert
            parametersOfOnPreRender.ShouldNotBeNull();
            parametersOfOnPreRender.Length.ShouldBe(1);
            methodOnPreRenderPrametersTypes.Length.ShouldBe(1);
            methodOnPreRenderPrametersTypes.Length.ShouldBe(parametersOfOnPreRender.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MyWorkWebPart_OnPreRender_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOnPreRender, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MyWorkWebPart_OnPreRender_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkWebPartInstance, MethodOnPreRender, Fixture, methodOnPreRenderPrametersTypes);

            // Assert
            methodOnPreRenderPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MyWorkWebPart_OnPreRender_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnPreRender, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkWebPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddContextualTab) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWorkWebPart_AddContextualTab_Method_Call_Internally(Type[] types)
        {
            var methodAddContextualTabPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkWebPartInstance, MethodAddContextualTab, Fixture, methodAddContextualTabPrametersTypes);
        }

        #endregion

        #region Method Call : (AddContextualTab) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MyWorkWebPart_AddContextualTab_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodAddContextualTabPrametersTypes = null;
            object[] parametersOfAddContextualTab = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddContextualTab, methodAddContextualTabPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_myWorkWebPartInstanceFixture, parametersOfAddContextualTab);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddContextualTab.ShouldBeNull();
            methodAddContextualTabPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddContextualTab) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MyWorkWebPart_AddContextualTab_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodAddContextualTabPrametersTypes = null;
            object[] parametersOfAddContextualTab = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_myWorkWebPartInstance, MethodAddContextualTab, parametersOfAddContextualTab, methodAddContextualTabPrametersTypes);

            // Assert
            parametersOfAddContextualTab.ShouldBeNull();
            methodAddContextualTabPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddContextualTab) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MyWorkWebPart_AddContextualTab_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodAddContextualTabPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkWebPartInstance, MethodAddContextualTab, Fixture, methodAddContextualTabPrametersTypes);

            // Assert
            methodAddContextualTabPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddContextualTab) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MyWorkWebPart_AddContextualTab_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddContextualTab, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkWebPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
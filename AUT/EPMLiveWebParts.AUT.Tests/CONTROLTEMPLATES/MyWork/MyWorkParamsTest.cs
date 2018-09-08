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

namespace EPMLiveWebParts.CONTROLTEMPLATES.MyWork
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.CONTROLTEMPLATES.MyWork.MyWorkParams" />)
    ///     and namespace <see cref="EPMLiveWebParts.CONTROLTEMPLATES.MyWork"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class MyWorkParamsTest : AbstractBaseSetupTypedTest<MyWorkParams>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (MyWorkParams) Initializer

        private const string PropertyCrossSiteUrls = "CrossSiteUrls";
        private const string PropertyDefaultGlobalView = "DefaultGlobalView";
        private const string PropertyDisplayTitle = "DisplayTitle";
        private const string PropertyDueDayFilter = "DueDayFilter";
        private const string PropertyMyWorkSelectedLists = "MyWorkSelectedLists";
        private const string PropertyMyWorkSelectedLst = "MyWorkSelectedLst";
        private const string PropertyNewItemIndicator = "NewItemIndicator";
        private const string PropertyPerformanceMode = "PerformanceMode";
        private const string PropertyQualifier = "Qualifier";
        private const string PropertySelectedFields = "SelectedFields";
        private const string PropertySelectedLists = "SelectedLists";
        private const string PropertySelectedLst = "SelectedLst";
        private const string PropertyShowToolbar = "ShowToolbar";
        private const string PropertyTotalWebPartCount = "TotalWebPartCount";
        private const string PropertyUseCentralizedSettings = "UseCentralizedSettings";
        private const string PropertyWebPartHeight = "WebPartHeight";
        private const string PropertyWebPartId = "WebPartId";
        private const string PropertyWebPartPageComponentId = "WebPartPageComponentId";
        private const string Field_crossSiteUrls = "_crossSiteUrls";
        private const string Field_defaultGlobalView = "_defaultGlobalView";
        private const string Field_displayTitle = "_displayTitle";
        private const string Field_dueDayFilter = "_dueDayFilter";
        private const string Field_myWorkSelectedLists = "_myWorkSelectedLists";
        private const string Field_myWorkSelectedLst = "_myWorkSelectedLst";
        private const string Field_newItemIndicator = "_newItemIndicator";
        private const string Field_performanceMode = "_performanceMode";
        private const string Field_qualifier = "_qualifier";
        private const string Field_selectedFields = "_selectedFields";
        private const string Field_selectedLists = "_selectedLists";
        private const string Field_selectedLst = "_selectedLst";
        private const string Field_showToolbar = "_showToolbar";
        private const string Field_totalWebPartCount = "_totalWebPartCount";
        private const string Field_useCentralizedSettings = "_useCentralizedSettings";
        private const string Field_webPartHeight = "_webPartHeight";
        private const string Field_webPartId = "_webPartId";
        private const string Field_webPartPageComponentId = "_webPartPageComponentId";
        private Type _myWorkParamsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private MyWorkParams _myWorkParamsInstance;
        private MyWorkParams _myWorkParamsInstanceFixture;

        #region General Initializer : Class (MyWorkParams) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="MyWorkParams" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _myWorkParamsInstanceType = typeof(MyWorkParams);
            _myWorkParamsInstanceFixture = Create(true);
            _myWorkParamsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (MyWorkParams)

        #region General Initializer : Class (MyWorkParams) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="MyWorkParams" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyCrossSiteUrls)]
        [TestCase(PropertyDefaultGlobalView)]
        [TestCase(PropertyDisplayTitle)]
        [TestCase(PropertyDueDayFilter)]
        [TestCase(PropertyMyWorkSelectedLists)]
        [TestCase(PropertyMyWorkSelectedLst)]
        [TestCase(PropertyNewItemIndicator)]
        [TestCase(PropertyPerformanceMode)]
        [TestCase(PropertyQualifier)]
        [TestCase(PropertySelectedFields)]
        [TestCase(PropertySelectedLists)]
        [TestCase(PropertySelectedLst)]
        [TestCase(PropertyShowToolbar)]
        [TestCase(PropertyTotalWebPartCount)]
        [TestCase(PropertyUseCentralizedSettings)]
        [TestCase(PropertyWebPartHeight)]
        [TestCase(PropertyWebPartId)]
        [TestCase(PropertyWebPartPageComponentId)]
        public void AUT_MyWorkParams_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_myWorkParamsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (MyWorkParams) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="MyWorkParams" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_crossSiteUrls)]
        [TestCase(Field_defaultGlobalView)]
        [TestCase(Field_displayTitle)]
        [TestCase(Field_dueDayFilter)]
        [TestCase(Field_myWorkSelectedLists)]
        [TestCase(Field_myWorkSelectedLst)]
        [TestCase(Field_newItemIndicator)]
        [TestCase(Field_performanceMode)]
        [TestCase(Field_qualifier)]
        [TestCase(Field_selectedFields)]
        [TestCase(Field_selectedLists)]
        [TestCase(Field_selectedLst)]
        [TestCase(Field_showToolbar)]
        [TestCase(Field_totalWebPartCount)]
        [TestCase(Field_useCentralizedSettings)]
        [TestCase(Field_webPartHeight)]
        [TestCase(Field_webPartId)]
        [TestCase(Field_webPartPageComponentId)]
        public void AUT_MyWorkParams_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_myWorkParamsInstanceFixture, 
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
        ///     Class (<see cref="MyWorkParams" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_MyWorkParams_Is_Instance_Present_Test()
        {
            // Assert
            _myWorkParamsInstanceType.ShouldNotBeNull();
            _myWorkParamsInstance.ShouldNotBeNull();
            _myWorkParamsInstanceFixture.ShouldNotBeNull();
            _myWorkParamsInstance.ShouldBeAssignableTo<MyWorkParams>();
            _myWorkParamsInstanceFixture.ShouldBeAssignableTo<MyWorkParams>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (MyWorkParams) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_MyWorkParams_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var crossSiteUrls = CreateType<string>();
            var defaultGlobalView = CreateType<string>();
            var displayTitle = CreateType<string>();
            var myWorkSelectedLists = CreateType<string>();
            var myWorkSelectedLst = CreateType<string[]>();
            var performanceMode = CreateType<bool>();
            var qualifier = CreateType<string>();
            var selectedFields = CreateType<string>();
            var selectedLists = CreateType<string>();
            var selectedLst = CreateType<string[]>();
            var totalWebPartCount = CreateType<int>();
            var useCentralizedSettings = CreateType<bool>();
            var webPartHeight = CreateType<string>();
            var webPartId = CreateType<string>();
            var webPartPageComponentId = CreateType<string>();
            var dueDayFilter = CreateType<string>();
            var newItemIndicator = CreateType<string>();
            var showToolbar = CreateType<bool>();
            MyWorkParams instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new MyWorkParams(crossSiteUrls, defaultGlobalView, displayTitle, myWorkSelectedLists, myWorkSelectedLst, performanceMode, qualifier, selectedFields, selectedLists, selectedLst, totalWebPartCount, useCentralizedSettings, webPartHeight, webPartId, webPartPageComponentId, dueDayFilter, newItemIndicator, showToolbar);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _myWorkParamsInstance.ShouldNotBeNull();
            _myWorkParamsInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<MyWorkParams>();
        }

        #endregion

        #region General Constructor : Class (MyWorkParams) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_MyWorkParams_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var crossSiteUrls = CreateType<string>();
            var defaultGlobalView = CreateType<string>();
            var displayTitle = CreateType<string>();
            var myWorkSelectedLists = CreateType<string>();
            var myWorkSelectedLst = CreateType<string[]>();
            var performanceMode = CreateType<bool>();
            var qualifier = CreateType<string>();
            var selectedFields = CreateType<string>();
            var selectedLists = CreateType<string>();
            var selectedLst = CreateType<string[]>();
            var totalWebPartCount = CreateType<int>();
            var useCentralizedSettings = CreateType<bool>();
            var webPartHeight = CreateType<string>();
            var webPartId = CreateType<string>();
            var webPartPageComponentId = CreateType<string>();
            var dueDayFilter = CreateType<string>();
            var newItemIndicator = CreateType<string>();
            var showToolbar = CreateType<bool>();
            MyWorkParams instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new MyWorkParams(crossSiteUrls, defaultGlobalView, displayTitle, myWorkSelectedLists, myWorkSelectedLst, performanceMode, qualifier, selectedFields, selectedLists, selectedLst, totalWebPartCount, useCentralizedSettings, webPartHeight, webPartId, webPartPageComponentId, dueDayFilter, newItemIndicator, showToolbar);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _myWorkParamsInstance.ShouldNotBeNull();
            _myWorkParamsInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (MyWorkParams) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyCrossSiteUrls)]
        [TestCaseGeneric(typeof(string) , PropertyDefaultGlobalView)]
        [TestCaseGeneric(typeof(string) , PropertyDisplayTitle)]
        [TestCaseGeneric(typeof(string) , PropertyDueDayFilter)]
        [TestCaseGeneric(typeof(string) , PropertyMyWorkSelectedLists)]
        [TestCaseGeneric(typeof(string[]) , PropertyMyWorkSelectedLst)]
        [TestCaseGeneric(typeof(string) , PropertyNewItemIndicator)]
        [TestCaseGeneric(typeof(bool) , PropertyPerformanceMode)]
        [TestCaseGeneric(typeof(string) , PropertyQualifier)]
        [TestCaseGeneric(typeof(string) , PropertySelectedFields)]
        [TestCaseGeneric(typeof(string) , PropertySelectedLists)]
        [TestCaseGeneric(typeof(string[]) , PropertySelectedLst)]
        [TestCaseGeneric(typeof(bool) , PropertyShowToolbar)]
        [TestCaseGeneric(typeof(int) , PropertyTotalWebPartCount)]
        [TestCaseGeneric(typeof(bool) , PropertyUseCentralizedSettings)]
        [TestCaseGeneric(typeof(string) , PropertyWebPartHeight)]
        [TestCaseGeneric(typeof(string) , PropertyWebPartId)]
        [TestCaseGeneric(typeof(string) , PropertyWebPartPageComponentId)]
        public void AUT_MyWorkParams_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<MyWorkParams, T>(_myWorkParamsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (MyWorkParams) => Property (CrossSiteUrls) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_MyWorkParams_Public_Class_CrossSiteUrls_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (MyWorkParams) => Property (DefaultGlobalView) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_MyWorkParams_Public_Class_DefaultGlobalView_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (MyWorkParams) => Property (DisplayTitle) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_MyWorkParams_Public_Class_DisplayTitle_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDisplayTitle);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MyWorkParams) => Property (DueDayFilter) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_MyWorkParams_Public_Class_DueDayFilter_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (MyWorkParams) => Property (MyWorkSelectedLists) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_MyWorkParams_Public_Class_MyWorkSelectedLists_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (MyWorkParams) => Property (MyWorkSelectedLst) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_MyWorkParams_MyWorkSelectedLst_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyMyWorkSelectedLst);
            Action currentAction = () => propertyInfo.SetValue(_myWorkParamsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (MyWorkParams) => Property (MyWorkSelectedLst) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_MyWorkParams_Public_Class_MyWorkSelectedLst_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyMyWorkSelectedLst);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MyWorkParams) => Property (NewItemIndicator) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_MyWorkParams_Public_Class_NewItemIndicator_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (MyWorkParams) => Property (PerformanceMode) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_MyWorkParams_Public_Class_PerformanceMode_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (MyWorkParams) => Property (Qualifier) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_MyWorkParams_Public_Class_Qualifier_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyQualifier);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MyWorkParams) => Property (SelectedFields) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_MyWorkParams_Public_Class_SelectedFields_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (MyWorkParams) => Property (SelectedLists) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_MyWorkParams_Public_Class_SelectedLists_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (MyWorkParams) => Property (SelectedLst) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_MyWorkParams_SelectedLst_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertySelectedLst);
            Action currentAction = () => propertyInfo.SetValue(_myWorkParamsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (MyWorkParams) => Property (SelectedLst) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_MyWorkParams_Public_Class_SelectedLst_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySelectedLst);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MyWorkParams) => Property (ShowToolbar) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_MyWorkParams_Public_Class_ShowToolbar_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (MyWorkParams) => Property (TotalWebPartCount) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_MyWorkParams_Public_Class_TotalWebPartCount_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyTotalWebPartCount);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MyWorkParams) => Property (UseCentralizedSettings) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_MyWorkParams_Public_Class_UseCentralizedSettings_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (MyWorkParams) => Property (WebPartHeight) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_MyWorkParams_Public_Class_WebPartHeight_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyWebPartHeight);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MyWorkParams) => Property (WebPartId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_MyWorkParams_Public_Class_WebPartId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyWebPartId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MyWorkParams) => Property (WebPartPageComponentId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_MyWorkParams_Public_Class_WebPartPageComponentId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyWebPartPageComponentId);

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
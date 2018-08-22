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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.CallCenterSection" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CallCenterSectionTest : AbstractBaseSetupTypedTest<CallCenterSection>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CallCenterSection) Initializer

        private const string Propertyitems = "items";
        private const string Propertylabel = "label";
        private const string Propertyname = "name";
        private const string FielditemsField = "itemsField";
        private const string FieldlabelField = "labelField";
        private const string FieldnameField = "nameField";
        private Type _callCenterSectionInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CallCenterSection _callCenterSectionInstance;
        private CallCenterSection _callCenterSectionInstanceFixture;

        #region General Initializer : Class (CallCenterSection) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CallCenterSection" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _callCenterSectionInstanceType = typeof(CallCenterSection);
            _callCenterSectionInstanceFixture = Create(true);
            _callCenterSectionInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CallCenterSection)

        #region General Initializer : Class (CallCenterSection) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CallCenterSection" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyitems)]
        [TestCase(Propertylabel)]
        [TestCase(Propertyname)]
        public void AUT_CallCenterSection_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_callCenterSectionInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CallCenterSection) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CallCenterSection" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielditemsField)]
        [TestCase(FieldlabelField)]
        [TestCase(FieldnameField)]
        public void AUT_CallCenterSection_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_callCenterSectionInstanceFixture, 
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
        ///     Class (<see cref="CallCenterSection" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_CallCenterSection_Is_Instance_Present_Test()
        {
            // Assert
            _callCenterSectionInstanceType.ShouldNotBeNull();
            _callCenterSectionInstance.ShouldNotBeNull();
            _callCenterSectionInstanceFixture.ShouldNotBeNull();
            _callCenterSectionInstance.ShouldBeAssignableTo<CallCenterSection>();
            _callCenterSectionInstanceFixture.ShouldBeAssignableTo<CallCenterSection>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CallCenterSection) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_CallCenterSection_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CallCenterSection instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _callCenterSectionInstanceType.ShouldNotBeNull();
            _callCenterSectionInstance.ShouldNotBeNull();
            _callCenterSectionInstanceFixture.ShouldNotBeNull();
            _callCenterSectionInstance.ShouldBeAssignableTo<CallCenterSection>();
            _callCenterSectionInstanceFixture.ShouldBeAssignableTo<CallCenterSection>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CallCenterSection) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(CallCenterItem[]) , Propertyitems)]
        [TestCaseGeneric(typeof(string) , Propertylabel)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        public void AUT_CallCenterSection_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CallCenterSection, T>(_callCenterSectionInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (CallCenterSection) => Property (items) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CallCenterSection_items_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyitems);
            Action currentAction = () => propertyInfo.SetValue(_callCenterSectionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CallCenterSection) => Property (items) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CallCenterSection_Public_Class_items_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyitems);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CallCenterSection) => Property (label) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CallCenterSection_Public_Class_label_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertylabel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CallCenterSection) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CallCenterSection_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyname);

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
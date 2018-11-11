using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.SalesforceMetadataService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.CallCenterItem" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CallCenterItemTest : AbstractBaseSetupTypedTest<CallCenterItem>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CallCenterItem) Initializer

        private const string Propertylabel = "label";
        private const string Propertyname = "name";
        private const string Propertyvalue = "value";
        private const string FieldlabelField = "labelField";
        private const string FieldnameField = "nameField";
        private const string FieldvalueField = "valueField";
        private Type _callCenterItemInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CallCenterItem _callCenterItemInstance;
        private CallCenterItem _callCenterItemInstanceFixture;

        #region General Initializer : Class (CallCenterItem) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CallCenterItem" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _callCenterItemInstanceType = typeof(CallCenterItem);
            _callCenterItemInstanceFixture = Create(true);
            _callCenterItemInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CallCenterItem)

        #region General Initializer : Class (CallCenterItem) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CallCenterItem" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertylabel)]
        [TestCase(Propertyname)]
        [TestCase(Propertyvalue)]
        public void AUT_CallCenterItem_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_callCenterItemInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CallCenterItem) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CallCenterItem" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldlabelField)]
        [TestCase(FieldnameField)]
        [TestCase(FieldvalueField)]
        public void AUT_CallCenterItem_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_callCenterItemInstanceFixture, 
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
        ///     Class (<see cref="CallCenterItem" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_CallCenterItem_Is_Instance_Present_Test()
        {
            // Assert
            _callCenterItemInstanceType.ShouldNotBeNull();
            _callCenterItemInstance.ShouldNotBeNull();
            _callCenterItemInstanceFixture.ShouldNotBeNull();
            _callCenterItemInstance.ShouldBeAssignableTo<CallCenterItem>();
            _callCenterItemInstanceFixture.ShouldBeAssignableTo<CallCenterItem>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CallCenterItem) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_CallCenterItem_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CallCenterItem instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _callCenterItemInstanceType.ShouldNotBeNull();
            _callCenterItemInstance.ShouldNotBeNull();
            _callCenterItemInstanceFixture.ShouldNotBeNull();
            _callCenterItemInstance.ShouldBeAssignableTo<CallCenterItem>();
            _callCenterItemInstanceFixture.ShouldBeAssignableTo<CallCenterItem>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CallCenterItem) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertylabel)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        [TestCaseGeneric(typeof(string) , Propertyvalue)]
        public void AUT_CallCenterItem_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CallCenterItem, T>(_callCenterItemInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (CallCenterItem) => Property (label) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CallCenterItem_Public_Class_label_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CallCenterItem) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CallCenterItem_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CallCenterItem) => Property (value) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CallCenterItem_Public_Class_value_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyvalue);

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
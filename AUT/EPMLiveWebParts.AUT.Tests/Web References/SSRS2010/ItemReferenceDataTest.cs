using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveWebParts.SSRS2010
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.SSRS2010.ItemReferenceData" />)
    ///     and namespace <see cref="EPMLiveWebParts.SSRS2010"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ItemReferenceDataTest : AbstractBaseSetupTypedTest<ItemReferenceData>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ItemReferenceData) Initializer

        private const string PropertyName = "Name";
        private const string PropertyReference = "Reference";
        private const string PropertyReferenceType = "ReferenceType";
        private const string FieldnameField = "nameField";
        private const string FieldreferenceField = "referenceField";
        private const string FieldreferenceTypeField = "referenceTypeField";
        private Type _itemReferenceDataInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ItemReferenceData _itemReferenceDataInstance;
        private ItemReferenceData _itemReferenceDataInstanceFixture;

        #region General Initializer : Class (ItemReferenceData) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ItemReferenceData" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _itemReferenceDataInstanceType = typeof(ItemReferenceData);
            _itemReferenceDataInstanceFixture = Create(true);
            _itemReferenceDataInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ItemReferenceData)

        #region General Initializer : Class (ItemReferenceData) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ItemReferenceData" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyName)]
        [TestCase(PropertyReference)]
        [TestCase(PropertyReferenceType)]
        public void AUT_ItemReferenceData_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_itemReferenceDataInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ItemReferenceData) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ItemReferenceData" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldnameField)]
        [TestCase(FieldreferenceField)]
        [TestCase(FieldreferenceTypeField)]
        public void AUT_ItemReferenceData_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_itemReferenceDataInstanceFixture, 
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
        ///     Class (<see cref="ItemReferenceData" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ItemReferenceData_Is_Instance_Present_Test()
        {
            // Assert
            _itemReferenceDataInstanceType.ShouldNotBeNull();
            _itemReferenceDataInstance.ShouldNotBeNull();
            _itemReferenceDataInstanceFixture.ShouldNotBeNull();
            _itemReferenceDataInstance.ShouldBeAssignableTo<ItemReferenceData>();
            _itemReferenceDataInstanceFixture.ShouldBeAssignableTo<ItemReferenceData>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ItemReferenceData) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ItemReferenceData_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ItemReferenceData instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _itemReferenceDataInstanceType.ShouldNotBeNull();
            _itemReferenceDataInstance.ShouldNotBeNull();
            _itemReferenceDataInstanceFixture.ShouldNotBeNull();
            _itemReferenceDataInstance.ShouldBeAssignableTo<ItemReferenceData>();
            _itemReferenceDataInstanceFixture.ShouldBeAssignableTo<ItemReferenceData>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ItemReferenceData) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyName)]
        [TestCaseGeneric(typeof(string) , PropertyReference)]
        [TestCaseGeneric(typeof(string) , PropertyReferenceType)]
        public void AUT_ItemReferenceData_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ItemReferenceData, T>(_itemReferenceDataInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ItemReferenceData) => Property (Name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ItemReferenceData_Public_Class_Name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ItemReferenceData) => Property (Reference) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ItemReferenceData_Public_Class_Reference_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyReference);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ItemReferenceData) => Property (ReferenceType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ItemReferenceData_Public_Class_ReferenceType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyReferenceType);

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
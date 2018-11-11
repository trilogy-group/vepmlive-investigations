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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.SSRS2010.ItemReference" />)
    ///     and namespace <see cref="EPMLiveWebParts.SSRS2010"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ItemReferenceTest : AbstractBaseSetupTypedTest<ItemReference>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ItemReference) Initializer

        private const string PropertyName = "Name";
        private const string PropertyReference = "Reference";
        private const string FieldnameField = "nameField";
        private const string FieldreferenceField = "referenceField";
        private Type _itemReferenceInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ItemReference _itemReferenceInstance;
        private ItemReference _itemReferenceInstanceFixture;

        #region General Initializer : Class (ItemReference) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ItemReference" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _itemReferenceInstanceType = typeof(ItemReference);
            _itemReferenceInstanceFixture = Create(true);
            _itemReferenceInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ItemReference)

        #region General Initializer : Class (ItemReference) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ItemReference" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyName)]
        [TestCase(PropertyReference)]
        public void AUT_ItemReference_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_itemReferenceInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ItemReference) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ItemReference" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldnameField)]
        [TestCase(FieldreferenceField)]
        public void AUT_ItemReference_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_itemReferenceInstanceFixture, 
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
        ///     Class (<see cref="ItemReference" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ItemReference_Is_Instance_Present_Test()
        {
            // Assert
            _itemReferenceInstanceType.ShouldNotBeNull();
            _itemReferenceInstance.ShouldNotBeNull();
            _itemReferenceInstanceFixture.ShouldNotBeNull();
            _itemReferenceInstance.ShouldBeAssignableTo<ItemReference>();
            _itemReferenceInstanceFixture.ShouldBeAssignableTo<ItemReference>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ItemReference) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ItemReference_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ItemReference instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _itemReferenceInstanceType.ShouldNotBeNull();
            _itemReferenceInstance.ShouldNotBeNull();
            _itemReferenceInstanceFixture.ShouldNotBeNull();
            _itemReferenceInstance.ShouldBeAssignableTo<ItemReference>();
            _itemReferenceInstanceFixture.ShouldBeAssignableTo<ItemReference>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ItemReference) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyName)]
        [TestCaseGeneric(typeof(string) , PropertyReference)]
        public void AUT_ItemReference_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ItemReference, T>(_itemReferenceInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ItemReference) => Property (Name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ItemReference_Public_Class_Name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ItemReference) => Property (Reference) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ItemReference_Public_Class_Reference_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #endregion

        #endregion
    }
}
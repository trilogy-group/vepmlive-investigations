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

namespace EPMLiveWebParts.SSRS2010
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.SSRS2010.ItemHistorySnapshot" />)
    ///     and namespace <see cref="EPMLiveWebParts.SSRS2010"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ItemHistorySnapshotTest : AbstractBaseSetupTypedTest<ItemHistorySnapshot>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ItemHistorySnapshot) Initializer

        private const string PropertyHistoryID = "HistoryID";
        private const string PropertyCreationDate = "CreationDate";
        private const string PropertySize = "Size";
        private const string FieldhistoryIDField = "historyIDField";
        private const string FieldcreationDateField = "creationDateField";
        private const string FieldsizeField = "sizeField";
        private Type _itemHistorySnapshotInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ItemHistorySnapshot _itemHistorySnapshotInstance;
        private ItemHistorySnapshot _itemHistorySnapshotInstanceFixture;

        #region General Initializer : Class (ItemHistorySnapshot) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ItemHistorySnapshot" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _itemHistorySnapshotInstanceType = typeof(ItemHistorySnapshot);
            _itemHistorySnapshotInstanceFixture = Create(true);
            _itemHistorySnapshotInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ItemHistorySnapshot)

        #region General Initializer : Class (ItemHistorySnapshot) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ItemHistorySnapshot" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyHistoryID)]
        [TestCase(PropertyCreationDate)]
        [TestCase(PropertySize)]
        public void AUT_ItemHistorySnapshot_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_itemHistorySnapshotInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ItemHistorySnapshot) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ItemHistorySnapshot" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldhistoryIDField)]
        [TestCase(FieldcreationDateField)]
        [TestCase(FieldsizeField)]
        public void AUT_ItemHistorySnapshot_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_itemHistorySnapshotInstanceFixture, 
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
        ///     Class (<see cref="ItemHistorySnapshot" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ItemHistorySnapshot_Is_Instance_Present_Test()
        {
            // Assert
            _itemHistorySnapshotInstanceType.ShouldNotBeNull();
            _itemHistorySnapshotInstance.ShouldNotBeNull();
            _itemHistorySnapshotInstanceFixture.ShouldNotBeNull();
            _itemHistorySnapshotInstance.ShouldBeAssignableTo<ItemHistorySnapshot>();
            _itemHistorySnapshotInstanceFixture.ShouldBeAssignableTo<ItemHistorySnapshot>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ItemHistorySnapshot) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ItemHistorySnapshot_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ItemHistorySnapshot instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _itemHistorySnapshotInstanceType.ShouldNotBeNull();
            _itemHistorySnapshotInstance.ShouldNotBeNull();
            _itemHistorySnapshotInstanceFixture.ShouldNotBeNull();
            _itemHistorySnapshotInstance.ShouldBeAssignableTo<ItemHistorySnapshot>();
            _itemHistorySnapshotInstanceFixture.ShouldBeAssignableTo<ItemHistorySnapshot>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ItemHistorySnapshot) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyHistoryID)]
        [TestCaseGeneric(typeof(System.DateTime) , PropertyCreationDate)]
        [TestCaseGeneric(typeof(int) , PropertySize)]
        public void AUT_ItemHistorySnapshot_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ItemHistorySnapshot, T>(_itemHistorySnapshotInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ItemHistorySnapshot) => Property (CreationDate) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ItemHistorySnapshot_CreationDate_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyCreationDate);
            Action currentAction = () => propertyInfo.SetValue(_itemHistorySnapshotInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ItemHistorySnapshot) => Property (CreationDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ItemHistorySnapshot_Public_Class_CreationDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCreationDate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ItemHistorySnapshot) => Property (HistoryID) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ItemHistorySnapshot_Public_Class_HistoryID_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyHistoryID);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ItemHistorySnapshot) => Property (Size) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ItemHistorySnapshot_Public_Class_Size_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySize);

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
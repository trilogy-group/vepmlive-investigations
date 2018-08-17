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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.LayoutColumn" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class LayoutColumnTest : AbstractBaseSetupTypedTest<LayoutColumn>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (LayoutColumn) Initializer

        private const string PropertylayoutItems = "layoutItems";
        private const string Propertyreserved = "reserved";
        private const string FieldlayoutItemsField = "layoutItemsField";
        private const string FieldreservedField = "reservedField";
        private Type _layoutColumnInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private LayoutColumn _layoutColumnInstance;
        private LayoutColumn _layoutColumnInstanceFixture;

        #region General Initializer : Class (LayoutColumn) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="LayoutColumn" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _layoutColumnInstanceType = typeof(LayoutColumn);
            _layoutColumnInstanceFixture = Create(true);
            _layoutColumnInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (LayoutColumn)

        #region General Initializer : Class (LayoutColumn) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="LayoutColumn" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertylayoutItems)]
        [TestCase(Propertyreserved)]
        public void AUT_LayoutColumn_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_layoutColumnInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (LayoutColumn) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="LayoutColumn" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldlayoutItemsField)]
        [TestCase(FieldreservedField)]
        public void AUT_LayoutColumn_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_layoutColumnInstanceFixture, 
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
        ///     Class (<see cref="LayoutColumn" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_LayoutColumn_Is_Instance_Present_Test()
        {
            // Assert
            _layoutColumnInstanceType.ShouldNotBeNull();
            _layoutColumnInstance.ShouldNotBeNull();
            _layoutColumnInstanceFixture.ShouldNotBeNull();
            _layoutColumnInstance.ShouldBeAssignableTo<LayoutColumn>();
            _layoutColumnInstanceFixture.ShouldBeAssignableTo<LayoutColumn>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (LayoutColumn) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_LayoutColumn_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            LayoutColumn instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _layoutColumnInstanceType.ShouldNotBeNull();
            _layoutColumnInstance.ShouldNotBeNull();
            _layoutColumnInstanceFixture.ShouldNotBeNull();
            _layoutColumnInstance.ShouldBeAssignableTo<LayoutColumn>();
            _layoutColumnInstanceFixture.ShouldBeAssignableTo<LayoutColumn>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (LayoutColumn) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(LayoutItem[]) , PropertylayoutItems)]
        [TestCaseGeneric(typeof(string) , Propertyreserved)]
        public void AUT_LayoutColumn_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<LayoutColumn, T>(_layoutColumnInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (LayoutColumn) => Property (layoutItems) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LayoutColumn_layoutItems_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertylayoutItems);
            Action currentAction = () => propertyInfo.SetValue(_layoutColumnInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (LayoutColumn) => Property (layoutItems) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LayoutColumn_Public_Class_layoutItems_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylayoutItems);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LayoutColumn) => Property (reserved) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LayoutColumn_Public_Class_reserved_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyreserved);

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
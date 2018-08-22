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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.MiniLayout" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class MiniLayoutTest : AbstractBaseSetupTypedTest<MiniLayout>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (MiniLayout) Initializer

        private const string Propertyfields = "fields";
        private const string PropertyrelatedLists = "relatedLists";
        private const string FieldfieldsField = "fieldsField";
        private const string FieldrelatedListsField = "relatedListsField";
        private Type _miniLayoutInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private MiniLayout _miniLayoutInstance;
        private MiniLayout _miniLayoutInstanceFixture;

        #region General Initializer : Class (MiniLayout) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="MiniLayout" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _miniLayoutInstanceType = typeof(MiniLayout);
            _miniLayoutInstanceFixture = Create(true);
            _miniLayoutInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (MiniLayout)

        #region General Initializer : Class (MiniLayout) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="MiniLayout" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyfields)]
        [TestCase(PropertyrelatedLists)]
        public void AUT_MiniLayout_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_miniLayoutInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (MiniLayout) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="MiniLayout" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldfieldsField)]
        [TestCase(FieldrelatedListsField)]
        public void AUT_MiniLayout_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_miniLayoutInstanceFixture, 
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
        ///     Class (<see cref="MiniLayout" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_MiniLayout_Is_Instance_Present_Test()
        {
            // Assert
            _miniLayoutInstanceType.ShouldNotBeNull();
            _miniLayoutInstance.ShouldNotBeNull();
            _miniLayoutInstanceFixture.ShouldNotBeNull();
            _miniLayoutInstance.ShouldBeAssignableTo<MiniLayout>();
            _miniLayoutInstanceFixture.ShouldBeAssignableTo<MiniLayout>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (MiniLayout) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_MiniLayout_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            MiniLayout instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _miniLayoutInstanceType.ShouldNotBeNull();
            _miniLayoutInstance.ShouldNotBeNull();
            _miniLayoutInstanceFixture.ShouldNotBeNull();
            _miniLayoutInstance.ShouldBeAssignableTo<MiniLayout>();
            _miniLayoutInstanceFixture.ShouldBeAssignableTo<MiniLayout>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (MiniLayout) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string[]) , Propertyfields)]
        [TestCaseGeneric(typeof(RelatedListItem[]) , PropertyrelatedLists)]
        public void AUT_MiniLayout_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<MiniLayout, T>(_miniLayoutInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (MiniLayout) => Property (fields) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MiniLayout_fields_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyfields);
            Action currentAction = () => propertyInfo.SetValue(_miniLayoutInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (MiniLayout) => Property (fields) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MiniLayout_Public_Class_fields_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyfields);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MiniLayout) => Property (relatedLists) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MiniLayout_relatedLists_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyrelatedLists);
            Action currentAction = () => propertyInfo.SetValue(_miniLayoutInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (MiniLayout) => Property (relatedLists) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MiniLayout_Public_Class_relatedLists_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #endregion

        #endregion
    }
}
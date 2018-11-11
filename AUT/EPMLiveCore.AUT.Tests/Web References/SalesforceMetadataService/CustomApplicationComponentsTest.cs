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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.CustomApplicationComponents" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CustomApplicationComponentsTest : AbstractBaseSetupTypedTest<CustomApplicationComponents>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CustomApplicationComponents) Initializer

        private const string Propertyalignment = "alignment";
        private const string PropertycustomApplicationComponent = "customApplicationComponent";
        private const string FieldalignmentField = "alignmentField";
        private const string FieldcustomApplicationComponentField = "customApplicationComponentField";
        private Type _customApplicationComponentsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CustomApplicationComponents _customApplicationComponentsInstance;
        private CustomApplicationComponents _customApplicationComponentsInstanceFixture;

        #region General Initializer : Class (CustomApplicationComponents) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CustomApplicationComponents" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _customApplicationComponentsInstanceType = typeof(CustomApplicationComponents);
            _customApplicationComponentsInstanceFixture = Create(true);
            _customApplicationComponentsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CustomApplicationComponents)

        #region General Initializer : Class (CustomApplicationComponents) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomApplicationComponents" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyalignment)]
        [TestCase(PropertycustomApplicationComponent)]
        public void AUT_CustomApplicationComponents_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_customApplicationComponentsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CustomApplicationComponents) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomApplicationComponents" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldalignmentField)]
        [TestCase(FieldcustomApplicationComponentField)]
        public void AUT_CustomApplicationComponents_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_customApplicationComponentsInstanceFixture, 
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
        ///     Class (<see cref="CustomApplicationComponents" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_CustomApplicationComponents_Is_Instance_Present_Test()
        {
            // Assert
            _customApplicationComponentsInstanceType.ShouldNotBeNull();
            _customApplicationComponentsInstance.ShouldNotBeNull();
            _customApplicationComponentsInstanceFixture.ShouldNotBeNull();
            _customApplicationComponentsInstance.ShouldBeAssignableTo<CustomApplicationComponents>();
            _customApplicationComponentsInstanceFixture.ShouldBeAssignableTo<CustomApplicationComponents>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CustomApplicationComponents) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_CustomApplicationComponents_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CustomApplicationComponents instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _customApplicationComponentsInstanceType.ShouldNotBeNull();
            _customApplicationComponentsInstance.ShouldNotBeNull();
            _customApplicationComponentsInstanceFixture.ShouldNotBeNull();
            _customApplicationComponentsInstance.ShouldBeAssignableTo<CustomApplicationComponents>();
            _customApplicationComponentsInstanceFixture.ShouldBeAssignableTo<CustomApplicationComponents>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CustomApplicationComponents) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertyalignment)]
        [TestCaseGeneric(typeof(string[]) , PropertycustomApplicationComponent)]
        public void AUT_CustomApplicationComponents_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CustomApplicationComponents, T>(_customApplicationComponentsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (CustomApplicationComponents) => Property (alignment) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomApplicationComponents_Public_Class_alignment_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyalignment);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomApplicationComponents) => Property (customApplicationComponent) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomApplicationComponents_customApplicationComponent_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycustomApplicationComponent);
            Action currentAction = () => propertyInfo.SetValue(_customApplicationComponentsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomApplicationComponents) => Property (customApplicationComponent) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomApplicationComponents_Public_Class_customApplicationComponent_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycustomApplicationComponent);

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
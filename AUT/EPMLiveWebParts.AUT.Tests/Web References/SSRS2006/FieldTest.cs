using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveWebParts.SSRS2006
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.SSRS2006.Field" />)
    ///     and namespace <see cref="EPMLiveWebParts.SSRS2006"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class FieldTest : AbstractBaseSetupTypedTest<Field>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Field) Initializer

        private const string PropertyAlias = "Alias";
        private const string PropertyName = "Name";
        private const string FieldaliasField = "aliasField";
        private const string FieldnameField = "nameField";
        private Type _fieldInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Field _fieldInstance;
        private Field _fieldInstanceFixture;

        #region General Initializer : Class (Field) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Field" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _fieldInstanceType = typeof(Field);
            _fieldInstanceFixture = Create(true);
            _fieldInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Field)

        #region General Initializer : Class (Field) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Field" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyAlias)]
        [TestCase(PropertyName)]
        public void AUT_Field_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_fieldInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Field) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Field" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldaliasField)]
        [TestCase(FieldnameField)]
        public void AUT_Field_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_fieldInstanceFixture, 
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
        ///     Class (<see cref="Field" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_Field_Is_Instance_Present_Test()
        {
            // Assert
            _fieldInstanceType.ShouldNotBeNull();
            _fieldInstance.ShouldNotBeNull();
            _fieldInstanceFixture.ShouldNotBeNull();
            _fieldInstance.ShouldBeAssignableTo<Field>();
            _fieldInstanceFixture.ShouldBeAssignableTo<Field>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Field) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_Field_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Field instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _fieldInstanceType.ShouldNotBeNull();
            _fieldInstance.ShouldNotBeNull();
            _fieldInstanceFixture.ShouldNotBeNull();
            _fieldInstance.ShouldBeAssignableTo<Field>();
            _fieldInstanceFixture.ShouldBeAssignableTo<Field>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Field) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyAlias)]
        [TestCaseGeneric(typeof(string) , PropertyName)]
        public void AUT_Field_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Field, T>(_fieldInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (Alias) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_Alias_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyAlias);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (Name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_Name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #endregion

        #endregion
    }
}
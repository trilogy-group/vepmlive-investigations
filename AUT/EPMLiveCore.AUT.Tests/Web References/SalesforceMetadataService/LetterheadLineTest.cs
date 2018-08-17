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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.LetterheadLine" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class LetterheadLineTest : AbstractBaseSetupTypedTest<LetterheadLine>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (LetterheadLine) Initializer

        private const string Propertycolor = "color";
        private const string Propertyheight = "height";
        private const string FieldcolorField = "colorField";
        private const string FieldheightField = "heightField";
        private Type _letterheadLineInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private LetterheadLine _letterheadLineInstance;
        private LetterheadLine _letterheadLineInstanceFixture;

        #region General Initializer : Class (LetterheadLine) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="LetterheadLine" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _letterheadLineInstanceType = typeof(LetterheadLine);
            _letterheadLineInstanceFixture = Create(true);
            _letterheadLineInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (LetterheadLine)

        #region General Initializer : Class (LetterheadLine) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="LetterheadLine" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertycolor)]
        [TestCase(Propertyheight)]
        public void AUT_LetterheadLine_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_letterheadLineInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (LetterheadLine) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="LetterheadLine" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcolorField)]
        [TestCase(FieldheightField)]
        public void AUT_LetterheadLine_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_letterheadLineInstanceFixture, 
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
        ///     Class (<see cref="LetterheadLine" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_LetterheadLine_Is_Instance_Present_Test()
        {
            // Assert
            _letterheadLineInstanceType.ShouldNotBeNull();
            _letterheadLineInstance.ShouldNotBeNull();
            _letterheadLineInstanceFixture.ShouldNotBeNull();
            _letterheadLineInstance.ShouldBeAssignableTo<LetterheadLine>();
            _letterheadLineInstanceFixture.ShouldBeAssignableTo<LetterheadLine>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (LetterheadLine) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_LetterheadLine_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            LetterheadLine instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _letterheadLineInstanceType.ShouldNotBeNull();
            _letterheadLineInstance.ShouldNotBeNull();
            _letterheadLineInstanceFixture.ShouldNotBeNull();
            _letterheadLineInstance.ShouldBeAssignableTo<LetterheadLine>();
            _letterheadLineInstanceFixture.ShouldBeAssignableTo<LetterheadLine>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (LetterheadLine) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertycolor)]
        [TestCaseGeneric(typeof(int) , Propertyheight)]
        public void AUT_LetterheadLine_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<LetterheadLine, T>(_letterheadLineInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (LetterheadLine) => Property (color) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LetterheadLine_Public_Class_color_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertycolor);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LetterheadLine) => Property (height) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LetterheadLine_Public_Class_height_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyheight);

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
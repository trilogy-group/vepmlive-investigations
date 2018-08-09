using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.Infrastructure
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Infrastructure.GridView" />)
    ///     and namespace <see cref="EPMLiveCore.Infrastructure"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class GridViewTest : AbstractBaseSetupTypedTest<GridView>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (GridView) Initializer

        private const string PropertyId = "Id";
        private const string PropertyVersion = "Version";
        private const string FieldDefinition = "Definition";
        private const string Field_id = "_id";
        private Type _gridViewInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private GridView _gridViewInstance;
        private GridView _gridViewInstanceFixture;

        #region General Initializer : Class (GridView) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="GridView" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _gridViewInstanceType = typeof(GridView);
            _gridViewInstanceFixture = Create(true);
            _gridViewInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (GridView)

        #region General Initializer : Class (GridView) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="GridView" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyId)]
        [TestCase(PropertyVersion)]
        public void AUT_GridView_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_gridViewInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (GridView) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="GridView" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldDefinition)]
        [TestCase(Field_id)]
        public void AUT_GridView_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_gridViewInstanceFixture, 
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
        ///     Class (<see cref="GridView" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_GridView_Is_Instance_Present_Test()
        {
            // Assert
            _gridViewInstanceType.ShouldNotBeNull();
            _gridViewInstance.ShouldNotBeNull();
            _gridViewInstanceFixture.ShouldNotBeNull();
            _gridViewInstance.ShouldBeAssignableTo<GridView>();
            _gridViewInstanceFixture.ShouldBeAssignableTo<GridView>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (GridView) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_GridView_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            GridView instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _gridViewInstanceType.ShouldNotBeNull();
            _gridViewInstance.ShouldNotBeNull();
            _gridViewInstanceFixture.ShouldNotBeNull();
            _gridViewInstance.ShouldBeAssignableTo<GridView>();
            _gridViewInstanceFixture.ShouldBeAssignableTo<GridView>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (GridView) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyId)]
        [TestCaseGeneric(typeof(int) , PropertyVersion)]
        public void AUT_GridView_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<GridView, T>(_gridViewInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (GridView) => Property (Id) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GridView_Public_Class_Id_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridView) => Property (Version) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GridView_Public_Class_Version_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyVersion);

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
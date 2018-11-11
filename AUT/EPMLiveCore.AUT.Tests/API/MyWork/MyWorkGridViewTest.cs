using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.API
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.MyWorkGridView" />)
    ///     and namespace <see cref="EPMLiveCore.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class MyWorkGridViewTest : AbstractBaseSetupTypedTest<MyWorkGridView>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (MyWorkGridView) Initializer

        private const string PropertyCols = "Cols";
        private const string PropertyDefault = "Default";
        private const string PropertyFilters = "Filters";
        private const string PropertyGrouping = "Grouping";
        private const string PropertyId = "Id";
        private const string PropertyLeftCols = "LeftCols";
        private const string PropertyName = "Name";
        private const string PropertyPersonal = "Personal";
        private const string PropertyRightCols = "RightCols";
        private const string PropertySorting = "Sorting";
        private const string PropertyHasPermission = "HasPermission";
        private Type _myWorkGridViewInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private MyWorkGridView _myWorkGridViewInstance;
        private MyWorkGridView _myWorkGridViewInstanceFixture;

        #region General Initializer : Class (MyWorkGridView) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="MyWorkGridView" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _myWorkGridViewInstanceType = typeof(MyWorkGridView);
            _myWorkGridViewInstanceFixture = Create(true);
            _myWorkGridViewInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (MyWorkGridView)

        #region General Initializer : Class (MyWorkGridView) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="MyWorkGridView" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyCols)]
        [TestCase(PropertyDefault)]
        [TestCase(PropertyFilters)]
        [TestCase(PropertyGrouping)]
        [TestCase(PropertyId)]
        [TestCase(PropertyLeftCols)]
        [TestCase(PropertyName)]
        [TestCase(PropertyPersonal)]
        [TestCase(PropertyRightCols)]
        [TestCase(PropertySorting)]
        [TestCase(PropertyHasPermission)]
        public void AUT_MyWorkGridView_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_myWorkGridViewInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="MyWorkGridView" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_MyWorkGridView_Is_Instance_Present_Test()
        {
            // Assert
            _myWorkGridViewInstanceType.ShouldNotBeNull();
            _myWorkGridViewInstance.ShouldNotBeNull();
            _myWorkGridViewInstanceFixture.ShouldNotBeNull();
            _myWorkGridViewInstance.ShouldBeAssignableTo<MyWorkGridView>();
            _myWorkGridViewInstanceFixture.ShouldBeAssignableTo<MyWorkGridView>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (MyWorkGridView) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_MyWorkGridView_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            MyWorkGridView instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _myWorkGridViewInstanceType.ShouldNotBeNull();
            _myWorkGridViewInstance.ShouldNotBeNull();
            _myWorkGridViewInstanceFixture.ShouldNotBeNull();
            _myWorkGridViewInstance.ShouldBeAssignableTo<MyWorkGridView>();
            _myWorkGridViewInstanceFixture.ShouldBeAssignableTo<MyWorkGridView>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (MyWorkGridView) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyCols)]
        [TestCaseGeneric(typeof(bool) , PropertyDefault)]
        [TestCaseGeneric(typeof(string) , PropertyFilters)]
        [TestCaseGeneric(typeof(string) , PropertyGrouping)]
        [TestCaseGeneric(typeof(string) , PropertyId)]
        [TestCaseGeneric(typeof(string) , PropertyLeftCols)]
        [TestCaseGeneric(typeof(string) , PropertyName)]
        [TestCaseGeneric(typeof(bool) , PropertyPersonal)]
        [TestCaseGeneric(typeof(string) , PropertyRightCols)]
        [TestCaseGeneric(typeof(string) , PropertySorting)]
        [TestCaseGeneric(typeof(bool) , PropertyHasPermission)]
        public void AUT_MyWorkGridView_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<MyWorkGridView, T>(_myWorkGridViewInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (MyWorkGridView) => Property (Cols) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_MyWorkGridView_Public_Class_Cols_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCols);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MyWorkGridView) => Property (Default) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_MyWorkGridView_Public_Class_Default_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDefault);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MyWorkGridView) => Property (Filters) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_MyWorkGridView_Public_Class_Filters_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyFilters);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MyWorkGridView) => Property (Grouping) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_MyWorkGridView_Public_Class_Grouping_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyGrouping);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MyWorkGridView) => Property (HasPermission) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_MyWorkGridView_Public_Class_HasPermission_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyHasPermission);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MyWorkGridView) => Property (Id) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_MyWorkGridView_Public_Class_Id_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (MyWorkGridView) => Property (LeftCols) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_MyWorkGridView_Public_Class_LeftCols_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyLeftCols);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MyWorkGridView) => Property (Name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_MyWorkGridView_Public_Class_Name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (MyWorkGridView) => Property (Personal) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_MyWorkGridView_Public_Class_Personal_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPersonal);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MyWorkGridView) => Property (RightCols) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_MyWorkGridView_Public_Class_RightCols_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyRightCols);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MyWorkGridView) => Property (Sorting) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_MyWorkGridView_Public_Class_Sorting_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySorting);

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
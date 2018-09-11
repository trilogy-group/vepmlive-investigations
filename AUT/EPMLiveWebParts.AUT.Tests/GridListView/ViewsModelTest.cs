using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveWebParts
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.ViewsModel" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ViewsModelTest : AbstractBaseSetupTypedTest<ViewsModel>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ViewsModel) Initializer

        private const string PropertyTitle = "Title";
        private const string PropertyServerRelativeUrl = "ServerRelativeUrl";
        private Type _viewsModelInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ViewsModel _viewsModelInstance;
        private ViewsModel _viewsModelInstanceFixture;

        #region General Initializer : Class (ViewsModel) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ViewsModel" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _viewsModelInstanceType = typeof(ViewsModel);
            _viewsModelInstanceFixture = Create(true);
            _viewsModelInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ViewsModel)

        #region General Initializer : Class (ViewsModel) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ViewsModel" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyTitle)]
        [TestCase(PropertyServerRelativeUrl)]
        public void AUT_ViewsModel_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_viewsModelInstanceFixture,
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
        ///     Class (<see cref="ViewsModel" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ViewsModel_Is_Instance_Present_Test()
        {
            // Assert
            _viewsModelInstanceType.ShouldNotBeNull();
            _viewsModelInstance.ShouldNotBeNull();
            _viewsModelInstanceFixture.ShouldNotBeNull();
            _viewsModelInstance.ShouldBeAssignableTo<ViewsModel>();
            _viewsModelInstanceFixture.ShouldBeAssignableTo<ViewsModel>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ViewsModel) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ViewsModel_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ViewsModel instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _viewsModelInstanceType.ShouldNotBeNull();
            _viewsModelInstance.ShouldNotBeNull();
            _viewsModelInstanceFixture.ShouldNotBeNull();
            _viewsModelInstance.ShouldBeAssignableTo<ViewsModel>();
            _viewsModelInstanceFixture.ShouldBeAssignableTo<ViewsModel>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ViewsModel) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyTitle)]
        [TestCaseGeneric(typeof(string) , PropertyServerRelativeUrl)]
        public void AUT_ViewsModel_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ViewsModel, T>(_viewsModelInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ViewsModel) => Property (ServerRelativeUrl) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ViewsModel_Public_Class_ServerRelativeUrl_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyServerRelativeUrl);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ViewsModel) => Property (Title) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ViewsModel_Public_Class_Title_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyTitle);

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
using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.ListDefinitions
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.ListDefinitions.ListAttribute" />)
    ///     and namespace <see cref="EPMLiveCore.ListDefinitions"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ListAttributeTest : AbstractBaseSetupTypedTest<ListAttribute>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ListAttribute) Initializer

        private const string PropertyName = "Name";
        private Type _listAttributeInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ListAttribute _listAttributeInstance;
        private ListAttribute _listAttributeInstanceFixture;

        #region General Initializer : Class (ListAttribute) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ListAttribute" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _listAttributeInstanceType = typeof(ListAttribute);
            _listAttributeInstanceFixture = Create(true);
            _listAttributeInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ListAttribute)

        #region General Initializer : Class (ListAttribute) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ListAttribute" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyName)]
        public void AUT_ListAttribute_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_listAttributeInstanceFixture,
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
        ///     Class (<see cref="ListAttribute" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ListAttribute_Is_Instance_Present_Test()
        {
            // Assert
            _listAttributeInstanceType.ShouldNotBeNull();
            _listAttributeInstance.ShouldNotBeNull();
            _listAttributeInstanceFixture.ShouldNotBeNull();
            _listAttributeInstance.ShouldBeAssignableTo<ListAttribute>();
            _listAttributeInstanceFixture.ShouldBeAssignableTo<ListAttribute>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ListAttribute) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ListAttribute_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ListAttribute instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _listAttributeInstanceType.ShouldNotBeNull();
            _listAttributeInstance.ShouldNotBeNull();
            _listAttributeInstanceFixture.ShouldNotBeNull();
            _listAttributeInstance.ShouldBeAssignableTo<ListAttribute>();
            _listAttributeInstanceFixture.ShouldBeAssignableTo<ListAttribute>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ListAttribute) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyName)]
        public void AUT_ListAttribute_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ListAttribute, T>(_listAttributeInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ListAttribute) => Property (Name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ListAttribute_Public_Class_Name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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
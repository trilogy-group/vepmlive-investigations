using System;
using System.Collections.Generic;
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
using static EPMLiveCore.Services.DataContracts.SocialEngine.Webs;

namespace EPMLiveCore.Services.DataContracts.SocialEngine
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Services.DataContracts.SocialEngine.Webs" />)
    ///     and namespace <see cref="EPMLiveCore.Services.DataContracts.SocialEngine"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class WebsTest : AbstractBaseSetupTypedTest<Webs>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Webs) Initializer

        private const string Propertycollection = "collection";
        private const string Propertyerror = "error";
        private Type _websInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Webs _websInstance;
        private Webs _websInstanceFixture;

        #region General Initializer : Class (Webs) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Webs" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _websInstanceType = typeof(Webs);
            _websInstanceFixture = Create(true);
            _websInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Webs)

        #region General Initializer : Class (Webs) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Webs" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Propertycollection)]
        [TestCase(Propertyerror)]
        public void AUT_Webs_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_websInstanceFixture,
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
        ///     Class (<see cref="Webs" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Webs_Is_Instance_Present_Test()
        {
            // Assert
            _websInstanceType.ShouldNotBeNull();
            _websInstance.ShouldNotBeNull();
            _websInstanceFixture.ShouldNotBeNull();
            _websInstance.ShouldBeAssignableTo<Webs>();
            _websInstanceFixture.ShouldBeAssignableTo<Webs>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Webs) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_Webs_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Webs instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _websInstanceType.ShouldNotBeNull();
            _websInstance.ShouldNotBeNull();
            _websInstanceFixture.ShouldNotBeNull();
            _websInstance.ShouldBeAssignableTo<Webs>();
            _websInstanceFixture.ShouldBeAssignableTo<Webs>();
        }

        #endregion

        #region General Constructor : Class (Webs) Default Assignment Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Webs_Constructor_Instantiated_With_Default_Assignments_Test()
        {

            // Act
            var websInstance  = new Webs();

            // Asserts
            websInstance.ShouldNotBeNull();
            websInstance.ShouldBeAssignableTo<Webs>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Webs) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(List<Web>) , Propertycollection)]
        [TestCaseGeneric(typeof(Error) , Propertyerror)]
        public void AUT_Webs_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Webs, T>(_websInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Webs) => Property (collection) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Webs_Public_Class_collection_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertycollection);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Webs) => Property (error) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Webs_error_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyerror);
            Action currentAction = () => propertyInfo.SetValue(_websInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Webs) => Property (error) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Webs_Public_Class_error_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyerror);

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
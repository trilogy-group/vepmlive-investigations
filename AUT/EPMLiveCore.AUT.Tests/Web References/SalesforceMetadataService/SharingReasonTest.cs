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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.SharingReason" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class SharingReasonTest : AbstractBaseSetupTypedTest<SharingReason>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SharingReason) Initializer

        private const string Propertylabel = "label";
        private const string FieldlabelField = "labelField";
        private Type _sharingReasonInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private SharingReason _sharingReasonInstance;
        private SharingReason _sharingReasonInstanceFixture;

        #region General Initializer : Class (SharingReason) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SharingReason" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _sharingReasonInstanceType = typeof(SharingReason);
            _sharingReasonInstanceFixture = Create(true);
            _sharingReasonInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SharingReason)

        #region General Initializer : Class (SharingReason) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="SharingReason" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertylabel)]
        public void AUT_SharingReason_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_sharingReasonInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (SharingReason) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="SharingReason" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldlabelField)]
        public void AUT_SharingReason_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_sharingReasonInstanceFixture, 
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
        ///     Class (<see cref="SharingReason" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_SharingReason_Is_Instance_Present_Test()
        {
            // Assert
            _sharingReasonInstanceType.ShouldNotBeNull();
            _sharingReasonInstance.ShouldNotBeNull();
            _sharingReasonInstanceFixture.ShouldNotBeNull();
            _sharingReasonInstance.ShouldBeAssignableTo<SharingReason>();
            _sharingReasonInstanceFixture.ShouldBeAssignableTo<SharingReason>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (SharingReason) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_SharingReason_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            SharingReason instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _sharingReasonInstanceType.ShouldNotBeNull();
            _sharingReasonInstance.ShouldNotBeNull();
            _sharingReasonInstanceFixture.ShouldNotBeNull();
            _sharingReasonInstance.ShouldBeAssignableTo<SharingReason>();
            _sharingReasonInstanceFixture.ShouldBeAssignableTo<SharingReason>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (SharingReason) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertylabel)]
        public void AUT_SharingReason_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<SharingReason, T>(_sharingReasonInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (SharingReason) => Property (label) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SharingReason_Public_Class_label_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertylabel);

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
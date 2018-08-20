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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ProfileLayoutAssignment" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ProfileLayoutAssignmentTest : AbstractBaseSetupTypedTest<ProfileLayoutAssignment>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ProfileLayoutAssignment) Initializer

        private const string Propertylayout = "layout";
        private const string PropertyrecordType = "recordType";
        private const string FieldlayoutField = "layoutField";
        private const string FieldrecordTypeField = "recordTypeField";
        private Type _profileLayoutAssignmentInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ProfileLayoutAssignment _profileLayoutAssignmentInstance;
        private ProfileLayoutAssignment _profileLayoutAssignmentInstanceFixture;

        #region General Initializer : Class (ProfileLayoutAssignment) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ProfileLayoutAssignment" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _profileLayoutAssignmentInstanceType = typeof(ProfileLayoutAssignment);
            _profileLayoutAssignmentInstanceFixture = Create(true);
            _profileLayoutAssignmentInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ProfileLayoutAssignment)

        #region General Initializer : Class (ProfileLayoutAssignment) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ProfileLayoutAssignment" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertylayout)]
        [TestCase(PropertyrecordType)]
        public void AUT_ProfileLayoutAssignment_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_profileLayoutAssignmentInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ProfileLayoutAssignment) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ProfileLayoutAssignment" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldlayoutField)]
        [TestCase(FieldrecordTypeField)]
        public void AUT_ProfileLayoutAssignment_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_profileLayoutAssignmentInstanceFixture, 
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
        ///     Class (<see cref="ProfileLayoutAssignment" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ProfileLayoutAssignment_Is_Instance_Present_Test()
        {
            // Assert
            _profileLayoutAssignmentInstanceType.ShouldNotBeNull();
            _profileLayoutAssignmentInstance.ShouldNotBeNull();
            _profileLayoutAssignmentInstanceFixture.ShouldNotBeNull();
            _profileLayoutAssignmentInstance.ShouldBeAssignableTo<ProfileLayoutAssignment>();
            _profileLayoutAssignmentInstanceFixture.ShouldBeAssignableTo<ProfileLayoutAssignment>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ProfileLayoutAssignment) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ProfileLayoutAssignment_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ProfileLayoutAssignment instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _profileLayoutAssignmentInstanceType.ShouldNotBeNull();
            _profileLayoutAssignmentInstance.ShouldNotBeNull();
            _profileLayoutAssignmentInstanceFixture.ShouldNotBeNull();
            _profileLayoutAssignmentInstance.ShouldBeAssignableTo<ProfileLayoutAssignment>();
            _profileLayoutAssignmentInstanceFixture.ShouldBeAssignableTo<ProfileLayoutAssignment>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ProfileLayoutAssignment) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertylayout)]
        [TestCaseGeneric(typeof(string) , PropertyrecordType)]
        public void AUT_ProfileLayoutAssignment_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ProfileLayoutAssignment, T>(_profileLayoutAssignmentInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ProfileLayoutAssignment) => Property (layout) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProfileLayoutAssignment_Public_Class_layout_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertylayout);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProfileLayoutAssignment) => Property (recordType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProfileLayoutAssignment_Public_Class_recordType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrecordType);

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
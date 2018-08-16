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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.PackageTypeMembers" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class PackageTypeMembersTest : AbstractBaseSetupTypedTest<PackageTypeMembers>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (PackageTypeMembers) Initializer

        private const string Propertymembers = "members";
        private const string Propertyname = "name";
        private const string FieldmembersField = "membersField";
        private const string FieldnameField = "nameField";
        private Type _packageTypeMembersInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private PackageTypeMembers _packageTypeMembersInstance;
        private PackageTypeMembers _packageTypeMembersInstanceFixture;

        #region General Initializer : Class (PackageTypeMembers) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PackageTypeMembers" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _packageTypeMembersInstanceType = typeof(PackageTypeMembers);
            _packageTypeMembersInstanceFixture = Create(true);
            _packageTypeMembersInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PackageTypeMembers)

        #region General Initializer : Class (PackageTypeMembers) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="PackageTypeMembers" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertymembers)]
        [TestCase(Propertyname)]
        public void AUT_PackageTypeMembers_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_packageTypeMembersInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (PackageTypeMembers) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="PackageTypeMembers" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldmembersField)]
        [TestCase(FieldnameField)]
        public void AUT_PackageTypeMembers_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_packageTypeMembersInstanceFixture, 
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
        ///     Class (<see cref="PackageTypeMembers" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_PackageTypeMembers_Is_Instance_Present_Test()
        {
            // Assert
            _packageTypeMembersInstanceType.ShouldNotBeNull();
            _packageTypeMembersInstance.ShouldNotBeNull();
            _packageTypeMembersInstanceFixture.ShouldNotBeNull();
            _packageTypeMembersInstance.ShouldBeAssignableTo<PackageTypeMembers>();
            _packageTypeMembersInstanceFixture.ShouldBeAssignableTo<PackageTypeMembers>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (PackageTypeMembers) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_PackageTypeMembers_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            PackageTypeMembers instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _packageTypeMembersInstanceType.ShouldNotBeNull();
            _packageTypeMembersInstance.ShouldNotBeNull();
            _packageTypeMembersInstanceFixture.ShouldNotBeNull();
            _packageTypeMembersInstance.ShouldBeAssignableTo<PackageTypeMembers>();
            _packageTypeMembersInstanceFixture.ShouldBeAssignableTo<PackageTypeMembers>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (PackageTypeMembers) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string[]) , Propertymembers)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        public void AUT_PackageTypeMembers_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<PackageTypeMembers, T>(_packageTypeMembersInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (PackageTypeMembers) => Property (members) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PackageTypeMembers_members_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertymembers);
            Action currentAction = () => propertyInfo.SetValue(_packageTypeMembersInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (PackageTypeMembers) => Property (members) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PackageTypeMembers_Public_Class_members_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertymembers);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PackageTypeMembers) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PackageTypeMembers_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyname);

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
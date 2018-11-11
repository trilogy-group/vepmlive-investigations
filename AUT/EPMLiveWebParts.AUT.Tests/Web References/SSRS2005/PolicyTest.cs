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

namespace EPMLiveWebParts.SSRS2005
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.SSRS2005.Policy" />)
    ///     and namespace <see cref="EPMLiveWebParts.SSRS2005"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class PolicyTest : AbstractBaseSetupTypedTest<Policy>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Policy) Initializer

        private const string PropertyGroupUserName = "GroupUserName";
        private const string PropertyRoles = "Roles";
        private const string FieldgroupUserNameField = "groupUserNameField";
        private const string FieldrolesField = "rolesField";
        private Type _policyInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Policy _policyInstance;
        private Policy _policyInstanceFixture;

        #region General Initializer : Class (Policy) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Policy" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _policyInstanceType = typeof(Policy);
            _policyInstanceFixture = Create(true);
            _policyInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Policy)

        #region General Initializer : Class (Policy) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Policy" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyGroupUserName)]
        [TestCase(PropertyRoles)]
        public void AUT_Policy_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_policyInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Policy) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Policy" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldgroupUserNameField)]
        [TestCase(FieldrolesField)]
        public void AUT_Policy_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_policyInstanceFixture, 
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
        ///     Class (<see cref="Policy" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_Policy_Is_Instance_Present_Test()
        {
            // Assert
            _policyInstanceType.ShouldNotBeNull();
            _policyInstance.ShouldNotBeNull();
            _policyInstanceFixture.ShouldNotBeNull();
            _policyInstance.ShouldBeAssignableTo<Policy>();
            _policyInstanceFixture.ShouldBeAssignableTo<Policy>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Policy) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_Policy_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Policy instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _policyInstanceType.ShouldNotBeNull();
            _policyInstance.ShouldNotBeNull();
            _policyInstanceFixture.ShouldNotBeNull();
            _policyInstance.ShouldBeAssignableTo<Policy>();
            _policyInstanceFixture.ShouldBeAssignableTo<Policy>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Policy) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyGroupUserName)]
        [TestCaseGeneric(typeof(Role[]) , PropertyRoles)]
        public void AUT_Policy_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Policy, T>(_policyInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Policy) => Property (GroupUserName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Policy_Public_Class_GroupUserName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyGroupUserName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Policy) => Property (Roles) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Policy_Roles_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyRoles);
            Action currentAction = () => propertyInfo.SetValue(_policyInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Policy) => Property (Roles) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Policy_Public_Class_Roles_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyRoles);

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
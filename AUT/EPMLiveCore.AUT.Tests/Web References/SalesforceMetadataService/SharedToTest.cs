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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.SharedTo" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class SharedToTest : AbstractBaseSetupTypedTest<SharedTo>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SharedTo) Initializer

        private const string PropertyallCustomerPortalUsers = "allCustomerPortalUsers";
        private const string PropertyallInternalUsers = "allInternalUsers";
        private const string PropertyallPartnerUsers = "allPartnerUsers";
        private const string Propertygroup = "group";
        private const string Propertygroups = "groups";
        private const string PropertyportalRole = "portalRole";
        private const string PropertyportalRoleAndSubordinates = "portalRoleAndSubordinates";
        private const string Propertyqueue = "queue";
        private const string Propertyrole = "role";
        private const string PropertyroleAndSubordinates = "roleAndSubordinates";
        private const string PropertyroleAndSubordinatesInternal = "roleAndSubordinatesInternal";
        private const string Propertyroles = "roles";
        private const string PropertyrolesAndSubordinates = "rolesAndSubordinates";
        private const string Propertyterritories = "territories";
        private const string PropertyterritoriesAndSubordinates = "territoriesAndSubordinates";
        private const string Propertyterritory = "territory";
        private const string PropertyterritoryAndSubordinates = "territoryAndSubordinates";
        private const string FieldallCustomerPortalUsersField = "allCustomerPortalUsersField";
        private const string FieldallInternalUsersField = "allInternalUsersField";
        private const string FieldallPartnerUsersField = "allPartnerUsersField";
        private const string FieldgroupField = "groupField";
        private const string FieldgroupsField = "groupsField";
        private const string FieldportalRoleField = "portalRoleField";
        private const string FieldportalRoleAndSubordinatesField = "portalRoleAndSubordinatesField";
        private const string FieldqueueField = "queueField";
        private const string FieldroleField = "roleField";
        private const string FieldroleAndSubordinatesField = "roleAndSubordinatesField";
        private const string FieldroleAndSubordinatesInternalField = "roleAndSubordinatesInternalField";
        private const string FieldrolesField = "rolesField";
        private const string FieldrolesAndSubordinatesField = "rolesAndSubordinatesField";
        private const string FieldterritoriesField = "territoriesField";
        private const string FieldterritoriesAndSubordinatesField = "territoriesAndSubordinatesField";
        private const string FieldterritoryField = "territoryField";
        private const string FieldterritoryAndSubordinatesField = "territoryAndSubordinatesField";
        private Type _sharedToInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private SharedTo _sharedToInstance;
        private SharedTo _sharedToInstanceFixture;

        #region General Initializer : Class (SharedTo) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SharedTo" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _sharedToInstanceType = typeof(SharedTo);
            _sharedToInstanceFixture = Create(true);
            _sharedToInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SharedTo)

        #region General Initializer : Class (SharedTo) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="SharedTo" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyallCustomerPortalUsers)]
        [TestCase(PropertyallInternalUsers)]
        [TestCase(PropertyallPartnerUsers)]
        [TestCase(Propertygroup)]
        [TestCase(Propertygroups)]
        [TestCase(PropertyportalRole)]
        [TestCase(PropertyportalRoleAndSubordinates)]
        [TestCase(Propertyqueue)]
        [TestCase(Propertyrole)]
        [TestCase(PropertyroleAndSubordinates)]
        [TestCase(PropertyroleAndSubordinatesInternal)]
        [TestCase(Propertyroles)]
        [TestCase(PropertyrolesAndSubordinates)]
        [TestCase(Propertyterritories)]
        [TestCase(PropertyterritoriesAndSubordinates)]
        [TestCase(Propertyterritory)]
        [TestCase(PropertyterritoryAndSubordinates)]
        public void AUT_SharedTo_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_sharedToInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (SharedTo) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="SharedTo" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldallCustomerPortalUsersField)]
        [TestCase(FieldallInternalUsersField)]
        [TestCase(FieldallPartnerUsersField)]
        [TestCase(FieldgroupField)]
        [TestCase(FieldgroupsField)]
        [TestCase(FieldportalRoleField)]
        [TestCase(FieldportalRoleAndSubordinatesField)]
        [TestCase(FieldqueueField)]
        [TestCase(FieldroleField)]
        [TestCase(FieldroleAndSubordinatesField)]
        [TestCase(FieldroleAndSubordinatesInternalField)]
        [TestCase(FieldrolesField)]
        [TestCase(FieldrolesAndSubordinatesField)]
        [TestCase(FieldterritoriesField)]
        [TestCase(FieldterritoriesAndSubordinatesField)]
        [TestCase(FieldterritoryField)]
        [TestCase(FieldterritoryAndSubordinatesField)]
        public void AUT_SharedTo_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_sharedToInstanceFixture, 
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
        ///     Class (<see cref="SharedTo" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_SharedTo_Is_Instance_Present_Test()
        {
            // Assert
            _sharedToInstanceType.ShouldNotBeNull();
            _sharedToInstance.ShouldNotBeNull();
            _sharedToInstanceFixture.ShouldNotBeNull();
            _sharedToInstance.ShouldBeAssignableTo<SharedTo>();
            _sharedToInstanceFixture.ShouldBeAssignableTo<SharedTo>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (SharedTo) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_SharedTo_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            SharedTo instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _sharedToInstanceType.ShouldNotBeNull();
            _sharedToInstance.ShouldNotBeNull();
            _sharedToInstanceFixture.ShouldNotBeNull();
            _sharedToInstance.ShouldBeAssignableTo<SharedTo>();
            _sharedToInstanceFixture.ShouldBeAssignableTo<SharedTo>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (SharedTo) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyallCustomerPortalUsers)]
        [TestCaseGeneric(typeof(string) , PropertyallInternalUsers)]
        [TestCaseGeneric(typeof(string) , PropertyallPartnerUsers)]
        [TestCaseGeneric(typeof(string[]) , Propertygroup)]
        [TestCaseGeneric(typeof(string[]) , Propertygroups)]
        [TestCaseGeneric(typeof(string[]) , PropertyportalRole)]
        [TestCaseGeneric(typeof(string[]) , PropertyportalRoleAndSubordinates)]
        [TestCaseGeneric(typeof(string[]) , Propertyqueue)]
        [TestCaseGeneric(typeof(string[]) , Propertyrole)]
        [TestCaseGeneric(typeof(string[]) , PropertyroleAndSubordinates)]
        [TestCaseGeneric(typeof(string[]) , PropertyroleAndSubordinatesInternal)]
        [TestCaseGeneric(typeof(string[]) , Propertyroles)]
        [TestCaseGeneric(typeof(string[]) , PropertyrolesAndSubordinates)]
        [TestCaseGeneric(typeof(string[]) , Propertyterritories)]
        [TestCaseGeneric(typeof(string[]) , PropertyterritoriesAndSubordinates)]
        [TestCaseGeneric(typeof(string[]) , Propertyterritory)]
        [TestCaseGeneric(typeof(string[]) , PropertyterritoryAndSubordinates)]
        public void AUT_SharedTo_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<SharedTo, T>(_sharedToInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (SharedTo) => Property (allCustomerPortalUsers) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SharedTo_Public_Class_allCustomerPortalUsers_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyallCustomerPortalUsers);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SharedTo) => Property (allInternalUsers) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SharedTo_Public_Class_allInternalUsers_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyallInternalUsers);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SharedTo) => Property (allPartnerUsers) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SharedTo_Public_Class_allPartnerUsers_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyallPartnerUsers);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SharedTo) => Property (group) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SharedTo_group_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertygroup);
            Action currentAction = () => propertyInfo.SetValue(_sharedToInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SharedTo) => Property (group) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SharedTo_Public_Class_group_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertygroup);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SharedTo) => Property (groups) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SharedTo_groups_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertygroups);
            Action currentAction = () => propertyInfo.SetValue(_sharedToInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SharedTo) => Property (groups) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SharedTo_Public_Class_groups_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertygroups);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SharedTo) => Property (portalRole) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SharedTo_portalRole_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyportalRole);
            Action currentAction = () => propertyInfo.SetValue(_sharedToInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SharedTo) => Property (portalRole) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SharedTo_Public_Class_portalRole_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyportalRole);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SharedTo) => Property (portalRoleAndSubordinates) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SharedTo_portalRoleAndSubordinates_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyportalRoleAndSubordinates);
            Action currentAction = () => propertyInfo.SetValue(_sharedToInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SharedTo) => Property (portalRoleAndSubordinates) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SharedTo_Public_Class_portalRoleAndSubordinates_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyportalRoleAndSubordinates);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SharedTo) => Property (queue) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SharedTo_queue_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyqueue);
            Action currentAction = () => propertyInfo.SetValue(_sharedToInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SharedTo) => Property (queue) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SharedTo_Public_Class_queue_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyqueue);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SharedTo) => Property (role) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SharedTo_role_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyrole);
            Action currentAction = () => propertyInfo.SetValue(_sharedToInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SharedTo) => Property (role) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SharedTo_Public_Class_role_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyrole);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SharedTo) => Property (roleAndSubordinates) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SharedTo_roleAndSubordinates_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyroleAndSubordinates);
            Action currentAction = () => propertyInfo.SetValue(_sharedToInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SharedTo) => Property (roleAndSubordinates) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SharedTo_Public_Class_roleAndSubordinates_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyroleAndSubordinates);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SharedTo) => Property (roleAndSubordinatesInternal) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SharedTo_roleAndSubordinatesInternal_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyroleAndSubordinatesInternal);
            Action currentAction = () => propertyInfo.SetValue(_sharedToInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SharedTo) => Property (roleAndSubordinatesInternal) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SharedTo_Public_Class_roleAndSubordinatesInternal_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyroleAndSubordinatesInternal);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SharedTo) => Property (roles) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SharedTo_roles_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyroles);
            Action currentAction = () => propertyInfo.SetValue(_sharedToInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SharedTo) => Property (roles) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SharedTo_Public_Class_roles_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyroles);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SharedTo) => Property (rolesAndSubordinates) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SharedTo_rolesAndSubordinates_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyrolesAndSubordinates);
            Action currentAction = () => propertyInfo.SetValue(_sharedToInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SharedTo) => Property (rolesAndSubordinates) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SharedTo_Public_Class_rolesAndSubordinates_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrolesAndSubordinates);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SharedTo) => Property (territories) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SharedTo_territories_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyterritories);
            Action currentAction = () => propertyInfo.SetValue(_sharedToInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SharedTo) => Property (territories) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SharedTo_Public_Class_territories_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyterritories);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SharedTo) => Property (territoriesAndSubordinates) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SharedTo_territoriesAndSubordinates_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyterritoriesAndSubordinates);
            Action currentAction = () => propertyInfo.SetValue(_sharedToInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SharedTo) => Property (territoriesAndSubordinates) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SharedTo_Public_Class_territoriesAndSubordinates_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyterritoriesAndSubordinates);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SharedTo) => Property (territory) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SharedTo_territory_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyterritory);
            Action currentAction = () => propertyInfo.SetValue(_sharedToInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SharedTo) => Property (territory) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SharedTo_Public_Class_territory_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyterritory);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SharedTo) => Property (territoryAndSubordinates) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SharedTo_territoryAndSubordinates_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyterritoryAndSubordinates);
            Action currentAction = () => propertyInfo.SetValue(_sharedToInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SharedTo) => Property (territoryAndSubordinates) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SharedTo_Public_Class_territoryAndSubordinates_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyterritoryAndSubordinates);

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
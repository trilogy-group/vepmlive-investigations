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

namespace EPMLiveWebParts.SSRS2006
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.SSRS2006.Subscription" />)
    ///     and namespace <see cref="EPMLiveWebParts.SSRS2006"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class SubscriptionTest : AbstractBaseSetupTypedTest<Subscription>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Subscription) Initializer

        private const string PropertySubscriptionID = "SubscriptionID";
        private const string PropertyOwner = "Owner";
        private const string PropertyPath = "Path";
        private const string PropertyVirtualPath = "VirtualPath";
        private const string PropertyReport = "Report";
        private const string PropertyDeliverySettings = "DeliverySettings";
        private const string PropertyDescription = "Description";
        private const string PropertyStatus = "Status";
        private const string PropertyActive = "Active";
        private const string PropertyLastExecuted = "LastExecuted";
        private const string PropertyLastExecutedSpecified = "LastExecutedSpecified";
        private const string PropertyModifiedBy = "ModifiedBy";
        private const string PropertyModifiedDate = "ModifiedDate";
        private const string PropertyEventType = "EventType";
        private const string PropertyIsDataDriven = "IsDataDriven";
        private const string FieldsubscriptionIDField = "subscriptionIDField";
        private const string FieldownerField = "ownerField";
        private const string FieldpathField = "pathField";
        private const string FieldvirtualPathField = "virtualPathField";
        private const string FieldreportField = "reportField";
        private const string FielddeliverySettingsField = "deliverySettingsField";
        private const string FielddescriptionField = "descriptionField";
        private const string FieldstatusField = "statusField";
        private const string FieldactiveField = "activeField";
        private const string FieldlastExecutedField = "lastExecutedField";
        private const string FieldlastExecutedFieldSpecified = "lastExecutedFieldSpecified";
        private const string FieldmodifiedByField = "modifiedByField";
        private const string FieldmodifiedDateField = "modifiedDateField";
        private const string FieldeventTypeField = "eventTypeField";
        private const string FieldisDataDrivenField = "isDataDrivenField";
        private Type _subscriptionInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Subscription _subscriptionInstance;
        private Subscription _subscriptionInstanceFixture;

        #region General Initializer : Class (Subscription) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Subscription" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _subscriptionInstanceType = typeof(Subscription);
            _subscriptionInstanceFixture = Create(true);
            _subscriptionInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Subscription)

        #region General Initializer : Class (Subscription) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Subscription" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertySubscriptionID)]
        [TestCase(PropertyOwner)]
        [TestCase(PropertyPath)]
        [TestCase(PropertyVirtualPath)]
        [TestCase(PropertyReport)]
        [TestCase(PropertyDeliverySettings)]
        [TestCase(PropertyDescription)]
        [TestCase(PropertyStatus)]
        [TestCase(PropertyActive)]
        [TestCase(PropertyLastExecuted)]
        [TestCase(PropertyLastExecutedSpecified)]
        [TestCase(PropertyModifiedBy)]
        [TestCase(PropertyModifiedDate)]
        [TestCase(PropertyEventType)]
        [TestCase(PropertyIsDataDriven)]
        public void AUT_Subscription_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_subscriptionInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Subscription) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Subscription" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldsubscriptionIDField)]
        [TestCase(FieldownerField)]
        [TestCase(FieldpathField)]
        [TestCase(FieldvirtualPathField)]
        [TestCase(FieldreportField)]
        [TestCase(FielddeliverySettingsField)]
        [TestCase(FielddescriptionField)]
        [TestCase(FieldstatusField)]
        [TestCase(FieldactiveField)]
        [TestCase(FieldlastExecutedField)]
        [TestCase(FieldlastExecutedFieldSpecified)]
        [TestCase(FieldmodifiedByField)]
        [TestCase(FieldmodifiedDateField)]
        [TestCase(FieldeventTypeField)]
        [TestCase(FieldisDataDrivenField)]
        public void AUT_Subscription_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_subscriptionInstanceFixture, 
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
        ///     Class (<see cref="Subscription" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_Subscription_Is_Instance_Present_Test()
        {
            // Assert
            _subscriptionInstanceType.ShouldNotBeNull();
            _subscriptionInstance.ShouldNotBeNull();
            _subscriptionInstanceFixture.ShouldNotBeNull();
            _subscriptionInstance.ShouldBeAssignableTo<Subscription>();
            _subscriptionInstanceFixture.ShouldBeAssignableTo<Subscription>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Subscription) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_Subscription_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Subscription instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _subscriptionInstanceType.ShouldNotBeNull();
            _subscriptionInstance.ShouldNotBeNull();
            _subscriptionInstanceFixture.ShouldNotBeNull();
            _subscriptionInstance.ShouldBeAssignableTo<Subscription>();
            _subscriptionInstanceFixture.ShouldBeAssignableTo<Subscription>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Subscription) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertySubscriptionID)]
        [TestCaseGeneric(typeof(string) , PropertyOwner)]
        [TestCaseGeneric(typeof(string) , PropertyPath)]
        [TestCaseGeneric(typeof(string) , PropertyVirtualPath)]
        [TestCaseGeneric(typeof(string) , PropertyReport)]
        [TestCaseGeneric(typeof(ExtensionSettings) , PropertyDeliverySettings)]
        [TestCaseGeneric(typeof(string) , PropertyDescription)]
        [TestCaseGeneric(typeof(string) , PropertyStatus)]
        [TestCaseGeneric(typeof(ActiveState) , PropertyActive)]
        [TestCaseGeneric(typeof(System.DateTime) , PropertyLastExecuted)]
        [TestCaseGeneric(typeof(bool) , PropertyLastExecutedSpecified)]
        [TestCaseGeneric(typeof(string) , PropertyModifiedBy)]
        [TestCaseGeneric(typeof(System.DateTime) , PropertyModifiedDate)]
        [TestCaseGeneric(typeof(string) , PropertyEventType)]
        [TestCaseGeneric(typeof(bool) , PropertyIsDataDriven)]
        public void AUT_Subscription_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Subscription, T>(_subscriptionInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Subscription) => Property (Active) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Subscription_Active_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyActive);
            Action currentAction = () => propertyInfo.SetValue(_subscriptionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Subscription) => Property (Active) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Subscription_Public_Class_Active_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyActive);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Subscription) => Property (DeliverySettings) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Subscription_DeliverySettings_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyDeliverySettings);
            Action currentAction = () => propertyInfo.SetValue(_subscriptionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Subscription) => Property (DeliverySettings) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Subscription_Public_Class_DeliverySettings_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDeliverySettings);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Subscription) => Property (Description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Subscription_Public_Class_Description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDescription);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Subscription) => Property (EventType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Subscription_Public_Class_EventType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyEventType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Subscription) => Property (IsDataDriven) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Subscription_Public_Class_IsDataDriven_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyIsDataDriven);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Subscription) => Property (LastExecuted) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Subscription_LastExecuted_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyLastExecuted);
            Action currentAction = () => propertyInfo.SetValue(_subscriptionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Subscription) => Property (LastExecuted) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Subscription_Public_Class_LastExecuted_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyLastExecuted);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Subscription) => Property (LastExecutedSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Subscription_Public_Class_LastExecutedSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyLastExecutedSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Subscription) => Property (ModifiedBy) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Subscription_Public_Class_ModifiedBy_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyModifiedBy);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Subscription) => Property (ModifiedDate) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Subscription_ModifiedDate_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyModifiedDate);
            Action currentAction = () => propertyInfo.SetValue(_subscriptionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Subscription) => Property (ModifiedDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Subscription_Public_Class_ModifiedDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyModifiedDate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Subscription) => Property (Owner) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Subscription_Public_Class_Owner_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyOwner);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Subscription) => Property (Path) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Subscription_Public_Class_Path_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPath);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Subscription) => Property (Report) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Subscription_Public_Class_Report_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyReport);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Subscription) => Property (Status) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Subscription_Public_Class_Status_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyStatus);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Subscription) => Property (SubscriptionID) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Subscription_Public_Class_SubscriptionID_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySubscriptionID);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Subscription) => Property (VirtualPath) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Subscription_Public_Class_VirtualPath_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyVirtualPath);

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
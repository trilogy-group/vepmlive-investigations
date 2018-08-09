using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.Jobs
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Jobs.ResourceImportMessage" />)
    ///     and namespace <see cref="EPMLiveCore.Jobs"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ResourceImportMessageTest : AbstractBaseSetupTypedTest<ResourceImportMessage>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ResourceImportMessage) Initializer

        private const string PropertyKind = "Kind";
        private const string PropertyDateTime = "DateTime";
        private const string PropertyMessage = "Message";
        private Type _resourceImportMessageInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ResourceImportMessage _resourceImportMessageInstance;
        private ResourceImportMessage _resourceImportMessageInstanceFixture;

        #region General Initializer : Class (ResourceImportMessage) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ResourceImportMessage" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _resourceImportMessageInstanceType = typeof(ResourceImportMessage);
            _resourceImportMessageInstanceFixture = Create(true);
            _resourceImportMessageInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ResourceImportMessage)

        #region General Initializer : Class (ResourceImportMessage) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ResourceImportMessage" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyKind)]
        [TestCase(PropertyDateTime)]
        [TestCase(PropertyMessage)]
        public void AUT_ResourceImportMessage_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_resourceImportMessageInstanceFixture,
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
        ///     Class (<see cref="ResourceImportMessage" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ResourceImportMessage_Is_Instance_Present_Test()
        {
            // Assert
            _resourceImportMessageInstanceType.ShouldNotBeNull();
            _resourceImportMessageInstance.ShouldNotBeNull();
            _resourceImportMessageInstanceFixture.ShouldNotBeNull();
            _resourceImportMessageInstance.ShouldBeAssignableTo<ResourceImportMessage>();
            _resourceImportMessageInstanceFixture.ShouldBeAssignableTo<ResourceImportMessage>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ResourceImportMessage) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ResourceImportMessage_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ResourceImportMessage instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _resourceImportMessageInstanceType.ShouldNotBeNull();
            _resourceImportMessageInstance.ShouldNotBeNull();
            _resourceImportMessageInstanceFixture.ShouldNotBeNull();
            _resourceImportMessageInstance.ShouldBeAssignableTo<ResourceImportMessage>();
            _resourceImportMessageInstanceFixture.ShouldBeAssignableTo<ResourceImportMessage>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ResourceImportMessage) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(Int32) , PropertyKind)]
        [TestCaseGeneric(typeof(DateTime) , PropertyDateTime)]
        [TestCaseGeneric(typeof(String) , PropertyMessage)]
        public void AUT_ResourceImportMessage_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ResourceImportMessage, T>(_resourceImportMessageInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ResourceImportMessage) => Property (DateTime) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ResourceImportMessage_DateTime_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyDateTime);
            Action currentAction = () => propertyInfo.SetValue(_resourceImportMessageInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ResourceImportMessage) => Property (DateTime) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ResourceImportMessage_Public_Class_DateTime_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDateTime);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ResourceImportMessage) => Property (Kind) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ResourceImportMessage_Public_Class_Kind_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyKind);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ResourceImportMessage) => Property (Message) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ResourceImportMessage_Public_Class_Message_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyMessage);

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
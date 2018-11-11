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

namespace WorkEnginePPM.DataServiceModules
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.DataServiceModules.DSMMessage" />)
    ///     and namespace <see cref="WorkEnginePPM.DataServiceModules"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class DSMMessageTest : AbstractBaseSetupTypedTest<DSMMessage>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DSMMessage) Initializer

        private const string PropertyKind = "Kind";
        private const string PropertyDateTime = "DateTime";
        private const string PropertyMessage = "Message";
        private Type _dSMMessageInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DSMMessage _dSMMessageInstance;
        private DSMMessage _dSMMessageInstanceFixture;

        #region General Initializer : Class (DSMMessage) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DSMMessage" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _dSMMessageInstanceType = typeof(DSMMessage);
            _dSMMessageInstanceFixture = Create(true);
            _dSMMessageInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DSMMessage)

        #region General Initializer : Class (DSMMessage) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DSMMessage" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyKind)]
        [TestCase(PropertyDateTime)]
        [TestCase(PropertyMessage)]
        public void AUT_DSMMessage_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_dSMMessageInstanceFixture,
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
        ///     Class (<see cref="DSMMessage" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_DSMMessage_Is_Instance_Present_Test()
        {
            // Assert
            _dSMMessageInstanceType.ShouldNotBeNull();
            _dSMMessageInstance.ShouldNotBeNull();
            _dSMMessageInstanceFixture.ShouldNotBeNull();
            _dSMMessageInstance.ShouldBeAssignableTo<DSMMessage>();
            _dSMMessageInstanceFixture.ShouldBeAssignableTo<DSMMessage>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DSMMessage) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_DSMMessage_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DSMMessage instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _dSMMessageInstanceType.ShouldNotBeNull();
            _dSMMessageInstance.ShouldNotBeNull();
            _dSMMessageInstanceFixture.ShouldNotBeNull();
            _dSMMessageInstance.ShouldBeAssignableTo<DSMMessage>();
            _dSMMessageInstanceFixture.ShouldBeAssignableTo<DSMMessage>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DSMMessage) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(Int32) , PropertyKind)]
        [TestCaseGeneric(typeof(DateTime) , PropertyDateTime)]
        [TestCaseGeneric(typeof(String) , PropertyMessage)]
        public void AUT_DSMMessage_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DSMMessage, T>(_dSMMessageInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DSMMessage) => Property (DateTime) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_DSMMessage_DateTime_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyDateTime);
            Action currentAction = () => propertyInfo.SetValue(_dSMMessageInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DSMMessage) => Property (DateTime) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_DSMMessage_Public_Class_DateTime_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DSMMessage) => Property (Kind) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_DSMMessage_Public_Class_Kind_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DSMMessage) => Property (Message) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_DSMMessage_Public_Class_Message_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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
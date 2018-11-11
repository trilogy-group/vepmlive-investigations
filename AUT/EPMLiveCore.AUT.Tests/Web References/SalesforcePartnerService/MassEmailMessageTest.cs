using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.AutoFixtureSetup;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore.SalesforcePartnerService;
using MassEmailMessage = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.MassEmailMessage" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class MassEmailMessageTest : AbstractBaseSetupTypedTest<MassEmailMessage>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (MassEmailMessage) Initializer

        private const string Propertydescription = "description";
        private const string PropertytargetObjectIds = "targetObjectIds";
        private const string PropertytemplateId = "templateId";
        private const string PropertywhatIds = "whatIds";
        private const string FielddescriptionField = "descriptionField";
        private const string FieldtargetObjectIdsField = "targetObjectIdsField";
        private const string FieldtemplateIdField = "templateIdField";
        private const string FieldwhatIdsField = "whatIdsField";
        private Type _massEmailMessageInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private MassEmailMessage _massEmailMessageInstance;
        private MassEmailMessage _massEmailMessageInstanceFixture;

        #region General Initializer : Class (MassEmailMessage) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="MassEmailMessage" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _massEmailMessageInstanceType = typeof(MassEmailMessage);
            _massEmailMessageInstanceFixture = Create(true);
            _massEmailMessageInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (MassEmailMessage)

        #region General Initializer : Class (MassEmailMessage) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="MassEmailMessage" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertydescription)]
        [TestCase(PropertytargetObjectIds)]
        [TestCase(PropertytemplateId)]
        [TestCase(PropertywhatIds)]
        public void AUT_MassEmailMessage_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_massEmailMessageInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (MassEmailMessage) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="MassEmailMessage" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielddescriptionField)]
        [TestCase(FieldtargetObjectIdsField)]
        [TestCase(FieldtemplateIdField)]
        [TestCase(FieldwhatIdsField)]
        public void AUT_MassEmailMessage_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_massEmailMessageInstanceFixture, 
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
        ///     Class (<see cref="MassEmailMessage" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_MassEmailMessage_Is_Instance_Present_Test()
        {
            // Assert
            _massEmailMessageInstanceType.ShouldNotBeNull();
            _massEmailMessageInstance.ShouldNotBeNull();
            _massEmailMessageInstanceFixture.ShouldNotBeNull();
            _massEmailMessageInstance.ShouldBeAssignableTo<MassEmailMessage>();
            _massEmailMessageInstanceFixture.ShouldBeAssignableTo<MassEmailMessage>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (MassEmailMessage) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_MassEmailMessage_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            MassEmailMessage instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _massEmailMessageInstanceType.ShouldNotBeNull();
            _massEmailMessageInstance.ShouldNotBeNull();
            _massEmailMessageInstanceFixture.ShouldNotBeNull();
            _massEmailMessageInstance.ShouldBeAssignableTo<MassEmailMessage>();
            _massEmailMessageInstanceFixture.ShouldBeAssignableTo<MassEmailMessage>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (MassEmailMessage) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        [TestCaseGeneric(typeof(string[]) , PropertytargetObjectIds)]
        [TestCaseGeneric(typeof(string) , PropertytemplateId)]
        [TestCaseGeneric(typeof(string[]) , PropertywhatIds)]
        public void AUT_MassEmailMessage_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<MassEmailMessage, T>(_massEmailMessageInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (MassEmailMessage) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MassEmailMessage_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertydescription);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MassEmailMessage) => Property (targetObjectIds) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MassEmailMessage_targetObjectIds_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertytargetObjectIds);
            Action currentAction = () => propertyInfo.SetValue(_massEmailMessageInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (MassEmailMessage) => Property (targetObjectIds) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MassEmailMessage_Public_Class_targetObjectIds_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytargetObjectIds);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MassEmailMessage) => Property (templateId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MassEmailMessage_Public_Class_templateId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytemplateId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MassEmailMessage) => Property (whatIds) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MassEmailMessage_whatIds_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertywhatIds);
            Action currentAction = () => propertyInfo.SetValue(_massEmailMessageInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (MassEmailMessage) => Property (whatIds) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MassEmailMessage_Public_Class_whatIds_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertywhatIds);

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
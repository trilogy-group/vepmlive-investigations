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
using EPMLiveCore.SSRS2006;
using TrustedUserHeader = EPMLiveCore.SSRS2006;

namespace EPMLiveCore.SSRS2006
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SSRS2006.TrustedUserHeader" />)
    ///     and namespace <see cref="EPMLiveCore.SSRS2006"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class TrustedUserHeaderTest : AbstractBaseSetupTypedTest<TrustedUserHeader>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (TrustedUserHeader) Initializer

        private const string PropertyUserName = "UserName";
        private const string PropertyUserToken = "UserToken";
        private const string PropertyAnyAttr = "AnyAttr";
        private const string FielduserNameField = "userNameField";
        private const string FielduserTokenField = "userTokenField";
        private const string FieldanyAttrField = "anyAttrField";
        private Type _trustedUserHeaderInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private TrustedUserHeader _trustedUserHeaderInstance;
        private TrustedUserHeader _trustedUserHeaderInstanceFixture;

        #region General Initializer : Class (TrustedUserHeader) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="TrustedUserHeader" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _trustedUserHeaderInstanceType = typeof(TrustedUserHeader);
            _trustedUserHeaderInstanceFixture = Create(true);
            _trustedUserHeaderInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (TrustedUserHeader)

        #region General Initializer : Class (TrustedUserHeader) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="TrustedUserHeader" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyUserName)]
        [TestCase(PropertyUserToken)]
        [TestCase(PropertyAnyAttr)]
        public void AUT_TrustedUserHeader_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_trustedUserHeaderInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (TrustedUserHeader) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="TrustedUserHeader" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielduserNameField)]
        [TestCase(FielduserTokenField)]
        [TestCase(FieldanyAttrField)]
        public void AUT_TrustedUserHeader_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_trustedUserHeaderInstanceFixture, 
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
        ///     Class (<see cref="TrustedUserHeader" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_TrustedUserHeader_Is_Instance_Present_Test()
        {
            // Assert
            _trustedUserHeaderInstanceType.ShouldNotBeNull();
            _trustedUserHeaderInstance.ShouldNotBeNull();
            _trustedUserHeaderInstanceFixture.ShouldNotBeNull();
            _trustedUserHeaderInstance.ShouldBeAssignableTo<TrustedUserHeader>();
            _trustedUserHeaderInstanceFixture.ShouldBeAssignableTo<TrustedUserHeader>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (TrustedUserHeader) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_TrustedUserHeader_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            TrustedUserHeader instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _trustedUserHeaderInstanceType.ShouldNotBeNull();
            _trustedUserHeaderInstance.ShouldNotBeNull();
            _trustedUserHeaderInstanceFixture.ShouldNotBeNull();
            _trustedUserHeaderInstance.ShouldBeAssignableTo<TrustedUserHeader>();
            _trustedUserHeaderInstanceFixture.ShouldBeAssignableTo<TrustedUserHeader>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (TrustedUserHeader) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyUserName)]
        [TestCaseGeneric(typeof(byte[]) , PropertyUserToken)]
        [TestCaseGeneric(typeof(System.Xml.XmlAttribute[]) , PropertyAnyAttr)]
        public void AUT_TrustedUserHeader_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<TrustedUserHeader, T>(_trustedUserHeaderInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (TrustedUserHeader) => Property (AnyAttr) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_TrustedUserHeader_AnyAttr_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyAnyAttr);
            Action currentAction = () => propertyInfo.SetValue(_trustedUserHeaderInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (TrustedUserHeader) => Property (AnyAttr) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_TrustedUserHeader_Public_Class_AnyAttr_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyAnyAttr);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TrustedUserHeader) => Property (UserName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_TrustedUserHeader_Public_Class_UserName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyUserName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TrustedUserHeader) => Property (UserToken) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_TrustedUserHeader_UserToken_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyUserToken);
            Action currentAction = () => propertyInfo.SetValue(_trustedUserHeaderInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (TrustedUserHeader) => Property (UserToken) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_TrustedUserHeader_Public_Class_UserToken_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyUserToken);

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
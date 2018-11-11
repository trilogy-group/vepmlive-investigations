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
using OwnerChangeOptions = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.OwnerChangeOptions" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class OwnerChangeOptionsTest : AbstractBaseSetupTypedTest<OwnerChangeOptions>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (OwnerChangeOptions) Initializer

        private const string PropertytransferAttachments = "transferAttachments";
        private const string PropertytransferOpenActivities = "transferOpenActivities";
        private const string FieldtransferAttachmentsField = "transferAttachmentsField";
        private const string FieldtransferOpenActivitiesField = "transferOpenActivitiesField";
        private Type _ownerChangeOptionsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private OwnerChangeOptions _ownerChangeOptionsInstance;
        private OwnerChangeOptions _ownerChangeOptionsInstanceFixture;

        #region General Initializer : Class (OwnerChangeOptions) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="OwnerChangeOptions" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _ownerChangeOptionsInstanceType = typeof(OwnerChangeOptions);
            _ownerChangeOptionsInstanceFixture = Create(true);
            _ownerChangeOptionsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (OwnerChangeOptions)

        #region General Initializer : Class (OwnerChangeOptions) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="OwnerChangeOptions" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertytransferAttachments)]
        [TestCase(PropertytransferOpenActivities)]
        public void AUT_OwnerChangeOptions_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_ownerChangeOptionsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (OwnerChangeOptions) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="OwnerChangeOptions" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldtransferAttachmentsField)]
        [TestCase(FieldtransferOpenActivitiesField)]
        public void AUT_OwnerChangeOptions_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_ownerChangeOptionsInstanceFixture, 
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
        ///     Class (<see cref="OwnerChangeOptions" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_OwnerChangeOptions_Is_Instance_Present_Test()
        {
            // Assert
            _ownerChangeOptionsInstanceType.ShouldNotBeNull();
            _ownerChangeOptionsInstance.ShouldNotBeNull();
            _ownerChangeOptionsInstanceFixture.ShouldNotBeNull();
            _ownerChangeOptionsInstance.ShouldBeAssignableTo<OwnerChangeOptions>();
            _ownerChangeOptionsInstanceFixture.ShouldBeAssignableTo<OwnerChangeOptions>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (OwnerChangeOptions) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_OwnerChangeOptions_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            OwnerChangeOptions instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _ownerChangeOptionsInstanceType.ShouldNotBeNull();
            _ownerChangeOptionsInstance.ShouldNotBeNull();
            _ownerChangeOptionsInstanceFixture.ShouldNotBeNull();
            _ownerChangeOptionsInstance.ShouldBeAssignableTo<OwnerChangeOptions>();
            _ownerChangeOptionsInstanceFixture.ShouldBeAssignableTo<OwnerChangeOptions>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (OwnerChangeOptions) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertytransferAttachments)]
        [TestCaseGeneric(typeof(bool) , PropertytransferOpenActivities)]
        public void AUT_OwnerChangeOptions_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<OwnerChangeOptions, T>(_ownerChangeOptionsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (OwnerChangeOptions) => Property (transferAttachments) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_OwnerChangeOptions_Public_Class_transferAttachments_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytransferAttachments);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (OwnerChangeOptions) => Property (transferOpenActivities) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_OwnerChangeOptions_Public_Class_transferOpenActivities_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytransferOpenActivities);

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
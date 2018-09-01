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
using DescribeSoftphoneLayoutItem = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.DescribeSoftphoneLayoutItem" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DescribeSoftphoneLayoutItemTest : AbstractBaseSetupTypedTest<DescribeSoftphoneLayoutItem>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DescribeSoftphoneLayoutItem) Initializer

        private const string PropertyitemApiName = "itemApiName";
        private const string FielditemApiNameField = "itemApiNameField";
        private Type _describeSoftphoneLayoutItemInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DescribeSoftphoneLayoutItem _describeSoftphoneLayoutItemInstance;
        private DescribeSoftphoneLayoutItem _describeSoftphoneLayoutItemInstanceFixture;

        #region General Initializer : Class (DescribeSoftphoneLayoutItem) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DescribeSoftphoneLayoutItem" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _describeSoftphoneLayoutItemInstanceType = typeof(DescribeSoftphoneLayoutItem);
            _describeSoftphoneLayoutItemInstanceFixture = Create(true);
            _describeSoftphoneLayoutItemInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DescribeSoftphoneLayoutItem)

        #region General Initializer : Class (DescribeSoftphoneLayoutItem) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeSoftphoneLayoutItem" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyitemApiName)]
        public void AUT_DescribeSoftphoneLayoutItem_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_describeSoftphoneLayoutItemInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DescribeSoftphoneLayoutItem) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeSoftphoneLayoutItem" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielditemApiNameField)]
        public void AUT_DescribeSoftphoneLayoutItem_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_describeSoftphoneLayoutItemInstanceFixture, 
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
        ///     Class (<see cref="DescribeSoftphoneLayoutItem" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DescribeSoftphoneLayoutItem_Is_Instance_Present_Test()
        {
            // Assert
            _describeSoftphoneLayoutItemInstanceType.ShouldNotBeNull();
            _describeSoftphoneLayoutItemInstance.ShouldNotBeNull();
            _describeSoftphoneLayoutItemInstanceFixture.ShouldNotBeNull();
            _describeSoftphoneLayoutItemInstance.ShouldBeAssignableTo<DescribeSoftphoneLayoutItem>();
            _describeSoftphoneLayoutItemInstanceFixture.ShouldBeAssignableTo<DescribeSoftphoneLayoutItem>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DescribeSoftphoneLayoutItem) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DescribeSoftphoneLayoutItem_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DescribeSoftphoneLayoutItem instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _describeSoftphoneLayoutItemInstanceType.ShouldNotBeNull();
            _describeSoftphoneLayoutItemInstance.ShouldNotBeNull();
            _describeSoftphoneLayoutItemInstanceFixture.ShouldNotBeNull();
            _describeSoftphoneLayoutItemInstance.ShouldBeAssignableTo<DescribeSoftphoneLayoutItem>();
            _describeSoftphoneLayoutItemInstanceFixture.ShouldBeAssignableTo<DescribeSoftphoneLayoutItem>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DescribeSoftphoneLayoutItem) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyitemApiName)]
        public void AUT_DescribeSoftphoneLayoutItem_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DescribeSoftphoneLayoutItem, T>(_describeSoftphoneLayoutItemInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSoftphoneLayoutItem) => Property (itemApiName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSoftphoneLayoutItem_Public_Class_itemApiName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyitemApiName);

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
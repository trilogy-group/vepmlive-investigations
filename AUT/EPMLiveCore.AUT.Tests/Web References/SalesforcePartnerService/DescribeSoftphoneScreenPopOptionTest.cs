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
using DescribeSoftphoneScreenPopOption = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.DescribeSoftphoneScreenPopOption" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DescribeSoftphoneScreenPopOptionTest : AbstractBaseSetupTypedTest<DescribeSoftphoneScreenPopOption>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DescribeSoftphoneScreenPopOption) Initializer

        private const string PropertymatchType = "matchType";
        private const string PropertyscreenPopData = "screenPopData";
        private const string PropertyscreenPopType = "screenPopType";
        private const string FieldmatchTypeField = "matchTypeField";
        private const string FieldscreenPopDataField = "screenPopDataField";
        private const string FieldscreenPopTypeField = "screenPopTypeField";
        private Type _describeSoftphoneScreenPopOptionInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DescribeSoftphoneScreenPopOption _describeSoftphoneScreenPopOptionInstance;
        private DescribeSoftphoneScreenPopOption _describeSoftphoneScreenPopOptionInstanceFixture;

        #region General Initializer : Class (DescribeSoftphoneScreenPopOption) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DescribeSoftphoneScreenPopOption" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _describeSoftphoneScreenPopOptionInstanceType = typeof(DescribeSoftphoneScreenPopOption);
            _describeSoftphoneScreenPopOptionInstanceFixture = Create(true);
            _describeSoftphoneScreenPopOptionInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DescribeSoftphoneScreenPopOption)

        #region General Initializer : Class (DescribeSoftphoneScreenPopOption) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeSoftphoneScreenPopOption" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertymatchType)]
        [TestCase(PropertyscreenPopData)]
        [TestCase(PropertyscreenPopType)]
        public void AUT_DescribeSoftphoneScreenPopOption_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_describeSoftphoneScreenPopOptionInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DescribeSoftphoneScreenPopOption) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeSoftphoneScreenPopOption" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldmatchTypeField)]
        [TestCase(FieldscreenPopDataField)]
        [TestCase(FieldscreenPopTypeField)]
        public void AUT_DescribeSoftphoneScreenPopOption_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_describeSoftphoneScreenPopOptionInstanceFixture, 
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
        ///     Class (<see cref="DescribeSoftphoneScreenPopOption" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DescribeSoftphoneScreenPopOption_Is_Instance_Present_Test()
        {
            // Assert
            _describeSoftphoneScreenPopOptionInstanceType.ShouldNotBeNull();
            _describeSoftphoneScreenPopOptionInstance.ShouldNotBeNull();
            _describeSoftphoneScreenPopOptionInstanceFixture.ShouldNotBeNull();
            _describeSoftphoneScreenPopOptionInstance.ShouldBeAssignableTo<DescribeSoftphoneScreenPopOption>();
            _describeSoftphoneScreenPopOptionInstanceFixture.ShouldBeAssignableTo<DescribeSoftphoneScreenPopOption>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DescribeSoftphoneScreenPopOption) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DescribeSoftphoneScreenPopOption_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DescribeSoftphoneScreenPopOption instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _describeSoftphoneScreenPopOptionInstanceType.ShouldNotBeNull();
            _describeSoftphoneScreenPopOptionInstance.ShouldNotBeNull();
            _describeSoftphoneScreenPopOptionInstanceFixture.ShouldNotBeNull();
            _describeSoftphoneScreenPopOptionInstance.ShouldBeAssignableTo<DescribeSoftphoneScreenPopOption>();
            _describeSoftphoneScreenPopOptionInstanceFixture.ShouldBeAssignableTo<DescribeSoftphoneScreenPopOption>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DescribeSoftphoneScreenPopOption) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertymatchType)]
        [TestCaseGeneric(typeof(string) , PropertyscreenPopData)]
        [TestCaseGeneric(typeof(string) , PropertyscreenPopType)]
        public void AUT_DescribeSoftphoneScreenPopOption_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DescribeSoftphoneScreenPopOption, T>(_describeSoftphoneScreenPopOptionInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSoftphoneScreenPopOption) => Property (matchType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSoftphoneScreenPopOption_Public_Class_matchType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertymatchType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSoftphoneScreenPopOption) => Property (screenPopData) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSoftphoneScreenPopOption_Public_Class_screenPopData_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyscreenPopData);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSoftphoneScreenPopOption) => Property (screenPopType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSoftphoneScreenPopOption_Public_Class_screenPopType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyscreenPopType);

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
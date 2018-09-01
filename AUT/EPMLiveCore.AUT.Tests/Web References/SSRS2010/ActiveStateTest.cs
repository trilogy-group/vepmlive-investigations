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
using EPMLiveCore.SSRS2010;
using ActiveState = EPMLiveCore.SSRS2010;

namespace EPMLiveCore.SSRS2010
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SSRS2010.ActiveState" />)
    ///     and namespace <see cref="EPMLiveCore.SSRS2010"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ActiveStateTest : AbstractBaseSetupTypedTest<ActiveState>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ActiveState) Initializer

        private const string PropertyDeliveryExtensionRemoved = "DeliveryExtensionRemoved";
        private const string PropertyDeliveryExtensionRemovedSpecified = "DeliveryExtensionRemovedSpecified";
        private const string PropertySharedDataSourceRemoved = "SharedDataSourceRemoved";
        private const string PropertySharedDataSourceRemovedSpecified = "SharedDataSourceRemovedSpecified";
        private const string PropertyMissingParameterValue = "MissingParameterValue";
        private const string PropertyMissingParameterValueSpecified = "MissingParameterValueSpecified";
        private const string PropertyInvalidParameterValue = "InvalidParameterValue";
        private const string PropertyInvalidParameterValueSpecified = "InvalidParameterValueSpecified";
        private const string PropertyUnknownReportParameter = "UnknownReportParameter";
        private const string PropertyUnknownReportParameterSpecified = "UnknownReportParameterSpecified";
        private const string PropertyDisabledByUser = "DisabledByUser";
        private const string PropertyDisabledByUserSpecified = "DisabledByUserSpecified";
        private const string FielddeliveryExtensionRemovedField = "deliveryExtensionRemovedField";
        private const string FielddeliveryExtensionRemovedFieldSpecified = "deliveryExtensionRemovedFieldSpecified";
        private const string FieldsharedDataSourceRemovedField = "sharedDataSourceRemovedField";
        private const string FieldsharedDataSourceRemovedFieldSpecified = "sharedDataSourceRemovedFieldSpecified";
        private const string FieldmissingParameterValueField = "missingParameterValueField";
        private const string FieldmissingParameterValueFieldSpecified = "missingParameterValueFieldSpecified";
        private const string FieldinvalidParameterValueField = "invalidParameterValueField";
        private const string FieldinvalidParameterValueFieldSpecified = "invalidParameterValueFieldSpecified";
        private const string FieldunknownReportParameterField = "unknownReportParameterField";
        private const string FieldunknownReportParameterFieldSpecified = "unknownReportParameterFieldSpecified";
        private const string FielddisabledByUserField = "disabledByUserField";
        private const string FielddisabledByUserFieldSpecified = "disabledByUserFieldSpecified";
        private Type _activeStateInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ActiveState _activeStateInstance;
        private ActiveState _activeStateInstanceFixture;

        #region General Initializer : Class (ActiveState) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ActiveState" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _activeStateInstanceType = typeof(ActiveState);
            _activeStateInstanceFixture = Create(true);
            _activeStateInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ActiveState)

        #region General Initializer : Class (ActiveState) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ActiveState" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyDeliveryExtensionRemoved)]
        [TestCase(PropertyDeliveryExtensionRemovedSpecified)]
        [TestCase(PropertySharedDataSourceRemoved)]
        [TestCase(PropertySharedDataSourceRemovedSpecified)]
        [TestCase(PropertyMissingParameterValue)]
        [TestCase(PropertyMissingParameterValueSpecified)]
        [TestCase(PropertyInvalidParameterValue)]
        [TestCase(PropertyInvalidParameterValueSpecified)]
        [TestCase(PropertyUnknownReportParameter)]
        [TestCase(PropertyUnknownReportParameterSpecified)]
        [TestCase(PropertyDisabledByUser)]
        [TestCase(PropertyDisabledByUserSpecified)]
        public void AUT_ActiveState_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_activeStateInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ActiveState) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ActiveState" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielddeliveryExtensionRemovedField)]
        [TestCase(FielddeliveryExtensionRemovedFieldSpecified)]
        [TestCase(FieldsharedDataSourceRemovedField)]
        [TestCase(FieldsharedDataSourceRemovedFieldSpecified)]
        [TestCase(FieldmissingParameterValueField)]
        [TestCase(FieldmissingParameterValueFieldSpecified)]
        [TestCase(FieldinvalidParameterValueField)]
        [TestCase(FieldinvalidParameterValueFieldSpecified)]
        [TestCase(FieldunknownReportParameterField)]
        [TestCase(FieldunknownReportParameterFieldSpecified)]
        [TestCase(FielddisabledByUserField)]
        [TestCase(FielddisabledByUserFieldSpecified)]
        public void AUT_ActiveState_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_activeStateInstanceFixture, 
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
        ///     Class (<see cref="ActiveState" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ActiveState_Is_Instance_Present_Test()
        {
            // Assert
            _activeStateInstanceType.ShouldNotBeNull();
            _activeStateInstance.ShouldNotBeNull();
            _activeStateInstanceFixture.ShouldNotBeNull();
            _activeStateInstance.ShouldBeAssignableTo<ActiveState>();
            _activeStateInstanceFixture.ShouldBeAssignableTo<ActiveState>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ActiveState) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ActiveState_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ActiveState instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _activeStateInstanceType.ShouldNotBeNull();
            _activeStateInstance.ShouldNotBeNull();
            _activeStateInstanceFixture.ShouldNotBeNull();
            _activeStateInstance.ShouldBeAssignableTo<ActiveState>();
            _activeStateInstanceFixture.ShouldBeAssignableTo<ActiveState>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ActiveState) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertyDeliveryExtensionRemoved)]
        [TestCaseGeneric(typeof(bool) , PropertyDeliveryExtensionRemovedSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertySharedDataSourceRemoved)]
        [TestCaseGeneric(typeof(bool) , PropertySharedDataSourceRemovedSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyMissingParameterValue)]
        [TestCaseGeneric(typeof(bool) , PropertyMissingParameterValueSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyInvalidParameterValue)]
        [TestCaseGeneric(typeof(bool) , PropertyInvalidParameterValueSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyUnknownReportParameter)]
        [TestCaseGeneric(typeof(bool) , PropertyUnknownReportParameterSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyDisabledByUser)]
        [TestCaseGeneric(typeof(bool) , PropertyDisabledByUserSpecified)]
        public void AUT_ActiveState_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ActiveState, T>(_activeStateInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ActiveState) => Property (DeliveryExtensionRemoved) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ActiveState_Public_Class_DeliveryExtensionRemoved_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDeliveryExtensionRemoved);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ActiveState) => Property (DeliveryExtensionRemovedSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ActiveState_Public_Class_DeliveryExtensionRemovedSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDeliveryExtensionRemovedSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ActiveState) => Property (DisabledByUser) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ActiveState_Public_Class_DisabledByUser_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDisabledByUser);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ActiveState) => Property (DisabledByUserSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ActiveState_Public_Class_DisabledByUserSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDisabledByUserSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ActiveState) => Property (InvalidParameterValue) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ActiveState_Public_Class_InvalidParameterValue_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyInvalidParameterValue);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ActiveState) => Property (InvalidParameterValueSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ActiveState_Public_Class_InvalidParameterValueSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyInvalidParameterValueSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ActiveState) => Property (MissingParameterValue) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ActiveState_Public_Class_MissingParameterValue_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyMissingParameterValue);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ActiveState) => Property (MissingParameterValueSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ActiveState_Public_Class_MissingParameterValueSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyMissingParameterValueSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ActiveState) => Property (SharedDataSourceRemoved) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ActiveState_Public_Class_SharedDataSourceRemoved_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySharedDataSourceRemoved);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ActiveState) => Property (SharedDataSourceRemovedSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ActiveState_Public_Class_SharedDataSourceRemovedSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySharedDataSourceRemovedSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ActiveState) => Property (UnknownReportParameter) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ActiveState_Public_Class_UnknownReportParameter_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyUnknownReportParameter);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ActiveState) => Property (UnknownReportParameterSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ActiveState_Public_Class_UnknownReportParameterSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyUnknownReportParameterSpecified);

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
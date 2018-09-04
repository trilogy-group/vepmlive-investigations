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
using DescribeLayout = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.DescribeLayout" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DescribeLayoutTest : AbstractBaseSetupTypedTest<DescribeLayout>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DescribeLayout) Initializer

        private const string PropertybuttonLayoutSection = "buttonLayoutSection";
        private const string PropertydetailLayoutSections = "detailLayoutSections";
        private const string PropertyeditLayoutSections = "editLayoutSections";
        private const string Propertyid = "id";
        private const string PropertyrelatedLists = "relatedLists";
        private const string FieldbuttonLayoutSectionField = "buttonLayoutSectionField";
        private const string FielddetailLayoutSectionsField = "detailLayoutSectionsField";
        private const string FieldeditLayoutSectionsField = "editLayoutSectionsField";
        private const string FieldidField = "idField";
        private const string FieldrelatedListsField = "relatedListsField";
        private Type _describeLayoutInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DescribeLayout _describeLayoutInstance;
        private DescribeLayout _describeLayoutInstanceFixture;

        #region General Initializer : Class (DescribeLayout) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DescribeLayout" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _describeLayoutInstanceType = typeof(DescribeLayout);
            _describeLayoutInstanceFixture = Create(true);
            _describeLayoutInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DescribeLayout)

        #region General Initializer : Class (DescribeLayout) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeLayout" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertybuttonLayoutSection)]
        [TestCase(PropertydetailLayoutSections)]
        [TestCase(PropertyeditLayoutSections)]
        [TestCase(Propertyid)]
        [TestCase(PropertyrelatedLists)]
        public void AUT_DescribeLayout_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_describeLayoutInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DescribeLayout) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeLayout" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldbuttonLayoutSectionField)]
        [TestCase(FielddetailLayoutSectionsField)]
        [TestCase(FieldeditLayoutSectionsField)]
        [TestCase(FieldidField)]
        [TestCase(FieldrelatedListsField)]
        public void AUT_DescribeLayout_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_describeLayoutInstanceFixture, 
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
        ///     Class (<see cref="DescribeLayout" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DescribeLayout_Is_Instance_Present_Test()
        {
            // Assert
            _describeLayoutInstanceType.ShouldNotBeNull();
            _describeLayoutInstance.ShouldNotBeNull();
            _describeLayoutInstanceFixture.ShouldNotBeNull();
            _describeLayoutInstance.ShouldBeAssignableTo<DescribeLayout>();
            _describeLayoutInstanceFixture.ShouldBeAssignableTo<DescribeLayout>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DescribeLayout) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DescribeLayout_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DescribeLayout instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _describeLayoutInstanceType.ShouldNotBeNull();
            _describeLayoutInstance.ShouldNotBeNull();
            _describeLayoutInstanceFixture.ShouldNotBeNull();
            _describeLayoutInstance.ShouldBeAssignableTo<DescribeLayout>();
            _describeLayoutInstanceFixture.ShouldBeAssignableTo<DescribeLayout>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DescribeLayout) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(DescribeLayoutButton[]) , PropertybuttonLayoutSection)]
        [TestCaseGeneric(typeof(DescribeLayoutSection[]) , PropertydetailLayoutSections)]
        [TestCaseGeneric(typeof(DescribeLayoutSection[]) , PropertyeditLayoutSections)]
        [TestCaseGeneric(typeof(string) , Propertyid)]
        [TestCaseGeneric(typeof(RelatedList[]) , PropertyrelatedLists)]
        public void AUT_DescribeLayout_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DescribeLayout, T>(_describeLayoutInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeLayout) => Property (buttonLayoutSection) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeLayout_buttonLayoutSection_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertybuttonLayoutSection);
            Action currentAction = () => propertyInfo.SetValue(_describeLayoutInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeLayout) => Property (buttonLayoutSection) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeLayout_Public_Class_buttonLayoutSection_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertybuttonLayoutSection);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeLayout) => Property (detailLayoutSections) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeLayout_detailLayoutSections_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertydetailLayoutSections);
            Action currentAction = () => propertyInfo.SetValue(_describeLayoutInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeLayout) => Property (detailLayoutSections) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeLayout_Public_Class_detailLayoutSections_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydetailLayoutSections);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeLayout) => Property (editLayoutSections) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeLayout_editLayoutSections_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyeditLayoutSections);
            Action currentAction = () => propertyInfo.SetValue(_describeLayoutInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeLayout) => Property (editLayoutSections) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeLayout_Public_Class_editLayoutSections_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyeditLayoutSections);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeLayout) => Property (id) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeLayout_Public_Class_id_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyid);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeLayout) => Property (relatedLists) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeLayout_relatedLists_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyrelatedLists);
            Action currentAction = () => propertyInfo.SetValue(_describeLayoutInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeLayout) => Property (relatedLists) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeLayout_Public_Class_relatedLists_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrelatedLists);

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
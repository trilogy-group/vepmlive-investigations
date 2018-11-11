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
using EPMLiveCore.SSRS2005;
using ItemNamespaceHeader = EPMLiveCore.SSRS2005;

namespace EPMLiveCore.SSRS2005
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SSRS2005.ItemNamespaceHeader" />)
    ///     and namespace <see cref="EPMLiveCore.SSRS2005"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ItemNamespaceHeaderTest : AbstractBaseSetupTypedTest<ItemNamespaceHeader>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ItemNamespaceHeader) Initializer

        private const string PropertyItemNamespace = "ItemNamespace";
        private const string PropertyAnyAttr = "AnyAttr";
        private const string FielditemNamespaceField = "itemNamespaceField";
        private const string FieldanyAttrField = "anyAttrField";
        private Type _itemNamespaceHeaderInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ItemNamespaceHeader _itemNamespaceHeaderInstance;
        private ItemNamespaceHeader _itemNamespaceHeaderInstanceFixture;

        #region General Initializer : Class (ItemNamespaceHeader) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ItemNamespaceHeader" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _itemNamespaceHeaderInstanceType = typeof(ItemNamespaceHeader);
            _itemNamespaceHeaderInstanceFixture = Create(true);
            _itemNamespaceHeaderInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ItemNamespaceHeader)

        #region General Initializer : Class (ItemNamespaceHeader) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ItemNamespaceHeader" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyItemNamespace)]
        [TestCase(PropertyAnyAttr)]
        public void AUT_ItemNamespaceHeader_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_itemNamespaceHeaderInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ItemNamespaceHeader) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ItemNamespaceHeader" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielditemNamespaceField)]
        [TestCase(FieldanyAttrField)]
        public void AUT_ItemNamespaceHeader_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_itemNamespaceHeaderInstanceFixture, 
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
        ///     Class (<see cref="ItemNamespaceHeader" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ItemNamespaceHeader_Is_Instance_Present_Test()
        {
            // Assert
            _itemNamespaceHeaderInstanceType.ShouldNotBeNull();
            _itemNamespaceHeaderInstance.ShouldNotBeNull();
            _itemNamespaceHeaderInstanceFixture.ShouldNotBeNull();
            _itemNamespaceHeaderInstance.ShouldBeAssignableTo<ItemNamespaceHeader>();
            _itemNamespaceHeaderInstanceFixture.ShouldBeAssignableTo<ItemNamespaceHeader>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ItemNamespaceHeader) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ItemNamespaceHeader_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ItemNamespaceHeader instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _itemNamespaceHeaderInstanceType.ShouldNotBeNull();
            _itemNamespaceHeaderInstance.ShouldNotBeNull();
            _itemNamespaceHeaderInstanceFixture.ShouldNotBeNull();
            _itemNamespaceHeaderInstance.ShouldBeAssignableTo<ItemNamespaceHeader>();
            _itemNamespaceHeaderInstanceFixture.ShouldBeAssignableTo<ItemNamespaceHeader>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ItemNamespaceHeader) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(ItemNamespaceEnum) , PropertyItemNamespace)]
        [TestCaseGeneric(typeof(System.Xml.XmlAttribute[]) , PropertyAnyAttr)]
        public void AUT_ItemNamespaceHeader_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ItemNamespaceHeader, T>(_itemNamespaceHeaderInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ItemNamespaceHeader) => Property (AnyAttr) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ItemNamespaceHeader_AnyAttr_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyAnyAttr);
            Action currentAction = () => propertyInfo.SetValue(_itemNamespaceHeaderInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ItemNamespaceHeader) => Property (AnyAttr) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ItemNamespaceHeader_Public_Class_AnyAttr_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ItemNamespaceHeader) => Property (ItemNamespace) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ItemNamespaceHeader_ItemNamespace_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyItemNamespace);
            Action currentAction = () => propertyInfo.SetValue(_itemNamespaceHeaderInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ItemNamespaceHeader) => Property (ItemNamespace) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ItemNamespaceHeader_Public_Class_ItemNamespace_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyItemNamespace);

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
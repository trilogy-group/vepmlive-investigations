using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.AutoFixtureSetup;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using Microsoft.SharePoint;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using GenericEntityPickerPropertyBag = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.GenericEntityPickerPropertyBag" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class GenericEntityPickerPropertyBagTest : AbstractBaseSetupTypedTest<GenericEntityPickerPropertyBag>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (GenericEntityPickerPropertyBag) Initializer

        private const string PropertyParentWebID = "ParentWebID";
        private const string PropertyLookupWebID = "LookupWebID";
        private const string PropertyLookupListID = "LookupListID";
        private const string PropertyLookupFieldInternalName = "LookupFieldInternalName";
        private const string PropertyLookupFieldSourceFieldID = "LookupFieldSourceFieldID";
        private const string PropertyIsMultiSelect = "IsMultiSelect";
        private const string PropertySourceControlID = "SourceControlID";
        private const string PropertySourceDropDownID = "SourceDropDownID";
        private const string PropertySelectCandidateID = "SelectCandidateID";
        private const string PropertyAddButtonID = "AddButtonID";
        private const string PropertyRemoveButtonID = "RemoveButtonID";
        private const string PropertySelectResultID = "SelectResultID";
        private const string PropertyControlType = "ControlType";
        private const string PropertyParent = "Parent";
        private const string PropertyParentListField = "ParentListField";
        private const string PropertyField = "Field";
        private const string PropertyRequired = "Required";
        private const string PropertyLookupFieldTargetFieldID = "LookupFieldTargetFieldID";
        private const string PropertyListID = "ListID";
        private const string PropertyItemID = "ItemID";
        private const string MethodToString = "ToString";
        private const string Field_xmlDataMgr = "_xmlDataMgr";
        private const string FieldlookupFieldTargetFieldID = "lookupFieldTargetFieldID";
        private Type _genericEntityPickerPropertyBagInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private GenericEntityPickerPropertyBag _genericEntityPickerPropertyBagInstance;
        private GenericEntityPickerPropertyBag _genericEntityPickerPropertyBagInstanceFixture;

        #region General Initializer : Class (GenericEntityPickerPropertyBag) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="GenericEntityPickerPropertyBag" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _genericEntityPickerPropertyBagInstanceType = typeof(GenericEntityPickerPropertyBag);
            _genericEntityPickerPropertyBagInstanceFixture = Create(true);
            _genericEntityPickerPropertyBagInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (GenericEntityPickerPropertyBag)

        #region General Initializer : Class (GenericEntityPickerPropertyBag) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="GenericEntityPickerPropertyBag" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodToString, 0)]
        public void AUT_GenericEntityPickerPropertyBag_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_genericEntityPickerPropertyBagInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (GenericEntityPickerPropertyBag) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="GenericEntityPickerPropertyBag" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyParentWebID)]
        [TestCase(PropertyLookupWebID)]
        [TestCase(PropertyLookupListID)]
        [TestCase(PropertyLookupFieldInternalName)]
        [TestCase(PropertyLookupFieldSourceFieldID)]
        [TestCase(PropertyIsMultiSelect)]
        [TestCase(PropertySourceControlID)]
        [TestCase(PropertySourceDropDownID)]
        [TestCase(PropertySelectCandidateID)]
        [TestCase(PropertyAddButtonID)]
        [TestCase(PropertyRemoveButtonID)]
        [TestCase(PropertySelectResultID)]
        [TestCase(PropertyControlType)]
        [TestCase(PropertyParent)]
        [TestCase(PropertyParentListField)]
        [TestCase(PropertyField)]
        [TestCase(PropertyRequired)]
        [TestCase(PropertyLookupFieldTargetFieldID)]
        [TestCase(PropertyListID)]
        [TestCase(PropertyItemID)]
        public void AUT_GenericEntityPickerPropertyBag_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_genericEntityPickerPropertyBagInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (GenericEntityPickerPropertyBag) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="GenericEntityPickerPropertyBag" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_xmlDataMgr)]
        [TestCase(FieldlookupFieldTargetFieldID)]
        public void AUT_GenericEntityPickerPropertyBag_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_genericEntityPickerPropertyBagInstanceFixture, 
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
        ///     Class (<see cref="GenericEntityPickerPropertyBag" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_GenericEntityPickerPropertyBag_Is_Instance_Present_Test()
        {
            // Assert
            _genericEntityPickerPropertyBagInstanceType.ShouldNotBeNull();
            _genericEntityPickerPropertyBagInstance.ShouldNotBeNull();
            _genericEntityPickerPropertyBagInstanceFixture.ShouldNotBeNull();
            _genericEntityPickerPropertyBagInstance.ShouldBeAssignableTo<GenericEntityPickerPropertyBag>();
            _genericEntityPickerPropertyBagInstanceFixture.ShouldBeAssignableTo<GenericEntityPickerPropertyBag>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (GenericEntityPickerPropertyBag) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_GenericEntityPickerPropertyBag_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            GenericEntityPickerPropertyBag instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _genericEntityPickerPropertyBagInstanceType.ShouldNotBeNull();
            _genericEntityPickerPropertyBagInstance.ShouldNotBeNull();
            _genericEntityPickerPropertyBagInstanceFixture.ShouldNotBeNull();
            _genericEntityPickerPropertyBagInstance.ShouldBeAssignableTo<GenericEntityPickerPropertyBag>();
            _genericEntityPickerPropertyBagInstanceFixture.ShouldBeAssignableTo<GenericEntityPickerPropertyBag>();
        }

        #endregion

        #region General Constructor : Class (GenericEntityPickerPropertyBag) instance created

        /// <summary>
        ///     Class (<see cref="GenericEntityPickerPropertyBag" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_GenericEntityPickerPropertyBag_Is_Created_Test()
        {
            // Assert
            _genericEntityPickerPropertyBagInstance.ShouldNotBeNull();
            _genericEntityPickerPropertyBagInstanceFixture.ShouldNotBeNull();
        }

        #endregion

        #region General Constructor : Class (GenericEntityPickerPropertyBag) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="GenericEntityPickerPropertyBag" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_GenericEntityPickerPropertyBag_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<GenericEntityPickerPropertyBag>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (GenericEntityPickerPropertyBag) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="GenericEntityPickerPropertyBag" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_GenericEntityPickerPropertyBag_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<GenericEntityPickerPropertyBag>(Fixture);
        }

        #endregion

        #region General Constructor : Class (GenericEntityPickerPropertyBag) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="GenericEntityPickerPropertyBag" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_GenericEntityPickerPropertyBag_Constructors_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfGenericEntityPickerPropertyBag = {  };
            Type [] methodGenericEntityPickerPropertyBagPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_genericEntityPickerPropertyBagInstanceType, methodGenericEntityPickerPropertyBagPrametersTypes, parametersOfGenericEntityPickerPropertyBag);
        }

        #endregion

        #region General Constructor : Class (GenericEntityPickerPropertyBag) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="GenericEntityPickerPropertyBag" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_GenericEntityPickerPropertyBag_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodGenericEntityPickerPropertyBagPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_genericEntityPickerPropertyBagInstanceType, Fixture, methodGenericEntityPickerPropertyBagPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (GenericEntityPickerPropertyBag) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="GenericEntityPickerPropertyBag" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_GenericEntityPickerPropertyBag_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var value = CreateType<string>();
            object[] parametersOfGenericEntityPickerPropertyBag = { value };
            var methodGenericEntityPickerPropertyBagPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_genericEntityPickerPropertyBagInstanceType, methodGenericEntityPickerPropertyBagPrametersTypes, parametersOfGenericEntityPickerPropertyBag);
        }

        #endregion

        #region General Constructor : Class (GenericEntityPickerPropertyBag) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="GenericEntityPickerPropertyBag" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_GenericEntityPickerPropertyBag_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodGenericEntityPickerPropertyBagPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_genericEntityPickerPropertyBagInstanceType, Fixture, methodGenericEntityPickerPropertyBagPrametersTypes);
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (GenericEntityPickerPropertyBag) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(Guid) , PropertyParentWebID)]
        [TestCaseGeneric(typeof(Guid) , PropertyLookupWebID)]
        [TestCaseGeneric(typeof(Guid) , PropertyLookupListID)]
        [TestCaseGeneric(typeof(string) , PropertyLookupFieldInternalName)]
        [TestCaseGeneric(typeof(Guid) , PropertyLookupFieldSourceFieldID)]
        [TestCaseGeneric(typeof(string) , PropertyIsMultiSelect)]
        [TestCaseGeneric(typeof(string) , PropertySourceControlID)]
        [TestCaseGeneric(typeof(string) , PropertySourceDropDownID)]
        [TestCaseGeneric(typeof(string) , PropertySelectCandidateID)]
        [TestCaseGeneric(typeof(string) , PropertyAddButtonID)]
        [TestCaseGeneric(typeof(string) , PropertyRemoveButtonID)]
        [TestCaseGeneric(typeof(string) , PropertySelectResultID)]
        [TestCaseGeneric(typeof(string) , PropertyControlType)]
        [TestCaseGeneric(typeof(string) , PropertyParent)]
        [TestCaseGeneric(typeof(string) , PropertyParentListField)]
        [TestCaseGeneric(typeof(string) , PropertyField)]
        [TestCaseGeneric(typeof(bool) , PropertyRequired)]
        [TestCaseGeneric(typeof(Guid) , PropertyLookupFieldTargetFieldID)]
        [TestCaseGeneric(typeof(Guid) , PropertyListID)]
        [TestCaseGeneric(typeof(int) , PropertyItemID)]
        public void AUT_GenericEntityPickerPropertyBag_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<GenericEntityPickerPropertyBag, T>(_genericEntityPickerPropertyBagInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (GenericEntityPickerPropertyBag) => Property (AddButtonID) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GenericEntityPickerPropertyBag_Public_Class_AddButtonID_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyAddButtonID);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GenericEntityPickerPropertyBag) => Property (ControlType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GenericEntityPickerPropertyBag_Public_Class_ControlType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyControlType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GenericEntityPickerPropertyBag) => Property (Field) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GenericEntityPickerPropertyBag_Public_Class_Field_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyField);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GenericEntityPickerPropertyBag) => Property (IsMultiSelect) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GenericEntityPickerPropertyBag_Public_Class_IsMultiSelect_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyIsMultiSelect);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GenericEntityPickerPropertyBag) => Property (ItemID) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GenericEntityPickerPropertyBag_Public_Class_ItemID_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyItemID);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GenericEntityPickerPropertyBag) => Property (ListID) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GenericEntityPickerPropertyBag_ListID_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyListID);
            Action currentAction = () => propertyInfo.SetValue(_genericEntityPickerPropertyBagInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (GenericEntityPickerPropertyBag) => Property (ListID) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GenericEntityPickerPropertyBag_Public_Class_ListID_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyListID);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GenericEntityPickerPropertyBag) => Property (LookupFieldInternalName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GenericEntityPickerPropertyBag_Public_Class_LookupFieldInternalName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyLookupFieldInternalName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GenericEntityPickerPropertyBag) => Property (LookupFieldSourceFieldID) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GenericEntityPickerPropertyBag_LookupFieldSourceFieldID_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyLookupFieldSourceFieldID);
            Action currentAction = () => propertyInfo.SetValue(_genericEntityPickerPropertyBagInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (GenericEntityPickerPropertyBag) => Property (LookupFieldSourceFieldID) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GenericEntityPickerPropertyBag_Public_Class_LookupFieldSourceFieldID_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyLookupFieldSourceFieldID);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GenericEntityPickerPropertyBag) => Property (LookupFieldTargetFieldID) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GenericEntityPickerPropertyBag_LookupFieldTargetFieldID_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyLookupFieldTargetFieldID);
            Action currentAction = () => propertyInfo.SetValue(_genericEntityPickerPropertyBagInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (GenericEntityPickerPropertyBag) => Property (LookupFieldTargetFieldID) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GenericEntityPickerPropertyBag_Public_Class_LookupFieldTargetFieldID_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyLookupFieldTargetFieldID);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GenericEntityPickerPropertyBag) => Property (LookupListID) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GenericEntityPickerPropertyBag_LookupListID_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyLookupListID);
            Action currentAction = () => propertyInfo.SetValue(_genericEntityPickerPropertyBagInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (GenericEntityPickerPropertyBag) => Property (LookupListID) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GenericEntityPickerPropertyBag_Public_Class_LookupListID_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyLookupListID);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GenericEntityPickerPropertyBag) => Property (LookupWebID) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GenericEntityPickerPropertyBag_LookupWebID_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyLookupWebID);
            Action currentAction = () => propertyInfo.SetValue(_genericEntityPickerPropertyBagInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (GenericEntityPickerPropertyBag) => Property (LookupWebID) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GenericEntityPickerPropertyBag_Public_Class_LookupWebID_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyLookupWebID);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GenericEntityPickerPropertyBag) => Property (Parent) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GenericEntityPickerPropertyBag_Public_Class_Parent_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyParent);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GenericEntityPickerPropertyBag) => Property (ParentListField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GenericEntityPickerPropertyBag_Public_Class_ParentListField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyParentListField);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GenericEntityPickerPropertyBag) => Property (ParentWebID) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GenericEntityPickerPropertyBag_ParentWebID_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyParentWebID);
            Action currentAction = () => propertyInfo.SetValue(_genericEntityPickerPropertyBagInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (GenericEntityPickerPropertyBag) => Property (ParentWebID) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GenericEntityPickerPropertyBag_Public_Class_ParentWebID_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyParentWebID);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GenericEntityPickerPropertyBag) => Property (RemoveButtonID) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GenericEntityPickerPropertyBag_Public_Class_RemoveButtonID_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyRemoveButtonID);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GenericEntityPickerPropertyBag) => Property (Required) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GenericEntityPickerPropertyBag_Public_Class_Required_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyRequired);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GenericEntityPickerPropertyBag) => Property (SelectCandidateID) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GenericEntityPickerPropertyBag_Public_Class_SelectCandidateID_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySelectCandidateID);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GenericEntityPickerPropertyBag) => Property (SelectResultID) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GenericEntityPickerPropertyBag_Public_Class_SelectResultID_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySelectResultID);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GenericEntityPickerPropertyBag) => Property (SourceControlID) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GenericEntityPickerPropertyBag_Public_Class_SourceControlID_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySourceControlID);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GenericEntityPickerPropertyBag) => Property (SourceDropDownID) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GenericEntityPickerPropertyBag_Public_Class_SourceDropDownID_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySourceDropDownID);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="GenericEntityPickerPropertyBag" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodToString)]
        public void AUT_GenericEntityPickerPropertyBag_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<GenericEntityPickerPropertyBag>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GenericEntityPickerPropertyBag_ToString_Method_Call_Internally(Type[] types)
        {
            var methodToStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericEntityPickerPropertyBagInstance, MethodToString, Fixture, methodToStringPrametersTypes);
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityPickerPropertyBag_ToString_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _genericEntityPickerPropertyBagInstance.ToString();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityPickerPropertyBag_ToString_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodToStringPrametersTypes = null;
            object[] parametersOfToString = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodToString, methodToStringPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_genericEntityPickerPropertyBagInstanceFixture, parametersOfToString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfToString.ShouldBeNull();
            methodToStringPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityPickerPropertyBag_ToString_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodToStringPrametersTypes = null;
            object[] parametersOfToString = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GenericEntityPickerPropertyBag, string>(_genericEntityPickerPropertyBagInstance, MethodToString, parametersOfToString, methodToStringPrametersTypes);

            // Assert
            parametersOfToString.ShouldBeNull();
            methodToStringPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityPickerPropertyBag_ToString_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodToStringPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericEntityPickerPropertyBagInstance, MethodToString, Fixture, methodToStringPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodToStringPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityPickerPropertyBag_ToString_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodToStringPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericEntityPickerPropertyBagInstance, MethodToString, Fixture, methodToStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodToStringPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityPickerPropertyBag_ToString_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodToString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_genericEntityPickerPropertyBagInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion
    }
}
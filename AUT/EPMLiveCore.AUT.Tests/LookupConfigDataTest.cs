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
using EPMLiveCore;
using LookupConfigData = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.LookupConfigData" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class LookupConfigDataTest : AbstractBaseSetupTypedTest<LookupConfigData>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (LookupConfigData) Initializer

        private const string PropertyField = "Field";
        private const string PropertyType = "Type";
        private const string PropertyParent = "Parent";
        private const string PropertyParentListField = "ParentListField";
        private const string PropertySecurity = "Security";
        private const string PropertyIsParent = "IsParent";
        private const string Fielddelimiter = "delimiter";
        private const string Field_field = "_field";
        private const string Field_type = "_type";
        private const string Field_parent = "_parent";
        private const string Field_parentListField = "_parentListField";
        private const string Field_security = "_security";
        private const string Field_isParent = "_isParent";
        private Type _lookupConfigDataInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private LookupConfigData _lookupConfigDataInstance;
        private LookupConfigData _lookupConfigDataInstanceFixture;

        #region General Initializer : Class (LookupConfigData) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="LookupConfigData" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _lookupConfigDataInstanceType = typeof(LookupConfigData);
            _lookupConfigDataInstanceFixture = Create(true);
            _lookupConfigDataInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (LookupConfigData)

        #region General Initializer : Class (LookupConfigData) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="LookupConfigData" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyField)]
        [TestCase(PropertyType)]
        [TestCase(PropertyParent)]
        [TestCase(PropertyParentListField)]
        [TestCase(PropertySecurity)]
        [TestCase(PropertyIsParent)]
        public void AUT_LookupConfigData_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_lookupConfigDataInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (LookupConfigData) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="LookupConfigData" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fielddelimiter)]
        [TestCase(Field_field)]
        [TestCase(Field_type)]
        [TestCase(Field_parent)]
        [TestCase(Field_parentListField)]
        [TestCase(Field_security)]
        [TestCase(Field_isParent)]
        public void AUT_LookupConfigData_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_lookupConfigDataInstanceFixture, 
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
        ///     Class (<see cref="LookupConfigData" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_LookupConfigData_Is_Instance_Present_Test()
        {
            // Assert
            _lookupConfigDataInstanceType.ShouldNotBeNull();
            _lookupConfigDataInstance.ShouldNotBeNull();
            _lookupConfigDataInstanceFixture.ShouldNotBeNull();
            _lookupConfigDataInstance.ShouldBeAssignableTo<LookupConfigData>();
            _lookupConfigDataInstanceFixture.ShouldBeAssignableTo<LookupConfigData>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (LookupConfigData) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_LookupConfigData_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            LookupConfigData instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _lookupConfigDataInstanceType.ShouldNotBeNull();
            _lookupConfigDataInstance.ShouldNotBeNull();
            _lookupConfigDataInstanceFixture.ShouldNotBeNull();
            _lookupConfigDataInstance.ShouldBeAssignableTo<LookupConfigData>();
            _lookupConfigDataInstanceFixture.ShouldBeAssignableTo<LookupConfigData>();
        }

        #endregion

        #region General Constructor : Class (LookupConfigData) instance created

        /// <summary>
        ///     Class (<see cref="LookupConfigData" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_LookupConfigData_Is_Created_Test()
        {
            // Assert
            _lookupConfigDataInstance.ShouldNotBeNull();
            _lookupConfigDataInstanceFixture.ShouldNotBeNull();
        }

        #endregion

        #region General Constructor : Class (LookupConfigData) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="LookupConfigData" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_LookupConfigData_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<LookupConfigData>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (LookupConfigData) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="LookupConfigData" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_LookupConfigData_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<LookupConfigData>(Fixture);
        }

        #endregion

        #region General Constructor : Class (LookupConfigData) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="LookupConfigData" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_LookupConfigData_Constructors_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfLookupConfigData = {  };
            Type [] methodLookupConfigDataPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_lookupConfigDataInstanceType, methodLookupConfigDataPrametersTypes, parametersOfLookupConfigData);
        }

        #endregion

        #region General Constructor : Class (LookupConfigData) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="LookupConfigData" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_LookupConfigData_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodLookupConfigDataPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_lookupConfigDataInstanceType, Fixture, methodLookupConfigDataPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (LookupConfigData) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="LookupConfigData" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_LookupConfigData_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var data = CreateType<string>();
            object[] parametersOfLookupConfigData = { data };
            var methodLookupConfigDataPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_lookupConfigDataInstanceType, methodLookupConfigDataPrametersTypes, parametersOfLookupConfigData);
        }

        #endregion

        #region General Constructor : Class (LookupConfigData) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="LookupConfigData" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_LookupConfigData_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodLookupConfigDataPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_lookupConfigDataInstanceType, Fixture, methodLookupConfigDataPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (LookupConfigData) Default Assignment Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_LookupConfigData_Constructor_Instantiated_With_Default_Assignments_Test()
        {

            // Act
            var lookupConfigDataInstance  = new LookupConfigData();

            // Asserts
            lookupConfigDataInstance.ShouldNotBeNull();
            lookupConfigDataInstance.ShouldBeAssignableTo<LookupConfigData>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (LookupConfigData) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyField)]
        [TestCaseGeneric(typeof(string) , PropertyType)]
        [TestCaseGeneric(typeof(string) , PropertyParent)]
        [TestCaseGeneric(typeof(string) , PropertyParentListField)]
        [TestCaseGeneric(typeof(bool) , PropertySecurity)]
        [TestCaseGeneric(typeof(bool) , PropertyIsParent)]
        public void AUT_LookupConfigData_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<LookupConfigData, T>(_lookupConfigDataInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (LookupConfigData) => Property (Field) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_LookupConfigData_Public_Class_Field_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (LookupConfigData) => Property (IsParent) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_LookupConfigData_Public_Class_IsParent_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyIsParent);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LookupConfigData) => Property (Parent) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_LookupConfigData_Public_Class_Parent_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (LookupConfigData) => Property (ParentListField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_LookupConfigData_Public_Class_ParentListField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (LookupConfigData) => Property (Security) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_LookupConfigData_Public_Class_Security_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySecurity);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LookupConfigData) => Property (Type) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_LookupConfigData_Public_Class_Type_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyType);

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
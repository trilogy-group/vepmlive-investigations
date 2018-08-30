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
using ModelPerspective = EPMLiveCore.SSRS2010;

namespace EPMLiveCore.SSRS2010
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SSRS2010.ModelPerspective" />)
    ///     and namespace <see cref="EPMLiveCore.SSRS2010"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ModelPerspectiveTest : AbstractBaseSetupTypedTest<ModelPerspective>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ModelPerspective) Initializer

        private const string PropertyID = "ID";
        private const string PropertyName = "Name";
        private const string PropertyDescription = "Description";
        private const string FieldidField = "idField";
        private const string FieldnameField = "nameField";
        private const string FielddescriptionField = "descriptionField";
        private Type _modelPerspectiveInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ModelPerspective _modelPerspectiveInstance;
        private ModelPerspective _modelPerspectiveInstanceFixture;

        #region General Initializer : Class (ModelPerspective) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ModelPerspective" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _modelPerspectiveInstanceType = typeof(ModelPerspective);
            _modelPerspectiveInstanceFixture = Create(true);
            _modelPerspectiveInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ModelPerspective)

        #region General Initializer : Class (ModelPerspective) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ModelPerspective" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyID)]
        [TestCase(PropertyName)]
        [TestCase(PropertyDescription)]
        public void AUT_ModelPerspective_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_modelPerspectiveInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ModelPerspective) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ModelPerspective" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldidField)]
        [TestCase(FieldnameField)]
        [TestCase(FielddescriptionField)]
        public void AUT_ModelPerspective_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_modelPerspectiveInstanceFixture, 
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
        ///     Class (<see cref="ModelPerspective" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ModelPerspective_Is_Instance_Present_Test()
        {
            // Assert
            _modelPerspectiveInstanceType.ShouldNotBeNull();
            _modelPerspectiveInstance.ShouldNotBeNull();
            _modelPerspectiveInstanceFixture.ShouldNotBeNull();
            _modelPerspectiveInstance.ShouldBeAssignableTo<ModelPerspective>();
            _modelPerspectiveInstanceFixture.ShouldBeAssignableTo<ModelPerspective>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ModelPerspective) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ModelPerspective_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ModelPerspective instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _modelPerspectiveInstanceType.ShouldNotBeNull();
            _modelPerspectiveInstance.ShouldNotBeNull();
            _modelPerspectiveInstanceFixture.ShouldNotBeNull();
            _modelPerspectiveInstance.ShouldBeAssignableTo<ModelPerspective>();
            _modelPerspectiveInstanceFixture.ShouldBeAssignableTo<ModelPerspective>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ModelPerspective) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyID)]
        [TestCaseGeneric(typeof(string) , PropertyName)]
        [TestCaseGeneric(typeof(string) , PropertyDescription)]
        public void AUT_ModelPerspective_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ModelPerspective, T>(_modelPerspectiveInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ModelPerspective) => Property (Description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ModelPerspective_Public_Class_Description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDescription);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ModelPerspective) => Property (ID) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ModelPerspective_Public_Class_ID_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyID);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ModelPerspective) => Property (Name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ModelPerspective_Public_Class_Name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyName);

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
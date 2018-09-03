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
using ParameterFieldReference = EPMLiveCore.SSRS2005;

namespace EPMLiveCore.SSRS2005
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SSRS2005.ParameterFieldReference" />)
    ///     and namespace <see cref="EPMLiveCore.SSRS2005"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ParameterFieldReferenceTest : AbstractBaseSetupTypedTest<ParameterFieldReference>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ParameterFieldReference) Initializer

        private const string PropertyParameterName = "ParameterName";
        private const string PropertyFieldAlias = "FieldAlias";
        private const string FieldparameterNameField = "parameterNameField";
        private const string FieldfieldAliasField = "fieldAliasField";
        private Type _parameterFieldReferenceInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ParameterFieldReference _parameterFieldReferenceInstance;
        private ParameterFieldReference _parameterFieldReferenceInstanceFixture;

        #region General Initializer : Class (ParameterFieldReference) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ParameterFieldReference" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _parameterFieldReferenceInstanceType = typeof(ParameterFieldReference);
            _parameterFieldReferenceInstanceFixture = Create(true);
            _parameterFieldReferenceInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ParameterFieldReference)

        #region General Initializer : Class (ParameterFieldReference) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ParameterFieldReference" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyParameterName)]
        [TestCase(PropertyFieldAlias)]
        public void AUT_ParameterFieldReference_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_parameterFieldReferenceInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ParameterFieldReference) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ParameterFieldReference" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldparameterNameField)]
        [TestCase(FieldfieldAliasField)]
        public void AUT_ParameterFieldReference_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_parameterFieldReferenceInstanceFixture, 
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
        ///     Class (<see cref="ParameterFieldReference" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ParameterFieldReference_Is_Instance_Present_Test()
        {
            // Assert
            _parameterFieldReferenceInstanceType.ShouldNotBeNull();
            _parameterFieldReferenceInstance.ShouldNotBeNull();
            _parameterFieldReferenceInstanceFixture.ShouldNotBeNull();
            _parameterFieldReferenceInstance.ShouldBeAssignableTo<ParameterFieldReference>();
            _parameterFieldReferenceInstanceFixture.ShouldBeAssignableTo<ParameterFieldReference>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ParameterFieldReference) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ParameterFieldReference_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ParameterFieldReference instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _parameterFieldReferenceInstanceType.ShouldNotBeNull();
            _parameterFieldReferenceInstance.ShouldNotBeNull();
            _parameterFieldReferenceInstanceFixture.ShouldNotBeNull();
            _parameterFieldReferenceInstance.ShouldBeAssignableTo<ParameterFieldReference>();
            _parameterFieldReferenceInstanceFixture.ShouldBeAssignableTo<ParameterFieldReference>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ParameterFieldReference) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyParameterName)]
        [TestCaseGeneric(typeof(string) , PropertyFieldAlias)]
        public void AUT_ParameterFieldReference_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ParameterFieldReference, T>(_parameterFieldReferenceInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ParameterFieldReference) => Property (FieldAlias) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ParameterFieldReference_Public_Class_FieldAlias_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyFieldAlias);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ParameterFieldReference) => Property (ParameterName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ParameterFieldReference_Public_Class_ParameterName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyParameterName);

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
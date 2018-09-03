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
using SearchCondition = EPMLiveCore.SSRS2005;

namespace EPMLiveCore.SSRS2005
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SSRS2005.SearchCondition" />)
    ///     and namespace <see cref="EPMLiveCore.SSRS2005"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class SearchConditionTest : AbstractBaseSetupTypedTest<SearchCondition>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SearchCondition) Initializer

        private const string PropertyCondition = "Condition";
        private const string PropertyConditionSpecified = "ConditionSpecified";
        private const string FieldconditionField = "conditionField";
        private const string FieldconditionFieldSpecified = "conditionFieldSpecified";
        private Type _searchConditionInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private SearchCondition _searchConditionInstance;
        private SearchCondition _searchConditionInstanceFixture;

        #region General Initializer : Class (SearchCondition) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SearchCondition" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _searchConditionInstanceType = typeof(SearchCondition);
            _searchConditionInstanceFixture = Create(true);
            _searchConditionInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SearchCondition)

        #region General Initializer : Class (SearchCondition) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="SearchCondition" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyCondition)]
        [TestCase(PropertyConditionSpecified)]
        public void AUT_SearchCondition_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_searchConditionInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (SearchCondition) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="SearchCondition" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldconditionField)]
        [TestCase(FieldconditionFieldSpecified)]
        public void AUT_SearchCondition_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_searchConditionInstanceFixture, 
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
        ///     Class (<see cref="SearchCondition" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_SearchCondition_Is_Instance_Present_Test()
        {
            // Assert
            _searchConditionInstanceType.ShouldNotBeNull();
            _searchConditionInstance.ShouldNotBeNull();
            _searchConditionInstanceFixture.ShouldNotBeNull();
            _searchConditionInstance.ShouldBeAssignableTo<SearchCondition>();
            _searchConditionInstanceFixture.ShouldBeAssignableTo<SearchCondition>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (SearchCondition) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_SearchCondition_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            SearchCondition instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _searchConditionInstanceType.ShouldNotBeNull();
            _searchConditionInstance.ShouldNotBeNull();
            _searchConditionInstanceFixture.ShouldNotBeNull();
            _searchConditionInstance.ShouldBeAssignableTo<SearchCondition>();
            _searchConditionInstanceFixture.ShouldBeAssignableTo<SearchCondition>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (SearchCondition) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(ConditionEnum) , PropertyCondition)]
        [TestCaseGeneric(typeof(bool) , PropertyConditionSpecified)]
        public void AUT_SearchCondition_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<SearchCondition, T>(_searchConditionInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (SearchCondition) => Property (Condition) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SearchCondition_Condition_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyCondition);
            Action currentAction = () => propertyInfo.SetValue(_searchConditionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SearchCondition) => Property (Condition) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SearchCondition_Public_Class_Condition_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCondition);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SearchCondition) => Property (ConditionSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SearchCondition_Public_Class_ConditionSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyConditionSpecified);

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
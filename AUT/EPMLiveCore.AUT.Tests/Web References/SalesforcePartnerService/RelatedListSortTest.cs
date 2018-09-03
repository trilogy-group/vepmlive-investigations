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
using RelatedListSort = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.RelatedListSort" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class RelatedListSortTest : AbstractBaseSetupTypedTest<RelatedListSort>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (RelatedListSort) Initializer

        private const string Propertyascending = "ascending";
        private const string Propertycolumn = "column";
        private const string FieldascendingField = "ascendingField";
        private const string FieldcolumnField = "columnField";
        private Type _relatedListSortInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private RelatedListSort _relatedListSortInstance;
        private RelatedListSort _relatedListSortInstanceFixture;

        #region General Initializer : Class (RelatedListSort) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RelatedListSort" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _relatedListSortInstanceType = typeof(RelatedListSort);
            _relatedListSortInstanceFixture = Create(true);
            _relatedListSortInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (RelatedListSort)

        #region General Initializer : Class (RelatedListSort) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="RelatedListSort" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyascending)]
        [TestCase(Propertycolumn)]
        public void AUT_RelatedListSort_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_relatedListSortInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (RelatedListSort) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="RelatedListSort" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldascendingField)]
        [TestCase(FieldcolumnField)]
        public void AUT_RelatedListSort_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_relatedListSortInstanceFixture, 
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
        ///     Class (<see cref="RelatedListSort" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_RelatedListSort_Is_Instance_Present_Test()
        {
            // Assert
            _relatedListSortInstanceType.ShouldNotBeNull();
            _relatedListSortInstance.ShouldNotBeNull();
            _relatedListSortInstanceFixture.ShouldNotBeNull();
            _relatedListSortInstance.ShouldBeAssignableTo<RelatedListSort>();
            _relatedListSortInstanceFixture.ShouldBeAssignableTo<RelatedListSort>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (RelatedListSort) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_RelatedListSort_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            RelatedListSort instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _relatedListSortInstanceType.ShouldNotBeNull();
            _relatedListSortInstance.ShouldNotBeNull();
            _relatedListSortInstanceFixture.ShouldNotBeNull();
            _relatedListSortInstance.ShouldBeAssignableTo<RelatedListSort>();
            _relatedListSortInstanceFixture.ShouldBeAssignableTo<RelatedListSort>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (RelatedListSort) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , Propertyascending)]
        [TestCaseGeneric(typeof(string) , Propertycolumn)]
        public void AUT_RelatedListSort_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<RelatedListSort, T>(_relatedListSortInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (RelatedListSort) => Property (ascending) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RelatedListSort_Public_Class_ascending_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyascending);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RelatedListSort) => Property (column) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RelatedListSort_Public_Class_column_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertycolumn);

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
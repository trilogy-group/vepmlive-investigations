using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.SalesforceMetadataService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ReportAggregateReference" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ReportAggregateReferenceTest : AbstractBaseSetupTypedTest<ReportAggregateReference>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportAggregateReference) Initializer

        private const string Propertyaggregate = "aggregate";
        private const string FieldaggregateField = "aggregateField";
        private Type _reportAggregateReferenceInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportAggregateReference _reportAggregateReferenceInstance;
        private ReportAggregateReference _reportAggregateReferenceInstanceFixture;

        #region General Initializer : Class (ReportAggregateReference) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportAggregateReference" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportAggregateReferenceInstanceType = typeof(ReportAggregateReference);
            _reportAggregateReferenceInstanceFixture = Create(true);
            _reportAggregateReferenceInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportAggregateReference)

        #region General Initializer : Class (ReportAggregateReference) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportAggregateReference" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyaggregate)]
        public void AUT_ReportAggregateReference_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_reportAggregateReferenceInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ReportAggregateReference) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportAggregateReference" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldaggregateField)]
        public void AUT_ReportAggregateReference_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_reportAggregateReferenceInstanceFixture, 
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
        ///     Class (<see cref="ReportAggregateReference" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ReportAggregateReference_Is_Instance_Present_Test()
        {
            // Assert
            _reportAggregateReferenceInstanceType.ShouldNotBeNull();
            _reportAggregateReferenceInstance.ShouldNotBeNull();
            _reportAggregateReferenceInstanceFixture.ShouldNotBeNull();
            _reportAggregateReferenceInstance.ShouldBeAssignableTo<ReportAggregateReference>();
            _reportAggregateReferenceInstanceFixture.ShouldBeAssignableTo<ReportAggregateReference>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ReportAggregateReference) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ReportAggregateReference_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ReportAggregateReference instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _reportAggregateReferenceInstanceType.ShouldNotBeNull();
            _reportAggregateReferenceInstance.ShouldNotBeNull();
            _reportAggregateReferenceInstanceFixture.ShouldNotBeNull();
            _reportAggregateReferenceInstance.ShouldBeAssignableTo<ReportAggregateReference>();
            _reportAggregateReferenceInstanceFixture.ShouldBeAssignableTo<ReportAggregateReference>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ReportAggregateReference) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertyaggregate)]
        public void AUT_ReportAggregateReference_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ReportAggregateReference, T>(_reportAggregateReferenceInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ReportAggregateReference) => Property (aggregate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportAggregateReference_Public_Class_aggregate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyaggregate);

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
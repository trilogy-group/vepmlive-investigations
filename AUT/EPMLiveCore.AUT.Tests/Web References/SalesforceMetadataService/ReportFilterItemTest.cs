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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ReportFilterItem" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ReportFilterItemTest : AbstractBaseSetupTypedTest<ReportFilterItem>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportFilterItem) Initializer

        private const string Propertycolumn = "column";
        private const string Propertyvalue = "value";
        private const string FieldcolumnField = "columnField";
        private const string FieldoperatorField = "operatorField";
        private const string FieldvalueField = "valueField";
        private Type _reportFilterItemInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportFilterItem _reportFilterItemInstance;
        private ReportFilterItem _reportFilterItemInstanceFixture;

        #region General Initializer : Class (ReportFilterItem) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportFilterItem" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportFilterItemInstanceType = typeof(ReportFilterItem);
            _reportFilterItemInstanceFixture = Create(true);
            _reportFilterItemInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportFilterItem)

        #region General Initializer : Class (ReportFilterItem) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportFilterItem" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertycolumn)]
        [TestCase(Propertyvalue)]
        public void AUT_ReportFilterItem_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_reportFilterItemInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ReportFilterItem) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportFilterItem" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcolumnField)]
        [TestCase(FieldoperatorField)]
        [TestCase(FieldvalueField)]
        public void AUT_ReportFilterItem_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_reportFilterItemInstanceFixture, 
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
        ///     Class (<see cref="ReportFilterItem" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ReportFilterItem_Is_Instance_Present_Test()
        {
            // Assert
            _reportFilterItemInstanceType.ShouldNotBeNull();
            _reportFilterItemInstance.ShouldNotBeNull();
            _reportFilterItemInstanceFixture.ShouldNotBeNull();
            _reportFilterItemInstance.ShouldBeAssignableTo<ReportFilterItem>();
            _reportFilterItemInstanceFixture.ShouldBeAssignableTo<ReportFilterItem>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ReportFilterItem) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ReportFilterItem_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ReportFilterItem instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _reportFilterItemInstanceType.ShouldNotBeNull();
            _reportFilterItemInstance.ShouldNotBeNull();
            _reportFilterItemInstanceFixture.ShouldNotBeNull();
            _reportFilterItemInstance.ShouldBeAssignableTo<ReportFilterItem>();
            _reportFilterItemInstanceFixture.ShouldBeAssignableTo<ReportFilterItem>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ReportFilterItem) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertycolumn)]
        [TestCaseGeneric(typeof(string) , Propertyvalue)]
        public void AUT_ReportFilterItem_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ReportFilterItem, T>(_reportFilterItemInstance, propertyName, Fixture);
        }

        #endregion
        
        #region General Getters/Setters : Class (ReportFilterItem) => Property (column) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportFilterItem_Public_Class_column_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportFilterItem) => Property (value) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportFilterItem_Public_Class_value_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyvalue);

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
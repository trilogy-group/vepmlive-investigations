using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveWebParts.SSRS2006
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.SSRS2006.DataSourceReference" />)
    ///     and namespace <see cref="EPMLiveWebParts.SSRS2006"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DataSourceReferenceTest : AbstractBaseSetupTypedTest<DataSourceReference>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DataSourceReference) Initializer

        private const string PropertyReference = "Reference";
        private const string FieldreferenceField = "referenceField";
        private Type _dataSourceReferenceInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DataSourceReference _dataSourceReferenceInstance;
        private DataSourceReference _dataSourceReferenceInstanceFixture;

        #region General Initializer : Class (DataSourceReference) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DataSourceReference" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _dataSourceReferenceInstanceType = typeof(DataSourceReference);
            _dataSourceReferenceInstanceFixture = Create(true);
            _dataSourceReferenceInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DataSourceReference)

        #region General Initializer : Class (DataSourceReference) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DataSourceReference" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyReference)]
        public void AUT_DataSourceReference_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_dataSourceReferenceInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DataSourceReference) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DataSourceReference" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldreferenceField)]
        public void AUT_DataSourceReference_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_dataSourceReferenceInstanceFixture, 
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
        ///     Class (<see cref="DataSourceReference" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DataSourceReference_Is_Instance_Present_Test()
        {
            // Assert
            _dataSourceReferenceInstanceType.ShouldNotBeNull();
            _dataSourceReferenceInstance.ShouldNotBeNull();
            _dataSourceReferenceInstanceFixture.ShouldNotBeNull();
            _dataSourceReferenceInstance.ShouldBeAssignableTo<DataSourceReference>();
            _dataSourceReferenceInstanceFixture.ShouldBeAssignableTo<DataSourceReference>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DataSourceReference) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DataSourceReference_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DataSourceReference instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _dataSourceReferenceInstanceType.ShouldNotBeNull();
            _dataSourceReferenceInstance.ShouldNotBeNull();
            _dataSourceReferenceInstanceFixture.ShouldNotBeNull();
            _dataSourceReferenceInstance.ShouldBeAssignableTo<DataSourceReference>();
            _dataSourceReferenceInstanceFixture.ShouldBeAssignableTo<DataSourceReference>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DataSourceReference) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyReference)]
        public void AUT_DataSourceReference_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DataSourceReference, T>(_dataSourceReferenceInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DataSourceReference) => Property (Reference) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataSourceReference_Public_Class_Reference_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyReference);

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
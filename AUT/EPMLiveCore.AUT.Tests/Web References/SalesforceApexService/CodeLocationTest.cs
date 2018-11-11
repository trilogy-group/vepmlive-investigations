using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.SalesforceApexService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceApexService.CodeLocation" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceApexService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CodeLocationTest : AbstractBaseSetupTypedTest<CodeLocation>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CodeLocation) Initializer

        private const string Propertycolumn = "column";
        private const string Propertyline = "line";
        private const string PropertynumExecutions = "numExecutions";
        private const string Propertytime = "time";
        private const string FieldcolumnField = "columnField";
        private const string FieldlineField = "lineField";
        private const string FieldnumExecutionsField = "numExecutionsField";
        private const string FieldtimeField = "timeField";
        private Type _codeLocationInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CodeLocation _codeLocationInstance;
        private CodeLocation _codeLocationInstanceFixture;

        #region General Initializer : Class (CodeLocation) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CodeLocation" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _codeLocationInstanceType = typeof(CodeLocation);
            _codeLocationInstanceFixture = Create(true);
            _codeLocationInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CodeLocation)

        #region General Initializer : Class (CodeLocation) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CodeLocation" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertycolumn)]
        [TestCase(Propertyline)]
        [TestCase(PropertynumExecutions)]
        [TestCase(Propertytime)]
        public void AUT_CodeLocation_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_codeLocationInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CodeLocation) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CodeLocation" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcolumnField)]
        [TestCase(FieldlineField)]
        [TestCase(FieldnumExecutionsField)]
        [TestCase(FieldtimeField)]
        public void AUT_CodeLocation_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_codeLocationInstanceFixture, 
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
        ///     Class (<see cref="CodeLocation" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_CodeLocation_Is_Instance_Present_Test()
        {
            // Assert
            _codeLocationInstanceType.ShouldNotBeNull();
            _codeLocationInstance.ShouldNotBeNull();
            _codeLocationInstanceFixture.ShouldNotBeNull();
            _codeLocationInstance.ShouldBeAssignableTo<CodeLocation>();
            _codeLocationInstanceFixture.ShouldBeAssignableTo<CodeLocation>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CodeLocation) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_CodeLocation_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CodeLocation instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _codeLocationInstanceType.ShouldNotBeNull();
            _codeLocationInstance.ShouldNotBeNull();
            _codeLocationInstanceFixture.ShouldNotBeNull();
            _codeLocationInstance.ShouldBeAssignableTo<CodeLocation>();
            _codeLocationInstanceFixture.ShouldBeAssignableTo<CodeLocation>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CodeLocation) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(int) , Propertycolumn)]
        [TestCaseGeneric(typeof(int) , Propertyline)]
        [TestCaseGeneric(typeof(int) , PropertynumExecutions)]
        [TestCaseGeneric(typeof(double) , Propertytime)]
        public void AUT_CodeLocation_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CodeLocation, T>(_codeLocationInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (CodeLocation) => Property (column) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CodeLocation_Public_Class_column_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CodeLocation) => Property (line) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CodeLocation_Public_Class_line_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyline);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CodeLocation) => Property (numExecutions) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CodeLocation_Public_Class_numExecutions_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynumExecutions);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CodeLocation) => Property (time) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CodeLocation_Public_Class_time_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertytime);

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
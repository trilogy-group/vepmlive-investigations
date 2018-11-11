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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceApexService.CompileTriggerResult" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceApexService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CompileTriggerResultTest : AbstractBaseSetupTypedTest<CompileTriggerResult>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CompileTriggerResult) Initializer

        private const string PropertybodyCrc = "bodyCrc";
        private const string PropertybodyCrcSpecified = "bodyCrcSpecified";
        private const string Propertycolumn = "column";
        private const string Propertyid = "id";
        private const string Propertyline = "line";
        private const string Propertyname = "name";
        private const string Propertyproblem = "problem";
        private const string Propertysuccess = "success";
        private const string FieldbodyCrcField = "bodyCrcField";
        private const string FieldbodyCrcFieldSpecified = "bodyCrcFieldSpecified";
        private const string FieldcolumnField = "columnField";
        private const string FieldidField = "idField";
        private const string FieldlineField = "lineField";
        private const string FieldnameField = "nameField";
        private const string FieldproblemField = "problemField";
        private const string FieldsuccessField = "successField";
        private Type _compileTriggerResultInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CompileTriggerResult _compileTriggerResultInstance;
        private CompileTriggerResult _compileTriggerResultInstanceFixture;

        #region General Initializer : Class (CompileTriggerResult) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CompileTriggerResult" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _compileTriggerResultInstanceType = typeof(CompileTriggerResult);
            _compileTriggerResultInstanceFixture = Create(true);
            _compileTriggerResultInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CompileTriggerResult)

        #region General Initializer : Class (CompileTriggerResult) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CompileTriggerResult" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertybodyCrc)]
        [TestCase(PropertybodyCrcSpecified)]
        [TestCase(Propertycolumn)]
        [TestCase(Propertyid)]
        [TestCase(Propertyline)]
        [TestCase(Propertyname)]
        [TestCase(Propertyproblem)]
        [TestCase(Propertysuccess)]
        public void AUT_CompileTriggerResult_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_compileTriggerResultInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CompileTriggerResult) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CompileTriggerResult" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldbodyCrcField)]
        [TestCase(FieldbodyCrcFieldSpecified)]
        [TestCase(FieldcolumnField)]
        [TestCase(FieldidField)]
        [TestCase(FieldlineField)]
        [TestCase(FieldnameField)]
        [TestCase(FieldproblemField)]
        [TestCase(FieldsuccessField)]
        public void AUT_CompileTriggerResult_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_compileTriggerResultInstanceFixture, 
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
        ///     Class (<see cref="CompileTriggerResult" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_CompileTriggerResult_Is_Instance_Present_Test()
        {
            // Assert
            _compileTriggerResultInstanceType.ShouldNotBeNull();
            _compileTriggerResultInstance.ShouldNotBeNull();
            _compileTriggerResultInstanceFixture.ShouldNotBeNull();
            _compileTriggerResultInstance.ShouldBeAssignableTo<CompileTriggerResult>();
            _compileTriggerResultInstanceFixture.ShouldBeAssignableTo<CompileTriggerResult>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CompileTriggerResult) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_CompileTriggerResult_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CompileTriggerResult instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _compileTriggerResultInstanceType.ShouldNotBeNull();
            _compileTriggerResultInstance.ShouldNotBeNull();
            _compileTriggerResultInstanceFixture.ShouldNotBeNull();
            _compileTriggerResultInstance.ShouldBeAssignableTo<CompileTriggerResult>();
            _compileTriggerResultInstanceFixture.ShouldBeAssignableTo<CompileTriggerResult>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CompileTriggerResult) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(int) , PropertybodyCrc)]
        [TestCaseGeneric(typeof(bool) , PropertybodyCrcSpecified)]
        [TestCaseGeneric(typeof(int) , Propertycolumn)]
        [TestCaseGeneric(typeof(string) , Propertyid)]
        [TestCaseGeneric(typeof(int) , Propertyline)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        [TestCaseGeneric(typeof(string) , Propertyproblem)]
        [TestCaseGeneric(typeof(bool) , Propertysuccess)]
        public void AUT_CompileTriggerResult_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CompileTriggerResult, T>(_compileTriggerResultInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (CompileTriggerResult) => Property (bodyCrc) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CompileTriggerResult_Public_Class_bodyCrc_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertybodyCrc);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CompileTriggerResult) => Property (bodyCrcSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CompileTriggerResult_Public_Class_bodyCrcSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertybodyCrcSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CompileTriggerResult) => Property (column) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CompileTriggerResult_Public_Class_column_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CompileTriggerResult) => Property (id) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CompileTriggerResult_Public_Class_id_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyid);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CompileTriggerResult) => Property (line) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CompileTriggerResult_Public_Class_line_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CompileTriggerResult) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CompileTriggerResult_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyname);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CompileTriggerResult) => Property (problem) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CompileTriggerResult_Public_Class_problem_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyproblem);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CompileTriggerResult) => Property (success) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CompileTriggerResult_Public_Class_success_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertysuccess);

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
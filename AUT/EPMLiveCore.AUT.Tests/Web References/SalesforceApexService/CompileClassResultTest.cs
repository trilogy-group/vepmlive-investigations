using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.SalesforceApexService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceApexService.CompileClassResult" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceApexService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CompileClassResultTest : AbstractBaseSetupTypedTest<CompileClassResult>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CompileClassResult) Initializer

        private const string PropertybodyCrc = "bodyCrc";
        private const string PropertybodyCrcSpecified = "bodyCrcSpecified";
        private const string Propertycolumn = "column";
        private const string Propertyid = "id";
        private const string Propertyline = "line";
        private const string Propertyname = "name";
        private const string Propertyproblem = "problem";
        private const string Propertysuccess = "success";
        private const string Propertywarnings = "warnings";
        private const string FieldbodyCrcField = "bodyCrcField";
        private const string FieldbodyCrcFieldSpecified = "bodyCrcFieldSpecified";
        private const string FieldcolumnField = "columnField";
        private const string FieldidField = "idField";
        private const string FieldlineField = "lineField";
        private const string FieldnameField = "nameField";
        private const string FieldproblemField = "problemField";
        private const string FieldsuccessField = "successField";
        private const string FieldwarningsField = "warningsField";
        private Type _compileClassResultInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CompileClassResult _compileClassResultInstance;
        private CompileClassResult _compileClassResultInstanceFixture;

        #region General Initializer : Class (CompileClassResult) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CompileClassResult" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _compileClassResultInstanceType = typeof(CompileClassResult);
            _compileClassResultInstanceFixture = Create(true);
            _compileClassResultInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CompileClassResult)

        #region General Initializer : Class (CompileClassResult) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CompileClassResult" />) explore and verify properties for coverage gain.
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
        [TestCase(Propertywarnings)]
        public void AUT_CompileClassResult_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_compileClassResultInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CompileClassResult) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CompileClassResult" />) explore and verify fields for coverage gain.
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
        [TestCase(FieldwarningsField)]
        public void AUT_CompileClassResult_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_compileClassResultInstanceFixture, 
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
        ///     Class (<see cref="CompileClassResult" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_CompileClassResult_Is_Instance_Present_Test()
        {
            // Assert
            _compileClassResultInstanceType.ShouldNotBeNull();
            _compileClassResultInstance.ShouldNotBeNull();
            _compileClassResultInstanceFixture.ShouldNotBeNull();
            _compileClassResultInstance.ShouldBeAssignableTo<CompileClassResult>();
            _compileClassResultInstanceFixture.ShouldBeAssignableTo<CompileClassResult>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CompileClassResult) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_CompileClassResult_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CompileClassResult instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _compileClassResultInstanceType.ShouldNotBeNull();
            _compileClassResultInstance.ShouldNotBeNull();
            _compileClassResultInstanceFixture.ShouldNotBeNull();
            _compileClassResultInstance.ShouldBeAssignableTo<CompileClassResult>();
            _compileClassResultInstanceFixture.ShouldBeAssignableTo<CompileClassResult>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CompileClassResult) => all properties (non-static) explore and verify type tests

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
        [TestCaseGeneric(typeof(string[]) , Propertywarnings)]
        public void AUT_CompileClassResult_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CompileClassResult, T>(_compileClassResultInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (CompileClassResult) => Property (bodyCrc) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CompileClassResult_Public_Class_bodyCrc_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CompileClassResult) => Property (bodyCrcSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CompileClassResult_Public_Class_bodyCrcSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CompileClassResult) => Property (column) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CompileClassResult_Public_Class_column_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CompileClassResult) => Property (id) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CompileClassResult_Public_Class_id_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CompileClassResult) => Property (line) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CompileClassResult_Public_Class_line_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CompileClassResult) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CompileClassResult_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CompileClassResult) => Property (problem) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CompileClassResult_Public_Class_problem_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CompileClassResult) => Property (success) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CompileClassResult_Public_Class_success_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CompileClassResult) => Property (warnings) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CompileClassResult_warnings_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertywarnings);
            Action currentAction = () => propertyInfo.SetValue(_compileClassResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CompileClassResult) => Property (warnings) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CompileClassResult_Public_Class_warnings_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertywarnings);

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
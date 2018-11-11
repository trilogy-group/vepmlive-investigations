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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceApexService.ExecuteAnonymousResult" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceApexService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ExecuteAnonymousResultTest : AbstractBaseSetupTypedTest<ExecuteAnonymousResult>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ExecuteAnonymousResult) Initializer

        private const string Propertycolumn = "column";
        private const string PropertycompileProblem = "compileProblem";
        private const string Propertycompiled = "compiled";
        private const string PropertyexceptionMessage = "exceptionMessage";
        private const string PropertyexceptionStackTrace = "exceptionStackTrace";
        private const string Propertyline = "line";
        private const string Propertysuccess = "success";
        private const string FieldcolumnField = "columnField";
        private const string FieldcompileProblemField = "compileProblemField";
        private const string FieldcompiledField = "compiledField";
        private const string FieldexceptionMessageField = "exceptionMessageField";
        private const string FieldexceptionStackTraceField = "exceptionStackTraceField";
        private const string FieldlineField = "lineField";
        private const string FieldsuccessField = "successField";
        private Type _executeAnonymousResultInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ExecuteAnonymousResult _executeAnonymousResultInstance;
        private ExecuteAnonymousResult _executeAnonymousResultInstanceFixture;

        #region General Initializer : Class (ExecuteAnonymousResult) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ExecuteAnonymousResult" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _executeAnonymousResultInstanceType = typeof(ExecuteAnonymousResult);
            _executeAnonymousResultInstanceFixture = Create(true);
            _executeAnonymousResultInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ExecuteAnonymousResult)

        #region General Initializer : Class (ExecuteAnonymousResult) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ExecuteAnonymousResult" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertycolumn)]
        [TestCase(PropertycompileProblem)]
        [TestCase(Propertycompiled)]
        [TestCase(PropertyexceptionMessage)]
        [TestCase(PropertyexceptionStackTrace)]
        [TestCase(Propertyline)]
        [TestCase(Propertysuccess)]
        public void AUT_ExecuteAnonymousResult_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_executeAnonymousResultInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ExecuteAnonymousResult) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ExecuteAnonymousResult" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcolumnField)]
        [TestCase(FieldcompileProblemField)]
        [TestCase(FieldcompiledField)]
        [TestCase(FieldexceptionMessageField)]
        [TestCase(FieldexceptionStackTraceField)]
        [TestCase(FieldlineField)]
        [TestCase(FieldsuccessField)]
        public void AUT_ExecuteAnonymousResult_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_executeAnonymousResultInstanceFixture, 
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
        ///     Class (<see cref="ExecuteAnonymousResult" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ExecuteAnonymousResult_Is_Instance_Present_Test()
        {
            // Assert
            _executeAnonymousResultInstanceType.ShouldNotBeNull();
            _executeAnonymousResultInstance.ShouldNotBeNull();
            _executeAnonymousResultInstanceFixture.ShouldNotBeNull();
            _executeAnonymousResultInstance.ShouldBeAssignableTo<ExecuteAnonymousResult>();
            _executeAnonymousResultInstanceFixture.ShouldBeAssignableTo<ExecuteAnonymousResult>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ExecuteAnonymousResult) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ExecuteAnonymousResult_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ExecuteAnonymousResult instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _executeAnonymousResultInstanceType.ShouldNotBeNull();
            _executeAnonymousResultInstance.ShouldNotBeNull();
            _executeAnonymousResultInstanceFixture.ShouldNotBeNull();
            _executeAnonymousResultInstance.ShouldBeAssignableTo<ExecuteAnonymousResult>();
            _executeAnonymousResultInstanceFixture.ShouldBeAssignableTo<ExecuteAnonymousResult>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ExecuteAnonymousResult) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(int) , Propertycolumn)]
        [TestCaseGeneric(typeof(string) , PropertycompileProblem)]
        [TestCaseGeneric(typeof(bool) , Propertycompiled)]
        [TestCaseGeneric(typeof(string) , PropertyexceptionMessage)]
        [TestCaseGeneric(typeof(string) , PropertyexceptionStackTrace)]
        [TestCaseGeneric(typeof(int) , Propertyline)]
        [TestCaseGeneric(typeof(bool) , Propertysuccess)]
        public void AUT_ExecuteAnonymousResult_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ExecuteAnonymousResult, T>(_executeAnonymousResultInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ExecuteAnonymousResult) => Property (column) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ExecuteAnonymousResult_Public_Class_column_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ExecuteAnonymousResult) => Property (compiled) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ExecuteAnonymousResult_Public_Class_compiled_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertycompiled);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExecuteAnonymousResult) => Property (compileProblem) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ExecuteAnonymousResult_Public_Class_compileProblem_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycompileProblem);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExecuteAnonymousResult) => Property (exceptionMessage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ExecuteAnonymousResult_Public_Class_exceptionMessage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyexceptionMessage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExecuteAnonymousResult) => Property (exceptionStackTrace) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ExecuteAnonymousResult_Public_Class_exceptionStackTrace_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyexceptionStackTrace);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExecuteAnonymousResult) => Property (line) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ExecuteAnonymousResult_Public_Class_line_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ExecuteAnonymousResult) => Property (success) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ExecuteAnonymousResult_Public_Class_success_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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
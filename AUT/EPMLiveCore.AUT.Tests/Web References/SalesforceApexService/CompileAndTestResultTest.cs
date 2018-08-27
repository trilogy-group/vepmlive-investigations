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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceApexService.CompileAndTestResult" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceApexService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CompileAndTestResultTest : AbstractBaseSetupTypedTest<CompileAndTestResult>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CompileAndTestResult) Initializer

        private const string Propertyclasses = "classes";
        private const string PropertydeleteClasses = "deleteClasses";
        private const string PropertydeleteTriggers = "deleteTriggers";
        private const string PropertyrunTestsResult = "runTestsResult";
        private const string Propertysuccess = "success";
        private const string Propertytriggers = "triggers";
        private const string FieldclassesField = "classesField";
        private const string FielddeleteClassesField = "deleteClassesField";
        private const string FielddeleteTriggersField = "deleteTriggersField";
        private const string FieldrunTestsResultField = "runTestsResultField";
        private const string FieldsuccessField = "successField";
        private const string FieldtriggersField = "triggersField";
        private Type _compileAndTestResultInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CompileAndTestResult _compileAndTestResultInstance;
        private CompileAndTestResult _compileAndTestResultInstanceFixture;

        #region General Initializer : Class (CompileAndTestResult) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CompileAndTestResult" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _compileAndTestResultInstanceType = typeof(CompileAndTestResult);
            _compileAndTestResultInstanceFixture = Create(true);
            _compileAndTestResultInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CompileAndTestResult)

        #region General Initializer : Class (CompileAndTestResult) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CompileAndTestResult" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyclasses)]
        [TestCase(PropertydeleteClasses)]
        [TestCase(PropertydeleteTriggers)]
        [TestCase(PropertyrunTestsResult)]
        [TestCase(Propertysuccess)]
        [TestCase(Propertytriggers)]
        public void AUT_CompileAndTestResult_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_compileAndTestResultInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CompileAndTestResult) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CompileAndTestResult" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldclassesField)]
        [TestCase(FielddeleteClassesField)]
        [TestCase(FielddeleteTriggersField)]
        [TestCase(FieldrunTestsResultField)]
        [TestCase(FieldsuccessField)]
        [TestCase(FieldtriggersField)]
        public void AUT_CompileAndTestResult_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_compileAndTestResultInstanceFixture, 
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
        ///     Class (<see cref="CompileAndTestResult" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_CompileAndTestResult_Is_Instance_Present_Test()
        {
            // Assert
            _compileAndTestResultInstanceType.ShouldNotBeNull();
            _compileAndTestResultInstance.ShouldNotBeNull();
            _compileAndTestResultInstanceFixture.ShouldNotBeNull();
            _compileAndTestResultInstance.ShouldBeAssignableTo<CompileAndTestResult>();
            _compileAndTestResultInstanceFixture.ShouldBeAssignableTo<CompileAndTestResult>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CompileAndTestResult) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_CompileAndTestResult_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CompileAndTestResult instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _compileAndTestResultInstanceType.ShouldNotBeNull();
            _compileAndTestResultInstance.ShouldNotBeNull();
            _compileAndTestResultInstanceFixture.ShouldNotBeNull();
            _compileAndTestResultInstance.ShouldBeAssignableTo<CompileAndTestResult>();
            _compileAndTestResultInstanceFixture.ShouldBeAssignableTo<CompileAndTestResult>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CompileAndTestResult) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(CompileClassResult[]) , Propertyclasses)]
        [TestCaseGeneric(typeof(DeleteApexResult[]) , PropertydeleteClasses)]
        [TestCaseGeneric(typeof(DeleteApexResult[]) , PropertydeleteTriggers)]
        [TestCaseGeneric(typeof(RunTestsResult) , PropertyrunTestsResult)]
        [TestCaseGeneric(typeof(bool) , Propertysuccess)]
        [TestCaseGeneric(typeof(CompileTriggerResult[]) , Propertytriggers)]
        public void AUT_CompileAndTestResult_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CompileAndTestResult, T>(_compileAndTestResultInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (CompileAndTestResult) => Property (classes) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CompileAndTestResult_classes_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyclasses);
            Action currentAction = () => propertyInfo.SetValue(_compileAndTestResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CompileAndTestResult) => Property (classes) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CompileAndTestResult_Public_Class_classes_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyclasses);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CompileAndTestResult) => Property (deleteClasses) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CompileAndTestResult_deleteClasses_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertydeleteClasses);
            Action currentAction = () => propertyInfo.SetValue(_compileAndTestResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CompileAndTestResult) => Property (deleteClasses) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CompileAndTestResult_Public_Class_deleteClasses_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydeleteClasses);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CompileAndTestResult) => Property (deleteTriggers) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CompileAndTestResult_deleteTriggers_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertydeleteTriggers);
            Action currentAction = () => propertyInfo.SetValue(_compileAndTestResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CompileAndTestResult) => Property (deleteTriggers) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CompileAndTestResult_Public_Class_deleteTriggers_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydeleteTriggers);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CompileAndTestResult) => Property (runTestsResult) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CompileAndTestResult_runTestsResult_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyrunTestsResult);
            Action currentAction = () => propertyInfo.SetValue(_compileAndTestResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CompileAndTestResult) => Property (runTestsResult) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CompileAndTestResult_Public_Class_runTestsResult_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrunTestsResult);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CompileAndTestResult) => Property (success) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CompileAndTestResult_Public_Class_success_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CompileAndTestResult) => Property (triggers) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CompileAndTestResult_triggers_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertytriggers);
            Action currentAction = () => propertyInfo.SetValue(_compileAndTestResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CompileAndTestResult) => Property (triggers) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CompileAndTestResult_Public_Class_triggers_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertytriggers);

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
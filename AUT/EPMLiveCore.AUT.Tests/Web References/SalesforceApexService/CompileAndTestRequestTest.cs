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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceApexService.CompileAndTestRequest" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceApexService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CompileAndTestRequestTest : AbstractBaseSetupTypedTest<CompileAndTestRequest>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CompileAndTestRequest) Initializer

        private const string PropertycheckOnly = "checkOnly";
        private const string Propertyclasses = "classes";
        private const string PropertydeleteClasses = "deleteClasses";
        private const string PropertydeleteTriggers = "deleteTriggers";
        private const string PropertyrunTestsRequest = "runTestsRequest";
        private const string Propertytriggers = "triggers";
        private const string FieldcheckOnlyField = "checkOnlyField";
        private const string FieldclassesField = "classesField";
        private const string FielddeleteClassesField = "deleteClassesField";
        private const string FielddeleteTriggersField = "deleteTriggersField";
        private const string FieldrunTestsRequestField = "runTestsRequestField";
        private const string FieldtriggersField = "triggersField";
        private Type _compileAndTestRequestInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CompileAndTestRequest _compileAndTestRequestInstance;
        private CompileAndTestRequest _compileAndTestRequestInstanceFixture;

        #region General Initializer : Class (CompileAndTestRequest) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CompileAndTestRequest" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _compileAndTestRequestInstanceType = typeof(CompileAndTestRequest);
            _compileAndTestRequestInstanceFixture = Create(true);
            _compileAndTestRequestInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CompileAndTestRequest)

        #region General Initializer : Class (CompileAndTestRequest) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CompileAndTestRequest" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertycheckOnly)]
        [TestCase(Propertyclasses)]
        [TestCase(PropertydeleteClasses)]
        [TestCase(PropertydeleteTriggers)]
        [TestCase(PropertyrunTestsRequest)]
        [TestCase(Propertytriggers)]
        public void AUT_CompileAndTestRequest_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_compileAndTestRequestInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CompileAndTestRequest) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CompileAndTestRequest" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcheckOnlyField)]
        [TestCase(FieldclassesField)]
        [TestCase(FielddeleteClassesField)]
        [TestCase(FielddeleteTriggersField)]
        [TestCase(FieldrunTestsRequestField)]
        [TestCase(FieldtriggersField)]
        public void AUT_CompileAndTestRequest_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_compileAndTestRequestInstanceFixture, 
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
        ///     Class (<see cref="CompileAndTestRequest" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_CompileAndTestRequest_Is_Instance_Present_Test()
        {
            // Assert
            _compileAndTestRequestInstanceType.ShouldNotBeNull();
            _compileAndTestRequestInstance.ShouldNotBeNull();
            _compileAndTestRequestInstanceFixture.ShouldNotBeNull();
            _compileAndTestRequestInstance.ShouldBeAssignableTo<CompileAndTestRequest>();
            _compileAndTestRequestInstanceFixture.ShouldBeAssignableTo<CompileAndTestRequest>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CompileAndTestRequest) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_CompileAndTestRequest_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CompileAndTestRequest instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _compileAndTestRequestInstanceType.ShouldNotBeNull();
            _compileAndTestRequestInstance.ShouldNotBeNull();
            _compileAndTestRequestInstanceFixture.ShouldNotBeNull();
            _compileAndTestRequestInstance.ShouldBeAssignableTo<CompileAndTestRequest>();
            _compileAndTestRequestInstanceFixture.ShouldBeAssignableTo<CompileAndTestRequest>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CompileAndTestRequest) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertycheckOnly)]
        [TestCaseGeneric(typeof(string[]) , Propertyclasses)]
        [TestCaseGeneric(typeof(string[]) , PropertydeleteClasses)]
        [TestCaseGeneric(typeof(string[]) , PropertydeleteTriggers)]
        [TestCaseGeneric(typeof(RunTestsRequest) , PropertyrunTestsRequest)]
        [TestCaseGeneric(typeof(string[]) , Propertytriggers)]
        public void AUT_CompileAndTestRequest_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CompileAndTestRequest, T>(_compileAndTestRequestInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (CompileAndTestRequest) => Property (checkOnly) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CompileAndTestRequest_Public_Class_checkOnly_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycheckOnly);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CompileAndTestRequest) => Property (classes) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CompileAndTestRequest_classes_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyclasses);
            Action currentAction = () => propertyInfo.SetValue(_compileAndTestRequestInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CompileAndTestRequest) => Property (classes) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CompileAndTestRequest_Public_Class_classes_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CompileAndTestRequest) => Property (deleteClasses) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CompileAndTestRequest_deleteClasses_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertydeleteClasses);
            Action currentAction = () => propertyInfo.SetValue(_compileAndTestRequestInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CompileAndTestRequest) => Property (deleteClasses) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CompileAndTestRequest_Public_Class_deleteClasses_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CompileAndTestRequest) => Property (deleteTriggers) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CompileAndTestRequest_deleteTriggers_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertydeleteTriggers);
            Action currentAction = () => propertyInfo.SetValue(_compileAndTestRequestInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CompileAndTestRequest) => Property (deleteTriggers) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CompileAndTestRequest_Public_Class_deleteTriggers_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CompileAndTestRequest) => Property (runTestsRequest) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CompileAndTestRequest_runTestsRequest_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyrunTestsRequest);
            Action currentAction = () => propertyInfo.SetValue(_compileAndTestRequestInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CompileAndTestRequest) => Property (runTestsRequest) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CompileAndTestRequest_Public_Class_runTestsRequest_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrunTestsRequest);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CompileAndTestRequest) => Property (triggers) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CompileAndTestRequest_triggers_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertytriggers);
            Action currentAction = () => propertyInfo.SetValue(_compileAndTestRequestInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CompileAndTestRequest) => Property (triggers) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CompileAndTestRequest_Public_Class_triggers_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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
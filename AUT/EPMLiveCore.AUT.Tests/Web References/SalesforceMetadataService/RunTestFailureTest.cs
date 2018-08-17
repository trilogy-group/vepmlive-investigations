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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.RunTestFailure" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class RunTestFailureTest : AbstractBaseSetupTypedTest<RunTestFailure>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (RunTestFailure) Initializer

        private const string Propertyid = "id";
        private const string Propertymessage = "message";
        private const string PropertymethodName = "methodName";
        private const string Propertyname = "name";
        private const string PropertypackageName = "packageName";
        private const string PropertystackTrace = "stackTrace";
        private const string Propertytime = "time";
        private const string Propertytype = "type";
        private const string FieldidField = "idField";
        private const string FieldmessageField = "messageField";
        private const string FieldmethodNameField = "methodNameField";
        private const string FieldnameField = "nameField";
        private const string FieldnamespaceField = "namespaceField";
        private const string FieldpackageNameField = "packageNameField";
        private const string FieldstackTraceField = "stackTraceField";
        private const string FieldtimeField = "timeField";
        private const string FieldtypeField = "typeField";
        private Type _runTestFailureInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private RunTestFailure _runTestFailureInstance;
        private RunTestFailure _runTestFailureInstanceFixture;

        #region General Initializer : Class (RunTestFailure) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RunTestFailure" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _runTestFailureInstanceType = typeof(RunTestFailure);
            _runTestFailureInstanceFixture = Create(true);
            _runTestFailureInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (RunTestFailure)

        #region General Initializer : Class (RunTestFailure) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="RunTestFailure" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyid)]
        [TestCase(Propertymessage)]
        [TestCase(PropertymethodName)]
        [TestCase(Propertyname)]
        [TestCase(PropertypackageName)]
        [TestCase(PropertystackTrace)]
        [TestCase(Propertytime)]
        [TestCase(Propertytype)]
        public void AUT_RunTestFailure_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_runTestFailureInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (RunTestFailure) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="RunTestFailure" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldidField)]
        [TestCase(FieldmessageField)]
        [TestCase(FieldmethodNameField)]
        [TestCase(FieldnameField)]
        [TestCase(FieldnamespaceField)]
        [TestCase(FieldpackageNameField)]
        [TestCase(FieldstackTraceField)]
        [TestCase(FieldtimeField)]
        [TestCase(FieldtypeField)]
        public void AUT_RunTestFailure_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_runTestFailureInstanceFixture, 
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
        ///     Class (<see cref="RunTestFailure" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_RunTestFailure_Is_Instance_Present_Test()
        {
            // Assert
            _runTestFailureInstanceType.ShouldNotBeNull();
            _runTestFailureInstance.ShouldNotBeNull();
            _runTestFailureInstanceFixture.ShouldNotBeNull();
            _runTestFailureInstance.ShouldBeAssignableTo<RunTestFailure>();
            _runTestFailureInstanceFixture.ShouldBeAssignableTo<RunTestFailure>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (RunTestFailure) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_RunTestFailure_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            RunTestFailure instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _runTestFailureInstanceType.ShouldNotBeNull();
            _runTestFailureInstance.ShouldNotBeNull();
            _runTestFailureInstanceFixture.ShouldNotBeNull();
            _runTestFailureInstance.ShouldBeAssignableTo<RunTestFailure>();
            _runTestFailureInstanceFixture.ShouldBeAssignableTo<RunTestFailure>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (RunTestFailure) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertyid)]
        [TestCaseGeneric(typeof(string) , Propertymessage)]
        [TestCaseGeneric(typeof(string) , PropertymethodName)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        [TestCaseGeneric(typeof(string) , PropertypackageName)]
        [TestCaseGeneric(typeof(string) , PropertystackTrace)]
        [TestCaseGeneric(typeof(double) , Propertytime)]
        [TestCaseGeneric(typeof(string) , Propertytype)]
        public void AUT_RunTestFailure_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<RunTestFailure, T>(_runTestFailureInstance, propertyName, Fixture);
        }

        #endregion
        
        #region General Getters/Setters : Class (RunTestFailure) => Property (id) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RunTestFailure_Public_Class_id_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (RunTestFailure) => Property (message) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RunTestFailure_Public_Class_message_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertymessage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RunTestFailure) => Property (methodName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RunTestFailure_Public_Class_methodName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertymethodName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RunTestFailure) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RunTestFailure_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (RunTestFailure) => Property (packageName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RunTestFailure_Public_Class_packageName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertypackageName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RunTestFailure) => Property (stackTrace) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RunTestFailure_Public_Class_stackTrace_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertystackTrace);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RunTestFailure) => Property (time) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RunTestFailure_Public_Class_time_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (RunTestFailure) => Property (type) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RunTestFailure_Public_Class_type_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertytype);

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
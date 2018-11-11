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

namespace EPMLiveCore.SalesforceMetadataService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.DeployResult" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DeployResultTest : AbstractBaseSetupTypedTest<DeployResult>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DeployResult) Initializer

        private const string Propertyid = "id";
        private const string Propertymessages = "messages";
        private const string PropertyretrieveResult = "retrieveResult";
        private const string PropertyrunTestResult = "runTestResult";
        private const string Propertysuccess = "success";
        private const string FieldidField = "idField";
        private const string FieldmessagesField = "messagesField";
        private const string FieldretrieveResultField = "retrieveResultField";
        private const string FieldrunTestResultField = "runTestResultField";
        private const string FieldsuccessField = "successField";
        private Type _deployResultInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DeployResult _deployResultInstance;
        private DeployResult _deployResultInstanceFixture;

        #region General Initializer : Class (DeployResult) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DeployResult" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _deployResultInstanceType = typeof(DeployResult);
            _deployResultInstanceFixture = Create(true);
            _deployResultInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DeployResult)

        #region General Initializer : Class (DeployResult) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DeployResult" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyid)]
        [TestCase(Propertymessages)]
        [TestCase(PropertyretrieveResult)]
        [TestCase(PropertyrunTestResult)]
        [TestCase(Propertysuccess)]
        public void AUT_DeployResult_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_deployResultInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DeployResult) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DeployResult" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldidField)]
        [TestCase(FieldmessagesField)]
        [TestCase(FieldretrieveResultField)]
        [TestCase(FieldrunTestResultField)]
        [TestCase(FieldsuccessField)]
        public void AUT_DeployResult_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_deployResultInstanceFixture, 
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
        ///     Class (<see cref="DeployResult" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DeployResult_Is_Instance_Present_Test()
        {
            // Assert
            _deployResultInstanceType.ShouldNotBeNull();
            _deployResultInstance.ShouldNotBeNull();
            _deployResultInstanceFixture.ShouldNotBeNull();
            _deployResultInstance.ShouldBeAssignableTo<DeployResult>();
            _deployResultInstanceFixture.ShouldBeAssignableTo<DeployResult>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DeployResult) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DeployResult_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DeployResult instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _deployResultInstanceType.ShouldNotBeNull();
            _deployResultInstance.ShouldNotBeNull();
            _deployResultInstanceFixture.ShouldNotBeNull();
            _deployResultInstance.ShouldBeAssignableTo<DeployResult>();
            _deployResultInstanceFixture.ShouldBeAssignableTo<DeployResult>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DeployResult) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertyid)]
        [TestCaseGeneric(typeof(DeployMessage[]) , Propertymessages)]
        [TestCaseGeneric(typeof(RetrieveResult) , PropertyretrieveResult)]
        [TestCaseGeneric(typeof(RunTestsResult) , PropertyrunTestResult)]
        [TestCaseGeneric(typeof(bool) , Propertysuccess)]
        public void AUT_DeployResult_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DeployResult, T>(_deployResultInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DeployResult) => Property (id) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DeployResult_Public_Class_id_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DeployResult) => Property (messages) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DeployResult_messages_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertymessages);
            Action currentAction = () => propertyInfo.SetValue(_deployResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DeployResult) => Property (messages) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DeployResult_Public_Class_messages_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertymessages);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DeployResult) => Property (retrieveResult) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DeployResult_retrieveResult_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyretrieveResult);
            Action currentAction = () => propertyInfo.SetValue(_deployResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DeployResult) => Property (retrieveResult) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DeployResult_Public_Class_retrieveResult_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyretrieveResult);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DeployResult) => Property (runTestResult) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DeployResult_runTestResult_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyrunTestResult);
            Action currentAction = () => propertyInfo.SetValue(_deployResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DeployResult) => Property (runTestResult) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DeployResult_Public_Class_runTestResult_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrunTestResult);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DeployResult) => Property (success) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DeployResult_Public_Class_success_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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
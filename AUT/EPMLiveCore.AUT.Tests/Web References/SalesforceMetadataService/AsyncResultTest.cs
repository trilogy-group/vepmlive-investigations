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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.AsyncResult" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class AsyncResultTest : AbstractBaseSetupTypedTest<AsyncResult>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (AsyncResult) Initializer

        private const string PropertycheckOnly = "checkOnly";
        private const string PropertycheckOnlySpecified = "checkOnlySpecified";
        private const string Propertydone = "done";
        private const string Propertyid = "id";
        private const string Propertymessage = "message";
        private const string PropertynumberComponentErrors = "numberComponentErrors";
        private const string PropertynumberComponentErrorsSpecified = "numberComponentErrorsSpecified";
        private const string PropertynumberComponentsDeployed = "numberComponentsDeployed";
        private const string PropertynumberComponentsDeployedSpecified = "numberComponentsDeployedSpecified";
        private const string PropertynumberComponentsTotal = "numberComponentsTotal";
        private const string PropertynumberComponentsTotalSpecified = "numberComponentsTotalSpecified";
        private const string PropertynumberTestErrors = "numberTestErrors";
        private const string PropertynumberTestErrorsSpecified = "numberTestErrorsSpecified";
        private const string PropertynumberTestsCompleted = "numberTestsCompleted";
        private const string PropertynumberTestsCompletedSpecified = "numberTestsCompletedSpecified";
        private const string PropertynumberTestsTotal = "numberTestsTotal";
        private const string PropertynumberTestsTotalSpecified = "numberTestsTotalSpecified";
        private const string Propertystate = "state";
        private const string PropertystateDetail = "stateDetail";
        private const string PropertystateDetailLastModifiedDate = "stateDetailLastModifiedDate";
        private const string PropertystateDetailLastModifiedDateSpecified = "stateDetailLastModifiedDateSpecified";
        private const string PropertystatusCode = "statusCode";
        private const string PropertystatusCodeSpecified = "statusCodeSpecified";
        private const string FieldcheckOnlyField = "checkOnlyField";
        private const string FieldcheckOnlyFieldSpecified = "checkOnlyFieldSpecified";
        private const string FielddoneField = "doneField";
        private const string FieldidField = "idField";
        private const string FieldmessageField = "messageField";
        private const string FieldnumberComponentErrorsField = "numberComponentErrorsField";
        private const string FieldnumberComponentErrorsFieldSpecified = "numberComponentErrorsFieldSpecified";
        private const string FieldnumberComponentsDeployedField = "numberComponentsDeployedField";
        private const string FieldnumberComponentsDeployedFieldSpecified = "numberComponentsDeployedFieldSpecified";
        private const string FieldnumberComponentsTotalField = "numberComponentsTotalField";
        private const string FieldnumberComponentsTotalFieldSpecified = "numberComponentsTotalFieldSpecified";
        private const string FieldnumberTestErrorsField = "numberTestErrorsField";
        private const string FieldnumberTestErrorsFieldSpecified = "numberTestErrorsFieldSpecified";
        private const string FieldnumberTestsCompletedField = "numberTestsCompletedField";
        private const string FieldnumberTestsCompletedFieldSpecified = "numberTestsCompletedFieldSpecified";
        private const string FieldnumberTestsTotalField = "numberTestsTotalField";
        private const string FieldnumberTestsTotalFieldSpecified = "numberTestsTotalFieldSpecified";
        private const string FieldstateField = "stateField";
        private const string FieldstateDetailField = "stateDetailField";
        private const string FieldstateDetailLastModifiedDateField = "stateDetailLastModifiedDateField";
        private const string FieldstateDetailLastModifiedDateFieldSpecified = "stateDetailLastModifiedDateFieldSpecified";
        private const string FieldstatusCodeField = "statusCodeField";
        private const string FieldstatusCodeFieldSpecified = "statusCodeFieldSpecified";
        private Type _asyncResultInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private AsyncResult _asyncResultInstance;
        private AsyncResult _asyncResultInstanceFixture;

        #region General Initializer : Class (AsyncResult) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="AsyncResult" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _asyncResultInstanceType = typeof(AsyncResult);
            _asyncResultInstanceFixture = Create(true);
            _asyncResultInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (AsyncResult)

        #region General Initializer : Class (AsyncResult) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="AsyncResult" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertycheckOnly)]
        [TestCase(PropertycheckOnlySpecified)]
        [TestCase(Propertydone)]
        [TestCase(Propertyid)]
        [TestCase(Propertymessage)]
        [TestCase(PropertynumberComponentErrors)]
        [TestCase(PropertynumberComponentErrorsSpecified)]
        [TestCase(PropertynumberComponentsDeployed)]
        [TestCase(PropertynumberComponentsDeployedSpecified)]
        [TestCase(PropertynumberComponentsTotal)]
        [TestCase(PropertynumberComponentsTotalSpecified)]
        [TestCase(PropertynumberTestErrors)]
        [TestCase(PropertynumberTestErrorsSpecified)]
        [TestCase(PropertynumberTestsCompleted)]
        [TestCase(PropertynumberTestsCompletedSpecified)]
        [TestCase(PropertynumberTestsTotal)]
        [TestCase(PropertynumberTestsTotalSpecified)]
        [TestCase(Propertystate)]
        [TestCase(PropertystateDetail)]
        [TestCase(PropertystateDetailLastModifiedDate)]
        [TestCase(PropertystateDetailLastModifiedDateSpecified)]
        [TestCase(PropertystatusCode)]
        [TestCase(PropertystatusCodeSpecified)]
        public void AUT_AsyncResult_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_asyncResultInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (AsyncResult) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="AsyncResult" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcheckOnlyField)]
        [TestCase(FieldcheckOnlyFieldSpecified)]
        [TestCase(FielddoneField)]
        [TestCase(FieldidField)]
        [TestCase(FieldmessageField)]
        [TestCase(FieldnumberComponentErrorsField)]
        [TestCase(FieldnumberComponentErrorsFieldSpecified)]
        [TestCase(FieldnumberComponentsDeployedField)]
        [TestCase(FieldnumberComponentsDeployedFieldSpecified)]
        [TestCase(FieldnumberComponentsTotalField)]
        [TestCase(FieldnumberComponentsTotalFieldSpecified)]
        [TestCase(FieldnumberTestErrorsField)]
        [TestCase(FieldnumberTestErrorsFieldSpecified)]
        [TestCase(FieldnumberTestsCompletedField)]
        [TestCase(FieldnumberTestsCompletedFieldSpecified)]
        [TestCase(FieldnumberTestsTotalField)]
        [TestCase(FieldnumberTestsTotalFieldSpecified)]
        [TestCase(FieldstateField)]
        [TestCase(FieldstateDetailField)]
        [TestCase(FieldstateDetailLastModifiedDateField)]
        [TestCase(FieldstateDetailLastModifiedDateFieldSpecified)]
        [TestCase(FieldstatusCodeField)]
        [TestCase(FieldstatusCodeFieldSpecified)]
        public void AUT_AsyncResult_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_asyncResultInstanceFixture, 
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
        ///     Class (<see cref="AsyncResult" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_AsyncResult_Is_Instance_Present_Test()
        {
            // Assert
            _asyncResultInstanceType.ShouldNotBeNull();
            _asyncResultInstance.ShouldNotBeNull();
            _asyncResultInstanceFixture.ShouldNotBeNull();
            _asyncResultInstance.ShouldBeAssignableTo<AsyncResult>();
            _asyncResultInstanceFixture.ShouldBeAssignableTo<AsyncResult>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (AsyncResult) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_AsyncResult_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            AsyncResult instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _asyncResultInstanceType.ShouldNotBeNull();
            _asyncResultInstance.ShouldNotBeNull();
            _asyncResultInstanceFixture.ShouldNotBeNull();
            _asyncResultInstance.ShouldBeAssignableTo<AsyncResult>();
            _asyncResultInstanceFixture.ShouldBeAssignableTo<AsyncResult>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (AsyncResult) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertycheckOnly)]
        [TestCaseGeneric(typeof(bool) , PropertycheckOnlySpecified)]
        [TestCaseGeneric(typeof(bool) , Propertydone)]
        [TestCaseGeneric(typeof(string) , Propertyid)]
        [TestCaseGeneric(typeof(string) , Propertymessage)]
        [TestCaseGeneric(typeof(int) , PropertynumberComponentErrors)]
        [TestCaseGeneric(typeof(bool) , PropertynumberComponentErrorsSpecified)]
        [TestCaseGeneric(typeof(int) , PropertynumberComponentsDeployed)]
        [TestCaseGeneric(typeof(bool) , PropertynumberComponentsDeployedSpecified)]
        [TestCaseGeneric(typeof(int) , PropertynumberComponentsTotal)]
        [TestCaseGeneric(typeof(bool) , PropertynumberComponentsTotalSpecified)]
        [TestCaseGeneric(typeof(int) , PropertynumberTestErrors)]
        [TestCaseGeneric(typeof(bool) , PropertynumberTestErrorsSpecified)]
        [TestCaseGeneric(typeof(int) , PropertynumberTestsCompleted)]
        [TestCaseGeneric(typeof(bool) , PropertynumberTestsCompletedSpecified)]
        [TestCaseGeneric(typeof(int) , PropertynumberTestsTotal)]
        [TestCaseGeneric(typeof(bool) , PropertynumberTestsTotalSpecified)]
        [TestCaseGeneric(typeof(AsyncRequestState) , Propertystate)]
        [TestCaseGeneric(typeof(string) , PropertystateDetail)]
        [TestCaseGeneric(typeof(System.DateTime) , PropertystateDetailLastModifiedDate)]
        [TestCaseGeneric(typeof(bool) , PropertystateDetailLastModifiedDateSpecified)]
        [TestCaseGeneric(typeof(StatusCode) , PropertystatusCode)]
        [TestCaseGeneric(typeof(bool) , PropertystatusCodeSpecified)]
        public void AUT_AsyncResult_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<AsyncResult, T>(_asyncResultInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (AsyncResult) => Property (checkOnly) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AsyncResult_Public_Class_checkOnly_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (AsyncResult) => Property (checkOnlySpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AsyncResult_Public_Class_checkOnlySpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycheckOnlySpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AsyncResult) => Property (done) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AsyncResult_Public_Class_done_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertydone);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AsyncResult) => Property (id) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AsyncResult_Public_Class_id_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (AsyncResult) => Property (message) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AsyncResult_Public_Class_message_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (AsyncResult) => Property (numberComponentErrors) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AsyncResult_Public_Class_numberComponentErrors_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynumberComponentErrors);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AsyncResult) => Property (numberComponentErrorsSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AsyncResult_Public_Class_numberComponentErrorsSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynumberComponentErrorsSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AsyncResult) => Property (numberComponentsDeployed) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AsyncResult_Public_Class_numberComponentsDeployed_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynumberComponentsDeployed);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AsyncResult) => Property (numberComponentsDeployedSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AsyncResult_Public_Class_numberComponentsDeployedSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynumberComponentsDeployedSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AsyncResult) => Property (numberComponentsTotal) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AsyncResult_Public_Class_numberComponentsTotal_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynumberComponentsTotal);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AsyncResult) => Property (numberComponentsTotalSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AsyncResult_Public_Class_numberComponentsTotalSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynumberComponentsTotalSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AsyncResult) => Property (numberTestErrors) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AsyncResult_Public_Class_numberTestErrors_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynumberTestErrors);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AsyncResult) => Property (numberTestErrorsSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AsyncResult_Public_Class_numberTestErrorsSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynumberTestErrorsSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AsyncResult) => Property (numberTestsCompleted) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AsyncResult_Public_Class_numberTestsCompleted_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynumberTestsCompleted);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AsyncResult) => Property (numberTestsCompletedSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AsyncResult_Public_Class_numberTestsCompletedSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynumberTestsCompletedSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AsyncResult) => Property (numberTestsTotal) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AsyncResult_Public_Class_numberTestsTotal_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynumberTestsTotal);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AsyncResult) => Property (numberTestsTotalSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AsyncResult_Public_Class_numberTestsTotalSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynumberTestsTotalSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AsyncResult) => Property (stateDetail) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AsyncResult_Public_Class_stateDetail_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertystateDetail);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AsyncResult) => Property (stateDetailLastModifiedDate) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AsyncResult_stateDetailLastModifiedDate_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertystateDetailLastModifiedDate);
            Action currentAction = () => propertyInfo.SetValue(_asyncResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (AsyncResult) => Property (stateDetailLastModifiedDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AsyncResult_Public_Class_stateDetailLastModifiedDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertystateDetailLastModifiedDate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AsyncResult) => Property (stateDetailLastModifiedDateSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AsyncResult_Public_Class_stateDetailLastModifiedDateSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertystateDetailLastModifiedDateSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AsyncResult) => Property (statusCode) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AsyncResult_statusCode_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertystatusCode);
            Action currentAction = () => propertyInfo.SetValue(_asyncResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (AsyncResult) => Property (statusCode) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AsyncResult_Public_Class_statusCode_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertystatusCode);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AsyncResult) => Property (statusCodeSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AsyncResult_Public_Class_statusCodeSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertystatusCodeSpecified);

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
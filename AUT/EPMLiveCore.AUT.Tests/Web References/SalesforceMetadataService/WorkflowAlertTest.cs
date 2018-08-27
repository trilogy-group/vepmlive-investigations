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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.WorkflowAlert" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class WorkflowAlertTest : AbstractBaseSetupTypedTest<WorkflowAlert>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WorkflowAlert) Initializer

        private const string PropertyccEmails = "ccEmails";
        private const string Propertydescription = "description";
        private const string Propertyrecipients = "recipients";
        private const string PropertysenderAddress = "senderAddress";
        private const string PropertysenderType = "senderType";
        private const string PropertysenderTypeSpecified = "senderTypeSpecified";
        private const string Propertytemplate = "template";
        private const string FieldccEmailsField = "ccEmailsField";
        private const string FielddescriptionField = "descriptionField";
        private const string FieldprotectedField = "protectedField";
        private const string FieldrecipientsField = "recipientsField";
        private const string FieldsenderAddressField = "senderAddressField";
        private const string FieldsenderTypeField = "senderTypeField";
        private const string FieldsenderTypeFieldSpecified = "senderTypeFieldSpecified";
        private const string FieldtemplateField = "templateField";
        private Type _workflowAlertInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private WorkflowAlert _workflowAlertInstance;
        private WorkflowAlert _workflowAlertInstanceFixture;

        #region General Initializer : Class (WorkflowAlert) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WorkflowAlert" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _workflowAlertInstanceType = typeof(WorkflowAlert);
            _workflowAlertInstanceFixture = Create(true);
            _workflowAlertInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WorkflowAlert)

        #region General Initializer : Class (WorkflowAlert) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="WorkflowAlert" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyccEmails)]
        [TestCase(Propertydescription)]
        [TestCase(Propertyrecipients)]
        [TestCase(PropertysenderAddress)]
        [TestCase(PropertysenderType)]
        [TestCase(PropertysenderTypeSpecified)]
        [TestCase(Propertytemplate)]
        public void AUT_WorkflowAlert_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_workflowAlertInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (WorkflowAlert) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="WorkflowAlert" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldccEmailsField)]
        [TestCase(FielddescriptionField)]
        [TestCase(FieldprotectedField)]
        [TestCase(FieldrecipientsField)]
        [TestCase(FieldsenderAddressField)]
        [TestCase(FieldsenderTypeField)]
        [TestCase(FieldsenderTypeFieldSpecified)]
        [TestCase(FieldtemplateField)]
        public void AUT_WorkflowAlert_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_workflowAlertInstanceFixture, 
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
        ///     Class (<see cref="WorkflowAlert" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_WorkflowAlert_Is_Instance_Present_Test()
        {
            // Assert
            _workflowAlertInstanceType.ShouldNotBeNull();
            _workflowAlertInstance.ShouldNotBeNull();
            _workflowAlertInstanceFixture.ShouldNotBeNull();
            _workflowAlertInstance.ShouldBeAssignableTo<WorkflowAlert>();
            _workflowAlertInstanceFixture.ShouldBeAssignableTo<WorkflowAlert>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (WorkflowAlert) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_WorkflowAlert_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            WorkflowAlert instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _workflowAlertInstanceType.ShouldNotBeNull();
            _workflowAlertInstance.ShouldNotBeNull();
            _workflowAlertInstanceFixture.ShouldNotBeNull();
            _workflowAlertInstance.ShouldBeAssignableTo<WorkflowAlert>();
            _workflowAlertInstanceFixture.ShouldBeAssignableTo<WorkflowAlert>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (WorkflowAlert) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string[]) , PropertyccEmails)]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        [TestCaseGeneric(typeof(WorkflowEmailRecipient[]) , Propertyrecipients)]
        [TestCaseGeneric(typeof(string) , PropertysenderAddress)]
        [TestCaseGeneric(typeof(ActionEmailSenderType) , PropertysenderType)]
        [TestCaseGeneric(typeof(bool) , PropertysenderTypeSpecified)]
        [TestCaseGeneric(typeof(string) , Propertytemplate)]
        public void AUT_WorkflowAlert_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<WorkflowAlert, T>(_workflowAlertInstance, propertyName, Fixture);
        }

        #endregion
        
        #region General Getters/Setters : Class (WorkflowAlert) => Property (ccEmails) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowAlert_ccEmails_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyccEmails);
            Action currentAction = () => propertyInfo.SetValue(_workflowAlertInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowAlert) => Property (ccEmails) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowAlert_Public_Class_ccEmails_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyccEmails);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowAlert) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowAlert_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertydescription);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowAlert) => Property (recipients) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowAlert_recipients_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyrecipients);
            Action currentAction = () => propertyInfo.SetValue(_workflowAlertInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowAlert) => Property (recipients) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowAlert_Public_Class_recipients_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyrecipients);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowAlert) => Property (senderAddress) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowAlert_Public_Class_senderAddress_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysenderAddress);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowAlert) => Property (senderType) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowAlert_senderType_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertysenderType);
            Action currentAction = () => propertyInfo.SetValue(_workflowAlertInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowAlert) => Property (senderType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowAlert_Public_Class_senderType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysenderType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowAlert) => Property (senderTypeSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowAlert_Public_Class_senderTypeSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysenderTypeSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowAlert) => Property (template) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowAlert_Public_Class_template_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertytemplate);

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
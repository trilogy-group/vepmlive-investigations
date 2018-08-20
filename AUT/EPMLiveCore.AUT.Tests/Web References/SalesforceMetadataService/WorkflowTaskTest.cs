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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.WorkflowTask" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class WorkflowTaskTest : AbstractBaseSetupTypedTest<WorkflowTask>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WorkflowTask) Initializer

        private const string PropertyassignedTo = "assignedTo";
        private const string PropertyassignedToType = "assignedToType";
        private const string Propertydescription = "description";
        private const string PropertydueDateOffset = "dueDateOffset";
        private const string PropertynotifyAssignee = "notifyAssignee";
        private const string PropertyoffsetFromField = "offsetFromField";
        private const string Propertypriority = "priority";
        private const string Propertystatus = "status";
        private const string Propertysubject = "subject";
        private const string FieldassignedToField = "assignedToField";
        private const string FieldassignedToTypeField = "assignedToTypeField";
        private const string FielddescriptionField = "descriptionField";
        private const string FielddueDateOffsetField = "dueDateOffsetField";
        private const string FieldnotifyAssigneeField = "notifyAssigneeField";
        private const string FieldoffsetFromFieldField = "offsetFromFieldField";
        private const string FieldpriorityField = "priorityField";
        private const string FieldprotectedField = "protectedField";
        private const string FieldstatusField = "statusField";
        private const string FieldsubjectField = "subjectField";
        private Type _workflowTaskInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private WorkflowTask _workflowTaskInstance;
        private WorkflowTask _workflowTaskInstanceFixture;

        #region General Initializer : Class (WorkflowTask) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WorkflowTask" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _workflowTaskInstanceType = typeof(WorkflowTask);
            _workflowTaskInstanceFixture = Create(true);
            _workflowTaskInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WorkflowTask)

        #region General Initializer : Class (WorkflowTask) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="WorkflowTask" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyassignedTo)]
        [TestCase(PropertyassignedToType)]
        [TestCase(Propertydescription)]
        [TestCase(PropertydueDateOffset)]
        [TestCase(PropertynotifyAssignee)]
        [TestCase(PropertyoffsetFromField)]
        [TestCase(Propertypriority)]
        [TestCase(Propertystatus)]
        [TestCase(Propertysubject)]
        public void AUT_WorkflowTask_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_workflowTaskInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (WorkflowTask) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="WorkflowTask" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldassignedToField)]
        [TestCase(FieldassignedToTypeField)]
        [TestCase(FielddescriptionField)]
        [TestCase(FielddueDateOffsetField)]
        [TestCase(FieldnotifyAssigneeField)]
        [TestCase(FieldoffsetFromFieldField)]
        [TestCase(FieldpriorityField)]
        [TestCase(FieldprotectedField)]
        [TestCase(FieldstatusField)]
        [TestCase(FieldsubjectField)]
        public void AUT_WorkflowTask_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_workflowTaskInstanceFixture, 
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
        ///     Class (<see cref="WorkflowTask" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_WorkflowTask_Is_Instance_Present_Test()
        {
            // Assert
            _workflowTaskInstanceType.ShouldNotBeNull();
            _workflowTaskInstance.ShouldNotBeNull();
            _workflowTaskInstanceFixture.ShouldNotBeNull();
            _workflowTaskInstance.ShouldBeAssignableTo<WorkflowTask>();
            _workflowTaskInstanceFixture.ShouldBeAssignableTo<WorkflowTask>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (WorkflowTask) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_WorkflowTask_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            WorkflowTask instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _workflowTaskInstanceType.ShouldNotBeNull();
            _workflowTaskInstance.ShouldNotBeNull();
            _workflowTaskInstanceFixture.ShouldNotBeNull();
            _workflowTaskInstance.ShouldBeAssignableTo<WorkflowTask>();
            _workflowTaskInstanceFixture.ShouldBeAssignableTo<WorkflowTask>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (WorkflowTask) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyassignedTo)]
        [TestCaseGeneric(typeof(ActionTaskAssignedToTypes) , PropertyassignedToType)]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        [TestCaseGeneric(typeof(int) , PropertydueDateOffset)]
        [TestCaseGeneric(typeof(bool) , PropertynotifyAssignee)]
        [TestCaseGeneric(typeof(string) , PropertyoffsetFromField)]
        [TestCaseGeneric(typeof(string) , Propertypriority)]
        [TestCaseGeneric(typeof(string) , Propertystatus)]
        [TestCaseGeneric(typeof(string) , Propertysubject)]
        public void AUT_WorkflowTask_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<WorkflowTask, T>(_workflowTaskInstance, propertyName, Fixture);
        }

        #endregion
        
        #region General Getters/Setters : Class (WorkflowTask) => Property (assignedTo) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowTask_Public_Class_assignedTo_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyassignedTo);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowTask) => Property (assignedToType) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowTask_assignedToType_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyassignedToType);
            Action currentAction = () => propertyInfo.SetValue(_workflowTaskInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowTask) => Property (assignedToType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowTask_Public_Class_assignedToType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyassignedToType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowTask) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowTask_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WorkflowTask) => Property (dueDateOffset) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowTask_Public_Class_dueDateOffset_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydueDateOffset);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowTask) => Property (notifyAssignee) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowTask_Public_Class_notifyAssignee_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynotifyAssignee);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowTask) => Property (offsetFromField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowTask_Public_Class_offsetFromField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyoffsetFromField);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowTask) => Property (priority) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowTask_Public_Class_priority_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertypriority);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowTask) => Property (status) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowTask_Public_Class_status_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertystatus);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowTask) => Property (subject) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowTask_Public_Class_subject_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertysubject);

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
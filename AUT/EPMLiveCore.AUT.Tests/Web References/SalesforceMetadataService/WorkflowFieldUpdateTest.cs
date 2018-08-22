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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.WorkflowFieldUpdate" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class WorkflowFieldUpdateTest : AbstractBaseSetupTypedTest<WorkflowFieldUpdate>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WorkflowFieldUpdate) Initializer

        private const string Propertydescription = "description";
        private const string Propertyfield = "field";
        private const string Propertyformula = "formula";
        private const string PropertyliteralValue = "literalValue";
        private const string PropertylookupValue = "lookupValue";
        private const string PropertylookupValueType = "lookupValueType";
        private const string PropertylookupValueTypeSpecified = "lookupValueTypeSpecified";
        private const string Propertyname = "name";
        private const string PropertynotifyAssignee = "notifyAssignee";
        private const string Propertyoperation = "operation";
        private const string PropertyreevaluateOnChange = "reevaluateOnChange";
        private const string PropertyreevaluateOnChangeSpecified = "reevaluateOnChangeSpecified";
        private const string PropertytargetObject = "targetObject";
        private const string FielddescriptionField = "descriptionField";
        private const string FieldfieldField = "fieldField";
        private const string FieldformulaField = "formulaField";
        private const string FieldliteralValueField = "literalValueField";
        private const string FieldlookupValueField = "lookupValueField";
        private const string FieldlookupValueTypeField = "lookupValueTypeField";
        private const string FieldlookupValueTypeFieldSpecified = "lookupValueTypeFieldSpecified";
        private const string FieldnameField = "nameField";
        private const string FieldnotifyAssigneeField = "notifyAssigneeField";
        private const string FieldoperationField = "operationField";
        private const string FieldprotectedField = "protectedField";
        private const string FieldreevaluateOnChangeField = "reevaluateOnChangeField";
        private const string FieldreevaluateOnChangeFieldSpecified = "reevaluateOnChangeFieldSpecified";
        private const string FieldtargetObjectField = "targetObjectField";
        private Type _workflowFieldUpdateInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private WorkflowFieldUpdate _workflowFieldUpdateInstance;
        private WorkflowFieldUpdate _workflowFieldUpdateInstanceFixture;

        #region General Initializer : Class (WorkflowFieldUpdate) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WorkflowFieldUpdate" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _workflowFieldUpdateInstanceType = typeof(WorkflowFieldUpdate);
            _workflowFieldUpdateInstanceFixture = Create(true);
            _workflowFieldUpdateInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WorkflowFieldUpdate)

        #region General Initializer : Class (WorkflowFieldUpdate) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="WorkflowFieldUpdate" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertydescription)]
        [TestCase(Propertyfield)]
        [TestCase(Propertyformula)]
        [TestCase(PropertyliteralValue)]
        [TestCase(PropertylookupValue)]
        [TestCase(PropertylookupValueType)]
        [TestCase(PropertylookupValueTypeSpecified)]
        [TestCase(Propertyname)]
        [TestCase(PropertynotifyAssignee)]
        [TestCase(Propertyoperation)]
        [TestCase(PropertyreevaluateOnChange)]
        [TestCase(PropertyreevaluateOnChangeSpecified)]
        [TestCase(PropertytargetObject)]
        public void AUT_WorkflowFieldUpdate_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_workflowFieldUpdateInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (WorkflowFieldUpdate) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="WorkflowFieldUpdate" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielddescriptionField)]
        [TestCase(FieldfieldField)]
        [TestCase(FieldformulaField)]
        [TestCase(FieldliteralValueField)]
        [TestCase(FieldlookupValueField)]
        [TestCase(FieldlookupValueTypeField)]
        [TestCase(FieldlookupValueTypeFieldSpecified)]
        [TestCase(FieldnameField)]
        [TestCase(FieldnotifyAssigneeField)]
        [TestCase(FieldoperationField)]
        [TestCase(FieldprotectedField)]
        [TestCase(FieldreevaluateOnChangeField)]
        [TestCase(FieldreevaluateOnChangeFieldSpecified)]
        [TestCase(FieldtargetObjectField)]
        public void AUT_WorkflowFieldUpdate_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_workflowFieldUpdateInstanceFixture, 
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
        ///     Class (<see cref="WorkflowFieldUpdate" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_WorkflowFieldUpdate_Is_Instance_Present_Test()
        {
            // Assert
            _workflowFieldUpdateInstanceType.ShouldNotBeNull();
            _workflowFieldUpdateInstance.ShouldNotBeNull();
            _workflowFieldUpdateInstanceFixture.ShouldNotBeNull();
            _workflowFieldUpdateInstance.ShouldBeAssignableTo<WorkflowFieldUpdate>();
            _workflowFieldUpdateInstanceFixture.ShouldBeAssignableTo<WorkflowFieldUpdate>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (WorkflowFieldUpdate) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_WorkflowFieldUpdate_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            WorkflowFieldUpdate instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _workflowFieldUpdateInstanceType.ShouldNotBeNull();
            _workflowFieldUpdateInstance.ShouldNotBeNull();
            _workflowFieldUpdateInstanceFixture.ShouldNotBeNull();
            _workflowFieldUpdateInstance.ShouldBeAssignableTo<WorkflowFieldUpdate>();
            _workflowFieldUpdateInstanceFixture.ShouldBeAssignableTo<WorkflowFieldUpdate>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (WorkflowFieldUpdate) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        [TestCaseGeneric(typeof(string) , Propertyfield)]
        [TestCaseGeneric(typeof(string) , Propertyformula)]
        [TestCaseGeneric(typeof(string) , PropertyliteralValue)]
        [TestCaseGeneric(typeof(string) , PropertylookupValue)]
        [TestCaseGeneric(typeof(LookupValueType) , PropertylookupValueType)]
        [TestCaseGeneric(typeof(bool) , PropertylookupValueTypeSpecified)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        [TestCaseGeneric(typeof(bool) , PropertynotifyAssignee)]
        [TestCaseGeneric(typeof(FieldUpdateOperation) , Propertyoperation)]
        [TestCaseGeneric(typeof(bool) , PropertyreevaluateOnChange)]
        [TestCaseGeneric(typeof(bool) , PropertyreevaluateOnChangeSpecified)]
        [TestCaseGeneric(typeof(string) , PropertytargetObject)]
        public void AUT_WorkflowFieldUpdate_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<WorkflowFieldUpdate, T>(_workflowFieldUpdateInstance, propertyName, Fixture);
        }

        #endregion
        
        #region General Getters/Setters : Class (WorkflowFieldUpdate) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowFieldUpdate_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WorkflowFieldUpdate) => Property (field) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowFieldUpdate_Public_Class_field_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyfield);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowFieldUpdate) => Property (formula) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowFieldUpdate_Public_Class_formula_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyformula);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowFieldUpdate) => Property (literalValue) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowFieldUpdate_Public_Class_literalValue_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyliteralValue);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowFieldUpdate) => Property (lookupValue) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowFieldUpdate_Public_Class_lookupValue_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylookupValue);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowFieldUpdate) => Property (lookupValueType) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowFieldUpdate_lookupValueType_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertylookupValueType);
            Action currentAction = () => propertyInfo.SetValue(_workflowFieldUpdateInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowFieldUpdate) => Property (lookupValueType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowFieldUpdate_Public_Class_lookupValueType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylookupValueType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowFieldUpdate) => Property (lookupValueTypeSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowFieldUpdate_Public_Class_lookupValueTypeSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylookupValueTypeSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowFieldUpdate) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowFieldUpdate_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WorkflowFieldUpdate) => Property (notifyAssignee) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowFieldUpdate_Public_Class_notifyAssignee_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WorkflowFieldUpdate) => Property (operation) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowFieldUpdate_operation_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyoperation);
            Action currentAction = () => propertyInfo.SetValue(_workflowFieldUpdateInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowFieldUpdate) => Property (operation) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowFieldUpdate_Public_Class_operation_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyoperation);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowFieldUpdate) => Property (reevaluateOnChange) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowFieldUpdate_Public_Class_reevaluateOnChange_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyreevaluateOnChange);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowFieldUpdate) => Property (reevaluateOnChangeSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowFieldUpdate_Public_Class_reevaluateOnChangeSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyreevaluateOnChangeSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowFieldUpdate) => Property (targetObject) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowFieldUpdate_Public_Class_targetObject_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytargetObject);

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
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

namespace EPMLiveWebParts.SSRS2010
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.SSRS2010.Job" />)
    ///     and namespace <see cref="EPMLiveWebParts.SSRS2010"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class JobTest : AbstractBaseSetupTypedTest<Job>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Job) Initializer

        private const string PropertyJobID = "JobID";
        private const string PropertyName = "Name";
        private const string PropertyPath = "Path";
        private const string PropertyDescription = "Description";
        private const string PropertyMachine = "Machine";
        private const string PropertyUser = "User";
        private const string PropertyStartDateTime = "StartDateTime";
        private const string PropertyJobActionName = "JobActionName";
        private const string PropertyJobTypeName = "JobTypeName";
        private const string PropertyJobStatusName = "JobStatusName";
        private const string FieldjobIDField = "jobIDField";
        private const string FieldnameField = "nameField";
        private const string FieldpathField = "pathField";
        private const string FielddescriptionField = "descriptionField";
        private const string FieldmachineField = "machineField";
        private const string FielduserField = "userField";
        private const string FieldstartDateTimeField = "startDateTimeField";
        private const string FieldjobActionNameField = "jobActionNameField";
        private const string FieldjobTypeNameField = "jobTypeNameField";
        private const string FieldjobStatusNameField = "jobStatusNameField";
        private Type _jobInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Job _jobInstance;
        private Job _jobInstanceFixture;

        #region General Initializer : Class (Job) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Job" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _jobInstanceType = typeof(Job);
            _jobInstanceFixture = Create(true);
            _jobInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Job)

        #region General Initializer : Class (Job) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Job" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyJobID)]
        [TestCase(PropertyName)]
        [TestCase(PropertyPath)]
        [TestCase(PropertyDescription)]
        [TestCase(PropertyMachine)]
        [TestCase(PropertyUser)]
        [TestCase(PropertyStartDateTime)]
        [TestCase(PropertyJobActionName)]
        [TestCase(PropertyJobTypeName)]
        [TestCase(PropertyJobStatusName)]
        public void AUT_Job_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_jobInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Job) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Job" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldjobIDField)]
        [TestCase(FieldnameField)]
        [TestCase(FieldpathField)]
        [TestCase(FielddescriptionField)]
        [TestCase(FieldmachineField)]
        [TestCase(FielduserField)]
        [TestCase(FieldstartDateTimeField)]
        [TestCase(FieldjobActionNameField)]
        [TestCase(FieldjobTypeNameField)]
        [TestCase(FieldjobStatusNameField)]
        public void AUT_Job_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_jobInstanceFixture, 
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
        ///     Class (<see cref="Job" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_Job_Is_Instance_Present_Test()
        {
            // Assert
            _jobInstanceType.ShouldNotBeNull();
            _jobInstance.ShouldNotBeNull();
            _jobInstanceFixture.ShouldNotBeNull();
            _jobInstance.ShouldBeAssignableTo<Job>();
            _jobInstanceFixture.ShouldBeAssignableTo<Job>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Job) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_Job_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Job instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _jobInstanceType.ShouldNotBeNull();
            _jobInstance.ShouldNotBeNull();
            _jobInstanceFixture.ShouldNotBeNull();
            _jobInstance.ShouldBeAssignableTo<Job>();
            _jobInstanceFixture.ShouldBeAssignableTo<Job>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Job) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyJobID)]
        [TestCaseGeneric(typeof(string) , PropertyName)]
        [TestCaseGeneric(typeof(string) , PropertyPath)]
        [TestCaseGeneric(typeof(string) , PropertyDescription)]
        [TestCaseGeneric(typeof(string) , PropertyMachine)]
        [TestCaseGeneric(typeof(string) , PropertyUser)]
        [TestCaseGeneric(typeof(System.DateTime) , PropertyStartDateTime)]
        [TestCaseGeneric(typeof(string) , PropertyJobActionName)]
        [TestCaseGeneric(typeof(string) , PropertyJobTypeName)]
        [TestCaseGeneric(typeof(string) , PropertyJobStatusName)]
        public void AUT_Job_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Job, T>(_jobInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Job) => Property (Description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Job_Public_Class_Description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDescription);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Job) => Property (JobActionName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Job_Public_Class_JobActionName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyJobActionName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Job) => Property (JobID) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Job_Public_Class_JobID_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyJobID);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Job) => Property (JobStatusName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Job_Public_Class_JobStatusName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyJobStatusName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Job) => Property (JobTypeName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Job_Public_Class_JobTypeName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyJobTypeName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Job) => Property (Machine) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Job_Public_Class_Machine_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyMachine);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Job) => Property (Name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Job_Public_Class_Name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Job) => Property (Path) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Job_Public_Class_Path_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPath);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Job) => Property (StartDateTime) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Job_StartDateTime_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyStartDateTime);
            Action currentAction = () => propertyInfo.SetValue(_jobInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Job) => Property (StartDateTime) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Job_Public_Class_StartDateTime_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyStartDateTime);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Job) => Property (User) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Job_Public_Class_User_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyUser);

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
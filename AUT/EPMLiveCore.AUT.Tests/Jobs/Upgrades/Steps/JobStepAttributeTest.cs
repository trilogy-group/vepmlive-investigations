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

namespace EPMLiveCore.Jobs.Upgrades.Steps
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Jobs.Upgrades.Steps.JobStepAttribute" />)
    ///     and namespace <see cref="EPMLiveCore.Jobs.Upgrades.Steps"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class JobStepAttributeTest : AbstractBaseSetupTypedTest<JobStepAttribute>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (JobStepAttribute) Initializer

        private const string PropertyParentJob = "ParentJob";
        private const string PropertySequence = "Sequence";
        private Type _jobStepAttributeInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private JobStepAttribute _jobStepAttributeInstance;
        private JobStepAttribute _jobStepAttributeInstanceFixture;

        #region General Initializer : Class (JobStepAttribute) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="JobStepAttribute" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _jobStepAttributeInstanceType = typeof(JobStepAttribute);
            _jobStepAttributeInstanceFixture = Create(true);
            _jobStepAttributeInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (JobStepAttribute)

        #region General Initializer : Class (JobStepAttribute) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="JobStepAttribute" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyParentJob)]
        [TestCase(PropertySequence)]
        public void AUT_JobStepAttribute_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_jobStepAttributeInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="JobStepAttribute" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_JobStepAttribute_Is_Instance_Present_Test()
        {
            // Assert
            _jobStepAttributeInstanceType.ShouldNotBeNull();
            _jobStepAttributeInstance.ShouldNotBeNull();
            _jobStepAttributeInstanceFixture.ShouldNotBeNull();
            _jobStepAttributeInstance.ShouldBeAssignableTo<JobStepAttribute>();
            _jobStepAttributeInstanceFixture.ShouldBeAssignableTo<JobStepAttribute>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (JobStepAttribute) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_JobStepAttribute_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var parentJob = CreateType<string>();
            var sequence = CreateType<double>();
            JobStepAttribute instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new JobStepAttribute(parentJob, sequence);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _jobStepAttributeInstance.ShouldNotBeNull();
            _jobStepAttributeInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<JobStepAttribute>();
        }

        #endregion

        #region General Constructor : Class (JobStepAttribute) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_JobStepAttribute_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var parentJob = CreateType<string>();
            var sequence = CreateType<double>();
            JobStepAttribute instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new JobStepAttribute(parentJob, sequence);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _jobStepAttributeInstance.ShouldNotBeNull();
            _jobStepAttributeInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (JobStepAttribute) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyParentJob)]
        [TestCaseGeneric(typeof(double) , PropertySequence)]
        public void AUT_JobStepAttribute_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<JobStepAttribute, T>(_jobStepAttributeInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (JobStepAttribute) => Property (ParentJob) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_JobStepAttribute_Public_Class_ParentJob_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyParentJob);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (JobStepAttribute) => Property (Sequence) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_JobStepAttribute_Public_Class_Sequence_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySequence);

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
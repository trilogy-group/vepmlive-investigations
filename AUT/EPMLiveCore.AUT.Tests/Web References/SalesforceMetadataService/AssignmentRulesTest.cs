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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.AssignmentRules" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class AssignmentRulesTest : AbstractBaseSetupTypedTest<AssignmentRules>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (AssignmentRules) Initializer

        private const string PropertyassignmentRule = "assignmentRule";
        private const string FieldassignmentRuleField = "assignmentRuleField";
        private Type _assignmentRulesInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private AssignmentRules _assignmentRulesInstance;
        private AssignmentRules _assignmentRulesInstanceFixture;

        #region General Initializer : Class (AssignmentRules) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="AssignmentRules" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _assignmentRulesInstanceType = typeof(AssignmentRules);
            _assignmentRulesInstanceFixture = Create(true);
            _assignmentRulesInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (AssignmentRules)

        #region General Initializer : Class (AssignmentRules) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="AssignmentRules" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyassignmentRule)]
        public void AUT_AssignmentRules_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_assignmentRulesInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (AssignmentRules) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="AssignmentRules" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldassignmentRuleField)]
        public void AUT_AssignmentRules_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_assignmentRulesInstanceFixture, 
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
        ///     Class (<see cref="AssignmentRules" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_AssignmentRules_Is_Instance_Present_Test()
        {
            // Assert
            _assignmentRulesInstanceType.ShouldNotBeNull();
            _assignmentRulesInstance.ShouldNotBeNull();
            _assignmentRulesInstanceFixture.ShouldNotBeNull();
            _assignmentRulesInstance.ShouldBeAssignableTo<AssignmentRules>();
            _assignmentRulesInstanceFixture.ShouldBeAssignableTo<AssignmentRules>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (AssignmentRules) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_AssignmentRules_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            AssignmentRules instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _assignmentRulesInstanceType.ShouldNotBeNull();
            _assignmentRulesInstance.ShouldNotBeNull();
            _assignmentRulesInstanceFixture.ShouldNotBeNull();
            _assignmentRulesInstance.ShouldBeAssignableTo<AssignmentRules>();
            _assignmentRulesInstanceFixture.ShouldBeAssignableTo<AssignmentRules>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (AssignmentRules) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(AssignmentRule[]) , PropertyassignmentRule)]
        public void AUT_AssignmentRules_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<AssignmentRules, T>(_assignmentRulesInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (AssignmentRules) => Property (assignmentRule) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AssignmentRules_assignmentRule_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyassignmentRule);
            Action currentAction = () => propertyInfo.SetValue(_assignmentRulesInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (AssignmentRules) => Property (assignmentRule) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AssignmentRules_Public_Class_assignmentRule_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyassignmentRule);

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
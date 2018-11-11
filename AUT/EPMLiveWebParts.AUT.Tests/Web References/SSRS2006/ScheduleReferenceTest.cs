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

namespace EPMLiveWebParts.SSRS2006
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.SSRS2006.ScheduleReference" />)
    ///     and namespace <see cref="EPMLiveWebParts.SSRS2006"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ScheduleReferenceTest : AbstractBaseSetupTypedTest<ScheduleReference>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ScheduleReference) Initializer

        private const string PropertyScheduleID = "ScheduleID";
        private const string PropertyDefinition = "Definition";
        private const string FieldscheduleIDField = "scheduleIDField";
        private const string FielddefinitionField = "definitionField";
        private Type _scheduleReferenceInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ScheduleReference _scheduleReferenceInstance;
        private ScheduleReference _scheduleReferenceInstanceFixture;

        #region General Initializer : Class (ScheduleReference) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ScheduleReference" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _scheduleReferenceInstanceType = typeof(ScheduleReference);
            _scheduleReferenceInstanceFixture = Create(true);
            _scheduleReferenceInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ScheduleReference)

        #region General Initializer : Class (ScheduleReference) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ScheduleReference" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyScheduleID)]
        [TestCase(PropertyDefinition)]
        public void AUT_ScheduleReference_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_scheduleReferenceInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ScheduleReference) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ScheduleReference" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldscheduleIDField)]
        [TestCase(FielddefinitionField)]
        public void AUT_ScheduleReference_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_scheduleReferenceInstanceFixture, 
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
        ///     Class (<see cref="ScheduleReference" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ScheduleReference_Is_Instance_Present_Test()
        {
            // Assert
            _scheduleReferenceInstanceType.ShouldNotBeNull();
            _scheduleReferenceInstance.ShouldNotBeNull();
            _scheduleReferenceInstanceFixture.ShouldNotBeNull();
            _scheduleReferenceInstance.ShouldBeAssignableTo<ScheduleReference>();
            _scheduleReferenceInstanceFixture.ShouldBeAssignableTo<ScheduleReference>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ScheduleReference) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ScheduleReference_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ScheduleReference instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _scheduleReferenceInstanceType.ShouldNotBeNull();
            _scheduleReferenceInstance.ShouldNotBeNull();
            _scheduleReferenceInstanceFixture.ShouldNotBeNull();
            _scheduleReferenceInstance.ShouldBeAssignableTo<ScheduleReference>();
            _scheduleReferenceInstanceFixture.ShouldBeAssignableTo<ScheduleReference>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ScheduleReference) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyScheduleID)]
        [TestCaseGeneric(typeof(ScheduleDefinition) , PropertyDefinition)]
        public void AUT_ScheduleReference_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ScheduleReference, T>(_scheduleReferenceInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ScheduleReference) => Property (Definition) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ScheduleReference_Definition_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyDefinition);
            Action currentAction = () => propertyInfo.SetValue(_scheduleReferenceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ScheduleReference) => Property (Definition) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ScheduleReference_Public_Class_Definition_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDefinition);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ScheduleReference) => Property (ScheduleID) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ScheduleReference_Public_Class_ScheduleID_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyScheduleID);

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
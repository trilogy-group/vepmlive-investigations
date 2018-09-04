using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace WorkEnginePPM.DataServiceModules
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.DataServiceModules.DSMLog" />)
    ///     and namespace <see cref="WorkEnginePPM.DataServiceModules"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class DSMLogTest : AbstractBaseSetupTypedTest<DSMLog>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DSMLog) Initializer

        private const string PropertyInfoCount = "InfoCount";
        private const string PropertyWarningCount = "WarningCount";
        private const string PropertyErrorCount = "ErrorCount";
        private const string PropertyMessages = "Messages";
        private Type _dSMLogInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DSMLog _dSMLogInstance;
        private DSMLog _dSMLogInstanceFixture;

        #region General Initializer : Class (DSMLog) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DSMLog" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _dSMLogInstanceType = typeof(DSMLog);
            _dSMLogInstanceFixture = Create(true);
            _dSMLogInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DSMLog)

        #region General Initializer : Class (DSMLog) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DSMLog" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyInfoCount)]
        [TestCase(PropertyWarningCount)]
        [TestCase(PropertyErrorCount)]
        [TestCase(PropertyMessages)]
        public void AUT_DSMLog_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_dSMLogInstanceFixture,
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
        ///     Class (<see cref="DSMLog" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_DSMLog_Is_Instance_Present_Test()
        {
            // Assert
            _dSMLogInstanceType.ShouldNotBeNull();
            _dSMLogInstance.ShouldNotBeNull();
            _dSMLogInstanceFixture.ShouldNotBeNull();
            _dSMLogInstance.ShouldBeAssignableTo<DSMLog>();
            _dSMLogInstanceFixture.ShouldBeAssignableTo<DSMLog>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DSMLog) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_DSMLog_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DSMLog instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _dSMLogInstanceType.ShouldNotBeNull();
            _dSMLogInstance.ShouldNotBeNull();
            _dSMLogInstanceFixture.ShouldNotBeNull();
            _dSMLogInstance.ShouldBeAssignableTo<DSMLog>();
            _dSMLogInstanceFixture.ShouldBeAssignableTo<DSMLog>();
        }

        #endregion

        #region General Constructor : Class (DSMLog) Default Assignment Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_DSMLog_Constructor_Instantiated_With_Default_Assignments_Test()
        {

            // Act
            var dSMLogInstance  = new DSMLog();

            // Asserts
            dSMLogInstance.ShouldNotBeNull();
            dSMLogInstance.ShouldBeAssignableTo<DSMLog>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DSMLog) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(Int32) , PropertyInfoCount)]
        [TestCaseGeneric(typeof(Int32) , PropertyWarningCount)]
        [TestCaseGeneric(typeof(Int32) , PropertyErrorCount)]
        [TestCaseGeneric(typeof(List<DSMMessage>) , PropertyMessages)]
        public void AUT_DSMLog_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DSMLog, T>(_dSMLogInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DSMLog) => Property (ErrorCount) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_DSMLog_Public_Class_ErrorCount_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyErrorCount);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DSMLog) => Property (InfoCount) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_DSMLog_Public_Class_InfoCount_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyInfoCount);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DSMLog) => Property (Messages) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_DSMLog_Public_Class_Messages_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyMessages);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DSMLog) => Property (WarningCount) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_DSMLog_Public_Class_WarningCount_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyWarningCount);

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
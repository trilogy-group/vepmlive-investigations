using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.Jobs
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Jobs.ResourceImportLog" />)
    ///     and namespace <see cref="EPMLiveCore.Jobs"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ResourceImportLogTest : AbstractBaseSetupTypedTest<ResourceImportLog>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ResourceImportLog) Initializer

        private const string PropertyInfoCount = "InfoCount";
        private const string PropertyWarningCount = "WarningCount";
        private const string PropertyErrorCount = "ErrorCount";
        private const string PropertyMessages = "Messages";
        private Type _resourceImportLogInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ResourceImportLog _resourceImportLogInstance;
        private ResourceImportLog _resourceImportLogInstanceFixture;

        #region General Initializer : Class (ResourceImportLog) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ResourceImportLog" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _resourceImportLogInstanceType = typeof(ResourceImportLog);
            _resourceImportLogInstanceFixture = Create(true);
            _resourceImportLogInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ResourceImportLog)

        #region General Initializer : Class (ResourceImportLog) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ResourceImportLog" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyInfoCount)]
        [TestCase(PropertyWarningCount)]
        [TestCase(PropertyErrorCount)]
        [TestCase(PropertyMessages)]
        public void AUT_ResourceImportLog_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_resourceImportLogInstanceFixture,
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
        ///     Class (<see cref="ResourceImportLog" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ResourceImportLog_Is_Instance_Present_Test()
        {
            // Assert
            _resourceImportLogInstanceType.ShouldNotBeNull();
            _resourceImportLogInstance.ShouldNotBeNull();
            _resourceImportLogInstanceFixture.ShouldNotBeNull();
            _resourceImportLogInstance.ShouldBeAssignableTo<ResourceImportLog>();
            _resourceImportLogInstanceFixture.ShouldBeAssignableTo<ResourceImportLog>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ResourceImportLog) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ResourceImportLog_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ResourceImportLog instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _resourceImportLogInstanceType.ShouldNotBeNull();
            _resourceImportLogInstance.ShouldNotBeNull();
            _resourceImportLogInstanceFixture.ShouldNotBeNull();
            _resourceImportLogInstance.ShouldBeAssignableTo<ResourceImportLog>();
            _resourceImportLogInstanceFixture.ShouldBeAssignableTo<ResourceImportLog>();
        }

        #endregion

        #region General Constructor : Class (ResourceImportLog) Default Assignment Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ResourceImportLog_Constructor_Instantiated_With_Default_Assignments_Test()
        {

            // Act
            var resourceImportLogInstance  = new ResourceImportLog();

            // Asserts
            resourceImportLogInstance.ShouldNotBeNull();
            resourceImportLogInstance.ShouldBeAssignableTo<ResourceImportLog>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ResourceImportLog) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(Int32) , PropertyInfoCount)]
        [TestCaseGeneric(typeof(Int32) , PropertyWarningCount)]
        [TestCaseGeneric(typeof(Int32) , PropertyErrorCount)]
        [TestCaseGeneric(typeof(List<ResourceImportMessage>) , PropertyMessages)]
        public void AUT_ResourceImportLog_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ResourceImportLog, T>(_resourceImportLogInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ResourceImportLog) => Property (ErrorCount) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ResourceImportLog_Public_Class_ErrorCount_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ResourceImportLog) => Property (InfoCount) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ResourceImportLog_Public_Class_InfoCount_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ResourceImportLog) => Property (Messages) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ResourceImportLog_Public_Class_Messages_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ResourceImportLog) => Property (WarningCount) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ResourceImportLog_Public_Class_WarningCount_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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
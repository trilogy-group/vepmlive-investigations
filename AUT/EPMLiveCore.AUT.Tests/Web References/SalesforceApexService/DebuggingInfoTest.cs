using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.SalesforceApexService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceApexService.DebuggingInfo" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceApexService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DebuggingInfoTest : AbstractBaseSetupTypedTest<DebuggingInfo>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DebuggingInfo) Initializer

        private const string PropertydebugLog = "debugLog";
        private const string FielddebugLogField = "debugLogField";
        private Type _debuggingInfoInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DebuggingInfo _debuggingInfoInstance;
        private DebuggingInfo _debuggingInfoInstanceFixture;

        #region General Initializer : Class (DebuggingInfo) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DebuggingInfo" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _debuggingInfoInstanceType = typeof(DebuggingInfo);
            _debuggingInfoInstanceFixture = Create(true);
            _debuggingInfoInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DebuggingInfo)

        #region General Initializer : Class (DebuggingInfo) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DebuggingInfo" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertydebugLog)]
        public void AUT_DebuggingInfo_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_debuggingInfoInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DebuggingInfo) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DebuggingInfo" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielddebugLogField)]
        public void AUT_DebuggingInfo_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_debuggingInfoInstanceFixture, 
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
        ///     Class (<see cref="DebuggingInfo" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DebuggingInfo_Is_Instance_Present_Test()
        {
            // Assert
            _debuggingInfoInstanceType.ShouldNotBeNull();
            _debuggingInfoInstance.ShouldNotBeNull();
            _debuggingInfoInstanceFixture.ShouldNotBeNull();
            _debuggingInfoInstance.ShouldBeAssignableTo<DebuggingInfo>();
            _debuggingInfoInstanceFixture.ShouldBeAssignableTo<DebuggingInfo>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DebuggingInfo) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DebuggingInfo_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DebuggingInfo instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _debuggingInfoInstanceType.ShouldNotBeNull();
            _debuggingInfoInstance.ShouldNotBeNull();
            _debuggingInfoInstanceFixture.ShouldNotBeNull();
            _debuggingInfoInstance.ShouldBeAssignableTo<DebuggingInfo>();
            _debuggingInfoInstanceFixture.ShouldBeAssignableTo<DebuggingInfo>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DebuggingInfo) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertydebugLog)]
        public void AUT_DebuggingInfo_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DebuggingInfo, T>(_debuggingInfoInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DebuggingInfo) => Property (debugLog) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DebuggingInfo_Public_Class_debugLog_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydebugLog);

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
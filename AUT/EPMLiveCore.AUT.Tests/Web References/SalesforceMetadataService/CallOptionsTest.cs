using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.SalesforceMetadataService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.CallOptions" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CallOptionsTest : AbstractBaseSetupTypedTest<CallOptions>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CallOptions) Initializer

        private const string Propertyclient = "client";
        private const string FieldclientField = "clientField";
        private Type _callOptionsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CallOptions _callOptionsInstance;
        private CallOptions _callOptionsInstanceFixture;

        #region General Initializer : Class (CallOptions) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CallOptions" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _callOptionsInstanceType = typeof(CallOptions);
            _callOptionsInstanceFixture = Create(true);
            _callOptionsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CallOptions)

        #region General Initializer : Class (CallOptions) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CallOptions" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyclient)]
        public void AUT_CallOptions_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_callOptionsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CallOptions) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CallOptions" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldclientField)]
        public void AUT_CallOptions_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_callOptionsInstanceFixture, 
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
        ///     Class (<see cref="CallOptions" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_CallOptions_Is_Instance_Present_Test()
        {
            // Assert
            _callOptionsInstanceType.ShouldNotBeNull();
            _callOptionsInstance.ShouldNotBeNull();
            _callOptionsInstanceFixture.ShouldNotBeNull();
            _callOptionsInstance.ShouldBeAssignableTo<CallOptions>();
            _callOptionsInstanceFixture.ShouldBeAssignableTo<CallOptions>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CallOptions) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_CallOptions_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CallOptions instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _callOptionsInstanceType.ShouldNotBeNull();
            _callOptionsInstance.ShouldNotBeNull();
            _callOptionsInstanceFixture.ShouldNotBeNull();
            _callOptionsInstance.ShouldBeAssignableTo<CallOptions>();
            _callOptionsInstanceFixture.ShouldBeAssignableTo<CallOptions>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CallOptions) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertyclient)]
        public void AUT_CallOptions_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CallOptions, T>(_callOptionsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (CallOptions) => Property (client) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CallOptions_Public_Class_client_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyclient);

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
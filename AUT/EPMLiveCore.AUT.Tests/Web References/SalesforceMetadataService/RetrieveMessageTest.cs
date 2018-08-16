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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.RetrieveMessage" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class RetrieveMessageTest : AbstractBaseSetupTypedTest<RetrieveMessage>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (RetrieveMessage) Initializer

        private const string PropertyfileName = "fileName";
        private const string Propertyproblem = "problem";
        private const string FieldfileNameField = "fileNameField";
        private const string FieldproblemField = "problemField";
        private Type _retrieveMessageInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private RetrieveMessage _retrieveMessageInstance;
        private RetrieveMessage _retrieveMessageInstanceFixture;

        #region General Initializer : Class (RetrieveMessage) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RetrieveMessage" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _retrieveMessageInstanceType = typeof(RetrieveMessage);
            _retrieveMessageInstanceFixture = Create(true);
            _retrieveMessageInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (RetrieveMessage)

        #region General Initializer : Class (RetrieveMessage) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="RetrieveMessage" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyfileName)]
        [TestCase(Propertyproblem)]
        public void AUT_RetrieveMessage_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_retrieveMessageInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (RetrieveMessage) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="RetrieveMessage" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldfileNameField)]
        [TestCase(FieldproblemField)]
        public void AUT_RetrieveMessage_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_retrieveMessageInstanceFixture, 
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
        ///     Class (<see cref="RetrieveMessage" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_RetrieveMessage_Is_Instance_Present_Test()
        {
            // Assert
            _retrieveMessageInstanceType.ShouldNotBeNull();
            _retrieveMessageInstance.ShouldNotBeNull();
            _retrieveMessageInstanceFixture.ShouldNotBeNull();
            _retrieveMessageInstance.ShouldBeAssignableTo<RetrieveMessage>();
            _retrieveMessageInstanceFixture.ShouldBeAssignableTo<RetrieveMessage>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (RetrieveMessage) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_RetrieveMessage_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            RetrieveMessage instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _retrieveMessageInstanceType.ShouldNotBeNull();
            _retrieveMessageInstance.ShouldNotBeNull();
            _retrieveMessageInstanceFixture.ShouldNotBeNull();
            _retrieveMessageInstance.ShouldBeAssignableTo<RetrieveMessage>();
            _retrieveMessageInstanceFixture.ShouldBeAssignableTo<RetrieveMessage>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (RetrieveMessage) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyfileName)]
        [TestCaseGeneric(typeof(string) , Propertyproblem)]
        public void AUT_RetrieveMessage_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<RetrieveMessage, T>(_retrieveMessageInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (RetrieveMessage) => Property (fileName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RetrieveMessage_Public_Class_fileName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyfileName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RetrieveMessage) => Property (problem) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RetrieveMessage_Public_Class_problem_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyproblem);

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
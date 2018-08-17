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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceApexService.DeleteApexResult" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceApexService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DeleteApexResultTest : AbstractBaseSetupTypedTest<DeleteApexResult>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DeleteApexResult) Initializer

        private const string Propertyid = "id";
        private const string Propertyproblem = "problem";
        private const string Propertysuccess = "success";
        private const string FieldidField = "idField";
        private const string FieldproblemField = "problemField";
        private const string FieldsuccessField = "successField";
        private Type _deleteApexResultInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DeleteApexResult _deleteApexResultInstance;
        private DeleteApexResult _deleteApexResultInstanceFixture;

        #region General Initializer : Class (DeleteApexResult) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DeleteApexResult" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _deleteApexResultInstanceType = typeof(DeleteApexResult);
            _deleteApexResultInstanceFixture = Create(true);
            _deleteApexResultInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DeleteApexResult)

        #region General Initializer : Class (DeleteApexResult) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DeleteApexResult" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyid)]
        [TestCase(Propertyproblem)]
        [TestCase(Propertysuccess)]
        public void AUT_DeleteApexResult_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_deleteApexResultInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DeleteApexResult) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DeleteApexResult" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldidField)]
        [TestCase(FieldproblemField)]
        [TestCase(FieldsuccessField)]
        public void AUT_DeleteApexResult_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_deleteApexResultInstanceFixture, 
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
        ///     Class (<see cref="DeleteApexResult" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DeleteApexResult_Is_Instance_Present_Test()
        {
            // Assert
            _deleteApexResultInstanceType.ShouldNotBeNull();
            _deleteApexResultInstance.ShouldNotBeNull();
            _deleteApexResultInstanceFixture.ShouldNotBeNull();
            _deleteApexResultInstance.ShouldBeAssignableTo<DeleteApexResult>();
            _deleteApexResultInstanceFixture.ShouldBeAssignableTo<DeleteApexResult>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DeleteApexResult) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DeleteApexResult_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DeleteApexResult instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _deleteApexResultInstanceType.ShouldNotBeNull();
            _deleteApexResultInstance.ShouldNotBeNull();
            _deleteApexResultInstanceFixture.ShouldNotBeNull();
            _deleteApexResultInstance.ShouldBeAssignableTo<DeleteApexResult>();
            _deleteApexResultInstanceFixture.ShouldBeAssignableTo<DeleteApexResult>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DeleteApexResult) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertyid)]
        [TestCaseGeneric(typeof(string) , Propertyproblem)]
        [TestCaseGeneric(typeof(bool) , Propertysuccess)]
        public void AUT_DeleteApexResult_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DeleteApexResult, T>(_deleteApexResultInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DeleteApexResult) => Property (id) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DeleteApexResult_Public_Class_id_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyid);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DeleteApexResult) => Property (problem) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DeleteApexResult_Public_Class_problem_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DeleteApexResult) => Property (success) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DeleteApexResult_Public_Class_success_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertysuccess);

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
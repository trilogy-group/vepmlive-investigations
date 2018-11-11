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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.WorkspaceMapping" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class WorkspaceMappingTest : AbstractBaseSetupTypedTest<WorkspaceMapping>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WorkspaceMapping) Initializer

        private const string PropertyfieldName = "fieldName";
        private const string Propertytab = "tab";
        private const string FieldfieldNameField = "fieldNameField";
        private const string FieldtabField = "tabField";
        private Type _workspaceMappingInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private WorkspaceMapping _workspaceMappingInstance;
        private WorkspaceMapping _workspaceMappingInstanceFixture;

        #region General Initializer : Class (WorkspaceMapping) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WorkspaceMapping" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _workspaceMappingInstanceType = typeof(WorkspaceMapping);
            _workspaceMappingInstanceFixture = Create(true);
            _workspaceMappingInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WorkspaceMapping)

        #region General Initializer : Class (WorkspaceMapping) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="WorkspaceMapping" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyfieldName)]
        [TestCase(Propertytab)]
        public void AUT_WorkspaceMapping_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_workspaceMappingInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (WorkspaceMapping) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="WorkspaceMapping" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldfieldNameField)]
        [TestCase(FieldtabField)]
        public void AUT_WorkspaceMapping_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_workspaceMappingInstanceFixture, 
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
        ///     Class (<see cref="WorkspaceMapping" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_WorkspaceMapping_Is_Instance_Present_Test()
        {
            // Assert
            _workspaceMappingInstanceType.ShouldNotBeNull();
            _workspaceMappingInstance.ShouldNotBeNull();
            _workspaceMappingInstanceFixture.ShouldNotBeNull();
            _workspaceMappingInstance.ShouldBeAssignableTo<WorkspaceMapping>();
            _workspaceMappingInstanceFixture.ShouldBeAssignableTo<WorkspaceMapping>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (WorkspaceMapping) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_WorkspaceMapping_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            WorkspaceMapping instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _workspaceMappingInstanceType.ShouldNotBeNull();
            _workspaceMappingInstance.ShouldNotBeNull();
            _workspaceMappingInstanceFixture.ShouldNotBeNull();
            _workspaceMappingInstance.ShouldBeAssignableTo<WorkspaceMapping>();
            _workspaceMappingInstanceFixture.ShouldBeAssignableTo<WorkspaceMapping>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (WorkspaceMapping) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyfieldName)]
        [TestCaseGeneric(typeof(string) , Propertytab)]
        public void AUT_WorkspaceMapping_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<WorkspaceMapping, T>(_workspaceMappingInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (WorkspaceMapping) => Property (fieldName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkspaceMapping_Public_Class_fieldName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyfieldName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkspaceMapping) => Property (tab) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkspaceMapping_Public_Class_tab_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertytab);

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
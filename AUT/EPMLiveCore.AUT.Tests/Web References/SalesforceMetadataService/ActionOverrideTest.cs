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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ActionOverride" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ActionOverrideTest : AbstractBaseSetupTypedTest<ActionOverride>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ActionOverride) Initializer

        private const string PropertyactionName = "actionName";
        private const string Propertycomment = "comment";
        private const string Propertycontent = "content";
        private const string PropertyskipRecordTypeSelect = "skipRecordTypeSelect";
        private const string PropertyskipRecordTypeSelectSpecified = "skipRecordTypeSelectSpecified";
        private const string Propertytype = "type";
        private const string PropertytypeSpecified = "typeSpecified";
        private const string FieldactionNameField = "actionNameField";
        private const string FieldcommentField = "commentField";
        private const string FieldcontentField = "contentField";
        private const string FieldskipRecordTypeSelectField = "skipRecordTypeSelectField";
        private const string FieldskipRecordTypeSelectFieldSpecified = "skipRecordTypeSelectFieldSpecified";
        private const string FieldtypeField = "typeField";
        private const string FieldtypeFieldSpecified = "typeFieldSpecified";
        private Type _actionOverrideInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ActionOverride _actionOverrideInstance;
        private ActionOverride _actionOverrideInstanceFixture;

        #region General Initializer : Class (ActionOverride) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ActionOverride" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _actionOverrideInstanceType = typeof(ActionOverride);
            _actionOverrideInstanceFixture = Create(true);
            _actionOverrideInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ActionOverride)

        #region General Initializer : Class (ActionOverride) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ActionOverride" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyactionName)]
        [TestCase(Propertycomment)]
        [TestCase(Propertycontent)]
        [TestCase(PropertyskipRecordTypeSelect)]
        [TestCase(PropertyskipRecordTypeSelectSpecified)]
        [TestCase(Propertytype)]
        [TestCase(PropertytypeSpecified)]
        public void AUT_ActionOverride_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_actionOverrideInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ActionOverride) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ActionOverride" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldactionNameField)]
        [TestCase(FieldcommentField)]
        [TestCase(FieldcontentField)]
        [TestCase(FieldskipRecordTypeSelectField)]
        [TestCase(FieldskipRecordTypeSelectFieldSpecified)]
        [TestCase(FieldtypeField)]
        [TestCase(FieldtypeFieldSpecified)]
        public void AUT_ActionOverride_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_actionOverrideInstanceFixture, 
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
        ///     Class (<see cref="ActionOverride" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ActionOverride_Is_Instance_Present_Test()
        {
            // Assert
            _actionOverrideInstanceType.ShouldNotBeNull();
            _actionOverrideInstance.ShouldNotBeNull();
            _actionOverrideInstanceFixture.ShouldNotBeNull();
            _actionOverrideInstance.ShouldBeAssignableTo<ActionOverride>();
            _actionOverrideInstanceFixture.ShouldBeAssignableTo<ActionOverride>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ActionOverride) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ActionOverride_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ActionOverride instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _actionOverrideInstanceType.ShouldNotBeNull();
            _actionOverrideInstance.ShouldNotBeNull();
            _actionOverrideInstanceFixture.ShouldNotBeNull();
            _actionOverrideInstance.ShouldBeAssignableTo<ActionOverride>();
            _actionOverrideInstanceFixture.ShouldBeAssignableTo<ActionOverride>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ActionOverride) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyactionName)]
        [TestCaseGeneric(typeof(string) , Propertycomment)]
        [TestCaseGeneric(typeof(string) , Propertycontent)]
        [TestCaseGeneric(typeof(bool) , PropertyskipRecordTypeSelect)]
        [TestCaseGeneric(typeof(bool) , PropertyskipRecordTypeSelectSpecified)]
        [TestCaseGeneric(typeof(ActionOverrideType) , Propertytype)]
        [TestCaseGeneric(typeof(bool) , PropertytypeSpecified)]
        public void AUT_ActionOverride_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ActionOverride, T>(_actionOverrideInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ActionOverride) => Property (actionName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ActionOverride_Public_Class_actionName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyactionName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ActionOverride) => Property (comment) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ActionOverride_Public_Class_comment_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertycomment);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ActionOverride) => Property (content) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ActionOverride_Public_Class_content_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertycontent);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ActionOverride) => Property (skipRecordTypeSelect) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ActionOverride_Public_Class_skipRecordTypeSelect_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyskipRecordTypeSelect);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ActionOverride) => Property (skipRecordTypeSelectSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ActionOverride_Public_Class_skipRecordTypeSelectSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyskipRecordTypeSelectSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ActionOverride) => Property (type) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ActionOverride_type_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertytype);
            Action currentAction = () => propertyInfo.SetValue(_actionOverrideInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ActionOverride) => Property (type) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ActionOverride_Public_Class_type_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertytype);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ActionOverride) => Property (typeSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ActionOverride_Public_Class_typeSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytypeSpecified);

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
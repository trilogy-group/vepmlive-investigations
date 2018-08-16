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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.DeployMessage" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DeployMessageTest : AbstractBaseSetupTypedTest<DeployMessage>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DeployMessage) Initializer

        private const string Propertychanged = "changed";
        private const string PropertycolumnNumber = "columnNumber";
        private const string PropertycolumnNumberSpecified = "columnNumberSpecified";
        private const string Propertycreated = "created";
        private const string Propertydeleted = "deleted";
        private const string PropertyfileName = "fileName";
        private const string PropertyfullName = "fullName";
        private const string Propertyid = "id";
        private const string PropertylineNumber = "lineNumber";
        private const string PropertylineNumberSpecified = "lineNumberSpecified";
        private const string Propertyproblem = "problem";
        private const string PropertyproblemType = "problemType";
        private const string PropertyproblemTypeSpecified = "problemTypeSpecified";
        private const string Propertysuccess = "success";
        private const string FieldchangedField = "changedField";
        private const string FieldcolumnNumberField = "columnNumberField";
        private const string FieldcolumnNumberFieldSpecified = "columnNumberFieldSpecified";
        private const string FieldcreatedField = "createdField";
        private const string FielddeletedField = "deletedField";
        private const string FieldfileNameField = "fileNameField";
        private const string FieldfullNameField = "fullNameField";
        private const string FieldidField = "idField";
        private const string FieldlineNumberField = "lineNumberField";
        private const string FieldlineNumberFieldSpecified = "lineNumberFieldSpecified";
        private const string FieldproblemField = "problemField";
        private const string FieldproblemTypeField = "problemTypeField";
        private const string FieldproblemTypeFieldSpecified = "problemTypeFieldSpecified";
        private const string FieldsuccessField = "successField";
        private Type _deployMessageInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DeployMessage _deployMessageInstance;
        private DeployMessage _deployMessageInstanceFixture;

        #region General Initializer : Class (DeployMessage) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DeployMessage" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _deployMessageInstanceType = typeof(DeployMessage);
            _deployMessageInstanceFixture = Create(true);
            _deployMessageInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DeployMessage)

        #region General Initializer : Class (DeployMessage) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DeployMessage" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertychanged)]
        [TestCase(PropertycolumnNumber)]
        [TestCase(PropertycolumnNumberSpecified)]
        [TestCase(Propertycreated)]
        [TestCase(Propertydeleted)]
        [TestCase(PropertyfileName)]
        [TestCase(PropertyfullName)]
        [TestCase(Propertyid)]
        [TestCase(PropertylineNumber)]
        [TestCase(PropertylineNumberSpecified)]
        [TestCase(Propertyproblem)]
        [TestCase(PropertyproblemType)]
        [TestCase(PropertyproblemTypeSpecified)]
        [TestCase(Propertysuccess)]
        public void AUT_DeployMessage_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_deployMessageInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DeployMessage) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DeployMessage" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldchangedField)]
        [TestCase(FieldcolumnNumberField)]
        [TestCase(FieldcolumnNumberFieldSpecified)]
        [TestCase(FieldcreatedField)]
        [TestCase(FielddeletedField)]
        [TestCase(FieldfileNameField)]
        [TestCase(FieldfullNameField)]
        [TestCase(FieldidField)]
        [TestCase(FieldlineNumberField)]
        [TestCase(FieldlineNumberFieldSpecified)]
        [TestCase(FieldproblemField)]
        [TestCase(FieldproblemTypeField)]
        [TestCase(FieldproblemTypeFieldSpecified)]
        [TestCase(FieldsuccessField)]
        public void AUT_DeployMessage_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_deployMessageInstanceFixture, 
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
        ///     Class (<see cref="DeployMessage" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DeployMessage_Is_Instance_Present_Test()
        {
            // Assert
            _deployMessageInstanceType.ShouldNotBeNull();
            _deployMessageInstance.ShouldNotBeNull();
            _deployMessageInstanceFixture.ShouldNotBeNull();
            _deployMessageInstance.ShouldBeAssignableTo<DeployMessage>();
            _deployMessageInstanceFixture.ShouldBeAssignableTo<DeployMessage>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DeployMessage) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DeployMessage_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DeployMessage instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _deployMessageInstanceType.ShouldNotBeNull();
            _deployMessageInstance.ShouldNotBeNull();
            _deployMessageInstanceFixture.ShouldNotBeNull();
            _deployMessageInstance.ShouldBeAssignableTo<DeployMessage>();
            _deployMessageInstanceFixture.ShouldBeAssignableTo<DeployMessage>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DeployMessage) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , Propertychanged)]
        [TestCaseGeneric(typeof(int) , PropertycolumnNumber)]
        [TestCaseGeneric(typeof(bool) , PropertycolumnNumberSpecified)]
        [TestCaseGeneric(typeof(bool) , Propertycreated)]
        [TestCaseGeneric(typeof(bool) , Propertydeleted)]
        [TestCaseGeneric(typeof(string) , PropertyfileName)]
        [TestCaseGeneric(typeof(string) , PropertyfullName)]
        [TestCaseGeneric(typeof(string) , Propertyid)]
        [TestCaseGeneric(typeof(int) , PropertylineNumber)]
        [TestCaseGeneric(typeof(bool) , PropertylineNumberSpecified)]
        [TestCaseGeneric(typeof(string) , Propertyproblem)]
        [TestCaseGeneric(typeof(DeployProblemType) , PropertyproblemType)]
        [TestCaseGeneric(typeof(bool) , PropertyproblemTypeSpecified)]
        [TestCaseGeneric(typeof(bool) , Propertysuccess)]
        public void AUT_DeployMessage_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DeployMessage, T>(_deployMessageInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DeployMessage) => Property (changed) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DeployMessage_Public_Class_changed_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertychanged);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DeployMessage) => Property (columnNumber) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DeployMessage_Public_Class_columnNumber_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycolumnNumber);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DeployMessage) => Property (columnNumberSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DeployMessage_Public_Class_columnNumberSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycolumnNumberSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DeployMessage) => Property (created) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DeployMessage_Public_Class_created_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertycreated);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DeployMessage) => Property (deleted) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DeployMessage_Public_Class_deleted_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertydeleted);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DeployMessage) => Property (fileName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DeployMessage_Public_Class_fileName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DeployMessage) => Property (fullName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DeployMessage_Public_Class_fullName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyfullName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DeployMessage) => Property (id) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DeployMessage_Public_Class_id_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DeployMessage) => Property (lineNumber) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DeployMessage_Public_Class_lineNumber_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylineNumber);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DeployMessage) => Property (lineNumberSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DeployMessage_Public_Class_lineNumberSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylineNumberSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DeployMessage) => Property (problem) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DeployMessage_Public_Class_problem_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DeployMessage) => Property (problemType) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DeployMessage_problemType_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyproblemType);
            Action currentAction = () => propertyInfo.SetValue(_deployMessageInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DeployMessage) => Property (problemType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DeployMessage_Public_Class_problemType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyproblemType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DeployMessage) => Property (problemTypeSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DeployMessage_Public_Class_problemTypeSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyproblemTypeSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DeployMessage) => Property (success) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DeployMessage_Public_Class_success_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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
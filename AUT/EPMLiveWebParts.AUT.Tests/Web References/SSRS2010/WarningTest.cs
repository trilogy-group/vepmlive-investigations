using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveWebParts.SSRS2010
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.SSRS2010.Warning" />)
    ///     and namespace <see cref="EPMLiveWebParts.SSRS2010"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class WarningTest : AbstractBaseSetupTypedTest<Warning>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Warning) Initializer

        private const string PropertyCode = "Code";
        private const string PropertySeverity = "Severity";
        private const string PropertyObjectName = "ObjectName";
        private const string PropertyObjectType = "ObjectType";
        private const string PropertyMessage = "Message";
        private const string FieldcodeField = "codeField";
        private const string FieldseverityField = "severityField";
        private const string FieldobjectNameField = "objectNameField";
        private const string FieldobjectTypeField = "objectTypeField";
        private const string FieldmessageField = "messageField";
        private Type _warningInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Warning _warningInstance;
        private Warning _warningInstanceFixture;

        #region General Initializer : Class (Warning) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Warning" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _warningInstanceType = typeof(Warning);
            _warningInstanceFixture = Create(true);
            _warningInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Warning)

        #region General Initializer : Class (Warning) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Warning" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyCode)]
        [TestCase(PropertySeverity)]
        [TestCase(PropertyObjectName)]
        [TestCase(PropertyObjectType)]
        [TestCase(PropertyMessage)]
        public void AUT_Warning_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_warningInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Warning) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Warning" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcodeField)]
        [TestCase(FieldseverityField)]
        [TestCase(FieldobjectNameField)]
        [TestCase(FieldobjectTypeField)]
        [TestCase(FieldmessageField)]
        public void AUT_Warning_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_warningInstanceFixture, 
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
        ///     Class (<see cref="Warning" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_Warning_Is_Instance_Present_Test()
        {
            // Assert
            _warningInstanceType.ShouldNotBeNull();
            _warningInstance.ShouldNotBeNull();
            _warningInstanceFixture.ShouldNotBeNull();
            _warningInstance.ShouldBeAssignableTo<Warning>();
            _warningInstanceFixture.ShouldBeAssignableTo<Warning>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Warning) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_Warning_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Warning instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _warningInstanceType.ShouldNotBeNull();
            _warningInstance.ShouldNotBeNull();
            _warningInstanceFixture.ShouldNotBeNull();
            _warningInstance.ShouldBeAssignableTo<Warning>();
            _warningInstanceFixture.ShouldBeAssignableTo<Warning>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Warning) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyCode)]
        [TestCaseGeneric(typeof(string) , PropertySeverity)]
        [TestCaseGeneric(typeof(string) , PropertyObjectName)]
        [TestCaseGeneric(typeof(string) , PropertyObjectType)]
        [TestCaseGeneric(typeof(string) , PropertyMessage)]
        public void AUT_Warning_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Warning, T>(_warningInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Warning) => Property (Code) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Warning_Public_Class_Code_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCode);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Warning) => Property (Message) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Warning_Public_Class_Message_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyMessage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Warning) => Property (ObjectName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Warning_Public_Class_ObjectName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyObjectName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Warning) => Property (ObjectType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Warning_Public_Class_ObjectType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyObjectType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Warning) => Property (Severity) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Warning_Public_Class_Severity_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySeverity);

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
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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ObjectRelationship" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ObjectRelationshipTest : AbstractBaseSetupTypedTest<ObjectRelationship>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ObjectRelationship) Initializer

        private const string Propertyjoin = "join";
        private const string PropertyouterJoin = "outerJoin";
        private const string Propertyrelationship = "relationship";
        private const string FieldjoinField = "joinField";
        private const string FieldouterJoinField = "outerJoinField";
        private const string FieldrelationshipField = "relationshipField";
        private Type _objectRelationshipInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ObjectRelationship _objectRelationshipInstance;
        private ObjectRelationship _objectRelationshipInstanceFixture;

        #region General Initializer : Class (ObjectRelationship) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ObjectRelationship" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _objectRelationshipInstanceType = typeof(ObjectRelationship);
            _objectRelationshipInstanceFixture = Create(true);
            _objectRelationshipInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ObjectRelationship)

        #region General Initializer : Class (ObjectRelationship) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ObjectRelationship" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyjoin)]
        [TestCase(PropertyouterJoin)]
        [TestCase(Propertyrelationship)]
        public void AUT_ObjectRelationship_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_objectRelationshipInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ObjectRelationship) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ObjectRelationship" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldjoinField)]
        [TestCase(FieldouterJoinField)]
        [TestCase(FieldrelationshipField)]
        public void AUT_ObjectRelationship_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_objectRelationshipInstanceFixture, 
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
        ///     Class (<see cref="ObjectRelationship" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ObjectRelationship_Is_Instance_Present_Test()
        {
            // Assert
            _objectRelationshipInstanceType.ShouldNotBeNull();
            _objectRelationshipInstance.ShouldNotBeNull();
            _objectRelationshipInstanceFixture.ShouldNotBeNull();
            _objectRelationshipInstance.ShouldBeAssignableTo<ObjectRelationship>();
            _objectRelationshipInstanceFixture.ShouldBeAssignableTo<ObjectRelationship>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ObjectRelationship) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ObjectRelationship_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ObjectRelationship instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _objectRelationshipInstanceType.ShouldNotBeNull();
            _objectRelationshipInstance.ShouldNotBeNull();
            _objectRelationshipInstanceFixture.ShouldNotBeNull();
            _objectRelationshipInstance.ShouldBeAssignableTo<ObjectRelationship>();
            _objectRelationshipInstanceFixture.ShouldBeAssignableTo<ObjectRelationship>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ObjectRelationship) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(ObjectRelationship) , Propertyjoin)]
        [TestCaseGeneric(typeof(bool) , PropertyouterJoin)]
        [TestCaseGeneric(typeof(string) , Propertyrelationship)]
        public void AUT_ObjectRelationship_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ObjectRelationship, T>(_objectRelationshipInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ObjectRelationship) => Property (join) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ObjectRelationship_join_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyjoin);
            Action currentAction = () => propertyInfo.SetValue(_objectRelationshipInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ObjectRelationship) => Property (join) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ObjectRelationship_Public_Class_join_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyjoin);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ObjectRelationship) => Property (outerJoin) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ObjectRelationship_Public_Class_outerJoin_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyouterJoin);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ObjectRelationship) => Property (relationship) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ObjectRelationship_Public_Class_relationship_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyrelationship);

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
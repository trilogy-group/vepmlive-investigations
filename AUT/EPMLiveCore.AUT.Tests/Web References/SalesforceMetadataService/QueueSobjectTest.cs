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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.QueueSobject" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class QueueSobjectTest : AbstractBaseSetupTypedTest<QueueSobject>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (QueueSobject) Initializer

        private const string PropertysobjectType = "sobjectType";
        private const string FieldsobjectTypeField = "sobjectTypeField";
        private Type _queueSobjectInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private QueueSobject _queueSobjectInstance;
        private QueueSobject _queueSobjectInstanceFixture;

        #region General Initializer : Class (QueueSobject) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="QueueSobject" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _queueSobjectInstanceType = typeof(QueueSobject);
            _queueSobjectInstanceFixture = Create(true);
            _queueSobjectInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (QueueSobject)

        #region General Initializer : Class (QueueSobject) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="QueueSobject" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertysobjectType)]
        public void AUT_QueueSobject_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_queueSobjectInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (QueueSobject) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="QueueSobject" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldsobjectTypeField)]
        public void AUT_QueueSobject_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_queueSobjectInstanceFixture, 
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
        ///     Class (<see cref="QueueSobject" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_QueueSobject_Is_Instance_Present_Test()
        {
            // Assert
            _queueSobjectInstanceType.ShouldNotBeNull();
            _queueSobjectInstance.ShouldNotBeNull();
            _queueSobjectInstanceFixture.ShouldNotBeNull();
            _queueSobjectInstance.ShouldBeAssignableTo<QueueSobject>();
            _queueSobjectInstanceFixture.ShouldBeAssignableTo<QueueSobject>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (QueueSobject) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_QueueSobject_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            QueueSobject instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _queueSobjectInstanceType.ShouldNotBeNull();
            _queueSobjectInstance.ShouldNotBeNull();
            _queueSobjectInstanceFixture.ShouldNotBeNull();
            _queueSobjectInstance.ShouldBeAssignableTo<QueueSobject>();
            _queueSobjectInstanceFixture.ShouldBeAssignableTo<QueueSobject>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (QueueSobject) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertysobjectType)]
        public void AUT_QueueSobject_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<QueueSobject, T>(_queueSobjectInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (QueueSobject) => Property (sobjectType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_QueueSobject_Public_Class_sobjectType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysobjectType);

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
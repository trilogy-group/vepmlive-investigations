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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.Queue" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class QueueTest : AbstractBaseSetupTypedTest<Queue>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Queue) Initializer

        private const string PropertydoesSendEmailToMembers = "doesSendEmailToMembers";
        private const string PropertydoesSendEmailToMembersSpecified = "doesSendEmailToMembersSpecified";
        private const string Propertyemail = "email";
        private const string Propertyname = "name";
        private const string PropertyqueueSobject = "queueSobject";
        private const string FielddoesSendEmailToMembersField = "doesSendEmailToMembersField";
        private const string FielddoesSendEmailToMembersFieldSpecified = "doesSendEmailToMembersFieldSpecified";
        private const string FieldemailField = "emailField";
        private const string FieldnameField = "nameField";
        private const string FieldqueueSobjectField = "queueSobjectField";
        private Type _queueInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Queue _queueInstance;
        private Queue _queueInstanceFixture;

        #region General Initializer : Class (Queue) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Queue" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _queueInstanceType = typeof(Queue);
            _queueInstanceFixture = Create(true);
            _queueInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Queue)

        #region General Initializer : Class (Queue) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Queue" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertydoesSendEmailToMembers)]
        [TestCase(PropertydoesSendEmailToMembersSpecified)]
        [TestCase(Propertyemail)]
        [TestCase(Propertyname)]
        [TestCase(PropertyqueueSobject)]
        public void AUT_Queue_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_queueInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Queue) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Queue" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielddoesSendEmailToMembersField)]
        [TestCase(FielddoesSendEmailToMembersFieldSpecified)]
        [TestCase(FieldemailField)]
        [TestCase(FieldnameField)]
        [TestCase(FieldqueueSobjectField)]
        public void AUT_Queue_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_queueInstanceFixture, 
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
        ///     Class (<see cref="Queue" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_Queue_Is_Instance_Present_Test()
        {
            // Assert
            _queueInstanceType.ShouldNotBeNull();
            _queueInstance.ShouldNotBeNull();
            _queueInstanceFixture.ShouldNotBeNull();
            _queueInstance.ShouldBeAssignableTo<Queue>();
            _queueInstanceFixture.ShouldBeAssignableTo<Queue>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Queue) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_Queue_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Queue instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _queueInstanceType.ShouldNotBeNull();
            _queueInstance.ShouldNotBeNull();
            _queueInstanceFixture.ShouldNotBeNull();
            _queueInstance.ShouldBeAssignableTo<Queue>();
            _queueInstanceFixture.ShouldBeAssignableTo<Queue>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Queue) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertydoesSendEmailToMembers)]
        [TestCaseGeneric(typeof(bool) , PropertydoesSendEmailToMembersSpecified)]
        [TestCaseGeneric(typeof(string) , Propertyemail)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        [TestCaseGeneric(typeof(QueueSobject[]) , PropertyqueueSobject)]
        public void AUT_Queue_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Queue, T>(_queueInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Queue) => Property (doesSendEmailToMembers) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Queue_Public_Class_doesSendEmailToMembers_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydoesSendEmailToMembers);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Queue) => Property (doesSendEmailToMembersSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Queue_Public_Class_doesSendEmailToMembersSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydoesSendEmailToMembersSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Queue) => Property (email) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Queue_Public_Class_email_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyemail);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Queue) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Queue_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyname);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Queue) => Property (queueSobject) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Queue_queueSobject_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyqueueSobject);
            Action currentAction = () => propertyInfo.SetValue(_queueInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Queue) => Property (queueSobject) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Queue_Public_Class_queueSobject_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyqueueSobject);

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
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

namespace PortfolioEngineCore.Services.DataServices.Core
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PortfolioEngineCore.Services.DataServices.Core.TransactionCompletedEventArgs" />)
    ///     and namespace <see cref="PortfolioEngineCore.Services.DataServices.Core"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class TransactionCompletedEventArgsTest : AbstractBaseSetupTypedTest<TransactionCompletedEventArgs>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (TransactionCompletedEventArgs) Initializer

        private const string PropertyData = "Data";
        private const string Field_data = "_data";
        private Type _transactionCompletedEventArgsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private TransactionCompletedEventArgs _transactionCompletedEventArgsInstance;
        private TransactionCompletedEventArgs _transactionCompletedEventArgsInstanceFixture;

        #region General Initializer : Class (TransactionCompletedEventArgs) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="TransactionCompletedEventArgs" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _transactionCompletedEventArgsInstanceType = typeof(TransactionCompletedEventArgs);
            _transactionCompletedEventArgsInstanceFixture = Create(true);
            _transactionCompletedEventArgsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (TransactionCompletedEventArgs)

        #region General Initializer : Class (TransactionCompletedEventArgs) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="TransactionCompletedEventArgs" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyData)]
        public void AUT_TransactionCompletedEventArgs_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_transactionCompletedEventArgsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (TransactionCompletedEventArgs) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="TransactionCompletedEventArgs" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_data)]
        public void AUT_TransactionCompletedEventArgs_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_transactionCompletedEventArgsInstanceFixture, 
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
        ///     Class (<see cref="TransactionCompletedEventArgs" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_TransactionCompletedEventArgs_Is_Instance_Present_Test()
        {
            // Assert
            _transactionCompletedEventArgsInstanceType.ShouldNotBeNull();
            _transactionCompletedEventArgsInstance.ShouldNotBeNull();
            _transactionCompletedEventArgsInstanceFixture.ShouldNotBeNull();
            _transactionCompletedEventArgsInstance.ShouldBeAssignableTo<TransactionCompletedEventArgs>();
            _transactionCompletedEventArgsInstanceFixture.ShouldBeAssignableTo<TransactionCompletedEventArgs>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (TransactionCompletedEventArgs) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_TransactionCompletedEventArgs_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var data = CreateType<object>();
            TransactionCompletedEventArgs instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new TransactionCompletedEventArgs(data);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _transactionCompletedEventArgsInstance.ShouldNotBeNull();
            _transactionCompletedEventArgsInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<TransactionCompletedEventArgs>();
        }

        #endregion

        #region General Constructor : Class (TransactionCompletedEventArgs) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_TransactionCompletedEventArgs_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var data = CreateType<object>();
            TransactionCompletedEventArgs instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new TransactionCompletedEventArgs(data);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _transactionCompletedEventArgsInstance.ShouldNotBeNull();
            _transactionCompletedEventArgsInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (TransactionCompletedEventArgs) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(object) , PropertyData)]
        public void AUT_TransactionCompletedEventArgs_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<TransactionCompletedEventArgs, T>(_transactionCompletedEventArgsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (TransactionCompletedEventArgs) => Property (Data) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TransactionCompletedEventArgs_Data_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyData);
            Action currentAction = () => propertyInfo.SetValue(_transactionCompletedEventArgsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (TransactionCompletedEventArgs) => Property (Data) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TransactionCompletedEventArgs_Public_Class_Data_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyData);

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
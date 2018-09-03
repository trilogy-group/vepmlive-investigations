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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PortfolioEngineCore.Services.DataServices.Core.TransactionCanceledEventArgs" />)
    ///     and namespace <see cref="PortfolioEngineCore.Services.DataServices.Core"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class TransactionCanceledEventArgsTest : AbstractBaseSetupTypedTest<TransactionCanceledEventArgs>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (TransactionCanceledEventArgs) Initializer

        private const string PropertyCancellationReason = "CancellationReason";
        private const string Field_cancellationReason = "_cancellationReason";
        private Type _transactionCanceledEventArgsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private TransactionCanceledEventArgs _transactionCanceledEventArgsInstance;
        private TransactionCanceledEventArgs _transactionCanceledEventArgsInstanceFixture;

        #region General Initializer : Class (TransactionCanceledEventArgs) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="TransactionCanceledEventArgs" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _transactionCanceledEventArgsInstanceType = typeof(TransactionCanceledEventArgs);
            _transactionCanceledEventArgsInstanceFixture = Create(true);
            _transactionCanceledEventArgsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (TransactionCanceledEventArgs)

        #region General Initializer : Class (TransactionCanceledEventArgs) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="TransactionCanceledEventArgs" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyCancellationReason)]
        public void AUT_TransactionCanceledEventArgs_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_transactionCanceledEventArgsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (TransactionCanceledEventArgs) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="TransactionCanceledEventArgs" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_cancellationReason)]
        public void AUT_TransactionCanceledEventArgs_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_transactionCanceledEventArgsInstanceFixture, 
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
        ///     Class (<see cref="TransactionCanceledEventArgs" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_TransactionCanceledEventArgs_Is_Instance_Present_Test()
        {
            // Assert
            _transactionCanceledEventArgsInstanceType.ShouldNotBeNull();
            _transactionCanceledEventArgsInstance.ShouldNotBeNull();
            _transactionCanceledEventArgsInstanceFixture.ShouldNotBeNull();
            _transactionCanceledEventArgsInstance.ShouldBeAssignableTo<TransactionCanceledEventArgs>();
            _transactionCanceledEventArgsInstanceFixture.ShouldBeAssignableTo<TransactionCanceledEventArgs>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (TransactionCanceledEventArgs) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_TransactionCanceledEventArgs_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var cancellationReason = CreateType<string>();
            TransactionCanceledEventArgs instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new TransactionCanceledEventArgs(cancellationReason);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _transactionCanceledEventArgsInstance.ShouldNotBeNull();
            _transactionCanceledEventArgsInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<TransactionCanceledEventArgs>();
        }

        #endregion

        #region General Constructor : Class (TransactionCanceledEventArgs) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_TransactionCanceledEventArgs_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var cancellationReason = CreateType<string>();
            TransactionCanceledEventArgs instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new TransactionCanceledEventArgs(cancellationReason);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _transactionCanceledEventArgsInstance.ShouldNotBeNull();
            _transactionCanceledEventArgsInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (TransactionCanceledEventArgs) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyCancellationReason)]
        public void AUT_TransactionCanceledEventArgs_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<TransactionCanceledEventArgs, T>(_transactionCanceledEventArgsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (TransactionCanceledEventArgs) => Property (CancellationReason) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TransactionCanceledEventArgs_Public_Class_CancellationReason_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCancellationReason);

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
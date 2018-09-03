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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PortfolioEngineCore.Services.DataServices.Core.TransactionProgressedEventArgs" />)
    ///     and namespace <see cref="PortfolioEngineCore.Services.DataServices.Core"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class TransactionProgressedEventArgsTest : AbstractBaseSetupTypedTest<TransactionProgressedEventArgs>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (TransactionProgressedEventArgs) Initializer

        private const string PropertyProgressPercentage = "ProgressPercentage";
        private const string Field_progressPercentage = "_progressPercentage";
        private Type _transactionProgressedEventArgsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private TransactionProgressedEventArgs _transactionProgressedEventArgsInstance;
        private TransactionProgressedEventArgs _transactionProgressedEventArgsInstanceFixture;

        #region General Initializer : Class (TransactionProgressedEventArgs) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="TransactionProgressedEventArgs" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _transactionProgressedEventArgsInstanceType = typeof(TransactionProgressedEventArgs);
            _transactionProgressedEventArgsInstanceFixture = Create(true);
            _transactionProgressedEventArgsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (TransactionProgressedEventArgs)

        #region General Initializer : Class (TransactionProgressedEventArgs) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="TransactionProgressedEventArgs" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyProgressPercentage)]
        public void AUT_TransactionProgressedEventArgs_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_transactionProgressedEventArgsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (TransactionProgressedEventArgs) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="TransactionProgressedEventArgs" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_progressPercentage)]
        public void AUT_TransactionProgressedEventArgs_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_transactionProgressedEventArgsInstanceFixture, 
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
        ///     Class (<see cref="TransactionProgressedEventArgs" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_TransactionProgressedEventArgs_Is_Instance_Present_Test()
        {
            // Assert
            _transactionProgressedEventArgsInstanceType.ShouldNotBeNull();
            _transactionProgressedEventArgsInstance.ShouldNotBeNull();
            _transactionProgressedEventArgsInstanceFixture.ShouldNotBeNull();
            _transactionProgressedEventArgsInstance.ShouldBeAssignableTo<TransactionProgressedEventArgs>();
            _transactionProgressedEventArgsInstanceFixture.ShouldBeAssignableTo<TransactionProgressedEventArgs>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (TransactionProgressedEventArgs) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_TransactionProgressedEventArgs_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var progressPercentage = CreateType<decimal>();
            TransactionProgressedEventArgs instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new TransactionProgressedEventArgs(progressPercentage);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _transactionProgressedEventArgsInstance.ShouldNotBeNull();
            _transactionProgressedEventArgsInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<TransactionProgressedEventArgs>();
        }

        #endregion

        #region General Constructor : Class (TransactionProgressedEventArgs) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_TransactionProgressedEventArgs_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var progressPercentage = CreateType<decimal>();
            TransactionProgressedEventArgs instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new TransactionProgressedEventArgs(progressPercentage);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _transactionProgressedEventArgsInstance.ShouldNotBeNull();
            _transactionProgressedEventArgsInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (TransactionProgressedEventArgs) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(decimal) , PropertyProgressPercentage)]
        public void AUT_TransactionProgressedEventArgs_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<TransactionProgressedEventArgs, T>(_transactionProgressedEventArgsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (TransactionProgressedEventArgs) => Property (ProgressPercentage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TransactionProgressedEventArgs_Public_Class_ProgressPercentage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyProgressPercentage);

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
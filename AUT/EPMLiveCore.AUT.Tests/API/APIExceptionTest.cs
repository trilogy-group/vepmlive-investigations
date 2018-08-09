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

namespace EPMLiveCore.API
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.APIException" />)
    ///     and namespace <see cref="EPMLiveCore.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class APIExceptionTest : AbstractBaseSetupTypedTest<APIException>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (APIException) Initializer

        private const string PropertyExceptionNumber = "ExceptionNumber";
        private Type _aPIExceptionInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private APIException _aPIExceptionInstance;
        private APIException _aPIExceptionInstanceFixture;

        #region General Initializer : Class (APIException) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="APIException" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _aPIExceptionInstanceType = typeof(APIException);
            _aPIExceptionInstanceFixture = Create(true);
            _aPIExceptionInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (APIException)

        #region General Initializer : Class (APIException) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="APIException" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyExceptionNumber)]
        public void AUT_APIException_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_aPIExceptionInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="APIException" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_APIException_Is_Instance_Present_Test()
        {
            // Assert
            _aPIExceptionInstanceType.ShouldNotBeNull();
            _aPIExceptionInstance.ShouldNotBeNull();
            _aPIExceptionInstanceFixture.ShouldNotBeNull();
            _aPIExceptionInstance.ShouldBeAssignableTo<APIException>();
            _aPIExceptionInstanceFixture.ShouldBeAssignableTo<APIException>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (APIException) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_APIException_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var exceptionNumber = CreateType<int>();
            var message = CreateType<string>();
            APIException instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new APIException(exceptionNumber, message);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _aPIExceptionInstance.ShouldNotBeNull();
            _aPIExceptionInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<APIException>();
        }

        #endregion

        #region General Constructor : Class (APIException) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_APIException_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var exceptionNumber = CreateType<int>();
            var message = CreateType<string>();
            APIException instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new APIException(exceptionNumber, message);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _aPIExceptionInstance.ShouldNotBeNull();
            _aPIExceptionInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #region General Constructor : Class (APIException) instance created

        /// <summary>
        ///     Class (<see cref="APIException" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_APIException_Is_Created_Test()
        {
            // Assert
            _aPIExceptionInstance.ShouldNotBeNull();
            _aPIExceptionInstanceFixture.ShouldNotBeNull();
        }

        #endregion

        #region General Constructor : Class (APIException) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="APIException" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_APIException_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<APIException>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (APIException) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="APIException" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_APIException_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<APIException>(Fixture);
        }

        #endregion

        #region General Constructor : Class (APIException) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="APIException" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_APIException_Constructors_Explore_Verify_Test()
        {
            // Arrange
            var exceptionNumber = CreateType<int>();
            var message = CreateType<string>();
            object[] parametersOfAPIException = { exceptionNumber, message };
            var methodAPIExceptionPrametersTypes = new Type[] { typeof(int), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_aPIExceptionInstanceType, methodAPIExceptionPrametersTypes, parametersOfAPIException);
        }

        #endregion

        #region General Constructor : Class (APIException) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="APIException" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_APIException_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodAPIExceptionPrametersTypes = new Type[] { typeof(int), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_aPIExceptionInstanceType, Fixture, methodAPIExceptionPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (APIException) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="APIException" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_APIException_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var exceptionNumber = CreateType<int>();
            var message = CreateType<string>();
            var exception = CreateType<Exception>();
            object[] parametersOfAPIException = { exceptionNumber, message, exception };
            var methodAPIExceptionPrametersTypes = new Type[] { typeof(int), typeof(string), typeof(Exception) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_aPIExceptionInstanceType, methodAPIExceptionPrametersTypes, parametersOfAPIException);
        }

        #endregion

        #region General Constructor : Class (APIException) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="APIException" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_APIException_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodAPIExceptionPrametersTypes = new Type[] { typeof(int), typeof(string), typeof(Exception) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_aPIExceptionInstanceType, Fixture, methodAPIExceptionPrametersTypes);
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (APIException) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(int) , PropertyExceptionNumber)]
        public void AUT_APIException_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<APIException, T>(_aPIExceptionInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (APIException) => Property (ExceptionNumber) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_APIException_Public_Class_ExceptionNumber_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyExceptionNumber);

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
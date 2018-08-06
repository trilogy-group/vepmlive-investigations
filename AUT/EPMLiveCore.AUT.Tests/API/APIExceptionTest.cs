using System;
using System.Diagnostics.CodeAnalysis;
using Shouldly;
using Should = Shouldly.Should;
using NUnit.Framework;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Extensions;

namespace EPMLiveCore.API
{
    /// <summary>
    ///     Automatic Unit Tests for (<see cref="APIException" />) class
    ///     using generator's artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class APIExceptionTest : AbstractGenericTest
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (APIException) Initializer

        /// <summary>
        ///    Create parameter or simple data-type using AutoFixture or Activator.
        /// </summary>
        /// <typeparam name="T">Create Given type.</typeparam>
        /// <returns>Returns a type of T</returns>
        [ExcludeFromCodeCoverage]
        private T CreateType<T>()
        {
            Exception exception;
            return CreateType<T>(out exception);
        }

        /// <summary>
        ///    Create parameter or simple data-type using AutoFixture or Activator or Constructor.
        /// </summary>
        /// <typeparam name="T">Create Given type.</typeparam>
        /// <returns>Returns a type of T</returns>
        [ExcludeFromCodeCoverage]
        private T CreateType<T>(out Exception exception)
        {
            return CreateAnalyzer.CreateTypeUsingFixtureOrConstuctor<T>(fixture: Fixture, exception: out exception);
        }

        /// <summary>
        ///    Create <see cref="APIException" /> class.
        /// </summary>
        /// <returns>Returns a newly created <see cref="APIException" />.</returns>
        [ExcludeFromCodeCoverage]
        private APIException Create(bool useFixtureAtFirst = false)
        {
            Exception createException;
            var parameters = CreateOrGetPrameters();
            return Create(createException: out createException, useFixtureAtFirst: useFixtureAtFirst, parameters: parameters);
        }

        /// <summary>
        ///    Create <see cref="APIException" /> class.
        /// </summary>
        /// <returns>Returns a newly created <see cref="APIException" />.</returns>
        [ExcludeFromCodeCoverage]
        private APIException Create(out Exception createException, object[] parameters = null, bool useFixtureAtFirst = false)
        {
            return CreateAnalyzer.Create<APIException>(fixture: Fixture, exception: out createException, useFixtureAtFirst: useFixtureAtFirst, parameters: parameters);
        }

        /// <summary>
        ///    Create Multiple of <see cref="APIException" /> classes depending on the given number.
        /// </summary>
        /// <returns>Returns a newly created <see cref="APIException" />.</returns>
        private APIException[] CreateMany(out Exception[] createExceptions, out bool isResultsAreNull, int number = 6, object[] parameters = null)
        {
            return CreateAnalyzer.CreateMany<APIException>(number: number, fixture: Fixture, exceptions: out createExceptions, isResultsAreNull: out isResultsAreNull, parameters: parameters);
        }

        /// <summary>
        ///    Create dynamic parameters for <see cref="APIException" /> class using AutoFixture.
        ///    Returns null if no parameters present.
        /// </summary>
        /// <returns>Returns a object array if parameters present or else returns null.</returns>
        [ExcludeFromCodeCoverage]
        private object[] CreateOrGetPrameters()
        {
            var exceptionNumber = CreateType<int>();
            var message = CreateType<string>();
            return new object[] {exceptionNumber, message};
        }

        #endregion

        #region Explore Class for Coverage Gain : Class (APIException)

        /// <summary>
        ///     Regular class (<see cref="APIException" />) non-public fields explore and verify for coverage gain.
        /// </summary>
        [Test]
        [Category("AUT Initializer")]
        public void AUT_RegularClass_APIException_NonPublic_Fields_Explore_Verify()
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyNonPublicFields<APIException>(Fixture);
        }

        /// <summary>
        ///     Regular class (<see cref="APIException" />) non-public properties explore and verify for coverage gain.
        /// </summary>
        [Test]
        [Category("AUT Initializer")]
        public void AUT_RegularClass_APIException_NonPublic_Properties_Explore_Verify()
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyNonPublicProperties<APIException>(Fixture);
        }

        /// <summary>
        ///     Regular class (<see cref="APIException" />) non-public methods explore and verify for coverage gain.
        /// </summary>
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        [Category("AUT Initializer")]
        public void AUT_RegularClass_APIException_NonPublic_Methods_Explore_Verify(int pageNumber = 1, int perPageMethodsToVerify = 3)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyNonPublicMethods<APIException>(Fixture, pageNumber, perPageMethodsToVerify);
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (APIException) => All Properties and Fields Test

        [Test]
        [Category("AUT GetterSetter")]
        public void AUT_APIException_Class_All_Properties_Getter_Settter_Test()
        {
            // Arrange
            Exception creationException;
            var aPIExceptionInstance  = Create(out creationException);
            var exceptionNumber = CreateType<int>();

            if (aPIExceptionInstance != null)
            {
                // Act
                aPIExceptionInstance.ExceptionNumber = exceptionNumber;

                // Assert
                aPIExceptionInstance.ExceptionNumber.ShouldNotBeNull();
            }
        }

        #endregion

        #region General Getters/Setters : Class (APIException) => Property (ExceptionNumber) Exists tests

        [Test]
        [Category("AUT GetterSetter")]
        public void AUT_APIException_Class_Invalid_Property_ExceptionNumberNotPresent_Access_Using_Reflexion_Doesnt_Throw_Exception_Test()
        {
            // Arrange
            const string propertyNameExceptionNumber = "ExceptionNumberNotPresent";
            Exception creationException;
            var aPIExceptionInstance  = Create(out creationException);

            if (aPIExceptionInstance != null)
            {
                // Assert
                Should.NotThrow(() => aPIExceptionInstance.GetType().GetProperty(propertyNameExceptionNumber));
            }
        }

        [Test]
        [Category("AUT GetterSetter")]
        public void AUT_APIException_Public_Class_ExceptionNumber_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            const string propertyNameExceptionNumber = "ExceptionNumber";
            Exception creationException;
            var aPIExceptionInstance  = Create(out creationException);

            if (aPIExceptionInstance != null)
            {
                // Arrange
                var propertyInfo  = aPIExceptionInstance.GetType().GetProperty(propertyNameExceptionNumber);

                if (propertyInfo != null && propertyInfo.IsPublicGet())
                {
                    // Act
                    var canRead = propertyInfo.CanRead;

                    // Assert
                    canRead.ShouldBeTrue();
                }
            }
        }

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (APIException) with Parameter Test

        [Test]
        [Category("AUT Constructor")]
        public void AUT_Constructor_APIException_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var exceptionNumber = CreateType<int>();
            var message = CreateType<string>();
            APIException instance = null;
            Exception creationException = null;
            Action createAction = ()=> instance = new APIException(exceptionNumber, message);

            // Act
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            if (creationException == null)
            {
                instance.ShouldNotBeNull();
                instance.ShouldBeOfType<APIException>();
            }
        }

        [Test]
        [Category("AUT Constructor")]
        public void AUT_Constructor_APIException_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var exceptionNumber = CreateType<int>();
            var message = CreateType<string>();
            APIException instance = null;
            Exception creationException = null;
            Action createAction = ()=> instance = new APIException(exceptionNumber, message);

            // Act
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            if (creationException == null)
            {
                instance.ShouldNotBeNull();
                Should.NotThrow(createAction);
            }
        }

        #endregion

        #endregion

        #endregion
    }
}
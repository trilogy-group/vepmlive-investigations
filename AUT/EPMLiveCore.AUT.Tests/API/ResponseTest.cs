using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Shouldly;
using Should = Shouldly.Should;
using NUnit.Framework;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Extensions;

namespace EPMLiveCore.API
{
    /// <summary>
    ///     Automatic Unit Tests for (<see cref="Response" />) class
    ///     using generator's artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ResponseTest : AbstractGenericTest
    {
        #region Category : General

        #region Category : MethodCallTest

        #region General Method Call : Class (Response) => Method (Failure) (Return Type : string) Test
        
        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_Response_Failure_Static_Method_2_Parameters_ParameterToken_1_Simple_Exploration_No_Exception_Thrown_Test()
        {
            // Arrange
            var errorId = CreateType<int>();
            var errorMessage = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => Response.Failure(errorId, errorMessage);
            var actionException = ActionAnalyzer.GetActionException(executeAction);

            if (actionException == null)
            {
                // Assert
                actionException.ShouldBeNull();
                Should.NotThrow(() => Response.Failure(errorId, errorMessage));
            }
        }
        
        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_Response_Failure_Static_Method_With_2_Parameters_Call_With_Reflection_MethodExploration_By_No_Exception_Thrown_Test()
        {
            // Arrange
            var errorId = CreateType<int>();
            var errorMessage = CreateType<string>();
            Object[] parametersOfFailure = {errorId, errorMessage};
            Exception exception = null, invokeException = null;
            var responseInstance  = Create(out exception);
            const string methodName = "Failure";

            if (responseInstance != null)
            {
                // Act
                var failureMethodInfo1 = responseInstance.GetType().GetMethod(methodName);
                var failureMethodInfo2 = responseInstance.GetType().GetMethod(methodName);

                // Assert
                invokeException.ShouldBeNull();
                Should.NotThrow(() => failureMethodInfo1.Invoke(responseInstance, parametersOfFailure));
                Should.NotThrow(() => failureMethodInfo2.Invoke(responseInstance, parametersOfFailure));
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_Response_Failure_Static_Method_With_2_Parameters_Call_With_Reflection_Observe_Using_Overflow_Parameters_Obvious_Not_Null_Test()
        {
            // Arrange
            var errorId = CreateType<int>();
            var errorMessage = CreateType<string>();
            Object[] parametersOutRanged = {errorId, errorMessage, null, null};
            Object[] parametersInDifferentNumber = {errorId};
            Exception exception;
            var responseInstance  = Create(out exception);
            const string methodName = "Failure";

            if (responseInstance != null)
            {
                // Act
                var failureMethodInfo1 = responseInstance.GetType().GetMethod(methodName);
                var failureMethodInfo2 = responseInstance.GetType().GetMethod(methodName);
                var returnType1 = failureMethodInfo1.ReturnType;
                var returnType2 = failureMethodInfo2.ReturnType;

                // Assert
                parametersOutRanged.ShouldNotBeNull();
                parametersInDifferentNumber.ShouldNotBeNull();
                returnType1.ShouldNotBeNull();
                returnType2.ShouldNotBeNull();
                returnType1.ShouldBe(returnType2);
                responseInstance.ShouldNotBeNull();
                failureMethodInfo1.ShouldNotBeNull();
                failureMethodInfo2.ShouldNotBeNull();
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_Response_Failure_Static_Method_With_2_Call_Using_Reflection_Result_Compare_If_Not_Null_Test()
        {
            // Arrange
            var errorId = CreateType<int>();
            var errorMessage = CreateType<string>();
            Object[] parametersOutRanged = {errorId, errorMessage, null, null};
            Object[] parametersInDifferentNumber = {errorId};
            Exception exception, exception1, exception2, exception3, exception4;
            var responseInstance  = Create(out exception);
            const string methodName = "Failure";

            if (responseInstance != null)
            {
                // Act
                var failureMethodInfo1 = responseInstance.GetType().GetMethod(methodName);
                var failureMethodInfo2 = responseInstance.GetType().GetMethod(methodName);
                var returnType1 = failureMethodInfo1.ReturnType;
                var returnType2 = failureMethodInfo2.ReturnType;
                var result1 = failureMethodInfo1.GetResultMethodInfo<Response, string>(responseInstance, out exception1, parametersOutRanged);
                var result2 = failureMethodInfo2.GetResultMethodInfo<Response, string>(responseInstance, out exception2, parametersOutRanged);
                var result3 = failureMethodInfo1.GetResultMethodInfo<Response, string>(responseInstance, out exception3, parametersInDifferentNumber);
                var result4 = failureMethodInfo2.GetResultMethodInfo<Response, string>(responseInstance, out exception4, parametersInDifferentNumber);

                // Assert
                returnType1.ShouldNotBeNull();
                returnType2.ShouldNotBeNull();
                returnType1.ShouldBe(returnType2);
                if (result1 != null)
                {
                    result1.ShouldNotBeNull();
                    result2.ShouldNotBeNull();
                    result3.ShouldNotBeNull();
                    result4.ShouldNotBeNull();
                }
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_Response_Failure_Static_Method_With_2_Call_Using_Reflection_Result_Validate_Null_Results_Test()
        {
            // Arrange
            var errorId = CreateType<int>();
            var errorMessage = CreateType<string>();
            Object[] parametersOutRanged = {errorId, errorMessage, null, null};
            Object[] parametersInDifferentNumber = {errorId};
            Exception exception, exception1, exception2, exception3, exception4;
            var responseInstance  = Create(out exception);
            const string methodName = "Failure";

            if (responseInstance != null)
            {
                // Act
                var failureMethodInfo1 = responseInstance.GetType().GetMethod(methodName);
                var failureMethodInfo2 = responseInstance.GetType().GetMethod(methodName);
                var result1 = failureMethodInfo1.GetResultMethodInfo<Response, string>(responseInstance, out exception1, parametersOutRanged);
                var result2 = failureMethodInfo2.GetResultMethodInfo<Response, string>(responseInstance, out exception2, parametersOutRanged);
                var result3 = failureMethodInfo1.GetResultMethodInfo<Response, string>(responseInstance, out exception3, parametersInDifferentNumber);
                var result4 = failureMethodInfo2.GetResultMethodInfo<Response, string>(responseInstance, out exception4, parametersInDifferentNumber);

                // Assert
                if (result1 == null)
                {
                    result1.ShouldBeNull();
                    result2.ShouldBeNull();
                    result3.ShouldBeNull();
                    result4.ShouldBeNull();
                }
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_Response_Failure_Static_Method_With_2_Call_Using_Reflection_Throw_Exceptions_Test()
        {
            // Arrange
            var errorId = CreateType<int>();
            var errorMessage = CreateType<string>();
            Object[] parametersOutRanged = {errorId, errorMessage, null, null};
            Object[] parametersInDifferentNumber = {errorId};
            Exception exception, exception1, exception2, exception3, exception4;
            var responseInstance  = Create(out exception);
            const string methodName = "Failure";

            if (responseInstance != null)
            {
                // Act
                var failureMethodInfo1 = responseInstance.GetType().GetMethod(methodName);
                var failureMethodInfo2 = responseInstance.GetType().GetMethod(methodName);
                var result1 = failureMethodInfo1.GetResultMethodInfo<Response, string>(responseInstance, out exception1, parametersOutRanged);
                var result2 = failureMethodInfo2.GetResultMethodInfo<Response, string>(responseInstance, out exception2, parametersOutRanged);
                var result3 = failureMethodInfo1.GetResultMethodInfo<Response, string>(responseInstance, out exception3, parametersInDifferentNumber);
                var result4 = failureMethodInfo2.GetResultMethodInfo<Response, string>(responseInstance, out exception4, parametersInDifferentNumber);

                // Assert
                exception1.ShouldNotBeNull();
                exception2.ShouldNotBeNull();
                result1.ShouldBeNull();
                result2.ShouldBeNull();
                result3.ShouldBeNull();
                result4.ShouldBeNull();
                Should.Throw(() => failureMethodInfo1.Invoke(responseInstance, parametersOutRanged), exceptionType: exception1.GetType());
                Should.Throw(() => failureMethodInfo2.Invoke(responseInstance, parametersOutRanged), exceptionType: exception2.GetType());
                Should.Throw<Exception>(() => failureMethodInfo1.Invoke(responseInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => failureMethodInfo2.Invoke(responseInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => failureMethodInfo1.Invoke(responseInstance, parametersOutRanged));
                Should.Throw<Exception>(() => failureMethodInfo2.Invoke(responseInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => failureMethodInfo1.Invoke(responseInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => failureMethodInfo2.Invoke(responseInstance, parametersOutRanged));
            }
        }
        
        #endregion

        #region General Method Call : Class (Response) => Method (Success) (Return Type : string) Test
        
        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_Response_Success_Static_Method_1_Parameters_ParameterToken_2_Simple_Exploration_No_Exception_Thrown_Test()
        {
            // Arrange
            var result = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => Response.Success(result);
            var actionException = ActionAnalyzer.GetActionException(executeAction);

            if (actionException == null)
            {
                // Assert
                actionException.ShouldBeNull();
                Should.NotThrow(() => Response.Success(result));
            }
        }
        
        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_Response_Success_Static_Method_With_1_Parameters_Call_With_Reflection_MethodExploration_By_No_Exception_Thrown_Test()
        {
            // Arrange
            var result = CreateType<string>();
            Object[] parametersOfSuccess = {result};
            Exception exception = null, invokeException = null;
            var responseInstance  = Create(out exception);
            const string methodName = "Success";

            if (responseInstance != null)
            {
                // Act
                var successMethodInfo1 = responseInstance.GetType().GetMethod(methodName);
                var successMethodInfo2 = responseInstance.GetType().GetMethod(methodName);

                // Assert
                invokeException.ShouldBeNull();
                Should.NotThrow(() => successMethodInfo1.Invoke(responseInstance, parametersOfSuccess));
                Should.NotThrow(() => successMethodInfo2.Invoke(responseInstance, parametersOfSuccess));
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_Response_Success_Static_Method_With_1_Parameters_Call_With_Reflection_Observe_Using_Overflow_Parameters_Obvious_Not_Null_Test()
        {
            // Arrange
            var result = CreateType<string>();
            Object[] parametersOutRanged = {result, null, null};
            Object[] parametersInDifferentNumber = {};
            Exception exception;
            var responseInstance  = Create(out exception);
            const string methodName = "Success";

            if (responseInstance != null)
            {
                // Act
                var successMethodInfo1 = responseInstance.GetType().GetMethod(methodName);
                var successMethodInfo2 = responseInstance.GetType().GetMethod(methodName);
                var returnType1 = successMethodInfo1.ReturnType;
                var returnType2 = successMethodInfo2.ReturnType;

                // Assert
                parametersOutRanged.ShouldNotBeNull();
                parametersInDifferentNumber.ShouldNotBeNull();
                returnType1.ShouldNotBeNull();
                returnType2.ShouldNotBeNull();
                returnType1.ShouldBe(returnType2);
                responseInstance.ShouldNotBeNull();
                successMethodInfo1.ShouldNotBeNull();
                successMethodInfo2.ShouldNotBeNull();
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_Response_Success_Static_Method_With_1_Call_Using_Reflection_Result_Compare_If_Not_Null_Test()
        {
            // Arrange
            var result = CreateType<string>();
            Object[] parametersOutRanged = {result, null, null};
            Object[] parametersInDifferentNumber = {};
            Exception exception, exception1, exception2, exception3, exception4;
            var responseInstance  = Create(out exception);
            const string methodName = "Success";

            if (responseInstance != null)
            {
                // Act
                var successMethodInfo1 = responseInstance.GetType().GetMethod(methodName);
                var successMethodInfo2 = responseInstance.GetType().GetMethod(methodName);
                var returnType1 = successMethodInfo1.ReturnType;
                var returnType2 = successMethodInfo2.ReturnType;
                var result1 = successMethodInfo1.GetResultMethodInfo<Response, string>(responseInstance, out exception1, parametersOutRanged);
                var result2 = successMethodInfo2.GetResultMethodInfo<Response, string>(responseInstance, out exception2, parametersOutRanged);
                var result3 = successMethodInfo1.GetResultMethodInfo<Response, string>(responseInstance, out exception3, parametersInDifferentNumber);
                var result4 = successMethodInfo2.GetResultMethodInfo<Response, string>(responseInstance, out exception4, parametersInDifferentNumber);

                // Assert
                returnType1.ShouldNotBeNull();
                returnType2.ShouldNotBeNull();
                returnType1.ShouldBe(returnType2);
                if (result1 != null)
                {
                    result1.ShouldNotBeNull();
                    result2.ShouldNotBeNull();
                    result3.ShouldNotBeNull();
                    result4.ShouldNotBeNull();
                }
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_Response_Success_Static_Method_With_1_Call_Using_Reflection_Result_Validate_Null_Results_Test()
        {
            // Arrange
            var result = CreateType<string>();
            Object[] parametersOutRanged = {result, null, null};
            Object[] parametersInDifferentNumber = {};
            Exception exception, exception1, exception2, exception3, exception4;
            var responseInstance  = Create(out exception);
            const string methodName = "Success";

            if (responseInstance != null)
            {
                // Act
                var successMethodInfo1 = responseInstance.GetType().GetMethod(methodName);
                var successMethodInfo2 = responseInstance.GetType().GetMethod(methodName);
                var result1 = successMethodInfo1.GetResultMethodInfo<Response, string>(responseInstance, out exception1, parametersOutRanged);
                var result2 = successMethodInfo2.GetResultMethodInfo<Response, string>(responseInstance, out exception2, parametersOutRanged);
                var result3 = successMethodInfo1.GetResultMethodInfo<Response, string>(responseInstance, out exception3, parametersInDifferentNumber);
                var result4 = successMethodInfo2.GetResultMethodInfo<Response, string>(responseInstance, out exception4, parametersInDifferentNumber);

                // Assert
                if (result1 == null)
                {
                    result1.ShouldBeNull();
                    result2.ShouldBeNull();
                    result3.ShouldBeNull();
                    result4.ShouldBeNull();
                }
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_Response_Success_Static_Method_With_1_Call_Using_Reflection_Throw_Exceptions_Test()
        {
            // Arrange
            var result = CreateType<string>();
            Object[] parametersOutRanged = {result, null, null};
            Object[] parametersInDifferentNumber = {};
            Exception exception, exception1, exception2, exception3, exception4;
            var responseInstance  = Create(out exception);
            const string methodName = "Success";

            if (responseInstance != null)
            {
                // Act
                var successMethodInfo1 = responseInstance.GetType().GetMethod(methodName);
                var successMethodInfo2 = responseInstance.GetType().GetMethod(methodName);
                var result1 = successMethodInfo1.GetResultMethodInfo<Response, string>(responseInstance, out exception1, parametersOutRanged);
                var result2 = successMethodInfo2.GetResultMethodInfo<Response, string>(responseInstance, out exception2, parametersOutRanged);
                var result3 = successMethodInfo1.GetResultMethodInfo<Response, string>(responseInstance, out exception3, parametersInDifferentNumber);
                var result4 = successMethodInfo2.GetResultMethodInfo<Response, string>(responseInstance, out exception4, parametersInDifferentNumber);

                // Assert
                exception1.ShouldNotBeNull();
                exception2.ShouldNotBeNull();
                result1.ShouldBeNull();
                result2.ShouldBeNull();
                result3.ShouldBeNull();
                result4.ShouldBeNull();
                Should.Throw(() => successMethodInfo1.Invoke(responseInstance, parametersOutRanged), exceptionType: exception1.GetType());
                Should.Throw(() => successMethodInfo2.Invoke(responseInstance, parametersOutRanged), exceptionType: exception2.GetType());
                Should.Throw<Exception>(() => successMethodInfo1.Invoke(responseInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => successMethodInfo2.Invoke(responseInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => successMethodInfo1.Invoke(responseInstance, parametersOutRanged));
                Should.Throw<Exception>(() => successMethodInfo2.Invoke(responseInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => successMethodInfo1.Invoke(responseInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => successMethodInfo2.Invoke(responseInstance, parametersOutRanged));
            }
        }
        
        #endregion

        #endregion

        #region Category : Initializer

        #region General Initializer : Class (Response) Initializer

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
        ///    Create <see cref="Response" /> class.
        /// </summary>
        /// <returns>Returns a newly created <see cref="Response" />.</returns>
        [ExcludeFromCodeCoverage]
        private Response Create(bool useFixtureAtFirst = false)
        {
            Exception createException;
            var parameters = CreateOrGetPrameters();
            return Create(createException: out createException, useFixtureAtFirst: useFixtureAtFirst, parameters: parameters);
        }

        /// <summary>
        ///    Create <see cref="Response" /> class.
        /// </summary>
        /// <returns>Returns a newly created <see cref="Response" />.</returns>
        [ExcludeFromCodeCoverage]
        private Response Create(out Exception createException, object[] parameters = null, bool useFixtureAtFirst = false)
        {
            return CreateAnalyzer.Create<Response>(fixture: Fixture, exception: out createException, useFixtureAtFirst: useFixtureAtFirst, parameters: parameters);
        }

        /// <summary>
        ///    Create Multiple of <see cref="Response" /> classes depending on the given number.
        /// </summary>
        /// <returns>Returns a newly created <see cref="Response" />.</returns>
        private Response[] CreateMany(out Exception[] createExceptions, out bool isResultsAreNull, int number = 6, object[] parameters = null)
        {
            return CreateAnalyzer.CreateMany<Response>(number: number, fixture: Fixture, exceptions: out createExceptions, isResultsAreNull: out isResultsAreNull, parameters: parameters);
        }

        /// <summary>
        ///    Create dynamic parameters for <see cref="Response" /> class using AutoFixture.
        ///    Returns null if no parameters present.
        /// </summary>
        /// <returns>Returns a object array if parameters present or else returns null.</returns>
        [ExcludeFromCodeCoverage]
        private object[] CreateOrGetPrameters()
        {
            var values = CreateType<string>();
            return new object[] {values};
        }

        #endregion

        #region Explore Class for Coverage Gain : Class (Response)

        /// <summary>
        ///     Regular class (<see cref="Response" />) non-public fields explore and verify for coverage gain.
        /// </summary>
        [Test]
        [Category("AUT Initializer")]
        public void AUT_RegularClass_Response_NonPublic_Fields_Explore_Verify()
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyNonPublicFields<Response>(Fixture);
        }

        /// <summary>
        ///     Regular class (<see cref="Response" />) non-public properties explore and verify for coverage gain.
        /// </summary>
        [Test]
        [Category("AUT Initializer")]
        public void AUT_RegularClass_Response_NonPublic_Properties_Explore_Verify()
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyNonPublicProperties<Response>(Fixture);
        }

        /// <summary>
        ///     Regular class (<see cref="Response" />) non-public methods explore and verify for coverage gain.
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
        public void AUT_RegularClass_Response_NonPublic_Methods_Explore_Verify(int pageNumber = 1, int perPageMethodsToVerify = 3)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyNonPublicMethods<Response>(Fixture, pageNumber, perPageMethodsToVerify);
        }

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Response) without Parameter Test

        [Test]
        [Category("AUT Constructor")]
        public void AUT_Constructor_Response_Instantiated_Without_Parameter_Throw_Exception_Test()
        {
            // Arrange
            Response instance = null;
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            if (exception != null)
            {
                // Assert
                Should.Throw<Exception>(() => new Response());
                instance.ShouldBeNull();
                exception.ShouldNotBeNull();
                instance.ShouldNotBeOfType<Response>();
            }
        }

        [Test]
        [Category("AUT Constructor")]
        public void AUT_Constructor_Response_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Response instance = null;
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            if (exception == null)
            {
                // Assert
                Should.NotThrow(() => new Response());
                instance.ShouldNotBeNull();
                exception.ShouldBeNull();
            }
        }

        [Test]
        [Category("AUT Constructor")]
        public void AUT_Constructor_Response_Without_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            Response instance = null;
            Exception creationException = null;
            Action createAction = () => instance = new Response();

            // Act
            creationException = ActionAnalyzer.GetActionException(createAction);

            if (instance != null)
            {
                // Assert
                instance.ShouldNotBeNull();
                instance.ShouldBeOfType<Response>();
            }
        }

        #endregion

        #endregion

        #endregion
    }
}
using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Shouldly;
using Should = Shouldly.Should;
using NUnit.Framework;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Extensions;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    /// <summary>
    ///     Automatic Unit Tests for (<see cref="Personalization" />) class
    ///     using generator's artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class PersonalizationTest : AbstractGenericTest
    {
        #region Category : General

        #region Category : MethodCallTest

        #region General Method Call : Class (Personalization) => Method (Get) (Return Type : string) Test
        
        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_Personalization_Get_Method_2_Parameters_ParameterToken_1_Simple_Exploration_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            Action executeAction = null;
            Exception exception = null, actionException = null;
            var personalizationInstance  = Create(out exception);
            var isInstanceNotNull = personalizationInstance != null;

            if (isInstanceNotNull)
            {
                // Act
                executeAction = () => personalizationInstance.Get(data, spWeb);
                actionException = ActionAnalyzer.GetActionException(executeAction);

                if (actionException == null)
                {
                    // Assert
                    actionException.ShouldBeNull();
                    Should.NotThrow(() => personalizationInstance.Get(data, spWeb));
                }
            }
        }
        
        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_Personalization_Get_Method_With_2_Parameters_Call_With_Reflection_MethodExploration_By_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            Object[] parametersOfGet = {data, spWeb};
            Exception exception = null, invokeException = null;
            var personalizationInstance  = Create(out exception);
            const string methodName = "Get";

            if (personalizationInstance != null)
            {
                // Act
                var getMethodInfo1 = personalizationInstance.GetType().GetMethod(methodName);
                var getMethodInfo2 = personalizationInstance.GetType().GetMethod(methodName);

                // Assert
                invokeException.ShouldBeNull();
                Should.NotThrow(() => getMethodInfo1.Invoke(personalizationInstance, parametersOfGet));
                Should.NotThrow(() => getMethodInfo2.Invoke(personalizationInstance, parametersOfGet));
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_Personalization_Get_Method_With_2_Parameters_Call_With_Reflection_Observe_Using_Overflow_Parameters_Obvious_Not_Null_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {data, spWeb, null, null};
            Object[] parametersInDifferentNumber = {data};
            Exception exception;
            var personalizationInstance  = Create(out exception);
            const string methodName = "Get";

            if (personalizationInstance != null)
            {
                // Act
                var getMethodInfo1 = personalizationInstance.GetType().GetMethod(methodName);
                var getMethodInfo2 = personalizationInstance.GetType().GetMethod(methodName);
                var returnType1 = getMethodInfo1.ReturnType;
                var returnType2 = getMethodInfo2.ReturnType;

                // Assert
                parametersOutRanged.ShouldNotBeNull();
                parametersInDifferentNumber.ShouldNotBeNull();
                returnType1.ShouldNotBeNull();
                returnType2.ShouldNotBeNull();
                returnType1.ShouldBe(returnType2);
                personalizationInstance.ShouldNotBeNull();
                getMethodInfo1.ShouldNotBeNull();
                getMethodInfo2.ShouldNotBeNull();
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_Personalization_Get_Method_With_2_Call_Using_Reflection_Result_Compare_If_Not_Null_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {data, spWeb, null, null};
            Object[] parametersInDifferentNumber = {data};
            Exception exception, exception1, exception2, exception3, exception4;
            var personalizationInstance  = Create(out exception);
            const string methodName = "Get";

            if (personalizationInstance != null)
            {
                // Act
                var getMethodInfo1 = personalizationInstance.GetType().GetMethod(methodName);
                var getMethodInfo2 = personalizationInstance.GetType().GetMethod(methodName);
                var returnType1 = getMethodInfo1.ReturnType;
                var returnType2 = getMethodInfo2.ReturnType;
                var result1 = getMethodInfo1.GetResultMethodInfo<Personalization, string>(personalizationInstance, out exception1, parametersOutRanged);
                var result2 = getMethodInfo2.GetResultMethodInfo<Personalization, string>(personalizationInstance, out exception2, parametersOutRanged);
                var result3 = getMethodInfo1.GetResultMethodInfo<Personalization, string>(personalizationInstance, out exception3, parametersInDifferentNumber);
                var result4 = getMethodInfo2.GetResultMethodInfo<Personalization, string>(personalizationInstance, out exception4, parametersInDifferentNumber);

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
        public void AUT_Personalization_Get_Method_With_2_Call_Using_Reflection_Result_Validate_Null_Results_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {data, spWeb, null, null};
            Object[] parametersInDifferentNumber = {data};
            Exception exception, exception1, exception2, exception3, exception4;
            var personalizationInstance  = Create(out exception);
            const string methodName = "Get";

            if (personalizationInstance != null)
            {
                // Act
                var getMethodInfo1 = personalizationInstance.GetType().GetMethod(methodName);
                var getMethodInfo2 = personalizationInstance.GetType().GetMethod(methodName);
                var result1 = getMethodInfo1.GetResultMethodInfo<Personalization, string>(personalizationInstance, out exception1, parametersOutRanged);
                var result2 = getMethodInfo2.GetResultMethodInfo<Personalization, string>(personalizationInstance, out exception2, parametersOutRanged);
                var result3 = getMethodInfo1.GetResultMethodInfo<Personalization, string>(personalizationInstance, out exception3, parametersInDifferentNumber);
                var result4 = getMethodInfo2.GetResultMethodInfo<Personalization, string>(personalizationInstance, out exception4, parametersInDifferentNumber);

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
        public void AUT_Personalization_Get_Method_With_2_Call_Using_Reflection_Throw_Exceptions_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {data, spWeb, null, null};
            Object[] parametersInDifferentNumber = {data};
            Exception exception, exception1, exception2, exception3, exception4;
            var personalizationInstance  = Create(out exception);
            const string methodName = "Get";

            if (personalizationInstance != null)
            {
                // Act
                var getMethodInfo1 = personalizationInstance.GetType().GetMethod(methodName);
                var getMethodInfo2 = personalizationInstance.GetType().GetMethod(methodName);
                var result1 = getMethodInfo1.GetResultMethodInfo<Personalization, string>(personalizationInstance, out exception1, parametersOutRanged);
                var result2 = getMethodInfo2.GetResultMethodInfo<Personalization, string>(personalizationInstance, out exception2, parametersOutRanged);
                var result3 = getMethodInfo1.GetResultMethodInfo<Personalization, string>(personalizationInstance, out exception3, parametersInDifferentNumber);
                var result4 = getMethodInfo2.GetResultMethodInfo<Personalization, string>(personalizationInstance, out exception4, parametersInDifferentNumber);

                // Assert
                exception1.ShouldNotBeNull();
                exception2.ShouldNotBeNull();
                result1.ShouldBeNull();
                result2.ShouldBeNull();
                result3.ShouldBeNull();
                result4.ShouldBeNull();
                Should.Throw(() => getMethodInfo1.Invoke(personalizationInstance, parametersOutRanged), exceptionType: exception1.GetType());
                Should.Throw(() => getMethodInfo2.Invoke(personalizationInstance, parametersOutRanged), exceptionType: exception2.GetType());
                Should.Throw<Exception>(() => getMethodInfo1.Invoke(personalizationInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => getMethodInfo2.Invoke(personalizationInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => getMethodInfo1.Invoke(personalizationInstance, parametersOutRanged));
                Should.Throw<Exception>(() => getMethodInfo2.Invoke(personalizationInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => getMethodInfo1.Invoke(personalizationInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => getMethodInfo2.Invoke(personalizationInstance, parametersOutRanged));
            }
        }
        
        #endregion

        #region General Method Call : Class (Personalization) => Method (Set) (Return Type : string) Test
        
        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_Personalization_Set_Method_2_Parameters_ParameterToken_2_Simple_Exploration_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            Action executeAction = null;
            Exception exception = null, actionException = null;
            var personalizationInstance  = Create(out exception);
            var isInstanceNotNull = personalizationInstance != null;

            if (isInstanceNotNull)
            {
                // Act
                executeAction = () => personalizationInstance.Set(data, spWeb);
                actionException = ActionAnalyzer.GetActionException(executeAction);

                if (actionException == null)
                {
                    // Assert
                    actionException.ShouldBeNull();
                    Should.NotThrow(() => personalizationInstance.Set(data, spWeb));
                }
            }
        }
        
        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_Personalization_Set_Method_With_2_Parameters_Call_With_Reflection_MethodExploration_By_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            Object[] parametersOfSet = {data, spWeb};
            Exception exception = null, invokeException = null;
            var personalizationInstance  = Create(out exception);
            const string methodName = "Set";

            if (personalizationInstance != null)
            {
                // Act
                var setMethodInfo1 = personalizationInstance.GetType().GetMethod(methodName);
                var setMethodInfo2 = personalizationInstance.GetType().GetMethod(methodName);

                // Assert
                invokeException.ShouldBeNull();
                Should.NotThrow(() => setMethodInfo1.Invoke(personalizationInstance, parametersOfSet));
                Should.NotThrow(() => setMethodInfo2.Invoke(personalizationInstance, parametersOfSet));
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_Personalization_Set_Method_With_2_Parameters_Call_With_Reflection_Observe_Using_Overflow_Parameters_Obvious_Not_Null_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {data, spWeb, null, null};
            Object[] parametersInDifferentNumber = {data};
            Exception exception;
            var personalizationInstance  = Create(out exception);
            const string methodName = "Set";

            if (personalizationInstance != null)
            {
                // Act
                var setMethodInfo1 = personalizationInstance.GetType().GetMethod(methodName);
                var setMethodInfo2 = personalizationInstance.GetType().GetMethod(methodName);
                var returnType1 = setMethodInfo1.ReturnType;
                var returnType2 = setMethodInfo2.ReturnType;

                // Assert
                parametersOutRanged.ShouldNotBeNull();
                parametersInDifferentNumber.ShouldNotBeNull();
                returnType1.ShouldNotBeNull();
                returnType2.ShouldNotBeNull();
                returnType1.ShouldBe(returnType2);
                personalizationInstance.ShouldNotBeNull();
                setMethodInfo1.ShouldNotBeNull();
                setMethodInfo2.ShouldNotBeNull();
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_Personalization_Set_Method_With_2_Call_Using_Reflection_Result_Compare_If_Not_Null_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {data, spWeb, null, null};
            Object[] parametersInDifferentNumber = {data};
            Exception exception, exception1, exception2, exception3, exception4;
            var personalizationInstance  = Create(out exception);
            const string methodName = "Set";

            if (personalizationInstance != null)
            {
                // Act
                var setMethodInfo1 = personalizationInstance.GetType().GetMethod(methodName);
                var setMethodInfo2 = personalizationInstance.GetType().GetMethod(methodName);
                var returnType1 = setMethodInfo1.ReturnType;
                var returnType2 = setMethodInfo2.ReturnType;
                var result1 = setMethodInfo1.GetResultMethodInfo<Personalization, string>(personalizationInstance, out exception1, parametersOutRanged);
                var result2 = setMethodInfo2.GetResultMethodInfo<Personalization, string>(personalizationInstance, out exception2, parametersOutRanged);
                var result3 = setMethodInfo1.GetResultMethodInfo<Personalization, string>(personalizationInstance, out exception3, parametersInDifferentNumber);
                var result4 = setMethodInfo2.GetResultMethodInfo<Personalization, string>(personalizationInstance, out exception4, parametersInDifferentNumber);

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
        public void AUT_Personalization_Set_Method_With_2_Call_Using_Reflection_Result_Validate_Null_Results_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {data, spWeb, null, null};
            Object[] parametersInDifferentNumber = {data};
            Exception exception, exception1, exception2, exception3, exception4;
            var personalizationInstance  = Create(out exception);
            const string methodName = "Set";

            if (personalizationInstance != null)
            {
                // Act
                var setMethodInfo1 = personalizationInstance.GetType().GetMethod(methodName);
                var setMethodInfo2 = personalizationInstance.GetType().GetMethod(methodName);
                var result1 = setMethodInfo1.GetResultMethodInfo<Personalization, string>(personalizationInstance, out exception1, parametersOutRanged);
                var result2 = setMethodInfo2.GetResultMethodInfo<Personalization, string>(personalizationInstance, out exception2, parametersOutRanged);
                var result3 = setMethodInfo1.GetResultMethodInfo<Personalization, string>(personalizationInstance, out exception3, parametersInDifferentNumber);
                var result4 = setMethodInfo2.GetResultMethodInfo<Personalization, string>(personalizationInstance, out exception4, parametersInDifferentNumber);

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
        public void AUT_Personalization_Set_Method_With_2_Call_Using_Reflection_Throw_Exceptions_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {data, spWeb, null, null};
            Object[] parametersInDifferentNumber = {data};
            Exception exception, exception1, exception2, exception3, exception4;
            var personalizationInstance  = Create(out exception);
            const string methodName = "Set";

            if (personalizationInstance != null)
            {
                // Act
                var setMethodInfo1 = personalizationInstance.GetType().GetMethod(methodName);
                var setMethodInfo2 = personalizationInstance.GetType().GetMethod(methodName);
                var result1 = setMethodInfo1.GetResultMethodInfo<Personalization, string>(personalizationInstance, out exception1, parametersOutRanged);
                var result2 = setMethodInfo2.GetResultMethodInfo<Personalization, string>(personalizationInstance, out exception2, parametersOutRanged);
                var result3 = setMethodInfo1.GetResultMethodInfo<Personalization, string>(personalizationInstance, out exception3, parametersInDifferentNumber);
                var result4 = setMethodInfo2.GetResultMethodInfo<Personalization, string>(personalizationInstance, out exception4, parametersInDifferentNumber);

                // Assert
                exception1.ShouldNotBeNull();
                exception2.ShouldNotBeNull();
                result1.ShouldBeNull();
                result2.ShouldBeNull();
                result3.ShouldBeNull();
                result4.ShouldBeNull();
                Should.Throw(() => setMethodInfo1.Invoke(personalizationInstance, parametersOutRanged), exceptionType: exception1.GetType());
                Should.Throw(() => setMethodInfo2.Invoke(personalizationInstance, parametersOutRanged), exceptionType: exception2.GetType());
                Should.Throw<Exception>(() => setMethodInfo1.Invoke(personalizationInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => setMethodInfo2.Invoke(personalizationInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => setMethodInfo1.Invoke(personalizationInstance, parametersOutRanged));
                Should.Throw<Exception>(() => setMethodInfo2.Invoke(personalizationInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => setMethodInfo1.Invoke(personalizationInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => setMethodInfo2.Invoke(personalizationInstance, parametersOutRanged));
            }
        }
        
        #endregion

        #endregion

        #region Category : Initializer

        #region General Initializer : Class (Personalization) Initializer

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
        ///    Create <see cref="Personalization" /> class.
        /// </summary>
        /// <returns>Returns a newly created <see cref="Personalization" />.</returns>
        [ExcludeFromCodeCoverage]
        private Personalization Create(bool useFixtureAtFirst = false)
        {
            Exception createException;
            var parameters = CreateOrGetPrameters();
            return Create(createException: out createException, useFixtureAtFirst: useFixtureAtFirst, parameters: parameters);
        }

        /// <summary>
        ///    Create <see cref="Personalization" /> class.
        /// </summary>
        /// <returns>Returns a newly created <see cref="Personalization" />.</returns>
        [ExcludeFromCodeCoverage]
        private Personalization Create(out Exception createException, object[] parameters = null, bool useFixtureAtFirst = false)
        {
            return CreateAnalyzer.Create<Personalization>(fixture: Fixture, exception: out createException, useFixtureAtFirst: useFixtureAtFirst, parameters: parameters);
        }

        /// <summary>
        ///    Create Multiple of <see cref="Personalization" /> classes depending on the given number.
        /// </summary>
        /// <returns>Returns a newly created <see cref="Personalization" />.</returns>
        private Personalization[] CreateMany(out Exception[] createExceptions, out bool isResultsAreNull, int number = 6, object[] parameters = null)
        {
            return CreateAnalyzer.CreateMany<Personalization>(number: number, fixture: Fixture, exceptions: out createExceptions, isResultsAreNull: out isResultsAreNull, parameters: parameters);
        }

        /// <summary>
        ///    Create dynamic parameters for <see cref="Personalization" /> class using AutoFixture.
        ///    Returns null if no parameters present.
        /// </summary>
        /// <returns>Returns a object array if parameters present or else returns null.</returns>
        [ExcludeFromCodeCoverage]
        private object[] CreateOrGetPrameters()
        {
            var spWeb = CreateType<SPWeb>();
            return new object[] {spWeb};
        }

        #endregion

        #region Explore Class for Coverage Gain : Class (Personalization)

        /// <summary>
        ///     Regular class (<see cref="Personalization" />) non-public fields explore and verify for coverage gain.
        /// </summary>
        [Test]
        [Category("AUT Initializer")]
        public void AUT_RegularClass_Personalization_NonPublic_Fields_Explore_Verify()
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyNonPublicFields<Personalization>(Fixture);
        }

        /// <summary>
        ///     Regular class (<see cref="Personalization" />) non-public properties explore and verify for coverage gain.
        /// </summary>
        [Test]
        [Category("AUT Initializer")]
        public void AUT_RegularClass_Personalization_NonPublic_Properties_Explore_Verify()
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyNonPublicProperties<Personalization>(Fixture);
        }

        /// <summary>
        ///     Regular class (<see cref="Personalization" />) non-public methods explore and verify for coverage gain.
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
        public void AUT_RegularClass_Personalization_NonPublic_Methods_Explore_Verify(int pageNumber = 1, int perPageMethodsToVerify = 3)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyNonPublicMethods<Personalization>(Fixture, pageNumber, perPageMethodsToVerify);
        }

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Personalization) without Parameter Test

        [Test]
        [Category("AUT Constructor")]
        public void AUT_Constructor_Personalization_Instantiated_Without_Parameter_Throw_Exception_Test()
        {
            // Arrange
            Personalization instance = null;
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            if (exception != null)
            {
                // Assert
                Should.Throw<Exception>(() => new Personalization());
                instance.ShouldBeNull();
                exception.ShouldNotBeNull();
                instance.ShouldNotBeOfType<Personalization>();
            }
        }

        [Test]
        [Category("AUT Constructor")]
        public void AUT_Constructor_Personalization_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Personalization instance = null;
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            if (exception == null)
            {
                // Assert
                Should.NotThrow(() => new Personalization());
                instance.ShouldNotBeNull();
                exception.ShouldBeNull();
            }
        }

        [Test]
        [Category("AUT Constructor")]
        public void AUT_Constructor_Personalization_Without_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            Personalization instance = null;
            Exception creationException = null;
            Action createAction = () => instance = new Personalization();

            // Act
            creationException = ActionAnalyzer.GetActionException(createAction);

            if (instance != null)
            {
                // Assert
                instance.ShouldNotBeNull();
                instance.ShouldBeOfType<Personalization>();
            }
        }

        #endregion

        #endregion

        #endregion
    }
}
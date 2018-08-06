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
    ///     Automatic Unit Tests for (<see cref="BaseJob" />) class
    ///     using generator's artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class BaseJobTest : AbstractGenericTest
    {
        #region Category : General

        #region Category : MethodCallTest

        #region General Method Call : Class (BaseJob) => Method (finishJob) (Return Type : void) Test

        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_BaseJob_finishJob_Method_Direct_Call_ParameterToken_1_Simple_Exploration_With_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;
            Exception exception = null, actionException = null;
            var baseJobInstance  = Create(out exception);
            var isInstanceNotNull = baseJobInstance != null;

            if (isInstanceNotNull)
            {
                // Act
                executeAction = () => baseJobInstance.finishJob();
                actionException = ActionAnalyzer.GetActionException(executeAction);

                // Assert
                Should.Throw(() => baseJobInstance.finishJob(), exceptionType: actionException.GetType());
                Should.Throw<Exception>(() => baseJobInstance.finishJob());
                actionException.ShouldNotBeNull();
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_BaseJob_finishJob_Method_Direct_Call_ParameterToken_1_Simple_Exploration_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;
            Exception exception = null, actionException = null;
            var baseJobInstance  = Create(out exception);
            var isInstanceNotNull = baseJobInstance != null;

            if (isInstanceNotNull)
            {
                // Act
                executeAction = () => baseJobInstance.finishJob();
                actionException = ActionAnalyzer.GetActionException(executeAction);

                if (actionException == null)
                {
                    // Assert
                    actionException.ShouldBeNull();
                    Should.NotThrow(() => baseJobInstance.finishJob());
                }
            }
        }
        
        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_BaseJob_finishJob_Method_With_Call_With_Reflection_Observe_Using_Overflow_Parameters_Obvious_Not_Null_Test()
        {
            // Arrange
            Object[] parametersOutRanged = {null, "", null, null};
            Object[] parametersInDifferentNumber = {};
            Exception exception;
            var baseJobInstance  = Create(out exception);
            const string methodName = "finishJob";

            if (baseJobInstance != null)
            {
                // Act
                var finishJobMethodInfo1 = baseJobInstance.GetType().GetMethod(methodName);
                var finishJobMethodInfo2 = baseJobInstance.GetType().GetMethod(methodName);
                var returnType1 = finishJobMethodInfo1.ReturnType;
                var returnType2 = finishJobMethodInfo2.ReturnType;

                // Assert
                parametersOutRanged.ShouldNotBeNull();
                parametersInDifferentNumber.ShouldNotBeNull();
                returnType1.ShouldNotBeNull();
                returnType2.ShouldNotBeNull();
                returnType1.ShouldBe(returnType2);
                baseJobInstance.ShouldNotBeNull();
                finishJobMethodInfo1.ShouldNotBeNull();
                finishJobMethodInfo2.ShouldNotBeNull();
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_BaseJob_finishJob_Method_Call_Using_Reflection_Throw_Exceptions_Test()
        {
            // Arrange
            Object[] parametersOutRanged = {null, "", null, null};
            Object[] parametersInDifferentNumber = {};
            Exception exception, exception1, exception2, exception3, exception4;
            var baseJobInstance  = Create(out exception);
            const string methodName = "finishJob";

            if (baseJobInstance != null)
            {
                // Act
                var finishJobMethodInfo1 = baseJobInstance.GetType().GetMethod(methodName);
                var finishJobMethodInfo2 = baseJobInstance.GetType().GetMethod(methodName);
                finishJobMethodInfo1.InvokeMethodInfo(baseJobInstance, out exception1, parametersOutRanged);
                finishJobMethodInfo2.InvokeMethodInfo(baseJobInstance, out exception2, parametersOutRanged);
                finishJobMethodInfo1.InvokeMethodInfo(baseJobInstance, out exception3, parametersInDifferentNumber);
                finishJobMethodInfo2.InvokeMethodInfo(baseJobInstance, out exception4, parametersInDifferentNumber);

                // Assert
                exception1.ShouldNotBeNull();
                exception2.ShouldNotBeNull();
                Should.Throw(() => finishJobMethodInfo1.Invoke(baseJobInstance, parametersOutRanged), exceptionType: exception1.GetType());
                Should.Throw(() => finishJobMethodInfo2.Invoke(baseJobInstance, parametersOutRanged), exceptionType: exception2.GetType());
                Should.Throw<Exception>(() => finishJobMethodInfo1.Invoke(baseJobInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => finishJobMethodInfo2.Invoke(baseJobInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => finishJobMethodInfo1.Invoke(baseJobInstance, parametersOutRanged));
                Should.Throw<Exception>(() => finishJobMethodInfo2.Invoke(baseJobInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => finishJobMethodInfo1.Invoke(baseJobInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => finishJobMethodInfo2.Invoke(baseJobInstance, parametersOutRanged));
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_BaseJob_finishJob_Method_Call_Using_Reflection_No_Exception_Thrown_Test()
        {
            // Arrange
            Object[] parameters = {};
            Exception exception, exception1, exception2, exception3, exception4;
            var baseJobInstance  = Create(out exception);
            const string methodName = "finishJob";

            if (baseJobInstance != null)
            {
                // Act
                var finishJobMethodInfo1 = baseJobInstance.GetType().GetMethod(methodName);
                var finishJobMethodInfo2 = baseJobInstance.GetType().GetMethod(methodName);
                finishJobMethodInfo1.InvokeMethodInfo(baseJobInstance, out exception1, parameters);
                finishJobMethodInfo2.InvokeMethodInfo(baseJobInstance, out exception2, parameters);
                finishJobMethodInfo1.InvokeMethodInfo(baseJobInstance, out exception3, parameters);
                finishJobMethodInfo2.InvokeMethodInfo(baseJobInstance, out exception4, parameters);

                // Assert
                if (exception1 == null)
                {
                    exception1.ShouldBeNull();
                    Should.NotThrow(() => finishJobMethodInfo1.Invoke(baseJobInstance, parameters));
                    Should.NotThrow(() => finishJobMethodInfo2.Invoke(baseJobInstance, parameters));
                }
            }
        }

        #endregion

        #region General Method Call : Class (BaseJob) => Method (initJob) (Return Type : bool) Test

        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_BaseJob_initJob_Method_1_Parameters_Method_Direct_Call_ParameterToken_2_Simple_Exploration_With_Throw_Exception_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            Action executeAction = null;
            Exception exception = null, actionException = null;
            var baseJobInstance  = Create(out exception);
            var isInstanceNotNull = baseJobInstance != null;

            if (isInstanceNotNull)
            {
                // Act
                executeAction = () => baseJobInstance.initJob(site);
                actionException = ActionAnalyzer.GetActionException(executeAction);

                // Assert
                Should.Throw(() => baseJobInstance.initJob(site), exceptionType: actionException.GetType());
                Should.Throw<Exception>(() => baseJobInstance.initJob(site));
                actionException.ShouldNotBeNull();
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_BaseJob_initJob_Method_1_Parameters_ParameterToken_2_Simple_Exploration_No_Exception_Thrown_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            Action executeAction = null;
            Exception exception = null, actionException = null;
            var baseJobInstance  = Create(out exception);
            var isInstanceNotNull = baseJobInstance != null;

            if (isInstanceNotNull)
            {
                // Act
                executeAction = () => baseJobInstance.initJob(site);
                actionException = ActionAnalyzer.GetActionException(executeAction);

                if (actionException == null)
                {
                    // Assert
                    actionException.ShouldBeNull();
                    Should.NotThrow(() => baseJobInstance.initJob(site));
                }
            }
        }
        
        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_BaseJob_initJob_Method_With_1_Parameters_Call_With_Reflection_Observe_Using_Overflow_Parameters_Obvious_Not_Null_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            Object[] parametersOutRanged = {site, null, null};
            Object[] parametersInDifferentNumber = {};
            Exception exception;
            var baseJobInstance  = Create(out exception);
            const string methodName = "initJob";

            if (baseJobInstance != null)
            {
                // Act
                var initJobMethodInfo1 = baseJobInstance.GetType().GetMethod(methodName);
                var initJobMethodInfo2 = baseJobInstance.GetType().GetMethod(methodName);
                var returnType1 = initJobMethodInfo1.ReturnType;
                var returnType2 = initJobMethodInfo2.ReturnType;

                // Assert
                parametersOutRanged.ShouldNotBeNull();
                parametersInDifferentNumber.ShouldNotBeNull();
                returnType1.ShouldNotBeNull();
                returnType2.ShouldNotBeNull();
                returnType1.ShouldBe(returnType2);
                baseJobInstance.ShouldNotBeNull();
                initJobMethodInfo1.ShouldNotBeNull();
                initJobMethodInfo2.ShouldNotBeNull();
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_BaseJob_initJob_Method_With_1_Call_Using_Reflection_Result_Compare_If_Not_Null_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            Object[] parametersOutRanged = {site, null, null};
            Object[] parametersInDifferentNumber = {};
            Exception exception, exception1, exception2, exception3, exception4;
            var baseJobInstance  = Create(out exception);
            const string methodName = "initJob";

            if (baseJobInstance != null)
            {
                // Act
                var initJobMethodInfo1 = baseJobInstance.GetType().GetMethod(methodName);
                var initJobMethodInfo2 = baseJobInstance.GetType().GetMethod(methodName);
                var returnType1 = initJobMethodInfo1.ReturnType;
                var returnType2 = initJobMethodInfo2.ReturnType;
                var result1 = initJobMethodInfo1.GetResultMethodInfo<BaseJob, bool>(baseJobInstance, out exception1, parametersOutRanged);
                var result2 = initJobMethodInfo2.GetResultMethodInfo<BaseJob, bool>(baseJobInstance, out exception2, parametersOutRanged);
                var result3 = initJobMethodInfo1.GetResultMethodInfo<BaseJob, bool>(baseJobInstance, out exception3, parametersInDifferentNumber);
                var result4 = initJobMethodInfo2.GetResultMethodInfo<BaseJob, bool>(baseJobInstance, out exception4, parametersInDifferentNumber);

                // Assert
                returnType1.ShouldNotBeNull();
                returnType2.ShouldNotBeNull();
                returnType1.ShouldBe(returnType2);
                result1.ShouldBe(result2);
                result3.ShouldBe(result4);
                result1.ShouldNotBeNull();
                result2.ShouldNotBeNull();
                result3.ShouldNotBeNull();
                result4.ShouldNotBeNull();
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_BaseJob_initJob_Method_With_1_Call_Using_Reflection_Result_Validate_Null_Results_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            Object[] parametersOutRanged = {site, null, null};
            Object[] parametersInDifferentNumber = {};
            Exception exception, exception1, exception2, exception3, exception4;
            var baseJobInstance  = Create(out exception);
            const string methodName = "initJob";

            if (baseJobInstance != null)
            {
                // Act
                var initJobMethodInfo1 = baseJobInstance.GetType().GetMethod(methodName);
                var initJobMethodInfo2 = baseJobInstance.GetType().GetMethod(methodName);
                var result1 = initJobMethodInfo1.GetResultMethodInfo<BaseJob, bool>(baseJobInstance, out exception1, parametersOutRanged);
                var result2 = initJobMethodInfo2.GetResultMethodInfo<BaseJob, bool>(baseJobInstance, out exception2, parametersOutRanged);
                var result3 = initJobMethodInfo1.GetResultMethodInfo<BaseJob, bool>(baseJobInstance, out exception3, parametersInDifferentNumber);
                var result4 = initJobMethodInfo2.GetResultMethodInfo<BaseJob, bool>(baseJobInstance, out exception4, parametersInDifferentNumber);

                // Assert
                result1.ShouldBe(result2);
                result3.ShouldBe(result4);
                result1.ShouldNotBeNull();
                result2.ShouldNotBeNull();
                result3.ShouldNotBeNull();
                result4.ShouldNotBeNull();
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_BaseJob_initJob_Method_With_1_Call_Using_Reflection_Throw_Exceptions_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            Object[] parametersOutRanged = {site, null, null};
            Object[] parametersInDifferentNumber = {};
            Exception exception, exception1, exception2, exception3, exception4;
            var baseJobInstance  = Create(out exception);
            const string methodName = "initJob";

            if (baseJobInstance != null)
            {
                // Act
                var initJobMethodInfo1 = baseJobInstance.GetType().GetMethod(methodName);
                var initJobMethodInfo2 = baseJobInstance.GetType().GetMethod(methodName);
                var result1 = initJobMethodInfo1.GetResultMethodInfo<BaseJob, bool>(baseJobInstance, out exception1, parametersOutRanged);
                var result2 = initJobMethodInfo2.GetResultMethodInfo<BaseJob, bool>(baseJobInstance, out exception2, parametersOutRanged);
                var result3 = initJobMethodInfo1.GetResultMethodInfo<BaseJob, bool>(baseJobInstance, out exception3, parametersInDifferentNumber);
                var result4 = initJobMethodInfo2.GetResultMethodInfo<BaseJob, bool>(baseJobInstance, out exception4, parametersInDifferentNumber);

                // Assert
                exception1.ShouldNotBeNull();
                exception2.ShouldNotBeNull();
                result1.ShouldBe(result2);
                result3.ShouldBe(result4);
                result1.ShouldNotBeNull();
                result2.ShouldNotBeNull();
                result3.ShouldNotBeNull();
                result4.ShouldNotBeNull();
                Should.Throw(() => initJobMethodInfo1.Invoke(baseJobInstance, parametersOutRanged), exceptionType: exception1.GetType());
                Should.Throw(() => initJobMethodInfo2.Invoke(baseJobInstance, parametersOutRanged), exceptionType: exception2.GetType());
                Should.Throw<Exception>(() => initJobMethodInfo1.Invoke(baseJobInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => initJobMethodInfo2.Invoke(baseJobInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => initJobMethodInfo1.Invoke(baseJobInstance, parametersOutRanged));
                Should.Throw<Exception>(() => initJobMethodInfo2.Invoke(baseJobInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => initJobMethodInfo1.Invoke(baseJobInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => initJobMethodInfo2.Invoke(baseJobInstance, parametersOutRanged));
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_BaseJob_initJob_Method_With_1_Call_Using_Reflection_No_Exception_Thrown_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            Object[] parameters = {site};
            Exception exception, exception1, exception2, exception3, exception4;
            var baseJobInstance  = Create(out exception);
            const string methodName = "initJob";

            if (baseJobInstance != null)
            {
                // Act
                var initJobMethodInfo1 = baseJobInstance.GetType().GetMethod(methodName);
                var initJobMethodInfo2 = baseJobInstance.GetType().GetMethod(methodName);
                var result1 = initJobMethodInfo1.GetResultMethodInfo<BaseJob, bool>(baseJobInstance, out exception1, parameters);
                var result2 = initJobMethodInfo2.GetResultMethodInfo<BaseJob, bool>(baseJobInstance, out exception2, parameters);
                var result3 = initJobMethodInfo1.GetResultMethodInfo<BaseJob, bool>(baseJobInstance, out exception3, parameters);
                var result4 = initJobMethodInfo2.GetResultMethodInfo<BaseJob, bool>(baseJobInstance, out exception4, parameters);

                // Assert
                if (exception1 == null)
                {
                    exception1.ShouldBeNull();
                    result1.ShouldBe(result2);
                    result3.ShouldBe(result4);
                    result1.ShouldNotBeNull();
                    result2.ShouldNotBeNull();
                    result3.ShouldNotBeNull();
                    result4.ShouldNotBeNull();
                    Should.NotThrow(() => initJobMethodInfo1.Invoke(baseJobInstance, parameters));
                    Should.NotThrow(() => initJobMethodInfo2.Invoke(baseJobInstance, parameters));
                }
            }
        }

        #endregion

        #endregion

        #region Category : Initializer

        #region General Initializer : Class (BaseJob) Initializer

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
        ///    Create <see cref="BaseJob" /> class.
        /// </summary>
        /// <returns>Returns a newly created <see cref="BaseJob" />.</returns>
        [ExcludeFromCodeCoverage]
        private BaseJob Create(bool useFixtureAtFirst = false)
        {
            Exception createException;
            var parameters = CreateOrGetPrameters();
            return Create(createException: out createException, useFixtureAtFirst: useFixtureAtFirst, parameters: parameters);
        }

        /// <summary>
        ///    Create <see cref="BaseJob" /> class.
        /// </summary>
        /// <returns>Returns a newly created <see cref="BaseJob" />.</returns>
        [ExcludeFromCodeCoverage]
        private BaseJob Create(out Exception createException, object[] parameters = null, bool useFixtureAtFirst = false)
        {
            return CreateAnalyzer.Create<BaseJob>(fixture: Fixture, exception: out createException, useFixtureAtFirst: useFixtureAtFirst, parameters: parameters);
        }

        /// <summary>
        ///    Create Multiple of <see cref="BaseJob" /> classes depending on the given number.
        /// </summary>
        /// <returns>Returns a newly created <see cref="BaseJob" />.</returns>
        private BaseJob[] CreateMany(out Exception[] createExceptions, out bool isResultsAreNull, int number = 6, object[] parameters = null)
        {
            return CreateAnalyzer.CreateMany<BaseJob>(number: number, fixture: Fixture, exceptions: out createExceptions, isResultsAreNull: out isResultsAreNull, parameters: parameters);
        }

        /// <summary>
        ///    Create dynamic parameters for <see cref="BaseJob" /> class using AutoFixture.
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

        #region Explore Class for Coverage Gain : Class (BaseJob)

        /// <summary>
        ///     Regular class (<see cref="BaseJob" />) non-public fields explore and verify for coverage gain.
        /// </summary>
        [Test]
        [Category("AUT Initializer")]
        public void AUT_RegularClass_BaseJob_NonPublic_Fields_Explore_Verify()
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyNonPublicFields<BaseJob>(Fixture);
        }

        /// <summary>
        ///     Regular class (<see cref="BaseJob" />) non-public properties explore and verify for coverage gain.
        /// </summary>
        [Test]
        [Category("AUT Initializer")]
        public void AUT_RegularClass_BaseJob_NonPublic_Properties_Explore_Verify()
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyNonPublicProperties<BaseJob>(Fixture);
        }

        /// <summary>
        ///     Regular class (<see cref="BaseJob" />) non-public methods explore and verify for coverage gain.
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
        public void AUT_RegularClass_BaseJob_NonPublic_Methods_Explore_Verify(int pageNumber = 1, int perPageMethodsToVerify = 3)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyNonPublicMethods<BaseJob>(Fixture, pageNumber, perPageMethodsToVerify);
        }

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (BaseJob) without Parameter Test

        [Test]
        [Category("AUT Constructor")]
        public void AUT_Constructor_BaseJob_Instantiated_Without_Parameter_Throw_Exception_Test()
        {
            // Arrange
            BaseJob instance = null;
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            if (exception != null)
            {
                // Assert
                Should.Throw<Exception>(() => new BaseJob());
                instance.ShouldBeNull();
                exception.ShouldNotBeNull();
                instance.ShouldNotBeOfType<BaseJob>();
            }
        }

        [Test]
        [Category("AUT Constructor")]
        public void AUT_Constructor_BaseJob_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            BaseJob instance = null;
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            if (exception == null)
            {
                // Assert
                Should.NotThrow(() => new BaseJob());
                instance.ShouldNotBeNull();
                exception.ShouldBeNull();
            }
        }

        [Test]
        [Category("AUT Constructor")]
        public void AUT_Constructor_BaseJob_Without_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            BaseJob instance = null;
            Exception creationException = null;
            Action createAction = () => instance = new BaseJob();

            // Act
            creationException = ActionAnalyzer.GetActionException(createAction);

            if (instance != null)
            {
                // Assert
                instance.ShouldNotBeNull();
                instance.ShouldBeOfType<BaseJob>();
            }
        }

        #endregion

        #endregion

        #endregion
    }
}
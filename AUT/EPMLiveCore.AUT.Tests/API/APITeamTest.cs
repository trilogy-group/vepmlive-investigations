using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Shouldly;
using Should = Shouldly.Should;
using NUnit.Framework;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Extensions;
using Microsoft.SharePoint;
using System.Xml;

namespace EPMLiveCore.API
{
    /// <summary>
    ///     Automatic Unit Tests for (<see cref="APITeam" />) class
    ///     using generator's artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class APITeamTest : AbstractGenericTest
    {
        #region Category : General

        #region Category : MethodCallTest

        #region General Method Call : Class (APITeam) => Method (SaveTeam) (Return Type : string) Test

        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_SaveTeam_Static_Method_2_Parameters_Method_Direct_Call_ParameterToken_1_Simple_Exploration_With_Throw_Exception_Test()
        {
            // Arrange
            var sdoc = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => APITeam.SaveTeam(sdoc, oWeb);
            var actionException = ActionAnalyzer.GetActionException(executeAction);

            // Assert
            Should.Throw(() => APITeam.SaveTeam(sdoc, oWeb), exceptionType: actionException.GetType());
            Should.Throw<Exception>(() => APITeam.SaveTeam(sdoc, oWeb));
            actionException.ShouldNotBeNull();
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_APITeam_SaveTeam_Static_Method_2_Parameters_ParameterToken_1_Simple_Exploration_No_Exception_Thrown_Test()
        {
            // Arrange
            var sdoc = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => APITeam.SaveTeam(sdoc, oWeb);
            var actionException = ActionAnalyzer.GetActionException(executeAction);

            if (actionException == null)
            {
                // Assert
                actionException.ShouldBeNull();
                Should.NotThrow(() => APITeam.SaveTeam(sdoc, oWeb));
            }
        }
        
        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_SaveTeam_Static_Method_With_2_Parameters_Call_With_Reflection_Observe_Using_Overflow_Parameters_Obvious_Not_Null_Test()
        {
            // Arrange
            var sdoc = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {sdoc, oWeb, null, null};
            Object[] parametersInDifferentNumber = {sdoc};
            Exception exception;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "SaveTeam";

            if (aPITeamInstance != null)
            {
                // Act
                var saveTeamMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var saveTeamMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var returnType1 = saveTeamMethodInfo1.ReturnType;
                var returnType2 = saveTeamMethodInfo2.ReturnType;

                // Assert
                parametersOutRanged.ShouldNotBeNull();
                parametersInDifferentNumber.ShouldNotBeNull();
                returnType1.ShouldNotBeNull();
                returnType2.ShouldNotBeNull();
                returnType1.ShouldBe(returnType2);
                aPITeamInstance.ShouldNotBeNull();
                saveTeamMethodInfo1.ShouldNotBeNull();
                saveTeamMethodInfo2.ShouldNotBeNull();
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_APITeam_SaveTeam_Static_Method_With_2_Call_Using_Reflection_Result_Compare_If_Not_Null_Test()
        {
            // Arrange
            var sdoc = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {sdoc, oWeb, null, null};
            Object[] parametersInDifferentNumber = {sdoc};
            Exception exception, exception1, exception2, exception3, exception4;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "SaveTeam";

            if (aPITeamInstance != null)
            {
                // Act
                var saveTeamMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var saveTeamMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var returnType1 = saveTeamMethodInfo1.ReturnType;
                var returnType2 = saveTeamMethodInfo2.ReturnType;
                var result1 = saveTeamMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception1, parametersOutRanged);
                var result2 = saveTeamMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception2, parametersOutRanged);
                var result3 = saveTeamMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception3, parametersInDifferentNumber);
                var result4 = saveTeamMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception4, parametersInDifferentNumber);

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
        public void AUT_APITeam_SaveTeam_Static_Method_With_2_Call_Using_Reflection_Result_Validate_Null_Results_Test()
        {
            // Arrange
            var sdoc = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {sdoc, oWeb, null, null};
            Object[] parametersInDifferentNumber = {sdoc};
            Exception exception, exception1, exception2, exception3, exception4;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "SaveTeam";

            if (aPITeamInstance != null)
            {
                // Act
                var saveTeamMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var saveTeamMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var result1 = saveTeamMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception1, parametersOutRanged);
                var result2 = saveTeamMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception2, parametersOutRanged);
                var result3 = saveTeamMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception3, parametersInDifferentNumber);
                var result4 = saveTeamMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception4, parametersInDifferentNumber);

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
        public void AUT_APITeam_SaveTeam_Static_Method_With_2_Call_Using_Reflection_Throw_Exceptions_Test()
        {
            // Arrange
            var sdoc = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {sdoc, oWeb, null, null};
            Object[] parametersInDifferentNumber = {sdoc};
            Exception exception, exception1, exception2, exception3, exception4;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "SaveTeam";

            if (aPITeamInstance != null)
            {
                // Act
                var saveTeamMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var saveTeamMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var result1 = saveTeamMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception1, parametersOutRanged);
                var result2 = saveTeamMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception2, parametersOutRanged);
                var result3 = saveTeamMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception3, parametersInDifferentNumber);
                var result4 = saveTeamMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception4, parametersInDifferentNumber);

                // Assert
                exception1.ShouldNotBeNull();
                exception2.ShouldNotBeNull();
                result1.ShouldBeNull();
                result2.ShouldBeNull();
                result3.ShouldBeNull();
                result4.ShouldBeNull();
                Should.Throw(() => saveTeamMethodInfo1.Invoke(aPITeamInstance, parametersOutRanged), exceptionType: exception1.GetType());
                Should.Throw(() => saveTeamMethodInfo2.Invoke(aPITeamInstance, parametersOutRanged), exceptionType: exception2.GetType());
                Should.Throw<Exception>(() => saveTeamMethodInfo1.Invoke(aPITeamInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => saveTeamMethodInfo2.Invoke(aPITeamInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => saveTeamMethodInfo1.Invoke(aPITeamInstance, parametersOutRanged));
                Should.Throw<Exception>(() => saveTeamMethodInfo2.Invoke(aPITeamInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => saveTeamMethodInfo1.Invoke(aPITeamInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => saveTeamMethodInfo2.Invoke(aPITeamInstance, parametersOutRanged));
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_APITeam_SaveTeam_Static_Method_With_2_Call_Using_Reflection_No_Exception_Thrown_Test()
        {
            // Arrange
            var sdoc = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Object[] parameters = {sdoc, oWeb};
            Exception exception, exception1, exception2, exception3, exception4;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "SaveTeam";

            if (aPITeamInstance != null)
            {
                // Act
                var saveTeamMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var saveTeamMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var result1 = saveTeamMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception1, parameters);
                var result2 = saveTeamMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception2, parameters);
                var result3 = saveTeamMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception3, parameters);
                var result4 = saveTeamMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception4, parameters);

                // Assert
                if (exception1 == null)
                {
                    exception1.ShouldBeNull();
                    result1.ShouldBeNull();
                    result2.ShouldBeNull();
                    result3.ShouldBeNull();
                    result4.ShouldBeNull();
                    Should.NotThrow(() => saveTeamMethodInfo1.Invoke(aPITeamInstance, parameters));
                    Should.NotThrow(() => saveTeamMethodInfo2.Invoke(aPITeamInstance, parameters));
                }
            }
        }

        #endregion

        #region General Method Call : Class (APITeam) => Method (GetTeam) (Return Type : string) Test

        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeam_Static_Method_2_Parameters_Method_Direct_Call_ParameterToken_2_Simple_Exploration_With_Throw_Exception_Test()
        {
            // Arrange
            var queryDoc = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => APITeam.GetTeam(queryDoc, oWeb);
            var actionException = ActionAnalyzer.GetActionException(executeAction);

            // Assert
            Should.Throw(() => APITeam.GetTeam(queryDoc, oWeb), exceptionType: actionException.GetType());
            Should.Throw<Exception>(() => APITeam.GetTeam(queryDoc, oWeb));
            actionException.ShouldNotBeNull();
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_APITeam_GetTeam_Static_Method_2_Parameters_ParameterToken_2_Simple_Exploration_No_Exception_Thrown_Test()
        {
            // Arrange
            var queryDoc = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => APITeam.GetTeam(queryDoc, oWeb);
            var actionException = ActionAnalyzer.GetActionException(executeAction);

            if (actionException == null)
            {
                // Assert
                actionException.ShouldBeNull();
                Should.NotThrow(() => APITeam.GetTeam(queryDoc, oWeb));
            }
        }
        
        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeam_Static_Method_With_2_Parameters_Call_With_Reflection_Observe_Using_Overflow_Parameters_Obvious_Not_Null_Test()
        {
            // Arrange
            var queryDoc = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {queryDoc, oWeb, null, null};
            Object[] parametersInDifferentNumber = {queryDoc};
            Exception exception;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetTeam";

            if (aPITeamInstance != null)
            {
                // Act
                var getTeamMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getTeamMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var returnType1 = getTeamMethodInfo1.ReturnType;
                var returnType2 = getTeamMethodInfo2.ReturnType;

                // Assert
                parametersOutRanged.ShouldNotBeNull();
                parametersInDifferentNumber.ShouldNotBeNull();
                returnType1.ShouldNotBeNull();
                returnType2.ShouldNotBeNull();
                returnType1.ShouldBe(returnType2);
                aPITeamInstance.ShouldNotBeNull();
                getTeamMethodInfo1.ShouldNotBeNull();
                getTeamMethodInfo2.ShouldNotBeNull();
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_APITeam_GetTeam_Static_Method_With_2_Call_Using_Reflection_Result_Compare_If_Not_Null_Test()
        {
            // Arrange
            var queryDoc = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {queryDoc, oWeb, null, null};
            Object[] parametersInDifferentNumber = {queryDoc};
            Exception exception, exception1, exception2, exception3, exception4;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetTeam";

            if (aPITeamInstance != null)
            {
                // Act
                var getTeamMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getTeamMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var returnType1 = getTeamMethodInfo1.ReturnType;
                var returnType2 = getTeamMethodInfo2.ReturnType;
                var result1 = getTeamMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception1, parametersOutRanged);
                var result2 = getTeamMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception2, parametersOutRanged);
                var result3 = getTeamMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception3, parametersInDifferentNumber);
                var result4 = getTeamMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception4, parametersInDifferentNumber);

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
        public void AUT_APITeam_GetTeam_Static_Method_With_2_Call_Using_Reflection_Result_Validate_Null_Results_Test()
        {
            // Arrange
            var queryDoc = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {queryDoc, oWeb, null, null};
            Object[] parametersInDifferentNumber = {queryDoc};
            Exception exception, exception1, exception2, exception3, exception4;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetTeam";

            if (aPITeamInstance != null)
            {
                // Act
                var getTeamMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getTeamMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var result1 = getTeamMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception1, parametersOutRanged);
                var result2 = getTeamMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception2, parametersOutRanged);
                var result3 = getTeamMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception3, parametersInDifferentNumber);
                var result4 = getTeamMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception4, parametersInDifferentNumber);

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
        public void AUT_APITeam_GetTeam_Static_Method_With_2_Call_Using_Reflection_Throw_Exceptions_Test()
        {
            // Arrange
            var queryDoc = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {queryDoc, oWeb, null, null};
            Object[] parametersInDifferentNumber = {queryDoc};
            Exception exception, exception1, exception2, exception3, exception4;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetTeam";

            if (aPITeamInstance != null)
            {
                // Act
                var getTeamMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getTeamMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var result1 = getTeamMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception1, parametersOutRanged);
                var result2 = getTeamMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception2, parametersOutRanged);
                var result3 = getTeamMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception3, parametersInDifferentNumber);
                var result4 = getTeamMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception4, parametersInDifferentNumber);

                // Assert
                exception1.ShouldNotBeNull();
                exception2.ShouldNotBeNull();
                result1.ShouldBeNull();
                result2.ShouldBeNull();
                result3.ShouldBeNull();
                result4.ShouldBeNull();
                Should.Throw(() => getTeamMethodInfo1.Invoke(aPITeamInstance, parametersOutRanged), exceptionType: exception1.GetType());
                Should.Throw(() => getTeamMethodInfo2.Invoke(aPITeamInstance, parametersOutRanged), exceptionType: exception2.GetType());
                Should.Throw<Exception>(() => getTeamMethodInfo1.Invoke(aPITeamInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => getTeamMethodInfo2.Invoke(aPITeamInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => getTeamMethodInfo1.Invoke(aPITeamInstance, parametersOutRanged));
                Should.Throw<Exception>(() => getTeamMethodInfo2.Invoke(aPITeamInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => getTeamMethodInfo1.Invoke(aPITeamInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => getTeamMethodInfo2.Invoke(aPITeamInstance, parametersOutRanged));
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_APITeam_GetTeam_Static_Method_With_2_Call_Using_Reflection_No_Exception_Thrown_Test()
        {
            // Arrange
            var queryDoc = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Object[] parameters = {queryDoc, oWeb};
            Exception exception, exception1, exception2, exception3, exception4;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetTeam";

            if (aPITeamInstance != null)
            {
                // Act
                var getTeamMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getTeamMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var result1 = getTeamMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception1, parameters);
                var result2 = getTeamMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception2, parameters);
                var result3 = getTeamMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception3, parameters);
                var result4 = getTeamMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception4, parameters);

                // Assert
                if (exception1 == null)
                {
                    exception1.ShouldBeNull();
                    result1.ShouldBeNull();
                    result2.ShouldBeNull();
                    result3.ShouldBeNull();
                    result4.ShouldBeNull();
                    Should.NotThrow(() => getTeamMethodInfo1.Invoke(aPITeamInstance, parameters));
                    Should.NotThrow(() => getTeamMethodInfo2.Invoke(aPITeamInstance, parameters));
                }
            }
        }

        #endregion

        #region General Method Call : Class (APITeam) => Method (GetTeamGridLayout) (Return Type : string) Test

        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeamGridLayout_Static_Method_2_Parameters_Method_Direct_Call_ParameterToken_3_Simple_Exploration_With_Throw_Exception_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => APITeam.GetTeamGridLayout(xml, oWeb);
            var actionException = ActionAnalyzer.GetActionException(executeAction);

            // Assert
            Should.Throw(() => APITeam.GetTeamGridLayout(xml, oWeb), exceptionType: actionException.GetType());
            Should.Throw<Exception>(() => APITeam.GetTeamGridLayout(xml, oWeb));
            actionException.ShouldNotBeNull();
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_APITeam_GetTeamGridLayout_Static_Method_2_Parameters_ParameterToken_3_Simple_Exploration_No_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => APITeam.GetTeamGridLayout(xml, oWeb);
            var actionException = ActionAnalyzer.GetActionException(executeAction);

            if (actionException == null)
            {
                // Assert
                actionException.ShouldBeNull();
                Should.NotThrow(() => APITeam.GetTeamGridLayout(xml, oWeb));
            }
        }
        
        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeamGridLayout_Static_Method_With_2_Parameters_Call_With_Reflection_Observe_Using_Overflow_Parameters_Obvious_Not_Null_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {xml, oWeb, null, null};
            Object[] parametersInDifferentNumber = {xml};
            Exception exception;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetTeamGridLayout";

            if (aPITeamInstance != null)
            {
                // Act
                var getTeamGridLayoutMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getTeamGridLayoutMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var returnType1 = getTeamGridLayoutMethodInfo1.ReturnType;
                var returnType2 = getTeamGridLayoutMethodInfo2.ReturnType;

                // Assert
                parametersOutRanged.ShouldNotBeNull();
                parametersInDifferentNumber.ShouldNotBeNull();
                returnType1.ShouldNotBeNull();
                returnType2.ShouldNotBeNull();
                returnType1.ShouldBe(returnType2);
                aPITeamInstance.ShouldNotBeNull();
                getTeamGridLayoutMethodInfo1.ShouldNotBeNull();
                getTeamGridLayoutMethodInfo2.ShouldNotBeNull();
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_APITeam_GetTeamGridLayout_Static_Method_With_2_Call_Using_Reflection_Result_Compare_If_Not_Null_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {xml, oWeb, null, null};
            Object[] parametersInDifferentNumber = {xml};
            Exception exception, exception1, exception2, exception3, exception4;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetTeamGridLayout";

            if (aPITeamInstance != null)
            {
                // Act
                var getTeamGridLayoutMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getTeamGridLayoutMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var returnType1 = getTeamGridLayoutMethodInfo1.ReturnType;
                var returnType2 = getTeamGridLayoutMethodInfo2.ReturnType;
                var result1 = getTeamGridLayoutMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception1, parametersOutRanged);
                var result2 = getTeamGridLayoutMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception2, parametersOutRanged);
                var result3 = getTeamGridLayoutMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception3, parametersInDifferentNumber);
                var result4 = getTeamGridLayoutMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception4, parametersInDifferentNumber);

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
        public void AUT_APITeam_GetTeamGridLayout_Static_Method_With_2_Call_Using_Reflection_Result_Validate_Null_Results_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {xml, oWeb, null, null};
            Object[] parametersInDifferentNumber = {xml};
            Exception exception, exception1, exception2, exception3, exception4;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetTeamGridLayout";

            if (aPITeamInstance != null)
            {
                // Act
                var getTeamGridLayoutMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getTeamGridLayoutMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var result1 = getTeamGridLayoutMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception1, parametersOutRanged);
                var result2 = getTeamGridLayoutMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception2, parametersOutRanged);
                var result3 = getTeamGridLayoutMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception3, parametersInDifferentNumber);
                var result4 = getTeamGridLayoutMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception4, parametersInDifferentNumber);

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
        public void AUT_APITeam_GetTeamGridLayout_Static_Method_With_2_Call_Using_Reflection_Throw_Exceptions_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {xml, oWeb, null, null};
            Object[] parametersInDifferentNumber = {xml};
            Exception exception, exception1, exception2, exception3, exception4;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetTeamGridLayout";

            if (aPITeamInstance != null)
            {
                // Act
                var getTeamGridLayoutMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getTeamGridLayoutMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var result1 = getTeamGridLayoutMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception1, parametersOutRanged);
                var result2 = getTeamGridLayoutMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception2, parametersOutRanged);
                var result3 = getTeamGridLayoutMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception3, parametersInDifferentNumber);
                var result4 = getTeamGridLayoutMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception4, parametersInDifferentNumber);

                // Assert
                exception1.ShouldNotBeNull();
                exception2.ShouldNotBeNull();
                result1.ShouldBeNull();
                result2.ShouldBeNull();
                result3.ShouldBeNull();
                result4.ShouldBeNull();
                Should.Throw(() => getTeamGridLayoutMethodInfo1.Invoke(aPITeamInstance, parametersOutRanged), exceptionType: exception1.GetType());
                Should.Throw(() => getTeamGridLayoutMethodInfo2.Invoke(aPITeamInstance, parametersOutRanged), exceptionType: exception2.GetType());
                Should.Throw<Exception>(() => getTeamGridLayoutMethodInfo1.Invoke(aPITeamInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => getTeamGridLayoutMethodInfo2.Invoke(aPITeamInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => getTeamGridLayoutMethodInfo1.Invoke(aPITeamInstance, parametersOutRanged));
                Should.Throw<Exception>(() => getTeamGridLayoutMethodInfo2.Invoke(aPITeamInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => getTeamGridLayoutMethodInfo1.Invoke(aPITeamInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => getTeamGridLayoutMethodInfo2.Invoke(aPITeamInstance, parametersOutRanged));
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_APITeam_GetTeamGridLayout_Static_Method_With_2_Call_Using_Reflection_No_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Object[] parameters = {xml, oWeb};
            Exception exception, exception1, exception2, exception3, exception4;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetTeamGridLayout";

            if (aPITeamInstance != null)
            {
                // Act
                var getTeamGridLayoutMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getTeamGridLayoutMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var result1 = getTeamGridLayoutMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception1, parameters);
                var result2 = getTeamGridLayoutMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception2, parameters);
                var result3 = getTeamGridLayoutMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception3, parameters);
                var result4 = getTeamGridLayoutMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception4, parameters);

                // Assert
                if (exception1 == null)
                {
                    exception1.ShouldBeNull();
                    result1.ShouldBeNull();
                    result2.ShouldBeNull();
                    result3.ShouldBeNull();
                    result4.ShouldBeNull();
                    Should.NotThrow(() => getTeamGridLayoutMethodInfo1.Invoke(aPITeamInstance, parameters));
                    Should.NotThrow(() => getTeamGridLayoutMethodInfo2.Invoke(aPITeamInstance, parameters));
                }
            }
        }

        #endregion

        #region General Method Call : Class (APITeam) => Method (GetResourceGridLayout) (Return Type : string) Test

        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourceGridLayout_Static_Method_2_Parameters_Method_Direct_Call_ParameterToken_4_Simple_Exploration_With_Throw_Exception_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => APITeam.GetResourceGridLayout(xml, oWeb);
            var actionException = ActionAnalyzer.GetActionException(executeAction);

            // Assert
            Should.Throw(() => APITeam.GetResourceGridLayout(xml, oWeb), exceptionType: actionException.GetType());
            Should.Throw<Exception>(() => APITeam.GetResourceGridLayout(xml, oWeb));
            actionException.ShouldNotBeNull();
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_APITeam_GetResourceGridLayout_Static_Method_2_Parameters_ParameterToken_4_Simple_Exploration_No_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => APITeam.GetResourceGridLayout(xml, oWeb);
            var actionException = ActionAnalyzer.GetActionException(executeAction);

            if (actionException == null)
            {
                // Assert
                actionException.ShouldBeNull();
                Should.NotThrow(() => APITeam.GetResourceGridLayout(xml, oWeb));
            }
        }
        
        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourceGridLayout_Static_Method_With_2_Parameters_Call_With_Reflection_Observe_Using_Overflow_Parameters_Obvious_Not_Null_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {xml, oWeb, null, null};
            Object[] parametersInDifferentNumber = {xml};
            Exception exception;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetResourceGridLayout";

            if (aPITeamInstance != null)
            {
                // Act
                var getResourceGridLayoutMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getResourceGridLayoutMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var returnType1 = getResourceGridLayoutMethodInfo1.ReturnType;
                var returnType2 = getResourceGridLayoutMethodInfo2.ReturnType;

                // Assert
                parametersOutRanged.ShouldNotBeNull();
                parametersInDifferentNumber.ShouldNotBeNull();
                returnType1.ShouldNotBeNull();
                returnType2.ShouldNotBeNull();
                returnType1.ShouldBe(returnType2);
                aPITeamInstance.ShouldNotBeNull();
                getResourceGridLayoutMethodInfo1.ShouldNotBeNull();
                getResourceGridLayoutMethodInfo2.ShouldNotBeNull();
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_APITeam_GetResourceGridLayout_Static_Method_With_2_Call_Using_Reflection_Result_Compare_If_Not_Null_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {xml, oWeb, null, null};
            Object[] parametersInDifferentNumber = {xml};
            Exception exception, exception1, exception2, exception3, exception4;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetResourceGridLayout";

            if (aPITeamInstance != null)
            {
                // Act
                var getResourceGridLayoutMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getResourceGridLayoutMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var returnType1 = getResourceGridLayoutMethodInfo1.ReturnType;
                var returnType2 = getResourceGridLayoutMethodInfo2.ReturnType;
                var result1 = getResourceGridLayoutMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception1, parametersOutRanged);
                var result2 = getResourceGridLayoutMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception2, parametersOutRanged);
                var result3 = getResourceGridLayoutMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception3, parametersInDifferentNumber);
                var result4 = getResourceGridLayoutMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception4, parametersInDifferentNumber);

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
        public void AUT_APITeam_GetResourceGridLayout_Static_Method_With_2_Call_Using_Reflection_Result_Validate_Null_Results_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {xml, oWeb, null, null};
            Object[] parametersInDifferentNumber = {xml};
            Exception exception, exception1, exception2, exception3, exception4;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetResourceGridLayout";

            if (aPITeamInstance != null)
            {
                // Act
                var getResourceGridLayoutMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getResourceGridLayoutMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var result1 = getResourceGridLayoutMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception1, parametersOutRanged);
                var result2 = getResourceGridLayoutMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception2, parametersOutRanged);
                var result3 = getResourceGridLayoutMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception3, parametersInDifferentNumber);
                var result4 = getResourceGridLayoutMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception4, parametersInDifferentNumber);

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
        public void AUT_APITeam_GetResourceGridLayout_Static_Method_With_2_Call_Using_Reflection_Throw_Exceptions_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {xml, oWeb, null, null};
            Object[] parametersInDifferentNumber = {xml};
            Exception exception, exception1, exception2, exception3, exception4;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetResourceGridLayout";

            if (aPITeamInstance != null)
            {
                // Act
                var getResourceGridLayoutMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getResourceGridLayoutMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var result1 = getResourceGridLayoutMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception1, parametersOutRanged);
                var result2 = getResourceGridLayoutMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception2, parametersOutRanged);
                var result3 = getResourceGridLayoutMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception3, parametersInDifferentNumber);
                var result4 = getResourceGridLayoutMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception4, parametersInDifferentNumber);

                // Assert
                exception1.ShouldNotBeNull();
                exception2.ShouldNotBeNull();
                result1.ShouldBeNull();
                result2.ShouldBeNull();
                result3.ShouldBeNull();
                result4.ShouldBeNull();
                Should.Throw(() => getResourceGridLayoutMethodInfo1.Invoke(aPITeamInstance, parametersOutRanged), exceptionType: exception1.GetType());
                Should.Throw(() => getResourceGridLayoutMethodInfo2.Invoke(aPITeamInstance, parametersOutRanged), exceptionType: exception2.GetType());
                Should.Throw<Exception>(() => getResourceGridLayoutMethodInfo1.Invoke(aPITeamInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => getResourceGridLayoutMethodInfo2.Invoke(aPITeamInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => getResourceGridLayoutMethodInfo1.Invoke(aPITeamInstance, parametersOutRanged));
                Should.Throw<Exception>(() => getResourceGridLayoutMethodInfo2.Invoke(aPITeamInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => getResourceGridLayoutMethodInfo1.Invoke(aPITeamInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => getResourceGridLayoutMethodInfo2.Invoke(aPITeamInstance, parametersOutRanged));
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_APITeam_GetResourceGridLayout_Static_Method_With_2_Call_Using_Reflection_No_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Object[] parameters = {xml, oWeb};
            Exception exception, exception1, exception2, exception3, exception4;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetResourceGridLayout";

            if (aPITeamInstance != null)
            {
                // Act
                var getResourceGridLayoutMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getResourceGridLayoutMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var result1 = getResourceGridLayoutMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception1, parameters);
                var result2 = getResourceGridLayoutMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception2, parameters);
                var result3 = getResourceGridLayoutMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception3, parameters);
                var result4 = getResourceGridLayoutMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception4, parameters);

                // Assert
                if (exception1 == null)
                {
                    exception1.ShouldBeNull();
                    result1.ShouldBeNull();
                    result2.ShouldBeNull();
                    result3.ShouldBeNull();
                    result4.ShouldBeNull();
                    Should.NotThrow(() => getResourceGridLayoutMethodInfo1.Invoke(aPITeamInstance, parameters));
                    Should.NotThrow(() => getResourceGridLayoutMethodInfo2.Invoke(aPITeamInstance, parameters));
                }
            }
        }

        #endregion

        #region General Method Call : Class (APITeam) => Method (GetResourceGridData) (Return Type : string) Test

        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourceGridData_Static_Method_2_Parameters_Method_Direct_Call_ParameterToken_5_Simple_Exploration_With_Throw_Exception_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => APITeam.GetResourceGridData(xml, oWeb);
            var actionException = ActionAnalyzer.GetActionException(executeAction);

            // Assert
            Should.Throw(() => APITeam.GetResourceGridData(xml, oWeb), exceptionType: actionException.GetType());
            Should.Throw<Exception>(() => APITeam.GetResourceGridData(xml, oWeb));
            actionException.ShouldNotBeNull();
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_APITeam_GetResourceGridData_Static_Method_2_Parameters_ParameterToken_5_Simple_Exploration_No_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => APITeam.GetResourceGridData(xml, oWeb);
            var actionException = ActionAnalyzer.GetActionException(executeAction);

            if (actionException == null)
            {
                // Assert
                actionException.ShouldBeNull();
                Should.NotThrow(() => APITeam.GetResourceGridData(xml, oWeb));
            }
        }
        
        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourceGridData_Static_Method_With_2_Parameters_Call_With_Reflection_Observe_Using_Overflow_Parameters_Obvious_Not_Null_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {xml, oWeb, null, null};
            Object[] parametersInDifferentNumber = {xml};
            Exception exception;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetResourceGridData";

            if (aPITeamInstance != null)
            {
                // Act
                var getResourceGridDataMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getResourceGridDataMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var returnType1 = getResourceGridDataMethodInfo1.ReturnType;
                var returnType2 = getResourceGridDataMethodInfo2.ReturnType;

                // Assert
                parametersOutRanged.ShouldNotBeNull();
                parametersInDifferentNumber.ShouldNotBeNull();
                returnType1.ShouldNotBeNull();
                returnType2.ShouldNotBeNull();
                returnType1.ShouldBe(returnType2);
                aPITeamInstance.ShouldNotBeNull();
                getResourceGridDataMethodInfo1.ShouldNotBeNull();
                getResourceGridDataMethodInfo2.ShouldNotBeNull();
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_APITeam_GetResourceGridData_Static_Method_With_2_Call_Using_Reflection_Result_Compare_If_Not_Null_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {xml, oWeb, null, null};
            Object[] parametersInDifferentNumber = {xml};
            Exception exception, exception1, exception2, exception3, exception4;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetResourceGridData";

            if (aPITeamInstance != null)
            {
                // Act
                var getResourceGridDataMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getResourceGridDataMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var returnType1 = getResourceGridDataMethodInfo1.ReturnType;
                var returnType2 = getResourceGridDataMethodInfo2.ReturnType;
                var result1 = getResourceGridDataMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception1, parametersOutRanged);
                var result2 = getResourceGridDataMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception2, parametersOutRanged);
                var result3 = getResourceGridDataMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception3, parametersInDifferentNumber);
                var result4 = getResourceGridDataMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception4, parametersInDifferentNumber);

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
        public void AUT_APITeam_GetResourceGridData_Static_Method_With_2_Call_Using_Reflection_Result_Validate_Null_Results_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {xml, oWeb, null, null};
            Object[] parametersInDifferentNumber = {xml};
            Exception exception, exception1, exception2, exception3, exception4;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetResourceGridData";

            if (aPITeamInstance != null)
            {
                // Act
                var getResourceGridDataMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getResourceGridDataMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var result1 = getResourceGridDataMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception1, parametersOutRanged);
                var result2 = getResourceGridDataMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception2, parametersOutRanged);
                var result3 = getResourceGridDataMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception3, parametersInDifferentNumber);
                var result4 = getResourceGridDataMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception4, parametersInDifferentNumber);

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
        public void AUT_APITeam_GetResourceGridData_Static_Method_With_2_Call_Using_Reflection_Throw_Exceptions_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {xml, oWeb, null, null};
            Object[] parametersInDifferentNumber = {xml};
            Exception exception, exception1, exception2, exception3, exception4;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetResourceGridData";

            if (aPITeamInstance != null)
            {
                // Act
                var getResourceGridDataMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getResourceGridDataMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var result1 = getResourceGridDataMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception1, parametersOutRanged);
                var result2 = getResourceGridDataMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception2, parametersOutRanged);
                var result3 = getResourceGridDataMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception3, parametersInDifferentNumber);
                var result4 = getResourceGridDataMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception4, parametersInDifferentNumber);

                // Assert
                exception1.ShouldNotBeNull();
                exception2.ShouldNotBeNull();
                result1.ShouldBeNull();
                result2.ShouldBeNull();
                result3.ShouldBeNull();
                result4.ShouldBeNull();
                Should.Throw(() => getResourceGridDataMethodInfo1.Invoke(aPITeamInstance, parametersOutRanged), exceptionType: exception1.GetType());
                Should.Throw(() => getResourceGridDataMethodInfo2.Invoke(aPITeamInstance, parametersOutRanged), exceptionType: exception2.GetType());
                Should.Throw<Exception>(() => getResourceGridDataMethodInfo1.Invoke(aPITeamInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => getResourceGridDataMethodInfo2.Invoke(aPITeamInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => getResourceGridDataMethodInfo1.Invoke(aPITeamInstance, parametersOutRanged));
                Should.Throw<Exception>(() => getResourceGridDataMethodInfo2.Invoke(aPITeamInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => getResourceGridDataMethodInfo1.Invoke(aPITeamInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => getResourceGridDataMethodInfo2.Invoke(aPITeamInstance, parametersOutRanged));
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_APITeam_GetResourceGridData_Static_Method_With_2_Call_Using_Reflection_No_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Object[] parameters = {xml, oWeb};
            Exception exception, exception1, exception2, exception3, exception4;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetResourceGridData";

            if (aPITeamInstance != null)
            {
                // Act
                var getResourceGridDataMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getResourceGridDataMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var result1 = getResourceGridDataMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception1, parameters);
                var result2 = getResourceGridDataMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception2, parameters);
                var result3 = getResourceGridDataMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception3, parameters);
                var result4 = getResourceGridDataMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception4, parameters);

                // Assert
                if (exception1 == null)
                {
                    exception1.ShouldBeNull();
                    result1.ShouldBeNull();
                    result2.ShouldBeNull();
                    result3.ShouldBeNull();
                    result4.ShouldBeNull();
                    Should.NotThrow(() => getResourceGridDataMethodInfo1.Invoke(aPITeamInstance, parameters));
                    Should.NotThrow(() => getResourceGridDataMethodInfo2.Invoke(aPITeamInstance, parameters));
                }
            }
        }

        #endregion

        #region General Method Call : Class (APITeam) => Method (GetTeamGridData) (Return Type : string) Test

        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeamGridData_Static_Method_2_Parameters_Method_Direct_Call_ParameterToken_6_Simple_Exploration_With_Throw_Exception_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => APITeam.GetTeamGridData(xml, oWeb);
            var actionException = ActionAnalyzer.GetActionException(executeAction);

            // Assert
            Should.Throw(() => APITeam.GetTeamGridData(xml, oWeb), exceptionType: actionException.GetType());
            Should.Throw<Exception>(() => APITeam.GetTeamGridData(xml, oWeb));
            actionException.ShouldNotBeNull();
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_APITeam_GetTeamGridData_Static_Method_2_Parameters_ParameterToken_6_Simple_Exploration_No_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => APITeam.GetTeamGridData(xml, oWeb);
            var actionException = ActionAnalyzer.GetActionException(executeAction);

            if (actionException == null)
            {
                // Assert
                actionException.ShouldBeNull();
                Should.NotThrow(() => APITeam.GetTeamGridData(xml, oWeb));
            }
        }
        
        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeamGridData_Static_Method_With_2_Parameters_Call_With_Reflection_Observe_Using_Overflow_Parameters_Obvious_Not_Null_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {xml, oWeb, null, null};
            Object[] parametersInDifferentNumber = {xml};
            Exception exception;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetTeamGridData";

            if (aPITeamInstance != null)
            {
                // Act
                var getTeamGridDataMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getTeamGridDataMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var returnType1 = getTeamGridDataMethodInfo1.ReturnType;
                var returnType2 = getTeamGridDataMethodInfo2.ReturnType;

                // Assert
                parametersOutRanged.ShouldNotBeNull();
                parametersInDifferentNumber.ShouldNotBeNull();
                returnType1.ShouldNotBeNull();
                returnType2.ShouldNotBeNull();
                returnType1.ShouldBe(returnType2);
                aPITeamInstance.ShouldNotBeNull();
                getTeamGridDataMethodInfo1.ShouldNotBeNull();
                getTeamGridDataMethodInfo2.ShouldNotBeNull();
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_APITeam_GetTeamGridData_Static_Method_With_2_Call_Using_Reflection_Result_Compare_If_Not_Null_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {xml, oWeb, null, null};
            Object[] parametersInDifferentNumber = {xml};
            Exception exception, exception1, exception2, exception3, exception4;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetTeamGridData";

            if (aPITeamInstance != null)
            {
                // Act
                var getTeamGridDataMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getTeamGridDataMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var returnType1 = getTeamGridDataMethodInfo1.ReturnType;
                var returnType2 = getTeamGridDataMethodInfo2.ReturnType;
                var result1 = getTeamGridDataMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception1, parametersOutRanged);
                var result2 = getTeamGridDataMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception2, parametersOutRanged);
                var result3 = getTeamGridDataMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception3, parametersInDifferentNumber);
                var result4 = getTeamGridDataMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception4, parametersInDifferentNumber);

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
        public void AUT_APITeam_GetTeamGridData_Static_Method_With_2_Call_Using_Reflection_Result_Validate_Null_Results_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {xml, oWeb, null, null};
            Object[] parametersInDifferentNumber = {xml};
            Exception exception, exception1, exception2, exception3, exception4;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetTeamGridData";

            if (aPITeamInstance != null)
            {
                // Act
                var getTeamGridDataMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getTeamGridDataMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var result1 = getTeamGridDataMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception1, parametersOutRanged);
                var result2 = getTeamGridDataMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception2, parametersOutRanged);
                var result3 = getTeamGridDataMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception3, parametersInDifferentNumber);
                var result4 = getTeamGridDataMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception4, parametersInDifferentNumber);

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
        public void AUT_APITeam_GetTeamGridData_Static_Method_With_2_Call_Using_Reflection_Throw_Exceptions_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {xml, oWeb, null, null};
            Object[] parametersInDifferentNumber = {xml};
            Exception exception, exception1, exception2, exception3, exception4;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetTeamGridData";

            if (aPITeamInstance != null)
            {
                // Act
                var getTeamGridDataMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getTeamGridDataMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var result1 = getTeamGridDataMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception1, parametersOutRanged);
                var result2 = getTeamGridDataMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception2, parametersOutRanged);
                var result3 = getTeamGridDataMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception3, parametersInDifferentNumber);
                var result4 = getTeamGridDataMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception4, parametersInDifferentNumber);

                // Assert
                exception1.ShouldNotBeNull();
                exception2.ShouldNotBeNull();
                result1.ShouldBeNull();
                result2.ShouldBeNull();
                result3.ShouldBeNull();
                result4.ShouldBeNull();
                Should.Throw(() => getTeamGridDataMethodInfo1.Invoke(aPITeamInstance, parametersOutRanged), exceptionType: exception1.GetType());
                Should.Throw(() => getTeamGridDataMethodInfo2.Invoke(aPITeamInstance, parametersOutRanged), exceptionType: exception2.GetType());
                Should.Throw<Exception>(() => getTeamGridDataMethodInfo1.Invoke(aPITeamInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => getTeamGridDataMethodInfo2.Invoke(aPITeamInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => getTeamGridDataMethodInfo1.Invoke(aPITeamInstance, parametersOutRanged));
                Should.Throw<Exception>(() => getTeamGridDataMethodInfo2.Invoke(aPITeamInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => getTeamGridDataMethodInfo1.Invoke(aPITeamInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => getTeamGridDataMethodInfo2.Invoke(aPITeamInstance, parametersOutRanged));
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_APITeam_GetTeamGridData_Static_Method_With_2_Call_Using_Reflection_No_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Object[] parameters = {xml, oWeb};
            Exception exception, exception1, exception2, exception3, exception4;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetTeamGridData";

            if (aPITeamInstance != null)
            {
                // Act
                var getTeamGridDataMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getTeamGridDataMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var result1 = getTeamGridDataMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception1, parameters);
                var result2 = getTeamGridDataMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception2, parameters);
                var result3 = getTeamGridDataMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception3, parameters);
                var result4 = getTeamGridDataMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception4, parameters);

                // Assert
                if (exception1 == null)
                {
                    exception1.ShouldBeNull();
                    result1.ShouldBeNull();
                    result2.ShouldBeNull();
                    result3.ShouldBeNull();
                    result4.ShouldBeNull();
                    Should.NotThrow(() => getTeamGridDataMethodInfo1.Invoke(aPITeamInstance, parameters));
                    Should.NotThrow(() => getTeamGridDataMethodInfo2.Invoke(aPITeamInstance, parameters));
                }
            }
        }

        #endregion

        #region General Method Call : Class (APITeam) => Method (GetResourcePoolXml) (Return Type : string) Test

        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourcePoolXml_Static_Method_2_Parameters_Method_Direct_Call_ParameterToken_7_Simple_Exploration_With_Throw_Exception_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => APITeam.GetResourcePoolXml(xml, oWeb);
            var actionException = ActionAnalyzer.GetActionException(executeAction);

            // Assert
            Should.Throw(() => APITeam.GetResourcePoolXml(xml, oWeb), exceptionType: actionException.GetType());
            Should.Throw<Exception>(() => APITeam.GetResourcePoolXml(xml, oWeb));
            actionException.ShouldNotBeNull();
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_APITeam_GetResourcePoolXml_Static_Method_2_Parameters_ParameterToken_7_Simple_Exploration_No_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => APITeam.GetResourcePoolXml(xml, oWeb);
            var actionException = ActionAnalyzer.GetActionException(executeAction);

            if (actionException == null)
            {
                // Assert
                actionException.ShouldBeNull();
                Should.NotThrow(() => APITeam.GetResourcePoolXml(xml, oWeb));
            }
        }
        
        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourcePoolXml_Static_Method_With_2_Parameters_Call_With_Reflection_Observe_Using_Overflow_Parameters_Obvious_Not_Null_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {xml, oWeb, null, null};
            Object[] parametersInDifferentNumber = {xml};
            Exception exception;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetResourcePoolXml";

            if (aPITeamInstance != null)
            {
                // Act
                var getResourcePoolXmlMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getResourcePoolXmlMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var returnType1 = getResourcePoolXmlMethodInfo1.ReturnType;
                var returnType2 = getResourcePoolXmlMethodInfo2.ReturnType;

                // Assert
                parametersOutRanged.ShouldNotBeNull();
                parametersInDifferentNumber.ShouldNotBeNull();
                returnType1.ShouldNotBeNull();
                returnType2.ShouldNotBeNull();
                returnType1.ShouldBe(returnType2);
                aPITeamInstance.ShouldNotBeNull();
                getResourcePoolXmlMethodInfo1.ShouldNotBeNull();
                getResourcePoolXmlMethodInfo2.ShouldNotBeNull();
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_APITeam_GetResourcePoolXml_Static_Method_With_2_Call_Using_Reflection_Result_Compare_If_Not_Null_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {xml, oWeb, null, null};
            Object[] parametersInDifferentNumber = {xml};
            Exception exception, exception1, exception2, exception3, exception4;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetResourcePoolXml";

            if (aPITeamInstance != null)
            {
                // Act
                var getResourcePoolXmlMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getResourcePoolXmlMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var returnType1 = getResourcePoolXmlMethodInfo1.ReturnType;
                var returnType2 = getResourcePoolXmlMethodInfo2.ReturnType;
                var result1 = getResourcePoolXmlMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception1, parametersOutRanged);
                var result2 = getResourcePoolXmlMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception2, parametersOutRanged);
                var result3 = getResourcePoolXmlMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception3, parametersInDifferentNumber);
                var result4 = getResourcePoolXmlMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception4, parametersInDifferentNumber);

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
        public void AUT_APITeam_GetResourcePoolXml_Static_Method_With_2_Call_Using_Reflection_Result_Validate_Null_Results_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {xml, oWeb, null, null};
            Object[] parametersInDifferentNumber = {xml};
            Exception exception, exception1, exception2, exception3, exception4;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetResourcePoolXml";

            if (aPITeamInstance != null)
            {
                // Act
                var getResourcePoolXmlMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getResourcePoolXmlMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var result1 = getResourcePoolXmlMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception1, parametersOutRanged);
                var result2 = getResourcePoolXmlMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception2, parametersOutRanged);
                var result3 = getResourcePoolXmlMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception3, parametersInDifferentNumber);
                var result4 = getResourcePoolXmlMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception4, parametersInDifferentNumber);

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
        public void AUT_APITeam_GetResourcePoolXml_Static_Method_With_2_Call_Using_Reflection_Throw_Exceptions_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {xml, oWeb, null, null};
            Object[] parametersInDifferentNumber = {xml};
            Exception exception, exception1, exception2, exception3, exception4;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetResourcePoolXml";

            if (aPITeamInstance != null)
            {
                // Act
                var getResourcePoolXmlMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getResourcePoolXmlMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var result1 = getResourcePoolXmlMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception1, parametersOutRanged);
                var result2 = getResourcePoolXmlMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception2, parametersOutRanged);
                var result3 = getResourcePoolXmlMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception3, parametersInDifferentNumber);
                var result4 = getResourcePoolXmlMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception4, parametersInDifferentNumber);

                // Assert
                exception1.ShouldNotBeNull();
                exception2.ShouldNotBeNull();
                result1.ShouldBeNull();
                result2.ShouldBeNull();
                result3.ShouldBeNull();
                result4.ShouldBeNull();
                Should.Throw(() => getResourcePoolXmlMethodInfo1.Invoke(aPITeamInstance, parametersOutRanged), exceptionType: exception1.GetType());
                Should.Throw(() => getResourcePoolXmlMethodInfo2.Invoke(aPITeamInstance, parametersOutRanged), exceptionType: exception2.GetType());
                Should.Throw<Exception>(() => getResourcePoolXmlMethodInfo1.Invoke(aPITeamInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => getResourcePoolXmlMethodInfo2.Invoke(aPITeamInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => getResourcePoolXmlMethodInfo1.Invoke(aPITeamInstance, parametersOutRanged));
                Should.Throw<Exception>(() => getResourcePoolXmlMethodInfo2.Invoke(aPITeamInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => getResourcePoolXmlMethodInfo1.Invoke(aPITeamInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => getResourcePoolXmlMethodInfo2.Invoke(aPITeamInstance, parametersOutRanged));
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_APITeam_GetResourcePoolXml_Static_Method_With_2_Call_Using_Reflection_No_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Object[] parameters = {xml, oWeb};
            Exception exception, exception1, exception2, exception3, exception4;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetResourcePoolXml";

            if (aPITeamInstance != null)
            {
                // Act
                var getResourcePoolXmlMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getResourcePoolXmlMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var result1 = getResourcePoolXmlMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception1, parameters);
                var result2 = getResourcePoolXmlMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception2, parameters);
                var result3 = getResourcePoolXmlMethodInfo1.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception3, parameters);
                var result4 = getResourcePoolXmlMethodInfo2.GetResultMethodInfo<APITeam, string>(aPITeamInstance, out exception4, parameters);

                // Assert
                if (exception1 == null)
                {
                    exception1.ShouldBeNull();
                    result1.ShouldBeNull();
                    result2.ShouldBeNull();
                    result3.ShouldBeNull();
                    result4.ShouldBeNull();
                    Should.NotThrow(() => getResourcePoolXmlMethodInfo1.Invoke(aPITeamInstance, parameters));
                    Should.NotThrow(() => getResourcePoolXmlMethodInfo2.Invoke(aPITeamInstance, parameters));
                }
            }
        }

        #endregion

        #region General Method Call : Class (APITeam) => Method (GetResourcePool) (Return Type : DataTable) Test

        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourcePool_Static_Method_2_Parameters_Method_Direct_Call_ParameterToken_8_Simple_Exploration_With_Throw_Exception_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => APITeam.GetResourcePool(xml, oWeb);
            var actionException = ActionAnalyzer.GetActionException(executeAction);

            // Assert
            Should.Throw(() => APITeam.GetResourcePool(xml, oWeb), exceptionType: actionException.GetType());
            Should.Throw<Exception>(() => APITeam.GetResourcePool(xml, oWeb));
            actionException.ShouldNotBeNull();
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_APITeam_GetResourcePool_Static_Method_2_Parameters_ParameterToken_8_Simple_Exploration_No_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => APITeam.GetResourcePool(xml, oWeb);
            var actionException = ActionAnalyzer.GetActionException(executeAction);

            if (actionException == null)
            {
                // Assert
                actionException.ShouldBeNull();
                Should.NotThrow(() => APITeam.GetResourcePool(xml, oWeb));
            }
        }
        
        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourcePool_Static_Method_With_2_Parameters_Call_With_Reflection_Observe_Using_Overflow_Parameters_Obvious_Not_Null_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {xml, oWeb, null, null};
            Object[] parametersInDifferentNumber = {xml};
            Exception exception;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetResourcePool";

            if (aPITeamInstance != null)
            {
                // Act
                var getResourcePoolMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getResourcePoolMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var returnType1 = getResourcePoolMethodInfo1.ReturnType;
                var returnType2 = getResourcePoolMethodInfo2.ReturnType;

                // Assert
                parametersOutRanged.ShouldNotBeNull();
                parametersInDifferentNumber.ShouldNotBeNull();
                returnType1.ShouldNotBeNull();
                returnType2.ShouldNotBeNull();
                returnType1.ShouldBe(returnType2);
                aPITeamInstance.ShouldNotBeNull();
                getResourcePoolMethodInfo1.ShouldNotBeNull();
                getResourcePoolMethodInfo2.ShouldNotBeNull();
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_APITeam_GetResourcePool_Static_Method_With_2_Call_Using_Reflection_Result_Compare_If_Not_Null_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {xml, oWeb, null, null};
            Object[] parametersInDifferentNumber = {xml};
            Exception exception, exception1, exception2, exception3, exception4;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetResourcePool";

            if (aPITeamInstance != null)
            {
                // Act
                var getResourcePoolMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getResourcePoolMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var returnType1 = getResourcePoolMethodInfo1.ReturnType;
                var returnType2 = getResourcePoolMethodInfo2.ReturnType;
                var result1 = getResourcePoolMethodInfo1.GetResultMethodInfo<APITeam, DataTable>(aPITeamInstance, out exception1, parametersOutRanged);
                var result2 = getResourcePoolMethodInfo2.GetResultMethodInfo<APITeam, DataTable>(aPITeamInstance, out exception2, parametersOutRanged);
                var result3 = getResourcePoolMethodInfo1.GetResultMethodInfo<APITeam, DataTable>(aPITeamInstance, out exception3, parametersInDifferentNumber);
                var result4 = getResourcePoolMethodInfo2.GetResultMethodInfo<APITeam, DataTable>(aPITeamInstance, out exception4, parametersInDifferentNumber);

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
        public void AUT_APITeam_GetResourcePool_Static_Method_With_2_Call_Using_Reflection_Result_Validate_Null_Results_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {xml, oWeb, null, null};
            Object[] parametersInDifferentNumber = {xml};
            Exception exception, exception1, exception2, exception3, exception4;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetResourcePool";

            if (aPITeamInstance != null)
            {
                // Act
                var getResourcePoolMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getResourcePoolMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var result1 = getResourcePoolMethodInfo1.GetResultMethodInfo<APITeam, DataTable>(aPITeamInstance, out exception1, parametersOutRanged);
                var result2 = getResourcePoolMethodInfo2.GetResultMethodInfo<APITeam, DataTable>(aPITeamInstance, out exception2, parametersOutRanged);
                var result3 = getResourcePoolMethodInfo1.GetResultMethodInfo<APITeam, DataTable>(aPITeamInstance, out exception3, parametersInDifferentNumber);
                var result4 = getResourcePoolMethodInfo2.GetResultMethodInfo<APITeam, DataTable>(aPITeamInstance, out exception4, parametersInDifferentNumber);

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
        public void AUT_APITeam_GetResourcePool_Static_Method_With_2_Call_Using_Reflection_Throw_Exceptions_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {xml, oWeb, null, null};
            Object[] parametersInDifferentNumber = {xml};
            Exception exception, exception1, exception2, exception3, exception4;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetResourcePool";

            if (aPITeamInstance != null)
            {
                // Act
                var getResourcePoolMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getResourcePoolMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var result1 = getResourcePoolMethodInfo1.GetResultMethodInfo<APITeam, DataTable>(aPITeamInstance, out exception1, parametersOutRanged);
                var result2 = getResourcePoolMethodInfo2.GetResultMethodInfo<APITeam, DataTable>(aPITeamInstance, out exception2, parametersOutRanged);
                var result3 = getResourcePoolMethodInfo1.GetResultMethodInfo<APITeam, DataTable>(aPITeamInstance, out exception3, parametersInDifferentNumber);
                var result4 = getResourcePoolMethodInfo2.GetResultMethodInfo<APITeam, DataTable>(aPITeamInstance, out exception4, parametersInDifferentNumber);

                // Assert
                exception1.ShouldNotBeNull();
                exception2.ShouldNotBeNull();
                result1.ShouldBeNull();
                result2.ShouldBeNull();
                result3.ShouldBeNull();
                result4.ShouldBeNull();
                Should.Throw(() => getResourcePoolMethodInfo1.Invoke(aPITeamInstance, parametersOutRanged), exceptionType: exception1.GetType());
                Should.Throw(() => getResourcePoolMethodInfo2.Invoke(aPITeamInstance, parametersOutRanged), exceptionType: exception2.GetType());
                Should.Throw<Exception>(() => getResourcePoolMethodInfo1.Invoke(aPITeamInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => getResourcePoolMethodInfo2.Invoke(aPITeamInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => getResourcePoolMethodInfo1.Invoke(aPITeamInstance, parametersOutRanged));
                Should.Throw<Exception>(() => getResourcePoolMethodInfo2.Invoke(aPITeamInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => getResourcePoolMethodInfo1.Invoke(aPITeamInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => getResourcePoolMethodInfo2.Invoke(aPITeamInstance, parametersOutRanged));
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_APITeam_GetResourcePool_Static_Method_With_2_Call_Using_Reflection_No_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Object[] parameters = {xml, oWeb};
            Exception exception, exception1, exception2, exception3, exception4;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetResourcePool";

            if (aPITeamInstance != null)
            {
                // Act
                var getResourcePoolMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getResourcePoolMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var result1 = getResourcePoolMethodInfo1.GetResultMethodInfo<APITeam, DataTable>(aPITeamInstance, out exception1, parameters);
                var result2 = getResourcePoolMethodInfo2.GetResultMethodInfo<APITeam, DataTable>(aPITeamInstance, out exception2, parameters);
                var result3 = getResourcePoolMethodInfo1.GetResultMethodInfo<APITeam, DataTable>(aPITeamInstance, out exception3, parameters);
                var result4 = getResourcePoolMethodInfo2.GetResultMethodInfo<APITeam, DataTable>(aPITeamInstance, out exception4, parameters);

                // Assert
                if (exception1 == null)
                {
                    exception1.ShouldBeNull();
                    result1.ShouldBeNull();
                    result2.ShouldBeNull();
                    result3.ShouldBeNull();
                    result4.ShouldBeNull();
                    Should.NotThrow(() => getResourcePoolMethodInfo1.Invoke(aPITeamInstance, parameters));
                    Should.NotThrow(() => getResourcePoolMethodInfo2.Invoke(aPITeamInstance, parameters));
                }
            }
        }

        #endregion

        #region General Method Call : Class (APITeam) => Method (GetResourcePoolForSave) (Return Type : DataTable) Test

        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourcePoolForSave_Static_Method_3_Parameters_Method_Direct_Call_ParameterToken_9_Simple_Exploration_With_Throw_Exception_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            var nodeTeam = CreateType<XmlNodeList>();
            Action executeAction = null;

            // Act
            executeAction = () => APITeam.GetResourcePoolForSave(xml, oWeb, nodeTeam);
            var actionException = ActionAnalyzer.GetActionException(executeAction);

            // Assert
            Should.Throw(() => APITeam.GetResourcePoolForSave(xml, oWeb, nodeTeam), exceptionType: actionException.GetType());
            Should.Throw<Exception>(() => APITeam.GetResourcePoolForSave(xml, oWeb, nodeTeam));
            actionException.ShouldNotBeNull();
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_APITeam_GetResourcePoolForSave_Static_Method_3_Parameters_ParameterToken_9_Simple_Exploration_No_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            var nodeTeam = CreateType<XmlNodeList>();
            Action executeAction = null;

            // Act
            executeAction = () => APITeam.GetResourcePoolForSave(xml, oWeb, nodeTeam);
            var actionException = ActionAnalyzer.GetActionException(executeAction);

            if (actionException == null)
            {
                // Assert
                actionException.ShouldBeNull();
                Should.NotThrow(() => APITeam.GetResourcePoolForSave(xml, oWeb, nodeTeam));
            }
        }
        
        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourcePoolForSave_Static_Method_With_3_Parameters_Call_With_Reflection_Observe_Using_Overflow_Parameters_Obvious_Not_Null_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            var nodeTeam = CreateType<XmlNodeList>();
            Object[] parametersOutRanged = {xml, oWeb, nodeTeam, null, null};
            Object[] parametersInDifferentNumber = {xml, oWeb};
            Exception exception;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetResourcePoolForSave";

            if (aPITeamInstance != null)
            {
                // Act
                var getResourcePoolForSaveMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getResourcePoolForSaveMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var returnType1 = getResourcePoolForSaveMethodInfo1.ReturnType;
                var returnType2 = getResourcePoolForSaveMethodInfo2.ReturnType;

                // Assert
                parametersOutRanged.ShouldNotBeNull();
                parametersInDifferentNumber.ShouldNotBeNull();
                returnType1.ShouldNotBeNull();
                returnType2.ShouldNotBeNull();
                returnType1.ShouldBe(returnType2);
                aPITeamInstance.ShouldNotBeNull();
                getResourcePoolForSaveMethodInfo1.ShouldNotBeNull();
                getResourcePoolForSaveMethodInfo2.ShouldNotBeNull();
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_APITeam_GetResourcePoolForSave_Static_Method_With_3_Call_Using_Reflection_Result_Compare_If_Not_Null_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            var nodeTeam = CreateType<XmlNodeList>();
            Object[] parametersOutRanged = {xml, oWeb, nodeTeam, null, null};
            Object[] parametersInDifferentNumber = {xml, oWeb};
            Exception exception, exception1, exception2, exception3, exception4;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetResourcePoolForSave";

            if (aPITeamInstance != null)
            {
                // Act
                var getResourcePoolForSaveMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getResourcePoolForSaveMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var returnType1 = getResourcePoolForSaveMethodInfo1.ReturnType;
                var returnType2 = getResourcePoolForSaveMethodInfo2.ReturnType;
                var result1 = getResourcePoolForSaveMethodInfo1.GetResultMethodInfo<APITeam, DataTable>(aPITeamInstance, out exception1, parametersOutRanged);
                var result2 = getResourcePoolForSaveMethodInfo2.GetResultMethodInfo<APITeam, DataTable>(aPITeamInstance, out exception2, parametersOutRanged);
                var result3 = getResourcePoolForSaveMethodInfo1.GetResultMethodInfo<APITeam, DataTable>(aPITeamInstance, out exception3, parametersInDifferentNumber);
                var result4 = getResourcePoolForSaveMethodInfo2.GetResultMethodInfo<APITeam, DataTable>(aPITeamInstance, out exception4, parametersInDifferentNumber);

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
        public void AUT_APITeam_GetResourcePoolForSave_Static_Method_With_3_Call_Using_Reflection_Result_Validate_Null_Results_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            var nodeTeam = CreateType<XmlNodeList>();
            Object[] parametersOutRanged = {xml, oWeb, nodeTeam, null, null};
            Object[] parametersInDifferentNumber = {xml, oWeb};
            Exception exception, exception1, exception2, exception3, exception4;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetResourcePoolForSave";

            if (aPITeamInstance != null)
            {
                // Act
                var getResourcePoolForSaveMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getResourcePoolForSaveMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var result1 = getResourcePoolForSaveMethodInfo1.GetResultMethodInfo<APITeam, DataTable>(aPITeamInstance, out exception1, parametersOutRanged);
                var result2 = getResourcePoolForSaveMethodInfo2.GetResultMethodInfo<APITeam, DataTable>(aPITeamInstance, out exception2, parametersOutRanged);
                var result3 = getResourcePoolForSaveMethodInfo1.GetResultMethodInfo<APITeam, DataTable>(aPITeamInstance, out exception3, parametersInDifferentNumber);
                var result4 = getResourcePoolForSaveMethodInfo2.GetResultMethodInfo<APITeam, DataTable>(aPITeamInstance, out exception4, parametersInDifferentNumber);

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
        public void AUT_APITeam_GetResourcePoolForSave_Static_Method_With_3_Call_Using_Reflection_Throw_Exceptions_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            var nodeTeam = CreateType<XmlNodeList>();
            Object[] parametersOutRanged = {xml, oWeb, nodeTeam, null, null};
            Object[] parametersInDifferentNumber = {xml, oWeb};
            Exception exception, exception1, exception2, exception3, exception4;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetResourcePoolForSave";

            if (aPITeamInstance != null)
            {
                // Act
                var getResourcePoolForSaveMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getResourcePoolForSaveMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var result1 = getResourcePoolForSaveMethodInfo1.GetResultMethodInfo<APITeam, DataTable>(aPITeamInstance, out exception1, parametersOutRanged);
                var result2 = getResourcePoolForSaveMethodInfo2.GetResultMethodInfo<APITeam, DataTable>(aPITeamInstance, out exception2, parametersOutRanged);
                var result3 = getResourcePoolForSaveMethodInfo1.GetResultMethodInfo<APITeam, DataTable>(aPITeamInstance, out exception3, parametersInDifferentNumber);
                var result4 = getResourcePoolForSaveMethodInfo2.GetResultMethodInfo<APITeam, DataTable>(aPITeamInstance, out exception4, parametersInDifferentNumber);

                // Assert
                exception1.ShouldNotBeNull();
                exception2.ShouldNotBeNull();
                result1.ShouldBeNull();
                result2.ShouldBeNull();
                result3.ShouldBeNull();
                result4.ShouldBeNull();
                Should.Throw(() => getResourcePoolForSaveMethodInfo1.Invoke(aPITeamInstance, parametersOutRanged), exceptionType: exception1.GetType());
                Should.Throw(() => getResourcePoolForSaveMethodInfo2.Invoke(aPITeamInstance, parametersOutRanged), exceptionType: exception2.GetType());
                Should.Throw<Exception>(() => getResourcePoolForSaveMethodInfo1.Invoke(aPITeamInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => getResourcePoolForSaveMethodInfo2.Invoke(aPITeamInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => getResourcePoolForSaveMethodInfo1.Invoke(aPITeamInstance, parametersOutRanged));
                Should.Throw<Exception>(() => getResourcePoolForSaveMethodInfo2.Invoke(aPITeamInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => getResourcePoolForSaveMethodInfo1.Invoke(aPITeamInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => getResourcePoolForSaveMethodInfo2.Invoke(aPITeamInstance, parametersOutRanged));
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_APITeam_GetResourcePoolForSave_Static_Method_With_3_Call_Using_Reflection_No_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            var nodeTeam = CreateType<XmlNodeList>();
            Object[] parameters = {xml, oWeb, nodeTeam};
            Exception exception, exception1, exception2, exception3, exception4;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetResourcePoolForSave";

            if (aPITeamInstance != null)
            {
                // Act
                var getResourcePoolForSaveMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getResourcePoolForSaveMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var result1 = getResourcePoolForSaveMethodInfo1.GetResultMethodInfo<APITeam, DataTable>(aPITeamInstance, out exception1, parameters);
                var result2 = getResourcePoolForSaveMethodInfo2.GetResultMethodInfo<APITeam, DataTable>(aPITeamInstance, out exception2, parameters);
                var result3 = getResourcePoolForSaveMethodInfo1.GetResultMethodInfo<APITeam, DataTable>(aPITeamInstance, out exception3, parameters);
                var result4 = getResourcePoolForSaveMethodInfo2.GetResultMethodInfo<APITeam, DataTable>(aPITeamInstance, out exception4, parameters);

                // Assert
                if (exception1 == null)
                {
                    exception1.ShouldBeNull();
                    result1.ShouldBeNull();
                    result2.ShouldBeNull();
                    result3.ShouldBeNull();
                    result4.ShouldBeNull();
                    Should.NotThrow(() => getResourcePoolForSaveMethodInfo1.Invoke(aPITeamInstance, parameters));
                    Should.NotThrow(() => getResourcePoolForSaveMethodInfo2.Invoke(aPITeamInstance, parameters));
                }
            }
        }

        #endregion

        #region General Method Call : Class (APITeam) => Method (GetWebGroups) (Return Type : List<SPGroup>) Test

        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetWebGroups_Static_Method_1_Parameters_Method_Direct_Call_ParameterToken_10_Simple_Exploration_With_Throw_Exception_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => APITeam.GetWebGroups(spWeb);
            var actionException = ActionAnalyzer.GetActionException(executeAction);

            // Assert
            Should.Throw(() => APITeam.GetWebGroups(spWeb), exceptionType: actionException.GetType());
            Should.Throw<Exception>(() => APITeam.GetWebGroups(spWeb));
            actionException.ShouldNotBeNull();
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_APITeam_GetWebGroups_Static_Method_1_Parameters_ParameterToken_10_Simple_Exploration_No_Exception_Thrown_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => APITeam.GetWebGroups(spWeb);
            var actionException = ActionAnalyzer.GetActionException(executeAction);

            if (actionException == null)
            {
                // Assert
                actionException.ShouldBeNull();
                Should.NotThrow(() => APITeam.GetWebGroups(spWeb));
            }
        }
        
        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetWebGroups_Static_Method_With_1_Parameters_Call_With_Reflection_Observe_Using_Overflow_Parameters_Obvious_Not_Null_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {spWeb, null, null};
            Object[] parametersInDifferentNumber = {};
            Exception exception;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetWebGroups";

            if (aPITeamInstance != null)
            {
                // Act
                var getWebGroupsMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getWebGroupsMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var returnType1 = getWebGroupsMethodInfo1.ReturnType;
                var returnType2 = getWebGroupsMethodInfo2.ReturnType;

                // Assert
                parametersOutRanged.ShouldNotBeNull();
                parametersInDifferentNumber.ShouldNotBeNull();
                returnType1.ShouldNotBeNull();
                returnType2.ShouldNotBeNull();
                returnType1.ShouldBe(returnType2);
                aPITeamInstance.ShouldNotBeNull();
                getWebGroupsMethodInfo1.ShouldNotBeNull();
                getWebGroupsMethodInfo2.ShouldNotBeNull();
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_APITeam_GetWebGroups_Static_Method_With_1_Call_Using_Reflection_Result_Compare_If_Not_Null_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {spWeb, null, null};
            Object[] parametersInDifferentNumber = {};
            Exception exception, exception1, exception2, exception3, exception4;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetWebGroups";

            if (aPITeamInstance != null)
            {
                // Act
                var getWebGroupsMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getWebGroupsMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var returnType1 = getWebGroupsMethodInfo1.ReturnType;
                var returnType2 = getWebGroupsMethodInfo2.ReturnType;
                var result1 = getWebGroupsMethodInfo1.GetResultMethodInfo<APITeam, List<SPGroup>>(aPITeamInstance, out exception1, parametersOutRanged);
                var result2 = getWebGroupsMethodInfo2.GetResultMethodInfo<APITeam, List<SPGroup>>(aPITeamInstance, out exception2, parametersOutRanged);
                var result3 = getWebGroupsMethodInfo1.GetResultMethodInfo<APITeam, List<SPGroup>>(aPITeamInstance, out exception3, parametersInDifferentNumber);
                var result4 = getWebGroupsMethodInfo2.GetResultMethodInfo<APITeam, List<SPGroup>>(aPITeamInstance, out exception4, parametersInDifferentNumber);

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
        public void AUT_APITeam_GetWebGroups_Static_Method_With_1_Call_Using_Reflection_Result_Validate_Null_Results_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {spWeb, null, null};
            Object[] parametersInDifferentNumber = {};
            Exception exception, exception1, exception2, exception3, exception4;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetWebGroups";

            if (aPITeamInstance != null)
            {
                // Act
                var getWebGroupsMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getWebGroupsMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var result1 = getWebGroupsMethodInfo1.GetResultMethodInfo<APITeam, List<SPGroup>>(aPITeamInstance, out exception1, parametersOutRanged);
                var result2 = getWebGroupsMethodInfo2.GetResultMethodInfo<APITeam, List<SPGroup>>(aPITeamInstance, out exception2, parametersOutRanged);
                var result3 = getWebGroupsMethodInfo1.GetResultMethodInfo<APITeam, List<SPGroup>>(aPITeamInstance, out exception3, parametersInDifferentNumber);
                var result4 = getWebGroupsMethodInfo2.GetResultMethodInfo<APITeam, List<SPGroup>>(aPITeamInstance, out exception4, parametersInDifferentNumber);

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
        public void AUT_APITeam_GetWebGroups_Static_Method_With_1_Call_Using_Reflection_Throw_Exceptions_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            Object[] parametersOutRanged = {spWeb, null, null};
            Object[] parametersInDifferentNumber = {};
            Exception exception, exception1, exception2, exception3, exception4;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetWebGroups";

            if (aPITeamInstance != null)
            {
                // Act
                var getWebGroupsMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getWebGroupsMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var result1 = getWebGroupsMethodInfo1.GetResultMethodInfo<APITeam, List<SPGroup>>(aPITeamInstance, out exception1, parametersOutRanged);
                var result2 = getWebGroupsMethodInfo2.GetResultMethodInfo<APITeam, List<SPGroup>>(aPITeamInstance, out exception2, parametersOutRanged);
                var result3 = getWebGroupsMethodInfo1.GetResultMethodInfo<APITeam, List<SPGroup>>(aPITeamInstance, out exception3, parametersInDifferentNumber);
                var result4 = getWebGroupsMethodInfo2.GetResultMethodInfo<APITeam, List<SPGroup>>(aPITeamInstance, out exception4, parametersInDifferentNumber);

                // Assert
                exception1.ShouldNotBeNull();
                exception2.ShouldNotBeNull();
                result1.ShouldBeNull();
                result2.ShouldBeNull();
                result3.ShouldBeNull();
                result4.ShouldBeNull();
                Should.Throw(() => getWebGroupsMethodInfo1.Invoke(aPITeamInstance, parametersOutRanged), exceptionType: exception1.GetType());
                Should.Throw(() => getWebGroupsMethodInfo2.Invoke(aPITeamInstance, parametersOutRanged), exceptionType: exception2.GetType());
                Should.Throw<Exception>(() => getWebGroupsMethodInfo1.Invoke(aPITeamInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => getWebGroupsMethodInfo2.Invoke(aPITeamInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => getWebGroupsMethodInfo1.Invoke(aPITeamInstance, parametersOutRanged));
                Should.Throw<Exception>(() => getWebGroupsMethodInfo2.Invoke(aPITeamInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => getWebGroupsMethodInfo1.Invoke(aPITeamInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => getWebGroupsMethodInfo2.Invoke(aPITeamInstance, parametersOutRanged));
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_APITeam_GetWebGroups_Static_Method_With_1_Call_Using_Reflection_No_Exception_Thrown_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            Object[] parameters = {spWeb};
            Exception exception, exception1, exception2, exception3, exception4;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "GetWebGroups";

            if (aPITeamInstance != null)
            {
                // Act
                var getWebGroupsMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var getWebGroupsMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var result1 = getWebGroupsMethodInfo1.GetResultMethodInfo<APITeam, List<SPGroup>>(aPITeamInstance, out exception1, parameters);
                var result2 = getWebGroupsMethodInfo2.GetResultMethodInfo<APITeam, List<SPGroup>>(aPITeamInstance, out exception2, parameters);
                var result3 = getWebGroupsMethodInfo1.GetResultMethodInfo<APITeam, List<SPGroup>>(aPITeamInstance, out exception3, parameters);
                var result4 = getWebGroupsMethodInfo2.GetResultMethodInfo<APITeam, List<SPGroup>>(aPITeamInstance, out exception4, parameters);

                // Assert
                if (exception1 == null)
                {
                    exception1.ShouldBeNull();
                    result1.ShouldBeNull();
                    result2.ShouldBeNull();
                    result3.ShouldBeNull();
                    result4.ShouldBeNull();
                    Should.NotThrow(() => getWebGroupsMethodInfo1.Invoke(aPITeamInstance, parameters));
                    Should.NotThrow(() => getWebGroupsMethodInfo2.Invoke(aPITeamInstance, parameters));
                }
            }
        }

        #endregion

        #region General Method Call : Class (APITeam) => Method (VerifyProjectTeamWorkspace) (Return Type : void) Test
        
        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_APITeam_VerifyProjectTeamWorkspace_Static_Method_3_Parameters_ParameterToken_11_Simple_Exploration_No_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var itemId = CreateType<int>();
            var listId = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => APITeam.VerifyProjectTeamWorkspace(web, out itemId, out listId);
            var actionException = ActionAnalyzer.GetActionException(executeAction);

            if (actionException == null)
            {
                // Assert
                actionException.ShouldBeNull();
                Should.NotThrow(() => APITeam.VerifyProjectTeamWorkspace(web, out itemId, out listId));
            }
        }
        
        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_VerifyProjectTeamWorkspace_Static_Method_With_3_Parameters_Call_With_Reflection_MethodExploration_By_No_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var itemId = CreateType<int>();
            var listId = CreateType<Guid>();
            Object[] parametersOfVerifyProjectTeamWorkspace = {web, itemId, listId};
            Exception exception = null, invokeException = null;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "VerifyProjectTeamWorkspace";

            if (aPITeamInstance != null)
            {
                // Act
                var verifyProjectTeamWorkspaceMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var verifyProjectTeamWorkspaceMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);

                // Assert
                invokeException.ShouldBeNull();
                Should.NotThrow(() => verifyProjectTeamWorkspaceMethodInfo1.Invoke(aPITeamInstance, parametersOfVerifyProjectTeamWorkspace));
                Should.NotThrow(() => verifyProjectTeamWorkspaceMethodInfo2.Invoke(aPITeamInstance, parametersOfVerifyProjectTeamWorkspace));
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_VerifyProjectTeamWorkspace_Static_Method_With_3_Parameters_Call_With_Reflection_Observe_Using_Overflow_Parameters_Obvious_Not_Null_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var itemId = CreateType<int>();
            var listId = CreateType<Guid>();
            Object[] parametersOutRanged = {web, itemId, listId, null, null};
            Object[] parametersInDifferentNumber = {web, itemId};
            Exception exception;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "VerifyProjectTeamWorkspace";

            if (aPITeamInstance != null)
            {
                // Act
                var verifyProjectTeamWorkspaceMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var verifyProjectTeamWorkspaceMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                var returnType1 = verifyProjectTeamWorkspaceMethodInfo1.ReturnType;
                var returnType2 = verifyProjectTeamWorkspaceMethodInfo2.ReturnType;

                // Assert
                parametersOutRanged.ShouldNotBeNull();
                parametersInDifferentNumber.ShouldNotBeNull();
                returnType1.ShouldNotBeNull();
                returnType2.ShouldNotBeNull();
                returnType1.ShouldBe(returnType2);
                aPITeamInstance.ShouldNotBeNull();
                verifyProjectTeamWorkspaceMethodInfo1.ShouldNotBeNull();
                verifyProjectTeamWorkspaceMethodInfo2.ShouldNotBeNull();
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_VerifyProjectTeamWorkspace_Static_Method_With_3_Call_Using_Reflection_Throw_Exceptions_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var itemId = CreateType<int>();
            var listId = CreateType<Guid>();
            Object[] parametersOutRanged = {web, itemId, listId, null, null};
            Object[] parametersInDifferentNumber = {web, itemId};
            Exception exception, exception1, exception2, exception3, exception4;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "VerifyProjectTeamWorkspace";

            if (aPITeamInstance != null)
            {
                // Act
                var verifyProjectTeamWorkspaceMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var verifyProjectTeamWorkspaceMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                verifyProjectTeamWorkspaceMethodInfo1.InvokeMethodInfo(aPITeamInstance, out exception1, parametersOutRanged);
                verifyProjectTeamWorkspaceMethodInfo2.InvokeMethodInfo(aPITeamInstance, out exception2, parametersOutRanged);
                verifyProjectTeamWorkspaceMethodInfo1.InvokeMethodInfo(aPITeamInstance, out exception3, parametersInDifferentNumber);
                verifyProjectTeamWorkspaceMethodInfo2.InvokeMethodInfo(aPITeamInstance, out exception4, parametersInDifferentNumber);

                // Assert
                exception1.ShouldNotBeNull();
                exception2.ShouldNotBeNull();
                Should.Throw(() => verifyProjectTeamWorkspaceMethodInfo1.Invoke(aPITeamInstance, parametersOutRanged), exceptionType: exception1.GetType());
                Should.Throw(() => verifyProjectTeamWorkspaceMethodInfo2.Invoke(aPITeamInstance, parametersOutRanged), exceptionType: exception2.GetType());
                Should.Throw<Exception>(() => verifyProjectTeamWorkspaceMethodInfo1.Invoke(aPITeamInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => verifyProjectTeamWorkspaceMethodInfo2.Invoke(aPITeamInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => verifyProjectTeamWorkspaceMethodInfo1.Invoke(aPITeamInstance, parametersOutRanged));
                Should.Throw<Exception>(() => verifyProjectTeamWorkspaceMethodInfo2.Invoke(aPITeamInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => verifyProjectTeamWorkspaceMethodInfo1.Invoke(aPITeamInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => verifyProjectTeamWorkspaceMethodInfo2.Invoke(aPITeamInstance, parametersOutRanged));
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_APITeam_VerifyProjectTeamWorkspace_Static_Method_With_3_Call_Using_Reflection_No_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var itemId = CreateType<int>();
            var listId = CreateType<Guid>();
            Object[] parameters = {web, itemId, listId};
            Exception exception, exception1, exception2, exception3, exception4;
            var aPITeamInstance  = Create(out exception);
            const string methodName = "VerifyProjectTeamWorkspace";

            if (aPITeamInstance != null)
            {
                // Act
                var verifyProjectTeamWorkspaceMethodInfo1 = aPITeamInstance.GetType().GetMethod(methodName);
                var verifyProjectTeamWorkspaceMethodInfo2 = aPITeamInstance.GetType().GetMethod(methodName);
                verifyProjectTeamWorkspaceMethodInfo1.InvokeMethodInfo(aPITeamInstance, out exception1, parameters);
                verifyProjectTeamWorkspaceMethodInfo2.InvokeMethodInfo(aPITeamInstance, out exception2, parameters);
                verifyProjectTeamWorkspaceMethodInfo1.InvokeMethodInfo(aPITeamInstance, out exception3, parameters);
                verifyProjectTeamWorkspaceMethodInfo2.InvokeMethodInfo(aPITeamInstance, out exception4, parameters);

                // Assert
                if (exception1 == null)
                {
                    exception1.ShouldBeNull();
                    Should.NotThrow(() => verifyProjectTeamWorkspaceMethodInfo1.Invoke(aPITeamInstance, parameters));
                    Should.NotThrow(() => verifyProjectTeamWorkspaceMethodInfo2.Invoke(aPITeamInstance, parameters));
                }
            }
        }

        #endregion

        #endregion

        #region Category : Initializer

        #region General Initializer : Class (APITeam) Initializer

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
        ///    Create <see cref="APITeam" /> class.
        /// </summary>
        /// <returns>Returns a newly created <see cref="APITeam" />.</returns>
        [ExcludeFromCodeCoverage]
        private APITeam Create(bool useFixtureAtFirst = false)
        {
            Exception createException;
            var parameters = CreateOrGetPrameters();
            return Create(createException: out createException, useFixtureAtFirst: useFixtureAtFirst, parameters: parameters);
        }

        /// <summary>
        ///    Create <see cref="APITeam" /> class.
        /// </summary>
        /// <returns>Returns a newly created <see cref="APITeam" />.</returns>
        [ExcludeFromCodeCoverage]
        private APITeam Create(out Exception createException, object[] parameters = null, bool useFixtureAtFirst = false)
        {
            return CreateAnalyzer.Create<APITeam>(fixture: Fixture, exception: out createException, useFixtureAtFirst: useFixtureAtFirst, parameters: parameters);
        }

        /// <summary>
        ///    Create Multiple of <see cref="APITeam" /> classes depending on the given number.
        /// </summary>
        /// <returns>Returns a newly created <see cref="APITeam" />.</returns>
        private APITeam[] CreateMany(out Exception[] createExceptions, out bool isResultsAreNull, int number = 6, object[] parameters = null)
        {
            return CreateAnalyzer.CreateMany<APITeam>(number: number, fixture: Fixture, exceptions: out createExceptions, isResultsAreNull: out isResultsAreNull, parameters: parameters);
        }

        /// <summary>
        ///    Create dynamic parameters for <see cref="APITeam" /> class using AutoFixture.
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

        #region Explore Class for Coverage Gain : Class (APITeam)

        /// <summary>
        ///     Regular class (<see cref="APITeam" />) non-public fields explore and verify for coverage gain.
        /// </summary>
        [Test]
        [Category("AUT Initializer")]
        public void AUT_RegularClass_APITeam_NonPublic_Fields_Explore_Verify()
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyNonPublicFields<APITeam>(Fixture);
        }

        /// <summary>
        ///     Regular class (<see cref="APITeam" />) non-public properties explore and verify for coverage gain.
        /// </summary>
        [Test]
        [Category("AUT Initializer")]
        public void AUT_RegularClass_APITeam_NonPublic_Properties_Explore_Verify()
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyNonPublicProperties<APITeam>(Fixture);
        }

        /// <summary>
        ///     Regular class (<see cref="APITeam" />) non-public methods explore and verify for coverage gain.
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
        public void AUT_RegularClass_APITeam_NonPublic_Methods_Explore_Verify(int pageNumber = 1, int perPageMethodsToVerify = 3)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyNonPublicMethods<APITeam>(Fixture, pageNumber, perPageMethodsToVerify);
        }

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (APITeam) without Parameter Test

        [Test]
        [Category("AUT Constructor")]
        public void AUT_Constructor_APITeam_Instantiated_Without_Parameter_Throw_Exception_Test()
        {
            // Arrange
            APITeam instance = null;
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            if (exception != null)
            {
                // Assert
                Should.Throw<Exception>(() => new APITeam());
                instance.ShouldBeNull();
                exception.ShouldNotBeNull();
                instance.ShouldNotBeOfType<APITeam>();
            }
        }

        [Test]
        [Category("AUT Constructor")]
        public void AUT_Constructor_APITeam_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            APITeam instance = null;
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            if (exception == null)
            {
                // Assert
                Should.NotThrow(() => new APITeam());
                instance.ShouldNotBeNull();
                exception.ShouldBeNull();
            }
        }

        [Test]
        [Category("AUT Constructor")]
        public void AUT_Constructor_APITeam_Without_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            APITeam instance = null;
            Exception creationException = null;
            Action createAction = () => instance = new APITeam();

            // Act
            creationException = ActionAnalyzer.GetActionException(createAction);

            if (instance != null)
            {
                // Assert
                instance.ShouldNotBeNull();
                instance.ShouldBeOfType<APITeam>();
            }
        }

        #endregion

        #endregion

        #endregion
    }
}
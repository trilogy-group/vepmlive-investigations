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

namespace EPMLiveCore.API
{
    /// <summary>
    ///     Automatic Unit Tests for (<see cref="NavigationService" />) class
    ///     using generator's artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class NavigationServiceTest : AbstractGenericTest
    {
        #region Category : General

        #region Category : MethodCallTest

        #region General Method Call : Class (NavigationService) => Method (GetContextualMenuItems) (Return Type : object) Test

        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetContextualMenuItems_Method_1_Parameters_Method_Direct_Call_ParameterToken_1_Simple_Exploration_With_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;
            Exception exception = null, actionException = null;
            var navigationServiceInstance  = Create(out exception);
            var isInstanceNotNull = navigationServiceInstance != null;

            if (isInstanceNotNull)
            {
                // Act
                executeAction = () => navigationServiceInstance.GetContextualMenuItems(data);
                actionException = ActionAnalyzer.GetActionException(executeAction);

                // Assert
                Should.Throw(() => navigationServiceInstance.GetContextualMenuItems(data), exceptionType: actionException.GetType());
                Should.Throw<Exception>(() => navigationServiceInstance.GetContextualMenuItems(data));
                actionException.ShouldNotBeNull();
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_NavigationService_GetContextualMenuItems_Method_1_Parameters_ParameterToken_1_Simple_Exploration_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;
            Exception exception = null, actionException = null;
            var navigationServiceInstance  = Create(out exception);
            var isInstanceNotNull = navigationServiceInstance != null;

            if (isInstanceNotNull)
            {
                // Act
                executeAction = () => navigationServiceInstance.GetContextualMenuItems(data);
                actionException = ActionAnalyzer.GetActionException(executeAction);

                if (actionException == null)
                {
                    // Assert
                    actionException.ShouldBeNull();
                    Should.NotThrow(() => navigationServiceInstance.GetContextualMenuItems(data));
                }
            }
        }
        
        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetContextualMenuItems_Method_With_1_Parameters_Call_With_Reflection_Observe_Using_Overflow_Parameters_Obvious_Not_Null_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Object[] parametersOutRanged = {data, null, null};
            Object[] parametersInDifferentNumber = {};
            Exception exception;
            var navigationServiceInstance  = Create(out exception);
            const string methodName = "GetContextualMenuItems";

            if (navigationServiceInstance != null)
            {
                // Act
                var getContextualMenuItemsMethodInfo1 = navigationServiceInstance.GetType().GetMethod(methodName);
                var getContextualMenuItemsMethodInfo2 = navigationServiceInstance.GetType().GetMethod(methodName);
                var returnType1 = getContextualMenuItemsMethodInfo1.ReturnType;
                var returnType2 = getContextualMenuItemsMethodInfo2.ReturnType;

                // Assert
                parametersOutRanged.ShouldNotBeNull();
                parametersInDifferentNumber.ShouldNotBeNull();
                returnType1.ShouldNotBeNull();
                returnType2.ShouldNotBeNull();
                returnType1.ShouldBe(returnType2);
                navigationServiceInstance.ShouldNotBeNull();
                getContextualMenuItemsMethodInfo1.ShouldNotBeNull();
                getContextualMenuItemsMethodInfo2.ShouldNotBeNull();
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_NavigationService_GetContextualMenuItems_Method_With_1_Call_Using_Reflection_Result_Compare_If_Not_Null_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Object[] parametersOutRanged = {data, null, null};
            Object[] parametersInDifferentNumber = {};
            Exception exception, exception1, exception2, exception3, exception4;
            var navigationServiceInstance  = Create(out exception);
            const string methodName = "GetContextualMenuItems";

            if (navigationServiceInstance != null)
            {
                // Act
                var getContextualMenuItemsMethodInfo1 = navigationServiceInstance.GetType().GetMethod(methodName);
                var getContextualMenuItemsMethodInfo2 = navigationServiceInstance.GetType().GetMethod(methodName);
                var returnType1 = getContextualMenuItemsMethodInfo1.ReturnType;
                var returnType2 = getContextualMenuItemsMethodInfo2.ReturnType;
                var result1 = getContextualMenuItemsMethodInfo1.GetResultMethodInfo<NavigationService, object>(navigationServiceInstance, out exception1, parametersOutRanged);
                var result2 = getContextualMenuItemsMethodInfo2.GetResultMethodInfo<NavigationService, object>(navigationServiceInstance, out exception2, parametersOutRanged);
                var result3 = getContextualMenuItemsMethodInfo1.GetResultMethodInfo<NavigationService, object>(navigationServiceInstance, out exception3, parametersInDifferentNumber);
                var result4 = getContextualMenuItemsMethodInfo2.GetResultMethodInfo<NavigationService, object>(navigationServiceInstance, out exception4, parametersInDifferentNumber);

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
        public void AUT_NavigationService_GetContextualMenuItems_Method_With_1_Call_Using_Reflection_Result_Validate_Null_Results_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Object[] parametersOutRanged = {data, null, null};
            Object[] parametersInDifferentNumber = {};
            Exception exception, exception1, exception2, exception3, exception4;
            var navigationServiceInstance  = Create(out exception);
            const string methodName = "GetContextualMenuItems";

            if (navigationServiceInstance != null)
            {
                // Act
                var getContextualMenuItemsMethodInfo1 = navigationServiceInstance.GetType().GetMethod(methodName);
                var getContextualMenuItemsMethodInfo2 = navigationServiceInstance.GetType().GetMethod(methodName);
                var result1 = getContextualMenuItemsMethodInfo1.GetResultMethodInfo<NavigationService, object>(navigationServiceInstance, out exception1, parametersOutRanged);
                var result2 = getContextualMenuItemsMethodInfo2.GetResultMethodInfo<NavigationService, object>(navigationServiceInstance, out exception2, parametersOutRanged);
                var result3 = getContextualMenuItemsMethodInfo1.GetResultMethodInfo<NavigationService, object>(navigationServiceInstance, out exception3, parametersInDifferentNumber);
                var result4 = getContextualMenuItemsMethodInfo2.GetResultMethodInfo<NavigationService, object>(navigationServiceInstance, out exception4, parametersInDifferentNumber);

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
        public void AUT_NavigationService_GetContextualMenuItems_Method_With_1_Call_Using_Reflection_Throw_Exceptions_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Object[] parametersOutRanged = {data, null, null};
            Object[] parametersInDifferentNumber = {};
            Exception exception, exception1, exception2, exception3, exception4;
            var navigationServiceInstance  = Create(out exception);
            const string methodName = "GetContextualMenuItems";

            if (navigationServiceInstance != null)
            {
                // Act
                var getContextualMenuItemsMethodInfo1 = navigationServiceInstance.GetType().GetMethod(methodName);
                var getContextualMenuItemsMethodInfo2 = navigationServiceInstance.GetType().GetMethod(methodName);
                var result1 = getContextualMenuItemsMethodInfo1.GetResultMethodInfo<NavigationService, object>(navigationServiceInstance, out exception1, parametersOutRanged);
                var result2 = getContextualMenuItemsMethodInfo2.GetResultMethodInfo<NavigationService, object>(navigationServiceInstance, out exception2, parametersOutRanged);
                var result3 = getContextualMenuItemsMethodInfo1.GetResultMethodInfo<NavigationService, object>(navigationServiceInstance, out exception3, parametersInDifferentNumber);
                var result4 = getContextualMenuItemsMethodInfo2.GetResultMethodInfo<NavigationService, object>(navigationServiceInstance, out exception4, parametersInDifferentNumber);

                // Assert
                exception1.ShouldNotBeNull();
                exception2.ShouldNotBeNull();
                result1.ShouldBeNull();
                result2.ShouldBeNull();
                result3.ShouldBeNull();
                result4.ShouldBeNull();
                Should.Throw(() => getContextualMenuItemsMethodInfo1.Invoke(navigationServiceInstance, parametersOutRanged), exceptionType: exception1.GetType());
                Should.Throw(() => getContextualMenuItemsMethodInfo2.Invoke(navigationServiceInstance, parametersOutRanged), exceptionType: exception2.GetType());
                Should.Throw<Exception>(() => getContextualMenuItemsMethodInfo1.Invoke(navigationServiceInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => getContextualMenuItemsMethodInfo2.Invoke(navigationServiceInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => getContextualMenuItemsMethodInfo1.Invoke(navigationServiceInstance, parametersOutRanged));
                Should.Throw<Exception>(() => getContextualMenuItemsMethodInfo2.Invoke(navigationServiceInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => getContextualMenuItemsMethodInfo1.Invoke(navigationServiceInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => getContextualMenuItemsMethodInfo2.Invoke(navigationServiceInstance, parametersOutRanged));
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_NavigationService_GetContextualMenuItems_Method_With_1_Call_Using_Reflection_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Object[] parameters = {data};
            Exception exception, exception1, exception2, exception3, exception4;
            var navigationServiceInstance  = Create(out exception);
            const string methodName = "GetContextualMenuItems";

            if (navigationServiceInstance != null)
            {
                // Act
                var getContextualMenuItemsMethodInfo1 = navigationServiceInstance.GetType().GetMethod(methodName);
                var getContextualMenuItemsMethodInfo2 = navigationServiceInstance.GetType().GetMethod(methodName);
                var result1 = getContextualMenuItemsMethodInfo1.GetResultMethodInfo<NavigationService, object>(navigationServiceInstance, out exception1, parameters);
                var result2 = getContextualMenuItemsMethodInfo2.GetResultMethodInfo<NavigationService, object>(navigationServiceInstance, out exception2, parameters);
                var result3 = getContextualMenuItemsMethodInfo1.GetResultMethodInfo<NavigationService, object>(navigationServiceInstance, out exception3, parameters);
                var result4 = getContextualMenuItemsMethodInfo2.GetResultMethodInfo<NavigationService, object>(navigationServiceInstance, out exception4, parameters);

                // Assert
                if (exception1 == null)
                {
                    exception1.ShouldBeNull();
                    result1.ShouldBeNull();
                    result2.ShouldBeNull();
                    result3.ShouldBeNull();
                    result4.ShouldBeNull();
                    Should.NotThrow(() => getContextualMenuItemsMethodInfo1.Invoke(navigationServiceInstance, parameters));
                    Should.NotThrow(() => getContextualMenuItemsMethodInfo2.Invoke(navigationServiceInstance, parameters));
                }
            }
        }

        #endregion

        #region General Method Call : Class (NavigationService) => Method (GetLinks) (Return Type : string) Test

        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetLinks_Method_Direct_Call_ParameterToken_2_Simple_Exploration_With_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;
            Exception exception = null, actionException = null;
            var navigationServiceInstance  = Create(out exception);
            var isInstanceNotNull = navigationServiceInstance != null;

            if (isInstanceNotNull)
            {
                // Act
                executeAction = () => navigationServiceInstance.GetLinks();
                actionException = ActionAnalyzer.GetActionException(executeAction);

                // Assert
                Should.Throw(() => navigationServiceInstance.GetLinks(), exceptionType: actionException.GetType());
                Should.Throw<Exception>(() => navigationServiceInstance.GetLinks());
                actionException.ShouldNotBeNull();
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_NavigationService_GetLinks_Method_Direct_Call_ParameterToken_2_Simple_Exploration_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;
            Exception exception = null, actionException = null;
            var navigationServiceInstance  = Create(out exception);
            var isInstanceNotNull = navigationServiceInstance != null;

            if (isInstanceNotNull)
            {
                // Act
                executeAction = () => navigationServiceInstance.GetLinks();
                actionException = ActionAnalyzer.GetActionException(executeAction);

                if (actionException == null)
                {
                    // Assert
                    actionException.ShouldBeNull();
                    Should.NotThrow(() => navigationServiceInstance.GetLinks());
                }
            }
        }
        
        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetLinks_Method_With_Call_With_Reflection_Observe_Using_Overflow_Parameters_Obvious_Not_Null_Test()
        {
            // Arrange
            Object[] parametersOutRanged = {null, "", null, null};
            Object[] parametersInDifferentNumber = {};
            Exception exception;
            var navigationServiceInstance  = Create(out exception);
            const string methodName = "GetLinks";

            if (navigationServiceInstance != null)
            {
                // Act
                var getLinksMethodInfo1 = navigationServiceInstance.GetType().GetMethod(methodName);
                var getLinksMethodInfo2 = navigationServiceInstance.GetType().GetMethod(methodName);
                var returnType1 = getLinksMethodInfo1.ReturnType;
                var returnType2 = getLinksMethodInfo2.ReturnType;

                // Assert
                parametersOutRanged.ShouldNotBeNull();
                parametersInDifferentNumber.ShouldNotBeNull();
                returnType1.ShouldNotBeNull();
                returnType2.ShouldNotBeNull();
                returnType1.ShouldBe(returnType2);
                navigationServiceInstance.ShouldNotBeNull();
                getLinksMethodInfo1.ShouldNotBeNull();
                getLinksMethodInfo2.ShouldNotBeNull();
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_NavigationService_GetLinks_Method_Call_Using_Reflection_Result_Compare_If_Not_Null_Test()
        {
            // Arrange
            Object[] parametersOutRanged = {null, "", null, null};
            Object[] parametersInDifferentNumber = {};
            Exception exception, exception1, exception2, exception3, exception4;
            var navigationServiceInstance  = Create(out exception);
            const string methodName = "GetLinks";

            if (navigationServiceInstance != null)
            {
                // Act
                var getLinksMethodInfo1 = navigationServiceInstance.GetType().GetMethod(methodName);
                var getLinksMethodInfo2 = navigationServiceInstance.GetType().GetMethod(methodName);
                var returnType1 = getLinksMethodInfo1.ReturnType;
                var returnType2 = getLinksMethodInfo2.ReturnType;
                var result1 = getLinksMethodInfo1.GetResultMethodInfo<NavigationService, string>(navigationServiceInstance, out exception1, parametersOutRanged);
                var result2 = getLinksMethodInfo2.GetResultMethodInfo<NavigationService, string>(navigationServiceInstance, out exception2, parametersOutRanged);
                var result3 = getLinksMethodInfo1.GetResultMethodInfo<NavigationService, string>(navigationServiceInstance, out exception3, parametersInDifferentNumber);
                var result4 = getLinksMethodInfo2.GetResultMethodInfo<NavigationService, string>(navigationServiceInstance, out exception4, parametersInDifferentNumber);

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
        public void AUT_NavigationService_GetLinks_Method_Call_Using_Reflection_Result_Validate_Null_Results_Test()
        {
            // Arrange
            Object[] parametersOutRanged = {null, "", null, null};
            Object[] parametersInDifferentNumber = {};
            Exception exception, exception1, exception2, exception3, exception4;
            var navigationServiceInstance  = Create(out exception);
            const string methodName = "GetLinks";

            if (navigationServiceInstance != null)
            {
                // Act
                var getLinksMethodInfo1 = navigationServiceInstance.GetType().GetMethod(methodName);
                var getLinksMethodInfo2 = navigationServiceInstance.GetType().GetMethod(methodName);
                var result1 = getLinksMethodInfo1.GetResultMethodInfo<NavigationService, string>(navigationServiceInstance, out exception1, parametersOutRanged);
                var result2 = getLinksMethodInfo2.GetResultMethodInfo<NavigationService, string>(navigationServiceInstance, out exception2, parametersOutRanged);
                var result3 = getLinksMethodInfo1.GetResultMethodInfo<NavigationService, string>(navigationServiceInstance, out exception3, parametersInDifferentNumber);
                var result4 = getLinksMethodInfo2.GetResultMethodInfo<NavigationService, string>(navigationServiceInstance, out exception4, parametersInDifferentNumber);

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
        public void AUT_NavigationService_GetLinks_Method_Call_Using_Reflection_Throw_Exceptions_Test()
        {
            // Arrange
            Object[] parametersOutRanged = {null, "", null, null};
            Object[] parametersInDifferentNumber = {};
            Exception exception, exception1, exception2, exception3, exception4;
            var navigationServiceInstance  = Create(out exception);
            const string methodName = "GetLinks";

            if (navigationServiceInstance != null)
            {
                // Act
                var getLinksMethodInfo1 = navigationServiceInstance.GetType().GetMethod(methodName);
                var getLinksMethodInfo2 = navigationServiceInstance.GetType().GetMethod(methodName);
                var result1 = getLinksMethodInfo1.GetResultMethodInfo<NavigationService, string>(navigationServiceInstance, out exception1, parametersOutRanged);
                var result2 = getLinksMethodInfo2.GetResultMethodInfo<NavigationService, string>(navigationServiceInstance, out exception2, parametersOutRanged);
                var result3 = getLinksMethodInfo1.GetResultMethodInfo<NavigationService, string>(navigationServiceInstance, out exception3, parametersInDifferentNumber);
                var result4 = getLinksMethodInfo2.GetResultMethodInfo<NavigationService, string>(navigationServiceInstance, out exception4, parametersInDifferentNumber);

                // Assert
                exception1.ShouldNotBeNull();
                exception2.ShouldNotBeNull();
                result1.ShouldBeNull();
                result2.ShouldBeNull();
                result3.ShouldBeNull();
                result4.ShouldBeNull();
                Should.Throw(() => getLinksMethodInfo1.Invoke(navigationServiceInstance, parametersOutRanged), exceptionType: exception1.GetType());
                Should.Throw(() => getLinksMethodInfo2.Invoke(navigationServiceInstance, parametersOutRanged), exceptionType: exception2.GetType());
                Should.Throw<Exception>(() => getLinksMethodInfo1.Invoke(navigationServiceInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => getLinksMethodInfo2.Invoke(navigationServiceInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => getLinksMethodInfo1.Invoke(navigationServiceInstance, parametersOutRanged));
                Should.Throw<Exception>(() => getLinksMethodInfo2.Invoke(navigationServiceInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => getLinksMethodInfo1.Invoke(navigationServiceInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => getLinksMethodInfo2.Invoke(navigationServiceInstance, parametersOutRanged));
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_NavigationService_GetLinks_Method_Call_Using_Reflection_No_Exception_Thrown_Test()
        {
            // Arrange
            Object[] parameters = {};
            Exception exception, exception1, exception2, exception3, exception4;
            var navigationServiceInstance  = Create(out exception);
            const string methodName = "GetLinks";

            if (navigationServiceInstance != null)
            {
                // Act
                var getLinksMethodInfo1 = navigationServiceInstance.GetType().GetMethod(methodName);
                var getLinksMethodInfo2 = navigationServiceInstance.GetType().GetMethod(methodName);
                var result1 = getLinksMethodInfo1.GetResultMethodInfo<NavigationService, string>(navigationServiceInstance, out exception1, parameters);
                var result2 = getLinksMethodInfo2.GetResultMethodInfo<NavigationService, string>(navigationServiceInstance, out exception2, parameters);
                var result3 = getLinksMethodInfo1.GetResultMethodInfo<NavigationService, string>(navigationServiceInstance, out exception3, parameters);
                var result4 = getLinksMethodInfo2.GetResultMethodInfo<NavigationService, string>(navigationServiceInstance, out exception4, parameters);

                // Assert
                if (exception1 == null)
                {
                    exception1.ShouldBeNull();
                    result1.ShouldBeNull();
                    result2.ShouldBeNull();
                    result3.ShouldBeNull();
                    result4.ShouldBeNull();
                    Should.NotThrow(() => getLinksMethodInfo1.Invoke(navigationServiceInstance, parameters));
                    Should.NotThrow(() => getLinksMethodInfo2.Invoke(navigationServiceInstance, parameters));
                }
            }
        }

        #endregion

        #region General Method Call : Class (NavigationService) => Method (GetMenuItems) (Return Type : DataTable) Test

        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetMenuItems_Method_6_Parameters_Method_Direct_Call_ParameterToken_3_Simple_Exploration_With_Throw_Exception_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var listId = CreateType<Guid>();
            var itemId = CreateType<int>();
            var userId = CreateType<int>();
            var diagnosticInfo = CreateType<Dictionary<string, string>>();
            Action executeAction = null;
            Exception exception = null, actionException = null;
            var navigationServiceInstance  = Create(out exception);
            var isInstanceNotNull = navigationServiceInstance != null;

            if (isInstanceNotNull)
            {
                // Act
                executeAction = () => navigationServiceInstance.GetMenuItems(siteId, webId, listId, itemId, userId, out diagnosticInfo);
                actionException = ActionAnalyzer.GetActionException(executeAction);

                // Assert
                Should.Throw(() => navigationServiceInstance.GetMenuItems(siteId, webId, listId, itemId, userId, out diagnosticInfo), exceptionType: actionException.GetType());
                Should.Throw<Exception>(() => navigationServiceInstance.GetMenuItems(siteId, webId, listId, itemId, userId, out diagnosticInfo));
                actionException.ShouldNotBeNull();
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_NavigationService_GetMenuItems_Method_6_Parameters_ParameterToken_3_Simple_Exploration_No_Exception_Thrown_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var listId = CreateType<Guid>();
            var itemId = CreateType<int>();
            var userId = CreateType<int>();
            var diagnosticInfo = CreateType<Dictionary<string, string>>();
            Action executeAction = null;
            Exception exception = null, actionException = null;
            var navigationServiceInstance  = Create(out exception);
            var isInstanceNotNull = navigationServiceInstance != null;

            if (isInstanceNotNull)
            {
                // Act
                executeAction = () => navigationServiceInstance.GetMenuItems(siteId, webId, listId, itemId, userId, out diagnosticInfo);
                actionException = ActionAnalyzer.GetActionException(executeAction);

                if (actionException == null)
                {
                    // Assert
                    actionException.ShouldBeNull();
                    Should.NotThrow(() => navigationServiceInstance.GetMenuItems(siteId, webId, listId, itemId, userId, out diagnosticInfo));
                }
            }
        }
        
        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_GetMenuItems_Method_With_6_Parameters_Call_With_Reflection_Observe_Using_Overflow_Parameters_Obvious_Not_Null_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var listId = CreateType<Guid>();
            var itemId = CreateType<int>();
            var userId = CreateType<int>();
            var diagnosticInfo = CreateType<Dictionary<string, string>>();
            Object[] parametersOutRanged = {siteId, webId, listId, itemId, userId, diagnosticInfo, null, null};
            Object[] parametersInDifferentNumber = {siteId, webId, listId, itemId, userId};
            Exception exception;
            var navigationServiceInstance  = Create(out exception);
            const string methodName = "GetMenuItems";

            if (navigationServiceInstance != null)
            {
                // Act
                var getMenuItemsMethodInfo1 = navigationServiceInstance.GetType().GetMethod(methodName);
                var getMenuItemsMethodInfo2 = navigationServiceInstance.GetType().GetMethod(methodName);
                var returnType1 = getMenuItemsMethodInfo1.ReturnType;
                var returnType2 = getMenuItemsMethodInfo2.ReturnType;

                // Assert
                parametersOutRanged.ShouldNotBeNull();
                parametersInDifferentNumber.ShouldNotBeNull();
                returnType1.ShouldNotBeNull();
                returnType2.ShouldNotBeNull();
                returnType1.ShouldBe(returnType2);
                navigationServiceInstance.ShouldNotBeNull();
                getMenuItemsMethodInfo1.ShouldNotBeNull();
                getMenuItemsMethodInfo2.ShouldNotBeNull();
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_NavigationService_GetMenuItems_Method_With_6_Call_Using_Reflection_Result_Compare_If_Not_Null_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var listId = CreateType<Guid>();
            var itemId = CreateType<int>();
            var userId = CreateType<int>();
            var diagnosticInfo = CreateType<Dictionary<string, string>>();
            Object[] parametersOutRanged = {siteId, webId, listId, itemId, userId, diagnosticInfo, null, null};
            Object[] parametersInDifferentNumber = {siteId, webId, listId, itemId, userId};
            Exception exception, exception1, exception2, exception3, exception4;
            var navigationServiceInstance  = Create(out exception);
            const string methodName = "GetMenuItems";

            if (navigationServiceInstance != null)
            {
                // Act
                var getMenuItemsMethodInfo1 = navigationServiceInstance.GetType().GetMethod(methodName);
                var getMenuItemsMethodInfo2 = navigationServiceInstance.GetType().GetMethod(methodName);
                var returnType1 = getMenuItemsMethodInfo1.ReturnType;
                var returnType2 = getMenuItemsMethodInfo2.ReturnType;
                var result1 = getMenuItemsMethodInfo1.GetResultMethodInfo<NavigationService, DataTable>(navigationServiceInstance, out exception1, parametersOutRanged);
                var result2 = getMenuItemsMethodInfo2.GetResultMethodInfo<NavigationService, DataTable>(navigationServiceInstance, out exception2, parametersOutRanged);
                var result3 = getMenuItemsMethodInfo1.GetResultMethodInfo<NavigationService, DataTable>(navigationServiceInstance, out exception3, parametersInDifferentNumber);
                var result4 = getMenuItemsMethodInfo2.GetResultMethodInfo<NavigationService, DataTable>(navigationServiceInstance, out exception4, parametersInDifferentNumber);

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
        public void AUT_NavigationService_GetMenuItems_Method_With_6_Call_Using_Reflection_Result_Validate_Null_Results_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var listId = CreateType<Guid>();
            var itemId = CreateType<int>();
            var userId = CreateType<int>();
            var diagnosticInfo = CreateType<Dictionary<string, string>>();
            Object[] parametersOutRanged = {siteId, webId, listId, itemId, userId, diagnosticInfo, null, null};
            Object[] parametersInDifferentNumber = {siteId, webId, listId, itemId, userId};
            Exception exception, exception1, exception2, exception3, exception4;
            var navigationServiceInstance  = Create(out exception);
            const string methodName = "GetMenuItems";

            if (navigationServiceInstance != null)
            {
                // Act
                var getMenuItemsMethodInfo1 = navigationServiceInstance.GetType().GetMethod(methodName);
                var getMenuItemsMethodInfo2 = navigationServiceInstance.GetType().GetMethod(methodName);
                var result1 = getMenuItemsMethodInfo1.GetResultMethodInfo<NavigationService, DataTable>(navigationServiceInstance, out exception1, parametersOutRanged);
                var result2 = getMenuItemsMethodInfo2.GetResultMethodInfo<NavigationService, DataTable>(navigationServiceInstance, out exception2, parametersOutRanged);
                var result3 = getMenuItemsMethodInfo1.GetResultMethodInfo<NavigationService, DataTable>(navigationServiceInstance, out exception3, parametersInDifferentNumber);
                var result4 = getMenuItemsMethodInfo2.GetResultMethodInfo<NavigationService, DataTable>(navigationServiceInstance, out exception4, parametersInDifferentNumber);

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
        public void AUT_NavigationService_GetMenuItems_Method_With_6_Call_Using_Reflection_Throw_Exceptions_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var listId = CreateType<Guid>();
            var itemId = CreateType<int>();
            var userId = CreateType<int>();
            var diagnosticInfo = CreateType<Dictionary<string, string>>();
            Object[] parametersOutRanged = {siteId, webId, listId, itemId, userId, diagnosticInfo, null, null};
            Object[] parametersInDifferentNumber = {siteId, webId, listId, itemId, userId};
            Exception exception, exception1, exception2, exception3, exception4;
            var navigationServiceInstance  = Create(out exception);
            const string methodName = "GetMenuItems";

            if (navigationServiceInstance != null)
            {
                // Act
                var getMenuItemsMethodInfo1 = navigationServiceInstance.GetType().GetMethod(methodName);
                var getMenuItemsMethodInfo2 = navigationServiceInstance.GetType().GetMethod(methodName);
                var result1 = getMenuItemsMethodInfo1.GetResultMethodInfo<NavigationService, DataTable>(navigationServiceInstance, out exception1, parametersOutRanged);
                var result2 = getMenuItemsMethodInfo2.GetResultMethodInfo<NavigationService, DataTable>(navigationServiceInstance, out exception2, parametersOutRanged);
                var result3 = getMenuItemsMethodInfo1.GetResultMethodInfo<NavigationService, DataTable>(navigationServiceInstance, out exception3, parametersInDifferentNumber);
                var result4 = getMenuItemsMethodInfo2.GetResultMethodInfo<NavigationService, DataTable>(navigationServiceInstance, out exception4, parametersInDifferentNumber);

                // Assert
                exception1.ShouldNotBeNull();
                exception2.ShouldNotBeNull();
                result1.ShouldBeNull();
                result2.ShouldBeNull();
                result3.ShouldBeNull();
                result4.ShouldBeNull();
                Should.Throw(() => getMenuItemsMethodInfo1.Invoke(navigationServiceInstance, parametersOutRanged), exceptionType: exception1.GetType());
                Should.Throw(() => getMenuItemsMethodInfo2.Invoke(navigationServiceInstance, parametersOutRanged), exceptionType: exception2.GetType());
                Should.Throw<Exception>(() => getMenuItemsMethodInfo1.Invoke(navigationServiceInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => getMenuItemsMethodInfo2.Invoke(navigationServiceInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => getMenuItemsMethodInfo1.Invoke(navigationServiceInstance, parametersOutRanged));
                Should.Throw<Exception>(() => getMenuItemsMethodInfo2.Invoke(navigationServiceInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => getMenuItemsMethodInfo1.Invoke(navigationServiceInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => getMenuItemsMethodInfo2.Invoke(navigationServiceInstance, parametersOutRanged));
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_NavigationService_GetMenuItems_Method_With_6_Call_Using_Reflection_No_Exception_Thrown_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var listId = CreateType<Guid>();
            var itemId = CreateType<int>();
            var userId = CreateType<int>();
            var diagnosticInfo = CreateType<Dictionary<string, string>>();
            Object[] parameters = {siteId, webId, listId, itemId, userId, diagnosticInfo};
            Exception exception, exception1, exception2, exception3, exception4;
            var navigationServiceInstance  = Create(out exception);
            const string methodName = "GetMenuItems";

            if (navigationServiceInstance != null)
            {
                // Act
                var getMenuItemsMethodInfo1 = navigationServiceInstance.GetType().GetMethod(methodName);
                var getMenuItemsMethodInfo2 = navigationServiceInstance.GetType().GetMethod(methodName);
                var result1 = getMenuItemsMethodInfo1.GetResultMethodInfo<NavigationService, DataTable>(navigationServiceInstance, out exception1, parameters);
                var result2 = getMenuItemsMethodInfo2.GetResultMethodInfo<NavigationService, DataTable>(navigationServiceInstance, out exception2, parameters);
                var result3 = getMenuItemsMethodInfo1.GetResultMethodInfo<NavigationService, DataTable>(navigationServiceInstance, out exception3, parameters);
                var result4 = getMenuItemsMethodInfo2.GetResultMethodInfo<NavigationService, DataTable>(navigationServiceInstance, out exception4, parameters);

                // Assert
                if (exception1 == null)
                {
                    exception1.ShouldBeNull();
                    result1.ShouldBeNull();
                    result2.ShouldBeNull();
                    result3.ShouldBeNull();
                    result4.ShouldBeNull();
                    Should.NotThrow(() => getMenuItemsMethodInfo1.Invoke(navigationServiceInstance, parameters));
                    Should.NotThrow(() => getMenuItemsMethodInfo2.Invoke(navigationServiceInstance, parameters));
                }
            }
        }

        #endregion

        #region General Method Call : Class (NavigationService) => Method (RemoveNavigationLink) (Return Type : void) Test

        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_RemoveNavigationLink_Method_1_Parameters_Method_Direct_Call_ParameterToken_4_Simple_Exploration_With_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;
            Exception exception = null, actionException = null;
            var navigationServiceInstance  = Create(out exception);
            var isInstanceNotNull = navigationServiceInstance != null;

            if (isInstanceNotNull)
            {
                // Act
                executeAction = () => navigationServiceInstance.RemoveNavigationLink(data);
                actionException = ActionAnalyzer.GetActionException(executeAction);

                // Assert
                Should.Throw(() => navigationServiceInstance.RemoveNavigationLink(data), exceptionType: actionException.GetType());
                Should.Throw<Exception>(() => navigationServiceInstance.RemoveNavigationLink(data));
                actionException.ShouldNotBeNull();
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_NavigationService_RemoveNavigationLink_Method_1_Parameters_ParameterToken_4_Simple_Exploration_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;
            Exception exception = null, actionException = null;
            var navigationServiceInstance  = Create(out exception);
            var isInstanceNotNull = navigationServiceInstance != null;

            if (isInstanceNotNull)
            {
                // Act
                executeAction = () => navigationServiceInstance.RemoveNavigationLink(data);
                actionException = ActionAnalyzer.GetActionException(executeAction);

                if (actionException == null)
                {
                    // Assert
                    actionException.ShouldBeNull();
                    Should.NotThrow(() => navigationServiceInstance.RemoveNavigationLink(data));
                }
            }
        }
        
        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_RemoveNavigationLink_Method_With_1_Parameters_Call_With_Reflection_Observe_Using_Overflow_Parameters_Obvious_Not_Null_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Object[] parametersOutRanged = {data, null, null};
            Object[] parametersInDifferentNumber = {};
            Exception exception;
            var navigationServiceInstance  = Create(out exception);
            const string methodName = "RemoveNavigationLink";

            if (navigationServiceInstance != null)
            {
                // Act
                var removeNavigationLinkMethodInfo1 = navigationServiceInstance.GetType().GetMethod(methodName);
                var removeNavigationLinkMethodInfo2 = navigationServiceInstance.GetType().GetMethod(methodName);
                var returnType1 = removeNavigationLinkMethodInfo1.ReturnType;
                var returnType2 = removeNavigationLinkMethodInfo2.ReturnType;

                // Assert
                parametersOutRanged.ShouldNotBeNull();
                parametersInDifferentNumber.ShouldNotBeNull();
                returnType1.ShouldNotBeNull();
                returnType2.ShouldNotBeNull();
                returnType1.ShouldBe(returnType2);
                navigationServiceInstance.ShouldNotBeNull();
                removeNavigationLinkMethodInfo1.ShouldNotBeNull();
                removeNavigationLinkMethodInfo2.ShouldNotBeNull();
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_RemoveNavigationLink_Method_With_1_Call_Using_Reflection_Throw_Exceptions_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Object[] parametersOutRanged = {data, null, null};
            Object[] parametersInDifferentNumber = {};
            Exception exception, exception1, exception2, exception3, exception4;
            var navigationServiceInstance  = Create(out exception);
            const string methodName = "RemoveNavigationLink";

            if (navigationServiceInstance != null)
            {
                // Act
                var removeNavigationLinkMethodInfo1 = navigationServiceInstance.GetType().GetMethod(methodName);
                var removeNavigationLinkMethodInfo2 = navigationServiceInstance.GetType().GetMethod(methodName);
                removeNavigationLinkMethodInfo1.InvokeMethodInfo(navigationServiceInstance, out exception1, parametersOutRanged);
                removeNavigationLinkMethodInfo2.InvokeMethodInfo(navigationServiceInstance, out exception2, parametersOutRanged);
                removeNavigationLinkMethodInfo1.InvokeMethodInfo(navigationServiceInstance, out exception3, parametersInDifferentNumber);
                removeNavigationLinkMethodInfo2.InvokeMethodInfo(navigationServiceInstance, out exception4, parametersInDifferentNumber);

                // Assert
                exception1.ShouldNotBeNull();
                exception2.ShouldNotBeNull();
                Should.Throw(() => removeNavigationLinkMethodInfo1.Invoke(navigationServiceInstance, parametersOutRanged), exceptionType: exception1.GetType());
                Should.Throw(() => removeNavigationLinkMethodInfo2.Invoke(navigationServiceInstance, parametersOutRanged), exceptionType: exception2.GetType());
                Should.Throw<Exception>(() => removeNavigationLinkMethodInfo1.Invoke(navigationServiceInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => removeNavigationLinkMethodInfo2.Invoke(navigationServiceInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => removeNavigationLinkMethodInfo1.Invoke(navigationServiceInstance, parametersOutRanged));
                Should.Throw<Exception>(() => removeNavigationLinkMethodInfo2.Invoke(navigationServiceInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => removeNavigationLinkMethodInfo1.Invoke(navigationServiceInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => removeNavigationLinkMethodInfo2.Invoke(navigationServiceInstance, parametersOutRanged));
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_NavigationService_RemoveNavigationLink_Method_With_1_Call_Using_Reflection_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Object[] parameters = {data};
            Exception exception, exception1, exception2, exception3, exception4;
            var navigationServiceInstance  = Create(out exception);
            const string methodName = "RemoveNavigationLink";

            if (navigationServiceInstance != null)
            {
                // Act
                var removeNavigationLinkMethodInfo1 = navigationServiceInstance.GetType().GetMethod(methodName);
                var removeNavigationLinkMethodInfo2 = navigationServiceInstance.GetType().GetMethod(methodName);
                removeNavigationLinkMethodInfo1.InvokeMethodInfo(navigationServiceInstance, out exception1, parameters);
                removeNavigationLinkMethodInfo2.InvokeMethodInfo(navigationServiceInstance, out exception2, parameters);
                removeNavigationLinkMethodInfo1.InvokeMethodInfo(navigationServiceInstance, out exception3, parameters);
                removeNavigationLinkMethodInfo2.InvokeMethodInfo(navigationServiceInstance, out exception4, parameters);

                // Assert
                if (exception1 == null)
                {
                    exception1.ShouldBeNull();
                    Should.NotThrow(() => removeNavigationLinkMethodInfo1.Invoke(navigationServiceInstance, parameters));
                    Should.NotThrow(() => removeNavigationLinkMethodInfo2.Invoke(navigationServiceInstance, parameters));
                }
            }
        }

        #endregion

        #region General Method Call : Class (NavigationService) => Method (ReorderLinks) (Return Type : void) Test
        
        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_NavigationService_ReorderLinks_Method_1_Parameters_ParameterToken_5_Simple_Exploration_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;
            Exception exception = null, actionException = null;
            var navigationServiceInstance  = Create(out exception);
            var isInstanceNotNull = navigationServiceInstance != null;

            if (isInstanceNotNull)
            {
                // Act
                executeAction = () => navigationServiceInstance.ReorderLinks(data);
                actionException = ActionAnalyzer.GetActionException(executeAction);

                if (actionException == null)
                {
                    // Assert
                    actionException.ShouldBeNull();
                    Should.NotThrow(() => navigationServiceInstance.ReorderLinks(data));
                }
            }
        }
        
        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_ReorderLinks_Method_With_1_Parameters_Call_With_Reflection_MethodExploration_By_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Object[] parametersOfReorderLinks = {data};
            Exception exception = null, invokeException = null;
            var navigationServiceInstance  = Create(out exception);
            const string methodName = "ReorderLinks";

            if (navigationServiceInstance != null)
            {
                // Act
                var reorderLinksMethodInfo1 = navigationServiceInstance.GetType().GetMethod(methodName);
                var reorderLinksMethodInfo2 = navigationServiceInstance.GetType().GetMethod(methodName);

                // Assert
                invokeException.ShouldBeNull();
                Should.NotThrow(() => reorderLinksMethodInfo1.Invoke(navigationServiceInstance, parametersOfReorderLinks));
                Should.NotThrow(() => reorderLinksMethodInfo2.Invoke(navigationServiceInstance, parametersOfReorderLinks));
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_ReorderLinks_Method_With_1_Parameters_Call_With_Reflection_Observe_Using_Overflow_Parameters_Obvious_Not_Null_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Object[] parametersOutRanged = {data, null, null};
            Object[] parametersInDifferentNumber = {};
            Exception exception;
            var navigationServiceInstance  = Create(out exception);
            const string methodName = "ReorderLinks";

            if (navigationServiceInstance != null)
            {
                // Act
                var reorderLinksMethodInfo1 = navigationServiceInstance.GetType().GetMethod(methodName);
                var reorderLinksMethodInfo2 = navigationServiceInstance.GetType().GetMethod(methodName);
                var returnType1 = reorderLinksMethodInfo1.ReturnType;
                var returnType2 = reorderLinksMethodInfo2.ReturnType;

                // Assert
                parametersOutRanged.ShouldNotBeNull();
                parametersInDifferentNumber.ShouldNotBeNull();
                returnType1.ShouldNotBeNull();
                returnType2.ShouldNotBeNull();
                returnType1.ShouldBe(returnType2);
                navigationServiceInstance.ShouldNotBeNull();
                reorderLinksMethodInfo1.ShouldNotBeNull();
                reorderLinksMethodInfo2.ShouldNotBeNull();
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        public void AUT_NavigationService_ReorderLinks_Method_With_1_Call_Using_Reflection_Throw_Exceptions_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Object[] parametersOutRanged = {data, null, null};
            Object[] parametersInDifferentNumber = {};
            Exception exception, exception1, exception2, exception3, exception4;
            var navigationServiceInstance  = Create(out exception);
            const string methodName = "ReorderLinks";

            if (navigationServiceInstance != null)
            {
                // Act
                var reorderLinksMethodInfo1 = navigationServiceInstance.GetType().GetMethod(methodName);
                var reorderLinksMethodInfo2 = navigationServiceInstance.GetType().GetMethod(methodName);
                reorderLinksMethodInfo1.InvokeMethodInfo(navigationServiceInstance, out exception1, parametersOutRanged);
                reorderLinksMethodInfo2.InvokeMethodInfo(navigationServiceInstance, out exception2, parametersOutRanged);
                reorderLinksMethodInfo1.InvokeMethodInfo(navigationServiceInstance, out exception3, parametersInDifferentNumber);
                reorderLinksMethodInfo2.InvokeMethodInfo(navigationServiceInstance, out exception4, parametersInDifferentNumber);

                // Assert
                exception1.ShouldNotBeNull();
                exception2.ShouldNotBeNull();
                Should.Throw(() => reorderLinksMethodInfo1.Invoke(navigationServiceInstance, parametersOutRanged), exceptionType: exception1.GetType());
                Should.Throw(() => reorderLinksMethodInfo2.Invoke(navigationServiceInstance, parametersOutRanged), exceptionType: exception2.GetType());
                Should.Throw<Exception>(() => reorderLinksMethodInfo1.Invoke(navigationServiceInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => reorderLinksMethodInfo2.Invoke(navigationServiceInstance, parametersInDifferentNumber));
                Should.Throw<Exception>(() => reorderLinksMethodInfo1.Invoke(navigationServiceInstance, parametersOutRanged));
                Should.Throw<Exception>(() => reorderLinksMethodInfo2.Invoke(navigationServiceInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => reorderLinksMethodInfo1.Invoke(navigationServiceInstance, parametersOutRanged));
                Should.Throw<TargetParameterCountException>(() => reorderLinksMethodInfo2.Invoke(navigationServiceInstance, parametersOutRanged));
            }
        }

        [Test]
        [Category("AUT MethodCallTest")]
        [ExcludeFromCodeCoverage]
        public void AUT_NavigationService_ReorderLinks_Method_With_1_Call_Using_Reflection_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Object[] parameters = {data};
            Exception exception, exception1, exception2, exception3, exception4;
            var navigationServiceInstance  = Create(out exception);
            const string methodName = "ReorderLinks";

            if (navigationServiceInstance != null)
            {
                // Act
                var reorderLinksMethodInfo1 = navigationServiceInstance.GetType().GetMethod(methodName);
                var reorderLinksMethodInfo2 = navigationServiceInstance.GetType().GetMethod(methodName);
                reorderLinksMethodInfo1.InvokeMethodInfo(navigationServiceInstance, out exception1, parameters);
                reorderLinksMethodInfo2.InvokeMethodInfo(navigationServiceInstance, out exception2, parameters);
                reorderLinksMethodInfo1.InvokeMethodInfo(navigationServiceInstance, out exception3, parameters);
                reorderLinksMethodInfo2.InvokeMethodInfo(navigationServiceInstance, out exception4, parameters);

                // Assert
                if (exception1 == null)
                {
                    exception1.ShouldBeNull();
                    Should.NotThrow(() => reorderLinksMethodInfo1.Invoke(navigationServiceInstance, parameters));
                    Should.NotThrow(() => reorderLinksMethodInfo2.Invoke(navigationServiceInstance, parameters));
                }
            }
        }

        #endregion

        #endregion

        #region Category : Initializer

        #region General Initializer : Class (NavigationService) Initializer

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
        ///    Create <see cref="NavigationService" /> class.
        /// </summary>
        /// <returns>Returns a newly created <see cref="NavigationService" />.</returns>
        [ExcludeFromCodeCoverage]
        private NavigationService Create(bool useFixtureAtFirst = false)
        {
            Exception createException;
            var parameters = CreateOrGetPrameters();
            return Create(createException: out createException, useFixtureAtFirst: useFixtureAtFirst, parameters: parameters);
        }

        /// <summary>
        ///    Create <see cref="NavigationService" /> class.
        /// </summary>
        /// <returns>Returns a newly created <see cref="NavigationService" />.</returns>
        [ExcludeFromCodeCoverage]
        private NavigationService Create(out Exception createException, object[] parameters = null, bool useFixtureAtFirst = false)
        {
            return CreateAnalyzer.Create<NavigationService>(fixture: Fixture, exception: out createException, useFixtureAtFirst: useFixtureAtFirst, parameters: parameters);
        }

        /// <summary>
        ///    Create Multiple of <see cref="NavigationService" /> classes depending on the given number.
        /// </summary>
        /// <returns>Returns a newly created <see cref="NavigationService" />.</returns>
        private NavigationService[] CreateMany(out Exception[] createExceptions, out bool isResultsAreNull, int number = 6, object[] parameters = null)
        {
            return CreateAnalyzer.CreateMany<NavigationService>(number: number, fixture: Fixture, exceptions: out createExceptions, isResultsAreNull: out isResultsAreNull, parameters: parameters);
        }

        /// <summary>
        ///    Create dynamic parameters for <see cref="NavigationService" /> class using AutoFixture.
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

        #region Explore Class for Coverage Gain : Class (NavigationService)

        /// <summary>
        ///     Regular class (<see cref="NavigationService" />) non-public fields explore and verify for coverage gain.
        /// </summary>
        [Test]
        [Category("AUT Initializer")]
        public void AUT_RegularClass_NavigationService_NonPublic_Fields_Explore_Verify()
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyNonPublicFields<NavigationService>(Fixture);
        }

        /// <summary>
        ///     Regular class (<see cref="NavigationService" />) non-public properties explore and verify for coverage gain.
        /// </summary>
        [Test]
        [Category("AUT Initializer")]
        public void AUT_RegularClass_NavigationService_NonPublic_Properties_Explore_Verify()
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyNonPublicProperties<NavigationService>(Fixture);
        }

        /// <summary>
        ///     Regular class (<see cref="NavigationService" />) non-public methods explore and verify for coverage gain.
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
        public void AUT_RegularClass_NavigationService_NonPublic_Methods_Explore_Verify(int pageNumber = 1, int perPageMethodsToVerify = 3)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyNonPublicMethods<NavigationService>(Fixture, pageNumber, perPageMethodsToVerify);
        }

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (NavigationService) with Parameter Test

        [Test]
        [Category("AUT Constructor")]
        public void AUT_Constructor_NavigationService_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var providers = CreateType<IEnumerable<string>>();
            var spWeb = CreateType<SPWeb>();
            NavigationService instance = null;
            Exception creationException = null;
            Action createAction = ()=> instance = new NavigationService(providers, spWeb);

            // Act
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            if (creationException == null)
            {
                instance.ShouldNotBeNull();
                instance.ShouldBeOfType<NavigationService>();
            }
        }

        [Test]
        [Category("AUT Constructor")]
        public void AUT_Constructor_NavigationService_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var providers = CreateType<IEnumerable<string>>();
            var spWeb = CreateType<SPWeb>();
            NavigationService instance = null;
            Exception creationException = null;
            Action createAction = ()=> instance = new NavigationService(providers, spWeb);

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
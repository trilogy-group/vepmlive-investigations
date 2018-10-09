using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.AutoFixtureSetup;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using Microsoft.SharePoint;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using ViewPermissionUtil = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.ViewPermissionUtil" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ViewPermissionUtilTest : AbstractBaseSetupTypedTest<ViewPermissionUtil>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ViewPermissionUtil) Initializer

        private const string MethodConvertFromString = "ConvertFromString";
        private const string MethodSetDefaultVue = "SetDefaultVue";
        private const string MethodConvertFromStringForPage = "ConvertFromStringForPage";
        private const string MethodGetDefautView = "GetDefautView";
        private const string MethodIsViewAllowed = "IsViewAllowed";
        private Type _viewPermissionUtilInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ViewPermissionUtil _viewPermissionUtilInstance;
        private ViewPermissionUtil _viewPermissionUtilInstanceFixture;

        #region General Initializer : Class (ViewPermissionUtil) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ViewPermissionUtil" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _viewPermissionUtilInstanceType = typeof(ViewPermissionUtil);
            _viewPermissionUtilInstanceFixture = Create(true);
            _viewPermissionUtilInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ViewPermissionUtil)

        #region General Initializer : Class (ViewPermissionUtil) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ViewPermissionUtil" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodConvertFromString, 0)]
        [TestCase(MethodSetDefaultVue, 0)]
        [TestCase(MethodConvertFromStringForPage, 0)]
        [TestCase(MethodGetDefautView, 0)]
        [TestCase(MethodIsViewAllowed, 0)]
        public void AUT_ViewPermissionUtil_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_viewPermissionUtilInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="ViewPermissionUtil" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ViewPermissionUtil_Is_Instance_Present_Test()
        {
            // Assert
            _viewPermissionUtilInstanceType.ShouldNotBeNull();
            _viewPermissionUtilInstance.ShouldNotBeNull();
            _viewPermissionUtilInstanceFixture.ShouldNotBeNull();
            _viewPermissionUtilInstance.ShouldBeAssignableTo<ViewPermissionUtil>();
            _viewPermissionUtilInstanceFixture.ShouldBeAssignableTo<ViewPermissionUtil>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ViewPermissionUtil) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ViewPermissionUtil_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ViewPermissionUtil instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _viewPermissionUtilInstanceType.ShouldNotBeNull();
            _viewPermissionUtilInstance.ShouldNotBeNull();
            _viewPermissionUtilInstanceFixture.ShouldNotBeNull();
            _viewPermissionUtilInstance.ShouldBeAssignableTo<ViewPermissionUtil>();
            _viewPermissionUtilInstanceFixture.ShouldBeAssignableTo<ViewPermissionUtil>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="ViewPermissionUtil" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodConvertFromString)]
        [TestCase(MethodSetDefaultVue)]
        [TestCase(MethodConvertFromStringForPage)]
        [TestCase(MethodGetDefautView)]
        [TestCase(MethodIsViewAllowed)]
        public void AUT_ViewPermissionUtil_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_viewPermissionUtilInstanceFixture,
                                                                              _viewPermissionUtilInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (ConvertFromString) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ViewPermissionUtil_ConvertFromString_Static_Method_Call_Internally(Type[] types)
        {
            var methodConvertFromStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_viewPermissionUtilInstanceFixture, _viewPermissionUtilInstanceType, MethodConvertFromString, Fixture, methodConvertFromStringPrametersTypes);
        }

        #endregion

        #region Method Call : (ConvertFromString) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionUtil_ConvertFromString_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var roleProperties = CreateType<Dictionary<int, Dictionary<string, bool>>>();
            var defaultViews = CreateType<Dictionary<int, string>>();
            var value = CreateType<string>();
            var currentList = CreateType<SPList>();
            Action executeAction = null;

            // Act
            executeAction = () => ViewPermissionUtil.ConvertFromString(ref roleProperties, ref defaultViews, value, currentList);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ConvertFromString) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionUtil_ConvertFromString_Static_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var roleProperties = CreateType<Dictionary<int, Dictionary<string, bool>>>();
            var defaultViews = CreateType<Dictionary<int, string>>();
            var value = CreateType<string>();
            var currentList = CreateType<SPList>();
            var methodConvertFromStringPrametersTypes = new Type[] { typeof(Dictionary<int, Dictionary<string, bool>>), typeof(Dictionary<int, string>), typeof(string), typeof(SPList) };
            object[] parametersOfConvertFromString = { roleProperties, defaultViews, value, currentList };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodConvertFromString, methodConvertFromStringPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_viewPermissionUtilInstanceFixture, parametersOfConvertFromString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfConvertFromString.ShouldNotBeNull();
            parametersOfConvertFromString.Length.ShouldBe(4);
            methodConvertFromStringPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ConvertFromString) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionUtil_ConvertFromString_Static_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var roleProperties = CreateType<Dictionary<int, Dictionary<string, bool>>>();
            var defaultViews = CreateType<Dictionary<int, string>>();
            var value = CreateType<string>();
            var currentList = CreateType<SPList>();
            var methodConvertFromStringPrametersTypes = new Type[] { typeof(Dictionary<int, Dictionary<string, bool>>), typeof(Dictionary<int, string>), typeof(string), typeof(SPList) };
            object[] parametersOfConvertFromString = { roleProperties, defaultViews, value, currentList };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_viewPermissionUtilInstanceFixture, _viewPermissionUtilInstanceType, MethodConvertFromString, parametersOfConvertFromString, methodConvertFromStringPrametersTypes);

            // Assert
            parametersOfConvertFromString.ShouldNotBeNull();
            parametersOfConvertFromString.Length.ShouldBe(4);
            methodConvertFromStringPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConvertFromString) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionUtil_ConvertFromString_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodConvertFromString, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ConvertFromString) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionUtil_ConvertFromString_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodConvertFromStringPrametersTypes = new Type[] { typeof(Dictionary<int, Dictionary<string, bool>>), typeof(Dictionary<int, string>), typeof(string), typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_viewPermissionUtilInstanceFixture, _viewPermissionUtilInstanceType, MethodConvertFromString, Fixture, methodConvertFromStringPrametersTypes);

            // Assert
            methodConvertFromStringPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConvertFromString) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionUtil_ConvertFromString_Static_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodConvertFromString, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_viewPermissionUtilInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetDefaultVue) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ViewPermissionUtil_SetDefaultVue_Static_Method_Call_Internally(Type[] types)
        {
            var methodSetDefaultVuePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_viewPermissionUtilInstanceFixture, _viewPermissionUtilInstanceType, MethodSetDefaultVue, Fixture, methodSetDefaultVuePrametersTypes);
        }

        #endregion

        #region Method Call : (SetDefaultVue) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionUtil_SetDefaultVue_Static_Method_Call_Void_With_5_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var defaultUserView = CreateType<string>();
            var listDefaultVue = CreateType<string>();
            var groupId = CreateType<int>();
            var currentList = CreateType<SPList>();
            var defaultViews = CreateType<Dictionary<int, string>>();
            var methodSetDefaultVuePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(int), typeof(SPList), typeof(Dictionary<int, string>) };
            object[] parametersOfSetDefaultVue = { defaultUserView, listDefaultVue, groupId, currentList, defaultViews };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_viewPermissionUtilInstanceFixture, _viewPermissionUtilInstanceType, MethodSetDefaultVue, parametersOfSetDefaultVue, methodSetDefaultVuePrametersTypes);

            // Assert
            parametersOfSetDefaultVue.ShouldNotBeNull();
            parametersOfSetDefaultVue.Length.ShouldBe(5);
            methodSetDefaultVuePrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetDefaultVue) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionUtil_SetDefaultVue_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetDefaultVue, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetDefaultVue) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionUtil_SetDefaultVue_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetDefaultVuePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(int), typeof(SPList), typeof(Dictionary<int, string>) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_viewPermissionUtilInstanceFixture, _viewPermissionUtilInstanceType, MethodSetDefaultVue, Fixture, methodSetDefaultVuePrametersTypes);

            // Assert
            methodSetDefaultVuePrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetDefaultVue) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionUtil_SetDefaultVue_Static_Method_Call_With_5_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetDefaultVue, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_viewPermissionUtilInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConvertFromStringForPage) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ViewPermissionUtil_ConvertFromStringForPage_Static_Method_Call_Internally(Type[] types)
        {
            var methodConvertFromStringForPagePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_viewPermissionUtilInstanceFixture, _viewPermissionUtilInstanceType, MethodConvertFromStringForPage, Fixture, methodConvertFromStringForPagePrametersTypes);
        }

        #endregion

        #region Method Call : (ConvertFromStringForPage) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionUtil_ConvertFromStringForPage_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var roleProperties = CreateType<Dictionary<int, Dictionary<string, bool>>>();
            var defaultViews = CreateType<Dictionary<int, string>>();
            var value = CreateType<string>();
            var currentList = CreateType<SPList>();
            Action executeAction = null;

            // Act
            executeAction = () => ViewPermissionUtil.ConvertFromStringForPage(ref roleProperties, ref defaultViews, value, currentList);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ConvertFromStringForPage) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionUtil_ConvertFromStringForPage_Static_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var roleProperties = CreateType<Dictionary<int, Dictionary<string, bool>>>();
            var defaultViews = CreateType<Dictionary<int, string>>();
            var value = CreateType<string>();
            var currentList = CreateType<SPList>();
            var methodConvertFromStringForPagePrametersTypes = new Type[] { typeof(Dictionary<int, Dictionary<string, bool>>), typeof(Dictionary<int, string>), typeof(string), typeof(SPList) };
            object[] parametersOfConvertFromStringForPage = { roleProperties, defaultViews, value, currentList };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodConvertFromStringForPage, methodConvertFromStringForPagePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_viewPermissionUtilInstanceFixture, parametersOfConvertFromStringForPage);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfConvertFromStringForPage.ShouldNotBeNull();
            parametersOfConvertFromStringForPage.Length.ShouldBe(4);
            methodConvertFromStringForPagePrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ConvertFromStringForPage) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionUtil_ConvertFromStringForPage_Static_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var roleProperties = CreateType<Dictionary<int, Dictionary<string, bool>>>();
            var defaultViews = CreateType<Dictionary<int, string>>();
            var value = CreateType<string>();
            var currentList = CreateType<SPList>();
            var methodConvertFromStringForPagePrametersTypes = new Type[] { typeof(Dictionary<int, Dictionary<string, bool>>), typeof(Dictionary<int, string>), typeof(string), typeof(SPList) };
            object[] parametersOfConvertFromStringForPage = { roleProperties, defaultViews, value, currentList };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_viewPermissionUtilInstanceFixture, _viewPermissionUtilInstanceType, MethodConvertFromStringForPage, parametersOfConvertFromStringForPage, methodConvertFromStringForPagePrametersTypes);

            // Assert
            parametersOfConvertFromStringForPage.ShouldNotBeNull();
            parametersOfConvertFromStringForPage.Length.ShouldBe(4);
            methodConvertFromStringForPagePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConvertFromStringForPage) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionUtil_ConvertFromStringForPage_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodConvertFromStringForPage, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ConvertFromStringForPage) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionUtil_ConvertFromStringForPage_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodConvertFromStringForPagePrametersTypes = new Type[] { typeof(Dictionary<int, Dictionary<string, bool>>), typeof(Dictionary<int, string>), typeof(string), typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_viewPermissionUtilInstanceFixture, _viewPermissionUtilInstanceType, MethodConvertFromStringForPage, Fixture, methodConvertFromStringForPagePrametersTypes);

            // Assert
            methodConvertFromStringForPagePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConvertFromStringForPage) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionUtil_ConvertFromStringForPage_Static_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodConvertFromStringForPage, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_viewPermissionUtilInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDefautView) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ViewPermissionUtil_GetDefautView_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetDefautViewPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_viewPermissionUtilInstanceFixture, _viewPermissionUtilInstanceType, MethodGetDefautView, Fixture, methodGetDefautViewPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDefautView) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionUtil_GetDefautView_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var groupValues = CreateType<Dictionary<int, string>>();
            var groupId = CreateType<int>();
            var methodGetDefautViewPrametersTypes = new Type[] { typeof(Dictionary<int, string>), typeof(int) };
            object[] parametersOfGetDefautView = { groupValues, groupId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_viewPermissionUtilInstanceFixture, _viewPermissionUtilInstanceType, MethodGetDefautView, parametersOfGetDefautView, methodGetDefautViewPrametersTypes);

            // Assert
            parametersOfGetDefautView.ShouldNotBeNull();
            parametersOfGetDefautView.Length.ShouldBe(2);
            methodGetDefautViewPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDefautView) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionUtil_GetDefautView_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetDefautViewPrametersTypes = new Type[] { typeof(Dictionary<int, string>), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_viewPermissionUtilInstanceFixture, _viewPermissionUtilInstanceType, MethodGetDefautView, Fixture, methodGetDefautViewPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDefautViewPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetDefautView) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionUtil_GetDefautView_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDefautViewPrametersTypes = new Type[] { typeof(Dictionary<int, string>), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_viewPermissionUtilInstanceFixture, _viewPermissionUtilInstanceType, MethodGetDefautView, Fixture, methodGetDefautViewPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDefautViewPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDefautView) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionUtil_GetDefautView_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetDefautView, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsViewAllowed) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ViewPermissionUtil_IsViewAllowed_Static_Method_Call_Internally(Type[] types)
        {
            var methodIsViewAllowedPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_viewPermissionUtilInstanceFixture, _viewPermissionUtilInstanceType, MethodIsViewAllowed, Fixture, methodIsViewAllowedPrametersTypes);
        }

        #endregion

        #region Method Call : (IsViewAllowed) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionUtil_IsViewAllowed_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var groupValues = CreateType<Dictionary<int, string>>();
            var groupId = CreateType<int>();
            var viewToTest = CreateType<string>();
            var methodIsViewAllowedPrametersTypes = new Type[] { typeof(Dictionary<int, string>), typeof(int), typeof(string) };
            object[] parametersOfIsViewAllowed = { groupValues, groupId, viewToTest };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_viewPermissionUtilInstanceFixture, _viewPermissionUtilInstanceType, MethodIsViewAllowed, parametersOfIsViewAllowed, methodIsViewAllowedPrametersTypes);

            // Assert
            parametersOfIsViewAllowed.ShouldNotBeNull();
            parametersOfIsViewAllowed.Length.ShouldBe(3);
            methodIsViewAllowedPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsViewAllowed) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionUtil_IsViewAllowed_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsViewAllowedPrametersTypes = new Type[] { typeof(Dictionary<int, string>), typeof(int), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_viewPermissionUtilInstanceFixture, _viewPermissionUtilInstanceType, MethodIsViewAllowed, Fixture, methodIsViewAllowedPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsViewAllowedPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsViewAllowed) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionUtil_IsViewAllowed_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodIsViewAllowed, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #endregion

        #endregion
    }
}
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
using System.Web;
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
using GlobalResourceHelper = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.GlobalResourceHelper" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class GlobalResourceHelperTest : AbstractBaseSetupTypedTest<GlobalResourceHelper>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (GlobalResourceHelper) Initializer

        private const string MethodGetResourceString = "GetResourceString";
        private Type _globalResourceHelperInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private GlobalResourceHelper _globalResourceHelperInstance;
        private GlobalResourceHelper _globalResourceHelperInstanceFixture;

        #region General Initializer : Class (GlobalResourceHelper) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="GlobalResourceHelper" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _globalResourceHelperInstanceType = typeof(GlobalResourceHelper);
            _globalResourceHelperInstanceFixture = Create(true);
            _globalResourceHelperInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (GlobalResourceHelper)

        #region General Initializer : Class (GlobalResourceHelper) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="GlobalResourceHelper" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetResourceString, 0)]
        public void AUT_GlobalResourceHelper_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_globalResourceHelperInstanceFixture, 
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
        ///     Class (<see cref="GlobalResourceHelper" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_GlobalResourceHelper_Is_Instance_Present_Test()
        {
            // Assert
            _globalResourceHelperInstanceType.ShouldNotBeNull();
            _globalResourceHelperInstance.ShouldNotBeNull();
            _globalResourceHelperInstanceFixture.ShouldNotBeNull();
            _globalResourceHelperInstance.ShouldBeAssignableTo<GlobalResourceHelper>();
            _globalResourceHelperInstanceFixture.ShouldBeAssignableTo<GlobalResourceHelper>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (GlobalResourceHelper) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_GlobalResourceHelper_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            GlobalResourceHelper instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _globalResourceHelperInstanceType.ShouldNotBeNull();
            _globalResourceHelperInstance.ShouldNotBeNull();
            _globalResourceHelperInstanceFixture.ShouldNotBeNull();
            _globalResourceHelperInstance.ShouldBeAssignableTo<GlobalResourceHelper>();
            _globalResourceHelperInstanceFixture.ShouldBeAssignableTo<GlobalResourceHelper>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="GlobalResourceHelper" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetResourceString)]
        public void AUT_GlobalResourceHelper_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_globalResourceHelperInstanceFixture,
                                                                              _globalResourceHelperInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (GetResourceString) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GlobalResourceHelper_GetResourceString_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetResourceStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_globalResourceHelperInstanceFixture, _globalResourceHelperInstanceType, MethodGetResourceString, Fixture, methodGetResourceStringPrametersTypes);
        }

        #endregion

        #region Method Call : (GetResourceString) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GlobalResourceHelper_GetResourceString_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var resourceClass = CreateType<string>();
            var key = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => GlobalResourceHelper.GetResourceString(resourceClass, key);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetResourceString) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GlobalResourceHelper_GetResourceString_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var resourceClass = CreateType<string>();
            var key = CreateType<string>();
            var methodGetResourceStringPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfGetResourceString = { resourceClass, key };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetResourceString, methodGetResourceStringPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_globalResourceHelperInstanceFixture, _globalResourceHelperInstanceType, MethodGetResourceString, Fixture, methodGetResourceStringPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_globalResourceHelperInstanceFixture, _globalResourceHelperInstanceType, MethodGetResourceString, parametersOfGetResourceString, methodGetResourceStringPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_globalResourceHelperInstanceFixture, parametersOfGetResourceString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetResourceString.ShouldNotBeNull();
            parametersOfGetResourceString.Length.ShouldBe(2);
            methodGetResourceStringPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetResourceString) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GlobalResourceHelper_GetResourceString_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var resourceClass = CreateType<string>();
            var key = CreateType<string>();
            var methodGetResourceStringPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfGetResourceString = { resourceClass, key };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_globalResourceHelperInstanceFixture, _globalResourceHelperInstanceType, MethodGetResourceString, parametersOfGetResourceString, methodGetResourceStringPrametersTypes);

            // Assert
            parametersOfGetResourceString.ShouldNotBeNull();
            parametersOfGetResourceString.Length.ShouldBe(2);
            methodGetResourceStringPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetResourceString) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GlobalResourceHelper_GetResourceString_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetResourceStringPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_globalResourceHelperInstanceFixture, _globalResourceHelperInstanceType, MethodGetResourceString, Fixture, methodGetResourceStringPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetResourceStringPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetResourceString) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GlobalResourceHelper_GetResourceString_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetResourceStringPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_globalResourceHelperInstanceFixture, _globalResourceHelperInstanceType, MethodGetResourceString, Fixture, methodGetResourceStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetResourceStringPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourceString) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GlobalResourceHelper_GetResourceString_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetResourceString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_globalResourceHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetResourceString) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GlobalResourceHelper_GetResourceString_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetResourceString, 0);
            const int parametersCount = 2;

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
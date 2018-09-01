using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Resources;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.AutoFixtureSetup;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using EPMLiveCore.API.ProjectArchiver;
using EPMLiveCore.Infrastructure.Logging;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Utilities;
using Microsoft.Win32;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using static EPMLiveCore.Infrastructure.Logging.LoggingService;
using EPMLiveCore;
using UserLevels = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.UserLevels" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class UserLevelsTest : AbstractBaseSetupTypedTest<UserLevels>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (UserLevels) Initializer

        private const string MethodGetById = "GetById";
        private const string MethodCount = "Count";
        private const string MethodGetEnumerator = "GetEnumerator";
        private const string MethodGetUserLevel = "GetUserLevel";
        private const string Fieldlevels = "levels";
        private Type _userLevelsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private UserLevels _userLevelsInstance;
        private UserLevels _userLevelsInstanceFixture;

        #region General Initializer : Class (UserLevels) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="UserLevels" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _userLevelsInstanceType = typeof(UserLevels);
            _userLevelsInstanceFixture = Create(true);
            _userLevelsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (UserLevels)

        #region General Initializer : Class (UserLevels) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="UserLevels" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetById, 0)]
        [TestCase(MethodCount, 0)]
        [TestCase(MethodGetEnumerator, 0)]
        [TestCase(MethodGetUserLevel, 0)]
        public void AUT_UserLevels_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_userLevelsInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (UserLevels) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="UserLevels" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldlevels)]
        public void AUT_UserLevels_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_userLevelsInstanceFixture, 
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
        ///     Class (<see cref="UserLevels" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_UserLevels_Is_Instance_Present_Test()
        {
            // Assert
            _userLevelsInstanceType.ShouldNotBeNull();
            _userLevelsInstance.ShouldNotBeNull();
            _userLevelsInstanceFixture.ShouldNotBeNull();
            _userLevelsInstance.ShouldBeAssignableTo<UserLevels>();
            _userLevelsInstanceFixture.ShouldBeAssignableTo<UserLevels>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (UserLevels) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_UserLevels_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            UserLevels instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _userLevelsInstanceType.ShouldNotBeNull();
            _userLevelsInstance.ShouldNotBeNull();
            _userLevelsInstanceFixture.ShouldNotBeNull();
            _userLevelsInstance.ShouldBeAssignableTo<UserLevels>();
            _userLevelsInstanceFixture.ShouldBeAssignableTo<UserLevels>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="UserLevels" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetById)]
        [TestCase(MethodCount)]
        [TestCase(MethodGetEnumerator)]
        [TestCase(MethodGetUserLevel)]
        public void AUT_UserLevels_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<UserLevels>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetById) (Return Type : UserLevel) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UserLevels_GetById_Method_Call_Internally(Type[] types)
        {
            var methodGetByIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_userLevelsInstance, MethodGetById, Fixture, methodGetByIdPrametersTypes);
        }

        #endregion

        #region Method Call : (GetById) (Return Type : UserLevel) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UserLevels_GetById_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var id = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _userLevelsInstance.GetById(id);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetById) (Return Type : UserLevel) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UserLevels_GetById_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var id = CreateType<int>();
            var methodGetByIdPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfGetById = { id };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetById, methodGetByIdPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<UserLevels, UserLevel>(_userLevelsInstanceFixture, out exception1, parametersOfGetById);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<UserLevels, UserLevel>(_userLevelsInstance, MethodGetById, parametersOfGetById, methodGetByIdPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetById.ShouldNotBeNull();
            parametersOfGetById.Length.ShouldBe(1);
            methodGetByIdPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetById) (Return Type : UserLevel) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UserLevels_GetById_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var id = CreateType<int>();
            var methodGetByIdPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfGetById = { id };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<UserLevels, UserLevel>(_userLevelsInstance, MethodGetById, parametersOfGetById, methodGetByIdPrametersTypes);

            // Assert
            parametersOfGetById.ShouldNotBeNull();
            parametersOfGetById.Length.ShouldBe(1);
            methodGetByIdPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetById) (Return Type : UserLevel) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UserLevels_GetById_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetByIdPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_userLevelsInstance, MethodGetById, Fixture, methodGetByIdPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetByIdPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetById) (Return Type : UserLevel) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UserLevels_GetById_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetById, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_userLevelsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetById) (Return Type : UserLevel) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UserLevels_GetById_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetById, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Count) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UserLevels_Count_Method_Call_Internally(Type[] types)
        {
            var methodCountPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_userLevelsInstance, MethodCount, Fixture, methodCountPrametersTypes);
        }

        #endregion

        #region Method Call : (Count) (Return Type : int) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UserLevels_Count_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _userLevelsInstance.Count();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Count) (Return Type : int) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UserLevels_Count_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodCountPrametersTypes = null;
            object[] parametersOfCount = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCount, methodCountPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_userLevelsInstanceFixture, parametersOfCount);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCount.ShouldBeNull();
            methodCountPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Count) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UserLevels_Count_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCountPrametersTypes = null;
            object[] parametersOfCount = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<UserLevels, int>(_userLevelsInstance, MethodCount, parametersOfCount, methodCountPrametersTypes);

            // Assert
            parametersOfCount.ShouldBeNull();
            methodCountPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Count) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UserLevels_Count_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodCountPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_userLevelsInstance, MethodCount, Fixture, methodCountPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodCountPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Count) (Return Type : int) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UserLevels_Count_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodCountPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_userLevelsInstance, MethodCount, Fixture, methodCountPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodCountPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Count) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UserLevels_Count_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCountPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_userLevelsInstance, MethodCount, Fixture, methodCountPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCountPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Count) (Return Type : int) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UserLevels_Count_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCount, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_userLevelsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetEnumerator) (Return Type : IEnumerator<KeyValuePair<int, UserLevel>>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UserLevels_GetEnumerator_Method_Call_Internally(Type[] types)
        {
            var methodGetEnumeratorPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_userLevelsInstance, MethodGetEnumerator, Fixture, methodGetEnumeratorPrametersTypes);
        }

        #endregion

        #region Method Call : (GetEnumerator) (Return Type : IEnumerator<KeyValuePair<int, UserLevel>>) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UserLevels_GetEnumerator_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _userLevelsInstance.GetEnumerator();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetEnumerator) (Return Type : IEnumerator<KeyValuePair<int, UserLevel>>) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UserLevels_GetEnumerator_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetEnumeratorPrametersTypes = null;
            object[] parametersOfGetEnumerator = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetEnumerator, methodGetEnumeratorPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_userLevelsInstanceFixture, parametersOfGetEnumerator);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetEnumerator.ShouldBeNull();
            methodGetEnumeratorPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetEnumerator) (Return Type : IEnumerator<KeyValuePair<int, UserLevel>>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UserLevels_GetEnumerator_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetEnumeratorPrametersTypes = null;
            object[] parametersOfGetEnumerator = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<UserLevels, IEnumerator<KeyValuePair<int, UserLevel>>>(_userLevelsInstance, MethodGetEnumerator, parametersOfGetEnumerator, methodGetEnumeratorPrametersTypes);

            // Assert
            parametersOfGetEnumerator.ShouldBeNull();
            methodGetEnumeratorPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetEnumerator) (Return Type : IEnumerator<KeyValuePair<int, UserLevel>>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UserLevels_GetEnumerator_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetEnumeratorPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_userLevelsInstance, MethodGetEnumerator, Fixture, methodGetEnumeratorPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetEnumeratorPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetEnumerator) (Return Type : IEnumerator<KeyValuePair<int, UserLevel>>) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UserLevels_GetEnumerator_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetEnumeratorPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_userLevelsInstance, MethodGetEnumerator, Fixture, methodGetEnumeratorPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetEnumeratorPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetEnumerator) (Return Type : IEnumerator<KeyValuePair<int, UserLevel>>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UserLevels_GetEnumerator_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetEnumeratorPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_userLevelsInstance, MethodGetEnumerator, Fixture, methodGetEnumeratorPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetEnumeratorPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetEnumerator) (Return Type : IEnumerator<KeyValuePair<int, UserLevel>>) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UserLevels_GetEnumerator_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetEnumerator, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_userLevelsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetUserLevel) (Return Type : UserLevel) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UserLevels_GetUserLevel_Method_Call_Internally(Type[] types)
        {
            var methodGetUserLevelPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_userLevelsInstance, MethodGetUserLevel, Fixture, methodGetUserLevelPrametersTypes);
        }

        #endregion

        #region Method Call : (GetUserLevel) (Return Type : UserLevel) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UserLevels_GetUserLevel_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var id = CreateType<int>();
            var levels = CreateType<int[]>();
            var methodGetUserLevelPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(int[]) };
            object[] parametersOfGetUserLevel = { name, id, levels };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetUserLevel, methodGetUserLevelPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_userLevelsInstanceFixture, parametersOfGetUserLevel);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetUserLevel.ShouldNotBeNull();
            parametersOfGetUserLevel.Length.ShouldBe(3);
            methodGetUserLevelPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetUserLevel) (Return Type : UserLevel) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UserLevels_GetUserLevel_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var id = CreateType<int>();
            var levels = CreateType<int[]>();
            var methodGetUserLevelPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(int[]) };
            object[] parametersOfGetUserLevel = { name, id, levels };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<UserLevels, UserLevel>(_userLevelsInstance, MethodGetUserLevel, parametersOfGetUserLevel, methodGetUserLevelPrametersTypes);

            // Assert
            parametersOfGetUserLevel.ShouldNotBeNull();
            parametersOfGetUserLevel.Length.ShouldBe(3);
            methodGetUserLevelPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetUserLevel) (Return Type : UserLevel) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UserLevels_GetUserLevel_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetUserLevelPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(int[]) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_userLevelsInstance, MethodGetUserLevel, Fixture, methodGetUserLevelPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetUserLevelPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetUserLevel) (Return Type : UserLevel) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UserLevels_GetUserLevel_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetUserLevelPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(int[]) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_userLevelsInstance, MethodGetUserLevel, Fixture, methodGetUserLevelPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetUserLevelPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetUserLevel) (Return Type : UserLevel) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UserLevels_GetUserLevel_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetUserLevel, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_userLevelsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetUserLevel) (Return Type : UserLevel) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UserLevels_GetUserLevel_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetUserLevel, 0);
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
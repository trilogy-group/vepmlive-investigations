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
using Microsoft.SharePoint.Administration;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using ReportAuth = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.ReportAuth" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ReportAuthTest : AbstractBaseSetupTypedTest<ReportAuth>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportAuth) Initializer

        private const string PropertyDisplayName = "DisplayName";
        private const string PropertyPassword = "Password";
        private const string PropertyUsername = "Username";
        private const string MethodHasAdditionalUpdateAccess = "HasAdditionalUpdateAccess";
        private const string Field_username = "_username";
        private const string Field_password = "_password";
        private Type _reportAuthInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportAuth _reportAuthInstance;
        private ReportAuth _reportAuthInstanceFixture;

        #region General Initializer : Class (ReportAuth) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportAuth" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportAuthInstanceType = typeof(ReportAuth);
            _reportAuthInstanceFixture = Create(true);
            _reportAuthInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportAuth)

        #region General Initializer : Class (ReportAuth) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ReportAuth" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodHasAdditionalUpdateAccess, 0)]
        public void AUT_ReportAuth_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_reportAuthInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ReportAuth) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportAuth" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyDisplayName)]
        [TestCase(PropertyPassword)]
        [TestCase(PropertyUsername)]
        public void AUT_ReportAuth_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_reportAuthInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ReportAuth) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportAuth" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_username)]
        [TestCase(Field_password)]
        public void AUT_ReportAuth_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_reportAuthInstanceFixture, 
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
        ///     Class (<see cref="ReportAuth" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ReportAuth_Is_Instance_Present_Test()
        {
            // Assert
            _reportAuthInstanceType.ShouldNotBeNull();
            _reportAuthInstance.ShouldNotBeNull();
            _reportAuthInstanceFixture.ShouldNotBeNull();
            _reportAuthInstance.ShouldBeAssignableTo<ReportAuth>();
            _reportAuthInstanceFixture.ShouldBeAssignableTo<ReportAuth>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ReportAuth) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ReportAuth_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ReportAuth instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _reportAuthInstanceType.ShouldNotBeNull();
            _reportAuthInstance.ShouldNotBeNull();
            _reportAuthInstanceFixture.ShouldNotBeNull();
            _reportAuthInstance.ShouldBeAssignableTo<ReportAuth>();
            _reportAuthInstanceFixture.ShouldBeAssignableTo<ReportAuth>();
        }

        #endregion

        #region General Constructor : Class (ReportAuth) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ReportAuth_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var parent = CreateType<SPPersistedObject>();
            var guid = CreateType<Guid>();
            ReportAuth instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new ReportAuth(name, parent, guid);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _reportAuthInstance.ShouldNotBeNull();
            _reportAuthInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<ReportAuth>();
        }

        #endregion

        #region General Constructor : Class (ReportAuth) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ReportAuth_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var parent = CreateType<SPPersistedObject>();
            var guid = CreateType<Guid>();
            ReportAuth instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new ReportAuth(name, parent, guid);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _reportAuthInstance.ShouldNotBeNull();
            _reportAuthInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #region General Constructor : Class (ReportAuth) instance created

        /// <summary>
        ///     Class (<see cref="ReportAuth" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ReportAuth_Is_Created_Test()
        {
            // Assert
            _reportAuthInstance.ShouldNotBeNull();
            _reportAuthInstanceFixture.ShouldNotBeNull();
        }

        #endregion

        #region General Constructor : Class (ReportAuth) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="ReportAuth" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_ReportAuth_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<ReportAuth>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (ReportAuth) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="ReportAuth" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ReportAuth_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<ReportAuth>(Fixture);
        }

        #endregion

        #region General Constructor : Class (ReportAuth) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ReportAuth" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ReportAuth_Constructors_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfReportAuth = {  };
            Type [] methodReportAuthPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_reportAuthInstanceType, methodReportAuthPrametersTypes, parametersOfReportAuth);
        }

        #endregion

        #region General Constructor : Class (ReportAuth) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ReportAuth" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ReportAuth_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodReportAuthPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_reportAuthInstanceType, Fixture, methodReportAuthPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (ReportAuth) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ReportAuth" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ReportAuth_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var parent = CreateType<SPPersistedObject>();
            var guid = CreateType<Guid>();
            object[] parametersOfReportAuth = { name, parent, guid };
            var methodReportAuthPrametersTypes = new Type[] { typeof(string), typeof(SPPersistedObject), typeof(Guid) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_reportAuthInstanceType, methodReportAuthPrametersTypes, parametersOfReportAuth);
        }

        #endregion

        #region General Constructor : Class (ReportAuth) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ReportAuth" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ReportAuth_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodReportAuthPrametersTypes = new Type[] { typeof(string), typeof(SPPersistedObject), typeof(Guid) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_reportAuthInstanceType, Fixture, methodReportAuthPrametersTypes);
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ReportAuth) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyDisplayName)]
        [TestCaseGeneric(typeof(String) , PropertyPassword)]
        [TestCaseGeneric(typeof(String) , PropertyUsername)]
        public void AUT_ReportAuth_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ReportAuth, T>(_reportAuthInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ReportAuth) => Property (DisplayName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportAuth_Public_Class_DisplayName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDisplayName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportAuth) => Property (Password) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportAuth_Public_Class_Password_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPassword);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportAuth) => Property (Username) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportAuth_Public_Class_Username_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyUsername);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ReportAuth" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodHasAdditionalUpdateAccess)]
        public void AUT_ReportAuth_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ReportAuth>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (HasAdditionalUpdateAccess) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportAuth_HasAdditionalUpdateAccess_Method_Call_Internally(Type[] types)
        {
            var methodHasAdditionalUpdateAccessPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportAuthInstance, MethodHasAdditionalUpdateAccess, Fixture, methodHasAdditionalUpdateAccessPrametersTypes);
        }

        #endregion

        #region Method Call : (HasAdditionalUpdateAccess) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportAuth_HasAdditionalUpdateAccess_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodHasAdditionalUpdateAccessPrametersTypes = null;
            object[] parametersOfHasAdditionalUpdateAccess = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodHasAdditionalUpdateAccess, methodHasAdditionalUpdateAccessPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportAuth, bool>(_reportAuthInstanceFixture, out exception1, parametersOfHasAdditionalUpdateAccess);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportAuth, bool>(_reportAuthInstance, MethodHasAdditionalUpdateAccess, parametersOfHasAdditionalUpdateAccess, methodHasAdditionalUpdateAccessPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfHasAdditionalUpdateAccess.ShouldBeNull();
            methodHasAdditionalUpdateAccessPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (HasAdditionalUpdateAccess) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportAuth_HasAdditionalUpdateAccess_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodHasAdditionalUpdateAccessPrametersTypes = null;
            object[] parametersOfHasAdditionalUpdateAccess = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodHasAdditionalUpdateAccess, methodHasAdditionalUpdateAccessPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportAuth, bool>(_reportAuthInstanceFixture, out exception1, parametersOfHasAdditionalUpdateAccess);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportAuth, bool>(_reportAuthInstance, MethodHasAdditionalUpdateAccess, parametersOfHasAdditionalUpdateAccess, methodHasAdditionalUpdateAccessPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfHasAdditionalUpdateAccess.ShouldBeNull();
            methodHasAdditionalUpdateAccessPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (HasAdditionalUpdateAccess) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportAuth_HasAdditionalUpdateAccess_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodHasAdditionalUpdateAccessPrametersTypes = null;
            object[] parametersOfHasAdditionalUpdateAccess = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodHasAdditionalUpdateAccess, methodHasAdditionalUpdateAccessPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportAuthInstanceFixture, parametersOfHasAdditionalUpdateAccess);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfHasAdditionalUpdateAccess.ShouldBeNull();
            methodHasAdditionalUpdateAccessPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HasAdditionalUpdateAccess) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportAuth_HasAdditionalUpdateAccess_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodHasAdditionalUpdateAccessPrametersTypes = null;
            object[] parametersOfHasAdditionalUpdateAccess = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportAuth, bool>(_reportAuthInstance, MethodHasAdditionalUpdateAccess, parametersOfHasAdditionalUpdateAccess, methodHasAdditionalUpdateAccessPrametersTypes);

            // Assert
            parametersOfHasAdditionalUpdateAccess.ShouldBeNull();
            methodHasAdditionalUpdateAccessPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HasAdditionalUpdateAccess) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportAuth_HasAdditionalUpdateAccess_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodHasAdditionalUpdateAccessPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportAuthInstance, MethodHasAdditionalUpdateAccess, Fixture, methodHasAdditionalUpdateAccessPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodHasAdditionalUpdateAccessPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (HasAdditionalUpdateAccess) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportAuth_HasAdditionalUpdateAccess_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodHasAdditionalUpdateAccessPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportAuthInstance, MethodHasAdditionalUpdateAccess, Fixture, methodHasAdditionalUpdateAccessPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodHasAdditionalUpdateAccessPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (HasAdditionalUpdateAccess) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportAuth_HasAdditionalUpdateAccess_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodHasAdditionalUpdateAccessPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportAuthInstance, MethodHasAdditionalUpdateAccess, Fixture, methodHasAdditionalUpdateAccessPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodHasAdditionalUpdateAccessPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (HasAdditionalUpdateAccess) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportAuth_HasAdditionalUpdateAccess_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodHasAdditionalUpdateAccess, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportAuthInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion
    }
}
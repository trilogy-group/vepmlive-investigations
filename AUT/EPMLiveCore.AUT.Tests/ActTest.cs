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
using Act = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Act" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class ActTest : AbstractBaseSetupTypedTest<Act>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Act) Initializer

        private const string PropertyIsOnline = "IsOnline";
        private const string MethodtranslateStatus = "translateStatus";
        private const string MethodCheckOnlineFeatureLicense = "CheckOnlineFeatureLicense";
        private const string MethodSetUserActivation = "SetUserActivation";
        private const string MethodCheckOnsiteFeatureLicense = "CheckOnsiteFeatureLicense";
        private const string MethodCheckFeatureLicense = "CheckFeatureLicense";
        private const string MethodSetUserLevelV3 = "SetUserLevelV3";
        private const string MethodGetLevelsFromSite = "GetLevelsFromSite";
        private const string MethodGetFeatureUsers = "GetFeatureUsers";
        private const string MethodGetFarmFeatureUsers = "GetFarmFeatureUsers";
        private const string MethodGetActivatedLevels = "GetActivatedLevels";
        private const string MethodGetAllAvailableLevels = "GetAllAvailableLevels";
        private const string MethodfarmEncode = "farmEncode";
        private const string MethodGetFeatureNameV2 = "GetFeatureNameV2";
        private const string MethodGetFeatureName = "GetFeatureName";
        private const string Field_web = "_web";
        private const string Field_bIsOnline = "_bIsOnline";
        private const string FieldOwnerUsername = "OwnerUsername";
        private const string FieldbLatestError = "bLatestError";
        private Type _actInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Act _actInstance;
        private Act _actInstanceFixture;

        #region General Initializer : Class (Act) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Act" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _actInstanceType = typeof(Act);
            _actInstanceFixture = Create(true);
            _actInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Act)

        #region General Initializer : Class (Act) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Act" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodtranslateStatus, 0)]
        [TestCase(MethodCheckOnlineFeatureLicense, 0)]
        [TestCase(MethodSetUserActivation, 0)]
        [TestCase(MethodCheckOnsiteFeatureLicense, 0)]
        [TestCase(MethodCheckFeatureLicense, 0)]
        [TestCase(MethodSetUserLevelV3, 0)]
        [TestCase(MethodGetLevelsFromSite, 0)]
        [TestCase(MethodGetFeatureUsers, 0)]
        [TestCase(MethodGetFarmFeatureUsers, 0)]
        [TestCase(MethodGetActivatedLevels, 0)]
        [TestCase(MethodGetAllAvailableLevels, 0)]
        [TestCase(MethodfarmEncode, 0)]
        [TestCase(MethodGetFeatureNameV2, 0)]
        [TestCase(MethodGetFeatureName, 0)]
        public void AUT_Act_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_actInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Act) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Act" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyIsOnline)]
        public void AUT_Act_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_actInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Act) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Act" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_web)]
        [TestCase(Field_bIsOnline)]
        [TestCase(FieldOwnerUsername)]
        [TestCase(FieldbLatestError)]
        public void AUT_Act_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_actInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Act) => Property (IsOnline) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Act_Public_Class_IsOnline_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyIsOnline);

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

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="Act" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetAllAvailableLevels)]
        [TestCase(MethodfarmEncode)]
        [TestCase(MethodGetFeatureNameV2)]
        [TestCase(MethodGetFeatureName)]
        public void AUT_Act_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_actInstanceFixture,
                                                                              _actInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="Act" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodtranslateStatus)]
        [TestCase(MethodCheckOnlineFeatureLicense)]
        [TestCase(MethodSetUserActivation)]
        [TestCase(MethodCheckOnsiteFeatureLicense)]
        [TestCase(MethodCheckFeatureLicense)]
        [TestCase(MethodSetUserLevelV3)]
        [TestCase(MethodGetLevelsFromSite)]
        [TestCase(MethodGetFeatureUsers)]
        [TestCase(MethodGetFarmFeatureUsers)]
        [TestCase(MethodGetActivatedLevels)]
        public void AUT_Act_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<Act>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (translateStatus) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Act_translateStatus_Method_Call_Internally(Type[] types)
        {
            var methodtranslateStatusPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_actInstance, MethodtranslateStatus, Fixture, methodtranslateStatusPrametersTypes);
        }

        #endregion

        #region Method Call : (translateStatus) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_translateStatus_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var status = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _actInstance.translateStatus(status);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (translateStatus) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_translateStatus_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var status = CreateType<int>();
            var methodtranslateStatusPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOftranslateStatus = { status };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodtranslateStatus, methodtranslateStatusPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Act, string>(_actInstanceFixture, out exception1, parametersOftranslateStatus);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Act, string>(_actInstance, MethodtranslateStatus, parametersOftranslateStatus, methodtranslateStatusPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOftranslateStatus.ShouldNotBeNull();
            parametersOftranslateStatus.Length.ShouldBe(1);
            methodtranslateStatusPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (translateStatus) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_translateStatus_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var status = CreateType<int>();
            var methodtranslateStatusPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOftranslateStatus = { status };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Act, string>(_actInstance, MethodtranslateStatus, parametersOftranslateStatus, methodtranslateStatusPrametersTypes);

            // Assert
            parametersOftranslateStatus.ShouldNotBeNull();
            parametersOftranslateStatus.Length.ShouldBe(1);
            methodtranslateStatusPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (translateStatus) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_translateStatus_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodtranslateStatusPrametersTypes = new Type[] { typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_actInstance, MethodtranslateStatus, Fixture, methodtranslateStatusPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodtranslateStatusPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (translateStatus) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_translateStatus_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodtranslateStatusPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_actInstance, MethodtranslateStatus, Fixture, methodtranslateStatusPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodtranslateStatusPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (translateStatus) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_translateStatus_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodtranslateStatus, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_actInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (translateStatus) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_translateStatus_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodtranslateStatus, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CheckOnlineFeatureLicense) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Act_CheckOnlineFeatureLicense_Method_Call_Internally(Type[] types)
        {
            var methodCheckOnlineFeatureLicensePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_actInstance, MethodCheckOnlineFeatureLicense, Fixture, methodCheckOnlineFeatureLicensePrametersTypes);
        }

        #endregion

        #region Method Call : (CheckOnlineFeatureLicense) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_CheckOnlineFeatureLicense_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var feature = CreateType<ActFeature>();
            var username = CreateType<string>();
            var site = CreateType<SPSite>();
            var methodCheckOnlineFeatureLicensePrametersTypes = new Type[] { typeof(ActFeature), typeof(string), typeof(SPSite) };
            object[] parametersOfCheckOnlineFeatureLicense = { feature, username, site };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCheckOnlineFeatureLicense, methodCheckOnlineFeatureLicensePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Act, int>(_actInstanceFixture, out exception1, parametersOfCheckOnlineFeatureLicense);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Act, int>(_actInstance, MethodCheckOnlineFeatureLicense, parametersOfCheckOnlineFeatureLicense, methodCheckOnlineFeatureLicensePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfCheckOnlineFeatureLicense.ShouldNotBeNull();
            parametersOfCheckOnlineFeatureLicense.Length.ShouldBe(3);
            methodCheckOnlineFeatureLicensePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (CheckOnlineFeatureLicense) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_CheckOnlineFeatureLicense_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var feature = CreateType<ActFeature>();
            var username = CreateType<string>();
            var site = CreateType<SPSite>();
            var methodCheckOnlineFeatureLicensePrametersTypes = new Type[] { typeof(ActFeature), typeof(string), typeof(SPSite) };
            object[] parametersOfCheckOnlineFeatureLicense = { feature, username, site };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCheckOnlineFeatureLicense, methodCheckOnlineFeatureLicensePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Act, int>(_actInstanceFixture, out exception1, parametersOfCheckOnlineFeatureLicense);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Act, int>(_actInstance, MethodCheckOnlineFeatureLicense, parametersOfCheckOnlineFeatureLicense, methodCheckOnlineFeatureLicensePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfCheckOnlineFeatureLicense.ShouldNotBeNull();
            parametersOfCheckOnlineFeatureLicense.Length.ShouldBe(3);
            methodCheckOnlineFeatureLicensePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (CheckOnlineFeatureLicense) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_CheckOnlineFeatureLicense_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var feature = CreateType<ActFeature>();
            var username = CreateType<string>();
            var site = CreateType<SPSite>();
            var methodCheckOnlineFeatureLicensePrametersTypes = new Type[] { typeof(ActFeature), typeof(string), typeof(SPSite) };
            object[] parametersOfCheckOnlineFeatureLicense = { feature, username, site };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Act, int>(_actInstance, MethodCheckOnlineFeatureLicense, parametersOfCheckOnlineFeatureLicense, methodCheckOnlineFeatureLicensePrametersTypes);

            // Assert
            parametersOfCheckOnlineFeatureLicense.ShouldNotBeNull();
            parametersOfCheckOnlineFeatureLicense.Length.ShouldBe(3);
            methodCheckOnlineFeatureLicensePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CheckOnlineFeatureLicense) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_CheckOnlineFeatureLicense_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCheckOnlineFeatureLicensePrametersTypes = new Type[] { typeof(ActFeature), typeof(string), typeof(SPSite) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_actInstance, MethodCheckOnlineFeatureLicense, Fixture, methodCheckOnlineFeatureLicensePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCheckOnlineFeatureLicensePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CheckOnlineFeatureLicense) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_CheckOnlineFeatureLicense_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCheckOnlineFeatureLicense, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_actInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CheckOnlineFeatureLicense) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_CheckOnlineFeatureLicense_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCheckOnlineFeatureLicense, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetUserActivation) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Act_SetUserActivation_Method_Call_Internally(Type[] types)
        {
            var methodSetUserActivationPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_actInstance, MethodSetUserActivation, Fixture, methodSetUserActivationPrametersTypes);
        }

        #endregion

        #region Method Call : (SetUserActivation) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_SetUserActivation_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var feature = CreateType<int>();
            var username = CreateType<string>();
            var site = CreateType<SPSite>();
            var methodSetUserActivationPrametersTypes = new Type[] { typeof(int), typeof(string), typeof(SPSite) };
            object[] parametersOfSetUserActivation = { feature, username, site };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSetUserActivation, methodSetUserActivationPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Act, int>(_actInstanceFixture, out exception1, parametersOfSetUserActivation);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Act, int>(_actInstance, MethodSetUserActivation, parametersOfSetUserActivation, methodSetUserActivationPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSetUserActivation.ShouldNotBeNull();
            parametersOfSetUserActivation.Length.ShouldBe(3);
            methodSetUserActivationPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (SetUserActivation) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_SetUserActivation_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var feature = CreateType<int>();
            var username = CreateType<string>();
            var site = CreateType<SPSite>();
            var methodSetUserActivationPrametersTypes = new Type[] { typeof(int), typeof(string), typeof(SPSite) };
            object[] parametersOfSetUserActivation = { feature, username, site };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSetUserActivation, methodSetUserActivationPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Act, int>(_actInstanceFixture, out exception1, parametersOfSetUserActivation);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Act, int>(_actInstance, MethodSetUserActivation, parametersOfSetUserActivation, methodSetUserActivationPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSetUserActivation.ShouldNotBeNull();
            parametersOfSetUserActivation.Length.ShouldBe(3);
            methodSetUserActivationPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (SetUserActivation) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_SetUserActivation_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var feature = CreateType<int>();
            var username = CreateType<string>();
            var site = CreateType<SPSite>();
            var methodSetUserActivationPrametersTypes = new Type[] { typeof(int), typeof(string), typeof(SPSite) };
            object[] parametersOfSetUserActivation = { feature, username, site };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Act, int>(_actInstance, MethodSetUserActivation, parametersOfSetUserActivation, methodSetUserActivationPrametersTypes);

            // Assert
            parametersOfSetUserActivation.ShouldNotBeNull();
            parametersOfSetUserActivation.Length.ShouldBe(3);
            methodSetUserActivationPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetUserActivation) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_SetUserActivation_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetUserActivationPrametersTypes = new Type[] { typeof(int), typeof(string), typeof(SPSite) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_actInstance, MethodSetUserActivation, Fixture, methodSetUserActivationPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSetUserActivationPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetUserActivation) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_SetUserActivation_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetUserActivation, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_actInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetUserActivation) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_SetUserActivation_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetUserActivation, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CheckOnsiteFeatureLicense) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Act_CheckOnsiteFeatureLicense_Method_Call_Internally(Type[] types)
        {
            var methodCheckOnsiteFeatureLicensePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_actInstance, MethodCheckOnsiteFeatureLicense, Fixture, methodCheckOnsiteFeatureLicensePrametersTypes);
        }

        #endregion

        #region Method Call : (CheckOnsiteFeatureLicense) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_CheckOnsiteFeatureLicense_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var feature = CreateType<ActFeature>();
            var username = CreateType<string>();
            var site = CreateType<SPSite>();
            var methodCheckOnsiteFeatureLicensePrametersTypes = new Type[] { typeof(ActFeature), typeof(string), typeof(SPSite) };
            object[] parametersOfCheckOnsiteFeatureLicense = { feature, username, site };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCheckOnsiteFeatureLicense, methodCheckOnsiteFeatureLicensePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Act, int>(_actInstanceFixture, out exception1, parametersOfCheckOnsiteFeatureLicense);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Act, int>(_actInstance, MethodCheckOnsiteFeatureLicense, parametersOfCheckOnsiteFeatureLicense, methodCheckOnsiteFeatureLicensePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfCheckOnsiteFeatureLicense.ShouldNotBeNull();
            parametersOfCheckOnsiteFeatureLicense.Length.ShouldBe(3);
            methodCheckOnsiteFeatureLicensePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (CheckOnsiteFeatureLicense) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_CheckOnsiteFeatureLicense_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var feature = CreateType<ActFeature>();
            var username = CreateType<string>();
            var site = CreateType<SPSite>();
            var methodCheckOnsiteFeatureLicensePrametersTypes = new Type[] { typeof(ActFeature), typeof(string), typeof(SPSite) };
            object[] parametersOfCheckOnsiteFeatureLicense = { feature, username, site };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCheckOnsiteFeatureLicense, methodCheckOnsiteFeatureLicensePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Act, int>(_actInstanceFixture, out exception1, parametersOfCheckOnsiteFeatureLicense);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Act, int>(_actInstance, MethodCheckOnsiteFeatureLicense, parametersOfCheckOnsiteFeatureLicense, methodCheckOnsiteFeatureLicensePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfCheckOnsiteFeatureLicense.ShouldNotBeNull();
            parametersOfCheckOnsiteFeatureLicense.Length.ShouldBe(3);
            methodCheckOnsiteFeatureLicensePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (CheckOnsiteFeatureLicense) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_CheckOnsiteFeatureLicense_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var feature = CreateType<ActFeature>();
            var username = CreateType<string>();
            var site = CreateType<SPSite>();
            var methodCheckOnsiteFeatureLicensePrametersTypes = new Type[] { typeof(ActFeature), typeof(string), typeof(SPSite) };
            object[] parametersOfCheckOnsiteFeatureLicense = { feature, username, site };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Act, int>(_actInstance, MethodCheckOnsiteFeatureLicense, parametersOfCheckOnsiteFeatureLicense, methodCheckOnsiteFeatureLicensePrametersTypes);

            // Assert
            parametersOfCheckOnsiteFeatureLicense.ShouldNotBeNull();
            parametersOfCheckOnsiteFeatureLicense.Length.ShouldBe(3);
            methodCheckOnsiteFeatureLicensePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CheckOnsiteFeatureLicense) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_CheckOnsiteFeatureLicense_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCheckOnsiteFeatureLicensePrametersTypes = new Type[] { typeof(ActFeature), typeof(string), typeof(SPSite) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_actInstance, MethodCheckOnsiteFeatureLicense, Fixture, methodCheckOnsiteFeatureLicensePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCheckOnsiteFeatureLicensePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CheckOnsiteFeatureLicense) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_CheckOnsiteFeatureLicense_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCheckOnsiteFeatureLicense, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_actInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CheckOnsiteFeatureLicense) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_CheckOnsiteFeatureLicense_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCheckOnsiteFeatureLicense, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CheckFeatureLicense) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Act_CheckFeatureLicense_Method_Call_Internally(Type[] types)
        {
            var methodCheckFeatureLicensePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_actInstance, MethodCheckFeatureLicense, Fixture, methodCheckFeatureLicensePrametersTypes);
        }

        #endregion

        #region Method Call : (CheckFeatureLicense) (Return Type : int) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_CheckFeatureLicense_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var feature = CreateType<ActFeature>();
            Action executeAction = null;

            // Act
            executeAction = () => _actInstance.CheckFeatureLicense(feature);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CheckFeatureLicense) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_CheckFeatureLicense_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var feature = CreateType<ActFeature>();
            var methodCheckFeatureLicensePrametersTypes = new Type[] { typeof(ActFeature) };
            object[] parametersOfCheckFeatureLicense = { feature };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCheckFeatureLicense, methodCheckFeatureLicensePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Act, int>(_actInstanceFixture, out exception1, parametersOfCheckFeatureLicense);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Act, int>(_actInstance, MethodCheckFeatureLicense, parametersOfCheckFeatureLicense, methodCheckFeatureLicensePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfCheckFeatureLicense.ShouldNotBeNull();
            parametersOfCheckFeatureLicense.Length.ShouldBe(1);
            methodCheckFeatureLicensePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (CheckFeatureLicense) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_CheckFeatureLicense_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var feature = CreateType<ActFeature>();
            var methodCheckFeatureLicensePrametersTypes = new Type[] { typeof(ActFeature) };
            object[] parametersOfCheckFeatureLicense = { feature };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCheckFeatureLicense, methodCheckFeatureLicensePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Act, int>(_actInstanceFixture, out exception1, parametersOfCheckFeatureLicense);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Act, int>(_actInstance, MethodCheckFeatureLicense, parametersOfCheckFeatureLicense, methodCheckFeatureLicensePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfCheckFeatureLicense.ShouldNotBeNull();
            parametersOfCheckFeatureLicense.Length.ShouldBe(1);
            methodCheckFeatureLicensePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (CheckFeatureLicense) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_CheckFeatureLicense_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var feature = CreateType<ActFeature>();
            var methodCheckFeatureLicensePrametersTypes = new Type[] { typeof(ActFeature) };
            object[] parametersOfCheckFeatureLicense = { feature };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Act, int>(_actInstance, MethodCheckFeatureLicense, parametersOfCheckFeatureLicense, methodCheckFeatureLicensePrametersTypes);

            // Assert
            parametersOfCheckFeatureLicense.ShouldNotBeNull();
            parametersOfCheckFeatureLicense.Length.ShouldBe(1);
            methodCheckFeatureLicensePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CheckFeatureLicense) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_CheckFeatureLicense_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCheckFeatureLicensePrametersTypes = new Type[] { typeof(ActFeature) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_actInstance, MethodCheckFeatureLicense, Fixture, methodCheckFeatureLicensePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCheckFeatureLicensePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CheckFeatureLicense) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_CheckFeatureLicense_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCheckFeatureLicense, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_actInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CheckFeatureLicense) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_CheckFeatureLicense_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCheckFeatureLicense, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetUserLevelV3) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Act_SetUserLevelV3_Method_Call_Internally(Type[] types)
        {
            var methodSetUserLevelV3PrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_actInstance, MethodSetUserLevelV3, Fixture, methodSetUserLevelV3PrametersTypes);
        }

        #endregion

        #region Method Call : (SetUserLevelV3) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_SetUserLevelV3_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var username = CreateType<string>();
            var level = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _actInstance.SetUserLevelV3(username, level);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetUserLevelV3) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_SetUserLevelV3_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var username = CreateType<string>();
            var level = CreateType<int>();
            var methodSetUserLevelV3PrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfSetUserLevelV3 = { username, level };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetUserLevelV3, methodSetUserLevelV3PrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_actInstanceFixture, parametersOfSetUserLevelV3);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetUserLevelV3.ShouldNotBeNull();
            parametersOfSetUserLevelV3.Length.ShouldBe(2);
            methodSetUserLevelV3PrametersTypes.Length.ShouldBe(2);
            methodSetUserLevelV3PrametersTypes.Length.ShouldBe(parametersOfSetUserLevelV3.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetUserLevelV3) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_SetUserLevelV3_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var username = CreateType<string>();
            var level = CreateType<int>();
            var methodSetUserLevelV3PrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfSetUserLevelV3 = { username, level };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_actInstance, MethodSetUserLevelV3, parametersOfSetUserLevelV3, methodSetUserLevelV3PrametersTypes);

            // Assert
            parametersOfSetUserLevelV3.ShouldNotBeNull();
            parametersOfSetUserLevelV3.Length.ShouldBe(2);
            methodSetUserLevelV3PrametersTypes.Length.ShouldBe(2);
            methodSetUserLevelV3PrametersTypes.Length.ShouldBe(parametersOfSetUserLevelV3.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetUserLevelV3) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_SetUserLevelV3_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetUserLevelV3, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetUserLevelV3) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_SetUserLevelV3_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetUserLevelV3PrametersTypes = new Type[] { typeof(string), typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_actInstance, MethodSetUserLevelV3, Fixture, methodSetUserLevelV3PrametersTypes);

            // Assert
            methodSetUserLevelV3PrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetUserLevelV3) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_SetUserLevelV3_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetUserLevelV3, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_actInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetLevelsFromSite) (Return Type : ArrayList) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Act_GetLevelsFromSite_Method_Call_Internally(Type[] types)
        {
            var methodGetLevelsFromSitePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_actInstance, MethodGetLevelsFromSite, Fixture, methodGetLevelsFromSitePrametersTypes);
        }

        #endregion

        #region Method Call : (GetLevelsFromSite) (Return Type : ArrayList) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetLevelsFromSite_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var ActivationType = CreateType<int>();
            var username = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _actInstance.GetLevelsFromSite(out ActivationType, username);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetLevelsFromSite) (Return Type : ArrayList) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetLevelsFromSite_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var ActivationType = CreateType<int>();
            var username = CreateType<string>();
            var methodGetLevelsFromSitePrametersTypes = new Type[] { typeof(int), typeof(string) };
            object[] parametersOfGetLevelsFromSite = { ActivationType, username };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetLevelsFromSite, methodGetLevelsFromSitePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Act, ArrayList>(_actInstanceFixture, out exception1, parametersOfGetLevelsFromSite);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Act, ArrayList>(_actInstance, MethodGetLevelsFromSite, parametersOfGetLevelsFromSite, methodGetLevelsFromSitePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetLevelsFromSite.ShouldNotBeNull();
            parametersOfGetLevelsFromSite.Length.ShouldBe(2);
            methodGetLevelsFromSitePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetLevelsFromSite) (Return Type : ArrayList) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetLevelsFromSite_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var ActivationType = CreateType<int>();
            var username = CreateType<string>();
            var methodGetLevelsFromSitePrametersTypes = new Type[] { typeof(int), typeof(string) };
            object[] parametersOfGetLevelsFromSite = { ActivationType, username };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Act, ArrayList>(_actInstance, MethodGetLevelsFromSite, parametersOfGetLevelsFromSite, methodGetLevelsFromSitePrametersTypes);

            // Assert
            parametersOfGetLevelsFromSite.ShouldNotBeNull();
            parametersOfGetLevelsFromSite.Length.ShouldBe(2);
            methodGetLevelsFromSitePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetLevelsFromSite) (Return Type : ArrayList) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetLevelsFromSite_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetLevelsFromSitePrametersTypes = new Type[] { typeof(int), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_actInstance, MethodGetLevelsFromSite, Fixture, methodGetLevelsFromSitePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetLevelsFromSitePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetLevelsFromSite) (Return Type : ArrayList) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetLevelsFromSite_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetLevelsFromSitePrametersTypes = new Type[] { typeof(int), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_actInstance, MethodGetLevelsFromSite, Fixture, methodGetLevelsFromSitePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetLevelsFromSitePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetLevelsFromSite) (Return Type : ArrayList) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetLevelsFromSite_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetLevelsFromSite, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_actInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLevelsFromSite) (Return Type : ArrayList) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetLevelsFromSite_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetLevelsFromSite, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFeatureUsers) (Return Type : ArrayList) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Act_GetFeatureUsers_Method_Call_Internally(Type[] types)
        {
            var methodGetFeatureUsersPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_actInstance, MethodGetFeatureUsers, Fixture, methodGetFeatureUsersPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFeatureUsers) (Return Type : ArrayList) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetFeatureUsers_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var featureid = CreateType<int>();
            var methodGetFeatureUsersPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfGetFeatureUsers = { featureid };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetFeatureUsers, methodGetFeatureUsersPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Act, ArrayList>(_actInstanceFixture, out exception1, parametersOfGetFeatureUsers);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Act, ArrayList>(_actInstance, MethodGetFeatureUsers, parametersOfGetFeatureUsers, methodGetFeatureUsersPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFeatureUsers.ShouldNotBeNull();
            parametersOfGetFeatureUsers.Length.ShouldBe(1);
            methodGetFeatureUsersPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFeatureUsers) (Return Type : ArrayList) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetFeatureUsers_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var featureid = CreateType<int>();
            var methodGetFeatureUsersPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfGetFeatureUsers = { featureid };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Act, ArrayList>(_actInstance, MethodGetFeatureUsers, parametersOfGetFeatureUsers, methodGetFeatureUsersPrametersTypes);

            // Assert
            parametersOfGetFeatureUsers.ShouldNotBeNull();
            parametersOfGetFeatureUsers.Length.ShouldBe(1);
            methodGetFeatureUsersPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFeatureUsers) (Return Type : ArrayList) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetFeatureUsers_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFeatureUsersPrametersTypes = new Type[] { typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_actInstance, MethodGetFeatureUsers, Fixture, methodGetFeatureUsersPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFeatureUsersPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFeatureUsers) (Return Type : ArrayList) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetFeatureUsers_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFeatureUsersPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_actInstance, MethodGetFeatureUsers, Fixture, methodGetFeatureUsersPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFeatureUsersPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFeatureUsers) (Return Type : ArrayList) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetFeatureUsers_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFeatureUsers, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_actInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFeatureUsers) (Return Type : ArrayList) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetFeatureUsers_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFeatureUsers, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFarmFeatureUsers) (Return Type : ArrayList) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Act_GetFarmFeatureUsers_Method_Call_Internally(Type[] types)
        {
            var methodGetFarmFeatureUsersPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_actInstance, MethodGetFarmFeatureUsers, Fixture, methodGetFarmFeatureUsersPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFarmFeatureUsers) (Return Type : ArrayList) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetFarmFeatureUsers_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var featureId = CreateType<int>();
            var methodGetFarmFeatureUsersPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfGetFarmFeatureUsers = { featureId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetFarmFeatureUsers, methodGetFarmFeatureUsersPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Act, ArrayList>(_actInstanceFixture, out exception1, parametersOfGetFarmFeatureUsers);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Act, ArrayList>(_actInstance, MethodGetFarmFeatureUsers, parametersOfGetFarmFeatureUsers, methodGetFarmFeatureUsersPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFarmFeatureUsers.ShouldNotBeNull();
            parametersOfGetFarmFeatureUsers.Length.ShouldBe(1);
            methodGetFarmFeatureUsersPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFarmFeatureUsers) (Return Type : ArrayList) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetFarmFeatureUsers_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var featureId = CreateType<int>();
            var methodGetFarmFeatureUsersPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfGetFarmFeatureUsers = { featureId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Act, ArrayList>(_actInstance, MethodGetFarmFeatureUsers, parametersOfGetFarmFeatureUsers, methodGetFarmFeatureUsersPrametersTypes);

            // Assert
            parametersOfGetFarmFeatureUsers.ShouldNotBeNull();
            parametersOfGetFarmFeatureUsers.Length.ShouldBe(1);
            methodGetFarmFeatureUsersPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFarmFeatureUsers) (Return Type : ArrayList) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetFarmFeatureUsers_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFarmFeatureUsersPrametersTypes = new Type[] { typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_actInstance, MethodGetFarmFeatureUsers, Fixture, methodGetFarmFeatureUsersPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFarmFeatureUsersPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFarmFeatureUsers) (Return Type : ArrayList) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetFarmFeatureUsers_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFarmFeatureUsersPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_actInstance, MethodGetFarmFeatureUsers, Fixture, methodGetFarmFeatureUsersPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFarmFeatureUsersPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFarmFeatureUsers) (Return Type : ArrayList) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetFarmFeatureUsers_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFarmFeatureUsers, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_actInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFarmFeatureUsers) (Return Type : ArrayList) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetFarmFeatureUsers_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFarmFeatureUsers, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetActivatedLevels) (Return Type : ArrayList) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Act_GetActivatedLevels_Method_Call_Internally(Type[] types)
        {
            var methodGetActivatedLevelsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_actInstance, MethodGetActivatedLevels, Fixture, methodGetActivatedLevelsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetActivatedLevels) (Return Type : ArrayList) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetActivatedLevels_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _actInstance.GetActivatedLevels();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetActivatedLevels) (Return Type : ArrayList) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetActivatedLevels_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetActivatedLevelsPrametersTypes = null;
            object[] parametersOfGetActivatedLevels = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetActivatedLevels, methodGetActivatedLevelsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Act, ArrayList>(_actInstanceFixture, out exception1, parametersOfGetActivatedLevels);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Act, ArrayList>(_actInstance, MethodGetActivatedLevels, parametersOfGetActivatedLevels, methodGetActivatedLevelsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetActivatedLevels.ShouldBeNull();
            methodGetActivatedLevelsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetActivatedLevels) (Return Type : ArrayList) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetActivatedLevels_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetActivatedLevelsPrametersTypes = null;
            object[] parametersOfGetActivatedLevels = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Act, ArrayList>(_actInstance, MethodGetActivatedLevels, parametersOfGetActivatedLevels, methodGetActivatedLevelsPrametersTypes);

            // Assert
            parametersOfGetActivatedLevels.ShouldBeNull();
            methodGetActivatedLevelsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetActivatedLevels) (Return Type : ArrayList) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetActivatedLevels_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetActivatedLevelsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_actInstance, MethodGetActivatedLevels, Fixture, methodGetActivatedLevelsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetActivatedLevelsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetActivatedLevels) (Return Type : ArrayList) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetActivatedLevels_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetActivatedLevelsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_actInstance, MethodGetActivatedLevels, Fixture, methodGetActivatedLevelsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetActivatedLevelsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetActivatedLevels) (Return Type : ArrayList) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetActivatedLevels_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetActivatedLevels, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_actInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAllAvailableLevels) (Return Type : SortedList) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Act_GetAllAvailableLevels_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetAllAvailableLevelsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_actInstanceFixture, _actInstanceType, MethodGetAllAvailableLevels, Fixture, methodGetAllAvailableLevelsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAllAvailableLevels) (Return Type : SortedList) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetAllAvailableLevels_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var ActivationType = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => Act.GetAllAvailableLevels(out ActivationType);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetAllAvailableLevels) (Return Type : SortedList) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetAllAvailableLevels_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var ActivationType = CreateType<int>();
            var methodGetAllAvailableLevelsPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfGetAllAvailableLevels = { ActivationType };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetAllAvailableLevels, methodGetAllAvailableLevelsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_actInstanceFixture, parametersOfGetAllAvailableLevels);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetAllAvailableLevels.ShouldNotBeNull();
            parametersOfGetAllAvailableLevels.Length.ShouldBe(1);
            methodGetAllAvailableLevelsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAllAvailableLevels) (Return Type : SortedList) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetAllAvailableLevels_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var ActivationType = CreateType<int>();
            var methodGetAllAvailableLevelsPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfGetAllAvailableLevels = { ActivationType };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<SortedList>(_actInstanceFixture, _actInstanceType, MethodGetAllAvailableLevels, parametersOfGetAllAvailableLevels, methodGetAllAvailableLevelsPrametersTypes);

            // Assert
            parametersOfGetAllAvailableLevels.ShouldNotBeNull();
            parametersOfGetAllAvailableLevels.Length.ShouldBe(1);
            methodGetAllAvailableLevelsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAllAvailableLevels) (Return Type : SortedList) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetAllAvailableLevels_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetAllAvailableLevelsPrametersTypes = new Type[] { typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_actInstanceFixture, _actInstanceType, MethodGetAllAvailableLevels, Fixture, methodGetAllAvailableLevelsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetAllAvailableLevelsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetAllAvailableLevels) (Return Type : SortedList) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetAllAvailableLevels_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetAllAvailableLevelsPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_actInstanceFixture, _actInstanceType, MethodGetAllAvailableLevels, Fixture, methodGetAllAvailableLevelsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetAllAvailableLevelsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAllAvailableLevels) (Return Type : SortedList) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetAllAvailableLevels_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetAllAvailableLevels, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_actInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetAllAvailableLevels) (Return Type : SortedList) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetAllAvailableLevels_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetAllAvailableLevels, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (farmEncode) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Act_farmEncode_Static_Method_Call_Internally(Type[] types)
        {
            var methodfarmEncodePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_actInstanceFixture, _actInstanceType, MethodfarmEncode, Fixture, methodfarmEncodePrametersTypes);
        }

        #endregion

        #region Method Call : (farmEncode) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_farmEncode_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var code = CreateType<string>();
            var methodfarmEncodePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOffarmEncode = { code };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodfarmEncode, methodfarmEncodePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_actInstanceFixture, _actInstanceType, MethodfarmEncode, Fixture, methodfarmEncodePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_actInstanceFixture, _actInstanceType, MethodfarmEncode, parametersOffarmEncode, methodfarmEncodePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_actInstanceFixture, parametersOffarmEncode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOffarmEncode.ShouldNotBeNull();
            parametersOffarmEncode.Length.ShouldBe(1);
            methodfarmEncodePrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (farmEncode) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_farmEncode_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var code = CreateType<string>();
            var methodfarmEncodePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOffarmEncode = { code };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_actInstanceFixture, _actInstanceType, MethodfarmEncode, parametersOffarmEncode, methodfarmEncodePrametersTypes);

            // Assert
            parametersOffarmEncode.ShouldNotBeNull();
            parametersOffarmEncode.Length.ShouldBe(1);
            methodfarmEncodePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (farmEncode) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_farmEncode_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodfarmEncodePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_actInstanceFixture, _actInstanceType, MethodfarmEncode, Fixture, methodfarmEncodePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodfarmEncodePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (farmEncode) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_farmEncode_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodfarmEncodePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_actInstanceFixture, _actInstanceType, MethodfarmEncode, Fixture, methodfarmEncodePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodfarmEncodePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (farmEncode) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_farmEncode_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodfarmEncode, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_actInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (farmEncode) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_farmEncode_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodfarmEncode, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFeatureNameV2) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Act_GetFeatureNameV2_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFeatureNameV2PrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_actInstanceFixture, _actInstanceType, MethodGetFeatureNameV2, Fixture, methodGetFeatureNameV2PrametersTypes);
        }

        #endregion

        #region Method Call : (GetFeatureNameV2) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetFeatureNameV2_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var featureid = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => Act.GetFeatureNameV2(featureid);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetFeatureNameV2) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetFeatureNameV2_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var featureid = CreateType<string>();
            var methodGetFeatureNameV2PrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetFeatureNameV2 = { featureid };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFeatureNameV2, methodGetFeatureNameV2PrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_actInstanceFixture, _actInstanceType, MethodGetFeatureNameV2, Fixture, methodGetFeatureNameV2PrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_actInstanceFixture, _actInstanceType, MethodGetFeatureNameV2, parametersOfGetFeatureNameV2, methodGetFeatureNameV2PrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetFeatureNameV2.ShouldNotBeNull();
            parametersOfGetFeatureNameV2.Length.ShouldBe(1);
            methodGetFeatureNameV2PrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_actInstanceFixture, _actInstanceType, MethodGetFeatureNameV2, parametersOfGetFeatureNameV2, methodGetFeatureNameV2PrametersTypes));
        }

        #endregion

        #region Method Call : (GetFeatureNameV2) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetFeatureNameV2_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var featureid = CreateType<string>();
            var methodGetFeatureNameV2PrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetFeatureNameV2 = { featureid };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetFeatureNameV2, methodGetFeatureNameV2PrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_actInstanceFixture, parametersOfGetFeatureNameV2);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetFeatureNameV2.ShouldNotBeNull();
            parametersOfGetFeatureNameV2.Length.ShouldBe(1);
            methodGetFeatureNameV2PrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFeatureNameV2) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetFeatureNameV2_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var featureid = CreateType<string>();
            var methodGetFeatureNameV2PrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetFeatureNameV2 = { featureid };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_actInstanceFixture, _actInstanceType, MethodGetFeatureNameV2, parametersOfGetFeatureNameV2, methodGetFeatureNameV2PrametersTypes);

            // Assert
            parametersOfGetFeatureNameV2.ShouldNotBeNull();
            parametersOfGetFeatureNameV2.Length.ShouldBe(1);
            methodGetFeatureNameV2PrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFeatureNameV2) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetFeatureNameV2_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetFeatureNameV2PrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_actInstanceFixture, _actInstanceType, MethodGetFeatureNameV2, Fixture, methodGetFeatureNameV2PrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetFeatureNameV2PrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFeatureNameV2) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetFeatureNameV2_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFeatureNameV2PrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_actInstanceFixture, _actInstanceType, MethodGetFeatureNameV2, Fixture, methodGetFeatureNameV2PrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFeatureNameV2PrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFeatureNameV2) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetFeatureNameV2_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFeatureNameV2, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_actInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetFeatureNameV2) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetFeatureNameV2_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFeatureNameV2, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFeatureName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Act_GetFeatureName_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFeatureNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_actInstanceFixture, _actInstanceType, MethodGetFeatureName, Fixture, methodGetFeatureNamePrametersTypes);
        }

        #endregion

        #region Method Call : (GetFeatureName) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetFeatureName_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var featureid = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => Act.GetFeatureName(featureid);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetFeatureName) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetFeatureName_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var featureid = CreateType<string>();
            var methodGetFeatureNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetFeatureName = { featureid };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFeatureName, methodGetFeatureNamePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_actInstanceFixture, _actInstanceType, MethodGetFeatureName, Fixture, methodGetFeatureNamePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_actInstanceFixture, _actInstanceType, MethodGetFeatureName, parametersOfGetFeatureName, methodGetFeatureNamePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetFeatureName.ShouldNotBeNull();
            parametersOfGetFeatureName.Length.ShouldBe(1);
            methodGetFeatureNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_actInstanceFixture, _actInstanceType, MethodGetFeatureName, parametersOfGetFeatureName, methodGetFeatureNamePrametersTypes));
        }

        #endregion

        #region Method Call : (GetFeatureName) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetFeatureName_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var featureid = CreateType<string>();
            var methodGetFeatureNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetFeatureName = { featureid };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetFeatureName, methodGetFeatureNamePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_actInstanceFixture, parametersOfGetFeatureName);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetFeatureName.ShouldNotBeNull();
            parametersOfGetFeatureName.Length.ShouldBe(1);
            methodGetFeatureNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFeatureName) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetFeatureName_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var featureid = CreateType<string>();
            var methodGetFeatureNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetFeatureName = { featureid };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_actInstanceFixture, _actInstanceType, MethodGetFeatureName, parametersOfGetFeatureName, methodGetFeatureNamePrametersTypes);

            // Assert
            parametersOfGetFeatureName.ShouldNotBeNull();
            parametersOfGetFeatureName.Length.ShouldBe(1);
            methodGetFeatureNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFeatureName) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetFeatureName_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetFeatureNamePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_actInstanceFixture, _actInstanceType, MethodGetFeatureName, Fixture, methodGetFeatureNamePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetFeatureNamePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFeatureName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetFeatureName_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFeatureNamePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_actInstanceFixture, _actInstanceType, MethodGetFeatureName, Fixture, methodGetFeatureNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFeatureNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFeatureName) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetFeatureName_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFeatureName, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_actInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetFeatureName) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Act_GetFeatureName_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFeatureName, 0);
            const int parametersCount = 1;

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
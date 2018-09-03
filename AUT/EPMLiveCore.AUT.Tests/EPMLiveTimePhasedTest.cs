using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
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
using EPMLiveCore.Infrastructure.Logging;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using static EPMLiveCore.Infrastructure.Logging.LoggingService;
using EPMLiveCore;
using EPMLiveTimePhased = EPMLiveCore;
using DocumentFormat.OpenXml.Drawing.Charts;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.EPMLiveTimePhased" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class EPMLiveTimePhasedTest : AbstractBaseSetupTypedTest<EPMLiveTimePhased>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EPMLiveTimePhased) Initializer

        private const string MethoddoTSData = "doTSData";
        private const string MethodgetConfigSetting = "getConfigSetting";
        private const string MethodsaveTimePhasedData = "saveTimePhasedData";
        private const string MethodgetAllValueTypes = "getAllValueTypes";
        private const string MethodiGetAllValueTypes = "iGetAllValueTypes";
        private const string MethodgetAllTimePeriods = "getAllTimePeriods";
        private const string MethodiGetAllTimePeriods = "iGetAllTimePeriods";
        private const string MethodgetPublisherSettings = "getPublisherSettings";
        private const string MethodcanPublishToSite = "canPublishToSite";
        private Type _ePMLiveTimePhasedInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private EPMLiveTimePhased _ePMLiveTimePhasedInstance;
        private EPMLiveTimePhased _ePMLiveTimePhasedInstanceFixture;

        #region General Initializer : Class (EPMLiveTimePhased) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EPMLiveTimePhased" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _ePMLiveTimePhasedInstanceType = typeof(EPMLiveTimePhased);
            _ePMLiveTimePhasedInstanceFixture = Create(true);
            _ePMLiveTimePhasedInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (EPMLiveTimePhased)

        #region General Initializer : Class (EPMLiveTimePhased) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="EPMLiveTimePhased" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(MethoddoTSData, 0)]
        [TestCase(MethodgetConfigSetting, 0)]
        [TestCase(MethodsaveTimePhasedData, 0)]
        [TestCase(MethodgetAllValueTypes, 0)]
        [TestCase(MethodiGetAllValueTypes, 0)]
        [TestCase(MethodgetAllTimePeriods, 0)]
        [TestCase(MethodiGetAllTimePeriods, 0)]
        [TestCase(MethodgetPublisherSettings, 0)]
        [TestCase(MethodcanPublishToSite, 0)]
        public void AUT_EPMLiveTimePhased_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_ePMLiveTimePhasedInstanceFixture, 
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
        ///     Class (<see cref="EPMLiveTimePhased" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_EPMLiveTimePhased_Is_Instance_Present_Test()
        {
            // Assert
            _ePMLiveTimePhasedInstanceType.ShouldNotBeNull();
            _ePMLiveTimePhasedInstance.ShouldNotBeNull();
            _ePMLiveTimePhasedInstanceFixture.ShouldNotBeNull();
            _ePMLiveTimePhasedInstance.ShouldBeAssignableTo<EPMLiveTimePhased>();
            _ePMLiveTimePhasedInstanceFixture.ShouldBeAssignableTo<EPMLiveTimePhased>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (EPMLiveTimePhased) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_EPMLiveTimePhased_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            EPMLiveTimePhased instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _ePMLiveTimePhasedInstanceType.ShouldNotBeNull();
            _ePMLiveTimePhasedInstance.ShouldNotBeNull();
            _ePMLiveTimePhasedInstanceFixture.ShouldNotBeNull();
            _ePMLiveTimePhasedInstance.ShouldBeAssignableTo<EPMLiveTimePhased>();
            _ePMLiveTimePhasedInstanceFixture.ShouldBeAssignableTo<EPMLiveTimePhased>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="EPMLiveTimePhased" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        [TestCase(MethoddoTSData)]
        [TestCase(MethodgetConfigSetting)]
        [TestCase(MethodsaveTimePhasedData)]
        [TestCase(MethodgetAllValueTypes)]
        [TestCase(MethodiGetAllValueTypes)]
        [TestCase(MethodgetAllTimePeriods)]
        [TestCase(MethodiGetAllTimePeriods)]
        [TestCase(MethodgetPublisherSettings)]
        [TestCase(MethodcanPublishToSite)]
        public void AUT_EPMLiveTimePhased_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<EPMLiveTimePhased>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (doTSData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveTimePhased_doTSData_Method_Call_Internally(Type[] types)
        {
            var methoddoTSDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveTimePhasedInstance, MethoddoTSData, Fixture, methoddoTSDataPrametersTypes);
        }

        #endregion

        #region Method Call : (doTSData) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_doTSData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<object>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMLiveTimePhasedInstance.doTSData(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (doTSData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_doTSData_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<object>();
            var methoddoTSDataPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfdoTSData = { data };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethoddoTSData, methoddoTSDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePMLiveTimePhasedInstanceFixture, parametersOfdoTSData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfdoTSData.ShouldNotBeNull();
            parametersOfdoTSData.Length.ShouldBe(1);
            methoddoTSDataPrametersTypes.Length.ShouldBe(1);
            methoddoTSDataPrametersTypes.Length.ShouldBe(parametersOfdoTSData.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (doTSData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_doTSData_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<object>();
            var methoddoTSDataPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfdoTSData = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ePMLiveTimePhasedInstance, MethoddoTSData, parametersOfdoTSData, methoddoTSDataPrametersTypes);

            // Assert
            parametersOfdoTSData.ShouldNotBeNull();
            parametersOfdoTSData.Length.ShouldBe(1);
            methoddoTSDataPrametersTypes.Length.ShouldBe(1);
            methoddoTSDataPrametersTypes.Length.ShouldBe(parametersOfdoTSData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (doTSData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_doTSData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethoddoTSData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (doTSData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_doTSData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methoddoTSDataPrametersTypes = new Type[] { typeof(object) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveTimePhasedInstance, MethoddoTSData, Fixture, methoddoTSDataPrametersTypes);

            // Assert
            methoddoTSDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (doTSData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_doTSData_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethoddoTSData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMLiveTimePhasedInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getConfigSetting) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveTimePhased_getConfigSetting_Method_Call_Internally(Type[] types)
        {
            var methodgetConfigSettingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveTimePhasedInstance, MethodgetConfigSetting, Fixture, methodgetConfigSettingPrametersTypes);
        }

        #endregion

        #region Method Call : (getConfigSetting) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_getConfigSetting_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var setting = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMLiveTimePhasedInstance.getConfigSetting(setting);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (getConfigSetting) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_getConfigSetting_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var setting = CreateType<string>();
            var methodgetConfigSettingPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfgetConfigSetting = { setting };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodgetConfigSetting, methodgetConfigSettingPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMLiveTimePhased, string>(_ePMLiveTimePhasedInstanceFixture, out exception1, parametersOfgetConfigSetting);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMLiveTimePhased, string>(_ePMLiveTimePhasedInstance, MethodgetConfigSetting, parametersOfgetConfigSetting, methodgetConfigSettingPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetConfigSetting.ShouldNotBeNull();
            parametersOfgetConfigSetting.Length.ShouldBe(1);
            methodgetConfigSettingPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getConfigSetting) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_getConfigSetting_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var setting = CreateType<string>();
            var methodgetConfigSettingPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfgetConfigSetting = { setting };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMLiveTimePhased, string>(_ePMLiveTimePhasedInstance, MethodgetConfigSetting, parametersOfgetConfigSetting, methodgetConfigSettingPrametersTypes);

            // Assert
            parametersOfgetConfigSetting.ShouldNotBeNull();
            parametersOfgetConfigSetting.Length.ShouldBe(1);
            methodgetConfigSettingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getConfigSetting) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_getConfigSetting_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetConfigSettingPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveTimePhasedInstance, MethodgetConfigSetting, Fixture, methodgetConfigSettingPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetConfigSettingPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getConfigSetting) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_getConfigSetting_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetConfigSettingPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveTimePhasedInstance, MethodgetConfigSetting, Fixture, methodgetConfigSettingPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetConfigSettingPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getConfigSetting) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_getConfigSetting_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetConfigSetting, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMLiveTimePhasedInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getConfigSetting) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_getConfigSetting_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetConfigSetting, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (saveTimePhasedData) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveTimePhased_saveTimePhasedData_Method_Call_Internally(Type[] types)
        {
            var methodsaveTimePhasedDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveTimePhasedInstance, MethodsaveTimePhasedData, Fixture, methodsaveTimePhasedDataPrametersTypes);
        }

        #endregion

        #region Method Call : (saveTimePhasedData) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_saveTimePhasedData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sUrl = CreateType<string>();
            var sProject = CreateType<string>();
            var sData = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMLiveTimePhasedInstance.saveTimePhasedData(sUrl, sProject, sData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (saveTimePhasedData) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_saveTimePhasedData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sUrl = CreateType<string>();
            var sProject = CreateType<string>();
            var sData = CreateType<string>();
            var methodsaveTimePhasedDataPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            object[] parametersOfsaveTimePhasedData = { sUrl, sProject, sData };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodsaveTimePhasedData, methodsaveTimePhasedDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMLiveTimePhased, bool>(_ePMLiveTimePhasedInstanceFixture, out exception1, parametersOfsaveTimePhasedData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMLiveTimePhased, bool>(_ePMLiveTimePhasedInstance, MethodsaveTimePhasedData, parametersOfsaveTimePhasedData, methodsaveTimePhasedDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfsaveTimePhasedData.ShouldNotBeNull();
            parametersOfsaveTimePhasedData.Length.ShouldBe(3);
            methodsaveTimePhasedDataPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (saveTimePhasedData) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_saveTimePhasedData_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sUrl = CreateType<string>();
            var sProject = CreateType<string>();
            var sData = CreateType<string>();
            var methodsaveTimePhasedDataPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            object[] parametersOfsaveTimePhasedData = { sUrl, sProject, sData };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodsaveTimePhasedData, methodsaveTimePhasedDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMLiveTimePhased, bool>(_ePMLiveTimePhasedInstanceFixture, out exception1, parametersOfsaveTimePhasedData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMLiveTimePhased, bool>(_ePMLiveTimePhasedInstance, MethodsaveTimePhasedData, parametersOfsaveTimePhasedData, methodsaveTimePhasedDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfsaveTimePhasedData.ShouldNotBeNull();
            parametersOfsaveTimePhasedData.Length.ShouldBe(3);
            methodsaveTimePhasedDataPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (saveTimePhasedData) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_saveTimePhasedData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sUrl = CreateType<string>();
            var sProject = CreateType<string>();
            var sData = CreateType<string>();
            var methodsaveTimePhasedDataPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            object[] parametersOfsaveTimePhasedData = { sUrl, sProject, sData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMLiveTimePhased, bool>(_ePMLiveTimePhasedInstance, MethodsaveTimePhasedData, parametersOfsaveTimePhasedData, methodsaveTimePhasedDataPrametersTypes);

            // Assert
            parametersOfsaveTimePhasedData.ShouldNotBeNull();
            parametersOfsaveTimePhasedData.Length.ShouldBe(3);
            methodsaveTimePhasedDataPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (saveTimePhasedData) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_saveTimePhasedData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodsaveTimePhasedDataPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveTimePhasedInstance, MethodsaveTimePhasedData, Fixture, methodsaveTimePhasedDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodsaveTimePhasedDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (saveTimePhasedData) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_saveTimePhasedData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodsaveTimePhasedData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMLiveTimePhasedInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (saveTimePhasedData) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_saveTimePhasedData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodsaveTimePhasedData, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getAllValueTypes) (Return Type : string[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveTimePhased_getAllValueTypes_Method_Call_Internally(Type[] types)
        {
            var methodgetAllValueTypesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveTimePhasedInstance, MethodgetAllValueTypes, Fixture, methodgetAllValueTypesPrametersTypes);
        }

        #endregion

        #region Method Call : (getAllValueTypes) (Return Type : string[]) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_getAllValueTypes_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sUrl = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMLiveTimePhasedInstance.getAllValueTypes(sUrl);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (getAllValueTypes) (Return Type : string[]) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_getAllValueTypes_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sUrl = CreateType<string>();
            var methodgetAllValueTypesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfgetAllValueTypes = { sUrl };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodgetAllValueTypes, methodgetAllValueTypesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMLiveTimePhased, string[]>(_ePMLiveTimePhasedInstanceFixture, out exception1, parametersOfgetAllValueTypes);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMLiveTimePhased, string[]>(_ePMLiveTimePhasedInstance, MethodgetAllValueTypes, parametersOfgetAllValueTypes, methodgetAllValueTypesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfgetAllValueTypes.ShouldNotBeNull();
            parametersOfgetAllValueTypes.Length.ShouldBe(1);
            methodgetAllValueTypesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getAllValueTypes) (Return Type : string[]) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_getAllValueTypes_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sUrl = CreateType<string>();
            var methodgetAllValueTypesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfgetAllValueTypes = { sUrl };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetAllValueTypes, methodgetAllValueTypesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePMLiveTimePhasedInstanceFixture, parametersOfgetAllValueTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetAllValueTypes.ShouldNotBeNull();
            parametersOfgetAllValueTypes.Length.ShouldBe(1);
            methodgetAllValueTypesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getAllValueTypes) (Return Type : string[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_getAllValueTypes_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sUrl = CreateType<string>();
            var methodgetAllValueTypesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfgetAllValueTypes = { sUrl };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMLiveTimePhased, string[]>(_ePMLiveTimePhasedInstance, MethodgetAllValueTypes, parametersOfgetAllValueTypes, methodgetAllValueTypesPrametersTypes);

            // Assert
            parametersOfgetAllValueTypes.ShouldNotBeNull();
            parametersOfgetAllValueTypes.Length.ShouldBe(1);
            methodgetAllValueTypesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getAllValueTypes) (Return Type : string[]) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_getAllValueTypes_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodgetAllValueTypesPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveTimePhasedInstance, MethodgetAllValueTypes, Fixture, methodgetAllValueTypesPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodgetAllValueTypesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getAllValueTypes) (Return Type : string[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_getAllValueTypes_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetAllValueTypesPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveTimePhasedInstance, MethodgetAllValueTypes, Fixture, methodgetAllValueTypesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetAllValueTypesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getAllValueTypes) (Return Type : string[]) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_getAllValueTypes_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetAllValueTypes, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMLiveTimePhasedInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getAllValueTypes) (Return Type : string[]) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_getAllValueTypes_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetAllValueTypes, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iGetAllValueTypes) (Return Type : string[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveTimePhased_iGetAllValueTypes_Method_Call_Internally(Type[] types)
        {
            var methodiGetAllValueTypesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveTimePhasedInstance, MethodiGetAllValueTypes, Fixture, methodiGetAllValueTypesPrametersTypes);
        }

        #endregion

        #region Method Call : (iGetAllValueTypes) (Return Type : string[]) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_iGetAllValueTypes_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodiGetAllValueTypesPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfiGetAllValueTypes = { web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodiGetAllValueTypes, methodiGetAllValueTypesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePMLiveTimePhasedInstanceFixture, parametersOfiGetAllValueTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfiGetAllValueTypes.ShouldNotBeNull();
            parametersOfiGetAllValueTypes.Length.ShouldBe(1);
            methodiGetAllValueTypesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iGetAllValueTypes) (Return Type : string[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_iGetAllValueTypes_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodiGetAllValueTypesPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfiGetAllValueTypes = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMLiveTimePhased, string[]>(_ePMLiveTimePhasedInstance, MethodiGetAllValueTypes, parametersOfiGetAllValueTypes, methodiGetAllValueTypesPrametersTypes);

            // Assert
            parametersOfiGetAllValueTypes.ShouldNotBeNull();
            parametersOfiGetAllValueTypes.Length.ShouldBe(1);
            methodiGetAllValueTypesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iGetAllValueTypes) (Return Type : string[]) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_iGetAllValueTypes_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodiGetAllValueTypesPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveTimePhasedInstance, MethodiGetAllValueTypes, Fixture, methodiGetAllValueTypesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodiGetAllValueTypesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (iGetAllValueTypes) (Return Type : string[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_iGetAllValueTypes_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodiGetAllValueTypesPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveTimePhasedInstance, MethodiGetAllValueTypes, Fixture, methodiGetAllValueTypesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodiGetAllValueTypesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iGetAllValueTypes) (Return Type : string[]) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_iGetAllValueTypes_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodiGetAllValueTypes, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMLiveTimePhasedInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (iGetAllValueTypes) (Return Type : string[]) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_iGetAllValueTypes_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodiGetAllValueTypes, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getAllTimePeriods) (Return Type : Period[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveTimePhased_getAllTimePeriods_Method_Call_Internally(Type[] types)
        {
            var methodgetAllTimePeriodsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveTimePhasedInstance, MethodgetAllTimePeriods, Fixture, methodgetAllTimePeriodsPrametersTypes);
        }

        #endregion

        #region Method Call : (getAllTimePeriods) (Return Type : Period[]) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_getAllTimePeriods_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sUrl = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMLiveTimePhasedInstance.getAllTimePeriods(sUrl);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (getAllTimePeriods) (Return Type : Period[]) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_getAllTimePeriods_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sUrl = CreateType<string>();
            var methodgetAllTimePeriodsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfgetAllTimePeriods = { sUrl };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodgetAllTimePeriods, methodgetAllTimePeriodsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMLiveTimePhased, Period[]>(_ePMLiveTimePhasedInstanceFixture, out exception1, parametersOfgetAllTimePeriods);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMLiveTimePhased, Period[]>(_ePMLiveTimePhasedInstance, MethodgetAllTimePeriods, parametersOfgetAllTimePeriods, methodgetAllTimePeriodsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetAllTimePeriods.ShouldNotBeNull();
            parametersOfgetAllTimePeriods.Length.ShouldBe(1);
            methodgetAllTimePeriodsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getAllTimePeriods) (Return Type : Period[]) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_getAllTimePeriods_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sUrl = CreateType<string>();
            var methodgetAllTimePeriodsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfgetAllTimePeriods = { sUrl };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetAllTimePeriods, methodgetAllTimePeriodsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePMLiveTimePhasedInstanceFixture, parametersOfgetAllTimePeriods);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetAllTimePeriods.ShouldNotBeNull();
            parametersOfgetAllTimePeriods.Length.ShouldBe(1);
            methodgetAllTimePeriodsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getAllTimePeriods) (Return Type : Period[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_getAllTimePeriods_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sUrl = CreateType<string>();
            var methodgetAllTimePeriodsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfgetAllTimePeriods = { sUrl };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMLiveTimePhased, Period[]>(_ePMLiveTimePhasedInstance, MethodgetAllTimePeriods, parametersOfgetAllTimePeriods, methodgetAllTimePeriodsPrametersTypes);

            // Assert
            parametersOfgetAllTimePeriods.ShouldNotBeNull();
            parametersOfgetAllTimePeriods.Length.ShouldBe(1);
            methodgetAllTimePeriodsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getAllTimePeriods) (Return Type : Period[]) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_getAllTimePeriods_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodgetAllTimePeriodsPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveTimePhasedInstance, MethodgetAllTimePeriods, Fixture, methodgetAllTimePeriodsPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodgetAllTimePeriodsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getAllTimePeriods) (Return Type : Period[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_getAllTimePeriods_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetAllTimePeriodsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveTimePhasedInstance, MethodgetAllTimePeriods, Fixture, methodgetAllTimePeriodsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetAllTimePeriodsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getAllTimePeriods) (Return Type : Period[]) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_getAllTimePeriods_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetAllTimePeriods, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMLiveTimePhasedInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getAllTimePeriods) (Return Type : Period[]) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_getAllTimePeriods_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetAllTimePeriods, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iGetAllTimePeriods) (Return Type : Period[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveTimePhased_iGetAllTimePeriods_Method_Call_Internally(Type[] types)
        {
            var methodiGetAllTimePeriodsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveTimePhasedInstance, MethodiGetAllTimePeriods, Fixture, methodiGetAllTimePeriodsPrametersTypes);
        }

        #endregion

        #region Method Call : (iGetAllTimePeriods) (Return Type : Period[]) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_iGetAllTimePeriods_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodiGetAllTimePeriodsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfiGetAllTimePeriods = { web };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodiGetAllTimePeriods, methodiGetAllTimePeriodsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMLiveTimePhased, Period[]>(_ePMLiveTimePhasedInstanceFixture, out exception1, parametersOfiGetAllTimePeriods);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMLiveTimePhased, Period[]>(_ePMLiveTimePhasedInstance, MethodiGetAllTimePeriods, parametersOfiGetAllTimePeriods, methodiGetAllTimePeriodsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfiGetAllTimePeriods.ShouldNotBeNull();
            parametersOfiGetAllTimePeriods.Length.ShouldBe(1);
            methodiGetAllTimePeriodsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (iGetAllTimePeriods) (Return Type : Period[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_iGetAllTimePeriods_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodiGetAllTimePeriodsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfiGetAllTimePeriods = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMLiveTimePhased, Period[]>(_ePMLiveTimePhasedInstance, MethodiGetAllTimePeriods, parametersOfiGetAllTimePeriods, methodiGetAllTimePeriodsPrametersTypes);

            // Assert
            parametersOfiGetAllTimePeriods.ShouldNotBeNull();
            parametersOfiGetAllTimePeriods.Length.ShouldBe(1);
            methodiGetAllTimePeriodsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iGetAllTimePeriods) (Return Type : Period[]) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_iGetAllTimePeriods_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodiGetAllTimePeriodsPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveTimePhasedInstance, MethodiGetAllTimePeriods, Fixture, methodiGetAllTimePeriodsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodiGetAllTimePeriodsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (iGetAllTimePeriods) (Return Type : Period[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_iGetAllTimePeriods_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodiGetAllTimePeriodsPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveTimePhasedInstance, MethodiGetAllTimePeriods, Fixture, methodiGetAllTimePeriodsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodiGetAllTimePeriodsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iGetAllTimePeriods) (Return Type : Period[]) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_iGetAllTimePeriods_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodiGetAllTimePeriods, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMLiveTimePhasedInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (iGetAllTimePeriods) (Return Type : Period[]) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_iGetAllTimePeriods_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodiGetAllTimePeriods, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getPublisherSettings) (Return Type : string[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveTimePhased_getPublisherSettings_Method_Call_Internally(Type[] types)
        {
            var methodgetPublisherSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveTimePhasedInstance, MethodgetPublisherSettings, Fixture, methodgetPublisherSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (getPublisherSettings) (Return Type : string[]) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_getPublisherSettings_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _ePMLiveTimePhasedInstance.getPublisherSettings();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (getPublisherSettings) (Return Type : string[]) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_getPublisherSettings_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodgetPublisherSettingsPrametersTypes = null;
            object[] parametersOfgetPublisherSettings = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodgetPublisherSettings, methodgetPublisherSettingsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMLiveTimePhased, string[]>(_ePMLiveTimePhasedInstanceFixture, out exception1, parametersOfgetPublisherSettings);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMLiveTimePhased, string[]>(_ePMLiveTimePhasedInstance, MethodgetPublisherSettings, parametersOfgetPublisherSettings, methodgetPublisherSettingsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetPublisherSettings.ShouldBeNull();
            methodgetPublisherSettingsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getPublisherSettings) (Return Type : string[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_getPublisherSettings_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodgetPublisherSettingsPrametersTypes = null;
            object[] parametersOfgetPublisherSettings = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMLiveTimePhased, string[]>(_ePMLiveTimePhasedInstance, MethodgetPublisherSettings, parametersOfgetPublisherSettings, methodgetPublisherSettingsPrametersTypes);

            // Assert
            parametersOfgetPublisherSettings.ShouldBeNull();
            methodgetPublisherSettingsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getPublisherSettings) (Return Type : string[]) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_getPublisherSettings_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodgetPublisherSettingsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveTimePhasedInstance, MethodgetPublisherSettings, Fixture, methodgetPublisherSettingsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetPublisherSettingsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getPublisherSettings) (Return Type : string[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_getPublisherSettings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodgetPublisherSettingsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveTimePhasedInstance, MethodgetPublisherSettings, Fixture, methodgetPublisherSettingsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetPublisherSettingsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getPublisherSettings) (Return Type : string[]) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_getPublisherSettings_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetPublisherSettings, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMLiveTimePhasedInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (canPublishToSite) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveTimePhased_canPublishToSite_Method_Call_Internally(Type[] types)
        {
            var methodcanPublishToSitePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveTimePhasedInstance, MethodcanPublishToSite, Fixture, methodcanPublishToSitePrametersTypes);
        }

        #endregion

        #region Method Call : (canPublishToSite) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_canPublishToSite_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _ePMLiveTimePhasedInstance.canPublishToSite();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (canPublishToSite) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_canPublishToSite_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodcanPublishToSitePrametersTypes = null;
            object[] parametersOfcanPublishToSite = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodcanPublishToSite, methodcanPublishToSitePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMLiveTimePhased, bool>(_ePMLiveTimePhasedInstanceFixture, out exception1, parametersOfcanPublishToSite);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMLiveTimePhased, bool>(_ePMLiveTimePhasedInstance, MethodcanPublishToSite, parametersOfcanPublishToSite, methodcanPublishToSitePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfcanPublishToSite.ShouldBeNull();
            methodcanPublishToSitePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (canPublishToSite) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_canPublishToSite_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodcanPublishToSitePrametersTypes = null;
            object[] parametersOfcanPublishToSite = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodcanPublishToSite, methodcanPublishToSitePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMLiveTimePhased, bool>(_ePMLiveTimePhasedInstanceFixture, out exception1, parametersOfcanPublishToSite);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMLiveTimePhased, bool>(_ePMLiveTimePhasedInstance, MethodcanPublishToSite, parametersOfcanPublishToSite, methodcanPublishToSitePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfcanPublishToSite.ShouldBeNull();
            methodcanPublishToSitePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (canPublishToSite) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_canPublishToSite_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodcanPublishToSitePrametersTypes = null;
            object[] parametersOfcanPublishToSite = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodcanPublishToSite, methodcanPublishToSitePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePMLiveTimePhasedInstanceFixture, parametersOfcanPublishToSite);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfcanPublishToSite.ShouldBeNull();
            methodcanPublishToSitePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (canPublishToSite) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_canPublishToSite_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodcanPublishToSitePrametersTypes = null;
            object[] parametersOfcanPublishToSite = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPMLiveTimePhased, bool>(_ePMLiveTimePhasedInstance, MethodcanPublishToSite, parametersOfcanPublishToSite, methodcanPublishToSitePrametersTypes);

            // Assert
            parametersOfcanPublishToSite.ShouldBeNull();
            methodcanPublishToSitePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (canPublishToSite) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_canPublishToSite_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodcanPublishToSitePrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveTimePhasedInstance, MethodcanPublishToSite, Fixture, methodcanPublishToSitePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodcanPublishToSitePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (canPublishToSite) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_canPublishToSite_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodcanPublishToSitePrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveTimePhasedInstance, MethodcanPublishToSite, Fixture, methodcanPublishToSitePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodcanPublishToSitePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (canPublishToSite) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_canPublishToSite_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodcanPublishToSitePrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveTimePhasedInstance, MethodcanPublishToSite, Fixture, methodcanPublishToSitePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodcanPublishToSitePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (canPublishToSite) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_EPMLiveTimePhased_canPublishToSite_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodcanPublishToSite, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMLiveTimePhasedInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion
    }
}
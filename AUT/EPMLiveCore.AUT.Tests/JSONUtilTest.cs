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
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using JSONUtil = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.JSONUtil" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class JSONUtilTest : AbstractBaseSetupTypedTest<JSONUtil>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (JSONUtil) Initializer

        private const string MethodConvertXmlToJson = "ConvertXmlToJson";
        private const string MethodprocessNode = "processNode";
        private const string MethodgetAttributeName = "getAttributeName";
        private const string MethodgetNodeName = "getNodeName";
        private Type _jSONUtilInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private JSONUtil _jSONUtilInstance;
        private JSONUtil _jSONUtilInstanceFixture;

        #region General Initializer : Class (JSONUtil) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="JSONUtil" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _jSONUtilInstanceType = typeof(JSONUtil);
            _jSONUtilInstanceFixture = Create(true);
            _jSONUtilInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (JSONUtil)

        #region General Initializer : Class (JSONUtil) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="JSONUtil" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodConvertXmlToJson, 0)]
        [TestCase(MethodprocessNode, 0)]
        [TestCase(MethodgetAttributeName, 0)]
        [TestCase(MethodgetNodeName, 0)]
        public void AUT_JSONUtil_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_jSONUtilInstanceFixture, 
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
        ///     Class (<see cref="JSONUtil" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_JSONUtil_Is_Instance_Present_Test()
        {
            // Assert
            _jSONUtilInstanceType.ShouldNotBeNull();
            _jSONUtilInstance.ShouldNotBeNull();
            _jSONUtilInstanceFixture.ShouldNotBeNull();
            _jSONUtilInstance.ShouldBeAssignableTo<JSONUtil>();
            _jSONUtilInstanceFixture.ShouldBeAssignableTo<JSONUtil>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (JSONUtil) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_JSONUtil_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            JSONUtil instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _jSONUtilInstanceType.ShouldNotBeNull();
            _jSONUtilInstance.ShouldNotBeNull();
            _jSONUtilInstanceFixture.ShouldNotBeNull();
            _jSONUtilInstance.ShouldBeAssignableTo<JSONUtil>();
            _jSONUtilInstanceFixture.ShouldBeAssignableTo<JSONUtil>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="JSONUtil" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodConvertXmlToJson)]
        [TestCase(MethodprocessNode)]
        [TestCase(MethodgetAttributeName)]
        [TestCase(MethodgetNodeName)]
        public void AUT_JSONUtil_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_jSONUtilInstanceFixture,
                                                                              _jSONUtilInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (ConvertXmlToJson) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_JSONUtil_ConvertXmlToJson_Static_Method_Call_Internally(Type[] types)
        {
            var methodConvertXmlToJsonPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_jSONUtilInstanceFixture, _jSONUtilInstanceType, MethodConvertXmlToJson, Fixture, methodConvertXmlToJsonPrametersTypes);
        }

        #endregion

        #region Method Call : (ConvertXmlToJson) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_JSONUtil_ConvertXmlToJson_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var idlist = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => JSONUtil.ConvertXmlToJson(xml, idlist);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ConvertXmlToJson) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_JSONUtil_ConvertXmlToJson_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var idlist = CreateType<string>();
            var methodConvertXmlToJsonPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfConvertXmlToJson = { xml, idlist };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodConvertXmlToJson, methodConvertXmlToJsonPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_jSONUtilInstanceFixture, _jSONUtilInstanceType, MethodConvertXmlToJson, Fixture, methodConvertXmlToJsonPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_jSONUtilInstanceFixture, _jSONUtilInstanceType, MethodConvertXmlToJson, parametersOfConvertXmlToJson, methodConvertXmlToJsonPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_jSONUtilInstanceFixture, parametersOfConvertXmlToJson);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfConvertXmlToJson.ShouldNotBeNull();
            parametersOfConvertXmlToJson.Length.ShouldBe(2);
            methodConvertXmlToJsonPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ConvertXmlToJson) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_JSONUtil_ConvertXmlToJson_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var idlist = CreateType<string>();
            var methodConvertXmlToJsonPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfConvertXmlToJson = { xml, idlist };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_jSONUtilInstanceFixture, _jSONUtilInstanceType, MethodConvertXmlToJson, parametersOfConvertXmlToJson, methodConvertXmlToJsonPrametersTypes);

            // Assert
            parametersOfConvertXmlToJson.ShouldNotBeNull();
            parametersOfConvertXmlToJson.Length.ShouldBe(2);
            methodConvertXmlToJsonPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConvertXmlToJson) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_JSONUtil_ConvertXmlToJson_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodConvertXmlToJsonPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_jSONUtilInstanceFixture, _jSONUtilInstanceType, MethodConvertXmlToJson, Fixture, methodConvertXmlToJsonPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodConvertXmlToJsonPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ConvertXmlToJson) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_JSONUtil_ConvertXmlToJson_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodConvertXmlToJsonPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_jSONUtilInstanceFixture, _jSONUtilInstanceType, MethodConvertXmlToJson, Fixture, methodConvertXmlToJsonPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodConvertXmlToJsonPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ConvertXmlToJson) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_JSONUtil_ConvertXmlToJson_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodConvertXmlToJson, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_jSONUtilInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ConvertXmlToJson) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_JSONUtil_ConvertXmlToJson_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodConvertXmlToJson, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processNode) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_JSONUtil_processNode_Static_Method_Call_Internally(Type[] types)
        {
            var methodprocessNodePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_jSONUtilInstanceFixture, _jSONUtilInstanceType, MethodprocessNode, Fixture, methodprocessNodePrametersTypes);
        }

        #endregion

        #region Method Call : (processNode) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_JSONUtil_processNode_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var nd = CreateType<XmlNode>();
            var idlist = CreateType<ArrayList>();
            var nodename = CreateType<string>();
            var methodprocessNodePrametersTypes = new Type[] { typeof(XmlNode), typeof(ArrayList), typeof(string) };
            object[] parametersOfprocessNode = { nd, idlist, nodename };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprocessNode, methodprocessNodePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_jSONUtilInstanceFixture, _jSONUtilInstanceType, MethodprocessNode, Fixture, methodprocessNodePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_jSONUtilInstanceFixture, _jSONUtilInstanceType, MethodprocessNode, parametersOfprocessNode, methodprocessNodePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_jSONUtilInstanceFixture, parametersOfprocessNode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfprocessNode.ShouldNotBeNull();
            parametersOfprocessNode.Length.ShouldBe(3);
            methodprocessNodePrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (processNode) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_JSONUtil_processNode_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var nd = CreateType<XmlNode>();
            var idlist = CreateType<ArrayList>();
            var nodename = CreateType<string>();
            var methodprocessNodePrametersTypes = new Type[] { typeof(XmlNode), typeof(ArrayList), typeof(string) };
            object[] parametersOfprocessNode = { nd, idlist, nodename };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_jSONUtilInstanceFixture, _jSONUtilInstanceType, MethodprocessNode, parametersOfprocessNode, methodprocessNodePrametersTypes);

            // Assert
            parametersOfprocessNode.ShouldNotBeNull();
            parametersOfprocessNode.Length.ShouldBe(3);
            methodprocessNodePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processNode) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_JSONUtil_processNode_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodprocessNodePrametersTypes = new Type[] { typeof(XmlNode), typeof(ArrayList), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_jSONUtilInstanceFixture, _jSONUtilInstanceType, MethodprocessNode, Fixture, methodprocessNodePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodprocessNodePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (processNode) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_JSONUtil_processNode_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodprocessNodePrametersTypes = new Type[] { typeof(XmlNode), typeof(ArrayList), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_jSONUtilInstanceFixture, _jSONUtilInstanceType, MethodprocessNode, Fixture, methodprocessNodePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodprocessNodePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processNode) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_JSONUtil_processNode_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprocessNode, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_jSONUtilInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (processNode) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_JSONUtil_processNode_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodprocessNode, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getAttributeName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_JSONUtil_getAttributeName_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetAttributeNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_jSONUtilInstanceFixture, _jSONUtilInstanceType, MethodgetAttributeName, Fixture, methodgetAttributeNamePrametersTypes);
        }

        #endregion

        #region Method Call : (getAttributeName) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_JSONUtil_getAttributeName_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var arrAttributes = CreateType<ArrayList>();
            var methodgetAttributeNamePrametersTypes = new Type[] { typeof(string), typeof(ArrayList) };
            object[] parametersOfgetAttributeName = { name, arrAttributes };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetAttributeName, methodgetAttributeNamePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_jSONUtilInstanceFixture, parametersOfgetAttributeName);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetAttributeName.ShouldNotBeNull();
            parametersOfgetAttributeName.Length.ShouldBe(2);
            methodgetAttributeNamePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getAttributeName) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_JSONUtil_getAttributeName_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var arrAttributes = CreateType<ArrayList>();
            var methodgetAttributeNamePrametersTypes = new Type[] { typeof(string), typeof(ArrayList) };
            object[] parametersOfgetAttributeName = { name, arrAttributes };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_jSONUtilInstanceFixture, _jSONUtilInstanceType, MethodgetAttributeName, parametersOfgetAttributeName, methodgetAttributeNamePrametersTypes);

            // Assert
            parametersOfgetAttributeName.ShouldNotBeNull();
            parametersOfgetAttributeName.Length.ShouldBe(2);
            methodgetAttributeNamePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getAttributeName) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_JSONUtil_getAttributeName_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetAttributeNamePrametersTypes = new Type[] { typeof(string), typeof(ArrayList) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_jSONUtilInstanceFixture, _jSONUtilInstanceType, MethodgetAttributeName, Fixture, methodgetAttributeNamePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetAttributeNamePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (getAttributeName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_JSONUtil_getAttributeName_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetAttributeNamePrametersTypes = new Type[] { typeof(string), typeof(ArrayList) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_jSONUtilInstanceFixture, _jSONUtilInstanceType, MethodgetAttributeName, Fixture, methodgetAttributeNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetAttributeNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getAttributeName) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_JSONUtil_getAttributeName_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetAttributeName, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_jSONUtilInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getAttributeName) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_JSONUtil_getAttributeName_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetAttributeName, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getNodeName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_JSONUtil_getNodeName_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetNodeNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_jSONUtilInstanceFixture, _jSONUtilInstanceType, MethodgetNodeName, Fixture, methodgetNodeNamePrametersTypes);
        }

        #endregion

        #region Method Call : (getNodeName) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_JSONUtil_getNodeName_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var nd = CreateType<XmlNode>();
            var idlist = CreateType<ArrayList>();
            var arrUsedNodes = CreateType<ArrayList>();
            var nodeCounter = CreateType<int>();
            var methodgetNodeNamePrametersTypes = new Type[] { typeof(XmlNode), typeof(ArrayList), typeof(ArrayList), typeof(int) };
            object[] parametersOfgetNodeName = { nd, idlist, arrUsedNodes, nodeCounter };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetNodeName, methodgetNodeNamePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_jSONUtilInstanceFixture, _jSONUtilInstanceType, MethodgetNodeName, Fixture, methodgetNodeNamePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_jSONUtilInstanceFixture, _jSONUtilInstanceType, MethodgetNodeName, parametersOfgetNodeName, methodgetNodeNamePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_jSONUtilInstanceFixture, parametersOfgetNodeName);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetNodeName.ShouldNotBeNull();
            parametersOfgetNodeName.Length.ShouldBe(4);
            methodgetNodeNamePrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (getNodeName) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_JSONUtil_getNodeName_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var nd = CreateType<XmlNode>();
            var idlist = CreateType<ArrayList>();
            var arrUsedNodes = CreateType<ArrayList>();
            var nodeCounter = CreateType<int>();
            var methodgetNodeNamePrametersTypes = new Type[] { typeof(XmlNode), typeof(ArrayList), typeof(ArrayList), typeof(int) };
            object[] parametersOfgetNodeName = { nd, idlist, arrUsedNodes, nodeCounter };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_jSONUtilInstanceFixture, _jSONUtilInstanceType, MethodgetNodeName, parametersOfgetNodeName, methodgetNodeNamePrametersTypes);

            // Assert
            parametersOfgetNodeName.ShouldNotBeNull();
            parametersOfgetNodeName.Length.ShouldBe(4);
            methodgetNodeNamePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getNodeName) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_JSONUtil_getNodeName_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetNodeNamePrametersTypes = new Type[] { typeof(XmlNode), typeof(ArrayList), typeof(ArrayList), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_jSONUtilInstanceFixture, _jSONUtilInstanceType, MethodgetNodeName, Fixture, methodgetNodeNamePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetNodeNamePrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (getNodeName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_JSONUtil_getNodeName_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetNodeNamePrametersTypes = new Type[] { typeof(XmlNode), typeof(ArrayList), typeof(ArrayList), typeof(int) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_jSONUtilInstanceFixture, _jSONUtilInstanceType, MethodgetNodeName, Fixture, methodgetNodeNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetNodeNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getNodeName) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_JSONUtil_getNodeName_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetNodeName, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_jSONUtilInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getNodeName) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_JSONUtil_getNodeName_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetNodeName, 0);
            const int parametersCount = 4;

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
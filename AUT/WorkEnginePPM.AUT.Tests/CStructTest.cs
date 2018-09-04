using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
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
using WorkEnginePPM;
using CStruct = WorkEnginePPM;

namespace WorkEnginePPM
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.CStruct" />)
    ///     and namespace <see cref="WorkEnginePPM"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class CStructTest : AbstractBaseSetupTypedTest<CStruct>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CStruct) Initializer

        private const string PropertyXMLDocument = "XMLDocument";
        private const string PropertyName = "Name";
        private const string PropertyValue = "Value";
        private const string PropertyInnerText = "InnerText";
        private const string MethodConvertXMLToJSON = "ConvertXMLToJSON";
        private const string MethodInitialize = "Initialize";
        private const string MethodLoadXML = "LoadXML";
        private const string MethodGetXMLNode = "GetXMLNode";
        private const string MethodAppendSubStruct = "AppendSubStruct";
        private const string MethodCreateSubStruct = "CreateSubStruct";
        private const string MethodCreateCDataSection = "CreateCDataSection";
        private const string MethodGetSubStruct = "GetSubStruct";
        private const string MethodAppendXML = "AppendXML";
        private const string MethodSetXMLNode = "SetXMLNode";
        private const string MethodXML = "XML";
        private const string MethodToString = "ToString";
        private const string MethodToJSONString = "ToJSONString";
        private const string MethodFromString = "FromString";
        private const string MethodAddElement = "AddElement";
        private const string MethodAddAttribute = "AddAttribute";
        private const string MethodGetNodeInternal = "GetNodeInternal";
        private const string MethodGetAttributeInternal = "GetAttributeInternal";
        private const string MethodDecodeXMLInt = "DecodeXMLInt";
        private const string MethodDecodeXMLDouble = "DecodeXMLDouble";
        private const string MethodDecodeXMLDecimal = "DecodeXMLDecimal";
        private const string MethodGetChildNodeCollection = "GetChildNodeCollection";
        private const string MethodGetCollection = "GetCollection";
        private const string MethodGetListSortedByAttribute = "GetListSortedByAttribute";
        private const string MethodGetListSortedByItem = "GetListSortedByItem";
        private const string MethodGetList = "GetList";
        private const string MethodGetBoolean = "GetBoolean";
        private const string MethodGetBooleanAttr = "GetBooleanAttr";
        private const string MethodGetInt = "GetInt";
        private const string MethodGetIntAttr = "GetIntAttr";
        private const string MethodGetDoubleAttr = "GetDoubleAttr";
        private const string MethodGetDecimalAttr = "GetDecimalAttr";
        private const string MethodGetString = "GetString";
        private const string MethodGetDate = "GetDate";
        private const string MethodGetStringAttr = "GetStringAttr";
        private const string MethodGetDateAttr = "GetDateAttr";
        private const string MethodGetGuid = "GetGuid";
        private const string MethodGetGuidAttr = "GetGuidAttr";
        private const string MethodCreateString = "CreateString";
        private const string MethodCreateStringAttr = "CreateStringAttr";
        private const string MethodCreateBoolean = "CreateBoolean";
        private const string MethodCreateBooleanAttr = "CreateBooleanAttr";
        private const string MethodCreateShortAttr = "CreateShortAttr";
        private const string MethodCreateInt = "CreateInt";
        private const string MethodReplaceInt = "ReplaceInt";
        private const string MethodCreateDouble = "CreateDouble";
        private const string MethodCreateIntAttr = "CreateIntAttr";
        private const string MethodCreateDoubleAttr = "CreateDoubleAttr";
        private const string MethodCreateDecimalAttr = "CreateDecimalAttr";
        private const string MethodCreateGuid = "CreateGuid";
        private const string MethodCreateGuidAttr = "CreateGuidAttr";
        private const string MethodCreateDate = "CreateDate";
        private const string MethodCreateDateAttr = "CreateDateAttr";
        private const string MethodXmlToJSONnode = "XmlToJSONnode";
        private const string MethodStoreChildNode = "StoreChildNode";
        private const string MethodOutputNode = "OutputNode";
        private const string MethodSafeJSON = "SafeJSON";
        private const string Fieldm_oXMLDocument = "m_oXMLDocument";
        private const string Fieldm_oNode = "m_oNode";
        private Type _cStructInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CStruct _cStructInstance;
        private CStruct _cStructInstanceFixture;

        #region General Initializer : Class (CStruct) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CStruct" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _cStructInstanceType = typeof(CStruct);
            _cStructInstanceFixture = Create(true);
            _cStructInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CStruct)

        #region General Initializer : Class (CStruct) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="CStruct" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodConvertXMLToJSON, 0)]
        [TestCase(MethodInitialize, 0)]
        [TestCase(MethodInitialize, 1)]
        [TestCase(MethodInitialize, 2)]
        [TestCase(MethodLoadXML, 0)]
        [TestCase(MethodGetXMLNode, 0)]
        [TestCase(MethodAppendSubStruct, 0)]
        [TestCase(MethodCreateSubStruct, 0)]
        [TestCase(MethodCreateCDataSection, 0)]
        [TestCase(MethodGetSubStruct, 0)]
        [TestCase(MethodGetSubStruct, 1)]
        [TestCase(MethodAppendXML, 0)]
        [TestCase(MethodSetXMLNode, 0)]
        [TestCase(MethodSetXMLNode, 1)]
        [TestCase(MethodXML, 0)]
        [TestCase(MethodToString, 0)]
        [TestCase(MethodToJSONString, 0)]
        [TestCase(MethodFromString, 0)]
        [TestCase(MethodAddElement, 0)]
        [TestCase(MethodAddAttribute, 0)]
        [TestCase(MethodGetNodeInternal, 0)]
        [TestCase(MethodGetAttributeInternal, 0)]
        [TestCase(MethodDecodeXMLInt, 0)]
        [TestCase(MethodDecodeXMLDouble, 0)]
        [TestCase(MethodDecodeXMLDecimal, 0)]
        [TestCase(MethodGetChildNodeCollection, 0)]
        [TestCase(MethodGetCollection, 0)]
        [TestCase(MethodGetListSortedByAttribute, 0)]
        [TestCase(MethodGetListSortedByItem, 0)]
        [TestCase(MethodGetList, 0)]
        [TestCase(MethodGetBoolean, 0)]
        [TestCase(MethodGetBoolean, 1)]
        [TestCase(MethodGetBooleanAttr, 0)]
        [TestCase(MethodGetBooleanAttr, 1)]
        [TestCase(MethodGetInt, 0)]
        [TestCase(MethodGetInt, 1)]
        [TestCase(MethodGetIntAttr, 0)]
        [TestCase(MethodGetIntAttr, 1)]
        [TestCase(MethodGetIntAttr, 2)]
        [TestCase(MethodGetDoubleAttr, 0)]
        [TestCase(MethodGetDoubleAttr, 1)]
        [TestCase(MethodGetDecimalAttr, 0)]
        [TestCase(MethodGetDecimalAttr, 1)]
        [TestCase(MethodGetString, 0)]
        [TestCase(MethodGetString, 1)]
        [TestCase(MethodGetDate, 0)]
        [TestCase(MethodGetDate, 1)]
        [TestCase(MethodGetStringAttr, 0)]
        [TestCase(MethodGetStringAttr, 1)]
        [TestCase(MethodGetStringAttr, 2)]
        [TestCase(MethodGetDateAttr, 0)]
        [TestCase(MethodGetDateAttr, 1)]
        [TestCase(MethodGetGuid, 0)]
        [TestCase(MethodGetGuidAttr, 0)]
        [TestCase(MethodCreateString, 0)]
        [TestCase(MethodCreateStringAttr, 0)]
        [TestCase(MethodCreateBoolean, 0)]
        [TestCase(MethodCreateBooleanAttr, 0)]
        [TestCase(MethodCreateShortAttr, 0)]
        [TestCase(MethodCreateInt, 0)]
        [TestCase(MethodReplaceInt, 0)]
        [TestCase(MethodCreateDouble, 0)]
        [TestCase(MethodCreateIntAttr, 0)]
        [TestCase(MethodCreateDoubleAttr, 0)]
        [TestCase(MethodCreateDecimalAttr, 0)]
        [TestCase(MethodCreateGuid, 0)]
        [TestCase(MethodCreateGuidAttr, 0)]
        [TestCase(MethodCreateDate, 0)]
        [TestCase(MethodCreateDateAttr, 0)]
        [TestCase(MethodXmlToJSONnode, 0)]
        [TestCase(MethodStoreChildNode, 0)]
        [TestCase(MethodOutputNode, 0)]
        [TestCase(MethodSafeJSON, 0)]
        public void AUT_CStruct_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_cStructInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CStruct) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CStruct" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyXMLDocument)]
        [TestCase(PropertyName)]
        [TestCase(PropertyValue)]
        [TestCase(PropertyInnerText)]
        public void AUT_CStruct_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_cStructInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CStruct) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CStruct" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldm_oXMLDocument)]
        [TestCase(Fieldm_oNode)]
        public void AUT_CStruct_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_cStructInstanceFixture, 
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
        ///     Class (<see cref="CStruct" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_CStruct_Is_Instance_Present_Test()
        {
            // Assert
            _cStructInstanceType.ShouldNotBeNull();
            _cStructInstance.ShouldNotBeNull();
            _cStructInstanceFixture.ShouldNotBeNull();
            _cStructInstance.ShouldBeAssignableTo<CStruct>();
            _cStructInstanceFixture.ShouldBeAssignableTo<CStruct>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CStruct) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_CStruct_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CStruct instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _cStructInstanceType.ShouldNotBeNull();
            _cStructInstance.ShouldNotBeNull();
            _cStructInstanceFixture.ShouldNotBeNull();
            _cStructInstance.ShouldBeAssignableTo<CStruct>();
            _cStructInstanceFixture.ShouldBeAssignableTo<CStruct>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CStruct) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(XmlDocument) , PropertyXMLDocument)]
        [TestCaseGeneric(typeof(string) , PropertyName)]
        [TestCaseGeneric(typeof(string) , PropertyValue)]
        [TestCaseGeneric(typeof(string) , PropertyInnerText)]
        public void AUT_CStruct_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CStruct, T>(_cStructInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (CStruct) => Property (InnerText) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_CStruct_Public_Class_InnerText_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyInnerText);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CStruct) => Property (Name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_CStruct_Public_Class_Name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CStruct) => Property (Value) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_CStruct_Public_Class_Value_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyValue);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CStruct) => Property (XMLDocument) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_CStruct_XMLDocument_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyXMLDocument);
            Action currentAction = () => propertyInfo.SetValue(_cStructInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CStruct) => Property (XMLDocument) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_CStruct_Public_Class_XMLDocument_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyXMLDocument);

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
        ///     Class (<see cref="CStruct" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodConvertXMLToJSON)]
        public void AUT_CStruct_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_cStructInstanceFixture,
                                                                              _cStructInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="CStruct" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodInitialize)]
        [TestCase(MethodLoadXML)]
        [TestCase(MethodGetXMLNode)]
        [TestCase(MethodAppendSubStruct)]
        [TestCase(MethodCreateSubStruct)]
        [TestCase(MethodCreateCDataSection)]
        [TestCase(MethodGetSubStruct)]
        [TestCase(MethodAppendXML)]
        [TestCase(MethodSetXMLNode)]
        [TestCase(MethodXML)]
        [TestCase(MethodToString)]
        [TestCase(MethodToJSONString)]
        [TestCase(MethodFromString)]
        [TestCase(MethodAddElement)]
        [TestCase(MethodAddAttribute)]
        [TestCase(MethodGetNodeInternal)]
        [TestCase(MethodGetAttributeInternal)]
        [TestCase(MethodDecodeXMLInt)]
        [TestCase(MethodDecodeXMLDouble)]
        [TestCase(MethodDecodeXMLDecimal)]
        [TestCase(MethodGetChildNodeCollection)]
        [TestCase(MethodGetCollection)]
        [TestCase(MethodGetListSortedByAttribute)]
        [TestCase(MethodGetListSortedByItem)]
        [TestCase(MethodGetList)]
        [TestCase(MethodGetBoolean)]
        [TestCase(MethodGetBooleanAttr)]
        [TestCase(MethodGetInt)]
        [TestCase(MethodGetIntAttr)]
        [TestCase(MethodGetDoubleAttr)]
        [TestCase(MethodGetDecimalAttr)]
        [TestCase(MethodGetString)]
        [TestCase(MethodGetDate)]
        [TestCase(MethodGetStringAttr)]
        [TestCase(MethodGetDateAttr)]
        [TestCase(MethodGetGuid)]
        [TestCase(MethodGetGuidAttr)]
        [TestCase(MethodCreateString)]
        [TestCase(MethodCreateStringAttr)]
        [TestCase(MethodCreateBoolean)]
        [TestCase(MethodCreateBooleanAttr)]
        [TestCase(MethodCreateShortAttr)]
        [TestCase(MethodCreateInt)]
        [TestCase(MethodReplaceInt)]
        [TestCase(MethodCreateDouble)]
        [TestCase(MethodCreateIntAttr)]
        [TestCase(MethodCreateDoubleAttr)]
        [TestCase(MethodCreateDecimalAttr)]
        [TestCase(MethodCreateGuid)]
        [TestCase(MethodCreateGuidAttr)]
        [TestCase(MethodCreateDate)]
        [TestCase(MethodCreateDateAttr)]
        [TestCase(MethodXmlToJSONnode)]
        [TestCase(MethodStoreChildNode)]
        [TestCase(MethodOutputNode)]
        [TestCase(MethodSafeJSON)]
        public void AUT_CStruct_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<CStruct>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (ConvertXMLToJSON) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_ConvertXMLToJSON_Static_Method_Call_Internally(Type[] types)
        {
            var methodConvertXMLToJSONPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_cStructInstanceFixture, _cStructInstanceType, MethodConvertXMLToJSON, Fixture, methodConvertXMLToJSONPrametersTypes);
        }

        #endregion

        #region Method Call : (ConvertXMLToJSON) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ConvertXMLToJSON_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => CStruct.ConvertXMLToJSON(sXML);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ConvertXMLToJSON) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ConvertXMLToJSON_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => CStruct.ConvertXMLToJSON(sXML);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ConvertXMLToJSON) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ConvertXMLToJSON_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            var methodConvertXMLToJSONPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfConvertXMLToJSON = { sXML };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodConvertXMLToJSON, methodConvertXMLToJSONPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_cStructInstanceFixture, _cStructInstanceType, MethodConvertXMLToJSON, Fixture, methodConvertXMLToJSONPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_cStructInstanceFixture, _cStructInstanceType, MethodConvertXMLToJSON, parametersOfConvertXMLToJSON, methodConvertXMLToJSONPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfConvertXMLToJSON);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfConvertXMLToJSON.ShouldNotBeNull();
            parametersOfConvertXMLToJSON.Length.ShouldBe(1);
            methodConvertXMLToJSONPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ConvertXMLToJSON) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ConvertXMLToJSON_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            var methodConvertXMLToJSONPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfConvertXMLToJSON = { sXML };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodConvertXMLToJSON, methodConvertXMLToJSONPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_cStructInstanceFixture, _cStructInstanceType, MethodConvertXMLToJSON, Fixture, methodConvertXMLToJSONPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_cStructInstanceFixture, _cStructInstanceType, MethodConvertXMLToJSON, parametersOfConvertXMLToJSON, methodConvertXMLToJSONPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfConvertXMLToJSON.ShouldNotBeNull();
            parametersOfConvertXMLToJSON.Length.ShouldBe(1);
            methodConvertXMLToJSONPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_cStructInstanceFixture, _cStructInstanceType, MethodConvertXMLToJSON, parametersOfConvertXMLToJSON, methodConvertXMLToJSONPrametersTypes));
        }

        #endregion

        #region Method Call : (ConvertXMLToJSON) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ConvertXMLToJSON_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            var methodConvertXMLToJSONPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfConvertXMLToJSON = { sXML };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodConvertXMLToJSON, methodConvertXMLToJSONPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfConvertXMLToJSON);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfConvertXMLToJSON.ShouldNotBeNull();
            parametersOfConvertXMLToJSON.Length.ShouldBe(1);
            methodConvertXMLToJSONPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConvertXMLToJSON) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ConvertXMLToJSON_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            var methodConvertXMLToJSONPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfConvertXMLToJSON = { sXML };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_cStructInstanceFixture, _cStructInstanceType, MethodConvertXMLToJSON, parametersOfConvertXMLToJSON, methodConvertXMLToJSONPrametersTypes);

            // Assert
            parametersOfConvertXMLToJSON.ShouldNotBeNull();
            parametersOfConvertXMLToJSON.Length.ShouldBe(1);
            methodConvertXMLToJSONPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConvertXMLToJSON) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ConvertXMLToJSON_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodConvertXMLToJSONPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_cStructInstanceFixture, _cStructInstanceType, MethodConvertXMLToJSON, Fixture, methodConvertXMLToJSONPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodConvertXMLToJSONPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ConvertXMLToJSON) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ConvertXMLToJSON_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodConvertXMLToJSONPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_cStructInstanceFixture, _cStructInstanceType, MethodConvertXMLToJSON, Fixture, methodConvertXMLToJSONPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodConvertXMLToJSONPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ConvertXMLToJSON) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ConvertXMLToJSON_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodConvertXMLToJSONPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_cStructInstanceFixture, _cStructInstanceType, MethodConvertXMLToJSON, Fixture, methodConvertXMLToJSONPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodConvertXMLToJSONPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ConvertXMLToJSON) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ConvertXMLToJSON_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodConvertXMLToJSON, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ConvertXMLToJSON) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ConvertXMLToJSON_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodConvertXMLToJSON, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ConvertXMLToJSON) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ConvertXMLToJSON_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodConvertXMLToJSON, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_Initialize_Method_Call_Internally(Type[] types)
        {
            var methodInitializePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodInitialize, Fixture, methodInitializePrametersTypes);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_Initialize_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sStructName = CreateType<string>();
            var xCompatibleStruct = CreateType<CStruct>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.Initialize(sStructName, xCompatibleStruct);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_Initialize_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sStructName = CreateType<string>();
            var xCompatibleStruct = CreateType<CStruct>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.Initialize(sStructName, xCompatibleStruct);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_Initialize_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sStructName = CreateType<string>();
            var xCompatibleStruct = CreateType<CStruct>();
            var methodInitializePrametersTypes = new Type[] { typeof(string), typeof(CStruct) };
            object[] parametersOfInitialize = { sStructName, xCompatibleStruct };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitialize, methodInitializePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfInitialize);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInitialize.ShouldNotBeNull();
            parametersOfInitialize.Length.ShouldBe(2);
            methodInitializePrametersTypes.Length.ShouldBe(2);
            methodInitializePrametersTypes.Length.ShouldBe(parametersOfInitialize.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_Initialize_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sStructName = CreateType<string>();
            var xCompatibleStruct = CreateType<CStruct>();
            var methodInitializePrametersTypes = new Type[] { typeof(string), typeof(CStruct) };
            object[] parametersOfInitialize = { sStructName, xCompatibleStruct };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitialize, methodInitializePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfInitialize);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInitialize.ShouldNotBeNull();
            parametersOfInitialize.Length.ShouldBe(2);
            methodInitializePrametersTypes.Length.ShouldBe(2);
            methodInitializePrametersTypes.Length.ShouldBe(parametersOfInitialize.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_Initialize_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sStructName = CreateType<string>();
            var xCompatibleStruct = CreateType<CStruct>();
            var methodInitializePrametersTypes = new Type[] { typeof(string), typeof(CStruct) };
            object[] parametersOfInitialize = { sStructName, xCompatibleStruct };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cStructInstance, MethodInitialize, parametersOfInitialize, methodInitializePrametersTypes);

            // Assert
            parametersOfInitialize.ShouldNotBeNull();
            parametersOfInitialize.Length.ShouldBe(2);
            methodInitializePrametersTypes.Length.ShouldBe(2);
            methodInitializePrametersTypes.Length.ShouldBe(parametersOfInitialize.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_Initialize_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodInitialize, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_Initialize_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInitializePrametersTypes = new Type[] { typeof(string), typeof(CStruct) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodInitialize, Fixture, methodInitializePrametersTypes);

            // Assert
            methodInitializePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_Initialize_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitialize, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_Initialize_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodInitializePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodInitialize, Fixture, methodInitializePrametersTypes);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_Initialize_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var sStructName = CreateType<string>();
            var oXMLDocument = CreateType<XmlDocument>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.Initialize(sStructName, oXMLDocument);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_Initialize_Method_DirectCall_Overloading_Of_1_No_Exception_Thrown_Test()
        {
            // Arrange
            var sStructName = CreateType<string>();
            var oXMLDocument = CreateType<XmlDocument>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.Initialize(sStructName, oXMLDocument);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_Initialize_Method_Call_Void_Overloading_Of_1_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sStructName = CreateType<string>();
            var oXMLDocument = CreateType<XmlDocument>();
            var methodInitializePrametersTypes = new Type[] { typeof(string), typeof(XmlDocument) };
            object[] parametersOfInitialize = { sStructName, oXMLDocument };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitialize, methodInitializePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfInitialize);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInitialize.ShouldNotBeNull();
            parametersOfInitialize.Length.ShouldBe(2);
            methodInitializePrametersTypes.Length.ShouldBe(2);
            methodInitializePrametersTypes.Length.ShouldBe(parametersOfInitialize.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_Initialize_Method_Call_Void_Overloading_Of_1_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sStructName = CreateType<string>();
            var oXMLDocument = CreateType<XmlDocument>();
            var methodInitializePrametersTypes = new Type[] { typeof(string), typeof(XmlDocument) };
            object[] parametersOfInitialize = { sStructName, oXMLDocument };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitialize, methodInitializePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfInitialize);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInitialize.ShouldNotBeNull();
            parametersOfInitialize.Length.ShouldBe(2);
            methodInitializePrametersTypes.Length.ShouldBe(2);
            methodInitializePrametersTypes.Length.ShouldBe(parametersOfInitialize.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_Initialize_Method_Call_Void_Overloading_Of_1_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sStructName = CreateType<string>();
            var oXMLDocument = CreateType<XmlDocument>();
            var methodInitializePrametersTypes = new Type[] { typeof(string), typeof(XmlDocument) };
            object[] parametersOfInitialize = { sStructName, oXMLDocument };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cStructInstance, MethodInitialize, parametersOfInitialize, methodInitializePrametersTypes);

            // Assert
            parametersOfInitialize.ShouldNotBeNull();
            parametersOfInitialize.Length.ShouldBe(2);
            methodInitializePrametersTypes.Length.ShouldBe(2);
            methodInitializePrametersTypes.Length.ShouldBe(parametersOfInitialize.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_Initialize_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodInitialize, 1);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_Initialize_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInitializePrametersTypes = new Type[] { typeof(string), typeof(XmlDocument) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodInitialize, Fixture, methodInitializePrametersTypes);

            // Assert
            methodInitializePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_Initialize_Method_Call_Overloading_Of_1_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitialize, 1);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_Initialize_Method_Overloading_Of_2_Call_Internally(Type[] types)
        {
            var methodInitializePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodInitialize, Fixture, methodInitializePrametersTypes);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_Initialize_Method_DirectCall_Overloading_Of_2_Throw_Exception_Test()
        {
            // Arrange
            var sStructName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.Initialize(sStructName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_Initialize_Method_DirectCall_Overloading_Of_2_No_Exception_Thrown_Test()
        {
            // Arrange
            var sStructName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.Initialize(sStructName);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_Initialize_Method_Call_Void_Overloading_Of_2_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sStructName = CreateType<string>();
            var methodInitializePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfInitialize = { sStructName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitialize, methodInitializePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfInitialize);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInitialize.ShouldNotBeNull();
            parametersOfInitialize.Length.ShouldBe(1);
            methodInitializePrametersTypes.Length.ShouldBe(1);
            methodInitializePrametersTypes.Length.ShouldBe(parametersOfInitialize.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_Initialize_Method_Call_Void_Overloading_Of_2_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sStructName = CreateType<string>();
            var methodInitializePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfInitialize = { sStructName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitialize, methodInitializePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfInitialize);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInitialize.ShouldNotBeNull();
            parametersOfInitialize.Length.ShouldBe(1);
            methodInitializePrametersTypes.Length.ShouldBe(1);
            methodInitializePrametersTypes.Length.ShouldBe(parametersOfInitialize.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_Initialize_Method_Call_Void_Overloading_Of_2_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sStructName = CreateType<string>();
            var methodInitializePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfInitialize = { sStructName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cStructInstance, MethodInitialize, parametersOfInitialize, methodInitializePrametersTypes);

            // Assert
            parametersOfInitialize.ShouldNotBeNull();
            parametersOfInitialize.Length.ShouldBe(1);
            methodInitializePrametersTypes.Length.ShouldBe(1);
            methodInitializePrametersTypes.Length.ShouldBe(parametersOfInitialize.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_Initialize_Method_Call_Overloading_Of_2_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodInitialize, 2);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_Initialize_Method_Call_Overloading_Of_2_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInitializePrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodInitialize, Fixture, methodInitializePrametersTypes);

            // Assert
            methodInitializePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_Initialize_Method_Call_Overloading_Of_2_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitialize, 2);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadXML) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_LoadXML_Method_Call_Internally(Type[] types)
        {
            var methodLoadXMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodLoadXML, Fixture, methodLoadXMLPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadXML) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_LoadXML_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.LoadXML(sXML);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (LoadXML) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_LoadXML_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.LoadXML(sXML);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (LoadXML) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_LoadXML_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            var methodLoadXMLPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfLoadXML = { sXML };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodLoadXML, methodLoadXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, bool>(_cStructInstanceFixture, out exception1, parametersOfLoadXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, bool>(_cStructInstance, MethodLoadXML, parametersOfLoadXML, methodLoadXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfLoadXML.ShouldNotBeNull();
            parametersOfLoadXML.Length.ShouldBe(1);
            methodLoadXMLPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (LoadXML) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_LoadXML_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            var methodLoadXMLPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfLoadXML = { sXML };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodLoadXML, methodLoadXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, bool>(_cStructInstanceFixture, out exception1, parametersOfLoadXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, bool>(_cStructInstance, MethodLoadXML, parametersOfLoadXML, methodLoadXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfLoadXML.ShouldNotBeNull();
            parametersOfLoadXML.Length.ShouldBe(1);
            methodLoadXMLPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (LoadXML) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_LoadXML_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            var methodLoadXMLPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfLoadXML = { sXML };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodLoadXML, methodLoadXMLPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfLoadXML);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfLoadXML.ShouldNotBeNull();
            parametersOfLoadXML.Length.ShouldBe(1);
            methodLoadXMLPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadXML) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_LoadXML_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            var methodLoadXMLPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfLoadXML = { sXML };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, bool>(_cStructInstance, MethodLoadXML, parametersOfLoadXML, methodLoadXMLPrametersTypes);

            // Assert
            parametersOfLoadXML.ShouldNotBeNull();
            parametersOfLoadXML.Length.ShouldBe(1);
            methodLoadXMLPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadXML) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_LoadXML_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodLoadXMLPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodLoadXML, Fixture, methodLoadXMLPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodLoadXMLPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (LoadXML) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_LoadXML_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodLoadXMLPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodLoadXML, Fixture, methodLoadXMLPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodLoadXMLPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (LoadXML) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_LoadXML_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLoadXMLPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodLoadXML, Fixture, methodLoadXMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodLoadXMLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LoadXML) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_LoadXML_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLoadXML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (LoadXML) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_LoadXML_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLoadXML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (LoadXML) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_LoadXML_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodLoadXML, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetXMLNode) (Return Type : XmlNode) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_GetXMLNode_Method_Call_Internally(Type[] types)
        {
            var methodGetXMLNodePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetXMLNode, Fixture, methodGetXMLNodePrametersTypes);
        }

        #endregion

        #region Method Call : (GetXMLNode) (Return Type : XmlNode) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetXMLNode_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetXMLNode();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetXMLNode) (Return Type : XmlNode) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetXMLNode_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetXMLNode();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetXMLNode) (Return Type : XmlNode) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetXMLNode_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetXMLNodePrametersTypes = null;
            object[] parametersOfGetXMLNode = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetXMLNode, methodGetXMLNodePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, XmlNode>(_cStructInstanceFixture, out exception1, parametersOfGetXMLNode);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, XmlNode>(_cStructInstance, MethodGetXMLNode, parametersOfGetXMLNode, methodGetXMLNodePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetXMLNode.ShouldBeNull();
            methodGetXMLNodePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetXMLNode) (Return Type : XmlNode) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetXMLNode_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodGetXMLNodePrametersTypes = null;
            object[] parametersOfGetXMLNode = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetXMLNode, methodGetXMLNodePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, XmlNode>(_cStructInstanceFixture, out exception1, parametersOfGetXMLNode);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, XmlNode>(_cStructInstance, MethodGetXMLNode, parametersOfGetXMLNode, methodGetXMLNodePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetXMLNode.ShouldBeNull();
            methodGetXMLNodePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetXMLNode) (Return Type : XmlNode) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetXMLNode_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetXMLNodePrametersTypes = null;
            object[] parametersOfGetXMLNode = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetXMLNode, methodGetXMLNodePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfGetXMLNode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetXMLNode.ShouldBeNull();
            methodGetXMLNodePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetXMLNode) (Return Type : XmlNode) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetXMLNode_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetXMLNodePrametersTypes = null;
            object[] parametersOfGetXMLNode = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, XmlNode>(_cStructInstance, MethodGetXMLNode, parametersOfGetXMLNode, methodGetXMLNodePrametersTypes);

            // Assert
            parametersOfGetXMLNode.ShouldBeNull();
            methodGetXMLNodePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetXMLNode) (Return Type : XmlNode) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetXMLNode_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetXMLNodePrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetXMLNode, Fixture, methodGetXMLNodePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetXMLNodePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetXMLNode) (Return Type : XmlNode) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetXMLNode_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetXMLNodePrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetXMLNode, Fixture, methodGetXMLNodePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetXMLNodePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetXMLNode) (Return Type : XmlNode) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetXMLNode_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetXMLNodePrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetXMLNode, Fixture, methodGetXMLNodePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetXMLNodePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetXMLNode) (Return Type : XmlNode) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetXMLNode_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetXMLNode, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetXMLNode) (Return Type : XmlNode) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetXMLNode_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetXMLNode, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AppendSubStruct) (Return Type : CStruct) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_AppendSubStruct_Method_Call_Internally(Type[] types)
        {
            var methodAppendSubStructPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodAppendSubStruct, Fixture, methodAppendSubStructPrametersTypes);
        }

        #endregion

        #region Method Call : (AppendSubStruct) (Return Type : CStruct) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_AppendSubStruct_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var xStruct = CreateType<CStruct>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.AppendSubStruct(xStruct);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (AppendSubStruct) (Return Type : CStruct) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_AppendSubStruct_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var xStruct = CreateType<CStruct>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.AppendSubStruct(xStruct);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (AppendSubStruct) (Return Type : CStruct) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_AppendSubStruct_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var xStruct = CreateType<CStruct>();
            var methodAppendSubStructPrametersTypes = new Type[] { typeof(CStruct) };
            object[] parametersOfAppendSubStruct = { xStruct };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodAppendSubStruct, methodAppendSubStructPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, CStruct>(_cStructInstanceFixture, out exception1, parametersOfAppendSubStruct);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, CStruct>(_cStructInstance, MethodAppendSubStruct, parametersOfAppendSubStruct, methodAppendSubStructPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfAppendSubStruct.ShouldNotBeNull();
            parametersOfAppendSubStruct.Length.ShouldBe(1);
            methodAppendSubStructPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (AppendSubStruct) (Return Type : CStruct) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_AppendSubStruct_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var xStruct = CreateType<CStruct>();
            var methodAppendSubStructPrametersTypes = new Type[] { typeof(CStruct) };
            object[] parametersOfAppendSubStruct = { xStruct };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodAppendSubStruct, methodAppendSubStructPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, CStruct>(_cStructInstanceFixture, out exception1, parametersOfAppendSubStruct);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, CStruct>(_cStructInstance, MethodAppendSubStruct, parametersOfAppendSubStruct, methodAppendSubStructPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfAppendSubStruct.ShouldNotBeNull();
            parametersOfAppendSubStruct.Length.ShouldBe(1);
            methodAppendSubStructPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (AppendSubStruct) (Return Type : CStruct) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_AppendSubStruct_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var xStruct = CreateType<CStruct>();
            var methodAppendSubStructPrametersTypes = new Type[] { typeof(CStruct) };
            object[] parametersOfAppendSubStruct = { xStruct };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAppendSubStruct, methodAppendSubStructPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfAppendSubStruct);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAppendSubStruct.ShouldNotBeNull();
            parametersOfAppendSubStruct.Length.ShouldBe(1);
            methodAppendSubStructPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AppendSubStruct) (Return Type : CStruct) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_AppendSubStruct_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xStruct = CreateType<CStruct>();
            var methodAppendSubStructPrametersTypes = new Type[] { typeof(CStruct) };
            object[] parametersOfAppendSubStruct = { xStruct };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, CStruct>(_cStructInstance, MethodAppendSubStruct, parametersOfAppendSubStruct, methodAppendSubStructPrametersTypes);

            // Assert
            parametersOfAppendSubStruct.ShouldNotBeNull();
            parametersOfAppendSubStruct.Length.ShouldBe(1);
            methodAppendSubStructPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AppendSubStruct) (Return Type : CStruct) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_AppendSubStruct_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodAppendSubStructPrametersTypes = new Type[] { typeof(CStruct) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodAppendSubStruct, Fixture, methodAppendSubStructPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodAppendSubStructPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (AppendSubStruct) (Return Type : CStruct) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_AppendSubStruct_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodAppendSubStructPrametersTypes = new Type[] { typeof(CStruct) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodAppendSubStruct, Fixture, methodAppendSubStructPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodAppendSubStructPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (AppendSubStruct) (Return Type : CStruct) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_AppendSubStruct_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAppendSubStructPrametersTypes = new Type[] { typeof(CStruct) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodAppendSubStruct, Fixture, methodAppendSubStructPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAppendSubStructPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AppendSubStruct) (Return Type : CStruct) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_AppendSubStruct_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAppendSubStruct, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (AppendSubStruct) (Return Type : CStruct) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_AppendSubStruct_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAppendSubStruct, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AppendSubStruct) (Return Type : CStruct) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_AppendSubStruct_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAppendSubStruct, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateSubStruct) (Return Type : CStruct) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_CreateSubStruct_Method_Call_Internally(Type[] types)
        {
            var methodCreateSubStructPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodCreateSubStruct, Fixture, methodCreateSubStructPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateSubStruct) (Return Type : CStruct) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateSubStruct_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.CreateSubStruct(sItemName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CreateSubStruct) (Return Type : CStruct) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateSubStruct_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.CreateSubStruct(sItemName);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (CreateSubStruct) (Return Type : CStruct) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateSubStruct_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodCreateSubStructPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfCreateSubStruct = { sItemName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCreateSubStruct, methodCreateSubStructPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, CStruct>(_cStructInstanceFixture, out exception1, parametersOfCreateSubStruct);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, CStruct>(_cStructInstance, MethodCreateSubStruct, parametersOfCreateSubStruct, methodCreateSubStructPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfCreateSubStruct.ShouldNotBeNull();
            parametersOfCreateSubStruct.Length.ShouldBe(1);
            methodCreateSubStructPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (CreateSubStruct) (Return Type : CStruct) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateSubStruct_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodCreateSubStructPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfCreateSubStruct = { sItemName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCreateSubStruct, methodCreateSubStructPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, CStruct>(_cStructInstanceFixture, out exception1, parametersOfCreateSubStruct);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, CStruct>(_cStructInstance, MethodCreateSubStruct, parametersOfCreateSubStruct, methodCreateSubStructPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfCreateSubStruct.ShouldNotBeNull();
            parametersOfCreateSubStruct.Length.ShouldBe(1);
            methodCreateSubStructPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (CreateSubStruct) (Return Type : CStruct) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateSubStruct_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodCreateSubStructPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfCreateSubStruct = { sItemName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateSubStruct, methodCreateSubStructPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfCreateSubStruct);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateSubStruct.ShouldNotBeNull();
            parametersOfCreateSubStruct.Length.ShouldBe(1);
            methodCreateSubStructPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateSubStruct) (Return Type : CStruct) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateSubStruct_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodCreateSubStructPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfCreateSubStruct = { sItemName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, CStruct>(_cStructInstance, MethodCreateSubStruct, parametersOfCreateSubStruct, methodCreateSubStructPrametersTypes);

            // Assert
            parametersOfCreateSubStruct.ShouldNotBeNull();
            parametersOfCreateSubStruct.Length.ShouldBe(1);
            methodCreateSubStructPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateSubStruct) (Return Type : CStruct) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateSubStruct_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCreateSubStructPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodCreateSubStruct, Fixture, methodCreateSubStructPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCreateSubStructPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (CreateSubStruct) (Return Type : CStruct) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateSubStruct_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodCreateSubStructPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodCreateSubStruct, Fixture, methodCreateSubStructPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodCreateSubStructPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (CreateSubStruct) (Return Type : CStruct) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateSubStruct_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateSubStructPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodCreateSubStruct, Fixture, methodCreateSubStructPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreateSubStructPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateSubStruct) (Return Type : CStruct) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateSubStruct_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateSubStruct, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (CreateSubStruct) (Return Type : CStruct) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateSubStruct_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateSubStruct, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateSubStruct) (Return Type : CStruct) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateSubStruct_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreateSubStruct, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateCDataSection) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_CreateCDataSection_Method_Call_Internally(Type[] types)
        {
            var methodCreateCDataSectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodCreateCDataSection, Fixture, methodCreateCDataSectionPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateCDataSection) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateCDataSection_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sData = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.CreateCDataSection(sData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CreateCDataSection) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateCDataSection_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sData = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.CreateCDataSection(sData);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (CreateCDataSection) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateCDataSection_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sData = CreateType<string>();
            var methodCreateCDataSectionPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfCreateCDataSection = { sData };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCreateCDataSection, methodCreateCDataSectionPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, bool>(_cStructInstanceFixture, out exception1, parametersOfCreateCDataSection);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, bool>(_cStructInstance, MethodCreateCDataSection, parametersOfCreateCDataSection, methodCreateCDataSectionPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfCreateCDataSection.ShouldNotBeNull();
            parametersOfCreateCDataSection.Length.ShouldBe(1);
            methodCreateCDataSectionPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (CreateCDataSection) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateCDataSection_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sData = CreateType<string>();
            var methodCreateCDataSectionPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfCreateCDataSection = { sData };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCreateCDataSection, methodCreateCDataSectionPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, bool>(_cStructInstanceFixture, out exception1, parametersOfCreateCDataSection);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, bool>(_cStructInstance, MethodCreateCDataSection, parametersOfCreateCDataSection, methodCreateCDataSectionPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfCreateCDataSection.ShouldNotBeNull();
            parametersOfCreateCDataSection.Length.ShouldBe(1);
            methodCreateCDataSectionPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (CreateCDataSection) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateCDataSection_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sData = CreateType<string>();
            var methodCreateCDataSectionPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfCreateCDataSection = { sData };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateCDataSection, methodCreateCDataSectionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfCreateCDataSection);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateCDataSection.ShouldNotBeNull();
            parametersOfCreateCDataSection.Length.ShouldBe(1);
            methodCreateCDataSectionPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateCDataSection) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateCDataSection_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sData = CreateType<string>();
            var methodCreateCDataSectionPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfCreateCDataSection = { sData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, bool>(_cStructInstance, MethodCreateCDataSection, parametersOfCreateCDataSection, methodCreateCDataSectionPrametersTypes);

            // Assert
            parametersOfCreateCDataSection.ShouldNotBeNull();
            parametersOfCreateCDataSection.Length.ShouldBe(1);
            methodCreateCDataSectionPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateCDataSection) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateCDataSection_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCreateCDataSectionPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodCreateCDataSection, Fixture, methodCreateCDataSectionPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodCreateCDataSectionPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (CreateCDataSection) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateCDataSection_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodCreateCDataSectionPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodCreateCDataSection, Fixture, methodCreateCDataSectionPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodCreateCDataSectionPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (CreateCDataSection) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateCDataSection_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateCDataSectionPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodCreateCDataSection, Fixture, methodCreateCDataSectionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreateCDataSectionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateCDataSection) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateCDataSection_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateCDataSection, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (CreateCDataSection) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateCDataSection_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateCDataSection, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateCDataSection) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateCDataSection_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreateCDataSection, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSubStruct) (Return Type : CStruct) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_GetSubStruct_Method_Call_Internally(Type[] types)
        {
            var methodGetSubStructPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetSubStruct, Fixture, methodGetSubStructPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSubStruct) (Return Type : CStruct) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetSubStruct_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetSubStruct();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetSubStruct) (Return Type : CStruct) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetSubStruct_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetSubStruct();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetSubStruct) (Return Type : CStruct) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetSubStruct_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetSubStructPrametersTypes = null;
            object[] parametersOfGetSubStruct = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetSubStruct, methodGetSubStructPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, CStruct>(_cStructInstanceFixture, out exception1, parametersOfGetSubStruct);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, CStruct>(_cStructInstance, MethodGetSubStruct, parametersOfGetSubStruct, methodGetSubStructPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetSubStruct.ShouldBeNull();
            methodGetSubStructPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSubStruct) (Return Type : CStruct) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetSubStruct_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodGetSubStructPrametersTypes = null;
            object[] parametersOfGetSubStruct = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetSubStruct, methodGetSubStructPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, CStruct>(_cStructInstanceFixture, out exception1, parametersOfGetSubStruct);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, CStruct>(_cStructInstance, MethodGetSubStruct, parametersOfGetSubStruct, methodGetSubStructPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetSubStruct.ShouldBeNull();
            methodGetSubStructPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSubStruct) (Return Type : CStruct) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetSubStruct_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetSubStructPrametersTypes = null;
            object[] parametersOfGetSubStruct = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetSubStruct, methodGetSubStructPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfGetSubStruct);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetSubStruct.ShouldBeNull();
            methodGetSubStructPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSubStruct) (Return Type : CStruct) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetSubStruct_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetSubStructPrametersTypes = null;
            object[] parametersOfGetSubStruct = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, CStruct>(_cStructInstance, MethodGetSubStruct, parametersOfGetSubStruct, methodGetSubStructPrametersTypes);

            // Assert
            parametersOfGetSubStruct.ShouldBeNull();
            methodGetSubStructPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSubStruct) (Return Type : CStruct) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetSubStruct_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetSubStructPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetSubStruct, Fixture, methodGetSubStructPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetSubStructPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSubStruct) (Return Type : CStruct) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetSubStruct_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetSubStructPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetSubStruct, Fixture, methodGetSubStructPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetSubStructPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSubStruct) (Return Type : CStruct) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetSubStruct_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetSubStructPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetSubStruct, Fixture, methodGetSubStructPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSubStructPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSubStruct) (Return Type : CStruct) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetSubStruct_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSubStruct, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetSubStruct) (Return Type : CStruct) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetSubStruct_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSubStruct, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSubStruct) (Return Type : CStruct) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_GetSubStruct_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodGetSubStructPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetSubStruct, Fixture, methodGetSubStructPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSubStruct) (Return Type : CStruct) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetSubStruct_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetSubStruct(sItemName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetSubStruct) (Return Type : CStruct) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetSubStruct_Method_DirectCall_Overloading_Of_1_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetSubStruct(sItemName);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetSubStruct) (Return Type : CStruct) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetSubStruct_Method_Call_Overloading_Of_1_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetSubStructPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetSubStruct = { sItemName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetSubStruct, methodGetSubStructPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, CStruct>(_cStructInstanceFixture, out exception1, parametersOfGetSubStruct);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, CStruct>(_cStructInstance, MethodGetSubStruct, parametersOfGetSubStruct, methodGetSubStructPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetSubStruct.ShouldNotBeNull();
            parametersOfGetSubStruct.Length.ShouldBe(1);
            methodGetSubStructPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetSubStruct) (Return Type : CStruct) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetSubStruct_Method_Call_Overloading_Of_1_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetSubStructPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetSubStruct = { sItemName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetSubStruct, methodGetSubStructPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, CStruct>(_cStructInstanceFixture, out exception1, parametersOfGetSubStruct);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, CStruct>(_cStructInstance, MethodGetSubStruct, parametersOfGetSubStruct, methodGetSubStructPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetSubStruct.ShouldNotBeNull();
            parametersOfGetSubStruct.Length.ShouldBe(1);
            methodGetSubStructPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetSubStruct) (Return Type : CStruct) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetSubStruct_Method_Call_Overloading_Of_1_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetSubStructPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetSubStruct = { sItemName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetSubStruct, methodGetSubStructPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfGetSubStruct);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetSubStruct.ShouldNotBeNull();
            parametersOfGetSubStruct.Length.ShouldBe(1);
            methodGetSubStructPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSubStruct) (Return Type : CStruct) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetSubStruct_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetSubStructPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetSubStruct = { sItemName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, CStruct>(_cStructInstance, MethodGetSubStruct, parametersOfGetSubStruct, methodGetSubStructPrametersTypes);

            // Assert
            parametersOfGetSubStruct.ShouldNotBeNull();
            parametersOfGetSubStruct.Length.ShouldBe(1);
            methodGetSubStructPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSubStruct) (Return Type : CStruct) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetSubStruct_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetSubStructPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetSubStruct, Fixture, methodGetSubStructPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetSubStructPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetSubStruct) (Return Type : CStruct) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetSubStruct_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetSubStructPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetSubStruct, Fixture, methodGetSubStructPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetSubStructPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetSubStruct) (Return Type : CStruct) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetSubStruct_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSubStructPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetSubStruct, Fixture, methodGetSubStructPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSubStructPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSubStruct) (Return Type : CStruct) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetSubStruct_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSubStruct, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetSubStruct) (Return Type : CStruct) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetSubStruct_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSubStruct, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSubStruct) (Return Type : CStruct) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetSubStruct_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetSubStruct, 1);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AppendXML) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_AppendXML_Method_Call_Internally(Type[] types)
        {
            var methodAppendXMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodAppendXML, Fixture, methodAppendXMLPrametersTypes);
        }

        #endregion

        #region Method Call : (AppendXML) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_AppendXML_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.AppendXML(sXML);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (AppendXML) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_AppendXML_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.AppendXML(sXML);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (AppendXML) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_AppendXML_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            var methodAppendXMLPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfAppendXML = { sXML };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodAppendXML, methodAppendXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, bool>(_cStructInstanceFixture, out exception1, parametersOfAppendXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, bool>(_cStructInstance, MethodAppendXML, parametersOfAppendXML, methodAppendXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfAppendXML.ShouldNotBeNull();
            parametersOfAppendXML.Length.ShouldBe(1);
            methodAppendXMLPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (AppendXML) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_AppendXML_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            var methodAppendXMLPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfAppendXML = { sXML };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodAppendXML, methodAppendXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, bool>(_cStructInstanceFixture, out exception1, parametersOfAppendXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, bool>(_cStructInstance, MethodAppendXML, parametersOfAppendXML, methodAppendXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfAppendXML.ShouldNotBeNull();
            parametersOfAppendXML.Length.ShouldBe(1);
            methodAppendXMLPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (AppendXML) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_AppendXML_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            var methodAppendXMLPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfAppendXML = { sXML };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAppendXML, methodAppendXMLPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfAppendXML);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAppendXML.ShouldNotBeNull();
            parametersOfAppendXML.Length.ShouldBe(1);
            methodAppendXMLPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AppendXML) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_AppendXML_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            var methodAppendXMLPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfAppendXML = { sXML };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, bool>(_cStructInstance, MethodAppendXML, parametersOfAppendXML, methodAppendXMLPrametersTypes);

            // Assert
            parametersOfAppendXML.ShouldNotBeNull();
            parametersOfAppendXML.Length.ShouldBe(1);
            methodAppendXMLPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AppendXML) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_AppendXML_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodAppendXMLPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodAppendXML, Fixture, methodAppendXMLPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodAppendXMLPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (AppendXML) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_AppendXML_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodAppendXMLPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodAppendXML, Fixture, methodAppendXMLPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodAppendXMLPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (AppendXML) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_AppendXML_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAppendXMLPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodAppendXML, Fixture, methodAppendXMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAppendXMLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AppendXML) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_AppendXML_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAppendXML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (AppendXML) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_AppendXML_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAppendXML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AppendXML) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_AppendXML_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAppendXML, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetXMLNode) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_SetXMLNode_Method_Call_Internally(Type[] types)
        {
            var methodSetXMLNodePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodSetXMLNode, Fixture, methodSetXMLNodePrametersTypes);
        }

        #endregion

        #region Method Call : (SetXMLNode) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_SetXMLNode_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var oNode = CreateType<XmlNode>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.SetXMLNode(oNode);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetXMLNode) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_SetXMLNode_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var oNode = CreateType<XmlNode>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.SetXMLNode(oNode);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (SetXMLNode) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_SetXMLNode_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var oNode = CreateType<XmlNode>();
            var methodSetXMLNodePrametersTypes = new Type[] { typeof(XmlNode) };
            object[] parametersOfSetXMLNode = { oNode };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetXMLNode, methodSetXMLNodePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfSetXMLNode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetXMLNode.ShouldNotBeNull();
            parametersOfSetXMLNode.Length.ShouldBe(1);
            methodSetXMLNodePrametersTypes.Length.ShouldBe(1);
            methodSetXMLNodePrametersTypes.Length.ShouldBe(parametersOfSetXMLNode.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetXMLNode) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_SetXMLNode_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var oNode = CreateType<XmlNode>();
            var methodSetXMLNodePrametersTypes = new Type[] { typeof(XmlNode) };
            object[] parametersOfSetXMLNode = { oNode };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetXMLNode, methodSetXMLNodePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfSetXMLNode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetXMLNode.ShouldNotBeNull();
            parametersOfSetXMLNode.Length.ShouldBe(1);
            methodSetXMLNodePrametersTypes.Length.ShouldBe(1);
            methodSetXMLNodePrametersTypes.Length.ShouldBe(parametersOfSetXMLNode.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetXMLNode) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_SetXMLNode_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oNode = CreateType<XmlNode>();
            var methodSetXMLNodePrametersTypes = new Type[] { typeof(XmlNode) };
            object[] parametersOfSetXMLNode = { oNode };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cStructInstance, MethodSetXMLNode, parametersOfSetXMLNode, methodSetXMLNodePrametersTypes);

            // Assert
            parametersOfSetXMLNode.ShouldNotBeNull();
            parametersOfSetXMLNode.Length.ShouldBe(1);
            methodSetXMLNodePrametersTypes.Length.ShouldBe(1);
            methodSetXMLNodePrametersTypes.Length.ShouldBe(parametersOfSetXMLNode.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetXMLNode) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_SetXMLNode_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetXMLNode, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetXMLNode) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_SetXMLNode_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetXMLNodePrametersTypes = new Type[] { typeof(XmlNode) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodSetXMLNode, Fixture, methodSetXMLNodePrametersTypes);

            // Assert
            methodSetXMLNodePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetXMLNode) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_SetXMLNode_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetXMLNode, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetXMLNode) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_SetXMLNode_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodSetXMLNodePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodSetXMLNode, Fixture, methodSetXMLNodePrametersTypes);
        }

        #endregion

        #region Method Call : (SetXMLNode) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_SetXMLNode_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var oNode = CreateType<XmlNode>();
            var oXMLDocument = CreateType<XmlDocument>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.SetXMLNode(oNode, oXMLDocument);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetXMLNode) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_SetXMLNode_Method_DirectCall_Overloading_Of_1_No_Exception_Thrown_Test()
        {
            // Arrange
            var oNode = CreateType<XmlNode>();
            var oXMLDocument = CreateType<XmlDocument>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.SetXMLNode(oNode, oXMLDocument);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (SetXMLNode) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_SetXMLNode_Method_Call_Void_Overloading_Of_1_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var oNode = CreateType<XmlNode>();
            var oXMLDocument = CreateType<XmlDocument>();
            var methodSetXMLNodePrametersTypes = new Type[] { typeof(XmlNode), typeof(XmlDocument) };
            object[] parametersOfSetXMLNode = { oNode, oXMLDocument };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetXMLNode, methodSetXMLNodePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfSetXMLNode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetXMLNode.ShouldNotBeNull();
            parametersOfSetXMLNode.Length.ShouldBe(2);
            methodSetXMLNodePrametersTypes.Length.ShouldBe(2);
            methodSetXMLNodePrametersTypes.Length.ShouldBe(parametersOfSetXMLNode.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetXMLNode) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_SetXMLNode_Method_Call_Void_Overloading_Of_1_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var oNode = CreateType<XmlNode>();
            var oXMLDocument = CreateType<XmlDocument>();
            var methodSetXMLNodePrametersTypes = new Type[] { typeof(XmlNode), typeof(XmlDocument) };
            object[] parametersOfSetXMLNode = { oNode, oXMLDocument };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetXMLNode, methodSetXMLNodePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfSetXMLNode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetXMLNode.ShouldNotBeNull();
            parametersOfSetXMLNode.Length.ShouldBe(2);
            methodSetXMLNodePrametersTypes.Length.ShouldBe(2);
            methodSetXMLNodePrametersTypes.Length.ShouldBe(parametersOfSetXMLNode.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetXMLNode) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_SetXMLNode_Method_Call_Void_Overloading_Of_1_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oNode = CreateType<XmlNode>();
            var oXMLDocument = CreateType<XmlDocument>();
            var methodSetXMLNodePrametersTypes = new Type[] { typeof(XmlNode), typeof(XmlDocument) };
            object[] parametersOfSetXMLNode = { oNode, oXMLDocument };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cStructInstance, MethodSetXMLNode, parametersOfSetXMLNode, methodSetXMLNodePrametersTypes);

            // Assert
            parametersOfSetXMLNode.ShouldNotBeNull();
            parametersOfSetXMLNode.Length.ShouldBe(2);
            methodSetXMLNodePrametersTypes.Length.ShouldBe(2);
            methodSetXMLNodePrametersTypes.Length.ShouldBe(parametersOfSetXMLNode.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetXMLNode) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_SetXMLNode_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetXMLNode, 1);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetXMLNode) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_SetXMLNode_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetXMLNodePrametersTypes = new Type[] { typeof(XmlNode), typeof(XmlDocument) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodSetXMLNode, Fixture, methodSetXMLNodePrametersTypes);

            // Assert
            methodSetXMLNodePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetXMLNode) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_SetXMLNode_Method_Call_Overloading_Of_1_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetXMLNode, 1);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (XML) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_XML_Method_Call_Internally(Type[] types)
        {
            var methodXMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodXML, Fixture, methodXMLPrametersTypes);
        }

        #endregion

        #region Method Call : (XML) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_XML_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.XML();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (XML) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_XML_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.XML();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (XML) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_XML_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodXMLPrametersTypes = null;
            object[] parametersOfXML = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodXML, methodXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, string>(_cStructInstanceFixture, out exception1, parametersOfXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, string>(_cStructInstance, MethodXML, parametersOfXML, methodXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfXML.ShouldBeNull();
            methodXMLPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (XML) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_XML_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodXMLPrametersTypes = null;
            object[] parametersOfXML = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodXML, methodXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, string>(_cStructInstanceFixture, out exception1, parametersOfXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, string>(_cStructInstance, MethodXML, parametersOfXML, methodXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfXML.ShouldBeNull();
            methodXMLPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (XML) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_XML_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodXMLPrametersTypes = null;
            object[] parametersOfXML = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodXML, methodXMLPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfXML);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfXML.ShouldBeNull();
            methodXMLPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (XML) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_XML_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodXMLPrametersTypes = null;
            object[] parametersOfXML = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, string>(_cStructInstance, MethodXML, parametersOfXML, methodXMLPrametersTypes);

            // Assert
            parametersOfXML.ShouldBeNull();
            methodXMLPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (XML) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_XML_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodXMLPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodXML, Fixture, methodXMLPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodXMLPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (XML) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_XML_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodXMLPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodXML, Fixture, methodXMLPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodXMLPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (XML) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_XML_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodXMLPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodXML, Fixture, methodXMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodXMLPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (XML) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_XML_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodXML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (XML) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_XML_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodXML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_ToString_Method_Call_Internally(Type[] types)
        {
            var methodToStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodToString, Fixture, methodToStringPrametersTypes);
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ToString_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var bEncode = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.ToString(bEncode);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ToString_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var bEncode = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.ToString(bEncode);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ToString_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var bEncode = CreateType<bool>();
            var methodToStringPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfToString = { bEncode };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodToString, methodToStringPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, string>(_cStructInstanceFixture, out exception1, parametersOfToString);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, string>(_cStructInstance, MethodToString, parametersOfToString, methodToStringPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfToString.ShouldNotBeNull();
            parametersOfToString.Length.ShouldBe(1);
            methodToStringPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ToString_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var bEncode = CreateType<bool>();
            var methodToStringPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfToString = { bEncode };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodToString, methodToStringPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, string>(_cStructInstanceFixture, out exception1, parametersOfToString);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, string>(_cStructInstance, MethodToString, parametersOfToString, methodToStringPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfToString.ShouldNotBeNull();
            parametersOfToString.Length.ShouldBe(1);
            methodToStringPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ToString_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var bEncode = CreateType<bool>();
            var methodToStringPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfToString = { bEncode };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodToString, methodToStringPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfToString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfToString.ShouldNotBeNull();
            parametersOfToString.Length.ShouldBe(1);
            methodToStringPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ToString_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var bEncode = CreateType<bool>();
            var methodToStringPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfToString = { bEncode };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, string>(_cStructInstance, MethodToString, parametersOfToString, methodToStringPrametersTypes);

            // Assert
            parametersOfToString.ShouldNotBeNull();
            parametersOfToString.Length.ShouldBe(1);
            methodToStringPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ToString_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodToStringPrametersTypes = new Type[] { typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodToString, Fixture, methodToStringPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodToStringPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ToString_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodToStringPrametersTypes = new Type[] { typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodToString, Fixture, methodToStringPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodToStringPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ToString_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodToStringPrametersTypes = new Type[] { typeof(bool) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodToString, Fixture, methodToStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodToStringPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ToString_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodToString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ToString_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodToString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ToString_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodToString, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ToJSONString) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_ToJSONString_Method_Call_Internally(Type[] types)
        {
            var methodToJSONStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodToJSONString, Fixture, methodToJSONStringPrametersTypes);
        }

        #endregion

        #region Method Call : (ToJSONString) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ToJSONString_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.ToJSONString();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ToJSONString) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ToJSONString_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.ToJSONString();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ToJSONString) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ToJSONString_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodToJSONStringPrametersTypes = null;
            object[] parametersOfToJSONString = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodToJSONString, methodToJSONStringPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, string>(_cStructInstanceFixture, out exception1, parametersOfToJSONString);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, string>(_cStructInstance, MethodToJSONString, parametersOfToJSONString, methodToJSONStringPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfToJSONString.ShouldBeNull();
            methodToJSONStringPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ToJSONString) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ToJSONString_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodToJSONStringPrametersTypes = null;
            object[] parametersOfToJSONString = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodToJSONString, methodToJSONStringPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, string>(_cStructInstanceFixture, out exception1, parametersOfToJSONString);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, string>(_cStructInstance, MethodToJSONString, parametersOfToJSONString, methodToJSONStringPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfToJSONString.ShouldBeNull();
            methodToJSONStringPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ToJSONString) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ToJSONString_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodToJSONStringPrametersTypes = null;
            object[] parametersOfToJSONString = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodToJSONString, methodToJSONStringPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfToJSONString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfToJSONString.ShouldBeNull();
            methodToJSONStringPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ToJSONString) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ToJSONString_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodToJSONStringPrametersTypes = null;
            object[] parametersOfToJSONString = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, string>(_cStructInstance, MethodToJSONString, parametersOfToJSONString, methodToJSONStringPrametersTypes);

            // Assert
            parametersOfToJSONString.ShouldBeNull();
            methodToJSONStringPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ToJSONString) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ToJSONString_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodToJSONStringPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodToJSONString, Fixture, methodToJSONStringPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodToJSONStringPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ToJSONString) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ToJSONString_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodToJSONStringPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodToJSONString, Fixture, methodToJSONStringPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodToJSONStringPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ToJSONString) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ToJSONString_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodToJSONStringPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodToJSONString, Fixture, methodToJSONStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodToJSONStringPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ToJSONString) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ToJSONString_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodToJSONString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ToJSONString) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ToJSONString_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodToJSONString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (FromString) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_FromString_Method_Call_Internally(Type[] types)
        {
            var methodFromStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodFromString, Fixture, methodFromStringPrametersTypes);
        }

        #endregion

        #region Method Call : (FromString) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_FromString_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var s = CreateType<string>();
            var bDecode = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.FromString(s, bDecode);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (FromString) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_FromString_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var s = CreateType<string>();
            var bDecode = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.FromString(s, bDecode);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (FromString) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_FromString_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var s = CreateType<string>();
            var bDecode = CreateType<bool>();
            var methodFromStringPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfFromString = { s, bDecode };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodFromString, methodFromStringPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, bool>(_cStructInstanceFixture, out exception1, parametersOfFromString);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, bool>(_cStructInstance, MethodFromString, parametersOfFromString, methodFromStringPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfFromString.ShouldNotBeNull();
            parametersOfFromString.Length.ShouldBe(2);
            methodFromStringPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (FromString) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_FromString_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var s = CreateType<string>();
            var bDecode = CreateType<bool>();
            var methodFromStringPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfFromString = { s, bDecode };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodFromString, methodFromStringPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, bool>(_cStructInstanceFixture, out exception1, parametersOfFromString);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, bool>(_cStructInstance, MethodFromString, parametersOfFromString, methodFromStringPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfFromString.ShouldNotBeNull();
            parametersOfFromString.Length.ShouldBe(2);
            methodFromStringPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (FromString) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_FromString_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var s = CreateType<string>();
            var bDecode = CreateType<bool>();
            var methodFromStringPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfFromString = { s, bDecode };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodFromString, methodFromStringPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfFromString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfFromString.ShouldNotBeNull();
            parametersOfFromString.Length.ShouldBe(2);
            methodFromStringPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FromString) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_FromString_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var s = CreateType<string>();
            var bDecode = CreateType<bool>();
            var methodFromStringPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfFromString = { s, bDecode };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, bool>(_cStructInstance, MethodFromString, parametersOfFromString, methodFromStringPrametersTypes);

            // Assert
            parametersOfFromString.ShouldNotBeNull();
            parametersOfFromString.Length.ShouldBe(2);
            methodFromStringPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FromString) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_FromString_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodFromStringPrametersTypes = new Type[] { typeof(string), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodFromString, Fixture, methodFromStringPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodFromStringPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (FromString) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_FromString_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodFromStringPrametersTypes = new Type[] { typeof(string), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodFromString, Fixture, methodFromStringPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodFromStringPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (FromString) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_FromString_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFromStringPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodFromString, Fixture, methodFromStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodFromStringPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FromString) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_FromString_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFromString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (FromString) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_FromString_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFromString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (FromString) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_FromString_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodFromString, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddElement) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_AddElement_Method_Call_Internally(Type[] types)
        {
            var methodAddElementPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodAddElement, Fixture, methodAddElementPrametersTypes);
        }

        #endregion

        #region Method Call : (AddElement) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_AddElement_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sValue = CreateType<string>();
            var methodAddElementPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfAddElement = { sItemName, sValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddElement, methodAddElementPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfAddElement);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddElement.ShouldNotBeNull();
            parametersOfAddElement.Length.ShouldBe(2);
            methodAddElementPrametersTypes.Length.ShouldBe(2);
            methodAddElementPrametersTypes.Length.ShouldBe(parametersOfAddElement.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddElement) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_AddElement_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sValue = CreateType<string>();
            var methodAddElementPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfAddElement = { sItemName, sValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddElement, methodAddElementPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfAddElement);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddElement.ShouldNotBeNull();
            parametersOfAddElement.Length.ShouldBe(2);
            methodAddElementPrametersTypes.Length.ShouldBe(2);
            methodAddElementPrametersTypes.Length.ShouldBe(parametersOfAddElement.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddElement) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_AddElement_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sValue = CreateType<string>();
            var methodAddElementPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfAddElement = { sItemName, sValue };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cStructInstance, MethodAddElement, parametersOfAddElement, methodAddElementPrametersTypes);

            // Assert
            parametersOfAddElement.ShouldNotBeNull();
            parametersOfAddElement.Length.ShouldBe(2);
            methodAddElementPrametersTypes.Length.ShouldBe(2);
            methodAddElementPrametersTypes.Length.ShouldBe(parametersOfAddElement.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddElement) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_AddElement_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddElement, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddElement) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_AddElement_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddElementPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodAddElement, Fixture, methodAddElementPrametersTypes);

            // Assert
            methodAddElementPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddElement) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_AddElement_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddElement, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddAttribute) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_AddAttribute_Method_Call_Internally(Type[] types)
        {
            var methodAddAttributePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodAddAttribute, Fixture, methodAddAttributePrametersTypes);
        }

        #endregion

        #region Method Call : (AddAttribute) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_AddAttribute_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sValue = CreateType<string>();
            var methodAddAttributePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfAddAttribute = { sItemName, sValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddAttribute, methodAddAttributePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfAddAttribute);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddAttribute.ShouldNotBeNull();
            parametersOfAddAttribute.Length.ShouldBe(2);
            methodAddAttributePrametersTypes.Length.ShouldBe(2);
            methodAddAttributePrametersTypes.Length.ShouldBe(parametersOfAddAttribute.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddAttribute) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_AddAttribute_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sValue = CreateType<string>();
            var methodAddAttributePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfAddAttribute = { sItemName, sValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddAttribute, methodAddAttributePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfAddAttribute);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddAttribute.ShouldNotBeNull();
            parametersOfAddAttribute.Length.ShouldBe(2);
            methodAddAttributePrametersTypes.Length.ShouldBe(2);
            methodAddAttributePrametersTypes.Length.ShouldBe(parametersOfAddAttribute.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddAttribute) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_AddAttribute_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sValue = CreateType<string>();
            var methodAddAttributePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfAddAttribute = { sItemName, sValue };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cStructInstance, MethodAddAttribute, parametersOfAddAttribute, methodAddAttributePrametersTypes);

            // Assert
            parametersOfAddAttribute.ShouldNotBeNull();
            parametersOfAddAttribute.Length.ShouldBe(2);
            methodAddAttributePrametersTypes.Length.ShouldBe(2);
            methodAddAttributePrametersTypes.Length.ShouldBe(parametersOfAddAttribute.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddAttribute) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_AddAttribute_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddAttribute, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddAttribute) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_AddAttribute_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddAttributePrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodAddAttribute, Fixture, methodAddAttributePrametersTypes);

            // Assert
            methodAddAttributePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddAttribute) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_AddAttribute_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddAttribute, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetNodeInternal) (Return Type : XmlNode) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_GetNodeInternal_Method_Call_Internally(Type[] types)
        {
            var methodGetNodeInternalPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetNodeInternal, Fixture, methodGetNodeInternalPrametersTypes);
        }

        #endregion

        #region Method Call : (GetNodeInternal) (Return Type : XmlNode) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetNodeInternal_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetNodeInternalPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetNodeInternal = { sItemName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetNodeInternal, methodGetNodeInternalPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, XmlNode>(_cStructInstanceFixture, out exception1, parametersOfGetNodeInternal);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, XmlNode>(_cStructInstance, MethodGetNodeInternal, parametersOfGetNodeInternal, methodGetNodeInternalPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetNodeInternal.ShouldNotBeNull();
            parametersOfGetNodeInternal.Length.ShouldBe(1);
            methodGetNodeInternalPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetNodeInternal) (Return Type : XmlNode) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetNodeInternal_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetNodeInternalPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetNodeInternal = { sItemName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetNodeInternal, methodGetNodeInternalPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, XmlNode>(_cStructInstanceFixture, out exception1, parametersOfGetNodeInternal);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, XmlNode>(_cStructInstance, MethodGetNodeInternal, parametersOfGetNodeInternal, methodGetNodeInternalPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetNodeInternal.ShouldNotBeNull();
            parametersOfGetNodeInternal.Length.ShouldBe(1);
            methodGetNodeInternalPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetNodeInternal) (Return Type : XmlNode) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetNodeInternal_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetNodeInternalPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetNodeInternal = { sItemName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetNodeInternal, methodGetNodeInternalPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfGetNodeInternal);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetNodeInternal.ShouldNotBeNull();
            parametersOfGetNodeInternal.Length.ShouldBe(1);
            methodGetNodeInternalPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetNodeInternal) (Return Type : XmlNode) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetNodeInternal_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetNodeInternalPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetNodeInternal = { sItemName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, XmlNode>(_cStructInstance, MethodGetNodeInternal, parametersOfGetNodeInternal, methodGetNodeInternalPrametersTypes);

            // Assert
            parametersOfGetNodeInternal.ShouldNotBeNull();
            parametersOfGetNodeInternal.Length.ShouldBe(1);
            methodGetNodeInternalPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetNodeInternal) (Return Type : XmlNode) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetNodeInternal_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetNodeInternalPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetNodeInternal, Fixture, methodGetNodeInternalPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetNodeInternalPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetNodeInternal) (Return Type : XmlNode) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetNodeInternal_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetNodeInternalPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetNodeInternal, Fixture, methodGetNodeInternalPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetNodeInternalPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetNodeInternal) (Return Type : XmlNode) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetNodeInternal_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetNodeInternalPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetNodeInternal, Fixture, methodGetNodeInternalPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetNodeInternalPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetNodeInternal) (Return Type : XmlNode) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetNodeInternal_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetNodeInternal, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetNodeInternal) (Return Type : XmlNode) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetNodeInternal_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetNodeInternal, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetNodeInternal) (Return Type : XmlNode) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetNodeInternal_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetNodeInternal, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAttributeInternal) (Return Type : XmlAttribute) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_GetAttributeInternal_Method_Call_Internally(Type[] types)
        {
            var methodGetAttributeInternalPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetAttributeInternal, Fixture, methodGetAttributeInternalPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAttributeInternal) (Return Type : XmlAttribute) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetAttributeInternal_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetAttributeInternalPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetAttributeInternal = { sItemName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetAttributeInternal, methodGetAttributeInternalPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, XmlAttribute>(_cStructInstanceFixture, out exception1, parametersOfGetAttributeInternal);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, XmlAttribute>(_cStructInstance, MethodGetAttributeInternal, parametersOfGetAttributeInternal, methodGetAttributeInternalPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetAttributeInternal.ShouldNotBeNull();
            parametersOfGetAttributeInternal.Length.ShouldBe(1);
            methodGetAttributeInternalPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetAttributeInternal) (Return Type : XmlAttribute) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetAttributeInternal_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetAttributeInternalPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetAttributeInternal = { sItemName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetAttributeInternal, methodGetAttributeInternalPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, XmlAttribute>(_cStructInstanceFixture, out exception1, parametersOfGetAttributeInternal);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, XmlAttribute>(_cStructInstance, MethodGetAttributeInternal, parametersOfGetAttributeInternal, methodGetAttributeInternalPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetAttributeInternal.ShouldNotBeNull();
            parametersOfGetAttributeInternal.Length.ShouldBe(1);
            methodGetAttributeInternalPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetAttributeInternal) (Return Type : XmlAttribute) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetAttributeInternal_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetAttributeInternalPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetAttributeInternal = { sItemName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetAttributeInternal, methodGetAttributeInternalPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfGetAttributeInternal);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetAttributeInternal.ShouldNotBeNull();
            parametersOfGetAttributeInternal.Length.ShouldBe(1);
            methodGetAttributeInternalPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAttributeInternal) (Return Type : XmlAttribute) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetAttributeInternal_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetAttributeInternalPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetAttributeInternal = { sItemName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, XmlAttribute>(_cStructInstance, MethodGetAttributeInternal, parametersOfGetAttributeInternal, methodGetAttributeInternalPrametersTypes);

            // Assert
            parametersOfGetAttributeInternal.ShouldNotBeNull();
            parametersOfGetAttributeInternal.Length.ShouldBe(1);
            methodGetAttributeInternalPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAttributeInternal) (Return Type : XmlAttribute) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetAttributeInternal_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetAttributeInternalPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetAttributeInternal, Fixture, methodGetAttributeInternalPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetAttributeInternalPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetAttributeInternal) (Return Type : XmlAttribute) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetAttributeInternal_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetAttributeInternalPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetAttributeInternal, Fixture, methodGetAttributeInternalPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetAttributeInternalPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetAttributeInternal) (Return Type : XmlAttribute) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetAttributeInternal_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetAttributeInternalPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetAttributeInternal, Fixture, methodGetAttributeInternalPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetAttributeInternalPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAttributeInternal) (Return Type : XmlAttribute) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetAttributeInternal_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetAttributeInternal, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetAttributeInternal) (Return Type : XmlAttribute) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetAttributeInternal_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetAttributeInternal, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAttributeInternal) (Return Type : XmlAttribute) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetAttributeInternal_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetAttributeInternal, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DecodeXMLInt) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_DecodeXMLInt_Method_Call_Internally(Type[] types)
        {
            var methodDecodeXMLIntPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodDecodeXMLInt, Fixture, methodDecodeXMLIntPrametersTypes);
        }

        #endregion

        #region Method Call : (DecodeXMLInt) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_DecodeXMLInt_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var s = CreateType<string>();
            var iDefault = CreateType<int>();
            var methodDecodeXMLIntPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfDecodeXMLInt = { s, iDefault };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDecodeXMLInt, methodDecodeXMLIntPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, int>(_cStructInstanceFixture, out exception1, parametersOfDecodeXMLInt);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, int>(_cStructInstance, MethodDecodeXMLInt, parametersOfDecodeXMLInt, methodDecodeXMLIntPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDecodeXMLInt.ShouldNotBeNull();
            parametersOfDecodeXMLInt.Length.ShouldBe(2);
            methodDecodeXMLIntPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (DecodeXMLInt) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_DecodeXMLInt_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var s = CreateType<string>();
            var iDefault = CreateType<int>();
            var methodDecodeXMLIntPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfDecodeXMLInt = { s, iDefault };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDecodeXMLInt, methodDecodeXMLIntPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, int>(_cStructInstanceFixture, out exception1, parametersOfDecodeXMLInt);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, int>(_cStructInstance, MethodDecodeXMLInt, parametersOfDecodeXMLInt, methodDecodeXMLIntPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDecodeXMLInt.ShouldNotBeNull();
            parametersOfDecodeXMLInt.Length.ShouldBe(2);
            methodDecodeXMLIntPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (DecodeXMLInt) (Return Type : int) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_DecodeXMLInt_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var s = CreateType<string>();
            var iDefault = CreateType<int>();
            var methodDecodeXMLIntPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfDecodeXMLInt = { s, iDefault };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDecodeXMLInt, methodDecodeXMLIntPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfDecodeXMLInt);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDecodeXMLInt.ShouldNotBeNull();
            parametersOfDecodeXMLInt.Length.ShouldBe(2);
            methodDecodeXMLIntPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DecodeXMLInt) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_DecodeXMLInt_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var s = CreateType<string>();
            var iDefault = CreateType<int>();
            var methodDecodeXMLIntPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfDecodeXMLInt = { s, iDefault };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, int>(_cStructInstance, MethodDecodeXMLInt, parametersOfDecodeXMLInt, methodDecodeXMLIntPrametersTypes);

            // Assert
            parametersOfDecodeXMLInt.ShouldNotBeNull();
            parametersOfDecodeXMLInt.Length.ShouldBe(2);
            methodDecodeXMLIntPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DecodeXMLInt) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_DecodeXMLInt_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodDecodeXMLIntPrametersTypes = new Type[] { typeof(string), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodDecodeXMLInt, Fixture, methodDecodeXMLIntPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodDecodeXMLIntPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (DecodeXMLInt) (Return Type : int) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_DecodeXMLInt_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodDecodeXMLIntPrametersTypes = new Type[] { typeof(string), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodDecodeXMLInt, Fixture, methodDecodeXMLIntPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodDecodeXMLIntPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (DecodeXMLInt) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_DecodeXMLInt_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDecodeXMLIntPrametersTypes = new Type[] { typeof(string), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodDecodeXMLInt, Fixture, methodDecodeXMLIntPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDecodeXMLIntPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DecodeXMLInt) (Return Type : int) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_DecodeXMLInt_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDecodeXMLInt, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (DecodeXMLInt) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_DecodeXMLInt_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDecodeXMLInt, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DecodeXMLInt) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_DecodeXMLInt_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDecodeXMLInt, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DecodeXMLDouble) (Return Type : double) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_DecodeXMLDouble_Method_Call_Internally(Type[] types)
        {
            var methodDecodeXMLDoublePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodDecodeXMLDouble, Fixture, methodDecodeXMLDoublePrametersTypes);
        }

        #endregion

        #region Method Call : (DecodeXMLDouble) (Return Type : double) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_DecodeXMLDouble_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var s = CreateType<string>();
            var dblDefault = CreateType<double>();
            var methodDecodeXMLDoublePrametersTypes = new Type[] { typeof(string), typeof(double) };
            object[] parametersOfDecodeXMLDouble = { s, dblDefault };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDecodeXMLDouble, methodDecodeXMLDoublePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, double>(_cStructInstanceFixture, out exception1, parametersOfDecodeXMLDouble);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, double>(_cStructInstance, MethodDecodeXMLDouble, parametersOfDecodeXMLDouble, methodDecodeXMLDoublePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDecodeXMLDouble.ShouldNotBeNull();
            parametersOfDecodeXMLDouble.Length.ShouldBe(2);
            methodDecodeXMLDoublePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (DecodeXMLDouble) (Return Type : double) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_DecodeXMLDouble_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var s = CreateType<string>();
            var dblDefault = CreateType<double>();
            var methodDecodeXMLDoublePrametersTypes = new Type[] { typeof(string), typeof(double) };
            object[] parametersOfDecodeXMLDouble = { s, dblDefault };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDecodeXMLDouble, methodDecodeXMLDoublePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, double>(_cStructInstanceFixture, out exception1, parametersOfDecodeXMLDouble);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, double>(_cStructInstance, MethodDecodeXMLDouble, parametersOfDecodeXMLDouble, methodDecodeXMLDoublePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDecodeXMLDouble.ShouldNotBeNull();
            parametersOfDecodeXMLDouble.Length.ShouldBe(2);
            methodDecodeXMLDoublePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (DecodeXMLDouble) (Return Type : double) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_DecodeXMLDouble_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var s = CreateType<string>();
            var dblDefault = CreateType<double>();
            var methodDecodeXMLDoublePrametersTypes = new Type[] { typeof(string), typeof(double) };
            object[] parametersOfDecodeXMLDouble = { s, dblDefault };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDecodeXMLDouble, methodDecodeXMLDoublePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfDecodeXMLDouble);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDecodeXMLDouble.ShouldNotBeNull();
            parametersOfDecodeXMLDouble.Length.ShouldBe(2);
            methodDecodeXMLDoublePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DecodeXMLDouble) (Return Type : double) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_DecodeXMLDouble_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var s = CreateType<string>();
            var dblDefault = CreateType<double>();
            var methodDecodeXMLDoublePrametersTypes = new Type[] { typeof(string), typeof(double) };
            object[] parametersOfDecodeXMLDouble = { s, dblDefault };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, double>(_cStructInstance, MethodDecodeXMLDouble, parametersOfDecodeXMLDouble, methodDecodeXMLDoublePrametersTypes);

            // Assert
            parametersOfDecodeXMLDouble.ShouldNotBeNull();
            parametersOfDecodeXMLDouble.Length.ShouldBe(2);
            methodDecodeXMLDoublePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DecodeXMLDouble) (Return Type : double) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_DecodeXMLDouble_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodDecodeXMLDoublePrametersTypes = new Type[] { typeof(string), typeof(double) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodDecodeXMLDouble, Fixture, methodDecodeXMLDoublePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodDecodeXMLDoublePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (DecodeXMLDouble) (Return Type : double) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_DecodeXMLDouble_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodDecodeXMLDoublePrametersTypes = new Type[] { typeof(string), typeof(double) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodDecodeXMLDouble, Fixture, methodDecodeXMLDoublePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodDecodeXMLDoublePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (DecodeXMLDouble) (Return Type : double) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_DecodeXMLDouble_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDecodeXMLDoublePrametersTypes = new Type[] { typeof(string), typeof(double) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodDecodeXMLDouble, Fixture, methodDecodeXMLDoublePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDecodeXMLDoublePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DecodeXMLDouble) (Return Type : double) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_DecodeXMLDouble_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDecodeXMLDouble, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (DecodeXMLDouble) (Return Type : double) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_DecodeXMLDouble_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDecodeXMLDouble, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DecodeXMLDouble) (Return Type : double) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_DecodeXMLDouble_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDecodeXMLDouble, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DecodeXMLDecimal) (Return Type : decimal) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_DecodeXMLDecimal_Method_Call_Internally(Type[] types)
        {
            var methodDecodeXMLDecimalPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodDecodeXMLDecimal, Fixture, methodDecodeXMLDecimalPrametersTypes);
        }

        #endregion

        #region Method Call : (DecodeXMLDecimal) (Return Type : decimal) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_DecodeXMLDecimal_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var s = CreateType<string>();
            var decDefault = CreateType<decimal>();
            var methodDecodeXMLDecimalPrametersTypes = new Type[] { typeof(string), typeof(decimal) };
            object[] parametersOfDecodeXMLDecimal = { s, decDefault };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDecodeXMLDecimal, methodDecodeXMLDecimalPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, decimal>(_cStructInstanceFixture, out exception1, parametersOfDecodeXMLDecimal);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, decimal>(_cStructInstance, MethodDecodeXMLDecimal, parametersOfDecodeXMLDecimal, methodDecodeXMLDecimalPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDecodeXMLDecimal.ShouldNotBeNull();
            parametersOfDecodeXMLDecimal.Length.ShouldBe(2);
            methodDecodeXMLDecimalPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (DecodeXMLDecimal) (Return Type : decimal) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_DecodeXMLDecimal_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var s = CreateType<string>();
            var decDefault = CreateType<decimal>();
            var methodDecodeXMLDecimalPrametersTypes = new Type[] { typeof(string), typeof(decimal) };
            object[] parametersOfDecodeXMLDecimal = { s, decDefault };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDecodeXMLDecimal, methodDecodeXMLDecimalPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, decimal>(_cStructInstanceFixture, out exception1, parametersOfDecodeXMLDecimal);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, decimal>(_cStructInstance, MethodDecodeXMLDecimal, parametersOfDecodeXMLDecimal, methodDecodeXMLDecimalPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDecodeXMLDecimal.ShouldNotBeNull();
            parametersOfDecodeXMLDecimal.Length.ShouldBe(2);
            methodDecodeXMLDecimalPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (DecodeXMLDecimal) (Return Type : decimal) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_DecodeXMLDecimal_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var s = CreateType<string>();
            var decDefault = CreateType<decimal>();
            var methodDecodeXMLDecimalPrametersTypes = new Type[] { typeof(string), typeof(decimal) };
            object[] parametersOfDecodeXMLDecimal = { s, decDefault };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDecodeXMLDecimal, methodDecodeXMLDecimalPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfDecodeXMLDecimal);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDecodeXMLDecimal.ShouldNotBeNull();
            parametersOfDecodeXMLDecimal.Length.ShouldBe(2);
            methodDecodeXMLDecimalPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DecodeXMLDecimal) (Return Type : decimal) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_DecodeXMLDecimal_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var s = CreateType<string>();
            var decDefault = CreateType<decimal>();
            var methodDecodeXMLDecimalPrametersTypes = new Type[] { typeof(string), typeof(decimal) };
            object[] parametersOfDecodeXMLDecimal = { s, decDefault };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, decimal>(_cStructInstance, MethodDecodeXMLDecimal, parametersOfDecodeXMLDecimal, methodDecodeXMLDecimalPrametersTypes);

            // Assert
            parametersOfDecodeXMLDecimal.ShouldNotBeNull();
            parametersOfDecodeXMLDecimal.Length.ShouldBe(2);
            methodDecodeXMLDecimalPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DecodeXMLDecimal) (Return Type : decimal) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_DecodeXMLDecimal_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodDecodeXMLDecimalPrametersTypes = new Type[] { typeof(string), typeof(decimal) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodDecodeXMLDecimal, Fixture, methodDecodeXMLDecimalPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodDecodeXMLDecimalPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (DecodeXMLDecimal) (Return Type : decimal) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_DecodeXMLDecimal_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodDecodeXMLDecimalPrametersTypes = new Type[] { typeof(string), typeof(decimal) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodDecodeXMLDecimal, Fixture, methodDecodeXMLDecimalPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodDecodeXMLDecimalPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (DecodeXMLDecimal) (Return Type : decimal) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_DecodeXMLDecimal_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDecodeXMLDecimalPrametersTypes = new Type[] { typeof(string), typeof(decimal) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodDecodeXMLDecimal, Fixture, methodDecodeXMLDecimalPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDecodeXMLDecimalPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DecodeXMLDecimal) (Return Type : decimal) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_DecodeXMLDecimal_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDecodeXMLDecimal, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (DecodeXMLDecimal) (Return Type : decimal) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_DecodeXMLDecimal_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDecodeXMLDecimal, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DecodeXMLDecimal) (Return Type : decimal) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_DecodeXMLDecimal_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDecodeXMLDecimal, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetChildNodeCollection) (Return Type : List<CStruct>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_GetChildNodeCollection_Method_Call_Internally(Type[] types)
        {
            var methodGetChildNodeCollectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetChildNodeCollection, Fixture, methodGetChildNodeCollectionPrametersTypes);
        }

        #endregion

        #region Method Call : (GetChildNodeCollection) (Return Type : List<CStruct>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetChildNodeCollection_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetChildNodeCollection();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetChildNodeCollection) (Return Type : List<CStruct>) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetChildNodeCollection_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetChildNodeCollection();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetChildNodeCollection) (Return Type : List<CStruct>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetChildNodeCollection_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetChildNodeCollectionPrametersTypes = null;
            object[] parametersOfGetChildNodeCollection = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetChildNodeCollection, methodGetChildNodeCollectionPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, List<CStruct>>(_cStructInstanceFixture, out exception1, parametersOfGetChildNodeCollection);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, List<CStruct>>(_cStructInstance, MethodGetChildNodeCollection, parametersOfGetChildNodeCollection, methodGetChildNodeCollectionPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetChildNodeCollection.ShouldBeNull();
            methodGetChildNodeCollectionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetChildNodeCollection) (Return Type : List<CStruct>) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetChildNodeCollection_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodGetChildNodeCollectionPrametersTypes = null;
            object[] parametersOfGetChildNodeCollection = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetChildNodeCollection, methodGetChildNodeCollectionPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, List<CStruct>>(_cStructInstanceFixture, out exception1, parametersOfGetChildNodeCollection);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, List<CStruct>>(_cStructInstance, MethodGetChildNodeCollection, parametersOfGetChildNodeCollection, methodGetChildNodeCollectionPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetChildNodeCollection.ShouldBeNull();
            methodGetChildNodeCollectionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetChildNodeCollection) (Return Type : List<CStruct>) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetChildNodeCollection_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetChildNodeCollectionPrametersTypes = null;
            object[] parametersOfGetChildNodeCollection = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetChildNodeCollection, methodGetChildNodeCollectionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfGetChildNodeCollection);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetChildNodeCollection.ShouldBeNull();
            methodGetChildNodeCollectionPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetChildNodeCollection) (Return Type : List<CStruct>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetChildNodeCollection_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetChildNodeCollectionPrametersTypes = null;
            object[] parametersOfGetChildNodeCollection = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, List<CStruct>>(_cStructInstance, MethodGetChildNodeCollection, parametersOfGetChildNodeCollection, methodGetChildNodeCollectionPrametersTypes);

            // Assert
            parametersOfGetChildNodeCollection.ShouldBeNull();
            methodGetChildNodeCollectionPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetChildNodeCollection) (Return Type : List<CStruct>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetChildNodeCollection_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetChildNodeCollectionPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetChildNodeCollection, Fixture, methodGetChildNodeCollectionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetChildNodeCollectionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetChildNodeCollection) (Return Type : List<CStruct>) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetChildNodeCollection_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetChildNodeCollectionPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetChildNodeCollection, Fixture, methodGetChildNodeCollectionPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetChildNodeCollectionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetChildNodeCollection) (Return Type : List<CStruct>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetChildNodeCollection_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetChildNodeCollectionPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetChildNodeCollection, Fixture, methodGetChildNodeCollectionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetChildNodeCollectionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetChildNodeCollection) (Return Type : List<CStruct>) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetChildNodeCollection_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetChildNodeCollection, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetChildNodeCollection) (Return Type : List<CStruct>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetChildNodeCollection_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetChildNodeCollection, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCollection) (Return Type : Queue<CStruct>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_GetCollection_Method_Call_Internally(Type[] types)
        {
            var methodGetCollectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetCollection, Fixture, methodGetCollectionPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCollection) (Return Type : Queue<CStruct>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetCollection_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetCollection(sItemName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetCollection) (Return Type : Queue<CStruct>) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetCollection_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetCollection(sItemName);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetCollection) (Return Type : Queue<CStruct>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetCollection_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetCollectionPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetCollection = { sItemName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetCollection, methodGetCollectionPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, Queue<CStruct>>(_cStructInstanceFixture, out exception1, parametersOfGetCollection);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, Queue<CStruct>>(_cStructInstance, MethodGetCollection, parametersOfGetCollection, methodGetCollectionPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetCollection.ShouldNotBeNull();
            parametersOfGetCollection.Length.ShouldBe(1);
            methodGetCollectionPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetCollection) (Return Type : Queue<CStruct>) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetCollection_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetCollectionPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetCollection = { sItemName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetCollection, methodGetCollectionPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, Queue<CStruct>>(_cStructInstanceFixture, out exception1, parametersOfGetCollection);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, Queue<CStruct>>(_cStructInstance, MethodGetCollection, parametersOfGetCollection, methodGetCollectionPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetCollection.ShouldNotBeNull();
            parametersOfGetCollection.Length.ShouldBe(1);
            methodGetCollectionPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetCollection) (Return Type : Queue<CStruct>) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetCollection_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetCollectionPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetCollection = { sItemName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetCollection, methodGetCollectionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfGetCollection);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetCollection.ShouldNotBeNull();
            parametersOfGetCollection.Length.ShouldBe(1);
            methodGetCollectionPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCollection) (Return Type : Queue<CStruct>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetCollection_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetCollectionPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetCollection = { sItemName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, Queue<CStruct>>(_cStructInstance, MethodGetCollection, parametersOfGetCollection, methodGetCollectionPrametersTypes);

            // Assert
            parametersOfGetCollection.ShouldNotBeNull();
            parametersOfGetCollection.Length.ShouldBe(1);
            methodGetCollectionPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCollection) (Return Type : Queue<CStruct>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetCollection_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCollectionPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetCollection, Fixture, methodGetCollectionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCollectionPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetCollection) (Return Type : Queue<CStruct>) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetCollection_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetCollectionPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetCollection, Fixture, methodGetCollectionPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetCollectionPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetCollection) (Return Type : Queue<CStruct>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetCollection_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCollectionPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetCollection, Fixture, methodGetCollectionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCollectionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCollection) (Return Type : Queue<CStruct>) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetCollection_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCollection, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetCollection) (Return Type : Queue<CStruct>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetCollection_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCollection, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCollection) (Return Type : Queue<CStruct>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetCollection_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCollection, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListSortedByAttribute) (Return Type : System.Collections.Generic.SortedList<string, CStruct>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_GetListSortedByAttribute_Method_Call_Internally(Type[] types)
        {
            var methodGetListSortedByAttributePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetListSortedByAttribute, Fixture, methodGetListSortedByAttributePrametersTypes);
        }

        #endregion

        #region Method Call : (GetListSortedByAttribute) (Return Type : System.Collections.Generic.SortedList<string, CStruct>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetListSortedByAttribute_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sAttribute = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetListSortedByAttribute(sItemName, sAttribute);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetListSortedByAttribute) (Return Type : System.Collections.Generic.SortedList<string, CStruct>) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetListSortedByAttribute_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sAttribute = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetListSortedByAttribute(sItemName, sAttribute);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetListSortedByAttribute) (Return Type : System.Collections.Generic.SortedList<string, CStruct>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetListSortedByAttribute_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sAttribute = CreateType<string>();
            var methodGetListSortedByAttributePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfGetListSortedByAttribute = { sItemName, sAttribute };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetListSortedByAttribute, methodGetListSortedByAttributePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, System.Collections.Generic.SortedList<string, CStruct>>(_cStructInstanceFixture, out exception1, parametersOfGetListSortedByAttribute);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, System.Collections.Generic.SortedList<string, CStruct>>(_cStructInstance, MethodGetListSortedByAttribute, parametersOfGetListSortedByAttribute, methodGetListSortedByAttributePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetListSortedByAttribute.ShouldNotBeNull();
            parametersOfGetListSortedByAttribute.Length.ShouldBe(2);
            methodGetListSortedByAttributePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetListSortedByAttribute) (Return Type : System.Collections.Generic.SortedList<string, CStruct>) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetListSortedByAttribute_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sAttribute = CreateType<string>();
            var methodGetListSortedByAttributePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfGetListSortedByAttribute = { sItemName, sAttribute };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetListSortedByAttribute, methodGetListSortedByAttributePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, System.Collections.Generic.SortedList<string, CStruct>>(_cStructInstanceFixture, out exception1, parametersOfGetListSortedByAttribute);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, System.Collections.Generic.SortedList<string, CStruct>>(_cStructInstance, MethodGetListSortedByAttribute, parametersOfGetListSortedByAttribute, methodGetListSortedByAttributePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetListSortedByAttribute.ShouldNotBeNull();
            parametersOfGetListSortedByAttribute.Length.ShouldBe(2);
            methodGetListSortedByAttributePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetListSortedByAttribute) (Return Type : System.Collections.Generic.SortedList<string, CStruct>) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetListSortedByAttribute_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sAttribute = CreateType<string>();
            var methodGetListSortedByAttributePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfGetListSortedByAttribute = { sItemName, sAttribute };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetListSortedByAttribute, methodGetListSortedByAttributePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfGetListSortedByAttribute);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetListSortedByAttribute.ShouldNotBeNull();
            parametersOfGetListSortedByAttribute.Length.ShouldBe(2);
            methodGetListSortedByAttributePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListSortedByAttribute) (Return Type : System.Collections.Generic.SortedList<string, CStruct>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetListSortedByAttribute_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sAttribute = CreateType<string>();
            var methodGetListSortedByAttributePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfGetListSortedByAttribute = { sItemName, sAttribute };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, System.Collections.Generic.SortedList<string, CStruct>>(_cStructInstance, MethodGetListSortedByAttribute, parametersOfGetListSortedByAttribute, methodGetListSortedByAttributePrametersTypes);

            // Assert
            parametersOfGetListSortedByAttribute.ShouldNotBeNull();
            parametersOfGetListSortedByAttribute.Length.ShouldBe(2);
            methodGetListSortedByAttributePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListSortedByAttribute) (Return Type : System.Collections.Generic.SortedList<string, CStruct>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetListSortedByAttribute_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetListSortedByAttributePrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetListSortedByAttribute, Fixture, methodGetListSortedByAttributePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetListSortedByAttributePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetListSortedByAttribute) (Return Type : System.Collections.Generic.SortedList<string, CStruct>) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetListSortedByAttribute_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetListSortedByAttributePrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetListSortedByAttribute, Fixture, methodGetListSortedByAttributePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetListSortedByAttributePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetListSortedByAttribute) (Return Type : System.Collections.Generic.SortedList<string, CStruct>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetListSortedByAttribute_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetListSortedByAttributePrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetListSortedByAttribute, Fixture, methodGetListSortedByAttributePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListSortedByAttributePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListSortedByAttribute) (Return Type : System.Collections.Generic.SortedList<string, CStruct>) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetListSortedByAttribute_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListSortedByAttribute, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetListSortedByAttribute) (Return Type : System.Collections.Generic.SortedList<string, CStruct>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetListSortedByAttribute_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListSortedByAttribute, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListSortedByAttribute) (Return Type : System.Collections.Generic.SortedList<string, CStruct>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetListSortedByAttribute_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetListSortedByAttribute, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListSortedByItem) (Return Type : System.Collections.Generic.SortedList<string, CStruct>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_GetListSortedByItem_Method_Call_Internally(Type[] types)
        {
            var methodGetListSortedByItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetListSortedByItem, Fixture, methodGetListSortedByItemPrametersTypes);
        }

        #endregion

        #region Method Call : (GetListSortedByItem) (Return Type : System.Collections.Generic.SortedList<string, CStruct>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetListSortedByItem_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sItem = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetListSortedByItem(sItemName, sItem);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetListSortedByItem) (Return Type : System.Collections.Generic.SortedList<string, CStruct>) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetListSortedByItem_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sItem = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetListSortedByItem(sItemName, sItem);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetListSortedByItem) (Return Type : System.Collections.Generic.SortedList<string, CStruct>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetListSortedByItem_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sItem = CreateType<string>();
            var methodGetListSortedByItemPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfGetListSortedByItem = { sItemName, sItem };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetListSortedByItem, methodGetListSortedByItemPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, System.Collections.Generic.SortedList<string, CStruct>>(_cStructInstanceFixture, out exception1, parametersOfGetListSortedByItem);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, System.Collections.Generic.SortedList<string, CStruct>>(_cStructInstance, MethodGetListSortedByItem, parametersOfGetListSortedByItem, methodGetListSortedByItemPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetListSortedByItem.ShouldNotBeNull();
            parametersOfGetListSortedByItem.Length.ShouldBe(2);
            methodGetListSortedByItemPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetListSortedByItem) (Return Type : System.Collections.Generic.SortedList<string, CStruct>) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetListSortedByItem_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sItem = CreateType<string>();
            var methodGetListSortedByItemPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfGetListSortedByItem = { sItemName, sItem };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetListSortedByItem, methodGetListSortedByItemPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, System.Collections.Generic.SortedList<string, CStruct>>(_cStructInstanceFixture, out exception1, parametersOfGetListSortedByItem);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, System.Collections.Generic.SortedList<string, CStruct>>(_cStructInstance, MethodGetListSortedByItem, parametersOfGetListSortedByItem, methodGetListSortedByItemPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetListSortedByItem.ShouldNotBeNull();
            parametersOfGetListSortedByItem.Length.ShouldBe(2);
            methodGetListSortedByItemPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetListSortedByItem) (Return Type : System.Collections.Generic.SortedList<string, CStruct>) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetListSortedByItem_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sItem = CreateType<string>();
            var methodGetListSortedByItemPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfGetListSortedByItem = { sItemName, sItem };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetListSortedByItem, methodGetListSortedByItemPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfGetListSortedByItem);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetListSortedByItem.ShouldNotBeNull();
            parametersOfGetListSortedByItem.Length.ShouldBe(2);
            methodGetListSortedByItemPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListSortedByItem) (Return Type : System.Collections.Generic.SortedList<string, CStruct>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetListSortedByItem_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sItem = CreateType<string>();
            var methodGetListSortedByItemPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfGetListSortedByItem = { sItemName, sItem };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, System.Collections.Generic.SortedList<string, CStruct>>(_cStructInstance, MethodGetListSortedByItem, parametersOfGetListSortedByItem, methodGetListSortedByItemPrametersTypes);

            // Assert
            parametersOfGetListSortedByItem.ShouldNotBeNull();
            parametersOfGetListSortedByItem.Length.ShouldBe(2);
            methodGetListSortedByItemPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListSortedByItem) (Return Type : System.Collections.Generic.SortedList<string, CStruct>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetListSortedByItem_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetListSortedByItemPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetListSortedByItem, Fixture, methodGetListSortedByItemPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetListSortedByItemPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetListSortedByItem) (Return Type : System.Collections.Generic.SortedList<string, CStruct>) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetListSortedByItem_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetListSortedByItemPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetListSortedByItem, Fixture, methodGetListSortedByItemPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetListSortedByItemPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetListSortedByItem) (Return Type : System.Collections.Generic.SortedList<string, CStruct>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetListSortedByItem_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetListSortedByItemPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetListSortedByItem, Fixture, methodGetListSortedByItemPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListSortedByItemPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListSortedByItem) (Return Type : System.Collections.Generic.SortedList<string, CStruct>) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetListSortedByItem_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListSortedByItem, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetListSortedByItem) (Return Type : System.Collections.Generic.SortedList<string, CStruct>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetListSortedByItem_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListSortedByItem, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListSortedByItem) (Return Type : System.Collections.Generic.SortedList<string, CStruct>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetListSortedByItem_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetListSortedByItem, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetList) (Return Type : System.Collections.Generic.List<CStruct>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_GetList_Method_Call_Internally(Type[] types)
        {
            var methodGetListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetList, Fixture, methodGetListPrametersTypes);
        }

        #endregion

        #region Method Call : (GetList) (Return Type : System.Collections.Generic.List<CStruct>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetList_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetList(sItemName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetList) (Return Type : System.Collections.Generic.List<CStruct>) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetList_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetList(sItemName);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetList) (Return Type : System.Collections.Generic.List<CStruct>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetList_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetListPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetList = { sItemName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetList, methodGetListPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, System.Collections.Generic.List<CStruct>>(_cStructInstanceFixture, out exception1, parametersOfGetList);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, System.Collections.Generic.List<CStruct>>(_cStructInstance, MethodGetList, parametersOfGetList, methodGetListPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetList.ShouldNotBeNull();
            parametersOfGetList.Length.ShouldBe(1);
            methodGetListPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetList) (Return Type : System.Collections.Generic.List<CStruct>) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetList_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetListPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetList = { sItemName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetList, methodGetListPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, System.Collections.Generic.List<CStruct>>(_cStructInstanceFixture, out exception1, parametersOfGetList);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, System.Collections.Generic.List<CStruct>>(_cStructInstance, MethodGetList, parametersOfGetList, methodGetListPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetList.ShouldNotBeNull();
            parametersOfGetList.Length.ShouldBe(1);
            methodGetListPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetList) (Return Type : System.Collections.Generic.List<CStruct>) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetList_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetListPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetList = { sItemName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetList, methodGetListPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfGetList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetList.ShouldNotBeNull();
            parametersOfGetList.Length.ShouldBe(1);
            methodGetListPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetList) (Return Type : System.Collections.Generic.List<CStruct>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetList_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetListPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetList = { sItemName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, System.Collections.Generic.List<CStruct>>(_cStructInstance, MethodGetList, parametersOfGetList, methodGetListPrametersTypes);

            // Assert
            parametersOfGetList.ShouldNotBeNull();
            parametersOfGetList.Length.ShouldBe(1);
            methodGetListPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetList) (Return Type : System.Collections.Generic.List<CStruct>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetList_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetListPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetList, Fixture, methodGetListPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetListPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetList) (Return Type : System.Collections.Generic.List<CStruct>) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetList_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetListPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetList, Fixture, methodGetListPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetListPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetList) (Return Type : System.Collections.Generic.List<CStruct>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetListPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetList, Fixture, methodGetListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetList) (Return Type : System.Collections.Generic.List<CStruct>) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetList_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetList, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetList) (Return Type : System.Collections.Generic.List<CStruct>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetList_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetList, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetList) (Return Type : System.Collections.Generic.List<CStruct>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetList_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetList, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetBoolean) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_GetBoolean_Method_Call_Internally(Type[] types)
        {
            var methodGetBooleanPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetBoolean, Fixture, methodGetBooleanPrametersTypes);
        }

        #endregion

        #region Method Call : (GetBoolean) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBoolean_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetBoolean(sItemName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetBoolean) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBoolean_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetBoolean(sItemName);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetBoolean) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBoolean_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetBooleanPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetBoolean = { sItemName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetBoolean, methodGetBooleanPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, bool>(_cStructInstanceFixture, out exception1, parametersOfGetBoolean);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, bool>(_cStructInstance, MethodGetBoolean, parametersOfGetBoolean, methodGetBooleanPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetBoolean.ShouldNotBeNull();
            parametersOfGetBoolean.Length.ShouldBe(1);
            methodGetBooleanPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetBoolean) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBoolean_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetBooleanPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetBoolean = { sItemName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetBoolean, methodGetBooleanPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, bool>(_cStructInstanceFixture, out exception1, parametersOfGetBoolean);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, bool>(_cStructInstance, MethodGetBoolean, parametersOfGetBoolean, methodGetBooleanPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetBoolean.ShouldNotBeNull();
            parametersOfGetBoolean.Length.ShouldBe(1);
            methodGetBooleanPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetBoolean) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBoolean_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetBooleanPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetBoolean = { sItemName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetBoolean, methodGetBooleanPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfGetBoolean);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetBoolean.ShouldNotBeNull();
            parametersOfGetBoolean.Length.ShouldBe(1);
            methodGetBooleanPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetBoolean) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBoolean_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetBooleanPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetBoolean = { sItemName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, bool>(_cStructInstance, MethodGetBoolean, parametersOfGetBoolean, methodGetBooleanPrametersTypes);

            // Assert
            parametersOfGetBoolean.ShouldNotBeNull();
            parametersOfGetBoolean.Length.ShouldBe(1);
            methodGetBooleanPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetBoolean) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBoolean_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetBooleanPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetBoolean, Fixture, methodGetBooleanPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetBooleanPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetBoolean) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBoolean_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetBooleanPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetBoolean, Fixture, methodGetBooleanPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetBooleanPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetBoolean) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBoolean_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetBooleanPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetBoolean, Fixture, methodGetBooleanPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetBooleanPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetBoolean) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBoolean_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetBoolean, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetBoolean) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBoolean_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetBoolean, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetBoolean) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBoolean_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetBoolean, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetBoolean) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_GetBoolean_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodGetBooleanPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetBoolean, Fixture, methodGetBooleanPrametersTypes);
        }

        #endregion

        #region Method Call : (GetBoolean) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBoolean_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bDefault = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetBoolean(sItemName, bDefault);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetBoolean) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBoolean_Method_DirectCall_Overloading_Of_1_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bDefault = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetBoolean(sItemName, bDefault);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetBoolean) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBoolean_Method_Call_Overloading_Of_1_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bDefault = CreateType<bool>();
            var methodGetBooleanPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfGetBoolean = { sItemName, bDefault };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetBoolean, methodGetBooleanPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, bool>(_cStructInstanceFixture, out exception1, parametersOfGetBoolean);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, bool>(_cStructInstance, MethodGetBoolean, parametersOfGetBoolean, methodGetBooleanPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetBoolean.ShouldNotBeNull();
            parametersOfGetBoolean.Length.ShouldBe(2);
            methodGetBooleanPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetBoolean) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBoolean_Method_Call_Overloading_Of_1_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bDefault = CreateType<bool>();
            var methodGetBooleanPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfGetBoolean = { sItemName, bDefault };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetBoolean, methodGetBooleanPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, bool>(_cStructInstanceFixture, out exception1, parametersOfGetBoolean);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, bool>(_cStructInstance, MethodGetBoolean, parametersOfGetBoolean, methodGetBooleanPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetBoolean.ShouldNotBeNull();
            parametersOfGetBoolean.Length.ShouldBe(2);
            methodGetBooleanPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetBoolean) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBoolean_Method_Call_Overloading_Of_1_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bDefault = CreateType<bool>();
            var methodGetBooleanPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfGetBoolean = { sItemName, bDefault };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetBoolean, methodGetBooleanPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfGetBoolean);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetBoolean.ShouldNotBeNull();
            parametersOfGetBoolean.Length.ShouldBe(2);
            methodGetBooleanPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetBoolean) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBoolean_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bDefault = CreateType<bool>();
            var methodGetBooleanPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfGetBoolean = { sItemName, bDefault };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, bool>(_cStructInstance, MethodGetBoolean, parametersOfGetBoolean, methodGetBooleanPrametersTypes);

            // Assert
            parametersOfGetBoolean.ShouldNotBeNull();
            parametersOfGetBoolean.Length.ShouldBe(2);
            methodGetBooleanPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetBoolean) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBoolean_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetBooleanPrametersTypes = new Type[] { typeof(string), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetBoolean, Fixture, methodGetBooleanPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetBooleanPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetBoolean) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBoolean_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetBooleanPrametersTypes = new Type[] { typeof(string), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetBoolean, Fixture, methodGetBooleanPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetBooleanPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetBoolean) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBoolean_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetBooleanPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetBoolean, Fixture, methodGetBooleanPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetBooleanPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetBoolean) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBoolean_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetBoolean, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetBoolean) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBoolean_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetBoolean, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetBoolean) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBoolean_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetBoolean, 1);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetBooleanAttr) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_GetBooleanAttr_Method_Call_Internally(Type[] types)
        {
            var methodGetBooleanAttrPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetBooleanAttr, Fixture, methodGetBooleanAttrPrametersTypes);
        }

        #endregion

        #region Method Call : (GetBooleanAttr) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBooleanAttr_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetBooleanAttr(sItemName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetBooleanAttr) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBooleanAttr_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetBooleanAttr(sItemName);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetBooleanAttr) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBooleanAttr_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetBooleanAttrPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetBooleanAttr = { sItemName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetBooleanAttr, methodGetBooleanAttrPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, bool>(_cStructInstanceFixture, out exception1, parametersOfGetBooleanAttr);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, bool>(_cStructInstance, MethodGetBooleanAttr, parametersOfGetBooleanAttr, methodGetBooleanAttrPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetBooleanAttr.ShouldNotBeNull();
            parametersOfGetBooleanAttr.Length.ShouldBe(1);
            methodGetBooleanAttrPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetBooleanAttr) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBooleanAttr_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetBooleanAttrPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetBooleanAttr = { sItemName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetBooleanAttr, methodGetBooleanAttrPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, bool>(_cStructInstanceFixture, out exception1, parametersOfGetBooleanAttr);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, bool>(_cStructInstance, MethodGetBooleanAttr, parametersOfGetBooleanAttr, methodGetBooleanAttrPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetBooleanAttr.ShouldNotBeNull();
            parametersOfGetBooleanAttr.Length.ShouldBe(1);
            methodGetBooleanAttrPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetBooleanAttr) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBooleanAttr_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetBooleanAttrPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetBooleanAttr = { sItemName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetBooleanAttr, methodGetBooleanAttrPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfGetBooleanAttr);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetBooleanAttr.ShouldNotBeNull();
            parametersOfGetBooleanAttr.Length.ShouldBe(1);
            methodGetBooleanAttrPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetBooleanAttr) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBooleanAttr_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetBooleanAttrPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetBooleanAttr = { sItemName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, bool>(_cStructInstance, MethodGetBooleanAttr, parametersOfGetBooleanAttr, methodGetBooleanAttrPrametersTypes);

            // Assert
            parametersOfGetBooleanAttr.ShouldNotBeNull();
            parametersOfGetBooleanAttr.Length.ShouldBe(1);
            methodGetBooleanAttrPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetBooleanAttr) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBooleanAttr_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetBooleanAttrPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetBooleanAttr, Fixture, methodGetBooleanAttrPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetBooleanAttrPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetBooleanAttr) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBooleanAttr_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetBooleanAttrPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetBooleanAttr, Fixture, methodGetBooleanAttrPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetBooleanAttrPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetBooleanAttr) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBooleanAttr_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetBooleanAttrPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetBooleanAttr, Fixture, methodGetBooleanAttrPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetBooleanAttrPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetBooleanAttr) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBooleanAttr_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetBooleanAttr, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetBooleanAttr) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBooleanAttr_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetBooleanAttr, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetBooleanAttr) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBooleanAttr_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetBooleanAttr, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetBooleanAttr) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_GetBooleanAttr_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodGetBooleanAttrPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetBooleanAttr, Fixture, methodGetBooleanAttrPrametersTypes);
        }

        #endregion

        #region Method Call : (GetBooleanAttr) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBooleanAttr_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bDefault = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetBooleanAttr(sItemName, bDefault);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetBooleanAttr) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBooleanAttr_Method_DirectCall_Overloading_Of_1_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bDefault = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetBooleanAttr(sItemName, bDefault);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetBooleanAttr) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBooleanAttr_Method_Call_Overloading_Of_1_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bDefault = CreateType<bool>();
            var methodGetBooleanAttrPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfGetBooleanAttr = { sItemName, bDefault };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetBooleanAttr, methodGetBooleanAttrPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, bool>(_cStructInstanceFixture, out exception1, parametersOfGetBooleanAttr);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, bool>(_cStructInstance, MethodGetBooleanAttr, parametersOfGetBooleanAttr, methodGetBooleanAttrPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetBooleanAttr.ShouldNotBeNull();
            parametersOfGetBooleanAttr.Length.ShouldBe(2);
            methodGetBooleanAttrPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetBooleanAttr) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBooleanAttr_Method_Call_Overloading_Of_1_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bDefault = CreateType<bool>();
            var methodGetBooleanAttrPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfGetBooleanAttr = { sItemName, bDefault };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetBooleanAttr, methodGetBooleanAttrPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, bool>(_cStructInstanceFixture, out exception1, parametersOfGetBooleanAttr);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, bool>(_cStructInstance, MethodGetBooleanAttr, parametersOfGetBooleanAttr, methodGetBooleanAttrPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetBooleanAttr.ShouldNotBeNull();
            parametersOfGetBooleanAttr.Length.ShouldBe(2);
            methodGetBooleanAttrPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetBooleanAttr) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBooleanAttr_Method_Call_Overloading_Of_1_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bDefault = CreateType<bool>();
            var methodGetBooleanAttrPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfGetBooleanAttr = { sItemName, bDefault };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetBooleanAttr, methodGetBooleanAttrPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfGetBooleanAttr);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetBooleanAttr.ShouldNotBeNull();
            parametersOfGetBooleanAttr.Length.ShouldBe(2);
            methodGetBooleanAttrPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetBooleanAttr) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBooleanAttr_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bDefault = CreateType<bool>();
            var methodGetBooleanAttrPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfGetBooleanAttr = { sItemName, bDefault };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, bool>(_cStructInstance, MethodGetBooleanAttr, parametersOfGetBooleanAttr, methodGetBooleanAttrPrametersTypes);

            // Assert
            parametersOfGetBooleanAttr.ShouldNotBeNull();
            parametersOfGetBooleanAttr.Length.ShouldBe(2);
            methodGetBooleanAttrPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetBooleanAttr) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBooleanAttr_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetBooleanAttrPrametersTypes = new Type[] { typeof(string), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetBooleanAttr, Fixture, methodGetBooleanAttrPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetBooleanAttrPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetBooleanAttr) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBooleanAttr_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetBooleanAttrPrametersTypes = new Type[] { typeof(string), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetBooleanAttr, Fixture, methodGetBooleanAttrPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetBooleanAttrPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetBooleanAttr) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBooleanAttr_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetBooleanAttrPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetBooleanAttr, Fixture, methodGetBooleanAttrPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetBooleanAttrPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetBooleanAttr) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBooleanAttr_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetBooleanAttr, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetBooleanAttr) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBooleanAttr_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetBooleanAttr, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetBooleanAttr) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetBooleanAttr_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetBooleanAttr, 1);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetInt) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_GetInt_Method_Call_Internally(Type[] types)
        {
            var methodGetIntPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetInt, Fixture, methodGetIntPrametersTypes);
        }

        #endregion

        #region Method Call : (GetInt) (Return Type : int) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetInt_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var iDefault = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetInt(sItemName, iDefault);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetInt) (Return Type : int) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetInt_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var iDefault = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetInt(sItemName, iDefault);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetInt) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetInt_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var iDefault = CreateType<int>();
            var methodGetIntPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfGetInt = { sItemName, iDefault };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetInt, methodGetIntPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, int>(_cStructInstanceFixture, out exception1, parametersOfGetInt);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, int>(_cStructInstance, MethodGetInt, parametersOfGetInt, methodGetIntPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetInt.ShouldNotBeNull();
            parametersOfGetInt.Length.ShouldBe(2);
            methodGetIntPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetInt) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetInt_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var iDefault = CreateType<int>();
            var methodGetIntPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfGetInt = { sItemName, iDefault };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetInt, methodGetIntPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, int>(_cStructInstanceFixture, out exception1, parametersOfGetInt);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, int>(_cStructInstance, MethodGetInt, parametersOfGetInt, methodGetIntPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetInt.ShouldNotBeNull();
            parametersOfGetInt.Length.ShouldBe(2);
            methodGetIntPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetInt) (Return Type : int) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetInt_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var iDefault = CreateType<int>();
            var methodGetIntPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfGetInt = { sItemName, iDefault };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetInt, methodGetIntPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfGetInt);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetInt.ShouldNotBeNull();
            parametersOfGetInt.Length.ShouldBe(2);
            methodGetIntPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetInt) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetInt_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var iDefault = CreateType<int>();
            var methodGetIntPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfGetInt = { sItemName, iDefault };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, int>(_cStructInstance, MethodGetInt, parametersOfGetInt, methodGetIntPrametersTypes);

            // Assert
            parametersOfGetInt.ShouldNotBeNull();
            parametersOfGetInt.Length.ShouldBe(2);
            methodGetIntPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetInt) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetInt_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetIntPrametersTypes = new Type[] { typeof(string), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetInt, Fixture, methodGetIntPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetIntPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetInt) (Return Type : int) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetInt_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetIntPrametersTypes = new Type[] { typeof(string), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetInt, Fixture, methodGetIntPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetIntPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetInt) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetInt_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetIntPrametersTypes = new Type[] { typeof(string), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetInt, Fixture, methodGetIntPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetIntPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetInt) (Return Type : int) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetInt_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetInt, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetInt) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetInt_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetInt, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetInt) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetInt_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetInt, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetInt) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_GetInt_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodGetIntPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetInt, Fixture, methodGetIntPrametersTypes);
        }

        #endregion

        #region Method Call : (GetInt) (Return Type : int) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetInt_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetInt(sItemName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetInt) (Return Type : int) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetInt_Method_DirectCall_Overloading_Of_1_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetInt(sItemName);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetInt) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetInt_Method_Call_Overloading_Of_1_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetIntPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetInt = { sItemName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetInt, methodGetIntPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, int>(_cStructInstanceFixture, out exception1, parametersOfGetInt);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, int>(_cStructInstance, MethodGetInt, parametersOfGetInt, methodGetIntPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetInt.ShouldNotBeNull();
            parametersOfGetInt.Length.ShouldBe(1);
            methodGetIntPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetInt) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetInt_Method_Call_Overloading_Of_1_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetIntPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetInt = { sItemName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetInt, methodGetIntPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, int>(_cStructInstanceFixture, out exception1, parametersOfGetInt);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, int>(_cStructInstance, MethodGetInt, parametersOfGetInt, methodGetIntPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetInt.ShouldNotBeNull();
            parametersOfGetInt.Length.ShouldBe(1);
            methodGetIntPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetInt) (Return Type : int) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetInt_Method_Call_Overloading_Of_1_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetIntPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetInt = { sItemName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetInt, methodGetIntPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfGetInt);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetInt.ShouldNotBeNull();
            parametersOfGetInt.Length.ShouldBe(1);
            methodGetIntPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetInt) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetInt_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetIntPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetInt = { sItemName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, int>(_cStructInstance, MethodGetInt, parametersOfGetInt, methodGetIntPrametersTypes);

            // Assert
            parametersOfGetInt.ShouldNotBeNull();
            parametersOfGetInt.Length.ShouldBe(1);
            methodGetIntPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetInt) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetInt_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetIntPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetInt, Fixture, methodGetIntPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetIntPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetInt) (Return Type : int) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetInt_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetIntPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetInt, Fixture, methodGetIntPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetIntPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetInt) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetInt_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetIntPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetInt, Fixture, methodGetIntPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetIntPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetInt) (Return Type : int) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetInt_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetInt, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetInt) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetInt_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetInt, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetInt) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetInt_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetInt, 1);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetIntAttr) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_GetIntAttr_Method_Call_Internally(Type[] types)
        {
            var methodGetIntAttrPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetIntAttr, Fixture, methodGetIntAttrPrametersTypes);
        }

        #endregion

        #region Method Call : (GetIntAttr) (Return Type : int) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetIntAttr_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetIntAttr(sItemName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetIntAttr) (Return Type : int) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetIntAttr_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetIntAttr(sItemName);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetIntAttr) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetIntAttr_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetIntAttrPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetIntAttr = { sItemName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetIntAttr, methodGetIntAttrPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, int>(_cStructInstanceFixture, out exception1, parametersOfGetIntAttr);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, int>(_cStructInstance, MethodGetIntAttr, parametersOfGetIntAttr, methodGetIntAttrPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetIntAttr.ShouldNotBeNull();
            parametersOfGetIntAttr.Length.ShouldBe(1);
            methodGetIntAttrPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetIntAttr) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetIntAttr_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetIntAttrPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetIntAttr = { sItemName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetIntAttr, methodGetIntAttrPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, int>(_cStructInstanceFixture, out exception1, parametersOfGetIntAttr);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, int>(_cStructInstance, MethodGetIntAttr, parametersOfGetIntAttr, methodGetIntAttrPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetIntAttr.ShouldNotBeNull();
            parametersOfGetIntAttr.Length.ShouldBe(1);
            methodGetIntAttrPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetIntAttr) (Return Type : int) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetIntAttr_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetIntAttrPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetIntAttr = { sItemName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetIntAttr, methodGetIntAttrPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfGetIntAttr);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetIntAttr.ShouldNotBeNull();
            parametersOfGetIntAttr.Length.ShouldBe(1);
            methodGetIntAttrPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetIntAttr) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetIntAttr_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetIntAttrPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetIntAttr = { sItemName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, int>(_cStructInstance, MethodGetIntAttr, parametersOfGetIntAttr, methodGetIntAttrPrametersTypes);

            // Assert
            parametersOfGetIntAttr.ShouldNotBeNull();
            parametersOfGetIntAttr.Length.ShouldBe(1);
            methodGetIntAttrPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetIntAttr) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetIntAttr_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetIntAttrPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetIntAttr, Fixture, methodGetIntAttrPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetIntAttrPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetIntAttr) (Return Type : int) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetIntAttr_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetIntAttrPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetIntAttr, Fixture, methodGetIntAttrPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetIntAttrPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetIntAttr) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetIntAttr_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetIntAttrPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetIntAttr, Fixture, methodGetIntAttrPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetIntAttrPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetIntAttr) (Return Type : int) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetIntAttr_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetIntAttr, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetIntAttr) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetIntAttr_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetIntAttr, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetIntAttr) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetIntAttr_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetIntAttr, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetIntAttr) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_GetIntAttr_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodGetIntAttrPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetIntAttr, Fixture, methodGetIntAttrPrametersTypes);
        }

        #endregion

        #region Method Call : (GetIntAttr) (Return Type : int) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetIntAttr_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var iDefault = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetIntAttr(sItemName, iDefault);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetIntAttr) (Return Type : int) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetIntAttr_Method_DirectCall_Overloading_Of_1_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var iDefault = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetIntAttr(sItemName, iDefault);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetIntAttr) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetIntAttr_Method_Call_Overloading_Of_1_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var iDefault = CreateType<int>();
            var methodGetIntAttrPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfGetIntAttr = { sItemName, iDefault };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetIntAttr, methodGetIntAttrPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, int>(_cStructInstanceFixture, out exception1, parametersOfGetIntAttr);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, int>(_cStructInstance, MethodGetIntAttr, parametersOfGetIntAttr, methodGetIntAttrPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetIntAttr.ShouldNotBeNull();
            parametersOfGetIntAttr.Length.ShouldBe(2);
            methodGetIntAttrPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetIntAttr) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetIntAttr_Method_Call_Overloading_Of_1_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var iDefault = CreateType<int>();
            var methodGetIntAttrPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfGetIntAttr = { sItemName, iDefault };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetIntAttr, methodGetIntAttrPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, int>(_cStructInstanceFixture, out exception1, parametersOfGetIntAttr);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, int>(_cStructInstance, MethodGetIntAttr, parametersOfGetIntAttr, methodGetIntAttrPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetIntAttr.ShouldNotBeNull();
            parametersOfGetIntAttr.Length.ShouldBe(2);
            methodGetIntAttrPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetIntAttr) (Return Type : int) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetIntAttr_Method_Call_Overloading_Of_1_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var iDefault = CreateType<int>();
            var methodGetIntAttrPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfGetIntAttr = { sItemName, iDefault };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetIntAttr, methodGetIntAttrPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfGetIntAttr);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetIntAttr.ShouldNotBeNull();
            parametersOfGetIntAttr.Length.ShouldBe(2);
            methodGetIntAttrPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetIntAttr) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetIntAttr_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var iDefault = CreateType<int>();
            var methodGetIntAttrPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfGetIntAttr = { sItemName, iDefault };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, int>(_cStructInstance, MethodGetIntAttr, parametersOfGetIntAttr, methodGetIntAttrPrametersTypes);

            // Assert
            parametersOfGetIntAttr.ShouldNotBeNull();
            parametersOfGetIntAttr.Length.ShouldBe(2);
            methodGetIntAttrPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetIntAttr) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetIntAttr_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetIntAttrPrametersTypes = new Type[] { typeof(string), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetIntAttr, Fixture, methodGetIntAttrPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetIntAttrPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetIntAttr) (Return Type : int) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetIntAttr_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetIntAttrPrametersTypes = new Type[] { typeof(string), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetIntAttr, Fixture, methodGetIntAttrPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetIntAttrPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetIntAttr) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetIntAttr_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetIntAttrPrametersTypes = new Type[] { typeof(string), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetIntAttr, Fixture, methodGetIntAttrPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetIntAttrPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetIntAttr) (Return Type : int) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetIntAttr_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetIntAttr, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetIntAttr) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetIntAttr_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetIntAttr, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetIntAttr) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetIntAttr_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetIntAttr, 1);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetIntAttr) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_GetIntAttr_Method_Overloading_Of_2_Call_Internally(Type[] types)
        {
            var methodGetIntAttrPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetIntAttr, Fixture, methodGetIntAttrPrametersTypes);
        }

        #endregion

        #region Method Call : (GetIntAttr) (Return Type : int) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetIntAttr_Method_DirectCall_Overloading_Of_2_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bTagFound = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetIntAttr(sItemName, out bTagFound);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetIntAttr) (Return Type : int) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetIntAttr_Method_DirectCall_Overloading_Of_2_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bTagFound = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetIntAttr(sItemName, out bTagFound);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetIntAttr) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetIntAttr_Method_Call_Overloading_Of_2_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bTagFound = CreateType<bool>();
            var methodGetIntAttrPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfGetIntAttr = { sItemName, bTagFound };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetIntAttr, methodGetIntAttrPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, int>(_cStructInstanceFixture, out exception1, parametersOfGetIntAttr);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, int>(_cStructInstance, MethodGetIntAttr, parametersOfGetIntAttr, methodGetIntAttrPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetIntAttr.ShouldNotBeNull();
            parametersOfGetIntAttr.Length.ShouldBe(2);
            methodGetIntAttrPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetIntAttr) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetIntAttr_Method_Call_Overloading_Of_2_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bTagFound = CreateType<bool>();
            var methodGetIntAttrPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfGetIntAttr = { sItemName, bTagFound };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetIntAttr, methodGetIntAttrPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, int>(_cStructInstanceFixture, out exception1, parametersOfGetIntAttr);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, int>(_cStructInstance, MethodGetIntAttr, parametersOfGetIntAttr, methodGetIntAttrPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetIntAttr.ShouldNotBeNull();
            parametersOfGetIntAttr.Length.ShouldBe(2);
            methodGetIntAttrPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetIntAttr) (Return Type : int) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetIntAttr_Method_Call_Overloading_Of_2_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bTagFound = CreateType<bool>();
            var methodGetIntAttrPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfGetIntAttr = { sItemName, bTagFound };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetIntAttr, methodGetIntAttrPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfGetIntAttr);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetIntAttr.ShouldNotBeNull();
            parametersOfGetIntAttr.Length.ShouldBe(2);
            methodGetIntAttrPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetIntAttr) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetIntAttr_Method_Call_Overloading_Of_2_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bTagFound = CreateType<bool>();
            var methodGetIntAttrPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfGetIntAttr = { sItemName, bTagFound };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, int>(_cStructInstance, MethodGetIntAttr, parametersOfGetIntAttr, methodGetIntAttrPrametersTypes);

            // Assert
            parametersOfGetIntAttr.ShouldNotBeNull();
            parametersOfGetIntAttr.Length.ShouldBe(2);
            methodGetIntAttrPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetIntAttr) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetIntAttr_Method_Call_Overloading_Of_2_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetIntAttrPrametersTypes = new Type[] { typeof(string), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetIntAttr, Fixture, methodGetIntAttrPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetIntAttrPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetIntAttr) (Return Type : int) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetIntAttr_Method_Call_Overloading_Of_2_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetIntAttrPrametersTypes = new Type[] { typeof(string), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetIntAttr, Fixture, methodGetIntAttrPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetIntAttrPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetIntAttr) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetIntAttr_Method_Call_Overloading_Of_2_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetIntAttrPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetIntAttr, Fixture, methodGetIntAttrPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetIntAttrPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetIntAttr) (Return Type : int) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetIntAttr_Method_Call_Overloading_Of_2_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetIntAttr, 2);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetIntAttr) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetIntAttr_Method_Call_Overloading_Of_2_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetIntAttr, 2);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetIntAttr) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetIntAttr_Method_Call_Overloading_Of_2_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetIntAttr, 2);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDoubleAttr) (Return Type : double) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_GetDoubleAttr_Method_Call_Internally(Type[] types)
        {
            var methodGetDoubleAttrPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetDoubleAttr, Fixture, methodGetDoubleAttrPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDoubleAttr) (Return Type : double) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDoubleAttr_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var dblDefault = CreateType<double>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetDoubleAttr(sItemName, dblDefault);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetDoubleAttr) (Return Type : double) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDoubleAttr_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var dblDefault = CreateType<double>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetDoubleAttr(sItemName, dblDefault);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetDoubleAttr) (Return Type : double) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDoubleAttr_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var dblDefault = CreateType<double>();
            var methodGetDoubleAttrPrametersTypes = new Type[] { typeof(string), typeof(double) };
            object[] parametersOfGetDoubleAttr = { sItemName, dblDefault };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDoubleAttr, methodGetDoubleAttrPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, double>(_cStructInstanceFixture, out exception1, parametersOfGetDoubleAttr);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, double>(_cStructInstance, MethodGetDoubleAttr, parametersOfGetDoubleAttr, methodGetDoubleAttrPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetDoubleAttr.ShouldNotBeNull();
            parametersOfGetDoubleAttr.Length.ShouldBe(2);
            methodGetDoubleAttrPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetDoubleAttr) (Return Type : double) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDoubleAttr_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var dblDefault = CreateType<double>();
            var methodGetDoubleAttrPrametersTypes = new Type[] { typeof(string), typeof(double) };
            object[] parametersOfGetDoubleAttr = { sItemName, dblDefault };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDoubleAttr, methodGetDoubleAttrPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, double>(_cStructInstanceFixture, out exception1, parametersOfGetDoubleAttr);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, double>(_cStructInstance, MethodGetDoubleAttr, parametersOfGetDoubleAttr, methodGetDoubleAttrPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetDoubleAttr.ShouldNotBeNull();
            parametersOfGetDoubleAttr.Length.ShouldBe(2);
            methodGetDoubleAttrPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetDoubleAttr) (Return Type : double) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDoubleAttr_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var dblDefault = CreateType<double>();
            var methodGetDoubleAttrPrametersTypes = new Type[] { typeof(string), typeof(double) };
            object[] parametersOfGetDoubleAttr = { sItemName, dblDefault };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetDoubleAttr, methodGetDoubleAttrPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfGetDoubleAttr);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetDoubleAttr.ShouldNotBeNull();
            parametersOfGetDoubleAttr.Length.ShouldBe(2);
            methodGetDoubleAttrPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDoubleAttr) (Return Type : double) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDoubleAttr_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var dblDefault = CreateType<double>();
            var methodGetDoubleAttrPrametersTypes = new Type[] { typeof(string), typeof(double) };
            object[] parametersOfGetDoubleAttr = { sItemName, dblDefault };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, double>(_cStructInstance, MethodGetDoubleAttr, parametersOfGetDoubleAttr, methodGetDoubleAttrPrametersTypes);

            // Assert
            parametersOfGetDoubleAttr.ShouldNotBeNull();
            parametersOfGetDoubleAttr.Length.ShouldBe(2);
            methodGetDoubleAttrPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDoubleAttr) (Return Type : double) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDoubleAttr_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetDoubleAttrPrametersTypes = new Type[] { typeof(string), typeof(double) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetDoubleAttr, Fixture, methodGetDoubleAttrPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetDoubleAttrPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetDoubleAttr) (Return Type : double) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDoubleAttr_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetDoubleAttrPrametersTypes = new Type[] { typeof(string), typeof(double) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetDoubleAttr, Fixture, methodGetDoubleAttrPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetDoubleAttrPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetDoubleAttr) (Return Type : double) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDoubleAttr_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDoubleAttrPrametersTypes = new Type[] { typeof(string), typeof(double) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetDoubleAttr, Fixture, methodGetDoubleAttrPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDoubleAttrPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDoubleAttr) (Return Type : double) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDoubleAttr_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDoubleAttr, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetDoubleAttr) (Return Type : double) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDoubleAttr_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDoubleAttr, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDoubleAttr) (Return Type : double) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDoubleAttr_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetDoubleAttr, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDoubleAttr) (Return Type : double) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_GetDoubleAttr_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodGetDoubleAttrPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetDoubleAttr, Fixture, methodGetDoubleAttrPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDoubleAttr) (Return Type : double) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDoubleAttr_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bTagFound = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetDoubleAttr(sItemName, out bTagFound);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetDoubleAttr) (Return Type : double) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDoubleAttr_Method_DirectCall_Overloading_Of_1_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bTagFound = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetDoubleAttr(sItemName, out bTagFound);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetDoubleAttr) (Return Type : double) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDoubleAttr_Method_Call_Overloading_Of_1_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bTagFound = CreateType<bool>();
            var methodGetDoubleAttrPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfGetDoubleAttr = { sItemName, bTagFound };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDoubleAttr, methodGetDoubleAttrPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, double>(_cStructInstanceFixture, out exception1, parametersOfGetDoubleAttr);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, double>(_cStructInstance, MethodGetDoubleAttr, parametersOfGetDoubleAttr, methodGetDoubleAttrPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetDoubleAttr.ShouldNotBeNull();
            parametersOfGetDoubleAttr.Length.ShouldBe(2);
            methodGetDoubleAttrPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetDoubleAttr) (Return Type : double) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDoubleAttr_Method_Call_Overloading_Of_1_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bTagFound = CreateType<bool>();
            var methodGetDoubleAttrPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfGetDoubleAttr = { sItemName, bTagFound };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDoubleAttr, methodGetDoubleAttrPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, double>(_cStructInstanceFixture, out exception1, parametersOfGetDoubleAttr);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, double>(_cStructInstance, MethodGetDoubleAttr, parametersOfGetDoubleAttr, methodGetDoubleAttrPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetDoubleAttr.ShouldNotBeNull();
            parametersOfGetDoubleAttr.Length.ShouldBe(2);
            methodGetDoubleAttrPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetDoubleAttr) (Return Type : double) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDoubleAttr_Method_Call_Overloading_Of_1_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bTagFound = CreateType<bool>();
            var methodGetDoubleAttrPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfGetDoubleAttr = { sItemName, bTagFound };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetDoubleAttr, methodGetDoubleAttrPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfGetDoubleAttr);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetDoubleAttr.ShouldNotBeNull();
            parametersOfGetDoubleAttr.Length.ShouldBe(2);
            methodGetDoubleAttrPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDoubleAttr) (Return Type : double) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDoubleAttr_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bTagFound = CreateType<bool>();
            var methodGetDoubleAttrPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfGetDoubleAttr = { sItemName, bTagFound };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, double>(_cStructInstance, MethodGetDoubleAttr, parametersOfGetDoubleAttr, methodGetDoubleAttrPrametersTypes);

            // Assert
            parametersOfGetDoubleAttr.ShouldNotBeNull();
            parametersOfGetDoubleAttr.Length.ShouldBe(2);
            methodGetDoubleAttrPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDoubleAttr) (Return Type : double) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDoubleAttr_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetDoubleAttrPrametersTypes = new Type[] { typeof(string), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetDoubleAttr, Fixture, methodGetDoubleAttrPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetDoubleAttrPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetDoubleAttr) (Return Type : double) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDoubleAttr_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetDoubleAttrPrametersTypes = new Type[] { typeof(string), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetDoubleAttr, Fixture, methodGetDoubleAttrPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetDoubleAttrPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetDoubleAttr) (Return Type : double) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDoubleAttr_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDoubleAttrPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetDoubleAttr, Fixture, methodGetDoubleAttrPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDoubleAttrPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDoubleAttr) (Return Type : double) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDoubleAttr_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDoubleAttr, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetDoubleAttr) (Return Type : double) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDoubleAttr_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDoubleAttr, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDoubleAttr) (Return Type : double) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDoubleAttr_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetDoubleAttr, 1);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDecimalAttr) (Return Type : decimal) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_GetDecimalAttr_Method_Call_Internally(Type[] types)
        {
            var methodGetDecimalAttrPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetDecimalAttr, Fixture, methodGetDecimalAttrPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDecimalAttr) (Return Type : decimal) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDecimalAttr_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var decDefault = CreateType<decimal>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetDecimalAttr(sItemName, decDefault);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetDecimalAttr) (Return Type : decimal) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDecimalAttr_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var decDefault = CreateType<decimal>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetDecimalAttr(sItemName, decDefault);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetDecimalAttr) (Return Type : decimal) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDecimalAttr_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var decDefault = CreateType<decimal>();
            var methodGetDecimalAttrPrametersTypes = new Type[] { typeof(string), typeof(decimal) };
            object[] parametersOfGetDecimalAttr = { sItemName, decDefault };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDecimalAttr, methodGetDecimalAttrPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, decimal>(_cStructInstanceFixture, out exception1, parametersOfGetDecimalAttr);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, decimal>(_cStructInstance, MethodGetDecimalAttr, parametersOfGetDecimalAttr, methodGetDecimalAttrPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetDecimalAttr.ShouldNotBeNull();
            parametersOfGetDecimalAttr.Length.ShouldBe(2);
            methodGetDecimalAttrPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetDecimalAttr) (Return Type : decimal) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDecimalAttr_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var decDefault = CreateType<decimal>();
            var methodGetDecimalAttrPrametersTypes = new Type[] { typeof(string), typeof(decimal) };
            object[] parametersOfGetDecimalAttr = { sItemName, decDefault };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDecimalAttr, methodGetDecimalAttrPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, decimal>(_cStructInstanceFixture, out exception1, parametersOfGetDecimalAttr);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, decimal>(_cStructInstance, MethodGetDecimalAttr, parametersOfGetDecimalAttr, methodGetDecimalAttrPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetDecimalAttr.ShouldNotBeNull();
            parametersOfGetDecimalAttr.Length.ShouldBe(2);
            methodGetDecimalAttrPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetDecimalAttr) (Return Type : decimal) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDecimalAttr_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var decDefault = CreateType<decimal>();
            var methodGetDecimalAttrPrametersTypes = new Type[] { typeof(string), typeof(decimal) };
            object[] parametersOfGetDecimalAttr = { sItemName, decDefault };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetDecimalAttr, methodGetDecimalAttrPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfGetDecimalAttr);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetDecimalAttr.ShouldNotBeNull();
            parametersOfGetDecimalAttr.Length.ShouldBe(2);
            methodGetDecimalAttrPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDecimalAttr) (Return Type : decimal) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDecimalAttr_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var decDefault = CreateType<decimal>();
            var methodGetDecimalAttrPrametersTypes = new Type[] { typeof(string), typeof(decimal) };
            object[] parametersOfGetDecimalAttr = { sItemName, decDefault };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, decimal>(_cStructInstance, MethodGetDecimalAttr, parametersOfGetDecimalAttr, methodGetDecimalAttrPrametersTypes);

            // Assert
            parametersOfGetDecimalAttr.ShouldNotBeNull();
            parametersOfGetDecimalAttr.Length.ShouldBe(2);
            methodGetDecimalAttrPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDecimalAttr) (Return Type : decimal) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDecimalAttr_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetDecimalAttrPrametersTypes = new Type[] { typeof(string), typeof(decimal) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetDecimalAttr, Fixture, methodGetDecimalAttrPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetDecimalAttrPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetDecimalAttr) (Return Type : decimal) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDecimalAttr_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetDecimalAttrPrametersTypes = new Type[] { typeof(string), typeof(decimal) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetDecimalAttr, Fixture, methodGetDecimalAttrPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetDecimalAttrPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetDecimalAttr) (Return Type : decimal) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDecimalAttr_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDecimalAttrPrametersTypes = new Type[] { typeof(string), typeof(decimal) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetDecimalAttr, Fixture, methodGetDecimalAttrPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDecimalAttrPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDecimalAttr) (Return Type : decimal) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDecimalAttr_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDecimalAttr, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetDecimalAttr) (Return Type : decimal) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDecimalAttr_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDecimalAttr, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDecimalAttr) (Return Type : decimal) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDecimalAttr_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetDecimalAttr, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDecimalAttr) (Return Type : decimal) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_GetDecimalAttr_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodGetDecimalAttrPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetDecimalAttr, Fixture, methodGetDecimalAttrPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDecimalAttr) (Return Type : decimal) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDecimalAttr_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bTagFound = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetDecimalAttr(sItemName, out bTagFound);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetDecimalAttr) (Return Type : decimal) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDecimalAttr_Method_DirectCall_Overloading_Of_1_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bTagFound = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetDecimalAttr(sItemName, out bTagFound);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetDecimalAttr) (Return Type : decimal) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDecimalAttr_Method_Call_Overloading_Of_1_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bTagFound = CreateType<bool>();
            var methodGetDecimalAttrPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfGetDecimalAttr = { sItemName, bTagFound };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDecimalAttr, methodGetDecimalAttrPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, decimal>(_cStructInstanceFixture, out exception1, parametersOfGetDecimalAttr);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, decimal>(_cStructInstance, MethodGetDecimalAttr, parametersOfGetDecimalAttr, methodGetDecimalAttrPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetDecimalAttr.ShouldNotBeNull();
            parametersOfGetDecimalAttr.Length.ShouldBe(2);
            methodGetDecimalAttrPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetDecimalAttr) (Return Type : decimal) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDecimalAttr_Method_Call_Overloading_Of_1_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bTagFound = CreateType<bool>();
            var methodGetDecimalAttrPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfGetDecimalAttr = { sItemName, bTagFound };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDecimalAttr, methodGetDecimalAttrPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, decimal>(_cStructInstanceFixture, out exception1, parametersOfGetDecimalAttr);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, decimal>(_cStructInstance, MethodGetDecimalAttr, parametersOfGetDecimalAttr, methodGetDecimalAttrPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetDecimalAttr.ShouldNotBeNull();
            parametersOfGetDecimalAttr.Length.ShouldBe(2);
            methodGetDecimalAttrPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetDecimalAttr) (Return Type : decimal) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDecimalAttr_Method_Call_Overloading_Of_1_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bTagFound = CreateType<bool>();
            var methodGetDecimalAttrPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfGetDecimalAttr = { sItemName, bTagFound };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetDecimalAttr, methodGetDecimalAttrPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfGetDecimalAttr);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetDecimalAttr.ShouldNotBeNull();
            parametersOfGetDecimalAttr.Length.ShouldBe(2);
            methodGetDecimalAttrPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDecimalAttr) (Return Type : decimal) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDecimalAttr_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bTagFound = CreateType<bool>();
            var methodGetDecimalAttrPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfGetDecimalAttr = { sItemName, bTagFound };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, decimal>(_cStructInstance, MethodGetDecimalAttr, parametersOfGetDecimalAttr, methodGetDecimalAttrPrametersTypes);

            // Assert
            parametersOfGetDecimalAttr.ShouldNotBeNull();
            parametersOfGetDecimalAttr.Length.ShouldBe(2);
            methodGetDecimalAttrPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDecimalAttr) (Return Type : decimal) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDecimalAttr_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetDecimalAttrPrametersTypes = new Type[] { typeof(string), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetDecimalAttr, Fixture, methodGetDecimalAttrPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetDecimalAttrPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetDecimalAttr) (Return Type : decimal) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDecimalAttr_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetDecimalAttrPrametersTypes = new Type[] { typeof(string), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetDecimalAttr, Fixture, methodGetDecimalAttrPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetDecimalAttrPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetDecimalAttr) (Return Type : decimal) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDecimalAttr_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDecimalAttrPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetDecimalAttr, Fixture, methodGetDecimalAttrPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDecimalAttrPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDecimalAttr) (Return Type : decimal) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDecimalAttr_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDecimalAttr, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetDecimalAttr) (Return Type : decimal) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDecimalAttr_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDecimalAttr, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDecimalAttr) (Return Type : decimal) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDecimalAttr_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetDecimalAttr, 1);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetString) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_GetString_Method_Call_Internally(Type[] types)
        {
            var methodGetStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetString, Fixture, methodGetStringPrametersTypes);
        }

        #endregion

        #region Method Call : (GetString) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetString_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sDefault = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetString(sItemName, sDefault);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetString) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetString_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sDefault = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetString(sItemName, sDefault);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetString) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetString_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sDefault = CreateType<string>();
            var methodGetStringPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfGetString = { sItemName, sDefault };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetString, methodGetStringPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, string>(_cStructInstanceFixture, out exception1, parametersOfGetString);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, string>(_cStructInstance, MethodGetString, parametersOfGetString, methodGetStringPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetString.ShouldNotBeNull();
            parametersOfGetString.Length.ShouldBe(2);
            methodGetStringPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetString) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetString_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sDefault = CreateType<string>();
            var methodGetStringPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfGetString = { sItemName, sDefault };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetString, methodGetStringPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, string>(_cStructInstanceFixture, out exception1, parametersOfGetString);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, string>(_cStructInstance, MethodGetString, parametersOfGetString, methodGetStringPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetString.ShouldNotBeNull();
            parametersOfGetString.Length.ShouldBe(2);
            methodGetStringPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetString) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetString_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sDefault = CreateType<string>();
            var methodGetStringPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfGetString = { sItemName, sDefault };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetString, methodGetStringPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfGetString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetString.ShouldNotBeNull();
            parametersOfGetString.Length.ShouldBe(2);
            methodGetStringPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetString) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetString_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sDefault = CreateType<string>();
            var methodGetStringPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfGetString = { sItemName, sDefault };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, string>(_cStructInstance, MethodGetString, parametersOfGetString, methodGetStringPrametersTypes);

            // Assert
            parametersOfGetString.ShouldNotBeNull();
            parametersOfGetString.Length.ShouldBe(2);
            methodGetStringPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetString) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetString_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetStringPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetString, Fixture, methodGetStringPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetStringPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetString) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetString_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetStringPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetString, Fixture, methodGetStringPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetStringPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetString) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetString_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetStringPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetString, Fixture, methodGetStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetStringPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetString) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetString_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetString) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetString_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetString) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetString_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetString, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetString) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_GetString_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodGetStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetString, Fixture, methodGetStringPrametersTypes);
        }

        #endregion

        #region Method Call : (GetString) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetString_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetString(sItemName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetString) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetString_Method_DirectCall_Overloading_Of_1_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetString(sItemName);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetString) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetString_Method_Call_Overloading_Of_1_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetStringPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetString = { sItemName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetString, methodGetStringPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, string>(_cStructInstanceFixture, out exception1, parametersOfGetString);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, string>(_cStructInstance, MethodGetString, parametersOfGetString, methodGetStringPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetString.ShouldNotBeNull();
            parametersOfGetString.Length.ShouldBe(1);
            methodGetStringPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetString) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetString_Method_Call_Overloading_Of_1_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetStringPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetString = { sItemName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetString, methodGetStringPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, string>(_cStructInstanceFixture, out exception1, parametersOfGetString);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, string>(_cStructInstance, MethodGetString, parametersOfGetString, methodGetStringPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetString.ShouldNotBeNull();
            parametersOfGetString.Length.ShouldBe(1);
            methodGetStringPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetString) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetString_Method_Call_Overloading_Of_1_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetStringPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetString = { sItemName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetString, methodGetStringPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfGetString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetString.ShouldNotBeNull();
            parametersOfGetString.Length.ShouldBe(1);
            methodGetStringPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetString) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetString_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetStringPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetString = { sItemName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, string>(_cStructInstance, MethodGetString, parametersOfGetString, methodGetStringPrametersTypes);

            // Assert
            parametersOfGetString.ShouldNotBeNull();
            parametersOfGetString.Length.ShouldBe(1);
            methodGetStringPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetString) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetString_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetStringPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetString, Fixture, methodGetStringPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetStringPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetString) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetString_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetStringPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetString, Fixture, methodGetStringPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetStringPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetString) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetString_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetStringPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetString, Fixture, methodGetStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetStringPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetString) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetString_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetString, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetString) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetString_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetString, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetString) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetString_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetString, 1);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDate) (Return Type : DateTime) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_GetDate_Method_Call_Internally(Type[] types)
        {
            var methodGetDatePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetDate, Fixture, methodGetDatePrametersTypes);
        }

        #endregion

        #region Method Call : (GetDate) (Return Type : DateTime) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDate_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bTagFound = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetDate(sItemName, out bTagFound);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetDate) (Return Type : DateTime) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDate_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bTagFound = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetDate(sItemName, out bTagFound);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetDate) (Return Type : DateTime) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDate_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bTagFound = CreateType<bool>();
            var methodGetDatePrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfGetDate = { sItemName, bTagFound };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDate, methodGetDatePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, DateTime>(_cStructInstanceFixture, out exception1, parametersOfGetDate);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, DateTime>(_cStructInstance, MethodGetDate, parametersOfGetDate, methodGetDatePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetDate.ShouldNotBeNull();
            parametersOfGetDate.Length.ShouldBe(2);
            methodGetDatePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetDate) (Return Type : DateTime) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDate_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bTagFound = CreateType<bool>();
            var methodGetDatePrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfGetDate = { sItemName, bTagFound };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDate, methodGetDatePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, DateTime>(_cStructInstanceFixture, out exception1, parametersOfGetDate);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, DateTime>(_cStructInstance, MethodGetDate, parametersOfGetDate, methodGetDatePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            parametersOfGetDate.ShouldNotBeNull();
            parametersOfGetDate.Length.ShouldBe(2);
            methodGetDatePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetDate) (Return Type : DateTime) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDate_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bTagFound = CreateType<bool>();
            var methodGetDatePrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfGetDate = { sItemName, bTagFound };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetDate, methodGetDatePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfGetDate);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetDate.ShouldNotBeNull();
            parametersOfGetDate.Length.ShouldBe(2);
            methodGetDatePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDate) (Return Type : DateTime) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDate_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bTagFound = CreateType<bool>();
            var methodGetDatePrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfGetDate = { sItemName, bTagFound };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, DateTime>(_cStructInstance, MethodGetDate, parametersOfGetDate, methodGetDatePrametersTypes);

            // Assert
            parametersOfGetDate.ShouldNotBeNull();
            parametersOfGetDate.Length.ShouldBe(2);
            methodGetDatePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDate) (Return Type : DateTime) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDate_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetDatePrametersTypes = new Type[] { typeof(string), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetDate, Fixture, methodGetDatePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDatePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetDate) (Return Type : DateTime) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDate_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetDatePrametersTypes = new Type[] { typeof(string), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetDate, Fixture, methodGetDatePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetDatePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetDate) (Return Type : DateTime) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDate_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDatePrametersTypes = new Type[] { typeof(string), typeof(bool) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetDate, Fixture, methodGetDatePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDatePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDate) (Return Type : DateTime) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDate_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDate, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetDate) (Return Type : DateTime) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDate_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDate, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDate) (Return Type : DateTime) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDate_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetDate, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDate) (Return Type : DateTime) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_GetDate_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodGetDatePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetDate, Fixture, methodGetDatePrametersTypes);
        }

        #endregion

        #region Method Call : (GetDate) (Return Type : DateTime) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDate_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetDate(sItemName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetDate) (Return Type : DateTime) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDate_Method_DirectCall_Overloading_Of_1_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetDate(sItemName);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetDate) (Return Type : DateTime) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDate_Method_Call_Overloading_Of_1_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetDatePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetDate = { sItemName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDate, methodGetDatePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, DateTime>(_cStructInstanceFixture, out exception1, parametersOfGetDate);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, DateTime>(_cStructInstance, MethodGetDate, parametersOfGetDate, methodGetDatePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetDate.ShouldNotBeNull();
            parametersOfGetDate.Length.ShouldBe(1);
            methodGetDatePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetDate) (Return Type : DateTime) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDate_Method_Call_Overloading_Of_1_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetDatePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetDate = { sItemName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDate, methodGetDatePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, DateTime>(_cStructInstanceFixture, out exception1, parametersOfGetDate);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, DateTime>(_cStructInstance, MethodGetDate, parametersOfGetDate, methodGetDatePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            parametersOfGetDate.ShouldNotBeNull();
            parametersOfGetDate.Length.ShouldBe(1);
            methodGetDatePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetDate) (Return Type : DateTime) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDate_Method_Call_Overloading_Of_1_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetDatePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetDate = { sItemName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetDate, methodGetDatePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfGetDate);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetDate.ShouldNotBeNull();
            parametersOfGetDate.Length.ShouldBe(1);
            methodGetDatePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDate) (Return Type : DateTime) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDate_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetDatePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetDate = { sItemName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, DateTime>(_cStructInstance, MethodGetDate, parametersOfGetDate, methodGetDatePrametersTypes);

            // Assert
            parametersOfGetDate.ShouldNotBeNull();
            parametersOfGetDate.Length.ShouldBe(1);
            methodGetDatePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDate) (Return Type : DateTime) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDate_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetDatePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetDate, Fixture, methodGetDatePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDatePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetDate) (Return Type : DateTime) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDate_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetDatePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetDate, Fixture, methodGetDatePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetDatePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetDate) (Return Type : DateTime) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDate_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDatePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetDate, Fixture, methodGetDatePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDatePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDate) (Return Type : DateTime) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDate_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDate, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetDate) (Return Type : DateTime) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDate_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDate, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDate) (Return Type : DateTime) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDate_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetDate, 1);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetStringAttr) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_GetStringAttr_Method_Call_Internally(Type[] types)
        {
            var methodGetStringAttrPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetStringAttr, Fixture, methodGetStringAttrPrametersTypes);
        }

        #endregion

        #region Method Call : (GetStringAttr) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetStringAttr_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sDefault = CreateType<string>();
            var bTagFound = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetStringAttr(sItemName, sDefault, out bTagFound);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetStringAttr) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetStringAttr_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sDefault = CreateType<string>();
            var bTagFound = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetStringAttr(sItemName, sDefault, out bTagFound);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetStringAttr) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetStringAttr_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sDefault = CreateType<string>();
            var bTagFound = CreateType<bool>();
            var methodGetStringAttrPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(bool) };
            object[] parametersOfGetStringAttr = { sItemName, sDefault, bTagFound };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetStringAttr, methodGetStringAttrPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, string>(_cStructInstanceFixture, out exception1, parametersOfGetStringAttr);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, string>(_cStructInstance, MethodGetStringAttr, parametersOfGetStringAttr, methodGetStringAttrPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetStringAttr.ShouldNotBeNull();
            parametersOfGetStringAttr.Length.ShouldBe(3);
            methodGetStringAttrPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetStringAttr) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetStringAttr_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sDefault = CreateType<string>();
            var bTagFound = CreateType<bool>();
            var methodGetStringAttrPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(bool) };
            object[] parametersOfGetStringAttr = { sItemName, sDefault, bTagFound };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetStringAttr, methodGetStringAttrPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, string>(_cStructInstanceFixture, out exception1, parametersOfGetStringAttr);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, string>(_cStructInstance, MethodGetStringAttr, parametersOfGetStringAttr, methodGetStringAttrPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetStringAttr.ShouldNotBeNull();
            parametersOfGetStringAttr.Length.ShouldBe(3);
            methodGetStringAttrPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetStringAttr) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetStringAttr_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sDefault = CreateType<string>();
            var bTagFound = CreateType<bool>();
            var methodGetStringAttrPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(bool) };
            object[] parametersOfGetStringAttr = { sItemName, sDefault, bTagFound };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetStringAttr, methodGetStringAttrPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfGetStringAttr);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetStringAttr.ShouldNotBeNull();
            parametersOfGetStringAttr.Length.ShouldBe(3);
            methodGetStringAttrPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetStringAttr) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetStringAttr_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sDefault = CreateType<string>();
            var bTagFound = CreateType<bool>();
            var methodGetStringAttrPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(bool) };
            object[] parametersOfGetStringAttr = { sItemName, sDefault, bTagFound };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, string>(_cStructInstance, MethodGetStringAttr, parametersOfGetStringAttr, methodGetStringAttrPrametersTypes);

            // Assert
            parametersOfGetStringAttr.ShouldNotBeNull();
            parametersOfGetStringAttr.Length.ShouldBe(3);
            methodGetStringAttrPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetStringAttr) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetStringAttr_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetStringAttrPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetStringAttr, Fixture, methodGetStringAttrPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetStringAttrPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetStringAttr) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetStringAttr_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetStringAttrPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetStringAttr, Fixture, methodGetStringAttrPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetStringAttrPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetStringAttr) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetStringAttr_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetStringAttrPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(bool) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetStringAttr, Fixture, methodGetStringAttrPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetStringAttrPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetStringAttr) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetStringAttr_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetStringAttr, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetStringAttr) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetStringAttr_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetStringAttr, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetStringAttr) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetStringAttr_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetStringAttr, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetStringAttr) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_GetStringAttr_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodGetStringAttrPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetStringAttr, Fixture, methodGetStringAttrPrametersTypes);
        }

        #endregion

        #region Method Call : (GetStringAttr) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetStringAttr_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetStringAttr(sItemName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetStringAttr) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetStringAttr_Method_DirectCall_Overloading_Of_1_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetStringAttr(sItemName);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetStringAttr) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetStringAttr_Method_Call_Overloading_Of_1_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetStringAttrPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetStringAttr = { sItemName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetStringAttr, methodGetStringAttrPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, string>(_cStructInstanceFixture, out exception1, parametersOfGetStringAttr);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, string>(_cStructInstance, MethodGetStringAttr, parametersOfGetStringAttr, methodGetStringAttrPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetStringAttr.ShouldNotBeNull();
            parametersOfGetStringAttr.Length.ShouldBe(1);
            methodGetStringAttrPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetStringAttr) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetStringAttr_Method_Call_Overloading_Of_1_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetStringAttrPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetStringAttr = { sItemName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetStringAttr, methodGetStringAttrPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, string>(_cStructInstanceFixture, out exception1, parametersOfGetStringAttr);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, string>(_cStructInstance, MethodGetStringAttr, parametersOfGetStringAttr, methodGetStringAttrPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetStringAttr.ShouldNotBeNull();
            parametersOfGetStringAttr.Length.ShouldBe(1);
            methodGetStringAttrPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetStringAttr) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetStringAttr_Method_Call_Overloading_Of_1_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetStringAttrPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetStringAttr = { sItemName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetStringAttr, methodGetStringAttrPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfGetStringAttr);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetStringAttr.ShouldNotBeNull();
            parametersOfGetStringAttr.Length.ShouldBe(1);
            methodGetStringAttrPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetStringAttr) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetStringAttr_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetStringAttrPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetStringAttr = { sItemName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, string>(_cStructInstance, MethodGetStringAttr, parametersOfGetStringAttr, methodGetStringAttrPrametersTypes);

            // Assert
            parametersOfGetStringAttr.ShouldNotBeNull();
            parametersOfGetStringAttr.Length.ShouldBe(1);
            methodGetStringAttrPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetStringAttr) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetStringAttr_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetStringAttrPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetStringAttr, Fixture, methodGetStringAttrPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetStringAttrPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetStringAttr) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetStringAttr_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetStringAttrPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetStringAttr, Fixture, methodGetStringAttrPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetStringAttrPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetStringAttr) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetStringAttr_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetStringAttrPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetStringAttr, Fixture, methodGetStringAttrPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetStringAttrPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetStringAttr) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetStringAttr_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetStringAttr, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetStringAttr) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetStringAttr_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetStringAttr, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetStringAttr) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetStringAttr_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetStringAttr, 1);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetStringAttr) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_GetStringAttr_Method_Overloading_Of_2_Call_Internally(Type[] types)
        {
            var methodGetStringAttrPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetStringAttr, Fixture, methodGetStringAttrPrametersTypes);
        }

        #endregion

        #region Method Call : (GetStringAttr) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetStringAttr_Method_DirectCall_Overloading_Of_2_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sDefault = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetStringAttr(sItemName, sDefault);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetStringAttr) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetStringAttr_Method_DirectCall_Overloading_Of_2_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sDefault = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetStringAttr(sItemName, sDefault);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetStringAttr) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetStringAttr_Method_Call_Overloading_Of_2_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sDefault = CreateType<string>();
            var methodGetStringAttrPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfGetStringAttr = { sItemName, sDefault };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetStringAttr, methodGetStringAttrPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, string>(_cStructInstanceFixture, out exception1, parametersOfGetStringAttr);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, string>(_cStructInstance, MethodGetStringAttr, parametersOfGetStringAttr, methodGetStringAttrPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetStringAttr.ShouldNotBeNull();
            parametersOfGetStringAttr.Length.ShouldBe(2);
            methodGetStringAttrPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetStringAttr) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetStringAttr_Method_Call_Overloading_Of_2_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sDefault = CreateType<string>();
            var methodGetStringAttrPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfGetStringAttr = { sItemName, sDefault };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetStringAttr, methodGetStringAttrPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, string>(_cStructInstanceFixture, out exception1, parametersOfGetStringAttr);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, string>(_cStructInstance, MethodGetStringAttr, parametersOfGetStringAttr, methodGetStringAttrPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetStringAttr.ShouldNotBeNull();
            parametersOfGetStringAttr.Length.ShouldBe(2);
            methodGetStringAttrPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetStringAttr) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetStringAttr_Method_Call_Overloading_Of_2_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sDefault = CreateType<string>();
            var methodGetStringAttrPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfGetStringAttr = { sItemName, sDefault };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetStringAttr, methodGetStringAttrPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfGetStringAttr);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetStringAttr.ShouldNotBeNull();
            parametersOfGetStringAttr.Length.ShouldBe(2);
            methodGetStringAttrPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetStringAttr) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetStringAttr_Method_Call_Overloading_Of_2_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sDefault = CreateType<string>();
            var methodGetStringAttrPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfGetStringAttr = { sItemName, sDefault };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, string>(_cStructInstance, MethodGetStringAttr, parametersOfGetStringAttr, methodGetStringAttrPrametersTypes);

            // Assert
            parametersOfGetStringAttr.ShouldNotBeNull();
            parametersOfGetStringAttr.Length.ShouldBe(2);
            methodGetStringAttrPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetStringAttr) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetStringAttr_Method_Call_Overloading_Of_2_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetStringAttrPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetStringAttr, Fixture, methodGetStringAttrPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetStringAttrPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetStringAttr) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetStringAttr_Method_Call_Overloading_Of_2_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetStringAttrPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetStringAttr, Fixture, methodGetStringAttrPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetStringAttrPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetStringAttr) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetStringAttr_Method_Call_Overloading_Of_2_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetStringAttrPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetStringAttr, Fixture, methodGetStringAttrPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetStringAttrPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetStringAttr) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetStringAttr_Method_Call_Overloading_Of_2_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetStringAttr, 2);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetStringAttr) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetStringAttr_Method_Call_Overloading_Of_2_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetStringAttr, 2);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetStringAttr) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetStringAttr_Method_Call_Overloading_Of_2_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetStringAttr, 2);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDateAttr) (Return Type : DateTime) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_GetDateAttr_Method_Call_Internally(Type[] types)
        {
            var methodGetDateAttrPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetDateAttr, Fixture, methodGetDateAttrPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDateAttr) (Return Type : DateTime) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDateAttr_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bTagFound = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetDateAttr(sItemName, out bTagFound);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetDateAttr) (Return Type : DateTime) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDateAttr_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bTagFound = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetDateAttr(sItemName, out bTagFound);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetDateAttr) (Return Type : DateTime) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDateAttr_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bTagFound = CreateType<bool>();
            var methodGetDateAttrPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfGetDateAttr = { sItemName, bTagFound };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDateAttr, methodGetDateAttrPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, DateTime>(_cStructInstanceFixture, out exception1, parametersOfGetDateAttr);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, DateTime>(_cStructInstance, MethodGetDateAttr, parametersOfGetDateAttr, methodGetDateAttrPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetDateAttr.ShouldNotBeNull();
            parametersOfGetDateAttr.Length.ShouldBe(2);
            methodGetDateAttrPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetDateAttr) (Return Type : DateTime) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDateAttr_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bTagFound = CreateType<bool>();
            var methodGetDateAttrPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfGetDateAttr = { sItemName, bTagFound };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDateAttr, methodGetDateAttrPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, DateTime>(_cStructInstanceFixture, out exception1, parametersOfGetDateAttr);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, DateTime>(_cStructInstance, MethodGetDateAttr, parametersOfGetDateAttr, methodGetDateAttrPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            parametersOfGetDateAttr.ShouldNotBeNull();
            parametersOfGetDateAttr.Length.ShouldBe(2);
            methodGetDateAttrPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetDateAttr) (Return Type : DateTime) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDateAttr_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bTagFound = CreateType<bool>();
            var methodGetDateAttrPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfGetDateAttr = { sItemName, bTagFound };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetDateAttr, methodGetDateAttrPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfGetDateAttr);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetDateAttr.ShouldNotBeNull();
            parametersOfGetDateAttr.Length.ShouldBe(2);
            methodGetDateAttrPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDateAttr) (Return Type : DateTime) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDateAttr_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bTagFound = CreateType<bool>();
            var methodGetDateAttrPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfGetDateAttr = { sItemName, bTagFound };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, DateTime>(_cStructInstance, MethodGetDateAttr, parametersOfGetDateAttr, methodGetDateAttrPrametersTypes);

            // Assert
            parametersOfGetDateAttr.ShouldNotBeNull();
            parametersOfGetDateAttr.Length.ShouldBe(2);
            methodGetDateAttrPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDateAttr) (Return Type : DateTime) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDateAttr_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetDateAttrPrametersTypes = new Type[] { typeof(string), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetDateAttr, Fixture, methodGetDateAttrPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDateAttrPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetDateAttr) (Return Type : DateTime) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDateAttr_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetDateAttrPrametersTypes = new Type[] { typeof(string), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetDateAttr, Fixture, methodGetDateAttrPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetDateAttrPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetDateAttr) (Return Type : DateTime) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDateAttr_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDateAttrPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetDateAttr, Fixture, methodGetDateAttrPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDateAttrPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDateAttr) (Return Type : DateTime) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDateAttr_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDateAttr, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetDateAttr) (Return Type : DateTime) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDateAttr_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDateAttr, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDateAttr) (Return Type : DateTime) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDateAttr_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetDateAttr, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDateAttr) (Return Type : DateTime) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_GetDateAttr_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodGetDateAttrPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetDateAttr, Fixture, methodGetDateAttrPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDateAttr) (Return Type : DateTime) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDateAttr_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetDateAttr(sItemName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetDateAttr) (Return Type : DateTime) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDateAttr_Method_DirectCall_Overloading_Of_1_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetDateAttr(sItemName);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetDateAttr) (Return Type : DateTime) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDateAttr_Method_Call_Overloading_Of_1_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetDateAttrPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetDateAttr = { sItemName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDateAttr, methodGetDateAttrPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, DateTime>(_cStructInstanceFixture, out exception1, parametersOfGetDateAttr);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, DateTime>(_cStructInstance, MethodGetDateAttr, parametersOfGetDateAttr, methodGetDateAttrPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetDateAttr.ShouldNotBeNull();
            parametersOfGetDateAttr.Length.ShouldBe(1);
            methodGetDateAttrPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetDateAttr) (Return Type : DateTime) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDateAttr_Method_Call_Overloading_Of_1_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetDateAttrPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetDateAttr = { sItemName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDateAttr, methodGetDateAttrPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, DateTime>(_cStructInstanceFixture, out exception1, parametersOfGetDateAttr);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, DateTime>(_cStructInstance, MethodGetDateAttr, parametersOfGetDateAttr, methodGetDateAttrPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            parametersOfGetDateAttr.ShouldNotBeNull();
            parametersOfGetDateAttr.Length.ShouldBe(1);
            methodGetDateAttrPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetDateAttr) (Return Type : DateTime) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDateAttr_Method_Call_Overloading_Of_1_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetDateAttrPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetDateAttr = { sItemName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetDateAttr, methodGetDateAttrPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfGetDateAttr);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetDateAttr.ShouldNotBeNull();
            parametersOfGetDateAttr.Length.ShouldBe(1);
            methodGetDateAttrPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDateAttr) (Return Type : DateTime) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDateAttr_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetDateAttrPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetDateAttr = { sItemName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, DateTime>(_cStructInstance, MethodGetDateAttr, parametersOfGetDateAttr, methodGetDateAttrPrametersTypes);

            // Assert
            parametersOfGetDateAttr.ShouldNotBeNull();
            parametersOfGetDateAttr.Length.ShouldBe(1);
            methodGetDateAttrPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDateAttr) (Return Type : DateTime) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDateAttr_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetDateAttrPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetDateAttr, Fixture, methodGetDateAttrPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDateAttrPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetDateAttr) (Return Type : DateTime) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDateAttr_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetDateAttrPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetDateAttr, Fixture, methodGetDateAttrPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetDateAttrPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetDateAttr) (Return Type : DateTime) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDateAttr_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDateAttrPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetDateAttr, Fixture, methodGetDateAttrPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDateAttrPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDateAttr) (Return Type : DateTime) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDateAttr_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDateAttr, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetDateAttr) (Return Type : DateTime) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDateAttr_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDateAttr, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDateAttr) (Return Type : DateTime) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetDateAttr_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetDateAttr, 1);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetGuid) (Return Type : Guid) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_GetGuid_Method_Call_Internally(Type[] types)
        {
            var methodGetGuidPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetGuid, Fixture, methodGetGuidPrametersTypes);
        }

        #endregion

        #region Method Call : (GetGuid) (Return Type : Guid) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetGuid_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetGuid(sItemName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetGuid) (Return Type : Guid) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetGuid_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetGuid(sItemName);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetGuid) (Return Type : Guid) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetGuid_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetGuidPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetGuid = { sItemName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetGuid, methodGetGuidPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, Guid>(_cStructInstanceFixture, out exception1, parametersOfGetGuid);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, Guid>(_cStructInstance, MethodGetGuid, parametersOfGetGuid, methodGetGuidPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetGuid.ShouldNotBeNull();
            parametersOfGetGuid.Length.ShouldBe(1);
            methodGetGuidPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetGuid) (Return Type : Guid) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetGuid_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetGuidPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetGuid = { sItemName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetGuid, methodGetGuidPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, Guid>(_cStructInstanceFixture, out exception1, parametersOfGetGuid);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, Guid>(_cStructInstance, MethodGetGuid, parametersOfGetGuid, methodGetGuidPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetGuid.ShouldNotBeNull();
            parametersOfGetGuid.Length.ShouldBe(1);
            methodGetGuidPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetGuid) (Return Type : Guid) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetGuid_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetGuidPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetGuid = { sItemName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetGuid, methodGetGuidPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfGetGuid);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetGuid.ShouldNotBeNull();
            parametersOfGetGuid.Length.ShouldBe(1);
            methodGetGuidPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetGuid) (Return Type : Guid) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetGuid_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetGuidPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetGuid = { sItemName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, Guid>(_cStructInstance, MethodGetGuid, parametersOfGetGuid, methodGetGuidPrametersTypes);

            // Assert
            parametersOfGetGuid.ShouldNotBeNull();
            parametersOfGetGuid.Length.ShouldBe(1);
            methodGetGuidPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetGuid) (Return Type : Guid) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetGuid_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetGuidPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetGuid, Fixture, methodGetGuidPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetGuidPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetGuid) (Return Type : Guid) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetGuid_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetGuidPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetGuid, Fixture, methodGetGuidPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetGuidPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetGuid) (Return Type : Guid) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetGuid_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetGuidPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetGuid, Fixture, methodGetGuidPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetGuidPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetGuid) (Return Type : Guid) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetGuid_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetGuid, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetGuid) (Return Type : Guid) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetGuid_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetGuid, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetGuid) (Return Type : Guid) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetGuid_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetGuid, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetGuidAttr) (Return Type : Guid) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_GetGuidAttr_Method_Call_Internally(Type[] types)
        {
            var methodGetGuidAttrPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetGuidAttr, Fixture, methodGetGuidAttrPrametersTypes);
        }

        #endregion

        #region Method Call : (GetGuidAttr) (Return Type : Guid) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetGuidAttr_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetGuidAttr(sItemName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetGuidAttr) (Return Type : Guid) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetGuidAttr_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.GetGuidAttr(sItemName);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetGuidAttr) (Return Type : Guid) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetGuidAttr_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetGuidAttrPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetGuidAttr = { sItemName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetGuidAttr, methodGetGuidAttrPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, Guid>(_cStructInstanceFixture, out exception1, parametersOfGetGuidAttr);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, Guid>(_cStructInstance, MethodGetGuidAttr, parametersOfGetGuidAttr, methodGetGuidAttrPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetGuidAttr.ShouldNotBeNull();
            parametersOfGetGuidAttr.Length.ShouldBe(1);
            methodGetGuidAttrPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetGuidAttr) (Return Type : Guid) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetGuidAttr_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetGuidAttrPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetGuidAttr = { sItemName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetGuidAttr, methodGetGuidAttrPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, Guid>(_cStructInstanceFixture, out exception1, parametersOfGetGuidAttr);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, Guid>(_cStructInstance, MethodGetGuidAttr, parametersOfGetGuidAttr, methodGetGuidAttrPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetGuidAttr.ShouldNotBeNull();
            parametersOfGetGuidAttr.Length.ShouldBe(1);
            methodGetGuidAttrPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetGuidAttr) (Return Type : Guid) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetGuidAttr_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetGuidAttrPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetGuidAttr = { sItemName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetGuidAttr, methodGetGuidAttrPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfGetGuidAttr);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetGuidAttr.ShouldNotBeNull();
            parametersOfGetGuidAttr.Length.ShouldBe(1);
            methodGetGuidAttrPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetGuidAttr) (Return Type : Guid) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetGuidAttr_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var methodGetGuidAttrPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetGuidAttr = { sItemName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, Guid>(_cStructInstance, MethodGetGuidAttr, parametersOfGetGuidAttr, methodGetGuidAttrPrametersTypes);

            // Assert
            parametersOfGetGuidAttr.ShouldNotBeNull();
            parametersOfGetGuidAttr.Length.ShouldBe(1);
            methodGetGuidAttrPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetGuidAttr) (Return Type : Guid) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetGuidAttr_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetGuidAttrPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetGuidAttr, Fixture, methodGetGuidAttrPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetGuidAttrPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetGuidAttr) (Return Type : Guid) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetGuidAttr_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetGuidAttrPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetGuidAttr, Fixture, methodGetGuidAttrPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetGuidAttrPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetGuidAttr) (Return Type : Guid) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetGuidAttr_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetGuidAttrPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodGetGuidAttr, Fixture, methodGetGuidAttrPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetGuidAttrPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetGuidAttr) (Return Type : Guid) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetGuidAttr_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetGuidAttr, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetGuidAttr) (Return Type : Guid) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetGuidAttr_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetGuidAttr, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetGuidAttr) (Return Type : Guid) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_GetGuidAttr_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetGuidAttr, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateString) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_CreateString_Method_Call_Internally(Type[] types)
        {
            var methodCreateStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodCreateString, Fixture, methodCreateStringPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateString) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateString_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sValue = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.CreateString(sItemName, sValue);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CreateString) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateString_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sValue = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.CreateString(sItemName, sValue);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (CreateString) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateString_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sValue = CreateType<string>();
            var methodCreateStringPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfCreateString = { sItemName, sValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateString, methodCreateStringPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfCreateString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateString.ShouldNotBeNull();
            parametersOfCreateString.Length.ShouldBe(2);
            methodCreateStringPrametersTypes.Length.ShouldBe(2);
            methodCreateStringPrametersTypes.Length.ShouldBe(parametersOfCreateString.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CreateString) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateString_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sValue = CreateType<string>();
            var methodCreateStringPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfCreateString = { sItemName, sValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateString, methodCreateStringPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfCreateString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateString.ShouldNotBeNull();
            parametersOfCreateString.Length.ShouldBe(2);
            methodCreateStringPrametersTypes.Length.ShouldBe(2);
            methodCreateStringPrametersTypes.Length.ShouldBe(parametersOfCreateString.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateString) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateString_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sValue = CreateType<string>();
            var methodCreateStringPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfCreateString = { sItemName, sValue };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cStructInstance, MethodCreateString, parametersOfCreateString, methodCreateStringPrametersTypes);

            // Assert
            parametersOfCreateString.ShouldNotBeNull();
            parametersOfCreateString.Length.ShouldBe(2);
            methodCreateStringPrametersTypes.Length.ShouldBe(2);
            methodCreateStringPrametersTypes.Length.ShouldBe(parametersOfCreateString.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateString) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateString_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreateString, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateString) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateString_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateStringPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodCreateString, Fixture, methodCreateStringPrametersTypes);

            // Assert
            methodCreateStringPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateString) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateString_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateString, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateStringAttr) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_CreateStringAttr_Method_Call_Internally(Type[] types)
        {
            var methodCreateStringAttrPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodCreateStringAttr, Fixture, methodCreateStringAttrPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateStringAttr) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateStringAttr_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sValue = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.CreateStringAttr(sItemName, sValue);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CreateStringAttr) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateStringAttr_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sValue = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.CreateStringAttr(sItemName, sValue);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (CreateStringAttr) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateStringAttr_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sValue = CreateType<string>();
            var methodCreateStringAttrPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfCreateStringAttr = { sItemName, sValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateStringAttr, methodCreateStringAttrPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfCreateStringAttr);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateStringAttr.ShouldNotBeNull();
            parametersOfCreateStringAttr.Length.ShouldBe(2);
            methodCreateStringAttrPrametersTypes.Length.ShouldBe(2);
            methodCreateStringAttrPrametersTypes.Length.ShouldBe(parametersOfCreateStringAttr.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CreateStringAttr) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateStringAttr_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sValue = CreateType<string>();
            var methodCreateStringAttrPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfCreateStringAttr = { sItemName, sValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateStringAttr, methodCreateStringAttrPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfCreateStringAttr);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateStringAttr.ShouldNotBeNull();
            parametersOfCreateStringAttr.Length.ShouldBe(2);
            methodCreateStringAttrPrametersTypes.Length.ShouldBe(2);
            methodCreateStringAttrPrametersTypes.Length.ShouldBe(parametersOfCreateStringAttr.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateStringAttr) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateStringAttr_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var sValue = CreateType<string>();
            var methodCreateStringAttrPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfCreateStringAttr = { sItemName, sValue };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cStructInstance, MethodCreateStringAttr, parametersOfCreateStringAttr, methodCreateStringAttrPrametersTypes);

            // Assert
            parametersOfCreateStringAttr.ShouldNotBeNull();
            parametersOfCreateStringAttr.Length.ShouldBe(2);
            methodCreateStringAttrPrametersTypes.Length.ShouldBe(2);
            methodCreateStringAttrPrametersTypes.Length.ShouldBe(parametersOfCreateStringAttr.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateStringAttr) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateStringAttr_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreateStringAttr, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateStringAttr) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateStringAttr_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateStringAttrPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodCreateStringAttr, Fixture, methodCreateStringAttrPrametersTypes);

            // Assert
            methodCreateStringAttrPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateStringAttr) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateStringAttr_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateStringAttr, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateBoolean) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_CreateBoolean_Method_Call_Internally(Type[] types)
        {
            var methodCreateBooleanPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodCreateBoolean, Fixture, methodCreateBooleanPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateBoolean) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateBoolean_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bValue = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.CreateBoolean(sItemName, bValue);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CreateBoolean) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateBoolean_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bValue = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.CreateBoolean(sItemName, bValue);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (CreateBoolean) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateBoolean_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bValue = CreateType<bool>();
            var methodCreateBooleanPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfCreateBoolean = { sItemName, bValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateBoolean, methodCreateBooleanPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfCreateBoolean);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateBoolean.ShouldNotBeNull();
            parametersOfCreateBoolean.Length.ShouldBe(2);
            methodCreateBooleanPrametersTypes.Length.ShouldBe(2);
            methodCreateBooleanPrametersTypes.Length.ShouldBe(parametersOfCreateBoolean.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CreateBoolean) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateBoolean_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bValue = CreateType<bool>();
            var methodCreateBooleanPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfCreateBoolean = { sItemName, bValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateBoolean, methodCreateBooleanPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfCreateBoolean);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateBoolean.ShouldNotBeNull();
            parametersOfCreateBoolean.Length.ShouldBe(2);
            methodCreateBooleanPrametersTypes.Length.ShouldBe(2);
            methodCreateBooleanPrametersTypes.Length.ShouldBe(parametersOfCreateBoolean.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateBoolean) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateBoolean_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bValue = CreateType<bool>();
            var methodCreateBooleanPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfCreateBoolean = { sItemName, bValue };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cStructInstance, MethodCreateBoolean, parametersOfCreateBoolean, methodCreateBooleanPrametersTypes);

            // Assert
            parametersOfCreateBoolean.ShouldNotBeNull();
            parametersOfCreateBoolean.Length.ShouldBe(2);
            methodCreateBooleanPrametersTypes.Length.ShouldBe(2);
            methodCreateBooleanPrametersTypes.Length.ShouldBe(parametersOfCreateBoolean.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateBoolean) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateBoolean_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreateBoolean, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateBoolean) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateBoolean_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateBooleanPrametersTypes = new Type[] { typeof(string), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodCreateBoolean, Fixture, methodCreateBooleanPrametersTypes);

            // Assert
            methodCreateBooleanPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateBoolean) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateBoolean_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateBoolean, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateBooleanAttr) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_CreateBooleanAttr_Method_Call_Internally(Type[] types)
        {
            var methodCreateBooleanAttrPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodCreateBooleanAttr, Fixture, methodCreateBooleanAttrPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateBooleanAttr) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateBooleanAttr_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bValue = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.CreateBooleanAttr(sItemName, bValue);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CreateBooleanAttr) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateBooleanAttr_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bValue = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.CreateBooleanAttr(sItemName, bValue);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (CreateBooleanAttr) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateBooleanAttr_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bValue = CreateType<bool>();
            var methodCreateBooleanAttrPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfCreateBooleanAttr = { sItemName, bValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateBooleanAttr, methodCreateBooleanAttrPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfCreateBooleanAttr);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateBooleanAttr.ShouldNotBeNull();
            parametersOfCreateBooleanAttr.Length.ShouldBe(2);
            methodCreateBooleanAttrPrametersTypes.Length.ShouldBe(2);
            methodCreateBooleanAttrPrametersTypes.Length.ShouldBe(parametersOfCreateBooleanAttr.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CreateBooleanAttr) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateBooleanAttr_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bValue = CreateType<bool>();
            var methodCreateBooleanAttrPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfCreateBooleanAttr = { sItemName, bValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateBooleanAttr, methodCreateBooleanAttrPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfCreateBooleanAttr);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateBooleanAttr.ShouldNotBeNull();
            parametersOfCreateBooleanAttr.Length.ShouldBe(2);
            methodCreateBooleanAttrPrametersTypes.Length.ShouldBe(2);
            methodCreateBooleanAttrPrametersTypes.Length.ShouldBe(parametersOfCreateBooleanAttr.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateBooleanAttr) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateBooleanAttr_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var bValue = CreateType<bool>();
            var methodCreateBooleanAttrPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfCreateBooleanAttr = { sItemName, bValue };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cStructInstance, MethodCreateBooleanAttr, parametersOfCreateBooleanAttr, methodCreateBooleanAttrPrametersTypes);

            // Assert
            parametersOfCreateBooleanAttr.ShouldNotBeNull();
            parametersOfCreateBooleanAttr.Length.ShouldBe(2);
            methodCreateBooleanAttrPrametersTypes.Length.ShouldBe(2);
            methodCreateBooleanAttrPrametersTypes.Length.ShouldBe(parametersOfCreateBooleanAttr.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateBooleanAttr) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateBooleanAttr_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreateBooleanAttr, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateBooleanAttr) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateBooleanAttr_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateBooleanAttrPrametersTypes = new Type[] { typeof(string), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodCreateBooleanAttr, Fixture, methodCreateBooleanAttrPrametersTypes);

            // Assert
            methodCreateBooleanAttrPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateBooleanAttr) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateBooleanAttr_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateBooleanAttr, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateShortAttr) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_CreateShortAttr_Method_Call_Internally(Type[] types)
        {
            var methodCreateShortAttrPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodCreateShortAttr, Fixture, methodCreateShortAttrPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateShortAttr) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateShortAttr_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var iValue = CreateType<short>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.CreateShortAttr(sItemName, iValue);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CreateShortAttr) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateShortAttr_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var iValue = CreateType<short>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.CreateShortAttr(sItemName, iValue);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (CreateShortAttr) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateShortAttr_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var iValue = CreateType<short>();
            var methodCreateShortAttrPrametersTypes = new Type[] { typeof(string), typeof(short) };
            object[] parametersOfCreateShortAttr = { sItemName, iValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateShortAttr, methodCreateShortAttrPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfCreateShortAttr);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateShortAttr.ShouldNotBeNull();
            parametersOfCreateShortAttr.Length.ShouldBe(2);
            methodCreateShortAttrPrametersTypes.Length.ShouldBe(2);
            methodCreateShortAttrPrametersTypes.Length.ShouldBe(parametersOfCreateShortAttr.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CreateShortAttr) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateShortAttr_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var iValue = CreateType<short>();
            var methodCreateShortAttrPrametersTypes = new Type[] { typeof(string), typeof(short) };
            object[] parametersOfCreateShortAttr = { sItemName, iValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateShortAttr, methodCreateShortAttrPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfCreateShortAttr);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateShortAttr.ShouldNotBeNull();
            parametersOfCreateShortAttr.Length.ShouldBe(2);
            methodCreateShortAttrPrametersTypes.Length.ShouldBe(2);
            methodCreateShortAttrPrametersTypes.Length.ShouldBe(parametersOfCreateShortAttr.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateShortAttr) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateShortAttr_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var iValue = CreateType<short>();
            var methodCreateShortAttrPrametersTypes = new Type[] { typeof(string), typeof(short) };
            object[] parametersOfCreateShortAttr = { sItemName, iValue };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cStructInstance, MethodCreateShortAttr, parametersOfCreateShortAttr, methodCreateShortAttrPrametersTypes);

            // Assert
            parametersOfCreateShortAttr.ShouldNotBeNull();
            parametersOfCreateShortAttr.Length.ShouldBe(2);
            methodCreateShortAttrPrametersTypes.Length.ShouldBe(2);
            methodCreateShortAttrPrametersTypes.Length.ShouldBe(parametersOfCreateShortAttr.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateShortAttr) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateShortAttr_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreateShortAttr, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateShortAttr) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateShortAttr_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateShortAttrPrametersTypes = new Type[] { typeof(string), typeof(short) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodCreateShortAttr, Fixture, methodCreateShortAttrPrametersTypes);

            // Assert
            methodCreateShortAttrPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateShortAttr) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateShortAttr_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateShortAttr, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateInt) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_CreateInt_Method_Call_Internally(Type[] types)
        {
            var methodCreateIntPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodCreateInt, Fixture, methodCreateIntPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateInt) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateInt_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var iValue = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.CreateInt(sItemName, iValue);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CreateInt) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateInt_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var iValue = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.CreateInt(sItemName, iValue);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (CreateInt) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateInt_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var iValue = CreateType<int>();
            var methodCreateIntPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfCreateInt = { sItemName, iValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateInt, methodCreateIntPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfCreateInt);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateInt.ShouldNotBeNull();
            parametersOfCreateInt.Length.ShouldBe(2);
            methodCreateIntPrametersTypes.Length.ShouldBe(2);
            methodCreateIntPrametersTypes.Length.ShouldBe(parametersOfCreateInt.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CreateInt) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateInt_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var iValue = CreateType<int>();
            var methodCreateIntPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfCreateInt = { sItemName, iValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateInt, methodCreateIntPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfCreateInt);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateInt.ShouldNotBeNull();
            parametersOfCreateInt.Length.ShouldBe(2);
            methodCreateIntPrametersTypes.Length.ShouldBe(2);
            methodCreateIntPrametersTypes.Length.ShouldBe(parametersOfCreateInt.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateInt) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateInt_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var iValue = CreateType<int>();
            var methodCreateIntPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfCreateInt = { sItemName, iValue };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cStructInstance, MethodCreateInt, parametersOfCreateInt, methodCreateIntPrametersTypes);

            // Assert
            parametersOfCreateInt.ShouldNotBeNull();
            parametersOfCreateInt.Length.ShouldBe(2);
            methodCreateIntPrametersTypes.Length.ShouldBe(2);
            methodCreateIntPrametersTypes.Length.ShouldBe(parametersOfCreateInt.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateInt) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateInt_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreateInt, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateInt) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateInt_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateIntPrametersTypes = new Type[] { typeof(string), typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodCreateInt, Fixture, methodCreateIntPrametersTypes);

            // Assert
            methodCreateIntPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateInt) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateInt_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateInt, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReplaceInt) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_ReplaceInt_Method_Call_Internally(Type[] types)
        {
            var methodReplaceIntPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodReplaceInt, Fixture, methodReplaceIntPrametersTypes);
        }

        #endregion

        #region Method Call : (ReplaceInt) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ReplaceInt_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var lNewValue = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.ReplaceInt(sItemName, lNewValue);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ReplaceInt) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ReplaceInt_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var lNewValue = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.ReplaceInt(sItemName, lNewValue);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ReplaceInt) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ReplaceInt_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var lNewValue = CreateType<int>();
            var methodReplaceIntPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfReplaceInt = { sItemName, lNewValue };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodReplaceInt, methodReplaceIntPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, bool>(_cStructInstanceFixture, out exception1, parametersOfReplaceInt);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, bool>(_cStructInstance, MethodReplaceInt, parametersOfReplaceInt, methodReplaceIntPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfReplaceInt.ShouldNotBeNull();
            parametersOfReplaceInt.Length.ShouldBe(2);
            methodReplaceIntPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ReplaceInt) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ReplaceInt_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var lNewValue = CreateType<int>();
            var methodReplaceIntPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfReplaceInt = { sItemName, lNewValue };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodReplaceInt, methodReplaceIntPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, bool>(_cStructInstanceFixture, out exception1, parametersOfReplaceInt);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, bool>(_cStructInstance, MethodReplaceInt, parametersOfReplaceInt, methodReplaceIntPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfReplaceInt.ShouldNotBeNull();
            parametersOfReplaceInt.Length.ShouldBe(2);
            methodReplaceIntPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ReplaceInt) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ReplaceInt_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var lNewValue = CreateType<int>();
            var methodReplaceIntPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfReplaceInt = { sItemName, lNewValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReplaceInt, methodReplaceIntPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfReplaceInt);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReplaceInt.ShouldNotBeNull();
            parametersOfReplaceInt.Length.ShouldBe(2);
            methodReplaceIntPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReplaceInt) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ReplaceInt_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var lNewValue = CreateType<int>();
            var methodReplaceIntPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfReplaceInt = { sItemName, lNewValue };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, bool>(_cStructInstance, MethodReplaceInt, parametersOfReplaceInt, methodReplaceIntPrametersTypes);

            // Assert
            parametersOfReplaceInt.ShouldNotBeNull();
            parametersOfReplaceInt.Length.ShouldBe(2);
            methodReplaceIntPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReplaceInt) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ReplaceInt_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodReplaceIntPrametersTypes = new Type[] { typeof(string), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodReplaceInt, Fixture, methodReplaceIntPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodReplaceIntPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ReplaceInt) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ReplaceInt_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodReplaceIntPrametersTypes = new Type[] { typeof(string), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodReplaceInt, Fixture, methodReplaceIntPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodReplaceIntPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ReplaceInt) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ReplaceInt_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReplaceIntPrametersTypes = new Type[] { typeof(string), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodReplaceInt, Fixture, methodReplaceIntPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodReplaceIntPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReplaceInt) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ReplaceInt_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReplaceInt, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ReplaceInt) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ReplaceInt_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReplaceInt, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ReplaceInt) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_ReplaceInt_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReplaceInt, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateDouble) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_CreateDouble_Method_Call_Internally(Type[] types)
        {
            var methodCreateDoublePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodCreateDouble, Fixture, methodCreateDoublePrametersTypes);
        }

        #endregion

        #region Method Call : (CreateDouble) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateDouble_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var dblValue = CreateType<double>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.CreateDouble(sItemName, dblValue);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CreateDouble) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateDouble_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var dblValue = CreateType<double>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.CreateDouble(sItemName, dblValue);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (CreateDouble) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateDouble_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var dblValue = CreateType<double>();
            var methodCreateDoublePrametersTypes = new Type[] { typeof(string), typeof(double) };
            object[] parametersOfCreateDouble = { sItemName, dblValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateDouble, methodCreateDoublePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfCreateDouble);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateDouble.ShouldNotBeNull();
            parametersOfCreateDouble.Length.ShouldBe(2);
            methodCreateDoublePrametersTypes.Length.ShouldBe(2);
            methodCreateDoublePrametersTypes.Length.ShouldBe(parametersOfCreateDouble.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CreateDouble) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateDouble_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var dblValue = CreateType<double>();
            var methodCreateDoublePrametersTypes = new Type[] { typeof(string), typeof(double) };
            object[] parametersOfCreateDouble = { sItemName, dblValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateDouble, methodCreateDoublePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfCreateDouble);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateDouble.ShouldNotBeNull();
            parametersOfCreateDouble.Length.ShouldBe(2);
            methodCreateDoublePrametersTypes.Length.ShouldBe(2);
            methodCreateDoublePrametersTypes.Length.ShouldBe(parametersOfCreateDouble.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateDouble) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateDouble_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var dblValue = CreateType<double>();
            var methodCreateDoublePrametersTypes = new Type[] { typeof(string), typeof(double) };
            object[] parametersOfCreateDouble = { sItemName, dblValue };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cStructInstance, MethodCreateDouble, parametersOfCreateDouble, methodCreateDoublePrametersTypes);

            // Assert
            parametersOfCreateDouble.ShouldNotBeNull();
            parametersOfCreateDouble.Length.ShouldBe(2);
            methodCreateDoublePrametersTypes.Length.ShouldBe(2);
            methodCreateDoublePrametersTypes.Length.ShouldBe(parametersOfCreateDouble.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateDouble) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateDouble_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreateDouble, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateDouble) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateDouble_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateDoublePrametersTypes = new Type[] { typeof(string), typeof(double) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodCreateDouble, Fixture, methodCreateDoublePrametersTypes);

            // Assert
            methodCreateDoublePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateDouble) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateDouble_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateDouble, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateIntAttr) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_CreateIntAttr_Method_Call_Internally(Type[] types)
        {
            var methodCreateIntAttrPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodCreateIntAttr, Fixture, methodCreateIntAttrPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateIntAttr) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateIntAttr_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var iValue = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.CreateIntAttr(sItemName, iValue);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CreateIntAttr) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateIntAttr_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var iValue = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.CreateIntAttr(sItemName, iValue);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (CreateIntAttr) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateIntAttr_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var iValue = CreateType<int>();
            var methodCreateIntAttrPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfCreateIntAttr = { sItemName, iValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateIntAttr, methodCreateIntAttrPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfCreateIntAttr);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateIntAttr.ShouldNotBeNull();
            parametersOfCreateIntAttr.Length.ShouldBe(2);
            methodCreateIntAttrPrametersTypes.Length.ShouldBe(2);
            methodCreateIntAttrPrametersTypes.Length.ShouldBe(parametersOfCreateIntAttr.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CreateIntAttr) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateIntAttr_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var iValue = CreateType<int>();
            var methodCreateIntAttrPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfCreateIntAttr = { sItemName, iValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateIntAttr, methodCreateIntAttrPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfCreateIntAttr);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateIntAttr.ShouldNotBeNull();
            parametersOfCreateIntAttr.Length.ShouldBe(2);
            methodCreateIntAttrPrametersTypes.Length.ShouldBe(2);
            methodCreateIntAttrPrametersTypes.Length.ShouldBe(parametersOfCreateIntAttr.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateIntAttr) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateIntAttr_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var iValue = CreateType<int>();
            var methodCreateIntAttrPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfCreateIntAttr = { sItemName, iValue };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cStructInstance, MethodCreateIntAttr, parametersOfCreateIntAttr, methodCreateIntAttrPrametersTypes);

            // Assert
            parametersOfCreateIntAttr.ShouldNotBeNull();
            parametersOfCreateIntAttr.Length.ShouldBe(2);
            methodCreateIntAttrPrametersTypes.Length.ShouldBe(2);
            methodCreateIntAttrPrametersTypes.Length.ShouldBe(parametersOfCreateIntAttr.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateIntAttr) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateIntAttr_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreateIntAttr, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateIntAttr) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateIntAttr_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateIntAttrPrametersTypes = new Type[] { typeof(string), typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodCreateIntAttr, Fixture, methodCreateIntAttrPrametersTypes);

            // Assert
            methodCreateIntAttrPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateIntAttr) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateIntAttr_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateIntAttr, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateDoubleAttr) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_CreateDoubleAttr_Method_Call_Internally(Type[] types)
        {
            var methodCreateDoubleAttrPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodCreateDoubleAttr, Fixture, methodCreateDoubleAttrPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateDoubleAttr) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateDoubleAttr_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var dblValue = CreateType<double>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.CreateDoubleAttr(sItemName, dblValue);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CreateDoubleAttr) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateDoubleAttr_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var dblValue = CreateType<double>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.CreateDoubleAttr(sItemName, dblValue);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (CreateDoubleAttr) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateDoubleAttr_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var dblValue = CreateType<double>();
            var methodCreateDoubleAttrPrametersTypes = new Type[] { typeof(string), typeof(double) };
            object[] parametersOfCreateDoubleAttr = { sItemName, dblValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateDoubleAttr, methodCreateDoubleAttrPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfCreateDoubleAttr);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateDoubleAttr.ShouldNotBeNull();
            parametersOfCreateDoubleAttr.Length.ShouldBe(2);
            methodCreateDoubleAttrPrametersTypes.Length.ShouldBe(2);
            methodCreateDoubleAttrPrametersTypes.Length.ShouldBe(parametersOfCreateDoubleAttr.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CreateDoubleAttr) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateDoubleAttr_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var dblValue = CreateType<double>();
            var methodCreateDoubleAttrPrametersTypes = new Type[] { typeof(string), typeof(double) };
            object[] parametersOfCreateDoubleAttr = { sItemName, dblValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateDoubleAttr, methodCreateDoubleAttrPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfCreateDoubleAttr);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateDoubleAttr.ShouldNotBeNull();
            parametersOfCreateDoubleAttr.Length.ShouldBe(2);
            methodCreateDoubleAttrPrametersTypes.Length.ShouldBe(2);
            methodCreateDoubleAttrPrametersTypes.Length.ShouldBe(parametersOfCreateDoubleAttr.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateDoubleAttr) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateDoubleAttr_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var dblValue = CreateType<double>();
            var methodCreateDoubleAttrPrametersTypes = new Type[] { typeof(string), typeof(double) };
            object[] parametersOfCreateDoubleAttr = { sItemName, dblValue };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cStructInstance, MethodCreateDoubleAttr, parametersOfCreateDoubleAttr, methodCreateDoubleAttrPrametersTypes);

            // Assert
            parametersOfCreateDoubleAttr.ShouldNotBeNull();
            parametersOfCreateDoubleAttr.Length.ShouldBe(2);
            methodCreateDoubleAttrPrametersTypes.Length.ShouldBe(2);
            methodCreateDoubleAttrPrametersTypes.Length.ShouldBe(parametersOfCreateDoubleAttr.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateDoubleAttr) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateDoubleAttr_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreateDoubleAttr, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateDoubleAttr) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateDoubleAttr_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateDoubleAttrPrametersTypes = new Type[] { typeof(string), typeof(double) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodCreateDoubleAttr, Fixture, methodCreateDoubleAttrPrametersTypes);

            // Assert
            methodCreateDoubleAttrPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateDoubleAttr) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateDoubleAttr_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateDoubleAttr, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateDecimalAttr) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_CreateDecimalAttr_Method_Call_Internally(Type[] types)
        {
            var methodCreateDecimalAttrPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodCreateDecimalAttr, Fixture, methodCreateDecimalAttrPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateDecimalAttr) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateDecimalAttr_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var decValue = CreateType<decimal>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.CreateDecimalAttr(sItemName, decValue);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CreateDecimalAttr) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateDecimalAttr_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var decValue = CreateType<decimal>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.CreateDecimalAttr(sItemName, decValue);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (CreateDecimalAttr) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateDecimalAttr_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var decValue = CreateType<decimal>();
            var methodCreateDecimalAttrPrametersTypes = new Type[] { typeof(string), typeof(decimal) };
            object[] parametersOfCreateDecimalAttr = { sItemName, decValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateDecimalAttr, methodCreateDecimalAttrPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfCreateDecimalAttr);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateDecimalAttr.ShouldNotBeNull();
            parametersOfCreateDecimalAttr.Length.ShouldBe(2);
            methodCreateDecimalAttrPrametersTypes.Length.ShouldBe(2);
            methodCreateDecimalAttrPrametersTypes.Length.ShouldBe(parametersOfCreateDecimalAttr.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CreateDecimalAttr) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateDecimalAttr_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var decValue = CreateType<decimal>();
            var methodCreateDecimalAttrPrametersTypes = new Type[] { typeof(string), typeof(decimal) };
            object[] parametersOfCreateDecimalAttr = { sItemName, decValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateDecimalAttr, methodCreateDecimalAttrPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfCreateDecimalAttr);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateDecimalAttr.ShouldNotBeNull();
            parametersOfCreateDecimalAttr.Length.ShouldBe(2);
            methodCreateDecimalAttrPrametersTypes.Length.ShouldBe(2);
            methodCreateDecimalAttrPrametersTypes.Length.ShouldBe(parametersOfCreateDecimalAttr.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateDecimalAttr) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateDecimalAttr_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var decValue = CreateType<decimal>();
            var methodCreateDecimalAttrPrametersTypes = new Type[] { typeof(string), typeof(decimal) };
            object[] parametersOfCreateDecimalAttr = { sItemName, decValue };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cStructInstance, MethodCreateDecimalAttr, parametersOfCreateDecimalAttr, methodCreateDecimalAttrPrametersTypes);

            // Assert
            parametersOfCreateDecimalAttr.ShouldNotBeNull();
            parametersOfCreateDecimalAttr.Length.ShouldBe(2);
            methodCreateDecimalAttrPrametersTypes.Length.ShouldBe(2);
            methodCreateDecimalAttrPrametersTypes.Length.ShouldBe(parametersOfCreateDecimalAttr.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateDecimalAttr) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateDecimalAttr_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreateDecimalAttr, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateDecimalAttr) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateDecimalAttr_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateDecimalAttrPrametersTypes = new Type[] { typeof(string), typeof(decimal) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodCreateDecimalAttr, Fixture, methodCreateDecimalAttrPrametersTypes);

            // Assert
            methodCreateDecimalAttrPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateDecimalAttr) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateDecimalAttr_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateDecimalAttr, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateGuid) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_CreateGuid_Method_Call_Internally(Type[] types)
        {
            var methodCreateGuidPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodCreateGuid, Fixture, methodCreateGuidPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateGuid) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateGuid_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var guidValue = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.CreateGuid(sItemName, guidValue);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CreateGuid) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateGuid_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var guidValue = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.CreateGuid(sItemName, guidValue);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (CreateGuid) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateGuid_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var guidValue = CreateType<Guid>();
            var methodCreateGuidPrametersTypes = new Type[] { typeof(string), typeof(Guid) };
            object[] parametersOfCreateGuid = { sItemName, guidValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateGuid, methodCreateGuidPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfCreateGuid);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateGuid.ShouldNotBeNull();
            parametersOfCreateGuid.Length.ShouldBe(2);
            methodCreateGuidPrametersTypes.Length.ShouldBe(2);
            methodCreateGuidPrametersTypes.Length.ShouldBe(parametersOfCreateGuid.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CreateGuid) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateGuid_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var guidValue = CreateType<Guid>();
            var methodCreateGuidPrametersTypes = new Type[] { typeof(string), typeof(Guid) };
            object[] parametersOfCreateGuid = { sItemName, guidValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateGuid, methodCreateGuidPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfCreateGuid);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateGuid.ShouldNotBeNull();
            parametersOfCreateGuid.Length.ShouldBe(2);
            methodCreateGuidPrametersTypes.Length.ShouldBe(2);
            methodCreateGuidPrametersTypes.Length.ShouldBe(parametersOfCreateGuid.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateGuid) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateGuid_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var guidValue = CreateType<Guid>();
            var methodCreateGuidPrametersTypes = new Type[] { typeof(string), typeof(Guid) };
            object[] parametersOfCreateGuid = { sItemName, guidValue };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cStructInstance, MethodCreateGuid, parametersOfCreateGuid, methodCreateGuidPrametersTypes);

            // Assert
            parametersOfCreateGuid.ShouldNotBeNull();
            parametersOfCreateGuid.Length.ShouldBe(2);
            methodCreateGuidPrametersTypes.Length.ShouldBe(2);
            methodCreateGuidPrametersTypes.Length.ShouldBe(parametersOfCreateGuid.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateGuid) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateGuid_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreateGuid, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateGuid) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateGuid_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateGuidPrametersTypes = new Type[] { typeof(string), typeof(Guid) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodCreateGuid, Fixture, methodCreateGuidPrametersTypes);

            // Assert
            methodCreateGuidPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateGuid) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateGuid_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateGuid, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateGuidAttr) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_CreateGuidAttr_Method_Call_Internally(Type[] types)
        {
            var methodCreateGuidAttrPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodCreateGuidAttr, Fixture, methodCreateGuidAttrPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateGuidAttr) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateGuidAttr_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var guidValue = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.CreateGuidAttr(sItemName, guidValue);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CreateGuidAttr) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateGuidAttr_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var guidValue = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.CreateGuidAttr(sItemName, guidValue);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (CreateGuidAttr) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateGuidAttr_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var guidValue = CreateType<Guid>();
            var methodCreateGuidAttrPrametersTypes = new Type[] { typeof(string), typeof(Guid) };
            object[] parametersOfCreateGuidAttr = { sItemName, guidValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateGuidAttr, methodCreateGuidAttrPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfCreateGuidAttr);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateGuidAttr.ShouldNotBeNull();
            parametersOfCreateGuidAttr.Length.ShouldBe(2);
            methodCreateGuidAttrPrametersTypes.Length.ShouldBe(2);
            methodCreateGuidAttrPrametersTypes.Length.ShouldBe(parametersOfCreateGuidAttr.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CreateGuidAttr) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateGuidAttr_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var guidValue = CreateType<Guid>();
            var methodCreateGuidAttrPrametersTypes = new Type[] { typeof(string), typeof(Guid) };
            object[] parametersOfCreateGuidAttr = { sItemName, guidValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateGuidAttr, methodCreateGuidAttrPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfCreateGuidAttr);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateGuidAttr.ShouldNotBeNull();
            parametersOfCreateGuidAttr.Length.ShouldBe(2);
            methodCreateGuidAttrPrametersTypes.Length.ShouldBe(2);
            methodCreateGuidAttrPrametersTypes.Length.ShouldBe(parametersOfCreateGuidAttr.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateGuidAttr) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateGuidAttr_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var guidValue = CreateType<Guid>();
            var methodCreateGuidAttrPrametersTypes = new Type[] { typeof(string), typeof(Guid) };
            object[] parametersOfCreateGuidAttr = { sItemName, guidValue };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cStructInstance, MethodCreateGuidAttr, parametersOfCreateGuidAttr, methodCreateGuidAttrPrametersTypes);

            // Assert
            parametersOfCreateGuidAttr.ShouldNotBeNull();
            parametersOfCreateGuidAttr.Length.ShouldBe(2);
            methodCreateGuidAttrPrametersTypes.Length.ShouldBe(2);
            methodCreateGuidAttrPrametersTypes.Length.ShouldBe(parametersOfCreateGuidAttr.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateGuidAttr) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateGuidAttr_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreateGuidAttr, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateGuidAttr) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateGuidAttr_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateGuidAttrPrametersTypes = new Type[] { typeof(string), typeof(Guid) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodCreateGuidAttr, Fixture, methodCreateGuidAttrPrametersTypes);

            // Assert
            methodCreateGuidAttrPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateGuidAttr) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateGuidAttr_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateGuidAttr, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateDate) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_CreateDate_Method_Call_Internally(Type[] types)
        {
            var methodCreateDatePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodCreateDate, Fixture, methodCreateDatePrametersTypes);
        }

        #endregion

        #region Method Call : (CreateDate) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateDate_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var dtValue = CreateType<DateTime>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.CreateDate(sItemName, dtValue);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CreateDate) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateDate_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var dtValue = CreateType<DateTime>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.CreateDate(sItemName, dtValue);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (CreateDate) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateDate_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var dtValue = CreateType<DateTime>();
            var methodCreateDatePrametersTypes = new Type[] { typeof(string), typeof(DateTime) };
            object[] parametersOfCreateDate = { sItemName, dtValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateDate, methodCreateDatePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfCreateDate);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateDate.ShouldNotBeNull();
            parametersOfCreateDate.Length.ShouldBe(2);
            methodCreateDatePrametersTypes.Length.ShouldBe(2);
            methodCreateDatePrametersTypes.Length.ShouldBe(parametersOfCreateDate.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CreateDate) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateDate_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var dtValue = CreateType<DateTime>();
            var methodCreateDatePrametersTypes = new Type[] { typeof(string), typeof(DateTime) };
            object[] parametersOfCreateDate = { sItemName, dtValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateDate, methodCreateDatePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfCreateDate);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateDate.ShouldNotBeNull();
            parametersOfCreateDate.Length.ShouldBe(2);
            methodCreateDatePrametersTypes.Length.ShouldBe(2);
            methodCreateDatePrametersTypes.Length.ShouldBe(parametersOfCreateDate.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateDate) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateDate_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var dtValue = CreateType<DateTime>();
            var methodCreateDatePrametersTypes = new Type[] { typeof(string), typeof(DateTime) };
            object[] parametersOfCreateDate = { sItemName, dtValue };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cStructInstance, MethodCreateDate, parametersOfCreateDate, methodCreateDatePrametersTypes);

            // Assert
            parametersOfCreateDate.ShouldNotBeNull();
            parametersOfCreateDate.Length.ShouldBe(2);
            methodCreateDatePrametersTypes.Length.ShouldBe(2);
            methodCreateDatePrametersTypes.Length.ShouldBe(parametersOfCreateDate.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateDate) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateDate_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreateDate, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateDate) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateDate_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateDatePrametersTypes = new Type[] { typeof(string), typeof(DateTime) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodCreateDate, Fixture, methodCreateDatePrametersTypes);

            // Assert
            methodCreateDatePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateDate) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateDate_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateDate, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateDateAttr) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_CreateDateAttr_Method_Call_Internally(Type[] types)
        {
            var methodCreateDateAttrPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodCreateDateAttr, Fixture, methodCreateDateAttrPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateDateAttr) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateDateAttr_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var dtValue = CreateType<DateTime>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.CreateDateAttr(sItemName, dtValue);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CreateDateAttr) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateDateAttr_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var dtValue = CreateType<DateTime>();
            Action executeAction = null;

            // Act
            executeAction = () => _cStructInstance.CreateDateAttr(sItemName, dtValue);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (CreateDateAttr) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateDateAttr_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var dtValue = CreateType<DateTime>();
            var methodCreateDateAttrPrametersTypes = new Type[] { typeof(string), typeof(DateTime) };
            object[] parametersOfCreateDateAttr = { sItemName, dtValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateDateAttr, methodCreateDateAttrPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfCreateDateAttr);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateDateAttr.ShouldNotBeNull();
            parametersOfCreateDateAttr.Length.ShouldBe(2);
            methodCreateDateAttrPrametersTypes.Length.ShouldBe(2);
            methodCreateDateAttrPrametersTypes.Length.ShouldBe(parametersOfCreateDateAttr.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CreateDateAttr) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateDateAttr_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var dtValue = CreateType<DateTime>();
            var methodCreateDateAttrPrametersTypes = new Type[] { typeof(string), typeof(DateTime) };
            object[] parametersOfCreateDateAttr = { sItemName, dtValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateDateAttr, methodCreateDateAttrPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfCreateDateAttr);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateDateAttr.ShouldNotBeNull();
            parametersOfCreateDateAttr.Length.ShouldBe(2);
            methodCreateDateAttrPrametersTypes.Length.ShouldBe(2);
            methodCreateDateAttrPrametersTypes.Length.ShouldBe(parametersOfCreateDateAttr.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateDateAttr) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateDateAttr_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItemName = CreateType<string>();
            var dtValue = CreateType<DateTime>();
            var methodCreateDateAttrPrametersTypes = new Type[] { typeof(string), typeof(DateTime) };
            object[] parametersOfCreateDateAttr = { sItemName, dtValue };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cStructInstance, MethodCreateDateAttr, parametersOfCreateDateAttr, methodCreateDateAttrPrametersTypes);

            // Assert
            parametersOfCreateDateAttr.ShouldNotBeNull();
            parametersOfCreateDateAttr.Length.ShouldBe(2);
            methodCreateDateAttrPrametersTypes.Length.ShouldBe(2);
            methodCreateDateAttrPrametersTypes.Length.ShouldBe(parametersOfCreateDateAttr.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateDateAttr) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateDateAttr_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreateDateAttr, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateDateAttr) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateDateAttr_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateDateAttrPrametersTypes = new Type[] { typeof(string), typeof(DateTime) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodCreateDateAttr, Fixture, methodCreateDateAttrPrametersTypes);

            // Assert
            methodCreateDateAttrPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateDateAttr) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_CreateDateAttr_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateDateAttr, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (XmlToJSONnode) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_XmlToJSONnode_Method_Call_Internally(Type[] types)
        {
            var methodXmlToJSONnodePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodXmlToJSONnode, Fixture, methodXmlToJSONnodePrametersTypes);
        }

        #endregion

        #region Method Call : (XmlToJSONnode) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_XmlToJSONnode_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sbJSON = CreateType<StringBuilder>();
            var node = CreateType<XmlElement>();
            var showNodeName = CreateType<bool>();
            var methodXmlToJSONnodePrametersTypes = new Type[] { typeof(StringBuilder), typeof(XmlElement), typeof(bool) };
            object[] parametersOfXmlToJSONnode = { sbJSON, node, showNodeName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodXmlToJSONnode, methodXmlToJSONnodePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfXmlToJSONnode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfXmlToJSONnode.ShouldNotBeNull();
            parametersOfXmlToJSONnode.Length.ShouldBe(3);
            methodXmlToJSONnodePrametersTypes.Length.ShouldBe(3);
            methodXmlToJSONnodePrametersTypes.Length.ShouldBe(parametersOfXmlToJSONnode.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (XmlToJSONnode) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_XmlToJSONnode_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sbJSON = CreateType<StringBuilder>();
            var node = CreateType<XmlElement>();
            var showNodeName = CreateType<bool>();
            var methodXmlToJSONnodePrametersTypes = new Type[] { typeof(StringBuilder), typeof(XmlElement), typeof(bool) };
            object[] parametersOfXmlToJSONnode = { sbJSON, node, showNodeName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodXmlToJSONnode, methodXmlToJSONnodePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfXmlToJSONnode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfXmlToJSONnode.ShouldNotBeNull();
            parametersOfXmlToJSONnode.Length.ShouldBe(3);
            methodXmlToJSONnodePrametersTypes.Length.ShouldBe(3);
            methodXmlToJSONnodePrametersTypes.Length.ShouldBe(parametersOfXmlToJSONnode.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (XmlToJSONnode) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_XmlToJSONnode_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sbJSON = CreateType<StringBuilder>();
            var node = CreateType<XmlElement>();
            var showNodeName = CreateType<bool>();
            var methodXmlToJSONnodePrametersTypes = new Type[] { typeof(StringBuilder), typeof(XmlElement), typeof(bool) };
            object[] parametersOfXmlToJSONnode = { sbJSON, node, showNodeName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cStructInstance, MethodXmlToJSONnode, parametersOfXmlToJSONnode, methodXmlToJSONnodePrametersTypes);

            // Assert
            parametersOfXmlToJSONnode.ShouldNotBeNull();
            parametersOfXmlToJSONnode.Length.ShouldBe(3);
            methodXmlToJSONnodePrametersTypes.Length.ShouldBe(3);
            methodXmlToJSONnodePrametersTypes.Length.ShouldBe(parametersOfXmlToJSONnode.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (XmlToJSONnode) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_XmlToJSONnode_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodXmlToJSONnode, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (XmlToJSONnode) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_XmlToJSONnode_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodXmlToJSONnodePrametersTypes = new Type[] { typeof(StringBuilder), typeof(XmlElement), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodXmlToJSONnode, Fixture, methodXmlToJSONnodePrametersTypes);

            // Assert
            methodXmlToJSONnodePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (XmlToJSONnode) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_XmlToJSONnode_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodXmlToJSONnode, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StoreChildNode) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_StoreChildNode_Method_Call_Internally(Type[] types)
        {
            var methodStoreChildNodePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodStoreChildNode, Fixture, methodStoreChildNodePrametersTypes);
        }

        #endregion

        #region Method Call : (StoreChildNode) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_StoreChildNode_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var childNodeNames = CreateType<SortedList>();
            var nodeName = CreateType<string>();
            var nodeValue = CreateType<object>();
            var methodStoreChildNodePrametersTypes = new Type[] { typeof(SortedList), typeof(string), typeof(object) };
            object[] parametersOfStoreChildNode = { childNodeNames, nodeName, nodeValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodStoreChildNode, methodStoreChildNodePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfStoreChildNode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfStoreChildNode.ShouldNotBeNull();
            parametersOfStoreChildNode.Length.ShouldBe(3);
            methodStoreChildNodePrametersTypes.Length.ShouldBe(3);
            methodStoreChildNodePrametersTypes.Length.ShouldBe(parametersOfStoreChildNode.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (StoreChildNode) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_StoreChildNode_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var childNodeNames = CreateType<SortedList>();
            var nodeName = CreateType<string>();
            var nodeValue = CreateType<object>();
            var methodStoreChildNodePrametersTypes = new Type[] { typeof(SortedList), typeof(string), typeof(object) };
            object[] parametersOfStoreChildNode = { childNodeNames, nodeName, nodeValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodStoreChildNode, methodStoreChildNodePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfStoreChildNode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfStoreChildNode.ShouldNotBeNull();
            parametersOfStoreChildNode.Length.ShouldBe(3);
            methodStoreChildNodePrametersTypes.Length.ShouldBe(3);
            methodStoreChildNodePrametersTypes.Length.ShouldBe(parametersOfStoreChildNode.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StoreChildNode) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_StoreChildNode_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var childNodeNames = CreateType<SortedList>();
            var nodeName = CreateType<string>();
            var nodeValue = CreateType<object>();
            var methodStoreChildNodePrametersTypes = new Type[] { typeof(SortedList), typeof(string), typeof(object) };
            object[] parametersOfStoreChildNode = { childNodeNames, nodeName, nodeValue };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cStructInstance, MethodStoreChildNode, parametersOfStoreChildNode, methodStoreChildNodePrametersTypes);

            // Assert
            parametersOfStoreChildNode.ShouldNotBeNull();
            parametersOfStoreChildNode.Length.ShouldBe(3);
            methodStoreChildNodePrametersTypes.Length.ShouldBe(3);
            methodStoreChildNodePrametersTypes.Length.ShouldBe(parametersOfStoreChildNode.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StoreChildNode) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_StoreChildNode_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodStoreChildNode, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (StoreChildNode) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_StoreChildNode_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodStoreChildNodePrametersTypes = new Type[] { typeof(SortedList), typeof(string), typeof(object) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodStoreChildNode, Fixture, methodStoreChildNodePrametersTypes);

            // Assert
            methodStoreChildNodePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StoreChildNode) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_StoreChildNode_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodStoreChildNode, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OutputNode) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_OutputNode_Method_Call_Internally(Type[] types)
        {
            var methodOutputNodePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodOutputNode, Fixture, methodOutputNodePrametersTypes);
        }

        #endregion

        #region Method Call : (OutputNode) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_OutputNode_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var childname = CreateType<string>();
            var alChild = CreateType<object>();
            var sbJSON = CreateType<StringBuilder>();
            var showNodeName = CreateType<bool>();
            var methodOutputNodePrametersTypes = new Type[] { typeof(string), typeof(object), typeof(StringBuilder), typeof(bool) };
            object[] parametersOfOutputNode = { childname, alChild, sbJSON, showNodeName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOutputNode, methodOutputNodePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfOutputNode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOutputNode.ShouldNotBeNull();
            parametersOfOutputNode.Length.ShouldBe(4);
            methodOutputNodePrametersTypes.Length.ShouldBe(4);
            methodOutputNodePrametersTypes.Length.ShouldBe(parametersOfOutputNode.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (OutputNode) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_OutputNode_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var childname = CreateType<string>();
            var alChild = CreateType<object>();
            var sbJSON = CreateType<StringBuilder>();
            var showNodeName = CreateType<bool>();
            var methodOutputNodePrametersTypes = new Type[] { typeof(string), typeof(object), typeof(StringBuilder), typeof(bool) };
            object[] parametersOfOutputNode = { childname, alChild, sbJSON, showNodeName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOutputNode, methodOutputNodePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfOutputNode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOutputNode.ShouldNotBeNull();
            parametersOfOutputNode.Length.ShouldBe(4);
            methodOutputNodePrametersTypes.Length.ShouldBe(4);
            methodOutputNodePrametersTypes.Length.ShouldBe(parametersOfOutputNode.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OutputNode) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_OutputNode_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var childname = CreateType<string>();
            var alChild = CreateType<object>();
            var sbJSON = CreateType<StringBuilder>();
            var showNodeName = CreateType<bool>();
            var methodOutputNodePrametersTypes = new Type[] { typeof(string), typeof(object), typeof(StringBuilder), typeof(bool) };
            object[] parametersOfOutputNode = { childname, alChild, sbJSON, showNodeName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cStructInstance, MethodOutputNode, parametersOfOutputNode, methodOutputNodePrametersTypes);

            // Assert
            parametersOfOutputNode.ShouldNotBeNull();
            parametersOfOutputNode.Length.ShouldBe(4);
            methodOutputNodePrametersTypes.Length.ShouldBe(4);
            methodOutputNodePrametersTypes.Length.ShouldBe(parametersOfOutputNode.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OutputNode) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_OutputNode_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOutputNode, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OutputNode) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_OutputNode_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOutputNodePrametersTypes = new Type[] { typeof(string), typeof(object), typeof(StringBuilder), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodOutputNode, Fixture, methodOutputNodePrametersTypes);

            // Assert
            methodOutputNodePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OutputNode) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_OutputNode_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOutputNode, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SafeJSON) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CStruct_SafeJSON_Method_Call_Internally(Type[] types)
        {
            var methodSafeJSONPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodSafeJSON, Fixture, methodSafeJSONPrametersTypes);
        }

        #endregion

        #region Method Call : (SafeJSON) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_SafeJSON_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sIn = CreateType<string>();
            var methodSafeJSONPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSafeJSON = { sIn };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSafeJSON, methodSafeJSONPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, string>(_cStructInstanceFixture, out exception1, parametersOfSafeJSON);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, string>(_cStructInstance, MethodSafeJSON, parametersOfSafeJSON, methodSafeJSONPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSafeJSON.ShouldNotBeNull();
            parametersOfSafeJSON.Length.ShouldBe(1);
            methodSafeJSONPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SafeJSON) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_SafeJSON_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sIn = CreateType<string>();
            var methodSafeJSONPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSafeJSON = { sIn };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSafeJSON, methodSafeJSONPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CStruct, string>(_cStructInstanceFixture, out exception1, parametersOfSafeJSON);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CStruct, string>(_cStructInstance, MethodSafeJSON, parametersOfSafeJSON, methodSafeJSONPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSafeJSON.ShouldNotBeNull();
            parametersOfSafeJSON.Length.ShouldBe(1);
            methodSafeJSONPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SafeJSON) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_SafeJSON_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sIn = CreateType<string>();
            var methodSafeJSONPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSafeJSON = { sIn };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSafeJSON, methodSafeJSONPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cStructInstanceFixture, parametersOfSafeJSON);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSafeJSON.ShouldNotBeNull();
            parametersOfSafeJSON.Length.ShouldBe(1);
            methodSafeJSONPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SafeJSON) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_SafeJSON_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sIn = CreateType<string>();
            var methodSafeJSONPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSafeJSON = { sIn };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CStruct, string>(_cStructInstance, MethodSafeJSON, parametersOfSafeJSON, methodSafeJSONPrametersTypes);

            // Assert
            parametersOfSafeJSON.ShouldNotBeNull();
            parametersOfSafeJSON.Length.ShouldBe(1);
            methodSafeJSONPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SafeJSON) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_SafeJSON_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSafeJSONPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodSafeJSON, Fixture, methodSafeJSONPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSafeJSONPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SafeJSON) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_SafeJSON_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodSafeJSONPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodSafeJSON, Fixture, methodSafeJSONPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodSafeJSONPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SafeJSON) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_SafeJSON_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSafeJSONPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cStructInstance, MethodSafeJSON, Fixture, methodSafeJSONPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSafeJSONPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SafeJSON) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_SafeJSON_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSafeJSON, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (SafeJSON) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_SafeJSON_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSafeJSON, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cStructInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SafeJSON) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CStruct_SafeJSON_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSafeJSON, 0);
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
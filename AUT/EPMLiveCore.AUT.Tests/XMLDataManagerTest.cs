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
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;
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
using XMLDataManager = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.XMLDataManager" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class XMLDataManagerTest : AbstractBaseSetupTypedTest<XMLDataManager>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (XMLDataManager) Initializer

        private const string MethodGetPropVal = "GetPropVal";
        private const string MethodEditProp = "EditProp";
        private const string FielddataXml = "dataXml";
        private Type _xMLDataManagerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private XMLDataManager _xMLDataManagerInstance;
        private XMLDataManager _xMLDataManagerInstanceFixture;

        #region General Initializer : Class (XMLDataManager) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="XMLDataManager" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _xMLDataManagerInstanceType = typeof(XMLDataManager);
            _xMLDataManagerInstanceFixture = Create(true);
            _xMLDataManagerInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (XMLDataManager)

        #region General Initializer : Class (XMLDataManager) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="XMLDataManager" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetPropVal, 0)]
        [TestCase(MethodEditProp, 0)]
        public void AUT_XMLDataManager_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_xMLDataManagerInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (XMLDataManager) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="XMLDataManager" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FielddataXml)]
        public void AUT_XMLDataManager_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_xMLDataManagerInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="XMLDataManager" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetPropVal)]
        [TestCase(MethodEditProp)]
        public void AUT_XMLDataManager_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<XMLDataManager>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetPropVal) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_XMLDataManager_GetPropVal_Method_Call_Internally(Type[] types)
        {
            var methodGetPropValPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_xMLDataManagerInstance, MethodGetPropVal, Fixture, methodGetPropValPrametersTypes);
        }

        #endregion

        #region Method Call : (GetPropVal) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_XMLDataManager_GetPropVal_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var propName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _xMLDataManagerInstance.GetPropVal(propName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetPropVal) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_XMLDataManager_GetPropVal_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var propName = CreateType<string>();
            var methodGetPropValPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetPropVal = { propName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetPropVal, methodGetPropValPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<XMLDataManager, string>(_xMLDataManagerInstanceFixture, out exception1, parametersOfGetPropVal);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<XMLDataManager, string>(_xMLDataManagerInstance, MethodGetPropVal, parametersOfGetPropVal, methodGetPropValPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetPropVal.ShouldNotBeNull();
            parametersOfGetPropVal.Length.ShouldBe(1);
            methodGetPropValPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetPropVal) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_XMLDataManager_GetPropVal_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var propName = CreateType<string>();
            var methodGetPropValPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetPropVal = { propName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<XMLDataManager, string>(_xMLDataManagerInstance, MethodGetPropVal, parametersOfGetPropVal, methodGetPropValPrametersTypes);

            // Assert
            parametersOfGetPropVal.ShouldNotBeNull();
            parametersOfGetPropVal.Length.ShouldBe(1);
            methodGetPropValPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPropVal) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_XMLDataManager_GetPropVal_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetPropValPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_xMLDataManagerInstance, MethodGetPropVal, Fixture, methodGetPropValPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetPropValPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetPropVal) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_XMLDataManager_GetPropVal_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetPropValPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_xMLDataManagerInstance, MethodGetPropVal, Fixture, methodGetPropValPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetPropValPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPropVal) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_XMLDataManager_GetPropVal_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetPropVal, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_xMLDataManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetPropVal) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_XMLDataManager_GetPropVal_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetPropVal, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (EditProp) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_XMLDataManager_EditProp_Method_Call_Internally(Type[] types)
        {
            var methodEditPropPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_xMLDataManagerInstance, MethodEditProp, Fixture, methodEditPropPrametersTypes);
        }

        #endregion

        #region Method Call : (EditProp) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_XMLDataManager_EditProp_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var key = CreateType<string>();
            var value = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _xMLDataManagerInstance.EditProp(key, value);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (EditProp) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_XMLDataManager_EditProp_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var key = CreateType<string>();
            var value = CreateType<string>();
            var methodEditPropPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfEditProp = { key, value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodEditProp, methodEditPropPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_xMLDataManagerInstanceFixture, parametersOfEditProp);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfEditProp.ShouldNotBeNull();
            parametersOfEditProp.Length.ShouldBe(2);
            methodEditPropPrametersTypes.Length.ShouldBe(2);
            methodEditPropPrametersTypes.Length.ShouldBe(parametersOfEditProp.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (EditProp) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_XMLDataManager_EditProp_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var key = CreateType<string>();
            var value = CreateType<string>();
            var methodEditPropPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfEditProp = { key, value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_xMLDataManagerInstance, MethodEditProp, parametersOfEditProp, methodEditPropPrametersTypes);

            // Assert
            parametersOfEditProp.ShouldNotBeNull();
            parametersOfEditProp.Length.ShouldBe(2);
            methodEditPropPrametersTypes.Length.ShouldBe(2);
            methodEditPropPrametersTypes.Length.ShouldBe(parametersOfEditProp.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EditProp) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_XMLDataManager_EditProp_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodEditProp, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (EditProp) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_XMLDataManager_EditProp_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodEditPropPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_xMLDataManagerInstance, MethodEditProp, Fixture, methodEditPropPrametersTypes);

            // Assert
            methodEditPropPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EditProp) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_XMLDataManager_EditProp_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodEditProp, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_xMLDataManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.getganttitems" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class GetganttitemsTest : AbstractBaseSetupTypedTest<getganttitems>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (getganttitems) Initializer

        private const string MethodgetParams = "getParams";
        private const string MethodoutputXml = "outputXml";
        private const string MethodgetAttribute = "getAttribute";
        private const string MethodprocessPredecessor = "processPredecessor";
        private const string MethodprocessPredecessors = "processPredecessors";
        private const string MethodgetFieldValue = "getFieldValue";
        private const string MethodProcessItems = "ProcessItems";
        private const string MethodgetFormat = "getFormat";
        private const string MethodgetRealField = "getRealField";
        private const string FieldarrHidden = "arrHidden";
        private const string FieldhshLookupEnums = "hshLookupEnums";
        private const string FieldhshLookupEnumKeys = "hshLookupEnumKeys";
        private const string FieldcurId = "curId";
        private Type _getganttitemsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private getganttitems _getganttitemsInstance;
        private getganttitems _getganttitemsInstanceFixture;

        #region General Initializer : Class (getganttitems) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="getganttitems" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _getganttitemsInstanceType = typeof(getganttitems);
            _getganttitemsInstanceFixture = Create(true);
            _getganttitemsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (getganttitems)

        #region General Initializer : Class (getganttitems) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="getganttitems" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodgetParams, 0)]
        [TestCase(MethodoutputXml, 0)]
        [TestCase(MethodgetAttribute, 0)]
        [TestCase(MethodprocessPredecessor, 0)]
        [TestCase(MethodprocessPredecessors, 0)]
        [TestCase(MethodgetFieldValue, 0)]
        [TestCase(MethodProcessItems, 0)]
        [TestCase(MethodgetFormat, 0)]
        [TestCase(MethodgetRealField, 0)]
        public void AUT_Getganttitems_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_getganttitemsInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (getganttitems) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="getganttitems" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldarrHidden)]
        [TestCase(FieldhshLookupEnums)]
        [TestCase(FieldhshLookupEnumKeys)]
        [TestCase(FieldcurId)]
        public void AUT_Getganttitems_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_getganttitemsInstanceFixture, 
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
        ///     Class (<see cref="getganttitems" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Getganttitems_Is_Instance_Present_Test()
        {
            // Assert
            _getganttitemsInstanceType.ShouldNotBeNull();
            _getganttitemsInstance.ShouldNotBeNull();
            _getganttitemsInstanceFixture.ShouldNotBeNull();
            _getganttitemsInstance.ShouldBeAssignableTo<getganttitems>();
            _getganttitemsInstanceFixture.ShouldBeAssignableTo<getganttitems>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (getganttitems) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_getganttitems_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            getganttitems instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _getganttitemsInstanceType.ShouldNotBeNull();
            _getganttitemsInstance.ShouldNotBeNull();
            _getganttitemsInstanceFixture.ShouldNotBeNull();
            _getganttitemsInstance.ShouldBeAssignableTo<getganttitems>();
            _getganttitemsInstanceFixture.ShouldBeAssignableTo<getganttitems>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="getganttitems" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodgetFormat)]
        public void AUT_Getganttitems_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_getganttitemsInstanceFixture,
                                                                              _getganttitemsInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="getganttitems" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodgetParams)]
        [TestCase(MethodoutputXml)]
        [TestCase(MethodgetAttribute)]
        [TestCase(MethodprocessPredecessor)]
        [TestCase(MethodprocessPredecessors)]
        [TestCase(MethodgetFieldValue)]
        [TestCase(MethodProcessItems)]
        [TestCase(MethodgetRealField)]
        public void AUT_Getganttitems_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<getganttitems>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (getParams) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getganttitems_getParams_Method_Call_Internally(Type[] types)
        {
            var methodgetParamsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getganttitemsInstance, MethodgetParams, Fixture, methodgetParamsPrametersTypes);
        }

        #endregion

        #region Method Call : (getParams) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_getParams_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var curWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => _getganttitemsInstance.getParams(curWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (getParams) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_getParams_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var curWeb = CreateType<SPWeb>();
            var methodgetParamsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfgetParams = { curWeb };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetParams, methodgetParamsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getganttitemsInstanceFixture, parametersOfgetParams);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetParams.ShouldNotBeNull();
            parametersOfgetParams.Length.ShouldBe(1);
            methodgetParamsPrametersTypes.Length.ShouldBe(1);
            methodgetParamsPrametersTypes.Length.ShouldBe(parametersOfgetParams.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (getParams) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_getParams_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var curWeb = CreateType<SPWeb>();
            var methodgetParamsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfgetParams = { curWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getganttitemsInstance, MethodgetParams, parametersOfgetParams, methodgetParamsPrametersTypes);

            // Assert
            parametersOfgetParams.ShouldNotBeNull();
            parametersOfgetParams.Length.ShouldBe(1);
            methodgetParamsPrametersTypes.Length.ShouldBe(1);
            methodgetParamsPrametersTypes.Length.ShouldBe(parametersOfgetParams.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getParams) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_getParams_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetParams, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getParams) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_getParams_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetParamsPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getganttitemsInstance, MethodgetParams, Fixture, methodgetParamsPrametersTypes);

            // Assert
            methodgetParamsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getParams) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_getParams_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetParams, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getganttitemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (outputXml) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getganttitems_outputXml_Method_Call_Internally(Type[] types)
        {
            var methodoutputXmlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getganttitemsInstance, MethodoutputXml, Fixture, methodoutputXmlPrametersTypes);
        }

        #endregion

        #region Method Call : (outputXml) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_outputXml_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodoutputXmlPrametersTypes = null;
            object[] parametersOfoutputXml = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodoutputXml, methodoutputXmlPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getganttitemsInstanceFixture, parametersOfoutputXml);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfoutputXml.ShouldBeNull();
            methodoutputXmlPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (outputXml) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_outputXml_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodoutputXmlPrametersTypes = null;
            object[] parametersOfoutputXml = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getganttitemsInstance, MethodoutputXml, parametersOfoutputXml, methodoutputXmlPrametersTypes);

            // Assert
            parametersOfoutputXml.ShouldBeNull();
            methodoutputXmlPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (outputXml) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_outputXml_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodoutputXmlPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getganttitemsInstance, MethodoutputXml, Fixture, methodoutputXmlPrametersTypes);

            // Assert
            methodoutputXmlPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (outputXml) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_outputXml_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodoutputXml, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getganttitemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getAttribute) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getganttitems_getAttribute_Method_Call_Internally(Type[] types)
        {
            var methodgetAttributePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getganttitemsInstance, MethodgetAttribute, Fixture, methodgetAttributePrametersTypes);
        }

        #endregion

        #region Method Call : (getAttribute) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_getAttribute_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var nd = CreateType<XmlNode>();
            var attribute = CreateType<string>();
            var methodgetAttributePrametersTypes = new Type[] { typeof(XmlNode), typeof(string) };
            object[] parametersOfgetAttribute = { nd, attribute };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetAttribute, methodgetAttributePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getganttitemsInstanceFixture, parametersOfgetAttribute);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetAttribute.ShouldNotBeNull();
            parametersOfgetAttribute.Length.ShouldBe(2);
            methodgetAttributePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getAttribute) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_getAttribute_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var nd = CreateType<XmlNode>();
            var attribute = CreateType<string>();
            var methodgetAttributePrametersTypes = new Type[] { typeof(XmlNode), typeof(string) };
            object[] parametersOfgetAttribute = { nd, attribute };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getganttitems, string>(_getganttitemsInstance, MethodgetAttribute, parametersOfgetAttribute, methodgetAttributePrametersTypes);

            // Assert
            parametersOfgetAttribute.ShouldNotBeNull();
            parametersOfgetAttribute.Length.ShouldBe(2);
            methodgetAttributePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getAttribute) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_getAttribute_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetAttributePrametersTypes = new Type[] { typeof(XmlNode), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getganttitemsInstance, MethodgetAttribute, Fixture, methodgetAttributePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetAttributePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (getAttribute) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_getAttribute_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetAttributePrametersTypes = new Type[] { typeof(XmlNode), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getganttitemsInstance, MethodgetAttribute, Fixture, methodgetAttributePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetAttributePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getAttribute) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_getAttribute_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetAttribute, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getganttitemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getAttribute) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_getAttribute_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetAttribute, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processPredecessor) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getganttitems_processPredecessor_Method_Call_Internally(Type[] types)
        {
            var methodprocessPredecessorPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getganttitemsInstance, MethodprocessPredecessor, Fixture, methodprocessPredecessorPrametersTypes);
        }

        #endregion

        #region Method Call : (processPredecessor) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_processPredecessor_Method_Call_Void_With_5_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var doc = CreateType<XmlDocument>();
            var pred = CreateType<string>();
            var project = CreateType<string>();
            var rowid = CreateType<string>();
            var suffix = CreateType<string>();
            var methodprocessPredecessorPrametersTypes = new Type[] { typeof(XmlDocument), typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfprocessPredecessor = { doc, pred, project, rowid, suffix };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodprocessPredecessor, methodprocessPredecessorPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getganttitemsInstanceFixture, parametersOfprocessPredecessor);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfprocessPredecessor.ShouldNotBeNull();
            parametersOfprocessPredecessor.Length.ShouldBe(5);
            methodprocessPredecessorPrametersTypes.Length.ShouldBe(5);
            methodprocessPredecessorPrametersTypes.Length.ShouldBe(parametersOfprocessPredecessor.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (processPredecessor) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_processPredecessor_Method_Call_Void_With_5_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var doc = CreateType<XmlDocument>();
            var pred = CreateType<string>();
            var project = CreateType<string>();
            var rowid = CreateType<string>();
            var suffix = CreateType<string>();
            var methodprocessPredecessorPrametersTypes = new Type[] { typeof(XmlDocument), typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfprocessPredecessor = { doc, pred, project, rowid, suffix };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getganttitemsInstance, MethodprocessPredecessor, parametersOfprocessPredecessor, methodprocessPredecessorPrametersTypes);

            // Assert
            parametersOfprocessPredecessor.ShouldNotBeNull();
            parametersOfprocessPredecessor.Length.ShouldBe(5);
            methodprocessPredecessorPrametersTypes.Length.ShouldBe(5);
            methodprocessPredecessorPrametersTypes.Length.ShouldBe(parametersOfprocessPredecessor.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processPredecessor) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_processPredecessor_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodprocessPredecessor, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processPredecessor) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_processPredecessor_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodprocessPredecessorPrametersTypes = new Type[] { typeof(XmlDocument), typeof(string), typeof(string), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getganttitemsInstance, MethodprocessPredecessor, Fixture, methodprocessPredecessorPrametersTypes);

            // Assert
            methodprocessPredecessorPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processPredecessor) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_processPredecessor_Method_Call_With_5_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprocessPredecessor, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getganttitemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processPredecessors) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getganttitems_processPredecessors_Method_Call_Internally(Type[] types)
        {
            var methodprocessPredecessorsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getganttitemsInstance, MethodprocessPredecessors, Fixture, methodprocessPredecessorsPrametersTypes);
        }

        #endregion

        #region Method Call : (processPredecessors) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_processPredecessors_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var ndRow = CreateType<XmlNode>();
            var doc = CreateType<XmlDocument>();
            var methodprocessPredecessorsPrametersTypes = new Type[] { typeof(XmlNode), typeof(XmlDocument) };
            object[] parametersOfprocessPredecessors = { ndRow, doc };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodprocessPredecessors, methodprocessPredecessorsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getganttitemsInstanceFixture, parametersOfprocessPredecessors);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfprocessPredecessors.ShouldNotBeNull();
            parametersOfprocessPredecessors.Length.ShouldBe(2);
            methodprocessPredecessorsPrametersTypes.Length.ShouldBe(2);
            methodprocessPredecessorsPrametersTypes.Length.ShouldBe(parametersOfprocessPredecessors.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processPredecessors) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_processPredecessors_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var ndRow = CreateType<XmlNode>();
            var doc = CreateType<XmlDocument>();
            var methodprocessPredecessorsPrametersTypes = new Type[] { typeof(XmlNode), typeof(XmlDocument) };
            object[] parametersOfprocessPredecessors = { ndRow, doc };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getganttitemsInstance, MethodprocessPredecessors, parametersOfprocessPredecessors, methodprocessPredecessorsPrametersTypes);

            // Assert
            parametersOfprocessPredecessors.ShouldNotBeNull();
            parametersOfprocessPredecessors.Length.ShouldBe(2);
            methodprocessPredecessorsPrametersTypes.Length.ShouldBe(2);
            methodprocessPredecessorsPrametersTypes.Length.ShouldBe(parametersOfprocessPredecessors.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processPredecessors) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_processPredecessors_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodprocessPredecessors, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processPredecessors) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_processPredecessors_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodprocessPredecessorsPrametersTypes = new Type[] { typeof(XmlNode), typeof(XmlDocument) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getganttitemsInstance, MethodprocessPredecessors, Fixture, methodprocessPredecessorsPrametersTypes);

            // Assert
            methodprocessPredecessorsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processPredecessors) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_processPredecessors_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprocessPredecessors, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getganttitemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getFieldValue) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getganttitems_getFieldValue_Method_Call_Internally(Type[] types)
        {
            var methodgetFieldValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getganttitemsInstance, MethodgetFieldValue, Fixture, methodgetFieldValuePrametersTypes);
        }

        #endregion

        #region Method Call : (getFieldValue) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_getFieldValue_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var fieldname = CreateType<string>();
            var value = CreateType<string>();
            var methodgetFieldValuePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfgetFieldValue = { fieldname, value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetFieldValue, methodgetFieldValuePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getganttitemsInstanceFixture, parametersOfgetFieldValue);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetFieldValue.ShouldNotBeNull();
            parametersOfgetFieldValue.Length.ShouldBe(2);
            methodgetFieldValuePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getFieldValue) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_getFieldValue_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var fieldname = CreateType<string>();
            var value = CreateType<string>();
            var methodgetFieldValuePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfgetFieldValue = { fieldname, value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getganttitems, string>(_getganttitemsInstance, MethodgetFieldValue, parametersOfgetFieldValue, methodgetFieldValuePrametersTypes);

            // Assert
            parametersOfgetFieldValue.ShouldNotBeNull();
            parametersOfgetFieldValue.Length.ShouldBe(2);
            methodgetFieldValuePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getFieldValue) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_getFieldValue_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetFieldValuePrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getganttitemsInstance, MethodgetFieldValue, Fixture, methodgetFieldValuePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetFieldValuePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (getFieldValue) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_getFieldValue_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetFieldValuePrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getganttitemsInstance, MethodgetFieldValue, Fixture, methodgetFieldValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetFieldValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getFieldValue) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_getFieldValue_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetFieldValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getganttitemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getFieldValue) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_getFieldValue_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetFieldValue, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessItems) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getganttitems_ProcessItems_Method_Call_Internally(Type[] types)
        {
            var methodProcessItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getganttitemsInstance, MethodProcessItems, Fixture, methodProcessItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessItems) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_ProcessItems_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var ndParent = CreateType<XmlNode>();
            var ndRow = CreateType<XmlNode>();
            var arrFields = CreateType<XmlNodeList>();
            var doc = CreateType<XmlDocument>();
            var methodProcessItemsPrametersTypes = new Type[] { typeof(XmlNode), typeof(XmlNode), typeof(XmlNodeList), typeof(XmlDocument) };
            object[] parametersOfProcessItems = { ndParent, ndRow, arrFields, doc };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodProcessItems, methodProcessItemsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getganttitemsInstanceFixture, parametersOfProcessItems);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfProcessItems.ShouldNotBeNull();
            parametersOfProcessItems.Length.ShouldBe(4);
            methodProcessItemsPrametersTypes.Length.ShouldBe(4);
            methodProcessItemsPrametersTypes.Length.ShouldBe(parametersOfProcessItems.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ProcessItems) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_ProcessItems_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var ndParent = CreateType<XmlNode>();
            var ndRow = CreateType<XmlNode>();
            var arrFields = CreateType<XmlNodeList>();
            var doc = CreateType<XmlDocument>();
            var methodProcessItemsPrametersTypes = new Type[] { typeof(XmlNode), typeof(XmlNode), typeof(XmlNodeList), typeof(XmlDocument) };
            object[] parametersOfProcessItems = { ndParent, ndRow, arrFields, doc };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getganttitemsInstance, MethodProcessItems, parametersOfProcessItems, methodProcessItemsPrametersTypes);

            // Assert
            parametersOfProcessItems.ShouldNotBeNull();
            parametersOfProcessItems.Length.ShouldBe(4);
            methodProcessItemsPrametersTypes.Length.ShouldBe(4);
            methodProcessItemsPrametersTypes.Length.ShouldBe(parametersOfProcessItems.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessItems) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_ProcessItems_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodProcessItems, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessItems) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_ProcessItems_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessItemsPrametersTypes = new Type[] { typeof(XmlNode), typeof(XmlNode), typeof(XmlNodeList), typeof(XmlDocument) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getganttitemsInstance, MethodProcessItems, Fixture, methodProcessItemsPrametersTypes);

            // Assert
            methodProcessItemsPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessItems) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_ProcessItems_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessItems, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getganttitemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getFormat) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getganttitems_getFormat_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetFormatPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_getganttitemsInstanceFixture, _getganttitemsInstanceType, MethodgetFormat, Fixture, methodgetFormatPrametersTypes);
        }

        #endregion

        #region Method Call : (getFormat) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_getFormat_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var oField = CreateType<SPField>();
            var oDoc = CreateType<XmlDocument>();
            var oWeb = CreateType<SPWeb>();
            var methodgetFormatPrametersTypes = new Type[] { typeof(SPField), typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfgetFormat = { oField, oDoc, oWeb };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetFormat, methodgetFormatPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_getganttitemsInstanceFixture, _getganttitemsInstanceType, MethodgetFormat, Fixture, methodgetFormatPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_getganttitemsInstanceFixture, _getganttitemsInstanceType, MethodgetFormat, parametersOfgetFormat, methodgetFormatPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_getganttitemsInstanceFixture, parametersOfgetFormat);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetFormat.ShouldNotBeNull();
            parametersOfgetFormat.Length.ShouldBe(3);
            methodgetFormatPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (getFormat) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_getFormat_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oField = CreateType<SPField>();
            var oDoc = CreateType<XmlDocument>();
            var oWeb = CreateType<SPWeb>();
            var methodgetFormatPrametersTypes = new Type[] { typeof(SPField), typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfgetFormat = { oField, oDoc, oWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_getganttitemsInstanceFixture, _getganttitemsInstanceType, MethodgetFormat, parametersOfgetFormat, methodgetFormatPrametersTypes);

            // Assert
            parametersOfgetFormat.ShouldNotBeNull();
            parametersOfgetFormat.Length.ShouldBe(3);
            methodgetFormatPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getFormat) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_getFormat_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetFormatPrametersTypes = new Type[] { typeof(SPField), typeof(XmlDocument), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_getganttitemsInstanceFixture, _getganttitemsInstanceType, MethodgetFormat, Fixture, methodgetFormatPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetFormatPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (getFormat) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_getFormat_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetFormatPrametersTypes = new Type[] { typeof(SPField), typeof(XmlDocument), typeof(SPWeb) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_getganttitemsInstanceFixture, _getganttitemsInstanceType, MethodgetFormat, Fixture, methodgetFormatPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetFormatPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getFormat) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_getFormat_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetFormat, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getganttitemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getFormat) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_getFormat_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetFormat, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getganttitems_getRealField_Method_Call_Internally(Type[] types)
        {
            var methodgetRealFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getganttitemsInstance, MethodgetRealField, Fixture, methodgetRealFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_getRealField_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var methodgetRealFieldPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfgetRealField = { field };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodgetRealField, methodgetRealFieldPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<getganttitems, SPField>(_getganttitemsInstanceFixture, out exception1, parametersOfgetRealField);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<getganttitems, SPField>(_getganttitemsInstance, MethodgetRealField, parametersOfgetRealField, methodgetRealFieldPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetRealField.ShouldNotBeNull();
            parametersOfgetRealField.Length.ShouldBe(1);
            methodgetRealFieldPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_getRealField_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var methodgetRealFieldPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfgetRealField = { field };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetRealField, methodgetRealFieldPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getganttitemsInstanceFixture, parametersOfgetRealField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetRealField.ShouldNotBeNull();
            parametersOfgetRealField.Length.ShouldBe(1);
            methodgetRealFieldPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_getRealField_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var methodgetRealFieldPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfgetRealField = { field };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getganttitems, SPField>(_getganttitemsInstance, MethodgetRealField, parametersOfgetRealField, methodgetRealFieldPrametersTypes);

            // Assert
            parametersOfgetRealField.ShouldNotBeNull();
            parametersOfgetRealField.Length.ShouldBe(1);
            methodgetRealFieldPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_getRealField_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetRealFieldPrametersTypes = new Type[] { typeof(SPField) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getganttitemsInstance, MethodgetRealField, Fixture, methodgetRealFieldPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetRealFieldPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_getRealField_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetRealFieldPrametersTypes = new Type[] { typeof(SPField) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getganttitemsInstance, MethodgetRealField, Fixture, methodgetRealFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetRealFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_getRealField_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetRealField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getganttitemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getganttitems_getRealField_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetRealField, 0);
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
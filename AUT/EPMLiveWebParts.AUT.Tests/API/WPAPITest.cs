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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.WPAPI" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class WPAPITest : AbstractBaseSetupTypedTest<WPAPI>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WPAPI) Initializer

        private const string MethodGetGrid = "GetGrid";
        private const string MethodGetGridRow = "GetGridRow";
        private const string MethodiGetGridRow = "iGetGridRow";
        private const string MethodSetGridRowEdit = "SetGridRowEdit";
        private const string MethodiGetRowValue = "iGetRowValue";
        private const string MethodGetHasComments = "GetHasComments";
        private const string MethodiSetGridRowEdit = "iSetGridRowEdit";
        private const string MethodGetGridRowEdit = "GetGridRowEdit";
        private const string MethodiGetGridRowEdit = "iGetGridRowEdit";
        private const string MethodGetFieldType = "GetFieldType";
        private const string MethodGetExampleDateFormat = "GetExampleDateFormat";
        private const string MethodValidEditCol = "ValidEditCol";
        private const string MethodGetCellValue = "GetCellValue";
        private Type _wPAPIInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private WPAPI _wPAPIInstance;
        private WPAPI _wPAPIInstanceFixture;

        #region General Initializer : Class (WPAPI) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WPAPI" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _wPAPIInstanceType = typeof(WPAPI);
            _wPAPIInstanceFixture = Create(true);
            _wPAPIInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WPAPI)

        #region General Initializer : Class (WPAPI) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="WPAPI" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetGrid, 0)]
        [TestCase(MethodGetGridRow, 0)]
        [TestCase(MethodiGetGridRow, 0)]
        [TestCase(MethodSetGridRowEdit, 0)]
        [TestCase(MethodiGetRowValue, 0)]
        [TestCase(MethodGetHasComments, 0)]
        [TestCase(MethodiSetGridRowEdit, 0)]
        [TestCase(MethodGetGridRowEdit, 0)]
        [TestCase(MethodiGetGridRowEdit, 0)]
        [TestCase(MethodGetFieldType, 0)]
        [TestCase(MethodGetExampleDateFormat, 0)]
        [TestCase(MethodValidEditCol, 0)]
        [TestCase(MethodGetCellValue, 0)]
        public void AUT_WPAPI_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_wPAPIInstanceFixture, 
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
        ///     Class (<see cref="WPAPI" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_WPAPI_Is_Instance_Present_Test()
        {
            // Assert
            _wPAPIInstanceType.ShouldNotBeNull();
            _wPAPIInstance.ShouldNotBeNull();
            _wPAPIInstanceFixture.ShouldNotBeNull();
            _wPAPIInstance.ShouldBeAssignableTo<WPAPI>();
            _wPAPIInstanceFixture.ShouldBeAssignableTo<WPAPI>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (WPAPI) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_WPAPI_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            WPAPI instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _wPAPIInstanceType.ShouldNotBeNull();
            _wPAPIInstance.ShouldNotBeNull();
            _wPAPIInstanceFixture.ShouldNotBeNull();
            _wPAPIInstance.ShouldBeAssignableTo<WPAPI>();
            _wPAPIInstanceFixture.ShouldBeAssignableTo<WPAPI>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="WPAPI" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetGrid)]
        [TestCase(MethodGetGridRow)]
        [TestCase(MethodiGetGridRow)]
        [TestCase(MethodSetGridRowEdit)]
        [TestCase(MethodiGetRowValue)]
        [TestCase(MethodGetHasComments)]
        [TestCase(MethodiSetGridRowEdit)]
        [TestCase(MethodGetGridRowEdit)]
        [TestCase(MethodiGetGridRowEdit)]
        [TestCase(MethodGetFieldType)]
        [TestCase(MethodGetExampleDateFormat)]
        [TestCase(MethodValidEditCol)]
        [TestCase(MethodGetCellValue)]
        public void AUT_WPAPI_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_wPAPIInstanceFixture,
                                                                              _wPAPIInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (GetGrid) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WPAPI_GetGrid_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetGridPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodGetGrid, Fixture, methodGetGridPrametersTypes);
        }

        #endregion

        #region Method Call : (GetGrid) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetGrid_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var web = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => WPAPI.GetGrid(data, web);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetGrid) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetGrid_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodGetGridPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetGrid = { data, web };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetGrid, methodGetGridPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodGetGrid, Fixture, methodGetGridPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodGetGrid, parametersOfGetGrid, methodGetGridPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetGrid.ShouldNotBeNull();
            parametersOfGetGrid.Length.ShouldBe(2);
            methodGetGridPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodGetGrid, parametersOfGetGrid, methodGetGridPrametersTypes));
        }

        #endregion

        #region Method Call : (GetGrid) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetGrid_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodGetGridPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetGrid = { data, web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetGrid, methodGetGridPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_wPAPIInstanceFixture, parametersOfGetGrid);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetGrid.ShouldNotBeNull();
            parametersOfGetGrid.Length.ShouldBe(2);
            methodGetGridPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetGrid) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetGrid_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodGetGridPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetGrid = { data, web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodGetGrid, parametersOfGetGrid, methodGetGridPrametersTypes);

            // Assert
            parametersOfGetGrid.ShouldNotBeNull();
            parametersOfGetGrid.Length.ShouldBe(2);
            methodGetGridPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetGrid) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetGrid_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetGridPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodGetGrid, Fixture, methodGetGridPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetGridPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetGrid) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetGrid_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetGridPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodGetGrid, Fixture, methodGetGridPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetGridPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetGrid) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetGrid_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetGrid, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_wPAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetGrid) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetGrid_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetGrid, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetGridRow) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WPAPI_GetGridRow_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetGridRowPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodGetGridRow, Fixture, methodGetGridRowPrametersTypes);
        }

        #endregion

        #region Method Call : (GetGridRow) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetGridRow_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var web = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => WPAPI.GetGridRow(data, web);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetGridRow) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetGridRow_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodGetGridRowPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetGridRow = { data, web };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetGridRow, methodGetGridRowPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodGetGridRow, Fixture, methodGetGridRowPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodGetGridRow, parametersOfGetGridRow, methodGetGridRowPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_wPAPIInstanceFixture, parametersOfGetGridRow);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetGridRow.ShouldNotBeNull();
            parametersOfGetGridRow.Length.ShouldBe(2);
            methodGetGridRowPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetGridRow) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetGridRow_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodGetGridRowPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetGridRow = { data, web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodGetGridRow, parametersOfGetGridRow, methodGetGridRowPrametersTypes);

            // Assert
            parametersOfGetGridRow.ShouldNotBeNull();
            parametersOfGetGridRow.Length.ShouldBe(2);
            methodGetGridRowPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetGridRow) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetGridRow_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetGridRowPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodGetGridRow, Fixture, methodGetGridRowPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetGridRowPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetGridRow) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetGridRow_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetGridRowPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodGetGridRow, Fixture, methodGetGridRowPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetGridRowPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetGridRow) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetGridRow_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetGridRow, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_wPAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetGridRow) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetGridRow_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetGridRow, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iGetGridRow) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WPAPI_iGetGridRow_Static_Method_Call_Internally(Type[] types)
        {
            var methodiGetGridRowPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodiGetGridRow, Fixture, methodiGetGridRowPrametersTypes);
        }

        #endregion

        #region Method Call : (iGetGridRow) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_iGetGridRow_Static_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var doc = CreateType<XmlDocument>();
            var oWeb = CreateType<SPWeb>();
            var DocIn = CreateType<XmlDocument>();
            var methodiGetGridRowPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb), typeof(XmlDocument) };
            object[] parametersOfiGetGridRow = { doc, oWeb, DocIn };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodiGetGridRow, methodiGetGridRowPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_wPAPIInstanceFixture, parametersOfiGetGridRow);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfiGetGridRow.ShouldNotBeNull();
            parametersOfiGetGridRow.Length.ShouldBe(3);
            methodiGetGridRowPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (iGetGridRow) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_iGetGridRow_Static_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var doc = CreateType<XmlDocument>();
            var oWeb = CreateType<SPWeb>();
            var DocIn = CreateType<XmlDocument>();
            var methodiGetGridRowPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb), typeof(XmlDocument) };
            object[] parametersOfiGetGridRow = { doc, oWeb, DocIn };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodiGetGridRow, parametersOfiGetGridRow, methodiGetGridRowPrametersTypes);

            // Assert
            parametersOfiGetGridRow.ShouldNotBeNull();
            parametersOfiGetGridRow.Length.ShouldBe(3);
            methodiGetGridRowPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iGetGridRow) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_iGetGridRow_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodiGetGridRow, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iGetGridRow) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_iGetGridRow_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodiGetGridRowPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb), typeof(XmlDocument) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodiGetGridRow, Fixture, methodiGetGridRowPrametersTypes);

            // Assert
            methodiGetGridRowPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iGetGridRow) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_iGetGridRow_Static_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodiGetGridRow, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_wPAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetGridRowEdit) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WPAPI_SetGridRowEdit_Static_Method_Call_Internally(Type[] types)
        {
            var methodSetGridRowEditPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodSetGridRowEdit, Fixture, methodSetGridRowEditPrametersTypes);
        }

        #endregion

        #region Method Call : (SetGridRowEdit) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_SetGridRowEdit_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var web = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => WPAPI.SetGridRowEdit(data, web);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (SetGridRowEdit) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_SetGridRowEdit_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodSetGridRowEditPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfSetGridRowEdit = { data, web };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetGridRowEdit, methodSetGridRowEditPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodSetGridRowEdit, Fixture, methodSetGridRowEditPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodSetGridRowEdit, parametersOfSetGridRowEdit, methodSetGridRowEditPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSetGridRowEdit.ShouldNotBeNull();
            parametersOfSetGridRowEdit.Length.ShouldBe(2);
            methodSetGridRowEditPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodSetGridRowEdit, parametersOfSetGridRowEdit, methodSetGridRowEditPrametersTypes));
        }

        #endregion

        #region Method Call : (SetGridRowEdit) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_SetGridRowEdit_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodSetGridRowEditPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfSetGridRowEdit = { data, web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetGridRowEdit, methodSetGridRowEditPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_wPAPIInstanceFixture, parametersOfSetGridRowEdit);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetGridRowEdit.ShouldNotBeNull();
            parametersOfSetGridRowEdit.Length.ShouldBe(2);
            methodSetGridRowEditPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetGridRowEdit) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_SetGridRowEdit_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodSetGridRowEditPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfSetGridRowEdit = { data, web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodSetGridRowEdit, parametersOfSetGridRowEdit, methodSetGridRowEditPrametersTypes);

            // Assert
            parametersOfSetGridRowEdit.ShouldNotBeNull();
            parametersOfSetGridRowEdit.Length.ShouldBe(2);
            methodSetGridRowEditPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetGridRowEdit) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_SetGridRowEdit_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodSetGridRowEditPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodSetGridRowEdit, Fixture, methodSetGridRowEditPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodSetGridRowEditPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (SetGridRowEdit) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_SetGridRowEdit_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetGridRowEditPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodSetGridRowEdit, Fixture, methodSetGridRowEditPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSetGridRowEditPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetGridRowEdit) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_SetGridRowEdit_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetGridRowEdit, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_wPAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (SetGridRowEdit) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_SetGridRowEdit_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetGridRowEdit, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iGetRowValue) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WPAPI_iGetRowValue_Static_Method_Call_Internally(Type[] types)
        {
            var methodiGetRowValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodiGetRowValue, Fixture, methodiGetRowValuePrametersTypes);
        }

        #endregion

        #region Method Call : (iGetRowValue) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_iGetRowValue_Static_Method_Call_Void_With_6_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var doc = CreateType<XmlDocument>();
            var oWeb = CreateType<SPWeb>();
            var DocIn = CreateType<XmlDocument>();
            var list = CreateType<SPList>();
            var li = CreateType<SPListItem>();
            var bEditMode = CreateType<bool>();
            var methodiGetRowValuePrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb), typeof(XmlDocument), typeof(SPList), typeof(SPListItem), typeof(bool) };
            object[] parametersOfiGetRowValue = { doc, oWeb, DocIn, list, li, bEditMode };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodiGetRowValue, methodiGetRowValuePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_wPAPIInstanceFixture, parametersOfiGetRowValue);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfiGetRowValue.ShouldNotBeNull();
            parametersOfiGetRowValue.Length.ShouldBe(6);
            methodiGetRowValuePrametersTypes.Length.ShouldBe(6);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (iGetRowValue) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_iGetRowValue_Static_Method_Call_Void_With_6_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var doc = CreateType<XmlDocument>();
            var oWeb = CreateType<SPWeb>();
            var DocIn = CreateType<XmlDocument>();
            var list = CreateType<SPList>();
            var li = CreateType<SPListItem>();
            var bEditMode = CreateType<bool>();
            var methodiGetRowValuePrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb), typeof(XmlDocument), typeof(SPList), typeof(SPListItem), typeof(bool) };
            object[] parametersOfiGetRowValue = { doc, oWeb, DocIn, list, li, bEditMode };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodiGetRowValue, parametersOfiGetRowValue, methodiGetRowValuePrametersTypes);

            // Assert
            parametersOfiGetRowValue.ShouldNotBeNull();
            parametersOfiGetRowValue.Length.ShouldBe(6);
            methodiGetRowValuePrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iGetRowValue) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_iGetRowValue_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodiGetRowValue, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iGetRowValue) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_iGetRowValue_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodiGetRowValuePrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb), typeof(XmlDocument), typeof(SPList), typeof(SPListItem), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodiGetRowValue, Fixture, methodiGetRowValuePrametersTypes);

            // Assert
            methodiGetRowValuePrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iGetRowValue) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_iGetRowValue_Static_Method_Call_With_6_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodiGetRowValue, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_wPAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetHasComments) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WPAPI_GetHasComments_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetHasCommentsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodGetHasComments, Fixture, methodGetHasCommentsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetHasComments) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetHasComments_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var methodGetHasCommentsPrametersTypes = new Type[] { typeof(SPListItem) };
            object[] parametersOfGetHasComments = { li };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetHasComments, methodGetHasCommentsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_wPAPIInstanceFixture, parametersOfGetHasComments);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetHasComments.ShouldNotBeNull();
            parametersOfGetHasComments.Length.ShouldBe(1);
            methodGetHasCommentsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetHasComments) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetHasComments_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var methodGetHasCommentsPrametersTypes = new Type[] { typeof(SPListItem) };
            object[] parametersOfGetHasComments = { li };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodGetHasComments, parametersOfGetHasComments, methodGetHasCommentsPrametersTypes);

            // Assert
            parametersOfGetHasComments.ShouldNotBeNull();
            parametersOfGetHasComments.Length.ShouldBe(1);
            methodGetHasCommentsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetHasComments) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetHasComments_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetHasCommentsPrametersTypes = new Type[] { typeof(SPListItem) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodGetHasComments, Fixture, methodGetHasCommentsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetHasCommentsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetHasComments) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetHasComments_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetHasCommentsPrametersTypes = new Type[] { typeof(SPListItem) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodGetHasComments, Fixture, methodGetHasCommentsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetHasCommentsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetHasComments) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetHasComments_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetHasComments, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_wPAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetHasComments) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetHasComments_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetHasComments, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iSetGridRowEdit) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WPAPI_iSetGridRowEdit_Static_Method_Call_Internally(Type[] types)
        {
            var methodiSetGridRowEditPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodiSetGridRowEdit, Fixture, methodiSetGridRowEditPrametersTypes);
        }

        #endregion

        #region Method Call : (iSetGridRowEdit) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_iSetGridRowEdit_Static_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var doc = CreateType<XmlDocument>();
            var oWeb = CreateType<SPWeb>();
            var DocIn = CreateType<XmlDocument>();
            var methodiSetGridRowEditPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb), typeof(XmlDocument) };
            object[] parametersOfiSetGridRowEdit = { doc, oWeb, DocIn };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodiSetGridRowEdit, methodiSetGridRowEditPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_wPAPIInstanceFixture, parametersOfiSetGridRowEdit);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfiSetGridRowEdit.ShouldNotBeNull();
            parametersOfiSetGridRowEdit.Length.ShouldBe(3);
            methodiSetGridRowEditPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (iSetGridRowEdit) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_iSetGridRowEdit_Static_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var doc = CreateType<XmlDocument>();
            var oWeb = CreateType<SPWeb>();
            var DocIn = CreateType<XmlDocument>();
            var methodiSetGridRowEditPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb), typeof(XmlDocument) };
            object[] parametersOfiSetGridRowEdit = { doc, oWeb, DocIn };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodiSetGridRowEdit, parametersOfiSetGridRowEdit, methodiSetGridRowEditPrametersTypes);

            // Assert
            parametersOfiSetGridRowEdit.ShouldNotBeNull();
            parametersOfiSetGridRowEdit.Length.ShouldBe(3);
            methodiSetGridRowEditPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iSetGridRowEdit) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_iSetGridRowEdit_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodiSetGridRowEdit, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iSetGridRowEdit) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_iSetGridRowEdit_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodiSetGridRowEditPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb), typeof(XmlDocument) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodiSetGridRowEdit, Fixture, methodiSetGridRowEditPrametersTypes);

            // Assert
            methodiSetGridRowEditPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iSetGridRowEdit) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_iSetGridRowEdit_Static_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodiSetGridRowEdit, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_wPAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetGridRowEdit) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WPAPI_GetGridRowEdit_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetGridRowEditPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodGetGridRowEdit, Fixture, methodGetGridRowEditPrametersTypes);
        }

        #endregion

        #region Method Call : (GetGridRowEdit) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetGridRowEdit_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var web = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => WPAPI.GetGridRowEdit(data, web);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetGridRowEdit) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetGridRowEdit_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodGetGridRowEditPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetGridRowEdit = { data, web };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetGridRowEdit, methodGetGridRowEditPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodGetGridRowEdit, Fixture, methodGetGridRowEditPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodGetGridRowEdit, parametersOfGetGridRowEdit, methodGetGridRowEditPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetGridRowEdit.ShouldNotBeNull();
            parametersOfGetGridRowEdit.Length.ShouldBe(2);
            methodGetGridRowEditPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodGetGridRowEdit, parametersOfGetGridRowEdit, methodGetGridRowEditPrametersTypes));
        }

        #endregion

        #region Method Call : (GetGridRowEdit) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetGridRowEdit_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodGetGridRowEditPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetGridRowEdit = { data, web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetGridRowEdit, methodGetGridRowEditPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_wPAPIInstanceFixture, parametersOfGetGridRowEdit);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetGridRowEdit.ShouldNotBeNull();
            parametersOfGetGridRowEdit.Length.ShouldBe(2);
            methodGetGridRowEditPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetGridRowEdit) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetGridRowEdit_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodGetGridRowEditPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetGridRowEdit = { data, web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodGetGridRowEdit, parametersOfGetGridRowEdit, methodGetGridRowEditPrametersTypes);

            // Assert
            parametersOfGetGridRowEdit.ShouldNotBeNull();
            parametersOfGetGridRowEdit.Length.ShouldBe(2);
            methodGetGridRowEditPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetGridRowEdit) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetGridRowEdit_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetGridRowEditPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodGetGridRowEdit, Fixture, methodGetGridRowEditPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetGridRowEditPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetGridRowEdit) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetGridRowEdit_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetGridRowEditPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodGetGridRowEdit, Fixture, methodGetGridRowEditPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetGridRowEditPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetGridRowEdit) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetGridRowEdit_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetGridRowEdit, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_wPAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetGridRowEdit) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetGridRowEdit_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetGridRowEdit, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iGetGridRowEdit) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WPAPI_iGetGridRowEdit_Static_Method_Call_Internally(Type[] types)
        {
            var methodiGetGridRowEditPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodiGetGridRowEdit, Fixture, methodiGetGridRowEditPrametersTypes);
        }

        #endregion

        #region Method Call : (iGetGridRowEdit) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_iGetGridRowEdit_Static_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var doc = CreateType<XmlDocument>();
            var oWeb = CreateType<SPWeb>();
            var DocIn = CreateType<XmlDocument>();
            var methodiGetGridRowEditPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb), typeof(XmlDocument) };
            object[] parametersOfiGetGridRowEdit = { doc, oWeb, DocIn };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodiGetGridRowEdit, methodiGetGridRowEditPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_wPAPIInstanceFixture, parametersOfiGetGridRowEdit);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfiGetGridRowEdit.ShouldNotBeNull();
            parametersOfiGetGridRowEdit.Length.ShouldBe(3);
            methodiGetGridRowEditPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (iGetGridRowEdit) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_iGetGridRowEdit_Static_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var doc = CreateType<XmlDocument>();
            var oWeb = CreateType<SPWeb>();
            var DocIn = CreateType<XmlDocument>();
            var methodiGetGridRowEditPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb), typeof(XmlDocument) };
            object[] parametersOfiGetGridRowEdit = { doc, oWeb, DocIn };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodiGetGridRowEdit, parametersOfiGetGridRowEdit, methodiGetGridRowEditPrametersTypes);

            // Assert
            parametersOfiGetGridRowEdit.ShouldNotBeNull();
            parametersOfiGetGridRowEdit.Length.ShouldBe(3);
            methodiGetGridRowEditPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iGetGridRowEdit) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_iGetGridRowEdit_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodiGetGridRowEdit, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iGetGridRowEdit) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_iGetGridRowEdit_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodiGetGridRowEditPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb), typeof(XmlDocument) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodiGetGridRowEdit, Fixture, methodiGetGridRowEditPrametersTypes);

            // Assert
            methodiGetGridRowEditPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iGetGridRowEdit) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_iGetGridRowEdit_Static_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodiGetGridRowEdit, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_wPAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFieldType) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WPAPI_GetFieldType_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFieldTypePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodGetFieldType, Fixture, methodGetFieldTypePrametersTypes);
        }

        #endregion

        #region Method Call : (GetFieldType) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetFieldType_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var oField = CreateType<SPField>();
            var senum = CreateType<string>();
            var senumkeys = CreateType<string>();
            var sFormat = CreateType<string>();
            var sRange = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            var methodGetFieldTypePrametersTypes = new Type[] { typeof(SPField), typeof(string), typeof(string), typeof(string), typeof(string), typeof(SPWeb) };
            object[] parametersOfGetFieldType = { oField, senum, senumkeys, sFormat, sRange, oWeb };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFieldType, methodGetFieldTypePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodGetFieldType, Fixture, methodGetFieldTypePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodGetFieldType, parametersOfGetFieldType, methodGetFieldTypePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_wPAPIInstanceFixture, parametersOfGetFieldType);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFieldType.ShouldNotBeNull();
            parametersOfGetFieldType.Length.ShouldBe(6);
            methodGetFieldTypePrametersTypes.Length.ShouldBe(6);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetFieldType) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetFieldType_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oField = CreateType<SPField>();
            var senum = CreateType<string>();
            var senumkeys = CreateType<string>();
            var sFormat = CreateType<string>();
            var sRange = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            var methodGetFieldTypePrametersTypes = new Type[] { typeof(SPField), typeof(string), typeof(string), typeof(string), typeof(string), typeof(SPWeb) };
            object[] parametersOfGetFieldType = { oField, senum, senumkeys, sFormat, sRange, oWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodGetFieldType, parametersOfGetFieldType, methodGetFieldTypePrametersTypes);

            // Assert
            parametersOfGetFieldType.ShouldNotBeNull();
            parametersOfGetFieldType.Length.ShouldBe(6);
            methodGetFieldTypePrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFieldType) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetFieldType_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFieldTypePrametersTypes = new Type[] { typeof(SPField), typeof(string), typeof(string), typeof(string), typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodGetFieldType, Fixture, methodGetFieldTypePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFieldTypePrametersTypes.Length.ShouldBe(6);
        }

        #endregion

        #region Method Call : (GetFieldType) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetFieldType_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFieldTypePrametersTypes = new Type[] { typeof(SPField), typeof(string), typeof(string), typeof(string), typeof(string), typeof(SPWeb) };
            const int parametersCount = 6;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodGetFieldType, Fixture, methodGetFieldTypePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFieldTypePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFieldType) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetFieldType_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFieldType, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_wPAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFieldType) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetFieldType_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFieldType, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetExampleDateFormat) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WPAPI_GetExampleDateFormat_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetExampleDateFormatPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodGetExampleDateFormat, Fixture, methodGetExampleDateFormatPrametersTypes);
        }

        #endregion

        #region Method Call : (GetExampleDateFormat) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetExampleDateFormat_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var yearLabel = CreateType<string>();
            var monthLabel = CreateType<string>();
            var dayLabel = CreateType<string>();
            var methodGetExampleDateFormatPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfGetExampleDateFormat = { web, yearLabel, monthLabel, dayLabel };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetExampleDateFormat, methodGetExampleDateFormatPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodGetExampleDateFormat, Fixture, methodGetExampleDateFormatPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodGetExampleDateFormat, parametersOfGetExampleDateFormat, methodGetExampleDateFormatPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_wPAPIInstanceFixture, parametersOfGetExampleDateFormat);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetExampleDateFormat.ShouldNotBeNull();
            parametersOfGetExampleDateFormat.Length.ShouldBe(4);
            methodGetExampleDateFormatPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetExampleDateFormat) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetExampleDateFormat_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var yearLabel = CreateType<string>();
            var monthLabel = CreateType<string>();
            var dayLabel = CreateType<string>();
            var methodGetExampleDateFormatPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfGetExampleDateFormat = { web, yearLabel, monthLabel, dayLabel };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodGetExampleDateFormat, parametersOfGetExampleDateFormat, methodGetExampleDateFormatPrametersTypes);

            // Assert
            parametersOfGetExampleDateFormat.ShouldNotBeNull();
            parametersOfGetExampleDateFormat.Length.ShouldBe(4);
            methodGetExampleDateFormatPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetExampleDateFormat) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetExampleDateFormat_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetExampleDateFormatPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodGetExampleDateFormat, Fixture, methodGetExampleDateFormatPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetExampleDateFormatPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetExampleDateFormat) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetExampleDateFormat_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetExampleDateFormatPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodGetExampleDateFormat, Fixture, methodGetExampleDateFormatPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetExampleDateFormatPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetExampleDateFormat) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetExampleDateFormat_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetExampleDateFormat, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_wPAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetExampleDateFormat) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetExampleDateFormat_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetExampleDateFormat, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ValidEditCol) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WPAPI_ValidEditCol_Static_Method_Call_Internally(Type[] types)
        {
            var methodValidEditColPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodValidEditCol, Fixture, methodValidEditColPrametersTypes);
        }

        #endregion

        #region Method Call : (ValidEditCol) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_ValidEditCol_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sCol = CreateType<string>();
            var methodValidEditColPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfValidEditCol = { sCol };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodValidEditCol, methodValidEditColPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_wPAPIInstanceFixture, parametersOfValidEditCol);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfValidEditCol.ShouldNotBeNull();
            parametersOfValidEditCol.Length.ShouldBe(1);
            methodValidEditColPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ValidEditCol) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_ValidEditCol_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sCol = CreateType<string>();
            var methodValidEditColPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfValidEditCol = { sCol };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodValidEditCol, parametersOfValidEditCol, methodValidEditColPrametersTypes);

            // Assert
            parametersOfValidEditCol.ShouldNotBeNull();
            parametersOfValidEditCol.Length.ShouldBe(1);
            methodValidEditColPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ValidEditCol) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_ValidEditCol_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodValidEditColPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodValidEditCol, Fixture, methodValidEditColPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodValidEditColPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ValidEditCol) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_ValidEditCol_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodValidEditCol, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_wPAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ValidEditCol) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_ValidEditCol_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodValidEditCol, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCellValue) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WPAPI_GetCellValue_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetCellValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodGetCellValue, Fixture, methodGetCellValuePrametersTypes);
        }

        #endregion

        #region Method Call : (GetCellValue) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetCellValue_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var oField = CreateType<SPField>();
            var bEditMode = CreateType<bool>();
            var oWeb = CreateType<SPWeb>();
            var methodGetCellValuePrametersTypes = new Type[] { typeof(SPListItem), typeof(SPField), typeof(bool), typeof(SPWeb) };
            object[] parametersOfGetCellValue = { li, oField, bEditMode, oWeb };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCellValue, methodGetCellValuePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodGetCellValue, Fixture, methodGetCellValuePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodGetCellValue, parametersOfGetCellValue, methodGetCellValuePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_wPAPIInstanceFixture, parametersOfGetCellValue);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetCellValue.ShouldNotBeNull();
            parametersOfGetCellValue.Length.ShouldBe(4);
            methodGetCellValuePrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetCellValue) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetCellValue_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var oField = CreateType<SPField>();
            var bEditMode = CreateType<bool>();
            var oWeb = CreateType<SPWeb>();
            var methodGetCellValuePrametersTypes = new Type[] { typeof(SPListItem), typeof(SPField), typeof(bool), typeof(SPWeb) };
            object[] parametersOfGetCellValue = { li, oField, bEditMode, oWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodGetCellValue, parametersOfGetCellValue, methodGetCellValuePrametersTypes);

            // Assert
            parametersOfGetCellValue.ShouldNotBeNull();
            parametersOfGetCellValue.Length.ShouldBe(4);
            methodGetCellValuePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCellValue) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetCellValue_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCellValuePrametersTypes = new Type[] { typeof(SPListItem), typeof(SPField), typeof(bool), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodGetCellValue, Fixture, methodGetCellValuePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCellValuePrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetCellValue) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetCellValue_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCellValuePrametersTypes = new Type[] { typeof(SPListItem), typeof(SPField), typeof(bool), typeof(SPWeb) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wPAPIInstanceFixture, _wPAPIInstanceType, MethodGetCellValue, Fixture, methodGetCellValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCellValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCellValue) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetCellValue_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCellValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_wPAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCellValue) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WPAPI_GetCellValue_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCellValue, 0);
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
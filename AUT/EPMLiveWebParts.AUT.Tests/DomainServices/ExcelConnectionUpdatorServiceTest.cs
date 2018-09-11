using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using DocumentFormat.OpenXml.Packaging;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.ExcelConnectionUpdatorService" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ExcelConnectionUpdatorServiceTest : AbstractBaseSetupTypedTest<ExcelConnectionUpdatorService>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ExcelConnectionUpdatorService) Initializer

        private const string MethodProcessOdcFiles = "ProcessOdcFiles";
        private const string MethodProcessExcelFiles = "ProcessExcelFiles";
        private const string MethodUpdateConnectionsInExcelFile = "UpdateConnectionsInExcelFile";
        private const string MethodGetOdcFileHtmlWithReplacedTokens = "GetOdcFileHtmlWithReplacedTokens";
        private const string MethodReplaceTokens = "ReplaceTokens";
        private const string Field_connectionInfo = "_connectionInfo";
        private const string Field_sharepointService = "_sharepointService";
        private const string FieldExcelNamespace = "ExcelNamespace";
        private Type _excelConnectionUpdatorServiceInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ExcelConnectionUpdatorService _excelConnectionUpdatorServiceInstance;
        private ExcelConnectionUpdatorService _excelConnectionUpdatorServiceInstanceFixture;

        #region General Initializer : Class (ExcelConnectionUpdatorService) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ExcelConnectionUpdatorService" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _excelConnectionUpdatorServiceInstanceType = typeof(ExcelConnectionUpdatorService);
            _excelConnectionUpdatorServiceInstanceFixture = Create(true);
            _excelConnectionUpdatorServiceInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ExcelConnectionUpdatorService)

        #region General Initializer : Class (ExcelConnectionUpdatorService) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ExcelConnectionUpdatorService" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodProcessOdcFiles, 0)]
        [TestCase(MethodProcessExcelFiles, 0)]
        [TestCase(MethodUpdateConnectionsInExcelFile, 0)]
        [TestCase(MethodGetOdcFileHtmlWithReplacedTokens, 0)]
        [TestCase(MethodReplaceTokens, 0)]
        public void AUT_ExcelConnectionUpdatorService_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_excelConnectionUpdatorServiceInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ExcelConnectionUpdatorService) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ExcelConnectionUpdatorService" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_connectionInfo)]
        [TestCase(Field_sharepointService)]
        [TestCase(FieldExcelNamespace)]
        public void AUT_ExcelConnectionUpdatorService_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_excelConnectionUpdatorServiceInstanceFixture, 
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
        ///     Class (<see cref="ExcelConnectionUpdatorService" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ExcelConnectionUpdatorService_Is_Instance_Present_Test()
        {
            // Assert
            _excelConnectionUpdatorServiceInstanceType.ShouldNotBeNull();
            _excelConnectionUpdatorServiceInstance.ShouldNotBeNull();
            _excelConnectionUpdatorServiceInstanceFixture.ShouldNotBeNull();
            _excelConnectionUpdatorServiceInstance.ShouldBeAssignableTo<ExcelConnectionUpdatorService>();
            _excelConnectionUpdatorServiceInstanceFixture.ShouldBeAssignableTo<ExcelConnectionUpdatorService>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ExcelConnectionUpdatorService) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ExcelConnectionUpdatorService_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var connectionInfo = CreateType<ExcelConnectionInfo>();
            var sharepointService = CreateType<ISharepointService>();
            ExcelConnectionUpdatorService instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new ExcelConnectionUpdatorService(connectionInfo, sharepointService);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _excelConnectionUpdatorServiceInstance.ShouldNotBeNull();
            _excelConnectionUpdatorServiceInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<ExcelConnectionUpdatorService>();
        }

        #endregion

        #region General Constructor : Class (ExcelConnectionUpdatorService) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ExcelConnectionUpdatorService_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var connectionInfo = CreateType<ExcelConnectionInfo>();
            var sharepointService = CreateType<ISharepointService>();
            ExcelConnectionUpdatorService instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new ExcelConnectionUpdatorService(connectionInfo, sharepointService);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _excelConnectionUpdatorServiceInstance.ShouldNotBeNull();
            _excelConnectionUpdatorServiceInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ExcelConnectionUpdatorService" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodProcessOdcFiles)]
        [TestCase(MethodProcessExcelFiles)]
        [TestCase(MethodUpdateConnectionsInExcelFile)]
        [TestCase(MethodGetOdcFileHtmlWithReplacedTokens)]
        [TestCase(MethodReplaceTokens)]
        public void AUT_ExcelConnectionUpdatorService_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ExcelConnectionUpdatorService>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (ProcessOdcFiles) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExcelConnectionUpdatorService_ProcessOdcFiles_Method_Call_Internally(Type[] types)
        {
            var methodProcessOdcFilesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_excelConnectionUpdatorServiceInstance, MethodProcessOdcFiles, Fixture, methodProcessOdcFilesPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessOdcFiles) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExcelConnectionUpdatorService_ProcessOdcFiles_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _excelConnectionUpdatorServiceInstance.ProcessOdcFiles();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ProcessOdcFiles) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExcelConnectionUpdatorService_ProcessOdcFiles_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodProcessOdcFilesPrametersTypes = null;
            object[] parametersOfProcessOdcFiles = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodProcessOdcFiles, methodProcessOdcFilesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_excelConnectionUpdatorServiceInstanceFixture, parametersOfProcessOdcFiles);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfProcessOdcFiles.ShouldBeNull();
            methodProcessOdcFilesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessOdcFiles) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExcelConnectionUpdatorService_ProcessOdcFiles_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodProcessOdcFilesPrametersTypes = null;
            object[] parametersOfProcessOdcFiles = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_excelConnectionUpdatorServiceInstance, MethodProcessOdcFiles, parametersOfProcessOdcFiles, methodProcessOdcFilesPrametersTypes);

            // Assert
            parametersOfProcessOdcFiles.ShouldBeNull();
            methodProcessOdcFilesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessOdcFiles) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExcelConnectionUpdatorService_ProcessOdcFiles_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodProcessOdcFilesPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_excelConnectionUpdatorServiceInstance, MethodProcessOdcFiles, Fixture, methodProcessOdcFilesPrametersTypes);

            // Assert
            methodProcessOdcFilesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessOdcFiles) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExcelConnectionUpdatorService_ProcessOdcFiles_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessOdcFiles, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_excelConnectionUpdatorServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessExcelFiles) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExcelConnectionUpdatorService_ProcessExcelFiles_Method_Call_Internally(Type[] types)
        {
            var methodProcessExcelFilesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_excelConnectionUpdatorServiceInstance, MethodProcessExcelFiles, Fixture, methodProcessExcelFilesPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessExcelFiles) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExcelConnectionUpdatorService_ProcessExcelFiles_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _excelConnectionUpdatorServiceInstance.ProcessExcelFiles();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ProcessExcelFiles) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExcelConnectionUpdatorService_ProcessExcelFiles_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodProcessExcelFilesPrametersTypes = null;
            object[] parametersOfProcessExcelFiles = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodProcessExcelFiles, methodProcessExcelFilesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_excelConnectionUpdatorServiceInstanceFixture, parametersOfProcessExcelFiles);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfProcessExcelFiles.ShouldBeNull();
            methodProcessExcelFilesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessExcelFiles) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExcelConnectionUpdatorService_ProcessExcelFiles_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodProcessExcelFilesPrametersTypes = null;
            object[] parametersOfProcessExcelFiles = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_excelConnectionUpdatorServiceInstance, MethodProcessExcelFiles, parametersOfProcessExcelFiles, methodProcessExcelFilesPrametersTypes);

            // Assert
            parametersOfProcessExcelFiles.ShouldBeNull();
            methodProcessExcelFilesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessExcelFiles) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExcelConnectionUpdatorService_ProcessExcelFiles_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodProcessExcelFilesPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_excelConnectionUpdatorServiceInstance, MethodProcessExcelFiles, Fixture, methodProcessExcelFilesPrametersTypes);

            // Assert
            methodProcessExcelFilesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessExcelFiles) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExcelConnectionUpdatorService_ProcessExcelFiles_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessExcelFiles, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_excelConnectionUpdatorServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateConnectionsInExcelFile) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExcelConnectionUpdatorService_UpdateConnectionsInExcelFile_Method_Call_Internally(Type[] types)
        {
            var methodUpdateConnectionsInExcelFilePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_excelConnectionUpdatorServiceInstance, MethodUpdateConnectionsInExcelFile, Fixture, methodUpdateConnectionsInExcelFilePrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateConnectionsInExcelFile) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExcelConnectionUpdatorService_UpdateConnectionsInExcelFile_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var excelDoc = CreateType<SpreadsheetDocument>();
            var methodUpdateConnectionsInExcelFilePrametersTypes = new Type[] { typeof(SpreadsheetDocument) };
            object[] parametersOfUpdateConnectionsInExcelFile = { excelDoc };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateConnectionsInExcelFile, methodUpdateConnectionsInExcelFilePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_excelConnectionUpdatorServiceInstanceFixture, parametersOfUpdateConnectionsInExcelFile);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateConnectionsInExcelFile.ShouldNotBeNull();
            parametersOfUpdateConnectionsInExcelFile.Length.ShouldBe(1);
            methodUpdateConnectionsInExcelFilePrametersTypes.Length.ShouldBe(1);
            methodUpdateConnectionsInExcelFilePrametersTypes.Length.ShouldBe(parametersOfUpdateConnectionsInExcelFile.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateConnectionsInExcelFile) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExcelConnectionUpdatorService_UpdateConnectionsInExcelFile_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var excelDoc = CreateType<SpreadsheetDocument>();
            var methodUpdateConnectionsInExcelFilePrametersTypes = new Type[] { typeof(SpreadsheetDocument) };
            object[] parametersOfUpdateConnectionsInExcelFile = { excelDoc };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_excelConnectionUpdatorServiceInstance, MethodUpdateConnectionsInExcelFile, parametersOfUpdateConnectionsInExcelFile, methodUpdateConnectionsInExcelFilePrametersTypes);

            // Assert
            parametersOfUpdateConnectionsInExcelFile.ShouldNotBeNull();
            parametersOfUpdateConnectionsInExcelFile.Length.ShouldBe(1);
            methodUpdateConnectionsInExcelFilePrametersTypes.Length.ShouldBe(1);
            methodUpdateConnectionsInExcelFilePrametersTypes.Length.ShouldBe(parametersOfUpdateConnectionsInExcelFile.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateConnectionsInExcelFile) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExcelConnectionUpdatorService_UpdateConnectionsInExcelFile_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateConnectionsInExcelFile, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateConnectionsInExcelFile) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExcelConnectionUpdatorService_UpdateConnectionsInExcelFile_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateConnectionsInExcelFilePrametersTypes = new Type[] { typeof(SpreadsheetDocument) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_excelConnectionUpdatorServiceInstance, MethodUpdateConnectionsInExcelFile, Fixture, methodUpdateConnectionsInExcelFilePrametersTypes);

            // Assert
            methodUpdateConnectionsInExcelFilePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateConnectionsInExcelFile) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExcelConnectionUpdatorService_UpdateConnectionsInExcelFile_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateConnectionsInExcelFile, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_excelConnectionUpdatorServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetOdcFileHtmlWithReplacedTokens) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExcelConnectionUpdatorService_GetOdcFileHtmlWithReplacedTokens_Method_Call_Internally(Type[] types)
        {
            var methodGetOdcFileHtmlWithReplacedTokensPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_excelConnectionUpdatorServiceInstance, MethodGetOdcFileHtmlWithReplacedTokens, Fixture, methodGetOdcFileHtmlWithReplacedTokensPrametersTypes);
        }

        #endregion

        #region Method Call : (GetOdcFileHtmlWithReplacedTokens) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExcelConnectionUpdatorService_GetOdcFileHtmlWithReplacedTokens_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var odcFileHtml = CreateType<string>();
            var methodGetOdcFileHtmlWithReplacedTokensPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetOdcFileHtmlWithReplacedTokens = { odcFileHtml };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetOdcFileHtmlWithReplacedTokens, methodGetOdcFileHtmlWithReplacedTokensPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_excelConnectionUpdatorServiceInstanceFixture, parametersOfGetOdcFileHtmlWithReplacedTokens);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetOdcFileHtmlWithReplacedTokens.ShouldNotBeNull();
            parametersOfGetOdcFileHtmlWithReplacedTokens.Length.ShouldBe(1);
            methodGetOdcFileHtmlWithReplacedTokensPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetOdcFileHtmlWithReplacedTokens) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExcelConnectionUpdatorService_GetOdcFileHtmlWithReplacedTokens_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var odcFileHtml = CreateType<string>();
            var methodGetOdcFileHtmlWithReplacedTokensPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetOdcFileHtmlWithReplacedTokens = { odcFileHtml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ExcelConnectionUpdatorService, string>(_excelConnectionUpdatorServiceInstance, MethodGetOdcFileHtmlWithReplacedTokens, parametersOfGetOdcFileHtmlWithReplacedTokens, methodGetOdcFileHtmlWithReplacedTokensPrametersTypes);

            // Assert
            parametersOfGetOdcFileHtmlWithReplacedTokens.ShouldNotBeNull();
            parametersOfGetOdcFileHtmlWithReplacedTokens.Length.ShouldBe(1);
            methodGetOdcFileHtmlWithReplacedTokensPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetOdcFileHtmlWithReplacedTokens) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExcelConnectionUpdatorService_GetOdcFileHtmlWithReplacedTokens_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetOdcFileHtmlWithReplacedTokensPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_excelConnectionUpdatorServiceInstance, MethodGetOdcFileHtmlWithReplacedTokens, Fixture, methodGetOdcFileHtmlWithReplacedTokensPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetOdcFileHtmlWithReplacedTokensPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetOdcFileHtmlWithReplacedTokens) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExcelConnectionUpdatorService_GetOdcFileHtmlWithReplacedTokens_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetOdcFileHtmlWithReplacedTokensPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_excelConnectionUpdatorServiceInstance, MethodGetOdcFileHtmlWithReplacedTokens, Fixture, methodGetOdcFileHtmlWithReplacedTokensPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetOdcFileHtmlWithReplacedTokensPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetOdcFileHtmlWithReplacedTokens) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExcelConnectionUpdatorService_GetOdcFileHtmlWithReplacedTokens_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetOdcFileHtmlWithReplacedTokens, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_excelConnectionUpdatorServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetOdcFileHtmlWithReplacedTokens) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExcelConnectionUpdatorService_GetOdcFileHtmlWithReplacedTokens_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetOdcFileHtmlWithReplacedTokens, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReplaceTokens) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExcelConnectionUpdatorService_ReplaceTokens_Method_Call_Internally(Type[] types)
        {
            var methodReplaceTokensPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_excelConnectionUpdatorServiceInstance, MethodReplaceTokens, Fixture, methodReplaceTokensPrametersTypes);
        }

        #endregion

        #region Method Call : (ReplaceTokens) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExcelConnectionUpdatorService_ReplaceTokens_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var tokenString = CreateType<string>();
            var methodReplaceTokensPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfReplaceTokens = { tokenString };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReplaceTokens, methodReplaceTokensPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_excelConnectionUpdatorServiceInstanceFixture, parametersOfReplaceTokens);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReplaceTokens.ShouldNotBeNull();
            parametersOfReplaceTokens.Length.ShouldBe(1);
            methodReplaceTokensPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReplaceTokens) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExcelConnectionUpdatorService_ReplaceTokens_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var tokenString = CreateType<string>();
            var methodReplaceTokensPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfReplaceTokens = { tokenString };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ExcelConnectionUpdatorService, string>(_excelConnectionUpdatorServiceInstance, MethodReplaceTokens, parametersOfReplaceTokens, methodReplaceTokensPrametersTypes);

            // Assert
            parametersOfReplaceTokens.ShouldNotBeNull();
            parametersOfReplaceTokens.Length.ShouldBe(1);
            methodReplaceTokensPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReplaceTokens) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExcelConnectionUpdatorService_ReplaceTokens_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodReplaceTokensPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_excelConnectionUpdatorServiceInstance, MethodReplaceTokens, Fixture, methodReplaceTokensPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodReplaceTokensPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ReplaceTokens) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExcelConnectionUpdatorService_ReplaceTokens_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReplaceTokensPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_excelConnectionUpdatorServiceInstance, MethodReplaceTokens, Fixture, methodReplaceTokensPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodReplaceTokensPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReplaceTokens) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExcelConnectionUpdatorService_ReplaceTokens_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReplaceTokens, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_excelConnectionUpdatorServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ReplaceTokens) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExcelConnectionUpdatorService_ReplaceTokens_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReplaceTokens, 0);
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
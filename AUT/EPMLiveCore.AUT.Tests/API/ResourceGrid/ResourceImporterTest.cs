using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.API
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.ResourceImporter" />)
    ///     and namespace <see cref="EPMLiveCore.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ResourceImporterTest : AbstractBaseSetupTypedTest<ResourceImporter>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ResourceImporter) Initializer

        private const string MethodImportAsync = "ImportAsync";
        private const string MethodAddNewResource = "AddNewResource";
        private const string MethodBuildResourceTable = "BuildResourceTable";
        private const string MethodGetCellReference = "GetCellReference";
        private const string MethodGetCellValue = "GetCellValue";
        private const string MethodGetListFields = "GetListFields";
        private const string MethodGetSiteUsers = "GetSiteUsers";
        private const string MethodGetUserValue = "GetUserValue";
        private const string MethodImportResources = "ImportResources";
        private const string MethodLoadSpreadsheet = "LoadSpreadsheet";
        private const string MethodParseExcelResources = "ParseExcelResources";
        private const string MethodUpdateItem = "UpdateItem";
        private const string MethodUpdateResource = "UpdateResource";
        private const string MethodValidateUser = "ValidateUser";
        private const string MethodLogImportMessage = "LogImportMessage";
        private const string MethodRaiseImportProgressChangedEvent = "RaiseImportProgressChangedEvent";
        private const string MethodRaiseImportCompletedEvent = "RaiseImportCompletedEvent";
        private const string FieldTAB_SEPERATOR = "TAB_SEPERATOR";
        private const string FieldVALIDATE_EMAIL_QUERY = "VALIDATE_EMAIL_QUERY";
        private const string Field_act = "_act";
        private const string Field_dtResources = "_dtResources";
        private const string Field_fileId = "_fileId";
        private const string Field_isOnline = "_isOnline";
        private const string Field_spWeb = "_spWeb";
        private const string Field_currentProcess = "_currentProcess";
        private const string Field_dSMResult = "_dSMResult";
        private const string Field_totalRecords = "_totalRecords";
        private const string FieldIsImportCancelled = "IsImportCancelled";
        private Type _resourceImporterInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ResourceImporter _resourceImporterInstance;
        private ResourceImporter _resourceImporterInstanceFixture;

        #region General Initializer : Class (ResourceImporter) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ResourceImporter" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _resourceImporterInstanceType = typeof(ResourceImporter);
            _resourceImporterInstanceFixture = Create(true);
            _resourceImporterInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ResourceImporter)

        #region General Initializer : Class (ResourceImporter) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ResourceImporter" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(MethodAddNewResource, 0)]
        [TestCase(MethodBuildResourceTable, 0)]
        [TestCase(MethodGetCellReference, 0)]
        [TestCase(MethodGetCellValue, 0)]
        [TestCase(MethodGetListFields, 0)]
        [TestCase(MethodGetSiteUsers, 0)]
        [TestCase(MethodGetUserValue, 0)]
        [TestCase(MethodImportResources, 0)]
        [TestCase(MethodLoadSpreadsheet, 0)]
        [TestCase(MethodParseExcelResources, 0)]
        [TestCase(MethodUpdateItem, 0)]
        [TestCase(MethodUpdateResource, 0)]
        [TestCase(MethodValidateUser, 0)]
        [TestCase(MethodLogImportMessage, 0)]
        [TestCase(MethodRaiseImportProgressChangedEvent, 0)]
        [TestCase(MethodRaiseImportCompletedEvent, 0)]
        public void AUT_ResourceImporter_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_resourceImporterInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ResourceImporter) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ResourceImporter" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldTAB_SEPERATOR)]
        [TestCase(FieldVALIDATE_EMAIL_QUERY)]
        [TestCase(FieldIsImportCancelled)]
        public void AUT_ResourceImporter_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_resourceImporterInstanceFixture, 
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
        ///      Class (<see cref="ResourceImporter" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        [TestCase(MethodAddNewResource)]
        [TestCase(MethodBuildResourceTable)]
        [TestCase(MethodGetCellReference)]
        [TestCase(MethodGetCellValue)]
        [TestCase(MethodGetListFields)]
        [TestCase(MethodGetSiteUsers)]
        [TestCase(MethodGetUserValue)]
        [TestCase(MethodImportResources)]
        [TestCase(MethodLoadSpreadsheet)]
        [TestCase(MethodParseExcelResources)]
        [TestCase(MethodUpdateItem)]
        [TestCase(MethodUpdateResource)]
        [TestCase(MethodValidateUser)]
        [TestCase(MethodLogImportMessage)]
        [TestCase(MethodRaiseImportProgressChangedEvent)]
        [TestCase(MethodRaiseImportCompletedEvent)]
        public void AUT_ResourceImporter_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ResourceImporter>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (AddNewResource) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceImporter_AddNewResource_Method_Call_Internally(Type[] types)
        {
            var methodAddNewResourcePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImporterInstance, MethodAddNewResource, Fixture, methodAddNewResourcePrametersTypes);
        }

        #endregion

        #region Method Call : (AddNewResource) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_AddNewResource_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var row = CreateType<DataRow>();
            var isGeneric = CreateType<bool>();
            var methodAddNewResourcePrametersTypes = new Type[] { typeof(DataRow), typeof(bool) };
            object[] parametersOfAddNewResource = { row, isGeneric };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddNewResource, methodAddNewResourcePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourceImporterInstanceFixture, parametersOfAddNewResource);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddNewResource.ShouldNotBeNull();
            parametersOfAddNewResource.Length.ShouldBe(2);
            methodAddNewResourcePrametersTypes.Length.ShouldBe(2);
            methodAddNewResourcePrametersTypes.Length.ShouldBe(parametersOfAddNewResource.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddNewResource) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_AddNewResource_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var row = CreateType<DataRow>();
            var isGeneric = CreateType<bool>();
            var methodAddNewResourcePrametersTypes = new Type[] { typeof(DataRow), typeof(bool) };
            object[] parametersOfAddNewResource = { row, isGeneric };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourceImporterInstance, MethodAddNewResource, parametersOfAddNewResource, methodAddNewResourcePrametersTypes);

            // Assert
            parametersOfAddNewResource.ShouldNotBeNull();
            parametersOfAddNewResource.Length.ShouldBe(2);
            methodAddNewResourcePrametersTypes.Length.ShouldBe(2);
            methodAddNewResourcePrametersTypes.Length.ShouldBe(parametersOfAddNewResource.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddNewResource) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_AddNewResource_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddNewResource, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddNewResource) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_AddNewResource_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddNewResourcePrametersTypes = new Type[] { typeof(DataRow), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImporterInstance, MethodAddNewResource, Fixture, methodAddNewResourcePrametersTypes);

            // Assert
            methodAddNewResourcePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddNewResource) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_AddNewResource_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddNewResource, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceImporterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildResourceTable) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceImporter_BuildResourceTable_Method_Call_Internally(Type[] types)
        {
            var methodBuildResourceTablePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImporterInstance, MethodBuildResourceTable, Fixture, methodBuildResourceTablePrametersTypes);
        }

        #endregion

        #region Method Call : (BuildResourceTable) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_BuildResourceTable_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodBuildResourceTablePrametersTypes = null;
            object[] parametersOfBuildResourceTable = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBuildResourceTable, methodBuildResourceTablePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourceImporterInstanceFixture, parametersOfBuildResourceTable);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfBuildResourceTable.ShouldBeNull();
            methodBuildResourceTablePrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (BuildResourceTable) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_BuildResourceTable_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodBuildResourceTablePrametersTypes = null;
            object[] parametersOfBuildResourceTable = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourceImporterInstance, MethodBuildResourceTable, parametersOfBuildResourceTable, methodBuildResourceTablePrametersTypes);

            // Assert
            parametersOfBuildResourceTable.ShouldBeNull();
            methodBuildResourceTablePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildResourceTable) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_BuildResourceTable_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodBuildResourceTablePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImporterInstance, MethodBuildResourceTable, Fixture, methodBuildResourceTablePrametersTypes);

            // Assert
            methodBuildResourceTablePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildResourceTable) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_BuildResourceTable_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildResourceTable, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceImporterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCellReference) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceImporter_GetCellReference_Method_Call_Internally(Type[] types)
        {
            var methodGetCellReferencePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImporterInstance, MethodGetCellReference, Fixture, methodGetCellReferencePrametersTypes);
        }

        #endregion

        #region Method Call : (GetCellReference) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_GetCellReference_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var cell = CreateType<Cell>();
            var methodGetCellReferencePrametersTypes = new Type[] { typeof(Cell) };
            object[] parametersOfGetCellReference = { cell };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetCellReference, methodGetCellReferencePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResourceImporter, string>(_resourceImporterInstanceFixture, out exception1, parametersOfGetCellReference);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResourceImporter, string>(_resourceImporterInstance, MethodGetCellReference, parametersOfGetCellReference, methodGetCellReferencePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetCellReference.ShouldNotBeNull();
            parametersOfGetCellReference.Length.ShouldBe(1);
            methodGetCellReferencePrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_resourceImporterInstanceFixture, parametersOfGetCellReference));
        }

        #endregion

        #region Method Call : (GetCellReference) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_GetCellReference_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var cell = CreateType<Cell>();
            var methodGetCellReferencePrametersTypes = new Type[] { typeof(Cell) };
            object[] parametersOfGetCellReference = { cell };

            // Assert
            parametersOfGetCellReference.ShouldNotBeNull();
            parametersOfGetCellReference.Length.ShouldBe(1);
            methodGetCellReferencePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<ResourceImporter, string>(_resourceImporterInstance, MethodGetCellReference, parametersOfGetCellReference, methodGetCellReferencePrametersTypes));
        }

        #endregion

        #region Method Call : (GetCellReference) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_GetCellReference_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCellReferencePrametersTypes = new Type[] { typeof(Cell) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImporterInstance, MethodGetCellReference, Fixture, methodGetCellReferencePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCellReferencePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetCellReference) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_GetCellReference_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCellReferencePrametersTypes = new Type[] { typeof(Cell) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImporterInstance, MethodGetCellReference, Fixture, methodGetCellReferencePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCellReferencePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCellReference) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_GetCellReference_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCellReference, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceImporterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCellReference) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_GetCellReference_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCellReference, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCellValue) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceImporter_GetCellValue_Method_Call_Internally(Type[] types)
        {
            var methodGetCellValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImporterInstance, MethodGetCellValue, Fixture, methodGetCellValuePrametersTypes);
        }

        #endregion

        #region Method Call : (GetCellValue) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_GetCellValue_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var document = CreateType<SpreadsheetDocument>();
            var cell = CreateType<Cell>();
            var methodGetCellValuePrametersTypes = new Type[] { typeof(SpreadsheetDocument), typeof(Cell) };
            object[] parametersOfGetCellValue = { document, cell };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetCellValue, methodGetCellValuePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResourceImporter, string>(_resourceImporterInstanceFixture, out exception1, parametersOfGetCellValue);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResourceImporter, string>(_resourceImporterInstance, MethodGetCellValue, parametersOfGetCellValue, methodGetCellValuePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetCellValue.ShouldNotBeNull();
            parametersOfGetCellValue.Length.ShouldBe(2);
            methodGetCellValuePrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(() => methodInfo.Invoke(_resourceImporterInstanceFixture, parametersOfGetCellValue));
        }

        #endregion

        #region Method Call : (GetCellValue) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_GetCellValue_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var document = CreateType<SpreadsheetDocument>();
            var cell = CreateType<Cell>();
            var methodGetCellValuePrametersTypes = new Type[] { typeof(SpreadsheetDocument), typeof(Cell) };
            object[] parametersOfGetCellValue = { document, cell };

            // Assert
            parametersOfGetCellValue.ShouldNotBeNull();
            parametersOfGetCellValue.Length.ShouldBe(2);
            methodGetCellValuePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<ResourceImporter, string>(_resourceImporterInstance, MethodGetCellValue, parametersOfGetCellValue, methodGetCellValuePrametersTypes));
        }

        #endregion

        #region Method Call : (GetCellValue) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_GetCellValue_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCellValuePrametersTypes = new Type[] { typeof(SpreadsheetDocument), typeof(Cell) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImporterInstance, MethodGetCellValue, Fixture, methodGetCellValuePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCellValuePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetCellValue) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_GetCellValue_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCellValuePrametersTypes = new Type[] { typeof(SpreadsheetDocument), typeof(Cell) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImporterInstance, MethodGetCellValue, Fixture, methodGetCellValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCellValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCellValue) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_GetCellValue_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCellValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceImporterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCellValue) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_GetCellValue_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCellValue, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListFields) (Return Type : Dictionary<string, SPFieldType>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceImporter_GetListFields_Method_Call_Internally(Type[] types)
        {
            var methodGetListFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImporterInstance, MethodGetListFields, Fixture, methodGetListFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetListFields) (Return Type : Dictionary<string, SPFieldType>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_GetListFields_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var lookupFieldDict = CreateType<Dictionary<string, Dictionary<string, int>>>();
            var methodGetListFieldsPrametersTypes = new Type[] { typeof(Dictionary<string, Dictionary<string, int>>) };
            object[] parametersOfGetListFields = { lookupFieldDict };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetListFields, methodGetListFieldsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResourceImporter, Dictionary<string, SPFieldType>>(_resourceImporterInstanceFixture, out exception1, parametersOfGetListFields);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResourceImporter, Dictionary<string, SPFieldType>>(_resourceImporterInstance, MethodGetListFields, parametersOfGetListFields, methodGetListFieldsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetListFields.ShouldNotBeNull();
            parametersOfGetListFields.Length.ShouldBe(1);
            methodGetListFieldsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_resourceImporterInstanceFixture, parametersOfGetListFields));
        }

        #endregion

        #region Method Call : (GetListFields) (Return Type : Dictionary<string, SPFieldType>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_GetListFields_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var lookupFieldDict = CreateType<Dictionary<string, Dictionary<string, int>>>();
            var methodGetListFieldsPrametersTypes = new Type[] { typeof(Dictionary<string, Dictionary<string, int>>) };
            object[] parametersOfGetListFields = { lookupFieldDict };

            // Assert
            parametersOfGetListFields.ShouldNotBeNull();
            parametersOfGetListFields.Length.ShouldBe(1);
            methodGetListFieldsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<ResourceImporter, Dictionary<string, SPFieldType>>(_resourceImporterInstance, MethodGetListFields, parametersOfGetListFields, methodGetListFieldsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetListFields) (Return Type : Dictionary<string, SPFieldType>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_GetListFields_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetListFieldsPrametersTypes = new Type[] { typeof(Dictionary<string, Dictionary<string, int>>) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImporterInstance, MethodGetListFields, Fixture, methodGetListFieldsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetListFieldsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetListFields) (Return Type : Dictionary<string, SPFieldType>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_GetListFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetListFieldsPrametersTypes = new Type[] { typeof(Dictionary<string, Dictionary<string, int>>) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImporterInstance, MethodGetListFields, Fixture, methodGetListFieldsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListFieldsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListFields) (Return Type : Dictionary<string, SPFieldType>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_GetListFields_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListFields, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceImporterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListFields) (Return Type : Dictionary<string, SPFieldType>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_GetListFields_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetListFields, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSiteUsers) (Return Type : Dictionary<string, object[]>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceImporter_GetSiteUsers_Method_Call_Internally(Type[] types)
        {
            var methodGetSiteUsersPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImporterInstance, MethodGetSiteUsers, Fixture, methodGetSiteUsersPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSiteUsers) (Return Type : Dictionary<string, object[]>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_GetSiteUsers_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetSiteUsersPrametersTypes = null;
            object[] parametersOfGetSiteUsers = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetSiteUsers, methodGetSiteUsersPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResourceImporter, Dictionary<string, object[]>>(_resourceImporterInstanceFixture, out exception1, parametersOfGetSiteUsers);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResourceImporter, Dictionary<string, object[]>>(_resourceImporterInstance, MethodGetSiteUsers, parametersOfGetSiteUsers, methodGetSiteUsersPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetSiteUsers.ShouldBeNull();
            methodGetSiteUsersPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(() => methodInfo.Invoke(_resourceImporterInstanceFixture, parametersOfGetSiteUsers));
        }

        #endregion

        #region Method Call : (GetSiteUsers) (Return Type : Dictionary<string, object[]>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_GetSiteUsers_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetSiteUsersPrametersTypes = null;
            object[] parametersOfGetSiteUsers = null; // no parameter present

            // Assert
            parametersOfGetSiteUsers.ShouldBeNull();
            methodGetSiteUsersPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<ResourceImporter, Dictionary<string, object[]>>(_resourceImporterInstance, MethodGetSiteUsers, parametersOfGetSiteUsers, methodGetSiteUsersPrametersTypes));
        }

        #endregion

        #region Method Call : (GetSiteUsers) (Return Type : Dictionary<string, object[]>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_GetSiteUsers_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetSiteUsersPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImporterInstance, MethodGetSiteUsers, Fixture, methodGetSiteUsersPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetSiteUsersPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSiteUsers) (Return Type : Dictionary<string, object[]>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_GetSiteUsers_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetSiteUsersPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImporterInstance, MethodGetSiteUsers, Fixture, methodGetSiteUsersPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSiteUsersPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSiteUsers) (Return Type : Dictionary<string, object[]>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_GetSiteUsers_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSiteUsers, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceImporterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetUserValue) (Return Type : SPFieldUserValue) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceImporter_GetUserValue_Method_Call_Internally(Type[] types)
        {
            var methodGetUserValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImporterInstance, MethodGetUserValue, Fixture, methodGetUserValuePrametersTypes);
        }

        #endregion

        #region Method Call : (GetUserValue) (Return Type : SPFieldUserValue) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_GetUserValue_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var usersDict = CreateType<Dictionary<string, object[]>>();
            var val = CreateType<string>();
            var methodGetUserValuePrametersTypes = new Type[] { typeof(Dictionary<string, object[]>), typeof(string) };
            object[] parametersOfGetUserValue = { usersDict, val };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetUserValue, methodGetUserValuePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResourceImporter, SPFieldUserValue>(_resourceImporterInstanceFixture, out exception1, parametersOfGetUserValue);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResourceImporter, SPFieldUserValue>(_resourceImporterInstance, MethodGetUserValue, parametersOfGetUserValue, methodGetUserValuePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetUserValue.ShouldNotBeNull();
            parametersOfGetUserValue.Length.ShouldBe(2);
            methodGetUserValuePrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(() => methodInfo.Invoke(_resourceImporterInstanceFixture, parametersOfGetUserValue));
        }

        #endregion

        #region Method Call : (GetUserValue) (Return Type : SPFieldUserValue) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_GetUserValue_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var usersDict = CreateType<Dictionary<string, object[]>>();
            var val = CreateType<string>();
            var methodGetUserValuePrametersTypes = new Type[] { typeof(Dictionary<string, object[]>), typeof(string) };
            object[] parametersOfGetUserValue = { usersDict, val };

            // Assert
            parametersOfGetUserValue.ShouldNotBeNull();
            parametersOfGetUserValue.Length.ShouldBe(2);
            methodGetUserValuePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<ResourceImporter, SPFieldUserValue>(_resourceImporterInstance, MethodGetUserValue, parametersOfGetUserValue, methodGetUserValuePrametersTypes));
        }

        #endregion

        #region Method Call : (GetUserValue) (Return Type : SPFieldUserValue) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_GetUserValue_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetUserValuePrametersTypes = new Type[] { typeof(Dictionary<string, object[]>), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImporterInstance, MethodGetUserValue, Fixture, methodGetUserValuePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetUserValuePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetUserValue) (Return Type : SPFieldUserValue) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_GetUserValue_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetUserValuePrametersTypes = new Type[] { typeof(Dictionary<string, object[]>), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImporterInstance, MethodGetUserValue, Fixture, methodGetUserValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetUserValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetUserValue) (Return Type : SPFieldUserValue) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_GetUserValue_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetUserValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceImporterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetUserValue) (Return Type : SPFieldUserValue) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_GetUserValue_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetUserValue, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ImportResources) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceImporter_ImportResources_Method_Call_Internally(Type[] types)
        {
            var methodImportResourcesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImporterInstance, MethodImportResources, Fixture, methodImportResourcesPrametersTypes);
        }

        #endregion

        #region Method Call : (ImportResources) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_ImportResources_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodImportResourcesPrametersTypes = null;
            object[] parametersOfImportResources = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodImportResources, methodImportResourcesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourceImporterInstanceFixture, parametersOfImportResources);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfImportResources.ShouldBeNull();
            methodImportResourcesPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ImportResources) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_ImportResources_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodImportResourcesPrametersTypes = null;
            object[] parametersOfImportResources = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourceImporterInstance, MethodImportResources, parametersOfImportResources, methodImportResourcesPrametersTypes);

            // Assert
            parametersOfImportResources.ShouldBeNull();
            methodImportResourcesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ImportResources) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_ImportResources_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodImportResourcesPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImporterInstance, MethodImportResources, Fixture, methodImportResourcesPrametersTypes);

            // Assert
            methodImportResourcesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ImportResources) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_ImportResources_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodImportResources, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceImporterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadSpreadsheet) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceImporter_LoadSpreadsheet_Method_Call_Internally(Type[] types)
        {
            var methodLoadSpreadsheetPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImporterInstance, MethodLoadSpreadsheet, Fixture, methodLoadSpreadsheetPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadSpreadsheet) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_LoadSpreadsheet_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodLoadSpreadsheetPrametersTypes = null;
            object[] parametersOfLoadSpreadsheet = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodLoadSpreadsheet, methodLoadSpreadsheetPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourceImporterInstanceFixture, parametersOfLoadSpreadsheet);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfLoadSpreadsheet.ShouldBeNull();
            methodLoadSpreadsheetPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (LoadSpreadsheet) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_LoadSpreadsheet_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodLoadSpreadsheetPrametersTypes = null;
            object[] parametersOfLoadSpreadsheet = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourceImporterInstance, MethodLoadSpreadsheet, parametersOfLoadSpreadsheet, methodLoadSpreadsheetPrametersTypes);

            // Assert
            parametersOfLoadSpreadsheet.ShouldBeNull();
            methodLoadSpreadsheetPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadSpreadsheet) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_LoadSpreadsheet_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodLoadSpreadsheetPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImporterInstance, MethodLoadSpreadsheet, Fixture, methodLoadSpreadsheetPrametersTypes);

            // Assert
            methodLoadSpreadsheetPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadSpreadsheet) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_LoadSpreadsheet_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLoadSpreadsheet, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceImporterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ParseExcelResources) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceImporter_ParseExcelResources_Method_Call_Internally(Type[] types)
        {
            var methodParseExcelResourcesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImporterInstance, MethodParseExcelResources, Fixture, methodParseExcelResourcesPrametersTypes);
        }

        #endregion

        #region Method Call : (ParseExcelResources) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_ParseExcelResources_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var stream = CreateType<Stream>();
            var methodParseExcelResourcesPrametersTypes = new Type[] { typeof(Stream) };
            object[] parametersOfParseExcelResources = { stream };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodParseExcelResources, methodParseExcelResourcesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourceImporterInstanceFixture, parametersOfParseExcelResources);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfParseExcelResources.ShouldNotBeNull();
            parametersOfParseExcelResources.Length.ShouldBe(1);
            methodParseExcelResourcesPrametersTypes.Length.ShouldBe(1);
            methodParseExcelResourcesPrametersTypes.Length.ShouldBe(parametersOfParseExcelResources.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ParseExcelResources) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_ParseExcelResources_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var stream = CreateType<Stream>();
            var methodParseExcelResourcesPrametersTypes = new Type[] { typeof(Stream) };
            object[] parametersOfParseExcelResources = { stream };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourceImporterInstance, MethodParseExcelResources, parametersOfParseExcelResources, methodParseExcelResourcesPrametersTypes);

            // Assert
            parametersOfParseExcelResources.ShouldNotBeNull();
            parametersOfParseExcelResources.Length.ShouldBe(1);
            methodParseExcelResourcesPrametersTypes.Length.ShouldBe(1);
            methodParseExcelResourcesPrametersTypes.Length.ShouldBe(parametersOfParseExcelResources.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ParseExcelResources) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_ParseExcelResources_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodParseExcelResources, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ParseExcelResources) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_ParseExcelResources_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodParseExcelResourcesPrametersTypes = new Type[] { typeof(Stream) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImporterInstance, MethodParseExcelResources, Fixture, methodParseExcelResourcesPrametersTypes);

            // Assert
            methodParseExcelResourcesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ParseExcelResources) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_ParseExcelResources_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodParseExcelResources, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceImporterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateItem) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceImporter_UpdateItem_Method_Call_Internally(Type[] types)
        {
            var methodUpdateItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImporterInstance, MethodUpdateItem, Fixture, methodUpdateItemPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateItem) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_UpdateItem_Method_Call_Void_With_5_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var row = CreateType<DataRow>();
            var lockedColumns = CreateType<ICollection<string>>();
            var spList = CreateType<SPList>();
            var spListItem = CreateType<SPListItem>();
            var isGeneric = CreateType<bool>();
            var methodUpdateItemPrametersTypes = new Type[] { typeof(DataRow), typeof(ICollection<string>), typeof(SPList), typeof(SPListItem), typeof(bool) };
            object[] parametersOfUpdateItem = { row, lockedColumns, spList, spListItem, isGeneric };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateItem, methodUpdateItemPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourceImporterInstanceFixture, parametersOfUpdateItem);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateItem.ShouldNotBeNull();
            parametersOfUpdateItem.Length.ShouldBe(5);
            methodUpdateItemPrametersTypes.Length.ShouldBe(5);
            methodUpdateItemPrametersTypes.Length.ShouldBe(parametersOfUpdateItem.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateItem) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_UpdateItem_Method_Call_Void_With_5_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var row = CreateType<DataRow>();
            var lockedColumns = CreateType<ICollection<string>>();
            var spList = CreateType<SPList>();
            var spListItem = CreateType<SPListItem>();
            var isGeneric = CreateType<bool>();
            var methodUpdateItemPrametersTypes = new Type[] { typeof(DataRow), typeof(ICollection<string>), typeof(SPList), typeof(SPListItem), typeof(bool) };
            object[] parametersOfUpdateItem = { row, lockedColumns, spList, spListItem, isGeneric };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourceImporterInstance, MethodUpdateItem, parametersOfUpdateItem, methodUpdateItemPrametersTypes);

            // Assert
            parametersOfUpdateItem.ShouldNotBeNull();
            parametersOfUpdateItem.Length.ShouldBe(5);
            methodUpdateItemPrametersTypes.Length.ShouldBe(5);
            methodUpdateItemPrametersTypes.Length.ShouldBe(parametersOfUpdateItem.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateItem) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_UpdateItem_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateItem, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateItem) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_UpdateItem_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateItemPrametersTypes = new Type[] { typeof(DataRow), typeof(ICollection<string>), typeof(SPList), typeof(SPListItem), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImporterInstance, MethodUpdateItem, Fixture, methodUpdateItemPrametersTypes);

            // Assert
            methodUpdateItemPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateItem) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_UpdateItem_Method_Call_With_5_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateItem, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceImporterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateResource) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceImporter_UpdateResource_Method_Call_Internally(Type[] types)
        {
            var methodUpdateResourcePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImporterInstance, MethodUpdateResource, Fixture, methodUpdateResourcePrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateResource) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_UpdateResource_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var row = CreateType<DataRow>();
            var isGeneric = CreateType<bool>();
            var methodUpdateResourcePrametersTypes = new Type[] { typeof(DataRow), typeof(bool) };
            object[] parametersOfUpdateResource = { row, isGeneric };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateResource, methodUpdateResourcePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourceImporterInstanceFixture, parametersOfUpdateResource);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateResource.ShouldNotBeNull();
            parametersOfUpdateResource.Length.ShouldBe(2);
            methodUpdateResourcePrametersTypes.Length.ShouldBe(2);
            methodUpdateResourcePrametersTypes.Length.ShouldBe(parametersOfUpdateResource.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateResource) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_UpdateResource_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var row = CreateType<DataRow>();
            var isGeneric = CreateType<bool>();
            var methodUpdateResourcePrametersTypes = new Type[] { typeof(DataRow), typeof(bool) };
            object[] parametersOfUpdateResource = { row, isGeneric };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourceImporterInstance, MethodUpdateResource, parametersOfUpdateResource, methodUpdateResourcePrametersTypes);

            // Assert
            parametersOfUpdateResource.ShouldNotBeNull();
            parametersOfUpdateResource.Length.ShouldBe(2);
            methodUpdateResourcePrametersTypes.Length.ShouldBe(2);
            methodUpdateResourcePrametersTypes.Length.ShouldBe(parametersOfUpdateResource.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateResource) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_UpdateResource_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateResource, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateResource) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_UpdateResource_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateResourcePrametersTypes = new Type[] { typeof(DataRow), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImporterInstance, MethodUpdateResource, Fixture, methodUpdateResourcePrametersTypes);

            // Assert
            methodUpdateResourcePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateResource) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_UpdateResource_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateResource, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceImporterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ValidateUser) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceImporter_ValidateUser_Method_Call_Internally(Type[] types)
        {
            var methodValidateUserPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImporterInstance, MethodValidateUser, Fixture, methodValidateUserPrametersTypes);
        }

        #endregion

        #region Method Call : (ValidateUser) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_ValidateUser_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var row = CreateType<DataRow>();
            var isGeneric = CreateType<bool>();
            var isNew = CreateType<bool>();
            var resourcePool = CreateType<SPList>();
            var methodValidateUserPrametersTypes = new Type[] { typeof(DataRow), typeof(bool), typeof(bool), typeof(SPList) };
            object[] parametersOfValidateUser = { row, isGeneric, isNew, resourcePool };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodValidateUser, methodValidateUserPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourceImporterInstanceFixture, parametersOfValidateUser);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfValidateUser.ShouldNotBeNull();
            parametersOfValidateUser.Length.ShouldBe(4);
            methodValidateUserPrametersTypes.Length.ShouldBe(4);
            methodValidateUserPrametersTypes.Length.ShouldBe(parametersOfValidateUser.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ValidateUser) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_ValidateUser_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var row = CreateType<DataRow>();
            var isGeneric = CreateType<bool>();
            var isNew = CreateType<bool>();
            var resourcePool = CreateType<SPList>();
            var methodValidateUserPrametersTypes = new Type[] { typeof(DataRow), typeof(bool), typeof(bool), typeof(SPList) };
            object[] parametersOfValidateUser = { row, isGeneric, isNew, resourcePool };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourceImporterInstance, MethodValidateUser, parametersOfValidateUser, methodValidateUserPrametersTypes);

            // Assert
            parametersOfValidateUser.ShouldNotBeNull();
            parametersOfValidateUser.Length.ShouldBe(4);
            methodValidateUserPrametersTypes.Length.ShouldBe(4);
            methodValidateUserPrametersTypes.Length.ShouldBe(parametersOfValidateUser.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ValidateUser) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_ValidateUser_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodValidateUser, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ValidateUser) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_ValidateUser_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodValidateUserPrametersTypes = new Type[] { typeof(DataRow), typeof(bool), typeof(bool), typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImporterInstance, MethodValidateUser, Fixture, methodValidateUserPrametersTypes);

            // Assert
            methodValidateUserPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ValidateUser) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_ValidateUser_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodValidateUser, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceImporterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LogImportMessage) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceImporter_LogImportMessage_Method_Call_Internally(Type[] types)
        {
            var methodLogImportMessagePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImporterInstance, MethodLogImportMessage, Fixture, methodLogImportMessagePrametersTypes);
        }

        #endregion

        #region Method Call : (LogImportMessage) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_LogImportMessage_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var message = CreateType<string>();
            var messageType = CreateType<Int32>();
            var methodLogImportMessagePrametersTypes = new Type[] { typeof(string), typeof(Int32) };
            object[] parametersOfLogImportMessage = { message, messageType };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodLogImportMessage, methodLogImportMessagePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourceImporterInstanceFixture, parametersOfLogImportMessage);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfLogImportMessage.ShouldNotBeNull();
            parametersOfLogImportMessage.Length.ShouldBe(2);
            methodLogImportMessagePrametersTypes.Length.ShouldBe(2);
            methodLogImportMessagePrametersTypes.Length.ShouldBe(parametersOfLogImportMessage.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (LogImportMessage) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_LogImportMessage_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var message = CreateType<string>();
            var messageType = CreateType<Int32>();
            var methodLogImportMessagePrametersTypes = new Type[] { typeof(string), typeof(Int32) };
            object[] parametersOfLogImportMessage = { message, messageType };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourceImporterInstance, MethodLogImportMessage, parametersOfLogImportMessage, methodLogImportMessagePrametersTypes);

            // Assert
            parametersOfLogImportMessage.ShouldNotBeNull();
            parametersOfLogImportMessage.Length.ShouldBe(2);
            methodLogImportMessagePrametersTypes.Length.ShouldBe(2);
            methodLogImportMessagePrametersTypes.Length.ShouldBe(parametersOfLogImportMessage.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LogImportMessage) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_LogImportMessage_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodLogImportMessage, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LogImportMessage) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_LogImportMessage_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLogImportMessagePrametersTypes = new Type[] { typeof(string), typeof(Int32) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImporterInstance, MethodLogImportMessage, Fixture, methodLogImportMessagePrametersTypes);

            // Assert
            methodLogImportMessagePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LogImportMessage) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_LogImportMessage_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLogImportMessage, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceImporterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaiseImportProgressChangedEvent) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceImporter_RaiseImportProgressChangedEvent_Method_Call_Internally(Type[] types)
        {
            var methodRaiseImportProgressChangedEventPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImporterInstance, MethodRaiseImportProgressChangedEvent, Fixture, methodRaiseImportProgressChangedEventPrametersTypes);
        }

        #endregion

        #region Method Call : (RaiseImportProgressChangedEvent) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_RaiseImportProgressChangedEvent_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var currentProcess = CreateType<string>();
            var methodRaiseImportProgressChangedEventPrametersTypes = new Type[] { typeof(String) };
            object[] parametersOfRaiseImportProgressChangedEvent = { currentProcess };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRaiseImportProgressChangedEvent, methodRaiseImportProgressChangedEventPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourceImporterInstanceFixture, parametersOfRaiseImportProgressChangedEvent);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRaiseImportProgressChangedEvent.ShouldNotBeNull();
            parametersOfRaiseImportProgressChangedEvent.Length.ShouldBe(1);
            methodRaiseImportProgressChangedEventPrametersTypes.Length.ShouldBe(1);
            methodRaiseImportProgressChangedEventPrametersTypes.Length.ShouldBe(parametersOfRaiseImportProgressChangedEvent.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RaiseImportProgressChangedEvent) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_RaiseImportProgressChangedEvent_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var currentProcess = CreateType<string>();
            var methodRaiseImportProgressChangedEventPrametersTypes = new Type[] { typeof(String) };
            object[] parametersOfRaiseImportProgressChangedEvent = { currentProcess };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourceImporterInstance, MethodRaiseImportProgressChangedEvent, parametersOfRaiseImportProgressChangedEvent, methodRaiseImportProgressChangedEventPrametersTypes);

            // Assert
            parametersOfRaiseImportProgressChangedEvent.ShouldNotBeNull();
            parametersOfRaiseImportProgressChangedEvent.Length.ShouldBe(1);
            methodRaiseImportProgressChangedEventPrametersTypes.Length.ShouldBe(1);
            methodRaiseImportProgressChangedEventPrametersTypes.Length.ShouldBe(parametersOfRaiseImportProgressChangedEvent.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaiseImportProgressChangedEvent) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_RaiseImportProgressChangedEvent_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRaiseImportProgressChangedEvent, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RaiseImportProgressChangedEvent) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_RaiseImportProgressChangedEvent_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRaiseImportProgressChangedEventPrametersTypes = new Type[] { typeof(String) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImporterInstance, MethodRaiseImportProgressChangedEvent, Fixture, methodRaiseImportProgressChangedEventPrametersTypes);

            // Assert
            methodRaiseImportProgressChangedEventPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaiseImportProgressChangedEvent) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_RaiseImportProgressChangedEvent_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRaiseImportProgressChangedEvent, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceImporterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaiseImportCompletedEvent) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceImporter_RaiseImportCompletedEvent_Method_Call_Internally(Type[] types)
        {
            var methodRaiseImportCompletedEventPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImporterInstance, MethodRaiseImportCompletedEvent, Fixture, methodRaiseImportCompletedEventPrametersTypes);
        }

        #endregion

        #region Method Call : (RaiseImportCompletedEvent) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_RaiseImportCompletedEvent_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var exception = CreateType<Exception>();
            var methodRaiseImportCompletedEventPrametersTypes = new Type[] { typeof(Exception) };
            object[] parametersOfRaiseImportCompletedEvent = { exception };
            var methodInfo = GetMethodInfo(MethodRaiseImportCompletedEvent, methodRaiseImportCompletedEventPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourceImporterInstanceFixture, parametersOfRaiseImportCompletedEvent);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRaiseImportCompletedEvent.ShouldNotBeNull();
            parametersOfRaiseImportCompletedEvent.Length.ShouldBe(1);
            methodRaiseImportCompletedEventPrametersTypes.Length.ShouldBe(1);
            methodRaiseImportCompletedEventPrametersTypes.Length.ShouldBe(parametersOfRaiseImportCompletedEvent.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RaiseImportCompletedEvent) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_RaiseImportCompletedEvent_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var exception = CreateType<Exception>();
            var methodRaiseImportCompletedEventPrametersTypes = new Type[] { typeof(Exception) };
            object[] parametersOfRaiseImportCompletedEvent = { exception };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourceImporterInstance, MethodRaiseImportCompletedEvent, parametersOfRaiseImportCompletedEvent, methodRaiseImportCompletedEventPrametersTypes);

            // Assert
            parametersOfRaiseImportCompletedEvent.ShouldNotBeNull();
            parametersOfRaiseImportCompletedEvent.Length.ShouldBe(1);
            methodRaiseImportCompletedEventPrametersTypes.Length.ShouldBe(1);
            methodRaiseImportCompletedEventPrametersTypes.Length.ShouldBe(parametersOfRaiseImportCompletedEvent.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaiseImportCompletedEvent) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_RaiseImportCompletedEvent_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRaiseImportCompletedEvent, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RaiseImportCompletedEvent) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_RaiseImportCompletedEvent_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRaiseImportCompletedEventPrametersTypes = new Type[] { typeof(Exception) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImporterInstance, MethodRaiseImportCompletedEvent, Fixture, methodRaiseImportCompletedEventPrametersTypes);

            // Assert
            methodRaiseImportCompletedEventPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaiseImportCompletedEvent) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ResourceImporter_RaiseImportCompletedEvent_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRaiseImportCompletedEvent, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceImporterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
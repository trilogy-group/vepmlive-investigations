using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Web.UI.WebControls;
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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.getlistreportitems" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class GetlistreportitemsTest : AbstractBaseSetupTypedTest<getlistreportitems>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (getlistreportitems) Initializer

        private const string MethodOnLoad = "OnLoad";
        private const string MethodpopulateFieldsFromEncryptedData = "populateFieldsFromEncryptedData";
        private const string MethodGetXmlForReportItems = "GetXmlForReportItems";
        private const string MethodGetXmlForNonReportItems = "GetXmlForNonReportItems";
        private const string MethodViewShouldBeIncludedInResults = "ViewShouldBeIncludedInResults";
        private const string MethodCreateColumnNode = "CreateColumnNode";
        private const string MethodCreateHeadNode = "CreateHeadNode";
        private const string MethodGetListNamesInHashtable = "GetListNamesInHashtable";
        private const string MethodGetSSRSReportTree = "GetSSRSReportTree";
        private const string MethodGetItemsNativeMode = "GetItemsNativeMode";
        private const string MethodPopulateTreeNativeMode = "PopulateTreeNativeMode";
        private const string MethodGetSharepointItems = "GetSharepointItems";
        private const string MethodAddSSRSReportLinks = "AddSSRSReportLinks";
        private const string MethodLoadTreeForSsrs = "LoadTreeForSsrs";
        private const string MethodPopulateTree = "PopulateTree";
        private const string MethodGetCredentials = "GetCredentials";
        private const string Field_displayListNames = "_displayListNames";
        private const string Field_viewLists = "_viewLists";
        private const string Field_reportsRootFolderName = "_reportsRootFolderName";
        private const string Field_reportingServicesUrl = "_reportingServicesUrl";
        private const string Field_isIntegrated = "_isIntegrated";
        private const string Field_reportsFolderName = "_reportsFolderName";
        private const string Field_isSsrs = "_isSsrs";
        private const string FieldFOLDER_TYPE_NAME = "FOLDER_TYPE_NAME";
        private const string FieldREPORT_TYPE_NAME = "REPORT_TYPE_NAME";
        private Type _getlistreportitemsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private getlistreportitems _getlistreportitemsInstance;
        private getlistreportitems _getlistreportitemsInstanceFixture;

        #region General Initializer : Class (getlistreportitems) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="getlistreportitems" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _getlistreportitemsInstanceType = typeof(getlistreportitems);
            _getlistreportitemsInstanceFixture = Create(true);
            _getlistreportitemsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (getlistreportitems)

        #region General Initializer : Class (getlistreportitems) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="getlistreportitems" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodOnLoad, 0)]
        [TestCase(MethodpopulateFieldsFromEncryptedData, 0)]
        [TestCase(MethodGetXmlForReportItems, 0)]
        [TestCase(MethodGetXmlForNonReportItems, 0)]
        [TestCase(MethodViewShouldBeIncludedInResults, 0)]
        [TestCase(MethodCreateColumnNode, 0)]
        [TestCase(MethodCreateHeadNode, 0)]
        [TestCase(MethodGetListNamesInHashtable, 0)]
        [TestCase(MethodGetSSRSReportTree, 0)]
        [TestCase(MethodGetItemsNativeMode, 0)]
        [TestCase(MethodPopulateTreeNativeMode, 0)]
        [TestCase(MethodGetSharepointItems, 0)]
        [TestCase(MethodAddSSRSReportLinks, 0)]
        [TestCase(MethodLoadTreeForSsrs, 0)]
        [TestCase(MethodPopulateTree, 0)]
        [TestCase(MethodGetCredentials, 0)]
        public void AUT_Getlistreportitems_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_getlistreportitemsInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (getlistreportitems) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="getlistreportitems" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_displayListNames)]
        [TestCase(Field_viewLists)]
        [TestCase(Field_reportsRootFolderName)]
        [TestCase(Field_reportingServicesUrl)]
        [TestCase(Field_isIntegrated)]
        [TestCase(Field_reportsFolderName)]
        [TestCase(Field_isSsrs)]
        [TestCase(FieldFOLDER_TYPE_NAME)]
        [TestCase(FieldREPORT_TYPE_NAME)]
        public void AUT_Getlistreportitems_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_getlistreportitemsInstanceFixture, 
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
        ///     Class (<see cref="getlistreportitems" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Getlistreportitems_Is_Instance_Present_Test()
        {
            // Assert
            _getlistreportitemsInstanceType.ShouldNotBeNull();
            _getlistreportitemsInstance.ShouldNotBeNull();
            _getlistreportitemsInstanceFixture.ShouldNotBeNull();
            _getlistreportitemsInstance.ShouldBeAssignableTo<getlistreportitems>();
            _getlistreportitemsInstanceFixture.ShouldBeAssignableTo<getlistreportitems>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (getlistreportitems) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_getlistreportitems_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            getlistreportitems instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _getlistreportitemsInstanceType.ShouldNotBeNull();
            _getlistreportitemsInstance.ShouldNotBeNull();
            _getlistreportitemsInstanceFixture.ShouldNotBeNull();
            _getlistreportitemsInstance.ShouldBeAssignableTo<getlistreportitems>();
            _getlistreportitemsInstanceFixture.ShouldBeAssignableTo<getlistreportitems>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="getlistreportitems" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodViewShouldBeIncludedInResults)]
        [TestCase(MethodCreateColumnNode)]
        [TestCase(MethodCreateHeadNode)]
        [TestCase(MethodAddSSRSReportLinks)]
        [TestCase(MethodGetCredentials)]
        public void AUT_Getlistreportitems_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_getlistreportitemsInstanceFixture,
                                                                              _getlistreportitemsInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="getlistreportitems" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodOnLoad)]
        [TestCase(MethodpopulateFieldsFromEncryptedData)]
        [TestCase(MethodGetXmlForReportItems)]
        [TestCase(MethodGetXmlForNonReportItems)]
        [TestCase(MethodGetListNamesInHashtable)]
        [TestCase(MethodGetSSRSReportTree)]
        [TestCase(MethodGetItemsNativeMode)]
        [TestCase(MethodPopulateTreeNativeMode)]
        [TestCase(MethodGetSharepointItems)]
        [TestCase(MethodLoadTreeForSsrs)]
        [TestCase(MethodPopulateTree)]
        public void AUT_Getlistreportitems_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<getlistreportitems>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getlistreportitems_OnLoad_Method_Call_Internally(Type[] types)
        {
            var methodOnLoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getlistreportitemsInstance, MethodOnLoad, Fixture, methodOnLoadPrametersTypes);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_OnLoad_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnLoadPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnLoad = { e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnLoad, methodOnLoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getlistreportitemsInstanceFixture, parametersOfOnLoad);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOnLoad.ShouldNotBeNull();
            parametersOfOnLoad.Length.ShouldBe(1);
            methodOnLoadPrametersTypes.Length.ShouldBe(1);
            methodOnLoadPrametersTypes.Length.ShouldBe(parametersOfOnLoad.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_OnLoad_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnLoadPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnLoad = { e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getlistreportitemsInstance, MethodOnLoad, parametersOfOnLoad, methodOnLoadPrametersTypes);

            // Assert
            parametersOfOnLoad.ShouldNotBeNull();
            parametersOfOnLoad.Length.ShouldBe(1);
            methodOnLoadPrametersTypes.Length.ShouldBe(1);
            methodOnLoadPrametersTypes.Length.ShouldBe(parametersOfOnLoad.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_OnLoad_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOnLoad, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_OnLoad_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnLoadPrametersTypes = new Type[] { typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getlistreportitemsInstance, MethodOnLoad, Fixture, methodOnLoadPrametersTypes);

            // Assert
            methodOnLoadPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_OnLoad_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnLoad, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getlistreportitemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (populateFieldsFromEncryptedData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getlistreportitems_populateFieldsFromEncryptedData_Method_Call_Internally(Type[] types)
        {
            var methodpopulateFieldsFromEncryptedDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getlistreportitemsInstance, MethodpopulateFieldsFromEncryptedData, Fixture, methodpopulateFieldsFromEncryptedDataPrametersTypes);
        }

        #endregion

        #region Method Call : (populateFieldsFromEncryptedData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_populateFieldsFromEncryptedData_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var base64EncryptedData = CreateType<string>();
            var methodpopulateFieldsFromEncryptedDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfpopulateFieldsFromEncryptedData = { base64EncryptedData };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodpopulateFieldsFromEncryptedData, methodpopulateFieldsFromEncryptedDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getlistreportitemsInstanceFixture, parametersOfpopulateFieldsFromEncryptedData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfpopulateFieldsFromEncryptedData.ShouldNotBeNull();
            parametersOfpopulateFieldsFromEncryptedData.Length.ShouldBe(1);
            methodpopulateFieldsFromEncryptedDataPrametersTypes.Length.ShouldBe(1);
            methodpopulateFieldsFromEncryptedDataPrametersTypes.Length.ShouldBe(parametersOfpopulateFieldsFromEncryptedData.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (populateFieldsFromEncryptedData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_populateFieldsFromEncryptedData_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var base64EncryptedData = CreateType<string>();
            var methodpopulateFieldsFromEncryptedDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfpopulateFieldsFromEncryptedData = { base64EncryptedData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getlistreportitemsInstance, MethodpopulateFieldsFromEncryptedData, parametersOfpopulateFieldsFromEncryptedData, methodpopulateFieldsFromEncryptedDataPrametersTypes);

            // Assert
            parametersOfpopulateFieldsFromEncryptedData.ShouldNotBeNull();
            parametersOfpopulateFieldsFromEncryptedData.Length.ShouldBe(1);
            methodpopulateFieldsFromEncryptedDataPrametersTypes.Length.ShouldBe(1);
            methodpopulateFieldsFromEncryptedDataPrametersTypes.Length.ShouldBe(parametersOfpopulateFieldsFromEncryptedData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (populateFieldsFromEncryptedData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_populateFieldsFromEncryptedData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodpopulateFieldsFromEncryptedData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (populateFieldsFromEncryptedData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_populateFieldsFromEncryptedData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodpopulateFieldsFromEncryptedDataPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getlistreportitemsInstance, MethodpopulateFieldsFromEncryptedData, Fixture, methodpopulateFieldsFromEncryptedDataPrametersTypes);

            // Assert
            methodpopulateFieldsFromEncryptedDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (populateFieldsFromEncryptedData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_populateFieldsFromEncryptedData_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodpopulateFieldsFromEncryptedData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getlistreportitemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetXmlForReportItems) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getlistreportitems_GetXmlForReportItems_Method_Call_Internally(Type[] types)
        {
            var methodGetXmlForReportItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getlistreportitemsInstance, MethodGetXmlForReportItems, Fixture, methodGetXmlForReportItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetXmlForReportItems) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_GetXmlForReportItems_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetXmlForReportItemsPrametersTypes = null;
            object[] parametersOfGetXmlForReportItems = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetXmlForReportItems, methodGetXmlForReportItemsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<getlistreportitems, string>(_getlistreportitemsInstanceFixture, out exception1, parametersOfGetXmlForReportItems);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<getlistreportitems, string>(_getlistreportitemsInstance, MethodGetXmlForReportItems, parametersOfGetXmlForReportItems, methodGetXmlForReportItemsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetXmlForReportItems.ShouldBeNull();
            methodGetXmlForReportItemsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetXmlForReportItems) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_GetXmlForReportItems_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetXmlForReportItemsPrametersTypes = null;
            object[] parametersOfGetXmlForReportItems = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getlistreportitems, string>(_getlistreportitemsInstance, MethodGetXmlForReportItems, parametersOfGetXmlForReportItems, methodGetXmlForReportItemsPrametersTypes);

            // Assert
            parametersOfGetXmlForReportItems.ShouldBeNull();
            methodGetXmlForReportItemsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetXmlForReportItems) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_GetXmlForReportItems_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetXmlForReportItemsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getlistreportitemsInstance, MethodGetXmlForReportItems, Fixture, methodGetXmlForReportItemsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetXmlForReportItemsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetXmlForReportItems) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_GetXmlForReportItems_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetXmlForReportItemsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getlistreportitemsInstance, MethodGetXmlForReportItems, Fixture, methodGetXmlForReportItemsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetXmlForReportItemsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetXmlForReportItems) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_GetXmlForReportItems_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetXmlForReportItems, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getlistreportitemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetXmlForNonReportItems) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getlistreportitems_GetXmlForNonReportItems_Method_Call_Internally(Type[] types)
        {
            var methodGetXmlForNonReportItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getlistreportitemsInstance, MethodGetXmlForNonReportItems, Fixture, methodGetXmlForNonReportItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetXmlForNonReportItems) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_GetXmlForNonReportItems_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetXmlForNonReportItemsPrametersTypes = null;
            object[] parametersOfGetXmlForNonReportItems = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetXmlForNonReportItems, methodGetXmlForNonReportItemsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<getlistreportitems, string>(_getlistreportitemsInstanceFixture, out exception1, parametersOfGetXmlForNonReportItems);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<getlistreportitems, string>(_getlistreportitemsInstance, MethodGetXmlForNonReportItems, parametersOfGetXmlForNonReportItems, methodGetXmlForNonReportItemsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetXmlForNonReportItems.ShouldBeNull();
            methodGetXmlForNonReportItemsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetXmlForNonReportItems) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_GetXmlForNonReportItems_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetXmlForNonReportItemsPrametersTypes = null;
            object[] parametersOfGetXmlForNonReportItems = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getlistreportitems, string>(_getlistreportitemsInstance, MethodGetXmlForNonReportItems, parametersOfGetXmlForNonReportItems, methodGetXmlForNonReportItemsPrametersTypes);

            // Assert
            parametersOfGetXmlForNonReportItems.ShouldBeNull();
            methodGetXmlForNonReportItemsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetXmlForNonReportItems) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_GetXmlForNonReportItems_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetXmlForNonReportItemsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getlistreportitemsInstance, MethodGetXmlForNonReportItems, Fixture, methodGetXmlForNonReportItemsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetXmlForNonReportItemsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetXmlForNonReportItems) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_GetXmlForNonReportItems_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetXmlForNonReportItemsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getlistreportitemsInstance, MethodGetXmlForNonReportItems, Fixture, methodGetXmlForNonReportItemsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetXmlForNonReportItemsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetXmlForNonReportItems) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_GetXmlForNonReportItems_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetXmlForNonReportItems, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getlistreportitemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ViewShouldBeIncludedInResults) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getlistreportitems_ViewShouldBeIncludedInResults_Static_Method_Call_Internally(Type[] types)
        {
            var methodViewShouldBeIncludedInResultsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_getlistreportitemsInstanceFixture, _getlistreportitemsInstanceType, MethodViewShouldBeIncludedInResults, Fixture, methodViewShouldBeIncludedInResultsPrametersTypes);
        }

        #endregion

        #region Method Call : (ViewShouldBeIncludedInResults) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_ViewShouldBeIncludedInResults_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spView = CreateType<SPView>();
            var methodViewShouldBeIncludedInResultsPrametersTypes = new Type[] { typeof(SPView) };
            object[] parametersOfViewShouldBeIncludedInResults = { spView };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_getlistreportitemsInstanceFixture, _getlistreportitemsInstanceType, MethodViewShouldBeIncludedInResults, parametersOfViewShouldBeIncludedInResults, methodViewShouldBeIncludedInResultsPrametersTypes);

            // Assert
            parametersOfViewShouldBeIncludedInResults.ShouldNotBeNull();
            parametersOfViewShouldBeIncludedInResults.Length.ShouldBe(1);
            methodViewShouldBeIncludedInResultsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ViewShouldBeIncludedInResults) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_ViewShouldBeIncludedInResults_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodViewShouldBeIncludedInResultsPrametersTypes = new Type[] { typeof(SPView) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_getlistreportitemsInstanceFixture, _getlistreportitemsInstanceType, MethodViewShouldBeIncludedInResults, Fixture, methodViewShouldBeIncludedInResultsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodViewShouldBeIncludedInResultsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ViewShouldBeIncludedInResults) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_ViewShouldBeIncludedInResults_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodViewShouldBeIncludedInResults, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getlistreportitemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ViewShouldBeIncludedInResults) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_ViewShouldBeIncludedInResults_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodViewShouldBeIncludedInResults, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateColumnNode) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getlistreportitems_CreateColumnNode_Static_Method_Call_Internally(Type[] types)
        {
            var methodCreateColumnNodePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_getlistreportitemsInstanceFixture, _getlistreportitemsInstanceType, MethodCreateColumnNode, Fixture, methodCreateColumnNodePrametersTypes);
        }

        #endregion

        #region Method Call : (CreateColumnNode) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_CreateColumnNode_Static_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var headNode = CreateType<XmlNode>();
            var xmlDocument = CreateType<XmlDocument>();
            var methodCreateColumnNodePrametersTypes = new Type[] { typeof(XmlNode), typeof(XmlDocument) };
            object[] parametersOfCreateColumnNode = { headNode, xmlDocument };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateColumnNode, methodCreateColumnNodePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getlistreportitemsInstanceFixture, parametersOfCreateColumnNode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateColumnNode.ShouldNotBeNull();
            parametersOfCreateColumnNode.Length.ShouldBe(2);
            methodCreateColumnNodePrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CreateColumnNode) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_CreateColumnNode_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var headNode = CreateType<XmlNode>();
            var xmlDocument = CreateType<XmlDocument>();
            var methodCreateColumnNodePrametersTypes = new Type[] { typeof(XmlNode), typeof(XmlDocument) };
            object[] parametersOfCreateColumnNode = { headNode, xmlDocument };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_getlistreportitemsInstanceFixture, _getlistreportitemsInstanceType, MethodCreateColumnNode, parametersOfCreateColumnNode, methodCreateColumnNodePrametersTypes);

            // Assert
            parametersOfCreateColumnNode.ShouldNotBeNull();
            parametersOfCreateColumnNode.Length.ShouldBe(2);
            methodCreateColumnNodePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateColumnNode) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_CreateColumnNode_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreateColumnNode, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateColumnNode) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_CreateColumnNode_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateColumnNodePrametersTypes = new Type[] { typeof(XmlNode), typeof(XmlDocument) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_getlistreportitemsInstanceFixture, _getlistreportitemsInstanceType, MethodCreateColumnNode, Fixture, methodCreateColumnNodePrametersTypes);

            // Assert
            methodCreateColumnNodePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateColumnNode) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_CreateColumnNode_Static_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateColumnNode, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getlistreportitemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateHeadNode) (Return Type : XmlNode) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getlistreportitems_CreateHeadNode_Static_Method_Call_Internally(Type[] types)
        {
            var methodCreateHeadNodePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_getlistreportitemsInstanceFixture, _getlistreportitemsInstanceType, MethodCreateHeadNode, Fixture, methodCreateHeadNodePrametersTypes);
        }

        #endregion

        #region Method Call : (CreateHeadNode) (Return Type : XmlNode) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_CreateHeadNode_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var mainNode = CreateType<XmlNode>();
            var xmlDocument = CreateType<XmlDocument>();
            var methodCreateHeadNodePrametersTypes = new Type[] { typeof(XmlNode), typeof(XmlDocument) };
            object[] parametersOfCreateHeadNode = { mainNode, xmlDocument };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateHeadNode, methodCreateHeadNodePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_getlistreportitemsInstanceFixture, _getlistreportitemsInstanceType, MethodCreateHeadNode, Fixture, methodCreateHeadNodePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<XmlNode>(_getlistreportitemsInstanceFixture, _getlistreportitemsInstanceType, MethodCreateHeadNode, parametersOfCreateHeadNode, methodCreateHeadNodePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_getlistreportitemsInstanceFixture, parametersOfCreateHeadNode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfCreateHeadNode.ShouldNotBeNull();
            parametersOfCreateHeadNode.Length.ShouldBe(2);
            methodCreateHeadNodePrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CreateHeadNode) (Return Type : XmlNode) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_CreateHeadNode_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var mainNode = CreateType<XmlNode>();
            var xmlDocument = CreateType<XmlDocument>();
            var methodCreateHeadNodePrametersTypes = new Type[] { typeof(XmlNode), typeof(XmlDocument) };
            object[] parametersOfCreateHeadNode = { mainNode, xmlDocument };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<XmlNode>(_getlistreportitemsInstanceFixture, _getlistreportitemsInstanceType, MethodCreateHeadNode, parametersOfCreateHeadNode, methodCreateHeadNodePrametersTypes);

            // Assert
            parametersOfCreateHeadNode.ShouldNotBeNull();
            parametersOfCreateHeadNode.Length.ShouldBe(2);
            methodCreateHeadNodePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateHeadNode) (Return Type : XmlNode) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_CreateHeadNode_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCreateHeadNodePrametersTypes = new Type[] { typeof(XmlNode), typeof(XmlDocument) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_getlistreportitemsInstanceFixture, _getlistreportitemsInstanceType, MethodCreateHeadNode, Fixture, methodCreateHeadNodePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCreateHeadNodePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (CreateHeadNode) (Return Type : XmlNode) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_CreateHeadNode_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateHeadNodePrametersTypes = new Type[] { typeof(XmlNode), typeof(XmlDocument) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_getlistreportitemsInstanceFixture, _getlistreportitemsInstanceType, MethodCreateHeadNode, Fixture, methodCreateHeadNodePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreateHeadNodePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateHeadNode) (Return Type : XmlNode) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_CreateHeadNode_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateHeadNode, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getlistreportitemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateHeadNode) (Return Type : XmlNode) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_CreateHeadNode_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreateHeadNode, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListNamesInHashtable) (Return Type : Hashtable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getlistreportitems_GetListNamesInHashtable_Method_Call_Internally(Type[] types)
        {
            var methodGetListNamesInHashtablePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getlistreportitemsInstance, MethodGetListNamesInHashtable, Fixture, methodGetListNamesInHashtablePrametersTypes);
        }

        #endregion

        #region Method Call : (GetListNamesInHashtable) (Return Type : Hashtable) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_GetListNamesInHashtable_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sortListName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _getlistreportitemsInstance.GetListNamesInHashtable(sortListName);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetListNamesInHashtable) (Return Type : Hashtable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_GetListNamesInHashtable_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sortListName = CreateType<string>();
            var methodGetListNamesInHashtablePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetListNamesInHashtable = { sortListName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetListNamesInHashtable, methodGetListNamesInHashtablePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<getlistreportitems, Hashtable>(_getlistreportitemsInstanceFixture, out exception1, parametersOfGetListNamesInHashtable);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<getlistreportitems, Hashtable>(_getlistreportitemsInstance, MethodGetListNamesInHashtable, parametersOfGetListNamesInHashtable, methodGetListNamesInHashtablePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetListNamesInHashtable.ShouldNotBeNull();
            parametersOfGetListNamesInHashtable.Length.ShouldBe(1);
            methodGetListNamesInHashtablePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetListNamesInHashtable) (Return Type : Hashtable) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_GetListNamesInHashtable_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sortListName = CreateType<string>();
            var methodGetListNamesInHashtablePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetListNamesInHashtable = { sortListName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetListNamesInHashtable, methodGetListNamesInHashtablePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getlistreportitemsInstanceFixture, parametersOfGetListNamesInHashtable);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetListNamesInHashtable.ShouldNotBeNull();
            parametersOfGetListNamesInHashtable.Length.ShouldBe(1);
            methodGetListNamesInHashtablePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListNamesInHashtable) (Return Type : Hashtable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_GetListNamesInHashtable_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sortListName = CreateType<string>();
            var methodGetListNamesInHashtablePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetListNamesInHashtable = { sortListName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getlistreportitems, Hashtable>(_getlistreportitemsInstance, MethodGetListNamesInHashtable, parametersOfGetListNamesInHashtable, methodGetListNamesInHashtablePrametersTypes);

            // Assert
            parametersOfGetListNamesInHashtable.ShouldNotBeNull();
            parametersOfGetListNamesInHashtable.Length.ShouldBe(1);
            methodGetListNamesInHashtablePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListNamesInHashtable) (Return Type : Hashtable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_GetListNamesInHashtable_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetListNamesInHashtablePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getlistreportitemsInstance, MethodGetListNamesInHashtable, Fixture, methodGetListNamesInHashtablePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetListNamesInHashtablePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetListNamesInHashtable) (Return Type : Hashtable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_GetListNamesInHashtable_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetListNamesInHashtablePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getlistreportitemsInstance, MethodGetListNamesInHashtable, Fixture, methodGetListNamesInHashtablePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListNamesInHashtablePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListNamesInHashtable) (Return Type : Hashtable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_GetListNamesInHashtable_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListNamesInHashtable, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getlistreportitemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListNamesInHashtable) (Return Type : Hashtable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_GetListNamesInHashtable_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetListNamesInHashtable, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSSRSReportTree) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getlistreportitems_GetSSRSReportTree_Method_Call_Internally(Type[] types)
        {
            var methodGetSSRSReportTreePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getlistreportitemsInstance, MethodGetSSRSReportTree, Fixture, methodGetSSRSReportTreePrametersTypes);
        }

        #endregion

        #region Method Call : (GetSSRSReportTree) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_GetSSRSReportTree_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var node = CreateType<TreeNode>();
            Action executeAction = null;

            // Act
            executeAction = () => _getlistreportitemsInstance.GetSSRSReportTree(ref node);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetSSRSReportTree) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_GetSSRSReportTree_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var node = CreateType<TreeNode>();
            var methodGetSSRSReportTreePrametersTypes = new Type[] { typeof(TreeNode) };
            object[] parametersOfGetSSRSReportTree = { node };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getlistreportitemsInstance, MethodGetSSRSReportTree, parametersOfGetSSRSReportTree, methodGetSSRSReportTreePrametersTypes);

            // Assert
            parametersOfGetSSRSReportTree.ShouldNotBeNull();
            parametersOfGetSSRSReportTree.Length.ShouldBe(1);
            methodGetSSRSReportTreePrametersTypes.Length.ShouldBe(1);
            methodGetSSRSReportTreePrametersTypes.Length.ShouldBe(parametersOfGetSSRSReportTree.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSSRSReportTree) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_GetSSRSReportTree_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetSSRSReportTree, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSSRSReportTree) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_GetSSRSReportTree_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSSRSReportTreePrametersTypes = new Type[] { typeof(TreeNode) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getlistreportitemsInstance, MethodGetSSRSReportTree, Fixture, methodGetSSRSReportTreePrametersTypes);

            // Assert
            methodGetSSRSReportTreePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSSRSReportTree) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_GetSSRSReportTree_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSSRSReportTree, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getlistreportitemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetItemsNativeMode) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getlistreportitems_GetItemsNativeMode_Method_Call_Internally(Type[] types)
        {
            var methodGetItemsNativeModePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getlistreportitemsInstance, MethodGetItemsNativeMode, Fixture, methodGetItemsNativeModePrametersTypes);
        }

        #endregion

        #region Method Call : (GetItemsNativeMode) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_GetItemsNativeMode_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var node = CreateType<TreeNode>();
            var web = CreateType<SPWeb>();
            var methodGetItemsNativeModePrametersTypes = new Type[] { typeof(TreeNode), typeof(SPWeb) };
            object[] parametersOfGetItemsNativeMode = { node, web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetItemsNativeMode, methodGetItemsNativeModePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getlistreportitemsInstanceFixture, parametersOfGetItemsNativeMode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetItemsNativeMode.ShouldNotBeNull();
            parametersOfGetItemsNativeMode.Length.ShouldBe(2);
            methodGetItemsNativeModePrametersTypes.Length.ShouldBe(2);
            methodGetItemsNativeModePrametersTypes.Length.ShouldBe(parametersOfGetItemsNativeMode.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetItemsNativeMode) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_GetItemsNativeMode_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var node = CreateType<TreeNode>();
            var web = CreateType<SPWeb>();
            var methodGetItemsNativeModePrametersTypes = new Type[] { typeof(TreeNode), typeof(SPWeb) };
            object[] parametersOfGetItemsNativeMode = { node, web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getlistreportitemsInstance, MethodGetItemsNativeMode, parametersOfGetItemsNativeMode, methodGetItemsNativeModePrametersTypes);

            // Assert
            parametersOfGetItemsNativeMode.ShouldNotBeNull();
            parametersOfGetItemsNativeMode.Length.ShouldBe(2);
            methodGetItemsNativeModePrametersTypes.Length.ShouldBe(2);
            methodGetItemsNativeModePrametersTypes.Length.ShouldBe(parametersOfGetItemsNativeMode.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetItemsNativeMode) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_GetItemsNativeMode_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetItemsNativeMode, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetItemsNativeMode) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_GetItemsNativeMode_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetItemsNativeModePrametersTypes = new Type[] { typeof(TreeNode), typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getlistreportitemsInstance, MethodGetItemsNativeMode, Fixture, methodGetItemsNativeModePrametersTypes);

            // Assert
            methodGetItemsNativeModePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetItemsNativeMode) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_GetItemsNativeMode_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetItemsNativeMode, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getlistreportitemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateTreeNativeMode) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getlistreportitems_PopulateTreeNativeMode_Method_Call_Internally(Type[] types)
        {
            var methodPopulateTreeNativeModePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getlistreportitemsInstance, MethodPopulateTreeNativeMode, Fixture, methodPopulateTreeNativeModePrametersTypes);
        }

        #endregion
        
        #region Method Call : (PopulateTreeNativeMode) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_PopulateTreeNativeMode_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPopulateTreeNativeMode, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion
        
        #region Method Call : (PopulateTreeNativeMode) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_PopulateTreeNativeMode_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPopulateTreeNativeMode, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getlistreportitemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSharepointItems) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getlistreportitems_GetSharepointItems_Method_Call_Internally(Type[] types)
        {
            var methodGetSharepointItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getlistreportitemsInstance, MethodGetSharepointItems, Fixture, methodGetSharepointItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSharepointItems) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_GetSharepointItems_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var node = CreateType<TreeNode>();
            var web = CreateType<SPWeb>();
            var methodGetSharepointItemsPrametersTypes = new Type[] { typeof(TreeNode), typeof(SPWeb) };
            object[] parametersOfGetSharepointItems = { node, web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetSharepointItems, methodGetSharepointItemsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getlistreportitemsInstanceFixture, parametersOfGetSharepointItems);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetSharepointItems.ShouldNotBeNull();
            parametersOfGetSharepointItems.Length.ShouldBe(2);
            methodGetSharepointItemsPrametersTypes.Length.ShouldBe(2);
            methodGetSharepointItemsPrametersTypes.Length.ShouldBe(parametersOfGetSharepointItems.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetSharepointItems) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_GetSharepointItems_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var node = CreateType<TreeNode>();
            var web = CreateType<SPWeb>();
            var methodGetSharepointItemsPrametersTypes = new Type[] { typeof(TreeNode), typeof(SPWeb) };
            object[] parametersOfGetSharepointItems = { node, web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getlistreportitemsInstance, MethodGetSharepointItems, parametersOfGetSharepointItems, methodGetSharepointItemsPrametersTypes);

            // Assert
            parametersOfGetSharepointItems.ShouldNotBeNull();
            parametersOfGetSharepointItems.Length.ShouldBe(2);
            methodGetSharepointItemsPrametersTypes.Length.ShouldBe(2);
            methodGetSharepointItemsPrametersTypes.Length.ShouldBe(parametersOfGetSharepointItems.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSharepointItems) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_GetSharepointItems_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetSharepointItems, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSharepointItems) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_GetSharepointItems_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSharepointItemsPrametersTypes = new Type[] { typeof(TreeNode), typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getlistreportitemsInstance, MethodGetSharepointItems, Fixture, methodGetSharepointItemsPrametersTypes);

            // Assert
            methodGetSharepointItemsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSharepointItems) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_GetSharepointItems_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSharepointItems, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getlistreportitemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddSSRSReportLinks) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getlistreportitems_AddSSRSReportLinks_Static_Method_Call_Internally(Type[] types)
        {
            var methodAddSSRSReportLinksPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_getlistreportitemsInstanceFixture, _getlistreportitemsInstanceType, MethodAddSSRSReportLinks, Fixture, methodAddSSRSReportLinksPrametersTypes);
        }

        #endregion

        #region Method Call : (AddSSRSReportLinks) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_AddSSRSReportLinks_Static_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var node = CreateType<TreeNode>();
            var doc = CreateType<XmlDocument>();
            var parentNode = CreateType<XmlNode>();
            var methodAddSSRSReportLinksPrametersTypes = new Type[] { typeof(TreeNode), typeof(XmlDocument), typeof(XmlNode) };
            object[] parametersOfAddSSRSReportLinks = { node, doc, parentNode };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddSSRSReportLinks, methodAddSSRSReportLinksPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getlistreportitemsInstanceFixture, parametersOfAddSSRSReportLinks);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddSSRSReportLinks.ShouldNotBeNull();
            parametersOfAddSSRSReportLinks.Length.ShouldBe(3);
            methodAddSSRSReportLinksPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddSSRSReportLinks) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_AddSSRSReportLinks_Static_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var node = CreateType<TreeNode>();
            var doc = CreateType<XmlDocument>();
            var parentNode = CreateType<XmlNode>();
            var methodAddSSRSReportLinksPrametersTypes = new Type[] { typeof(TreeNode), typeof(XmlDocument), typeof(XmlNode) };
            object[] parametersOfAddSSRSReportLinks = { node, doc, parentNode };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_getlistreportitemsInstanceFixture, _getlistreportitemsInstanceType, MethodAddSSRSReportLinks, parametersOfAddSSRSReportLinks, methodAddSSRSReportLinksPrametersTypes);

            // Assert
            parametersOfAddSSRSReportLinks.ShouldNotBeNull();
            parametersOfAddSSRSReportLinks.Length.ShouldBe(3);
            methodAddSSRSReportLinksPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddSSRSReportLinks) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_AddSSRSReportLinks_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddSSRSReportLinks, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddSSRSReportLinks) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_AddSSRSReportLinks_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddSSRSReportLinksPrametersTypes = new Type[] { typeof(TreeNode), typeof(XmlDocument), typeof(XmlNode) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_getlistreportitemsInstanceFixture, _getlistreportitemsInstanceType, MethodAddSSRSReportLinks, Fixture, methodAddSSRSReportLinksPrametersTypes);

            // Assert
            methodAddSSRSReportLinksPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddSSRSReportLinks) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_AddSSRSReportLinks_Static_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddSSRSReportLinks, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getlistreportitemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadTreeForSsrs) (Return Type : TreeNode) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getlistreportitems_LoadTreeForSsrs_Method_Call_Internally(Type[] types)
        {
            var methodLoadTreeForSsrsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getlistreportitemsInstance, MethodLoadTreeForSsrs, Fixture, methodLoadTreeForSsrsPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadTreeForSsrs) (Return Type : TreeNode) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_LoadTreeForSsrs_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listItems = CreateType<SPListItemCollection>();
            var doc = CreateType<SPDocumentLibrary>();
            var methodLoadTreeForSsrsPrametersTypes = new Type[] { typeof(SPListItemCollection), typeof(SPDocumentLibrary) };
            object[] parametersOfLoadTreeForSsrs = { listItems, doc };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodLoadTreeForSsrs, methodLoadTreeForSsrsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<getlistreportitems, TreeNode>(_getlistreportitemsInstanceFixture, out exception1, parametersOfLoadTreeForSsrs);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<getlistreportitems, TreeNode>(_getlistreportitemsInstance, MethodLoadTreeForSsrs, parametersOfLoadTreeForSsrs, methodLoadTreeForSsrsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfLoadTreeForSsrs.ShouldNotBeNull();
            parametersOfLoadTreeForSsrs.Length.ShouldBe(2);
            methodLoadTreeForSsrsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (LoadTreeForSsrs) (Return Type : TreeNode) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_LoadTreeForSsrs_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listItems = CreateType<SPListItemCollection>();
            var doc = CreateType<SPDocumentLibrary>();
            var methodLoadTreeForSsrsPrametersTypes = new Type[] { typeof(SPListItemCollection), typeof(SPDocumentLibrary) };
            object[] parametersOfLoadTreeForSsrs = { listItems, doc };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getlistreportitems, TreeNode>(_getlistreportitemsInstance, MethodLoadTreeForSsrs, parametersOfLoadTreeForSsrs, methodLoadTreeForSsrsPrametersTypes);

            // Assert
            parametersOfLoadTreeForSsrs.ShouldNotBeNull();
            parametersOfLoadTreeForSsrs.Length.ShouldBe(2);
            methodLoadTreeForSsrsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadTreeForSsrs) (Return Type : TreeNode) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_LoadTreeForSsrs_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodLoadTreeForSsrsPrametersTypes = new Type[] { typeof(SPListItemCollection), typeof(SPDocumentLibrary) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getlistreportitemsInstance, MethodLoadTreeForSsrs, Fixture, methodLoadTreeForSsrsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodLoadTreeForSsrsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (LoadTreeForSsrs) (Return Type : TreeNode) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_LoadTreeForSsrs_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLoadTreeForSsrsPrametersTypes = new Type[] { typeof(SPListItemCollection), typeof(SPDocumentLibrary) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getlistreportitemsInstance, MethodLoadTreeForSsrs, Fixture, methodLoadTreeForSsrsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodLoadTreeForSsrsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LoadTreeForSsrs) (Return Type : TreeNode) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_LoadTreeForSsrs_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLoadTreeForSsrs, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getlistreportitemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (LoadTreeForSsrs) (Return Type : TreeNode) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_LoadTreeForSsrs_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodLoadTreeForSsrs, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PopulateTree) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getlistreportitems_PopulateTree_Method_Call_Internally(Type[] types)
        {
            var methodPopulateTreePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getlistreportitemsInstance, MethodPopulateTree, Fixture, methodPopulateTreePrametersTypes);
        }

        #endregion

        #region Method Call : (PopulateTree) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_PopulateTree_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var listItems = CreateType<SPListItemCollection>();
            var doc = CreateType<SPDocumentLibrary>();
            var tn = CreateType<TreeNode>();
            var methodPopulateTreePrametersTypes = new Type[] { typeof(SPListItemCollection), typeof(SPDocumentLibrary), typeof(TreeNode) };
            object[] parametersOfPopulateTree = { listItems, doc, tn };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPopulateTree, methodPopulateTreePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getlistreportitemsInstanceFixture, parametersOfPopulateTree);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPopulateTree.ShouldNotBeNull();
            parametersOfPopulateTree.Length.ShouldBe(3);
            methodPopulateTreePrametersTypes.Length.ShouldBe(3);
            methodPopulateTreePrametersTypes.Length.ShouldBe(parametersOfPopulateTree.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (PopulateTree) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_PopulateTree_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listItems = CreateType<SPListItemCollection>();
            var doc = CreateType<SPDocumentLibrary>();
            var tn = CreateType<TreeNode>();
            var methodPopulateTreePrametersTypes = new Type[] { typeof(SPListItemCollection), typeof(SPDocumentLibrary), typeof(TreeNode) };
            object[] parametersOfPopulateTree = { listItems, doc, tn };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getlistreportitemsInstance, MethodPopulateTree, parametersOfPopulateTree, methodPopulateTreePrametersTypes);

            // Assert
            parametersOfPopulateTree.ShouldNotBeNull();
            parametersOfPopulateTree.Length.ShouldBe(3);
            methodPopulateTreePrametersTypes.Length.ShouldBe(3);
            methodPopulateTreePrametersTypes.Length.ShouldBe(parametersOfPopulateTree.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateTree) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_PopulateTree_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPopulateTree, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PopulateTree) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_PopulateTree_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPopulateTreePrametersTypes = new Type[] { typeof(SPListItemCollection), typeof(SPDocumentLibrary), typeof(TreeNode) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getlistreportitemsInstance, MethodPopulateTree, Fixture, methodPopulateTreePrametersTypes);

            // Assert
            methodPopulateTreePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateTree) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_PopulateTree_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPopulateTree, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getlistreportitemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCredentials) (Return Type : NetworkCredential) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getlistreportitems_GetCredentials_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetCredentialsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_getlistreportitemsInstanceFixture, _getlistreportitemsInstanceType, MethodGetCredentials, Fixture, methodGetCredentialsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCredentials) (Return Type : NetworkCredential) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_GetCredentials_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetCredentialsPrametersTypes = null;
            object[] parametersOfGetCredentials = null; // no parameter present
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCredentials, methodGetCredentialsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_getlistreportitemsInstanceFixture, _getlistreportitemsInstanceType, MethodGetCredentials, Fixture, methodGetCredentialsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<NetworkCredential>(_getlistreportitemsInstanceFixture, _getlistreportitemsInstanceType, MethodGetCredentials, parametersOfGetCredentials, methodGetCredentialsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_getlistreportitemsInstanceFixture, parametersOfGetCredentials);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetCredentials.ShouldBeNull();
            methodGetCredentialsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetCredentials) (Return Type : NetworkCredential) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_GetCredentials_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetCredentialsPrametersTypes = null;
            object[] parametersOfGetCredentials = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<NetworkCredential>(_getlistreportitemsInstanceFixture, _getlistreportitemsInstanceType, MethodGetCredentials, parametersOfGetCredentials, methodGetCredentialsPrametersTypes);

            // Assert
            parametersOfGetCredentials.ShouldBeNull();
            methodGetCredentialsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCredentials) (Return Type : NetworkCredential) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_GetCredentials_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetCredentialsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_getlistreportitemsInstanceFixture, _getlistreportitemsInstanceType, MethodGetCredentials, Fixture, methodGetCredentialsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCredentialsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCredentials) (Return Type : NetworkCredential) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_GetCredentials_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetCredentialsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_getlistreportitemsInstanceFixture, _getlistreportitemsInstanceType, MethodGetCredentials, Fixture, methodGetCredentialsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCredentialsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCredentials) (Return Type : NetworkCredential) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getlistreportitems_GetCredentials_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCredentials, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getlistreportitemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #endregion

        #endregion
    }
}
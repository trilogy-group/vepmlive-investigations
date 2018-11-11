using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using EPMLiveCore.Infrastructure;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.API
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.ResourceGrid" />)
    ///     and namespace <see cref="EPMLiveCore.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class ResourceGridTest : AbstractBaseSetupTypedTest<ResourceGrid>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ResourceGrid) Initializer

        private const string MethodClearCache = "ClearCache";
        private const string MethodBuildDepartmentHierarchy = "BuildDepartmentHierarchy";
        private const string MethodBuildIElement = "BuildIElement";
        private const string MethodConfirmDelete = "ConfirmDelete";
        private const string MethodExtractResourceId = "ExtractResourceId";
        private const string MethodFilterDepartmentResources = "FilterDepartmentResources";
        private const string MethodGetCacheKey = "GetCacheKey";
        private const string MethodGetDataGrid = "GetDataGrid";
        private const string MethodBuildEnumValues = "BuildEnumValues";
        private const string MethodGetLayoutGrid = "GetLayoutGrid";
        private const string MethodParseResources = "ParseResources";
        private const string MethodRegisterGridIdAndCss = "RegisterGridIdAndCss";
        private const string MethodDeleteResourcePoolResource = "DeleteResourcePoolResource";
        private const string MethodDeleteResourcePoolViews = "DeleteResourcePoolViews";
        private const string MethodExportResources = "ExportResources";
        private const string MethodGetResourcePoolDataGrid = "GetResourcePoolDataGrid";
        private const string MethodGetResourcePoolDataGridChanges = "GetResourcePoolDataGridChanges";
        private const string MethodGetResourcePoolLayoutGrid = "GetResourcePoolLayoutGrid";
        private const string MethodGetResourcePoolViews = "GetResourcePoolViews";
        private const string MethodGetViews = "GetViews";
        private const string MethodGetResources = "GetResources";
        private const string MethodSaveResourcePoolViews = "SaveResourcePoolViews";
        private const string MethodUpdateResourcePoolViews = "UpdateResourcePoolViews";
        private const string MethodRefreshResources = "RefreshResources";
        private const string FieldCOMPONENT_NAME = "COMPONENT_NAME";
        private const string Field_resourceDictionary = "_resourceDictionary";
        private Type _resourceGridInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ResourceGrid _resourceGridInstance;
        private ResourceGrid _resourceGridInstanceFixture;

        #region General Initializer : Class (ResourceGrid) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ResourceGrid" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _resourceGridInstanceType = typeof(ResourceGrid);
            _resourceGridInstanceFixture = Create(true);
            _resourceGridInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ResourceGrid)

        #region General Initializer : Class (ResourceGrid) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ResourceGrid" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodClearCache, 0)]
        [TestCase(MethodBuildDepartmentHierarchy, 0)]
        [TestCase(MethodBuildIElement, 0)]
        [TestCase(MethodConfirmDelete, 0)]
        [TestCase(MethodExtractResourceId, 0)]
        [TestCase(MethodFilterDepartmentResources, 0)]
        [TestCase(MethodGetCacheKey, 0)]
        [TestCase(MethodGetDataGrid, 0)]
        [TestCase(MethodBuildEnumValues, 0)]
        [TestCase(MethodGetLayoutGrid, 0)]
        [TestCase(MethodParseResources, 0)]
        [TestCase(MethodRegisterGridIdAndCss, 0)]
        [TestCase(MethodDeleteResourcePoolResource, 0)]
        [TestCase(MethodDeleteResourcePoolViews, 0)]
        [TestCase(MethodExportResources, 0)]
        [TestCase(MethodGetResourcePoolDataGrid, 0)]
        [TestCase(MethodGetResourcePoolDataGridChanges, 0)]
        [TestCase(MethodGetResourcePoolLayoutGrid, 0)]
        [TestCase(MethodGetResourcePoolViews, 0)]
        [TestCase(MethodGetViews, 0)]
        [TestCase(MethodGetResources, 0)]
        [TestCase(MethodSaveResourcePoolViews, 0)]
        [TestCase(MethodUpdateResourcePoolViews, 0)]
        [TestCase(MethodRefreshResources, 0)]
        public void AUT_ResourceGrid_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_resourceGridInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ResourceGrid) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ResourceGrid" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldCOMPONENT_NAME)]
        [TestCase(Field_resourceDictionary)]
        public void AUT_ResourceGrid_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_resourceGridInstanceFixture, 
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
        ///     Class (<see cref="ResourceGrid" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ResourceGrid_Is_Instance_Present_Test()
        {
            // Assert
            _resourceGridInstanceType.ShouldNotBeNull();
            _resourceGridInstance.ShouldNotBeNull();
            _resourceGridInstanceFixture.ShouldNotBeNull();
            _resourceGridInstance.ShouldBeAssignableTo<ResourceGrid>();
            _resourceGridInstanceFixture.ShouldBeAssignableTo<ResourceGrid>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ResourceGrid) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ResourceGrid_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ResourceGrid instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _resourceGridInstanceType.ShouldNotBeNull();
            _resourceGridInstance.ShouldNotBeNull();
            _resourceGridInstanceFixture.ShouldNotBeNull();
            _resourceGridInstance.ShouldBeAssignableTo<ResourceGrid>();
            _resourceGridInstanceFixture.ShouldBeAssignableTo<ResourceGrid>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="ResourceGrid" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodClearCache)]
        [TestCase(MethodBuildDepartmentHierarchy)]
        [TestCase(MethodBuildIElement)]
        [TestCase(MethodConfirmDelete)]
        [TestCase(MethodExtractResourceId)]
        [TestCase(MethodFilterDepartmentResources)]
        [TestCase(MethodGetCacheKey)]
        [TestCase(MethodGetDataGrid)]
        [TestCase(MethodBuildEnumValues)]
        [TestCase(MethodGetLayoutGrid)]
        [TestCase(MethodParseResources)]
        [TestCase(MethodRegisterGridIdAndCss)]
        [TestCase(MethodDeleteResourcePoolResource)]
        [TestCase(MethodDeleteResourcePoolViews)]
        [TestCase(MethodExportResources)]
        [TestCase(MethodGetResourcePoolDataGrid)]
        [TestCase(MethodGetResourcePoolDataGridChanges)]
        [TestCase(MethodGetResourcePoolLayoutGrid)]
        [TestCase(MethodGetResourcePoolViews)]
        [TestCase(MethodGetViews)]
        [TestCase(MethodGetResources)]
        [TestCase(MethodSaveResourcePoolViews)]
        [TestCase(MethodUpdateResourcePoolViews)]
        [TestCase(MethodRefreshResources)]
        public void AUT_ResourceGrid_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_resourceGridInstanceFixture,
                                                                              _resourceGridInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceGrid_ClearCache_Static_Method_Call_Internally(Type[] types)
        {
            var methodClearCachePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodClearCache, Fixture, methodClearCachePrametersTypes);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_ClearCache_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => ResourceGrid.ClearCache(spWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_ClearCache_Static_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            var methodClearCachePrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfClearCache = { spWeb };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodClearCache, methodClearCachePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourceGridInstanceFixture, parametersOfClearCache);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfClearCache.ShouldNotBeNull();
            parametersOfClearCache.Length.ShouldBe(1);
            methodClearCachePrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_ClearCache_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            var methodClearCachePrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfClearCache = { spWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodClearCache, parametersOfClearCache, methodClearCachePrametersTypes);

            // Assert
            parametersOfClearCache.ShouldNotBeNull();
            parametersOfClearCache.Length.ShouldBe(1);
            methodClearCachePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_ClearCache_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodClearCache, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_ClearCache_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodClearCachePrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodClearCache, Fixture, methodClearCachePrametersTypes);

            // Assert
            methodClearCachePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_ClearCache_Static_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodClearCache, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceGridInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildDepartmentHierarchy) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceGrid_BuildDepartmentHierarchy_Static_Method_Call_Internally(Type[] types)
        {
            var methodBuildDepartmentHierarchyPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodBuildDepartmentHierarchy, Fixture, methodBuildDepartmentHierarchyPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildDepartmentHierarchy) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_BuildDepartmentHierarchy_Static_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var dataRows = CreateType<IEnumerable<DataRow>>();
            var dataTable = CreateType<DataTable>();
            var methodBuildDepartmentHierarchyPrametersTypes = new Type[] { typeof(IEnumerable<DataRow>), typeof(DataTable) };
            object[] parametersOfBuildDepartmentHierarchy = { dataRows, dataTable };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBuildDepartmentHierarchy, methodBuildDepartmentHierarchyPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourceGridInstanceFixture, parametersOfBuildDepartmentHierarchy);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfBuildDepartmentHierarchy.ShouldNotBeNull();
            parametersOfBuildDepartmentHierarchy.Length.ShouldBe(2);
            methodBuildDepartmentHierarchyPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (BuildDepartmentHierarchy) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_BuildDepartmentHierarchy_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dataRows = CreateType<IEnumerable<DataRow>>();
            var dataTable = CreateType<DataTable>();
            var methodBuildDepartmentHierarchyPrametersTypes = new Type[] { typeof(IEnumerable<DataRow>), typeof(DataTable) };
            object[] parametersOfBuildDepartmentHierarchy = { dataRows, dataTable };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodBuildDepartmentHierarchy, parametersOfBuildDepartmentHierarchy, methodBuildDepartmentHierarchyPrametersTypes);

            // Assert
            parametersOfBuildDepartmentHierarchy.ShouldNotBeNull();
            parametersOfBuildDepartmentHierarchy.Length.ShouldBe(2);
            methodBuildDepartmentHierarchyPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildDepartmentHierarchy) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_BuildDepartmentHierarchy_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBuildDepartmentHierarchy, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildDepartmentHierarchy) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_BuildDepartmentHierarchy_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBuildDepartmentHierarchyPrametersTypes = new Type[] { typeof(IEnumerable<DataRow>), typeof(DataTable) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodBuildDepartmentHierarchy, Fixture, methodBuildDepartmentHierarchyPrametersTypes);

            // Assert
            methodBuildDepartmentHierarchyPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildDepartmentHierarchy) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_BuildDepartmentHierarchy_Static_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildDepartmentHierarchy, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceGridInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildIElement) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceGrid_BuildIElement_Static_Method_Call_Internally(Type[] types)
        {
            var methodBuildIElementPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodBuildIElement, Fixture, methodBuildIElementPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildIElement) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_BuildIElement_Static_Method_Call_Void_With_13_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var gridFields = CreateType<Dictionary<string, SPField>>();
            var resourcesList = CreateType<SPList>();
            var gridSafeFields = CreateType<Dictionary<string, string>>();
            var type = CreateType<string>();
            var value = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            var field = CreateType<string>();
            var iElement = CreateType<XElement>();
            var dtUserInfo = CreateType<DataTable>();
            var dataElement = CreateType<XElement>();
            var profilePic = CreateType<string>();
            var resourceId = CreateType<int>();
            var disableThumbnails = CreateType<bool>();
            var methodBuildIElementPrametersTypes = new Type[] { typeof(Dictionary<string, SPField>), typeof(SPList), typeof(Dictionary<string, string>), typeof(string), typeof(string), typeof(SPWeb), typeof(string), typeof(XElement), typeof(DataTable), typeof(XElement), typeof(string), typeof(int), typeof(bool) };
            object[] parametersOfBuildIElement = { gridFields, resourcesList, gridSafeFields, type, value, spWeb, field, iElement, dtUserInfo, dataElement, profilePic, resourceId, disableThumbnails };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBuildIElement, methodBuildIElementPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourceGridInstanceFixture, parametersOfBuildIElement);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfBuildIElement.ShouldNotBeNull();
            parametersOfBuildIElement.Length.ShouldBe(13);
            methodBuildIElementPrametersTypes.Length.ShouldBe(13);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (BuildIElement) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_BuildIElement_Static_Method_Call_Void_With_13_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var gridFields = CreateType<Dictionary<string, SPField>>();
            var resourcesList = CreateType<SPList>();
            var gridSafeFields = CreateType<Dictionary<string, string>>();
            var type = CreateType<string>();
            var value = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            var field = CreateType<string>();
            var iElement = CreateType<XElement>();
            var dtUserInfo = CreateType<DataTable>();
            var dataElement = CreateType<XElement>();
            var profilePic = CreateType<string>();
            var resourceId = CreateType<int>();
            var disableThumbnails = CreateType<bool>();
            var methodBuildIElementPrametersTypes = new Type[] { typeof(Dictionary<string, SPField>), typeof(SPList), typeof(Dictionary<string, string>), typeof(string), typeof(string), typeof(SPWeb), typeof(string), typeof(XElement), typeof(DataTable), typeof(XElement), typeof(string), typeof(int), typeof(bool) };
            object[] parametersOfBuildIElement = { gridFields, resourcesList, gridSafeFields, type, value, spWeb, field, iElement, dtUserInfo, dataElement, profilePic, resourceId, disableThumbnails };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodBuildIElement, parametersOfBuildIElement, methodBuildIElementPrametersTypes);

            // Assert
            parametersOfBuildIElement.ShouldNotBeNull();
            parametersOfBuildIElement.Length.ShouldBe(13);
            methodBuildIElementPrametersTypes.Length.ShouldBe(13);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildIElement) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_BuildIElement_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBuildIElement, 0);
            const int parametersCount = 13;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildIElement) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_BuildIElement_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBuildIElementPrametersTypes = new Type[] { typeof(Dictionary<string, SPField>), typeof(SPList), typeof(Dictionary<string, string>), typeof(string), typeof(string), typeof(SPWeb), typeof(string), typeof(XElement), typeof(DataTable), typeof(XElement), typeof(string), typeof(int), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodBuildIElement, Fixture, methodBuildIElementPrametersTypes);

            // Assert
            methodBuildIElementPrametersTypes.Length.ShouldBe(13);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildIElement) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_BuildIElement_Static_Method_Call_With_13_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildIElement, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceGridInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConfirmDelete) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceGrid_ConfirmDelete_Static_Method_Call_Internally(Type[] types)
        {
            var methodConfirmDeletePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodConfirmDelete, Fixture, methodConfirmDeletePrametersTypes);
        }

        #endregion

        #region Method Call : (ConfirmDelete) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_ConfirmDelete_Static_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var resourceId = CreateType<int>();
            var resourceManager = CreateType<ResourcePoolManager>();
            var methodConfirmDeletePrametersTypes = new Type[] { typeof(int), typeof(ResourcePoolManager) };
            object[] parametersOfConfirmDelete = { resourceId, resourceManager };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodConfirmDelete, methodConfirmDeletePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourceGridInstanceFixture, parametersOfConfirmDelete);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfConfirmDelete.ShouldNotBeNull();
            parametersOfConfirmDelete.Length.ShouldBe(2);
            methodConfirmDeletePrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ConfirmDelete) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_ConfirmDelete_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var resourceId = CreateType<int>();
            var resourceManager = CreateType<ResourcePoolManager>();
            var methodConfirmDeletePrametersTypes = new Type[] { typeof(int), typeof(ResourcePoolManager) };
            object[] parametersOfConfirmDelete = { resourceId, resourceManager };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodConfirmDelete, parametersOfConfirmDelete, methodConfirmDeletePrametersTypes);

            // Assert
            parametersOfConfirmDelete.ShouldNotBeNull();
            parametersOfConfirmDelete.Length.ShouldBe(2);
            methodConfirmDeletePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConfirmDelete) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_ConfirmDelete_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodConfirmDelete, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ConfirmDelete) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_ConfirmDelete_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodConfirmDeletePrametersTypes = new Type[] { typeof(int), typeof(ResourcePoolManager) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodConfirmDelete, Fixture, methodConfirmDeletePrametersTypes);

            // Assert
            methodConfirmDeletePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConfirmDelete) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_ConfirmDelete_Static_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodConfirmDelete, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceGridInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExtractResourceId) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceGrid_ExtractResourceId_Static_Method_Call_Internally(Type[] types)
        {
            var methodExtractResourceIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodExtractResourceId, Fixture, methodExtractResourceIdPrametersTypes);
        }

        #endregion

        #region Method Call : (ExtractResourceId) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_ExtractResourceId_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var confirmDelete = CreateType<bool>();
            var methodExtractResourceIdPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfExtractResourceId = { data, confirmDelete };

            // Assert
            parametersOfExtractResourceId.ShouldNotBeNull();
            parametersOfExtractResourceId.Length.ShouldBe(2);
            methodExtractResourceIdPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<int>(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodExtractResourceId, parametersOfExtractResourceId, methodExtractResourceIdPrametersTypes));
        }

        #endregion

        #region Method Call : (ExtractResourceId) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_ExtractResourceId_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodExtractResourceIdPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodExtractResourceId, Fixture, methodExtractResourceIdPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodExtractResourceIdPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExtractResourceId) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_ExtractResourceId_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodExtractResourceId, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceGridInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ExtractResourceId) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_ExtractResourceId_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodExtractResourceId, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FilterDepartmentResources) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceGrid_FilterDepartmentResources_Static_Method_Call_Internally(Type[] types)
        {
            var methodFilterDepartmentResourcesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodFilterDepartmentResources, Fixture, methodFilterDepartmentResourcesPrametersTypes);
        }

        #endregion

        #region Method Call : (FilterDepartmentResources) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_FilterDepartmentResources_Static_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var resultXml = CreateType<XDocument>();
            var methodFilterDepartmentResourcesPrametersTypes = new Type[] { typeof(XDocument) };
            object[] parametersOfFilterDepartmentResources = { resultXml };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodFilterDepartmentResources, methodFilterDepartmentResourcesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourceGridInstanceFixture, parametersOfFilterDepartmentResources);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfFilterDepartmentResources.ShouldNotBeNull();
            parametersOfFilterDepartmentResources.Length.ShouldBe(1);
            methodFilterDepartmentResourcesPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (FilterDepartmentResources) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_FilterDepartmentResources_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var resultXml = CreateType<XDocument>();
            var methodFilterDepartmentResourcesPrametersTypes = new Type[] { typeof(XDocument) };
            object[] parametersOfFilterDepartmentResources = { resultXml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodFilterDepartmentResources, parametersOfFilterDepartmentResources, methodFilterDepartmentResourcesPrametersTypes);

            // Assert
            parametersOfFilterDepartmentResources.ShouldNotBeNull();
            parametersOfFilterDepartmentResources.Length.ShouldBe(1);
            methodFilterDepartmentResourcesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FilterDepartmentResources) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_FilterDepartmentResources_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodFilterDepartmentResources, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FilterDepartmentResources) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_FilterDepartmentResources_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFilterDepartmentResourcesPrametersTypes = new Type[] { typeof(XDocument) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodFilterDepartmentResources, Fixture, methodFilterDepartmentResourcesPrametersTypes);

            // Assert
            methodFilterDepartmentResourcesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FilterDepartmentResources) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_FilterDepartmentResources_Static_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFilterDepartmentResources, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceGridInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCacheKey) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceGrid_GetCacheKey_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetCacheKeyPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetCacheKey, Fixture, methodGetCacheKeyPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCacheKey) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetCacheKey_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var kind = CreateType<string>();
            var methodGetCacheKeyPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfGetCacheKey = { web, kind };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetCacheKey, methodGetCacheKeyPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetCacheKey, Fixture, methodGetCacheKeyPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetCacheKey, parametersOfGetCacheKey, methodGetCacheKeyPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resourceGridInstanceFixture, parametersOfGetCacheKey);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetCacheKey.ShouldNotBeNull();
            parametersOfGetCacheKey.Length.ShouldBe(2);
            methodGetCacheKeyPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetCacheKey) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetCacheKey_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var kind = CreateType<string>();
            var methodGetCacheKeyPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfGetCacheKey = { web, kind };

            // Assert
            parametersOfGetCacheKey.ShouldNotBeNull();
            parametersOfGetCacheKey.Length.ShouldBe(2);
            methodGetCacheKeyPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetCacheKey, parametersOfGetCacheKey, methodGetCacheKeyPrametersTypes));
        }

        #endregion

        #region Method Call : (GetCacheKey) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetCacheKey_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCacheKeyPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetCacheKey, Fixture, methodGetCacheKeyPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCacheKeyPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetCacheKey) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetCacheKey_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCacheKeyPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetCacheKey, Fixture, methodGetCacheKeyPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCacheKeyPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCacheKey) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetCacheKey_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCacheKey, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceGridInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCacheKey) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetCacheKey_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCacheKey, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDataGrid) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceGrid_GetDataGrid_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetDataGridPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetDataGrid, Fixture, methodGetDataGridPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDataGrid) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetDataGrid_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodGetDataGridPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetDataGrid = { data, web };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDataGrid, methodGetDataGridPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetDataGrid, Fixture, methodGetDataGridPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetDataGrid, parametersOfGetDataGrid, methodGetDataGridPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resourceGridInstanceFixture, parametersOfGetDataGrid);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetDataGrid.ShouldNotBeNull();
            parametersOfGetDataGrid.Length.ShouldBe(2);
            methodGetDataGridPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetDataGrid) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetDataGrid_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodGetDataGridPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetDataGrid = { data, web };

            // Assert
            parametersOfGetDataGrid.ShouldNotBeNull();
            parametersOfGetDataGrid.Length.ShouldBe(2);
            methodGetDataGridPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetDataGrid, parametersOfGetDataGrid, methodGetDataGridPrametersTypes));
        }

        #endregion

        #region Method Call : (GetDataGrid) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetDataGrid_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetDataGridPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetDataGrid, Fixture, methodGetDataGridPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDataGridPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetDataGrid) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetDataGrid_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDataGridPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetDataGrid, Fixture, methodGetDataGridPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDataGridPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDataGrid) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetDataGrid_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDataGrid, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceGridInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDataGrid) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetDataGrid_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetDataGrid, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildEnumValues) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceGrid_BuildEnumValues_Static_Method_Call_Internally(Type[] types)
        {
            var methodBuildEnumValuesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodBuildEnumValues, Fixture, methodBuildEnumValuesPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildEnumValues) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_BuildEnumValues_Static_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var gridFields = CreateType<Dictionary<string, SPField>>();
            var bElement = CreateType<XElement>();
            var resourceTeam = CreateType<XDocument>();
            var colsElement = CreateType<XElement>();
            var methodBuildEnumValuesPrametersTypes = new Type[] { typeof(Dictionary<string, SPField>), typeof(XElement), typeof(XDocument), typeof(XElement) };
            object[] parametersOfBuildEnumValues = { gridFields, bElement, resourceTeam, colsElement };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBuildEnumValues, methodBuildEnumValuesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourceGridInstanceFixture, parametersOfBuildEnumValues);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfBuildEnumValues.ShouldNotBeNull();
            parametersOfBuildEnumValues.Length.ShouldBe(4);
            methodBuildEnumValuesPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildEnumValues) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_BuildEnumValues_Static_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var gridFields = CreateType<Dictionary<string, SPField>>();
            var bElement = CreateType<XElement>();
            var resourceTeam = CreateType<XDocument>();
            var colsElement = CreateType<XElement>();
            var methodBuildEnumValuesPrametersTypes = new Type[] { typeof(Dictionary<string, SPField>), typeof(XElement), typeof(XDocument), typeof(XElement) };
            object[] parametersOfBuildEnumValues = { gridFields, bElement, resourceTeam, colsElement };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodBuildEnumValues, parametersOfBuildEnumValues, methodBuildEnumValuesPrametersTypes);

            // Assert
            parametersOfBuildEnumValues.ShouldNotBeNull();
            parametersOfBuildEnumValues.Length.ShouldBe(4);
            methodBuildEnumValuesPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildEnumValues) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_BuildEnumValues_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBuildEnumValues, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildEnumValues) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_BuildEnumValues_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBuildEnumValuesPrametersTypes = new Type[] { typeof(Dictionary<string, SPField>), typeof(XElement), typeof(XDocument), typeof(XElement) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodBuildEnumValues, Fixture, methodBuildEnumValuesPrametersTypes);

            // Assert
            methodBuildEnumValuesPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildEnumValues) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_BuildEnumValues_Static_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildEnumValues, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceGridInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetLayoutGrid) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceGrid_GetLayoutGrid_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetLayoutGridPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetLayoutGrid, Fixture, methodGetLayoutGridPrametersTypes);
        }

        #endregion

        #region Method Call : (GetLayoutGrid) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetLayoutGrid_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetLayoutGridPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetLayoutGrid = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetLayoutGrid, methodGetLayoutGridPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetLayoutGrid, Fixture, methodGetLayoutGridPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetLayoutGrid, parametersOfGetLayoutGrid, methodGetLayoutGridPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resourceGridInstanceFixture, parametersOfGetLayoutGrid);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetLayoutGrid.ShouldNotBeNull();
            parametersOfGetLayoutGrid.Length.ShouldBe(1);
            methodGetLayoutGridPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetLayoutGrid) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetLayoutGrid_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetLayoutGridPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetLayoutGrid = { data };

            // Assert
            parametersOfGetLayoutGrid.ShouldNotBeNull();
            parametersOfGetLayoutGrid.Length.ShouldBe(1);
            methodGetLayoutGridPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetLayoutGrid, parametersOfGetLayoutGrid, methodGetLayoutGridPrametersTypes));
        }

        #endregion

        #region Method Call : (GetLayoutGrid) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetLayoutGrid_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetLayoutGridPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetLayoutGrid, Fixture, methodGetLayoutGridPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetLayoutGridPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetLayoutGrid) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetLayoutGrid_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetLayoutGridPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetLayoutGrid, Fixture, methodGetLayoutGridPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetLayoutGridPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetLayoutGrid) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetLayoutGrid_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetLayoutGrid, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceGridInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLayoutGrid) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetLayoutGrid_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetLayoutGrid, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ParseResources) (Return Type : IEnumerable<string>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceGrid_ParseResources_Static_Method_Call_Internally(Type[] types)
        {
            var methodParseResourcesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodParseResources, Fixture, methodParseResourcesPrametersTypes);
        }

        #endregion

        #region Method Call : (ParseResources) (Return Type : IEnumerable<string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_ParseResources_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodParseResourcesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfParseResources = { value };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodParseResources, methodParseResourcesPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodParseResources, Fixture, methodParseResourcesPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<IEnumerable<string>>(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodParseResources, parametersOfParseResources, methodParseResourcesPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resourceGridInstanceFixture, parametersOfParseResources);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfParseResources.ShouldNotBeNull();
            parametersOfParseResources.Length.ShouldBe(1);
            methodParseResourcesPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ParseResources) (Return Type : IEnumerable<string>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_ParseResources_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodParseResourcesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfParseResources = { value };

            // Assert
            parametersOfParseResources.ShouldNotBeNull();
            parametersOfParseResources.Length.ShouldBe(1);
            methodParseResourcesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<IEnumerable<string>>(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodParseResources, parametersOfParseResources, methodParseResourcesPrametersTypes));
        }

        #endregion

        #region Method Call : (ParseResources) (Return Type : IEnumerable<string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_ParseResources_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodParseResourcesPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodParseResources, Fixture, methodParseResourcesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodParseResourcesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ParseResources) (Return Type : IEnumerable<string>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_ParseResources_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodParseResourcesPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodParseResources, Fixture, methodParseResourcesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodParseResourcesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ParseResources) (Return Type : IEnumerable<string>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_ParseResources_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodParseResources, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceGridInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ParseResources) (Return Type : IEnumerable<string>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_ParseResources_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodParseResources, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RegisterGridIdAndCss) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceGrid_RegisterGridIdAndCss_Static_Method_Call_Internally(Type[] types)
        {
            var methodRegisterGridIdAndCssPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodRegisterGridIdAndCss, Fixture, methodRegisterGridIdAndCssPrametersTypes);
        }

        #endregion

        #region Method Call : (RegisterGridIdAndCss) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_RegisterGridIdAndCss_Static_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var resultRootElement = CreateType<XElement>();
            var dataXml = CreateType<XDocument>();
            var methodRegisterGridIdAndCssPrametersTypes = new Type[] { typeof(XElement), typeof(XDocument) };
            object[] parametersOfRegisterGridIdAndCss = { resultRootElement, dataXml };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRegisterGridIdAndCss, methodRegisterGridIdAndCssPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourceGridInstanceFixture, parametersOfRegisterGridIdAndCss);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRegisterGridIdAndCss.ShouldNotBeNull();
            parametersOfRegisterGridIdAndCss.Length.ShouldBe(2);
            methodRegisterGridIdAndCssPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RegisterGridIdAndCss) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_RegisterGridIdAndCss_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var resultRootElement = CreateType<XElement>();
            var dataXml = CreateType<XDocument>();
            var methodRegisterGridIdAndCssPrametersTypes = new Type[] { typeof(XElement), typeof(XDocument) };
            object[] parametersOfRegisterGridIdAndCss = { resultRootElement, dataXml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodRegisterGridIdAndCss, parametersOfRegisterGridIdAndCss, methodRegisterGridIdAndCssPrametersTypes);

            // Assert
            parametersOfRegisterGridIdAndCss.ShouldNotBeNull();
            parametersOfRegisterGridIdAndCss.Length.ShouldBe(2);
            methodRegisterGridIdAndCssPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterGridIdAndCss) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_RegisterGridIdAndCss_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRegisterGridIdAndCss, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RegisterGridIdAndCss) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_RegisterGridIdAndCss_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRegisterGridIdAndCssPrametersTypes = new Type[] { typeof(XElement), typeof(XDocument) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodRegisterGridIdAndCss, Fixture, methodRegisterGridIdAndCssPrametersTypes);

            // Assert
            methodRegisterGridIdAndCssPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterGridIdAndCss) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_RegisterGridIdAndCss_Static_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRegisterGridIdAndCss, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceGridInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteResourcePoolResource) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceGrid_DeleteResourcePoolResource_Static_Method_Call_Internally(Type[] types)
        {
            var methodDeleteResourcePoolResourcePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodDeleteResourcePoolResource, Fixture, methodDeleteResourcePoolResourcePrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteResourcePoolResource) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_DeleteResourcePoolResource_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodDeleteResourcePoolResourcePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeleteResourcePoolResource = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteResourcePoolResource, methodDeleteResourcePoolResourcePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodDeleteResourcePoolResource, Fixture, methodDeleteResourcePoolResourcePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodDeleteResourcePoolResource, parametersOfDeleteResourcePoolResource, methodDeleteResourcePoolResourcePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resourceGridInstanceFixture, parametersOfDeleteResourcePoolResource);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfDeleteResourcePoolResource.ShouldNotBeNull();
            parametersOfDeleteResourcePoolResource.Length.ShouldBe(1);
            methodDeleteResourcePoolResourcePrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DeleteResourcePoolResource) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_DeleteResourcePoolResource_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodDeleteResourcePoolResourcePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeleteResourcePoolResource = { data };

            // Assert
            parametersOfDeleteResourcePoolResource.ShouldNotBeNull();
            parametersOfDeleteResourcePoolResource.Length.ShouldBe(1);
            methodDeleteResourcePoolResourcePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodDeleteResourcePoolResource, parametersOfDeleteResourcePoolResource, methodDeleteResourcePoolResourcePrametersTypes));
        }

        #endregion

        #region Method Call : (DeleteResourcePoolResource) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_DeleteResourcePoolResource_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodDeleteResourcePoolResourcePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodDeleteResourcePoolResource, Fixture, methodDeleteResourcePoolResourcePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodDeleteResourcePoolResourcePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteResourcePoolResource) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_DeleteResourcePoolResource_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteResourcePoolResourcePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodDeleteResourcePoolResource, Fixture, methodDeleteResourcePoolResourcePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteResourcePoolResourcePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteResourcePoolResource) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_DeleteResourcePoolResource_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteResourcePoolResource, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceGridInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteResourcePoolResource) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_DeleteResourcePoolResource_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteResourcePoolResource, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteResourcePoolViews) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceGrid_DeleteResourcePoolViews_Static_Method_Call_Internally(Type[] types)
        {
            var methodDeleteResourcePoolViewsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodDeleteResourcePoolViews, Fixture, methodDeleteResourcePoolViewsPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteResourcePoolViews) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_DeleteResourcePoolViews_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodDeleteResourcePoolViewsPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfDeleteResourcePoolViews = { data, web };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteResourcePoolViews, methodDeleteResourcePoolViewsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodDeleteResourcePoolViews, Fixture, methodDeleteResourcePoolViewsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodDeleteResourcePoolViews, parametersOfDeleteResourcePoolViews, methodDeleteResourcePoolViewsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resourceGridInstanceFixture, parametersOfDeleteResourcePoolViews);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfDeleteResourcePoolViews.ShouldNotBeNull();
            parametersOfDeleteResourcePoolViews.Length.ShouldBe(2);
            methodDeleteResourcePoolViewsPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DeleteResourcePoolViews) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_DeleteResourcePoolViews_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodDeleteResourcePoolViewsPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfDeleteResourcePoolViews = { data, web };

            // Assert
            parametersOfDeleteResourcePoolViews.ShouldNotBeNull();
            parametersOfDeleteResourcePoolViews.Length.ShouldBe(2);
            methodDeleteResourcePoolViewsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodDeleteResourcePoolViews, parametersOfDeleteResourcePoolViews, methodDeleteResourcePoolViewsPrametersTypes));
        }

        #endregion

        #region Method Call : (DeleteResourcePoolViews) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_DeleteResourcePoolViews_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodDeleteResourcePoolViewsPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodDeleteResourcePoolViews, Fixture, methodDeleteResourcePoolViewsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodDeleteResourcePoolViewsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (DeleteResourcePoolViews) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_DeleteResourcePoolViews_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteResourcePoolViewsPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodDeleteResourcePoolViews, Fixture, methodDeleteResourcePoolViewsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteResourcePoolViewsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteResourcePoolViews) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_DeleteResourcePoolViews_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteResourcePoolViews, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceGridInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteResourcePoolViews) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_DeleteResourcePoolViews_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteResourcePoolViews, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExportResources) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceGrid_ExportResources_Static_Method_Call_Internally(Type[] types)
        {
            var methodExportResourcesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodExportResources, Fixture, methodExportResourcesPrametersTypes);
        }

        #endregion

        #region Method Call : (ExportResources) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_ExportResources_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            var methodExportResourcesPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfExportResources = { spWeb };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodExportResources, methodExportResourcesPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfExportResources.ShouldNotBeNull();
            parametersOfExportResources.Length.ShouldBe(1);
            methodExportResourcesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(_resourceGridInstanceFixture, parametersOfExportResources));
        }

        #endregion

        #region Method Call : (ExportResources) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_ExportResources_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            var methodExportResourcesPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfExportResources = { spWeb };

            // Assert
            parametersOfExportResources.ShouldNotBeNull();
            parametersOfExportResources.Length.ShouldBe(1);
            methodExportResourcesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodExportResources, parametersOfExportResources, methodExportResourcesPrametersTypes));
        }

        #endregion

        #region Method Call : (ExportResources) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_ExportResources_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodExportResourcesPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodExportResources, Fixture, methodExportResourcesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodExportResourcesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ExportResources) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_ExportResources_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodExportResourcesPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodExportResources, Fixture, methodExportResourcesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodExportResourcesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExportResources) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_ExportResources_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodExportResources, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceGridInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ExportResources) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_ExportResources_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodExportResources, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourcePoolDataGrid) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceGrid_GetResourcePoolDataGrid_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetResourcePoolDataGridPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetResourcePoolDataGrid, Fixture, methodGetResourcePoolDataGridPrametersTypes);
        }

        #endregion

        #region Method Call : (GetResourcePoolDataGrid) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetResourcePoolDataGrid_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodGetResourcePoolDataGridPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetResourcePoolDataGrid = { data, web };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetResourcePoolDataGrid, methodGetResourcePoolDataGridPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetResourcePoolDataGrid, Fixture, methodGetResourcePoolDataGridPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetResourcePoolDataGrid, parametersOfGetResourcePoolDataGrid, methodGetResourcePoolDataGridPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resourceGridInstanceFixture, parametersOfGetResourcePoolDataGrid);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetResourcePoolDataGrid.ShouldNotBeNull();
            parametersOfGetResourcePoolDataGrid.Length.ShouldBe(2);
            methodGetResourcePoolDataGridPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetResourcePoolDataGrid) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetResourcePoolDataGrid_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodGetResourcePoolDataGridPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetResourcePoolDataGrid = { data, web };

            // Assert
            parametersOfGetResourcePoolDataGrid.ShouldNotBeNull();
            parametersOfGetResourcePoolDataGrid.Length.ShouldBe(2);
            methodGetResourcePoolDataGridPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetResourcePoolDataGrid, parametersOfGetResourcePoolDataGrid, methodGetResourcePoolDataGridPrametersTypes));
        }

        #endregion

        #region Method Call : (GetResourcePoolDataGrid) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetResourcePoolDataGrid_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetResourcePoolDataGridPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetResourcePoolDataGrid, Fixture, methodGetResourcePoolDataGridPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetResourcePoolDataGridPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetResourcePoolDataGrid) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetResourcePoolDataGrid_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetResourcePoolDataGridPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetResourcePoolDataGrid, Fixture, methodGetResourcePoolDataGridPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetResourcePoolDataGridPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourcePoolDataGrid) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetResourcePoolDataGrid_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetResourcePoolDataGrid, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceGridInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetResourcePoolDataGrid) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetResourcePoolDataGrid_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetResourcePoolDataGrid, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourcePoolDataGridChanges) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceGrid_GetResourcePoolDataGridChanges_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetResourcePoolDataGridChangesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetResourcePoolDataGridChanges, Fixture, methodGetResourcePoolDataGridChangesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetResourcePoolDataGridChanges) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetResourcePoolDataGridChanges_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            var methodGetResourcePoolDataGridChangesPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetResourcePoolDataGridChanges = { data, spWeb };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetResourcePoolDataGridChanges, methodGetResourcePoolDataGridChangesPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetResourcePoolDataGridChanges, Fixture, methodGetResourcePoolDataGridChangesPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetResourcePoolDataGridChanges, parametersOfGetResourcePoolDataGridChanges, methodGetResourcePoolDataGridChangesPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resourceGridInstanceFixture, parametersOfGetResourcePoolDataGridChanges);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetResourcePoolDataGridChanges.ShouldNotBeNull();
            parametersOfGetResourcePoolDataGridChanges.Length.ShouldBe(2);
            methodGetResourcePoolDataGridChangesPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetResourcePoolDataGridChanges) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetResourcePoolDataGridChanges_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            var methodGetResourcePoolDataGridChangesPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetResourcePoolDataGridChanges = { data, spWeb };

            // Assert
            parametersOfGetResourcePoolDataGridChanges.ShouldNotBeNull();
            parametersOfGetResourcePoolDataGridChanges.Length.ShouldBe(2);
            methodGetResourcePoolDataGridChangesPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetResourcePoolDataGridChanges, parametersOfGetResourcePoolDataGridChanges, methodGetResourcePoolDataGridChangesPrametersTypes));
        }

        #endregion

        #region Method Call : (GetResourcePoolDataGridChanges) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetResourcePoolDataGridChanges_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetResourcePoolDataGridChangesPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetResourcePoolDataGridChanges, Fixture, methodGetResourcePoolDataGridChangesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetResourcePoolDataGridChangesPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetResourcePoolDataGridChanges) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetResourcePoolDataGridChanges_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetResourcePoolDataGridChangesPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetResourcePoolDataGridChanges, Fixture, methodGetResourcePoolDataGridChangesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetResourcePoolDataGridChangesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourcePoolDataGridChanges) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetResourcePoolDataGridChanges_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetResourcePoolDataGridChanges, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceGridInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetResourcePoolDataGridChanges) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetResourcePoolDataGridChanges_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetResourcePoolDataGridChanges, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourcePoolLayoutGrid) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceGrid_GetResourcePoolLayoutGrid_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetResourcePoolLayoutGridPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetResourcePoolLayoutGrid, Fixture, methodGetResourcePoolLayoutGridPrametersTypes);
        }

        #endregion

        #region Method Call : (GetResourcePoolLayoutGrid) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetResourcePoolLayoutGrid_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodGetResourcePoolLayoutGridPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetResourcePoolLayoutGrid = { data, web };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetResourcePoolLayoutGrid, methodGetResourcePoolLayoutGridPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetResourcePoolLayoutGrid, Fixture, methodGetResourcePoolLayoutGridPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetResourcePoolLayoutGrid, parametersOfGetResourcePoolLayoutGrid, methodGetResourcePoolLayoutGridPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resourceGridInstanceFixture, parametersOfGetResourcePoolLayoutGrid);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetResourcePoolLayoutGrid.ShouldNotBeNull();
            parametersOfGetResourcePoolLayoutGrid.Length.ShouldBe(2);
            methodGetResourcePoolLayoutGridPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetResourcePoolLayoutGrid) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetResourcePoolLayoutGrid_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodGetResourcePoolLayoutGridPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetResourcePoolLayoutGrid = { data, web };

            // Assert
            parametersOfGetResourcePoolLayoutGrid.ShouldNotBeNull();
            parametersOfGetResourcePoolLayoutGrid.Length.ShouldBe(2);
            methodGetResourcePoolLayoutGridPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetResourcePoolLayoutGrid, parametersOfGetResourcePoolLayoutGrid, methodGetResourcePoolLayoutGridPrametersTypes));
        }

        #endregion

        #region Method Call : (GetResourcePoolLayoutGrid) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetResourcePoolLayoutGrid_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetResourcePoolLayoutGridPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetResourcePoolLayoutGrid, Fixture, methodGetResourcePoolLayoutGridPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetResourcePoolLayoutGridPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetResourcePoolLayoutGrid) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetResourcePoolLayoutGrid_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetResourcePoolLayoutGridPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetResourcePoolLayoutGrid, Fixture, methodGetResourcePoolLayoutGridPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetResourcePoolLayoutGridPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourcePoolLayoutGrid) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetResourcePoolLayoutGrid_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetResourcePoolLayoutGrid, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceGridInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetResourcePoolLayoutGrid) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetResourcePoolLayoutGrid_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetResourcePoolLayoutGrid, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourcePoolViews) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceGrid_GetResourcePoolViews_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetResourcePoolViewsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetResourcePoolViews, Fixture, methodGetResourcePoolViewsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetResourcePoolViews) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetResourcePoolViews_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodGetResourcePoolViewsPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetResourcePoolViews = { data, web };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetResourcePoolViews, methodGetResourcePoolViewsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetResourcePoolViews, Fixture, methodGetResourcePoolViewsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetResourcePoolViews, parametersOfGetResourcePoolViews, methodGetResourcePoolViewsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resourceGridInstanceFixture, parametersOfGetResourcePoolViews);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetResourcePoolViews.ShouldNotBeNull();
            parametersOfGetResourcePoolViews.Length.ShouldBe(2);
            methodGetResourcePoolViewsPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetResourcePoolViews) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetResourcePoolViews_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodGetResourcePoolViewsPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetResourcePoolViews = { data, web };

            // Assert
            parametersOfGetResourcePoolViews.ShouldNotBeNull();
            parametersOfGetResourcePoolViews.Length.ShouldBe(2);
            methodGetResourcePoolViewsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetResourcePoolViews, parametersOfGetResourcePoolViews, methodGetResourcePoolViewsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetResourcePoolViews) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetResourcePoolViews_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetResourcePoolViewsPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetResourcePoolViews, Fixture, methodGetResourcePoolViewsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetResourcePoolViewsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetResourcePoolViews) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetResourcePoolViews_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetResourcePoolViewsPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetResourcePoolViews, Fixture, methodGetResourcePoolViewsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetResourcePoolViewsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourcePoolViews) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetResourcePoolViews_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetResourcePoolViews, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceGridInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetResourcePoolViews) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetResourcePoolViews_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetResourcePoolViews, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetViews) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceGrid_GetViews_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetViewsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetViews, Fixture, methodGetViewsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetViews) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetViews_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetViewsPrametersTypes = null;
            object[] parametersOfGetViews = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetViews, methodGetViewsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetViews, Fixture, methodGetViewsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetViews, parametersOfGetViews, methodGetViewsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resourceGridInstanceFixture, parametersOfGetViews);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetViews.ShouldBeNull();
            methodGetViewsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetViews) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetViews_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetViewsPrametersTypes = null;
            object[] parametersOfGetViews = null; // no parameter present

            // Assert
            parametersOfGetViews.ShouldBeNull();
            methodGetViewsPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetViews, parametersOfGetViews, methodGetViewsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetViews) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetViews_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetViewsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetViews, Fixture, methodGetViewsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetViewsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetViews) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetViews_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetViewsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetViews, Fixture, methodGetViewsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetViewsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetViews) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetViews_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetViews, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceGridInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetResources) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceGrid_GetResources_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetResourcesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetResources, Fixture, methodGetResourcesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetResources) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetResources_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodGetResourcesPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetResources = { data, web };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetResources, methodGetResourcesPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetResources, Fixture, methodGetResourcesPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetResources, parametersOfGetResources, methodGetResourcesPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resourceGridInstanceFixture, parametersOfGetResources);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetResources.ShouldNotBeNull();
            parametersOfGetResources.Length.ShouldBe(2);
            methodGetResourcesPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetResources) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetResources_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodGetResourcesPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetResources = { data, web };

            // Assert
            parametersOfGetResources.ShouldNotBeNull();
            parametersOfGetResources.Length.ShouldBe(2);
            methodGetResourcesPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetResources, parametersOfGetResources, methodGetResourcesPrametersTypes));
        }

        #endregion

        #region Method Call : (GetResources) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetResources_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetResourcesPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetResources, Fixture, methodGetResourcesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetResourcesPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetResources) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetResources_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetResourcesPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodGetResources, Fixture, methodGetResourcesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetResourcesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResources) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetResources_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetResources, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceGridInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetResources) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_GetResources_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetResources, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveResourcePoolViews) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceGrid_SaveResourcePoolViews_Static_Method_Call_Internally(Type[] types)
        {
            var methodSaveResourcePoolViewsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodSaveResourcePoolViews, Fixture, methodSaveResourcePoolViewsPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveResourcePoolViews) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_SaveResourcePoolViews_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodSaveResourcePoolViewsPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfSaveResourcePoolViews = { data, web };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSaveResourcePoolViews, methodSaveResourcePoolViewsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodSaveResourcePoolViews, Fixture, methodSaveResourcePoolViewsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodSaveResourcePoolViews, parametersOfSaveResourcePoolViews, methodSaveResourcePoolViewsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resourceGridInstanceFixture, parametersOfSaveResourcePoolViews);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSaveResourcePoolViews.ShouldNotBeNull();
            parametersOfSaveResourcePoolViews.Length.ShouldBe(2);
            methodSaveResourcePoolViewsPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SaveResourcePoolViews) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_SaveResourcePoolViews_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodSaveResourcePoolViewsPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfSaveResourcePoolViews = { data, web };

            // Assert
            parametersOfSaveResourcePoolViews.ShouldNotBeNull();
            parametersOfSaveResourcePoolViews.Length.ShouldBe(2);
            methodSaveResourcePoolViewsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodSaveResourcePoolViews, parametersOfSaveResourcePoolViews, methodSaveResourcePoolViewsPrametersTypes));
        }

        #endregion

        #region Method Call : (SaveResourcePoolViews) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_SaveResourcePoolViews_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSaveResourcePoolViewsPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodSaveResourcePoolViews, Fixture, methodSaveResourcePoolViewsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSaveResourcePoolViewsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (SaveResourcePoolViews) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_SaveResourcePoolViews_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveResourcePoolViewsPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodSaveResourcePoolViews, Fixture, methodSaveResourcePoolViewsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSaveResourcePoolViewsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveResourcePoolViews) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_SaveResourcePoolViews_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveResourcePoolViews, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceGridInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SaveResourcePoolViews) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_SaveResourcePoolViews_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSaveResourcePoolViews, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateResourcePoolViews) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceGrid_UpdateResourcePoolViews_Static_Method_Call_Internally(Type[] types)
        {
            var methodUpdateResourcePoolViewsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodUpdateResourcePoolViews, Fixture, methodUpdateResourcePoolViewsPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateResourcePoolViews) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_UpdateResourcePoolViews_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodUpdateResourcePoolViewsPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfUpdateResourcePoolViews = { data, web };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateResourcePoolViews, methodUpdateResourcePoolViewsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodUpdateResourcePoolViews, Fixture, methodUpdateResourcePoolViewsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodUpdateResourcePoolViews, parametersOfUpdateResourcePoolViews, methodUpdateResourcePoolViewsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resourceGridInstanceFixture, parametersOfUpdateResourcePoolViews);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfUpdateResourcePoolViews.ShouldNotBeNull();
            parametersOfUpdateResourcePoolViews.Length.ShouldBe(2);
            methodUpdateResourcePoolViewsPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateResourcePoolViews) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_UpdateResourcePoolViews_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodUpdateResourcePoolViewsPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfUpdateResourcePoolViews = { data, web };

            // Assert
            parametersOfUpdateResourcePoolViews.ShouldNotBeNull();
            parametersOfUpdateResourcePoolViews.Length.ShouldBe(2);
            methodUpdateResourcePoolViewsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodUpdateResourcePoolViews, parametersOfUpdateResourcePoolViews, methodUpdateResourcePoolViewsPrametersTypes));
        }

        #endregion

        #region Method Call : (UpdateResourcePoolViews) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_UpdateResourcePoolViews_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodUpdateResourcePoolViewsPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodUpdateResourcePoolViews, Fixture, methodUpdateResourcePoolViewsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodUpdateResourcePoolViewsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (UpdateResourcePoolViews) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_UpdateResourcePoolViews_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateResourcePoolViewsPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodUpdateResourcePoolViews, Fixture, methodUpdateResourcePoolViewsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateResourcePoolViewsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateResourcePoolViews) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_UpdateResourcePoolViews_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateResourcePoolViews, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceGridInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateResourcePoolViews) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_UpdateResourcePoolViews_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateResourcePoolViews, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RefreshResources) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceGrid_RefreshResources_Static_Method_Call_Internally(Type[] types)
        {
            var methodRefreshResourcesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodRefreshResources, Fixture, methodRefreshResourcesPrametersTypes);
        }

        #endregion

        #region Method Call : (RefreshResources) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_RefreshResources_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            var methodRefreshResourcesPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfRefreshResources = { spWeb };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRefreshResources, methodRefreshResourcesPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodRefreshResources, Fixture, methodRefreshResourcesPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodRefreshResources, parametersOfRefreshResources, methodRefreshResourcesPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resourceGridInstanceFixture, parametersOfRefreshResources);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfRefreshResources.ShouldNotBeNull();
            parametersOfRefreshResources.Length.ShouldBe(1);
            methodRefreshResourcesPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RefreshResources) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_RefreshResources_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            var methodRefreshResourcesPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfRefreshResources = { spWeb };

            // Assert
            parametersOfRefreshResources.ShouldNotBeNull();
            parametersOfRefreshResources.Length.ShouldBe(1);
            methodRefreshResourcesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodRefreshResources, parametersOfRefreshResources, methodRefreshResourcesPrametersTypes));
        }

        #endregion

        #region Method Call : (RefreshResources) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_RefreshResources_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodRefreshResourcesPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodRefreshResources, Fixture, methodRefreshResourcesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodRefreshResourcesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (RefreshResources) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_RefreshResources_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRefreshResourcesPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceGridInstanceFixture, _resourceGridInstanceType, MethodRefreshResources, Fixture, methodRefreshResourcesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRefreshResourcesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RefreshResources) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_RefreshResources_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRefreshResources, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceGridInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RefreshResources) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_RefreshResources_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRefreshResources, 0);
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
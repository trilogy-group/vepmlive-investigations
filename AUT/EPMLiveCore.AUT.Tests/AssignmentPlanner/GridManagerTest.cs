using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.AssignmentPlanner
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.AssignmentPlanner.GridManager" />)
    ///     and namespace <see cref="EPMLiveCore.AssignmentPlanner"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class GridManagerTest : AbstractBaseSetupTypedTest<GridManager>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (GridManager) Initializer

        private const string MethodDeleteViews = "DeleteViews";
        private const string MethodGetData = "GetData";
        private const string MethodGetLayout = "GetLayout";
        private const string MethodGetModel = "GetModel";
        private const string MethodLoadModels = "LoadModels";
        private const string MethodLoadViews = "LoadViews";
        private const string MethodSaveModels = "SaveModels";
        private const string MethodSaveViews = "SaveViews";
        private const string MethodUpdateViews = "UpdateViews";
        private const string MethodConfigureColumns = "ConfigureColumns";
        private const string MethodConfigureDefaultColumns = "ConfigureDefaultColumns";
        private const string MethodGetGanttExclude = "GetGanttExclude";
        private const string MethodRegisterGridIdAndCss = "RegisterGridIdAndCss";
        private const string MethodValidateMyWorkDataResponse = "ValidateMyWorkDataResponse";
        private const string FieldComponentName = "ComponentName";
        private const string FieldReportingConnectionError = "ReportingConnectionError";
        private const string Field_spWeb = "_spWeb";
        private Type _gridManagerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private GridManager _gridManagerInstance;
        private GridManager _gridManagerInstanceFixture;

        #region General Initializer : Class (GridManager) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="GridManager" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _gridManagerInstanceType = typeof(GridManager);
            _gridManagerInstanceFixture = Create(true);
            _gridManagerInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (GridManager)

        #region General Initializer : Class (GridManager) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="GridManager" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodDeleteViews, 0)]
        [TestCase(MethodGetData, 0)]
        [TestCase(MethodGetLayout, 0)]
        [TestCase(MethodGetModel, 0)]
        [TestCase(MethodLoadModels, 0)]
        [TestCase(MethodLoadViews, 0)]
        [TestCase(MethodSaveModels, 0)]
        [TestCase(MethodSaveViews, 0)]
        [TestCase(MethodUpdateViews, 0)]
        [TestCase(MethodConfigureColumns, 0)]
        [TestCase(MethodConfigureDefaultColumns, 0)]
        [TestCase(MethodGetGanttExclude, 0)]
        [TestCase(MethodRegisterGridIdAndCss, 0)]
        [TestCase(MethodValidateMyWorkDataResponse, 0)]
        public void AUT_GridManager_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_gridManagerInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (GridManager) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="GridManager" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldComponentName)]
        [TestCase(FieldReportingConnectionError)]
        [TestCase(Field_spWeb)]
        public void AUT_GridManager_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_gridManagerInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="GridManager" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodConfigureColumns)]
        [TestCase(MethodConfigureDefaultColumns)]
        [TestCase(MethodRegisterGridIdAndCss)]
        [TestCase(MethodValidateMyWorkDataResponse)]
        public void AUT_GridManager_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_gridManagerInstanceFixture,
                                                                              _gridManagerInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="GridManager" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodDeleteViews)]
        [TestCase(MethodGetData)]
        [TestCase(MethodGetLayout)]
        [TestCase(MethodGetModel)]
        [TestCase(MethodLoadModels)]
        [TestCase(MethodLoadViews)]
        [TestCase(MethodSaveModels)]
        [TestCase(MethodSaveViews)]
        [TestCase(MethodUpdateViews)]
        [TestCase(MethodGetGanttExclude)]
        public void AUT_GridManager_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<GridManager>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (DeleteViews) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridManager_DeleteViews_Method_Call_Internally(Type[] types)
        {
            var methodDeleteViewsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridManagerInstance, MethodDeleteViews, Fixture, methodDeleteViewsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridManager_GetData_Method_Call_Internally(Type[] types)
        {
            var methodGetDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridManagerInstance, MethodGetData, Fixture, methodGetDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetLayout) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridManager_GetLayout_Method_Call_Internally(Type[] types)
        {
            var methodGetLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridManagerInstance, MethodGetLayout, Fixture, methodGetLayoutPrametersTypes);
        }

        #endregion

        #region Method Call : (GetModel) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridManager_GetModel_Method_Call_Internally(Type[] types)
        {
            var methodGetModelPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridManagerInstance, MethodGetModel, Fixture, methodGetModelPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadModels) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridManager_LoadModels_Method_Call_Internally(Type[] types)
        {
            var methodLoadModelsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridManagerInstance, MethodLoadModels, Fixture, methodLoadModelsPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadViews) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridManager_LoadViews_Method_Call_Internally(Type[] types)
        {
            var methodLoadViewsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridManagerInstance, MethodLoadViews, Fixture, methodLoadViewsPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveModels) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridManager_SaveModels_Method_Call_Internally(Type[] types)
        {
            var methodSaveModelsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridManagerInstance, MethodSaveModels, Fixture, methodSaveModelsPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveViews) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridManager_SaveViews_Method_Call_Internally(Type[] types)
        {
            var methodSaveViewsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridManagerInstance, MethodSaveViews, Fixture, methodSaveViewsPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateViews) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridManager_UpdateViews_Method_Call_Internally(Type[] types)
        {
            var methodUpdateViewsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridManagerInstance, MethodUpdateViews, Fixture, methodUpdateViewsPrametersTypes);
        }

        #endregion

        #region Method Call : (ConfigureColumns) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridManager_ConfigureColumns_Static_Method_Call_Internally(Type[] types)
        {
            var methodConfigureColumnsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_gridManagerInstanceFixture, _gridManagerInstanceType, MethodConfigureColumns, Fixture, methodConfigureColumnsPrametersTypes);
        }

        #endregion

        #region Method Call : (ConfigureDefaultColumns) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridManager_ConfigureDefaultColumns_Static_Method_Call_Internally(Type[] types)
        {
            var methodConfigureDefaultColumnsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_gridManagerInstanceFixture, _gridManagerInstanceType, MethodConfigureDefaultColumns, Fixture, methodConfigureDefaultColumnsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetGanttExclude) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridManager_GetGanttExclude_Method_Call_Internally(Type[] types)
        {
            var methodGetGanttExcludePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridManagerInstance, MethodGetGanttExclude, Fixture, methodGetGanttExcludePrametersTypes);
        }

        #endregion

        #region Method Call : (RegisterGridIdAndCss) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridManager_RegisterGridIdAndCss_Static_Method_Call_Internally(Type[] types)
        {
            var methodRegisterGridIdAndCssPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_gridManagerInstanceFixture, _gridManagerInstanceType, MethodRegisterGridIdAndCss, Fixture, methodRegisterGridIdAndCssPrametersTypes);
        }

        #endregion

        #region Method Call : (ValidateMyWorkDataResponse) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridManager_ValidateMyWorkDataResponse_Static_Method_Call_Internally(Type[] types)
        {
            var methodValidateMyWorkDataResponsePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_gridManagerInstanceFixture, _gridManagerInstanceType, MethodValidateMyWorkDataResponse, Fixture, methodValidateMyWorkDataResponsePrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}
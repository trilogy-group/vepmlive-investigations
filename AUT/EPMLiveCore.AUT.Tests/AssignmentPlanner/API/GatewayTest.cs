using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.AssignmentPlanner.API
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.AssignmentPlanner.API.Gateway" />)
    ///     and namespace <see cref="EPMLiveCore.AssignmentPlanner.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class GatewayTest : AbstractBaseSetupTypedTest<Gateway>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Gateway) Initializer

        private const string MethodDeleteViews = "DeleteViews";
        private const string MethodGetGridData = "GetGridData";
        private const string MethodGetGridLayout = "GetGridLayout";
        private const string MethodGetModel = "GetModel";
        private const string MethodLoadModels = "LoadModels";
        private const string MethodLoadViews = "LoadViews";
        private const string MethodPublish = "Publish";
        private const string MethodSaveModels = "SaveModels";
        private const string MethodSaveViews = "SaveViews";
        private const string MethodUpdateViews = "UpdateViews";
        private Type _gatewayInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Gateway _gatewayInstance;
        private Gateway _gatewayInstanceFixture;

        #region General Initializer : Class (Gateway) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Gateway" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _gatewayInstanceType = typeof(Gateway);
            _gatewayInstanceFixture = Create(true);
            _gatewayInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Gateway)

        #region General Initializer : Class (Gateway) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Gateway" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodDeleteViews, 0)]
        [TestCase(MethodGetGridData, 0)]
        [TestCase(MethodGetGridLayout, 0)]
        [TestCase(MethodGetModel, 0)]
        [TestCase(MethodLoadModels, 0)]
        [TestCase(MethodLoadViews, 0)]
        [TestCase(MethodPublish, 0)]
        [TestCase(MethodSaveModels, 0)]
        [TestCase(MethodSaveViews, 0)]
        [TestCase(MethodUpdateViews, 0)]
        public void AUT_Gateway_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_gatewayInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="Gateway" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodDeleteViews)]
        [TestCase(MethodGetGridData)]
        [TestCase(MethodGetGridLayout)]
        [TestCase(MethodGetModel)]
        [TestCase(MethodLoadModels)]
        [TestCase(MethodLoadViews)]
        [TestCase(MethodPublish)]
        [TestCase(MethodSaveModels)]
        [TestCase(MethodSaveViews)]
        [TestCase(MethodUpdateViews)]
        public void AUT_Gateway_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<Gateway>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (DeleteViews) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gateway_DeleteViews_Method_Call_Internally(Type[] types)
        {
            var methodDeleteViewsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gatewayInstance, MethodDeleteViews, Fixture, methodDeleteViewsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetGridData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gateway_GetGridData_Method_Call_Internally(Type[] types)
        {
            var methodGetGridDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gatewayInstance, MethodGetGridData, Fixture, methodGetGridDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetGridLayout) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gateway_GetGridLayout_Method_Call_Internally(Type[] types)
        {
            var methodGetGridLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gatewayInstance, MethodGetGridLayout, Fixture, methodGetGridLayoutPrametersTypes);
        }

        #endregion

        #region Method Call : (GetModel) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gateway_GetModel_Method_Call_Internally(Type[] types)
        {
            var methodGetModelPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gatewayInstance, MethodGetModel, Fixture, methodGetModelPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadModels) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gateway_LoadModels_Method_Call_Internally(Type[] types)
        {
            var methodLoadModelsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gatewayInstance, MethodLoadModels, Fixture, methodLoadModelsPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadViews) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gateway_LoadViews_Method_Call_Internally(Type[] types)
        {
            var methodLoadViewsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gatewayInstance, MethodLoadViews, Fixture, methodLoadViewsPrametersTypes);
        }

        #endregion

        #region Method Call : (Publish) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gateway_Publish_Method_Call_Internally(Type[] types)
        {
            var methodPublishPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gatewayInstance, MethodPublish, Fixture, methodPublishPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveModels) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gateway_SaveModels_Method_Call_Internally(Type[] types)
        {
            var methodSaveModelsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gatewayInstance, MethodSaveModels, Fixture, methodSaveModelsPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveViews) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gateway_SaveViews_Method_Call_Internally(Type[] types)
        {
            var methodSaveViewsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gatewayInstance, MethodSaveViews, Fixture, methodSaveViewsPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateViews) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gateway_UpdateViews_Method_Call_Internally(Type[] types)
        {
            var methodUpdateViewsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gatewayInstance, MethodUpdateViews, Fixture, methodUpdateViewsPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}
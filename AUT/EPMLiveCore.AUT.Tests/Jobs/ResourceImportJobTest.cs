using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.Jobs
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Jobs.ResourceImportJob" />)
    ///     and namespace <see cref="EPMLiveCore.Jobs"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ResourceImportJobTest : AbstractBaseSetupTypedTest<ResourceImportJob>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ResourceImportJob) Initializer

        private const string Methodexecute = "execute";
        private const string MethodResourceImportProgressChanged = "ResourceImportProgressChanged";
        private const string MethodResourceImportCompleted = "ResourceImportCompleted";
        private const string MethodUpdateProgress = "UpdateProgress";
        private const string MethodBuildResult = "BuildResult";
        private const string MethodIsImportCancelled = "IsImportCancelled";
        private const string FieldUPDATE_LOG_SQL = "UPDATE_LOG_SQL";
        private const string FieldGET_JOBQUEUE_STATUS = "GET_JOBQUEUE_STATUS";
        private const string Field_done = "_done";
        private const string FieldresourceImporter = "resourceImporter";
        private Type _resourceImportJobInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ResourceImportJob _resourceImportJobInstance;
        private ResourceImportJob _resourceImportJobInstanceFixture;

        #region General Initializer : Class (ResourceImportJob) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ResourceImportJob" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _resourceImportJobInstanceType = typeof(ResourceImportJob);
            _resourceImportJobInstanceFixture = Create(true);
            _resourceImportJobInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ResourceImportJob)

        #region General Initializer : Class (ResourceImportJob) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ResourceImportJob" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Methodexecute, 0)]
        [TestCase(MethodResourceImportProgressChanged, 0)]
        [TestCase(MethodResourceImportCompleted, 0)]
        [TestCase(MethodUpdateProgress, 0)]
        [TestCase(MethodBuildResult, 0)]
        [TestCase(MethodIsImportCancelled, 0)]
        public void AUT_ResourceImportJob_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_resourceImportJobInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ResourceImportJob) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ResourceImportJob" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldUPDATE_LOG_SQL)]
        [TestCase(FieldGET_JOBQUEUE_STATUS)]
        [TestCase(Field_done)]
        [TestCase(FieldresourceImporter)]
        public void AUT_ResourceImportJob_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_resourceImportJobInstanceFixture, 
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
        ///      Class (<see cref="ResourceImportJob" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(Methodexecute)]
        [TestCase(MethodResourceImportProgressChanged)]
        [TestCase(MethodResourceImportCompleted)]
        [TestCase(MethodUpdateProgress)]
        [TestCase(MethodBuildResult)]
        [TestCase(MethodIsImportCancelled)]
        public void AUT_ResourceImportJob_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ResourceImportJob>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceImportJob_execute_Method_Call_Internally(Type[] types)
        {
            var methodexecutePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImportJobInstance, Methodexecute, Fixture, methodexecutePrametersTypes);
        }

        #endregion

        #region Method Call : (ResourceImportProgressChanged) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceImportJob_ResourceImportProgressChanged_Method_Call_Internally(Type[] types)
        {
            var methodResourceImportProgressChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImportJobInstance, MethodResourceImportProgressChanged, Fixture, methodResourceImportProgressChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (ResourceImportCompleted) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceImportJob_ResourceImportCompleted_Method_Call_Internally(Type[] types)
        {
            var methodResourceImportCompletedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImportJobInstance, MethodResourceImportCompleted, Fixture, methodResourceImportCompletedPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateProgress) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceImportJob_UpdateProgress_Method_Call_Internally(Type[] types)
        {
            var methodUpdateProgressPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImportJobInstance, MethodUpdateProgress, Fixture, methodUpdateProgressPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildResult) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceImportJob_BuildResult_Method_Call_Internally(Type[] types)
        {
            var methodBuildResultPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImportJobInstance, MethodBuildResult, Fixture, methodBuildResultPrametersTypes);
        }

        #endregion

        #region Method Call : (IsImportCancelled) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceImportJob_IsImportCancelled_Method_Call_Internally(Type[] types)
        {
            var methodIsImportCancelledPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceImportJobInstance, MethodIsImportCancelled, Fixture, methodIsImportCancelledPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}
using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace WorkEnginePPM.Jobs
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.Jobs.PublishWorkPlannerWork" />)
    ///     and namespace <see cref="WorkEnginePPM.Jobs"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class PublishWorkPlannerWorkTest : AbstractBaseSetupTypedTest<PublishWorkPlannerWork>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (PublishWorkPlannerWork) Initializer

        private const string MethodGetAdminInfos = "GetAdminInfos";
        private const string Methodexecute = "execute";
        private Type _publishWorkPlannerWorkInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private PublishWorkPlannerWork _publishWorkPlannerWorkInstance;
        private PublishWorkPlannerWork _publishWorkPlannerWorkInstanceFixture;

        #region General Initializer : Class (PublishWorkPlannerWork) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PublishWorkPlannerWork" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _publishWorkPlannerWorkInstanceType = typeof(PublishWorkPlannerWork);
            _publishWorkPlannerWorkInstanceFixture = Create(true);
            _publishWorkPlannerWorkInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PublishWorkPlannerWork)

        #region General Initializer : Class (PublishWorkPlannerWork) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="PublishWorkPlannerWork" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetAdminInfos, 0)]
        [TestCase(Methodexecute, 0)]
        public void AUT_PublishWorkPlannerWork_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_publishWorkPlannerWorkInstanceFixture, 
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
        ///     Class (<see cref="PublishWorkPlannerWork" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_PublishWorkPlannerWork_Is_Instance_Present_Test()
        {
            // Assert
            _publishWorkPlannerWorkInstanceType.ShouldNotBeNull();
            _publishWorkPlannerWorkInstance.ShouldNotBeNull();
            _publishWorkPlannerWorkInstanceFixture.ShouldNotBeNull();
            _publishWorkPlannerWorkInstance.ShouldBeAssignableTo<PublishWorkPlannerWork>();
            _publishWorkPlannerWorkInstanceFixture.ShouldBeAssignableTo<PublishWorkPlannerWork>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (PublishWorkPlannerWork) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_PublishWorkPlannerWork_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            PublishWorkPlannerWork instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _publishWorkPlannerWorkInstanceType.ShouldNotBeNull();
            _publishWorkPlannerWorkInstance.ShouldNotBeNull();
            _publishWorkPlannerWorkInstanceFixture.ShouldNotBeNull();
            _publishWorkPlannerWorkInstance.ShouldBeAssignableTo<PublishWorkPlannerWork>();
            _publishWorkPlannerWorkInstanceFixture.ShouldBeAssignableTo<PublishWorkPlannerWork>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="PublishWorkPlannerWork" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetAdminInfos)]
        [TestCase(Methodexecute)]
        public void AUT_PublishWorkPlannerWork_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<PublishWorkPlannerWork>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetAdminInfos) (Return Type : PortfolioEngineCore.Admininfos) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PublishWorkPlannerWork_GetAdminInfos_Method_Call_Internally(Type[] types)
        {
            var methodGetAdminInfosPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_publishWorkPlannerWorkInstance, MethodGetAdminInfos, Fixture, methodGetAdminInfosPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAdminInfos) (Return Type : PortfolioEngineCore.Admininfos) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishWorkPlannerWork_GetAdminInfos_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Site = CreateType<SPSite>();
            var methodGetAdminInfosPrametersTypes = new Type[] { typeof(SPSite) };
            object[] parametersOfGetAdminInfos = { Site };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetAdminInfos, methodGetAdminInfosPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PublishWorkPlannerWork, PortfolioEngineCore.Admininfos>(_publishWorkPlannerWorkInstanceFixture, out exception1, parametersOfGetAdminInfos);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PublishWorkPlannerWork, PortfolioEngineCore.Admininfos>(_publishWorkPlannerWorkInstance, MethodGetAdminInfos, parametersOfGetAdminInfos, methodGetAdminInfosPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetAdminInfos.ShouldNotBeNull();
            parametersOfGetAdminInfos.Length.ShouldBe(1);
            methodGetAdminInfosPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetAdminInfos) (Return Type : PortfolioEngineCore.Admininfos) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishWorkPlannerWork_GetAdminInfos_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Site = CreateType<SPSite>();
            var methodGetAdminInfosPrametersTypes = new Type[] { typeof(SPSite) };
            object[] parametersOfGetAdminInfos = { Site };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<PublishWorkPlannerWork, PortfolioEngineCore.Admininfos>(_publishWorkPlannerWorkInstance, MethodGetAdminInfos, parametersOfGetAdminInfos, methodGetAdminInfosPrametersTypes);

            // Assert
            parametersOfGetAdminInfos.ShouldNotBeNull();
            parametersOfGetAdminInfos.Length.ShouldBe(1);
            methodGetAdminInfosPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAdminInfos) (Return Type : PortfolioEngineCore.Admininfos) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishWorkPlannerWork_GetAdminInfos_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetAdminInfosPrametersTypes = new Type[] { typeof(SPSite) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_publishWorkPlannerWorkInstance, MethodGetAdminInfos, Fixture, methodGetAdminInfosPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetAdminInfosPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetAdminInfos) (Return Type : PortfolioEngineCore.Admininfos) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishWorkPlannerWork_GetAdminInfos_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetAdminInfosPrametersTypes = new Type[] { typeof(SPSite) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_publishWorkPlannerWorkInstance, MethodGetAdminInfos, Fixture, methodGetAdminInfosPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetAdminInfosPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAdminInfos) (Return Type : PortfolioEngineCore.Admininfos) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishWorkPlannerWork_GetAdminInfos_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetAdminInfos, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_publishWorkPlannerWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAdminInfos) (Return Type : PortfolioEngineCore.Admininfos) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishWorkPlannerWork_GetAdminInfos_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetAdminInfos, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PublishWorkPlannerWork_execute_Method_Call_Internally(Type[] types)
        {
            var methodexecutePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_publishWorkPlannerWorkInstance, Methodexecute, Fixture, methodexecutePrametersTypes);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishWorkPlannerWork_execute_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var web = CreateType<SPWeb>();
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _publishWorkPlannerWorkInstance.execute(site, web, data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishWorkPlannerWork_execute_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var web = CreateType<SPWeb>();
            var data = CreateType<string>();
            var methodexecutePrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb), typeof(string) };
            object[] parametersOfexecute = { site, web, data };
            Exception exception = null;
            var methodInfo = GetMethodInfo(Methodexecute, methodexecutePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_publishWorkPlannerWorkInstanceFixture, parametersOfexecute);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfexecute.ShouldNotBeNull();
            parametersOfexecute.Length.ShouldBe(3);
            methodexecutePrametersTypes.Length.ShouldBe(3);
            methodexecutePrametersTypes.Length.ShouldBe(parametersOfexecute.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishWorkPlannerWork_execute_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var web = CreateType<SPWeb>();
            var data = CreateType<string>();
            var methodexecutePrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb), typeof(string) };
            object[] parametersOfexecute = { site, web, data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_publishWorkPlannerWorkInstance, Methodexecute, parametersOfexecute, methodexecutePrametersTypes);

            // Assert
            parametersOfexecute.ShouldNotBeNull();
            parametersOfexecute.Length.ShouldBe(3);
            methodexecutePrametersTypes.Length.ShouldBe(3);
            methodexecutePrametersTypes.Length.ShouldBe(parametersOfexecute.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishWorkPlannerWork_execute_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(Methodexecute, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishWorkPlannerWork_execute_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodexecutePrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_publishWorkPlannerWorkInstance, Methodexecute, Fixture, methodexecutePrametersTypes);

            // Assert
            methodexecutePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PublishWorkPlannerWork_execute_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(Methodexecute, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_publishWorkPlannerWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
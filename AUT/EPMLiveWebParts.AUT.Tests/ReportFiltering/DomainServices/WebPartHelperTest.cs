using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts.ReportFiltering.DomainServices
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.ReportFiltering.DomainServices.WebPartHelper" />)
    ///     and namespace <see cref="EPMLiveWebParts.ReportFiltering.DomainServices"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class WebPartHelperTest : AbstractBaseSetupTypedTest<WebPartHelper>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WebPartHelper) Initializer

        private const string MethodConvertWebPartIdToGuid = "ConvertWebPartIdToGuid";
        private Type _webPartHelperInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private WebPartHelper _webPartHelperInstance;
        private WebPartHelper _webPartHelperInstanceFixture;

        #region General Initializer : Class (WebPartHelper) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WebPartHelper" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _webPartHelperInstanceType = typeof(WebPartHelper);
            _webPartHelperInstanceFixture = Create(true);
            _webPartHelperInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WebPartHelper)

        #region General Initializer : Class (WebPartHelper) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="WebPartHelper" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodConvertWebPartIdToGuid, 0)]
        public void AUT_WebPartHelper_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_webPartHelperInstanceFixture, 
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
        ///     Class (<see cref="WebPartHelper" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_WebPartHelper_Is_Instance_Present_Test()
        {
            // Assert
            _webPartHelperInstanceType.ShouldNotBeNull();
            _webPartHelperInstance.ShouldNotBeNull();
            _webPartHelperInstanceFixture.ShouldNotBeNull();
            _webPartHelperInstance.ShouldBeAssignableTo<WebPartHelper>();
            _webPartHelperInstanceFixture.ShouldBeAssignableTo<WebPartHelper>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (WebPartHelper) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_WebPartHelper_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            WebPartHelper instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _webPartHelperInstanceType.ShouldNotBeNull();
            _webPartHelperInstance.ShouldNotBeNull();
            _webPartHelperInstanceFixture.ShouldNotBeNull();
            _webPartHelperInstance.ShouldBeAssignableTo<WebPartHelper>();
            _webPartHelperInstanceFixture.ShouldBeAssignableTo<WebPartHelper>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="WebPartHelper" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodConvertWebPartIdToGuid)]
        public void AUT_WebPartHelper_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_webPartHelperInstanceFixture,
                                                                              _webPartHelperInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (ConvertWebPartIdToGuid) (Return Type : Guid?) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WebPartHelper_ConvertWebPartIdToGuid_Static_Method_Call_Internally(Type[] types)
        {
            var methodConvertWebPartIdToGuidPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webPartHelperInstanceFixture, _webPartHelperInstanceType, MethodConvertWebPartIdToGuid, Fixture, methodConvertWebPartIdToGuidPrametersTypes);
        }

        #endregion

        #region Method Call : (ConvertWebPartIdToGuid) (Return Type : Guid?) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartHelper_ConvertWebPartIdToGuid_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var webPartId = CreateType<string>();
            var methodConvertWebPartIdToGuidPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfConvertWebPartIdToGuid = { webPartId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<Guid?>(_webPartHelperInstanceFixture, _webPartHelperInstanceType, MethodConvertWebPartIdToGuid, parametersOfConvertWebPartIdToGuid, methodConvertWebPartIdToGuidPrametersTypes);

            // Assert
            parametersOfConvertWebPartIdToGuid.ShouldNotBeNull();
            parametersOfConvertWebPartIdToGuid.Length.ShouldBe(1);
            methodConvertWebPartIdToGuidPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConvertWebPartIdToGuid) (Return Type : Guid?) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartHelper_ConvertWebPartIdToGuid_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodConvertWebPartIdToGuidPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webPartHelperInstanceFixture, _webPartHelperInstanceType, MethodConvertWebPartIdToGuid, Fixture, methodConvertWebPartIdToGuidPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodConvertWebPartIdToGuidPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ConvertWebPartIdToGuid) (Return Type : Guid?) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebPartHelper_ConvertWebPartIdToGuid_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodConvertWebPartIdToGuid, 0);
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
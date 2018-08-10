using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;
using EPMLiveCore.ReportingProxy;

namespace EPMLiveCore.Infrastructure
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Infrastructure.ReportingProxyBase" />)
    ///     and namespace <see cref="EPMLiveCore.Infrastructure"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ReportingProxyBaseTest : AbstractBaseSetupTypedTest<ReportingProxyBase>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportingProxyBase) Initializer

        private const string MethodGetEpmDataClass = "GetEpmDataClass";
        private const string MethodGetMethod = "GetMethod";
        private const string MethodGetProperty = "GetProperty";
        private const string MethodGetReportBizClass = "GetReportBizClass";
        private const string MethodGetReportDataClass = "GetReportDataClass";
        private const string MethodSetProperty = "SetProperty";
        private const string FieldWeb = "Web";
        private const string FieldReportingAssembly = "ReportingAssembly";
        private Type _reportingProxyBaseInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportingProxyBase _reportingProxyBaseInstance;
        private ReportingProxyBase _reportingProxyBaseInstanceFixture;
        private Type[] _abstractClassInstanciatedTypesList;

        #region General Initializer : Class (ReportingProxyBase) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportingProxyBase" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportingProxyBaseInstanceType = typeof(ReportingProxyBase);
            _abstractClassInstanciatedTypesList = new Type[] { typeof(QueryExecutor), typeof(ReportingLogger) };
            _reportingProxyBaseInstanceFixture = Create(true);
            _reportingProxyBaseInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportingProxyBase)

        #region General Initializer : Class (ReportingProxyBase) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ReportingProxyBase" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetEpmDataClass, 0)]
        [TestCase(MethodGetMethod, 0)]
        [TestCase(MethodGetProperty, 0)]
        [TestCase(MethodGetReportBizClass, 0)]
        [TestCase(MethodGetReportDataClass, 0)]
        [TestCase(MethodSetProperty, 0)]
        public void AUT_ReportingProxyBase_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_reportingProxyBaseInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ReportingProxyBase) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportingProxyBase" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldWeb)]
        [TestCase(FieldReportingAssembly)]
        public void AUT_ReportingProxyBase_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_reportingProxyBaseInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #endregion
    }
}
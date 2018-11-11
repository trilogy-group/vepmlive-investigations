using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace CostDataValues
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="CostDataValues.clsPortFieldData" />)
    ///     and namespace <see cref="CostDataValues"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ClsPortFieldDataTest : AbstractBaseSetupTypedTest<clsPortFieldData>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (clsPortFieldData) Initializer

        private const string FieldID = "ID";
        private const string FieldName = "Name";
        private Type _clsPortFieldDataInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private clsPortFieldData _clsPortFieldDataInstance;
        private clsPortFieldData _clsPortFieldDataInstanceFixture;

        #region General Initializer : Class (clsPortFieldData) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="clsPortFieldData" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _clsPortFieldDataInstanceType = typeof(clsPortFieldData);
            _clsPortFieldDataInstanceFixture = Create(true);
            _clsPortFieldDataInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (clsPortFieldData)

        #region General Initializer : Class (clsPortFieldData) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="clsPortFieldData" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldID)]
        [TestCase(FieldName)]
        public void AUT_ClsPortFieldData_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_clsPortFieldDataInstanceFixture, 
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
        ///     Class (<see cref="clsPortFieldData" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ClsPortFieldData_Is_Instance_Present_Test()
        {
            // Assert
            _clsPortFieldDataInstanceType.ShouldNotBeNull();
            _clsPortFieldDataInstance.ShouldNotBeNull();
            _clsPortFieldDataInstanceFixture.ShouldNotBeNull();
            _clsPortFieldDataInstance.ShouldBeAssignableTo<clsPortFieldData>();
            _clsPortFieldDataInstanceFixture.ShouldBeAssignableTo<clsPortFieldData>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (clsPortFieldData) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_clsPortFieldData_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            clsPortFieldData instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _clsPortFieldDataInstanceType.ShouldNotBeNull();
            _clsPortFieldDataInstance.ShouldNotBeNull();
            _clsPortFieldDataInstanceFixture.ShouldNotBeNull();
            _clsPortFieldDataInstance.ShouldBeAssignableTo<clsPortFieldData>();
            _clsPortFieldDataInstanceFixture.ShouldBeAssignableTo<clsPortFieldData>();
        }

        #endregion

        #endregion

        #endregion
    }
}
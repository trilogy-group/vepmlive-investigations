using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace CostDataValues
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="CostDataValues.clsCustomFieldData" />)
    ///     and namespace <see cref="CostDataValues"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ClsCustomFieldDataTest : AbstractBaseSetupTypedTest<clsCustomFieldData>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (clsCustomFieldData) Initializer

        private const string PropertyFieldID = "FieldID";
        private const string PropertyName = "Name";
        private const string PropertyDisplayName = "DisplayName";
        private const string PropertyLookupOnly = "LookupOnly";
        private const string PropertyLookupID = "LookupID";
        private const string PropertyLeafOnly = "LeafOnly";
        private const string PropertyUseFullName = "UseFullName";
        private const string PropertyListItems = "ListItems";
        private const string PropertyjsonMenu = "jsonMenu";
        private Type _clsCustomFieldDataInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private clsCustomFieldData _clsCustomFieldDataInstance;
        private clsCustomFieldData _clsCustomFieldDataInstanceFixture;

        #region General Initializer : Class (clsCustomFieldData) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="clsCustomFieldData" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _clsCustomFieldDataInstanceType = typeof(clsCustomFieldData);
            _clsCustomFieldDataInstanceFixture = Create(true);
            _clsCustomFieldDataInstance = Create(false);
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="clsCustomFieldData" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ClsCustomFieldData_Is_Instance_Present_Test()
        {
            // Assert
            _clsCustomFieldDataInstanceType.ShouldNotBeNull();
            _clsCustomFieldDataInstance.ShouldNotBeNull();
            _clsCustomFieldDataInstanceFixture.ShouldNotBeNull();
            _clsCustomFieldDataInstance.ShouldBeAssignableTo<clsCustomFieldData>();
            _clsCustomFieldDataInstanceFixture.ShouldBeAssignableTo<clsCustomFieldData>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (clsCustomFieldData) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_clsCustomFieldData_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            clsCustomFieldData instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _clsCustomFieldDataInstanceType.ShouldNotBeNull();
            _clsCustomFieldDataInstance.ShouldNotBeNull();
            _clsCustomFieldDataInstanceFixture.ShouldNotBeNull();
            _clsCustomFieldDataInstance.ShouldBeAssignableTo<clsCustomFieldData>();
            _clsCustomFieldDataInstanceFixture.ShouldBeAssignableTo<clsCustomFieldData>();
        }

        #endregion

        #endregion

        #endregion
    }
}
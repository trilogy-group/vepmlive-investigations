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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="CostDataValues.clsTargetRowData" />)
    ///     and namespace <see cref="CostDataValues"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ClsTargetRowDataTest : AbstractBaseSetupTypedTest<clsTargetRowData>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (clsTargetRowData) Initializer

        private const string PropertyCT_ID = "CT_ID";
        private const string PropertyBC_UID = "BC_UID";
        private const string PropertyBC_ROLE_UID = "BC_ROLE_UID";
        private const string PropertyBC_SEQ = "BC_SEQ";
        private const string PropertyMC_Val = "MC_Val";
        private const string PropertyCAT_UID = "CAT_UID";
        private const string PropertyCT_Name = "CT_Name";
        private const string PropertyCat_Name = "Cat_Name";
        private const string PropertyRole_Name = "Role_Name";
        private const string PropertyMC_Name = "MC_Name";
        private const string PropertyFullCatName = "FullCatName";
        private const string PropertyCC_Name = "CC_Name";
        private const string PropertyFullCCName = "FullCCName";
        private const string PropertyGrouping = "Grouping";
        private const string PropertybGroupRow = "bGroupRow";
        private const string Propertym_rt = "m_rt";
        private const string Propertym_rt_name = "m_rt_name";
        private const string PropertysUoM = "sUoM";
        private const string PropertyzCost = "zCost";
        private const string PropertyzValue = "zValue";
        private const string PropertyzFTE = "zFTE";
        private const string PropertyOCVal = "OCVal";
        private const string PropertyText_OCVal = "Text_OCVal";
        private const string PropertyTXVal = "TXVal";
        private Type _clsTargetRowDataInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private clsTargetRowData _clsTargetRowDataInstance;
        private clsTargetRowData _clsTargetRowDataInstanceFixture;

        #region General Initializer : Class (clsTargetRowData) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="clsTargetRowData" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _clsTargetRowDataInstanceType = typeof(clsTargetRowData);
            _clsTargetRowDataInstanceFixture = Create(true);
            _clsTargetRowDataInstance = Create(false);
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="clsTargetRowData" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ClsTargetRowData_Is_Instance_Present_Test()
        {
            // Assert
            _clsTargetRowDataInstanceType.ShouldNotBeNull();
            _clsTargetRowDataInstance.ShouldNotBeNull();
            _clsTargetRowDataInstanceFixture.ShouldNotBeNull();
            _clsTargetRowDataInstance.ShouldBeAssignableTo<clsTargetRowData>();
            _clsTargetRowDataInstanceFixture.ShouldBeAssignableTo<clsTargetRowData>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (clsTargetRowData) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_clsTargetRowData_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            clsTargetRowData instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _clsTargetRowDataInstanceType.ShouldNotBeNull();
            _clsTargetRowDataInstance.ShouldNotBeNull();
            _clsTargetRowDataInstanceFixture.ShouldNotBeNull();
            _clsTargetRowDataInstance.ShouldBeAssignableTo<clsTargetRowData>();
            _clsTargetRowDataInstanceFixture.ShouldBeAssignableTo<clsTargetRowData>();
        }

        #endregion

        #endregion

        #endregion
    }
}
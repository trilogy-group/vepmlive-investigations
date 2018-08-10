using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps.AddListData" />)
    ///     and namespace <see cref="EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class AddListDataTest : AbstractBaseSetupTypedTest<AddListData>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (AddListData) Initializer

        private const string PropertyDescription = "Description";
        private const string MethodPerform = "Perform";
        private const string MethodProcessResources = "ProcessResources";
        private const string MethodProcessNonWork = "ProcessNonWork";
        private const string MethodProcessRoles = "ProcessRoles";
        private const string MethodProcessDepartments = "ProcessDepartments";
        private const string MethodProcessWorkHours = "ProcessWorkHours";
        private const string MethodProcessHolidays = "ProcessHolidays";
        private Type _addListDataInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private AddListData _addListDataInstance;
        private AddListData _addListDataInstanceFixture;

        #region General Initializer : Class (AddListData) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="AddListData" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _addListDataInstanceType = typeof(AddListData);
            _addListDataInstanceFixture = Create(true);
            _addListDataInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (AddListData)

        #region General Initializer : Class (AddListData) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="AddListData" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPerform, 0)]
        [TestCase(MethodProcessResources, 0)]
        [TestCase(MethodProcessNonWork, 0)]
        [TestCase(MethodProcessRoles, 0)]
        [TestCase(MethodProcessDepartments, 0)]
        [TestCase(MethodProcessWorkHours, 0)]
        [TestCase(MethodProcessHolidays, 0)]
        public void AUT_AddListData_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_addListDataInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (AddListData) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="AddListData" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyDescription)]
        public void AUT_AddListData_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_addListDataInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="AddListData" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPerform)]
        [TestCase(MethodProcessResources)]
        [TestCase(MethodProcessNonWork)]
        [TestCase(MethodProcessRoles)]
        [TestCase(MethodProcessDepartments)]
        [TestCase(MethodProcessWorkHours)]
        [TestCase(MethodProcessHolidays)]
        public void AUT_AddListData_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<AddListData>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Perform) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AddListData_Perform_Method_Call_Internally(Type[] types)
        {
            var methodPerformPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addListDataInstance, MethodPerform, Fixture, methodPerformPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessResources) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AddListData_ProcessResources_Method_Call_Internally(Type[] types)
        {
            var methodProcessResourcesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addListDataInstance, MethodProcessResources, Fixture, methodProcessResourcesPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessNonWork) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AddListData_ProcessNonWork_Method_Call_Internally(Type[] types)
        {
            var methodProcessNonWorkPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addListDataInstance, MethodProcessNonWork, Fixture, methodProcessNonWorkPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessRoles) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AddListData_ProcessRoles_Method_Call_Internally(Type[] types)
        {
            var methodProcessRolesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addListDataInstance, MethodProcessRoles, Fixture, methodProcessRolesPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessDepartments) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AddListData_ProcessDepartments_Method_Call_Internally(Type[] types)
        {
            var methodProcessDepartmentsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addListDataInstance, MethodProcessDepartments, Fixture, methodProcessDepartmentsPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessWorkHours) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AddListData_ProcessWorkHours_Method_Call_Internally(Type[] types)
        {
            var methodProcessWorkHoursPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addListDataInstance, MethodProcessWorkHours, Fixture, methodProcessWorkHoursPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessHolidays) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AddListData_ProcessHolidays_Method_Call_Internally(Type[] types)
        {
            var methodProcessHolidaysPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addListDataInstance, MethodProcessHolidays, Fixture, methodProcessHolidaysPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}
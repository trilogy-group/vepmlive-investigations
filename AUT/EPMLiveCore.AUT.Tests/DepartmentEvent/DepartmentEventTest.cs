using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.DepartmentEvent" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class DepartmentEventTest : AbstractBaseSetupTypedTest<DepartmentEvent>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DepartmentEvent) Initializer

        private const string MethodItemAdding = "ItemAdding";
        private const string MethodItemUpdating = "ItemUpdating";
        private const string MethodItemDeleted = "ItemDeleted";
        private const string MethodprocessItem = "processItem";
        private const string MethodGetProperty = "GetProperty";
        private Type _departmentEventInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DepartmentEvent _departmentEventInstance;
        private DepartmentEvent _departmentEventInstanceFixture;

        #region General Initializer : Class (DepartmentEvent) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DepartmentEvent" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _departmentEventInstanceType = typeof(DepartmentEvent);
            _departmentEventInstanceFixture = Create(true);
            _departmentEventInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DepartmentEvent)

        #region General Initializer : Class (DepartmentEvent) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="DepartmentEvent" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodItemAdding, 0)]
        [TestCase(MethodItemUpdating, 0)]
        [TestCase(MethodItemDeleted, 0)]
        [TestCase(MethodprocessItem, 0)]
        [TestCase(MethodGetProperty, 0)]
        public void AUT_DepartmentEvent_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_departmentEventInstanceFixture, 
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
        ///      Class (<see cref="DepartmentEvent" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodItemAdding)]
        [TestCase(MethodItemUpdating)]
        [TestCase(MethodItemDeleted)]
        [TestCase(MethodprocessItem)]
        [TestCase(MethodGetProperty)]
        public void AUT_DepartmentEvent_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<DepartmentEvent>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (ItemAdding) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DepartmentEvent_ItemAdding_Method_Call_Internally(Type[] types)
        {
            var methodItemAddingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_departmentEventInstance, MethodItemAdding, Fixture, methodItemAddingPrametersTypes);
        }

        #endregion

        #region Method Call : (ItemUpdating) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DepartmentEvent_ItemUpdating_Method_Call_Internally(Type[] types)
        {
            var methodItemUpdatingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_departmentEventInstance, MethodItemUpdating, Fixture, methodItemUpdatingPrametersTypes);
        }

        #endregion

        #region Method Call : (ItemDeleted) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DepartmentEvent_ItemDeleted_Method_Call_Internally(Type[] types)
        {
            var methodItemDeletedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_departmentEventInstance, MethodItemDeleted, Fixture, methodItemDeletedPrametersTypes);
        }

        #endregion

        #region Method Call : (processItem) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DepartmentEvent_processItem_Method_Call_Internally(Type[] types)
        {
            var methodprocessItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_departmentEventInstance, MethodprocessItem, Fixture, methodprocessItemPrametersTypes);
        }

        #endregion

        #region Method Call : (GetProperty) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DepartmentEvent_GetProperty_Method_Call_Internally(Type[] types)
        {
            var methodGetPropertyPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_departmentEventInstance, MethodGetProperty, Fixture, methodGetPropertyPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}
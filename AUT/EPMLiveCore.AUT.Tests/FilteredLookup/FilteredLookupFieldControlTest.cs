using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.FilteredLookupFieldControl" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class FilteredLookupFieldControlTest : AbstractBaseSetupTypedTest<FilteredLookupFieldControl>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FilteredLookupFieldControl) Initializer

        private const string PropertyDefaultTemplateName = "DefaultTemplateName";
        private const string PropertyValue = "Value";
        private const string MethodOnInit = "OnInit";
        private const string MethodOnLoad = "OnLoad";
        private const string MethodCreateChildControls = "CreateChildControls";
        private const string MethodIsExplorerOnWin = "IsExplorerOnWin";
        private const string MethodCreateStandardSelect = "CreateStandardSelect";
        private const string MethodCreateCustomSelect = "CreateCustomSelect";
        private const string MethodConcatAvailableItems = "ConcatAvailableItems";
        private const string MethodGetRenderingWebControl = "GetRenderingWebControl";
        private const string MethodInitialize = "Initialize";
        private const string MethodEnsureValueIsAvailable = "EnsureValueIsAvailable";
        private const string MethodGetCustomSelectValue = "GetCustomSelectValue";
        private const string MethodSetCustomSelectValue = "SetCustomSelectValue";
        private const string MethodSetValue = "SetValue";
        private const string Field_fieldVal = "_fieldVal";
        private const string Field_availableItems = "_availableItems";
        private Type _filteredLookupFieldControlInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private FilteredLookupFieldControl _filteredLookupFieldControlInstance;
        private FilteredLookupFieldControl _filteredLookupFieldControlInstanceFixture;

        #region General Initializer : Class (FilteredLookupFieldControl) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FilteredLookupFieldControl" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _filteredLookupFieldControlInstanceType = typeof(FilteredLookupFieldControl);
            _filteredLookupFieldControlInstanceFixture = Create(true);
            _filteredLookupFieldControlInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FilteredLookupFieldControl)

        #region General Initializer : Class (FilteredLookupFieldControl) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="FilteredLookupFieldControl" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodOnInit, 0)]
        [TestCase(MethodOnLoad, 0)]
        [TestCase(MethodCreateChildControls, 0)]
        [TestCase(MethodIsExplorerOnWin, 0)]
        [TestCase(MethodCreateStandardSelect, 0)]
        [TestCase(MethodCreateCustomSelect, 0)]
        [TestCase(MethodConcatAvailableItems, 0)]
        [TestCase(MethodGetRenderingWebControl, 0)]
        [TestCase(MethodInitialize, 0)]
        [TestCase(MethodEnsureValueIsAvailable, 0)]
        [TestCase(MethodGetCustomSelectValue, 0)]
        [TestCase(MethodSetCustomSelectValue, 0)]
        [TestCase(MethodSetValue, 0)]
        public void AUT_FilteredLookupFieldControl_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_filteredLookupFieldControlInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FilteredLookupFieldControl) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="FilteredLookupFieldControl" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyDefaultTemplateName)]
        [TestCase(PropertyValue)]
        public void AUT_FilteredLookupFieldControl_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_filteredLookupFieldControlInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FilteredLookupFieldControl) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FilteredLookupFieldControl" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_fieldVal)]
        [TestCase(Field_availableItems)]
        public void AUT_FilteredLookupFieldControl_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_filteredLookupFieldControlInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (FilteredLookupFieldControl) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyDefaultTemplateName)]
        [TestCaseGeneric(typeof(object) , PropertyValue)]
        public void AUT_FilteredLookupFieldControl_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<FilteredLookupFieldControl, T>(_filteredLookupFieldControlInstance, propertyName, Fixture);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="FilteredLookupFieldControl" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodOnInit)]
        [TestCase(MethodOnLoad)]
        [TestCase(MethodCreateChildControls)]
        [TestCase(MethodIsExplorerOnWin)]
        [TestCase(MethodCreateStandardSelect)]
        [TestCase(MethodCreateCustomSelect)]
        [TestCase(MethodConcatAvailableItems)]
        [TestCase(MethodGetRenderingWebControl)]
        [TestCase(MethodInitialize)]
        [TestCase(MethodEnsureValueIsAvailable)]
        [TestCase(MethodGetCustomSelectValue)]
        [TestCase(MethodSetCustomSelectValue)]
        [TestCase(MethodSetValue)]
        public void AUT_FilteredLookupFieldControl_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<FilteredLookupFieldControl>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FilteredLookupFieldControl_OnInit_Method_Call_Internally(Type[] types)
        {
            var methodOnInitPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldControlInstance, MethodOnInit, Fixture, methodOnInitPrametersTypes);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FilteredLookupFieldControl_OnLoad_Method_Call_Internally(Type[] types)
        {
            var methodOnLoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldControlInstance, MethodOnLoad, Fixture, methodOnLoadPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FilteredLookupFieldControl_CreateChildControls_Method_Call_Internally(Type[] types)
        {
            var methodCreateChildControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldControlInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (IsExplorerOnWin) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FilteredLookupFieldControl_IsExplorerOnWin_Method_Call_Internally(Type[] types)
        {
            var methodIsExplorerOnWinPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldControlInstance, MethodIsExplorerOnWin, Fixture, methodIsExplorerOnWinPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateStandardSelect) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FilteredLookupFieldControl_CreateStandardSelect_Method_Call_Internally(Type[] types)
        {
            var methodCreateStandardSelectPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldControlInstance, MethodCreateStandardSelect, Fixture, methodCreateStandardSelectPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateCustomSelect) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FilteredLookupFieldControl_CreateCustomSelect_Method_Call_Internally(Type[] types)
        {
            var methodCreateCustomSelectPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldControlInstance, MethodCreateCustomSelect, Fixture, methodCreateCustomSelectPrametersTypes);
        }

        #endregion

        #region Method Call : (ConcatAvailableItems) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FilteredLookupFieldControl_ConcatAvailableItems_Method_Call_Internally(Type[] types)
        {
            var methodConcatAvailableItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldControlInstance, MethodConcatAvailableItems, Fixture, methodConcatAvailableItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetRenderingWebControl) (Return Type : Control) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FilteredLookupFieldControl_GetRenderingWebControl_Method_Call_Internally(Type[] types)
        {
            var methodGetRenderingWebControlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldControlInstance, MethodGetRenderingWebControl, Fixture, methodGetRenderingWebControlPrametersTypes);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FilteredLookupFieldControl_Initialize_Method_Call_Internally(Type[] types)
        {
            var methodInitializePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldControlInstance, MethodInitialize, Fixture, methodInitializePrametersTypes);
        }

        #endregion

        #region Method Call : (EnsureValueIsAvailable) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FilteredLookupFieldControl_EnsureValueIsAvailable_Method_Call_Internally(Type[] types)
        {
            var methodEnsureValueIsAvailablePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldControlInstance, MethodEnsureValueIsAvailable, Fixture, methodEnsureValueIsAvailablePrametersTypes);
        }

        #endregion

        #region Method Call : (GetCustomSelectValue) (Return Type : SPFieldLookupValue) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FilteredLookupFieldControl_GetCustomSelectValue_Method_Call_Internally(Type[] types)
        {
            var methodGetCustomSelectValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldControlInstance, MethodGetCustomSelectValue, Fixture, methodGetCustomSelectValuePrametersTypes);
        }

        #endregion

        #region Method Call : (SetCustomSelectValue) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FilteredLookupFieldControl_SetCustomSelectValue_Method_Call_Internally(Type[] types)
        {
            var methodSetCustomSelectValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldControlInstance, MethodSetCustomSelectValue, Fixture, methodSetCustomSelectValuePrametersTypes);
        }

        #endregion

        #region Method Call : (SetValue) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FilteredLookupFieldControl_SetValue_Method_Call_Internally(Type[] types)
        {
            var methodSetValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldControlInstance, MethodSetValue, Fixture, methodSetValuePrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}
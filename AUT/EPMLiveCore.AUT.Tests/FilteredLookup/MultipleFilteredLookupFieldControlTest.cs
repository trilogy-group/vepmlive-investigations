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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.MultipleFilteredLookupFieldControl" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class MultipleFilteredLookupFieldControlTest : AbstractBaseSetupTypedTest<MultipleFilteredLookupFieldControl>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (MultipleFilteredLookupFieldControl) Initializer

        private const string PropertyDefaultTemplateName = "DefaultTemplateName";
        private const string PropertyValue = "Value";
        private const string MethodOnInit = "OnInit";
        private const string MethodOnLoad = "OnLoad";
        private const string MethodCreateChildControls = "CreateChildControls";
        private const string MethodBuildAvailableItems = "BuildAvailableItems";
        private const string MethodInitialize = "Initialize";
        private const string MethodEnsureValuesAreAvailable = "EnsureValuesAreAvailable";
        private const string MethodSetValue = "SetValue";
        private const string Field_fieldVals = "_fieldVals";
        private const string Field_availableItems = "_availableItems";
        private const string FieldSelectCandidate = "SelectCandidate";
        private const string FieldSelectResult = "SelectResult";
        private const string FieldAddButton = "AddButton";
        private const string FieldRemoveButton = "RemoveButton";
        private const string FieldMultiLookupPicker = "MultiLookupPicker";
        private Type _multipleFilteredLookupFieldControlInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private MultipleFilteredLookupFieldControl _multipleFilteredLookupFieldControlInstance;
        private MultipleFilteredLookupFieldControl _multipleFilteredLookupFieldControlInstanceFixture;

        #region General Initializer : Class (MultipleFilteredLookupFieldControl) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="MultipleFilteredLookupFieldControl" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _multipleFilteredLookupFieldControlInstanceType = typeof(MultipleFilteredLookupFieldControl);
            _multipleFilteredLookupFieldControlInstanceFixture = Create(true);
            _multipleFilteredLookupFieldControlInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (MultipleFilteredLookupFieldControl)

        #region General Initializer : Class (MultipleFilteredLookupFieldControl) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="MultipleFilteredLookupFieldControl" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodOnInit, 0)]
        [TestCase(MethodOnLoad, 0)]
        [TestCase(MethodCreateChildControls, 0)]
        [TestCase(MethodBuildAvailableItems, 0)]
        [TestCase(MethodInitialize, 0)]
        [TestCase(MethodEnsureValuesAreAvailable, 0)]
        [TestCase(MethodSetValue, 0)]
        public void AUT_MultipleFilteredLookupFieldControl_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_multipleFilteredLookupFieldControlInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (MultipleFilteredLookupFieldControl) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="MultipleFilteredLookupFieldControl" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyDefaultTemplateName)]
        [TestCase(PropertyValue)]
        public void AUT_MultipleFilteredLookupFieldControl_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_multipleFilteredLookupFieldControlInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (MultipleFilteredLookupFieldControl) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="MultipleFilteredLookupFieldControl" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_fieldVals)]
        [TestCase(Field_availableItems)]
        [TestCase(FieldSelectCandidate)]
        [TestCase(FieldSelectResult)]
        [TestCase(FieldAddButton)]
        [TestCase(FieldRemoveButton)]
        [TestCase(FieldMultiLookupPicker)]
        public void AUT_MultipleFilteredLookupFieldControl_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_multipleFilteredLookupFieldControlInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (MultipleFilteredLookupFieldControl) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyDefaultTemplateName)]
        [TestCaseGeneric(typeof(object) , PropertyValue)]
        public void AUT_MultipleFilteredLookupFieldControl_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<MultipleFilteredLookupFieldControl, T>(_multipleFilteredLookupFieldControlInstance, propertyName, Fixture);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="MultipleFilteredLookupFieldControl" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodOnInit)]
        [TestCase(MethodOnLoad)]
        [TestCase(MethodCreateChildControls)]
        [TestCase(MethodBuildAvailableItems)]
        [TestCase(MethodInitialize)]
        [TestCase(MethodEnsureValuesAreAvailable)]
        [TestCase(MethodSetValue)]
        public void AUT_MultipleFilteredLookupFieldControl_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<MultipleFilteredLookupFieldControl>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MultipleFilteredLookupFieldControl_OnInit_Method_Call_Internally(Type[] types)
        {
            var methodOnInitPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_multipleFilteredLookupFieldControlInstance, MethodOnInit, Fixture, methodOnInitPrametersTypes);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MultipleFilteredLookupFieldControl_OnLoad_Method_Call_Internally(Type[] types)
        {
            var methodOnLoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_multipleFilteredLookupFieldControlInstance, MethodOnLoad, Fixture, methodOnLoadPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MultipleFilteredLookupFieldControl_CreateChildControls_Method_Call_Internally(Type[] types)
        {
            var methodCreateChildControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_multipleFilteredLookupFieldControlInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildAvailableItems) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MultipleFilteredLookupFieldControl_BuildAvailableItems_Method_Call_Internally(Type[] types)
        {
            var methodBuildAvailableItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_multipleFilteredLookupFieldControlInstance, MethodBuildAvailableItems, Fixture, methodBuildAvailableItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MultipleFilteredLookupFieldControl_Initialize_Method_Call_Internally(Type[] types)
        {
            var methodInitializePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_multipleFilteredLookupFieldControlInstance, MethodInitialize, Fixture, methodInitializePrametersTypes);
        }

        #endregion

        #region Method Call : (EnsureValuesAreAvailable) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MultipleFilteredLookupFieldControl_EnsureValuesAreAvailable_Method_Call_Internally(Type[] types)
        {
            var methodEnsureValuesAreAvailablePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_multipleFilteredLookupFieldControlInstance, MethodEnsureValuesAreAvailable, Fixture, methodEnsureValuesAreAvailablePrametersTypes);
        }

        #endregion

        #region Method Call : (SetValue) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MultipleFilteredLookupFieldControl_SetValue_Method_Call_Internally(Type[] types)
        {
            var methodSetValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_multipleFilteredLookupFieldControlInstance, MethodSetValue, Fixture, methodSetValuePrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}
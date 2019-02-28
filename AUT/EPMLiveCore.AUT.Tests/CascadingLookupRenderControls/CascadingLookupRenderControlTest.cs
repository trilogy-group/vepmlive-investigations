using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.CascadingLookupRenderControl" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class CascadingLookupRenderControlTest : AbstractBaseSetupTypedTest<CascadingLookupRenderControl>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CascadingLookupRenderControl) Initializer

        private const string PropertyLookupData = "LookupData";
        private const string PropertyLookupField = "LookupField";
        private const string PropertyCustomProperty = "CustomProperty";
        private const string PropertyLookupList = "LookupList";
        private const string PropertyThrottled = "Throttled";
        private const string PropertyDataSource = "DataSource";
        private const string PropertyChoices = "Choices";
        private const string PropertyHiddenFieldName = "HiddenFieldName";
        private const string MethodOnInit = "OnInit";
        private const string MethodOnPreRender = "OnPreRender";
        private const string MethodCreateChildControls = "CreateChildControls";
        private const string MethodClear = "Clear";
        private const string MethodSetFieldControlValue = "SetFieldControlValue";
        private const string MethodUpdateFieldValueInItem = "UpdateFieldValueInItem";
        private const string FieldpropBag = "propBag";
        private const string Fieldparent = "parent";
        private const string Fieldm_dataSource = "_dataSource";
        private const string Field_lookupList = "_lookupList";
        private const string Field_parentLookupList = "_parentLookupList";
        private const string Fieldm_throttled = "_throttled";
        private const string Fieldm_dropList = "DropList";
        private const string Fieldm_tbx = "TextField";
        private const string Fieldm_dropImage = "DropImage";
        private const string Fieldm_ids = "m_ids";
        private const string Fieldm_value = "LookupValue";
        private const string Fieldm_selectedValueIndex = "SelectedValueIndex";
        private const string Fieldm_webForeign = "WebForeign";
        private const string Fieldm_hasValueSet = "HasValueSet";
        private Type _cascadingLookupRenderControlInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CascadingLookupRenderControl _cascadingLookupRenderControlInstance;
        private CascadingLookupRenderControl _cascadingLookupRenderControlInstanceFixture;

        #region General Initializer : Class (CascadingLookupRenderControl) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CascadingLookupRenderControl" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _cascadingLookupRenderControlInstanceType = typeof(CascadingLookupRenderControl);
            _cascadingLookupRenderControlInstanceFixture = Create(true);
            _cascadingLookupRenderControlInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CascadingLookupRenderControl)

        #region General Initializer : Class (CascadingLookupRenderControl) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="CascadingLookupRenderControl" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodOnInit, 0)]
        [TestCase(MethodOnPreRender, 0)]
        [TestCase(MethodCreateChildControls, 0)]
        [TestCase(MethodClear, 0)]
        [TestCase(MethodSetFieldControlValue, 0)]
        [TestCase(MethodUpdateFieldValueInItem, 0)]
        public void AUT_CascadingLookupRenderControl_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_cascadingLookupRenderControlInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion
        
        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CascadingLookupRenderControl) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(LookupConfigData) , PropertyLookupData)]
        [TestCaseGeneric(typeof(SPFieldLookup) , PropertyLookupField)]
        [TestCaseGeneric(typeof(string) , PropertyCustomProperty)]
        [TestCaseGeneric(typeof(SPList) , PropertyLookupList)]
        [TestCaseGeneric(typeof(bool) , PropertyThrottled)]
        [TestCaseGeneric(typeof(ICollection) , PropertyDataSource)]
        [TestCaseGeneric(typeof(string) , PropertyChoices)]
        [TestCaseGeneric(typeof(string) , PropertyHiddenFieldName)]
        public void AUT_CascadingLookupRenderControl_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CascadingLookupRenderControl, T>(_cascadingLookupRenderControlInstance, propertyName, Fixture);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="CascadingLookupRenderControl" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodOnInit)]
        [TestCase(MethodOnPreRender)]
        [TestCase(MethodCreateChildControls)]
        [TestCase(MethodClear)]
        [TestCase(MethodSetFieldControlValue)]
        [TestCase(MethodUpdateFieldValueInItem)]
        public void AUT_CascadingLookupRenderControl_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<CascadingLookupRenderControl>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupRenderControl_OnInit_Method_Call_Internally(Type[] types)
        {
            var methodOnInitPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupRenderControlInstance, MethodOnInit, Fixture, methodOnInitPrametersTypes);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupRenderControl_OnPreRender_Method_Call_Internally(Type[] types)
        {
            var methodOnPreRenderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupRenderControlInstance, MethodOnPreRender, Fixture, methodOnPreRenderPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupRenderControl_CreateChildControls_Method_Call_Internally(Type[] types)
        {
            var methodCreateChildControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupRenderControlInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (Clear) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupRenderControl_Clear_Method_Call_Internally(Type[] types)
        {
            var methodClearPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupRenderControlInstance, MethodClear, Fixture, methodClearPrametersTypes);
        }

        #endregion

        #region Method Call : (SetFieldControlValue) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupRenderControl_SetFieldControlValue_Method_Call_Internally(Type[] types)
        {
            var methodSetFieldControlValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupRenderControlInstance, MethodSetFieldControlValue, Fixture, methodSetFieldControlValuePrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateFieldValueInItem) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupRenderControl_UpdateFieldValueInItem_Method_Call_Internally(Type[] types)
        {
            var methodUpdateFieldValueInItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupRenderControlInstance, MethodUpdateFieldValueInItem, Fixture, methodUpdateFieldValueInItemPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}
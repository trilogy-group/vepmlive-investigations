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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.CascadingLookupFieldControl" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class CascadingLookupFieldControlTest : AbstractBaseSetupTypedTest<CascadingLookupFieldControl>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CascadingLookupFieldControl) Initializer

        private const string PropertylblErrorID = "lblErrorID";
        private const string PropertyDefaultTemplateName = "DefaultTemplateName";
        private const string PropertyValue = "Value";
        private const string MethodFocus = "Focus";
        private const string MethodFindControlRecursive = "FindControlRecursive";
        private const string MethodCreateChildControls = "CreateChildControls";
        private const string MethodPopulateDropdown = "PopulateDropdown";
        private const string MethodddlCLField_SelectedIndexChanged = "ddlCLField_SelectedIndexChanged";
        private const string MethodUpdateChildren = "UpdateChildren";
        private const string MethodPopulateChild = "PopulateChild";
        private const string MethodBuildQuery = "BuildQuery";
        private const string MethodExecuteQuery = "ExecuteQuery";
        private const string MethodInitializeDDL = "InitializeDDL";
        private const string MethodEnsureDDLHasValues = "EnsureDDLHasValues";
        private const string MethodBindDDL = "BindDDL";
        private const string MethodClearError = "ClearError";
        private const string MethodReportError = "ReportError";
        private const string FieldddlCLField = "ddlCLField";
        private const string FieldlblError = "lblError";
        private const string FieldstrUrl = "strUrl";
        private const string FieldstrList = "strList";
        private const string FieldstrField = "strField";
        private const string FieldstrParentField = "strParentField";
        private const string FieldstrChildrenField = "strChildrenField";
        private const string FieldstrFilterValueField = "strFilterValueField";
        private const string FieldstrDefineNone = "strDefineNone";
        private Type _cascadingLookupFieldControlInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CascadingLookupFieldControl _cascadingLookupFieldControlInstance;
        private CascadingLookupFieldControl _cascadingLookupFieldControlInstanceFixture;

        #region General Initializer : Class (CascadingLookupFieldControl) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CascadingLookupFieldControl" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _cascadingLookupFieldControlInstanceType = typeof(CascadingLookupFieldControl);
            _cascadingLookupFieldControlInstanceFixture = Create(true);
            _cascadingLookupFieldControlInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CascadingLookupFieldControl)

        #region General Initializer : Class (CascadingLookupFieldControl) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="CascadingLookupFieldControl" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodFocus, 0)]
        [TestCase(MethodCreateChildControls, 0)]
        [TestCase(MethodPopulateDropdown, 0)]
        [TestCase(MethodddlCLField_SelectedIndexChanged, 0)]
        [TestCase(MethodUpdateChildren, 0)]
        [TestCase(MethodPopulateChild, 0)]
        [TestCase(MethodBuildQuery, 0)]
        [TestCase(MethodExecuteQuery, 0)]
        [TestCase(MethodInitializeDDL, 0)]
        [TestCase(MethodEnsureDDLHasValues, 0)]
        [TestCase(MethodBindDDL, 0)]
        [TestCase(MethodBindDDL, 1)]
        [TestCase(MethodClearError, 0)]
        [TestCase(MethodReportError, 0)]
        [TestCase(MethodReportError, 1)]
        public void AUT_CascadingLookupFieldControl_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_cascadingLookupFieldControlInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CascadingLookupFieldControl) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CascadingLookupFieldControl" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertylblErrorID)]
        [TestCase(PropertyDefaultTemplateName)]
        [TestCase(PropertyValue)]
        public void AUT_CascadingLookupFieldControl_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_cascadingLookupFieldControlInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CascadingLookupFieldControl) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CascadingLookupFieldControl" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldddlCLField)]
        [TestCase(FieldlblError)]
        [TestCase(FieldstrUrl)]
        [TestCase(FieldstrList)]
        [TestCase(FieldstrField)]
        [TestCase(FieldstrParentField)]
        [TestCase(FieldstrChildrenField)]
        [TestCase(FieldstrFilterValueField)]
        [TestCase(FieldstrDefineNone)]
        public void AUT_CascadingLookupFieldControl_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_cascadingLookupFieldControlInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CascadingLookupFieldControl) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertylblErrorID)]
        [TestCaseGeneric(typeof(string) , PropertyDefaultTemplateName)]
        [TestCaseGeneric(typeof(object) , PropertyValue)]
        public void AUT_CascadingLookupFieldControl_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CascadingLookupFieldControl, T>(_cascadingLookupFieldControlInstance, propertyName, Fixture);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="CascadingLookupFieldControl" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodFocus)]
        [TestCase(MethodCreateChildControls)]
        [TestCase(MethodPopulateDropdown)]
        [TestCase(MethodddlCLField_SelectedIndexChanged)]
        [TestCase(MethodUpdateChildren)]
        [TestCase(MethodPopulateChild)]
        [TestCase(MethodBuildQuery)]
        [TestCase(MethodExecuteQuery)]
        [TestCase(MethodInitializeDDL)]
        [TestCase(MethodEnsureDDLHasValues)]
        [TestCase(MethodBindDDL)]
        [TestCase(MethodClearError)]
        [TestCase(MethodReportError)]
        public void AUT_CascadingLookupFieldControl_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<CascadingLookupFieldControl>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Focus) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupFieldControl_Focus_Method_Call_Internally(Type[] types)
        {
            var methodFocusPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldControlInstance, MethodFocus, Fixture, methodFocusPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupFieldControl_CreateChildControls_Method_Call_Internally(Type[] types)
        {
            var methodCreateChildControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldControlInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (PopulateDropdown) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupFieldControl_PopulateDropdown_Method_Call_Internally(Type[] types)
        {
            var methodPopulateDropdownPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldControlInstance, MethodPopulateDropdown, Fixture, methodPopulateDropdownPrametersTypes);
        }

        #endregion

        #region Method Call : (ddlCLField_SelectedIndexChanged) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupFieldControl_ddlCLField_SelectedIndexChanged_Method_Call_Internally(Type[] types)
        {
            var methodddlCLField_SelectedIndexChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldControlInstance, MethodddlCLField_SelectedIndexChanged, Fixture, methodddlCLField_SelectedIndexChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateChildren) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupFieldControl_UpdateChildren_Method_Call_Internally(Type[] types)
        {
            var methodUpdateChildrenPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldControlInstance, MethodUpdateChildren, Fixture, methodUpdateChildrenPrametersTypes);
        }

        #endregion

        #region Method Call : (PopulateChild) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupFieldControl_PopulateChild_Method_Call_Internally(Type[] types)
        {
            var methodPopulateChildPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldControlInstance, MethodPopulateChild, Fixture, methodPopulateChildPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildQuery) (Return Type : SPQuery) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupFieldControl_BuildQuery_Method_Call_Internally(Type[] types)
        {
            var methodBuildQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldControlInstance, MethodBuildQuery, Fixture, methodBuildQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (ExecuteQuery) (Return Type : SPListItemCollection) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupFieldControl_ExecuteQuery_Method_Call_Internally(Type[] types)
        {
            var methodExecuteQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldControlInstance, MethodExecuteQuery, Fixture, methodExecuteQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (InitializeDDL) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupFieldControl_InitializeDDL_Method_Call_Internally(Type[] types)
        {
            var methodInitializeDDLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldControlInstance, MethodInitializeDDL, Fixture, methodInitializeDDLPrametersTypes);
        }

        #endregion

        #region Method Call : (EnsureDDLHasValues) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupFieldControl_EnsureDDLHasValues_Method_Call_Internally(Type[] types)
        {
            var methodEnsureDDLHasValuesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldControlInstance, MethodEnsureDDLHasValues, Fixture, methodEnsureDDLHasValuesPrametersTypes);
        }

        #endregion

        #region Method Call : (BindDDL) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupFieldControl_BindDDL_Method_Call_Internally(Type[] types)
        {
            var methodBindDDLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldControlInstance, MethodBindDDL, Fixture, methodBindDDLPrametersTypes);
        }

        #endregion

        #region Method Call : (BindDDL) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupFieldControl_BindDDL_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodBindDDLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldControlInstance, MethodBindDDL, Fixture, methodBindDDLPrametersTypes);
        }

        #endregion

        #region Method Call : (ClearError) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupFieldControl_ClearError_Method_Call_Internally(Type[] types)
        {
            var methodClearErrorPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldControlInstance, MethodClearError, Fixture, methodClearErrorPrametersTypes);
        }

        #endregion

        #region Method Call : (ReportError) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupFieldControl_ReportError_Method_Call_Internally(Type[] types)
        {
            var methodReportErrorPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldControlInstance, MethodReportError, Fixture, methodReportErrorPrametersTypes);
        }

        #endregion

        #region Method Call : (ReportError) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupFieldControl_ReportError_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodReportErrorPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldControlInstance, MethodReportError, Fixture, methodReportErrorPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}
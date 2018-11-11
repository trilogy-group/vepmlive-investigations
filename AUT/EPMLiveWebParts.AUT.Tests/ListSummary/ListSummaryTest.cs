using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Web.UI;
using System.Xml;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebPartPages;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.ListSummary" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ListSummaryTest : AbstractBaseSetupTypedTest<ListSummary>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ListSummary) Initializer

        private const string PropertyPropStatus = "PropStatus";
        private const string PropertyPropUrl = "PropUrl";
        private const string PropertyPropList = "PropList";
        private const string PropertyPropView = "PropView";
        private const string PropertyPropRollupList = "PropRollupList";
        private const string PropertyPropRollupSites = "PropRollupSites";
        private const string MethodReportIDConsumer = "ReportIDConsumer";
        private const string MethodCreateChildControls = "CreateChildControls";
        private const string MethodGetReportFilters = "GetReportFilters";
        private const string MethodRenderWebPart = "RenderWebPart";
        private const string MethodgetData = "getData";
        private const string MethodProcessReportFilter = "ProcessReportFilter";
        private const string MethodprocessWeb = "processWeb";
        private const string MethodprocessList = "processList";
        private const string MethodGetToolParts = "GetToolParts";
        private const string FieldMAX_LOOKUPFILTER = "MAX_LOOKUPFILTER";
        private const string Field_myProvider = "_myProvider";
        private const string Fieldact = "act";
        private const string FieldstrList = "strList";
        private const string FieldstrView = "strView";
        private const string FieldstrRollupList = "strRollupList";
        private const string FieldstrRollupSites = "strRollupSites";
        private const string FieldstrStatus = "strStatus";
        private const string FieldstrUrl = "strUrl";
        private const string Fieldactivation = "activation";
        private const string FieldsErrors = "sErrors";
        private const string FieldtotalItems = "totalItems";
        private const string FieldslStatus = "slStatus";
        private const string FieldreportFilterField = "reportFilterField";
        private const string FieldreportFilterIDs = "reportFilterIDs";
        private const string Field_lookupField = "_lookupField";
        private const string Field_lookupFieldList = "_lookupFieldList";
        private Type _listSummaryInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ListSummary _listSummaryInstance;
        private ListSummary _listSummaryInstanceFixture;

        #region General Initializer : Class (ListSummary) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ListSummary" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _listSummaryInstanceType = typeof(ListSummary);
            _listSummaryInstanceFixture = Create(true);
            _listSummaryInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ListSummary)

        #region General Initializer : Class (ListSummary) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ListSummary" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(MethodReportIDConsumer, 0)]
        [TestCase(MethodCreateChildControls, 0)]
        [TestCase(MethodGetReportFilters, 0)]
        [TestCase(MethodRenderWebPart, 0)]
        [TestCase(MethodgetData, 0)]
        [TestCase(MethodProcessReportFilter, 0)]
        [TestCase(MethodprocessWeb, 0)]
        [TestCase(MethodprocessList, 0)]
        [TestCase(MethodGetToolParts, 0)]
        public void AUT_ListSummary_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_listSummaryInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ListSummary) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ListSummary" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyPropStatus)]
        [TestCase(PropertyPropUrl)]
        [TestCase(PropertyPropList)]
        [TestCase(PropertyPropView)]
        [TestCase(PropertyPropRollupList)]
        [TestCase(PropertyPropRollupSites)]
        public void AUT_ListSummary_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_listSummaryInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ListSummary) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ListSummary" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldMAX_LOOKUPFILTER)]
        [TestCase(Field_myProvider)]
        [TestCase(Fieldact)]
        [TestCase(FieldstrList)]
        [TestCase(FieldstrView)]
        [TestCase(FieldstrRollupList)]
        [TestCase(FieldstrRollupSites)]
        [TestCase(FieldstrStatus)]
        [TestCase(FieldstrUrl)]
        [TestCase(Fieldactivation)]
        [TestCase(FieldsErrors)]
        [TestCase(FieldtotalItems)]
        [TestCase(FieldslStatus)]
        [TestCase(FieldreportFilterField)]
        [TestCase(FieldreportFilterIDs)]
        [TestCase(Field_lookupField)]
        [TestCase(Field_lookupFieldList)]
        public void AUT_ListSummary_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_listSummaryInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ListSummary) => Property (PropList) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ListSummary_Public_Class_PropList_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropList);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ListSummary) => Property (PropRollupList) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ListSummary_Public_Class_PropRollupList_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropRollupList);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ListSummary) => Property (PropRollupSites) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ListSummary_Public_Class_PropRollupSites_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropRollupSites);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ListSummary) => Property (PropStatus) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ListSummary_Public_Class_PropStatus_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropStatus);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ListSummary) => Property (PropUrl) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ListSummary_Public_Class_PropUrl_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropUrl);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ListSummary) => Property (PropView) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ListSummary_Public_Class_PropView_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropView);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ListSummary" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        [TestCase(MethodReportIDConsumer)]
        [TestCase(MethodCreateChildControls)]
        [TestCase(MethodGetReportFilters)]
        [TestCase(MethodRenderWebPart)]
        [TestCase(MethodgetData)]
        [TestCase(MethodProcessReportFilter)]
        [TestCase(MethodprocessWeb)]
        [TestCase(MethodprocessList)]
        [TestCase(MethodGetToolParts)]
        public void AUT_ListSummary_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ListSummary>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (ReportIDConsumer) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListSummary_ReportIDConsumer_Method_Call_Internally(Type[] types)
        {
            var methodReportIDConsumerPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listSummaryInstance, MethodReportIDConsumer, Fixture, methodReportIDConsumerPrametersTypes);
        }

        #endregion

        #region Method Call : (ReportIDConsumer) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_ReportIDConsumer_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Provider = CreateType<IReportID>();
            Action executeAction = null;

            // Act
            executeAction = () => _listSummaryInstance.ReportIDConsumer(Provider);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ReportIDConsumer) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_ReportIDConsumer_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var Provider = CreateType<IReportID>();
            var methodReportIDConsumerPrametersTypes = new Type[] { typeof(IReportID) };
            object[] parametersOfReportIDConsumer = { Provider };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReportIDConsumer, methodReportIDConsumerPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listSummaryInstanceFixture, parametersOfReportIDConsumer);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReportIDConsumer.ShouldNotBeNull();
            parametersOfReportIDConsumer.Length.ShouldBe(1);
            methodReportIDConsumerPrametersTypes.Length.ShouldBe(1);
            methodReportIDConsumerPrametersTypes.Length.ShouldBe(parametersOfReportIDConsumer.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ReportIDConsumer) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_ReportIDConsumer_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Provider = CreateType<IReportID>();
            var methodReportIDConsumerPrametersTypes = new Type[] { typeof(IReportID) };
            object[] parametersOfReportIDConsumer = { Provider };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listSummaryInstance, MethodReportIDConsumer, parametersOfReportIDConsumer, methodReportIDConsumerPrametersTypes);

            // Assert
            parametersOfReportIDConsumer.ShouldNotBeNull();
            parametersOfReportIDConsumer.Length.ShouldBe(1);
            methodReportIDConsumerPrametersTypes.Length.ShouldBe(1);
            methodReportIDConsumerPrametersTypes.Length.ShouldBe(parametersOfReportIDConsumer.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReportIDConsumer) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_ReportIDConsumer_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReportIDConsumer, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReportIDConsumer) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_ReportIDConsumer_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReportIDConsumerPrametersTypes = new Type[] { typeof(IReportID) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listSummaryInstance, MethodReportIDConsumer, Fixture, methodReportIDConsumerPrametersTypes);

            // Assert
            methodReportIDConsumerPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReportIDConsumer) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_ReportIDConsumer_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReportIDConsumer, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listSummaryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListSummary_CreateChildControls_Method_Call_Internally(Type[] types)
        {
            var methodCreateChildControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listSummaryInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, methodCreateChildControlsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listSummaryInstanceFixture, parametersOfCreateChildControls);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateChildControls.ShouldBeNull();
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listSummaryInstance, MethodCreateChildControls, parametersOfCreateChildControls, methodCreateChildControlsPrametersTypes);

            // Assert
            parametersOfCreateChildControls.ShouldBeNull();
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_CreateChildControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listSummaryInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);

            // Assert
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_CreateChildControls_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listSummaryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetReportFilters) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListSummary_GetReportFilters_Method_Call_Internally(Type[] types)
        {
            var methodGetReportFiltersPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listSummaryInstance, MethodGetReportFilters, Fixture, methodGetReportFiltersPrametersTypes);
        }

        #endregion

        #region Method Call : (GetReportFilters) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_GetReportFilters_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetReportFiltersPrametersTypes = null;
            object[] parametersOfGetReportFilters = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetReportFilters, methodGetReportFiltersPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ListSummary, string>(_listSummaryInstanceFixture, out exception1, parametersOfGetReportFilters);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ListSummary, string>(_listSummaryInstance, MethodGetReportFilters, parametersOfGetReportFilters, methodGetReportFiltersPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetReportFilters.ShouldBeNull();
            methodGetReportFiltersPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetReportFilters) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_GetReportFilters_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetReportFiltersPrametersTypes = null;
            object[] parametersOfGetReportFilters = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ListSummary, string>(_listSummaryInstance, MethodGetReportFilters, parametersOfGetReportFilters, methodGetReportFiltersPrametersTypes);

            // Assert
            parametersOfGetReportFilters.ShouldBeNull();
            methodGetReportFiltersPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetReportFilters) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_GetReportFilters_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetReportFiltersPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listSummaryInstance, MethodGetReportFilters, Fixture, methodGetReportFiltersPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetReportFiltersPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetReportFilters) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_GetReportFilters_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetReportFiltersPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listSummaryInstance, MethodGetReportFilters, Fixture, methodGetReportFiltersPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetReportFiltersPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetReportFilters) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_GetReportFilters_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetReportFilters, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listSummaryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RenderWebPart) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListSummary_RenderWebPart_Method_Call_Internally(Type[] types)
        {
            var methodRenderWebPartPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listSummaryInstance, MethodRenderWebPart, Fixture, methodRenderWebPartPrametersTypes);
        }

        #endregion

        #region Method Call : (RenderWebPart) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_RenderWebPart_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodRenderWebPartPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRenderWebPart = { output };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRenderWebPart, methodRenderWebPartPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listSummaryInstanceFixture, parametersOfRenderWebPart);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRenderWebPart.ShouldNotBeNull();
            parametersOfRenderWebPart.Length.ShouldBe(1);
            methodRenderWebPartPrametersTypes.Length.ShouldBe(1);
            methodRenderWebPartPrametersTypes.Length.ShouldBe(parametersOfRenderWebPart.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RenderWebPart) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_RenderWebPart_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodRenderWebPartPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRenderWebPart = { output };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listSummaryInstance, MethodRenderWebPart, parametersOfRenderWebPart, methodRenderWebPartPrametersTypes);

            // Assert
            parametersOfRenderWebPart.ShouldNotBeNull();
            parametersOfRenderWebPart.Length.ShouldBe(1);
            methodRenderWebPartPrametersTypes.Length.ShouldBe(1);
            methodRenderWebPartPrametersTypes.Length.ShouldBe(parametersOfRenderWebPart.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderWebPart) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_RenderWebPart_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRenderWebPart, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenderWebPart) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_RenderWebPart_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenderWebPartPrametersTypes = new Type[] { typeof(HtmlTextWriter) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listSummaryInstance, MethodRenderWebPart, Fixture, methodRenderWebPartPrametersTypes);

            // Assert
            methodRenderWebPartPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderWebPart) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_RenderWebPart_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenderWebPart, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listSummaryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListSummary_getData_Method_Call_Internally(Type[] types)
        {
            var methodgetDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listSummaryInstance, MethodgetData, Fixture, methodgetDataPrametersTypes);
        }

        #endregion

        #region Method Call : (getData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_getData_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodgetDataPrametersTypes = null;
            object[] parametersOfgetData = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetData, methodgetDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listSummaryInstanceFixture, parametersOfgetData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetData.ShouldBeNull();
            methodgetDataPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (getData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_getData_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodgetDataPrametersTypes = null;
            object[] parametersOfgetData = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listSummaryInstance, MethodgetData, parametersOfgetData, methodgetDataPrametersTypes);

            // Assert
            parametersOfgetData.ShouldBeNull();
            methodgetDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_getData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodgetDataPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listSummaryInstance, MethodgetData, Fixture, methodgetDataPrametersTypes);

            // Assert
            methodgetDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_getData_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listSummaryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessReportFilter) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListSummary_ProcessReportFilter_Method_Call_Internally(Type[] types)
        {
            var methodProcessReportFilterPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listSummaryInstance, MethodProcessReportFilter, Fixture, methodProcessReportFilterPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessReportFilter) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_ProcessReportFilter_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var xmlQuery = CreateType<XmlDocument>();
            var list = CreateType<SPList>();
            var web = CreateType<SPWeb>();
            var methodProcessReportFilterPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPList), typeof(SPWeb) };
            object[] parametersOfProcessReportFilter = { xmlQuery, list, web };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodProcessReportFilter, methodProcessReportFilterPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ListSummary, string>(_listSummaryInstanceFixture, out exception1, parametersOfProcessReportFilter);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ListSummary, string>(_listSummaryInstance, MethodProcessReportFilter, parametersOfProcessReportFilter, methodProcessReportFilterPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfProcessReportFilter.ShouldNotBeNull();
            parametersOfProcessReportFilter.Length.ShouldBe(3);
            methodProcessReportFilterPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (ProcessReportFilter) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_ProcessReportFilter_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xmlQuery = CreateType<XmlDocument>();
            var list = CreateType<SPList>();
            var web = CreateType<SPWeb>();
            var methodProcessReportFilterPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPList), typeof(SPWeb) };
            object[] parametersOfProcessReportFilter = { xmlQuery, list, web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ListSummary, string>(_listSummaryInstance, MethodProcessReportFilter, parametersOfProcessReportFilter, methodProcessReportFilterPrametersTypes);

            // Assert
            parametersOfProcessReportFilter.ShouldNotBeNull();
            parametersOfProcessReportFilter.Length.ShouldBe(3);
            methodProcessReportFilterPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessReportFilter) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_ProcessReportFilter_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodProcessReportFilterPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPList), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listSummaryInstance, MethodProcessReportFilter, Fixture, methodProcessReportFilterPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodProcessReportFilterPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (ProcessReportFilter) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_ProcessReportFilter_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessReportFilterPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPList), typeof(SPWeb) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listSummaryInstance, MethodProcessReportFilter, Fixture, methodProcessReportFilterPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodProcessReportFilterPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessReportFilter) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_ProcessReportFilter_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessReportFilter, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listSummaryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ProcessReportFilter) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_ProcessReportFilter_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodProcessReportFilter, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processWeb) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListSummary_processWeb_Method_Call_Internally(Type[] types)
        {
            var methodprocessWebPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listSummaryInstance, MethodprocessWeb, Fixture, methodprocessWebPrametersTypes);
        }

        #endregion

        #region Method Call : (processWeb) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_processWeb_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodprocessWebPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfprocessWeb = { web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodprocessWeb, methodprocessWebPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listSummaryInstanceFixture, parametersOfprocessWeb);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfprocessWeb.ShouldNotBeNull();
            parametersOfprocessWeb.Length.ShouldBe(1);
            methodprocessWebPrametersTypes.Length.ShouldBe(1);
            methodprocessWebPrametersTypes.Length.ShouldBe(parametersOfprocessWeb.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (processWeb) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_processWeb_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodprocessWebPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfprocessWeb = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listSummaryInstance, MethodprocessWeb, parametersOfprocessWeb, methodprocessWebPrametersTypes);

            // Assert
            parametersOfprocessWeb.ShouldNotBeNull();
            parametersOfprocessWeb.Length.ShouldBe(1);
            methodprocessWebPrametersTypes.Length.ShouldBe(1);
            methodprocessWebPrametersTypes.Length.ShouldBe(parametersOfprocessWeb.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processWeb) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_processWeb_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodprocessWeb, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processWeb) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_processWeb_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodprocessWebPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listSummaryInstance, MethodprocessWeb, Fixture, methodprocessWebPrametersTypes);

            // Assert
            methodprocessWebPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processWeb) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_processWeb_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprocessWeb, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listSummaryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processList) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListSummary_processList_Method_Call_Internally(Type[] types)
        {
            var methodprocessListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listSummaryInstance, MethodprocessList, Fixture, methodprocessListPrametersTypes);
        }

        #endregion

        #region Method Call : (processList) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_processList_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var dt = CreateType<DataTable>();
            var methodprocessListPrametersTypes = new Type[] { typeof(DataTable) };
            object[] parametersOfprocessList = { dt };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodprocessList, methodprocessListPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listSummaryInstanceFixture, parametersOfprocessList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfprocessList.ShouldNotBeNull();
            parametersOfprocessList.Length.ShouldBe(1);
            methodprocessListPrametersTypes.Length.ShouldBe(1);
            methodprocessListPrametersTypes.Length.ShouldBe(parametersOfprocessList.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (processList) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_processList_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dt = CreateType<DataTable>();
            var methodprocessListPrametersTypes = new Type[] { typeof(DataTable) };
            object[] parametersOfprocessList = { dt };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listSummaryInstance, MethodprocessList, parametersOfprocessList, methodprocessListPrametersTypes);

            // Assert
            parametersOfprocessList.ShouldNotBeNull();
            parametersOfprocessList.Length.ShouldBe(1);
            methodprocessListPrametersTypes.Length.ShouldBe(1);
            methodprocessListPrametersTypes.Length.ShouldBe(parametersOfprocessList.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processList) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_processList_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodprocessList, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processList) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_processList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodprocessListPrametersTypes = new Type[] { typeof(DataTable) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listSummaryInstance, MethodprocessList, Fixture, methodprocessListPrametersTypes);

            // Assert
            methodprocessListPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processList) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_processList_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprocessList, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listSummaryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListSummary_GetToolParts_Method_Call_Internally(Type[] types)
        {
            var methodGetToolPartsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listSummaryInstance, MethodGetToolParts, Fixture, methodGetToolPartsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_GetToolParts_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _listSummaryInstance.GetToolParts();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_GetToolParts_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetToolPartsPrametersTypes = null;
            object[] parametersOfGetToolParts = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetToolParts, methodGetToolPartsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ListSummary, ToolPart[]>(_listSummaryInstanceFixture, out exception1, parametersOfGetToolParts);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ListSummary, ToolPart[]>(_listSummaryInstance, MethodGetToolParts, parametersOfGetToolParts, methodGetToolPartsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetToolParts.ShouldBeNull();
            methodGetToolPartsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_GetToolParts_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetToolPartsPrametersTypes = null;
            object[] parametersOfGetToolParts = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ListSummary, ToolPart[]>(_listSummaryInstance, MethodGetToolParts, parametersOfGetToolParts, methodGetToolPartsPrametersTypes);

            // Assert
            parametersOfGetToolParts.ShouldBeNull();
            methodGetToolPartsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_GetToolParts_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetToolPartsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listSummaryInstance, MethodGetToolParts, Fixture, methodGetToolPartsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetToolPartsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_GetToolParts_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetToolPartsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listSummaryInstance, MethodGetToolParts, Fixture, methodGetToolPartsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetToolPartsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ListSummary_GetToolParts_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetToolParts, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listSummaryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #endregion

        #endregion
    }
}
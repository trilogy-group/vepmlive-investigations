using System;
using System.Collections;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.getgantttasks" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class GetgantttasksTest : AbstractBaseSetupTypedTest<getgantttasks>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (getgantttasks) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodoutputData = "outputData";
        private const string MethodcreateLinks = "createLinks";
        private const string MethodsetInitialAggs = "setInitialAggs";
        private const string MethodgetParams = "getParams";
        private const string MethodaddBar = "addBar";
        private const string MethodaddHeader = "addHeader";
        private const string MethodprocessListDT = "processListDT";
        private const string MethodprocessList = "processList";
        private const string MethodProcessField = "ProcessField";
        private const string MethodProcessUserField = "ProcessUserField";
        private const string MethodadditionalPerfFields = "additionalPerfFields";
        private const string MethodaddGroups = "addGroups";
        private const string MethodgetField = "getField";
        private const string MethodformatField = "formatField";
        private const string MethodsetMinMax = "setMinMax";
        private const string MethodgetQuery = "getQuery";
        private const string MethodaddItems = "addItems";
        private const string MethodaddItem = "addItem";
        private const string MethodsetAggVal = "setAggVal";
        private const string MethodgetRealField = "getRealField";
        private const string FieldfilterResources = "filterResources";
        private const string FieldcurUser = "curUser";
        private const string Fielddata = "data";
        private const string Fieldlist = "list";
        private const string Fieldview = "view";
        private const string Fieldstrlist = "strlist";
        private const string Fieldstrview = "strview";
        private const string Fieldstart = "start";
        private const string Fieldfinish = "finish";
        private const string Fieldprogress = "progress";
        private const string Fieldwbsfield = "wbsfield";
        private const string Fieldmilestone = "milestone";
        private const string Fieldexecutive = "executive";
        private const string Fieldinformation = "information";
        private const string Fieldlinktype = "linktype";
        private const string Fieldrolluplists = "rolluplists";
        private const string Fieldrollupsites = "rollupsites";
        private const string FieldusePerformance = "usePerformance";
        private const string Fieldadditionalgroups = "additionalgroups";
        private const string FieldglobalError = "globalError";
        private const string FieldusePopup = "usePopup";
        private const string Fieldfilterfield = "filterfield";
        private const string Fieldfiltervalue = "filtervalue";
        private const string Fieldexpanded = "expanded";
        private const string FieldhshItemNodes = "hshItemNodes";
        private const string FieldqueueAllItems = "queueAllItems";
        private const string FieldarrGroupFields = "arrGroupFields";
        private const string FieldarrGroupMin = "arrGroupMin";
        private const string FieldarrGroupMax = "arrGroupMax";
        private const string FieldarrAggregationDef = "arrAggregationDef";
        private const string FieldarrAggregationVals = "arrAggregationVals";
        private const string FieldarrItems = "arrItems";
        private const string FieldarrColumns = "arrColumns";
        private const string FieldhshImages = "hshImages";
        private const string FieldhshWBS = "hshWBS";
        private const string FieldhshWBSSummaryTasks = "hshWBSSummaryTasks";
        private const string FieldoverallMin = "overallMin";
        private const string FieldhshLists = "hshLists";
        private const string FieldndMainParent = "ndMainParent";
        private const string FielddocComplete = "docComplete";
        private const string FieldisResourcePlan = "isResourcePlan";
        private const string FieldstartHour = "startHour";
        private const string FieldendHour = "endHour";
        private const string FieldnonWork = "nonWork";
        private const string Fieldworkdays = "workdays";
        private const string FieldproviderEn = "providerEn";
        private const string FielddtProviderEn = "dtProviderEn";
        private Type _getgantttasksInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private getgantttasks _getgantttasksInstance;
        private getgantttasks _getgantttasksInstanceFixture;

        #region General Initializer : Class (getgantttasks) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="getgantttasks" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _getgantttasksInstanceType = typeof(getgantttasks);
            _getgantttasksInstanceFixture = Create(true);
            _getgantttasksInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (getgantttasks)

        #region General Initializer : Class (getgantttasks) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="getgantttasks" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodoutputData, 0)]
        [TestCase(MethodcreateLinks, 0)]
        [TestCase(MethodsetInitialAggs, 0)]
        [TestCase(MethodgetParams, 0)]
        [TestCase(MethodaddBar, 0)]
        [TestCase(MethodaddHeader, 0)]
        [TestCase(MethodprocessListDT, 0)]
        [TestCase(MethodprocessList, 0)]
        [TestCase(MethodadditionalPerfFields, 0)]
        [TestCase(MethodaddGroups, 0)]
        [TestCase(MethodgetField, 0)]
        [TestCase(MethodgetField, 1)]
        [TestCase(MethodformatField, 0)]
        [TestCase(MethodformatField, 1)]
        [TestCase(MethodsetMinMax, 0)]
        [TestCase(MethodgetQuery, 0)]
        [TestCase(MethodaddItems, 0)]
        [TestCase(MethodaddItem, 0)]
        [TestCase(MethodaddItem, 1)]
        [TestCase(MethodsetAggVal, 0)]
        [TestCase(MethodgetRealField, 0)]
        public void AUT_Getgantttasks_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_getgantttasksInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (getgantttasks) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="getgantttasks" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldfilterResources)]
        [TestCase(FieldcurUser)]
        [TestCase(Fielddata)]
        [TestCase(Fieldlist)]
        [TestCase(Fieldview)]
        [TestCase(Fieldstrlist)]
        [TestCase(Fieldstrview)]
        [TestCase(Fieldstart)]
        [TestCase(Fieldfinish)]
        [TestCase(Fieldprogress)]
        [TestCase(Fieldwbsfield)]
        [TestCase(Fieldmilestone)]
        [TestCase(Fieldexecutive)]
        [TestCase(Fieldinformation)]
        [TestCase(Fieldlinktype)]
        [TestCase(Fieldrolluplists)]
        [TestCase(Fieldrollupsites)]
        [TestCase(FieldusePerformance)]
        [TestCase(Fieldadditionalgroups)]
        [TestCase(FieldglobalError)]
        [TestCase(FieldusePopup)]
        [TestCase(Fieldfilterfield)]
        [TestCase(Fieldfiltervalue)]
        [TestCase(Fieldexpanded)]
        [TestCase(FieldhshItemNodes)]
        [TestCase(FieldqueueAllItems)]
        [TestCase(FieldarrGroupFields)]
        [TestCase(FieldarrGroupMin)]
        [TestCase(FieldarrGroupMax)]
        [TestCase(FieldarrAggregationDef)]
        [TestCase(FieldarrAggregationVals)]
        [TestCase(FieldarrItems)]
        [TestCase(FieldarrColumns)]
        [TestCase(FieldhshImages)]
        [TestCase(FieldhshWBS)]
        [TestCase(FieldhshWBSSummaryTasks)]
        [TestCase(FieldoverallMin)]
        [TestCase(FieldhshLists)]
        [TestCase(FieldndMainParent)]
        [TestCase(FielddocComplete)]
        [TestCase(FieldisResourcePlan)]
        [TestCase(FieldstartHour)]
        [TestCase(FieldendHour)]
        [TestCase(FieldnonWork)]
        [TestCase(Fieldworkdays)]
        [TestCase(FieldproviderEn)]
        [TestCase(FielddtProviderEn)]
        public void AUT_Getgantttasks_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_getgantttasksInstanceFixture, 
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
        ///     Class (<see cref="getgantttasks" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Getgantttasks_Is_Instance_Present_Test()
        {
            // Assert
            _getgantttasksInstanceType.ShouldNotBeNull();
            _getgantttasksInstance.ShouldNotBeNull();
            _getgantttasksInstanceFixture.ShouldNotBeNull();
            _getgantttasksInstance.ShouldBeAssignableTo<getgantttasks>();
            _getgantttasksInstanceFixture.ShouldBeAssignableTo<getgantttasks>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (getgantttasks) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_getgantttasks_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            getgantttasks instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _getgantttasksInstanceType.ShouldNotBeNull();
            _getgantttasksInstance.ShouldNotBeNull();
            _getgantttasksInstanceFixture.ShouldNotBeNull();
            _getgantttasksInstance.ShouldBeAssignableTo<getgantttasks>();
            _getgantttasksInstanceFixture.ShouldBeAssignableTo<getgantttasks>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="getgantttasks" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodoutputData)]
        [TestCase(MethodcreateLinks)]
        [TestCase(MethodsetInitialAggs)]
        [TestCase(MethodgetParams)]
        [TestCase(MethodaddBar)]
        [TestCase(MethodaddHeader)]
        [TestCase(MethodprocessListDT)]
        [TestCase(MethodprocessList)]
        [TestCase(MethodadditionalPerfFields)]
        [TestCase(MethodaddGroups)]
        [TestCase(MethodgetField)]
        [TestCase(MethodformatField)]
        [TestCase(MethodsetMinMax)]
        [TestCase(MethodgetQuery)]
        [TestCase(MethodaddItems)]
        [TestCase(MethodaddItem)]
        [TestCase(MethodsetAggVal)]
        [TestCase(MethodgetRealField)]
        public void AUT_Getgantttasks_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<getgantttasks>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgantttasks_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getgantttasksInstanceFixture, parametersOfPage_Load);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPage_Load.ShouldNotBeNull();
            parametersOfPage_Load.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(parametersOfPage_Load.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getgantttasksInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

            // Assert
            parametersOfPage_Load.ShouldNotBeNull();
            parametersOfPage_Load.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(parametersOfPage_Load.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_Page_Load_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getgantttasksInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (outputData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgantttasks_outputData_Method_Call_Internally(Type[] types)
        {
            var methodoutputDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodoutputData, Fixture, methodoutputDataPrametersTypes);
        }

        #endregion

        #region Method Call : (outputData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_outputData_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodoutputDataPrametersTypes = null;
            object[] parametersOfoutputData = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodoutputData, methodoutputDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getgantttasksInstanceFixture, parametersOfoutputData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfoutputData.ShouldBeNull();
            methodoutputDataPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (outputData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_outputData_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodoutputDataPrametersTypes = null;
            object[] parametersOfoutputData = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getgantttasksInstance, MethodoutputData, parametersOfoutputData, methodoutputDataPrametersTypes);

            // Assert
            parametersOfoutputData.ShouldBeNull();
            methodoutputDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (outputData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_outputData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodoutputDataPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodoutputData, Fixture, methodoutputDataPrametersTypes);

            // Assert
            methodoutputDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (outputData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_outputData_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodoutputData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getgantttasksInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (createLinks) (Return Type : XmlDocument) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgantttasks_createLinks_Method_Call_Internally(Type[] types)
        {
            var methodcreateLinksPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodcreateLinks, Fixture, methodcreateLinksPrametersTypes);
        }

        #endregion

        #region Method Call : (createLinks) (Return Type : XmlDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_createLinks_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var doc = CreateType<XmlDocument>();
            var ndLinks = CreateType<XmlNode>();
            var methodcreateLinksPrametersTypes = new Type[] { typeof(XmlDocument), typeof(XmlNode) };
            object[] parametersOfcreateLinks = { doc, ndLinks };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodcreateLinks, methodcreateLinksPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<getgantttasks, XmlDocument>(_getgantttasksInstanceFixture, out exception1, parametersOfcreateLinks);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<getgantttasks, XmlDocument>(_getgantttasksInstance, MethodcreateLinks, parametersOfcreateLinks, methodcreateLinksPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfcreateLinks.ShouldNotBeNull();
            parametersOfcreateLinks.Length.ShouldBe(2);
            methodcreateLinksPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (createLinks) (Return Type : XmlDocument) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_createLinks_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var doc = CreateType<XmlDocument>();
            var ndLinks = CreateType<XmlNode>();
            var methodcreateLinksPrametersTypes = new Type[] { typeof(XmlDocument), typeof(XmlNode) };
            object[] parametersOfcreateLinks = { doc, ndLinks };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getgantttasks, XmlDocument>(_getgantttasksInstance, MethodcreateLinks, parametersOfcreateLinks, methodcreateLinksPrametersTypes);

            // Assert
            parametersOfcreateLinks.ShouldNotBeNull();
            parametersOfcreateLinks.Length.ShouldBe(2);
            methodcreateLinksPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (createLinks) (Return Type : XmlDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_createLinks_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodcreateLinksPrametersTypes = new Type[] { typeof(XmlDocument), typeof(XmlNode) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodcreateLinks, Fixture, methodcreateLinksPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodcreateLinksPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (createLinks) (Return Type : XmlDocument) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_createLinks_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodcreateLinksPrametersTypes = new Type[] { typeof(XmlDocument), typeof(XmlNode) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodcreateLinks, Fixture, methodcreateLinksPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodcreateLinksPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (createLinks) (Return Type : XmlDocument) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_createLinks_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodcreateLinks, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getgantttasksInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (createLinks) (Return Type : XmlDocument) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_createLinks_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodcreateLinks, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setInitialAggs) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgantttasks_setInitialAggs_Method_Call_Internally(Type[] types)
        {
            var methodsetInitialAggsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodsetInitialAggs, Fixture, methodsetInitialAggsPrametersTypes);
        }

        #endregion

        #region Method Call : (setInitialAggs) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_setInitialAggs_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var grouping = CreateType<string>();
            var methodsetInitialAggsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfsetInitialAggs = { grouping };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodsetInitialAggs, methodsetInitialAggsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getgantttasksInstanceFixture, parametersOfsetInitialAggs);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfsetInitialAggs.ShouldNotBeNull();
            parametersOfsetInitialAggs.Length.ShouldBe(1);
            methodsetInitialAggsPrametersTypes.Length.ShouldBe(1);
            methodsetInitialAggsPrametersTypes.Length.ShouldBe(parametersOfsetInitialAggs.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setInitialAggs) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_setInitialAggs_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var grouping = CreateType<string>();
            var methodsetInitialAggsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfsetInitialAggs = { grouping };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getgantttasksInstance, MethodsetInitialAggs, parametersOfsetInitialAggs, methodsetInitialAggsPrametersTypes);

            // Assert
            parametersOfsetInitialAggs.ShouldNotBeNull();
            parametersOfsetInitialAggs.Length.ShouldBe(1);
            methodsetInitialAggsPrametersTypes.Length.ShouldBe(1);
            methodsetInitialAggsPrametersTypes.Length.ShouldBe(parametersOfsetInitialAggs.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setInitialAggs) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_setInitialAggs_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodsetInitialAggs, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setInitialAggs) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_setInitialAggs_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodsetInitialAggsPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodsetInitialAggs, Fixture, methodsetInitialAggsPrametersTypes);

            // Assert
            methodsetInitialAggsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setInitialAggs) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_setInitialAggs_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodsetInitialAggs, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getgantttasksInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getParams) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgantttasks_getParams_Method_Call_Internally(Type[] types)
        {
            var methodgetParamsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodgetParams, Fixture, methodgetParamsPrametersTypes);
        }

        #endregion

        #region Method Call : (getParams) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_getParams_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var curWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => _getgantttasksInstance.getParams(curWeb);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (getParams) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_getParams_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var curWeb = CreateType<SPWeb>();
            var methodgetParamsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfgetParams = { curWeb };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetParams, methodgetParamsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getgantttasksInstanceFixture, parametersOfgetParams);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetParams.ShouldNotBeNull();
            parametersOfgetParams.Length.ShouldBe(1);
            methodgetParamsPrametersTypes.Length.ShouldBe(1);
            methodgetParamsPrametersTypes.Length.ShouldBe(parametersOfgetParams.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getParams) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_getParams_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var curWeb = CreateType<SPWeb>();
            var methodgetParamsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfgetParams = { curWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getgantttasksInstance, MethodgetParams, parametersOfgetParams, methodgetParamsPrametersTypes);

            // Assert
            parametersOfgetParams.ShouldNotBeNull();
            parametersOfgetParams.Length.ShouldBe(1);
            methodgetParamsPrametersTypes.Length.ShouldBe(1);
            methodgetParamsPrametersTypes.Length.ShouldBe(parametersOfgetParams.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getParams) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_getParams_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetParams, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getParams) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_getParams_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetParamsPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodgetParams, Fixture, methodgetParamsPrametersTypes);

            // Assert
            methodgetParamsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getParams) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_getParams_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetParams, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getgantttasksInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addBar) (Return Type : XmlNode) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgantttasks_addBar_Method_Call_Internally(Type[] types)
        {
            var methodaddBarPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodaddBar, Fixture, methodaddBarPrametersTypes);
        }

        #endregion

        #region Method Call : (addBar) (Return Type : XmlNode) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_addBar_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var doc = CreateType<XmlDocument>();
            var nodeData = CreateType<string>();
            var methodaddBarPrametersTypes = new Type[] { typeof(XmlDocument), typeof(string) };
            object[] parametersOfaddBar = { doc, nodeData };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodaddBar, methodaddBarPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<getgantttasks, XmlNode>(_getgantttasksInstanceFixture, out exception1, parametersOfaddBar);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<getgantttasks, XmlNode>(_getgantttasksInstance, MethodaddBar, parametersOfaddBar, methodaddBarPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfaddBar.ShouldNotBeNull();
            parametersOfaddBar.Length.ShouldBe(2);
            methodaddBarPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (addBar) (Return Type : XmlNode) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_addBar_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var doc = CreateType<XmlDocument>();
            var nodeData = CreateType<string>();
            var methodaddBarPrametersTypes = new Type[] { typeof(XmlDocument), typeof(string) };
            object[] parametersOfaddBar = { doc, nodeData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getgantttasks, XmlNode>(_getgantttasksInstance, MethodaddBar, parametersOfaddBar, methodaddBarPrametersTypes);

            // Assert
            parametersOfaddBar.ShouldNotBeNull();
            parametersOfaddBar.Length.ShouldBe(2);
            methodaddBarPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addBar) (Return Type : XmlNode) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_addBar_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodaddBarPrametersTypes = new Type[] { typeof(XmlDocument), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodaddBar, Fixture, methodaddBarPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodaddBarPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (addBar) (Return Type : XmlNode) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_addBar_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodaddBarPrametersTypes = new Type[] { typeof(XmlDocument), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodaddBar, Fixture, methodaddBarPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodaddBarPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addBar) (Return Type : XmlNode) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_addBar_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodaddBar, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getgantttasksInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (addBar) (Return Type : XmlNode) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_addBar_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodaddBar, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addHeader) (Return Type : XmlDocument) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgantttasks_addHeader_Method_Call_Internally(Type[] types)
        {
            var methodaddHeaderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodaddHeader, Fixture, methodaddHeaderPrametersTypes);
        }

        #endregion

        #region Method Call : (addHeader) (Return Type : XmlDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_addHeader_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var doc = CreateType<XmlDocument>();
            var methodaddHeaderPrametersTypes = new Type[] { typeof(XmlDocument) };
            object[] parametersOfaddHeader = { doc };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodaddHeader, methodaddHeaderPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<getgantttasks, XmlDocument>(_getgantttasksInstanceFixture, out exception1, parametersOfaddHeader);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<getgantttasks, XmlDocument>(_getgantttasksInstance, MethodaddHeader, parametersOfaddHeader, methodaddHeaderPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfaddHeader.ShouldNotBeNull();
            parametersOfaddHeader.Length.ShouldBe(1);
            methodaddHeaderPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (addHeader) (Return Type : XmlDocument) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_addHeader_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var doc = CreateType<XmlDocument>();
            var methodaddHeaderPrametersTypes = new Type[] { typeof(XmlDocument) };
            object[] parametersOfaddHeader = { doc };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getgantttasks, XmlDocument>(_getgantttasksInstance, MethodaddHeader, parametersOfaddHeader, methodaddHeaderPrametersTypes);

            // Assert
            parametersOfaddHeader.ShouldNotBeNull();
            parametersOfaddHeader.Length.ShouldBe(1);
            methodaddHeaderPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addHeader) (Return Type : XmlDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_addHeader_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodaddHeaderPrametersTypes = new Type[] { typeof(XmlDocument) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodaddHeader, Fixture, methodaddHeaderPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodaddHeaderPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (addHeader) (Return Type : XmlDocument) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_addHeader_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodaddHeaderPrametersTypes = new Type[] { typeof(XmlDocument) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodaddHeader, Fixture, methodaddHeaderPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodaddHeaderPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addHeader) (Return Type : XmlDocument) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_addHeader_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodaddHeader, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getgantttasksInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (addHeader) (Return Type : XmlDocument) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_addHeader_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodaddHeader, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processListDT) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgantttasks_processListDT_Method_Call_Internally(Type[] types)
        {
            var methodprocessListDTPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodprocessListDT, Fixture, methodprocessListDTPrametersTypes);
        }

        #endregion

        #region Method Call : (processListDT) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_processListDT_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var dtRows = CreateType<DataRow[]>();
            var arrGTemp = CreateType<SortedList>();
            var listname = CreateType<string>();
            var methodprocessListDTPrametersTypes = new Type[] { typeof(SPWeb), typeof(DataRow[]), typeof(SortedList), typeof(string) };
            object[] parametersOfprocessListDT = { web, dtRows, arrGTemp, listname };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodprocessListDT, methodprocessListDTPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getgantttasksInstanceFixture, parametersOfprocessListDT);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfprocessListDT.ShouldNotBeNull();
            parametersOfprocessListDT.Length.ShouldBe(4);
            methodprocessListDTPrametersTypes.Length.ShouldBe(4);
            methodprocessListDTPrametersTypes.Length.ShouldBe(parametersOfprocessListDT.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processListDT) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_processListDT_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var dtRows = CreateType<DataRow[]>();
            var arrGTemp = CreateType<SortedList>();
            var listname = CreateType<string>();
            var methodprocessListDTPrametersTypes = new Type[] { typeof(SPWeb), typeof(DataRow[]), typeof(SortedList), typeof(string) };
            object[] parametersOfprocessListDT = { web, dtRows, arrGTemp, listname };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getgantttasksInstance, MethodprocessListDT, parametersOfprocessListDT, methodprocessListDTPrametersTypes);

            // Assert
            parametersOfprocessListDT.ShouldNotBeNull();
            parametersOfprocessListDT.Length.ShouldBe(4);
            methodprocessListDTPrametersTypes.Length.ShouldBe(4);
            methodprocessListDTPrametersTypes.Length.ShouldBe(parametersOfprocessListDT.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processListDT) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_processListDT_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodprocessListDT, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processListDT) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_processListDT_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodprocessListDTPrametersTypes = new Type[] { typeof(SPWeb), typeof(DataRow[]), typeof(SortedList), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodprocessListDT, Fixture, methodprocessListDTPrametersTypes);

            // Assert
            methodprocessListDTPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processListDT) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_processListDT_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprocessListDT, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getgantttasksInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processList) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgantttasks_processList_Method_Call_Internally(Type[] types)
        {
            var methodprocessListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodprocessList, Fixture, methodprocessListPrametersTypes);
        }

        #endregion

        #region Method Call : (processList) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_processList_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var spquery = CreateType<string>();
            var currentItems = CreateType<SPList>();
            var tempGroups = CreateType<SortedList>();
            var methodprocessListPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(SPList), typeof(SortedList) };
            object[] parametersOfprocessList = { web, spquery, currentItems, tempGroups };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodprocessList, methodprocessListPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getgantttasksInstanceFixture, parametersOfprocessList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfprocessList.ShouldNotBeNull();
            parametersOfprocessList.Length.ShouldBe(4);
            methodprocessListPrametersTypes.Length.ShouldBe(4);
            methodprocessListPrametersTypes.Length.ShouldBe(parametersOfprocessList.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (processList) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_processList_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var spquery = CreateType<string>();
            var currentItems = CreateType<SPList>();
            var tempGroups = CreateType<SortedList>();
            var methodprocessListPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(SPList), typeof(SortedList) };
            object[] parametersOfprocessList = { web, spquery, currentItems, tempGroups };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getgantttasksInstance, MethodprocessList, parametersOfprocessList, methodprocessListPrametersTypes);

            // Assert
            parametersOfprocessList.ShouldNotBeNull();
            parametersOfprocessList.Length.ShouldBe(4);
            methodprocessListPrametersTypes.Length.ShouldBe(4);
            methodprocessListPrametersTypes.Length.ShouldBe(parametersOfprocessList.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processList) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_processList_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodprocessList, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processList) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_processList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodprocessListPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(SPList), typeof(SortedList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodprocessList, Fixture, methodprocessListPrametersTypes);

            // Assert
            methodprocessListPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processList) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_processList_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprocessList, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getgantttasksInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessField) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgantttasks_ProcessField_Method_Call_Internally(Type[] types)
        {
            var methodProcessFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodProcessField, Fixture, methodProcessFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessField) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_ProcessField_Method_Call_Void_With_5_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var arrGTemp = CreateType<SortedList>();
            var groups = CreateType<string[]>();
            var groupby = CreateType<string>();
            var field = CreateType<SPField>();
            var newgroup = CreateType<string>();
            var methodProcessFieldPrametersTypes = new Type[] { typeof(SortedList), typeof(string[]), typeof(string), typeof(SPField), typeof(string) };
            object[] parametersOfProcessField = { arrGTemp, groups, groupby, field, newgroup };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getgantttasksInstance, MethodProcessField, parametersOfProcessField, methodProcessFieldPrametersTypes);

            // Assert
            parametersOfProcessField.ShouldNotBeNull();
            parametersOfProcessField.Length.ShouldBe(5);
            methodProcessFieldPrametersTypes.Length.ShouldBe(5);
            methodProcessFieldPrametersTypes.Length.ShouldBe(parametersOfProcessField.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessField) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_ProcessField_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessFieldPrametersTypes = new Type[] { typeof(SortedList), typeof(string[]), typeof(string), typeof(SPField), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodProcessField, Fixture, methodProcessFieldPrametersTypes);

            // Assert
            methodProcessFieldPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessUserField) (Return Type : string[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgantttasks_ProcessUserField_Static_Method_Call_Internally(Type[] types)
        {
            var methodProcessUserFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_getgantttasksInstanceFixture, _getgantttasksInstanceType, MethodProcessUserField, Fixture, methodProcessUserFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessUserField) (Return Type : string[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_ProcessUserField_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var arrGTemp = CreateType<SortedList>();
            var groups = CreateType<string[]>();
            var newgroup = CreateType<string>();
            var methodProcessUserFieldPrametersTypes = new Type[] { typeof(SortedList), typeof(string[]), typeof(string) };
            object[] parametersOfProcessUserField = { arrGTemp, groups, newgroup };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string[]>(_getgantttasksInstanceFixture, _getgantttasksInstanceType, MethodProcessUserField, parametersOfProcessUserField, methodProcessUserFieldPrametersTypes);

            // Assert
            parametersOfProcessUserField.ShouldNotBeNull();
            parametersOfProcessUserField.Length.ShouldBe(3);
            methodProcessUserFieldPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessUserField) (Return Type : string[]) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_ProcessUserField_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodProcessUserFieldPrametersTypes = new Type[] { typeof(SortedList), typeof(string[]), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_getgantttasksInstanceFixture, _getgantttasksInstanceType, MethodProcessUserField, Fixture, methodProcessUserFieldPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodProcessUserFieldPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (ProcessUserField) (Return Type : string[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_ProcessUserField_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessUserFieldPrametersTypes = new Type[] { typeof(SortedList), typeof(string[]), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_getgantttasksInstanceFixture, _getgantttasksInstanceType, MethodProcessUserField, Fixture, methodProcessUserFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodProcessUserFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (additionalPerfFields) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgantttasks_additionalPerfFields_Method_Call_Internally(Type[] types)
        {
            var methodadditionalPerfFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodadditionalPerfFields, Fixture, methodadditionalPerfFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (additionalPerfFields) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_additionalPerfFields_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var dqFields = CreateType<string>();
            var arr = CreateType<ArrayList>();
            var methodadditionalPerfFieldsPrametersTypes = new Type[] { typeof(string), typeof(ArrayList) };
            object[] parametersOfadditionalPerfFields = { dqFields, arr };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodadditionalPerfFields, methodadditionalPerfFieldsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<getgantttasks, string>(_getgantttasksInstanceFixture, out exception1, parametersOfadditionalPerfFields);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<getgantttasks, string>(_getgantttasksInstance, MethodadditionalPerfFields, parametersOfadditionalPerfFields, methodadditionalPerfFieldsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfadditionalPerfFields.ShouldNotBeNull();
            parametersOfadditionalPerfFields.Length.ShouldBe(2);
            methodadditionalPerfFieldsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (additionalPerfFields) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_additionalPerfFields_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dqFields = CreateType<string>();
            var arr = CreateType<ArrayList>();
            var methodadditionalPerfFieldsPrametersTypes = new Type[] { typeof(string), typeof(ArrayList) };
            object[] parametersOfadditionalPerfFields = { dqFields, arr };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getgantttasks, string>(_getgantttasksInstance, MethodadditionalPerfFields, parametersOfadditionalPerfFields, methodadditionalPerfFieldsPrametersTypes);

            // Assert
            parametersOfadditionalPerfFields.ShouldNotBeNull();
            parametersOfadditionalPerfFields.Length.ShouldBe(2);
            methodadditionalPerfFieldsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (additionalPerfFields) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_additionalPerfFields_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodadditionalPerfFieldsPrametersTypes = new Type[] { typeof(string), typeof(ArrayList) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodadditionalPerfFields, Fixture, methodadditionalPerfFieldsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodadditionalPerfFieldsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (additionalPerfFields) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_additionalPerfFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodadditionalPerfFieldsPrametersTypes = new Type[] { typeof(string), typeof(ArrayList) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodadditionalPerfFields, Fixture, methodadditionalPerfFieldsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodadditionalPerfFieldsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (additionalPerfFields) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_additionalPerfFields_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodadditionalPerfFields, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getgantttasksInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (additionalPerfFields) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_additionalPerfFields_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodadditionalPerfFields, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addGroups) (Return Type : XmlDocument) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgantttasks_addGroups_Method_Call_Internally(Type[] types)
        {
            var methodaddGroupsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodaddGroups, Fixture, methodaddGroupsPrametersTypes);
        }

        #endregion

        #region Method Call : (addGroups) (Return Type : XmlDocument) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_addGroups_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var doc = CreateType<XmlDocument>();
            var web = CreateType<SPWeb>();
            var spquery = CreateType<string>();
            var arrGTemp = CreateType<SortedList>();
            var methodaddGroupsPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb), typeof(string), typeof(SortedList) };
            object[] parametersOfaddGroups = { doc, web, spquery, arrGTemp };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodaddGroups, methodaddGroupsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getgantttasksInstanceFixture, parametersOfaddGroups);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfaddGroups.ShouldNotBeNull();
            parametersOfaddGroups.Length.ShouldBe(4);
            methodaddGroupsPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addGroups) (Return Type : XmlDocument) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_addGroups_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var doc = CreateType<XmlDocument>();
            var web = CreateType<SPWeb>();
            var spquery = CreateType<string>();
            var arrGTemp = CreateType<SortedList>();
            var methodaddGroupsPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb), typeof(string), typeof(SortedList) };
            object[] parametersOfaddGroups = { doc, web, spquery, arrGTemp };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getgantttasks, XmlDocument>(_getgantttasksInstance, MethodaddGroups, parametersOfaddGroups, methodaddGroupsPrametersTypes);

            // Assert
            parametersOfaddGroups.ShouldNotBeNull();
            parametersOfaddGroups.Length.ShouldBe(4);
            methodaddGroupsPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addGroups) (Return Type : XmlDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_addGroups_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodaddGroupsPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb), typeof(string), typeof(SortedList) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodaddGroups, Fixture, methodaddGroupsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodaddGroupsPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (addGroups) (Return Type : XmlDocument) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_addGroups_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodaddGroupsPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb), typeof(string), typeof(SortedList) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodaddGroups, Fixture, methodaddGroupsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodaddGroupsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addGroups) (Return Type : XmlDocument) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_addGroups_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodaddGroups, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getgantttasksInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (addGroups) (Return Type : XmlDocument) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_addGroups_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodaddGroups, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getField) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgantttasks_getField_Method_Call_Internally(Type[] types)
        {
            var methodgetFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodgetField, Fixture, methodgetFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (getField) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_getField_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var dr = CreateType<DataRow>();
            var field = CreateType<string>();
            var methodgetFieldPrametersTypes = new Type[] { typeof(DataRow), typeof(string) };
            object[] parametersOfgetField = { dr, field };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodgetField, methodgetFieldPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<getgantttasks, string>(_getgantttasksInstanceFixture, out exception1, parametersOfgetField);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<getgantttasks, string>(_getgantttasksInstance, MethodgetField, parametersOfgetField, methodgetFieldPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetField.ShouldNotBeNull();
            parametersOfgetField.Length.ShouldBe(2);
            methodgetFieldPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (getField) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_getField_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dr = CreateType<DataRow>();
            var field = CreateType<string>();
            var methodgetFieldPrametersTypes = new Type[] { typeof(DataRow), typeof(string) };
            object[] parametersOfgetField = { dr, field };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getgantttasks, string>(_getgantttasksInstance, MethodgetField, parametersOfgetField, methodgetFieldPrametersTypes);

            // Assert
            parametersOfgetField.ShouldNotBeNull();
            parametersOfgetField.Length.ShouldBe(2);
            methodgetFieldPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getField) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_getField_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetFieldPrametersTypes = new Type[] { typeof(DataRow), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodgetField, Fixture, methodgetFieldPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetFieldPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (getField) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_getField_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetFieldPrametersTypes = new Type[] { typeof(DataRow), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodgetField, Fixture, methodgetFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getField) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_getField_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getgantttasksInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getField) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_getField_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetField, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getField) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgantttasks_getField_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodgetFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodgetField, Fixture, methodgetFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (getField) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_getField_Method_Call_Overloading_Of_1_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var field = CreateType<string>();
            var methodgetFieldPrametersTypes = new Type[] { typeof(SPListItem), typeof(string) };
            object[] parametersOfgetField = { li, field };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetField, methodgetFieldPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getgantttasksInstanceFixture, parametersOfgetField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetField.ShouldNotBeNull();
            parametersOfgetField.Length.ShouldBe(2);
            methodgetFieldPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getField) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_getField_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var field = CreateType<string>();
            var methodgetFieldPrametersTypes = new Type[] { typeof(SPListItem), typeof(string) };
            object[] parametersOfgetField = { li, field };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getgantttasks, string>(_getgantttasksInstance, MethodgetField, parametersOfgetField, methodgetFieldPrametersTypes);

            // Assert
            parametersOfgetField.ShouldNotBeNull();
            parametersOfgetField.Length.ShouldBe(2);
            methodgetFieldPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getField) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_getField_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetFieldPrametersTypes = new Type[] { typeof(SPListItem), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodgetField, Fixture, methodgetFieldPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetFieldPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (getField) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_getField_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetFieldPrametersTypes = new Type[] { typeof(SPListItem), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodgetField, Fixture, methodgetFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getField) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_getField_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetField, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getgantttasksInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getField) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_getField_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetField, 1);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (formatField) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgantttasks_formatField_Method_Call_Internally(Type[] types)
        {
            var methodformatFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodformatField, Fixture, methodformatFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (formatField) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_formatField_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var val = CreateType<string>();
            var fieldname = CreateType<string>();
            var dr = CreateType<DataRow>();
            var group = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _getgantttasksInstance.formatField(val, fieldname, dr, group);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (formatField) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_formatField_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var val = CreateType<string>();
            var fieldname = CreateType<string>();
            var dr = CreateType<DataRow>();
            var group = CreateType<bool>();
            var methodformatFieldPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(DataRow), typeof(bool) };
            object[] parametersOfformatField = { val, fieldname, dr, group };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodformatField, methodformatFieldPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<getgantttasks, string>(_getgantttasksInstanceFixture, out exception1, parametersOfformatField);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<getgantttasks, string>(_getgantttasksInstance, MethodformatField, parametersOfformatField, methodformatFieldPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfformatField.ShouldNotBeNull();
            parametersOfformatField.Length.ShouldBe(4);
            methodformatFieldPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (formatField) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_formatField_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var val = CreateType<string>();
            var fieldname = CreateType<string>();
            var dr = CreateType<DataRow>();
            var group = CreateType<bool>();
            var methodformatFieldPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(DataRow), typeof(bool) };
            object[] parametersOfformatField = { val, fieldname, dr, group };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getgantttasks, string>(_getgantttasksInstance, MethodformatField, parametersOfformatField, methodformatFieldPrametersTypes);

            // Assert
            parametersOfformatField.ShouldNotBeNull();
            parametersOfformatField.Length.ShouldBe(4);
            methodformatFieldPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (formatField) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_formatField_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodformatFieldPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(DataRow), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodformatField, Fixture, methodformatFieldPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodformatFieldPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (formatField) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_formatField_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodformatFieldPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(DataRow), typeof(bool) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodformatField, Fixture, methodformatFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodformatFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (formatField) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_formatField_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodformatField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getgantttasksInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (formatField) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_formatField_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodformatField, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (formatField) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgantttasks_formatField_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodformatFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodformatField, Fixture, methodformatFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (formatField) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_formatField_Method_Call_Overloading_Of_1_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var val = CreateType<string>();
            var fieldname = CreateType<string>();
            var calculated = CreateType<bool>();
            var group = CreateType<bool>();
            var methodformatFieldPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(bool), typeof(bool) };
            object[] parametersOfformatField = { val, fieldname, calculated, group };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodformatField, methodformatFieldPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getgantttasksInstanceFixture, parametersOfformatField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfformatField.ShouldNotBeNull();
            parametersOfformatField.Length.ShouldBe(4);
            methodformatFieldPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (formatField) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_formatField_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var val = CreateType<string>();
            var fieldname = CreateType<string>();
            var calculated = CreateType<bool>();
            var group = CreateType<bool>();
            var methodformatFieldPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(bool), typeof(bool) };
            object[] parametersOfformatField = { val, fieldname, calculated, group };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getgantttasks, string>(_getgantttasksInstance, MethodformatField, parametersOfformatField, methodformatFieldPrametersTypes);

            // Assert
            parametersOfformatField.ShouldNotBeNull();
            parametersOfformatField.Length.ShouldBe(4);
            methodformatFieldPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (formatField) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_formatField_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodformatFieldPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(bool), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodformatField, Fixture, methodformatFieldPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodformatFieldPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (formatField) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_formatField_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodformatFieldPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(bool), typeof(bool) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodformatField, Fixture, methodformatFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodformatFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (formatField) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_formatField_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodformatField, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getgantttasksInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (formatField) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_formatField_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodformatField, 1);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setMinMax) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgantttasks_setMinMax_Method_Call_Internally(Type[] types)
        {
            var methodsetMinMaxPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodsetMinMax, Fixture, methodsetMinMaxPrametersTypes);
        }

        #endregion

        #region Method Call : (setMinMax) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_setMinMax_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var group = CreateType<string>();
            var min = CreateType<DateTime>();
            var max = CreateType<DateTime>();
            var methodsetMinMaxPrametersTypes = new Type[] { typeof(string), typeof(DateTime), typeof(DateTime) };
            object[] parametersOfsetMinMax = { group, min, max };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodsetMinMax, methodsetMinMaxPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getgantttasksInstanceFixture, parametersOfsetMinMax);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfsetMinMax.ShouldNotBeNull();
            parametersOfsetMinMax.Length.ShouldBe(3);
            methodsetMinMaxPrametersTypes.Length.ShouldBe(3);
            methodsetMinMaxPrametersTypes.Length.ShouldBe(parametersOfsetMinMax.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setMinMax) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_setMinMax_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var group = CreateType<string>();
            var min = CreateType<DateTime>();
            var max = CreateType<DateTime>();
            var methodsetMinMaxPrametersTypes = new Type[] { typeof(string), typeof(DateTime), typeof(DateTime) };
            object[] parametersOfsetMinMax = { group, min, max };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getgantttasksInstance, MethodsetMinMax, parametersOfsetMinMax, methodsetMinMaxPrametersTypes);

            // Assert
            parametersOfsetMinMax.ShouldNotBeNull();
            parametersOfsetMinMax.Length.ShouldBe(3);
            methodsetMinMaxPrametersTypes.Length.ShouldBe(3);
            methodsetMinMaxPrametersTypes.Length.ShouldBe(parametersOfsetMinMax.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setMinMax) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_setMinMax_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodsetMinMax, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setMinMax) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_setMinMax_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodsetMinMaxPrametersTypes = new Type[] { typeof(string), typeof(DateTime), typeof(DateTime) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodsetMinMax, Fixture, methodsetMinMaxPrametersTypes);

            // Assert
            methodsetMinMaxPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setMinMax) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_setMinMax_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodsetMinMax, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getgantttasksInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getQuery) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgantttasks_getQuery_Method_Call_Internally(Type[] types)
        {
            var methodgetQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodgetQuery, Fixture, methodgetQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (getQuery) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_getQuery_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _getgantttasksInstance.getQuery();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (getQuery) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_getQuery_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodgetQueryPrametersTypes = null;
            object[] parametersOfgetQuery = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodgetQuery, methodgetQueryPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<getgantttasks, string>(_getgantttasksInstanceFixture, out exception1, parametersOfgetQuery);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<getgantttasks, string>(_getgantttasksInstance, MethodgetQuery, parametersOfgetQuery, methodgetQueryPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetQuery.ShouldBeNull();
            methodgetQueryPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getQuery) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_getQuery_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodgetQueryPrametersTypes = null;
            object[] parametersOfgetQuery = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getgantttasks, string>(_getgantttasksInstance, MethodgetQuery, parametersOfgetQuery, methodgetQueryPrametersTypes);

            // Assert
            parametersOfgetQuery.ShouldBeNull();
            methodgetQueryPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getQuery) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_getQuery_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodgetQueryPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodgetQuery, Fixture, methodgetQueryPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetQueryPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getQuery) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_getQuery_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodgetQueryPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodgetQuery, Fixture, methodgetQueryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetQueryPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getQuery) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_getQuery_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetQuery, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getgantttasksInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (addItems) (Return Type : XmlDocument) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgantttasks_addItems_Method_Call_Internally(Type[] types)
        {
            var methodaddItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodaddItems, Fixture, methodaddItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (addItems) (Return Type : XmlDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_addItems_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var doc = CreateType<XmlDocument>();
            var curWeb = CreateType<SPWeb>();
            var methodaddItemsPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfaddItems = { doc, curWeb };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodaddItems, methodaddItemsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<getgantttasks, XmlDocument>(_getgantttasksInstanceFixture, out exception1, parametersOfaddItems);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<getgantttasks, XmlDocument>(_getgantttasksInstance, MethodaddItems, parametersOfaddItems, methodaddItemsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfaddItems.ShouldNotBeNull();
            parametersOfaddItems.Length.ShouldBe(2);
            methodaddItemsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (addItems) (Return Type : XmlDocument) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_addItems_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var doc = CreateType<XmlDocument>();
            var curWeb = CreateType<SPWeb>();
            var methodaddItemsPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfaddItems = { doc, curWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getgantttasks, XmlDocument>(_getgantttasksInstance, MethodaddItems, parametersOfaddItems, methodaddItemsPrametersTypes);

            // Assert
            parametersOfaddItems.ShouldNotBeNull();
            parametersOfaddItems.Length.ShouldBe(2);
            methodaddItemsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addItems) (Return Type : XmlDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_addItems_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodaddItemsPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodaddItems, Fixture, methodaddItemsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodaddItemsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (addItems) (Return Type : XmlDocument) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_addItems_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodaddItemsPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodaddItems, Fixture, methodaddItemsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodaddItemsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addItems) (Return Type : XmlDocument) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_addItems_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodaddItems, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getgantttasksInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (addItems) (Return Type : XmlDocument) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_addItems_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodaddItems, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addItem) (Return Type : XmlDocument) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgantttasks_addItem_Method_Call_Internally(Type[] types)
        {
            var methodaddItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodaddItem, Fixture, methodaddItemPrametersTypes);
        }

        #endregion

        #region Method Call : (addItem) (Return Type : XmlDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_addItem_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var dr = CreateType<DataRow>();
            var doc = CreateType<XmlDocument>();
            var methodaddItemPrametersTypes = new Type[] { typeof(DataRow), typeof(XmlDocument) };
            object[] parametersOfaddItem = { dr, doc };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodaddItem, methodaddItemPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<getgantttasks, XmlDocument>(_getgantttasksInstanceFixture, out exception1, parametersOfaddItem);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<getgantttasks, XmlDocument>(_getgantttasksInstance, MethodaddItem, parametersOfaddItem, methodaddItemPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfaddItem.ShouldNotBeNull();
            parametersOfaddItem.Length.ShouldBe(2);
            methodaddItemPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (addItem) (Return Type : XmlDocument) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_addItem_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dr = CreateType<DataRow>();
            var doc = CreateType<XmlDocument>();
            var methodaddItemPrametersTypes = new Type[] { typeof(DataRow), typeof(XmlDocument) };
            object[] parametersOfaddItem = { dr, doc };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getgantttasks, XmlDocument>(_getgantttasksInstance, MethodaddItem, parametersOfaddItem, methodaddItemPrametersTypes);

            // Assert
            parametersOfaddItem.ShouldNotBeNull();
            parametersOfaddItem.Length.ShouldBe(2);
            methodaddItemPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addItem) (Return Type : XmlDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_addItem_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodaddItemPrametersTypes = new Type[] { typeof(DataRow), typeof(XmlDocument) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodaddItem, Fixture, methodaddItemPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodaddItemPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (addItem) (Return Type : XmlDocument) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_addItem_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodaddItemPrametersTypes = new Type[] { typeof(DataRow), typeof(XmlDocument) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodaddItem, Fixture, methodaddItemPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodaddItemPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addItem) (Return Type : XmlDocument) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_addItem_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodaddItem, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getgantttasksInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (addItem) (Return Type : XmlDocument) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_addItem_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodaddItem, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addItem) (Return Type : XmlDocument) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgantttasks_addItem_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodaddItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodaddItem, Fixture, methodaddItemPrametersTypes);
        }

        #endregion

        #region Method Call : (addItem) (Return Type : XmlDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_addItem_Method_Call_Overloading_Of_1_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var doc = CreateType<XmlDocument>();
            var methodaddItemPrametersTypes = new Type[] { typeof(SPListItem), typeof(XmlDocument) };
            object[] parametersOfaddItem = { li, doc };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodaddItem, methodaddItemPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<getgantttasks, XmlDocument>(_getgantttasksInstanceFixture, out exception1, parametersOfaddItem);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<getgantttasks, XmlDocument>(_getgantttasksInstance, MethodaddItem, parametersOfaddItem, methodaddItemPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfaddItem.ShouldNotBeNull();
            parametersOfaddItem.Length.ShouldBe(2);
            methodaddItemPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (addItem) (Return Type : XmlDocument) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_addItem_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var doc = CreateType<XmlDocument>();
            var methodaddItemPrametersTypes = new Type[] { typeof(SPListItem), typeof(XmlDocument) };
            object[] parametersOfaddItem = { li, doc };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getgantttasks, XmlDocument>(_getgantttasksInstance, MethodaddItem, parametersOfaddItem, methodaddItemPrametersTypes);

            // Assert
            parametersOfaddItem.ShouldNotBeNull();
            parametersOfaddItem.Length.ShouldBe(2);
            methodaddItemPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addItem) (Return Type : XmlDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_addItem_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodaddItemPrametersTypes = new Type[] { typeof(SPListItem), typeof(XmlDocument) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodaddItem, Fixture, methodaddItemPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodaddItemPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (addItem) (Return Type : XmlDocument) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_addItem_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodaddItemPrametersTypes = new Type[] { typeof(SPListItem), typeof(XmlDocument) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodaddItem, Fixture, methodaddItemPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodaddItemPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addItem) (Return Type : XmlDocument) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_addItem_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodaddItem, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getgantttasksInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (addItem) (Return Type : XmlDocument) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_addItem_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodaddItem, 1);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setAggVal) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgantttasks_setAggVal_Method_Call_Internally(Type[] types)
        {
            var methodsetAggValPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodsetAggVal, Fixture, methodsetAggValPrametersTypes);
        }

        #endregion

        #region Method Call : (setAggVal) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_setAggVal_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var group = CreateType<string>();
            var fieldname = CreateType<string>();
            var val = CreateType<string>();
            var aggList = CreateType<SPList>();
            var methodsetAggValPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(SPList) };
            object[] parametersOfsetAggVal = { group, fieldname, val, aggList };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodsetAggVal, methodsetAggValPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getgantttasksInstanceFixture, parametersOfsetAggVal);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfsetAggVal.ShouldNotBeNull();
            parametersOfsetAggVal.Length.ShouldBe(4);
            methodsetAggValPrametersTypes.Length.ShouldBe(4);
            methodsetAggValPrametersTypes.Length.ShouldBe(parametersOfsetAggVal.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setAggVal) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_setAggVal_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var group = CreateType<string>();
            var fieldname = CreateType<string>();
            var val = CreateType<string>();
            var aggList = CreateType<SPList>();
            var methodsetAggValPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(SPList) };
            object[] parametersOfsetAggVal = { group, fieldname, val, aggList };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getgantttasksInstance, MethodsetAggVal, parametersOfsetAggVal, methodsetAggValPrametersTypes);

            // Assert
            parametersOfsetAggVal.ShouldNotBeNull();
            parametersOfsetAggVal.Length.ShouldBe(4);
            methodsetAggValPrametersTypes.Length.ShouldBe(4);
            methodsetAggValPrametersTypes.Length.ShouldBe(parametersOfsetAggVal.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setAggVal) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_setAggVal_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodsetAggVal, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setAggVal) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_setAggVal_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodsetAggValPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodsetAggVal, Fixture, methodsetAggValPrametersTypes);

            // Assert
            methodsetAggValPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setAggVal) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_setAggVal_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodsetAggVal, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getgantttasksInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getgantttasks_getRealField_Method_Call_Internally(Type[] types)
        {
            var methodgetRealFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodgetRealField, Fixture, methodgetRealFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_getRealField_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var methodgetRealFieldPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfgetRealField = { field };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodgetRealField, methodgetRealFieldPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<getgantttasks, SPField>(_getgantttasksInstanceFixture, out exception1, parametersOfgetRealField);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<getgantttasks, SPField>(_getgantttasksInstance, MethodgetRealField, parametersOfgetRealField, methodgetRealFieldPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetRealField.ShouldNotBeNull();
            parametersOfgetRealField.Length.ShouldBe(1);
            methodgetRealFieldPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_getRealField_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var methodgetRealFieldPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfgetRealField = { field };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetRealField, methodgetRealFieldPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getgantttasksInstanceFixture, parametersOfgetRealField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetRealField.ShouldNotBeNull();
            parametersOfgetRealField.Length.ShouldBe(1);
            methodgetRealFieldPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_getRealField_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var methodgetRealFieldPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfgetRealField = { field };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getgantttasks, SPField>(_getgantttasksInstance, MethodgetRealField, parametersOfgetRealField, methodgetRealFieldPrametersTypes);

            // Assert
            parametersOfgetRealField.ShouldNotBeNull();
            parametersOfgetRealField.Length.ShouldBe(1);
            methodgetRealFieldPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_getRealField_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetRealFieldPrametersTypes = new Type[] { typeof(SPField) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodgetRealField, Fixture, methodgetRealFieldPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetRealFieldPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_getRealField_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetRealFieldPrametersTypes = new Type[] { typeof(SPField) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getgantttasksInstance, MethodgetRealField, Fixture, methodgetRealFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetRealFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_getRealField_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetRealField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getgantttasksInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getgantttasks_getRealField_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetRealField, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #endregion

        #endregion
    }
}
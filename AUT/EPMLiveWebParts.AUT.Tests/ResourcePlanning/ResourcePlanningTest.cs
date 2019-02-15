using System;
using System.Diagnostics.CodeAnalysis;
using System.Web.UI;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.ResourcePlanning" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ResourcePlanningTest : AbstractBaseSetupTypedTest<ResourcePlanning>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ResourcePlanning) Initializer

        private const string PropertyDelayScript = "DelayScript";
        private const string PropertyWebPartContextualInfo = "WebPartContextualInfo";
        private const string MethodAddContextualTab = "AddContextualTab";
        private const string MethodOnLoad = "OnLoad";
        private const string MethodOnPreRender = "OnPreRender";
        private const string MethodDispose = "Dispose";
        private const string MethodCreateChildControls = "CreateChildControls";
        private const string MethodRenderWebPart = "RenderWebPart";
        private const string Methodlnk_Click = "lnk_Click";
        private const string MethodrenderGantt = "renderGantt";
        private const string MethodgetGanttParams = "getGanttParams";
        private const string MethodprocessControls = "processControls";
        private const string MethodrenderGrid = "renderGrid";
        private const string Fieldreslist = "reslist";
        private const string FieldrcList = "rcList";
        private const string Fieldresview = "resview";
        private const string FieldresUrl = "resUrl";
        private const string Fieldactivation = "activation";
        private const string Fieldtoolbar = "toolbar";
        private const string FieldresWeb = "resWeb";
        private const string FieldcurWeb = "curWeb";
        private const string FieldviewList = "viewList";
        private const string FieldstrAction = "strAction";
        private const string Fieldlnk = "lnk";
        private const string Fieldact = "act";
        private const string FieldsResourceList = "sResourceList";
        private const string Fielderror = "error";
        private const string FieldsFullGridId = "sFullGridId";
        private Type _resourcePlanningInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ResourcePlanning _resourcePlanningInstance;
        private ResourcePlanning _resourcePlanningInstanceFixture;

        #region General Initializer : Class (ResourcePlanning) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ResourcePlanning" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _resourcePlanningInstanceType = typeof(ResourcePlanning);
            _resourcePlanningInstanceFixture = Create(true);
            _resourcePlanningInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ResourcePlanning)

        #region General Initializer : Class (ResourcePlanning) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ResourcePlanning" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodAddContextualTab, 0)]
        [TestCase(MethodOnLoad, 0)]
        [TestCase(MethodOnPreRender, 0)]
        [TestCase(MethodDispose, 0)]
        [TestCase(MethodCreateChildControls, 0)]
        [TestCase(MethodRenderWebPart, 0)]
        [TestCase(Methodlnk_Click, 0)]
        [TestCase(MethodrenderGantt, 0)]
        [TestCase(MethodgetGanttParams, 0)]
        [TestCase(MethodprocessControls, 0)]
        [TestCase(MethodrenderGrid, 0)]
        public void AUT_ResourcePlanning_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_resourcePlanningInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ResourcePlanning) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ResourcePlanning" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyDelayScript)]
        [TestCase(PropertyWebPartContextualInfo)]
        public void AUT_ResourcePlanning_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_resourcePlanningInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ResourcePlanning) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ResourcePlanning" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldreslist)]
        [TestCase(FieldrcList)]
        [TestCase(Fieldresview)]
        [TestCase(FieldresUrl)]
        [TestCase(Fieldactivation)]
        [TestCase(Fieldtoolbar)]
        [TestCase(FieldresWeb)]
        [TestCase(FieldcurWeb)]
        [TestCase(FieldviewList)]
        [TestCase(FieldstrAction)]
        [TestCase(Fieldlnk)]
        [TestCase(Fieldact)]
        [TestCase(FieldsResourceList)]
        [TestCase(Fielderror)]
        [TestCase(FieldsFullGridId)]
        public void AUT_ResourcePlanning_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_resourcePlanningInstanceFixture, 
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
        ///     Class (<see cref="ResourcePlanning" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ResourcePlanning_Is_Instance_Present_Test()
        {
            // Assert
            _resourcePlanningInstanceType.ShouldNotBeNull();
            _resourcePlanningInstance.ShouldNotBeNull();
            _resourcePlanningInstanceFixture.ShouldNotBeNull();
            _resourcePlanningInstance.ShouldBeAssignableTo<ResourcePlanning>();
            _resourcePlanningInstanceFixture.ShouldBeAssignableTo<ResourcePlanning>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ResourcePlanning) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ResourcePlanning_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ResourcePlanning instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _resourcePlanningInstanceType.ShouldNotBeNull();
            _resourcePlanningInstance.ShouldNotBeNull();
            _resourcePlanningInstanceFixture.ShouldNotBeNull();
            _resourcePlanningInstance.ShouldBeAssignableTo<ResourcePlanning>();
            _resourcePlanningInstanceFixture.ShouldBeAssignableTo<ResourcePlanning>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ResourcePlanning) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyDelayScript)]
        [TestCaseGeneric(typeof(WebPartContextualInfo) , PropertyWebPartContextualInfo)]
        public void AUT_ResourcePlanning_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ResourcePlanning, T>(_resourcePlanningInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ResourcePlanning) => Property (DelayScript) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ResourcePlanning_Public_Class_DelayScript_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDelayScript);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ResourcePlanning) => Property (WebPartContextualInfo) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ResourcePlanning_WebPartContextualInfo_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyWebPartContextualInfo);
            Action currentAction = () => propertyInfo.SetValue(_resourcePlanningInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ResourcePlanning) => Property (WebPartContextualInfo) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ResourcePlanning_Public_Class_WebPartContextualInfo_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyWebPartContextualInfo);

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
        ///      Class (<see cref="ResourcePlanning" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodAddContextualTab)]
        [TestCase(MethodOnLoad)]
        [TestCase(MethodOnPreRender)]
        [TestCase(MethodDispose)]
        [TestCase(MethodCreateChildControls)]
        [TestCase(MethodRenderWebPart)]
        [TestCase(Methodlnk_Click)]
        [TestCase(MethodrenderGantt)]
        [TestCase(MethodgetGanttParams)]
        [TestCase(MethodprocessControls)]
        [TestCase(MethodrenderGrid)]
        public void AUT_ResourcePlanning_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ResourcePlanning>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (AddContextualTab) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePlanning_AddContextualTab_Method_Call_Internally(Type[] types)
        {
            var methodAddContextualTabPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePlanningInstance, MethodAddContextualTab, Fixture, methodAddContextualTabPrametersTypes);
        }

        #endregion

        #region Method Call : (AddContextualTab) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_AddContextualTab_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodAddContextualTabPrametersTypes = null;
            object[] parametersOfAddContextualTab = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddContextualTab, methodAddContextualTabPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourcePlanningInstanceFixture, parametersOfAddContextualTab);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddContextualTab.ShouldBeNull();
            methodAddContextualTabPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddContextualTab) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_AddContextualTab_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodAddContextualTabPrametersTypes = null;
            object[] parametersOfAddContextualTab = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourcePlanningInstance, MethodAddContextualTab, parametersOfAddContextualTab, methodAddContextualTabPrametersTypes);

            // Assert
            parametersOfAddContextualTab.ShouldBeNull();
            methodAddContextualTabPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddContextualTab) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_AddContextualTab_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodAddContextualTabPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePlanningInstance, MethodAddContextualTab, Fixture, methodAddContextualTabPrametersTypes);

            // Assert
            methodAddContextualTabPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddContextualTab) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_AddContextualTab_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddContextualTab, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcePlanningInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePlanning_OnLoad_Method_Call_Internally(Type[] types)
        {
            var methodOnLoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePlanningInstance, MethodOnLoad, Fixture, methodOnLoadPrametersTypes);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_OnLoad_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnLoadPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnLoad = { e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnLoad, methodOnLoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourcePlanningInstanceFixture, parametersOfOnLoad);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOnLoad.ShouldNotBeNull();
            parametersOfOnLoad.Length.ShouldBe(1);
            methodOnLoadPrametersTypes.Length.ShouldBe(1);
            methodOnLoadPrametersTypes.Length.ShouldBe(parametersOfOnLoad.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_OnLoad_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnLoadPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnLoad = { e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourcePlanningInstance, MethodOnLoad, parametersOfOnLoad, methodOnLoadPrametersTypes);

            // Assert
            parametersOfOnLoad.ShouldNotBeNull();
            parametersOfOnLoad.Length.ShouldBe(1);
            methodOnLoadPrametersTypes.Length.ShouldBe(1);
            methodOnLoadPrametersTypes.Length.ShouldBe(parametersOfOnLoad.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_OnLoad_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOnLoad, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_OnLoad_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnLoadPrametersTypes = new Type[] { typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePlanningInstance, MethodOnLoad, Fixture, methodOnLoadPrametersTypes);

            // Assert
            methodOnLoadPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_OnLoad_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnLoad, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcePlanningInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePlanning_OnPreRender_Method_Call_Internally(Type[] types)
        {
            var methodOnPreRenderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePlanningInstance, MethodOnPreRender, Fixture, methodOnPreRenderPrametersTypes);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_OnPreRender_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnPreRender = { e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnPreRender, methodOnPreRenderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourcePlanningInstanceFixture, parametersOfOnPreRender);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOnPreRender.ShouldNotBeNull();
            parametersOfOnPreRender.Length.ShouldBe(1);
            methodOnPreRenderPrametersTypes.Length.ShouldBe(1);
            methodOnPreRenderPrametersTypes.Length.ShouldBe(parametersOfOnPreRender.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_OnPreRender_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnPreRender = { e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourcePlanningInstance, MethodOnPreRender, parametersOfOnPreRender, methodOnPreRenderPrametersTypes);

            // Assert
            parametersOfOnPreRender.ShouldNotBeNull();
            parametersOfOnPreRender.Length.ShouldBe(1);
            methodOnPreRenderPrametersTypes.Length.ShouldBe(1);
            methodOnPreRenderPrametersTypes.Length.ShouldBe(parametersOfOnPreRender.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_OnPreRender_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOnPreRender, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_OnPreRender_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePlanningInstance, MethodOnPreRender, Fixture, methodOnPreRenderPrametersTypes);

            // Assert
            methodOnPreRenderPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_OnPreRender_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnPreRender, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcePlanningInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePlanning_Dispose_Method_Call_Internally(Type[] types)
        {
            var methodDisposePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePlanningInstance, MethodDispose, Fixture, methodDisposePrametersTypes);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_Dispose_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _resourcePlanningInstance.Dispose();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_Dispose_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodDisposePrametersTypes = null;
            object[] parametersOfDispose = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDispose, methodDisposePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourcePlanningInstanceFixture, parametersOfDispose);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDispose.ShouldBeNull();
            methodDisposePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_Dispose_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodDisposePrametersTypes = null;
            object[] parametersOfDispose = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourcePlanningInstance, MethodDispose, parametersOfDispose, methodDisposePrametersTypes);

            // Assert
            parametersOfDispose.ShouldBeNull();
            methodDisposePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_Dispose_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodDisposePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePlanningInstance, MethodDispose, Fixture, methodDisposePrametersTypes);

            // Assert
            methodDisposePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_Dispose_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDispose, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcePlanningInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePlanning_CreateChildControls_Method_Call_Internally(Type[] types)
        {
            var methodCreateChildControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePlanningInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, methodCreateChildControlsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourcePlanningInstanceFixture, parametersOfCreateChildControls);

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
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourcePlanningInstance, MethodCreateChildControls, parametersOfCreateChildControls, methodCreateChildControlsPrametersTypes);

            // Assert
            parametersOfCreateChildControls.ShouldBeNull();
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_CreateChildControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePlanningInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);

            // Assert
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_CreateChildControls_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcePlanningInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderWebPart) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePlanning_RenderWebPart_Method_Call_Internally(Type[] types)
        {
            var methodRenderWebPartPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePlanningInstance, MethodRenderWebPart, Fixture, methodRenderWebPartPrametersTypes);
        }

        #endregion

        #region Method Call : (RenderWebPart) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_RenderWebPart_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodRenderWebPartPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRenderWebPart = { output };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRenderWebPart, methodRenderWebPartPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourcePlanningInstanceFixture, parametersOfRenderWebPart);

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
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_RenderWebPart_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodRenderWebPartPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRenderWebPart = { output };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourcePlanningInstance, MethodRenderWebPart, parametersOfRenderWebPart, methodRenderWebPartPrametersTypes);

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
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_RenderWebPart_Method_Call_Parameters_Count_Verification_Test()
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
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_RenderWebPart_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenderWebPartPrametersTypes = new Type[] { typeof(HtmlTextWriter) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePlanningInstance, MethodRenderWebPart, Fixture, methodRenderWebPartPrametersTypes);

            // Assert
            methodRenderWebPartPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderWebPart) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_RenderWebPart_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenderWebPart, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcePlanningInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (lnk_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePlanning_lnk_Click_Method_Call_Internally(Type[] types)
        {
            var methodlnk_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePlanningInstance, Methodlnk_Click, Fixture, methodlnk_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (lnk_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_lnk_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodlnk_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOflnk_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(Methodlnk_Click, methodlnk_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourcePlanningInstanceFixture, parametersOflnk_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOflnk_Click.ShouldNotBeNull();
            parametersOflnk_Click.Length.ShouldBe(2);
            methodlnk_ClickPrametersTypes.Length.ShouldBe(2);
            methodlnk_ClickPrametersTypes.Length.ShouldBe(parametersOflnk_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (lnk_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_lnk_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodlnk_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOflnk_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourcePlanningInstance, Methodlnk_Click, parametersOflnk_Click, methodlnk_ClickPrametersTypes);

            // Assert
            parametersOflnk_Click.ShouldNotBeNull();
            parametersOflnk_Click.Length.ShouldBe(2);
            methodlnk_ClickPrametersTypes.Length.ShouldBe(2);
            methodlnk_ClickPrametersTypes.Length.ShouldBe(parametersOflnk_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (lnk_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_lnk_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(Methodlnk_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (lnk_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_lnk_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodlnk_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePlanningInstance, Methodlnk_Click, Fixture, methodlnk_ClickPrametersTypes);

            // Assert
            methodlnk_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (lnk_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_lnk_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(Methodlnk_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcePlanningInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (renderGantt) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePlanning_renderGantt_Method_Call_Internally(Type[] types)
        {
            var methodrenderGanttPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePlanningInstance, MethodrenderGantt, Fixture, methodrenderGanttPrametersTypes);
        }

        #endregion

        #region Method Call : (renderGantt) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_renderGantt_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodrenderGanttPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfrenderGantt = { output };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodrenderGantt, methodrenderGanttPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourcePlanningInstanceFixture, parametersOfrenderGantt);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfrenderGantt.ShouldNotBeNull();
            parametersOfrenderGantt.Length.ShouldBe(1);
            methodrenderGanttPrametersTypes.Length.ShouldBe(1);
            methodrenderGanttPrametersTypes.Length.ShouldBe(parametersOfrenderGantt.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (renderGantt) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_renderGantt_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodrenderGanttPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfrenderGantt = { output };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourcePlanningInstance, MethodrenderGantt, parametersOfrenderGantt, methodrenderGanttPrametersTypes);

            // Assert
            parametersOfrenderGantt.ShouldNotBeNull();
            parametersOfrenderGantt.Length.ShouldBe(1);
            methodrenderGanttPrametersTypes.Length.ShouldBe(1);
            methodrenderGanttPrametersTypes.Length.ShouldBe(parametersOfrenderGantt.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (renderGantt) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_renderGantt_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodrenderGantt, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (renderGantt) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_renderGantt_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodrenderGanttPrametersTypes = new Type[] { typeof(HtmlTextWriter) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePlanningInstance, MethodrenderGantt, Fixture, methodrenderGanttPrametersTypes);

            // Assert
            methodrenderGanttPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (renderGantt) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_renderGantt_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodrenderGantt, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcePlanningInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getGanttParams) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePlanning_getGanttParams_Method_Call_Internally(Type[] types)
        {
            var methodgetGanttParamsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePlanningInstance, MethodgetGanttParams, Fixture, methodgetGanttParamsPrametersTypes);
        }

        #endregion

        #region Method Call : (getGanttParams) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_getGanttParams_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodgetGanttParamsPrametersTypes = null;
            object[] parametersOfgetGanttParams = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodgetGanttParams, methodgetGanttParamsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResourcePlanning, string>(_resourcePlanningInstanceFixture, out exception1, parametersOfgetGanttParams);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResourcePlanning, string>(_resourcePlanningInstance, MethodgetGanttParams, parametersOfgetGanttParams, methodgetGanttParamsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetGanttParams.ShouldBeNull();
            methodgetGanttParamsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getGanttParams) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_getGanttParams_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodgetGanttParamsPrametersTypes = null;
            object[] parametersOfgetGanttParams = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ResourcePlanning, string>(_resourcePlanningInstance, MethodgetGanttParams, parametersOfgetGanttParams, methodgetGanttParamsPrametersTypes);

            // Assert
            parametersOfgetGanttParams.ShouldBeNull();
            methodgetGanttParamsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getGanttParams) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_getGanttParams_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodgetGanttParamsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePlanningInstance, MethodgetGanttParams, Fixture, methodgetGanttParamsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetGanttParamsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getGanttParams) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_getGanttParams_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodgetGanttParamsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePlanningInstance, MethodgetGanttParams, Fixture, methodgetGanttParamsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetGanttParamsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getGanttParams) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_getGanttParams_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetGanttParams, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcePlanningInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (processControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePlanning_processControls_Method_Call_Internally(Type[] types)
        {
            var methodprocessControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePlanningInstance, MethodprocessControls, Fixture, methodprocessControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (processControls) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_processControls_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var parentControl = CreateType<Control>();
            var ZoneIndex = CreateType<string>();
            var viewUrl = CreateType<string>();
            var curWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => _resourcePlanningInstance.processControls(parentControl, ZoneIndex, viewUrl, curWeb);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (processControls) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_processControls_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var parentControl = CreateType<Control>();
            var ZoneIndex = CreateType<string>();
            var viewUrl = CreateType<string>();
            var curWeb = CreateType<SPWeb>();
            var methodprocessControlsPrametersTypes = new Type[] { typeof(Control), typeof(string), typeof(string), typeof(SPWeb) };
            object[] parametersOfprocessControls = { parentControl, ZoneIndex, viewUrl, curWeb };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodprocessControls, methodprocessControlsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourcePlanningInstanceFixture, parametersOfprocessControls);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfprocessControls.ShouldNotBeNull();
            parametersOfprocessControls.Length.ShouldBe(4);
            methodprocessControlsPrametersTypes.Length.ShouldBe(4);
            methodprocessControlsPrametersTypes.Length.ShouldBe(parametersOfprocessControls.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processControls) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_processControls_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var parentControl = CreateType<Control>();
            var ZoneIndex = CreateType<string>();
            var viewUrl = CreateType<string>();
            var curWeb = CreateType<SPWeb>();
            var methodprocessControlsPrametersTypes = new Type[] { typeof(Control), typeof(string), typeof(string), typeof(SPWeb) };
            object[] parametersOfprocessControls = { parentControl, ZoneIndex, viewUrl, curWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourcePlanningInstance, MethodprocessControls, parametersOfprocessControls, methodprocessControlsPrametersTypes);

            // Assert
            parametersOfprocessControls.ShouldNotBeNull();
            parametersOfprocessControls.Length.ShouldBe(4);
            methodprocessControlsPrametersTypes.Length.ShouldBe(4);
            methodprocessControlsPrametersTypes.Length.ShouldBe(parametersOfprocessControls.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processControls) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_processControls_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodprocessControls, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processControls) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_processControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodprocessControlsPrametersTypes = new Type[] { typeof(Control), typeof(string), typeof(string), typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePlanningInstance, MethodprocessControls, Fixture, methodprocessControlsPrametersTypes);

            // Assert
            methodprocessControlsPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processControls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_processControls_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprocessControls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcePlanningInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (renderGrid) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePlanning_renderGrid_Method_Call_Internally(Type[] types)
        {
            var methodrenderGridPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePlanningInstance, MethodrenderGrid, Fixture, methodrenderGridPrametersTypes);
        }

        #endregion

        #region Method Call : (renderGrid) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_renderGrid_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodrenderGridPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfrenderGrid = { output };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodrenderGrid, methodrenderGridPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourcePlanningInstanceFixture, parametersOfrenderGrid);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfrenderGrid.ShouldNotBeNull();
            parametersOfrenderGrid.Length.ShouldBe(1);
            methodrenderGridPrametersTypes.Length.ShouldBe(1);
            methodrenderGridPrametersTypes.Length.ShouldBe(parametersOfrenderGrid.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (renderGrid) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_renderGrid_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodrenderGridPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfrenderGrid = { output };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourcePlanningInstance, MethodrenderGrid, parametersOfrenderGrid, methodrenderGridPrametersTypes);

            // Assert
            parametersOfrenderGrid.ShouldNotBeNull();
            parametersOfrenderGrid.Length.ShouldBe(1);
            methodrenderGridPrametersTypes.Length.ShouldBe(1);
            methodrenderGridPrametersTypes.Length.ShouldBe(parametersOfrenderGrid.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (renderGrid) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_renderGrid_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodrenderGrid, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (renderGrid) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_renderGrid_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodrenderGridPrametersTypes = new Type[] { typeof(HtmlTextWriter) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePlanningInstance, MethodrenderGrid, Fixture, methodrenderGridPrametersTypes);

            // Assert
            methodrenderGridPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (renderGrid) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanning_renderGrid_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodrenderGrid, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcePlanningInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
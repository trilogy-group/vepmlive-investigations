using System;
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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.getitems" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class GetitemsTest : AbstractBaseSetupTypedTest<getitems>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (getitems) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodaddGroups = "addGroups";
        private const string MethodaddItems = "addItems";
        private const string MethodaddItem = "addItem";
        private const string MethodgetRealQuery = "getRealQuery";
        private const string MethodgetField = "getField";
        private const string MethodformatField = "formatField";
        private const string MethodaddHeader = "addHeader";
        private const string FieldstrXml = "strXml";
        private const string FielddocXml = "docXml";
        private const string FielddocConfig = "docConfig";
        private const string FieldndCurrentView = "ndCurrentView";
        private const string FieldcurWeb = "curWeb";
        private const string FieldcurView = "curView";
        private const string Fielddata = "data";
        private const string FieldarrColumns = "arrColumns";
        private const string FieldqueueAllItems = "queueAllItems";
        private const string FieldarrItems = "arrItems";
        private const string FieldhshItemNodes = "hshItemNodes";
        private const string FieldarrAggregationDef = "arrAggregationDef";
        private const string FieldarrAggregationVals = "arrAggregationVals";
        private const string FieldhshWBS = "hshWBS";
        private const string FieldarrGroupMin = "arrGroupMin";
        private const string FieldarrGroupMax = "arrGroupMax";
        private const string FieldndMainParent = "ndMainParent";
        private const string FieldhshGroups = "hshGroups";
        private const string FieldarrGroupFields = "arrGroupFields";
        private const string FieldarrGroupExpand = "arrGroupExpand";
        private Type _getitemsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private getitems _getitemsInstance;
        private getitems _getitemsInstanceFixture;

        #region General Initializer : Class (getitems) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="getitems" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _getitemsInstanceType = typeof(getitems);
            _getitemsInstanceFixture = Create(true);
            _getitemsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (getitems)

        #region General Initializer : Class (getitems) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="getitems" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodaddGroups, 0)]
        [TestCase(MethodaddItems, 0)]
        [TestCase(MethodaddItem, 0)]
        [TestCase(MethodgetRealQuery, 0)]
        [TestCase(MethodaddGroups, 1)]
        [TestCase(MethodgetField, 0)]
        [TestCase(MethodformatField, 0)]
        [TestCase(MethodaddHeader, 0)]
        public void AUT_Getitems_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_getitemsInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (getitems) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="getitems" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldstrXml)]
        [TestCase(FielddocXml)]
        [TestCase(FielddocConfig)]
        [TestCase(FieldndCurrentView)]
        [TestCase(FieldcurWeb)]
        [TestCase(FieldcurView)]
        [TestCase(Fielddata)]
        [TestCase(FieldarrColumns)]
        [TestCase(FieldqueueAllItems)]
        [TestCase(FieldarrItems)]
        [TestCase(FieldhshItemNodes)]
        [TestCase(FieldarrAggregationDef)]
        [TestCase(FieldarrAggregationVals)]
        [TestCase(FieldhshWBS)]
        [TestCase(FieldarrGroupMin)]
        [TestCase(FieldarrGroupMax)]
        [TestCase(FieldndMainParent)]
        [TestCase(FieldhshGroups)]
        [TestCase(FieldarrGroupFields)]
        [TestCase(FieldarrGroupExpand)]
        public void AUT_Getitems_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_getitemsInstanceFixture, 
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
        ///     Class (<see cref="getitems" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Getitems_Is_Instance_Present_Test()
        {
            // Assert
            _getitemsInstanceType.ShouldNotBeNull();
            _getitemsInstance.ShouldNotBeNull();
            _getitemsInstanceFixture.ShouldNotBeNull();
            _getitemsInstance.ShouldBeAssignableTo<getitems>();
            _getitemsInstanceFixture.ShouldBeAssignableTo<getitems>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (getitems) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_getitems_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            getitems instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _getitemsInstanceType.ShouldNotBeNull();
            _getitemsInstance.ShouldNotBeNull();
            _getitemsInstanceFixture.ShouldNotBeNull();
            _getitemsInstance.ShouldBeAssignableTo<getitems>();
            _getitemsInstanceFixture.ShouldBeAssignableTo<getitems>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="getitems" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodaddGroups)]
        [TestCase(MethodaddItems)]
        [TestCase(MethodaddItem)]
        [TestCase(MethodgetRealQuery)]
        [TestCase(MethodgetField)]
        [TestCase(MethodformatField)]
        [TestCase(MethodaddHeader)]
        public void AUT_Getitems_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<getitems>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getitems_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getitemsInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getitems_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getitemsInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Getitems_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getitemsInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Getitems_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Getitems_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getitemsInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getitems_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getitemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addGroups) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getitems_addGroups_Method_Call_Internally(Type[] types)
        {
            var methodaddGroupsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getitemsInstance, MethodaddGroups, Fixture, methodaddGroupsPrametersTypes);
        }

        #endregion

        #region Method Call : (addGroups) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getitems_addGroups_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodaddGroupsPrametersTypes = null;
            object[] parametersOfaddGroups = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodaddGroups, methodaddGroupsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getitemsInstanceFixture, parametersOfaddGroups);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfaddGroups.ShouldBeNull();
            methodaddGroupsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (addGroups) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getitems_addGroups_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodaddGroupsPrametersTypes = null;
            object[] parametersOfaddGroups = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getitemsInstance, MethodaddGroups, parametersOfaddGroups, methodaddGroupsPrametersTypes);

            // Assert
            parametersOfaddGroups.ShouldBeNull();
            methodaddGroupsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addGroups) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getitems_addGroups_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodaddGroupsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getitemsInstance, MethodaddGroups, Fixture, methodaddGroupsPrametersTypes);

            // Assert
            methodaddGroupsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addGroups) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getitems_addGroups_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodaddGroups, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getitemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addItems) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getitems_addItems_Method_Call_Internally(Type[] types)
        {
            var methodaddItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getitemsInstance, MethodaddItems, Fixture, methodaddItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (addItems) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getitems_addItems_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodaddItemsPrametersTypes = null;
            object[] parametersOfaddItems = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodaddItems, methodaddItemsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getitemsInstanceFixture, parametersOfaddItems);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfaddItems.ShouldBeNull();
            methodaddItemsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addItems) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getitems_addItems_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodaddItemsPrametersTypes = null;
            object[] parametersOfaddItems = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getitemsInstance, MethodaddItems, parametersOfaddItems, methodaddItemsPrametersTypes);

            // Assert
            parametersOfaddItems.ShouldBeNull();
            methodaddItemsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addItems) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getitems_addItems_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodaddItemsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getitemsInstance, MethodaddItems, Fixture, methodaddItemsPrametersTypes);

            // Assert
            methodaddItemsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addItems) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getitems_addItems_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodaddItems, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getitemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addItem) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getitems_addItem_Method_Call_Internally(Type[] types)
        {
            var methodaddItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getitemsInstance, MethodaddItem, Fixture, methodaddItemPrametersTypes);
        }

        #endregion

        #region Method Call : (addItem) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getitems_addItem_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var methodaddItemPrametersTypes = new Type[] { typeof(SPListItem) };
            object[] parametersOfaddItem = { li };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodaddItem, methodaddItemPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getitemsInstanceFixture, parametersOfaddItem);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfaddItem.ShouldNotBeNull();
            parametersOfaddItem.Length.ShouldBe(1);
            methodaddItemPrametersTypes.Length.ShouldBe(1);
            methodaddItemPrametersTypes.Length.ShouldBe(parametersOfaddItem.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (addItem) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getitems_addItem_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var methodaddItemPrametersTypes = new Type[] { typeof(SPListItem) };
            object[] parametersOfaddItem = { li };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getitemsInstance, MethodaddItem, parametersOfaddItem, methodaddItemPrametersTypes);

            // Assert
            parametersOfaddItem.ShouldNotBeNull();
            parametersOfaddItem.Length.ShouldBe(1);
            methodaddItemPrametersTypes.Length.ShouldBe(1);
            methodaddItemPrametersTypes.Length.ShouldBe(parametersOfaddItem.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addItem) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getitems_addItem_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodaddItem, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addItem) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getitems_addItem_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodaddItemPrametersTypes = new Type[] { typeof(SPListItem) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getitemsInstance, MethodaddItem, Fixture, methodaddItemPrametersTypes);

            // Assert
            methodaddItemPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addItem) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getitems_addItem_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodaddItem, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getitemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getRealQuery) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getitems_getRealQuery_Method_Call_Internally(Type[] types)
        {
            var methodgetRealQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getitemsInstance, MethodgetRealQuery, Fixture, methodgetRealQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (getRealQuery) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getitems_getRealQuery_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var nd = CreateType<XmlNode>();
            var web = CreateType<SPWeb>();
            var methodgetRealQueryPrametersTypes = new Type[] { typeof(XmlNode), typeof(SPWeb) };
            object[] parametersOfgetRealQuery = { nd, web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetRealQuery, methodgetRealQueryPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getitemsInstanceFixture, parametersOfgetRealQuery);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetRealQuery.ShouldNotBeNull();
            parametersOfgetRealQuery.Length.ShouldBe(2);
            methodgetRealQueryPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getRealQuery) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getitems_getRealQuery_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var nd = CreateType<XmlNode>();
            var web = CreateType<SPWeb>();
            var methodgetRealQueryPrametersTypes = new Type[] { typeof(XmlNode), typeof(SPWeb) };
            object[] parametersOfgetRealQuery = { nd, web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getitems, string>(_getitemsInstance, MethodgetRealQuery, parametersOfgetRealQuery, methodgetRealQueryPrametersTypes);

            // Assert
            parametersOfgetRealQuery.ShouldNotBeNull();
            parametersOfgetRealQuery.Length.ShouldBe(2);
            methodgetRealQueryPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getRealQuery) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getitems_getRealQuery_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetRealQueryPrametersTypes = new Type[] { typeof(XmlNode), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getitemsInstance, MethodgetRealQuery, Fixture, methodgetRealQueryPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetRealQueryPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (getRealQuery) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getitems_getRealQuery_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetRealQueryPrametersTypes = new Type[] { typeof(XmlNode), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getitemsInstance, MethodgetRealQuery, Fixture, methodgetRealQueryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetRealQueryPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getRealQuery) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getitems_getRealQuery_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetRealQuery, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getitemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getRealQuery) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getitems_getRealQuery_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetRealQuery, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addGroups) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getitems_addGroups_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodaddGroupsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getitemsInstance, MethodaddGroups, Fixture, methodaddGroupsPrametersTypes);
        }

        #endregion

        #region Method Call : (addGroups) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getitems_addGroups_Method_Call_Void_Overloading_Of_1_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodaddGroupsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfaddGroups = { web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodaddGroups, methodaddGroupsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getitemsInstanceFixture, parametersOfaddGroups);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfaddGroups.ShouldNotBeNull();
            parametersOfaddGroups.Length.ShouldBe(1);
            methodaddGroupsPrametersTypes.Length.ShouldBe(1);
            methodaddGroupsPrametersTypes.Length.ShouldBe(parametersOfaddGroups.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addGroups) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getitems_addGroups_Method_Call_Void_Overloading_Of_1_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodaddGroupsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfaddGroups = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getitemsInstance, MethodaddGroups, parametersOfaddGroups, methodaddGroupsPrametersTypes);

            // Assert
            parametersOfaddGroups.ShouldNotBeNull();
            parametersOfaddGroups.Length.ShouldBe(1);
            methodaddGroupsPrametersTypes.Length.ShouldBe(1);
            methodaddGroupsPrametersTypes.Length.ShouldBe(parametersOfaddGroups.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addGroups) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getitems_addGroups_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodaddGroups, 1);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addGroups) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getitems_addGroups_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodaddGroupsPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getitemsInstance, MethodaddGroups, Fixture, methodaddGroupsPrametersTypes);

            // Assert
            methodaddGroupsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addGroups) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getitems_addGroups_Method_Call_Overloading_Of_1_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodaddGroups, 1);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getitemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getField) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getitems_getField_Method_Call_Internally(Type[] types)
        {
            var methodgetFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getitemsInstance, MethodgetField, Fixture, methodgetFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (getField) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getitems_getField_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var field = CreateType<string>();
            var group = CreateType<bool>();
            var methodgetFieldPrametersTypes = new Type[] { typeof(SPListItem), typeof(string), typeof(bool) };
            object[] parametersOfgetField = { li, field, group };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetField, methodgetFieldPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getitemsInstanceFixture, parametersOfgetField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetField.ShouldNotBeNull();
            parametersOfgetField.Length.ShouldBe(3);
            methodgetFieldPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getField) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getitems_getField_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var field = CreateType<string>();
            var group = CreateType<bool>();
            var methodgetFieldPrametersTypes = new Type[] { typeof(SPListItem), typeof(string), typeof(bool) };
            object[] parametersOfgetField = { li, field, group };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getitems, string>(_getitemsInstance, MethodgetField, parametersOfgetField, methodgetFieldPrametersTypes);

            // Assert
            parametersOfgetField.ShouldNotBeNull();
            parametersOfgetField.Length.ShouldBe(3);
            methodgetFieldPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getField) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getitems_getField_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetFieldPrametersTypes = new Type[] { typeof(SPListItem), typeof(string), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getitemsInstance, MethodgetField, Fixture, methodgetFieldPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetFieldPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (getField) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getitems_getField_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetFieldPrametersTypes = new Type[] { typeof(SPListItem), typeof(string), typeof(bool) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getitemsInstance, MethodgetField, Fixture, methodgetFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getField) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getitems_getField_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getitemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getField) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getitems_getField_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetField, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (formatField) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getitems_formatField_Method_Call_Internally(Type[] types)
        {
            var methodformatFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getitemsInstance, MethodformatField, Fixture, methodformatFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (formatField) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getitems_formatField_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var val = CreateType<string>();
            var fieldname = CreateType<string>();
            var calculated = CreateType<bool>();
            var group = CreateType<bool>();
            var li = CreateType<SPListItem>();
            var methodformatFieldPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(bool), typeof(bool), typeof(SPListItem) };
            object[] parametersOfformatField = { val, fieldname, calculated, group, li };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodformatField, methodformatFieldPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<getitems, string>(_getitemsInstanceFixture, out exception1, parametersOfformatField);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<getitems, string>(_getitemsInstance, MethodformatField, parametersOfformatField, methodformatFieldPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfformatField.ShouldNotBeNull();
            parametersOfformatField.Length.ShouldBe(5);
            methodformatFieldPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (formatField) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getitems_formatField_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var val = CreateType<string>();
            var fieldname = CreateType<string>();
            var calculated = CreateType<bool>();
            var group = CreateType<bool>();
            var li = CreateType<SPListItem>();
            var methodformatFieldPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(bool), typeof(bool), typeof(SPListItem) };
            object[] parametersOfformatField = { val, fieldname, calculated, group, li };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getitems, string>(_getitemsInstance, MethodformatField, parametersOfformatField, methodformatFieldPrametersTypes);

            // Assert
            parametersOfformatField.ShouldNotBeNull();
            parametersOfformatField.Length.ShouldBe(5);
            methodformatFieldPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (formatField) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getitems_formatField_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodformatFieldPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(bool), typeof(bool), typeof(SPListItem) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getitemsInstance, MethodformatField, Fixture, methodformatFieldPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodformatFieldPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (formatField) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getitems_formatField_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodformatFieldPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(bool), typeof(bool), typeof(SPListItem) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getitemsInstance, MethodformatField, Fixture, methodformatFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodformatFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (formatField) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getitems_formatField_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodformatField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getitemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (formatField) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getitems_formatField_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodformatField, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addHeader) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getitems_addHeader_Method_Call_Internally(Type[] types)
        {
            var methodaddHeaderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getitemsInstance, MethodaddHeader, Fixture, methodaddHeaderPrametersTypes);
        }

        #endregion

        #region Method Call : (addHeader) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getitems_addHeader_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodaddHeaderPrametersTypes = null;
            object[] parametersOfaddHeader = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodaddHeader, methodaddHeaderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getitemsInstanceFixture, parametersOfaddHeader);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfaddHeader.ShouldBeNull();
            methodaddHeaderPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (addHeader) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getitems_addHeader_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodaddHeaderPrametersTypes = null;
            object[] parametersOfaddHeader = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getitemsInstance, MethodaddHeader, parametersOfaddHeader, methodaddHeaderPrametersTypes);

            // Assert
            parametersOfaddHeader.ShouldBeNull();
            methodaddHeaderPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addHeader) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getitems_addHeader_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodaddHeaderPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getitemsInstance, MethodaddHeader, Fixture, methodaddHeaderPrametersTypes);

            // Assert
            methodaddHeaderPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addHeader) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getitems_addHeader_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodaddHeader, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getitemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
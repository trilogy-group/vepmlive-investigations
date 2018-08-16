using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.SPFields
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SPFields.DaysHoursBreakdownFieldControl" />)
    ///     and namespace <see cref="EPMLiveCore.SPFields"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class DaysHoursBreakdownFieldControlTest : AbstractBaseSetupTypedTest<DaysHoursBreakdownFieldControl>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DaysHoursBreakdownFieldControl) Initializer

        private const string PropertyDefaultTemplateName = "DefaultTemplateName";
        private const string MethodUpdateFieldValueInItem = "UpdateFieldValueInItem";
        private const string MethodCreateChildControls = "CreateChildControls";
        private const string MethodDateChanged = "DateChanged";
        private const string MethodFillGridView = "FillGridView";
        private const string MethodFinishDateTextBoxTextChanged = "FinishDateTextBoxTextChanged";
        private const string MethodGetDatePattern = "GetDatePattern";
        private const string MethodGetHolidays = "GetHolidays";
        private const string MethodGetRequiredLists = "GetRequiredLists";
        private const string MethodGetWorkHours = "GetWorkHours";
        private const string MethodInitializeControls = "InitializeControls";
        private const string MethodLoadBlockedDays = "LoadBlockedDays";
        private const string MethodStartDateTextBoxTextChanged = "StartDateTextBoxTextChanged";
        private const string FieldDAYS_HOURS_BREAKDOWN_SCRIPT = "DAYS_HOURS_BREAKDOWN_SCRIPT";
        private const string Field_finishDateTextBox = "_finishDateTextBox";
        private const string Field_firstLoadTextBox = "_firstLoadTextBox";
        private const string Field_holidayDictionary = "_holidayDictionary";
        private const string Field_postBackMarkerTextBox = "_postBackMarkerTextBox";
        private const string Field_previousHours = "_previousHours";
        private const string Field_spGridView = "_spGridView";
        private const string Field_startDateTextBox = "_startDateTextBox";
        private const string Field_valueTextBox = "_valueTextBox";
        private const string Field_workHoursDictionary = "_workHoursDictionary";
        private Type _daysHoursBreakdownFieldControlInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DaysHoursBreakdownFieldControl _daysHoursBreakdownFieldControlInstance;
        private DaysHoursBreakdownFieldControl _daysHoursBreakdownFieldControlInstanceFixture;

        #region General Initializer : Class (DaysHoursBreakdownFieldControl) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DaysHoursBreakdownFieldControl" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _daysHoursBreakdownFieldControlInstanceType = typeof(DaysHoursBreakdownFieldControl);
            _daysHoursBreakdownFieldControlInstanceFixture = Create(true);
            _daysHoursBreakdownFieldControlInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DaysHoursBreakdownFieldControl)

        #region General Initializer : Class (DaysHoursBreakdownFieldControl) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="DaysHoursBreakdownFieldControl" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodUpdateFieldValueInItem, 0)]
        [TestCase(MethodCreateChildControls, 0)]
        [TestCase(MethodDateChanged, 0)]
        [TestCase(MethodFillGridView, 0)]
        [TestCase(MethodFinishDateTextBoxTextChanged, 0)]
        [TestCase(MethodGetDatePattern, 0)]
        [TestCase(MethodGetHolidays, 0)]
        [TestCase(MethodGetRequiredLists, 0)]
        [TestCase(MethodGetWorkHours, 0)]
        [TestCase(MethodInitializeControls, 0)]
        [TestCase(MethodLoadBlockedDays, 0)]
        [TestCase(MethodStartDateTextBoxTextChanged, 0)]
        public void AUT_DaysHoursBreakdownFieldControl_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_daysHoursBreakdownFieldControlInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DaysHoursBreakdownFieldControl) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DaysHoursBreakdownFieldControl" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyDefaultTemplateName)]
        public void AUT_DaysHoursBreakdownFieldControl_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_daysHoursBreakdownFieldControlInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DaysHoursBreakdownFieldControl) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DaysHoursBreakdownFieldControl" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldDAYS_HOURS_BREAKDOWN_SCRIPT)]
        [TestCase(Field_finishDateTextBox)]
        [TestCase(Field_firstLoadTextBox)]
        [TestCase(Field_holidayDictionary)]
        [TestCase(Field_postBackMarkerTextBox)]
        [TestCase(Field_previousHours)]
        [TestCase(Field_spGridView)]
        [TestCase(Field_startDateTextBox)]
        [TestCase(Field_valueTextBox)]
        [TestCase(Field_workHoursDictionary)]
        public void AUT_DaysHoursBreakdownFieldControl_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_daysHoursBreakdownFieldControlInstanceFixture, 
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
        ///     Class (<see cref="DaysHoursBreakdownFieldControl" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_DaysHoursBreakdownFieldControl_Is_Instance_Present_Test()
        {
            // Assert
            _daysHoursBreakdownFieldControlInstanceType.ShouldNotBeNull();
            _daysHoursBreakdownFieldControlInstance.ShouldNotBeNull();
            _daysHoursBreakdownFieldControlInstanceFixture.ShouldNotBeNull();
            _daysHoursBreakdownFieldControlInstance.ShouldBeAssignableTo<DaysHoursBreakdownFieldControl>();
            _daysHoursBreakdownFieldControlInstanceFixture.ShouldBeAssignableTo<DaysHoursBreakdownFieldControl>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DaysHoursBreakdownFieldControl) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_DaysHoursBreakdownFieldControl_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DaysHoursBreakdownFieldControl instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _daysHoursBreakdownFieldControlInstanceType.ShouldNotBeNull();
            _daysHoursBreakdownFieldControlInstance.ShouldNotBeNull();
            _daysHoursBreakdownFieldControlInstanceFixture.ShouldNotBeNull();
            _daysHoursBreakdownFieldControlInstance.ShouldBeAssignableTo<DaysHoursBreakdownFieldControl>();
            _daysHoursBreakdownFieldControlInstanceFixture.ShouldBeAssignableTo<DaysHoursBreakdownFieldControl>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DaysHoursBreakdownFieldControl) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyDefaultTemplateName)]
        public void AUT_DaysHoursBreakdownFieldControl_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DaysHoursBreakdownFieldControl, T>(_daysHoursBreakdownFieldControlInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DaysHoursBreakdownFieldControl) => Property (DefaultTemplateName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_DaysHoursBreakdownFieldControl_Public_Class_DefaultTemplateName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDefaultTemplateName);

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

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="DaysHoursBreakdownFieldControl" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetRequiredLists)]
        public void AUT_DaysHoursBreakdownFieldControl_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_daysHoursBreakdownFieldControlInstanceFixture,
                                                                              _daysHoursBreakdownFieldControlInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="DaysHoursBreakdownFieldControl" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodUpdateFieldValueInItem)]
        [TestCase(MethodCreateChildControls)]
        [TestCase(MethodDateChanged)]
        [TestCase(MethodFillGridView)]
        [TestCase(MethodFinishDateTextBoxTextChanged)]
        [TestCase(MethodGetDatePattern)]
        [TestCase(MethodGetHolidays)]
        [TestCase(MethodGetWorkHours)]
        [TestCase(MethodInitializeControls)]
        [TestCase(MethodLoadBlockedDays)]
        [TestCase(MethodStartDateTextBoxTextChanged)]
        public void AUT_DaysHoursBreakdownFieldControl_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<DaysHoursBreakdownFieldControl>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (UpdateFieldValueInItem) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DaysHoursBreakdownFieldControl_UpdateFieldValueInItem_Method_Call_Internally(Type[] types)
        {
            var methodUpdateFieldValueInItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_daysHoursBreakdownFieldControlInstance, MethodUpdateFieldValueInItem, Fixture, methodUpdateFieldValueInItemPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateFieldValueInItem) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_UpdateFieldValueInItem_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _daysHoursBreakdownFieldControlInstance.UpdateFieldValueInItem();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateFieldValueInItem) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_UpdateFieldValueInItem_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodUpdateFieldValueInItemPrametersTypes = null;
            object[] parametersOfUpdateFieldValueInItem = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateFieldValueInItem, methodUpdateFieldValueInItemPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_daysHoursBreakdownFieldControlInstanceFixture, parametersOfUpdateFieldValueInItem);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateFieldValueInItem.ShouldBeNull();
            methodUpdateFieldValueInItemPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateFieldValueInItem) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_UpdateFieldValueInItem_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodUpdateFieldValueInItemPrametersTypes = null;
            object[] parametersOfUpdateFieldValueInItem = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_daysHoursBreakdownFieldControlInstance, MethodUpdateFieldValueInItem, parametersOfUpdateFieldValueInItem, methodUpdateFieldValueInItemPrametersTypes);

            // Assert
            parametersOfUpdateFieldValueInItem.ShouldBeNull();
            methodUpdateFieldValueInItemPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateFieldValueInItem) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_UpdateFieldValueInItem_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodUpdateFieldValueInItemPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_daysHoursBreakdownFieldControlInstance, MethodUpdateFieldValueInItem, Fixture, methodUpdateFieldValueInItemPrametersTypes);

            // Assert
            methodUpdateFieldValueInItemPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateFieldValueInItem) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_UpdateFieldValueInItem_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateFieldValueInItem, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_daysHoursBreakdownFieldControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DaysHoursBreakdownFieldControl_CreateChildControls_Method_Call_Internally(Type[] types)
        {
            var methodCreateChildControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_daysHoursBreakdownFieldControlInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, methodCreateChildControlsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_daysHoursBreakdownFieldControlInstanceFixture, parametersOfCreateChildControls);

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
        public void AUT_DaysHoursBreakdownFieldControl_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_daysHoursBreakdownFieldControlInstance, MethodCreateChildControls, parametersOfCreateChildControls, methodCreateChildControlsPrametersTypes);

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
        public void AUT_DaysHoursBreakdownFieldControl_CreateChildControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_daysHoursBreakdownFieldControlInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);

            // Assert
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_CreateChildControls_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_daysHoursBreakdownFieldControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DateChanged) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DaysHoursBreakdownFieldControl_DateChanged_Method_Call_Internally(Type[] types)
        {
            var methodDateChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_daysHoursBreakdownFieldControlInstance, MethodDateChanged, Fixture, methodDateChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (DateChanged) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_DateChanged_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodDateChangedPrametersTypes = null;
            object[] parametersOfDateChanged = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDateChanged, methodDateChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_daysHoursBreakdownFieldControlInstanceFixture, parametersOfDateChanged);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDateChanged.ShouldBeNull();
            methodDateChangedPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DateChanged) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_DateChanged_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodDateChangedPrametersTypes = null;
            object[] parametersOfDateChanged = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_daysHoursBreakdownFieldControlInstance, MethodDateChanged, parametersOfDateChanged, methodDateChangedPrametersTypes);

            // Assert
            parametersOfDateChanged.ShouldBeNull();
            methodDateChangedPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DateChanged) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_DateChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodDateChangedPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_daysHoursBreakdownFieldControlInstance, MethodDateChanged, Fixture, methodDateChangedPrametersTypes);

            // Assert
            methodDateChangedPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DateChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_DateChanged_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDateChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_daysHoursBreakdownFieldControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FillGridView) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DaysHoursBreakdownFieldControl_FillGridView_Method_Call_Internally(Type[] types)
        {
            var methodFillGridViewPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_daysHoursBreakdownFieldControlInstance, MethodFillGridView, Fixture, methodFillGridViewPrametersTypes);
        }

        #endregion

        #region Method Call : (FillGridView) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_FillGridView_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var datePattern = CreateType<string>();
            var methodFillGridViewPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfFillGridView = { datePattern };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodFillGridView, methodFillGridViewPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_daysHoursBreakdownFieldControlInstanceFixture, parametersOfFillGridView);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfFillGridView.ShouldNotBeNull();
            parametersOfFillGridView.Length.ShouldBe(1);
            methodFillGridViewPrametersTypes.Length.ShouldBe(1);
            methodFillGridViewPrametersTypes.Length.ShouldBe(parametersOfFillGridView.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (FillGridView) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_FillGridView_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var datePattern = CreateType<string>();
            var methodFillGridViewPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfFillGridView = { datePattern };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_daysHoursBreakdownFieldControlInstance, MethodFillGridView, parametersOfFillGridView, methodFillGridViewPrametersTypes);

            // Assert
            parametersOfFillGridView.ShouldNotBeNull();
            parametersOfFillGridView.Length.ShouldBe(1);
            methodFillGridViewPrametersTypes.Length.ShouldBe(1);
            methodFillGridViewPrametersTypes.Length.ShouldBe(parametersOfFillGridView.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FillGridView) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_FillGridView_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodFillGridView, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FillGridView) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_FillGridView_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFillGridViewPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_daysHoursBreakdownFieldControlInstance, MethodFillGridView, Fixture, methodFillGridViewPrametersTypes);

            // Assert
            methodFillGridViewPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FillGridView) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_FillGridView_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFillGridView, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_daysHoursBreakdownFieldControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FinishDateTextBoxTextChanged) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DaysHoursBreakdownFieldControl_FinishDateTextBoxTextChanged_Method_Call_Internally(Type[] types)
        {
            var methodFinishDateTextBoxTextChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_daysHoursBreakdownFieldControlInstance, MethodFinishDateTextBoxTextChanged, Fixture, methodFinishDateTextBoxTextChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (FinishDateTextBoxTextChanged) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_FinishDateTextBoxTextChanged_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodFinishDateTextBoxTextChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfFinishDateTextBoxTextChanged = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodFinishDateTextBoxTextChanged, methodFinishDateTextBoxTextChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_daysHoursBreakdownFieldControlInstanceFixture, parametersOfFinishDateTextBoxTextChanged);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfFinishDateTextBoxTextChanged.ShouldNotBeNull();
            parametersOfFinishDateTextBoxTextChanged.Length.ShouldBe(2);
            methodFinishDateTextBoxTextChangedPrametersTypes.Length.ShouldBe(2);
            methodFinishDateTextBoxTextChangedPrametersTypes.Length.ShouldBe(parametersOfFinishDateTextBoxTextChanged.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (FinishDateTextBoxTextChanged) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_FinishDateTextBoxTextChanged_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodFinishDateTextBoxTextChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfFinishDateTextBoxTextChanged = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_daysHoursBreakdownFieldControlInstance, MethodFinishDateTextBoxTextChanged, parametersOfFinishDateTextBoxTextChanged, methodFinishDateTextBoxTextChangedPrametersTypes);

            // Assert
            parametersOfFinishDateTextBoxTextChanged.ShouldNotBeNull();
            parametersOfFinishDateTextBoxTextChanged.Length.ShouldBe(2);
            methodFinishDateTextBoxTextChangedPrametersTypes.Length.ShouldBe(2);
            methodFinishDateTextBoxTextChangedPrametersTypes.Length.ShouldBe(parametersOfFinishDateTextBoxTextChanged.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FinishDateTextBoxTextChanged) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_FinishDateTextBoxTextChanged_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodFinishDateTextBoxTextChanged, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FinishDateTextBoxTextChanged) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_FinishDateTextBoxTextChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFinishDateTextBoxTextChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_daysHoursBreakdownFieldControlInstance, MethodFinishDateTextBoxTextChanged, Fixture, methodFinishDateTextBoxTextChangedPrametersTypes);

            // Assert
            methodFinishDateTextBoxTextChangedPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FinishDateTextBoxTextChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_FinishDateTextBoxTextChanged_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFinishDateTextBoxTextChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_daysHoursBreakdownFieldControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDatePattern) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DaysHoursBreakdownFieldControl_GetDatePattern_Method_Call_Internally(Type[] types)
        {
            var methodGetDatePatternPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_daysHoursBreakdownFieldControlInstance, MethodGetDatePattern, Fixture, methodGetDatePatternPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDatePattern) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_GetDatePattern_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetDatePatternPrametersTypes = null;
            object[] parametersOfGetDatePattern = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDatePattern, methodGetDatePatternPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<DaysHoursBreakdownFieldControl, string>(_daysHoursBreakdownFieldControlInstanceFixture, out exception1, parametersOfGetDatePattern);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<DaysHoursBreakdownFieldControl, string>(_daysHoursBreakdownFieldControlInstance, MethodGetDatePattern, parametersOfGetDatePattern, methodGetDatePatternPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetDatePattern.ShouldBeNull();
            methodGetDatePatternPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDatePattern) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_GetDatePattern_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetDatePatternPrametersTypes = null;
            object[] parametersOfGetDatePattern = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<DaysHoursBreakdownFieldControl, string>(_daysHoursBreakdownFieldControlInstance, MethodGetDatePattern, parametersOfGetDatePattern, methodGetDatePatternPrametersTypes);

            // Assert
            parametersOfGetDatePattern.ShouldBeNull();
            methodGetDatePatternPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDatePattern) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_GetDatePattern_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetDatePatternPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_daysHoursBreakdownFieldControlInstance, MethodGetDatePattern, Fixture, methodGetDatePatternPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDatePatternPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDatePattern) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_GetDatePattern_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetDatePatternPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_daysHoursBreakdownFieldControlInstance, MethodGetDatePattern, Fixture, methodGetDatePatternPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDatePatternPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDatePattern) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_GetDatePattern_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDatePattern, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_daysHoursBreakdownFieldControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetHolidays) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DaysHoursBreakdownFieldControl_GetHolidays_Method_Call_Internally(Type[] types)
        {
            var methodGetHolidaysPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_daysHoursBreakdownFieldControlInstance, MethodGetHolidays, Fixture, methodGetHolidaysPrametersTypes);
        }

        #endregion

        #region Method Call : (GetHolidays) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_GetHolidays_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var holidaysList = CreateType<SPList>();
            var resourceListItem = CreateType<SPListItem>();
            var methodGetHolidaysPrametersTypes = new Type[] { typeof(SPList), typeof(SPListItem) };
            object[] parametersOfGetHolidays = { holidaysList, resourceListItem };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetHolidays, methodGetHolidaysPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_daysHoursBreakdownFieldControlInstanceFixture, parametersOfGetHolidays);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetHolidays.ShouldNotBeNull();
            parametersOfGetHolidays.Length.ShouldBe(2);
            methodGetHolidaysPrametersTypes.Length.ShouldBe(2);
            methodGetHolidaysPrametersTypes.Length.ShouldBe(parametersOfGetHolidays.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetHolidays) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_GetHolidays_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var holidaysList = CreateType<SPList>();
            var resourceListItem = CreateType<SPListItem>();
            var methodGetHolidaysPrametersTypes = new Type[] { typeof(SPList), typeof(SPListItem) };
            object[] parametersOfGetHolidays = { holidaysList, resourceListItem };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_daysHoursBreakdownFieldControlInstance, MethodGetHolidays, parametersOfGetHolidays, methodGetHolidaysPrametersTypes);

            // Assert
            parametersOfGetHolidays.ShouldNotBeNull();
            parametersOfGetHolidays.Length.ShouldBe(2);
            methodGetHolidaysPrametersTypes.Length.ShouldBe(2);
            methodGetHolidaysPrametersTypes.Length.ShouldBe(parametersOfGetHolidays.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetHolidays) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_GetHolidays_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetHolidays, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetHolidays) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_GetHolidays_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetHolidaysPrametersTypes = new Type[] { typeof(SPList), typeof(SPListItem) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_daysHoursBreakdownFieldControlInstance, MethodGetHolidays, Fixture, methodGetHolidaysPrametersTypes);

            // Assert
            methodGetHolidaysPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetHolidays) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_GetHolidays_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetHolidays, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_daysHoursBreakdownFieldControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetRequiredLists) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DaysHoursBreakdownFieldControl_GetRequiredLists_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetRequiredListsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_daysHoursBreakdownFieldControlInstanceFixture, _daysHoursBreakdownFieldControlInstanceType, MethodGetRequiredLists, Fixture, methodGetRequiredListsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetRequiredLists) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_GetRequiredLists_Static_Method_Call_Void_With_6_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var spListCollection = CreateType<SPListCollection>();
            var dhbField = CreateType<DaysHoursBreakdownField>();
            var holidaysList = CreateType<SPList>();
            var holidaySchedulesList = CreateType<SPList>();
            var resourcesList = CreateType<SPList>();
            var workHoursList = CreateType<SPList>();
            var methodGetRequiredListsPrametersTypes = new Type[] { typeof(SPListCollection), typeof(DaysHoursBreakdownField), typeof(SPList), typeof(SPList), typeof(SPList), typeof(SPList) };
            object[] parametersOfGetRequiredLists = { spListCollection, dhbField, holidaysList, holidaySchedulesList, resourcesList, workHoursList };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetRequiredLists, methodGetRequiredListsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_daysHoursBreakdownFieldControlInstanceFixture, parametersOfGetRequiredLists);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetRequiredLists.ShouldNotBeNull();
            parametersOfGetRequiredLists.Length.ShouldBe(6);
            methodGetRequiredListsPrametersTypes.Length.ShouldBe(6);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetRequiredLists) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_GetRequiredLists_Static_Method_Call_Void_With_6_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spListCollection = CreateType<SPListCollection>();
            var dhbField = CreateType<DaysHoursBreakdownField>();
            var holidaysList = CreateType<SPList>();
            var holidaySchedulesList = CreateType<SPList>();
            var resourcesList = CreateType<SPList>();
            var workHoursList = CreateType<SPList>();
            var methodGetRequiredListsPrametersTypes = new Type[] { typeof(SPListCollection), typeof(DaysHoursBreakdownField), typeof(SPList), typeof(SPList), typeof(SPList), typeof(SPList) };
            object[] parametersOfGetRequiredLists = { spListCollection, dhbField, holidaysList, holidaySchedulesList, resourcesList, workHoursList };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_daysHoursBreakdownFieldControlInstanceFixture, _daysHoursBreakdownFieldControlInstanceType, MethodGetRequiredLists, parametersOfGetRequiredLists, methodGetRequiredListsPrametersTypes);

            // Assert
            parametersOfGetRequiredLists.ShouldNotBeNull();
            parametersOfGetRequiredLists.Length.ShouldBe(6);
            methodGetRequiredListsPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetRequiredLists) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_GetRequiredLists_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetRequiredLists, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRequiredLists) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_GetRequiredLists_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetRequiredListsPrametersTypes = new Type[] { typeof(SPListCollection), typeof(DaysHoursBreakdownField), typeof(SPList), typeof(SPList), typeof(SPList), typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_daysHoursBreakdownFieldControlInstanceFixture, _daysHoursBreakdownFieldControlInstanceType, MethodGetRequiredLists, Fixture, methodGetRequiredListsPrametersTypes);

            // Assert
            methodGetRequiredListsPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetRequiredLists) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_GetRequiredLists_Static_Method_Call_With_6_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetRequiredLists, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_daysHoursBreakdownFieldControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetWorkHours) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DaysHoursBreakdownFieldControl_GetWorkHours_Method_Call_Internally(Type[] types)
        {
            var methodGetWorkHoursPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_daysHoursBreakdownFieldControlInstance, MethodGetWorkHours, Fixture, methodGetWorkHoursPrametersTypes);
        }

        #endregion

        #region Method Call : (GetWorkHours) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_GetWorkHours_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var workHoursList = CreateType<SPList>();
            var resourceListItem = CreateType<SPListItem>();
            var spWeb = CreateType<SPWeb>();
            var methodGetWorkHoursPrametersTypes = new Type[] { typeof(SPList), typeof(SPListItem), typeof(SPWeb) };
            object[] parametersOfGetWorkHours = { workHoursList, resourceListItem, spWeb };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetWorkHours, methodGetWorkHoursPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_daysHoursBreakdownFieldControlInstanceFixture, parametersOfGetWorkHours);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetWorkHours.ShouldNotBeNull();
            parametersOfGetWorkHours.Length.ShouldBe(3);
            methodGetWorkHoursPrametersTypes.Length.ShouldBe(3);
            methodGetWorkHoursPrametersTypes.Length.ShouldBe(parametersOfGetWorkHours.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetWorkHours) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_GetWorkHours_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var workHoursList = CreateType<SPList>();
            var resourceListItem = CreateType<SPListItem>();
            var spWeb = CreateType<SPWeb>();
            var methodGetWorkHoursPrametersTypes = new Type[] { typeof(SPList), typeof(SPListItem), typeof(SPWeb) };
            object[] parametersOfGetWorkHours = { workHoursList, resourceListItem, spWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_daysHoursBreakdownFieldControlInstance, MethodGetWorkHours, parametersOfGetWorkHours, methodGetWorkHoursPrametersTypes);

            // Assert
            parametersOfGetWorkHours.ShouldNotBeNull();
            parametersOfGetWorkHours.Length.ShouldBe(3);
            methodGetWorkHoursPrametersTypes.Length.ShouldBe(3);
            methodGetWorkHoursPrametersTypes.Length.ShouldBe(parametersOfGetWorkHours.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetWorkHours) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_GetWorkHours_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetWorkHours, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetWorkHours) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_GetWorkHours_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetWorkHoursPrametersTypes = new Type[] { typeof(SPList), typeof(SPListItem), typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_daysHoursBreakdownFieldControlInstance, MethodGetWorkHours, Fixture, methodGetWorkHoursPrametersTypes);

            // Assert
            methodGetWorkHoursPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetWorkHours) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_GetWorkHours_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetWorkHours, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_daysHoursBreakdownFieldControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializeControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DaysHoursBreakdownFieldControl_InitializeControls_Method_Call_Internally(Type[] types)
        {
            var methodInitializeControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_daysHoursBreakdownFieldControlInstance, MethodInitializeControls, Fixture, methodInitializeControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (InitializeControls) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_InitializeControls_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodInitializeControlsPrametersTypes = null;
            object[] parametersOfInitializeControls = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitializeControls, methodInitializeControlsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_daysHoursBreakdownFieldControlInstanceFixture, parametersOfInitializeControls);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInitializeControls.ShouldBeNull();
            methodInitializeControlsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (InitializeControls) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_InitializeControls_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodInitializeControlsPrametersTypes = null;
            object[] parametersOfInitializeControls = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_daysHoursBreakdownFieldControlInstance, MethodInitializeControls, parametersOfInitializeControls, methodInitializeControlsPrametersTypes);

            // Assert
            parametersOfInitializeControls.ShouldBeNull();
            methodInitializeControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializeControls) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_InitializeControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodInitializeControlsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_daysHoursBreakdownFieldControlInstance, MethodInitializeControls, Fixture, methodInitializeControlsPrametersTypes);

            // Assert
            methodInitializeControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializeControls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_InitializeControls_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitializeControls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_daysHoursBreakdownFieldControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadBlockedDays) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DaysHoursBreakdownFieldControl_LoadBlockedDays_Method_Call_Internally(Type[] types)
        {
            var methodLoadBlockedDaysPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_daysHoursBreakdownFieldControlInstance, MethodLoadBlockedDays, Fixture, methodLoadBlockedDaysPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadBlockedDays) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_LoadBlockedDays_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var dhbField = CreateType<DaysHoursBreakdownField>();
            var methodLoadBlockedDaysPrametersTypes = new Type[] { typeof(DaysHoursBreakdownField) };
            object[] parametersOfLoadBlockedDays = { dhbField };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodLoadBlockedDays, methodLoadBlockedDaysPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_daysHoursBreakdownFieldControlInstanceFixture, parametersOfLoadBlockedDays);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfLoadBlockedDays.ShouldNotBeNull();
            parametersOfLoadBlockedDays.Length.ShouldBe(1);
            methodLoadBlockedDaysPrametersTypes.Length.ShouldBe(1);
            methodLoadBlockedDaysPrametersTypes.Length.ShouldBe(parametersOfLoadBlockedDays.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (LoadBlockedDays) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_LoadBlockedDays_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dhbField = CreateType<DaysHoursBreakdownField>();
            var methodLoadBlockedDaysPrametersTypes = new Type[] { typeof(DaysHoursBreakdownField) };
            object[] parametersOfLoadBlockedDays = { dhbField };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_daysHoursBreakdownFieldControlInstance, MethodLoadBlockedDays, parametersOfLoadBlockedDays, methodLoadBlockedDaysPrametersTypes);

            // Assert
            parametersOfLoadBlockedDays.ShouldNotBeNull();
            parametersOfLoadBlockedDays.Length.ShouldBe(1);
            methodLoadBlockedDaysPrametersTypes.Length.ShouldBe(1);
            methodLoadBlockedDaysPrametersTypes.Length.ShouldBe(parametersOfLoadBlockedDays.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadBlockedDays) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_LoadBlockedDays_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodLoadBlockedDays, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LoadBlockedDays) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_LoadBlockedDays_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLoadBlockedDaysPrametersTypes = new Type[] { typeof(DaysHoursBreakdownField) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_daysHoursBreakdownFieldControlInstance, MethodLoadBlockedDays, Fixture, methodLoadBlockedDaysPrametersTypes);

            // Assert
            methodLoadBlockedDaysPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadBlockedDays) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_LoadBlockedDays_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLoadBlockedDays, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_daysHoursBreakdownFieldControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StartDateTextBoxTextChanged) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DaysHoursBreakdownFieldControl_StartDateTextBoxTextChanged_Method_Call_Internally(Type[] types)
        {
            var methodStartDateTextBoxTextChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_daysHoursBreakdownFieldControlInstance, MethodStartDateTextBoxTextChanged, Fixture, methodStartDateTextBoxTextChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (StartDateTextBoxTextChanged) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_StartDateTextBoxTextChanged_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodStartDateTextBoxTextChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfStartDateTextBoxTextChanged = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodStartDateTextBoxTextChanged, methodStartDateTextBoxTextChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_daysHoursBreakdownFieldControlInstanceFixture, parametersOfStartDateTextBoxTextChanged);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfStartDateTextBoxTextChanged.ShouldNotBeNull();
            parametersOfStartDateTextBoxTextChanged.Length.ShouldBe(2);
            methodStartDateTextBoxTextChangedPrametersTypes.Length.ShouldBe(2);
            methodStartDateTextBoxTextChangedPrametersTypes.Length.ShouldBe(parametersOfStartDateTextBoxTextChanged.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (StartDateTextBoxTextChanged) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_StartDateTextBoxTextChanged_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodStartDateTextBoxTextChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfStartDateTextBoxTextChanged = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_daysHoursBreakdownFieldControlInstance, MethodStartDateTextBoxTextChanged, parametersOfStartDateTextBoxTextChanged, methodStartDateTextBoxTextChangedPrametersTypes);

            // Assert
            parametersOfStartDateTextBoxTextChanged.ShouldNotBeNull();
            parametersOfStartDateTextBoxTextChanged.Length.ShouldBe(2);
            methodStartDateTextBoxTextChangedPrametersTypes.Length.ShouldBe(2);
            methodStartDateTextBoxTextChangedPrametersTypes.Length.ShouldBe(parametersOfStartDateTextBoxTextChanged.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StartDateTextBoxTextChanged) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_StartDateTextBoxTextChanged_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodStartDateTextBoxTextChanged, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (StartDateTextBoxTextChanged) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_StartDateTextBoxTextChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodStartDateTextBoxTextChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_daysHoursBreakdownFieldControlInstance, MethodStartDateTextBoxTextChanged, Fixture, methodStartDateTextBoxTextChangedPrametersTypes);

            // Assert
            methodStartDateTextBoxTextChangedPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StartDateTextBoxTextChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownFieldControl_StartDateTextBoxTextChanged_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodStartDateTextBoxTextChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_daysHoursBreakdownFieldControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
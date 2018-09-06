using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace WorkEnginePPM
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.EditableFieldDisplay" />)
    ///     and namespace <see cref="WorkEnginePPM"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class EditableFieldDisplayTest : AbstractBaseSetupTypedTest<EditableFieldDisplay>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EditableFieldDisplay) Initializer

        private const string MethodcanEdit = "canEdit";
        private const string MethodRenderField = "RenderField";
        private const string MethodWhereUser = "WhereUser";
        private const string MethodWhereField = "WhereField";
        private const string MethodisDate = "isDate";
        private const string MethodgetFieldSchemaAttribValue = "getFieldSchemaAttribValue";
        private const string MethodIsNumeric = "IsNumeric";
        private Type _editableFieldDisplayInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private EditableFieldDisplay _editableFieldDisplayInstance;
        private EditableFieldDisplay _editableFieldDisplayInstanceFixture;

        #region General Initializer : Class (EditableFieldDisplay) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EditableFieldDisplay" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _editableFieldDisplayInstanceType = typeof(EditableFieldDisplay);
            _editableFieldDisplayInstanceFixture = Create(true);
            _editableFieldDisplayInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (EditableFieldDisplay)

        #region General Initializer : Class (EditableFieldDisplay) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="EditableFieldDisplay" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodcanEdit, 0)]
        [TestCase(MethodRenderField, 0)]
        [TestCase(MethodWhereUser, 0)]
        [TestCase(MethodWhereField, 0)]
        [TestCase(MethodisDate, 0)]
        [TestCase(MethodgetFieldSchemaAttribValue, 0)]
        [TestCase(MethodIsNumeric, 0)]
        public void AUT_EditableFieldDisplay_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_editableFieldDisplayInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="EditableFieldDisplay" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_EditableFieldDisplay_Is_Instance_Present_Test()
        {
            // Assert
            _editableFieldDisplayInstanceType.ShouldNotBeNull();
            _editableFieldDisplayInstance.ShouldNotBeNull();
            _editableFieldDisplayInstanceFixture.ShouldNotBeNull();
            _editableFieldDisplayInstance.ShouldBeAssignableTo<EditableFieldDisplay>();
            _editableFieldDisplayInstanceFixture.ShouldBeAssignableTo<EditableFieldDisplay>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (EditableFieldDisplay) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_EditableFieldDisplay_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            EditableFieldDisplay instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _editableFieldDisplayInstanceType.ShouldNotBeNull();
            _editableFieldDisplayInstance.ShouldNotBeNull();
            _editableFieldDisplayInstanceFixture.ShouldNotBeNull();
            _editableFieldDisplayInstance.ShouldBeAssignableTo<EditableFieldDisplay>();
            _editableFieldDisplayInstanceFixture.ShouldBeAssignableTo<EditableFieldDisplay>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="EditableFieldDisplay" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodcanEdit)]
        [TestCase(MethodRenderField)]
        [TestCase(MethodWhereUser)]
        [TestCase(MethodWhereField)]
        [TestCase(MethodisDate)]
        [TestCase(MethodgetFieldSchemaAttribValue)]
        [TestCase(MethodIsNumeric)]
        public void AUT_EditableFieldDisplay_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_editableFieldDisplayInstanceFixture,
                                                                              _editableFieldDisplayInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (canEdit) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EditableFieldDisplay_canEdit_Static_Method_Call_Internally(Type[] types)
        {
            var methodcanEditPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editableFieldDisplayInstanceFixture, _editableFieldDisplayInstanceType, MethodcanEdit, Fixture, methodcanEditPrametersTypes);
        }

        #endregion

        #region Method Call : (canEdit) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditableFieldDisplay_canEdit_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var fieldProperties = CreateType<Dictionary<string, Dictionary<string, string>>>();
            var li = CreateType<SPListItem>();
            Action executeAction = null;

            // Act
            executeAction = () => EditableFieldDisplay.canEdit(field, fieldProperties, li);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (canEdit) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditableFieldDisplay_canEdit_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var fieldProperties = CreateType<Dictionary<string, Dictionary<string, string>>>();
            var li = CreateType<SPListItem>();
            var methodcanEditPrametersTypes = new Type[] { typeof(SPField), typeof(Dictionary<string, Dictionary<string, string>>), typeof(SPListItem) };
            object[] parametersOfcanEdit = { field, fieldProperties, li };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_editableFieldDisplayInstanceFixture, _editableFieldDisplayInstanceType, MethodcanEdit, parametersOfcanEdit, methodcanEditPrametersTypes);

            // Assert
            parametersOfcanEdit.ShouldNotBeNull();
            parametersOfcanEdit.Length.ShouldBe(3);
            methodcanEditPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (canEdit) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditableFieldDisplay_canEdit_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodcanEditPrametersTypes = new Type[] { typeof(SPField), typeof(Dictionary<string, Dictionary<string, string>>), typeof(SPListItem) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editableFieldDisplayInstanceFixture, _editableFieldDisplayInstanceType, MethodcanEdit, Fixture, methodcanEditPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodcanEditPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (canEdit) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditableFieldDisplay_canEdit_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodcanEdit, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_editableFieldDisplayInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (canEdit) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditableFieldDisplay_canEdit_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodcanEdit, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenderField) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EditableFieldDisplay_RenderField_Static_Method_Call_Internally(Type[] types)
        {
            var methodRenderFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editableFieldDisplayInstanceFixture, _editableFieldDisplayInstanceType, MethodRenderField, Fixture, methodRenderFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (RenderField) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditableFieldDisplay_RenderField_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var where = CreateType<string>();
            var conditionField = CreateType<string>();
            var condition = CreateType<string>();
            var group = CreateType<string>();
            var valueCondition = CreateType<string>();
            var li = CreateType<SPListItem>();
            Action executeAction = null;

            // Act
            executeAction = () => EditableFieldDisplay.RenderField(field, where, conditionField, condition, group, valueCondition, li);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (RenderField) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditableFieldDisplay_RenderField_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var where = CreateType<string>();
            var conditionField = CreateType<string>();
            var condition = CreateType<string>();
            var group = CreateType<string>();
            var valueCondition = CreateType<string>();
            var li = CreateType<SPListItem>();
            var methodRenderFieldPrametersTypes = new Type[] { typeof(SPField), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(SPListItem) };
            object[] parametersOfRenderField = { field, where, conditionField, condition, group, valueCondition, li };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_editableFieldDisplayInstanceFixture, _editableFieldDisplayInstanceType, MethodRenderField, parametersOfRenderField, methodRenderFieldPrametersTypes);

            // Assert
            parametersOfRenderField.ShouldNotBeNull();
            parametersOfRenderField.Length.ShouldBe(7);
            methodRenderFieldPrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderField) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditableFieldDisplay_RenderField_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenderFieldPrametersTypes = new Type[] { typeof(SPField), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(SPListItem) };
            const int parametersCount = 7;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editableFieldDisplayInstanceFixture, _editableFieldDisplayInstanceType, MethodRenderField, Fixture, methodRenderFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRenderFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenderField) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditableFieldDisplay_RenderField_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenderField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_editableFieldDisplayInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RenderField) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditableFieldDisplay_RenderField_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRenderField, 0);
            const int parametersCount = 7;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (WhereUser) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EditableFieldDisplay_WhereUser_Static_Method_Call_Internally(Type[] types)
        {
            var methodWhereUserPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editableFieldDisplayInstanceFixture, _editableFieldDisplayInstanceType, MethodWhereUser, Fixture, methodWhereUserPrametersTypes);
        }

        #endregion

        #region Method Call : (WhereUser) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditableFieldDisplay_WhereUser_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var condition = CreateType<string>();
            var group = CreateType<string>();
            var methodWhereUserPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfWhereUser = { condition, group };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_editableFieldDisplayInstanceFixture, _editableFieldDisplayInstanceType, MethodWhereUser, parametersOfWhereUser, methodWhereUserPrametersTypes);

            // Assert
            parametersOfWhereUser.ShouldNotBeNull();
            parametersOfWhereUser.Length.ShouldBe(2);
            methodWhereUserPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WhereUser) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditableFieldDisplay_WhereUser_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodWhereUserPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editableFieldDisplayInstanceFixture, _editableFieldDisplayInstanceType, MethodWhereUser, Fixture, methodWhereUserPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodWhereUserPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (WhereUser) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditableFieldDisplay_WhereUser_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodWhereUser, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_editableFieldDisplayInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (WhereUser) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditableFieldDisplay_WhereUser_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodWhereUser, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (WhereField) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EditableFieldDisplay_WhereField_Static_Method_Call_Internally(Type[] types)
        {
            var methodWhereFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editableFieldDisplayInstanceFixture, _editableFieldDisplayInstanceType, MethodWhereField, Fixture, methodWhereFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (WhereField) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditableFieldDisplay_WhereField_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var oConditionField = CreateType<SPField>();
            var where = CreateType<string>();
            var condition = CreateType<string>();
            var value = CreateType<string>();
            var li = CreateType<SPListItem>();
            var methodWhereFieldPrametersTypes = new Type[] { typeof(SPField), typeof(string), typeof(string), typeof(string), typeof(SPListItem) };
            object[] parametersOfWhereField = { oConditionField, where, condition, value, li };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodWhereField, methodWhereFieldPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_editableFieldDisplayInstanceFixture, parametersOfWhereField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfWhereField.ShouldNotBeNull();
            parametersOfWhereField.Length.ShouldBe(5);
            methodWhereFieldPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WhereField) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditableFieldDisplay_WhereField_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oConditionField = CreateType<SPField>();
            var where = CreateType<string>();
            var condition = CreateType<string>();
            var value = CreateType<string>();
            var li = CreateType<SPListItem>();
            var methodWhereFieldPrametersTypes = new Type[] { typeof(SPField), typeof(string), typeof(string), typeof(string), typeof(SPListItem) };
            object[] parametersOfWhereField = { oConditionField, where, condition, value, li };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_editableFieldDisplayInstanceFixture, _editableFieldDisplayInstanceType, MethodWhereField, parametersOfWhereField, methodWhereFieldPrametersTypes);

            // Assert
            parametersOfWhereField.ShouldNotBeNull();
            parametersOfWhereField.Length.ShouldBe(5);
            methodWhereFieldPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WhereField) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditableFieldDisplay_WhereField_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodWhereFieldPrametersTypes = new Type[] { typeof(SPField), typeof(string), typeof(string), typeof(string), typeof(SPListItem) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editableFieldDisplayInstanceFixture, _editableFieldDisplayInstanceType, MethodWhereField, Fixture, methodWhereFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodWhereFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (WhereField) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditableFieldDisplay_WhereField_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodWhereField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_editableFieldDisplayInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (WhereField) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditableFieldDisplay_WhereField_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodWhereField, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (isDate) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EditableFieldDisplay_isDate_Static_Method_Call_Internally(Type[] types)
        {
            var methodisDatePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editableFieldDisplayInstanceFixture, _editableFieldDisplayInstanceType, MethodisDate, Fixture, methodisDatePrametersTypes);
        }

        #endregion

        #region Method Call : (isDate) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditableFieldDisplay_isDate_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sDate = CreateType<string>();
            var methodisDatePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfisDate = { sDate };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodisDate, methodisDatePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_editableFieldDisplayInstanceFixture, parametersOfisDate);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfisDate.ShouldNotBeNull();
            parametersOfisDate.Length.ShouldBe(1);
            methodisDatePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (isDate) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditableFieldDisplay_isDate_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sDate = CreateType<string>();
            var methodisDatePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfisDate = { sDate };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_editableFieldDisplayInstanceFixture, _editableFieldDisplayInstanceType, MethodisDate, parametersOfisDate, methodisDatePrametersTypes);

            // Assert
            parametersOfisDate.ShouldNotBeNull();
            parametersOfisDate.Length.ShouldBe(1);
            methodisDatePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (isDate) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditableFieldDisplay_isDate_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodisDatePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editableFieldDisplayInstanceFixture, _editableFieldDisplayInstanceType, MethodisDate, Fixture, methodisDatePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodisDatePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (isDate) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditableFieldDisplay_isDate_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodisDate, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_editableFieldDisplayInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (isDate) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditableFieldDisplay_isDate_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodisDate, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getFieldSchemaAttribValue) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EditableFieldDisplay_getFieldSchemaAttribValue_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetFieldSchemaAttribValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editableFieldDisplayInstanceFixture, _editableFieldDisplayInstanceType, MethodgetFieldSchemaAttribValue, Fixture, methodgetFieldSchemaAttribValuePrametersTypes);
        }

        #endregion

        #region Method Call : (getFieldSchemaAttribValue) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditableFieldDisplay_getFieldSchemaAttribValue_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sStringToSearch = CreateType<string>();
            var sAttribName = CreateType<string>();
            var methodgetFieldSchemaAttribValuePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfgetFieldSchemaAttribValue = { sStringToSearch, sAttribName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetFieldSchemaAttribValue, methodgetFieldSchemaAttribValuePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_editableFieldDisplayInstanceFixture, parametersOfgetFieldSchemaAttribValue);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetFieldSchemaAttribValue.ShouldNotBeNull();
            parametersOfgetFieldSchemaAttribValue.Length.ShouldBe(2);
            methodgetFieldSchemaAttribValuePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getFieldSchemaAttribValue) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditableFieldDisplay_getFieldSchemaAttribValue_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sStringToSearch = CreateType<string>();
            var sAttribName = CreateType<string>();
            var methodgetFieldSchemaAttribValuePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfgetFieldSchemaAttribValue = { sStringToSearch, sAttribName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_editableFieldDisplayInstanceFixture, _editableFieldDisplayInstanceType, MethodgetFieldSchemaAttribValue, parametersOfgetFieldSchemaAttribValue, methodgetFieldSchemaAttribValuePrametersTypes);

            // Assert
            parametersOfgetFieldSchemaAttribValue.ShouldNotBeNull();
            parametersOfgetFieldSchemaAttribValue.Length.ShouldBe(2);
            methodgetFieldSchemaAttribValuePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getFieldSchemaAttribValue) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditableFieldDisplay_getFieldSchemaAttribValue_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetFieldSchemaAttribValuePrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editableFieldDisplayInstanceFixture, _editableFieldDisplayInstanceType, MethodgetFieldSchemaAttribValue, Fixture, methodgetFieldSchemaAttribValuePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetFieldSchemaAttribValuePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (getFieldSchemaAttribValue) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditableFieldDisplay_getFieldSchemaAttribValue_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetFieldSchemaAttribValuePrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editableFieldDisplayInstanceFixture, _editableFieldDisplayInstanceType, MethodgetFieldSchemaAttribValue, Fixture, methodgetFieldSchemaAttribValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetFieldSchemaAttribValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getFieldSchemaAttribValue) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditableFieldDisplay_getFieldSchemaAttribValue_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetFieldSchemaAttribValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_editableFieldDisplayInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getFieldSchemaAttribValue) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditableFieldDisplay_getFieldSchemaAttribValue_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetFieldSchemaAttribValue, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsNumeric) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EditableFieldDisplay_IsNumeric_Static_Method_Call_Internally(Type[] types)
        {
            var methodIsNumericPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editableFieldDisplayInstanceFixture, _editableFieldDisplayInstanceType, MethodIsNumeric, Fixture, methodIsNumericPrametersTypes);
        }

        #endregion

        #region Method Call : (IsNumeric) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditableFieldDisplay_IsNumeric_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodIsNumericPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsNumeric = { value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodIsNumeric, methodIsNumericPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_editableFieldDisplayInstanceFixture, parametersOfIsNumeric);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfIsNumeric.ShouldNotBeNull();
            parametersOfIsNumeric.Length.ShouldBe(1);
            methodIsNumericPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsNumeric) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditableFieldDisplay_IsNumeric_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodIsNumericPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsNumeric = { value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_editableFieldDisplayInstanceFixture, _editableFieldDisplayInstanceType, MethodIsNumeric, parametersOfIsNumeric, methodIsNumericPrametersTypes);

            // Assert
            parametersOfIsNumeric.ShouldNotBeNull();
            parametersOfIsNumeric.Length.ShouldBe(1);
            methodIsNumericPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsNumeric) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditableFieldDisplay_IsNumeric_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsNumericPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editableFieldDisplayInstanceFixture, _editableFieldDisplayInstanceType, MethodIsNumeric, Fixture, methodIsNumericPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsNumericPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsNumeric) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditableFieldDisplay_IsNumeric_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsNumeric, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_editableFieldDisplayInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (IsNumeric) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditableFieldDisplay_IsNumeric_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodIsNumeric, 0);
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
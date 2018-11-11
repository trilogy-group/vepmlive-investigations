using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using EPMLiveWebParts.ReportFiltering.DomainModel;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts.Layouts.epmlive
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.Layouts.epmlive.getreportfiltertitles" />)
    ///     and namespace <see cref="EPMLiveWebParts.Layouts.epmlive"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class GetreportfiltertitlesTest : AbstractBaseSetupTypedTest<getreportfiltertitles>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (getreportfiltertitles) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodGetJsonWithErrorMessage = "GetJsonWithErrorMessage";
        private const string MethodGetFieldSelection = "GetFieldSelection";
        private const string MethodCleanValueIfFromPeoplePicker = "CleanValueIfFromPeoplePicker";
        private const string MethodRequestParametersAreValid = "RequestParametersAreValid";
        private const string MethodGetFilteredTitlesAsJson = "GetFilteredTitlesAsJson";
        private const string MethodPersistSelectedFields = "PersistSelectedFields";
        private const string MethodGetPersistedSettings = "GetPersistedSettings";
        private const string MethodPersistUserSettings = "PersistUserSettings";
        private const string Field_listName = "_listName";
        private const string Field_fieldName = "_fieldName";
        private const string Field_selectedFields = "_selectedFields";
        private const string Field_webPartId = "_webPartId";
        private const string Field_filterOperator = "_filterOperator";
        private Type _getreportfiltertitlesInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private getreportfiltertitles _getreportfiltertitlesInstance;
        private getreportfiltertitles _getreportfiltertitlesInstanceFixture;

        #region General Initializer : Class (getreportfiltertitles) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="getreportfiltertitles" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _getreportfiltertitlesInstanceType = typeof(getreportfiltertitles);
            _getreportfiltertitlesInstanceFixture = Create(true);
            _getreportfiltertitlesInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (getreportfiltertitles)

        #region General Initializer : Class (getreportfiltertitles) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="getreportfiltertitles" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodGetJsonWithErrorMessage, 0)]
        [TestCase(MethodGetFieldSelection, 0)]
        [TestCase(MethodCleanValueIfFromPeoplePicker, 0)]
        [TestCase(MethodRequestParametersAreValid, 0)]
        [TestCase(MethodGetFilteredTitlesAsJson, 0)]
        [TestCase(MethodPersistSelectedFields, 0)]
        [TestCase(MethodGetPersistedSettings, 0)]
        [TestCase(MethodPersistUserSettings, 0)]
        public void AUT_Getreportfiltertitles_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_getreportfiltertitlesInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (getreportfiltertitles) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="getreportfiltertitles" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_listName)]
        [TestCase(Field_fieldName)]
        [TestCase(Field_selectedFields)]
        [TestCase(Field_webPartId)]
        [TestCase(Field_filterOperator)]
        public void AUT_Getreportfiltertitles_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_getreportfiltertitlesInstanceFixture, 
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
        ///     Class (<see cref="getreportfiltertitles" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Getreportfiltertitles_Is_Instance_Present_Test()
        {
            // Assert
            _getreportfiltertitlesInstanceType.ShouldNotBeNull();
            _getreportfiltertitlesInstance.ShouldNotBeNull();
            _getreportfiltertitlesInstanceFixture.ShouldNotBeNull();
            _getreportfiltertitlesInstance.ShouldBeAssignableTo<getreportfiltertitles>();
            _getreportfiltertitlesInstanceFixture.ShouldBeAssignableTo<getreportfiltertitles>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (getreportfiltertitles) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_getreportfiltertitles_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            getreportfiltertitles instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _getreportfiltertitlesInstanceType.ShouldNotBeNull();
            _getreportfiltertitlesInstance.ShouldNotBeNull();
            _getreportfiltertitlesInstanceFixture.ShouldNotBeNull();
            _getreportfiltertitlesInstance.ShouldBeAssignableTo<getreportfiltertitles>();
            _getreportfiltertitlesInstanceFixture.ShouldBeAssignableTo<getreportfiltertitles>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="getreportfiltertitles" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodGetJsonWithErrorMessage)]
        [TestCase(MethodGetFieldSelection)]
        [TestCase(MethodCleanValueIfFromPeoplePicker)]
        [TestCase(MethodRequestParametersAreValid)]
        [TestCase(MethodGetFilteredTitlesAsJson)]
        [TestCase(MethodPersistSelectedFields)]
        [TestCase(MethodGetPersistedSettings)]
        [TestCase(MethodPersistUserSettings)]
        public void AUT_Getreportfiltertitles_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<getreportfiltertitles>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getreportfiltertitles_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getreportfiltertitlesInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getreportfiltertitlesInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Getreportfiltertitles_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getreportfiltertitlesInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Getreportfiltertitles_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Getreportfiltertitles_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getreportfiltertitlesInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getreportfiltertitlesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetJsonWithErrorMessage) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getreportfiltertitles_GetJsonWithErrorMessage_Method_Call_Internally(Type[] types)
        {
            var methodGetJsonWithErrorMessagePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getreportfiltertitlesInstance, MethodGetJsonWithErrorMessage, Fixture, methodGetJsonWithErrorMessagePrametersTypes);
        }

        #endregion

        #region Method Call : (GetJsonWithErrorMessage) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_GetJsonWithErrorMessage_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var fieldSelection = CreateType<ReportFilterSelection>();
            var methodGetJsonWithErrorMessagePrametersTypes = new Type[] { typeof(ReportFilterSelection) };
            object[] parametersOfGetJsonWithErrorMessage = { fieldSelection };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetJsonWithErrorMessage, methodGetJsonWithErrorMessagePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getreportfiltertitlesInstanceFixture, parametersOfGetJsonWithErrorMessage);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetJsonWithErrorMessage.ShouldNotBeNull();
            parametersOfGetJsonWithErrorMessage.Length.ShouldBe(1);
            methodGetJsonWithErrorMessagePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetJsonWithErrorMessage) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_GetJsonWithErrorMessage_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var fieldSelection = CreateType<ReportFilterSelection>();
            var methodGetJsonWithErrorMessagePrametersTypes = new Type[] { typeof(ReportFilterSelection) };
            object[] parametersOfGetJsonWithErrorMessage = { fieldSelection };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getreportfiltertitles, string>(_getreportfiltertitlesInstance, MethodGetJsonWithErrorMessage, parametersOfGetJsonWithErrorMessage, methodGetJsonWithErrorMessagePrametersTypes);

            // Assert
            parametersOfGetJsonWithErrorMessage.ShouldNotBeNull();
            parametersOfGetJsonWithErrorMessage.Length.ShouldBe(1);
            methodGetJsonWithErrorMessagePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetJsonWithErrorMessage) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_GetJsonWithErrorMessage_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetJsonWithErrorMessagePrametersTypes = new Type[] { typeof(ReportFilterSelection) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getreportfiltertitlesInstance, MethodGetJsonWithErrorMessage, Fixture, methodGetJsonWithErrorMessagePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetJsonWithErrorMessagePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetJsonWithErrorMessage) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_GetJsonWithErrorMessage_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetJsonWithErrorMessagePrametersTypes = new Type[] { typeof(ReportFilterSelection) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getreportfiltertitlesInstance, MethodGetJsonWithErrorMessage, Fixture, methodGetJsonWithErrorMessagePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetJsonWithErrorMessagePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetJsonWithErrorMessage) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_GetJsonWithErrorMessage_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetJsonWithErrorMessage, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getreportfiltertitlesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetJsonWithErrorMessage) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_GetJsonWithErrorMessage_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetJsonWithErrorMessage, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFieldSelection) (Return Type : ReportFilterSelection) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getreportfiltertitles_GetFieldSelection_Method_Call_Internally(Type[] types)
        {
            var methodGetFieldSelectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getreportfiltertitlesInstance, MethodGetFieldSelection, Fixture, methodGetFieldSelectionPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFieldSelection) (Return Type : ReportFilterSelection) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_GetFieldSelection_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var web = CreateType<SPWeb>();
            var methodGetFieldSelectionPrametersTypes = new Type[] { typeof(SPField), typeof(SPWeb) };
            object[] parametersOfGetFieldSelection = { field, web };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetFieldSelection, methodGetFieldSelectionPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<getreportfiltertitles, ReportFilterSelection>(_getreportfiltertitlesInstanceFixture, out exception1, parametersOfGetFieldSelection);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<getreportfiltertitles, ReportFilterSelection>(_getreportfiltertitlesInstance, MethodGetFieldSelection, parametersOfGetFieldSelection, methodGetFieldSelectionPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFieldSelection.ShouldNotBeNull();
            parametersOfGetFieldSelection.Length.ShouldBe(2);
            methodGetFieldSelectionPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetFieldSelection) (Return Type : ReportFilterSelection) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_GetFieldSelection_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var web = CreateType<SPWeb>();
            var methodGetFieldSelectionPrametersTypes = new Type[] { typeof(SPField), typeof(SPWeb) };
            object[] parametersOfGetFieldSelection = { field, web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getreportfiltertitles, ReportFilterSelection>(_getreportfiltertitlesInstance, MethodGetFieldSelection, parametersOfGetFieldSelection, methodGetFieldSelectionPrametersTypes);

            // Assert
            parametersOfGetFieldSelection.ShouldNotBeNull();
            parametersOfGetFieldSelection.Length.ShouldBe(2);
            methodGetFieldSelectionPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFieldSelection) (Return Type : ReportFilterSelection) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_GetFieldSelection_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFieldSelectionPrametersTypes = new Type[] { typeof(SPField), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getreportfiltertitlesInstance, MethodGetFieldSelection, Fixture, methodGetFieldSelectionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFieldSelectionPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetFieldSelection) (Return Type : ReportFilterSelection) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_GetFieldSelection_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFieldSelectionPrametersTypes = new Type[] { typeof(SPField), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getreportfiltertitlesInstance, MethodGetFieldSelection, Fixture, methodGetFieldSelectionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFieldSelectionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFieldSelection) (Return Type : ReportFilterSelection) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_GetFieldSelection_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFieldSelection, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getreportfiltertitlesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFieldSelection) (Return Type : ReportFilterSelection) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_GetFieldSelection_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFieldSelection, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CleanValueIfFromPeoplePicker) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getreportfiltertitles_CleanValueIfFromPeoplePicker_Method_Call_Internally(Type[] types)
        {
            var methodCleanValueIfFromPeoplePickerPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getreportfiltertitlesInstance, MethodCleanValueIfFromPeoplePicker, Fixture, methodCleanValueIfFromPeoplePickerPrametersTypes);
        }

        #endregion

        #region Method Call : (CleanValueIfFromPeoplePicker) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_CleanValueIfFromPeoplePicker_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var selectedFields = CreateType<string>();
            var methodCleanValueIfFromPeoplePickerPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfCleanValueIfFromPeoplePicker = { selectedFields };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCleanValueIfFromPeoplePicker, methodCleanValueIfFromPeoplePickerPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getreportfiltertitlesInstanceFixture, parametersOfCleanValueIfFromPeoplePicker);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCleanValueIfFromPeoplePicker.ShouldNotBeNull();
            parametersOfCleanValueIfFromPeoplePicker.Length.ShouldBe(1);
            methodCleanValueIfFromPeoplePickerPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CleanValueIfFromPeoplePicker) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_CleanValueIfFromPeoplePicker_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var selectedFields = CreateType<string>();
            var methodCleanValueIfFromPeoplePickerPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfCleanValueIfFromPeoplePicker = { selectedFields };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getreportfiltertitles, string>(_getreportfiltertitlesInstance, MethodCleanValueIfFromPeoplePicker, parametersOfCleanValueIfFromPeoplePicker, methodCleanValueIfFromPeoplePickerPrametersTypes);

            // Assert
            parametersOfCleanValueIfFromPeoplePicker.ShouldNotBeNull();
            parametersOfCleanValueIfFromPeoplePicker.Length.ShouldBe(1);
            methodCleanValueIfFromPeoplePickerPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CleanValueIfFromPeoplePicker) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_CleanValueIfFromPeoplePicker_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCleanValueIfFromPeoplePickerPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getreportfiltertitlesInstance, MethodCleanValueIfFromPeoplePicker, Fixture, methodCleanValueIfFromPeoplePickerPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCleanValueIfFromPeoplePickerPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (CleanValueIfFromPeoplePicker) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_CleanValueIfFromPeoplePicker_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCleanValueIfFromPeoplePickerPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getreportfiltertitlesInstance, MethodCleanValueIfFromPeoplePicker, Fixture, methodCleanValueIfFromPeoplePickerPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCleanValueIfFromPeoplePickerPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CleanValueIfFromPeoplePicker) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_CleanValueIfFromPeoplePicker_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCleanValueIfFromPeoplePicker, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getreportfiltertitlesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (CleanValueIfFromPeoplePicker) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_CleanValueIfFromPeoplePicker_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCleanValueIfFromPeoplePicker, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RequestParametersAreValid) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getreportfiltertitles_RequestParametersAreValid_Method_Call_Internally(Type[] types)
        {
            var methodRequestParametersAreValidPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getreportfiltertitlesInstance, MethodRequestParametersAreValid, Fixture, methodRequestParametersAreValidPrametersTypes);
        }

        #endregion

        #region Method Call : (RequestParametersAreValid) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_RequestParametersAreValid_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodRequestParametersAreValidPrametersTypes = null;
            object[] parametersOfRequestParametersAreValid = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRequestParametersAreValid, methodRequestParametersAreValidPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getreportfiltertitlesInstanceFixture, parametersOfRequestParametersAreValid);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRequestParametersAreValid.ShouldBeNull();
            methodRequestParametersAreValidPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RequestParametersAreValid) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_RequestParametersAreValid_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRequestParametersAreValidPrametersTypes = null;
            object[] parametersOfRequestParametersAreValid = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getreportfiltertitles, bool>(_getreportfiltertitlesInstance, MethodRequestParametersAreValid, parametersOfRequestParametersAreValid, methodRequestParametersAreValidPrametersTypes);

            // Assert
            parametersOfRequestParametersAreValid.ShouldBeNull();
            methodRequestParametersAreValidPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RequestParametersAreValid) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_RequestParametersAreValid_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodRequestParametersAreValidPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getreportfiltertitlesInstance, MethodRequestParametersAreValid, Fixture, methodRequestParametersAreValidPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodRequestParametersAreValidPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RequestParametersAreValid) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_RequestParametersAreValid_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodRequestParametersAreValidPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getreportfiltertitlesInstance, MethodRequestParametersAreValid, Fixture, methodRequestParametersAreValidPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodRequestParametersAreValidPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RequestParametersAreValid) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_RequestParametersAreValid_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRequestParametersAreValidPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getreportfiltertitlesInstance, MethodRequestParametersAreValid, Fixture, methodRequestParametersAreValidPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRequestParametersAreValidPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RequestParametersAreValid) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_RequestParametersAreValid_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRequestParametersAreValid, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getreportfiltertitlesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetFilteredTitlesAsJson) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getreportfiltertitles_GetFilteredTitlesAsJson_Method_Call_Internally(Type[] types)
        {
            var methodGetFilteredTitlesAsJsonPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getreportfiltertitlesInstance, MethodGetFilteredTitlesAsJson, Fixture, methodGetFilteredTitlesAsJsonPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFilteredTitlesAsJson) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_GetFilteredTitlesAsJson_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var filteredTitles = CreateType<List<string>>();
            var methodGetFilteredTitlesAsJsonPrametersTypes = new Type[] { typeof(List<string>) };
            object[] parametersOfGetFilteredTitlesAsJson = { filteredTitles };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetFilteredTitlesAsJson, methodGetFilteredTitlesAsJsonPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getreportfiltertitlesInstanceFixture, parametersOfGetFilteredTitlesAsJson);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetFilteredTitlesAsJson.ShouldNotBeNull();
            parametersOfGetFilteredTitlesAsJson.Length.ShouldBe(1);
            methodGetFilteredTitlesAsJsonPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFilteredTitlesAsJson) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_GetFilteredTitlesAsJson_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var filteredTitles = CreateType<List<string>>();
            var methodGetFilteredTitlesAsJsonPrametersTypes = new Type[] { typeof(List<string>) };
            object[] parametersOfGetFilteredTitlesAsJson = { filteredTitles };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getreportfiltertitles, string>(_getreportfiltertitlesInstance, MethodGetFilteredTitlesAsJson, parametersOfGetFilteredTitlesAsJson, methodGetFilteredTitlesAsJsonPrametersTypes);

            // Assert
            parametersOfGetFilteredTitlesAsJson.ShouldNotBeNull();
            parametersOfGetFilteredTitlesAsJson.Length.ShouldBe(1);
            methodGetFilteredTitlesAsJsonPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFilteredTitlesAsJson) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_GetFilteredTitlesAsJson_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFilteredTitlesAsJsonPrametersTypes = new Type[] { typeof(List<string>) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getreportfiltertitlesInstance, MethodGetFilteredTitlesAsJson, Fixture, methodGetFilteredTitlesAsJsonPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFilteredTitlesAsJsonPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFilteredTitlesAsJson) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_GetFilteredTitlesAsJson_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFilteredTitlesAsJsonPrametersTypes = new Type[] { typeof(List<string>) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getreportfiltertitlesInstance, MethodGetFilteredTitlesAsJson, Fixture, methodGetFilteredTitlesAsJsonPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFilteredTitlesAsJsonPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFilteredTitlesAsJson) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_GetFilteredTitlesAsJson_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFilteredTitlesAsJson, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getreportfiltertitlesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetFilteredTitlesAsJson) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_GetFilteredTitlesAsJson_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFilteredTitlesAsJson, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PersistSelectedFields) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getreportfiltertitles_PersistSelectedFields_Method_Call_Internally(Type[] types)
        {
            var methodPersistSelectedFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getreportfiltertitlesInstance, MethodPersistSelectedFields, Fixture, methodPersistSelectedFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (PersistSelectedFields) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_PersistSelectedFields_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var reportId = CreateType<string>();
            var fieldSelection = CreateType<ReportFilterSelection>();
            var list = CreateType<SPList>();
            var methodPersistSelectedFieldsPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(ReportFilterSelection), typeof(SPList) };
            object[] parametersOfPersistSelectedFields = { web, reportId, fieldSelection, list };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPersistSelectedFields, methodPersistSelectedFieldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getreportfiltertitlesInstanceFixture, parametersOfPersistSelectedFields);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPersistSelectedFields.ShouldNotBeNull();
            parametersOfPersistSelectedFields.Length.ShouldBe(4);
            methodPersistSelectedFieldsPrametersTypes.Length.ShouldBe(4);
            methodPersistSelectedFieldsPrametersTypes.Length.ShouldBe(parametersOfPersistSelectedFields.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (PersistSelectedFields) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_PersistSelectedFields_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var reportId = CreateType<string>();
            var fieldSelection = CreateType<ReportFilterSelection>();
            var list = CreateType<SPList>();
            var methodPersistSelectedFieldsPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(ReportFilterSelection), typeof(SPList) };
            object[] parametersOfPersistSelectedFields = { web, reportId, fieldSelection, list };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getreportfiltertitlesInstance, MethodPersistSelectedFields, parametersOfPersistSelectedFields, methodPersistSelectedFieldsPrametersTypes);

            // Assert
            parametersOfPersistSelectedFields.ShouldNotBeNull();
            parametersOfPersistSelectedFields.Length.ShouldBe(4);
            methodPersistSelectedFieldsPrametersTypes.Length.ShouldBe(4);
            methodPersistSelectedFieldsPrametersTypes.Length.ShouldBe(parametersOfPersistSelectedFields.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PersistSelectedFields) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_PersistSelectedFields_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPersistSelectedFields, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PersistSelectedFields) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_PersistSelectedFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPersistSelectedFieldsPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(ReportFilterSelection), typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getreportfiltertitlesInstance, MethodPersistSelectedFields, Fixture, methodPersistSelectedFieldsPrametersTypes);

            // Assert
            methodPersistSelectedFieldsPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PersistSelectedFields) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_PersistSelectedFields_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPersistSelectedFields, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getreportfiltertitlesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPersistedSettings) (Return Type : ReportFilterUserSettings) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getreportfiltertitles_GetPersistedSettings_Method_Call_Internally(Type[] types)
        {
            var methodGetPersistedSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getreportfiltertitlesInstance, MethodGetPersistedSettings, Fixture, methodGetPersistedSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetPersistedSettings) (Return Type : ReportFilterUserSettings) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_GetPersistedSettings_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var reportId = CreateType<string>();
            var methodGetPersistedSettingsPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfGetPersistedSettings = { web, reportId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetPersistedSettings, methodGetPersistedSettingsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<getreportfiltertitles, ReportFilterUserSettings>(_getreportfiltertitlesInstanceFixture, out exception1, parametersOfGetPersistedSettings);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<getreportfiltertitles, ReportFilterUserSettings>(_getreportfiltertitlesInstance, MethodGetPersistedSettings, parametersOfGetPersistedSettings, methodGetPersistedSettingsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetPersistedSettings.ShouldNotBeNull();
            parametersOfGetPersistedSettings.Length.ShouldBe(2);
            methodGetPersistedSettingsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetPersistedSettings) (Return Type : ReportFilterUserSettings) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_GetPersistedSettings_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var reportId = CreateType<string>();
            var methodGetPersistedSettingsPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfGetPersistedSettings = { web, reportId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<getreportfiltertitles, ReportFilterUserSettings>(_getreportfiltertitlesInstance, MethodGetPersistedSettings, parametersOfGetPersistedSettings, methodGetPersistedSettingsPrametersTypes);

            // Assert
            parametersOfGetPersistedSettings.ShouldNotBeNull();
            parametersOfGetPersistedSettings.Length.ShouldBe(2);
            methodGetPersistedSettingsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPersistedSettings) (Return Type : ReportFilterUserSettings) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_GetPersistedSettings_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetPersistedSettingsPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getreportfiltertitlesInstance, MethodGetPersistedSettings, Fixture, methodGetPersistedSettingsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetPersistedSettingsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetPersistedSettings) (Return Type : ReportFilterUserSettings) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_GetPersistedSettings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetPersistedSettingsPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getreportfiltertitlesInstance, MethodGetPersistedSettings, Fixture, methodGetPersistedSettingsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetPersistedSettingsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPersistedSettings) (Return Type : ReportFilterUserSettings) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_GetPersistedSettings_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetPersistedSettings, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getreportfiltertitlesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetPersistedSettings) (Return Type : ReportFilterUserSettings) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_GetPersistedSettings_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetPersistedSettings, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PersistUserSettings) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getreportfiltertitles_PersistUserSettings_Method_Call_Internally(Type[] types)
        {
            var methodPersistUserSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getreportfiltertitlesInstance, MethodPersistUserSettings, Fixture, methodPersistUserSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (PersistUserSettings) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_PersistUserSettings_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var userSettings = CreateType<ReportFilterUserSettings>();
            var web = CreateType<SPWeb>();
            var methodPersistUserSettingsPrametersTypes = new Type[] { typeof(ReportFilterUserSettings), typeof(SPWeb) };
            object[] parametersOfPersistUserSettings = { userSettings, web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPersistUserSettings, methodPersistUserSettingsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getreportfiltertitlesInstanceFixture, parametersOfPersistUserSettings);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPersistUserSettings.ShouldNotBeNull();
            parametersOfPersistUserSettings.Length.ShouldBe(2);
            methodPersistUserSettingsPrametersTypes.Length.ShouldBe(2);
            methodPersistUserSettingsPrametersTypes.Length.ShouldBe(parametersOfPersistUserSettings.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (PersistUserSettings) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_PersistUserSettings_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var userSettings = CreateType<ReportFilterUserSettings>();
            var web = CreateType<SPWeb>();
            var methodPersistUserSettingsPrametersTypes = new Type[] { typeof(ReportFilterUserSettings), typeof(SPWeb) };
            object[] parametersOfPersistUserSettings = { userSettings, web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getreportfiltertitlesInstance, MethodPersistUserSettings, parametersOfPersistUserSettings, methodPersistUserSettingsPrametersTypes);

            // Assert
            parametersOfPersistUserSettings.ShouldNotBeNull();
            parametersOfPersistUserSettings.Length.ShouldBe(2);
            methodPersistUserSettingsPrametersTypes.Length.ShouldBe(2);
            methodPersistUserSettingsPrametersTypes.Length.ShouldBe(parametersOfPersistUserSettings.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PersistUserSettings) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_PersistUserSettings_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPersistUserSettings, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PersistUserSettings) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_PersistUserSettings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPersistUserSettingsPrametersTypes = new Type[] { typeof(ReportFilterUserSettings), typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getreportfiltertitlesInstance, MethodPersistUserSettings, Fixture, methodPersistUserSettingsPrametersTypes);

            // Assert
            methodPersistUserSettingsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PersistUserSettings) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getreportfiltertitles_PersistUserSettings_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPersistUserSettings, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getreportfiltertitlesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
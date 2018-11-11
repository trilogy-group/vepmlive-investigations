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

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.CreateNewAjaxDataHost" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public partial class CreateNewAjaxDataHostTest : AbstractBaseSetupTypedTest<CreateNewAjaxDataHost>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CreateNewAjaxDataHost) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodBuildListItemHTML = "BuildListItemHTML";
        private const string MethodBuildListSection = "BuildListSection";
        private const string MethodGetCreatableLists = "GetCreatableLists";
        private const string MethodBuildDocumentLibrarySection = "BuildDocumentLibrarySection";
        private const string MethodGetCreatableLibraries = "GetCreatableLibraries";
        private const string MethodGetDefaultFormUrl = "GetDefaultFormUrl";
        private const string MethodTryListSettingByIndex = "TryListSettingByIndex";
        private const string Field_requestUrl = "_requestUrl";
        private const string FieldLIST_ITEM_HTML = "LIST_ITEM_HTML";
        private Type _createNewAjaxDataHostInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CreateNewAjaxDataHost _createNewAjaxDataHostInstance;
        private CreateNewAjaxDataHost _createNewAjaxDataHostInstanceFixture;

        #region General Initializer : Class (CreateNewAjaxDataHost) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CreateNewAjaxDataHost" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _createNewAjaxDataHostInstanceType = typeof(CreateNewAjaxDataHost);
            _createNewAjaxDataHostInstanceFixture = Create(true);
            _createNewAjaxDataHostInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CreateNewAjaxDataHost)

        #region General Initializer : Class (CreateNewAjaxDataHost) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="CreateNewAjaxDataHost" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodBuildListItemHTML, 0)]
        [TestCase(MethodBuildListSection, 0)]
        [TestCase(MethodGetCreatableLists, 0)]
        [TestCase(MethodBuildDocumentLibrarySection, 0)]
        [TestCase(MethodGetCreatableLibraries, 0)]
        [TestCase(MethodGetDefaultFormUrl, 0)]
        [TestCase(MethodTryListSettingByIndex, 0)]
        public void AUT_CreateNewAjaxDataHost_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_createNewAjaxDataHostInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CreateNewAjaxDataHost) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CreateNewAjaxDataHost" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_requestUrl)]
        public void AUT_CreateNewAjaxDataHost_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_createNewAjaxDataHostInstanceFixture, 
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
        ///     Class (<see cref="CreateNewAjaxDataHost" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_CreateNewAjaxDataHost_Is_Instance_Present_Test()
        {
            // Assert
            _createNewAjaxDataHostInstanceType.ShouldNotBeNull();
            _createNewAjaxDataHostInstance.ShouldNotBeNull();
            _createNewAjaxDataHostInstanceFixture.ShouldNotBeNull();
            _createNewAjaxDataHostInstance.ShouldBeAssignableTo<CreateNewAjaxDataHost>();
            _createNewAjaxDataHostInstanceFixture.ShouldBeAssignableTo<CreateNewAjaxDataHost>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CreateNewAjaxDataHost) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_CreateNewAjaxDataHost_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CreateNewAjaxDataHost instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _createNewAjaxDataHostInstanceType.ShouldNotBeNull();
            _createNewAjaxDataHostInstance.ShouldNotBeNull();
            _createNewAjaxDataHostInstanceFixture.ShouldNotBeNull();
            _createNewAjaxDataHostInstance.ShouldBeAssignableTo<CreateNewAjaxDataHost>();
            _createNewAjaxDataHostInstanceFixture.ShouldBeAssignableTo<CreateNewAjaxDataHost>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="CreateNewAjaxDataHost" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetCreatableLists)]
        [TestCase(MethodGetCreatableLibraries)]
        [TestCase(MethodGetDefaultFormUrl)]
        public void AUT_CreateNewAjaxDataHost_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_createNewAjaxDataHostInstanceFixture,
                                                                              _createNewAjaxDataHostInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="CreateNewAjaxDataHost" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodBuildListItemHTML)]
        [TestCase(MethodBuildListSection)]
        [TestCase(MethodBuildDocumentLibrarySection)]
        [TestCase(MethodTryListSettingByIndex)]
        public void AUT_CreateNewAjaxDataHost_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<CreateNewAjaxDataHost>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CreateNewAjaxDataHost_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createNewAjaxDataHostInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewAjaxDataHost_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_createNewAjaxDataHostInstanceFixture, parametersOfPage_Load);

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
        public void AUT_CreateNewAjaxDataHost_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_createNewAjaxDataHostInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_CreateNewAjaxDataHost_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_CreateNewAjaxDataHost_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createNewAjaxDataHostInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewAjaxDataHost_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_createNewAjaxDataHostInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildListItemHTML) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CreateNewAjaxDataHost_BuildListItemHTML_Method_Call_Internally(Type[] types)
        {
            var methodBuildListItemHTMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createNewAjaxDataHostInstance, MethodBuildListItemHTML, Fixture, methodBuildListItemHTMLPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildListItemHTML) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewAjaxDataHost_BuildListItemHTML_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodBuildListItemHTMLPrametersTypes = null;
            object[] parametersOfBuildListItemHTML = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodBuildListItemHTML, methodBuildListItemHTMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CreateNewAjaxDataHost, string>(_createNewAjaxDataHostInstanceFixture, out exception1, parametersOfBuildListItemHTML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CreateNewAjaxDataHost, string>(_createNewAjaxDataHostInstance, MethodBuildListItemHTML, parametersOfBuildListItemHTML, methodBuildListItemHTMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfBuildListItemHTML.ShouldBeNull();
            methodBuildListItemHTMLPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(() => methodInfo.Invoke(_createNewAjaxDataHostInstanceFixture, parametersOfBuildListItemHTML));
        }

        #endregion

        #region Method Call : (BuildListItemHTML) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewAjaxDataHost_BuildListItemHTML_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodBuildListItemHTMLPrametersTypes = null;
            object[] parametersOfBuildListItemHTML = null; // no parameter present

            // Assert
            parametersOfBuildListItemHTML.ShouldBeNull();
            methodBuildListItemHTMLPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<CreateNewAjaxDataHost, string>(_createNewAjaxDataHostInstance, MethodBuildListItemHTML, parametersOfBuildListItemHTML, methodBuildListItemHTMLPrametersTypes));
        }

        #endregion

        #region Method Call : (BuildListItemHTML) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewAjaxDataHost_BuildListItemHTML_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodBuildListItemHTMLPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createNewAjaxDataHostInstance, MethodBuildListItemHTML, Fixture, methodBuildListItemHTMLPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodBuildListItemHTMLPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BuildListItemHTML) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewAjaxDataHost_BuildListItemHTML_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodBuildListItemHTMLPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createNewAjaxDataHostInstance, MethodBuildListItemHTML, Fixture, methodBuildListItemHTMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildListItemHTMLPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BuildListItemHTML) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewAjaxDataHost_BuildListItemHTML_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildListItemHTML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_createNewAjaxDataHostInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BuildListSection) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CreateNewAjaxDataHost_BuildListSection_Method_Call_Internally(Type[] types)
        {
            var methodBuildListSectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createNewAjaxDataHostInstance, MethodBuildListSection, Fixture, methodBuildListSectionPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildListSection) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewAjaxDataHost_BuildListSection_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodBuildListSectionPrametersTypes = null;
            object[] parametersOfBuildListSection = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodBuildListSection, methodBuildListSectionPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CreateNewAjaxDataHost, string>(_createNewAjaxDataHostInstanceFixture, out exception1, parametersOfBuildListSection);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CreateNewAjaxDataHost, string>(_createNewAjaxDataHostInstance, MethodBuildListSection, parametersOfBuildListSection, methodBuildListSectionPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfBuildListSection.ShouldBeNull();
            methodBuildListSectionPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(() => methodInfo.Invoke(_createNewAjaxDataHostInstanceFixture, parametersOfBuildListSection));
        }

        #endregion

        #region Method Call : (BuildListSection) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewAjaxDataHost_BuildListSection_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodBuildListSectionPrametersTypes = null;
            object[] parametersOfBuildListSection = null; // no parameter present

            // Assert
            parametersOfBuildListSection.ShouldBeNull();
            methodBuildListSectionPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<CreateNewAjaxDataHost, string>(_createNewAjaxDataHostInstance, MethodBuildListSection, parametersOfBuildListSection, methodBuildListSectionPrametersTypes));
        }

        #endregion

        #region Method Call : (BuildListSection) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewAjaxDataHost_BuildListSection_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodBuildListSectionPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createNewAjaxDataHostInstance, MethodBuildListSection, Fixture, methodBuildListSectionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodBuildListSectionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BuildListSection) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewAjaxDataHost_BuildListSection_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodBuildListSectionPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createNewAjaxDataHostInstance, MethodBuildListSection, Fixture, methodBuildListSectionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildListSectionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BuildListSection) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewAjaxDataHost_BuildListSection_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildListSection, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_createNewAjaxDataHostInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCreatableLists) (Return Type : Dictionary<int, string[]>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CreateNewAjaxDataHost_GetCreatableLists_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetCreatableListsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_createNewAjaxDataHostInstanceFixture, _createNewAjaxDataHostInstanceType, MethodGetCreatableLists, Fixture, methodGetCreatableListsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCreatableLists) (Return Type : Dictionary<int, string[]>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewAjaxDataHost_GetCreatableLists_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var cWeb = CreateType<SPWeb>();
            var requestUrl = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => CreateNewAjaxDataHost.GetCreatableLists(cWeb, requestUrl);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetCreatableLists) (Return Type : Dictionary<int, string[]>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewAjaxDataHost_GetCreatableLists_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var cWeb = CreateType<SPWeb>();
            var requestUrl = CreateType<string>();
            var methodGetCreatableListsPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfGetCreatableLists = { cWeb, requestUrl };

            // Assert
            parametersOfGetCreatableLists.ShouldNotBeNull();
            parametersOfGetCreatableLists.Length.ShouldBe(2);
            methodGetCreatableListsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<int, string[]>>(_createNewAjaxDataHostInstanceFixture, _createNewAjaxDataHostInstanceType, MethodGetCreatableLists, parametersOfGetCreatableLists, methodGetCreatableListsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetCreatableLists) (Return Type : Dictionary<int, string[]>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewAjaxDataHost_GetCreatableLists_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCreatableListsPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_createNewAjaxDataHostInstanceFixture, _createNewAjaxDataHostInstanceType, MethodGetCreatableLists, Fixture, methodGetCreatableListsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCreatableListsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCreatableLists) (Return Type : Dictionary<int, string[]>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewAjaxDataHost_GetCreatableLists_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCreatableLists, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_createNewAjaxDataHostInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCreatableLists) (Return Type : Dictionary<int, string[]>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewAjaxDataHost_GetCreatableLists_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCreatableLists, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildDocumentLibrarySection) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CreateNewAjaxDataHost_BuildDocumentLibrarySection_Method_Call_Internally(Type[] types)
        {
            var methodBuildDocumentLibrarySectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createNewAjaxDataHostInstance, MethodBuildDocumentLibrarySection, Fixture, methodBuildDocumentLibrarySectionPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildDocumentLibrarySection) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewAjaxDataHost_BuildDocumentLibrarySection_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodBuildDocumentLibrarySectionPrametersTypes = null;
            object[] parametersOfBuildDocumentLibrarySection = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodBuildDocumentLibrarySection, methodBuildDocumentLibrarySectionPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CreateNewAjaxDataHost, string>(_createNewAjaxDataHostInstanceFixture, out exception1, parametersOfBuildDocumentLibrarySection);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CreateNewAjaxDataHost, string>(_createNewAjaxDataHostInstance, MethodBuildDocumentLibrarySection, parametersOfBuildDocumentLibrarySection, methodBuildDocumentLibrarySectionPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfBuildDocumentLibrarySection.ShouldBeNull();
            methodBuildDocumentLibrarySectionPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(() => methodInfo.Invoke(_createNewAjaxDataHostInstanceFixture, parametersOfBuildDocumentLibrarySection));
        }

        #endregion

        #region Method Call : (BuildDocumentLibrarySection) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewAjaxDataHost_BuildDocumentLibrarySection_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodBuildDocumentLibrarySectionPrametersTypes = null;
            object[] parametersOfBuildDocumentLibrarySection = null; // no parameter present

            // Assert
            parametersOfBuildDocumentLibrarySection.ShouldBeNull();
            methodBuildDocumentLibrarySectionPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<CreateNewAjaxDataHost, string>(_createNewAjaxDataHostInstance, MethodBuildDocumentLibrarySection, parametersOfBuildDocumentLibrarySection, methodBuildDocumentLibrarySectionPrametersTypes));
        }

        #endregion

        #region Method Call : (BuildDocumentLibrarySection) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewAjaxDataHost_BuildDocumentLibrarySection_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodBuildDocumentLibrarySectionPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createNewAjaxDataHostInstance, MethodBuildDocumentLibrarySection, Fixture, methodBuildDocumentLibrarySectionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodBuildDocumentLibrarySectionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BuildDocumentLibrarySection) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewAjaxDataHost_BuildDocumentLibrarySection_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodBuildDocumentLibrarySectionPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createNewAjaxDataHostInstance, MethodBuildDocumentLibrarySection, Fixture, methodBuildDocumentLibrarySectionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildDocumentLibrarySectionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BuildDocumentLibrarySection) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewAjaxDataHost_BuildDocumentLibrarySection_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildDocumentLibrarySection, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_createNewAjaxDataHostInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCreatableLibraries) (Return Type : Dictionary<int, string[]>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CreateNewAjaxDataHost_GetCreatableLibraries_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetCreatableLibrariesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_createNewAjaxDataHostInstanceFixture, _createNewAjaxDataHostInstanceType, MethodGetCreatableLibraries, Fixture, methodGetCreatableLibrariesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCreatableLibraries) (Return Type : Dictionary<int, string[]>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewAjaxDataHost_GetCreatableLibraries_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var cWeb = CreateType<SPWeb>();
            var requestUrl = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => CreateNewAjaxDataHost.GetCreatableLibraries(cWeb, requestUrl);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetCreatableLibraries) (Return Type : Dictionary<int, string[]>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewAjaxDataHost_GetCreatableLibraries_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var cWeb = CreateType<SPWeb>();
            var requestUrl = CreateType<string>();
            var methodGetCreatableLibrariesPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfGetCreatableLibraries = { cWeb, requestUrl };

            // Assert
            parametersOfGetCreatableLibraries.ShouldNotBeNull();
            parametersOfGetCreatableLibraries.Length.ShouldBe(2);
            methodGetCreatableLibrariesPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<int, string[]>>(_createNewAjaxDataHostInstanceFixture, _createNewAjaxDataHostInstanceType, MethodGetCreatableLibraries, parametersOfGetCreatableLibraries, methodGetCreatableLibrariesPrametersTypes));
        }

        #endregion

        #region Method Call : (GetCreatableLibraries) (Return Type : Dictionary<int, string[]>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewAjaxDataHost_GetCreatableLibraries_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCreatableLibrariesPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_createNewAjaxDataHostInstanceFixture, _createNewAjaxDataHostInstanceType, MethodGetCreatableLibraries, Fixture, methodGetCreatableLibrariesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCreatableLibrariesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCreatableLibraries) (Return Type : Dictionary<int, string[]>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewAjaxDataHost_GetCreatableLibraries_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCreatableLibraries, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_createNewAjaxDataHostInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCreatableLibraries) (Return Type : Dictionary<int, string[]>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewAjaxDataHost_GetCreatableLibraries_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCreatableLibraries, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDefaultFormUrl) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CreateNewAjaxDataHost_GetDefaultFormUrl_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetDefaultFormUrlPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_createNewAjaxDataHostInstanceFixture, _createNewAjaxDataHostInstanceType, MethodGetDefaultFormUrl, Fixture, methodGetDefaultFormUrlPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDefaultFormUrl) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewAjaxDataHost_GetDefaultFormUrl_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var requestUrl = CreateType<string>();
            var methodGetDefaultFormUrlPrametersTypes = new Type[] { typeof(SPList), typeof(string) };
            object[] parametersOfGetDefaultFormUrl = { list, requestUrl };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDefaultFormUrl, methodGetDefaultFormUrlPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_createNewAjaxDataHostInstanceFixture, _createNewAjaxDataHostInstanceType, MethodGetDefaultFormUrl, Fixture, methodGetDefaultFormUrlPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_createNewAjaxDataHostInstanceFixture, _createNewAjaxDataHostInstanceType, MethodGetDefaultFormUrl, parametersOfGetDefaultFormUrl, methodGetDefaultFormUrlPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_createNewAjaxDataHostInstanceFixture, parametersOfGetDefaultFormUrl);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetDefaultFormUrl.ShouldNotBeNull();
            parametersOfGetDefaultFormUrl.Length.ShouldBe(2);
            methodGetDefaultFormUrlPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetDefaultFormUrl) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewAjaxDataHost_GetDefaultFormUrl_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var requestUrl = CreateType<string>();
            var methodGetDefaultFormUrlPrametersTypes = new Type[] { typeof(SPList), typeof(string) };
            object[] parametersOfGetDefaultFormUrl = { list, requestUrl };

            // Assert
            parametersOfGetDefaultFormUrl.ShouldNotBeNull();
            parametersOfGetDefaultFormUrl.Length.ShouldBe(2);
            methodGetDefaultFormUrlPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_createNewAjaxDataHostInstanceFixture, _createNewAjaxDataHostInstanceType, MethodGetDefaultFormUrl, parametersOfGetDefaultFormUrl, methodGetDefaultFormUrlPrametersTypes));
        }

        #endregion

        #region Method Call : (GetDefaultFormUrl) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewAjaxDataHost_GetDefaultFormUrl_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetDefaultFormUrlPrametersTypes = new Type[] { typeof(SPList), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_createNewAjaxDataHostInstanceFixture, _createNewAjaxDataHostInstanceType, MethodGetDefaultFormUrl, Fixture, methodGetDefaultFormUrlPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDefaultFormUrlPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetDefaultFormUrl) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewAjaxDataHost_GetDefaultFormUrl_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDefaultFormUrlPrametersTypes = new Type[] { typeof(SPList), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_createNewAjaxDataHostInstanceFixture, _createNewAjaxDataHostInstanceType, MethodGetDefaultFormUrl, Fixture, methodGetDefaultFormUrlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDefaultFormUrlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDefaultFormUrl) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewAjaxDataHost_GetDefaultFormUrl_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDefaultFormUrl, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_createNewAjaxDataHostInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDefaultFormUrl) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewAjaxDataHost_GetDefaultFormUrl_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetDefaultFormUrl, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TryListSettingByIndex) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CreateNewAjaxDataHost_TryListSettingByIndex_Method_Call_Internally(Type[] types)
        {
            var methodTryListSettingByIndexPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createNewAjaxDataHostInstance, MethodTryListSettingByIndex, Fixture, methodTryListSettingByIndexPrametersTypes);
        }

        #endregion

        #region Method Call : (TryListSettingByIndex) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewAjaxDataHost_TryListSettingByIndex_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var properties = CreateType<string>();
            var propIndex = CreateType<int>();
            var returnVal = CreateType<string>();
            var methodTryListSettingByIndexPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(string) };
            object[] parametersOfTryListSettingByIndex = { properties, propIndex, returnVal };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodTryListSettingByIndex, methodTryListSettingByIndexPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CreateNewAjaxDataHost, bool>(_createNewAjaxDataHostInstanceFixture, out exception1, parametersOfTryListSettingByIndex);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CreateNewAjaxDataHost, bool>(_createNewAjaxDataHostInstance, MethodTryListSettingByIndex, parametersOfTryListSettingByIndex, methodTryListSettingByIndexPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfTryListSettingByIndex.ShouldNotBeNull();
            parametersOfTryListSettingByIndex.Length.ShouldBe(3);
            methodTryListSettingByIndexPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<CreateNewAjaxDataHost, bool>(_createNewAjaxDataHostInstance, MethodTryListSettingByIndex, parametersOfTryListSettingByIndex, methodTryListSettingByIndexPrametersTypes));
        }

        #endregion

        #region Method Call : (TryListSettingByIndex) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewAjaxDataHost_TryListSettingByIndex_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<string>();
            var propIndex = CreateType<int>();
            var returnVal = CreateType<string>();
            var methodTryListSettingByIndexPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(string) };
            object[] parametersOfTryListSettingByIndex = { properties, propIndex, returnVal };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodTryListSettingByIndex, methodTryListSettingByIndexPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfTryListSettingByIndex.ShouldNotBeNull();
            parametersOfTryListSettingByIndex.Length.ShouldBe(3);
            methodTryListSettingByIndexPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => methodInfo.Invoke(_createNewAjaxDataHostInstanceFixture, parametersOfTryListSettingByIndex));
        }

        #endregion

        #region Method Call : (TryListSettingByIndex) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewAjaxDataHost_TryListSettingByIndex_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<string>();
            var propIndex = CreateType<int>();
            var returnVal = CreateType<string>();
            var methodTryListSettingByIndexPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(string) };
            object[] parametersOfTryListSettingByIndex = { properties, propIndex, returnVal };

            // Assert
            parametersOfTryListSettingByIndex.ShouldNotBeNull();
            parametersOfTryListSettingByIndex.Length.ShouldBe(3);
            methodTryListSettingByIndexPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<CreateNewAjaxDataHost, bool>(_createNewAjaxDataHostInstance, MethodTryListSettingByIndex, parametersOfTryListSettingByIndex, methodTryListSettingByIndexPrametersTypes));
        }

        #endregion

        #region Method Call : (TryListSettingByIndex) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewAjaxDataHost_TryListSettingByIndex_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodTryListSettingByIndexPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createNewAjaxDataHostInstance, MethodTryListSettingByIndex, Fixture, methodTryListSettingByIndexPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodTryListSettingByIndexPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TryListSettingByIndex) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewAjaxDataHost_TryListSettingByIndex_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodTryListSettingByIndex, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_createNewAjaxDataHostInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (TryListSettingByIndex) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewAjaxDataHost_TryListSettingByIndex_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodTryListSettingByIndex, 0);
            const int parametersCount = 3;

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
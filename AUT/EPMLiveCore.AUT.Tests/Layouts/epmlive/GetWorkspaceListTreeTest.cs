using System;
using System.Collections.Generic;
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

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.GetWorkspaceListTree" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class GetWorkspaceListTreeTest : AbstractBaseSetupTypedTest<GetWorkspaceListTree>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (GetWorkspaceListTree) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodaddWebs = "addWebs";
        private const string MethodValidateUserAccess = "ValidateUserAccess";
        private const string Fielddoc = "doc";
        private const string Fielddata = "data";
        private const string Field_unelevatedSite = "_unelevatedSite";
        private const string Field_unelevatedWeb = "_unelevatedWeb";
        private const string Field_exec = "_exec";
        private const string Field_strSite = "_strSite";
        private Type _getWorkspaceListTreeInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private GetWorkspaceListTree _getWorkspaceListTreeInstance;
        private GetWorkspaceListTree _getWorkspaceListTreeInstanceFixture;

        #region General Initializer : Class (GetWorkspaceListTree) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="GetWorkspaceListTree" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _getWorkspaceListTreeInstanceType = typeof(GetWorkspaceListTree);
            _getWorkspaceListTreeInstanceFixture = Create(true);
            _getWorkspaceListTreeInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (GetWorkspaceListTree)

        #region General Initializer : Class (GetWorkspaceListTree) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="GetWorkspaceListTree" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodaddWebs, 0)]
        [TestCase(MethodValidateUserAccess, 0)]
        public void AUT_GetWorkspaceListTree_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_getWorkspaceListTreeInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (GetWorkspaceListTree) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="GetWorkspaceListTree" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fielddoc)]
        [TestCase(Fielddata)]
        [TestCase(Field_unelevatedSite)]
        [TestCase(Field_unelevatedWeb)]
        [TestCase(Field_exec)]
        [TestCase(Field_strSite)]
        public void AUT_GetWorkspaceListTree_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_getWorkspaceListTreeInstanceFixture, 
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
        ///     Class (<see cref="GetWorkspaceListTree" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_GetWorkspaceListTree_Is_Instance_Present_Test()
        {
            // Assert
            _getWorkspaceListTreeInstanceType.ShouldNotBeNull();
            _getWorkspaceListTreeInstance.ShouldNotBeNull();
            _getWorkspaceListTreeInstanceFixture.ShouldNotBeNull();
            _getWorkspaceListTreeInstance.ShouldBeAssignableTo<GetWorkspaceListTree>();
            _getWorkspaceListTreeInstanceFixture.ShouldBeAssignableTo<GetWorkspaceListTree>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (GetWorkspaceListTree) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_GetWorkspaceListTree_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            GetWorkspaceListTree instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _getWorkspaceListTreeInstanceType.ShouldNotBeNull();
            _getWorkspaceListTreeInstance.ShouldNotBeNull();
            _getWorkspaceListTreeInstanceFixture.ShouldNotBeNull();
            _getWorkspaceListTreeInstance.ShouldBeAssignableTo<GetWorkspaceListTree>();
            _getWorkspaceListTreeInstanceFixture.ShouldBeAssignableTo<GetWorkspaceListTree>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="GetWorkspaceListTree" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodaddWebs)]
        [TestCase(MethodValidateUserAccess)]
        public void AUT_GetWorkspaceListTree_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<GetWorkspaceListTree>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GetWorkspaceListTree_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getWorkspaceListTreeInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GetWorkspaceListTree_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getWorkspaceListTreeInstanceFixture, parametersOfPage_Load);

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
        public void AUT_GetWorkspaceListTree_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getWorkspaceListTreeInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_GetWorkspaceListTree_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_GetWorkspaceListTree_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getWorkspaceListTreeInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GetWorkspaceListTree_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getWorkspaceListTreeInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addWebs) (Return Type : List<XmlNode>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GetWorkspaceListTree_addWebs_Method_Call_Internally(Type[] types)
        {
            var methodaddWebsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getWorkspaceListTreeInstance, MethodaddWebs, Fixture, methodaddWebsPrametersTypes);
        }

        #endregion

        #region Method Call : (addWebs) (Return Type : List<XmlNode>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GetWorkspaceListTree_addWebs_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var parentNode = CreateType<XmlNode>();
            var methodaddWebsPrametersTypes = new Type[] { typeof(SPWeb), typeof(XmlNode) };
            object[] parametersOfaddWebs = { web, parentNode };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodaddWebs, methodaddWebsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GetWorkspaceListTree, List<XmlNode>>(_getWorkspaceListTreeInstanceFixture, out exception1, parametersOfaddWebs);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GetWorkspaceListTree, List<XmlNode>>(_getWorkspaceListTreeInstance, MethodaddWebs, parametersOfaddWebs, methodaddWebsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfaddWebs.ShouldNotBeNull();
            parametersOfaddWebs.Length.ShouldBe(2);
            methodaddWebsPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(() => methodInfo.Invoke(_getWorkspaceListTreeInstanceFixture, parametersOfaddWebs));
        }

        #endregion

        #region Method Call : (addWebs) (Return Type : List<XmlNode>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GetWorkspaceListTree_addWebs_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var parentNode = CreateType<XmlNode>();
            var methodaddWebsPrametersTypes = new Type[] { typeof(SPWeb), typeof(XmlNode) };
            object[] parametersOfaddWebs = { web, parentNode };

            // Assert
            parametersOfaddWebs.ShouldNotBeNull();
            parametersOfaddWebs.Length.ShouldBe(2);
            methodaddWebsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<GetWorkspaceListTree, List<XmlNode>>(_getWorkspaceListTreeInstance, MethodaddWebs, parametersOfaddWebs, methodaddWebsPrametersTypes));
        }

        #endregion

        #region Method Call : (addWebs) (Return Type : List<XmlNode>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GetWorkspaceListTree_addWebs_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodaddWebsPrametersTypes = new Type[] { typeof(SPWeb), typeof(XmlNode) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getWorkspaceListTreeInstance, MethodaddWebs, Fixture, methodaddWebsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodaddWebsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (addWebs) (Return Type : List<XmlNode>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GetWorkspaceListTree_addWebs_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodaddWebsPrametersTypes = new Type[] { typeof(SPWeb), typeof(XmlNode) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getWorkspaceListTreeInstance, MethodaddWebs, Fixture, methodaddWebsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodaddWebsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addWebs) (Return Type : List<XmlNode>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GetWorkspaceListTree_addWebs_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodaddWebs, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getWorkspaceListTreeInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (addWebs) (Return Type : List<XmlNode>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GetWorkspaceListTree_addWebs_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodaddWebs, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ValidateUserAccess) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GetWorkspaceListTree_ValidateUserAccess_Method_Call_Internally(Type[] types)
        {
            var methodValidateUserAccessPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getWorkspaceListTreeInstance, MethodValidateUserAccess, Fixture, methodValidateUserAccessPrametersTypes);
        }

        #endregion

        #region Method Call : (ValidateUserAccess) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GetWorkspaceListTree_ValidateUserAccess_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var user = CreateType<SPUser>();
            var web = CreateType<SPWeb>();
            var methodValidateUserAccessPrametersTypes = new Type[] { typeof(SPUser), typeof(SPWeb) };
            object[] parametersOfValidateUserAccess = { user, web };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodValidateUserAccess, methodValidateUserAccessPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GetWorkspaceListTree, bool>(_getWorkspaceListTreeInstanceFixture, out exception1, parametersOfValidateUserAccess);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GetWorkspaceListTree, bool>(_getWorkspaceListTreeInstance, MethodValidateUserAccess, parametersOfValidateUserAccess, methodValidateUserAccessPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfValidateUserAccess.ShouldNotBeNull();
            parametersOfValidateUserAccess.Length.ShouldBe(2);
            methodValidateUserAccessPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(() => methodInfo.Invoke(_getWorkspaceListTreeInstanceFixture, parametersOfValidateUserAccess));
        }

        #endregion

        #region Method Call : (ValidateUserAccess) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GetWorkspaceListTree_ValidateUserAccess_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var user = CreateType<SPUser>();
            var web = CreateType<SPWeb>();
            var methodValidateUserAccessPrametersTypes = new Type[] { typeof(SPUser), typeof(SPWeb) };
            object[] parametersOfValidateUserAccess = { user, web };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodValidateUserAccess, methodValidateUserAccessPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GetWorkspaceListTree, bool>(_getWorkspaceListTreeInstanceFixture, out exception1, parametersOfValidateUserAccess);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GetWorkspaceListTree, bool>(_getWorkspaceListTreeInstance, MethodValidateUserAccess, parametersOfValidateUserAccess, methodValidateUserAccessPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfValidateUserAccess.ShouldNotBeNull();
            parametersOfValidateUserAccess.Length.ShouldBe(2);
            methodValidateUserAccessPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<GetWorkspaceListTree, bool>(_getWorkspaceListTreeInstance, MethodValidateUserAccess, parametersOfValidateUserAccess, methodValidateUserAccessPrametersTypes));
        }

        #endregion

        #region Method Call : (ValidateUserAccess) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GetWorkspaceListTree_ValidateUserAccess_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var user = CreateType<SPUser>();
            var web = CreateType<SPWeb>();
            var methodValidateUserAccessPrametersTypes = new Type[] { typeof(SPUser), typeof(SPWeb) };
            object[] parametersOfValidateUserAccess = { user, web };

            // Assert
            parametersOfValidateUserAccess.ShouldNotBeNull();
            parametersOfValidateUserAccess.Length.ShouldBe(2);
            methodValidateUserAccessPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<GetWorkspaceListTree, bool>(_getWorkspaceListTreeInstance, MethodValidateUserAccess, parametersOfValidateUserAccess, methodValidateUserAccessPrametersTypes));
        }

        #endregion

        #region Method Call : (ValidateUserAccess) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GetWorkspaceListTree_ValidateUserAccess_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodValidateUserAccessPrametersTypes = new Type[] { typeof(SPUser), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getWorkspaceListTreeInstance, MethodValidateUserAccess, Fixture, methodValidateUserAccessPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodValidateUserAccessPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ValidateUserAccess) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GetWorkspaceListTree_ValidateUserAccess_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodValidateUserAccess, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_getWorkspaceListTreeInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ValidateUserAccess) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GetWorkspaceListTree_ValidateUserAccess_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodValidateUserAccess, 0);
            const int parametersCount = 2;

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
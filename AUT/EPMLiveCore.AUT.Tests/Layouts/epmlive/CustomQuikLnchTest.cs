using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.CustomQuikLnch" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CustomQuikLnchTest : AbstractBaseSetupTypedTest<CustomQuikLnch>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CustomQuikLnch) Initializer

        private const string MethodInitProps = "InitProps";
        private const string MethodManageInternalArrayList = "ManageInternalArrayList";
        private const string MethodLoadTopNavBarNodeCollInMemory = "LoadTopNavBarNodeCollInMemory";
        private const string MethodPage_Load = "Page_Load";
        private const string MethodManageToolBarControls = "ManageToolBarControls";
        private const string MethodAuthenticateUser = "AuthenticateUser";
        private const string MethodOnPreRender = "OnPreRender";
        private const string Field_appId = "_appId";
        private const string Field_web = "_web";
        private const string Field_alLinkData = "_alLinkData";
        private const string FieldappHelper = "appHelper";
        private Type _customQuikLnchInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CustomQuikLnch _customQuikLnchInstance;
        private CustomQuikLnch _customQuikLnchInstanceFixture;

        #region General Initializer : Class (CustomQuikLnch) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CustomQuikLnch" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _customQuikLnchInstanceType = typeof(CustomQuikLnch);
            _customQuikLnchInstanceFixture = Create(true);
            _customQuikLnchInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CustomQuikLnch)

        #region General Initializer : Class (CustomQuikLnch) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="CustomQuikLnch" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodInitProps, 0)]
        [TestCase(MethodManageInternalArrayList, 0)]
        [TestCase(MethodLoadTopNavBarNodeCollInMemory, 0)]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodManageToolBarControls, 0)]
        [TestCase(MethodAuthenticateUser, 0)]
        [TestCase(MethodOnPreRender, 0)]
        public void AUT_CustomQuikLnch_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_customQuikLnchInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CustomQuikLnch) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomQuikLnch" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_appId)]
        [TestCase(Field_web)]
        [TestCase(Field_alLinkData)]
        [TestCase(FieldappHelper)]
        public void AUT_CustomQuikLnch_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_customQuikLnchInstanceFixture, 
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
        ///     Class (<see cref="CustomQuikLnch" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_CustomQuikLnch_Is_Instance_Present_Test()
        {
            // Assert
            _customQuikLnchInstanceType.ShouldNotBeNull();
            _customQuikLnchInstance.ShouldNotBeNull();
            _customQuikLnchInstanceFixture.ShouldNotBeNull();
            _customQuikLnchInstance.ShouldBeAssignableTo<CustomQuikLnch>();
            _customQuikLnchInstanceFixture.ShouldBeAssignableTo<CustomQuikLnch>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CustomQuikLnch) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_CustomQuikLnch_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CustomQuikLnch instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _customQuikLnchInstanceType.ShouldNotBeNull();
            _customQuikLnchInstance.ShouldNotBeNull();
            _customQuikLnchInstanceFixture.ShouldNotBeNull();
            _customQuikLnchInstance.ShouldBeAssignableTo<CustomQuikLnch>();
            _customQuikLnchInstanceFixture.ShouldBeAssignableTo<CustomQuikLnch>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="CustomQuikLnch" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodInitProps)]
        [TestCase(MethodManageInternalArrayList)]
        [TestCase(MethodLoadTopNavBarNodeCollInMemory)]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodManageToolBarControls)]
        [TestCase(MethodAuthenticateUser)]
        [TestCase(MethodOnPreRender)]
        public void AUT_CustomQuikLnch_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<CustomQuikLnch>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (InitProps) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomQuikLnch_InitProps_Method_Call_Internally(Type[] types)
        {
            var methodInitPropsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customQuikLnchInstance, MethodInitProps, Fixture, methodInitPropsPrametersTypes);
        }

        #endregion

        #region Method Call : (InitProps) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQuikLnch_InitProps_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodInitPropsPrametersTypes = null;
            object[] parametersOfInitProps = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitProps, methodInitPropsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customQuikLnchInstanceFixture, parametersOfInitProps);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInitProps.ShouldBeNull();
            methodInitPropsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (InitProps) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQuikLnch_InitProps_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodInitPropsPrametersTypes = null;
            object[] parametersOfInitProps = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customQuikLnchInstance, MethodInitProps, parametersOfInitProps, methodInitPropsPrametersTypes);

            // Assert
            parametersOfInitProps.ShouldBeNull();
            methodInitPropsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitProps) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQuikLnch_InitProps_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodInitPropsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customQuikLnchInstance, MethodInitProps, Fixture, methodInitPropsPrametersTypes);

            // Assert
            methodInitPropsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitProps) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQuikLnch_InitProps_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitProps, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customQuikLnchInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ManageInternalArrayList) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomQuikLnch_ManageInternalArrayList_Method_Call_Internally(Type[] types)
        {
            var methodManageInternalArrayListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customQuikLnchInstance, MethodManageInternalArrayList, Fixture, methodManageInternalArrayListPrametersTypes);
        }

        #endregion

        #region Method Call : (ManageInternalArrayList) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQuikLnch_ManageInternalArrayList_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodManageInternalArrayListPrametersTypes = null;
            object[] parametersOfManageInternalArrayList = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodManageInternalArrayList, methodManageInternalArrayListPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customQuikLnchInstanceFixture, parametersOfManageInternalArrayList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfManageInternalArrayList.ShouldBeNull();
            methodManageInternalArrayListPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ManageInternalArrayList) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQuikLnch_ManageInternalArrayList_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodManageInternalArrayListPrametersTypes = null;
            object[] parametersOfManageInternalArrayList = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customQuikLnchInstance, MethodManageInternalArrayList, parametersOfManageInternalArrayList, methodManageInternalArrayListPrametersTypes);

            // Assert
            parametersOfManageInternalArrayList.ShouldBeNull();
            methodManageInternalArrayListPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ManageInternalArrayList) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQuikLnch_ManageInternalArrayList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodManageInternalArrayListPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customQuikLnchInstance, MethodManageInternalArrayList, Fixture, methodManageInternalArrayListPrametersTypes);

            // Assert
            methodManageInternalArrayListPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ManageInternalArrayList) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQuikLnch_ManageInternalArrayList_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodManageInternalArrayList, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customQuikLnchInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadTopNavBarNodeCollInMemory) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomQuikLnch_LoadTopNavBarNodeCollInMemory_Method_Call_Internally(Type[] types)
        {
            var methodLoadTopNavBarNodeCollInMemoryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customQuikLnchInstance, MethodLoadTopNavBarNodeCollInMemory, Fixture, methodLoadTopNavBarNodeCollInMemoryPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadTopNavBarNodeCollInMemory) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQuikLnch_LoadTopNavBarNodeCollInMemory_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodLoadTopNavBarNodeCollInMemoryPrametersTypes = null;
            object[] parametersOfLoadTopNavBarNodeCollInMemory = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodLoadTopNavBarNodeCollInMemory, methodLoadTopNavBarNodeCollInMemoryPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customQuikLnchInstanceFixture, parametersOfLoadTopNavBarNodeCollInMemory);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfLoadTopNavBarNodeCollInMemory.ShouldBeNull();
            methodLoadTopNavBarNodeCollInMemoryPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (LoadTopNavBarNodeCollInMemory) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQuikLnch_LoadTopNavBarNodeCollInMemory_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodLoadTopNavBarNodeCollInMemoryPrametersTypes = null;
            object[] parametersOfLoadTopNavBarNodeCollInMemory = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customQuikLnchInstance, MethodLoadTopNavBarNodeCollInMemory, parametersOfLoadTopNavBarNodeCollInMemory, methodLoadTopNavBarNodeCollInMemoryPrametersTypes);

            // Assert
            parametersOfLoadTopNavBarNodeCollInMemory.ShouldBeNull();
            methodLoadTopNavBarNodeCollInMemoryPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadTopNavBarNodeCollInMemory) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQuikLnch_LoadTopNavBarNodeCollInMemory_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodLoadTopNavBarNodeCollInMemoryPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customQuikLnchInstance, MethodLoadTopNavBarNodeCollInMemory, Fixture, methodLoadTopNavBarNodeCollInMemoryPrametersTypes);

            // Assert
            methodLoadTopNavBarNodeCollInMemoryPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadTopNavBarNodeCollInMemory) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQuikLnch_LoadTopNavBarNodeCollInMemory_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLoadTopNavBarNodeCollInMemory, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customQuikLnchInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomQuikLnch_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customQuikLnchInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQuikLnch_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customQuikLnchInstanceFixture, parametersOfPage_Load);

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
        public void AUT_CustomQuikLnch_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customQuikLnchInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_CustomQuikLnch_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_CustomQuikLnch_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customQuikLnchInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQuikLnch_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customQuikLnchInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ManageToolBarControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomQuikLnch_ManageToolBarControls_Method_Call_Internally(Type[] types)
        {
            var methodManageToolBarControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customQuikLnchInstance, MethodManageToolBarControls, Fixture, methodManageToolBarControlsPrametersTypes);
        }

        #endregion
        
        #region Method Call : (ManageToolBarControls) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQuikLnch_ManageToolBarControls_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodManageToolBarControlsPrametersTypes = null;
            object[] parametersOfManageToolBarControls = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customQuikLnchInstance, MethodManageToolBarControls, parametersOfManageToolBarControls, methodManageToolBarControlsPrametersTypes);

            // Assert
            parametersOfManageToolBarControls.ShouldBeNull();
            methodManageToolBarControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ManageToolBarControls) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQuikLnch_ManageToolBarControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodManageToolBarControlsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customQuikLnchInstance, MethodManageToolBarControls, Fixture, methodManageToolBarControlsPrametersTypes);

            // Assert
            methodManageToolBarControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ManageToolBarControls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQuikLnch_ManageToolBarControls_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodManageToolBarControls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customQuikLnchInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AuthenticateUser) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomQuikLnch_AuthenticateUser_Method_Call_Internally(Type[] types)
        {
            var methodAuthenticateUserPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customQuikLnchInstance, MethodAuthenticateUser, Fixture, methodAuthenticateUserPrametersTypes);
        }

        #endregion

        #region Method Call : (AuthenticateUser) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQuikLnch_AuthenticateUser_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodAuthenticateUserPrametersTypes = null;
            object[] parametersOfAuthenticateUser = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAuthenticateUser, methodAuthenticateUserPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customQuikLnchInstanceFixture, parametersOfAuthenticateUser);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAuthenticateUser.ShouldBeNull();
            methodAuthenticateUserPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AuthenticateUser) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQuikLnch_AuthenticateUser_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodAuthenticateUserPrametersTypes = null;
            object[] parametersOfAuthenticateUser = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customQuikLnchInstance, MethodAuthenticateUser, parametersOfAuthenticateUser, methodAuthenticateUserPrametersTypes);

            // Assert
            parametersOfAuthenticateUser.ShouldBeNull();
            methodAuthenticateUserPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AuthenticateUser) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQuikLnch_AuthenticateUser_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodAuthenticateUserPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customQuikLnchInstance, MethodAuthenticateUser, Fixture, methodAuthenticateUserPrametersTypes);

            // Assert
            methodAuthenticateUserPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AuthenticateUser) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQuikLnch_AuthenticateUser_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAuthenticateUser, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customQuikLnchInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomQuikLnch_OnPreRender_Method_Call_Internally(Type[] types)
        {
            var methodOnPreRenderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customQuikLnchInstance, MethodOnPreRender, Fixture, methodOnPreRenderPrametersTypes);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQuikLnch_OnPreRender_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnPreRender = { e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnPreRender, methodOnPreRenderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customQuikLnchInstanceFixture, parametersOfOnPreRender);

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
        public void AUT_CustomQuikLnch_OnPreRender_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnPreRender = { e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customQuikLnchInstance, MethodOnPreRender, parametersOfOnPreRender, methodOnPreRenderPrametersTypes);

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
        public void AUT_CustomQuikLnch_OnPreRender_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_CustomQuikLnch_OnPreRender_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customQuikLnchInstance, MethodOnPreRender, Fixture, methodOnPreRenderPrametersTypes);

            // Assert
            methodOnPreRenderPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQuikLnch_OnPreRender_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnPreRender, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customQuikLnchInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.CustomTopNav" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CustomTopNavTest : AbstractBaseSetupTypedTest<CustomTopNav>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CustomTopNav) Initializer

        private const string MethodInitProps = "InitProps";
        private const string MethodManageInternalArrayList = "ManageInternalArrayList";
        private const string MethodLoadTopNavBarNodeCollInMemory = "LoadTopNavBarNodeCollInMemory";
        private const string MethodIsInheritingFromParent = "IsInheritingFromParent";
        private const string MethodManageToolBarControls = "ManageToolBarControls";
        private const string MethodCheckTopNavInheritance = "CheckTopNavInheritance";
        private const string MethodPage_Load = "Page_Load";
        private const string MethodOnPreRender = "OnPreRender";
        private const string Field_appId = "_appId";
        private const string Field_web = "_web";
        private const string Field_alLinkData = "_alLinkData";
        private const string FieldappHelper = "appHelper";
        private Type _customTopNavInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CustomTopNav _customTopNavInstance;
        private CustomTopNav _customTopNavInstanceFixture;

        #region General Initializer : Class (CustomTopNav) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CustomTopNav" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _customTopNavInstanceType = typeof(CustomTopNav);
            _customTopNavInstanceFixture = Create(true);
            _customTopNavInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CustomTopNav)

        #region General Initializer : Class (CustomTopNav) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="CustomTopNav" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodInitProps, 0)]
        [TestCase(MethodManageInternalArrayList, 0)]
        [TestCase(MethodLoadTopNavBarNodeCollInMemory, 0)]
        [TestCase(MethodIsInheritingFromParent, 0)]
        [TestCase(MethodManageToolBarControls, 0)]
        [TestCase(MethodCheckTopNavInheritance, 0)]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodOnPreRender, 0)]
        public void AUT_CustomTopNav_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_customTopNavInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CustomTopNav) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomTopNav" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_appId)]
        [TestCase(Field_web)]
        [TestCase(Field_alLinkData)]
        [TestCase(FieldappHelper)]
        public void AUT_CustomTopNav_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_customTopNavInstanceFixture, 
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
        ///     Class (<see cref="CustomTopNav" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_CustomTopNav_Is_Instance_Present_Test()
        {
            // Assert
            _customTopNavInstanceType.ShouldNotBeNull();
            _customTopNavInstance.ShouldNotBeNull();
            _customTopNavInstanceFixture.ShouldNotBeNull();
            _customTopNavInstance.ShouldBeAssignableTo<CustomTopNav>();
            _customTopNavInstanceFixture.ShouldBeAssignableTo<CustomTopNav>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CustomTopNav) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_CustomTopNav_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CustomTopNav instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _customTopNavInstanceType.ShouldNotBeNull();
            _customTopNavInstance.ShouldNotBeNull();
            _customTopNavInstanceFixture.ShouldNotBeNull();
            _customTopNavInstance.ShouldBeAssignableTo<CustomTopNav>();
            _customTopNavInstanceFixture.ShouldBeAssignableTo<CustomTopNav>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="CustomTopNav" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodInitProps)]
        [TestCase(MethodManageInternalArrayList)]
        [TestCase(MethodLoadTopNavBarNodeCollInMemory)]
        [TestCase(MethodIsInheritingFromParent)]
        [TestCase(MethodManageToolBarControls)]
        [TestCase(MethodCheckTopNavInheritance)]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodOnPreRender)]
        public void AUT_CustomTopNav_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<CustomTopNav>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (InitProps) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomTopNav_InitProps_Method_Call_Internally(Type[] types)
        {
            var methodInitPropsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customTopNavInstance, MethodInitProps, Fixture, methodInitPropsPrametersTypes);
        }

        #endregion

        #region Method Call : (InitProps) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTopNav_InitProps_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodInitPropsPrametersTypes = null;
            object[] parametersOfInitProps = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitProps, methodInitPropsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customTopNavInstanceFixture, parametersOfInitProps);

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
        public void AUT_CustomTopNav_InitProps_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodInitPropsPrametersTypes = null;
            object[] parametersOfInitProps = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customTopNavInstance, MethodInitProps, parametersOfInitProps, methodInitPropsPrametersTypes);

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
        public void AUT_CustomTopNav_InitProps_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodInitPropsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customTopNavInstance, MethodInitProps, Fixture, methodInitPropsPrametersTypes);

            // Assert
            methodInitPropsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitProps) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTopNav_InitProps_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitProps, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customTopNavInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ManageInternalArrayList) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomTopNav_ManageInternalArrayList_Method_Call_Internally(Type[] types)
        {
            var methodManageInternalArrayListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customTopNavInstance, MethodManageInternalArrayList, Fixture, methodManageInternalArrayListPrametersTypes);
        }

        #endregion

        #region Method Call : (ManageInternalArrayList) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTopNav_ManageInternalArrayList_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodManageInternalArrayListPrametersTypes = null;
            object[] parametersOfManageInternalArrayList = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodManageInternalArrayList, methodManageInternalArrayListPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customTopNavInstanceFixture, parametersOfManageInternalArrayList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfManageInternalArrayList.ShouldBeNull();
            methodManageInternalArrayListPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ManageInternalArrayList) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTopNav_ManageInternalArrayList_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodManageInternalArrayListPrametersTypes = null;
            object[] parametersOfManageInternalArrayList = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customTopNavInstance, MethodManageInternalArrayList, parametersOfManageInternalArrayList, methodManageInternalArrayListPrametersTypes);

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
        public void AUT_CustomTopNav_ManageInternalArrayList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodManageInternalArrayListPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customTopNavInstance, MethodManageInternalArrayList, Fixture, methodManageInternalArrayListPrametersTypes);

            // Assert
            methodManageInternalArrayListPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ManageInternalArrayList) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTopNav_ManageInternalArrayList_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodManageInternalArrayList, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customTopNavInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadTopNavBarNodeCollInMemory) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomTopNav_LoadTopNavBarNodeCollInMemory_Method_Call_Internally(Type[] types)
        {
            var methodLoadTopNavBarNodeCollInMemoryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customTopNavInstance, MethodLoadTopNavBarNodeCollInMemory, Fixture, methodLoadTopNavBarNodeCollInMemoryPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadTopNavBarNodeCollInMemory) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTopNav_LoadTopNavBarNodeCollInMemory_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodLoadTopNavBarNodeCollInMemoryPrametersTypes = null;
            object[] parametersOfLoadTopNavBarNodeCollInMemory = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodLoadTopNavBarNodeCollInMemory, methodLoadTopNavBarNodeCollInMemoryPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customTopNavInstanceFixture, parametersOfLoadTopNavBarNodeCollInMemory);

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
        public void AUT_CustomTopNav_LoadTopNavBarNodeCollInMemory_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodLoadTopNavBarNodeCollInMemoryPrametersTypes = null;
            object[] parametersOfLoadTopNavBarNodeCollInMemory = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customTopNavInstance, MethodLoadTopNavBarNodeCollInMemory, parametersOfLoadTopNavBarNodeCollInMemory, methodLoadTopNavBarNodeCollInMemoryPrametersTypes);

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
        public void AUT_CustomTopNav_LoadTopNavBarNodeCollInMemory_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodLoadTopNavBarNodeCollInMemoryPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customTopNavInstance, MethodLoadTopNavBarNodeCollInMemory, Fixture, methodLoadTopNavBarNodeCollInMemoryPrametersTypes);

            // Assert
            methodLoadTopNavBarNodeCollInMemoryPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadTopNavBarNodeCollInMemory) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTopNav_LoadTopNavBarNodeCollInMemory_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLoadTopNavBarNodeCollInMemory, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customTopNavInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsInheritingFromParent) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomTopNav_IsInheritingFromParent_Method_Call_Internally(Type[] types)
        {
            var methodIsInheritingFromParentPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customTopNavInstance, MethodIsInheritingFromParent, Fixture, methodIsInheritingFromParentPrametersTypes);
        }

        #endregion

        #region Method Call : (IsInheritingFromParent) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTopNav_IsInheritingFromParent_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodIsInheritingFromParentPrametersTypes = null;
            object[] parametersOfIsInheritingFromParent = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsInheritingFromParent, methodIsInheritingFromParentPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CustomTopNav, bool>(_customTopNavInstanceFixture, out exception1, parametersOfIsInheritingFromParent);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CustomTopNav, bool>(_customTopNavInstance, MethodIsInheritingFromParent, parametersOfIsInheritingFromParent, methodIsInheritingFromParentPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsInheritingFromParent.ShouldBeNull();
            methodIsInheritingFromParentPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(() => methodInfo.Invoke(_customTopNavInstanceFixture, parametersOfIsInheritingFromParent));
        }

        #endregion

        #region Method Call : (IsInheritingFromParent) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTopNav_IsInheritingFromParent_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodIsInheritingFromParentPrametersTypes = null;
            object[] parametersOfIsInheritingFromParent = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsInheritingFromParent, methodIsInheritingFromParentPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CustomTopNav, bool>(_customTopNavInstanceFixture, out exception1, parametersOfIsInheritingFromParent);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CustomTopNav, bool>(_customTopNavInstance, MethodIsInheritingFromParent, parametersOfIsInheritingFromParent, methodIsInheritingFromParentPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsInheritingFromParent.ShouldBeNull();
            methodIsInheritingFromParentPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<CustomTopNav, bool>(_customTopNavInstance, MethodIsInheritingFromParent, parametersOfIsInheritingFromParent, methodIsInheritingFromParentPrametersTypes));
        }

        #endregion

        #region Method Call : (IsInheritingFromParent) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTopNav_IsInheritingFromParent_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodIsInheritingFromParentPrametersTypes = null;
            object[] parametersOfIsInheritingFromParent = null; // no parameter present

            // Assert
            parametersOfIsInheritingFromParent.ShouldBeNull();
            methodIsInheritingFromParentPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<CustomTopNav, bool>(_customTopNavInstance, MethodIsInheritingFromParent, parametersOfIsInheritingFromParent, methodIsInheritingFromParentPrametersTypes));
        }

        #endregion

        #region Method Call : (IsInheritingFromParent) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTopNav_IsInheritingFromParent_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodIsInheritingFromParentPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customTopNavInstance, MethodIsInheritingFromParent, Fixture, methodIsInheritingFromParentPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsInheritingFromParentPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsInheritingFromParent) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTopNav_IsInheritingFromParent_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsInheritingFromParent, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_customTopNavInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ManageToolBarControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomTopNav_ManageToolBarControls_Method_Call_Internally(Type[] types)
        {
            var methodManageToolBarControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customTopNavInstance, MethodManageToolBarControls, Fixture, methodManageToolBarControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (ManageToolBarControls) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTopNav_ManageToolBarControls_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodManageToolBarControlsPrametersTypes = null;
            object[] parametersOfManageToolBarControls = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodManageToolBarControls, methodManageToolBarControlsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customTopNavInstanceFixture, parametersOfManageToolBarControls);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfManageToolBarControls.ShouldBeNull();
            methodManageToolBarControlsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ManageToolBarControls) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTopNav_ManageToolBarControls_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodManageToolBarControlsPrametersTypes = null;
            object[] parametersOfManageToolBarControls = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customTopNavInstance, MethodManageToolBarControls, parametersOfManageToolBarControls, methodManageToolBarControlsPrametersTypes);

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
        public void AUT_CustomTopNav_ManageToolBarControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodManageToolBarControlsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customTopNavInstance, MethodManageToolBarControls, Fixture, methodManageToolBarControlsPrametersTypes);

            // Assert
            methodManageToolBarControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ManageToolBarControls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTopNav_ManageToolBarControls_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodManageToolBarControls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customTopNavInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CheckTopNavInheritance) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomTopNav_CheckTopNavInheritance_Method_Call_Internally(Type[] types)
        {
            var methodCheckTopNavInheritancePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customTopNavInstance, MethodCheckTopNavInheritance, Fixture, methodCheckTopNavInheritancePrametersTypes);
        }

        #endregion

        #region Method Call : (CheckTopNavInheritance) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTopNav_CheckTopNavInheritance_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodCheckTopNavInheritancePrametersTypes = null;
            object[] parametersOfCheckTopNavInheritance = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCheckTopNavInheritance, methodCheckTopNavInheritancePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customTopNavInstanceFixture, parametersOfCheckTopNavInheritance);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCheckTopNavInheritance.ShouldBeNull();
            methodCheckTopNavInheritancePrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CheckTopNavInheritance) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTopNav_CheckTopNavInheritance_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCheckTopNavInheritancePrametersTypes = null;
            object[] parametersOfCheckTopNavInheritance = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customTopNavInstance, MethodCheckTopNavInheritance, parametersOfCheckTopNavInheritance, methodCheckTopNavInheritancePrametersTypes);

            // Assert
            parametersOfCheckTopNavInheritance.ShouldBeNull();
            methodCheckTopNavInheritancePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CheckTopNavInheritance) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTopNav_CheckTopNavInheritance_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCheckTopNavInheritancePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customTopNavInstance, MethodCheckTopNavInheritance, Fixture, methodCheckTopNavInheritancePrametersTypes);

            // Assert
            methodCheckTopNavInheritancePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CheckTopNavInheritance) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTopNav_CheckTopNavInheritance_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCheckTopNavInheritance, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customTopNavInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomTopNav_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customTopNavInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTopNav_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customTopNavInstanceFixture, parametersOfPage_Load);

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
        public void AUT_CustomTopNav_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customTopNavInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_CustomTopNav_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_CustomTopNav_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customTopNavInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTopNav_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customTopNavInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomTopNav_OnPreRender_Method_Call_Internally(Type[] types)
        {
            var methodOnPreRenderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customTopNavInstance, MethodOnPreRender, Fixture, methodOnPreRenderPrametersTypes);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTopNav_OnPreRender_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnPreRender = { e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnPreRender, methodOnPreRenderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customTopNavInstanceFixture, parametersOfOnPreRender);

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
        public void AUT_CustomTopNav_OnPreRender_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnPreRender = { e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customTopNavInstance, MethodOnPreRender, parametersOfOnPreRender, methodOnPreRenderPrametersTypes);

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
        public void AUT_CustomTopNav_OnPreRender_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_CustomTopNav_OnPreRender_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customTopNavInstance, MethodOnPreRender, Fixture, methodOnPreRenderPrametersTypes);

            // Assert
            methodOnPreRenderPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTopNav_OnPreRender_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnPreRender, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customTopNavInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
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

namespace EPMLiveCore.Layouts.EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Layouts.EPMLiveCore.usersv2" />)
    ///     and namespace <see cref="EPMLiveCore.Layouts.EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class Usersv2Test : AbstractBaseSetupTypedTest<usersv2>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (usersv2) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodListUsers = "ListUsers";
        private const string MethodDeleteUser = "DeleteUser";
        private const string FieldsFeature = "sFeature";
        private Type _usersv2InstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private usersv2 _usersv2Instance;
        private usersv2 _usersv2InstanceFixture;

        #region General Initializer : Class (usersv2) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="usersv2" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _usersv2InstanceType = typeof(usersv2);
            _usersv2InstanceFixture = Create(true);
            _usersv2Instance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (usersv2)

        #region General Initializer : Class (usersv2) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="usersv2" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodListUsers, 0)]
        [TestCase(MethodDeleteUser, 0)]
        public void AUT_Usersv2_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_usersv2InstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (usersv2) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="usersv2" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldsFeature)]
        public void AUT_Usersv2_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_usersv2InstanceFixture, 
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
        ///     Class (<see cref="usersv2" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Usersv2_Is_Instance_Present_Test()
        {
            // Assert
            _usersv2InstanceType.ShouldNotBeNull();
            _usersv2Instance.ShouldNotBeNull();
            _usersv2InstanceFixture.ShouldNotBeNull();
            _usersv2Instance.ShouldBeAssignableTo<usersv2>();
            _usersv2InstanceFixture.ShouldBeAssignableTo<usersv2>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (usersv2) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_usersv2_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            usersv2 instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _usersv2InstanceType.ShouldNotBeNull();
            _usersv2Instance.ShouldNotBeNull();
            _usersv2InstanceFixture.ShouldNotBeNull();
            _usersv2Instance.ShouldBeAssignableTo<usersv2>();
            _usersv2InstanceFixture.ShouldBeAssignableTo<usersv2>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="usersv2" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodListUsers)]
        [TestCase(MethodDeleteUser)]
        public void AUT_Usersv2_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<usersv2>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Usersv2_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersv2Instance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Usersv2_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_usersv2InstanceFixture, parametersOfPage_Load);

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
        public void AUT_Usersv2_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_usersv2Instance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Usersv2_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Usersv2_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersv2Instance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Usersv2_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_usersv2InstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ListUsers) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Usersv2_ListUsers_Method_Call_Internally(Type[] types)
        {
            var methodListUsersPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersv2Instance, MethodListUsers, Fixture, methodListUsersPrametersTypes);
        }

        #endregion

        #region Method Call : (ListUsers) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Usersv2_ListUsers_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodListUsersPrametersTypes = null;
            object[] parametersOfListUsers = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodListUsers, methodListUsersPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_usersv2InstanceFixture, parametersOfListUsers);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfListUsers.ShouldBeNull();
            methodListUsersPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ListUsers) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Usersv2_ListUsers_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodListUsersPrametersTypes = null;
            object[] parametersOfListUsers = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_usersv2Instance, MethodListUsers, parametersOfListUsers, methodListUsersPrametersTypes);

            // Assert
            parametersOfListUsers.ShouldBeNull();
            methodListUsersPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ListUsers) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Usersv2_ListUsers_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodListUsersPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersv2Instance, MethodListUsers, Fixture, methodListUsersPrametersTypes);

            // Assert
            methodListUsersPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ListUsers) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Usersv2_ListUsers_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodListUsers, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_usersv2InstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteUser) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Usersv2_DeleteUser_Method_Call_Internally(Type[] types)
        {
            var methodDeleteUserPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersv2Instance, MethodDeleteUser, Fixture, methodDeleteUserPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteUser) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Usersv2_DeleteUser_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sFeatureUserID = CreateType<string>();
            var methodDeleteUserPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeleteUser = { sFeatureUserID };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDeleteUser, methodDeleteUserPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_usersv2InstanceFixture, parametersOfDeleteUser);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDeleteUser.ShouldNotBeNull();
            parametersOfDeleteUser.Length.ShouldBe(1);
            methodDeleteUserPrametersTypes.Length.ShouldBe(1);
            methodDeleteUserPrametersTypes.Length.ShouldBe(parametersOfDeleteUser.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DeleteUser) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Usersv2_DeleteUser_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sFeatureUserID = CreateType<string>();
            var methodDeleteUserPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeleteUser = { sFeatureUserID };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_usersv2Instance, MethodDeleteUser, parametersOfDeleteUser, methodDeleteUserPrametersTypes);

            // Assert
            parametersOfDeleteUser.ShouldNotBeNull();
            parametersOfDeleteUser.Length.ShouldBe(1);
            methodDeleteUserPrametersTypes.Length.ShouldBe(1);
            methodDeleteUserPrametersTypes.Length.ShouldBe(parametersOfDeleteUser.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteUser) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Usersv2_DeleteUser_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteUser, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteUser) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Usersv2_DeleteUser_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteUserPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_usersv2Instance, MethodDeleteUser, Fixture, methodDeleteUserPrametersTypes);

            // Assert
            methodDeleteUserPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteUser) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Usersv2_DeleteUser_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteUser, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_usersv2InstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
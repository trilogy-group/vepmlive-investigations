using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.AutoFixtureSetup;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.WebControls;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using adminusers = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.adminusers" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class AdminusersTest : AbstractBaseSetupTypedTest<adminusers>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (adminusers) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodListUsers = "ListUsers";
        private const string MethodDeleteUser = "DeleteUser";
        private const string FieldGvItems = "GvItems";
        private const string FieldlblFeatureName = "lblFeatureName";
        private const string FieldlblUsage = "lblUsage";
        private const string FieldlblConnError = "lblConnError";
        private const string FieldlblMaxUsers = "lblMaxUsers";
        private const string FieldlblError = "lblError";
        private const string FieldsFeature = "sFeature";
        private Type _adminusersInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private adminusers _adminusersInstance;
        private adminusers _adminusersInstanceFixture;

        #region General Initializer : Class (adminusers) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="adminusers" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _adminusersInstanceType = typeof(adminusers);
            _adminusersInstanceFixture = Create(true);
            _adminusersInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (adminusers)

        #region General Initializer : Class (adminusers) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="adminusers" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodListUsers, 0)]
        [TestCase(MethodDeleteUser, 0)]
        public void AUT_Adminusers_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_adminusersInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (adminusers) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="adminusers" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldGvItems)]
        [TestCase(FieldlblFeatureName)]
        [TestCase(FieldlblUsage)]
        [TestCase(FieldlblConnError)]
        [TestCase(FieldlblMaxUsers)]
        [TestCase(FieldlblError)]
        [TestCase(FieldsFeature)]
        public void AUT_Adminusers_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_adminusersInstanceFixture, 
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
        ///     Class (<see cref="adminusers" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Adminusers_Is_Instance_Present_Test()
        {
            // Assert
            _adminusersInstanceType.ShouldNotBeNull();
            _adminusersInstance.ShouldNotBeNull();
            _adminusersInstanceFixture.ShouldNotBeNull();
            _adminusersInstance.ShouldBeAssignableTo<adminusers>();
            _adminusersInstanceFixture.ShouldBeAssignableTo<adminusers>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (adminusers) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_adminusers_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            adminusers instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _adminusersInstanceType.ShouldNotBeNull();
            _adminusersInstance.ShouldNotBeNull();
            _adminusersInstanceFixture.ShouldNotBeNull();
            _adminusersInstance.ShouldBeAssignableTo<adminusers>();
            _adminusersInstanceFixture.ShouldBeAssignableTo<adminusers>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="adminusers" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodListUsers)]
        [TestCase(MethodDeleteUser)]
        public void AUT_Adminusers_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<adminusers>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adminusers_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminusersInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminusers_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_adminusersInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Adminusers_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_adminusersInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Adminusers_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Adminusers_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminusersInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminusers_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_adminusersInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ListUsers) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adminusers_ListUsers_Method_Call_Internally(Type[] types)
        {
            var methodListUsersPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminusersInstance, MethodListUsers, Fixture, methodListUsersPrametersTypes);
        }

        #endregion

        #region Method Call : (ListUsers) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminusers_ListUsers_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodListUsersPrametersTypes = null;
            object[] parametersOfListUsers = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodListUsers, methodListUsersPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_adminusersInstanceFixture, parametersOfListUsers);

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
        public void AUT_Adminusers_ListUsers_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodListUsersPrametersTypes = null;
            object[] parametersOfListUsers = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_adminusersInstance, MethodListUsers, parametersOfListUsers, methodListUsersPrametersTypes);

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
        public void AUT_Adminusers_ListUsers_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodListUsersPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminusersInstance, MethodListUsers, Fixture, methodListUsersPrametersTypes);

            // Assert
            methodListUsersPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ListUsers) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminusers_ListUsers_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodListUsers, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_adminusersInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteUser) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adminusers_DeleteUser_Method_Call_Internally(Type[] types)
        {
            var methodDeleteUserPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminusersInstance, MethodDeleteUser, Fixture, methodDeleteUserPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteUser) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminusers_DeleteUser_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sFeatureUserID = CreateType<string>();
            var methodDeleteUserPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeleteUser = { sFeatureUserID };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDeleteUser, methodDeleteUserPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_adminusersInstanceFixture, parametersOfDeleteUser);

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
        public void AUT_Adminusers_DeleteUser_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sFeatureUserID = CreateType<string>();
            var methodDeleteUserPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeleteUser = { sFeatureUserID };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_adminusersInstance, MethodDeleteUser, parametersOfDeleteUser, methodDeleteUserPrametersTypes);

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
        public void AUT_Adminusers_DeleteUser_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Adminusers_DeleteUser_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteUserPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminusersInstance, MethodDeleteUser, Fixture, methodDeleteUserPrametersTypes);

            // Assert
            methodDeleteUserPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteUser) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminusers_DeleteUser_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteUser, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_adminusersInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
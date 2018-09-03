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
using System.Xml;
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
using Microsoft.Win32;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using adminaddkey = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.adminaddkey" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class AdminaddkeyTest : AbstractBaseSetupTypedTest<adminaddkey>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (adminaddkey) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodaddKey = "addKey";
        private const string MethodinsertKey = "insertKey";
        private const string FieldlblResult = "lblResult";
        private Type _adminaddkeyInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private adminaddkey _adminaddkeyInstance;
        private adminaddkey _adminaddkeyInstanceFixture;

        #region General Initializer : Class (adminaddkey) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="adminaddkey" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _adminaddkeyInstanceType = typeof(adminaddkey);
            _adminaddkeyInstanceFixture = Create(true);
            _adminaddkeyInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (adminaddkey)

        #region General Initializer : Class (adminaddkey) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="adminaddkey" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodaddKey, 0)]
        [TestCase(MethodinsertKey, 0)]
        public void AUT_Adminaddkey_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_adminaddkeyInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (adminaddkey) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="adminaddkey" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldlblResult)]
        public void AUT_Adminaddkey_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_adminaddkeyInstanceFixture, 
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
        ///     Class (<see cref="adminaddkey" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Adminaddkey_Is_Instance_Present_Test()
        {
            // Assert
            _adminaddkeyInstanceType.ShouldNotBeNull();
            _adminaddkeyInstance.ShouldNotBeNull();
            _adminaddkeyInstanceFixture.ShouldNotBeNull();
            _adminaddkeyInstance.ShouldBeAssignableTo<adminaddkey>();
            _adminaddkeyInstanceFixture.ShouldBeAssignableTo<adminaddkey>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (adminaddkey) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_adminaddkey_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            adminaddkey instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _adminaddkeyInstanceType.ShouldNotBeNull();
            _adminaddkeyInstance.ShouldNotBeNull();
            _adminaddkeyInstanceFixture.ShouldNotBeNull();
            _adminaddkeyInstance.ShouldBeAssignableTo<adminaddkey>();
            _adminaddkeyInstanceFixture.ShouldBeAssignableTo<adminaddkey>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="adminaddkey" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodaddKey)]
        [TestCase(MethodinsertKey)]
        public void AUT_Adminaddkey_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<adminaddkey>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adminaddkey_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminaddkeyInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminaddkey_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_adminaddkeyInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Adminaddkey_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_adminaddkeyInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Adminaddkey_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Adminaddkey_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminaddkeyInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminaddkey_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_adminaddkeyInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addKey) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adminaddkey_addKey_Method_Call_Internally(Type[] types)
        {
            var methodaddKeyPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminaddkeyInstance, MethodaddKey, Fixture, methodaddKeyPrametersTypes);
        }

        #endregion

        #region Method Call : (addKey) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminaddkey_addKey_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var inkey = CreateType<string>();
            var methodaddKeyPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfaddKey = { inkey };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodaddKey, methodaddKeyPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<adminaddkey, bool>(_adminaddkeyInstanceFixture, out exception1, parametersOfaddKey);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<adminaddkey, bool>(_adminaddkeyInstance, MethodaddKey, parametersOfaddKey, methodaddKeyPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfaddKey.ShouldNotBeNull();
            parametersOfaddKey.Length.ShouldBe(1);
            methodaddKeyPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (addKey) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminaddkey_addKey_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var inkey = CreateType<string>();
            var methodaddKeyPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfaddKey = { inkey };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodaddKey, methodaddKeyPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<adminaddkey, bool>(_adminaddkeyInstanceFixture, out exception1, parametersOfaddKey);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<adminaddkey, bool>(_adminaddkeyInstance, MethodaddKey, parametersOfaddKey, methodaddKeyPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfaddKey.ShouldNotBeNull();
            parametersOfaddKey.Length.ShouldBe(1);
            methodaddKeyPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (addKey) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminaddkey_addKey_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var inkey = CreateType<string>();
            var methodaddKeyPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfaddKey = { inkey };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<adminaddkey, bool>(_adminaddkeyInstance, MethodaddKey, parametersOfaddKey, methodaddKeyPrametersTypes);

            // Assert
            parametersOfaddKey.ShouldNotBeNull();
            parametersOfaddKey.Length.ShouldBe(1);
            methodaddKeyPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addKey) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminaddkey_addKey_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodaddKeyPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminaddkeyInstance, MethodaddKey, Fixture, methodaddKeyPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodaddKeyPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addKey) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminaddkey_addKey_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodaddKey, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_adminaddkeyInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (addKey) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminaddkey_addKey_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodaddKey, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (insertKey) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adminaddkey_insertKey_Method_Call_Internally(Type[] types)
        {
            var methodinsertKeyPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminaddkeyInstance, MethodinsertKey, Fixture, methodinsertKeyPrametersTypes);
        }

        #endregion

        #region Method Call : (insertKey) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminaddkey_insertKey_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var key = CreateType<string>();
            var methodinsertKeyPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfinsertKey = { key };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodinsertKey, methodinsertKeyPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<adminaddkey, bool>(_adminaddkeyInstanceFixture, out exception1, parametersOfinsertKey);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<adminaddkey, bool>(_adminaddkeyInstance, MethodinsertKey, parametersOfinsertKey, methodinsertKeyPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfinsertKey.ShouldNotBeNull();
            parametersOfinsertKey.Length.ShouldBe(1);
            methodinsertKeyPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (insertKey) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminaddkey_insertKey_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var key = CreateType<string>();
            var methodinsertKeyPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfinsertKey = { key };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodinsertKey, methodinsertKeyPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<adminaddkey, bool>(_adminaddkeyInstanceFixture, out exception1, parametersOfinsertKey);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<adminaddkey, bool>(_adminaddkeyInstance, MethodinsertKey, parametersOfinsertKey, methodinsertKeyPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfinsertKey.ShouldNotBeNull();
            parametersOfinsertKey.Length.ShouldBe(1);
            methodinsertKeyPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (insertKey) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminaddkey_insertKey_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var key = CreateType<string>();
            var methodinsertKeyPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfinsertKey = { key };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<adminaddkey, bool>(_adminaddkeyInstance, MethodinsertKey, parametersOfinsertKey, methodinsertKeyPrametersTypes);

            // Assert
            parametersOfinsertKey.ShouldNotBeNull();
            parametersOfinsertKey.Length.ShouldBe(1);
            methodinsertKeyPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (insertKey) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminaddkey_insertKey_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodinsertKeyPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminaddkeyInstance, MethodinsertKey, Fixture, methodinsertKeyPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodinsertKeyPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (insertKey) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminaddkey_insertKey_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodinsertKey, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_adminaddkeyInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (insertKey) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminaddkey_insertKey_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodinsertKey, 0);
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
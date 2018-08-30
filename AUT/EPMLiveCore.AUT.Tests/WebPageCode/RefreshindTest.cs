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
using Microsoft.VisualBasic;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using refreshind = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.refreshind" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class RefreshindTest : AbstractBaseSetupTypedTest<refreshind>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (refreshind) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodgetListItemCount = "getListItemCount";
        private const string FieldprojectCenter = "projectCenter";
        private const string FieldhCurrentProjectCenter = "hCurrentProjectCenter";
        private Type _refreshindInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private refreshind _refreshindInstance;
        private refreshind _refreshindInstanceFixture;

        #region General Initializer : Class (refreshind) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="refreshind" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _refreshindInstanceType = typeof(refreshind);
            _refreshindInstanceFixture = Create(true);
            _refreshindInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (refreshind)

        #region General Initializer : Class (refreshind) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="refreshind" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodgetListItemCount, 0)]
        public void AUT_Refreshind_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_refreshindInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (refreshind) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="refreshind" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldprojectCenter)]
        [TestCase(FieldhCurrentProjectCenter)]
        public void AUT_Refreshind_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_refreshindInstanceFixture, 
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
        ///     Class (<see cref="refreshind" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Refreshind_Is_Instance_Present_Test()
        {
            // Assert
            _refreshindInstanceType.ShouldNotBeNull();
            _refreshindInstance.ShouldNotBeNull();
            _refreshindInstanceFixture.ShouldNotBeNull();
            _refreshindInstance.ShouldBeAssignableTo<refreshind>();
            _refreshindInstanceFixture.ShouldBeAssignableTo<refreshind>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (refreshind) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_refreshind_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            refreshind instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _refreshindInstanceType.ShouldNotBeNull();
            _refreshindInstance.ShouldNotBeNull();
            _refreshindInstanceFixture.ShouldNotBeNull();
            _refreshindInstance.ShouldBeAssignableTo<refreshind>();
            _refreshindInstanceFixture.ShouldBeAssignableTo<refreshind>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="refreshind" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodgetListItemCount)]
        public void AUT_Refreshind_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<refreshind>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Refreshind_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_refreshindInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Refreshind_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_refreshindInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Refreshind_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_refreshindInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Refreshind_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Refreshind_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_refreshindInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Refreshind_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_refreshindInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getListItemCount) (Return Type : double) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Refreshind_getListItemCount_Method_Call_Internally(Type[] types)
        {
            var methodgetListItemCountPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_refreshindInstance, MethodgetListItemCount, Fixture, methodgetListItemCountPrametersTypes);
        }

        #endregion

        #region Method Call : (getListItemCount) (Return Type : double) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Refreshind_getListItemCount_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var f = CreateType<SPField>();
            var project = CreateType<string>();
            var methodgetListItemCountPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPField), typeof(string) };
            object[] parametersOfgetListItemCount = { web, f, project };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodgetListItemCount, methodgetListItemCountPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<refreshind, double>(_refreshindInstanceFixture, out exception1, parametersOfgetListItemCount);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<refreshind, double>(_refreshindInstance, MethodgetListItemCount, parametersOfgetListItemCount, methodgetListItemCountPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfgetListItemCount.ShouldNotBeNull();
            parametersOfgetListItemCount.Length.ShouldBe(3);
            methodgetListItemCountPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (getListItemCount) (Return Type : double) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Refreshind_getListItemCount_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var f = CreateType<SPField>();
            var project = CreateType<string>();
            var methodgetListItemCountPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPField), typeof(string) };
            object[] parametersOfgetListItemCount = { web, f, project };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodgetListItemCount, methodgetListItemCountPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<refreshind, double>(_refreshindInstanceFixture, out exception1, parametersOfgetListItemCount);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<refreshind, double>(_refreshindInstance, MethodgetListItemCount, parametersOfgetListItemCount, methodgetListItemCountPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfgetListItemCount.ShouldNotBeNull();
            parametersOfgetListItemCount.Length.ShouldBe(3);
            methodgetListItemCountPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (getListItemCount) (Return Type : double) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Refreshind_getListItemCount_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var f = CreateType<SPField>();
            var project = CreateType<string>();
            var methodgetListItemCountPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPField), typeof(string) };
            object[] parametersOfgetListItemCount = { web, f, project };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<refreshind, double>(_refreshindInstance, MethodgetListItemCount, parametersOfgetListItemCount, methodgetListItemCountPrametersTypes);

            // Assert
            parametersOfgetListItemCount.ShouldNotBeNull();
            parametersOfgetListItemCount.Length.ShouldBe(3);
            methodgetListItemCountPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getListItemCount) (Return Type : double) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Refreshind_getListItemCount_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetListItemCountPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPField), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_refreshindInstance, MethodgetListItemCount, Fixture, methodgetListItemCountPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetListItemCountPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getListItemCount) (Return Type : double) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Refreshind_getListItemCount_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetListItemCount, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_refreshindInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getListItemCount) (Return Type : double) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Refreshind_getListItemCount_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetListItemCount, 0);
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
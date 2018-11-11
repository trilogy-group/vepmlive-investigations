using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using InstallSolutions = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.InstallSolutions" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class InstallSolutionsTest : AbstractBaseSetupTypedTest<InstallSolutions>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (InstallSolutions) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodInstall = "Install";
        private const string MethodEnsureLanguagePack = "EnsureLanguagePack";
        private const string Fieldoutput = "output";
        private Type _installSolutionsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private InstallSolutions _installSolutionsInstance;
        private InstallSolutions _installSolutionsInstanceFixture;

        #region General Initializer : Class (InstallSolutions) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="InstallSolutions" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _installSolutionsInstanceType = typeof(InstallSolutions);
            _installSolutionsInstanceFixture = Create(true);
            _installSolutionsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (InstallSolutions)

        #region General Initializer : Class (InstallSolutions) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="InstallSolutions" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodInstall, 0)]
        [TestCase(MethodEnsureLanguagePack, 0)]
        public void AUT_InstallSolutions_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_installSolutionsInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (InstallSolutions) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="InstallSolutions" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldoutput)]
        public void AUT_InstallSolutions_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_installSolutionsInstanceFixture, 
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
        ///     Class (<see cref="InstallSolutions" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_InstallSolutions_Is_Instance_Present_Test()
        {
            // Assert
            _installSolutionsInstanceType.ShouldNotBeNull();
            _installSolutionsInstance.ShouldNotBeNull();
            _installSolutionsInstanceFixture.ShouldNotBeNull();
            _installSolutionsInstance.ShouldBeAssignableTo<InstallSolutions>();
            _installSolutionsInstanceFixture.ShouldBeAssignableTo<InstallSolutions>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (InstallSolutions) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_InstallSolutions_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            InstallSolutions instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _installSolutionsInstanceType.ShouldNotBeNull();
            _installSolutionsInstance.ShouldNotBeNull();
            _installSolutionsInstanceFixture.ShouldNotBeNull();
            _installSolutionsInstance.ShouldBeAssignableTo<InstallSolutions>();
            _installSolutionsInstanceFixture.ShouldBeAssignableTo<InstallSolutions>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="InstallSolutions" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodEnsureLanguagePack)]
        public void AUT_InstallSolutions_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_installSolutionsInstanceFixture,
                                                                              _installSolutionsInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="InstallSolutions" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodInstall)]
        public void AUT_InstallSolutions_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<InstallSolutions>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_InstallSolutions_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_installSolutionsInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallSolutions_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_installSolutionsInstanceFixture, parametersOfPage_Load);

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
        public void AUT_InstallSolutions_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_installSolutionsInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_InstallSolutions_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_InstallSolutions_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_installSolutionsInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallSolutions_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_installSolutionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Install) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_InstallSolutions_Install_Method_Call_Internally(Type[] types)
        {
            var methodInstallPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_installSolutionsInstance, MethodInstall, Fixture, methodInstallPrametersTypes);
        }

        #endregion

        #region Method Call : (Install) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallSolutions_Install_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Solution = CreateType<Guid>();
            var farm = CreateType<SPFarm>();
            var apps = CreateType<System.Collections.ObjectModel.Collection<SPWebApplication>>();
            var methodInstallPrametersTypes = new Type[] { typeof(Guid), typeof(SPFarm), typeof(System.Collections.ObjectModel.Collection<SPWebApplication>) };
            object[] parametersOfInstall = { Solution, farm, apps };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodInstall, methodInstallPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<InstallSolutions, bool>(_installSolutionsInstanceFixture, out exception1, parametersOfInstall);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<InstallSolutions, bool>(_installSolutionsInstance, MethodInstall, parametersOfInstall, methodInstallPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfInstall.ShouldNotBeNull();
            parametersOfInstall.Length.ShouldBe(3);
            methodInstallPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (Install) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallSolutions_Install_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var Solution = CreateType<Guid>();
            var farm = CreateType<SPFarm>();
            var apps = CreateType<System.Collections.ObjectModel.Collection<SPWebApplication>>();
            var methodInstallPrametersTypes = new Type[] { typeof(Guid), typeof(SPFarm), typeof(System.Collections.ObjectModel.Collection<SPWebApplication>) };
            object[] parametersOfInstall = { Solution, farm, apps };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodInstall, methodInstallPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<InstallSolutions, bool>(_installSolutionsInstanceFixture, out exception1, parametersOfInstall);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<InstallSolutions, bool>(_installSolutionsInstance, MethodInstall, parametersOfInstall, methodInstallPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfInstall.ShouldNotBeNull();
            parametersOfInstall.Length.ShouldBe(3);
            methodInstallPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (Install) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallSolutions_Install_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Solution = CreateType<Guid>();
            var farm = CreateType<SPFarm>();
            var apps = CreateType<System.Collections.ObjectModel.Collection<SPWebApplication>>();
            var methodInstallPrametersTypes = new Type[] { typeof(Guid), typeof(SPFarm), typeof(System.Collections.ObjectModel.Collection<SPWebApplication>) };
            object[] parametersOfInstall = { Solution, farm, apps };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<InstallSolutions, bool>(_installSolutionsInstance, MethodInstall, parametersOfInstall, methodInstallPrametersTypes);

            // Assert
            parametersOfInstall.ShouldNotBeNull();
            parametersOfInstall.Length.ShouldBe(3);
            methodInstallPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Install) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallSolutions_Install_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInstallPrametersTypes = new Type[] { typeof(Guid), typeof(SPFarm), typeof(System.Collections.ObjectModel.Collection<SPWebApplication>) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_installSolutionsInstance, MethodInstall, Fixture, methodInstallPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodInstallPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Install) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallSolutions_Install_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInstall, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_installSolutionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Install) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallSolutions_Install_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodInstall, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (EnsureLanguagePack) (Return Type : SPSolutionLanguagePack) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_InstallSolutions_EnsureLanguagePack_Static_Method_Call_Internally(Type[] types)
        {
            var methodEnsureLanguagePackPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_installSolutionsInstanceFixture, _installSolutionsInstanceType, MethodEnsureLanguagePack, Fixture, methodEnsureLanguagePackPrametersTypes);
        }

        #endregion

        #region Method Call : (EnsureLanguagePack) (Return Type : SPSolutionLanguagePack) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallSolutions_EnsureLanguagePack_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var spSolution = CreateType<SPSolution>();
            var lcid = CreateType<uint>();
            var methodEnsureLanguagePackPrametersTypes = new Type[] { typeof(SPSolution), typeof(uint) };
            object[] parametersOfEnsureLanguagePack = { spSolution, lcid };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodEnsureLanguagePack, methodEnsureLanguagePackPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_installSolutionsInstanceFixture, _installSolutionsInstanceType, MethodEnsureLanguagePack, Fixture, methodEnsureLanguagePackPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<SPSolutionLanguagePack>(_installSolutionsInstanceFixture, _installSolutionsInstanceType, MethodEnsureLanguagePack, parametersOfEnsureLanguagePack, methodEnsureLanguagePackPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_installSolutionsInstanceFixture, parametersOfEnsureLanguagePack);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfEnsureLanguagePack.ShouldNotBeNull();
            parametersOfEnsureLanguagePack.Length.ShouldBe(2);
            methodEnsureLanguagePackPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (EnsureLanguagePack) (Return Type : SPSolutionLanguagePack) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallSolutions_EnsureLanguagePack_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spSolution = CreateType<SPSolution>();
            var lcid = CreateType<uint>();
            var methodEnsureLanguagePackPrametersTypes = new Type[] { typeof(SPSolution), typeof(uint) };
            object[] parametersOfEnsureLanguagePack = { spSolution, lcid };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<SPSolutionLanguagePack>(_installSolutionsInstanceFixture, _installSolutionsInstanceType, MethodEnsureLanguagePack, parametersOfEnsureLanguagePack, methodEnsureLanguagePackPrametersTypes);

            // Assert
            parametersOfEnsureLanguagePack.ShouldNotBeNull();
            parametersOfEnsureLanguagePack.Length.ShouldBe(2);
            methodEnsureLanguagePackPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnsureLanguagePack) (Return Type : SPSolutionLanguagePack) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallSolutions_EnsureLanguagePack_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodEnsureLanguagePackPrametersTypes = new Type[] { typeof(SPSolution), typeof(uint) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_installSolutionsInstanceFixture, _installSolutionsInstanceType, MethodEnsureLanguagePack, Fixture, methodEnsureLanguagePackPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodEnsureLanguagePackPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (EnsureLanguagePack) (Return Type : SPSolutionLanguagePack) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallSolutions_EnsureLanguagePack_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodEnsureLanguagePackPrametersTypes = new Type[] { typeof(SPSolution), typeof(uint) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_installSolutionsInstanceFixture, _installSolutionsInstanceType, MethodEnsureLanguagePack, Fixture, methodEnsureLanguagePackPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodEnsureLanguagePackPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (EnsureLanguagePack) (Return Type : SPSolutionLanguagePack) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallSolutions_EnsureLanguagePack_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodEnsureLanguagePack, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_installSolutionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (EnsureLanguagePack) (Return Type : SPSolutionLanguagePack) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallSolutions_EnsureLanguagePack_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodEnsureLanguagePack, 0);
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
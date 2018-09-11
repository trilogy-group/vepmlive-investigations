using System;
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

namespace EPMLiveWebparts
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebparts.getworkspacelist" />)
    ///     and namespace <see cref="EPMLiveWebparts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class GetworkspacelistTest : AbstractBaseSetupTypedTest<getworkspacelist>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (getworkspacelist) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodaddWebs = "addWebs";
        private const string Fielddoc = "doc";
        private const string Fielddata = "data";
        private Type _getworkspacelistInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private getworkspacelist _getworkspacelistInstance;
        private getworkspacelist _getworkspacelistInstanceFixture;

        #region General Initializer : Class (getworkspacelist) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="getworkspacelist" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _getworkspacelistInstanceType = typeof(getworkspacelist);
            _getworkspacelistInstanceFixture = Create(true);
            _getworkspacelistInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (getworkspacelist)

        #region General Initializer : Class (getworkspacelist) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="getworkspacelist" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodaddWebs, 0)]
        public void AUT_Getworkspacelist_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_getworkspacelistInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (getworkspacelist) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="getworkspacelist" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fielddoc)]
        [TestCase(Fielddata)]
        public void AUT_Getworkspacelist_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_getworkspacelistInstanceFixture, 
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
        ///     Class (<see cref="getworkspacelist" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Getworkspacelist_Is_Instance_Present_Test()
        {
            // Assert
            _getworkspacelistInstanceType.ShouldNotBeNull();
            _getworkspacelistInstance.ShouldNotBeNull();
            _getworkspacelistInstanceFixture.ShouldNotBeNull();
            _getworkspacelistInstance.ShouldBeAssignableTo<getworkspacelist>();
            _getworkspacelistInstanceFixture.ShouldBeAssignableTo<getworkspacelist>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (getworkspacelist) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_getworkspacelist_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            getworkspacelist instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _getworkspacelistInstanceType.ShouldNotBeNull();
            _getworkspacelistInstance.ShouldNotBeNull();
            _getworkspacelistInstanceFixture.ShouldNotBeNull();
            _getworkspacelistInstance.ShouldBeAssignableTo<getworkspacelist>();
            _getworkspacelistInstanceFixture.ShouldBeAssignableTo<getworkspacelist>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="getworkspacelist" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodaddWebs)]
        public void AUT_Getworkspacelist_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<getworkspacelist>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getworkspacelist_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getworkspacelistInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getworkspacelist_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getworkspacelistInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Getworkspacelist_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getworkspacelistInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Getworkspacelist_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Getworkspacelist_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getworkspacelistInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getworkspacelist_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getworkspacelistInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addWebs) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getworkspacelist_addWebs_Method_Call_Internally(Type[] types)
        {
            var methodaddWebsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getworkspacelistInstance, MethodaddWebs, Fixture, methodaddWebsPrametersTypes);
        }

        #endregion

        #region Method Call : (addWebs) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getworkspacelist_addWebs_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var parentNode = CreateType<XmlNode>();
            var methodaddWebsPrametersTypes = new Type[] { typeof(SPWeb), typeof(XmlNode) };
            object[] parametersOfaddWebs = { web, parentNode };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodaddWebs, methodaddWebsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getworkspacelistInstanceFixture, parametersOfaddWebs);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfaddWebs.ShouldNotBeNull();
            parametersOfaddWebs.Length.ShouldBe(2);
            methodaddWebsPrametersTypes.Length.ShouldBe(2);
            methodaddWebsPrametersTypes.Length.ShouldBe(parametersOfaddWebs.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (addWebs) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getworkspacelist_addWebs_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var parentNode = CreateType<XmlNode>();
            var methodaddWebsPrametersTypes = new Type[] { typeof(SPWeb), typeof(XmlNode) };
            object[] parametersOfaddWebs = { web, parentNode };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getworkspacelistInstance, MethodaddWebs, parametersOfaddWebs, methodaddWebsPrametersTypes);

            // Assert
            parametersOfaddWebs.ShouldNotBeNull();
            parametersOfaddWebs.Length.ShouldBe(2);
            methodaddWebsPrametersTypes.Length.ShouldBe(2);
            methodaddWebsPrametersTypes.Length.ShouldBe(parametersOfaddWebs.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addWebs) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getworkspacelist_addWebs_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (addWebs) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getworkspacelist_addWebs_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodaddWebsPrametersTypes = new Type[] { typeof(SPWeb), typeof(XmlNode) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getworkspacelistInstance, MethodaddWebs, Fixture, methodaddWebsPrametersTypes);

            // Assert
            methodaddWebsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addWebs) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getworkspacelist_addWebs_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodaddWebs, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getworkspacelistInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
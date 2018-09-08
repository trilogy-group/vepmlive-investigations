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

namespace EPMLiveWebParts
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.listedititem" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ListedititemTest : AbstractBaseSetupTypedTest<listedititem>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (listedititem) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodListFormWebPart1_Init = "ListFormWebPart1_Init";
        private const string FieldListFormWebPart1 = "ListFormWebPart1";
        private const string FieldpageClose = "pageClose";
        private const string FieldstrGridId = "strGridId";
        private const string Fieldstrsiteid = "strsiteid";
        private const string Fieldstrwebid = "strwebid";
        private const string Fieldstrlistid = "strlistid";
        private const string Fieldstritemid = "stritemid";
        private const string Fieldstrrowid = "strrowid";
        private const string FieldwebUrl = "webUrl";
        private Type _listedititemInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private listedititem _listedititemInstance;
        private listedititem _listedititemInstanceFixture;

        #region General Initializer : Class (listedititem) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="listedititem" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _listedititemInstanceType = typeof(listedititem);
            _listedititemInstanceFixture = Create(true);
            _listedititemInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (listedititem)

        #region General Initializer : Class (listedititem) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="listedititem" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodListFormWebPart1_Init, 0)]
        public void AUT_Listedititem_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_listedititemInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (listedititem) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="listedititem" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldListFormWebPart1)]
        [TestCase(FieldpageClose)]
        [TestCase(FieldstrGridId)]
        [TestCase(Fieldstrsiteid)]
        [TestCase(Fieldstrwebid)]
        [TestCase(Fieldstrlistid)]
        [TestCase(Fieldstritemid)]
        [TestCase(Fieldstrrowid)]
        [TestCase(FieldwebUrl)]
        public void AUT_Listedititem_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_listedititemInstanceFixture, 
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
        ///     Class (<see cref="listedititem" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Listedititem_Is_Instance_Present_Test()
        {
            // Assert
            _listedititemInstanceType.ShouldNotBeNull();
            _listedititemInstance.ShouldNotBeNull();
            _listedititemInstanceFixture.ShouldNotBeNull();
            _listedititemInstance.ShouldBeAssignableTo<listedititem>();
            _listedititemInstanceFixture.ShouldBeAssignableTo<listedititem>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (listedititem) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_listedititem_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            listedititem instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _listedititemInstanceType.ShouldNotBeNull();
            _listedititemInstance.ShouldNotBeNull();
            _listedititemInstanceFixture.ShouldNotBeNull();
            _listedititemInstance.ShouldBeAssignableTo<listedititem>();
            _listedititemInstanceFixture.ShouldBeAssignableTo<listedititem>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="listedititem" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodListFormWebPart1_Init)]
        public void AUT_Listedititem_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<listedititem>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Listedititem_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listedititemInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Listedititem_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listedititemInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Listedititem_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listedititemInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Listedititem_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Listedititem_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listedititemInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Listedititem_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listedititemInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ListFormWebPart1_Init) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Listedititem_ListFormWebPart1_Init_Method_Call_Internally(Type[] types)
        {
            var methodListFormWebPart1_InitPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listedititemInstance, MethodListFormWebPart1_Init, Fixture, methodListFormWebPart1_InitPrametersTypes);
        }

        #endregion

        #region Method Call : (ListFormWebPart1_Init) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Listedititem_ListFormWebPart1_Init_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodListFormWebPart1_InitPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfListFormWebPart1_Init = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodListFormWebPart1_Init, methodListFormWebPart1_InitPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listedititemInstanceFixture, parametersOfListFormWebPart1_Init);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfListFormWebPart1_Init.ShouldNotBeNull();
            parametersOfListFormWebPart1_Init.Length.ShouldBe(2);
            methodListFormWebPart1_InitPrametersTypes.Length.ShouldBe(2);
            methodListFormWebPart1_InitPrametersTypes.Length.ShouldBe(parametersOfListFormWebPart1_Init.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ListFormWebPart1_Init) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Listedititem_ListFormWebPart1_Init_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodListFormWebPart1_InitPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfListFormWebPart1_Init = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listedititemInstance, MethodListFormWebPart1_Init, parametersOfListFormWebPart1_Init, methodListFormWebPart1_InitPrametersTypes);

            // Assert
            parametersOfListFormWebPart1_Init.ShouldNotBeNull();
            parametersOfListFormWebPart1_Init.Length.ShouldBe(2);
            methodListFormWebPart1_InitPrametersTypes.Length.ShouldBe(2);
            methodListFormWebPart1_InitPrametersTypes.Length.ShouldBe(parametersOfListFormWebPart1_Init.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ListFormWebPart1_Init) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Listedititem_ListFormWebPart1_Init_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodListFormWebPart1_Init, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ListFormWebPart1_Init) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Listedititem_ListFormWebPart1_Init_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodListFormWebPart1_InitPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listedititemInstance, MethodListFormWebPart1_Init, Fixture, methodListFormWebPart1_InitPrametersTypes);

            // Assert
            methodListFormWebPart1_InitPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ListFormWebPart1_Init) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Listedititem_ListFormWebPart1_Init_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodListFormWebPart1_Init, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listedititemInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
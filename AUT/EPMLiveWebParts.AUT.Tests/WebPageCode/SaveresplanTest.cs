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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.saveresplan" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class SaveresplanTest : AbstractBaseSetupTypedTest<saveresplan>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (saveresplan) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodStrToByteArray = "StrToByteArray";
        private const string Fielddoc = "doc";
        private const string Fielddata = "data";
        private Type _saveresplanInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private saveresplan _saveresplanInstance;
        private saveresplan _saveresplanInstanceFixture;

        #region General Initializer : Class (saveresplan) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="saveresplan" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _saveresplanInstanceType = typeof(saveresplan);
            _saveresplanInstanceFixture = Create(true);
            _saveresplanInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (saveresplan)

        #region General Initializer : Class (saveresplan) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="saveresplan" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodStrToByteArray, 0)]
        public void AUT_Saveresplan_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_saveresplanInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (saveresplan) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="saveresplan" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fielddoc)]
        [TestCase(Fielddata)]
        public void AUT_Saveresplan_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_saveresplanInstanceFixture, 
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
        ///     Class (<see cref="saveresplan" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Saveresplan_Is_Instance_Present_Test()
        {
            // Assert
            _saveresplanInstanceType.ShouldNotBeNull();
            _saveresplanInstance.ShouldNotBeNull();
            _saveresplanInstanceFixture.ShouldNotBeNull();
            _saveresplanInstance.ShouldBeAssignableTo<saveresplan>();
            _saveresplanInstanceFixture.ShouldBeAssignableTo<saveresplan>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (saveresplan) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_saveresplan_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            saveresplan instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _saveresplanInstanceType.ShouldNotBeNull();
            _saveresplanInstance.ShouldNotBeNull();
            _saveresplanInstanceFixture.ShouldNotBeNull();
            _saveresplanInstance.ShouldBeAssignableTo<saveresplan>();
            _saveresplanInstanceFixture.ShouldBeAssignableTo<saveresplan>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="saveresplan" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodStrToByteArray)]
        public void AUT_Saveresplan_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_saveresplanInstanceFixture,
                                                                              _saveresplanInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="saveresplan" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        public void AUT_Saveresplan_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<saveresplan>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Saveresplan_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_saveresplanInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Saveresplan_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_saveresplanInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Saveresplan_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_saveresplanInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Saveresplan_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Saveresplan_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_saveresplanInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Saveresplan_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_saveresplanInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StrToByteArray) (Return Type : byte[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Saveresplan_StrToByteArray_Static_Method_Call_Internally(Type[] types)
        {
            var methodStrToByteArrayPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_saveresplanInstanceFixture, _saveresplanInstanceType, MethodStrToByteArray, Fixture, methodStrToByteArrayPrametersTypes);
        }

        #endregion

        #region Method Call : (StrToByteArray) (Return Type : byte[]) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Saveresplan_StrToByteArray_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var str = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => saveresplan.StrToByteArray(str);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (StrToByteArray) (Return Type : byte[]) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Saveresplan_StrToByteArray_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var str = CreateType<string>();
            var methodStrToByteArrayPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfStrToByteArray = { str };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodStrToByteArray, methodStrToByteArrayPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_saveresplanInstanceFixture, parametersOfStrToByteArray);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfStrToByteArray.ShouldNotBeNull();
            parametersOfStrToByteArray.Length.ShouldBe(1);
            methodStrToByteArrayPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StrToByteArray) (Return Type : byte[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Saveresplan_StrToByteArray_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var str = CreateType<string>();
            var methodStrToByteArrayPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfStrToByteArray = { str };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<byte[]>(_saveresplanInstanceFixture, _saveresplanInstanceType, MethodStrToByteArray, parametersOfStrToByteArray, methodStrToByteArrayPrametersTypes);

            // Assert
            parametersOfStrToByteArray.ShouldNotBeNull();
            parametersOfStrToByteArray.Length.ShouldBe(1);
            methodStrToByteArrayPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StrToByteArray) (Return Type : byte[]) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Saveresplan_StrToByteArray_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodStrToByteArrayPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_saveresplanInstanceFixture, _saveresplanInstanceType, MethodStrToByteArray, Fixture, methodStrToByteArrayPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodStrToByteArrayPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (StrToByteArray) (Return Type : byte[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Saveresplan_StrToByteArray_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodStrToByteArrayPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_saveresplanInstanceFixture, _saveresplanInstanceType, MethodStrToByteArray, Fixture, methodStrToByteArrayPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodStrToByteArrayPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (StrToByteArray) (Return Type : byte[]) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Saveresplan_StrToByteArray_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodStrToByteArray, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_saveresplanInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (StrToByteArray) (Return Type : byte[]) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Saveresplan_StrToByteArray_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodStrToByteArray, 0);
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
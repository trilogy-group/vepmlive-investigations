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

namespace WorkEnginePPM
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.vb" />)
    ///     and namespace <see cref="WorkEnginePPM"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class VbTest : AbstractBaseSetupTypedTest<vb>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (vb) Initializer

        private const string MethodIIf = "IIf";
        private const string Methodval = "val";
        private const string MethodMax = "Max";
        private const string MethodLeft = "Left";
        private Type _vbInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private vb _vbInstance;
        private vb _vbInstanceFixture;

        #region General Initializer : Class (vb) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="vb" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _vbInstanceType = typeof(vb);
            _vbInstanceFixture = Create(true);
            _vbInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (vb)

        #region General Initializer : Class (vb) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="vb" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodIIf, 0)]
        [TestCase(Methodval, 0)]
        [TestCase(MethodMax, 0)]
        [TestCase(MethodLeft, 0)]
        public void AUT_Vb_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_vbInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="vb" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Vb_Is_Instance_Present_Test()
        {
            // Assert
            _vbInstanceType.ShouldNotBeNull();
            _vbInstance.ShouldNotBeNull();
            _vbInstanceFixture.ShouldNotBeNull();
            _vbInstance.ShouldBeAssignableTo<vb>();
            _vbInstanceFixture.ShouldBeAssignableTo<vb>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (vb) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_vb_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            vb instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _vbInstanceType.ShouldNotBeNull();
            _vbInstance.ShouldNotBeNull();
            _vbInstanceFixture.ShouldNotBeNull();
            _vbInstance.ShouldBeAssignableTo<vb>();
            _vbInstanceFixture.ShouldBeAssignableTo<vb>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="vb" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodIIf)]
        [TestCase(Methodval)]
        [TestCase(MethodMax)]
        [TestCase(MethodLeft)]
        public void AUT_Vb_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_vbInstanceFixture,
                                                                              _vbInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (IIf) (Return Type : object) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Vb_IIf_Static_Method_Call_Internally(Type[] types)
        {
            var methodIIfPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_vbInstanceFixture, _vbInstanceType, MethodIIf, Fixture, methodIIfPrametersTypes);
        }

        #endregion

        #region Method Call : (IIf) (Return Type : object) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Vb_IIf_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var Expression = CreateType<bool>();
            var TruePart = CreateType<object>();
            var FalsePart = CreateType<object>();
            Action executeAction = null;

            // Act
            executeAction = () => vb.IIf(Expression, TruePart, FalsePart);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (IIf) (Return Type : object) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Vb_IIf_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var Expression = CreateType<bool>();
            var TruePart = CreateType<object>();
            var FalsePart = CreateType<object>();
            var methodIIfPrametersTypes = new Type[] { typeof(bool), typeof(object), typeof(object) };
            object[] parametersOfIIf = { Expression, TruePart, FalsePart };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodIIf, methodIIfPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_vbInstanceFixture, parametersOfIIf);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfIIf.ShouldNotBeNull();
            parametersOfIIf.Length.ShouldBe(3);
            methodIIfPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IIf) (Return Type : object) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Vb_IIf_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Expression = CreateType<bool>();
            var TruePart = CreateType<object>();
            var FalsePart = CreateType<object>();
            var methodIIfPrametersTypes = new Type[] { typeof(bool), typeof(object), typeof(object) };
            object[] parametersOfIIf = { Expression, TruePart, FalsePart };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<object>(_vbInstanceFixture, _vbInstanceType, MethodIIf, parametersOfIIf, methodIIfPrametersTypes);

            // Assert
            parametersOfIIf.ShouldNotBeNull();
            parametersOfIIf.Length.ShouldBe(3);
            methodIIfPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IIf) (Return Type : object) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Vb_IIf_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodIIfPrametersTypes = new Type[] { typeof(bool), typeof(object), typeof(object) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_vbInstanceFixture, _vbInstanceType, MethodIIf, Fixture, methodIIfPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodIIfPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (IIf) (Return Type : object) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Vb_IIf_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIIfPrametersTypes = new Type[] { typeof(bool), typeof(object), typeof(object) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_vbInstanceFixture, _vbInstanceType, MethodIIf, Fixture, methodIIfPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIIfPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IIf) (Return Type : object) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Vb_IIf_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIIf, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_vbInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (IIf) (Return Type : object) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Vb_IIf_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodIIf, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (val) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Vb_val_Static_Method_Call_Internally(Type[] types)
        {
            var methodvalPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_vbInstanceFixture, _vbInstanceType, Methodval, Fixture, methodvalPrametersTypes);
        }

        #endregion

        #region Method Call : (val) (Return Type : int) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Vb_val_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sInteger = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => vb.val(sInteger);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (val) (Return Type : int) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Vb_val_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sInteger = CreateType<string>();
            var methodvalPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfval = { sInteger };
            Exception exception = null;
            var methodInfo = GetMethodInfo(Methodval, methodvalPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_vbInstanceFixture, parametersOfval);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfval.ShouldNotBeNull();
            parametersOfval.Length.ShouldBe(1);
            methodvalPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (val) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Vb_val_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sInteger = CreateType<string>();
            var methodvalPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfval = { sInteger };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<int>(_vbInstanceFixture, _vbInstanceType, Methodval, parametersOfval, methodvalPrametersTypes);

            // Assert
            parametersOfval.ShouldNotBeNull();
            parametersOfval.Length.ShouldBe(1);
            methodvalPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (val) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Vb_val_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodvalPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_vbInstanceFixture, _vbInstanceType, Methodval, Fixture, methodvalPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodvalPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (val) (Return Type : int) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Vb_val_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodvalPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_vbInstanceFixture, _vbInstanceType, Methodval, Fixture, methodvalPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodvalPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (val) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Vb_val_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodvalPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_vbInstanceFixture, _vbInstanceType, Methodval, Fixture, methodvalPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodvalPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (val) (Return Type : int) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Vb_val_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(Methodval, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_vbInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (val) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Vb_val_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(Methodval, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Max) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Vb_Max_Static_Method_Call_Internally(Type[] types)
        {
            var methodMaxPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_vbInstanceFixture, _vbInstanceType, MethodMax, Fixture, methodMaxPrametersTypes);
        }

        #endregion

        #region Method Call : (Max) (Return Type : int) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Vb_Max_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var p0 = CreateType<int>();
            var p1 = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => vb.Max(p0, p1);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Max) (Return Type : int) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Vb_Max_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var p0 = CreateType<int>();
            var p1 = CreateType<int>();
            var methodMaxPrametersTypes = new Type[] { typeof(int), typeof(int) };
            object[] parametersOfMax = { p0, p1 };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodMax, methodMaxPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_vbInstanceFixture, parametersOfMax);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfMax.ShouldNotBeNull();
            parametersOfMax.Length.ShouldBe(2);
            methodMaxPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Max) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Vb_Max_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var p0 = CreateType<int>();
            var p1 = CreateType<int>();
            var methodMaxPrametersTypes = new Type[] { typeof(int), typeof(int) };
            object[] parametersOfMax = { p0, p1 };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<int>(_vbInstanceFixture, _vbInstanceType, MethodMax, parametersOfMax, methodMaxPrametersTypes);

            // Assert
            parametersOfMax.ShouldNotBeNull();
            parametersOfMax.Length.ShouldBe(2);
            methodMaxPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Max) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Vb_Max_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodMaxPrametersTypes = new Type[] { typeof(int), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_vbInstanceFixture, _vbInstanceType, MethodMax, Fixture, methodMaxPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodMaxPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (Max) (Return Type : int) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Vb_Max_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodMaxPrametersTypes = new Type[] { typeof(int), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_vbInstanceFixture, _vbInstanceType, MethodMax, Fixture, methodMaxPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodMaxPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (Max) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Vb_Max_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodMaxPrametersTypes = new Type[] { typeof(int), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_vbInstanceFixture, _vbInstanceType, MethodMax, Fixture, methodMaxPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodMaxPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Max) (Return Type : int) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Vb_Max_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodMax, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_vbInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (Max) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Vb_Max_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodMax, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Left) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Vb_Left_Static_Method_Call_Internally(Type[] types)
        {
            var methodLeftPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_vbInstanceFixture, _vbInstanceType, MethodLeft, Fixture, methodLeftPrametersTypes);
        }

        #endregion

        #region Method Call : (Left) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Vb_Left_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var s = CreateType<string>();
            var nLen = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => vb.Left(s, nLen);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Left) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Vb_Left_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var s = CreateType<string>();
            var nLen = CreateType<int>();
            var methodLeftPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfLeft = { s, nLen };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodLeft, methodLeftPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_vbInstanceFixture, parametersOfLeft);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfLeft.ShouldNotBeNull();
            parametersOfLeft.Length.ShouldBe(2);
            methodLeftPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Left) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Vb_Left_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var s = CreateType<string>();
            var nLen = CreateType<int>();
            var methodLeftPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfLeft = { s, nLen };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_vbInstanceFixture, _vbInstanceType, MethodLeft, parametersOfLeft, methodLeftPrametersTypes);

            // Assert
            parametersOfLeft.ShouldNotBeNull();
            parametersOfLeft.Length.ShouldBe(2);
            methodLeftPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Left) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Vb_Left_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodLeftPrametersTypes = new Type[] { typeof(string), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_vbInstanceFixture, _vbInstanceType, MethodLeft, Fixture, methodLeftPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodLeftPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (Left) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Vb_Left_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLeftPrametersTypes = new Type[] { typeof(string), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_vbInstanceFixture, _vbInstanceType, MethodLeft, Fixture, methodLeftPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodLeftPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Left) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Vb_Left_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLeft, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_vbInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (Left) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Vb_Left_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodLeft, 0);
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
using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using EPMLiveWebParts.EpmCharting.DomainModel;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts.EpmCharting.DomainServices
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.EpmCharting.DomainServices.ChartHelper" />)
    ///     and namespace <see cref="EPMLiveWebParts.EpmCharting.DomainServices"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ChartHelperTest : AbstractBaseSetupTypedTest<ChartHelper>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ChartHelper) Initializer

        private const string MethodIsCalculateableSharepointField = "IsCalculateableSharepointField";
        private const string MethodParseDouble = "ParseDouble";
        private Type _chartHelperInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ChartHelper _chartHelperInstance;
        private ChartHelper _chartHelperInstanceFixture;

        #region General Initializer : Class (ChartHelper) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ChartHelper" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _chartHelperInstanceType = typeof(ChartHelper);
            _chartHelperInstanceFixture = Create(true);
            _chartHelperInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ChartHelper)

        #region General Initializer : Class (ChartHelper) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ChartHelper" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodIsCalculateableSharepointField, 0)]
        [TestCase(MethodParseDouble, 0)]
        [TestCase(MethodParseDouble, 1)]
        public void AUT_ChartHelper_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_chartHelperInstanceFixture, 
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
        ///     Class (<see cref="ChartHelper" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ChartHelper_Is_Instance_Present_Test()
        {
            // Assert
            _chartHelperInstanceType.ShouldNotBeNull();
            _chartHelperInstance.ShouldNotBeNull();
            _chartHelperInstanceFixture.ShouldNotBeNull();
            _chartHelperInstance.ShouldBeAssignableTo<ChartHelper>();
            _chartHelperInstanceFixture.ShouldBeAssignableTo<ChartHelper>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ChartHelper) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ChartHelper_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ChartHelper instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _chartHelperInstanceType.ShouldNotBeNull();
            _chartHelperInstance.ShouldNotBeNull();
            _chartHelperInstanceFixture.ShouldNotBeNull();
            _chartHelperInstance.ShouldBeAssignableTo<ChartHelper>();
            _chartHelperInstanceFixture.ShouldBeAssignableTo<ChartHelper>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="ChartHelper" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodIsCalculateableSharepointField)]
        [TestCase(MethodParseDouble)]
        public void AUT_ChartHelper_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_chartHelperInstanceFixture,
                                                                              _chartHelperInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (IsCalculateableSharepointField) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartHelper_IsCalculateableSharepointField_Static_Method_Call_Internally(Type[] types)
        {
            var methodIsCalculateableSharepointFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_chartHelperInstanceFixture, _chartHelperInstanceType, MethodIsCalculateableSharepointField, Fixture, methodIsCalculateableSharepointFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (IsCalculateableSharepointField) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartHelper_IsCalculateableSharepointField_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var fld = CreateType<SPField>();
            Action executeAction = null;

            // Act
            executeAction = () => ChartHelper.IsCalculateableSharepointField(fld);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (IsCalculateableSharepointField) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartHelper_IsCalculateableSharepointField_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var fld = CreateType<SPField>();
            var methodIsCalculateableSharepointFieldPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfIsCalculateableSharepointField = { fld };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_chartHelperInstanceFixture, _chartHelperInstanceType, MethodIsCalculateableSharepointField, parametersOfIsCalculateableSharepointField, methodIsCalculateableSharepointFieldPrametersTypes);

            // Assert
            parametersOfIsCalculateableSharepointField.ShouldNotBeNull();
            parametersOfIsCalculateableSharepointField.Length.ShouldBe(1);
            methodIsCalculateableSharepointFieldPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsCalculateableSharepointField) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartHelper_IsCalculateableSharepointField_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsCalculateableSharepointFieldPrametersTypes = new Type[] { typeof(SPField) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_chartHelperInstanceFixture, _chartHelperInstanceType, MethodIsCalculateableSharepointField, Fixture, methodIsCalculateableSharepointFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsCalculateableSharepointFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsCalculateableSharepointField) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartHelper_IsCalculateableSharepointField_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsCalculateableSharepointField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_chartHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsCalculateableSharepointField) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartHelper_IsCalculateableSharepointField_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodIsCalculateableSharepointField, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ParseDouble) (Return Type : double) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartHelper_ParseDouble_Static_Method_Call_Internally(Type[] types)
        {
            var methodParseDoublePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_chartHelperInstanceFixture, _chartHelperInstanceType, MethodParseDouble, Fixture, methodParseDoublePrametersTypes);
        }

        #endregion

        #region Method Call : (ParseDouble) (Return Type : double) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartHelper_ParseDouble_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var doubleAsString = CreateType<string>();
            var formatProvider = CreateType<IFormatProvider>();
            var aggregateType = CreateType<EpmChartAggregateType>();
            Action executeAction = null;

            // Act
            executeAction = () => ChartHelper.ParseDouble(doubleAsString, formatProvider, aggregateType);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ParseDouble) (Return Type : double) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartHelper_ParseDouble_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var doubleAsString = CreateType<string>();
            var formatProvider = CreateType<IFormatProvider>();
            var aggregateType = CreateType<EpmChartAggregateType>();
            var methodParseDoublePrametersTypes = new Type[] { typeof(string), typeof(IFormatProvider), typeof(EpmChartAggregateType) };
            object[] parametersOfParseDouble = { doubleAsString, formatProvider, aggregateType };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodParseDouble, methodParseDoublePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_chartHelperInstanceFixture, _chartHelperInstanceType, MethodParseDouble, Fixture, methodParseDoublePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<double>(_chartHelperInstanceFixture, _chartHelperInstanceType, MethodParseDouble, parametersOfParseDouble, methodParseDoublePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfParseDouble.ShouldNotBeNull();
            parametersOfParseDouble.Length.ShouldBe(3);
            methodParseDoublePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<double>(_chartHelperInstanceFixture, _chartHelperInstanceType, MethodParseDouble, parametersOfParseDouble, methodParseDoublePrametersTypes));
        }

        #endregion

        #region Method Call : (ParseDouble) (Return Type : double) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartHelper_ParseDouble_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var doubleAsString = CreateType<string>();
            var formatProvider = CreateType<IFormatProvider>();
            var aggregateType = CreateType<EpmChartAggregateType>();
            var methodParseDoublePrametersTypes = new Type[] { typeof(string), typeof(IFormatProvider), typeof(EpmChartAggregateType) };
            object[] parametersOfParseDouble = { doubleAsString, formatProvider, aggregateType };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodParseDouble, methodParseDoublePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartHelperInstanceFixture, parametersOfParseDouble);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfParseDouble.ShouldNotBeNull();
            parametersOfParseDouble.Length.ShouldBe(3);
            methodParseDoublePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ParseDouble) (Return Type : double) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartHelper_ParseDouble_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var doubleAsString = CreateType<string>();
            var formatProvider = CreateType<IFormatProvider>();
            var aggregateType = CreateType<EpmChartAggregateType>();
            var methodParseDoublePrametersTypes = new Type[] { typeof(string), typeof(IFormatProvider), typeof(EpmChartAggregateType) };
            object[] parametersOfParseDouble = { doubleAsString, formatProvider, aggregateType };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<double>(_chartHelperInstanceFixture, _chartHelperInstanceType, MethodParseDouble, parametersOfParseDouble, methodParseDoublePrametersTypes);

            // Assert
            parametersOfParseDouble.ShouldNotBeNull();
            parametersOfParseDouble.Length.ShouldBe(3);
            methodParseDoublePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ParseDouble) (Return Type : double) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartHelper_ParseDouble_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodParseDoublePrametersTypes = new Type[] { typeof(string), typeof(IFormatProvider), typeof(EpmChartAggregateType) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_chartHelperInstanceFixture, _chartHelperInstanceType, MethodParseDouble, Fixture, methodParseDoublePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodParseDoublePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (ParseDouble) (Return Type : double) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartHelper_ParseDouble_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodParseDoublePrametersTypes = new Type[] { typeof(string), typeof(IFormatProvider), typeof(EpmChartAggregateType) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_chartHelperInstanceFixture, _chartHelperInstanceType, MethodParseDouble, Fixture, methodParseDoublePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodParseDoublePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (ParseDouble) (Return Type : double) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartHelper_ParseDouble_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodParseDoublePrametersTypes = new Type[] { typeof(string), typeof(IFormatProvider), typeof(EpmChartAggregateType) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_chartHelperInstanceFixture, _chartHelperInstanceType, MethodParseDouble, Fixture, methodParseDoublePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodParseDoublePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ParseDouble) (Return Type : double) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartHelper_ParseDouble_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodParseDouble, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_chartHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ParseDouble) (Return Type : double) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartHelper_ParseDouble_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodParseDouble, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ParseDouble) (Return Type : double) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartHelper_ParseDouble_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodParseDoublePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_chartHelperInstanceFixture, _chartHelperInstanceType, MethodParseDouble, Fixture, methodParseDoublePrametersTypes);
        }

        #endregion

        #region Method Call : (ParseDouble) (Return Type : double) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartHelper_ParseDouble_Static_Method_DirectCall_Overloading_Of_1_No_Exception_Thrown_Test()
        {
            // Arrange
            var doubleAsString = CreateType<string>();
            var formatProvider = CreateType<IFormatProvider>();
            var aggregateType = CreateType<EpmChartAggregateType>();
            var isCurrency = CreateType<Boolean>();
            Action executeAction = null;

            // Act
            executeAction = () => ChartHelper.ParseDouble(doubleAsString, formatProvider, aggregateType, isCurrency);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ParseDouble) (Return Type : double) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartHelper_ParseDouble_Static_Method_Call_Overloading_Of_1_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var doubleAsString = CreateType<string>();
            var formatProvider = CreateType<IFormatProvider>();
            var aggregateType = CreateType<EpmChartAggregateType>();
            var isCurrency = CreateType<Boolean>();
            var methodParseDoublePrametersTypes = new Type[] { typeof(string), typeof(IFormatProvider), typeof(EpmChartAggregateType), typeof(Boolean) };
            object[] parametersOfParseDouble = { doubleAsString, formatProvider, aggregateType, isCurrency };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodParseDouble, methodParseDoublePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_chartHelperInstanceFixture, _chartHelperInstanceType, MethodParseDouble, Fixture, methodParseDoublePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<double>(_chartHelperInstanceFixture, _chartHelperInstanceType, MethodParseDouble, parametersOfParseDouble, methodParseDoublePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfParseDouble.ShouldNotBeNull();
            parametersOfParseDouble.Length.ShouldBe(4);
            methodParseDoublePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<double>(_chartHelperInstanceFixture, _chartHelperInstanceType, MethodParseDouble, parametersOfParseDouble, methodParseDoublePrametersTypes));
        }

        #endregion

        #region Method Call : (ParseDouble) (Return Type : double) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartHelper_ParseDouble_Static_Method_Call_Overloading_Of_1_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var doubleAsString = CreateType<string>();
            var formatProvider = CreateType<IFormatProvider>();
            var aggregateType = CreateType<EpmChartAggregateType>();
            var isCurrency = CreateType<Boolean>();
            var methodParseDoublePrametersTypes = new Type[] { typeof(string), typeof(IFormatProvider), typeof(EpmChartAggregateType), typeof(Boolean) };
            object[] parametersOfParseDouble = { doubleAsString, formatProvider, aggregateType, isCurrency };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodParseDouble, methodParseDoublePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartHelperInstanceFixture, parametersOfParseDouble);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfParseDouble.ShouldNotBeNull();
            parametersOfParseDouble.Length.ShouldBe(4);
            methodParseDoublePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ParseDouble) (Return Type : double) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartHelper_ParseDouble_Static_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var doubleAsString = CreateType<string>();
            var formatProvider = CreateType<IFormatProvider>();
            var aggregateType = CreateType<EpmChartAggregateType>();
            var isCurrency = CreateType<Boolean>();
            var methodParseDoublePrametersTypes = new Type[] { typeof(string), typeof(IFormatProvider), typeof(EpmChartAggregateType), typeof(Boolean) };
            object[] parametersOfParseDouble = { doubleAsString, formatProvider, aggregateType, isCurrency };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<double>(_chartHelperInstanceFixture, _chartHelperInstanceType, MethodParseDouble, parametersOfParseDouble, methodParseDoublePrametersTypes);

            // Assert
            parametersOfParseDouble.ShouldNotBeNull();
            parametersOfParseDouble.Length.ShouldBe(4);
            methodParseDoublePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ParseDouble) (Return Type : double) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartHelper_ParseDouble_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodParseDoublePrametersTypes = new Type[] { typeof(string), typeof(IFormatProvider), typeof(EpmChartAggregateType), typeof(Boolean) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_chartHelperInstanceFixture, _chartHelperInstanceType, MethodParseDouble, Fixture, methodParseDoublePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodParseDoublePrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (ParseDouble) (Return Type : double) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartHelper_ParseDouble_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodParseDoublePrametersTypes = new Type[] { typeof(string), typeof(IFormatProvider), typeof(EpmChartAggregateType), typeof(Boolean) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_chartHelperInstanceFixture, _chartHelperInstanceType, MethodParseDouble, Fixture, methodParseDoublePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodParseDoublePrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (ParseDouble) (Return Type : double) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartHelper_ParseDouble_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodParseDoublePrametersTypes = new Type[] { typeof(string), typeof(IFormatProvider), typeof(EpmChartAggregateType), typeof(Boolean) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_chartHelperInstanceFixture, _chartHelperInstanceType, MethodParseDouble, Fixture, methodParseDoublePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodParseDoublePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ParseDouble) (Return Type : double) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartHelper_ParseDouble_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodParseDouble, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_chartHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ParseDouble) (Return Type : double) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartHelper_ParseDouble_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodParseDouble, 1);
            const int parametersCount = 4;

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
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

namespace PortfolioEngineCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PortfolioEngineCore.EPKClass01" />)
    ///     and namespace <see cref="PortfolioEngineCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class EPKClass01Test : AbstractBaseSetupTypedTest<EPKClass01>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EPKClass01) Initializer

        private const string MethodGetEntityID = "GetEntityID";
        private const string MethodGetEntity = "GetEntity";
        private const string MethodGetFieldFormat = "GetFieldFormat";
        private const string MethodGetTableAndField = "GetTableAndField";
        private const string MethodGetTableID = "GetTableID";
        private Type _ePKClass01InstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private EPKClass01 _ePKClass01Instance;
        private EPKClass01 _ePKClass01InstanceFixture;

        #region General Initializer : Class (EPKClass01) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EPKClass01" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _ePKClass01InstanceType = typeof(EPKClass01);
            _ePKClass01InstanceFixture = Create(true);
            _ePKClass01Instance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (EPKClass01)

        #region General Initializer : Class (EPKClass01) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="EPKClass01" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetEntityID, 0)]
        [TestCase(MethodGetEntity, 0)]
        [TestCase(MethodGetFieldFormat, 0)]
        [TestCase(MethodGetTableAndField, 0)]
        [TestCase(MethodGetTableID, 0)]
        public void AUT_EPKClass01_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_ePKClass01InstanceFixture, 
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
        ///     Class (<see cref="EPKClass01" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_EPKClass01_Is_Instance_Present_Test()
        {
            // Assert
            _ePKClass01InstanceType.ShouldNotBeNull();
            _ePKClass01Instance.ShouldNotBeNull();
            _ePKClass01InstanceFixture.ShouldNotBeNull();
            _ePKClass01Instance.ShouldBeAssignableTo<EPKClass01>();
            _ePKClass01InstanceFixture.ShouldBeAssignableTo<EPKClass01>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (EPKClass01) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_EPKClass01_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            EPKClass01 instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _ePKClass01InstanceType.ShouldNotBeNull();
            _ePKClass01Instance.ShouldNotBeNull();
            _ePKClass01InstanceFixture.ShouldNotBeNull();
            _ePKClass01Instance.ShouldBeAssignableTo<EPKClass01>();
            _ePKClass01InstanceFixture.ShouldBeAssignableTo<EPKClass01>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="EPKClass01" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetEntityID)]
        [TestCase(MethodGetEntity)]
        [TestCase(MethodGetFieldFormat)]
        [TestCase(MethodGetTableAndField)]
        [TestCase(MethodGetTableID)]
        public void AUT_EPKClass01_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_ePKClass01InstanceFixture,
                                                                              _ePKClass01InstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (GetEntityID) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPKClass01_GetEntityID_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetEntityIDPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePKClass01InstanceFixture, _ePKClass01InstanceType, MethodGetEntityID, Fixture, methodGetEntityIDPrametersTypes);
        }

        #endregion

        #region Method Call : (GetEntityID) (Return Type : int) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKClass01_GetEntityID_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var iTable = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => EPKClass01.GetEntityID(iTable);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion
        
        #region Method Call : (GetEntityID) (Return Type : int) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKClass01_GetEntityID_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var iTable = CreateType<int>();
            var methodGetEntityIDPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfGetEntityID = { iTable };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetEntityID, methodGetEntityIDPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePKClass01InstanceFixture, parametersOfGetEntityID);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetEntityID.ShouldNotBeNull();
            parametersOfGetEntityID.Length.ShouldBe(1);
            methodGetEntityIDPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetEntityID) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKClass01_GetEntityID_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var iTable = CreateType<int>();
            var methodGetEntityIDPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfGetEntityID = { iTable };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<int>(_ePKClass01InstanceFixture, _ePKClass01InstanceType, MethodGetEntityID, parametersOfGetEntityID, methodGetEntityIDPrametersTypes);

            // Assert
            parametersOfGetEntityID.ShouldNotBeNull();
            parametersOfGetEntityID.Length.ShouldBe(1);
            methodGetEntityIDPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetEntityID) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKClass01_GetEntityID_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetEntityIDPrametersTypes = new Type[] { typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePKClass01InstanceFixture, _ePKClass01InstanceType, MethodGetEntityID, Fixture, methodGetEntityIDPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetEntityIDPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetEntityID) (Return Type : int) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKClass01_GetEntityID_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetEntityIDPrametersTypes = new Type[] { typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePKClass01InstanceFixture, _ePKClass01InstanceType, MethodGetEntityID, Fixture, methodGetEntityIDPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetEntityIDPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetEntityID) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKClass01_GetEntityID_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetEntityIDPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePKClass01InstanceFixture, _ePKClass01InstanceType, MethodGetEntityID, Fixture, methodGetEntityIDPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetEntityIDPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetEntityID) (Return Type : int) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKClass01_GetEntityID_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetEntityID, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePKClass01InstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetEntityID) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKClass01_GetEntityID_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetEntityID, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetEntity) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPKClass01_GetEntity_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetEntityPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePKClass01InstanceFixture, _ePKClass01InstanceType, MethodGetEntity, Fixture, methodGetEntityPrametersTypes);
        }

        #endregion

        #region Method Call : (GetEntity) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKClass01_GetEntity_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var iEntity = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => EPKClass01.GetEntity(iEntity);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetEntity) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKClass01_GetEntity_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var iEntity = CreateType<int>();
            var methodGetEntityPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfGetEntity = { iEntity };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetEntity, methodGetEntityPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePKClass01InstanceFixture, parametersOfGetEntity);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetEntity.ShouldNotBeNull();
            parametersOfGetEntity.Length.ShouldBe(1);
            methodGetEntityPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetEntity) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKClass01_GetEntity_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var iEntity = CreateType<int>();
            var methodGetEntityPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfGetEntity = { iEntity };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_ePKClass01InstanceFixture, _ePKClass01InstanceType, MethodGetEntity, parametersOfGetEntity, methodGetEntityPrametersTypes);

            // Assert
            parametersOfGetEntity.ShouldNotBeNull();
            parametersOfGetEntity.Length.ShouldBe(1);
            methodGetEntityPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetEntity) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKClass01_GetEntity_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetEntityPrametersTypes = new Type[] { typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePKClass01InstanceFixture, _ePKClass01InstanceType, MethodGetEntity, Fixture, methodGetEntityPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetEntityPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetEntity) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKClass01_GetEntity_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetEntityPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePKClass01InstanceFixture, _ePKClass01InstanceType, MethodGetEntity, Fixture, methodGetEntityPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetEntityPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetEntity) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKClass01_GetEntity_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetEntity, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePKClass01InstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetEntity) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKClass01_GetEntity_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetEntity, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFieldFormat) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPKClass01_GetFieldFormat_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFieldFormatPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePKClass01InstanceFixture, _ePKClass01InstanceType, MethodGetFieldFormat, Fixture, methodGetFieldFormatPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFieldFormat) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKClass01_GetFieldFormat_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var iDataType = CreateType<int>();
            var bIsDeprecated = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => EPKClass01.GetFieldFormat(iDataType, out bIsDeprecated);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetFieldFormat) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKClass01_GetFieldFormat_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var iDataType = CreateType<int>();
            var bIsDeprecated = CreateType<bool>();
            var methodGetFieldFormatPrametersTypes = new Type[] { typeof(int), typeof(bool) };
            object[] parametersOfGetFieldFormat = { iDataType, bIsDeprecated };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetFieldFormat, methodGetFieldFormatPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePKClass01InstanceFixture, parametersOfGetFieldFormat);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetFieldFormat.ShouldNotBeNull();
            parametersOfGetFieldFormat.Length.ShouldBe(2);
            methodGetFieldFormatPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFieldFormat) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKClass01_GetFieldFormat_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var iDataType = CreateType<int>();
            var bIsDeprecated = CreateType<bool>();
            var methodGetFieldFormatPrametersTypes = new Type[] { typeof(int), typeof(bool) };
            object[] parametersOfGetFieldFormat = { iDataType, bIsDeprecated };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_ePKClass01InstanceFixture, _ePKClass01InstanceType, MethodGetFieldFormat, parametersOfGetFieldFormat, methodGetFieldFormatPrametersTypes);

            // Assert
            parametersOfGetFieldFormat.ShouldNotBeNull();
            parametersOfGetFieldFormat.Length.ShouldBe(2);
            methodGetFieldFormatPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFieldFormat) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKClass01_GetFieldFormat_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFieldFormatPrametersTypes = new Type[] { typeof(int), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePKClass01InstanceFixture, _ePKClass01InstanceType, MethodGetFieldFormat, Fixture, methodGetFieldFormatPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFieldFormatPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetFieldFormat) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKClass01_GetFieldFormat_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFieldFormatPrametersTypes = new Type[] { typeof(int), typeof(bool) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePKClass01InstanceFixture, _ePKClass01InstanceType, MethodGetFieldFormat, Fixture, methodGetFieldFormatPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFieldFormatPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFieldFormat) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKClass01_GetFieldFormat_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFieldFormat, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePKClass01InstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetFieldFormat) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKClass01_GetFieldFormat_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFieldFormat, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTableAndField) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPKClass01_GetTableAndField_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetTableAndFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePKClass01InstanceFixture, _ePKClass01InstanceType, MethodGetTableAndField, Fixture, methodGetTableAndFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTableAndField) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKClass01_GetTableAndField_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var iTable = CreateType<int>();
            var iField = CreateType<int>();
            var sTable = CreateType<string>();
            var sField = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => EPKClass01.GetTableAndField(iTable, iField, out sTable, out sField);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetTableAndField) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKClass01_GetTableAndField_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var iTable = CreateType<int>();
            var iField = CreateType<int>();
            var sTable = CreateType<string>();
            var sField = CreateType<string>();
            var methodGetTableAndFieldPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(string), typeof(string) };
            object[] parametersOfGetTableAndField = { iTable, iField, sTable, sField };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetTableAndField, methodGetTableAndFieldPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePKClass01InstanceFixture, parametersOfGetTableAndField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetTableAndField.ShouldNotBeNull();
            parametersOfGetTableAndField.Length.ShouldBe(4);
            methodGetTableAndFieldPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTableAndField) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKClass01_GetTableAndField_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var iTable = CreateType<int>();
            var iField = CreateType<int>();
            var sTable = CreateType<string>();
            var sField = CreateType<string>();
            var methodGetTableAndFieldPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(string), typeof(string) };
            object[] parametersOfGetTableAndField = { iTable, iField, sTable, sField };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_ePKClass01InstanceFixture, _ePKClass01InstanceType, MethodGetTableAndField, parametersOfGetTableAndField, methodGetTableAndFieldPrametersTypes);

            // Assert
            parametersOfGetTableAndField.ShouldNotBeNull();
            parametersOfGetTableAndField.Length.ShouldBe(4);
            methodGetTableAndFieldPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTableAndField) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKClass01_GetTableAndField_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTableAndFieldPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(string), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePKClass01InstanceFixture, _ePKClass01InstanceType, MethodGetTableAndField, Fixture, methodGetTableAndFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTableAndFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTableAndField) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKClass01_GetTableAndField_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTableAndField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePKClass01InstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetTableAndField) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKClass01_GetTableAndField_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTableAndField, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTableID) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPKClass01_GetTableID_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetTableIDPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePKClass01InstanceFixture, _ePKClass01InstanceType, MethodGetTableID, Fixture, methodGetTableIDPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTableID) (Return Type : int) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKClass01_GetTableID_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var iEntity = CreateType<int>();
            var iDataType = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => EPKClass01.GetTableID(iEntity, iDataType);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetTableID) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKClass01_GetTableID_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var iEntity = CreateType<int>();
            var iDataType = CreateType<int>();
            var methodGetTableIDPrametersTypes = new Type[] { typeof(int), typeof(int) };
            object[] parametersOfGetTableID = { iEntity, iDataType };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTableID, methodGetTableIDPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePKClass01InstanceFixture, _ePKClass01InstanceType, MethodGetTableID, Fixture, methodGetTableIDPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<int>(_ePKClass01InstanceFixture, _ePKClass01InstanceType, MethodGetTableID, parametersOfGetTableID, methodGetTableIDPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetTableID.ShouldNotBeNull();
            parametersOfGetTableID.Length.ShouldBe(2);
            methodGetTableIDPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<int>(_ePKClass01InstanceFixture, _ePKClass01InstanceType, MethodGetTableID, parametersOfGetTableID, methodGetTableIDPrametersTypes));
        }

        #endregion

        #region Method Call : (GetTableID) (Return Type : int) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKClass01_GetTableID_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var iEntity = CreateType<int>();
            var iDataType = CreateType<int>();
            var methodGetTableIDPrametersTypes = new Type[] { typeof(int), typeof(int) };
            object[] parametersOfGetTableID = { iEntity, iDataType };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetTableID, methodGetTableIDPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePKClass01InstanceFixture, parametersOfGetTableID);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetTableID.ShouldNotBeNull();
            parametersOfGetTableID.Length.ShouldBe(2);
            methodGetTableIDPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTableID) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKClass01_GetTableID_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var iEntity = CreateType<int>();
            var iDataType = CreateType<int>();
            var methodGetTableIDPrametersTypes = new Type[] { typeof(int), typeof(int) };
            object[] parametersOfGetTableID = { iEntity, iDataType };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<int>(_ePKClass01InstanceFixture, _ePKClass01InstanceType, MethodGetTableID, parametersOfGetTableID, methodGetTableIDPrametersTypes);

            // Assert
            parametersOfGetTableID.ShouldNotBeNull();
            parametersOfGetTableID.Length.ShouldBe(2);
            methodGetTableIDPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTableID) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKClass01_GetTableID_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTableIDPrametersTypes = new Type[] { typeof(int), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePKClass01InstanceFixture, _ePKClass01InstanceType, MethodGetTableID, Fixture, methodGetTableIDPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetTableIDPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetTableID) (Return Type : int) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKClass01_GetTableID_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetTableIDPrametersTypes = new Type[] { typeof(int), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePKClass01InstanceFixture, _ePKClass01InstanceType, MethodGetTableID, Fixture, methodGetTableIDPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetTableIDPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetTableID) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKClass01_GetTableID_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTableIDPrametersTypes = new Type[] { typeof(int), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePKClass01InstanceFixture, _ePKClass01InstanceType, MethodGetTableID, Fixture, methodGetTableIDPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTableIDPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTableID) (Return Type : int) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKClass01_GetTableID_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTableID, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePKClass01InstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetTableID) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKClass01_GetTableID_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTableID, 0);
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
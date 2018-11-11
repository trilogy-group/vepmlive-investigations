using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.ReportHelper
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.ReportHelper.ColumnDef" />)
    ///     and namespace <see cref="EPMLiveCore.ReportHelper"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ColumnDefTest : AbstractBaseSetupTypedTest<ColumnDef>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ColumnDef) Initializer

        private const string PropertySqlColumnName = "SqlColumnName";
        private const string PropertyColumnType = "ColumnType";
        private const string PropertyInternalName = "InternalName";
        private const string PropertyDisplayName = "DisplayName";
        private const string PropertySqlColumnType = "SqlColumnType";
        private const string PropertySqlColumnSize = "SqlColumnSize";
        private const string PropertyIsLookup = "IsLookup";
        private const string MethodGetInvalidFieldType = "GetInvalidFieldType";
        private const string MethodToString = "ToString";
        private const string MethodGetString = "GetString";
        private const string MethodGetDefaultColumns = "GetDefaultColumns";
        private const string MethodGetDefaultColumnsSnapshot = "GetDefaultColumnsSnapshot";
        private const string MethodAddColumn = "AddColumn";
        private const string MethodConvertDbTypeToSqlDbType = "ConvertDbTypeToSqlDbType";
        private const string MethodGetParameterFromSPField = "GetParameterFromSPField";
        private const string Field_dbTypeTable = "_dbTypeTable";
        private const string Field_displayName = "_displayName";
        private const string Field_internalName = "_internalName";
        private const string Field_isLookup = "_isLookup";
        private const string Field_sqlColumnName = "_sqlColumnName";
        private const string Field_sqlColumnSize = "_sqlColumnSize";
        private const string Field_sqlColumnType = "_sqlColumnType";
        private Type _columnDefInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ColumnDef _columnDefInstance;
        private ColumnDef _columnDefInstanceFixture;

        #region General Initializer : Class (ColumnDef) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ColumnDef" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _columnDefInstanceType = typeof(ColumnDef);
            _columnDefInstanceFixture = Create(true);
            _columnDefInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ColumnDef)

        #region General Initializer : Class (ColumnDef) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ColumnDef" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetInvalidFieldType, 0)]
        [TestCase(MethodToString, 0)]
        [TestCase(MethodGetString, 0)]
        [TestCase(MethodGetDefaultColumns, 0)]
        [TestCase(MethodGetDefaultColumnsSnapshot, 0)]
        [TestCase(MethodAddColumn, 0)]
        [TestCase(MethodAddColumn, 1)]
        [TestCase(MethodConvertDbTypeToSqlDbType, 0)]
        [TestCase(MethodGetParameterFromSPField, 0)]
        public void AUT_ColumnDef_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_columnDefInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ColumnDef) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ColumnDef" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertySqlColumnName)]
        [TestCase(PropertyColumnType)]
        [TestCase(PropertyInternalName)]
        [TestCase(PropertyDisplayName)]
        [TestCase(PropertySqlColumnType)]
        [TestCase(PropertySqlColumnSize)]
        [TestCase(PropertyIsLookup)]
        public void AUT_ColumnDef_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_columnDefInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ColumnDef) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ColumnDef" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_dbTypeTable)]
        [TestCase(Field_displayName)]
        [TestCase(Field_internalName)]
        [TestCase(Field_isLookup)]
        [TestCase(Field_sqlColumnName)]
        [TestCase(Field_sqlColumnSize)]
        [TestCase(Field_sqlColumnType)]
        public void AUT_ColumnDef_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_columnDefInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ColumnDef) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="ColumnDef" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void AUT_ColumnDef_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<ColumnDef>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (ColumnDef) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="ColumnDef" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ColumnDef_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<ColumnDef>(Fixture);
        }

        #endregion

        #region General Constructor : Class (ColumnDef) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ColumnDef" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ColumnDef_Constructors_Explore_Verify_Test()
        {
            // Arrange
            var spField = CreateType<SPField>();
            object[] parametersOfColumnDef = { spField };
            var methodColumnDefPrametersTypes = new Type[] { typeof(SPField) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_columnDefInstanceType, methodColumnDefPrametersTypes, parametersOfColumnDef);
        }

        #endregion

        #region General Constructor : Class (ColumnDef) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ColumnDef" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ColumnDef_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodColumnDefPrametersTypes = new Type[] { typeof(SPField) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_columnDefInstanceType, Fixture, methodColumnDefPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (ColumnDef) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ColumnDef" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ColumnDef_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var sqlColumnName = CreateType<string>();
            var internalName = CreateType<string>();
            var displayName = CreateType<string>();
            var spFieldType = CreateType<SPFieldType>();
            var sqlDbType = CreateType<SqlDbType>();
            object[] parametersOfColumnDef = { sqlColumnName, internalName, displayName, spFieldType, sqlDbType };
            var methodColumnDefPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(SPFieldType), typeof(SqlDbType) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_columnDefInstanceType, methodColumnDefPrametersTypes, parametersOfColumnDef);
        }

        #endregion

        #region General Constructor : Class (ColumnDef) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ColumnDef" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ColumnDef_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodColumnDefPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(SPFieldType), typeof(SqlDbType) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_columnDefInstanceType, Fixture, methodColumnDefPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (ColumnDef) constructors with parameter (Overloading_Of_2_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ColumnDef" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ColumnDef_Constructors_Overloading_Of_2_Explore_Verify_Test()
        {
            // Arrange
            var sqlColumnName = CreateType<string>();
            var internalName = CreateType<string>();
            var displayName = CreateType<string>();
            var spFieldType = CreateType<SPFieldType>();
            var sqlDbType = CreateType<SqlDbType>();
            var size = CreateType<int>();
            object[] parametersOfColumnDef = { sqlColumnName, internalName, displayName, spFieldType, sqlDbType, size };
            var methodColumnDefPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(SPFieldType), typeof(SqlDbType), typeof(int) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_columnDefInstanceType, methodColumnDefPrametersTypes, parametersOfColumnDef);
        }

        #endregion

        #region General Constructor : Class (ColumnDef) constructors with dynamic parameters (Overloading_Of_2_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ColumnDef" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ColumnDef_Constructors_Overloading_Of_2_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodColumnDefPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(SPFieldType), typeof(SqlDbType), typeof(int) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_columnDefInstanceType, Fixture, methodColumnDefPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (ColumnDef) constructors with parameter (Overloading_Of_3_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ColumnDef" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ColumnDef_Constructors_Overloading_Of_3_Explore_Verify_Test()
        {
            // Arrange
            var row = CreateType<DataRow>();
            object[] parametersOfColumnDef = { row };
            var methodColumnDefPrametersTypes = new Type[] { typeof(DataRow) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_columnDefInstanceType, methodColumnDefPrametersTypes, parametersOfColumnDef);
        }

        #endregion

        #region General Constructor : Class (ColumnDef) constructors with dynamic parameters (Overloading_Of_3_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ColumnDef" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ColumnDef_Constructors_Overloading_Of_3_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodColumnDefPrametersTypes = new Type[] { typeof(DataRow) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_columnDefInstanceType, Fixture, methodColumnDefPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (ColumnDef) constructors with parameter (Overloading_Of_4_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ColumnDef" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ColumnDef_Constructors_Overloading_Of_4_Explore_Verify_Test()
        {
            // Arrange
            var column = CreateType<DataColumn>();
            object[] parametersOfColumnDef = { column };
            var methodColumnDefPrametersTypes = new Type[] { typeof(DataColumn) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_columnDefInstanceType, methodColumnDefPrametersTypes, parametersOfColumnDef);
        }

        #endregion

        #region General Constructor : Class (ColumnDef) constructors with dynamic parameters (Overloading_Of_4_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ColumnDef" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ColumnDef_Constructors_Overloading_Of_4_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodColumnDefPrametersTypes = new Type[] { typeof(DataColumn) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_columnDefInstanceType, Fixture, methodColumnDefPrametersTypes);
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ColumnDef) => Property (ColumnType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ColumnDef_Public_Class_ColumnType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyColumnType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ColumnDef) => Property (DisplayName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ColumnDef_Public_Class_DisplayName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDisplayName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ColumnDef) => Property (InternalName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ColumnDef_Public_Class_InternalName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyInternalName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ColumnDef) => Property (IsLookup) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ColumnDef_Public_Class_IsLookup_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyIsLookup);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ColumnDef) => Property (SqlColumnName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ColumnDef_Public_Class_SqlColumnName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySqlColumnName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ColumnDef) => Property (SqlColumnSize) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ColumnDef_Public_Class_SqlColumnSize_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySqlColumnSize);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ColumnDef) => Property (SqlColumnType) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ColumnDef_SqlColumnType_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertySqlColumnType);
            Action currentAction = () => propertyInfo.SetValue(_columnDefInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ColumnDef) => Property (SqlColumnType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ColumnDef_Public_Class_SqlColumnType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySqlColumnType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="ColumnDef" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetString)]
        [TestCase(MethodGetDefaultColumns)]
        [TestCase(MethodGetDefaultColumnsSnapshot)]
        [TestCase(MethodAddColumn)]
        [TestCase(MethodConvertDbTypeToSqlDbType)]
        [TestCase(MethodGetParameterFromSPField)]
        public void AUT_ColumnDef_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_columnDefInstanceFixture,
                                                                              _columnDefInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ColumnDef" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetInvalidFieldType)]
        [TestCase(MethodToString)]
        public void AUT_ColumnDef_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ColumnDef>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetInvalidFieldType) (Return Type : SPFieldType) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ColumnDef_GetInvalidFieldType_Method_Call_Internally(Type[] types)
        {
            var methodGetInvalidFieldTypePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_columnDefInstance, MethodGetInvalidFieldType, Fixture, methodGetInvalidFieldTypePrametersTypes);
        }

        #endregion

        #region Method Call : (GetInvalidFieldType) (Return Type : SPFieldType) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_GetInvalidFieldType_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var methodGetInvalidFieldTypePrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfGetInvalidFieldType = { field };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetInvalidFieldType, methodGetInvalidFieldTypePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ColumnDef, SPFieldType>(_columnDefInstanceFixture, out exception1, parametersOfGetInvalidFieldType);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ColumnDef, SPFieldType>(_columnDefInstance, MethodGetInvalidFieldType, parametersOfGetInvalidFieldType, methodGetInvalidFieldTypePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetInvalidFieldType.ShouldNotBeNull();
            parametersOfGetInvalidFieldType.Length.ShouldBe(1);
            methodGetInvalidFieldTypePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetInvalidFieldType) (Return Type : SPFieldType) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_GetInvalidFieldType_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var methodGetInvalidFieldTypePrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfGetInvalidFieldType = { field };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ColumnDef, SPFieldType>(_columnDefInstance, MethodGetInvalidFieldType, parametersOfGetInvalidFieldType, methodGetInvalidFieldTypePrametersTypes);

            // Assert
            parametersOfGetInvalidFieldType.ShouldNotBeNull();
            parametersOfGetInvalidFieldType.Length.ShouldBe(1);
            methodGetInvalidFieldTypePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetInvalidFieldType) (Return Type : SPFieldType) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_GetInvalidFieldType_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetInvalidFieldTypePrametersTypes = new Type[] { typeof(SPField) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_columnDefInstance, MethodGetInvalidFieldType, Fixture, methodGetInvalidFieldTypePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetInvalidFieldTypePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetInvalidFieldType) (Return Type : SPFieldType) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_GetInvalidFieldType_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetInvalidFieldTypePrametersTypes = new Type[] { typeof(SPField) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_columnDefInstance, MethodGetInvalidFieldType, Fixture, methodGetInvalidFieldTypePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetInvalidFieldTypePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetInvalidFieldType) (Return Type : SPFieldType) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_GetInvalidFieldType_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetInvalidFieldType, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_columnDefInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetInvalidFieldType) (Return Type : SPFieldType) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_GetInvalidFieldType_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetInvalidFieldType, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ColumnDef_ToString_Method_Call_Internally(Type[] types)
        {
            var methodToStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_columnDefInstance, MethodToString, Fixture, methodToStringPrametersTypes);
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_ToString_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _columnDefInstance.ToString();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_ToString_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodToStringPrametersTypes = null;
            object[] parametersOfToString = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodToString, methodToStringPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ColumnDef, string>(_columnDefInstanceFixture, out exception1, parametersOfToString);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ColumnDef, string>(_columnDefInstance, MethodToString, parametersOfToString, methodToStringPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfToString.ShouldBeNull();
            methodToStringPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_ToString_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodToStringPrametersTypes = null;
            object[] parametersOfToString = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ColumnDef, string>(_columnDefInstance, MethodToString, parametersOfToString, methodToStringPrametersTypes);

            // Assert
            parametersOfToString.ShouldBeNull();
            methodToStringPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_ToString_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodToStringPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_columnDefInstance, MethodToString, Fixture, methodToStringPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodToStringPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_ToString_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodToStringPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_columnDefInstance, MethodToString, Fixture, methodToStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodToStringPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_ToString_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodToString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_columnDefInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetString) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ColumnDef_GetString_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_columnDefInstanceFixture, _columnDefInstanceType, MethodGetString, Fixture, methodGetStringPrametersTypes);
        }

        #endregion

        #region Method Call : (GetString) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_GetString_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var columnDef = CreateType<ColumnDef>();
            Action executeAction = null;

            // Act
            executeAction = () => ColumnDef.GetString(columnDef);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetString) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_GetString_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var columnDef = CreateType<ColumnDef>();
            var methodGetStringPrametersTypes = new Type[] { typeof(ColumnDef) };
            object[] parametersOfGetString = { columnDef };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetString, methodGetStringPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_columnDefInstanceFixture, _columnDefInstanceType, MethodGetString, Fixture, methodGetStringPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_columnDefInstanceFixture, _columnDefInstanceType, MethodGetString, parametersOfGetString, methodGetStringPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_columnDefInstanceFixture, parametersOfGetString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetString.ShouldNotBeNull();
            parametersOfGetString.Length.ShouldBe(1);
            methodGetStringPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetString) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_GetString_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var columnDef = CreateType<ColumnDef>();
            var methodGetStringPrametersTypes = new Type[] { typeof(ColumnDef) };
            object[] parametersOfGetString = { columnDef };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_columnDefInstanceFixture, _columnDefInstanceType, MethodGetString, parametersOfGetString, methodGetStringPrametersTypes);

            // Assert
            parametersOfGetString.ShouldNotBeNull();
            parametersOfGetString.Length.ShouldBe(1);
            methodGetStringPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetString) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_GetString_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetStringPrametersTypes = new Type[] { typeof(ColumnDef) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_columnDefInstanceFixture, _columnDefInstanceType, MethodGetString, Fixture, methodGetStringPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetStringPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetString) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_GetString_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetStringPrametersTypes = new Type[] { typeof(ColumnDef) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_columnDefInstanceFixture, _columnDefInstanceType, MethodGetString, Fixture, methodGetStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetStringPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetString) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_GetString_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_columnDefInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetString) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_GetString_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetString, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDefaultColumns) (Return Type : ColumnDefCollection) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ColumnDef_GetDefaultColumns_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetDefaultColumnsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_columnDefInstanceFixture, _columnDefInstanceType, MethodGetDefaultColumns, Fixture, methodGetDefaultColumnsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDefaultColumns) (Return Type : ColumnDefCollection) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_GetDefaultColumns_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => ColumnDef.GetDefaultColumns();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetDefaultColumns) (Return Type : ColumnDefCollection) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_GetDefaultColumns_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetDefaultColumnsPrametersTypes = null;
            object[] parametersOfGetDefaultColumns = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetDefaultColumns, methodGetDefaultColumnsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_columnDefInstanceFixture, parametersOfGetDefaultColumns);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetDefaultColumns.ShouldBeNull();
            methodGetDefaultColumnsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDefaultColumns) (Return Type : ColumnDefCollection) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_GetDefaultColumns_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetDefaultColumnsPrametersTypes = null;
            object[] parametersOfGetDefaultColumns = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<ColumnDefCollection>(_columnDefInstanceFixture, _columnDefInstanceType, MethodGetDefaultColumns, parametersOfGetDefaultColumns, methodGetDefaultColumnsPrametersTypes);

            // Assert
            parametersOfGetDefaultColumns.ShouldBeNull();
            methodGetDefaultColumnsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDefaultColumns) (Return Type : ColumnDefCollection) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_GetDefaultColumns_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetDefaultColumnsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_columnDefInstanceFixture, _columnDefInstanceType, MethodGetDefaultColumns, Fixture, methodGetDefaultColumnsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDefaultColumnsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDefaultColumns) (Return Type : ColumnDefCollection) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_GetDefaultColumns_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetDefaultColumnsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_columnDefInstanceFixture, _columnDefInstanceType, MethodGetDefaultColumns, Fixture, methodGetDefaultColumnsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDefaultColumnsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDefaultColumns) (Return Type : ColumnDefCollection) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_GetDefaultColumns_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDefaultColumns, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_columnDefInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetDefaultColumnsSnapshot) (Return Type : ColumnDefCollection) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ColumnDef_GetDefaultColumnsSnapshot_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetDefaultColumnsSnapshotPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_columnDefInstanceFixture, _columnDefInstanceType, MethodGetDefaultColumnsSnapshot, Fixture, methodGetDefaultColumnsSnapshotPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDefaultColumnsSnapshot) (Return Type : ColumnDefCollection) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_GetDefaultColumnsSnapshot_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => ColumnDef.GetDefaultColumnsSnapshot();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetDefaultColumnsSnapshot) (Return Type : ColumnDefCollection) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_GetDefaultColumnsSnapshot_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetDefaultColumnsSnapshotPrametersTypes = null;
            object[] parametersOfGetDefaultColumnsSnapshot = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetDefaultColumnsSnapshot, methodGetDefaultColumnsSnapshotPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_columnDefInstanceFixture, parametersOfGetDefaultColumnsSnapshot);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetDefaultColumnsSnapshot.ShouldBeNull();
            methodGetDefaultColumnsSnapshotPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDefaultColumnsSnapshot) (Return Type : ColumnDefCollection) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_GetDefaultColumnsSnapshot_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetDefaultColumnsSnapshotPrametersTypes = null;
            object[] parametersOfGetDefaultColumnsSnapshot = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<ColumnDefCollection>(_columnDefInstanceFixture, _columnDefInstanceType, MethodGetDefaultColumnsSnapshot, parametersOfGetDefaultColumnsSnapshot, methodGetDefaultColumnsSnapshotPrametersTypes);

            // Assert
            parametersOfGetDefaultColumnsSnapshot.ShouldBeNull();
            methodGetDefaultColumnsSnapshotPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDefaultColumnsSnapshot) (Return Type : ColumnDefCollection) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_GetDefaultColumnsSnapshot_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetDefaultColumnsSnapshotPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_columnDefInstanceFixture, _columnDefInstanceType, MethodGetDefaultColumnsSnapshot, Fixture, methodGetDefaultColumnsSnapshotPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDefaultColumnsSnapshotPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDefaultColumnsSnapshot) (Return Type : ColumnDefCollection) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_GetDefaultColumnsSnapshot_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetDefaultColumnsSnapshotPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_columnDefInstanceFixture, _columnDefInstanceType, MethodGetDefaultColumnsSnapshot, Fixture, methodGetDefaultColumnsSnapshotPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDefaultColumnsSnapshotPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDefaultColumnsSnapshot) (Return Type : ColumnDefCollection) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_GetDefaultColumnsSnapshot_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDefaultColumnsSnapshot, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_columnDefInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (AddColumn) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ColumnDef_AddColumn_Static_Method_Call_Internally(Type[] types)
        {
            var methodAddColumnPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_columnDefInstanceFixture, _columnDefInstanceType, MethodAddColumn, Fixture, methodAddColumnPrametersTypes);
        }

        #endregion

        #region Method Call : (AddColumn) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_AddColumn_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var columns = CreateType<ColumnDefCollection>();
            var field = CreateType<SPField>();
            Action executeAction = null;

            // Act
            executeAction = () => ColumnDef.AddColumn(columns, field);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (AddColumn) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_AddColumn_Static_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var columns = CreateType<ColumnDefCollection>();
            var field = CreateType<SPField>();
            var methodAddColumnPrametersTypes = new Type[] { typeof(ColumnDefCollection), typeof(SPField) };
            object[] parametersOfAddColumn = { columns, field };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddColumn, methodAddColumnPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_columnDefInstanceFixture, parametersOfAddColumn);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddColumn.ShouldNotBeNull();
            parametersOfAddColumn.Length.ShouldBe(2);
            methodAddColumnPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddColumn) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_AddColumn_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var columns = CreateType<ColumnDefCollection>();
            var field = CreateType<SPField>();
            var methodAddColumnPrametersTypes = new Type[] { typeof(ColumnDefCollection), typeof(SPField) };
            object[] parametersOfAddColumn = { columns, field };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_columnDefInstanceFixture, _columnDefInstanceType, MethodAddColumn, parametersOfAddColumn, methodAddColumnPrametersTypes);

            // Assert
            parametersOfAddColumn.ShouldNotBeNull();
            parametersOfAddColumn.Length.ShouldBe(2);
            methodAddColumnPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddColumn) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_AddColumn_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddColumn, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddColumn) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_AddColumn_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddColumnPrametersTypes = new Type[] { typeof(ColumnDefCollection), typeof(SPField) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_columnDefInstanceFixture, _columnDefInstanceType, MethodAddColumn, Fixture, methodAddColumnPrametersTypes);

            // Assert
            methodAddColumnPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddColumn) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_AddColumn_Static_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddColumn, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_columnDefInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddColumn) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ColumnDef_AddColumn_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodAddColumnPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_columnDefInstanceFixture, _columnDefInstanceType, MethodAddColumn, Fixture, methodAddColumnPrametersTypes);
        }

        #endregion

        #region Method Call : (AddColumn) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_AddColumn_Static_Method_DirectCall_Overloading_Of_1_No_Exception_Thrown_Test()
        {
            // Arrange
            var columns = CreateType<ColumnDefCollection>();
            var column = CreateType<DataColumn>();
            Action executeAction = null;

            // Act
            executeAction = () => ColumnDef.AddColumn(columns, column);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (AddColumn) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_AddColumn_Static_Method_Call_Void_Overloading_Of_1_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var columns = CreateType<ColumnDefCollection>();
            var column = CreateType<DataColumn>();
            var methodAddColumnPrametersTypes = new Type[] { typeof(ColumnDefCollection), typeof(DataColumn) };
            object[] parametersOfAddColumn = { columns, column };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddColumn, methodAddColumnPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_columnDefInstanceFixture, parametersOfAddColumn);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddColumn.ShouldNotBeNull();
            parametersOfAddColumn.Length.ShouldBe(2);
            methodAddColumnPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddColumn) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_AddColumn_Static_Method_Call_Void_Overloading_Of_1_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var columns = CreateType<ColumnDefCollection>();
            var column = CreateType<DataColumn>();
            var methodAddColumnPrametersTypes = new Type[] { typeof(ColumnDefCollection), typeof(DataColumn) };
            object[] parametersOfAddColumn = { columns, column };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_columnDefInstanceFixture, _columnDefInstanceType, MethodAddColumn, parametersOfAddColumn, methodAddColumnPrametersTypes);

            // Assert
            parametersOfAddColumn.ShouldNotBeNull();
            parametersOfAddColumn.Length.ShouldBe(2);
            methodAddColumnPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddColumn) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_AddColumn_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddColumn, 1);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddColumn) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_AddColumn_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddColumnPrametersTypes = new Type[] { typeof(ColumnDefCollection), typeof(DataColumn) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_columnDefInstanceFixture, _columnDefInstanceType, MethodAddColumn, Fixture, methodAddColumnPrametersTypes);

            // Assert
            methodAddColumnPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddColumn) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_AddColumn_Static_Method_Call_Overloading_Of_1_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddColumn, 1);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_columnDefInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConvertDbTypeToSqlDbType) (Return Type : SqlDbType) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ColumnDef_ConvertDbTypeToSqlDbType_Static_Method_Call_Internally(Type[] types)
        {
            var methodConvertDbTypeToSqlDbTypePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_columnDefInstanceFixture, _columnDefInstanceType, MethodConvertDbTypeToSqlDbType, Fixture, methodConvertDbTypeToSqlDbTypePrametersTypes);
        }

        #endregion

        #region Method Call : (ConvertDbTypeToSqlDbType) (Return Type : SqlDbType) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_ConvertDbTypeToSqlDbType_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var dbType = CreateType<Type>();
            Action executeAction = null;

            // Act
            executeAction = () => ColumnDef.ConvertDbTypeToSqlDbType(dbType);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ConvertDbTypeToSqlDbType) (Return Type : SqlDbType) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_ConvertDbTypeToSqlDbType_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var dbType = CreateType<Type>();
            var methodConvertDbTypeToSqlDbTypePrametersTypes = new Type[] { typeof(Type) };
            object[] parametersOfConvertDbTypeToSqlDbType = { dbType };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodConvertDbTypeToSqlDbType, methodConvertDbTypeToSqlDbTypePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_columnDefInstanceFixture, _columnDefInstanceType, MethodConvertDbTypeToSqlDbType, Fixture, methodConvertDbTypeToSqlDbTypePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<SqlDbType>(_columnDefInstanceFixture, _columnDefInstanceType, MethodConvertDbTypeToSqlDbType, parametersOfConvertDbTypeToSqlDbType, methodConvertDbTypeToSqlDbTypePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfConvertDbTypeToSqlDbType.ShouldNotBeNull();
            parametersOfConvertDbTypeToSqlDbType.Length.ShouldBe(1);
            methodConvertDbTypeToSqlDbTypePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<SqlDbType>(_columnDefInstanceFixture, _columnDefInstanceType, MethodConvertDbTypeToSqlDbType, parametersOfConvertDbTypeToSqlDbType, methodConvertDbTypeToSqlDbTypePrametersTypes));
        }

        #endregion

        #region Method Call : (ConvertDbTypeToSqlDbType) (Return Type : SqlDbType) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_ConvertDbTypeToSqlDbType_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var dbType = CreateType<Type>();
            var methodConvertDbTypeToSqlDbTypePrametersTypes = new Type[] { typeof(Type) };
            object[] parametersOfConvertDbTypeToSqlDbType = { dbType };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodConvertDbTypeToSqlDbType, methodConvertDbTypeToSqlDbTypePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_columnDefInstanceFixture, parametersOfConvertDbTypeToSqlDbType);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfConvertDbTypeToSqlDbType.ShouldNotBeNull();
            parametersOfConvertDbTypeToSqlDbType.Length.ShouldBe(1);
            methodConvertDbTypeToSqlDbTypePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConvertDbTypeToSqlDbType) (Return Type : SqlDbType) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_ConvertDbTypeToSqlDbType_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dbType = CreateType<Type>();
            var methodConvertDbTypeToSqlDbTypePrametersTypes = new Type[] { typeof(Type) };
            object[] parametersOfConvertDbTypeToSqlDbType = { dbType };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<SqlDbType>(_columnDefInstanceFixture, _columnDefInstanceType, MethodConvertDbTypeToSqlDbType, parametersOfConvertDbTypeToSqlDbType, methodConvertDbTypeToSqlDbTypePrametersTypes);

            // Assert
            parametersOfConvertDbTypeToSqlDbType.ShouldNotBeNull();
            parametersOfConvertDbTypeToSqlDbType.Length.ShouldBe(1);
            methodConvertDbTypeToSqlDbTypePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConvertDbTypeToSqlDbType) (Return Type : SqlDbType) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_ConvertDbTypeToSqlDbType_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodConvertDbTypeToSqlDbTypePrametersTypes = new Type[] { typeof(Type) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_columnDefInstanceFixture, _columnDefInstanceType, MethodConvertDbTypeToSqlDbType, Fixture, methodConvertDbTypeToSqlDbTypePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodConvertDbTypeToSqlDbTypePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ConvertDbTypeToSqlDbType) (Return Type : SqlDbType) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_ConvertDbTypeToSqlDbType_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodConvertDbTypeToSqlDbTypePrametersTypes = new Type[] { typeof(Type) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_columnDefInstanceFixture, _columnDefInstanceType, MethodConvertDbTypeToSqlDbType, Fixture, methodConvertDbTypeToSqlDbTypePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodConvertDbTypeToSqlDbTypePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ConvertDbTypeToSqlDbType) (Return Type : SqlDbType) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_ConvertDbTypeToSqlDbType_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodConvertDbTypeToSqlDbType, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_columnDefInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ConvertDbTypeToSqlDbType) (Return Type : SqlDbType) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_ConvertDbTypeToSqlDbType_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodConvertDbTypeToSqlDbType, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetParameterFromSPField) (Return Type : SqlParameter) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ColumnDef_GetParameterFromSPField_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetParameterFromSPFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_columnDefInstanceFixture, _columnDefInstanceType, MethodGetParameterFromSPField, Fixture, methodGetParameterFromSPFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (GetParameterFromSPField) (Return Type : SqlParameter) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_GetParameterFromSPField_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            Action executeAction = null;

            // Act
            executeAction = () => ColumnDef.GetParameterFromSPField(field);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetParameterFromSPField) (Return Type : SqlParameter) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_GetParameterFromSPField_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var methodGetParameterFromSPFieldPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfGetParameterFromSPField = { field };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetParameterFromSPField, methodGetParameterFromSPFieldPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_columnDefInstanceFixture, _columnDefInstanceType, MethodGetParameterFromSPField, Fixture, methodGetParameterFromSPFieldPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<SqlParameter>(_columnDefInstanceFixture, _columnDefInstanceType, MethodGetParameterFromSPField, parametersOfGetParameterFromSPField, methodGetParameterFromSPFieldPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_columnDefInstanceFixture, parametersOfGetParameterFromSPField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetParameterFromSPField.ShouldNotBeNull();
            parametersOfGetParameterFromSPField.Length.ShouldBe(1);
            methodGetParameterFromSPFieldPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetParameterFromSPField) (Return Type : SqlParameter) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_GetParameterFromSPField_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var methodGetParameterFromSPFieldPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfGetParameterFromSPField = { field };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<SqlParameter>(_columnDefInstanceFixture, _columnDefInstanceType, MethodGetParameterFromSPField, parametersOfGetParameterFromSPField, methodGetParameterFromSPFieldPrametersTypes);

            // Assert
            parametersOfGetParameterFromSPField.ShouldNotBeNull();
            parametersOfGetParameterFromSPField.Length.ShouldBe(1);
            methodGetParameterFromSPFieldPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetParameterFromSPField) (Return Type : SqlParameter) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_GetParameterFromSPField_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetParameterFromSPFieldPrametersTypes = new Type[] { typeof(SPField) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_columnDefInstanceFixture, _columnDefInstanceType, MethodGetParameterFromSPField, Fixture, methodGetParameterFromSPFieldPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetParameterFromSPFieldPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetParameterFromSPField) (Return Type : SqlParameter) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_GetParameterFromSPField_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetParameterFromSPFieldPrametersTypes = new Type[] { typeof(SPField) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_columnDefInstanceFixture, _columnDefInstanceType, MethodGetParameterFromSPField, Fixture, methodGetParameterFromSPFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetParameterFromSPFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetParameterFromSPField) (Return Type : SqlParameter) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_GetParameterFromSPField_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetParameterFromSPField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_columnDefInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetParameterFromSPField) (Return Type : SqlParameter) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDef_GetParameterFromSPField_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetParameterFromSPField, 0);
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
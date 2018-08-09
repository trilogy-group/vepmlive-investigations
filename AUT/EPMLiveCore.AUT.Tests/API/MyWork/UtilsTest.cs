using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.API
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.Utils" />)
    ///     and namespace <see cref="EPMLiveCore.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class UtilsTest : AbstractBaseSetupTest
    {
        public UtilsTest() : base(typeof(Utils))
        {}

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Utils) Initializer

        private const string MethodGetConfigWeb = "GetConfigWeb";
        private const string MethodGetFormat = "GetFormat";
        private const string MethodGetGridEnum = "GetGridEnum";
        private const string MethodGetRelatedGridTypeForReadOnly = "GetRelatedGridTypeForReadOnly";
        private const string MethodToGridSafeFieldName = "ToGridSafeFieldName";
        private const string MethodGetCleanValueFromFormatted = "GetCleanValueFromFormatted";
        private const string MethodAddItemListWebSiteToXElement = "AddItemListWebSiteToXElement";
        private const string MethodCleanGuid = "CleanGuid";
        private const string MethodGetCleanFieldValue = "GetCleanFieldValue";
        private const string MethodGetFieldProperties = "GetFieldProperties";
        private const string MethodGetFieldTypes = "GetFieldTypes";
        private const string MethodGetFieldValues = "GetFieldValues";
        private const string MethodGetItemListWebSite = "GetItemListWebSite";
        private const string MethodGetListWebSite = "GetListWebSite";
        private const string MethodGetRelatedGridType = "GetRelatedGridType";
        private const string MethodGetRelatedGridTypeForMyTimesheet = "GetRelatedGridTypeForMyTimesheet";
        private const string MethodToOriginalFieldName = "ToOriginalFieldName";
        private const string MethodValidateItemListWebAndSite = "ValidateItemListWebAndSite";
        private const string MethodValidateListWebAndSite = "ValidateListWebAndSite";
        private const string FieldMyWorkList = "MyWorkList";
        private const string FieldReservedWords = "ReservedWords";
        private Type _utilsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;

        #region General Initializer : Class (Utils) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Utils" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _utilsInstanceType = typeof(Utils);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Utils)

        #region General Initializer : Class (Utils) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Utils" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetConfigWeb, 0)]
        [TestCase(MethodGetFormat, 0)]
        [TestCase(MethodGetGridEnum, 0)]
        [TestCase(MethodGetRelatedGridTypeForReadOnly, 0)]
        [TestCase(MethodToGridSafeFieldName, 0)]
        [TestCase(MethodGetCleanValueFromFormatted, 0)]
        [TestCase(MethodAddItemListWebSiteToXElement, 0)]
        [TestCase(MethodCleanGuid, 0)]
        [TestCase(MethodGetCleanFieldValue, 0)]
        [TestCase(MethodGetConfigWeb, 1)]
        [TestCase(MethodGetFieldProperties, 0)]
        [TestCase(MethodGetFieldTypes, 0)]
        [TestCase(MethodGetFieldValues, 0)]
        [TestCase(MethodGetItemListWebSite, 0)]
        [TestCase(MethodGetListWebSite, 0)]
        [TestCase(MethodGetRelatedGridType, 0)]
        [TestCase(MethodGetRelatedGridTypeForMyTimesheet, 0)]
        [TestCase(MethodToOriginalFieldName, 0)]
        [TestCase(MethodValidateItemListWebAndSite, 0)]
        [TestCase(MethodValidateListWebAndSite, 0)]
        public void AUT_Utils_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(null, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Utils) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Utils" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldMyWorkList)]
        [TestCase(FieldReservedWords)]
        public void AUT_Utils_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(null, 
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
        ///     Class (<see cref="Utils" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Utils_Is_Static_Type_Present_Test()
        {
            // Assert
            _utilsInstanceType.ShouldNotBeNull();
        }

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="Utils" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetConfigWeb)]
        [TestCase(MethodGetFormat)]
        [TestCase(MethodGetGridEnum)]
        [TestCase(MethodGetRelatedGridTypeForReadOnly)]
        [TestCase(MethodToGridSafeFieldName)]
        [TestCase(MethodGetCleanValueFromFormatted)]
        [TestCase(MethodAddItemListWebSiteToXElement)]
        [TestCase(MethodCleanGuid)]
        [TestCase(MethodGetCleanFieldValue)]
        [TestCase(MethodGetFieldProperties)]
        [TestCase(MethodGetFieldTypes)]
        [TestCase(MethodGetFieldValues)]
        [TestCase(MethodGetItemListWebSite)]
        [TestCase(MethodGetListWebSite)]
        [TestCase(MethodGetRelatedGridType)]
        [TestCase(MethodGetRelatedGridTypeForMyTimesheet)]
        [TestCase(MethodToOriginalFieldName)]
        [TestCase(MethodValidateItemListWebAndSite)]
        [TestCase(MethodValidateListWebAndSite)]
        public void AUT_Utils_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(null,
                                                                              _utilsInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (GetConfigWeb) (Return Type : SPWeb) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utils_GetConfigWeb_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetConfigWebPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetConfigWeb, Fixture, methodGetConfigWebPrametersTypes);
        }

        #endregion

        #region Method Call : (GetConfigWeb) (Return Type : SPWeb) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetConfigWeb_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => Utils.GetConfigWeb();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetConfigWeb) (Return Type : SPWeb) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetConfigWeb_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetConfigWebPrametersTypes = null;
            object[] parametersOfGetConfigWeb = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetConfigWeb, methodGetConfigWebPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetConfigWeb, Fixture, methodGetConfigWebPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<SPWeb>(null, _utilsInstanceType, MethodGetConfigWeb, parametersOfGetConfigWeb, methodGetConfigWebPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetConfigWeb);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetConfigWeb.ShouldBeNull();
            methodGetConfigWebPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetConfigWeb) (Return Type : SPWeb) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetConfigWeb_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetConfigWebPrametersTypes = null;
            object[] parametersOfGetConfigWeb = null; // no parameter present

            // Assert
            parametersOfGetConfigWeb.ShouldBeNull();
            methodGetConfigWebPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<SPWeb>(null, _utilsInstanceType, MethodGetConfigWeb, parametersOfGetConfigWeb, methodGetConfigWebPrametersTypes));
        }

        #endregion

        #region Method Call : (GetConfigWeb) (Return Type : SPWeb) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetConfigWeb_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetConfigWebPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetConfigWeb, Fixture, methodGetConfigWebPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetConfigWebPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetConfigWeb) (Return Type : SPWeb) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetConfigWeb_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetConfigWebPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetConfigWeb, Fixture, methodGetConfigWebPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetConfigWebPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetConfigWeb) (Return Type : SPWeb) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetConfigWeb_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetConfigWeb, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFormat) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utils_GetFormat_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFormatPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetFormat, Fixture, methodGetFormatPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFormat) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetFormat_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            Action executeAction = null;

            // Act
            executeAction = () => Utils.GetFormat(field);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetFormat) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetFormat_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var methodGetFormatPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfGetFormat = { field };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetFormat, methodGetFormatPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetFormat, Fixture, methodGetFormatPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _utilsInstanceType, MethodGetFormat, parametersOfGetFormat, methodGetFormatPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetFormat);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFormat.ShouldNotBeNull();
            parametersOfGetFormat.Length.ShouldBe(1);
            methodGetFormatPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetFormat) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetFormat_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var methodGetFormatPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfGetFormat = { field };

            // Assert
            parametersOfGetFormat.ShouldNotBeNull();
            parametersOfGetFormat.Length.ShouldBe(1);
            methodGetFormatPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _utilsInstanceType, MethodGetFormat, parametersOfGetFormat, methodGetFormatPrametersTypes));
        }

        #endregion

        #region Method Call : (GetFormat) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetFormat_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFormatPrametersTypes = new Type[] { typeof(SPField) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetFormat, Fixture, methodGetFormatPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFormatPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFormat) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetFormat_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFormatPrametersTypes = new Type[] { typeof(SPField) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetFormat, Fixture, methodGetFormatPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFormatPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFormat) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetFormat_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFormat, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFormat) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetFormat_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFormat, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetGridEnum) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utils_GetGridEnum_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetGridEnumPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetGridEnum, Fixture, methodGetGridEnumPrametersTypes);
        }

        #endregion

        #region Method Call : (GetGridEnum) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetGridEnum_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var spSite = CreateType<SPSite>();
            var spField = CreateType<SPField>();
            var values = CreateType<string>();
            var range = CreateType<int>();
            var keys = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => Utils.GetGridEnum(spSite, spField, out values, out range, out keys);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetGridEnum) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetGridEnum_Static_Method_Call_Void_With_5_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spSite = CreateType<SPSite>();
            var spField = CreateType<SPField>();
            var values = CreateType<string>();
            var range = CreateType<int>();
            var keys = CreateType<string>();
            var methodGetGridEnumPrametersTypes = new Type[] { typeof(SPSite), typeof(SPField), typeof(string), typeof(int), typeof(string) };
            object[] parametersOfGetGridEnum = { spSite, spField, values, range, keys };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(null, _utilsInstanceType, MethodGetGridEnum, parametersOfGetGridEnum, methodGetGridEnumPrametersTypes);

            // Assert
            parametersOfGetGridEnum.ShouldNotBeNull();
            parametersOfGetGridEnum.Length.ShouldBe(5);
            methodGetGridEnumPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetGridEnum) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetGridEnum_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetGridEnum, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetGridEnum) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetGridEnum_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetGridEnumPrametersTypes = new Type[] { typeof(SPSite), typeof(SPField), typeof(string), typeof(int), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetGridEnum, Fixture, methodGetGridEnumPrametersTypes);

            // Assert
            methodGetGridEnumPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetGridEnum) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetGridEnum_Static_Method_Call_With_5_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetGridEnum, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetRelatedGridTypeForReadOnly) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utils_GetRelatedGridTypeForReadOnly_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetRelatedGridTypeForReadOnlyPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetRelatedGridTypeForReadOnly, Fixture, methodGetRelatedGridTypeForReadOnlyPrametersTypes);
        }

        #endregion

        #region Method Call : (GetRelatedGridTypeForReadOnly) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetRelatedGridTypeForReadOnly_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sPField = CreateType<SPField>();
            Action executeAction = null;

            // Act
            executeAction = () => Utils.GetRelatedGridTypeForReadOnly(sPField);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetRelatedGridTypeForReadOnly) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetRelatedGridTypeForReadOnly_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sPField = CreateType<SPField>();
            var methodGetRelatedGridTypeForReadOnlyPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfGetRelatedGridTypeForReadOnly = { sPField };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetRelatedGridTypeForReadOnly, methodGetRelatedGridTypeForReadOnlyPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetRelatedGridTypeForReadOnly, Fixture, methodGetRelatedGridTypeForReadOnlyPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _utilsInstanceType, MethodGetRelatedGridTypeForReadOnly, parametersOfGetRelatedGridTypeForReadOnly, methodGetRelatedGridTypeForReadOnlyPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetRelatedGridTypeForReadOnly);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetRelatedGridTypeForReadOnly.ShouldNotBeNull();
            parametersOfGetRelatedGridTypeForReadOnly.Length.ShouldBe(1);
            methodGetRelatedGridTypeForReadOnlyPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetRelatedGridTypeForReadOnly) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetRelatedGridTypeForReadOnly_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sPField = CreateType<SPField>();
            var methodGetRelatedGridTypeForReadOnlyPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfGetRelatedGridTypeForReadOnly = { sPField };

            // Assert
            parametersOfGetRelatedGridTypeForReadOnly.ShouldNotBeNull();
            parametersOfGetRelatedGridTypeForReadOnly.Length.ShouldBe(1);
            methodGetRelatedGridTypeForReadOnlyPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _utilsInstanceType, MethodGetRelatedGridTypeForReadOnly, parametersOfGetRelatedGridTypeForReadOnly, methodGetRelatedGridTypeForReadOnlyPrametersTypes));
        }

        #endregion

        #region Method Call : (GetRelatedGridTypeForReadOnly) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetRelatedGridTypeForReadOnly_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetRelatedGridTypeForReadOnlyPrametersTypes = new Type[] { typeof(SPField) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetRelatedGridTypeForReadOnly, Fixture, methodGetRelatedGridTypeForReadOnlyPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetRelatedGridTypeForReadOnlyPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetRelatedGridTypeForReadOnly) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetRelatedGridTypeForReadOnly_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetRelatedGridTypeForReadOnlyPrametersTypes = new Type[] { typeof(SPField) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetRelatedGridTypeForReadOnly, Fixture, methodGetRelatedGridTypeForReadOnlyPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetRelatedGridTypeForReadOnlyPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRelatedGridTypeForReadOnly) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetRelatedGridTypeForReadOnly_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetRelatedGridTypeForReadOnly, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRelatedGridTypeForReadOnly) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetRelatedGridTypeForReadOnly_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetRelatedGridTypeForReadOnly, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ToGridSafeFieldName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utils_ToGridSafeFieldName_Static_Method_Call_Internally(Type[] types)
        {
            var methodToGridSafeFieldNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodToGridSafeFieldName, Fixture, methodToGridSafeFieldNamePrametersTypes);
        }

        #endregion

        #region Method Call : (ToGridSafeFieldName) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_ToGridSafeFieldName_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var name = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => Utils.ToGridSafeFieldName(name);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ToGridSafeFieldName) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_ToGridSafeFieldName_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var methodToGridSafeFieldNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfToGridSafeFieldName = { name };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodToGridSafeFieldName, methodToGridSafeFieldNamePrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfToGridSafeFieldName.ShouldNotBeNull();
            parametersOfToGridSafeFieldName.Length.ShouldBe(1);
            methodToGridSafeFieldNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(null, parametersOfToGridSafeFieldName));
        }

        #endregion

        #region Method Call : (ToGridSafeFieldName) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_ToGridSafeFieldName_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var methodToGridSafeFieldNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfToGridSafeFieldName = { name };

            // Assert
            parametersOfToGridSafeFieldName.ShouldNotBeNull();
            parametersOfToGridSafeFieldName.Length.ShouldBe(1);
            methodToGridSafeFieldNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _utilsInstanceType, MethodToGridSafeFieldName, parametersOfToGridSafeFieldName, methodToGridSafeFieldNamePrametersTypes));
        }

        #endregion

        #region Method Call : (ToGridSafeFieldName) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_ToGridSafeFieldName_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodToGridSafeFieldNamePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodToGridSafeFieldName, Fixture, methodToGridSafeFieldNamePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodToGridSafeFieldNamePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ToGridSafeFieldName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_ToGridSafeFieldName_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodToGridSafeFieldNamePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodToGridSafeFieldName, Fixture, methodToGridSafeFieldNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodToGridSafeFieldNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ToGridSafeFieldName) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_ToGridSafeFieldName_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodToGridSafeFieldName, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ToGridSafeFieldName) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_ToGridSafeFieldName_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodToGridSafeFieldName, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCleanValueFromFormatted) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utils_GetCleanValueFromFormatted_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetCleanValueFromFormattedPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetCleanValueFromFormatted, Fixture, methodGetCleanValueFromFormattedPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCleanValueFromFormatted) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetCleanValueFromFormatted_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodGetCleanValueFromFormattedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetCleanValueFromFormatted = { value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetCleanValueFromFormatted, methodGetCleanValueFromFormattedPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetCleanValueFromFormatted.ShouldNotBeNull();
            parametersOfGetCleanValueFromFormatted.Length.ShouldBe(1);
            methodGetCleanValueFromFormattedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(null, parametersOfGetCleanValueFromFormatted));
        }

        #endregion

        #region Method Call : (GetCleanValueFromFormatted) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetCleanValueFromFormatted_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodGetCleanValueFromFormattedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetCleanValueFromFormatted = { value };

            // Assert
            parametersOfGetCleanValueFromFormatted.ShouldNotBeNull();
            parametersOfGetCleanValueFromFormatted.Length.ShouldBe(1);
            methodGetCleanValueFromFormattedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _utilsInstanceType, MethodGetCleanValueFromFormatted, parametersOfGetCleanValueFromFormatted, methodGetCleanValueFromFormattedPrametersTypes));
        }

        #endregion

        #region Method Call : (GetCleanValueFromFormatted) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetCleanValueFromFormatted_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCleanValueFromFormattedPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetCleanValueFromFormatted, Fixture, methodGetCleanValueFromFormattedPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCleanValueFromFormattedPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetCleanValueFromFormatted) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetCleanValueFromFormatted_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCleanValueFromFormattedPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetCleanValueFromFormatted, Fixture, methodGetCleanValueFromFormattedPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCleanValueFromFormattedPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCleanValueFromFormatted) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetCleanValueFromFormatted_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCleanValueFromFormatted, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetCleanValueFromFormatted) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetCleanValueFromFormatted_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCleanValueFromFormatted, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddItemListWebSiteToXElement) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utils_AddItemListWebSiteToXElement_Static_Method_Call_Internally(Type[] types)
        {
            var methodAddItemListWebSiteToXElementPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodAddItemListWebSiteToXElement, Fixture, methodAddItemListWebSiteToXElementPrametersTypes);
        }

        #endregion

        #region Method Call : (AddItemListWebSiteToXElement) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_AddItemListWebSiteToXElement_Static_Method_Call_Void_With_6_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var itemId = CreateType<int>();
            var listId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var siteId = CreateType<Guid>();
            var siteUrl = CreateType<string>();
            var xElement = CreateType<XElement>();
            var methodAddItemListWebSiteToXElementPrametersTypes = new Type[] { typeof(int), typeof(Guid), typeof(Guid), typeof(Guid), typeof(string), typeof(XElement) };
            object[] parametersOfAddItemListWebSiteToXElement = { itemId, listId, webId, siteId, siteUrl, xElement };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddItemListWebSiteToXElement, methodAddItemListWebSiteToXElementPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfAddItemListWebSiteToXElement);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddItemListWebSiteToXElement.ShouldNotBeNull();
            parametersOfAddItemListWebSiteToXElement.Length.ShouldBe(6);
            methodAddItemListWebSiteToXElementPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddItemListWebSiteToXElement) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_AddItemListWebSiteToXElement_Static_Method_Call_Void_With_6_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var itemId = CreateType<int>();
            var listId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var siteId = CreateType<Guid>();
            var siteUrl = CreateType<string>();
            var xElement = CreateType<XElement>();
            var methodAddItemListWebSiteToXElementPrametersTypes = new Type[] { typeof(int), typeof(Guid), typeof(Guid), typeof(Guid), typeof(string), typeof(XElement) };
            object[] parametersOfAddItemListWebSiteToXElement = { itemId, listId, webId, siteId, siteUrl, xElement };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(null, _utilsInstanceType, MethodAddItemListWebSiteToXElement, parametersOfAddItemListWebSiteToXElement, methodAddItemListWebSiteToXElementPrametersTypes);

            // Assert
            parametersOfAddItemListWebSiteToXElement.ShouldNotBeNull();
            parametersOfAddItemListWebSiteToXElement.Length.ShouldBe(6);
            methodAddItemListWebSiteToXElementPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddItemListWebSiteToXElement) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_AddItemListWebSiteToXElement_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddItemListWebSiteToXElement, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddItemListWebSiteToXElement) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_AddItemListWebSiteToXElement_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddItemListWebSiteToXElementPrametersTypes = new Type[] { typeof(int), typeof(Guid), typeof(Guid), typeof(Guid), typeof(string), typeof(XElement) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodAddItemListWebSiteToXElement, Fixture, methodAddItemListWebSiteToXElementPrametersTypes);

            // Assert
            methodAddItemListWebSiteToXElementPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddItemListWebSiteToXElement) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_AddItemListWebSiteToXElement_Static_Method_Call_With_6_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddItemListWebSiteToXElement, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CleanGuid) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utils_CleanGuid_Static_Method_Call_Internally(Type[] types)
        {
            var methodCleanGuidPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodCleanGuid, Fixture, methodCleanGuidPrametersTypes);
        }

        #endregion

        #region Method Call : (CleanGuid) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_CleanGuid_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var id = CreateType<object>();
            var methodCleanGuidPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfCleanGuid = { id };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCleanGuid, methodCleanGuidPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCleanGuid.ShouldNotBeNull();
            parametersOfCleanGuid.Length.ShouldBe(1);
            methodCleanGuidPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(null, parametersOfCleanGuid));
        }

        #endregion

        #region Method Call : (CleanGuid) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_CleanGuid_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var id = CreateType<object>();
            var methodCleanGuidPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfCleanGuid = { id };

            // Assert
            parametersOfCleanGuid.ShouldNotBeNull();
            parametersOfCleanGuid.Length.ShouldBe(1);
            methodCleanGuidPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _utilsInstanceType, MethodCleanGuid, parametersOfCleanGuid, methodCleanGuidPrametersTypes));
        }

        #endregion

        #region Method Call : (CleanGuid) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_CleanGuid_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCleanGuidPrametersTypes = new Type[] { typeof(object) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodCleanGuid, Fixture, methodCleanGuidPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCleanGuidPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (CleanGuid) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_CleanGuid_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCleanGuidPrametersTypes = new Type[] { typeof(object) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodCleanGuid, Fixture, methodCleanGuidPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCleanGuidPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CleanGuid) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_CleanGuid_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCleanGuid, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (CleanGuid) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_CleanGuid_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCleanGuid, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCleanFieldValue) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utils_GetCleanFieldValue_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetCleanFieldValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetCleanFieldValue, Fixture, methodGetCleanFieldValuePrametersTypes);
        }

        #endregion

        #region Method Call : (GetCleanFieldValue) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetCleanFieldValue_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var field = CreateType<XElement>();
            var methodGetCleanFieldValuePrametersTypes = new Type[] { typeof(XElement) };
            object[] parametersOfGetCleanFieldValue = { field };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetCleanFieldValue, methodGetCleanFieldValuePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetCleanFieldValue, Fixture, methodGetCleanFieldValuePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _utilsInstanceType, MethodGetCleanFieldValue, parametersOfGetCleanFieldValue, methodGetCleanFieldValuePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetCleanFieldValue);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetCleanFieldValue.ShouldNotBeNull();
            parametersOfGetCleanFieldValue.Length.ShouldBe(1);
            methodGetCleanFieldValuePrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetCleanFieldValue) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetCleanFieldValue_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var field = CreateType<XElement>();
            var methodGetCleanFieldValuePrametersTypes = new Type[] { typeof(XElement) };
            object[] parametersOfGetCleanFieldValue = { field };

            // Assert
            parametersOfGetCleanFieldValue.ShouldNotBeNull();
            parametersOfGetCleanFieldValue.Length.ShouldBe(1);
            methodGetCleanFieldValuePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _utilsInstanceType, MethodGetCleanFieldValue, parametersOfGetCleanFieldValue, methodGetCleanFieldValuePrametersTypes));
        }

        #endregion

        #region Method Call : (GetCleanFieldValue) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetCleanFieldValue_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCleanFieldValuePrametersTypes = new Type[] { typeof(XElement) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetCleanFieldValue, Fixture, methodGetCleanFieldValuePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCleanFieldValuePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetCleanFieldValue) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetCleanFieldValue_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCleanFieldValuePrametersTypes = new Type[] { typeof(XElement) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetCleanFieldValue, Fixture, methodGetCleanFieldValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCleanFieldValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCleanFieldValue) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetCleanFieldValue_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCleanFieldValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCleanFieldValue) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetCleanFieldValue_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCleanFieldValue, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetConfigWeb) (Return Type : SPWeb) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utils_GetConfigWeb_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodGetConfigWebPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetConfigWeb, Fixture, methodGetConfigWebPrametersTypes);
        }

        #endregion

        #region Method Call : (GetConfigWeb) (Return Type : SPWeb) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetConfigWeb_Static_Method_Call_Overloading_Of_1_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var theWeb = CreateType<SPWeb>();
            var lockedWeb = CreateType<Guid>();
            var methodGetConfigWebPrametersTypes = new Type[] { typeof(SPWeb), typeof(Guid) };
            object[] parametersOfGetConfigWeb = { theWeb, lockedWeb };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetConfigWeb, methodGetConfigWebPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetConfigWeb, Fixture, methodGetConfigWebPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<SPWeb>(null, _utilsInstanceType, MethodGetConfigWeb, parametersOfGetConfigWeb, methodGetConfigWebPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetConfigWeb);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetConfigWeb.ShouldNotBeNull();
            parametersOfGetConfigWeb.Length.ShouldBe(2);
            methodGetConfigWebPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetConfigWeb) (Return Type : SPWeb) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetConfigWeb_Static_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var theWeb = CreateType<SPWeb>();
            var lockedWeb = CreateType<Guid>();
            var methodGetConfigWebPrametersTypes = new Type[] { typeof(SPWeb), typeof(Guid) };
            object[] parametersOfGetConfigWeb = { theWeb, lockedWeb };

            // Assert
            parametersOfGetConfigWeb.ShouldNotBeNull();
            parametersOfGetConfigWeb.Length.ShouldBe(2);
            methodGetConfigWebPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<SPWeb>(null, _utilsInstanceType, MethodGetConfigWeb, parametersOfGetConfigWeb, methodGetConfigWebPrametersTypes));
        }

        #endregion

        #region Method Call : (GetConfigWeb) (Return Type : SPWeb) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetConfigWeb_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetConfigWebPrametersTypes = new Type[] { typeof(SPWeb), typeof(Guid) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetConfigWeb, Fixture, methodGetConfigWebPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetConfigWebPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetConfigWeb) (Return Type : SPWeb) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetConfigWeb_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetConfigWebPrametersTypes = new Type[] { typeof(SPWeb), typeof(Guid) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetConfigWeb, Fixture, methodGetConfigWebPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetConfigWebPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetConfigWeb) (Return Type : SPWeb) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetConfigWeb_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetConfigWeb, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFieldProperties) (Return Type : Dictionary<string, Dictionary<string, string>>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utils_GetFieldProperties_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFieldPropertiesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetFieldProperties, Fixture, methodGetFieldPropertiesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFieldProperties) (Return Type : Dictionary<string, Dictionary<string, string>>) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetFieldProperties_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var spList = CreateType<SPList>();
            var methodGetFieldPropertiesPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfGetFieldProperties = { spList };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetFieldProperties, methodGetFieldPropertiesPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetFieldProperties.ShouldNotBeNull();
            parametersOfGetFieldProperties.Length.ShouldBe(1);
            methodGetFieldPropertiesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(null, parametersOfGetFieldProperties));
        }

        #endregion

        #region Method Call : (GetFieldProperties) (Return Type : Dictionary<string, Dictionary<string, string>>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetFieldProperties_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spList = CreateType<SPList>();
            var methodGetFieldPropertiesPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfGetFieldProperties = { spList };

            // Assert
            parametersOfGetFieldProperties.ShouldNotBeNull();
            parametersOfGetFieldProperties.Length.ShouldBe(1);
            methodGetFieldPropertiesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, Dictionary<string, string>>>(null, _utilsInstanceType, MethodGetFieldProperties, parametersOfGetFieldProperties, methodGetFieldPropertiesPrametersTypes));
        }

        #endregion

        #region Method Call : (GetFieldProperties) (Return Type : Dictionary<string, Dictionary<string, string>>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetFieldProperties_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFieldPropertiesPrametersTypes = new Type[] { typeof(SPList) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetFieldProperties, Fixture, methodGetFieldPropertiesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFieldPropertiesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFieldProperties) (Return Type : Dictionary<string, Dictionary<string, string>>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetFieldProperties_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFieldPropertiesPrametersTypes = new Type[] { typeof(SPList) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetFieldProperties, Fixture, methodGetFieldPropertiesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFieldPropertiesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFieldProperties) (Return Type : Dictionary<string, Dictionary<string, string>>) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetFieldProperties_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFieldProperties, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetFieldProperties) (Return Type : Dictionary<string, Dictionary<string, string>>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetFieldProperties_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFieldProperties, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFieldTypes) (Return Type : Dictionary<string, SPField>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utils_GetFieldTypes_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFieldTypesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetFieldTypes, Fixture, methodGetFieldTypesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFieldTypes) (Return Type : Dictionary<string, SPField>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetFieldTypes_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetFieldTypesPrametersTypes = null;
            object[] parametersOfGetFieldTypes = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetFieldTypes, methodGetFieldTypesPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetFieldTypes, Fixture, methodGetFieldTypesPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, SPField>>(null, _utilsInstanceType, MethodGetFieldTypes, parametersOfGetFieldTypes, methodGetFieldTypesPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetFieldTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFieldTypes.ShouldBeNull();
            methodGetFieldTypesPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetFieldTypes) (Return Type : Dictionary<string, SPField>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetFieldTypes_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetFieldTypesPrametersTypes = null;
            object[] parametersOfGetFieldTypes = null; // no parameter present

            // Assert
            parametersOfGetFieldTypes.ShouldBeNull();
            methodGetFieldTypesPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, SPField>>(null, _utilsInstanceType, MethodGetFieldTypes, parametersOfGetFieldTypes, methodGetFieldTypesPrametersTypes));
        }

        #endregion

        #region Method Call : (GetFieldTypes) (Return Type : Dictionary<string, SPField>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetFieldTypes_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetFieldTypesPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetFieldTypes, Fixture, methodGetFieldTypesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFieldTypesPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFieldTypes) (Return Type : Dictionary<string, SPField>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetFieldTypes_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetFieldTypesPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetFieldTypes, Fixture, methodGetFieldTypesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFieldTypesPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFieldTypes) (Return Type : Dictionary<string, SPField>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetFieldTypes_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFieldTypes, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFieldValues) (Return Type : Dictionary<string, string>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utils_GetFieldValues_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFieldValuesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetFieldValues, Fixture, methodGetFieldValuesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFieldValues) (Return Type : Dictionary<string, string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetFieldValues_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var xElement = CreateType<XElement>();
            var methodGetFieldValuesPrametersTypes = new Type[] { typeof(XElement) };
            object[] parametersOfGetFieldValues = { xElement };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetFieldValues, methodGetFieldValuesPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetFieldValues, Fixture, methodGetFieldValuesPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, string>>(null, _utilsInstanceType, MethodGetFieldValues, parametersOfGetFieldValues, methodGetFieldValuesPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetFieldValues);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFieldValues.ShouldNotBeNull();
            parametersOfGetFieldValues.Length.ShouldBe(1);
            methodGetFieldValuesPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetFieldValues) (Return Type : Dictionary<string, string>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetFieldValues_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xElement = CreateType<XElement>();
            var methodGetFieldValuesPrametersTypes = new Type[] { typeof(XElement) };
            object[] parametersOfGetFieldValues = { xElement };

            // Assert
            parametersOfGetFieldValues.ShouldNotBeNull();
            parametersOfGetFieldValues.Length.ShouldBe(1);
            methodGetFieldValuesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, string>>(null, _utilsInstanceType, MethodGetFieldValues, parametersOfGetFieldValues, methodGetFieldValuesPrametersTypes));
        }

        #endregion

        #region Method Call : (GetFieldValues) (Return Type : Dictionary<string, string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetFieldValues_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFieldValuesPrametersTypes = new Type[] { typeof(XElement) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetFieldValues, Fixture, methodGetFieldValuesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFieldValuesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFieldValues) (Return Type : Dictionary<string, string>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetFieldValues_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFieldValuesPrametersTypes = new Type[] { typeof(XElement) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetFieldValues, Fixture, methodGetFieldValuesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFieldValuesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFieldValues) (Return Type : Dictionary<string, string>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetFieldValues_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFieldValues, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFieldValues) (Return Type : Dictionary<string, string>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetFieldValues_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFieldValues, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetItemListWebSite) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utils_GetItemListWebSite_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetItemListWebSitePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetItemListWebSite, Fixture, methodGetItemListWebSitePrametersTypes);
        }

        #endregion

        #region Method Call : (GetItemListWebSite) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetItemListWebSite_Static_Method_Call_Void_With_7_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var element = CreateType<XElement>();
            var itemId = CreateType<int>();
            var listId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var siteId = CreateType<Guid>();
            var siteUrl = CreateType<string>();
            var methodGetItemListWebSitePrametersTypes = new Type[] { typeof(string), typeof(XElement), typeof(int), typeof(Guid), typeof(Guid), typeof(Guid), typeof(string) };
            object[] parametersOfGetItemListWebSite = { data, element, itemId, listId, webId, siteId, siteUrl };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetItemListWebSite, methodGetItemListWebSitePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetItemListWebSite);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetItemListWebSite.ShouldNotBeNull();
            parametersOfGetItemListWebSite.Length.ShouldBe(7);
            methodGetItemListWebSitePrametersTypes.Length.ShouldBe(7);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetItemListWebSite) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetItemListWebSite_Static_Method_Call_Void_With_7_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var element = CreateType<XElement>();
            var itemId = CreateType<int>();
            var listId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var siteId = CreateType<Guid>();
            var siteUrl = CreateType<string>();
            var methodGetItemListWebSitePrametersTypes = new Type[] { typeof(string), typeof(XElement), typeof(int), typeof(Guid), typeof(Guid), typeof(Guid), typeof(string) };
            object[] parametersOfGetItemListWebSite = { data, element, itemId, listId, webId, siteId, siteUrl };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(null, _utilsInstanceType, MethodGetItemListWebSite, parametersOfGetItemListWebSite, methodGetItemListWebSitePrametersTypes);

            // Assert
            parametersOfGetItemListWebSite.ShouldNotBeNull();
            parametersOfGetItemListWebSite.Length.ShouldBe(7);
            methodGetItemListWebSitePrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetItemListWebSite) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetItemListWebSite_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetItemListWebSite, 0);
            const int parametersCount = 7;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetItemListWebSite) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetItemListWebSite_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetItemListWebSitePrametersTypes = new Type[] { typeof(string), typeof(XElement), typeof(int), typeof(Guid), typeof(Guid), typeof(Guid), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetItemListWebSite, Fixture, methodGetItemListWebSitePrametersTypes);

            // Assert
            methodGetItemListWebSitePrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetItemListWebSite) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetItemListWebSite_Static_Method_Call_With_7_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetItemListWebSite, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListWebSite) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utils_GetListWebSite_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetListWebSitePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetListWebSite, Fixture, methodGetListWebSitePrametersTypes);
        }

        #endregion

        #region Method Call : (GetListWebSite) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetListWebSite_Static_Method_Call_Void_With_6_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var element = CreateType<XElement>();
            var listId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var siteId = CreateType<Guid>();
            var siteUrl = CreateType<string>();
            var methodGetListWebSitePrametersTypes = new Type[] { typeof(string), typeof(XElement), typeof(Guid), typeof(Guid), typeof(Guid), typeof(string) };
            object[] parametersOfGetListWebSite = { data, element, listId, webId, siteId, siteUrl };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetListWebSite, methodGetListWebSitePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetListWebSite);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetListWebSite.ShouldNotBeNull();
            parametersOfGetListWebSite.Length.ShouldBe(6);
            methodGetListWebSitePrametersTypes.Length.ShouldBe(6);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetListWebSite) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetListWebSite_Static_Method_Call_Void_With_6_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var element = CreateType<XElement>();
            var listId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var siteId = CreateType<Guid>();
            var siteUrl = CreateType<string>();
            var methodGetListWebSitePrametersTypes = new Type[] { typeof(string), typeof(XElement), typeof(Guid), typeof(Guid), typeof(Guid), typeof(string) };
            object[] parametersOfGetListWebSite = { data, element, listId, webId, siteId, siteUrl };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(null, _utilsInstanceType, MethodGetListWebSite, parametersOfGetListWebSite, methodGetListWebSitePrametersTypes);

            // Assert
            parametersOfGetListWebSite.ShouldNotBeNull();
            parametersOfGetListWebSite.Length.ShouldBe(6);
            methodGetListWebSitePrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListWebSite) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetListWebSite_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetListWebSite, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListWebSite) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetListWebSite_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetListWebSitePrametersTypes = new Type[] { typeof(string), typeof(XElement), typeof(Guid), typeof(Guid), typeof(Guid), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetListWebSite, Fixture, methodGetListWebSitePrametersTypes);

            // Assert
            methodGetListWebSitePrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListWebSite) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetListWebSite_Static_Method_Call_With_6_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListWebSite, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetRelatedGridType) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utils_GetRelatedGridType_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetRelatedGridTypePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetRelatedGridType, Fixture, methodGetRelatedGridTypePrametersTypes);
        }

        #endregion

        #region Method Call : (GetRelatedGridType) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetRelatedGridType_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sPField = CreateType<SPField>();
            var methodGetRelatedGridTypePrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfGetRelatedGridType = { sPField };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetRelatedGridType, methodGetRelatedGridTypePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetRelatedGridType, Fixture, methodGetRelatedGridTypePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _utilsInstanceType, MethodGetRelatedGridType, parametersOfGetRelatedGridType, methodGetRelatedGridTypePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetRelatedGridType);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetRelatedGridType.ShouldNotBeNull();
            parametersOfGetRelatedGridType.Length.ShouldBe(1);
            methodGetRelatedGridTypePrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetRelatedGridType) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetRelatedGridType_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sPField = CreateType<SPField>();
            var methodGetRelatedGridTypePrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfGetRelatedGridType = { sPField };

            // Assert
            parametersOfGetRelatedGridType.ShouldNotBeNull();
            parametersOfGetRelatedGridType.Length.ShouldBe(1);
            methodGetRelatedGridTypePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _utilsInstanceType, MethodGetRelatedGridType, parametersOfGetRelatedGridType, methodGetRelatedGridTypePrametersTypes));
        }

        #endregion

        #region Method Call : (GetRelatedGridType) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetRelatedGridType_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetRelatedGridTypePrametersTypes = new Type[] { typeof(SPField) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetRelatedGridType, Fixture, methodGetRelatedGridTypePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetRelatedGridTypePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetRelatedGridType) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetRelatedGridType_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetRelatedGridTypePrametersTypes = new Type[] { typeof(SPField) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetRelatedGridType, Fixture, methodGetRelatedGridTypePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetRelatedGridTypePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRelatedGridType) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetRelatedGridType_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetRelatedGridType, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRelatedGridType) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetRelatedGridType_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetRelatedGridType, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRelatedGridTypeForMyTimesheet) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utils_GetRelatedGridTypeForMyTimesheet_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetRelatedGridTypeForMyTimesheetPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetRelatedGridTypeForMyTimesheet, Fixture, methodGetRelatedGridTypeForMyTimesheetPrametersTypes);
        }

        #endregion

        #region Method Call : (GetRelatedGridTypeForMyTimesheet) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetRelatedGridTypeForMyTimesheet_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sPField = CreateType<SPField>();
            var methodGetRelatedGridTypeForMyTimesheetPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfGetRelatedGridTypeForMyTimesheet = { sPField };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetRelatedGridTypeForMyTimesheet, methodGetRelatedGridTypeForMyTimesheetPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetRelatedGridTypeForMyTimesheet, Fixture, methodGetRelatedGridTypeForMyTimesheetPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _utilsInstanceType, MethodGetRelatedGridTypeForMyTimesheet, parametersOfGetRelatedGridTypeForMyTimesheet, methodGetRelatedGridTypeForMyTimesheetPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetRelatedGridTypeForMyTimesheet);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetRelatedGridTypeForMyTimesheet.ShouldNotBeNull();
            parametersOfGetRelatedGridTypeForMyTimesheet.Length.ShouldBe(1);
            methodGetRelatedGridTypeForMyTimesheetPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetRelatedGridTypeForMyTimesheet) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetRelatedGridTypeForMyTimesheet_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sPField = CreateType<SPField>();
            var methodGetRelatedGridTypeForMyTimesheetPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfGetRelatedGridTypeForMyTimesheet = { sPField };

            // Assert
            parametersOfGetRelatedGridTypeForMyTimesheet.ShouldNotBeNull();
            parametersOfGetRelatedGridTypeForMyTimesheet.Length.ShouldBe(1);
            methodGetRelatedGridTypeForMyTimesheetPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _utilsInstanceType, MethodGetRelatedGridTypeForMyTimesheet, parametersOfGetRelatedGridTypeForMyTimesheet, methodGetRelatedGridTypeForMyTimesheetPrametersTypes));
        }

        #endregion

        #region Method Call : (GetRelatedGridTypeForMyTimesheet) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetRelatedGridTypeForMyTimesheet_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetRelatedGridTypeForMyTimesheetPrametersTypes = new Type[] { typeof(SPField) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetRelatedGridTypeForMyTimesheet, Fixture, methodGetRelatedGridTypeForMyTimesheetPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetRelatedGridTypeForMyTimesheetPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetRelatedGridTypeForMyTimesheet) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetRelatedGridTypeForMyTimesheet_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetRelatedGridTypeForMyTimesheetPrametersTypes = new Type[] { typeof(SPField) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodGetRelatedGridTypeForMyTimesheet, Fixture, methodGetRelatedGridTypeForMyTimesheetPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetRelatedGridTypeForMyTimesheetPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRelatedGridTypeForMyTimesheet) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetRelatedGridTypeForMyTimesheet_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetRelatedGridTypeForMyTimesheet, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRelatedGridTypeForMyTimesheet) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_GetRelatedGridTypeForMyTimesheet_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetRelatedGridTypeForMyTimesheet, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ToOriginalFieldName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utils_ToOriginalFieldName_Static_Method_Call_Internally(Type[] types)
        {
            var methodToOriginalFieldNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodToOriginalFieldName, Fixture, methodToOriginalFieldNamePrametersTypes);
        }

        #endregion

        #region Method Call : (ToOriginalFieldName) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_ToOriginalFieldName_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var methodToOriginalFieldNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfToOriginalFieldName = { name };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodToOriginalFieldName, methodToOriginalFieldNamePrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfToOriginalFieldName.ShouldNotBeNull();
            parametersOfToOriginalFieldName.Length.ShouldBe(1);
            methodToOriginalFieldNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(null, parametersOfToOriginalFieldName));
        }

        #endregion

        #region Method Call : (ToOriginalFieldName) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_ToOriginalFieldName_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var methodToOriginalFieldNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfToOriginalFieldName = { name };

            // Assert
            parametersOfToOriginalFieldName.ShouldNotBeNull();
            parametersOfToOriginalFieldName.Length.ShouldBe(1);
            methodToOriginalFieldNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _utilsInstanceType, MethodToOriginalFieldName, parametersOfToOriginalFieldName, methodToOriginalFieldNamePrametersTypes));
        }

        #endregion

        #region Method Call : (ToOriginalFieldName) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_ToOriginalFieldName_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodToOriginalFieldNamePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodToOriginalFieldName, Fixture, methodToOriginalFieldNamePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodToOriginalFieldNamePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ToOriginalFieldName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_ToOriginalFieldName_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodToOriginalFieldNamePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodToOriginalFieldName, Fixture, methodToOriginalFieldNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodToOriginalFieldNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ToOriginalFieldName) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_ToOriginalFieldName_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodToOriginalFieldName, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ToOriginalFieldName) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_ToOriginalFieldName_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodToOriginalFieldName, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ValidateItemListWebAndSite) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utils_ValidateItemListWebAndSite_Static_Method_Call_Internally(Type[] types)
        {
            var methodValidateItemListWebAndSitePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodValidateItemListWebAndSite, Fixture, methodValidateItemListWebAndSitePrametersTypes);
        }

        #endregion

        #region Method Call : (ValidateItemListWebAndSite) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_ValidateItemListWebAndSite_Static_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var element = CreateType<XElement>();
            var methodValidateItemListWebAndSitePrametersTypes = new Type[] { typeof(XElement) };
            object[] parametersOfValidateItemListWebAndSite = { element };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodValidateItemListWebAndSite, methodValidateItemListWebAndSitePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfValidateItemListWebAndSite);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfValidateItemListWebAndSite.ShouldNotBeNull();
            parametersOfValidateItemListWebAndSite.Length.ShouldBe(1);
            methodValidateItemListWebAndSitePrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ValidateItemListWebAndSite) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_ValidateItemListWebAndSite_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var element = CreateType<XElement>();
            var methodValidateItemListWebAndSitePrametersTypes = new Type[] { typeof(XElement) };
            object[] parametersOfValidateItemListWebAndSite = { element };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(null, _utilsInstanceType, MethodValidateItemListWebAndSite, parametersOfValidateItemListWebAndSite, methodValidateItemListWebAndSitePrametersTypes);

            // Assert
            parametersOfValidateItemListWebAndSite.ShouldNotBeNull();
            parametersOfValidateItemListWebAndSite.Length.ShouldBe(1);
            methodValidateItemListWebAndSitePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ValidateItemListWebAndSite) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_ValidateItemListWebAndSite_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodValidateItemListWebAndSite, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ValidateItemListWebAndSite) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_ValidateItemListWebAndSite_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodValidateItemListWebAndSitePrametersTypes = new Type[] { typeof(XElement) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodValidateItemListWebAndSite, Fixture, methodValidateItemListWebAndSitePrametersTypes);

            // Assert
            methodValidateItemListWebAndSitePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ValidateItemListWebAndSite) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_ValidateItemListWebAndSite_Static_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodValidateItemListWebAndSite, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ValidateListWebAndSite) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utils_ValidateListWebAndSite_Static_Method_Call_Internally(Type[] types)
        {
            var methodValidateListWebAndSitePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodValidateListWebAndSite, Fixture, methodValidateListWebAndSitePrametersTypes);
        }

        #endregion

        #region Method Call : (ValidateListWebAndSite) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_ValidateListWebAndSite_Static_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var element = CreateType<XElement>();
            var methodValidateListWebAndSitePrametersTypes = new Type[] { typeof(XElement) };
            object[] parametersOfValidateListWebAndSite = { element };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodValidateListWebAndSite, methodValidateListWebAndSitePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfValidateListWebAndSite);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfValidateListWebAndSite.ShouldNotBeNull();
            parametersOfValidateListWebAndSite.Length.ShouldBe(1);
            methodValidateListWebAndSitePrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ValidateListWebAndSite) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_ValidateListWebAndSite_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var element = CreateType<XElement>();
            var methodValidateListWebAndSitePrametersTypes = new Type[] { typeof(XElement) };
            object[] parametersOfValidateListWebAndSite = { element };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(null, _utilsInstanceType, MethodValidateListWebAndSite, parametersOfValidateListWebAndSite, methodValidateListWebAndSitePrametersTypes);

            // Assert
            parametersOfValidateListWebAndSite.ShouldNotBeNull();
            parametersOfValidateListWebAndSite.Length.ShouldBe(1);
            methodValidateListWebAndSitePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ValidateListWebAndSite) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_ValidateListWebAndSite_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodValidateListWebAndSite, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ValidateListWebAndSite) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_ValidateListWebAndSite_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodValidateListWebAndSitePrametersTypes = new Type[] { typeof(XElement) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilsInstanceType, MethodValidateListWebAndSite, Fixture, methodValidateListWebAndSitePrametersTypes);

            // Assert
            methodValidateListWebAndSitePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ValidateListWebAndSite) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utils_ValidateListWebAndSite_Static_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodValidateListWebAndSite, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
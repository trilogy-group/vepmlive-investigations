using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace PortfolioEngineCore.PortfolioItems
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PortfolioEngineCore.PortfolioItems.PortfolioItems" />)
    ///     and namespace <see cref="PortfolioEngineCore.PortfolioItems"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
	[ExcludeFromCodeCoverage]
    public class PortfolioItemsTest : AbstractBaseSetupTypedTest<PortfolioItems>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (PortfolioItems) Initializer

        private const string MethodObtainManagedPortfolioItems = "ObtainManagedPortfolioItems";
        private const string MethodGeneratePortfolioItemTicket = "GeneratePortfolioItemTicket";
        private const string MethodUpdatePortfolioItems = "UpdatePortfolioItems";
        private const string MethodClosePortfolioItems = "ClosePortfolioItems";
        private const string MethodCreateUpdateUpdatePortfolioItemsXML = "CreateUpdateUpdatePortfolioItemsXML";
        private const string MethodCreatePI = "CreatePI";
        private const string MethodGetPITitleValue = "GetPITitleValue";
        private const string MethodStripNum = "StripNum";
        private const string MethodUpdatePI = "UpdatePI";
        private const string MethodPerformCustomFieldsCalculate = "PerformCustomFieldsCalculate";
        private const string MethodGetCustFieldVal = "GetCustFieldVal";
        private const string MethodFormatAs000 = "FormatAs000";
        private const string MethodInsertDateString = "InsertDateString";
        private const string MethodResolveResName = "ResolveResName";
        private const string MethodResolveNameAndDelegates = "ResolveNameAndDelegates";
        private const string MethodDoFlagStuff = "DoFlagStuff";
        private const string MethodDoIntStuff = "DoIntStuff";
        private const string MethodDoDoubleStuff = "DoDoubleStuff";
        private const string MethodExecuteSQLSelect = "ExecuteSQLSelect";
        private const string MethodExportPIInfo = "ExportPIInfo";
        private const string MethodGetMVValue = "GetMVValue";
        private const string MethodGetLookupValue = "GetLookupValue";
        private const string MethodUpdateProjectDiscountRate = "UpdateProjectDiscountRate";
        private const string FieldLogKeyword = "LogKeyword";
        private const string FieldLogProjectDiscountRateFunction = "LogProjectDiscountRateFunction";
        private const string FieldLogProjectDiscountRateMessage = "LogProjectDiscountRateMessage";
        private const string FieldLogProjectDiscountRateError = "LogProjectDiscountRateError";
        private const string FieldDiscountRateXmlAttribute = "DiscountRateXmlAttribute";
        private const string FieldDiscountRatePreviousValueXmlAttribute = "DiscountRatePreviousValueXmlAttribute";
        private const string Field_sqlConnection = "_sqlConnection";
        private const string FieldCONST_PI_MANAGER_SURROGATE_CONTEXT = "CONST_PI_MANAGER_SURROGATE_CONTEXT";
        private Type _portfolioItemsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private PortfolioItems _portfolioItemsInstance;
        private PortfolioItems _portfolioItemsInstanceFixture;

        #region General Initializer : Class (PortfolioItems) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PortfolioItems" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _portfolioItemsInstanceType = typeof(PortfolioItems);
            _portfolioItemsInstanceFixture = Create(true);
            _portfolioItemsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PortfolioItems)

        #region General Initializer : Class (PortfolioItems) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="PortfolioItems" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodObtainManagedPortfolioItems, 0)]
        [TestCase(MethodGeneratePortfolioItemTicket, 0)]
        [TestCase(MethodUpdatePortfolioItems, 0)]
        [TestCase(MethodClosePortfolioItems, 0)]
        [TestCase(MethodCreateUpdateUpdatePortfolioItemsXML, 0)]
        [TestCase(MethodCreatePI, 0)]
        [TestCase(MethodGetPITitleValue, 0)]
        [TestCase(MethodStripNum, 0)]
        [TestCase(MethodUpdatePI, 0)]
        [TestCase(MethodPerformCustomFieldsCalculate, 0)]
        [TestCase(MethodGetCustFieldVal, 0)]
        [TestCase(MethodFormatAs000, 0)]
        [TestCase(MethodInsertDateString, 0)]
        [TestCase(MethodResolveResName, 0)]
        [TestCase(MethodResolveNameAndDelegates, 0)]
        [TestCase(MethodDoFlagStuff, 0)]
        [TestCase(MethodDoIntStuff, 0)]
        [TestCase(MethodDoDoubleStuff, 0)]
        [TestCase(MethodExecuteSQLSelect, 0)]
        [TestCase(MethodExportPIInfo, 0)]
        [TestCase(MethodGetMVValue, 0)]
        [TestCase(MethodGetLookupValue, 0)]
        public void AUT_PortfolioItems_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_portfolioItemsInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="PortfolioItems" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetCustFieldVal)]
        [TestCase(MethodExecuteSQLSelect)]
        [TestCase(MethodGetMVValue)]
        [TestCase(MethodGetLookupValue)]
        public void AUT_PortfolioItems_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_portfolioItemsInstanceFixture,
                                                                              _portfolioItemsInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="PortfolioItems" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodObtainManagedPortfolioItems)]
        [TestCase(MethodGeneratePortfolioItemTicket)]
        [TestCase(MethodUpdatePortfolioItems)]
        [TestCase(MethodClosePortfolioItems)]
        [TestCase(MethodCreateUpdateUpdatePortfolioItemsXML)]
        [TestCase(MethodCreatePI)]
        [TestCase(MethodGetPITitleValue)]
        [TestCase(MethodStripNum)]
        [TestCase(MethodUpdatePI)]
        [TestCase(MethodPerformCustomFieldsCalculate)]
        [TestCase(MethodFormatAs000)]
        [TestCase(MethodInsertDateString)]
        [TestCase(MethodResolveResName)]
        [TestCase(MethodResolveNameAndDelegates)]
        [TestCase(MethodDoFlagStuff)]
        [TestCase(MethodDoIntStuff)]
        [TestCase(MethodDoDoubleStuff)]
        [TestCase(MethodExportPIInfo)]
        [TestCase(MethodUpdateProjectDiscountRate)]
        public void AUT_PortfolioItems_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<PortfolioItems>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (ObtainManagedPortfolioItems) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioItems_ObtainManagedPortfolioItems_Method_Call_Internally(Type[] types)
        {
            var methodObtainManagedPortfolioItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodObtainManagedPortfolioItems, Fixture, methodObtainManagedPortfolioItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (ObtainManagedPortfolioItems) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_ObtainManagedPortfolioItems_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sExtIDList = CreateType<string>();
            var sPIDList = CreateType<string>();
            var sXML = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _portfolioItemsInstance.ObtainManagedPortfolioItems(out sExtIDList, out sPIDList, out sXML);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ObtainManagedPortfolioItems) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_ObtainManagedPortfolioItems_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sExtIDList = CreateType<string>();
            var sPIDList = CreateType<string>();
            var sXML = CreateType<string>();
            var methodObtainManagedPortfolioItemsPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            object[] parametersOfObtainManagedPortfolioItems = { sExtIDList, sPIDList, sXML };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodObtainManagedPortfolioItems, methodObtainManagedPortfolioItemsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_portfolioItemsInstanceFixture, parametersOfObtainManagedPortfolioItems);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfObtainManagedPortfolioItems.ShouldNotBeNull();
            parametersOfObtainManagedPortfolioItems.Length.ShouldBe(3);
            methodObtainManagedPortfolioItemsPrametersTypes.Length.ShouldBe(3);
            methodObtainManagedPortfolioItemsPrametersTypes.Length.ShouldBe(parametersOfObtainManagedPortfolioItems.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ObtainManagedPortfolioItems) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_ObtainManagedPortfolioItems_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sExtIDList = CreateType<string>();
            var sPIDList = CreateType<string>();
            var sXML = CreateType<string>();
            var methodObtainManagedPortfolioItemsPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            object[] parametersOfObtainManagedPortfolioItems = { sExtIDList, sPIDList, sXML };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_portfolioItemsInstance, MethodObtainManagedPortfolioItems, parametersOfObtainManagedPortfolioItems, methodObtainManagedPortfolioItemsPrametersTypes);

            // Assert
            parametersOfObtainManagedPortfolioItems.ShouldNotBeNull();
            parametersOfObtainManagedPortfolioItems.Length.ShouldBe(3);
            methodObtainManagedPortfolioItemsPrametersTypes.Length.ShouldBe(3);
            methodObtainManagedPortfolioItemsPrametersTypes.Length.ShouldBe(parametersOfObtainManagedPortfolioItems.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ObtainManagedPortfolioItems) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_ObtainManagedPortfolioItems_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodObtainManagedPortfolioItems, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ObtainManagedPortfolioItems) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_ObtainManagedPortfolioItems_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodObtainManagedPortfolioItemsPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodObtainManagedPortfolioItems, Fixture, methodObtainManagedPortfolioItemsPrametersTypes);

            // Assert
            methodObtainManagedPortfolioItemsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ObtainManagedPortfolioItems) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_ObtainManagedPortfolioItems_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodObtainManagedPortfolioItems, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioItemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GeneratePortfolioItemTicket) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioItems_GeneratePortfolioItemTicket_Method_Call_Internally(Type[] types)
        {
            var methodGeneratePortfolioItemTicketPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodGeneratePortfolioItemTicket, Fixture, methodGeneratePortfolioItemTicketPrametersTypes);
        }

        #endregion

        #region Method Call : (GeneratePortfolioItemTicket) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_GeneratePortfolioItemTicket_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sDataIn = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _portfolioItemsInstance.GeneratePortfolioItemTicket(sDataIn);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GeneratePortfolioItemTicket) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_GeneratePortfolioItemTicket_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sDataIn = CreateType<string>();
            var methodGeneratePortfolioItemTicketPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGeneratePortfolioItemTicket = { sDataIn };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGeneratePortfolioItemTicket, methodGeneratePortfolioItemTicketPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PortfolioItems, string>(_portfolioItemsInstanceFixture, out exception1, parametersOfGeneratePortfolioItemTicket);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PortfolioItems, string>(_portfolioItemsInstance, MethodGeneratePortfolioItemTicket, parametersOfGeneratePortfolioItemTicket, methodGeneratePortfolioItemTicketPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGeneratePortfolioItemTicket.ShouldNotBeNull();
            parametersOfGeneratePortfolioItemTicket.Length.ShouldBe(1);
            methodGeneratePortfolioItemTicketPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GeneratePortfolioItemTicket) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_GeneratePortfolioItemTicket_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sDataIn = CreateType<string>();
            var methodGeneratePortfolioItemTicketPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGeneratePortfolioItemTicket = { sDataIn };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<PortfolioItems, string>(_portfolioItemsInstance, MethodGeneratePortfolioItemTicket, parametersOfGeneratePortfolioItemTicket, methodGeneratePortfolioItemTicketPrametersTypes);

            // Assert
            parametersOfGeneratePortfolioItemTicket.ShouldNotBeNull();
            parametersOfGeneratePortfolioItemTicket.Length.ShouldBe(1);
            methodGeneratePortfolioItemTicketPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GeneratePortfolioItemTicket) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_GeneratePortfolioItemTicket_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGeneratePortfolioItemTicketPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodGeneratePortfolioItemTicket, Fixture, methodGeneratePortfolioItemTicketPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGeneratePortfolioItemTicketPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GeneratePortfolioItemTicket) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_GeneratePortfolioItemTicket_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGeneratePortfolioItemTicketPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodGeneratePortfolioItemTicket, Fixture, methodGeneratePortfolioItemTicketPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGeneratePortfolioItemTicketPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GeneratePortfolioItemTicket) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_GeneratePortfolioItemTicket_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGeneratePortfolioItemTicket, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioItemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GeneratePortfolioItemTicket) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_GeneratePortfolioItemTicket_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGeneratePortfolioItemTicket, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdatePortfolioItems) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioItems_UpdatePortfolioItems_Method_Call_Internally(Type[] types)
        {
            var methodUpdatePortfolioItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodUpdatePortfolioItems, Fixture, methodUpdatePortfolioItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdatePortfolioItems) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_UpdatePortfolioItems_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _portfolioItemsInstance.UpdatePortfolioItems(xml);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdatePortfolioItems) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_UpdatePortfolioItems_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodUpdatePortfolioItemsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdatePortfolioItems = { xml };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdatePortfolioItems, methodUpdatePortfolioItemsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PortfolioItems, string>(_portfolioItemsInstanceFixture, out exception1, parametersOfUpdatePortfolioItems);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PortfolioItems, string>(_portfolioItemsInstance, MethodUpdatePortfolioItems, parametersOfUpdatePortfolioItems, methodUpdatePortfolioItemsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfUpdatePortfolioItems.ShouldNotBeNull();
            parametersOfUpdatePortfolioItems.Length.ShouldBe(1);
            methodUpdatePortfolioItemsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (UpdatePortfolioItems) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_UpdatePortfolioItems_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodUpdatePortfolioItemsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdatePortfolioItems = { xml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<PortfolioItems, string>(_portfolioItemsInstance, MethodUpdatePortfolioItems, parametersOfUpdatePortfolioItems, methodUpdatePortfolioItemsPrametersTypes);

            // Assert
            parametersOfUpdatePortfolioItems.ShouldNotBeNull();
            parametersOfUpdatePortfolioItems.Length.ShouldBe(1);
            methodUpdatePortfolioItemsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdatePortfolioItems) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_UpdatePortfolioItems_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodUpdatePortfolioItemsPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodUpdatePortfolioItems, Fixture, methodUpdatePortfolioItemsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodUpdatePortfolioItemsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (UpdatePortfolioItems) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_UpdatePortfolioItems_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdatePortfolioItemsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodUpdatePortfolioItems, Fixture, methodUpdatePortfolioItemsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdatePortfolioItemsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdatePortfolioItems) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_UpdatePortfolioItems_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdatePortfolioItems, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioItemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdatePortfolioItems) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_UpdatePortfolioItems_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdatePortfolioItems, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ClosePortfolioItems) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioItems_ClosePortfolioItems_Method_Call_Internally(Type[] types)
        {
            var methodClosePortfolioItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodClosePortfolioItems, Fixture, methodClosePortfolioItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (ClosePortfolioItems) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_ClosePortfolioItems_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _portfolioItemsInstance.ClosePortfolioItems(xml);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ClosePortfolioItems) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_ClosePortfolioItems_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodClosePortfolioItemsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfClosePortfolioItems = { xml };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodClosePortfolioItems, methodClosePortfolioItemsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PortfolioItems, string>(_portfolioItemsInstanceFixture, out exception1, parametersOfClosePortfolioItems);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PortfolioItems, string>(_portfolioItemsInstance, MethodClosePortfolioItems, parametersOfClosePortfolioItems, methodClosePortfolioItemsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfClosePortfolioItems.ShouldNotBeNull();
            parametersOfClosePortfolioItems.Length.ShouldBe(1);
            methodClosePortfolioItemsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ClosePortfolioItems) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_ClosePortfolioItems_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodClosePortfolioItemsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfClosePortfolioItems = { xml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<PortfolioItems, string>(_portfolioItemsInstance, MethodClosePortfolioItems, parametersOfClosePortfolioItems, methodClosePortfolioItemsPrametersTypes);

            // Assert
            parametersOfClosePortfolioItems.ShouldNotBeNull();
            parametersOfClosePortfolioItems.Length.ShouldBe(1);
            methodClosePortfolioItemsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClosePortfolioItems) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_ClosePortfolioItems_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodClosePortfolioItemsPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodClosePortfolioItems, Fixture, methodClosePortfolioItemsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodClosePortfolioItemsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ClosePortfolioItems) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_ClosePortfolioItems_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodClosePortfolioItemsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodClosePortfolioItems, Fixture, methodClosePortfolioItemsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodClosePortfolioItemsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ClosePortfolioItems) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_ClosePortfolioItems_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodClosePortfolioItems, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioItemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ClosePortfolioItems) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_ClosePortfolioItems_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodClosePortfolioItems, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateUpdateUpdatePortfolioItemsXML) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioItems_CreateUpdateUpdatePortfolioItemsXML_Method_Call_Internally(Type[] types)
        {
            var methodCreateUpdateUpdatePortfolioItemsXMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodCreateUpdateUpdatePortfolioItemsXML, Fixture, methodCreateUpdateUpdatePortfolioItemsXMLPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateUpdateUpdatePortfolioItemsXML) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_CreateUpdateUpdatePortfolioItemsXML_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var pids = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _portfolioItemsInstance.CreateUpdateUpdatePortfolioItemsXML(pids);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CreateUpdateUpdatePortfolioItemsXML) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_CreateUpdateUpdatePortfolioItemsXML_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var pids = CreateType<string>();
            var methodCreateUpdateUpdatePortfolioItemsXMLPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfCreateUpdateUpdatePortfolioItemsXML = { pids };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCreateUpdateUpdatePortfolioItemsXML, methodCreateUpdateUpdatePortfolioItemsXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PortfolioItems, string>(_portfolioItemsInstanceFixture, out exception1, parametersOfCreateUpdateUpdatePortfolioItemsXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PortfolioItems, string>(_portfolioItemsInstance, MethodCreateUpdateUpdatePortfolioItemsXML, parametersOfCreateUpdateUpdatePortfolioItemsXML, methodCreateUpdateUpdatePortfolioItemsXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfCreateUpdateUpdatePortfolioItemsXML.ShouldNotBeNull();
            parametersOfCreateUpdateUpdatePortfolioItemsXML.Length.ShouldBe(1);
            methodCreateUpdateUpdatePortfolioItemsXMLPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (CreateUpdateUpdatePortfolioItemsXML) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_CreateUpdateUpdatePortfolioItemsXML_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var pids = CreateType<string>();
            var methodCreateUpdateUpdatePortfolioItemsXMLPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfCreateUpdateUpdatePortfolioItemsXML = { pids };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<PortfolioItems, string>(_portfolioItemsInstance, MethodCreateUpdateUpdatePortfolioItemsXML, parametersOfCreateUpdateUpdatePortfolioItemsXML, methodCreateUpdateUpdatePortfolioItemsXMLPrametersTypes);

            // Assert
            parametersOfCreateUpdateUpdatePortfolioItemsXML.ShouldNotBeNull();
            parametersOfCreateUpdateUpdatePortfolioItemsXML.Length.ShouldBe(1);
            methodCreateUpdateUpdatePortfolioItemsXMLPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateUpdateUpdatePortfolioItemsXML) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_CreateUpdateUpdatePortfolioItemsXML_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCreateUpdateUpdatePortfolioItemsXMLPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodCreateUpdateUpdatePortfolioItemsXML, Fixture, methodCreateUpdateUpdatePortfolioItemsXMLPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCreateUpdateUpdatePortfolioItemsXMLPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (CreateUpdateUpdatePortfolioItemsXML) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_CreateUpdateUpdatePortfolioItemsXML_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateUpdateUpdatePortfolioItemsXMLPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodCreateUpdateUpdatePortfolioItemsXML, Fixture, methodCreateUpdateUpdatePortfolioItemsXMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreateUpdateUpdatePortfolioItemsXMLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateUpdateUpdatePortfolioItemsXML) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_CreateUpdateUpdatePortfolioItemsXML_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateUpdateUpdatePortfolioItemsXML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioItemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateUpdateUpdatePortfolioItemsXML) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_CreateUpdateUpdatePortfolioItemsXML_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreateUpdateUpdatePortfolioItemsXML, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreatePI) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioItems_CreatePI_Method_Call_Internally(Type[] types)
        {
            var methodCreatePIPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodCreatePI, Fixture, methodCreatePIPrametersTypes);
        }

        #endregion

        #region Method Call : (CreatePI) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_CreatePI_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sGuid = CreateType<string>();
            var statusText = CreateType<string>();
            var methodCreatePIPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfCreatePI = { sGuid, statusText };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCreatePI, methodCreatePIPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PortfolioItems, int>(_portfolioItemsInstanceFixture, out exception1, parametersOfCreatePI);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PortfolioItems, int>(_portfolioItemsInstance, MethodCreatePI, parametersOfCreatePI, methodCreatePIPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfCreatePI.ShouldNotBeNull();
            parametersOfCreatePI.Length.ShouldBe(2);
            methodCreatePIPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (CreatePI) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_CreatePI_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sGuid = CreateType<string>();
            var statusText = CreateType<string>();
            var methodCreatePIPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfCreatePI = { sGuid, statusText };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCreatePI, methodCreatePIPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PortfolioItems, int>(_portfolioItemsInstanceFixture, out exception1, parametersOfCreatePI);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PortfolioItems, int>(_portfolioItemsInstance, MethodCreatePI, parametersOfCreatePI, methodCreatePIPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfCreatePI.ShouldNotBeNull();
            parametersOfCreatePI.Length.ShouldBe(2);
            methodCreatePIPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (CreatePI) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_CreatePI_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sGuid = CreateType<string>();
            var statusText = CreateType<string>();
            var methodCreatePIPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfCreatePI = { sGuid, statusText };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<PortfolioItems, int>(_portfolioItemsInstance, MethodCreatePI, parametersOfCreatePI, methodCreatePIPrametersTypes);

            // Assert
            parametersOfCreatePI.ShouldNotBeNull();
            parametersOfCreatePI.Length.ShouldBe(2);
            methodCreatePIPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreatePI) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_CreatePI_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreatePIPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodCreatePI, Fixture, methodCreatePIPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreatePIPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreatePI) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_CreatePI_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreatePI, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioItemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreatePI) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_CreatePI_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreatePI, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPITitleValue) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioItems_GetPITitleValue_Method_Call_Internally(Type[] types)
        {
            var methodGetPITitleValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodGetPITitleValue, Fixture, methodGetPITitleValuePrametersTypes);
        }

        #endregion

        #region Method Call : (GetPITitleValue) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_GetPITitleValue_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var xPI = CreateType<CStruct>();
            var methodGetPITitleValuePrametersTypes = new Type[] { typeof(CStruct) };
            object[] parametersOfGetPITitleValue = { xPI };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetPITitleValue, methodGetPITitleValuePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PortfolioItems, string>(_portfolioItemsInstanceFixture, out exception1, parametersOfGetPITitleValue);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PortfolioItems, string>(_portfolioItemsInstance, MethodGetPITitleValue, parametersOfGetPITitleValue, methodGetPITitleValuePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetPITitleValue.ShouldNotBeNull();
            parametersOfGetPITitleValue.Length.ShouldBe(1);
            methodGetPITitleValuePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetPITitleValue) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_GetPITitleValue_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xPI = CreateType<CStruct>();
            var methodGetPITitleValuePrametersTypes = new Type[] { typeof(CStruct) };
            object[] parametersOfGetPITitleValue = { xPI };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<PortfolioItems, string>(_portfolioItemsInstance, MethodGetPITitleValue, parametersOfGetPITitleValue, methodGetPITitleValuePrametersTypes);

            // Assert
            parametersOfGetPITitleValue.ShouldNotBeNull();
            parametersOfGetPITitleValue.Length.ShouldBe(1);
            methodGetPITitleValuePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPITitleValue) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_GetPITitleValue_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetPITitleValuePrametersTypes = new Type[] { typeof(CStruct) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodGetPITitleValue, Fixture, methodGetPITitleValuePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetPITitleValuePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetPITitleValue) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_GetPITitleValue_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetPITitleValuePrametersTypes = new Type[] { typeof(CStruct) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodGetPITitleValue, Fixture, methodGetPITitleValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetPITitleValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPITitleValue) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_GetPITitleValue_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetPITitleValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioItemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetPITitleValue) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_GetPITitleValue_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetPITitleValue, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (StripNum) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioItems_StripNum_Method_Call_Internally(Type[] types)
        {
            var methodStripNumPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodStripNum, Fixture, methodStripNumPrametersTypes);
        }

        #endregion

        #region Method Call : (StripNum) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_StripNum_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sin = CreateType<string>();
            var methodStripNumPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfStripNum = { sin };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodStripNum, methodStripNumPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PortfolioItems, int>(_portfolioItemsInstanceFixture, out exception1, parametersOfStripNum);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PortfolioItems, int>(_portfolioItemsInstance, MethodStripNum, parametersOfStripNum, methodStripNumPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfStripNum.ShouldNotBeNull();
            parametersOfStripNum.Length.ShouldBe(1);
            methodStripNumPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (StripNum) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_StripNum_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sin = CreateType<string>();
            var methodStripNumPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfStripNum = { sin };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodStripNum, methodStripNumPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PortfolioItems, int>(_portfolioItemsInstanceFixture, out exception1, parametersOfStripNum);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PortfolioItems, int>(_portfolioItemsInstance, MethodStripNum, parametersOfStripNum, methodStripNumPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfStripNum.ShouldNotBeNull();
            parametersOfStripNum.Length.ShouldBe(1);
            methodStripNumPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (StripNum) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_StripNum_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sin = CreateType<string>();
            var methodStripNumPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfStripNum = { sin };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<PortfolioItems, int>(_portfolioItemsInstance, MethodStripNum, parametersOfStripNum, methodStripNumPrametersTypes);

            // Assert
            parametersOfStripNum.ShouldNotBeNull();
            parametersOfStripNum.Length.ShouldBe(1);
            methodStripNumPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StripNum) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_StripNum_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodStripNumPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodStripNum, Fixture, methodStripNumPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodStripNumPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (StripNum) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_StripNum_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodStripNum, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioItemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (StripNum) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_StripNum_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodStripNum, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdatePI) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioItems_UpdatePI_Method_Call_Internally(Type[] types)
        {
            var methodUpdatePIPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodUpdatePI, Fixture, methodUpdatePIPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdatePI) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_UpdatePI_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdatePI, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioItemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdatePI) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_UpdatePI_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdatePI, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PerformCustomFieldsCalculate) (Return Type : StatusEnum) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioItems_PerformCustomFieldsCalculate_Method_Call_Internally(Type[] types)
        {
            var methodPerformCustomFieldsCalculatePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodPerformCustomFieldsCalculate, Fixture, methodPerformCustomFieldsCalculatePrametersTypes);
        }

        #endregion

        #region Method Call : (PerformCustomFieldsCalculate) (Return Type : StatusEnum) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_PerformCustomFieldsCalculate_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var iPID = CreateType<int>();
            var methodPerformCustomFieldsCalculatePrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfPerformCustomFieldsCalculate = { iPID };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodPerformCustomFieldsCalculate, methodPerformCustomFieldsCalculatePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PortfolioItems, StatusEnum>(_portfolioItemsInstanceFixture, out exception1, parametersOfPerformCustomFieldsCalculate);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PortfolioItems, StatusEnum>(_portfolioItemsInstance, MethodPerformCustomFieldsCalculate, parametersOfPerformCustomFieldsCalculate, methodPerformCustomFieldsCalculatePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfPerformCustomFieldsCalculate.ShouldNotBeNull();
            parametersOfPerformCustomFieldsCalculate.Length.ShouldBe(1);
            methodPerformCustomFieldsCalculatePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (PerformCustomFieldsCalculate) (Return Type : StatusEnum) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_PerformCustomFieldsCalculate_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var iPID = CreateType<int>();
            var methodPerformCustomFieldsCalculatePrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfPerformCustomFieldsCalculate = { iPID };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<PortfolioItems, StatusEnum>(_portfolioItemsInstance, MethodPerformCustomFieldsCalculate, parametersOfPerformCustomFieldsCalculate, methodPerformCustomFieldsCalculatePrametersTypes);

            // Assert
            parametersOfPerformCustomFieldsCalculate.ShouldNotBeNull();
            parametersOfPerformCustomFieldsCalculate.Length.ShouldBe(1);
            methodPerformCustomFieldsCalculatePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PerformCustomFieldsCalculate) (Return Type : StatusEnum) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_PerformCustomFieldsCalculate_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodPerformCustomFieldsCalculatePrametersTypes = new Type[] { typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodPerformCustomFieldsCalculate, Fixture, methodPerformCustomFieldsCalculatePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodPerformCustomFieldsCalculatePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (PerformCustomFieldsCalculate) (Return Type : StatusEnum) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_PerformCustomFieldsCalculate_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPerformCustomFieldsCalculatePrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodPerformCustomFieldsCalculate, Fixture, methodPerformCustomFieldsCalculatePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodPerformCustomFieldsCalculatePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PerformCustomFieldsCalculate) (Return Type : StatusEnum) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_PerformCustomFieldsCalculate_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPerformCustomFieldsCalculate, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioItemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PerformCustomFieldsCalculate) (Return Type : StatusEnum) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_PerformCustomFieldsCalculate_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPerformCustomFieldsCalculate, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCustFieldVal) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioItems_GetCustFieldVal_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetCustFieldValPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioItemsInstanceFixture, _portfolioItemsInstanceType, MethodGetCustFieldVal, Fixture, methodGetCustFieldValPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCustFieldVal) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_GetCustFieldVal_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var lfit = CreateType<int>();
            var lfat = CreateType<int>();
            var methodGetCustFieldValPrametersTypes = new Type[] { typeof(int), typeof(int) };
            object[] parametersOfGetCustFieldVal = { lfit, lfat };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetCustFieldVal, methodGetCustFieldValPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_portfolioItemsInstanceFixture, parametersOfGetCustFieldVal);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetCustFieldVal.ShouldNotBeNull();
            parametersOfGetCustFieldVal.Length.ShouldBe(2);
            methodGetCustFieldValPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCustFieldVal) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_GetCustFieldVal_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var lfit = CreateType<int>();
            var lfat = CreateType<int>();
            var methodGetCustFieldValPrametersTypes = new Type[] { typeof(int), typeof(int) };
            object[] parametersOfGetCustFieldVal = { lfit, lfat };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioItemsInstanceFixture, _portfolioItemsInstanceType, MethodGetCustFieldVal, parametersOfGetCustFieldVal, methodGetCustFieldValPrametersTypes);

            // Assert
            parametersOfGetCustFieldVal.ShouldNotBeNull();
            parametersOfGetCustFieldVal.Length.ShouldBe(2);
            methodGetCustFieldValPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCustFieldVal) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_GetCustFieldVal_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCustFieldValPrametersTypes = new Type[] { typeof(int), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioItemsInstanceFixture, _portfolioItemsInstanceType, MethodGetCustFieldVal, Fixture, methodGetCustFieldValPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCustFieldValPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetCustFieldVal) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_GetCustFieldVal_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCustFieldValPrametersTypes = new Type[] { typeof(int), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioItemsInstanceFixture, _portfolioItemsInstanceType, MethodGetCustFieldVal, Fixture, methodGetCustFieldValPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCustFieldValPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCustFieldVal) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_GetCustFieldVal_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCustFieldVal, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioItemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetCustFieldVal) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_GetCustFieldVal_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCustFieldVal, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FormatAs000) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioItems_FormatAs000_Method_Call_Internally(Type[] types)
        {
            var methodFormatAs000PrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodFormatAs000, Fixture, methodFormatAs000PrametersTypes);
        }

        #endregion

        #region Method Call : (FormatAs000) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_FormatAs000_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var inval = CreateType<int>();
            var methodFormatAs000PrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfFormatAs000 = { inval };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodFormatAs000, methodFormatAs000PrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PortfolioItems, string>(_portfolioItemsInstanceFixture, out exception1, parametersOfFormatAs000);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PortfolioItems, string>(_portfolioItemsInstance, MethodFormatAs000, parametersOfFormatAs000, methodFormatAs000PrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfFormatAs000.ShouldNotBeNull();
            parametersOfFormatAs000.Length.ShouldBe(1);
            methodFormatAs000PrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (FormatAs000) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_FormatAs000_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var inval = CreateType<int>();
            var methodFormatAs000PrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfFormatAs000 = { inval };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<PortfolioItems, string>(_portfolioItemsInstance, MethodFormatAs000, parametersOfFormatAs000, methodFormatAs000PrametersTypes);

            // Assert
            parametersOfFormatAs000.ShouldNotBeNull();
            parametersOfFormatAs000.Length.ShouldBe(1);
            methodFormatAs000PrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FormatAs000) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_FormatAs000_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodFormatAs000PrametersTypes = new Type[] { typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodFormatAs000, Fixture, methodFormatAs000PrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodFormatAs000PrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (FormatAs000) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_FormatAs000_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFormatAs000PrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodFormatAs000, Fixture, methodFormatAs000PrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodFormatAs000PrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FormatAs000) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_FormatAs000_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFormatAs000, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioItemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (FormatAs000) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_FormatAs000_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodFormatAs000, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InsertDateString) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioItems_InsertDateString_Method_Call_Internally(Type[] types)
        {
            var methodInsertDateStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodInsertDateString, Fixture, methodInsertDateStringPrametersTypes);
        }

        #endregion

        #region Method Call : (InsertDateString) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_InsertDateString_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sIn = CreateType<string>();
            var methodInsertDateStringPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfInsertDateString = { sIn };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodInsertDateString, methodInsertDateStringPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PortfolioItems, string>(_portfolioItemsInstanceFixture, out exception1, parametersOfInsertDateString);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PortfolioItems, string>(_portfolioItemsInstance, MethodInsertDateString, parametersOfInsertDateString, methodInsertDateStringPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfInsertDateString.ShouldNotBeNull();
            parametersOfInsertDateString.Length.ShouldBe(1);
            methodInsertDateStringPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (InsertDateString) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_InsertDateString_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sIn = CreateType<string>();
            var methodInsertDateStringPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfInsertDateString = { sIn };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<PortfolioItems, string>(_portfolioItemsInstance, MethodInsertDateString, parametersOfInsertDateString, methodInsertDateStringPrametersTypes);

            // Assert
            parametersOfInsertDateString.ShouldNotBeNull();
            parametersOfInsertDateString.Length.ShouldBe(1);
            methodInsertDateStringPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InsertDateString) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_InsertDateString_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodInsertDateStringPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodInsertDateString, Fixture, methodInsertDateStringPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodInsertDateStringPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (InsertDateString) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_InsertDateString_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInsertDateStringPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodInsertDateString, Fixture, methodInsertDateStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodInsertDateStringPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InsertDateString) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_InsertDateString_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInsertDateString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioItemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (InsertDateString) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_InsertDateString_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodInsertDateString, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ResolveResName) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioItems_ResolveResName_Method_Call_Internally(Type[] types)
        {
            var methodResolveResNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodResolveResName, Fixture, methodResolveResNamePrametersTypes);
        }

        #endregion

        #region Method Call : (ResolveResName) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_ResolveResName_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var resName = CreateType<string>();
            var missingnames = CreateType<string>();
            var methodResolveResNamePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfResolveResName = { resName, missingnames };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodResolveResName, methodResolveResNamePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PortfolioItems, int>(_portfolioItemsInstanceFixture, out exception1, parametersOfResolveResName);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PortfolioItems, int>(_portfolioItemsInstance, MethodResolveResName, parametersOfResolveResName, methodResolveResNamePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfResolveResName.ShouldNotBeNull();
            parametersOfResolveResName.Length.ShouldBe(2);
            methodResolveResNamePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ResolveResName) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_ResolveResName_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var resName = CreateType<string>();
            var missingnames = CreateType<string>();
            var methodResolveResNamePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfResolveResName = { resName, missingnames };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodResolveResName, methodResolveResNamePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PortfolioItems, int>(_portfolioItemsInstanceFixture, out exception1, parametersOfResolveResName);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PortfolioItems, int>(_portfolioItemsInstance, MethodResolveResName, parametersOfResolveResName, methodResolveResNamePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfResolveResName.ShouldNotBeNull();
            parametersOfResolveResName.Length.ShouldBe(2);
            methodResolveResNamePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ResolveResName) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_ResolveResName_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var resName = CreateType<string>();
            var missingnames = CreateType<string>();
            var methodResolveResNamePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfResolveResName = { resName, missingnames };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<PortfolioItems, int>(_portfolioItemsInstance, MethodResolveResName, parametersOfResolveResName, methodResolveResNamePrametersTypes);

            // Assert
            parametersOfResolveResName.ShouldNotBeNull();
            parametersOfResolveResName.Length.ShouldBe(2);
            methodResolveResNamePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ResolveResName) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_ResolveResName_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodResolveResNamePrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodResolveResName, Fixture, methodResolveResNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodResolveResNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ResolveResName) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_ResolveResName_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodResolveResName, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioItemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ResolveResName) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_ResolveResName_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodResolveResName, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ResolveNameAndDelegates) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioItems_ResolveNameAndDelegates_Method_Call_Internally(Type[] types)
        {
            var methodResolveNameAndDelegatesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodResolveNameAndDelegates, Fixture, methodResolveNameAndDelegatesPrametersTypes);
        }

        #endregion

        #region Method Call : (ResolveNameAndDelegates) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_ResolveNameAndDelegates_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var resName = CreateType<string>();
            var missingnames = CreateType<string>();
            var iPI = CreateType<int>();
            var surrContext = CreateType<int>();
            var bDoDelegateWrite = CreateType<bool>();
            var methodResolveNameAndDelegatesPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(int), typeof(int), typeof(bool) };
            object[] parametersOfResolveNameAndDelegates = { resName, missingnames, iPI, surrContext, bDoDelegateWrite };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodResolveNameAndDelegates, methodResolveNameAndDelegatesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PortfolioItems, int>(_portfolioItemsInstanceFixture, out exception1, parametersOfResolveNameAndDelegates);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PortfolioItems, int>(_portfolioItemsInstance, MethodResolveNameAndDelegates, parametersOfResolveNameAndDelegates, methodResolveNameAndDelegatesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfResolveNameAndDelegates.ShouldNotBeNull();
            parametersOfResolveNameAndDelegates.Length.ShouldBe(5);
            methodResolveNameAndDelegatesPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (ResolveNameAndDelegates) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_ResolveNameAndDelegates_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var resName = CreateType<string>();
            var missingnames = CreateType<string>();
            var iPI = CreateType<int>();
            var surrContext = CreateType<int>();
            var bDoDelegateWrite = CreateType<bool>();
            var methodResolveNameAndDelegatesPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(int), typeof(int), typeof(bool) };
            object[] parametersOfResolveNameAndDelegates = { resName, missingnames, iPI, surrContext, bDoDelegateWrite };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodResolveNameAndDelegates, methodResolveNameAndDelegatesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PortfolioItems, int>(_portfolioItemsInstanceFixture, out exception1, parametersOfResolveNameAndDelegates);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PortfolioItems, int>(_portfolioItemsInstance, MethodResolveNameAndDelegates, parametersOfResolveNameAndDelegates, methodResolveNameAndDelegatesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfResolveNameAndDelegates.ShouldNotBeNull();
            parametersOfResolveNameAndDelegates.Length.ShouldBe(5);
            methodResolveNameAndDelegatesPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (ResolveNameAndDelegates) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_ResolveNameAndDelegates_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var resName = CreateType<string>();
            var missingnames = CreateType<string>();
            var iPI = CreateType<int>();
            var surrContext = CreateType<int>();
            var bDoDelegateWrite = CreateType<bool>();
            var methodResolveNameAndDelegatesPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(int), typeof(int), typeof(bool) };
            object[] parametersOfResolveNameAndDelegates = { resName, missingnames, iPI, surrContext, bDoDelegateWrite };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<PortfolioItems, int>(_portfolioItemsInstance, MethodResolveNameAndDelegates, parametersOfResolveNameAndDelegates, methodResolveNameAndDelegatesPrametersTypes);

            // Assert
            parametersOfResolveNameAndDelegates.ShouldNotBeNull();
            parametersOfResolveNameAndDelegates.Length.ShouldBe(5);
            methodResolveNameAndDelegatesPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ResolveNameAndDelegates) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_ResolveNameAndDelegates_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodResolveNameAndDelegatesPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(int), typeof(int), typeof(bool) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodResolveNameAndDelegates, Fixture, methodResolveNameAndDelegatesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodResolveNameAndDelegatesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ResolveNameAndDelegates) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_ResolveNameAndDelegates_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodResolveNameAndDelegates, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioItemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ResolveNameAndDelegates) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_ResolveNameAndDelegates_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodResolveNameAndDelegates, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DoFlagStuff) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioItems_DoFlagStuff_Method_Call_Internally(Type[] types)
        {
            var methodDoFlagStuffPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodDoFlagStuff, Fixture, methodDoFlagStuffPrametersTypes);
        }

        #endregion

        #region Method Call : (DoFlagStuff) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_DoFlagStuff_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sFlag = CreateType<string>();
            var methodDoFlagStuffPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDoFlagStuff = { sFlag };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDoFlagStuff, methodDoFlagStuffPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PortfolioItems, int>(_portfolioItemsInstanceFixture, out exception1, parametersOfDoFlagStuff);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PortfolioItems, int>(_portfolioItemsInstance, MethodDoFlagStuff, parametersOfDoFlagStuff, methodDoFlagStuffPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDoFlagStuff.ShouldNotBeNull();
            parametersOfDoFlagStuff.Length.ShouldBe(1);
            methodDoFlagStuffPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DoFlagStuff) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_DoFlagStuff_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sFlag = CreateType<string>();
            var methodDoFlagStuffPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDoFlagStuff = { sFlag };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDoFlagStuff, methodDoFlagStuffPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PortfolioItems, int>(_portfolioItemsInstanceFixture, out exception1, parametersOfDoFlagStuff);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PortfolioItems, int>(_portfolioItemsInstance, MethodDoFlagStuff, parametersOfDoFlagStuff, methodDoFlagStuffPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDoFlagStuff.ShouldNotBeNull();
            parametersOfDoFlagStuff.Length.ShouldBe(1);
            methodDoFlagStuffPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DoFlagStuff) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_DoFlagStuff_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sFlag = CreateType<string>();
            var methodDoFlagStuffPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDoFlagStuff = { sFlag };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<PortfolioItems, int>(_portfolioItemsInstance, MethodDoFlagStuff, parametersOfDoFlagStuff, methodDoFlagStuffPrametersTypes);

            // Assert
            parametersOfDoFlagStuff.ShouldNotBeNull();
            parametersOfDoFlagStuff.Length.ShouldBe(1);
            methodDoFlagStuffPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoFlagStuff) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_DoFlagStuff_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDoFlagStuffPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodDoFlagStuff, Fixture, methodDoFlagStuffPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDoFlagStuffPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DoFlagStuff) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_DoFlagStuff_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDoFlagStuff, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioItemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DoFlagStuff) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_DoFlagStuff_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDoFlagStuff, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DoIntStuff) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioItems_DoIntStuff_Method_Call_Internally(Type[] types)
        {
            var methodDoIntStuffPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodDoIntStuff, Fixture, methodDoIntStuffPrametersTypes);
        }

        #endregion

        #region Method Call : (DoIntStuff) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_DoIntStuff_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sNum = CreateType<string>();
            var methodDoIntStuffPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDoIntStuff = { sNum };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDoIntStuff, methodDoIntStuffPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PortfolioItems, int>(_portfolioItemsInstanceFixture, out exception1, parametersOfDoIntStuff);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PortfolioItems, int>(_portfolioItemsInstance, MethodDoIntStuff, parametersOfDoIntStuff, methodDoIntStuffPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDoIntStuff.ShouldNotBeNull();
            parametersOfDoIntStuff.Length.ShouldBe(1);
            methodDoIntStuffPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DoIntStuff) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_DoIntStuff_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sNum = CreateType<string>();
            var methodDoIntStuffPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDoIntStuff = { sNum };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDoIntStuff, methodDoIntStuffPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PortfolioItems, int>(_portfolioItemsInstanceFixture, out exception1, parametersOfDoIntStuff);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PortfolioItems, int>(_portfolioItemsInstance, MethodDoIntStuff, parametersOfDoIntStuff, methodDoIntStuffPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDoIntStuff.ShouldNotBeNull();
            parametersOfDoIntStuff.Length.ShouldBe(1);
            methodDoIntStuffPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DoIntStuff) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_DoIntStuff_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sNum = CreateType<string>();
            var methodDoIntStuffPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDoIntStuff = { sNum };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<PortfolioItems, int>(_portfolioItemsInstance, MethodDoIntStuff, parametersOfDoIntStuff, methodDoIntStuffPrametersTypes);

            // Assert
            parametersOfDoIntStuff.ShouldNotBeNull();
            parametersOfDoIntStuff.Length.ShouldBe(1);
            methodDoIntStuffPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoIntStuff) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_DoIntStuff_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDoIntStuffPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodDoIntStuff, Fixture, methodDoIntStuffPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDoIntStuffPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DoIntStuff) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_DoIntStuff_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDoIntStuff, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioItemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DoIntStuff) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_DoIntStuff_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDoIntStuff, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DoDoubleStuff) (Return Type : double) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioItems_DoDoubleStuff_Method_Call_Internally(Type[] types)
        {
            var methodDoDoubleStuffPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodDoDoubleStuff, Fixture, methodDoDoubleStuffPrametersTypes);
        }

        #endregion

        #region Method Call : (DoDoubleStuff) (Return Type : double) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_DoDoubleStuff_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sNum = CreateType<string>();
            var methodDoDoubleStuffPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDoDoubleStuff = { sNum };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDoDoubleStuff, methodDoDoubleStuffPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PortfolioItems, double>(_portfolioItemsInstanceFixture, out exception1, parametersOfDoDoubleStuff);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PortfolioItems, double>(_portfolioItemsInstance, MethodDoDoubleStuff, parametersOfDoDoubleStuff, methodDoDoubleStuffPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDoDoubleStuff.ShouldNotBeNull();
            parametersOfDoDoubleStuff.Length.ShouldBe(1);
            methodDoDoubleStuffPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DoDoubleStuff) (Return Type : double) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_DoDoubleStuff_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sNum = CreateType<string>();
            var methodDoDoubleStuffPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDoDoubleStuff = { sNum };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDoDoubleStuff, methodDoDoubleStuffPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PortfolioItems, double>(_portfolioItemsInstanceFixture, out exception1, parametersOfDoDoubleStuff);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PortfolioItems, double>(_portfolioItemsInstance, MethodDoDoubleStuff, parametersOfDoDoubleStuff, methodDoDoubleStuffPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDoDoubleStuff.ShouldNotBeNull();
            parametersOfDoDoubleStuff.Length.ShouldBe(1);
            methodDoDoubleStuffPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DoDoubleStuff) (Return Type : double) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_DoDoubleStuff_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sNum = CreateType<string>();
            var methodDoDoubleStuffPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDoDoubleStuff = { sNum };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<PortfolioItems, double>(_portfolioItemsInstance, MethodDoDoubleStuff, parametersOfDoDoubleStuff, methodDoDoubleStuffPrametersTypes);

            // Assert
            parametersOfDoDoubleStuff.ShouldNotBeNull();
            parametersOfDoDoubleStuff.Length.ShouldBe(1);
            methodDoDoubleStuffPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoDoubleStuff) (Return Type : double) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_DoDoubleStuff_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDoDoubleStuffPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodDoDoubleStuff, Fixture, methodDoDoubleStuffPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDoDoubleStuffPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DoDoubleStuff) (Return Type : double) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_DoDoubleStuff_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDoDoubleStuff, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioItemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DoDoubleStuff) (Return Type : double) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_DoDoubleStuff_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDoDoubleStuff, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteSQLSelect) (Return Type : StatusEnum) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioItems_ExecuteSQLSelect_Static_Method_Call_Internally(Type[] types)
        {
            var methodExecuteSQLSelectPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioItemsInstanceFixture, _portfolioItemsInstanceType, MethodExecuteSQLSelect, Fixture, methodExecuteSQLSelectPrametersTypes);
        }

        #endregion

        #region Method Call : (ExecuteSQLSelect) (Return Type : StatusEnum) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_ExecuteSQLSelect_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var oCommand = CreateType<SqlCommand>();
            var reader = CreateType<SqlDataReader>();
            var methodExecuteSQLSelectPrametersTypes = new Type[] { typeof(SqlCommand), typeof(SqlDataReader) };
            object[] parametersOfExecuteSQLSelect = { oCommand, reader };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodExecuteSQLSelect, methodExecuteSQLSelectPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_portfolioItemsInstanceFixture, parametersOfExecuteSQLSelect);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfExecuteSQLSelect.ShouldNotBeNull();
            parametersOfExecuteSQLSelect.Length.ShouldBe(2);
            methodExecuteSQLSelectPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteSQLSelect) (Return Type : StatusEnum) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_ExecuteSQLSelect_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oCommand = CreateType<SqlCommand>();
            var reader = CreateType<SqlDataReader>();
            var methodExecuteSQLSelectPrametersTypes = new Type[] { typeof(SqlCommand), typeof(SqlDataReader) };
            object[] parametersOfExecuteSQLSelect = { oCommand, reader };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<StatusEnum>(_portfolioItemsInstanceFixture, _portfolioItemsInstanceType, MethodExecuteSQLSelect, parametersOfExecuteSQLSelect, methodExecuteSQLSelectPrametersTypes);

            // Assert
            parametersOfExecuteSQLSelect.ShouldNotBeNull();
            parametersOfExecuteSQLSelect.Length.ShouldBe(2);
            methodExecuteSQLSelectPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteSQLSelect) (Return Type : StatusEnum) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_ExecuteSQLSelect_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodExecuteSQLSelectPrametersTypes = new Type[] { typeof(SqlCommand), typeof(SqlDataReader) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioItemsInstanceFixture, _portfolioItemsInstanceType, MethodExecuteSQLSelect, Fixture, methodExecuteSQLSelectPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodExecuteSQLSelectPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ExecuteSQLSelect) (Return Type : StatusEnum) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_ExecuteSQLSelect_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodExecuteSQLSelectPrametersTypes = new Type[] { typeof(SqlCommand), typeof(SqlDataReader) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioItemsInstanceFixture, _portfolioItemsInstanceType, MethodExecuteSQLSelect, Fixture, methodExecuteSQLSelectPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodExecuteSQLSelectPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteSQLSelect) (Return Type : StatusEnum) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_ExecuteSQLSelect_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodExecuteSQLSelect, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioItemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ExecuteSQLSelect) (Return Type : StatusEnum) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_ExecuteSQLSelect_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodExecuteSQLSelect, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExportPIInfo) (Return Type : StatusEnum) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioItems_ExportPIInfo_Method_Call_Internally(Type[] types)
        {
            var methodExportPIInfoPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodExportPIInfo, Fixture, methodExportPIInfoPrametersTypes);
        }

        #endregion

        #region Method Call : (ExportPIInfo) (Return Type : StatusEnum) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_ExportPIInfo_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var dba = CreateType<DBAccess>();
            var sProjectIDs = CreateType<string>();
            var xEPKUpdate = CreateType<CStruct>();
            var methodExportPIInfoPrametersTypes = new Type[] { typeof(DBAccess), typeof(string), typeof(CStruct) };
            object[] parametersOfExportPIInfo = { dba, sProjectIDs, xEPKUpdate };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodExportPIInfo, methodExportPIInfoPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PortfolioItems, StatusEnum>(_portfolioItemsInstanceFixture, out exception1, parametersOfExportPIInfo);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PortfolioItems, StatusEnum>(_portfolioItemsInstance, MethodExportPIInfo, parametersOfExportPIInfo, methodExportPIInfoPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfExportPIInfo.ShouldNotBeNull();
            parametersOfExportPIInfo.Length.ShouldBe(3);
            methodExportPIInfoPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (ExportPIInfo) (Return Type : StatusEnum) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_ExportPIInfo_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dba = CreateType<DBAccess>();
            var sProjectIDs = CreateType<string>();
            var xEPKUpdate = CreateType<CStruct>();
            var methodExportPIInfoPrametersTypes = new Type[] { typeof(DBAccess), typeof(string), typeof(CStruct) };
            object[] parametersOfExportPIInfo = { dba, sProjectIDs, xEPKUpdate };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<PortfolioItems, StatusEnum>(_portfolioItemsInstance, MethodExportPIInfo, parametersOfExportPIInfo, methodExportPIInfoPrametersTypes);

            // Assert
            parametersOfExportPIInfo.ShouldNotBeNull();
            parametersOfExportPIInfo.Length.ShouldBe(3);
            methodExportPIInfoPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExportPIInfo) (Return Type : StatusEnum) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_ExportPIInfo_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodExportPIInfoPrametersTypes = new Type[] { typeof(DBAccess), typeof(string), typeof(CStruct) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodExportPIInfo, Fixture, methodExportPIInfoPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodExportPIInfoPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (ExportPIInfo) (Return Type : StatusEnum) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_ExportPIInfo_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodExportPIInfoPrametersTypes = new Type[] { typeof(DBAccess), typeof(string), typeof(CStruct) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodExportPIInfo, Fixture, methodExportPIInfoPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodExportPIInfoPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExportPIInfo) (Return Type : StatusEnum) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_ExportPIInfo_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodExportPIInfo, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioItemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ExportPIInfo) (Return Type : StatusEnum) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_ExportPIInfo_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodExportPIInfo, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMVValue) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioItems_GetMVValue_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetMVValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioItemsInstanceFixture, _portfolioItemsInstanceType, MethodGetMVValue, Fixture, methodGetMVValuePrametersTypes);
        }

        #endregion

        #region Method Call : (GetMVValue) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_GetMVValue_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var clnMVs = CreateType<SortedList<int, SortedList<int, string>>>();
            var lFieldID = CreateType<int>();
            var lWresID = CreateType<int>();
            var methodGetMVValuePrametersTypes = new Type[] { typeof(SortedList<int, SortedList<int, string>>), typeof(int), typeof(int) };
            object[] parametersOfGetMVValue = { clnMVs, lFieldID, lWresID };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetMVValue, methodGetMVValuePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_portfolioItemsInstanceFixture, parametersOfGetMVValue);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetMVValue.ShouldNotBeNull();
            parametersOfGetMVValue.Length.ShouldBe(3);
            methodGetMVValuePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetMVValue) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_GetMVValue_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var clnMVs = CreateType<SortedList<int, SortedList<int, string>>>();
            var lFieldID = CreateType<int>();
            var lWresID = CreateType<int>();
            var methodGetMVValuePrametersTypes = new Type[] { typeof(SortedList<int, SortedList<int, string>>), typeof(int), typeof(int) };
            object[] parametersOfGetMVValue = { clnMVs, lFieldID, lWresID };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioItemsInstanceFixture, _portfolioItemsInstanceType, MethodGetMVValue, parametersOfGetMVValue, methodGetMVValuePrametersTypes);

            // Assert
            parametersOfGetMVValue.ShouldNotBeNull();
            parametersOfGetMVValue.Length.ShouldBe(3);
            methodGetMVValuePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetMVValue) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_GetMVValue_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetMVValuePrametersTypes = new Type[] { typeof(SortedList<int, SortedList<int, string>>), typeof(int), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioItemsInstanceFixture, _portfolioItemsInstanceType, MethodGetMVValue, Fixture, methodGetMVValuePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetMVValuePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetMVValue) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_GetMVValue_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetMVValuePrametersTypes = new Type[] { typeof(SortedList<int, SortedList<int, string>>), typeof(int), typeof(int) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioItemsInstanceFixture, _portfolioItemsInstanceType, MethodGetMVValue, Fixture, methodGetMVValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetMVValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMVValue) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_GetMVValue_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetMVValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioItemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetMVValue) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_GetMVValue_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetMVValue, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetLookupValue) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioItems_GetLookupValue_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetLookupValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioItemsInstanceFixture, _portfolioItemsInstanceType, MethodGetLookupValue, Fixture, methodGetLookupValuePrametersTypes);
        }

        #endregion

        #region Method Call : (GetLookupValue) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_GetLookupValue_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var clnLookupValues = CreateType<SortedList<int, string>>();
            var lID = CreateType<int>();
            var methodGetLookupValuePrametersTypes = new Type[] { typeof(SortedList<int, string>), typeof(int) };
            object[] parametersOfGetLookupValue = { clnLookupValues, lID };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetLookupValue, methodGetLookupValuePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_portfolioItemsInstanceFixture, parametersOfGetLookupValue);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetLookupValue.ShouldNotBeNull();
            parametersOfGetLookupValue.Length.ShouldBe(2);
            methodGetLookupValuePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetLookupValue) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_GetLookupValue_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var clnLookupValues = CreateType<SortedList<int, string>>();
            var lID = CreateType<int>();
            var methodGetLookupValuePrametersTypes = new Type[] { typeof(SortedList<int, string>), typeof(int) };
            object[] parametersOfGetLookupValue = { clnLookupValues, lID };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioItemsInstanceFixture, _portfolioItemsInstanceType, MethodGetLookupValue, parametersOfGetLookupValue, methodGetLookupValuePrametersTypes);

            // Assert
            parametersOfGetLookupValue.ShouldNotBeNull();
            parametersOfGetLookupValue.Length.ShouldBe(2);
            methodGetLookupValuePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetLookupValue) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_GetLookupValue_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetLookupValuePrametersTypes = new Type[] { typeof(SortedList<int, string>), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioItemsInstanceFixture, _portfolioItemsInstanceType, MethodGetLookupValue, Fixture, methodGetLookupValuePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetLookupValuePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetLookupValue) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_GetLookupValue_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetLookupValuePrametersTypes = new Type[] { typeof(SortedList<int, string>), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioItemsInstanceFixture, _portfolioItemsInstanceType, MethodGetLookupValue, Fixture, methodGetLookupValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetLookupValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetLookupValue) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_GetLookupValue_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetLookupValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioItemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetLookupValue) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_GetLookupValue_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetLookupValue, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateProjectDiscountRate) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioItems_UpdateProjectDiscountRate_Method_Call_Internally(Type[] types)
        {
            var methodUpdateProjectDiscountRatePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodUpdateProjectDiscountRate, Fixture, methodUpdateProjectDiscountRatePrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateProjectDiscountRate) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_UpdateProjectDiscountRate_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dba = CreateType<DBAccess>();
            var projectId = CreateType<int>();
            var discountRate = CreateType<string>();
            var discountRatePreviousValue = CreateType<string>();
            var methodUpdateProjectDiscountRatePrametersTypes = new Type[] { typeof(DBAccess), typeof(int), typeof(string), typeof(string) };
            object[] parametersOfUpdateProjectDiscountRate = { dba, projectId, discountRate, discountRatePreviousValue };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_portfolioItemsInstance, MethodUpdateProjectDiscountRate, parametersOfUpdateProjectDiscountRate, methodUpdateProjectDiscountRatePrametersTypes);

            // Assert
            parametersOfUpdateProjectDiscountRate.ShouldNotBeNull();
            parametersOfUpdateProjectDiscountRate.Length.ShouldBe(4);
            methodUpdateProjectDiscountRatePrametersTypes.Length.ShouldBe(4);
            methodUpdateProjectDiscountRatePrametersTypes.Length.ShouldBe(parametersOfUpdateProjectDiscountRate.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateProjectDiscountRate) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PortfolioItems_UpdateProjectDiscountRate_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateProjectDiscountRatePrametersTypes = new Type[] { typeof(DBAccess), typeof(int), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioItemsInstance, MethodUpdateProjectDiscountRate, Fixture, methodUpdateProjectDiscountRatePrametersTypes);

            // Assert
            methodUpdateProjectDiscountRatePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
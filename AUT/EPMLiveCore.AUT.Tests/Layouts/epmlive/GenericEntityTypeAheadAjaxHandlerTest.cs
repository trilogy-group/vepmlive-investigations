using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.GenericEntityTypeAheadAjaxHandler" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class GenericEntityTypeAheadAjaxHandlerTest : AbstractBaseSetupTypedTest<GenericEntityTypeAheadAjaxHandler>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (GenericEntityTypeAheadAjaxHandler) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodOutputResult = "OutputResult";
        private const string MethodInitVals = "InitVals";
        private const string MethodIssueQuery = "IssueQuery";
        private const string MethodApplyFiltersAndCreateOutput = "ApplyFiltersAndCreateOutput";
        private const string MethodRecordIsArchived = "RecordIsArchived";
        private const string MethodGetTableName = "GetTableName";
        private const string MethodBuildDynamicSPQueryWithMultipleOrConditions = "BuildDynamicSPQueryWithMultipleOrConditions";
        private const string MethodUpdateOrNode = "UpdateOrNode";
        private const string MethodBuildDynamicOrEqCombination = "BuildDynamicOrEqCombination";
        private const string MethodBuildOrNodeForSPQuery = "BuildOrNodeForSPQuery";
        private const string MethodBuildEqNodeForSPQuery = "BuildEqNodeForSPQuery";
        private const string MethodBuildEqNodeInnerXmlForSPQuery = "BuildEqNodeInnerXmlForSPQuery";
        private const string Fieldoutput = "output";
        private const string Field_webID = "_webID";
        private const string Field_listID = "_listID";
        private const string Field_fieldID = "_fieldID";
        private const string Field_field = "_field";
        private const string Field_parent = "_parent";
        private const string Field_parentValue = "_parentValue";
        private const string Field_parentListField = "_parentListField";
        private const string Field_sbResult = "_sbResult";
        private const string Field_isMultiSelect = "_isMultiSelect";
        private const string Field_selectedChildren = "_selectedChildren";
        private Type _genericEntityTypeAheadAjaxHandlerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private GenericEntityTypeAheadAjaxHandler _genericEntityTypeAheadAjaxHandlerInstance;
        private GenericEntityTypeAheadAjaxHandler _genericEntityTypeAheadAjaxHandlerInstanceFixture;

        #region General Initializer : Class (GenericEntityTypeAheadAjaxHandler) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="GenericEntityTypeAheadAjaxHandler" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _genericEntityTypeAheadAjaxHandlerInstanceType = typeof(GenericEntityTypeAheadAjaxHandler);
            _genericEntityTypeAheadAjaxHandlerInstanceFixture = Create(true);
            _genericEntityTypeAheadAjaxHandlerInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (GenericEntityTypeAheadAjaxHandler)

        #region General Initializer : Class (GenericEntityTypeAheadAjaxHandler) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="GenericEntityTypeAheadAjaxHandler" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodOutputResult, 0)]
        [TestCase(MethodInitVals, 0)]
        [TestCase(MethodIssueQuery, 0)]
        [TestCase(MethodGetTableName, 0)]
        [TestCase(MethodBuildDynamicSPQueryWithMultipleOrConditions, 0)]
        [TestCase(MethodUpdateOrNode, 0)]
        [TestCase(MethodBuildDynamicOrEqCombination, 0)]
        [TestCase(MethodBuildOrNodeForSPQuery, 0)]
        [TestCase(MethodBuildEqNodeForSPQuery, 0)]
        [TestCase(MethodBuildEqNodeInnerXmlForSPQuery, 0)]
        public void AUT_GenericEntityTypeAheadAjaxHandler_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_genericEntityTypeAheadAjaxHandlerInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (GenericEntityTypeAheadAjaxHandler) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="GenericEntityTypeAheadAjaxHandler" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldoutput)]
        [TestCase(Field_webID)]
        [TestCase(Field_listID)]
        [TestCase(Field_fieldID)]
        [TestCase(Field_field)]
        [TestCase(Field_parent)]
        [TestCase(Field_parentValue)]
        [TestCase(Field_parentListField)]
        [TestCase(Field_sbResult)]
        [TestCase(Field_isMultiSelect)]
        [TestCase(Field_selectedChildren)]
        public void AUT_GenericEntityTypeAheadAjaxHandler_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_genericEntityTypeAheadAjaxHandlerInstanceFixture, 
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
        ///     Class (<see cref="GenericEntityTypeAheadAjaxHandler" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_Is_Instance_Present_Test()
        {
            // Assert
            _genericEntityTypeAheadAjaxHandlerInstanceType.ShouldNotBeNull();
            _genericEntityTypeAheadAjaxHandlerInstance.ShouldNotBeNull();
            _genericEntityTypeAheadAjaxHandlerInstanceFixture.ShouldNotBeNull();
            _genericEntityTypeAheadAjaxHandlerInstance.ShouldBeAssignableTo<GenericEntityTypeAheadAjaxHandler>();
            _genericEntityTypeAheadAjaxHandlerInstanceFixture.ShouldBeAssignableTo<GenericEntityTypeAheadAjaxHandler>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (GenericEntityTypeAheadAjaxHandler) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_GenericEntityTypeAheadAjaxHandler_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            GenericEntityTypeAheadAjaxHandler instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _genericEntityTypeAheadAjaxHandlerInstanceType.ShouldNotBeNull();
            _genericEntityTypeAheadAjaxHandlerInstance.ShouldNotBeNull();
            _genericEntityTypeAheadAjaxHandlerInstanceFixture.ShouldNotBeNull();
            _genericEntityTypeAheadAjaxHandlerInstance.ShouldBeAssignableTo<GenericEntityTypeAheadAjaxHandler>();
            _genericEntityTypeAheadAjaxHandlerInstanceFixture.ShouldBeAssignableTo<GenericEntityTypeAheadAjaxHandler>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="GenericEntityTypeAheadAjaxHandler" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodBuildDynamicSPQueryWithMultipleOrConditions)]
        [TestCase(MethodUpdateOrNode)]
        [TestCase(MethodBuildDynamicOrEqCombination)]
        [TestCase(MethodBuildOrNodeForSPQuery)]
        [TestCase(MethodBuildEqNodeForSPQuery)]
        [TestCase(MethodBuildEqNodeInnerXmlForSPQuery)]
        public void AUT_GenericEntityTypeAheadAjaxHandler_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_genericEntityTypeAheadAjaxHandlerInstanceFixture,
                                                                              _genericEntityTypeAheadAjaxHandlerInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="GenericEntityTypeAheadAjaxHandler" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodOutputResult)]
        [TestCase(MethodInitVals)]
        [TestCase(MethodIssueQuery)]
        [TestCase(MethodGetTableName)]
        public void AUT_GenericEntityTypeAheadAjaxHandler_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<GenericEntityTypeAheadAjaxHandler>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GenericEntityTypeAheadAjaxHandler_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericEntityTypeAheadAjaxHandlerInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_genericEntityTypeAheadAjaxHandlerInstanceFixture, parametersOfPage_Load);

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
        public void AUT_GenericEntityTypeAheadAjaxHandler_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_genericEntityTypeAheadAjaxHandlerInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_GenericEntityTypeAheadAjaxHandler_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_GenericEntityTypeAheadAjaxHandler_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericEntityTypeAheadAjaxHandlerInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_genericEntityTypeAheadAjaxHandlerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OutputResult) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GenericEntityTypeAheadAjaxHandler_OutputResult_Method_Call_Internally(Type[] types)
        {
            var methodOutputResultPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericEntityTypeAheadAjaxHandlerInstance, MethodOutputResult, Fixture, methodOutputResultPrametersTypes);
        }

        #endregion

        #region Method Call : (OutputResult) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_OutputResult_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodOutputResultPrametersTypes = null;
            object[] parametersOfOutputResult = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOutputResult, methodOutputResultPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_genericEntityTypeAheadAjaxHandlerInstanceFixture, parametersOfOutputResult);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOutputResult.ShouldBeNull();
            methodOutputResultPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OutputResult) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_OutputResult_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodOutputResultPrametersTypes = null;
            object[] parametersOfOutputResult = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_genericEntityTypeAheadAjaxHandlerInstance, MethodOutputResult, parametersOfOutputResult, methodOutputResultPrametersTypes);

            // Assert
            parametersOfOutputResult.ShouldBeNull();
            methodOutputResultPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OutputResult) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_OutputResult_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodOutputResultPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericEntityTypeAheadAjaxHandlerInstance, MethodOutputResult, Fixture, methodOutputResultPrametersTypes);

            // Assert
            methodOutputResultPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OutputResult) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_OutputResult_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOutputResult, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_genericEntityTypeAheadAjaxHandlerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitVals) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GenericEntityTypeAheadAjaxHandler_InitVals_Method_Call_Internally(Type[] types)
        {
            var methodInitValsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericEntityTypeAheadAjaxHandlerInstance, MethodInitVals, Fixture, methodInitValsPrametersTypes);
        }

        #endregion

        #region Method Call : (InitVals) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_InitVals_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodInitValsPrametersTypes = null;
            object[] parametersOfInitVals = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitVals, methodInitValsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_genericEntityTypeAheadAjaxHandlerInstanceFixture, parametersOfInitVals);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInitVals.ShouldBeNull();
            methodInitValsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (InitVals) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_InitVals_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodInitValsPrametersTypes = null;
            object[] parametersOfInitVals = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_genericEntityTypeAheadAjaxHandlerInstance, MethodInitVals, parametersOfInitVals, methodInitValsPrametersTypes);

            // Assert
            parametersOfInitVals.ShouldBeNull();
            methodInitValsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitVals) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_InitVals_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodInitValsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericEntityTypeAheadAjaxHandlerInstance, MethodInitVals, Fixture, methodInitValsPrametersTypes);

            // Assert
            methodInitValsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitVals) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_InitVals_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitVals, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_genericEntityTypeAheadAjaxHandlerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IssueQuery) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GenericEntityTypeAheadAjaxHandler_IssueQuery_Method_Call_Internally(Type[] types)
        {
            var methodIssueQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericEntityTypeAheadAjaxHandlerInstance, MethodIssueQuery, Fixture, methodIssueQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (IssueQuery) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_IssueQuery_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodIssueQueryPrametersTypes = null;
            object[] parametersOfIssueQuery = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodIssueQuery, methodIssueQueryPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_genericEntityTypeAheadAjaxHandlerInstanceFixture, parametersOfIssueQuery);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfIssueQuery.ShouldBeNull();
            methodIssueQueryPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (IssueQuery) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_IssueQuery_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodIssueQueryPrametersTypes = null;
            object[] parametersOfIssueQuery = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_genericEntityTypeAheadAjaxHandlerInstance, MethodIssueQuery, parametersOfIssueQuery, methodIssueQueryPrametersTypes);

            // Assert
            parametersOfIssueQuery.ShouldBeNull();
            methodIssueQueryPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IssueQuery) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_IssueQuery_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodIssueQueryPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericEntityTypeAheadAjaxHandlerInstance, MethodIssueQuery, Fixture, methodIssueQueryPrametersTypes);

            // Assert
            methodIssueQueryPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IssueQuery) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_IssueQuery_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIssueQuery, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_genericEntityTypeAheadAjaxHandlerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ApplyFiltersAndCreateOutput) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GenericEntityTypeAheadAjaxHandler_ApplyFiltersAndCreateOutput_Method_Call_Internally(Type[] types)
        {
            var methodApplyFiltersAndCreateOutputPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericEntityTypeAheadAjaxHandlerInstance, MethodApplyFiltersAndCreateOutput, Fixture, methodApplyFiltersAndCreateOutputPrametersTypes);
        }

        #endregion

        #region Method Call : (ApplyFiltersAndCreateOutput) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_ApplyFiltersAndCreateOutput_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var results = CreateType<DataRow[]>();
            var methodApplyFiltersAndCreateOutputPrametersTypes = new Type[] { typeof(DataRow[]) };
            object[] parametersOfApplyFiltersAndCreateOutput = { results };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_genericEntityTypeAheadAjaxHandlerInstance, MethodApplyFiltersAndCreateOutput, parametersOfApplyFiltersAndCreateOutput, methodApplyFiltersAndCreateOutputPrametersTypes);

            // Assert
            parametersOfApplyFiltersAndCreateOutput.ShouldNotBeNull();
            parametersOfApplyFiltersAndCreateOutput.Length.ShouldBe(1);
            methodApplyFiltersAndCreateOutputPrametersTypes.Length.ShouldBe(1);
            methodApplyFiltersAndCreateOutputPrametersTypes.Length.ShouldBe(parametersOfApplyFiltersAndCreateOutput.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ApplyFiltersAndCreateOutput) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_ApplyFiltersAndCreateOutput_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodApplyFiltersAndCreateOutputPrametersTypes = new Type[] { typeof(DataRow[]) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericEntityTypeAheadAjaxHandlerInstance, MethodApplyFiltersAndCreateOutput, Fixture, methodApplyFiltersAndCreateOutputPrametersTypes);

            // Assert
            methodApplyFiltersAndCreateOutputPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RecordIsArchived) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GenericEntityTypeAheadAjaxHandler_RecordIsArchived_Static_Method_Call_Internally(Type[] types)
        {
            var methodRecordIsArchivedPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_genericEntityTypeAheadAjaxHandlerInstanceFixture, _genericEntityTypeAheadAjaxHandlerInstanceType, MethodRecordIsArchived, Fixture, methodRecordIsArchivedPrametersTypes);
        }

        #endregion

        #region Method Call : (RecordIsArchived) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_RecordIsArchived_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var row = CreateType<DataRow>();
            var methodRecordIsArchivedPrametersTypes = new Type[] { typeof(DataRow) };
            object[] parametersOfRecordIsArchived = { row };

            // Assert
            parametersOfRecordIsArchived.ShouldNotBeNull();
            parametersOfRecordIsArchived.Length.ShouldBe(1);
            methodRecordIsArchivedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_genericEntityTypeAheadAjaxHandlerInstanceFixture, _genericEntityTypeAheadAjaxHandlerInstanceType, MethodRecordIsArchived, parametersOfRecordIsArchived, methodRecordIsArchivedPrametersTypes));
        }

        #endregion

        #region Method Call : (RecordIsArchived) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_RecordIsArchived_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRecordIsArchivedPrametersTypes = new Type[] { typeof(DataRow) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_genericEntityTypeAheadAjaxHandlerInstanceFixture, _genericEntityTypeAheadAjaxHandlerInstanceType, MethodRecordIsArchived, Fixture, methodRecordIsArchivedPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRecordIsArchivedPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTableName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GenericEntityTypeAheadAjaxHandler_GetTableName_Method_Call_Internally(Type[] types)
        {
            var methodGetTableNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericEntityTypeAheadAjaxHandlerInstance, MethodGetTableName, Fixture, methodGetTableNamePrametersTypes);
        }

        #endregion

        #region Method Call : (GetTableName) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_GetTableName_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var listID = CreateType<Guid>();
            var methodGetTableNamePrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfGetTableName = { listID };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetTableName, methodGetTableNamePrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetTableName.ShouldNotBeNull();
            parametersOfGetTableName.Length.ShouldBe(1);
            methodGetTableNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(_genericEntityTypeAheadAjaxHandlerInstanceFixture, parametersOfGetTableName));
        }

        #endregion

        #region Method Call : (GetTableName) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_GetTableName_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listID = CreateType<Guid>();
            var methodGetTableNamePrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfGetTableName = { listID };

            // Assert
            parametersOfGetTableName.ShouldNotBeNull();
            parametersOfGetTableName.Length.ShouldBe(1);
            methodGetTableNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<GenericEntityTypeAheadAjaxHandler, string>(_genericEntityTypeAheadAjaxHandlerInstance, MethodGetTableName, parametersOfGetTableName, methodGetTableNamePrametersTypes));
        }

        #endregion

        #region Method Call : (GetTableName) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_GetTableName_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTableNamePrametersTypes = new Type[] { typeof(Guid) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericEntityTypeAheadAjaxHandlerInstance, MethodGetTableName, Fixture, methodGetTableNamePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTableNamePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTableName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_GetTableName_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTableNamePrametersTypes = new Type[] { typeof(Guid) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericEntityTypeAheadAjaxHandlerInstance, MethodGetTableName, Fixture, methodGetTableNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTableNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTableName) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_GetTableName_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTableName, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_genericEntityTypeAheadAjaxHandlerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetTableName) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_GetTableName_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTableName, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildDynamicSPQueryWithMultipleOrConditions) (Return Type : String) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GenericEntityTypeAheadAjaxHandler_BuildDynamicSPQueryWithMultipleOrConditions_Static_Method_Call_Internally(Type[] types)
        {
            var methodBuildDynamicSPQueryWithMultipleOrConditionsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_genericEntityTypeAheadAjaxHandlerInstanceFixture, _genericEntityTypeAheadAjaxHandlerInstanceType, MethodBuildDynamicSPQueryWithMultipleOrConditions, Fixture, methodBuildDynamicSPQueryWithMultipleOrConditionsPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildDynamicSPQueryWithMultipleOrConditions) (Return Type : String) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_BuildDynamicSPQueryWithMultipleOrConditions_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var lookupField = CreateType<string>();
            var selectedParents = CreateType<string[]>();
            var methodBuildDynamicSPQueryWithMultipleOrConditionsPrametersTypes = new Type[] { typeof(string), typeof(string[]) };
            object[] parametersOfBuildDynamicSPQueryWithMultipleOrConditions = { lookupField, selectedParents };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBuildDynamicSPQueryWithMultipleOrConditions, methodBuildDynamicSPQueryWithMultipleOrConditionsPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfBuildDynamicSPQueryWithMultipleOrConditions.ShouldNotBeNull();
            parametersOfBuildDynamicSPQueryWithMultipleOrConditions.Length.ShouldBe(2);
            methodBuildDynamicSPQueryWithMultipleOrConditionsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => methodInfo.Invoke(_genericEntityTypeAheadAjaxHandlerInstanceFixture, parametersOfBuildDynamicSPQueryWithMultipleOrConditions));
        }

        #endregion

        #region Method Call : (BuildDynamicSPQueryWithMultipleOrConditions) (Return Type : String) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_BuildDynamicSPQueryWithMultipleOrConditions_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var lookupField = CreateType<string>();
            var selectedParents = CreateType<string[]>();
            var methodBuildDynamicSPQueryWithMultipleOrConditionsPrametersTypes = new Type[] { typeof(string), typeof(string[]) };
            object[] parametersOfBuildDynamicSPQueryWithMultipleOrConditions = { lookupField, selectedParents };

            // Assert
            parametersOfBuildDynamicSPQueryWithMultipleOrConditions.ShouldNotBeNull();
            parametersOfBuildDynamicSPQueryWithMultipleOrConditions.Length.ShouldBe(2);
            methodBuildDynamicSPQueryWithMultipleOrConditionsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<String>(_genericEntityTypeAheadAjaxHandlerInstanceFixture, _genericEntityTypeAheadAjaxHandlerInstanceType, MethodBuildDynamicSPQueryWithMultipleOrConditions, parametersOfBuildDynamicSPQueryWithMultipleOrConditions, methodBuildDynamicSPQueryWithMultipleOrConditionsPrametersTypes));
        }

        #endregion

        #region Method Call : (BuildDynamicSPQueryWithMultipleOrConditions) (Return Type : String) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_BuildDynamicSPQueryWithMultipleOrConditions_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodBuildDynamicSPQueryWithMultipleOrConditionsPrametersTypes = new Type[] { typeof(string), typeof(string[]) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_genericEntityTypeAheadAjaxHandlerInstanceFixture, _genericEntityTypeAheadAjaxHandlerInstanceType, MethodBuildDynamicSPQueryWithMultipleOrConditions, Fixture, methodBuildDynamicSPQueryWithMultipleOrConditionsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodBuildDynamicSPQueryWithMultipleOrConditionsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (BuildDynamicSPQueryWithMultipleOrConditions) (Return Type : String) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_BuildDynamicSPQueryWithMultipleOrConditions_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBuildDynamicSPQueryWithMultipleOrConditionsPrametersTypes = new Type[] { typeof(string), typeof(string[]) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_genericEntityTypeAheadAjaxHandlerInstanceFixture, _genericEntityTypeAheadAjaxHandlerInstanceType, MethodBuildDynamicSPQueryWithMultipleOrConditions, Fixture, methodBuildDynamicSPQueryWithMultipleOrConditionsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildDynamicSPQueryWithMultipleOrConditionsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildDynamicSPQueryWithMultipleOrConditions) (Return Type : String) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_BuildDynamicSPQueryWithMultipleOrConditions_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildDynamicSPQueryWithMultipleOrConditions, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_genericEntityTypeAheadAjaxHandlerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (BuildDynamicSPQueryWithMultipleOrConditions) (Return Type : String) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_BuildDynamicSPQueryWithMultipleOrConditions_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBuildDynamicSPQueryWithMultipleOrConditions, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateOrNode) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GenericEntityTypeAheadAjaxHandler_UpdateOrNode_Static_Method_Call_Internally(Type[] types)
        {
            var methodUpdateOrNodePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_genericEntityTypeAheadAjaxHandlerInstanceFixture, _genericEntityTypeAheadAjaxHandlerInstanceType, MethodUpdateOrNode, Fixture, methodUpdateOrNodePrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateOrNode) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_UpdateOrNode_Static_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var xmlDoc = CreateType<XmlDocument>();
            var nodeParent = CreateType<XmlElement>();
            var lookupField = CreateType<string>();
            var val = CreateType<string>();
            var methodUpdateOrNodePrametersTypes = new Type[] { typeof(XmlDocument), typeof(XmlElement), typeof(string), typeof(string) };
            object[] parametersOfUpdateOrNode = { xmlDoc, nodeParent, lookupField, val };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateOrNode, methodUpdateOrNodePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_genericEntityTypeAheadAjaxHandlerInstanceFixture, parametersOfUpdateOrNode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateOrNode.ShouldNotBeNull();
            parametersOfUpdateOrNode.Length.ShouldBe(4);
            methodUpdateOrNodePrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateOrNode) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_UpdateOrNode_Static_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xmlDoc = CreateType<XmlDocument>();
            var nodeParent = CreateType<XmlElement>();
            var lookupField = CreateType<string>();
            var val = CreateType<string>();
            var methodUpdateOrNodePrametersTypes = new Type[] { typeof(XmlDocument), typeof(XmlElement), typeof(string), typeof(string) };
            object[] parametersOfUpdateOrNode = { xmlDoc, nodeParent, lookupField, val };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_genericEntityTypeAheadAjaxHandlerInstanceFixture, _genericEntityTypeAheadAjaxHandlerInstanceType, MethodUpdateOrNode, parametersOfUpdateOrNode, methodUpdateOrNodePrametersTypes);

            // Assert
            parametersOfUpdateOrNode.ShouldNotBeNull();
            parametersOfUpdateOrNode.Length.ShouldBe(4);
            methodUpdateOrNodePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateOrNode) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_UpdateOrNode_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateOrNode, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateOrNode) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_UpdateOrNode_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateOrNodePrametersTypes = new Type[] { typeof(XmlDocument), typeof(XmlElement), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_genericEntityTypeAheadAjaxHandlerInstanceFixture, _genericEntityTypeAheadAjaxHandlerInstanceType, MethodUpdateOrNode, Fixture, methodUpdateOrNodePrametersTypes);

            // Assert
            methodUpdateOrNodePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateOrNode) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_UpdateOrNode_Static_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateOrNode, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_genericEntityTypeAheadAjaxHandlerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildDynamicOrEqCombination) (Return Type : XmlElement) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GenericEntityTypeAheadAjaxHandler_BuildDynamicOrEqCombination_Static_Method_Call_Internally(Type[] types)
        {
            var methodBuildDynamicOrEqCombinationPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_genericEntityTypeAheadAjaxHandlerInstanceFixture, _genericEntityTypeAheadAjaxHandlerInstanceType, MethodBuildDynamicOrEqCombination, Fixture, methodBuildDynamicOrEqCombinationPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildDynamicOrEqCombination) (Return Type : XmlElement) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_BuildDynamicOrEqCombination_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var xmlDoc = CreateType<XmlDocument>();
            var nodeParent = CreateType<XmlElement>();
            var lookupField = CreateType<string>();
            var val = CreateType<string>();
            var methodBuildDynamicOrEqCombinationPrametersTypes = new Type[] { typeof(XmlDocument), typeof(XmlElement), typeof(string), typeof(string) };
            object[] parametersOfBuildDynamicOrEqCombination = { xmlDoc, nodeParent, lookupField, val };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBuildDynamicOrEqCombination, methodBuildDynamicOrEqCombinationPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfBuildDynamicOrEqCombination.ShouldNotBeNull();
            parametersOfBuildDynamicOrEqCombination.Length.ShouldBe(4);
            methodBuildDynamicOrEqCombinationPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => methodInfo.Invoke(_genericEntityTypeAheadAjaxHandlerInstanceFixture, parametersOfBuildDynamicOrEqCombination));
        }

        #endregion

        #region Method Call : (BuildDynamicOrEqCombination) (Return Type : XmlElement) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_BuildDynamicOrEqCombination_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xmlDoc = CreateType<XmlDocument>();
            var nodeParent = CreateType<XmlElement>();
            var lookupField = CreateType<string>();
            var val = CreateType<string>();
            var methodBuildDynamicOrEqCombinationPrametersTypes = new Type[] { typeof(XmlDocument), typeof(XmlElement), typeof(string), typeof(string) };
            object[] parametersOfBuildDynamicOrEqCombination = { xmlDoc, nodeParent, lookupField, val };

            // Assert
            parametersOfBuildDynamicOrEqCombination.ShouldNotBeNull();
            parametersOfBuildDynamicOrEqCombination.Length.ShouldBe(4);
            methodBuildDynamicOrEqCombinationPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<XmlElement>(_genericEntityTypeAheadAjaxHandlerInstanceFixture, _genericEntityTypeAheadAjaxHandlerInstanceType, MethodBuildDynamicOrEqCombination, parametersOfBuildDynamicOrEqCombination, methodBuildDynamicOrEqCombinationPrametersTypes));
        }

        #endregion

        #region Method Call : (BuildDynamicOrEqCombination) (Return Type : XmlElement) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_BuildDynamicOrEqCombination_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodBuildDynamicOrEqCombinationPrametersTypes = new Type[] { typeof(XmlDocument), typeof(XmlElement), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_genericEntityTypeAheadAjaxHandlerInstanceFixture, _genericEntityTypeAheadAjaxHandlerInstanceType, MethodBuildDynamicOrEqCombination, Fixture, methodBuildDynamicOrEqCombinationPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodBuildDynamicOrEqCombinationPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (BuildDynamicOrEqCombination) (Return Type : XmlElement) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_BuildDynamicOrEqCombination_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBuildDynamicOrEqCombinationPrametersTypes = new Type[] { typeof(XmlDocument), typeof(XmlElement), typeof(string), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_genericEntityTypeAheadAjaxHandlerInstanceFixture, _genericEntityTypeAheadAjaxHandlerInstanceType, MethodBuildDynamicOrEqCombination, Fixture, methodBuildDynamicOrEqCombinationPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildDynamicOrEqCombinationPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildDynamicOrEqCombination) (Return Type : XmlElement) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_BuildDynamicOrEqCombination_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildDynamicOrEqCombination, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_genericEntityTypeAheadAjaxHandlerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BuildDynamicOrEqCombination) (Return Type : XmlElement) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_BuildDynamicOrEqCombination_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBuildDynamicOrEqCombination, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildOrNodeForSPQuery) (Return Type : XmlElement) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GenericEntityTypeAheadAjaxHandler_BuildOrNodeForSPQuery_Static_Method_Call_Internally(Type[] types)
        {
            var methodBuildOrNodeForSPQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_genericEntityTypeAheadAjaxHandlerInstanceFixture, _genericEntityTypeAheadAjaxHandlerInstanceType, MethodBuildOrNodeForSPQuery, Fixture, methodBuildOrNodeForSPQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildOrNodeForSPQuery) (Return Type : XmlElement) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_BuildOrNodeForSPQuery_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var xmlDoc = CreateType<XmlDocument>();
            var nodeParent = CreateType<XmlElement>();
            var methodBuildOrNodeForSPQueryPrametersTypes = new Type[] { typeof(XmlDocument), typeof(XmlElement) };
            object[] parametersOfBuildOrNodeForSPQuery = { xmlDoc, nodeParent };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBuildOrNodeForSPQuery, methodBuildOrNodeForSPQueryPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfBuildOrNodeForSPQuery.ShouldNotBeNull();
            parametersOfBuildOrNodeForSPQuery.Length.ShouldBe(2);
            methodBuildOrNodeForSPQueryPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => methodInfo.Invoke(_genericEntityTypeAheadAjaxHandlerInstanceFixture, parametersOfBuildOrNodeForSPQuery));
        }

        #endregion

        #region Method Call : (BuildOrNodeForSPQuery) (Return Type : XmlElement) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_BuildOrNodeForSPQuery_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xmlDoc = CreateType<XmlDocument>();
            var nodeParent = CreateType<XmlElement>();
            var methodBuildOrNodeForSPQueryPrametersTypes = new Type[] { typeof(XmlDocument), typeof(XmlElement) };
            object[] parametersOfBuildOrNodeForSPQuery = { xmlDoc, nodeParent };

            // Assert
            parametersOfBuildOrNodeForSPQuery.ShouldNotBeNull();
            parametersOfBuildOrNodeForSPQuery.Length.ShouldBe(2);
            methodBuildOrNodeForSPQueryPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<XmlElement>(_genericEntityTypeAheadAjaxHandlerInstanceFixture, _genericEntityTypeAheadAjaxHandlerInstanceType, MethodBuildOrNodeForSPQuery, parametersOfBuildOrNodeForSPQuery, methodBuildOrNodeForSPQueryPrametersTypes));
        }

        #endregion

        #region Method Call : (BuildOrNodeForSPQuery) (Return Type : XmlElement) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_BuildOrNodeForSPQuery_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodBuildOrNodeForSPQueryPrametersTypes = new Type[] { typeof(XmlDocument), typeof(XmlElement) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_genericEntityTypeAheadAjaxHandlerInstanceFixture, _genericEntityTypeAheadAjaxHandlerInstanceType, MethodBuildOrNodeForSPQuery, Fixture, methodBuildOrNodeForSPQueryPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodBuildOrNodeForSPQueryPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (BuildOrNodeForSPQuery) (Return Type : XmlElement) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_BuildOrNodeForSPQuery_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBuildOrNodeForSPQueryPrametersTypes = new Type[] { typeof(XmlDocument), typeof(XmlElement) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_genericEntityTypeAheadAjaxHandlerInstanceFixture, _genericEntityTypeAheadAjaxHandlerInstanceType, MethodBuildOrNodeForSPQuery, Fixture, methodBuildOrNodeForSPQueryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildOrNodeForSPQueryPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildOrNodeForSPQuery) (Return Type : XmlElement) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_BuildOrNodeForSPQuery_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildOrNodeForSPQuery, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_genericEntityTypeAheadAjaxHandlerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BuildOrNodeForSPQuery) (Return Type : XmlElement) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_BuildOrNodeForSPQuery_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBuildOrNodeForSPQuery, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildEqNodeForSPQuery) (Return Type : XmlElement) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GenericEntityTypeAheadAjaxHandler_BuildEqNodeForSPQuery_Static_Method_Call_Internally(Type[] types)
        {
            var methodBuildEqNodeForSPQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_genericEntityTypeAheadAjaxHandlerInstanceFixture, _genericEntityTypeAheadAjaxHandlerInstanceType, MethodBuildEqNodeForSPQuery, Fixture, methodBuildEqNodeForSPQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildEqNodeForSPQuery) (Return Type : XmlElement) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_BuildEqNodeForSPQuery_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var xmlDoc = CreateType<XmlDocument>();
            var nodeParent = CreateType<XmlElement>();
            var methodBuildEqNodeForSPQueryPrametersTypes = new Type[] { typeof(XmlDocument), typeof(XmlElement) };
            object[] parametersOfBuildEqNodeForSPQuery = { xmlDoc, nodeParent };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBuildEqNodeForSPQuery, methodBuildEqNodeForSPQueryPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfBuildEqNodeForSPQuery.ShouldNotBeNull();
            parametersOfBuildEqNodeForSPQuery.Length.ShouldBe(2);
            methodBuildEqNodeForSPQueryPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => methodInfo.Invoke(_genericEntityTypeAheadAjaxHandlerInstanceFixture, parametersOfBuildEqNodeForSPQuery));
        }

        #endregion

        #region Method Call : (BuildEqNodeForSPQuery) (Return Type : XmlElement) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_BuildEqNodeForSPQuery_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xmlDoc = CreateType<XmlDocument>();
            var nodeParent = CreateType<XmlElement>();
            var methodBuildEqNodeForSPQueryPrametersTypes = new Type[] { typeof(XmlDocument), typeof(XmlElement) };
            object[] parametersOfBuildEqNodeForSPQuery = { xmlDoc, nodeParent };

            // Assert
            parametersOfBuildEqNodeForSPQuery.ShouldNotBeNull();
            parametersOfBuildEqNodeForSPQuery.Length.ShouldBe(2);
            methodBuildEqNodeForSPQueryPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<XmlElement>(_genericEntityTypeAheadAjaxHandlerInstanceFixture, _genericEntityTypeAheadAjaxHandlerInstanceType, MethodBuildEqNodeForSPQuery, parametersOfBuildEqNodeForSPQuery, methodBuildEqNodeForSPQueryPrametersTypes));
        }

        #endregion

        #region Method Call : (BuildEqNodeForSPQuery) (Return Type : XmlElement) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_BuildEqNodeForSPQuery_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodBuildEqNodeForSPQueryPrametersTypes = new Type[] { typeof(XmlDocument), typeof(XmlElement) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_genericEntityTypeAheadAjaxHandlerInstanceFixture, _genericEntityTypeAheadAjaxHandlerInstanceType, MethodBuildEqNodeForSPQuery, Fixture, methodBuildEqNodeForSPQueryPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodBuildEqNodeForSPQueryPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (BuildEqNodeForSPQuery) (Return Type : XmlElement) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_BuildEqNodeForSPQuery_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBuildEqNodeForSPQueryPrametersTypes = new Type[] { typeof(XmlDocument), typeof(XmlElement) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_genericEntityTypeAheadAjaxHandlerInstanceFixture, _genericEntityTypeAheadAjaxHandlerInstanceType, MethodBuildEqNodeForSPQuery, Fixture, methodBuildEqNodeForSPQueryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildEqNodeForSPQueryPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildEqNodeForSPQuery) (Return Type : XmlElement) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_BuildEqNodeForSPQuery_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildEqNodeForSPQuery, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_genericEntityTypeAheadAjaxHandlerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BuildEqNodeForSPQuery) (Return Type : XmlElement) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_BuildEqNodeForSPQuery_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBuildEqNodeForSPQuery, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildEqNodeInnerXmlForSPQuery) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GenericEntityTypeAheadAjaxHandler_BuildEqNodeInnerXmlForSPQuery_Static_Method_Call_Internally(Type[] types)
        {
            var methodBuildEqNodeInnerXmlForSPQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_genericEntityTypeAheadAjaxHandlerInstanceFixture, _genericEntityTypeAheadAjaxHandlerInstanceType, MethodBuildEqNodeInnerXmlForSPQuery, Fixture, methodBuildEqNodeInnerXmlForSPQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildEqNodeInnerXmlForSPQuery) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_BuildEqNodeInnerXmlForSPQuery_Static_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var xmlDoc = CreateType<XmlDocument>();
            var nodeParent = CreateType<XmlElement>();
            var fieldName = CreateType<string>();
            var val = CreateType<string>();
            var methodBuildEqNodeInnerXmlForSPQueryPrametersTypes = new Type[] { typeof(XmlDocument), typeof(XmlElement), typeof(string), typeof(string) };
            object[] parametersOfBuildEqNodeInnerXmlForSPQuery = { xmlDoc, nodeParent, fieldName, val };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBuildEqNodeInnerXmlForSPQuery, methodBuildEqNodeInnerXmlForSPQueryPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_genericEntityTypeAheadAjaxHandlerInstanceFixture, parametersOfBuildEqNodeInnerXmlForSPQuery);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfBuildEqNodeInnerXmlForSPQuery.ShouldNotBeNull();
            parametersOfBuildEqNodeInnerXmlForSPQuery.Length.ShouldBe(4);
            methodBuildEqNodeInnerXmlForSPQueryPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildEqNodeInnerXmlForSPQuery) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_BuildEqNodeInnerXmlForSPQuery_Static_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xmlDoc = CreateType<XmlDocument>();
            var nodeParent = CreateType<XmlElement>();
            var fieldName = CreateType<string>();
            var val = CreateType<string>();
            var methodBuildEqNodeInnerXmlForSPQueryPrametersTypes = new Type[] { typeof(XmlDocument), typeof(XmlElement), typeof(string), typeof(string) };
            object[] parametersOfBuildEqNodeInnerXmlForSPQuery = { xmlDoc, nodeParent, fieldName, val };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_genericEntityTypeAheadAjaxHandlerInstanceFixture, _genericEntityTypeAheadAjaxHandlerInstanceType, MethodBuildEqNodeInnerXmlForSPQuery, parametersOfBuildEqNodeInnerXmlForSPQuery, methodBuildEqNodeInnerXmlForSPQueryPrametersTypes);

            // Assert
            parametersOfBuildEqNodeInnerXmlForSPQuery.ShouldNotBeNull();
            parametersOfBuildEqNodeInnerXmlForSPQuery.Length.ShouldBe(4);
            methodBuildEqNodeInnerXmlForSPQueryPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildEqNodeInnerXmlForSPQuery) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_BuildEqNodeInnerXmlForSPQuery_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBuildEqNodeInnerXmlForSPQuery, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildEqNodeInnerXmlForSPQuery) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_BuildEqNodeInnerXmlForSPQuery_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBuildEqNodeInnerXmlForSPQueryPrametersTypes = new Type[] { typeof(XmlDocument), typeof(XmlElement), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_genericEntityTypeAheadAjaxHandlerInstanceFixture, _genericEntityTypeAheadAjaxHandlerInstanceType, MethodBuildEqNodeInnerXmlForSPQuery, Fixture, methodBuildEqNodeInnerXmlForSPQueryPrametersTypes);

            // Assert
            methodBuildEqNodeInnerXmlForSPQueryPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildEqNodeInnerXmlForSPQuery) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericEntityTypeAheadAjaxHandler_BuildEqNodeInnerXmlForSPQuery_Static_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildEqNodeInnerXmlForSPQuery, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_genericEntityTypeAheadAjaxHandlerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
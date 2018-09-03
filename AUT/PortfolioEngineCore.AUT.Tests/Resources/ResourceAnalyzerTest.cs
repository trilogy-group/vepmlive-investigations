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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PortfolioEngineCore.ResourceAnalyzer" />)
    ///     and namespace <see cref="PortfolioEngineCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class ResourceAnalyzerTest : AbstractBaseSetupTypedTest<ResourceAnalyzer>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ResourceAnalyzer) Initializer

        private const string MethodGetResourceAnalyzerUserCalendarSettingsXML = "GetResourceAnalyzerUserCalendarSettingsXML";
        private const string MethodSetResourceAnalyzerUserCalendarSettingsXML = "SetResourceAnalyzerUserCalendarSettingsXML";
        private const string MethodGetResourceAnalyzerViewsXML = "GetResourceAnalyzerViewsXML";
        private const string MethodGetResourceAnalyzerViewXML = "GetResourceAnalyzerViewXML";
        private const string MethodSaveResourceAnalyzerViewXML = "SaveResourceAnalyzerViewXML";
        private const string MethodDeleteResourceAnalyzerViewXML = "DeleteResourceAnalyzerViewXML";
        private const string MethodRenameResourceAnalyzerViewXML = "RenameResourceAnalyzerViewXML";
        private const string MethodSetResourceAnalyzerDraggedDataXML = "SetResourceAnalyzerDraggedDataXML";
        private const string MethodFormatSQLDateTime = "FormatSQLDateTime";
        private const string Field_sqlConnection = "_sqlConnection";
        private Type _resourceAnalyzerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ResourceAnalyzer _resourceAnalyzerInstance;
        private ResourceAnalyzer _resourceAnalyzerInstanceFixture;

        #region General Initializer : Class (ResourceAnalyzer) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ResourceAnalyzer" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _resourceAnalyzerInstanceType = typeof(ResourceAnalyzer);
            _resourceAnalyzerInstanceFixture = Create(true);
            _resourceAnalyzerInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ResourceAnalyzer)

        #region General Initializer : Class (ResourceAnalyzer) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ResourceAnalyzer" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetResourceAnalyzerUserCalendarSettingsXML, 0)]
        [TestCase(MethodSetResourceAnalyzerUserCalendarSettingsXML, 0)]
        [TestCase(MethodGetResourceAnalyzerViewsXML, 0)]
        [TestCase(MethodGetResourceAnalyzerViewXML, 0)]
        [TestCase(MethodSaveResourceAnalyzerViewXML, 0)]
        [TestCase(MethodDeleteResourceAnalyzerViewXML, 0)]
        [TestCase(MethodRenameResourceAnalyzerViewXML, 0)]
        [TestCase(MethodSetResourceAnalyzerDraggedDataXML, 0)]
        [TestCase(MethodFormatSQLDateTime, 0)]
        public void AUT_ResourceAnalyzer_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_resourceAnalyzerInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ResourceAnalyzer) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ResourceAnalyzer" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_sqlConnection)]
        public void AUT_ResourceAnalyzer_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_resourceAnalyzerInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ResourceAnalyzer) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="ResourceAnalyzer" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_ResourceAnalyzer_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<ResourceAnalyzer>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (ResourceAnalyzer) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="ResourceAnalyzer" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ResourceAnalyzer_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<ResourceAnalyzer>(Fixture);
        }

        #endregion

        #region General Constructor : Class (ResourceAnalyzer) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ResourceAnalyzer" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ResourceAnalyzer_Constructors_Explore_Verify_Test()
        {
            // Arrange
            var basepath = CreateType<string>();
            var username = CreateType<string>();
            var pid = CreateType<string>();
            var company = CreateType<string>();
            var dbcnstring = CreateType<string>();
            var secLevel = CreateType<SecurityLevels>();
            var bDebug = CreateType<bool>();
            object[] parametersOfResourceAnalyzer = { basepath, username, pid, company, dbcnstring, secLevel, bDebug };
            var methodResourceAnalyzerPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(SecurityLevels), typeof(bool) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_resourceAnalyzerInstanceType, methodResourceAnalyzerPrametersTypes, parametersOfResourceAnalyzer);
        }

        #endregion

        #region General Constructor : Class (ResourceAnalyzer) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ResourceAnalyzer" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ResourceAnalyzer_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodResourceAnalyzerPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(SecurityLevels), typeof(bool) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_resourceAnalyzerInstanceType, Fixture, methodResourceAnalyzerPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (ResourceAnalyzer) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ResourceAnalyzer" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ResourceAnalyzer_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var sBaseInfo = CreateType<string>();
            object[] parametersOfResourceAnalyzer = { sBaseInfo };
            var methodResourceAnalyzerPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_resourceAnalyzerInstanceType, methodResourceAnalyzerPrametersTypes, parametersOfResourceAnalyzer);
        }

        #endregion

        #region General Constructor : Class (ResourceAnalyzer) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ResourceAnalyzer" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ResourceAnalyzer_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodResourceAnalyzerPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_resourceAnalyzerInstanceType, Fixture, methodResourceAnalyzerPrametersTypes);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ResourceAnalyzer" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetResourceAnalyzerUserCalendarSettingsXML)]
        [TestCase(MethodSetResourceAnalyzerUserCalendarSettingsXML)]
        [TestCase(MethodGetResourceAnalyzerViewsXML)]
        [TestCase(MethodGetResourceAnalyzerViewXML)]
        [TestCase(MethodSaveResourceAnalyzerViewXML)]
        [TestCase(MethodDeleteResourceAnalyzerViewXML)]
        [TestCase(MethodRenameResourceAnalyzerViewXML)]
        [TestCase(MethodSetResourceAnalyzerDraggedDataXML)]
        [TestCase(MethodFormatSQLDateTime)]
        public void AUT_ResourceAnalyzer_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ResourceAnalyzer>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerUserCalendarSettingsXML) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceAnalyzer_GetResourceAnalyzerUserCalendarSettingsXML_Method_Call_Internally(Type[] types)
        {
            var methodGetResourceAnalyzerUserCalendarSettingsXMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceAnalyzerInstance, MethodGetResourceAnalyzerUserCalendarSettingsXML, Fixture, methodGetResourceAnalyzerUserCalendarSettingsXMLPrametersTypes);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerUserCalendarSettingsXML) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_GetResourceAnalyzerUserCalendarSettingsXML_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sReply = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _resourceAnalyzerInstance.GetResourceAnalyzerUserCalendarSettingsXML(out sReply);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerUserCalendarSettingsXML) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_GetResourceAnalyzerUserCalendarSettingsXML_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sReply = CreateType<string>();
            var methodGetResourceAnalyzerUserCalendarSettingsXMLPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetResourceAnalyzerUserCalendarSettingsXML = { sReply };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetResourceAnalyzerUserCalendarSettingsXML, methodGetResourceAnalyzerUserCalendarSettingsXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResourceAnalyzer, bool>(_resourceAnalyzerInstanceFixture, out exception1, parametersOfGetResourceAnalyzerUserCalendarSettingsXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResourceAnalyzer, bool>(_resourceAnalyzerInstance, MethodGetResourceAnalyzerUserCalendarSettingsXML, parametersOfGetResourceAnalyzerUserCalendarSettingsXML, methodGetResourceAnalyzerUserCalendarSettingsXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetResourceAnalyzerUserCalendarSettingsXML.ShouldNotBeNull();
            parametersOfGetResourceAnalyzerUserCalendarSettingsXML.Length.ShouldBe(1);
            methodGetResourceAnalyzerUserCalendarSettingsXMLPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerUserCalendarSettingsXML) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_GetResourceAnalyzerUserCalendarSettingsXML_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sReply = CreateType<string>();
            var methodGetResourceAnalyzerUserCalendarSettingsXMLPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetResourceAnalyzerUserCalendarSettingsXML = { sReply };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetResourceAnalyzerUserCalendarSettingsXML, methodGetResourceAnalyzerUserCalendarSettingsXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResourceAnalyzer, bool>(_resourceAnalyzerInstanceFixture, out exception1, parametersOfGetResourceAnalyzerUserCalendarSettingsXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResourceAnalyzer, bool>(_resourceAnalyzerInstance, MethodGetResourceAnalyzerUserCalendarSettingsXML, parametersOfGetResourceAnalyzerUserCalendarSettingsXML, methodGetResourceAnalyzerUserCalendarSettingsXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetResourceAnalyzerUserCalendarSettingsXML.ShouldNotBeNull();
            parametersOfGetResourceAnalyzerUserCalendarSettingsXML.Length.ShouldBe(1);
            methodGetResourceAnalyzerUserCalendarSettingsXMLPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerUserCalendarSettingsXML) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_GetResourceAnalyzerUserCalendarSettingsXML_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sReply = CreateType<string>();
            var methodGetResourceAnalyzerUserCalendarSettingsXMLPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetResourceAnalyzerUserCalendarSettingsXML = { sReply };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ResourceAnalyzer, bool>(_resourceAnalyzerInstance, MethodGetResourceAnalyzerUserCalendarSettingsXML, parametersOfGetResourceAnalyzerUserCalendarSettingsXML, methodGetResourceAnalyzerUserCalendarSettingsXMLPrametersTypes);

            // Assert
            parametersOfGetResourceAnalyzerUserCalendarSettingsXML.ShouldNotBeNull();
            parametersOfGetResourceAnalyzerUserCalendarSettingsXML.Length.ShouldBe(1);
            methodGetResourceAnalyzerUserCalendarSettingsXMLPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerUserCalendarSettingsXML) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_GetResourceAnalyzerUserCalendarSettingsXML_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetResourceAnalyzerUserCalendarSettingsXMLPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceAnalyzerInstance, MethodGetResourceAnalyzerUserCalendarSettingsXML, Fixture, methodGetResourceAnalyzerUserCalendarSettingsXMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetResourceAnalyzerUserCalendarSettingsXMLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerUserCalendarSettingsXML) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_GetResourceAnalyzerUserCalendarSettingsXML_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetResourceAnalyzerUserCalendarSettingsXML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerUserCalendarSettingsXML) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_GetResourceAnalyzerUserCalendarSettingsXML_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetResourceAnalyzerUserCalendarSettingsXML, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetResourceAnalyzerUserCalendarSettingsXML) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceAnalyzer_SetResourceAnalyzerUserCalendarSettingsXML_Method_Call_Internally(Type[] types)
        {
            var methodSetResourceAnalyzerUserCalendarSettingsXMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceAnalyzerInstance, MethodSetResourceAnalyzerUserCalendarSettingsXML, Fixture, methodSetResourceAnalyzerUserCalendarSettingsXMLPrametersTypes);
        }

        #endregion

        #region Method Call : (SetResourceAnalyzerUserCalendarSettingsXML) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_SetResourceAnalyzerUserCalendarSettingsXML_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var calID = CreateType<int>();
            var startID = CreateType<int>();
            var endID = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _resourceAnalyzerInstance.SetResourceAnalyzerUserCalendarSettingsXML(calID, startID, endID);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetResourceAnalyzerUserCalendarSettingsXML) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_SetResourceAnalyzerUserCalendarSettingsXML_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var calID = CreateType<int>();
            var startID = CreateType<int>();
            var endID = CreateType<int>();
            var methodSetResourceAnalyzerUserCalendarSettingsXMLPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(int) };
            object[] parametersOfSetResourceAnalyzerUserCalendarSettingsXML = { calID, startID, endID };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSetResourceAnalyzerUserCalendarSettingsXML, methodSetResourceAnalyzerUserCalendarSettingsXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResourceAnalyzer, bool>(_resourceAnalyzerInstanceFixture, out exception1, parametersOfSetResourceAnalyzerUserCalendarSettingsXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResourceAnalyzer, bool>(_resourceAnalyzerInstance, MethodSetResourceAnalyzerUserCalendarSettingsXML, parametersOfSetResourceAnalyzerUserCalendarSettingsXML, methodSetResourceAnalyzerUserCalendarSettingsXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSetResourceAnalyzerUserCalendarSettingsXML.ShouldNotBeNull();
            parametersOfSetResourceAnalyzerUserCalendarSettingsXML.Length.ShouldBe(3);
            methodSetResourceAnalyzerUserCalendarSettingsXMLPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (SetResourceAnalyzerUserCalendarSettingsXML) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_SetResourceAnalyzerUserCalendarSettingsXML_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var calID = CreateType<int>();
            var startID = CreateType<int>();
            var endID = CreateType<int>();
            var methodSetResourceAnalyzerUserCalendarSettingsXMLPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(int) };
            object[] parametersOfSetResourceAnalyzerUserCalendarSettingsXML = { calID, startID, endID };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSetResourceAnalyzerUserCalendarSettingsXML, methodSetResourceAnalyzerUserCalendarSettingsXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResourceAnalyzer, bool>(_resourceAnalyzerInstanceFixture, out exception1, parametersOfSetResourceAnalyzerUserCalendarSettingsXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResourceAnalyzer, bool>(_resourceAnalyzerInstance, MethodSetResourceAnalyzerUserCalendarSettingsXML, parametersOfSetResourceAnalyzerUserCalendarSettingsXML, methodSetResourceAnalyzerUserCalendarSettingsXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSetResourceAnalyzerUserCalendarSettingsXML.ShouldNotBeNull();
            parametersOfSetResourceAnalyzerUserCalendarSettingsXML.Length.ShouldBe(3);
            methodSetResourceAnalyzerUserCalendarSettingsXMLPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (SetResourceAnalyzerUserCalendarSettingsXML) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_SetResourceAnalyzerUserCalendarSettingsXML_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var calID = CreateType<int>();
            var startID = CreateType<int>();
            var endID = CreateType<int>();
            var methodSetResourceAnalyzerUserCalendarSettingsXMLPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(int) };
            object[] parametersOfSetResourceAnalyzerUserCalendarSettingsXML = { calID, startID, endID };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ResourceAnalyzer, bool>(_resourceAnalyzerInstance, MethodSetResourceAnalyzerUserCalendarSettingsXML, parametersOfSetResourceAnalyzerUserCalendarSettingsXML, methodSetResourceAnalyzerUserCalendarSettingsXMLPrametersTypes);

            // Assert
            parametersOfSetResourceAnalyzerUserCalendarSettingsXML.ShouldNotBeNull();
            parametersOfSetResourceAnalyzerUserCalendarSettingsXML.Length.ShouldBe(3);
            methodSetResourceAnalyzerUserCalendarSettingsXMLPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetResourceAnalyzerUserCalendarSettingsXML) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_SetResourceAnalyzerUserCalendarSettingsXML_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetResourceAnalyzerUserCalendarSettingsXMLPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(int) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceAnalyzerInstance, MethodSetResourceAnalyzerUserCalendarSettingsXML, Fixture, methodSetResourceAnalyzerUserCalendarSettingsXMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSetResourceAnalyzerUserCalendarSettingsXMLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetResourceAnalyzerUserCalendarSettingsXML) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_SetResourceAnalyzerUserCalendarSettingsXML_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetResourceAnalyzerUserCalendarSettingsXML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetResourceAnalyzerUserCalendarSettingsXML) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_SetResourceAnalyzerUserCalendarSettingsXML_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetResourceAnalyzerUserCalendarSettingsXML, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerViewsXML) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceAnalyzer_GetResourceAnalyzerViewsXML_Method_Call_Internally(Type[] types)
        {
            var methodGetResourceAnalyzerViewsXMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceAnalyzerInstance, MethodGetResourceAnalyzerViewsXML, Fixture, methodGetResourceAnalyzerViewsXMLPrametersTypes);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerViewsXML) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_GetResourceAnalyzerViewsXML_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sReply = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _resourceAnalyzerInstance.GetResourceAnalyzerViewsXML(out sReply);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerViewsXML) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_GetResourceAnalyzerViewsXML_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sReply = CreateType<string>();
            var methodGetResourceAnalyzerViewsXMLPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetResourceAnalyzerViewsXML = { sReply };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetResourceAnalyzerViewsXML, methodGetResourceAnalyzerViewsXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResourceAnalyzer, bool>(_resourceAnalyzerInstanceFixture, out exception1, parametersOfGetResourceAnalyzerViewsXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResourceAnalyzer, bool>(_resourceAnalyzerInstance, MethodGetResourceAnalyzerViewsXML, parametersOfGetResourceAnalyzerViewsXML, methodGetResourceAnalyzerViewsXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetResourceAnalyzerViewsXML.ShouldNotBeNull();
            parametersOfGetResourceAnalyzerViewsXML.Length.ShouldBe(1);
            methodGetResourceAnalyzerViewsXMLPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerViewsXML) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_GetResourceAnalyzerViewsXML_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sReply = CreateType<string>();
            var methodGetResourceAnalyzerViewsXMLPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetResourceAnalyzerViewsXML = { sReply };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetResourceAnalyzerViewsXML, methodGetResourceAnalyzerViewsXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResourceAnalyzer, bool>(_resourceAnalyzerInstanceFixture, out exception1, parametersOfGetResourceAnalyzerViewsXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResourceAnalyzer, bool>(_resourceAnalyzerInstance, MethodGetResourceAnalyzerViewsXML, parametersOfGetResourceAnalyzerViewsXML, methodGetResourceAnalyzerViewsXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetResourceAnalyzerViewsXML.ShouldNotBeNull();
            parametersOfGetResourceAnalyzerViewsXML.Length.ShouldBe(1);
            methodGetResourceAnalyzerViewsXMLPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerViewsXML) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_GetResourceAnalyzerViewsXML_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sReply = CreateType<string>();
            var methodGetResourceAnalyzerViewsXMLPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetResourceAnalyzerViewsXML = { sReply };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ResourceAnalyzer, bool>(_resourceAnalyzerInstance, MethodGetResourceAnalyzerViewsXML, parametersOfGetResourceAnalyzerViewsXML, methodGetResourceAnalyzerViewsXMLPrametersTypes);

            // Assert
            parametersOfGetResourceAnalyzerViewsXML.ShouldNotBeNull();
            parametersOfGetResourceAnalyzerViewsXML.Length.ShouldBe(1);
            methodGetResourceAnalyzerViewsXMLPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerViewsXML) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_GetResourceAnalyzerViewsXML_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetResourceAnalyzerViewsXMLPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceAnalyzerInstance, MethodGetResourceAnalyzerViewsXML, Fixture, methodGetResourceAnalyzerViewsXMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetResourceAnalyzerViewsXMLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerViewsXML) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_GetResourceAnalyzerViewsXML_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetResourceAnalyzerViewsXML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerViewsXML) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_GetResourceAnalyzerViewsXML_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetResourceAnalyzerViewsXML, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerViewXML) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceAnalyzer_GetResourceAnalyzerViewXML_Method_Call_Internally(Type[] types)
        {
            var methodGetResourceAnalyzerViewXMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceAnalyzerInstance, MethodGetResourceAnalyzerViewXML, Fixture, methodGetResourceAnalyzerViewXMLPrametersTypes);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerViewXML) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_GetResourceAnalyzerViewXML_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var sReply = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _resourceAnalyzerInstance.GetResourceAnalyzerViewXML(guidView, out sReply);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerViewXML) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_GetResourceAnalyzerViewXML_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var sReply = CreateType<string>();
            var methodGetResourceAnalyzerViewXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            object[] parametersOfGetResourceAnalyzerViewXML = { guidView, sReply };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetResourceAnalyzerViewXML, methodGetResourceAnalyzerViewXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResourceAnalyzer, bool>(_resourceAnalyzerInstanceFixture, out exception1, parametersOfGetResourceAnalyzerViewXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResourceAnalyzer, bool>(_resourceAnalyzerInstance, MethodGetResourceAnalyzerViewXML, parametersOfGetResourceAnalyzerViewXML, methodGetResourceAnalyzerViewXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetResourceAnalyzerViewXML.ShouldNotBeNull();
            parametersOfGetResourceAnalyzerViewXML.Length.ShouldBe(2);
            methodGetResourceAnalyzerViewXMLPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerViewXML) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_GetResourceAnalyzerViewXML_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var sReply = CreateType<string>();
            var methodGetResourceAnalyzerViewXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            object[] parametersOfGetResourceAnalyzerViewXML = { guidView, sReply };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetResourceAnalyzerViewXML, methodGetResourceAnalyzerViewXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResourceAnalyzer, bool>(_resourceAnalyzerInstanceFixture, out exception1, parametersOfGetResourceAnalyzerViewXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResourceAnalyzer, bool>(_resourceAnalyzerInstance, MethodGetResourceAnalyzerViewXML, parametersOfGetResourceAnalyzerViewXML, methodGetResourceAnalyzerViewXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetResourceAnalyzerViewXML.ShouldNotBeNull();
            parametersOfGetResourceAnalyzerViewXML.Length.ShouldBe(2);
            methodGetResourceAnalyzerViewXMLPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerViewXML) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_GetResourceAnalyzerViewXML_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var sReply = CreateType<string>();
            var methodGetResourceAnalyzerViewXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            object[] parametersOfGetResourceAnalyzerViewXML = { guidView, sReply };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ResourceAnalyzer, bool>(_resourceAnalyzerInstance, MethodGetResourceAnalyzerViewXML, parametersOfGetResourceAnalyzerViewXML, methodGetResourceAnalyzerViewXMLPrametersTypes);

            // Assert
            parametersOfGetResourceAnalyzerViewXML.ShouldNotBeNull();
            parametersOfGetResourceAnalyzerViewXML.Length.ShouldBe(2);
            methodGetResourceAnalyzerViewXMLPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerViewXML) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_GetResourceAnalyzerViewXML_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetResourceAnalyzerViewXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceAnalyzerInstance, MethodGetResourceAnalyzerViewXML, Fixture, methodGetResourceAnalyzerViewXMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetResourceAnalyzerViewXMLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerViewXML) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_GetResourceAnalyzerViewXML_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetResourceAnalyzerViewXML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerViewXML) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_GetResourceAnalyzerViewXML_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetResourceAnalyzerViewXML, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveResourceAnalyzerViewXML) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceAnalyzer_SaveResourceAnalyzerViewXML_Method_Call_Internally(Type[] types)
        {
            var methodSaveResourceAnalyzerViewXMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceAnalyzerInstance, MethodSaveResourceAnalyzerViewXML, Fixture, methodSaveResourceAnalyzerViewXMLPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveResourceAnalyzerViewXML) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_SaveResourceAnalyzerViewXML_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var sName = CreateType<string>();
            var bPersonal = CreateType<bool>();
            var bDefault = CreateType<bool>();
            var sData = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _resourceAnalyzerInstance.SaveResourceAnalyzerViewXML(guidView, sName, bPersonal, bDefault, sData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SaveResourceAnalyzerViewXML) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_SaveResourceAnalyzerViewXML_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var sName = CreateType<string>();
            var bPersonal = CreateType<bool>();
            var bDefault = CreateType<bool>();
            var sData = CreateType<string>();
            var methodSaveResourceAnalyzerViewXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(bool), typeof(bool), typeof(string) };
            object[] parametersOfSaveResourceAnalyzerViewXML = { guidView, sName, bPersonal, bDefault, sData };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSaveResourceAnalyzerViewXML, methodSaveResourceAnalyzerViewXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResourceAnalyzer, bool>(_resourceAnalyzerInstanceFixture, out exception1, parametersOfSaveResourceAnalyzerViewXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResourceAnalyzer, bool>(_resourceAnalyzerInstance, MethodSaveResourceAnalyzerViewXML, parametersOfSaveResourceAnalyzerViewXML, methodSaveResourceAnalyzerViewXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSaveResourceAnalyzerViewXML.ShouldNotBeNull();
            parametersOfSaveResourceAnalyzerViewXML.Length.ShouldBe(5);
            methodSaveResourceAnalyzerViewXMLPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (SaveResourceAnalyzerViewXML) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_SaveResourceAnalyzerViewXML_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var sName = CreateType<string>();
            var bPersonal = CreateType<bool>();
            var bDefault = CreateType<bool>();
            var sData = CreateType<string>();
            var methodSaveResourceAnalyzerViewXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(bool), typeof(bool), typeof(string) };
            object[] parametersOfSaveResourceAnalyzerViewXML = { guidView, sName, bPersonal, bDefault, sData };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSaveResourceAnalyzerViewXML, methodSaveResourceAnalyzerViewXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResourceAnalyzer, bool>(_resourceAnalyzerInstanceFixture, out exception1, parametersOfSaveResourceAnalyzerViewXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResourceAnalyzer, bool>(_resourceAnalyzerInstance, MethodSaveResourceAnalyzerViewXML, parametersOfSaveResourceAnalyzerViewXML, methodSaveResourceAnalyzerViewXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSaveResourceAnalyzerViewXML.ShouldNotBeNull();
            parametersOfSaveResourceAnalyzerViewXML.Length.ShouldBe(5);
            methodSaveResourceAnalyzerViewXMLPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (SaveResourceAnalyzerViewXML) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_SaveResourceAnalyzerViewXML_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var sName = CreateType<string>();
            var bPersonal = CreateType<bool>();
            var bDefault = CreateType<bool>();
            var sData = CreateType<string>();
            var methodSaveResourceAnalyzerViewXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(bool), typeof(bool), typeof(string) };
            object[] parametersOfSaveResourceAnalyzerViewXML = { guidView, sName, bPersonal, bDefault, sData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ResourceAnalyzer, bool>(_resourceAnalyzerInstance, MethodSaveResourceAnalyzerViewXML, parametersOfSaveResourceAnalyzerViewXML, methodSaveResourceAnalyzerViewXMLPrametersTypes);

            // Assert
            parametersOfSaveResourceAnalyzerViewXML.ShouldNotBeNull();
            parametersOfSaveResourceAnalyzerViewXML.Length.ShouldBe(5);
            methodSaveResourceAnalyzerViewXMLPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveResourceAnalyzerViewXML) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_SaveResourceAnalyzerViewXML_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveResourceAnalyzerViewXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(bool), typeof(bool), typeof(string) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceAnalyzerInstance, MethodSaveResourceAnalyzerViewXML, Fixture, methodSaveResourceAnalyzerViewXMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSaveResourceAnalyzerViewXMLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveResourceAnalyzerViewXML) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_SaveResourceAnalyzerViewXML_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveResourceAnalyzerViewXML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SaveResourceAnalyzerViewXML) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_SaveResourceAnalyzerViewXML_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSaveResourceAnalyzerViewXML, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteResourceAnalyzerViewXML) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceAnalyzer_DeleteResourceAnalyzerViewXML_Method_Call_Internally(Type[] types)
        {
            var methodDeleteResourceAnalyzerViewXMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceAnalyzerInstance, MethodDeleteResourceAnalyzerViewXML, Fixture, methodDeleteResourceAnalyzerViewXMLPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteResourceAnalyzerViewXML) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_DeleteResourceAnalyzerViewXML_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => _resourceAnalyzerInstance.DeleteResourceAnalyzerViewXML(guidView);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteResourceAnalyzerViewXML) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_DeleteResourceAnalyzerViewXML_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var methodDeleteResourceAnalyzerViewXMLPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfDeleteResourceAnalyzerViewXML = { guidView };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteResourceAnalyzerViewXML, methodDeleteResourceAnalyzerViewXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResourceAnalyzer, bool>(_resourceAnalyzerInstanceFixture, out exception1, parametersOfDeleteResourceAnalyzerViewXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResourceAnalyzer, bool>(_resourceAnalyzerInstance, MethodDeleteResourceAnalyzerViewXML, parametersOfDeleteResourceAnalyzerViewXML, methodDeleteResourceAnalyzerViewXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteResourceAnalyzerViewXML.ShouldNotBeNull();
            parametersOfDeleteResourceAnalyzerViewXML.Length.ShouldBe(1);
            methodDeleteResourceAnalyzerViewXMLPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteResourceAnalyzerViewXML) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_DeleteResourceAnalyzerViewXML_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var methodDeleteResourceAnalyzerViewXMLPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfDeleteResourceAnalyzerViewXML = { guidView };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteResourceAnalyzerViewXML, methodDeleteResourceAnalyzerViewXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResourceAnalyzer, bool>(_resourceAnalyzerInstanceFixture, out exception1, parametersOfDeleteResourceAnalyzerViewXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResourceAnalyzer, bool>(_resourceAnalyzerInstance, MethodDeleteResourceAnalyzerViewXML, parametersOfDeleteResourceAnalyzerViewXML, methodDeleteResourceAnalyzerViewXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteResourceAnalyzerViewXML.ShouldNotBeNull();
            parametersOfDeleteResourceAnalyzerViewXML.Length.ShouldBe(1);
            methodDeleteResourceAnalyzerViewXMLPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteResourceAnalyzerViewXML) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_DeleteResourceAnalyzerViewXML_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var methodDeleteResourceAnalyzerViewXMLPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfDeleteResourceAnalyzerViewXML = { guidView };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ResourceAnalyzer, bool>(_resourceAnalyzerInstance, MethodDeleteResourceAnalyzerViewXML, parametersOfDeleteResourceAnalyzerViewXML, methodDeleteResourceAnalyzerViewXMLPrametersTypes);

            // Assert
            parametersOfDeleteResourceAnalyzerViewXML.ShouldNotBeNull();
            parametersOfDeleteResourceAnalyzerViewXML.Length.ShouldBe(1);
            methodDeleteResourceAnalyzerViewXMLPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteResourceAnalyzerViewXML) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_DeleteResourceAnalyzerViewXML_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteResourceAnalyzerViewXMLPrametersTypes = new Type[] { typeof(Guid) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceAnalyzerInstance, MethodDeleteResourceAnalyzerViewXML, Fixture, methodDeleteResourceAnalyzerViewXMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteResourceAnalyzerViewXMLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteResourceAnalyzerViewXML) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_DeleteResourceAnalyzerViewXML_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteResourceAnalyzerViewXML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteResourceAnalyzerViewXML) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_DeleteResourceAnalyzerViewXML_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteResourceAnalyzerViewXML, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenameResourceAnalyzerViewXML) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceAnalyzer_RenameResourceAnalyzerViewXML_Method_Call_Internally(Type[] types)
        {
            var methodRenameResourceAnalyzerViewXMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceAnalyzerInstance, MethodRenameResourceAnalyzerViewXML, Fixture, methodRenameResourceAnalyzerViewXMLPrametersTypes);
        }

        #endregion

        #region Method Call : (RenameResourceAnalyzerViewXML) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_RenameResourceAnalyzerViewXML_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var sName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _resourceAnalyzerInstance.RenameResourceAnalyzerViewXML(guidView, sName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (RenameResourceAnalyzerViewXML) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_RenameResourceAnalyzerViewXML_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var sName = CreateType<string>();
            var methodRenameResourceAnalyzerViewXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            object[] parametersOfRenameResourceAnalyzerViewXML = { guidView, sName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRenameResourceAnalyzerViewXML, methodRenameResourceAnalyzerViewXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResourceAnalyzer, bool>(_resourceAnalyzerInstanceFixture, out exception1, parametersOfRenameResourceAnalyzerViewXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResourceAnalyzer, bool>(_resourceAnalyzerInstance, MethodRenameResourceAnalyzerViewXML, parametersOfRenameResourceAnalyzerViewXML, methodRenameResourceAnalyzerViewXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfRenameResourceAnalyzerViewXML.ShouldNotBeNull();
            parametersOfRenameResourceAnalyzerViewXML.Length.ShouldBe(2);
            methodRenameResourceAnalyzerViewXMLPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (RenameResourceAnalyzerViewXML) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_RenameResourceAnalyzerViewXML_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var sName = CreateType<string>();
            var methodRenameResourceAnalyzerViewXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            object[] parametersOfRenameResourceAnalyzerViewXML = { guidView, sName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRenameResourceAnalyzerViewXML, methodRenameResourceAnalyzerViewXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResourceAnalyzer, bool>(_resourceAnalyzerInstanceFixture, out exception1, parametersOfRenameResourceAnalyzerViewXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResourceAnalyzer, bool>(_resourceAnalyzerInstance, MethodRenameResourceAnalyzerViewXML, parametersOfRenameResourceAnalyzerViewXML, methodRenameResourceAnalyzerViewXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfRenameResourceAnalyzerViewXML.ShouldNotBeNull();
            parametersOfRenameResourceAnalyzerViewXML.Length.ShouldBe(2);
            methodRenameResourceAnalyzerViewXMLPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (RenameResourceAnalyzerViewXML) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_RenameResourceAnalyzerViewXML_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var sName = CreateType<string>();
            var methodRenameResourceAnalyzerViewXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            object[] parametersOfRenameResourceAnalyzerViewXML = { guidView, sName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ResourceAnalyzer, bool>(_resourceAnalyzerInstance, MethodRenameResourceAnalyzerViewXML, parametersOfRenameResourceAnalyzerViewXML, methodRenameResourceAnalyzerViewXMLPrametersTypes);

            // Assert
            parametersOfRenameResourceAnalyzerViewXML.ShouldNotBeNull();
            parametersOfRenameResourceAnalyzerViewXML.Length.ShouldBe(2);
            methodRenameResourceAnalyzerViewXMLPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenameResourceAnalyzerViewXML) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_RenameResourceAnalyzerViewXML_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenameResourceAnalyzerViewXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceAnalyzerInstance, MethodRenameResourceAnalyzerViewXML, Fixture, methodRenameResourceAnalyzerViewXMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRenameResourceAnalyzerViewXMLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenameResourceAnalyzerViewXML) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_RenameResourceAnalyzerViewXML_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenameResourceAnalyzerViewXML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RenameResourceAnalyzerViewXML) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_RenameResourceAnalyzerViewXML_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRenameResourceAnalyzerViewXML, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetResourceAnalyzerDraggedDataXML) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceAnalyzer_SetResourceAnalyzerDraggedDataXML_Method_Call_Internally(Type[] types)
        {
            var methodSetResourceAnalyzerDraggedDataXMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceAnalyzerInstance, MethodSetResourceAnalyzerDraggedDataXML, Fixture, methodSetResourceAnalyzerDraggedDataXMLPrametersTypes);
        }

        #endregion

        #region Method Call : (SetResourceAnalyzerDraggedDataXML) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_SetResourceAnalyzerDraggedDataXML_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var dataXML = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _resourceAnalyzerInstance.SetResourceAnalyzerDraggedDataXML(dataXML);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetResourceAnalyzerDraggedDataXML) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_SetResourceAnalyzerDraggedDataXML_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var dataXML = CreateType<string>();
            var methodSetResourceAnalyzerDraggedDataXMLPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSetResourceAnalyzerDraggedDataXML = { dataXML };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSetResourceAnalyzerDraggedDataXML, methodSetResourceAnalyzerDraggedDataXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResourceAnalyzer, bool>(_resourceAnalyzerInstanceFixture, out exception1, parametersOfSetResourceAnalyzerDraggedDataXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResourceAnalyzer, bool>(_resourceAnalyzerInstance, MethodSetResourceAnalyzerDraggedDataXML, parametersOfSetResourceAnalyzerDraggedDataXML, methodSetResourceAnalyzerDraggedDataXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSetResourceAnalyzerDraggedDataXML.ShouldNotBeNull();
            parametersOfSetResourceAnalyzerDraggedDataXML.Length.ShouldBe(1);
            methodSetResourceAnalyzerDraggedDataXMLPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SetResourceAnalyzerDraggedDataXML) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_SetResourceAnalyzerDraggedDataXML_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var dataXML = CreateType<string>();
            var methodSetResourceAnalyzerDraggedDataXMLPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSetResourceAnalyzerDraggedDataXML = { dataXML };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSetResourceAnalyzerDraggedDataXML, methodSetResourceAnalyzerDraggedDataXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResourceAnalyzer, bool>(_resourceAnalyzerInstanceFixture, out exception1, parametersOfSetResourceAnalyzerDraggedDataXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResourceAnalyzer, bool>(_resourceAnalyzerInstance, MethodSetResourceAnalyzerDraggedDataXML, parametersOfSetResourceAnalyzerDraggedDataXML, methodSetResourceAnalyzerDraggedDataXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSetResourceAnalyzerDraggedDataXML.ShouldNotBeNull();
            parametersOfSetResourceAnalyzerDraggedDataXML.Length.ShouldBe(1);
            methodSetResourceAnalyzerDraggedDataXMLPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SetResourceAnalyzerDraggedDataXML) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_SetResourceAnalyzerDraggedDataXML_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dataXML = CreateType<string>();
            var methodSetResourceAnalyzerDraggedDataXMLPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSetResourceAnalyzerDraggedDataXML = { dataXML };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ResourceAnalyzer, bool>(_resourceAnalyzerInstance, MethodSetResourceAnalyzerDraggedDataXML, parametersOfSetResourceAnalyzerDraggedDataXML, methodSetResourceAnalyzerDraggedDataXMLPrametersTypes);

            // Assert
            parametersOfSetResourceAnalyzerDraggedDataXML.ShouldNotBeNull();
            parametersOfSetResourceAnalyzerDraggedDataXML.Length.ShouldBe(1);
            methodSetResourceAnalyzerDraggedDataXMLPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetResourceAnalyzerDraggedDataXML) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_SetResourceAnalyzerDraggedDataXML_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetResourceAnalyzerDraggedDataXMLPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceAnalyzerInstance, MethodSetResourceAnalyzerDraggedDataXML, Fixture, methodSetResourceAnalyzerDraggedDataXMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSetResourceAnalyzerDraggedDataXMLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetResourceAnalyzerDraggedDataXML) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_SetResourceAnalyzerDraggedDataXML_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetResourceAnalyzerDraggedDataXML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetResourceAnalyzerDraggedDataXML) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_SetResourceAnalyzerDraggedDataXML_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetResourceAnalyzerDraggedDataXML, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FormatSQLDateTime) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceAnalyzer_FormatSQLDateTime_Method_Call_Internally(Type[] types)
        {
            var methodFormatSQLDateTimePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceAnalyzerInstance, MethodFormatSQLDateTime, Fixture, methodFormatSQLDateTimePrametersTypes);
        }

        #endregion

        #region Method Call : (FormatSQLDateTime) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_FormatSQLDateTime_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var dt = CreateType<DateTime>();
            var methodFormatSQLDateTimePrametersTypes = new Type[] { typeof(DateTime) };
            object[] parametersOfFormatSQLDateTime = { dt };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodFormatSQLDateTime, methodFormatSQLDateTimePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResourceAnalyzer, string>(_resourceAnalyzerInstanceFixture, out exception1, parametersOfFormatSQLDateTime);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResourceAnalyzer, string>(_resourceAnalyzerInstance, MethodFormatSQLDateTime, parametersOfFormatSQLDateTime, methodFormatSQLDateTimePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfFormatSQLDateTime.ShouldNotBeNull();
            parametersOfFormatSQLDateTime.Length.ShouldBe(1);
            methodFormatSQLDateTimePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (FormatSQLDateTime) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_FormatSQLDateTime_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dt = CreateType<DateTime>();
            var methodFormatSQLDateTimePrametersTypes = new Type[] { typeof(DateTime) };
            object[] parametersOfFormatSQLDateTime = { dt };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ResourceAnalyzer, string>(_resourceAnalyzerInstance, MethodFormatSQLDateTime, parametersOfFormatSQLDateTime, methodFormatSQLDateTimePrametersTypes);

            // Assert
            parametersOfFormatSQLDateTime.ShouldNotBeNull();
            parametersOfFormatSQLDateTime.Length.ShouldBe(1);
            methodFormatSQLDateTimePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FormatSQLDateTime) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_FormatSQLDateTime_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodFormatSQLDateTimePrametersTypes = new Type[] { typeof(DateTime) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceAnalyzerInstance, MethodFormatSQLDateTime, Fixture, methodFormatSQLDateTimePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodFormatSQLDateTimePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (FormatSQLDateTime) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_FormatSQLDateTime_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFormatSQLDateTimePrametersTypes = new Type[] { typeof(DateTime) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceAnalyzerInstance, MethodFormatSQLDateTime, Fixture, methodFormatSQLDateTimePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodFormatSQLDateTimePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FormatSQLDateTime) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_FormatSQLDateTime_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFormatSQLDateTime, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (FormatSQLDateTime) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceAnalyzer_FormatSQLDateTime_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodFormatSQLDateTime, 0);
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
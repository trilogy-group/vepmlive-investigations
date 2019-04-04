using System;
using System.Collections.Generic;
using System.Data;
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

namespace EPMLiveCore.Infrastructure
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Infrastructure.ResourcePoolManager" />)
    ///     and namespace <see cref="EPMLiveCore.Infrastructure"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ResourcePoolManagerTest : AbstractBaseSetupTypedTest<ResourcePoolManager>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ResourcePoolManager) Initializer

        private const string MethodGetAll = "GetAll";
        private const string MethodBuildXmlElements = "BuildXmlElements";
        private const string MethodGetAllFromReportingDB = "GetAllFromReportingDB";
        private const string MethodProcessHtmlValues = "ProcessHtmlValues";
        private Type _resourcePoolManagerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ResourcePoolManager _resourcePoolManagerInstance;
        private ResourcePoolManager _resourcePoolManagerInstanceFixture;

        #region General Initializer : Class (ResourcePoolManager) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ResourcePoolManager" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _resourcePoolManagerInstanceType = typeof(ResourcePoolManager);
            _resourcePoolManagerInstanceFixture = Create(true);
            _resourcePoolManagerInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ResourcePoolManager)

        #region General Initializer : Class (ResourcePoolManager) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ResourcePoolManager" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetAll, 0)]
        [TestCase(MethodBuildXmlElements, 0)]
        [TestCase(MethodGetAllFromReportingDB, 0)]
        [TestCase(MethodProcessHtmlValues, 0)]
        public void AUT_ResourcePoolManager_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_resourcePoolManagerInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ResourcePoolManager) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="ResourcePoolManager" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_ResourcePoolManager_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<ResourcePoolManager>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (ResourcePoolManager) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="ResourcePoolManager" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ResourcePoolManager_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<ResourcePoolManager>(Fixture);
        }

        #endregion

        #region General Constructor : Class (ResourcePoolManager) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ResourcePoolManager" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ResourcePoolManager_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfResourcePoolManager = {  };
            Type [] methodResourcePoolManagerPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_resourcePoolManagerInstanceType, methodResourcePoolManagerPrametersTypes, parametersOfResourcePoolManager);
        }

        #endregion

        #region General Constructor : Class (ResourcePoolManager) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ResourcePoolManager" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ResourcePoolManager_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodResourcePoolManagerPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_resourcePoolManagerInstanceType, Fixture, methodResourcePoolManagerPrametersTypes);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ResourcePoolManager" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetAll)]
        [TestCase(MethodBuildXmlElements)]
        [TestCase(MethodGetAllFromReportingDB)]
        [TestCase(MethodProcessHtmlValues)]
        public void AUT_ResourcePoolManager_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ResourcePoolManager>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetAll) (Return Type : XDocument) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePoolManager_GetAll_Method_Call_Internally(Type[] types)
        {
            var methodGetAllPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolManagerInstance, MethodGetAll, Fixture, methodGetAllPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAll) (Return Type : XDocument) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolManager_GetAll_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var includeHidden = CreateType<bool>();
            var includeReadOnly = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _resourcePoolManagerInstance.GetAll(includeHidden, includeReadOnly);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetAll) (Return Type : XDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolManager_GetAll_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var includeHidden = CreateType<bool>();
            var includeReadOnly = CreateType<bool>();
            var methodGetAllPrametersTypes = new Type[] { typeof(bool), typeof(bool) };
            object[] parametersOfGetAll = { includeHidden, includeReadOnly };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetAll, methodGetAllPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResourcePoolManager, XDocument>(_resourcePoolManagerInstanceFixture, out exception1, parametersOfGetAll);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResourcePoolManager, XDocument>(_resourcePoolManagerInstance, MethodGetAll, parametersOfGetAll, methodGetAllPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetAll.ShouldNotBeNull();
            parametersOfGetAll.Length.ShouldBe(2);
            methodGetAllPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(() => methodInfo.Invoke(_resourcePoolManagerInstanceFixture, parametersOfGetAll));
        }

        #endregion

        #region Method Call : (GetAll) (Return Type : XDocument) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolManager_GetAll_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var includeHidden = CreateType<bool>();
            var includeReadOnly = CreateType<bool>();
            var methodGetAllPrametersTypes = new Type[] { typeof(bool), typeof(bool) };
            object[] parametersOfGetAll = { includeHidden, includeReadOnly };

            // Assert
            parametersOfGetAll.ShouldNotBeNull();
            parametersOfGetAll.Length.ShouldBe(2);
            methodGetAllPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<ResourcePoolManager, XDocument>(_resourcePoolManagerInstance, MethodGetAll, parametersOfGetAll, methodGetAllPrametersTypes));
        }

        #endregion

        #region Method Call : (GetAll) (Return Type : XDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolManager_GetAll_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetAllPrametersTypes = new Type[] { typeof(bool), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolManagerInstance, MethodGetAll, Fixture, methodGetAllPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetAllPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetAll) (Return Type : XDocument) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolManager_GetAll_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetAllPrametersTypes = new Type[] { typeof(bool), typeof(bool) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolManagerInstance, MethodGetAll, Fixture, methodGetAllPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetAllPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAll) (Return Type : XDocument) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolManager_GetAll_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetAll, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcePoolManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAll) (Return Type : XDocument) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolManager_GetAll_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetAll, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildXmlElements) (Return Type : List<XElement>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePoolManager_BuildXmlElements_Method_Call_Internally(Type[] types)
        {
            var methodBuildXmlElementsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolManagerInstance, MethodBuildXmlElements, Fixture, methodBuildXmlElementsPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildXmlElements) (Return Type : List<XElement>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolManager_BuildXmlElements_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var includeHidden = CreateType<bool>();
            var includeReadOnly = CreateType<bool>();
            var rowCollection = CreateType<IEnumerable<DataRow>>();
            var spFieldCollection = CreateType<List<SPField>>();
            var dataColumnCollection = CreateType<DataColumnCollection>();
            var resources = CreateType<DataTable>();
            var valueDictionary = CreateType<Dictionary<string, object[]>>();
            var methodBuildXmlElementsPrametersTypes = new Type[] { typeof(bool), typeof(bool), typeof(IEnumerable<DataRow>), typeof(List<SPField>), typeof(DataColumnCollection), typeof(DataTable), typeof(Dictionary<string, object[]>) };
            object[] parametersOfBuildXmlElements = { includeHidden, includeReadOnly, rowCollection, spFieldCollection, dataColumnCollection, resources, valueDictionary };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodBuildXmlElements, methodBuildXmlElementsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResourcePoolManager, List<XElement>>(_resourcePoolManagerInstanceFixture, out exception1, parametersOfBuildXmlElements);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResourcePoolManager, List<XElement>>(_resourcePoolManagerInstance, MethodBuildXmlElements, parametersOfBuildXmlElements, methodBuildXmlElementsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfBuildXmlElements.ShouldNotBeNull();
            parametersOfBuildXmlElements.Length.ShouldBe(7);
            methodBuildXmlElementsPrametersTypes.Length.ShouldBe(7);
            Should.Throw<Exception>(() => methodInfo.Invoke(_resourcePoolManagerInstanceFixture, parametersOfBuildXmlElements));
        }

        #endregion

        #region Method Call : (BuildXmlElements) (Return Type : List<XElement>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolManager_BuildXmlElements_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var includeHidden = CreateType<bool>();
            var includeReadOnly = CreateType<bool>();
            var rowCollection = CreateType<IEnumerable<DataRow>>();
            var spFieldCollection = CreateType<List<SPField>>();
            var dataColumnCollection = CreateType<DataColumnCollection>();
            var resources = CreateType<DataTable>();
            var valueDictionary = CreateType<Dictionary<string, object[]>>();
            var methodBuildXmlElementsPrametersTypes = new Type[] { typeof(bool), typeof(bool), typeof(IEnumerable<DataRow>), typeof(List<SPField>), typeof(DataColumnCollection), typeof(DataTable), typeof(Dictionary<string, object[]>) };
            object[] parametersOfBuildXmlElements = { includeHidden, includeReadOnly, rowCollection, spFieldCollection, dataColumnCollection, resources, valueDictionary };

            // Assert
            parametersOfBuildXmlElements.ShouldNotBeNull();
            parametersOfBuildXmlElements.Length.ShouldBe(7);
            methodBuildXmlElementsPrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<ResourcePoolManager, List<XElement>>(_resourcePoolManagerInstance, MethodBuildXmlElements, parametersOfBuildXmlElements, methodBuildXmlElementsPrametersTypes));
        }

        #endregion

        #region Method Call : (BuildXmlElements) (Return Type : List<XElement>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolManager_BuildXmlElements_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodBuildXmlElementsPrametersTypes = new Type[] { typeof(bool), typeof(bool), typeof(IEnumerable<DataRow>), typeof(List<SPField>), typeof(DataColumnCollection), typeof(DataTable), typeof(Dictionary<string, object[]>) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolManagerInstance, MethodBuildXmlElements, Fixture, methodBuildXmlElementsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodBuildXmlElementsPrametersTypes.Length.ShouldBe(7);
        }

        #endregion

        #region Method Call : (BuildXmlElements) (Return Type : List<XElement>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolManager_BuildXmlElements_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBuildXmlElementsPrametersTypes = new Type[] { typeof(bool), typeof(bool), typeof(IEnumerable<DataRow>), typeof(List<SPField>), typeof(DataColumnCollection), typeof(DataTable), typeof(Dictionary<string, object[]>) };
            const int parametersCount = 7;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolManagerInstance, MethodBuildXmlElements, Fixture, methodBuildXmlElementsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildXmlElementsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildXmlElements) (Return Type : List<XElement>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolManager_BuildXmlElements_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildXmlElements, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcePoolManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BuildXmlElements) (Return Type : List<XElement>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolManager_BuildXmlElements_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBuildXmlElements, 0);
            const int parametersCount = 7;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAllFromReportingDB) (Return Type : XDocument) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePoolManager_GetAllFromReportingDB_Method_Call_Internally(Type[] types)
        {
            var methodGetAllFromReportingDBPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolManagerInstance, MethodGetAllFromReportingDB, Fixture, methodGetAllFromReportingDBPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAllFromReportingDB) (Return Type : XDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolManager_GetAllFromReportingDB_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var includeHidden = CreateType<bool>();
            var includeReadOnly = CreateType<bool>();
            var methodGetAllFromReportingDBPrametersTypes = new Type[] { typeof(bool), typeof(bool) };
            object[] parametersOfGetAllFromReportingDB = { includeHidden, includeReadOnly };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetAllFromReportingDB, methodGetAllFromReportingDBPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResourcePoolManager, XDocument>(_resourcePoolManagerInstanceFixture, out exception1, parametersOfGetAllFromReportingDB);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResourcePoolManager, XDocument>(_resourcePoolManagerInstance, MethodGetAllFromReportingDB, parametersOfGetAllFromReportingDB, methodGetAllFromReportingDBPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetAllFromReportingDB.ShouldNotBeNull();
            parametersOfGetAllFromReportingDB.Length.ShouldBe(2);
            methodGetAllFromReportingDBPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(() => methodInfo.Invoke(_resourcePoolManagerInstanceFixture, parametersOfGetAllFromReportingDB));
        }

        #endregion

        #region Method Call : (GetAllFromReportingDB) (Return Type : XDocument) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolManager_GetAllFromReportingDB_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var includeHidden = CreateType<bool>();
            var includeReadOnly = CreateType<bool>();
            var methodGetAllFromReportingDBPrametersTypes = new Type[] { typeof(bool), typeof(bool) };
            object[] parametersOfGetAllFromReportingDB = { includeHidden, includeReadOnly };

            // Assert
            parametersOfGetAllFromReportingDB.ShouldNotBeNull();
            parametersOfGetAllFromReportingDB.Length.ShouldBe(2);
            methodGetAllFromReportingDBPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<ResourcePoolManager, XDocument>(_resourcePoolManagerInstance, MethodGetAllFromReportingDB, parametersOfGetAllFromReportingDB, methodGetAllFromReportingDBPrametersTypes));
        }

        #endregion

        #region Method Call : (GetAllFromReportingDB) (Return Type : XDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolManager_GetAllFromReportingDB_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetAllFromReportingDBPrametersTypes = new Type[] { typeof(bool), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolManagerInstance, MethodGetAllFromReportingDB, Fixture, methodGetAllFromReportingDBPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetAllFromReportingDBPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetAllFromReportingDB) (Return Type : XDocument) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolManager_GetAllFromReportingDB_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetAllFromReportingDBPrametersTypes = new Type[] { typeof(bool), typeof(bool) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolManagerInstance, MethodGetAllFromReportingDB, Fixture, methodGetAllFromReportingDBPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetAllFromReportingDBPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAllFromReportingDB) (Return Type : XDocument) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolManager_GetAllFromReportingDB_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetAllFromReportingDB, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcePoolManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAllFromReportingDB) (Return Type : XDocument) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolManager_GetAllFromReportingDB_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetAllFromReportingDB, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessHtmlValues) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePoolManager_ProcessHtmlValues_Method_Call_Internally(Type[] types)
        {
            var methodProcessHtmlValuesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolManagerInstance, MethodProcessHtmlValues, Fixture, methodProcessHtmlValuesPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessHtmlValues) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolManager_ProcessHtmlValues_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var elements = CreateType<IEnumerable<XElement>>();
            var valueDictionary = CreateType<Dictionary<string, object[]>>();
            var methodProcessHtmlValuesPrametersTypes = new Type[] { typeof(IEnumerable<XElement>), typeof(Dictionary<string, object[]>) };
            object[] parametersOfProcessHtmlValues = { elements, valueDictionary };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodProcessHtmlValues, methodProcessHtmlValuesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourcePoolManagerInstanceFixture, parametersOfProcessHtmlValues);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfProcessHtmlValues.ShouldNotBeNull();
            parametersOfProcessHtmlValues.Length.ShouldBe(2);
            methodProcessHtmlValuesPrametersTypes.Length.ShouldBe(2);
            methodProcessHtmlValuesPrametersTypes.Length.ShouldBe(parametersOfProcessHtmlValues.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ProcessHtmlValues) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolManager_ProcessHtmlValues_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var elements = CreateType<IEnumerable<XElement>>();
            var valueDictionary = CreateType<Dictionary<string, object[]>>();
            var methodProcessHtmlValuesPrametersTypes = new Type[] { typeof(IEnumerable<XElement>), typeof(Dictionary<string, object[]>) };
            object[] parametersOfProcessHtmlValues = { elements, valueDictionary };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourcePoolManagerInstance, MethodProcessHtmlValues, parametersOfProcessHtmlValues, methodProcessHtmlValuesPrametersTypes);

            // Assert
            parametersOfProcessHtmlValues.ShouldNotBeNull();
            parametersOfProcessHtmlValues.Length.ShouldBe(2);
            methodProcessHtmlValuesPrametersTypes.Length.ShouldBe(2);
            methodProcessHtmlValuesPrametersTypes.Length.ShouldBe(parametersOfProcessHtmlValues.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessHtmlValues) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolManager_ProcessHtmlValues_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodProcessHtmlValues, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessHtmlValues) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolManager_ProcessHtmlValues_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessHtmlValuesPrametersTypes = new Type[] { typeof(IEnumerable<XElement>), typeof(Dictionary<string, object[]>) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolManagerInstance, MethodProcessHtmlValues, Fixture, methodProcessHtmlValuesPrametersTypes);

            // Assert
            methodProcessHtmlValuesPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessHtmlValues) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolManager_ProcessHtmlValues_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessHtmlValues, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcePoolManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
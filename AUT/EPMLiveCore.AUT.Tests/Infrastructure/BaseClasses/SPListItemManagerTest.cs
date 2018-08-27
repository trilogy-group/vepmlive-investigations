using System;
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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Infrastructure.SPListItemManager" />)
    ///     and namespace <see cref="EPMLiveCore.Infrastructure"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class SPListItemManagerTest : AbstractBaseSetupTypedTest<SPListItemManager>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SPListItemManager) Initializer

        private const string PropertyBatchProcessLimit = "BatchProcessLimit";
        private const string PropertyParentList = "ParentList";
        private const string MethodAdd = "Add";
        private const string MethodDelete = "Delete";
        private const string MethodDispose = "Dispose";
        private const string MethodGetAll = "GetAll";
        private const string MethodItemExists = "ItemExists";
        private const string MethodGetCurrentResource = "GetCurrentResource";
        private const string MethodUpdate = "Update";
        private const string MethodGetFieldSpecialValues = "GetFieldSpecialValues";
        private const string MethodPerformBatchListOperation = "PerformBatchListOperation";
        private const string FieldElementName = "ElementName";
        private const string FieldRootElementName = "RootElementName";
        private const string Field_batchProcessLimit = "_batchProcessLimit";
        private Type _sPListItemManagerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private SPListItemManager _sPListItemManagerInstance;
        private SPListItemManager _sPListItemManagerInstanceFixture;

        #region General Initializer : Class (SPListItemManager) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SPListItemManager" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _sPListItemManagerInstanceType = typeof(SPListItemManager);
            _sPListItemManagerInstanceFixture = Create(true);
            _sPListItemManagerInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SPListItemManager)

        #region General Initializer : Class (SPListItemManager) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="SPListItemManager" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodAdd, 0)]
        [TestCase(MethodDelete, 0)]
        [TestCase(MethodDispose, 0)]
        [TestCase(MethodGetAll, 0)]
        [TestCase(MethodGetAll, 1)]
        [TestCase(MethodGetAll, 2)]
        [TestCase(MethodItemExists, 0)]
        [TestCase(MethodGetCurrentResource, 0)]
        [TestCase(MethodUpdate, 0)]
        [TestCase(MethodDelete, 1)]
        [TestCase(MethodDispose, 1)]
        [TestCase(MethodGetFieldSpecialValues, 0)]
        [TestCase(MethodPerformBatchListOperation, 0)]
        [TestCase(MethodPerformBatchListOperation, 1)]
        public void AUT_SPListItemManager_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_sPListItemManagerInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (SPListItemManager) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="SPListItemManager" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyBatchProcessLimit)]
        [TestCase(PropertyParentList)]
        public void AUT_SPListItemManager_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_sPListItemManagerInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (SPListItemManager) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="SPListItemManager" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldElementName)]
        [TestCase(FieldRootElementName)]
        [TestCase(Field_batchProcessLimit)]
        public void AUT_SPListItemManager_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_sPListItemManagerInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (SPListItemManager) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="SPListItemManager" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_SPListItemManager_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<SPListItemManager>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (SPListItemManager) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="SPListItemManager" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_SPListItemManager_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<SPListItemManager>(Fixture);
        }

        #endregion

        #region General Constructor : Class (SPListItemManager) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="SPListItemManager" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_SPListItemManager_Constructors_Explore_Verify_Test()
        {
            // Arrange
            var listName = CreateType<string>();
            var webId = CreateType<Guid>();
            var siteId = CreateType<Guid>();
            var rootElementName = CreateType<string>();
            var elementName = CreateType<string>();
            object[] parametersOfSPListItemManager = { listName, webId, siteId, rootElementName, elementName };
            var methodSPListItemManagerPrametersTypes = new Type[] { typeof(string), typeof(Guid), typeof(Guid), typeof(string), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_sPListItemManagerInstanceType, methodSPListItemManagerPrametersTypes, parametersOfSPListItemManager);
        }

        #endregion

        #region General Constructor : Class (SPListItemManager) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="SPListItemManager" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_SPListItemManager_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodSPListItemManagerPrametersTypes = new Type[] { typeof(string), typeof(Guid), typeof(Guid), typeof(string), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_sPListItemManagerInstanceType, Fixture, methodSPListItemManagerPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (SPListItemManager) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="SPListItemManager" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_SPListItemManager_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var listName = CreateType<string>();
            var webId = CreateType<Guid>();
            var siteId = CreateType<Guid>();
            object[] parametersOfSPListItemManager = { listName, webId, siteId };
            var methodSPListItemManagerPrametersTypes = new Type[] { typeof(string), typeof(Guid), typeof(Guid) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_sPListItemManagerInstanceType, methodSPListItemManagerPrametersTypes, parametersOfSPListItemManager);
        }

        #endregion

        #region General Constructor : Class (SPListItemManager) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="SPListItemManager" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_SPListItemManager_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodSPListItemManagerPrametersTypes = new Type[] { typeof(string), typeof(Guid), typeof(Guid) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_sPListItemManagerInstanceType, Fixture, methodSPListItemManagerPrametersTypes);
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (SPListItemManager) => Property (BatchProcessLimit) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SPListItemManager_Public_Class_BatchProcessLimit_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyBatchProcessLimit);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SPListItemManager) => Property (ParentList) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SPListItemManager_Public_Class_ParentList_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyParentList);

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

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="SPListItemManager" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodAdd)]
        [TestCase(MethodDelete)]
        [TestCase(MethodDispose)]
        [TestCase(MethodGetAll)]
        [TestCase(MethodItemExists)]
        [TestCase(MethodGetCurrentResource)]
        [TestCase(MethodUpdate)]
        [TestCase(MethodGetFieldSpecialValues)]
        [TestCase(MethodPerformBatchListOperation)]
        public void AUT_SPListItemManager_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<SPListItemManager>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Add) (Return Type : XDocument) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SPListItemManager_Add_Method_Call_Internally(Type[] types)
        {
            var methodAddPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sPListItemManagerInstance, MethodAdd, Fixture, methodAddPrametersTypes);
        }

        #endregion

        #region Method Call : (Add) (Return Type : XDocument) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_Add_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var serializedListItems = CreateType<XDocument>();
            Action executeAction = null;

            // Act
            executeAction = () => _sPListItemManagerInstance.Add(serializedListItems);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Add) (Return Type : XDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_Add_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var serializedListItems = CreateType<XDocument>();
            var methodAddPrametersTypes = new Type[] { typeof(XDocument) };
            object[] parametersOfAdd = { serializedListItems };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodAdd, methodAddPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<SPListItemManager, XDocument>(_sPListItemManagerInstanceFixture, out exception1, parametersOfAdd);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<SPListItemManager, XDocument>(_sPListItemManagerInstance, MethodAdd, parametersOfAdd, methodAddPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfAdd.ShouldNotBeNull();
            parametersOfAdd.Length.ShouldBe(1);
            methodAddPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_sPListItemManagerInstanceFixture, parametersOfAdd));
        }

        #endregion

        #region Method Call : (Add) (Return Type : XDocument) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_Add_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var serializedListItems = CreateType<XDocument>();
            var methodAddPrametersTypes = new Type[] { typeof(XDocument) };
            object[] parametersOfAdd = { serializedListItems };

            // Assert
            parametersOfAdd.ShouldNotBeNull();
            parametersOfAdd.Length.ShouldBe(1);
            methodAddPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<SPListItemManager, XDocument>(_sPListItemManagerInstance, MethodAdd, parametersOfAdd, methodAddPrametersTypes));
        }

        #endregion

        #region Method Call : (Add) (Return Type : XDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_Add_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodAddPrametersTypes = new Type[] { typeof(XDocument) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sPListItemManagerInstance, MethodAdd, Fixture, methodAddPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodAddPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Add) (Return Type : XDocument) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_Add_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddPrametersTypes = new Type[] { typeof(XDocument) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sPListItemManagerInstance, MethodAdd, Fixture, methodAddPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAddPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Add) (Return Type : XDocument) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_Add_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAdd, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_sPListItemManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Add) (Return Type : XDocument) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_Add_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAdd, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : XDocument) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SPListItemManager_Delete_Method_Call_Internally(Type[] types)
        {
            var methodDeletePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sPListItemManagerInstance, MethodDelete, Fixture, methodDeletePrametersTypes);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : XDocument) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_Delete_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var serializedListItems = CreateType<XDocument>();
            Action executeAction = null;

            // Act
            executeAction = () => _sPListItemManagerInstance.Delete(serializedListItems);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : XDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_Delete_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var serializedListItems = CreateType<XDocument>();
            var methodDeletePrametersTypes = new Type[] { typeof(XDocument) };
            object[] parametersOfDelete = { serializedListItems };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDelete, methodDeletePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<SPListItemManager, XDocument>(_sPListItemManagerInstanceFixture, out exception1, parametersOfDelete);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<SPListItemManager, XDocument>(_sPListItemManagerInstance, MethodDelete, parametersOfDelete, methodDeletePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfDelete.ShouldNotBeNull();
            parametersOfDelete.Length.ShouldBe(1);
            methodDeletePrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_sPListItemManagerInstanceFixture, parametersOfDelete));
        }

        #endregion

        #region Method Call : (Delete) (Return Type : XDocument) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_Delete_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var serializedListItems = CreateType<XDocument>();
            var methodDeletePrametersTypes = new Type[] { typeof(XDocument) };
            object[] parametersOfDelete = { serializedListItems };

            // Assert
            parametersOfDelete.ShouldNotBeNull();
            parametersOfDelete.Length.ShouldBe(1);
            methodDeletePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<SPListItemManager, XDocument>(_sPListItemManagerInstance, MethodDelete, parametersOfDelete, methodDeletePrametersTypes));
        }

        #endregion

        #region Method Call : (Delete) (Return Type : XDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_Delete_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodDeletePrametersTypes = new Type[] { typeof(XDocument) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sPListItemManagerInstance, MethodDelete, Fixture, methodDeletePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodDeletePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : XDocument) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_Delete_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeletePrametersTypes = new Type[] { typeof(XDocument) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sPListItemManagerInstance, MethodDelete, Fixture, methodDeletePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeletePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : XDocument) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_Delete_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDelete, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_sPListItemManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Delete) (Return Type : XDocument) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_Delete_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDelete, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SPListItemManager_Dispose_Method_Call_Internally(Type[] types)
        {
            var methodDisposePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sPListItemManagerInstance, MethodDispose, Fixture, methodDisposePrametersTypes);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_Dispose_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _sPListItemManagerInstance.Dispose();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_Dispose_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodDisposePrametersTypes = null;
            object[] parametersOfDispose = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDispose, methodDisposePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_sPListItemManagerInstanceFixture, parametersOfDispose);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDispose.ShouldBeNull();
            methodDisposePrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_Dispose_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodDisposePrametersTypes = null;
            object[] parametersOfDispose = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_sPListItemManagerInstance, MethodDispose, parametersOfDispose, methodDisposePrametersTypes);

            // Assert
            parametersOfDispose.ShouldBeNull();
            methodDisposePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_Dispose_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodDisposePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sPListItemManagerInstance, MethodDispose, Fixture, methodDisposePrametersTypes);

            // Assert
            methodDisposePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_Dispose_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDispose, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_sPListItemManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAll) (Return Type : XDocument) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SPListItemManager_GetAll_Method_Call_Internally(Type[] types)
        {
            var methodGetAllPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sPListItemManagerInstance, MethodGetAll, Fixture, methodGetAllPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAll) (Return Type : XDocument) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_GetAll_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _sPListItemManagerInstance.GetAll();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetAll) (Return Type : XDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_GetAll_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetAllPrametersTypes = null;
            object[] parametersOfGetAll = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetAll, methodGetAllPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<SPListItemManager, XDocument>(_sPListItemManagerInstanceFixture, out exception1, parametersOfGetAll);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<SPListItemManager, XDocument>(_sPListItemManagerInstance, MethodGetAll, parametersOfGetAll, methodGetAllPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetAll.ShouldBeNull();
            methodGetAllPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(() => methodInfo.Invoke(_sPListItemManagerInstanceFixture, parametersOfGetAll));
        }

        #endregion

        #region Method Call : (GetAll) (Return Type : XDocument) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_GetAll_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetAllPrametersTypes = null;
            object[] parametersOfGetAll = null; // no parameter present

            // Assert
            parametersOfGetAll.ShouldBeNull();
            methodGetAllPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<SPListItemManager, XDocument>(_sPListItemManagerInstance, MethodGetAll, parametersOfGetAll, methodGetAllPrametersTypes));
        }

        #endregion

        #region Method Call : (GetAll) (Return Type : XDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_GetAll_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetAllPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sPListItemManagerInstance, MethodGetAll, Fixture, methodGetAllPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetAllPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAll) (Return Type : XDocument) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_GetAll_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetAllPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sPListItemManagerInstance, MethodGetAll, Fixture, methodGetAllPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetAllPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAll) (Return Type : XDocument) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_GetAll_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetAll, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_sPListItemManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAll) (Return Type : XDocument) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SPListItemManager_GetAll_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodGetAllPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sPListItemManagerInstance, MethodGetAll, Fixture, methodGetAllPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAll) (Return Type : XDocument) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_GetAll_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var includeHidden = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _sPListItemManagerInstance.GetAll(includeHidden);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetAll) (Return Type : XDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_GetAll_Method_Call_Overloading_Of_1_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var includeHidden = CreateType<bool>();
            var methodGetAllPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfGetAll = { includeHidden };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetAll, methodGetAllPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<SPListItemManager, XDocument>(_sPListItemManagerInstanceFixture, out exception1, parametersOfGetAll);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<SPListItemManager, XDocument>(_sPListItemManagerInstance, MethodGetAll, parametersOfGetAll, methodGetAllPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetAll.ShouldNotBeNull();
            parametersOfGetAll.Length.ShouldBe(1);
            methodGetAllPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_sPListItemManagerInstanceFixture, parametersOfGetAll));
        }

        #endregion

        #region Method Call : (GetAll) (Return Type : XDocument) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_GetAll_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var includeHidden = CreateType<bool>();
            var methodGetAllPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfGetAll = { includeHidden };

            // Assert
            parametersOfGetAll.ShouldNotBeNull();
            parametersOfGetAll.Length.ShouldBe(1);
            methodGetAllPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<SPListItemManager, XDocument>(_sPListItemManagerInstance, MethodGetAll, parametersOfGetAll, methodGetAllPrametersTypes));
        }

        #endregion

        #region Method Call : (GetAll) (Return Type : XDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_GetAll_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetAllPrametersTypes = new Type[] { typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sPListItemManagerInstance, MethodGetAll, Fixture, methodGetAllPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetAllPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetAll) (Return Type : XDocument) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_GetAll_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetAllPrametersTypes = new Type[] { typeof(bool) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sPListItemManagerInstance, MethodGetAll, Fixture, methodGetAllPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetAllPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAll) (Return Type : XDocument) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_GetAll_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetAll, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_sPListItemManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAll) (Return Type : XDocument) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_GetAll_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetAll, 1);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAll) (Return Type : XDocument) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SPListItemManager_GetAll_Method_Overloading_Of_2_Call_Internally(Type[] types)
        {
            var methodGetAllPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sPListItemManagerInstance, MethodGetAll, Fixture, methodGetAllPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAll) (Return Type : XDocument) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_GetAll_Method_DirectCall_Overloading_Of_2_Throw_Exception_Test()
        {
            // Arrange
            var includeHidden = CreateType<bool>();
            var includeReadOnly = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _sPListItemManagerInstance.GetAll(includeHidden, includeReadOnly);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetAll) (Return Type : XDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_GetAll_Method_Call_Overloading_Of_2_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var includeHidden = CreateType<bool>();
            var includeReadOnly = CreateType<bool>();
            var methodGetAllPrametersTypes = new Type[] { typeof(bool), typeof(bool) };
            object[] parametersOfGetAll = { includeHidden, includeReadOnly };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetAll, methodGetAllPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<SPListItemManager, XDocument>(_sPListItemManagerInstanceFixture, out exception1, parametersOfGetAll);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<SPListItemManager, XDocument>(_sPListItemManagerInstance, MethodGetAll, parametersOfGetAll, methodGetAllPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetAll.ShouldNotBeNull();
            parametersOfGetAll.Length.ShouldBe(2);
            methodGetAllPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(() => methodInfo.Invoke(_sPListItemManagerInstanceFixture, parametersOfGetAll));
        }

        #endregion

        #region Method Call : (GetAll) (Return Type : XDocument) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_GetAll_Method_Call_Overloading_Of_2_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
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
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<SPListItemManager, XDocument>(_sPListItemManagerInstance, MethodGetAll, parametersOfGetAll, methodGetAllPrametersTypes));
        }

        #endregion

        #region Method Call : (GetAll) (Return Type : XDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_GetAll_Method_Call_Overloading_Of_2_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetAllPrametersTypes = new Type[] { typeof(bool), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sPListItemManagerInstance, MethodGetAll, Fixture, methodGetAllPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetAllPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetAll) (Return Type : XDocument) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_GetAll_Method_Call_Overloading_Of_2_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetAllPrametersTypes = new Type[] { typeof(bool), typeof(bool) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sPListItemManagerInstance, MethodGetAll, Fixture, methodGetAllPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetAllPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAll) (Return Type : XDocument) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_GetAll_Method_Call_Overloading_Of_2_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetAll, 2);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_sPListItemManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAll) (Return Type : XDocument) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_GetAll_Method_Call_Overloading_Of_2_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetAll, 2);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ItemExists) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SPListItemManager_ItemExists_Method_Call_Internally(Type[] types)
        {
            var methodItemExistsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sPListItemManagerInstance, MethodItemExists, Fixture, methodItemExistsPrametersTypes);
        }

        #endregion

        #region Method Call : (ItemExists) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_ItemExists_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var id = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _sPListItemManagerInstance.ItemExists(id);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ItemExists) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_ItemExists_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var id = CreateType<int>();
            var methodItemExistsPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfItemExists = { id };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodItemExists, methodItemExistsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<SPListItemManager, bool>(_sPListItemManagerInstanceFixture, out exception1, parametersOfItemExists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<SPListItemManager, bool>(_sPListItemManagerInstance, MethodItemExists, parametersOfItemExists, methodItemExistsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfItemExists.ShouldNotBeNull();
            parametersOfItemExists.Length.ShouldBe(1);
            methodItemExistsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_sPListItemManagerInstanceFixture, parametersOfItemExists));
        }

        #endregion

        #region Method Call : (ItemExists) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_ItemExists_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var id = CreateType<int>();
            var methodItemExistsPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfItemExists = { id };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodItemExists, methodItemExistsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<SPListItemManager, bool>(_sPListItemManagerInstanceFixture, out exception1, parametersOfItemExists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<SPListItemManager, bool>(_sPListItemManagerInstance, MethodItemExists, parametersOfItemExists, methodItemExistsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfItemExists.ShouldNotBeNull();
            parametersOfItemExists.Length.ShouldBe(1);
            methodItemExistsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<SPListItemManager, bool>(_sPListItemManagerInstance, MethodItemExists, parametersOfItemExists, methodItemExistsPrametersTypes));
        }

        #endregion

        #region Method Call : (ItemExists) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_ItemExists_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var id = CreateType<int>();
            var methodItemExistsPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfItemExists = { id };

            // Assert
            parametersOfItemExists.ShouldNotBeNull();
            parametersOfItemExists.Length.ShouldBe(1);
            methodItemExistsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<SPListItemManager, bool>(_sPListItemManagerInstance, MethodItemExists, parametersOfItemExists, methodItemExistsPrametersTypes));
        }

        #endregion

        #region Method Call : (ItemExists) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_ItemExists_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodItemExistsPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sPListItemManagerInstance, MethodItemExists, Fixture, methodItemExistsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodItemExistsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ItemExists) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_ItemExists_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodItemExists, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_sPListItemManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ItemExists) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_ItemExists_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodItemExists, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCurrentResource) (Return Type : SPListItem) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SPListItemManager_GetCurrentResource_Method_Call_Internally(Type[] types)
        {
            var methodGetCurrentResourcePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sPListItemManagerInstance, MethodGetCurrentResource, Fixture, methodGetCurrentResourcePrametersTypes);
        }

        #endregion

        #region Method Call : (GetCurrentResource) (Return Type : SPListItem) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_GetCurrentResource_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var id = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _sPListItemManagerInstance.GetCurrentResource(id);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetCurrentResource) (Return Type : SPListItem) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_GetCurrentResource_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var id = CreateType<int>();
            var methodGetCurrentResourcePrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfGetCurrentResource = { id };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetCurrentResource, methodGetCurrentResourcePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<SPListItemManager, SPListItem>(_sPListItemManagerInstanceFixture, out exception1, parametersOfGetCurrentResource);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<SPListItemManager, SPListItem>(_sPListItemManagerInstance, MethodGetCurrentResource, parametersOfGetCurrentResource, methodGetCurrentResourcePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetCurrentResource.ShouldNotBeNull();
            parametersOfGetCurrentResource.Length.ShouldBe(1);
            methodGetCurrentResourcePrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_sPListItemManagerInstanceFixture, parametersOfGetCurrentResource));
        }

        #endregion

        #region Method Call : (GetCurrentResource) (Return Type : SPListItem) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_GetCurrentResource_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var id = CreateType<int>();
            var methodGetCurrentResourcePrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfGetCurrentResource = { id };

            // Assert
            parametersOfGetCurrentResource.ShouldNotBeNull();
            parametersOfGetCurrentResource.Length.ShouldBe(1);
            methodGetCurrentResourcePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<SPListItemManager, SPListItem>(_sPListItemManagerInstance, MethodGetCurrentResource, parametersOfGetCurrentResource, methodGetCurrentResourcePrametersTypes));
        }

        #endregion

        #region Method Call : (GetCurrentResource) (Return Type : SPListItem) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_GetCurrentResource_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCurrentResourcePrametersTypes = new Type[] { typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sPListItemManagerInstance, MethodGetCurrentResource, Fixture, methodGetCurrentResourcePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCurrentResourcePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetCurrentResource) (Return Type : SPListItem) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_GetCurrentResource_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCurrentResourcePrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sPListItemManagerInstance, MethodGetCurrentResource, Fixture, methodGetCurrentResourcePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCurrentResourcePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCurrentResource) (Return Type : SPListItem) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_GetCurrentResource_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCurrentResource, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_sPListItemManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCurrentResource) (Return Type : SPListItem) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_GetCurrentResource_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCurrentResource, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Update) (Return Type : XDocument) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SPListItemManager_Update_Method_Call_Internally(Type[] types)
        {
            var methodUpdatePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sPListItemManagerInstance, MethodUpdate, Fixture, methodUpdatePrametersTypes);
        }

        #endregion

        #region Method Call : (Update) (Return Type : XDocument) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_Update_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var serializedListItems = CreateType<XDocument>();
            Action executeAction = null;

            // Act
            executeAction = () => _sPListItemManagerInstance.Update(serializedListItems);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Update) (Return Type : XDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_Update_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var serializedListItems = CreateType<XDocument>();
            var methodUpdatePrametersTypes = new Type[] { typeof(XDocument) };
            object[] parametersOfUpdate = { serializedListItems };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdate, methodUpdatePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<SPListItemManager, XDocument>(_sPListItemManagerInstanceFixture, out exception1, parametersOfUpdate);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<SPListItemManager, XDocument>(_sPListItemManagerInstance, MethodUpdate, parametersOfUpdate, methodUpdatePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfUpdate.ShouldNotBeNull();
            parametersOfUpdate.Length.ShouldBe(1);
            methodUpdatePrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_sPListItemManagerInstanceFixture, parametersOfUpdate));
        }

        #endregion

        #region Method Call : (Update) (Return Type : XDocument) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_Update_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var serializedListItems = CreateType<XDocument>();
            var methodUpdatePrametersTypes = new Type[] { typeof(XDocument) };
            object[] parametersOfUpdate = { serializedListItems };

            // Assert
            parametersOfUpdate.ShouldNotBeNull();
            parametersOfUpdate.Length.ShouldBe(1);
            methodUpdatePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<SPListItemManager, XDocument>(_sPListItemManagerInstance, MethodUpdate, parametersOfUpdate, methodUpdatePrametersTypes));
        }

        #endregion

        #region Method Call : (Update) (Return Type : XDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_Update_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodUpdatePrametersTypes = new Type[] { typeof(XDocument) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sPListItemManagerInstance, MethodUpdate, Fixture, methodUpdatePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodUpdatePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Update) (Return Type : XDocument) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_Update_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdatePrametersTypes = new Type[] { typeof(XDocument) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sPListItemManagerInstance, MethodUpdate, Fixture, methodUpdatePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdatePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Update) (Return Type : XDocument) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_Update_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdate, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_sPListItemManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Update) (Return Type : XDocument) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_Update_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdate, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SPListItemManager_Delete_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodDeletePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sPListItemManagerInstance, MethodDelete, Fixture, methodDeletePrametersTypes);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_Delete_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var id = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _sPListItemManagerInstance.Delete(id);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_Delete_Method_Call_Void_Overloading_Of_1_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var id = CreateType<int>();
            var methodDeletePrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfDelete = { id };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDelete, methodDeletePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_sPListItemManagerInstanceFixture, parametersOfDelete);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDelete.ShouldNotBeNull();
            parametersOfDelete.Length.ShouldBe(1);
            methodDeletePrametersTypes.Length.ShouldBe(1);
            methodDeletePrametersTypes.Length.ShouldBe(parametersOfDelete.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_Delete_Method_Call_Void_Overloading_Of_1_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var id = CreateType<int>();
            var methodDeletePrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfDelete = { id };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_sPListItemManagerInstance, MethodDelete, parametersOfDelete, methodDeletePrametersTypes);

            // Assert
            parametersOfDelete.ShouldNotBeNull();
            parametersOfDelete.Length.ShouldBe(1);
            methodDeletePrametersTypes.Length.ShouldBe(1);
            methodDeletePrametersTypes.Length.ShouldBe(parametersOfDelete.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_Delete_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDelete, 1);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_Delete_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeletePrametersTypes = new Type[] { typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sPListItemManagerInstance, MethodDelete, Fixture, methodDeletePrametersTypes);

            // Assert
            methodDeletePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_Delete_Method_Call_Overloading_Of_1_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDelete, 1);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_sPListItemManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SPListItemManager_Dispose_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodDisposePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sPListItemManagerInstance, MethodDispose, Fixture, methodDisposePrametersTypes);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_Dispose_Method_Call_Void_Overloading_Of_1_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var disposing = CreateType<Boolean>();
            var methodDisposePrametersTypes = new Type[] { typeof(Boolean) };
            object[] parametersOfDispose = { disposing };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDispose, methodDisposePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_sPListItemManagerInstanceFixture, parametersOfDispose);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDispose.ShouldNotBeNull();
            parametersOfDispose.Length.ShouldBe(1);
            methodDisposePrametersTypes.Length.ShouldBe(1);
            methodDisposePrametersTypes.Length.ShouldBe(parametersOfDispose.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_Dispose_Method_Call_Void_Overloading_Of_1_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var disposing = CreateType<Boolean>();
            var methodDisposePrametersTypes = new Type[] { typeof(Boolean) };
            object[] parametersOfDispose = { disposing };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_sPListItemManagerInstance, MethodDispose, parametersOfDispose, methodDisposePrametersTypes);

            // Assert
            parametersOfDispose.ShouldNotBeNull();
            parametersOfDispose.Length.ShouldBe(1);
            methodDisposePrametersTypes.Length.ShouldBe(1);
            methodDisposePrametersTypes.Length.ShouldBe(parametersOfDispose.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_Dispose_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDispose, 1);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_Dispose_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDisposePrametersTypes = new Type[] { typeof(Boolean) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sPListItemManagerInstance, MethodDispose, Fixture, methodDisposePrametersTypes);

            // Assert
            methodDisposePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_Dispose_Method_Call_Overloading_Of_1_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDispose, 1);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_sPListItemManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFieldSpecialValues) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SPListItemManager_GetFieldSpecialValues_Method_Call_Internally(Type[] types)
        {
            var methodGetFieldSpecialValuesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sPListItemManagerInstance, MethodGetFieldSpecialValues, Fixture, methodGetFieldSpecialValuesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFieldSpecialValues) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_GetFieldSpecialValues_Method_Call_Void_With_6_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var spField = CreateType<SPField>();
            var stringValue = CreateType<string>();
            var value = CreateType<object>();
            var fieldEditValue = CreateType<string>();
            var fieldTextValue = CreateType<string>();
            var fieldHtmlValue = CreateType<string>();
            var methodGetFieldSpecialValuesPrametersTypes = new Type[] { typeof(SPField), typeof(string), typeof(object), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfGetFieldSpecialValues = { spField, stringValue, value, fieldEditValue, fieldTextValue, fieldHtmlValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetFieldSpecialValues, methodGetFieldSpecialValuesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_sPListItemManagerInstanceFixture, parametersOfGetFieldSpecialValues);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetFieldSpecialValues.ShouldNotBeNull();
            parametersOfGetFieldSpecialValues.Length.ShouldBe(6);
            methodGetFieldSpecialValuesPrametersTypes.Length.ShouldBe(6);
            methodGetFieldSpecialValuesPrametersTypes.Length.ShouldBe(parametersOfGetFieldSpecialValues.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetFieldSpecialValues) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_GetFieldSpecialValues_Method_Call_Void_With_6_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spField = CreateType<SPField>();
            var stringValue = CreateType<string>();
            var value = CreateType<object>();
            var fieldEditValue = CreateType<string>();
            var fieldTextValue = CreateType<string>();
            var fieldHtmlValue = CreateType<string>();
            var methodGetFieldSpecialValuesPrametersTypes = new Type[] { typeof(SPField), typeof(string), typeof(object), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfGetFieldSpecialValues = { spField, stringValue, value, fieldEditValue, fieldTextValue, fieldHtmlValue };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_sPListItemManagerInstance, MethodGetFieldSpecialValues, parametersOfGetFieldSpecialValues, methodGetFieldSpecialValuesPrametersTypes);

            // Assert
            parametersOfGetFieldSpecialValues.ShouldNotBeNull();
            parametersOfGetFieldSpecialValues.Length.ShouldBe(6);
            methodGetFieldSpecialValuesPrametersTypes.Length.ShouldBe(6);
            methodGetFieldSpecialValuesPrametersTypes.Length.ShouldBe(parametersOfGetFieldSpecialValues.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFieldSpecialValues) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_GetFieldSpecialValues_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFieldSpecialValues, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFieldSpecialValues) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_GetFieldSpecialValues_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFieldSpecialValuesPrametersTypes = new Type[] { typeof(SPField), typeof(string), typeof(object), typeof(string), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sPListItemManagerInstance, MethodGetFieldSpecialValues, Fixture, methodGetFieldSpecialValuesPrametersTypes);

            // Assert
            methodGetFieldSpecialValuesPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFieldSpecialValues) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_GetFieldSpecialValues_Method_Call_With_6_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFieldSpecialValues, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_sPListItemManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PerformBatchListOperation) (Return Type : XDocument) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SPListItemManager_PerformBatchListOperation_Method_Call_Internally(Type[] types)
        {
            var methodPerformBatchListOperationPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sPListItemManagerInstance, MethodPerformBatchListOperation, Fixture, methodPerformBatchListOperationPrametersTypes);
        }

        #endregion

        #region Method Call : (PerformBatchListOperation) (Return Type : XDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_PerformBatchListOperation_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var serializedListItems = CreateType<XDocument>();
            var command = CreateType<string>();
            var methodPerformBatchListOperationPrametersTypes = new Type[] { typeof(XDocument), typeof(string) };
            object[] parametersOfPerformBatchListOperation = { serializedListItems, command };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodPerformBatchListOperation, methodPerformBatchListOperationPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<SPListItemManager, XDocument>(_sPListItemManagerInstanceFixture, out exception1, parametersOfPerformBatchListOperation);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<SPListItemManager, XDocument>(_sPListItemManagerInstance, MethodPerformBatchListOperation, parametersOfPerformBatchListOperation, methodPerformBatchListOperationPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfPerformBatchListOperation.ShouldNotBeNull();
            parametersOfPerformBatchListOperation.Length.ShouldBe(2);
            methodPerformBatchListOperationPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(() => methodInfo.Invoke(_sPListItemManagerInstanceFixture, parametersOfPerformBatchListOperation));
        }

        #endregion

        #region Method Call : (PerformBatchListOperation) (Return Type : XDocument) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_PerformBatchListOperation_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var serializedListItems = CreateType<XDocument>();
            var command = CreateType<string>();
            var methodPerformBatchListOperationPrametersTypes = new Type[] { typeof(XDocument), typeof(string) };
            object[] parametersOfPerformBatchListOperation = { serializedListItems, command };

            // Assert
            parametersOfPerformBatchListOperation.ShouldNotBeNull();
            parametersOfPerformBatchListOperation.Length.ShouldBe(2);
            methodPerformBatchListOperationPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<SPListItemManager, XDocument>(_sPListItemManagerInstance, MethodPerformBatchListOperation, parametersOfPerformBatchListOperation, methodPerformBatchListOperationPrametersTypes));
        }

        #endregion

        #region Method Call : (PerformBatchListOperation) (Return Type : XDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_PerformBatchListOperation_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodPerformBatchListOperationPrametersTypes = new Type[] { typeof(XDocument), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sPListItemManagerInstance, MethodPerformBatchListOperation, Fixture, methodPerformBatchListOperationPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodPerformBatchListOperationPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (PerformBatchListOperation) (Return Type : XDocument) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_PerformBatchListOperation_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPerformBatchListOperationPrametersTypes = new Type[] { typeof(XDocument), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sPListItemManagerInstance, MethodPerformBatchListOperation, Fixture, methodPerformBatchListOperationPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodPerformBatchListOperationPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PerformBatchListOperation) (Return Type : XDocument) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_PerformBatchListOperation_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPerformBatchListOperation, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_sPListItemManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PerformBatchListOperation) (Return Type : XDocument) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_PerformBatchListOperation_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPerformBatchListOperation, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PerformBatchListOperation) (Return Type : XDocument) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SPListItemManager_PerformBatchListOperation_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodPerformBatchListOperationPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sPListItemManagerInstance, MethodPerformBatchListOperation, Fixture, methodPerformBatchListOperationPrametersTypes);
        }

        #endregion

        #region Method Call : (PerformBatchListOperation) (Return Type : XDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_PerformBatchListOperation_Method_Call_Overloading_Of_1_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var serializedListItems = CreateType<XDocument>();
            var command = CreateType<string>();
            var createNew = CreateType<bool>();
            var methodPerformBatchListOperationPrametersTypes = new Type[] { typeof(XDocument), typeof(string), typeof(bool) };
            object[] parametersOfPerformBatchListOperation = { serializedListItems, command, createNew };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodPerformBatchListOperation, methodPerformBatchListOperationPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<SPListItemManager, XDocument>(_sPListItemManagerInstanceFixture, out exception1, parametersOfPerformBatchListOperation);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<SPListItemManager, XDocument>(_sPListItemManagerInstance, MethodPerformBatchListOperation, parametersOfPerformBatchListOperation, methodPerformBatchListOperationPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfPerformBatchListOperation.ShouldNotBeNull();
            parametersOfPerformBatchListOperation.Length.ShouldBe(3);
            methodPerformBatchListOperationPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(() => methodInfo.Invoke(_sPListItemManagerInstanceFixture, parametersOfPerformBatchListOperation));
        }

        #endregion

        #region Method Call : (PerformBatchListOperation) (Return Type : XDocument) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_PerformBatchListOperation_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var serializedListItems = CreateType<XDocument>();
            var command = CreateType<string>();
            var createNew = CreateType<bool>();
            var methodPerformBatchListOperationPrametersTypes = new Type[] { typeof(XDocument), typeof(string), typeof(bool) };
            object[] parametersOfPerformBatchListOperation = { serializedListItems, command, createNew };

            // Assert
            parametersOfPerformBatchListOperation.ShouldNotBeNull();
            parametersOfPerformBatchListOperation.Length.ShouldBe(3);
            methodPerformBatchListOperationPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<SPListItemManager, XDocument>(_sPListItemManagerInstance, MethodPerformBatchListOperation, parametersOfPerformBatchListOperation, methodPerformBatchListOperationPrametersTypes));
        }

        #endregion

        #region Method Call : (PerformBatchListOperation) (Return Type : XDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_PerformBatchListOperation_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodPerformBatchListOperationPrametersTypes = new Type[] { typeof(XDocument), typeof(string), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sPListItemManagerInstance, MethodPerformBatchListOperation, Fixture, methodPerformBatchListOperationPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodPerformBatchListOperationPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (PerformBatchListOperation) (Return Type : XDocument) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_PerformBatchListOperation_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPerformBatchListOperationPrametersTypes = new Type[] { typeof(XDocument), typeof(string), typeof(bool) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sPListItemManagerInstance, MethodPerformBatchListOperation, Fixture, methodPerformBatchListOperationPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodPerformBatchListOperationPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PerformBatchListOperation) (Return Type : XDocument) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_PerformBatchListOperation_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPerformBatchListOperation, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_sPListItemManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PerformBatchListOperation) (Return Type : XDocument) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPListItemManager_PerformBatchListOperation_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPerformBatchListOperation, 1);
            const int parametersCount = 3;

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
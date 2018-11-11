using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Web.UI.WebControls;
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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.ReportHelper.ListBiz" />)
    ///     and namespace <see cref="EPMLiveCore.ReportHelper"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class ListBizTest : AbstractBaseSetupTypedTest<ListBiz>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ListBiz) Initializer

        private const string PropertyResourceList = "ResourceList";
        private const string PropertySystem = "System";
        private const string PropertyListName = "ListName";
        private const string MethodPopulateInstance = "PopulateInstance";
        private const string MethodUpdateListMapping = "UpdateListMapping";
        private const string MethodCreateNewMapping = "CreateNewMapping";
        private const string MethodFieldExistsInCollection = "FieldExistsInCollection";
        private const string MethodCreate = "Create";
        private const string MethodUpdate = "Update";
        private const string MethodDelete = "Delete";
        private const string MethodGetLog = "GetLog";
        private const string MethodClearLog = "ClearLog";
        private const string MethodGetMaximumLogLevel = "GetMaximumLogLevel";
        private const string MethodGetMappedFieldsStrings = "GetMappedFieldsStrings";
        private const string MethodGetMappedFields = "GetMappedFields";
        private const string MethodSetResourceListFlag = "SetResourceListFlag";
        private const string MethodSnapshot = "Snapshot";
        private const string MethodRegisterEvent = "RegisterEvent";
        private const string MethodGetListEvents = "GetListEvents";
        private const string MethodRemoveEvent = "RemoveEvent";
        private const string FieldAutomaticFields = "AutomaticFields";
        private const string FieldRequiredResourceFields = "RequiredResourceFields";
        private const string Field_listId = "_listId";
        private const string Field_listName = "_listName";
        private const string Field_resourceList = "_resourceList";
        private const string Field_siteId = "_siteId";
        private const string Field_system = "_system";
        private const string Field_tableName = "_tableName";
        private const string Field_tableNameSnapshot = "_tableNameSnapshot";
        private Type _listBizInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ListBiz _listBizInstance;
        private ListBiz _listBizInstanceFixture;

        #region General Initializer : Class (ListBiz) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ListBiz" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _listBizInstanceType = typeof(ListBiz);
            _listBizInstanceFixture = Create(true);
            _listBizInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ListBiz)

        #region General Initializer : Class (ListBiz) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ListBiz" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPopulateInstance, 0)]
        [TestCase(MethodUpdateListMapping, 0)]
        [TestCase(MethodUpdateListMapping, 1)]
        [TestCase(MethodCreateNewMapping, 0)]
        [TestCase(MethodCreateNewMapping, 1)]
        [TestCase(MethodFieldExistsInCollection, 0)]
        [TestCase(MethodCreate, 0)]
        [TestCase(MethodCreate, 1)]
        [TestCase(MethodUpdate, 0)]
        [TestCase(MethodDelete, 0)]
        [TestCase(MethodGetLog, 0)]
        [TestCase(MethodClearLog, 0)]
        [TestCase(MethodGetMaximumLogLevel, 0)]
        [TestCase(MethodGetMappedFieldsStrings, 0)]
        [TestCase(MethodGetMappedFields, 0)]
        [TestCase(MethodSetResourceListFlag, 0)]
        [TestCase(MethodSnapshot, 0)]
        [TestCase(MethodRegisterEvent, 0)]
        [TestCase(MethodGetListEvents, 0)]
        [TestCase(MethodRemoveEvent, 0)]
        public void AUT_ListBiz_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_listBizInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ListBiz) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ListBiz" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyResourceList)]
        [TestCase(PropertySystem)]
        [TestCase(PropertyListName)]
        public void AUT_ListBiz_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_listBizInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ListBiz) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ListBiz" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldAutomaticFields)]
        [TestCase(FieldRequiredResourceFields)]
        [TestCase(Field_listId)]
        [TestCase(Field_listName)]
        [TestCase(Field_resourceList)]
        [TestCase(Field_siteId)]
        [TestCase(Field_system)]
        [TestCase(Field_tableName)]
        [TestCase(Field_tableNameSnapshot)]
        public void AUT_ListBiz_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_listBizInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ListBiz) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="ListBiz" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        public void AUT_ListBiz_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<ListBiz>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (ListBiz) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="ListBiz" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ListBiz_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<ListBiz>(Fixture);
        }

        #endregion

        #region General Constructor : Class (ListBiz) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ListBiz" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ListBiz_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var siteId = CreateType<Guid>();
            object[] parametersOfListBiz = { listId, siteId };
            var methodListBizPrametersTypes = new Type[] { typeof(Guid), typeof(Guid) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_listBizInstanceType, methodListBizPrametersTypes, parametersOfListBiz);
        }

        #endregion

        #region General Constructor : Class (ListBiz) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ListBiz" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ListBiz_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodListBizPrametersTypes = new Type[] { typeof(Guid), typeof(Guid) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_listBizInstanceType, Fixture, methodListBizPrametersTypes);
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ListBiz) => Property (ListName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ListBiz_Public_Class_ListName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyListName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ListBiz) => Property (ResourceList) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ListBiz_Public_Class_ResourceList_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyResourceList);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ListBiz) => Property (System) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ListBiz_Public_Class_System_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySystem);

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
        ///     Class (<see cref="ListBiz" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodCreateNewMapping)]
        [TestCase(MethodFieldExistsInCollection)]
        public void AUT_ListBiz_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_listBizInstanceFixture,
                                                                              _listBizInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ListBiz" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPopulateInstance)]
        [TestCase(MethodUpdateListMapping)]
        [TestCase(MethodCreate)]
        [TestCase(MethodUpdate)]
        [TestCase(MethodDelete)]
        [TestCase(MethodGetLog)]
        [TestCase(MethodClearLog)]
        [TestCase(MethodGetMaximumLogLevel)]
        [TestCase(MethodGetMappedFieldsStrings)]
        [TestCase(MethodGetMappedFields)]
        [TestCase(MethodSetResourceListFlag)]
        [TestCase(MethodSnapshot)]
        [TestCase(MethodRegisterEvent)]
        [TestCase(MethodGetListEvents)]
        [TestCase(MethodRemoveEvent)]
        public void AUT_ListBiz_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ListBiz>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (PopulateInstance) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListBiz_PopulateInstance_Method_Call_Internally(Type[] types)
        {
            var methodPopulateInstancePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listBizInstance, MethodPopulateInstance, Fixture, methodPopulateInstancePrametersTypes);
        }

        #endregion

        #region Method Call : (PopulateInstance) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_PopulateInstance_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var row = CreateType<DataRow>();
            var methodPopulateInstancePrametersTypes = new Type[] { typeof(DataRow) };
            object[] parametersOfPopulateInstance = { row };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPopulateInstance, methodPopulateInstancePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listBizInstanceFixture, parametersOfPopulateInstance);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPopulateInstance.ShouldNotBeNull();
            parametersOfPopulateInstance.Length.ShouldBe(1);
            methodPopulateInstancePrametersTypes.Length.ShouldBe(1);
            methodPopulateInstancePrametersTypes.Length.ShouldBe(parametersOfPopulateInstance.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (PopulateInstance) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_PopulateInstance_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var row = CreateType<DataRow>();
            var methodPopulateInstancePrametersTypes = new Type[] { typeof(DataRow) };
            object[] parametersOfPopulateInstance = { row };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listBizInstance, MethodPopulateInstance, parametersOfPopulateInstance, methodPopulateInstancePrametersTypes);

            // Assert
            parametersOfPopulateInstance.ShouldNotBeNull();
            parametersOfPopulateInstance.Length.ShouldBe(1);
            methodPopulateInstancePrametersTypes.Length.ShouldBe(1);
            methodPopulateInstancePrametersTypes.Length.ShouldBe(parametersOfPopulateInstance.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateInstance) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_PopulateInstance_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPopulateInstance, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PopulateInstance) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_PopulateInstance_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPopulateInstancePrametersTypes = new Type[] { typeof(DataRow) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listBizInstance, MethodPopulateInstance, Fixture, methodPopulateInstancePrametersTypes);

            // Assert
            methodPopulateInstancePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateInstance) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_PopulateInstance_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPopulateInstance, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listBizInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateListMapping) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListBiz_UpdateListMapping_Method_Call_Internally(Type[] types)
        {
            var methodUpdateListMappingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listBizInstance, MethodUpdateListMapping, Fixture, methodUpdateListMappingPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateListMapping) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_UpdateListMapping_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var fields = CreateType<ListItemCollection>();
            Action executeAction = null;

            // Act
            executeAction = () => _listBizInstance.UpdateListMapping(fields);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateListMapping) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_UpdateListMapping_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var fields = CreateType<ListItemCollection>();
            var methodUpdateListMappingPrametersTypes = new Type[] { typeof(ListItemCollection) };
            object[] parametersOfUpdateListMapping = { fields };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateListMapping, methodUpdateListMappingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listBizInstanceFixture, parametersOfUpdateListMapping);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateListMapping.ShouldNotBeNull();
            parametersOfUpdateListMapping.Length.ShouldBe(1);
            methodUpdateListMappingPrametersTypes.Length.ShouldBe(1);
            methodUpdateListMappingPrametersTypes.Length.ShouldBe(parametersOfUpdateListMapping.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateListMapping) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_UpdateListMapping_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var fields = CreateType<ListItemCollection>();
            var methodUpdateListMappingPrametersTypes = new Type[] { typeof(ListItemCollection) };
            object[] parametersOfUpdateListMapping = { fields };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listBizInstance, MethodUpdateListMapping, parametersOfUpdateListMapping, methodUpdateListMappingPrametersTypes);

            // Assert
            parametersOfUpdateListMapping.ShouldNotBeNull();
            parametersOfUpdateListMapping.Length.ShouldBe(1);
            methodUpdateListMappingPrametersTypes.Length.ShouldBe(1);
            methodUpdateListMappingPrametersTypes.Length.ShouldBe(parametersOfUpdateListMapping.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateListMapping) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_UpdateListMapping_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateListMapping, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateListMapping) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_UpdateListMapping_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateListMappingPrametersTypes = new Type[] { typeof(ListItemCollection) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listBizInstance, MethodUpdateListMapping, Fixture, methodUpdateListMappingPrametersTypes);

            // Assert
            methodUpdateListMappingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateListMapping) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_UpdateListMapping_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateListMapping, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listBizInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateListMapping) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListBiz_UpdateListMapping_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodUpdateListMappingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listBizInstance, MethodUpdateListMapping, Fixture, methodUpdateListMappingPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateListMapping) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_UpdateListMapping_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var newfieldId = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => _listBizInstance.UpdateListMapping(newfieldId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateListMapping) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_UpdateListMapping_Method_Call_Void_Overloading_Of_1_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var newfieldId = CreateType<Guid>();
            var methodUpdateListMappingPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfUpdateListMapping = { newfieldId };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateListMapping, methodUpdateListMappingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listBizInstanceFixture, parametersOfUpdateListMapping);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateListMapping.ShouldNotBeNull();
            parametersOfUpdateListMapping.Length.ShouldBe(1);
            methodUpdateListMappingPrametersTypes.Length.ShouldBe(1);
            methodUpdateListMappingPrametersTypes.Length.ShouldBe(parametersOfUpdateListMapping.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateListMapping) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_UpdateListMapping_Method_Call_Void_Overloading_Of_1_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var newfieldId = CreateType<Guid>();
            var methodUpdateListMappingPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfUpdateListMapping = { newfieldId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listBizInstance, MethodUpdateListMapping, parametersOfUpdateListMapping, methodUpdateListMappingPrametersTypes);

            // Assert
            parametersOfUpdateListMapping.ShouldNotBeNull();
            parametersOfUpdateListMapping.Length.ShouldBe(1);
            methodUpdateListMappingPrametersTypes.Length.ShouldBe(1);
            methodUpdateListMappingPrametersTypes.Length.ShouldBe(parametersOfUpdateListMapping.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateListMapping) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_UpdateListMapping_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateListMapping, 1);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateListMapping) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_UpdateListMapping_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateListMappingPrametersTypes = new Type[] { typeof(Guid) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listBizInstance, MethodUpdateListMapping, Fixture, methodUpdateListMappingPrametersTypes);

            // Assert
            methodUpdateListMappingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateListMapping) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_UpdateListMapping_Method_Call_Overloading_Of_1_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateListMapping, 1);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listBizInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateNewMapping) (Return Type : ListBiz) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListBiz_CreateNewMapping_Static_Method_Call_Internally(Type[] types)
        {
            var methodCreateNewMappingPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listBizInstanceFixture, _listBizInstanceType, MethodCreateNewMapping, Fixture, methodCreateNewMappingPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateNewMapping) (Return Type : ListBiz) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_CreateNewMapping_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var listId = CreateType<Guid>();
            var fields = CreateType<ListItemCollection>();
            var isAuto = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => ListBiz.CreateNewMapping(siteId, listId, fields, isAuto);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CreateNewMapping) (Return Type : ListBiz) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_CreateNewMapping_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var listId = CreateType<Guid>();
            var fields = CreateType<ListItemCollection>();
            var isAuto = CreateType<bool>();
            var methodCreateNewMappingPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(ListItemCollection), typeof(bool) };
            object[] parametersOfCreateNewMapping = { siteId, listId, fields, isAuto };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateNewMapping, methodCreateNewMappingPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listBizInstanceFixture, _listBizInstanceType, MethodCreateNewMapping, Fixture, methodCreateNewMappingPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<ListBiz>(_listBizInstanceFixture, _listBizInstanceType, MethodCreateNewMapping, parametersOfCreateNewMapping, methodCreateNewMappingPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_listBizInstanceFixture, parametersOfCreateNewMapping);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfCreateNewMapping.ShouldNotBeNull();
            parametersOfCreateNewMapping.Length.ShouldBe(4);
            methodCreateNewMappingPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CreateNewMapping) (Return Type : ListBiz) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_CreateNewMapping_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var listId = CreateType<Guid>();
            var fields = CreateType<ListItemCollection>();
            var isAuto = CreateType<bool>();
            var methodCreateNewMappingPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(ListItemCollection), typeof(bool) };
            object[] parametersOfCreateNewMapping = { siteId, listId, fields, isAuto };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<ListBiz>(_listBizInstanceFixture, _listBizInstanceType, MethodCreateNewMapping, parametersOfCreateNewMapping, methodCreateNewMappingPrametersTypes);

            // Assert
            parametersOfCreateNewMapping.ShouldNotBeNull();
            parametersOfCreateNewMapping.Length.ShouldBe(4);
            methodCreateNewMappingPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateNewMapping) (Return Type : ListBiz) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_CreateNewMapping_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCreateNewMappingPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(ListItemCollection), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listBizInstanceFixture, _listBizInstanceType, MethodCreateNewMapping, Fixture, methodCreateNewMappingPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCreateNewMappingPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (CreateNewMapping) (Return Type : ListBiz) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_CreateNewMapping_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateNewMappingPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(ListItemCollection), typeof(bool) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listBizInstanceFixture, _listBizInstanceType, MethodCreateNewMapping, Fixture, methodCreateNewMappingPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreateNewMappingPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateNewMapping) (Return Type : ListBiz) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_CreateNewMapping_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateNewMapping, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listBizInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateNewMapping) (Return Type : ListBiz) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_CreateNewMapping_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreateNewMapping, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateNewMapping) (Return Type : ListBiz) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListBiz_CreateNewMapping_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodCreateNewMappingPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listBizInstanceFixture, _listBizInstanceType, MethodCreateNewMapping, Fixture, methodCreateNewMappingPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateNewMapping) (Return Type : ListBiz) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_CreateNewMapping_Static_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var listId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var fields = CreateType<ListItemCollection>();
            Action executeAction = null;

            // Act
            executeAction = () => ListBiz.CreateNewMapping(siteId, listId, webId, fields);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CreateNewMapping) (Return Type : ListBiz) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_CreateNewMapping_Static_Method_Call_Overloading_Of_1_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var listId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var fields = CreateType<ListItemCollection>();
            var methodCreateNewMappingPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(ListItemCollection) };
            object[] parametersOfCreateNewMapping = { siteId, listId, webId, fields };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateNewMapping, methodCreateNewMappingPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listBizInstanceFixture, _listBizInstanceType, MethodCreateNewMapping, Fixture, methodCreateNewMappingPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<ListBiz>(_listBizInstanceFixture, _listBizInstanceType, MethodCreateNewMapping, parametersOfCreateNewMapping, methodCreateNewMappingPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_listBizInstanceFixture, parametersOfCreateNewMapping);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfCreateNewMapping.ShouldNotBeNull();
            parametersOfCreateNewMapping.Length.ShouldBe(4);
            methodCreateNewMappingPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CreateNewMapping) (Return Type : ListBiz) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_CreateNewMapping_Static_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var listId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var fields = CreateType<ListItemCollection>();
            var methodCreateNewMappingPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(ListItemCollection) };
            object[] parametersOfCreateNewMapping = { siteId, listId, webId, fields };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<ListBiz>(_listBizInstanceFixture, _listBizInstanceType, MethodCreateNewMapping, parametersOfCreateNewMapping, methodCreateNewMappingPrametersTypes);

            // Assert
            parametersOfCreateNewMapping.ShouldNotBeNull();
            parametersOfCreateNewMapping.Length.ShouldBe(4);
            methodCreateNewMappingPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateNewMapping) (Return Type : ListBiz) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_CreateNewMapping_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCreateNewMappingPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(ListItemCollection) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listBizInstanceFixture, _listBizInstanceType, MethodCreateNewMapping, Fixture, methodCreateNewMappingPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCreateNewMappingPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (CreateNewMapping) (Return Type : ListBiz) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_CreateNewMapping_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateNewMappingPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(ListItemCollection) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listBizInstanceFixture, _listBizInstanceType, MethodCreateNewMapping, Fixture, methodCreateNewMappingPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreateNewMappingPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateNewMapping) (Return Type : ListBiz) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_CreateNewMapping_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateNewMapping, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listBizInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateNewMapping) (Return Type : ListBiz) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_CreateNewMapping_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreateNewMapping, 1);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FieldExistsInCollection) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListBiz_FieldExistsInCollection_Static_Method_Call_Internally(Type[] types)
        {
            var methodFieldExistsInCollectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listBizInstanceFixture, _listBizInstanceType, MethodFieldExistsInCollection, Fixture, methodFieldExistsInCollectionPrametersTypes);
        }

        #endregion

        #region Method Call : (FieldExistsInCollection) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_FieldExistsInCollection_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var liCol = CreateType<ListItemCollection>();
            var fieldName = CreateType<string>();
            var methodFieldExistsInCollectionPrametersTypes = new Type[] { typeof(ListItemCollection), typeof(string) };
            object[] parametersOfFieldExistsInCollection = { liCol, fieldName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodFieldExistsInCollection, methodFieldExistsInCollectionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listBizInstanceFixture, parametersOfFieldExistsInCollection);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfFieldExistsInCollection.ShouldNotBeNull();
            parametersOfFieldExistsInCollection.Length.ShouldBe(2);
            methodFieldExistsInCollectionPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FieldExistsInCollection) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_FieldExistsInCollection_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var liCol = CreateType<ListItemCollection>();
            var fieldName = CreateType<string>();
            var methodFieldExistsInCollectionPrametersTypes = new Type[] { typeof(ListItemCollection), typeof(string) };
            object[] parametersOfFieldExistsInCollection = { liCol, fieldName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_listBizInstanceFixture, _listBizInstanceType, MethodFieldExistsInCollection, parametersOfFieldExistsInCollection, methodFieldExistsInCollectionPrametersTypes);

            // Assert
            parametersOfFieldExistsInCollection.ShouldNotBeNull();
            parametersOfFieldExistsInCollection.Length.ShouldBe(2);
            methodFieldExistsInCollectionPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FieldExistsInCollection) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_FieldExistsInCollection_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFieldExistsInCollectionPrametersTypes = new Type[] { typeof(ListItemCollection), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listBizInstanceFixture, _listBizInstanceType, MethodFieldExistsInCollection, Fixture, methodFieldExistsInCollectionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodFieldExistsInCollectionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FieldExistsInCollection) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_FieldExistsInCollection_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFieldExistsInCollection, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listBizInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (FieldExistsInCollection) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_FieldExistsInCollection_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodFieldExistsInCollection, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Create) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListBiz_Create_Method_Call_Internally(Type[] types)
        {
            var methodCreatePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listBizInstance, MethodCreate, Fixture, methodCreatePrametersTypes);
        }

        #endregion

        #region Method Call : (Create) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_Create_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var columns = CreateType<ColumnDefCollection>();
            var columnsSnapshot = CreateType<List<ColumnDef>>();
            var tableName = CreateType<string>();
            var methodCreatePrametersTypes = new Type[] { typeof(ColumnDefCollection), typeof(List<ColumnDef>), typeof(string) };
            object[] parametersOfCreate = { columns, columnsSnapshot, tableName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreate, methodCreatePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listBizInstanceFixture, parametersOfCreate);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreate.ShouldNotBeNull();
            parametersOfCreate.Length.ShouldBe(3);
            methodCreatePrametersTypes.Length.ShouldBe(3);
            methodCreatePrametersTypes.Length.ShouldBe(parametersOfCreate.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Create) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_Create_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var columns = CreateType<ColumnDefCollection>();
            var columnsSnapshot = CreateType<List<ColumnDef>>();
            var tableName = CreateType<string>();
            var methodCreatePrametersTypes = new Type[] { typeof(ColumnDefCollection), typeof(List<ColumnDef>), typeof(string) };
            object[] parametersOfCreate = { columns, columnsSnapshot, tableName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listBizInstance, MethodCreate, parametersOfCreate, methodCreatePrametersTypes);

            // Assert
            parametersOfCreate.ShouldNotBeNull();
            parametersOfCreate.Length.ShouldBe(3);
            methodCreatePrametersTypes.Length.ShouldBe(3);
            methodCreatePrametersTypes.Length.ShouldBe(parametersOfCreate.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Create) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_Create_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreate, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Create) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_Create_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreatePrametersTypes = new Type[] { typeof(ColumnDefCollection), typeof(List<ColumnDef>), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listBizInstance, MethodCreate, Fixture, methodCreatePrametersTypes);

            // Assert
            methodCreatePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Create) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_Create_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreate, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listBizInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Create) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListBiz_Create_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodCreatePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listBizInstance, MethodCreate, Fixture, methodCreatePrametersTypes);
        }

        #endregion

        #region Method Call : (Create) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_Create_Method_Call_Void_Overloading_Of_1_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var columns = CreateType<ColumnDefCollection>();
            var columnsSnapshot = CreateType<List<ColumnDef>>();
            var tableName = CreateType<string>();
            var webId = CreateType<Guid>();
            var methodCreatePrametersTypes = new Type[] { typeof(ColumnDefCollection), typeof(List<ColumnDef>), typeof(string), typeof(Guid) };
            object[] parametersOfCreate = { columns, columnsSnapshot, tableName, webId };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreate, methodCreatePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listBizInstanceFixture, parametersOfCreate);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreate.ShouldNotBeNull();
            parametersOfCreate.Length.ShouldBe(4);
            methodCreatePrametersTypes.Length.ShouldBe(4);
            methodCreatePrametersTypes.Length.ShouldBe(parametersOfCreate.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Create) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_Create_Method_Call_Void_Overloading_Of_1_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var columns = CreateType<ColumnDefCollection>();
            var columnsSnapshot = CreateType<List<ColumnDef>>();
            var tableName = CreateType<string>();
            var webId = CreateType<Guid>();
            var methodCreatePrametersTypes = new Type[] { typeof(ColumnDefCollection), typeof(List<ColumnDef>), typeof(string), typeof(Guid) };
            object[] parametersOfCreate = { columns, columnsSnapshot, tableName, webId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listBizInstance, MethodCreate, parametersOfCreate, methodCreatePrametersTypes);

            // Assert
            parametersOfCreate.ShouldNotBeNull();
            parametersOfCreate.Length.ShouldBe(4);
            methodCreatePrametersTypes.Length.ShouldBe(4);
            methodCreatePrametersTypes.Length.ShouldBe(parametersOfCreate.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Create) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_Create_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreate, 1);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Create) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_Create_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreatePrametersTypes = new Type[] { typeof(ColumnDefCollection), typeof(List<ColumnDef>), typeof(string), typeof(Guid) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listBizInstance, MethodCreate, Fixture, methodCreatePrametersTypes);

            // Assert
            methodCreatePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Create) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_Create_Method_Call_Overloading_Of_1_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreate, 1);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listBizInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Update) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListBiz_Update_Method_Call_Internally(Type[] types)
        {
            var methodUpdatePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listBizInstance, MethodUpdate, Fixture, methodUpdatePrametersTypes);
        }

        #endregion

        #region Method Call : (Update) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_Update_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var columns = CreateType<ColumnDefCollection>();
            var methodUpdatePrametersTypes = new Type[] { typeof(ColumnDefCollection) };
            object[] parametersOfUpdate = { columns };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdate, methodUpdatePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listBizInstanceFixture, parametersOfUpdate);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdate.ShouldNotBeNull();
            parametersOfUpdate.Length.ShouldBe(1);
            methodUpdatePrametersTypes.Length.ShouldBe(1);
            methodUpdatePrametersTypes.Length.ShouldBe(parametersOfUpdate.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Update) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_Update_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var columns = CreateType<ColumnDefCollection>();
            var methodUpdatePrametersTypes = new Type[] { typeof(ColumnDefCollection) };
            object[] parametersOfUpdate = { columns };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listBizInstance, MethodUpdate, parametersOfUpdate, methodUpdatePrametersTypes);

            // Assert
            parametersOfUpdate.ShouldNotBeNull();
            parametersOfUpdate.Length.ShouldBe(1);
            methodUpdatePrametersTypes.Length.ShouldBe(1);
            methodUpdatePrametersTypes.Length.ShouldBe(parametersOfUpdate.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Update) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_Update_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (Update) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_Update_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdatePrametersTypes = new Type[] { typeof(ColumnDefCollection) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listBizInstance, MethodUpdate, Fixture, methodUpdatePrametersTypes);

            // Assert
            methodUpdatePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Update) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_Update_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdate, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listBizInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListBiz_Delete_Method_Call_Internally(Type[] types)
        {
            var methodDeletePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listBizInstance, MethodDelete, Fixture, methodDeletePrametersTypes);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_Delete_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _listBizInstance.Delete();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_Delete_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodDeletePrametersTypes = null;
            object[] parametersOfDelete = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDelete, methodDeletePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ListBiz, bool>(_listBizInstanceFixture, out exception1, parametersOfDelete);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ListBiz, bool>(_listBizInstance, MethodDelete, parametersOfDelete, methodDeletePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDelete.ShouldBeNull();
            methodDeletePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Delete) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_Delete_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodDeletePrametersTypes = null;
            object[] parametersOfDelete = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDelete, methodDeletePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ListBiz, bool>(_listBizInstanceFixture, out exception1, parametersOfDelete);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ListBiz, bool>(_listBizInstance, MethodDelete, parametersOfDelete, methodDeletePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDelete.ShouldBeNull();
            methodDeletePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Delete) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_Delete_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodDeletePrametersTypes = null;
            object[] parametersOfDelete = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ListBiz, bool>(_listBizInstance, MethodDelete, parametersOfDelete, methodDeletePrametersTypes);

            // Assert
            parametersOfDelete.ShouldBeNull();
            methodDeletePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_Delete_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodDeletePrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listBizInstance, MethodDelete, Fixture, methodDeletePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeletePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Delete) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_Delete_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDelete, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listBizInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLog) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListBiz_GetLog_Method_Call_Internally(Type[] types)
        {
            var methodGetLogPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listBizInstance, MethodGetLog, Fixture, methodGetLogPrametersTypes);
        }

        #endregion

        #region Method Call : (GetLog) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_GetLog_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var minimumLevel = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _listBizInstance.GetLog(minimumLevel);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetLog) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_GetLog_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var minimumLevel = CreateType<int>();
            var methodGetLogPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfGetLog = { minimumLevel };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetLog, methodGetLogPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ListBiz, DataTable>(_listBizInstanceFixture, out exception1, parametersOfGetLog);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ListBiz, DataTable>(_listBizInstance, MethodGetLog, parametersOfGetLog, methodGetLogPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetLog.ShouldNotBeNull();
            parametersOfGetLog.Length.ShouldBe(1);
            methodGetLogPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetLog) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_GetLog_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var minimumLevel = CreateType<int>();
            var methodGetLogPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfGetLog = { minimumLevel };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ListBiz, DataTable>(_listBizInstance, MethodGetLog, parametersOfGetLog, methodGetLogPrametersTypes);

            // Assert
            parametersOfGetLog.ShouldNotBeNull();
            parametersOfGetLog.Length.ShouldBe(1);
            methodGetLogPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetLog) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_GetLog_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetLogPrametersTypes = new Type[] { typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listBizInstance, MethodGetLog, Fixture, methodGetLogPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetLogPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetLog) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_GetLog_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetLogPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listBizInstance, MethodGetLog, Fixture, methodGetLogPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetLogPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetLog) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_GetLog_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetLog, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listBizInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLog) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_GetLog_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetLog, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ClearLog) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListBiz_ClearLog_Method_Call_Internally(Type[] types)
        {
            var methodClearLogPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listBizInstance, MethodClearLog, Fixture, methodClearLogPrametersTypes);
        }

        #endregion

        #region Method Call : (ClearLog) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_ClearLog_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var type = CreateType<object>();
            Action executeAction = null;

            // Act
            executeAction = () => _listBizInstance.ClearLog(type);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ClearLog) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_ClearLog_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var type = CreateType<object>();
            var methodClearLogPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfClearLog = { type };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodClearLog, methodClearLogPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listBizInstanceFixture, parametersOfClearLog);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfClearLog.ShouldNotBeNull();
            parametersOfClearLog.Length.ShouldBe(1);
            methodClearLogPrametersTypes.Length.ShouldBe(1);
            methodClearLogPrametersTypes.Length.ShouldBe(parametersOfClearLog.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ClearLog) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_ClearLog_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var type = CreateType<object>();
            var methodClearLogPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfClearLog = { type };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listBizInstance, MethodClearLog, parametersOfClearLog, methodClearLogPrametersTypes);

            // Assert
            parametersOfClearLog.ShouldNotBeNull();
            parametersOfClearLog.Length.ShouldBe(1);
            methodClearLogPrametersTypes.Length.ShouldBe(1);
            methodClearLogPrametersTypes.Length.ShouldBe(parametersOfClearLog.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearLog) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_ClearLog_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodClearLog, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ClearLog) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_ClearLog_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodClearLogPrametersTypes = new Type[] { typeof(object) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listBizInstance, MethodClearLog, Fixture, methodClearLogPrametersTypes);

            // Assert
            methodClearLogPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearLog) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_ClearLog_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodClearLog, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listBizInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetMaximumLogLevel) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListBiz_GetMaximumLogLevel_Method_Call_Internally(Type[] types)
        {
            var methodGetMaximumLogLevelPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listBizInstance, MethodGetMaximumLogLevel, Fixture, methodGetMaximumLogLevelPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMaximumLogLevel) (Return Type : int) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_GetMaximumLogLevel_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _listBizInstance.GetMaximumLogLevel();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetMaximumLogLevel) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_GetMaximumLogLevel_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetMaximumLogLevelPrametersTypes = null;
            object[] parametersOfGetMaximumLogLevel = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetMaximumLogLevel, methodGetMaximumLogLevelPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ListBiz, int>(_listBizInstanceFixture, out exception1, parametersOfGetMaximumLogLevel);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ListBiz, int>(_listBizInstance, MethodGetMaximumLogLevel, parametersOfGetMaximumLogLevel, methodGetMaximumLogLevelPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetMaximumLogLevel.ShouldBeNull();
            methodGetMaximumLogLevelPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMaximumLogLevel) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_GetMaximumLogLevel_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodGetMaximumLogLevelPrametersTypes = null;
            object[] parametersOfGetMaximumLogLevel = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetMaximumLogLevel, methodGetMaximumLogLevelPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ListBiz, int>(_listBizInstanceFixture, out exception1, parametersOfGetMaximumLogLevel);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ListBiz, int>(_listBizInstance, MethodGetMaximumLogLevel, parametersOfGetMaximumLogLevel, methodGetMaximumLogLevelPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetMaximumLogLevel.ShouldBeNull();
            methodGetMaximumLogLevelPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMaximumLogLevel) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_GetMaximumLogLevel_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetMaximumLogLevelPrametersTypes = null;
            object[] parametersOfGetMaximumLogLevel = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ListBiz, int>(_listBizInstance, MethodGetMaximumLogLevel, parametersOfGetMaximumLogLevel, methodGetMaximumLogLevelPrametersTypes);

            // Assert
            parametersOfGetMaximumLogLevel.ShouldBeNull();
            methodGetMaximumLogLevelPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetMaximumLogLevel) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_GetMaximumLogLevel_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetMaximumLogLevelPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listBizInstance, MethodGetMaximumLogLevel, Fixture, methodGetMaximumLogLevelPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetMaximumLogLevelPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMaximumLogLevel) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_GetMaximumLogLevel_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetMaximumLogLevel, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listBizInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMappedFieldsStrings) (Return Type : List<string>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListBiz_GetMappedFieldsStrings_Method_Call_Internally(Type[] types)
        {
            var methodGetMappedFieldsStringsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listBizInstance, MethodGetMappedFieldsStrings, Fixture, methodGetMappedFieldsStringsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMappedFieldsStrings) (Return Type : List<string>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_GetMappedFieldsStrings_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _listBizInstance.GetMappedFieldsStrings();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetMappedFieldsStrings) (Return Type : List<string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_GetMappedFieldsStrings_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetMappedFieldsStringsPrametersTypes = null;
            object[] parametersOfGetMappedFieldsStrings = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetMappedFieldsStrings, methodGetMappedFieldsStringsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ListBiz, List<string>>(_listBizInstanceFixture, out exception1, parametersOfGetMappedFieldsStrings);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ListBiz, List<string>>(_listBizInstance, MethodGetMappedFieldsStrings, parametersOfGetMappedFieldsStrings, methodGetMappedFieldsStringsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetMappedFieldsStrings.ShouldBeNull();
            methodGetMappedFieldsStringsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMappedFieldsStrings) (Return Type : List<string>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_GetMappedFieldsStrings_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetMappedFieldsStringsPrametersTypes = null;
            object[] parametersOfGetMappedFieldsStrings = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ListBiz, List<string>>(_listBizInstance, MethodGetMappedFieldsStrings, parametersOfGetMappedFieldsStrings, methodGetMappedFieldsStringsPrametersTypes);

            // Assert
            parametersOfGetMappedFieldsStrings.ShouldBeNull();
            methodGetMappedFieldsStringsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetMappedFieldsStrings) (Return Type : List<string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_GetMappedFieldsStrings_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetMappedFieldsStringsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listBizInstance, MethodGetMappedFieldsStrings, Fixture, methodGetMappedFieldsStringsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetMappedFieldsStringsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMappedFieldsStrings) (Return Type : List<string>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_GetMappedFieldsStrings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetMappedFieldsStringsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listBizInstance, MethodGetMappedFieldsStrings, Fixture, methodGetMappedFieldsStringsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetMappedFieldsStringsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMappedFieldsStrings) (Return Type : List<string>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_GetMappedFieldsStrings_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetMappedFieldsStrings, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listBizInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMappedFields) (Return Type : ColumnDefCollection) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListBiz_GetMappedFields_Method_Call_Internally(Type[] types)
        {
            var methodGetMappedFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listBizInstance, MethodGetMappedFields, Fixture, methodGetMappedFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMappedFields) (Return Type : ColumnDefCollection) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_GetMappedFields_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _listBizInstance.GetMappedFields();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetMappedFields) (Return Type : ColumnDefCollection) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_GetMappedFields_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetMappedFieldsPrametersTypes = null;
            object[] parametersOfGetMappedFields = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetMappedFields, methodGetMappedFieldsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ListBiz, ColumnDefCollection>(_listBizInstanceFixture, out exception1, parametersOfGetMappedFields);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ListBiz, ColumnDefCollection>(_listBizInstance, MethodGetMappedFields, parametersOfGetMappedFields, methodGetMappedFieldsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetMappedFields.ShouldBeNull();
            methodGetMappedFieldsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMappedFields) (Return Type : ColumnDefCollection) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_GetMappedFields_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetMappedFieldsPrametersTypes = null;
            object[] parametersOfGetMappedFields = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ListBiz, ColumnDefCollection>(_listBizInstance, MethodGetMappedFields, parametersOfGetMappedFields, methodGetMappedFieldsPrametersTypes);

            // Assert
            parametersOfGetMappedFields.ShouldBeNull();
            methodGetMappedFieldsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetMappedFields) (Return Type : ColumnDefCollection) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_GetMappedFields_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetMappedFieldsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listBizInstance, MethodGetMappedFields, Fixture, methodGetMappedFieldsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetMappedFieldsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMappedFields) (Return Type : ColumnDefCollection) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_GetMappedFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetMappedFieldsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listBizInstance, MethodGetMappedFields, Fixture, methodGetMappedFieldsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetMappedFieldsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMappedFields) (Return Type : ColumnDefCollection) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_GetMappedFields_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetMappedFields, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listBizInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetResourceListFlag) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListBiz_SetResourceListFlag_Method_Call_Internally(Type[] types)
        {
            var methodSetResourceListFlagPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listBizInstance, MethodSetResourceListFlag, Fixture, methodSetResourceListFlagPrametersTypes);
        }

        #endregion

        #region Method Call : (SetResourceListFlag) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_SetResourceListFlag_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var flag = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _listBizInstance.SetResourceListFlag(flag);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetResourceListFlag) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_SetResourceListFlag_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var flag = CreateType<bool>();
            var methodSetResourceListFlagPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfSetResourceListFlag = { flag };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSetResourceListFlag, methodSetResourceListFlagPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ListBiz, bool>(_listBizInstanceFixture, out exception1, parametersOfSetResourceListFlag);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ListBiz, bool>(_listBizInstance, MethodSetResourceListFlag, parametersOfSetResourceListFlag, methodSetResourceListFlagPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSetResourceListFlag.ShouldNotBeNull();
            parametersOfSetResourceListFlag.Length.ShouldBe(1);
            methodSetResourceListFlagPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SetResourceListFlag) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_SetResourceListFlag_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var flag = CreateType<bool>();
            var methodSetResourceListFlagPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfSetResourceListFlag = { flag };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSetResourceListFlag, methodSetResourceListFlagPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ListBiz, bool>(_listBizInstanceFixture, out exception1, parametersOfSetResourceListFlag);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ListBiz, bool>(_listBizInstance, MethodSetResourceListFlag, parametersOfSetResourceListFlag, methodSetResourceListFlagPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSetResourceListFlag.ShouldNotBeNull();
            parametersOfSetResourceListFlag.Length.ShouldBe(1);
            methodSetResourceListFlagPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SetResourceListFlag) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_SetResourceListFlag_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var flag = CreateType<bool>();
            var methodSetResourceListFlagPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfSetResourceListFlag = { flag };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ListBiz, bool>(_listBizInstance, MethodSetResourceListFlag, parametersOfSetResourceListFlag, methodSetResourceListFlagPrametersTypes);

            // Assert
            parametersOfSetResourceListFlag.ShouldNotBeNull();
            parametersOfSetResourceListFlag.Length.ShouldBe(1);
            methodSetResourceListFlagPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetResourceListFlag) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_SetResourceListFlag_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetResourceListFlagPrametersTypes = new Type[] { typeof(bool) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listBizInstance, MethodSetResourceListFlag, Fixture, methodSetResourceListFlagPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSetResourceListFlagPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetResourceListFlag) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_SetResourceListFlag_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetResourceListFlag, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listBizInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetResourceListFlag) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_SetResourceListFlag_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetResourceListFlag, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Snapshot) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListBiz_Snapshot_Method_Call_Internally(Type[] types)
        {
            var methodSnapshotPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listBizInstance, MethodSnapshot, Fixture, methodSnapshotPrametersTypes);
        }

        #endregion

        #region Method Call : (Snapshot) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_Snapshot_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _listBizInstance.Snapshot();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Snapshot) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_Snapshot_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodSnapshotPrametersTypes = null;
            object[] parametersOfSnapshot = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSnapshot, methodSnapshotPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ListBiz, bool>(_listBizInstanceFixture, out exception1, parametersOfSnapshot);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ListBiz, bool>(_listBizInstance, MethodSnapshot, parametersOfSnapshot, methodSnapshotPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSnapshot.ShouldBeNull();
            methodSnapshotPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Snapshot) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_Snapshot_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodSnapshotPrametersTypes = null;
            object[] parametersOfSnapshot = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSnapshot, methodSnapshotPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ListBiz, bool>(_listBizInstanceFixture, out exception1, parametersOfSnapshot);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ListBiz, bool>(_listBizInstance, MethodSnapshot, parametersOfSnapshot, methodSnapshotPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSnapshot.ShouldBeNull();
            methodSnapshotPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Snapshot) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_Snapshot_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodSnapshotPrametersTypes = null;
            object[] parametersOfSnapshot = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ListBiz, bool>(_listBizInstance, MethodSnapshot, parametersOfSnapshot, methodSnapshotPrametersTypes);

            // Assert
            parametersOfSnapshot.ShouldBeNull();
            methodSnapshotPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Snapshot) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_Snapshot_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodSnapshotPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listBizInstance, MethodSnapshot, Fixture, methodSnapshotPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSnapshotPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Snapshot) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_Snapshot_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSnapshot, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listBizInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RegisterEvent) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListBiz_RegisterEvent_Method_Call_Internally(Type[] types)
        {
            var methodRegisterEventPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listBizInstance, MethodRegisterEvent, Fixture, methodRegisterEventPrametersTypes);
        }

        #endregion

        #region Method Call : (RegisterEvent) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_RegisterEvent_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodRegisterEventPrametersTypes = null;
            object[] parametersOfRegisterEvent = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRegisterEvent, methodRegisterEventPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listBizInstanceFixture, parametersOfRegisterEvent);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRegisterEvent.ShouldBeNull();
            methodRegisterEventPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RegisterEvent) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_RegisterEvent_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRegisterEventPrametersTypes = null;
            object[] parametersOfRegisterEvent = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listBizInstance, MethodRegisterEvent, parametersOfRegisterEvent, methodRegisterEventPrametersTypes);

            // Assert
            parametersOfRegisterEvent.ShouldBeNull();
            methodRegisterEventPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterEvent) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_RegisterEvent_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRegisterEventPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listBizInstance, MethodRegisterEvent, Fixture, methodRegisterEventPrametersTypes);

            // Assert
            methodRegisterEventPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterEvent) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_RegisterEvent_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRegisterEvent, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listBizInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListEvents) (Return Type : List<SPEventReceiverDefinition>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListBiz_GetListEvents_Method_Call_Internally(Type[] types)
        {
            var methodGetListEventsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listBizInstance, MethodGetListEvents, Fixture, methodGetListEventsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetListEvents) (Return Type : List<SPEventReceiverDefinition>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_GetListEvents_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var assemblyName = CreateType<string>();
            var className = CreateType<string>();
            var types = CreateType<List<SPEventReceiverType>>();
            var methodGetListEventsPrametersTypes = new Type[] { typeof(SPList), typeof(string), typeof(string), typeof(List<SPEventReceiverType>) };
            object[] parametersOfGetListEvents = { list, assemblyName, className, types };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetListEvents, methodGetListEventsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ListBiz, List<SPEventReceiverDefinition>>(_listBizInstanceFixture, out exception1, parametersOfGetListEvents);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ListBiz, List<SPEventReceiverDefinition>>(_listBizInstance, MethodGetListEvents, parametersOfGetListEvents, methodGetListEventsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetListEvents.ShouldNotBeNull();
            parametersOfGetListEvents.Length.ShouldBe(4);
            methodGetListEventsPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetListEvents) (Return Type : List<SPEventReceiverDefinition>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_GetListEvents_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var assemblyName = CreateType<string>();
            var className = CreateType<string>();
            var types = CreateType<List<SPEventReceiverType>>();
            var methodGetListEventsPrametersTypes = new Type[] { typeof(SPList), typeof(string), typeof(string), typeof(List<SPEventReceiverType>) };
            object[] parametersOfGetListEvents = { list, assemblyName, className, types };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ListBiz, List<SPEventReceiverDefinition>>(_listBizInstance, MethodGetListEvents, parametersOfGetListEvents, methodGetListEventsPrametersTypes);

            // Assert
            parametersOfGetListEvents.ShouldNotBeNull();
            parametersOfGetListEvents.Length.ShouldBe(4);
            methodGetListEventsPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListEvents) (Return Type : List<SPEventReceiverDefinition>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_GetListEvents_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetListEventsPrametersTypes = new Type[] { typeof(SPList), typeof(string), typeof(string), typeof(List<SPEventReceiverType>) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listBizInstance, MethodGetListEvents, Fixture, methodGetListEventsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetListEventsPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetListEvents) (Return Type : List<SPEventReceiverDefinition>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_GetListEvents_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetListEventsPrametersTypes = new Type[] { typeof(SPList), typeof(string), typeof(string), typeof(List<SPEventReceiverType>) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listBizInstance, MethodGetListEvents, Fixture, methodGetListEventsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListEventsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListEvents) (Return Type : List<SPEventReceiverDefinition>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_GetListEvents_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListEvents, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listBizInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListEvents) (Return Type : List<SPEventReceiverDefinition>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_GetListEvents_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetListEvents, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RemoveEvent) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListBiz_RemoveEvent_Method_Call_Internally(Type[] types)
        {
            var methodRemoveEventPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listBizInstance, MethodRemoveEvent, Fixture, methodRemoveEventPrametersTypes);
        }

        #endregion

        #region Method Call : (RemoveEvent) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_RemoveEvent_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodRemoveEventPrametersTypes = null;
            object[] parametersOfRemoveEvent = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRemoveEvent, methodRemoveEventPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listBizInstanceFixture, parametersOfRemoveEvent);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRemoveEvent.ShouldBeNull();
            methodRemoveEventPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RemoveEvent) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_RemoveEvent_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRemoveEventPrametersTypes = null;
            object[] parametersOfRemoveEvent = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listBizInstance, MethodRemoveEvent, parametersOfRemoveEvent, methodRemoveEventPrametersTypes);

            // Assert
            parametersOfRemoveEvent.ShouldBeNull();
            methodRemoveEventPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RemoveEvent) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_RemoveEvent_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRemoveEventPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listBizInstance, MethodRemoveEvent, Fixture, methodRemoveEventPrametersTypes);

            // Assert
            methodRemoveEventPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RemoveEvent) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListBiz_RemoveEvent_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRemoveEvent, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listBizInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
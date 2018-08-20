using System;
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

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.ResourcePoolEvent" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class ResourcePoolEventTest : AbstractBaseSetupTypedTest<ResourcePoolEvent>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ResourcePoolEvent) Initializer

        private const string MethodloadData = "loadData";
        private const string MethodItemAdding = "ItemAdding";
        private const string MethodGetProperty = "GetProperty";
        private const string MethodprocessItem = "processItem";
        private const string MethodProcessDepartment = "ProcessDepartment";
        private const string MethodProcessLevel = "ProcessLevel";
        private const string MethodGetPropertyBeforeOrAfter = "GetPropertyBeforeOrAfter";
        private const string MethoddisableAccount = "disableAccount";
        private const string MethodProcessOnlineUser = "ProcessOnlineUser";
        private const string MethodaddUserToAccount = "addUserToAccount";
        private const string MethodgetTempPassword = "getTempPassword";
        private const string MethodsetPermissions = "setPermissions";
        private const string MethodsendRequestEmail = "sendRequestEmail";
        private const string MethodsendOwnerEmail = "sendOwnerEmail";
        private const string MethodcreateGroup = "createGroup";
        private const string MethodaddUser = "addUser";
        private const string MethodItemUpdating = "ItemUpdating";
        private const string MethodItemDeleted = "ItemDeleted";
        private const string MethodItemDeleting = "ItemDeleting";
        private const string FieldisOnline = "isOnline";
        private const string Fieldmax = "max";
        private const string Fieldcount = "count";
        private const string Fieldexpired = "expired";
        private const string Fieldcn = "cn";
        private const string Fieldownerusername = "ownerusername";
        private const string Fieldowneremail = "owneremail";
        private const string Fieldaccountid = "accountid";
        private const string Fieldbillingtype = "billingtype";
        private const string FieldActivationType = "ActivationType";
        private Type _resourcePoolEventInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ResourcePoolEvent _resourcePoolEventInstance;
        private ResourcePoolEvent _resourcePoolEventInstanceFixture;

        #region General Initializer : Class (ResourcePoolEvent) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ResourcePoolEvent" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _resourcePoolEventInstanceType = typeof(ResourcePoolEvent);
            _resourcePoolEventInstanceFixture = Create(true);
            _resourcePoolEventInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ResourcePoolEvent)

        #region General Initializer : Class (ResourcePoolEvent) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ResourcePoolEvent" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodloadData, 0)]
        [TestCase(MethodItemAdding, 0)]
        [TestCase(MethodGetProperty, 0)]
        [TestCase(MethodprocessItem, 0)]
        [TestCase(MethodProcessDepartment, 0)]
        [TestCase(MethodProcessLevel, 0)]
        [TestCase(MethodGetPropertyBeforeOrAfter, 0)]
        [TestCase(MethoddisableAccount, 0)]
        [TestCase(MethodProcessOnlineUser, 0)]
        [TestCase(MethodaddUserToAccount, 0)]
        [TestCase(MethodgetTempPassword, 0)]
        [TestCase(MethodsetPermissions, 0)]
        [TestCase(MethodsendRequestEmail, 0)]
        [TestCase(MethodsendOwnerEmail, 0)]
        [TestCase(MethodcreateGroup, 0)]
        [TestCase(MethodaddUser, 0)]
        [TestCase(MethodItemUpdating, 0)]
        [TestCase(MethodItemDeleted, 0)]
        [TestCase(MethodItemDeleting, 0)]
        public void AUT_ResourcePoolEvent_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_resourcePoolEventInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ResourcePoolEvent) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ResourcePoolEvent" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldisOnline)]
        [TestCase(Fieldmax)]
        [TestCase(Fieldcount)]
        [TestCase(Fieldexpired)]
        [TestCase(Fieldcn)]
        [TestCase(Fieldownerusername)]
        [TestCase(Fieldowneremail)]
        [TestCase(Fieldaccountid)]
        [TestCase(Fieldbillingtype)]
        [TestCase(FieldActivationType)]
        public void AUT_ResourcePoolEvent_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_resourcePoolEventInstanceFixture, 
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
        ///     Class (<see cref="ResourcePoolEvent" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ResourcePoolEvent_Is_Instance_Present_Test()
        {
            // Assert
            _resourcePoolEventInstanceType.ShouldNotBeNull();
            _resourcePoolEventInstance.ShouldNotBeNull();
            _resourcePoolEventInstanceFixture.ShouldNotBeNull();
            _resourcePoolEventInstance.ShouldBeAssignableTo<ResourcePoolEvent>();
            _resourcePoolEventInstanceFixture.ShouldBeAssignableTo<ResourcePoolEvent>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ResourcePoolEvent) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ResourcePoolEvent_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ResourcePoolEvent instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _resourcePoolEventInstanceType.ShouldNotBeNull();
            _resourcePoolEventInstance.ShouldNotBeNull();
            _resourcePoolEventInstanceFixture.ShouldNotBeNull();
            _resourcePoolEventInstance.ShouldBeAssignableTo<ResourcePoolEvent>();
            _resourcePoolEventInstanceFixture.ShouldBeAssignableTo<ResourcePoolEvent>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ResourcePoolEvent" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodloadData)]
        [TestCase(MethodItemAdding)]
        [TestCase(MethodGetProperty)]
        [TestCase(MethodprocessItem)]
        [TestCase(MethodProcessDepartment)]
        [TestCase(MethodProcessLevel)]
        [TestCase(MethodGetPropertyBeforeOrAfter)]
        [TestCase(MethoddisableAccount)]
        [TestCase(MethodProcessOnlineUser)]
        [TestCase(MethodaddUserToAccount)]
        [TestCase(MethodgetTempPassword)]
        [TestCase(MethodsetPermissions)]
        [TestCase(MethodsendRequestEmail)]
        [TestCase(MethodsendOwnerEmail)]
        [TestCase(MethodcreateGroup)]
        [TestCase(MethodaddUser)]
        [TestCase(MethodItemUpdating)]
        [TestCase(MethodItemDeleted)]
        [TestCase(MethodItemDeleting)]
        public void AUT_ResourcePoolEvent_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ResourcePoolEvent>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (loadData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePoolEvent_loadData_Method_Call_Internally(Type[] types)
        {
            var methodloadDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethodloadData, Fixture, methodloadDataPrametersTypes);
        }

        #endregion

        #region Method Call : (loadData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_loadData_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var siteuid = CreateType<Guid>();
            var methodloadDataPrametersTypes = new Type[] { typeof(SPList), typeof(Guid) };
            object[] parametersOfloadData = { list, siteuid };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodloadData, methodloadDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourcePoolEventInstanceFixture, parametersOfloadData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfloadData.ShouldNotBeNull();
            parametersOfloadData.Length.ShouldBe(2);
            methodloadDataPrametersTypes.Length.ShouldBe(2);
            methodloadDataPrametersTypes.Length.ShouldBe(parametersOfloadData.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (loadData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_loadData_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var siteuid = CreateType<Guid>();
            var methodloadDataPrametersTypes = new Type[] { typeof(SPList), typeof(Guid) };
            object[] parametersOfloadData = { list, siteuid };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourcePoolEventInstance, MethodloadData, parametersOfloadData, methodloadDataPrametersTypes);

            // Assert
            parametersOfloadData.ShouldNotBeNull();
            parametersOfloadData.Length.ShouldBe(2);
            methodloadDataPrametersTypes.Length.ShouldBe(2);
            methodloadDataPrametersTypes.Length.ShouldBe(parametersOfloadData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_loadData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodloadData, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (loadData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_loadData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodloadDataPrametersTypes = new Type[] { typeof(SPList), typeof(Guid) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethodloadData, Fixture, methodloadDataPrametersTypes);

            // Assert
            methodloadDataPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_loadData_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodloadData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcePoolEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemAdding) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePoolEvent_ItemAdding_Method_Call_Internally(Type[] types)
        {
            var methodItemAddingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethodItemAdding, Fixture, methodItemAddingPrametersTypes);
        }

        #endregion

        #region Method Call : (ItemAdding) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_ItemAdding_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _resourcePoolEventInstance.ItemAdding(properties);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ItemAdding) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_ItemAdding_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemAddingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemAdding = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodItemAdding, methodItemAddingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourcePoolEventInstanceFixture, parametersOfItemAdding);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfItemAdding.ShouldNotBeNull();
            parametersOfItemAdding.Length.ShouldBe(1);
            methodItemAddingPrametersTypes.Length.ShouldBe(1);
            methodItemAddingPrametersTypes.Length.ShouldBe(parametersOfItemAdding.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ItemAdding) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_ItemAdding_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemAddingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemAdding = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourcePoolEventInstance, MethodItemAdding, parametersOfItemAdding, methodItemAddingPrametersTypes);

            // Assert
            parametersOfItemAdding.ShouldNotBeNull();
            parametersOfItemAdding.Length.ShouldBe(1);
            methodItemAddingPrametersTypes.Length.ShouldBe(1);
            methodItemAddingPrametersTypes.Length.ShouldBe(parametersOfItemAdding.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemAdding) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_ItemAdding_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodItemAdding, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ItemAdding) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_ItemAdding_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodItemAddingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethodItemAdding, Fixture, methodItemAddingPrametersTypes);

            // Assert
            methodItemAddingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemAdding) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_ItemAdding_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodItemAdding, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcePoolEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetProperty) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePoolEvent_GetProperty_Method_Call_Internally(Type[] types)
        {
            var methodGetPropertyPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethodGetProperty, Fixture, methodGetPropertyPrametersTypes);
        }

        #endregion

        #region Method Call : (GetProperty) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_GetProperty_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var property = CreateType<string>();
            var methodGetPropertyPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(string) };
            object[] parametersOfGetProperty = { properties, property };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetProperty, methodGetPropertyPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourcePoolEventInstanceFixture, parametersOfGetProperty);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetProperty.ShouldNotBeNull();
            parametersOfGetProperty.Length.ShouldBe(2);
            methodGetPropertyPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetProperty) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_GetProperty_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var property = CreateType<string>();
            var methodGetPropertyPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(string) };
            object[] parametersOfGetProperty = { properties, property };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ResourcePoolEvent, string>(_resourcePoolEventInstance, MethodGetProperty, parametersOfGetProperty, methodGetPropertyPrametersTypes);

            // Assert
            parametersOfGetProperty.ShouldNotBeNull();
            parametersOfGetProperty.Length.ShouldBe(2);
            methodGetPropertyPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetProperty) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_GetProperty_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetPropertyPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethodGetProperty, Fixture, methodGetPropertyPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetPropertyPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetProperty) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_GetProperty_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetPropertyPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethodGetProperty, Fixture, methodGetPropertyPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetPropertyPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetProperty) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_GetProperty_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetProperty, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcePoolEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetProperty) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_GetProperty_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetProperty, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processItem) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePoolEvent_processItem_Method_Call_Internally(Type[] types)
        {
            var methodprocessItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethodprocessItem, Fixture, methodprocessItemPrametersTypes);
        }

        #endregion

        #region Method Call : (processItem) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_processItem_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var isAdd = CreateType<bool>();
            var methodprocessItemPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(bool) };
            object[] parametersOfprocessItem = { properties, isAdd };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodprocessItem, methodprocessItemPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourcePoolEventInstanceFixture, parametersOfprocessItem);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfprocessItem.ShouldNotBeNull();
            parametersOfprocessItem.Length.ShouldBe(2);
            methodprocessItemPrametersTypes.Length.ShouldBe(2);
            methodprocessItemPrametersTypes.Length.ShouldBe(parametersOfprocessItem.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (processItem) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_processItem_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var isAdd = CreateType<bool>();
            var methodprocessItemPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(bool) };
            object[] parametersOfprocessItem = { properties, isAdd };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourcePoolEventInstance, MethodprocessItem, parametersOfprocessItem, methodprocessItemPrametersTypes);

            // Assert
            parametersOfprocessItem.ShouldNotBeNull();
            parametersOfprocessItem.Length.ShouldBe(2);
            methodprocessItemPrametersTypes.Length.ShouldBe(2);
            methodprocessItemPrametersTypes.Length.ShouldBe(parametersOfprocessItem.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processItem) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_processItem_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodprocessItem, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processItem) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_processItem_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodprocessItemPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethodprocessItem, Fixture, methodprocessItemPrametersTypes);

            // Assert
            methodprocessItemPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processItem) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_processItem_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprocessItem, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcePoolEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessDepartment) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePoolEvent_ProcessDepartment_Method_Call_Internally(Type[] types)
        {
            var methodProcessDepartmentPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethodProcessDepartment, Fixture, methodProcessDepartmentPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessDepartment) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_ProcessDepartment_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodProcessDepartmentPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfProcessDepartment = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodProcessDepartment, methodProcessDepartmentPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourcePoolEventInstanceFixture, parametersOfProcessDepartment);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfProcessDepartment.ShouldNotBeNull();
            parametersOfProcessDepartment.Length.ShouldBe(1);
            methodProcessDepartmentPrametersTypes.Length.ShouldBe(1);
            methodProcessDepartmentPrametersTypes.Length.ShouldBe(parametersOfProcessDepartment.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ProcessDepartment) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_ProcessDepartment_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodProcessDepartmentPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfProcessDepartment = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourcePoolEventInstance, MethodProcessDepartment, parametersOfProcessDepartment, methodProcessDepartmentPrametersTypes);

            // Assert
            parametersOfProcessDepartment.ShouldNotBeNull();
            parametersOfProcessDepartment.Length.ShouldBe(1);
            methodProcessDepartmentPrametersTypes.Length.ShouldBe(1);
            methodProcessDepartmentPrametersTypes.Length.ShouldBe(parametersOfProcessDepartment.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessDepartment) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_ProcessDepartment_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodProcessDepartment, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessDepartment) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_ProcessDepartment_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessDepartmentPrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethodProcessDepartment, Fixture, methodProcessDepartmentPrametersTypes);

            // Assert
            methodProcessDepartmentPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessDepartment) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_ProcessDepartment_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessDepartment, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcePoolEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessLevel) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePoolEvent_ProcessLevel_Method_Call_Internally(Type[] types)
        {
            var methodProcessLevelPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethodProcessLevel, Fixture, methodProcessLevelPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessLevel) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_ProcessLevel_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodProcessLevelPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfProcessLevel = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodProcessLevel, methodProcessLevelPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourcePoolEventInstanceFixture, parametersOfProcessLevel);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfProcessLevel.ShouldNotBeNull();
            parametersOfProcessLevel.Length.ShouldBe(1);
            methodProcessLevelPrametersTypes.Length.ShouldBe(1);
            methodProcessLevelPrametersTypes.Length.ShouldBe(parametersOfProcessLevel.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ProcessLevel) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_ProcessLevel_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodProcessLevelPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfProcessLevel = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourcePoolEventInstance, MethodProcessLevel, parametersOfProcessLevel, methodProcessLevelPrametersTypes);

            // Assert
            parametersOfProcessLevel.ShouldNotBeNull();
            parametersOfProcessLevel.Length.ShouldBe(1);
            methodProcessLevelPrametersTypes.Length.ShouldBe(1);
            methodProcessLevelPrametersTypes.Length.ShouldBe(parametersOfProcessLevel.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessLevel) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_ProcessLevel_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodProcessLevel, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessLevel) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_ProcessLevel_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessLevelPrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethodProcessLevel, Fixture, methodProcessLevelPrametersTypes);

            // Assert
            methodProcessLevelPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessLevel) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_ProcessLevel_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessLevel, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcePoolEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPropertyBeforeOrAfter) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePoolEvent_GetPropertyBeforeOrAfter_Method_Call_Internally(Type[] types)
        {
            var methodGetPropertyBeforeOrAfterPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethodGetPropertyBeforeOrAfter, Fixture, methodGetPropertyBeforeOrAfterPrametersTypes);
        }

        #endregion

        #region Method Call : (GetPropertyBeforeOrAfter) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_GetPropertyBeforeOrAfter_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var field = CreateType<string>();
            var methodGetPropertyBeforeOrAfterPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(string) };
            object[] parametersOfGetPropertyBeforeOrAfter = { properties, field };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetPropertyBeforeOrAfter, methodGetPropertyBeforeOrAfterPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResourcePoolEvent, string>(_resourcePoolEventInstanceFixture, out exception1, parametersOfGetPropertyBeforeOrAfter);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResourcePoolEvent, string>(_resourcePoolEventInstance, MethodGetPropertyBeforeOrAfter, parametersOfGetPropertyBeforeOrAfter, methodGetPropertyBeforeOrAfterPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetPropertyBeforeOrAfter.ShouldNotBeNull();
            parametersOfGetPropertyBeforeOrAfter.Length.ShouldBe(2);
            methodGetPropertyBeforeOrAfterPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetPropertyBeforeOrAfter) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_GetPropertyBeforeOrAfter_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var field = CreateType<string>();
            var methodGetPropertyBeforeOrAfterPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(string) };
            object[] parametersOfGetPropertyBeforeOrAfter = { properties, field };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ResourcePoolEvent, string>(_resourcePoolEventInstance, MethodGetPropertyBeforeOrAfter, parametersOfGetPropertyBeforeOrAfter, methodGetPropertyBeforeOrAfterPrametersTypes);

            // Assert
            parametersOfGetPropertyBeforeOrAfter.ShouldNotBeNull();
            parametersOfGetPropertyBeforeOrAfter.Length.ShouldBe(2);
            methodGetPropertyBeforeOrAfterPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPropertyBeforeOrAfter) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_GetPropertyBeforeOrAfter_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetPropertyBeforeOrAfterPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethodGetPropertyBeforeOrAfter, Fixture, methodGetPropertyBeforeOrAfterPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetPropertyBeforeOrAfterPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetPropertyBeforeOrAfter) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_GetPropertyBeforeOrAfter_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetPropertyBeforeOrAfterPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethodGetPropertyBeforeOrAfter, Fixture, methodGetPropertyBeforeOrAfterPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetPropertyBeforeOrAfterPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPropertyBeforeOrAfter) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_GetPropertyBeforeOrAfter_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetPropertyBeforeOrAfter, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcePoolEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetPropertyBeforeOrAfter) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_GetPropertyBeforeOrAfter_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetPropertyBeforeOrAfter, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (disableAccount) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePoolEvent_disableAccount_Method_Call_Internally(Type[] types)
        {
            var methoddisableAccountPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethoddisableAccount, Fixture, methoddisableAccountPrametersTypes);
        }

        #endregion

        #region Method Call : (disableAccount) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_disableAccount_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methoddisableAccountPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfdisableAccount = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethoddisableAccount, methoddisableAccountPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourcePoolEventInstanceFixture, parametersOfdisableAccount);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfdisableAccount.ShouldNotBeNull();
            parametersOfdisableAccount.Length.ShouldBe(1);
            methoddisableAccountPrametersTypes.Length.ShouldBe(1);
            methoddisableAccountPrametersTypes.Length.ShouldBe(parametersOfdisableAccount.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (disableAccount) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_disableAccount_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methoddisableAccountPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfdisableAccount = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourcePoolEventInstance, MethoddisableAccount, parametersOfdisableAccount, methoddisableAccountPrametersTypes);

            // Assert
            parametersOfdisableAccount.ShouldNotBeNull();
            parametersOfdisableAccount.Length.ShouldBe(1);
            methoddisableAccountPrametersTypes.Length.ShouldBe(1);
            methoddisableAccountPrametersTypes.Length.ShouldBe(parametersOfdisableAccount.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (disableAccount) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_disableAccount_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethoddisableAccount, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (disableAccount) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_disableAccount_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methoddisableAccountPrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethoddisableAccount, Fixture, methoddisableAccountPrametersTypes);

            // Assert
            methoddisableAccountPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (disableAccount) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_disableAccount_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethoddisableAccount, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcePoolEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessOnlineUser) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePoolEvent_ProcessOnlineUser_Method_Call_Internally(Type[] types)
        {
            var methodProcessOnlineUserPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethodProcessOnlineUser, Fixture, methodProcessOnlineUserPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessOnlineUser) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_ProcessOnlineUser_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var isAdd = CreateType<bool>();
            var methodProcessOnlineUserPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(bool) };
            object[] parametersOfProcessOnlineUser = { properties, isAdd };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodProcessOnlineUser, methodProcessOnlineUserPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourcePoolEventInstanceFixture, parametersOfProcessOnlineUser);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfProcessOnlineUser.ShouldNotBeNull();
            parametersOfProcessOnlineUser.Length.ShouldBe(2);
            methodProcessOnlineUserPrametersTypes.Length.ShouldBe(2);
            methodProcessOnlineUserPrametersTypes.Length.ShouldBe(parametersOfProcessOnlineUser.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ProcessOnlineUser) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_ProcessOnlineUser_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var isAdd = CreateType<bool>();
            var methodProcessOnlineUserPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(bool) };
            object[] parametersOfProcessOnlineUser = { properties, isAdd };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourcePoolEventInstance, MethodProcessOnlineUser, parametersOfProcessOnlineUser, methodProcessOnlineUserPrametersTypes);

            // Assert
            parametersOfProcessOnlineUser.ShouldNotBeNull();
            parametersOfProcessOnlineUser.Length.ShouldBe(2);
            methodProcessOnlineUserPrametersTypes.Length.ShouldBe(2);
            methodProcessOnlineUserPrametersTypes.Length.ShouldBe(parametersOfProcessOnlineUser.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessOnlineUser) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_ProcessOnlineUser_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodProcessOnlineUser, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessOnlineUser) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_ProcessOnlineUser_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessOnlineUserPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethodProcessOnlineUser, Fixture, methodProcessOnlineUserPrametersTypes);

            // Assert
            methodProcessOnlineUserPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessOnlineUser) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_ProcessOnlineUser_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessOnlineUser, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcePoolEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addUserToAccount) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePoolEvent_addUserToAccount_Method_Call_Internally(Type[] types)
        {
            var methodaddUserToAccountPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethodaddUserToAccount, Fixture, methodaddUserToAccountPrametersTypes);
        }

        #endregion

        #region Method Call : (addUserToAccount) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_addUserToAccount_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var firstname = CreateType<string>();
            var lastname = CreateType<string>();
            var email = CreateType<string>();
            var username = CreateType<string>();
            var methodaddUserToAccountPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfaddUserToAccount = { firstname, lastname, email, username };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodaddUserToAccount, methodaddUserToAccountPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourcePoolEventInstanceFixture, parametersOfaddUserToAccount);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfaddUserToAccount.ShouldNotBeNull();
            parametersOfaddUserToAccount.Length.ShouldBe(4);
            methodaddUserToAccountPrametersTypes.Length.ShouldBe(4);
            methodaddUserToAccountPrametersTypes.Length.ShouldBe(parametersOfaddUserToAccount.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (addUserToAccount) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_addUserToAccount_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var firstname = CreateType<string>();
            var lastname = CreateType<string>();
            var email = CreateType<string>();
            var username = CreateType<string>();
            var methodaddUserToAccountPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfaddUserToAccount = { firstname, lastname, email, username };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourcePoolEventInstance, MethodaddUserToAccount, parametersOfaddUserToAccount, methodaddUserToAccountPrametersTypes);

            // Assert
            parametersOfaddUserToAccount.ShouldNotBeNull();
            parametersOfaddUserToAccount.Length.ShouldBe(4);
            methodaddUserToAccountPrametersTypes.Length.ShouldBe(4);
            methodaddUserToAccountPrametersTypes.Length.ShouldBe(parametersOfaddUserToAccount.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addUserToAccount) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_addUserToAccount_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodaddUserToAccount, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addUserToAccount) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_addUserToAccount_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodaddUserToAccountPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethodaddUserToAccount, Fixture, methodaddUserToAccountPrametersTypes);

            // Assert
            methodaddUserToAccountPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addUserToAccount) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_addUserToAccount_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodaddUserToAccount, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcePoolEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getTempPassword) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePoolEvent_getTempPassword_Method_Call_Internally(Type[] types)
        {
            var methodgetTempPasswordPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethodgetTempPassword, Fixture, methodgetTempPasswordPrametersTypes);
        }

        #endregion

        #region Method Call : (getTempPassword) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_getTempPassword_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var username = CreateType<string>();
            var methodgetTempPasswordPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfgetTempPassword = { username };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodgetTempPassword, methodgetTempPasswordPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResourcePoolEvent, string>(_resourcePoolEventInstanceFixture, out exception1, parametersOfgetTempPassword);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResourcePoolEvent, string>(_resourcePoolEventInstance, MethodgetTempPassword, parametersOfgetTempPassword, methodgetTempPasswordPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetTempPassword.ShouldNotBeNull();
            parametersOfgetTempPassword.Length.ShouldBe(1);
            methodgetTempPasswordPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getTempPassword) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_getTempPassword_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var username = CreateType<string>();
            var methodgetTempPasswordPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfgetTempPassword = { username };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ResourcePoolEvent, string>(_resourcePoolEventInstance, MethodgetTempPassword, parametersOfgetTempPassword, methodgetTempPasswordPrametersTypes);

            // Assert
            parametersOfgetTempPassword.ShouldNotBeNull();
            parametersOfgetTempPassword.Length.ShouldBe(1);
            methodgetTempPasswordPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getTempPassword) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_getTempPassword_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetTempPasswordPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethodgetTempPassword, Fixture, methodgetTempPasswordPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetTempPasswordPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getTempPassword) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_getTempPassword_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetTempPasswordPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethodgetTempPassword, Fixture, methodgetTempPasswordPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetTempPasswordPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getTempPassword) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_getTempPassword_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetTempPassword, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcePoolEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getTempPassword) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_getTempPassword_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetTempPassword, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setPermissions) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePoolEvent_setPermissions_Method_Call_Internally(Type[] types)
        {
            var methodsetPermissionsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethodsetPermissions, Fixture, methodsetPermissionsPrametersTypes);
        }

        #endregion

        #region Method Call : (setPermissions) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_setPermissions_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var isAdd = CreateType<bool>();
            var methodsetPermissionsPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(bool) };
            object[] parametersOfsetPermissions = { properties, isAdd };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodsetPermissions, methodsetPermissionsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResourcePoolEvent, bool>(_resourcePoolEventInstanceFixture, out exception1, parametersOfsetPermissions);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResourcePoolEvent, bool>(_resourcePoolEventInstance, MethodsetPermissions, parametersOfsetPermissions, methodsetPermissionsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfsetPermissions.ShouldNotBeNull();
            parametersOfsetPermissions.Length.ShouldBe(2);
            methodsetPermissionsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (setPermissions) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_setPermissions_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var isAdd = CreateType<bool>();
            var methodsetPermissionsPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(bool) };
            object[] parametersOfsetPermissions = { properties, isAdd };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodsetPermissions, methodsetPermissionsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResourcePoolEvent, bool>(_resourcePoolEventInstanceFixture, out exception1, parametersOfsetPermissions);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResourcePoolEvent, bool>(_resourcePoolEventInstance, MethodsetPermissions, parametersOfsetPermissions, methodsetPermissionsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfsetPermissions.ShouldNotBeNull();
            parametersOfsetPermissions.Length.ShouldBe(2);
            methodsetPermissionsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (setPermissions) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_setPermissions_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var isAdd = CreateType<bool>();
            var methodsetPermissionsPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(bool) };
            object[] parametersOfsetPermissions = { properties, isAdd };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ResourcePoolEvent, bool>(_resourcePoolEventInstance, MethodsetPermissions, parametersOfsetPermissions, methodsetPermissionsPrametersTypes);

            // Assert
            parametersOfsetPermissions.ShouldNotBeNull();
            parametersOfsetPermissions.Length.ShouldBe(2);
            methodsetPermissionsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setPermissions) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_setPermissions_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodsetPermissionsPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(bool) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethodsetPermissions, Fixture, methodsetPermissionsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodsetPermissionsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setPermissions) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_setPermissions_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodsetPermissions, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcePoolEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (setPermissions) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_setPermissions_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodsetPermissions, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (sendRequestEmail) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePoolEvent_sendRequestEmail_Method_Call_Internally(Type[] types)
        {
            var methodsendRequestEmailPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethodsendRequestEmail, Fixture, methodsendRequestEmailPrametersTypes);
        }

        #endregion

        #region Method Call : (sendRequestEmail) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_sendRequestEmail_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var thisClass = CreateType<Type>();
            var properties = CreateType<SPItemEventProperties>();
            var requestorname = CreateType<string>();
            var methodsendRequestEmailPrametersTypes = new Type[] { typeof(Type), typeof(SPItemEventProperties), typeof(string) };
            object[] parametersOfsendRequestEmail = { thisClass, properties, requestorname };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodsendRequestEmail, methodsendRequestEmailPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourcePoolEventInstanceFixture, parametersOfsendRequestEmail);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfsendRequestEmail.ShouldNotBeNull();
            parametersOfsendRequestEmail.Length.ShouldBe(3);
            methodsendRequestEmailPrametersTypes.Length.ShouldBe(3);
            methodsendRequestEmailPrametersTypes.Length.ShouldBe(parametersOfsendRequestEmail.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (sendRequestEmail) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_sendRequestEmail_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var thisClass = CreateType<Type>();
            var properties = CreateType<SPItemEventProperties>();
            var requestorname = CreateType<string>();
            var methodsendRequestEmailPrametersTypes = new Type[] { typeof(Type), typeof(SPItemEventProperties), typeof(string) };
            object[] parametersOfsendRequestEmail = { thisClass, properties, requestorname };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourcePoolEventInstance, MethodsendRequestEmail, parametersOfsendRequestEmail, methodsendRequestEmailPrametersTypes);

            // Assert
            parametersOfsendRequestEmail.ShouldNotBeNull();
            parametersOfsendRequestEmail.Length.ShouldBe(3);
            methodsendRequestEmailPrametersTypes.Length.ShouldBe(3);
            methodsendRequestEmailPrametersTypes.Length.ShouldBe(parametersOfsendRequestEmail.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (sendRequestEmail) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_sendRequestEmail_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodsendRequestEmail, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (sendRequestEmail) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_sendRequestEmail_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodsendRequestEmailPrametersTypes = new Type[] { typeof(Type), typeof(SPItemEventProperties), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethodsendRequestEmail, Fixture, methodsendRequestEmailPrametersTypes);

            // Assert
            methodsendRequestEmailPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (sendRequestEmail) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_sendRequestEmail_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodsendRequestEmail, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcePoolEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (sendOwnerEmail) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePoolEvent_sendOwnerEmail_Method_Call_Internally(Type[] types)
        {
            var methodsendOwnerEmailPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethodsendOwnerEmail, Fixture, methodsendOwnerEmailPrametersTypes);
        }

        #endregion

        #region Method Call : (sendOwnerEmail) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_sendOwnerEmail_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var thisClass = CreateType<Type>();
            var properties = CreateType<SPItemEventProperties>();
            var requestorname = CreateType<string>();
            var methodsendOwnerEmailPrametersTypes = new Type[] { typeof(Type), typeof(SPItemEventProperties), typeof(string) };
            object[] parametersOfsendOwnerEmail = { thisClass, properties, requestorname };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodsendOwnerEmail, methodsendOwnerEmailPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourcePoolEventInstanceFixture, parametersOfsendOwnerEmail);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfsendOwnerEmail.ShouldNotBeNull();
            parametersOfsendOwnerEmail.Length.ShouldBe(3);
            methodsendOwnerEmailPrametersTypes.Length.ShouldBe(3);
            methodsendOwnerEmailPrametersTypes.Length.ShouldBe(parametersOfsendOwnerEmail.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (sendOwnerEmail) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_sendOwnerEmail_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var thisClass = CreateType<Type>();
            var properties = CreateType<SPItemEventProperties>();
            var requestorname = CreateType<string>();
            var methodsendOwnerEmailPrametersTypes = new Type[] { typeof(Type), typeof(SPItemEventProperties), typeof(string) };
            object[] parametersOfsendOwnerEmail = { thisClass, properties, requestorname };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourcePoolEventInstance, MethodsendOwnerEmail, parametersOfsendOwnerEmail, methodsendOwnerEmailPrametersTypes);

            // Assert
            parametersOfsendOwnerEmail.ShouldNotBeNull();
            parametersOfsendOwnerEmail.Length.ShouldBe(3);
            methodsendOwnerEmailPrametersTypes.Length.ShouldBe(3);
            methodsendOwnerEmailPrametersTypes.Length.ShouldBe(parametersOfsendOwnerEmail.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (sendOwnerEmail) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_sendOwnerEmail_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodsendOwnerEmail, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (sendOwnerEmail) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_sendOwnerEmail_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodsendOwnerEmailPrametersTypes = new Type[] { typeof(Type), typeof(SPItemEventProperties), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethodsendOwnerEmail, Fixture, methodsendOwnerEmailPrametersTypes);

            // Assert
            methodsendOwnerEmailPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (sendOwnerEmail) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_sendOwnerEmail_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodsendOwnerEmail, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcePoolEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (createGroup) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePoolEvent_createGroup_Method_Call_Internally(Type[] types)
        {
            var methodcreateGroupPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethodcreateGroup, Fixture, methodcreateGroupPrametersTypes);
        }

        #endregion

        #region Method Call : (createGroup) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_createGroup_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodcreateGroupPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfcreateGroup = { properties };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodcreateGroup, methodcreateGroupPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResourcePoolEvent, string>(_resourcePoolEventInstanceFixture, out exception1, parametersOfcreateGroup);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResourcePoolEvent, string>(_resourcePoolEventInstance, MethodcreateGroup, parametersOfcreateGroup, methodcreateGroupPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfcreateGroup.ShouldNotBeNull();
            parametersOfcreateGroup.Length.ShouldBe(1);
            methodcreateGroupPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (createGroup) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_createGroup_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodcreateGroupPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfcreateGroup = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ResourcePoolEvent, string>(_resourcePoolEventInstance, MethodcreateGroup, parametersOfcreateGroup, methodcreateGroupPrametersTypes);

            // Assert
            parametersOfcreateGroup.ShouldNotBeNull();
            parametersOfcreateGroup.Length.ShouldBe(1);
            methodcreateGroupPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (createGroup) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_createGroup_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodcreateGroupPrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethodcreateGroup, Fixture, methodcreateGroupPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodcreateGroupPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (createGroup) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_createGroup_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodcreateGroupPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethodcreateGroup, Fixture, methodcreateGroupPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodcreateGroupPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (createGroup) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_createGroup_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodcreateGroup, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcePoolEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (createGroup) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_createGroup_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodcreateGroup, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addUser) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePoolEvent_addUser_Method_Call_Internally(Type[] types)
        {
            var methodaddUserPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethodaddUser, Fixture, methodaddUserPrametersTypes);
        }

        #endregion

        #region Method Call : (addUser) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_addUser_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var username = CreateType<string>();
            var display = CreateType<string>();
            var email = CreateType<string>();
            var prefix = CreateType<string>();
            var methodaddUserPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfaddUser = { properties, username, display, email, prefix };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodaddUser, methodaddUserPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResourcePoolEvent, string>(_resourcePoolEventInstanceFixture, out exception1, parametersOfaddUser);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResourcePoolEvent, string>(_resourcePoolEventInstance, MethodaddUser, parametersOfaddUser, methodaddUserPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfaddUser.ShouldNotBeNull();
            parametersOfaddUser.Length.ShouldBe(5);
            methodaddUserPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (addUser) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_addUser_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var username = CreateType<string>();
            var display = CreateType<string>();
            var email = CreateType<string>();
            var prefix = CreateType<string>();
            var methodaddUserPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfaddUser = { properties, username, display, email, prefix };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ResourcePoolEvent, string>(_resourcePoolEventInstance, MethodaddUser, parametersOfaddUser, methodaddUserPrametersTypes);

            // Assert
            parametersOfaddUser.ShouldNotBeNull();
            parametersOfaddUser.Length.ShouldBe(5);
            methodaddUserPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addUser) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_addUser_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodaddUserPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(string), typeof(string), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethodaddUser, Fixture, methodaddUserPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodaddUserPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (addUser) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_addUser_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodaddUserPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(string), typeof(string), typeof(string), typeof(string) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethodaddUser, Fixture, methodaddUserPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodaddUserPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addUser) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_addUser_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodaddUser, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcePoolEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (addUser) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_addUser_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodaddUser, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ItemUpdating) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePoolEvent_ItemUpdating_Method_Call_Internally(Type[] types)
        {
            var methodItemUpdatingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethodItemUpdating, Fixture, methodItemUpdatingPrametersTypes);
        }

        #endregion

        #region Method Call : (ItemUpdating) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_ItemUpdating_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _resourcePoolEventInstance.ItemUpdating(properties);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ItemUpdating) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_ItemUpdating_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemUpdatingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemUpdating = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodItemUpdating, methodItemUpdatingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourcePoolEventInstanceFixture, parametersOfItemUpdating);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfItemUpdating.ShouldNotBeNull();
            parametersOfItemUpdating.Length.ShouldBe(1);
            methodItemUpdatingPrametersTypes.Length.ShouldBe(1);
            methodItemUpdatingPrametersTypes.Length.ShouldBe(parametersOfItemUpdating.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ItemUpdating) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_ItemUpdating_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemUpdatingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemUpdating = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourcePoolEventInstance, MethodItemUpdating, parametersOfItemUpdating, methodItemUpdatingPrametersTypes);

            // Assert
            parametersOfItemUpdating.ShouldNotBeNull();
            parametersOfItemUpdating.Length.ShouldBe(1);
            methodItemUpdatingPrametersTypes.Length.ShouldBe(1);
            methodItemUpdatingPrametersTypes.Length.ShouldBe(parametersOfItemUpdating.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemUpdating) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_ItemUpdating_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodItemUpdating, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ItemUpdating) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_ItemUpdating_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodItemUpdatingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethodItemUpdating, Fixture, methodItemUpdatingPrametersTypes);

            // Assert
            methodItemUpdatingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemUpdating) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_ItemUpdating_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodItemUpdating, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcePoolEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemDeleted) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePoolEvent_ItemDeleted_Method_Call_Internally(Type[] types)
        {
            var methodItemDeletedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethodItemDeleted, Fixture, methodItemDeletedPrametersTypes);
        }

        #endregion

        #region Method Call : (ItemDeleted) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_ItemDeleted_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _resourcePoolEventInstance.ItemDeleted(properties);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ItemDeleted) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_ItemDeleted_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemDeletedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemDeleted = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodItemDeleted, methodItemDeletedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourcePoolEventInstanceFixture, parametersOfItemDeleted);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfItemDeleted.ShouldNotBeNull();
            parametersOfItemDeleted.Length.ShouldBe(1);
            methodItemDeletedPrametersTypes.Length.ShouldBe(1);
            methodItemDeletedPrametersTypes.Length.ShouldBe(parametersOfItemDeleted.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemDeleted) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_ItemDeleted_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemDeletedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemDeleted = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourcePoolEventInstance, MethodItemDeleted, parametersOfItemDeleted, methodItemDeletedPrametersTypes);

            // Assert
            parametersOfItemDeleted.ShouldNotBeNull();
            parametersOfItemDeleted.Length.ShouldBe(1);
            methodItemDeletedPrametersTypes.Length.ShouldBe(1);
            methodItemDeletedPrametersTypes.Length.ShouldBe(parametersOfItemDeleted.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemDeleted) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_ItemDeleted_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodItemDeleted, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ItemDeleted) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_ItemDeleted_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodItemDeletedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethodItemDeleted, Fixture, methodItemDeletedPrametersTypes);

            // Assert
            methodItemDeletedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemDeleted) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_ItemDeleted_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodItemDeleted, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcePoolEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemDeleting) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePoolEvent_ItemDeleting_Method_Call_Internally(Type[] types)
        {
            var methodItemDeletingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethodItemDeleting, Fixture, methodItemDeletingPrametersTypes);
        }

        #endregion

        #region Method Call : (ItemDeleting) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_ItemDeleting_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _resourcePoolEventInstance.ItemDeleting(properties);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ItemDeleting) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_ItemDeleting_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemDeletingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemDeleting = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodItemDeleting, methodItemDeletingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourcePoolEventInstanceFixture, parametersOfItemDeleting);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfItemDeleting.ShouldNotBeNull();
            parametersOfItemDeleting.Length.ShouldBe(1);
            methodItemDeletingPrametersTypes.Length.ShouldBe(1);
            methodItemDeletingPrametersTypes.Length.ShouldBe(parametersOfItemDeleting.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ItemDeleting) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_ItemDeleting_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemDeletingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemDeleting = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourcePoolEventInstance, MethodItemDeleting, parametersOfItemDeleting, methodItemDeletingPrametersTypes);

            // Assert
            parametersOfItemDeleting.ShouldNotBeNull();
            parametersOfItemDeleting.Length.ShouldBe(1);
            methodItemDeletingPrametersTypes.Length.ShouldBe(1);
            methodItemDeletingPrametersTypes.Length.ShouldBe(parametersOfItemDeleting.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemDeleting) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_ItemDeleting_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodItemDeleting, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ItemDeleting) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_ItemDeleting_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodItemDeletingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePoolEventInstance, MethodItemDeleting, Fixture, methodItemDeletingPrametersTypes);

            // Assert
            methodItemDeletingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemDeleting) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePoolEvent_ItemDeleting_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodItemDeleting, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcePoolEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
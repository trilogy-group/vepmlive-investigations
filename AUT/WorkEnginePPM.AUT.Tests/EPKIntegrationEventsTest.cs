using System;
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

namespace WorkEnginePPM
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.EPKIntegrationEvents" />)
    ///     and namespace <see cref="WorkEnginePPM"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class EPKIntegrationEventsTest : AbstractBaseSetupTypedTest<EPKIntegrationEvents>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EPKIntegrationEvents) Initializer

        private const string MethodItemAdded = "ItemAdded";
        private const string MethodItemDeleting = "ItemDeleting";
        private const string MethodItemUpdating = "ItemUpdating";
        private const string MethodCheckProjectNameChange = "CheckProjectNameChange";
        private const string MethodUpdateDB = "UpdateDB";
        private const string MethodUpdateMicrosoftProject = "UpdateMicrosoftProject";
        private const string MethodUpdateGroupsNames = "UpdateGroupsNames";
        private const string MethodprocessItem = "processItem";
        private const string MethodUpdateItemXml = "UpdateItemXml";
        private const string MethodCloseItemXml = "CloseItemXml";
        private const string FieldProjectGroupVisitor = "ProjectGroupVisitor";
        private const string FieldProjectGroupMember = "ProjectGroupMember";
        private const string FieldProjectGroupOwner = "ProjectGroupOwner";
        private const string FieldPROJECT_CENTER_TITLE = "PROJECT_CENTER_TITLE";
        private const string FieldPROJECT_SCHEDULES_FOLDER_NAME = "PROJECT_SCHEDULES_FOLDER_NAME";
        private const string FieldMSPROJECT_FOLDER_NAME = "MSPROJECT_FOLDER_NAME";
        private const string FieldMSPROJECT_FILE_EXTENSION = "MSPROJECT_FILE_EXTENSION";
        private Type _ePKIntegrationEventsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private EPKIntegrationEvents _ePKIntegrationEventsInstance;
        private EPKIntegrationEvents _ePKIntegrationEventsInstanceFixture;

        #region General Initializer : Class (EPKIntegrationEvents) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EPKIntegrationEvents" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _ePKIntegrationEventsInstanceType = typeof(EPKIntegrationEvents);
            _ePKIntegrationEventsInstanceFixture = Create(true);
            _ePKIntegrationEventsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (EPKIntegrationEvents)

        #region General Initializer : Class (EPKIntegrationEvents) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="EPKIntegrationEvents" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodItemAdded, 0)]
        [TestCase(MethodItemDeleting, 0)]
        [TestCase(MethodItemUpdating, 0)]
        [TestCase(MethodCheckProjectNameChange, 0)]
        [TestCase(MethodUpdateDB, 0)]
        [TestCase(MethodUpdateMicrosoftProject, 0)]
        [TestCase(MethodUpdateGroupsNames, 0)]
        [TestCase(MethodprocessItem, 0)]
        [TestCase(MethodUpdateItemXml, 0)]
        [TestCase(MethodCloseItemXml, 0)]
        public void AUT_EPKIntegrationEvents_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_ePKIntegrationEventsInstanceFixture, 
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
        ///     Class (<see cref="EPKIntegrationEvents" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_EPKIntegrationEvents_Is_Instance_Present_Test()
        {
            // Assert
            _ePKIntegrationEventsInstanceType.ShouldNotBeNull();
            _ePKIntegrationEventsInstance.ShouldNotBeNull();
            _ePKIntegrationEventsInstanceFixture.ShouldNotBeNull();
            _ePKIntegrationEventsInstance.ShouldBeAssignableTo<EPKIntegrationEvents>();
            _ePKIntegrationEventsInstanceFixture.ShouldBeAssignableTo<EPKIntegrationEvents>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (EPKIntegrationEvents) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_EPKIntegrationEvents_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            EPKIntegrationEvents instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _ePKIntegrationEventsInstanceType.ShouldNotBeNull();
            _ePKIntegrationEventsInstance.ShouldNotBeNull();
            _ePKIntegrationEventsInstanceFixture.ShouldNotBeNull();
            _ePKIntegrationEventsInstance.ShouldBeAssignableTo<EPKIntegrationEvents>();
            _ePKIntegrationEventsInstanceFixture.ShouldBeAssignableTo<EPKIntegrationEvents>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="EPKIntegrationEvents" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodItemAdded)]
        [TestCase(MethodItemDeleting)]
        [TestCase(MethodItemUpdating)]
        [TestCase(MethodCheckProjectNameChange)]
        [TestCase(MethodUpdateDB)]
        [TestCase(MethodUpdateMicrosoftProject)]
        [TestCase(MethodUpdateGroupsNames)]
        [TestCase(MethodprocessItem)]
        [TestCase(MethodUpdateItemXml)]
        [TestCase(MethodCloseItemXml)]
        public void AUT_EPKIntegrationEvents_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<EPKIntegrationEvents>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPKIntegrationEvents_ItemAdded_Method_Call_Internally(Type[] types)
        {
            var methodItemAddedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePKIntegrationEventsInstance, MethodItemAdded, Fixture, methodItemAddedPrametersTypes);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_ItemAdded_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePKIntegrationEventsInstance.ItemAdded(properties);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_ItemAdded_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemAddedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemAdded = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodItemAdded, methodItemAddedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePKIntegrationEventsInstanceFixture, parametersOfItemAdded);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfItemAdded.ShouldNotBeNull();
            parametersOfItemAdded.Length.ShouldBe(1);
            methodItemAddedPrametersTypes.Length.ShouldBe(1);
            methodItemAddedPrametersTypes.Length.ShouldBe(parametersOfItemAdded.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_ItemAdded_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemAddedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemAdded = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ePKIntegrationEventsInstance, MethodItemAdded, parametersOfItemAdded, methodItemAddedPrametersTypes);

            // Assert
            parametersOfItemAdded.ShouldNotBeNull();
            parametersOfItemAdded.Length.ShouldBe(1);
            methodItemAddedPrametersTypes.Length.ShouldBe(1);
            methodItemAddedPrametersTypes.Length.ShouldBe(parametersOfItemAdded.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_ItemAdded_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodItemAdded, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_ItemAdded_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodItemAddedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePKIntegrationEventsInstance, MethodItemAdded, Fixture, methodItemAddedPrametersTypes);

            // Assert
            methodItemAddedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_ItemAdded_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodItemAdded, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ePKIntegrationEventsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemDeleting) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPKIntegrationEvents_ItemDeleting_Method_Call_Internally(Type[] types)
        {
            var methodItemDeletingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePKIntegrationEventsInstance, MethodItemDeleting, Fixture, methodItemDeletingPrametersTypes);
        }

        #endregion

        #region Method Call : (ItemDeleting) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_ItemDeleting_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePKIntegrationEventsInstance.ItemDeleting(properties);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ItemDeleting) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_ItemDeleting_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemDeletingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemDeleting = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodItemDeleting, methodItemDeletingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePKIntegrationEventsInstanceFixture, parametersOfItemDeleting);

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
        public void AUT_EPKIntegrationEvents_ItemDeleting_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemDeletingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemDeleting = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ePKIntegrationEventsInstance, MethodItemDeleting, parametersOfItemDeleting, methodItemDeletingPrametersTypes);

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
        public void AUT_EPKIntegrationEvents_ItemDeleting_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_EPKIntegrationEvents_ItemDeleting_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodItemDeletingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePKIntegrationEventsInstance, MethodItemDeleting, Fixture, methodItemDeletingPrametersTypes);

            // Assert
            methodItemDeletingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemDeleting) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_ItemDeleting_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodItemDeleting, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ePKIntegrationEventsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemUpdating) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPKIntegrationEvents_ItemUpdating_Method_Call_Internally(Type[] types)
        {
            var methodItemUpdatingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePKIntegrationEventsInstance, MethodItemUpdating, Fixture, methodItemUpdatingPrametersTypes);
        }

        #endregion

        #region Method Call : (ItemUpdating) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_ItemUpdating_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePKIntegrationEventsInstance.ItemUpdating(properties);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ItemUpdating) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_ItemUpdating_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemUpdatingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemUpdating = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodItemUpdating, methodItemUpdatingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePKIntegrationEventsInstanceFixture, parametersOfItemUpdating);

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
        public void AUT_EPKIntegrationEvents_ItemUpdating_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemUpdatingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemUpdating = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ePKIntegrationEventsInstance, MethodItemUpdating, parametersOfItemUpdating, methodItemUpdatingPrametersTypes);

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
        public void AUT_EPKIntegrationEvents_ItemUpdating_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_EPKIntegrationEvents_ItemUpdating_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodItemUpdatingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePKIntegrationEventsInstance, MethodItemUpdating, Fixture, methodItemUpdatingPrametersTypes);

            // Assert
            methodItemUpdatingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemUpdating) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_ItemUpdating_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodItemUpdating, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ePKIntegrationEventsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CheckProjectNameChange) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPKIntegrationEvents_CheckProjectNameChange_Method_Call_Internally(Type[] types)
        {
            var methodCheckProjectNameChangePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePKIntegrationEventsInstance, MethodCheckProjectNameChange, Fixture, methodCheckProjectNameChangePrametersTypes);
        }

        #endregion

        #region Method Call : (CheckProjectNameChange) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_CheckProjectNameChange_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodCheckProjectNameChangePrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfCheckProjectNameChange = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCheckProjectNameChange, methodCheckProjectNameChangePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePKIntegrationEventsInstanceFixture, parametersOfCheckProjectNameChange);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCheckProjectNameChange.ShouldNotBeNull();
            parametersOfCheckProjectNameChange.Length.ShouldBe(1);
            methodCheckProjectNameChangePrametersTypes.Length.ShouldBe(1);
            methodCheckProjectNameChangePrametersTypes.Length.ShouldBe(parametersOfCheckProjectNameChange.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CheckProjectNameChange) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_CheckProjectNameChange_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodCheckProjectNameChangePrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfCheckProjectNameChange = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ePKIntegrationEventsInstance, MethodCheckProjectNameChange, parametersOfCheckProjectNameChange, methodCheckProjectNameChangePrametersTypes);

            // Assert
            parametersOfCheckProjectNameChange.ShouldNotBeNull();
            parametersOfCheckProjectNameChange.Length.ShouldBe(1);
            methodCheckProjectNameChangePrametersTypes.Length.ShouldBe(1);
            methodCheckProjectNameChangePrametersTypes.Length.ShouldBe(parametersOfCheckProjectNameChange.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CheckProjectNameChange) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_CheckProjectNameChange_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCheckProjectNameChange, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CheckProjectNameChange) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_CheckProjectNameChange_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCheckProjectNameChangePrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePKIntegrationEventsInstance, MethodCheckProjectNameChange, Fixture, methodCheckProjectNameChangePrametersTypes);

            // Assert
            methodCheckProjectNameChangePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CheckProjectNameChange) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_CheckProjectNameChange_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCheckProjectNameChange, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ePKIntegrationEventsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateDB) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPKIntegrationEvents_UpdateDB_Method_Call_Internally(Type[] types)
        {
            var methodUpdateDBPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePKIntegrationEventsInstance, MethodUpdateDB, Fixture, methodUpdateDBPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateDB) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_UpdateDB_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var con = CreateType<SqlConnection>();
            var projectNameNew = CreateType<string>();
            var methodUpdateDBPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(SqlConnection), typeof(string) };
            object[] parametersOfUpdateDB = { properties, con, projectNameNew };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateDB, methodUpdateDBPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePKIntegrationEventsInstanceFixture, parametersOfUpdateDB);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateDB.ShouldNotBeNull();
            parametersOfUpdateDB.Length.ShouldBe(3);
            methodUpdateDBPrametersTypes.Length.ShouldBe(3);
            methodUpdateDBPrametersTypes.Length.ShouldBe(parametersOfUpdateDB.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateDB) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_UpdateDB_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var con = CreateType<SqlConnection>();
            var projectNameNew = CreateType<string>();
            var methodUpdateDBPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(SqlConnection), typeof(string) };
            object[] parametersOfUpdateDB = { properties, con, projectNameNew };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ePKIntegrationEventsInstance, MethodUpdateDB, parametersOfUpdateDB, methodUpdateDBPrametersTypes);

            // Assert
            parametersOfUpdateDB.ShouldNotBeNull();
            parametersOfUpdateDB.Length.ShouldBe(3);
            methodUpdateDBPrametersTypes.Length.ShouldBe(3);
            methodUpdateDBPrametersTypes.Length.ShouldBe(parametersOfUpdateDB.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateDB) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_UpdateDB_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateDB, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateDB) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_UpdateDB_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateDBPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(SqlConnection), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePKIntegrationEventsInstance, MethodUpdateDB, Fixture, methodUpdateDBPrametersTypes);

            // Assert
            methodUpdateDBPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateDB) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_UpdateDB_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateDB, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ePKIntegrationEventsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateMicrosoftProject) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPKIntegrationEvents_UpdateMicrosoftProject_Method_Call_Internally(Type[] types)
        {
            var methodUpdateMicrosoftProjectPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePKIntegrationEventsInstance, MethodUpdateMicrosoftProject, Fixture, methodUpdateMicrosoftProjectPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateMicrosoftProject) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_UpdateMicrosoftProject_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var projectNameDB = CreateType<string>();
            var projectNameNew = CreateType<string>();
            var methodUpdateMicrosoftProjectPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(string), typeof(string) };
            object[] parametersOfUpdateMicrosoftProject = { properties, projectNameDB, projectNameNew };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateMicrosoftProject, methodUpdateMicrosoftProjectPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePKIntegrationEventsInstanceFixture, parametersOfUpdateMicrosoftProject);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateMicrosoftProject.ShouldNotBeNull();
            parametersOfUpdateMicrosoftProject.Length.ShouldBe(3);
            methodUpdateMicrosoftProjectPrametersTypes.Length.ShouldBe(3);
            methodUpdateMicrosoftProjectPrametersTypes.Length.ShouldBe(parametersOfUpdateMicrosoftProject.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateMicrosoftProject) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_UpdateMicrosoftProject_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var projectNameDB = CreateType<string>();
            var projectNameNew = CreateType<string>();
            var methodUpdateMicrosoftProjectPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(string), typeof(string) };
            object[] parametersOfUpdateMicrosoftProject = { properties, projectNameDB, projectNameNew };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ePKIntegrationEventsInstance, MethodUpdateMicrosoftProject, parametersOfUpdateMicrosoftProject, methodUpdateMicrosoftProjectPrametersTypes);

            // Assert
            parametersOfUpdateMicrosoftProject.ShouldNotBeNull();
            parametersOfUpdateMicrosoftProject.Length.ShouldBe(3);
            methodUpdateMicrosoftProjectPrametersTypes.Length.ShouldBe(3);
            methodUpdateMicrosoftProjectPrametersTypes.Length.ShouldBe(parametersOfUpdateMicrosoftProject.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateMicrosoftProject) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_UpdateMicrosoftProject_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateMicrosoftProject, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateMicrosoftProject) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_UpdateMicrosoftProject_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateMicrosoftProjectPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePKIntegrationEventsInstance, MethodUpdateMicrosoftProject, Fixture, methodUpdateMicrosoftProjectPrametersTypes);

            // Assert
            methodUpdateMicrosoftProjectPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateMicrosoftProject) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_UpdateMicrosoftProject_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateMicrosoftProject, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ePKIntegrationEventsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateGroupsNames) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPKIntegrationEvents_UpdateGroupsNames_Method_Call_Internally(Type[] types)
        {
            var methodUpdateGroupsNamesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePKIntegrationEventsInstance, MethodUpdateGroupsNames, Fixture, methodUpdateGroupsNamesPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateGroupsNames) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_UpdateGroupsNames_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var projectNameDB = CreateType<string>();
            var projectNameNew = CreateType<string>();
            var methodUpdateGroupsNamesPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(string), typeof(string) };
            object[] parametersOfUpdateGroupsNames = { properties, projectNameDB, projectNameNew };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateGroupsNames, methodUpdateGroupsNamesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePKIntegrationEventsInstanceFixture, parametersOfUpdateGroupsNames);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateGroupsNames.ShouldNotBeNull();
            parametersOfUpdateGroupsNames.Length.ShouldBe(3);
            methodUpdateGroupsNamesPrametersTypes.Length.ShouldBe(3);
            methodUpdateGroupsNamesPrametersTypes.Length.ShouldBe(parametersOfUpdateGroupsNames.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateGroupsNames) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_UpdateGroupsNames_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var projectNameDB = CreateType<string>();
            var projectNameNew = CreateType<string>();
            var methodUpdateGroupsNamesPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(string), typeof(string) };
            object[] parametersOfUpdateGroupsNames = { properties, projectNameDB, projectNameNew };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ePKIntegrationEventsInstance, MethodUpdateGroupsNames, parametersOfUpdateGroupsNames, methodUpdateGroupsNamesPrametersTypes);

            // Assert
            parametersOfUpdateGroupsNames.ShouldNotBeNull();
            parametersOfUpdateGroupsNames.Length.ShouldBe(3);
            methodUpdateGroupsNamesPrametersTypes.Length.ShouldBe(3);
            methodUpdateGroupsNamesPrametersTypes.Length.ShouldBe(parametersOfUpdateGroupsNames.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateGroupsNames) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_UpdateGroupsNames_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateGroupsNames, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateGroupsNames) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_UpdateGroupsNames_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateGroupsNamesPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePKIntegrationEventsInstance, MethodUpdateGroupsNames, Fixture, methodUpdateGroupsNamesPrametersTypes);

            // Assert
            methodUpdateGroupsNamesPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateGroupsNames) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_UpdateGroupsNames_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateGroupsNames, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ePKIntegrationEventsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processItem) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPKIntegrationEvents_processItem_Method_Call_Internally(Type[] types)
        {
            var methodprocessItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePKIntegrationEventsInstance, MethodprocessItem, Fixture, methodprocessItemPrametersTypes);
        }

        #endregion

        #region Method Call : (processItem) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_processItem_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodprocessItemPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfprocessItem = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodprocessItem, methodprocessItemPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePKIntegrationEventsInstanceFixture, parametersOfprocessItem);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfprocessItem.ShouldNotBeNull();
            parametersOfprocessItem.Length.ShouldBe(1);
            methodprocessItemPrametersTypes.Length.ShouldBe(1);
            methodprocessItemPrametersTypes.Length.ShouldBe(parametersOfprocessItem.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (processItem) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_processItem_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodprocessItemPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfprocessItem = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ePKIntegrationEventsInstance, MethodprocessItem, parametersOfprocessItem, methodprocessItemPrametersTypes);

            // Assert
            parametersOfprocessItem.ShouldNotBeNull();
            parametersOfprocessItem.Length.ShouldBe(1);
            methodprocessItemPrametersTypes.Length.ShouldBe(1);
            methodprocessItemPrametersTypes.Length.ShouldBe(parametersOfprocessItem.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processItem) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_processItem_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodprocessItem, 0);
            const int parametersCount = 1;

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
        public void AUT_EPKIntegrationEvents_processItem_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodprocessItemPrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePKIntegrationEventsInstance, MethodprocessItem, Fixture, methodprocessItemPrametersTypes);

            // Assert
            methodprocessItemPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processItem) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_processItem_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprocessItem, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ePKIntegrationEventsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateItemXml) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPKIntegrationEvents_UpdateItemXml_Method_Call_Internally(Type[] types)
        {
            var methodUpdateItemXmlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePKIntegrationEventsInstance, MethodUpdateItemXml, Fixture, methodUpdateItemXmlPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateItemXml) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_UpdateItemXml_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodUpdateItemXmlPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfUpdateItemXml = { xml, web };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateItemXml, methodUpdateItemXmlPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPKIntegrationEvents, string>(_ePKIntegrationEventsInstanceFixture, out exception1, parametersOfUpdateItemXml);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPKIntegrationEvents, string>(_ePKIntegrationEventsInstance, MethodUpdateItemXml, parametersOfUpdateItemXml, methodUpdateItemXmlPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfUpdateItemXml.ShouldNotBeNull();
            parametersOfUpdateItemXml.Length.ShouldBe(2);
            methodUpdateItemXmlPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (UpdateItemXml) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_UpdateItemXml_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodUpdateItemXmlPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfUpdateItemXml = { xml, web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPKIntegrationEvents, string>(_ePKIntegrationEventsInstance, MethodUpdateItemXml, parametersOfUpdateItemXml, methodUpdateItemXmlPrametersTypes);

            // Assert
            parametersOfUpdateItemXml.ShouldNotBeNull();
            parametersOfUpdateItemXml.Length.ShouldBe(2);
            methodUpdateItemXmlPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateItemXml) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_UpdateItemXml_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodUpdateItemXmlPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePKIntegrationEventsInstance, MethodUpdateItemXml, Fixture, methodUpdateItemXmlPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodUpdateItemXmlPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (UpdateItemXml) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_UpdateItemXml_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateItemXmlPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePKIntegrationEventsInstance, MethodUpdateItemXml, Fixture, methodUpdateItemXmlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateItemXmlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateItemXml) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_UpdateItemXml_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateItemXml, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePKIntegrationEventsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateItemXml) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_UpdateItemXml_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateItemXml, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CloseItemXml) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPKIntegrationEvents_CloseItemXml_Method_Call_Internally(Type[] types)
        {
            var methodCloseItemXmlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePKIntegrationEventsInstance, MethodCloseItemXml, Fixture, methodCloseItemXmlPrametersTypes);
        }

        #endregion

        #region Method Call : (CloseItemXml) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_CloseItemXml_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodCloseItemXmlPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfCloseItemXml = { xml, web };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCloseItemXml, methodCloseItemXmlPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPKIntegrationEvents, string>(_ePKIntegrationEventsInstanceFixture, out exception1, parametersOfCloseItemXml);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPKIntegrationEvents, string>(_ePKIntegrationEventsInstance, MethodCloseItemXml, parametersOfCloseItemXml, methodCloseItemXmlPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfCloseItemXml.ShouldNotBeNull();
            parametersOfCloseItemXml.Length.ShouldBe(2);
            methodCloseItemXmlPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (CloseItemXml) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_CloseItemXml_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodCloseItemXmlPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfCloseItemXml = { xml, web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EPKIntegrationEvents, string>(_ePKIntegrationEventsInstance, MethodCloseItemXml, parametersOfCloseItemXml, methodCloseItemXmlPrametersTypes);

            // Assert
            parametersOfCloseItemXml.ShouldNotBeNull();
            parametersOfCloseItemXml.Length.ShouldBe(2);
            methodCloseItemXmlPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CloseItemXml) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_CloseItemXml_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCloseItemXmlPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePKIntegrationEventsInstance, MethodCloseItemXml, Fixture, methodCloseItemXmlPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCloseItemXmlPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (CloseItemXml) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_CloseItemXml_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCloseItemXmlPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePKIntegrationEventsInstance, MethodCloseItemXml, Fixture, methodCloseItemXmlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCloseItemXmlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CloseItemXml) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_CloseItemXml_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCloseItemXml, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePKIntegrationEventsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CloseItemXml) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKIntegrationEvents_CloseItemXml_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCloseItemXml, 0);
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
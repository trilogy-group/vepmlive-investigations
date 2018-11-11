using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.AssociatedListItems" />)
    ///     and namespace <see cref="EPMLiveCore.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class AssociatedListItemsTest : AbstractBaseSetupTypedTest<AssociatedListItems>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (AssociatedListItems) Initializer

        private const string MethodGetAssociatedItems = "GetAssociatedItems";
        private const string MethodGetFancyFormAssociatedItems = "GetFancyFormAssociatedItems";
        private const string MethodGetFancyFormAssociatedItemAttachments = "GetFancyFormAssociatedItemAttachments";
        private Type _associatedListItemsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private AssociatedListItems _associatedListItemsInstance;
        private AssociatedListItems _associatedListItemsInstanceFixture;

        #region General Initializer : Class (AssociatedListItems) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="AssociatedListItems" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _associatedListItemsInstanceType = typeof(AssociatedListItems);
            _associatedListItemsInstanceFixture = Create(true);
            _associatedListItemsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (AssociatedListItems)

        #region General Initializer : Class (AssociatedListItems) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="AssociatedListItems" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetAssociatedItems, 0)]
        [TestCase(MethodGetFancyFormAssociatedItems, 0)]
        [TestCase(MethodGetFancyFormAssociatedItemAttachments, 0)]
        public void AUT_AssociatedListItems_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_associatedListItemsInstanceFixture, 
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
        ///     Class (<see cref="AssociatedListItems" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_AssociatedListItems_Is_Instance_Present_Test()
        {
            // Assert
            _associatedListItemsInstanceType.ShouldNotBeNull();
            _associatedListItemsInstance.ShouldNotBeNull();
            _associatedListItemsInstanceFixture.ShouldNotBeNull();
            _associatedListItemsInstance.ShouldBeAssignableTo<AssociatedListItems>();
            _associatedListItemsInstanceFixture.ShouldBeAssignableTo<AssociatedListItems>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (AssociatedListItems) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_AssociatedListItems_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            AssociatedListItems instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _associatedListItemsInstanceType.ShouldNotBeNull();
            _associatedListItemsInstance.ShouldNotBeNull();
            _associatedListItemsInstanceFixture.ShouldNotBeNull();
            _associatedListItemsInstance.ShouldBeAssignableTo<AssociatedListItems>();
            _associatedListItemsInstanceFixture.ShouldBeAssignableTo<AssociatedListItems>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="AssociatedListItems" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetAssociatedItems)]
        [TestCase(MethodGetFancyFormAssociatedItems)]
        [TestCase(MethodGetFancyFormAssociatedItemAttachments)]
        public void AUT_AssociatedListItems_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_associatedListItemsInstanceFixture,
                                                                              _associatedListItemsInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (GetAssociatedItems) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssociatedListItems_GetAssociatedItems_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetAssociatedItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_associatedListItemsInstanceFixture, _associatedListItemsInstanceType, MethodGetAssociatedItems, Fixture, methodGetAssociatedItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAssociatedItems) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedListItems_GetAssociatedItems_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => AssociatedListItems.GetAssociatedItems(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetAssociatedItems) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedListItems_GetAssociatedItems_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetAssociatedItemsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetAssociatedItems = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetAssociatedItems, methodGetAssociatedItemsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_associatedListItemsInstanceFixture, _associatedListItemsInstanceType, MethodGetAssociatedItems, Fixture, methodGetAssociatedItemsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_associatedListItemsInstanceFixture, _associatedListItemsInstanceType, MethodGetAssociatedItems, parametersOfGetAssociatedItems, methodGetAssociatedItemsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_associatedListItemsInstanceFixture, parametersOfGetAssociatedItems);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetAssociatedItems.ShouldNotBeNull();
            parametersOfGetAssociatedItems.Length.ShouldBe(1);
            methodGetAssociatedItemsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetAssociatedItems) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedListItems_GetAssociatedItems_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetAssociatedItemsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetAssociatedItems = { data };

            // Assert
            parametersOfGetAssociatedItems.ShouldNotBeNull();
            parametersOfGetAssociatedItems.Length.ShouldBe(1);
            methodGetAssociatedItemsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_associatedListItemsInstanceFixture, _associatedListItemsInstanceType, MethodGetAssociatedItems, parametersOfGetAssociatedItems, methodGetAssociatedItemsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetAssociatedItems) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedListItems_GetAssociatedItems_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetAssociatedItemsPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_associatedListItemsInstanceFixture, _associatedListItemsInstanceType, MethodGetAssociatedItems, Fixture, methodGetAssociatedItemsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetAssociatedItemsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetAssociatedItems) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedListItems_GetAssociatedItems_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetAssociatedItemsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_associatedListItemsInstanceFixture, _associatedListItemsInstanceType, MethodGetAssociatedItems, Fixture, methodGetAssociatedItemsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetAssociatedItemsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAssociatedItems) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedListItems_GetAssociatedItems_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetAssociatedItems, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_associatedListItemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAssociatedItems) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedListItems_GetAssociatedItems_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetAssociatedItems, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFancyFormAssociatedItems) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssociatedListItems_GetFancyFormAssociatedItems_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFancyFormAssociatedItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_associatedListItemsInstanceFixture, _associatedListItemsInstanceType, MethodGetFancyFormAssociatedItems, Fixture, methodGetFancyFormAssociatedItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFancyFormAssociatedItems) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedListItems_GetFancyFormAssociatedItems_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => AssociatedListItems.GetFancyFormAssociatedItems(data, oWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetFancyFormAssociatedItems) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedListItems_GetFancyFormAssociatedItems_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            var methodGetFancyFormAssociatedItemsPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetFancyFormAssociatedItems = { data, oWeb };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetFancyFormAssociatedItems, methodGetFancyFormAssociatedItemsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_associatedListItemsInstanceFixture, _associatedListItemsInstanceType, MethodGetFancyFormAssociatedItems, Fixture, methodGetFancyFormAssociatedItemsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_associatedListItemsInstanceFixture, _associatedListItemsInstanceType, MethodGetFancyFormAssociatedItems, parametersOfGetFancyFormAssociatedItems, methodGetFancyFormAssociatedItemsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_associatedListItemsInstanceFixture, parametersOfGetFancyFormAssociatedItems);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFancyFormAssociatedItems.ShouldNotBeNull();
            parametersOfGetFancyFormAssociatedItems.Length.ShouldBe(2);
            methodGetFancyFormAssociatedItemsPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetFancyFormAssociatedItems) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedListItems_GetFancyFormAssociatedItems_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            var methodGetFancyFormAssociatedItemsPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetFancyFormAssociatedItems = { data, oWeb };

            // Assert
            parametersOfGetFancyFormAssociatedItems.ShouldNotBeNull();
            parametersOfGetFancyFormAssociatedItems.Length.ShouldBe(2);
            methodGetFancyFormAssociatedItemsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_associatedListItemsInstanceFixture, _associatedListItemsInstanceType, MethodGetFancyFormAssociatedItems, parametersOfGetFancyFormAssociatedItems, methodGetFancyFormAssociatedItemsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetFancyFormAssociatedItems) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedListItems_GetFancyFormAssociatedItems_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFancyFormAssociatedItemsPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_associatedListItemsInstanceFixture, _associatedListItemsInstanceType, MethodGetFancyFormAssociatedItems, Fixture, methodGetFancyFormAssociatedItemsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFancyFormAssociatedItemsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetFancyFormAssociatedItems) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedListItems_GetFancyFormAssociatedItems_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFancyFormAssociatedItemsPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_associatedListItemsInstanceFixture, _associatedListItemsInstanceType, MethodGetFancyFormAssociatedItems, Fixture, methodGetFancyFormAssociatedItemsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFancyFormAssociatedItemsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFancyFormAssociatedItems) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedListItems_GetFancyFormAssociatedItems_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFancyFormAssociatedItems, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_associatedListItemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFancyFormAssociatedItems) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedListItems_GetFancyFormAssociatedItems_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFancyFormAssociatedItems, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFancyFormAssociatedItemAttachments) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssociatedListItems_GetFancyFormAssociatedItemAttachments_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFancyFormAssociatedItemAttachmentsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_associatedListItemsInstanceFixture, _associatedListItemsInstanceType, MethodGetFancyFormAssociatedItemAttachments, Fixture, methodGetFancyFormAssociatedItemAttachmentsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFancyFormAssociatedItemAttachments) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedListItems_GetFancyFormAssociatedItemAttachments_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => AssociatedListItems.GetFancyFormAssociatedItemAttachments(data, oWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetFancyFormAssociatedItemAttachments) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedListItems_GetFancyFormAssociatedItemAttachments_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            var methodGetFancyFormAssociatedItemAttachmentsPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetFancyFormAssociatedItemAttachments = { data, oWeb };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetFancyFormAssociatedItemAttachments, methodGetFancyFormAssociatedItemAttachmentsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_associatedListItemsInstanceFixture, _associatedListItemsInstanceType, MethodGetFancyFormAssociatedItemAttachments, Fixture, methodGetFancyFormAssociatedItemAttachmentsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_associatedListItemsInstanceFixture, _associatedListItemsInstanceType, MethodGetFancyFormAssociatedItemAttachments, parametersOfGetFancyFormAssociatedItemAttachments, methodGetFancyFormAssociatedItemAttachmentsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_associatedListItemsInstanceFixture, parametersOfGetFancyFormAssociatedItemAttachments);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFancyFormAssociatedItemAttachments.ShouldNotBeNull();
            parametersOfGetFancyFormAssociatedItemAttachments.Length.ShouldBe(2);
            methodGetFancyFormAssociatedItemAttachmentsPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetFancyFormAssociatedItemAttachments) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedListItems_GetFancyFormAssociatedItemAttachments_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            var methodGetFancyFormAssociatedItemAttachmentsPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetFancyFormAssociatedItemAttachments = { data, oWeb };

            // Assert
            parametersOfGetFancyFormAssociatedItemAttachments.ShouldNotBeNull();
            parametersOfGetFancyFormAssociatedItemAttachments.Length.ShouldBe(2);
            methodGetFancyFormAssociatedItemAttachmentsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_associatedListItemsInstanceFixture, _associatedListItemsInstanceType, MethodGetFancyFormAssociatedItemAttachments, parametersOfGetFancyFormAssociatedItemAttachments, methodGetFancyFormAssociatedItemAttachmentsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetFancyFormAssociatedItemAttachments) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedListItems_GetFancyFormAssociatedItemAttachments_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFancyFormAssociatedItemAttachmentsPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_associatedListItemsInstanceFixture, _associatedListItemsInstanceType, MethodGetFancyFormAssociatedItemAttachments, Fixture, methodGetFancyFormAssociatedItemAttachmentsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFancyFormAssociatedItemAttachmentsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetFancyFormAssociatedItemAttachments) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedListItems_GetFancyFormAssociatedItemAttachments_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFancyFormAssociatedItemAttachmentsPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_associatedListItemsInstanceFixture, _associatedListItemsInstanceType, MethodGetFancyFormAssociatedItemAttachments, Fixture, methodGetFancyFormAssociatedItemAttachmentsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFancyFormAssociatedItemAttachmentsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFancyFormAssociatedItemAttachments) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedListItems_GetFancyFormAssociatedItemAttachments_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFancyFormAssociatedItemAttachments, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_associatedListItemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFancyFormAssociatedItemAttachments) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedListItems_GetFancyFormAssociatedItemAttachments_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFancyFormAssociatedItemAttachments, 0);
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
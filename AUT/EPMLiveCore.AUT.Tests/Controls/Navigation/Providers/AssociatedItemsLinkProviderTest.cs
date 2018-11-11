using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using EPMLiveCore.API;
using EPMLiveCore.Infrastructure.Navigation;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.Controls.Navigation.Providers
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Controls.Navigation.Providers.AssociatedItemsLinkProvider" />)
    ///     and namespace <see cref="EPMLiveCore.Controls.Navigation.Providers"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class AssociatedItemsLinkProviderTest : AbstractBaseSetupTypedTest<AssociatedItemsLinkProvider>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (AssociatedItemsLinkProvider) Initializer

        private const string PropertyKey = "Key";
        private const string MethodGetAssociatedItems = "GetAssociatedItems";
        private const string MethodGetLink = "GetLink";
        private const string MethodParentWebListItemId = "ParentWebListItemId";
        private const string MethodGetLinks = "GetLinks";
        private const string FieldLIST_URL = "LIST_URL";
        private const string FieldPARENT_WEB_LIST_ITEM_QUERY = "PARENT_WEB_LIST_ITEM_QUERY";
        private const string Field_key = "_key";
        private Type _associatedItemsLinkProviderInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private AssociatedItemsLinkProvider _associatedItemsLinkProviderInstance;
        private AssociatedItemsLinkProvider _associatedItemsLinkProviderInstanceFixture;

        #region General Initializer : Class (AssociatedItemsLinkProvider) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="AssociatedItemsLinkProvider" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _associatedItemsLinkProviderInstanceType = typeof(AssociatedItemsLinkProvider);
            _associatedItemsLinkProviderInstanceFixture = Create(true);
            _associatedItemsLinkProviderInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (AssociatedItemsLinkProvider)

        #region General Initializer : Class (AssociatedItemsLinkProvider) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="AssociatedItemsLinkProvider" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetAssociatedItems, 0)]
        [TestCase(MethodGetLink, 0)]
        [TestCase(MethodGetLink, 1)]
        [TestCase(MethodParentWebListItemId, 0)]
        [TestCase(MethodGetLinks, 0)]
        public void AUT_AssociatedItemsLinkProvider_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_associatedItemsLinkProviderInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (AssociatedItemsLinkProvider) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="AssociatedItemsLinkProvider" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyKey)]
        public void AUT_AssociatedItemsLinkProvider_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_associatedItemsLinkProviderInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (AssociatedItemsLinkProvider) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="AssociatedItemsLinkProvider" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldLIST_URL)]
        [TestCase(FieldPARENT_WEB_LIST_ITEM_QUERY)]
        [TestCase(Field_key)]
        public void AUT_AssociatedItemsLinkProvider_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_associatedItemsLinkProviderInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : GetterSetter
        
        #region General Getters/Setters : Class (AssociatedItemsLinkProvider) => Property (Key) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AssociatedItemsLinkProvider_Public_Class_Key_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyKey);

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
        ///      Class (<see cref="AssociatedItemsLinkProvider" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetAssociatedItems)]
        [TestCase(MethodGetLink)]
        [TestCase(MethodParentWebListItemId)]
        [TestCase(MethodGetLinks)]
        public void AUT_AssociatedItemsLinkProvider_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<AssociatedItemsLinkProvider>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetAssociatedItems) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssociatedItemsLinkProvider_GetAssociatedItems_Method_Call_Internally(Type[] types)
        {
            var methodGetAssociatedItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_associatedItemsLinkProviderInstance, MethodGetAssociatedItems, Fixture, methodGetAssociatedItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAssociatedItems) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedItemsLinkProvider_GetAssociatedItems_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var links = CreateType<List<NavLink>>();
            var methodGetAssociatedItemsPrametersTypes = new Type[] { typeof(List<NavLink>) };
            object[] parametersOfGetAssociatedItems = { links };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetAssociatedItems, methodGetAssociatedItemsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_associatedItemsLinkProviderInstanceFixture, parametersOfGetAssociatedItems);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetAssociatedItems.ShouldNotBeNull();
            parametersOfGetAssociatedItems.Length.ShouldBe(1);
            methodGetAssociatedItemsPrametersTypes.Length.ShouldBe(1);
            methodGetAssociatedItemsPrametersTypes.Length.ShouldBe(parametersOfGetAssociatedItems.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetAssociatedItems) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedItemsLinkProvider_GetAssociatedItems_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var links = CreateType<List<NavLink>>();
            var methodGetAssociatedItemsPrametersTypes = new Type[] { typeof(List<NavLink>) };
            object[] parametersOfGetAssociatedItems = { links };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_associatedItemsLinkProviderInstance, MethodGetAssociatedItems, parametersOfGetAssociatedItems, methodGetAssociatedItemsPrametersTypes);

            // Assert
            parametersOfGetAssociatedItems.ShouldNotBeNull();
            parametersOfGetAssociatedItems.Length.ShouldBe(1);
            methodGetAssociatedItemsPrametersTypes.Length.ShouldBe(1);
            methodGetAssociatedItemsPrametersTypes.Length.ShouldBe(parametersOfGetAssociatedItems.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAssociatedItems) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedItemsLinkProvider_GetAssociatedItems_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (GetAssociatedItems) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedItemsLinkProvider_GetAssociatedItems_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetAssociatedItemsPrametersTypes = new Type[] { typeof(List<NavLink>) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_associatedItemsLinkProviderInstance, MethodGetAssociatedItems, Fixture, methodGetAssociatedItemsPrametersTypes);

            // Assert
            methodGetAssociatedItemsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAssociatedItems) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedItemsLinkProvider_GetAssociatedItems_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetAssociatedItems, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_associatedItemsLinkProviderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetLink) (Return Type : NavLink) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssociatedItemsLinkProvider_GetLink_Method_Call_Internally(Type[] types)
        {
            var methodGetLinkPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_associatedItemsLinkProviderInstance, MethodGetLink, Fixture, methodGetLinkPrametersTypes);
        }

        #endregion

        #region Method Call : (GetLink) (Return Type : NavLink) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedItemsLinkProvider_GetLink_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listInfo = CreateType<AssociatedListInfo>();
            var spList = CreateType<SPList>();
            var title = CreateType<string>();
            var methodGetLinkPrametersTypes = new Type[] { typeof(AssociatedListInfo), typeof(SPList), typeof(string) };
            object[] parametersOfGetLink = { listInfo, spList, title };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetLink, methodGetLinkPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<AssociatedItemsLinkProvider, NavLink>(_associatedItemsLinkProviderInstanceFixture, out exception1, parametersOfGetLink);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<AssociatedItemsLinkProvider, NavLink>(_associatedItemsLinkProviderInstance, MethodGetLink, parametersOfGetLink, methodGetLinkPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetLink.ShouldNotBeNull();
            parametersOfGetLink.Length.ShouldBe(3);
            methodGetLinkPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(() => methodInfo.Invoke(_associatedItemsLinkProviderInstanceFixture, parametersOfGetLink));
        }

        #endregion

        #region Method Call : (GetLink) (Return Type : NavLink) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedItemsLinkProvider_GetLink_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listInfo = CreateType<AssociatedListInfo>();
            var spList = CreateType<SPList>();
            var title = CreateType<string>();
            var methodGetLinkPrametersTypes = new Type[] { typeof(AssociatedListInfo), typeof(SPList), typeof(string) };
            object[] parametersOfGetLink = { listInfo, spList, title };

            // Assert
            parametersOfGetLink.ShouldNotBeNull();
            parametersOfGetLink.Length.ShouldBe(3);
            methodGetLinkPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<AssociatedItemsLinkProvider, NavLink>(_associatedItemsLinkProviderInstance, MethodGetLink, parametersOfGetLink, methodGetLinkPrametersTypes));
        }

        #endregion

        #region Method Call : (GetLink) (Return Type : NavLink) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedItemsLinkProvider_GetLink_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetLinkPrametersTypes = new Type[] { typeof(AssociatedListInfo), typeof(SPList), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_associatedItemsLinkProviderInstance, MethodGetLink, Fixture, methodGetLinkPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetLinkPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetLink) (Return Type : NavLink) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedItemsLinkProvider_GetLink_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetLinkPrametersTypes = new Type[] { typeof(AssociatedListInfo), typeof(SPList), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_associatedItemsLinkProviderInstance, MethodGetLink, Fixture, methodGetLinkPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetLinkPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetLink) (Return Type : NavLink) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedItemsLinkProvider_GetLink_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetLink, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_associatedItemsLinkProviderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLink) (Return Type : NavLink) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedItemsLinkProvider_GetLink_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetLink, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetLink) (Return Type : NavLink) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssociatedItemsLinkProvider_GetLink_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodGetLinkPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_associatedItemsLinkProviderInstance, MethodGetLink, Fixture, methodGetLinkPrametersTypes);
        }

        #endregion

        #region Method Call : (GetLink) (Return Type : NavLink) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedItemsLinkProvider_GetLink_Method_Call_Overloading_Of_1_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var spList = CreateType<SPList>();
            var itemId = CreateType<int>();
            var methodGetLinkPrametersTypes = new Type[] { typeof(SPList), typeof(int) };
            object[] parametersOfGetLink = { spList, itemId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetLink, methodGetLinkPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<AssociatedItemsLinkProvider, NavLink>(_associatedItemsLinkProviderInstanceFixture, out exception1, parametersOfGetLink);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<AssociatedItemsLinkProvider, NavLink>(_associatedItemsLinkProviderInstance, MethodGetLink, parametersOfGetLink, methodGetLinkPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetLink.ShouldNotBeNull();
            parametersOfGetLink.Length.ShouldBe(2);
            methodGetLinkPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(() => methodInfo.Invoke(_associatedItemsLinkProviderInstanceFixture, parametersOfGetLink));
        }

        #endregion

        #region Method Call : (GetLink) (Return Type : NavLink) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedItemsLinkProvider_GetLink_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spList = CreateType<SPList>();
            var itemId = CreateType<int>();
            var methodGetLinkPrametersTypes = new Type[] { typeof(SPList), typeof(int) };
            object[] parametersOfGetLink = { spList, itemId };

            // Assert
            parametersOfGetLink.ShouldNotBeNull();
            parametersOfGetLink.Length.ShouldBe(2);
            methodGetLinkPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<AssociatedItemsLinkProvider, NavLink>(_associatedItemsLinkProviderInstance, MethodGetLink, parametersOfGetLink, methodGetLinkPrametersTypes));
        }

        #endregion

        #region Method Call : (GetLink) (Return Type : NavLink) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedItemsLinkProvider_GetLink_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetLinkPrametersTypes = new Type[] { typeof(SPList), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_associatedItemsLinkProviderInstance, MethodGetLink, Fixture, methodGetLinkPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetLinkPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetLink) (Return Type : NavLink) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedItemsLinkProvider_GetLink_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetLinkPrametersTypes = new Type[] { typeof(SPList), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_associatedItemsLinkProviderInstance, MethodGetLink, Fixture, methodGetLinkPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetLinkPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetLink) (Return Type : NavLink) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedItemsLinkProvider_GetLink_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetLink, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_associatedItemsLinkProviderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLink) (Return Type : NavLink) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedItemsLinkProvider_GetLink_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetLink, 1);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ParentWebListItemId) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssociatedItemsLinkProvider_ParentWebListItemId_Method_Call_Internally(Type[] types)
        {
            var methodParentWebListItemIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_associatedItemsLinkProviderInstance, MethodParentWebListItemId, Fixture, methodParentWebListItemIdPrametersTypes);
        }

        #endregion

        #region Method Call : (ParentWebListItemId) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedItemsLinkProvider_ParentWebListItemId_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var parentWebId = CreateType<Guid>();
            var parentListId = CreateType<Guid>();
            var parentItemId = CreateType<int>();
            var methodParentWebListItemIdPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(int) };
            object[] parametersOfParentWebListItemId = { parentWebId, parentListId, parentItemId };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodParentWebListItemId, methodParentWebListItemIdPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_associatedItemsLinkProviderInstanceFixture, parametersOfParentWebListItemId);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfParentWebListItemId.ShouldNotBeNull();
            parametersOfParentWebListItemId.Length.ShouldBe(3);
            methodParentWebListItemIdPrametersTypes.Length.ShouldBe(3);
            methodParentWebListItemIdPrametersTypes.Length.ShouldBe(parametersOfParentWebListItemId.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ParentWebListItemId) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedItemsLinkProvider_ParentWebListItemId_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var parentWebId = CreateType<Guid>();
            var parentListId = CreateType<Guid>();
            var parentItemId = CreateType<int>();
            var methodParentWebListItemIdPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(int) };
            object[] parametersOfParentWebListItemId = { parentWebId, parentListId, parentItemId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_associatedItemsLinkProviderInstance, MethodParentWebListItemId, parametersOfParentWebListItemId, methodParentWebListItemIdPrametersTypes);

            // Assert
            parametersOfParentWebListItemId.ShouldNotBeNull();
            parametersOfParentWebListItemId.Length.ShouldBe(3);
            methodParentWebListItemIdPrametersTypes.Length.ShouldBe(3);
            methodParentWebListItemIdPrametersTypes.Length.ShouldBe(parametersOfParentWebListItemId.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ParentWebListItemId) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedItemsLinkProvider_ParentWebListItemId_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodParentWebListItemId, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ParentWebListItemId) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedItemsLinkProvider_ParentWebListItemId_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodParentWebListItemIdPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_associatedItemsLinkProviderInstance, MethodParentWebListItemId, Fixture, methodParentWebListItemIdPrametersTypes);

            // Assert
            methodParentWebListItemIdPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ParentWebListItemId) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedItemsLinkProvider_ParentWebListItemId_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodParentWebListItemId, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_associatedItemsLinkProviderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssociatedItemsLinkProvider_GetLinks_Method_Call_Internally(Type[] types)
        {
            var methodGetLinksPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_associatedItemsLinkProviderInstance, MethodGetLinks, Fixture, methodGetLinksPrametersTypes);
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedItemsLinkProvider_GetLinks_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _associatedItemsLinkProviderInstance.GetLinks();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedItemsLinkProvider_GetLinks_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetLinksPrametersTypes = null;
            object[] parametersOfGetLinks = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetLinks, methodGetLinksPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<AssociatedItemsLinkProvider, IEnumerable<INavObject>>(_associatedItemsLinkProviderInstanceFixture, out exception1, parametersOfGetLinks);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<AssociatedItemsLinkProvider, IEnumerable<INavObject>>(_associatedItemsLinkProviderInstance, MethodGetLinks, parametersOfGetLinks, methodGetLinksPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetLinks.ShouldBeNull();
            methodGetLinksPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(() => methodInfo.Invoke(_associatedItemsLinkProviderInstanceFixture, parametersOfGetLinks));
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedItemsLinkProvider_GetLinks_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetLinksPrametersTypes = null;
            object[] parametersOfGetLinks = null; // no parameter present

            // Assert
            parametersOfGetLinks.ShouldBeNull();
            methodGetLinksPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<AssociatedItemsLinkProvider, IEnumerable<INavObject>>(_associatedItemsLinkProviderInstance, MethodGetLinks, parametersOfGetLinks, methodGetLinksPrametersTypes));
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedItemsLinkProvider_GetLinks_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetLinksPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_associatedItemsLinkProviderInstance, MethodGetLinks, Fixture, methodGetLinksPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetLinksPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedItemsLinkProvider_GetLinks_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetLinksPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_associatedItemsLinkProviderInstance, MethodGetLinks, Fixture, methodGetLinksPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetLinksPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssociatedItemsLinkProvider_GetLinks_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetLinks, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_associatedItemsLinkProviderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #endregion

        #endregion
    }
}
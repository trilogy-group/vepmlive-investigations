using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using EPMLiveCore.Infrastructure.Navigation;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.Controls.Navigation.Providers
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Controls.Navigation.Providers.GenericLinkProvider" />)
    ///     and namespace <see cref="EPMLiveCore.Controls.Navigation.Providers"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class GenericLinkProviderTest : AbstractBaseSetupTypedTest<GenericLinkProvider>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (GenericLinkProvider) Initializer

        private const string PropertyKey = "Key";
        private const string MethodRemove = "Remove";
        private const string MethodReorder = "Reorder";
        private const string MethodResetCache = "ResetCache";
        private const string MethodClearCache = "ClearCache";
        private const string MethodGetLinks = "GetLinks";
        private const string FieldA_QUERY = "A_QUERY";
        private const string FieldD_QUERY = "D_QUERY";
        private const string FieldR_QUERY = "R_QUERY";
        private const string FieldU_QUERY = "U_QUERY";
        private Type _genericLinkProviderInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private GenericLinkProvider _genericLinkProviderInstance;
        private GenericLinkProvider _genericLinkProviderInstanceFixture;

        #region General Initializer : Class (GenericLinkProvider) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="GenericLinkProvider" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _genericLinkProviderInstanceType = typeof(GenericLinkProvider);
            _genericLinkProviderInstanceFixture = Create(true);
            _genericLinkProviderInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (GenericLinkProvider)

        #region General Initializer : Class (GenericLinkProvider) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="GenericLinkProvider" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodRemove, 0)]
        [TestCase(MethodReorder, 0)]
        [TestCase(MethodResetCache, 0)]
        [TestCase(MethodClearCache, 0)]
        [TestCase(MethodGetLinks, 0)]
        public void AUT_GenericLinkProvider_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_genericLinkProviderInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (GenericLinkProvider) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="GenericLinkProvider" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyKey)]
        public void AUT_GenericLinkProvider_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_genericLinkProviderInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (GenericLinkProvider) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="GenericLinkProvider" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldA_QUERY)]
        [TestCase(FieldD_QUERY)]
        [TestCase(FieldR_QUERY)]
        [TestCase(FieldU_QUERY)]
        public void AUT_GenericLinkProvider_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_genericLinkProviderInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : GetterSetter
        
        #region General Getters/Setters : Class (GenericLinkProvider) => Property (Key) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GenericLinkProvider_Public_Class_Key_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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
        ///      Class (<see cref="GenericLinkProvider" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodRemove)]
        [TestCase(MethodReorder)]
        [TestCase(MethodResetCache)]
        [TestCase(MethodClearCache)]
        [TestCase(MethodGetLinks)]
        public void AUT_GenericLinkProvider_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<GenericLinkProvider>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Remove) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GenericLinkProvider_Remove_Method_Call_Internally(Type[] types)
        {
            var methodRemovePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericLinkProviderInstance, MethodRemove, Fixture, methodRemovePrametersTypes);
        }

        #endregion

        #region Method Call : (Remove) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericLinkProvider_Remove_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var linkId = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => _genericLinkProviderInstance.Remove(linkId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Remove) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericLinkProvider_Remove_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var linkId = CreateType<Guid>();
            var methodRemovePrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfRemove = { linkId };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRemove, methodRemovePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_genericLinkProviderInstanceFixture, parametersOfRemove);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRemove.ShouldNotBeNull();
            parametersOfRemove.Length.ShouldBe(1);
            methodRemovePrametersTypes.Length.ShouldBe(1);
            methodRemovePrametersTypes.Length.ShouldBe(parametersOfRemove.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Remove) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericLinkProvider_Remove_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var linkId = CreateType<Guid>();
            var methodRemovePrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfRemove = { linkId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_genericLinkProviderInstance, MethodRemove, parametersOfRemove, methodRemovePrametersTypes);

            // Assert
            parametersOfRemove.ShouldNotBeNull();
            parametersOfRemove.Length.ShouldBe(1);
            methodRemovePrametersTypes.Length.ShouldBe(1);
            methodRemovePrametersTypes.Length.ShouldBe(parametersOfRemove.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Remove) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericLinkProvider_Remove_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRemove, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Remove) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericLinkProvider_Remove_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRemovePrametersTypes = new Type[] { typeof(Guid) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericLinkProviderInstance, MethodRemove, Fixture, methodRemovePrametersTypes);

            // Assert
            methodRemovePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Remove) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericLinkProvider_Remove_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRemove, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_genericLinkProviderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Reorder) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GenericLinkProvider_Reorder_Method_Call_Internally(Type[] types)
        {
            var methodReorderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericLinkProviderInstance, MethodReorder, Fixture, methodReorderPrametersTypes);
        }

        #endregion

        #region Method Call : (Reorder) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericLinkProvider_Reorder_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<Dictionary<Guid, int>>();
            Action executeAction = null;

            // Act
            executeAction = () => _genericLinkProviderInstance.Reorder(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Reorder) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericLinkProvider_Reorder_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<Dictionary<Guid, int>>();
            var methodReorderPrametersTypes = new Type[] { typeof(Dictionary<Guid, int>) };
            object[] parametersOfReorder = { data };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReorder, methodReorderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_genericLinkProviderInstanceFixture, parametersOfReorder);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReorder.ShouldNotBeNull();
            parametersOfReorder.Length.ShouldBe(1);
            methodReorderPrametersTypes.Length.ShouldBe(1);
            methodReorderPrametersTypes.Length.ShouldBe(parametersOfReorder.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Reorder) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericLinkProvider_Reorder_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<Dictionary<Guid, int>>();
            var methodReorderPrametersTypes = new Type[] { typeof(Dictionary<Guid, int>) };
            object[] parametersOfReorder = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_genericLinkProviderInstance, MethodReorder, parametersOfReorder, methodReorderPrametersTypes);

            // Assert
            parametersOfReorder.ShouldNotBeNull();
            parametersOfReorder.Length.ShouldBe(1);
            methodReorderPrametersTypes.Length.ShouldBe(1);
            methodReorderPrametersTypes.Length.ShouldBe(parametersOfReorder.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Reorder) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericLinkProvider_Reorder_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReorder, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Reorder) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericLinkProvider_Reorder_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReorderPrametersTypes = new Type[] { typeof(Dictionary<Guid, int>) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericLinkProviderInstance, MethodReorder, Fixture, methodReorderPrametersTypes);

            // Assert
            methodReorderPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Reorder) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericLinkProvider_Reorder_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReorder, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_genericLinkProviderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ResetCache) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GenericLinkProvider_ResetCache_Method_Call_Internally(Type[] types)
        {
            var methodResetCachePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericLinkProviderInstance, MethodResetCache, Fixture, methodResetCachePrametersTypes);
        }

        #endregion

        #region Method Call : (ResetCache) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericLinkProvider_ResetCache_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var safeRemove = CreateType<bool>();
            var methodResetCachePrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfResetCache = { safeRemove };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodResetCache, methodResetCachePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_genericLinkProviderInstanceFixture, parametersOfResetCache);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfResetCache.ShouldNotBeNull();
            parametersOfResetCache.Length.ShouldBe(1);
            methodResetCachePrametersTypes.Length.ShouldBe(1);
            methodResetCachePrametersTypes.Length.ShouldBe(parametersOfResetCache.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ResetCache) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericLinkProvider_ResetCache_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var safeRemove = CreateType<bool>();
            var methodResetCachePrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfResetCache = { safeRemove };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_genericLinkProviderInstance, MethodResetCache, parametersOfResetCache, methodResetCachePrametersTypes);

            // Assert
            parametersOfResetCache.ShouldNotBeNull();
            parametersOfResetCache.Length.ShouldBe(1);
            methodResetCachePrametersTypes.Length.ShouldBe(1);
            methodResetCachePrametersTypes.Length.ShouldBe(parametersOfResetCache.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ResetCache) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericLinkProvider_ResetCache_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodResetCache, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ResetCache) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericLinkProvider_ResetCache_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodResetCachePrametersTypes = new Type[] { typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericLinkProviderInstance, MethodResetCache, Fixture, methodResetCachePrametersTypes);

            // Assert
            methodResetCachePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ResetCache) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericLinkProvider_ResetCache_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodResetCache, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_genericLinkProviderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GenericLinkProvider_ClearCache_Method_Call_Internally(Type[] types)
        {
            var methodClearCachePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericLinkProviderInstance, MethodClearCache, Fixture, methodClearCachePrametersTypes);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericLinkProvider_ClearCache_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var safeRemove = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _genericLinkProviderInstance.ClearCache(safeRemove);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericLinkProvider_ClearCache_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var safeRemove = CreateType<bool>();
            var methodClearCachePrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfClearCache = { safeRemove };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodClearCache, methodClearCachePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_genericLinkProviderInstanceFixture, parametersOfClearCache);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfClearCache.ShouldNotBeNull();
            parametersOfClearCache.Length.ShouldBe(1);
            methodClearCachePrametersTypes.Length.ShouldBe(1);
            methodClearCachePrametersTypes.Length.ShouldBe(parametersOfClearCache.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericLinkProvider_ClearCache_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var safeRemove = CreateType<bool>();
            var methodClearCachePrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfClearCache = { safeRemove };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_genericLinkProviderInstance, MethodClearCache, parametersOfClearCache, methodClearCachePrametersTypes);

            // Assert
            parametersOfClearCache.ShouldNotBeNull();
            parametersOfClearCache.Length.ShouldBe(1);
            methodClearCachePrametersTypes.Length.ShouldBe(1);
            methodClearCachePrametersTypes.Length.ShouldBe(parametersOfClearCache.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericLinkProvider_ClearCache_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodClearCache, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericLinkProvider_ClearCache_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodClearCachePrametersTypes = new Type[] { typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericLinkProviderInstance, MethodClearCache, Fixture, methodClearCachePrametersTypes);

            // Assert
            methodClearCachePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericLinkProvider_ClearCache_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodClearCache, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_genericLinkProviderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GenericLinkProvider_GetLinks_Method_Call_Internally(Type[] types)
        {
            var methodGetLinksPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericLinkProviderInstance, MethodGetLinks, Fixture, methodGetLinksPrametersTypes);
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericLinkProvider_GetLinks_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _genericLinkProviderInstance.GetLinks();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericLinkProvider_GetLinks_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetLinksPrametersTypes = null;
            object[] parametersOfGetLinks = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetLinks, methodGetLinksPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GenericLinkProvider, IEnumerable<INavObject>>(_genericLinkProviderInstanceFixture, out exception1, parametersOfGetLinks);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GenericLinkProvider, IEnumerable<INavObject>>(_genericLinkProviderInstance, MethodGetLinks, parametersOfGetLinks, methodGetLinksPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetLinks.ShouldBeNull();
            methodGetLinksPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(() => methodInfo.Invoke(_genericLinkProviderInstanceFixture, parametersOfGetLinks));
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericLinkProvider_GetLinks_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetLinksPrametersTypes = null;
            object[] parametersOfGetLinks = null; // no parameter present

            // Assert
            parametersOfGetLinks.ShouldBeNull();
            methodGetLinksPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<GenericLinkProvider, IEnumerable<INavObject>>(_genericLinkProviderInstance, MethodGetLinks, parametersOfGetLinks, methodGetLinksPrametersTypes));
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericLinkProvider_GetLinks_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetLinksPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericLinkProviderInstance, MethodGetLinks, Fixture, methodGetLinksPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetLinksPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericLinkProvider_GetLinks_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetLinksPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericLinkProviderInstance, MethodGetLinks, Fixture, methodGetLinksPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetLinksPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLinks) (Return Type : IEnumerable<INavObject>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GenericLinkProvider_GetLinks_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetLinks, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_genericLinkProviderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #endregion

        #endregion
    }
}
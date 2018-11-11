using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using PortfolioEngineCore.Infrastructure.Entities;
using Should = Shouldly.Should;
using Shouldly;

namespace PortfolioEngineCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PortfolioEngineCore.Resources" />)
    ///     and namespace <see cref="PortfolioEngineCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ResourcesTest : AbstractBaseSetupTypedTest<Resources>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Resources) Initializer

        private const string MethodBuildResource = "BuildResource";
        private const string MethodCanDelete = "CanDelete";
        private const string MethodDelete = "Delete";
        private const string MethodFindResource = "FindResource";
        private const string MethodGetPermissionGroups = "GetPermissionGroups";
        private const string MethodGetResourceCostCategoryRole = "GetResourceCostCategoryRole";
        private const string MethodGetResourcePermissionGroups = "GetResourcePermissionGroups";
        private const string MethodUpdateResource = "UpdateResource";
        private const string Field_resourceRepository = "_resourceRepository";
        private Type _resourcesInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Resources _resourcesInstance;
        private Resources _resourcesInstanceFixture;

        #region General Initializer : Class (Resources) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Resources" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _resourcesInstanceType = typeof(Resources);
            _resourcesInstanceFixture = Create(true);
            _resourcesInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Resources)

        #region General Initializer : Class (Resources) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Resources" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodBuildResource, 0)]
        [TestCase(MethodCanDelete, 0)]
        [TestCase(MethodDelete, 0)]
        [TestCase(MethodFindResource, 0)]
        [TestCase(MethodGetPermissionGroups, 0)]
        [TestCase(MethodGetResourceCostCategoryRole, 0)]
        [TestCase(MethodGetResourcePermissionGroups, 0)]
        [TestCase(MethodUpdateResource, 0)]
        public void AUT_Resources_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_resourcesInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Resources) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Resources" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_resourceRepository)]
        public void AUT_Resources_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_resourcesInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="Resources" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodBuildResource)]
        [TestCase(MethodCanDelete)]
        [TestCase(MethodDelete)]
        [TestCase(MethodFindResource)]
        [TestCase(MethodGetPermissionGroups)]
        [TestCase(MethodGetResourceCostCategoryRole)]
        [TestCase(MethodGetResourcePermissionGroups)]
        [TestCase(MethodUpdateResource)]
        public void AUT_Resources_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<Resources>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (BuildResource) (Return Type : Resource) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Resources_BuildResource_Method_Call_Internally(Type[] types)
        {
            var methodBuildResourcePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcesInstance, MethodBuildResource, Fixture, methodBuildResourcePrametersTypes);
        }

        #endregion

        #region Method Call : (BuildResource) (Return Type : Resource) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_BuildResource_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var dataRow = CreateType<DataRow>();
            Action executeAction = null;

            // Act
            executeAction = () => _resourcesInstance.BuildResource(dataRow);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (BuildResource) (Return Type : Resource) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_BuildResource_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var dataRow = CreateType<DataRow>();
            var methodBuildResourcePrametersTypes = new Type[] { typeof(DataRow) };
            object[] parametersOfBuildResource = { dataRow };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodBuildResource, methodBuildResourcePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Resources, Resource>(_resourcesInstanceFixture, out exception1, parametersOfBuildResource);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Resources, Resource>(_resourcesInstance, MethodBuildResource, parametersOfBuildResource, methodBuildResourcePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfBuildResource.ShouldNotBeNull();
            parametersOfBuildResource.Length.ShouldBe(1);
            methodBuildResourcePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (BuildResource) (Return Type : Resource) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_BuildResource_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dataRow = CreateType<DataRow>();
            var methodBuildResourcePrametersTypes = new Type[] { typeof(DataRow) };
            object[] parametersOfBuildResource = { dataRow };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Resources, Resource>(_resourcesInstance, MethodBuildResource, parametersOfBuildResource, methodBuildResourcePrametersTypes);

            // Assert
            parametersOfBuildResource.ShouldNotBeNull();
            parametersOfBuildResource.Length.ShouldBe(1);
            methodBuildResourcePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildResource) (Return Type : Resource) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_BuildResource_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodBuildResourcePrametersTypes = new Type[] { typeof(DataRow) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcesInstance, MethodBuildResource, Fixture, methodBuildResourcePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodBuildResourcePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (BuildResource) (Return Type : Resource) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_BuildResource_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBuildResourcePrametersTypes = new Type[] { typeof(DataRow) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcesInstance, MethodBuildResource, Fixture, methodBuildResourcePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildResourcePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildResource) (Return Type : Resource) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_BuildResource_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildResource, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BuildResource) (Return Type : Resource) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_BuildResource_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBuildResource, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CanDelete) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Resources_CanDelete_Method_Call_Internally(Type[] types)
        {
            var methodCanDeletePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcesInstance, MethodCanDelete, Fixture, methodCanDeletePrametersTypes);
        }

        #endregion

        #region Method Call : (CanDelete) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_CanDelete_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var resource = CreateType<Resource>();
            var message = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _resourcesInstance.CanDelete(resource, out message);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CanDelete) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_CanDelete_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var resource = CreateType<Resource>();
            var message = CreateType<string>();
            var methodCanDeletePrametersTypes = new Type[] { typeof(Resource), typeof(string) };
            object[] parametersOfCanDelete = { resource, message };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCanDelete, methodCanDeletePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Resources, string>(_resourcesInstanceFixture, out exception1, parametersOfCanDelete);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Resources, string>(_resourcesInstance, MethodCanDelete, parametersOfCanDelete, methodCanDeletePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfCanDelete.ShouldNotBeNull();
            parametersOfCanDelete.Length.ShouldBe(2);
            methodCanDeletePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (CanDelete) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_CanDelete_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var resource = CreateType<Resource>();
            var message = CreateType<string>();
            var methodCanDeletePrametersTypes = new Type[] { typeof(Resource), typeof(string) };
            object[] parametersOfCanDelete = { resource, message };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Resources, string>(_resourcesInstance, MethodCanDelete, parametersOfCanDelete, methodCanDeletePrametersTypes);

            // Assert
            parametersOfCanDelete.ShouldNotBeNull();
            parametersOfCanDelete.Length.ShouldBe(2);
            methodCanDeletePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CanDelete) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_CanDelete_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCanDeletePrametersTypes = new Type[] { typeof(Resource), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcesInstance, MethodCanDelete, Fixture, methodCanDeletePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCanDeletePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (CanDelete) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_CanDelete_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCanDeletePrametersTypes = new Type[] { typeof(Resource), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcesInstance, MethodCanDelete, Fixture, methodCanDeletePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCanDeletePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CanDelete) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_CanDelete_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCanDelete, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CanDelete) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_CanDelete_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCanDelete, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Resources_Delete_Method_Call_Internally(Type[] types)
        {
            var methodDeletePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcesInstance, MethodDelete, Fixture, methodDeletePrametersTypes);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_Delete_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var resource = CreateType<Resource>();
            var currentUserId = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _resourcesInstance.Delete(resource, currentUserId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_Delete_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var resource = CreateType<Resource>();
            var currentUserId = CreateType<int>();
            var methodDeletePrametersTypes = new Type[] { typeof(Resource), typeof(int) };
            object[] parametersOfDelete = { resource, currentUserId };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDelete, methodDeletePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourcesInstanceFixture, parametersOfDelete);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDelete.ShouldNotBeNull();
            parametersOfDelete.Length.ShouldBe(2);
            methodDeletePrametersTypes.Length.ShouldBe(2);
            methodDeletePrametersTypes.Length.ShouldBe(parametersOfDelete.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_Delete_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var resource = CreateType<Resource>();
            var currentUserId = CreateType<int>();
            var methodDeletePrametersTypes = new Type[] { typeof(Resource), typeof(int) };
            object[] parametersOfDelete = { resource, currentUserId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourcesInstance, MethodDelete, parametersOfDelete, methodDeletePrametersTypes);

            // Assert
            parametersOfDelete.ShouldNotBeNull();
            parametersOfDelete.Length.ShouldBe(2);
            methodDeletePrametersTypes.Length.ShouldBe(2);
            methodDeletePrametersTypes.Length.ShouldBe(parametersOfDelete.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_Delete_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDelete, 0);
            const int parametersCount = 2;

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
        public void AUT_Resources_Delete_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeletePrametersTypes = new Type[] { typeof(Resource), typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcesInstance, MethodDelete, Fixture, methodDeletePrametersTypes);

            // Assert
            methodDeletePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_Delete_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDelete, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FindResource) (Return Type : Resource) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Resources_FindResource_Method_Call_Internally(Type[] types)
        {
            var methodFindResourcePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcesInstance, MethodFindResource, Fixture, methodFindResourcePrametersTypes);
        }

        #endregion

        #region Method Call : (FindResource) (Return Type : Resource) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_FindResource_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var id = CreateType<int?>();
            var externalId = CreateType<string>();
            var username = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _resourcesInstance.FindResource(id, externalId, username);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (FindResource) (Return Type : Resource) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_FindResource_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var id = CreateType<int?>();
            var externalId = CreateType<string>();
            var username = CreateType<string>();
            var methodFindResourcePrametersTypes = new Type[] { typeof(int?), typeof(string), typeof(string) };
            object[] parametersOfFindResource = { id, externalId, username };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodFindResource, methodFindResourcePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Resources, Resource>(_resourcesInstanceFixture, out exception1, parametersOfFindResource);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Resources, Resource>(_resourcesInstance, MethodFindResource, parametersOfFindResource, methodFindResourcePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfFindResource.ShouldNotBeNull();
            parametersOfFindResource.Length.ShouldBe(3);
            methodFindResourcePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (FindResource) (Return Type : Resource) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_FindResource_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var id = CreateType<int?>();
            var externalId = CreateType<string>();
            var username = CreateType<string>();
            var methodFindResourcePrametersTypes = new Type[] { typeof(int?), typeof(string), typeof(string) };
            object[] parametersOfFindResource = { id, externalId, username };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Resources, Resource>(_resourcesInstance, MethodFindResource, parametersOfFindResource, methodFindResourcePrametersTypes);

            // Assert
            parametersOfFindResource.ShouldNotBeNull();
            parametersOfFindResource.Length.ShouldBe(3);
            methodFindResourcePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FindResource) (Return Type : Resource) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_FindResource_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodFindResourcePrametersTypes = new Type[] { typeof(int?), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcesInstance, MethodFindResource, Fixture, methodFindResourcePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodFindResourcePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (FindResource) (Return Type : Resource) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_FindResource_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFindResourcePrametersTypes = new Type[] { typeof(int?), typeof(string), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcesInstance, MethodFindResource, Fixture, methodFindResourcePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodFindResourcePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FindResource) (Return Type : Resource) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_FindResource_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFindResource, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (FindResource) (Return Type : Resource) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_FindResource_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodFindResource, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPermissionGroups) (Return Type : IList<Group>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Resources_GetPermissionGroups_Method_Call_Internally(Type[] types)
        {
            var methodGetPermissionGroupsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcesInstance, MethodGetPermissionGroups, Fixture, methodGetPermissionGroupsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetPermissionGroups) (Return Type : IList<Group>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_GetPermissionGroups_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _resourcesInstance.GetPermissionGroups();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetPermissionGroups) (Return Type : IList<Group>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_GetPermissionGroups_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetPermissionGroupsPrametersTypes = null;
            object[] parametersOfGetPermissionGroups = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetPermissionGroups, methodGetPermissionGroupsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Resources, IList<Group>>(_resourcesInstanceFixture, out exception1, parametersOfGetPermissionGroups);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Resources, IList<Group>>(_resourcesInstance, MethodGetPermissionGroups, parametersOfGetPermissionGroups, methodGetPermissionGroupsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetPermissionGroups.ShouldBeNull();
            methodGetPermissionGroupsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetPermissionGroups) (Return Type : IList<Group>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_GetPermissionGroups_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetPermissionGroupsPrametersTypes = null;
            object[] parametersOfGetPermissionGroups = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Resources, IList<Group>>(_resourcesInstance, MethodGetPermissionGroups, parametersOfGetPermissionGroups, methodGetPermissionGroupsPrametersTypes);

            // Assert
            parametersOfGetPermissionGroups.ShouldBeNull();
            methodGetPermissionGroupsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPermissionGroups) (Return Type : IList<Group>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_GetPermissionGroups_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetPermissionGroupsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcesInstance, MethodGetPermissionGroups, Fixture, methodGetPermissionGroupsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetPermissionGroupsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetPermissionGroups) (Return Type : IList<Group>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_GetPermissionGroups_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetPermissionGroupsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcesInstance, MethodGetPermissionGroups, Fixture, methodGetPermissionGroupsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetPermissionGroupsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetPermissionGroups) (Return Type : IList<Group>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_GetPermissionGroups_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetPermissionGroups, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetResourceCostCategoryRole) (Return Type : Role) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Resources_GetResourceCostCategoryRole_Method_Call_Internally(Type[] types)
        {
            var methodGetResourceCostCategoryRolePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcesInstance, MethodGetResourceCostCategoryRole, Fixture, methodGetResourceCostCategoryRolePrametersTypes);
        }

        #endregion

        #region Method Call : (GetResourceCostCategoryRole) (Return Type : Role) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_GetResourceCostCategoryRole_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var id = CreateType<int?>();
            var externalId = CreateType<string>();
            var username = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _resourcesInstance.GetResourceCostCategoryRole(id, externalId, username);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetResourceCostCategoryRole) (Return Type : Role) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_GetResourceCostCategoryRole_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var id = CreateType<int?>();
            var externalId = CreateType<string>();
            var username = CreateType<string>();
            var methodGetResourceCostCategoryRolePrametersTypes = new Type[] { typeof(int?), typeof(string), typeof(string) };
            object[] parametersOfGetResourceCostCategoryRole = { id, externalId, username };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetResourceCostCategoryRole, methodGetResourceCostCategoryRolePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Resources, Role>(_resourcesInstanceFixture, out exception1, parametersOfGetResourceCostCategoryRole);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Resources, Role>(_resourcesInstance, MethodGetResourceCostCategoryRole, parametersOfGetResourceCostCategoryRole, methodGetResourceCostCategoryRolePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetResourceCostCategoryRole.ShouldNotBeNull();
            parametersOfGetResourceCostCategoryRole.Length.ShouldBe(3);
            methodGetResourceCostCategoryRolePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetResourceCostCategoryRole) (Return Type : Role) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_GetResourceCostCategoryRole_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var id = CreateType<int?>();
            var externalId = CreateType<string>();
            var username = CreateType<string>();
            var methodGetResourceCostCategoryRolePrametersTypes = new Type[] { typeof(int?), typeof(string), typeof(string) };
            object[] parametersOfGetResourceCostCategoryRole = { id, externalId, username };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Resources, Role>(_resourcesInstance, MethodGetResourceCostCategoryRole, parametersOfGetResourceCostCategoryRole, methodGetResourceCostCategoryRolePrametersTypes);

            // Assert
            parametersOfGetResourceCostCategoryRole.ShouldNotBeNull();
            parametersOfGetResourceCostCategoryRole.Length.ShouldBe(3);
            methodGetResourceCostCategoryRolePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetResourceCostCategoryRole) (Return Type : Role) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_GetResourceCostCategoryRole_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetResourceCostCategoryRolePrametersTypes = new Type[] { typeof(int?), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcesInstance, MethodGetResourceCostCategoryRole, Fixture, methodGetResourceCostCategoryRolePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetResourceCostCategoryRolePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetResourceCostCategoryRole) (Return Type : Role) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_GetResourceCostCategoryRole_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetResourceCostCategoryRolePrametersTypes = new Type[] { typeof(int?), typeof(string), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcesInstance, MethodGetResourceCostCategoryRole, Fixture, methodGetResourceCostCategoryRolePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetResourceCostCategoryRolePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourceCostCategoryRole) (Return Type : Role) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_GetResourceCostCategoryRole_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetResourceCostCategoryRole, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetResourceCostCategoryRole) (Return Type : Role) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_GetResourceCostCategoryRole_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetResourceCostCategoryRole, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourcePermissionGroups) (Return Type : IList<Group>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Resources_GetResourcePermissionGroups_Method_Call_Internally(Type[] types)
        {
            var methodGetResourcePermissionGroupsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcesInstance, MethodGetResourcePermissionGroups, Fixture, methodGetResourcePermissionGroupsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetResourcePermissionGroups) (Return Type : IList<Group>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_GetResourcePermissionGroups_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var id = CreateType<int?>();
            var externalId = CreateType<string>();
            var username = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _resourcesInstance.GetResourcePermissionGroups(id, externalId, username);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetResourcePermissionGroups) (Return Type : IList<Group>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_GetResourcePermissionGroups_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var id = CreateType<int?>();
            var externalId = CreateType<string>();
            var username = CreateType<string>();
            var methodGetResourcePermissionGroupsPrametersTypes = new Type[] { typeof(int?), typeof(string), typeof(string) };
            object[] parametersOfGetResourcePermissionGroups = { id, externalId, username };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetResourcePermissionGroups, methodGetResourcePermissionGroupsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Resources, IList<Group>>(_resourcesInstanceFixture, out exception1, parametersOfGetResourcePermissionGroups);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Resources, IList<Group>>(_resourcesInstance, MethodGetResourcePermissionGroups, parametersOfGetResourcePermissionGroups, methodGetResourcePermissionGroupsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetResourcePermissionGroups.ShouldNotBeNull();
            parametersOfGetResourcePermissionGroups.Length.ShouldBe(3);
            methodGetResourcePermissionGroupsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetResourcePermissionGroups) (Return Type : IList<Group>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_GetResourcePermissionGroups_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var id = CreateType<int?>();
            var externalId = CreateType<string>();
            var username = CreateType<string>();
            var methodGetResourcePermissionGroupsPrametersTypes = new Type[] { typeof(int?), typeof(string), typeof(string) };
            object[] parametersOfGetResourcePermissionGroups = { id, externalId, username };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Resources, IList<Group>>(_resourcesInstance, MethodGetResourcePermissionGroups, parametersOfGetResourcePermissionGroups, methodGetResourcePermissionGroupsPrametersTypes);

            // Assert
            parametersOfGetResourcePermissionGroups.ShouldNotBeNull();
            parametersOfGetResourcePermissionGroups.Length.ShouldBe(3);
            methodGetResourcePermissionGroupsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetResourcePermissionGroups) (Return Type : IList<Group>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_GetResourcePermissionGroups_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetResourcePermissionGroupsPrametersTypes = new Type[] { typeof(int?), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcesInstance, MethodGetResourcePermissionGroups, Fixture, methodGetResourcePermissionGroupsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetResourcePermissionGroupsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetResourcePermissionGroups) (Return Type : IList<Group>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_GetResourcePermissionGroups_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetResourcePermissionGroupsPrametersTypes = new Type[] { typeof(int?), typeof(string), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcesInstance, MethodGetResourcePermissionGroups, Fixture, methodGetResourcePermissionGroupsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetResourcePermissionGroupsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourcePermissionGroups) (Return Type : IList<Group>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_GetResourcePermissionGroups_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetResourcePermissionGroups, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetResourcePermissionGroups) (Return Type : IList<Group>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_GetResourcePermissionGroups_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetResourcePermissionGroups, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateResource) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Resources_UpdateResource_Method_Call_Internally(Type[] types)
        {
            var methodUpdateResourcePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcesInstance, MethodUpdateResource, Fixture, methodUpdateResourcePrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateResource) (Return Type : int) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_UpdateResource_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var resource = CreateType<Resource>();
            Action executeAction = null;

            // Act
            executeAction = () => _resourcesInstance.UpdateResource(resource);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateResource) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_UpdateResource_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var resource = CreateType<Resource>();
            var methodUpdateResourcePrametersTypes = new Type[] { typeof(Resource) };
            object[] parametersOfUpdateResource = { resource };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateResource, methodUpdateResourcePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Resources, int>(_resourcesInstanceFixture, out exception1, parametersOfUpdateResource);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Resources, int>(_resourcesInstance, MethodUpdateResource, parametersOfUpdateResource, methodUpdateResourcePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUpdateResource.ShouldNotBeNull();
            parametersOfUpdateResource.Length.ShouldBe(1);
            methodUpdateResourcePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (UpdateResource) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_UpdateResource_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var resource = CreateType<Resource>();
            var methodUpdateResourcePrametersTypes = new Type[] { typeof(Resource) };
            object[] parametersOfUpdateResource = { resource };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateResource, methodUpdateResourcePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Resources, int>(_resourcesInstanceFixture, out exception1, parametersOfUpdateResource);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Resources, int>(_resourcesInstance, MethodUpdateResource, parametersOfUpdateResource, methodUpdateResourcePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUpdateResource.ShouldNotBeNull();
            parametersOfUpdateResource.Length.ShouldBe(1);
            methodUpdateResourcePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (UpdateResource) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_UpdateResource_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var resource = CreateType<Resource>();
            var methodUpdateResourcePrametersTypes = new Type[] { typeof(Resource) };
            object[] parametersOfUpdateResource = { resource };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Resources, int>(_resourcesInstance, MethodUpdateResource, parametersOfUpdateResource, methodUpdateResourcePrametersTypes);

            // Assert
            parametersOfUpdateResource.ShouldNotBeNull();
            parametersOfUpdateResource.Length.ShouldBe(1);
            methodUpdateResourcePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateResource) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_UpdateResource_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateResourcePrametersTypes = new Type[] { typeof(Resource) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcesInstance, MethodUpdateResource, Fixture, methodUpdateResourcePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateResourcePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateResource) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_UpdateResource_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateResource, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateResource) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resources_UpdateResource_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateResource, 0);
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
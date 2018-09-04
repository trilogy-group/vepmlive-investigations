using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web.UI.WebControls;
using System.Xml;
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.AutoFixtureSetup;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using WEPeopleQuery = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.WEPeopleQuery" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class WEPeopleQueryTest : AbstractBaseSetupTypedTest<WEPeopleQuery>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WEPeopleQuery) Initializer

        private const string MethodWEPeopleQuery_Load = "WEPeopleQuery_Load";
        private const string MethodIssueQuery = "IssueQuery";
        private const string MethodGetEntity = "GetEntity";
        private const string FielddtUsers = "dtUsers";
        private const string FieldCurrentWeb = "CurrentWeb";
        private Type _wEPeopleQueryInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private WEPeopleQuery _wEPeopleQueryInstance;
        private WEPeopleQuery _wEPeopleQueryInstanceFixture;

        #region General Initializer : Class (WEPeopleQuery) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WEPeopleQuery" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _wEPeopleQueryInstanceType = typeof(WEPeopleQuery);
            _wEPeopleQueryInstanceFixture = Create(true);
            _wEPeopleQueryInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WEPeopleQuery)

        #region General Initializer : Class (WEPeopleQuery) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="WEPeopleQuery" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodWEPeopleQuery_Load, 0)]
        [TestCase(MethodIssueQuery, 0)]
        [TestCase(MethodGetEntity, 0)]
        public void AUT_WEPeopleQuery_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_wEPeopleQueryInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (WEPeopleQuery) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="WEPeopleQuery" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FielddtUsers)]
        [TestCase(FieldCurrentWeb)]
        public void AUT_WEPeopleQuery_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_wEPeopleQueryInstanceFixture, 
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
        ///     Class (<see cref="WEPeopleQuery" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_WEPeopleQuery_Is_Instance_Present_Test()
        {
            // Assert
            _wEPeopleQueryInstanceType.ShouldNotBeNull();
            _wEPeopleQueryInstance.ShouldNotBeNull();
            _wEPeopleQueryInstanceFixture.ShouldNotBeNull();
            _wEPeopleQueryInstance.ShouldBeAssignableTo<WEPeopleQuery>();
            _wEPeopleQueryInstanceFixture.ShouldBeAssignableTo<WEPeopleQuery>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (WEPeopleQuery) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_WEPeopleQuery_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var _CurrentWeb = CreateType<Guid>();
            WEPeopleQuery instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new WEPeopleQuery(_CurrentWeb);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _wEPeopleQueryInstance.ShouldNotBeNull();
            _wEPeopleQueryInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<WEPeopleQuery>();
        }

        #endregion

        #region General Constructor : Class (WEPeopleQuery) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_WEPeopleQuery_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var _CurrentWeb = CreateType<Guid>();
            WEPeopleQuery instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new WEPeopleQuery(_CurrentWeb);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _wEPeopleQueryInstance.ShouldNotBeNull();
            _wEPeopleQueryInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="WEPeopleQuery" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodWEPeopleQuery_Load)]
        [TestCase(MethodIssueQuery)]
        [TestCase(MethodGetEntity)]
        public void AUT_WEPeopleQuery_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<WEPeopleQuery>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (WEPeopleQuery_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WEPeopleQuery_WEPeopleQuery_Load_Method_Call_Internally(Type[] types)
        {
            var methodWEPeopleQuery_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wEPeopleQueryInstance, MethodWEPeopleQuery_Load, Fixture, methodWEPeopleQuery_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (WEPeopleQuery_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEPeopleQuery_WEPeopleQuery_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodWEPeopleQuery_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfWEPeopleQuery_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodWEPeopleQuery_Load, methodWEPeopleQuery_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_wEPeopleQueryInstanceFixture, parametersOfWEPeopleQuery_Load);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfWEPeopleQuery_Load.ShouldNotBeNull();
            parametersOfWEPeopleQuery_Load.Length.ShouldBe(2);
            methodWEPeopleQuery_LoadPrametersTypes.Length.ShouldBe(2);
            methodWEPeopleQuery_LoadPrametersTypes.Length.ShouldBe(parametersOfWEPeopleQuery_Load.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (WEPeopleQuery_Load) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEPeopleQuery_WEPeopleQuery_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodWEPeopleQuery_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfWEPeopleQuery_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_wEPeopleQueryInstance, MethodWEPeopleQuery_Load, parametersOfWEPeopleQuery_Load, methodWEPeopleQuery_LoadPrametersTypes);

            // Assert
            parametersOfWEPeopleQuery_Load.ShouldNotBeNull();
            parametersOfWEPeopleQuery_Load.Length.ShouldBe(2);
            methodWEPeopleQuery_LoadPrametersTypes.Length.ShouldBe(2);
            methodWEPeopleQuery_LoadPrametersTypes.Length.ShouldBe(parametersOfWEPeopleQuery_Load.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WEPeopleQuery_Load) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEPeopleQuery_WEPeopleQuery_Load_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodWEPeopleQuery_Load, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (WEPeopleQuery_Load) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEPeopleQuery_WEPeopleQuery_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodWEPeopleQuery_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wEPeopleQueryInstance, MethodWEPeopleQuery_Load, Fixture, methodWEPeopleQuery_LoadPrametersTypes);

            // Assert
            methodWEPeopleQuery_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WEPeopleQuery_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEPeopleQuery_WEPeopleQuery_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodWEPeopleQuery_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_wEPeopleQueryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IssueQuery) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WEPeopleQuery_IssueQuery_Method_Call_Internally(Type[] types)
        {
            var methodIssueQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wEPeopleQueryInstance, MethodIssueQuery, Fixture, methodIssueQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (IssueQuery) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEPeopleQuery_IssueQuery_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var search = CreateType<string>();
            var groupName = CreateType<string>();
            var pageIndex = CreateType<int>();
            var pageSize = CreateType<int>();
            var methodIssueQueryPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(int), typeof(int) };
            object[] parametersOfIssueQuery = { search, groupName, pageIndex, pageSize };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIssueQuery, methodIssueQueryPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<WEPeopleQuery, int>(_wEPeopleQueryInstanceFixture, out exception1, parametersOfIssueQuery);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<WEPeopleQuery, int>(_wEPeopleQueryInstance, MethodIssueQuery, parametersOfIssueQuery, methodIssueQueryPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIssueQuery.ShouldNotBeNull();
            parametersOfIssueQuery.Length.ShouldBe(4);
            methodIssueQueryPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (IssueQuery) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEPeopleQuery_IssueQuery_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var search = CreateType<string>();
            var groupName = CreateType<string>();
            var pageIndex = CreateType<int>();
            var pageSize = CreateType<int>();
            var methodIssueQueryPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(int), typeof(int) };
            object[] parametersOfIssueQuery = { search, groupName, pageIndex, pageSize };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIssueQuery, methodIssueQueryPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<WEPeopleQuery, int>(_wEPeopleQueryInstanceFixture, out exception1, parametersOfIssueQuery);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<WEPeopleQuery, int>(_wEPeopleQueryInstance, MethodIssueQuery, parametersOfIssueQuery, methodIssueQueryPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIssueQuery.ShouldNotBeNull();
            parametersOfIssueQuery.Length.ShouldBe(4);
            methodIssueQueryPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (IssueQuery) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEPeopleQuery_IssueQuery_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var search = CreateType<string>();
            var groupName = CreateType<string>();
            var pageIndex = CreateType<int>();
            var pageSize = CreateType<int>();
            var methodIssueQueryPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(int), typeof(int) };
            object[] parametersOfIssueQuery = { search, groupName, pageIndex, pageSize };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<WEPeopleQuery, int>(_wEPeopleQueryInstance, MethodIssueQuery, parametersOfIssueQuery, methodIssueQueryPrametersTypes);

            // Assert
            parametersOfIssueQuery.ShouldNotBeNull();
            parametersOfIssueQuery.Length.ShouldBe(4);
            methodIssueQueryPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IssueQuery) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEPeopleQuery_IssueQuery_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIssueQueryPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(int), typeof(int) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wEPeopleQueryInstance, MethodIssueQuery, Fixture, methodIssueQueryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIssueQueryPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IssueQuery) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEPeopleQuery_IssueQuery_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIssueQuery, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_wEPeopleQueryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IssueQuery) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEPeopleQuery_IssueQuery_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodIssueQuery, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetEntity) (Return Type : PickerEntity) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WEPeopleQuery_GetEntity_Method_Call_Internally(Type[] types)
        {
            var methodGetEntityPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wEPeopleQueryInstance, MethodGetEntity, Fixture, methodGetEntityPrametersTypes);
        }

        #endregion

        #region Method Call : (GetEntity) (Return Type : PickerEntity) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEPeopleQuery_GetEntity_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var dr = CreateType<DataRow>();
            Action executeAction = null;

            // Act
            executeAction = () => _wEPeopleQueryInstance.GetEntity(dr);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetEntity) (Return Type : PickerEntity) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEPeopleQuery_GetEntity_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var dr = CreateType<DataRow>();
            var methodGetEntityPrametersTypes = new Type[] { typeof(DataRow) };
            object[] parametersOfGetEntity = { dr };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetEntity, methodGetEntityPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<WEPeopleQuery, PickerEntity>(_wEPeopleQueryInstanceFixture, out exception1, parametersOfGetEntity);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<WEPeopleQuery, PickerEntity>(_wEPeopleQueryInstance, MethodGetEntity, parametersOfGetEntity, methodGetEntityPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetEntity.ShouldNotBeNull();
            parametersOfGetEntity.Length.ShouldBe(1);
            methodGetEntityPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetEntity) (Return Type : PickerEntity) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEPeopleQuery_GetEntity_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dr = CreateType<DataRow>();
            var methodGetEntityPrametersTypes = new Type[] { typeof(DataRow) };
            object[] parametersOfGetEntity = { dr };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<WEPeopleQuery, PickerEntity>(_wEPeopleQueryInstance, MethodGetEntity, parametersOfGetEntity, methodGetEntityPrametersTypes);

            // Assert
            parametersOfGetEntity.ShouldNotBeNull();
            parametersOfGetEntity.Length.ShouldBe(1);
            methodGetEntityPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetEntity) (Return Type : PickerEntity) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEPeopleQuery_GetEntity_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetEntityPrametersTypes = new Type[] { typeof(DataRow) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wEPeopleQueryInstance, MethodGetEntity, Fixture, methodGetEntityPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetEntityPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetEntity) (Return Type : PickerEntity) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEPeopleQuery_GetEntity_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetEntityPrametersTypes = new Type[] { typeof(DataRow) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wEPeopleQueryInstance, MethodGetEntity, Fixture, methodGetEntityPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetEntityPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetEntity) (Return Type : PickerEntity) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEPeopleQuery_GetEntity_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetEntity, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_wEPeopleQueryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetEntity) (Return Type : PickerEntity) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEPeopleQuery_GetEntity_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetEntity, 0);
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
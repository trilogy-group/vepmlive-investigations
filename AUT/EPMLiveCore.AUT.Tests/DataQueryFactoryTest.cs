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
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using DataQueryFactory = EPMLiveCore;
using static EPMLiveCore.DataQueryFactory;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.DataQueryFactory" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class DataQueryFactoryTest : AbstractBaseSetupTypedTest<DataQueryFactory>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DataQueryFactory) Initializer

        private const string PropertyListIds = "ListIds";
        private const string PropertyListType = "ListType";
        private const string PropertyViewFields = "ViewFields";
        private const string PropertyQuery = "Query";
        private const string PropertyWebs = "Webs";
        private const string PropertyDataQuery = "DataQuery";
        private const string MethodConstructDataQuery = "ConstructDataQuery";
        private const string Field_listIds = "_listIds";
        private const string Field_listType = "_listType";
        private const string Field_query = "_query";
        private const string Field_viewFields = "_viewFields";
        private const string Field_webs = "_webs";
        private Type _dataQueryFactoryInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DataQueryFactory _dataQueryFactoryInstance;
        private DataQueryFactory _dataQueryFactoryInstanceFixture;

        #region General Initializer : Class (DataQueryFactory) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DataQueryFactory" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _dataQueryFactoryInstanceType = typeof(DataQueryFactory);
            _dataQueryFactoryInstanceFixture = Create(true);
            _dataQueryFactoryInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DataQueryFactory)

        #region General Initializer : Class (DataQueryFactory) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="DataQueryFactory" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodConstructDataQuery, 0)]
        public void AUT_DataQueryFactory_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_dataQueryFactoryInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DataQueryFactory) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DataQueryFactory" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyListIds)]
        [TestCase(PropertyListType)]
        [TestCase(PropertyViewFields)]
        [TestCase(PropertyQuery)]
        [TestCase(PropertyWebs)]
        [TestCase(PropertyDataQuery)]
        public void AUT_DataQueryFactory_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_dataQueryFactoryInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DataQueryFactory) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DataQueryFactory" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_listIds)]
        [TestCase(Field_listType)]
        [TestCase(Field_query)]
        [TestCase(Field_viewFields)]
        [TestCase(Field_webs)]
        public void AUT_DataQueryFactory_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_dataQueryFactoryInstanceFixture, 
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
        ///     Class (<see cref="DataQueryFactory" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_DataQueryFactory_Is_Instance_Present_Test()
        {
            // Assert
            _dataQueryFactoryInstanceType.ShouldNotBeNull();
            _dataQueryFactoryInstance.ShouldNotBeNull();
            _dataQueryFactoryInstanceFixture.ShouldNotBeNull();
            _dataQueryFactoryInstance.ShouldBeAssignableTo<DataQueryFactory>();
            _dataQueryFactoryInstanceFixture.ShouldBeAssignableTo<DataQueryFactory>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DataQueryFactory) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_DataQueryFactory_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DataQueryFactory instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _dataQueryFactoryInstanceType.ShouldNotBeNull();
            _dataQueryFactoryInstance.ShouldNotBeNull();
            _dataQueryFactoryInstanceFixture.ShouldNotBeNull();
            _dataQueryFactoryInstance.ShouldBeAssignableTo<DataQueryFactory>();
            _dataQueryFactoryInstanceFixture.ShouldBeAssignableTo<DataQueryFactory>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DataQueryFactory) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(List<Guid>) , PropertyListIds)]
        [TestCaseGeneric(typeof(BaseType) , PropertyListType)]
        [TestCaseGeneric(typeof(List<string>) , PropertyViewFields)]
        [TestCaseGeneric(typeof(string) , PropertyQuery)]
        [TestCaseGeneric(typeof(Scope) , PropertyWebs)]
        [TestCaseGeneric(typeof(SPSiteDataQuery) , PropertyDataQuery)]
        public void AUT_DataQueryFactory_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DataQueryFactory, T>(_dataQueryFactoryInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DataQueryFactory) => Property (DataQuery) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_DataQueryFactory_DataQuery_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyDataQuery);
            Action currentAction = () => propertyInfo.SetValue(_dataQueryFactoryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DataQueryFactory) => Property (DataQuery) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_DataQueryFactory_Public_Class_DataQuery_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDataQuery);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DataQueryFactory) => Property (ListIds) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_DataQueryFactory_Public_Class_ListIds_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyListIds);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DataQueryFactory) => Property (ListType) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_DataQueryFactory_ListType_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyListType);
            Action currentAction = () => propertyInfo.SetValue(_dataQueryFactoryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DataQueryFactory) => Property (ListType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_DataQueryFactory_Public_Class_ListType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyListType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DataQueryFactory) => Property (Query) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_DataQueryFactory_Public_Class_Query_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyQuery);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DataQueryFactory) => Property (ViewFields) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_DataQueryFactory_Public_Class_ViewFields_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyViewFields);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DataQueryFactory) => Property (Webs) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_DataQueryFactory_Webs_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyWebs);
            Action currentAction = () => propertyInfo.SetValue(_dataQueryFactoryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DataQueryFactory) => Property (Webs) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_DataQueryFactory_Public_Class_Webs_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyWebs);

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
        ///      Class (<see cref="DataQueryFactory" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodConstructDataQuery)]
        public void AUT_DataQueryFactory_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<DataQueryFactory>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (ConstructDataQuery) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DataQueryFactory_ConstructDataQuery_Method_Call_Internally(Type[] types)
        {
            var methodConstructDataQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dataQueryFactoryInstance, MethodConstructDataQuery, Fixture, methodConstructDataQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (ConstructDataQuery) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataQueryFactory_ConstructDataQuery_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var q = CreateType<SPSiteDataQuery>();
            Action executeAction = null;

            // Act
            executeAction = () => _dataQueryFactoryInstance.ConstructDataQuery(q);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ConstructDataQuery) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataQueryFactory_ConstructDataQuery_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var q = CreateType<SPSiteDataQuery>();
            var methodConstructDataQueryPrametersTypes = new Type[] { typeof(SPSiteDataQuery) };
            object[] parametersOfConstructDataQuery = { q };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodConstructDataQuery, methodConstructDataQueryPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_dataQueryFactoryInstanceFixture, parametersOfConstructDataQuery);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfConstructDataQuery.ShouldNotBeNull();
            parametersOfConstructDataQuery.Length.ShouldBe(1);
            methodConstructDataQueryPrametersTypes.Length.ShouldBe(1);
            methodConstructDataQueryPrametersTypes.Length.ShouldBe(parametersOfConstructDataQuery.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConstructDataQuery) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataQueryFactory_ConstructDataQuery_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var q = CreateType<SPSiteDataQuery>();
            var methodConstructDataQueryPrametersTypes = new Type[] { typeof(SPSiteDataQuery) };
            object[] parametersOfConstructDataQuery = { q };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_dataQueryFactoryInstance, MethodConstructDataQuery, parametersOfConstructDataQuery, methodConstructDataQueryPrametersTypes);

            // Assert
            parametersOfConstructDataQuery.ShouldNotBeNull();
            parametersOfConstructDataQuery.Length.ShouldBe(1);
            methodConstructDataQueryPrametersTypes.Length.ShouldBe(1);
            methodConstructDataQueryPrametersTypes.Length.ShouldBe(parametersOfConstructDataQuery.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConstructDataQuery) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataQueryFactory_ConstructDataQuery_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodConstructDataQuery, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ConstructDataQuery) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataQueryFactory_ConstructDataQuery_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodConstructDataQueryPrametersTypes = new Type[] { typeof(SPSiteDataQuery) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dataQueryFactoryInstance, MethodConstructDataQuery, Fixture, methodConstructDataQueryPrametersTypes);

            // Assert
            methodConstructDataQueryPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConstructDataQuery) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataQueryFactory_ConstructDataQuery_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodConstructDataQuery, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_dataQueryFactoryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
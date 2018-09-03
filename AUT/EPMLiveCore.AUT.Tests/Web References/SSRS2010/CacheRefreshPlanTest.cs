using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.AutoFixtureSetup;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore.SSRS2010;
using CacheRefreshPlan = EPMLiveCore.SSRS2010;

namespace EPMLiveCore.SSRS2010
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SSRS2010.CacheRefreshPlan" />)
    ///     and namespace <see cref="EPMLiveCore.SSRS2010"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CacheRefreshPlanTest : AbstractBaseSetupTypedTest<CacheRefreshPlan>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CacheRefreshPlan) Initializer

        private const string PropertyCacheRefreshPlanID = "CacheRefreshPlanID";
        private const string PropertyItemPath = "ItemPath";
        private const string PropertyDescription = "Description";
        private const string PropertyState = "State";
        private const string PropertyLastExecuted = "LastExecuted";
        private const string PropertyModifiedDate = "ModifiedDate";
        private const string PropertyModifiedBy = "ModifiedBy";
        private const string PropertyLastRunStatus = "LastRunStatus";
        private const string FieldcacheRefreshPlanIDField = "cacheRefreshPlanIDField";
        private const string FielditemPathField = "itemPathField";
        private const string FielddescriptionField = "descriptionField";
        private const string FieldstateField = "stateField";
        private const string FieldlastExecutedField = "lastExecutedField";
        private const string FieldmodifiedDateField = "modifiedDateField";
        private const string FieldmodifiedByField = "modifiedByField";
        private const string FieldlastRunStatusField = "lastRunStatusField";
        private Type _cacheRefreshPlanInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CacheRefreshPlan _cacheRefreshPlanInstance;
        private CacheRefreshPlan _cacheRefreshPlanInstanceFixture;

        #region General Initializer : Class (CacheRefreshPlan) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CacheRefreshPlan" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _cacheRefreshPlanInstanceType = typeof(CacheRefreshPlan);
            _cacheRefreshPlanInstanceFixture = Create(true);
            _cacheRefreshPlanInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CacheRefreshPlan)

        #region General Initializer : Class (CacheRefreshPlan) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CacheRefreshPlan" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyCacheRefreshPlanID)]
        [TestCase(PropertyItemPath)]
        [TestCase(PropertyDescription)]
        [TestCase(PropertyState)]
        [TestCase(PropertyLastExecuted)]
        [TestCase(PropertyModifiedDate)]
        [TestCase(PropertyModifiedBy)]
        [TestCase(PropertyLastRunStatus)]
        public void AUT_CacheRefreshPlan_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_cacheRefreshPlanInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CacheRefreshPlan) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CacheRefreshPlan" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcacheRefreshPlanIDField)]
        [TestCase(FielditemPathField)]
        [TestCase(FielddescriptionField)]
        [TestCase(FieldstateField)]
        [TestCase(FieldlastExecutedField)]
        [TestCase(FieldmodifiedDateField)]
        [TestCase(FieldmodifiedByField)]
        [TestCase(FieldlastRunStatusField)]
        public void AUT_CacheRefreshPlan_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_cacheRefreshPlanInstanceFixture, 
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
        ///     Class (<see cref="CacheRefreshPlan" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_CacheRefreshPlan_Is_Instance_Present_Test()
        {
            // Assert
            _cacheRefreshPlanInstanceType.ShouldNotBeNull();
            _cacheRefreshPlanInstance.ShouldNotBeNull();
            _cacheRefreshPlanInstanceFixture.ShouldNotBeNull();
            _cacheRefreshPlanInstance.ShouldBeAssignableTo<CacheRefreshPlan>();
            _cacheRefreshPlanInstanceFixture.ShouldBeAssignableTo<CacheRefreshPlan>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CacheRefreshPlan) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_CacheRefreshPlan_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CacheRefreshPlan instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _cacheRefreshPlanInstanceType.ShouldNotBeNull();
            _cacheRefreshPlanInstance.ShouldNotBeNull();
            _cacheRefreshPlanInstanceFixture.ShouldNotBeNull();
            _cacheRefreshPlanInstance.ShouldBeAssignableTo<CacheRefreshPlan>();
            _cacheRefreshPlanInstanceFixture.ShouldBeAssignableTo<CacheRefreshPlan>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CacheRefreshPlan) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyCacheRefreshPlanID)]
        [TestCaseGeneric(typeof(string) , PropertyItemPath)]
        [TestCaseGeneric(typeof(string) , PropertyDescription)]
        [TestCaseGeneric(typeof(CacheRefreshPlanState) , PropertyState)]
        [TestCaseGeneric(typeof(System.DateTime) , PropertyLastExecuted)]
        [TestCaseGeneric(typeof(System.DateTime) , PropertyModifiedDate)]
        [TestCaseGeneric(typeof(string) , PropertyModifiedBy)]
        [TestCaseGeneric(typeof(string) , PropertyLastRunStatus)]
        public void AUT_CacheRefreshPlan_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CacheRefreshPlan, T>(_cacheRefreshPlanInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (CacheRefreshPlan) => Property (CacheRefreshPlanID) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CacheRefreshPlan_Public_Class_CacheRefreshPlanID_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCacheRefreshPlanID);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CacheRefreshPlan) => Property (Description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CacheRefreshPlan_Public_Class_Description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDescription);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CacheRefreshPlan) => Property (ItemPath) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CacheRefreshPlan_Public_Class_ItemPath_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyItemPath);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CacheRefreshPlan) => Property (LastExecuted) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CacheRefreshPlan_LastExecuted_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyLastExecuted);
            Action currentAction = () => propertyInfo.SetValue(_cacheRefreshPlanInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CacheRefreshPlan) => Property (LastExecuted) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CacheRefreshPlan_Public_Class_LastExecuted_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyLastExecuted);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CacheRefreshPlan) => Property (LastRunStatus) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CacheRefreshPlan_Public_Class_LastRunStatus_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyLastRunStatus);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CacheRefreshPlan) => Property (ModifiedBy) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CacheRefreshPlan_Public_Class_ModifiedBy_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyModifiedBy);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CacheRefreshPlan) => Property (ModifiedDate) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CacheRefreshPlan_ModifiedDate_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyModifiedDate);
            Action currentAction = () => propertyInfo.SetValue(_cacheRefreshPlanInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CacheRefreshPlan) => Property (ModifiedDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CacheRefreshPlan_Public_Class_ModifiedDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyModifiedDate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CacheRefreshPlan) => Property (State) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CacheRefreshPlan_State_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyState);
            Action currentAction = () => propertyInfo.SetValue(_cacheRefreshPlanInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CacheRefreshPlan) => Property (State) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CacheRefreshPlan_Public_Class_State_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyState);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #endregion

        #endregion
    }
}
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
using EPMLiveCore.SSRS2006;
using ReportHistorySnapshot = EPMLiveCore.SSRS2006;

namespace EPMLiveCore.SSRS2006
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SSRS2006.ReportHistorySnapshot" />)
    ///     and namespace <see cref="EPMLiveCore.SSRS2006"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ReportHistorySnapshotTest : AbstractBaseSetupTypedTest<ReportHistorySnapshot>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportHistorySnapshot) Initializer

        private const string PropertyHistoryID = "HistoryID";
        private const string PropertyCreationDate = "CreationDate";
        private const string PropertySize = "Size";
        private const string FieldhistoryIDField = "historyIDField";
        private const string FieldcreationDateField = "creationDateField";
        private const string FieldsizeField = "sizeField";
        private Type _reportHistorySnapshotInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportHistorySnapshot _reportHistorySnapshotInstance;
        private ReportHistorySnapshot _reportHistorySnapshotInstanceFixture;

        #region General Initializer : Class (ReportHistorySnapshot) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportHistorySnapshot" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportHistorySnapshotInstanceType = typeof(ReportHistorySnapshot);
            _reportHistorySnapshotInstanceFixture = Create(true);
            _reportHistorySnapshotInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportHistorySnapshot)

        #region General Initializer : Class (ReportHistorySnapshot) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportHistorySnapshot" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyHistoryID)]
        [TestCase(PropertyCreationDate)]
        [TestCase(PropertySize)]
        public void AUT_ReportHistorySnapshot_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_reportHistorySnapshotInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ReportHistorySnapshot) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportHistorySnapshot" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldhistoryIDField)]
        [TestCase(FieldcreationDateField)]
        [TestCase(FieldsizeField)]
        public void AUT_ReportHistorySnapshot_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_reportHistorySnapshotInstanceFixture, 
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
        ///     Class (<see cref="ReportHistorySnapshot" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ReportHistorySnapshot_Is_Instance_Present_Test()
        {
            // Assert
            _reportHistorySnapshotInstanceType.ShouldNotBeNull();
            _reportHistorySnapshotInstance.ShouldNotBeNull();
            _reportHistorySnapshotInstanceFixture.ShouldNotBeNull();
            _reportHistorySnapshotInstance.ShouldBeAssignableTo<ReportHistorySnapshot>();
            _reportHistorySnapshotInstanceFixture.ShouldBeAssignableTo<ReportHistorySnapshot>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ReportHistorySnapshot) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ReportHistorySnapshot_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ReportHistorySnapshot instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _reportHistorySnapshotInstanceType.ShouldNotBeNull();
            _reportHistorySnapshotInstance.ShouldNotBeNull();
            _reportHistorySnapshotInstanceFixture.ShouldNotBeNull();
            _reportHistorySnapshotInstance.ShouldBeAssignableTo<ReportHistorySnapshot>();
            _reportHistorySnapshotInstanceFixture.ShouldBeAssignableTo<ReportHistorySnapshot>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ReportHistorySnapshot) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyHistoryID)]
        [TestCaseGeneric(typeof(System.DateTime) , PropertyCreationDate)]
        [TestCaseGeneric(typeof(int) , PropertySize)]
        public void AUT_ReportHistorySnapshot_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ReportHistorySnapshot, T>(_reportHistorySnapshotInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ReportHistorySnapshot) => Property (CreationDate) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportHistorySnapshot_CreationDate_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyCreationDate);
            Action currentAction = () => propertyInfo.SetValue(_reportHistorySnapshotInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportHistorySnapshot) => Property (CreationDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportHistorySnapshot_Public_Class_CreationDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCreationDate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportHistorySnapshot) => Property (HistoryID) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportHistorySnapshot_Public_Class_HistoryID_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyHistoryID);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportHistorySnapshot) => Property (Size) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportHistorySnapshot_Public_Class_Size_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySize);

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
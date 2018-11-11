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
using EPMLiveCore.WorkEngineSolutionStoreListSvc;
using GetListItemChangesWithKnowledgeCompletedEventArgs = EPMLiveCore.WorkEngineSolutionStoreListSvc;

namespace EPMLiveCore.WorkEngineSolutionStoreListSvc
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.WorkEngineSolutionStoreListSvc.GetListItemChangesWithKnowledgeCompletedEventArgs" />)
    ///     and namespace <see cref="EPMLiveCore.WorkEngineSolutionStoreListSvc"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class GetListItemChangesWithKnowledgeCompletedEventArgsTest : AbstractBaseSetupTypedTest<GetListItemChangesWithKnowledgeCompletedEventArgs>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (GetListItemChangesWithKnowledgeCompletedEventArgs) Initializer

        private const string PropertyResult = "Result";
        private const string Fieldresults = "results";
        private Type _getListItemChangesWithKnowledgeCompletedEventArgsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private GetListItemChangesWithKnowledgeCompletedEventArgs _getListItemChangesWithKnowledgeCompletedEventArgsInstance;
        private GetListItemChangesWithKnowledgeCompletedEventArgs _getListItemChangesWithKnowledgeCompletedEventArgsInstanceFixture;

        #region General Initializer : Class (GetListItemChangesWithKnowledgeCompletedEventArgs) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="GetListItemChangesWithKnowledgeCompletedEventArgs" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _getListItemChangesWithKnowledgeCompletedEventArgsInstanceType = typeof(GetListItemChangesWithKnowledgeCompletedEventArgs);
            _getListItemChangesWithKnowledgeCompletedEventArgsInstanceFixture = Create(true);
            _getListItemChangesWithKnowledgeCompletedEventArgsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (GetListItemChangesWithKnowledgeCompletedEventArgs)

        #region General Initializer : Class (GetListItemChangesWithKnowledgeCompletedEventArgs) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="GetListItemChangesWithKnowledgeCompletedEventArgs" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyResult)]
        public void AUT_GetListItemChangesWithKnowledgeCompletedEventArgs_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_getListItemChangesWithKnowledgeCompletedEventArgsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (GetListItemChangesWithKnowledgeCompletedEventArgs) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="GetListItemChangesWithKnowledgeCompletedEventArgs" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Fieldresults)]
        public void AUT_GetListItemChangesWithKnowledgeCompletedEventArgs_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_getListItemChangesWithKnowledgeCompletedEventArgsInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (GetListItemChangesWithKnowledgeCompletedEventArgs) => Property (Result) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetListItemChangesWithKnowledgeCompletedEventArgs_Result_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyResult);
            Action currentAction = () => propertyInfo.SetValue(_getListItemChangesWithKnowledgeCompletedEventArgsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (GetListItemChangesWithKnowledgeCompletedEventArgs) => Property (Result) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetListItemChangesWithKnowledgeCompletedEventArgs_Public_Class_Result_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyResult);

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
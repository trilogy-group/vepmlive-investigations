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
using ListParameterStatesCompletedEventArgs = EPMLiveCore.SSRS2010;

namespace EPMLiveCore.SSRS2010
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SSRS2010.ListParameterStatesCompletedEventArgs" />)
    ///     and namespace <see cref="EPMLiveCore.SSRS2010"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ListParameterStatesCompletedEventArgsTest : AbstractBaseSetupTypedTest<ListParameterStatesCompletedEventArgs>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ListParameterStatesCompletedEventArgs) Initializer

        private const string PropertyResult = "Result";
        private const string Fieldresults = "results";
        private Type _listParameterStatesCompletedEventArgsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ListParameterStatesCompletedEventArgs _listParameterStatesCompletedEventArgsInstance;
        private ListParameterStatesCompletedEventArgs _listParameterStatesCompletedEventArgsInstanceFixture;

        #region General Initializer : Class (ListParameterStatesCompletedEventArgs) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ListParameterStatesCompletedEventArgs" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _listParameterStatesCompletedEventArgsInstanceType = typeof(ListParameterStatesCompletedEventArgs);
            _listParameterStatesCompletedEventArgsInstanceFixture = Create(true);
            _listParameterStatesCompletedEventArgsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ListParameterStatesCompletedEventArgs)

        #region General Initializer : Class (ListParameterStatesCompletedEventArgs) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ListParameterStatesCompletedEventArgs" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyResult)]
        public void AUT_ListParameterStatesCompletedEventArgs_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_listParameterStatesCompletedEventArgsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ListParameterStatesCompletedEventArgs) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ListParameterStatesCompletedEventArgs" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Fieldresults)]
        public void AUT_ListParameterStatesCompletedEventArgs_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_listParameterStatesCompletedEventArgsInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ListParameterStatesCompletedEventArgs) => Property (Result) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ListParameterStatesCompletedEventArgs_Result_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyResult);
            Action currentAction = () => propertyInfo.SetValue(_listParameterStatesCompletedEventArgsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ListParameterStatesCompletedEventArgs) => Property (Result) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ListParameterStatesCompletedEventArgs_Public_Class_Result_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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
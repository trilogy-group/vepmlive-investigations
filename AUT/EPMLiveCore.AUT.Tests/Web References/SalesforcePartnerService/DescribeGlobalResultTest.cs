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
using EPMLiveCore.SalesforcePartnerService;
using DescribeGlobalResult = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.DescribeGlobalResult" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DescribeGlobalResultTest : AbstractBaseSetupTypedTest<DescribeGlobalResult>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DescribeGlobalResult) Initializer

        private const string Propertyencoding = "encoding";
        private const string PropertymaxBatchSize = "maxBatchSize";
        private const string Propertysobjects = "sobjects";
        private const string FieldencodingField = "encodingField";
        private const string FieldmaxBatchSizeField = "maxBatchSizeField";
        private const string FieldsobjectsField = "sobjectsField";
        private Type _describeGlobalResultInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DescribeGlobalResult _describeGlobalResultInstance;
        private DescribeGlobalResult _describeGlobalResultInstanceFixture;

        #region General Initializer : Class (DescribeGlobalResult) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DescribeGlobalResult" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _describeGlobalResultInstanceType = typeof(DescribeGlobalResult);
            _describeGlobalResultInstanceFixture = Create(true);
            _describeGlobalResultInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DescribeGlobalResult)

        #region General Initializer : Class (DescribeGlobalResult) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeGlobalResult" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyencoding)]
        [TestCase(PropertymaxBatchSize)]
        [TestCase(Propertysobjects)]
        public void AUT_DescribeGlobalResult_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_describeGlobalResultInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DescribeGlobalResult) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeGlobalResult" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldencodingField)]
        [TestCase(FieldmaxBatchSizeField)]
        [TestCase(FieldsobjectsField)]
        public void AUT_DescribeGlobalResult_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_describeGlobalResultInstanceFixture, 
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
        ///     Class (<see cref="DescribeGlobalResult" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DescribeGlobalResult_Is_Instance_Present_Test()
        {
            // Assert
            _describeGlobalResultInstanceType.ShouldNotBeNull();
            _describeGlobalResultInstance.ShouldNotBeNull();
            _describeGlobalResultInstanceFixture.ShouldNotBeNull();
            _describeGlobalResultInstance.ShouldBeAssignableTo<DescribeGlobalResult>();
            _describeGlobalResultInstanceFixture.ShouldBeAssignableTo<DescribeGlobalResult>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DescribeGlobalResult) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DescribeGlobalResult_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DescribeGlobalResult instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _describeGlobalResultInstanceType.ShouldNotBeNull();
            _describeGlobalResultInstance.ShouldNotBeNull();
            _describeGlobalResultInstanceFixture.ShouldNotBeNull();
            _describeGlobalResultInstance.ShouldBeAssignableTo<DescribeGlobalResult>();
            _describeGlobalResultInstanceFixture.ShouldBeAssignableTo<DescribeGlobalResult>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DescribeGlobalResult) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertyencoding)]
        [TestCaseGeneric(typeof(int) , PropertymaxBatchSize)]
        [TestCaseGeneric(typeof(DescribeGlobalSObjectResult[]) , Propertysobjects)]
        public void AUT_DescribeGlobalResult_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DescribeGlobalResult, T>(_describeGlobalResultInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeGlobalResult) => Property (encoding) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeGlobalResult_Public_Class_encoding_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyencoding);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeGlobalResult) => Property (maxBatchSize) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeGlobalResult_Public_Class_maxBatchSize_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertymaxBatchSize);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeGlobalResult) => Property (sobjects) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeGlobalResult_sobjects_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertysobjects);
            Action currentAction = () => propertyInfo.SetValue(_describeGlobalResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeGlobalResult) => Property (sobjects) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeGlobalResult_Public_Class_sobjects_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertysobjects);

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
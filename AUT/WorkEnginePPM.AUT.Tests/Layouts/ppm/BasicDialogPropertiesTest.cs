using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using PortfolioEngineCore;
using Should = Shouldly.Should;
using Shouldly;
using WorkEnginePPM.Layouts.ppm2;

namespace WorkEnginePPM.AUT.Tests.Layouts.ppm
{
    /// <summary>
    ///   Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.Layouts.ppm2.BasicDialogProperties" />)
    ///   and namespace <see cref="WorkEnginePPM.Layouts.ppm2" /> class using generator(v:0.2.1)'s
    ///   artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class BasicDialogPropertiesTest : AbstractBaseSetupTypedTest<BasicDialogProperties>
    {
        private const string PropertyId = "Id";
        private const string PropertyName = "Name";
        private const string PropertyDesc = "Desc";
        private const string PropertyDialogTitle = "DialogTitle";

        private const string FieldDialogTitle = "_dialogTitle";
        private const string Fieldc_id = "_id";
        private const string Fieldc_name = "_name";
        private const string Fieldc_desc = "_desc";

        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        
        private BasicDialogProperties _basicDialogPropertiesInstance;
        private BasicDialogProperties _basicDialogPropertiesInstanceFixture;

        /// <summary>
        ///    Setting up everything for <see cref="grouppermissionform" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _basicDialogPropertiesInstanceFixture = Create(true);
            _basicDialogPropertiesInstance = Create(false);
        }

        /// <summary>
        ///   Class (<see cref="grouppermissionform" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyId)]
        [TestCase(PropertyName)]
        [TestCase(PropertyDesc)]
        [TestCase(PropertyDialogTitle)]
        public void AUT_BasicDialogProperties_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_basicDialogPropertiesInstanceFixture, Fixture, propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(int), PropertyId)]
        [TestCaseGeneric(typeof(string), PropertyName)]
        [TestCaseGeneric(typeof(string), PropertyDesc)]
        [TestCaseGeneric(typeof(string), PropertyDialogTitle)]
        public void AUT_BasicDialogProperties_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<BasicDialogProperties, T>(
                _basicDialogPropertiesInstance,
                propertyName,
                Fixture);
        }

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_BasicDialogProperties_Public_Class_Desc_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(PropertyDesc);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_BasicDialogProperties_Public_Class_DialogTitle_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(PropertyDialogTitle);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_BasicDialogProperties_Public_Class_id_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(PropertyId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_BasicDialogProperties_Public_Class_Name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(PropertyName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        /// <summary>
        ///   Class (<see cref="grouppermissionform" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldDialogTitle)]
        [TestCase(Fieldc_id)]
        [TestCase(Fieldc_name)]
        [TestCase(Fieldc_desc)]
        public void AUT_Grouppermissionform_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(
                _basicDialogPropertiesInstanceFixture,
                Fixture,
                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }
    }
}
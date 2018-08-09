using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps.AddFiles" />)
    ///     and namespace <see cref="EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class AddFilesTest : AbstractBaseSetupTypedTest<AddFiles>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (AddFiles) Initializer

        private const string PropertyDescription = "Description";
        private const string MethodPerform = "Perform";
        private const string MethodAddFile = "AddFile";
        private const string Fieldstoreurl = "storeurl";
        private Type _addFilesInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private AddFiles _addFilesInstance;
        private AddFiles _addFilesInstanceFixture;

        #region General Initializer : Class (AddFiles) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="AddFiles" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _addFilesInstanceType = typeof(AddFiles);
            _addFilesInstanceFixture = Create(true);
            _addFilesInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (AddFiles)

        #region General Initializer : Class (AddFiles) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="AddFiles" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPerform, 0)]
        [TestCase(MethodAddFile, 0)]
        public void AUT_AddFiles_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_addFilesInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (AddFiles) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="AddFiles" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyDescription)]
        public void AUT_AddFiles_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_addFilesInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (AddFiles) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="AddFiles" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldstoreurl)]
        public void AUT_AddFiles_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_addFilesInstanceFixture, 
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
        ///      Class (<see cref="AddFiles" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPerform)]
        [TestCase(MethodAddFile)]
        public void AUT_AddFiles_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<AddFiles>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Perform) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AddFiles_Perform_Method_Call_Internally(Type[] types)
        {
            var methodPerformPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addFilesInstance, MethodPerform, Fixture, methodPerformPrametersTypes);
        }

        #endregion

        #region Method Call : (AddFile) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AddFiles_AddFile_Method_Call_Internally(Type[] types)
        {
            var methodAddFilePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addFilesInstance, MethodAddFile, Fixture, methodAddFilePrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}
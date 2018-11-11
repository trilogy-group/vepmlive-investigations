using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.CascadingMultiLookupRenderControl" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class CascadingMultiLookupRenderControlTest : AbstractBaseSetupTypedTest<CascadingMultiLookupRenderControl>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CascadingMultiLookupRenderControl) Initializer

        private const string PropertyLookupData = "LookupData";
        private const string PropertyLookupField = "LookupField";
        private const string PropertyCustomProperty = "CustomProperty";
        private const string MethodOnInit = "OnInit";
        private const string MethodOnPreRender = "OnPreRender";
        private const string FieldpropBag = "propBag";
        private Type _cascadingMultiLookupRenderControlInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CascadingMultiLookupRenderControl _cascadingMultiLookupRenderControlInstance;
        private CascadingMultiLookupRenderControl _cascadingMultiLookupRenderControlInstanceFixture;

        #region General Initializer : Class (CascadingMultiLookupRenderControl) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CascadingMultiLookupRenderControl" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _cascadingMultiLookupRenderControlInstanceType = typeof(CascadingMultiLookupRenderControl);
            _cascadingMultiLookupRenderControlInstanceFixture = Create(true);
            _cascadingMultiLookupRenderControlInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CascadingMultiLookupRenderControl)

        #region General Initializer : Class (CascadingMultiLookupRenderControl) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="CascadingMultiLookupRenderControl" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodOnInit, 0)]
        [TestCase(MethodOnPreRender, 0)]
        public void AUT_CascadingMultiLookupRenderControl_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_cascadingMultiLookupRenderControlInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CascadingMultiLookupRenderControl) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CascadingMultiLookupRenderControl" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyLookupData)]
        [TestCase(PropertyLookupField)]
        [TestCase(PropertyCustomProperty)]
        public void AUT_CascadingMultiLookupRenderControl_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_cascadingMultiLookupRenderControlInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CascadingMultiLookupRenderControl) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CascadingMultiLookupRenderControl" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldpropBag)]
        public void AUT_CascadingMultiLookupRenderControl_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_cascadingMultiLookupRenderControlInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CascadingMultiLookupRenderControl) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(LookupConfigData) , PropertyLookupData)]
        [TestCaseGeneric(typeof(SPFieldLookup) , PropertyLookupField)]
        [TestCaseGeneric(typeof(string) , PropertyCustomProperty)]
        public void AUT_CascadingMultiLookupRenderControl_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CascadingMultiLookupRenderControl, T>(_cascadingMultiLookupRenderControlInstance, propertyName, Fixture);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="CascadingMultiLookupRenderControl" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodOnInit)]
        [TestCase(MethodOnPreRender)]
        public void AUT_CascadingMultiLookupRenderControl_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<CascadingMultiLookupRenderControl>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingMultiLookupRenderControl_OnInit_Method_Call_Internally(Type[] types)
        {
            var methodOnInitPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingMultiLookupRenderControlInstance, MethodOnInit, Fixture, methodOnInitPrametersTypes);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingMultiLookupRenderControl_OnPreRender_Method_Call_Internally(Type[] types)
        {
            var methodOnPreRenderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingMultiLookupRenderControlInstance, MethodOnPreRender, Fixture, methodOnPreRenderPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}
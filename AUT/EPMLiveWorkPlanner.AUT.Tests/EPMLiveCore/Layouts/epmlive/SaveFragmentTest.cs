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
using System.Web;
using System.Xml;
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.BaseSetup.Version.V2;
using AUT.ConfigureTestProjects.BaseSetup.Version.V3;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.Model;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore.Layouts.epmlive;
using SaveFragment = EPMLiveCore.Layouts.epmlive;

namespace EPMLiveCore.Layouts.epmlive
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Layouts.epmlive.SaveFragment" />)
    ///     and namespace <see cref="EPMLiveCore.Layouts.epmlive"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class SaveFragmentTest : AbstractBaseSetupV3Test
    {
        public SaveFragmentTest() : base(typeof(SaveFragment))
        {}

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Overrides of IAbstractBaseSetupV2Test

        /// <summary>
        ///    Configure and ignore problematic tests.
        ///    Added tests will be ignored.
        /// </summary>
        public override void ConfigureIgnoringTests()
        {
            base.ConfigureIgnoringTests();
        }

        #endregion

        #region General Initializer : Class (SaveFragment) Initializer

        #region Methods

        private const string MethodSavePlannerFragments = "SavePlannerFragments";
        private const string MethodPage_Load = "Page_Load";
        private const string MethodbtnSave_Click = "btnSave_Click";

        #endregion

        private Type _saveFragmentInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private SaveFragment _saveFragmentInstance;
        private SaveFragment _saveFragmentInstanceFixture;

        #region General Initializer : Class (SaveFragment) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SaveFragment" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _saveFragmentInstanceType = typeof(SaveFragment);
            _saveFragmentInstanceFixture = this.Create<SaveFragment>(true);
            _saveFragmentInstance = _saveFragmentInstanceFixture ?? this.Create<SaveFragment>(false);
            CurrentInstance = _saveFragmentInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SaveFragment)

        #region General Initializer : Class (SaveFragment) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="SaveFragment" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodSavePlannerFragments, 0)]
        [TestCase(MethodPage_Load, 0)]
        public void AUT_SaveFragment_All_Methods_Explore_Verify_Test(string name, int overloadingIndex = 0)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var currentMethodInfo = this.GetMethodInfo(name, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_saveFragmentInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="SaveFragment" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_SaveFragment_Is_Instance_Present_Test()
        {
            // Assert
            _saveFragmentInstanceType.ShouldNotBeNull();
            _saveFragmentInstance.ShouldNotBeNull();
            _saveFragmentInstanceFixture.ShouldNotBeNull();
            _saveFragmentInstance.ShouldBeAssignableTo<SaveFragment>();
            _saveFragmentInstanceFixture.ShouldBeAssignableTo<SaveFragment>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (SaveFragment) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_SaveFragment_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            SaveFragment instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _saveFragmentInstanceType.ShouldNotBeNull();
            _saveFragmentInstance.ShouldNotBeNull();
            _saveFragmentInstanceFixture.ShouldNotBeNull();
            _saveFragmentInstance.ShouldBeAssignableTo<SaveFragment>();
            _saveFragmentInstanceFixture.ShouldBeAssignableTo<SaveFragment>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : (SavePlannerFragments) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SaveFragment_SavePlannerFragments_Method_Call_Internally(Type[] types)
        {
            var methodSavePlannerFragmentsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_saveFragmentInstance, MethodSavePlannerFragments, Fixture, methodSavePlannerFragmentsPrametersTypes);
        }

        #endregion

        #region Method Call : (SavePlannerFragments) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SaveFragment_SavePlannerFragments_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodSavePlannerFragments);
            var plannerFragmentList = this.CreateType<SPList>();
            var methodSavePlannerFragmentsPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfSavePlannerFragments = { plannerFragmentList };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodSavePlannerFragments, methodSavePlannerFragmentsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_saveFragmentInstanceFixture, parametersOfSavePlannerFragments);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSavePlannerFragments.ShouldNotBeNull();
            parametersOfSavePlannerFragments.Length.ShouldBe(1);
            methodSavePlannerFragmentsPrametersTypes.Length.ShouldBe(1);
            methodSavePlannerFragmentsPrametersTypes.Length.ShouldBe(parametersOfSavePlannerFragments.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SavePlannerFragments) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SaveFragment_SavePlannerFragments_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodSavePlannerFragments);
            var plannerFragmentList = this.CreateType<SPList>();
            var methodSavePlannerFragmentsPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfSavePlannerFragments = { plannerFragmentList };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_saveFragmentInstance, MethodSavePlannerFragments, parametersOfSavePlannerFragments, methodSavePlannerFragmentsPrametersTypes);

            // Assert
            parametersOfSavePlannerFragments.ShouldNotBeNull();
            parametersOfSavePlannerFragments.Length.ShouldBe(1);
            methodSavePlannerFragmentsPrametersTypes.Length.ShouldBe(1);
            methodSavePlannerFragmentsPrametersTypes.Length.ShouldBe(parametersOfSavePlannerFragments.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SavePlannerFragments) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SaveFragment_SavePlannerFragments_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodSavePlannerFragments);
            var methodInfo = this.GetMethodInfo(MethodSavePlannerFragments, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SavePlannerFragments) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SaveFragment_SavePlannerFragments_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodSavePlannerFragments);
            var methodSavePlannerFragmentsPrametersTypes = new Type[] { typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_saveFragmentInstance, MethodSavePlannerFragments, Fixture, methodSavePlannerFragmentsPrametersTypes);

            // Assert
            methodSavePlannerFragmentsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SavePlannerFragments) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SaveFragment_SavePlannerFragments_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodSavePlannerFragments);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodSavePlannerFragments, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_saveFragmentInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SaveFragment_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_saveFragmentInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SaveFragment_Page_Load_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPage_Load);
            var sender = this.CreateType<object>();
            var e = this.CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_saveFragmentInstanceFixture, parametersOfPage_Load);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPage_Load.ShouldNotBeNull();
            parametersOfPage_Load.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(parametersOfPage_Load.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SaveFragment_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPage_Load);
            var sender = this.CreateType<object>();
            var e = this.CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_saveFragmentInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

            // Assert
            parametersOfPage_Load.ShouldNotBeNull();
            parametersOfPage_Load.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(parametersOfPage_Load.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SaveFragment_Page_Load_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPage_Load);
            var methodInfo = this.GetMethodInfo(MethodPage_Load, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SaveFragment_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPage_Load);
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_saveFragmentInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SaveFragment_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPage_Load);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_saveFragmentInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnSave_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SaveFragment_btnSave_Click_Method_Call_Internally(Type[] types)
        {
            var methodbtnSave_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_saveFragmentInstance, MethodbtnSave_Click, Fixture, methodbtnSave_ClickPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}
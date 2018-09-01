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
using Microsoft.SharePoint.WebControls;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using WEPickerDialog = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.WEPickerDialog" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class WEPickerDialogTest : AbstractBaseSetupTypedTest<WEPickerDialog>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WEPickerDialog) Initializer

        private const string MethodgetColumns = "getColumns";
        private Type _wEPickerDialogInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private WEPickerDialog _wEPickerDialogInstance;
        private WEPickerDialog _wEPickerDialogInstanceFixture;

        #region General Initializer : Class (WEPickerDialog) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WEPickerDialog" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _wEPickerDialogInstanceType = typeof(WEPickerDialog);
            _wEPickerDialogInstanceFixture = Create(true);
            _wEPickerDialogInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WEPickerDialog)

        #region General Initializer : Class (WEPickerDialog) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="WEPickerDialog" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodgetColumns, 0)]
        public void AUT_WEPickerDialog_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_wEPickerDialogInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="WEPickerDialog" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodgetColumns)]
        public void AUT_WEPickerDialog_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<WEPickerDialog>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (getColumns) (Return Type : Dictionary<string, string>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WEPickerDialog_getColumns_Method_Call_Internally(Type[] types)
        {
            var methodgetColumnsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wEPickerDialogInstance, MethodgetColumns, Fixture, methodgetColumnsPrametersTypes);
        }

        #endregion

        #region Method Call : (getColumns) (Return Type : Dictionary<string, string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEPickerDialog_getColumns_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodgetColumnsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfgetColumns = { web };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodgetColumns, methodgetColumnsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<WEPickerDialog, Dictionary<string, string>>(_wEPickerDialogInstanceFixture, out exception1, parametersOfgetColumns);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<WEPickerDialog, Dictionary<string, string>>(_wEPickerDialogInstance, MethodgetColumns, parametersOfgetColumns, methodgetColumnsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetColumns.ShouldNotBeNull();
            parametersOfgetColumns.Length.ShouldBe(1);
            methodgetColumnsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getColumns) (Return Type : Dictionary<string, string>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEPickerDialog_getColumns_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodgetColumnsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfgetColumns = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<WEPickerDialog, Dictionary<string, string>>(_wEPickerDialogInstance, MethodgetColumns, parametersOfgetColumns, methodgetColumnsPrametersTypes);

            // Assert
            parametersOfgetColumns.ShouldNotBeNull();
            parametersOfgetColumns.Length.ShouldBe(1);
            methodgetColumnsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getColumns) (Return Type : Dictionary<string, string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEPickerDialog_getColumns_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetColumnsPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wEPickerDialogInstance, MethodgetColumns, Fixture, methodgetColumnsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetColumnsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getColumns) (Return Type : Dictionary<string, string>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEPickerDialog_getColumns_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetColumnsPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wEPickerDialogInstance, MethodgetColumns, Fixture, methodgetColumnsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetColumnsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getColumns) (Return Type : Dictionary<string, string>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEPickerDialog_getColumns_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetColumns, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_wEPickerDialogInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getColumns) (Return Type : Dictionary<string, string>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEPickerDialog_getColumns_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetColumns, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #endregion

        #endregion
    }
}
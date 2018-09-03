using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
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
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using removesolutions = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.removesolutions" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class RemovesolutionsTest : AbstractBaseSetupTypedTest<removesolutions>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (removesolutions) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodRemove = "Remove";
        private const string Fieldoutput = "output";
        private Type _removesolutionsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private removesolutions _removesolutionsInstance;
        private removesolutions _removesolutionsInstanceFixture;

        #region General Initializer : Class (removesolutions) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="removesolutions" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _removesolutionsInstanceType = typeof(removesolutions);
            _removesolutionsInstanceFixture = Create(true);
            _removesolutionsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (removesolutions)

        #region General Initializer : Class (removesolutions) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="removesolutions" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodRemove, 0)]
        public void AUT_Removesolutions_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_removesolutionsInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (removesolutions) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="removesolutions" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldoutput)]
        public void AUT_Removesolutions_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_removesolutionsInstanceFixture, 
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
        ///     Class (<see cref="removesolutions" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Removesolutions_Is_Instance_Present_Test()
        {
            // Assert
            _removesolutionsInstanceType.ShouldNotBeNull();
            _removesolutionsInstance.ShouldNotBeNull();
            _removesolutionsInstanceFixture.ShouldNotBeNull();
            _removesolutionsInstance.ShouldBeAssignableTo<removesolutions>();
            _removesolutionsInstanceFixture.ShouldBeAssignableTo<removesolutions>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (removesolutions) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_removesolutions_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            removesolutions instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _removesolutionsInstanceType.ShouldNotBeNull();
            _removesolutionsInstance.ShouldNotBeNull();
            _removesolutionsInstanceFixture.ShouldNotBeNull();
            _removesolutionsInstance.ShouldBeAssignableTo<removesolutions>();
            _removesolutionsInstanceFixture.ShouldBeAssignableTo<removesolutions>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="removesolutions" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodRemove)]
        public void AUT_Removesolutions_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<removesolutions>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Removesolutions_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_removesolutionsInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Removesolutions_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_removesolutionsInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Removesolutions_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_removesolutionsInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Removesolutions_Page_Load_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);
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
        public void AUT_Removesolutions_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_removesolutionsInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Removesolutions_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_removesolutionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Remove) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Removesolutions_Remove_Method_Call_Internally(Type[] types)
        {
            var methodRemovePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_removesolutionsInstance, MethodRemove, Fixture, methodRemovePrametersTypes);
        }

        #endregion

        #region Method Call : (Remove) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Removesolutions_Remove_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Solution = CreateType<Guid>();
            var farm = CreateType<SPFarm>();
            var apps = CreateType<System.Collections.ObjectModel.Collection<SPWebApplication>>();
            var methodRemovePrametersTypes = new Type[] { typeof(Guid), typeof(SPFarm), typeof(System.Collections.ObjectModel.Collection<SPWebApplication>) };
            object[] parametersOfRemove = { Solution, farm, apps };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRemove, methodRemovePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<removesolutions, bool>(_removesolutionsInstanceFixture, out exception1, parametersOfRemove);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<removesolutions, bool>(_removesolutionsInstance, MethodRemove, parametersOfRemove, methodRemovePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfRemove.ShouldNotBeNull();
            parametersOfRemove.Length.ShouldBe(3);
            methodRemovePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (Remove) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Removesolutions_Remove_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var Solution = CreateType<Guid>();
            var farm = CreateType<SPFarm>();
            var apps = CreateType<System.Collections.ObjectModel.Collection<SPWebApplication>>();
            var methodRemovePrametersTypes = new Type[] { typeof(Guid), typeof(SPFarm), typeof(System.Collections.ObjectModel.Collection<SPWebApplication>) };
            object[] parametersOfRemove = { Solution, farm, apps };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRemove, methodRemovePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<removesolutions, bool>(_removesolutionsInstanceFixture, out exception1, parametersOfRemove);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<removesolutions, bool>(_removesolutionsInstance, MethodRemove, parametersOfRemove, methodRemovePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfRemove.ShouldNotBeNull();
            parametersOfRemove.Length.ShouldBe(3);
            methodRemovePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (Remove) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Removesolutions_Remove_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Solution = CreateType<Guid>();
            var farm = CreateType<SPFarm>();
            var apps = CreateType<System.Collections.ObjectModel.Collection<SPWebApplication>>();
            var methodRemovePrametersTypes = new Type[] { typeof(Guid), typeof(SPFarm), typeof(System.Collections.ObjectModel.Collection<SPWebApplication>) };
            object[] parametersOfRemove = { Solution, farm, apps };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<removesolutions, bool>(_removesolutionsInstance, MethodRemove, parametersOfRemove, methodRemovePrametersTypes);

            // Assert
            parametersOfRemove.ShouldNotBeNull();
            parametersOfRemove.Length.ShouldBe(3);
            methodRemovePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Remove) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Removesolutions_Remove_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRemovePrametersTypes = new Type[] { typeof(Guid), typeof(SPFarm), typeof(System.Collections.ObjectModel.Collection<SPWebApplication>) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_removesolutionsInstance, MethodRemove, Fixture, methodRemovePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRemovePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Remove) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Removesolutions_Remove_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRemove, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_removesolutionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Remove) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Removesolutions_Remove_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRemove, 0);
            const int parametersCount = 3;

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
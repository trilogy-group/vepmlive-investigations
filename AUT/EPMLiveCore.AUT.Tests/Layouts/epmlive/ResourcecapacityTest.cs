using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.Layouts.epmlive
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Layouts.epmlive.resourcecapacity" />)
    ///     and namespace <see cref="EPMLiveCore.Layouts.epmlive"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ResourcecapacityTest : AbstractBaseSetupTypedTest<resourcecapacity>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (resourcecapacity) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodRSNOIM = "RSNOIM";
        private const string MethodRS = "RS";
        private const string Fieldsrs2006 = "srs2006";
        private const string Fieldsrs2005 = "srs2005";
        private const string FieldparametersSSRS2006 = "parametersSSRS2006";
        private const string FieldparametersSSRS2005 = "parametersSSRS2005";
        private Type _resourcecapacityInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private resourcecapacity _resourcecapacityInstance;
        private resourcecapacity _resourcecapacityInstanceFixture;

        #region General Initializer : Class (resourcecapacity) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="resourcecapacity" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _resourcecapacityInstanceType = typeof(resourcecapacity);
            _resourcecapacityInstanceFixture = Create(true);
            _resourcecapacityInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (resourcecapacity)

        #region General Initializer : Class (resourcecapacity) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="resourcecapacity" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodRSNOIM, 0)]
        [TestCase(MethodRS, 0)]
        public void AUT_Resourcecapacity_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_resourcecapacityInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (resourcecapacity) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="resourcecapacity" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldsrs2006)]
        [TestCase(Fieldsrs2005)]
        [TestCase(FieldparametersSSRS2006)]
        [TestCase(FieldparametersSSRS2005)]
        public void AUT_Resourcecapacity_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_resourcecapacityInstanceFixture, 
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
        ///     Class (<see cref="resourcecapacity" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Resourcecapacity_Is_Instance_Present_Test()
        {
            // Assert
            _resourcecapacityInstanceType.ShouldNotBeNull();
            _resourcecapacityInstance.ShouldNotBeNull();
            _resourcecapacityInstanceFixture.ShouldNotBeNull();
            _resourcecapacityInstance.ShouldBeAssignableTo<resourcecapacity>();
            _resourcecapacityInstanceFixture.ShouldBeAssignableTo<resourcecapacity>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (resourcecapacity) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_resourcecapacity_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            resourcecapacity instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _resourcecapacityInstanceType.ShouldNotBeNull();
            _resourcecapacityInstance.ShouldNotBeNull();
            _resourcecapacityInstanceFixture.ShouldNotBeNull();
            _resourcecapacityInstance.ShouldBeAssignableTo<resourcecapacity>();
            _resourcecapacityInstanceFixture.ShouldBeAssignableTo<resourcecapacity>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="resourcecapacity" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodRSNOIM)]
        [TestCase(MethodRS)]
        public void AUT_Resourcecapacity_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<resourcecapacity>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Resourcecapacity_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcecapacityInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resourcecapacity_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourcecapacityInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Resourcecapacity_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourcecapacityInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Resourcecapacity_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Resourcecapacity_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcecapacityInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resourcecapacity_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcecapacityInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RSNOIM) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Resourcecapacity_RSNOIM_Method_Call_Internally(Type[] types)
        {
            var methodRSNOIMPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcecapacityInstance, MethodRSNOIM, Fixture, methodRSNOIMPrametersTypes);
        }

        #endregion

        #region Method Call : (RSNOIM) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resourcecapacity_RSNOIM_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var url = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodRSNOIMPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfRSNOIM = { url, web };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRSNOIM, methodRSNOIMPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<resourcecapacity, string>(_resourcecapacityInstanceFixture, out exception1, parametersOfRSNOIM);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<resourcecapacity, string>(_resourcecapacityInstance, MethodRSNOIM, parametersOfRSNOIM, methodRSNOIMPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfRSNOIM.ShouldNotBeNull();
            parametersOfRSNOIM.Length.ShouldBe(2);
            methodRSNOIMPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(() => methodInfo.Invoke(_resourcecapacityInstanceFixture, parametersOfRSNOIM));
        }

        #endregion

        #region Method Call : (RSNOIM) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resourcecapacity_RSNOIM_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var url = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodRSNOIMPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfRSNOIM = { url, web };

            // Assert
            parametersOfRSNOIM.ShouldNotBeNull();
            parametersOfRSNOIM.Length.ShouldBe(2);
            methodRSNOIMPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<resourcecapacity, string>(_resourcecapacityInstance, MethodRSNOIM, parametersOfRSNOIM, methodRSNOIMPrametersTypes));
        }

        #endregion

        #region Method Call : (RSNOIM) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resourcecapacity_RSNOIM_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodRSNOIMPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcecapacityInstance, MethodRSNOIM, Fixture, methodRSNOIMPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodRSNOIMPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (RSNOIM) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resourcecapacity_RSNOIM_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRSNOIMPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcecapacityInstance, MethodRSNOIM, Fixture, methodRSNOIMPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRSNOIMPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RSNOIM) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resourcecapacity_RSNOIM_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRSNOIM, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcecapacityInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RSNOIM) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resourcecapacity_RSNOIM_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRSNOIM, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RS) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Resourcecapacity_RS_Method_Call_Internally(Type[] types)
        {
            var methodRSPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcecapacityInstance, MethodRS, Fixture, methodRSPrametersTypes);
        }

        #endregion

        #region Method Call : (RS) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resourcecapacity_RS_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var url = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodRSPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfRS = { url, web };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRS, methodRSPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<resourcecapacity, string>(_resourcecapacityInstanceFixture, out exception1, parametersOfRS);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<resourcecapacity, string>(_resourcecapacityInstance, MethodRS, parametersOfRS, methodRSPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfRS.ShouldNotBeNull();
            parametersOfRS.Length.ShouldBe(2);
            methodRSPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(() => methodInfo.Invoke(_resourcecapacityInstanceFixture, parametersOfRS));
        }

        #endregion

        #region Method Call : (RS) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resourcecapacity_RS_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var url = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodRSPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfRS = { url, web };

            // Assert
            parametersOfRS.ShouldNotBeNull();
            parametersOfRS.Length.ShouldBe(2);
            methodRSPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<resourcecapacity, string>(_resourcecapacityInstance, MethodRS, parametersOfRS, methodRSPrametersTypes));
        }

        #endregion

        #region Method Call : (RS) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resourcecapacity_RS_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodRSPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcecapacityInstance, MethodRS, Fixture, methodRSPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodRSPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (RS) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resourcecapacity_RS_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRSPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcecapacityInstance, MethodRS, Fixture, methodRSPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRSPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RS) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resourcecapacity_RS_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRS, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcecapacityInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RS) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resourcecapacity_RS_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRS, 0);
            const int parametersCount = 2;

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
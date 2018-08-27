using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.settings" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class SettingsTest : AbstractBaseSetupTypedTest<settings>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (settings) Initializer

        private const string MethodgetCategoryName = "getCategoryName";
        private const string MethodgetPicture = "getPicture";
        private const string MethodPage_Load = "Page_Load";
        private const string Fielddata = "data";
        private Type _settingsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private settings _settingsInstance;
        private settings _settingsInstanceFixture;

        #region General Initializer : Class (settings) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="settings" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _settingsInstanceType = typeof(settings);
            _settingsInstanceFixture = Create(true);
            _settingsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (settings)

        #region General Initializer : Class (settings) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="settings" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodgetCategoryName, 0)]
        [TestCase(MethodgetPicture, 0)]
        [TestCase(MethodPage_Load, 0)]
        public void AUT_Settings_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_settingsInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (settings) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="settings" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fielddata)]
        public void AUT_Settings_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_settingsInstanceFixture, 
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
        ///     Class (<see cref="settings" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Settings_Is_Instance_Present_Test()
        {
            // Assert
            _settingsInstanceType.ShouldNotBeNull();
            _settingsInstance.ShouldNotBeNull();
            _settingsInstanceFixture.ShouldNotBeNull();
            _settingsInstance.ShouldBeAssignableTo<settings>();
            _settingsInstanceFixture.ShouldBeAssignableTo<settings>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (settings) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_settings_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            settings instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _settingsInstanceType.ShouldNotBeNull();
            _settingsInstance.ShouldNotBeNull();
            _settingsInstanceFixture.ShouldNotBeNull();
            _settingsInstance.ShouldBeAssignableTo<settings>();
            _settingsInstanceFixture.ShouldBeAssignableTo<settings>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="settings" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodgetCategoryName)]
        [TestCase(MethodgetPicture)]
        [TestCase(MethodPage_Load)]
        public void AUT_Settings_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<settings>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (getCategoryName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Settings_getCategoryName_Method_Call_Internally(Type[] types)
        {
            var methodgetCategoryNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_settingsInstance, MethodgetCategoryName, Fixture, methodgetCategoryNamePrametersTypes);
        }

        #endregion

        #region Method Call : (getCategoryName) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Settings_getCategoryName_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var category = CreateType<string>();
            var methodgetCategoryNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfgetCategoryName = { category };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetCategoryName, methodgetCategoryNamePrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetCategoryName.ShouldNotBeNull();
            parametersOfgetCategoryName.Length.ShouldBe(1);
            methodgetCategoryNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(_settingsInstanceFixture, parametersOfgetCategoryName));
        }

        #endregion

        #region Method Call : (getCategoryName) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Settings_getCategoryName_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var category = CreateType<string>();
            var methodgetCategoryNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfgetCategoryName = { category };

            // Assert
            parametersOfgetCategoryName.ShouldNotBeNull();
            parametersOfgetCategoryName.Length.ShouldBe(1);
            methodgetCategoryNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<settings, string>(_settingsInstance, MethodgetCategoryName, parametersOfgetCategoryName, methodgetCategoryNamePrametersTypes));
        }

        #endregion

        #region Method Call : (getCategoryName) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Settings_getCategoryName_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetCategoryNamePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_settingsInstance, MethodgetCategoryName, Fixture, methodgetCategoryNamePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetCategoryNamePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getCategoryName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Settings_getCategoryName_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetCategoryNamePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_settingsInstance, MethodgetCategoryName, Fixture, methodgetCategoryNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetCategoryNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getCategoryName) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Settings_getCategoryName_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetCategoryName, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_settingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getCategoryName) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Settings_getCategoryName_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetCategoryName, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getPicture) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Settings_getPicture_Method_Call_Internally(Type[] types)
        {
            var methodgetPicturePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_settingsInstance, MethodgetPicture, Fixture, methodgetPicturePrametersTypes);
        }

        #endregion

        #region Method Call : (getPicture) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Settings_getPicture_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var category = CreateType<string>();
            var methodgetPicturePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfgetPicture = { category };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetPicture, methodgetPicturePrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetPicture.ShouldNotBeNull();
            parametersOfgetPicture.Length.ShouldBe(1);
            methodgetPicturePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(_settingsInstanceFixture, parametersOfgetPicture));
        }

        #endregion

        #region Method Call : (getPicture) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Settings_getPicture_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var category = CreateType<string>();
            var methodgetPicturePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfgetPicture = { category };

            // Assert
            parametersOfgetPicture.ShouldNotBeNull();
            parametersOfgetPicture.Length.ShouldBe(1);
            methodgetPicturePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<settings, string>(_settingsInstance, MethodgetPicture, parametersOfgetPicture, methodgetPicturePrametersTypes));
        }

        #endregion

        #region Method Call : (getPicture) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Settings_getPicture_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetPicturePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_settingsInstance, MethodgetPicture, Fixture, methodgetPicturePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetPicturePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getPicture) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Settings_getPicture_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetPicturePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_settingsInstance, MethodgetPicture, Fixture, methodgetPicturePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetPicturePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getPicture) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Settings_getPicture_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetPicture, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_settingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getPicture) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Settings_getPicture_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetPicture, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Settings_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_settingsInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Settings_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_settingsInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Settings_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_settingsInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Settings_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Settings_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_settingsInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Settings_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_settingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
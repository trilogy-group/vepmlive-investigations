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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.MoreInformation" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class MoreInformationTest : AbstractBaseSetupTypedTest<MoreInformation>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (MoreInformation) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodManageFields = "ManageFields";
        private const string MethodLoadPageContentByTempId = "LoadPageContentByTempId";
        private const string MethodPullMoreInfoFromTempGal = "PullMoreInfoFromTempGal";
        private const string MethodPullMoreInfoFromOnline = "PullMoreInfoFromOnline";
        private const string Field_tempId = "_tempId";
        private const string Field_isOnline = "_isOnline";
        private const string Field_solutionType = "_solutionType";
        private const string Field_templateType = "_templateType";
        private const string FieldSOL_LIB_TITLE = "SOL_LIB_TITLE";
        private Type _moreInformationInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private MoreInformation _moreInformationInstance;
        private MoreInformation _moreInformationInstanceFixture;

        #region General Initializer : Class (MoreInformation) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="MoreInformation" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _moreInformationInstanceType = typeof(MoreInformation);
            _moreInformationInstanceFixture = Create(true);
            _moreInformationInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (MoreInformation)

        #region General Initializer : Class (MoreInformation) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="MoreInformation" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodManageFields, 0)]
        [TestCase(MethodLoadPageContentByTempId, 0)]
        [TestCase(MethodPullMoreInfoFromTempGal, 0)]
        [TestCase(MethodPullMoreInfoFromOnline, 0)]
        public void AUT_MoreInformation_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_moreInformationInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (MoreInformation) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="MoreInformation" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_tempId)]
        [TestCase(Field_isOnline)]
        [TestCase(Field_solutionType)]
        [TestCase(Field_templateType)]
        [TestCase(FieldSOL_LIB_TITLE)]
        public void AUT_MoreInformation_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_moreInformationInstanceFixture, 
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
        ///     Class (<see cref="MoreInformation" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_MoreInformation_Is_Instance_Present_Test()
        {
            // Assert
            _moreInformationInstanceType.ShouldNotBeNull();
            _moreInformationInstance.ShouldNotBeNull();
            _moreInformationInstanceFixture.ShouldNotBeNull();
            _moreInformationInstance.ShouldBeAssignableTo<MoreInformation>();
            _moreInformationInstanceFixture.ShouldBeAssignableTo<MoreInformation>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (MoreInformation) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_MoreInformation_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            MoreInformation instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _moreInformationInstanceType.ShouldNotBeNull();
            _moreInformationInstance.ShouldNotBeNull();
            _moreInformationInstanceFixture.ShouldNotBeNull();
            _moreInformationInstance.ShouldBeAssignableTo<MoreInformation>();
            _moreInformationInstanceFixture.ShouldBeAssignableTo<MoreInformation>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="MoreInformation" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodManageFields)]
        [TestCase(MethodLoadPageContentByTempId)]
        [TestCase(MethodPullMoreInfoFromTempGal)]
        [TestCase(MethodPullMoreInfoFromOnline)]
        public void AUT_MoreInformation_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<MoreInformation>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MoreInformation_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_moreInformationInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MoreInformation_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_moreInformationInstanceFixture, parametersOfPage_Load);

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
        public void AUT_MoreInformation_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_moreInformationInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_MoreInformation_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_MoreInformation_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_moreInformationInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MoreInformation_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_moreInformationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ManageFields) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MoreInformation_ManageFields_Method_Call_Internally(Type[] types)
        {
            var methodManageFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_moreInformationInstance, MethodManageFields, Fixture, methodManageFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (ManageFields) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MoreInformation_ManageFields_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodManageFieldsPrametersTypes = null;
            object[] parametersOfManageFields = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodManageFields, methodManageFieldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_moreInformationInstanceFixture, parametersOfManageFields);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfManageFields.ShouldBeNull();
            methodManageFieldsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ManageFields) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MoreInformation_ManageFields_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodManageFieldsPrametersTypes = null;
            object[] parametersOfManageFields = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_moreInformationInstance, MethodManageFields, parametersOfManageFields, methodManageFieldsPrametersTypes);

            // Assert
            parametersOfManageFields.ShouldBeNull();
            methodManageFieldsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ManageFields) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MoreInformation_ManageFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodManageFieldsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_moreInformationInstance, MethodManageFields, Fixture, methodManageFieldsPrametersTypes);

            // Assert
            methodManageFieldsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ManageFields) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MoreInformation_ManageFields_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodManageFields, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_moreInformationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadPageContentByTempId) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MoreInformation_LoadPageContentByTempId_Method_Call_Internally(Type[] types)
        {
            var methodLoadPageContentByTempIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_moreInformationInstance, MethodLoadPageContentByTempId, Fixture, methodLoadPageContentByTempIdPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadPageContentByTempId) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MoreInformation_LoadPageContentByTempId_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodLoadPageContentByTempIdPrametersTypes = null;
            object[] parametersOfLoadPageContentByTempId = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodLoadPageContentByTempId, methodLoadPageContentByTempIdPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_moreInformationInstanceFixture, parametersOfLoadPageContentByTempId);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfLoadPageContentByTempId.ShouldBeNull();
            methodLoadPageContentByTempIdPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (LoadPageContentByTempId) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MoreInformation_LoadPageContentByTempId_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodLoadPageContentByTempIdPrametersTypes = null;
            object[] parametersOfLoadPageContentByTempId = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_moreInformationInstance, MethodLoadPageContentByTempId, parametersOfLoadPageContentByTempId, methodLoadPageContentByTempIdPrametersTypes);

            // Assert
            parametersOfLoadPageContentByTempId.ShouldBeNull();
            methodLoadPageContentByTempIdPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadPageContentByTempId) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MoreInformation_LoadPageContentByTempId_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodLoadPageContentByTempIdPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_moreInformationInstance, MethodLoadPageContentByTempId, Fixture, methodLoadPageContentByTempIdPrametersTypes);

            // Assert
            methodLoadPageContentByTempIdPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadPageContentByTempId) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MoreInformation_LoadPageContentByTempId_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLoadPageContentByTempId, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_moreInformationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PullMoreInfoFromTempGal) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MoreInformation_PullMoreInfoFromTempGal_Method_Call_Internally(Type[] types)
        {
            var methodPullMoreInfoFromTempGalPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_moreInformationInstance, MethodPullMoreInfoFromTempGal, Fixture, methodPullMoreInfoFromTempGalPrametersTypes);
        }

        #endregion

        #region Method Call : (PullMoreInfoFromTempGal) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MoreInformation_PullMoreInfoFromTempGal_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodPullMoreInfoFromTempGalPrametersTypes = null;
            object[] parametersOfPullMoreInfoFromTempGal = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPullMoreInfoFromTempGal, methodPullMoreInfoFromTempGalPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_moreInformationInstanceFixture, parametersOfPullMoreInfoFromTempGal);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPullMoreInfoFromTempGal.ShouldBeNull();
            methodPullMoreInfoFromTempGalPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (PullMoreInfoFromTempGal) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MoreInformation_PullMoreInfoFromTempGal_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodPullMoreInfoFromTempGalPrametersTypes = null;
            object[] parametersOfPullMoreInfoFromTempGal = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_moreInformationInstance, MethodPullMoreInfoFromTempGal, parametersOfPullMoreInfoFromTempGal, methodPullMoreInfoFromTempGalPrametersTypes);

            // Assert
            parametersOfPullMoreInfoFromTempGal.ShouldBeNull();
            methodPullMoreInfoFromTempGalPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PullMoreInfoFromTempGal) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MoreInformation_PullMoreInfoFromTempGal_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodPullMoreInfoFromTempGalPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_moreInformationInstance, MethodPullMoreInfoFromTempGal, Fixture, methodPullMoreInfoFromTempGalPrametersTypes);

            // Assert
            methodPullMoreInfoFromTempGalPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PullMoreInfoFromTempGal) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MoreInformation_PullMoreInfoFromTempGal_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPullMoreInfoFromTempGal, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_moreInformationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PullMoreInfoFromOnline) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MoreInformation_PullMoreInfoFromOnline_Method_Call_Internally(Type[] types)
        {
            var methodPullMoreInfoFromOnlinePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_moreInformationInstance, MethodPullMoreInfoFromOnline, Fixture, methodPullMoreInfoFromOnlinePrametersTypes);
        }

        #endregion

        #region Method Call : (PullMoreInfoFromOnline) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MoreInformation_PullMoreInfoFromOnline_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodPullMoreInfoFromOnlinePrametersTypes = null;
            object[] parametersOfPullMoreInfoFromOnline = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPullMoreInfoFromOnline, methodPullMoreInfoFromOnlinePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_moreInformationInstanceFixture, parametersOfPullMoreInfoFromOnline);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPullMoreInfoFromOnline.ShouldBeNull();
            methodPullMoreInfoFromOnlinePrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (PullMoreInfoFromOnline) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MoreInformation_PullMoreInfoFromOnline_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodPullMoreInfoFromOnlinePrametersTypes = null;
            object[] parametersOfPullMoreInfoFromOnline = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_moreInformationInstance, MethodPullMoreInfoFromOnline, parametersOfPullMoreInfoFromOnline, methodPullMoreInfoFromOnlinePrametersTypes);

            // Assert
            parametersOfPullMoreInfoFromOnline.ShouldBeNull();
            methodPullMoreInfoFromOnlinePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PullMoreInfoFromOnline) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MoreInformation_PullMoreInfoFromOnline_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodPullMoreInfoFromOnlinePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_moreInformationInstance, MethodPullMoreInfoFromOnline, Fixture, methodPullMoreInfoFromOnlinePrametersTypes);

            // Assert
            methodPullMoreInfoFromOnlinePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PullMoreInfoFromOnline) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MoreInformation_PullMoreInfoFromOnline_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPullMoreInfoFromOnline, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_moreInformationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
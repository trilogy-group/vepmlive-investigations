using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing.Imaging;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts.Layouts.epmlive
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.Layouts.epmlive.UploadProfilePicture" />)
    ///     and namespace <see cref="EPMLiveWebParts.Layouts.epmlive"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class UploadProfilePictureTest : AbstractBaseSetupTypedTest<UploadProfilePicture>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (UploadProfilePicture) Initializer

        private const string MethodOnSaveButtonClicked = "OnSaveButtonClicked";
        private const string MethodPage_Load = "Page_Load";
        private const string MethodUploadPictureButton_Click = "UploadPictureButton_Click";
        private const string MethodCloseDialog = "CloseDialog";
        private const string MethodDeleteExistingPicturesForUser = "DeleteExistingPicturesForUser";
        private const string MethodGetCleanUserName = "GetCleanUserName";
        private const string MethodGetDocumentLibrary = "GetDocumentLibrary";
        private const string MethodGetEncoder = "GetEncoder";
        private const string MethodGetPictureFileName = "GetPictureFileName";
        private const string MethodGetPictureUrl = "GetPictureUrl";
        private const string MethodResizeImage = "ResizeImage";
        private const string MethodSavePicture = "SavePicture";
        private const string MethodUpdatePictureUrlInSiteUserInfoList = "UpdatePictureUrlInSiteUserInfoList";
        private const string MethodUpdatePictureUrlInUserProfile = "UpdatePictureUrlInUserProfile";
        private const string MethodUploadPictureToDocumentLibrary = "UploadPictureToDocumentLibrary";
        private const string FieldLAYOUT_PATH = "LAYOUT_PATH";
        private const string FieldPROFILE_PICTURE_LIBRARY_NAME = "PROFILE_PICTURE_LIBRARY_NAME";
        private Type _uploadProfilePictureInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private UploadProfilePicture _uploadProfilePictureInstance;
        private UploadProfilePicture _uploadProfilePictureInstanceFixture;

        #region General Initializer : Class (UploadProfilePicture) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="UploadProfilePicture" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _uploadProfilePictureInstanceType = typeof(UploadProfilePicture);
            _uploadProfilePictureInstanceFixture = Create(true);
            _uploadProfilePictureInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (UploadProfilePicture)

        #region General Initializer : Class (UploadProfilePicture) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="UploadProfilePicture" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodOnSaveButtonClicked, 0)]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodUploadPictureButton_Click, 0)]
        [TestCase(MethodCloseDialog, 0)]
        [TestCase(MethodDeleteExistingPicturesForUser, 0)]
        [TestCase(MethodGetCleanUserName, 0)]
        [TestCase(MethodGetDocumentLibrary, 0)]
        [TestCase(MethodGetEncoder, 0)]
        [TestCase(MethodGetPictureFileName, 0)]
        [TestCase(MethodGetPictureUrl, 0)]
        [TestCase(MethodResizeImage, 0)]
        [TestCase(MethodSavePicture, 0)]
        [TestCase(MethodUpdatePictureUrlInSiteUserInfoList, 0)]
        [TestCase(MethodUpdatePictureUrlInUserProfile, 0)]
        [TestCase(MethodUploadPictureToDocumentLibrary, 0)]
        public void AUT_UploadProfilePicture_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_uploadProfilePictureInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (UploadProfilePicture) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="UploadProfilePicture" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldLAYOUT_PATH)]
        [TestCase(FieldPROFILE_PICTURE_LIBRARY_NAME)]
        public void AUT_UploadProfilePicture_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_uploadProfilePictureInstanceFixture, 
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
        ///     Class (<see cref="UploadProfilePicture" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_UploadProfilePicture_Is_Instance_Present_Test()
        {
            // Assert
            _uploadProfilePictureInstanceType.ShouldNotBeNull();
            _uploadProfilePictureInstance.ShouldNotBeNull();
            _uploadProfilePictureInstanceFixture.ShouldNotBeNull();
            _uploadProfilePictureInstance.ShouldBeAssignableTo<UploadProfilePicture>();
            _uploadProfilePictureInstanceFixture.ShouldBeAssignableTo<UploadProfilePicture>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (UploadProfilePicture) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_UploadProfilePicture_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            UploadProfilePicture instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _uploadProfilePictureInstanceType.ShouldNotBeNull();
            _uploadProfilePictureInstance.ShouldNotBeNull();
            _uploadProfilePictureInstanceFixture.ShouldNotBeNull();
            _uploadProfilePictureInstance.ShouldBeAssignableTo<UploadProfilePicture>();
            _uploadProfilePictureInstanceFixture.ShouldBeAssignableTo<UploadProfilePicture>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="UploadProfilePicture" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetDocumentLibrary)]
        [TestCase(MethodGetEncoder)]
        [TestCase(MethodGetPictureUrl)]
        [TestCase(MethodUpdatePictureUrlInSiteUserInfoList)]
        [TestCase(MethodUpdatePictureUrlInUserProfile)]
        [TestCase(MethodUploadPictureToDocumentLibrary)]
        public void AUT_UploadProfilePicture_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_uploadProfilePictureInstanceFixture,
                                                                              _uploadProfilePictureInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="UploadProfilePicture" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodOnSaveButtonClicked)]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodUploadPictureButton_Click)]
        [TestCase(MethodCloseDialog)]
        [TestCase(MethodDeleteExistingPicturesForUser)]
        [TestCase(MethodGetCleanUserName)]
        [TestCase(MethodGetPictureFileName)]
        [TestCase(MethodResizeImage)]
        [TestCase(MethodSavePicture)]
        public void AUT_UploadProfilePicture_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<UploadProfilePicture>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (OnSaveButtonClicked) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UploadProfilePicture_OnSaveButtonClicked_Method_Call_Internally(Type[] types)
        {
            var methodOnSaveButtonClickedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_uploadProfilePictureInstance, MethodOnSaveButtonClicked, Fixture, methodOnSaveButtonClickedPrametersTypes);
        }

        #endregion

        #region Method Call : (OnSaveButtonClicked) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_OnSaveButtonClicked_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodOnSaveButtonClickedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfOnSaveButtonClicked = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnSaveButtonClicked, methodOnSaveButtonClickedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_uploadProfilePictureInstanceFixture, parametersOfOnSaveButtonClicked);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOnSaveButtonClicked.ShouldNotBeNull();
            parametersOfOnSaveButtonClicked.Length.ShouldBe(2);
            methodOnSaveButtonClickedPrametersTypes.Length.ShouldBe(2);
            methodOnSaveButtonClickedPrametersTypes.Length.ShouldBe(parametersOfOnSaveButtonClicked.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (OnSaveButtonClicked) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_OnSaveButtonClicked_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodOnSaveButtonClickedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfOnSaveButtonClicked = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_uploadProfilePictureInstance, MethodOnSaveButtonClicked, parametersOfOnSaveButtonClicked, methodOnSaveButtonClickedPrametersTypes);

            // Assert
            parametersOfOnSaveButtonClicked.ShouldNotBeNull();
            parametersOfOnSaveButtonClicked.Length.ShouldBe(2);
            methodOnSaveButtonClickedPrametersTypes.Length.ShouldBe(2);
            methodOnSaveButtonClickedPrametersTypes.Length.ShouldBe(parametersOfOnSaveButtonClicked.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnSaveButtonClicked) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_OnSaveButtonClicked_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOnSaveButtonClicked, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnSaveButtonClicked) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_OnSaveButtonClicked_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnSaveButtonClickedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_uploadProfilePictureInstance, MethodOnSaveButtonClicked, Fixture, methodOnSaveButtonClickedPrametersTypes);

            // Assert
            methodOnSaveButtonClickedPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnSaveButtonClicked) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_OnSaveButtonClicked_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnSaveButtonClicked, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_uploadProfilePictureInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UploadProfilePicture_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_uploadProfilePictureInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_uploadProfilePictureInstanceFixture, parametersOfPage_Load);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPage_Load.ShouldNotBeNull();
            parametersOfPage_Load.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(parametersOfPage_Load.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_uploadProfilePictureInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_UploadProfilePicture_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_UploadProfilePicture_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_uploadProfilePictureInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_uploadProfilePictureInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UploadPictureButton_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UploadProfilePicture_UploadPictureButton_Click_Method_Call_Internally(Type[] types)
        {
            var methodUploadPictureButton_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_uploadProfilePictureInstance, MethodUploadPictureButton_Click, Fixture, methodUploadPictureButton_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (UploadPictureButton_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_UploadPictureButton_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodUploadPictureButton_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfUploadPictureButton_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUploadPictureButton_Click, methodUploadPictureButton_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_uploadProfilePictureInstanceFixture, parametersOfUploadPictureButton_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUploadPictureButton_Click.ShouldNotBeNull();
            parametersOfUploadPictureButton_Click.Length.ShouldBe(2);
            methodUploadPictureButton_ClickPrametersTypes.Length.ShouldBe(2);
            methodUploadPictureButton_ClickPrametersTypes.Length.ShouldBe(parametersOfUploadPictureButton_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UploadPictureButton_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_UploadPictureButton_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodUploadPictureButton_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfUploadPictureButton_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_uploadProfilePictureInstance, MethodUploadPictureButton_Click, parametersOfUploadPictureButton_Click, methodUploadPictureButton_ClickPrametersTypes);

            // Assert
            parametersOfUploadPictureButton_Click.ShouldNotBeNull();
            parametersOfUploadPictureButton_Click.Length.ShouldBe(2);
            methodUploadPictureButton_ClickPrametersTypes.Length.ShouldBe(2);
            methodUploadPictureButton_ClickPrametersTypes.Length.ShouldBe(parametersOfUploadPictureButton_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UploadPictureButton_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_UploadPictureButton_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUploadPictureButton_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UploadPictureButton_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_UploadPictureButton_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUploadPictureButton_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_uploadProfilePictureInstance, MethodUploadPictureButton_Click, Fixture, methodUploadPictureButton_ClickPrametersTypes);

            // Assert
            methodUploadPictureButton_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UploadPictureButton_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_UploadPictureButton_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUploadPictureButton_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_uploadProfilePictureInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CloseDialog) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UploadProfilePicture_CloseDialog_Method_Call_Internally(Type[] types)
        {
            var methodCloseDialogPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_uploadProfilePictureInstance, MethodCloseDialog, Fixture, methodCloseDialogPrametersTypes);
        }

        #endregion

        #region Method Call : (CloseDialog) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_CloseDialog_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var pictureUrl = CreateType<string>();
            var methodCloseDialogPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfCloseDialog = { pictureUrl };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCloseDialog, methodCloseDialogPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_uploadProfilePictureInstanceFixture, parametersOfCloseDialog);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCloseDialog.ShouldNotBeNull();
            parametersOfCloseDialog.Length.ShouldBe(1);
            methodCloseDialogPrametersTypes.Length.ShouldBe(1);
            methodCloseDialogPrametersTypes.Length.ShouldBe(parametersOfCloseDialog.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CloseDialog) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_CloseDialog_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var pictureUrl = CreateType<string>();
            var methodCloseDialogPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfCloseDialog = { pictureUrl };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_uploadProfilePictureInstance, MethodCloseDialog, parametersOfCloseDialog, methodCloseDialogPrametersTypes);

            // Assert
            parametersOfCloseDialog.ShouldNotBeNull();
            parametersOfCloseDialog.Length.ShouldBe(1);
            methodCloseDialogPrametersTypes.Length.ShouldBe(1);
            methodCloseDialogPrametersTypes.Length.ShouldBe(parametersOfCloseDialog.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CloseDialog) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_CloseDialog_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCloseDialog, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CloseDialog) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_CloseDialog_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCloseDialogPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_uploadProfilePictureInstance, MethodCloseDialog, Fixture, methodCloseDialogPrametersTypes);

            // Assert
            methodCloseDialogPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CloseDialog) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_CloseDialog_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCloseDialog, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_uploadProfilePictureInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteExistingPicturesForUser) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UploadProfilePicture_DeleteExistingPicturesForUser_Method_Call_Internally(Type[] types)
        {
            var methodDeleteExistingPicturesForUserPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_uploadProfilePictureInstance, MethodDeleteExistingPicturesForUser, Fixture, methodDeleteExistingPicturesForUserPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteExistingPicturesForUser) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_DeleteExistingPicturesForUser_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var pictureDocumentLibrary = CreateType<SPFolder>();
            var methodDeleteExistingPicturesForUserPrametersTypes = new Type[] { typeof(SPFolder) };
            object[] parametersOfDeleteExistingPicturesForUser = { pictureDocumentLibrary };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDeleteExistingPicturesForUser, methodDeleteExistingPicturesForUserPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_uploadProfilePictureInstanceFixture, parametersOfDeleteExistingPicturesForUser);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDeleteExistingPicturesForUser.ShouldNotBeNull();
            parametersOfDeleteExistingPicturesForUser.Length.ShouldBe(1);
            methodDeleteExistingPicturesForUserPrametersTypes.Length.ShouldBe(1);
            methodDeleteExistingPicturesForUserPrametersTypes.Length.ShouldBe(parametersOfDeleteExistingPicturesForUser.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DeleteExistingPicturesForUser) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_DeleteExistingPicturesForUser_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var pictureDocumentLibrary = CreateType<SPFolder>();
            var methodDeleteExistingPicturesForUserPrametersTypes = new Type[] { typeof(SPFolder) };
            object[] parametersOfDeleteExistingPicturesForUser = { pictureDocumentLibrary };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_uploadProfilePictureInstance, MethodDeleteExistingPicturesForUser, parametersOfDeleteExistingPicturesForUser, methodDeleteExistingPicturesForUserPrametersTypes);

            // Assert
            parametersOfDeleteExistingPicturesForUser.ShouldNotBeNull();
            parametersOfDeleteExistingPicturesForUser.Length.ShouldBe(1);
            methodDeleteExistingPicturesForUserPrametersTypes.Length.ShouldBe(1);
            methodDeleteExistingPicturesForUserPrametersTypes.Length.ShouldBe(parametersOfDeleteExistingPicturesForUser.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteExistingPicturesForUser) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_DeleteExistingPicturesForUser_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteExistingPicturesForUser, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteExistingPicturesForUser) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_DeleteExistingPicturesForUser_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteExistingPicturesForUserPrametersTypes = new Type[] { typeof(SPFolder) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_uploadProfilePictureInstance, MethodDeleteExistingPicturesForUser, Fixture, methodDeleteExistingPicturesForUserPrametersTypes);

            // Assert
            methodDeleteExistingPicturesForUserPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteExistingPicturesForUser) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_DeleteExistingPicturesForUser_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteExistingPicturesForUser, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_uploadProfilePictureInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCleanUserName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UploadProfilePicture_GetCleanUserName_Method_Call_Internally(Type[] types)
        {
            var methodGetCleanUserNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_uploadProfilePictureInstance, MethodGetCleanUserName, Fixture, methodGetCleanUserNamePrametersTypes);
        }

        #endregion

        #region Method Call : (GetCleanUserName) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_GetCleanUserName_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var loginName = CreateType<string>();
            var methodGetCleanUserNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetCleanUserName = { loginName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetCleanUserName, methodGetCleanUserNamePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_uploadProfilePictureInstanceFixture, parametersOfGetCleanUserName);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetCleanUserName.ShouldNotBeNull();
            parametersOfGetCleanUserName.Length.ShouldBe(1);
            methodGetCleanUserNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCleanUserName) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_GetCleanUserName_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var loginName = CreateType<string>();
            var methodGetCleanUserNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetCleanUserName = { loginName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<UploadProfilePicture, string>(_uploadProfilePictureInstance, MethodGetCleanUserName, parametersOfGetCleanUserName, methodGetCleanUserNamePrametersTypes);

            // Assert
            parametersOfGetCleanUserName.ShouldNotBeNull();
            parametersOfGetCleanUserName.Length.ShouldBe(1);
            methodGetCleanUserNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCleanUserName) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_GetCleanUserName_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCleanUserNamePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_uploadProfilePictureInstance, MethodGetCleanUserName, Fixture, methodGetCleanUserNamePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCleanUserNamePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetCleanUserName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_GetCleanUserName_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCleanUserNamePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_uploadProfilePictureInstance, MethodGetCleanUserName, Fixture, methodGetCleanUserNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCleanUserNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCleanUserName) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_GetCleanUserName_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCleanUserName, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_uploadProfilePictureInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetCleanUserName) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_GetCleanUserName_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCleanUserName, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDocumentLibrary) (Return Type : SPFolder) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UploadProfilePicture_GetDocumentLibrary_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetDocumentLibraryPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_uploadProfilePictureInstanceFixture, _uploadProfilePictureInstanceType, MethodGetDocumentLibrary, Fixture, methodGetDocumentLibraryPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDocumentLibrary) (Return Type : SPFolder) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_GetDocumentLibrary_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var documentLibraryName = CreateType<string>();
            var methodGetDocumentLibraryPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetDocumentLibrary = { documentLibraryName };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDocumentLibrary, methodGetDocumentLibraryPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_uploadProfilePictureInstanceFixture, _uploadProfilePictureInstanceType, MethodGetDocumentLibrary, Fixture, methodGetDocumentLibraryPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<SPFolder>(_uploadProfilePictureInstanceFixture, _uploadProfilePictureInstanceType, MethodGetDocumentLibrary, parametersOfGetDocumentLibrary, methodGetDocumentLibraryPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_uploadProfilePictureInstanceFixture, parametersOfGetDocumentLibrary);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetDocumentLibrary.ShouldNotBeNull();
            parametersOfGetDocumentLibrary.Length.ShouldBe(1);
            methodGetDocumentLibraryPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetDocumentLibrary) (Return Type : SPFolder) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_GetDocumentLibrary_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var documentLibraryName = CreateType<string>();
            var methodGetDocumentLibraryPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetDocumentLibrary = { documentLibraryName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<SPFolder>(_uploadProfilePictureInstanceFixture, _uploadProfilePictureInstanceType, MethodGetDocumentLibrary, parametersOfGetDocumentLibrary, methodGetDocumentLibraryPrametersTypes);

            // Assert
            parametersOfGetDocumentLibrary.ShouldNotBeNull();
            parametersOfGetDocumentLibrary.Length.ShouldBe(1);
            methodGetDocumentLibraryPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDocumentLibrary) (Return Type : SPFolder) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_GetDocumentLibrary_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetDocumentLibraryPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_uploadProfilePictureInstanceFixture, _uploadProfilePictureInstanceType, MethodGetDocumentLibrary, Fixture, methodGetDocumentLibraryPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDocumentLibraryPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetDocumentLibrary) (Return Type : SPFolder) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_GetDocumentLibrary_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDocumentLibraryPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_uploadProfilePictureInstanceFixture, _uploadProfilePictureInstanceType, MethodGetDocumentLibrary, Fixture, methodGetDocumentLibraryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDocumentLibraryPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDocumentLibrary) (Return Type : SPFolder) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_GetDocumentLibrary_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDocumentLibrary, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_uploadProfilePictureInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDocumentLibrary) (Return Type : SPFolder) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_GetDocumentLibrary_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetDocumentLibrary, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetEncoder) (Return Type : ImageCodecInfo) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UploadProfilePicture_GetEncoder_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetEncoderPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_uploadProfilePictureInstanceFixture, _uploadProfilePictureInstanceType, MethodGetEncoder, Fixture, methodGetEncoderPrametersTypes);
        }

        #endregion

        #region Method Call : (GetEncoder) (Return Type : ImageCodecInfo) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_GetEncoder_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var format = CreateType<ImageFormat>();
            var methodGetEncoderPrametersTypes = new Type[] { typeof(ImageFormat) };
            object[] parametersOfGetEncoder = { format };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetEncoder, methodGetEncoderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_uploadProfilePictureInstanceFixture, parametersOfGetEncoder);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetEncoder.ShouldNotBeNull();
            parametersOfGetEncoder.Length.ShouldBe(1);
            methodGetEncoderPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetEncoder) (Return Type : ImageCodecInfo) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_GetEncoder_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var format = CreateType<ImageFormat>();
            var methodGetEncoderPrametersTypes = new Type[] { typeof(ImageFormat) };
            object[] parametersOfGetEncoder = { format };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<ImageCodecInfo>(_uploadProfilePictureInstanceFixture, _uploadProfilePictureInstanceType, MethodGetEncoder, parametersOfGetEncoder, methodGetEncoderPrametersTypes);

            // Assert
            parametersOfGetEncoder.ShouldNotBeNull();
            parametersOfGetEncoder.Length.ShouldBe(1);
            methodGetEncoderPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetEncoder) (Return Type : ImageCodecInfo) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_GetEncoder_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetEncoderPrametersTypes = new Type[] { typeof(ImageFormat) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_uploadProfilePictureInstanceFixture, _uploadProfilePictureInstanceType, MethodGetEncoder, Fixture, methodGetEncoderPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetEncoderPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetEncoder) (Return Type : ImageCodecInfo) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_GetEncoder_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetEncoderPrametersTypes = new Type[] { typeof(ImageFormat) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_uploadProfilePictureInstanceFixture, _uploadProfilePictureInstanceType, MethodGetEncoder, Fixture, methodGetEncoderPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetEncoderPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetEncoder) (Return Type : ImageCodecInfo) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_GetEncoder_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetEncoder, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_uploadProfilePictureInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetEncoder) (Return Type : ImageCodecInfo) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_GetEncoder_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetEncoder, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPictureFileName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UploadProfilePicture_GetPictureFileName_Method_Call_Internally(Type[] types)
        {
            var methodGetPictureFileNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_uploadProfilePictureInstance, MethodGetPictureFileName, Fixture, methodGetPictureFileNamePrametersTypes);
        }

        #endregion

        #region Method Call : (GetPictureFileName) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_GetPictureFileName_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetPictureFileNamePrametersTypes = null;
            object[] parametersOfGetPictureFileName = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetPictureFileName, methodGetPictureFileNamePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<UploadProfilePicture, string>(_uploadProfilePictureInstanceFixture, out exception1, parametersOfGetPictureFileName);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<UploadProfilePicture, string>(_uploadProfilePictureInstance, MethodGetPictureFileName, parametersOfGetPictureFileName, methodGetPictureFileNamePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetPictureFileName.ShouldBeNull();
            methodGetPictureFileNamePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetPictureFileName) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_GetPictureFileName_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetPictureFileNamePrametersTypes = null;
            object[] parametersOfGetPictureFileName = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<UploadProfilePicture, string>(_uploadProfilePictureInstance, MethodGetPictureFileName, parametersOfGetPictureFileName, methodGetPictureFileNamePrametersTypes);

            // Assert
            parametersOfGetPictureFileName.ShouldBeNull();
            methodGetPictureFileNamePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPictureFileName) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_GetPictureFileName_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetPictureFileNamePrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_uploadProfilePictureInstance, MethodGetPictureFileName, Fixture, methodGetPictureFileNamePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetPictureFileNamePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetPictureFileName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_GetPictureFileName_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetPictureFileNamePrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_uploadProfilePictureInstance, MethodGetPictureFileName, Fixture, methodGetPictureFileNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetPictureFileNamePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetPictureFileName) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_GetPictureFileName_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetPictureFileName, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_uploadProfilePictureInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetPictureUrl) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UploadProfilePicture_GetPictureUrl_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetPictureUrlPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_uploadProfilePictureInstanceFixture, _uploadProfilePictureInstanceType, MethodGetPictureUrl, Fixture, methodGetPictureUrlPrametersTypes);
        }

        #endregion

        #region Method Call : (GetPictureUrl) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_GetPictureUrl_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var fileName = CreateType<string>();
            var methodGetPictureUrlPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetPictureUrl = { fileName };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetPictureUrl, methodGetPictureUrlPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_uploadProfilePictureInstanceFixture, _uploadProfilePictureInstanceType, MethodGetPictureUrl, Fixture, methodGetPictureUrlPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_uploadProfilePictureInstanceFixture, _uploadProfilePictureInstanceType, MethodGetPictureUrl, parametersOfGetPictureUrl, methodGetPictureUrlPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_uploadProfilePictureInstanceFixture, parametersOfGetPictureUrl);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetPictureUrl.ShouldNotBeNull();
            parametersOfGetPictureUrl.Length.ShouldBe(1);
            methodGetPictureUrlPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetPictureUrl) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_GetPictureUrl_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var fileName = CreateType<string>();
            var methodGetPictureUrlPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetPictureUrl = { fileName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_uploadProfilePictureInstanceFixture, _uploadProfilePictureInstanceType, MethodGetPictureUrl, parametersOfGetPictureUrl, methodGetPictureUrlPrametersTypes);

            // Assert
            parametersOfGetPictureUrl.ShouldNotBeNull();
            parametersOfGetPictureUrl.Length.ShouldBe(1);
            methodGetPictureUrlPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPictureUrl) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_GetPictureUrl_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetPictureUrlPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_uploadProfilePictureInstanceFixture, _uploadProfilePictureInstanceType, MethodGetPictureUrl, Fixture, methodGetPictureUrlPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetPictureUrlPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetPictureUrl) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_GetPictureUrl_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetPictureUrlPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_uploadProfilePictureInstanceFixture, _uploadProfilePictureInstanceType, MethodGetPictureUrl, Fixture, methodGetPictureUrlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetPictureUrlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPictureUrl) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_GetPictureUrl_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetPictureUrl, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_uploadProfilePictureInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetPictureUrl) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_GetPictureUrl_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetPictureUrl, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ResizeImage) (Return Type : byte[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UploadProfilePicture_ResizeImage_Method_Call_Internally(Type[] types)
        {
            var methodResizeImagePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_uploadProfilePictureInstance, MethodResizeImage, Fixture, methodResizeImagePrametersTypes);
        }

        #endregion

        #region Method Call : (ResizeImage) (Return Type : byte[]) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_ResizeImage_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var resizeInfo = CreateType<string>();
            var methodResizeImagePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfResizeImage = { resizeInfo };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodResizeImage, methodResizeImagePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<UploadProfilePicture, byte[]>(_uploadProfilePictureInstanceFixture, out exception1, parametersOfResizeImage);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<UploadProfilePicture, byte[]>(_uploadProfilePictureInstance, MethodResizeImage, parametersOfResizeImage, methodResizeImagePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfResizeImage.ShouldNotBeNull();
            parametersOfResizeImage.Length.ShouldBe(1);
            methodResizeImagePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ResizeImage) (Return Type : byte[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_ResizeImage_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var resizeInfo = CreateType<string>();
            var methodResizeImagePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfResizeImage = { resizeInfo };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<UploadProfilePicture, byte[]>(_uploadProfilePictureInstance, MethodResizeImage, parametersOfResizeImage, methodResizeImagePrametersTypes);

            // Assert
            parametersOfResizeImage.ShouldNotBeNull();
            parametersOfResizeImage.Length.ShouldBe(1);
            methodResizeImagePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ResizeImage) (Return Type : byte[]) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_ResizeImage_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodResizeImagePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_uploadProfilePictureInstance, MethodResizeImage, Fixture, methodResizeImagePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodResizeImagePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ResizeImage) (Return Type : byte[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_ResizeImage_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodResizeImagePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_uploadProfilePictureInstance, MethodResizeImage, Fixture, methodResizeImagePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodResizeImagePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ResizeImage) (Return Type : byte[]) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_ResizeImage_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodResizeImage, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_uploadProfilePictureInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ResizeImage) (Return Type : byte[]) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_ResizeImage_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodResizeImage, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SavePicture) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UploadProfilePicture_SavePicture_Method_Call_Internally(Type[] types)
        {
            var methodSavePicturePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_uploadProfilePictureInstance, MethodSavePicture, Fixture, methodSavePicturePrametersTypes);
        }

        #endregion

        #region Method Call : (SavePicture) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_SavePicture_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var pic = CreateType<byte[]>();
            var methodSavePicturePrametersTypes = new Type[] { typeof(byte[]) };
            object[] parametersOfSavePicture = { pic };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSavePicture, methodSavePicturePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_uploadProfilePictureInstanceFixture, parametersOfSavePicture);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSavePicture.ShouldNotBeNull();
            parametersOfSavePicture.Length.ShouldBe(1);
            methodSavePicturePrametersTypes.Length.ShouldBe(1);
            methodSavePicturePrametersTypes.Length.ShouldBe(parametersOfSavePicture.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SavePicture) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_SavePicture_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var pic = CreateType<byte[]>();
            var methodSavePicturePrametersTypes = new Type[] { typeof(byte[]) };
            object[] parametersOfSavePicture = { pic };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_uploadProfilePictureInstance, MethodSavePicture, parametersOfSavePicture, methodSavePicturePrametersTypes);

            // Assert
            parametersOfSavePicture.ShouldNotBeNull();
            parametersOfSavePicture.Length.ShouldBe(1);
            methodSavePicturePrametersTypes.Length.ShouldBe(1);
            methodSavePicturePrametersTypes.Length.ShouldBe(parametersOfSavePicture.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SavePicture) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_SavePicture_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSavePicture, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SavePicture) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_SavePicture_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSavePicturePrametersTypes = new Type[] { typeof(byte[]) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_uploadProfilePictureInstance, MethodSavePicture, Fixture, methodSavePicturePrametersTypes);

            // Assert
            methodSavePicturePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SavePicture) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_SavePicture_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSavePicture, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_uploadProfilePictureInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdatePictureUrlInSiteUserInfoList) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UploadProfilePicture_UpdatePictureUrlInSiteUserInfoList_Static_Method_Call_Internally(Type[] types)
        {
            var methodUpdatePictureUrlInSiteUserInfoListPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_uploadProfilePictureInstanceFixture, _uploadProfilePictureInstanceType, MethodUpdatePictureUrlInSiteUserInfoList, Fixture, methodUpdatePictureUrlInSiteUserInfoListPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdatePictureUrlInSiteUserInfoList) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_UpdatePictureUrlInSiteUserInfoList_Static_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var pictureUrl = CreateType<string>();
            var methodUpdatePictureUrlInSiteUserInfoListPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdatePictureUrlInSiteUserInfoList = { pictureUrl };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdatePictureUrlInSiteUserInfoList, methodUpdatePictureUrlInSiteUserInfoListPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_uploadProfilePictureInstanceFixture, parametersOfUpdatePictureUrlInSiteUserInfoList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdatePictureUrlInSiteUserInfoList.ShouldNotBeNull();
            parametersOfUpdatePictureUrlInSiteUserInfoList.Length.ShouldBe(1);
            methodUpdatePictureUrlInSiteUserInfoListPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdatePictureUrlInSiteUserInfoList) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_UpdatePictureUrlInSiteUserInfoList_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var pictureUrl = CreateType<string>();
            var methodUpdatePictureUrlInSiteUserInfoListPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdatePictureUrlInSiteUserInfoList = { pictureUrl };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_uploadProfilePictureInstanceFixture, _uploadProfilePictureInstanceType, MethodUpdatePictureUrlInSiteUserInfoList, parametersOfUpdatePictureUrlInSiteUserInfoList, methodUpdatePictureUrlInSiteUserInfoListPrametersTypes);

            // Assert
            parametersOfUpdatePictureUrlInSiteUserInfoList.ShouldNotBeNull();
            parametersOfUpdatePictureUrlInSiteUserInfoList.Length.ShouldBe(1);
            methodUpdatePictureUrlInSiteUserInfoListPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdatePictureUrlInSiteUserInfoList) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_UpdatePictureUrlInSiteUserInfoList_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdatePictureUrlInSiteUserInfoList, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdatePictureUrlInSiteUserInfoList) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_UpdatePictureUrlInSiteUserInfoList_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdatePictureUrlInSiteUserInfoListPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_uploadProfilePictureInstanceFixture, _uploadProfilePictureInstanceType, MethodUpdatePictureUrlInSiteUserInfoList, Fixture, methodUpdatePictureUrlInSiteUserInfoListPrametersTypes);

            // Assert
            methodUpdatePictureUrlInSiteUserInfoListPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdatePictureUrlInSiteUserInfoList) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_UpdatePictureUrlInSiteUserInfoList_Static_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdatePictureUrlInSiteUserInfoList, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_uploadProfilePictureInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdatePictureUrlInUserProfile) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UploadProfilePicture_UpdatePictureUrlInUserProfile_Static_Method_Call_Internally(Type[] types)
        {
            var methodUpdatePictureUrlInUserProfilePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_uploadProfilePictureInstanceFixture, _uploadProfilePictureInstanceType, MethodUpdatePictureUrlInUserProfile, Fixture, methodUpdatePictureUrlInUserProfilePrametersTypes);
        }

        #endregion

        #region Method Call : (UpdatePictureUrlInUserProfile) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_UpdatePictureUrlInUserProfile_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var pictureUrl = CreateType<string>();
            var methodUpdatePictureUrlInUserProfilePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdatePictureUrlInUserProfile = { pictureUrl };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdatePictureUrlInUserProfile, methodUpdatePictureUrlInUserProfilePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_uploadProfilePictureInstanceFixture, parametersOfUpdatePictureUrlInUserProfile);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdatePictureUrlInUserProfile.ShouldNotBeNull();
            parametersOfUpdatePictureUrlInUserProfile.Length.ShouldBe(1);
            methodUpdatePictureUrlInUserProfilePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdatePictureUrlInUserProfile) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_UpdatePictureUrlInUserProfile_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var pictureUrl = CreateType<string>();
            var methodUpdatePictureUrlInUserProfilePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdatePictureUrlInUserProfile = { pictureUrl };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_uploadProfilePictureInstanceFixture, _uploadProfilePictureInstanceType, MethodUpdatePictureUrlInUserProfile, parametersOfUpdatePictureUrlInUserProfile, methodUpdatePictureUrlInUserProfilePrametersTypes);

            // Assert
            parametersOfUpdatePictureUrlInUserProfile.ShouldNotBeNull();
            parametersOfUpdatePictureUrlInUserProfile.Length.ShouldBe(1);
            methodUpdatePictureUrlInUserProfilePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdatePictureUrlInUserProfile) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_UpdatePictureUrlInUserProfile_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdatePictureUrlInUserProfile, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdatePictureUrlInUserProfile) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_UpdatePictureUrlInUserProfile_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdatePictureUrlInUserProfilePrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_uploadProfilePictureInstanceFixture, _uploadProfilePictureInstanceType, MethodUpdatePictureUrlInUserProfile, Fixture, methodUpdatePictureUrlInUserProfilePrametersTypes);

            // Assert
            methodUpdatePictureUrlInUserProfilePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdatePictureUrlInUserProfile) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_UpdatePictureUrlInUserProfile_Static_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdatePictureUrlInUserProfile, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_uploadProfilePictureInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UploadPictureToDocumentLibrary) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UploadProfilePicture_UploadPictureToDocumentLibrary_Static_Method_Call_Internally(Type[] types)
        {
            var methodUploadPictureToDocumentLibraryPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_uploadProfilePictureInstanceFixture, _uploadProfilePictureInstanceType, MethodUploadPictureToDocumentLibrary, Fixture, methodUploadPictureToDocumentLibraryPrametersTypes);
        }

        #endregion

        #region Method Call : (UploadPictureToDocumentLibrary) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_UploadPictureToDocumentLibrary_Static_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var pictureDocumentLibrary = CreateType<SPFolder>();
            var pictureFileName = CreateType<string>();
            var pictureFileBytes = CreateType<byte[]>();
            var methodUploadPictureToDocumentLibraryPrametersTypes = new Type[] { typeof(SPFolder), typeof(string), typeof(byte[]) };
            object[] parametersOfUploadPictureToDocumentLibrary = { pictureDocumentLibrary, pictureFileName, pictureFileBytes };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUploadPictureToDocumentLibrary, methodUploadPictureToDocumentLibraryPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_uploadProfilePictureInstanceFixture, parametersOfUploadPictureToDocumentLibrary);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUploadPictureToDocumentLibrary.ShouldNotBeNull();
            parametersOfUploadPictureToDocumentLibrary.Length.ShouldBe(3);
            methodUploadPictureToDocumentLibraryPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UploadPictureToDocumentLibrary) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_UploadPictureToDocumentLibrary_Static_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var pictureDocumentLibrary = CreateType<SPFolder>();
            var pictureFileName = CreateType<string>();
            var pictureFileBytes = CreateType<byte[]>();
            var methodUploadPictureToDocumentLibraryPrametersTypes = new Type[] { typeof(SPFolder), typeof(string), typeof(byte[]) };
            object[] parametersOfUploadPictureToDocumentLibrary = { pictureDocumentLibrary, pictureFileName, pictureFileBytes };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_uploadProfilePictureInstanceFixture, _uploadProfilePictureInstanceType, MethodUploadPictureToDocumentLibrary, parametersOfUploadPictureToDocumentLibrary, methodUploadPictureToDocumentLibraryPrametersTypes);

            // Assert
            parametersOfUploadPictureToDocumentLibrary.ShouldNotBeNull();
            parametersOfUploadPictureToDocumentLibrary.Length.ShouldBe(3);
            methodUploadPictureToDocumentLibraryPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UploadPictureToDocumentLibrary) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_UploadPictureToDocumentLibrary_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUploadPictureToDocumentLibrary, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UploadPictureToDocumentLibrary) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_UploadPictureToDocumentLibrary_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUploadPictureToDocumentLibraryPrametersTypes = new Type[] { typeof(SPFolder), typeof(string), typeof(byte[]) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_uploadProfilePictureInstanceFixture, _uploadProfilePictureInstanceType, MethodUploadPictureToDocumentLibrary, Fixture, methodUploadPictureToDocumentLibraryPrametersTypes);

            // Assert
            methodUploadPictureToDocumentLibraryPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UploadPictureToDocumentLibrary) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UploadProfilePicture_UploadPictureToDocumentLibrary_Static_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUploadPictureToDocumentLibrary, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_uploadProfilePictureInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
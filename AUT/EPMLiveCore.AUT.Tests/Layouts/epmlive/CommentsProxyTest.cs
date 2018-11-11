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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.CommentsProxy" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public partial class CommentsProxyTest : AbstractBaseSetupTypedTest<CommentsProxy>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CommentsProxy) Initializer

        private const string MethodCreateComment = "CreateComment";
        private const string MethodUpdateComment = "UpdateComment";
        private const string MethodReadComment = "ReadComment";
        private const string MethodDeleteComment = "DeleteComment";
        private const string MethodManageFields = "ManageFields";
        private const string MethodHandleAjaxCalls = "HandleAjaxCalls";
        private const string MethodPage_Load = "Page_Load";
        private const string Field_listId = "_listId";
        private const string Field_itemId = "_itemId";
        private const string Field_userId = "_userId";
        private const string Field_command = "_command";
        private const string Field_comment = "_comment";
        private const string Field_newComment = "_newComment";
        private const string Field_commentItemId = "_commentItemId";
        private const string Field_statusUpdate = "_statusUpdate";
        private const string Field_statusUpdateId = "_statusUpdateId";
        private Type _commentsProxyInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CommentsProxy _commentsProxyInstance;
        private CommentsProxy _commentsProxyInstanceFixture;

        #region General Initializer : Class (CommentsProxy) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CommentsProxy" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _commentsProxyInstanceType = typeof(CommentsProxy);
            _commentsProxyInstanceFixture = Create(true);
            _commentsProxyInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CommentsProxy)

        #region General Initializer : Class (CommentsProxy) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="CommentsProxy" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodCreateComment, 0)]
        [TestCase(MethodUpdateComment, 0)]
        [TestCase(MethodReadComment, 0)]
        [TestCase(MethodDeleteComment, 0)]
        [TestCase(MethodManageFields, 0)]
        [TestCase(MethodHandleAjaxCalls, 0)]
        [TestCase(MethodPage_Load, 0)]
        public void AUT_CommentsProxy_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_commentsProxyInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CommentsProxy) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CommentsProxy" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_listId)]
        [TestCase(Field_itemId)]
        [TestCase(Field_userId)]
        [TestCase(Field_command)]
        [TestCase(Field_comment)]
        [TestCase(Field_newComment)]
        [TestCase(Field_commentItemId)]
        [TestCase(Field_statusUpdate)]
        [TestCase(Field_statusUpdateId)]
        public void AUT_CommentsProxy_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_commentsProxyInstanceFixture, 
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
        ///     Class (<see cref="CommentsProxy" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_CommentsProxy_Is_Instance_Present_Test()
        {
            // Assert
            _commentsProxyInstanceType.ShouldNotBeNull();
            _commentsProxyInstance.ShouldNotBeNull();
            _commentsProxyInstanceFixture.ShouldNotBeNull();
            _commentsProxyInstance.ShouldBeAssignableTo<CommentsProxy>();
            _commentsProxyInstanceFixture.ShouldBeAssignableTo<CommentsProxy>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CommentsProxy) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_CommentsProxy_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CommentsProxy instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _commentsProxyInstanceType.ShouldNotBeNull();
            _commentsProxyInstance.ShouldNotBeNull();
            _commentsProxyInstanceFixture.ShouldNotBeNull();
            _commentsProxyInstance.ShouldBeAssignableTo<CommentsProxy>();
            _commentsProxyInstanceFixture.ShouldBeAssignableTo<CommentsProxy>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="CommentsProxy" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodCreateComment)]
        [TestCase(MethodUpdateComment)]
        [TestCase(MethodReadComment)]
        [TestCase(MethodDeleteComment)]
        [TestCase(MethodManageFields)]
        [TestCase(MethodHandleAjaxCalls)]
        [TestCase(MethodPage_Load)]
        public void AUT_CommentsProxy_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<CommentsProxy>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (CreateComment) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CommentsProxy_CreateComment_Method_Call_Internally(Type[] types)
        {
            var methodCreateCommentPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commentsProxyInstance, MethodCreateComment, Fixture, methodCreateCommentPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateComment) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommentsProxy_CreateComment_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodCreateCommentPrametersTypes = null;
            object[] parametersOfCreateComment = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateComment, methodCreateCommentPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_commentsProxyInstanceFixture, parametersOfCreateComment);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateComment.ShouldBeNull();
            methodCreateCommentPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CreateComment) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommentsProxy_CreateComment_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateCommentPrametersTypes = null;
            object[] parametersOfCreateComment = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_commentsProxyInstance, MethodCreateComment, parametersOfCreateComment, methodCreateCommentPrametersTypes);

            // Assert
            parametersOfCreateComment.ShouldBeNull();
            methodCreateCommentPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateComment) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommentsProxy_CreateComment_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateCommentPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commentsProxyInstance, MethodCreateComment, Fixture, methodCreateCommentPrametersTypes);

            // Assert
            methodCreateCommentPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateComment) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommentsProxy_CreateComment_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateComment, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_commentsProxyInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateComment) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CommentsProxy_UpdateComment_Method_Call_Internally(Type[] types)
        {
            var methodUpdateCommentPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commentsProxyInstance, MethodUpdateComment, Fixture, methodUpdateCommentPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateComment) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommentsProxy_UpdateComment_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodUpdateCommentPrametersTypes = null;
            object[] parametersOfUpdateComment = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateComment, methodUpdateCommentPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_commentsProxyInstanceFixture, parametersOfUpdateComment);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateComment.ShouldBeNull();
            methodUpdateCommentPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateComment) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommentsProxy_UpdateComment_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodUpdateCommentPrametersTypes = null;
            object[] parametersOfUpdateComment = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_commentsProxyInstance, MethodUpdateComment, parametersOfUpdateComment, methodUpdateCommentPrametersTypes);

            // Assert
            parametersOfUpdateComment.ShouldBeNull();
            methodUpdateCommentPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateComment) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommentsProxy_UpdateComment_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodUpdateCommentPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commentsProxyInstance, MethodUpdateComment, Fixture, methodUpdateCommentPrametersTypes);

            // Assert
            methodUpdateCommentPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateComment) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommentsProxy_UpdateComment_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateComment, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_commentsProxyInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadComment) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CommentsProxy_ReadComment_Method_Call_Internally(Type[] types)
        {
            var methodReadCommentPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commentsProxyInstance, MethodReadComment, Fixture, methodReadCommentPrametersTypes);
        }

        #endregion

        #region Method Call : (ReadComment) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommentsProxy_ReadComment_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodReadCommentPrametersTypes = null;
            object[] parametersOfReadComment = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReadComment, methodReadCommentPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_commentsProxyInstanceFixture, parametersOfReadComment);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReadComment.ShouldBeNull();
            methodReadCommentPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ReadComment) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommentsProxy_ReadComment_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodReadCommentPrametersTypes = null;
            object[] parametersOfReadComment = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_commentsProxyInstance, MethodReadComment, parametersOfReadComment, methodReadCommentPrametersTypes);

            // Assert
            parametersOfReadComment.ShouldBeNull();
            methodReadCommentPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadComment) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommentsProxy_ReadComment_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodReadCommentPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commentsProxyInstance, MethodReadComment, Fixture, methodReadCommentPrametersTypes);

            // Assert
            methodReadCommentPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadComment) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommentsProxy_ReadComment_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReadComment, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_commentsProxyInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteComment) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CommentsProxy_DeleteComment_Method_Call_Internally(Type[] types)
        {
            var methodDeleteCommentPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commentsProxyInstance, MethodDeleteComment, Fixture, methodDeleteCommentPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteComment) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommentsProxy_DeleteComment_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodDeleteCommentPrametersTypes = null;
            object[] parametersOfDeleteComment = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDeleteComment, methodDeleteCommentPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_commentsProxyInstanceFixture, parametersOfDeleteComment);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDeleteComment.ShouldBeNull();
            methodDeleteCommentPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DeleteComment) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommentsProxy_DeleteComment_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodDeleteCommentPrametersTypes = null;
            object[] parametersOfDeleteComment = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_commentsProxyInstance, MethodDeleteComment, parametersOfDeleteComment, methodDeleteCommentPrametersTypes);

            // Assert
            parametersOfDeleteComment.ShouldBeNull();
            methodDeleteCommentPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteComment) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommentsProxy_DeleteComment_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodDeleteCommentPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commentsProxyInstance, MethodDeleteComment, Fixture, methodDeleteCommentPrametersTypes);

            // Assert
            methodDeleteCommentPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteComment) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommentsProxy_DeleteComment_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteComment, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_commentsProxyInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ManageFields) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CommentsProxy_ManageFields_Method_Call_Internally(Type[] types)
        {
            var methodManageFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commentsProxyInstance, MethodManageFields, Fixture, methodManageFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (ManageFields) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommentsProxy_ManageFields_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodManageFieldsPrametersTypes = null;
            object[] parametersOfManageFields = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodManageFields, methodManageFieldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_commentsProxyInstanceFixture, parametersOfManageFields);

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
        public void AUT_CommentsProxy_ManageFields_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodManageFieldsPrametersTypes = null;
            object[] parametersOfManageFields = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_commentsProxyInstance, MethodManageFields, parametersOfManageFields, methodManageFieldsPrametersTypes);

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
        public void AUT_CommentsProxy_ManageFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodManageFieldsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commentsProxyInstance, MethodManageFields, Fixture, methodManageFieldsPrametersTypes);

            // Assert
            methodManageFieldsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ManageFields) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommentsProxy_ManageFields_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodManageFields, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_commentsProxyInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HandleAjaxCalls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CommentsProxy_HandleAjaxCalls_Method_Call_Internally(Type[] types)
        {
            var methodHandleAjaxCallsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commentsProxyInstance, MethodHandleAjaxCalls, Fixture, methodHandleAjaxCallsPrametersTypes);
        }

        #endregion

        #region Method Call : (HandleAjaxCalls) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommentsProxy_HandleAjaxCalls_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodHandleAjaxCallsPrametersTypes = null;
            object[] parametersOfHandleAjaxCalls = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodHandleAjaxCalls, methodHandleAjaxCallsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_commentsProxyInstanceFixture, parametersOfHandleAjaxCalls);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfHandleAjaxCalls.ShouldBeNull();
            methodHandleAjaxCallsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HandleAjaxCalls) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommentsProxy_HandleAjaxCalls_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodHandleAjaxCallsPrametersTypes = null;
            object[] parametersOfHandleAjaxCalls = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_commentsProxyInstance, MethodHandleAjaxCalls, parametersOfHandleAjaxCalls, methodHandleAjaxCallsPrametersTypes);

            // Assert
            parametersOfHandleAjaxCalls.ShouldBeNull();
            methodHandleAjaxCallsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HandleAjaxCalls) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommentsProxy_HandleAjaxCalls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodHandleAjaxCallsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commentsProxyInstance, MethodHandleAjaxCalls, Fixture, methodHandleAjaxCallsPrametersTypes);

            // Assert
            methodHandleAjaxCallsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HandleAjaxCalls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommentsProxy_HandleAjaxCalls_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodHandleAjaxCalls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_commentsProxyInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CommentsProxy_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commentsProxyInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommentsProxy_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_commentsProxyInstanceFixture, parametersOfPage_Load);

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
        public void AUT_CommentsProxy_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_commentsProxyInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_CommentsProxy_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_CommentsProxy_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commentsProxyInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommentsProxy_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_commentsProxyInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
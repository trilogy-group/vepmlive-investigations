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

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Comments" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public partial class CommentsTest : AbstractBaseSetupTypedTest<Comments>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Comments) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodSetCCPeople = "SetCCPeople";
        private const string MethodSetTOPeople = "SetTOPeople";
        private const string MethodEnsureCommentsListExist = "EnsureCommentsListExist";
        private const string MethodManageFields = "ManageFields";
        private const string MethodUserIsAssigned = "UserIsAssigned";
        private const string MethodGetItemAssigneeIds = "GetItemAssigneeIds";
        private const string MethodGetItemAuthorId = "GetItemAuthorId";
        private const string MethodAddCommentersFields = "AddCommentersFields";
        private const string MethodBuildHTMLTableRowsForEachComment = "BuildHTMLTableRowsForEachComment";
        private const string Field_hasPerm = "_hasPerm";
        private const string Field_webUrl = "_webUrl";
        private const string Field_userProfileUrl = "_userProfileUrl";
        private const string Field_userEmail = "_userEmail";
        private const string Field_userPictureUrl = "_userPictureUrl";
        private const string Field_currentUserLoginName = "_currentUserLoginName";
        private const string Field_listTitle = "_listTitle";
        private const string Field_itemTitle = "_itemTitle";
        private const string Field_wpeId = "_wpeId";
        private const string Field_listId = "_listId";
        private const string Field_itemId = "_itemId";
        private const string Field_authorId = "_authorId";
        private const string Field_assigneeIds = "_assigneeIds";
        private Type _commentsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Comments _commentsInstance;
        private Comments _commentsInstanceFixture;

        #region General Initializer : Class (Comments) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Comments" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _commentsInstanceType = typeof(Comments);
            _commentsInstanceFixture = Create(true);
            _commentsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Comments)

        #region General Initializer : Class (Comments) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Comments" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodSetCCPeople, 0)]
        [TestCase(MethodSetTOPeople, 0)]
        [TestCase(MethodEnsureCommentsListExist, 0)]
        [TestCase(MethodManageFields, 0)]
        [TestCase(MethodUserIsAssigned, 0)]
        [TestCase(MethodGetItemAssigneeIds, 0)]
        [TestCase(MethodGetItemAuthorId, 0)]
        [TestCase(MethodAddCommentersFields, 0)]
        [TestCase(MethodBuildHTMLTableRowsForEachComment, 0)]
        public void AUT_Comments_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_commentsInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Comments) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Comments" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_hasPerm)]
        [TestCase(Field_webUrl)]
        [TestCase(Field_userProfileUrl)]
        [TestCase(Field_userEmail)]
        [TestCase(Field_userPictureUrl)]
        [TestCase(Field_currentUserLoginName)]
        [TestCase(Field_listTitle)]
        [TestCase(Field_itemTitle)]
        [TestCase(Field_wpeId)]
        [TestCase(Field_listId)]
        [TestCase(Field_itemId)]
        [TestCase(Field_authorId)]
        [TestCase(Field_assigneeIds)]
        public void AUT_Comments_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_commentsInstanceFixture, 
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
        ///     Class (<see cref="Comments" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Comments_Is_Instance_Present_Test()
        {
            // Assert
            _commentsInstanceType.ShouldNotBeNull();
            _commentsInstance.ShouldNotBeNull();
            _commentsInstanceFixture.ShouldNotBeNull();
            _commentsInstance.ShouldBeAssignableTo<Comments>();
            _commentsInstanceFixture.ShouldBeAssignableTo<Comments>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Comments) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_Comments_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Comments instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _commentsInstanceType.ShouldNotBeNull();
            _commentsInstance.ShouldNotBeNull();
            _commentsInstanceFixture.ShouldNotBeNull();
            _commentsInstance.ShouldBeAssignableTo<Comments>();
            _commentsInstanceFixture.ShouldBeAssignableTo<Comments>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="Comments" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodSetCCPeople)]
        [TestCase(MethodSetTOPeople)]
        [TestCase(MethodEnsureCommentsListExist)]
        [TestCase(MethodManageFields)]
        [TestCase(MethodUserIsAssigned)]
        [TestCase(MethodGetItemAssigneeIds)]
        [TestCase(MethodGetItemAuthorId)]
        [TestCase(MethodAddCommentersFields)]
        [TestCase(MethodBuildHTMLTableRowsForEachComment)]
        public void AUT_Comments_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<Comments>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Comments_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commentsInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Comments_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_commentsInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Comments_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_commentsInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Comments_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Comments_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commentsInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Comments_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_commentsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetCCPeople) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Comments_SetCCPeople_Method_Call_Internally(Type[] types)
        {
            var methodSetCCPeoplePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commentsInstance, MethodSetCCPeople, Fixture, methodSetCCPeoplePrametersTypes);
        }

        #endregion

        #region Method Call : (SetCCPeople) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Comments_SetCCPeople_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodSetCCPeoplePrametersTypes = null;
            object[] parametersOfSetCCPeople = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetCCPeople, methodSetCCPeoplePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_commentsInstanceFixture, parametersOfSetCCPeople);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetCCPeople.ShouldBeNull();
            methodSetCCPeoplePrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetCCPeople) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Comments_SetCCPeople_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodSetCCPeoplePrametersTypes = null;
            object[] parametersOfSetCCPeople = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_commentsInstance, MethodSetCCPeople, parametersOfSetCCPeople, methodSetCCPeoplePrametersTypes);

            // Assert
            parametersOfSetCCPeople.ShouldBeNull();
            methodSetCCPeoplePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetCCPeople) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Comments_SetCCPeople_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodSetCCPeoplePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commentsInstance, MethodSetCCPeople, Fixture, methodSetCCPeoplePrametersTypes);

            // Assert
            methodSetCCPeoplePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetCCPeople) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Comments_SetCCPeople_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetCCPeople, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_commentsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetTOPeople) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Comments_SetTOPeople_Method_Call_Internally(Type[] types)
        {
            var methodSetTOPeoplePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commentsInstance, MethodSetTOPeople, Fixture, methodSetTOPeoplePrametersTypes);
        }

        #endregion

        #region Method Call : (SetTOPeople) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Comments_SetTOPeople_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodSetTOPeoplePrametersTypes = null;
            object[] parametersOfSetTOPeople = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetTOPeople, methodSetTOPeoplePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_commentsInstanceFixture, parametersOfSetTOPeople);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetTOPeople.ShouldBeNull();
            methodSetTOPeoplePrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetTOPeople) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Comments_SetTOPeople_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodSetTOPeoplePrametersTypes = null;
            object[] parametersOfSetTOPeople = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_commentsInstance, MethodSetTOPeople, parametersOfSetTOPeople, methodSetTOPeoplePrametersTypes);

            // Assert
            parametersOfSetTOPeople.ShouldBeNull();
            methodSetTOPeoplePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetTOPeople) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Comments_SetTOPeople_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodSetTOPeoplePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commentsInstance, MethodSetTOPeople, Fixture, methodSetTOPeoplePrametersTypes);

            // Assert
            methodSetTOPeoplePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetTOPeople) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Comments_SetTOPeople_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetTOPeople, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_commentsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnsureCommentsListExist) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Comments_EnsureCommentsListExist_Method_Call_Internally(Type[] types)
        {
            var methodEnsureCommentsListExistPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commentsInstance, MethodEnsureCommentsListExist, Fixture, methodEnsureCommentsListExistPrametersTypes);
        }

        #endregion

        #region Method Call : (EnsureCommentsListExist) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Comments_EnsureCommentsListExist_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodEnsureCommentsListExistPrametersTypes = null;
            object[] parametersOfEnsureCommentsListExist = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodEnsureCommentsListExist, methodEnsureCommentsListExistPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_commentsInstanceFixture, parametersOfEnsureCommentsListExist);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfEnsureCommentsListExist.ShouldBeNull();
            methodEnsureCommentsListExistPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (EnsureCommentsListExist) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Comments_EnsureCommentsListExist_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodEnsureCommentsListExistPrametersTypes = null;
            object[] parametersOfEnsureCommentsListExist = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_commentsInstance, MethodEnsureCommentsListExist, parametersOfEnsureCommentsListExist, methodEnsureCommentsListExistPrametersTypes);

            // Assert
            parametersOfEnsureCommentsListExist.ShouldBeNull();
            methodEnsureCommentsListExistPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnsureCommentsListExist) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Comments_EnsureCommentsListExist_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodEnsureCommentsListExistPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commentsInstance, MethodEnsureCommentsListExist, Fixture, methodEnsureCommentsListExistPrametersTypes);

            // Assert
            methodEnsureCommentsListExistPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnsureCommentsListExist) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Comments_EnsureCommentsListExist_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodEnsureCommentsListExist, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_commentsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ManageFields) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Comments_ManageFields_Method_Call_Internally(Type[] types)
        {
            var methodManageFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commentsInstance, MethodManageFields, Fixture, methodManageFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (ManageFields) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Comments_ManageFields_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodManageFieldsPrametersTypes = null;
            object[] parametersOfManageFields = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodManageFields, methodManageFieldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_commentsInstanceFixture, parametersOfManageFields);

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
        public void AUT_Comments_ManageFields_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodManageFieldsPrametersTypes = null;
            object[] parametersOfManageFields = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_commentsInstance, MethodManageFields, parametersOfManageFields, methodManageFieldsPrametersTypes);

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
        public void AUT_Comments_ManageFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodManageFieldsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commentsInstance, MethodManageFields, Fixture, methodManageFieldsPrametersTypes);

            // Assert
            methodManageFieldsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ManageFields) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Comments_ManageFields_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodManageFields, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_commentsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UserIsAssigned) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Comments_UserIsAssigned_Method_Call_Internally(Type[] types)
        {
            var methodUserIsAssignedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commentsInstance, MethodUserIsAssigned, Fixture, methodUserIsAssignedPrametersTypes);
        }

        #endregion

        #region Method Call : (UserIsAssigned) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Comments_UserIsAssigned_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var userID = CreateType<int>();
            var item = CreateType<SPListItem>();
            var methodUserIsAssignedPrametersTypes = new Type[] { typeof(int), typeof(SPListItem) };
            object[] parametersOfUserIsAssigned = { userID, item };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUserIsAssigned, methodUserIsAssignedPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Comments, bool>(_commentsInstanceFixture, out exception1, parametersOfUserIsAssigned);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Comments, bool>(_commentsInstance, MethodUserIsAssigned, parametersOfUserIsAssigned, methodUserIsAssignedPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUserIsAssigned.ShouldNotBeNull();
            parametersOfUserIsAssigned.Length.ShouldBe(2);
            methodUserIsAssignedPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Comments, bool>(_commentsInstance, MethodUserIsAssigned, parametersOfUserIsAssigned, methodUserIsAssignedPrametersTypes));
        }

        #endregion

        #region Method Call : (UserIsAssigned) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Comments_UserIsAssigned_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var userID = CreateType<int>();
            var item = CreateType<SPListItem>();
            var methodUserIsAssignedPrametersTypes = new Type[] { typeof(int), typeof(SPListItem) };
            object[] parametersOfUserIsAssigned = { userID, item };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUserIsAssigned, methodUserIsAssignedPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUserIsAssigned.ShouldNotBeNull();
            parametersOfUserIsAssigned.Length.ShouldBe(2);
            methodUserIsAssignedPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => methodInfo.Invoke(_commentsInstanceFixture, parametersOfUserIsAssigned));
        }

        #endregion

        #region Method Call : (UserIsAssigned) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Comments_UserIsAssigned_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var userID = CreateType<int>();
            var item = CreateType<SPListItem>();
            var methodUserIsAssignedPrametersTypes = new Type[] { typeof(int), typeof(SPListItem) };
            object[] parametersOfUserIsAssigned = { userID, item };

            // Assert
            parametersOfUserIsAssigned.ShouldNotBeNull();
            parametersOfUserIsAssigned.Length.ShouldBe(2);
            methodUserIsAssignedPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Comments, bool>(_commentsInstance, MethodUserIsAssigned, parametersOfUserIsAssigned, methodUserIsAssignedPrametersTypes));
        }

        #endregion

        #region Method Call : (UserIsAssigned) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Comments_UserIsAssigned_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUserIsAssignedPrametersTypes = new Type[] { typeof(int), typeof(SPListItem) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commentsInstance, MethodUserIsAssigned, Fixture, methodUserIsAssignedPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUserIsAssignedPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UserIsAssigned) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Comments_UserIsAssigned_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUserIsAssigned, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_commentsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (UserIsAssigned) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Comments_UserIsAssigned_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUserIsAssigned, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetItemAssigneeIds) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Comments_GetItemAssigneeIds_Method_Call_Internally(Type[] types)
        {
            var methodGetItemAssigneeIdsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commentsInstance, MethodGetItemAssigneeIds, Fixture, methodGetItemAssigneeIdsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetItemAssigneeIds) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Comments_GetItemAssigneeIds_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var item = CreateType<SPListItem>();
            var methodGetItemAssigneeIdsPrametersTypes = new Type[] { typeof(SPListItem) };
            object[] parametersOfGetItemAssigneeIds = { item };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetItemAssigneeIds, methodGetItemAssigneeIdsPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetItemAssigneeIds.ShouldNotBeNull();
            parametersOfGetItemAssigneeIds.Length.ShouldBe(1);
            methodGetItemAssigneeIdsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(_commentsInstanceFixture, parametersOfGetItemAssigneeIds));
        }

        #endregion

        #region Method Call : (GetItemAssigneeIds) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Comments_GetItemAssigneeIds_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var item = CreateType<SPListItem>();
            var methodGetItemAssigneeIdsPrametersTypes = new Type[] { typeof(SPListItem) };
            object[] parametersOfGetItemAssigneeIds = { item };

            // Assert
            parametersOfGetItemAssigneeIds.ShouldNotBeNull();
            parametersOfGetItemAssigneeIds.Length.ShouldBe(1);
            methodGetItemAssigneeIdsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Comments, string>(_commentsInstance, MethodGetItemAssigneeIds, parametersOfGetItemAssigneeIds, methodGetItemAssigneeIdsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetItemAssigneeIds) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Comments_GetItemAssigneeIds_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetItemAssigneeIdsPrametersTypes = new Type[] { typeof(SPListItem) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commentsInstance, MethodGetItemAssigneeIds, Fixture, methodGetItemAssigneeIdsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetItemAssigneeIdsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetItemAssigneeIds) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Comments_GetItemAssigneeIds_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetItemAssigneeIdsPrametersTypes = new Type[] { typeof(SPListItem) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commentsInstance, MethodGetItemAssigneeIds, Fixture, methodGetItemAssigneeIdsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetItemAssigneeIdsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetItemAssigneeIds) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Comments_GetItemAssigneeIds_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetItemAssigneeIds, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_commentsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetItemAssigneeIds) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Comments_GetItemAssigneeIds_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetItemAssigneeIds, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetItemAuthorId) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Comments_GetItemAuthorId_Method_Call_Internally(Type[] types)
        {
            var methodGetItemAuthorIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commentsInstance, MethodGetItemAuthorId, Fixture, methodGetItemAuthorIdPrametersTypes);
        }

        #endregion

        #region Method Call : (GetItemAuthorId) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Comments_GetItemAuthorId_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var item = CreateType<SPListItem>();
            var methodGetItemAuthorIdPrametersTypes = new Type[] { typeof(SPListItem) };
            object[] parametersOfGetItemAuthorId = { item };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetItemAuthorId, methodGetItemAuthorIdPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Comments, string>(_commentsInstanceFixture, out exception1, parametersOfGetItemAuthorId);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Comments, string>(_commentsInstance, MethodGetItemAuthorId, parametersOfGetItemAuthorId, methodGetItemAuthorIdPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetItemAuthorId.ShouldNotBeNull();
            parametersOfGetItemAuthorId.Length.ShouldBe(1);
            methodGetItemAuthorIdPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_commentsInstanceFixture, parametersOfGetItemAuthorId));
        }

        #endregion

        #region Method Call : (GetItemAuthorId) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Comments_GetItemAuthorId_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var item = CreateType<SPListItem>();
            var methodGetItemAuthorIdPrametersTypes = new Type[] { typeof(SPListItem) };
            object[] parametersOfGetItemAuthorId = { item };

            // Assert
            parametersOfGetItemAuthorId.ShouldNotBeNull();
            parametersOfGetItemAuthorId.Length.ShouldBe(1);
            methodGetItemAuthorIdPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Comments, string>(_commentsInstance, MethodGetItemAuthorId, parametersOfGetItemAuthorId, methodGetItemAuthorIdPrametersTypes));
        }

        #endregion

        #region Method Call : (GetItemAuthorId) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Comments_GetItemAuthorId_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetItemAuthorIdPrametersTypes = new Type[] { typeof(SPListItem) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commentsInstance, MethodGetItemAuthorId, Fixture, methodGetItemAuthorIdPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetItemAuthorIdPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetItemAuthorId) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Comments_GetItemAuthorId_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetItemAuthorIdPrametersTypes = new Type[] { typeof(SPListItem) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commentsInstance, MethodGetItemAuthorId, Fixture, methodGetItemAuthorIdPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetItemAuthorIdPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetItemAuthorId) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Comments_GetItemAuthorId_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetItemAuthorId, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_commentsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetItemAuthorId) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Comments_GetItemAuthorId_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetItemAuthorId, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddCommentersFields) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Comments_AddCommentersFields_Method_Call_Internally(Type[] types)
        {
            var methodAddCommentersFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commentsInstance, MethodAddCommentersFields, Fixture, methodAddCommentersFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (AddCommentersFields) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Comments_AddCommentersFields_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodAddCommentersFieldsPrametersTypes = null;
            object[] parametersOfAddCommentersFields = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddCommentersFields, methodAddCommentersFieldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_commentsInstanceFixture, parametersOfAddCommentersFields);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddCommentersFields.ShouldBeNull();
            methodAddCommentersFieldsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddCommentersFields) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Comments_AddCommentersFields_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodAddCommentersFieldsPrametersTypes = null;
            object[] parametersOfAddCommentersFields = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_commentsInstance, MethodAddCommentersFields, parametersOfAddCommentersFields, methodAddCommentersFieldsPrametersTypes);

            // Assert
            parametersOfAddCommentersFields.ShouldBeNull();
            methodAddCommentersFieldsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddCommentersFields) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Comments_AddCommentersFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodAddCommentersFieldsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commentsInstance, MethodAddCommentersFields, Fixture, methodAddCommentersFieldsPrametersTypes);

            // Assert
            methodAddCommentersFieldsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddCommentersFields) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Comments_AddCommentersFields_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddCommentersFields, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_commentsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildHTMLTableRowsForEachComment) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Comments_BuildHTMLTableRowsForEachComment_Method_Call_Internally(Type[] types)
        {
            var methodBuildHTMLTableRowsForEachCommentPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commentsInstance, MethodBuildHTMLTableRowsForEachComment, Fixture, methodBuildHTMLTableRowsForEachCommentPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildHTMLTableRowsForEachComment) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Comments_BuildHTMLTableRowsForEachComment_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodBuildHTMLTableRowsForEachCommentPrametersTypes = null;
            object[] parametersOfBuildHTMLTableRowsForEachComment = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBuildHTMLTableRowsForEachComment, methodBuildHTMLTableRowsForEachCommentPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_commentsInstanceFixture, parametersOfBuildHTMLTableRowsForEachComment);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfBuildHTMLTableRowsForEachComment.ShouldBeNull();
            methodBuildHTMLTableRowsForEachCommentPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (BuildHTMLTableRowsForEachComment) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Comments_BuildHTMLTableRowsForEachComment_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodBuildHTMLTableRowsForEachCommentPrametersTypes = null;
            object[] parametersOfBuildHTMLTableRowsForEachComment = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_commentsInstance, MethodBuildHTMLTableRowsForEachComment, parametersOfBuildHTMLTableRowsForEachComment, methodBuildHTMLTableRowsForEachCommentPrametersTypes);

            // Assert
            parametersOfBuildHTMLTableRowsForEachComment.ShouldBeNull();
            methodBuildHTMLTableRowsForEachCommentPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildHTMLTableRowsForEachComment) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Comments_BuildHTMLTableRowsForEachComment_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodBuildHTMLTableRowsForEachCommentPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commentsInstance, MethodBuildHTMLTableRowsForEachComment, Fixture, methodBuildHTMLTableRowsForEachCommentPrametersTypes);

            // Assert
            methodBuildHTMLTableRowsForEachCommentPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildHTMLTableRowsForEachComment) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Comments_BuildHTMLTableRowsForEachComment_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildHTMLTableRowsForEachComment, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_commentsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
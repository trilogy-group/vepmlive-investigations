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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.newapp" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class NewappTest : AbstractBaseSetupTypedTest<newapp>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (newapp) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodBtnOK_Click = "BtnOK_Click";
        private const string MethodUpdateList = "UpdateList";
        private const string Field_spProjectUtility = "_spProjectUtility";
        private const string FieldbaseURL = "baseURL";
        private const string FieldmetaDataString = "metaDataString";
        private const string FieldprocessString = "processString";
        private const string FieldrequiredOK = "requiredOK";
        private const string FieldbtnOK = "btnOK";
        private const string FieldDdlGroup = "DdlGroup";
        private const string FieldpnlTitle = "pnlTitle";
        private const string FieldpnlURL = "pnlURL";
        private const string FieldpnlURLBad = "pnlURLBad";
        private const string FieldtxtURL = "txtURL";
        private const string FieldtxtTitle = "txtTitle";
        private const string Fieldlabel1 = "label1";
        private const string FieldPanel2 = "Panel2";
        private const string FieldURL = "URL";
        private const string FieldrdoTopLinkYes = "rdoTopLinkYes";
        private const string FieldrdoTopLinkNo = "rdoTopLinkNo";
        private const string FieldrdoUnique = "rdoUnique";
        private const string FieldrdoInherit = "rdoInherit";
        private const string FieldwsTypeNew = "wsTypeNew";
        private const string FieldwsTypeExisting = "wsTypeExisting";
        private const string FieldlistName = "listName";
        private const string FieldstrName = "strName";
        private const string FieldinpName = "inpName";
        private const string FieldvalidTemplates = "validTemplates";
        private Type _newappInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private newapp _newappInstance;
        private newapp _newappInstanceFixture;

        #region General Initializer : Class (newapp) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="newapp" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _newappInstanceType = typeof(newapp);
            _newappInstanceFixture = Create(true);
            _newappInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (newapp)

        #region General Initializer : Class (newapp) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="newapp" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodBtnOK_Click, 0)]
        public void AUT_Newapp_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_newappInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (newapp) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="newapp" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldbaseURL)]
        [TestCase(FieldmetaDataString)]
        [TestCase(FieldprocessString)]
        [TestCase(FieldrequiredOK)]
        [TestCase(FieldbtnOK)]
        [TestCase(FieldDdlGroup)]
        [TestCase(FieldpnlTitle)]
        [TestCase(FieldpnlURL)]
        [TestCase(FieldpnlURLBad)]
        [TestCase(FieldtxtURL)]
        [TestCase(FieldtxtTitle)]
        [TestCase(Fieldlabel1)]
        [TestCase(FieldPanel2)]
        [TestCase(FieldURL)]
        [TestCase(FieldrdoTopLinkYes)]
        [TestCase(FieldrdoTopLinkNo)]
        [TestCase(FieldrdoUnique)]
        [TestCase(FieldrdoInherit)]
        [TestCase(FieldwsTypeNew)]
        [TestCase(FieldwsTypeExisting)]
        [TestCase(FieldlistName)]
        [TestCase(FieldstrName)]
        [TestCase(FieldinpName)]
        [TestCase(FieldvalidTemplates)]
        public void AUT_Newapp_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_newappInstanceFixture, 
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
        ///     Class (<see cref="newapp" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Newapp_Is_Instance_Present_Test()
        {
            // Assert
            _newappInstanceType.ShouldNotBeNull();
            _newappInstance.ShouldNotBeNull();
            _newappInstanceFixture.ShouldNotBeNull();
            _newappInstance.ShouldBeAssignableTo<newapp>();
            _newappInstanceFixture.ShouldBeAssignableTo<newapp>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (newapp) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_newapp_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            newapp instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _newappInstanceType.ShouldNotBeNull();
            _newappInstance.ShouldNotBeNull();
            _newappInstanceFixture.ShouldNotBeNull();
            _newappInstance.ShouldBeAssignableTo<newapp>();
            _newappInstanceFixture.ShouldBeAssignableTo<newapp>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="newapp" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodBtnOK_Click)]
        public void AUT_Newapp_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<newapp>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Newapp_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_newappInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Newapp_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_newappInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Newapp_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_newappInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Newapp_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Newapp_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_newappInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Newapp_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_newappInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BtnOK_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Newapp_BtnOK_Click_Method_Call_Internally(Type[] types)
        {
            var methodBtnOK_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_newappInstance, MethodBtnOK_Click, Fixture, methodBtnOK_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (BtnOK_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Newapp_BtnOK_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodBtnOK_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfBtnOK_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBtnOK_Click, methodBtnOK_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_newappInstanceFixture, parametersOfBtnOK_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfBtnOK_Click.ShouldNotBeNull();
            parametersOfBtnOK_Click.Length.ShouldBe(2);
            methodBtnOK_ClickPrametersTypes.Length.ShouldBe(2);
            methodBtnOK_ClickPrametersTypes.Length.ShouldBe(parametersOfBtnOK_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (BtnOK_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Newapp_BtnOK_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodBtnOK_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfBtnOK_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_newappInstance, MethodBtnOK_Click, parametersOfBtnOK_Click, methodBtnOK_ClickPrametersTypes);

            // Assert
            parametersOfBtnOK_Click.ShouldNotBeNull();
            parametersOfBtnOK_Click.Length.ShouldBe(2);
            methodBtnOK_ClickPrametersTypes.Length.ShouldBe(2);
            methodBtnOK_ClickPrametersTypes.Length.ShouldBe(parametersOfBtnOK_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BtnOK_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Newapp_BtnOK_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBtnOK_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BtnOK_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Newapp_BtnOK_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBtnOK_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_newappInstance, MethodBtnOK_Click, Fixture, methodBtnOK_ClickPrametersTypes);

            // Assert
            methodBtnOK_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BtnOK_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Newapp_BtnOK_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBtnOK_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_newappInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateList) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Newapp_UpdateList_Method_Call_Internally(Type[] types)
        {
            var methodUpdateListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_newappInstance, MethodUpdateList, Fixture, methodUpdateListPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateList) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Newapp_UpdateList_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var currentList = CreateType<SPList>();
            var workspaceId = CreateType<Guid>();
            var methodUpdateListPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPList), typeof(Guid) };
            object[] parametersOfUpdateList = { web, currentList, workspaceId };

            // Assert
            parametersOfUpdateList.ShouldNotBeNull();
            parametersOfUpdateList.Length.ShouldBe(3);
            methodUpdateListPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<newapp, string>(_newappInstance, MethodUpdateList, parametersOfUpdateList, methodUpdateListPrametersTypes));
        }

        #endregion

        #region Method Call : (UpdateList) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Newapp_UpdateList_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodUpdateListPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPList), typeof(Guid) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_newappInstance, MethodUpdateList, Fixture, methodUpdateListPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodUpdateListPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (UpdateList) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Newapp_UpdateList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateListPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPList), typeof(Guid) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_newappInstance, MethodUpdateList, Fixture, methodUpdateListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateListPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #endregion

        #endregion
    }
}
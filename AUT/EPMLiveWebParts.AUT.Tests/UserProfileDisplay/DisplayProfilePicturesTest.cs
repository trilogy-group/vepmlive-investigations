using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Web.UI;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebPartPages;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.DisplayProfilePictures" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class DisplayProfilePicturesTest : AbstractBaseSetupTypedTest<DisplayProfilePictures>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DisplayProfilePictures) Initializer

        private const string PropertyLargeImage = "LargeImage";
        private const string MethodRender = "Render";
        private const string MethodWriteJavascriptToOutput = "WriteJavascriptToOutput";
        private const string MethodGetToolParts = "GetToolParts";
        private const string MethodUpdateContextSoWeCanGetDataFromSiteUserInfoList = "UpdateContextSoWeCanGetDataFromSiteUserInfoList";
        private const string MethodGetCurrentDate = "GetCurrentDate";
        private const string MethodWriteStylesToOutput = "WriteStylesToOutput";
        private const string MethodWriteSmallImageHtmlToOutput = "WriteSmallImageHtmlToOutput";
        private const string MethodWriteLargeImageHtmlToOutput = "WriteLargeImageHtmlToOutput";
        private const string MethodGetProfilePicturePath = "GetProfilePicturePath";
        private const string MethodGetProfileUser = "GetProfileUser";
        private const string MethodIsSharePointSystemAccount = "IsSharePointSystemAccount";
        private const string MethodGetUserProfileManagerClass = "GetUserProfileManagerClass";
        private const string MethodHasMySite = "HasMySite";
        private const string FieldDefaultProfilePicturePath = "DefaultProfilePicturePath";
        private Type _displayProfilePicturesInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DisplayProfilePictures _displayProfilePicturesInstance;
        private DisplayProfilePictures _displayProfilePicturesInstanceFixture;

        #region General Initializer : Class (DisplayProfilePictures) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DisplayProfilePictures" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _displayProfilePicturesInstanceType = typeof(DisplayProfilePictures);
            _displayProfilePicturesInstanceFixture = Create(true);
            _displayProfilePicturesInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DisplayProfilePictures)
        
        #region General Initializer : Class (DisplayProfilePictures) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DisplayProfilePictures" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyLargeImage)]
        public void AUT_DisplayProfilePictures_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_displayProfilePicturesInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DisplayProfilePictures) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DisplayProfilePictures" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldDefaultProfilePicturePath)]
        public void AUT_DisplayProfilePictures_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_displayProfilePicturesInstanceFixture, 
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
        ///     Class (<see cref="DisplayProfilePictures" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DisplayProfilePictures_Is_Instance_Present_Test()
        {
            // Assert
            _displayProfilePicturesInstanceType.ShouldNotBeNull();
            _displayProfilePicturesInstance.ShouldNotBeNull();
            _displayProfilePicturesInstanceFixture.ShouldNotBeNull();
            _displayProfilePicturesInstance.ShouldBeAssignableTo<DisplayProfilePictures>();
            _displayProfilePicturesInstanceFixture.ShouldBeAssignableTo<DisplayProfilePictures>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DisplayProfilePictures) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DisplayProfilePictures_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DisplayProfilePictures instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _displayProfilePicturesInstanceType.ShouldNotBeNull();
            _displayProfilePicturesInstance.ShouldNotBeNull();
            _displayProfilePicturesInstanceFixture.ShouldNotBeNull();
            _displayProfilePicturesInstance.ShouldBeAssignableTo<DisplayProfilePictures>();
            _displayProfilePicturesInstanceFixture.ShouldBeAssignableTo<DisplayProfilePictures>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DisplayProfilePictures) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertyLargeImage)]
        public void AUT_DisplayProfilePictures_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DisplayProfilePictures, T>(_displayProfilePicturesInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DisplayProfilePictures) => Property (LargeImage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DisplayProfilePictures_Public_Class_LargeImage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyLargeImage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="DisplayProfilePictures" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        [TestCase(MethodUpdateContextSoWeCanGetDataFromSiteUserInfoList)]
        public void AUT_DisplayProfilePictures_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_displayProfilePicturesInstanceFixture,
                                                                              _displayProfilePicturesInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion
        
        #region Method Call : (Render) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DisplayProfilePictures_Render_Method_Call_Internally(Type[] types)
        {
            var methodRenderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_displayProfilePicturesInstance, MethodRender, Fixture, methodRenderPrametersTypes);
        }

        #endregion

        #region Method Call : (Render) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_Render_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var writer = CreateType<HtmlTextWriter>();
            var methodRenderPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRender = { writer };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRender, methodRenderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_displayProfilePicturesInstanceFixture, parametersOfRender);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRender.ShouldNotBeNull();
            parametersOfRender.Length.ShouldBe(1);
            methodRenderPrametersTypes.Length.ShouldBe(1);
            methodRenderPrametersTypes.Length.ShouldBe(parametersOfRender.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Render) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_Render_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var writer = CreateType<HtmlTextWriter>();
            var methodRenderPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRender = { writer };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_displayProfilePicturesInstance, MethodRender, parametersOfRender, methodRenderPrametersTypes);

            // Assert
            parametersOfRender.ShouldNotBeNull();
            parametersOfRender.Length.ShouldBe(1);
            methodRenderPrametersTypes.Length.ShouldBe(1);
            methodRenderPrametersTypes.Length.ShouldBe(parametersOfRender.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Render) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_Render_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRender, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Render) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_Render_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenderPrametersTypes = new Type[] { typeof(HtmlTextWriter) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_displayProfilePicturesInstance, MethodRender, Fixture, methodRenderPrametersTypes);

            // Assert
            methodRenderPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Render) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_Render_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRender, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_displayProfilePicturesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteJavascriptToOutput) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DisplayProfilePictures_WriteJavascriptToOutput_Method_Call_Internally(Type[] types)
        {
            var methodWriteJavascriptToOutputPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_displayProfilePicturesInstance, MethodWriteJavascriptToOutput, Fixture, methodWriteJavascriptToOutputPrametersTypes);
        }

        #endregion

        #region Method Call : (WriteJavascriptToOutput) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_WriteJavascriptToOutput_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var writer = CreateType<HtmlTextWriter>();
            var methodWriteJavascriptToOutputPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfWriteJavascriptToOutput = { writer };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodWriteJavascriptToOutput, methodWriteJavascriptToOutputPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_displayProfilePicturesInstanceFixture, parametersOfWriteJavascriptToOutput);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfWriteJavascriptToOutput.ShouldNotBeNull();
            parametersOfWriteJavascriptToOutput.Length.ShouldBe(1);
            methodWriteJavascriptToOutputPrametersTypes.Length.ShouldBe(1);
            methodWriteJavascriptToOutputPrametersTypes.Length.ShouldBe(parametersOfWriteJavascriptToOutput.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteJavascriptToOutput) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_WriteJavascriptToOutput_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var writer = CreateType<HtmlTextWriter>();
            var methodWriteJavascriptToOutputPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfWriteJavascriptToOutput = { writer };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_displayProfilePicturesInstance, MethodWriteJavascriptToOutput, parametersOfWriteJavascriptToOutput, methodWriteJavascriptToOutputPrametersTypes);

            // Assert
            parametersOfWriteJavascriptToOutput.ShouldNotBeNull();
            parametersOfWriteJavascriptToOutput.Length.ShouldBe(1);
            methodWriteJavascriptToOutputPrametersTypes.Length.ShouldBe(1);
            methodWriteJavascriptToOutputPrametersTypes.Length.ShouldBe(parametersOfWriteJavascriptToOutput.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteJavascriptToOutput) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_WriteJavascriptToOutput_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodWriteJavascriptToOutput, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (WriteJavascriptToOutput) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_WriteJavascriptToOutput_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodWriteJavascriptToOutputPrametersTypes = new Type[] { typeof(HtmlTextWriter) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_displayProfilePicturesInstance, MethodWriteJavascriptToOutput, Fixture, methodWriteJavascriptToOutputPrametersTypes);

            // Assert
            methodWriteJavascriptToOutputPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteJavascriptToOutput) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_WriteJavascriptToOutput_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodWriteJavascriptToOutput, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_displayProfilePicturesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DisplayProfilePictures_GetToolParts_Method_Call_Internally(Type[] types)
        {
            var methodGetToolPartsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_displayProfilePicturesInstance, MethodGetToolParts, Fixture, methodGetToolPartsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_GetToolParts_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _displayProfilePicturesInstance.GetToolParts();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_GetToolParts_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetToolPartsPrametersTypes = null;
            object[] parametersOfGetToolParts = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetToolParts, methodGetToolPartsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_displayProfilePicturesInstanceFixture, parametersOfGetToolParts);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetToolParts.ShouldBeNull();
            methodGetToolPartsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_GetToolParts_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetToolPartsPrametersTypes = null;
            object[] parametersOfGetToolParts = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<DisplayProfilePictures, ToolPart[]>(_displayProfilePicturesInstance, MethodGetToolParts, parametersOfGetToolParts, methodGetToolPartsPrametersTypes);

            // Assert
            parametersOfGetToolParts.ShouldBeNull();
            methodGetToolPartsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_GetToolParts_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetToolPartsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_displayProfilePicturesInstance, MethodGetToolParts, Fixture, methodGetToolPartsPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetToolPartsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_GetToolParts_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetToolPartsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_displayProfilePicturesInstance, MethodGetToolParts, Fixture, methodGetToolPartsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetToolPartsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_GetToolParts_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetToolParts, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_displayProfilePicturesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (UpdateContextSoWeCanGetDataFromSiteUserInfoList) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DisplayProfilePictures_UpdateContextSoWeCanGetDataFromSiteUserInfoList_Static_Method_Call_Internally(Type[] types)
        {
            var methodUpdateContextSoWeCanGetDataFromSiteUserInfoListPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_displayProfilePicturesInstanceFixture, _displayProfilePicturesInstanceType, MethodUpdateContextSoWeCanGetDataFromSiteUserInfoList, Fixture, methodUpdateContextSoWeCanGetDataFromSiteUserInfoListPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateContextSoWeCanGetDataFromSiteUserInfoList) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_UpdateContextSoWeCanGetDataFromSiteUserInfoList_Static_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodUpdateContextSoWeCanGetDataFromSiteUserInfoListPrametersTypes = null;
            object[] parametersOfUpdateContextSoWeCanGetDataFromSiteUserInfoList = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateContextSoWeCanGetDataFromSiteUserInfoList, methodUpdateContextSoWeCanGetDataFromSiteUserInfoListPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_displayProfilePicturesInstanceFixture, parametersOfUpdateContextSoWeCanGetDataFromSiteUserInfoList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateContextSoWeCanGetDataFromSiteUserInfoList.ShouldBeNull();
            methodUpdateContextSoWeCanGetDataFromSiteUserInfoListPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateContextSoWeCanGetDataFromSiteUserInfoList) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_UpdateContextSoWeCanGetDataFromSiteUserInfoList_Static_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodUpdateContextSoWeCanGetDataFromSiteUserInfoListPrametersTypes = null;
            object[] parametersOfUpdateContextSoWeCanGetDataFromSiteUserInfoList = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_displayProfilePicturesInstanceFixture, _displayProfilePicturesInstanceType, MethodUpdateContextSoWeCanGetDataFromSiteUserInfoList, parametersOfUpdateContextSoWeCanGetDataFromSiteUserInfoList, methodUpdateContextSoWeCanGetDataFromSiteUserInfoListPrametersTypes);

            // Assert
            parametersOfUpdateContextSoWeCanGetDataFromSiteUserInfoList.ShouldBeNull();
            methodUpdateContextSoWeCanGetDataFromSiteUserInfoListPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateContextSoWeCanGetDataFromSiteUserInfoList) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_UpdateContextSoWeCanGetDataFromSiteUserInfoList_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodUpdateContextSoWeCanGetDataFromSiteUserInfoListPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_displayProfilePicturesInstanceFixture, _displayProfilePicturesInstanceType, MethodUpdateContextSoWeCanGetDataFromSiteUserInfoList, Fixture, methodUpdateContextSoWeCanGetDataFromSiteUserInfoListPrametersTypes);

            // Assert
            methodUpdateContextSoWeCanGetDataFromSiteUserInfoListPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateContextSoWeCanGetDataFromSiteUserInfoList) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_UpdateContextSoWeCanGetDataFromSiteUserInfoList_Static_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateContextSoWeCanGetDataFromSiteUserInfoList, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_displayProfilePicturesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCurrentDate) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DisplayProfilePictures_GetCurrentDate_Method_Call_Internally(Type[] types)
        {
            var methodGetCurrentDatePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_displayProfilePicturesInstance, MethodGetCurrentDate, Fixture, methodGetCurrentDatePrametersTypes);
        }

        #endregion

        #region Method Call : (GetCurrentDate) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_GetCurrentDate_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodGetCurrentDatePrametersTypes = null;
            object[] parametersOfGetCurrentDate = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetCurrentDate, methodGetCurrentDatePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<DisplayProfilePictures, string>(_displayProfilePicturesInstanceFixture, out exception1, parametersOfGetCurrentDate);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<DisplayProfilePictures, string>(_displayProfilePicturesInstance, MethodGetCurrentDate, parametersOfGetCurrentDate, methodGetCurrentDatePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetCurrentDate.ShouldBeNull();
            methodGetCurrentDatePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCurrentDate) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_GetCurrentDate_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetCurrentDatePrametersTypes = null;
            object[] parametersOfGetCurrentDate = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetCurrentDate, methodGetCurrentDatePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_displayProfilePicturesInstanceFixture, parametersOfGetCurrentDate);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetCurrentDate.ShouldBeNull();
            methodGetCurrentDatePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCurrentDate) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_GetCurrentDate_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetCurrentDatePrametersTypes = null;
            object[] parametersOfGetCurrentDate = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<DisplayProfilePictures, string>(_displayProfilePicturesInstance, MethodGetCurrentDate, parametersOfGetCurrentDate, methodGetCurrentDatePrametersTypes);

            // Assert
            parametersOfGetCurrentDate.ShouldBeNull();
            methodGetCurrentDatePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCurrentDate) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_GetCurrentDate_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetCurrentDatePrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_displayProfilePicturesInstance, MethodGetCurrentDate, Fixture, methodGetCurrentDatePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetCurrentDatePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCurrentDate) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_GetCurrentDate_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetCurrentDatePrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_displayProfilePicturesInstance, MethodGetCurrentDate, Fixture, methodGetCurrentDatePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCurrentDatePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCurrentDate) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_GetCurrentDate_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCurrentDate, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_displayProfilePicturesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (WriteStylesToOutput) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DisplayProfilePictures_WriteStylesToOutput_Method_Call_Internally(Type[] types)
        {
            var methodWriteStylesToOutputPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_displayProfilePicturesInstance, MethodWriteStylesToOutput, Fixture, methodWriteStylesToOutputPrametersTypes);
        }

        #endregion

        #region Method Call : (WriteStylesToOutput) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_WriteStylesToOutput_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var writer = CreateType<HtmlTextWriter>();
            var methodWriteStylesToOutputPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfWriteStylesToOutput = { writer };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodWriteStylesToOutput, methodWriteStylesToOutputPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_displayProfilePicturesInstanceFixture, parametersOfWriteStylesToOutput);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfWriteStylesToOutput.ShouldNotBeNull();
            parametersOfWriteStylesToOutput.Length.ShouldBe(1);
            methodWriteStylesToOutputPrametersTypes.Length.ShouldBe(1);
            methodWriteStylesToOutputPrametersTypes.Length.ShouldBe(parametersOfWriteStylesToOutput.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteStylesToOutput) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_WriteStylesToOutput_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var writer = CreateType<HtmlTextWriter>();
            var methodWriteStylesToOutputPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfWriteStylesToOutput = { writer };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_displayProfilePicturesInstance, MethodWriteStylesToOutput, parametersOfWriteStylesToOutput, methodWriteStylesToOutputPrametersTypes);

            // Assert
            parametersOfWriteStylesToOutput.ShouldNotBeNull();
            parametersOfWriteStylesToOutput.Length.ShouldBe(1);
            methodWriteStylesToOutputPrametersTypes.Length.ShouldBe(1);
            methodWriteStylesToOutputPrametersTypes.Length.ShouldBe(parametersOfWriteStylesToOutput.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteStylesToOutput) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_WriteStylesToOutput_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodWriteStylesToOutput, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (WriteStylesToOutput) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_WriteStylesToOutput_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodWriteStylesToOutputPrametersTypes = new Type[] { typeof(HtmlTextWriter) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_displayProfilePicturesInstance, MethodWriteStylesToOutput, Fixture, methodWriteStylesToOutputPrametersTypes);

            // Assert
            methodWriteStylesToOutputPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteStylesToOutput) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_WriteStylesToOutput_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodWriteStylesToOutput, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_displayProfilePicturesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteSmallImageHtmlToOutput) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DisplayProfilePictures_WriteSmallImageHtmlToOutput_Method_Call_Internally(Type[] types)
        {
            var methodWriteSmallImageHtmlToOutputPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_displayProfilePicturesInstance, MethodWriteSmallImageHtmlToOutput, Fixture, methodWriteSmallImageHtmlToOutputPrametersTypes);
        }

        #endregion

        #region Method Call : (WriteSmallImageHtmlToOutput) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_WriteSmallImageHtmlToOutput_Method_Call_Void_With_6_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var writer = CreateType<HtmlTextWriter>();
            var loginName = CreateType<string>();
            var profilePicturePath = CreateType<string>();
            var personalUrl = CreateType<string>();
            var isSharepointServer = CreateType<bool>();
            var hasMySite = CreateType<bool>();
            var methodWriteSmallImageHtmlToOutputPrametersTypes = new Type[] { typeof(HtmlTextWriter), typeof(string), typeof(string), typeof(string), typeof(bool), typeof(bool) };
            object[] parametersOfWriteSmallImageHtmlToOutput = { writer, loginName, profilePicturePath, personalUrl, isSharepointServer, hasMySite };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodWriteSmallImageHtmlToOutput, methodWriteSmallImageHtmlToOutputPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_displayProfilePicturesInstanceFixture, parametersOfWriteSmallImageHtmlToOutput);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfWriteSmallImageHtmlToOutput.ShouldNotBeNull();
            parametersOfWriteSmallImageHtmlToOutput.Length.ShouldBe(6);
            methodWriteSmallImageHtmlToOutputPrametersTypes.Length.ShouldBe(6);
            methodWriteSmallImageHtmlToOutputPrametersTypes.Length.ShouldBe(parametersOfWriteSmallImageHtmlToOutput.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (WriteSmallImageHtmlToOutput) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_WriteSmallImageHtmlToOutput_Method_Call_Void_With_6_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var writer = CreateType<HtmlTextWriter>();
            var loginName = CreateType<string>();
            var profilePicturePath = CreateType<string>();
            var personalUrl = CreateType<string>();
            var isSharepointServer = CreateType<bool>();
            var hasMySite = CreateType<bool>();
            var methodWriteSmallImageHtmlToOutputPrametersTypes = new Type[] { typeof(HtmlTextWriter), typeof(string), typeof(string), typeof(string), typeof(bool), typeof(bool) };
            object[] parametersOfWriteSmallImageHtmlToOutput = { writer, loginName, profilePicturePath, personalUrl, isSharepointServer, hasMySite };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_displayProfilePicturesInstance, MethodWriteSmallImageHtmlToOutput, parametersOfWriteSmallImageHtmlToOutput, methodWriteSmallImageHtmlToOutputPrametersTypes);

            // Assert
            parametersOfWriteSmallImageHtmlToOutput.ShouldNotBeNull();
            parametersOfWriteSmallImageHtmlToOutput.Length.ShouldBe(6);
            methodWriteSmallImageHtmlToOutputPrametersTypes.Length.ShouldBe(6);
            methodWriteSmallImageHtmlToOutputPrametersTypes.Length.ShouldBe(parametersOfWriteSmallImageHtmlToOutput.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteSmallImageHtmlToOutput) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_WriteSmallImageHtmlToOutput_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodWriteSmallImageHtmlToOutput, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (WriteSmallImageHtmlToOutput) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_WriteSmallImageHtmlToOutput_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodWriteSmallImageHtmlToOutputPrametersTypes = new Type[] { typeof(HtmlTextWriter), typeof(string), typeof(string), typeof(string), typeof(bool), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_displayProfilePicturesInstance, MethodWriteSmallImageHtmlToOutput, Fixture, methodWriteSmallImageHtmlToOutputPrametersTypes);

            // Assert
            methodWriteSmallImageHtmlToOutputPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteSmallImageHtmlToOutput) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_WriteSmallImageHtmlToOutput_Method_Call_With_6_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodWriteSmallImageHtmlToOutput, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_displayProfilePicturesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteLargeImageHtmlToOutput) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DisplayProfilePictures_WriteLargeImageHtmlToOutput_Method_Call_Internally(Type[] types)
        {
            var methodWriteLargeImageHtmlToOutputPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_displayProfilePicturesInstance, MethodWriteLargeImageHtmlToOutput, Fixture, methodWriteLargeImageHtmlToOutputPrametersTypes);
        }

        #endregion

        #region Method Call : (WriteLargeImageHtmlToOutput) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_WriteLargeImageHtmlToOutput_Method_Call_Void_With_7_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var writer = CreateType<HtmlTextWriter>();
            var profilePicturePath = CreateType<string>();
            var loginName = CreateType<string>();
            var currentUser = CreateType<SPUser>();
            var personalUrl = CreateType<string>();
            var isSharepointServer = CreateType<bool>();
            var hasMySite = CreateType<bool>();
            var methodWriteLargeImageHtmlToOutputPrametersTypes = new Type[] { typeof(HtmlTextWriter), typeof(string), typeof(string), typeof(SPUser), typeof(string), typeof(bool), typeof(bool) };
            object[] parametersOfWriteLargeImageHtmlToOutput = { writer, profilePicturePath, loginName, currentUser, personalUrl, isSharepointServer, hasMySite };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodWriteLargeImageHtmlToOutput, methodWriteLargeImageHtmlToOutputPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_displayProfilePicturesInstanceFixture, parametersOfWriteLargeImageHtmlToOutput);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfWriteLargeImageHtmlToOutput.ShouldNotBeNull();
            parametersOfWriteLargeImageHtmlToOutput.Length.ShouldBe(7);
            methodWriteLargeImageHtmlToOutputPrametersTypes.Length.ShouldBe(7);
            methodWriteLargeImageHtmlToOutputPrametersTypes.Length.ShouldBe(parametersOfWriteLargeImageHtmlToOutput.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (WriteLargeImageHtmlToOutput) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_WriteLargeImageHtmlToOutput_Method_Call_Void_With_7_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var writer = CreateType<HtmlTextWriter>();
            var profilePicturePath = CreateType<string>();
            var loginName = CreateType<string>();
            var currentUser = CreateType<SPUser>();
            var personalUrl = CreateType<string>();
            var isSharepointServer = CreateType<bool>();
            var hasMySite = CreateType<bool>();
            var methodWriteLargeImageHtmlToOutputPrametersTypes = new Type[] { typeof(HtmlTextWriter), typeof(string), typeof(string), typeof(SPUser), typeof(string), typeof(bool), typeof(bool) };
            object[] parametersOfWriteLargeImageHtmlToOutput = { writer, profilePicturePath, loginName, currentUser, personalUrl, isSharepointServer, hasMySite };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_displayProfilePicturesInstance, MethodWriteLargeImageHtmlToOutput, parametersOfWriteLargeImageHtmlToOutput, methodWriteLargeImageHtmlToOutputPrametersTypes);

            // Assert
            parametersOfWriteLargeImageHtmlToOutput.ShouldNotBeNull();
            parametersOfWriteLargeImageHtmlToOutput.Length.ShouldBe(7);
            methodWriteLargeImageHtmlToOutputPrametersTypes.Length.ShouldBe(7);
            methodWriteLargeImageHtmlToOutputPrametersTypes.Length.ShouldBe(parametersOfWriteLargeImageHtmlToOutput.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteLargeImageHtmlToOutput) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_WriteLargeImageHtmlToOutput_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodWriteLargeImageHtmlToOutput, 0);
            const int parametersCount = 7;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (WriteLargeImageHtmlToOutput) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_WriteLargeImageHtmlToOutput_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodWriteLargeImageHtmlToOutputPrametersTypes = new Type[] { typeof(HtmlTextWriter), typeof(string), typeof(string), typeof(SPUser), typeof(string), typeof(bool), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_displayProfilePicturesInstance, MethodWriteLargeImageHtmlToOutput, Fixture, methodWriteLargeImageHtmlToOutputPrametersTypes);

            // Assert
            methodWriteLargeImageHtmlToOutputPrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteLargeImageHtmlToOutput) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_WriteLargeImageHtmlToOutput_Method_Call_With_7_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodWriteLargeImageHtmlToOutput, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_displayProfilePicturesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetProfilePicturePath) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DisplayProfilePictures_GetProfilePicturePath_Method_Call_Internally(Type[] types)
        {
            var methodGetProfilePicturePathPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_displayProfilePicturesInstance, MethodGetProfilePicturePath, Fixture, methodGetProfilePicturePathPrametersTypes);
        }

        #endregion

        #region Method Call : (GetProfilePicturePath) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_GetProfilePicturePath_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var spListItem = CreateType<SPListItem>();
            var methodGetProfilePicturePathPrametersTypes = new Type[] { typeof(SPListItem) };
            object[] parametersOfGetProfilePicturePath = { spListItem };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetProfilePicturePath, methodGetProfilePicturePathPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<DisplayProfilePictures, string>(_displayProfilePicturesInstanceFixture, out exception1, parametersOfGetProfilePicturePath);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<DisplayProfilePictures, string>(_displayProfilePicturesInstance, MethodGetProfilePicturePath, parametersOfGetProfilePicturePath, methodGetProfilePicturePathPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetProfilePicturePath.ShouldNotBeNull();
            parametersOfGetProfilePicturePath.Length.ShouldBe(1);
            methodGetProfilePicturePathPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetProfilePicturePath) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_GetProfilePicturePath_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spListItem = CreateType<SPListItem>();
            var methodGetProfilePicturePathPrametersTypes = new Type[] { typeof(SPListItem) };
            object[] parametersOfGetProfilePicturePath = { spListItem };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<DisplayProfilePictures, string>(_displayProfilePicturesInstance, MethodGetProfilePicturePath, parametersOfGetProfilePicturePath, methodGetProfilePicturePathPrametersTypes);

            // Assert
            parametersOfGetProfilePicturePath.ShouldNotBeNull();
            parametersOfGetProfilePicturePath.Length.ShouldBe(1);
            methodGetProfilePicturePathPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetProfilePicturePath) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_GetProfilePicturePath_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetProfilePicturePathPrametersTypes = new Type[] { typeof(SPListItem) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_displayProfilePicturesInstance, MethodGetProfilePicturePath, Fixture, methodGetProfilePicturePathPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetProfilePicturePathPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetProfilePicturePath) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_GetProfilePicturePath_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetProfilePicturePathPrametersTypes = new Type[] { typeof(SPListItem) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_displayProfilePicturesInstance, MethodGetProfilePicturePath, Fixture, methodGetProfilePicturePathPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetProfilePicturePathPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetProfilePicturePath) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_GetProfilePicturePath_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetProfilePicturePath, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_displayProfilePicturesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetProfilePicturePath) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_GetProfilePicturePath_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetProfilePicturePath, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetProfileUser) (Return Type : SPUser) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DisplayProfilePictures_GetProfileUser_Method_Call_Internally(Type[] types)
        {
            var methodGetProfileUserPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_displayProfilePicturesInstance, MethodGetProfileUser, Fixture, methodGetProfileUserPrametersTypes);
        }

        #endregion

        #region Method Call : (GetProfileUser) (Return Type : SPUser) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_GetProfileUser_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var loginName = CreateType<string>();
            var revertSystemAccount = CreateType<bool>();
            var user = CreateType<SPUser>();
            var methodGetProfileUserPrametersTypes = new Type[] { typeof(SPSite), typeof(string), typeof(bool), typeof(SPUser) };
            object[] parametersOfGetProfileUser = { site, loginName, revertSystemAccount, user };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetProfileUser, methodGetProfileUserPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<DisplayProfilePictures, SPUser>(_displayProfilePicturesInstanceFixture, out exception1, parametersOfGetProfileUser);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<DisplayProfilePictures, SPUser>(_displayProfilePicturesInstance, MethodGetProfileUser, parametersOfGetProfileUser, methodGetProfileUserPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetProfileUser.ShouldNotBeNull();
            parametersOfGetProfileUser.Length.ShouldBe(4);
            methodGetProfileUserPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetProfileUser) (Return Type : SPUser) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_GetProfileUser_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var loginName = CreateType<string>();
            var revertSystemAccount = CreateType<bool>();
            var user = CreateType<SPUser>();
            var methodGetProfileUserPrametersTypes = new Type[] { typeof(SPSite), typeof(string), typeof(bool), typeof(SPUser) };
            object[] parametersOfGetProfileUser = { site, loginName, revertSystemAccount, user };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetProfileUser, methodGetProfileUserPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_displayProfilePicturesInstanceFixture, parametersOfGetProfileUser);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetProfileUser.ShouldNotBeNull();
            parametersOfGetProfileUser.Length.ShouldBe(4);
            methodGetProfileUserPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetProfileUser) (Return Type : SPUser) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_GetProfileUser_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var loginName = CreateType<string>();
            var revertSystemAccount = CreateType<bool>();
            var user = CreateType<SPUser>();
            var methodGetProfileUserPrametersTypes = new Type[] { typeof(SPSite), typeof(string), typeof(bool), typeof(SPUser) };
            object[] parametersOfGetProfileUser = { site, loginName, revertSystemAccount, user };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<DisplayProfilePictures, SPUser>(_displayProfilePicturesInstance, MethodGetProfileUser, parametersOfGetProfileUser, methodGetProfileUserPrametersTypes);

            // Assert
            parametersOfGetProfileUser.ShouldNotBeNull();
            parametersOfGetProfileUser.Length.ShouldBe(4);
            methodGetProfileUserPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetProfileUser) (Return Type : SPUser) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_GetProfileUser_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetProfileUserPrametersTypes = new Type[] { typeof(SPSite), typeof(string), typeof(bool), typeof(SPUser) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_displayProfilePicturesInstance, MethodGetProfileUser, Fixture, methodGetProfileUserPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetProfileUserPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetProfileUser) (Return Type : SPUser) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_GetProfileUser_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetProfileUserPrametersTypes = new Type[] { typeof(SPSite), typeof(string), typeof(bool), typeof(SPUser) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_displayProfilePicturesInstance, MethodGetProfileUser, Fixture, methodGetProfileUserPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetProfileUserPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetProfileUser) (Return Type : SPUser) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_GetProfileUser_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetProfileUser, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_displayProfilePicturesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetProfileUser) (Return Type : SPUser) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_GetProfileUser_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetProfileUser, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsSharePointSystemAccount) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DisplayProfilePictures_IsSharePointSystemAccount_Method_Call_Internally(Type[] types)
        {
            var methodIsSharePointSystemAccountPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_displayProfilePicturesInstance, MethodIsSharePointSystemAccount, Fixture, methodIsSharePointSystemAccountPrametersTypes);
        }

        #endregion

        #region Method Call : (IsSharePointSystemAccount) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_IsSharePointSystemAccount_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var loginName = CreateType<string>();
            var methodIsSharePointSystemAccountPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsSharePointSystemAccount = { loginName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsSharePointSystemAccount, methodIsSharePointSystemAccountPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<DisplayProfilePictures, bool>(_displayProfilePicturesInstanceFixture, out exception1, parametersOfIsSharePointSystemAccount);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<DisplayProfilePictures, bool>(_displayProfilePicturesInstance, MethodIsSharePointSystemAccount, parametersOfIsSharePointSystemAccount, methodIsSharePointSystemAccountPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsSharePointSystemAccount.ShouldNotBeNull();
            parametersOfIsSharePointSystemAccount.Length.ShouldBe(1);
            methodIsSharePointSystemAccountPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (IsSharePointSystemAccount) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_IsSharePointSystemAccount_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var loginName = CreateType<string>();
            var methodIsSharePointSystemAccountPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsSharePointSystemAccount = { loginName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsSharePointSystemAccount, methodIsSharePointSystemAccountPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<DisplayProfilePictures, bool>(_displayProfilePicturesInstanceFixture, out exception1, parametersOfIsSharePointSystemAccount);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<DisplayProfilePictures, bool>(_displayProfilePicturesInstance, MethodIsSharePointSystemAccount, parametersOfIsSharePointSystemAccount, methodIsSharePointSystemAccountPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsSharePointSystemAccount.ShouldNotBeNull();
            parametersOfIsSharePointSystemAccount.Length.ShouldBe(1);
            methodIsSharePointSystemAccountPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (IsSharePointSystemAccount) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_IsSharePointSystemAccount_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var loginName = CreateType<string>();
            var methodIsSharePointSystemAccountPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsSharePointSystemAccount = { loginName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodIsSharePointSystemAccount, methodIsSharePointSystemAccountPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_displayProfilePicturesInstanceFixture, parametersOfIsSharePointSystemAccount);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfIsSharePointSystemAccount.ShouldNotBeNull();
            parametersOfIsSharePointSystemAccount.Length.ShouldBe(1);
            methodIsSharePointSystemAccountPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsSharePointSystemAccount) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_IsSharePointSystemAccount_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var loginName = CreateType<string>();
            var methodIsSharePointSystemAccountPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsSharePointSystemAccount = { loginName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<DisplayProfilePictures, bool>(_displayProfilePicturesInstance, MethodIsSharePointSystemAccount, parametersOfIsSharePointSystemAccount, methodIsSharePointSystemAccountPrametersTypes);

            // Assert
            parametersOfIsSharePointSystemAccount.ShouldNotBeNull();
            parametersOfIsSharePointSystemAccount.Length.ShouldBe(1);
            methodIsSharePointSystemAccountPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsSharePointSystemAccount) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_IsSharePointSystemAccount_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsSharePointSystemAccountPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_displayProfilePicturesInstance, MethodIsSharePointSystemAccount, Fixture, methodIsSharePointSystemAccountPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsSharePointSystemAccountPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsSharePointSystemAccount) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_IsSharePointSystemAccount_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsSharePointSystemAccount, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_displayProfilePicturesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (IsSharePointSystemAccount) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_IsSharePointSystemAccount_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodIsSharePointSystemAccount, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetUserProfileManagerClass) (Return Type : Type) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DisplayProfilePictures_GetUserProfileManagerClass_Method_Call_Internally(Type[] types)
        {
            var methodGetUserProfileManagerClassPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_displayProfilePicturesInstance, MethodGetUserProfileManagerClass, Fixture, methodGetUserProfileManagerClassPrametersTypes);
        }

        #endregion

        #region Method Call : (GetUserProfileManagerClass) (Return Type : Type) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_GetUserProfileManagerClass_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetUserProfileManagerClassPrametersTypes = null;
            object[] parametersOfGetUserProfileManagerClass = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetUserProfileManagerClass, methodGetUserProfileManagerClassPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<DisplayProfilePictures, Type>(_displayProfilePicturesInstanceFixture, out exception1, parametersOfGetUserProfileManagerClass);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<DisplayProfilePictures, Type>(_displayProfilePicturesInstance, MethodGetUserProfileManagerClass, parametersOfGetUserProfileManagerClass, methodGetUserProfileManagerClassPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetUserProfileManagerClass.ShouldBeNull();
            methodGetUserProfileManagerClassPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetUserProfileManagerClass) (Return Type : Type) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_GetUserProfileManagerClass_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetUserProfileManagerClassPrametersTypes = null;
            object[] parametersOfGetUserProfileManagerClass = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetUserProfileManagerClass, methodGetUserProfileManagerClassPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_displayProfilePicturesInstanceFixture, parametersOfGetUserProfileManagerClass);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetUserProfileManagerClass.ShouldBeNull();
            methodGetUserProfileManagerClassPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetUserProfileManagerClass) (Return Type : Type) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_GetUserProfileManagerClass_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetUserProfileManagerClassPrametersTypes = null;
            object[] parametersOfGetUserProfileManagerClass = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<DisplayProfilePictures, Type>(_displayProfilePicturesInstance, MethodGetUserProfileManagerClass, parametersOfGetUserProfileManagerClass, methodGetUserProfileManagerClassPrametersTypes);

            // Assert
            parametersOfGetUserProfileManagerClass.ShouldBeNull();
            methodGetUserProfileManagerClassPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetUserProfileManagerClass) (Return Type : Type) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_GetUserProfileManagerClass_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetUserProfileManagerClassPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_displayProfilePicturesInstance, MethodGetUserProfileManagerClass, Fixture, methodGetUserProfileManagerClassPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetUserProfileManagerClassPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetUserProfileManagerClass) (Return Type : Type) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_GetUserProfileManagerClass_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetUserProfileManagerClassPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_displayProfilePicturesInstance, MethodGetUserProfileManagerClass, Fixture, methodGetUserProfileManagerClassPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetUserProfileManagerClassPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetUserProfileManagerClass) (Return Type : Type) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_GetUserProfileManagerClass_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetUserProfileManagerClass, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_displayProfilePicturesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (HasMySite) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DisplayProfilePictures_HasMySite_Method_Call_Internally(Type[] types)
        {
            var methodHasMySitePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_displayProfilePicturesInstance, MethodHasMySite, Fixture, methodHasMySitePrametersTypes);
        }

        #endregion

        #region Method Call : (HasMySite) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_HasMySite_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var userProfileManagerClass = CreateType<Type>();
            var methodHasMySitePrametersTypes = new Type[] { typeof(Type) };
            object[] parametersOfHasMySite = { userProfileManagerClass };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodHasMySite, methodHasMySitePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<DisplayProfilePictures, bool>(_displayProfilePicturesInstanceFixture, out exception1, parametersOfHasMySite);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<DisplayProfilePictures, bool>(_displayProfilePicturesInstance, MethodHasMySite, parametersOfHasMySite, methodHasMySitePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfHasMySite.ShouldNotBeNull();
            parametersOfHasMySite.Length.ShouldBe(1);
            methodHasMySitePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (HasMySite) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_HasMySite_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var userProfileManagerClass = CreateType<Type>();
            var methodHasMySitePrametersTypes = new Type[] { typeof(Type) };
            object[] parametersOfHasMySite = { userProfileManagerClass };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodHasMySite, methodHasMySitePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<DisplayProfilePictures, bool>(_displayProfilePicturesInstanceFixture, out exception1, parametersOfHasMySite);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<DisplayProfilePictures, bool>(_displayProfilePicturesInstance, MethodHasMySite, parametersOfHasMySite, methodHasMySitePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfHasMySite.ShouldNotBeNull();
            parametersOfHasMySite.Length.ShouldBe(1);
            methodHasMySitePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (HasMySite) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_HasMySite_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var userProfileManagerClass = CreateType<Type>();
            var methodHasMySitePrametersTypes = new Type[] { typeof(Type) };
            object[] parametersOfHasMySite = { userProfileManagerClass };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodHasMySite, methodHasMySitePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_displayProfilePicturesInstanceFixture, parametersOfHasMySite);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfHasMySite.ShouldNotBeNull();
            parametersOfHasMySite.Length.ShouldBe(1);
            methodHasMySitePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HasMySite) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_HasMySite_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var userProfileManagerClass = CreateType<Type>();
            var methodHasMySitePrametersTypes = new Type[] { typeof(Type) };
            object[] parametersOfHasMySite = { userProfileManagerClass };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<DisplayProfilePictures, bool>(_displayProfilePicturesInstance, MethodHasMySite, parametersOfHasMySite, methodHasMySitePrametersTypes);

            // Assert
            parametersOfHasMySite.ShouldNotBeNull();
            parametersOfHasMySite.Length.ShouldBe(1);
            methodHasMySitePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HasMySite) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_HasMySite_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodHasMySitePrametersTypes = new Type[] { typeof(Type) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_displayProfilePicturesInstance, MethodHasMySite, Fixture, methodHasMySitePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodHasMySitePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (HasMySite) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_HasMySite_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodHasMySite, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_displayProfilePicturesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (HasMySite) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_DisplayProfilePictures_HasMySite_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodHasMySite, 0);
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
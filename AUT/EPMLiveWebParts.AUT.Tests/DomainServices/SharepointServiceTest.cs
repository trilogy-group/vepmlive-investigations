using System;
using System.Collections.Generic;
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

namespace EPMLiveWebParts
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.SharepointService" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class SharepointServiceTest : AbstractBaseSetupTypedTest<SharepointService>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SharepointService) Initializer

        private const string MethodGetSharepointFilesFromDocumentLibrary = "GetSharepointFilesFromDocumentLibrary";
        private const string MethodGetOdcFileHtml = "GetOdcFileHtml";
        private const string MethodAddFileToLibraryAndOverwrite = "AddFileToLibraryAndOverwrite";
        private Type _sharepointServiceInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private SharepointService _sharepointServiceInstance;
        private SharepointService _sharepointServiceInstanceFixture;

        #region General Initializer : Class (SharepointService) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SharepointService" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _sharepointServiceInstanceType = typeof(SharepointService);
            _sharepointServiceInstanceFixture = Create(true);
            _sharepointServiceInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SharepointService)

        #region General Initializer : Class (SharepointService) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="SharepointService" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetSharepointFilesFromDocumentLibrary, 0)]
        [TestCase(MethodGetOdcFileHtml, 0)]
        [TestCase(MethodAddFileToLibraryAndOverwrite, 0)]
        public void AUT_SharepointService_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_sharepointServiceInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="SharepointService" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_SharepointService_Is_Instance_Present_Test()
        {
            // Assert
            _sharepointServiceInstanceType.ShouldNotBeNull();
            _sharepointServiceInstance.ShouldNotBeNull();
            _sharepointServiceInstanceFixture.ShouldNotBeNull();
            _sharepointServiceInstance.ShouldBeAssignableTo<SharepointService>();
            _sharepointServiceInstanceFixture.ShouldBeAssignableTo<SharepointService>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (SharepointService) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_SharepointService_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            SharepointService instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _sharepointServiceInstanceType.ShouldNotBeNull();
            _sharepointServiceInstance.ShouldNotBeNull();
            _sharepointServiceInstanceFixture.ShouldNotBeNull();
            _sharepointServiceInstance.ShouldBeAssignableTo<SharepointService>();
            _sharepointServiceInstanceFixture.ShouldBeAssignableTo<SharepointService>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="SharepointService" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetSharepointFilesFromDocumentLibrary)]
        [TestCase(MethodGetOdcFileHtml)]
        [TestCase(MethodAddFileToLibraryAndOverwrite)]
        public void AUT_SharepointService_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<SharepointService>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetSharepointFilesFromDocumentLibrary) (Return Type : List<SPFile>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SharepointService_GetSharepointFilesFromDocumentLibrary_Method_Call_Internally(Type[] types)
        {
            var methodGetSharepointFilesFromDocumentLibraryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sharepointServiceInstance, MethodGetSharepointFilesFromDocumentLibrary, Fixture, methodGetSharepointFilesFromDocumentLibraryPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSharepointFilesFromDocumentLibrary) (Return Type : List<SPFile>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SharepointService_GetSharepointFilesFromDocumentLibrary_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var documentLibraryName = CreateType<string>();
            var fileExtension = CreateType<string>();
            var siteUrl = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _sharepointServiceInstance.GetSharepointFilesFromDocumentLibrary(documentLibraryName, fileExtension, siteUrl);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetSharepointFilesFromDocumentLibrary) (Return Type : List<SPFile>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SharepointService_GetSharepointFilesFromDocumentLibrary_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var documentLibraryName = CreateType<string>();
            var fileExtension = CreateType<string>();
            var siteUrl = CreateType<string>();
            var methodGetSharepointFilesFromDocumentLibraryPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            object[] parametersOfGetSharepointFilesFromDocumentLibrary = { documentLibraryName, fileExtension, siteUrl };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetSharepointFilesFromDocumentLibrary, methodGetSharepointFilesFromDocumentLibraryPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<SharepointService, List<SPFile>>(_sharepointServiceInstanceFixture, out exception1, parametersOfGetSharepointFilesFromDocumentLibrary);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<SharepointService, List<SPFile>>(_sharepointServiceInstance, MethodGetSharepointFilesFromDocumentLibrary, parametersOfGetSharepointFilesFromDocumentLibrary, methodGetSharepointFilesFromDocumentLibraryPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetSharepointFilesFromDocumentLibrary.ShouldNotBeNull();
            parametersOfGetSharepointFilesFromDocumentLibrary.Length.ShouldBe(3);
            methodGetSharepointFilesFromDocumentLibraryPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetSharepointFilesFromDocumentLibrary) (Return Type : List<SPFile>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SharepointService_GetSharepointFilesFromDocumentLibrary_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var documentLibraryName = CreateType<string>();
            var fileExtension = CreateType<string>();
            var siteUrl = CreateType<string>();
            var methodGetSharepointFilesFromDocumentLibraryPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            object[] parametersOfGetSharepointFilesFromDocumentLibrary = { documentLibraryName, fileExtension, siteUrl };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<SharepointService, List<SPFile>>(_sharepointServiceInstance, MethodGetSharepointFilesFromDocumentLibrary, parametersOfGetSharepointFilesFromDocumentLibrary, methodGetSharepointFilesFromDocumentLibraryPrametersTypes);

            // Assert
            parametersOfGetSharepointFilesFromDocumentLibrary.ShouldNotBeNull();
            parametersOfGetSharepointFilesFromDocumentLibrary.Length.ShouldBe(3);
            methodGetSharepointFilesFromDocumentLibraryPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSharepointFilesFromDocumentLibrary) (Return Type : List<SPFile>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SharepointService_GetSharepointFilesFromDocumentLibrary_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetSharepointFilesFromDocumentLibraryPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sharepointServiceInstance, MethodGetSharepointFilesFromDocumentLibrary, Fixture, methodGetSharepointFilesFromDocumentLibraryPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetSharepointFilesFromDocumentLibraryPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetSharepointFilesFromDocumentLibrary) (Return Type : List<SPFile>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SharepointService_GetSharepointFilesFromDocumentLibrary_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSharepointFilesFromDocumentLibraryPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sharepointServiceInstance, MethodGetSharepointFilesFromDocumentLibrary, Fixture, methodGetSharepointFilesFromDocumentLibraryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSharepointFilesFromDocumentLibraryPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSharepointFilesFromDocumentLibrary) (Return Type : List<SPFile>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SharepointService_GetSharepointFilesFromDocumentLibrary_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSharepointFilesFromDocumentLibrary, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_sharepointServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSharepointFilesFromDocumentLibrary) (Return Type : List<SPFile>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SharepointService_GetSharepointFilesFromDocumentLibrary_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetSharepointFilesFromDocumentLibrary, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetOdcFileHtml) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SharepointService_GetOdcFileHtml_Method_Call_Internally(Type[] types)
        {
            var methodGetOdcFileHtmlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sharepointServiceInstance, MethodGetOdcFileHtml, Fixture, methodGetOdcFileHtmlPrametersTypes);
        }

        #endregion

        #region Method Call : (GetOdcFileHtml) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SharepointService_GetOdcFileHtml_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var odcFile = CreateType<SPFile>();
            Action executeAction = null;

            // Act
            executeAction = () => _sharepointServiceInstance.GetOdcFileHtml(odcFile);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetOdcFileHtml) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SharepointService_GetOdcFileHtml_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var odcFile = CreateType<SPFile>();
            var methodGetOdcFileHtmlPrametersTypes = new Type[] { typeof(SPFile) };
            object[] parametersOfGetOdcFileHtml = { odcFile };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetOdcFileHtml, methodGetOdcFileHtmlPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<SharepointService, string>(_sharepointServiceInstanceFixture, out exception1, parametersOfGetOdcFileHtml);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<SharepointService, string>(_sharepointServiceInstance, MethodGetOdcFileHtml, parametersOfGetOdcFileHtml, methodGetOdcFileHtmlPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetOdcFileHtml.ShouldNotBeNull();
            parametersOfGetOdcFileHtml.Length.ShouldBe(1);
            methodGetOdcFileHtmlPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetOdcFileHtml) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SharepointService_GetOdcFileHtml_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var odcFile = CreateType<SPFile>();
            var methodGetOdcFileHtmlPrametersTypes = new Type[] { typeof(SPFile) };
            object[] parametersOfGetOdcFileHtml = { odcFile };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<SharepointService, string>(_sharepointServiceInstance, MethodGetOdcFileHtml, parametersOfGetOdcFileHtml, methodGetOdcFileHtmlPrametersTypes);

            // Assert
            parametersOfGetOdcFileHtml.ShouldNotBeNull();
            parametersOfGetOdcFileHtml.Length.ShouldBe(1);
            methodGetOdcFileHtmlPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetOdcFileHtml) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SharepointService_GetOdcFileHtml_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetOdcFileHtmlPrametersTypes = new Type[] { typeof(SPFile) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sharepointServiceInstance, MethodGetOdcFileHtml, Fixture, methodGetOdcFileHtmlPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetOdcFileHtmlPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetOdcFileHtml) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SharepointService_GetOdcFileHtml_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetOdcFileHtmlPrametersTypes = new Type[] { typeof(SPFile) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sharepointServiceInstance, MethodGetOdcFileHtml, Fixture, methodGetOdcFileHtmlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetOdcFileHtmlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetOdcFileHtml) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SharepointService_GetOdcFileHtml_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetOdcFileHtml, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_sharepointServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetOdcFileHtml) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SharepointService_GetOdcFileHtml_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetOdcFileHtml, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddFileToLibraryAndOverwrite) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SharepointService_AddFileToLibraryAndOverwrite_Method_Call_Internally(Type[] types)
        {
            var methodAddFileToLibraryAndOverwritePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sharepointServiceInstance, MethodAddFileToLibraryAndOverwrite, Fixture, methodAddFileToLibraryAndOverwritePrametersTypes);
        }

        #endregion

        #region Method Call : (AddFileToLibraryAndOverwrite) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SharepointService_AddFileToLibraryAndOverwrite_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var file = CreateType<SPFile>();
            var bytes = CreateType<byte[]>();
            Action executeAction = null;

            // Act
            executeAction = () => _sharepointServiceInstance.AddFileToLibraryAndOverwrite(file, bytes);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (AddFileToLibraryAndOverwrite) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SharepointService_AddFileToLibraryAndOverwrite_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var file = CreateType<SPFile>();
            var bytes = CreateType<byte[]>();
            var methodAddFileToLibraryAndOverwritePrametersTypes = new Type[] { typeof(SPFile), typeof(byte[]) };
            object[] parametersOfAddFileToLibraryAndOverwrite = { file, bytes };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddFileToLibraryAndOverwrite, methodAddFileToLibraryAndOverwritePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_sharepointServiceInstanceFixture, parametersOfAddFileToLibraryAndOverwrite);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddFileToLibraryAndOverwrite.ShouldNotBeNull();
            parametersOfAddFileToLibraryAndOverwrite.Length.ShouldBe(2);
            methodAddFileToLibraryAndOverwritePrametersTypes.Length.ShouldBe(2);
            methodAddFileToLibraryAndOverwritePrametersTypes.Length.ShouldBe(parametersOfAddFileToLibraryAndOverwrite.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddFileToLibraryAndOverwrite) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SharepointService_AddFileToLibraryAndOverwrite_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var file = CreateType<SPFile>();
            var bytes = CreateType<byte[]>();
            var methodAddFileToLibraryAndOverwritePrametersTypes = new Type[] { typeof(SPFile), typeof(byte[]) };
            object[] parametersOfAddFileToLibraryAndOverwrite = { file, bytes };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_sharepointServiceInstance, MethodAddFileToLibraryAndOverwrite, parametersOfAddFileToLibraryAndOverwrite, methodAddFileToLibraryAndOverwritePrametersTypes);

            // Assert
            parametersOfAddFileToLibraryAndOverwrite.ShouldNotBeNull();
            parametersOfAddFileToLibraryAndOverwrite.Length.ShouldBe(2);
            methodAddFileToLibraryAndOverwritePrametersTypes.Length.ShouldBe(2);
            methodAddFileToLibraryAndOverwritePrametersTypes.Length.ShouldBe(parametersOfAddFileToLibraryAndOverwrite.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddFileToLibraryAndOverwrite) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SharepointService_AddFileToLibraryAndOverwrite_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddFileToLibraryAndOverwrite, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddFileToLibraryAndOverwrite) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SharepointService_AddFileToLibraryAndOverwrite_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddFileToLibraryAndOverwritePrametersTypes = new Type[] { typeof(SPFile), typeof(byte[]) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sharepointServiceInstance, MethodAddFileToLibraryAndOverwrite, Fixture, methodAddFileToLibraryAndOverwritePrametersTypes);

            // Assert
            methodAddFileToLibraryAndOverwritePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddFileToLibraryAndOverwrite) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SharepointService_AddFileToLibraryAndOverwrite_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddFileToLibraryAndOverwrite, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_sharepointServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
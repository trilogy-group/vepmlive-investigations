using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.UI.WebControls;
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.AutoFixtureSetup;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using EPMLiveCore.ListDefinitions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebPartPages;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using ExtensionMethods = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.ExtensionMethods" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class ExtensionMethodsTest : AbstractBaseSetupTest
    {

        public ExtensionMethodsTest() : base(typeof(ExtensionMethods))
        {}

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ExtensionMethods) Initializer

        private const string MethodCompress = "Compress";
        private const string MethodZip = "Zip";
        private const string MethodUnzip = "Unzip";
        private const string MethodDecodeToBase64 = "DecodeToBase64";
        private const string MethodDecompress = "Decompress";
        private const string MethodEncodeToBase64 = "EncodeToBase64";
        private const string MethodIsGuid = "IsGuid";
        private const string MethodMd5 = "Md5";
        private const string MethodRemoveAccent = "RemoveAccent";
        private const string MethodSha1 = "Sha1";
        private const string MethodSlugify = "Slugify";
        private const string MethodToPrettierName = "ToPrettierName";
        private const string MethodLeft = "Left";
        private const string MethodRight = "Right";
        private const string MethodMid = "Mid";
        private const string MethodToBool = "ToBool";
        private const string MethodToSqlCompliant = "ToSqlCompliant";
        private const string MethodGetContents = "GetContents";
        private const string MethodUpdateContentsAndSave = "UpdateContentsAndSave";
        private const string MethodGetViewFile = "GetViewFile";
        private const string MethodGetListByTemplateId = "GetListByTemplateId";
        private const string MethodSafeServerRelativeUrl = "SafeServerRelativeUrl";
        private const string MethodToTreeList = "ToTreeList";
        private const string MethodSort = "Sort";
        private const string MethodStartOfWeek = "StartOfWeek";
        private const string MethodToFriendlyDate = "ToFriendlyDate";
        private const string MethodToFriendlyDateAndTime = "ToFriendlyDateAndTime";
        private const string MethodToRegionalDateTime = "ToRegionalDateTime";
        private const string MethodToDateTime = "ToDateTime";
        private const string MethodToUnixTime = "ToUnixTime";
        private const string MethodSeconds = "Seconds";
        private const string MethodMinutes = "Minutes";
        private const string MethodHours = "Hours";
        private const string MethodDays = "Days";
        private const string MethodHasItems = "HasItems";
        private const string MethodContainsFieldWithInternalName = "ContainsFieldWithInternalName";
        private const string MethodSpDecompress = "SpDecompress";
        private const string MethodCopyStream = "CopyStream";
        private const string MethodAsDelimitedString = "AsDelimitedString";
        private const string MethodPopulateFromCommaSeparatedString = "PopulateFromCommaSeparatedString";
        private const string MethodGetExtId = "GetExtId";
        private const string MethodGetResourcePoolId = "GetResourcePoolId";
        private const string MethodGetWebPartByTypeName = "GetWebPartByTypeName";
        private const string MethodGetSize = "GetSize";
        private const string MethodGetFields = "GetFields";
        private const string MethodGetTypeSizeArray = "GetTypeSizeArray";
        private const string MethodGetTypeSize = "GetTypeSize";
        private const string MethodIsNonEmptyString = "IsNonEmptyString";
        private const string MethodIsInt = "IsInt";
        private const string MethodIsDateTime = "IsDateTime";
        private const string MethodHas = "Has";
        private const string MethodIs = "Is";
        private const string MethodAdd = "Add";
        private const string MethodRemove = "Remove";
        private const string MethodOlsonName = "OlsonName";
        private const string MethodGetWebTree = "GetWebTree";
        private Type _extensionMethodsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;

        #region General Initializer : Class (ExtensionMethods) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ExtensionMethods" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _extensionMethodsInstanceType = typeof(ExtensionMethods);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ExtensionMethods)

        #region General Initializer : Class (ExtensionMethods) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ExtensionMethods" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodCompress, 0)]
        [TestCase(MethodZip, 0)]
        [TestCase(MethodUnzip, 0)]
        [TestCase(MethodDecodeToBase64, 0)]
        [TestCase(MethodDecompress, 0)]
        [TestCase(MethodEncodeToBase64, 0)]
        [TestCase(MethodIsGuid, 0)]
        [TestCase(MethodMd5, 0)]
        [TestCase(MethodRemoveAccent, 0)]
        [TestCase(MethodSha1, 0)]
        [TestCase(MethodSlugify, 0)]
        [TestCase(MethodToPrettierName, 0)]
        [TestCase(MethodToPrettierName, 1)]
        [TestCase(MethodToPrettierName, 2)]
        [TestCase(MethodToPrettierName, 3)]
        [TestCase(MethodLeft, 0)]
        [TestCase(MethodRight, 0)]
        [TestCase(MethodMid, 0)]
        [TestCase(MethodMid, 1)]
        [TestCase(MethodToBool, 0)]
        [TestCase(MethodToSqlCompliant, 0)]
        [TestCase(MethodGetContents, 0)]
        [TestCase(MethodUpdateContentsAndSave, 0)]
        [TestCase(MethodGetViewFile, 0)]
        [TestCase(MethodGetListByTemplateId, 0)]
        [TestCase(MethodSafeServerRelativeUrl, 0)]
        [TestCase(MethodToTreeList, 0)]
        [TestCase(MethodSort, 0)]
        [TestCase(MethodSort, 1)]
        [TestCase(MethodStartOfWeek, 0)]
        [TestCase(MethodToFriendlyDate, 0)]
        [TestCase(MethodToFriendlyDateAndTime, 0)]
        [TestCase(MethodToFriendlyDateAndTime, 1)]
        [TestCase(MethodToRegionalDateTime, 0)]
        [TestCase(MethodToDateTime, 0)]
        [TestCase(MethodToUnixTime, 0)]
        [TestCase(MethodSeconds, 0)]
        [TestCase(MethodMinutes, 0)]
        [TestCase(MethodHours, 0)]
        [TestCase(MethodDays, 0)]
        [TestCase(MethodHasItems, 0)]
        [TestCase(MethodContainsFieldWithInternalName, 0)]
        [TestCase(MethodSpDecompress, 0)]
        [TestCase(MethodCopyStream, 0)]
        [TestCase(MethodAsDelimitedString, 0)]
        [TestCase(MethodPopulateFromCommaSeparatedString, 0)]
        [TestCase(MethodGetExtId, 0)]
        [TestCase(MethodGetResourcePoolId, 0)]
        [TestCase(MethodGetWebPartByTypeName, 0)]
        [TestCase(MethodSort, 2)]
        [TestCase(MethodGetSize, 0)]
        [TestCase(MethodGetFields, 0)]
        [TestCase(MethodGetTypeSizeArray, 0)]
        [TestCase(MethodGetTypeSize, 0)]
        [TestCase(MethodIsGuid, 1)]
        [TestCase(MethodIsNonEmptyString, 0)]
        [TestCase(MethodIsInt, 0)]
        [TestCase(MethodIsDateTime, 0)]
        [TestCase(MethodOlsonName, 0)]
        [TestCase(MethodGetWebTree, 0)]
        public void AUT_ExtensionMethods_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(null, 
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
        ///     Class (<see cref="ExtensionMethods" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ExtensionMethods_Is_Static_Type_Present_Test()
        {
            // Assert
            _extensionMethodsInstanceType.ShouldNotBeNull();
        }

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="ExtensionMethods" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodCompress)]
        [TestCase(MethodZip)]
        [TestCase(MethodUnzip)]
        [TestCase(MethodDecodeToBase64)]
        [TestCase(MethodDecompress)]
        [TestCase(MethodEncodeToBase64)]
        [TestCase(MethodIsGuid)]
        [TestCase(MethodMd5)]
        [TestCase(MethodRemoveAccent)]
        [TestCase(MethodSha1)]
        [TestCase(MethodSlugify)]
        [TestCase(MethodToPrettierName)]
        [TestCase(MethodLeft)]
        [TestCase(MethodRight)]
        [TestCase(MethodMid)]
        [TestCase(MethodToBool)]
        [TestCase(MethodToSqlCompliant)]
        [TestCase(MethodGetContents)]
        [TestCase(MethodUpdateContentsAndSave)]
        [TestCase(MethodGetViewFile)]
        [TestCase(MethodGetListByTemplateId)]
        [TestCase(MethodSafeServerRelativeUrl)]
        [TestCase(MethodToTreeList)]
        [TestCase(MethodSort)]
        [TestCase(MethodStartOfWeek)]
        [TestCase(MethodToFriendlyDate)]
        [TestCase(MethodToFriendlyDateAndTime)]
        [TestCase(MethodToRegionalDateTime)]
        [TestCase(MethodToDateTime)]
        [TestCase(MethodToUnixTime)]
        [TestCase(MethodSeconds)]
        [TestCase(MethodMinutes)]
        [TestCase(MethodHours)]
        [TestCase(MethodDays)]
        [TestCase(MethodHasItems)]
        [TestCase(MethodContainsFieldWithInternalName)]
        [TestCase(MethodSpDecompress)]
        [TestCase(MethodCopyStream)]
        [TestCase(MethodAsDelimitedString)]
        [TestCase(MethodPopulateFromCommaSeparatedString)]
        [TestCase(MethodGetExtId)]
        [TestCase(MethodGetResourcePoolId)]
        [TestCase(MethodGetWebPartByTypeName)]
        [TestCase(MethodGetSize)]
        [TestCase(MethodGetFields)]
        [TestCase(MethodGetTypeSizeArray)]
        [TestCase(MethodGetTypeSize)]
        [TestCase(MethodIsNonEmptyString)]
        [TestCase(MethodIsInt)]
        [TestCase(MethodIsDateTime)]
        [TestCase(MethodOlsonName)]
        [TestCase(MethodGetWebTree)]
        public void AUT_ExtensionMethods_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(null,
                                                                              _extensionMethodsInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (Compress) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_Compress_Static_Method_Call_Internally(Type[] types)
        {
            var methodCompressPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodCompress, Fixture, methodCompressPrametersTypes);
        }

        #endregion

        #region Method Call : (Compress) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Compress_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var text = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.Compress(text);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Compress) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Compress_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var text = CreateType<string>();
            var methodCompressPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfCompress = { text };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCompress, methodCompressPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfCompress);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCompress.ShouldNotBeNull();
            parametersOfCompress.Length.ShouldBe(1);
            methodCompressPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Compress) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Compress_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var text = CreateType<string>();
            var methodCompressPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfCompress = { text };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodCompress, parametersOfCompress, methodCompressPrametersTypes);

            // Assert
            parametersOfCompress.ShouldNotBeNull();
            parametersOfCompress.Length.ShouldBe(1);
            methodCompressPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Compress) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Compress_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodCompressPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodCompress, Fixture, methodCompressPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodCompressPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Compress) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Compress_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCompressPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodCompress, Fixture, methodCompressPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCompressPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Compress) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Compress_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCompress, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (Compress) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Compress_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCompress, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Zip) (Return Type : byte[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_Zip_Static_Method_Call_Internally(Type[] types)
        {
            var methodZipPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodZip, Fixture, methodZipPrametersTypes);
        }

        #endregion

        #region Method Call : (Zip) (Return Type : byte[]) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Zip_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var text = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.Zip(text);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Zip) (Return Type : byte[]) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Zip_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var text = CreateType<string>();
            var methodZipPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfZip = { text };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodZip, methodZipPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfZip);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfZip.ShouldNotBeNull();
            parametersOfZip.Length.ShouldBe(1);
            methodZipPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Zip) (Return Type : byte[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Zip_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var text = CreateType<string>();
            var methodZipPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfZip = { text };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<byte[]>(null, _extensionMethodsInstanceType, MethodZip, parametersOfZip, methodZipPrametersTypes);

            // Assert
            parametersOfZip.ShouldNotBeNull();
            parametersOfZip.Length.ShouldBe(1);
            methodZipPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Zip) (Return Type : byte[]) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Zip_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodZipPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodZip, Fixture, methodZipPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodZipPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Zip) (Return Type : byte[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Zip_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodZipPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodZip, Fixture, methodZipPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodZipPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Zip) (Return Type : byte[]) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Zip_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodZip, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (Zip) (Return Type : byte[]) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Zip_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodZip, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Unzip) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_Unzip_Static_Method_Call_Internally(Type[] types)
        {
            var methodUnzipPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodUnzip, Fixture, methodUnzipPrametersTypes);
        }

        #endregion

        #region Method Call : (Unzip) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Unzip_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var bytes = CreateType<byte[]>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.Unzip(bytes);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Unzip) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Unzip_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var bytes = CreateType<byte[]>();
            var methodUnzipPrametersTypes = new Type[] { typeof(byte[]) };
            object[] parametersOfUnzip = { bytes };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUnzip, methodUnzipPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodUnzip, Fixture, methodUnzipPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodUnzip, parametersOfUnzip, methodUnzipPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfUnzip);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfUnzip.ShouldNotBeNull();
            parametersOfUnzip.Length.ShouldBe(1);
            methodUnzipPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Unzip) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Unzip_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var bytes = CreateType<byte[]>();
            var methodUnzipPrametersTypes = new Type[] { typeof(byte[]) };
            object[] parametersOfUnzip = { bytes };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodUnzip, parametersOfUnzip, methodUnzipPrametersTypes);

            // Assert
            parametersOfUnzip.ShouldNotBeNull();
            parametersOfUnzip.Length.ShouldBe(1);
            methodUnzipPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Unzip) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Unzip_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodUnzipPrametersTypes = new Type[] { typeof(byte[]) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodUnzip, Fixture, methodUnzipPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodUnzipPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Unzip) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Unzip_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUnzipPrametersTypes = new Type[] { typeof(byte[]) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodUnzip, Fixture, methodUnzipPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUnzipPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Unzip) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Unzip_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUnzip, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Unzip) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Unzip_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUnzip, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DecodeToBase64) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_DecodeToBase64_Static_Method_Call_Internally(Type[] types)
        {
            var methodDecodeToBase64PrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodDecodeToBase64, Fixture, methodDecodeToBase64PrametersTypes);
        }

        #endregion

        #region Method Call : (DecodeToBase64) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_DecodeToBase64_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var value = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.DecodeToBase64(value);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DecodeToBase64) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_DecodeToBase64_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodDecodeToBase64PrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDecodeToBase64 = { value };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDecodeToBase64, methodDecodeToBase64PrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodDecodeToBase64, Fixture, methodDecodeToBase64PrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodDecodeToBase64, parametersOfDecodeToBase64, methodDecodeToBase64PrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfDecodeToBase64);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfDecodeToBase64.ShouldNotBeNull();
            parametersOfDecodeToBase64.Length.ShouldBe(1);
            methodDecodeToBase64PrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DecodeToBase64) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_DecodeToBase64_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodDecodeToBase64PrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDecodeToBase64 = { value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodDecodeToBase64, parametersOfDecodeToBase64, methodDecodeToBase64PrametersTypes);

            // Assert
            parametersOfDecodeToBase64.ShouldNotBeNull();
            parametersOfDecodeToBase64.Length.ShouldBe(1);
            methodDecodeToBase64PrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DecodeToBase64) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_DecodeToBase64_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodDecodeToBase64PrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodDecodeToBase64, Fixture, methodDecodeToBase64PrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodDecodeToBase64PrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DecodeToBase64) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_DecodeToBase64_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDecodeToBase64PrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodDecodeToBase64, Fixture, methodDecodeToBase64PrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDecodeToBase64PrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DecodeToBase64) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_DecodeToBase64_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDecodeToBase64, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DecodeToBase64) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_DecodeToBase64_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDecodeToBase64, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Decompress) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_Decompress_Static_Method_Call_Internally(Type[] types)
        {
            var methodDecompressPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodDecompress, Fixture, methodDecompressPrametersTypes);
        }

        #endregion

        #region Method Call : (Decompress) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Decompress_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var compressedText = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.Decompress(compressedText);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Decompress) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Decompress_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var compressedText = CreateType<string>();
            var methodDecompressPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDecompress = { compressedText };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDecompress, methodDecompressPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodDecompress, Fixture, methodDecompressPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodDecompress, parametersOfDecompress, methodDecompressPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfDecompress);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfDecompress.ShouldNotBeNull();
            parametersOfDecompress.Length.ShouldBe(1);
            methodDecompressPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Decompress) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Decompress_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var compressedText = CreateType<string>();
            var methodDecompressPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDecompress = { compressedText };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodDecompress, parametersOfDecompress, methodDecompressPrametersTypes);

            // Assert
            parametersOfDecompress.ShouldNotBeNull();
            parametersOfDecompress.Length.ShouldBe(1);
            methodDecompressPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Decompress) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Decompress_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodDecompressPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodDecompress, Fixture, methodDecompressPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodDecompressPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Decompress) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Decompress_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDecompressPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodDecompress, Fixture, methodDecompressPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDecompressPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Decompress) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Decompress_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDecompress, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Decompress) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Decompress_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDecompress, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (EncodeToBase64) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_EncodeToBase64_Static_Method_Call_Internally(Type[] types)
        {
            var methodEncodeToBase64PrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodEncodeToBase64, Fixture, methodEncodeToBase64PrametersTypes);
        }

        #endregion

        #region Method Call : (EncodeToBase64) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_EncodeToBase64_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.EncodeToBase64(value);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (EncodeToBase64) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_EncodeToBase64_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodEncodeToBase64PrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfEncodeToBase64 = { value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodEncodeToBase64, methodEncodeToBase64PrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfEncodeToBase64);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfEncodeToBase64.ShouldNotBeNull();
            parametersOfEncodeToBase64.Length.ShouldBe(1);
            methodEncodeToBase64PrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EncodeToBase64) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_EncodeToBase64_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodEncodeToBase64PrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfEncodeToBase64 = { value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodEncodeToBase64, parametersOfEncodeToBase64, methodEncodeToBase64PrametersTypes);

            // Assert
            parametersOfEncodeToBase64.ShouldNotBeNull();
            parametersOfEncodeToBase64.Length.ShouldBe(1);
            methodEncodeToBase64PrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EncodeToBase64) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_EncodeToBase64_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodEncodeToBase64PrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodEncodeToBase64, Fixture, methodEncodeToBase64PrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodEncodeToBase64PrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (EncodeToBase64) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_EncodeToBase64_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodEncodeToBase64PrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodEncodeToBase64, Fixture, methodEncodeToBase64PrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodEncodeToBase64PrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (EncodeToBase64) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_EncodeToBase64_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodEncodeToBase64, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (EncodeToBase64) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_EncodeToBase64_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodEncodeToBase64, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsGuid) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_IsGuid_Static_Method_Call_Internally(Type[] types)
        {
            var methodIsGuidPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodIsGuid, Fixture, methodIsGuidPrametersTypes);
        }

        #endregion

        #region Method Call : (IsGuid) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsGuid_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var possibleGuid = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.IsGuid(possibleGuid);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (IsGuid) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsGuid_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var possibleGuid = CreateType<string>();
            var methodIsGuidPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsGuid = { possibleGuid };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsGuid, methodIsGuidPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodIsGuid, Fixture, methodIsGuidPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<bool>(null, _extensionMethodsInstanceType, MethodIsGuid, parametersOfIsGuid, methodIsGuidPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsGuid.ShouldNotBeNull();
            parametersOfIsGuid.Length.ShouldBe(1);
            methodIsGuidPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(null, _extensionMethodsInstanceType, MethodIsGuid, parametersOfIsGuid, methodIsGuidPrametersTypes));
        }

        #endregion

        #region Method Call : (IsGuid) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsGuid_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var possibleGuid = CreateType<string>();
            var methodIsGuidPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsGuid = { possibleGuid };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodIsGuid, methodIsGuidPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfIsGuid);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfIsGuid.ShouldNotBeNull();
            parametersOfIsGuid.Length.ShouldBe(1);
            methodIsGuidPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsGuid) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsGuid_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var possibleGuid = CreateType<string>();
            var methodIsGuidPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsGuid = { possibleGuid };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(null, _extensionMethodsInstanceType, MethodIsGuid, parametersOfIsGuid, methodIsGuidPrametersTypes);

            // Assert
            parametersOfIsGuid.ShouldNotBeNull();
            parametersOfIsGuid.Length.ShouldBe(1);
            methodIsGuidPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsGuid) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsGuid_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodIsGuidPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodIsGuid, Fixture, methodIsGuidPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodIsGuidPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (IsGuid) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsGuid_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodIsGuidPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodIsGuid, Fixture, methodIsGuidPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodIsGuidPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (IsGuid) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsGuid_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsGuidPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodIsGuid, Fixture, methodIsGuidPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsGuidPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsGuid) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsGuid_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsGuid, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (IsGuid) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsGuid_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodIsGuid, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Md5) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_Md5_Static_Method_Call_Internally(Type[] types)
        {
            var methodMd5PrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodMd5, Fixture, methodMd5PrametersTypes);
        }

        #endregion

        #region Method Call : (Md5) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Md5_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.Md5(value);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Md5) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Md5_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodMd5PrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfMd5 = { value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodMd5, methodMd5PrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfMd5);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfMd5.ShouldNotBeNull();
            parametersOfMd5.Length.ShouldBe(1);
            methodMd5PrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Md5) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Md5_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodMd5PrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfMd5 = { value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodMd5, parametersOfMd5, methodMd5PrametersTypes);

            // Assert
            parametersOfMd5.ShouldNotBeNull();
            parametersOfMd5.Length.ShouldBe(1);
            methodMd5PrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Md5) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Md5_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodMd5PrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodMd5, Fixture, methodMd5PrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodMd5PrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Md5) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Md5_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodMd5PrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodMd5, Fixture, methodMd5PrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodMd5PrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Md5) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Md5_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodMd5, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (Md5) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Md5_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodMd5, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RemoveAccent) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_RemoveAccent_Static_Method_Call_Internally(Type[] types)
        {
            var methodRemoveAccentPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodRemoveAccent, Fixture, methodRemoveAccentPrametersTypes);
        }

        #endregion

        #region Method Call : (RemoveAccent) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_RemoveAccent_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var txt = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.RemoveAccent(txt);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (RemoveAccent) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_RemoveAccent_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var txt = CreateType<string>();
            var methodRemoveAccentPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRemoveAccent = { txt };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRemoveAccent, methodRemoveAccentPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfRemoveAccent);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRemoveAccent.ShouldNotBeNull();
            parametersOfRemoveAccent.Length.ShouldBe(1);
            methodRemoveAccentPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RemoveAccent) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_RemoveAccent_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var txt = CreateType<string>();
            var methodRemoveAccentPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRemoveAccent = { txt };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodRemoveAccent, parametersOfRemoveAccent, methodRemoveAccentPrametersTypes);

            // Assert
            parametersOfRemoveAccent.ShouldNotBeNull();
            parametersOfRemoveAccent.Length.ShouldBe(1);
            methodRemoveAccentPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RemoveAccent) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_RemoveAccent_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodRemoveAccentPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodRemoveAccent, Fixture, methodRemoveAccentPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodRemoveAccentPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (RemoveAccent) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_RemoveAccent_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRemoveAccentPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodRemoveAccent, Fixture, methodRemoveAccentPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRemoveAccentPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RemoveAccent) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_RemoveAccent_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRemoveAccent, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (RemoveAccent) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_RemoveAccent_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRemoveAccent, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Sha1) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_Sha1_Static_Method_Call_Internally(Type[] types)
        {
            var methodSha1PrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodSha1, Fixture, methodSha1PrametersTypes);
        }

        #endregion

        #region Method Call : (Sha1) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Sha1_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.Sha1(value);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Sha1) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Sha1_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodSha1PrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSha1 = { value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSha1, methodSha1PrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfSha1);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSha1.ShouldNotBeNull();
            parametersOfSha1.Length.ShouldBe(1);
            methodSha1PrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Sha1) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Sha1_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodSha1PrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSha1 = { value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodSha1, parametersOfSha1, methodSha1PrametersTypes);

            // Assert
            parametersOfSha1.ShouldNotBeNull();
            parametersOfSha1.Length.ShouldBe(1);
            methodSha1PrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Sha1) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Sha1_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodSha1PrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodSha1, Fixture, methodSha1PrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodSha1PrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Sha1) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Sha1_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSha1PrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodSha1, Fixture, methodSha1PrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSha1PrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Sha1) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Sha1_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSha1, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (Sha1) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Sha1_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSha1, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Slugify) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_Slugify_Static_Method_Call_Internally(Type[] types)
        {
            var methodSlugifyPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodSlugify, Fixture, methodSlugifyPrametersTypes);
        }

        #endregion

        #region Method Call : (Slugify) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Slugify_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var str = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.Slugify(str);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Slugify) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Slugify_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var str = CreateType<string>();
            var methodSlugifyPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSlugify = { str };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSlugify, methodSlugifyPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfSlugify);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSlugify.ShouldNotBeNull();
            parametersOfSlugify.Length.ShouldBe(1);
            methodSlugifyPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Slugify) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Slugify_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var str = CreateType<string>();
            var methodSlugifyPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSlugify = { str };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodSlugify, parametersOfSlugify, methodSlugifyPrametersTypes);

            // Assert
            parametersOfSlugify.ShouldNotBeNull();
            parametersOfSlugify.Length.ShouldBe(1);
            methodSlugifyPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Slugify) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Slugify_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodSlugifyPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodSlugify, Fixture, methodSlugifyPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodSlugifyPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Slugify) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Slugify_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSlugifyPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodSlugify, Fixture, methodSlugifyPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSlugifyPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Slugify) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Slugify_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSlugify, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (Slugify) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Slugify_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSlugify, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ToPrettierName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_ToPrettierName_Static_Method_Call_Internally(Type[] types)
        {
            var methodToPrettierNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToPrettierName, Fixture, methodToPrettierNamePrametersTypes);
        }

        #endregion

        #region Method Call : (ToPrettierName) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToPrettierName_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var internalName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.ToPrettierName(internalName);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ToPrettierName) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToPrettierName_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var internalName = CreateType<string>();
            var methodToPrettierNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfToPrettierName = { internalName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodToPrettierName, methodToPrettierNamePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfToPrettierName);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfToPrettierName.ShouldNotBeNull();
            parametersOfToPrettierName.Length.ShouldBe(1);
            methodToPrettierNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ToPrettierName) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToPrettierName_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var internalName = CreateType<string>();
            var methodToPrettierNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfToPrettierName = { internalName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodToPrettierName, parametersOfToPrettierName, methodToPrettierNamePrametersTypes);

            // Assert
            parametersOfToPrettierName.ShouldNotBeNull();
            parametersOfToPrettierName.Length.ShouldBe(1);
            methodToPrettierNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ToPrettierName) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToPrettierName_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodToPrettierNamePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToPrettierName, Fixture, methodToPrettierNamePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodToPrettierNamePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ToPrettierName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToPrettierName_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodToPrettierNamePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToPrettierName, Fixture, methodToPrettierNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodToPrettierNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ToPrettierName) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToPrettierName_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodToPrettierName, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ToPrettierName) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToPrettierName_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodToPrettierName, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ToPrettierName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_ToPrettierName_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodToPrettierNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToPrettierName, Fixture, methodToPrettierNamePrametersTypes);
        }

        #endregion

        #region Method Call : (ToPrettierName) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToPrettierName_Static_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var internalName = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.ToPrettierName(internalName, spWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ToPrettierName) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToPrettierName_Static_Method_Call_Overloading_Of_1_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var internalName = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            var methodToPrettierNamePrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfToPrettierName = { internalName, spWeb };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodToPrettierName, methodToPrettierNamePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToPrettierName, Fixture, methodToPrettierNamePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodToPrettierName, parametersOfToPrettierName, methodToPrettierNamePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfToPrettierName);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfToPrettierName.ShouldNotBeNull();
            parametersOfToPrettierName.Length.ShouldBe(2);
            methodToPrettierNamePrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ToPrettierName) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToPrettierName_Static_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var internalName = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            var methodToPrettierNamePrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfToPrettierName = { internalName, spWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodToPrettierName, parametersOfToPrettierName, methodToPrettierNamePrametersTypes);

            // Assert
            parametersOfToPrettierName.ShouldNotBeNull();
            parametersOfToPrettierName.Length.ShouldBe(2);
            methodToPrettierNamePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ToPrettierName) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToPrettierName_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodToPrettierNamePrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToPrettierName, Fixture, methodToPrettierNamePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodToPrettierNamePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ToPrettierName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToPrettierName_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodToPrettierNamePrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToPrettierName, Fixture, methodToPrettierNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodToPrettierNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ToPrettierName) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToPrettierName_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodToPrettierName, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ToPrettierName) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToPrettierName_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodToPrettierName, 1);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ToPrettierName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_ToPrettierName_Static_Method_Overloading_Of_2_Call_Internally(Type[] types)
        {
            var methodToPrettierNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToPrettierName, Fixture, methodToPrettierNamePrametersTypes);
        }

        #endregion

        #region Method Call : (ToPrettierName) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToPrettierName_Static_Method_DirectCall_Overloading_Of_2_Throw_Exception_Test()
        {
            // Arrange
            var internalName = CreateType<string>();
            var selectedLists = CreateType<List<string>>();
            var spWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.ToPrettierName(internalName, selectedLists, spWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ToPrettierName) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToPrettierName_Static_Method_Call_Overloading_Of_2_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var internalName = CreateType<string>();
            var selectedLists = CreateType<List<string>>();
            var spWeb = CreateType<SPWeb>();
            var methodToPrettierNamePrametersTypes = new Type[] { typeof(string), typeof(List<string>), typeof(SPWeb) };
            object[] parametersOfToPrettierName = { internalName, selectedLists, spWeb };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodToPrettierName, methodToPrettierNamePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToPrettierName, Fixture, methodToPrettierNamePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodToPrettierName, parametersOfToPrettierName, methodToPrettierNamePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfToPrettierName);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfToPrettierName.ShouldNotBeNull();
            parametersOfToPrettierName.Length.ShouldBe(3);
            methodToPrettierNamePrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ToPrettierName) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToPrettierName_Static_Method_Call_Overloading_Of_2_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var internalName = CreateType<string>();
            var selectedLists = CreateType<List<string>>();
            var spWeb = CreateType<SPWeb>();
            var methodToPrettierNamePrametersTypes = new Type[] { typeof(string), typeof(List<string>), typeof(SPWeb) };
            object[] parametersOfToPrettierName = { internalName, selectedLists, spWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodToPrettierName, parametersOfToPrettierName, methodToPrettierNamePrametersTypes);

            // Assert
            parametersOfToPrettierName.ShouldNotBeNull();
            parametersOfToPrettierName.Length.ShouldBe(3);
            methodToPrettierNamePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ToPrettierName) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToPrettierName_Static_Method_Call_Overloading_Of_2_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodToPrettierNamePrametersTypes = new Type[] { typeof(string), typeof(List<string>), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToPrettierName, Fixture, methodToPrettierNamePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodToPrettierNamePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (ToPrettierName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToPrettierName_Static_Method_Call_Overloading_Of_2_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodToPrettierNamePrametersTypes = new Type[] { typeof(string), typeof(List<string>), typeof(SPWeb) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToPrettierName, Fixture, methodToPrettierNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodToPrettierNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ToPrettierName) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToPrettierName_Static_Method_Call_Overloading_Of_2_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodToPrettierName, 2);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ToPrettierName) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToPrettierName_Static_Method_Call_Overloading_Of_2_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodToPrettierName, 2);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ToPrettierName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_ToPrettierName_Static_Method_Overloading_Of_3_Call_Internally(Type[] types)
        {
            var methodToPrettierNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToPrettierName, Fixture, methodToPrettierNamePrametersTypes);
        }

        #endregion

        #region Method Call : (ToPrettierName) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToPrettierName_Static_Method_DirectCall_Overloading_Of_3_Throw_Exception_Test()
        {
            // Arrange
            var internalName = CreateType<string>();
            var listName = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.ToPrettierName(internalName, listName, spWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ToPrettierName) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToPrettierName_Static_Method_Call_Overloading_Of_3_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var internalName = CreateType<string>();
            var listName = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            var methodToPrettierNamePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(SPWeb) };
            object[] parametersOfToPrettierName = { internalName, listName, spWeb };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodToPrettierName, methodToPrettierNamePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToPrettierName, Fixture, methodToPrettierNamePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodToPrettierName, parametersOfToPrettierName, methodToPrettierNamePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfToPrettierName);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfToPrettierName.ShouldNotBeNull();
            parametersOfToPrettierName.Length.ShouldBe(3);
            methodToPrettierNamePrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ToPrettierName) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToPrettierName_Static_Method_Call_Overloading_Of_3_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var internalName = CreateType<string>();
            var listName = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            var methodToPrettierNamePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(SPWeb) };
            object[] parametersOfToPrettierName = { internalName, listName, spWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodToPrettierName, parametersOfToPrettierName, methodToPrettierNamePrametersTypes);

            // Assert
            parametersOfToPrettierName.ShouldNotBeNull();
            parametersOfToPrettierName.Length.ShouldBe(3);
            methodToPrettierNamePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ToPrettierName) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToPrettierName_Static_Method_Call_Overloading_Of_3_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodToPrettierNamePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToPrettierName, Fixture, methodToPrettierNamePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodToPrettierNamePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (ToPrettierName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToPrettierName_Static_Method_Call_Overloading_Of_3_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodToPrettierNamePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(SPWeb) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToPrettierName, Fixture, methodToPrettierNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodToPrettierNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ToPrettierName) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToPrettierName_Static_Method_Call_Overloading_Of_3_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodToPrettierName, 3);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ToPrettierName) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToPrettierName_Static_Method_Call_Overloading_Of_3_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodToPrettierName, 3);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Left) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_Left_Static_Method_Call_Internally(Type[] types)
        {
            var methodLeftPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodLeft, Fixture, methodLeftPrametersTypes);
        }

        #endregion

        #region Method Call : (Left) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Left_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var param = CreateType<string>();
            var length = CreateType<int>();
            var methodLeftPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfLeft = { param, length };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodLeft, parametersOfLeft, methodLeftPrametersTypes);

            // Assert
            parametersOfLeft.ShouldNotBeNull();
            parametersOfLeft.Length.ShouldBe(2);
            methodLeftPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Left) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Left_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLeftPrametersTypes = new Type[] { typeof(string), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodLeft, Fixture, methodLeftPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodLeftPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Left) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Left_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodLeft, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Right) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_Right_Static_Method_Call_Internally(Type[] types)
        {
            var methodRightPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodRight, Fixture, methodRightPrametersTypes);
        }

        #endregion

        #region Method Call : (Right) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Right_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var param = CreateType<string>();
            var length = CreateType<int>();
            var methodRightPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfRight = { param, length };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodRight, parametersOfRight, methodRightPrametersTypes);

            // Assert
            parametersOfRight.ShouldNotBeNull();
            parametersOfRight.Length.ShouldBe(2);
            methodRightPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion
        
        #region Method Call : (Right) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Right_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRightPrametersTypes = new Type[] { typeof(string), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodRight, Fixture, methodRightPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRightPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Right) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Right_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRight, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Mid) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_Mid_Static_Method_Call_Internally(Type[] types)
        {
            var methodMidPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodMid, Fixture, methodMidPrametersTypes);
        }

        #endregion

        #region Method Call : (Mid) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Mid_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var param = CreateType<string>();
            var startIndex = CreateType<int>();
            var length = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.Mid(param, startIndex, length);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Mid) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Mid_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var param = CreateType<string>();
            var startIndex = CreateType<int>();
            var length = CreateType<int>();
            var methodMidPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(int) };
            object[] parametersOfMid = { param, startIndex, length };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodMid, methodMidPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodMid, Fixture, methodMidPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodMid, parametersOfMid, methodMidPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfMid);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfMid.ShouldNotBeNull();
            parametersOfMid.Length.ShouldBe(3);
            methodMidPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Mid) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Mid_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var param = CreateType<string>();
            var startIndex = CreateType<int>();
            var length = CreateType<int>();
            var methodMidPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(int) };
            object[] parametersOfMid = { param, startIndex, length };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodMid, parametersOfMid, methodMidPrametersTypes);

            // Assert
            parametersOfMid.ShouldNotBeNull();
            parametersOfMid.Length.ShouldBe(3);
            methodMidPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Mid) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Mid_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodMidPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodMid, Fixture, methodMidPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodMidPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (Mid) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Mid_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodMidPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(int) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodMid, Fixture, methodMidPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodMidPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Mid) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Mid_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodMid, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Mid) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Mid_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodMid, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Mid) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_Mid_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodMidPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodMid, Fixture, methodMidPrametersTypes);
        }

        #endregion

        #region Method Call : (Mid) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Mid_Static_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var param = CreateType<string>();
            var startIndex = CreateType<int>();
            var methodMidPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfMid = { param, startIndex };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodMid, parametersOfMid, methodMidPrametersTypes);

            // Assert
            parametersOfMid.ShouldNotBeNull();
            parametersOfMid.Length.ShouldBe(2);
            methodMidPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Mid) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Mid_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodMidPrametersTypes = new Type[] { typeof(string), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodMid, Fixture, methodMidPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodMidPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Mid) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Mid_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodMid, 1);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ToBool) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_ToBool_Static_Method_Call_Internally(Type[] types)
        {
            var methodToBoolPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToBool, Fixture, methodToBoolPrametersTypes);
        }

        #endregion

        #region Method Call : (ToBool) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToBool_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<object>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.ToBool(value);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ToBool) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToBool_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var value = CreateType<object>();
            var methodToBoolPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfToBool = { value };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodToBool, methodToBoolPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToBool, Fixture, methodToBoolPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<bool>(null, _extensionMethodsInstanceType, MethodToBool, parametersOfToBool, methodToBoolPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfToBool.ShouldNotBeNull();
            parametersOfToBool.Length.ShouldBe(1);
            methodToBoolPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(null, _extensionMethodsInstanceType, MethodToBool, parametersOfToBool, methodToBoolPrametersTypes));
        }

        #endregion

        #region Method Call : (ToBool) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToBool_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<object>();
            var methodToBoolPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfToBool = { value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodToBool, methodToBoolPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfToBool);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfToBool.ShouldNotBeNull();
            parametersOfToBool.Length.ShouldBe(1);
            methodToBoolPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ToBool) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToBool_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var value = CreateType<object>();
            var methodToBoolPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfToBool = { value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(null, _extensionMethodsInstanceType, MethodToBool, parametersOfToBool, methodToBoolPrametersTypes);

            // Assert
            parametersOfToBool.ShouldNotBeNull();
            parametersOfToBool.Length.ShouldBe(1);
            methodToBoolPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ToBool) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToBool_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodToBoolPrametersTypes = new Type[] { typeof(object) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToBool, Fixture, methodToBoolPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodToBoolPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ToBool) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToBool_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodToBoolPrametersTypes = new Type[] { typeof(object) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToBool, Fixture, methodToBoolPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodToBoolPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ToBool) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToBool_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodToBoolPrametersTypes = new Type[] { typeof(object) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToBool, Fixture, methodToBoolPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodToBoolPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ToBool) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToBool_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodToBool, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ToBool) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToBool_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodToBool, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ToSqlCompliant) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_ToSqlCompliant_Static_Method_Call_Internally(Type[] types)
        {
            var methodToSqlCompliantPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToSqlCompliant, Fixture, methodToSqlCompliantPrametersTypes);
        }

        #endregion

        #region Method Call : (ToSqlCompliant) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToSqlCompliant_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.ToSqlCompliant(value);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ToSqlCompliant) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToSqlCompliant_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodToSqlCompliantPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfToSqlCompliant = { value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodToSqlCompliant, methodToSqlCompliantPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfToSqlCompliant);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfToSqlCompliant.ShouldNotBeNull();
            parametersOfToSqlCompliant.Length.ShouldBe(1);
            methodToSqlCompliantPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ToSqlCompliant) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToSqlCompliant_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodToSqlCompliantPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfToSqlCompliant = { value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodToSqlCompliant, parametersOfToSqlCompliant, methodToSqlCompliantPrametersTypes);

            // Assert
            parametersOfToSqlCompliant.ShouldNotBeNull();
            parametersOfToSqlCompliant.Length.ShouldBe(1);
            methodToSqlCompliantPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ToSqlCompliant) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToSqlCompliant_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodToSqlCompliantPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToSqlCompliant, Fixture, methodToSqlCompliantPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodToSqlCompliantPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ToSqlCompliant) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToSqlCompliant_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodToSqlCompliantPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToSqlCompliant, Fixture, methodToSqlCompliantPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodToSqlCompliantPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ToSqlCompliant) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToSqlCompliant_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodToSqlCompliant, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ToSqlCompliant) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToSqlCompliant_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodToSqlCompliant, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetContents) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_GetContents_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetContentsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetContents, Fixture, methodGetContentsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetContents) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetContents_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var viewAspxFile = CreateType<SPFile>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.GetContents(viewAspxFile);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetContents) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetContents_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var viewAspxFile = CreateType<SPFile>();
            var methodGetContentsPrametersTypes = new Type[] { typeof(SPFile) };
            object[] parametersOfGetContents = { viewAspxFile };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetContents, methodGetContentsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetContents, Fixture, methodGetContentsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodGetContents, parametersOfGetContents, methodGetContentsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetContents);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetContents.ShouldNotBeNull();
            parametersOfGetContents.Length.ShouldBe(1);
            methodGetContentsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetContents) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetContents_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var viewAspxFile = CreateType<SPFile>();
            var methodGetContentsPrametersTypes = new Type[] { typeof(SPFile) };
            object[] parametersOfGetContents = { viewAspxFile };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodGetContents, parametersOfGetContents, methodGetContentsPrametersTypes);

            // Assert
            parametersOfGetContents.ShouldNotBeNull();
            parametersOfGetContents.Length.ShouldBe(1);
            methodGetContentsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetContents) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetContents_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetContentsPrametersTypes = new Type[] { typeof(SPFile) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetContents, Fixture, methodGetContentsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetContentsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetContents) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetContents_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetContentsPrametersTypes = new Type[] { typeof(SPFile) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetContents, Fixture, methodGetContentsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetContentsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetContents) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetContents_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetContents, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetContents) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetContents_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetContents, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateContentsAndSave) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_UpdateContentsAndSave_Static_Method_Call_Internally(Type[] types)
        {
            var methodUpdateContentsAndSavePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodUpdateContentsAndSave, Fixture, methodUpdateContentsAndSavePrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateContentsAndSave) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_UpdateContentsAndSave_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var file = CreateType<SPFile>();
            var fileContents = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.UpdateContentsAndSave(file, fileContents);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateContentsAndSave) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_UpdateContentsAndSave_Static_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var file = CreateType<SPFile>();
            var fileContents = CreateType<string>();
            var methodUpdateContentsAndSavePrametersTypes = new Type[] { typeof(SPFile), typeof(string) };
            object[] parametersOfUpdateContentsAndSave = { file, fileContents };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateContentsAndSave, methodUpdateContentsAndSavePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfUpdateContentsAndSave);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateContentsAndSave.ShouldNotBeNull();
            parametersOfUpdateContentsAndSave.Length.ShouldBe(2);
            methodUpdateContentsAndSavePrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateContentsAndSave) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_UpdateContentsAndSave_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var file = CreateType<SPFile>();
            var fileContents = CreateType<string>();
            var methodUpdateContentsAndSavePrametersTypes = new Type[] { typeof(SPFile), typeof(string) };
            object[] parametersOfUpdateContentsAndSave = { file, fileContents };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(null, _extensionMethodsInstanceType, MethodUpdateContentsAndSave, parametersOfUpdateContentsAndSave, methodUpdateContentsAndSavePrametersTypes);

            // Assert
            parametersOfUpdateContentsAndSave.ShouldNotBeNull();
            parametersOfUpdateContentsAndSave.Length.ShouldBe(2);
            methodUpdateContentsAndSavePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateContentsAndSave) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_UpdateContentsAndSave_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateContentsAndSave, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateContentsAndSave) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_UpdateContentsAndSave_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateContentsAndSavePrametersTypes = new Type[] { typeof(SPFile), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodUpdateContentsAndSave, Fixture, methodUpdateContentsAndSavePrametersTypes);

            // Assert
            methodUpdateContentsAndSavePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateContentsAndSave) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_UpdateContentsAndSave_Static_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateContentsAndSave, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetViewFile) (Return Type : SPFile) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_GetViewFile_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetViewFilePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetViewFile, Fixture, methodGetViewFilePrametersTypes);
        }

        #endregion

        #region Method Call : (GetViewFile) (Return Type : SPFile) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetViewFile_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var listToCreateViewOn = CreateType<SPList>();
            var view = CreateType<SPView>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.GetViewFile(listToCreateViewOn, view);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetViewFile) (Return Type : SPFile) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetViewFile_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listToCreateViewOn = CreateType<SPList>();
            var view = CreateType<SPView>();
            var methodGetViewFilePrametersTypes = new Type[] { typeof(SPList), typeof(SPView) };
            object[] parametersOfGetViewFile = { listToCreateViewOn, view };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetViewFile, methodGetViewFilePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetViewFile, Fixture, methodGetViewFilePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<SPFile>(null, _extensionMethodsInstanceType, MethodGetViewFile, parametersOfGetViewFile, methodGetViewFilePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetViewFile);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetViewFile.ShouldNotBeNull();
            parametersOfGetViewFile.Length.ShouldBe(2);
            methodGetViewFilePrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetViewFile) (Return Type : SPFile) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetViewFile_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listToCreateViewOn = CreateType<SPList>();
            var view = CreateType<SPView>();
            var methodGetViewFilePrametersTypes = new Type[] { typeof(SPList), typeof(SPView) };
            object[] parametersOfGetViewFile = { listToCreateViewOn, view };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<SPFile>(null, _extensionMethodsInstanceType, MethodGetViewFile, parametersOfGetViewFile, methodGetViewFilePrametersTypes);

            // Assert
            parametersOfGetViewFile.ShouldNotBeNull();
            parametersOfGetViewFile.Length.ShouldBe(2);
            methodGetViewFilePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetViewFile) (Return Type : SPFile) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetViewFile_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetViewFilePrametersTypes = new Type[] { typeof(SPList), typeof(SPView) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetViewFile, Fixture, methodGetViewFilePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetViewFilePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetViewFile) (Return Type : SPFile) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetViewFile_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetViewFilePrametersTypes = new Type[] { typeof(SPList), typeof(SPView) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetViewFile, Fixture, methodGetViewFilePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetViewFilePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetViewFile) (Return Type : SPFile) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetViewFile_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetViewFile, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetViewFile) (Return Type : SPFile) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetViewFile_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetViewFile, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListByTemplateId) (Return Type : IEnumerable<SPList>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_GetListByTemplateId_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetListByTemplateIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetListByTemplateId, Fixture, methodGetListByTemplateIdPrametersTypes);
        }

        #endregion

        #region Method Call : (GetListByTemplateId) (Return Type : IEnumerable<SPList>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetListByTemplateId_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            var templateId = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.GetListByTemplateId(spWeb, templateId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetListByTemplateId) (Return Type : IEnumerable<SPList>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetListByTemplateId_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            var templateId = CreateType<int>();
            var methodGetListByTemplateIdPrametersTypes = new Type[] { typeof(SPWeb), typeof(int) };
            object[] parametersOfGetListByTemplateId = { spWeb, templateId };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListByTemplateId, methodGetListByTemplateIdPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetListByTemplateId, Fixture, methodGetListByTemplateIdPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<IEnumerable<SPList>>(null, _extensionMethodsInstanceType, MethodGetListByTemplateId, parametersOfGetListByTemplateId, methodGetListByTemplateIdPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetListByTemplateId);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetListByTemplateId.ShouldNotBeNull();
            parametersOfGetListByTemplateId.Length.ShouldBe(2);
            methodGetListByTemplateIdPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetListByTemplateId) (Return Type : IEnumerable<SPList>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetListByTemplateId_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            var templateId = CreateType<int>();
            var methodGetListByTemplateIdPrametersTypes = new Type[] { typeof(SPWeb), typeof(int) };
            object[] parametersOfGetListByTemplateId = { spWeb, templateId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<IEnumerable<SPList>>(null, _extensionMethodsInstanceType, MethodGetListByTemplateId, parametersOfGetListByTemplateId, methodGetListByTemplateIdPrametersTypes);

            // Assert
            parametersOfGetListByTemplateId.ShouldNotBeNull();
            parametersOfGetListByTemplateId.Length.ShouldBe(2);
            methodGetListByTemplateIdPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListByTemplateId) (Return Type : IEnumerable<SPList>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetListByTemplateId_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetListByTemplateIdPrametersTypes = new Type[] { typeof(SPWeb), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetListByTemplateId, Fixture, methodGetListByTemplateIdPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetListByTemplateIdPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetListByTemplateId) (Return Type : IEnumerable<SPList>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetListByTemplateId_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetListByTemplateIdPrametersTypes = new Type[] { typeof(SPWeb), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetListByTemplateId, Fixture, methodGetListByTemplateIdPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListByTemplateIdPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListByTemplateId) (Return Type : IEnumerable<SPList>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetListByTemplateId_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListByTemplateId, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListByTemplateId) (Return Type : IEnumerable<SPList>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetListByTemplateId_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetListByTemplateId, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SafeServerRelativeUrl) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_SafeServerRelativeUrl_Static_Method_Call_Internally(Type[] types)
        {
            var methodSafeServerRelativeUrlPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodSafeServerRelativeUrl, Fixture, methodSafeServerRelativeUrlPrametersTypes);
        }

        #endregion

        #region Method Call : (SafeServerRelativeUrl) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_SafeServerRelativeUrl_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.SafeServerRelativeUrl(spWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SafeServerRelativeUrl) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_SafeServerRelativeUrl_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            var methodSafeServerRelativeUrlPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfSafeServerRelativeUrl = { spWeb };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSafeServerRelativeUrl, methodSafeServerRelativeUrlPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodSafeServerRelativeUrl, Fixture, methodSafeServerRelativeUrlPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodSafeServerRelativeUrl, parametersOfSafeServerRelativeUrl, methodSafeServerRelativeUrlPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfSafeServerRelativeUrl);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSafeServerRelativeUrl.ShouldNotBeNull();
            parametersOfSafeServerRelativeUrl.Length.ShouldBe(1);
            methodSafeServerRelativeUrlPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SafeServerRelativeUrl) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_SafeServerRelativeUrl_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            var methodSafeServerRelativeUrlPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfSafeServerRelativeUrl = { spWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodSafeServerRelativeUrl, parametersOfSafeServerRelativeUrl, methodSafeServerRelativeUrlPrametersTypes);

            // Assert
            parametersOfSafeServerRelativeUrl.ShouldNotBeNull();
            parametersOfSafeServerRelativeUrl.Length.ShouldBe(1);
            methodSafeServerRelativeUrlPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SafeServerRelativeUrl) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_SafeServerRelativeUrl_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSafeServerRelativeUrlPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodSafeServerRelativeUrl, Fixture, methodSafeServerRelativeUrlPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSafeServerRelativeUrlPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SafeServerRelativeUrl) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_SafeServerRelativeUrl_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSafeServerRelativeUrlPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodSafeServerRelativeUrl, Fixture, methodSafeServerRelativeUrlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSafeServerRelativeUrlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SafeServerRelativeUrl) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_SafeServerRelativeUrl_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSafeServerRelativeUrl, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SafeServerRelativeUrl) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_SafeServerRelativeUrl_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSafeServerRelativeUrl, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ToTreeList) (Return Type : List<Guid>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_ToTreeList_Static_Method_Call_Internally(Type[] types)
        {
            var methodToTreeListPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToTreeList, Fixture, methodToTreeListPrametersTypes);
        }

        #endregion

        #region Method Call : (ToTreeList) (Return Type : List<Guid>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToTreeList_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.ToTreeList(web);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ToTreeList) (Return Type : List<Guid>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToTreeList_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodToTreeListPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfToTreeList = { web };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodToTreeList, methodToTreeListPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToTreeList, Fixture, methodToTreeListPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<List<Guid>>(null, _extensionMethodsInstanceType, MethodToTreeList, parametersOfToTreeList, methodToTreeListPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfToTreeList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfToTreeList.ShouldNotBeNull();
            parametersOfToTreeList.Length.ShouldBe(1);
            methodToTreeListPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ToTreeList) (Return Type : List<Guid>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToTreeList_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodToTreeListPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfToTreeList = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<List<Guid>>(null, _extensionMethodsInstanceType, MethodToTreeList, parametersOfToTreeList, methodToTreeListPrametersTypes);

            // Assert
            parametersOfToTreeList.ShouldNotBeNull();
            parametersOfToTreeList.Length.ShouldBe(1);
            methodToTreeListPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ToTreeList) (Return Type : List<Guid>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToTreeList_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodToTreeListPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToTreeList, Fixture, methodToTreeListPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodToTreeListPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ToTreeList) (Return Type : List<Guid>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToTreeList_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodToTreeListPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToTreeList, Fixture, methodToTreeListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodToTreeListPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ToTreeList) (Return Type : List<Guid>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToTreeList_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodToTreeList, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ToTreeList) (Return Type : List<Guid>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToTreeList_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodToTreeList, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Sort) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_Sort_Static_Method_Call_Internally(Type[] types)
        {
            var methodSortPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodSort, Fixture, methodSortPrametersTypes);
        }

        #endregion

        #region Method Call : (Sort) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Sort_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var listBox = CreateType<ListBox>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.Sort(listBox);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Sort) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Sort_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var listBox = CreateType<ListBox>();
            var methodSortPrametersTypes = new Type[] { typeof(ListBox) };
            object[] parametersOfSort = { listBox };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSort, methodSortPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfSort);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSort.ShouldNotBeNull();
            parametersOfSort.Length.ShouldBe(1);
            methodSortPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Sort) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Sort_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listBox = CreateType<ListBox>();
            var methodSortPrametersTypes = new Type[] { typeof(ListBox) };
            object[] parametersOfSort = { listBox };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(null, _extensionMethodsInstanceType, MethodSort, parametersOfSort, methodSortPrametersTypes);

            // Assert
            parametersOfSort.ShouldNotBeNull();
            parametersOfSort.Length.ShouldBe(1);
            methodSortPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Sort) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Sort_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSort, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Sort) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Sort_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSortPrametersTypes = new Type[] { typeof(ListBox) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodSort, Fixture, methodSortPrametersTypes);

            // Assert
            methodSortPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Sort) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Sort_Static_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSort, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Sort) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_Sort_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodSortPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodSort, Fixture, methodSortPrametersTypes);
        }

        #endregion

        #region Method Call : (Sort) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Sort_Static_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var listControl = CreateType<ListControl>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.Sort(listControl);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Sort) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Sort_Static_Method_Call_Void_Overloading_Of_1_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var listControl = CreateType<ListControl>();
            var methodSortPrametersTypes = new Type[] { typeof(ListControl) };
            object[] parametersOfSort = { listControl };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSort, methodSortPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfSort);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSort.ShouldNotBeNull();
            parametersOfSort.Length.ShouldBe(1);
            methodSortPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Sort) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Sort_Static_Method_Call_Void_Overloading_Of_1_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listControl = CreateType<ListControl>();
            var methodSortPrametersTypes = new Type[] { typeof(ListControl) };
            object[] parametersOfSort = { listControl };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(null, _extensionMethodsInstanceType, MethodSort, parametersOfSort, methodSortPrametersTypes);

            // Assert
            parametersOfSort.ShouldNotBeNull();
            parametersOfSort.Length.ShouldBe(1);
            methodSortPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Sort) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Sort_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSort, 1);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Sort) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Sort_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSortPrametersTypes = new Type[] { typeof(ListControl) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodSort, Fixture, methodSortPrametersTypes);

            // Assert
            methodSortPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Sort) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Sort_Static_Method_Call_Overloading_Of_1_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSort, 1);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StartOfWeek) (Return Type : DateTime) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_StartOfWeek_Static_Method_Call_Internally(Type[] types)
        {
            var methodStartOfWeekPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodStartOfWeek, Fixture, methodStartOfWeekPrametersTypes);
        }

        #endregion

        #region Method Call : (StartOfWeek) (Return Type : DateTime) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_StartOfWeek_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var dateTime = CreateType<DateTime>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.StartOfWeek(dateTime);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (StartOfWeek) (Return Type : DateTime) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_StartOfWeek_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var dateTime = CreateType<DateTime>();
            var methodStartOfWeekPrametersTypes = new Type[] { typeof(DateTime) };
            object[] parametersOfStartOfWeek = { dateTime };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodStartOfWeek, methodStartOfWeekPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodStartOfWeek, Fixture, methodStartOfWeekPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<DateTime>(null, _extensionMethodsInstanceType, MethodStartOfWeek, parametersOfStartOfWeek, methodStartOfWeekPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            parametersOfStartOfWeek.ShouldNotBeNull();
            parametersOfStartOfWeek.Length.ShouldBe(1);
            methodStartOfWeekPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<DateTime>(null, _extensionMethodsInstanceType, MethodStartOfWeek, parametersOfStartOfWeek, methodStartOfWeekPrametersTypes));
        }

        #endregion

        #region Method Call : (StartOfWeek) (Return Type : DateTime) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_StartOfWeek_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var dateTime = CreateType<DateTime>();
            var methodStartOfWeekPrametersTypes = new Type[] { typeof(DateTime) };
            object[] parametersOfStartOfWeek = { dateTime };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodStartOfWeek, methodStartOfWeekPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfStartOfWeek);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfStartOfWeek.ShouldNotBeNull();
            parametersOfStartOfWeek.Length.ShouldBe(1);
            methodStartOfWeekPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StartOfWeek) (Return Type : DateTime) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_StartOfWeek_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dateTime = CreateType<DateTime>();
            var methodStartOfWeekPrametersTypes = new Type[] { typeof(DateTime) };
            object[] parametersOfStartOfWeek = { dateTime };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<DateTime>(null, _extensionMethodsInstanceType, MethodStartOfWeek, parametersOfStartOfWeek, methodStartOfWeekPrametersTypes);

            // Assert
            parametersOfStartOfWeek.ShouldNotBeNull();
            parametersOfStartOfWeek.Length.ShouldBe(1);
            methodStartOfWeekPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StartOfWeek) (Return Type : DateTime) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_StartOfWeek_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodStartOfWeekPrametersTypes = new Type[] { typeof(DateTime) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodStartOfWeek, Fixture, methodStartOfWeekPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodStartOfWeekPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (StartOfWeek) (Return Type : DateTime) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_StartOfWeek_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodStartOfWeekPrametersTypes = new Type[] { typeof(DateTime) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodStartOfWeek, Fixture, methodStartOfWeekPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodStartOfWeekPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (StartOfWeek) (Return Type : DateTime) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_StartOfWeek_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodStartOfWeek, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (StartOfWeek) (Return Type : DateTime) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_StartOfWeek_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodStartOfWeek, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ToFriendlyDate) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_ToFriendlyDate_Static_Method_Call_Internally(Type[] types)
        {
            var methodToFriendlyDatePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToFriendlyDate, Fixture, methodToFriendlyDatePrametersTypes);
        }

        #endregion

        #region Method Call : (ToFriendlyDate) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToFriendlyDate_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var dateTime = CreateType<DateTime>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.ToFriendlyDate(dateTime);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ToFriendlyDate) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToFriendlyDate_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var dateTime = CreateType<DateTime>();
            var methodToFriendlyDatePrametersTypes = new Type[] { typeof(DateTime) };
            object[] parametersOfToFriendlyDate = { dateTime };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodToFriendlyDate, methodToFriendlyDatePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfToFriendlyDate);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfToFriendlyDate.ShouldNotBeNull();
            parametersOfToFriendlyDate.Length.ShouldBe(1);
            methodToFriendlyDatePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ToFriendlyDate) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToFriendlyDate_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dateTime = CreateType<DateTime>();
            var methodToFriendlyDatePrametersTypes = new Type[] { typeof(DateTime) };
            object[] parametersOfToFriendlyDate = { dateTime };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodToFriendlyDate, parametersOfToFriendlyDate, methodToFriendlyDatePrametersTypes);

            // Assert
            parametersOfToFriendlyDate.ShouldNotBeNull();
            parametersOfToFriendlyDate.Length.ShouldBe(1);
            methodToFriendlyDatePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ToFriendlyDate) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToFriendlyDate_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodToFriendlyDatePrametersTypes = new Type[] { typeof(DateTime) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToFriendlyDate, Fixture, methodToFriendlyDatePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodToFriendlyDatePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ToFriendlyDate) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToFriendlyDate_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodToFriendlyDatePrametersTypes = new Type[] { typeof(DateTime) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToFriendlyDate, Fixture, methodToFriendlyDatePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodToFriendlyDatePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ToFriendlyDate) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToFriendlyDate_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodToFriendlyDate, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ToFriendlyDate) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToFriendlyDate_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodToFriendlyDate, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ToFriendlyDateAndTime) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_ToFriendlyDateAndTime_Static_Method_Call_Internally(Type[] types)
        {
            var methodToFriendlyDateAndTimePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToFriendlyDateAndTime, Fixture, methodToFriendlyDateAndTimePrametersTypes);
        }

        #endregion

        #region Method Call : (ToFriendlyDateAndTime) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToFriendlyDateAndTime_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var dateTime = CreateType<DateTime>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.ToFriendlyDateAndTime(dateTime);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ToFriendlyDateAndTime) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToFriendlyDateAndTime_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var dateTime = CreateType<DateTime>();
            var methodToFriendlyDateAndTimePrametersTypes = new Type[] { typeof(DateTime) };
            object[] parametersOfToFriendlyDateAndTime = { dateTime };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodToFriendlyDateAndTime, methodToFriendlyDateAndTimePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfToFriendlyDateAndTime);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfToFriendlyDateAndTime.ShouldNotBeNull();
            parametersOfToFriendlyDateAndTime.Length.ShouldBe(1);
            methodToFriendlyDateAndTimePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ToFriendlyDateAndTime) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToFriendlyDateAndTime_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dateTime = CreateType<DateTime>();
            var methodToFriendlyDateAndTimePrametersTypes = new Type[] { typeof(DateTime) };
            object[] parametersOfToFriendlyDateAndTime = { dateTime };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodToFriendlyDateAndTime, parametersOfToFriendlyDateAndTime, methodToFriendlyDateAndTimePrametersTypes);

            // Assert
            parametersOfToFriendlyDateAndTime.ShouldNotBeNull();
            parametersOfToFriendlyDateAndTime.Length.ShouldBe(1);
            methodToFriendlyDateAndTimePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ToFriendlyDateAndTime) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToFriendlyDateAndTime_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodToFriendlyDateAndTimePrametersTypes = new Type[] { typeof(DateTime) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToFriendlyDateAndTime, Fixture, methodToFriendlyDateAndTimePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodToFriendlyDateAndTimePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ToFriendlyDateAndTime) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToFriendlyDateAndTime_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodToFriendlyDateAndTimePrametersTypes = new Type[] { typeof(DateTime) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToFriendlyDateAndTime, Fixture, methodToFriendlyDateAndTimePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodToFriendlyDateAndTimePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ToFriendlyDateAndTime) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToFriendlyDateAndTime_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodToFriendlyDateAndTime, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ToFriendlyDateAndTime) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToFriendlyDateAndTime_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodToFriendlyDateAndTime, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ToFriendlyDateAndTime) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_ToFriendlyDateAndTime_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodToFriendlyDateAndTimePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToFriendlyDateAndTime, Fixture, methodToFriendlyDateAndTimePrametersTypes);
        }

        #endregion

        #region Method Call : (ToFriendlyDateAndTime) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToFriendlyDateAndTime_Static_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var dateTime = CreateType<DateTime>();
            var web = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.ToFriendlyDateAndTime(dateTime, web);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ToFriendlyDateAndTime) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToFriendlyDateAndTime_Static_Method_Call_Overloading_Of_1_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var dateTime = CreateType<DateTime>();
            var web = CreateType<SPWeb>();
            var methodToFriendlyDateAndTimePrametersTypes = new Type[] { typeof(DateTime), typeof(SPWeb) };
            object[] parametersOfToFriendlyDateAndTime = { dateTime, web };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodToFriendlyDateAndTime, methodToFriendlyDateAndTimePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToFriendlyDateAndTime, Fixture, methodToFriendlyDateAndTimePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodToFriendlyDateAndTime, parametersOfToFriendlyDateAndTime, methodToFriendlyDateAndTimePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfToFriendlyDateAndTime);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfToFriendlyDateAndTime.ShouldNotBeNull();
            parametersOfToFriendlyDateAndTime.Length.ShouldBe(2);
            methodToFriendlyDateAndTimePrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ToFriendlyDateAndTime) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToFriendlyDateAndTime_Static_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dateTime = CreateType<DateTime>();
            var web = CreateType<SPWeb>();
            var methodToFriendlyDateAndTimePrametersTypes = new Type[] { typeof(DateTime), typeof(SPWeb) };
            object[] parametersOfToFriendlyDateAndTime = { dateTime, web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodToFriendlyDateAndTime, parametersOfToFriendlyDateAndTime, methodToFriendlyDateAndTimePrametersTypes);

            // Assert
            parametersOfToFriendlyDateAndTime.ShouldNotBeNull();
            parametersOfToFriendlyDateAndTime.Length.ShouldBe(2);
            methodToFriendlyDateAndTimePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ToFriendlyDateAndTime) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToFriendlyDateAndTime_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodToFriendlyDateAndTimePrametersTypes = new Type[] { typeof(DateTime), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToFriendlyDateAndTime, Fixture, methodToFriendlyDateAndTimePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodToFriendlyDateAndTimePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ToFriendlyDateAndTime) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToFriendlyDateAndTime_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodToFriendlyDateAndTimePrametersTypes = new Type[] { typeof(DateTime), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToFriendlyDateAndTime, Fixture, methodToFriendlyDateAndTimePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodToFriendlyDateAndTimePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ToFriendlyDateAndTime) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToFriendlyDateAndTime_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodToFriendlyDateAndTime, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ToFriendlyDateAndTime) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToFriendlyDateAndTime_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodToFriendlyDateAndTime, 1);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ToRegionalDateTime) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_ToRegionalDateTime_Static_Method_Call_Internally(Type[] types)
        {
            var methodToRegionalDateTimePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToRegionalDateTime, Fixture, methodToRegionalDateTimePrametersTypes);
        }

        #endregion

        #region Method Call : (ToRegionalDateTime) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToRegionalDateTime_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var dateTime = CreateType<DateTime>();
            var spWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.ToRegionalDateTime(dateTime, spWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ToRegionalDateTime) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToRegionalDateTime_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var dateTime = CreateType<DateTime>();
            var spWeb = CreateType<SPWeb>();
            var methodToRegionalDateTimePrametersTypes = new Type[] { typeof(DateTime), typeof(SPWeb) };
            object[] parametersOfToRegionalDateTime = { dateTime, spWeb };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodToRegionalDateTime, methodToRegionalDateTimePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToRegionalDateTime, Fixture, methodToRegionalDateTimePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodToRegionalDateTime, parametersOfToRegionalDateTime, methodToRegionalDateTimePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfToRegionalDateTime);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfToRegionalDateTime.ShouldNotBeNull();
            parametersOfToRegionalDateTime.Length.ShouldBe(2);
            methodToRegionalDateTimePrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ToRegionalDateTime) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToRegionalDateTime_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dateTime = CreateType<DateTime>();
            var spWeb = CreateType<SPWeb>();
            var methodToRegionalDateTimePrametersTypes = new Type[] { typeof(DateTime), typeof(SPWeb) };
            object[] parametersOfToRegionalDateTime = { dateTime, spWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodToRegionalDateTime, parametersOfToRegionalDateTime, methodToRegionalDateTimePrametersTypes);

            // Assert
            parametersOfToRegionalDateTime.ShouldNotBeNull();
            parametersOfToRegionalDateTime.Length.ShouldBe(2);
            methodToRegionalDateTimePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ToRegionalDateTime) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToRegionalDateTime_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodToRegionalDateTimePrametersTypes = new Type[] { typeof(DateTime), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToRegionalDateTime, Fixture, methodToRegionalDateTimePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodToRegionalDateTimePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ToRegionalDateTime) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToRegionalDateTime_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodToRegionalDateTimePrametersTypes = new Type[] { typeof(DateTime), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToRegionalDateTime, Fixture, methodToRegionalDateTimePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodToRegionalDateTimePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ToRegionalDateTime) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToRegionalDateTime_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodToRegionalDateTime, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ToRegionalDateTime) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToRegionalDateTime_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodToRegionalDateTime, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ToDateTime) (Return Type : DateTime) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_ToDateTime_Static_Method_Call_Internally(Type[] types)
        {
            var methodToDateTimePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToDateTime, Fixture, methodToDateTimePrametersTypes);
        }

        #endregion

        #region Method Call : (ToDateTime) (Return Type : DateTime) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToDateTime_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var unixTime = CreateType<long>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.ToDateTime(unixTime);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ToDateTime) (Return Type : DateTime) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToDateTime_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var unixTime = CreateType<long>();
            var methodToDateTimePrametersTypes = new Type[] { typeof(long) };
            object[] parametersOfToDateTime = { unixTime };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodToDateTime, methodToDateTimePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToDateTime, Fixture, methodToDateTimePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<DateTime>(null, _extensionMethodsInstanceType, MethodToDateTime, parametersOfToDateTime, methodToDateTimePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            parametersOfToDateTime.ShouldNotBeNull();
            parametersOfToDateTime.Length.ShouldBe(1);
            methodToDateTimePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<DateTime>(null, _extensionMethodsInstanceType, MethodToDateTime, parametersOfToDateTime, methodToDateTimePrametersTypes));
        }

        #endregion

        #region Method Call : (ToDateTime) (Return Type : DateTime) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToDateTime_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var unixTime = CreateType<long>();
            var methodToDateTimePrametersTypes = new Type[] { typeof(long) };
            object[] parametersOfToDateTime = { unixTime };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodToDateTime, methodToDateTimePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfToDateTime);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfToDateTime.ShouldNotBeNull();
            parametersOfToDateTime.Length.ShouldBe(1);
            methodToDateTimePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ToDateTime) (Return Type : DateTime) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToDateTime_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var unixTime = CreateType<long>();
            var methodToDateTimePrametersTypes = new Type[] { typeof(long) };
            object[] parametersOfToDateTime = { unixTime };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<DateTime>(null, _extensionMethodsInstanceType, MethodToDateTime, parametersOfToDateTime, methodToDateTimePrametersTypes);

            // Assert
            parametersOfToDateTime.ShouldNotBeNull();
            parametersOfToDateTime.Length.ShouldBe(1);
            methodToDateTimePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ToDateTime) (Return Type : DateTime) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToDateTime_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodToDateTimePrametersTypes = new Type[] { typeof(long) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToDateTime, Fixture, methodToDateTimePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodToDateTimePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ToDateTime) (Return Type : DateTime) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToDateTime_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodToDateTimePrametersTypes = new Type[] { typeof(long) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToDateTime, Fixture, methodToDateTimePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodToDateTimePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ToDateTime) (Return Type : DateTime) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToDateTime_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodToDateTime, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ToDateTime) (Return Type : DateTime) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToDateTime_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodToDateTime, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ToUnixTime) (Return Type : long) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_ToUnixTime_Static_Method_Call_Internally(Type[] types)
        {
            var methodToUnixTimePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToUnixTime, Fixture, methodToUnixTimePrametersTypes);
        }

        #endregion

        #region Method Call : (ToUnixTime) (Return Type : long) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToUnixTime_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var dateTime = CreateType<DateTime>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.ToUnixTime(dateTime);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ToUnixTime) (Return Type : long) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToUnixTime_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var dateTime = CreateType<DateTime>();
            var methodToUnixTimePrametersTypes = new Type[] { typeof(DateTime) };
            object[] parametersOfToUnixTime = { dateTime };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodToUnixTime, methodToUnixTimePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfToUnixTime);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfToUnixTime.ShouldNotBeNull();
            parametersOfToUnixTime.Length.ShouldBe(1);
            methodToUnixTimePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ToUnixTime) (Return Type : long) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToUnixTime_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dateTime = CreateType<DateTime>();
            var methodToUnixTimePrametersTypes = new Type[] { typeof(DateTime) };
            object[] parametersOfToUnixTime = { dateTime };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<long>(null, _extensionMethodsInstanceType, MethodToUnixTime, parametersOfToUnixTime, methodToUnixTimePrametersTypes);

            // Assert
            parametersOfToUnixTime.ShouldNotBeNull();
            parametersOfToUnixTime.Length.ShouldBe(1);
            methodToUnixTimePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ToUnixTime) (Return Type : long) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToUnixTime_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodToUnixTimePrametersTypes = new Type[] { typeof(DateTime) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToUnixTime, Fixture, methodToUnixTimePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodToUnixTimePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ToUnixTime) (Return Type : long) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToUnixTime_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodToUnixTimePrametersTypes = new Type[] { typeof(DateTime) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToUnixTime, Fixture, methodToUnixTimePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodToUnixTimePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ToUnixTime) (Return Type : long) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToUnixTime_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodToUnixTimePrametersTypes = new Type[] { typeof(DateTime) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToUnixTime, Fixture, methodToUnixTimePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodToUnixTimePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ToUnixTime) (Return Type : long) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToUnixTime_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodToUnixTime, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ToUnixTime) (Return Type : long) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToUnixTime_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodToUnixTime, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Seconds) (Return Type : TimeSpan) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_Seconds_Static_Method_Call_Internally(Type[] types)
        {
            var methodSecondsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodSeconds, Fixture, methodSecondsPrametersTypes);
        }

        #endregion

        #region Method Call : (Seconds) (Return Type : TimeSpan) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Seconds_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.Seconds(value);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Seconds) (Return Type : TimeSpan) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Seconds_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<int>();
            var methodSecondsPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfSeconds = { value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSeconds, methodSecondsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfSeconds);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSeconds.ShouldNotBeNull();
            parametersOfSeconds.Length.ShouldBe(1);
            methodSecondsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Seconds) (Return Type : TimeSpan) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Seconds_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var value = CreateType<int>();
            var methodSecondsPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfSeconds = { value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<TimeSpan>(null, _extensionMethodsInstanceType, MethodSeconds, parametersOfSeconds, methodSecondsPrametersTypes);

            // Assert
            parametersOfSeconds.ShouldNotBeNull();
            parametersOfSeconds.Length.ShouldBe(1);
            methodSecondsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Seconds) (Return Type : TimeSpan) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Seconds_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodSecondsPrametersTypes = new Type[] { typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodSeconds, Fixture, methodSecondsPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodSecondsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Seconds) (Return Type : TimeSpan) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Seconds_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSecondsPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodSeconds, Fixture, methodSecondsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSecondsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Seconds) (Return Type : TimeSpan) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Seconds_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSeconds, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (Seconds) (Return Type : TimeSpan) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Seconds_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSeconds, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Minutes) (Return Type : TimeSpan) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_Minutes_Static_Method_Call_Internally(Type[] types)
        {
            var methodMinutesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodMinutes, Fixture, methodMinutesPrametersTypes);
        }

        #endregion

        #region Method Call : (Minutes) (Return Type : TimeSpan) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Minutes_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.Minutes(value);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Minutes) (Return Type : TimeSpan) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Minutes_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<int>();
            var methodMinutesPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfMinutes = { value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodMinutes, methodMinutesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfMinutes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfMinutes.ShouldNotBeNull();
            parametersOfMinutes.Length.ShouldBe(1);
            methodMinutesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Minutes) (Return Type : TimeSpan) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Minutes_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var value = CreateType<int>();
            var methodMinutesPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfMinutes = { value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<TimeSpan>(null, _extensionMethodsInstanceType, MethodMinutes, parametersOfMinutes, methodMinutesPrametersTypes);

            // Assert
            parametersOfMinutes.ShouldNotBeNull();
            parametersOfMinutes.Length.ShouldBe(1);
            methodMinutesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Minutes) (Return Type : TimeSpan) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Minutes_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodMinutesPrametersTypes = new Type[] { typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodMinutes, Fixture, methodMinutesPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodMinutesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Minutes) (Return Type : TimeSpan) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Minutes_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodMinutesPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodMinutes, Fixture, methodMinutesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodMinutesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Minutes) (Return Type : TimeSpan) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Minutes_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodMinutes, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (Minutes) (Return Type : TimeSpan) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Minutes_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodMinutes, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Hours) (Return Type : TimeSpan) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_Hours_Static_Method_Call_Internally(Type[] types)
        {
            var methodHoursPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodHours, Fixture, methodHoursPrametersTypes);
        }

        #endregion

        #region Method Call : (Hours) (Return Type : TimeSpan) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Hours_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.Hours(value);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Hours) (Return Type : TimeSpan) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Hours_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<int>();
            var methodHoursPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfHours = { value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodHours, methodHoursPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfHours);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfHours.ShouldNotBeNull();
            parametersOfHours.Length.ShouldBe(1);
            methodHoursPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Hours) (Return Type : TimeSpan) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Hours_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var value = CreateType<int>();
            var methodHoursPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfHours = { value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<TimeSpan>(null, _extensionMethodsInstanceType, MethodHours, parametersOfHours, methodHoursPrametersTypes);

            // Assert
            parametersOfHours.ShouldNotBeNull();
            parametersOfHours.Length.ShouldBe(1);
            methodHoursPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Hours) (Return Type : TimeSpan) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Hours_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodHoursPrametersTypes = new Type[] { typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodHours, Fixture, methodHoursPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodHoursPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Hours) (Return Type : TimeSpan) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Hours_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodHoursPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodHours, Fixture, methodHoursPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodHoursPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Hours) (Return Type : TimeSpan) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Hours_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodHours, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (Hours) (Return Type : TimeSpan) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Hours_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodHours, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Days) (Return Type : TimeSpan) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_Days_Static_Method_Call_Internally(Type[] types)
        {
            var methodDaysPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodDays, Fixture, methodDaysPrametersTypes);
        }

        #endregion

        #region Method Call : (Days) (Return Type : TimeSpan) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Days_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.Days(value);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Days) (Return Type : TimeSpan) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Days_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<int>();
            var methodDaysPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfDays = { value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDays, methodDaysPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfDays);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDays.ShouldNotBeNull();
            parametersOfDays.Length.ShouldBe(1);
            methodDaysPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Days) (Return Type : TimeSpan) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Days_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var value = CreateType<int>();
            var methodDaysPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfDays = { value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<TimeSpan>(null, _extensionMethodsInstanceType, MethodDays, parametersOfDays, methodDaysPrametersTypes);

            // Assert
            parametersOfDays.ShouldNotBeNull();
            parametersOfDays.Length.ShouldBe(1);
            methodDaysPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Days) (Return Type : TimeSpan) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Days_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodDaysPrametersTypes = new Type[] { typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodDays, Fixture, methodDaysPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodDaysPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Days) (Return Type : TimeSpan) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Days_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDaysPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodDays, Fixture, methodDaysPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDaysPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Days) (Return Type : TimeSpan) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Days_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDays, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (Days) (Return Type : TimeSpan) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Days_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDays, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (HasItems) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_HasItems_Static_Method_Call_Internally(Type[] types)
        {
            var methodHasItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodHasItems, Fixture, methodHasItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (HasItems) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_HasItems_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var spListItemCollection = CreateType<SPListItemCollection>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.HasItems(spListItemCollection);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (HasItems) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_HasItems_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var spListItemCollection = CreateType<SPListItemCollection>();
            var methodHasItemsPrametersTypes = new Type[] { typeof(SPListItemCollection) };
            object[] parametersOfHasItems = { spListItemCollection };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodHasItems, methodHasItemsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodHasItems, Fixture, methodHasItemsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<bool>(null, _extensionMethodsInstanceType, MethodHasItems, parametersOfHasItems, methodHasItemsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfHasItems.ShouldNotBeNull();
            parametersOfHasItems.Length.ShouldBe(1);
            methodHasItemsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(null, _extensionMethodsInstanceType, MethodHasItems, parametersOfHasItems, methodHasItemsPrametersTypes));
        }

        #endregion

        #region Method Call : (HasItems) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_HasItems_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var spListItemCollection = CreateType<SPListItemCollection>();
            var methodHasItemsPrametersTypes = new Type[] { typeof(SPListItemCollection) };
            object[] parametersOfHasItems = { spListItemCollection };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodHasItems, methodHasItemsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfHasItems);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfHasItems.ShouldNotBeNull();
            parametersOfHasItems.Length.ShouldBe(1);
            methodHasItemsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HasItems) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_HasItems_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spListItemCollection = CreateType<SPListItemCollection>();
            var methodHasItemsPrametersTypes = new Type[] { typeof(SPListItemCollection) };
            object[] parametersOfHasItems = { spListItemCollection };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(null, _extensionMethodsInstanceType, MethodHasItems, parametersOfHasItems, methodHasItemsPrametersTypes);

            // Assert
            parametersOfHasItems.ShouldNotBeNull();
            parametersOfHasItems.Length.ShouldBe(1);
            methodHasItemsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HasItems) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_HasItems_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodHasItemsPrametersTypes = new Type[] { typeof(SPListItemCollection) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodHasItems, Fixture, methodHasItemsPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodHasItemsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (HasItems) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_HasItems_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodHasItemsPrametersTypes = new Type[] { typeof(SPListItemCollection) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodHasItems, Fixture, methodHasItemsPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodHasItemsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (HasItems) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_HasItems_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodHasItemsPrametersTypes = new Type[] { typeof(SPListItemCollection) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodHasItems, Fixture, methodHasItemsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodHasItemsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (HasItems) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_HasItems_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodHasItems, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (HasItems) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_HasItems_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodHasItems, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ContainsFieldWithInternalName) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_ContainsFieldWithInternalName_Static_Method_Call_Internally(Type[] types)
        {
            var methodContainsFieldWithInternalNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodContainsFieldWithInternalName, Fixture, methodContainsFieldWithInternalNamePrametersTypes);
        }

        #endregion

        #region Method Call : (ContainsFieldWithInternalName) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ContainsFieldWithInternalName_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var spFieldCollection = CreateType<SPFieldCollection>();
            var spFieldInternalName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.ContainsFieldWithInternalName(spFieldCollection, spFieldInternalName);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ContainsFieldWithInternalName) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ContainsFieldWithInternalName_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var spFieldCollection = CreateType<SPFieldCollection>();
            var spFieldInternalName = CreateType<string>();
            var methodContainsFieldWithInternalNamePrametersTypes = new Type[] { typeof(SPFieldCollection), typeof(string) };
            object[] parametersOfContainsFieldWithInternalName = { spFieldCollection, spFieldInternalName };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodContainsFieldWithInternalName, methodContainsFieldWithInternalNamePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodContainsFieldWithInternalName, Fixture, methodContainsFieldWithInternalNamePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<bool>(null, _extensionMethodsInstanceType, MethodContainsFieldWithInternalName, parametersOfContainsFieldWithInternalName, methodContainsFieldWithInternalNamePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfContainsFieldWithInternalName.ShouldNotBeNull();
            parametersOfContainsFieldWithInternalName.Length.ShouldBe(2);
            methodContainsFieldWithInternalNamePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(null, _extensionMethodsInstanceType, MethodContainsFieldWithInternalName, parametersOfContainsFieldWithInternalName, methodContainsFieldWithInternalNamePrametersTypes));
        }

        #endregion

        #region Method Call : (ContainsFieldWithInternalName) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ContainsFieldWithInternalName_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var spFieldCollection = CreateType<SPFieldCollection>();
            var spFieldInternalName = CreateType<string>();
            var methodContainsFieldWithInternalNamePrametersTypes = new Type[] { typeof(SPFieldCollection), typeof(string) };
            object[] parametersOfContainsFieldWithInternalName = { spFieldCollection, spFieldInternalName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodContainsFieldWithInternalName, methodContainsFieldWithInternalNamePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfContainsFieldWithInternalName);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfContainsFieldWithInternalName.ShouldNotBeNull();
            parametersOfContainsFieldWithInternalName.Length.ShouldBe(2);
            methodContainsFieldWithInternalNamePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ContainsFieldWithInternalName) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ContainsFieldWithInternalName_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spFieldCollection = CreateType<SPFieldCollection>();
            var spFieldInternalName = CreateType<string>();
            var methodContainsFieldWithInternalNamePrametersTypes = new Type[] { typeof(SPFieldCollection), typeof(string) };
            object[] parametersOfContainsFieldWithInternalName = { spFieldCollection, spFieldInternalName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(null, _extensionMethodsInstanceType, MethodContainsFieldWithInternalName, parametersOfContainsFieldWithInternalName, methodContainsFieldWithInternalNamePrametersTypes);

            // Assert
            parametersOfContainsFieldWithInternalName.ShouldNotBeNull();
            parametersOfContainsFieldWithInternalName.Length.ShouldBe(2);
            methodContainsFieldWithInternalNamePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ContainsFieldWithInternalName) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ContainsFieldWithInternalName_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodContainsFieldWithInternalNamePrametersTypes = new Type[] { typeof(SPFieldCollection), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodContainsFieldWithInternalName, Fixture, methodContainsFieldWithInternalNamePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodContainsFieldWithInternalNamePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ContainsFieldWithInternalName) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ContainsFieldWithInternalName_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodContainsFieldWithInternalNamePrametersTypes = new Type[] { typeof(SPFieldCollection), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodContainsFieldWithInternalName, Fixture, methodContainsFieldWithInternalNamePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodContainsFieldWithInternalNamePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ContainsFieldWithInternalName) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ContainsFieldWithInternalName_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodContainsFieldWithInternalNamePrametersTypes = new Type[] { typeof(SPFieldCollection), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodContainsFieldWithInternalName, Fixture, methodContainsFieldWithInternalNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodContainsFieldWithInternalNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ContainsFieldWithInternalName) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ContainsFieldWithInternalName_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodContainsFieldWithInternalName, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ContainsFieldWithInternalName) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ContainsFieldWithInternalName_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodContainsFieldWithInternalName, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SpDecompress) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_SpDecompress_Static_Method_Call_Internally(Type[] types)
        {
            var methodSpDecompressPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodSpDecompress, Fixture, methodSpDecompressPrametersTypes);
        }

        #endregion

        #region Method Call : (SpDecompress) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_SpDecompress_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var compressedBytesBuffer = CreateType<byte[]>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.SpDecompress(compressedBytesBuffer);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (SpDecompress) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_SpDecompress_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var compressedBytesBuffer = CreateType<byte[]>();
            var methodSpDecompressPrametersTypes = new Type[] { typeof(byte[]) };
            object[] parametersOfSpDecompress = { compressedBytesBuffer };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSpDecompress, methodSpDecompressPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodSpDecompress, Fixture, methodSpDecompressPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodSpDecompress, parametersOfSpDecompress, methodSpDecompressPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSpDecompress.ShouldNotBeNull();
            parametersOfSpDecompress.Length.ShouldBe(1);
            methodSpDecompressPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodSpDecompress, parametersOfSpDecompress, methodSpDecompressPrametersTypes));
        }

        #endregion

        #region Method Call : (SpDecompress) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_SpDecompress_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var compressedBytesBuffer = CreateType<byte[]>();
            var methodSpDecompressPrametersTypes = new Type[] { typeof(byte[]) };
            object[] parametersOfSpDecompress = { compressedBytesBuffer };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSpDecompress, methodSpDecompressPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfSpDecompress);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSpDecompress.ShouldNotBeNull();
            parametersOfSpDecompress.Length.ShouldBe(1);
            methodSpDecompressPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SpDecompress) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_SpDecompress_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var compressedBytesBuffer = CreateType<byte[]>();
            var methodSpDecompressPrametersTypes = new Type[] { typeof(byte[]) };
            object[] parametersOfSpDecompress = { compressedBytesBuffer };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodSpDecompress, parametersOfSpDecompress, methodSpDecompressPrametersTypes);

            // Assert
            parametersOfSpDecompress.ShouldNotBeNull();
            parametersOfSpDecompress.Length.ShouldBe(1);
            methodSpDecompressPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SpDecompress) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_SpDecompress_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodSpDecompressPrametersTypes = new Type[] { typeof(byte[]) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodSpDecompress, Fixture, methodSpDecompressPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodSpDecompressPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SpDecompress) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_SpDecompress_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSpDecompressPrametersTypes = new Type[] { typeof(byte[]) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodSpDecompress, Fixture, methodSpDecompressPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSpDecompressPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SpDecompress) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_SpDecompress_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSpDecompress, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (SpDecompress) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_SpDecompress_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSpDecompress, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CopyStream) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_CopyStream_Static_Method_Call_Internally(Type[] types)
        {
            var methodCopyStreamPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodCopyStream, Fixture, methodCopyStreamPrametersTypes);
        }

        #endregion

        #region Method Call : (CopyStream) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_CopyStream_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var input = CreateType<Stream>();
            var output = CreateType<Stream>();
            var methodCopyStreamPrametersTypes = new Type[] { typeof(Stream), typeof(Stream) };
            object[] parametersOfCopyStream = { input, output };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCopyStream, methodCopyStreamPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfCopyStream);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCopyStream.ShouldNotBeNull();
            parametersOfCopyStream.Length.ShouldBe(2);
            methodCopyStreamPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CopyStream) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_CopyStream_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var input = CreateType<Stream>();
            var output = CreateType<Stream>();
            var methodCopyStreamPrametersTypes = new Type[] { typeof(Stream), typeof(Stream) };
            object[] parametersOfCopyStream = { input, output };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(null, _extensionMethodsInstanceType, MethodCopyStream, parametersOfCopyStream, methodCopyStreamPrametersTypes);

            // Assert
            parametersOfCopyStream.ShouldNotBeNull();
            parametersOfCopyStream.Length.ShouldBe(2);
            methodCopyStreamPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CopyStream) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_CopyStream_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCopyStream, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CopyStream) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_CopyStream_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCopyStreamPrametersTypes = new Type[] { typeof(Stream), typeof(Stream) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodCopyStream, Fixture, methodCopyStreamPrametersTypes);

            // Assert
            methodCopyStreamPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CopyStream) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_CopyStream_Static_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCopyStream, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AsDelimitedString) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_AsDelimitedString_Static_Method_Call_Internally(Type[] types)
        {
            var methodAsDelimitedStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodAsDelimitedString, Fixture, methodAsDelimitedStringPrametersTypes);
        }

        #endregion

        #region Method Call : (AsDelimitedString) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_AsDelimitedString_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<IEnumerable<string>>();
            var delimiter = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.AsDelimitedString(list, delimiter);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (AsDelimitedString) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_AsDelimitedString_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<IEnumerable<string>>();
            var delimiter = CreateType<string>();
            var methodAsDelimitedStringPrametersTypes = new Type[] { typeof(IEnumerable<string>), typeof(string) };
            object[] parametersOfAsDelimitedString = { list, delimiter };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAsDelimitedString, methodAsDelimitedStringPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfAsDelimitedString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAsDelimitedString.ShouldNotBeNull();
            parametersOfAsDelimitedString.Length.ShouldBe(2);
            methodAsDelimitedStringPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AsDelimitedString) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_AsDelimitedString_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<IEnumerable<string>>();
            var delimiter = CreateType<string>();
            var methodAsDelimitedStringPrametersTypes = new Type[] { typeof(IEnumerable<string>), typeof(string) };
            object[] parametersOfAsDelimitedString = { list, delimiter };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodAsDelimitedString, parametersOfAsDelimitedString, methodAsDelimitedStringPrametersTypes);

            // Assert
            parametersOfAsDelimitedString.ShouldNotBeNull();
            parametersOfAsDelimitedString.Length.ShouldBe(2);
            methodAsDelimitedStringPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AsDelimitedString) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_AsDelimitedString_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodAsDelimitedStringPrametersTypes = new Type[] { typeof(IEnumerable<string>), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodAsDelimitedString, Fixture, methodAsDelimitedStringPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodAsDelimitedStringPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (AsDelimitedString) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_AsDelimitedString_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAsDelimitedStringPrametersTypes = new Type[] { typeof(IEnumerable<string>), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodAsDelimitedString, Fixture, methodAsDelimitedStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAsDelimitedStringPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AsDelimitedString) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_AsDelimitedString_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAsDelimitedString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (AsDelimitedString) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_AsDelimitedString_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAsDelimitedString, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PopulateFromCommaSeparatedString) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_PopulateFromCommaSeparatedString_Static_Method_Call_Internally(Type[] types)
        {
            var methodPopulateFromCommaSeparatedStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodPopulateFromCommaSeparatedString, Fixture, methodPopulateFromCommaSeparatedStringPrametersTypes);
        }

        #endregion

        #region Method Call : (PopulateFromCommaSeparatedString) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_PopulateFromCommaSeparatedString_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<List<string>>();
            var stringToSeparate = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.PopulateFromCommaSeparatedString(list, stringToSeparate);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (PopulateFromCommaSeparatedString) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_PopulateFromCommaSeparatedString_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<List<string>>();
            var stringToSeparate = CreateType<string>();
            var methodPopulateFromCommaSeparatedStringPrametersTypes = new Type[] { typeof(List<string>), typeof(string) };
            object[] parametersOfPopulateFromCommaSeparatedString = { list, stringToSeparate };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPopulateFromCommaSeparatedString, methodPopulateFromCommaSeparatedStringPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfPopulateFromCommaSeparatedString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPopulateFromCommaSeparatedString.ShouldNotBeNull();
            parametersOfPopulateFromCommaSeparatedString.Length.ShouldBe(2);
            methodPopulateFromCommaSeparatedStringPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateFromCommaSeparatedString) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_PopulateFromCommaSeparatedString_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<List<string>>();
            var stringToSeparate = CreateType<string>();
            var methodPopulateFromCommaSeparatedStringPrametersTypes = new Type[] { typeof(List<string>), typeof(string) };
            object[] parametersOfPopulateFromCommaSeparatedString = { list, stringToSeparate };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(null, _extensionMethodsInstanceType, MethodPopulateFromCommaSeparatedString, parametersOfPopulateFromCommaSeparatedString, methodPopulateFromCommaSeparatedStringPrametersTypes);

            // Assert
            parametersOfPopulateFromCommaSeparatedString.ShouldNotBeNull();
            parametersOfPopulateFromCommaSeparatedString.Length.ShouldBe(2);
            methodPopulateFromCommaSeparatedStringPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateFromCommaSeparatedString) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_PopulateFromCommaSeparatedString_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPopulateFromCommaSeparatedString, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PopulateFromCommaSeparatedString) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_PopulateFromCommaSeparatedString_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPopulateFromCommaSeparatedStringPrametersTypes = new Type[] { typeof(List<string>), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodPopulateFromCommaSeparatedString, Fixture, methodPopulateFromCommaSeparatedStringPrametersTypes);

            // Assert
            methodPopulateFromCommaSeparatedStringPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateFromCommaSeparatedString) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_PopulateFromCommaSeparatedString_Static_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPopulateFromCommaSeparatedString, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetExtId) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_GetExtId_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetExtIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetExtId, Fixture, methodGetExtIdPrametersTypes);
        }

        #endregion

        #region Method Call : (GetExtId) (Return Type : int) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetExtId_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var spUser = CreateType<SPUser>();
            var spWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.GetExtId(spUser, spWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetExtId) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetExtId_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spUser = CreateType<SPUser>();
            var spWeb = CreateType<SPWeb>();
            var methodGetExtIdPrametersTypes = new Type[] { typeof(SPUser), typeof(SPWeb) };
            object[] parametersOfGetExtId = { spUser, spWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<int>(null, _extensionMethodsInstanceType, MethodGetExtId, parametersOfGetExtId, methodGetExtIdPrametersTypes);

            // Assert
            parametersOfGetExtId.ShouldNotBeNull();
            parametersOfGetExtId.Length.ShouldBe(2);
            methodGetExtIdPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetExtId) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetExtId_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetExtIdPrametersTypes = new Type[] { typeof(SPUser), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetExtId, Fixture, methodGetExtIdPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetExtIdPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetExtId) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetExtId_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetExtId, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetExtId) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetExtId_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetExtId, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourcePoolId) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_GetResourcePoolId_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetResourcePoolIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetResourcePoolId, Fixture, methodGetResourcePoolIdPrametersTypes);
        }

        #endregion

        #region Method Call : (GetResourcePoolId) (Return Type : int) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetResourcePoolId_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var spUser = CreateType<SPUser>();
            var spWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.GetResourcePoolId(spUser, spWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetResourcePoolId) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetResourcePoolId_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spUser = CreateType<SPUser>();
            var spWeb = CreateType<SPWeb>();
            var methodGetResourcePoolIdPrametersTypes = new Type[] { typeof(SPUser), typeof(SPWeb) };
            object[] parametersOfGetResourcePoolId = { spUser, spWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<int>(null, _extensionMethodsInstanceType, MethodGetResourcePoolId, parametersOfGetResourcePoolId, methodGetResourcePoolIdPrametersTypes);

            // Assert
            parametersOfGetResourcePoolId.ShouldNotBeNull();
            parametersOfGetResourcePoolId.Length.ShouldBe(2);
            methodGetResourcePoolIdPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetResourcePoolId) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetResourcePoolId_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetResourcePoolIdPrametersTypes = new Type[] { typeof(SPUser), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetResourcePoolId, Fixture, methodGetResourcePoolIdPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetResourcePoolIdPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourcePoolId) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetResourcePoolId_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetResourcePoolId, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetResourcePoolId) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetResourcePoolId_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetResourcePoolId, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetWebPartByTypeName) (Return Type : WebPart) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_GetWebPartByTypeName_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetWebPartByTypeNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetWebPartByTypeName, Fixture, methodGetWebPartByTypeNamePrametersTypes);
        }

        #endregion

        #region Method Call : (GetWebPartByTypeName) (Return Type : WebPart) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetWebPartByTypeName_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var webPartManager = CreateType<SPLimitedWebPartManager>();
            var webPartType = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.GetWebPartByTypeName(webPartManager, webPartType);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetWebPartByTypeName) (Return Type : WebPart) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetWebPartByTypeName_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var webPartManager = CreateType<SPLimitedWebPartManager>();
            var webPartType = CreateType<string>();
            var methodGetWebPartByTypeNamePrametersTypes = new Type[] { typeof(SPLimitedWebPartManager), typeof(string) };
            object[] parametersOfGetWebPartByTypeName = { webPartManager, webPartType };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetWebPartByTypeName, methodGetWebPartByTypeNamePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetWebPartByTypeName, Fixture, methodGetWebPartByTypeNamePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<WebPart>(null, _extensionMethodsInstanceType, MethodGetWebPartByTypeName, parametersOfGetWebPartByTypeName, methodGetWebPartByTypeNamePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetWebPartByTypeName);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetWebPartByTypeName.ShouldNotBeNull();
            parametersOfGetWebPartByTypeName.Length.ShouldBe(2);
            methodGetWebPartByTypeNamePrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetWebPartByTypeName) (Return Type : WebPart) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetWebPartByTypeName_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var webPartManager = CreateType<SPLimitedWebPartManager>();
            var webPartType = CreateType<string>();
            var methodGetWebPartByTypeNamePrametersTypes = new Type[] { typeof(SPLimitedWebPartManager), typeof(string) };
            object[] parametersOfGetWebPartByTypeName = { webPartManager, webPartType };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<WebPart>(null, _extensionMethodsInstanceType, MethodGetWebPartByTypeName, parametersOfGetWebPartByTypeName, methodGetWebPartByTypeNamePrametersTypes);

            // Assert
            parametersOfGetWebPartByTypeName.ShouldNotBeNull();
            parametersOfGetWebPartByTypeName.Length.ShouldBe(2);
            methodGetWebPartByTypeNamePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetWebPartByTypeName) (Return Type : WebPart) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetWebPartByTypeName_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetWebPartByTypeNamePrametersTypes = new Type[] { typeof(SPLimitedWebPartManager), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetWebPartByTypeName, Fixture, methodGetWebPartByTypeNamePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetWebPartByTypeNamePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetWebPartByTypeName) (Return Type : WebPart) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetWebPartByTypeName_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetWebPartByTypeNamePrametersTypes = new Type[] { typeof(SPLimitedWebPartManager), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetWebPartByTypeName, Fixture, methodGetWebPartByTypeNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetWebPartByTypeNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetWebPartByTypeName) (Return Type : WebPart) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetWebPartByTypeName_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetWebPartByTypeName, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetWebPartByTypeName) (Return Type : WebPart) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetWebPartByTypeName_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetWebPartByTypeName, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Sort) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_Sort_Static_Method_Overloading_Of_2_Call_Internally(Type[] types)
        {
            var methodSortPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodSort, Fixture, methodSortPrametersTypes);
        }

        #endregion

        #region Method Call : (Sort) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Sort_Static_Method_DirectCall_Overloading_Of_2_No_Exception_Thrown_Test()
        {
            // Arrange
            var treeView = CreateType<TreeView>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.Sort(treeView);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Sort) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Sort_Static_Method_Call_Void_Overloading_Of_2_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var treeView = CreateType<TreeView>();
            var methodSortPrametersTypes = new Type[] { typeof(TreeView) };
            object[] parametersOfSort = { treeView };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSort, methodSortPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfSort);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSort.ShouldNotBeNull();
            parametersOfSort.Length.ShouldBe(1);
            methodSortPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Sort) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Sort_Static_Method_Call_Void_Overloading_Of_2_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var treeView = CreateType<TreeView>();
            var methodSortPrametersTypes = new Type[] { typeof(TreeView) };
            object[] parametersOfSort = { treeView };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(null, _extensionMethodsInstanceType, MethodSort, parametersOfSort, methodSortPrametersTypes);

            // Assert
            parametersOfSort.ShouldNotBeNull();
            parametersOfSort.Length.ShouldBe(1);
            methodSortPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Sort) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Sort_Static_Method_Call_Overloading_Of_2_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSort, 2);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Sort) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Sort_Static_Method_Call_Overloading_Of_2_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSortPrametersTypes = new Type[] { typeof(TreeView) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodSort, Fixture, methodSortPrametersTypes);

            // Assert
            methodSortPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Sort) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Sort_Static_Method_Call_Overloading_Of_2_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSort, 2);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSize) (Return Type : long) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_GetSize_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetSizePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetSize, Fixture, methodGetSizePrametersTypes);
        }

        #endregion

        #region Method Call : (GetSize) (Return Type : long) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetSize_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var obj = CreateType<object>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.GetSize(obj);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetSize) (Return Type : long) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetSize_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var obj = CreateType<object>();
            var methodGetSizePrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfGetSize = { obj };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSize, methodGetSizePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetSize, Fixture, methodGetSizePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<long>(null, _extensionMethodsInstanceType, MethodGetSize, parametersOfGetSize, methodGetSizePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetSize.ShouldNotBeNull();
            parametersOfGetSize.Length.ShouldBe(1);
            methodGetSizePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<long>(null, _extensionMethodsInstanceType, MethodGetSize, parametersOfGetSize, methodGetSizePrametersTypes));
        }

        #endregion

        #region Method Call : (GetSize) (Return Type : long) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetSize_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var obj = CreateType<object>();
            var methodGetSizePrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfGetSize = { obj };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetSize, methodGetSizePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetSize);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetSize.ShouldNotBeNull();
            parametersOfGetSize.Length.ShouldBe(1);
            methodGetSizePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSize) (Return Type : long) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetSize_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var obj = CreateType<object>();
            var methodGetSizePrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfGetSize = { obj };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<long>(null, _extensionMethodsInstanceType, MethodGetSize, parametersOfGetSize, methodGetSizePrametersTypes);

            // Assert
            parametersOfGetSize.ShouldNotBeNull();
            parametersOfGetSize.Length.ShouldBe(1);
            methodGetSizePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSize) (Return Type : long) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetSize_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetSizePrametersTypes = new Type[] { typeof(object) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetSize, Fixture, methodGetSizePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetSizePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetSize) (Return Type : long) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetSize_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetSizePrametersTypes = new Type[] { typeof(object) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetSize, Fixture, methodGetSizePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetSizePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetSize) (Return Type : long) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetSize_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSizePrametersTypes = new Type[] { typeof(object) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetSize, Fixture, methodGetSizePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSizePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSize) (Return Type : long) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetSize_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSize, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetSize) (Return Type : long) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetSize_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetSize, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFields) (Return Type : IEnumerable<FieldInfo>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_GetFields_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetFields, Fixture, methodGetFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFields) (Return Type : IEnumerable<FieldInfo>) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetFields_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var type = CreateType<Type>();
            var methodGetFieldsPrametersTypes = new Type[] { typeof(Type) };
            object[] parametersOfGetFields = { type };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetFields, methodGetFieldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetFields);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetFields.ShouldNotBeNull();
            parametersOfGetFields.Length.ShouldBe(1);
            methodGetFieldsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFields) (Return Type : IEnumerable<FieldInfo>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetFields_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var type = CreateType<Type>();
            var methodGetFieldsPrametersTypes = new Type[] { typeof(Type) };
            object[] parametersOfGetFields = { type };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<IEnumerable<FieldInfo>>(null, _extensionMethodsInstanceType, MethodGetFields, parametersOfGetFields, methodGetFieldsPrametersTypes);

            // Assert
            parametersOfGetFields.ShouldNotBeNull();
            parametersOfGetFields.Length.ShouldBe(1);
            methodGetFieldsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFields) (Return Type : IEnumerable<FieldInfo>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetFields_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFieldsPrametersTypes = new Type[] { typeof(Type) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetFields, Fixture, methodGetFieldsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFieldsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFields) (Return Type : IEnumerable<FieldInfo>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetFields_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFieldsPrametersTypes = new Type[] { typeof(Type) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetFields, Fixture, methodGetFieldsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFieldsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFields) (Return Type : IEnumerable<FieldInfo>) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetFields_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFields, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetFields) (Return Type : IEnumerable<FieldInfo>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetFields_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFields, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTypeSizeArray) (Return Type : long) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_GetTypeSizeArray_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetTypeSizeArrayPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetTypeSizeArray, Fixture, methodGetTypeSizeArrayPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTypeSizeArray) (Return Type : long) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetTypeSizeArray_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var typeName = CreateType<string>();
            var objValue = CreateType<object>();
            var methodGetTypeSizeArrayPrametersTypes = new Type[] { typeof(string), typeof(object) };
            object[] parametersOfGetTypeSizeArray = { typeName, objValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetTypeSizeArray, methodGetTypeSizeArrayPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetTypeSizeArray);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetTypeSizeArray.ShouldNotBeNull();
            parametersOfGetTypeSizeArray.Length.ShouldBe(2);
            methodGetTypeSizeArrayPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTypeSizeArray) (Return Type : long) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetTypeSizeArray_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var typeName = CreateType<string>();
            var objValue = CreateType<object>();
            var methodGetTypeSizeArrayPrametersTypes = new Type[] { typeof(string), typeof(object) };
            object[] parametersOfGetTypeSizeArray = { typeName, objValue };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<long>(null, _extensionMethodsInstanceType, MethodGetTypeSizeArray, parametersOfGetTypeSizeArray, methodGetTypeSizeArrayPrametersTypes);

            // Assert
            parametersOfGetTypeSizeArray.ShouldNotBeNull();
            parametersOfGetTypeSizeArray.Length.ShouldBe(2);
            methodGetTypeSizeArrayPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTypeSizeArray) (Return Type : long) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetTypeSizeArray_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTypeSizeArrayPrametersTypes = new Type[] { typeof(string), typeof(object) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetTypeSizeArray, Fixture, methodGetTypeSizeArrayPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTypeSizeArrayPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTypeSizeArray) (Return Type : long) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetTypeSizeArray_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTypeSizeArray, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetTypeSizeArray) (Return Type : long) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetTypeSizeArray_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTypeSizeArray, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTypeSize) (Return Type : long) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_GetTypeSize_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetTypeSizePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetTypeSize, Fixture, methodGetTypeSizePrametersTypes);
        }

        #endregion

        #region Method Call : (GetTypeSize) (Return Type : long) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetTypeSize_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var typeName = CreateType<string>();
            var methodGetTypeSizePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetTypeSize = { typeName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetTypeSize, methodGetTypeSizePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetTypeSize);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetTypeSize.ShouldNotBeNull();
            parametersOfGetTypeSize.Length.ShouldBe(1);
            methodGetTypeSizePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTypeSize) (Return Type : long) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetTypeSize_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var typeName = CreateType<string>();
            var methodGetTypeSizePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetTypeSize = { typeName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<long>(null, _extensionMethodsInstanceType, MethodGetTypeSize, parametersOfGetTypeSize, methodGetTypeSizePrametersTypes);

            // Assert
            parametersOfGetTypeSize.ShouldNotBeNull();
            parametersOfGetTypeSize.Length.ShouldBe(1);
            methodGetTypeSizePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTypeSize) (Return Type : long) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetTypeSize_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTypeSizePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetTypeSize, Fixture, methodGetTypeSizePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTypeSizePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTypeSize) (Return Type : long) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetTypeSize_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTypeSize, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetTypeSize) (Return Type : long) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetTypeSize_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTypeSize, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsGuid) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_IsGuid_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodIsGuidPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodIsGuid, Fixture, methodIsGuidPrametersTypes);
        }

        #endregion

        #region Method Call : (IsGuid) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsGuid_Static_Method_DirectCall_Overloading_Of_1_No_Exception_Thrown_Test()
        {
            // Arrange
            var obj = CreateType<object>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.IsGuid(obj);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (IsGuid) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsGuid_Static_Method_Call_Overloading_Of_1_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var obj = CreateType<object>();
            var methodIsGuidPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfIsGuid = { obj };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsGuid, methodIsGuidPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodIsGuid, Fixture, methodIsGuidPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<bool>(null, _extensionMethodsInstanceType, MethodIsGuid, parametersOfIsGuid, methodIsGuidPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsGuid.ShouldNotBeNull();
            parametersOfIsGuid.Length.ShouldBe(1);
            methodIsGuidPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(null, _extensionMethodsInstanceType, MethodIsGuid, parametersOfIsGuid, methodIsGuidPrametersTypes));
        }

        #endregion

        #region Method Call : (IsGuid) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsGuid_Static_Method_Call_Overloading_Of_1_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var obj = CreateType<object>();
            var methodIsGuidPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfIsGuid = { obj };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodIsGuid, methodIsGuidPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfIsGuid);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfIsGuid.ShouldNotBeNull();
            parametersOfIsGuid.Length.ShouldBe(1);
            methodIsGuidPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsGuid) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsGuid_Static_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var obj = CreateType<object>();
            var methodIsGuidPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfIsGuid = { obj };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(null, _extensionMethodsInstanceType, MethodIsGuid, parametersOfIsGuid, methodIsGuidPrametersTypes);

            // Assert
            parametersOfIsGuid.ShouldNotBeNull();
            parametersOfIsGuid.Length.ShouldBe(1);
            methodIsGuidPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsGuid) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsGuid_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodIsGuidPrametersTypes = new Type[] { typeof(object) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodIsGuid, Fixture, methodIsGuidPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodIsGuidPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (IsGuid) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsGuid_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodIsGuidPrametersTypes = new Type[] { typeof(object) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodIsGuid, Fixture, methodIsGuidPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodIsGuidPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (IsGuid) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsGuid_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsGuidPrametersTypes = new Type[] { typeof(object) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodIsGuid, Fixture, methodIsGuidPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsGuidPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsGuid) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsGuid_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsGuid, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (IsGuid) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsGuid_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodIsGuid, 1);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsNonEmptyString) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_IsNonEmptyString_Static_Method_Call_Internally(Type[] types)
        {
            var methodIsNonEmptyStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodIsNonEmptyString, Fixture, methodIsNonEmptyStringPrametersTypes);
        }

        #endregion

        #region Method Call : (IsNonEmptyString) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsNonEmptyString_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var obj = CreateType<object>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.IsNonEmptyString(obj);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (IsNonEmptyString) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsNonEmptyString_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var obj = CreateType<object>();
            var methodIsNonEmptyStringPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfIsNonEmptyString = { obj };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsNonEmptyString, methodIsNonEmptyStringPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodIsNonEmptyString, Fixture, methodIsNonEmptyStringPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<bool>(null, _extensionMethodsInstanceType, MethodIsNonEmptyString, parametersOfIsNonEmptyString, methodIsNonEmptyStringPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsNonEmptyString.ShouldNotBeNull();
            parametersOfIsNonEmptyString.Length.ShouldBe(1);
            methodIsNonEmptyStringPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(null, _extensionMethodsInstanceType, MethodIsNonEmptyString, parametersOfIsNonEmptyString, methodIsNonEmptyStringPrametersTypes));
        }

        #endregion

        #region Method Call : (IsNonEmptyString) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsNonEmptyString_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var obj = CreateType<object>();
            var methodIsNonEmptyStringPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfIsNonEmptyString = { obj };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodIsNonEmptyString, methodIsNonEmptyStringPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfIsNonEmptyString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfIsNonEmptyString.ShouldNotBeNull();
            parametersOfIsNonEmptyString.Length.ShouldBe(1);
            methodIsNonEmptyStringPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsNonEmptyString) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsNonEmptyString_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var obj = CreateType<object>();
            var methodIsNonEmptyStringPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfIsNonEmptyString = { obj };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(null, _extensionMethodsInstanceType, MethodIsNonEmptyString, parametersOfIsNonEmptyString, methodIsNonEmptyStringPrametersTypes);

            // Assert
            parametersOfIsNonEmptyString.ShouldNotBeNull();
            parametersOfIsNonEmptyString.Length.ShouldBe(1);
            methodIsNonEmptyStringPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsNonEmptyString) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsNonEmptyString_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodIsNonEmptyStringPrametersTypes = new Type[] { typeof(object) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodIsNonEmptyString, Fixture, methodIsNonEmptyStringPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodIsNonEmptyStringPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (IsNonEmptyString) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsNonEmptyString_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodIsNonEmptyStringPrametersTypes = new Type[] { typeof(object) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodIsNonEmptyString, Fixture, methodIsNonEmptyStringPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodIsNonEmptyStringPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (IsNonEmptyString) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsNonEmptyString_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsNonEmptyStringPrametersTypes = new Type[] { typeof(object) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodIsNonEmptyString, Fixture, methodIsNonEmptyStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsNonEmptyStringPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsNonEmptyString) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsNonEmptyString_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsNonEmptyString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (IsNonEmptyString) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsNonEmptyString_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodIsNonEmptyString, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsInt) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_IsInt_Static_Method_Call_Internally(Type[] types)
        {
            var methodIsIntPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodIsInt, Fixture, methodIsIntPrametersTypes);
        }

        #endregion

        #region Method Call : (IsInt) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsInt_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var obj = CreateType<object>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.IsInt(obj);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (IsInt) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsInt_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var obj = CreateType<object>();
            var methodIsIntPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfIsInt = { obj };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsInt, methodIsIntPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodIsInt, Fixture, methodIsIntPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<bool>(null, _extensionMethodsInstanceType, MethodIsInt, parametersOfIsInt, methodIsIntPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsInt.ShouldNotBeNull();
            parametersOfIsInt.Length.ShouldBe(1);
            methodIsIntPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(null, _extensionMethodsInstanceType, MethodIsInt, parametersOfIsInt, methodIsIntPrametersTypes));
        }

        #endregion

        #region Method Call : (IsInt) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsInt_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var obj = CreateType<object>();
            var methodIsIntPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfIsInt = { obj };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodIsInt, methodIsIntPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfIsInt);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfIsInt.ShouldNotBeNull();
            parametersOfIsInt.Length.ShouldBe(1);
            methodIsIntPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsInt) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsInt_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var obj = CreateType<object>();
            var methodIsIntPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfIsInt = { obj };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(null, _extensionMethodsInstanceType, MethodIsInt, parametersOfIsInt, methodIsIntPrametersTypes);

            // Assert
            parametersOfIsInt.ShouldNotBeNull();
            parametersOfIsInt.Length.ShouldBe(1);
            methodIsIntPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsInt) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsInt_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodIsIntPrametersTypes = new Type[] { typeof(object) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodIsInt, Fixture, methodIsIntPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodIsIntPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (IsInt) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsInt_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodIsIntPrametersTypes = new Type[] { typeof(object) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodIsInt, Fixture, methodIsIntPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodIsIntPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (IsInt) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsInt_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsIntPrametersTypes = new Type[] { typeof(object) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodIsInt, Fixture, methodIsIntPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsIntPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsInt) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsInt_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsInt, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (IsInt) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsInt_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodIsInt, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsDateTime) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_IsDateTime_Static_Method_Call_Internally(Type[] types)
        {
            var methodIsDateTimePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodIsDateTime, Fixture, methodIsDateTimePrametersTypes);
        }

        #endregion

        #region Method Call : (IsDateTime) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsDateTime_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var obj = CreateType<object>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.IsDateTime(obj);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (IsDateTime) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsDateTime_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var obj = CreateType<object>();
            var methodIsDateTimePrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfIsDateTime = { obj };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsDateTime, methodIsDateTimePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodIsDateTime, Fixture, methodIsDateTimePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<bool>(null, _extensionMethodsInstanceType, MethodIsDateTime, parametersOfIsDateTime, methodIsDateTimePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsDateTime.ShouldNotBeNull();
            parametersOfIsDateTime.Length.ShouldBe(1);
            methodIsDateTimePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(null, _extensionMethodsInstanceType, MethodIsDateTime, parametersOfIsDateTime, methodIsDateTimePrametersTypes));
        }

        #endregion

        #region Method Call : (IsDateTime) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsDateTime_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var obj = CreateType<object>();
            var methodIsDateTimePrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfIsDateTime = { obj };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodIsDateTime, methodIsDateTimePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfIsDateTime);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfIsDateTime.ShouldNotBeNull();
            parametersOfIsDateTime.Length.ShouldBe(1);
            methodIsDateTimePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsDateTime) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsDateTime_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var obj = CreateType<object>();
            var methodIsDateTimePrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfIsDateTime = { obj };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(null, _extensionMethodsInstanceType, MethodIsDateTime, parametersOfIsDateTime, methodIsDateTimePrametersTypes);

            // Assert
            parametersOfIsDateTime.ShouldNotBeNull();
            parametersOfIsDateTime.Length.ShouldBe(1);
            methodIsDateTimePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsDateTime) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsDateTime_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodIsDateTimePrametersTypes = new Type[] { typeof(object) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodIsDateTime, Fixture, methodIsDateTimePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodIsDateTimePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (IsDateTime) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsDateTime_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodIsDateTimePrametersTypes = new Type[] { typeof(object) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodIsDateTime, Fixture, methodIsDateTimePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodIsDateTimePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (IsDateTime) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsDateTime_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsDateTimePrametersTypes = new Type[] { typeof(object) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodIsDateTime, Fixture, methodIsDateTimePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsDateTimePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsDateTime) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsDateTime_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsDateTime, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (IsDateTime) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_IsDateTime_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodIsDateTime, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OlsonName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_OlsonName_Static_Method_Call_Internally(Type[] types)
        {
            var methodOlsonNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodOlsonName, Fixture, methodOlsonNamePrametersTypes);
        }

        #endregion

        #region Method Call : (OlsonName) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_OlsonName_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var timeZone = CreateType<TimeZoneInfo>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.OlsonName(timeZone);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (OlsonName) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_OlsonName_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var timeZone = CreateType<TimeZoneInfo>();
            var methodOlsonNamePrametersTypes = new Type[] { typeof(TimeZoneInfo) };
            object[] parametersOfOlsonName = { timeZone };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOlsonName, methodOlsonNamePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodOlsonName, Fixture, methodOlsonNamePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodOlsonName, parametersOfOlsonName, methodOlsonNamePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfOlsonName.ShouldNotBeNull();
            parametersOfOlsonName.Length.ShouldBe(1);
            methodOlsonNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodOlsonName, parametersOfOlsonName, methodOlsonNamePrametersTypes));
        }

        #endregion

        #region Method Call : (OlsonName) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_OlsonName_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var timeZone = CreateType<TimeZoneInfo>();
            var methodOlsonNamePrametersTypes = new Type[] { typeof(TimeZoneInfo) };
            object[] parametersOfOlsonName = { timeZone };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOlsonName, methodOlsonNamePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfOlsonName);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOlsonName.ShouldNotBeNull();
            parametersOfOlsonName.Length.ShouldBe(1);
            methodOlsonNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OlsonName) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_OlsonName_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var timeZone = CreateType<TimeZoneInfo>();
            var methodOlsonNamePrametersTypes = new Type[] { typeof(TimeZoneInfo) };
            object[] parametersOfOlsonName = { timeZone };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodOlsonName, parametersOfOlsonName, methodOlsonNamePrametersTypes);

            // Assert
            parametersOfOlsonName.ShouldNotBeNull();
            parametersOfOlsonName.Length.ShouldBe(1);
            methodOlsonNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OlsonName) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_OlsonName_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodOlsonNamePrametersTypes = new Type[] { typeof(TimeZoneInfo) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodOlsonName, Fixture, methodOlsonNamePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodOlsonNamePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (OlsonName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_OlsonName_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOlsonNamePrametersTypes = new Type[] { typeof(TimeZoneInfo) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodOlsonName, Fixture, methodOlsonNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodOlsonNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OlsonName) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_OlsonName_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOlsonName, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (OlsonName) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_OlsonName_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOlsonName, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetWebTree) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_GetWebTree_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetWebTreePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetWebTree, Fixture, methodGetWebTreePrametersTypes);
        }

        #endregion
        
        #region Method Call : (GetWebTree) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetWebTree_Static_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var id = CreateType<Guid>();
            var siteUrl = CreateType<string>();
            var tree = CreateType<List<Guid>>();
            var methodGetWebTreePrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(List<Guid>) };
            object[] parametersOfGetWebTree = { id, siteUrl, tree };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(null, _extensionMethodsInstanceType, MethodGetWebTree, parametersOfGetWebTree, methodGetWebTreePrametersTypes);

            // Assert
            parametersOfGetWebTree.ShouldNotBeNull();
            parametersOfGetWebTree.Length.ShouldBe(3);
            methodGetWebTreePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetWebTree) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetWebTree_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetWebTree, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetWebTree) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetWebTree_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetWebTreePrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(List<Guid>) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodGetWebTree, Fixture, methodGetWebTreePrametersTypes);

            // Assert
            methodGetWebTreePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetWebTree) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_GetWebTree_Static_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetWebTree, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.Infrastructure
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Infrastructure.EPMLiveFileStore" />)
    ///     and namespace <see cref="EPMLiveCore.Infrastructure"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class EPMLiveFileStoreTest : AbstractBaseSetupTypedTest<EPMLiveFileStore>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EPMLiveFileStore) Initializer

        private const string MethodAdd = "Add";
        private const string MethodGetBytes = "GetBytes";
        private const string MethodDelete = "Delete";
        private const string MethodGet = "Get";
        private const string MethodGetFile = "GetFile";
        private const string MethodGetStream = "GetStream";
        private const string MethodCreateFileStore = "CreateFileStore";
        private const string MethodDispose = "Dispose";
        private const string FieldFILE_STORE_NAME = "FILE_STORE_NAME";
        private const string Field_fileStore = "_fileStore";
        private const string Field_spSite = "_spSite";
        private const string Field_spWeb = "_spWeb";
        private Type _ePMLiveFileStoreInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private EPMLiveFileStore _ePMLiveFileStoreInstance;
        private EPMLiveFileStore _ePMLiveFileStoreInstanceFixture;

        #region General Initializer : Class (EPMLiveFileStore) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EPMLiveFileStore" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _ePMLiveFileStoreInstanceType = typeof(EPMLiveFileStore);
            _ePMLiveFileStoreInstanceFixture = Create(true);
            _ePMLiveFileStoreInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (EPMLiveFileStore)

        #region General Initializer : Class (EPMLiveFileStore) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="EPMLiveFileStore" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodAdd, 0)]
        [TestCase(MethodGetBytes, 0)]
        [TestCase(MethodAdd, 1)]
        [TestCase(MethodDelete, 0)]
        [TestCase(MethodGet, 0)]
        [TestCase(MethodGetFile, 0)]
        [TestCase(MethodGetStream, 0)]
        [TestCase(MethodCreateFileStore, 0)]
        [TestCase(MethodDispose, 0)]
        [TestCase(MethodDispose, 1)]
        public void AUT_EPMLiveFileStore_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_ePMLiveFileStoreInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (EPMLiveFileStore) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="EPMLiveFileStore" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldFILE_STORE_NAME)]
        [TestCase(Field_fileStore)]
        [TestCase(Field_spSite)]
        [TestCase(Field_spWeb)]
        public void AUT_EPMLiveFileStore_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_ePMLiveFileStoreInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="EPMLiveFileStore" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetBytes)]
        public void AUT_EPMLiveFileStore_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_ePMLiveFileStoreInstanceFixture,
                                                                              _ePMLiveFileStoreInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="EPMLiveFileStore" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodAdd)]
        [TestCase(MethodDelete)]
        [TestCase(MethodGet)]
        [TestCase(MethodGetFile)]
        [TestCase(MethodGetStream)]
        [TestCase(MethodCreateFileStore)]
        [TestCase(MethodDispose)]
        public void AUT_EPMLiveFileStore_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<EPMLiveFileStore>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Add) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveFileStore_Add_Method_Call_Internally(Type[] types)
        {
            var methodAddPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveFileStoreInstance, MethodAdd, Fixture, methodAddPrametersTypes);
        }

        #endregion

        #region Method Call : (Add) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_Add_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var content = CreateType<byte[]>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMLiveFileStoreInstance.Add(content);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Add) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_Add_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var content = CreateType<byte[]>();
            var methodAddPrametersTypes = new Type[] { typeof(byte[]) };
            object[] parametersOfAdd = { content };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodAdd, methodAddPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMLiveFileStore, string>(_ePMLiveFileStoreInstanceFixture, out exception1, parametersOfAdd);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMLiveFileStore, string>(_ePMLiveFileStoreInstance, MethodAdd, parametersOfAdd, methodAddPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfAdd.ShouldNotBeNull();
            parametersOfAdd.Length.ShouldBe(1);
            methodAddPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_ePMLiveFileStoreInstanceFixture, parametersOfAdd));
        }

        #endregion

        #region Method Call : (Add) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_Add_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var content = CreateType<byte[]>();
            var methodAddPrametersTypes = new Type[] { typeof(byte[]) };
            object[] parametersOfAdd = { content };

            // Assert
            parametersOfAdd.ShouldNotBeNull();
            parametersOfAdd.Length.ShouldBe(1);
            methodAddPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<EPMLiveFileStore, string>(_ePMLiveFileStoreInstance, MethodAdd, parametersOfAdd, methodAddPrametersTypes));
        }

        #endregion

        #region Method Call : (Add) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_Add_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodAddPrametersTypes = new Type[] { typeof(byte[]) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveFileStoreInstance, MethodAdd, Fixture, methodAddPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodAddPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Add) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_Add_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddPrametersTypes = new Type[] { typeof(byte[]) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveFileStoreInstance, MethodAdd, Fixture, methodAddPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAddPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Add) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_Add_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAdd, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMLiveFileStoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Add) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_Add_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAdd, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetBytes) (Return Type : byte[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveFileStore_GetBytes_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetBytesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePMLiveFileStoreInstanceFixture, _ePMLiveFileStoreInstanceType, MethodGetBytes, Fixture, methodGetBytesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetBytes) (Return Type : byte[]) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_GetBytes_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var input = CreateType<Stream>();
            Action executeAction = null;

            // Act
            executeAction = () => EPMLiveFileStore.GetBytes(input);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetBytes) (Return Type : byte[]) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_GetBytes_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var input = CreateType<Stream>();
            var methodGetBytesPrametersTypes = new Type[] { typeof(Stream) };
            object[] parametersOfGetBytes = { input };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetBytes, methodGetBytesPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePMLiveFileStoreInstanceFixture, _ePMLiveFileStoreInstanceType, MethodGetBytes, Fixture, methodGetBytesPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<byte[]>(_ePMLiveFileStoreInstanceFixture, _ePMLiveFileStoreInstanceType, MethodGetBytes, parametersOfGetBytes, methodGetBytesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetBytes.ShouldNotBeNull();
            parametersOfGetBytes.Length.ShouldBe(1);
            methodGetBytesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<byte[]>(_ePMLiveFileStoreInstanceFixture, _ePMLiveFileStoreInstanceType, MethodGetBytes, parametersOfGetBytes, methodGetBytesPrametersTypes));
        }

        #endregion

        #region Method Call : (GetBytes) (Return Type : byte[]) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_GetBytes_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var input = CreateType<Stream>();
            var methodGetBytesPrametersTypes = new Type[] { typeof(Stream) };
            object[] parametersOfGetBytes = { input };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetBytes, methodGetBytesPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetBytes.ShouldNotBeNull();
            parametersOfGetBytes.Length.ShouldBe(1);
            methodGetBytesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(_ePMLiveFileStoreInstanceFixture, parametersOfGetBytes));
        }

        #endregion

        #region Method Call : (GetBytes) (Return Type : byte[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_GetBytes_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var input = CreateType<Stream>();
            var methodGetBytesPrametersTypes = new Type[] { typeof(Stream) };
            object[] parametersOfGetBytes = { input };

            // Assert
            parametersOfGetBytes.ShouldNotBeNull();
            parametersOfGetBytes.Length.ShouldBe(1);
            methodGetBytesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<byte[]>(_ePMLiveFileStoreInstanceFixture, _ePMLiveFileStoreInstanceType, MethodGetBytes, parametersOfGetBytes, methodGetBytesPrametersTypes));
        }

        #endregion

        #region Method Call : (GetBytes) (Return Type : byte[]) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_GetBytes_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetBytesPrametersTypes = new Type[] { typeof(Stream) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePMLiveFileStoreInstanceFixture, _ePMLiveFileStoreInstanceType, MethodGetBytes, Fixture, methodGetBytesPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetBytesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetBytes) (Return Type : byte[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_GetBytes_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetBytesPrametersTypes = new Type[] { typeof(Stream) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePMLiveFileStoreInstanceFixture, _ePMLiveFileStoreInstanceType, MethodGetBytes, Fixture, methodGetBytesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetBytesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetBytes) (Return Type : byte[]) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_GetBytes_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetBytes, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMLiveFileStoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetBytes) (Return Type : byte[]) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_GetBytes_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetBytes, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Add) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveFileStore_Add_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodAddPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveFileStoreInstance, MethodAdd, Fixture, methodAddPrametersTypes);
        }

        #endregion

        #region Method Call : (Add) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_Add_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var content = CreateType<byte[]>();
            var fileExtension = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMLiveFileStoreInstance.Add(content, fileExtension);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Add) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_Add_Method_Call_Overloading_Of_1_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var content = CreateType<byte[]>();
            var fileExtension = CreateType<string>();
            var methodAddPrametersTypes = new Type[] { typeof(byte[]), typeof(string) };
            object[] parametersOfAdd = { content, fileExtension };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodAdd, methodAddPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMLiveFileStore, string>(_ePMLiveFileStoreInstanceFixture, out exception1, parametersOfAdd);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMLiveFileStore, string>(_ePMLiveFileStoreInstance, MethodAdd, parametersOfAdd, methodAddPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfAdd.ShouldNotBeNull();
            parametersOfAdd.Length.ShouldBe(2);
            methodAddPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(() => methodInfo.Invoke(_ePMLiveFileStoreInstanceFixture, parametersOfAdd));
        }

        #endregion

        #region Method Call : (Add) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_Add_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var content = CreateType<byte[]>();
            var fileExtension = CreateType<string>();
            var methodAddPrametersTypes = new Type[] { typeof(byte[]), typeof(string) };
            object[] parametersOfAdd = { content, fileExtension };

            // Assert
            parametersOfAdd.ShouldNotBeNull();
            parametersOfAdd.Length.ShouldBe(2);
            methodAddPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<EPMLiveFileStore, string>(_ePMLiveFileStoreInstance, MethodAdd, parametersOfAdd, methodAddPrametersTypes));
        }

        #endregion

        #region Method Call : (Add) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_Add_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodAddPrametersTypes = new Type[] { typeof(byte[]), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveFileStoreInstance, MethodAdd, Fixture, methodAddPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodAddPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (Add) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_Add_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddPrametersTypes = new Type[] { typeof(byte[]), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveFileStoreInstance, MethodAdd, Fixture, methodAddPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAddPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Add) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_Add_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAdd, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMLiveFileStoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Add) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_Add_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAdd, 1);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveFileStore_Delete_Method_Call_Internally(Type[] types)
        {
            var methodDeletePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveFileStoreInstance, MethodDelete, Fixture, methodDeletePrametersTypes);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_Delete_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var fileName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMLiveFileStoreInstance.Delete(fileName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_Delete_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var fileName = CreateType<string>();
            var methodDeletePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDelete = { fileName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDelete, methodDeletePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePMLiveFileStoreInstanceFixture, parametersOfDelete);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDelete.ShouldNotBeNull();
            parametersOfDelete.Length.ShouldBe(1);
            methodDeletePrametersTypes.Length.ShouldBe(1);
            methodDeletePrametersTypes.Length.ShouldBe(parametersOfDelete.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_Delete_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var fileName = CreateType<string>();
            var methodDeletePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDelete = { fileName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ePMLiveFileStoreInstance, MethodDelete, parametersOfDelete, methodDeletePrametersTypes);

            // Assert
            parametersOfDelete.ShouldNotBeNull();
            parametersOfDelete.Length.ShouldBe(1);
            methodDeletePrametersTypes.Length.ShouldBe(1);
            methodDeletePrametersTypes.Length.ShouldBe(parametersOfDelete.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_Delete_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDelete, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_Delete_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeletePrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveFileStoreInstance, MethodDelete, Fixture, methodDeletePrametersTypes);

            // Assert
            methodDeletePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_Delete_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDelete, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMLiveFileStoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Get) (Return Type : byte[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveFileStore_Get_Method_Call_Internally(Type[] types)
        {
            var methodGetPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveFileStoreInstance, MethodGet, Fixture, methodGetPrametersTypes);
        }

        #endregion

        #region Method Call : (Get) (Return Type : byte[]) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_Get_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var fileName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMLiveFileStoreInstance.Get(fileName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Get) (Return Type : byte[]) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_Get_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var fileName = CreateType<string>();
            var methodGetPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGet = { fileName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGet, methodGetPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMLiveFileStore, byte[]>(_ePMLiveFileStoreInstanceFixture, out exception1, parametersOfGet);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMLiveFileStore, byte[]>(_ePMLiveFileStoreInstance, MethodGet, parametersOfGet, methodGetPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGet.ShouldNotBeNull();
            parametersOfGet.Length.ShouldBe(1);
            methodGetPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_ePMLiveFileStoreInstanceFixture, parametersOfGet));
        }

        #endregion

        #region Method Call : (Get) (Return Type : byte[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_Get_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var fileName = CreateType<string>();
            var methodGetPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGet = { fileName };

            // Assert
            parametersOfGet.ShouldNotBeNull();
            parametersOfGet.Length.ShouldBe(1);
            methodGetPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<EPMLiveFileStore, byte[]>(_ePMLiveFileStoreInstance, MethodGet, parametersOfGet, methodGetPrametersTypes));
        }

        #endregion

        #region Method Call : (Get) (Return Type : byte[]) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_Get_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveFileStoreInstance, MethodGet, Fixture, methodGetPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Get) (Return Type : byte[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_Get_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveFileStoreInstance, MethodGet, Fixture, methodGetPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Get) (Return Type : byte[]) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_Get_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGet, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMLiveFileStoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Get) (Return Type : byte[]) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_Get_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGet, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFile) (Return Type : SPFile) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveFileStore_GetFile_Method_Call_Internally(Type[] types)
        {
            var methodGetFilePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveFileStoreInstance, MethodGetFile, Fixture, methodGetFilePrametersTypes);
        }

        #endregion

        #region Method Call : (GetFile) (Return Type : SPFile) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_GetFile_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var fileName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMLiveFileStoreInstance.GetFile(fileName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetFile) (Return Type : SPFile) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_GetFile_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var fileName = CreateType<string>();
            var methodGetFilePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetFile = { fileName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetFile, methodGetFilePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMLiveFileStore, SPFile>(_ePMLiveFileStoreInstanceFixture, out exception1, parametersOfGetFile);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMLiveFileStore, SPFile>(_ePMLiveFileStoreInstance, MethodGetFile, parametersOfGetFile, methodGetFilePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFile.ShouldNotBeNull();
            parametersOfGetFile.Length.ShouldBe(1);
            methodGetFilePrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_ePMLiveFileStoreInstanceFixture, parametersOfGetFile));
        }

        #endregion

        #region Method Call : (GetFile) (Return Type : SPFile) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_GetFile_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var fileName = CreateType<string>();
            var methodGetFilePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetFile = { fileName };

            // Assert
            parametersOfGetFile.ShouldNotBeNull();
            parametersOfGetFile.Length.ShouldBe(1);
            methodGetFilePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<EPMLiveFileStore, SPFile>(_ePMLiveFileStoreInstance, MethodGetFile, parametersOfGetFile, methodGetFilePrametersTypes));
        }

        #endregion

        #region Method Call : (GetFile) (Return Type : SPFile) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_GetFile_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFilePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveFileStoreInstance, MethodGetFile, Fixture, methodGetFilePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFilePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFile) (Return Type : SPFile) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_GetFile_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFilePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveFileStoreInstance, MethodGetFile, Fixture, methodGetFilePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFilePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFile) (Return Type : SPFile) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_GetFile_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFile, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMLiveFileStoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFile) (Return Type : SPFile) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_GetFile_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFile, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetStream) (Return Type : Stream) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveFileStore_GetStream_Method_Call_Internally(Type[] types)
        {
            var methodGetStreamPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveFileStoreInstance, MethodGetStream, Fixture, methodGetStreamPrametersTypes);
        }

        #endregion

        #region Method Call : (GetStream) (Return Type : Stream) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_GetStream_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var fileName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMLiveFileStoreInstance.GetStream(fileName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetStream) (Return Type : Stream) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_GetStream_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var fileName = CreateType<string>();
            var methodGetStreamPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetStream = { fileName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetStream, methodGetStreamPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMLiveFileStore, Stream>(_ePMLiveFileStoreInstanceFixture, out exception1, parametersOfGetStream);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMLiveFileStore, Stream>(_ePMLiveFileStoreInstance, MethodGetStream, parametersOfGetStream, methodGetStreamPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetStream.ShouldNotBeNull();
            parametersOfGetStream.Length.ShouldBe(1);
            methodGetStreamPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_ePMLiveFileStoreInstanceFixture, parametersOfGetStream));
        }

        #endregion

        #region Method Call : (GetStream) (Return Type : Stream) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_GetStream_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var fileName = CreateType<string>();
            var methodGetStreamPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetStream = { fileName };

            // Assert
            parametersOfGetStream.ShouldNotBeNull();
            parametersOfGetStream.Length.ShouldBe(1);
            methodGetStreamPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<EPMLiveFileStore, Stream>(_ePMLiveFileStoreInstance, MethodGetStream, parametersOfGetStream, methodGetStreamPrametersTypes));
        }

        #endregion

        #region Method Call : (GetStream) (Return Type : Stream) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_GetStream_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetStreamPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveFileStoreInstance, MethodGetStream, Fixture, methodGetStreamPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetStreamPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetStream) (Return Type : Stream) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_GetStream_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetStreamPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveFileStoreInstance, MethodGetStream, Fixture, methodGetStreamPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetStreamPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetStream) (Return Type : Stream) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_GetStream_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetStream, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMLiveFileStoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetStream) (Return Type : Stream) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_GetStream_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetStream, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateFileStore) (Return Type : SPDocumentLibrary) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveFileStore_CreateFileStore_Method_Call_Internally(Type[] types)
        {
            var methodCreateFileStorePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveFileStoreInstance, MethodCreateFileStore, Fixture, methodCreateFileStorePrametersTypes);
        }

        #endregion

        #region Method Call : (CreateFileStore) (Return Type : SPDocumentLibrary) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_CreateFileStore_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodCreateFileStorePrametersTypes = null;
            object[] parametersOfCreateFileStore = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCreateFileStore, methodCreateFileStorePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EPMLiveFileStore, SPDocumentLibrary>(_ePMLiveFileStoreInstanceFixture, out exception1, parametersOfCreateFileStore);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EPMLiveFileStore, SPDocumentLibrary>(_ePMLiveFileStoreInstance, MethodCreateFileStore, parametersOfCreateFileStore, methodCreateFileStorePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfCreateFileStore.ShouldBeNull();
            methodCreateFileStorePrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(() => methodInfo.Invoke(_ePMLiveFileStoreInstanceFixture, parametersOfCreateFileStore));
        }

        #endregion

        #region Method Call : (CreateFileStore) (Return Type : SPDocumentLibrary) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_CreateFileStore_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateFileStorePrametersTypes = null;
            object[] parametersOfCreateFileStore = null; // no parameter present

            // Assert
            parametersOfCreateFileStore.ShouldBeNull();
            methodCreateFileStorePrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<EPMLiveFileStore, SPDocumentLibrary>(_ePMLiveFileStoreInstance, MethodCreateFileStore, parametersOfCreateFileStore, methodCreateFileStorePrametersTypes));
        }

        #endregion

        #region Method Call : (CreateFileStore) (Return Type : SPDocumentLibrary) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_CreateFileStore_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodCreateFileStorePrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveFileStoreInstance, MethodCreateFileStore, Fixture, methodCreateFileStorePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCreateFileStorePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateFileStore) (Return Type : SPDocumentLibrary) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_CreateFileStore_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateFileStorePrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveFileStoreInstance, MethodCreateFileStore, Fixture, methodCreateFileStorePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreateFileStorePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateFileStore) (Return Type : SPDocumentLibrary) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_CreateFileStore_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateFileStore, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMLiveFileStoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveFileStore_Dispose_Method_Call_Internally(Type[] types)
        {
            var methodDisposePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveFileStoreInstance, MethodDispose, Fixture, methodDisposePrametersTypes);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_Dispose_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var disposing = CreateType<bool>();
            var methodDisposePrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfDispose = { disposing };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDispose, methodDisposePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePMLiveFileStoreInstanceFixture, parametersOfDispose);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDispose.ShouldNotBeNull();
            parametersOfDispose.Length.ShouldBe(1);
            methodDisposePrametersTypes.Length.ShouldBe(1);
            methodDisposePrametersTypes.Length.ShouldBe(parametersOfDispose.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_Dispose_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var disposing = CreateType<bool>();
            var methodDisposePrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfDispose = { disposing };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ePMLiveFileStoreInstance, MethodDispose, parametersOfDispose, methodDisposePrametersTypes);

            // Assert
            parametersOfDispose.ShouldNotBeNull();
            parametersOfDispose.Length.ShouldBe(1);
            methodDisposePrametersTypes.Length.ShouldBe(1);
            methodDisposePrametersTypes.Length.ShouldBe(parametersOfDispose.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_Dispose_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDisposePrametersTypes = new Type[] { typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveFileStoreInstance, MethodDispose, Fixture, methodDisposePrametersTypes);

            // Assert
            methodDisposePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_Dispose_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDispose, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMLiveFileStoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveFileStore_Dispose_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodDisposePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveFileStoreInstance, MethodDispose, Fixture, methodDisposePrametersTypes);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_Dispose_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _ePMLiveFileStoreInstance.Dispose();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_Dispose_Method_Call_Void_Overloading_Of_1_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodDisposePrametersTypes = null;
            object[] parametersOfDispose = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDispose, methodDisposePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePMLiveFileStoreInstanceFixture, parametersOfDispose);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDispose.ShouldBeNull();
            methodDisposePrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_Dispose_Method_Call_Void_Overloading_Of_1_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodDisposePrametersTypes = null;
            object[] parametersOfDispose = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ePMLiveFileStoreInstance, MethodDispose, parametersOfDispose, methodDisposePrametersTypes);

            // Assert
            parametersOfDispose.ShouldBeNull();
            methodDisposePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_Dispose_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodDisposePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveFileStoreInstance, MethodDispose, Fixture, methodDisposePrametersTypes);

            // Assert
            methodDisposePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveFileStore_Dispose_Method_Call_Overloading_Of_1_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDispose, 1);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMLiveFileStoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}
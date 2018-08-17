using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.TagManager
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.TagManager.TagManager" />)
    ///     and namespace <see cref="EPMLiveCore.TagManager"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class TagManagerTest : AbstractBaseSetupTypedTest<TagManager>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (TagManager) Initializer

        private const string MethodParseData = "ParseData";
        private const string MethodParseRequest = "ParseRequest";
        private const string MethodAddTagOrder = "AddTagOrder";
        private const string MethodGetTag = "GetTag";
        private const string MethodRegisterTag = "RegisterTag";
        private const string MethodRemoveTagOrder = "RemoveTagOrder";
        private const string Field_spWeb = "_spWeb";
        private const string Field_tagOrderRepository = "_tagOrderRepository";
        private const string Field_tagRepository = "_tagRepository";
        private Type _tagManagerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private TagManager _tagManagerInstance;
        private TagManager _tagManagerInstanceFixture;

        #region General Initializer : Class (TagManager) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="TagManager" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _tagManagerInstanceType = typeof(TagManager);
            _tagManagerInstanceFixture = Create(true);
            _tagManagerInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (TagManager)

        #region General Initializer : Class (TagManager) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="TagManager" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodParseData, 0)]
        [TestCase(MethodParseRequest, 0)]
        [TestCase(MethodParseRequest, 1)]
        [TestCase(MethodAddTagOrder, 0)]
        [TestCase(MethodGetTag, 0)]
        [TestCase(MethodRegisterTag, 0)]
        [TestCase(MethodRemoveTagOrder, 0)]
        public void AUT_TagManager_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_tagManagerInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (TagManager) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="TagManager" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_spWeb)]
        [TestCase(Field_tagOrderRepository)]
        [TestCase(Field_tagRepository)]
        public void AUT_TagManager_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_tagManagerInstanceFixture, 
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
        ///     Class (<see cref="TagManager" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodParseData)]
        public void AUT_TagManager_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_tagManagerInstanceFixture,
                                                                              _tagManagerInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="TagManager" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodParseRequest)]
        [TestCase(MethodAddTagOrder)]
        [TestCase(MethodGetTag)]
        [TestCase(MethodRegisterTag)]
        [TestCase(MethodRemoveTagOrder)]
        public void AUT_TagManager_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<TagManager>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (ParseData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TagManager_ParseData_Static_Method_Call_Internally(Type[] types)
        {
            var methodParseDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_tagManagerInstanceFixture, _tagManagerInstanceType, MethodParseData, Fixture, methodParseDataPrametersTypes);
        }

        #endregion

        #region Method Call : (ParseData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TagManager_ParseData_Static_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var listId = CreateType<string>();
            var itemId = CreateType<string>();
            var tagId = CreateType<string>();
            var methodParseDataPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfParseData = { data, listId, itemId, tagId };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodParseData, methodParseDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tagManagerInstanceFixture, parametersOfParseData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfParseData.ShouldNotBeNull();
            parametersOfParseData.Length.ShouldBe(4);
            methodParseDataPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ParseData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TagManager_ParseData_Static_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var listId = CreateType<string>();
            var itemId = CreateType<string>();
            var tagId = CreateType<string>();
            var methodParseDataPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfParseData = { data, listId, itemId, tagId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_tagManagerInstanceFixture, _tagManagerInstanceType, MethodParseData, parametersOfParseData, methodParseDataPrametersTypes);

            // Assert
            parametersOfParseData.ShouldNotBeNull();
            parametersOfParseData.Length.ShouldBe(4);
            methodParseDataPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ParseData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TagManager_ParseData_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodParseData, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ParseData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TagManager_ParseData_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodParseDataPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_tagManagerInstanceFixture, _tagManagerInstanceType, MethodParseData, Fixture, methodParseDataPrametersTypes);

            // Assert
            methodParseDataPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ParseData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TagManager_ParseData_Static_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodParseData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tagManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ParseRequest) (Return Type : XDocument) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TagManager_ParseRequest_Method_Call_Internally(Type[] types)
        {
            var methodParseRequestPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tagManagerInstance, MethodParseRequest, Fixture, methodParseRequestPrametersTypes);
        }

        #endregion

        #region Method Call : (ParseRequest) (Return Type : XDocument) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TagManager_ParseRequest_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var resourceId = CreateType<int>();
            var tagType = CreateType<int>();
            var methodParseRequestPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(int) };
            object[] parametersOfParseRequest = { data, resourceId, tagType };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<TagManager, XDocument>(_tagManagerInstance, MethodParseRequest, parametersOfParseRequest, methodParseRequestPrametersTypes);

            // Assert
            parametersOfParseRequest.ShouldNotBeNull();
            parametersOfParseRequest.Length.ShouldBe(3);
            methodParseRequestPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ParseRequest) (Return Type : XDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TagManager_ParseRequest_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodParseRequestPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tagManagerInstance, MethodParseRequest, Fixture, methodParseRequestPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodParseRequestPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (ParseRequest) (Return Type : XDocument) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TagManager_ParseRequest_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodParseRequestPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(int) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tagManagerInstance, MethodParseRequest, Fixture, methodParseRequestPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodParseRequestPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ParseRequest) (Return Type : XDocument) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TagManager_ParseRequest_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodParseRequest, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_tagManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ParseRequest) (Return Type : XDocument) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TagManager_ParseRequest_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodParseRequest, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ParseRequest) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TagManager_ParseRequest_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodParseRequestPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tagManagerInstance, MethodParseRequest, Fixture, methodParseRequestPrametersTypes);
        }

        #endregion

        #region Method Call : (ParseRequest) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TagManager_ParseRequest_Method_Call_Void_Overloading_Of_1_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var name = CreateType<string>();
            var tagType = CreateType<int>();
            var resourceId = CreateType<int>();
            var methodParseRequestPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(int), typeof(int) };
            object[] parametersOfParseRequest = { data, name, tagType, resourceId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tagManagerInstance, MethodParseRequest, parametersOfParseRequest, methodParseRequestPrametersTypes);

            // Assert
            parametersOfParseRequest.ShouldNotBeNull();
            parametersOfParseRequest.Length.ShouldBe(4);
            methodParseRequestPrametersTypes.Length.ShouldBe(4);
            methodParseRequestPrametersTypes.Length.ShouldBe(parametersOfParseRequest.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ParseRequest) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TagManager_ParseRequest_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodParseRequest, 1);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ParseRequest) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TagManager_ParseRequest_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodParseRequestPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(int), typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tagManagerInstance, MethodParseRequest, Fixture, methodParseRequestPrametersTypes);

            // Assert
            methodParseRequestPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ParseRequest) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TagManager_ParseRequest_Method_Call_Overloading_Of_1_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodParseRequest, 1);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tagManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddTagOrder) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TagManager_AddTagOrder_Method_Call_Internally(Type[] types)
        {
            var methodAddTagOrderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tagManagerInstance, MethodAddTagOrder, Fixture, methodAddTagOrderPrametersTypes);
        }

        #endregion

        #region Method Call : (AddTagOrder) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TagManager_AddTagOrder_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodAddTagOrderPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfAddTagOrder = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodAddTagOrder, methodAddTagOrderPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<TagManager, string>(_tagManagerInstanceFixture, out exception1, parametersOfAddTagOrder);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<TagManager, string>(_tagManagerInstance, MethodAddTagOrder, parametersOfAddTagOrder, methodAddTagOrderPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfAddTagOrder.ShouldNotBeNull();
            parametersOfAddTagOrder.Length.ShouldBe(1);
            methodAddTagOrderPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (AddTagOrder) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TagManager_AddTagOrder_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodAddTagOrderPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfAddTagOrder = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<TagManager, string>(_tagManagerInstance, MethodAddTagOrder, parametersOfAddTagOrder, methodAddTagOrderPrametersTypes);

            // Assert
            parametersOfAddTagOrder.ShouldNotBeNull();
            parametersOfAddTagOrder.Length.ShouldBe(1);
            methodAddTagOrderPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddTagOrder) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TagManager_AddTagOrder_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodAddTagOrderPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tagManagerInstance, MethodAddTagOrder, Fixture, methodAddTagOrderPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodAddTagOrderPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (AddTagOrder) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TagManager_AddTagOrder_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddTagOrderPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tagManagerInstance, MethodAddTagOrder, Fixture, methodAddTagOrderPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAddTagOrderPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddTagOrder) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TagManager_AddTagOrder_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddTagOrder, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_tagManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AddTagOrder) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TagManager_AddTagOrder_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddTagOrder, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTag) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TagManager_GetTag_Method_Call_Internally(Type[] types)
        {
            var methodGetTagPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tagManagerInstance, MethodGetTag, Fixture, methodGetTagPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTag) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TagManager_GetTag_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetTagPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetTag = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetTag, methodGetTagPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<TagManager, string>(_tagManagerInstanceFixture, out exception1, parametersOfGetTag);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<TagManager, string>(_tagManagerInstance, MethodGetTag, parametersOfGetTag, methodGetTagPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetTag.ShouldNotBeNull();
            parametersOfGetTag.Length.ShouldBe(1);
            methodGetTagPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTag) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TagManager_GetTag_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetTagPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetTag = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<TagManager, string>(_tagManagerInstance, MethodGetTag, parametersOfGetTag, methodGetTagPrametersTypes);

            // Assert
            parametersOfGetTag.ShouldNotBeNull();
            parametersOfGetTag.Length.ShouldBe(1);
            methodGetTagPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTag) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TagManager_GetTag_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTagPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tagManagerInstance, MethodGetTag, Fixture, methodGetTagPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTagPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTag) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TagManager_GetTag_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTagPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tagManagerInstance, MethodGetTag, Fixture, methodGetTagPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTagPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTag) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TagManager_GetTag_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTag, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_tagManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTag) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TagManager_GetTag_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTag, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RegisterTag) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TagManager_RegisterTag_Method_Call_Internally(Type[] types)
        {
            var methodRegisterTagPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tagManagerInstance, MethodRegisterTag, Fixture, methodRegisterTagPrametersTypes);
        }

        #endregion

        #region Method Call : (RegisterTag) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TagManager_RegisterTag_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodRegisterTagPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRegisterTag = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRegisterTag, methodRegisterTagPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<TagManager, string>(_tagManagerInstanceFixture, out exception1, parametersOfRegisterTag);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<TagManager, string>(_tagManagerInstance, MethodRegisterTag, parametersOfRegisterTag, methodRegisterTagPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfRegisterTag.ShouldNotBeNull();
            parametersOfRegisterTag.Length.ShouldBe(1);
            methodRegisterTagPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (RegisterTag) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TagManager_RegisterTag_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodRegisterTagPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRegisterTag = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<TagManager, string>(_tagManagerInstance, MethodRegisterTag, parametersOfRegisterTag, methodRegisterTagPrametersTypes);

            // Assert
            parametersOfRegisterTag.ShouldNotBeNull();
            parametersOfRegisterTag.Length.ShouldBe(1);
            methodRegisterTagPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterTag) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TagManager_RegisterTag_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodRegisterTagPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tagManagerInstance, MethodRegisterTag, Fixture, methodRegisterTagPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodRegisterTagPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (RegisterTag) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TagManager_RegisterTag_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRegisterTagPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tagManagerInstance, MethodRegisterTag, Fixture, methodRegisterTagPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRegisterTagPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RegisterTag) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TagManager_RegisterTag_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRegisterTag, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_tagManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RegisterTag) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TagManager_RegisterTag_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRegisterTag, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RemoveTagOrder) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TagManager_RemoveTagOrder_Method_Call_Internally(Type[] types)
        {
            var methodRemoveTagOrderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tagManagerInstance, MethodRemoveTagOrder, Fixture, methodRemoveTagOrderPrametersTypes);
        }

        #endregion

        #region Method Call : (RemoveTagOrder) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TagManager_RemoveTagOrder_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodRemoveTagOrderPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRemoveTagOrder = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRemoveTagOrder, methodRemoveTagOrderPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<TagManager, string>(_tagManagerInstanceFixture, out exception1, parametersOfRemoveTagOrder);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<TagManager, string>(_tagManagerInstance, MethodRemoveTagOrder, parametersOfRemoveTagOrder, methodRemoveTagOrderPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfRemoveTagOrder.ShouldNotBeNull();
            parametersOfRemoveTagOrder.Length.ShouldBe(1);
            methodRemoveTagOrderPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (RemoveTagOrder) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TagManager_RemoveTagOrder_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodRemoveTagOrderPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRemoveTagOrder = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<TagManager, string>(_tagManagerInstance, MethodRemoveTagOrder, parametersOfRemoveTagOrder, methodRemoveTagOrderPrametersTypes);

            // Assert
            parametersOfRemoveTagOrder.ShouldNotBeNull();
            parametersOfRemoveTagOrder.Length.ShouldBe(1);
            methodRemoveTagOrderPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RemoveTagOrder) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TagManager_RemoveTagOrder_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodRemoveTagOrderPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tagManagerInstance, MethodRemoveTagOrder, Fixture, methodRemoveTagOrderPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodRemoveTagOrderPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (RemoveTagOrder) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TagManager_RemoveTagOrder_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRemoveTagOrderPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tagManagerInstance, MethodRemoveTagOrder, Fixture, methodRemoveTagOrderPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRemoveTagOrderPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RemoveTagOrder) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TagManager_RemoveTagOrder_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRemoveTagOrder, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_tagManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RemoveTagOrder) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TagManager_RemoveTagOrder_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRemoveTagOrder, 0);
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
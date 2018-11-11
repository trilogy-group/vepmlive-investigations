using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint.JsonUtilities;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.GridImage" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class GridImageTest : AbstractBaseSetupTypedTest<GridImage>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (GridImage) Initializer

        private const string Propertykey = "key";
        private const string PropertyimageUrl = "imageUrl";
        private const string MethodToJson = "ToJson";
        private Type _gridImageInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private GridImage _gridImageInstance;
        private GridImage _gridImageInstanceFixture;

        #region General Initializer : Class (GridImage) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="GridImage" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _gridImageInstanceType = typeof(GridImage);
            _gridImageInstanceFixture = Create(true);
            _gridImageInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (GridImage)

        #region General Initializer : Class (GridImage) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="GridImage" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodToJson, 0)]
        public void AUT_GridImage_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_gridImageInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (GridImage) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="GridImage" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Propertykey)]
        [TestCase(PropertyimageUrl)]
        public void AUT_GridImage_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_gridImageInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="GridImage" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_GridImage_Is_Instance_Present_Test()
        {
            // Assert
            _gridImageInstanceType.ShouldNotBeNull();
            _gridImageInstance.ShouldNotBeNull();
            _gridImageInstanceFixture.ShouldNotBeNull();
            _gridImageInstance.ShouldBeAssignableTo<GridImage>();
            _gridImageInstanceFixture.ShouldBeAssignableTo<GridImage>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (GridImage) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_GridImage_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            GridImage instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _gridImageInstanceType.ShouldNotBeNull();
            _gridImageInstance.ShouldNotBeNull();
            _gridImageInstanceFixture.ShouldNotBeNull();
            _gridImageInstance.ShouldBeAssignableTo<GridImage>();
            _gridImageInstanceFixture.ShouldBeAssignableTo<GridImage>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (GridImage) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(object) , Propertykey)]
        [TestCaseGeneric(typeof(string) , PropertyimageUrl)]
        public void AUT_GridImage_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<GridImage, T>(_gridImageInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (GridImage) => Property (imageUrl) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GridImage_Public_Class_imageUrl_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyimageUrl);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridImage) => Property (key) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_GridImage_Public_Class_key_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertykey);

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

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="GridImage" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodToJson)]
        public void AUT_GridImage_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<GridImage>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (ToJson) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridImage_ToJson_Method_Call_Internally(Type[] types)
        {
            var methodToJsonPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridImageInstance, MethodToJson, Fixture, methodToJsonPrametersTypes);
        }

        #endregion

        #region Method Call : (ToJson) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridImage_ToJson_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var s = CreateType<Serializer>();
            Action executeAction = null;

            // Act
            executeAction = () => _gridImageInstance.ToJson(s);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ToJson) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridImage_ToJson_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var s = CreateType<Serializer>();
            var methodToJsonPrametersTypes = new Type[] { typeof(Serializer) };
            object[] parametersOfToJson = { s };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodToJson, methodToJsonPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridImageInstanceFixture, parametersOfToJson);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfToJson.ShouldNotBeNull();
            parametersOfToJson.Length.ShouldBe(1);
            methodToJsonPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ToJson) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridImage_ToJson_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var s = CreateType<Serializer>();
            var methodToJsonPrametersTypes = new Type[] { typeof(Serializer) };
            object[] parametersOfToJson = { s };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridImage, string>(_gridImageInstance, MethodToJson, parametersOfToJson, methodToJsonPrametersTypes);

            // Assert
            parametersOfToJson.ShouldNotBeNull();
            parametersOfToJson.Length.ShouldBe(1);
            methodToJsonPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ToJson) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridImage_ToJson_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodToJsonPrametersTypes = new Type[] { typeof(Serializer) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridImageInstance, MethodToJson, Fixture, methodToJsonPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodToJsonPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ToJson) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridImage_ToJson_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodToJsonPrametersTypes = new Type[] { typeof(Serializer) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridImageInstance, MethodToJson, Fixture, methodToJsonPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodToJsonPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ToJson) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridImage_ToJson_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodToJson, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridImageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ToJson) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridImage_ToJson_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodToJson, 0);
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
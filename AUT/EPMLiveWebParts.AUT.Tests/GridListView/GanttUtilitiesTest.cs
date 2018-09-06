using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint.JSGrid;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.GanttUtilities" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class GanttUtilitiesTest : AbstractBaseSetupTypedTest<GanttUtilities>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (GanttUtilities) Initializer

        private const string PropertyImageNames = "ImageNames";
        private const string MethodGanttImage = "GanttImage";
        private const string MethodGetImagesHashTable = "GetImagesHashTable";
        private const string MethodInitGanttImage = "InitGanttImage";
        private const string MethodGetStyleInfo = "GetStyleInfo";
        private const string FieldlookupTypeInfo = "lookupTypeInfo";
        private const string FieldimageNames = "imageNames";
        private Type _ganttUtilitiesInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private GanttUtilities _ganttUtilitiesInstance;
        private GanttUtilities _ganttUtilitiesInstanceFixture;

        #region General Initializer : Class (GanttUtilities) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="GanttUtilities" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _ganttUtilitiesInstanceType = typeof(GanttUtilities);
            _ganttUtilitiesInstanceFixture = Create(true);
            _ganttUtilitiesInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (GanttUtilities)

        #region General Initializer : Class (GanttUtilities) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="GanttUtilities" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGanttImage, 0)]
        [TestCase(MethodGetImagesHashTable, 0)]
        [TestCase(MethodInitGanttImage, 0)]
        [TestCase(MethodGetStyleInfo, 0)]
        public void AUT_GanttUtilities_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_ganttUtilitiesInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (GanttUtilities) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="GanttUtilities" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyImageNames)]
        public void AUT_GanttUtilities_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_ganttUtilitiesInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (GanttUtilities) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="GanttUtilities" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldlookupTypeInfo)]
        [TestCase(FieldimageNames)]
        public void AUT_GanttUtilities_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_ganttUtilitiesInstanceFixture, 
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
        ///     Class (<see cref="GanttUtilities" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_GanttUtilities_Is_Instance_Present_Test()
        {
            // Assert
            _ganttUtilitiesInstanceType.ShouldNotBeNull();
            _ganttUtilitiesInstance.ShouldNotBeNull();
            _ganttUtilitiesInstanceFixture.ShouldNotBeNull();
            _ganttUtilitiesInstance.ShouldBeAssignableTo<GanttUtilities>();
            _ganttUtilitiesInstanceFixture.ShouldBeAssignableTo<GanttUtilities>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (GanttUtilities) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_GanttUtilities_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            GanttUtilities instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _ganttUtilitiesInstanceType.ShouldNotBeNull();
            _ganttUtilitiesInstance.ShouldNotBeNull();
            _ganttUtilitiesInstanceFixture.ShouldNotBeNull();
            _ganttUtilitiesInstance.ShouldBeAssignableTo<GanttUtilities>();
            _ganttUtilitiesInstanceFixture.ShouldBeAssignableTo<GanttUtilities>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (GanttUtilities) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(List<string>) , PropertyImageNames)]
        public void AUT_GanttUtilities_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<GanttUtilities, T>(_ganttUtilitiesInstance, propertyName, Fixture);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="GanttUtilities" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGanttImage)]
        [TestCase(MethodGetImagesHashTable)]
        [TestCase(MethodInitGanttImage)]
        [TestCase(MethodGetStyleInfo)]
        public void AUT_GanttUtilities_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_ganttUtilitiesInstanceFixture,
                                                                              _ganttUtilitiesInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (GanttImage) (Return Type : LookupTypeInfo) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GanttUtilities_GanttImage_Static_Method_Call_Internally(Type[] types)
        {
            var methodGanttImagePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ganttUtilitiesInstanceFixture, _ganttUtilitiesInstanceType, MethodGanttImage, Fixture, methodGanttImagePrametersTypes);
        }

        #endregion

        #region Method Call : (GanttImage) (Return Type : LookupTypeInfo) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GanttUtilities_GanttImage_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var ganttImages = CreateType<Hashtable>();
            var imgNames = CreateType<List<string>>();
            Action executeAction = null;

            // Act
            executeAction = () => GanttUtilities.GanttImage(ganttImages, imgNames);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GanttImage) (Return Type : LookupTypeInfo) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GanttUtilities_GanttImage_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var ganttImages = CreateType<Hashtable>();
            var imgNames = CreateType<List<string>>();
            var methodGanttImagePrametersTypes = new Type[] { typeof(Hashtable), typeof(List<string>) };
            object[] parametersOfGanttImage = { ganttImages, imgNames };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGanttImage, methodGanttImagePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ganttUtilitiesInstanceFixture, _ganttUtilitiesInstanceType, MethodGanttImage, Fixture, methodGanttImagePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<LookupTypeInfo>(_ganttUtilitiesInstanceFixture, _ganttUtilitiesInstanceType, MethodGanttImage, parametersOfGanttImage, methodGanttImagePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_ganttUtilitiesInstanceFixture, parametersOfGanttImage);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGanttImage.ShouldNotBeNull();
            parametersOfGanttImage.Length.ShouldBe(2);
            methodGanttImagePrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GanttImage) (Return Type : LookupTypeInfo) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GanttUtilities_GanttImage_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var ganttImages = CreateType<Hashtable>();
            var imgNames = CreateType<List<string>>();
            var methodGanttImagePrametersTypes = new Type[] { typeof(Hashtable), typeof(List<string>) };
            object[] parametersOfGanttImage = { ganttImages, imgNames };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<LookupTypeInfo>(_ganttUtilitiesInstanceFixture, _ganttUtilitiesInstanceType, MethodGanttImage, parametersOfGanttImage, methodGanttImagePrametersTypes);

            // Assert
            parametersOfGanttImage.ShouldNotBeNull();
            parametersOfGanttImage.Length.ShouldBe(2);
            methodGanttImagePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GanttImage) (Return Type : LookupTypeInfo) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GanttUtilities_GanttImage_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGanttImagePrametersTypes = new Type[] { typeof(Hashtable), typeof(List<string>) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ganttUtilitiesInstanceFixture, _ganttUtilitiesInstanceType, MethodGanttImage, Fixture, methodGanttImagePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGanttImagePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GanttImage) (Return Type : LookupTypeInfo) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GanttUtilities_GanttImage_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGanttImagePrametersTypes = new Type[] { typeof(Hashtable), typeof(List<string>) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ganttUtilitiesInstanceFixture, _ganttUtilitiesInstanceType, MethodGanttImage, Fixture, methodGanttImagePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGanttImagePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GanttImage) (Return Type : LookupTypeInfo) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GanttUtilities_GanttImage_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGanttImage, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ganttUtilitiesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GanttImage) (Return Type : LookupTypeInfo) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GanttUtilities_GanttImage_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGanttImage, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetImagesHashTable) (Return Type : Hashtable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GanttUtilities_GetImagesHashTable_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetImagesHashTablePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ganttUtilitiesInstanceFixture, _ganttUtilitiesInstanceType, MethodGetImagesHashTable, Fixture, methodGetImagesHashTablePrametersTypes);
        }

        #endregion

        #region Method Call : (GetImagesHashTable) (Return Type : Hashtable) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GanttUtilities_GetImagesHashTable_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var dt = CreateType<DataTable>();
            Action executeAction = null;

            // Act
            executeAction = () => GanttUtilities.GetImagesHashTable(dt);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetImagesHashTable) (Return Type : Hashtable) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GanttUtilities_GetImagesHashTable_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var dt = CreateType<DataTable>();
            var methodGetImagesHashTablePrametersTypes = new Type[] { typeof(DataTable) };
            object[] parametersOfGetImagesHashTable = { dt };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetImagesHashTable, methodGetImagesHashTablePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ganttUtilitiesInstanceFixture, _ganttUtilitiesInstanceType, MethodGetImagesHashTable, Fixture, methodGetImagesHashTablePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<Hashtable>(_ganttUtilitiesInstanceFixture, _ganttUtilitiesInstanceType, MethodGetImagesHashTable, parametersOfGetImagesHashTable, methodGetImagesHashTablePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetImagesHashTable.ShouldNotBeNull();
            parametersOfGetImagesHashTable.Length.ShouldBe(1);
            methodGetImagesHashTablePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<Hashtable>(_ganttUtilitiesInstanceFixture, _ganttUtilitiesInstanceType, MethodGetImagesHashTable, parametersOfGetImagesHashTable, methodGetImagesHashTablePrametersTypes));
        }

        #endregion

        #region Method Call : (GetImagesHashTable) (Return Type : Hashtable) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GanttUtilities_GetImagesHashTable_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var dt = CreateType<DataTable>();
            var methodGetImagesHashTablePrametersTypes = new Type[] { typeof(DataTable) };
            object[] parametersOfGetImagesHashTable = { dt };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetImagesHashTable, methodGetImagesHashTablePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ganttUtilitiesInstanceFixture, parametersOfGetImagesHashTable);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetImagesHashTable.ShouldNotBeNull();
            parametersOfGetImagesHashTable.Length.ShouldBe(1);
            methodGetImagesHashTablePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetImagesHashTable) (Return Type : Hashtable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GanttUtilities_GetImagesHashTable_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dt = CreateType<DataTable>();
            var methodGetImagesHashTablePrametersTypes = new Type[] { typeof(DataTable) };
            object[] parametersOfGetImagesHashTable = { dt };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<Hashtable>(_ganttUtilitiesInstanceFixture, _ganttUtilitiesInstanceType, MethodGetImagesHashTable, parametersOfGetImagesHashTable, methodGetImagesHashTablePrametersTypes);

            // Assert
            parametersOfGetImagesHashTable.ShouldNotBeNull();
            parametersOfGetImagesHashTable.Length.ShouldBe(1);
            methodGetImagesHashTablePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetImagesHashTable) (Return Type : Hashtable) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GanttUtilities_GetImagesHashTable_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetImagesHashTablePrametersTypes = new Type[] { typeof(DataTable) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ganttUtilitiesInstanceFixture, _ganttUtilitiesInstanceType, MethodGetImagesHashTable, Fixture, methodGetImagesHashTablePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetImagesHashTablePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetImagesHashTable) (Return Type : Hashtable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GanttUtilities_GetImagesHashTable_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetImagesHashTablePrametersTypes = new Type[] { typeof(DataTable) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ganttUtilitiesInstanceFixture, _ganttUtilitiesInstanceType, MethodGetImagesHashTable, Fixture, methodGetImagesHashTablePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetImagesHashTablePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetImagesHashTable) (Return Type : Hashtable) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GanttUtilities_GetImagesHashTable_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetImagesHashTable, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ganttUtilitiesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetImagesHashTable) (Return Type : Hashtable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GanttUtilities_GetImagesHashTable_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetImagesHashTable, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InitGanttImage) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GanttUtilities_InitGanttImage_Static_Method_Call_Internally(Type[] types)
        {
            var methodInitGanttImagePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ganttUtilitiesInstanceFixture, _ganttUtilitiesInstanceType, MethodInitGanttImage, Fixture, methodInitGanttImagePrametersTypes);
        }

        #endregion

        #region Method Call : (InitGanttImage) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GanttUtilities_InitGanttImage_Static_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var Images = CreateType<Hashtable>();
            var imgNames = CreateType<List<string>>();
            var methodInitGanttImagePrametersTypes = new Type[] { typeof(Hashtable), typeof(List<string>) };
            object[] parametersOfInitGanttImage = { Images, imgNames };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitGanttImage, methodInitGanttImagePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ganttUtilitiesInstanceFixture, parametersOfInitGanttImage);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInitGanttImage.ShouldNotBeNull();
            parametersOfInitGanttImage.Length.ShouldBe(2);
            methodInitGanttImagePrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (InitGanttImage) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GanttUtilities_InitGanttImage_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Images = CreateType<Hashtable>();
            var imgNames = CreateType<List<string>>();
            var methodInitGanttImagePrametersTypes = new Type[] { typeof(Hashtable), typeof(List<string>) };
            object[] parametersOfInitGanttImage = { Images, imgNames };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_ganttUtilitiesInstanceFixture, _ganttUtilitiesInstanceType, MethodInitGanttImage, parametersOfInitGanttImage, methodInitGanttImagePrametersTypes);

            // Assert
            parametersOfInitGanttImage.ShouldNotBeNull();
            parametersOfInitGanttImage.Length.ShouldBe(2);
            methodInitGanttImagePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitGanttImage) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GanttUtilities_InitGanttImage_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodInitGanttImage, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InitGanttImage) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GanttUtilities_InitGanttImage_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInitGanttImagePrametersTypes = new Type[] { typeof(Hashtable), typeof(List<string>) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ganttUtilitiesInstanceFixture, _ganttUtilitiesInstanceType, MethodInitGanttImage, Fixture, methodInitGanttImagePrametersTypes);

            // Assert
            methodInitGanttImagePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitGanttImage) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GanttUtilities_InitGanttImage_Static_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitGanttImage, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ganttUtilitiesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetStyleInfo) (Return Type : GanttStyleInfo) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GanttUtilities_GetStyleInfo_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetStyleInfoPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ganttUtilitiesInstanceFixture, _ganttUtilitiesInstanceType, MethodGetStyleInfo, Fixture, methodGetStyleInfoPrametersTypes);
        }

        #endregion

        #region Method Call : (GetStyleInfo) (Return Type : GanttStyleInfo) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GanttUtilities_GetStyleInfo_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => GanttUtilities.GetStyleInfo();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetStyleInfo) (Return Type : GanttStyleInfo) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GanttUtilities_GetStyleInfo_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetStyleInfoPrametersTypes = null;
            object[] parametersOfGetStyleInfo = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetStyleInfo, methodGetStyleInfoPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ganttUtilitiesInstanceFixture, parametersOfGetStyleInfo);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetStyleInfo.ShouldBeNull();
            methodGetStyleInfoPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetStyleInfo) (Return Type : GanttStyleInfo) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GanttUtilities_GetStyleInfo_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetStyleInfoPrametersTypes = null;
            object[] parametersOfGetStyleInfo = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<GanttStyleInfo>(_ganttUtilitiesInstanceFixture, _ganttUtilitiesInstanceType, MethodGetStyleInfo, parametersOfGetStyleInfo, methodGetStyleInfoPrametersTypes);

            // Assert
            parametersOfGetStyleInfo.ShouldBeNull();
            methodGetStyleInfoPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetStyleInfo) (Return Type : GanttStyleInfo) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GanttUtilities_GetStyleInfo_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetStyleInfoPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ganttUtilitiesInstanceFixture, _ganttUtilitiesInstanceType, MethodGetStyleInfo, Fixture, methodGetStyleInfoPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetStyleInfoPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetStyleInfo) (Return Type : GanttStyleInfo) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GanttUtilities_GetStyleInfo_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetStyleInfoPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ganttUtilitiesInstanceFixture, _ganttUtilitiesInstanceType, MethodGetStyleInfo, Fixture, methodGetStyleInfoPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetStyleInfoPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetStyleInfo) (Return Type : GanttStyleInfo) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GanttUtilities_GetStyleInfo_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetStyleInfo, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ganttUtilitiesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion
    }
}
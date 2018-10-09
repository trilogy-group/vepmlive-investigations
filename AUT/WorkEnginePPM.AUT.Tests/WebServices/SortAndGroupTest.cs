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

namespace WorkEnginePPM
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.SortAndGroup" />)
    ///     and namespace <see cref="WorkEnginePPM"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class SortAndGroupTest : AbstractBaseSetupTypedTest<SortAndGroup>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SortAndGroup) Initializer

        private const string MethodNewGrouping = "NewGrouping";
        private const string MethodFinishedWithGrouping = "FinishedWithGrouping";
        private const string MethodDefineItemValues = "DefineItemValues";
        private const string MethodSortItems = "SortItems";
        private const string MethodDefineGroupingValue = "DefineGroupingValue";
        private const string MethodSortGroup = "SortGroup";
        private const string MethodDoNotSortGroup = "DoNotSortGroup";
        private const string MethodCalculateGrouplingList = "CalculateGrouplingList";
        private const string MethodSetLevels = "SetLevels";
        private const string MethodCopyGroupSubTree = "CopyGroupSubTree";
        private const string MethodGetBackPath = "GetBackPath";
        private const string MethodAddToCons = "AddToCons";
        private const string MethodFixUpAdditions = "FixUpAdditions";
        private const string MethodListify = "Listify";
        private const string MethodElementDetails = "ElementDetails";
        private const string FieldGroup1 = "Group1";
        private const string FieldGroup2 = "Group2";
        private const string FieldGroup3 = "Group3";
        private const string FieldGroupHead1 = "GroupHead1";
        private const string FieldGroupHead2 = "GroupHead2";
        private const string FieldGroupHead3 = "GroupHead3";
        private const string FieldItems = "Items";
        private const string FieldConsolidate = "Consolidate";
        private const string FieldSorted1 = "Sorted1";
        private const string FieldSorted2 = "Sorted2";
        private const string FieldSorted3 = "Sorted3";
        private Type _sortAndGroupInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private SortAndGroup _sortAndGroupInstance;
        private SortAndGroup _sortAndGroupInstanceFixture;

        #region General Initializer : Class (SortAndGroup) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SortAndGroup" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _sortAndGroupInstanceType = typeof(SortAndGroup);
            _sortAndGroupInstanceFixture = Create(true);
            _sortAndGroupInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SortAndGroup)

        #region General Initializer : Class (SortAndGroup) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="SortAndGroup" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodNewGrouping, 0)]
        [TestCase(MethodFinishedWithGrouping, 0)]
        [TestCase(MethodDefineItemValues, 0)]
        [TestCase(MethodSortItems, 0)]
        [TestCase(MethodDefineGroupingValue, 0)]
        [TestCase(MethodSortGroup, 0)]
        [TestCase(MethodDoNotSortGroup, 0)]
        [TestCase(MethodCalculateGrouplingList, 0)]
        [TestCase(MethodSetLevels, 0)]
        [TestCase(MethodCopyGroupSubTree, 0)]
        [TestCase(MethodGetBackPath, 0)]
        [TestCase(MethodAddToCons, 0)]
        [TestCase(MethodFixUpAdditions, 0)]
        [TestCase(MethodListify, 0)]
        [TestCase(MethodElementDetails, 0)]
        public void AUT_SortAndGroup_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_sortAndGroupInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (SortAndGroup) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="SortAndGroup" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldGroup1)]
        [TestCase(FieldGroup2)]
        [TestCase(FieldGroup3)]
        [TestCase(FieldGroupHead1)]
        [TestCase(FieldGroupHead2)]
        [TestCase(FieldGroupHead3)]
        [TestCase(FieldItems)]
        [TestCase(FieldConsolidate)]
        [TestCase(FieldSorted1)]
        [TestCase(FieldSorted2)]
        [TestCase(FieldSorted3)]
        public void AUT_SortAndGroup_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_sortAndGroupInstanceFixture, 
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
        ///     Class (<see cref="SortAndGroup" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_SortAndGroup_Is_Instance_Present_Test()
        {
            // Assert
            _sortAndGroupInstanceType.ShouldNotBeNull();
            _sortAndGroupInstance.ShouldNotBeNull();
            _sortAndGroupInstanceFixture.ShouldNotBeNull();
            _sortAndGroupInstance.ShouldBeAssignableTo<SortAndGroup>();
            _sortAndGroupInstanceFixture.ShouldBeAssignableTo<SortAndGroup>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (SortAndGroup) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_SortAndGroup_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            SortAndGroup instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _sortAndGroupInstanceType.ShouldNotBeNull();
            _sortAndGroupInstance.ShouldNotBeNull();
            _sortAndGroupInstanceFixture.ShouldNotBeNull();
            _sortAndGroupInstance.ShouldBeAssignableTo<SortAndGroup>();
            _sortAndGroupInstanceFixture.ShouldBeAssignableTo<SortAndGroup>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="SortAndGroup" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodNewGrouping)]
        [TestCase(MethodFinishedWithGrouping)]
        [TestCase(MethodDefineItemValues)]
        [TestCase(MethodSortItems)]
        [TestCase(MethodDefineGroupingValue)]
        [TestCase(MethodSortGroup)]
        [TestCase(MethodDoNotSortGroup)]
        [TestCase(MethodCalculateGrouplingList)]
        [TestCase(MethodSetLevels)]
        [TestCase(MethodCopyGroupSubTree)]
        [TestCase(MethodGetBackPath)]
        [TestCase(MethodAddToCons)]
        [TestCase(MethodFixUpAdditions)]
        [TestCase(MethodListify)]
        [TestCase(MethodElementDetails)]
        public void AUT_SortAndGroup_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<SortAndGroup>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (NewGrouping) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SortAndGroup_NewGrouping_Method_Call_Internally(Type[] types)
        {
            var methodNewGroupingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sortAndGroupInstance, MethodNewGrouping, Fixture, methodNewGroupingPrametersTypes);
        }

        #endregion

        #region Method Call : (NewGrouping) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_NewGrouping_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _sortAndGroupInstance.NewGrouping();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (NewGrouping) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_NewGrouping_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodNewGroupingPrametersTypes = null;
            object[] parametersOfNewGrouping = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodNewGrouping, methodNewGroupingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_sortAndGroupInstanceFixture, parametersOfNewGrouping);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfNewGrouping.ShouldBeNull();
            methodNewGroupingPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (NewGrouping) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_NewGrouping_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodNewGroupingPrametersTypes = null;
            object[] parametersOfNewGrouping = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_sortAndGroupInstance, MethodNewGrouping, parametersOfNewGrouping, methodNewGroupingPrametersTypes);

            // Assert
            parametersOfNewGrouping.ShouldBeNull();
            methodNewGroupingPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (NewGrouping) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_NewGrouping_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodNewGroupingPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sortAndGroupInstance, MethodNewGrouping, Fixture, methodNewGroupingPrametersTypes);

            // Assert
            methodNewGroupingPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (NewGrouping) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_NewGrouping_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodNewGrouping, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_sortAndGroupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FinishedWithGrouping) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SortAndGroup_FinishedWithGrouping_Method_Call_Internally(Type[] types)
        {
            var methodFinishedWithGroupingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sortAndGroupInstance, MethodFinishedWithGrouping, Fixture, methodFinishedWithGroupingPrametersTypes);
        }

        #endregion

        #region Method Call : (FinishedWithGrouping) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_FinishedWithGrouping_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _sortAndGroupInstance.FinishedWithGrouping();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (FinishedWithGrouping) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_FinishedWithGrouping_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodFinishedWithGroupingPrametersTypes = null;
            object[] parametersOfFinishedWithGrouping = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodFinishedWithGrouping, methodFinishedWithGroupingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_sortAndGroupInstanceFixture, parametersOfFinishedWithGrouping);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfFinishedWithGrouping.ShouldBeNull();
            methodFinishedWithGroupingPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FinishedWithGrouping) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_FinishedWithGrouping_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodFinishedWithGroupingPrametersTypes = null;
            object[] parametersOfFinishedWithGrouping = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_sortAndGroupInstance, MethodFinishedWithGrouping, parametersOfFinishedWithGrouping, methodFinishedWithGroupingPrametersTypes);

            // Assert
            parametersOfFinishedWithGrouping.ShouldBeNull();
            methodFinishedWithGroupingPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FinishedWithGrouping) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_FinishedWithGrouping_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodFinishedWithGroupingPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sortAndGroupInstance, MethodFinishedWithGrouping, Fixture, methodFinishedWithGroupingPrametersTypes);

            // Assert
            methodFinishedWithGroupingPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FinishedWithGrouping) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_FinishedWithGrouping_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFinishedWithGrouping, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_sortAndGroupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DefineItemValues) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SortAndGroup_DefineItemValues_Method_Call_Internally(Type[] types)
        {
            var methodDefineItemValuesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sortAndGroupInstance, MethodDefineItemValues, Fixture, methodDefineItemValuesPrametersTypes);
        }

        #endregion

        #region Method Call : (DefineItemValues) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_DefineItemValues_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var ItemValue = CreateType<int>();
            var grp1Val = CreateType<int>();
            var grp2Val = CreateType<int>();
            var grp3Val = CreateType<int>();
            var ElStr = CreateType<string>();
            var ElDStr = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _sortAndGroupInstance.DefineItemValues(ItemValue, grp1Val, grp2Val, grp3Val, ElStr, ElDStr);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DefineItemValues) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_DefineItemValues_Method_Call_Void_With_6_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var ItemValue = CreateType<int>();
            var grp1Val = CreateType<int>();
            var grp2Val = CreateType<int>();
            var grp3Val = CreateType<int>();
            var ElStr = CreateType<string>();
            var ElDStr = CreateType<string>();
            var methodDefineItemValuesPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(int), typeof(int), typeof(string), typeof(string) };
            object[] parametersOfDefineItemValues = { ItemValue, grp1Val, grp2Val, grp3Val, ElStr, ElDStr };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDefineItemValues, methodDefineItemValuesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_sortAndGroupInstanceFixture, parametersOfDefineItemValues);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDefineItemValues.ShouldNotBeNull();
            parametersOfDefineItemValues.Length.ShouldBe(6);
            methodDefineItemValuesPrametersTypes.Length.ShouldBe(6);
            methodDefineItemValuesPrametersTypes.Length.ShouldBe(parametersOfDefineItemValues.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DefineItemValues) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_DefineItemValues_Method_Call_Void_With_6_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var ItemValue = CreateType<int>();
            var grp1Val = CreateType<int>();
            var grp2Val = CreateType<int>();
            var grp3Val = CreateType<int>();
            var ElStr = CreateType<string>();
            var ElDStr = CreateType<string>();
            var methodDefineItemValuesPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(int), typeof(int), typeof(string), typeof(string) };
            object[] parametersOfDefineItemValues = { ItemValue, grp1Val, grp2Val, grp3Val, ElStr, ElDStr };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_sortAndGroupInstance, MethodDefineItemValues, parametersOfDefineItemValues, methodDefineItemValuesPrametersTypes);

            // Assert
            parametersOfDefineItemValues.ShouldNotBeNull();
            parametersOfDefineItemValues.Length.ShouldBe(6);
            methodDefineItemValuesPrametersTypes.Length.ShouldBe(6);
            methodDefineItemValuesPrametersTypes.Length.ShouldBe(parametersOfDefineItemValues.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DefineItemValues) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_DefineItemValues_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDefineItemValues, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DefineItemValues) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_DefineItemValues_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDefineItemValuesPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(int), typeof(int), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sortAndGroupInstance, MethodDefineItemValues, Fixture, methodDefineItemValuesPrametersTypes);

            // Assert
            methodDefineItemValuesPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DefineItemValues) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_DefineItemValues_Method_Call_With_6_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDefineItemValues, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_sortAndGroupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SortItems) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SortAndGroup_SortItems_Method_Call_Internally(Type[] types)
        {
            var methodSortItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sortAndGroupInstance, MethodSortItems, Fixture, methodSortItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (SortItems) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_SortItems_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sortorder = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _sortAndGroupInstance.SortItems(sortorder);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (SortItems) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_SortItems_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sortorder = CreateType<int>();
            var methodSortItemsPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfSortItems = { sortorder };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSortItems, methodSortItemsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_sortAndGroupInstanceFixture, parametersOfSortItems);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSortItems.ShouldNotBeNull();
            parametersOfSortItems.Length.ShouldBe(1);
            methodSortItemsPrametersTypes.Length.ShouldBe(1);
            methodSortItemsPrametersTypes.Length.ShouldBe(parametersOfSortItems.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SortItems) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_SortItems_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sortorder = CreateType<int>();
            var methodSortItemsPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfSortItems = { sortorder };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_sortAndGroupInstance, MethodSortItems, parametersOfSortItems, methodSortItemsPrametersTypes);

            // Assert
            parametersOfSortItems.ShouldNotBeNull();
            parametersOfSortItems.Length.ShouldBe(1);
            methodSortItemsPrametersTypes.Length.ShouldBe(1);
            methodSortItemsPrametersTypes.Length.ShouldBe(parametersOfSortItems.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SortItems) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_SortItems_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSortItems, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SortItems) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_SortItems_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSortItemsPrametersTypes = new Type[] { typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sortAndGroupInstance, MethodSortItems, Fixture, methodSortItemsPrametersTypes);

            // Assert
            methodSortItemsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SortItems) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_SortItems_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSortItems, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_sortAndGroupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DefineGroupingValue) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SortAndGroup_DefineGroupingValue_Method_Call_Internally(Type[] types)
        {
            var methodDefineGroupingValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sortAndGroupInstance, MethodDefineGroupingValue, Fixture, methodDefineGroupingValuePrametersTypes);
        }

        #endregion

        #region Method Call : (DefineGroupingValue) (Return Type : void) No Exception Thrown

        //[Test]
        //[Timeout(TestsTimeOut)]
        //[Category("AUT MethodCallTest")]
        //public void AUT_SortAndGroup_DefineGroupingValue_Method_Call_Void_With_5_Parameters_No_Exception_Thrown_Test()
        //{
        //    // Arrange
        //    var group = CreateType<int>();
        //    var parval = CreateType<int>();
        //    var thisval = CreateType<int>();
        //    var ElStr = CreateType<string>();
        //    var ElDStr = CreateType<string>();
        //    var methodDefineGroupingValuePrametersTypes = new Type[] { typeof(int), typeof(int), typeof(int), typeof(string), typeof(string) };
        //    object[] parametersOfDefineGroupingValue = { group, parval, thisval, ElStr, ElDStr };
        //    Exception exception = null;
        //    var methodInfo = GetMethodInfo(MethodDefineGroupingValue, methodDefineGroupingValuePrametersTypes, out exception);

        //    // Act
        //    Action currentAction = () => methodInfo.Invoke(_sortAndGroupInstanceFixture, parametersOfDefineGroupingValue);

        //    // Assert
        //    methodInfo.ShouldNotBeNull();
        //    exception.ShouldBeNull();
        //    parametersOfDefineGroupingValue.ShouldNotBeNull();
        //    parametersOfDefineGroupingValue.Length.ShouldBe(5);
        //    methodDefineGroupingValuePrametersTypes.Length.ShouldBe(5);
        //    methodDefineGroupingValuePrametersTypes.Length.ShouldBe(parametersOfDefineGroupingValue.Length);
        //    Should.NotThrow(currentAction);
        //}

        #endregion

        #region Method Call : (DefineGroupingValue) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_DefineGroupingValue_Method_Call_Void_With_5_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var group = CreateType<int>();
            var parval = CreateType<int>();
            var thisval = CreateType<int>();
            var ElStr = CreateType<string>();
            var ElDStr = CreateType<string>();
            var methodDefineGroupingValuePrametersTypes = new Type[] { typeof(int), typeof(int), typeof(int), typeof(string), typeof(string) };
            object[] parametersOfDefineGroupingValue = { group, parval, thisval, ElStr, ElDStr };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_sortAndGroupInstance, MethodDefineGroupingValue, parametersOfDefineGroupingValue, methodDefineGroupingValuePrametersTypes);

            // Assert
            parametersOfDefineGroupingValue.ShouldNotBeNull();
            parametersOfDefineGroupingValue.Length.ShouldBe(5);
            methodDefineGroupingValuePrametersTypes.Length.ShouldBe(5);
            methodDefineGroupingValuePrametersTypes.Length.ShouldBe(parametersOfDefineGroupingValue.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DefineGroupingValue) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_DefineGroupingValue_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDefineGroupingValue, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DefineGroupingValue) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_DefineGroupingValue_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDefineGroupingValuePrametersTypes = new Type[] { typeof(int), typeof(int), typeof(int), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sortAndGroupInstance, MethodDefineGroupingValue, Fixture, methodDefineGroupingValuePrametersTypes);

            // Assert
            methodDefineGroupingValuePrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DefineGroupingValue) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_DefineGroupingValue_Method_Call_With_5_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDefineGroupingValue, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_sortAndGroupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SortGroup) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SortAndGroup_SortGroup_Method_Call_Internally(Type[] types)
        {
            var methodSortGroupPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sortAndGroupInstance, MethodSortGroup, Fixture, methodSortGroupPrametersTypes);
        }

        #endregion

        #region Method Call : (SortGroup) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_SortGroup_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var group = CreateType<int>();
            var sortorder = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _sortAndGroupInstance.SortGroup(group, sortorder);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (SortGroup) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_SortGroup_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var group = CreateType<int>();
            var sortorder = CreateType<int>();
            var methodSortGroupPrametersTypes = new Type[] { typeof(int), typeof(int) };
            object[] parametersOfSortGroup = { group, sortorder };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSortGroup, methodSortGroupPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_sortAndGroupInstanceFixture, parametersOfSortGroup);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSortGroup.ShouldNotBeNull();
            parametersOfSortGroup.Length.ShouldBe(2);
            methodSortGroupPrametersTypes.Length.ShouldBe(2);
            methodSortGroupPrametersTypes.Length.ShouldBe(parametersOfSortGroup.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SortGroup) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_SortGroup_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var group = CreateType<int>();
            var sortorder = CreateType<int>();
            var methodSortGroupPrametersTypes = new Type[] { typeof(int), typeof(int) };
            object[] parametersOfSortGroup = { group, sortorder };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_sortAndGroupInstance, MethodSortGroup, parametersOfSortGroup, methodSortGroupPrametersTypes);

            // Assert
            parametersOfSortGroup.ShouldNotBeNull();
            parametersOfSortGroup.Length.ShouldBe(2);
            methodSortGroupPrametersTypes.Length.ShouldBe(2);
            methodSortGroupPrametersTypes.Length.ShouldBe(parametersOfSortGroup.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SortGroup) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_SortGroup_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSortGroup, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SortGroup) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_SortGroup_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSortGroupPrametersTypes = new Type[] { typeof(int), typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sortAndGroupInstance, MethodSortGroup, Fixture, methodSortGroupPrametersTypes);

            // Assert
            methodSortGroupPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SortGroup) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_SortGroup_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSortGroup, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_sortAndGroupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoNotSortGroup) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SortAndGroup_DoNotSortGroup_Method_Call_Internally(Type[] types)
        {
            var methodDoNotSortGroupPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sortAndGroupInstance, MethodDoNotSortGroup, Fixture, methodDoNotSortGroupPrametersTypes);
        }

        #endregion

        #region Method Call : (DoNotSortGroup) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_DoNotSortGroup_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var group = CreateType<int>();
            var methodDoNotSortGroupPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfDoNotSortGroup = { group };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_sortAndGroupInstance, MethodDoNotSortGroup, parametersOfDoNotSortGroup, methodDoNotSortGroupPrametersTypes);

            // Assert
            parametersOfDoNotSortGroup.ShouldNotBeNull();
            parametersOfDoNotSortGroup.Length.ShouldBe(1);
            methodDoNotSortGroupPrametersTypes.Length.ShouldBe(1);
            methodDoNotSortGroupPrametersTypes.Length.ShouldBe(parametersOfDoNotSortGroup.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoNotSortGroup) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_DoNotSortGroup_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDoNotSortGroup, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DoNotSortGroup) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_DoNotSortGroup_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDoNotSortGroupPrametersTypes = new Type[] { typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sortAndGroupInstance, MethodDoNotSortGroup, Fixture, methodDoNotSortGroupPrametersTypes);

            // Assert
            methodDoNotSortGroupPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoNotSortGroup) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_DoNotSortGroup_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDoNotSortGroup, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_sortAndGroupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CalculateGrouplingList) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SortAndGroup_CalculateGrouplingList_Method_Call_Internally(Type[] types)
        {
            var methodCalculateGrouplingListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sortAndGroupInstance, MethodCalculateGrouplingList, Fixture, methodCalculateGrouplingListPrametersTypes);
        }

        #endregion

        #region Method Call : (CalculateGrouplingList) (Return Type : int) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_CalculateGrouplingList_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var fullpathflag = CreateType<int>();
            var GroupToLevel = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _sortAndGroupInstance.CalculateGrouplingList(fullpathflag, GroupToLevel);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CalculateGrouplingList) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_CalculateGrouplingList_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var fullpathflag = CreateType<int>();
            var GroupToLevel = CreateType<int>();
            var methodCalculateGrouplingListPrametersTypes = new Type[] { typeof(int), typeof(int) };
            object[] parametersOfCalculateGrouplingList = { fullpathflag, GroupToLevel };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCalculateGrouplingList, methodCalculateGrouplingListPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<SortAndGroup, int>(_sortAndGroupInstanceFixture, out exception1, parametersOfCalculateGrouplingList);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<SortAndGroup, int>(_sortAndGroupInstance, MethodCalculateGrouplingList, parametersOfCalculateGrouplingList, methodCalculateGrouplingListPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfCalculateGrouplingList.ShouldNotBeNull();
            parametersOfCalculateGrouplingList.Length.ShouldBe(2);
            methodCalculateGrouplingListPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (CalculateGrouplingList) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_CalculateGrouplingList_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var fullpathflag = CreateType<int>();
            var GroupToLevel = CreateType<int>();
            var methodCalculateGrouplingListPrametersTypes = new Type[] { typeof(int), typeof(int) };
            object[] parametersOfCalculateGrouplingList = { fullpathflag, GroupToLevel };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCalculateGrouplingList, methodCalculateGrouplingListPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<SortAndGroup, int>(_sortAndGroupInstanceFixture, out exception1, parametersOfCalculateGrouplingList);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<SortAndGroup, int>(_sortAndGroupInstance, MethodCalculateGrouplingList, parametersOfCalculateGrouplingList, methodCalculateGrouplingListPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfCalculateGrouplingList.ShouldNotBeNull();
            parametersOfCalculateGrouplingList.Length.ShouldBe(2);
            methodCalculateGrouplingListPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (CalculateGrouplingList) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_CalculateGrouplingList_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var fullpathflag = CreateType<int>();
            var GroupToLevel = CreateType<int>();
            var methodCalculateGrouplingListPrametersTypes = new Type[] { typeof(int), typeof(int) };
            object[] parametersOfCalculateGrouplingList = { fullpathflag, GroupToLevel };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<SortAndGroup, int>(_sortAndGroupInstance, MethodCalculateGrouplingList, parametersOfCalculateGrouplingList, methodCalculateGrouplingListPrametersTypes);

            // Assert
            parametersOfCalculateGrouplingList.ShouldNotBeNull();
            parametersOfCalculateGrouplingList.Length.ShouldBe(2);
            methodCalculateGrouplingListPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CalculateGrouplingList) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_CalculateGrouplingList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCalculateGrouplingListPrametersTypes = new Type[] { typeof(int), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sortAndGroupInstance, MethodCalculateGrouplingList, Fixture, methodCalculateGrouplingListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCalculateGrouplingListPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CalculateGrouplingList) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_CalculateGrouplingList_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCalculateGrouplingList, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_sortAndGroupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CalculateGrouplingList) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_CalculateGrouplingList_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCalculateGrouplingList, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetLevels) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SortAndGroup_SetLevels_Method_Call_Internally(Type[] types)
        {
            var methodSetLevelsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sortAndGroupInstance, MethodSetLevels, Fixture, methodSetLevelsPrametersTypes);
        }

        #endregion
        
        #region Method Call : (SetLevels) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_SetLevels_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetLevels, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion
        
        #region Method Call : (SetLevels) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_SetLevels_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetLevels, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_sortAndGroupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CopyGroupSubTree) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SortAndGroup_CopyGroupSubTree_Method_Call_Internally(Type[] types)
        {
            var methodCopyGroupSubTreePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sortAndGroupInstance, MethodCopyGroupSubTree, Fixture, methodCopyGroupSubTreePrametersTypes);
        }

        #endregion
        
        #region Method Call : (CopyGroupSubTree) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_CopyGroupSubTree_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCopyGroupSubTree, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion
        
        #region Method Call : (CopyGroupSubTree) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_CopyGroupSubTree_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCopyGroupSubTree, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_sortAndGroupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetBackPath) (Return Type : GroupField) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SortAndGroup_GetBackPath_Method_Call_Internally(Type[] types)
        {
            var methodGetBackPathPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sortAndGroupInstance, MethodGetBackPath, Fixture, methodGetBackPathPrametersTypes);
        }

        #endregion

        #region Method Call : (GetBackPath) (Return Type : GroupField) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_GetBackPath_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetBackPathPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sortAndGroupInstance, MethodGetBackPath, Fixture, methodGetBackPathPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetBackPathPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetBackPath) (Return Type : GroupField) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_GetBackPath_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetBackPathPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(int) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sortAndGroupInstance, MethodGetBackPath, Fixture, methodGetBackPathPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetBackPathPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetBackPath) (Return Type : GroupField) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_GetBackPath_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetBackPath, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_sortAndGroupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetBackPath) (Return Type : GroupField) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_GetBackPath_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetBackPath, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddToCons) (Return Type : Consolid) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SortAndGroup_AddToCons_Method_Call_Internally(Type[] types)
        {
            var methodAddToConsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sortAndGroupInstance, MethodAddToCons, Fixture, methodAddToConsPrametersTypes);
        }

        #endregion

        #region Method Call : (AddToCons) (Return Type : Consolid) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_AddToCons_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddToCons, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_sortAndGroupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AddToCons) (Return Type : Consolid) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_AddToCons_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddToCons, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FixUpAdditions) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SortAndGroup_FixUpAdditions_Method_Call_Internally(Type[] types)
        {
            var methodFixUpAdditionsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sortAndGroupInstance, MethodFixUpAdditions, Fixture, methodFixUpAdditionsPrametersTypes);
        }

        #endregion
        
        #region Method Call : (FixUpAdditions) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_FixUpAdditions_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodFixUpAdditions, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion
        
        #region Method Call : (FixUpAdditions) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_FixUpAdditions_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFixUpAdditions, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_sortAndGroupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Listify) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SortAndGroup_Listify_Method_Call_Internally(Type[] types)
        {
            var methodListifyPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sortAndGroupInstance, MethodListify, Fixture, methodListifyPrametersTypes);
        }

        #endregion
        
        #region Method Call : (Listify) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_Listify_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodListify, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion
        
        #region Method Call : (Listify) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_Listify_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodListify, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_sortAndGroupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ElementDetails) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SortAndGroup_ElementDetails_Method_Call_Internally(Type[] types)
        {
            var methodElementDetailsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sortAndGroupInstance, MethodElementDetails, Fixture, methodElementDetailsPrametersTypes);
        }

        #endregion

        #region Method Call : (ElementDetails) (Return Type : int) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_ElementDetails_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var element = CreateType<int>();
            var group = CreateType<int>();
            var uid = CreateType<int>();
            var level = CreateType<int>();
            var grp_level = CreateType<int>();
            var sVal = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _sortAndGroupInstance.ElementDetails(element, ref group, ref uid, ref level, ref grp_level, ref sVal);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ElementDetails) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_ElementDetails_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var element = CreateType<int>();
            var group = CreateType<int>();
            var uid = CreateType<int>();
            var level = CreateType<int>();
            var grp_level = CreateType<int>();
            var sVal = CreateType<string>();
            var methodElementDetailsPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(int), typeof(int), typeof(int), typeof(string) };
            object[] parametersOfElementDetails = { element, group, uid, level, grp_level, sVal };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodElementDetails, methodElementDetailsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<SortAndGroup, int>(_sortAndGroupInstanceFixture, out exception1, parametersOfElementDetails);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<SortAndGroup, int>(_sortAndGroupInstance, MethodElementDetails, parametersOfElementDetails, methodElementDetailsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfElementDetails.ShouldNotBeNull();
            parametersOfElementDetails.Length.ShouldBe(6);
            methodElementDetailsPrametersTypes.Length.ShouldBe(6);
        }

        #endregion

        #region Method Call : (ElementDetails) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_ElementDetails_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var element = CreateType<int>();
            var group = CreateType<int>();
            var uid = CreateType<int>();
            var level = CreateType<int>();
            var grp_level = CreateType<int>();
            var sVal = CreateType<string>();
            var methodElementDetailsPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(int), typeof(int), typeof(int), typeof(string) };
            object[] parametersOfElementDetails = { element, group, uid, level, grp_level, sVal };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodElementDetails, methodElementDetailsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<SortAndGroup, int>(_sortAndGroupInstanceFixture, out exception1, parametersOfElementDetails);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<SortAndGroup, int>(_sortAndGroupInstance, MethodElementDetails, parametersOfElementDetails, methodElementDetailsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfElementDetails.ShouldNotBeNull();
            parametersOfElementDetails.Length.ShouldBe(6);
            methodElementDetailsPrametersTypes.Length.ShouldBe(6);
        }

        #endregion

        #region Method Call : (ElementDetails) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_ElementDetails_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var element = CreateType<int>();
            var group = CreateType<int>();
            var uid = CreateType<int>();
            var level = CreateType<int>();
            var grp_level = CreateType<int>();
            var sVal = CreateType<string>();
            var methodElementDetailsPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(int), typeof(int), typeof(int), typeof(string) };
            object[] parametersOfElementDetails = { element, group, uid, level, grp_level, sVal };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<SortAndGroup, int>(_sortAndGroupInstance, MethodElementDetails, parametersOfElementDetails, methodElementDetailsPrametersTypes);

            // Assert
            parametersOfElementDetails.ShouldNotBeNull();
            parametersOfElementDetails.Length.ShouldBe(6);
            methodElementDetailsPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ElementDetails) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_ElementDetails_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodElementDetailsPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(int), typeof(int), typeof(int), typeof(string) };
            const int parametersCount = 6;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sortAndGroupInstance, MethodElementDetails, Fixture, methodElementDetailsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodElementDetailsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ElementDetails) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_ElementDetails_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodElementDetails, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_sortAndGroupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ElementDetails) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SortAndGroup_ElementDetails_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodElementDetails, 0);
            const int parametersCount = 6;

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
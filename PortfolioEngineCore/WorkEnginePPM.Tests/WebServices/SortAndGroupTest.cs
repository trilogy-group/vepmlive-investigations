using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace WorkEnginePPM.Tests.WebServices
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class SortAndGroupTest
    {
        private SortAndGroup _testObj;
        private PrivateObject _privateObj;

        private const string DummyString = "DummyString";
        private const string DummyAbc = "abc";
        private const string DummyXyz = "xyz";
        private const int DummyNegative = -1;
        private const int DummyZero = 0;
        private const int DummyOne = 1;
        private const int DummyTwo = 2;
        private const int DummyThree = 3;
        private const int DummyFour = 4;
        private const int DummyFive = 5;
        private const int DummySix = 6;

        private const int SortDescending = 0;
        private const int SortAscending = 1;

        private const string Group1Field = "Group1";
        private const string Group2Field = "Group2";
        private const string Group3Field = "Group3";
        private const string GroupHead1Field = "GroupHead1";
        private const string GroupHead2Field = "GroupHead2";
        private const string GroupHead3Field = "GroupHead3";
        private const string ItemsField = "Items";
        private const string ConsolidateField = "Consolidate";
        private const string Sorted1Field = "Sorted1";
        private const string Sorted2Field = "Sorted2";
        private const string Sorted3Field = "Sorted3";

        [TestInitialize]
        public void TestInitialize()
        {
            _testObj = new SortAndGroup();
            _privateObj = new PrivateObject(_testObj);
        }

        [TestMethod]
        public void NewGrouping_OnValidCall_ConfirmResult()
        {
            // Arrange, Act
            _testObj.NewGrouping();

            // Assert
            var group1 = _privateObj.GetFieldOrProperty(Group1Field);
            var group2 = _privateObj.GetFieldOrProperty(Group2Field);
            var group3 = _privateObj.GetFieldOrProperty(Group3Field);
            var groupHead1 = _privateObj.GetFieldOrProperty(GroupHead1Field);
            var groupHead2 = _privateObj.GetFieldOrProperty(GroupHead2Field);
            var groupHead3 = _privateObj.GetFieldOrProperty(GroupHead3Field);
            var items = _privateObj.GetFieldOrProperty(ItemsField);
            var consolidate = _privateObj.GetFieldOrProperty(ConsolidateField);
            var sorted1 = _privateObj.GetFieldOrProperty(Sorted1Field);
            var sorted2 = _privateObj.GetFieldOrProperty(Sorted2Field);
            var sorted3 = _privateObj.GetFieldOrProperty(Sorted3Field);
            this.ShouldSatisfyAllConditions(
                () => group1.ShouldNotBeNull(),
                () => group2.ShouldNotBeNull(),
                () => group3.ShouldNotBeNull(),
                () => groupHead1.ShouldNotBeNull(),
                () => groupHead2.ShouldNotBeNull(),
                () => groupHead3.ShouldNotBeNull(),
                () => items.ShouldNotBeNull(),
                () => consolidate.ShouldNotBeNull(),
                () => sorted1.ShouldNotBeNull(),
                () => sorted2.ShouldNotBeNull(),
                () => sorted3.ShouldNotBeNull());
        }

        [TestMethod]
        public void FinishedWithGrouping_OnValidCall_ConfirmResult()
        {
            // Arrange
            _testObj.NewGrouping();

            // Act
            _testObj.FinishedWithGrouping();

            // Assert
            var group1 = _privateObj.GetFieldOrProperty(Group1Field);
            var group2 = _privateObj.GetFieldOrProperty(Group2Field);
            var group3 = _privateObj.GetFieldOrProperty(Group3Field);
            var groupHead1 = _privateObj.GetFieldOrProperty(GroupHead1Field);
            var groupHead2 = _privateObj.GetFieldOrProperty(GroupHead2Field);
            var groupHead3 = _privateObj.GetFieldOrProperty(GroupHead3Field);
            var items = _privateObj.GetFieldOrProperty(ItemsField);
            var consolidate = _privateObj.GetFieldOrProperty(ConsolidateField);
            var sorted1 = _privateObj.GetFieldOrProperty(Sorted1Field);
            var sorted2 = _privateObj.GetFieldOrProperty(Sorted2Field);
            var sorted3 = _privateObj.GetFieldOrProperty(Sorted3Field);
            this.ShouldSatisfyAllConditions(
                () => group1.ShouldBeNull(),
                () => group2.ShouldBeNull(),
                () => group3.ShouldBeNull(),
                () => groupHead1.ShouldBeNull(),
                () => groupHead2.ShouldBeNull(),
                () => groupHead3.ShouldBeNull(),
                () => items.ShouldBeNull(),
                () => consolidate.ShouldBeNull(),
                () => sorted1.ShouldBeNull(),
                () => sorted2.ShouldBeNull(),
                () => sorted3.ShouldBeNull());
        }

        [TestMethod]
        public void DefineItemValues_OnValidCall_ConfirmResult()
        {
            // Arrange
            _testObj.NewGrouping();

            // Act
            _testObj.DefineItemValues(DummyOne, DummyOne, DummyOne, DummyOne, DummyString, DummyString);

            // Assert
            var items = (List<tagItem>)_privateObj.GetFieldOrProperty(ItemsField);
            this.ShouldSatisfyAllConditions(
                () => items.ShouldNotBeNull(),
                () => items.Count.ShouldBe(1),
                () => items[0].ItemVal.ShouldBe(DummyOne),
                () => items[0].Group1.ShouldBe(DummyOne),
                () => items[0].Group2.ShouldBe(DummyOne),
                () => items[0].Group3.ShouldBe(DummyOne),
                () => items[0].sVal.ShouldBe(DummyString),
                () => items[0].sDVal.ShouldBe(DummyString));
        }

        [TestMethod]
        public void SortItems_OnAscendingOrder_ConfirmResult()
        {
            // Arrange
            _testObj.NewGrouping();
            _testObj.DefineItemValues(DummyOne, DummyOne, DummyOne, DummyOne, DummyXyz, DummyXyz);
            _testObj.DefineItemValues(DummyTwo, DummyTwo, DummyTwo, DummyTwo, DummyAbc, DummyAbc);

            // Act
            _testObj.SortItems(SortAscending);

            // Assert
            var items = (List<tagItem>)_privateObj.GetFieldOrProperty(ItemsField);
            this.ShouldSatisfyAllConditions(
                () => items.ShouldNotBeNull(),
                () => items[0].ItemVal.ShouldBe(DummyTwo),
                () => items[1].ItemVal.ShouldBe(DummyOne));
        }

        [TestMethod]
        public void SortItems_OnDescendingOrder_ConfirmResult()
        {
            // Arrange
            _testObj.NewGrouping();
            _testObj.DefineItemValues(DummyOne, DummyOne, DummyOne, DummyOne, DummyAbc, DummyAbc);
            _testObj.DefineItemValues(DummyTwo, DummyTwo, DummyTwo, DummyTwo, DummyXyz, DummyXyz);

            // Act
            _testObj.SortItems(SortDescending);

            // Assert
            var items = (List<tagItem>)_privateObj.GetFieldOrProperty(ItemsField);
            this.ShouldSatisfyAllConditions(
                () => items.ShouldNotBeNull(),
                () => items[0].ItemVal.ShouldBe(DummyTwo),
                () => items[1].ItemVal.ShouldBe(DummyOne));
        }

        [TestMethod]
        public void DefineGroupingValue_WhenGroupOne_ConfirmResult()
        {
            // Arrange
            _testObj.NewGrouping();

            // Act
            _testObj.DefineGroupingValue(DummyOne, DummyOne, DummyOne, DummyString, DummyString);

            // Assert
            var group1 = (List<GroupField>)_privateObj.GetFieldOrProperty(Group1Field);
            this.ShouldSatisfyAllConditions(
                () => group1.ShouldNotBeNull(),
                () => group1.Count.ShouldBe(1),
                () => group1[0].Parent_UID.ShouldBe(DummyOne),
                () => group1[0].This_UID.ShouldBe(DummyOne),
                () => group1[0].sVal.ShouldBe(DummyString),
                () => group1[0].sDVal.ShouldBe(DummyString),
                () => group1[0].Group.ShouldBe(DummyOne));
        }

        [TestMethod]
        public void DefineGroupingValue_WhenGroupTwo_ConfirmResult()
        {
            // Arrange
            _testObj.NewGrouping();

            // Act
            _testObj.DefineGroupingValue(DummyTwo, DummyTwo, DummyTwo, DummyString, DummyString);

            // Assert
            var group2 = (List<GroupField>)_privateObj.GetFieldOrProperty(Group2Field);
            this.ShouldSatisfyAllConditions(
                () => group2.ShouldNotBeNull(),
                () => group2.Count.ShouldBe(1),
                () => group2[0].Parent_UID.ShouldBe(DummyTwo),
                () => group2[0].This_UID.ShouldBe(DummyTwo),
                () => group2[0].sVal.ShouldBe(DummyString),
                () => group2[0].sDVal.ShouldBe(DummyString),
                () => group2[0].Group.ShouldBe(DummyTwo));
        }

        [TestMethod]
        public void DefineGroupingValue_WhenGroupThree_ConfirmResult()
        {
            // Arrange
            _testObj.NewGrouping();

            // Act
            _testObj.DefineGroupingValue(DummyThree, DummyThree, DummyThree, DummyString, DummyString);

            // Assert
            var group3 = (List<GroupField>)_privateObj.GetFieldOrProperty(Group3Field);
            this.ShouldSatisfyAllConditions(
                () => group3.ShouldNotBeNull(),
                () => group3.Count.ShouldBe(1),
                () => group3[0].Parent_UID.ShouldBe(DummyThree),
                () => group3[0].This_UID.ShouldBe(DummyThree),
                () => group3[0].sVal.ShouldBe(DummyString),
                () => group3[0].sDVal.ShouldBe(DummyString),
                () => group3[0].Group.ShouldBe(DummyThree));
        }

        [TestMethod]
        public void SortGroup_WhenGroup1AscendingOrder_ConfirmResult()
        {
            // Arrange
            _testObj.NewGrouping();
            _testObj.DefineGroupingValue(DummyOne, DummyOne, DummyOne, DummyXyz, DummyString);
            _testObj.DefineGroupingValue(DummyOne, DummyTwo, DummyTwo, DummyAbc, DummyString);

            // Act
            _testObj.SortGroup(DummyOne, SortAscending);

            // Assert
            var sorted1 = (Dictionary<int, GroupField>)_privateObj.GetFieldOrProperty(Sorted1Field);
            this.ShouldSatisfyAllConditions(
                () => sorted1.ShouldNotBeNull(),
                () => sorted1.Count.ShouldBe(2),
                () => sorted1.First().Value.sVal.ShouldBe(DummyAbc));
        }

        [TestMethod]
        public void SortGroup_WhenGroup1DescendingOrder_ConfirmResult()
        {
            // Arrange
            _testObj.NewGrouping();
            _testObj.DefineGroupingValue(DummyOne, DummyOne, DummyOne, DummyAbc, DummyString);
            _testObj.DefineGroupingValue(DummyOne, DummyTwo, DummyTwo, DummyXyz, DummyString);

            // Act
            _testObj.SortGroup(DummyOne, SortDescending);

            // Assert
            var sorted1 = (Dictionary<int, GroupField>)_privateObj.GetFieldOrProperty(Sorted1Field);
            this.ShouldSatisfyAllConditions(
                () => sorted1.ShouldNotBeNull(),
                () => sorted1.Count.ShouldBe(2),
                () => sorted1.First().Value.sVal.ShouldBe(DummyXyz));
        }

        [TestMethod]
        public void SortGroup_WhenGroup2AscendingOrder_ConfirmResult()
        {
            // Arrange
            _testObj.NewGrouping();
            _testObj.DefineGroupingValue(DummyTwo, DummyOne, DummyOne, DummyXyz, DummyString);
            _testObj.DefineGroupingValue(DummyTwo, DummyTwo, DummyTwo, DummyAbc, DummyString);

            // Act
            _testObj.SortGroup(DummyTwo, SortAscending);

            // Assert
            var sorted2 = (Dictionary<int, GroupField>)_privateObj.GetFieldOrProperty(Sorted2Field);
            this.ShouldSatisfyAllConditions(
                () => sorted2.ShouldNotBeNull(),
                () => sorted2.Count.ShouldBe(2),
                () => sorted2.First().Value.sVal.ShouldBe(DummyAbc));
        }

        [TestMethod]
        public void SortGroup_WhenGroup2DescendingOrder_ConfirmResult()
        {
            // Arrange
            _testObj.NewGrouping();
            _testObj.DefineGroupingValue(DummyTwo, DummyOne, DummyOne, DummyAbc, DummyString);
            _testObj.DefineGroupingValue(DummyTwo, DummyTwo, DummyTwo, DummyXyz, DummyString);

            // Act
            _testObj.SortGroup(DummyTwo, SortDescending);

            // Assert
            var sorted2 = (Dictionary<int, GroupField>)_privateObj.GetFieldOrProperty(Sorted2Field);
            this.ShouldSatisfyAllConditions(
                () => sorted2.ShouldNotBeNull(),
                () => sorted2.Count.ShouldBe(2),
                () => sorted2.First().Value.sVal.ShouldBe(DummyXyz));
        }

        [TestMethod]
        public void SortGroup_WhenGroup3AscendingOrder_ConfirmResult()
        {
            // Arrange
            _testObj.NewGrouping();
            _testObj.DefineGroupingValue(DummyThree, DummyOne, DummyOne, DummyXyz, DummyString);
            _testObj.DefineGroupingValue(DummyThree, DummyTwo, DummyTwo, DummyAbc, DummyString);

            // Act
            _testObj.SortGroup(DummyThree, SortAscending);

            // Assert
            var sorted3 = (Dictionary<int, GroupField>)_privateObj.GetFieldOrProperty(Sorted3Field);
            this.ShouldSatisfyAllConditions(
                () => sorted3.ShouldNotBeNull(),
                () => sorted3.Count.ShouldBe(2),
                () => sorted3.First().Value.sVal.ShouldBe(DummyAbc));
        }

        [TestMethod]
        public void SortGroup_WhenGroup3DescendingOrder_ConfirmResult()
        {
            // Arrange
            _testObj.NewGrouping();
            _testObj.DefineGroupingValue(DummyThree, DummyOne, DummyOne, DummyAbc, DummyString);
            _testObj.DefineGroupingValue(DummyThree, DummyTwo, DummyTwo, DummyXyz, DummyString);

            // Act
            _testObj.SortGroup(DummyThree, SortDescending);

            // Assert
            var sorted3 = (Dictionary<int, GroupField>)_privateObj.GetFieldOrProperty(Sorted3Field);
            this.ShouldSatisfyAllConditions(
                () => sorted3.ShouldNotBeNull(),
                () => sorted3.Count.ShouldBe(2),
                () => sorted3.First().Value.sVal.ShouldBe(DummyXyz));
        }

        [TestMethod]
        public void DoNotSortGroup_WhenGroup1_ConfirmResult()
        {
            // Arrange
            _testObj.NewGrouping();
            _testObj.DefineGroupingValue(DummyOne, DummyOne, DummyOne, DummyXyz, DummyString);
            _testObj.DefineGroupingValue(DummyOne, DummyTwo, DummyTwo, DummyAbc, DummyString);

            // Act
            _testObj.DoNotSortGroup(DummyOne);

            // Assert
            var sorted1 = (Dictionary<int, GroupField>)_privateObj.GetFieldOrProperty(Sorted1Field);
            this.ShouldSatisfyAllConditions(
                () => sorted1.ShouldNotBeNull(),
                () => sorted1.Count.ShouldBe(2),
                () => sorted1.First().Value.sVal.ShouldBe(DummyXyz));
        }

        [TestMethod]
        public void DoNotSortGroup_WhenGroup2_ConfirmResult()
        {
            // Arrange
            _testObj.NewGrouping();
            _testObj.DefineGroupingValue(DummyTwo, DummyOne, DummyOne, DummyXyz, DummyString);
            _testObj.DefineGroupingValue(DummyTwo, DummyTwo, DummyTwo, DummyAbc, DummyString);

            // Act
            _testObj.DoNotSortGroup(DummyTwo);

            // Assert
            var sorted2 = (Dictionary<int, GroupField>)_privateObj.GetFieldOrProperty(Sorted2Field);
            this.ShouldSatisfyAllConditions(
                () => sorted2.ShouldNotBeNull(),
                () => sorted2.Count.ShouldBe(2),
                () => sorted2.First().Value.sVal.ShouldBe(DummyXyz));
        }

        [TestMethod]
        public void DoNotSortGroup_WhenGroup3_ConfirmResult()
        {
            // Arrange
            _testObj.NewGrouping();
            _testObj.DefineGroupingValue(DummyThree, DummyOne, DummyOne, DummyXyz, DummyString);
            _testObj.DefineGroupingValue(DummyThree, DummyTwo, DummyTwo, DummyAbc, DummyString);

            // Act
            _testObj.DoNotSortGroup(DummyThree);

            // Assert
            var sorted3 = (Dictionary<int, GroupField>)_privateObj.GetFieldOrProperty(Sorted3Field);
            this.ShouldSatisfyAllConditions(
                () => sorted3.ShouldNotBeNull(),
                () => sorted3.Count.ShouldBe(2),
                () => sorted3.First().Value.sVal.ShouldBe(DummyXyz));
        }

        [TestMethod]
        public void CalculateGrouplingList_WhenGroupToLevelInformed_ConfirmResult()
        {
            // Arrange
            _testObj.NewGrouping();
            _testObj.DefineItemValues(DummyOne, DummyOne, DummyOne, DummyOne, DummyString, DummyString);

            _testObj.DefineGroupingValue(DummyOne, DummyZero, DummyOne, DummyAbc, DummyString);
            _testObj.DefineGroupingValue(DummyOne, DummyOne, DummyTwo, DummyXyz, DummyString);
            _testObj.DefineGroupingValue(DummyOne, DummyOne, DummyThree, DummyString, DummyString);
            _testObj.DefineGroupingValue(DummyOne, DummyZero, DummyFour, DummyAbc, DummyString);
            _testObj.DefineGroupingValue(DummyOne, DummyFour, DummyFive, DummyAbc, DummyString);
            _testObj.DefineGroupingValue(DummyOne, DummyFive, DummySix, DummyAbc, DummyString);

            _testObj.DefineGroupingValue(DummyTwo, DummyZero, DummyOne, DummyString, DummyString);
            _testObj.DefineGroupingValue(DummyThree, DummyZero, DummyOne, DummyString, DummyString);

            _testObj.SortGroup(DummyOne, SortAscending);
            _testObj.SortGroup(DummyTwo, SortAscending);
            _testObj.SortGroup(DummyThree, SortAscending);

            // Act
            var result = _testObj.CalculateGrouplingList(DummyOne, DummyFour);

            // Assert
            var consolidate = (List<Consolid>)_privateObj.GetFieldOrProperty(ConsolidateField);
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(1),
                () => consolidate.ShouldNotBeNull(),
                () => consolidate.Count.ShouldBe(10));
        }

        [TestMethod]
        public void CalculateGrouplingList_WhenGroupToLevelIsNegative_ConfirmResult()
        {
            // Arrange
            _testObj.NewGrouping();
            _testObj.DefineItemValues(DummyOne, DummyOne, DummyZero, DummyZero, DummyString, DummyString);

            _testObj.DefineGroupingValue(DummyOne, DummyZero, DummyOne, DummyAbc, DummyString);

            _testObj.SortGroup(DummyOne, DummyOne);

            // Act
            var result = _testObj.CalculateGrouplingList(DummyOne, DummyNegative);

            // Assert
            var consolidate = (List<Consolid>)_privateObj.GetFieldOrProperty(ConsolidateField);
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(1),
                () => consolidate.ShouldNotBeNull(),
                () => consolidate.Count.ShouldBe(1));
        }

        [TestMethod]
        public void ElementDetails_WhenGroupNodeIsNotNull_ConfirmResult()
        {
            // Arrange
            var group = 0;
            var id = 0;
            var level = 0;
            var groupLevel = 0;
            var value = string.Empty;

            _testObj.NewGrouping();
            _testObj.DefineItemValues(DummyOne, DummyOne, DummyOne, DummyOne, DummyString, DummyString);

            _testObj.DefineGroupingValue(DummyOne, DummyZero, DummyOne, DummyAbc, DummyString);
            _testObj.DefineGroupingValue(DummyOne, DummyOne, DummyTwo, DummyXyz, DummyString);
            _testObj.DefineGroupingValue(DummyOne, DummyOne, DummyThree, DummyString, DummyString);
            _testObj.DefineGroupingValue(DummyOne, DummyZero, DummyFour, DummyAbc, DummyString);
            _testObj.DefineGroupingValue(DummyOne, DummyFour, DummyFive, DummyAbc, DummyString);
            _testObj.DefineGroupingValue(DummyOne, DummyFive, DummySix, DummyAbc, DummyString);

            _testObj.DefineGroupingValue(DummyTwo, DummyZero, DummyOne, DummyString, DummyString);
            _testObj.DefineGroupingValue(DummyThree, DummyZero, DummyOne, DummyString, DummyString);

            _testObj.SortGroup(DummyOne, SortAscending);
            _testObj.SortGroup(DummyTwo, SortAscending);
            _testObj.SortGroup(DummyThree, SortAscending);

            _testObj.CalculateGrouplingList(DummyOne, DummyFour);

            // Act
            var result = _testObj.ElementDetails(DummyOne, ref group, ref id, ref level, ref groupLevel, ref value);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(2),
                () => group.ShouldBe(DummyOne),
                () => id.ShouldBe(DummyOne),
                () => level.ShouldBe(DummyOne),
                () => groupLevel.ShouldBe(DummyOne),
                () => value.ShouldBe(DummyString));
        }

        [TestMethod]
        public void ElementDetails_WhenGroupNodeIsNull_ConfirmResult()
        {
            // Arrange
            var group = 0;
            var id = 0;
            var level = 0;
            var groupLevel = 0;
            var value = string.Empty;

            _testObj.NewGrouping();

            _testObj.DefineItemValues(DummyOne, DummyOne, DummyZero, DummyZero, DummyString, DummyString);
            _testObj.DefineGroupingValue(DummyOne, DummyZero, DummyOne, DummyAbc, DummyString);

            _testObj.SortGroup(DummyOne, DummyOne);

            _testObj.CalculateGrouplingList(DummyOne, DummyZero);

            // Act
            var result = _testObj.ElementDetails(DummyOne, ref group, ref id, ref level, ref groupLevel, ref value);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(DummyNegative),
                () => group.ShouldBe(DummyZero),
                () => id.ShouldBe(DummyOne),
                () => level.ShouldBe(DummyOne),
                () => groupLevel.ShouldBe(DummyZero),
                () => value.ShouldBe(DummyString));
        }
    }
}

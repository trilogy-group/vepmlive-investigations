using System;
using System.Collections;
using System.Collections.Fakes;
using System.Collections.Generic;
using System.Data;
using System.Data.Fakes;
using System.IO;
using System.Linq;
using System.Xml.Fakes;
using System.Xml.Linq;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using WorkEnginePPM.Fakes;

namespace WorkEnginePPM.Tests.WebServices
{
    [TestClass]
    public class IntegrationBuildTasksTests : IntegrationTestsBase
    {
        private const string DisplaySettings = "Name|Normal|DummyName#Title|Normal|DummyTitle#";
        private const string DummyString = "DummyString";
        private const string DummyId = "24875";
        private const string OrderId = "245";
        private const string OrderUId = "24";
        private const string EditorString = "EditorString";
        private const string TaskString = "Task";
        private const int ItemId = 777;
        private const string DummyTitle = "DummyTitle";
        private const string LookupValue = "LookupValue";
        private const string DummyInternalName = "DummyInternalName";
        private const float SPFieldValueNumber = 4.0f;

        private ShimHashtable _shimHashtable;
        private static readonly DateTime TestDateTime = new DateTime(2010, 10, 10, 10, 10, 10);

        [TestMethod]
        public void BuildTasks_CalculatedTypeHashTableContainIsAssignment_ExecutesCorrectly()
        {
            BuildTaskTests(SPFieldType.Calculated, true, true);
        }

        [TestMethod]
        public void BuildTasks_CalculatedTypeHashTableNotContainIsAssignment_ExecutesCorrectly()
        {
            BuildTaskTests(SPFieldType.Calculated, false, true);
        }

        [TestMethod]
        public void BuildTasks_CalculatedTypeHashTableContainNotAssignment_ExecutesCorrectly()
        {
            BuildTaskTests(SPFieldType.Calculated, true, false);
        }

        [TestMethod]
        public void BuildTasks_CalculatedTypeHashTableNotContainNotAssignment_ExecutesCorrectly()
        {
            BuildTaskTests(SPFieldType.Calculated, false, false);
        }

        [TestMethod]
        public void BuildTasks_CurrencyTypeHashTableContainIsAssignment_ExecutesCorrectly()
        {
            BuildTaskTests(SPFieldType.Currency, true, true);
        }

        [TestMethod]
        public void BuildTasks_CurrencyTypeHashTableNotContainIsAssignment_ExecutesCorrectly()
        {
            BuildTaskTests(SPFieldType.Currency, false, true);
        }

        [TestMethod]
        public void BuildTasks_CurrencyTypeHashTableContainNotAssignment_ExecutesCorrectly()
        {
            BuildTaskTests(SPFieldType.Currency, true, false);
        }

        [TestMethod]
        public void BuildTasks_CurrencyTypeHashTableNotContainNotAssignment_ExecutesCorrectly()
        {
            BuildTaskTests(SPFieldType.Currency, false, false);
        }

        [TestMethod]
        public void BuildTasks_NumberTypeHashTableContainIsAssignment_ExecutesCorrectly()
        {
            BuildTaskTests(SPFieldType.Number, true, true);
        }

        [TestMethod]
        public void BuildTasks_NumberTypeHashTableNotContainIsAssignment_ExecutesCorrectly()
        {
            BuildTaskTests(SPFieldType.Number, false, true);
        }

        [TestMethod]
        public void BuildTasks_NumberTypeHashTableContainNotAssignment_ExecutesCorrectly()
        {
            BuildTaskTests(SPFieldType.Number, true, false);
        }

        [TestMethod]
        public void BuildTasks_NumberTypeHashTableNotContainNotAssignment_ExecutesCorrectly()
        {
            BuildTaskTests(SPFieldType.Number, false, false);
        }

        [TestMethod]
        public void BuildTasks_DateTimeTypeHashTableContainIsAssignment_ExecutesCorrectly()
        {
            BuildTaskTests(SPFieldType.DateTime, true, true);
        }

        [TestMethod]
        public void BuildTasks_DateTimeTypeHashTableNotContainIsAssignment_ExecutesCorrectly()
        {
            BuildTaskTests(SPFieldType.DateTime, false, true);
        }

        [TestMethod]
        public void BuildTasks_DateTimeTypeHashTableContainNotAssignment_ExecutesCorrectly()
        {
            BuildTaskTests(SPFieldType.DateTime, true, false);
        }

        [TestMethod]
        public void BuildTasks_DateTimeTypeHashTableNotContainNotAssignment_ExecutesCorrectly()
        {
            BuildTaskTests(SPFieldType.DateTime, false, false);
        }

        private void BuildTaskTests(SPFieldType spFieldType, bool hashtableShouldContain, bool isAssignment)
        {
            // Arrange
            ArrangeBuildTasks(spFieldType, hashtableShouldContain, isAssignment);

            // Act
            Action action = () => Result = (string)PrivateObject.Invoke(
                "buildTasks",
                (DataTable)new ShimDataTable(),
                (Hashtable)_shimHashtable,
                (SPList)new ShimSPList());

            // Assert
            AssertConditions(action, isAssignment, hashtableShouldContain, spFieldType);
        }

        private void AssertConditions(
            Action action,
            bool isAssignment,
            bool hashtableShouldContain,
            SPFieldType spFieldType)
        {
            this.ShouldSatisfyAllConditions(
                () =>
                {
                    action.ShouldNotThrow();
                    XmlDocument = XDocument.Parse(Result);
                },
                () => XmlDocument.Descendants("Task").First().Attribute("ID").Value.ShouldBe(OrderId),
                () => XmlDocument.Descendants("Task").First().Attribute("UID").Value.ShouldBe(OrderUId),
                () => int.Parse(XmlDocument.Descendants("Task").First().Attribute("ItemID").Value).ShouldBe(ItemId),
                () => XmlDocument.Descendants("Title").First().Value.ShouldContain(DummyTitle),
                () => XmlDocument.Descendants("Field").First().Value.ShouldContain(LookupValue),
                () => XmlDocument.Descendants("Field")
                    .Single(element => element.Attributes().Any(attribute => attribute.Name == "Name" && attribute.Value == "IsAssignment"))
                    .Value.ShouldContain(
                        isAssignment
                            ? "1"
                            : "0"),
                () => XmlDocument.Descendants("Field")
                    .Single(element => element.Attributes().Any(attribute => attribute.Name == "Name" && attribute.Value == "TaskHierarchy"))
                    .Value.ShouldContain(TaskString),
                () =>
                {
                    var xElement = XmlDocument.Descendants("Field")
                        .SingleOrDefault(
                            element => element.Attributes()
                                .Any(
                                    attribute => attribute.Name == "Name"
                                        && attribute.Value
                                        == (hashtableShouldContain
                                            ? DummyInternalName
                                            : DummyString)));
                    switch (spFieldType)
                    {
                        case SPFieldType.Currency:
                        case SPFieldType.Number:
                            xElement.Value.ShouldContain(SPFieldValueNumber.ToString());
                            break;
                        case SPFieldType.DateTime:
                            xElement.Value.ShouldContain(TestDateTime.ToString("s"));
                            break;
                        default:
                            xElement.ShouldBeNull();
                            break;
                    }
                });
        }

        private void ArrangeBuildTasks(SPFieldType spFieldType, bool hashtableShouldContain, bool isAssignment)
        {
            ShimConfigFunctions.getListSettingSPListString = (_1, _2) => DisplaySettings;
            ArrangeDataTable();
            ShimDataRow.AllInstances.ItemGetString = (_1, _2) => DummyId;
            ShimSPList.AllInstances.GetItemByIdInt32 = (_1, _2) => new ShimSPListItem();
            ShimSPList.AllInstances.FieldsGet = _ => (SPFieldCollection)new ShimSPBaseCollection(new ShimSPFieldCollection());
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPField>
            {
                new ShimSPField()
            }.GetEnumerator();
            ShimSPField.AllInstances.ShowInEditFormGet = _ => true;
            ShimSPField.AllInstances.TypeGet = _ => spFieldType;
            ShimSPField.AllInstances.SchemaXmlGet = _ => DummyString;
            ShimSPFieldCollection.AllInstances.ItemGetGuid = (_1, _2) => new ShimSPField();
            ShimSPField.AllInstances.GetFieldValueString = (_, str) => str;
            ShimSPField.AllInstances.InternalNameGet = _ => DummyString;
            ShimSPListItem.AllInstances.IDGet = _ => ItemId;
            ShimSPListItem.AllInstances.TitleGet = _ => DummyTitle;
            ShimSPListItem.AllInstances.ItemGetGuid = (_1, _2) =>
            {
                switch (spFieldType)
                {
                    case SPFieldType.Currency:
                    case SPFieldType.Number:
                        return SPFieldValueNumber;
                    case SPFieldType.DateTime:
                        return TestDateTime;
                    default:
                        return string.Empty;
                }
            };

            _shimHashtable = new ShimHashtable
            {
                ContainsObject = _ => hashtableShouldContain,
                ItemGetObject = obj =>
                {
                    if (hashtableShouldContain)
                    {
                        return DummyInternalName;
                    }
                    return null;
                }
            };

            ShimXmlDocument.AllInstances.LoadXmlString = (_1, _2) => { };
            ShimIntegration.AllInstances.isEditableSPListItemSPFieldDictionaryOfStringDictionaryOfStringString = (_1, _2, _3, _4) => true;

            ShimSPList.AllInstances.ParentWebGet = _ => new ShimSPWeb();
            ShimSPFieldUserValue.ConstructorSPWebString = (_1, _2, _3) => { };
            ShimSPFieldUserValue.AllInstances.LookupValueGet = _ => LookupValue;

            ArrangeSPListItem(isAssignment);
        }

        private void ArrangeSPListItem(bool isAssignment)
        {
            ShimSPListItem.AllInstances.ItemGetString = (_1, str) =>
            {
                switch (str)
                {
                    case "taskorder":
                        return OrderId;
                    case "taskuid":
                        return OrderUId;
                    case "IsAssignment":
                        return isAssignment.ToString();
                    case "TaskHierarchy":
                        return TaskString;
                    case "Editor":
                        return EditorString;
                    default:
                        return string.Empty;
                }
            };
        }
    }
}
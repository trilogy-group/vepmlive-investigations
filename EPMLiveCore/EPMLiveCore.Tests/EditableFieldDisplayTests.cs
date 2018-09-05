using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests
{
    [TestClass]
    public class EditableFieldDisplayTests
    {
        private EditableFieldDisplay _testObj;
        private PrivateObject _privateObj;
        private IDisposable _shimsContext;
        private ShimSPField spField;
        private Dictionary<string, Dictionary<string, string>> fieldProperties;
        private ShimSPListItem listItem;
        private Guid guid;
        private const string CanEditMethodName = "canEdit";
        private const string RenderFieldMethodName = "RenderField";
        private const string IsDisplayFieldMethodName = "IsDisplayField";
        private const string IsEditableFieldMethodName = "isEditableField";
        private const string GetFieldSchemaAttribValueMethodName = "getFieldSchemaAttribValue";
        private const string IsDateMethodName = "isDate";
        private const string IsNumericMethodName = "IsNumeric";
        private const string WhereUserMethodName = "WhereUser";
        private const string WhereFieldMethodName = "WhereField";
        private const string InternalNameString = "InternalName";
        private const string EditableString = "Editable";
        private const string UserDisplaySettings = ";[Me];condition;group";
        private const string FieldDisplaySettings = ";[Field];condition;group";
        private const string UserName = "userName";

        [TestInitialize]
        public void Setup()
        {
            _testObj = new EditableFieldDisplay();
            _privateObj = new PrivateObject(_testObj);

            SetupShims();
        }

        private void SetupShims()
        {
            _shimsContext = ShimsContext.Create();

            guid = Guid.NewGuid();

            spField = new ShimSPField()
            {
                InternalNameGet = () => InternalNameString
            };

            fieldProperties = new Dictionary<string, Dictionary<string, string>>()
            {
                [InternalNameString] = new Dictionary<string, string>()
                {
                    [EditableString] = UserDisplaySettings
                }
            };

            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    CurrentUserGet = () => new ShimSPUser()
                    {
                        NameGet = () => UserName
                    }
                }
            };

            listItem = new ShimSPListItem();
        }

        [TestCleanup]
        public void TearDown()
        {
            _shimsContext?.Dispose();
        }

        [TestMethod]
        public void CanEdit_WhereUser_ReturnsBoolean()
        {
            // Arrange
            const bool expected = true;
            fieldProperties[InternalNameString][EditableString] = UserDisplaySettings;

            spField.ShowInEditFormGet = () => expected;
            ShimEditableFieldDisplay.RenderFieldSPFieldStringStringStringStringStringSPListItem = (_, _1, _2, _3, _4, _5, _6) =>
            {
                throw new Exception();
            };

            // Act
            var actual = (bool)_privateObj.Invoke(
                CanEditMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { spField.Instance, fieldProperties, listItem.Instance });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void CanEdit_WhereField_ReturnsBoolean()
        {
            // Arrange
            const bool expected = true;
            fieldProperties[InternalNameString][EditableString] = FieldDisplaySettings;

            spField.ShowInEditFormGet = () => null;
            ShimEditableFieldDisplay.RenderFieldSPFieldStringStringStringStringStringSPListItem = (_, _1, _2, _3, _4, _5, _6) =>
            {
                throw new Exception();
            };

            // Act
            var actual = (bool)_privateObj.Invoke(
                CanEditMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { spField.Instance, fieldProperties, listItem.Instance });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void RenderField_WhenUser_ReturnsBoolean()
        {
            // Arrange
            const bool expected = true;
            const string where = "[Me]";
            const string conditionField = "conditionField";

            ShimEditableFieldDisplay.WhereUserStringString = (_, _1) => expected;

            // Act
            var actual = (bool)_privateObj.Invoke(
                RenderFieldMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { spField.Instance, where, conditionField, string.Empty, string.Empty, string.Empty, listItem.Instance });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void RenderField_WhenField_ReturnsBoolean()
        {
            // Arrange
            const bool expected = true;
            const string where = "[Field]";
            const string conditionField = "conditionField";

            listItem.FieldsGet = () => new ShimSPFieldCollection()
            {
                GetFieldByInternalNameString = _ => null
            };
            ShimEditableFieldDisplay.WhereFieldSPFieldStringStringStringSPListItem = (_, _1, _2, _3, _4) => expected;

            // Act
            var actual = (bool)_privateObj.Invoke(
                RenderFieldMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { spField.Instance, where, conditionField, string.Empty, string.Empty, string.Empty, listItem.Instance });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void IsDisplayField_always_ReturnsBoolean()
        {
            // Arrange
            const string customValue = "always;";
            const bool expected = true;

            fieldProperties[InternalNameString][EditableString] = customValue;

            // Act
            var actual = (bool)_privateObj.Invoke(
                IsDisplayFieldMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { spField.Instance, fieldProperties, EditableString });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void IsDisplayField_never_ReturnsBoolean()
        {
            // Arrange
            const string customValue = "never;";
            const bool expected = false;

            fieldProperties[InternalNameString][EditableString] = customValue;

            // Act
            var actual = (bool)_privateObj.Invoke(
                IsDisplayFieldMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { spField.Instance, fieldProperties, EditableString });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void IsDisplayField_where_ReturnsBoolean()
        {
            // Arrange
            const string customValue = "where;[Me];condition;group";
            const bool expected = true;

            fieldProperties[InternalNameString][EditableString] = customValue;
            ShimEditableFieldDisplay.WhereUserStringString = (_, _1) => expected;

            // Act
            var actual = (bool)_privateObj.Invoke(
                IsDisplayFieldMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { spField.Instance, fieldProperties, EditableString });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void IsEditableField_InvalidKey_ReturnsBoolean()
        {
            // Arrange
            const bool expected = true;
            const string invalidKey = "InvalidKey";

            // Act
            var actual = (bool)_privateObj.Invoke(
                IsEditableFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, fieldProperties, invalidKey });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void IsEditableField_InvalidWhere_ReturnsBoolean()
        {
            // Arrange
            const bool expected = true;
            const string invalidKey = "InvalidKey";
            const string customValue = "where;[Me];condition;group";

            fieldProperties[InternalNameString].Add(invalidKey, customValue);

            // Act
            var actual = (bool)_privateObj.Invoke(
                IsEditableFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, fieldProperties, invalidKey });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void IsEditableField_EditableWhere_ReturnsBoolean()
        {
            // Arrange
            const bool expected = true;
            const string invalidKey = "InvalidKey";
            const string customValue1 = "never;[Me];condition;group";
            const string customValue2 = "where;[Me];condition;group";

            fieldProperties[InternalNameString].Add(invalidKey, customValue1);
            fieldProperties[InternalNameString][EditableString] = customValue2;

            // Act
            var actual = (bool)_privateObj.Invoke(
                IsEditableFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, fieldProperties, invalidKey });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void IsEditableField_EditableNever_ReturnsBoolean()
        {
            // Arrange
            const bool expected = false;
            const string invalidKey = "InvalidKey";
            const string customValue1 = "never;[Me];condition;group";

            fieldProperties[InternalNameString].Add(invalidKey, customValue1);
            fieldProperties[InternalNameString][EditableString] = customValue1;

            // Act
            var actual = (bool)_privateObj.Invoke(
                IsEditableFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, fieldProperties, invalidKey });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void GetFieldSchemaAttribValue_WhenCalled_ReturnsString()
        {
            // Arrange
            const string attributeName = "attributeName";
            const string attributeValue = @"attributeValue";
            var stringToSearch = $"{attributeName}=\"{attributeValue}\"";

            // Act
            var actual = (string)_privateObj.Invoke(
                GetFieldSchemaAttribValueMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { stringToSearch, attributeName });

            // Assert
            actual.ShouldBe(attributeValue);
        }

        [TestMethod]
        public void IsDate_ValidDate_ReturnsTrue()
        {
            // Arrange
            var input = DateTime.Now.ToString();

            // Act
            var actual = (bool)_privateObj.Invoke(
                IsDateMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { input });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void IsDate_InvalidDate_ReturnsFalse()
        {
            // Arrange
            const string input = "input";

            // Act
            var actual = (bool)_privateObj.Invoke(
                IsDateMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { input });

            // Assert
            actual.ShouldBeFalse();
        }

        [TestMethod]
        public void isEditableField_NewKeyWhereUserFalse_ReturnsTrue()
        {
            // Arrange
            const bool expected = false;
            const string invalidKey = "InvalidKey";
            const string customValue = "where;[Me];condition;group";

            fieldProperties[InternalNameString].Add(invalidKey, customValue);
            ShimEditableFieldDisplay.RenderFieldSPFieldStringStringStringStringStringSPListItem =
                (_, _1, _2, _3, _4, _5, _6) => expected;

            // Act
            var actual = (bool)_privateObj.Invoke(
                IsEditableFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { listItem.Instance, spField.Instance, fieldProperties, invalidKey });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void isEditableField_NewKeyWhereUserTrue_ReturnsTrue()
        {
            // Arrange
            const bool expected = true;
            const string invalidKey = "InvalidKey";
            const string customValue = "where;[Me];conditionField;condition;valueCondition";

            fieldProperties[InternalNameString][EditableString] = customValue;
            fieldProperties[InternalNameString].Add(invalidKey, customValue);
            ShimEditableFieldDisplay.RenderFieldSPFieldStringStringStringStringStringSPListItem =
                (_, _1, _2, _3, _4, _5, _6) => expected;

            // Act
            var actual = (bool)_privateObj.Invoke(
                IsEditableFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { listItem.Instance, spField.Instance, fieldProperties, invalidKey });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void isEditableField_NewKeyWhereFieldTrue_ReturnsTrue()
        {
            // Arrange
            const bool expected = true;
            const string invalidKey = "InvalidKey";
            const string customValue = "where;[Field];conditionField;condition;valueCondition";

            fieldProperties[InternalNameString][EditableString] = customValue;
            fieldProperties[InternalNameString].Add(invalidKey, customValue);
            ShimEditableFieldDisplay.RenderFieldSPFieldStringStringStringStringStringSPListItem =
                (_, _1, _2, _3, _4, _5, _6) => expected;

            // Act
            var actual = (bool)_privateObj.Invoke(
                IsEditableFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { listItem.Instance, spField.Instance, fieldProperties, invalidKey });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void IsNumeric_ValidNumber_ReturnsTrue()
        {
            // Arrange
            const string input = "12345";

            // Act
            var actual = (bool)_privateObj.Invoke(
                IsNumericMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { input });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void IsNumeric_InvalidNumber_ReturnsFalse()
        {
            // Arrange
            const string input = "input";

            // Act
            var actual = (bool)_privateObj.Invoke(
                IsNumericMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { input });

            // Assert
            actual.ShouldBeFalse();
        }

        [TestMethod]
        public void IsNumeric_Empty_ReturnsFalse()
        {
            // Arrange
            var input = string.Empty;

            // Act
            var actual = (bool)_privateObj.Invoke(
                IsNumericMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { input });

            // Assert
            actual.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereUser_WhenCalled_ReturnsBoolean()
        {
            // Arrange
            const string condition = "IsInGroup";
            const string group = "group";

            var userGroups = new ShimSPGroupCollection().Instance;
            userGroups.Add(group, null, null, group);

            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    CurrentUserGet = () => new ShimSPUser()
                    {
                        GroupsGet = () => userGroups
                    }
                }
            };
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPGroup>()
            {
                new ShimSPGroup()
                {
                    NameGet = () => group
                }
            }.GetEnumerator();

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereUserMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { condition, group });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_BooleanIsEqualTo_ReturnsTrue()
        {
            // Arrange
            const string where = "";
            const string condition = "IsEqualTo";
            const string value = "True";

            spField.TypeGet = () => SPFieldType.Boolean;
            spField.IdGet = () => guid;

            listItem.ItemGetGuid = _ => value;

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_BooleanIsEqualTo_ReturnsFalse()
        {
            // Arrange
            const string where = "";
            const string condition = "IsEqualTo";
            const string value = "[Today]";

            spField.TypeGet = () => SPFieldType.Boolean;
            spField.IdGet = () => guid;

            listItem.ItemGetGuid = _ => $"NOT_{value}";

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_DateTimeIsEqualTo_ReturnsTrue()
        {
            // Arrange
            const string where = "";
            const string condition = "IsEqualTo";

            var now = DateTime.Now;
            var value = now.ToString();

            spField.TypeGet = () => SPFieldType.DateTime;
            spField.IdGet = () => guid;
            spField.SchemaXmlGet = () => "Format=\"DateTime\"";

            listItem.ItemGetGuid = _ => value;

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_DateTimeIsEqualTo_ReturnsFalse()
        {
            // Arrange
            const string where = "";
            const string condition = "IsEqualTo";

            var now = DateTime.Now;
            var value = now.ToString();

            spField.TypeGet = () => SPFieldType.DateTime;
            spField.IdGet = () => guid;
            spField.SchemaXmlGet = () => "Format=\"DateTime\"";

            listItem.ItemGetGuid = _ => now.AddDays(1).ToString();

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_DateTime2IsEqualTo_ReturnsTrue()
        {
            // Arrange
            const string where = "";
            const string condition = "IsEqualTo";

            var now = DateTime.Now;
            var value = now.ToString();

            spField.TypeGet = () => SPFieldType.DateTime;
            spField.IdGet = () => guid;
            spField.SchemaXmlGet = () => "Format=\"NotDateTime\"";

            listItem.ItemGetGuid = _ => value;

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_DateTime2IsEqualTo_ReturnsFalse()
        {
            // Arrange
            const string where = "";
            const string condition = "IsEqualTo";

            var now = DateTime.Now;
            var value = now.ToString();

            spField.TypeGet = () => SPFieldType.DateTime;
            spField.IdGet = () => guid;
            spField.SchemaXmlGet = () => "Format=\"NotDateTime\"";

            listItem.ItemGetGuid = _ => now.AddDays(1).ToString();

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_NumberIsEqualTo_ReturnsTrue()
        {
            // Arrange
            const string where = "";
            const string condition = "IsEqualTo";
            const string value = "5";

            spField.TypeGet = () => SPFieldType.Number;
            spField.IdGet = () => guid;

            listItem.ItemGetGuid = _ => value;

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_NumberIsEqualTo_ReturnsFalse()
        {
            // Arrange
            const string where = "";
            const string condition = "IsEqualTo";
            const string value = "5";

            spField.TypeGet = () => SPFieldType.Number;
            spField.IdGet = () => guid;

            listItem.ItemGetGuid = _ => "10";

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_CurrencyIsEqualTo_ReturnsTrue()
        {
            // Arrange
            const string where = "";
            const string condition = "IsEqualTo";
            const string value = "5";

            spField.TypeGet = () => SPFieldType.Currency;
            spField.IdGet = () => guid;

            listItem.ItemGetGuid = _ => value;

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_CurrencyIsEqualTo_ReturnsFalse()
        {
            // Arrange
            const string where = "";
            const string condition = "IsEqualTo";
            const string value = "5";

            spField.TypeGet = () => SPFieldType.Currency;
            spField.IdGet = () => guid;

            listItem.ItemGetGuid = _ => "10";

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_TextIsEqualTo_ReturnsTrue()
        {
            // Arrange
            const string where = "";
            const string condition = "IsEqualTo";
            const string value = "[Me]";

            spField.TypeGet = () => SPFieldType.Text;
            spField.IdGet = () => guid;
            spField.GetFieldValueAsTextObject = _ => UserName;

            listItem.ItemGetGuid = _ => UserName;

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_TextIsEqualTo_ReturnsFalse()
        {
            // Arrange
            const string where = "";
            const string condition = "IsEqualTo";
            const string value = "Something";

            spField.TypeGet = () => SPFieldType.Text;
            spField.IdGet = () => guid;
            spField.GetFieldValueAsTextObject = _ => UserName;

            listItem.ItemGetGuid = _ => UserName;

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_BooleanIsNotEqualTo_ReturnsFalse()
        {
            // Arrange
            const string where = "";
            const string condition = "IsNotEqualTo";
            const string value = "True";

            spField.TypeGet = () => SPFieldType.Boolean;
            spField.IdGet = () => guid;

            listItem.ItemGetGuid = _ => value;

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_BooleanIsNotEqualTo_ReturnsTrue()
        {
            // Arrange
            const string where = "";
            const string condition = "IsNotEqualTo";
            const string value = "[Today]";

            spField.TypeGet = () => SPFieldType.Boolean;
            spField.IdGet = () => guid;

            listItem.ItemGetGuid = _ => $"NOT_{value}";

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_DateTimeIsNotEqualTo_ReturnsFalse()
        {
            // Arrange
            const string where = "";
            const string condition = "IsNotEqualTo";

            var now = DateTime.Now;
            var value = now.ToString();

            spField.TypeGet = () => SPFieldType.DateTime;
            spField.IdGet = () => guid;
            spField.SchemaXmlGet = () => "Format=\"DateTime\"";

            listItem.ItemGetGuid = _ => value;

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_DateTimeIsNotEqualTo_ReturnsTrue()
        {
            // Arrange
            const string where = "";
            const string condition = "IsNotEqualTo";

            var now = DateTime.Now;
            var value = now.ToString();

            spField.TypeGet = () => SPFieldType.DateTime;
            spField.IdGet = () => guid;
            spField.SchemaXmlGet = () => "Format=\"DateTime\"";

            listItem.ItemGetGuid = _ => now.AddDays(1).ToString();

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_DateTime2IsNotEqualTo_ReturnsFalse()
        {
            // Arrange
            const string where = "";
            const string condition = "IsNotEqualTo";

            var now = DateTime.Now;
            var value = now.ToString();

            spField.TypeGet = () => SPFieldType.DateTime;
            spField.IdGet = () => guid;
            spField.SchemaXmlGet = () => "Format=\"NotDateTime\"";

            listItem.ItemGetGuid = _ => value;

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_DateTime2IsNotEqualTo_ReturnsTrue()
        {
            // Arrange
            const string where = "";
            const string condition = "IsNotEqualTo";

            var now = DateTime.Now;
            var value = now.ToString();

            spField.TypeGet = () => SPFieldType.DateTime;
            spField.IdGet = () => guid;
            spField.SchemaXmlGet = () => "Format=\"NotDateTime\"";

            listItem.ItemGetGuid = _ => now.AddDays(1).ToString();

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_NumberIsNotEqualTo_ReturnsFalse()
        {
            // Arrange
            const string where = "";
            const string condition = "IsNotEqualTo";
            const string value = "5";

            spField.TypeGet = () => SPFieldType.Number;
            spField.IdGet = () => guid;

            listItem.ItemGetGuid = _ => value;

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_NumberIsNotEqualTo_ReturnsTrue()
        {
            // Arrange
            const string where = "";
            const string condition = "IsNotEqualTo";
            const string value = "5";

            spField.TypeGet = () => SPFieldType.Number;
            spField.IdGet = () => guid;

            listItem.ItemGetGuid = _ => "10";

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_CurrencyIsNotEqualTo_ReturnsFalse()
        {
            // Arrange
            const string where = "";
            const string condition = "IsNotEqualTo";
            const string value = "5";

            spField.TypeGet = () => SPFieldType.Currency;
            spField.IdGet = () => guid;

            listItem.ItemGetGuid = _ => value;

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_CurrencyIsNotEqualTo_ReturnsTrue()
        {
            // Arrange
            const string where = "";
            const string condition = "IsNotEqualTo";
            const string value = "5";

            spField.TypeGet = () => SPFieldType.Currency;
            spField.IdGet = () => guid;

            listItem.ItemGetGuid = _ => "10";

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_TextIsNotEqualTo_ReturnsFalse()
        {
            // Arrange
            const string where = "";
            const string condition = "IsNotEqualTo";
            const string value = "[Me]";

            spField.TypeGet = () => SPFieldType.Text;
            spField.IdGet = () => guid;
            spField.GetFieldValueAsTextObject = _ => UserName;

            listItem.ItemGetGuid = _ => UserName;

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_TextIsNotEqualTo_ReturnsTrue()
        {
            // Arrange
            const string where = "";
            const string condition = "IsNotEqualTo";
            const string value = "Something";

            spField.TypeGet = () => SPFieldType.Text;
            spField.IdGet = () => guid;
            spField.GetFieldValueAsTextObject = _ => UserName;

            listItem.ItemGetGuid = _ => UserName;

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_DateTimeIsGreaterThan_ReturnsTrue()
        {
            // Arrange
            const string where = "";
            const string condition = "IsGreaterThan";

            var now = DateTime.Now;
            var value = now.ToString();

            spField.TypeGet = () => SPFieldType.DateTime;
            spField.IdGet = () => guid;
            spField.SchemaXmlGet = () => "Format=\"DateTime\"";

            listItem.ItemGetGuid = _ => now.AddDays(1).ToString();

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_DateTimeIsGreaterThan_ReturnsFalse()
        {
            // Arrange
            const string where = "";
            const string condition = "IsGreaterThan";

            var now = DateTime.Now;
            var value = now.ToString();

            spField.TypeGet = () => SPFieldType.DateTime;
            spField.IdGet = () => guid;
            spField.SchemaXmlGet = () => "Format=\"DateTime\"";

            listItem.ItemGetGuid = _ => value;

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_DateTime2IsGreaterThan_ReturnsTrue()
        {
            // Arrange
            const string where = "";
            const string condition = "IsGreaterThan";

            var now = DateTime.Now;
            var value = now.ToString();

            spField.TypeGet = () => SPFieldType.DateTime;
            spField.IdGet = () => guid;
            spField.SchemaXmlGet = () => "Format=\"NotDateTime\"";

            listItem.ItemGetGuid = _ => now.AddDays(1).ToString();

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_DateTime2IsGreaterThan_ReturnsFalse()
        {
            // Arrange
            const string where = "";
            const string condition = "IsGreaterThan";

            var now = DateTime.Now;
            var value = now.ToString();

            spField.TypeGet = () => SPFieldType.DateTime;
            spField.IdGet = () => guid;
            spField.SchemaXmlGet = () => "Format=\"NotDateTime\"";

            listItem.ItemGetGuid = _ => value;

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_NumberIsGreaterThan_ReturnsTrue()
        {
            // Arrange
            const string where = "";
            const string condition = "IsGreaterThan";
            const string value = "5";

            spField.TypeGet = () => SPFieldType.Number;
            spField.IdGet = () => guid;

            listItem.ItemGetGuid = _ => "10";

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_NumberIsGreaterThan_ReturnsFalse()
        {
            // Arrange
            const string where = "";
            const string condition = "IsGreaterThan";
            const string value = "5";

            spField.TypeGet = () => SPFieldType.Number;
            spField.IdGet = () => guid;

            listItem.ItemGetGuid = _ => value;

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_CurrencyIsGreaterThan_ReturnsTrue()
        {
            // Arrange
            const string where = "";
            const string condition = "IsGreaterThan";
            const string value = "5";

            spField.TypeGet = () => SPFieldType.Currency;
            spField.IdGet = () => guid;

            listItem.ItemGetGuid = _ => "10";

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_CurrencyIsGreaterThan_ReturnsFalse()
        {
            // Arrange
            const string where = "";
            const string condition = "IsGreaterThan";
            const string value = "5";

            spField.TypeGet = () => SPFieldType.Currency;
            spField.IdGet = () => guid;

            listItem.ItemGetGuid = _ => value;

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_TextIsGreaterThan_ReturnsFalse()
        {
            // Arrange
            const string where = "";
            const string condition = "IsGreaterThan";
            const string value = "[Me]";

            spField.TypeGet = () => SPFieldType.Text;
            spField.IdGet = () => guid;
            spField.GetFieldValueAsTextObject = _ => UserName;

            listItem.ItemGetGuid = _ => UserName;

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_DateTimeIsGreaterThanOrEqual_ReturnsTrue()
        {
            // Arrange
            const string where = "";
            const string condition = "IsGreaterThanOrEqual";

            var now = DateTime.Now;
            var value = now.ToString();

            spField.TypeGet = () => SPFieldType.DateTime;
            spField.IdGet = () => guid;
            spField.SchemaXmlGet = () => "Format=\"DateTime\"";

            listItem.ItemGetGuid = _ => value;

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_DateTimeIsGreaterThanOrEqual_ReturnsFalse()
        {
            // Arrange
            const string where = "";
            const string condition = "IsGreaterThanOrEqual";

            var now = DateTime.Now;
            var value = now.ToString();

            spField.TypeGet = () => SPFieldType.DateTime;
            spField.IdGet = () => guid;
            spField.SchemaXmlGet = () => "Format=\"DateTime\"";

            listItem.ItemGetGuid = _ => now.AddDays(-1).ToString();

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_DateTime2IsGreaterThanOrEqual_ReturnsTrue()
        {
            // Arrange
            const string where = "";
            const string condition = "IsGreaterThanOrEqual";

            var now = DateTime.Now;
            var value = now.ToString();

            spField.TypeGet = () => SPFieldType.DateTime;
            spField.IdGet = () => guid;
            spField.SchemaXmlGet = () => "Format=\"NotDateTime\"";

            listItem.ItemGetGuid = _ => value;

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_DateTime2IsGreaterThanOrEqual_ReturnsFalse()
        {
            // Arrange
            const string where = "";
            const string condition = "IsGreaterThanOrEqual";

            var now = DateTime.Now;
            var value = now.ToString();

            spField.TypeGet = () => SPFieldType.DateTime;
            spField.IdGet = () => guid;
            spField.SchemaXmlGet = () => "Format=\"NotDateTime\"";

            listItem.ItemGetGuid = _ => now.AddDays(-1).ToString();

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_NumberIsGreaterThanOrEqual_ReturnsTrue()
        {
            // Arrange
            const string where = "";
            const string condition = "IsGreaterThanOrEqual";
            const string value = "5";

            spField.TypeGet = () => SPFieldType.Number;
            spField.IdGet = () => guid;

            listItem.ItemGetGuid = _ => value;

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_NumberIsGreaterThanOrEqual_ReturnsFalse()
        {
            // Arrange
            const string where = "";
            const string condition = "IsGreaterThanOrEqual";
            const string value = "5";

            spField.TypeGet = () => SPFieldType.Number;
            spField.IdGet = () => guid;

            listItem.ItemGetGuid = _ => "4";

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_CurrencyIsGreaterThanOrEqual_ReturnsTrue()
        {
            // Arrange
            const string where = "";
            const string condition = "IsGreaterThanOrEqual";
            const string value = "5";

            spField.TypeGet = () => SPFieldType.Currency;
            spField.IdGet = () => guid;

            listItem.ItemGetGuid = _ => value;

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_CurrencyIsGreaterThanOrEqual_ReturnsFalse()
        {
            // Arrange
            const string where = "";
            const string condition = "IsGreaterThanOrEqual";
            const string value = "5";

            spField.TypeGet = () => SPFieldType.Currency;
            spField.IdGet = () => guid;

            listItem.ItemGetGuid = _ => "3";

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_TextIsGreaterThanOrEqual_ReturnsFalse()
        {
            // Arrange
            const string where = "";
            const string condition = "IsGreaterThanOrEqual";
            const string value = "[Me]";

            spField.TypeGet = () => SPFieldType.Text;
            spField.IdGet = () => guid;
            spField.GetFieldValueAsTextObject = _ => UserName;

            listItem.ItemGetGuid = _ => UserName;

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_DateTimeIsLessThan_ReturnsTrue()
        {
            // Arrange
            const string where = "";
            const string condition = "IsLessThan";

            var now = DateTime.Now;
            var value = now.ToString();

            spField.TypeGet = () => SPFieldType.DateTime;
            spField.IdGet = () => guid;
            spField.SchemaXmlGet = () => "Format=\"DateTime\"";

            listItem.ItemGetGuid = _ => now.AddDays(-1).ToString();

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_DateTimeIsLessThan_ReturnsFalse()
        {
            // Arrange
            const string where = "";
            const string condition = "IsLessThan";

            var now = DateTime.Now;
            var value = now.ToString();

            spField.TypeGet = () => SPFieldType.DateTime;
            spField.IdGet = () => guid;
            spField.SchemaXmlGet = () => "Format=\"DateTime\"";

            listItem.ItemGetGuid = _ => value;

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_DateTime2IsLessThan_ReturnsTrue()
        {
            // Arrange
            const string where = "";
            const string condition = "IsLessThan";

            var now = DateTime.Now;
            var value = now.ToString();

            spField.TypeGet = () => SPFieldType.DateTime;
            spField.IdGet = () => guid;
            spField.SchemaXmlGet = () => "Format=\"NotDateTime\"";

            listItem.ItemGetGuid = _ => now.AddDays(-1).ToString();

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_DateTime2IsLessThan_ReturnsFalse()
        {
            // Arrange
            const string where = "";
            const string condition = "IsLessThan";

            var now = DateTime.Now;
            var value = now.ToString();

            spField.TypeGet = () => SPFieldType.DateTime;
            spField.IdGet = () => guid;
            spField.SchemaXmlGet = () => "Format=\"NotDateTime\"";

            listItem.ItemGetGuid = _ => value;

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_NumberIsLessThan_ReturnsTrue()
        {
            // Arrange
            const string where = "";
            const string condition = "IsLessThan";
            const string value = "5";

            spField.TypeGet = () => SPFieldType.Number;
            spField.IdGet = () => guid;

            listItem.ItemGetGuid = _ => "-10";

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_NumberIsLessThan_ReturnsFalse()
        {
            // Arrange
            const string where = "";
            const string condition = "IsLessThan";
            const string value = "5";

            spField.TypeGet = () => SPFieldType.Number;
            spField.IdGet = () => guid;

            listItem.ItemGetGuid = _ => value;

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_CurrencyIsLessThan_ReturnsTrue()
        {
            // Arrange
            const string where = "";
            const string condition = "IsLessThan";
            const string value = "5";

            spField.TypeGet = () => SPFieldType.Currency;
            spField.IdGet = () => guid;

            listItem.ItemGetGuid = _ => "-10";

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_CurrencyIsLessThan_ReturnsFalse()
        {
            // Arrange
            const string where = "";
            const string condition = "IsLessThan";
            const string value = "5";

            spField.TypeGet = () => SPFieldType.Currency;
            spField.IdGet = () => guid;

            listItem.ItemGetGuid = _ => value;

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_TextIsLessThan_ReturnsFalse()
        {
            // Arrange
            const string where = "";
            const string condition = "IsLessThan";
            const string value = "[Me]";

            spField.TypeGet = () => SPFieldType.Text;
            spField.IdGet = () => guid;
            spField.GetFieldValueAsTextObject = _ => UserName;

            listItem.ItemGetGuid = _ => UserName;

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_DateTimeIsLessThanOrEqual_ReturnsTrue()
        {
            // Arrange
            const string where = "";
            const string condition = "IsLessThanOrEqual";

            var now = DateTime.Now;
            var value = now.ToString();

            spField.TypeGet = () => SPFieldType.DateTime;
            spField.IdGet = () => guid;
            spField.SchemaXmlGet = () => "Format=\"DateTime\"";

            listItem.ItemGetGuid = _ => value;

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_DateTimeIsLessThanOrEqual_ReturnsFalse()
        {
            // Arrange
            const string where = "";
            const string condition = "IsLessThanOrEqual";

            var now = DateTime.Now;
            var value = now.ToString();

            spField.TypeGet = () => SPFieldType.DateTime;
            spField.IdGet = () => guid;
            spField.SchemaXmlGet = () => "Format=\"DateTime\"";

            listItem.ItemGetGuid = _ => now.AddDays(1).ToString();

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_DateTime2IsLessThanOrEqual_ReturnsTrue()
        {
            // Arrange
            const string where = "";
            const string condition = "IsLessThanOrEqual";

            var now = DateTime.Now;
            var value = now.ToString();

            spField.TypeGet = () => SPFieldType.DateTime;
            spField.IdGet = () => guid;
            spField.SchemaXmlGet = () => "Format=\"NotDateTime\"";

            listItem.ItemGetGuid = _ => value;

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_DateTime2IsLessThanOrEqual_ReturnsFalse()
        {
            // Arrange
            const string where = "";
            const string condition = "IsLessThanOrEqual";

            var now = DateTime.Now;
            var value = now.ToString();

            spField.TypeGet = () => SPFieldType.DateTime;
            spField.IdGet = () => guid;
            spField.SchemaXmlGet = () => "Format=\"NotDateTime\"";

            listItem.ItemGetGuid = _ => now.AddDays(1).ToString();

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_NumberIsLessThanOrEqual_ReturnsTrue()
        {
            // Arrange
            const string where = "";
            const string condition = "IsLessThanOrEqual";
            const string value = "5";

            spField.TypeGet = () => SPFieldType.Number;
            spField.IdGet = () => guid;

            listItem.ItemGetGuid = _ => value;

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_NumberIsLessThanOrEqual_ReturnsFalse()
        {
            // Arrange
            const string where = "";
            const string condition = "IsLessThanOrEqual";
            const string value = "5";

            spField.TypeGet = () => SPFieldType.Number;
            spField.IdGet = () => guid;

            listItem.ItemGetGuid = _ => "10";

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_CurrencyIsLessThanOrEqual_ReturnsTrue()
        {
            // Arrange
            const string where = "";
            const string condition = "IsLessThanOrEqual";
            const string value = "5";

            spField.TypeGet = () => SPFieldType.Currency;
            spField.IdGet = () => guid;

            listItem.ItemGetGuid = _ => value;

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void WhereField_CurrencyIsLessThanOrEqual_ReturnsFalse()
        {
            // Arrange
            const string where = "";
            const string condition = "IsLessThanOrEqual";
            const string value = "5";

            spField.TypeGet = () => SPFieldType.Currency;
            spField.IdGet = () => guid;

            listItem.ItemGetGuid = _ => "10";

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_TextIsLessThanOrEqual_ReturnsFalse()
        {
            // Arrange
            const string where = "";
            const string condition = "IsLessThanOrEqual";
            const string value = "[Me]";

            spField.TypeGet = () => SPFieldType.Text;
            spField.IdGet = () => guid;
            spField.GetFieldValueAsTextObject = _ => UserName;

            listItem.ItemGetGuid = _ => UserName;

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_TextContains_ReturnsFalse()
        {
            // Arrange
            const string where = "";
            const string condition = "Contains";
            const string value = "someString";

            spField.TypeGet = () => SPFieldType.Text;
            spField.IdGet = () => guid;
            spField.GetFieldValueAsTextObject = _ => UserName;

            listItem.ItemGetGuid = _ => UserName;

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereField_TextContains_ReturnsTrue()
        {
            // Arrange
            const string where = "";
            const string condition = "Contains";
            const string value = "[Me]";

            spField.TypeGet = () => SPFieldType.Text;
            spField.IdGet = () => guid;
            spField.GetFieldValueAsTextObject = _ => UserName;

            listItem.ItemGetGuid = _ => UserName;

            // Act
            var actual = (bool)_privateObj.Invoke(
                WhereFieldMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { spField.Instance, where, condition, value, listItem.Instance });

            // Assert
            actual.ShouldBeTrue();
        }
    }
}

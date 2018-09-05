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
        private const string CanEditMethodName = "canEdit";
        private const string RenderFieldMethodName = "RenderField";
        private const string IsDisplayFieldMethodName = "IsDisplayField";
        private const string IsEditableFieldMethodName = "isEditableField";
        private const string GetFieldSchemaAttribValueMethodName = "getFieldSchemaAttribValue";
        private const string InternalNameString = "InternalName";
        private const string EditableString = "Editable";
        private const string UserDisplaySettings = ";[Me];condition;group";
        private const string FieldDisplaySettings = ";[Field];condition;group";

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
        public void GetFieldSchemaAttribValue__ReturnsString()
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
    }
}

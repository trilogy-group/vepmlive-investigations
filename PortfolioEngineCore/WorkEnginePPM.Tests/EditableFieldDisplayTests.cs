using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace WorkEnginePPM.Tests
{
    [TestClass, ExcludeFromCodeCoverage]
    public class EditableFieldDisplayTests
    {
        private IDisposable _shimsObject;
        private PrivateType _privateType;
        private const string DummyFieldName = "DummyFieldName";
        private const string DummyGroup = "DummyGroup";
        private const string DummyValue = "DummyValue";
        private const string DummyUser = "DummyUser";

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsObject = ShimsContext.Create();
            _privateType = new PrivateType(typeof(EditableFieldDisplay));
            SetupShims();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsObject?.Dispose();
        }

        public void SetupShims()
        {
            const string Group = "group";

            var userGroups = new ShimSPGroupCollection().Instance;
            userGroups.Add(DummyGroup, null, null, Group);

            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    CurrentUserGet = () => new ShimSPUser()
                    {
                        GroupsGet = () => userGroups,
                        NameGet = () => DummyUser
                    }
                }
            };

            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPGroup>()
            {
                new ShimSPGroup()
                {
                    NameGet = () => DummyGroup
                }
            }.GetEnumerator();
        }

        [TestMethod]
        public void CanEdit_fieldPropertiesMe_ReturnTrue()
        {
            // Arrange
            var customValue = $"where;[Me];IsInGroup;{DummyGroup}";
            var field = new ShimSPField()
            {
                InternalNameGet = () => DummyFieldName
            };
            var fieldProperties = new Dictionary<string, Dictionary<string, string>>
            {
                {
                    DummyFieldName, new Dictionary<string, string>
                    {
                        { "Editable", customValue }
                    }
                }
            };

            var listItem = new ShimSPListItem();

            // Act
            var actualResult = EditableFieldDisplay.canEdit(field, fieldProperties, listItem);

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void CanEdit_fieldPropertiesNotMe_ReturnTrue()
        {
            // Arrange
            var customValue = $"where;[NotMe];IsNotInGroup;{DummyGroup}";
            var field = new ShimSPField()
            {
                InternalNameGet = () => DummyFieldName
            };
            var fieldProperties = new Dictionary<string, Dictionary<string, string>>
            {
                {
                    DummyFieldName, new Dictionary<string, string>
                    {
                        { "Editable", customValue }
                    }
                }
            };

            var listItem = new ShimSPListItem();

            // Act
            var actualResult = EditableFieldDisplay.canEdit(field, fieldProperties, listItem);

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void CanEdit_fieldPropertiesNotMeShowInEditFormHasValue_ReturnTrue()
        {
            // Arrange
            var customValue = $"where;[NotMe];IsNotInGroup;{DummyGroup}";
            var field = new ShimSPField()
            {
                InternalNameGet = () => DummyFieldName,
                ShowInEditFormGet = () => true
            };
            var fieldProperties = new Dictionary<string, Dictionary<string, string>>
            {
                {
                    DummyFieldName, new Dictionary<string, string>
                    {
                        { "Editable", customValue }
                    }
                }
            };

            var listItem = new ShimSPListItem();

            // Act
            var actualResult = EditableFieldDisplay.canEdit(field, fieldProperties, listItem);

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void RenderField_WithoutCondition_ReturnsFalse()
        {
            // Arrange
            var fieldId = Guid.NewGuid();
            var field = new ShimSPField()
            {
                IdGet = () => fieldId,
                InternalNameGet = () => DummyFieldName,
                TypeGet = () => SPFieldType.Text
            };

            var listItem = new ShimSPListItem()
            {
                ItemGetGuid = guid => DummyValue,
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    GetFieldByInternalNameString = internalName => new ShimSPField()
                    {
                        TypeGet = () => SPFieldType.Text,
                        GetFieldValueAsTextObject = item => DummyValue
                    }
                }
            };

            var where = "NotMe";
            var conditionField = "Name";
            var condition = string.Empty;
            var group = string.Empty;
            var valueCondition = string.Empty;

            // Act
            var actualResult = EditableFieldDisplay.RenderField(
                field,
                where,
                conditionField,
                condition,
                group,
                valueCondition,
                listItem);

            // Assert
            actualResult.ShouldBeFalse();
        }

        [TestMethod]
        public void WhereUser_IsInGroupFalse_ReturnsTrue()
        {
            // Arrange, Act
            var actualResult = (bool)_privateType.InvokeStatic("WhereUser", "NoGroup", "None");

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void IsNumeric_ValidValue_ReturnsTrue()
        {
            // Arrange, Act
            var actualResult = (bool)_privateType.InvokeStatic("IsNumeric", "1000");

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void IsNumeric_ValidValue_ReturnsFalse()
        {
            // Arrange, Act
            var actualResult = (bool)_privateType.InvokeStatic("IsNumeric", "A000");

            // Assert
            actualResult.ShouldBeFalse();
        }
    }
}

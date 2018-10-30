﻿using System;
using System.Collections.Generic;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace WorkEnginePPM.Tests
{
    [TestClass]
    public class IntegrationTests
    {
        private const string InternalName = "InternalName";
        private const string DummyText = "Dummy";
        private const string IsEditableMethod = "isEditable";
        private const string EditKey = "Edit";
        private const string EditableKey = "Editable";
        private IDisposable _shimsObject;
        private Integration _testObj;
        private PrivateObject _privateObj;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsObject = ShimsContext.Create();
            _testObj = new Integration();
            _privateObj = new PrivateObject(_testObj);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsObject?.Dispose();
        }

        [TestMethod]
        public void IsEditable_NoEdit_ReturnsTrue()
        {
            // Arrange
            var listItem = new ShimSPListItem();
            var field = new ShimSPField
            {
                InternalNameGet = () => InternalName
            };

            var fieldProperties = new Dictionary<string, Dictionary<string, string>>
            {
                [InternalName] = new Dictionary<string, string>
                {
                    [DummyText] = DummyText
                }
            };

            // Act
            var result = (bool)_privateObj.Invoke(IsEditableMethod, listItem.Instance, field.Instance, fieldProperties);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void IsEditable_EditFieldRenderFieldFalse_ReturnsFalse()
        {
            // Arrange
            var listItem = new ShimSPListItem();
            var field = new ShimSPField
            {
                InternalNameGet = () => InternalName
            };

            var fieldProperties = new Dictionary<string, Dictionary<string, string>>
            {
                [InternalName] = new Dictionary<string, string>
                {
                    [EditKey] = "where;[Me];equals;group1;valueCondition1"
                }
            };

            ShimEditableFieldDisplay.RenderFieldSPFieldStringStringStringStringStringSPListItem = (spField, s, arg3, arg4, arg5, arg6, arg7) => false;

            // Act
            var result = (bool)_privateObj.Invoke(IsEditableMethod, listItem.Instance, field.Instance, fieldProperties);

            // Assert
            result.ShouldBeFalse();
        }

        [TestMethod]
        public void IsEditable_EditableFieldRenderFieldTrue_ReturnsTrue()
        {
            // Arrange
            var listItem = new ShimSPListItem();
            var field = new ShimSPField
            {
                InternalNameGet = () => InternalName
            };

            var fieldProperties = new Dictionary<string, Dictionary<string, string>>
            {
                [InternalName] = new Dictionary<string, string>
                {
                    [EditKey] = DummyText,
                    [EditableKey] = "where;[Me];equals;group1;valueCondition1"
                }
            };

            ShimEditableFieldDisplay.RenderFieldSPFieldStringStringStringStringStringSPListItem = (spField, s, arg3, arg4, arg5, arg6, arg7) => true;

            // Act
            var result = (bool)_privateObj.Invoke(IsEditableMethod, listItem.Instance, field.Instance, fieldProperties);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void IsEditable_EditableNever_ReturnsFalse()
        {
            // Arrange
            var listItem = new ShimSPListItem();
            var field = new ShimSPField
            {
                InternalNameGet = () => InternalName
            };

            var fieldProperties = new Dictionary<string, Dictionary<string, string>>
            {
                [InternalName] = new Dictionary<string, string>
                {
                    [EditKey] = DummyText,
                    [EditableKey] = "Never"
                }
            };

            // Act
            var result = (bool)_privateObj.Invoke(IsEditableMethod, listItem.Instance, field.Instance, fieldProperties);

            // Assert
            result.ShouldBeFalse();
        }

        [TestMethod]
        public void IsEditable_EditableNoWhere_ReturnsTrue()
        {
            // Arrange
            var listItem = new ShimSPListItem();
            var field = new ShimSPField
            {
                InternalNameGet = () => InternalName
            };

            var fieldProperties = new Dictionary<string, Dictionary<string, string>>
            {
                [InternalName] = new Dictionary<string, string>
                {
                    [EditKey] = DummyText,
                    [EditableKey] = DummyText
                }
            };

            // Act
            var result = (bool)_privateObj.Invoke(IsEditableMethod, listItem.Instance, field.Instance, fieldProperties);

            // Assert
            result.ShouldBeTrue();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using EPMLiveCore.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveCore.Tests
{
    public partial class ListDisplaySettingIteratorTests
    {
        private const string IsFieldExcludedMethod = "IsFieldExcluded";
        private const string FieldPropertiesField = "fieldProperties";

        [TestMethod]
        public void IsFieldExcluded_Should_Call_Base()
        {
            // Arrange
            var wasCalled = false;
            ShimListFieldIterator.AllInstances.IsFieldExcludedSPField = (a, b) =>
            {
                wasCalled = true;
                return wasCalled;
            };

            // Act 
            _privateObject.Invoke(IsFieldExcludedMethod, new ShimSPField().Instance);

            // Assert
            Assert.IsTrue(wasCalled);
        }

        [TestMethod]
        public void IsFieldExcluded_With_IsFeatureActivate_IsResList_Should_Call_Base()
        {
            // Arrange
            var wasCalled = false;
            ShimListFieldIterator.AllInstances.IsFieldExcludedSPField = (a, b) =>
            {
                wasCalled = true;
                return wasCalled;
            };

            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);            
            _privateObject.SetFieldOrProperty(IsResListField, true);
            
            // Act 
            _privateObject.Invoke(IsFieldExcludedMethod, new ShimSPField().Instance);

            // Assert
            Assert.IsTrue(wasCalled);
        }

        [TestMethod]
        public void IsFieldExcluded_With_IsOnline_Should_Return_True()
        {
            // Arrange
            ShimSPField.AllInstances.InternalNameGet = _ => "SharePointAccount";

            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty("isOnline", true);

            // Act 
            var actual = (bool)_privateObject.Invoke(IsFieldExcludedMethod, new ShimSPField().Instance);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsFieldExcluded_With_InternalName_ResourceLevel_Should_Return_True()
        {
            // Arrange
            ShimSPField.AllInstances.InternalNameGet = _ => "ResourceLevel";

            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);

            // Act 
            var actual = (bool)_privateObject.Invoke(IsFieldExcludedMethod, new ShimSPField().Instance);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsFieldExcluded_With_InternalName_ResourceLevel_And_IsSiteAdminGet_Should_Return_True()
        {
            // Arrange
            ShimSPField.AllInstances.InternalNameGet = _ => "ResourceLevel";
            ShimSPUser.AllInstances.IsSiteAdminGet = _ => true;
            ShimAct.ConstructorSPWeb = (a, b) => { };
            ShimAct.AllInstances.GetLevelsFromSiteInt32OutString = (Act act, out int actType, string userName) =>
            {
                actType = 0;
                return new ArrayList();
            };

            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);

            // Act 
            var actual = (bool)_privateObject.Invoke(IsFieldExcludedMethod, new ShimSPField().Instance);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsFieldExcluded_With_InternalName_ResourceLevel_And_IsSiteAdminGet_Should_Return_False()
        {
            // Arrange
            ShimSPField.AllInstances.InternalNameGet = _ => "ResourceLevel";
            ShimSPUser.AllInstances.IsSiteAdminGet = _ => true;
            ShimAct.ConstructorSPWeb = (a, b) => { };
            ShimAct.AllInstances.GetLevelsFromSiteInt32OutString = (Act act, out int actType, string userName) =>
            {
                actType = 3;
                return new ArrayList();
            };

            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);

            // Act 
            var actual = (bool)_privateObject.Invoke(IsFieldExcludedMethod, new ShimSPField().Instance);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsFieldExcluded_With_InternalName_Permissions_And_New_Should_Return_False()
        {
            // Arrange
            ShimSPField.AllInstances.InternalNameGet = _ => "Permissions";
            
            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(ModeField, SPControlMode.New);

            // Act 
            var actual = (bool)_privateObject.Invoke(IsFieldExcludedMethod, new ShimSPField().Instance);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsFieldExcluded_With_InternalName_Permissions_And_Display_Should_Return_False()
        {
            // Arrange
            ShimSPField.AllInstances.InternalNameGet = _ => "Permissions";
            ShimFormComponent.AllInstances.ListItemGet = _ => new ShimSPListItem();
            ShimSPListItem.AllInstances.ItemGetString = (a, b) => "False";

            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(ModeField, SPControlMode.Display);

            // Act 
            var actual = (bool)_privateObject.Invoke(IsFieldExcludedMethod, new ShimSPField().Instance);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsFieldExcluded_With_InternalName_Permissions_And_Display_Should_Return_True()
        {
            // Arrange
            ShimSPField.AllInstances.InternalNameGet = _ => "Permissions";
            ShimFormComponent.AllInstances.ListItemGet = _ => new ShimSPListItem();
            ShimSPListItem.AllInstances.ItemGetString = (a, b) => string.Empty;

            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(ModeField, SPControlMode.Display);

            // Act 
            var actual = (bool)_privateObject.Invoke(IsFieldExcludedMethod, new ShimSPField().Instance);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsFieldExcluded_With_InternalName_Title_Should_Return_True()
        {
            // Arrange
            ShimSPField.AllInstances.InternalNameGet = _ => "Title";
            ShimFormComponent.AllInstances.ListItemGet = _ => new ShimSPListItem();
            ShimSPListItem.AllInstances.ItemGetString = (a, b) => false.ToString();

            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(ModeField, SPControlMode.Edit);

            // Act 
            var actual = (bool)_privateObject.Invoke(IsFieldExcludedMethod, new ShimSPField().Instance);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsFieldExcluded_With_InternalName_Title_Should_Return_False()
        {
            // Arrange
            ShimSPField.AllInstances.InternalNameGet = _ => "Title";
            ShimFormComponent.AllInstances.ListItemGet = _ => new ShimSPListItem();
            ShimSPListItem.AllInstances.ItemGetString = (a, b) => true.ToString();

            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(ModeField, SPControlMode.Edit);

            // Act 
            var actual = (bool)_privateObject.Invoke(IsFieldExcludedMethod, new ShimSPField().Instance);

            // Assert
            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void IsFieldExcluded_With_InternalName_LastName_Should_Return_False()
        {
            // Arrange
            ShimSPField.AllInstances.InternalNameGet = _ => "LastName";
            ShimFormComponent.AllInstances.ListItemGet = _ => new ShimSPListItem();
            ShimSPListItem.AllInstances.ItemGetString = (a, b) => string.Empty;

            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(ModeField, SPControlMode.Invalid);

            // Act 
            var actual = (bool)_privateObject.Invoke(IsFieldExcludedMethod, new ShimSPField().Instance);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsFieldExcluded_With_InternalName_LastName_Should_Return_True()
        {
            // Arrange
            ShimSPField.AllInstances.InternalNameGet = _ => "LastName";
            ShimFormComponent.AllInstances.ListItemGet = _ => new ShimSPListItem();
            ShimSPListItem.AllInstances.ItemGetString = (a, b) => true.ToString();

            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(ModeField, SPControlMode.Invalid);

            // Act 
            var actual = (bool)_privateObject.Invoke(IsFieldExcludedMethod, new ShimSPField().Instance);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsFieldExcluded_With_InternalName_LastName_Edit_Should_Return_False1()
        {
            // Arrange
            ShimSPField.AllInstances.InternalNameGet = _ => "LastName";

            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(ModeField, SPControlMode.New);

            // Act 
            var actual = (bool)_privateObject.Invoke(IsFieldExcludedMethod, new ShimSPField().Instance);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsFieldExcluded_With_InternalName_LastName_Edit_Should_Return_False2()
        {
            // Arrange
            ShimSPField.AllInstances.InternalNameGet = _ => "LastName";

            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(ModeField, SPControlMode.New);

            // Act 
            var actual = (bool)_privateObject.Invoke(IsFieldExcludedMethod, new ShimSPField().Instance);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsFieldExcluded_With_InternalName_Email_Should_Return_False()
        {
            // Arrange
            ShimSPField.AllInstances.InternalNameGet = _ => "Email";

            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(ModeField, SPControlMode.New);

            // Act 
            var actual = (bool)_privateObject.Invoke(IsFieldExcludedMethod, new ShimSPField().Instance);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsFieldExcluded_With_InternalName_Email_Should_Return_True()
        {
            // Arrange
            ShimSPField.AllInstances.InternalNameGet = _ => "Email";

            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(ModeField, SPControlMode.Invalid);

            // Act 
            var actual = (bool)_privateObject.Invoke(IsFieldExcludedMethod, new ShimSPField().Instance);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsFieldExcluded_With_InternalName_CanLogin_Should_Return_True()
        {
            // Arrange
            ShimSPField.AllInstances.InternalNameGet = _ => "CanLogin";
            
            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            
            // Act 
            var actual = (bool)_privateObject.Invoke(IsFieldExcludedMethod, new ShimSPField().Instance);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsFieldExcluded_With_InternalName_Generic_Should_Return_False()
        {
            // Arrange
            ShimSPField.AllInstances.InternalNameGet = _ => "Generic";

            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(ModeField, SPControlMode.New);

            // Act 
            var actual = (bool)_privateObject.Invoke(IsFieldExcludedMethod, new ShimSPField().Instance);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsFieldExcluded_With_InternalName_Generic_Should_Return_True()
        {
            // Arrange
            ShimSPField.AllInstances.InternalNameGet = _ => "Generic";

            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(ModeField, SPControlMode.Invalid);

            // Act 
            var actual = (bool)_privateObject.Invoke(IsFieldExcludedMethod, new ShimSPField().Instance);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsFieldExcluded_With_InternalName_Approved_Should_Return_True1()
        {
            // Arrange
            ShimSPField.AllInstances.InternalNameGet = _ => "Approved";
            ShimSPField.AllInstances.ParentListGet = _ => new ShimSPList();
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimExtensionMethods.ContainsFieldWithInternalNameSPFieldCollectionString = (a, b) => true;

            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(ModeField, SPControlMode.Invalid);

            // Act 
            var actual = (bool)_privateObject.Invoke(IsFieldExcludedMethod, new ShimSPField().Instance);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsFieldExcluded_With_InternalName_Approved_Should_Return_True2()
        {
            // Arrange
            ShimSPField.AllInstances.InternalNameGet = _ => "Approved";
            ShimSPWeb.AllInstances.UserIsSiteAdminGet = _ => false;
            ShimSPField.AllInstances.ParentListGet = _ => new ShimSPList();
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimExtensionMethods.ContainsFieldWithInternalNameSPFieldCollectionString = (a, b) => false;

            ShimFormComponent.AllInstances.ListItemGet = _ => new ShimSPListItem();
            ShimSPListItem.AllInstances.ItemGetString = (a, b) => "False";

            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(ModeField, SPControlMode.Invalid);

            // Act 
            var actual = (bool)_privateObject.Invoke(IsFieldExcludedMethod, new ShimSPField().Instance);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsFieldExcluded_With_InternalName_Approved_Should_Return_False()
        {
            // Arrange
            ShimSPField.AllInstances.InternalNameGet = _ => "Approved";
            ShimSPWeb.AllInstances.UserIsSiteAdminGet= _ => true;
            ShimSPField.AllInstances.ParentListGet = _ => new ShimSPList();
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimExtensionMethods.ContainsFieldWithInternalNameSPFieldCollectionString = (a, b) => false;

            ShimFormComponent.AllInstances.ListItemGet = _ => new ShimSPListItem();
            ShimSPListItem.AllInstances.ItemGetString = (a, b) => "False";

            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(ModeField, SPControlMode.Invalid);

            // Act 
            var actual = (bool)_privateObject.Invoke(IsFieldExcludedMethod, new ShimSPField().Instance);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsFieldExcluded_With_IsFeatureActivate_IsResList_FieldProperties_Should_Call_Base()
        {
            // Arrange
            var wasCalled = false;
            ShimListFieldIterator.AllInstances.IsFieldExcludedSPField = (a, b) =>
            {
                wasCalled = true;
                return wasCalled;
            };

            var fieldProperties = new Dictionary<string, Dictionary<string, string>>();

            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(FieldPropertiesField, fieldProperties);

            // Act 
            _privateObject.Invoke(IsFieldExcludedMethod, new ShimSPField().Instance);

            // Assert
            Assert.IsTrue(wasCalled);
        }

        [TestMethod]
        public void IsFieldExcluded_With_IsFeatureActivate_IsResList_FieldProperties_Display_Me()
        {
            // Arrange
            var expected = false;
            var fieldProperties = new Dictionary<string, Dictionary<string, string>>()
            {
                ["name"] = new Dictionary<string, string>()
                {
                    ["Display"] = "where;[Me];condition;group"
                }
            };
            ShimEditableFieldDisplay.RenderFieldSPFieldStringStringStringStringStringSPListItem = (a, b, c, d, e, f, g) => !expected;

            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(FieldPropertiesField, fieldProperties);
            _privateObject.SetFieldOrProperty(ModeField, SPControlMode.Display);

            // Act 
            var actual = _privateObject.Invoke(IsFieldExcludedMethod, new ShimSPField().Instance);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsFieldExcluded_With_IsFeatureActivate_IsResList_FieldProperties_Display()
        {
            // Arrange
            var expected = false;
            var fieldProperties = new Dictionary<string, Dictionary<string, string>>()
            {
                ["name"] = new Dictionary<string, string>()
                {
                    ["Display"] = "where;;condition;group;value"
                }
            };
            ShimEditableFieldDisplay.RenderFieldSPFieldStringStringStringStringStringSPListItem = (a, b, c, d, e, f, g) => !expected;

            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(FieldPropertiesField, fieldProperties);
            _privateObject.SetFieldOrProperty(ModeField, SPControlMode.Display);

            // Act 
            var actual = _privateObject.Invoke(IsFieldExcludedMethod, new ShimSPField().Instance);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsFieldExcluded_With_IsFeatureActivate_IsResList_FieldProperties_Display_Should_Call_Base()
        {
            // Arrange
            var fieldProperties = new Dictionary<string, Dictionary<string, string>>()
            {
                ["name"] = new Dictionary<string, string>()
                {
                    ["Display"] = string.Empty
                }
            };
            var wasCalled = false;
            ShimListFieldIterator.AllInstances.IsFieldExcludedSPField = (a, b) =>
            {
                wasCalled = true;
                return wasCalled;
            };

            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(FieldPropertiesField, fieldProperties);
            _privateObject.SetFieldOrProperty(ModeField, SPControlMode.Display);

            // Act 
            var actual = _privateObject.Invoke(IsFieldExcludedMethod, new ShimSPField().Instance);

            // Assert
            Assert.IsTrue(wasCalled);
        }

        [TestMethod]
        public void IsFieldExcluded_With_IsFeatureActivate_IsResList_FieldProperties_Edit_Me()
        {
            // Arrange
            var expected = false;
            var fieldProperties = new Dictionary<string, Dictionary<string, string>>()
            {
                ["name"] = new Dictionary<string, string>()
                {
                    ["Edit"] = "where;[Me];condition;group"
                }
            };
            ShimEditableFieldDisplay.RenderFieldSPFieldStringStringStringStringStringSPListItem = (a, b, c, d, e, f, g) => !expected;

            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(FieldPropertiesField, fieldProperties);
            _privateObject.SetFieldOrProperty(ModeField, SPControlMode.Edit);

            // Act 
            var actual = _privateObject.Invoke(IsFieldExcludedMethod, new ShimSPField().Instance);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsFieldExcluded_With_IsFeatureActivate_IsResList_FieldProperties_Edit()
        {
            // Arrange
            var expected = false;
            var fieldProperties = new Dictionary<string, Dictionary<string, string>>()
            {
                ["name"] = new Dictionary<string, string>()
                {
                    ["Edit"] = "where;;condition;group;value"
                }
            };
            ShimEditableFieldDisplay.RenderFieldSPFieldStringStringStringStringStringSPListItem = (a, b, c, d, e, f, g) => !expected;

            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(FieldPropertiesField, fieldProperties);
            _privateObject.SetFieldOrProperty(ModeField, SPControlMode.Edit);

            // Act 
            var actual = _privateObject.Invoke(IsFieldExcludedMethod, new ShimSPField().Instance);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsFieldExcluded_With_IsFeatureActivate_IsResList_FieldProperties_Edit_Should_Call_Base()
        {
            // Arrange
            var fieldProperties = new Dictionary<string, Dictionary<string, string>>()
            {
                ["name"] = new Dictionary<string, string>()
                {
                    ["Display"] = string.Empty
                }
            };
            var wasCalled = false;
            ShimListFieldIterator.AllInstances.IsFieldExcludedSPField = (a, b) =>
            {
                wasCalled = true;
                return wasCalled;
            };

            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(FieldPropertiesField, fieldProperties);
            _privateObject.SetFieldOrProperty(ModeField, SPControlMode.Edit);

            // Act 
            var actual = _privateObject.Invoke(IsFieldExcludedMethod, new ShimSPField().Instance);

            // Assert
            Assert.IsTrue(wasCalled);
        }

        [TestMethod]
        public void IsFieldExcluded_With_IsFeatureActivate_IsResList_FieldProperties_New_Me()
        {
            // Arrange
            var expected = false;
            var fieldProperties = new Dictionary<string, Dictionary<string, string>>()
            {
                ["name"] = new Dictionary<string, string>()
                {
                    ["New"] = "where;[Me];condition;group"
                }
            };
            ShimEditableFieldDisplay.RenderFieldSPFieldStringStringStringStringStringSPListItem = (a, b, c, d, e, f, g) => !expected;

            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(FieldPropertiesField, fieldProperties);
            _privateObject.SetFieldOrProperty(ModeField, SPControlMode.New);

            // Act 
            var actual = _privateObject.Invoke(IsFieldExcludedMethod, new ShimSPField().Instance);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsFieldExcluded_With_IsFeatureActivate_IsResList_FieldProperties_New()
        {
            // Arrange
            var expected = false;
            var fieldProperties = new Dictionary<string, Dictionary<string, string>>()
            {
                ["name"] = new Dictionary<string, string>()
                {
                    ["New"] = "where;;condition;group;value"
                }
            };
            ShimEditableFieldDisplay.RenderFieldSPFieldStringStringStringStringStringSPListItem = (a, b, c, d, e, f, g) => !expected;

            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(FieldPropertiesField, fieldProperties);
            _privateObject.SetFieldOrProperty(ModeField, SPControlMode.New);

            // Act 
            var actual = _privateObject.Invoke(IsFieldExcludedMethod, new ShimSPField().Instance);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsFieldExcluded_With_IsFeatureActivate_IsResList_FieldProperties_New_Should_Call_Base()
        {
            // Arrange
            var fieldProperties = new Dictionary<string, Dictionary<string, string>>()
            {
                ["name"] = new Dictionary<string, string>()
                {
                    ["Display"] = string.Empty
                }
            };
            var wasCalled = false;
            ShimListFieldIterator.AllInstances.IsFieldExcludedSPField = (a, b) =>
            {
                wasCalled = true;
                return wasCalled;
            };

            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(FieldPropertiesField, fieldProperties);
            _privateObject.SetFieldOrProperty(ModeField, SPControlMode.New);

            // Act 
            var actual = _privateObject.Invoke(IsFieldExcludedMethod, new ShimSPField().Instance);

            // Assert
            Assert.IsTrue(wasCalled);
        }

        [TestMethod]
        public void IsFieldExcluded_With_IsFeatureActivate_IsResList_FieldProperties_Invalid()
        {
            // Arrange
            var wasCalled = false;
            ShimListFieldIterator.AllInstances.IsFieldExcludedSPField = (a, b) =>
            {
                wasCalled = true;
                return wasCalled;
            };

            var fieldProperties = new Dictionary<string, Dictionary<string, string>>()
            {
                ["name"] = new Dictionary<string, string>()
            };

            _privateObject.SetFieldOrProperty(IsFeatureActivatedField, true);
            _privateObject.SetFieldOrProperty(IsResListField, true);
            _privateObject.SetFieldOrProperty(FieldPropertiesField, fieldProperties);
            _privateObject.SetFieldOrProperty(ModeField, SPControlMode.Invalid);

            // Act 
            _privateObject.Invoke(IsFieldExcludedMethod, new ShimSPField().Instance);

            // Assert
            Assert.IsTrue(wasCalled);
        }
    }
}

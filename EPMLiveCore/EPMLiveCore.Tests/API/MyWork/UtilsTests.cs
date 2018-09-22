using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Linq.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveCore.Tests.API.MyWork
{
    using EPMLiveCore.API;
    using EPMLiveCore.API.Fakes;
    using Fakes;
    using Shouldly;

    [TestClass]
    public class UtilsTests
    {
        private static readonly Guid DummyGuid = Guid.NewGuid();
        private const string DummyString = "DummyString";
        private const string GetCleanValueFromFormattedMethodName = "GetCleanValueFromFormatted";
        private const string FormatTypeName = "Format";
        private const string TypeName = "Type";
        private IDisposable shimContext;
        private PrivateType privateType;

        [TestInitialize]
        public void Initialize()
        {
            shimContext = ShimsContext.Create();
            SetupShims();
            privateType = new PrivateType(typeof(Utils));
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimContext?.Dispose();
        }

        private void SetupShims()
        {
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPSite.AllInstances.UrlGet = _ => "DummyUrl";
            ShimSPSite.ConstructorString = (_, url) => { };
            ShimSPSite.AllInstances.OpenWeb = _ => new ShimSPWeb();
            ShimCoreFunctions.getLockedWebSPWeb = _ => DummyGuid;
        }

        private IEnumerable<XElement> GetXElementList()
        {
            return new List<XElement>
            {
                new ShimXElement
                {
                    NameGet = () => new ShimXName
                    {
                        LocalNameGet = () => "List"
                    }.Instance
                }.Instance,
                new ShimXElement
                {
                    NameGet = () => new ShimXName
                    {
                        LocalNameGet = () => "Web"
                    }
                },
                new ShimXElement
                {
                    NameGet = () => new ShimXName
                    {
                        LocalNameGet = () => "Site"
                    }
                },
                new ShimXElement
                {
                    NameGet = () => new ShimXName
                    {
                        LocalNameGet = () => "Item"
                    }
                }
            };
        }

        private FakesDelegates.Func<XContainer, XName, XElement> GetDummyXElement(string itemName)
        {
            return (container, name) =>
            {
                if (name == itemName)
                {
                    return new ShimXElement
                    {
                        Attributes = () => new List<XAttribute>()
                    };
                }
                else
                {
                    return new ShimXElement
                    {
                        Attributes = () => new List<XAttribute>
                        {
                            new XAttribute("ID", 1)
                        }
                    };
                }
            };
        }

        [TestMethod]
        public void GetConfigWeb_Should_ReturnSPWeb()
        {
            // Arrange
            ShimUtils.GetConfigWebSPWebGuid = (web, guid) => new ShimSPWeb();

            // Act
            var result = Utils.GetConfigWeb();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ToGridSafeFieldName_Should_ReturnContent()
        {
            // Arrange, Act
            var result = Utils.ToGridSafeFieldName("Name");

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
        }

        [TestMethod]
        public void AddItemListWebSiteToXElement_Should_AddItems()
        {
            // Arrange
            var element = new ShimXElement().Instance;
            var elementsAdded = new List<object>();
            ShimXContainer.AllInstances.AddObject = (_, newElement) =>
            {
                elementsAdded.Add(newElement);
            };
            ShimXContainer.AllInstances.ElementXName = (_, name) => new ShimXElement();

            // Act
            Utils.AddItemListWebSiteToXElement(1, DummyGuid, DummyGuid, DummyGuid, "DummyUrl", ref element);

            // Assert
            Assert.AreNotEqual(0, elementsAdded.Count);
        }

        [TestMethod]
        public void CleanGuid_Should_ReturnExpectedValue()
        {
            // Arrange
            var expectedValue = DummyGuid.ToString();
            var initialValue = $"{{{DummyGuid}}}";

            // Act
            var result = Utils.CleanGuid(initialValue);

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void GetCleanFieldValue_FieldValueEmpty_ReturnsEmpty()
        {
            // Arrange
            var field = new ShimXElement
            {
                ValueGet = () => string.Empty
            };

            // Act
            var result = Utils.GetCleanFieldValue(field);

            // Assert
            Assert.IsTrue(string.IsNullOrWhiteSpace(result));
        }

        [TestMethod]
        public void GetCleanFieldValue_FormatNoDecimal_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "2";
            var field = new ShimXElement
            {
                ValueGet = () => "2.00",
                AttributeXName = name =>
                {
                    switch (name.LocalName)
                    {
                        case FormatTypeName:
                            return new XAttribute(FormatTypeName, "NoDecimal");
                        case TypeName:
                            return new XAttribute(TypeName, "Number");
                        default:
                            return null;
                    }
                }
            };

            // Act
            var result = Utils.GetCleanFieldValue(field);

            // Assert
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetCleanFieldValue_FormatTwoDecimal_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "2.00";
            var field = new ShimXElement
            {
                ValueGet = () => "2.00",
                AttributeXName = name =>
                {
                    switch (name.LocalName)
                    {
                        case FormatTypeName:
                            return new XAttribute(FormatTypeName, "TwoDecimals");
                        case TypeName:
                            return new XAttribute(TypeName, "Number");
                        default:
                            return null;
                    }
                }
            };

            // Act
            var result = Utils.GetCleanFieldValue(field);

            // Assert
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetConfigWebGuid_Should_ReturnsSPWeb()
        {
            // Arrange
            var web = new ShimSPWeb
            {
                IDGet = () => DummyGuid,
                SiteGet = () => new ShimSPSite
                {
                    OpenWebGuid = _ => new ShimSPWeb()
                }
            };

            // Act
            var result = Utils.GetConfigWeb(web, DummyGuid);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetFieldProperties_Should_ReturnDictionary()
        {
            // Arrange
            var spList = new ShimSPList();
            ShimCoreFunctions.getListSettingStringSPList = (name, list) => string.Empty;

            // Act
            var result = Utils.GetFieldProperties(spList);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetFieldTypes_Should_ReturnDictionary()
        {
            // Arrange
            ShimUtils.GetConfigWeb = () => new ShimSPWeb
            {
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetString = name => new ShimSPList
                    {
                        FieldsGet = () =>
                        {
                            var list = new List<SPField>
                            {
                                new ShimSPField()
                                {
                                    HiddenGet = () => false,
                                    InternalNameGet = () => DummyString
                                }
                            };
                            return new ShimSPFieldCollection().Bind(list);
                        }
                    }
                }
            };

            // Act
            var result = Utils.GetFieldTypes();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Keys.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetFieldValues_FieldsElementDoesNotExists_ThrowsException()
        {
            // Arrange
            var element = new ShimXElement();
            ShimXContainer.AllInstances.Descendants = _ => new List<XElement>
            {
                new ShimXElement
                {
                    NameGet = () => new ShimXName
                    {
                        LocalNameGet = () => DummyString
                    }
                }
            };

            // Act
            var result = Utils.GetFieldValues(element);

            // Assert
            // Expects an exception
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetFieldValues_FieldElementDoesNotExists_ThrowsException()
        {
            // Arrange
            var element = new ShimXElement();
            ShimXContainer.AllInstances.Descendants = _ => new List<XElement>
            {
                new ShimXElement
                {
                    NameGet = () => new ShimXName
                    {
                        LocalNameGet = () => "Fields"
                    }
                }
            };
            ShimXContainer.AllInstances.ElementXName = (_, name) => new ShimXElement();
            // Act
            var result = Utils.GetFieldValues(element);

            // Assert
            // Expect an exception

        }

        [TestMethod]
        public void GetFieldValues_OnSuccess_ReturnsDictionary()
        {
            // Arrange
            var element = new ShimXElement();
            ShimXContainer.AllInstances.Descendants = _ => new List<XElement>
            {
                new ShimXElement
                {
                    NameGet = () => new ShimXName
                    {
                        LocalNameGet = () => "Fields"
                    }
                },
                new ShimXElement
                {
                    NameGet = () => new ShimXName
                    {
                        LocalNameGet = () => "Field"
                    }
                }
            };
            ShimXContainer.AllInstances.ElementXName = (_, name) => new ShimXElement();
            ShimXContainer.AllInstances.ElementsXName = (_, name) => new List<XElement>
            {
                new ShimXElement
                {
                    AttributeXName = attributeName => new XAttribute("Name", DummyString)
                }
            };

            // Act
            var result = Utils.GetFieldValues(element);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Keys.Count);
        }

        [TestMethod]
        public void GetItemListWebSite_Should_ExecuteCorrectly()
        {
            // Arrange
            ShimUtils.ValidateItemListWebAndSiteXElement = _ => { };
            var element = new ShimXElement();
            var listId = new Guid();
            var webId = new Guid();
            var siteId = new Guid();
            var siteUrl = string.Empty;
            var itemId = 0;
            ShimXContainer.AllInstances.ElementXName = (_, name) =>
            {
                if (name == "Item")
                {
                    return new ShimXElement
                    {
                        AttributeXName = attributeName => new ShimXAttribute
                        {
                            ValueGet = () => "1"
                        }
                    };
                }
                else
                {
                    return new ShimXElement
                    {
                        AttributeXName = attributeName => new ShimXAttribute
                        {
                            ValueGet = () => DummyGuid.ToString()
                        }
                    };
                }
            };

            // Act
            Utils.GetItemListWebSite(DummyString, element, out itemId, out listId, out webId, out siteId, out siteUrl);

            // Assert
            Assert.AreEqual(DummyGuid, listId);
            Assert.AreEqual(DummyGuid, webId);
            Assert.AreEqual(DummyGuid, siteId);
            Assert.AreEqual(1, itemId);
            Assert.IsFalse(string.IsNullOrWhiteSpace(siteUrl));
        }

        [TestMethod]
        public void GetListWebSite_Should_ExecuteCorrectly()
        {
            // Arrange
            ShimUtils.ValidateListWebAndSiteXElement = _ => { };
            var element = new ShimXElement();
            var listId = new Guid();
            var webId = new Guid();
            var siteId = new Guid();
            var siteUrl = string.Empty;
            ShimXContainer.AllInstances.ElementXName = (_, name) => new ShimXElement
            {
                AttributeXName = attributeName => new ShimXAttribute
                {
                    ValueGet = () => DummyGuid.ToString()
                }
            };

            // Act
            Utils.GetListWebSite(DummyString, element, out listId, out webId, out siteId, out siteUrl);

            // Assert
            Assert.AreEqual(DummyGuid, listId);
            Assert.AreEqual(DummyGuid, webId);
            Assert.AreEqual(DummyGuid, siteId);
            Assert.IsFalse(string.IsNullOrWhiteSpace(siteUrl));
        }

        [TestMethod]
        public void GetRelatedGridType_FieldTypeText_REturnExpectedValue()
        {
            const string ExpectedValue = "Text";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Text
            };

            // Act
            var result = Utils.GetRelatedGridType(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetRelatedGridType_FieldTypeInteger_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Float";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Integer
            };

            // Act
            var result = Utils.GetRelatedGridType(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetRelatedGridTypeForMyTimesheet_FieldTypeCurrency_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Float";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Currency
            };

            // Act
            var result = Utils.GetRelatedGridTypeForMyTimesheet(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetRelatedGridTypeForMyTimesheet_FieldTypeDateTime_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Date";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.DateTime
            };

            // Act
            var result = Utils.GetRelatedGridTypeForMyTimesheet(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetRelatedGridTypeForMyTimesheet_FieldTypeBoolean_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Bool";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Boolean
            };

            // Act
            var result = Utils.GetRelatedGridTypeForMyTimesheet(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetRelatedGridTypeForMyTimesheet_FieldTypeNote_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Lines";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Note
            };

            // Act
            var result = Utils.GetRelatedGridTypeForMyTimesheet(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetRelatedGridTypeForMyTimesheet_FieldTypeURL_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Link";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.URL
            };

            // Act
            var result = Utils.GetRelatedGridTypeForMyTimesheet(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetRelatedGridTypeForMyTimesheet_FieldTypeChoice_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Enum";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Choice
            };

            // Act
            var result = Utils.GetRelatedGridTypeForMyTimesheet(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetRelatedGridTypeForMyTimesheet_FieldTypeCalculated_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Icon";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Calculated,
                DescriptionGet = () => "Indicator"
            };

            // Act
            var result = Utils.GetRelatedGridTypeForMyTimesheet(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetRelatedGridTypeForMyTimesheet_FieldTypeDefaultValue_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Html";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.ModStat,
            };

            // Act
            var result = Utils.GetRelatedGridTypeForMyTimesheet(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetRelatedGridTypeForMyTimesheet_FieldTypeText_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Text";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Text
            };

            // Act
            var result = Utils.GetRelatedGridTypeForMyTimesheet(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetRelatedGridTypeForMyTimesheet_FieldTypeInteger_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Float";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Integer
            };

            // Act
            var result = Utils.GetRelatedGridTypeForMyTimesheet(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetRelatedGridType_FieldTypeCurrency_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Float";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Currency
            };

            // Act
            var result = Utils.GetRelatedGridType(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetRelatedGridType_FieldTypeDateTime_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Date";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.DateTime
            };

            // Act
            var result = Utils.GetRelatedGridType(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetRelatedGridType_FieldTypeBoolean_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Bool";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Boolean
            };

            // Act
            var result = Utils.GetRelatedGridType(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetRelatedGridType_FieldTypeNote_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Lines";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Note
            };

            // Act
            var result = Utils.GetRelatedGridType(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetRelatedGridType_FieldTypeURL_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Link";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.URL
            };

            // Act
            var result = Utils.GetRelatedGridType(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetRelatedGridType_FieldTypeChoice_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Enum";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Choice
            };

            // Act
            var result = Utils.GetRelatedGridType(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetRelatedGridType_FieldTypeMultiChoice_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Html";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.MultiChoice,
            };

            // Act
            var result = Utils.GetRelatedGridType(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetRelatedGridType_FieldTypeCalculated_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Icon";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Calculated,
                DescriptionGet = () => "Indicator"
            };

            // Act
            var result = Utils.GetRelatedGridType(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetRelatedGridType_FieldTypeDefaultValue_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Html";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.ModStat,
            };

            // Act
            var result = Utils.GetRelatedGridType(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void ToOriginalFieldName_Should_ReturnContent()
        {
            // Arrange, Act
            var result = Utils.ToOriginalFieldName("Name");

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ValidateItemListWebAndSite_ItemElementDoesNotExist_ThrowsException()
        {
            // Arrange
            var element = new ShimXElement();
            ShimXContainer.AllInstances.Descendants = _ => new List<XElement>();

            // Act
            Utils.ValidateItemListWebAndSite(element);

            // Assert
            // Expect an exception
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ValidateItemListWebAndSite_ListElementDoesNotExist_ThrowsException()
        {
            // Arrange
            var element = new ShimXElement();
            ShimXContainer.AllInstances.Descendants = _ => GetXElementList().Where(p => p.Name.LocalName != "List");

            // Act
            Utils.ValidateItemListWebAndSite(element);

            // Assert
            // Expect an exception
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ValidateItemListWebAndSite_WebElementDoesNotExist_ThrowsException()
        {
            // Arrange
            var element = new ShimXElement();
            ShimXContainer.AllInstances.Descendants = _ => GetXElementList().Where(p => p.Name.LocalName != "Web");

            // Act
            Utils.ValidateItemListWebAndSite(element);

            // Assert
            // Expect an exception
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ValidateItemListWebAndSite_SiteElementDoesNotExist_ThrowsException()
        {
            // Arrange
            var element = new ShimXElement();
            ShimXContainer.AllInstances.Descendants = _ => GetXElementList().Where(p => p.Name.LocalName != "Site");

            // Act
            Utils.ValidateItemListWebAndSite(element);

            // Assert
            // Expect an exception
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ValidateItemListWebAndSite_ItemIdAttributeDoesNotExist_ThrowsException()
        {
            // Arrange
            var element = new ShimXElement();
            ShimXContainer.AllInstances.Descendants = _ => GetXElementList();
            ShimXContainer.AllInstances.ElementXName = GetDummyXElement("Item");

            // Act
            Utils.ValidateItemListWebAndSite(element);

            // Assert
            // Expect an exception
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ValidateItemListWebAndSite_ListIdAttributeDoesNotExist_ThrowsException()
        {
            // Arrange
            var element = new ShimXElement();
            ShimXContainer.AllInstances.Descendants = _ => GetXElementList();
            ShimXContainer.AllInstances.ElementXName = GetDummyXElement("List");

            // Act
            Utils.ValidateItemListWebAndSite(element);

            // Assert
            // Expect an exception
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ValidateItemListWebAndSite_WebIdAttributeDoesNotExist_ThrowsException()
        {
            // Arrange
            var element = new ShimXElement();
            ShimXContainer.AllInstances.Descendants = _ => GetXElementList();
            ShimXContainer.AllInstances.ElementXName = GetDummyXElement("Web");

            // Act
            Utils.ValidateItemListWebAndSite(element);

            // Assert
            // Expect an exception
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ValidateItemListWebAndSite_SiteIdAttributeDoesNotExist_ThrowsException()
        {
            // Arrange
            var element = new ShimXElement();
            ShimXContainer.AllInstances.Descendants = _ => GetXElementList();
            ShimXContainer.AllInstances.ElementXName = GetDummyXElement("Site");

            // Act
            Utils.ValidateItemListWebAndSite(element);

            // Assert
            // Expect an exception
        }

        [TestMethod]
        public void ValidateItemListWebAndSite_WithValidElement_NotThrowException()
        {
            // Arrange
            var element = new ShimXElement();
            ShimXContainer.AllInstances.Descendants = _ => GetXElementList();
            ShimXContainer.AllInstances.ElementXName = GetDummyXElement("Site");
            ShimXContainer.AllInstances.ElementXName = (_, name) =>
            {
                return new ShimXElement
                {
                    Attributes = () => new List<XAttribute>
                    {
                        new XAttribute("ID", 1),
                        new XAttribute("URL", DummyString),
                    }
                };
            };

            // Act
            Action action = () => Utils.ValidateItemListWebAndSite(element);

            // Assert
            action.ShouldNotThrow();
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ValidateItemListWebAndSite_SiteUrlAttributeDoesNotExist_ThrowsException()
        {
            // Arrange
            var element = new ShimXElement();
            ShimXContainer.AllInstances.Descendants = _ => GetXElementList();
            ShimXContainer.AllInstances.ElementXName = (_, name) =>
            {
                if (name == "Site")
                {
                    return new ShimXElement
                    {
                        Attributes = () => new List<XAttribute>
                        {
                            new XAttribute("ID", 1)
                        }
                    };
                }
                else
                {
                    return new ShimXElement
                    {
                        Attributes = () => new List<XAttribute>
                        {
                            new XAttribute("ID", 1)
                        }
                    };
                }
            };

            // Act
            Utils.ValidateItemListWebAndSite(element);

            // Assert
            // Expect an exception
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ValidateListWebAndSite_ListElementDoesNotExist_ThrowsException()
        {
            // Arrange
            var element = new ShimXElement();
            ShimXContainer.AllInstances.Descendants = _ => new List<XElement>();

            // Act
            Utils.ValidateListWebAndSite(element);

            // Assert
            // Expect an exception
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ValidateListWebAndSite_WebElementDoesNotExist_ThrowsException()
        {
            // Arrange
            var element = new ShimXElement();
            ShimXContainer.AllInstances.Descendants = _ => GetXElementList().Where(p => p.Name.LocalName == "List");

            // Act
            Utils.ValidateListWebAndSite(element);

            // Assert
            // Expect an exception
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ValidateListWebAndSite_SiteElementDoesNotExist_ThrowsException()
        {
            // Arrange
            var element = new ShimXElement();
            ShimXContainer.AllInstances.Descendants = _ => GetXElementList().Where(p => p.Name.LocalName != "Site");

            // Act
            Utils.ValidateListWebAndSite(element);

            // Assert
            // Expect an exception
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ValidateListWebAndSite_ListIdAttributeDoesNotExist_ThrowsException()
        {
            // Arrange
            var element = new ShimXElement();
            ShimXContainer.AllInstances.Descendants = _ => GetXElementList();
            ShimXContainer.AllInstances.ElementXName = (_, name) => new ShimXElement
            {
                Attributes = () => new List<XAttribute>()
            };

            // Act
            Utils.ValidateListWebAndSite(element);

            // Assert
            // Expect an exception
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ValidateListWebAndSite_WebIdAttributeDoesNotExist_ThrowsException()
        {
            // Arrange
            var element = new ShimXElement();
            ShimXContainer.AllInstances.Descendants = _ => GetXElementList();
            ShimXContainer.AllInstances.ElementXName = GetDummyXElement("Web");

            // Act
            Utils.ValidateListWebAndSite(element);

            // Assert
            // Expect an exception
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ValidateListWebAndSite_SiteIdAttributeDoesNotExist_ThrowsException()
        {
            // Arrange
            var element = new ShimXElement();
            ShimXContainer.AllInstances.Descendants = _ => GetXElementList();
            ShimXContainer.AllInstances.ElementXName = GetDummyXElement("Site");

            // Act
            Utils.ValidateListWebAndSite(element);

            // Assert
            // Expect an exception
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ValidateListWebAndSite_SiteUrlAttributeDoesNotExist_ThrowsException()
        {
            // Arrange
            var element = new ShimXElement();
            ShimXContainer.AllInstances.Descendants = _ => GetXElementList();
            ShimXContainer.AllInstances.ElementXName = (_, name) =>
            {
                if (name == "Site")
                {
                    return new ShimXElement
                    {
                        Attributes = () => new List<XAttribute>
                        {
                            new XAttribute("ID", 1)
                        }
                    };
                }
                else
                {
                    return new ShimXElement
                    {
                        Attributes = () => new List<XAttribute>
                        {
                            new XAttribute("ID", 1)
                        }
                    };
                }
            };

            // Act
            Utils.ValidateListWebAndSite(element);

            // Assert
            // Expect an exception
        }

        [TestMethod]
        public void ValidateListWebAndSite_ValidElement_NotThrowException()
        {
            // Arrange
            var element = new ShimXElement();
            ShimXContainer.AllInstances.Descendants = _ => GetXElementList();
            ShimXContainer.AllInstances.ElementXName = (_, name) =>
            {
                return new ShimXElement
                {
                    Attributes = () => new List<XAttribute>
                    {
                        new XAttribute("ID", 1),
                        new XAttribute("URL", DummyString)
                    }
                };
            };

            // Act
            Action action = () => Utils.ValidateListWebAndSite(element);

            // Assert
            action.ShouldNotThrow();
        }


        [TestMethod]
        public void GetCleanValueFromFormatted_WithSpecificContentFloat_ReturnsExpectedValue()
        {
            // Arrange
            const int ExpectedValue = 1;
            var formatValue = $"float;#{ExpectedValue}";

            // Act
            var result = privateType.InvokeStatic(GetCleanValueFromFormattedMethodName, formatValue) as string;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(ExpectedValue.ToString(), result);
        }

        [TestMethod]
        public void GetCleanValueFromFormatted_WithSpecificContent_ReturnsExpectedValue()
        {
            // Arrange
            const int ExpectedValue = 1;
            var formatValue = $"{DummyString}#{ExpectedValue}";

            // Act
            var result = privateType.InvokeStatic(GetCleanValueFromFormattedMethodName, formatValue) as string;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(ExpectedValue.ToString(), result);
        }

        [TestMethod]
        public void GetRelatedGridTypeForReadOnly_FieldTypeInteger_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Int";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Integer
            };

            // Act
            var result = Utils.GetRelatedGridTypeForReadOnly(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetRelatedGridTypeForReadOnly_FieldTypeCurrency_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Float";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Currency
            };

            // Act
            var result = Utils.GetRelatedGridTypeForReadOnly(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetRelatedGridTypeForReadOnly_FieldTypeDateTime_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Date";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.DateTime
            };

            // Act
            var result = Utils.GetRelatedGridTypeForReadOnly(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetRelatedGridTypeForReadOnly_FieldTypeBoolean_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Bool";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Boolean
            };

            // Act
            var result = Utils.GetRelatedGridTypeForReadOnly(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetRelatedGridTypeForReadOnly_FieldTypeNote_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Lines";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Note
            };

            // Act
            var result = Utils.GetRelatedGridTypeForReadOnly(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetRelatedGridTypeForReadOnly_FieldTypeURL_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Link";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.URL
            };

            // Act
            var result = Utils.GetRelatedGridTypeForReadOnly(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetRelatedGridTypeForReadOnly_FieldTypeChoice_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Enum";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Choice
            };

            // Act
            var result = Utils.GetRelatedGridTypeForReadOnly(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetRelatedGridTypeForReadOnly_FieldTypeCalculated_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Icon";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Calculated,
                DescriptionGet = () => "Indicator"
            };

            // Act
            var result = Utils.GetRelatedGridTypeForReadOnly(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetRelatedGridTypeForReadOnly_FieldTypeInvalid_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Html";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Invalid,
            };

            // Act
            var result = Utils.GetRelatedGridTypeForReadOnly(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetRelatedGridTypeForReadOnly_FieldTypeDefaultValue_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "Html";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.ModStat,
            };

            // Act
            var result = Utils.GetRelatedGridTypeForReadOnly(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetGridEnum_FieldTypeChoice_ExecutesCorrectly()
        {
            // Arrange
            var site = new ShimSPSite().Instance;
            var field = new ShimSPFieldChoice().Instance;
            ShimSPFieldMultiChoice.AllInstances.ChoicesGet = _ => new StringCollection
            {
                DummyString
            };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Choice;
            var values = string.Empty;
            var range = 0;
            var keys = string.Empty;

            // Act
            Utils.GetGridEnum(site, field, out values, out range, out keys);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(values));
        }

        [TestMethod]
        public void GetGridEnum_FieldTypeLookup_ExecutesCorrectly()
        {
            // Arrange
            var site = new ShimSPSite().Instance;
            var field = new ShimSPFieldLookup
            {
                AllowMultipleValuesGet = () => true,
                LookupWebIdGet = () => DummyGuid,
                LookupListGet = () => DummyGuid.ToString()
            }.Instance;
            ShimSPFieldMultiChoice.AllInstances.ChoicesGet = _ => new StringCollection
            {
                DummyString
            };
            ShimSPSite.AllInstances.OpenWebGuid = (_, guid) => new ShimSPWeb();
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetGuid = guid => new ShimSPList
                {
                    ItemsGet = () => new ShimSPListItemCollection
                    {
                        GetEnumerator = () => new List<SPListItem>
                        {
                            new ShimSPListItem
                            {
                                ItemGetString = name => DummyString
                            }
                        }.GetEnumerator()
                    }
                }
            };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Lookup;
            var values = string.Empty;
            var range = 0;
            var keys = string.Empty;

            // Act
            Utils.GetGridEnum(site, field, out values, out range, out keys);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(values));
            Assert.IsFalse(string.IsNullOrWhiteSpace(keys));
        }

        [TestMethod]
        public void GetGridEnum_FieldTypeMultiChoice_ExecutesCorrectly()
        {
            // Arrange
            var site = new ShimSPSite().Instance;
            var field = new ShimSPFieldMultiChoice().Instance;
            ShimSPFieldMultiChoice.AllInstances.ChoicesGet = _ => new StringCollection
            {
                DummyString
            };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.MultiChoice;
            var values = string.Empty;
            var range = 0;
            var keys = string.Empty;

            // Act
            Utils.GetGridEnum(site, field, out values, out range, out keys);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(values));
            Assert.IsFalse(string.IsNullOrWhiteSpace(keys));
            Assert.AreEqual(1, range);
        }


        [TestMethod]
        public void GetFormat_FieldTypeDateTime_ReturnsExpectedValue()
        {
            // Arrange
            var expectedValue = SPDateTimeFieldFormatType.DateTime.ToString();
            var field = new ShimSPFieldDateTime
            {
                DisplayFormatGet = () => SPDateTimeFieldFormatType.DateTime
            };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.DateTime;

            // Act
            var result = Utils.GetFormat(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void GetFormat_FieldTypeCurrency_ReturnsExpectedValue()
        {
            // Arrange
            var expectedValue = "Currency";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Currency
            };

            // Act
            var result = Utils.GetFormat(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void GetFormat_FieldTypeCalculated_ReturnsExpectedValue()
        {
            // Arrange
            var expectedValue = "Indicator";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Calculated,
                DescriptionGet = () => expectedValue
            };

            // Act
            var result = Utils.GetFormat(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void GetFormat_FieldTypeDefaultValue_ReturnsExpectedValue()
        {
            // Arrange
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Attachments
            };

            // Act
            var result = Utils.GetFormat(field);

            // Assert
            Assert.IsTrue(string.IsNullOrWhiteSpace(result));
        }

        [TestMethod]
        public void GetFormat_FieldTypeNumberAndDisplayFormatAutomatic_ReturnsExpectedValue()
        {
            // Arrange
            var expectedValue = ",#0.##########";
            var field = new ShimSPFieldNumber
            {
                DisplayFormatGet = () => SPNumberFormatTypes.Automatic,
                ShowAsPercentageGet = () => true
            };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Number;

            // Act
            var result = Utils.GetFormat(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.IsTrue(result.Contains(expectedValue));
        }

        [TestMethod]
        public void GetFormat_FieldTypeNumberAndDisplayFormatNoDecimal_ReturnsExpectedValue()
        {
            // Arrange
            var expectedValue = ",#0";
            var field = new ShimSPFieldNumber
            {
                DisplayFormatGet = () => SPNumberFormatTypes.NoDecimal,
                ShowAsPercentageGet = () => true
            };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Number;

            // Act
            var result = Utils.GetFormat(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.IsTrue(result.Contains(expectedValue));
        }

        [TestMethod]
        public void GetFormat_FieldTypeNumberAndDisplayFormatOneDecimal_ReturnsExpectedValue()
        {
            // Arrange
            var expectedValue = ",#0.0";
            var field = new ShimSPFieldNumber
            {
                DisplayFormatGet = () => SPNumberFormatTypes.OneDecimal,
                ShowAsPercentageGet = () => true
            };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Number;

            // Act
            var result = Utils.GetFormat(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.IsTrue(result.Contains(expectedValue));
        }

        [TestMethod]
        public void GetFormat_FieldTypeNumberAndDisplayFormatTwoDecimals_ReturnsExpectedValue()
        {
            // Arrange
            var expectedValue = ",#0.00";
            var field = new ShimSPFieldNumber
            {
                DisplayFormatGet = () => SPNumberFormatTypes.TwoDecimals,
                ShowAsPercentageGet = () => true
            };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Number;

            // Act
            var result = Utils.GetFormat(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.IsTrue(result.Contains(expectedValue));
        }

        [TestMethod]
        public void GetFormat_FieldTypeNumberAndDisplayFormatThreeDecimals_ReturnsExpectedValue()
        {
            // Arrange
            var expectedValue = ",#0.000";
            var field = new ShimSPFieldNumber
            {
                DisplayFormatGet = () => SPNumberFormatTypes.ThreeDecimals,
                ShowAsPercentageGet = () => true
            };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Number;

            // Act
            var result = Utils.GetFormat(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.IsTrue(result.Contains(expectedValue));
        }

        [TestMethod]
        public void GetFormat_FieldTypeNumberAndDisplayFormatFourDecimals_ReturnsExpectedValue()
        {
            // Arrange
            var expectedValue = ",#0.0000";
            var field = new ShimSPFieldNumber
            {
                DisplayFormatGet = () => SPNumberFormatTypes.FourDecimals,
                ShowAsPercentageGet = () => true
            };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Number;

            // Act
            var result = Utils.GetFormat(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.IsTrue(result.Contains(expectedValue));
        }

        [TestMethod]
        public void GetFormat_FieldTypeNumberAndDisplayFormatFiveDecimals_ReturnsExpectedValue()
        {
            // Arrange
            var expectedValue = ",#0.00000";
            var field = new ShimSPFieldNumber
            {
                DisplayFormatGet = () => SPNumberFormatTypes.FiveDecimals,
                ShowAsPercentageGet = () => true
            };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Number;

            // Act
            var result = Utils.GetFormat(field);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.IsTrue(result.Contains(expectedValue));
        }

        [TestMethod]
        public void GetFormat_FieldTypeNumberAndDisplayFormatUnknownValue_ReturnsExpectedValue()
        {
            // Arrange
            var field = new ShimSPFieldNumber
            {
                DisplayFormatGet = () => (SPNumberFormatTypes)10,
                ShowAsPercentageGet = () => true
            };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Number;

            // Act
            var result = Utils.GetFormat(field);

            // Assert
            Assert.IsTrue(string.IsNullOrEmpty(result));
        }
    }
}

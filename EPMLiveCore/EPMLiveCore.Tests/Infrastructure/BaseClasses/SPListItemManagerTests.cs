using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.Linq.Fakes;
using EPMLiveCore.API;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.Infrastructure.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveCore.Tests.Infrastructure.BaseClasses
{
    [TestClass]
    public class SPListItemManagerTests
    {
        private static readonly Guid DummyGuid = Guid.NewGuid();
        private const string DummyString = "DummyString";
        private const string GetFieldSpecialValuesMethodName = "GetFieldSpecialValues";
        private const string PerformBatchListOperationMethodName = "PerformBatchListOperation";
        private IDisposable shimContext;
        private PrivateObject privateObject;
        private SPListItemManager spListItemManager;

        [TestInitialize]
        public void Initialize()
        {
            shimContext = ShimsContext.Create();
            SetupShims();
            spListItemManager = new SPListItemManager(DummyString, DummyGuid, DummyGuid);
            privateObject = new PrivateObject(spListItemManager);
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimContext?.Dispose();
            spListItemManager?.Dispose();
        }

        private void SetupShims()
        {
            ShimSPSite.ConstructorGuid = (_, guid) => { };
            ShimSPSite.AllInstances.OpenWebGuid = (_, guid) => new ShimSPWeb();
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection();
            ShimSPListCollection.AllInstances.TryGetListString = (_, listName) => new ShimSPList();
            ShimSPList.AllInstances.ParentWebGet = _ => new ShimSPWeb();
        }

        [TestMethod]
        [ExpectedException(typeof(APIException))]
        public void Constructor_SPListNull_ThrowsException()
        {
            // Arrange
            ShimSPSite.ConstructorGuid = (_, guid) => { };
            ShimSPSite.AllInstances.OpenWebGuid = (_, guid) => new ShimSPWeb();
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection();
            ShimSPListCollection.AllInstances.TryGetListString = (_, listName) => null;

            // Act
            var instance = new SPListItemManager(DummyString, DummyGuid, DummyGuid);

            // Assert
            // Expect an exception
        }

        [TestMethod]
        public void Constructor_OnSuccess_CreatesInstance()
        {
            // Arrange
            ShimSPSite.ConstructorGuid = (_, guid) => { };
            ShimSPSite.AllInstances.OpenWebGuid = (_, guid) => new ShimSPWeb();
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection();
            ShimSPListCollection.AllInstances.TryGetListString = (_, listName) => new ShimSPList();

            // Act
            var instance = new SPListItemManager(DummyString, DummyGuid, DummyGuid);
            privateObject = new PrivateObject(instance);
            var rootElementName = privateObject.GetFieldOrProperty("RootElementName") as string;
            var elementName = privateObject.GetFieldOrProperty("ElementName") as string;

            // Assert
            Assert.IsNotNull(instance);
            Assert.IsNotNull(instance.ParentList);
            Assert.IsFalse(string.IsNullOrWhiteSpace(rootElementName));
            Assert.IsFalse(string.IsNullOrWhiteSpace(elementName));
        }

        [TestMethod]
        public void BatchProcessLimit_GetSet_Test()
        {
            // Arrange
            const int ExpectedValue = 2;

            // Act
            spListItemManager.BatchProcessLimit = ExpectedValue;
            var result = spListItemManager.BatchProcessLimit;

            // Assert
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        [ExpectedException(typeof(APIException))]
        public void BatchProcessLimit_ValueLessThan2_ThrowsException()
        {
            // Arrange
            const int ExpectedValue = 1;

            // Act
            spListItemManager.BatchProcessLimit = ExpectedValue;

            // Assert
            // Expect an exception
        }

        [TestMethod]
        public void Add_OnScuccess_ShouldCallPerformBatchListOperation()
        {
            // Arrange
            const string ExpectedCommand = "Save";
            ShimSPListItemManager.AllInstances.PerformBatchListOperationXDocumentStringBoolean =
                (_, items, command, createNew) => command == ExpectedCommand ? new XDocument() : null;

            // Act
            var result = spListItemManager.Add(new XDocument());

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(APIException))]
        public void Add_OnException_ThrowsAPIException()
        {
            // Arrange
            ShimSPListItemManager.AllInstances.PerformBatchListOperationXDocumentStringBoolean =
                (_, items, command, createNew) =>
                {
                    throw new Exception();
                };

            // Act
            var result = spListItemManager.Add(new XDocument());

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Delete_OnScuccess_ShouldCallPerformBatchListOperation()
        {
            // Arrange
            const string ExpectedCommand = "Delete";
            ShimSPListItemManager.AllInstances.PerformBatchListOperationXDocumentString =
                (_, items, command) => command == ExpectedCommand ? new XDocument() : null;

            // Act
            var result = spListItemManager.Delete(new XDocument());

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(APIException))]
        public void Delete_OnException_ThrowsAPIException()
        {
            // Arrange
            ShimSPListItemManager.AllInstances.PerformBatchListOperationXDocumentStringBoolean =
                (_, items, command, createNew) =>
                {
                    throw new Exception();
                };

            // Act
            var result = spListItemManager.Delete(new XDocument());

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetAll_OnSuccess_ReturnsObject()
        {
            // Arrange
            ShimSPList.AllInstances.ItemsGet = _ => new ShimSPListItemCollection
            {
                GetEnumerator = () => new List<SPListItem>
                {
                    new ShimSPListItem
                    {
                        ItemGetString = name => 1
                    }

                }.GetEnumerator()
            };
            ShimSPList.AllInstances.FieldsGet = _ =>
            {
                var list = new List<SPField>
                {
                    new ShimSPField
                    {
                        InternalNameGet = () => DummyString,
                        HiddenGet = () => false,
                        ReadOnlyFieldGet = () => false
                    },
                    new ShimSPField
                    {
                        InternalNameGet = () => DummyString,
                        HiddenGet = () => true,
                        ReadOnlyFieldGet = () => false
                    },
                    new ShimSPField
                    {
                        InternalNameGet = () => DummyString,
                        HiddenGet = () => false,
                        ReadOnlyFieldGet = () => true
                    }
                };
                return new ShimSPFieldCollection().Bind(list);
            };
            ShimSPListItemManager.AllInstances.GetFieldSpecialValuesSPFieldStringObjectStringOutStringOutStringOut = GetFieldSpecialValues;

            // Act
            var result = spListItemManager.GetAll();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(APIException))]
        public void GetAll_OnException_ThrowsAPIException()
        {
            // Arrange
            ShimSPList.AllInstances.ItemsGet = _ => new ShimSPListItemCollection
            {
                GetEnumerator = () => new List<SPListItem>
                {
                    new ShimSPListItem
                    {
                        ItemGetString = name =>
                        {
                            if (name == DummyString)
                            {
                                throw new Exception();
                            }
                            else
                            {
                                return 1;
                            }
                        }
                    }

                }.GetEnumerator()
            };
            ShimSPList.AllInstances.FieldsGet = _ =>
            {
                var list = new List<SPField>
                {
                    new ShimSPField
                    {
                        InternalNameGet = () => DummyString,
                        HiddenGet = () => false,
                        ReadOnlyFieldGet = () => false
                    },
                };
                return new ShimSPFieldCollection().Bind(list);
            };
            ShimSPListItemManager.AllInstances.GetFieldSpecialValuesSPFieldStringObjectStringOutStringOutStringOut = GetFieldSpecialValuesThrowsException;

            // Act
            var result = spListItemManager.GetAll(false);

            // Assert
            //Expect an exception
        }

        [TestMethod]
        public void ItemExists_SPListItemNull_ReturnsFalse()
        {
            // Arrange
            ShimSPList.AllInstances.GetItemByIdSelectedFieldsInt32StringArray = (_, id, stringParams) => null;

            // Act
            var result = spListItemManager.ItemExists(1);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetCurrentResource_OnSuccess_ReturnsObject()
        {
            // Arrange
            ShimSPList.AllInstances.GetItemByIdSelectedFieldsInt32StringArray =
                (_, id, stringParams) => new ShimSPListItem();

            // Act
            var result = spListItemManager.GetCurrentResource(1);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetCurrentResource_OnException_ReturnsNull()
        {
            // Arrange
            ShimSPList.AllInstances.GetItemByIdSelectedFieldsInt32StringArray =
                (_, id, stringParams) =>
                {
                    throw new Exception();
                };

            // Act
            var result = spListItemManager.GetCurrentResource(1);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Update_OnScuccess_ShouldCallPerformBatchListOperation()
        {
            // Arrange
            const string ExpectedCommand = "Update";
            ShimSPListItemManager.AllInstances.PerformBatchListOperationXDocumentString =
                (_, items, command) => command == ExpectedCommand ? new XDocument() : null;

            // Act
            var result = spListItemManager.Update(new XDocument());

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(APIException))]
        public void Update_OnException_ThrowsAPIException()
        {
            // Arrange
            ShimSPListItemManager.AllInstances.PerformBatchListOperationXDocumentString =
                (_, items, command) =>
                {
                    throw new Exception();
                };

            // Act
            var result = spListItemManager.Update(new XDocument());

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteId_Should_ExecuteCorrectly()
        {
            // Arrange
            var deleteListItemWasCalled = false;
            var updateListWasCalled = false;
            ShimSPList.AllInstances.GetItemByIdInt32 = (_, id) => new ShimSPListItem
            {
                Delete = () =>
                {
                    deleteListItemWasCalled = true;
                }
            };
            ShimSPList.AllInstances.Update = _ =>
            {
                updateListWasCalled = true;
            };

            // Act
            spListItemManager.Delete(1);

            // Assert
            Assert.IsTrue(deleteListItemWasCalled);
            Assert.IsTrue(updateListWasCalled);
        }

        [TestMethod]
        public void GetFieldSpecialValues_FieldTypeDate_ShouldExecuteCorrectly()
        {
            // Arrange
            var fieldType = new ShimSPField
            {
                TypeGet = () => SPFieldType.DateTime
            }.Instance;
            var fieldEditValue = string.Empty;
            var fieldTextValue = string.Empty;
            var fieldHtmlValue = string.Empty;
            var objectValue = DateTime.Now;
            var stringValue = DateTime.Now.ToString();
            var args = new object[] { fieldType, stringValue, objectValue, fieldEditValue, fieldTextValue, fieldHtmlValue };

            // Act
            privateObject.Invoke(GetFieldSpecialValuesMethodName, args);
            fieldEditValue = args[3] as string;
            fieldTextValue = args[4] as string;
            fieldHtmlValue = args[5] as string;

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(fieldEditValue));
            Assert.IsFalse(string.IsNullOrWhiteSpace(fieldTextValue));
            Assert.IsFalse(string.IsNullOrWhiteSpace(fieldHtmlValue));
        }

        [TestMethod]
        public void GetFieldSpecialValues_FieldTypeText_ShouldExecuteCorrectly()
        {
            // Arrange
            var fieldType = new ShimSPField
            {
                TypeGet = () => SPFieldType.Text
            }.Instance;
            var fieldEditValue = string.Empty;
            var fieldTextValue = string.Empty;
            var fieldHtmlValue = string.Empty;
            var objectValue = DummyString;
            var stringValue = DummyString;
            var args = new object[] { fieldType, stringValue, objectValue, fieldEditValue, fieldTextValue, fieldHtmlValue };
            ShimSPField.AllInstances.GetFieldValueAsTextObject = (_, objValue) => DummyString;
            ShimSPField.AllInstances.GetFieldValueForEditObject = (_, objValue) => DummyString;
            ShimSPField.AllInstances.GetFieldValueAsHtmlObject = (_, objValue) => DummyString;

            // Act
            privateObject.Invoke(GetFieldSpecialValuesMethodName, args);
            fieldEditValue = args[3] as string;
            fieldTextValue = args[4] as string;
            fieldHtmlValue = args[5] as string;

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(fieldEditValue));
            Assert.IsFalse(string.IsNullOrWhiteSpace(fieldTextValue));
            Assert.IsFalse(string.IsNullOrWhiteSpace(fieldHtmlValue));
        }

        [TestMethod]
        [ExpectedException(typeof(APIException))]
        public void PerformBatchListOperation_RootElementNull_ThrowsAPIException()
        {
            // Arrange
            var serializedItems = new XDocument();
            ShimSPWeb.AllInstances.IDGet = _ => DummyGuid;
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite
            {
                IDGet = () => DummyGuid
            };
            ShimXContainer.AllInstances.ElementXName = (_, name) => null;

            // Act
            privateObject.Invoke(PerformBatchListOperationMethodName, serializedItems, DummyString, true);

            // Assert
            // Expect an exception
        }

        [TestMethod]
        [ExpectedException(typeof(APIException))]
        public void PerformBatchListOperation_CreateNewFalseAndIdAttributeNull_ThrowsAPIException()
        {
            // Arrange
            var serializedItems = new XDocument();
            ShimSPWeb.AllInstances.IDGet = _ => DummyGuid;
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite
            {
                IDGet = () => DummyGuid
            };
            ShimXContainer.AllInstances.ElementXName = (_, name) => new ShimXElement();
            ShimXContainer.AllInstances.ElementsXName = (_, name) => new List<XElement>
            {
                new ShimXElement
                {
                    AttributeXName = attributeName => null
                }
            };

            // Act
            privateObject.Invoke(PerformBatchListOperationMethodName, serializedItems, DummyString);

            // Assert
            // Expect an exception
        }

        [TestMethod]
        [ExpectedException(typeof(APIException))]
        public void PerformBatchListOperation_CreateNewTrueAndIdAttributeNull_ThrowsAPIException()
        {
            // Arrange
            var serializedItems = new XDocument();
            ShimSPWeb.AllInstances.IDGet = _ => DummyGuid;
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite
            {
                IDGet = () => DummyGuid
            };
            ShimXContainer.AllInstances.ElementXName = (_, name) => new ShimXElement();
            ShimXContainer.AllInstances.ElementsXName = (_, name) => new List<XElement>
            {
                new ShimXElement
                {
                    AttributeXName = attributeName => null
                }
            };

            // Act
            privateObject.Invoke(PerformBatchListOperationMethodName, serializedItems, DummyString, true);

            // Assert
            // Expect an exception
        }

        [TestMethod]
        public void PerformBatchListOperation_OnSuccess_ReturnsXDocument()
        {
            // Arrange
            var serializedItems = new XDocument();
            ShimSPWeb.AllInstances.IDGet = _ => DummyGuid;
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite
            {
                IDGet = () => DummyGuid
            };
            ShimXContainer.AllInstances.ElementXName = (_, name) => new ShimXElement();
            ShimXContainer.AllInstances.ElementsXName = (_, name) => new List<XElement>
            {
                new ShimXElement
                {
                    AttributeXName = attributeName => new ShimXAttribute
                    {
                        ValueGet = () => "ID"
                    }
                },
                new ShimXElement
                {
                    AttributeXName = attributeName => new ShimXAttribute
                    {
                        ValueGet = () => DummyString
                    }
                },
                new ShimXElement
                {
                    AttributeXName = attributeName => new ShimXAttribute
                    {
                        ValueGet = () => DummyString
                    }
                }
            };
            spListItemManager.BatchProcessLimit = 3;

            // Act
            var result = privateObject.Invoke(PerformBatchListOperationMethodName, serializedItems, DummyString) as XDocument;

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// This method is fake and these parameters are required, even though not all of them are used
        /// </summary>
        private void GetFieldSpecialValues(SPListItemManager listItemManager, SPField spField, string stringValue, object value, out string fieldEditValue, out string fieldTextValue, out string fieldHtmlValue)
        {
            fieldEditValue = DummyString;
            fieldTextValue = DummyString;
            fieldHtmlValue = DummyString;
        }

        /// <summary>
        /// This method is fake and these parameters are required, even though not all of them are used
        /// </summary>
        private void GetFieldSpecialValuesThrowsException(SPListItemManager listItemManager, SPField spField, string stringValue, object value, out string fieldEditValue, out string fieldTextValue, out string fieldHtmlValue)
        {
            throw new Exception("Dummy Exception");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Fakes;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.Linq.Fakes;
using EPMLiveCore.API;
using EPMLiveCore.API.SPAdmin;
using EPMLiveCore.API.SPAdmin.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.API.SPAdmin
{
    using System.Data;

    [TestClass]
    public class EventReceiverManagerTests
    {
        private const string DummyString = "DummyString";
        private const string ListEventReceiversMethodName = "ListEventReceivers";
        private const string AddEventReceiverMethodName = "AddEventReceiver";
        private const string RemoveEventReceiverMethodName = "RemoveEventReceiver";
        private const string TypeNameOperation = "Operation";
        private const string TypeNameEventType = "EventType";
        private const string TypeNameType = "Type";
        private const string TypeNameAssembly = "Assembly";
        private const string TypeNameClassName = "ClassName";
        private const string ParseRequestDataMethodName = "ParseRequestData";
        private const string WebIdAttribute = "WebId";
        private const string SiteIdAttribute = "SiteId";
        private const string ListIdAttribute = "ListId";
        private const string ListAttribute = "List";
        private const string StatusAttribute = "Status";
        private const string DataAttribute = "Data";
        private const string AddOperation = "ADD";
        private const string ListOperation = "LIST";
        private const string RemoveOperation = "REMOVE";
        private const string EPMLiveCoreDll = "EPM Live Core.dll";
        private static bool RemoveEventReceiverWasCalled = false;
        private static bool AddEventReceiverWasCalled = false;
        private static bool ListEventReceiversWasCalled = false;
        private static readonly Guid DummyGuid = Guid.NewGuid();
        private IDisposable shimsContext;
        private EventReceiverManager eventReceiverManager;
        private PrivateObject privateObject;
        private PrivateType privateType;

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            SetupShims();
            eventReceiverManager = new EventReceiverManager(new ShimSPWeb());
            privateObject = new PrivateObject(eventReceiverManager);
            privateType = new PrivateType(typeof(EventReceiverManager));
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }

        private void SetupShims()
        {
            ShimSPSite.ConstructorGuid = (_, guid) => { };
            ShimSPSite.AllInstances.OpenWebGuid = (_, guid) => new ShimSPWeb();
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection();
            ShimSPListCollection.AllInstances.GetListGuidBoolean = (_, id, fetchMetadata) => new ShimSPList();
            ShimXContainer.AllInstances.ElementXName = (_, name) => new ShimXElement();
            ShimXContainer.AllInstances.ElementsXName = (_, name) => new List<XElement>();
        }

        [TestMethod]
        public void Constructor_Should_CreatesInstance()
        {
            // Arrange
            var spWeb = new ShimSPWeb().Instance;

            // Act
            var instance = new EventReceiverManager(spWeb);
            privateObject = new PrivateObject(instance);
            var web = privateObject.GetFieldOrProperty("Web") as SPWeb;

            // Assert
            instance.ShouldSatisfyAllConditions(
                () => instance.ShouldNotBeNull(),
                () => web.ShouldNotBeNull(),
                () => web.ShouldBe(spWeb));
        }

        [TestMethod]
        public void ListEventReceivers_Should_AddElement()
        {
            // Arrange
            var receiverType = SPEventReceiverType.AppInstalled;
            var spList = new ShimSPList
            {
                IDGet = () => DummyGuid,
                EventReceiversGet = () =>
                {
                    var list = new List<SPEventReceiverDefinition>
                    {
                        new ShimSPEventReceiverDefinition
                        {
                            IdGet = () => DummyGuid,
                            TypeGet = () => receiverType,
                            AssemblyGet = () => DummyString,
                            ClassGet = () => DummyString,
                            SiteIdGet = () => DummyGuid,
                            WebIdGet = () => DummyGuid
                        }
                    };
                    return new ShimSPEventReceiverDefinitionCollection().Bind(list);
                }
            }.Instance;
            var receiverElement = new XElement(DummyString);
            var args = new object[] { spList, receiverElement };

            // Act
            privateObject.Invoke(ListEventReceiversMethodName, args);
            receiverElement = args[1] as XElement;

            // Assert
            receiverElement.ShouldSatisfyAllConditions(
                () => receiverElement.ShouldNotBeNull(),
                () => receiverElement.ToString().ShouldContainWithoutWhitespace(DummyString),
                () => receiverElement.ToString().ShouldContainWithoutWhitespace(DummyGuid.ToString()),
                () => receiverElement.ToString().ShouldContainWithoutWhitespace(receiverType.ToString()));
        }

        [TestMethod]
        public void AddEventReceiver_ReceiverAlreadyExists_ExecutesCorrectly()
        {
            // Arrange
            ShimEventReceiverManager.AllInstances.AddEventReceiverSPListStringStringSPEventReceiverTypeXElementRef = null;
            ShimXContainer.AllInstances.ElementXName = null;
            const string ExpectedValue = "1";
            const string ExpectedMessage = "Operation not performed. Event receiver already exists.";
            var receiverType = SPEventReceiverType.GroupUserDeleted;
            var receiverElement = new XElement(DummyString);
            var spList = new ShimSPList
            {
                ParentWebGet = () => new ShimSPWeb
                {
                    IDGet = () => DummyGuid,
                    SiteGet = () => new ShimSPSite
                    {
                        IDGet = () => DummyGuid
                    }
                },
                EventReceiversGet = () =>
                {
                    var list = new List<SPEventReceiverDefinition>
                    {
                        new ShimSPEventReceiverDefinition
                        {
                            AssemblyGet = () => DummyString,
                            ClassGet = () => DummyString,
                            TypeGet = () => receiverType
                        }
                    };
                    return new ShimSPEventReceiverDefinitionCollection().Bind(list);
                }
            }.Instance;
            var args = new object[]
            {
                spList,
                DummyString,
                DummyString,
                receiverType,
                receiverElement
            };

            // Actpriv
            privateObject.Invoke(AddEventReceiverMethodName, args);
            receiverElement = args[4] as XElement;
            var dataElement = receiverElement.Element(DataAttribute);

            // Assert
            receiverElement.ShouldNotBeNull();
            dataElement.ShouldNotBeNull();
            dataElement.Value.ShouldBe(ExpectedMessage);
            dataElement.Attribute(StatusAttribute)?.Value.ShouldBe(ExpectedValue);
        }

        [TestMethod]
        public void AddEventReceiver_ReceiverDoesNotExist_ExecutesCorrectly()
        {
            // Arrange
            ShimEventReceiverManager.AllInstances.AddEventReceiverSPListStringStringSPEventReceiverTypeXElementRef = null;
            ShimXContainer.AllInstances.ElementXName = null;
            const string ExpectedValue = "0";
            const string ExpectedMessage = "Event receiver successfully installed.";
            var receiverType = SPEventReceiverType.GroupUserDeleted;
            var receiverElement = new XElement(DummyString);
            var spList = new ShimSPList
            {
                ParentWebGet = () => new ShimSPWeb
                {
                    IDGet = () => DummyGuid,
                    SiteGet = () => new ShimSPSite
                    {
                        IDGet = () => DummyGuid
                    }
                },
                EventReceiversGet = () =>
                {
                    var list = new List<SPEventReceiverDefinition>();
                    return new ShimSPEventReceiverDefinitionCollection().Bind(list);
                }
            }.Instance;
            var args = new object[]
            {
                spList,
                DummyString,
                DummyString,
                receiverType,
                receiverElement
            };

            // Actpriv
            privateObject.Invoke(AddEventReceiverMethodName, args);
            receiverElement = args[4] as XElement;
            var dataElement = receiverElement.Element(DataAttribute);

            // Assert
            receiverElement.ShouldNotBeNull();
            dataElement.ShouldNotBeNull();
            dataElement.Value.ShouldBe(ExpectedMessage);
            dataElement.Attribute(StatusAttribute)?.Value.ShouldBe(ExpectedValue);
        }

        [TestMethod]
        public void RemoveEventReceiver_ReceiverExists_ExecutesCorrectly()
        {
            // Arrange
            ShimEventReceiverManager.AllInstances.RemoveEventReceiverSPListStringStringSPEventReceiverTypeXElementRef = null;
            ShimXContainer.AllInstances.ElementXName = null;
            const string ExpectedValue = "0";
            const string ExpectedMessage = "Event receiver successfully uninstalled.";
            var receiverType = SPEventReceiverType.GroupUserDeleted;
            var receiverElement = new XElement(DummyString);
            var spList = new ShimSPList
            {
                ParentWebGet = () => new ShimSPWeb
                {
                    IDGet = () => DummyGuid,
                    SiteGet = () => new ShimSPSite
                    {
                        IDGet = () => DummyGuid
                    }
                },
                EventReceiversGet = () =>
                {
                    var list = new List<SPEventReceiverDefinition>
                    {
                        new ShimSPEventReceiverDefinition
                        {
                            AssemblyGet = () => DummyString,
                            ClassGet = () => DummyString,
                            TypeGet = () => receiverType
                        }
                    };
                    return new ShimSPEventReceiverDefinitionCollection().Bind(list);
                }
            }.Instance;
            var args = new object[]
            {
                spList,
                DummyString,
                DummyString,
                receiverType,
                receiverElement
            };

            // Act
            privateObject.Invoke(RemoveEventReceiverMethodName, args);
            receiverElement = args[4] as XElement;
            var dataElement = receiverElement.Element(DataAttribute);

            // Assert
            receiverElement.ShouldNotBeNull();
            dataElement.ShouldNotBeNull();
            dataElement.Value.ShouldBe(ExpectedMessage);
            dataElement.Attribute(StatusAttribute)?.Value.ShouldBe(ExpectedValue);
        }

        [TestMethod]
        public void RemoveEventReceiver_ReceiverNotFound_ExecutesCorrectly()
        {
            // Arrange
            ShimEventReceiverManager.AllInstances.RemoveEventReceiverSPListStringStringSPEventReceiverTypeXElementRef = null;
            ShimXContainer.AllInstances.ElementXName = null;
            const string ExpectedValue = "1";
            const string ExpectedMessage = "Operation not performed. Event receiver was not found.";
            var receiverType = SPEventReceiverType.GroupUserDeleted;
            var receiverElement = new XElement(DummyString);
            var spList = new ShimSPList
            {
                ParentWebGet = () => new ShimSPWeb
                {
                    IDGet = () => DummyGuid,
                    SiteGet = () => new ShimSPSite
                    {
                        IDGet = () => DummyGuid
                    }
                },
                EventReceiversGet = () =>
                {
                    var list = new List<SPEventReceiverDefinition>();
                    return new ShimSPEventReceiverDefinitionCollection().Bind(list);
                }
            }.Instance;
            var args = new object[]
            {
                spList,
                DummyString,
                DummyString,
                receiverType,
                receiverElement
            };

            // Actpriv
            privateObject.Invoke(RemoveEventReceiverMethodName, args);
            receiverElement = args[4] as XElement;
            var dataElement = receiverElement.Element(DataAttribute);

            // Assert
            receiverElement.ShouldNotBeNull();
            dataElement.ShouldNotBeNull();
            dataElement.Value.ShouldBe(ExpectedMessage);
            dataElement.Attribute(StatusAttribute)?.Value.ShouldBe(ExpectedValue);
        }

        [TestMethod]
        public void Manage_OnSuccess_ExecutesCorrectly()
        {
            // Arrange
            const string ExpectedValue = "EventReceiver DataId=\"DummyString\">DummyString<Result Status=\"0\" /></EventReceiver>";
            var siteId = Guid.NewGuid();
            ShimEventReceiverManager.ParseRequestDataString = _ => new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    GetEnumerator = () => new List<DataRow>
                    {
                        new ShimDataRow
                        {
                            ItemGetString = name => DummyGuid
                        },
                        new ShimDataRow()
                        {
                            ItemGetString = name => name == WebIdAttribute ? Guid.NewGuid() : DummyGuid
                        },
                        new ShimDataRow()
                        {
                            ItemGetString = name => name == ListAttribute ? Guid.NewGuid() : DummyGuid
                        },
                        new ShimDataRow
                        {
                            ItemGetString = name => DummyGuid
                        },
                    }.GetEnumerator()
                },
                SelectString = filter => new DataRow[]
                {
                    new ShimDataRow
                    {
                        ItemGetString = GetDataRowItemValue(SPEventReceiverType.AppInstalled, AddOperation, DummyString)
                    },
                    new ShimDataRow
                    {
                        ItemGetString = GetDataRowItemValue(SPEventReceiverType.AppInstalled, RemoveOperation, DummyString)
                    },
                    new ShimDataRow
                    {
                        ItemGetString = GetDataRowItemValue(SPEventReceiverType.AppInstalled, ListOperation, DummyString)
                    }
                }
            };
            ShimEventReceiverManager.AllInstances.AddEventReceiverSPListStringStringSPEventReceiverTypeXElementRef = AddEventReceiver;
            ShimEventReceiverManager.AllInstances.RemoveEventReceiverSPListStringStringSPEventReceiverTypeXElementRef = RemoveEventReceiver;
            ShimEventReceiverManager.AllInstances.ListEventReceiversSPListXElementRef = ListEventReceivers;

            // Act
            var result = eventReceiverManager.Manage(DummyString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(ExpectedValue),
                () => AddEventReceiverWasCalled.ShouldBeTrue(),
                () => RemoveEventReceiverWasCalled.ShouldBeTrue(),
                () => ListEventReceiversWasCalled.ShouldBeTrue());
        }

        [TestMethod]
        public void Manage_OnAPIException_ShouldThrowsAPIExpection()
        {
            // Arrange
            ShimEventReceiverManager.ParseRequestDataString = _ =>
            {
                throw new APIException(1, "Dummy Exception");
            };

            // Act
            Action action = () => eventReceiverManager.Manage(DummyString);

            // Assert
            action.ShouldThrow<APIException>();
        }

        [TestMethod]
        public void Manage_OnException_ShouldThrowsAPIExpection()
        {
            // Arrange
            var siteId = Guid.NewGuid();
            ShimEventReceiverManager.ParseRequestDataString = _ =>
            {
                throw new Exception("Dummy Exception");
            };

            // Act
            Action action = () => eventReceiverManager.Manage(DummyString);

            // Assert
            action.ShouldThrow<APIException>();
        }

        [TestMethod]
        public void Manage_OnDataRowAPIException_ExecutesCorrectly()
        {
            // Arrange
            const string DummyException = "Dummy Exception";
            const int ExceptionId = 2;
            var expectedValue = $"<Result Status=\"1\">Error Id: {ExceptionId}. Message: {DummyException}</Result>";
            var siteId = Guid.NewGuid();
            ShimEventReceiverManager.ParseRequestDataString = _ => new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    GetEnumerator = () => new List<DataRow>
                    {
                        new ShimDataRow
                        {
                            ItemGetString = name => DummyGuid
                        },
                        new ShimDataRow()
                        {
                            ItemGetString = name => name == WebIdAttribute ? Guid.NewGuid() : DummyGuid
                        },
                        new ShimDataRow()
                        {
                            ItemGetString = name => name == ListAttribute ? Guid.NewGuid() : DummyGuid
                        },
                        new ShimDataRow
                        {
                            ItemGetString = name => DummyGuid
                        },
                    }.GetEnumerator()
                },
                SelectString = filter => new DataRow[]
                {
                    new ShimDataRow
                    {
                        ItemGetString = GetDataRowItemValue(SPEventReceiverType.AppInstalled, AddOperation, DummyString)
                    }
                }
            };
            ShimSPListCollection.AllInstances.GetListGuidBoolean = (_, id, fetchMetadata) =>
            {
                throw new APIException(ExceptionId, DummyException);
            };

            // Act
            var result = eventReceiverManager.Manage(DummyString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(expectedValue));
        }

        [TestMethod]
        public void Manage_OnDataRowException_ExecutesCorrectly()
        {
            // Arrange
            const string DummyException = "Dummy Exception";
            var expectedValue = $"<Result Status=\"1\">{DummyException}</Result>";
            var siteId = Guid.NewGuid();
            ShimEventReceiverManager.ParseRequestDataString = _ => new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    GetEnumerator = () => new List<DataRow>
                    {
                        new ShimDataRow
                        {
                            ItemGetString = name => DummyGuid
                        },
                        new ShimDataRow()
                        {
                            ItemGetString = name => name == WebIdAttribute ? Guid.NewGuid() : DummyGuid
                        },
                        new ShimDataRow()
                        {
                            ItemGetString = name => name == ListAttribute ? Guid.NewGuid() : DummyGuid
                        },
                        new ShimDataRow
                        {
                            ItemGetString = name => DummyGuid
                        },
                    }.GetEnumerator()
                },
                SelectString = filter => new DataRow[]
                {
                    new ShimDataRow
                    {
                        ItemGetString = GetDataRowItemValue(SPEventReceiverType.AppInstalled, AddOperation, DummyString)
                    }
                }
            };
            ShimSPListCollection.AllInstances.GetListGuidBoolean = (_, id, fetchMetadata) =>
            {
                throw new Exception(DummyException);
            };

            // Act
            var result = eventReceiverManager.Manage(DummyString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContainWithoutWhitespace(expectedValue));
        }

        [TestMethod]
        public void ParseRequestData_RootElementNull_ThrowsException()
        {
            // Arrange
            ShimXDocument.ParseString = content => new ShimXDocument
            {
                RootGet = () => null
            };

            // Act
            Action action = () => privateType.InvokeStatic(ParseRequestDataMethodName, DummyString);

            // Assert
            action.ShouldThrow<APIException>();
        }

        [TestMethod]
        public void ParseRequestData_DataElementNull_ThrowsException()
        {
            // Arrange
            ShimXDocument.ParseString = content => new ShimXDocument
            {
                RootGet = () => new ShimXElement()
            };
            ShimXContainer.AllInstances.ElementXName = (_, name) => null;

            // Act
            Action action = () => privateType.InvokeStatic(ParseRequestDataMethodName, DummyString);

            // Assert
            action.ShouldThrow<APIException>();
        }

        [TestMethod]
        public void ParseRequestData_EventReceiverElementsListEmpty_ThrowsException()
        {
            // Arrange
            ShimXDocument.ParseString = content => new ShimXDocument
            {
                RootGet = () => new ShimXElement()
            };

            // Act
            Action action = () => privateType.InvokeStatic(ParseRequestDataMethodName, DummyString);

            // Assert
            action.ShouldThrow<APIException>();
        }

        [TestMethod]
        public void ParseRequestData_EventReceiverElementDataIdNull_ThrowsException()
        {
            // Arrange
            ShimXDocument.ParseString = content => new ShimXDocument
            {
                RootGet = () => new ShimXElement()
            };
            ShimXContainer.AllInstances.ElementsXName = (_, name) => new List<XElement>
            {
                new ShimXElement()
                {
                    AttributeXName = attributeName => null
                }
            };

            // Act
            Action action = () => privateType.InvokeStatic(ParseRequestDataMethodName, DummyString);

            // Assert
            action.ShouldThrow<APIException>();
        }
      
        [TestMethod]
        public void ParseRequestData_EventReceiverElementSiteIdNull_ThrowsException()
        {
            // Arrange
            ShimXDocument.ParseString = content => new ShimXDocument
            {
                RootGet = () => new ShimXElement()
            };
            ShimXContainer.AllInstances.ElementsXName = (_, name) => new List<XElement>
            {
                new ShimXElement()
                {
                    AttributeXName = attributeName => attributeName == SiteIdAttribute ? null : new XAttribute(attributeName, DummyGuid)
                }
            };

            // Act
            Action action = () => privateType.InvokeStatic(ParseRequestDataMethodName, DummyString);

            // Assert
            action.ShouldThrow<APIException>();
        }

        [TestMethod]
        public void ParseRequestData_EventReceiverElementWebIdNull_ThrowsException()
        {
            // Arrange
            ShimXDocument.ParseString = content => new ShimXDocument
            {
                RootGet = () => new ShimXElement()
            };
            ShimXContainer.AllInstances.ElementsXName = (_, name) => new List<XElement>
            {
                new ShimXElement()
                {
                    AttributeXName = attributeName => attributeName == WebIdAttribute ? null : new XAttribute(attributeName, DummyGuid)
                }
            };

            // Act
            Action action = () => privateType.InvokeStatic(ParseRequestDataMethodName, DummyString);

            // Assert
            action.ShouldThrow<APIException>();
        }

        [TestMethod]
        public void ParseRequestData_EventReceiverElementListIdNull_ThrowsException()
        {
            // Arrange
            ShimXDocument.ParseString = content => new ShimXDocument
            {
                RootGet = () => new ShimXElement()
            };
            ShimXContainer.AllInstances.ElementsXName = (_, name) => new List<XElement>
            {
                new ShimXElement()
                {
                    AttributeXName = attributeName => attributeName == ListIdAttribute ? null : new XAttribute(attributeName, DummyGuid)
                }
            };

            // Act
            Action action = () => privateType.InvokeStatic(ParseRequestDataMethodName, DummyString);

            // Assert
            action.ShouldThrow<APIException>();
        }

        [TestMethod]
        public void ParseRequestData_EventReceiverElementTypeNull_ThrowsException()
        {
            // Arrange
            ShimXDocument.ParseString = content => new ShimXDocument
            {
                RootGet = () => new ShimXElement()
            };
            ShimXContainer.AllInstances.ElementsXName = (_, name) => new List<XElement>
            {
                new ShimXElement()
                {
                    AttributeXName = attributeName => attributeName == TypeNameType ? null : new XAttribute(attributeName, DummyGuid)
                }
            };

            // Act
            Action action = () => privateType.InvokeStatic(ParseRequestDataMethodName, DummyString);

            // Assert
            action.ShouldThrow<APIException>();
        }

        [TestMethod]
        public void ParseRequestData_InvalidEventReceiverType_ThrowsException()
        {
            // Arrange
            ShimXDocument.ParseString = content => new ShimXDocument
            {
                RootGet = () => new ShimXElement()
            };
            ShimXContainer.AllInstances.ElementsXName = (_, name) => new List<XElement>
            {
                new ShimXElement()
                {
                    AttributeXName = attributeName => new XAttribute(attributeName, DummyGuid)
                }
            };

            // Act
            Action action = () => privateType.InvokeStatic(ParseRequestDataMethodName, DummyString);

            // Assert
            action.ShouldThrow<APIException>();
        }

        [TestMethod]
        public void ParseRequestData_EventReceiverElementOperationNull_ThrowsException()
        {
            // Arrange
            ShimXDocument.ParseString = content => new ShimXDocument
            {
                RootGet = () => new ShimXElement()
            };
            ShimXContainer.AllInstances.ElementsXName = (_, name) => new List<XElement>
            {
                new ShimXElement()
                {
                    AttributeXName = attributeName =>
                    {
                        if (attributeName == TypeNameOperation)
                        {
                            return null;
                        }
                        else if (attributeName == TypeNameType)
                        {
                            return new XAttribute(attributeName, SPEventReceiverType.AppInstalled);
                        }
                        else
                        {
                            return new XAttribute(attributeName, DummyGuid);
                        }
                    }
                }
            };

            // Act
            Action action = () => privateType.InvokeStatic(ParseRequestDataMethodName, DummyString);

            // Assert
            action.ShouldThrow<APIException>();
        }

        [TestMethod]
        public void ParseRequestData_EventReceiverElementOperationInvalid_ThrowsException()
        {
            // Arrange
            ShimXDocument.ParseString = content => new ShimXDocument
            {
                RootGet = () => new ShimXElement()
            };
            ShimXContainer.AllInstances.ElementsXName = (_, name) => new List<XElement>
            {
                new ShimXElement()
                {
                    AttributeXName = GetItemAttribute(DummyString, SPEventReceiverType.AppInstalled, DummyGuid)
                }
            };

            // Act
            Action action = () => privateType.InvokeStatic(ParseRequestDataMethodName, DummyString);

            // Assert
            action.ShouldThrow<APIException>();
        }

        [TestMethod]
        public void ParseRequestData_EventReceiverElementAssemblyNull_ThrowsException()
        {
            // Arrange
            ShimXDocument.ParseString = content => new ShimXDocument
            {
                RootGet = () => new ShimXElement()
            };
            ShimXContainer.AllInstances.ElementsXName = (_, name) => new List<XElement>
            {
                new ShimXElement()
                {
                    AttributeXName = GetItemAttribute(AddOperation, SPEventReceiverType.AppInstalled, DummyGuid, null)
                }
            };

            // Act
            Action action = () => privateType.InvokeStatic(ParseRequestDataMethodName, DummyString);

            // Assert
            action.ShouldThrow<APIException>();
        }

        [TestMethod]
        public void ParseRequestData_EventReceiverElementAssemblyInvalid_ThrowsException()
        {
            // Arrange
            ShimXDocument.ParseString = content => new ShimXDocument
            {
                RootGet = () => new ShimXElement()
            };
            ShimXContainer.AllInstances.ElementsXName = (_, name) => new List<XElement>
            {
                new ShimXElement()
                {
                    AttributeXName = GetItemAttribute(AddOperation, SPEventReceiverType.AppInstalled, DummyGuid, DummyString)
                }
            };

            // Act
            Action action = () => privateType.InvokeStatic(ParseRequestDataMethodName, DummyString);

            // Assert
            action.ShouldThrow<APIException>();
        }

        [TestMethod]
        public void ParseRequestData_EventReceiverElementClassName_ThrowsException()
        {
            // Arrange
            var assemblyName = GetAssemblyFullName();
            ShimXDocument.ParseString = content => new ShimXDocument
            {
                RootGet = () => new ShimXElement()
            };
            ShimXContainer.AllInstances.ElementsXName = (_, name) => new List<XElement>
            {
                new ShimXElement()
                {
                    AttributeXName = GetItemAttribute(AddOperation, SPEventReceiverType.AppInstalled, DummyGuid, assemblyName, null)
                }
            };

            // Act
            Action action = () => privateType.InvokeStatic(ParseRequestDataMethodName, DummyString);

            // Assert
            action.ShouldThrow<APIException>();
        }

        [TestMethod]
        public void ParseRequestData_EventReceiverAssemblyClassNull_ThrowsException()
        {
            // Arrange
            var assemblyName = GetAssemblyFullName();
            ShimXDocument.ParseString = content => new ShimXDocument
            {
                RootGet = () => new ShimXElement()
            };
            ShimXContainer.AllInstances.ElementsXName = (_, name) => new List<XElement>
            {
                new ShimXElement()
                {
                    AttributeXName = GetItemAttribute(AddOperation, SPEventReceiverType.AppInstalled, DummyGuid, assemblyName, DummyString)
                }
            };

            // Act
            Action action = () => privateType.InvokeStatic(ParseRequestDataMethodName, DummyString);

            // Assert
            action.ShouldThrow<APIException>();
        }

        [TestMethod]
        public void ParseRequestData_EventReceiverAssemblyClassNotValid_ThrowsException()
        {
            // Arrange
            var assemblyName = GetAssemblyFullName();
            ShimXDocument.ParseString = content => new ShimXDocument
            {
                RootGet = () => new ShimXElement()
            };
            ShimXContainer.AllInstances.ElementsXName = (_, name) => new List<XElement>
            {
                new ShimXElement()
                {
                    AttributeXName = GetItemAttribute(AddOperation, SPEventReceiverType.AppInstalled, DummyGuid, assemblyName, "EPMLiveCore.Act")
                }
            };

            // Act
            Action action = () => privateType.InvokeStatic(ParseRequestDataMethodName, DummyString);

            // Assert
            action.ShouldThrow<APIException>();
        }

        [TestMethod]
        public void ParseRequestData_OnSucces_ShouldReturnDataTable()
        {
            // Arrange
            var assemblyName = GetAssemblyFullName();
            const string ExpectedOperation = "ADD";
            ShimXDocument.ParseString = content => new ShimXDocument
            {
                RootGet = () => new ShimXElement()
            };
            ShimXContainer.AllInstances.ElementsXName = (_, name) => new List<XElement>
            {
                new ShimXElement()
                {
                    AttributeXName = GetItemAttribute(ExpectedOperation, SPEventReceiverType.AppInstalled, DummyGuid, assemblyName, "EPMLiveCore.ChildParentSync")
                }
            };

            // Act
            var result = privateType.InvokeStatic(ParseRequestDataMethodName, DummyString) as DataTable;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Rows.Count.ShouldBeGreaterThan(0),
                () => result.Rows[0].ItemArray.Length.ShouldBeGreaterThanOrEqualTo(8),
                () => result.Rows[0][0].ShouldBe(DummyGuid),
                () => result.Rows[0][3].ShouldBe(ExpectedOperation));
        }

        [TestMethod]
        public void ParseRequestData_OpenWebException_ThrowsAPIException()
        {
            // Arrange
            var assemblyName = GetAssemblyFullName();
            ShimXDocument.ParseString = content => new ShimXDocument
            {
                RootGet = () => new ShimXElement()
            };
            ShimXContainer.AllInstances.ElementsXName = (_, name) => new List<XElement>
            {
                new ShimXElement()
                {
                    AttributeXName = GetItemAttribute(ListOperation, SPEventReceiverType.AppInstalled, DummyGuid, assemblyName, "EPMLiveCore.ChildParentSync")
                }
            };
            ShimSPSite.AllInstances.OpenWebGuid = (_, guid) =>
            {
                throw new Exception();
            };

            // Act
            Action action = () => new PrivateType(typeof(EventReceiverManager)).InvokeStatic(ParseRequestDataMethodName, DummyString);

            // Assert
            action.ShouldThrow<APIException>();
        }

        private string GetAssemblyFullName()
        {
            var assembly = Assembly.LoadFrom(EPMLiveCoreDll);
            return assembly?.FullName;
        }

        private FakesDelegates.Func<XName, XAttribute> GetItemAttribute(
            object operationValue = null,
            object typeValue = null,
            object defaultValue = null,
            object assemblyValue = null,
            object classNameValue = null)
        {
            return name =>
            {
                switch (name.LocalName)
                {
                    case TypeNameOperation:
                        return operationValue == null ? null : new XAttribute(name, operationValue);
                    case TypeNameType:
                        return typeValue == null ? null : new XAttribute(name, typeValue);
                    case TypeNameAssembly:
                        return assemblyValue == null ? null : new XAttribute(name, assemblyValue);
                    case TypeNameClassName:
                        return classNameValue == null ? null : new XAttribute(name, classNameValue);
                    default:
                        return new XAttribute(name, defaultValue);
                }
            };
        }

        private FakesDelegates.Func<string, object> GetDataRowItemValue(
            object eventType, 
            string operation, 
            object defaultValue)
        {
            return name =>
            {
                switch (name)
                {
                    case TypeNameEventType:
                        return eventType;
                    case TypeNameOperation:
                        return operation;
                    default:
                        return defaultValue;
                }
            };
        }

        /// <summary>
        /// This method is fake. All the parameters are required, even though not all of them are used
        /// </summary>
        private void ListEventReceivers(EventReceiverManager eventReceiver, SPList list, ref XElement element)
        {
            element.Add(DummyString);
            ListEventReceiversWasCalled = true;
        }

        /// <summary>
        /// This method is fake. All the parameters are required, even though not all of them are used
        /// </summary>
        private void RemoveEventReceiver(
            EventReceiverManager eventReceiver,
            SPList list,
            string assembly,
            string className,
            SPEventReceiverType type,
            ref XElement element)
        {
            RemoveEventReceiverWasCalled = true;
            element.Add(DummyString);
        }

        /// <summary>
        /// This method is fake. All the parameters are required, even though not all of them are used
        /// </summary>
        private void AddEventReceiver(
            EventReceiverManager eventReceiver,
            SPList list,
            string assembly,
            string className,
            SPEventReceiverType type,
            ref XElement element)
        {
            element.Add(DummyString);
            AddEventReceiverWasCalled = true;
        }
    }
}

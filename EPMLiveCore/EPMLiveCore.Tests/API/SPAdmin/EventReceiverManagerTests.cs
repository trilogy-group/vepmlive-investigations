using System;
using System.Collections.Generic;
using System.Data.Fakes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DocumentFormat.OpenXml.Drawing.Charts;
using EPMLiveCore.API.SPAdmin;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using EPMLiveCore.API.SPAdmin.Fakes;
using System.Data;
using EPMLiveCore.API;

namespace EPMLiveCore.Tests.API.SPAdmin
{
    [TestClass]
    public class EventReceiverManagerTests
    {
        private IDisposable shimsContext;
        private EventReceiverManager eventReceiverManager;
        private PrivateObject privateObject;
        private const string DummyString = "DummyString";
        private const string ListEventReceiversMethodName = "ListEventReceivers";
        private const string AddEventReceiverMethodName = "AddEventReceiver";
        private const string RemoveEventReceiverMethodName = "RemoveEventReceiver";
        private static bool RemoveEventReceiverWasCalled = false;
        private static bool AddEventReceiverWasCalled = false;
        private static bool ListEventReceiversWasCalled = false;
        private static readonly Guid DummyGuid = Guid.NewGuid();

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            SetupShims();
            eventReceiverManager = new EventReceiverManager(new ShimSPWeb());
            privateObject = new PrivateObject(eventReceiverManager);
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
            var dataElement = receiverElement.Element("Data");

            // Assert
            receiverElement.ShouldNotBeNull();
            dataElement.ShouldNotBeNull();
            dataElement.Value.ShouldBe(ExpectedMessage);
            dataElement.Attribute("Status")?.Value.ShouldBe("1");
        }

        [TestMethod]
        public void AddEventReceiver_ReceiverDoesNotExist_ExecutesCorrectly()
        {
            // Arrange
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
            var dataElement = receiverElement.Element("Data");

            // Assert
            receiverElement.ShouldNotBeNull();
            dataElement.ShouldNotBeNull();
            dataElement.Value.ShouldBe(ExpectedMessage);
            dataElement.Attribute("Status")?.Value.ShouldBe("0");
        }

        [TestMethod]
        public void RemoveEventReceiver_ReceiverExists_ExecutesCorrectly()
        {
            // Arrange
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
            var dataElement = receiverElement.Element("Data");

            // Assert
            receiverElement.ShouldNotBeNull();
            dataElement.ShouldNotBeNull();
            dataElement.Value.ShouldBe(ExpectedMessage);
            dataElement.Attribute("Status")?.Value.ShouldBe("0");
        }

        [TestMethod]
        public void RemoveEventReceiver_ReceiverNotFound_ExecutesCorrectly()
        {
            // Arrange
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
            var dataElement = receiverElement.Element("Data");

            // Assert
            receiverElement.ShouldNotBeNull();
            dataElement.ShouldNotBeNull();
            dataElement.Value.ShouldBe(ExpectedMessage);
            dataElement.Attribute("Status")?.Value.ShouldBe("1");
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
                            ItemGetString = name => name == "WebId" ? Guid.NewGuid() : DummyGuid
                        },
                        new ShimDataRow()
                        {
                            ItemGetString = name => name == "List" ? Guid.NewGuid() : DummyGuid
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
                        ItemGetString = GetDataRowItemValue(SPEventReceiverType.AppInstalled, "ADD", DummyString)
                    },
                    new ShimDataRow
                    {
                        ItemGetString = GetDataRowItemValue(SPEventReceiverType.AppInstalled, "REMOVE", DummyString)
                    },
                    new ShimDataRow
                    {
                        ItemGetString = GetDataRowItemValue(SPEventReceiverType.AppInstalled, "LIST", DummyString)
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
                () => result.ShouldContain(ExpectedValue));

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
                            ItemGetString = name => name == "WebId" ? Guid.NewGuid() : DummyGuid
                        },
                        new ShimDataRow()
                        {
                            ItemGetString = name => name == "List" ? Guid.NewGuid() : DummyGuid
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
                        ItemGetString = GetDataRowItemValue(SPEventReceiverType.AppInstalled, "ADD", DummyString)
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
                            ItemGetString = name => name == "WebId" ? Guid.NewGuid() : DummyGuid
                        },
                        new ShimDataRow()
                        {
                            ItemGetString = name => name == "List" ? Guid.NewGuid() : DummyGuid
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
                        ItemGetString = GetDataRowItemValue(SPEventReceiverType.AppInstalled, "ADD", DummyString)
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






        private FakesDelegates.Func<string, object> GetDataRowItemValue(object eventType, string operation, object defaultValue)
        {
            return name =>
            {
                switch (name)
                {
                    case "EventType":
                        return eventType;
                    case "Operation":
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

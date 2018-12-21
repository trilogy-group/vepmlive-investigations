using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Fakes;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Linq.Fakes;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.Infrastructure.Fakes;
using EPMLiveCore.ReportHelper.Fakes;
using EPMLiveCore.ReportingProxy.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Infrastructure.ResourceManagment
{
    using System.Data;
    using System.Threading.Tasks.Fakes;
    using EPMLiveCore.API;
    using EPMLiveCore.API.Fakes;

    [TestClass]
    public class ResourcePoolManagerTests
    {
        private const string ProcessHtmlValuesMethodName = "ProcessHtmlValues";
        private const string GetAllFromReportingDBMethodName = "GetAllFromReportingDB";
        private const string BuildXmlElementsMethodName = "BuildXmlElements";
        private const int DummyInt = 1;
        private const string DummyString = "DummyString";
        private const string ContainsDataColumn = "ItemContains";
        private static readonly Guid DummyGuid = Guid.NewGuid();
        private IDisposable shimsContext;
        private ResourcePoolManager resourcePoolManager;
        private PrivateObject privateObject;

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            SetupShims();
            resourcePoolManager = new ResourcePoolManager();
            privateObject = new PrivateObject(resourcePoolManager);
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
            resourcePoolManager?.Dispose();
        }

        private void SetupShims()
        {
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimSPContext.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPWeb.AllInstances.IDGet = _ => DummyGuid;
            ShimSPSite.AllInstances.IDGet = _ => DummyGuid;
            ShimSPListItemManager.ConstructorStringGuidGuidStringString = (_, name, web, site, rootElement, elementName) => { };
            ShimReportData.ConstructorGuid = (_, id) => { };
            ShimReportData.AllInstances.GetSite = _ => new ShimDataRow();
            ShimReportData.AllInstances.GetListMappingGuid = (_, id) => new ShimDataRow();
            ShimQueryExecutor.ConstructorSPWeb = (_, web) => { };
            ShimXElement.ConstructorXName = (_, anme) => { };
            ShimUtils.GetFormatSPField = _ => "DummyFormat";
        }

        [TestMethod]
        public void ConstructorSPWeb_Should_CreatesInstance()
        {
            // Arrange
            var spWeb = new ShimSPWeb
            {
                IDGet = () => DummyGuid,
                SiteGet = () => new ShimSPSite
                {
                    IDGet = () => DummyGuid
                }
            };

            // Act
            var instance = new ResourcePoolManager(spWeb);

            // Assert
            instance.ShouldNotBeNull();
        }

        [TestMethod]
        public void Constructor_Should_CreatesInstance()
        {
            // Arrange, Act
            var instance = new ResourcePoolManager();

            // Assert
            instance.ShouldNotBeNull();
        }

        [TestMethod]
        public void GetAll_DataRowValueDifferentFrom1_ReturnsListManagerDocument()
        {
            // Arrange
            ShimSPListItemManager.AllInstances.ParentListGet = _ => new ShimSPList
            {
                ParentWebGet = () => new ShimSPWeb
                {
                    SiteGet = () => new ShimSPSite()
                }
            };
            ShimQueryExecutor.AllInstances.ExecuteReportingDBQueryStringIDictionaryOfStringObject =
                (_, query, parameters) => new ShimDataTable
                {
                    RowsGet = () => new ShimDataRowCollection
                    {
                        CountGet = () => 1,
                        ItemGetInt32 = index => new ShimDataRow
                        {
                            ItemGetString = name => 2
                        }
                    }
                };
            ShimSPListItemManager.AllInstances.GetAllBooleanBoolean =
                (_, includeHidden, includeReadOnly) => new ShimXDocument
                {
                    NodeTypeGet = () => XmlNodeType.Document
                };

            // Act
            var result = resourcePoolManager.GetAll(true, true);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.NodeType.ShouldBe(XmlNodeType.Document));
        }

        [TestMethod]
        public void GetAll_DataTableEmpty_ReturnsListManagerDocument()
        {
            // Arrange
            ShimSPListItemManager.AllInstances.ParentListGet = _ => new ShimSPList
            {
                ParentWebGet = () => new ShimSPWeb
                {
                    SiteGet = () => new ShimSPSite()
                }
            };
            ShimQueryExecutor.AllInstances.ExecuteReportingDBQueryStringIDictionaryOfStringObject =
                (_, query, parameters) => new ShimDataTable
                {
                    RowsGet = () => new ShimDataRowCollection
                    {
                        CountGet = () => 0
                    }
                };
            ShimSPListItemManager.AllInstances.GetAllBooleanBoolean =
                (_, includeHidden, includeReadOnly) => new ShimXDocument
                {
                    NodeTypeGet = () => XmlNodeType.Document
                };

            // Act
            var result = resourcePoolManager.GetAll(true, true);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.NodeType.ShouldBe(XmlNodeType.Document));
        }

        [TestMethod]
        public void GetAll_UseReportingDbTrue_ReturnsExpectedValue()
        {
            // Arrange
            ShimSPListItemManager.AllInstances.ParentListGet = _ => new ShimSPList
            {
                ParentWebGet = () => new ShimSPWeb
                {
                    SiteGet = () => new ShimSPSite()
                }
            };

            ShimQueryExecutor.AllInstances.ExecuteReportingDBQueryStringIDictionaryOfStringObject =
                (_, query, parameters) => new ShimDataTable
                {
                    RowsGet = () => new ShimDataRowCollection
                    {
                        CountGet = () => 1,
                        ItemGetInt32 = index => new ShimDataRow
                        {
                            ItemGetString = name => 1
                        }
                    }
                };
            ShimResourcePoolManager.AllInstances.GetAllFromReportingDBBooleanBoolean =
                (_, includeHidden, includeReadOnly) => new ShimXDocument
                {
                    NodeTypeGet = () => XmlNodeType.Document
                };

            // Act
            var result = resourcePoolManager.GetAll(true, true);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.NodeType.ShouldBe(XmlNodeType.Document));
        }

        [TestMethod]
        public void ProcessHtmlValues_Should_ExecuteCorrectly()
        {
            // Arrange
            var elements = new List<XElement>
            {
                new ShimXElement()
            };
            var valueDictionary = new Dictionary<string, object[]>
            {
                [DummyString] = new object[]
                {
                    new ShimSPFieldLookup
                    {
                        PrimaryFieldIdGet = () => DummyString,
                        GetFieldValueAsHtmlObject = _ => DummyString
                    }.Instance,
                    DummyString
                }
            };
            ShimXContainer.AllInstances.ElementsXName = (_, name) => new List<XElement>
            {
                new ShimXElement
                {
                    AttributeXName = attrName => null
                },
                new ShimXElement
                {
                    AttributeXName = attrName =>
                    {
                        if (attrName == "ProcessHtmlValue")
                        {
                            return new XAttribute("ProcessHtmlValue", "true");
                        }
                        else
                        {
                            return new XAttribute("HtmlValue", "Dummy");
                        }
                    }
                },
                new ShimXElement
                {
                    AttributeXName = attrName =>
                    {
                        if (attrName == "ProcessHtmlValue")
                        {
                            return new XAttribute("ProcessHtmlValue", "true");
                        }
                        else
                        {
                            return new XAttribute("HtmlValue", DummyString);
                        }
                    }
                }
            };
            var htmlValue = string.Empty;
            ShimXAttribute.AllInstances.SetValueObject = (_, value) =>
            {
                htmlValue = value.ToString();
            };
            ShimSPFieldLookup.AllInstances.GetFieldValueAsHtmlObject = (_, value) => DummyString;
            ShimXAttribute.AllInstances.Remove = _ => { };

            // Act
            var result = privateObject.Invoke(ProcessHtmlValuesMethodName, elements, valueDictionary);

            // Assert
            htmlValue.ShouldSatisfyAllConditions(
                () => htmlValue.ShouldNotBeNullOrEmpty(),
                () => htmlValue.ShouldBe(DummyString));
        }

        [TestMethod]
        public void GetAllFromReportingDB_ResourcesNull_ReturnsXmlDocument()
        {
            // Arrange
            ShimSPListItemManager.AllInstances.ParentListGet = _ => new ShimSPList
            {
                ParentWebGet = () => new ShimSPWeb
                {
                    SiteGet = () => new ShimSPSite(),
                    CurrentUserGet = () => new ShimSPUser()
                }
            };
            ShimQueryExecutor.AllInstances.ExecuteReportingDBStoredProcStringIDictionaryOfStringObject =
                (_, procedureName, parameters) => null;

            // Act
            var result = privateObject.Invoke(GetAllFromReportingDBMethodName, true, true) as XDocument;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.NodeType.ShouldBe(XmlNodeType.Document),
                () => result.Root.ShouldNotBeNull());
        }

        [TestMethod]
        public void GetAllFromReportingDB_Should_ReturnsObject()
        {
            // Arrange
            ShimXElement.ConstructorXName = (_, name) => { };
            ShimSPListItemManager.AllInstances.ParentListGet = _ => new ShimSPList
            {
                ParentWebGet = () => new ShimSPWeb
                {
                    SiteGet = () => new ShimSPSite(),
                    CurrentUserGet = () => new ShimSPUser()
                }
            };
            ShimQueryExecutor.AllInstances.ExecuteReportingDBStoredProcStringIDictionaryOfStringObject =
                (_, procedureName, parameters) => new ShimDataTable
                {
                    ColumnsGet = () =>
                    {
                        var list = new List<DataRow>
                        {
                            new ShimDataRow()
                        };
                        return new ShimDataColumnCollection().Bind(list);
                    },
                    RowsGet = () => new ShimDataRowCollection
                    {
                        GetEnumerator = () => new List<DataRow>
                        {
                            new ShimDataRow().Instance,
                            new ShimDataRow().Instance,
                            new ShimDataRow().Instance,
                            new ShimDataRow().Instance
                        }.GetEnumerator()
                    }
                };
            ShimSPList.AllInstances.FieldsGet = _ =>
            {
                var list = new List<SPField>
                {
                    new ShimSPField()
                };
                return new ShimSPFieldCollection().Bind(list);
            };
            ShimReportXmlBuilder.AllInstances.BuildXmlElementsBooleanBooleanIEnumerableOfDataRowIListOfSPFieldDataColumnCollectionDataTableDictionaryOfStringObjectArrayOut = BuildXmlElements;
            ShimTaskFactory.AllInstances.StartNewAction = (_, action) =>
            {
                return Task.CompletedTask;
            };
            ShimResourcePoolManager.AllInstances.ProcessHtmlValuesIEnumerableOfXElementDictionaryOfStringObjectArray = (_, elements, dictioanry) => { };

            // Act
            var result = privateObject.Invoke(GetAllFromReportingDBMethodName, true, true) as XDocument;

            // Assert
            result.ShouldNotBeNull();
        }

        [TestMethod]
        public void GetAllFromReportingDB_OnException_ThrowsAPIException()
        {
            // Arrange
            ShimQueryExecutor.AllInstances.ExecuteReportingDBStoredProcStringIDictionaryOfStringObject =
                (_, procedureName, parameters) =>
                {
                    throw new Exception();
                };

            // Act
            Action action = () => privateObject.Invoke(GetAllFromReportingDBMethodName, true, true);

            // Assert
            action.ShouldThrow<APIException>();
        }

        [TestMethod]
        public void BuildXmlElements_Should_ReturnList()
        {
            // Arrange
            var rowCollection = new List<DataRow>
            {
                new ShimDataRow
                {
                    ItemGetString = name => string.Empty
                }
            }.AsEnumerable();
            var spFieldCollection = GetSPFieldList();
            var dataColumnCollection = new ShimDataColumnCollection
            {
                ContainsString = name => name == ContainsDataColumn
            }.Instance;
            var resources = new ShimDataTable
            {
                ColumnsGet = () => new ShimDataColumnCollection
                {
                    ContainsString = name => true
                }
            }.Instance;
            var dictionary = new Dictionary<string, object[]>();
            ShimSPFieldMultiChoiceValue.ConstructorString = (_, value) => { };
            ShimSPFieldMultiChoiceValue.AllInstances.CountGet = _ => 1;
            ShimSPFieldMultiChoiceValue.AllInstances.ItemGetInt32 = (_, index) => DummyString;
            ShimSPListItemManager.AllInstances.GetFieldSpecialValuesSPFieldStringObjectStringOutStringOutStringOut = GetFieldSpecialValues;
            var reportXmlBuilder = new ReportXmlBuilder(resourcePoolManager, DummyString);

            // Act
            var result = reportXmlBuilder.BuildXmlElements(
                false, 
                false, 
                rowCollection, 
                spFieldCollection, 
                dataColumnCollection, 
                resources, 
                out dictionary);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldNotBeEmpty(),
                () => result.First().Value.ShouldContain(";#"),
                () => result.First().Elements().ShouldNotBeEmpty());
        }

        private List<SPField> GetSPFieldList()
        {
            return new List<SPField>
            {
                new ShimSPField
                {
                    InternalNameGet = () => DummyString,
                    HiddenGet = () => true,
                    ReadOnlyFieldGet = () => true,
                },
                new ShimSPField
                {
                    InternalNameGet = () => DummyString,
                    HiddenGet = () => false,
                    ReadOnlyFieldGet = () => true,
                },
                new ShimSPField
                {
                    InternalNameGet = () => ContainsDataColumn,
                    HiddenGet = () => false,
                    ReadOnlyFieldGet = () => false,
                    TypeGet = () => SPFieldType.DateTime
                },
                new ShimSPField
                {
                    InternalNameGet = () => DummyString,
                    HiddenGet = () => false,
                    ReadOnlyFieldGet = () => false,
                    TypeGet = () => SPFieldType.AllDayEvent
                },
                new ShimSPField
                {
                    InternalNameGet = () => DummyString,
                    HiddenGet = () => false,
                    ReadOnlyFieldGet = () => false,
                    TypeGet = () => SPFieldType.MultiChoice
                },
                new ShimSPField
                {
                    InternalNameGet = () => DummyString,
                    HiddenGet = () => false,
                    ReadOnlyFieldGet = () => false,
                    TypeGet = () => SPFieldType.User
                },
                new ShimSPField
                {
                    InternalNameGet = () => DummyString,
                    HiddenGet = () => false,
                    ReadOnlyFieldGet = () => false,
                    TypeGet = () => SPFieldType.User
                },
                new ShimSPField(new ShimSPFieldLookup())
                {
                    InternalNameGet = () => DummyString,
                    HiddenGet = () => false,
                    ReadOnlyFieldGet = () => false,
                    TypeGet = () => SPFieldType.Lookup
                },
                new ShimSPField(new ShimSPFieldLookup())
                {
                    InternalNameGet = () => DummyString,
                    HiddenGet = () => false,
                    ReadOnlyFieldGet = () => false,
                    TypeGet = () => SPFieldType.Lookup
                }
            };
        }

        /// <summary>
        /// This method is fake. All the parameters are required, even though not all of them are used
        /// </summary>
        private void GetFieldSpecialValues(
            SPListItemManager listManager, 
            SPField spField, 
            string stringValue, 
            object value, 
            out string fieldEditValue, 
            out string fieldTextValue, 
            out string fieldHtmlValue)
        {
            fieldEditValue = DummyString;
            fieldTextValue = DummyString;
            fieldHtmlValue = DummyString;
        }

        /// <summary>
        /// This method is fake. All the parameters are required, even though not all of them are used
        /// </summary>
        private List<XElement> BuildXmlElements(
            ReportXmlBuilder resourceManager, 
            bool hidden, 
            bool readOnly, 
            IEnumerable<DataRow> rowCollection, 
            IList<SPField> fields, 
            DataColumnCollection dataColumns, 
            System.Data.DataTable resources, 
            out Dictionary<string, object[]> valuesDict)
        {
            valuesDict = new Dictionary<string, object[]>();
            return new List<XElement>();
        }
    }
}

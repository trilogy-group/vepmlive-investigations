using System;
using System.Data;
using System.Data.Common.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Fakes;
using EPMLive.TestFakes.Utility;
using EPMLiveCore.ReportHelper.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests
{
    [TestClass, ExcludeFromCodeCoverage]
    public class ReportingDataTest
    {
        private const string SampleTable = "SampleTable";
        private const int SamplePageNum = 1;
        private const int SamplePageSize = 10;
        private const string DummyString = "Dummy";
        private const string GetReportQueryNodeMethodName = "GetReportQueryNode";
        private const string ValuesNodeName = "Values";
        private const string UserIdNodeName = "UserID";

        private IDisposable _shimsContext;
        private SharepointShims _sharepointShims;
        private AdoShims _adoShims;
        private PrivateType _privateType;

        [TestInitialize]
        public void Initialize()
        {
            _shimsContext = ShimsContext.Create();

            _sharepointShims = SharepointShims.ShimSharepointCalls();
            _adoShims = AdoShims.ShimAdoNetCalls();
            _privateType = new PrivateType(typeof(ReportingData));
        }

        [TestCleanup]
        public void Cleanup()
        {
            _shimsContext.Dispose();
        }

        [TestMethod]
        public void GetReportingData_Called_AdoDisposed()
        {
            // Arrange
            ShimReportBiz.ConstructorGuid = (biz, guid) =>
            {
                new ShimReportBiz(biz)
                {
                    SiteExists = () => true
                };
            };

            ShimDbDataAdapter.AllInstances.FillDataSet = (adapter, set) =>
            {
                var table = new DataTable(SampleTable);
                set.Tables.Add(table);
                return 0;
            };

            // Act
            var result = ReportingData.GetReportingData(
                _sharepointShims.WebShim,
                string.Empty,
                true,
                string.Empty,
                string.Empty,
                SamplePageNum,
                SamplePageSize);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Tables.Count.ShouldBe(1),
                () => result.Tables[0].TableName.ShouldBe(SampleTable),
                () => _adoShims.CommandsDisposed.Count.ShouldBe(2),
                () => _adoShims.DataAdaptersDisposed.Count.ShouldBe(1));
        }

        [TestMethod]
        public void ProcessReportFilter_Called_AdoDisposed()
        {
            // Arrange, Act
            var result = ReportingData.ProcessReportFilter(
                _sharepointShims.ListShim,
                _sharepointShims.WebShim,
                string.Empty);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe("<In><FieldRef Name=\"Title\"/><Values></Values></In>"),
                () => _adoShims.ConnectionsDisposed.Count.ShouldBe(1),
                () => _adoShims.CommandsDisposed.Count.ShouldBe(1),
                () => _adoShims.DataReadersDisposed.Count.ShouldBe(1));
        }

        [TestMethod]
        public void GetReportQueryNode_NodeNameIsNull_ReturnExpectedContent()
        {
            // Arrange
            var expectedText = $"{DummyString} is null";
            var spWeb = new ShimSPWeb().Instance;
            var xmlNode = new ShimXmlNode(new XmlDocument()).Instance;
            var spList = new ShimSPList
            {
                FieldsGet = () => new ShimSPFieldCollection
                {
                    GetFieldByInternalNameString = name => new ShimSPField
                    {
                        TypeGet = () => SPFieldType.Text
                    }
                }
            }.Instance;
            ShimXmlDocument.AllInstances.NameGet = _ => "IsNull";
            ShimXmlNode.AllInstances.SelectSingleNodeString = (_, nodeName) => new ShimXmlNode(new XmlDocument())
            {
                AttributesGet = () => new ShimXmlAttributeCollection
                {
                    ItemOfGetString = attrName => new ShimXmlAttribute
                    {
                        ValueGet = () => DummyString
                    }
                }
            }.Instance;
            var args = new object[] { spWeb, xmlNode, spList };

            // Act
            var result = _privateType.InvokeStatic(GetReportQueryNodeMethodName, args) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(expectedText));
        }

        [TestMethod]
        public void GetReportQueryNode_ValuesNodeNotEmpty_ReturnExpectedContent()
        {
            // Arrange
            var expectedText = $"({DummyString}Text = '{DummyString}' )";
            var spWeb = new ShimSPWeb().Instance;
            var xmlNode = new ShimXmlNode(new XmlDocument()).Instance;
            var spList = new ShimSPList
            {
                FieldsGet = () => new ShimSPFieldCollection
                {
                    GetFieldByInternalNameString = name => new ShimSPField
                    {
                        TypeGet = () => SPFieldType.User
                    }
                }
            }.Instance;
            var privateType = new PrivateType(typeof(ReportingData));
            ShimXmlDocument.AllInstances.NameGet = _ => "Contains";
            ShimXmlNode.AllInstances.SelectSingleNodeString =
                (_, nodeName) => new ShimXmlNode(new XmlDocument())
                {
                    AttributesGet = () => new ShimXmlAttributeCollection
                    {
                        ItemOfGetString = attrName => new ShimXmlAttribute
                        {
                            ValueGet = () => "Dummy"
                        }
                    }
                }.Instance;
            ShimXmlNode.AllInstances.SelectNodesString = (_, name) =>
            {
                var document = new XmlDocument();
                var element = document.CreateElement("Dummy");
                element.InnerText = "Dummy";
                document.AppendChild(element);
                return document.ChildNodes;
            };
            var args = new object[] { spWeb, xmlNode, spList };

            // Act
            var result = privateType.InvokeStatic(GetReportQueryNodeMethodName, args) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(expectedText));
        }

        [TestMethod]
        public void GetReportQueryNode_FieldTypeCalculated()
        {
            // Arrange
            var expectedText = $"{DummyString} Like '%100%'";
            var spWeb = new ShimSPWeb
            {
                CurrentUserGet = () => new ShimSPUser
                {
                    IDGet = () => 1
                }
            }.Instance;
            var xmlNode = new ShimXmlNode(new XmlDocument()).Instance;
            var spList = new ShimSPList
            {
                FieldsGet = () => new ShimSPFieldCollection
                {
                    GetFieldByInternalNameString = name => new ShimSPFieldCalculated
                    {
                        ShowAsPercentageGet = () => true
                    }
                }
            }.Instance;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Calculated;
            ShimXmlDocument.AllInstances.NameGet = _ => "Contains";
            ShimXmlNode.AllInstances.SelectSingleNodeString = (_, nodeName) =>
            {
                if (nodeName == "Values")
                {
                    return null;
                }
                else
                {
                    return GetDefaultXmlNode(DummyString, DummyString);
                }
            };

            var args = new object[] { spWeb, xmlNode, spList };

            // Act
            var result = _privateType.InvokeStatic(GetReportQueryNodeMethodName, args) as string;


            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(expectedText));
        }

        [TestMethod]
        public void GetReportQueryNode_FieldTypeDateTime()
        {
            // Arrange
            var expectedText = $"{DummyString} Like '{DateTime.Now.ToString("yyyy-MM-dd")}";
            var spWeb = new ShimSPWeb
            {
                CurrentUserGet = () => new ShimSPUser
                {
                    IDGet = () => 1
                }
            }.Instance;
            var xmlNode = new ShimXmlNode(new XmlDocument()).Instance;
            var spList = new ShimSPList
            {
                FieldsGet = () => new ShimSPFieldCollection
                {
                    GetFieldByInternalNameString = name => new ShimSPFieldCalculated
                    {
                        ShowAsPercentageGet = () => true
                    }
                }
            }.Instance;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.DateTime;
            ShimXmlDocument.AllInstances.NameGet = _ => "BeginsWith";
            ShimXmlNode.AllInstances.SelectSingleNodeString = (_, nodeName) =>
            {
                if (nodeName == ValuesNodeName || nodeName == UserIdNodeName)
                {
                    return null;
                }
                else
                {
                    return GetDefaultXmlNode(string.Empty, DummyString, "<Today></Today>");
                }
            };
            var args = new object[] { spWeb, xmlNode, spList };

            // Act
            var result = _privateType.InvokeStatic(GetReportQueryNodeMethodName, args) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(expectedText));
        }

        [TestMethod]
        public void GetReportQueryNode_FieldTypeLookup()
        {
            // Arrange
            var expectedText = $"{DummyString}ID Is Not Null";
            var spWeb = new ShimSPWeb
            {
                CurrentUserGet = () => new ShimSPUser
                {
                    IDGet = () => 1
                }
            }.Instance;
            var xmlNode = new ShimXmlNode(new XmlDocument()).Instance;
            var spList = new ShimSPList
            {
                FieldsGet = () => new ShimSPFieldCollection
                {
                    GetFieldByInternalNameString = name => new ShimSPFieldLookup
                    {
                        LookupListGet = () => Guid.NewGuid().ToString(),
                        LookupFieldGet = () => DummyString
                    }
                }
            }.Instance;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Lookup;
            ShimXmlDocument.AllInstances.NameGet = _ => "IsNotNull";
            ShimXmlNode.AllInstances.SelectSingleNodeString = (_, nodeName) =>
            {
                if (nodeName == ValuesNodeName || nodeName == UserIdNodeName)
                {
                    return null;
                }
                else
                {
                    return GetDefaultXmlNode(string.Empty, DummyString, "<Today></Today>");
                }
            };
            ShimSPField.AllInstances.ParentListGet = _ => new ShimSPList
            {
                ParentWebGet = () => new ShimSPWeb
                {
                    ListsGet = () => new ShimSPListCollection
                    {
                        ItemGetGuid = guid => new ShimSPList
                        {
                            FieldsGet = () => new ShimSPFieldCollection
                            {
                                GetFieldByInternalNameString = name => new ShimSPField
                                {
                                    TypeGet = () => SPFieldType.Integer
                                }
                            }
                        }
                    }
                }
            };
            var args = new object[] { spWeb, xmlNode, spList };

            // Act
            var result = _privateType.InvokeStatic(GetReportQueryNodeMethodName, args) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(expectedText));
        }

        [TestMethod]
        public void GetReportQueryNode_FieldTypeUser()
        {
            // Arrange
            var expectedText = $"{DummyString}ID Is Null";
            var spWeb = new ShimSPWeb
            {
                CurrentUserGet = () => new ShimSPUser
                {
                    IDGet = () => 1
                }
            }.Instance;
            var xmlNode = new ShimXmlNode(new XmlDocument()).Instance;
            var spList = new ShimSPList
            {
                FieldsGet = () => new ShimSPFieldCollection
                {
                    GetFieldByInternalNameString = name => new ShimSPFieldLookup
                    {
                        LookupListGet = () => Guid.NewGuid().ToString(),
                        LookupFieldGet = () => DummyString
                    }
                }
            }.Instance;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.User;
            ShimXmlDocument.AllInstances.NameGet = _ => "IsNull";
            ShimXmlNode.AllInstances.SelectSingleNodeString = (_, nodeName) =>
            {
                if (nodeName == ValuesNodeName || nodeName == UserIdNodeName)
                {
                    return null;
                }
                else
                {
                    return GetDefaultXmlNode("1", DummyString);
                }
            };
            var args = new object[] { spWeb, xmlNode, spList };

            // Act
            var result = _privateType.InvokeStatic(GetReportQueryNodeMethodName, args) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(expectedText));
        }

        [TestMethod]
        public void GetReportQueryNode_NotEqualOperator()
        {
            // Arrange
            var expectedText = $"(CounterID <> '1' OR CounterID IS NULL)";
            var spWeb = new ShimSPWeb
            {
                CurrentUserGet = () => new ShimSPUser
                {
                    IDGet = () => 1
                }
            }.Instance;
            var xmlNode = new ShimXmlNode(new XmlDocument()).Instance;
            var spList = new ShimSPList
            {
                FieldsGet = () => new ShimSPFieldCollection
                {
                    GetFieldByInternalNameString = name => new ShimSPFieldLookup
                    {
                        LookupListGet = () => Guid.NewGuid().ToString(),
                        LookupFieldGet = () => DummyString
                    }
                }
            }.Instance;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Lookup;
            ShimXmlDocument.AllInstances.NameGet = _ => "Neq";
            ShimXmlNode.AllInstances.SelectSingleNodeString = (_, nodeName) =>
            {
                if (nodeName == ValuesNodeName || nodeName == UserIdNodeName)
                {
                    return null;
                }
                else
                {
                    return GetDefaultXmlNode("1", SPFieldType.Counter.ToString());
                }
            };
            ShimSPField.AllInstances.ParentListGet = _ => new ShimSPList
            {
                ParentWebGet = () => new ShimSPWeb
                {
                    ListsGet = () => new ShimSPListCollection
                    {
                        ItemGetGuid = guid => new ShimSPList
                        {
                            FieldsGet = () => new ShimSPFieldCollection
                            {
                                GetFieldByInternalNameString = name => new ShimSPField
                                {
                                    TypeGet = () => SPFieldType.Computed
                                }
                            }
                        }
                    }
                }
            };
            var args = new object[] { spWeb, xmlNode, spList };

            // Act
            var result = _privateType.InvokeStatic(GetReportQueryNodeMethodName, args) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(expectedText));
        }

        [TestMethod]
        public void GetReportQueryNode_AndOrOperatorsWithEmptyParams_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "(( Or ) And )";
            var nodeAnd = new ShimXmlDocument() { NameGet = () => "And" };
            var nodeOr = new ShimXmlDocument() { NameGet = () => "Or" };
            var spWeb = new ShimSPWeb().Instance;
            var spList = new ShimSPList().Instance;
            var xmlNode = new ShimXmlNode(nodeAnd)
            {
                FirstChildGet = () => new ShimXmlNode(nodeOr)
            }.Instance;
            ShimXmlNode.AllInstances.FirstChildGet = _ => new ShimXmlNode(new XmlDocument());
            ShimXmlNode.AllInstances.NextSiblingGet = _ => new ShimXmlNode(new XmlDocument());
            ShimXmlNode.AllInstances.SelectSingleNodeString = (_, nodeName) => new ShimXmlNode(new XmlDocument())
            {
                AttributesGet = () => new ShimXmlAttributeCollection
                {
                    ItemOfGetString = attrName => new ShimXmlAttribute
                    {
                        ValueGet = () => "="
                    }
                }
            }.Instance;
            var args = new object[] { spWeb, xmlNode, spList };

            // Act
            var result = _privateType.InvokeStatic(GetReportQueryNodeMethodName, args) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(ExpectedValue));
        }

        [TestMethod]
        public void GetReportQueryNode_NodeSignEqualAndFieldLookup()
        {
            // Arrange
            var expectedText = $"',' + CAST({DummyString}Text as varchar(MAX)) + ',' LIKE '%,1,%'";
            var spWeb = new ShimSPWeb().Instance;
            var xmlNode = new ShimXmlNode(new XmlDocument()).Instance;
            var spList = new ShimSPList
            {
                FieldsGet = () => new ShimSPFieldCollection
                {
                    GetFieldByInternalNameString = name => new ShimSPFieldLookup
                    {
                        LookupListGet = () => Guid.NewGuid().ToString(),
                        LookupFieldGet = () => DummyString
                    }
                }
            }.Instance;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Lookup;
            ShimXmlDocument.AllInstances.NameGet = _ => "=";
            ShimXmlNode.AllInstances.SelectSingleNodeString = (_, nodeName) =>
            {
                if (nodeName == ValuesNodeName || nodeName == UserIdNodeName)
                {
                    return null;
                }
                else
                {
                    return GetDefaultXmlNode("1", DummyString);
                }
            };
            var args = new object[] { spWeb, xmlNode, spList };

            // Act
            var result = _privateType.InvokeStatic(GetReportQueryNodeMethodName, args) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(expectedText));
        }

        [TestMethod]
        public void GetReportQueryNode_NodeDefaultSign()
        {
            // Arrange
            var expectedText = $"{DummyString} = '1'";
            var spWeb = new ShimSPWeb().Instance;
            var xmlNode = new ShimXmlNode(new XmlDocument()).Instance;
            var spList = new ShimSPList
            {
                FieldsGet = () => new ShimSPFieldCollection
                {
                    GetFieldByInternalNameString = name => new ShimSPFieldLookup
                    {
                        LookupListGet = () => Guid.NewGuid().ToString(),
                        LookupFieldGet = () => DummyString
                    }
                }
            }.Instance;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.AllDayEvent;
            ShimXmlDocument.AllInstances.NameGet = _ => "";
            ShimXmlNode.AllInstances.SelectSingleNodeString = (_, nodeName) =>
            {
                if (nodeName == ValuesNodeName || nodeName == UserIdNodeName)
                {
                    return null;
                }
                else
                {
                    return GetDefaultXmlNode("1", DummyString);
                }
            };
            var args = new object[] { spWeb, xmlNode, spList };

            // Act
            var result = _privateType.InvokeStatic(GetReportQueryNodeMethodName, args) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(expectedText));
        }

        [TestMethod]
        public void GetReportQueryNode_NodeDefaultSignDateTimeField()
        {
            // Arrange
            var expectedText = $"CONVERT(nvarchar, {DummyString}, 111) = CONVERT(nvarchar, CONVERT(DateTime, '1'), 111)";
            var spWeb = new ShimSPWeb().Instance;
            var xmlNode = new ShimXmlNode(new XmlDocument()).Instance;
            var spList = new ShimSPList
            {
                FieldsGet = () => new ShimSPFieldCollection
                {
                    GetFieldByInternalNameString = name => new ShimSPFieldLookup
                    {
                        LookupListGet = () => Guid.NewGuid().ToString(),
                        LookupFieldGet = () => DummyString
                    }
                }
            }.Instance;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.DateTime;
            ShimXmlDocument.AllInstances.NameGet = _ => "";
            ShimXmlNode.AllInstances.SelectSingleNodeString = (_, nodeName) =>
            {
                if (nodeName == ValuesNodeName || nodeName == UserIdNodeName)
                {
                    return null;
                }
                else
                {
                    return GetDefaultXmlNode("1", DummyString);
                }
            };
            var args = new object[] { spWeb, xmlNode, spList };

            // Act
            var result = _privateType.InvokeStatic(GetReportQueryNodeMethodName, args) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(expectedText));
        }

        [TestMethod]
        public void GetReportQueryNode_NeqOperatorDateTime()
        {
            // Arrange
            var expectedText = $"((CONVERT(nvarchar,{DummyString}, 111) <> CONVERT(nvarchar, CONVERT(DateTime, '1'), 111)) OR {DummyString} IS NULL)";
            var spWeb = new ShimSPWeb().Instance;
            var xmlNode = new ShimXmlNode(new XmlDocument()).Instance;
            var spList = new ShimSPList
            {
                FieldsGet = () => new ShimSPFieldCollection
                {
                    GetFieldByInternalNameString = name => new ShimSPFieldLookup
                    {
                        LookupListGet = () => Guid.NewGuid().ToString(),
                        LookupFieldGet = () => DummyString
                    }
                }
            }.Instance;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.DateTime;
            ShimXmlDocument.AllInstances.NameGet = _ => "Neq";
            ShimXmlNode.AllInstances.SelectSingleNodeString = (_, nodeName) =>
            {
                if (nodeName == ValuesNodeName || nodeName == UserIdNodeName)
                {
                    return null;
                }
                else
                {
                    return GetDefaultXmlNode("1", DummyString);
                }
            };
            var args = new object[] { spWeb, xmlNode, spList };

            // Act
            var result = _privateType.InvokeStatic(GetReportQueryNodeMethodName, args) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(expectedText));
        }

        private XmlNode GetDefaultXmlNode(string innerText, string attributeNameValue, string innerXml = null)
        {
            return new ShimXmlNode(new XmlDocument())
            {
                InnerTextGet = () => innerText,
                InnerXmlGet = () => innerXml ?? string.Empty,
                AttributesGet = () => new ShimXmlAttributeCollection
                {
                    ItemOfGetString = attrName => new ShimXmlAttribute
                    {
                        ValueGet = () => attributeNameValue
                    }
                }
            }.Instance;
        }
    }
}

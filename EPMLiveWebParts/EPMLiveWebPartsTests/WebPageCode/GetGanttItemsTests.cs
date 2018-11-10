using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Xml;
using System.Xml.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWebParts.Tests.WebPageCode
{
    using EPMLiveCore;
    using Fakes;

    [TestClass]
    public class GetGanttItemsTests
    {
        private IDisposable shimsContext;
        private getganttitems getganttitems;
        private PrivateObject privateObject;
        private PrivateType privateType;
        private const string OutputXmlMethodName = "outputXml";
        private const string TitleField = "TitleField";
        private const string EditField = "EditField";
        private const string WorkspaceUrlField = "WorkspaceUrlField";
        private const string TextField = "TextField";
        private const string NumberField = "NumberField";
        private const string CurrencyField = "CurrencyField";
        private const string DateTimeField = "DateTimeField";
        private const string BooleanField = "BooleanField";
        private const string CalculatedField = "CalculatedField";
        private const string ChoiceField = "ChoiceField";
        private const string LookupField = "LookupField";
        private const string MultichoiceField = "MultichoiceField";
        private const string NoteField = "NoteField";
        private const string URLField = "URLField";
        private const string UserField = "UserField";
        private const string StateField = "StateField";
        private const string CalculatedFieldIndicator = "CalculatedFieldIndicator";
        private const string DummyValue = "DummyValue";
        private const string StartDateField = "StartField";
        private const string DueDateField = "DueField";
        private const string ProgressField = "Progress";
        private const string GetAttributeMethodName = "getAttribute";
        private const string ProcessPredecessorMethodName = "processPredecessor";
        private const string ProcessPredecessorsMethodName = "processPredecessors";
        private const string ProcessItemsMethodName = "ProcessItems";
        private const string GetFormatMethodName = "getFormat";
        private const string GetParamsMethodName = "getParams";
        private const string GetRealFieldMethodName = "getRealField";
        private const string GetFieldValueMethodName = "getFieldValue";

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            SetupShims();
            getganttitems = new getganttitems();
            privateObject = new PrivateObject(getganttitems);
            privateType = new PrivateType(typeof(getganttitems));
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }

        private void SetupShims()
        {
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<schema></schema>";
        }

        [TestMethod]
        public void OutputXml_Should_ExecuteCorrectly()
        {
            // Arrange
            privateObject.SetFieldOrProperty("gridname", DummyValue);
            privateObject.SetFieldOrProperty("tb", new TimeDebug(string.Empty, string.Empty));
            privateObject.SetFieldOrProperty("aViewFields", new ArrayList());
            var docXml = new ShimXmlNode(new XmlDocument())
            {
                SelectSingleNodeString = name => new ShimXmlNode(new XmlDocument())
                {
                    InnerTextGet = () => "Dummy"
                },
                FirstChildGet = () => new ShimXmlNode(new XmlDocument())
                {
                    SelectNodesString = name =>
                    {
                        var doc = new XmlDocument();
                        doc.AppendChild(doc.CreateElement("ElementName"));
                        return doc.ChildNodes;
                    }
                }
            }.Instance;
            privateObject.SetFieldOrProperty("docXml", docXml as XmlDocument);
            privateObject.SetFieldOrProperty("epmdebug", bool.TrueString.ToLower());
            privateObject.SetFieldOrProperty("bShowGantt", true);
            privateObject.SetFieldOrProperty("StartDateField", StartDateField);
            privateObject.SetFieldOrProperty("DueDateField", DueDateField);
            privateObject.SetFieldOrProperty("ProgressField", ProgressField);
            privateObject.SetFieldOrProperty("list", new ShimSPList
            {
                BaseTypeGet = () => Microsoft.SharePoint.SPBaseType.DocumentLibrary
            }.Instance);
            privateObject.SetFieldOrProperty("view", new ShimSPView
            {
                RowLimitGet = () => 1
            }.Instance);
            privateObject.SetFieldOrProperty("hshLookupEnums", new Hashtable());
            privateObject.SetFieldOrProperty("hshLookupEnumKeys", new Hashtable());
            Shimgetganttitems.AllInstances.ProcessItemsXmlNodeXmlNodeXmlNodeListXmlDocument =
                (_, parent, row, fields, document) => { };
            var expectedContent = new List<string>
            {
                "NameCol=\"FileLeafRef\" MainCol=\"FileLeafRef\" />",
                "PagInfo=\"Dummy\" PagSize=\"1\" LinkTitleField=\"Title\"",
                $"{StartDateField}Formula=\"ganttstart()\"",
                $"{DueDateField}Formula=\"ganttend()\"",
                $"{ProgressField}Formula=\"ganttpercent()\"",
            };

            // Act
            privateObject.Invoke(OutputXmlMethodName);
            var result = privateObject.GetFieldOrProperty("data") as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => expectedContent.ForEach(content => result.ShouldContainWithoutWhitespace(content)));
        }

        [TestMethod]
        public void OutputXml_ViewFieldsPart1_ExecutesCorrectly()
        {
            // Arrange
            privateObject.SetFieldOrProperty("gridname", DummyValue);
            privateObject.SetFieldOrProperty("tb", new TimeDebug(string.Empty, string.Empty));
            var docXml = new ShimXmlNode(new XmlDocument())
            {
                SelectSingleNodeString = name => null,
                FirstChildGet = () => new ShimXmlNode(new XmlDocument())
                {
                    SelectNodesString = name =>
                    {
                        var doc = new XmlDocument();
                        doc.AppendChild(doc.CreateElement("ElementName"));
                        return doc.ChildNodes;
                    }
                }
            }.Instance;
            privateObject.SetFieldOrProperty("docXml", docXml as XmlDocument);
            privateObject.SetFieldOrProperty("list", new ShimSPList
            {
                BaseTypeGet = () => Microsoft.SharePoint.SPBaseType.GenericList,
                FieldsGet = () => new ShimSPFieldCollection()
            }.Instance);
            privateObject.SetFieldOrProperty("view", new ShimSPView
            {
                RowLimitGet = () => 1
            }.Instance);
            privateObject.SetFieldOrProperty("hshLookupEnums", new Hashtable());
            privateObject.SetFieldOrProperty("hshLookupEnumKeys", new Hashtable());
            Shimgetganttitems.AllInstances.ProcessItemsXmlNodeXmlNodeXmlNodeListXmlDocument =
                (_, parent, row, fields, document) => { };
            Shimgetganttitems.AllInstances.getRealFieldSPField =
                (_, field) => field;
            Shimgetganttitems.getFormatSPFieldXmlDocumentSPWeb =
                (field, document, web) =>
                {
                    return field.Type == SPFieldType.Currency
                        ? "R$"
                        : "DummyFormat";
                };
            privateObject.SetFieldOrProperty("aViewFields", new ArrayList
            {
                TitleField,
                EditField,
                WorkspaceUrlField,
                TextField,
                NumberField,
                CurrencyField,
                DateTimeField,
                BooleanField,
            });
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, name) =>
            {
                switch (name)
                {
                    case TitleField:
                        return new ShimSPField
                        {
                            InternalNameGet = () => "Title",
                        };
                    case EditField:
                        return new ShimSPField
                        {
                            InternalNameGet = () => "Edit",
                        };
                    case WorkspaceUrlField:
                        return new ShimSPField
                        {
                            InternalNameGet = () => "WorkspaceUrl",
                        };
                    case TextField:
                        return new ShimSPField
                        {
                            InternalNameGet = () => "TextField",
                            TypeGet = () => SPFieldType.Text,
                        };
                    case NumberField:
                        return new ShimSPField
                        {
                            InternalNameGet = () => "NumberField",
                            TypeGet = () => SPFieldType.Number,
                        };
                    case CurrencyField:
                        return new ShimSPField(new ShimSPFieldCurrency() { CurrencyLocaleIdGet = () => 1046 })
                        {
                            InternalNameGet = () => "CurrencyField",
                            TypeGet = () => SPFieldType.Currency,
                        };
                    case DateTimeField:
                        return new ShimSPField
                        {
                            InternalNameGet = () => "DateTimeField",
                            TypeGet = () => SPFieldType.DateTime,
                        };
                    case BooleanField:
                        return new ShimSPField
                        {
                            InternalNameGet = () => "BooleanField",
                            TypeGet = () => SPFieldType.Boolean,
                        };
                    default:
                        return new ShimSPField();
                }
            };
            var expectedContent = new List<string>
            {
                "NameCol=\"Title\" MainCol=\"Title\" />",
                "<C Name=\"Title\" CaseSensitive=\"0\" Format=\"DummyFormat\" EditFormat=\"DummyFormat\" " +
                "MinWidth=\"300\" Button=\"Html\" RelWidth=\"1\" Wrap=\"0\" Type=\"Html\" />",
                "<C Name=\"Edit\" CaseSensitive=\"0\" Format=\"DummyFormat\" EditFormat=\"DummyFormat\" " +
                "Width=\"50\" Wrap=\"0\" Type=\"Html\" />",
                "<C Name=\"WorkspaceUrl\" CaseSensitive=\"0\" Format=\"DummyFormat\" EditFormat=\"DummyFormat\" " +
                "Width=\"60\" Align=\"Center\" Wrap=\"0\" Type=\"Html\" />",
                "<C Name=\"TextField\" CaseSensitive=\"0\" Format=\"DummyFormat\" EditFormat=\"DummyFormat\" " +
                "MinWidth=\"150\" Wrap=\"0\" Type=\"Html\" />",
                "<C Name=\"NumberField\" CaseSensitive=\"0\" Format=\"DummyFormat\" EditFormat=\"DummyFormat\" " +
                "Align=\"Right\" MinWidth=\"150\" Wrap=\"0\" Type=\"Float\" />",
                "<C Name=\"CurrencyField\" CaseSensitive=\"0\" Format=\"R$\" EditFormat=\"\" " +
                "Align=\"Right\" MinWidth=\"150\" Wrap=\"0\" Type=\"Float\" />",
                "<C Name=\"DateTimeField\" CaseSensitive=\"0\" Format=\"DummyFormat\" EditFormat=\"DummyFormat\" Align=\"Left\" MinWidth=\"150\" Wrap=\"0\" Type=\"Date\" />",
                "<C Name=\"BooleanField\" CaseSensitive=\"0\" Format=\"DummyFormat\" EditFormat=\"DummyFormat\" MinWidth=\"150\" Wrap=\"0\" Type=\"Bool\" />"
            };

            // Act
            privateObject.Invoke(OutputXmlMethodName);
            var result = privateObject.GetFieldOrProperty("data") as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => expectedContent.ForEach(content => result.ShouldContainWithoutWhitespace(content)));
        }

        [TestMethod]
        public void OutputXml_ViewFieldsPart2_ExecutesCorrectly()
        {
            // Arrange
            privateObject.SetFieldOrProperty("gridname", DummyValue);
            privateObject.SetFieldOrProperty("tb", new TimeDebug(string.Empty, string.Empty));
            var docXml = new ShimXmlNode(new XmlDocument())
            {
                SelectSingleNodeString = name => null,
                FirstChildGet = () => new ShimXmlNode(new XmlDocument())
                {
                    SelectNodesString = name =>
                    {
                        var doc = new XmlDocument();
                        doc.AppendChild(doc.CreateElement("ElementName"));
                        return doc.ChildNodes;
                    }
                }
            }.Instance;
            privateObject.SetFieldOrProperty("docXml", docXml as XmlDocument);
            privateObject.SetFieldOrProperty("list", new ShimSPList
            {
                BaseTypeGet = () => Microsoft.SharePoint.SPBaseType.GenericList,
                FieldsGet = () => new ShimSPFieldCollection()
            }.Instance);
            privateObject.SetFieldOrProperty("view", new ShimSPView
            {
                RowLimitGet = () => 1
            }.Instance);
            privateObject.SetFieldOrProperty("hshLookupEnums", new Hashtable());
            privateObject.SetFieldOrProperty("hshLookupEnumKeys", new Hashtable());
            Shimgetganttitems.AllInstances.ProcessItemsXmlNodeXmlNodeXmlNodeListXmlDocument =
                (_, parent, row, fields, document) => { };
            Shimgetganttitems.AllInstances.getRealFieldSPField =
                (_, field) => field;
            Shimgetganttitems.getFormatSPFieldXmlDocumentSPWeb =
                (field, document, web) => "DummyFormat";
            privateObject.SetFieldOrProperty("aViewFields", new ArrayList
            {
                CalculatedField,
                CalculatedFieldIndicator,
                ChoiceField,
                LookupField,
                MultichoiceField,
                NoteField,
                URLField,
                UserField,
                StateField,
            });
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, name) =>
            {
                switch (name)
                {
                    case CalculatedFieldIndicator:
                        {
                            var calculated = new ShimSPFieldCalculated
                            {
                                OutputTypeGet = () => SPFieldType.File,
                            };
                            return new ShimSPField(calculated)
                            {
                                TypeGet = () => SPFieldType.Calculated,
                                InternalNameGet = () => CalculatedField,
                                DescriptionGet = () => "Indicator"
                            };
                        }
                    case CalculatedField:
                        {
                            var calculated = new ShimSPFieldCalculated
                            {
                                OutputTypeGet = () => SPFieldType.Currency
                            };
                            return new ShimSPField(calculated)
                            {
                                TypeGet = () => SPFieldType.Calculated,
                                InternalNameGet = () => CalculatedField,
                            };
                        }
                    case ChoiceField:
                        {
                            var choice = new ShimSPFieldChoice();
                            var multiChoice = new ShimSPFieldMultiChoice(choice)
                            {
                                ChoicesGet = () => new StringCollection() { DummyValue }
                            };
                            return new ShimSPField(multiChoice)
                            {
                                InternalNameGet = () => ChoiceField,
                                TypeGet = () => SPFieldType.Choice
                            };
                        }
                    case LookupField:
                        return new ShimSPField
                        {
                            InternalNameGet = () => LookupField,
                            TypeGet = () => SPFieldType.Lookup,
                            TypeAsStringGet = () => "LookupMulti"
                        };
                    case MultichoiceField:
                        {
                            var multiChoice = new ShimSPFieldMultiChoice
                            {
                                ChoicesGet = () => new StringCollection() { DummyValue }
                            };
                            return new ShimSPField(multiChoice)
                            {
                                InternalNameGet = () => MultichoiceField,
                                TypeGet = () => SPFieldType.MultiChoice
                            };
                        }
                    case NoteField:
                        return new ShimSPField
                        {
                            InternalNameGet = () => NoteField,
                            TypeGet = () => SPFieldType.Note
                        };
                    case URLField:
                        return new ShimSPField
                        {
                            InternalNameGet = () => URLField,
                            TypeGet = () => SPFieldType.URL
                        };
                    case UserField:
                        return new ShimSPField
                        {
                            InternalNameGet = () => UserField,
                            TypeGet = () => SPFieldType.User
                        };
                    case StateField:
                        return new ShimSPField
                        {
                            TypeAsStringGet = () => "TotalRollup",
                            InternalNameGet = () => "State",
                            TypeGet = () => SPFieldType.WorkflowStatus
                        };
                    default:
                        return new ShimSPField();
                }
            };
            privateObject.SetFieldOrProperty("hshLookupEnums", new Hashtable());
            privateObject.SetFieldOrProperty("hshLookupEnumKeys", new Hashtable());
            var expectedContent = new List<string>
            {
                "<C Name=\"NoteField\" CaseSensitive=\"0\" Format=\"DummyFormat\" EditFormat=\"DummyFormat\" " +
                "MinWidth=\"200\" Wrap=\"0\" Type=\"Html\" />",
                "<C Name=\"URLField\" CaseSensitive=\"0\" Format=\"DummyFormat\" EditFormat=\"DummyFormat\" " +
                "MinWidth=\"150\" Wrap=\"0\" Type=\"Html\" />",
                "<C Name=\"UserField\" Format=\"DummyFormat\" EditFormat=\"DummyFormat\" CaseSensitive=\"0\" " +
                "MinWidth=\"150\" Wrap=\"0\" Type=\"Html\" />",
                "<C Name=\"FState\" CaseSensitive=\"0\" Format=\"DummyFormat\" EditFormat=\"DummyFormat\" " +
                "Align=\"Right\" MinWidth=\"150\" Wrap=\"0\" Type=\"Html\" />",
                "<C Name=\"ChoiceField\" CaseSensitive=\"0\" Format=\"DummyFormat\" EditFormat=\"DummyFormat\" " +
                "Enum=\";DummyValue\" EnumKeys=\";DummyValue\" MinWidth=\"150\" Wrap=\"0\" Type=\"Enum\" />",
                "<C Name=\"LookupField\" CaseSensitive=\"0\" Format=\"DummyFormat\" EditFormat=\"DummyFormat\" " +
                "Enum=\";\" EnumKeys=\";\" Range=\"1\" MinWidth=\"150\" Wrap=\"0\" Type=\"Enum\" />",
                "<C Name=\"MultichoiceField\" CaseSensitive=\"0\" Format=\"DummyFormat\" EditFormat=\"DummyFormat\" " +
                "Enum=\";DummyValue\" Range=\"1\" MinWidth=\"150\" Wrap=\"0\" Type=\"Enum\" />"
            };

            // Act
            privateObject.Invoke(OutputXmlMethodName);
            var result = privateObject.GetFieldOrProperty("data") as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => expectedContent.ForEach(content => result.ShouldContainWithoutWhitespace(content)));
        }

        [TestMethod]
        public void GetAttribute_AttributeFound_ReturnsExpectedValue()
        {
            // Arrange
            const string AttributeName = "AttrName";
            const string ExpectedValue = "Value";
            var node = new ShimXmlNode(new XmlDocument())
            {
                AttributesGet = () => new ShimXmlAttributeCollection
                {
                    ItemOfGetString = name => new ShimXmlAttribute
                    {
                        ValueGet = () => ExpectedValue
                    }
                }
            }.Instance;

            // Act
            var result = privateObject.Invoke(GetAttributeMethodName, node, AttributeName) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(ExpectedValue));
        }

        [TestMethod]
        public void GetAttribute_OnException_ReturnsEmptyValue()
        {
            // Arrange
            const string AttributeName = "AttrName";
            var node = new ShimXmlNode(new XmlDocument())
            {
                AttributesGet = () =>
                {
                    throw new Exception();
                }
            }.Instance;

            // Act
            var result = privateObject.Invoke(GetAttributeMethodName, node, AttributeName) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBeNullOrEmpty());
        }

        [TestMethod]
        public void ProcessPredecessor_Should_ExecuteCorrectly()
        {
            // Arrange
            const string Order = "Order";
            const string Project = "Proj";
            const string RowId = "1";
            const string Suffix = "Dummy";
            var expectedValue = $"Descendants=\"{RowId}{Suffix}\"";
            var xml = $"<root><B><I taskorder=\"{Order}\" Project=\"{Project}\"/></B></root>";
            var document = new XmlDocument();
            document.LoadXml(xml);

            // Act
            privateObject.Invoke(
                ProcessPredecessorMethodName,
                document,
                Order,
                Project,
                RowId,
                Suffix);
            var result = document.OuterXml;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(expectedValue));
        }

        [TestMethod]
        public void ProcessPredecessor_ExistingAttribute_ExecutesCorrectly()
        {
            // Arrange
            const string Order = "Order";
            const string Project = "Proj";
            const string RowId = "1";
            const string Suffix = "Dummy";
            var expectedValue = $"Descendants=\"Value,{RowId}{Suffix}\"";
            var xml = $"<root><B><I taskorder=\"{Order}\" Project=\"{Project}\" Descendants=\"Value\"/></B></root>";
            var document = new XmlDocument();
            document.LoadXml(xml);

            // Act
            privateObject.Invoke(
                ProcessPredecessorMethodName,
                document,
                Order,
                Project,
                RowId,
                Suffix);
            var result = document.OuterXml;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(expectedValue));
        }

        [TestMethod]
        public void ProcessPredecessors_Should_ExecuteCorrectly()
        {
            // Arrange
            var node = new ShimXmlNode(new XmlDocument())
            {
            }.Instance;
            var document = new XmlDocument();
            Shimgetganttitems.AllInstances.getAttributeXmlNodeString =
                (_, row, attribute) => "10abc,1b";
            var suffixList = new List<string>();
            Shimgetganttitems.AllInstances.processPredecessorXmlDocumentStringStringStringString =
                (_, doc, pred, project, row, suffix) =>
                {
                    suffixList.Add(suffix);
                };

            // Act
            privateObject.Invoke(
                ProcessPredecessorsMethodName,
                node,
                document);

            // Assert
            suffixList.ShouldSatisfyAllConditions(
                () => suffixList.ShouldContain("abc"),
                () => suffixList.ShouldContain("b"));
        }

        [TestMethod]
        public void ProcessItems_Should_ExecuteCorrectly()
        {
            // Arrange
            var nodeList = new List<XmlNode>();
            var parent = new ShimXmlNode(new XmlDocument())
            {
                AppendChildXmlNode = node =>
                {
                    nodeList.Add(node);
                    return node;
                }
            }.Instance;
            var row = new ShimXmlNode(new XmlDocument())
            {
                SelectNodesString = _ =>
                {
                    return DummyXmlNodeList(4);
                },
                SelectSingleNodeString = _ => new ShimXmlNode(new XmlDocument())
                {
                    InnerTextGet = () => DummyValue
                }
            }.Instance;
            var arrayFields = DummyFieldsXmlNodeList();
            var document = new XmlDocument();
            document.LoadXml("<Grid><row></row></Grid>");
            Shimgetganttitems.AllInstances.getFieldValueStringString = 
                (_, fieldName, text) => text;
            privateObject.SetFieldOrProperty("DueDateField", DueDateField);
            privateObject.SetFieldOrProperty("hshLookupEnums", new Hashtable
            {
                ["State"] = new ArrayList()
            });
            privateObject.SetFieldOrProperty("hshLookupEnumKeys", new Hashtable
            {
                ["State"] = new ArrayList()
            });
            var expectedAttributes = new List<string>
            {
                "siteid",
                "webid",
                "itemid",
                "wsurl",
                "listid",
                "SiteUrl",
                "viewMenus",
                "HasComments",
                "HasPlan",
                "id",
                "DueField",
                "Predecessors",
                "Title",
                "FState"
            };

            // Act
            privateObject.Invoke(
                ProcessItemsMethodName,
                parent,
                row,
                arrayFields,
                document);
            var attributesItem = nodeList.FirstOrDefault();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => nodeList.ShouldNotBeEmpty(),
                () => attributesItem.ShouldNotBeNull(),
                () => attributesItem.Attributes.Count.ShouldBeGreaterThan(0),
                () => ValidateExpectedAttributes(attributesItem.Attributes, expectedAttributes));
        }

        [TestMethod]
        public void GetFormat_TypeDateTimeDateOnly_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "M/d/yyyy";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.DateTime
            }.Instance;
            var document = new XmlDocument();
            var web = new ShimSPWeb().Instance;
            ShimXmlNode.AllInstances.FirstChildGet = _ => new ShimXmlNode(new XmlDocument())
            {
                AttributesGet = () => new ShimXmlAttributeCollection
                {
                    ItemOfGetString = name => CreateAttribute("DateOnly")
                }
            };

            // Act
            var result = privateType.InvokeStatic(GetFormatMethodName, field, document, web) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(ExpectedValue));
        }

        [TestMethod]
        public void GetFormat_TypeDateTimeFullDate_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "dddd, MMMM d, yyyy h:mm:ss tt";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.DateTime
            }.Instance;
            var document = new XmlDocument();
            var web = new ShimSPWeb().Instance;
            ShimXmlNode.AllInstances.FirstChildGet = _ => new ShimXmlNode(new XmlDocument())
            {
                AttributesGet = () => new ShimXmlAttributeCollection
                {
                    ItemOfGetString = name => CreateAttribute("FullDate")
                }
            };

            // Act
            var result = privateType.InvokeStatic(GetFormatMethodName, field, document, web) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(ExpectedValue));
        }

        [TestMethod]
        public void GetFormat_TypeNumberPercentage_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "0\\%;0\\%;0\\%";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Number
            }.Instance;
            var document = new XmlDocument();
            var web = new ShimSPWeb().Instance;
            ShimXmlNode.AllInstances.FirstChildGet = _ => new ShimXmlNode(new XmlDocument())
            {
                AttributesGet = () => new ShimXmlAttributeCollection
                {
                    ItemOfGetString = name => CreateAttribute("true")
                }
            };

            // Act
            var result = privateType.InvokeStatic(GetFormatMethodName, field, document, web) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(ExpectedValue));
        }

        [TestMethod]
        public void GetFormat_TypeNumber_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = ",0.00000";
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Number
            }.Instance;
            var document = new XmlDocument();
            var web = new ShimSPWeb().Instance;
            ShimXmlNode.AllInstances.FirstChildGet = _ => new ShimXmlNode(new XmlDocument())
            {
                AttributesGet = () => new ShimXmlAttributeCollection
                {
                    ItemOfGetString = name => CreateAttribute("5")
                }
            };

            // Act
            var result = privateType.InvokeStatic(GetFormatMethodName, field, document, web) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(ExpectedValue));
        }

        [TestMethod]
        public void GetFormat_TypeCurrencyWithSymbol_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "R$,0.00";
            var currency = new ShimSPFieldCurrency
            {
                CurrencyLocaleIdGet = () => 1046
            };
            var field = new ShimSPField(currency)
            {
                TypeGet = () => SPFieldType.Currency
            }.Instance;
            var document = new XmlDocument();
            var web = new ShimSPWeb().Instance;
            ShimXmlNode.AllInstances.FirstChildGet = _ => new ShimXmlNode(new XmlDocument())
            {
                AttributesGet = () => new ShimXmlAttributeCollection
                {
                    ItemOfGetString = name => CreateAttribute("5")
                }
            };

            // Act
            var result = privateType.InvokeStatic(GetFormatMethodName, field, document, web) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(ExpectedValue));
        }

        [TestMethod]
        public void GetFormat_TypeCurrencyWithoutSymbol_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = ",0.00 m.";
            var currency = new ShimSPFieldCurrency
            {
                CurrencyLocaleIdGet = () => 1090
            };
            var field = new ShimSPField(currency)
            {
                TypeGet = () => SPFieldType.Currency
            }.Instance;
            var document = new XmlDocument();
            var web = new ShimSPWeb().Instance;
            ShimXmlNode.AllInstances.FirstChildGet = _ => new ShimXmlNode(new XmlDocument())
            {
                AttributesGet = () => new ShimXmlAttributeCollection
                {
                    ItemOfGetString = name => CreateAttribute("5")
                }
            };

            // Act
            var result = privateType.InvokeStatic(GetFormatMethodName, field, document, web) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(ExpectedValue));
        }

        [TestMethod]
        public void GetFormat_TypeCalculatedCurrency_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "$,0.00";
            var field = new ShimSPField()
            {
                TypeGet = () => SPFieldType.Calculated
            }.Instance;
            var document = new XmlDocument();
            var web = new ShimSPWeb
            {
                LocaleGet = () => new CultureInfo("en-US")
            }.Instance;
            ShimXmlNode.AllInstances.FirstChildGet = _ => new ShimXmlNode(new XmlDocument())
            {
                AttributesGet = () => new ShimXmlAttributeCollection
                {
                    ItemOfGetString = name => CreateAttribute("Currency")
                }
            };

            // Act
            var result = privateType.InvokeStatic(GetFormatMethodName, field, document, web) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(ExpectedValue));
        }

        [TestMethod]
        public void GetFormat_TypeCalculatedNumberPercentage_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "0\\%;-##%";
            var field = new ShimSPField()
            {
                TypeGet = () => SPFieldType.Calculated
            }.Instance;
            var document = new XmlDocument();
            var web = new ShimSPWeb
            {
                LocaleGet = () => new CultureInfo("en-US")
            }.Instance;
            ShimXmlNode.AllInstances.FirstChildGet = _ => new ShimXmlNode(new XmlDocument())
            {
                AttributesGet = () => new ShimXmlAttributeCollection
                {
                    ItemOfGetString = name =>
                    {
                        if (name == "ResultType")
                        {
                            return CreateAttribute("Number");
                        }
                        else
                        {
                            return CreateAttribute(bool.TrueString);
                        }
                    }
                }
            };

            // Act
            var result = privateType.InvokeStatic(GetFormatMethodName, field, document, web) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(ExpectedValue));
        }

        [TestMethod]
        public void GetFormat_TypeCalculatedNumber_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = ",0.00000";
            var field = new ShimSPField()
            {
                TypeGet = () => SPFieldType.Calculated
            }.Instance;
            var document = new XmlDocument();
            var web = new ShimSPWeb
            {
                LocaleGet = () => new CultureInfo("en-US")
            }.Instance;
            ShimXmlNode.AllInstances.FirstChildGet = _ => new ShimXmlNode(new XmlDocument())
            {
                AttributesGet = () => new ShimXmlAttributeCollection
                {
                    ItemOfGetString = name =>
                    {
                        if (name == "ResultType")
                        {
                            return CreateAttribute("Number");
                        }
                        else
                        {
                            return CreateAttribute("5");
                        }
                    }
                }
            };

            // Act
            var result = privateType.InvokeStatic(GetFormatMethodName, field, document, web) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(ExpectedValue));
        }

        [TestMethod]
        public void GetParams_Should_ExecuteCorrectly()
        {
            // Arrange
            var fieldList = new List<string>();
            var web = new ShimSPWeb().Instance;
            Shimgetgriditems.AllInstances.getParamsSPWeb = (_, spWeb) => { };
            privateObject.SetFieldOrProperty("aViewFields", new ArrayList
            {
                DummyValue
            });
            privateObject.SetFieldOrProperty("tb", new TimeDebug(string.Empty, string.Empty));
            privateObject.SetFieldOrProperty("StartDateField", StartDateField);
            privateObject.SetFieldOrProperty("DueDateField", DueDateField);
            privateObject.SetFieldOrProperty("ProgressField", ProgressField);
            privateObject.SetFieldOrProperty("view",
                new ShimSPView
                {
                    ViewFieldsGet = () => new ShimSPViewFieldCollection
                    {
                        AddString = field => fieldList.Add(field)
                    }
                }.Instance);

            // Act
            privateObject.Invoke(GetParamsMethodName, web);
            var arrHidden = privateObject.GetFieldOrProperty("arrHidden") as ArrayList;

            // Assert
            this.ShouldSatisfyAllConditions(
                () => arrHidden.ShouldNotBeNull(),
                () => arrHidden.Count.ShouldBeGreaterThan(0),
                () => fieldList.ShouldNotBeEmpty());
        }

        [TestMethod]
        public void GetFieldValue_TypeDateTime_ReturnsExpectedValue()
        {
            // Arrange
            var dummyDate = DateTime.Now;
            var expectedValue = dummyDate.ToString("yyyy-MM-dd HH:mm:ss");
            const string Value = "Value";
            privateObject.SetFieldOrProperty("list", new ShimSPList
            {
                FieldsGet = () => new ShimSPFieldCollection
                {
                    GetFieldByInternalNameString = name => new ShimSPField
                    {
                        TypeGet = () => SPFieldType.DateTime,
                        GetFieldValueString = _ => dummyDate
                    }
                }
            }.Instance);

            // Act
            var result = privateObject.Invoke(GetFieldValueMethodName, DummyValue, Value) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(expectedValue));
        }

        [TestMethod]
        public void GetFieldValue_TypeDateTimeOnError_ReturnsExpectedValue()
        {
            // Arrange
            const string Value = "Value";
            privateObject.SetFieldOrProperty("list", new ShimSPList
            {
                FieldsGet = () => new ShimSPFieldCollection
                {
                    GetFieldByInternalNameString = name => new ShimSPField
                    {
                        TypeGet = () => SPFieldType.DateTime,
                        GetFieldValueString = _ => Value
                    }
                }
            }.Instance);

            // Act
            var result = privateObject.Invoke(GetFieldValueMethodName, DummyValue, Value) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(Value));
        }

        [TestMethod]
        public void GetFieldValue_TypeNumberWithPercentSymbol_ReturnsExpectedValue()
        {
            // Arrange
            const string Value = "100%";
            const string ExpectedValue = "100";
            var numberField = new ShimSPFieldNumber
            {
                ShowAsPercentageGet = () => true
            };
            privateObject.SetFieldOrProperty("list", new ShimSPList
            {
                FieldsGet = () => new ShimSPFieldCollection
                {
                    GetFieldByInternalNameString = name => new ShimSPField(numberField)
                    {
                        TypeGet = () => SPFieldType.Number,
                        GetFieldValueString = _ => Value
                    }
                }
            }.Instance);

            // Act
            var result = privateObject.Invoke(GetFieldValueMethodName, DummyValue, Value) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(ExpectedValue));
        }

        [TestMethod]
        public void GetFieldValue_TypeNumberShowAsPercentage_ReturnsExpectedValue()
        {
            // Arrange
            const string Value = "85";
            const string ExpectedValue = "8500";
            var numberField = new ShimSPFieldNumber
            {
                ShowAsPercentageGet = () => true
            };
            privateObject.SetFieldOrProperty("list", new ShimSPList
            {
                FieldsGet = () => new ShimSPFieldCollection
                {
                    GetFieldByInternalNameString = name => new ShimSPField(numberField)
                    {
                        TypeGet = () => SPFieldType.Number,
                        GetFieldValueString = _ => Value
                    }
                }
            }.Instance);

            // Act
            var result = privateObject.Invoke(GetFieldValueMethodName, DummyValue, Value) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(ExpectedValue));
        }

        [TestMethod]
        public void GetFieldValue_TypeNumber_ReturnsExpectedValue()
        {
            // Arrange
            const string Value = "85";
            const string ExpectedValue = "85";
            var numberField = new ShimSPFieldNumber
            {
                ShowAsPercentageGet = () => false
            };
            privateObject.SetFieldOrProperty("list", new ShimSPList
            {
                FieldsGet = () => new ShimSPFieldCollection
                {
                    GetFieldByInternalNameString = name => new ShimSPField(numberField)
                    {
                        TypeGet = () => SPFieldType.Number,
                        GetFieldValueString = _ => Value
                    }
                }
            }.Instance);

            // Act
            var result = privateObject.Invoke(GetFieldValueMethodName, DummyValue, Value) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(ExpectedValue));
        }

        [TestMethod]
        public void GetFieldValue_TypeCalculatedWithPercentSymbol_ReturnsExpectedValue()
        {
            // Arrange
            const string Value = "100%";
            const string ExpectedValue = "<img src=\"/_layouts/images/100\">";
            var numberField = new ShimSPFieldCalculated
            {
                ShowAsPercentageGet = () => true
            };
            privateObject.SetFieldOrProperty("list", new ShimSPList
            {
                FieldsGet = () => new ShimSPFieldCollection
                {
                    GetFieldByInternalNameString = name => new ShimSPField(numberField)
                    {
                        TypeGet = () => SPFieldType.Calculated,
                        GetFieldValueString = _ => Value,
                        DescriptionGet = () => "Indicator"
                    }
                }
            }.Instance);

            // Act
            var result = privateObject.Invoke(GetFieldValueMethodName, DummyValue, Value) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(ExpectedValue));
        }

        [TestMethod]
        public void GetFieldValue_TypeCalculatedShowAsPercentage_ReturnsExpectedValue()
        {
            // Arrange
            const string Value = "85";
            const string ExpectedValue = "8500";
            var numberField = new ShimSPFieldCalculated
            {
                ShowAsPercentageGet = () => true
            };
            privateObject.SetFieldOrProperty("list", new ShimSPList
            {
                FieldsGet = () => new ShimSPFieldCollection
                {
                    GetFieldByInternalNameString = name => new ShimSPField(numberField)
                    {
                        TypeGet = () => SPFieldType.Calculated,
                        GetFieldValueString = _ => Value,
                    }
                }
            }.Instance);

            // Act
            var result = privateObject.Invoke(GetFieldValueMethodName, DummyValue, Value) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(ExpectedValue));
        }

        [TestMethod]
        public void GetFieldValue_TypeCalculated_ReturnsExpectedValue()
        {
            // Arrange
            const string Value = "85";
            const string ExpectedValue = "85";
            var numberField = new ShimSPFieldCalculated
            {
                ShowAsPercentageGet = () => false
            };
            privateObject.SetFieldOrProperty("list", new ShimSPList
            {
                FieldsGet = () => new ShimSPFieldCollection
                {
                    GetFieldByInternalNameString = name => new ShimSPField(numberField)
                    {
                        TypeGet = () => SPFieldType.Calculated,
                        GetFieldValueString = _ => Value
                    }
                }
            }.Instance);

            // Act
            var result = privateObject.Invoke(GetFieldValueMethodName, DummyValue, Value) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(ExpectedValue));
        }

        [TestMethod]
        public void GetFieldValue_TypeBoolean_Returns1()
        {
            GetFieldValue_TypeBoolean_ReturnsExpectedValue(bool.TrueString, "1");
        }

        [TestMethod]
        public void GetFieldValue_TypeBoolean_Returns0()
        {
            GetFieldValue_TypeBoolean_ReturnsExpectedValue(DummyValue, "0");
        }

        private void GetFieldValue_TypeBoolean_ReturnsExpectedValue(string value, string expectedValue)
        {
            // Arrange
            privateObject.SetFieldOrProperty("list", new ShimSPList
            {
                FieldsGet = () => new ShimSPFieldCollection
                {
                    GetFieldByInternalNameString = name => new ShimSPField
                    {
                        TypeGet = () => SPFieldType.Boolean,
                        GetFieldValueString = _ => value
                    }
                }
            }.Instance);

            // Act
            var result = privateObject.Invoke(GetFieldValueMethodName, DummyValue, value) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(expectedValue));
        }

        [TestMethod]
        public void GetFieldValue_TypeNote_ReturnsExpectedValue()
        {
            // Arrange
            privateObject.SetFieldOrProperty("list", new ShimSPList
            {
                FieldsGet = () => new ShimSPFieldCollection
                {
                    GetFieldByInternalNameString = name => new ShimSPField
                    {
                        TypeGet = () => SPFieldType.Note,
                    }
                }
            }.Instance);

            // Act
            var result = privateObject.Invoke(GetFieldValueMethodName, DummyValue, DummyValue) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(DummyValue));
        }

        [TestMethod]
        public void GetFieldValue_TypeTotalRoolup_ReturnsExpectedValue()
        {
            // Arrange
            privateObject.SetFieldOrProperty("list", new ShimSPList
            {
                FieldsGet = () => new ShimSPFieldCollection
                {
                    GetFieldByInternalNameString = name => new ShimSPField
                    {
                        TypeAsStringGet = () => "TotalRollup",
                        TypeGet = () => SPFieldType.Text,
                        GetFieldValueAsTextObject = valueObject => DummyValue
                    }
                }
            }.Instance);

            // Act
            var result = privateObject.Invoke(GetFieldValueMethodName, DummyValue, DummyValue) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(DummyValue));
        }

        [TestMethod]
        public void GetFieldValue_TypeDefault_ReturnsExpectedValue()
        {
            // Arrange
            privateObject.SetFieldOrProperty("list", new ShimSPList
            {
                FieldsGet = () => new ShimSPFieldCollection
                {
                    GetFieldByInternalNameString = name => new ShimSPField
                    {
                        TypeAsStringGet = () => "TotalRollup",
                        TypeGet = () => SPFieldType.WorkflowStatus,
                        GetFieldValueAsTextObject = valueObject => DummyValue
                    }
                }
            }.Instance);

            // Act
            var result = privateObject.Invoke(GetFieldValueMethodName, DummyValue, DummyValue) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(DummyValue));
        }

        [TestMethod]
        public void GetRealField_Should_ReturnsExpectedResult()
        {
            // Arrange
            var field = new ShimSPField
            {
                TypeGet = () => SPFieldType.Computed,
                SchemaXmlGet = () => DummyValue,
                ParentListGet = () => new ShimSPList
                {
                    FieldsGet = () => new ShimSPFieldCollection
                    {
                        GetFieldByInternalNameString = name => new ShimSPField()
                    }
                }
            }.Instance;
            ShimXmlNode.AllInstances.FirstChildGet = _ => new ShimXmlNode(new XmlDocument())
            {
                AttributesGet = () => new ShimXmlAttributeCollection()
            };
            ShimXmlDocument.AllInstances.LoadXmlString = (_, content) => { };

            // Act
            var result = privateObject.Invoke(GetRealFieldMethodName, field) as SPField;

            // Assert
            result.ShouldNotBeNull();
        }

        private XmlAttribute CreateAttribute(string value, string name = null)
        {
            return new ShimXmlAttribute
            {
                NameGet = () => name ?? DummyValue,
                ValueGet = () => value
            }.Instance;
        }

        private void ValidateExpectedAttributes(
            XmlAttributeCollection attributes, 
            IEnumerable<string> expectedAttributes)
        {
            attributes.ShouldNotBeNull();
            foreach (var attribute in expectedAttributes)
            {
                attributes[attribute].ShouldNotBeNull();
            }
        }

        private XmlNodeList DummyXmlNodeList(int lenght)
        {
            var doc = new XmlDocument();
            doc.AppendChild(doc.CreateElement("root"));
            for (int i = 0; i < lenght; i++)
            {
                var element = doc.CreateElement($"Element{i}");
                element.InnerText = i.ToString();
                doc.FirstChild.AppendChild(element);
            }
            return doc.FirstChild.ChildNodes;
        }

        private XmlNodeList DummyFieldsXmlNodeList()
        {
            var doc = new XmlDocument();
            doc.AppendChild(doc.CreateElement("root"));

            var dueDateField = doc.CreateElement("DueDate");
            var dueDateId = doc.CreateAttribute("id");
            dueDateId.Value = DueDateField;
            dueDateField.Attributes.Append(dueDateId);
            doc.FirstChild.AppendChild(dueDateField);

            var predecessorField = doc.CreateElement("Predecessors");
            var predecessorId = doc.CreateAttribute("id");
            predecessorId.Value = "Predecessors";
            predecessorField.Attributes.Append(predecessorId);
            doc.FirstChild.AppendChild(predecessorField);

            var titleField = doc.CreateElement("Title");
            var titleId = doc.CreateAttribute("id");
            titleId.Value = "Title";
            titleField.Attributes.Append(titleId);
            doc.FirstChild.AppendChild(titleField);

            var stateField = doc.CreateElement("State");
            var stateId = doc.CreateAttribute("id");
            stateId.Value = "State";
            stateField.Attributes.Append(stateId);
            doc.FirstChild.AppendChild(stateField);

            return doc.FirstChild.ChildNodes;
        }

        private XmlNodeList DummyCellsXmlNodeList()
        {
            var doc = new XmlDocument();
            doc.AppendChild(new ShimXmlElement
            {
                NameGet = () => "Root",
                NodeTypeGet = () => XmlNodeType.Element
            });
            doc.FirstChild.AppendChild(new ShimXmlElement
            {
                NameGet = () => "Predecessors",
                InnerTextGet = () => DummyValue,
                NodeTypeGet = () => XmlNodeType.Element,
            });
            doc.FirstChild.AppendChild(new ShimXmlElement()
            {
                NameGet = () => "Title",
                InnerTextGet = () => DummyValue,
                NodeTypeGet = () => XmlNodeType.Element,
            });
            return doc.FirstChild.ChildNodes;
        }
    }
}

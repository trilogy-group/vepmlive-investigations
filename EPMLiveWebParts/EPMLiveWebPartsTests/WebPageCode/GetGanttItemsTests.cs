using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Fakes;
using EPMLiveWebParts.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWebParts.Tests.WebPageCode
{
    using System.Collections.Specialized;
    using EPMLiveCore;
    using Fakes;
    using Microsoft.SharePoint;

    [TestClass]
    public class GetGanttItemsTests
    {
        private IDisposable shimsContext;
        private getganttitems getganttitems;
        private PrivateObject privateObject;
        private string outputXmlMethodName = "outputXml";

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

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            SetupShims();
            getganttitems = new getganttitems();
            privateObject = new PrivateObject(getganttitems);
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
        public void outputXml_Should_ExecuteCorrectly()
        {
            // Arrange
            privateObject.SetFieldOrProperty("gridname", DummyValue);
            privateObject.SetFieldOrProperty("tb", new TimeDebug("", ""));
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
            privateObject.Invoke(outputXmlMethodName);
            var result = privateObject.GetFieldOrProperty("data") as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => expectedContent.ForEach(content => result.ShouldContainWithoutWhitespace(content)));
        }

        [TestMethod]
        public void outputXml_ViewFields_Part1()
        {
            // Arrange
            privateObject.SetFieldOrProperty("gridname", DummyValue);
            privateObject.SetFieldOrProperty("tb", new TimeDebug("", ""));
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
            privateObject.Invoke(outputXmlMethodName);
            var result = privateObject.GetFieldOrProperty("data") as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => expectedContent.ForEach(content => result.ShouldContainWithoutWhitespace(content)));
        }

        [TestMethod]
        public void outputXml_ViewFields_Part2()
        {
            // Arrange
            privateObject.SetFieldOrProperty("gridname", DummyValue);
            privateObject.SetFieldOrProperty("tb", new TimeDebug("", ""));
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
            privateObject.Invoke(outputXmlMethodName);
            var result = privateObject.GetFieldOrProperty("data") as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => expectedContent.ForEach(content => result.ShouldContainWithoutWhitespace(content)));
        }

    }
}

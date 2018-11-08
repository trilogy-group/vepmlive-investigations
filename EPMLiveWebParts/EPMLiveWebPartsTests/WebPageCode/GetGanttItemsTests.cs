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
    using EPMLiveCore;
    using Fakes;

    [TestClass]
    public class GetGanttItemsTests
    {
        private IDisposable shimsContext;
        private getganttitems getganttitems;
        private PrivateObject privateObject;
        private string outputXmlMethodName = "outputXml";
        
        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            getganttitems = new getganttitems();
            privateObject = new PrivateObject(getganttitems);
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }

        [TestMethod]
        public void outputXml()
        {
            // Arrange
            privateObject.SetFieldOrProperty("gridname", "DummyValue");
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
            const string StartDateField = "StartField";
            const string DueDateField = "DueField";
            const string ProgressField = "Progress";
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
            privateObject.SetFieldOrProperty("hshLookupEnums", new Hashtable
            {
                ["DummyKey"] = new ArrayList() { 1, 2 }
            });

            privateObject.SetFieldOrProperty("hshLookupEnumKeys", new Hashtable
            {
                ["DummyKey"] = new ArrayList() { 1, 2 }
            });
            
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


    }
}

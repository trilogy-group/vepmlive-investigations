using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Fakes;
using System.Xml.Linq;
using System.Xml.Linq.Fakes;
using EPMLive.TestFakes.Utility;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using WorkEnginePPM.Fakes;

namespace WorkEnginePPM.Tests.WebServices
{
    [TestClass]
    public class IntegrationGetMissingEventHandlersTests : IntegrationTestsBase
    {
        private const string Xml = @"<FirstChild Key=""001"" EventClass=""Class01""/>";
        private const string BorkedXml = @"<FirstChild Key="""" EventClass=""""/>";
        private const string SettingsString = "DummySetting1,DummySetting2,DummySetting3,DummySetting4";

        private SharepointShims _sharepointShims;
        private AdoShims _adoShims;

        [TestInitialize]
        public override void Setup()
        {
            base.Setup();
            _adoShims = AdoShims.ShimAdoNetCalls();
            _sharepointShims = SharepointShims.ShimSharepointCalls();
        }

        [TestMethod]
        public void GetMissingEventHandlers_ValidInput_NoErrors()
        {
            // Arrange
            ArrangeGetMissingEventHandlers(true, true, true, true, false);

            // Act
            Action action = () => Result = (string)PrivateObject.Invoke("GetMissingEventHandlers", Xml);

            // Assert
            this.ShouldSatisfyAllConditions(
                () =>
                {
                    action.ShouldNotThrow();
                    XmlDocument = XDocument.Parse(Result);
                },
                () => XmlDocument.Descendants("Result")
                                .First()
                                .Attribute("Status")
                                .Value.ShouldBe("0"));
        }

        [TestMethod]
        public void GetMissingEventHandlers_NoConfig_HandlesErrors()
        {
            // Arrange
            ArrangeGetMissingEventHandlers(false, true, true, true, false);

            // Act
            Action action = () => Result = (string)PrivateObject.Invoke("GetMissingEventHandlers", Xml);

            // Assert
            this.ShouldSatisfyAllConditions(
                () =>
                {
                    action.ShouldNotThrow();
                    XmlDocument = XDocument.Parse(Result);
                },
                () => XmlDocument.Descendants("Result")
                                .First()
                                .Attribute("Status")
                                .Value.ShouldBe("1"),
                () => XmlDocument.Descendants("Error")
                                .First()
                                .Value.ShouldContain("No Lists Defined"),
                () => XmlDocument.Descendants("Error")
                                .First()
                                .Attribute("ID")
                                .Value.ShouldContain("102"));
        }

        [TestMethod]
        public void GetMissingEventHandlers_BorkedXml_HandlesErrors()
        {
            // Arrange
            ArrangeGetMissingEventHandlers(true, true, true, true, false);

            // Act
            Action action = () => Result = (string)PrivateObject.Invoke("GetMissingEventHandlers", BorkedXml);

            // Assert
            this.ShouldSatisfyAllConditions(
                () =>
                {
                    action.ShouldNotThrow();
                    XmlDocument = XDocument.Parse(Result);
                },
                () => XmlDocument.Descendants("Result")
                                .First()
                                .Attribute("Status")
                                .Value.ShouldBe("1"),
                () => XmlDocument.Descendants("Error")
                                .First()
                                .Value.ShouldContain("Invalid Key or Event Class Value"),
                () => XmlDocument.Descendants("Error")
                                .First()
                                .Attribute("ID")
                                .Value.ShouldContain("101"));
        }

        [TestMethod]
        public void GetMissingEventHandlers_HandlesExceptions()
        {
            // Arrange
            ArrangeGetMissingEventHandlers(true, true, true, true, true);

            // Act
            Action action = () => Result = (string)PrivateObject.Invoke("GetMissingEventHandlers", Xml);

            // Assert
            this.ShouldSatisfyAllConditions(
                () =>
                {
                    action.ShouldNotThrow();
                    XmlDocument = XDocument.Parse(Result);
                },
                () => XmlDocument.Descendants("Result")
                                .First()
                                .Attribute("Status")
                                .Value.ShouldBe("1"),
                () => XmlDocument.Descendants("Error")
                                .First()
                                .Value.ShouldContain("Exception Handled"),
                () => XmlDocument.Descendants("Error")
                                .First()
                                .Attribute("ID")
                                .Value.ShouldContain("100"));
        }

        [TestMethod]
        public void GetMissingEventHandlers_NoEvent_HandlesErrors()
        {
            // Arrange
            ArrangeGetMissingEventHandlers(true, false, false, false, false);

            // Act
            Action action = () => Result = (string)PrivateObject.Invoke("GetMissingEventHandlers", Xml);

            // Assert
            this.ShouldSatisfyAllConditions(
                () =>
                {
                    action.ShouldNotThrow();
                    XmlDocument = XDocument.Parse(Result);
                },
                () => XmlDocument.Descendants("Result")
                                .First()
                                .Attribute("Status")
                                .Value.ShouldBe("0"),
                () =>
                {
                    XmlDocument.Descendants("Lists")
                              .First()
                              .Value.ShouldContain(SettingsString.Trim(','));
                });
        }

        private void ArrangeGetMissingEventHandlers(
            bool shouldHaveConfig,
            bool shouldAdded,
            bool shouldUpdating,
            bool shouldDeleting,
            bool docLoadShouldThrow)
        {
            ShimConfigFunctions.getConfigSettingSPWebString = (_1, _2) => shouldHaveConfig
                ? SettingsString
                : string.Empty;
            ShimSPSite.AllInstances.AllWebsGet = _ => new ShimSPWebCollection();
            ShimSPWebCollection.AllInstances.CountGet = _ => 1;
            ShimSPWebCollection.AllInstances.ItemGetInt32 = (_1, _2) => _sharepointShims.WebShim;
            ShimSPList.AllInstances.EventReceiversGet = _ => new ShimSPEventReceiverDefinitionCollection();

            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPEventReceiverDefinition>
            {
                new ShimSPEventReceiverDefinition
                {
                    TypeGet = () => SPEventReceiverType.ItemAdded,
                    ClassGet = () => shouldAdded
                        ? "Class01"
                        : string.Empty
                },
                new ShimSPEventReceiverDefinition
                {
                    TypeGet = () => SPEventReceiverType.ItemUpdating,
                    ClassGet = () => shouldUpdating
                        ? "Class01"
                        : string.Empty
                },
                new ShimSPEventReceiverDefinition
                {
                    TypeGet = () => SPEventReceiverType.ItemDeleting,
                    ClassGet = () => shouldDeleting
                        ? "Class01"
                        : string.Empty
                }
            }.GetEnumerator();

            if (docLoadShouldThrow)
            {
                ShimXmlDocument.AllInstances.LoadXmlString = (_1, _2) =>
                {
                    throw new InvalidOperationException("Exception Handled");
                };
            }
        }
    }
}

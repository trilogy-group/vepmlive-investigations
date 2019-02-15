using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Fakes;
using System.Xml.Linq;
using EPMLive.TestFakes.Utility;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using WorkEnginePPM.Fakes;

namespace WorkEnginePPM.Tests.WebServices
{
    [TestClass]
    public class IntegrationDisableEventsTests : IntegrationTestsBase
    {
        private const string Xml = @"<FirstChild Key=""001"" EventClass=""Class01""/>";
        private const string BorkedXml = @"<FirstChild Key="""" EventClass=""""/>";
        private const string SettingsString = "DummySetting1,DummySetting2,DummySetting3,DummySetting4";
        private const string DisableEvents = "DisableEvents";

        private AdoShims _adoShims;
        private SharepointShims _sharepointShims;
        private int _deleteCallCount;
        private int _updateCalledCount;

        [TestInitialize]
        public override void Setup()
        {
            base.Setup();
            _adoShims = AdoShims.ShimAdoNetCalls();
            _sharepointShims = SharepointShims.ShimSharepointCalls();
        }

        [TestMethod]
        public void DisableEvents_ValidInput_NoErrors()
        {
            // Arrange
            ArrangeDisableEvents(
                true,
                true,
                true,
                true,
                false);

            // Act
            Action action = () => Result = (string)PrivateObject.Invoke(DisableEvents, Xml);

            // Assert
            this.ShouldSatisfyAllConditions(
                () =>
                {
                    action.ShouldNotThrow();
                    XmlDocument = XDocument.Parse(Result);
                },
                () => _deleteCallCount.ShouldBe(12),
                () => _updateCalledCount.ShouldBe(4),
                () => XmlDocument.Descendants("Result").First().Attribute("Status").Value.ShouldBe("0"),
                () => XmlDocument.Descendants("Lists").First().Value.ShouldContain(SettingsString));
        }

        [TestMethod]
        public void DisableEvents_NoConfig_HandlesErrors()
        {
            // Arrange
            ArrangeDisableEvents(
                false,
                true,
                true,
                true,
                false);

            // Act
            Action action = () => Result = (string)PrivateObject.Invoke(DisableEvents, Xml);

            // Assert
            this.ShouldSatisfyAllConditions(
                () =>
                {
                    action.ShouldNotThrow();
                    XmlDocument = XDocument.Parse(Result);
                },
                () => XmlDocument.Descendants("Result").First().Attribute("Status").Value.ShouldBe("0"));
        }

        [TestMethod]
        public void DisableEvents_BorkedXml_HandlesErrors()
        {
            // Arrange
            ArrangeDisableEvents(
                true,
                true,
                true,
                true,
                false);

            // Act
            Action action = () => Result = (string)PrivateObject.Invoke(DisableEvents, BorkedXml);

            // Assert
            this.ShouldSatisfyAllConditions(
                () =>
                {
                    action.ShouldNotThrow();
                    XmlDocument = XDocument.Parse(Result);
                },
                () => XmlDocument.Descendants("Result").First().Attribute("Status").Value.ShouldBe("1"),
                () => XmlDocument.Descendants("Error").First().Value.ShouldContain("Invalid Key or Event Class Value"),
                () => XmlDocument.Descendants("Error").First().Attribute("ID").Value.ShouldContain("101"));
        }

        [TestMethod]
        public void DisableEvents_HandlesExceptions()
        {
            // Arrange
            ArrangeDisableEvents(
                true,
                true,
                true,
                true,
                true);

            // Act
            Action action = () => Result = (string)PrivateObject.Invoke(DisableEvents, Xml);

            // Assert
            this.ShouldSatisfyAllConditions(
                () =>
                {
                    action.ShouldNotThrow();
                    XmlDocument = XDocument.Parse(Result);
                },
                () => XmlDocument.Descendants("Result").First().Attribute("Status").Value.ShouldBe("1"),
                () => XmlDocument.Descendants("Error").First().Value.ShouldContain("Exception Handled"),
                () => XmlDocument.Descendants("Error").First().Attribute("ID").Value.ShouldContain("100"));
        }

        [TestMethod]
        public void DisableEvents_NoEvent_NoErrors()
        {
            // Arrange
            ArrangeDisableEvents(
                true,
                false,
                false,
                false,
                false);

            // Act
            Action action = () => Result = (string)PrivateObject.Invoke(DisableEvents, Xml);

            // Assert
            this.ShouldSatisfyAllConditions(
                () =>
                {
                    action.ShouldNotThrow();
                    XmlDocument = XDocument.Parse(Result);
                },
                () => XmlDocument.Descendants("Result").First().Attribute("Status").Value.ShouldBe("0"));
        }

        private void ArrangeDisableEvents(
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
            ShimSPEventReceiverDefinitionCollection.AllInstances.ItemGetGuid = (_1, _2) => new ShimSPEventReceiverDefinition();
            _updateCalledCount = 0;
            ShimSPList.AllInstances.Update = _ => _updateCalledCount++;
            _deleteCallCount = 0;
            ShimSPEventReceiverDefinition.AllInstances.Delete = _ => _deleteCallCount++;

            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPEventReceiverDefinition>
            {
                new ShimSPEventReceiverDefinition
                {
                    TypeGet = () => SPEventReceiverType.ItemAdded,
                    IdGet = () => new Guid("12457845126547841203145201010101"),
                    ClassGet = () => shouldAdded
                        ? "Class01"
                        : string.Empty
                },
                new ShimSPEventReceiverDefinition
                {
                    TypeGet = () => SPEventReceiverType.ItemUpdating,
                    IdGet = () => new Guid("46514080904051230604070105040203"),
                    ClassGet = () => shouldUpdating
                        ? "Class01"
                        : string.Empty
                },
                new ShimSPEventReceiverDefinition
                {
                    TypeGet = () => SPEventReceiverType.ItemDeleting,
                    IdGet = () => new Guid("10451023147050408010406052364785"),
                    ClassGet = () => shouldDeleting
                        ? "Class01"
                        : string.Empty
                }
            }.GetEnumerator();

            if (docLoadShouldThrow)
            {
                ShimXmlDocument.AllInstances.LoadXmlString = (_1, _2) => { throw new InvalidOperationException("Exception Handled"); };
            }
        }
    }
}
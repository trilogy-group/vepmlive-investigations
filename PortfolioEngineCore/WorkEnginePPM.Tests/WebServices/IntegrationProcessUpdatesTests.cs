using System;
using System.Linq;
using System.Xml.Linq;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace WorkEnginePPM.Tests.WebServices
{
    [TestClass]
    public class IntegrationProcessUpdatesTests : IntegrationUpdatesTestsBase
    {
        private const string BorkedXml =
            @"<FirstChild Key="""" EventClass=""Class01"" ID=""41570213647852014741032548741025.45102364102521023175412068945132.201451067""/>
              <Task ItemID=""007"" Status=""1""/>
              </FirstChild>";
        private const string NoKeyXml =
            @"<FirstChild Key="""" EventClass=""Class01"" ID=""41570213647852014741032548741025.45102364102521023175412068945132.201451067"">
                <Task ItemID=""007"" Status=""1""/>
              </FirstChild>";
        private const string ApprovedXml =
            @"<FirstChild Key=""001"" EventClass=""Class01"" ID=""41570213647852014741032548741025.45102364102521023175412068945132.201451067"">
                <Task ItemID=""007"" Status=""1""/>
              </FirstChild>";
        private const string RecusedXml =
            @"<FirstChild Key=""001"" EventClass=""Class01"" ID=""41570213647852014741032548741025.45102364102521023175412068945132.201451067"">
                <Task ItemID=""007"" Status=""0""/>
              </FirstChild>";
        private const string ApprovedString = "Approved";
        private const string RejectedString = "Rejected";
        private const string PubTransUidString = "PUBTRANSUID";
        private const string ProcessUpdatesMethodName = "ProcessUpdates";

        private string _actualApprovalString;
        private string _actualPubTransUidString;
        private string _actualTaskInnerTextString;
        private bool _updateWasCalled;

        [TestMethod]
        public void ProcessUpdates_ValidParameters_ExecutesWithNoErrors()
        {
            // Arrange
            ArrangeProcessUpdates(true, true, true, true, false);

            // Act
            Action action = () => Result = (string)PrivateObject.Invoke(ProcessUpdatesMethodName, ApprovedXml);

            // Assert
            this.ShouldSatisfyAllConditions(
                () =>
                {
                    action.ShouldNotThrow();
                    XmlDocument = XDocument.Parse(Result);
                },
                () => XmlDocument.Descendants("Result").First().Attribute("Status").Value.ShouldBe("0"),
                () => XmlDocument.Descendants("Task").First().Attribute("ID").Value.ShouldBe("007"),
                () => XmlDocument.Descendants("Task").First().Attribute("Status").Value.ShouldBe("0"),
                () => _actualApprovalString.ShouldBe(ApprovedString),
                () => _actualPubTransUidString.ShouldBe(PubTransUidString),
                () => _actualTaskInnerTextString.ShouldBeEmpty(),
                () => _updateWasCalled.ShouldBeTrue());
        }

        [TestMethod]
        public void ProcessUpdates_ValidParametersRecusedXml_ExecutesWithNoErrors()
        {
            // Arrange
            ArrangeProcessUpdates(true, true, true, true, false);

            // Act
            Action action = () => Result = (string)PrivateObject.Invoke(ProcessUpdatesMethodName, RecusedXml);

            // Assert
            this.ShouldSatisfyAllConditions(
                () =>
                {
                    action.ShouldNotThrow();
                    XmlDocument = XDocument.Parse(Result);
                },
                () => XmlDocument.Descendants("Result").First().Attribute("Status").Value.ShouldBe("0"),
                () => XmlDocument.Descendants("Task").First().Attribute("ID").Value.ShouldBe("007"),
                () => XmlDocument.Descendants("Task").First().Attribute("Status").Value.ShouldBe("0"),
                () => _actualApprovalString.ShouldBe(RejectedString),
                () => _actualPubTransUidString.ShouldBe(PubTransUidString),
                () => _actualTaskInnerTextString.ShouldBeEmpty(),
                () => _updateWasCalled.ShouldBeTrue());
        }

        [TestMethod]
        public void ProcessUpdates_ValidParametersNoKeyXml_HandlesErrors()
        {
            // Arrange
            ArrangeProcessUpdates(true, true, true, true, false);

            // Act
            Action action = () => Result = (string)PrivateObject.Invoke(ProcessUpdatesMethodName, NoKeyXml);

            // Assert
            this.ShouldSatisfyAllConditions(
                () =>
                {
                    action.ShouldNotThrow();
                    XmlDocument = XDocument.Parse(Result);
                },
                () => XmlDocument.Descendants("Result").First().Attribute("Status").Value.ShouldBe("1"),
                () => XmlDocument.Descendants("Error").First().Value.ShouldContain("Invalid Key"),
                () => XmlDocument.Descendants("Error").First().Attribute("ID").Value.ShouldBe("100"),
                () => _actualApprovalString.ShouldBeNull(),
                () => _actualPubTransUidString.ShouldBeNull(),
                () => _actualTaskInnerTextString.ShouldBeNull(),
                () => _updateWasCalled.ShouldBeFalse());
        }

        [TestMethod]
        public void ProcessUpdates_BorkedXml_HandlesErrors()
        {
            // Arrange
            ArrangeProcessUpdates(true, true, true, true, true);

            // Act
            Action action = () => Result = (string)PrivateObject.Invoke(ProcessUpdatesMethodName, BorkedXml);

            // Assert
            this.ShouldSatisfyAllConditions(
                () =>
                {
                    action.ShouldNotThrow();
                    XmlDocument = XDocument.Parse(Result);
                },
                () => XmlDocument.Descendants("Result").First().Attribute("Status").Value.ShouldBe("1"),
                () => XmlDocument.Descendants("Error").First().Value.ShouldContain("Exception Handled"),
                () => XmlDocument.Descendants("Error").First().Attribute("ID").Value.ShouldBe("100"),
                () => _actualApprovalString.ShouldBeNull(),
                () => _actualPubTransUidString.ShouldBeNull(),
                () => _actualTaskInnerTextString.ShouldBeNull(),
                () => _updateWasCalled.ShouldBeFalse());
        }

        [TestMethod]
        public void ProcessUpdates_ListUpdateFails_HandlesErrors()
        {
            // Arrange
            ArrangeProcessUpdates(true, true, true, true, false);
            ShimSPListItem.AllInstances.Update = _ =>
            {
                _updateWasCalled = true;
                throw new InvalidOperationException("Update Failed but it was handled");
            };

            // Act
            Action action = () => Result = (string)PrivateObject.Invoke(ProcessUpdatesMethodName, ApprovedXml);

            // Assert
            this.ShouldSatisfyAllConditions(
                () =>
                {
                    action.ShouldNotThrow();
                    XmlDocument = XDocument.Parse(Result);
                },
                () => XmlDocument.Descendants("Result").First().Attribute("Status").Value.ShouldBe("1"),
                () => XmlDocument.Descendants("Task").First().Attribute("ID").Value.ShouldBe("007"),
                () => XmlDocument.Descendants("Task").First().Value.ShouldContain("Update Failed but it was handled"),
                () => XmlDocument.Descendants("Task").First().Attribute("Status").Value.ShouldBe("1"),
                () => _actualApprovalString.ShouldBe(ApprovedString),
                () => _actualPubTransUidString.ShouldBe(PubTransUidString),
                () => _actualTaskInnerTextString.ShouldBeEmpty(),
                () => _updateWasCalled.ShouldBeTrue());
        }

        private void ArrangeProcessUpdates(bool docLoadShouldThrow, bool loadShouldThrow, bool shouldUpdating, bool shouldDeleting, bool shouldThrow)
        {
            ArrangeBaseUpdatesEvents(docLoadShouldThrow, loadShouldThrow, shouldUpdating, shouldDeleting, shouldThrow);
            ShimSPListItem.AllInstances.ItemSetStringObject = (_, str, obj) =>
            {
                switch (str)
                {
                    case "Publisher_x0020_Approval_x0020_S":
                        _actualApprovalString = (string)obj;
                        break;
                    case "Publisher_x0020_Approval_x0020_C":
                        _actualTaskInnerTextString = (string)obj;
                        break;
                    case "PubTransUid":
                        _actualPubTransUidString = (string)obj;
                        break;
                    default:
                        throw new InvalidOperationException("Unexpected Value");
                }
            };
            ShimSPListItem.AllInstances.Update = _ => _updateWasCalled = true;
        }
    }
}
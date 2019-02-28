using System;
using System.Data.Fakes;
using System.Linq;
using System.Xml.Linq;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using WorkEnginePPM.Fakes;

namespace WorkEnginePPM.Tests.WebServices
{
    [TestClass]
    public class IntegrationGetUpdatesTests : IntegrationUpdatesTestsBase
    {
        private const string DummyGuidString = "12457845126547841203145201010101";
        private const string _xml =
            @"<FirstChild Key=""001"" EventClass=""Class01"" ID=""41570213647852014741032548741025.45102364102521023175412068945132.201451067""/>";
        private const string _noKeyXml =
            @"<FirstChild Key="""" EventClass=""Class01"" ID=""41570213647852014741032548741025.45102364102521023175412068945132.201451067""/>";
        private const string GetUpdatesMethodName = "GetUpdates";

        private SPSiteDataQuery _actualQuery;
        private bool _buildTasksWasCalled;
        private XDocument _queryActualQueryDocument;
        private XDocument _queryListsDocument;
        private XDocument _queryViewFieldsDocument;

        [TestMethod]
        public void GetUpdates_ValidInput_NoErrors()
        {
            // Arrange
            ArrangeGetUpdates(true, true, true, true, false);

            // Act
            Action action = () => Result = (string)PrivateObject.Invoke(GetUpdatesMethodName, _xml);

            // Assert
            this.ShouldSatisfyAllConditions(
                () =>
                {
                    action.ShouldNotThrow();
                    XmlDocument = XDocument.Parse(Result);
                    _queryListsDocument = XDocument.Parse(_actualQuery.Lists);
                    _queryActualQueryDocument = XDocument.Parse(_actualQuery.Query);
                    _queryViewFieldsDocument = XDocument.Parse(_actualQuery.ViewFields);
                },
                () => _buildTasksWasCalled.ShouldBeTrue(),
                () => _queryListsDocument.Descendants("List").First().Attribute("ID").Value.ShouldBe(new Guid(DummyGuidString).ToString()),
                () => _queryActualQueryDocument.Descendants("FieldRef").First().Attribute("Name").Value.ShouldBe(SettingsString),
                () => _queryActualQueryDocument.Descendants("FieldRef").First().Attribute("LookupId").Value.ShouldBe(bool.TrueString),
                () => _queryActualQueryDocument.Descendants("Eq").First().Descendants("Value").First().Value.ShouldBe("201451067"),
                () => _queryViewFieldsDocument.Descendants("FieldRef").First().Attribute("Name").Value.ShouldBe("Title"));
        }

        [TestMethod]
        public void GetUpdates_NoKey_HandlesErrors()
        {
            // Arrange
            ArrangeGetUpdates(true, true, true, true, false);

            // Act
            Action action = () => Result = (string)PrivateObject.Invoke(GetUpdatesMethodName, _noKeyXml);

            // Assert
            this.ShouldSatisfyAllConditions(
                () =>
                {
                    action.ShouldNotThrow();
                    XmlDocument = XDocument.Parse(Result);
                },
                () => _buildTasksWasCalled.ShouldBeFalse(),
                () => _actualQuery.ShouldBeNull(),
                () => XmlDocument.Descendants("Result").First().Attribute("Status").Value.ShouldBe("1"),
                () => XmlDocument.Descendants("Error").First().Value.ShouldContain("Invalid Key"),
                () => XmlDocument.Descendants("Error").First().Attribute("ID").Value.ShouldBe("100"));
        }

        [TestMethod]
        public void GetUpdates_Throws_HandlesErrors()
        {
            // Arrange
            ArrangeGetUpdates(true, true, true, true, true);

            // Act
            Action action = () => Result = (string)PrivateObject.Invoke(GetUpdatesMethodName, _noKeyXml);

            // Assert
            this.ShouldSatisfyAllConditions(
                () =>
                {
                    action.ShouldNotThrow();
                    XmlDocument = XDocument.Parse(Result);
                },
                () => _buildTasksWasCalled.ShouldBeFalse(),
                () => _actualQuery.ShouldBeNull(),
                () => XmlDocument.Descendants("Result").First().Attribute("Status").Value.ShouldBe("1"),
                () => XmlDocument.Descendants("Error").First().Value.ShouldContain("Exception Handled"),
                () => XmlDocument.Descendants("Error").First().Attribute("ID").Value.ShouldBe("100"));
        }

        private void ArrangeGetUpdates(bool docLoadShouldThrow, bool loadShouldThrow, bool shouldUpdating, bool shouldDeleting, bool shouldThrow)
        {
            ArrangeBaseUpdatesEvents(docLoadShouldThrow, loadShouldThrow, shouldUpdating, shouldDeleting, shouldThrow);

            ShimSPList.AllInstances.IDGet = _ => new Guid(DummyGuidString);
            _actualQuery = null;
            SharePointShims.WebShim.GetSiteDataSPSiteDataQuery = query =>
            {
                _actualQuery = query;
                return new ShimDataTable();
            };
            _buildTasksWasCalled = false;
            ShimIntegration.AllInstances.buildTasksDataTableHashtableSPList = (_1, _2, _3, _4) =>
            {
                _buildTasksWasCalled = true;
                return string.Empty;
            };
        }
    }
}
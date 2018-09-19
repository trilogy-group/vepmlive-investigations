using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPMLiveWebParts.Fakes;
using EPMLiveWebParts.API.Fakes;
using EPMLiveWebParts.API;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using EPMLiveCore.Fakes;

namespace EPMLiveWebParts.Tests.API
{
    [TestClass, ExcludeFromCodeCoverage]
    public class WPAPITest
    {
        private IDisposable _shimObject;
        private WPAPI _testObj;
        private ShimSPWeb _web;
        private ShimSPSite _site;
        private ShimSPList _list;
        private string _webId;
        private string _siteId;
        private bool _siteCreated;
        private bool _webOpened;
        private bool _gridAPICreated;
        private bool _listItemUpdated;

        private const int DummyInt = 1;
        private const double DummyDouble = 1D;
        private const string DummyString = "DummyString";
        private const string WebId = "4a37915c-8b5a-4d43-8167-b21e08b70461";
        private const string SiteId = "f7a29869-98c9-488b-8365-a4d685639dd0";
        private const string ListId = "3afc34c2-26d2-450d-a956-a7f94b92f1d4";
        private const string ResultForGetGridRow = "<Result Status=\"0\"><![CDATA[<Grid><Changes><I id=\"1\" DummyString=\"1\" HasComments=\"2\" /></Changes></Grid>]]></Result>";

        [TestInitialize]
        public void TestInitialize()
        {
            _siteCreated = false;
            _webOpened = false;
            _gridAPICreated = false;
            _listItemUpdated = false;
            _shimObject = ShimsContext.Create();

            SetupShims();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimObject?.Dispose();
        }

        private void SetupShims()
        {
            _list = new ShimSPList
            {
                TitleGet = () => "Project Center",
                ParentWebGet = () => _web,
                GetItemByIdInt32 = _ => new ShimSPListItem
                {
                    ItemGetGuid = __ => DummyDouble,
                    ItemGetString = item =>
                    {
                        switch (item)
                        {
                            case "CommentCount":
                                return DummyDouble;
                            case "Complete":
                                return true;
                            default:
                                return DummyString;
                        }
                    },
                    ParentListGet = () => _list,
                    FieldsGet = () => new ShimSPFieldCollection
                    {
                        ContainsFieldString = __ => true
                    },
                    Update = () => _listItemUpdated = true
                },
                FieldsGet = () => new ShimSPFieldCollection
                {
                    GetFieldByInternalNameString = _ => new ShimSPFieldNumber().Instance,
                    ContainsFieldWithStaticNameString = _ => true
                }
            };

            _site = new ShimSPSite
            {
                IDGet = () => string.IsNullOrEmpty(_siteId) ? Guid.NewGuid() : new Guid(_siteId)
            };

            _web = new ShimSPWeb
            {
                IDGet = () => string.IsNullOrEmpty(_webId) ? Guid.NewGuid() : new Guid(_webId),
                SiteGet = () => _site.Instance,
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetGuid = _ => _list
                },
                CurrentUserGet = () => new ShimSPUser
                {
                    IDGet = () => DummyInt
                }
            };

            ShimSPSite.ConstructorGuid = (_, __) => _siteCreated = true;
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) =>
            {
                _webOpened = true;
                return _web;
            };
            ShimSPSite.AllInstances.Dispose = _ => { };

            ShimSPWeb.AllInstances.Dispose = _ => { };

            ShimSPField.AllInstances.TypeGet = instance =>
            {
                if (instance is SPFieldNumber)
                {
                    return SPFieldType.Number;
                }

                return SPFieldType.Text;
            };

            ShimSPFieldUserValue.ConstructorSPWebString = (_, __, ___) => { };
            ShimSPFieldLookupValue.AllInstances.LookupIdGet = _ => DummyInt;

            ShimGridAPI.ConstructorStringSPWeb = (_, __, ___) => _gridAPICreated = true;
            ShimGridAPI.AllInstances.ToString01 = _ => DummyString;

            ShimCoreFunctions.getListSettingStringSPList = (_, __) =>
                $"\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\ntrue";
        }

        [TestMethod]
        public void GetGrid_OnValidCall_ConfirmResult()
        {
            // Arrange, Act
            var result = WPAPI.GetGrid(DummyString, _web.Instance);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _gridAPICreated.ShouldBeTrue(),
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(DummyString));
        }

        [TestMethod]
        public void GetGridRow_WhenDifferentSiteId_ConfirmResult()
        {
            // Arrange
            var xmlString = CreateXml();

            // Act
            var result = WPAPI.GetGridRow(xmlString, _web.Instance);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _siteCreated.ShouldBeTrue(),
                () => _webOpened.ShouldBeTrue(),
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(ResultForGetGridRow));
        }

        [TestMethod]
        public void GetGridRow_WhenDifferentWebId_ConfirmResult()
        {
            // Arrange
            var xmlString = CreateXml();
            _siteId = SiteId;

            // Act
            var result = WPAPI.GetGridRow(xmlString, _web.Instance);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _siteCreated.ShouldBeFalse(),
                () => _webOpened.ShouldBeTrue(),
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(ResultForGetGridRow));
        }

        [TestMethod]
        public void GetGridRow_WhenSiteIdAndWebIdAreEqual_ConfirmResult()
        {
            // Arrange
            var xmlString = CreateXml();
            _siteId = SiteId;
            _webId = WebId;

            // Act
            var result = WPAPI.GetGridRow(xmlString, _web.Instance);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _siteCreated.ShouldBeFalse(),
                () => _webOpened.ShouldBeFalse(),
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(ResultForGetGridRow));
        }

        private string CreateXml()
        {
            return $@"
                <Root id='{DummyInt}' webid='{WebId}' siteid='{SiteId}' listid='{ListId}' itemid='{DummyInt}' Cols='{DummyString}'>
                    <Field Name='{DummyString}'>{DummyString}</Field>
                </Root>";
        }

        [TestMethod]
        public void SetGridRowEdit_WhenDifferentSiteId_ConfirmResult()
        {
            // Arrange
            var xmlString = CreateXml();

            // Act
            var result = WPAPI.SetGridRowEdit(xmlString, _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _siteCreated.ShouldBeTrue(),
                () => _webOpened.ShouldBeTrue(),
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(ResultForGetGridRow),
                () => _listItemUpdated.ShouldBeTrue());
        }

        [TestMethod]
        public void SetGridRowEdit_WhenDifferentWebId_ConfirmResult()
        {
            // Arrange
            var xmlString = CreateXml();
            _siteId = SiteId;

            // Act
            var result = WPAPI.SetGridRowEdit(xmlString, _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _siteCreated.ShouldBeFalse(),
                () => _webOpened.ShouldBeTrue(),
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(ResultForGetGridRow),
                () => _listItemUpdated.ShouldBeTrue());
        }

        [TestMethod]
        public void SetGridRowEdit_WhenSiteIdAndWebIdAreEqual_ConfirmResult()
        {
            // Arrange
            var xmlString = CreateXml();
            _siteId = SiteId;
            _webId = WebId;

            // Act
            var result = WPAPI.SetGridRowEdit(xmlString, _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _siteCreated.ShouldBeFalse(),
                () => _webOpened.ShouldBeFalse(),
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(ResultForGetGridRow),
                () => _listItemUpdated.ShouldBeTrue());
        }
    }
}

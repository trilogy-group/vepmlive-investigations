using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using System.Xml;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.WebPageCode
{
    [TestClass, ExcludeFromCodeCoverage]
    public class GetWorkspaceXmlTests
    {
        private IDisposable _shimContext;
        private getworkspacexml _testEntity;
        private PrivateObject _privateObject;

        private const string AddWebsMethodName = "AddWebs";

        private ShimSPWeb _spWeb;
        private XmlDocument _doc;
        private XmlNode _parentNode;
        private const string DummyString = "DummyString";
        private const string DummyTitle = "DummyTitle";
        private const string DummyRelativeUrl = "DummyRelativeUrl";
        private const string DummyServerRelativeUrlForm = "DummyServerRelativeUrlForm";
        private static readonly Guid DummyWebId = new Guid("f66bea96-334f-4704-bba5-0b83d96bc2ff");

        [TestInitialize]
        public void TestInitialize()
        {
            _shimContext = ShimsContext.Create();
            _testEntity = new getworkspacexml();
            _privateObject = new PrivateObject(_testEntity);

            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (sender, permissionMask) => true;
            _spWeb = new ShimSPWeb()
            {
                IDGet = () => DummyWebId,
                TitleGet = () => DummyTitle,
                ServerRelativeUrlGet = () => DummyRelativeUrl
            };

            _doc = new XmlDocument();
            _doc.LoadXml("<rows></rows>");
            _parentNode = _doc.ChildNodes[0];
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimContext?.Dispose();
            _testEntity?.Dispose();
        }

        [TestMethod]
        public void AddWebs_RequestListNull_WriteParentNode()
        {
            // Arrange
            ShimPage.AllInstances.RequestGet = sender => new ShimHttpRequest()
            {
                ItemGetString = itemName => null
            };

            _privateObject.SetField("doc", _doc);

            // Act
            _privateObject.Invoke(AddWebsMethodName, _spWeb.Instance, _parentNode);

            // Assert
            _parentNode.InnerXml.ShouldBe($"<row locked=\"1\" open=\"1\" id=\"{DummyRelativeUrl}\"><userdata /><cell>{DummyTitle}</cell><cell>{DummyRelativeUrl}</cell></row>");
        }

        [TestMethod]
        public void AddWebs_RequestListNotNullHiddenFalseHideNewButton_KeepParentNodeTheSame()
        {
            // Arrange
            ShimPage.AllInstances.RequestGet = sender => new ShimHttpRequest()
            {
                ItemGetString = itemName => DummyString
            };

            _privateObject.SetField("doc", _doc);

            _spWeb.ListsGet = () => new ShimSPListCollection()
            {
                ItemGetString = itemName => new ShimSPList()
                {
                    HiddenGet = () => false
                }
            };

            ShimGridGanttSettings.ConstructorSPList = (sender, spList) =>
            {
                var gridGantt = new ShimGridGanttSettings(sender);
                gridGantt.Instance.HideNewButton = true;
            };

            // Act
            _privateObject.Invoke(AddWebsMethodName, _spWeb.Instance, _parentNode);

            // Assert
            _parentNode.InnerXml.ShouldBeEmpty();
        }

        [TestMethod]
        public void AddWebs_RequestListNotNullHiddenTrue_KeepParentNodeTheSame()
        {
            // Arrange
            ShimPage.AllInstances.RequestGet = sender => new ShimHttpRequest()
            {
                ItemGetString = itemName => DummyString
            };

            _privateObject.SetField("doc", _doc);

            _spWeb.ListsGet = () => new ShimSPListCollection()
            {
                ItemGetString = itemName => new ShimSPList()
                {
                    HiddenGet = () => true
                }
            };

            ShimGridGanttSettings.ConstructorSPList = (sender, spList) =>
            {
                var gridGantt = new ShimGridGanttSettings(sender);
                gridGantt.Instance.HideNewButton = true;
            };

            // Act
            _privateObject.Invoke(AddWebsMethodName, _spWeb.Instance, _parentNode);

            // Assert
            _parentNode.InnerXml.ShouldBeEmpty();
        }

        [TestMethod]
        public void AddWebs_RequestListNotNullHiddenFalse_KeepParentNodeTheSame()
        {
            // Arrange
            ShimPage.AllInstances.RequestGet = sender => new ShimHttpRequest()
            {
                ItemGetString = itemName => DummyString
            };

            _privateObject.SetField("doc", _doc);

            _spWeb.ListsGet = () => new ShimSPListCollection()
            {
                ItemGetString = itemName => new ShimSPList()
                {
                    HiddenGet = () => false,
                    FormsGet = () => new ShimSPFormCollection()
                    {
                        ItemGetPAGETYPE = pageType => new ShimSPForm()
                        {
                            ServerRelativeUrlGet = () => DummyServerRelativeUrlForm
                        }
                    }
                }
            };

            _spWeb.WebsGet = () => new ShimSPWebCollection().Bind(
                new SPWeb[]
                {
                    new ShimSPWeb()
                }.AsEnumerable());

            ShimGridGanttSettings.ConstructorSPList = (sender, spList) =>
            {
                var gridGantt = new ShimGridGanttSettings(sender);
                gridGantt.Instance.HideNewButton = false;
            };

            var expectedResult = new List<string>()
            {
                $"<row locked=\"1\" open=\"1\" id=\"{DummyRelativeUrl}\">",
                $"<userdata name=\"NewItemURL\">{DummyServerRelativeUrlForm}</userdata>",
                "<userdata name=\"CanPublish\">Yes</userdata>",
                $"<cell>{DummyTitle}</cell>",
                $"<cell>{DummyRelativeUrl}</cell>",
                $"<userdata name=\"webid\">{DummyWebId}</userdata></row>"
            };

            // Act
            _privateObject.Invoke(AddWebsMethodName, _spWeb.Instance, _parentNode);

            // Assert
            var actualInnerXml = _parentNode.InnerXml;

            this.ShouldSatisfyAllConditions(
                () => actualInnerXml.ShouldNotBeNullOrEmpty(),
                () => expectedResult.ForEach(c => actualInnerXml.ShouldContain(c)));
        }
    }
}
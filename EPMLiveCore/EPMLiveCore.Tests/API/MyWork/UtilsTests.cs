using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveCore.Tests.API.MyWork
{
    using System.Xml.Linq;
    using System.Xml.Linq.Fakes;
    using EPMLiveCore.API;
    using EPMLiveCore.API.Fakes;
    using Fakes;
    using Microsoft.QualityTools.Testing.Fakes;
    using Microsoft.SharePoint;
    using Microsoft.SharePoint.Fakes;

    [TestClass]
    public class UtilsTests
    {
        private IDisposable shimContext;
        private static readonly Guid DummyGuid = Guid.NewGuid();

        [TestInitialize]
        public void Initialize()
        {
            shimContext = ShimsContext.Create();
            SetupShims();
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimContext?.Dispose();
        }

        private void SetupShims()
        {
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPSite.AllInstances.UrlGet = _ => "DummyUrl";
            ShimSPSite.ConstructorString = (_, url) => { };
            ShimSPSite.AllInstances.OpenWeb = _ => new ShimSPWeb();
            ShimCoreFunctions.getLockedWebSPWeb = _ => DummyGuid;





        }

        [TestMethod]
        public void GetConfigWeb_Should_ReturnSPWeb()
        {
            // Arrange
            ShimUtils.GetConfigWebSPWebGuid = (web, guid) => new ShimSPWeb();

            // Act
            var result = Utils.GetConfigWeb();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ToGridSafeFieldName()
        {
            // Arrange

            // Act
            var result = Utils.ToGridSafeFieldName("Name");
            
            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
        }

        [TestMethod]
        public void AddItemListWebSiteToXElement_Should_AddItems()
        {
            // Arrange
            var element = new ShimXElement().Instance;
            var elementsAdded = new List<object>();
            ShimXContainer.AllInstances.AddObject = (_, newElement) =>
            {
                elementsAdded.Add(newElement);
            };

            // Act
            Utils.AddItemListWebSiteToXElement(1, DummyGuid, DummyGuid, DummyGuid, "DummyUrl", ref element);

            // Assert
            Assert.AreNotEqual(0, elementsAdded.Count);
        }

        [TestMethod]
        public void CleanGuid_Should_ReturnExpectedValue()
        {
            // Arrange
            var expectedValue = DummyGuid.ToString();
            var initialValue = $"{{{DummyGuid}}}";

            // Act
            var result = Utils.CleanGuid(initialValue);

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void GetCleanFieldValue_FieldValueEmpty_ReturnsEmpty()
        {
            // Arrange
            var field = new ShimXElement
            {
                ValueGet = () => string.Empty
            };

            // Act
            var result = Utils.GetCleanFieldValue(field);

            // Assert
            Assert.IsTrue(string.IsNullOrWhiteSpace(result));

        }

        [TestMethod]
        public void GetCleanFieldValue_FormatNoDecimal_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "2";
            var field = new ShimXElement
            {
                ValueGet = () => "2.00",
                AttributeXName = name =>
                {
                    switch (name.LocalName)
                    {
                        case "Format":
                            return new XAttribute("Format", "NoDecimal");
                        case "Type":
                            return new XAttribute("Type", "Number");
                        default:
                            return null;
                    }
                }
            };

            // Act
            var result = Utils.GetCleanFieldValue(field);

            // Assert
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod]
        public void GetCleanFieldValue_FormatTwoDecimal_ReturnsExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "2.00";
            var field = new ShimXElement
            {
                ValueGet = () => "2.00",
                AttributeXName = name =>
                {
                    switch (name.LocalName)
                    {
                        case "Format":
                            return new XAttribute("Format", "TwoDecimal");
                        case "Type":
                            return new XAttribute("Type", "Number");
                        default:
                            return null;
                    }
                }
            };

            // Act
            var result = Utils.GetCleanFieldValue(field);

            // Assert
            Assert.AreEqual(ExpectedValue, result);
        }



    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EPMLiveCore.SalesforceMetadataService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Web_References.SalesforceMetadataService
{
    /// <summary>
    /// Unit Tests for <see cref="EPMLiveCore.SalesforceMetadataService.WebLink"/>
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class WebLinkTest
    {
        private PrivateObject _privateObject;
        private WebLink _testEntity;
        private const string DummyString = "DummyString";

        [TestInitialize]
        public void SetUp()
        {
            _testEntity = new WebLink();
            _privateObject = new PrivateObject(_testEntity);
        }

        [TestMethod]
        public void Properties_TestGetterAndSetter()
        {
            // Arrange
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["availability"] = new WebLinkAvailability(),
                ["description"] = DummyString,
                ["displayType"] = new WebLinkDisplayType(),
                ["encodingKey"] = new Encoding(),
                ["encodingKeySpecified"] = true,
                ["hasMenubar"] = true,
                ["hasMenubarSpecified"] = true,
                ["hasScrollbars"] = true,
                ["hasScrollbarsSpecified"] = true,
                ["hasToolbar"] = true,
                ["hasToolbarSpecified"] = true,
                ["height"] = new int(),
                ["heightSpecified"] = true,
                ["isResizable"] = true,
                ["isResizableSpecified"] = true,
                ["linkType"] = new WebLinkType(),
                ["masterLabel"] = DummyString,
                ["openType"] = new WebLinkWindowType(),
                ["page"] = DummyString,
                ["position"] = new WebLinkPosition(),
                ["positionSpecified"] = true,
                ["protected"] = true,
                ["requireRowSelection"] = true,
                ["requireRowSelectionSpecified"] = true,
                ["scontrol"] = DummyString,
                ["showsLocation"] = true,
                ["showsLocationSpecified"] = true,
                ["showsStatus"] = true,
                ["showsStatusSpecified"] = true,
                ["url"] = DummyString,
                ["width"] = new int(),
                ["widthSpecified"] = true,
            };

            // Act
            foreach (var kvp in propertiesDictionary)
            {
                _privateObject.SetProperty(kvp.Key, kvp.Value);
            }

            // Assert
            var assertions = new List<Action>();
            foreach (var kvp in propertiesDictionary)
            {
                assertions.Add(() => _privateObject.GetProperty(kvp.Key).ShouldBe(kvp.Value));
            }
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }
    }
}
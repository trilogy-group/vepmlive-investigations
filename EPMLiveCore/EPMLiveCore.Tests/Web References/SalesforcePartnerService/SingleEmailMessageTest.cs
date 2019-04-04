using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EPMLiveCore.SalesforcePartnerService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Web_References.SalesforcePartnerService
{
    /// <summary>
    /// Unit Tests for <see cref="EPMLiveCore.SalesforcePartnerService.SingleEmailMessage"/>
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class SingleEmailMessageTest
    {
        private PrivateObject _privateObject;
        private SingleEmailMessage _testEntity;
        private const string DummyString = "DummyString";

        [TestInitialize]
        public void SetUp()
        {
            _testEntity = new SingleEmailMessage();
            _privateObject = new PrivateObject(_testEntity);
        }

        [TestMethod]
        public void Properties_TestGetterAndSetter()
        {
            // Arrange
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["bccAddresses"] = new string[] { },
                ["ccAddresses"] = new string[] { },
                ["charset"] = DummyString,
                ["documentAttachments"] = new string[] { },
                ["htmlBody"] = DummyString,
                ["inReplyTo"] = DummyString,
                ["fileAttachments"] = new EmailFileAttachment[] { },
                ["orgWideEmailAddressId"] = DummyString,
                ["plainTextBody"] = DummyString,
                ["references"] = DummyString,
                ["targetObjectId"] = DummyString,
                ["templateId"] = DummyString,
                ["toAddresses"] = new string[] { },
                ["whatId"] = DummyString,
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

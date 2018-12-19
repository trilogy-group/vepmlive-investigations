using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EPMLiveCore.SalesforceMetadataService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Web_References.SalesforceMetadataService
{
    /// <summary>
    /// Unit Tests for <see cref="EPMLiveCore.SalesforceMetadataService.CustomSite"/>
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class CustomSiteTest
    {
        private PrivateObject _privateObject;
        private CustomSite _testEntity;
        private const string DummyString = "DummyString";

        [TestInitialize]
        public void SetUp()
        {
            _testEntity = new CustomSite();
            _privateObject = new PrivateObject(_testEntity);
        }

        [TestMethod]
        public void Properties_TestGetterAndSetter()
        {
            // Arrange
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["active"] = true,
                ["allowHomePage"] = true,
                ["allowStandardAnswersPages"] = true,
                ["allowStandardAnswersPagesSpecified"] = true,
                ["allowStandardIdeasPages"] = true,
                ["allowStandardLookups"] = true,
                ["allowStandardSearch"] = true,
                ["analyticsTrackingCode"] = DummyString,
                ["authorizationRequiredPage"] = DummyString,
                ["bandwidthExceededPage"] = DummyString,
                ["changePasswordPage"] = DummyString,
                ["chatterAnswersForgotPasswordConfirmPage"] = DummyString,
                ["chatterAnswersForgotPasswordPage"] = DummyString,
                ["chatterAnswersHelpPage"] = DummyString,
                ["chatterAnswersLoginPage"] = DummyString,
                ["chatterAnswersRegistrationPage"] = DummyString,
                ["customWebAddresses"] = new SiteWebAddress[] { },
                ["description"] = DummyString,
                ["favoriteIcon"] = DummyString,
                ["fileNotFoundPage"] = DummyString,
                ["genericErrorPage"] = DummyString,
                ["guestProfile"] = DummyString,
                ["inMaintenancePage"] = DummyString,
                ["inactiveIndexPage"] = DummyString,
                ["indexPage"] = DummyString,
                ["masterLabel"] = DummyString,
                ["myProfilePage"] = DummyString,
                ["portal"] = DummyString,
                ["requireInsecurePortalAccess"] = true,
                ["robotsTxtPage"] = DummyString,
                ["rootComponent"] = DummyString,
                ["serverIsDown"] = DummyString,
                ["siteAdmin"] = DummyString,
                ["siteRedirectMappings"] = new SiteRedirectMapping[] { },
                ["siteTemplate"] = DummyString,
                ["siteType"] = new SiteType(),
                ["subdomain"] = DummyString,
                ["urlPathPrefix"] = DummyString,
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
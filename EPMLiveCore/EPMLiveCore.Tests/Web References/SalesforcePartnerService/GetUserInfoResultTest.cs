using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EPMLiveCore.SalesforcePartnerService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Web_References.SalesforcePartnerService
{
    /// <summary>
    /// Unit Tests for <see cref="EPMLiveCore.SalesforcePartnerService.GetUserInfoResult"/>
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class GetUserInfoResultTest
    {
        private PrivateObject _privateObject;
        private GetUserInfoResult _testEntity;
        private const string DummyString = "DummyString";
        private const int DummyInt = 1;

        [TestInitialize]
        public void SetUp()
        {
            _testEntity = new GetUserInfoResult();
            _privateObject = new PrivateObject(_testEntity);
        }

        [TestMethod]
        public void Properties_TestGetterAndSetter()
        {
            // Arrange
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["accessibilityMode"] = true,
                ["currencySymbol"] = DummyString,
                ["orgAttachmentFileSizeLimit"] = DummyInt,
                ["orgDefaultCurrencyIsoCode"] = DummyString,
                ["orgDisallowHtmlAttachments"] = true,
                ["orgHasPersonAccounts"] = true,
                ["organizationId"] = DummyString,
                ["organizationMultiCurrency"] = true,
                ["organizationName"] = DummyString,
                ["profileId"] = DummyString,
                ["roleId"] = DummyString,
                ["sessionSecondsValid"] = DummyInt,
                ["userDefaultCurrencyIsoCode"] = DummyString,
                ["userEmail"] = DummyString,
                ["userFullName"] = DummyString,
                ["userId"] = DummyString,
                ["userLanguage"] = DummyString,
                ["userLocale"] = DummyString,
                ["userName"] = DummyString,
                ["userTimeZone"] = DummyString,
                ["userType"] = DummyString,
                ["userUiSkin"] = DummyString,
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

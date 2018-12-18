using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EPMLiveCore.SalesforceMetadataService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Web_References.SalesforceMetadataService
{
    /// <summary>
    /// Unit Tests for <see cref="EPMLiveCore.SalesforceMetadataService.SessionSettings"/>
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class SessionSettingsTest
    {
        private PrivateObject _privateObject;
        private SessionSettings _testEntity;

        [TestInitialize]
        public void SetUp()
        {
            _testEntity = new SessionSettings();
            _privateObject = new PrivateObject(_testEntity);
        }

        [TestMethod]
        public void Properties_TestGetterAndSetter()
        {
            // Arrange
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["disableTimeoutWarning"] = true,
                ["disableTimeoutWarningSpecified"] = true,
                ["enableCSRFOnGet"] = true,
                ["enableCSRFOnGetSpecified"] = true,
                ["enableCSRFOnPost"] = true,
                ["enableCSRFOnPostSpecified"] = true,
                ["enableCacheAndAutocomplete"] = true,
                ["enableCacheAndAutocompleteSpecified"] = true,
                ["enableClickjackNonsetupSFDC"] = true,
                ["enableClickjackNonsetupSFDCSpecified"] = true,
                ["enableClickjackNonsetupUser"] = true,
                ["enableClickjackNonsetupUserSpecified"] = true,
                ["enableClickjackSetup"] = true,
                ["enableClickjackSetupSpecified"] = true,
                ["enableSMSIdentity"] = true,
                ["enableSMSIdentitySpecified"] = true,
                ["forceRelogin"] = true,
                ["forceReloginSpecified"] = true,
                ["lockSessionsToIp"] = true,
                ["lockSessionsToIpSpecified"] = true,
                ["sessionTimeout"] = new SessionTimeout(),
                ["sessionTimeoutSpecified"] = true,
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
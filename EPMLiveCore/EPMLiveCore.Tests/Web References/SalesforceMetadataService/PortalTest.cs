using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EPMLiveCore.SalesforceMetadataService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Web_References.SalesforceMetadataService
{
    /// <summary>
    /// Unit Tests for <see cref="EPMLiveCore.SalesforceMetadataService.Portal"/>
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class PortalTest
    {
        private PrivateObject _privateObject;
        private Portal _testEntity;
        private const string DummyString = "DummyString";

        [TestInitialize]
        public void SetUp()
        {
            _testEntity = new Portal();
            _privateObject = new PrivateObject(_testEntity);
        }

        [TestMethod]
        public void Properties_TestGetterAndSetter()
        {
            // Arrange
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["active"] = true,
                ["admin"] = DummyString,
                ["defaultLanguage"] = DummyString,
                ["description"] = DummyString,
                ["emailSenderAddress"] = DummyString,
                ["emailSenderName"] = DummyString,
                ["enableSelfCloseCase"] = true,
                ["enableSelfCloseCaseSpecified"] = true,
                ["footerDocument"] = DummyString,
                ["forgotPassTemplate"] = DummyString,
                ["headerDocument"] = DummyString,
                ["isSelfRegistrationActivated"] = true,
                ["isSelfRegistrationActivatedSpecified"] = true,
                ["loginHeaderDocument"] = DummyString,
                ["logoDocument"] = DummyString,
                ["logoutUrl"] = DummyString,
                ["newCommentTemplate"] = DummyString,
                ["newPassTemplate"] = DummyString,
                ["newUserTemplate"] = DummyString,
                ["ownerNotifyTemplate"] = DummyString,
                ["selfRegNewUserUrl"] = DummyString,
                ["selfRegUserDefaultProfile"] = DummyString,
                ["selfRegUserDefaultRole"] = new PortalRoles(),
                ["selfRegUserDefaultRoleSpecified"] = true,
                ["selfRegUserTemplate"] = DummyString,
                ["showActionConfirmation"] = true,
                ["showActionConfirmationSpecified"] = true,
                ["stylesheetDocument"] = DummyString,
                ["type"] = new PortalType(),
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
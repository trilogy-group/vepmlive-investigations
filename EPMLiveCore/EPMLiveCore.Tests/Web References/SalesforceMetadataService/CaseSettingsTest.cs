using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EPMLiveCore.SalesforceMetadataService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Web_References.SalesforceMetadataService
{
    /// <summary>
    /// Unit Tests for <see cref="EPMLiveCore.SalesforceMetadataService.CaseSettings"/>
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class CaseSettingsTest
    {
        private PrivateObject _privateObject;
        private CaseSettings _testEntity;
        private const string DummyString = "DummyString";

        [TestInitialize]
        public void SetUp()
        {
            _testEntity = new CaseSettings();
            _privateObject = new PrivateObject(_testEntity);
        }

        [TestMethod]
        public void Properties_TestGetterAndSetter()
        {
            // Arrange
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["caseAssignNotificationTemplate"] = DummyString,
                ["caseCloseNotificationTemplate"] = DummyString,
                ["caseCommentNotificationTemplate"] = DummyString,
                ["caseCreateNotificationTemplate"] = DummyString,
                ["closeCaseThroughStatusChange"] = true,
                ["closeCaseThroughStatusChangeSpecified"] = true,
                ["defaultCaseOwner"] = DummyString,
                ["defaultCaseOwnerType"] = DummyString,
                ["defaultCaseUser"] = DummyString,
                ["emailToCase"] = new EmailToCaseSettings(),
                ["enableCaseFeed"] = true,
                ["enableCaseFeedSpecified"] = true,
                ["enableDraftEmails"] = true,
                ["enableDraftEmailsSpecified"] = true,
                ["enableEarlyEscalationRuleTriggers"] = true,
                ["enableEarlyEscalationRuleTriggersSpecified"] = true,
                ["enableNewEmailDefaultTemplate"] = true,
                ["enableNewEmailDefaultTemplateSpecified"] = true,
                ["enableSuggestedArticlesApplication"] = true,
                ["enableSuggestedArticlesApplicationSpecified"] = true,
                ["enableSuggestedArticlesCustomerPortal"] = true,
                ["enableSuggestedArticlesCustomerPortalSpecified"] = true,
                ["enableSuggestedArticlesPartnerPortal"] = true,
                ["enableSuggestedArticlesPartnerPortalSpecified"] = true,
                ["enableSuggestedSolutions"] = true,
                ["enableSuggestedSolutionsSpecified"] = true,
                ["keepRecordTypeOnAssignmentRule"] = true,
                ["keepRecordTypeOnAssignmentRuleSpecified"] = true,
                ["newEmailDefaultTemplateClass"] = DummyString,
                ["notifyContactOnCaseComment"] = true,
                ["notifyContactOnCaseCommentSpecified"] = true,
                ["notifyDefaultCaseOwner"] = true,
                ["notifyDefaultCaseOwnerSpecified"] = true,
                ["notifyOwnerOnCaseComment"] = true,
                ["notifyOwnerOnCaseCommentSpecified"] = true,
                ["notifyOwnerOnCaseOwnerChange"] = true,
                ["notifyOwnerOnCaseOwnerChangeSpecified"] = true,
                ["showFewerCloseActions"] = true,
                ["showFewerCloseActionsSpecified"] = true,
                ["useSystemEmailAddress"] = true,
                ["useSystemEmailAddressSpecified"] = true,
                ["webToCase"] = new WebToCaseSettings(),
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
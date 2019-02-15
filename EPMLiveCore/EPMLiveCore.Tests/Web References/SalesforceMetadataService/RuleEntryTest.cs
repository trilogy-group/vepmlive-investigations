using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EPMLiveCore.SalesforceMetadataService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Web_References.SalesforceMetadataService
{
    /// <summary>
    /// Unit Tests for <see cref="EPMLiveCore.SalesforceMetadataService.RuleEntry"/>
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class RuleEntryTest
    {
        private PrivateObject _privateObject;
        private RuleEntry _testEntity;
        private const string DummyString = "DummyString";
        private const int DummyInt = 1;

        [TestInitialize]
        public void SetUp()
        {
            _testEntity = new RuleEntry();
            _privateObject = new PrivateObject(_testEntity);
        }

        [TestMethod]
        public void Properties_TestGetterAndSetter()
        {
            // Arrange
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["assignedTo"] = DummyString,
                ["assignedToType"] = new AssignToLookupValueType(),
                ["assignedToTypeSpecified"] = true,
                ["booleanFilter"] = DummyString,
                ["businessHours"] = DummyString,
                ["businessHoursSource"] = new BusinessHoursSourceType(),
                ["businessHoursSourceSpecified"] = true,
                ["criteriaItems"] = new FilterItem[] { },
                ["disableEscalationWhenModified"] = true,
                ["disableEscalationWhenModifiedSpecified"] = true,
                ["escalationAction"] = new EscalationAction[] { },
                ["escalationStartTime"] = new EscalationStartTimeType(),
                ["escalationStartTimeSpecified"] = true,
                ["formula"] = DummyString,
                ["overrideExistingTeams"] = true,
                ["overrideExistingTeamsSpecified"] = true,
                ["replyToEmail"] = DummyString,
                ["senderEmail"] = DummyString,
                ["senderName"] = DummyString,
                ["team"] = new string[] { },
                ["template"] = DummyString,
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
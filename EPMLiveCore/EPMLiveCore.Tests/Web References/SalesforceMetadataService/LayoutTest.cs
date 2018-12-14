using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EPMLiveCore.SalesforceMetadataService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Web_References.SalesforceMetadataService
{
    /// <summary>
    /// Unit Tests for <see cref="EPMLiveCore.SalesforceMetadataService.Layout"/>
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class LayoutTest
    {
        private PrivateObject _privateObject;
        private Layout _testEntity;
        private const string DummyString = "DummyString";

        [TestInitialize]
        public void SetUp()
        {
            _testEntity = new Layout();
            _privateObject = new PrivateObject(_testEntity);
        }

        [TestMethod]
        public void Properties_TestGetterAndSetter()
        {
            // Arrange
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["customButtons"] = new string[] { },
                ["customConsoleComponents"] = new CustomConsoleComponents(),
                ["emailDefault"] = true,
                ["emailDefaultSpecified"] = true,
                ["excludeButtons"] = new string[] { },
                ["headers"] = new LayoutHeader[] { },
                ["layoutSections"] = new LayoutSection[] { },
                ["miniLayout"] = new MiniLayout(),
                ["multilineLayoutFields"] = new string[] { },
                ["relatedLists"] = new RelatedListItem[] { },
                ["relatedObjects"] = new string[] { },
                ["runAssignmentRulesDefault"] = true,
                ["runAssignmentRulesDefaultSpecified"] = true,
                ["showEmailCheckbox"] = true,
                ["showEmailCheckboxSpecified"] = true,
                ["showHighlightsPanel"] = true,
                ["showHighlightsPanelSpecified"] = true,
                ["showInteractionLogPanel"] = true,
                ["showInteractionLogPanelSpecified"] = true,
                ["showKnowledgeComponent"] = true,
                ["showKnowledgeComponentSpecified"] = true,
                ["showRunAssignmentRulesCheckbox"] = true,
                ["showRunAssignmentRulesCheckboxSpecified"] = true,
                ["showSolutionSection"] = true,
                ["showSolutionSectionSpecified"] = true,
                ["showSubmitAndAttachButton"] = true,
                ["showSubmitAndAttachButtonSpecified"] = true,
                ["summaryLayout"] = new SummaryLayout(),
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
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EPMLiveCore.SalesforceMetadataService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Web_References.SalesforceMetadataService
{
    /// <summary>
    /// Unit Tests for <see cref="EPMLiveCore.SalesforceMetadataService.CustomObject"/>
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class CustomObjectTest
    {
        private PrivateObject _privateObject;
        private CustomObject _testEntity;
        private readonly string DummyString = "DummyString";

        [TestInitialize]
        public void SetUp()
        {
            _testEntity = new CustomObject();
            _privateObject = new PrivateObject(_testEntity);
        }

        [TestMethod]
        public void Properties_TestGetterAndSetter()
        {
            // Arrange
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["actionOverrides"] = new ActionOverride[] { },
                ["articleTypeChannelDisplay"] = new ArticleTypeTemplate[] { },
                ["businessProcesses"] = new BusinessProcess[] { },
                ["customHelp"] = DummyString,
                ["customHelpPage"] = DummyString,
                ["customSettingsType"] = new CustomSettingsType(),
                ["customSettingsTypeSpecified"] = true,
                ["customSettingsVisibility"] = new CustomSettingsVisibility(),
                ["customSettingsVisibilitySpecified"] = true,
                ["deploymentStatus"] = new DeploymentStatus(),
                ["deploymentStatusSpecified"] = true,
                ["deprecated"] = true,
                ["deprecatedSpecified"] = true,
                ["description"] = DummyString,
                ["enableActivities"] = true,
                ["enableActivitiesSpecified"] = true,
                ["enableDivisions"] = true,
                ["enableDivisionsSpecified"] = true,
                ["enableEnhancedLookup"] = true,
                ["enableEnhancedLookupSpecified"] = true,
                ["enableFeeds"] = true,
                ["enableFeedsSpecified"] = true,
                ["enableHistory"] = true,
                ["enableHistorySpecified"] = true,
                ["enableReports"] = true,
                ["enableReportsSpecified"] = true,
                ["fieldSets"] = new FieldSet[] { },
                ["fields"] = new CustomField[] { },
                ["gender"] = new Gender(),
                ["genderSpecified"] = true,
                ["household"] = true,
                ["householdSpecified"] = true,
                ["label"] = DummyString,
                ["listViews"] = new ListView[] { },
                ["nameField"] = new CustomField(),
                ["namedFilters"] = new NamedFilter[] { },
                ["pluralLabel"] = DummyString,
                ["recordTypeTrackFeedHistory"] = true,
                ["recordTypeTrackFeedHistorySpecified"] = true,
                ["recordTypeTrackHistory"] = true,
                ["recordTypeTrackHistorySpecified"] = true,
                ["recordTypes"] = new RecordType[] { },
                ["searchLayouts"] = new SearchLayouts(),
                ["sharingModel"] = new SharingModel(),
                ["sharingModelSpecified"] = true,
                ["sharingReasons"] = new SharingReason[] { },
                ["sharingRecalculations"] = new SharingRecalculation[] { },
                ["startsWith"] = new StartsWith(),
                ["startsWithSpecified"] = true,
                ["validationRules"] = new ValidationRule[] { },
                ["webLinks"] = new WebLink[] { },
            };

            // Act
            foreach (KeyValuePair<string, object> kvp in propertiesDictionary)
            {
                _privateObject.SetProperty(kvp.Key, kvp.Value);
            }

            // Assert
            var assertions = new List<Action>();
            foreach (KeyValuePair<string, object> kvp in propertiesDictionary)
            {
                assertions.Add(() => _privateObject.GetProperty(kvp.Key).ShouldBe(kvp.Value));
            }
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }
    }
}

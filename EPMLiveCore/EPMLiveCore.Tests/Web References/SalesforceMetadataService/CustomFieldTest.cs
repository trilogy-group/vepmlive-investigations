using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EPMLiveCore.SalesforceMetadataService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Web_References.SalesforceMetadataService
{
    /// <summary>
    /// Unit Tests for <see cref="EPMLiveCore.SalesforceMetadataService.CustomField"/>
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class CustomFieldTest
    {
        private PrivateObject _privateObject;
        private CustomField _testEntity;
        private const string DummyString = "DummyString";
        private const int DummyInt = 1;

        [TestInitialize]
        public void SetUp()
        {
            _testEntity = new CustomField();
            _privateObject = new PrivateObject(_testEntity);
        }

        [TestMethod]
        public void Properties_TestGetterAndSetter()
        {
            // Arrange
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["caseSensitive"] = true,
                ["caseSensitiveSpecified"] = true,
                ["customDataType"] = DummyString,
                ["defaultValue"] = DummyString,
                ["deleteConstraint"] = new DeleteConstraint(),
                ["deleteConstraintSpecified"] = true,
                ["deprecated"] = true,
                ["deprecatedSpecified"] = true,
                ["description"] = DummyString,
                ["displayFormat"] = DummyString,
                ["escapeMarkup"] = true,
                ["escapeMarkupSpecified"] = true,
                ["externalDeveloperName"] = DummyString,
                ["externalId"] = true,
                ["externalIdSpecified"] = true,
                ["formula"] = DummyString,
                ["formulaTreatBlanksAs"] = new TreatBlanksAs(),
                ["formulaTreatBlanksAsSpecified"] = true,
                ["inlineHelpText"] = DummyString,
                ["isFilteringDisabled"] = true,
                ["isFilteringDisabledSpecified"] = true,
                ["isNameField"] = true,
                ["isNameFieldSpecified"] = true,
                ["isSortingDisabled"] = true,
                ["isSortingDisabledSpecified"] = true,
                ["label"] = DummyString,
                ["length"] = DummyInt,
                ["lengthSpecified"] = true,
                ["maskChar"] = new EncryptedFieldMaskChar(),
                ["maskCharSpecified"] = true,
                ["maskType"] = new EncryptedFieldMaskType(),
                ["maskTypeSpecified"] = true,
                ["picklist"] = new Picklist(),
                ["populateExistingRows"] = true,
                ["populateExistingRowsSpecified"] = true,
                ["precision"] = DummyInt,
                ["precisionSpecified"] = true,
                ["referenceTo"] = DummyString,
                ["relationshipLabel"] = DummyString,
                ["relationshipName"] = DummyString,
                ["relationshipOrder"] = DummyInt,
                ["relationshipOrderSpecified"] = true,
                ["reparentableMasterDetail"] = true,
                ["reparentableMasterDetailSpecified"] = true,
                ["required"] = true,
                ["requiredSpecified"] = true,
                ["restrictedAdminField"] = true,
                ["restrictedAdminFieldSpecified"] = true,
                ["scale"] = DummyInt,
                ["scaleSpecified"] = true,
                ["startingNumber"] = DummyInt,
                ["startingNumberSpecified"] = true,
                ["stripMarkup"] = true,
                ["stripMarkupSpecified"] = true,
                ["summarizedField"] = DummyString,
                ["summaryFilterItems"] = new FilterItem[] { },
                ["summaryForeignKey"] = DummyString,
                ["summaryOperation"] = new SummaryOperations(),
                ["summaryOperationSpecified"] = true,
                ["trackFeedHistory"] = true,
                ["trackFeedHistorySpecified"] = true,
                ["trackHistory"] = true,
                ["trackHistorySpecified"] = true,
                ["type"] = new FieldType(),
                ["unique"] = true,
                ["uniqueSpecified"] = true,
                ["visibleLines"] = DummyInt,
                ["visibleLinesSpecified"] = true,
                ["writeRequiresMasterRead"] = true,
                ["writeRequiresMasterReadSpecified"] = true,
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
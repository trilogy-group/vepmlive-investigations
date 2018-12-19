using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EPMLiveCore.SalesforcePartnerService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Web_References.SalesforcePartnerService
{
    /// <summary>
    /// Unit Tests for <see cref="EPMLiveCore.SalesforcePartnerService.Field"/>
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class FieldTest
    {
        private PrivateObject _privateObject;
        private Field _testEntity;
        private const string DummyString = "DummyString";
        private const int DummyInt = 1;

        [TestInitialize]
        public void SetUp()
        {
            _testEntity = new Field();
            _privateObject = new PrivateObject(_testEntity);
        }

        [TestMethod]
        public void Properties_TestGetterAndSetter()
        {
            // Arrange
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["autoNumber"] = true,
                ["byteLength"] = DummyInt,
                ["calculated"] = true,
                ["calculatedFormula"] = DummyString,
                ["cascadeDelete"] = true,
                ["cascadeDeleteSpecified"] = true,
                ["caseSensitive"] = true,
                ["controllerName"] = DummyString,
                ["createable"] = true,
                ["custom"] = true,
                ["defaultValueFormula"] = DummyString,
                ["defaultedOnCreate"] = true,
                ["dependentPicklist"] = true,
                ["dependentPicklistSpecified"] = true,
                ["deprecatedAndHidden"] = true,
                ["digits"] = DummyInt,
                ["displayLocationInDecimal"] = true,
                ["displayLocationInDecimalSpecified"] = true,
                ["externalId"] = true,
                ["externalIdSpecified"] = true,
                ["filterable"] = true,
                ["groupable"] = true,
                ["htmlFormatted"] = true,
                ["htmlFormattedSpecified"] = true,
                ["idLookup"] = true,
                ["inlineHelpText"] = DummyString,
                ["label"] = DummyString,
                ["length"] = DummyInt,
                ["name"] = DummyString,
                ["nameField"] = true,
                ["namePointing"] = true,
                ["namePointingSpecified"] = true,
                ["nillable"] = true,
                ["permissionable"] = true,
                ["picklistValues"] = new PicklistEntry[] { },
                ["precision"] = DummyInt,
                ["referenceTo"] = new string[] { },
                ["relationshipName"] = DummyString,
                ["relationshipOrder"] = DummyInt,
                ["relationshipOrderSpecified"] = true,
                ["restrictedDelete"] = true,
                ["restrictedDeleteSpecified"] = true,
                ["restrictedPicklist"] = true,
                ["scale"] = DummyInt,
                ["soapType"] = new soapType(),
                ["sortable"] = true,
                ["sortableSpecified"] = true,
                ["type"] = new fieldType(),
                ["unique"] = true,
                ["updateable"] = true,
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

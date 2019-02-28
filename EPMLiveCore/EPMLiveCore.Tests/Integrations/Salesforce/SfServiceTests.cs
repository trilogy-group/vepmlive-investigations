using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Fakes;
using System.Net.Fakes;
using System.Xml;
using System.Xml.Fakes;
using EPMLiveCore.Integrations.Salesforce;
using EPMLiveCore.Integrations.Salesforce.Fakes;
using EPMLiveCore.SalesforcePartnerService;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Integrations.Salesforce
{
    [TestClass]
    public class SfServiceTests
    {
        private IDisposable shimsContext;
        private SfService sfService;
        private const string DummyString = "DummyString";
        private const string DateField = "DateField";
        private const string PercentField = "PercentField";
        private const string TimeField = "TimeField";
        private const string LookupField = "LookupField";
        private const string ReferenceField = "ReferenceField";

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            SetupShims();
            sfService = new SfService(DummyString, DummyString, DummyString, true);
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }

        private void SetupShims()
        {
            ShimWebClient.AllInstances.UploadValuesStringStringNameValueCollection = 
                (_, address, method, data) => null;
            ShimSfMedadataService.ConstructorStringStringStringStringBoolean = 
                (_, username, password, token, namespaceApp, sandbox) => { };
        }

        [TestMethod]
        public void UpsertItems_Should_ExecuteCorrectly()
        {
            // Arrange
            const string DummyId = "2";
            const double Percent = 19.6;
            const string ExpectedDateValue = "2018-01-01";
            const string ExpectedTimeValue = "10:50:47";
            var ExpectedPercentValue = Percent / 100;
            var dateValue = string.Empty;
            var timeValue = string.Empty;
            var lookupValue = new object();
            var percentValue = 0D;
            var referenceValue = string.Empty;
            var dtItems = new ShimDataTable
            {
                ColumnsGet = () => 
                {
                    var list = new List<DataColumn>
                    {
                        new DataColumn("DummyId")
                    };
                    return new ShimDataColumnCollection().Bind(list);
                },
                RowsGet = () => new ShimDataRowCollection
                {
                    GetEnumerator = () => new List<DataRow>
                    {
                        new ShimDataRow
                        {
                            ItemGetString = name => 
                            {
                                switch (name)
                                {
                                    case DateField:
                                        return "01/01/2018";
                                    case PercentField:
                                        return Percent;
                                    case TimeField:
                                        return "10:50:47";
                                    case LookupField:
                                        return "Dummy;#";
                                    case ReferenceField:
                                        return "jack@doe.com";
                                    default:
                                        return "john@doe.com,mary@doe.com";
                                }
                            }
                        }
                    }.GetEnumerator()
                }
            };
            ShimSfService.AllInstances.LookupItemExistsStringString = (_, itemId, objectName) => false;
            ShimDataColumnCollection.AllInstances.ContainsString = (_, name) => true;
            ShimSfMedadataService.AllInstances.GetFieldsString = (_, anm) => new Field[]
            {
                new Field
                {
                    name = "PercentField",
                    type = fieldType.percent
                },
                new Field
                {
                    name = "DateField",
                    type = fieldType.date
                },
                new Field
                {
                    name = "TimeField",
                    type = fieldType.time
                },
                new Field
                {
                    name = "ReferenceField",
                    type = fieldType.reference,
                    referenceTo = new string[] { "User" }
                },
                new Field
                {
                    name = "LookupField",
                    type = fieldType.reference,
                    referenceTo = new string[] { DummyString }
                }
            };
            ShimSfMedadataService.AllInstances.ExecuteQueryString = (_, query) => new List<sObject>
            {
                new sObject()
                {
                    Id = DummyId,
                    Any = new XmlElement[]
                    {
                        new ShimXmlElement(),
                        new ShimXmlElement
                        {
                            InnerTextGet = () => "jack@doe.com"
                        },
                        new ShimXmlElement
                        {
                            InnerTextGet = () => "user@doe.com"
                        },
                        new ShimXmlElement
                        {
                            InnerTextGet = () => DummyString
                        }
                    }
                }
            };
            ShimSfMedadataService.AllInstances.UpsertItemsStringDataTableBoolean = 
                (_, objectName, items, liveId) => new List<Dictionary<UpsertKind, SaveResult>>
                {
                    new Dictionary<UpsertKind, SaveResult>
                    {
                        [UpsertKind.INSERT] = new SaveResult()
                    }
                };
            ShimDataRow.AllInstances.ItemSetStringObject = (_, itemName, objectValue) =>
            {
                switch (itemName)
                {
                    case DateField:
                        dateValue = objectValue?.ToString();
                        break;
                    case PercentField:
                        percentValue = ((double?)objectValue).GetValueOrDefault(0);
                        break;
                    case TimeField:
                        timeValue = objectValue?.ToString();
                        break;
                    case LookupField:
                        lookupValue = objectValue;
                        break;
                    case ReferenceField:
                        referenceValue = objectValue?.ToString();
                        break;
                    default:
                        break;
                }
            };

            // Act
            var result = sfService.UpsertItems(DummyString, dtItems);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldNotBeEmpty(),
                () => dateValue.ShouldBe(ExpectedDateValue),
                () => timeValue.ShouldBe(ExpectedTimeValue),
                () => lookupValue.ShouldBeNull(),
                () => percentValue.ShouldBe(ExpectedPercentValue),
                () => referenceValue.ShouldBe(DummyId));
        }
    }
}

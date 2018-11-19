using System;
using System.Collections.Generic;
using System.Collections.Generic.Fakes;
using System.Data;
using System.Data.Fakes;
using System.Diagnostics.CodeAnalysis;
using EPMLiveCore.API.Fakes;
using EPMLiveWorkPlanner.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWorkPlanner.Tests.Jobs
{
    [TestClass, ExcludeFromCodeCoverage]
    public class ListImportJobTests
    {
        private IDisposable _shimContext;
        private ListImportJob _testEntity;

        private static readonly DateTime DummyDateTime = new DateTime(2018, 1, 1, 0, 0, 0);
        private const string DummyString = "DummyString";
        private const double DummyDouble = 10.20;
        private const int DummyInt = 1;
        private const int DummyId = 5;
        private const string DummyListField = "DummyListField";
        private const string PlannerField = "PlannerField";
        private const string DummyTitle = "DummyTitle";
        private static readonly Guid DummyGuid = new Guid("6452bd43-ada2-4246-8f8b-1f4fcab2c87a");
        private static readonly Guid DummyGuidParentList = new Guid("6452bd43-ada3-4246-8f8b-1f4fcab2c87a");
        private static readonly Guid DummyGuidListItem = new Guid("6452bd43-ada4-4246-8f8b-1f4fcab2c87a");
        private const string DummyListProjectCenter = "DummyListProjectCenter";
        private const string DummyListTaskCenter = "DummyListTaskCenter";
        private const string DummyInternalName = "DummyInternalName";

        [TestInitialize]
        public void TestInitialize()
        {
            _shimContext = ShimsContext.Create();
            _testEntity = new ListImportJob();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimContext?.Dispose();
        }

        [TestMethod]
        public void GetFieldValue_TypeDateTimeValueValid_ReturnsString()
        {
            // Arrange
            var listItem = new ShimSPListItem()
            {
                ItemGetGuid = guid => DummyDateTime
            };
            var field = new ShimSPField()
            {
                TypeGet = () => SPFieldType.DateTime,
                DescriptionGet = () => string.Empty
            };
            var dataSetResources = new ShimDataSet();

            // Act
            var actualResult = _testEntity.getFieldValue(listItem, field, dataSetResources);

            // Assert
            actualResult.ShouldBe(DummyDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        [TestMethod]
        public void GetFieldValue_TypeDateTimeValueInvalid_ReturnsStringEmpty()
        {
            // Arrange
            var listItem = new ShimSPListItem()
            {
                ItemGetGuid = guid => null
            };
            var field = new ShimSPField()
            {
                TypeGet = () => SPFieldType.DateTime,
                DescriptionGet = () => string.Empty
            };
            var dataSetResources = new ShimDataSet();

            // Act
            var actualResult = _testEntity.getFieldValue(listItem, field, dataSetResources);

            // Assert
            actualResult.ShouldBe(string.Empty);
        }

        [TestMethod]
        public void GetFieldValue_TypeUserValueValid_ReturnsString()
        {
            // Arrange
            var listItem = new ShimSPListItem()
            {
                ItemGetGuid = guid => DummyString,
                ParentListGet = () => new ShimSPList()
                {
                    ParentWebGet = () => new ShimSPWeb()
                }
            };
            var field = new ShimSPField()
            {
                TypeGet = () => SPFieldType.User,
                DescriptionGet = () => string.Empty
            };

            var dataTable = new DataTable();
            dataTable.Columns.Add("SPAccountInfo");
            dataTable.Columns.Add("ID");
            var dataRow = dataTable.NewRow();
            dataRow[0] = DummyInt;
            dataRow[1] = DummyId;
            dataTable.Rows.Add(dataRow);

            var dataSetResources = new ShimDataSet()
            {
                TablesGet = () => new ShimDataTableCollection()
                {
                    ItemGetInt32 = pos => dataTable
                }
            };

            ShimSPFieldLookupValue.AllInstances.ToString01 = sender => DummyInt.ToString();

            ShimSPFieldUserValueCollection.ConstructorSPWebString = (sender, web, fieldValue) => new ShimList<SPFieldUserValue>(new ShimSPFieldUserValueCollection(sender))
            {
                GetEnumerator = () => new List<SPFieldUserValue>()
                {
                    new ShimSPFieldUserValue()
                }.GetEnumerator()
            };

            // Act
            var actualResult = _testEntity.getFieldValue(listItem, field, dataSetResources);

            // Assert
            actualResult.ShouldBe(DummyId.ToString());
        }

        [TestMethod]
        public void GetFieldValue_TypeNoteValueValid_ReturnsString()
        {
            // Arrange
            var listItem = new ShimSPListItem()
            {
                ItemGetGuid = guid => DummyString
            };
            var field = new ShimSPField()
            {
                TypeGet = () => SPFieldType.Note,
                DescriptionGet = () => string.Empty
            };
            var dataSetResources = new ShimDataSet();

            // Act
            var actualResult = _testEntity.getFieldValue(listItem, field, dataSetResources);

            // Assert
            actualResult.ShouldBe(DummyString);
        }

        [TestMethod]
        public void GetFieldValue_TypeNoteValueInvalid_ReturnsStringEmpty()
        {
            // Arrange
            var listItem = new ShimSPListItem()
            {
                ItemGetGuid = guid => null
            };
            var field = new ShimSPField()
            {
                TypeGet = () => SPFieldType.Note,
                DescriptionGet = () => string.Empty
            };
            var dataSetResources = new ShimDataSet();

            // Act
            var actualResult = _testEntity.getFieldValue(listItem, field, dataSetResources);

            // Assert
            actualResult.ShouldBe(string.Empty);
        }

        [TestMethod]
        public void GetFieldValue_TypeCalculatedTypeNumberValueValid_ReturnsString()
        {
            // Arrange
            var listItem = new ShimSPListItem()
            {
                ItemGetGuid = guid => "0;#300"
            };

            var field = new ShimSPField(
                new ShimSPFieldCalculated()
                {
                    OutputTypeGet = () => SPFieldType.Number
                })
            {
                TypeGet = () => SPFieldType.Calculated,
                DescriptionGet = () => string.Empty
            };
            var dataSetResources = new ShimDataSet();

            // Act
            var actualResult = _testEntity.getFieldValue(listItem, field, dataSetResources);

            // Assert
            actualResult.ShouldBe("300");
        }

        [TestMethod]
        public void GetFieldValue_TypeCalculatedTypeIntegerValueValid_ReturnsString()
        {
            // Arrange
            var listItem = new ShimSPListItem()
            {
                ItemGetGuid = guid => DummyInt
            };

            var field = new ShimSPField(
                new ShimSPFieldCalculated()
                {
                    OutputTypeGet = () => SPFieldType.Integer,
                    GetFieldValueAsTextObject = objValue => DummyInt.ToString()
                })
            {
                TypeGet = () => SPFieldType.Calculated,
                DescriptionGet = () => string.Empty
            };
            var dataSetResources = new ShimDataSet();

            // Act
            var actualResult = _testEntity.getFieldValue(listItem, field, dataSetResources);

            // Assert
            actualResult.ShouldBe(DummyInt.ToString());
        }

        [TestMethod]
        public void GetFieldValue_TypeNumberValueValid_ReturnsString()
        {
            // Arrange
            var listItem = new ShimSPListItem()
            {
                ItemGetGuid = guid => DummyInt
            };

            var field = new ShimSPField(
                new ShimSPFieldNumber()
                {
                    ShowAsPercentageGet = () => false
                })
            {
                TypeGet = () => SPFieldType.Number,
                DescriptionGet = () => string.Empty
            };
            var dataSetResources = new ShimDataSet();

            // Act
            var actualResult = _testEntity.getFieldValue(listItem, field, dataSetResources);

            // Assert
            actualResult.ShouldBe(DummyInt.ToString());
        }

        [TestMethod]
        public void GetFieldValue_TypeNumberShowAsPercentageValueValid_ReturnsString()
        {
            // Arrange
            var listItem = new ShimSPListItem()
            {
                ItemGetGuid = guid => DummyInt
            };
            var field = new ShimSPField(
                new ShimSPFieldNumber()
                {
                    ShowAsPercentageGet = () => true
                })
            {
                TypeGet = () => SPFieldType.Number,
                DescriptionGet = () => string.Empty
            };
            var dataSetResources = new ShimDataSet();

            // Act
            var actualResult = _testEntity.getFieldValue(listItem, field, dataSetResources);

            // Assert
            actualResult.ShouldBe("100");
        }

        [TestMethod]
        public void GetFieldValue_TypeNumberShowAsPercentageValueInvalid_ReturnsStringEmpty()
        {
            // Arrange
            var listItem = new ShimSPListItem()
            {
                ItemGetGuid = guid => DummyString
            };
            var field = new ShimSPField(
                new ShimSPFieldNumber()
                {
                    ShowAsPercentageGet = () => true
                })
            {
                TypeGet = () => SPFieldType.Number,
                DescriptionGet = () => string.Empty
            };
            var dataSetResources = new ShimDataSet();

            // Act
            var actualResult = _testEntity.getFieldValue(listItem, field, dataSetResources);

            // Assert
            actualResult.ShouldBe(DummyString);
        }

        [TestMethod]
        public void GetFieldValue_TypeCurrencyValueValid_ReturnsString()
        {
            // Arrange
            var listItem = new ShimSPListItem()
            {
                ItemGetGuid = guid => DummyDouble
            };
            var field = new ShimSPField()
            {
                TypeGet = () => SPFieldType.Currency,
                DescriptionGet = () => string.Empty
            };
            var dataSetResources = new ShimDataSet();

            // Act
            var actualResult = _testEntity.getFieldValue(listItem, field, dataSetResources);

            // Assert
            actualResult.ShouldBe(DummyDouble.ToString());
        }

        [TestMethod]
        public void GetFieldValue_TypeCurrencyValueInvalid_ReturnsStringEmpty()
        {
            // Arrange
            var listItem = new ShimSPListItem()
            {
                ItemGetGuid = guid => null
            };
            var field = new ShimSPField()
            {
                TypeGet = () => SPFieldType.Currency,
                DescriptionGet = () => string.Empty
            };
            var dataSetResources = new ShimDataSet();

            // Act
            var actualResult = _testEntity.getFieldValue(listItem, field, dataSetResources);

            // Assert
            actualResult.ShouldBe(string.Empty);
        }

        [TestMethod]
        public void GetFieldValue_TypeLookupValueValid_ReturnsString()
        {
            // Arrange
            var listItem = new ShimSPListItem()
            {
                ItemGetGuid = guid => DummyString
            };
            var field = new ShimSPField()
            {
                TypeGet = () => SPFieldType.Lookup,
                DescriptionGet = () => string.Empty
            };
            var dataSetResources = new ShimDataSet();

            ShimSPFieldLookupValueCollection.ConstructorString = (sender, fieldValue) => new ShimList<SPFieldLookupValue>(new ShimSPFieldLookupValueCollection(sender))
            {
                GetEnumerator = () => new List<SPFieldLookupValue>()
                {
                    new ShimSPFieldLookupValue
                    {
                        LookupIdGet = () => 1
                    },
                    new ShimSPFieldLookupValue
                    {
                        LookupIdGet = () => 2
                    }
                }.GetEnumerator()
            };

            // Act
            var actualResult = _testEntity.getFieldValue(listItem, field, dataSetResources);

            // Assert
            actualResult.ShouldBe("1;2");
        }

        [TestMethod]
        public void GetFieldValue_TypeLookupValueInvalid_ReturnsStringEmpty()
        {
            // Arrange
            var listItem = new ShimSPListItem()
            {
                ItemGetGuid = guid => null
            };
            var field = new ShimSPField()
            {
                TypeGet = () => SPFieldType.Lookup,
                DescriptionGet = () => string.Empty
            };
            var dataSetResources = new ShimDataSet();

            // Act
            var actualResult = _testEntity.getFieldValue(listItem, field, dataSetResources);

            // Assert
            actualResult.ShouldBe(string.Empty);
        }

        [TestMethod]
        public void GetFieldValue_TypeBooleanValueTrue_ReturnsStringOne()
        {
            // Arrange
            var listItem = new ShimSPListItem()
            {
                ItemGetGuid = guid => "true"
            };
            var field = new ShimSPField()
            {
                TypeGet = () => SPFieldType.Boolean,
                DescriptionGet = () => string.Empty
            };
            var dataSetResources = new ShimDataSet();

            // Act
            var actualResult = _testEntity.getFieldValue(listItem, field, dataSetResources);

            // Assert
            actualResult.ShouldBe("1");
        }

        [TestMethod]
        public void GetFieldValue_TypeBooleanValueDifferentTrue_ReturnsStringZero()
        {
            // Arrange
            var listItem = new ShimSPListItem()
            {
                ItemGetGuid = guid => "f4lse"
            };
            var field = new ShimSPField()
            {
                TypeGet = () => SPFieldType.Boolean,
                DescriptionGet = () => string.Empty
            };
            var dataSetResources = new ShimDataSet();

            // Act
            var actualResult = _testEntity.getFieldValue(listItem, field, dataSetResources);

            // Assert
            actualResult.ShouldBe("0");
        }

        [TestMethod]
        public void GetFieldValue_TypeBooleanValueInvalid_ReturnsStringZero()
        {
            // Arrange
            var listItem = new ShimSPListItem()
            {
                ItemGetGuid = guid => null
            };
            var field = new ShimSPField()
            {
                TypeGet = () => SPFieldType.Boolean,
                DescriptionGet = () => string.Empty
            };
            var dataSetResources = new ShimDataSet();

            // Act
            var actualResult = _testEntity.getFieldValue(listItem, field, dataSetResources);

            // Assert
            actualResult.ShouldBe("0");
        }

        [TestMethod]
        public void GetFieldValue_TypeTextValueValidDescriptionIndicator_ReturnsString()
        {
            // Arrange
            var listItem = new ShimSPListItem()
            {
                ItemGetGuid = guid => DummyString,
                ParentListGet = () => new ShimSPList()
                {
                    ParentWebGet = () => new ShimSPWeb()
                    {
                        ServerRelativeUrlGet = () => string.Empty
                    }
                }
            };
            var field = new ShimSPField()
            {
                TypeGet = () => SPFieldType.Text,
                DescriptionGet = () => "Indicator",
                GetFieldValueAsTextObject = objValue => DummyString
            };
            var dataSetResources = new ShimDataSet();

            // Act
            var actualResult = _testEntity.getFieldValue(listItem, field, dataSetResources);

            // Assert
            actualResult.ShouldBe("<img src=\"/_layouts/images/DummyString\">");
        }

        [TestMethod]
        public void GetFieldValue_TypeTextValueInvalid_ReturnsString()
        {
            // Arrange
            var listItem = new ShimSPListItem()
            {
                ItemGetGuid = guid => null
            };
            var field = new ShimSPField()
            {
                TypeGet = () => SPFieldType.Text,
                DescriptionGet = () => string.Empty
            };
            var dataSetResources = new ShimDataSet();

            // Act
            var actualResult = _testEntity.getFieldValue(listItem, field, dataSetResources);

            // Assert
            actualResult.ShouldBe(string.Empty);
        }

        [TestMethod]
        public void Execute_ListNull_FillErrorString()
        {
            // Arrange
            var data = $@"<Data List=""{DummyString}""><Columns><Column ListField=""{DummyListField}"" PlannerField=""{PlannerField}""></Column></Columns></Data>";

            var site = new ShimSPSite();
            var web = new ShimSPWeb()
            {
                ListsGet = () => new ShimSPListCollection()
                {
                    TryGetListString = listTitle => null
                }
            };

            // Act
            _testEntity.execute(site, web, data);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _testEntity.sErrors.ShouldBe("List could not be found."),
                () => _testEntity.bErrors.ShouldBeTrue());
        }

        [TestMethod]
        public void Execute_LisFoundedAttachedItemOnlyTruePlannerNotFound_FillErrorString()
        {
            // Arrange
            var data = $@"<Data List=""{DummyString}""><Columns><Column ListField=""{DummyListField}"" PlannerField=""{PlannerField}""></Column></Columns></Data>";

            var spList = new ShimSPList()
            {
                TitleGet = () => DummyListProjectCenter,
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    ContainsFieldString = fieldName => true
                },
                GetItemsSPQuery = query => new ShimSPListItemCollection().Bind(
                    new SPListItem[]
                    {
                        new ShimSPListItem()
                        {
                            ParentListGet = () => new ShimSPList()
                            {
                                IDGet = () => DummyGuidParentList,
                                FieldsGet = () => new ShimSPFieldCollection().Bind(
                                    new SPField[]
                                    {
                                        new ShimSPField()
                                        {
                                            ReorderableGet = () => true,
                                            InternalNameGet = () => DummyInternalName
                                        },
                                        new ShimSPField()
                                        {
                                            ReorderableGet = () => true,
                                            InternalNameGet = () => DummyListField
                                        }
                                    })
                            },
                            IDGet = () => DummyId
                        }
                    })
            };

            ShimSPQuery.Constructor = sender => new ShimSPQuery();

            var site = new ShimSPSite();
            var web = new ShimSPWeb()
            {
                ListsGet = () => new ShimSPListCollection()
                {
                    TryGetListString = listTitle => spList,
                    ItemGetString = itemName => new ShimSPList()
                    {
                        IDGet = () => DummyGuid
                    }
                }
            };

            var plannerProps = new ShimWorkPlannerAPI.ShimPlannerProps();

            plannerProps.Instance.sListProjectCenter = DummyListProjectCenter;
            plannerProps.Instance.sListTaskCenter = DummyListTaskCenter;

            ShimWorkPlannerAPI.getSettingsSPWebString = (oWeb, sPlanner) => plannerProps;
            ShimWorkPlannerAPI.GetResourceTableWorkPlannerAPIPlannerPropsGuidStringSPWeb = (props, listId, itemId, webParam) => new ShimDataSet();

            ShimWorkPlannerAPI.GetTasksXmlDocumentSPWeb = (dataPlanInfo, webParam) => "<xmlcfg><I id=\"1\" Predecessors=\"Predecessors;myString\" Descendants=\"Descendants;myString\" /></xmlcfg>";

            ShimBaseJob.AllInstances.updateProgressSingle = (sender, newCount) => { };

            // Act
            _testEntity.execute(site, web, data);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _testEntity.sErrors.ShouldBe("<Result Status=\"1\">Planner Not Specified</Result>"),
                () => _testEntity.bErrors.ShouldBeTrue());
        }

        [TestMethod]
        public void Execute_LisFoundedAttachedItemOnlyFalsePlannerNotFound_FillErrorString()
        {
            // Arrange
            var data = $@"<Data List=""{DummyString}"" AttachedItemsOnly=""false""><Columns><Column ListField=""{DummyListField}"" PlannerField=""{PlannerField}""></Column></Columns></Data>";

            var spList = new ShimSPList()
            {
                TitleGet = () => DummyListTaskCenter,
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    ContainsFieldString = fieldName => true
                },
                ItemsGet = () => new ShimSPListItemCollection().Bind(
                    new SPListItem[]
                    {
                        new ShimSPListItem()
                        {
                            ParentListGet = () => new ShimSPList()
                            {
                                IDGet = () => DummyGuidParentList,
                                FieldsGet = () => new ShimSPFieldCollection().Bind(
                                    new SPField[]
                                    {
                                        new ShimSPField()
                                        {
                                            ReorderableGet = () => true,
                                            InternalNameGet = () => DummyInternalName
                                        },
                                        new ShimSPField()
                                        {
                                            ReorderableGet = () => true,
                                            InternalNameGet = () => DummyListField
                                        }
                                    })
                            },
                            IDGet = () => DummyId
                        }
                    })
            };

            ShimSPQuery.Constructor = sender => new ShimSPQuery();

            var site = new ShimSPSite();
            var web = new ShimSPWeb()
            {
                ListsGet = () => new ShimSPListCollection()
                {
                    TryGetListString = listTitle => spList,
                    ItemGetString = itemName => new ShimSPList()
                    {
                        IDGet = () => DummyGuid
                    }
                }
            };

            var plannerProps = new ShimWorkPlannerAPI.ShimPlannerProps();

            plannerProps.Instance.sListProjectCenter = DummyListProjectCenter;
            plannerProps.Instance.sListTaskCenter = DummyListTaskCenter;

            ShimWorkPlannerAPI.getSettingsSPWebString = (oWeb, sPlanner) => plannerProps;
            ShimWorkPlannerAPI.GetResourceTableWorkPlannerAPIPlannerPropsGuidStringSPWeb = (props, listId, itemId, webParam) => new ShimDataSet();

            ShimWorkPlannerAPI.GetTasksXmlDocumentSPWeb = (dataPlanInfo, webParam) => "<xmlcfg><I id=\"1\" Predecessors=\"Predecessors;myString\" Descendants=\"Descendants;myString\" /></xmlcfg>";

            ShimBaseJob.AllInstances.updateProgressSingle = (sender, newCount) => { };

            // Act
            _testEntity.execute(site, web, data);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _testEntity.sErrors.ShouldBe("<Result Status=\"1\">Planner Not Specified</Result>"),
                () => _testEntity.bErrors.ShouldBeTrue());
        }

        [TestMethod]
        public void Execute_NoPlannerSpecified_FillErrorString()
        {
            // Arrange
            var data = $@"<Data List=""{DummyString}"" AttachedItemsOnly=""false""><Columns><Column ListField=""{DummyListField}"" PlannerField=""{PlannerField}""></Column></Columns></Data>";

            var site = new ShimSPSite();
            var web = new ShimSPWeb()
            {
                ListsGet = () => new ShimSPListCollection()
                {
                    ItemGetString = itemName => new ShimSPList()
                    {
                        IDGet = () => DummyGuid
                    }
                }
            };

            _testEntity.key = string.Empty;

            // Act
            _testEntity.execute(site, web, data);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _testEntity.sErrors.ShouldBe("No Planner Specified"),
                () => _testEntity.bErrors.ShouldBeTrue());
        }

        [TestMethod]
        public void Execute_NoListSpecified_FillErrorString()
        {
            // Arrange
            var data = $@"<Data AttachedItemsOnly=""false""><Columns><Column ListField=""{DummyListField}"" PlannerField=""{PlannerField}"" ></Column></Columns></Data>";

            var site = new ShimSPSite();
            var web = new ShimSPWeb()
            {
                ListsGet = () => new ShimSPListCollection()
                {
                    ItemGetString = itemName => new ShimSPList()
                    {
                        IDGet = () => DummyGuid
                    }
                }
            };

            // Act
            _testEntity.execute(site, web, data);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _testEntity.sErrors.ShouldBe("No List Specified"),
                () => _testEntity.bErrors.ShouldBeTrue());
        }

        [TestMethod]
        public void Execute_FailLoadXml_FillErrorString()
        {
            // Arrange
            var data = string.Empty;
            var site = new ShimSPSite();
            var web = new ShimSPWeb();

            // Act
            _testEntity.execute(site, web, data);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _testEntity.sErrors.ShouldContain("Error importing list: "),
                () => _testEntity.bErrors.ShouldBeTrue());
        }
    }
}
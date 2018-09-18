using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Fakes;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.IO.Fakes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Fakes;
using DocumentFormat.OpenXml.Packaging.Fakes;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Spreadsheet.Fakes;
using EPMLiveCore.API;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.Infrastructure.Fakes;
using EPMLiveCore.Jobs;
using EPMLiveCore.Jobs.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.API.ResourceGrid
{
    [TestClass, ExcludeFromCodeCoverage]
    public class ResourceImporterTests
    {
        private IDisposable _shimObject;
        private ResourceImporter _testObj;
        private PrivateObject _privateObj;
        private ShimSPWeb _web;
        private bool _fileDeleted;

        private const int DummyInt = 1;
        private const string DummyString = "DummyString";
        private const string NeedToBeSiteAdminErrorMessage = "You need to be a Site Collection Administrator in order to import resources.";
        private const string DSMResultProperty = "_dSMResult";
        private const string DtResourcesProperty = "_dtResources";

        [TestInitialize]
        public void TestInitializer()
        {
            _fileDeleted = false;
            _shimObject = ShimsContext.Create();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimObject?.Dispose();
        }

        private void SetupShims(bool isSiteAdmin)
        {
            _web = new ShimSPWeb
            {
                CurrentUserGet = () => new ShimSPUser
                {
                    IsSiteAdminGet = () => isSiteAdmin
                },
                SiteUserInfoListGet = () => new ShimSPList
                {
                    GetItemsStringArray = _ => new ShimSPListItemCollection().Bind(new SPListItem[]
                    {
                        new ShimSPListItem
                        {
                            ItemGetString = __ => DummyString
                        }
                    })
                },
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetString = _ => new ShimSPList
                    {
                        FieldsGet = () => new ShimSPFieldCollection
                        {
                            GetFieldByInternalNameString = name =>
                            {
                                if (name == DummyString)
                                {
                                    return new ShimSPFieldLookup
                                    {
                                        LookupListGet = () => Guid.NewGuid().ToString(),
                                        LookupFieldGet = () => DummyString
                                    };
                                }

                                return new ShimSPField();
                            }
                        }
                    },
                    ItemGetGuid = _ => new ShimSPList
                    {
                        GetItemsStringArray = __ => new ShimSPListItemCollection().Bind(new SPListItem[]
                        {
                            new ShimSPListItem
                            {
                                ItemGetString = item =>
                                {
                                    if (item == "ID")
                                    {
                                        return DummyInt;
                                    }

                                    return DummyString;
                                }
                            }
                        })
                    }
                },
                GroupsGet = () => new ShimSPGroupCollection().Bind(new SPGroup[]
                {
                    new ShimSPGroup
                    {
                        NameGet = () => DummyString,
                        IDGet = () => DummyInt
                    }
                })
            };

            ShimSPField.AllInstances.TypeGet = instance =>
            {
                if (instance is SPFieldLookup)
                {
                    return SPFieldType.Lookup;
                }

                return SPFieldType.Text;
            };

            ShimAct.ConstructorSPWeb = (_, __) => { };
            ShimAct.AllInstances.IsOnlineGet = _ => true;
            ShimAct.AllInstances.GetLevelsFromSiteInt32OutString = (Act instance, out int actType, string userName) =>
            {
                actType = DummyInt;

                return new ArrayList
                {
                    new ActLevel
                    {
                        name = DummyString,
                        id = DummyInt
                    }
                };
            };

            ShimEPMLiveFileStore.ConstructorSPWeb = (_, __) => { };
            ShimEPMLiveFileStore.AllInstances.Dispose = _ => { };
            ShimEPMLiveFileStore.AllInstances.GetStreamString = (_, __) => new ShimFileStream();
            ShimEPMLiveFileStore.AllInstances.DeleteString = (_, __) => _fileDeleted = true;

            ShimFileStream.AllInstances.DisposeBoolean = (_, __) => { };

            ShimSpreadsheetDocument.OpenStreamBoolean = (_, __) => new ShimSpreadsheetDocument
            {
                WorkbookPartGet = () => new ShimWorkbookPart
                {
                    WorkbookGet = () => new ShimWorkbook()
                }
            };

            ShimOpenXmlPackage.AllInstances.Dispose = _ => { };

            ShimOpenXmlElement.AllInstances.GetFirstChildOf1<Sheets>(_ => new ShimSheets());
            ShimOpenXmlElement.AllInstances.GetFirstChildOf1<SheetData>(_ => new ShimSheetData());
            ShimOpenXmlElement.AllInstances.ElementsOf1(_ => new List<Sheet>
            {
                new ShimSheet
                {
                    IdGet = () => DummyString
                }
            });
            ShimOpenXmlElement.AllInstances.DescendantsOf1(_ => new List<Row>
            {
                new ShimRow().Bind(new List<Cell>
                {
                    new ShimCell(),
                    new ShimCell(),
                    new ShimCell()
                }),
                new ShimRow(),
                new ShimRow()
            });
            ShimOpenXmlElement.AllInstances.DescendantsOf1(_ => new List<Cell>
            {
                new ShimCell(),
                new ShimCell(),
                new ShimCell()
            });

            ShimCellType.AllInstances.CellValueGet = _ => new ShimCellValue();
            var count1 = 0;
            ShimCellType.AllInstances.CellReferenceGet = _ =>
            {
                count1++;
                switch (count1)
                {
                    case 1:
                        return $"ResourceLevel";
                    case 2:
                        return "Permissions";
                    default:
                        count1 = 0;
                        return $"{DummyString}{DummyInt}";
                }
            };

            var count2 = 0;
            ShimOpenXmlLeafTextElement.AllInstances.InnerXmlGet = _ => 
            {
                count2++;
                switch (count2)
                {
                    case 1:
                        return "ResourceLevel";
                    case 2:
                        return "Permissions";
                    case 6:
                        return DummyInt.ToString();
                    default:
                        return DummyString;
                }
            };

            ShimOpenXmlPartContainer.AllInstances.GetPartByIdString = (_, __) => new ShimWorksheetPart
            {
                WorksheetGet = () => new ShimWorksheet()
            };
        }

        private void CreateTestObject(string data, bool isImportCancelled)
        {
            _testObj = new ResourceImporter(_web.Instance, data, true);
            _testObj.IsImportCancelled = isImportCancelled;
            _testObj.ImportCompleted += ResourceImportCompleted;
            _testObj.ImportProgressChanged += ResourceImportProgressChanged;

            _privateObj = new PrivateObject(_testObj);
        }

        private void ResourceImportCompleted(object sender, ImportCompletedEventHandlerArgs args)
        {
            // Dummy event for test purpose
        }

        private void ResourceImportProgressChanged(object sender, ImportProgressChangedEventHandlerArgs args)
        {
            // Dummy event for test purpose
        }

        [TestMethod]
        public void OnCreate_WhenUserIsNotSiteAdmin_ConfirmResult()
        {
            // Arrange
            SetupShims(false);
            
            // Act
            Action action = () => CreateTestObject(DummyString, false);

            // Assert
            Should.Throw<Exception>(action).Message.ShouldBe(NeedToBeSiteAdminErrorMessage);
        }

        [TestMethod]
        public void ImportAsync_WhenImportIsCancelled_LogCreated()
        {
            // Arrange
            SetupShims(true);
            CreateTestObject(DummyString, true);

            // Act
            _testObj.ImportAsync();

            // Assert
            var dSMResult = (ResourceImportResult)_privateObj.GetFieldOrProperty(DSMResultProperty);
            this.ShouldSatisfyAllConditions(
                () => dSMResult.Log.InfoCount.ShouldBe(1),
                () => dSMResult.Log.WarningCount.ShouldBe(0),
                () => dSMResult.Log.ErrorCount.ShouldBe(0),
                () => dSMResult.Log.Messages.Count.ShouldBe(1),
                () => dSMResult.Log.Messages[0].Message.ShouldBe("Import cancelled!"));
        }

        [TestMethod]
        public void ImportAsync_OnError_LogCreated()
        {
            // Arrange
            const string DummyErrorMessage = "Dummy Error Message";

            SetupShims(true);
            CreateTestObject(DummyString, false);

            ShimResourceImporter.AllInstances.LoadSpreadsheet = _ =>
            {
                throw new Exception(DummyErrorMessage);
            };

            // Act
            _testObj.ImportAsync();

            // Assert
            var dSMResult = (ResourceImportResult)_privateObj.GetFieldOrProperty(DSMResultProperty);
            this.ShouldSatisfyAllConditions(
                () => dSMResult.Log.InfoCount.ShouldBe(0),
                () => dSMResult.Log.WarningCount.ShouldBe(1),
                () => dSMResult.Log.ErrorCount.ShouldBe(1),
                () => dSMResult.Log.Messages.Count.ShouldBe(2),
                () => dSMResult.Log.Messages[0].Message.ShouldBe(DummyErrorMessage),
                () => dSMResult.Log.Messages[1].Message.ShouldBe("Import completed with errors!"));
        }

        [TestMethod]
        public void ImportAsync_OnValidCall_ConfirmResult()
        {
            // Arrange
            SetupShims(true);
            CreateTestObject(DummyString, false);

            // Act
            _testObj.ImportAsync();

            // Assert
            var dSMResult = (ResourceImportResult)_privateObj.GetFieldOrProperty(DSMResultProperty);
            var dtResources = (DataTable)_privateObj.GetFieldOrProperty(DtResourcesProperty);
            this.ShouldSatisfyAllConditions(
                () => dSMResult.Log.InfoCount.ShouldBe(1),
                () => dSMResult.Log.Messages[0].Message.ShouldBe("Loading Spreadsheet"),
                () => _fileDeleted.ShouldBeTrue(),
                () => dtResources.Columns.Contains(DummyString).ShouldBeTrue(),
                () => dtResources.Rows.Count.ShouldBe(1));
        }
    }
}
